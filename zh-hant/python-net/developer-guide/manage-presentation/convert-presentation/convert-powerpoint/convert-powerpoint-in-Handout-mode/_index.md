---
title: 使用 Python 於講義模式轉換簡報
linktitle: 講義模式
type: docs
weight: 150
url: /zh-hant/python-net/convert-powerpoint-in-Handout-mode/
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
description: "在 Python 中將簡報轉換為講義。設定每頁投影片數量、保留備註，並使用 Aspose.Slides 匯出為 PDF 或圖像，提供範例程式碼。免費試用。"
---
## **簡介**

Aspose.Slides 提供將簡報轉換為各種格式的功能，亦可在 Handout 模式下建立可列印的講義。此模式允許您設定多張投影片在單一頁面上的排列方式，對於會議、研討會及其他活動非常實用。您可透過在 [PdfOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/htmloptions/), 以及 [TiffOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/tiffoptions/) 類別中設定 `slides_layout_options` 屬性來啟用此模式。

## **講義模式匯出**

若要設定講義模式，請使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/handoutlayoutingoptions/) 物件，它決定單一頁面上放置的投影片數量及其他顯示參數。

以下示範程式碼說明如何在講義模式下將簡報轉換為 PDF。

```py
# 載入簡報。
with slides.Presentation("sample.pptx") as presentation:

    # 設定匯出選項。
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 每頁水平顯示 4 張投影片
    slides_layout_options.print_slide_numbers = True                                 # 列印投影片編號
    slides_layout_options.print_frame_slide = True                                   # 在投影片周圍列印框線
    slides_layout_options.print_comments = False                                     # 不列印備註

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # 依選定的版面配置將簡報匯出為 PDF。
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" %}} 
請記住，`slides_layout_options` 屬性僅在特定輸出格式（如 PDF、HTML、TIFF）以及以圖像方式渲染時可用。
{{% /alert %}} 

## **常見問題**

**在 Handout 模式下，每頁最多可顯示多少張投影片縮圖？**

Aspose.Slides 支援 [presets](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/handouttype/)，每頁最多可放置 9 張縮圖，且可水平或垂直排列：1、2、3、4（水平/垂直）、6（水平/垂直）以及 9（水平/垂直）。

**我可以自訂格線，例如每頁 5 或 8 張投影片嗎？**

不行。縮圖的數量與排列方式由 [HandoutType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/handouttype/) 列舉嚴格控制；不支援任意版面配置。

**我可以在講義輸出中包含隱藏的投影片嗎？**

可以。請在目標格式的匯出設定中啟用 `show_hidden_slides` 選項，例如 [PdfOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/htmloptions/), 或 [TiffOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/tiffoptions/).