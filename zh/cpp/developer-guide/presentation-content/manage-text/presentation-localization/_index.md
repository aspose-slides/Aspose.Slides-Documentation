---
title: 用 C++ 自动化演示文稿本地化
linktitle: 演示文稿本地化
type: docs
weight: 100
url: /zh/cpp/presentation-localization/
keywords:
- 更改语言
- 拼写检查
- 语言 ID
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中自动化 PowerPoint 和 OpenDocument 幻灯片本地化，提供实用代码示例和加速全球推广的技巧。"
---

## **更改演示文稿和形状文本的语言**
- 创建一个[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)类的实例。
- 通过使用索引获取幻灯片的引用。
- 向幻灯片添加矩形类型的 AutoShape。
- 向 TextFrame 添加一些文本。
- 为文本设置 Language Id。
- 将演示文稿写入 PPTX 文件。

以下示例演示了上述步骤的实现。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}

## **常见问题**

**语言 ID 会触发自动文本翻译吗？**

不。Aspose.Slides 中的[Language ID](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/)用于存储拼写检查和语法校对的语言，但它不会翻译或更改文本内容。它是 PowerPoint 用于校对的元数据。

**语言 ID 会影响渲染过程中的连字符和换行吗？**

在 Aspose.Slides 中，[Language ID](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/)用于校对。连字符质量和换行主要取决于[合适的字体](/slides/zh/cpp/powerpoint-fonts/)以及书写系统的布局/换行设置。为确保正确渲染，请确保所需字体可用，配置[字体替换规则](/slides/zh/cpp/font-substitution/)，以及/或将[嵌入字体](/slides/zh/cpp/embedded-font/)嵌入演示文稿。

**我可以在同一段落中设置不同的语言吗？**

可以。[Language ID](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/)在文本片段级别应用，因此单个段落可以混合多种语言，并拥有不同的校对设置。