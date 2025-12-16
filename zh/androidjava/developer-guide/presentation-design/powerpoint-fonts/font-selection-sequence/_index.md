---
title: Aspose.Slides for Android via Java 中的字体选择顺序
linktitle: 字体选择
type: docs
weight: 80
url: /zh/androidjava/font-selection-sequence/
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
- Android
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Android via Java 如何选择字体，确保 PPT、PPTX 和 ODP 文件的呈现清晰一致——立即提升您的幻灯片。"
---

## **字体选择**

在演示文稿加载、渲染或转换为其他格式时，会有特定的字体规则。例如，当您尝试将演示文稿（其幻灯片）转换为图像时，会检查演示文稿的字体，以验证所选字体是否在操作系统中可用。如果确认字体缺失，则会进行替换——请参阅[**字体替换**](https://docs.aspose.com/slides/androidjava/font-replacement/)和[**字体替代**](https://docs.aspose.com/slides/androidjava/font-substitution/)。

以下是 Aspose.Slides 处理字体的过程：

1. Aspose.Slides 在操作系统中搜索与演示文稿所选字体匹配的字体。  
2. 如果找到了所选字体，Aspose.Slides 会使用它。否则，Aspose.Slides 会使用尽可能接近 PowerPoint 所使用的替代字体。  
3. 如果通过[FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/)设置了字体替换规则，则会应用这些规则。

Aspose.Slides 允许您将字体添加到应用程序运行时，然后使用这些字体。请参阅[**自定义字体**](https://docs.aspose.com/slides/androidjava/custom-font/)。

当在演示文稿中放置额外的字体时，这些字体称为[**嵌入字体**](https://docs.aspose.com/slides/androidjava/embedded-font/)。

Aspose.Slides 允许您添加仅用于输出文档的字体。例如，如果您要将演示文稿转换为 PDF，而其中的字体在您的系统和嵌入字体中缺失，您可以将所需的字体添加或加载为**外部字体**。

{{% alert title="注意" color="primary" %}} 
我们不分发任何字体，无论是付费的还是免费的。我们的 API 允许您加载外部字体并将其嵌入文档，但您需自行决定并自行承担使用这些字体的责任。
{{% /alert %}}

## **常见问题**

**如何在转换之前确定演示文稿实际使用了哪些字体？**

Aspose.Slides 通过[字体管理器](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/)让您检查使用的字体，从而决定是[嵌入](/slides/zh/androidjava/embedded-font/)、[替换](/slides/zh/androidjava/font-replacement/)还是添加[外部来源](/slides/zh/androidjava/custom-font/)。这有助于防止渲染和导出期间出现不想要的替换。

**我可以在不将字体安装到操作系统的情况下添加额外的字体目录吗？**

可以。您可以注册[外部字体来源](/slides/zh/androidjava/custom-font/)（例如文件夹或内存流），用于渲染和导出。这样即可摆脱对主机系统字体的依赖并保持布局可预测。

**如何防止在缺少字形时静默回退到不合适的字体？**

预先定义明确的[字体替换](/slides/zh/androidjava/font-replacement/)和字体[回退规则](/slides/zh/androidjava/fallback-font/)。通过分析已使用的字体并为替代品设置受控优先级，您可以确保排版一致，避免意外结果。