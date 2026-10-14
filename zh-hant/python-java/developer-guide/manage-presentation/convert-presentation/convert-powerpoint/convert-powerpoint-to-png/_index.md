---
title: 在 Python 中將 PowerPoint 投影片轉換為 PNG
linktitle: PowerPoint 轉 PNG
type: docs
weight: 30
url: /zh-hant/python-java/convert-powerpoint-to-png/
keywords:
- 轉換 PowerPoint
- 轉換 簡報
- 轉換 投影片
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
description: "在 Python（透過 Java）中將 PowerPoint 投影片轉換為 PNG 圖像。以自訂比例或精確影像尺寸匯出 PPT、PPTX 與 ODP 簡報。"
---
## **概觀**

本文說明如何使用 Aspose.Slides for Python via Java 將簡報投影片轉換為 PNG 圖像。您可以載入 PPT、PPTX、ODP 等格式的簡報，渲染每張投影片，並將其另存為單獨的 PNG 圖像。

以下範例示範預設比例渲染、提升比例、以像素指定輸出尺寸，以及選擇漸層渲染樣式。

## **將 PowerPoint 轉換為 PNG**

使用 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 類別載入簡報，並透過 [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) 集合存取投影片。範例使用不帶參數的 [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) 來渲染每張投影片，以建立縮圖。接著呼叫 [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-)，並使用 [ImageFormat.Png](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/#Png) 將每個渲染後的投影片儲存為 PNG 圖像。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage()
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
不帶參數的 [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) 重載會以 0.2 的比例渲染。例如，測量為 720 × 540 點的投影片會產生 144 × 108 像素的縮圖。若要控制輸出尺寸，請使用下方示範的比例因子或明確的圖像大小重載。
{{% /alert %}}

## **將 PowerPoint 轉換為 PNG（自訂尺寸）**

將水平與垂直比例因子傳遞給 [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) 以控制渲染尺寸。在此範例中，兩個因子皆為 2，因​​此測量為 720 × 540 點的投影片會產生 1440 × 1080 像素的圖像。相同的比例因子會保留投影片的長寬比。每個渲染後的圖像皆以 PNG 格式儲存。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = scale_x

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **將 PowerPoint 轉換為 PNG（自訂大小）**

若要以像素指定輸出尺寸，請傳遞尺寸給 [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) 而非比例因子。此範例將每張投影片渲染為 960 × 720 像素，並以 PNG 格式儲存結果。請選擇與投影片長寬比相符的尺寸，以避免圖像拉伸。

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

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(image_size)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **選擇漸層渲染樣式**

假設投影片包含漸層填色，但匯出的 PNG 中的過渡色看起來較淡或與 PowerPoint 中不同。您可以使用由 [RenderingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/) 繼承的 [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setGradientStyle) 方法來選擇漸層的渲染方式。

下載 [gradient‑styles.pptx](gradient-styles.pptx) 並將其放在應用程式的工作目錄中。其第一張投影片包含兩個線性漸層：上部由青色到橙色，下部由藍色到黃色。每個漸層在 0% 與 100% 位置各有兩個色標。

以下範例載入此簡報，並使用 [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) 以兩種模式渲染同一張第一投影片。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GradientStyle, ImageFormat, Presentation, RenderingOptions

presentation = Presentation("gradient-styles.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    gradient_styles = (GradientStyle.Default, GradientStyle.PowerPointUI)
    for style in gradient_styles:
        options = RenderingOptions()
        options.setGradientStyle(style)

        style_name = "Default" if style == GradientStyle.Default else "PowerPointUI"
        image = slide.getImage(options, 1.0, 1.0)
        try:
            image.save(f"gradient-{style_name}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

下方圖像顯示同一張投影片的輸出結果，兩種模式各包含兩個漸層：

| 預設 | PowerPointUI |
| --- | --- |
| ![以預設模式渲染的青色‑到‑橙色與藍色‑到‑黃色漸層](gradient-Default.png) | ![以 PowerPointUI 模式渲染的相同漸層](gradient-PowerPointUI.png) |

在此範例中，`Default` 產生較亮的中間色，而 `PowerPointUI` 產生較暗的中間色。差異取決於漸層的顏色與色標。

當標準 Aspose.Slides 輸出符合需求時，請選擇 `Default`。若您的優先考量是與 PowerPoint 中的外觀相匹配，則使用 `PowerPointUI`。請將兩種輸出與您的預期結果進行比較；兩者皆無絕對優劣。

## **常見問題**

**如何匯出特定形狀（例如圖表或圖片），而不是整張投影片？**

Aspose.Slides 支援[為單一形狀產生縮圖](/slides/zh-hant/python-java/create-shape-thumbnails/)，讓您將形狀渲染為 PNG 圖像。

**伺服器上是否支援平行轉換？**

可以。為每個執行緒或行程使用獨立的簡報實例；[請勿在執行緒間共用單一實例](/slides/zh-hant/python-java/multithreading/)。

**匯出為 PNG 時評估版的限制是什麼？**

評估模式會在輸出圖像上加上浮水印，並在套用授權前套用[其他限制](/slides/zh-hant/python-java/licensing/)。