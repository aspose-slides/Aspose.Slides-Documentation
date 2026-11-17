---
title: 使用 C++ 管理簡報中的投影片轉場
linktitle: 投影片轉場
type: docs
weight: 80
url: /zh-hant/cpp/slide-transition/
keywords:
- 投影片轉場
- 新增投影片轉場
- 套用投影片轉場
- 進階投影片轉場
- Morph 轉場
- 轉場類型
- 轉場效果
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 套用投影片轉場、設定自動投影片前進，並自訂 Morph 及其他轉場效果。"
---
## **概覽**

投影片轉場控制投影片在投影片放映期間的顯示方式。使用 Aspose.Slides for C++，您可以為每張投影片選擇轉場效果、設定滑鼠點擊或計時器的前進方式，並調整特定效果的選項。本文章使用 C++ 範例套用轉場、設定精確的轉場持續時間、管理投影片計時，並在兩張投影片之間建立 Morph 轉場。範例也說明如何將設定儲存為 PPTX 檔案。

## **新增投影片轉場**

若要套用轉場，先使用 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 類別載入簡報，並透過 [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) 取得投影片的轉場設定。使用 [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) 並傳入 [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) 列舉中的值，之後儲存簡報。

下列範例將 Circle 轉場套用於第一張投影片，並將 Comb 轉場套用於第二張投影片。請使用至少包含兩張投影片的 `input.pptx` 檔案。

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

## **輪形轉場**

[IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) 的 [set_Spokes](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/set_spokes/) 方法控制顯示目標投影片時的徑向區段數量。先使用 [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) 並傳入 [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) 中的 Wheel，之後以 [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) 取得 [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/)。

此範例建立兩組相同的投影片：一張黑色投影片，緊接著一張含金色矩形的投影片。目標投影片使用 1 與 8 個輻條的設定，並透過 [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) 設定相同的速度，另外使用 [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) 明確設定 8,000 毫秒的持續時間，以便輕易觀察差異。

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

在 PowerPoint 中開啟輸出簡報並執行投影片放映。從第 1 張投影片前進至第 2 張，接著從第 3 張前進至第 4 張。在 PowerPoint 播放時，驗證過的 1 個輻條會以單一順時針掃描顯示投影片；驗證過的 8 個輻條則同時以八個徑向區段顯示。目標內容與轉場時間相同，差異僅在於顯示區段的數量。

## **新增進階投影片轉場**

您可以設定投影片在畫面上停留的時間，以及是否透過滑鼠點擊前進投影片放映。以下方法控制此行為：

- [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) 允許觀眾透過滑鼠點擊前進。
- [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) 啟用自動前進。
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) 指定自動前進前的延遲時間（以毫秒為單位）。

同時啟用點擊與計時前進，讓觀眾可以點擊前進或等待計時器。若僅使用計時器，請以 `false` 呼叫 [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/)。延遲時間決定投影片放映何時前進；它不會設定視覺轉場效果的持續時間。

此範例將不同的效果分別指派給前三張投影片，並分別在 3、5、7 秒後自動前進。滑鼠點擊同樣可以前進這些投影片。請使用至少包含三張投影片的 `input.pptx` 檔案。

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

若要檢查是否已啟用計時前進，請呼叫 [get_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_advanceafter/)。僅儲存的延遲時間並不代表計時器已啟動。

下一個範例開啟上述儲存的檔案，報告每個已啟用的計時器，並對延遲時間超過兩秒的投影片停用自動前進。對這些投影片啟用滑鼠點擊，最後將更新的設定儲存。

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

## **精確控制轉場時間**

使用 [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) 可以毫秒為單位指定轉場效果的精確長度。投影片的 [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) 方法透過 [ISlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/) 曝露這些設定：

| 方法 | 目的 |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) | 設定轉場效果本身的持續時間（以毫秒為單位）。 |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | 設定投影片自動前進前的延遲時間（以毫秒為單位）。呼叫 [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) 並傳入 `true` 以啟動此計時器。 |
| [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) | 從 [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) 中挑選預定義的速度類別：Slow、Medium 或 Fast。當未指定精確持續時間時使用此設定。 |

[set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) 僅控制轉場效果本身；它不決定投影片在畫面上停留的時間。請另外設定自動前進的延遲時間。若未設定明確的持續時間，Aspose.Slides 會根據轉場類型以及 [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) 回傳的值來決定效果的持續時間。

