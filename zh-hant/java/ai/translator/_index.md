---
title: AI 驅動的簡報翻譯器
linktitle: AI 驅動的翻譯器
type: docs
weight: 20
url: /zh-hant/java/ai/translator/
keywords:
- AI 簡報翻譯器
- AI 投影片翻譯器
- AI 驅動的功能
- 多語言簡報
- 多語言投影片
- 簡報翻譯
- 投影片翻譯
- AI 驅動的功能
- AI 能力
- AI 代理程式
- Web 用戶端
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 的 AI 來翻譯 PowerPoint 投影片。將 PPT、PPTX 與 ODP 本地化，同時保留版面配置——快速且開發者友好。立即試用。"
---
## **簡介**

Aspose.Slides 是一個強大的 API，可編程地管理 PowerPoint 簡報。除了建立、編輯和轉換投影片之外，它還提供 AI 驅動的功能，例如用於多語言投影片內容的簡報翻譯 API。

## **運作方式**

Aspose.Slides 本身不包含內建的 AI 功能，而是透過網路整合外部 AI 模型。此功能透過 [SlidesAIAgent](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidesaiagent/) 類別公開，該類別使用 [IAIWebClient](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iaiwebclient/) 介面的實作與 AI 服務通訊。

您可以使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/openaiwebclient/) 連接至 OpenAI 的 API，或實作自己的 [IAIWebClient](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iaiwebclient/) 以使用其他 AI 供應商或語言模型。

Aspose.Slides 會處理通訊、解析 AI 回應，並在保留原始投影片版面與格式的同時，智慧地插入翻譯內容。

{{% alert color="primary" %}}
請注意，OpenAI API 是付費服務，因此在使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/openaiwebclient/) 時，您需要建立帳號並提供 API 金鑰。
{{% /alert %}}

## **範例**

在此範例中，我們使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/openaiwebclient/) 並指定 OpenAI 的 [model](https://platform.openai.com/docs/models) ，將 PowerPoint 簡報翻譯成日文。

```java
// 載入要翻譯的簡報。
Presentation presentation = new Presentation("sample.pptx");

// 使用 OpenAIWebClient 建立 AI 客戶端，指定模型與 API 金鑰。
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // 使用 AI 客戶端初始化 SlidesAIAgent。
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // 將簡報翻譯成日文。
    aiAgent.translate(presentation, "japanese");

    // 將翻譯後的簡報儲存為 PDF。
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

預設情況下，內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/openaiwebclient/) 會建立並管理自己的內部 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 實例，並自動處理其生命週期。然而，如果您希望自行管理 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — 主要是為了設定代理等必要設定，或使用 [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) 或不同的 [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) 以獲得更佳的資源管理與效能 — 您可以在建構 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/openaiwebclient/) 時提供自己的 `HttpURLConnection` 實例。

```java
// 假設您已經有一個預先配置好的 HttpURLConnection 實例（例如，帶有自訂逾時、代理設定等）。
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **主要優點**

Aspose.Slides 簡報翻譯 API 提供一個 AI 驅動的解決方案，用於交付多語言 PowerPoint 簡報。透過在保留版面與設計的同時自動化翻譯，可節省時間並降低相較於手動流程的錯誤。無論您是開發人員、教育者或商業專業人士，這個 API 都能協助您為全球受眾建立具吸引力的在地化簡報，擴大觸及範圍並提升溝通效果。