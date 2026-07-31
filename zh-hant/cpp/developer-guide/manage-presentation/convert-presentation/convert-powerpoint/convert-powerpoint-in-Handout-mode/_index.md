---
title: 使用 C++ 於講義模式轉換 PowerPoint 簡報
linktitle: 講義模式
type: docs
weight: 150
url: /zh-hant/cpp/convert-powerpoint-in-handout-mode/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 講義模式
- 講義
- PPT
- PPTX
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 C++ 將簡報轉換為講義。設定每頁投影片數量、保留備註，並使用 Aspose.Slides 匯出為 PDF 或影像，附有範例程式碼。免費試用。"
---
## **簡介**

Aspose.Slides 提供將簡報轉換為各種格式的功能，亦支援以 **Handout** 模式建立列印講義。此模式讓您設定多張投影片在同一頁上呈現的方式，非常適合會議、研討會與其他活動。您可透過在 [IPdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/ihtmloptions/)、[ITiffOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/itiffoptions/) 介面中設定 `set_SlidesLayoutOptions` 方法來啟用此模式。

## **Handout 模式匯出**

若要設定 Handout 模式，請使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/handoutlayoutingoptions/) 物件，它決定每頁放置多少張投影片以及其他顯示參數。

以下範例示範如何在 Handout 模式下將簡報轉換為 PDF。

```cpp
// 載入簡報。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 設定匯出選項。
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 每頁水平排列四張投影片
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // 列印投影片編號
slidesLayoutOptions->set_PrintFrameSlide(true);                      // 在投影片周圍列印框線
slidesLayoutOptions->set_PrintComments(false);                       // 不列印註解

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// 以選定的版面配置將簡報匯出為 PDF。
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
請注意，`set_SlidesLayoutOptions` 方法僅在特定輸出格式（例如 PDF、HTML、TIFF，或以影像方式呈現）中可用。 
{{% /alert %}} 

## **常見問題**

**在 Handout 模式下，每頁最大可顯示多少張投影片縮圖？**

Aspose.Slides 支援的 [presets](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/handouttype/) 最多可在每頁顯示 9 張縮圖，且支援水平或垂直排列：1、2、3、4（水平/垂直）、6（水平/垂直）以及 9（水平/垂直）。

**我能定義自訂的格線，例如每頁 5 張或 8 張投影片嗎？**

不能。縮圖的數量與排列方式嚴格受 [HandoutType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/handouttype/) 列舉控制；不支援任意版面配置。

**我能在 Handout 輸出中包含隱藏的投影片嗎？**

可以。請在目標格式的匯出設定（如 [PdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/htmloptions/)、[TiffOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/tiffoptions/)）中使用 `set_ShowHiddenSlides` 方法。