<!-- visual-explanation:slide-transition:start -->
[![不同的條形分別表示 750 毫秒的轉場持續時間以及 5,000 毫秒的自動前進設定。](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*此範例將每張投影片設定為 750 ms 的 Fade 轉場，並分別在 5,000 ms 後自動前進。轉場持續時間控制效果本身；前進設定控制何時離開投影片。這些條形為示意設定，並非實際測量的綜合時間軸。*
<!-- visual-explanation:slide-transition:end -->

### **將相同的持續時間套用到每張投影片**

為了保持節奏一致，將相同的效果與精確的持續時間套用至每張投影片。本範例載入 `input.pptx`，從 [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) 中選取 Fade，並將每個轉場的持續時間設定為 750 毫秒。再分別在 5,000 毫秒後啟用自動前進，並停用滑鼠點擊前進，最後將結果儲存為 PPTX。

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

    // 設定自動前進，與效果持續時間獨立。
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **為各投影片設定不同的持續時間**

不同的投影片可以使用不同的效果持續時間。例如，為標題投影片使用較短的轉場，為章節介紹使用較長的轉場。本範例將第一張投影片設定為 500 毫秒，第二張投影片設定為 1,200 毫秒。請使用至少包含兩張投影片的 `input.pptx` 檔案。

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

### **將轉場與動畫輸出協調**

在製作 [animated GIF](/slides/zh-hant/cpp/convert-powerpoint-to-animated-gif/)、[HTML5 presentation](/slides/zh-hant/cpp/export-to-html5/) 或 [video](/slides/zh-hant/cpp/convert-powerpoint-to-video/) 時，請在匯出前設定精確的轉場持續時間，以符合預期的節奏。例如，場景之間使用 600 毫秒的淡入淡出，並分別調整每張投影片的前進延遲，以提供旁白或內容的播放時間。

對於 GIF 與影片，請將輸出幀率與效果持續時間對應：600 毫秒相當於 30 fps 時的 18 幀。於 HTML5 輸出時，請在匯出設定中啟用動畫轉場。檢查所選擇的匯出格式支援的效果與計時選項，並預覽輸出以確認同步。

### **讀取現有轉場持續時間**

在修改轉場之前呼叫 [get_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_duration/) 以判斷是否已儲存明確的值。`-1` 表示未設定明確的持續時間；非負值則表示以毫秒為單位的已儲存持續時間。未設定的值並非計算出的播放持續時間：Aspose.Slides 會根據轉場類型與 [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) 回傳的值來決定該持續時間。設定轉場類型可能會初始化持續時間，因此請先檢查原始設定。

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

## **Morph 轉場**

Morph 轉場會在連續投影片之間為物件的變化加入動畫。要建立簡單的 Morph 效果，只需複製投影片、在複製版上移動或調整物件大小，然後對第二張投影片套用 Morph 轉場。如此即可讓相對應的物件在原始狀態與變更後的狀態之間動畫過渡。

以下範例建立一張包含文字矩形的投影片，複製該投影片，並在複製版上改變矩形的位置與大小。接著在第二張投影片上選取 [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) 中的 Morph。於支援 Morph 的簡報檢視器中開啟已儲存的檔案，即可在投影片放映時看到效果。

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

## **Morph 轉場類型**

[TransitionMorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) 列舉控制 Morph 如何匹配與動畫內容：

- [ByObject](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) 將每個圖形視為整體物件。
- [ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) 盡可能以單字匹配的方式為文字動畫。
- [ByChar](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) 盡可能以字元匹配的方式為文字動畫。

先以 Morph 呼叫 [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/)，然後存取 [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/)。取得的值會提供 [IMorphTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/) 介面，可透過其 [set_MorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) 方法選擇匹配模式。

此範例開啟前節建立的簡報，並將第二張投影片設定為以單字為單位的 Morph 動畫。

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

## **設定轉場效果**

某些轉場會提供額外選項，例如方向或是否從黑屏開始。可用的選項取決於所選的轉場類型。先設定類型，然後使用 [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) 回傳的相應介面。

以下範例對 `input.pptx` 的第一張投影片套用 Cut 轉場，並透過 [IOptionalBlackTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/) 呼叫 [set_FromBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) 並傳入 `true`，使轉場從黑屏開始。

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

## **常見問題**

**我可以控制投影片轉場的播放速度嗎？**

可以。需要以毫秒為單位的精確效果持續時間時，請優先使用 [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/)。若預定義的 [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/)（Slow、Medium 或 Fast）足以滿足需求且未設定精確持續時間，則使用 [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/)。這些設定僅控制轉場效果，與自動前進的延遲時間無關。

**我可以為轉場加入音訊並使其循環播放嗎？**

可以。使用 [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_sound/) 指定內嵌音訊，然後以 [TransitionSoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionsoundmode/) 中的 StartSound 呼叫 [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundmode/)，再以 [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundloop/) 啟用循環。音訊會持續循環，直到投影片放映中的下一個音效事件為止。

**將相同的轉場快速套用至每張投影片的最佳方式是什麼？**

遍歷簡報的 [get_Slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slides/) 方法回傳的集合，對每張投影片的轉場呼叫 [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) 並傳入相同的值。於同一迴圈中設定任何計時或效果選項，即可保持所有投影片的行為一致。

**我如何檢查投影片上目前設定的轉場是什麼？**

對投影片的 [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) 方法回傳的轉場呼叫 [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_type/)。它會回傳 [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) 列舉中的值；若為 None，表示未套用任何轉場效果。