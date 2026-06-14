---
title: AI 驅動的多語言投影片產生器
linktitle: AI 驅動的產生器
type: docs
weight: 40
url: /zh-hant/net/ai/generator/
keywords:
- 多語言簡報
- 多語言投影片
- AI 簡報產生器
- AI 投影片產生器
- AI 驅動功能
- AI 代理
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 從文字產生多語言投影片。套用您的範本並匯出完善的簡報至 PowerPoint 和 OpenDocument。了解更多。"
---
## **簡介**

Aspose.Slides 引入了一項新的 AI 驅動功能——Presentation Generator，允許開發人員從簡單的文字輸入（如主題說明、摘要、引語或項目符號）自動建立結構良好的 PowerPoint 簡報。

使用者可以調整內容細節層級，並可選擇套用自訂簡報範本以定義視覺設計。

目前，AI Presentation Generator 以文字區塊、項目清單和表格來組織內容。尚未支援影像產生；但可在之後使用 Aspose.Slides 工具或手動方式輕鬆加入圖片。

輸出為完整的 PowerPoint 簡報，可直接使用或匯出為 Aspose.Slides API 支援的任何格式。雖然產生器能產出高品質結果，但可能仍需少量後期編輯以符合特定需求。

## **運作方式**

Aspose.Slides 不內建 AI 模型；相反地，它透過網路與外部 AI 服務整合。此整合由[SlidesAIAgent](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ai/slidesaiagent/)類別處理，該類別使用[IAIWebClient](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ai/iaiwebclient/)介面的實作與 AI 模型通訊。

您可以使用內建的[OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ai/openaiwebclient/)，它連接到 OpenAI 的 API，或提供自訂的[IAIWebClient](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ai/iaiwebclient/)實作以使用其他 AI 供應商或語言模型。Aspose.Slides 會管理與 AI 服務的所有通訊，並處理 AI 的回應以產生投影片。請注意，OpenAI API 為付費服務，使用內建的[OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ai/openaiwebclient/) 時需要帳號與 API 金鑰。

## **讓我們編寫程式**

### **範例 1**

此範例示範如何使用內建的[OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ai/openaiwebclient/)產生有關 Aspose.Slides 主題的簡報。

```csharp
// 建立 OpenAIWebClient 的實例，這是內建的 OpenAI 網路客戶端實作。
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

// 建立 SlidesAIAgent 的實例，可存取 AI 驅動的功能。
var aiAgent = new SlidesAIAgent(aiWebClient);

// 定義產生簡報的指示。
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// 根據指示產生內容為中等量的簡報。
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Medium);

// 將產生的簡報儲存至本機磁碟，為 PowerPoint (.pptx) 檔案。
presentation.Save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
```

### **範例 2**

以下範例展示[GeneratePresentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ai/slidesaiagent/generatepresentation/)方法的多載情況。在此情況下，使用外部管理的[HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)實例以及使用者的 `master presentation`。

預設情況下，內建的[OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ai/openaiwebclient/)會建立並管理其自行的內部[HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)實例，並自動處理其生命週期與釋放。但若您希望自行管理[HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)（例如使用[IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory)以改善資源管理與效能），則可在建構[OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ai/openaiwebclient/)時提供自己的[HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)實例。

```csharp
// 建立外部管理的 HttpClient 實例。
using var httpClient = new HttpClient();

// 將 HttpClient 傳遞給 OpenAIWebClient 建構函式。
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", httpClient);

// 建立 SlidesAIAgent 的實例。
var aiAgent = new SlidesAIAgent(aiWebClient);

// 定義產生簡報的指示。
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// 從本機磁碟載入主簡報作為設計範本。
using var masterPresentation = new Presentation("masterPresentation.pptx");

// 使用指示與主範本產生詳細的簡報。
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Detailed, masterPresentation);

// 將產生的簡報另存為 PDF。
presentation.Save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
```

值得注意的是，許多客戶在同步情境下使用 Aspose.Slides。為了支援此需求，[SlidesAIAgent](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ai/slidesaiagent/)類別同時提供同步與非同步方法，讓您可依應用程式的工作流程選擇最合適的方式。

## **主要優勢**

Aspose.Slides 中全新的 AI Presentation Generator 提供了一種快速且彈性的方式，從簡單文字提示產生結構化的投影片組。支援自訂範本、外部管理的[HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)實例，以及同步與非同步工作流程，使其能無縫整合至各種應用程式。

典型使用情境包括製作行銷簡報、教育教材、客戶報告與內部投影片。雖然目前尚未支援影像產生，但此工具已奠定自動化簡報製作的堅實基礎，未來亦將持續加入更多功能。