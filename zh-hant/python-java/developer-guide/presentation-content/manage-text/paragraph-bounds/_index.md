---
title: 從 Python（透過 Java）取得投影片中的段落邊界
linktitle: 段落邊界
type: docs
weight: 43
url: /zh-hant/python-java/paragraph-bounds/
keywords:
- 段落邊界
- 段落座標
- 段落大小
- 文字框
- PowerPoint
- 投影片
- Python
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python（透過 Java）中取得段落邊界，以優化 PowerPoint 投影片的文字定位。"
---
## **概述**

本文說明如何取得 Aspose.Slides 中段落的邊界、大小與座標。它展示如何使用 [Paragraph.getRect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraph/#getRect) 從 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/) 取得段落矩形，如何取得表格儲存格文字框內段落的座標，並強調測量單位、文字換行對邊界的影響、像素轉換以及有效段落格式化值等重要細節。

## **取得段落的矩形座標**

使用 [Paragraph.getRect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraph/#getRect) 取得段落的邊界矩形。

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

## **取得表格儲存格文字框內段落的大小**

若要取得表格儲存格文字框內 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraph/) 的大小與座標，請使用 [Paragraph.getRect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraph/#getRect)。回傳的矩形是相對於表格儲存格文字框的，因此在需要投影片層級座標時，需加上表格位置與儲存格偏移量。

以下範例取得表格儲存格內段落的邊界，並在投影片上繪製矩形以視覺化這些邊界：

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

## **常見問題**

**段落座標使用何種單位測量？**

它們以點 (point) 為單位測量，1 吋等於 72 點。此單位適用於投影片上所有座標與尺寸。

**文字換行會影響段落的邊界嗎？**

會。若為 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/) 的 [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setWrapText) 啟用文字換行，文字會依區域寬度斷行，進而改變段落的實際邊界。

**段落座標能可靠地映射到匯出影像的像素嗎？**

可以。使用以下公式將點轉換為像素：像素 = 點 x (DPI / 72)。結果取決於渲染或匯出時所選擇的 DPI。

**如何取得考慮樣式繼承的「有效」段落格式參數？**

使用 [有效段落格式資料結構](/slides/zh-hant/python-java/shape-effective-properties/)；它會返回縮排、間距、換行、RTL 等最終合併的值。