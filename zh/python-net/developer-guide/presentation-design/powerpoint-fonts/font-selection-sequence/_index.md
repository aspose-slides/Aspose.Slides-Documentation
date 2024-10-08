---
title: Python中的字体选择顺序
linktitle: Python中的字体选择顺序
type: docs
weight: 80
url: /zh/python-net/font-selection-sequence/
keywords:
- 字体
- 字体选择
- 字体替换
- 字体替代
- PowerPoint演示文稿
- Python
- Aspose.Slides for Python
description: "Python中的PowerPoint字体选择顺序"
---

## 字体选择

在加载、渲染或转换演示文稿时，演示文稿中的字体遵循一定的规则。例如，当您尝试将演示文稿（其幻灯片）转换为图像时，会检查演示文稿的字体以验证所选字体是否可在操作系统中使用。如果确认字体缺失，则会被替换 — 请参见 [**字体替换**](https://docs.aspose.com/slides/python-net/font-replacement/) 和 [**字体替代**](https://docs.aspose.com/slides/python-net/font-substitution/)。

Aspose.Slides 在处理字体时遵循以下过程：

1. Aspose.Slides 在操作系统中搜索字体，以找到与演示文稿所选字体匹配的字体。
2. 如果找到所选字体，Aspose.Slides 将使用它。否则，Aspose.Slides 将使用尽可能接近 PowerPoint 所使用的替代字体。
3. 如果通过 [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) 设置了字体替换规则，则会应用这些规则。

Aspose.Slides 允许您将字体添加到应用程序运行时，然后使用这些字体。请参阅 [**自定义字体**](https://docs.aspose.com/slides/python-net/custom-font/)。

当额外字体被放置在演示文稿中时，它们被称为 [**嵌入字体**](https://docs.aspose.com/slides/python-net/embedded-font/)。

Aspose.Slides 允许您添加仅应用于输出文档的字体。例如，如果您希望转换为 PDF 的演示文稿包含系统中缺失的字体和嵌入字体，您可以将所需字体添加或加载为 **外部字体**。

{{% alert title="注意" color="primary" %}} 
我们不分发任何字体，无论是付费还是免费。我们的 API 允许您加载外部字体并将其嵌入文档，但这需要您自行决定和承担责任。
{{% /alert %}}