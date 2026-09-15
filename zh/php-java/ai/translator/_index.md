---
title: AI 驱动的演示文稿翻译器
linktitle: AI 驱动的翻译器
type: docs
weight: 20
url: /zh/php-java/ai/translator/
keywords:
- AI 演示文稿翻译器
- AI 幻灯片翻译器
- AI 驱动的功能
- 多语言演示文稿
- 多语言幻灯片
- 演示文稿翻译
- 幻灯片翻译
- AI 驱动的特性
- AI 能力
- AI 代理
- Web 客户端
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP 的 AI 将 PowerPoint 幻灯片翻译成多语言。对 PPT、PPTX 和 ODP 进行本地化，同时保留布局——快速且对开发者友好。立即试用。"
---
## **介绍**

Aspose.Slides 是一个功能强大的 API，用于以编程方式管理 PowerPoint 演示文稿。除了创建、编辑和转换幻灯片外，它还提供 AI 驱动的功能——例如用于多语言幻灯片内容的 Presentation Translation API。

## **工作原理**

Aspose.Slides 本身不包含内置的 AI 功能，而是通过互联网与外部 AI 模型集成。该功能通过 [SlidesAIAgent](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidesaiagent/) 类公开，以便与 AI 服务通信。

您可以使用内置的 [OpenAIWebClient](https://reference.aspose.com/slides/zh/php-java/aspose.slides/openaiwebclient/) 连接到 OpenAI 的 API。

Aspose.Slides 负责通信，解析 AI 响应，并在保持原始幻灯片布局和格式的同时智能地插入翻译后的内容。

{{% alert color="info" title="注意" %}}
需要注意的是，OpenAI API 是付费服务，使用内置的 [OpenAIWebClient](https://reference.aspose.com/slides/zh/php-java/aspose.slides/openaiwebclient/) 时，您需要创建账户并提供 API 密钥。
{{% /alert %}}

## **示例**

在本示例中，我们使用内置的 [OpenAIWebClient](https://reference.aspose.com/slides/zh/php-java/aspose.slides/openaiwebclient/) 并指定 OpenAI [model](https://platform.openai.com/docs/models) 将 PowerPoint 演示文稿翻译为日语。

```php
// 加载要翻译的演示文稿。
$presentation = new Presentation("sample.pptx");

// 使用 OpenAIWebClient 创建 AI 客户端，指定模型和 API 密钥。
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // 使用 AI 客户端初始化 SlidesAIAgent。
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // 将演示文稿翻译为日语。
    $aiAgent->translate($presentation, "japanese");

    // 将翻译后的演示文稿保存为 PDF。
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```

默认情况下，内置的 [OpenAIWebClient](https://reference.aspose.com/slides/zh/php-java/aspose.slides/openaiwebclient/) 会创建并管理其内部的 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 实例，自动处理其生命周期。但如果您希望自行管理 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)——主要是为了配置代理等必要设置，或使用 [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) 或不同的 [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) 以获得更好的资源管理和性能——则可以在构造 [OpenAIWebClient](https://reference.aspose.com/slides/zh/php-java/aspose.slides/openaiwebclient/) 时提供您自己的 `HttpURLConnection` 实例。

```php
// 创建并预先配置您自己的 HttpURLConnection 实例（自定义超时、代理设置等）。
$url = new Java("java.net.URL", "https://api.openai.com/v1/chat/completions");
$urlConnection = $url->openConnection();
$urlConnection->setConnectTimeout(10000);
$urlConnection->setReadTimeout(60000);

// 将连接传递给 AI 客户端。
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

### **Azure OpenAI 示例**

您可以使用 [OpenAICompatibleWebClient](https://reference.aspose.com/slides/zh/php-java/aspose.slides/openaicompatiblewebclient/) 将翻译器配置为使用您的 Azure OpenAI 部署。

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

此代码片段演示如何使用您的 Azure OpenAI 端点翻译演示文稿。请将占位符值替换为您的部署名称、API 密钥和端点 URL。

## **关键优势**

Aspose.Slides Presentation Translation API 提供了一种 AI 驱动的解决方案，用于交付多语言 PowerPoint 演示文稿。通过在保持布局和设计的同时自动翻译，它节省时间并降低相比手动工作流的错误风险。无论您是开发人员、教育工作者还是商务专业人士，此 API 都能帮助您为全球受众创建引人入胜的本地化演示文稿——扩大影响范围并提升沟通效果。