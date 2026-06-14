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
- AI 驅動特性
- AI 能力
- AI 代理
- Web 客戶端
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP 以 AI 翻譯 PowerPoint 投影片。將 PPT、PPTX 和 ODP 本地化，同時保留版面配置——快速且對開發者友好。立即試用。"
---
## **簡介**

Aspose.Slides 是一個功能強大的 API，用於程式化管理 PowerPoint 簡報。除了建立、編輯和轉換投影片外，它還提供 AI 驅動的功能，例如用於多語言投影片內容的簡報翻譯 API。

## **運作方式**

Aspose.Slides 不內建 AI 功能，但會透過網際網路整合外部 AI 模型。此功能透過 [SlidesAIAgent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidesaiagent/) 類別公開，以與 AI 服務通訊。

您可以使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/openaiwebclient/) 連接至 OpenAI 的 API。

Aspose.Slides 處理通訊、剖析 AI 回應，並在保留原始投影片版面與格式的同時，智慧地插入翻譯後的內容。

{{% alert color="primary" %}}
請注意，OpenAI API 為付費服務，因此在使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/openaiwebclient/) 時，您需要建立帳號並提供您的 API 金鑰。
{{% /alert %}}

## **範例**

在此範例中，我們使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/openaiwebclient/) 以及指定的 OpenAI [model](https://platform.openai.com/docs/models) 將 PowerPoint 簡報翻譯成日文。

```php
// 載入要翻譯的簡報。
$presentation = new Presentation("sample.pptx");

// 使用 OpenAIWebClient 建立 AI 客戶端，並指定您的模型和 API 金鑰。
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // 使用 AI 客戶端初始化 SlidesAIAgent。
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // 將簡報翻譯成日文。
    $aiAgent->translate($presentation, "japanese");

    // 將翻譯後的簡報儲存為 PDF。
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```

預設情況下，內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/openaiwebclient/) 會建立並管理其自己的內部 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 實例，並自動處理其生命週期。然而，如果您希望自行管理 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)——主要是為了設定代理等必要設定，或是使用 [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) 或不同的 [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) 以獲得更佳的資源管理與效能——您可以在構造 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/openaiwebclient/) 時提供自己的 `HttpURLConnection` 實例。

```php
// 假設您已擁有預先配置好的 HttpURLConnection 實例（例如，自訂逾時、代理設定等）。
$urlConnection = $yourPreconfiguredConnection;
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

## **主要優勢**

Aspose.Slides 簡報翻譯 API 提供 AI 驅動的解決方案，以交付多語言的 PowerPoint 簡報。透過自動化翻譯且保持版面與設計，較手動流程節省時間並降低錯誤。無論您是開發者、教育者，或是商業專業人士，此 API 都能協助您為全球受眾建立吸引人且在地化的簡報，擴大影響力並提升溝通效果。