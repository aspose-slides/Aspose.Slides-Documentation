---
title: 在 .NET 中管理簡報的投影片轉場
linktitle: 投影片轉場
type: docs
weight: 90
url: /zh-hant/net/slide-transition/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 套用投影片轉場、設定自動投影片前進，並自訂 Morph 以及其他轉場效果。"
---
## **概觀**

投影片轉場控制投影片在投影片秀期間的顯示方式。使用 Aspose.Slides for .NET，您可以為每張投影片選擇轉場效果、設定以滑鼠點擊或計時器前進，並調整特定效果的選項。本文使用 C# 範例說明如何套用轉場、設定精確的轉場持續時間、管理投影片計時，並在兩張投影片之間建立 Morph 轉場。範例亦示範如何將設定儲存為 PPTX 檔案。

## **新增投影片轉場**

若要套用轉場，請使用 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別載入簡報，並存取投影片的 [SlideShowTransition](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseslide/slideshowtransition/) 屬性。將其 [Type](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islideshowtransition/type/) 設為來自 [TransitionType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.slideshow/transitiontype/) 列舉的值，然後儲存簡報。

以下範例將 Circle 轉場套用於第一張投影片，將 Comb 轉場套用於第二張。請使用至少包含兩張投影片的 `input.pptx` 檔案。

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

## **新增進階投影片轉場**

您可以設定投影片在螢幕上停留的時間，以及滑鼠點擊是否前進投影片秀。以下屬性控制此行為：

- [AdvanceOnClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islideshowtransition/advanceonclick/) 允許觀眾透過點擊滑鼠前進。
- [AdvanceAfter](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islideshowtransition/advanceafter/) 允許自動前進。
- [AdvanceAfterTime](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islideshowtransition/advanceaftertime/) 指定自動前進前的延遲時間（毫秒）。

同時啟用點擊和計時前進可讓觀眾點擊或等待計時器。若僅使用計時器，請將 [AdvanceOnClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islideshowtransition/advanceonclick/) 設為 `false`。延遲時間控制投影片秀何時前進；它不會設定視覺轉場效果的持續時間。

此範例將不同效果指派給前三張投影片，並分別在 3、5、7 秒後自動前進。滑鼠點擊同樣可以前進這些投影片。請使用至少包含三張投影片的 `input.pptx` 檔案。

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

若要檢查是否已啟用計時前進，請讀取 [AdvanceAfter](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islideshowtransition/advanceafter/)。僅有儲存的延遲值並不表示計時器已啟動。

下一個範例會開啟上面儲存的檔案，報告每個已啟用的計時器，並對延遲超過兩秒的投影片停用自動前進。對這些投影片啟用滑鼠點擊，最後儲存更新後的設定。

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

## **精確控制轉場計時**

使用 [Duration](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.slideshow/slideshowtransition/duration/) 可以毫秒為單位指定轉場效果的精確長度。投影片的 [SlideShowTransition](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseslide/slideshowtransition/) 屬性透過 [ISlideShowTransition](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islideshowtransition/) 透露這些設定：

