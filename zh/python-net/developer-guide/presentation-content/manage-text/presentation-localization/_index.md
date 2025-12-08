---
title: 使用 Python 自动化演示文稿本地化
linktitle: 演示文稿本地化
type: docs
weight: 100
url: /zh/python-net/presentation-localization/
keywords:
- 更改语言
- 拼写检查
- 语言 ID
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中自动化 PowerPoint 和 OpenDocument 幻灯片本地化，提供实用代码示例和技巧，加速全球部署。"
---

## **更改演示文稿和形状文本的语言**
- 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
- 通过使用索引获取幻灯片的引用。
- 向幻灯片添加矩形类型的 AutoShape。
- 向 TextFrame 添加一些文本。
- 设置文本的 Language Id。
- 将演示文稿写入为 PPTX 文件。

以下示例演示了上述步骤的实现。
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```


## **常见问题**
**language_id 会触发自动文本翻译吗？**

否。Aspose.Slides 中的 [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) 用于存储拼写检查和语法校对的语言，但它不会翻译或更改文本内容。它是 PowerPoint 用于校对的元数据。

**language_id 会影响渲染时的连字符和换行吗？**

In Aspose.Slides 中，[language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) 用于校对。连字符质量和换行主要取决于[适当的字体](/slides/zh/python-net/powerpoint-fonts/)的可用性以及书写系统的布局/换行设置。为了确保正确渲染，请提供所需字体，配置[字体替换规则](/slides/zh/python-net/font-substitution/)，并/或将[嵌入字体](/slides/zh/python-net/embedded-font/)嵌入演示文稿。

**我可以在同一段落中设置不同的语言吗？**

是的。[language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) 在文本片段级别应用，因此单个段落可以混合多种语言并具有不同的校对设置。