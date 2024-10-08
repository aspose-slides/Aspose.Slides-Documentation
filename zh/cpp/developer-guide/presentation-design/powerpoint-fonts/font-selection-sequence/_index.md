---
title: C++ 中的字体选择顺序
linktitle: C++ 中的字体选择顺序
type: docs
weight: 80
url: /zh/cpp/font-selection-sequence/
keywords:
- 字体
- 字体选择
- 字体替换
- 字体替代
- PowerPoint 演示文稿
- C++
- Aspose.Slides for C++
description: "C++ 中 PowerPoint 字体选择顺序"
---

## 字体选择

在加载、呈现或转换为其他格式时，演示文稿中的字体遵循特定规则。例如，当您尝试将演示文稿（其幻灯片）转换为图像时，会检查演示文稿的字体，以验证所选字体是否在操作系统中可用。如果确认字体缺失，则会进行替换 — 请参见 [**字体替换**](https://docs.aspose.com/slides/cpp/font-replacement/) 和 [**字体替代**](https://docs.aspose.com/slides/cpp/font-substitution/)。

Aspose.Slides 在处理字体时遵循以下流程：

1. Aspose.Slides 在操作系统中搜索字体，以找到与演示文稿所选字体匹配的字体。
2. 如果找到所选字体，Aspose.Slides 就会使用它。否则，Aspose.Slides 将使用尽可能接近 PowerPoint 使用的替代字体。
3. 如果通过 [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/) 设置了字体替换规则，则会应用这些规则。

Aspose.Slides 允许您在应用程序运行时添加字体，然后使用这些字体。请参见 [**自定义字体**](https://docs.aspose.com/slides/cpp/custom-font/)。

当额外的字体放置在演示文稿中时，它们被称为 [**嵌入字体**](https://docs.aspose.com/slides/cpp/embedded-font/)。

Aspose.Slides 允许您添加仅应用于输出文档的字体。例如，如果您要转换为 PDF 的演示文稿中包含您系统中缺失的字体和嵌入字体，您可以将所需字体添加或加载为 **外部字体**。

{{% alert title="注意" color="primary" %}} 
我们不分发任何字体，无论是付费还是免费的。我们的 API 允许您加载外部字体并将其嵌入文档，但您需要自行决定和负责使用这些字体。
{{% /alert %}}