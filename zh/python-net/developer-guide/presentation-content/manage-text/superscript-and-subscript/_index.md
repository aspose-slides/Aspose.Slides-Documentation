---
title: 在 Python 中管理上标和下标
linktitle: 上标和下标
type: docs
weight: 80
url: /zh/python-net/superscript-and-subscript/
keywords:
- 上标
- 下标
- 添加上标
- 添加下标
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "通过 .NET 在 Aspose.Slides for Python 中掌握上标和下标，提升演示文稿的专业文本格式，实现最大影响力。"
---

## **添加上标和下标文本**

您可以向任何段落部分添加上标和下标文本。在 Aspose.Slides 中，使用 `escapement` 属性来控制此行为，属性位于 [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) 类。

`escapement` 是一个百分比，范围从 **-100% 到 100%**：

- **> 0** → 上标（例如，25% = 稍微上移；100% = 完全上标）
- **0** → 基线（无上标/下标）
- **< 0** → 下标（例如，-25% = 稍微下移；-100% = 完全下标）

步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 并获取幻灯片。
1. 添加一个矩形 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 并访问其 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)。
1. 清除已有的段落。
1. 对于上标：创建一个段落和一个文本段，设置 `portion.portion_format.escapement` 为 **0 到 100** 之间的值，设置文本，然后添加该文本段。
1. 对于下标：创建另一个段落和文本段，设置 `escapement` 为 **-100 到 0** 之间的值，设置文本，然后添加该文本段。
1. 将演示文稿保存为 PPTX。

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # 获取幻灯片。
    slide = presentation.slides[0]

    # 创建文本框。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    shape.text_frame.paragraphs.clear()

    # 创建上标文本的段落。
    superscript_paragraph = slides.Paragraph()

    # 创建常规文本的文本段。
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superscript_paragraph.portions.add(portion1)

    # 创建上标文本的文本段。
    superscript_portion = slides.Portion()
    superscript_portion.portion_format.escapement = 30
    superscript_portion.text = "TM"
    superscript_paragraph.portions.add(superscript_portion)

    # 创建下标文本的段落。
    subscript_paragraph = slides.Paragraph()

    # 创建常规文本的文本段。
    portion2 = slides.Portion()
    portion2.text = "a"
    subscript_paragraph.portions.add(portion2)

    # 创建下标文本的文本段。
    subscript_portion = slides.Portion()
    subscript_portion.portion_format.escapement = -25
    subscript_portion.text = "i"
    subscript_paragraph.portions.add(subscript_portion)

    # 将段落添加到文本框。
    shape.text_frame.paragraphs.add(superscript_paragraph)
    shape.text_frame.paragraphs.add(subscript_paragraph)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```


## **常见问题**

**我能在表格和其他容器中使用上标/下标，而不仅限于普通文本框吗？**

是的。您可以在任何暴露 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 的对象（包括表格单元格）内部将文本格式化为上标或下标。该格式会应用于该框架内的文本段。

**导出为 PDF、HTML 或图片时，上标/下标会被保留吗？**

是的。Aspose.Slides 在导出到常见格式（如 [PDF](/slides/zh/python-net/convert-powerpoint-to-pdf/)、[HTML](/slides/zh/python-net/convert-powerpoint-to-html/)、以及 [raster images](/slides/zh/python-net/convert-powerpoint-to-png/)）时会保留上标/下标格式，因为渲染管线会遵循文本段级别的格式设置。

**我能在同一文本片段中将上标/下标与超链接组合使用吗？**

是的。[Hyperlinks](/slides/zh/python-net/manage-hyperlinks/) 在文本段（片段）级别分配，因此同一个文本段可以同时包含超链接并设置为上标或下标。