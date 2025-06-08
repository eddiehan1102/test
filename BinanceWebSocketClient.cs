using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BinanceRealtime
{
    public class BinanceWebSocketClient
    {
        private ClientWebSocket? _webSocket;

        public async Task ConnectAsync(string symbol, CancellationToken token)
        {
            _webSocket = new ClientWebSocket();
            var url = new Uri($"wss://stream.binance.com:9443/ws/{symbol}@trade");
            await _webSocket.ConnectAsync(url, token);
            await ReceiveLoop(token);
        }

        private async Task ReceiveLoop(CancellationToken token)
        {
            if (_webSocket == null) return;
            var buffer = new byte[8192];
            while (_webSocket.State == WebSocketState.Open && !token.IsCancellationRequested)
            {
                var result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), token);
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed", token);
                    break;
                }
                var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                ParseAndPrint(message);
            }
        }

        private void ParseAndPrint(string json)
        {
            try
            {
                var obj = JObject.Parse(json);
                var price = obj["p"]?.ToString();
                if (!string.IsNullOrEmpty(price))
                {
                    Console.WriteLine($"ETH/USDT Price: {price}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing message: {ex.Message}");
            }
        }
    }
}
