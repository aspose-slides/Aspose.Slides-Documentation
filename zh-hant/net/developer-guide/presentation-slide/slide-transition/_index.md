---
title: 在 .NET 中管理簡報的投影片切換
linktitle: 投影片切換
type: docs
weight: 90
url: /zh-hant/net/slide-transition/
keywords:
- 投影片切換
- 新增投影片切換
- 套用投影片切換
- 進階投影片切換
- Morph 切換
- 切換類型
- 切換效果
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 套用投影片切換、設定自動投影片前進，並自訂 Morph 與其他切換效果。"
---
## **概觀**

投影片切換控制投影片在投影片放映期間的顯示方式。使用 Aspose.Slides for .NET，您可以為每張投影片選擇切換效果、設定滑鼠點擊或計時器的前進方式，並調整特定效果的選項。本文以 C# 範例示範套用切換、設定精確的切換持續時間、管理投影片計時，以及在兩張投影片之間建立 Morph 切換。範例亦說明如何將設定儲存為 PPTX 檔案。

## **新增投影片切換**

要套用切換，請使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 類別載入簡報，並存取投影片的 [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) 屬性。將其 [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) 設為來自 [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) 列舉的值，之後儲存簡報。

以下範例將 Circle 切換套用於第一張投影片，將 Comb 切換套用於第二張。請使用至少兩張投影片的 `input.pptx` 檔案。

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

## **輪廓切換**

[IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/) 的 [Spokes](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/spokes/) 屬性控制顯示目標投影片的徑向區段數量。先將投影片的切換 [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) 設為 Wheel（來自 [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/)），再以 [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/) 方式取得 [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/)。

此範例建立兩組相同的投影片：黑色投影片後接金色矩形投影片。目標投影片的輻條數分別為 1 與 8，且皆具有相同的 [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) 與明確設定為 8,000 毫秒的 [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/)，以便輕易觀察差異。

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

在 PowerPoint 中開啟輸出簡報並執行投影片放映。從投影片 1 前往投影片 2，接著從投影片 3 前往投影片 4。在 PowerPoint 播放時，驗證過的 1 輻條會以一次順時針掃描顯示投影片；驗證過的 8 輻條則同時以八個徑向區段顯示。目的內容與切換計時相同，差異僅在於顯示區段數。

## **使用 Reveal 切換的黑色淡入**

將目的投影片的切換類型設為 Reveal，然後使用 [IRevealTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/irevealtransition/) 設定 [ThroughBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/irevealtransition/throughblack/)。此範例建立一張青色來源投影片與一張珊瑚色目的投影片，然後對兩張投影片進行複製，以比較兩秒切換在關閉與啟用淡入黑色時的差異。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var source = presentation.Slides[0];
var destination = presentation.Slides.AddClone(source);
StyleSlide(source, Color.Teal, "Source");
StyleSlide(destination, Color.Coral, "Destination");
presentation.Slides.AddClone(source);
presentation.Slides.AddClone(destination);

foreach (var index in new[] { 1, 3 })
{
    var transition = presentation.Slides[index].SlideShowTransition;
    transition.Type = TransitionType.Reveal;
    transition.Speed = TransitionSpeed.Slow;
    transition.Duration = 2000;

    var reveal = (IRevealTransition)transition.Value;
    reveal.Direction = TransitionLeftRightDirectionType.Left;
    reveal.ThroughBlack = index == 3;
}

presentation.Save("reveal-transitions.pptx", SaveFormat.Pptx);