| 屬性 | 目的 |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.slideshow/slideshowtransition/duration/) | 設定轉場效果本身的持續時間（毫秒）。 |
| [AdvanceAfterTime](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | 設定投影片自動前進前的延遲時間（毫秒）。啟用 [AdvanceAfter](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islideshowtransition/advanceafter/) 以啟動此計時器。 |
| [Speed](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.slideshow/slideshowtransition/speed/) | 從 [TransitionSpeed](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.slideshow/transitionspeed/) 中選取預定義的速度類別：Slow、Medium 或 Fast。當未指定精確持續時間時會使用此設定。 |

[Duration] 僅控制轉場效果；它不決定投影片保持可見的時間。請另行設定自動前進的延遲。若未設定明確的持續時間，Aspose.Slides 會根據轉場類型與 [Speed] 值自行決定效果長度。

### **為每張投影片套用相同的持續時間**

為了保持節奏一致，請對每張投影片套用相同的效果與精確的持續時間。此範例載入 `input.pptx`，從 [TransitionType] 中選取 Fade，並將每個轉場的持續時間設為 750 毫秒。然後分別啟用 5,000 毫秒後的自動前進，並停用滑鼠點擊前進，最後將結果儲存為 PPTX。

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

### **為各投影片設定不同的持續時間**

不同投影片可以使用不同的效果持續時間。例如，標題投影片使用較短的轉場，章節介紹投影片使用較長的轉場。此範例將第一張投影片的持續時間設為 500 毫秒，第二張設為 1,200 毫秒。請使用至少包含兩張投影片的 `input.pptx` 檔案。

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

### **將轉場與動畫輸出協調**

在製作 [animated GIF](/slides/zh-hant/net/convert-powerpoint-to-animated-gif/)、[HTML5 presentation](/slides/zh-hant/net/export-to-html5/) 或 [video](/slides/zh-hant/net/convert-powerpoint-to-video/) 時，請先設定精確的轉場持續時間，以配合預期的節奏。例如，場景之間使用 600 毫秒的淡入淡出，並分別調整每張投影片的前進延遲，以留出旁白或內容的時間。

對於 GIF 與影片，請將輸出幀率與效果持續時間協調：600 毫秒相當於 30 幀每秒下的 18 幀。於 HTML5 中，請在匯出設定中啟用動畫轉場。檢查所選匯出格式支援的效果與計時選項，並預覽輸出以確認同步。

### **讀取現有的轉場持續時間**

在修改轉場之前先讀取 [Duration]，以判斷是否已儲存明確的值。`-1` 表示未設定明確持續時間；非負值則表示以毫秒為單位的已儲存持續時間。未設定的值並非計算出的播放持續時間：Aspose.Slides 會根據轉場類型與 [Speed] 來決定該持續時間。設定轉場類型可能會初始化持續時間，因此請先檢查原始設定。

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

## **Morph 轉場**

Morph 轉場會在連續投影片之間動畫化物件的變化。要建立簡易的 Morph 效果，請複製投影片、在副本上移動或調整物件大小，然後將 Morph 轉場套用至第二張投影片。這樣會讓對應的物件在原始狀態與修改後的狀態之間動畫化。

以下範例建立一張含文字矩形的投影片，複製該投影片，並在副本上變更矩形的位置與大小。接著為第二張投影片選取 [TransitionType] 列舉中的 Morph。使用支援 Morph 的簡報檢視器開啟儲存的檔案，即可在投影片秀中看到效果。

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

## **Morph 轉場類型**

[TransitionMorphType] 列舉決定 Morph 如何匹配與動畫化內容：

- [ByObject] 將每個圖形視為完整的物件。
- [ByWord] 盡可能以單字為單位匹配文字並動畫化。
- [ByChar] 盡可能以字元為單位匹配文字並動畫化。

在存取其 [Value] 之前，先將轉場 [Type] 設為 Morph。取得的值會提供 [IMorphTransition] 介面，其 [MorphType] 屬性可選擇匹配模式。

此範例開啟前一節建立的簡報，並將第二張投影片設定為使用以單字為基礎的 Morph 動畫。

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

## **設定轉場效果**

某些轉場會透露額外選項，例如方向或是否從黑畫面開始。可用的選項取決於所選的轉場 [Type]。先設定類型，然後從其 [Value] 取得相對應的介面。

以下範例將 Cut 轉場套用於 `input.pptx` 的第一張投影片。它透過 [IOptionalBlackTransition] 設定 [FromBlack]，使轉場從黑畫面開始。

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

**我可以控制投影片轉場的播放速度嗎？**

是。若需要以毫秒為單位的精確效果持續時間，請使用 [Duration]。若預定義的 [TransitionSpeed]（Slow、Medium 或 Fast）已足夠且未設定明確持續時間，則使用 [Speed]。這些設定會獨立於自動前進的延遲時間，僅控制轉場效果。

**我可以為轉場附加音訊並讓它循環播放嗎？**

是。將內嵌音訊指派給 [Sound]，將 [SoundMode] 設為來自 [TransitionSoundMode] 列舉的 StartSound，並啟用 [SoundLoop]。音訊會持續循環，直至投影片秀中的下一個音效事件。

**將相同的轉場套用到每張投影片的最快方法是什麼？**

遍歷簡報的 [Slides] 集合，將每張投影片的轉場 [Type] 設為相同的值。在同一迴圈內設定任何計時與效果選項，即可確保所有投影片的行為一致。

**我要如何檢查投影片目前設定了哪種轉場？**

讀取投影片的 [SlideShowTransition] 的 [Type] 屬性。它會回傳來自 [TransitionType] 列舉的值；若為 None，表示未套用任何轉場效果。