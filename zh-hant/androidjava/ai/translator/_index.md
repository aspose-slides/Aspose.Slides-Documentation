---
title: AI 驅動的簡報翻譯器
linktitle: AI 驅動的翻譯器
type: docs
weight: 20
url: /zh-hant/androidjava/ai/translator/
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
- AI 代理程式
- 網路客戶端
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android (Java) 以 AI 翻譯 PowerPoint 投影片。將 PPT、PPTX 與 ODP 本地化，同時保留版面配置——快速且對開發人員友善。立即體驗。"
---
## **簡介**

Aspose.Slides 是一個功能強大的 API，可用於程式化管理 PowerPoint 簡報。除了建立、編輯和轉換投影片外，還提供 AI 驅動的功能──例如用於多語言投影片內容的 Presentation Translation API。

## **運作方式**

Aspose.Slides 並未內建 AI 功能，但可與網際網路上的外部 AI 模型整合。此功能透過 [SlidesAIAgent](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slidesaiagent/) 類別公開，該類別使用 [IAIWebClient](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iaiwebclient/) 介面的實作來與 AI 服務通訊。

您可以使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/openaiwebclient/) 連接至 OpenAI 的 API，或自行實作 [IAIWebClient](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iaiwebclient/) 以使用其他 AI 供應商或語言模型。

Aspose.Slides 處理通訊、解析 AI 回應，並在保留原始投影片版面配置與格式的同時，智慧地插入翻譯後的內容。

{{% alert color="info" title="Note" %}}
請注意，OpenAI API 為付費服務，使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/openaiwebclient/) 時，您需要建立帳號並提供 API 金鑰。
{{% /alert %}}

## **範例**

在此範例中，我們使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/openaiwebclient/) 與指定的 OpenAI [model](https://platform.openai.com/docs/models) 將 PowerPoint 簡報翻譯成日文。

```java
import com.aspose.slides.*;

// 載入要翻譯的簡報。
Presentation presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // 使用 AI 客戶端初始化 SlidesAIAgent。
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // 將簡報翻譯成日文。
    aiAgent.translate(presentation, "japanese");

    // 將翻譯後的簡報另存為 PDF。
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

預設情況下，內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/openaiwebclient/) 會建立並管理其自身的內部 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 實例，自動處理其生命週期。然而，如果您希望自行管理 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)——主要是為了設定代理等必要設定，或使用 [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) 或不同的 [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) 以獲得更佳的資源管理與效能——您可以在建構 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/openaiwebclient/) 時提供自己的 `HttpURLConnection` 實例。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // 自行配置 HttpURLConnection 實例（例如自訂逾時、代理設定等）。
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // 將連線傳遞給 OpenAIWebClient 建構函式。
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

### **Azure OpenAI 範例**

您可以使用 [OpenAICompatibleWebClient](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/openaicompatiblewebclient/) 設定翻譯器，以使用您在 Azure OpenAI 的部署。

```java
import com.aspose.slides.*;

String model = "your-azure-deployment-name";
String apiKey = "your-azure-api-key";
String baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

OpenAICompatibleWebClient aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);
    Presentation presentation = new Presentation("Presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

此程式碼片段示範如何使用 Azure OpenAI 端點翻譯簡報。請將佔位值替換為您的部署名稱、API 金鑰與端點 URL。

## **主要優點**

Aspose.Slides Presentation Translation API 提供一個 AI 驅動的解決方案，讓您能夠提供多語言的 PowerPoint 簡報。透過自動翻譯且保留版面與設計，較手動流程可節省時間並減少錯誤。無論您是開發人員、教育者或商務專業人士，此 API 都能協助您為全球受眾打造引人入勝的在地化簡報，擴大影響力並提升溝通效果。