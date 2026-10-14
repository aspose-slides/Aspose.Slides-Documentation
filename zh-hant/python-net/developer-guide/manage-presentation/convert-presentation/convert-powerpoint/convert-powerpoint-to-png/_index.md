---
title: 在 Python 中將 PowerPoint 投影片轉換為 PNG
linktitle: PowerPoint 轉 PNG
type: docs
weight: 30
url: /zh-hant/python-net/convert-powerpoint-to-png/
keywords:
- 將 PowerPoint 轉換為 PNG
- 將簡報轉換為 PNG
- 将投影片转换为 PNG
- 将 PPT 转换为 PNG
- 将 PPTX 转换为 PNG
- 将 ODP 转换为 PNG
- PowerPoint 轉 PNG
- 簡報轉 PNG
- 投影片轉 PNG
- PPT 轉 PNG
- PPTX 轉 PNG
- ODP 轉 PNG
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET，快速將 PowerPoint 與 OpenDocument 簡報轉換為高品質 PNG 圖像，確保精確且自動化的結果。"
---
## **概觀**

本文章說明如何使用 Aspose.Slides for Python via .NET 將簡報投影片轉換為 PNG 圖像。您可以載入 PPT、PPTX 和 ODP 等格式的簡報，呈現每張投影片，並將其儲存為單獨的 PNG 圖片。以下範例示範在預設比例、放大比例、以像素指定輸出尺寸，以及選擇漸層呈現樣式時的渲染方式。

## **將 PowerPoint 轉換為 PNG**

使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別載入簡報，並透過 [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) 集合存取投影片。範例使用不帶參數的 [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) 來渲染每張投影片以建立縮圖。接著呼叫 [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) 並傳入 [ImageFormat.PNG](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) 以將每張渲染的投影片儲存為 PNG 圖像。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert color="info" title="Note" %}}
不帶參數的 [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) 重載會以 0.2 的比例渲染。例如，測量為 720 × 540 點的投影片會產生 144 × 108 像素的縮圖。若要控制輸出尺寸，請使用具有比例因子或以下示範之明確影像大小的重載。
{{% /alert %}}

## **將 PowerPoint 轉換為 PNG（自訂尺寸）**

將水平與垂直比例因子傳遞給 [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) 以控制渲染尺寸。在此範例中，兩個因子皆為 2，因此測量為 720 × 540 點的投影片會產生 1440 × 1080 像素的影像。相等的比例因子會保留投影片的長寬比。每張影像皆使用 [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) 以 PNG 格式儲存。

```python
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **將 PowerPoint 轉換為 PNG（自訂大小）**

若要以像素指定輸出尺寸，請傳遞尺寸給 [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) 而非比例因子。此範例將每張投影片渲染為 960 × 720 像素，並使用 [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) 儲存結果。請選擇與投影片長寬比相符的尺寸，以免影像被拉伸。

```python
import aspose.slides as slides

image_size = slides.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(image_size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **選擇漸層呈現樣式**

假設投影片包含漸層填色，但匯出的 PNG 中的過渡顏色看起來較淡或與 PowerPoint 中顯示的不同。您可以使用 [gradient_style](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/gradient_style/) 屬性搭配 [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) 來選擇漸層的呈現方式。下載 [gradient-styles.pptx](gradient-styles.pptx) 並將其放置於應用程式的工作目錄。其第一張投影片包含兩個線性漸層：上方由青色至橙色，下方由藍色至黃色。每個漸層都有兩個停點，分別在 0% 與 100%。以下範例載入此簡報，並使用 [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) 於兩種模式下渲染相同的第一張投影片。

```python
import aspose.slides as slides

with slides.Presentation("gradient-styles.pptx") as presentation:
    slide = presentation.slides[0]

    gradient_styles = [slides.GradientStyle.DEFAULT, slides.GradientStyle.POWER_POINT_UI]
    for style in gradient_styles:
        options = slides.export.RenderingOptions()
        options.gradient_style = style

        with slide.get_image(options, 1.0, 1.0) as image:
            image.save(f"gradient-{style.name}.png", slides.ImageFormat.PNG)
```

以下影像顯示同一張投影片的輸出，其中每張圖像都包含兩種漸層：

| 預設 | PowerPointUI |
| --- | --- |
| ![以預設方式呈現的青色至橙色與藍色至黃色漸層](gradient-Default.png) | ![以 PowerPointUI 方式呈現的相同漸層](gradient-PowerPointUI.png) |

在此範例中，`DEFAULT` 產生較淡的中間色彩，而 `POWER_POINT_UI` 產生較暗的中間色彩。差異取決於漸層的顏色與停點。當標準 Aspose.Slides 輸出符合需求時，請選擇 `DEFAULT`。若您的優先考量是與 PowerPoint 外觀相符，請嘗試 `POWER_POINT_UI`。將兩種輸出與預期結果比較；沒有哪一種模式是普遍最佳的。

## **常見問題**

**如何匯出特定形狀（例如圖表或圖片），而不是整張投影片？**  
Aspose.Slides 支援[為個別形狀產生縮圖](/slides/zh-hant/python-net/create-shape-thumbnails/)，讓您能將形狀以 PNG 影像呈現。

**伺服器上是否支援平行轉換？**  
是的。每個執行緒或行程使用獨立的簡報實例；[不要在執行緒間共享同一個實例](/slides/zh-hant/python-net/multithreading/)。

**匯出為 PNG 時的評估模式限制是什麼？**  
評估模式會在輸出影像上加入浮水印，並套用[其他限制](/slides/zh-hant/python-net/licensing/)，直到套用授權為止。