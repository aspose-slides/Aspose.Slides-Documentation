---
title: Java中的字体选择序列
linktitle: Java中的字体选择序列
type: docs
weight: 80
url: /androidjava/font-selection-sequence/
keywords:
- 字体
- 字体选择
- 字体替换
- 字体替代
- PowerPoint演示文稿
- Java
- Aspose.Slides for Android via Java
description: Java中的PowerPoint字体选择序列
---

## 字体选择

在加载、呈现或转换演示文稿为其他格式时，应用于演示文稿的字体存在特定规则。例如，当您尝试将演示文稿（其幻灯片）转换为图像时，将检查演示文稿的字体，以验证所选字体是否在操作系统中可用。如果确认缺少字体，它们将被替换——请参阅[**字体替换**](https://docs.aspose.com/slides/androidjava/font-replacement/)和[**字体替代**](https://docs.aspose.com/slides/androidjava/font-substitution/)。

Aspose.Slides在处理字体时遵循以下过程：

1. Aspose.Slides在操作系统中搜索字体，以找到与演示文稿所选字体匹配的字体。
2. 如果找到所选字体，Aspose.Slides将使用它。否则，Aspose.Slides将使用尽可能接近PowerPoint所用的替代字体。
3. 如果通过[FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/)设置了字体替换规则，将会应用这些规则。

Aspose.Slides允许您将字体添加到应用程序运行时，然后使用这些字体。请参阅[**自定义字体**](https://docs.aspose.com/slides/androidjava/custom-font/)。

当额外的字体被放置在演示文稿中时，它们被称为[**嵌入字体**](https://docs.aspose.com/slides/androidjava/embedded-font/)。

Aspose.Slides允许您添加仅应用于输出文档的字体。例如，如果您希望转换为PDF的演示文稿包含系统中缺失的字体和嵌入字体，您可以添加或加载所需的字体作为**外部字体**。

{{% alert title="注意" color="primary" %}} 
我们不分发任何字体，无论是付费的还是免费的。我们的API允许您加载外部字体并将其嵌入到文档中，但您是自行决定和负责使用这些字体。
{{% /alert %}}