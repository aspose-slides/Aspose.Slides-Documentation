---
title: 段落
type: docs
weight: 60
url: /zh/python-net/paragraph/
keywords: "段落, 部分, 段落坐标, 部分坐标, PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "Python 中 PowerPoint 演示文稿的段落和部分"
---

## **获取 TextFrame 中段落和部分的坐标**
使用 Aspose.Slides for Python via .NET，开发者现在可以获取 TextFrame 的段落集合中的段落的矩形坐标。它还允许您获取部分集合中部分的坐标。在本主题中，我们将通过示例展示如何获取段落的矩形坐标以及段落内部分的位置。

## **获取段落的矩形坐标**
新的方法 **GetRect()** 已被添加。它允许获取段落边界矩形。

```py
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **获取表格单元格文本框中段落和部分的大小** ##

要获取表格单元格文本框中 [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) 或 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 的大小和坐标，可以使用 [IPortion.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) 和 [IParagraph.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) 方法。

以下示例代码演示了描述的操作：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "source.pptx") as pres:
    tbl = pres.slides[0].shapes[0]

    cell = tbl.rows[1][1]

    x = tbl.X + tbl.rows[1][1].offset_x
    y = tbl.Y + tbl.rows[1][1].offset_y

    for para in cell.text_frame.paragraphs:
        if para.text == "":
            continue

        rect = para.get_rect()
        shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                rect.x + x, rect.y + y, rect.width, rect.height)

        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        shape.line_format.fill_format.fill_type = slides.FillType.SOLID

        for portion in para.portions:
            if "0" in portion.text:
                rect = portion.get_rect()
                shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                        rect.x + x, rect.y + y, rect.width, rect.height)

                shape.fill_format.fill_type = slides.FillType.NO_FILL
```