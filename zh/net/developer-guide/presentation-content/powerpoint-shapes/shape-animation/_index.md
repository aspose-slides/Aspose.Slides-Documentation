---
title: 在 .NET 演示文稿中应用形状动画
linktitle: 形状动画
type: docs
weight: 60
url: /zh/net/shape-animation/
keywords:
- 形状
- 动画
- 效果
- 动画形状
- 动画文本
- 添加动画
- 获取动画
- 提取动画
- 添加效果
- 获取效果
- 提取效果
- 效果声音
- 应用动画
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 添加、检查和自定义形状动画、时间设置、声音、动画后行为以及动画文本。"
---
## **概述**

Aspose.Slides for .NET 将幻灯片动画表示为幻灯片时间轴中的效果。每个效果具有目标形状、动画类型和子类型、触发器、时间设置以及诸如声音或动画后行为等可选属性。

时间轴包含两种序列：

- **主序列** 在幻灯片前进时播放。
- **交互序列** 在其触发形状被点击时启动。

由于文本框、图片、图表、表格和其他幻灯片对象实现了 [IShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/)，您可以对大多数幻灯片内容使用相同的 [ISequence.AddEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/isequence/addeffect/) 方法。可用的效果列在 [EffectType](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/effecttype/) 枚举中。

## **添加形状动画**

要添加动画，请获取幻灯片的主序列并调用 [ISequence.AddEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/isequence/addeffect/)，提供目标形状、效果类型、子类型和触发器。若要在另一形状被点击时启动效果，请创建触发器为该形状的交互序列。

以下示例创建两种类型的动画并将结果保存为 `shape-animations.pptx`。

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

触发器控制效果何时开始：

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/effecttriggertype/) 在主序列中等待点击，或在交互序列中等待对触发形状的点击。
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/effecttriggertype/) 与前一个效果同时开始。
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/effecttriggertype/) 在前一个效果完成后开始。

要为图片、图表或其他形状类型添加动画，请将该对象传递给 [ISequence.AddEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/isequence/addeffect/) 而不是 `targetShape`。有关图表特定的分组选项，请参阅 [Animated Charts](/slides/zh/net/animated-charts/)。

## **读取形状动画**

当已知目标形状时，使用 [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/isequence/geteffectsbyshape/)。若要检查每个效果，请枚举主序列和所有交互序列。枚举可避免假设序列在索引 `0` 处包含效果。

以下示例创建一个具有主序列和交互效果的形状，获取针对该形状的效果，然后枚举幻灯片上的每个序列。

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

如果仅需要单个形状的效果，请先通过名称、占位符类型或其他稳定属性识别该形状；然后调用 [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/isequence/geteffectsbyshape/)。不要假设索引 `0` 处的 [IShapeCollection.Item](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/item/) 总是目标对象。

## **处理继承的占位符效果**

普通幻灯片上的占位符可以继承其版面幻灯片和母版幻灯片上对应占位符的动画行为。[IShape.GetBasePlaceholder](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/getbaseplaceholder/) 返回该父占位符，如果不存在父占位符则返回 `null`。

在以下示例演示文稿中，页脚在普通幻灯片上使用 **Random Bars**，在版面幻灯片上使用 **Split**，在母版幻灯片上使用 **Fly In**。

![普通幻灯片上的页脚动画效果](slide-shape-animation.png)

![版面幻灯片上页脚占位符的动画效果](layout-shape-animation.png)

![母版幻灯片上页脚占位符的动画效果](master-shape-animation.png)

下面的示例自行构建占位符层次结构。它向母版占位符、版面占位符以及普通幻灯片上的对应占位符添加效果。每次调用 [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/getbaseplaceholder/) 前都会检查返回的形状是否为 null。

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

## **更改动画时间**

PowerPoint **Timing** 对话框对应 [ITiming](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/) 的属性。

![动画效果的 PowerPoint 时间设置对话框](shape-animation.png)

- **Start** 对应 [ITiming.TriggerType](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/triggertype/)。
- **Duration** 对应 [ITiming.Duration](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/duration/)（以秒为单位）。
- **Delay** 对应 [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/triggerdelaytime/)（以秒为单位）。
- **Repeat** 对应 [ITiming.RepeatCount](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/repeatcount/)、[ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/repeatuntilnextclick/) 或 [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/repeatuntilendslide/)。
- **Rewind when done playing** 对应 [ITiming.Rewind](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/rewind/)。

此独立示例添加一个效果，通过 [ISequence.AddEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/isequence/addeffect/) 返回的对象修改其时间设置，并保存结果。保留返回的 [IEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ieffect/) 引用可避免不必要的集合索引。

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

