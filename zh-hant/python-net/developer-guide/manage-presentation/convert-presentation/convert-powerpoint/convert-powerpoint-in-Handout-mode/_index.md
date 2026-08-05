---
title: 使用 Python 以講義模式轉換簡報
linktitle: 講義模式
type: docs
weight: 150
url: /zh-hant/python-net/convert-powerpoint-in-handout-mode/
keywords:
- 轉換 PowerPoint
- 轉換 簡報
- 講義模式
- 講義
- PowerPoint
- 簡報
- PPT
- PPTX
- Python
- Aspose.Slides
description: "在 Python 中將簡報轉換為講義。設定每頁投影片數量、保留備註，使用 Aspose.Slides 匯出為 PDF 或影像，並提供示範程式碼。免費試用。"
---
## **簡介**

Aspose.Slides 提供將簡報轉換為各種格式的功能，亦包括以講義模式列印的講義。此模式允許您設定多張投影片在同一頁上的顯示方式，適用於會議、研討會等場合。您可以透過在 [PdfOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/pdfoptions/)、[RenderingOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/renderingoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/htmloptions/) 與 [TiffOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/tiffoptions/) 類別中設定 `slides_layout_options` 屬性來啟用此模式。

## **講義模式匯出**

若要設定講義模式，請使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/handoutlayoutingoptions/) 物件，它決定每頁放置的投影片數量以及其他顯示參數。

以下為示範程式碼，展示如何在講義模式下將簡報轉換為 PDF。

```py
# 載入簡報。
with slides.Presentation("sample.pptx") as presentation:

    # 設定匯出選項。
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 每頁水平排列 4 張投影片
    slides_layout_options.print_slide_numbers = True                                 # 列印投影片編號
    slides_layout_options.print_frame_slide = True                                   # 在投影片周圍列印框線
    slides_layout_options.print_comments = False                                     # 無備註

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # 以選擇的版面配置將簡報匯出為 PDF。
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" %}} 
請注意，`slides_layout_options` 屬性僅在某些輸出格式中可用，例如 PDF、HTML、TIFF，或以圖像方式渲染時。
{{% /alert %}} 

## **常見問題**

**在講義模式下，每頁最多可以顯示多少張投影片縮圖？**

Aspose.Slides 支援的 [presets](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/handouttype/) 最多可在每頁顯示 9 張縮圖，且可水平或垂直排列：1、2、3、4（水平/垂直）、6（水平/垂直）以及 9（水平/垂直）。

**我可以自訂格線，例如每頁 5 張或 8 張投影片嗎？**

不行。縮圖的數量與排列方式嚴格受 [HandoutType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/handouttype/) 列舉值控制，不支援任意版面配置。

**我可以在講義輸出中包含隱藏的投影片嗎？**

可以。請在目標格式的匯出設定（例如 [PdfOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/htmloptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/tiffoptions/)）中啟用 `show_hidden_slides` 選項。