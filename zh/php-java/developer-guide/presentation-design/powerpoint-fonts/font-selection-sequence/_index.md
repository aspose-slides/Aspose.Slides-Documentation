---
title: 字体选择顺序
linktitle: 字体选择顺序
type: docs
weight: 80
url: /zh/php-java/font-selection-sequence/
keywords: "字体, 字体选择, 字体替换, 字体更换, PowerPoint 演示文稿, Java, Aspose.Slides for PHP via Java"
description: PowerPoint 字体选择顺序
---

## 字体选择

在加载、渲染或转换演示文稿为其他格式时，演示文稿中的字体适用某些规则。例如，当您尝试将演示文稿（其幻灯片）转换为图像时，会检查演示文稿的字体以验证所选字体是否在操作系统中可用。如果确认字体缺失，它们将被替换——请参见 [**字体更换**](https://docs.aspose.com/slides/php-java/font-replacement/) 和 [**字体替代**](https://docs.aspose.com/slides/php-java/font-substitution/)。

Aspose.Slides 处理字体时遵循以下过程：

1. Aspose.Slides 在操作系统中搜索字体，以找到与演示文稿所选字体匹配的字体。
2. 如果找到所选字体，Aspose.Slides 将使用它。否则，Aspose.Slides 将使用尽可能接近 PowerPoint 所使用的替代字体。
3. 如果通过 [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/) 设置了字体替换规则，则会应用这些规则。

Aspose.Slides 允许您将字体添加到 Aspose 运行时，然后使用这些字体。请参见 [**自定义字体**](https://docs.aspose.com/slides/php-java/custom-font/)。

当在演示文稿中放入额外字体时，它们被称为 [**嵌入字体**](https://docs.aspose.com/slides/php-java/embedded-font/)。

Aspose.Slides 允许您添加仅应用于输出文档的字体。例如，如果您希望转换为 PDF 的演示文稿包含缺失于您的系统中的字体和嵌入字体，您可以将所需的字体添加或加载为 **外部字体**。