---
title: 从演示文稿中获取段落边界（Python）
linktitle: 段落
type: docs
weight: 60
url: /zh/python-net/paragraph/
keywords:
- 段落边界
- 文本段落边界
- 段落坐标
- 段落部分坐标
- 段落大小
- 文本段落大小
- 文本框
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 检索段落和文本段的边界，以优化 PowerPoint 和 OpenDocument 演示文稿中的文本定位。"
---

## **在 TextFrame 中获取段落和文本段坐标**
使用 Aspose.Slides for Python via .NET，开发者现在可以获取 TextFrame 中段落集合内段落的矩形坐标。它还允许获取段落中文本段集合内文本段的坐标。在本章节中，我们将通过示例演示如何获取段落的矩形坐标以及段落内部文本段的位置。

## **获取段落的矩形坐标**
新增方法 **GetRect()** 已添加。它用于获取段落的边界矩形。

```py
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **获取表格单元格文本框内段落和文本段的大小** ##

要获取表格单元格文本框中 [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) 或 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 的大小和坐标，可使用 [IPortion.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) 和 [IParagraph.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) 方法。

以下示例代码演示了上述操作：

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

## **FAQ**

**段落和文本段的坐标以什么单位返回？**

以点为单位，1 英寸 = 72 点。此规则适用于幻灯片上的所有坐标和尺寸。

**自动换行会影响段落的边界吗？**

是的。如果在 [wrapping](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) 已在 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 中启用，文本会根据区域宽度换行，从而改变段落的实际边界。

**段落坐标能可靠地映射到导出图像的像素吗？**

是的。使用以下公式将点转换为像素：pixels = points × (DPI / 72)。结果取决于渲染/导出时选择的 DPI。

**如何获取“有效”的段落格式参数，以考虑样式继承？**

使用 [effective paragraph formatting data structure](/slides/zh/python-net/shape-effective-properties/)，它返回缩进、间距、换行、RTL 等的最终合并值。