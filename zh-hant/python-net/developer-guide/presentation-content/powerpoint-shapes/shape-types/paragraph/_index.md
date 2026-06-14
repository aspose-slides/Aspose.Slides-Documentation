---
title: 從 Python 取得簡報中的段落邊界
linktitle: 段落
type: docs
weight: 60
url: /zh-hant/python-net/paragraph/
keywords:
- 段落邊界
- 文字片段邊界
- 段落座標
- 片段座標
- 段落大小
- 文字片段大小
- 文字框
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via .NET 中檢索段落與文字片段的邊界，以優化 PowerPoint 與 OpenDocument 簡報中的文字定位。"
---
## **概述**

本文說明如何取得 Aspose.Slides 中段落與文字片段的邊界、大小與座標。它示範如何使用 `get_rect()` 從 `TextFrame` 取得段落的矩形、如何取得表格儲存格文字框內段落與片段的座標，並強調測量單位、文字換行對邊界的影響、像素轉換，以及有效的段落格式設定值等重要細節。

## **取得 TextFrame 中段落與片段的座標**

使用 Aspose.Slides for Python via .NET，開發人員現在可以取得 TextFrame 中段落集合內段落的矩形座標。它也允許取得段落中片段集合內片段的座標。於本主題中，我們將透過範例示範如何取得段落的矩形座標以及段落內片段的位置。

## **取得段落的矩形座標**

已新增方法 **GetRect()**。它可取得段落的邊界矩形。

```py
import aspose.slides as slides

# 實例化一個表示簡報檔案的 Presentation 物件
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **取得表格儲存格文字框內段落與片段的大小** ##

若要取得表格儲存格文字框內 [Portion](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/) 或 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 的大小與座標，可使用 [IPortion.GetRect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iportion/) 與 [IParagraph.GetRect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iparagraph/) 方法。

以下範例程式碼示範上述操作：

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

## **常見問題**

**段落與文字片段的座標以何種單位回傳？**

以點 (point) 為單位，1 吋 = 72 點。此單位適用於投影片上所有的座標與尺寸。

**文字換行會影響段落的邊界嗎？**

會。若在 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 中啟用[換行](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/wrap_text/)，文字會依區域寬度換行，從而改變段落的實際邊界。

**段落的座標能可靠地映射到匯出影像的像素嗎？**

能。可使用以下公式將點轉換為像素：pixels = points × (DPI / 72)。結果取決於渲染／匯出時所選擇的 DPI。

**如何取得考慮樣式繼承的「有效」段落格式參數？**

使用 [effective paragraph formatting data structure](/slides/zh-hant/python-net/shape-effective-properties/); 它會回傳縮排、間距、換行、RTL 等最終合併的值。