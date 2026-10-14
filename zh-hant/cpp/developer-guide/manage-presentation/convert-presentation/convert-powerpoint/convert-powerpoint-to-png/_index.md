---
title: 在 C++ 中將 PowerPoint 投影片轉換為 PNG
linktitle: PowerPoint 轉 PNG
type: docs
weight: 30
url: /zh-hant/cpp/convert-powerpoint-to-png/
keywords:
- 轉換 PowerPoint
- 轉換 簡報
- 轉換 投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 PNG
- 簡報 轉 PNG
- 投影片 轉 PNG
- PPT 轉 PNG
- PPTX 轉 PNG
- 儲存 PPT 為 PNG
- 儲存 PPTX 為 PNG
- 匯出 PPT 為 PNG
- 匯出 PPTX 為 PNG
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 快速將 PowerPoint 簡報轉換為高品質 PNG 圖像，確保精確且自動化的結果。"
---
## **概觀**

本文說明如何使用 Aspose.Slides for C++ 將簡報投影片轉換為 PNG 圖像。您可以載入 PPT、PPTX、ODP 等格式的簡報，將每張投影片渲染後，分別儲存為 PNG 圖像。

以下範例示範了以預設比例渲染、提升比例、以像素指定輸出尺寸，以及選擇漸層渲染樣式。

## **將 PowerPoint 轉換為 PNG**

使用 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 類別載入簡報，並透過 [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) 存取投影片。範例使用不帶參數的 [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) 來渲染每張投影片，以建立縮圖。接著呼叫 [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/)，並使用 [ImageFormat::Png](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/) 將每個渲染出的投影片儲存為 PNG 圖像。

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage();
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
不帶參數的 [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) 重載會以 0.2 的比例渲染。例如，尺寸為 720 × 540 點的投影片會產生 144 × 108 像素的縮圖。若要控制輸出尺寸，請使用帶比例因子或下方示範的明確圖像大小的重載。
{{% /alert %}}

## **以自訂尺寸將 PowerPoint 轉換為 PNG（自訂尺寸）**

將水平與垂直比例因子傳遞給 [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) 可控制渲染後的尺寸。在此範例中，兩個因子皆為 2，因此尺寸為 720 × 540 點的投影片會產生 1440 × 1080 像素的圖像。相同的比例因子會保留投影片的長寬比。每張圖像皆使用 [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) 以 PNG 格式儲存。

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto scaleX = 2.f;
auto scaleY = scaleX;

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **以自訂大小將 PowerPoint 轉換為 PNG（自訂大小）**

若要以像素指定輸出尺寸，請傳遞尺寸給 [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) 而非比例因子。此範例將每張投影片渲染為 960 × 720 像素，並使用 [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) 儲存結果。請選擇與投影片長寬比相符的尺寸，以避免圖像被拉伸。

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <drawing/size.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto imageSize = System::Drawing::Size(960, 720);

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(imageSize);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **選擇漸層渲染樣式**

假設投影片包含漸層填色，但匯出的 PNG 中的過渡顏色較淡或與 PowerPoint 中看到的不同。您可以使用 [SaveOptions::set_GradientStyle](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_gradientstyle/) 方法（屬於 [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/)）來選擇漸層的渲染方式。

下載 [gradient-styles.pptx](gradient-styles.pptx) 並將其放置於應用程式的工作目錄中。其第一張投影片包含兩個線性漸層：上部由青色漸變至橙色，下部由藍色漸變至黃色。每個漸層都有兩個色停，分別位於 0% 與 100%。

以下範例載入此簡報，並使用 [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) 以兩種模式渲染相同的第一張投影片。

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <DOM/GradientStyle.h>
#include <Export/RenderingOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"gradient-styles.pptx");
auto slide = presentation->get_Slide(0);

auto gradientStyles = { GradientStyle::Default, GradientStyle::PowerPointUI };
for (auto style : gradientStyles)
{
    auto options = MakeObject<RenderingOptions>();
    options->set_GradientStyle(style);

    auto image = slide->GetImage(options, 1.f, 1.f);
    auto styleName = style == GradientStyle::Default ? u"Default" : u"PowerPointUI";
    image->Save(String::Format(u"gradient-{0}.png", styleName), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

下方的影像顯示同一張投影片的輸出結果，每張影像皆包含兩個漸層：

| Default | PowerPointUI |
| --- | --- |
| ![使用 Default 呈現的青色至橙色與藍色至黃色漸層](gradient-Default.png) | ![使用 PowerPointUI 呈現的相同漸層](gradient-PowerPointUI.png) |

在此範例中，`Default` 產生較淡的中間色，而 `PowerPointUI` 產生較暗的中間色。差異取決於漸層中的顏色與色停。

當標準的 Aspose.Slides 輸出符合需求時，請選擇 `Default`。若您的優先目標是與 PowerPoint 的外觀相符，請嘗試 `PowerPointUI`。將兩種輸出與預期結果比較；兩種模式皆無絕對的優勢。

## **常見問題**

**如何匯出特定形狀（例如圖表或圖片）而非整張投影片？**

Aspose.Slides 支援 [為單一形狀產生縮圖](/slides/zh-hant/cpp/shape-thumbnails/)，讓您能將形狀渲染為 PNG 圖像。

**伺服器上是否支援平行轉換？**

是。每個執行緒或行程序使用獨立的簡報實例；[不要在執行緒間共享單一實例](/slides/zh-hant/cpp/multithreading/)。

**匯出 PNG 時的評估模式限制是什麼？**

評估模式會在輸出圖像上加入浮水印，且會套用 [其他限制](/slides/zh-hant/cpp/licensing/)，直到套用授權為止。