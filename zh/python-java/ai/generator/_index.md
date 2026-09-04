---
title: AI 驱动的多语言幻灯片生成器
linktitle: AI 驱动的生成器
type: docs
weight: 40
url: /zh/python-java/ai/generator/
keywords:
- 多语言演示文稿
- 多语言幻灯片
- AI 演示文稿生成器
- AI 幻灯片生成器
- 演示文稿模板
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 从文本生成多语言演示文稿。选择内容细节，应用模板，并导出为 PowerPoint 或 PDF。"
---
## **简介**

Aspose.Slides for Python via Java 中的 AI 演示文稿生成器可根据主题描述、摘要、引用或要点创建演示文稿。 在提示中指定所需语言，选择内容量，并可选择提供演示文稿模板以定义布局和设计。

生成器使用文本块、项目符号列表和表格来组织内容。 它不生成图像；您可以在生成的演示文稿后添加。 在共享演示文稿之前，请检查生成的内容和布局。

## **工作原理**

[SlidesAIAgent](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidesaiagent/) 使用 AI 客户端与外部模型通信。以下示例使用内置的 [OpenAIWebClient](https://reference.aspose.com/slides/zh/python-java/aspose.slides/openaiwebclient/)。Aspose.Slides 处理模型的响应并构建可编辑或导出的演示文稿。

使用 [SlidesAIAgent.generatePresentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidesaiagent/#generatePresentation) 并提供文本描述和 [PresentationContentAmountType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationcontentamounttype/) 值。带有第三个参数的重载接受一个演示文稿作为设计模板。

## **先决条件**

请遵循 [Installation](/slides/zh/python-java/installation/) 配置 Python、Java、JPype 和 Aspose.Slides。 在运行示例之前，设置 `OPENAI_API_KEY` 和 `OPENAI_MODEL` 环境变量。 选择内置客户端支持且您 API 账户可用的模型。

{{% alert color="info" title="Note" %}}
AI 服务需要互联网连接和单独的 API 访问权限。提示会发送到配置的服务，其使用费用独立于您的 Aspose.Slides 许可证。
{{% /alert %}}

每个示例仅在 JVM 未运行时启动它，并使其保持可用于后续操作。 在为笔记本调整代码时，请参阅 [JVM lifecycle guidance](/slides/zh/python-java/limitations-and-api-differences/#import-the-library)。

## **从文本生成演示文稿**

此示例生成一个英文演示文稿，内容量为 [Medium](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationcontentamounttype/#Medium)，并将其保存为 PowerPoint 文件。

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    instruction = "Generate an English presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
    presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Medium)
    try:
        presentation.save("generated.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **使用模板生成演示文稿**

将 `masterPresentation.pptx` 放在工作目录中。此示例使用 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 加载它，生成一个西班牙语演示文稿，内容为 [Detailed](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationcontentamounttype/#Detailed)，并导出为 PDF。 即使生成或保存失败，模板和生成的演示文稿也会被释放。

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    template = Presentation("masterPresentation.pptx")
    try:
        instruction = "Generate a Spanish presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
        presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Detailed, template)
        try:
            presentation.save("generated.pdf", SaveFormat.Pdf)
        finally:
            presentation.dispose()
    finally:
        template.dispose()
finally:
    ai_client.close()
```

如果需要配置代理或连接超时，请参阅 [Configure the HTTP Connection](/slides/zh/python-java/ai/translator/#configure-the-http-connection)。 您也可以将生成的客户端传递给生成器。

## **主要优势**

生成可以减少培训材料、产品概览、客户报告和内部演示文稿的初始草稿工作。提示控制主题和语言，而模板则允许您重复使用现有的演示文稿设计。

## **常见问题**

**如何控制生成的演示文稿的长度？**

选择 [Brief](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationcontentamounttype/#Brief)、[Medium](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationcontentamounttype/#Medium) 或 [Detailed](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationcontentamounttype/#Detailed)。这些设置会影响幻灯片的数量和每张幻灯片的详细程度；它们并不指定确切的幻灯片数量。

**我可以用其他语言生成幻灯片吗？**

可以。 在文本描述中包含所需语言。结果取决于所选模型的语言能力。

**导出为 PDF 时我可以保留可编辑版本吗？**

可以。在释放生成的演示文稿之前，使用第一个示例中的方法另存为 PPTX。