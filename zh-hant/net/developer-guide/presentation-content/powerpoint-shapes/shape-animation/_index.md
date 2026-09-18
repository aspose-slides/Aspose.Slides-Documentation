---
title: 在 .NET 中於簡報套用形狀動畫
linktitle: 形狀動畫
type: docs
weight: 60
url: /zh-hant/net/shape-animation/
keywords:
- 形狀
- 動畫
- 效果
- 動畫形狀
- 動畫文字
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
description: "了解如何使用 Aspose.Slides for .NET 新增、檢查並自訂形狀動畫、時間設定、聲音、動畫結束後的行為，以及動畫文字。"
---
## **概述**

若要使用效果中的各個行為或編輯動態路徑段，請參閱[Custom Animation](/slides/zh-hant/net/custom-animation/)。

Aspose.Slides for .NET 將投影片動畫表示為投影片時間軸中的效果。每個效果具有目標形狀、動畫類型與子類型、觸發條件、時間設定，以及聲音或動畫結束後行為等可選屬性。

時間軸包含兩種序列：

- **主要序列** 會在投影片前進時播放。
- **互動序列** 會在其觸發形狀被點擊時開始。

由於文字方塊、圖片、圖表、表格及其他投影片物件皆實作[IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/)，您可以對大多數投影片內容使用相同的[ISequence.AddEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/isequence/addeffect/)方法。可用的效果列於[EffectType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/effecttype/)列舉中。

## **新增形狀動畫**

若要新增動畫，取得投影片的主要序列，並以目標形狀、效果類型、子類型與觸發條件呼叫[ISequence.AddEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/isequence/addeffect/)。若要在點擊另一個形狀時開始的效果，請建立觸發該形狀的互動序列。

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

觸發條件決定效果何時開始：

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/effecttriggertype/) 在主要序列中等待點擊，或在互動序列中等待觸發形狀的點擊。
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/effecttriggertype/) 與前一個效果同時開始。
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/effecttriggertype/) 在前一個效果完成後開始。

若要為圖片、圖表或其他形狀類型設定動畫，請將該物件傳遞給[ISequence.AddEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/isequence/addeffect/)，而非`targetShape`。有關圖表專屬的分組選項，請參閱[Animated Charts](/slides/zh-hant/net/animated-charts/)。

## **讀取形狀動畫**

當已知目標形狀時，請使用[ISequence.GetEffectsByShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/isequence/geteffectsbyshape/)。若要檢查每個效果，請列舉主要序列與所有互動序列。列舉可避免假設序列在索引 `0` 處一定有效果。

以下範例建立具有主要序列與互動效果的形狀，取得針對該形狀的效果，然後列舉投影片上的每個序列。

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

如果只需要單一形狀的效果，請先依名稱、占位符類型或其他穩定屬性識別該形狀；然後呼叫[ISequence.GetEffectsByShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/isequence/geteffectsbyshape/)。不要假設索引 `0` 的[IShapeCollection.Item](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/item/)必定是目標物件。

## **使用繼承的占位符效果**

普通投影片上的占位符可以繼承其版面投影片與母片投影片中對應占位符的動畫行為。[IShape.GetBasePlaceholder](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/getbaseplaceholder/)會回傳該父占位符，若無父占位符則回傳`null`。

在以下範例簡報中，頁腳在普通投影片上使用**Random Bars**，在版面投影片上使用**Split**，在母片投影片上使用**Fly In**。

![普通投影片上的頁腳動畫效果](slide-shape-animation.png)

![版面投影片上的頁腳占位符動畫效果](layout-shape-animation.png)

![母片投影片上的頁腳占位符動畫效果](master-shape-animation.png)

下一個範例自行建立占位符層級。它向母片占位符、版面占位符以及普通投影片上的對應占位符加入效果。每次呼叫[IShape.GetBasePlaceholder](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/getbaseplaceholder/)後，都會檢查回傳的形狀再使用。

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

## **變更動畫時間設定**

PowerPoint 的 **Timing** 對話方塊對應至[ITiming](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/)的屬性。

![動畫效果的 PowerPoint Timing 對話方塊](shape-animation.png)

- **開始** 對應至[ITiming.TriggerType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/triggertype/)。
- **持續時間** 對應至[ITiming.Duration](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/duration/)，（以秒為單位）。
- **延遲** 對應至[ITiming.TriggerDelayTime](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/triggerdelaytime/)，（以秒為單位）。
- **重複** 對應至[ITiming.RepeatCount](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/repeatcount/)、[ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/repeatuntilnextclick/)或[ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/repeatuntilendslide/)。
- **播放完成後倒帶** 對應至[ITiming.Rewind](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/rewind/)。

此獨立範例加入效果，透過[ISequence.AddEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/isequence/addeffect/)回傳的物件變更其時間設定，並儲存結果。保留回傳的[IEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/)參考可避免不必要的集合索引。

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

