---
title: 取得 Python 簡報中的段落邊界
linktitle: 段落邊界
type: docs
weight: 43
url: /zh-hant/python-net/paragraph-bounds/
keywords:
- 段落邊界
- 段落座標
- 段落大小
- 文字框
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via .NET 中檢索段落邊界，以優化 PowerPoint 與 OpenDocument 簡報中的文字定位。"
---
## **概覽**

本文說明如何取得 Aspose.Slides 中段落的邊界、大小與座標。它展示了如何使用 [Paragraph.get_rect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/get_rect/) 從 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 取得段落矩形，如何取得表格儲存格文字框內段落的座標，並強調重要細節，如測量單位、文字換行對邊界的影響、像素轉換以及有效的段落格式化值。

## **取得段落的矩形座標**

使用 [Paragraph.get_rect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/get_rect/) 取得段落的外框矩形。

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    paragraph = shape.text_frame.paragraphs[0]
    rectangle = paragraph.get_rect()
```

## **取得表格儲存格文字框內段落的大小**

若要取得表格儲存格文字框中 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 的大小與座標，請使用 [Paragraph.get_rect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/get_rect/)。回傳的矩形相對於表格儲存格文字框，如果需要投影片層級的座標，必須再加上表格位置與儲存格偏移。

以下範例取得表格儲存格內段落的邊界，並在投影片上繪製矩形以視覺化這些邊界：

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

## **常見問題**

**段落座標的測量單位是什麼？**

它們以點（points）為單位，1 英吋等於 72 點。此單位適用於投影片上的所有座標與尺寸。

**文字換行會影響段落的邊界嗎？**

會。若在 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 上啟用了 [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/wrap_text/)，文字會依區域寬度換行，從而更改段落的實際邊界。

**段落座標能可靠地映射到匯出影像的像素嗎？**

可以。使用以下公式將點轉換為像素：pixels = points x (DPI / 72)。結果取決於渲染或匯出時所選擇的 DPI。

**如何取得考慮樣式繼承的「有效」段落格式參數？**

使用[effective paragraph formatting data structure](/slides/zh-hant/python-net/shape-effective-properties/); 它會回傳縮排、間距、換行、RTL 等最終合併的值。