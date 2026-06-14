---
title: 在 Python 中將 PPT、PPTX 和 ODP 轉換為 JPG
linktitle: 將投影片轉換為 JPG 圖像
type: docs
weight: 60
url: /zh-hant/python-net/convert-powerpoint-to-jpg/
keywords:
- 將 PowerPoint 轉換為 JPG
- 將簡報轉換為 JPG
- 將投影片轉換為 JPG
- 將 PPT 轉換為 JPG
- 將 PPTX 轉換為 JPG
- 將 ODP 轉換為 JPG
- PowerPoint 轉換為 JPG
- 簡報轉換為 JPG
- 投影片轉換為 JPG
- PPT 轉換為 JPG
- PPTX 轉換為 JPG
- ODP 轉換為 JPG
- 將 PowerPoint 轉換為 JPEG
- 將簡報轉換為 JPEG
- 將投影片轉換為 JPEG
- 將 PPT 轉換為 JPEG
- 將 PPTX 轉換為 JPEG
- 將 ODP 轉換為 JPEG
- PowerPoint 轉換為 JPEG
- 簡報轉換為 JPEG
- 投影片轉換為 JPEG
- PPT 轉換為 JPEG
- PPTX 轉換為 JPEG
- ODP 轉換為 JPEG
- Python
- Aspose.Slides
description: "了解如何使用 Python 僅需幾行程式碼，將 PowerPoint 與 OpenDocument 簡報轉換為高品質 JPEG 圖像。優化簡報以供網站使用、分享與存檔。立即閱讀完整指南！"
---
## **簡介**

將 PowerPoint 和 OpenDocument 簡報轉換為 JPG 圖像有助於分享投影片、優化效能，以及將內容嵌入網站或應用程式。Aspose.Slides for Python 允許您將 PPTX、PPT 和 ODP 檔案轉換為高品質 JPEG 圖像。本指南說明各種轉換方法。

有了這些功能，您可以輕鬆實作自己的簡報檢視器，並為每張投影片建立縮圖。如果您想保護簡報投影片不被複製或以唯讀模式展示簡報，這將非常有用。Aspose.Slides 允許您將整個簡報或特定投影片轉換為圖像格式。

## **將簡報投影片轉換為 JPG 圖像**

