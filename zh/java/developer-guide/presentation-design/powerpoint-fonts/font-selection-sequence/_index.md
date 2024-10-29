---
title: Java中的字体选择顺序
linktitle: Java中的字体选择顺序
type: docs
weight: 80
url: /zh/java/font-selection-sequence/
keywords:
- 字体
- 字体选择
- 字体替代
- 字体替换
- PowerPoint演示文稿
- Java
- Aspose.Slides for Java
description: Java中的PowerPoint字体选择顺序
---

## 字体选择

在加载、渲染或转换演示文稿时，演示文稿中的字体遵循特定规则。例如，当您尝试将演示文稿（其幻灯片）转换为图像时，会检查演示文稿的字体，以验证所选字体是否在操作系统中可用。如果确认缺少所选字体，则会进行替换 — 请参见 [**字体替换**](https://docs.aspose.com/slides/java/font-replacement/) 和 [**字体替代**](https://docs.aspose.com/slides/java/font-substitution/)。

Aspose.Slides 在处理字体时遵循以下过程：

1. Aspose.Slides 在操作系统中搜索字体，以寻找与演示文稿所选字体匹配的字体。
2. 如果找到所选字体，则 Aspose.Slides 使用它。否则，Aspose.Slides 使用尽可能接近 PowerPoint 所用的替代字体。
3. 如果通过 [FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/) 设置了字体替换规则，则会应用这些规则。

Aspose.Slides 允许您在应用程序运行时添加字体，然后使用这些字体。请参见 [**自定义字体**](https://docs.aspose.com/slides/java/custom-font/)。

在演示文稿中放置的其他字体称为 [**嵌入字体**](https://docs.aspose.com/slides/java/embedded-font/)。

Aspose.Slides 允许您添加仅应用于输出文档的字体。例如，如果您要转换为 PDF 的演示文稿包含系统中缺少的字体和嵌入字体，您可以将所需字体作为 **外部字体** 添加或加载。

{{% alert title="注意" color="primary" %}} 
我们不分发任何字体，无论是付费还是免费。我们的 API 允许您加载外部字体并将其嵌入文档，但您需要自行选择和负责使用的字体。
{{% /alert %}}