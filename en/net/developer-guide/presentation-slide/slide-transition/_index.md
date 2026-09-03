---
title: Manage Slide Transitions in Presentations in .NET
linktitle: Slide Transition
type: docs
weight: 90
url: /net/slide-transition/
keywords:
- slide transition
- add slide transition
- apply slide transition
- advanced slide transition
- morph transition
- transition type
- transition effect
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Apply slide transitions, configure automatic slide advancement, and customize Morph and other transition effects with Aspose.Slides for .NET."
---

## **Overview**

Slide transitions control how slides appear during a slide show. With Aspose.Slides for .NET, you can choose a transition effect for each slide, configure advancement by mouse click or timer, and adjust options specific to an effect. This article uses C# examples to apply transitions, set exact transition durations, manage slide timing, and create a Morph transition between two slides. The examples also show how to save the settings to a PPTX file.

## **Add Slide Transition**

To apply a transition, load a presentation with the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class and access the slide's [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) property. Set its [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) to a value from the [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) enumeration, then save the presentation.

The following example applies a Circle transition to the first slide and a Comb transition to the second. Use an `input.pptx` file with at least two slides.

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

## **Add Advanced Slide Transition**

You can configure how long a slide remains on screen and whether a mouse click advances the slide show. The following properties control this behavior:

- [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) allows the viewer to advance by clicking the mouse.
- [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) enables automatic advancement.
- [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceaftertime/) specifies the delay before automatic advancement, in milliseconds.

Enable both click and timed advancement to let the viewer move on with a click or wait for the timer. To use only the timer, set [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) to `false`. The delay controls when the slide show advances; it does not set the duration of the visual transition effect.

This example assigns different effects to the first three slides and enables automatic advancement after 3, 5, and 7 seconds, respectively. Mouse clicks can also advance these slides. Use an `input.pptx` file with at least three slides.

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

To check whether timed advancement is enabled, read [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/). A stored delay alone does not indicate that the timer is active.

The next example opens the file saved above, reports each enabled timer, and disables automatic advancement for slides with a delay greater than two seconds. It enables mouse clicks for those slides and saves the updated settings.

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

## **Control Transition Timing Precisely**

Use [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) to specify the exact length of a transition effect in milliseconds. The slide's [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) property exposes these settings through [ISlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/):

| Property | Purpose |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) | Sets the duration of the transition effect itself, in milliseconds. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Sets the delay before the slide advances automatically, in milliseconds. Enable [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) to activate this timer. |
| [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) | Selects a predefined speed category from [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium, or Fast. It is used when an exact duration is not specified. |

[Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) controls only the transition effect; it does not determine how long the slide remains visible. Configure the automatic advancement delay separately. When no explicit duration is set, Aspose.Slides determines the effect duration from the transition type and [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) value.

### **Apply the Same Duration to Every Slide**

For consistent pacing, apply the same effect and exact duration to every slide. This example loads `input.pptx`, selects Fade from [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/), and gives each transition a duration of 750 milliseconds. It separately enables automatic advancement after 5,000 milliseconds and disables advancement by mouse click, then saves the result as PPTX.

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

    // Configure automatic advancement independently of the effect duration.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **Set Different Durations for Individual Slides**

Different slides can use different effect durations. For example, use a brief transition for a title slide and a longer transition for a section introduction. This example sets 500 milliseconds for the first slide and 1,200 milliseconds for the second. Use an `input.pptx` file with at least two slides.

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

### **Coordinate Transitions with Animated Output**

When preparing an [animated GIF](/slides/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/net/export-to-html5/), or [video](/slides/net/convert-powerpoint-to-video/), set exact transition durations before export to match the intended pacing. For example, use a 600-millisecond fade between scenes, and adjust each slide's advancement delay separately to allow time for its narration or content.

For GIF and video, coordinate the output frame rate with the effect duration: 600 milliseconds corresponds to 18 frames at 30 frames per second. In HTML5, enable animated transitions in the export settings. Check the chosen export format's supported effects and timing options, and preview the output to confirm synchronization.

### **Read an Existing Transition Duration**

Read [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) before modifying the transition to determine whether an explicit value is stored. A value of `-1` means no explicit duration is set; a nonnegative value specifies the stored duration in milliseconds. The unset value is not the calculated playback duration: Aspose.Slides uses the transition type and [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) to determine that duration. Setting a transition type can initialize a duration, so inspect the original settings first.

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

## **Morph Transition**

The Morph transition animates changes between objects on consecutive slides. To create a simple Morph effect, clone a slide, move or resize an object on the clone, and apply the Morph transition to the second slide. This gives the transition corresponding objects to animate between their original and modified states.

The following example creates a slide with a text rectangle, clones the slide, and changes the rectangle's position and size on the clone. It then selects Morph from the [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) enumeration for the second slide. Open the saved file in a presentation viewer that supports Morph to see the effect during a slide show.

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

## **Morph Transition Types**

The [TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) enumeration controls how Morph matches and animates content:

- [ByObject](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) treats each shape as a whole object.
- [ByWord](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) animates text by matching words where possible.
- [ByChar](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) animates text by matching characters where possible.

Set the transition [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) to Morph before accessing its [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/). The value then provides the [IMorphTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/) interface, whose [MorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/morphtype/) property selects the matching mode.

This example opens the presentation created in the previous section and configures the second slide to use word-based Morph animation.

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

## **Set Transition Effects**

Some transitions expose additional options, such as direction or whether the effect starts from a black screen. The available options depend on the selected transition [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/). Set the type first, then use the appropriate interface from its [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/).

The following example applies a Cut transition to the first slide of `input.pptx`. It sets [FromBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) through [IOptionalBlackTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/) so that the transition starts from a black screen.

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
