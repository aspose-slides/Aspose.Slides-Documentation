---
title: Aspose.Slides for Python via Java 中的字体选择顺序
linktitle: 字体选择
type: docs
weight: 80
url: /zh/python-java/font-selection-sequence/
keywords:
- 字体选择
- 字体替换
- 字体更换
- 替换规则
- 可用字体
- 缺失字体
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Python via Java 如何选择字体，确保 PPT、PPTX 和 ODP 文件的清晰一致呈现—立即提升您的幻灯片。"
---
## **概述**

当加载、呈现或转换演示文稿为其他格式时，Aspose.Slides 会检查演示文稿中使用的字体是否在操作系统中可用。如果缺少必需的字体，Aspose.Slides 将选择一个尽可能接近 PowerPoint 所使用的替代字体。

Aspose.Slides 首先在操作系统中搜索选定的字体。如果找到，则使用该字体；如果未找到，则使用合适的替代字体。若通过 [FontSubstRule](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsubstrule/) 定义了字体替换规则，这些规则也会被考虑。

您还可以在应用运行时添加字体，使用演示文稿中的嵌入字体，或为输出文档（如 PDF 文件）加载外部字体。

## **字体选择**

在加载、呈现或转换演示文稿为其他格式时，演示文稿中的字体会应用特定规则。例如，当您尝试将演示文稿（其幻灯片）转换为图像时，会检查演示文稿的字体以确认所选字体在操作系统中可用。如果确认缺少这些字体，它们将被替换——参见 [Font Replacement](/slides/zh/python-java/font-replacement/) 和 [Font Substitution](/slides/zh/python-java/font-substitution/)。

以下是 Aspose.Slides 处理字体的过程：

1. Aspose.Slides 在操作系统中搜索字体，以找到与演示文稿所选字体匹配的字体。
2. 如果找到所选字体，Aspose.Slides 使用它；否则，Aspose.Slides 使用一个尽可能接近 PowerPoint 使用的替代字体。
3. 如果通过 [FontSubstRule](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsubstrule/) 设置了字体替换规则，则会应用这些规则。

Aspose.Slides 允许您在应用运行时添加字体，然后使用这些字体。参见 [Custom fonts](/slides/zh/python-java/custom-font/)。

当在演示文稿中放置额外的字体时，它们称为 [Embedded fonts](/slides/zh/python-java/embedded-font/)。

Aspose.Slides 允许您添加仅用于输出文档的字体。例如，如果您要将演示文稿转换为 PDF，而所使用的字体既未安装在系统中，也未嵌入在演示文稿中，您可以将所需字体添加或加载为 **external fonts**。

{{% alert title="Note" color="info" %}}
我们不分发任何字体，无论是付费还是免费。我们的 API 允许您加载外部字体并将其嵌入文档，但这需由您自行判断并自行承担责任。
{{% /alert %}}

## **FAQ**

**如何在转换之前确定演示文稿实际使用了哪些字体？**

Aspose.Slides 让您通过 [font manager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/) 检查使用的字体，从而决定是否 [embed](/slides/zh/python-java/embedded-font/)、[replace](/slides/zh/python-java/font-replacement/) 或添加 [external sources](/slides/zh/python-java/custom-font/)。这有助于防止在渲染和导出过程中出现不想要的替换。

**我可以在不将字体安装到操作系统的情况下添加额外的字体目录吗？**

可以。您可以注册 [external font sources](/slides/zh/python-java/custom-font/)（如文件夹或内存流）用于渲染和导出。这消除了对宿主系统字体的依赖，使布局更可预测。

**如何防止在缺少字形时静默回退到不合适的字体？**

预先定义明确的 [font replacement](/slides/zh/python-java/font-replacement/) 和字体 [fallback rules](/slides/zh/python-java/fallback-font/)。通过分析使用的字体并为替代字体设置受控的优先级，您可以确保排版一致，避免意外结果。