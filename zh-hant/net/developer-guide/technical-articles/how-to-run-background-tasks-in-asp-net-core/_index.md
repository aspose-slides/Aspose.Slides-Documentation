---
title: 如何在 ASP.NET Core 中執行背景工作
type: docs
weight: 300
url: /zh-hant/net/how-to-run-background-tasks-in-asp-net-core/
keywords:
- ASP.NET Core
- 背景工作
- 背景處理
- 託管服務
- 背景工作者
- 工作佇列
- 非同步工作排程
- 伺服器端檔案處理
- 進度追蹤
- 狀態輪詢
- SignalR 通知
- AWS SQS
- Amazon S3
- Amazon DynamoDB
- 可擴充架構
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 ASP.NET Core 中使用託管服務、工作佇列與狀態更新執行背景工作──使用 Aspose.Slides 處理與轉換 PPT、PPTX 與 ODP。"
---
## **簡介**

File processing（例如，將簡報匯出為 PDF）是一項典型的伺服器端工作。 在請求處理程式內執行（客戶端等待時）會有以下缺點：

- *使用者介面不佳。* 頁面會凍結，使用者必須等候結果。重新載入頁面會取消任務。
- *作業逾時。* 我們無法保證處理能在固定時間內完成，使用者可能會看到「作業逾時」的訊息。
- *吞吐量與可擴充性低。* ASP.NET Core 設計為非同步處理大量請求。CPU 綁定、長時間執行的任務會阻塞執行緒，降低伺服器吞吐量。
- *容錯能力不足。* 若長時間任務執行期間發生問題（例如連線問題），處理會失敗，且必須從頭重新開始。

