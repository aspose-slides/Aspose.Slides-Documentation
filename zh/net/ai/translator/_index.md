---
title: AI 驱动的演示文稿翻译器
linktitle: AI 驱动的翻译器
type: docs
weight: 20
url: /zh/net/ai/translator/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 的 AI 将 PowerPoint 幻灯片翻译为多语言。对 PPT、PPTX 和 ODP 进行本地化，同时保留布局——快速且开发者友好。立即试用。"
---
## **介绍**

Aspose.Slides 是一个强大的 API，用于以编程方式管理 PowerPoint 演示文稿。除了创建、编辑和转换幻灯片外，它还提供 AI 驱动的功能，例如用于多语言幻灯片内容的 [Presentation Translation API](https://reference.aspose.com/slides/zh/net/aspose.slides.ai/)。

## **工作原理**

Aspose.Slides 不包含内置的 AI 功能，但通过互联网与外部 AI 模型集成。此功能通过 [SlidesAIAgent](https://reference.aspose.com/slides/zh/net/aspose.slides.ai/slidesaiagent) 类公开，该类使用实现了 [IAIWebClient](https://reference.aspose.com/slides/zh/net/aspose.slides.ai/iaiwebclient/) 接口的实现来与 AI 服务通信。

您可以使用内置的 [OpenAIWebClient](https://reference.aspose.com/slides/zh/net/aspose.slides.ai/openaiwebclient/) 连接到 OpenAI 的 API，或实现您自己的 [IAIWebClient](https://reference.aspose.com/slides/zh/net/aspose.slides.ai/iaiwebclient/) 以使用其他 AI 提供商或语言模型。

Aspose.Slides 负责通信，解析 AI 响应，并在保留原始幻灯片布局和格式的同时智能地插入翻译后的内容。

{{% alert color="info" title="Note" %}}
请注意，OpenAI API 是付费服务，因此在使用内置的 [OpenAIWebClient](https://reference.aspose.com/slides/zh/net/aspose.slides.ai/openaiwebclient/) 时，您需要创建账户并提供您的 API 密钥。
{{% /alert %}}

## **示例**

在此示例中，我们使用内置的 [OpenAIWebClient](https://reference.aspose.com/slides/zh/net/aspose.slides.ai/openaiwebclient/) 并指定 OpenAI 的 [model](https://platform.openai.com/docs/models) 将 PowerPoint 演示文稿翻译成日语。

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// 加载要翻译的演示文稿。
using var presentation = new Presentation("sample.pptx");

// 使用 OpenAIWebClient 创建 AI 客户端，指定模型和 API 密钥。
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// 使用 AI 客户端初始化 SlidesAIAgent。
var aiAgent = new SlidesAIAgent(aiWebClient);

// 将演示文稿翻译为日语。
await aiAgent.TranslateAsync(presentation, "japanese");

// 将翻译后的演示文稿保存为 PDF。
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

默认情况下，内置的 [OpenAIWebClient](https://reference.aspose.com/slides/zh/net/aspose.slides.ai/openaiwebclient/) 会创建并管理其自己的内部 [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) 实例，自动处理其生命周期和释放。不过，如果您更倾向于自行管理 [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)（例如在使用 [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) 以获得更好的资源管理和性能时），可以在构造 [OpenAIWebClient](https://reference.aspose.com/slides/zh/net/aspose.slides.ai/openaiwebclient/) 时提供您自己的 `HttpClient` 实例。

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// 使用您自行管理的 HttpClient —— 例如由 IHttpClientFactory 创建的实例
// 通过依赖注入注入。
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides 通常在同步环境中使用。为支持此场景，[SlidesAIAgent](https://reference.aspose.com/slides/zh/net/aspose.slides.ai/slidesaiagent/) 类提供同步和异步方法，允许您选择最适合应用工作流的方式。

### **Azure OpenAI 示例**

Aspose.Slides for .NET 支持兼容 OpenAI 的提供商，包括 Azure OpenAI。您可以使用 [OpenAICompatibleWebClient](https://reference.aspose.com/slides/zh/net/aspose.slides.ai/openaicompatiblewebclient/) 将翻译器配置为使用您内部的 Azure 部署。

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

var model = "your-azure-deployment-name";
var apiKey = "your-azure-api-key";
var baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

using var aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
var aiAgent = new SlidesAIAgent(aiWebClient);
using var presentation = new Presentation("Presentation.pptx");
aiAgent.Translate(presentation, "spanish");
presentation.Save("Translated.pptx", SaveFormat.Pptx);
```

此代码片段演示了使用您的 Azure OpenAI 端点翻译演示文稿。请将占位符值替换为您的部署名称、API 密钥和端点 URL。

## **关键收益**

Aspose.Slides 的 [Presentation Translation API](https://reference.aspose.com/slides/zh/net/aspose.slides.ai/) 提供了 AI 驱动的解决方案，用于交付多语言 PowerPoint 演示文稿。通过在保留布局和设计的同时自动翻译，它节省时间并减少与手动工作流相比的错误。无论您是开发者、教育工作者还是商务专业人士，此 API 都能帮助您为全球受众创建引人入胜的本地化演示文稿——扩展影响范围并提升沟通效果。