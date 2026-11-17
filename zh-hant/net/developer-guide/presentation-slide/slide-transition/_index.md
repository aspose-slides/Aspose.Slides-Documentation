---
title: 管理 .NET 簡報中的投影片過渡效果
linktitle: 投影片過渡
type: docs
weight: 90
url: /zh-hant/net/slide-transition/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 套用投影片過渡、設定自動投影片前進，並自訂 Morph 及其他過渡效果。"
---
## **概觀**

投影片過渡效果控制投影片在投影片放映期間的顯示方式。使用 Aspose.Slides for .NET，您可以為每張投影片選擇過渡效果，設定以滑鼠點擊或計時器方式前進，並調整特定於效果的選項。本文使用 C# 範例套用過渡、設定精確的過渡持續時間、管理投影片計時，並在兩張投影片之間建立 Morph 過渡。這些範例亦示範如何將設定儲存至 PPTX 檔案。

## **新增投影片過渡**

要套用過渡效果，請使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 類別載入簡報，並存取投影片的 [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) 屬性。將其 [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) 設為來自 [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) 列舉的值，然後儲存簡報。

以下範例將 Circle 過渡套用於第一張投影片，將 Comb 過渡套用於第二張投影片。使用至少包含兩張投影片的 `input.pptx` 檔案。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    presentation.Save("slide-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **Wheel 轉場**

[IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/) 的 [Spokes](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/spokes/) 屬性控制顯示目標投影片的徑向區段數量。先將投影片的過渡 [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) 設為來自 [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) 的 Wheel，然後以 [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/) 方式存取 [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/)。

此範例建立兩組相同的投影片：一張黑色投影片，接著是一張帶金色矩形的投影片。目標投影片使用 1 與 8 的輻條數，且擁有相同的 [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) 與明確設定為 8,000 毫秒的 [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/)，以便輕鬆觀察差異。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();
var slideWidth = presentation.SlideSize.Size.Width;
var slideHeight = presentation.SlideSize.Size.Height;

var blackSlide = presentation.Slides[0];
blackSlide.Shapes.Clear();
blackSlide.Background.Type = BackgroundType.OwnBackground;
blackSlide.Background.FillFormat.FillType = FillType.Solid;
blackSlide.Background.FillFormat.SolidFillColor.Color = Color.Black;

var destinationSlide = presentation.Slides.AddClone(blackSlide);
var rectangle = destinationSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
rectangle.FillFormat.FillType = FillType.Solid;
rectangle.FillFormat.SolidFillColor.Color = Color.Gold;
rectangle.TextFrame.Text = "Wheel transition";

presentation.Slides.AddClone(blackSlide);
presentation.Slides.AddClone(destinationSlide);

var spokeCounts = new uint[] { 1, 8 };
for (var i = 0; i < spokeCounts.Length; i++)
{
    var transition = presentation.Slides[i * 2 + 1].SlideShowTransition;
    transition.Type = TransitionType.Wheel;
    var wheelTransition = (IWheelTransition)transition.Value;
    wheelTransition.Spokes = spokeCounts[i];
    transition.Speed = TransitionSpeed.Slow;
    transition.Duration = 8000;
}

presentation.Save("wheel-transitions.pptx", SaveFormat.Pptx);
```

在 PowerPoint 中開啟輸出簡報並執行投影片放映。從投影片 1 前進至投影片 2，然後從投影片 3 前進至投影片 4。在 PowerPoint 播放時，驗證過的 1 輻條會以一次順時針掃描顯示投影片；驗證過的 8 輻條則同時透過八個徑向區段顯示。目標內容與過渡計時相同，差異僅在於顯示區段的數量。

## **新增進階投影片過渡**

您可以設定投影片在螢幕上的顯示時間，以及是否透過滑鼠點擊前進投影片放映。以下屬性可控制此行為：

- [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) 允許觀眾透過點擊滑鼠前進。
- [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) 啟用自動前進。
- [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceaftertime/) 指定自動前進前的延遲時間（以毫秒為單位）。

同時啟用點擊與計時前進，可讓觀眾點擊前進或等待計時器。若僅使用計時器，請將 [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) 設為 `false`。此延遲控制投影片放映何時前進；它不會設定視覺過渡效果的持續時間。

此範例為前三張投影片指派不同的效果，並分別在 3、5、7 秒後啟用自動前進。滑鼠點擊亦可前進這些投影片。使用至少包含三張投影片的 `input.pptx` 檔案。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 3)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Circle;
    firstTransition.AdvanceOnClick = true;
    firstTransition.AdvanceAfter = true;
    firstTransition.AdvanceAfterTime = 3000;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Comb;
    secondTransition.AdvanceOnClick = true;
    secondTransition.AdvanceAfter = true;
    secondTransition.AdvanceAfterTime = 5000;

    var thirdTransition = presentation.Slides[2].SlideShowTransition;
    thirdTransition.Type = TransitionType.Zoom;
    thirdTransition.AdvanceOnClick = true;
    thirdTransition.AdvanceAfter = true;
    thirdTransition.AdvanceAfterTime = 7000;

    presentation.Save("advanced-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least three slides.");
}
```

若要檢查是否啟用計時前進，請讀取 [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/)。僅有存儲的延遲並不表示計時器已啟動。

下一個範例開啟上述保存的檔案，報告每個已啟用的計時器，並針對延遲超過兩秒的投影片停用自動前進。對這些投影片啟用滑鼠點擊，並保存更新後的設定。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("advanced-transitions.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;

    if (transition.AdvanceAfter)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: advance after {transition.AdvanceAfterTime} ms.");

        if (transition.AdvanceAfterTime > 2000)
        {
            transition.AdvanceAfter = false;
            transition.AdvanceOnClick = true;
        }
    }
}

