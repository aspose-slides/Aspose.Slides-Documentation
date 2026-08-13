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
## **概述**

当加载、渲染或转换为其他格式的演示文稿时，Aspose.Slides 会检查演示文稿中使用的字体是否在操作系统中可用。如果缺少必需的字体，Aspose.Slides 会选择一个尽可能接近 PowerPoint 所使用的替代字体。

Aspose.Slides 首先在操作系统中搜索所选字体。如果找到该字体，则使用它；如果未找到，则使用合适的替代字体。当通过 `FontSubstRule` 定义字体替代规则时，这些规则也会被考虑在内。

您还可以在应用程序运行时添加字体，使用演示文稿中的嵌入字体，或为输出文档（如 PDF 文件）加载外部字体。

## **字体选择**

在加载、渲染或转换为其他格式的演示文稿时，字体会受到特定规则的约束。例如，当您尝试将演示文稿（其幻灯片）转换为图像时，会检查演示文稿的字体以确认所选字体在操作系统中可用。如果确认缺少这些字体，它们将被替换——参见[**Font Replacement**](https://docs.aspose.com/slides/zh/net/font-replacement/)和[**Font Substitution**](https://docs.aspose.com/slides/zh/net/font-substitution/)。

以下是 Aspose.Slides 处理字体时遵循的流程：

1. Aspose.Slides 在操作系统中搜索字体，以找到与演示文稿所选字体匹配的字体。 
2. 如果找到所选字体，Aspose.Slides 将使用它；否则，Aspose.Slides 将使用一个尽可能接近 PowerPoint 所使用的替代字体。 
3. 如果通过[FontSubstRule](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsubstrule/) 设置了字体替代规则，则会应用这些规则。 

Aspose.Slides 允许您在应用程序运行时添加字体，然后使用这些字体。请参阅[**Custom fonts**](https://docs.aspose.com/slides/zh/net/custom-font/)。 

当在演示文稿中放置额外的字体时，这些字体称为[**Embedded fonts**](https://docs.aspose.com/slides/zh/net/embedded-font/)。 

Aspose.Slides 允许您添加仅用于输出文档的字体。例如，如果您要转换为 PDF 的演示文稿中包含系统和嵌入字体中缺失的字体，您可以将所需字体添加或加载为**external fonts**。 

{{% alert title="Note" color="info" %}} 
我们不分发任何字体，无论是付费的还是免费的。我们的 API 允许您加载外部字体并将其嵌入文档，但这需要您自行决定并自行承担责任。 
{{% /alert %}}

## **常见问题**

### 如何在转换前确定演示文稿实际使用了哪些字体？

Aspose.Slides 让您通过[字体管理器](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/fontsmanager/)检查使用的字体，从而决定是否[嵌入](/slides/zh/net/embedded-font/)、[替换](/slides/zh/net/font-replacement/)或添加[外部来源](/slides/zh/net/custom-font/)。这有助于防止在渲染和导出过程中出现不希望的替代。

### 我可以在不将字体安装到操作系统的情况下添加额外的字体目录吗？

是的。您可以注册[外部字体来源](/slides/zh/net/custom-font/)（如文件夹或内存流）用于渲染和导出。这消除了对宿主系统字体的依赖，使布局保持可预测。

### 当缺少字形时，如何防止静默回退到不合适的字体？

提前明确定义[字体替换](/slides/zh/net/font-replacement/)和字体[回退规则](/slides/zh/net/fallback-font/)。通过分析使用的字体并为替代品设置受控的优先级，您可以确保版式一致，避免出现意外结果。