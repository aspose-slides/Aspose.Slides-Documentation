---
title: 在 Python 中調整簡報投影片上的形狀大小
type: docs
weight: 130
url: /zh-hant/python-net/resizing-shapes-on-slide/
aliases:
  - /zh-hant/python-net/re-sizing-shapes-on-slide/
keywords:
- 調整形狀大小
- 變更形狀尺寸
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 透過 .NET，輕鬆調整 PowerPoint 與 OpenDocument 投影片上的形狀大小——自動化投影片版面調整並提升生產力。"
---
## **概觀**

當您變更簡報的投影片尺寸時，可能還需要調整形狀的大小與位置，以符合新的尺寸。本文說明如何手動縮放形狀，以及如何在投影片、母片和版面配置上處理表格。

## **調整形狀**

為了保留每個形狀的相對位置與大小，需將其水平座標與寬度乘以新投影片寬度與原始寬度的比例。再將相同的高度比例套用於其垂直座標與高度。

第一個範例載入一個投影片中不包含表格的簡報，將投影片大小變更為 A4，並儲存結果。它使用 [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) 搭配 [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) 以便之後的迴圈負責縮放。比例是無單位的；形狀的位置與尺寸以點 (point) 為單位。不同的寬度與高度比例會導致形狀變形，且變更形狀尺寸不會縮放其字型大小。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # 計算水平與垂直的獨立縮放因子。
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
表格需要單獨處理：必須縮放其欄寬與列高，而不是直接設定表格的整體寬度與高度。如果儲存格內容需要更多空間，列高可能會大於要求的尺寸。
{{% /alert %}}

第二個範例支援表格，且在儲存調整大小的簡報之前，會處理母片、版面配置以及個別投影片上的形狀。其輔助程式會對每個 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 透過縮放 [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) 與 [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) 來處理。之後會僅縮放表格的位置，而不會單獨縮放其整體尺寸。

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # 表格的尺寸由欄寬和列高控制。
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
    # 計算水平與垂直的獨立縮放因子。
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # 調整在母片、版面配置以及個別投影片上定義的形狀大小。
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**為什麼在調整投影片大小後，形狀會變形或被截斷？**

如果在變更投影片大小時未對形狀進行縮放，形狀會保留原始位置與尺寸，可能會延伸至投影片之外。以不同的比例縮放寬度與高度也會導致形狀變形。

**提供的程式碼是否適用於所有形狀類型？**

第一個範例直接變更形狀的邊界，適用於沒有表格的投影片。第二個範例則會單獨處理表格。請檢查最終的版面配置，特別是文字與表格，因為這些範例不會縮放字型大小，且表格內容可能會限制列高。

**在調整投影片大小時，該如何調整表格的尺寸？**

如第二個範例所示，先以寬度比例縮放欄寬，並以高度比例縮放最小列高，最後再縮放表格的位置。

**此調整大小方式是否適用於母片與版面配置投影片？**

是的。第二個範例會遍歷 [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) 以及每個母片的 [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/)，並對其形狀套用相同的調整大小邏輯。

**我可以在調整大小的同時變更投影片的方向（直向/橫向）嗎？**

可以。先變更投影片大小後，在讀取目標尺寸之前設定 [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/)，如此縮放係數會反映最終的方向。

**我可以設定的投影片尺寸是否有限制？**

您可以使用 [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) 來指定自訂的投影片尺寸。支援的尺寸亦取決於簡報格式及開啟檔案的應用程式。

**如何防止具有固定長寬比的形狀被扭曲？**

對寬度與高度使用相同的縮放係數。若要在新投影片尺寸內保留原始版面配置，請同時取寬度與高度比例較小的那個作為縮放係數，套用於尺寸與位置。此方法可維持比例，但可能會在某一側留下未使用的空間。