presentation.Save("adjusted-transitions.pptx", SaveFormat.Pptx);
```

## **精確控制過渡時間**

使用 [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) 以毫秒為單位指定過渡效果的精確長度。投影片的 [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) 屬性透過 [ISlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/) 透露這些設定：

| Property | Purpose |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) | 設定過渡效果本身的持續時間（以毫秒為單位）。 |
| [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | 設定投影片自動前進前的延遲時間（以毫秒為單位）。啟用 [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) 以啟動此計時器。 |
| [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) | 從 [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/) 中選取預設速度類別：Slow、Medium 或 Fast。當未指定精確持續時間時會使用此設定。 |

[Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) 僅控制過渡效果；它不決定投影片的可見時間。請另行設定自動前進的延遲。若未設定明確的持續時間，Aspose.Slides 會根據過渡類型與 [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) 的值計算效果持續時間。

### **將相同的持續時間套用至每張投影片**

為了保持節奏一致，將相同的效果與精確持續時間套用至每張投影片。此範例載入 `input.pptx`，從 [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) 中選取 Fade，並將每個過渡的持續時間設為 750 毫秒。它另行啟用在 5,000 毫秒後的自動前進，並停用滑鼠點擊前進，最後將結果儲存為 PPTX。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    transition.Type = TransitionType.Fade;
    transition.Duration = 750;

    // 獨立於效果持續時間設定自動前進。
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **為個別投影片設定不同的持續時間**

不同的投影片可以使用不同的效果持續時間。例如，為標題投影片使用較短的過渡，為章節介紹使用較長的過渡。此範例將第一張投影片的持續時間設為 500 毫秒，第二張設為 1,200 毫秒。使用至少包含兩張投影片的 `input.pptx` 檔案。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Fade;
    firstTransition.Duration = 500;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Push;
    secondTransition.Duration = 1200;

    presentation.Save("individual-transition-durations.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

### **將過渡與動畫輸出協調**

在準備 [animated GIF](/slides/zh-hant/net/convert-powerpoint-to-animated-gif/)、[HTML5 presentation](/slides/zh-hant/net/export-to-html5/) 或 [video](/slides/zh-hant/net/convert-powerpoint-to-video/) 時，請在匯出前設定精確的過渡持續時間，以匹配預期的節奏。例如，場景之間使用 600 毫秒的淡入淡出，並個別調整每張投影片的前進延遲，以留出旁白或內容的時間。

對於 GIF 和影片，請將輸出幀率與效果持續時間協調：600 毫秒相當於 30 fps 下的 18 幀。於 HTML5 輸出時，請在匯出設定中啟用動畫過渡。檢查所選匯出格式支援的效果與計時選項，並預覽輸出以確認同步。

### **讀取現有過渡持續時間**

在修改過渡之前，先讀取 [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) 以判斷是否儲存了明確的值。值為 `-1` 表示未設定明確的持續時間；非負值表示以毫秒為單位的儲存持續時間。未設定的值並非計算出的播放持續時間：Aspose.Slides 會根據過渡類型與 [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) 來決定該持續時間。設定過渡類型可能會初始化持續時間，因此請先檢查原始設定。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    var duration = transition.Duration;

    if (duration >= 0)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: stored transition duration is {duration} ms.");
    }
    else
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: no explicit duration; timing depends on {transition.Type} and {transition.Speed}.");
    }
}
```

