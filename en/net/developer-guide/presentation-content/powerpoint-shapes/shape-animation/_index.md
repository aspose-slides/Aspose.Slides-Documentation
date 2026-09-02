---
title: Apply Shape Animations in Presentations in .NET
linktitle: Shape Animation
type: docs
weight: 60
url: /net/shape-animation/
keywords:
- shape
- animation
- effect
- animated shape
- animated text
- add animation
- get animation
- extract animation
- add effect
- get effect
- extract effect
- effect sound
- apply animation
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Learn how to add, inspect, and customize shape animations, timing, sounds, after-animation behavior, and animated text with Aspose.Slides for .NET."
---

## **Overview**

Aspose.Slides for .NET represents slide animations as effects in a slide timeline. An effect has a target shape, an animation type and subtype, a trigger, timing settings, and optional properties such as sound or after-animation behavior.

The timeline contains two kinds of sequences:

- The **main sequence** plays as the slide advances.
- An **interactive sequence** starts when its trigger shape is clicked.

Because text boxes, pictures, charts, tables, and other slide objects implement [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), you use the same [ISequence.AddEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/addeffect/) method for most slide content. The available effects are listed in the [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype/) enumeration.

## **Add Shape Animations**

To add an animation, get the slide's main sequence and call [ISequence.AddEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/addeffect/) with the target shape, effect type, subtype, and trigger. For an effect that starts when another shape is clicked, create an interactive sequence whose trigger is that other shape.

The following example creates both types of animation and saves the result to `shape-animations.pptx`.

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

The trigger controls when an effect starts:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttriggertype/) waits for a click in the main sequence, or for a click on the trigger shape in an interactive sequence.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttriggertype/) starts with the preceding effect.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttriggertype/) starts when the preceding effect finishes.

To animate a picture, chart, or another shape type, pass that object to [ISequence.AddEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/addeffect/) instead of `targetShape`. For chart-specific grouping options, see [Animated Charts](/slides/net/animated-charts/).

## **Read Shape Animations**

Use [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/geteffectsbyshape/) when you know the target shape. To inspect every effect, enumerate the main sequence and every interactive sequence. Enumeration avoids assuming that a sequence contains an effect at index `0`.

The following example creates a shape with main-sequence and interactive effects, gets the effects that target the shape, and then enumerates every sequence on the slide.

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

If you only need the effects for one shape, first identify the shape by name, placeholder type, or another stable property; then call [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/geteffectsbyshape/). Do not assume that [IShapeCollection.Item](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/item/) at index `0` is always the intended object.

## **Work with Inherited Placeholder Effects**

A placeholder on a normal slide can inherit animation behavior from the corresponding placeholder on its layout slide and master slide. [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) returns that parent placeholder, or `null` when no parent exists.

In the following example presentation, the footer has **Random Bars** on the normal slide, **Split** on the layout slide, and **Fly In** on the master slide.

![Footer animation effect on the normal slide](slide-shape-animation.png)

![Footer placeholder animation effect on the layout slide](layout-shape-animation.png)

![Footer placeholder animation effect on the master slide](master-shape-animation.png)

The next example builds the placeholder hierarchy itself. It adds effects to a master placeholder, a layout placeholder, and the corresponding placeholder on a normal slide. Every call to [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) is checked before the returned shape is used.

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

## **Change Animation Timing**

The PowerPoint **Timing** dialog maps to the properties of [ITiming](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/).

![PowerPoint Timing dialog for an animation effect](shape-animation.png)

- **Start** maps to [ITiming.TriggerType](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/triggertype/).
- **Duration** maps to [ITiming.Duration](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/duration/), in seconds.
- **Delay** maps to [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/triggerdelaytime/), in seconds.
- **Repeat** maps to [ITiming.RepeatCount](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatcount/), [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilnextclick/), or [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilendslide/).
- **Rewind when done playing** maps to [ITiming.Rewind](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/rewind/).

This independent example adds an effect, changes its timing through the object returned by [ISequence.AddEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/addeffect/), and saves the result. Keeping the returned [IEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/) reference avoids an unnecessary collection index.

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

