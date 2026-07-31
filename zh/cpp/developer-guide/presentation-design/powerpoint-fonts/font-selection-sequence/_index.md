---
title: Aspose.Slides for C++ 中的字体选择顺序
linktitle: 字体选择
type: docs
weight: 80
url: /zh/cpp/font-selection-sequence/
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
- C++
- Aspose.Slides
description: "了解 Aspose.Slides for C++ 如何选择字体，确保 PPT、PPTX 和 ODP 文件的呈现清晰一致——立即提升您的幻灯片。"
---
## **概述**

当加载、渲染或转换为其他格式的演示文稿时，Aspose.Slides 会检查演示文稿中使用的字体在操作系统中是否可用。如果缺少所需的字体，Aspose.Slides 会选择一个尽可能接近 PowerPoint 使用的替代字体。

Aspose.Slides 首先在操作系统中搜索所选字体。如果找到该字体，则使用它；如果未找到，则应用合适的替代字体。当通过 `FontSubstRule` 定义字体替换规则时，这些规则也会被考虑。

您还可以在应用运行时添加字体、使用演示文稿中的嵌入字体，或为 PDF 等输出文档加载外部字体。

## **字体选择**

在加载、渲染或转换为其他格式时，演示文稿中的字体会受到特定规则的约束。例如，当您尝试将演示文稿（其幻灯片）转换为图像时，会检查演示文稿的字体是否在操作系统中可用。如果确认字体缺失，则会进行替换——请参阅[**字体替换**](https://docs.aspose.com/slides/zh/cpp/font-replacement/)和[**字体替代**](https://docs.aspose.com/slides/zh/cpp/font-substitution/)。

这是 Aspose.Slides 处理字体时遵循的过程：

1. Aspose.Slides 在操作系统中搜索字体，以找到与演示文稿所选字体匹配的字体。  
2. 如果找到所选字体，Aspose.Slides 使用它；否则，Aspose.Slides 使用一个尽可能接近 PowerPoint 使用的替代字体。  
3. 如果通过[FontSubstRule](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsubstrule/)设置了字体替换规则，则会应用这些规则。  

Aspose.Slides 允许您在应用运行时添加字体并使用这些字体。请参阅[**自定义字体**](https://docs.aspose.com/slides/zh/cpp/custom-font/)。  

当在演示文稿中放置额外字体时，它们被称为[**嵌入字体**](https://docs.aspose.com/slides/zh/cpp/embedded-font/)。  

Aspose.Slides 允许您添加仅用于输出文档的字体。例如，如果要将演示文稿转换为 PDF，但演示文稿中包含系统和嵌入字体缺失的字体，您可以将所需字体添加或加载为**外部字体**。  

{{% alert title="Note" color="primary" %}} 
我们不分发任何字体，无论是付费的还是免费的。我们的 API 允许您加载外部字体并将其嵌入文档，但这需由您自行决定并自行承担责任。  
{{% /alert %}}

## **常见问题**

**如何在转换前确定演示文稿实际使用了哪些字体？**

Aspose.Slides 通过[字体管理器](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_fontsmanager/)让您检查使用的字体，从而决定是[嵌入](/slides/zh/cpp/embedded-font/)、[替换](/slides/zh/cpp/font-replacement/)还是添加[外部来源](/slides/zh/cpp/custom-font/)。这有助于在渲染和导出时防止不需要的替换。  

**我可以在不将字体安装到操作系统的情况下添加额外的字体目录吗？**

是的。您可以注册[外部字体源](/slides/zh/cpp/custom-font/)，例如文件夹或内存流，用于渲染和导出。这样可以消除对宿主系统字体的依赖，并保持布局可预测。  

**当字形缺失时，如何防止静默回退到不合适的字体？**

预先定义明确的[字体替换](/slides/zh/cpp/font-replacement/)和字体[回退规则](/slides/zh/cpp/fallback-font/)。通过分析使用的字体并为替代字体设置受控的优先级，您可以确保排版一致，避免意外结果。