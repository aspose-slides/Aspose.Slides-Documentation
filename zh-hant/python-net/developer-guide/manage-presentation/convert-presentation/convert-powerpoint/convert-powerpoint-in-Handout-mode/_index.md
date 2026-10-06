---
title: 使用 Python 於講義模式轉換簡報
linktitle: 講義模式
type: docs
weight: 150
url: /zh-hant/python-net/convert-powerpoint-in-handout-mode/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 講義模式
- 講義
- PowerPoint
- 簡報
- PPT
- PPTX
- Python
- Aspose.Slides
description: "使用 Python 將簡報轉換為講義。設定每頁投影片數量、保留備註，使用 Aspose.Slides 匯出為 PDF 或影像，並提供範例程式碼。立即免費體驗。"
---
## **簡介**

Aspose.Slides 提供將簡報轉換為各種格式的功能，包括在 Handout 模式下建立列印用的講義。此模式讓您設定多張投影片如何顯示在同一頁上，適用於會議、研討會及其他活動。您可以在 [PdfOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/pdfoptions/)、[RenderingOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/renderingoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/htmloptions/) 與 [TiffOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/tiffoptions/) 類別中設定 `slides_layout_options` 屬性來啟用此模式。

若要在匯出前設定講義頁面的尺寸與方向，請參閱 [Notes Page Size](/slides/zh-hant/python-net/notes-size/)。

## **講義模式匯出**

若要設定 Handout 模式，請使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/handoutlayoutingoptions/) 物件，它決定單頁上放置多少張投影片以及其他顯示參數。

以下程式碼範例說明如何在 Handout 模式下將簡報轉換為 PDF。

```py
import aspose.slides as slides

# 載入簡報。
with slides.Presentation("sample.pptx") as presentation:

    # 設定匯出選項。
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 每頁水平排列 4 張投影片
    slides_layout_options.print_slide_numbers = True                                 # 列印投影片編號
    slides_layout_options.print_frame_slide = True                                   # 在投影片周圍列印框線
    slides_layout_options.print_comments = False                                     # 沒有備註

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # 使用選定的版面配置將簡報匯出為 PDF。
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" title="Warning" %}}
請注意，`slides_layout_options` 屬性僅適用於某些輸出格式，例如 PDF、HTML、TIFF，以及以影像方式渲染時。
{{% /alert %}} 

## **常見問答**

**在 Handout 模式下，每頁最多可以顯示多少張投影片縮圖？**

Aspose.Slides 支援最多 9 張縮圖的[預設配置](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/handouttype/)，可水平或垂直排列：1、2、3、4（水平/垂直）、6（水平/垂直）以及 9（水平/垂直）。

**我可以自訂格線，例如每頁 5 或 8 張投影片嗎？**

不行。縮圖的數量與排列方式嚴格受 [HandoutType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/handouttype/) 列舉限制；不支援任意佈局。

**我可以在 Handout 輸出中包含隱藏的投影片嗎？**

可以。只要在目標格式的匯出設定中啟用 `show_hidden_slides` 選項，例如 [PdfOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/htmloptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/tiffoptions/)。