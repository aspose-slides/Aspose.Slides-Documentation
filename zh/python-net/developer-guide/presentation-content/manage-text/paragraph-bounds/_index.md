---
title: 获取 Python 演示文稿中的段落边界
linktitle: 段落边界
type: docs
weight: 43
url: /zh/python-net/paragraph-bounds/
keywords:
- 段落边界
- 段落坐标
- 段落大小
- 文本框
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via .NET 中检索段落边界，以优化 PowerPoint 和 OpenDocument 演示文稿中的文本定位。"
---
## **概述**

本文说明了如何获取 Aspose.Slides 中段落的边界、大小和坐标。它展示了如何使用 [Paragraph.get_rect](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/get_rect/) 从 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 检索段落矩形，如何获取表格单元格文本框内段落的坐标，并强调了测量单位、换行对边界的影响、像素转换以及有效段落格式值等重要细节。

## **获取段落的矩形坐标**

使用 [Paragraph.get_rect](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/get_rect/) 获取段落的边界矩形。

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    paragraph = shape.text_frame.paragraphs[0]
    rectangle = paragraph.get_rect()
```

## **获取表格单元格 TextFrame 中段落的大小**

要获取表格单元格文本框中 [Paragraph](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/) 的大小和坐标，使用 [Paragraph.get_rect](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/get_rect/)。返回的矩形是相对于表格单元格文本框的，如果需要幻灯片级别的坐标，需要加上表格位置和单元格偏移量。

下面的示例获取表格单元格内段落的边界，并在幻灯片上绘制矩形以直观显示这些边界：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("source.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]
    cell = table.rows[1][1]

    cell_x = table.x + cell.offset_x
    cell_y = table.y + cell.offset_y

    for paragraph in cell.text_frame.paragraphs:
        if paragraph.text == "":
            continue

        paragraph_rectangle = paragraph.get_rect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.shapes.add_auto_shape(
            slides.ShapeType.RECTANGLE,
            paragraph_rectangle_x,
            paragraph_rectangle_y,
            paragraph_rectangle.width,
            paragraph_rectangle.height)

        paragraph_bounds_shape.fill_format.fill_type = slides.FillType.NO_FILL
        paragraph_bounds_shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        paragraph_bounds_shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**段落坐标使用什么单位测量？**

它们以点为单位，1 英寸等于 72 点。这适用于幻灯片上的所有坐标和尺寸。

**换行会影响段落的边界吗？**

是的。如果为 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 启用了 [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/wrap_text/)，文本会换行以适应区域宽度，从而改变段落的实际边界。

**段落坐标能可靠地映射到导出图像的像素吗？**

可以。使用公式 pixels = points × (DPI / 72) 将点转换为像素。结果取决于渲染或导出时选择的 DPI。

**如何获取考虑样式继承后的“有效”段落格式参数？**

使用 [有效段落格式数据结构](/slides/zh/python-net/shape-effective-properties/); 它返回缩进、间距、换行、RTL 等参数的最终合并值。