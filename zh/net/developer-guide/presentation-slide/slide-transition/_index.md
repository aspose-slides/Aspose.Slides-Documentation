---
title: 管理 .NET 中演示文稿的幻灯片转换
linktitle: 幻灯片转换
type: docs
weight: 90
url: /zh/net/slide-transition/
keywords:
- 幻灯片转换
- 添加幻灯片转换
- 应用幻灯片转换
- 高级幻灯片转换
- Morph 转换
- 转换类型
- 转换效果
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 应用幻灯片转换，配置自动幻灯片前进，并自定义 Morph 和其他转换效果。"
---
## **概述**

幻灯片转换控制幻灯片在播放演示时的出现方式。使用 Aspose.Slides for .NET，您可以为每张幻灯片选择一种转换效果，配置通过鼠标点击或计时器进行切换，并调整特定于某种效果的选项。本文使用 C# 示例演示如何应用转换、设置精确的转换时长、管理幻灯片计时，以及在两张幻灯片之间创建 Morph 转换。示例还展示了如何将设置保存为 PPTX 文件。

## **添加幻灯片转换**

要应用转换，请使用 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类加载演示文稿，然后访问幻灯片的 [SlideShowTransition](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseslide/slideshowtransition/) 属性。将其 [Type](https://reference.aspose.com/slides/zh/net/aspose.slides/islideshowtransition/type/) 设置为 [TransitionType](https://reference.aspose.com/slides/zh/net/aspose.slides.slideshow/transitiontype/) 枚举中的值，然后保存演示文稿。

下面的示例对第一张幻灯片应用 Circle 转换，对第二张幻灯片应用 Comb 转换。请使用至少包含两张幻灯片的 `input.pptx` 文件。

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

## **添加高级幻灯片转换**

您可以配置幻灯片在屏幕上停留的时间以及是否通过鼠标点击推进幻灯片放映。以下属性控制此行为：

- [AdvanceOnClick](https://reference.aspose.com/slides/zh/net/aspose.slides/islideshowtransition/advanceonclick/) 允许观众通过点击鼠标前进。
- [AdvanceAfter](https://reference.aspose.com/slides/zh/net/aspose.slides/islideshowtransition/advanceafter/) 启用自动前进。
- [AdvanceAfterTime](https://reference.aspose.com/slides/zh/net/aspose.slides/islideshowtransition/advanceaftertime/) 指定自动前进前的延迟（毫秒）。

同时启用点击和计时前进，使观众可以点击前进或等待计时器。若只使用计时器，请将 [AdvanceOnClick](https://reference.aspose.com/slides/zh/net/aspose.slides/islideshowtransition/advanceonclick/) 设置为 `false`。延迟控制幻灯片放映何时前进；它并不设定可视转换效果的时长。

此示例为前三张幻灯片分别分配不同的效果，并在 3、5、7 秒后自动前进。鼠标点击同样可以前进这些幻灯片。请使用至少包含三张幻灯片的 `input.pptx` 文件。

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

要检查是否启用了计时前进，请读取 [AdvanceAfter](https://reference.aspose.com/slides/zh/net/aspose.slides/islideshowtransition/advanceafter/)。仅存储的延迟并不表示计时器已激活。

下面的示例打开上面保存的文件，报告每个已启用的计时器，并对延迟超过两秒的幻灯片禁用自动前进。它为这些幻灯片启用鼠标点击，并保存更新后的设置。

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

## **精确控制转换计时**

使用 [Duration](https://reference.aspose.com/slides/zh/net/aspose.slides.slideshow/slideshowtransition/duration/) 可指定转换效果的精确时长（毫秒）。幻灯片的 [SlideShowTransition](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseslide/slideshowtransition/) 属性通过 [ISlideShowTransition](https://reference.aspose.com/slides/zh/net/aspose.slides/islideshowtransition/) 暴露这些设置：

| 属性 | 用途 |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/zh/net/aspose.slides.slideshow/slideshowtransition/duration/) | 设置转换效果本身的时长（毫秒）。 |
| [AdvanceAfterTime](https://reference.aspose.com/slides/zh/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | 设置幻灯片自动前进前的延迟（毫秒）。需启用 [AdvanceAfter](https://reference.aspose.com/slides/zh/net/aspose.slides/islideshowtransition/advanceafter/) 才会启动计时器。 |
| [Speed](https://reference.aspose.com/slides/zh/net/aspose.slides.slideshow/slideshowtransition/speed/) | 从 [TransitionSpeed](https://reference.aspose.com/slides/zh/net/aspose.slides.slideshow/transitionspeed/) 中选择预定义的速度类别：Slow、Medium 或 Fast。仅在未指定精确时长时使用。 |

[Duration](https://reference.aspose.com/slides/zh/net/aspose.slides.slideshow/slideshowtransition/duration/) 仅控制转换效果；它不决定幻灯片保持可见的时长。请分别配置自动前进的延迟。当未设置显式时长时，Aspose.Slides 会根据转换类型和 [Speed](https://reference.aspose.com/slides/zh/net/aspose.slides.slideshow/slideshowtransition/speed/) 值计算效果时长。

### **对每张幻灯片应用相同的时长**

为了保持节奏一致，可对每张幻灯片使用相同的效果和精确时长。此示例加载 `input.pptx`，从 [TransitionType](https://reference.aspose.com/slides/zh/net/aspose.slides.slideshow/transitiontype/) 中选择 Fade，并为每个转换设置 750 毫秒的时长。它分别启用 5,000 毫秒后的自动前进，并禁用鼠标点击前进，最后将结果保存为 PPTX。

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

    // 配置自动前进，使其独立于效果时长。
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **为单独幻灯片设置不同的时长**

不同的幻灯片可以使用不同的效果时长。例如，对标题页使用较短的转换，对章节引入使用较长的转换。此示例为第一张幻灯片设置 500 毫秒，第二张幻灯片设置 1,200 毫秒。请使用至少包含两张幻灯片的 `input.pptx` 文件。

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

### **与动画输出同步转换**

在准备 [animated GIF](/slides/zh/net/convert-powerpoint-to-animated-gif/)、[HTML5 presentation](/slides/zh/net/export-to-html5/) 或 [video](/slides/zh/net/convert-powerpoint-to-video/) 时，请在导出前设置精确的转换时长，以匹配预期的节奏。例如，在场景之间使用 600 毫秒的淡入淡出，并分别调整每张幻灯片的前进延迟，以留出旁白或内容展示的时间。

对于 GIF 和视频，需要将输出帧率与效果时长对应：600 毫秒相当于 30 帧/秒下的 18 帧。对于 HTML5，在导出设置中启用动画转换。请检查所选导出格式支持的转换效果与计时选项，并预览输出以确认同步。

### **读取现有的转换时长**

在修改转换之前读取 [Duration](https://reference.aspose.com/slides/zh/net/aspose.slides.slideshow/slideshowtransition/duration/)，以确定是否存有显式值。`-1` 表示未设置显式时长；非负值表示存储的毫秒时长。未设置的值并非计算后的播放时长：Aspose.Slides 会依据转换类型和 [Speed](https://reference.aspose.com/slides/zh/net/aspose.slides.slideshow/slideshowtransition/speed/) 确定该时长。设置转换类型可能会初始化时长，因此请先检查原始设置。

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

## **Morph 转换**

Morph 转换在连续幻灯片之间对对象的变化进行动画化。要创建简单的 Morph 效果，可克隆幻灯片，在克隆上移动或调整对象大小，然后对第二张幻灯片应用 Morph 转换。这样会让对应的对象在原始状态和修改后状态之间进行动画。

以下示例创建一个包含文本矩形的幻灯片，克隆该幻灯片，并在克隆上更改矩形的位置和大小。然后为第二张幻灯片在 [TransitionType](https://reference.aspose.com/slides/zh/net/aspose.slides.slideshow/transitiontype/) 枚举中选择 Morph。使用支持 Morph 的演示文稿查看器打开保存的文件，即可在放映时看到效果。

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

## **Morph 转换类型**

[TransitionMorphType](https://reference.aspose.com/slides/zh/net/aspose.slides.slideshow/transitionmorphtype/) 枚举控制 Morph 如何匹配并动画化内容：

- [ByObject](https://reference.aspose.com/slides/zh/net/aspose.slides.slideshow/transitionmorphtype/) 将每个形状视为整体对象。
- [ByWord](https://reference.aspose.com/slides/zh/net/aspose.slides.slideshow/transitionmorphtype/) 在可能的情况下按单词匹配动画文本。
- [ByChar](https://reference.aspose.com/slides/zh/net/aspose.slides.slideshow/transitionmorphtype/) 在可能的情况下按字符匹配动画文本。

在访问其 [Value](https://reference.aspose.com/slides/zh/net/aspose.slides/islideshowtransition/value/) 之前，将转换的 [Type](https://reference.aspose.com/slides/zh/net/aspose.slides/islideshowtransition/type/) 设置为 Morph。此值随后提供 [IMorphTransition](https://reference.aspose.com/slides/zh/net/aspose.slides.slideshow/imorphtransition/) 接口，其 [MorphType](https://reference.aspose.com/slides/zh/net/aspose.slides.slideshow/imorphtransition/morphtype/) 属性选择匹配模式。

此示例打开前一节创建的演示文稿，并将第二张幻灯片配置为基于单词的 Morph 动画。

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

## **设置转换效果**

某些转换公开额外选项，例如方向或是否从黑屏开始。可用选项取决于所选转换的 [Type](https://reference.aspose.com/slides/zh/net/aspose.slides/islideshowtransition/type/)。先设置类型，然后使用其 [Value](https://reference.aspose.com/slides/zh/net/aspose.slides/islideshowtransition/value/) 中的相应接口。

以下示例对 `input.pptx` 的第一张幻灯片应用 Cut 转换。它通过 [IOptionalBlackTransition](https://reference.aspose.com/slides/zh/net/aspose.slides.slideshow/ioptionalblacktransition/) 的 [FromBlack](https://reference.aspose.com/slides/zh/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) 将转换设置为从黑屏开始。

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

## **常见问题**

**我可以控制幻灯片转换的播放速度吗？**

可以。当需要以毫秒为单位的精确效果时长时，请优先使用 [Duration](https://reference.aspose.com/slides/zh/net/aspose.slides.slideshow/slideshowtransition/duration/)。如果预定义的 [TransitionSpeed](https://reference.aspose.com/slides/zh/net/aspose.slides.slideshow/transitionspeed/)（Slow、Medium、Fast）足够且未设置显式时长，则使用 [Speed](https://reference.aspose.com/slides/zh/net/aspose.slides.slideshow/slideshowtransition/speed/)。这些设置独立于自动前进延迟，控制转换效果本身。

**我可以为转换附加音频并让其循环播放吗？**

可以。将嵌入的音频分配给 [Sound](https://reference.aspose.com/slides/zh/net/aspose.slides/islideshowtransition/sound/)，将 [SoundMode](https://reference.aspose.com/slides/zh/net/aspose.slides/islideshowtransition/soundmode/) 设置为 [TransitionSoundMode](https://reference.aspose.com/slides/zh/net/aspose.slides.slideshow/transitionsoundmode/) 枚举中的 StartSound，并启用 [SoundLoop](https://reference.aspose.com/slides/zh/net/aspose.slides/islideshowtransition/soundloop/)。音频将在幻灯片放映的下一次声音事件之前循环播放。

**将相同转换应用于所有幻灯片的最快方法是什么？**

遍历演示文稿的 [Slides](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/slides/zh/) 集合，在循环中将每张幻灯片的转换 [Type](https://reference.aspose.com/slides/zh/net/aspose.slides/islideshowtransition/type/) 设置为相同的值。将任何计时和效果选项也放在同一循环中，以保持各幻灯片行为一致。

**如何检查当前幻灯片上设置的转换类型？**

读取幻灯片的 [SlideShowTransition](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseslide/slideshowtransition/) 中的 [Type](https://reference.aspose.com/slides/zh/net/aspose.slides/islideshowtransition/type/) 属性。它返回 [TransitionType](https://reference.aspose.com/slides/zh/net/aspose.slides.slideshow/transitiontype/) 枚举中的值；None 表示未应用任何转换效果。