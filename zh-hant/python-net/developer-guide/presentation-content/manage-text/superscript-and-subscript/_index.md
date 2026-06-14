---
title: 在 Python 中管理上標與下標
linktitle: 上標與下標
type: docs
weight: 80
url: /zh-hant/python-net/superscript-and-subscript/
keywords:
- 上標
- 下標
- 加入上標
- 加入下標
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "精通在 Aspose.Slides for Python（透過 .NET）中的上標與下標，並以專業的文字格式提升您的簡報，達到最佳效果。"
---
## **概觀**

Aspose.Slides 提供將上標與下標文字整合至 PowerPoint（PPT、PPTX）和 OpenDocument（ODP）簡報的功能。無論您需要突顯化學式、數學方程式，或以腳註註釋內容，這些專門的格式選項都有助於保持清晰與精確。本文將教您如何在每張投影片中無縫套用上標與下標樣式，以確保專業效果。

## **加入上標與下標文字**

您可以將上標與下標文字加入任何段落部分。於 Aspose.Slides 中，使用 [PortionFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/) 類別的 `escapement` 屬性來控制。

`escapement` 是一個百分比，範圍從 **-100% 到 100%**：

- **> 0** → 上標（例如，25% = 輕微上升；100% = 完全上標）
- **0** → 基線（無上/下標）
- **< 0** → 下標（例如，-25% = 輕微下降；-100% = 完全下標）

步驟：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 並取得投影片。
2. 加入一個矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 並存取其 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)。
3. 清除現有段落。
4. 針對上標：建立段落與文字部份，將 `portion.portion_format.escapement` 設為 **0 至 100** 之間的值，設定文字，並加入該部份。
5. 針對下標：建立另一個段落與文字部份，將 `escapement` 設為 **-100 至 0** 之間的值，設定文字，並加入該部份。
6. 將簡報儲存為 PPTX。

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # 取得投影片。
    slide = presentation.slides[0]

    # 建立文字方塊。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    shape.text_frame.paragraphs.clear()

    # 建立上標文字的段落。
    superscript_paragraph = slides.Paragraph()

    # 建立包含一般文字的文字部份。
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superscript_paragraph.portions.add(portion1)

    # 建立包含上標文字的文字部份。
    superscript_portion = slides.Portion()
    superscript_portion.portion_format.escapement = 30
    superscript_portion.text = "TM"
    superscript_paragraph.portions.add(superscript_portion)

    # 建立下標文字的段落。
    subscript_paragraph = slides.Paragraph()

    # 建立包含一般文字的文字部份。
    portion2 = slides.Portion()
    portion2.text = "a"
    subscript_paragraph.portions.add(portion2)

    # 建立包含下標文字的文字部份。
    subscript_portion = slides.Portion()
    subscript_portion.portion_format.escapement = -25
    subscript_portion.text = "i"
    subscript_paragraph.portions.add(subscript_portion)

    # 將段落加入文字方塊。
    shape.text_frame.paragraphs.add(superscript_paragraph)
    shape.text_frame.paragraphs.add(subscript_paragraph)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**我可以在表格和其他容器中套用上標/下標，而不僅限於普通文字方塊嗎？**

是的。您可以在任何公開 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 的物件（包括表格儲存格）內將文字格式化為上標或下標。此格式會套用於該框架內的文字部份。

**在匯出為 PDF、HTML 或影像時，上標/下標會被保留嗎？**

是的。Aspose.Slides 在匯出至常見格式如 [PDF](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/)、[HTML](/slides/zh-hant/python-net/convert-powerpoint-to-html/) 與 [raster images](/slides/zh-hant/python-net/convert-powerpoint-to-png/) 時會保留上標/下標格式，因為渲染管線會尊重文字部份層級的格式設定。

**我可以在同一文字片段中同時使用上標/下標與超連結嗎？**

是的。[Hyperlinks](/slides/zh-hant/python-net/manage-hyperlinks/) 於文字部份（片段）層級指定，因此一個部份可以同時擁有超連結且被格式化為上標或下標。