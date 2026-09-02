---
title: 在 .NET 簡報中套用形狀動畫
linktitle: 形狀動畫
type: docs
weight: 60
url: /zh-hant/net/shape-animation/
keywords:
- 形狀
- 動畫
- 效果
- 動態形狀
- 動態文字
- 新增動畫
- 取得動畫
- 擷取動畫
- 新增效果
- 取得效果
- 擷取效果
- 效果聲音
- 套用動畫
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "瞭解如何使用 Aspose.Slides for .NET 新增、檢查及自訂形狀動畫、計時、聲音、動畫結束後行為，以及動態文字。"
---
## **概述**

Aspose.Slides for .NET 將投影片動畫表示為投影片時間軸中的效果。每個效果具有目標形狀、動畫類型與子類型、觸發器、計時設定，以及聲音或動畫結束後行為等可選屬性。

時間軸包含兩種序列：

- **主序列** 會在投影片前進時播放。
- **互動序列** 會在其觸發形狀被點擊時開始。

由於文字方塊、圖片、圖表、表格及其他投影片物件皆實作 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/)，因此對大多數投影片內容皆使用相同的 [ISequence.AddEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/isequence/addeffect/) 方法。可用的效果列在 [EffectType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/effecttype/) 列舉中。

## **新增形狀動畫**

若要新增動畫，取得投影片的主序列，並以目標形狀、效果類型、子類型與觸發器呼叫 [ISequence.AddEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/isequence/addeffect/)。若要建立在點擊其他形狀時才開始的效果，請建立觸發器為該其他形狀的互動序列。

以下範例同時建立兩種動畫，並將結果儲存為 `shape-animations.pptx`。

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var targetShape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Click to animate this shape";

var mainSequence = slide.Timeline.MainSequence;
var entranceEffect = mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
entranceEffect.Timing.Duration = 1.5f;

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

presentation.Save("shape-animations.pptx", SaveFormat.Pptx);
```

觸發器決定效果何時開始：

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/effecttriggertype/) 會在主序列中等待點擊，或在互動序列中等待對觸發形狀的點擊。
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/effecttriggertype/) 會與前一個效果同時開始。
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/effecttriggertype/) 會在前一個效果結束後開始。

若要為圖片、圖表或其他形狀類型加入動畫，請將該物件傳遞給 [ISequence.AddEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/isequence/addeffect/) 取代 `targetShape`。有關圖表特定的群組選項，請參閱 [Animated Charts](/slides/zh-hant/net/animated-charts/)。

## **讀取形狀動畫**

當已知目標形狀時，使用 [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/isequence/geteffectsbyshape/)。若要檢查每個效果，請列舉主序列與所有互動序列。列舉可避免假設某序列在索引 `0` 處一定有效果。

以下範例建立具有主序列與互動效果的形狀，取得針對該形狀的效果，然後列舉投影片上的每個序列。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Animated shape";

var mainSequence = slide.Timeline.MainSequence;
mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

var targetEffects = mainSequence.GetEffectsByShape(targetShape);
Console.WriteLine($"The main sequence contains {targetEffects.Length} effect(s) for {targetShape.Name}.");

PrintSequence("Main sequence", mainSequence);

var interactiveIndex = 1;
foreach (var sequence in slide.Timeline.InteractiveSequences)
{
    var triggerName = sequence.TriggerShape == null ? "unknown" : sequence.TriggerShape.Name;
    var sequenceLabel = $"Interactive sequence {interactiveIndex}, trigger: {triggerName}";
    PrintSequence(sequenceLabel, sequence);
    interactiveIndex++;
}

static void PrintSequence(string label, ISequence sequence)
{
    Console.WriteLine($"  {label}: {sequence.Count} effect(s)");

    foreach (var effect in sequence)
    {
        var targetName = effect.TargetShape == null ? "unknown" : effect.TargetShape.Name;
        var effectDescription = $"{effect.Type} {effect.Subtype}; target: {targetName}; trigger: {effect.Timing.TriggerType}";
        Console.WriteLine($"    {effectDescription}");
    }
}
```

