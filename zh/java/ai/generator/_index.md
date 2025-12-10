---
title: AI 驱动的多语言幻灯片生成器
linktitle: AI 驱动的生成器
type: docs
weight: 40
url: /zh/java/ai/generator/
keywords:
- 多语言演示文稿
- 多语言幻灯片
- AI 演示生成器
- AI 幻灯片生成器
- AI 驱动的功能
- AI 代理
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 从文本生成多语言幻灯片。应用您的模板并导出精美的演示文稿至 PowerPoint 和 OpenDocument。了解更多。"
---

## **Aspose.Slides 演示 AI API：AI 驱动的幻灯片生成器**

Aspose.Slides 引入了一项新的 AI 驱动功能——Presentation Generator，它使开发人员能够根据主题描述、摘要、引用或要点等简单文本输入自动创建结构良好的 PowerPoint 演示文稿。  
用户可以调整内容细节层级，并可选择应用自定义演示模板以定义视觉设计。  
目前，AI 演示生成器使用文本块、项目符号列表和表格来构建内容。尚不支持图像生成；但可以随后使用 Aspose.Slides 工具或手动轻松添加图像。  
输出是完整的 PowerPoint 演示文稿，可直接使用或导出为 Aspose.Slides API 支持的任意格式。虽然生成器能产生高质量的结果，但可能需要进行少量后期编辑以满足特定需求。

## **工作原理**

Aspose.Slides 不包含内置的 AI 模型；相反，它通过互联网集成外部 AI 服务。此集成由 [SlidesAIAgent](https://reference.aspose.com/slides/java/com.aspose.slides/slidesaiagent/) 类处理，该类使用 [IAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/iaiwebclient/) 接口的实现来与 AI 模型通信。  
您可以使用内置的 [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/)，它连接到 OpenAI 的 API，或提供自定义的 [IAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/iaiwebclient/) 实现，以配合其他 AI 提供商或语言模型。Aspose.Slides 管理与 AI 服务的所有通信并处理 AI 的响应以生成幻灯片。请注意，OpenAI API 是付费服务，使用内置的 [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) 时需要账户和 API 密钥。

## **让我们编码**

### **示例 1**

本示例演示如何使用内置的 [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) 生成关于 Aspose.Slides 主题的演示文稿。  
```java
// 创建 OpenAIWebClient 实例，这是 OpenAI 网络客户端的内置实现。
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // 创建 SlidesAIAgent 实例，它提供对 AI 驱动功能的访问。
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // 定义用于生成演示文稿的指令。
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // 根据指令生成内容量为中等的演示文稿。
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Medium);
    try {
    // 将生成的演示文稿保存为本地磁盘上的 PowerPoint (.pptx) 文件。
    presentation.save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```


### **示例 2**

以下示例演示了 [generatePresentation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesaiagent/#generatePresentation-java.lang.String-int-) 方法的重载。在此案例中，使用了外部管理的 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 实例以及用户的 `master presentation`。  
默认情况下，内置的 [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) 会创建并管理其自己的内部 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 实例，自动处理其生命周期。然而，如果您希望自行管理 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ——例如在使用 [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) 或 [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) 以提升资源管理和性能时——可以在构造 [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) 时提供您自己的 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 实例。  
```java
// 将 HttpURLConnection 传递给 OpenAIWebClient 构造函数。
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // 创建 SlidesAIAgent 实例。
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // 定义用于生成演示文稿的指令。
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // 从本地磁盘加载主演示文稿以用作设计模板。
    Presentation masterPresentation = new Presentation("masterPresentation.pptx");

    // 使用指令和主模板生成详细演示文稿。
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // 将生成的演示文稿保存为 PDF。
        presentation.save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```


## **主要优势**

Aspose.Slides 中的新 AI 演示生成器提供了一种快速灵活的方式，可从简单文本提示生成结构化的幻灯片文稿。支持自定义模板和外部管理的 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 实例，可轻松集成到各种应用中。  
典型的使用场景包括创建营销演示、教育资料、客户报告以及内部幻灯片。尽管尚未支持图像生成，但该工具已提供了自动化演示创建的坚实基础，未来预计会有更多增强功能。