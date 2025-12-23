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
description: "使用 Aspose.Slides for PHP 的 AI 翻译 PowerPoint 幻灯片。 在保持布局的情况下本地化 PPT、PPTX 和 ODP——快速且对开发者友好。立即尝试。"
---

## **Aspose.Slides 演示文稿翻译 API：AI 驱动的多语言幻灯片翻译**

Aspose.Slides 是一个功能强大的 API，可用于以编程方式管理 PowerPoint 演示文稿。除了创建、编辑和转换幻灯片外，它还提供 AI 驱动的功能——例如用于多语言幻灯片内容的演示文稿翻译 API。

## **工作原理**

Aspose.Slides 本身不包含内置的 AI 功能，但可以通过互联网与外部 AI 模型集成。此功能通过 [SlidesAIAgent](https://reference.aspose.com/slides/php-java/aspose.slides/slidesaiagent/) 类公开，用于与 AI 服务通信。

您可以使用内置的 [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/) 连接到 OpenAI 的 API。

Aspose.Slides 负责通信、解析 AI 响应，并在保持原始幻灯片布局和格式的同时智能地插入翻译后的内容。

{{% alert color="primary" %}}
请注意，OpenAI API 是一项付费服务，使用内置的 [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/) 时，您需要创建账户并提供 API 密钥。
{{% /alert %}}

## **示例**

在此示例中，我们使用内置的 [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/) 并指定 OpenAI [model](https://platform.openai.com/docs/models) 将 PowerPoint 演示文稿翻译成日语。
```php
// 加载要翻译的演示文稿。
$presentation = new Presentation("sample.pptx");

// 创建一个使用 OpenAIWebClient 的 AI 客户端，指定模型和 API 密钥。
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // 使用 AI 客户端初始化 SlidesAIAgent。
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // 将演示文稿翻译成日语。
    $aiAgent->translate($presentation, "japanese");

    // 将翻译后的演示文稿保存为 PDF。
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```


默认情况下，内置的 [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/) 会创建并管理其自己的内部 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 实例，自动处理其生命周期。但如果您希望自行管理 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) —— 主要是为了配置代理等必要设置，或使用 [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) 或不同的 [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) 以获得更好的资源管理和性能 —— 您可以在构造 [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/) 时提供自己的 `HttpURLConnection` 实例。
```php
// 假设您已有预配置的 HttpURLConnection 实例（例如，自定义超时、代理设置等）。
$urlConnection = $yourPreconfiguredConnection;
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```


## **主要优势**

Aspose.Slides 演示文稿翻译 API 提供了一种 AI 驱动的解决方案，用于交付多语言 PowerPoint 演示文稿。通过在保持布局和设计的前提下自动翻译，它节省了时间并将错误降至最低，相比手动工作流更高效。无论您是开发人员、教育工作者还是商业专业人士，此 API 都能帮助您为全球受众创建引人入胜、本地化的演示文稿——拓展影响力并提升沟通效果。