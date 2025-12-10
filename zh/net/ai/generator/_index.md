---
title: AI 驱动的多语言幻灯片生成器
linktitle: AI 驱动的生成器
type: docs
weight: 40
url: /zh/net/ai/generator/
keywords:
- 多语言演示文稿
- 多语言幻灯片
- AI 演示文稿生成器
- AI 幻灯片生成器
- AI 驱动的功能
- AI 代理
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 从文本生成多语言幻灯片。应用您的模板并将精美的演示文稿导出为 PowerPoint 和 OpenDocument。了解更多。"
---

## **Aspose.Slides Presentation AI API：AI 驱动的幻灯片生成器**

Aspose.Slides 引入了全新的 AI 驱动功能——Presentation Generator，开发者可以根据主题描述、摘要、引语或要点等简短文本输入，自动生成结构良好的 PowerPoint 演示文稿。

用户可以调节内容细节层级，并可选地使用自定义演示模板来定义视觉设计。

当前，AI Presentation Generator 使用文本块、项目列表和表格来组织内容。尚未支持图像生成；不过生成的演示文稿可随后使用 Aspose.Slides 工具或手动方式轻松添加图片。

输出为完整的 PowerPoint 演示文稿，可直接使用或导出为 Aspose.Slides API 支持的任何格式。虽然生成器能够提供高质量结果，但在满足特定需求时可能需要进行少量后期编辑。

## **工作原理**

Aspose.Slides 本身不包含内置的 AI 模型，而是通过互联网与外部 AI 服务集成。此集成由[SlidesAIAgent](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/)类处理，该类使用实现了[IAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/)接口的对象与 AI 模型通信。

您可以使用内置的[OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/)，它连接到 OpenAI 的 API，或提供自定义的[IAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/)实现，以配合其他 AI 提供商或语言模型。Aspose.Slides 负责所有与 AI 服务的通信，并处理 AI 的响应以生成幻灯片。请注意，OpenAI API 是付费服务，使用内置的[OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/)时需要拥有账户并提供 API 密钥。

## **动手编码**

### **示例 1**

本示例演示如何使用内置的[OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/)生成关于 Aspose.Slides 主题的演示文稿。

```csharp
// 创建 OpenAIWebClient 实例，这是 OpenAI 网络客户端的内置实现。
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

// 创建 SlidesAIAgent 实例，以访问 AI 驱动的功能。
var aiAgent = new SlidesAIAgent(aiWebClient);

// 定义生成演示文稿的指令。
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// 根据指令生成内容量为中等的演示文稿。
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Medium);

// 将生成的演示文稿保存为本地的 PowerPoint (.pptx) 文件。
presentation.Save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
```

### **示例 2**

下面的示例演示[GeneratePresentation](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/generatepresentation/)方法的重载。此示例使用外部管理的[HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)实例以及用户的`master presentation`。

默认情况下，内置的[OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/)会创建并管理自己的内部[HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)实例，自动处理其生命周期和释放。但如果您希望自行管理[HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)（例如使用[IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory)以提升资源管理和性能），可以在构造[OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/)时传入自己的[HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)实例。

```csharp
// 创建外部管理的 HttpClient 实例。
using var httpClient = new HttpClient();

// 将 HttpClient 传入 OpenAIWebClient 构造函数。
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", httpClient);

// 创建 SlidesAIAgent 实例。
var aiAgent = new SlidesAIAgent(aiWebClient);

// 定义生成演示文稿的指令。
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// 从本地磁盘加载主演示文稿，作为设计模板使用。
using var masterPresentation = new Presentation("masterPresentation.pptx");

// 使用指令和主模板生成详细的演示文稿。
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Detailed, masterPresentation);

// 将生成的演示文稿保存为 PDF。
presentation.Save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
```

值得注意的是，许多客户在同步上下文中使用 Aspose.Slides。为支持此场景，[SlidesAIAgent](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/)类同时提供同步和异步方法，便于您根据应用工作流选择最合适的调用方式。

## **核心优势**

Aspose.Slides 全新的 AI Presentation Generator 可快速灵活地依据简短文本提示生成结构化的幻灯片套件。支持自定义模板、外部管理的[HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)实例，以及同步/异步工作流，使其能够无缝集成到各种应用场景中。

典型使用场景包括制作营销演示、教学材料、客户报告以及内部幻灯片。虽然目前尚未支持图像生成，但该工具已为自动化演示文稿创建提供了坚实的基础，未来还将进一步增强功能。