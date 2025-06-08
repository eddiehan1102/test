# Binance 即時加密貨幣 API 串接專案

## 專案簡介
本專案以 C# 開發，目標為串接 Binance 幣安交易所的即時加密貨幣行情 API，實現即時行情訂閱、資料解析與後續策略開發的基礎架構。適合用於量化交易、即時監控或自動化策略開發。

## 主要功能
- 連接 Binance WebSocket API，取得即時加密貨幣行情（如 BTC/USDT 等）
- 支援多幣種行情訂閱
- 即時資料解析與顯示
- 可擴充自動交易或策略模組

## 技術架構
- 語言：C# (.NET 6 或以上)
- 主要函式庫：
  - `WebSocketSharp` 或 `System.Net.WebSockets`（WebSocket 連線）
  - `Newtonsoft.Json`（JSON 解析）
- 可擴充性設計，方便後續加入下單、策略等功能

## 安裝與執行步驟
1. **下載專案**
   ```bash
   git clone <本專案網址>
   ```
2. **安裝相依套件**
   ```bash
   dotnet restore
   ```
3. **編譯與執行**
   ```bash
   dotnet run
   ```
4. **設定訂閱幣種**
   - 可於 `appsettings.json` 或程式碼中調整需要訂閱的幣種與交易對

## 主要檔案結構
```
|-- README.md
|-- Program.cs
|-- BinanceWebSocketClient.cs
|-- appsettings.json
|-- ...
```

## 注意事項
- 請確保網路暢通，且未遭防火牆阻擋 WebSocket 連線
- 本專案僅用於學術研究與技術交流，請勿用於非法用途
- 若需下單功能，請妥善保管 API Key 與 Secret，勿上傳至公開倉庫

---

如需協助或有其他功能需求，歡迎提出！
