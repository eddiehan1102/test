using System;
using System.Threading;
using System.Threading.Tasks;

namespace BinanceRealtime
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string symbol = "ethusdt";
            Console.WriteLine($"Connecting to Binance WebSocket for {symbol} price...");
            var client = new BinanceWebSocketClient();
            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) => {
                e.Cancel = true;
                cts.Cancel();
            };

            try
            {
                await client.ConnectAsync(symbol, cts.Token);
            }
            catch (OperationCanceledException)
            {
                // graceful exit
            }
        }
    }
}
