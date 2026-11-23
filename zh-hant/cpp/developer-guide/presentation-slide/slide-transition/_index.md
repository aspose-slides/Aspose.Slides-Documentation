---
title: 使用 C++ 管理簡報投影片過渡
linktitle: 投影片過渡
type: docs
weight: 80
url: /zh-hant/cpp/slide-transition/
keywords:
- 投影片過渡
- 新增投影片過渡
- 套用投影片過渡
- 進階投影片過渡
- Morph 過渡
- 過渡類型
- 過渡效果
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 套用投影片過渡、設定自動投影片前進，並自訂 Morph 以及其他過渡效果。"
---
## **概述**

投影片過渡控制投影片在投影片放映期間的顯示方式。使用 Aspose.Slides for C++，您可以為每張投影片選擇過渡效果、設定以滑鼠點擊或計時器前進，並調整特定效果的選項。本文使用 C++ 範例說明如何套用過渡、設定精確的過渡持續時間、管理投影片計時，並在兩張投影片之間建立 Morph 過渡。範例亦示範如何將設定儲存為 PPTX 檔案。

## **新增投影片過渡**

要套用過渡，請使用 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 類別載入簡報，並透過 [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) 取得投影片的過渡設定。呼叫 [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) 並傳入來自 [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) 列舉的值，最後儲存簡報。

以下範例把 Circle 過渡套用到第一張投影片，將 Comb 過渡套用到第二張投影片。請以至少兩張投影片的 `input.pptx` 檔案作為輸入。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    presentation->get_Slide(0)->get_SlideShowTransition()->set_Type(TransitionType::Circle);
    presentation->get_Slide(1)->get_SlideShowTransition()->set_Type(TransitionType::Comb);

    presentation->Save(u"slide-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **輪盤過渡**

[IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) 介面的 [set_Spokes](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/set_spokes/) 方法控制顯示目標投影片的徑向區段數量。先以 [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) 中的 Wheel 呼叫 [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/)，再以 [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) 介面的 [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) 取得設定。

此範例建立兩組相同的投影片：先是一張黑色投影片，接著是一張有金色矩形的投影片。目標投影片分別使用 1 與 8 個輻條，皆以 [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) 設定相同速度，並以 [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) 明確設定 8,000 毫秒，以便觀察差異。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IBackground.h>
#include <DOM/BackgroundType.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/IWheelTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
#include <cstdint>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();
auto slideWidth = presentation->get_SlideSize()->get_Size().get_Width();
auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();

auto blackSlide = presentation->get_Slide(0);
blackSlide->get_Shapes()->Clear();
blackSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
blackSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
blackSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

auto destinationSlide = presentation->get_Slides()->AddClone(blackSlide);
auto rectangle = destinationSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, slideWidth, slideHeight);
rectangle->get_FillFormat()->set_FillType(FillType::Solid);
rectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gold());
rectangle->get_TextFrame()->set_Text(u"Wheel transition");

presentation->get_Slides()->AddClone(blackSlide);
presentation->get_Slides()->AddClone(destinationSlide);

const uint32_t spokeCounts[] = { 1, 8 };
for (auto i = 0; i < 2; i++)
{
    auto transition = presentation->get_Slide(i * 2 + 1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Wheel);
    auto wheelTransition = ExplicitCast<IWheelTransition>(transition->get_Value());
    wheelTransition->set_Spokes(spokeCounts[i]);
    transition->set_Speed(TransitionSpeed::Slow);
    transition->set_Duration(8000);
}

presentation->Save(u"wheel-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

在 PowerPoint 中開啟輸出簡報並執行投影片放映。先從第 1 張投影片前往第 2 張，再從第 3 張前往第 4 張。於 PowerPoint 播放時，驗證過的 1 個輻條會以單次順時針掃描顯示投影片；驗證過的 8 個輻條則同時以八個徑向區段顯示。目標內容與過渡時間相同，差異僅在於顯示區段數量。

## **使用 Reveal 過渡的淡入黑色效果**

將目標投影片的過渡類型設定為 Reveal，然後對 [IRevealTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/irevealtransition/) 介面呼叫 [set_ThroughBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/irevealtransition/set_throughblack/)。此範例建立一張青綠色來源投影片與一張珊瑚色目標投影片，並將兩者複製，以便比較在關閉與啟用「淡入黑色」設定時相同兩秒過渡的差異。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IBackground.h>
#include <DOM/BackgroundType.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/SlideShowTransition/IRevealTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionLeftRightDirectionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto styleSlide = [](SharedPtr<ISlide> slide, Color background, const String& label)
{
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
    auto fill = slide->get_Background()->get_FillFormat();
    fill->set_FillType(FillType::Solid);
    fill->get_SolidFillColor()->set_Color(background);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 160, 180, 400, 130);
    auto textFrame = shape->get_TextFrame();
    textFrame->set_Text(label);
    textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_FontHeight(44);
};

