---
title: 使用 C++ 以講義模式轉換 PowerPoint 簡報
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
description: "使用 C++ 將簡報轉換為講義。設定每頁投影片數量，保留註解，使用 Aspose.Slides 匯出為 PDF 或影像，並提供範例程式碼。免費試用。"
---
## **Introduction**

Aspose.Slides 提供將簡報轉換為各種格式的功能，包含以講義模式列印的講義製作。此模式讓您設定多張投影片如何排列在同一頁面上，適合會議、研討會等場合使用。您可以透過在 [IPdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/ihtmloptions/)、以及 [ITiffOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/itiffoptions/) 介面中呼叫 `set_SlidesLayoutOptions` 方法來啟用此模式。

若要在匯出前設定講義頁面的尺寸與方向，請參閱 [Notes Page Size](/slides/zh-hant/cpp/notes-size/)。

## **Handout Mode Export**

要設定講義模式，請使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/handoutlayoutingoptions/) 物件，該物件決定單頁上的投影片數量及其他顯示參數。

以下程式碼示範如何在講義模式下將簡報轉換為 PDF。

```cpp
#include <DOM/Presentation.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 載入簡報。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 設定匯出選項。
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 每頁水平放置 4 張投影片
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // 列印投影片編號
slidesLayoutOptions->set_PrintFrameSlide(true);                      // 在投影片周圍列印框線
slidesLayoutOptions->set_PrintComments(false);                       // 不列印註解

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// 以選擇的版面配置將簡報匯出為 PDF。
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
請注意，`set_SlidesLayoutOptions` 方法僅在特定輸出格式（如 PDF、HTML、TIFF）以及以圖像方式呈現時可用。
{{% /alert %}} 

## **FAQ**

### What is the maximum number of slide thumbnails per page in Handout mode?

Aspose.Slides 支援的 [presets](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/handouttype/) 最多可在每頁顯示 9 個縮圖，且可依水平或垂直排序：1、2、3、4（水平/垂直）、6（水平/垂直）以及 9（水平/垂直）。

### Can I define a custom grid, such as 5 or 8 slides per page?

不支援。縮圖的數量與排序嚴格受 [HandoutType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/handouttype/) 列舉控制，無法使用自訂布局。

### Can I include hidden slides in the Handout output?

可以。請在目標格式的匯出設定中使用 `set_ShowHiddenSlides` 方法，例如 [PdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/htmloptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/tiffoptions/)。