## **Morph 過渡**

Morph 過渡在連續投影片之間為物件的變化製作動畫。要建立簡單的 Morph 效果，請複製投影片、在複製品上移動或調整物件大小，然後將 Morph 過渡套用至第二張投影片。這樣可讓對應的物件在原始與修改後的狀態之間進行動畫。

以下範例建立一張含文字矩形的投影片，複製該投影片，並在複製品上變更矩形的位置與大小。然後為第二張投影片從 [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) 列舉中選取 Morph。於支援 Morph 的簡報檢視器中開啟已保存的檔案，即可在投影片放映期間看到效果。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var rectangle = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
rectangle.TextFrame.Text = "Morph transition";

var secondSlide = presentation.Slides.AddClone(firstSlide);
var movedRectangle = secondSlide.Shapes[0];
movedRectangle.X += 100;
movedRectangle.Y += 50;
movedRectangle.Width -= 200;
movedRectangle.Height -= 10;

secondSlide.SlideShowTransition.Type = TransitionType.Morph;

presentation.Save("morph-transition.pptx", SaveFormat.Pptx);
```

## **Morph 過渡類型**

[TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) 列舉控制 Morph 如何匹配與動畫化內容：

- [ByObject](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) 將每個形狀視為整體物件。
- [ByWord](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) 盡可能以匹配字詞的方式為文字動畫。
- [ByChar](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) 盡可能以匹配字元的方式為文字動畫。

將過渡 [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) 設為 Morph，然後存取其 [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/)。此值會提供 [IMorphTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/) 介面，其 [MorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/morphtype/) 屬性選擇匹配模式。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("morph-transition.pptx");

if (presentation.Slides.Count >= 2)
{
    var transition = presentation.Slides[1].SlideShowTransition;
    transition.Type = TransitionType.Morph;

    if (transition.Value is IMorphTransition morphTransition)
    {
        morphTransition.MorphType = TransitionMorphType.ByWord;
        presentation.Save("morph-by-word.pptx", SaveFormat.Pptx);
    }
    else
    {
        Console.WriteLine("Morph transition options are unavailable.");
    }
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

<!-- visual-explanation:slide-transition:start -->
[![Morph 匹配單位顯示為整體形狀、個別字詞與個別字元。](visual-slide-transition-76bdbee41cb7.svg)](visual-slide-transition-76bdbee41cb7.svg)

*Morph 可以在可能的情況下匹配整體形狀、字詞或字元。這些方框標示匹配單位，而非觀察到的移動。此範例在第二張投影片上選擇 ByWord。*
<!-- visual-explanation:slide-transition:end -->

## **設定過渡效果**

某些過渡會暴露額外選項，例如方向或是否從黑色畫面開始。可用選項取決於所選過渡的 [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/)。先設定類型，然後從其 [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) 使用相應的介面。

以下範例將 Cut 過渡套用於 `input.pptx` 的第一張投影片。它透過 [IOptionalBlackTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/) 設定 [FromBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/)，使過渡從黑色畫面開始。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");
var transition = presentation.Slides[0].SlideShowTransition;
transition.Type = TransitionType.Cut;

if (transition.Value is IOptionalBlackTransition cutTransition)
{
    cutTransition.FromBlack = true;
    presentation.Save("cut-from-black.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Cut transition options are unavailable.");
}
```

## **FAQ**

**Can I control the playback speed of a slide transition?**

Yes. Prefer [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) when you need an exact effect duration in milliseconds. Use [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) when a predefined [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/) category—Slow, Medium, or Fast—is sufficient and no explicit duration is set. These settings control the transition effect independently of the automatic advancement delay.

**Can I attach audio to a transition and make it loop?**

Yes. Assign embedded audio to [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/), set [SoundMode](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundmode/) to StartSound from the [TransitionSoundMode](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionsoundmode/) enumeration, and enable [SoundLoop](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundloop/). The audio loops until the next sound event in the slide show.

**What's the fastest way to apply the same transition to every slide?**

Loop through the presentation's [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) collection and set each slide's transition [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) to the same value. Set any timing and effect options in the same loop to keep the behavior consistent across slides.

**How can I check which transition is currently set on a slide?**

Read the [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) property from the slide's [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/). It returns a value from the [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) enumeration; None means that no transition effect is applied.