请有目的地使用单一的重复模式。将重复计数与 "until" 标志组合使用可能在不同的查看器中产生混乱的结果。更改重复模式时，请先设置 [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/repeatuntilnextclick/) 和 [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/repeatuntilendslide/)，再设置 [ITiming.RepeatCount](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/repeatcount/)，因为设置任意标志都会改变当前的重复模式。

## **添加和提取动画声音**

动画效果可以通过 [IEffect.Sound](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ieffect/sound/) 引用嵌入的音频。[IEffect.StopPreviousSound](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ieffect/stopprevioussound/) 用于指示效果停止先前效果启动的音频。

### **向效果添加声音**

以下示例假设本地存在名为 `animation-sound.wav` 的音频文件。它创建两个效果，将该文件嵌入为第一个效果的声音，并配置第二个效果停止该声音。它使用 [ISequence.AddEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/isequence/addeffect/) 返回的对象，无需序列索引。

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

### **提取嵌入的效果声音**

以下示例假设本地存在名为 `presentation-with-animation-sounds.pptx` 的演示文稿。它扫描主序列和交互序列，并将每个嵌入的效果声音写入 `extracted-animation-sounds` 目录。文件扩展名根据 [IAudio.ContentType](https://reference.aspose.com/slides/zh/net/aspose.slides/iaudio/contenttype/) 暴露的音频 MIME 类型选择。

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

对于大型音频对象，使用 [IAudio.GetStream](https://reference.aspose.com/slides/zh/net/aspose.slides/iaudio/getstream/) 并将流复制到文件，而不是将整个对象加载到字节数组中。

## **设置动画后行为**

**After animation** 选项控制效果完成后形状的处理方式。

![PowerPoint 效果选项对话框显示“After animation”设置](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/afteranimationtype/) 枚举支持保持形状不变、更改其颜色、动画结束后隐藏形状或在下一次点击时隐藏形状。当类型为 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/afteranimationtype/) 时，还需设置 [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ieffect/afteranimationcolor/)。

此独立示例创建一个效果，通过返回的效果对象设置其动画后行为，并保存结果。

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

将类型从 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/afteranimationtype/) 改为其他值会清除动画后的颜色设置。

## **动画文字**

文字动画有两个相关控制：

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itextanimation/buildtype/) 控制段落是整体出现还是逐段出现。
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ieffect/animatetexttype/) 控制文字是一次性出现、按单词还是按字母出现。[IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ieffect/delaybetweentextparts/) 设置单词或字母之间的延迟。正值表示效果持续时间的百分比，负值表示以秒为单位的延迟。

以下独立示例对文本框中的单词进行动画。[BuildType.AsOneObject](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/buildtype/) 禁用逐段构建，使单词设置适用于整个文本框。

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

若要按段落构建文本框，请设置 [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/buildtype/)（或其他段落级别）。若要为单个段落使用独立效果，请使用接受 [IParagraph](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraph/) 的 [ISequence.AddEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/isequence/addeffect/) 重载。段落级别示例请参阅 [Animated Text](/slides/zh/net/animated-text/)。

## **导出与兼容性说明**

- 保存为 PPT 或 PPTX 会保留动画模型，但最终播放由演示文稿查看器控制。
- PDF 和静态图像不会播放动画。当输出必须显示动画时，请使用 [HTML5 export](/slides/zh/net/export-to-html5/)、动画 GIF 或 [video conversion](/slides/zh/net/convert-powerpoint-to-video/)。
- 对于 HTML5，启用 [Html5Options.AnimateShapes](https://reference.aspose.com/slides/zh/net/aspose.slides.export/html5options/animateshapes/)，并在需要时启用 [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/html5options/animatetransitions/)。
- 视频渲染支持许多常见的进入、强调、退出和路径动画，但并非所有 PowerPoint 动画都受支持。请检查当前的 [supported animations and effects](/slides/zh/net/convert-powerpoint-to-video/#supported-animations-and-effects)，并在目标 Aspose.Slides 版本下测试关键演示文稿。
- 高级自定义效果以及从其他演示格式导入的效果可能会保留在文件中，但在 PowerPoint、HTML5 或视频中呈现方式不同。请验证导出结果，而不是仅依赖效果名称。

## **常见问题**

**为什么动画在 PowerPoint 中出现而在 PDF 中不出现？**

PDF 是静态格式，动画和幻灯片切换不会播放。需要保留动画时，请导出为 HTML5、动画 GIF 或视频。

**为什么效果在视频中播放不同？**

视频导出会渲染动画，而不是存储原始 PowerPoint 行为。某些高级效果不受支持或被近似。请查看支持的效果表，并在投入生产前测试实际演示文稿。

**移动形状的前后顺序会改变它的动画顺序吗？**

不会。形状的 Z 顺序控制重叠，序列顺序和触发器控制动画播放。如果需要不同的播放顺序，请更改时间轴。