---
title: 從簡報中取得整個投影片背景作為影像
linktitle: 整個投影片背景
type: docs
weight: 95
url: /zh-hant/python-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- 投影片背景
- 最終背景
- 提取背景
- 整體背景
- 背景轉為影像
- PPT 背景
- PPTX 背景
- ODP 背景
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 從 PowerPoint 和 OpenDocument 簡報中提取完整投影片背景為影像，簡化視覺工作流程。"
---
## **概觀**

在 PowerPoint 簡報中，投影片背景可能由多個元素組成，包括投影片背景影像、簡報主題、色彩配置，以及放置於母片或版面投影片上的物件。

本篇說明如何使用 Aspose.Slides for Python via Java 將整個投影片背景提取為影像。由於沒有單一方法可完成此任務，需要將選取的投影片複製到暫存簡報，刪除投影片圖形，然後將結果投影片背景轉換為影像。

## **取得整個投影片背景**

Aspose.Slides for Python via Java 未提供直接將整個簡報投影片背景匯出為影像的簡易方法，但您可依照下列步驟完成：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別載入簡報。
1. 從簡報中取得投影片大小。
1. 選取投影片。
1. 建立暫存簡報。
1. 在暫存簡報中設定相同的投影片大小。
1. 將選取的投影片複製到暫存簡報中。
1. 刪除已複製投影片中的圖形。
1. 將已複製的投影片轉換為影像。

以下程式碼範例可將整個簡報投影片背景提取為影像。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, ImageFormat

slide_index = 0
image_scale = 1.0

presentation = Presentation("sample.pptx")
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(slide_index)

    temp_presentation = Presentation()
    try:
        slide_width = jpype.JFloat(slide_size.getWidth())
        slide_height = jpype.JFloat(slide_size.getHeight())
        temp_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)

        cloned_slide = temp_presentation.getSlides().addClone(slide)
        cloned_slide.getShapes().clear()

        background = cloned_slide.getImage(image_scale, image_scale)
        try:
            background.save("output.png", ImageFormat.Png)
        finally:
            background.dispose()
    finally:
        temp_presentation.dispose()
finally:
    presentation.dispose()
```

## **常見問題**

**會保留母片上複雜的漸層、紋理或圖片填充，作為最終的背景影像嗎？**

是。Aspose.Slides 會呈現在投影片、版面或母片上定義的漸層、圖片與紋理填滿。如果您需要將外觀與繼承的母片分離，請在匯出前於目前的投影片[設定自訂背景](/slides/zh-hant/python-java/presentation-background/)。

**在儲存之前，我可以在最終的背景影像上加入浮水印嗎？**

是。您可以在工作用的[加入浮水印](/slides/zh-hant/python-java/watermark/)圖形或圖像於[投影片的副本](/slides/zh-hant/python-java/clone-slides/)（放在其他內容之後）上，然後匯出。這樣即可產生已內嵌浮水印的背景影像。

**我可以在不依賴現有投影片的情況下，取得特定版面或母片的背景嗎？**

是。存取所需的母片或版面，將其套用到[暫存投影片](/slides/zh-hant/python-java/clone-slides/)並設定所需大小，然後匯出該投影片，即可取得來自該版面或母片的背景。

**是否有授權限制會影響影像匯出？**

渲染功能在[有效授權](/slides/zh-hant/python-java/licensing/)下皆可完整使用。在評估模式下，輸出可能會有浮水印等限制。請在執行批次匯出前於每個行程中一次性啟用授權。