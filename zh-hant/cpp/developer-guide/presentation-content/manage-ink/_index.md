---
title: 在 C++ 中管理簡報墨跡物件
linktitle: 管理墨跡
type: docs
weight: 95
url: /zh-hant/cpp/manage-ink/
keywords:
- 墨跡
- 墨跡物件
- 墨跡軌跡
- 管理墨跡
- 繪製墨跡
- 繪圖
- 墨跡匯出
- 墨跡算繪
- 隱藏墨跡
- IInkOptions
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "管理 PowerPoint 墨跡物件，編輯軌跡與筆刷屬性，並在使用 Aspose.Slides for C++ 時控制 PDF、HTML、SVG、TIFF 和影像匯出期間的墨跡外觀。"
---
## **簡介**

PowerPoint 提供了墨跡功能，允許您繪製自由形式的筆畫。墨跡可用於標註其他物件、顯示連接與流程，並將注意力聚焦於投影片上的特定項目。

[Aspose.Slides.Ink](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.ink/) 命名空間包含處理墨跡物件所需的類別和介面。例如，[IInk](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.ink/iink/) 介面表示投影片上的墨跡物件。

## **一般物件與墨跡物件的差異**

PowerPoint 投影片上的物件通常以形狀物件呈現。最簡單的形狀是一個容器，定義物件本身的區域（其框架），以及容器大小、形狀和背景等屬性。詳細資訊請參閱 [Shape Layout Format](https://docs.aspose.com/slides/zh-hant/cpp/shape-manipulations/#access-layout-formats-for-shape)。

然而，當 PowerPoint 處理墨跡物件時，會忽略物件框架（容器）的所有屬性，僅保留其大小。容器區域的大小由標準的 [IShape::get_Width](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_width/) 與 [IShape::get_Height](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_height/) 方法決定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨跡軌跡**

墨跡軌跡是用來記錄使用者書寫數位墨跡時筆尖軌跡的基本元素。軌跡儲存一系列相連的點。

最簡單的編碼形式是指定每個取樣點的 X 與 Y 座標。當所有相連的點被繪製時，會產生如下圖像：

![ink_powerpoint2](ink_powerpoint2.png)

## **繪圖筆刷屬性**

筆刷用於繪製連接墨跡軌跡點的線條。筆刷具備自己的顏色與大小，分別透過 [IInkBrush::get_Color](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.ink/iinkbrush/get_color/) 與 [IInkBrush::get_Size](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.ink/iinkbrush/get_size/) 方法取得。

### **設定墨跡筆刷顏色**

以下 C++ 程式碼示範如何設定墨跡筆刷的顏色：

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Color(System::Drawing::Color::get_Red());

presentation->Dispose();
```

### **設定墨跡筆刷大小**

以下 C++ 程式碼示範如何設定墨跡筆刷的大小：

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));

presentation->Dispose();
```

通常，筆刷的寬度與高度不相同，PowerPoint 不會顯示筆刷大小（相應的資料區段會呈現灰色）。當筆刷的寬度與高度相同時，PowerPoint 會以以下方式顯示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

為了更清楚說明，我們將提高墨跡物件的高度，並檢視重要的尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不會考慮筆刷的大小——它始終假設線條粗細為零（請參見前圖）。

因此，要確定整個墨跡物件的可見區域，必須將其軌跡的筆刷大小納入考量。在此，目標物件（手寫文字軌跡）已被縮放至容器（框架）的大小。當容器大小變更時，筆刷大小保持不變，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 對文字物件也採用類似的行為：

![ink_powerpoint6](ink_powerpoint6.png)

## **在匯出與算繪期間控制墨跡外觀**

Aspose.Slides 提供了 [IInkOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/iinkoptions/) 介面，以控制墨跡物件在匯出或算繪輸出時的呈現方式。您可以使用其方法完全隱藏墨跡或變更墨跡筆刷遮罩操作的解釋方式。

Ink options are available through the export or rendering options for several output types:

| Output | Ink options method |
| --- | --- |
| PDF | [PdfOptions::get_InkOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/get_inkoptions/) |
| HTML | [HtmlOptions::get_InkOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/htmloptions/get_inkoptions/) |
| SVG | [SVGOptions::get_InkOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/svgoptions/get_inkoptions/) |
| TIFF | [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) |
| Slide image | [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) |

這些方法提供相同的兩個設定：

- [IInkOptions::set_HideInk](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/iinkoptions/set_hideink/) 決定是否在輸出中包含墨跡物件。預設值為 `false`。
- [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) 決定在算繪墨跡筆刷時，遮罩操作是否被解釋為不透明度。預設值為 `true`；將其設為 `false` 以改用 ROP 操作。

### **在 PDF 輸出中隱藏墨跡物件**

預設情況下，匯出時會保留墨跡物件。當需要沒有手寫註解或其他墨跡內容的乾淨輸出時，請以 `true` 呼叫 [IInkOptions::set_HideInk](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/iinkoptions/set_hideink/)。

以下 C++ 範例在匯出簡報為 PDF 時隱藏所有墨跡物件：

```cpp
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::PdfOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->get_InkOptions()->set_HideInk(true);

presentation->Save(u"presentation_without_ink.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **算繪投影片為影像時隱藏墨跡物件**

若要在將投影片算繪為點陣圖影像時隱藏墨跡物件，請設定 [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/renderingoptions/get_inkoptions/)，並將算繪選項傳遞給 [ISlide::GetImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/getimage/) 方法。

以下 C++ 範例將第一張投影片算繪為不含墨跡物件的 PNG 影像：

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::ImageFormat;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::RenderingOptions;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->get_InkOptions()->set_HideInk(true);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions);
image->Save(u"slide_without_ink.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

### **控制墨跡遮罩算繪**

[IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) 方法控制在算繪墨跡筆刷時，遮罩操作的解釋方式。預設值為 `true`，使用不透明度。將此方法設為 `false` 則改用 ROP 操作。

以下 C++ 範例將投影片匯出為 SVG，並使用基於 ROP 的墨跡遮罩算繪：

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SVGOptions;
using System::MakeObject;
using System::IO::File;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->get_InkOptions()->set_InterpretMaskOpAsOpacity(false);

auto stream = File::Create(u"slide.svg");
presentation->get_Slide(0)->WriteAsSvg(stream, svgOptions);

stream->Dispose();
presentation->Dispose();
```

相同設定也可透過 [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) 在匯出簡報或算繪投影片為 TIFF 時套用。

### **選擇隱藏或保留墨跡**

當匯出的檔案應為帶有註解之簡報的清潔版（例如，供發佈而無審閱標記的最終副本）時，請使用 `true` 的 [IInkOptions::set_HideInk](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/iinkoptions/set_hideink/)。

若墨跡註解是預期內容的一部分，例如審閱意見、手寫筆記、重點標示或應保留於匯出結果的圖形，請保留墨跡可見（預設 `false` 設定）。這讓應用程式能從同一簡報產生分別的審閱與最終輸出，而無需修改來源墨跡物件。

## **常見問題**

**我可以更改現有墨跡筆畫的顏色或大小嗎？**

可以。從 [IInk::get_Traces](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.ink/iink/get_traces/) 取得軌跡，然後變更其 [IInkTrace::get_Brush](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.ink/iinktrace/get_brush/)。您可以對筆刷呼叫 [IInkBrush::set_Color](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.ink/iinkbrush/set_color/) 與 [IInkBrush::set_Size](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.ink/iinkbrush/set_size/)。

**隱藏墨跡會改變原始簡報嗎？**

不會。[IInkOptions::set_HideInk](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/iinkoptions/set_hideink/) 僅影響算繪或匯出結果；它不會移除或修改原始簡報中的墨跡物件。

**哪些匯出格式支援墨跡選項？**

您可以透過前述相應的匯出或算繪選項，為 PDF、HTML、SVG、TIFF 以及點陣圖投影片影像設定墨跡選項。

**進一步閱讀**

* 若要了解一般形狀，請參閱 [PowerPoint Shapes](https://docs.aspose.com/slides/zh-hant/cpp/powerpoint-shapes/) 章節。  
* 如需取得有效屬性的更多資訊，請參閱 [Shape Effective Properties](https://docs.aspose.com/slides/zh-hant/cpp/shape-effective-properties/#get-effective-font-height-value)。  
* 有關 PDF 匯出的詳細資訊，請參閱 [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/zh-hant/cpp/convert-powerpoint-to-pdf/)。  
* 有關 HTML 匯出的詳細資訊，請參閱 [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/zh-hant/cpp/convert-powerpoint-to-html/)。  
* 有關 SVG 匯出的詳細資訊，請參閱 [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/zh-hant/cpp/render-a-slide-as-an-svg-image/)。  
* 有關 TIFF 匯出的詳細資訊，請參閱 [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/zh-hant/cpp/convert-powerpoint-to-tiff/)。  
* 有關投影片轉影像算繪的詳細資訊，請參閱 [Convert Presentation Slides to Images](https://docs.aspose.com/slides/zh-hant/cpp/convert-slide/)。