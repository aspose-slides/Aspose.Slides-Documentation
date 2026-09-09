---
title: 用 Java 的 Python 获取演示文稿中的段落边界
linktitle: 段落边界
type: docs
weight: 43
url: /zh/python-java/paragraph-bounds/
keywords:
- 段落边界
- 段落坐标
- 段落大小
- 文本框
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via Java 中检索段落边界，以优化 PowerPoint 演示文稿中的文本定位。"
---
## **概述**

本文阐述了如何获取 Aspose.Slides 中段落的边界、尺寸和坐标。它展示了如何通过使用 [Paragraph.getRect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraph/#getRect) 从 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/) 检索段落矩形，如何获取表格单元格文本框内段落的坐标，并强调了测量单位、文本换行对边界的影响、像素转换以及有效段落格式化值等重要细节。

## **获取段落的矩形坐标**

使用 [Paragraph.getRect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraph/#getRect) 获取段落的边界矩形。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    rectangle = paragraph.getRect()
finally:
    presentation.dispose()
```

## **获取表格单元格文本框内段落的大小**

要获取表格单元格文本框内 [Paragraph](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraph/) 的大小和坐标，请使用 [Paragraph.getRect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraph/#getRect)。返回的矩形相对于表格单元格文本框，因此在需要幻灯片级别坐标时，需要加上表格位置和单元格偏移。

下面的示例获取表格单元格内段落的边界，并在幻灯片上绘制矩形以可视化这些边界：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation("source.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)
    cell = table.getRows().get_Item(1).get_Item(1)

    cell_x = table.getX() + cell.getOffsetX()
    cell_y = table.getY() + cell.getOffsetY()

    for paragraph in cell.getTextFrame().getParagraphs():
        if not paragraph.getText():
            continue

        paragraph_rectangle = paragraph.getRect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, paragraph_rectangle_x, paragraph_rectangle_y, paragraph_rectangle.width, paragraph_rectangle.height)

        paragraph_bounds_shape.getFillFormat().setFillType(FillType.NoFill)
        paragraph_bounds_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
        paragraph_bounds_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**段落坐标使用什么单位？**

它们使用点（point）作为单位，1 英寸等于 72 点。这适用于幻灯片上的所有坐标和尺寸。

**换行会影响段落的边界吗？**

会。若为 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/) 启用了 [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/#setWrapText)，文本会在区域宽度内换行，从而改变段落的实际边界。

**段落坐标能可靠地映射到导出图像的像素吗？**

能。使用公式：像素 = 点 × (DPI / 72) 将点转换为像素。结果取决于渲染或导出时选择的 DPI。

**如何获取“有效”的段落格式化参数，以考虑样式继承？**

使用 [effective paragraph formatting data structure](/slides/zh/python-java/shape-effective-properties/)；它返回缩进、间距、换行、RTL 等参数的最终合并值。