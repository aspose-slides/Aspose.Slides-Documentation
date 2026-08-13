---
title: Aspose.Slides for Java 中的字体选择顺序
linktitle: 字体选择
type: docs
weight: 80
url: /zh/java/font-selection-sequence/
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
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Java 如何选择字体，确保 PPT、PPTX 和 ODP 文件的呈现清晰一致——立即提升您的幻灯片。"
---
## **概述**

当加载、渲染或转换演示文稿为其他格式时，Aspose.Slides 会检查演示文稿中使用的字体是否在操作系统中可用。如果缺少所需字体，Aspose.Slides 会选择一个尽可能接近 PowerPoint 所使用的替代字体。

Aspose.Slides 首先在操作系统中搜索所选字体。如果找到，则使用该字体；如果未找到，则应用适当的替代字体。当通过 `FontSubstRule` 定义字体替代规则时，也会考虑这些规则。

您还可以在应用运行时添加字体，使用演示文稿中的嵌入字体，或为输出文档（如 PDF 文件）加载外部字体。

## **字体选择**

在加载、渲染或转换演示文稿为其他格式时，演示文稿中的字体会遵循特定规则。例如，当您尝试将演示文稿（其幻灯片）转换为图像时，系统会检查演示文稿的字体，以确认所选字体在操作系统中可用。如果确认缺少这些字体，则会进行替换——参见 [**字体替换**](https://docs.aspose.com/slides/zh/java/font-replacement/) 和 [**字体替代**](https://docs.aspose.com/slides/zh/java/font-substitution/)。

Aspose.Slides 处理字体的流程如下：

1. Aspose.Slides 在操作系统中搜索字体，以找到与演示文稿所选字体匹配的字体。  
2. 如果找到所选字体，Aspose.Slides 使用它；否则，Aspose.Slides 使用尽可能接近 PowerPoint 所使用的替代字体。  
3. 如果通过 [FontSubstRule](https://reference.aspose.com/slides/zh/java/com.aspose.slides/fontsubstrule/) 设置了字体替代规则，则会应用这些规则。  

Aspose.Slides 允许您在应用运行时添加字体，然后使用这些字体。参见 [**自定义字体**](https://docs.aspose.com/slides/zh/java/custom-font/)。

当在演示文稿中放置额外字体时，这些字体称为 [**嵌入字体**](https://docs.aspose.com/slides/zh/java/embedded-font/)。

Aspose.Slides 允许您添加仅适用于输出文档的字体。例如，如果要将包含系统中缺失且未嵌入的字体的演示文稿转换为 PDF，您可以将所需字体添加为 **外部字体**。

{{% alert title="注意" color="info" %}} 
我们不分发任何字体，无论是付费的还是免费的。我们的 API 允许您加载外部字体并将其嵌入文档，但您需自行决定并负责使用的字体。
{{% /alert %}}

## **常见问题**

### 如何在转换前确定演示文稿实际使用了哪些字体？

Aspose.Slides 通过 [font manager](https://reference.aspose.com/slides/zh/java/com.aspose.slides/fontsmanager/) 让您检查使用的字体，从而决定是 [嵌入](/slides/zh/java/embedded-font/)、[替换](/slides/zh/java/font-replacement/) 还是添加 [外部来源](/slides/zh/java/custom-font/)。这有助于防止在渲染和导出期间出现不希望的替换。

### 我可以在不将字体安装到操作系统的情况下添加额外的字体目录吗？

可以。您可以注册 [外部字体来源](/slides/zh/java/custom-font/)（如文件夹或内存流）用于渲染和导出。这样可消除对宿主系统字体的依赖，并保持布局的可预测性。

### 如何防止在缺少字形时静默回退到不合适的字体？

提前定义明确的 [字体替换](/slides/zh/java/font-replacement/) 和字体 [回退规则](/slides/zh/java/fallback-font/)。通过分析使用的字体并为替代字体设置受控优先级，您可以确保排版一致，避免意外结果。