---
title: 在 Python via Java 中調整簡報投影片的形狀大小
type: docs
weight: 110
url: /zh-hant/python-java/re-sizing-shapes-on-slide/
keywords:
- 調整形狀大小
- 變更形狀尺寸
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 輕鬆調整 PowerPoint 與 OpenDocument 投影片上的形狀大小——自動化投影片版面調整並提升工作效率。"
---
## **概覽**

Aspose.Slides for Python via Java 客戶最常問的問題之一是如何調整形狀大小，使得在投影片尺寸變更時，資料不會被截斷。本文簡短技術說明將展示如何做到這一點。

## **調整形狀大小**

為防止投影片尺寸變更時形狀位置錯位，請更新每個形狀的位置與尺寸，使其符合新的投影片佈局。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

# 載入簡報檔案。
presentation = Presentation("sample.ppt")
try:
    # 取得原始投影片尺寸。
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # 在不縮放現有形狀的情況下變更投影片尺寸。
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)

    # 取得新的投影片尺寸。
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # 調整並重新定位每張投影片上的形狀。
    for slide in presentation.getSlides():
        for shape in slide.getShapes():

            # 縮放形狀尺寸。
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # 縮放形狀位置。
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="注意" %}} 

表格不需要特別處理：設定表格的寬度與高度會按比例重新縮放其行與列，因此再度縮放行高與列寬會使比例套用兩次。

{{% /alert %}} 

上面的程式碼僅會變更投影片上的形狀。母片與版面配置投影片保有自己的形狀，若希望整個簡報遵循新的投影片尺寸，亦需同時對它們的形狀進行縮放：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

presentation = Presentation("sample.pptx")
try:
    # 取得原始投影片尺寸。
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # 在不縮放現有形狀的情況下變更投影片尺寸。
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    # presentation.getSlideSize().setOrientation(SlideOrientation.Portrait)

    # 取得新的投影片尺寸。
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.getMasters():
        for shape in master.getShapes():
            # 縮放形狀尺寸。
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # 縮放形狀位置。
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

        for layout_slide in master.getLayoutSlides():
            for shape in layout_slide.getShapes():
                # 縮放形狀尺寸。
                shape.setHeight(shape.getHeight() * height_ratio)
                shape.setWidth(shape.getWidth() * width_ratio)

                # 縮放形狀位置。
                shape.setY(shape.getY() * height_ratio)
                shape.setX(shape.getX() * width_ratio)

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            # 縮放形狀尺寸。
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # 縮放形狀位置。
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**為何在調整投影片大小後形狀會被扭曲或截斷？**

在調整投影片尺寸時，形狀會保留原始位置與大小，除非明確改變縮放比例。這可能導致內容被裁切或形狀錯位。

**提供的程式碼是否適用於所有形狀類型？**

是的。設定高度與寬度同樣適用於文字方塊、影像、圖表以及表格等。

**在調整投影片時，如何調整表格大小？**

直接縮放表格形狀本身，和其他形狀一樣。其行列會比例跟隨縮放，請勿在之後再次分別縮放行高或列寬。

**此調整方式是否適用於母片與版面配置投影片？**

是的，但您也應該遍歷 [Presentation.getMasters](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getMasters) 與 [Presentation.getLayoutSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getLayoutSlides)，對它們的形狀套用相同的縮放邏輯，以確保簡報全體一致。

**我可以在調整尺寸的同時更改投影片的方向（直式/橫式）嗎？**

可以。您可以使用 [SlideSize.setOrientation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesize/#setOrientation) 變更方向，並確保相應調整縮放邏輯以維持版面配置。

**投影片尺寸有上限嗎？**

Aspose.Slides 支援自訂尺寸，但過大的尺寸可能會影響效能或與某些 PowerPoint 版本的相容性。

**如何避免固定長寬比的形狀被扭曲？**

在縮放前可檢查形狀鎖定的 [getAspectRatioLocked](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshapelock/#getAspectRatioLocked) 方法。若已鎖定，請比例調整寬度或高度，而非分別縮放。