void StyleSlide(ISlide slide, Color background, string label)
{
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = background;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 160, 180, 400, 130);
    shape.TextFrame.Text = label;
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 44;
}
```

在 PowerPoint 投影片放映中，從投影片 1 前往投影片 2。青色直接淡入珊瑚色。接著從投影片 3 前往投影片 4。畫面會短暫變暗至近黑色，然後顯示珊瑚色投影片。兩張投影片皆保留原始背景顏色。

以下列出每半秒的 PowerPoint 畫面截圖。比較每列的中間畫面以觀察設定效果。

![PowerPoint playback with ThroughBlack disabled (top) and enabled (bottom). Only the bottom row passes through near black.](reveal-through-black.png)

## **新增進階投影片切換**

您可以設定投影片在螢幕上停留的時間以及是否透過滑鼠點擊前進投影片放映。以下屬性控制此行為：

- [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) 允許觀眾透過滑鼠點擊前進。
- [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) 啟用自動前進。
- [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceaftertime/) 指定自動前進前的延遲（毫秒）。

同時啟用點擊與計時前進，讓觀眾可點擊前進或等待計時器。若僅使用計時器，將 [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) 設為 `false`。延遲僅決定投影片放映何時前進；不會設定視覺切換效果的持續時間。

此範例為前三張投影片指派不同的效果，並分別在 3、5、7 秒後啟用自動前進。滑鼠點擊亦可前進這些投影片。請使用至少三張投影片的 `input.pptx` 檔案。

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

若要檢查是否已啟用計時前進，請讀取 [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/)。僅有儲存的延遲並不表示計時器已啟動。

以下範例開啟先前儲存的檔案，回報每個已啟用的計時器，並對延遲超過兩秒的投影片停用自動前進，為這些投影片啟用滑鼠點擊，最後儲存更新後的設定。

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

## **精確控制切換計時**

使用 [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) 以毫秒為單位指定切換效果的精確長度。投影片的 [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) 屬性透過 [ISlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/) 暴露這些設定：

| Property | Purpose |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) | Sets the duration of the transition effect itself, in milliseconds. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Sets the delay before the slide advances automatically, in milliseconds. Enable [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) to activate this timer. |
| [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) | Selects a predefined speed category from [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium, or Fast. It is used when an exact duration is not specified. |

[Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) 只控制切換效果；不會決定投影片在螢幕上可見的時間。請分別設定自動前進的延遲。若未設定明確的持續時間，Aspose.Slides 會根據切換類型與 [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) 值決定效果持續時間。

### **將相同持續時間套用至每張投影片**

為了保持節奏一致，將相同的效果與精確持續時間套用至每張投影片。此範例載入 `input.pptx`，選取 [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) 中的 Fade，並將每個切換的持續時間設為 750 毫秒。它同時啟用 5,000 毫秒後的自動前進，並停用滑鼠點擊前進，最後將結果儲存為 PPTX。

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

    // 設定自動前進，與效果持續時間無關。
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **為單一投影片設定不同持續時間**

不同投影片可使用不同的效果持續時間。例如，標題投影片使用較短的切換，章節引言使用較長的切換。此範例將第一張投影片的持續時間設為 500 毫秒，第二張投影片設為 1,200 毫秒。請使用至少兩張投影片的 `input.pptx` 檔案。

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

### **與動畫輸出協同切換時間**

在製作 [animated GIF](/slides/zh-hant/net/convert-powerpoint-to-animated-gif/)、[HTML5 presentation](/slides/zh-hant/net/export-to-html5/) 或 [video](/slides/zh-hant/net/convert-powerpoint-to-video/) 時，請在匯出前設定精確的切換持續時間，以符合預期節奏。例如，場景之間使用 600 毫秒的淡入，並分別設定每張投影片的前進延遲，以提供旁白或內容的時間。

對於 GIF 與影片，請將輸出影格率與效果持續時間對齊：600 毫秒相當於 30 fps 時的 18 幀。於 HTML5 中，於匯出設定中啟用動畫切換。檢查所選匯出格式支援的效果與計時選項，並預覽輸出以確認同步。

### **讀取現有切換持續時間**

在修改切換之前讀取 [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/)，以判斷是否已儲存明確值。`-1` 代表未設定明確持續時間；非負值表示以毫秒為單位的儲存時間。未設定的值並非計算出的播放持續時間：Aspose.Slides 會根據切換類型與 [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) 來決定。設定切換類型時可能會初始化持續時間，請先檢查原始設定。

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

## **Morph 切換**

Morph 切換在連續投影片之間為物件變更製作動畫。要建立簡單的 Morph 效果，請複製投影片、在複製投影片上移動或調整物件大小，然後將 Morph 切換套用於第二張投影片。此方式會讓對應的物件在原始與修改狀態之間動畫化。

以下範例建立一張包含文字方塊的投影片，複製該投影片，並在複製投影片上變更方塊的位置與大小。接著為第二張投影片的 [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) 設為 Morph。將儲存的檔案以支援 Morph 的簡報檢視器開啟，即可在投影片放映時看到效果。

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

## **Morph 切換類型**

[TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) 列舉控制 Morph 如何匹配與動畫化內容：

- [ByObject](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) 將每個圖形視為整體物件。
- [ByWord](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) 盡可能以單詞為單位動畫化文字。
- [ByChar](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) 盡可能以字元為單位動畫化文字。

先將切換 [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) 設為 Morph，然後存取其 [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/)。該值會提供 [IMorphTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/) 介面，其 [MorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/morphtype/) 屬性選擇匹配模式。

此範例開啟前一節建立的簡報，並將第二張投影片設定為以單詞為單位的 Morph 動畫。

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
[![Morph matching units shown as a whole shape, individual words, and individual characters.](visual-slide-transition-76bdbee41cb7.svg)](visual-slide-transition-76bdbee41cb7.svg)

*Morph 可以在可能的情況下匹配整個形狀、單詞或字元。這些方框用於標示匹配單位，而非觀測到的運動。範例在第二張投影片上選擇 ByWord。*
<!-- visual-explanation:slide-transition:end -->

## **設定切換效果**

某些切換會公開額外選項，例如方向或是否從黑畫面開始。可用的選項取決於所選切換的 [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/)。先設定類型，然後使用其 [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) 所提供的相應介面。

以下範例將 Cut 切換套用於 `input.pptx` 的第一張投影片。它透過 [IOptionalBlackTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/) 的 [FromBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) 設定，使切換從黑畫面開始。

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

## **常見問題**

**我可以控制投影片切換的播放速度嗎？**

可以。當您需要以毫秒為單位的精確效果持續時間時，請優先使用 [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/)。若預設的 [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/)（Slow、Medium 或 Fast）已足夠且未設定明確持續時間，則使用 [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/)。這些設定會獨立於自動前進延遲，僅控制切換效果。

**我能將音訊附加至切換並使其循環嗎？**

可以。將嵌入音訊指派給 [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/)，將 [SoundMode](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundmode/) 設為來自 [TransitionSoundMode](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionsoundmode/) 列舉的 StartSound，並啟用 [SoundLoop](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundloop/)。音訊會在投影片放映的下一個音效事件前持續循環。

**將相同切換套用至每張投影片的最快方法是什麼？**

遍歷簡報的 [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) 集合，將每張投影片的切換 [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) 設為相同的值。於同一迴圈中設定任何計時與效果選項，以確保所有投影片的行為一致。

**我如何檢查投影片目前設定了哪種切換？**

讀取投影片的 [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) 中的 [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) 屬性。它會返回 [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) 列舉的值；None 表示未套用任何切換效果。