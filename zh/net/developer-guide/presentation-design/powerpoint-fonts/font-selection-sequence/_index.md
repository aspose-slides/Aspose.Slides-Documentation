---
title: C# 中的字体选择顺序
linktitle: C# 中的字体选择顺序
type: docs
weight: 80
url: /net/font-selection-sequence/
keywords:
- 字体
- 字体选择
- 字体替换
- 字体替代
- PowerPoint 演示文稿
- C#
- Csharp
- Aspose.Slides for .NET
description: C# 中的 PowerPoint 字体选择顺序
---

## 字体选择

在加载、渲染或转换演示文稿为其他格式时，演示文稿中的字体遵循一定的规则。例如，当您尝试将演示文稿（其幻灯片）转换为图像时，会检查演示文稿中的字体以验证操作系统中是否存在所选字体。如果确认缺少字体，则会进行替换 — 参见 [**字体替换**](https://docs.aspose.com/slides/net/font-replacement/) 和 [**字体替代**](https://docs.aspose.com/slides/net/font-substitution/)。

Aspose.Slides 在处理字体时遵循以下流程：

1. Aspose.Slides 在操作系统中搜索字体，以找到与演示文稿所选字体匹配的字体。
2. 如果找到所选字体，Aspose.Slides 将使用它。否则，Aspose.Slides 会使用尽可能接近 PowerPoint 所使用的替换字体。
3. 如果通过 [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) 设置了字体替换规则，则会应用这些规则。

Aspose.Slides 允许您向应用程序运行时添加字体，然后使用这些字体。请参见 [**自定义字体**](https://docs.aspose.com/slides/net/custom-font/)。

当额外的字体包含在演示文稿中时，它们被称为 [**嵌入字体**](https://docs.aspose.com/slides/net/embedded-font/)。

Aspose.Slides 允许您添加仅应用于输出文档的字体。例如，如果您希望转换为 PDF 的演示文稿包含在您的系统中缺失的字体和嵌入字体，您可以作为 **外部字体** 添加或加载所需的字体。

{{% alert title="注意" color="primary" %}} 
我们不分发任何字体，无论是付费的还是免费的。我们的 API 允许您加载外部字体并将其嵌入文档中，但您需自行承担使用字体的决定和责任。
{{% /alert %}}