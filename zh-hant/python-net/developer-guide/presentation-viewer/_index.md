---
title: 在 Python 中建立簡報檢視器
linktitle: 簡報檢視器
type: docs
weight: 50
url: /zh-hant/python-net/presentation-viewer/
keywords: 
- 檢視簡報
- 簡報檢視器
- 建立簡報檢視器
- 檢視 PPT
- 檢視 PPTX
- 檢視 ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 Python 中建立自訂簡報檢視器。輕鬆顯示 PowerPoint (PPTX、PPT) 和 OpenDocument (ODP) 檔案，無需 Microsoft PowerPoint 或其他辦公軟體。"
---
## **簡介**

Aspose.Slides for Python 用於建立包含投影片的簡報檔案。這些投影片可以透過在 Microsoft PowerPoint 等程式中開啟簡報來檢視。然而，開發人員有時可能需要在喜好的圖片檢視器中將投影片視為影像，或在自訂的簡報檢視器中使用它們。在此情況下，Aspose.Slides 允許您將單一投影片匯出為影像。本文將說明如何完成此操作。

## **從投影片產生 SVG 影像**

要使用 Aspose.Slides 從簡報投影片產生 SVG 影像，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
2. 依索引取得投影片的參照。  
3. 開啟檔案串流。  
4. 將投影片儲存為 SVG 影像至檔案串流。

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```

## **建立投影片縮圖影像**

Aspose.Slides 幫助您產生投影片的縮圖影像。要使用 Aspose.Slides 產生投影片縮圖，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
2. 依索引取得投影片的參照。  
3. 依所需比例產生參照投影片的縮圖影像。  
4. 以您偏好的影像格式儲存縮圖影像。

```py
import aspose.slides as slides

slide_index = 0
scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(scale_x, scale_y) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **建立自訂尺寸的投影片縮圖**

要建立具有使用者自訂尺寸的投影片縮圖影像，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
2. 依索引取得投影片的參照。  
3. 依指定尺寸產生參照投影片的縮圖影像。  
4. 以您偏好的影像格式儲存縮圖影像。

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

slide_index = 0
slide_size = pydrawing.Size(1200, 800)

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(slide_size) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **建立包含講者備註的投影片縮圖**

要使用 Aspose.Slides 產生包含講者備註的投影片縮圖，請依照以下步驟操作：

1. 建立 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/renderingoptions/) 類別的實例。  
2. 使用 `RenderingOptions.slides_layout_options` 屬性設定講者備註的位置。  
3. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
4. 依索引取得投影片的參照。  
5. 使用渲染選項產生參照投影片的縮圖影像。  
6. 以您偏好的影像格式儲存縮圖影像。

```py
slide_index = 0

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(rendering_options) as image:
        image.save("output.png", slides.ImageFormat.PNG)
```

## **即時範例**

試用免費的 [**Aspose.Slides Viewer**](https://products.aspose.app/slides/zh-hant/viewer/) 應用程式，了解您可使用 Aspose.Slides API 實作的功能：

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/zh-hant/viewer/)

## **常見問題**

**我可以在 ASP.NET 網頁應用程式中嵌入簡報檢視器嗎？**

是的。您可以在伺服器端使用 Aspose.Slides 將投影片渲染為 [images](/slides/zh-hant/python-net/convert-powerpoint-to-png/) 或 [HTML](/slides/zh-hant/python-net/convert-powerpoint-to-html/) 並在瀏覽器中顯示。導覽與縮放功能可透過 JavaScript 實作，以提供互動體驗。

**在自訂的 .NET 檢視器中顯示投影片的最佳方法是什麼？**

建議的做法是使用 Aspose.Slides 將每張投影片渲染為 [image](/slides/zh-hant/python-net/convert-powerpoint-to-png/)（例如 PNG 或 SVG）或轉換成 [HTML](/slides/zh-hant/python-net/convert-powerpoint-to-html/)，再將輸出顯示於 picture box（桌面應用）或 HTML 容器（網頁）中。

**我該如何處理包含大量投影片的巨型簡報？**

對於大型簡報，建議使用延遲載入或按需渲染投影片的方式。即僅在使用者切換至該投影片時才產生其內容，以降低記憶體使用與載入時間。