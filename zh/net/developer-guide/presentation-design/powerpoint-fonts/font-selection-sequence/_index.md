---
title: Aspose.Slides for .NET 中的字体选择序列
linktitle: 字体选择
type: docs
weight: 80
url: /zh/net/font-selection-sequence/
keywords:
- 字体选择
- 字体替代
- 字体替换
- 替代规则
- 可用字体
- 缺失字体
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解 Aspose.Slides for .NET 如何选择字体，确保 PPT、PPTX 和 ODP 文件的清晰一致呈现——立即提升您的幻灯片。"
---

## **字体选择**

在演示文稿加载、渲染或转换为其他格式时，某些规则适用于其中的字体。例如，当您尝试将演示文稿（其幻灯片）转换为图像时，系统会检查演示文稿的字体以验证所选字体是否在操作系统中可用。如果确认字体缺失，它们将被替换——请参阅[**Font Replacement**](https://docs.aspose.com/slides/net/font-replacement/)和[**Font Substitution**](https://docs.aspose.com/slides/net/font-substitution/)。

这是 Aspose.Slides 处理字体时遵循的流程：

1. Aspose.Slides 在操作系统中搜索字体，以找到与演示文稿所选字体匹配的字体。 
2. 如果找到所选字体，Aspose.Slides 将使用它。否则，Aspose.Slides 将使用一种尽可能接近 PowerPoint 所使用的替代字体。 
3. 如果通过[FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/)设置了字体替换规则，则会应用这些规则。 

Aspose.Slides 允许您在应用程序运行时添加字体并使用这些字体。请参阅[**Custom fonts**](https://docs.aspose.com/slides/net/custom-font/)。 

当在演示文稿中放置额外的字体时，它们称为[**Embedded fonts**](https://docs.aspose.com/slides/net/embedded-font/)。 

Aspose.Slides 允许您添加仅适用于*输出文档*的字体。例如，如果您要转换为 PDF 的演示文稿包含系统和嵌入字体中缺失的字体，您可以将所需字体添加或加载为**external fonts**。 

{{% alert title="Note" color="primary" %}} 
我们不分发任何字体，无论是付费的还是免费的。我们的 API 允许您加载 external fonts 并将其嵌入文档，但这需由您自行决定并自行承担责任。 
{{% /alert %}}

## **常见问题**

**如何在转换前确定演示文稿实际使用了哪些字体？**

Aspose.Slides 让您通过[font manager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/)检查使用的字体，从而决定是[embed](/slides/zh/net/embedded-font/)、[replace](/slides/zh/net/font-replacement/)还是添加[external sources](/slides/zh/net/custom-font/)。这有助于防止在渲染和导出过程中出现不希望的替换。 

**我可以在不将字体安装到操作系统的情况下添加额外的字体目录吗？**

可以。您可以注册[external font sources](/slides/zh/net/custom-font/)（例如文件夹或内存流）用于渲染和导出。这消除了对主机系统字体的依赖，使布局保持可预测。 

**当字形缺失时，如何防止静默回退到不合适的字体？**

提前定义明确的[font replacement](/slides/zh/net/font-replacement/)和字体[fallBack rules](/slides/zh/net/fallback-font/)。通过分析使用的字体并为替代字体设定受控的优先级，您可以确保排版一致，避免意外结果。