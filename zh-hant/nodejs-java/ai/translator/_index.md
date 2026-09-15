---
title: AI 驅動簡報翻譯器
linktitle: AI 驅動翻譯器
type: docs
weight: 20
url: /zh-hant/nodejs-java/ai/translator/
keywords:
- AI 簡報翻譯器
- AI 投影片翻譯器
- AI 驅動功能
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 以 AI 翻譯 PowerPoint 投影片。將 PPT、PPTX 與 ODP 本地化，同時保留版面配置—快速且開發者友好。立即試用。"
---
## **簡介**

Aspose.Slides 是一個功能強大的 API，可程式化地管理 PowerPoint 簡報。除了建立、編輯和轉換投影片之外，還提供 AI 驅動的功能，例如用於多語言投影片內容的簡報翻譯 API。

## **運作原理**

Aspose.Slides 本身不包含內建的 AI 功能，而是透過網際網路與外部 AI 模型整合。此功能透過 [SlidesAIAgent](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidesaiagent/) 類別暴露，以與 AI 服務通訊。

您可以使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/openaiwebclient/) 連接至 OpenAI 的 API。

Aspose.Slides 會處理通訊、解析 AI 回應，並在保留原始投影片版面與格式的同時，智慧地插入翻譯後的內容。

{{% alert color="info" title="注意" %}}
請注意，OpenAI API 為付費服務，使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/openaiwebclient/) 時，您需建立帳號並提供 API 金鑰。
{{% /alert %}}

## **範例**

在此範例中，我們使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/openaiwebclient/) 並指定 OpenAI 的 [model](https://platform.openai.com/docs/models) 將 PowerPoint 簡報翻譯成日文。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 載入要翻譯的簡報。
let presentation = new aspose.slides.Presentation("sample.pptx");

// 使用 OpenAIWebClient 建立 AI 客戶端，並指定模型與 API 金鑰。
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // 使用 AI 客戶端初始化 SlidesAIAgent。
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // 將簡報翻譯成日文。
    aiAgent.translate(presentation, "japanese");

    // 將翻譯後的簡報另存為 PDF。
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

預設情況下，內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/openaiwebclient/) 會建立並管理自己的內部 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 實例，並自動處理其生命週期。然而，如果您希望自行管理 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — 主要是為了設定代理、使用 [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) 或使用不同的 [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) 以獲得更佳的資源管理與效能 — 您可以在建構 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/openaiwebclient/) 時提供自訂的 `HttpURLConnection` 實例。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Create and pre-configure an HttpURLConnection instance (e.g., with custom timeouts, proxy settings, etc.)
let url = java.newInstanceSync("java.net.URL", "https://api.openai.com/v1/chat/completions");
let urlConnection = url.openConnection();
urlConnection.setConnectTimeout(10000);
urlConnection.setReadTimeout(60000);

let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Azure OpenAI 範例**

您可以使用 [OpenAICompatibleWebClient](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/openaicompatiblewebclient/)，將翻譯器設定為使用您的 Azure OpenAI 部署。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let model = "your-azure-deployment-name";
let apiKey = "your-azure-api-key";
let baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

let aiWebClient = new aspose.slides.OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);
    let presentation = new aspose.slides.Presentation("presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

此程式碼片段示範如何使用 Azure OpenAI 端點翻譯簡報。請將佔位值替換為您的部署名稱、API 金鑰與端點 URL。

## **主要優勢**

Aspose.Slides 簡報翻譯 API 提供 AI 驅動的解決方案，讓多語言 PowerPoint 簡報的交付變得更簡便。透過自動翻譯且保留版面與設計，較手動工作流程節省時間並降低錯誤。無論您是開發人員、教育工作者或企業專業人士，此 API 都能協助您為全球受眾製作具吸引力的本地化簡報，擴大影響力並提升溝通效果。