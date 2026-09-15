---
title: AI 驱动的演示文稿翻译器
linktitle: AI 驱动的翻译器
type: docs
weight: 20
url: /zh/androidjava/ai/translator/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android（Java 版）通过 AI 翻译 PowerPoint 幻灯片。 在保持布局的同时本地化 PPT、PPTX 和 ODP——快速且对开发者友好。 试试看。"
---
## **介绍**

Aspose.Slides 是一个功能强大的 API，用于以编程方式管理 PowerPoint 演示文稿。除了创建、编辑和转换幻灯片外，它还提供 AI 驱动的功能——例如用于多语言幻灯片内容的 Presentation Translation API。

## **工作原理**

Aspose.Slides 本身不包含内置的 AI 功能，而是通过互联网与外部 AI 模型集成。此功能通过 [SlidesAIAgent](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slidesaiagent/) 类公开，该类使用实现了 [IAIWebClient](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iaiwebclient/) 接口的实现来与 AI 服务通信。

您可以使用内置的 [OpenAIWebClient](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/openaiwebclient/) 连接到 OpenAI 的 API，或实现自己的 [IAIWebClient](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iaiwebclient/) 以使用其他 AI 提供商或语言模型。

Aspose.Slides 负责通信、解析 AI 响应，并在保留原始幻灯片布局和格式的同时智能插入翻译后的内容。

{{% alert color="info" title="注意" %}}
注意，OpenAI API 是付费服务，使用内置的 [OpenAIWebClient](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/openaiwebclient/) 时，需要创建账号并提供您的 API 密钥。
{{% /alert %}}

## **示例**

在此示例中，我们使用内置的 [OpenAIWebClient](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/openaiwebclient/) 并指定的 OpenAI [model](https://platform.openai.com/docs/models) 将 PowerPoint 演示文稿翻译成日语。

```java
import com.aspose.slides.*;

// 加载要翻译的演示文稿。
Presentation presentation = new Presentation("sample.pptx");

// 使用 OpenAIWebClient 创建 AI 客户端，指定模型和 API 密钥。
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // 使用 AI 客户端初始化 SlidesAIAgent。
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // 将演示文稿翻译成日语。
    aiAgent.translate(presentation, "japanese");

    // 将翻译后的演示文稿保存为 PDF。
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

默认情况下，内置的 [OpenAIWebClient](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/openaiwebclient/) 会创建并管理自己的内部 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 实例，自动处理其生命周期。然而，如果您希望自行管理 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)——主要是为了配置代理等关键设置，或使用 [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) 或不同的 [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) 以获得更好的资源管理和性能——则可以在构造 [OpenAIWebClient](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/openaiwebclient/) 时提供您自己的 `HttpURLConnection` 实例。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // 自行配置 HttpURLConnection 实例（例如，自定义超时、代理设置等）。
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // 将连接传递给 OpenAIWebClient 构造函数。
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

### **Azure OpenAI 示例**

您可以使用 [OpenAICompatibleWebClient](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/openaicompatiblewebclient/) 将翻译器配置为使用您的 Azure OpenAI 部署。

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

此代码片段演示了使用您的 Azure OpenAI 端点翻译演示文稿。请将占位符值替换为您的部署名称、API 密钥和端点 URL。

## **主要优势**

Aspose.Slides Presentation Translation API 提供了一种 AI 驱动的解决方案，用于交付多语言 PowerPoint 演示文稿。通过在保留布局和设计的同时自动化翻译，它节省时间并将手动工作流程中的错误降至最低。无论您是开发者、教育工作者还是商务专业人士，此 API 都能帮助您创建面向全球受众的引人入胜、本地化的演示文稿——扩大影响范围，提升沟通效果。