auto presentation = MakeObject<Presentation>();

auto source = presentation->get_Slide(0);
auto destination = presentation->get_Slides()->AddClone(source);
styleSlide(source, Color::get_Teal(), u"Source");
styleSlide(destination, Color::get_Coral(), u"Destination");
presentation->get_Slides()->AddClone(source);
presentation->get_Slides()->AddClone(destination);

for (auto index : {1, 3})
{
    auto transition = presentation->get_Slide(index)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Reveal);
    transition->set_Speed(TransitionSpeed::Slow);
    transition->set_Duration(2000);

    auto reveal = ExplicitCast<IRevealTransition>(transition->get_Value());
    reveal->set_Direction(TransitionLeftRightDirectionType::Left);
    reveal->set_ThroughBlack(index == 3);
}

presentation->Save(u"reveal-transitions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

在 PowerPoint 投影片放映中，先從第 1 張投影片前往第 2 張。青綠色會直接淡入珊瑚色。再從第 3 張投影片前往第 4 張。畫面會短暫變暗至近黑色，之後才顯示珊瑚色投影片。兩張投影片皆保留原本的背景顏色。

下方列出以半秒間隔擷取的 PowerPoint 影格。比對每列的中間影格即可看出設定的差異。

![PowerPoint playback with ThroughBlack disabled (top) and enabled (bottom). Only the bottom row passes through near black.](reveal-through-black.png)

## **新增進階投影片過渡**

您可以設定投影片在螢幕上的停留時間，以及是否以滑鼠點擊前進投影片放映。以下方法控制此行為：

- [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) 允許觀看者以點擊方式前進。
- [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) 允許自動前進。
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) 指定自動前進前的延遲時間（毫秒）。

同時啟用點擊與計時前進，讓觀看者可以點擊繼續或等候計時器。若只想使用計時器，請以 `false` 呼叫 [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/)。延遲時間決定投影片何時前進，並不等同於視覺過渡效果的持續時間。

此範例為前三張投影片指定不同的效果，並分別在 3、5、7 秒後自動前進。這些投影片同樣可以透過滑鼠點擊前進。請以至少三張投影片的 `input.pptx` 檔案作為輸入。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 3)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Circle);
    firstTransition->set_AdvanceOnClick(true);
    firstTransition->set_AdvanceAfter(true);
    firstTransition->set_AdvanceAfterTime(3000);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Comb);
    secondTransition->set_AdvanceOnClick(true);
    secondTransition->set_AdvanceAfter(true);
    secondTransition->set_AdvanceAfterTime(5000);

    auto thirdTransition = presentation->get_Slide(2)->get_SlideShowTransition();
    thirdTransition->set_Type(TransitionType::Zoom);
    thirdTransition->set_AdvanceOnClick(true);
    thirdTransition->set_AdvanceAfter(true);
    thirdTransition->set_AdvanceAfterTime(7000);

    presentation->Save(u"advanced-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least three slides.");
}

