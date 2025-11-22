---
title: JavaScript 中的字体选择序列
linktitle: 字体选择序列
type: docs
weight: 80
url: /zh/nodejs-java/font-selection-sequence/
keywords:
- 字体
- 字体选择
- 字体替代
- 字体替换
- PowerPoint 演示文稿
- Java
- 适用于 Node.js via Java 的 Aspose.Slides
description: JavaScript 中的 PowerPoint 字体选择序列
---

## **字体选择**

当演示文稿被加载、呈现或转换为其他格式时，字体有特定规则适用。例如，当您尝试将演示文稿（其幻灯片）转换为图像时，会检查演示文稿的字体，以确认所选字体在操作系统中可用。如果确认字体缺失，则会被替换——请参阅 [**字体替换**](https://docs.aspose.com/slides/nodejs-java/font-replacement/) 和 [**字体替代**](https://docs.aspose.com/slides/nodejs-java/font-substitution/)。

以下是 Aspose.Slides 处理字体时遵循的流程：

1. Aspose.Slides 在操作系统中搜索字体，以查找与演示文稿所选字体匹配的字体。  
2. 如果找到所选字体，Aspose.Slides 将使用它。否则，Aspose.Slides 将使用尽可能接近 PowerPoint 所使用的替代字体。  
3. 如果通过 [FontSubstRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrule/) 设置了字体替换规则，则会应用这些规则。

Aspose.Slides 允许您在应用运行时添加字体并使用这些字体。请参阅 [**自定义字体**](https://docs.aspose.com/slides/nodejs-java/custom-font/)。

当在演示文稿中嵌入额外字体时，这些字体称为 [**嵌入式字体**](https://docs.aspose.com/slides/nodejs-java/embedded-font/)。

Aspose.Slides 允许您添加仅用于 *输出文档* 的字体。例如，如果您要转换为 PDF 的演示文稿缺少系统和嵌入式字体，您可以将所需字体添加或加载为 **外部字体**。

{{% alert title="Note" color="primary" %}} 
我们不分发任何字体，无论是付费还是免费。我们的 API 允许您加载外部字体并将其嵌入文档，但这完全由您自行决定并自行承担责任。
{{% /alert %}}

## **常见问题**

**如何在转换前确定演示文稿实际使用了哪些字体？**

Aspose.Slides 允许您通过 [font manager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/) 检查使用的字体，以便决定是 [嵌入](/slides/zh/nodejs-java/embedded-font/)、[替换](/slides/zh/nodejs-java/font-replacement/) 还是添加 [外部来源](/slides/zh/nodejs-java/custom-font/)。这有助于防止在渲染和导出过程中出现不希望的替换。

**我可以在不将字体安装到操作系统的情况下添加额外的字体目录吗？**

是的。您可以注册 [外部字体来源](/slides/zh/nodejs-java/custom-font/)（如文件夹或内存流）用于渲染和导出。这消除了对主机系统字体的依赖，使布局保持可预测。

**当字符缺失时，如何防止默默回退到不合适的字体？**

预先定义明确的 [字体替换](/slides/zh/nodejs-java/font-replacement/) 和字体 [回退规则](/slides/zh/nodejs-java/fallback-font/)。通过分析已使用的字体并为替代字体设置受控的优先级，您可以确保排版一致，避免意外结果。