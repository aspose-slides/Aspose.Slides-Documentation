---
title: 在 Python 中透過 Java 調整簡報投影片的形狀大小
type: docs
weight: 110
url: /zh-hant/python-java/resizing-shapes-on-slide/
aliases:
  - /python-java/re-sizing-shapes-on-slide/
  - /zh-hant/python-java/re-sizing-shapes-on-slide/
keywords:
- 調整形狀大小
- 更改形狀尺寸
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 輕鬆調整 PowerPoint 與 OpenDocument 投影片上的形狀大小——自動化投影片版面調整，提高生產力。"
---
## **概述**

當您變更簡報的投影片尺寸時，可能還需要調整形狀的大小與位置，以符合新的尺寸。本文說明如何手動縮放形狀，以及如何處理投影片、母片與版面的表格。

## **調整形狀大小**

為了保留每個形狀的相對位置與大小，請將其水平座標與寬度乘以新投影片寬度與原始寬度的比例。再將相同的高度比例套用到垂直座標與高度上。

第一個範例會載入投影片中不含表格的簡報，將投影片大小變更為 A4，並儲存結果。它使用[SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) 搭配 [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale) 以便在隨後的迴圈中自行控制縮放。比例值沒有單位；形狀的位置與尺寸以點 (point) 為單位測量。不同的寬度與高度比例可能會扭曲形狀，且變更形狀的尺寸不會同步縮放字型大小。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # 計算水平與垂直的獨立縮放比例。
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setX(shape.getX() * width_ratio)
            shape.setY(shape.getY() * height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
表格需要單獨處理：應根據欄寬與列高的比例進行縮放，而不是直接指定表格的整體寬度與高度。如果儲存格內容需要更多空間，列高可能會保持大於要求的大小。
{{% /alert %}}

第二個範例支援表格，並在儲存調整過大小的簡報之前，處理母片、版面以及個別投影片上的形狀。其輔助程式會對每個[Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) 透過[Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) 縮放欄寬，並以[Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight) 縮放最小列高。之後僅縮放表格的位置，而不會單獨縮放其整體尺寸。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # 表格的尺寸受欄寬與列高控制。
            for column in shape.getColumns():
                column.setWidth(column.getWidth() * width_ratio)

            for row in shape.getRows():
                row.setMinimalHeight(row.getMinimalHeight() * height_ratio)
        else:
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)

        shape.setX(shape.getX() * width_ratio)
        shape.setY(shape.getY() * height_ratio)


presentation = Presentation("sample.pptx")
try:
    # 計算水平與垂直的獨立縮放比例。
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    # 調整母片、版面以及個別投影片上定義的形狀大小。
    for master in presentation.getMasters():
        resize_shapes(master.getShapes(), width_ratio, height_ratio)

        for layout_slide in master.getLayoutSlides():
            resize_shapes(layout_slide.getShapes(), width_ratio, height_ratio)

    for slide in presentation.getSlides():
        resize_shapes(slide.getShapes(), width_ratio, height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**為什麼在調整投影片大小後形狀會被扭曲或截斷？**

如果在變更投影片尺寸時未同步縮放形狀，形狀會保留原始位置與尺寸，可能會超出投影片範圍。以不同的寬高比例進行縮放亦會導致形狀扭曲。

**提供的程式碼是否適用於所有形狀類型？**

第一個範例直接變更形狀的邊界，適用於不含表格的投影片。第二個範例則另行處理表格。請檢查最終版面，尤其是文字與表格，因為這些範例不會縮放字型大小，且表格內容可能限制列高。

**在調整投影片時，如何調整表格的大小？**

如同第二個範例所示，先以寬度比例縮放欄寬、以高度比例縮放最小列高，最後再縮放表格的位置。

**此調整能套用於母片與版面投影片嗎？**

會的。第二個範例會遍歷[Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) 以及每個母片的[MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides)，並對其形狀套用相同的調整邏輯。

**我可以在調整大小的同時變更投影片方向（直向/橫向）嗎？**

可以。在變更投影片大小之後、讀取目標尺寸之前，呼叫[SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation)，以確保縮放係數反映最終的方向。

**我可以設定的投影片尺寸有上限嗎？**

您可以使用[SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) 來設定自訂的投影片尺寸。支援的尺寸亦取決於簡報的格式以及開啟檔案的應用程式。

**如何避免具有固定長寬比的形狀被扭曲？**

使用相同的寬高縮放係數。為了將原始版面適配至新投影片尺寸，可同時使用寬度與高度比例中較小的那個作為縮放係數，套用於尺寸與位置。此做法可保留比例，但可能在一側留下未使用的空間。