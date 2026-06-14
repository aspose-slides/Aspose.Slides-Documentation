---
title: 使用 Python 在簡報中建立線條形狀
linktitle: 線條
type: docs
weight: 50
url: /zh-hant/python-net/line/
keywords:
- 線條
- 建立線條
- 加入線條
- 純線條
- 設定線條
- 自訂線條
- 虛線樣式
- 箭頭
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 與 OpenDocument 簡報中操作線條格式設定。探索屬性、方法與範例。"
---
## **概覽**

Aspose.Slides for Python via .NET 支援在投影片中加入各種形狀。在本主題中，我們將透過在投影片中加入直線來開始使用形狀。使用 Aspose.Slides，開發人員不僅可以建立簡單的直線，還可以在投影片上繪製一些華麗的直線。

## **建立純直線**

使用 Aspose.Slides 在投影片上加入純直線作為簡易分隔線或連接線。若要在簡報中選取的投影片上加入純直線，請遵循以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的執行個體。
2. 依照索引取得投影片的參考。
3. 使用 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/) 物件的 `add_auto_shape` 方法，加入類型為 `LINE` 的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
4. 將簡報儲存為 PPTX 檔案。

下列範例會在簡報的第一張投影片加入一條直線。

```py
import aspose.slides as slides

# 實例化 Presentation 類別。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增類型為 LINE 的自動形狀。
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # 將簡報儲存為 PPTX 檔案。
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **建立帶箭頭的直線**

Aspose.Slides 允許您設定直線屬性，使其更具視覺吸引力。以下我們將設定直線的幾項屬性，使其呈現為箭頭。請遵循以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的執行個體。
2. 依照索引取得投影片的參考。
3. 使用 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/) 物件的 `add_auto_shape` 方法，加入類型為 `LINE` 的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
4. 設定 [line style](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/linestyle/)。
5. 設定直線寬度。
6. 設定直線的 [dash style](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/linedashstyle/)。
7. 設定直線起點的 [arrowhead style](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/linearrowheadstyle/) 與長度。
8. 設定直線終點的箭頭樣式與長度。
9. 將簡報儲存為 PPTX 檔案。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 實例化代表 PPTX 檔案的 Presentation 類別。
with slides.Presentation() as presentation:
    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增類型為 LINE 的自動形狀。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # 套用線條的格式設定。
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # 將簡報儲存為 PPTX 檔案。
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**我可以將普通直線轉換為連接器，使其「貼齊」形狀嗎？**

不會。普通直線（類型為 [LINE](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapetype/) 的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)）不會自動變成連接器。若要使其貼齊形狀，請使用專用的 [Connector](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/connector/) 類型以及用於連接的 [corresponding APIs](/slides/zh-hant/python-net/connector/)。

**如果直線的屬性繼承自佈景主題且難以判斷最終值，我應該怎麼辦？**

請透過 [ILineFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ilinefillformateffectivedata/) 類別閱讀 [有效屬性](/slides/zh-hant/python-net/shape-effective-properties/)，這些類別已考慮繼承與佈景主題樣式。

**我可以鎖定直線以防止編輯（移動、調整大小）嗎？**

可以。形狀提供 [lock objects](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/auto_shape_lock/)，讓您 [禁止編輯操作](/slides/zh-hant/python-net/applying-protection-to-presentation/)。