請明確使用單一的重複模式。將重複次數與「直到」旗標同時使用，可能在不同檢視器中產生混亂結果。變更重複模式時，請先設定[ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/repeatuntilnextclick/)與[ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/repeatuntilendslide/)，再設定[ITiming.RepeatCount](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/repeatcount/)，因為設定任一旗標會同時變更啟用的重複模式。

## **新增與擷取動畫聲音**

動畫效果可透過[IEffect.Sound](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/sound/)參考嵌入的音訊。[IEffect.StopPreviousSound](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/stopprevioussound/) 讓效果停止先前效果所啟動的音訊。

### **為效果新增聲音**

以下範例假設本機有名為`animation-sound.wav`的音訊檔案。它建立兩個效果，將該檔案嵌入為第一個效果的聲音，並設定第二個效果停止該聲音。它使用[ISequence.AddEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/isequence/addeffect/)回傳的物件，因此不需要序列索引。

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

以下範例假設本機有名為`presentation-with-animation-sounds.pptx`的簡報。它掃描主要與互動序列，將每個嵌入的效果聲音寫入`extracted-animation-sounds`目錄。副檔名根據[IAudio.ContentType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iaudio/contenttype/)所提供的音訊 MIME 類型選取。

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

針對大型音訊物件，請使用[IAudio.GetStream](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iaudio/getstream/)，將串流複製至檔案，而非將整個物件載入為位元組陣列。

## **設定動畫結束後的行為**

**After animation**（動畫結束後）選項控制形狀在效果完成後的處理方式。

![PowerPoint 效果選項對話方塊顯示 After animation 設定](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/afteranimationtype/)列舉支援保持形狀不變、變更其顏色、在動畫結束後隱藏，或在下一次點擊時隱藏。當類型為[AfterAnimationType.Color](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/afteranimationtype/)時，亦需設定[IEffect.AfterAnimationColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/afteranimationcolor/)。

此獨立範例建立一個效果，透過回傳的效果物件設定其動畫結束後的行為，並儲存結果。

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

將類型從[AfterAnimationType.Color](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/afteranimationtype/)改變為其他值會清除動畫結束後的顏色設定。

## **文字動畫**

文字動畫有兩個相關控制項：

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itextanimation/buildtype/) 控制段落是一起出現還是逐段顯示。
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/animatetexttype/) 控制文字是一次全部顯示、逐字或逐字母顯示。[IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/delaybetweentextparts/) 設定單字或字母之間的延遲。正值代表效果持續時間的百分比，負值則為秒數延遲。

以下獨立範例為文字方塊中的單字加入動畫。[BuildType.AsOneObject](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/buildtype/) 會停用逐段落建構，使單字設定套用於整個文字框。

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

若要逐段落建立文字方塊，請設定[BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/buildtype/)（或其他段落層級）。若要針對單一段落套用獨立效果，請使用接受[IParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraph/)的[ISequence.AddEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/isequence/addeffect/)重載。請參閱[Animated Text](/slides/zh-hant/net/animated-text/) 以取得段落層級的範例。

## **匯出與相容性說明**

- 將檔案儲存為 PPT 或 PPTX 會保留動畫模型，但最終播放由簡報檢視器控制。
- PDF 與靜態圖像不會播放動畫。若輸出必須呈現動態，請使用[HTML5 export](/slides/zh-hant/net/export-to-html5/)、動畫 GIF，或[video conversion](/slides/zh-hant/net/convert-powerpoint-to-video/)。
- 對於 HTML5，請啟用[Html5Options.AnimateShapes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/html5options/animateshapes/)，必要時再啟用[Html5Options.AnimateTransitions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/html5options/animatetransitions/)。
- 影片轉換支援許多常見的進入、強調、退出與動態路徑效果，但並非所有 PowerPoint 效果皆受支援。請檢查目前的[supported animations and effects](/slides/zh-hant/net/convert-powerpoint-to-video/#supported-animations-and-effects) 並以目標 Aspose.Slides 版本測試關鍵簡報。
- 進階自訂效果以及從其他簡報格式匯入的效果可能會在檔案中保留，但在 PowerPoint、HTML5 或影片中呈現方式可能不同。請驗證匯出結果，而非僅僅依賴效果名稱。

## **常見問題**

**為什麼動畫在 PowerPoint 中會出現，但在 PDF 中不會？**

PDF 為靜態格式，故不會播放動畫與投影片切換。若必須保留動態，請匯出為 HTML5、動畫 GIF，或影片。

**為什麼效果在影片中播放會不同？**

影片匯出會將動畫渲染成影片，而非保留原始 PowerPoint 的行為。某些進階效果未受支援或僅為近似。請查閱支援的效果表，並在正式使用前測試實際簡報。

**將形狀前移或後移會改變動畫的播放順序嗎？**

不會。形狀的 Z 軸順序決定重疊層級，序列順序與觸發條件決定動畫播放。若需不同的播放順序，請調整時間軸。