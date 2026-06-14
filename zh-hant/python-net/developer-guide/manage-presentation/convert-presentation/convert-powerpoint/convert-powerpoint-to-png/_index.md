---
title: 在 Python 中將 PowerPoint 投影片轉換為 PNG
linktitle: 投影片轉 PNG
type: docs
weight: 30
url: /zh-hant/python-net/convert-powerpoint-to-png/
keywords:
- 將 PowerPoint 轉換為 PNG
- 將簡報轉換為 PNG
- 將投影片轉換為 PNG
- 將 PPT 轉換為 PNG
- 將 PPTX 轉換為 PNG
- 將 ODP 轉換為 PNG
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

Aspose.Slides for Python via .NET 讓將 PowerPoint 簡報轉換為 PNG 變得非常簡單。您可以載入簡報，遍歷其投影片，將每張投影片渲染為點陣圖，並將結果儲存為 PNG 檔案。這非常適合產生投影片預覽、在網頁中嵌入投影片，或產出供後續處理使用的靜態資產。

## **將投影片轉換為 PNG**

本節展示了使用 Aspose.Slides for Python via .NET 將 PowerPoint 簡報轉換為 PNG 圖像的最簡單範例。

請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 從 `Presentation.slides` 集合取得投影片（請參閱 [Slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/) 類別）。
3. 使用 `Slide.get_image` 方法產生投影片的縮圖。
4. 使用 `Presentation.save` 方法將投影片縮圖以 PNG 格式儲存。

以下 Python 程式碼示範如何將 PowerPoint 簡報轉換為 PNG：

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **使用自訂維度將投影片轉換為 PNG**

若要以自訂比例匯出投影片為 PNG，請在呼叫 `Slide.get_image` 時提供水平與垂直的比例因子。這些倍數會相對於投影片的原始尺寸調整輸出；例如，`2.0` 會將寬度與高度皆加倍。使用相同的 `scale_x` 與 `scale_y` 值即可保持長寬比。

以下 Python 程式碼示範上述操作：

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **使用自訂大小將投影片轉換為 PNG**

若您想以特定大小產生 PNG 檔案，請傳入所需的 `width` 與 `height` 值。以下程式碼示範了在指定影像大小的情況下將 PowerPoint 轉換為 PNG：

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

size = drawing.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert title="Tip" color="primary" %}}
您可能想試試 Aspose 提供的免費 **PowerPoint-to-PNG 轉換器**——[PPTX to PNG](https://products.aspose.app/slides/zh-hant/conversion/pptx-to-png) 與 [PPT to PNG](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-png)。它們提供了本頁面所述流程的即時實作。
{{% /alert %}}

## **常見問題**

**如何僅匯出特定形狀（例如圖表或圖片）而非整張投影片？**  
Aspose.Slides 支援 [為單一形狀生成縮圖](/slides/zh-hant/python-net/create-shape-thumbnails/)，您可以將形狀渲染為 PNG 影像。

**伺服器上是否支援平行轉換？**  
是的，但請 [不要在多執行緒間共享](/slides/zh-hant/python-net/multithreading/) 同一個 Presentation 實例。每個執行緒或程序應使用獨立的實例。

**在匯出為 PNG 時，試用版有哪些限制？**  
評估模式會在輸出影像上加上浮水印，且在套用授權之前會套用 [其他限制](/slides/zh-hant/python-net/licensing/)。