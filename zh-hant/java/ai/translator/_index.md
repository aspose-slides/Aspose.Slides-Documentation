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
- 多語系簡報
- 多語系投影片
- 簡報翻譯
- 投影片翻譯
- AI 驅動的功能
- AI 能力
- AI 代理
- Web 用戶端
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 的 AI 來翻譯 PowerPoint 投影片。將 PPT、PPTX 與 ODP 本地化，同時保留版面配置——快速且對開發人員友好。立即嘗試。"
---
## **簡介**

Aspose.Slides 是一個功能強大的 API，可用於以程式方式管理 PowerPoint 簡報。除了建立、編輯和轉換投影片外，它還提供 AI 驅動的功能，例如用於多語言投影片內容的 Presentation Translation API。

## **工作原理**

Aspose.Slides 本身不包含內建的 AI 功能，但可透過網際網路整合外部 AI 模型。此功能透過 [SlidesAIAgent](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidesaiagent/) 類別暴露，該類別使用實作 [IAIWebClient](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iaiwebclient/) 介面的實例與 AI 服務進行通訊。

您可以使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/openaiwebclient/) 連接至 OpenAI 的 API，或實作自己的 [IAIWebClient](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iaiwebclient/) 以使用其他 AI 供應商或語言模型。

Aspose.Slides 負責處理通訊、解析 AI 回應，並在保留原始投影片版面配置與格式的同時，智慧地插入翻譯內容。

{{% alert color="info" %}}
請注意，OpenAI API 為付費服務，因此在使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/openaiwebclient/) 時，您需要建立帳號並提供 API 金鑰。
{{% /alert %}}

## **範例**

在此範例中，我們使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/openaiwebclient/) 結合指定的 OpenAI [model](https://platform.openai.com/docs/models)，將 PowerPoint 簡報翻譯成日文。

```java
import com.aspose.slides.*;

// 載入要翻譯的簡報。
Presentation presentation = new Presentation("sample.pptx");

// 使用 OpenAIWebClient 建立 AI 用戶端，並指定模型與 API 金鑰。
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // 使用 AI 用戶端初始化 SlidesAIAgent。
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

預設情況下，內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/openaiwebclient/) 會建立並管理其內部的 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 實例，自動處理其生命週期。然而，如果您希望自行管理 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)（主要是為了設定代理等必要設定，或使用 [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) 或其他 [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) 以獲得更佳的資源管理與效能），則可在建構 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/openaiwebclient/) 時提供自己的 `HttpURLConnection` 實例。

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// 自行配置 HttpURLConnection 實例（自訂逾時、代理設定等）。
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **關鍵優勢**

Aspose.Slides Presentation Translation API 提供一個 AI 驅動的解決方案，用於呈現多語言 PowerPoint 簡報。透過自動化翻譯且保留版面與設計，它比手動流程省時且降低錯誤。無論您是開發人員、教育工作者或商業專業人士，此 API 都能協助您為全球受眾打造具吸引力且本地化的簡報，擴大影響範圍並提升溝通效果。