如果只需要單一形狀的效果，請先以名稱、佔位符類型或其他穩定屬性識別該形狀，然後呼叫 [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/isequence/geteffectsbyshape/)。不要假設索引 `0` 的 [IShapeCollection.Item](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/item/) 必定是目標物件。

## **處理繼承的佔位符效果**

普通投影片上的佔位符可以繼承自其版面配置投影片與母版投影片上對應佔位符的動畫行為。 [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/getbaseplaceholder/) 會傳回該父佔位符，若無父佔位符則傳回 `null`。

在以下示範簡報中，頁腳在普通投影片上使用 **Random Bars**，在版面配置投影片上使用 **Split**，在母版投影片上使用 **Fly In**。

![正常投影片上的頁腳動畫效果](slide-shape-animation.png)

![版面配置投影片上頁腳佔位符動畫效果](layout-shape-animation.png)

![母版投影片上頁腳佔位符動畫效果](master-shape-animation.png)

下一個範例自行建立佔位符階層。它會為母版佔位符、版面配置佔位符以及普通投影片上的對應佔位符新增效果。每次呼叫 [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/getbaseplaceholder/) 前都會先檢查返回的形狀是否為 null。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
var layoutPlaceholder = layoutSlide.PlaceholderManager.AddTextPlaceholder(100, 100, 400, 80);
layoutSlide.Timeline.MainSequence.AddEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
if (masterPlaceholder != null)
{
    var masterSequence = layoutSlide.MasterSlide.Timeline.MainSequence;
    masterSequence.AddEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}

var slide = presentation.Slides.AddEmptySlide(layoutSlide);
var slidePlaceholder = FindPlaceholderWithBase(slide);

if (slidePlaceholder == null)
{
    throw new InvalidOperationException("The slide does not contain a placeholder linked to its layout slide.");
}

slide.Timeline.MainSequence.AddEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
PrintEffects("Normal slide", slide.Timeline.MainSequence.GetEffectsByShape(slidePlaceholder));

var baseLayoutPlaceholder = slidePlaceholder.GetBasePlaceholder();
if (baseLayoutPlaceholder != null)
{
    PrintEffects("Layout slide", layoutSlide.Timeline.MainSequence.GetEffectsByShape(baseLayoutPlaceholder));

    var baseMasterPlaceholder = baseLayoutPlaceholder.GetBasePlaceholder();
    if (baseMasterPlaceholder != null)
    {
        PrintEffects("Master slide", layoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(baseMasterPlaceholder));
    }
}

presentation.Save("placeholder-animations.pptx", SaveFormat.Pptx);

static IShape FindPlaceholderWithBase(ISlide slide)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape.GetBasePlaceholder() != null)
        {
            return shape;
        }
    }

    return null;
}

static void PrintEffects(string source, IEffect[] effects)
{
    Console.WriteLine($"{source}: {effects.Length} effect(s)");

    foreach (var effect in effects)
    {
        Console.WriteLine($"  {effect.Type} {effect.Subtype}");
    }
}
```

## **變更動畫計時**

PowerPoint **Timing** 對話框對應到 [ITiming](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/) 的屬性。

![PowerPoint 動畫效果的 Timing 對話框](shape-animation.png)

- **開始** 對應到 [ITiming.TriggerType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/triggertype/)。
- **持續時間** 對應到 [ITiming.Duration](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/duration/)，以秒為單位。
- **延遲** 對應到 [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/triggerdelaytime/)，以秒為單位。
- **重複** 對應到 [ITiming.RepeatCount](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/repeatcount/)、[ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/repeatuntilnextclick/) 或 [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/repeatuntilendslide/)。
- **播放完畢後倒帶** 對應到 [ITiming.Rewind](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/rewind/)。

此獨立範例新增一個效果，透過由 [ISequence.AddEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/isequence/addeffect/) 回傳的物件變更其計時，並儲存結果。保留回傳的 [IEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/) 參考可避免不必要的集合索引。

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Timed animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Timing.TriggerType = EffectTriggerType.OnClick;
effect.Timing.Duration = 2.0f;
effect.Timing.TriggerDelayTime = 0.5f;
effect.Timing.RepeatUntilNextClick = false;
effect.Timing.RepeatUntilEndSlide = false;
effect.Timing.RepeatCount = 2.0f;
effect.Timing.Rewind = true;

presentation.Save("shape-animation-timing.pptx", SaveFormat.Pptx);
```

