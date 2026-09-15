---
title: AI 驅動的簡報翻譯器
linktitle: AI 驅動的翻譯器
type: docs
weight: 20
url: /zh-hant/php-java/ai/translator/
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
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP 以 AI 翻譯 PowerPoint 投影片。 在保留版面的同時本地化 PPT、PPTX 與 ODP — 快速且開發者友善。 立即試用。"
---
## **簡介**

Aspose.Slides 是一個功能強大的 API，用於以程式方式管理 PowerPoint 簡報。除了建立、編輯和轉換投影片外，它還提供 AI 驅動的功能，例如用於多語言投影片內容的 Presentation Translation API。

## **運作方式**

Aspose.Slides 本身不含內建 AI 功能，但會透過網際網路與外部 AI 模型整合。此功能透過 [SlidesAIAgent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidesaiagent/) 類別來與 AI 服務通訊。

您可以使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/openaiwebclient/) 連接至 OpenAI 的 API。

Aspose.Slides 會處理通訊、解析 AI 回應，並在保留原始投影片版面配置與格式的同時，智慧地插入翻譯後的內容。

{{% alert color="info" title="Note" %}}
請注意，OpenAI API 為付費服務，使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/openaiwebclient/) 時，您需要建立帳號並提供 API 金鑰。
{{% /alert %}}

## **範例**

在此範例中，我們使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/openaiwebclient/) 搭配指定的 OpenAI [model](https://platform.openai.com/docs/models) 將 PowerPoint 簡報翻譯成日文。

```php
// 載入要翻譯的簡報。
$presentation = new Presentation("sample.pptx");

// 使用 OpenAIWebClient 建立 AI 用戶端，指定您的模型與 API 金鑰。
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // 使用 AI 用戶端初始化 SlidesAIAgent。
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // 將簡報翻譯成日文。
    $aiAgent->translate($presentation, "japanese");

    // 將翻譯後的簡報保存為 PDF。
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```

預設情況下，內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/openaiwebclient/) 會自行建立並管理其內部的 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 實例，並自動處理其生命週期。然而，如果您希望自行管理 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) —— 主要是為了設定代理或使用 [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) 或其他 [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) 以提升資源管理與效能 —— 您可以在建構 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/openaiwebclient/) 時提供自訂的 `HttpURLConnection` 實例。

```php
// 建立並預先設定您自己的 HttpURLConnection 實例（自訂逾時、代理設定等）。
$url = new Java("java.net.URL", "https://api.openai.com/v1/chat/completions");
$urlConnection = $url->openConnection();
$urlConnection->setConnectTimeout(10000);
$urlConnection->setReadTimeout(60000);

// 將連線傳遞給 AI 用戶端。
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

### **Azure OpenAI 範例**

您可以使用 [OpenAICompatibleWebClient](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/openaicompatiblewebclient/) 設定翻譯器，使用您的 Azure OpenAI 部署。

```php
use aspose\slides\OpenAICompatibleWebClient;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlidesAIAgent;

$model = "your-azure-deployment-name";
$apiKey = "your-azure-api-key";
$baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

$aiWebClient = new OpenAICompatibleWebClient($model, $apiKey, $baseUrl);
try {
    $aiAgent = new SlidesAIAgent($aiWebClient);
    $presentation = new Presentation("Presentation.pptx");
    try {
        $aiAgent->translate($presentation, "spanish");
        $presentation->save("Translated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $aiWebClient->dispose();
}
```

此程式碼片段示範如何使用您的 Azure OpenAI 端點翻譯簡報。請將佔位值取代為您的部署名稱、API 金鑰與端點 URL。

## **主要優勢**

Aspose.Slides Presentation Translation API 提供 AI 驅動的解決方案，讓您能傳遞多語言的 PowerPoint 簡報。透過自動翻譯並保留版面與設計，相較於手動流程可節省時間並減少錯誤。無論您是開發人員、教育工作者或商業專業人士，此 API 都能協助您為全球受眾建立具吸引力的本地化簡報，擴大影響力並提升溝通效果。