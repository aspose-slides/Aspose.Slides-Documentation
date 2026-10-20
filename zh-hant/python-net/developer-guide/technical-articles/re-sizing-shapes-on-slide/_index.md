---
title: 在 Python 中調整簡報投影片上的形狀大小
type: docs
weight: 130
url: /zh-hant/python-net/resizing-shapes-on-slide/
aliases:
  - /python-net/re-sizing-shapes-on-slide/
  - /zh-hant/python-net/re-sizing-shapes-on-slide/
keywords:
- 調整形狀大小
- 變更形狀尺寸
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET，輕鬆調整 PowerPoint 與 OpenDocument 投影片上的形狀大小──自動化投影片版面調整，提升生產力。"
---
## **概觀**

當您更改簡報的投影片尺寸時，可能也需要調整和重新定位其形狀以符合新尺寸。本文說明如何手動縮放形狀以及如何處理投影片、母片和版面的表格。

## **調整形狀大小**

為了保留每個形狀的相對位置與大小，將其水平座標與寬度乘以新投影片寬度與原始寬度的比例。對其垂直座標與高度套用相應的高度比例。

第一個範例載入一個投影片中沒有表格的簡報，將投影片尺寸更改為 A4，並儲存結果。它使用[SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/)與[SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/)以便後續迴圈控制縮放。比例是無單位的；形狀的位置和尺寸以點為單位測量。不同的寬高比例會扭曲形狀，且變更形狀尺寸不會縮放其字型大小。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # 計算獨立的水平與垂直縮放因子。
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    for slide in presentation.slides:
        for shape in slide.shapes:
            shape.width *= width_ratio
            shape.height *= height_ratio
            shape.x *= width_ratio
            shape.y *= height_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
表格需要單獨處理：以比例縮放其欄寬與列高，而不是直接指定表格的整體寬度與高度。如果儲存格內容需要更多空間，列高可能仍會大於要求的尺寸。
{{% /alert %}}

第二個範例支援表格，且在儲存調整尺寸後的簡報之前，會同時處理母片、版面以及單一投影片上的形狀。它的輔助程式會對每個[Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)透過縮放[Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/)與[Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/)來處理。之後再縮放表格的位置，而不會單獨縮放其整體尺寸。

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # 表格尺寸由欄寬和列高控制。
            for column in shape.columns:
                column.width *= width_ratio

            for row in shape.rows:
                row.minimal_height *= height_ratio
        else:
            shape.width *= width_ratio
            shape.height *= height_ratio

        shape.x *= width_ratio
        shape.y *= height_ratio


with slides.Presentation("sample.pptx") as presentation:
    # 計算獨立的水平與垂直縮放因子。
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # 調整母片、版面以及個別投影片上定義的形狀。
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**為什麼在調整投影片尺寸後形狀會變形或被截斷？**

如果在更改投影片尺寸時未同時縮放形狀，形狀會保留原始位置與尺寸，可能會超出投影片範圍。寬高使用不同比例縮放也會造成形狀變形。

**提供的程式碼能適用於所有形狀類型嗎？**

第一個範例直接變更形狀邊界，適用於沒有表格的投影片。第二個範例則會單獨處理表格。請檢查最終版面，特別是文字與表格，因為這些範例不會縮放字型大小，且表格內容可能限制列高。

**在調整投影片時，如何調整表格的尺寸？**

如第二個範例所示，先以寬度比例縮放欄寬，並以高度比例縮放最小列高，然後再縮放表格的位置。

**此調整方式會套用於母片投影片與版面投影片嗎？**

會的。第二個範例會遍歷[Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/)以及每個母片的[MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/)並對其形狀套用相同的調整邏輯。

**我可以在調整尺寸的同時變更投影片的方向（直向/橫向）嗎？**

可以。在變更投影片尺寸後、讀取目標尺寸前，設定[SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/)，以便縮放因子反映最終的方向。

**設定投影片尺寸有大小限制嗎？**

您可以使用[SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/)指定自訂投影片尺寸。支援的尺寸亦受簡報格式與開啟檔案的應用程式影響。

**如何防止具有固定長寬比的形狀變形？**

對寬度與高度使用相同的縮放因子。若要讓原始版面適應新投影片尺寸，可同時使用較小的寬高比例作為兩者的縮放因子，這樣可保留比例，但可能在一側留下未使用的空間。