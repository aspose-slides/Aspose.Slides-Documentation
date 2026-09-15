---
title: AI 助力簡報翻譯器
linktitle: AI 助力翻譯器
type: docs
weight: 20
url: /zh-hant/net/ai/translator/
keywords:
- AI 簡報翻譯器
- AI 投影片翻譯器
- AI 助力功能
- 多語言簡報
- 多語言投影片
- 簡報翻譯
- 投影片翻譯
- AI 驅動功能
- AI 能力
- AI 代理
- Web 用戶端
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 以 AI 翻譯 PowerPoint 投影片。將 PPT、PPTX 與 ODP 本地化，同時保留版面配置—快速且對開發者友善。立即體驗。"
---
## **簡介**

Aspose.Slides 是一個強大的 API，可程式化管理 PowerPoint 簡報。除了建立、編輯和轉換投影片外，它還提供 AI 驅動的功能，例如用於多語言投影片內容的 [Presentation Translation API](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ai/)。

## **運作方式**

Aspose.Slides 本身不包含內建的 AI 功能，但可透過網路整合外部 AI 模型。此功能透過 [SlidesAIAgent](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ai/slidesaiagent) 類別公開，該類別使用實作了 [IAIWebClient](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ai/iaiwebclient/) 介面的客戶端與 AI 服務通訊。

您可以使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ai/openaiwebclient/) 連接至 OpenAI 的 API，或自行實作 [IAIWebClient](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ai/iaiwebclient/) 以使用其他 AI 供應商或語言模型。

Aspose.Slides 會處理通訊、解析 AI 回應，並在保留原始投影片版面與格式的同時，智慧地插入翻譯後的內容。

{{% alert color="info" title="Note" %}}
請注意，OpenAI API 為付費服務，因此在使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ai/openaiwebclient/) 時，您需要建立帳號並提供 API 金鑰。
{{% /alert %}}

## **範例**

在此範例中，我們使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ai/openaiwebclient/) 以及指定的 OpenAI [model](https://platform.openai.com/docs/models) 將 PowerPoint 簡報翻譯成日文。

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// 載入要翻譯的簡報。
using var presentation = new Presentation("sample.pptx");

// 使用 OpenAIWebClient 建立 AI 客戶端，指定模型與 API 金鑰。
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// 使用此 AI 客戶端初始化 SlidesAIAgent。
var aiAgent = new SlidesAIAgent(aiWebClient);

// 將簡報翻譯成日文。
await aiAgent.TranslateAsync(presentation, "japanese");

// 將翻譯後的簡報儲存為 PDF。
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

預設情況下，內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ai/openaiwebclient/) 會建立並管理自己的內部 [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) 實例，自動處理其生命週期與釋放。然而，如果您希望自行管理 [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)，例如使用 [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) 以獲得更佳的資源管理與效能，您可以在建構 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ai/openaiwebclient/) 時提供自訂的 `HttpClient` 實例。

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// 使用您自行管理的 HttpClient - 例如，由 IHttpClientFactory 建立的實例
// 透過依賴注入注入
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides 通常在同步環境中使用。為了支援此情況，[SlidesAIAgent](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ai/slidesaiagent/) 類別同時提供同步與非同步方法，讓您可以選擇最符合應用程式工作流程的方式。

### **Azure OpenAI 範例**

Aspose.Slides for .NET 支援相容於 OpenAI 的供應商，包括 Azure OpenAI。您可以使用 [OpenAICompatibleWebClient](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ai/openaicompatiblewebclient/) 將翻譯器設定為使用您內部的 Azure 部署。

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

var model = "your-azure-deployment-name";
var apiKey = "your-azure-api-key";
var baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

using var aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
var aiAgent = new SlidesAIAgent(aiWebClient);
using var presentation = new Presentation("Presentation.pptx");
aiAgent.Translate(presentation, "spanish");
presentation.Save("Translated.pptx", SaveFormat.Pptx);
```

此程式碼片段示範如何使用您的 Azure OpenAI 端點翻譯簡報。請將佔位值替換為您的部署名稱、API 金鑰與端點 URL。

## **主要好處**

Aspose.Slides 的 [Presentation Translation API](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ai/) 提供一套 AI 驅動的解決方案，讓您能夠提供多語言 PowerPoint 簡報。透過自動翻譯且保留版面與設計，它能節省時間並降低相較於手動流程的錯誤風險。無論您是開發人員、教育者或商業專業人士，此 API 都能協助您為全球觀眾建立具吸引力的本地化簡報，擴大觸及範圍並提升溝通效果。