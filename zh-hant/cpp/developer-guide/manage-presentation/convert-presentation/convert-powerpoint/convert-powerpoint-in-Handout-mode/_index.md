---
title: 使用 C++ 於講義模式轉換 PowerPoint 簡報
linktitle: 講義模式
type: docs
weight: 150
url: /zh-hant/cpp/convert-powerpoint-in-Handout-mode/
keywords:
- 轉換 PowerPoint
- 轉換 簡報
- 講義模式
- 講義
- PPT
- PPTX
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 C++ 將簡報轉換為講義。設定每頁投影片數量、保留備註，並使用 Aspose.Slides 匯出為 PDF 或影像，附帶範例程式碼。立即免費試用。"
---
## **Introduction**

Aspose.Slides 提供將簡報轉換為各種格式的功能，包括在講義模式下製作可列印的講義。此模式允許您設定多張投影片如何顯示在同一頁面上，對於會議、研討會及其他活動相當有用。您可以透過在 [IPdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/ihtmloptions/) 與 [ITiffOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/itiffoptions/) 介面中設定 `set_SlidesLayoutOptions` 方法來啟用此模式。

## **Handout Mode Export**

若要設定講義模式，請使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/handoutlayoutingoptions/) 物件，該物件決定單頁上放置的投影片數量以及其他顯示參數。

以下程式碼範例示範如何在講義模式下將簡報轉換為 PDF。

```cpp
// 載入簡報。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 設定匯出選項。
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 每頁水平排列 4 張投影片
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // 列印投影片編號
slidesLayoutOptions->set_PrintFrameSlide(true);                      // 為投影片列印邊框
slidesLayoutOptions->set_PrintComments(false);                       // 不列印註解

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// 使用選定的版面配置將簡報匯出為 PDF。
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
請注意，`set_SlidesLayoutOptions` 方法僅在特定的輸出格式中可用，例如 PDF、HTML、TIFF，或以影像方式渲染時。
{{% /alert %}} 

## **FAQ**

**在講義模式下，每頁最多可顯示多少張投影片縮圖？**

Aspose.Slides 支援的 [presets](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/handouttype/) 最多可在每頁顯示 9 張縮圖，且可採水平或垂直排序：1、2、3、4（水平/垂直）、6（水平/垂直）以及 9（水平/垂直）。

**我可以自訂格線，例如每頁 5 或 8 張投影片嗎？**

不能。縮圖的數量與排序嚴格受 [HandoutType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/handouttype/) 列舉控制；不支援任意版面配置。

**我可以在講義輸出中包含隱藏的投影片嗎？**

可以。請在目標格式的匯出設定中使用 `set_ShowHiddenSlides` 方法，例如 [PdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/htmloptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/tiffoptions/)。