presentation->Dispose();
```

若要檢查是否已啟用計時前進，請呼叫 [get_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_advanceafter/)。僅有存儲的延遲值並不代表計時器已啟動。

下一個範例開啟上述儲存的檔案，報告每個已啟用的計時器，並對延遲超過兩秒的投影片停用自動前進，同時為這些投影片啟用滑鼠點擊，最後儲存更新後的設定。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"advanced-transitions.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();

    if (transition->get_AdvanceAfter())
    {
        Console::WriteLine(u"Slide {0}: advance after {1} ms.", slide->get_SlideNumber(), transition->get_AdvanceAfterTime());

        if (transition->get_AdvanceAfterTime() > 2000)
        {
            transition->set_AdvanceAfter(false);
            transition->set_AdvanceOnClick(true);
        }
    }
}

presentation->Save(u"adjusted-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **精確控制過渡時間**

使用 [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) 以毫秒為單位指定過渡效果的精確長度。投影片的 [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) 方法會透過 [ISlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/) 暴露這些設定：

| 方法 | 用途 |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) | 設定過渡效果本身的持續時間（毫秒）。 |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | 設定投影片自動前進前的延遲時間（毫秒）。請以 `true` 呼叫 [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) 以啟動此計時器。 |
| [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) | 從 [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) 中選取預定義的速度類別：Slow、Medium 或 Fast。當未指定精確持續時間時會使用此設定。 |

[set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) 僅控制過渡效果本身，並不決定投影片的可見時間。自動前進的延遲需另行設定。若未設定明確的持續時間，Aspose.Slides 會根據過渡類型與 [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) 回傳的值推算效果長度。

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*The shared example gives each slide a 750-ms Fade transition and separately enables automatic advancement at 5,000 ms. Transition duration controls the effect; advancement controls when to leave the slide. These bars are schematic settings, not a measured combined timeline.*
<!-- visual-explanation:slide-transition:end -->

### **將相同持續時間套用至每張投影片**

為了保持節奏一致，請將相同的效果與精確持續時間套用至每張投影片。此範例載入 `input.pptx`，從 [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) 中選取 Fade，並將每個過渡設定為 750 毫秒。同時以 5,000 毫秒啟用自動前進，並停用滑鼠點擊前進，最後以 PPTX 格式儲存結果。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    transition->set_Type(TransitionType::Fade);
    transition->set_Duration(750);

    // 獨立於效果持續時間設定自動前進。
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **為個別投影片設定不同持續時間**

不同投影片可以使用不同的效果持續時間。例如，對標題投影片使用較短的過渡，對章節介紹投影片使用較長的過渡。此範例將第一張投影片設定為 500 毫秒，第二張投影片設定為 1,200 毫秒。請以至少兩張投影片的 `input.pptx` 檔案作為輸入。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Fade);
    firstTransition->set_Duration(500);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Push);
    secondTransition->set_Duration(1200);

    presentation->Save(u"individual-transition-durations.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

### **與動畫輸出協調過渡**

在製作 [animated GIF](/slides/zh-hant/cpp/convert-powerpoint-to-animated-gif/)、[HTML5 presentation](/slides/zh-hant/cpp/export-to-html5/) 或 [video](/slides/zh-hant/cpp/convert-powerpoint-to-video/) 時，請於匯出前設定精確的過渡持續時間，以符合預期節奏。例如，於場景之間使用 600 毫秒的淡入，並分別調整每張投影片的前進延遲，以留出旁白或內容的時間。

對於 GIF 與影片，請將輸出幀率與效果持續時間協調：600 毫秒相當於 30 FPS 下的 18 幀。於 HTML5 中，請在匯出設定中啟用動畫過渡。確認所選匯出格式支援的效果與時間選項，並預覽輸出以驗證同步性。

### **讀取現有過渡持續時間**

在修改過渡前先呼叫 [get_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_duration/)，以判斷是否已存儲明確值。`-1` 代表未設定明確持續時間；非負值則表示以毫秒為單位的已存儲持續時間。未設定的值並非計算出的播放時長：Aspose.Slides 會根據過渡類型與 [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) 的回傳值決定時長。設定過渡類型可能會初始化持續時間，請先檢查原始設定。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    auto duration = transition->get_Duration();

    if (duration >= 0)
    {
        Console::WriteLine(u"Slide {0}: stored transition duration is {1} ms.", slide->get_SlideNumber(), duration);
    }
    else
    {
        Console::WriteLine(u"Slide {0}: no explicit duration; timing depends on {1} and {2}.", slide->get_SlideNumber(), transition->get_Type(), transition->get_Speed());
    }
}

presentation->Dispose();
```

## **Morph 過渡**

Morph 過渡在連續投影片之間動畫化物件的變化。建立簡單的 Morph 效果，只需複製投影片、在複製版上移動或調整物件大小，然後將 Morph 過渡套用至第二張投影片，即可讓對應物件在原始與修改後狀態之間動畫化。

