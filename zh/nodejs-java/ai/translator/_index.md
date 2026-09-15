---
title: AI 驱动的演示文稿翻译器
linktitle: AI 驱动的翻译器
type: docs
weight: 20
url: /zh/nodejs-java/ai/translator/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 的 AI 将 PowerPoint 幻灯片翻译。对 PPT、PPTX 和 ODP 进行本地化，同时保留布局——快速且对开发者友好。尝试一下。"
---
## **介绍**

Aspose.Slides 是一个强大的 API，用于以编程方式管理 PowerPoint 演示文稿。除了创建、编辑和转换幻灯片之外，它还提供 AI 驱动的功能，例如用于多语言幻灯片内容的 Presentation Translation API。

## **工作原理**

Aspose.Slides 本身不包含内置的 AI 功能，但可以通过互联网与外部 AI 模型集成。此功能通过 [SlidesAIAgent](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slidesaiagent/) 类公开，以便与 AI 服务通信。

您可以使用内置的 [OpenAIWebClient](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/openaiwebclient/) 连接到 OpenAI 的 API。

Aspose.Slides 负责处理通信，解析 AI 响应，并在保持原始幻灯片布局和格式的同时智能地插入翻译后的内容。

{{% alert color="info" title="Note" %}}
请注意，OpenAI API 是付费服务，因此在使用内置的 [OpenAIWebClient](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/openaiwebclient/) 时，您需要创建账户并提供 API 密钥。
{{% /alert %}}

## **示例**

在本示例中，我们使用内置的 [OpenAIWebClient](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/openaiwebclient/) 和指定的 OpenAI [model](https://platform.openai.com/docs/models) 将 PowerPoint 演示文稿翻译成日语。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Load a presentation to translate.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Initialize SlidesAIAgent with the AI client.
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Translate the presentation to Japanese.
    aiAgent.translate(presentation, "japanese");

    // Save the translated presentation as a PDF.
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

默认情况下，内置的 [OpenAIWebClient](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/openaiwebclient/) 会创建并管理其内部的 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 实例，自动处理其生命周期。然而，如果您希望自行管理 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ——主要是为了配置代理等关键设置，或使用 [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) 或不同的 [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) 以获得更好的资源管理和性能——则可以在构造 [OpenAIWebClient](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/openaiwebclient/) 时提供您自己的 `HttpURLConnection` 实例。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 创建并预先配置 HttpURLConnection 实例（例如，使用自定义超时、代理设置等）
let url = java.newInstanceSync("java.net.URL", "https://api.openai.com/v1/chat/completions");
let urlConnection = url.openConnection();
urlConnection.setConnectTimeout(10000);
urlConnection.setReadTimeout(60000);

let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Azure OpenAI 示例**

您可以使用 [OpenAICompatibleWebClient](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/openaicompatiblewebclient/) 将翻译器配置为使用您的 Azure OpenAI 部署。

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

此代码段演示了使用您的 Azure OpenAI 端点翻译演示文稿。请将占位符值替换为您的部署名称、API 密钥和端点 URL。

## **主要优势**

Aspose.Slides Presentation Translation API 提供了一种 AI 驱动的解决方案，用于交付多语言 PowerPoint 演示文稿。通过在保持布局和设计的同时自动翻译，它比手工工作流节省时间并降低错误率。无论您是开发人员、教育者还是商业专业人士，此 API 都能帮助您为全球受众创建引人入胜、本地化的演示文稿——扩展影响范围并提升沟通效果。