使用單一的重複模式。將重複計數與「直到」旗標混合使用可能在不同的檢視器中產生混淆的結果。變更重複模式時，請先設定 [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/repeatuntilnextclick/) 與 [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/repeatuntilendslide/)，再設定 [ITiming.RepeatCount](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/repeatcount/)，因為設定任一旗標都會同時更改目前的重複模式。

## **新增與擷取動畫聲音**

動畫效果可以透過 [IEffect.Sound](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/sound/) 參考嵌入的音訊。[IEffect.StopPreviousSound](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/stopprevioussound/) 會指示效果停止先前效果啟動的音訊。

### **為效果新增聲音**

以下範例預期本機有名為 `animation-sound.wav` 的音訊檔案。它會建立兩個效果，將該檔案嵌入為第一個效果的聲音，並將第二個效果設定為停止該聲音。它使用由 [ISequence.AddEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/isequence/addeffect/) 回傳的物件，因此不需要序列索引。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
firstShape.TextFrame.Text = "Starts sound";
secondShape.TextFrame.Text = "Stops sound";

var sequence = slide.Timeline.MainSequence;
var firstEffect = sequence.AddEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
var secondEffect = sequence.AddEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var audioData = File.ReadAllBytes("animation-sound.wav");
var effectSound = presentation.Audios.AddAudio(audioData);
firstEffect.Sound = effectSound;
secondEffect.StopPreviousSound = true;

presentation.Save("shape-animation-sound.pptx", SaveFormat.Pptx);
```

### **擷取嵌入的效果聲音**

以下範例預期本機有名為 `presentation-with-animation-sounds.pptx` 的簡報。它會掃描主序列與互動序列，將每個嵌入的效果聲音寫入 `extracted-animation-sounds` 目錄。副檔名會根據 [IAudio.ContentType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iaudio/contenttype/) 所回傳的音訊 MIME 類型選擇。

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;

var inputPath = "presentation-with-animation-sounds.pptx";
var outputDirectory = "extracted-animation-sounds";

Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation(inputPath);
var soundIndex = 1;

foreach (var slide in presentation.Slides)
{
    SaveSounds(slide.Timeline.MainSequence, outputDirectory, ref soundIndex);

    foreach (var sequence in slide.Timeline.InteractiveSequences)
    {
        SaveSounds(sequence, outputDirectory, ref soundIndex);
    }
}

Console.WriteLine($"Extracted {soundIndex - 1} sound file(s) to {Path.GetFullPath(outputDirectory)}.");

static void SaveSounds(ISequence sequence, string outputDirectory, ref int soundIndex)
{
    foreach (var effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        var extension = GetAudioExtension(effect.Sound.ContentType);
        var outputPath = Path.Combine(outputDirectory, $"effect-sound-{soundIndex}{extension}");
        File.WriteAllBytes(outputPath, effect.Sound.BinaryData);
        soundIndex++;
    }
}

static string GetAudioExtension(string contentType)
{
    var normalizedType = contentType == null ? string.Empty : contentType.ToLowerInvariant();

    if (normalizedType == "audio/mpeg")
        return ".mp3";

    if (normalizedType == "audio/mp4")
        return ".m4a";

    if (normalizedType == "audio/ogg")
        return ".ogg";

    if (normalizedType == "audio/wav" || normalizedType == "audio/x-wav")
        return ".wav";

    return ".bin";
}
```

對於大型音訊物件，請使用 [IAudio.GetStream](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iaudio/getstream/) 並將串流複製到檔案，而非將整個物件載入至位元組陣列。

