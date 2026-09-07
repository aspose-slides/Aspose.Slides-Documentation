---
title: 在 Python 中將 PowerPoint 投影片轉換為 PNG
linktitle: PowerPoint 轉 PNG
type: docs
weight: 30
url: /zh-hant/python-java/convert-powerpoint-to-png/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 PNG
- 簡報 轉 PNG
- 投影片 轉 PNG
- PPT 轉 PNG
- PPTX 轉 PNG
- 將 PPT 儲存為 PNG
- 將 PPTX 儲存為 PNG
- 匯出 PPT 為 PNG
- 匯出 PPTX 為 PNG
- Python
- Java
- Aspose.Slides
description: "在 Python（透過 Java）中將 PowerPoint 投影片匯出為 PNG 影像。支援自訂比例或精確影像尺寸的 PPT、PPTX 與 ODP 簡報匯出。"
---
## **概觀**

本文說明如何使用 Aspose.Slides for Python via Java 將 PowerPoint 簡報轉換為 PNG 圖像。您可以載入 PPT、PPTX 與 ODP 檔案，將每張投影片渲染，並將其儲存為單獨的 PNG 圖像。範例亦說明如何透過比例因子或精確的寬度與高度來控制輸出尺寸。每個範例會在需要時啟動 Java 虛擬機，並在使用後釋放簡報與影像資源。

## **將 PowerPoint 轉換為 PNG**

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別載入輸入檔案。
2. 使用 [Presentation.getSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSlides) 取得投影片。
3. 使用 [Slide.getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getImage) 渲染每張投影片。
4. 使用 [ImageFormat.Png](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imageformat/#Png) 儲存每個渲染後的影像，然後釋放其資源。

以下 Python 範例會以預設大小匯出所有投影片：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage()
        try:
            slide_image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **使用自訂比例將 PowerPoint 轉換為 PNG**

將水平與垂直比例因子傳遞給 [Slide.getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getImage) 以增減輸出尺寸。例如，使用比例因子 2 於兩個軸向渲染 720 × 540 點的投影片，會產生 1440 × 1080 像素的影像。使用相等的比例因子可保留投影片的長寬比。不同的因子會水平或垂直拉伸投影片。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = 2.0
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"slide_scaled_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **使用自訂尺寸將 PowerPoint 轉換為 PNG**

若要指定精確的像素尺寸，請將具有目標寬度與高度的 Java `Dimension` 物件傳遞給 [Slide.getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getImage)。選擇與來源投影片相同長寬比的尺寸，以避免變形。以下範例會將每張投影片儲存為 960 × 720 像素的 PNG 影像：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(image_size)
        try:
            slide_image.save(f"slide_sized_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **常見問題**

**我可以匯出個別的圖形，例如圖表或圖片，而不是整張投影片嗎？**

可以。Aspose.Slides 支援[為個別圖形產生縮圖](/slides/zh-hant/python-java/create-shape-thumbnails/)，您可以將其儲存為 PNG 影像。

**我可以在伺服器上平行轉換簡報嗎？**

為每個執行緒或行程使用獨立的 Presentation 實例，並使用唯一的輸出路徑以避免檔案被覆寫。不要在執行緒間共享同一個 Presentation 實例。請參閱 [Multithreading](/slides/zh-hant/python-java/multithreading/)。

**在匯出 PNG 時，試用版有哪些限制？**

評估模式會在輸出影像上加上浮水印，並套用[其他限制](/slides/zh-hant/python-java/licensing/)。套用授權即可移除這些限制。