Use one repeat mode intentionally. Combining a repeat count with an "until" flag can produce confusing results in different viewers. When changing repeat modes, set [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilnextclick/) and [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilendslide/) before [ITiming.RepeatCount](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatcount/), because setting either flag also changes the active repeat mode.

## **Add and Extract Animation Sounds**

An animation effect can reference embedded audio through [IEffect.Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/sound/). [IEffect.StopPreviousSound](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/stopprevioussound/) tells an effect to stop audio started by an earlier effect.

### **Add a Sound to an Effect**

The following example expects a local audio file named `animation-sound.wav`. It creates two effects, embeds that file as the sound for the first effect, and configures the second effect to stop the sound. It uses the objects returned by [ISequence.AddEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/addeffect/), so no sequence index is required.

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

### **Extract Embedded Effect Sounds**

The following example expects a local presentation named `presentation-with-animation-sounds.pptx`. It scans both main and interactive sequences and writes every embedded effect sound to the `extracted-animation-sounds` directory. The extension is selected from the audio MIME type exposed by [IAudio.ContentType](https://reference.aspose.com/slides/net/aspose.slides/iaudio/contenttype/).

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

For large audio objects, use [IAudio.GetStream](https://reference.aspose.com/slides/net/aspose.slides/iaudio/getstream/) and copy the stream to a file instead of loading the entire object into a byte array.

## **Set After-Animation Behavior**

The **After animation** option controls what happens to a shape after its effect finishes.

![PowerPoint Effect Options dialog showing After animation settings](shape-after-animation.png)

The [AfterAnimationType](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) enumeration supports leaving the shape unchanged, changing its color, hiding it after the animation, or hiding it on the next click. When the type is [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/), set [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationcolor/) as well.

This independent example creates an effect, sets its after-animation behavior through the returned effect object, and saves the result.

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

Changing the type away from [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) clears the after-animation color setting.

## **Animate Text**

Text animation has two related controls:

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/itextanimation/buildtype/) controls whether paragraphs appear together or by paragraph level.
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) controls whether text appears all at once, by word, or by letter. [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) sets the delay between words or letters. A positive value is a percentage of the effect duration; a negative value is a delay in seconds.

The following independent example animates the words in a text box. [BuildType.AsOneObject](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype/) disables paragraph-by-paragraph building so that the word setting applies to the entire text frame.

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

To build a text box by paragraph, set [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype/) (or another paragraph level). To target a single paragraph with its own effect, use the [ISequence.AddEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/addeffect/) overload that accepts an [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/). See [Animated Text](/slides/net/animated-text/) for paragraph-level examples.

## **Export and Compatibility Notes**

- Saving to PPT or PPTX preserves the animation model, but the final playback is controlled by the presentation viewer.
- PDF and static images do not play animations. Use [HTML5 export](/slides/net/export-to-html5/), animated GIF, or [video conversion](/slides/net/convert-powerpoint-to-video/) when the output must show motion.
- For HTML5, enable [Html5Options.AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) and, when needed, [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/).
- Video rendering supports many common entrance, emphasis, exit, and motion-path effects, but not every PowerPoint effect is supported. Check the current [supported animations and effects](/slides/net/convert-powerpoint-to-video/#supported-animations-and-effects) and test critical presentations with your target Aspose.Slides version.
- Advanced custom effects and effects imported from other presentation formats may be preserved in the file but render differently in PowerPoint, HTML5, or video. Validate the exported result rather than relying only on the effect name.

## **FAQ**

**Why does an animation appear in PowerPoint but not in a PDF?**

PDF is a static format, so animations and slide transitions do not play. Export to HTML5, animated GIF, or video when motion must be preserved.

**Why does an effect play differently in a video?**

Video export renders animations rather than storing the original PowerPoint behavior. Some advanced effects are unsupported or approximated. Review the supported-effects table and test the actual presentation before production use.

**Does moving a shape forward or backward change its animation order?**

No. Shape z-order controls overlap, while sequence order and triggers control animation playback. Change the timeline if you need a different playback order.