## **設定動畫結束後行為**

**After animation** 選項控制形狀在效果結束後的處理方式。

![PowerPoint Effect Options dialog showing After animation settings](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/afteranimationtype/) 列舉支援保持形狀不變、變更顏色、在動畫結束後隱藏，或在下一次點擊時隱藏。當類型為 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/afteranimationtype/)，同時需要設定 [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/afteranimationcolor/)。

此獨立範例建立一個效果，透過回傳的效果物件設定其動畫結束後行為，並儲存結果。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Dim after animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.AfterAnimationType = AfterAnimationType.Color;
effect.AfterAnimationColor.Color = Color.LightGray;

presentation.Save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
```

將類型從 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/afteranimationtype/) 改為其他值時，會清除動畫結束後的顏色設定。

## **文字動畫**

文字動畫有兩個相關控制項：

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itextanimation/buildtype/) 控制段落是一起顯示還是逐段顯示。
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/animatetexttype/) 控制文字是一次顯示、逐字或逐字母顯示。[IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/delaybetweentextparts/) 設定字或字母之間的延遲。正值為效果持續時間的百分比；負值為以秒為單位的延遲。

以下獨立範例對文字方塊中的單字進行動畫。[BuildType.AsOneObject](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/buildtype/) 會停用逐段建構，讓單字設定套用於整個文字框。

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
textBox.TextFrame.Text = "Aspose.Slides animates this sentence word by word.";

var effect = slide.Timeline.MainSequence.AddEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.TextAnimation.BuildType = BuildType.AsOneObject;
effect.AnimateTextType = AnimateTextType.ByWord;
effect.DelayBetweenTextParts = 20.0f;

presentation.Save("animated-text.pptx", SaveFormat.Pptx);
```

若要逐段建構文字方塊，請設定 [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/buildtype/)（或其他段落層級）。若要對單一段落使用獨立效果，請使用接受 [IParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraph/) 的 [ISequence.AddEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/isequence/addeffect/) 重載。請參閱 [Animated Text](/slides/zh-hant/net/animated-text/) 取得段落層級的範例。

## **匯出與相容性說明**

- 儲存為 PPT 或 PPTX 會保留動畫模型，但最終播放由簡報檢視器控制。
- PDF 與靜態影像不會播放動畫。當輸出必須呈現動態時，請使用 [HTML5 export](/slides/zh-hant/net/export-to-html5/)、動畫 GIF，或 [video conversion](/slides/zh-hant/net/convert-powerpoint-to-video/)。
- 若使用 HTML5，請啟用 [Html5Options.AnimateShapes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/html5options/animateshapes/)，必要時再啟用 [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/html5options/animatetransitions/)。
- 影片轉換支援許多常見的進入、強調、退出與移動路徑效果，但並非所有 PowerPoint 效果皆受支援。請檢查最新的 [supported animations and effects](/slides/zh-hant/net/convert-powerpoint-to-video/#supported-animations-and-effects) 並使用目標 Aspose.Slides 版本測試關鍵簡報。
- 進階自訂效果以及從其他簡報格式匯入的效果可能會在檔案中保留，但在 PowerPoint、HTML5 或影片中呈現方式可能不同。請驗證匯出結果，而非僅依賴效果名稱。

## **常見問題**

**為什麼動畫在 PowerPoint 中出現，但在 PDF 中卻沒有？**

PDF 為靜態格式，動畫與投影片切換不會播放。若需保留動態，請匯出為 HTML5、動畫 GIF 或影片。

**為什麼效果在影片中呈現的方式不同？**

影片匯出會將動畫渲染為影片畫面，而非保留原始 PowerPoint 行為。某些進階效果不受支援或會被近似。請參考支援的效果表，並在正式使用前測試實際簡報。

**移動形狀的前後順序會改變動畫的播放順序嗎？**

不會。形狀的 Z 順序只控制重疊，而序列順序與觸發器才決定動畫的播放順序。如需改變播放順序，請調整時間軸。