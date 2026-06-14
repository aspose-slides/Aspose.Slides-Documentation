---
title: AI 驅動的簡報翻譯器
linktitle: AI 驅動的翻譯器
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
description: "使用 Aspose.Slides for Node.js 的 AI 翻譯 PowerPoint 投影片。將 PPT、PPTX 與 ODP 本地化，同時保留版面配置——快速且友善開發者。立即試用。"
---
## **簡介**

Aspose.Slides 是一個功能強大的 API，可程式化管理 PowerPoint 簡報。除了建立、編輯與轉換投影片外，它還提供 AI 驅動的功能，例如用於多語言投影片內容的簡報翻譯 API。

## **運作方式**

Aspose.Slides 本身不包含內建的 AI 功能，而是透過網路與外部 AI 模型整合。此功能透過 [SlidesAIAgent](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidesaiagent/) 類別公開，以與 AI 服務溝通。

您可以使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/openaiwebclient/) 來連接 OpenAI 的 API。

Aspose.Slides 負責通訊、解析 AI 回應，並在保持原始投影片版面與格式的同時，智慧地插入翻譯後的內容。

{{% alert color="primary" %}}
請注意，OpenAI API 為付費服務，因此在使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/openaiwebclient/) 時，您需要創建帳號並提供 API 金鑰。
{{% /alert %}}

## **範例**

在此範例中，我們使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/openaiwebclient/) 搭配指定的 OpenAI [model](https://platform.openai.com/docs/models) 將 PowerPoint 簡報翻譯成日文。

```js
// 載入要翻譯的簡報。
let presentation = new aspose.slides.Presentation("sample.pptx");

// 使用 OpenAIWebClient 建立 AI 客戶端，指定您的模型與 API 金鑰。
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

預設情況下，內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/openaiwebclient/) 會建立並管理其內部的 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 實例，並自動處理其生命周期。然而，如果您想自行管理 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) —— 主要是為了設定必要的項目，例如代理伺服器，或使用 [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) 或不同的 [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) 以獲得更佳的資源管理與效能 —— 您可以在建構 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/openaiwebclient/) 時提供自己的 `HttpURLConnection` 實例。

```js
// 假設您已經有一個預先配置的 HttpURLConnection 實例 (例如，具有自訂逾時、代理設定等)
let urlConnection = yourPreconfiguredConnection;
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **主要優勢**

Aspose.Slides 簡報翻譯 API 提供一個 AI 驅動的解決方案，協助製作多語言 PowerPoint 簡報。透過自動化翻譯且保留版面與設計，與手動流程相比可節省時間並降低錯誤。無論您是開發者、教育者或商務專業人士，此 API 都能讓您為全球受眾打造吸引人且在地化的簡報，擴大影響力並提升溝通效果。