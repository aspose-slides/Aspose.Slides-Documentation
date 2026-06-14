---
title: 在 Python 中將 PowerPoint 投影片轉換為圖像
linktitle: 投影片轉圖像
type: docs
weight: 41
url: /zh-hant/python-net/convert-slide/
keywords:
- 轉換投影片
- 將投影片轉換為圖像
- 將投影片匯出為圖像
- 將投影片儲存為圖像
- 投影片轉圖像
- 投影片轉 PNG
- 投影片轉 JPEG
- 投影片轉位圖
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 將 PowerPoint 與 OpenDocument 投影片轉換為多種格式。輕鬆將 PPTX 與 ODP 投影片匯出為 BMP、PNG、JPEG、TIFF 等高品質影像。"
---
## **簡介**

Aspose.Slides for Python via .NET 讓您輕鬆將 PowerPoint 和 OpenDocument 簡報投影片轉換為各種影像格式，包括 BMP、PNG、JPG（JPEG）、GIF 等。

若要將投影片轉換為影像，請遵循以下步驟：

1. 使用以下方式定義所需的轉換設定並選取要匯出的投影片：
    - 使用 [TiffOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/tiffoptions/) 類別，或
    - 使用 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/renderingoptions/) 類別。
2. 透過呼叫 [Slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/) 類別的 `get_image` 方法產生投影片影像。

在 Aspose.Slides for Python via .NET 中，[IImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/) 是一個允許您處理由像素資料定義的影像的類別。您可以使用此類別的實例將影像儲存為多種格式（BMP、JPG、PNG 等）。

## **將投影片轉換為位圖並以 PNG 儲存影像**

您可以將投影片轉換為位圖物件，直接在應用程式中使用。或者，您也可以先將投影片轉換為位圖，再將影像儲存為 JPEG 或其他您偏好的格式。

以下 Python 程式碼示範如何將簡報的第一張投影片轉換為位圖物件，並以 PNG 格式儲存影像：

```py 
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    # 將簡報中的第一張投影片轉換為位圖。
    with presentation.slides[0].get_image() as image:
        # 以 PNG 格式儲存影像。
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **將投影片轉換為自訂尺寸的影像**

您可能需要取得特定尺寸的影像。使用 [get_image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) 的重載，您可以將投影片轉換為具有特定寬度和高度的影像。

以下範例程式碼示範如何執行此操作：

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    # 將簡報中的第一張投影片以指定尺寸轉換為位圖。
    with presentation.slides[0].get_image(image_size) as image:
        # 以 JPEG 格式儲存影像。
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **將含備註與評論的投影片轉換為影像**

某些投影片可能包含備註與評論。

Aspose.Slides 提供兩個類別——[TiffOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/tiffoptions/) 與 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/renderingoptions/)——讓您能控制將簡報投影片渲染為影像的方式。兩個類別皆具備 `slides_layout_options` 屬性，可在將投影片轉換為影像時設定備註與評論的渲染方式。

使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/notescommentslayoutingoptions/) 類別，您可以指定備註與評論在最終影像中的首選位置。

以下 Python 程式碼示範如何將含備註與評論的投影片轉換為影像：

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    notes_comments_options = slides.export.NotesCommentsLayoutingOptions()
    notes_comments_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED  # 設定備註的位置。
    notes_comments_options.comments_position = slides.export.CommentsPositions.RIGHT       # 設定評論的位置。
    notes_comments_options.comments_area_width = 500                                       # 設定評論區域的寬度。
    notes_comments_options.comments_area_color = draw.Color.antique_white                  # 設定評論區域的顏色。

    # 建立渲染選項。
    options = slides.export.RenderingOptions()
    options.slides_layout_options = notes_comments_options

    # 將簡報的第一張投影片轉換為影像。
    with presentation.slides[0].get_image(options, scale_x, scale_y) as image:
        # 以 GIF 格式儲存影像。
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Note" color="warning" %}} 
在任何投影片轉影像的轉換過程中，無法將 [notes_position](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) 屬性設為 `BOTTOM_FULL`（用於指定備註位置），因為備註的文字可能過長，導致無法符合指定的影像尺寸。
{{% /alert %}} 

## **使用 TIFF 選項將投影片轉換為影像**

[TiffOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/tiffoptions/) 類別提供更大的控制權，讓您能指定大小、解析度、色彩調色盤等參數，以掌握最終 TIFF 影像。

以下 Python 程式碼示範使用 TIFF 選項輸出 300 DPI 解析度、尺寸為 2160 × 2800 的黑白影像的轉換過程：

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

# 載入簡報檔案。
with slides.Presentation("sample.pptx") as presentation:
    # 從簡報中取得第一張投影片。
    slide = presentation.slides[0]

    # 設定輸出 TIFF 圖像的參數。
    options = slides.export.TiffOptions()
    options.image_size = draw.Size(2160, 2880)                                 # 設定圖像大小。
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED  # 設定像素格式（黑白）。
    options.dpi_x = 300                                                        # 設定水平解析度。
    options.dpi_y = 300                                                        # 設定垂直解析度。

    # 使用指定的選項將投影片轉換為圖像。
    with slide.get_image(options) as image:
        # 以 TIFF 格式儲存圖像。
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **將所有投影片轉換為影像**

Aspose.Slides 讓您能將簡報中的所有投影片轉換為影像，實際上將整個簡報轉換為一系列影像。

以下範例程式碼示範如何在 Python 中將簡報的所有投影片轉換為影像：

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    # 逐張投影片將簡報渲染為圖像。
    for i, slide in enumerate(presentation.slides):
        # 控制隱藏投影片（不渲染隱藏的投影片）。
        if slide.hidden:
            continue

        # 將投影片轉換為圖像。
        with slide.get_image(scale_x, scale_y) as image:
            # 以 JPEG 格式儲存圖像。
            image.save("Slide_{0}.jpg".format(i), slides.ImageFormat.JPEG)
```

## **常見問題**

**Aspose.Slides 支援渲染帶有動畫的投影片嗎？**  
不會，`get_image` 方法僅會儲存投影片的靜態影像，並不包含動畫。

**隱藏的投影片可以匯出為影像嗎？**  
可以，隱藏的投影片可以像一般投影片一樣處理。只需確保它們已被納入處理迴圈即可。

**影像能夠儲存陰影和效果嗎？**  
可以，Aspose.Slides 在將投影片儲存為影像時支援渲染陰影、透明度及其他圖形效果。