---
title: AI 驱动的演示文稿翻译器
linktitle: AI 驱动的翻译器
type: docs
weight: 20
url: /zh/python-net/ai/translator/
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
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 的 AI 翻译 PowerPoint 幻灯片。 本地化 PPT、PPTX 和 ODP，保持布局——快速且对开发者友好。试试看。"
---
## **介绍**

Aspose.Slides 是一个功能强大的 API，用于以编程方式管理 PowerPoint 演示文稿。除了创建、编辑和转换幻灯片之外，它还提供 AI 驱动的功能，例如用于多语言幻灯片内容的 [Presentation Translation API](https://reference.aspose.com/slides/zh/python-net/aspose.slides.ai/)。

## **工作原理**

Aspose.Slides 本身不包含内置的 AI 能力，但可以通过互联网与外部 AI 模型集成。此功能通过 [SlidesAIAgent](https://reference.aspose.com/slides/zh/python-net/aspose.slides.ai/slidesaiagent/) 类公开，该类使用 [IAIWebClient](https://reference.aspose.com/slides/zh/python-net/aspose.slides.ai/iaiwebclient/) 子类与 AI 服务通信。

您可以使用内置的 [OpenAIWebClient](https://reference.aspose.com/slides/zh/python-net/aspose.slides.ai/openaiwebclient/) 连接到 OpenAI 的 API，或实现自己的 [IAIWebClient](https://reference.aspose.com/slides/zh/python-net/aspose.slides.ai/iaiwebclient/) 以使用其他 AI 提供商或语言模型。

Aspose.Slides 负责通信、解析 AI 响应，并在保留原始幻灯片布局和格式的同时智能地插入翻译内容。

{{% alert color="info" %}}
请注意，OpenAI API 是付费服务，因此在使用内置的 [OpenAIWebClient](https://reference.aspose.com/slides/zh/python-net/aspose.slides.ai/openaiwebclient/) 时，您需要创建账户并提供 API 密钥。
{{% /alert %}}

## **示例**

在此示例中，我们使用内置的 [OpenAIWebClient](https://reference.aspose.com/slides/zh/python-net/aspose.slides.ai/openaiwebclient/) 并指定 OpenAI [模型](https://platform.openai.com/docs/models)，将 PowerPoint 演示文稿翻译为日语。

```py
import aspose.slides as slides

# 加载要翻译的演示文稿。
with slides.Presentation("sample.pptx") as presentation:

    # 使用 OpenAIWebClient 创建 AI 客户端，指定模型和 API 密钥。
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # 使用 AI 客户端初始化 SlidesAIAgent。
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # 将演示文稿翻译为日语。
        ai_agent.translate(presentation, "japanese")

        # 将翻译后的演示文稿保存为 PDF。
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

### **Azure OpenAI 示例**

自版本 **26.7.0** 起，Aspose.Slides for Python via .NET 支持与 OpenAI 兼容的提供商，包括 Azure OpenAI。您可以使用 [OpenAICompatibleWebClient](https://reference.aspose.com/slides/zh/python-net/aspose.slides.ai/openaicompatiblewebclient/) 将翻译器配置为使用您内部的 Azure 部署。

```py
import aspose.slides as slides

model = "your-azure-deployment-name"
api_key = "your-azure-api-key"
base_url = "https://your-resource.openai.azure.com/openai/v1/"

with slides.ai.OpenAICompatibleWebClient(model, api_key, base_url) as ai_web_client:
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)
    with slides.Presentation("Presentation.pptx") as presentation:
        ai_agent.translate(presentation, "spanish")
        presentation.save("Translated.pptx", slides.export.SaveFormat.PPTX)
```

此代码片段演示了使用您的 Azure OpenAI 端点翻译演示文稿。请将占位符值替换为您的部署名称、API 密钥和端点 URL。

## **主要优势**

Aspose.Slides 的 [Presentation Translation API](https://reference.aspose.com/slides/zh/python-net/aspose.slides.ai/) 提供了一个 AI 驱动的解决方案，用于交付多语言 PowerPoint 演示文稿。通过在保留布局和设计的同时实现自动翻译，它可以节省时间并将错误降至最低，相较于手动工作流更为高效。无论您是开发者、教育者还是商务专业人士，该 API 都能帮助您创建有吸引力的本地化演示文稿，以面向全球受众，扩大影响力并提升沟通效果。