以下是將 PPT、PPTX 或 ODP 檔案轉換為 JPG 的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
1. 從 [Presentation.slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/slides/zh-hant/) 集合取得 [Slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/) 類型的投影片物件。  
1. 使用 [Slide.get_image(scale_x,scale_y)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/get_image/#float-float) 方法建立投影片的圖像。  
1. 在圖像物件上呼叫 [IImage.save(filename,format)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/save/#str-imageformat) 方法，傳入輸出檔名和圖像格式作為參數。

{{% alert color="primary" %}}
**注意：** PPT、PPTX 或 ODP 轉換為 JPG 與 Aspose.Slides Python API 中轉換為其他格式不同。對於其他格式，您通常使用 [Presentation.save(fname,format,options)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions) 方法。然而，對於 JPG 轉換，必須使用 [IImage.save(filename,format)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/save/#str-imageformat) 方法。
{{% /alert %}}

```py
import aspose.slides as slides

scale_x = 1
scale_y = scale_x

with slides.Presentation("PowerPoint_Presentation.ppt") as presentation:
    for slide in presentation.slides:
        with slide.get_image(scale_x, scale_y) as thumbnail:
            # 將圖像以 JPEG 格式儲存至磁碟。
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```

## **將投影片轉換為具有自訂尺寸的 JPG**

若要變更產生的 JPG 圖像尺寸，可透過傳入 [Slide.get_image(image_size)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) 方法來設定圖像大小。這讓您能產生具有特定寬度和高度的圖像，確保輸出符合解析度和長寬比的需求。此彈性在為 Web 應用程式、報告或文件產生圖像時尤為有用，因為這些情境常需要精確的圖像尺寸。

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

image_size = pydrawing.Size(1200, 800)

with slides.Presentation("PowerPoint_Presentation.pptx") as presentation:
    for slide in presentation.slides:
        # 建立指定尺寸的投影片圖像。
        with slide.get_image(image_size) as thumbnail:
            # 將圖像以 JPEG 格式儲存至磁碟。
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```

## **在將投影片另存為圖像時呈現批註**

Aspose.Slides for Python 提供一項功能，可在將簡報投影片轉換為 JPG 圖像時呈現批註。此功能對於保留協作者在 PowerPoint 簡報中加入的註解、回饋或討論特別有用。啟用此選項後，批註會出現在生成的圖像中，讓您在不開啟原始簡報檔案的情況下，更容易檢視與分享回饋。

假設我們有一個簡報檔案「sample.pptx」，其中的某張投影片包含批註：

![The slide with comments](slide_with_comments.png)

以下 Python 程式碼在保留批註的同時將投影片轉換為 JPG 圖像：

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    # 設定投影片批註的選項。
    comments_options = slides.export.NotesCommentsLayoutingOptions()
    comments_options.comments_position = slides.export.CommentsPositions.RIGHT
    comments_options.comments_area_width = 200
    comments_options.comments_area_color = pydrawing.Color.dark_orange

    options = slides.export.RenderingOptions()
    options.slides_layout_options = comments_options

    # 將第一張投影片轉換為圖像。
    with presentation.slides[0].get_image(options, scale_x, scale_y) as thumbnail:
        thumbnail.save("Slide_1.jpg", slides.ImageFormat.JPEG)
```

結果：

![The JPG image with comments](image_with_comments.png)

## **另請參閱**

其他將 PPT、PPTX 或 ODP 轉換為圖像的選項，例如：

- [Convert PowerPoint to GIF](/slides/zh-hant/python-net/convert-powerpoint-to-animated-gif/)
- [Convert PowerPoint to PNG](/slides/zh-hant/python-net/convert-powerpoint-to-png/)
- [Convert PowerPoint to TIFF](/slides/zh-hant/python-net/convert-powerpoint-to-tiff/)
- [Convert PowerPoint to SVG](/slides/zh-hant/python-net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
要了解 Aspose.Slides 如何將 PowerPoint 轉換為 JPG 圖像，請試用以下免費線上轉換器：PowerPoint [PPTX to JPG](https://products.aspose.app/slides/zh-hant/conversion/pptx-to-jpg) 和 [PPT to JPG](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-jpg)。 
{{% /alert %}} 

![Free Online PPTX to JPG Converter](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}
Aspose 提供一個[免費的拼貼 Web 應用程式](https://products.aspose.app/slides/zh-hant/collage)。使用此線上服務，您可以合併 [JPG to JPG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG to PNG 圖像、建立[相片格子](https://products.aspose.app/slides/zh-hant/collage/photo-grid)等。 

依照本文描述的相同原理，您可以將圖像從一種格式轉換為另一種格式。更多資訊請參見以下頁面：轉換[image to JPG](https://products.aspose.com/slides/zh-hant/python-net/conversion/image-to-jpg/)；轉換[JPG to image](https://products.aspose.com/slides/zh-hant/python-net/conversion/jpg-to-image/)；轉換[JPG to PNG](https://products.aspose.com/slides/zh-hant/python-net/conversion/jpg-to-png/)；轉換[PNG to JPG](https://products.aspose.com/slides/zh-hant/python-net/conversion/png-to-jpg/)；轉換[PNG to SVG](https://products.aspose.com/slides/zh-hant/python-net/conversion/png-to-svg/)；轉換[SVG to PNG](https://products.aspose.com/slides/zh-hant/python-net/conversion/svg-to-png/)。
{{% /alert %}}

## **常見問題**

**此方法是否支援批次轉換？**

是的，Aspose.Slides 允許一次操作將多張投影片批次轉換為 JPG。

**轉換是否支援 SmartArt、圖表和其他複雜物件？**

是的，Aspose.Slides 會呈現所有內容，包括 SmartArt、圖表、表格、形狀等。然而，與 PowerPoint 相比，渲染精確度可能會因自訂或缺少的字型而略有差異。

**對可處理的投影片數量有任何限制嗎？**

Aspose.Slides 本身並未對可處理的投影片數量設定嚴格限制。但在處理大型簡報或高解析度圖像時，可能會遇到記憶體不足的錯誤。