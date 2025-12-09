---
title: Aspose.Slides for Python 中的字体选择顺序
linktitle: 字体选择
type: docs
weight: 80
url: /zh/python-net/font-selection-sequence/
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
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python（通过 .NET）如何选择字体，确保 PPT、PPTX 和 ODP 文件的清晰一致展示——立即提升您的幻灯片。"
---

## **字体选择**

在加载、渲染或转换演示文稿为其他格式时，演示文稿中的字体会受到特定规则的约束。例如，当您尝试将演示文稿（其幻灯片）转换为图像时，系统会检查演示文稿的字体，以验证所选字体是否在操作系统中可用。如果确认字体缺失，则会进行替换——请参阅[**字体替换**](https://docs.aspose.com/slides/python-net/font-replacement/)和[**字体替代**](https://docs.aspose.com/slides/python-net/font-substitution/)。

以下是 Aspose.Slides 处理字体的过程：

1. Aspose.Slides 在操作系统中搜索字体，以找到与演示文稿所选字体匹配的字体。  
2. 如果找到所选字体，Aspose.Slides 将使用它。否则，Aspose.Slides 将使用尽可能接近 PowerPoint 使用的替代字体。  
3. 如果通过[FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/)设置了字体替换规则，则会应用这些规则。  

Aspose.Slides 允许您向应用程序运行时添加字体并使用这些字体。参见[**自定义字体**](https://docs.aspose.com/slides/python-net/custom-font/)。  

当在演示文稿中放置额外字体时，它们称为[**嵌入字体**](https://docs.aspose.com/slides/python-net/embedded-font/)。  

Aspose.Slides 允许您添加仅用于输出文档的字体。例如，如果您要将演示文稿转换为 PDF，而该演示文稿包含系统中缺失且未嵌入的字体，您可以将所需字体添加或加载为**外部字体**。  

{{% alert title="Note" color="primary" %}} 
我们不分发任何字体，无论是付费的还是免费的。我们的 API 允许您加载外部字体并将其嵌入文档，但这完全由您自行决定并自行承担责任。 
{{% /alert %}}

## **常见问答**

**如何在转换之前确定演示文稿实际使用了哪些字体？**

Aspose.Slides 让您通过[字体管理器](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/)检查使用的字体，从而决定是否[嵌入](/slides/zh/python-net/embedded-font/)、[替换](/slides/zh/python-net/font-replacement/)或添加[外部来源](/slides/zh/python-net/custom-font/)。这有助于在渲染和导出期间防止不必要的替换。

**我可以在不将字体安装到操作系统的情况下添加额外的字体目录吗？**

可以。您可以注册[外部字体来源](/slides/zh/python-net/custom-font/)，例如文件夹或内存流，以用于渲染和导出。这消除了对主机系统字体的依赖，并保持布局的可预测性。

**如何防止在缺少字形时静默回退到不合适的字体？**

提前定义明确的[字体替换](/slides/zh/python-net/font-replacement/)和字体[回退规则](/slides/zh/python-net/fallback-font/)。通过分析使用的字体并为替代品设置受控的优先级，您可以确保排版的一致性，避免意外结果。