以下範例建立一張包含文字矩形的投影片，將其複製，並在複製版上變更矩形的位置與大小。接著於第二張投影片的 [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) 列舉中選取 Morph。於支援 Morph 的簡報檢視器中開啟儲存的檔案，即可在投影片放映時看到效果。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto rectangle = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
rectangle->get_TextFrame()->set_Text(u"Morph transition");

auto secondSlide = presentation->get_Slides()->AddClone(firstSlide);
auto movedRectangle = secondSlide->get_Shape(0);
movedRectangle->set_X(movedRectangle->get_X() + 100);
movedRectangle->set_Y(movedRectangle->get_Y() + 50);
movedRectangle->set_Width(movedRectangle->get_Width() - 200);
movedRectangle->set_Height(movedRectangle->get_Height() - 10);

secondSlide->get_SlideShowTransition()->set_Type(TransitionType::Morph);

presentation->Save(u"morph-transition.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Morph 過渡類型**

[TransitionMorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) 列舉決定 Morph 如何匹配與動畫化內容：

- [ByObject](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) 將每個形狀視為完整物件。
- [ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) 盡可能以單字為單位動畫化文字。
- [ByChar](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) 盡可能以字元為單位動畫化文字。

先以 Morph 呼叫 [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/)，再以 [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) 取得 [IMorphTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/) 介面，最後使用其 [set_MorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) 方法選擇匹配模式。

此範例開啟前一節建立的簡報，並將第二張投影片設定為以單字為基礎的 Morph 動畫。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IMorphTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionMorphType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"morph-transition.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto transition = presentation->get_Slide(1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Morph);

    auto morphTransition = AsCast<IMorphTransition>(transition->get_Value());
    if (morphTransition != nullptr)
    {
        morphTransition->set_MorphType(TransitionMorphType::ByWord);
        presentation->Save(u"morph-by-word.pptx", SaveFormat::Pptx);
    }
    else
    {
        Console::WriteLine(u"Morph transition options are unavailable.");
    }
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **設定過渡效果**

某些過渡會公開額外選項，例如方向或是否從黑色畫面開始。可用的選項取決於所選的過渡類型。先設定類型，然後使用由 [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) 回傳的相應介面。

以下範例將 Cut 過渡套用至 `input.pptx` 的第一張投影片。它透過 [IOptionalBlackTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/) 呼叫 [set_FromBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) 並傳入 `true`，使過渡從黑色畫面開始。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IOptionalBlackTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto transition = presentation->get_Slide(0)->get_SlideShowTransition();
transition->set_Type(TransitionType::Cut);

auto cutTransition = AsCast<IOptionalBlackTransition>(transition->get_Value());
if (cutTransition != nullptr)
{
    cutTransition->set_FromBlack(true);
    presentation->Save(u"cut-from-black.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Cut transition options are unavailable.");
}

presentation->Dispose();
```

## **常見問題集**

**我可以控制投影片過渡的播放速度嗎？**

可以。當需要以毫秒為單位的精確效果持續時間時，請偏好使用 [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/)。若僅需使用預定義的 [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/)（Slow、Medium 或 Fast）類別且未設定明確持續時間，則使用 [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) 即可。這些設定獨立於自動前進的延遲。

**我可以為過渡附加音訊並讓它循環播放嗎？**

可以。使用 [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_sound/) 指定內嵌音訊，然後以 [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundmode/) 並傳入 [TransitionSoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionsoundmode/) 中的 StartSound，最後以 [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundloop/) 啟用循環。音訊會持續循環，直至投影片放映中下一個音效事件發生。

**將相同過渡套用至每張投影片的最快方法是什麼？**

遍歷簡報的 [get_Slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slides/) 方法回傳的集合，對每張投影片的過渡呼叫 [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) 並傳入相同的值。於同一迴圈中設定所有計時與效果選項，以確保各投影片行為一致。

**我如何檢查投影片目前設定的過渡類型？**

對投影片的 [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) 回傳的過渡呼叫 [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_type/)。它會回傳來自 [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) 列舉的值；若為 None，表示未套用任何過渡效果。