一個[更好的做法](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/best-practices?view=aspnetcore-9.0#complete-long-running-tasks-outside-of-http-requests)是將工作排程為非同步，於背景執行，並在完成後回傳結果。

在此模型中，使用者可以看到目前狀態（且可離開或重新載入頁面），伺服器資源可有效擴展並彈性調整，且可套用重試政策。

典型的背景處理解決方案包含：

1. 用於排程工作的 API。
2. 用於追蹤工作狀態的 API。
3. 用於處理已排程工作的背景工作者。
4. 用於儲存與取得結果的 API。

## **背景工作範例**

為了示範此方法，請參考[示範 ASP.NET Core 3.1 網路應用程式](./BackgroundJobDemo.zip)。該應用程式包含一個頁面，使用者可以上傳簡報並點選**匯出為 PDF**；簡報會被上傳後，由背景工作者轉換為 PDF。

## **Web 應用程式**

示範 Web 應用程式（*BackgroundJobDemo* 專案）包含：

- 檔案上傳頁面（Razor 頁面「Upload」）。
- 進度頁面（Razor 頁面「Progress」包含幾個檢查與顯示狀態的 JavaScript 函式）。
- Controller (`JobStatusController`) 提供處理狀態 (`api/status/{jobId}`)。
- Controller (`JobResultController`) 回傳匯出的 PDF 檔案 (`api/result/{id}`)。
- 基於 ASP.NET Core 主機服務的背景工作者（請參考 `WorkerService` 類別）。

Razor 頁面、Controller 與背景工作者透過在 *BackgroundJobDemo.Common* 專案中定義的介面委派實際工作。工作管理與處理的具體實作提供於獨立的專案（*BackgroundJobDemo.Local*、*BackgroundJobDemo.Aws* 等），可在 `Startup.ConfigureServices` 方法中切換。

為了示範，"Upload" 頁面使用緩衝的模型繫結，但對於大型檔案上傳，建議使用非緩衝串流[建議](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads)。於正式環境，請考慮相關的[安全性考量](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads#security-considerations)。"Progress" 頁面每兩秒透過 JavaScript 輪詢排程工作狀態（此間隔可設定）。輪詢是常見做法，但在更進階的情境中可能需要透過 WebSocket 取得即時通知（即時通訊超出本文範圍）。[SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr) 是一個簡單且功能強大的即時通訊工具。

在伺服器行程中託管背景工作者對於簡易應用程式相當方便，但有[缺點](https://haacked.com/archive/2011/10/16/the-dangers-of-implementing-recurring-background-tasks-in-asp-net.aspx)。更健全且具可擴充性的做法是將工作者部署於獨立行程（例如請參考 *BackgroundJobDemo.Worker* 主控台應用程式）。

## **基本實作**

*BackgroundJobDemo.Local* 專案提供使用 SQLite 資料庫的簡易工作管理實作（資料庫路徑透過 `LocalConfig.DbFilePath` 設定；請參考 `Startup.ConfigureServices`）。上傳與處理後的檔案儲存在檔案系統中（儲存資料夾路徑透過 `LocalConfig.FileStorageFolderPath` 設定；請參考 `Startup.ConfigureServices`）。在真實應用中，為了提升容錯能力與效能，工作排程應透過訊息佇列實作（例如 RabbitMQ、AWS SQS、Azure Storage Queue）。

## **基於 Amazon Web Services 的分散式實作**

*BackgroundJobDemo.Aws* 專案在 Amazon Web Services 上實作工作處理，並示範水平可擴充的分散式架構。它包含以下元件：

- Web 應用程式 — 與使用者互動並排程 PPTX 轉 PDF 的匯出工作等。
- Worker — 處理匯出（在行程內、行程外，或 AWS Lambda）。
- Message queue — 儲存待處理的工作（Amazon SQS）。
- File storage — 儲存上傳與處理後的檔案（Amazon S3）。
- Key–value store — 追蹤工作處理狀態（Amazon DynamoDB）。

典型的分散式架構依賴[訊息佇列](https://aws.amazon.com/message-queue/)：Web 應用程式將背景工作放入佇列；背景工作者從佇列取得工作並執行所需工作。此方式使元件解耦，且處理具備非同步與可靠性。佇列保證傳遞，並使用*visibility timeout*（可見性逾時）：當某個工作者取得訊息時，該訊息對其他工作者即隱藏；只有執行中的工作者於完成後移除它。若處理未在可見性逾時內完成（例如因失敗或網路問題），未處理的訊息會再次變為可見。

我們的實作使用[Amazon Simple Queue Service](https://aws.amazon.com/sqs/)（SQS），這是一項為微服務、分散式系統與無伺服器應用程式提供的全代管訊息佇列服務。

訊息佇列旨在傳遞輕量級訊息（例如 SQS 訊息大小上限為 256 KB），因此訊息僅應包含工作描述。大量資料（如待處理的檔案）應另行儲存並在訊息中引用。[Amazon S3](https://aws.amazon.com/s3/) 用於儲存上傳與處理後的檔案。

需要一個鍵值存儲來依 ID 持久化與取得工作結果。本範例使用[Amazon DynamoDB](https://aws.amazon.com/dynamodb/)，這是一項快速且彈性的 NoSQL 資料庫服務。

若要在 Amazon Web Services 上執行示範應用程式：

1. 在相同的 AWS 區域中，建立並設定：
   1. SQS 佇列，
   1. S3 儲存貯體，
   1. DynamoDB 資料表。
1. 透過在 `Startup.ConfigureServices` 中呼叫*AddAws*，將 Web 應用程式連接至這些服務，並提供 SQS 佇列 URL、S3 儲存貯體名稱、DynamoDB 資料表名稱與 AWS 區域。

## **參考資料**

- [ASP.NET Core 效能最佳實踐](https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices)
- [在 ASP.NET Core 上傳檔案](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads)
- [使用 SignalR 的即時 ASP.NET](https://dotnet.microsoft.com/apps/aspnet/signalr)
- [訊息佇列](https://aws.amazon.com/message-queue/)
- [Amazon Simple Queue Service](https://aws.amazon.com/sqs/)
- [Amazon S3](https://aws.amazon.com/s3/)
- [Amazon DynamoDB](https://aws.amazon.com/dynamodb/)