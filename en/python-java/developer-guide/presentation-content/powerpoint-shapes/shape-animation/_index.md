---
title: Apply Shape Animations in Presentations Using Python via Java
linktitle: Shape Animation
type: docs
weight: 60
url: /python-java/shape-animation/
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
- Python
- Java
- Aspose.Slides
description: "Learn how to add, inspect, and customize shape animations, timing, sounds, after-animation behavior, and animated text with Aspose.Slides for Python via Java."
---

## **Overview**

Aspose.Slides for Python via Java represents slide animations as effects in a slide timeline. An effect has a target shape, an animation type and subtype, a trigger, timing settings, and optional properties such as sound or after-animation behavior.

The timeline contains two kinds of sequences:

- The **main sequence** plays as the slide advances.
- An **interactive sequence** starts when its trigger shape is clicked.

Because text boxes, pictures, charts, tables, and other slide objects derive from [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/), you use the same [Sequence.addEffect](https://reference.aspose.com/slides/python-java/aspose.slides/sequence/#addEffect) method for most slide content. The available effects are listed in the [EffectType](https://reference.aspose.com/slides/python-java/aspose.slides/effecttype/) class.

## **Add Shape Animations**

To add an animation, get the slide's main sequence and call [Sequence.addEffect](https://reference.aspose.com/slides/python-java/aspose.slides/sequence/#addEffect) with the target shape, effect type, subtype, and trigger. For an effect that starts when another shape is clicked, create an interactive sequence whose trigger is that other shape.

The following example creates both types of animation and saves the result to `shape-animations.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Click to animate this shape")

    main_sequence = slide.getTimeline().getMainSequence()
    entrance_effect = main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    entrance_effect.getTiming().setDuration(1.5)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    presentation.save("shape-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The trigger controls when an effect starts:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/effecttriggertype/#OnClick) waits for a click in the main sequence, or for a click on the trigger shape in an interactive sequence.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/python-java/aspose.slides/effecttriggertype/#WithPrevious) starts with the preceding effect.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/python-java/aspose.slides/effecttriggertype/#AfterPrevious) starts when the preceding effect finishes.

To animate a picture, chart, or another shape type, pass that object to [Sequence.addEffect](https://reference.aspose.com/slides/python-java/aspose.slides/sequence/#addEffect) instead of `target_shape`. For chart-specific grouping options, see [Animated Charts](/slides/python-java/animated-charts/).

## **Read Shape Animations**

Use [Sequence.getEffectsByShape](https://reference.aspose.com/slides/python-java/aspose.slides/sequence/#getEffectsByShape) when you know the target shape. To inspect every effect, enumerate the main sequence and every interactive sequence. Enumeration avoids assuming that a sequence contains an effect at index `0`.

The following example creates a shape with main-sequence and interactive effects, gets the effects that target the shape, and then enumerates every sequence on the slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

def print_sequence(label, sequence):
    print(f"  {label}: {sequence.getCount()} effect(s)")
    for effect in sequence:
        target_shape = effect.getTargetShape()
        target_name = "unknown" if target_shape is None else target_shape.getName()
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        trigger_name = EffectTriggerType.getName(EffectTriggerType.class_, effect.getTiming().getTriggerType())
        effect_description = f"{type_name} {subtype_name}; target: {target_name}; trigger: {trigger_name}"
        print(f"    {effect_description}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Animated shape")

    main_sequence = slide.getTimeline().getMainSequence()
    main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    target_effects = main_sequence.getEffectsByShape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.getName()}.")
    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.getTimeline().getInteractiveSequences(), start=1):
        trigger_shape = sequence.getTriggerShape()
        trigger_name = "unknown" if trigger_shape is None else trigger_shape.getName()
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
finally:
    presentation.dispose()
```

If you only need the effects for one shape, first identify the shape by name, placeholder type, or another stable property; then call [Sequence.getEffectsByShape](https://reference.aspose.com/slides/python-java/aspose.slides/sequence/#getEffectsByShape). Do not assume that [ShapeCollection.get_Item](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#get_Item) at index `0` is always the intended object.

## **Work with Inherited Placeholder Effects**

A placeholder on a normal slide can inherit animation behavior from the corresponding placeholder on its layout slide and master slide. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) returns that parent placeholder, or `None` when no parent exists.

In the following example presentation, the footer has **Random Bars** on the normal slide, **Split** on the layout slide, and **Fly In** on the master slide.

![Footer animation effect on the normal slide](slide-shape-animation.png)

![Footer placeholder animation effect on the layout slide](layout-shape-animation.png)

![Footer placeholder animation effect on the master slide](master-shape-animation.png)

The next example uses a placeholder hierarchy from a new presentation. It adds effects to a master placeholder, a layout placeholder, and the corresponding placeholder on a normal slide. Every call to [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) is checked before the returned shape is used.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, SlideLayoutType

def find_placeholder_with_base(slide, expected_base=None):
    for shape in slide.getShapes():
        base_placeholder = shape.getBasePlaceholder()
        if base_placeholder is not None and (expected_base is None or base_placeholder == expected_base):
            return shape
    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")
    for effect in effects:
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        print(f"  {type_name} {subtype_name}")


presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)
    layout_placeholder = find_placeholder_with_base(layout_slide) if layout_slide is not None else None
    if layout_placeholder is None:
        print("The layout slide does not contain a placeholder linked to its master slide.")
    else:
        master_placeholder = layout_placeholder.getBasePlaceholder()
        layout_slide.getMasterSlide().getTimeline().getMainSequence().addEffect(master_placeholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
        layout_slide.getTimeline().getMainSequence().addEffect(layout_placeholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick)

        slide = presentation.getSlides().addEmptySlide(layout_slide)
        slide_placeholder = find_placeholder_with_base(slide, layout_placeholder)
        if slide_placeholder is None:
            print("The slide does not contain a placeholder linked to its layout slide.")
        else:
            slide.getTimeline().getMainSequence().addEffect(slide_placeholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick)
            slide_effects = slide.getTimeline().getMainSequence().getEffectsByShape(slide_placeholder)
            print_effects("Normal slide", slide_effects)

            base_layout_placeholder = slide_placeholder.getBasePlaceholder()
            if base_layout_placeholder is not None:
                layout_effects = layout_slide.getTimeline().getMainSequence().getEffectsByShape(base_layout_placeholder)
                print_effects("Layout slide", layout_effects)

                base_master_placeholder = base_layout_placeholder.getBasePlaceholder()
                if base_master_placeholder is not None:
                    master_effects = layout_slide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(base_master_placeholder)
                    print_effects("Master slide", master_effects)

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Change Animation Timing**

The PowerPoint **Timing** dialog maps to the properties of [Timing](https://reference.aspose.com/slides/python-java/aspose.slides/timing/).

![PowerPoint Timing dialog for an animation effect](shape-animation.png)

- **Start** maps to [Timing.getTriggerType](https://reference.aspose.com/slides/python-java/aspose.slides/timing/#getTriggerType).
- **Duration** maps to [Timing.getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/timing/#getDuration), in seconds.
- **Delay** maps to [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/python-java/aspose.slides/timing/#getTriggerDelayTime), in seconds.
- **Repeat** maps to [Timing.getRepeatCount](https://reference.aspose.com/slides/python-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/python-java/aspose.slides/timing/#getRepeatUntilNextClick), or [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/python-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Rewind when done playing** maps to [Timing.getRewind](https://reference.aspose.com/slides/python-java/aspose.slides/timing/#getRewind).

This independent example adds an effect, changes its timing through the object returned by [Sequence.addEffect](https://reference.aspose.com/slides/python-java/aspose.slides/sequence/#addEffect), and saves the result. Keeping the returned [Effect](https://reference.aspose.com/slides/python-java/aspose.slides/effect/) reference avoids an unnecessary collection index.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Timed animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick)
    effect.getTiming().setDuration(2.0)
    effect.getTiming().setTriggerDelayTime(0.5)
    effect.getTiming().setRepeatUntilNextClick(False)
    effect.getTiming().setRepeatUntilEndSlide(False)
    effect.getTiming().setRepeatCount(2.0)
    effect.getTiming().setRewind(True)

    presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Use one repeat mode intentionally. Combining a repeat count with an "until" flag can produce confusing results in different viewers. When changing repeat modes, set [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/python-java/aspose.slides/timing/#setRepeatUntilNextClick) and [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/python-java/aspose.slides/timing/#setRepeatUntilEndSlide) before [Timing.setRepeatCount](https://reference.aspose.com/slides/python-java/aspose.slides/timing/#setRepeatCount), because setting either flag also changes the active repeat mode.

## **Add and Extract Animation Sounds**

An animation effect can reference embedded audio through [Effect.getSound](https://reference.aspose.com/slides/python-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/python-java/aspose.slides/effect/#setStopPreviousSound) tells an effect to stop audio started by an earlier effect.

### **Add a Sound to an Effect**

The following example expects a local audio file named `animation-sound.wav`. It creates two effects, embeds that file as the sound for the first effect, and configures the second effect to stop the sound. It uses the objects returned by [Sequence.addEffect](https://reference.aspose.com/slides/python-java/aspose.slides/sequence/#addEffect), so no sequence index is required.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80)
    first_shape.addTextFrame("Starts sound")
    second_shape.addTextFrame("Stops sound")

    sequence = slide.getTimeline().getMainSequence()
    first_effect = sequence.addEffect(first_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    second_effect = sequence.addEffect(second_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    audio_data = Path("animation-sound.wav").read_bytes()
    effect_sound = presentation.getAudios().addAudio(jpype.JArray(jpype.JByte)(audio_data))
    first_effect.setSound(effect_sound)
    second_effect.setStopPreviousSound(True)

    presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Extract Embedded Effect Sounds**

The following example expects a local presentation named `presentation-with-animation-sounds.pptx`. It scans both main and interactive sequences and writes every embedded effect sound to the `extracted-animation-sounds` directory. The extension is selected from the audio MIME type exposed by [Audio.getContentType](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getContentType).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path

def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else str(content_type).lower()
    if normalized_type == "audio/mpeg":
        return ".mp3"
    if normalized_type == "audio/mp4":
        return ".m4a"
    if normalized_type == "audio/ogg":
        return ".ogg"
    if normalized_type in ("audio/wav", "audio/x-wav"):
        return ".wav"
    return ".bin"


def save_sounds(sequence, output_directory, sound_index):
    for effect in sequence:
        sound = effect.getSound()
        if sound is None:
            continue
        extension = get_audio_extension(sound.getContentType())
        output_path = output_directory / f"effect-sound-{sound_index}{extension}"
        audio_data = bytes(sound.getBinaryData())
        output_path.write_bytes(audio_data)
        sound_index += 1
    return sound_index


input_path = Path("presentation-with-animation-sounds.pptx")
output_directory = Path("extracted-animation-sounds")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation(str(input_path))
try:
    sound_index = 1
    for slide in presentation.getSlides():
        sound_index = save_sounds(slide.getTimeline().getMainSequence(), output_directory, sound_index)
        for sequence in slide.getTimeline().getInteractiveSequences():
            sound_index = save_sounds(sequence, output_directory, sound_index)
    print(f"Extracted {sound_index - 1} sound file(s) to {output_directory.resolve()}.")
finally:
    presentation.dispose()
```

For large audio objects, use [Audio.getStream](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getStream) and copy the stream to a file instead of loading the entire object into a byte array.

## **Set After-Animation Behavior**

The **After animation** option controls what happens to a shape after its effect finishes.

![PowerPoint Effect Options dialog showing After animation settings](shape-after-animation.png)

The [AfterAnimationType](https://reference.aspose.com/slides/python-java/aspose.slides/afteranimationtype/) class supports leaving the shape unchanged, changing its color, hiding it after the animation, or hiding it on the next click. When the type is [AfterAnimationType.Color](https://reference.aspose.com/slides/python-java/aspose.slides/afteranimationtype/#Color), set [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/python-java/aspose.slides/effect/#getAfterAnimationColor) as well.

This independent example creates an effect, sets its after-animation behavior through the returned effect object, and saves the result.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AfterAnimationType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Dim after animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.setAfterAnimationType(AfterAnimationType.Color)
    effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY)

    presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Changing the type away from [AfterAnimationType.Color](https://reference.aspose.com/slides/python-java/aspose.slides/afteranimationtype/#Color) clears the after-animation color setting.

## **Animate Text**

Text animation has two related controls:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/python-java/aspose.slides/textanimation/#getBuildType) controls whether paragraphs appear together or by paragraph level.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/python-java/aspose.slides/effect/#getAnimateTextType) controls whether text appears all at once, by word, or by letter. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/python-java/aspose.slides/effect/#getDelayBetweenTextParts) sets the delay between words or letters. A positive value is a percentage of the effect duration; a negative value is a delay in seconds.

The following independent example animates the words in a text box. [BuildType.AsOneObject](https://reference.aspose.com/slides/python-java/aspose.slides/buildtype/#AsOneObject) disables paragraph-by-paragraph building so that the word setting applies to the entire text frame.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AnimateTextType, BuildType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100)
    text_box.addTextFrame("Aspose.Slides animates this sentence word by word.")

    effect = slide.getTimeline().getMainSequence().addEffect(text_box, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTextAnimation().setBuildType(BuildType.AsOneObject)
    effect.setAnimateTextType(AnimateTextType.ByWord)
    effect.setDelayBetweenTextParts(20.0)

    presentation.save("animated-text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

To build a text box by paragraph, set [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/python-java/aspose.slides/buildtype/#ByLevelParagraphs1) (or another paragraph level). To target a single paragraph with its own effect, use the [Sequence.addEffect](https://reference.aspose.com/slides/python-java/aspose.slides/sequence/#addEffect) overload that accepts a [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/). See [Animated Text](/slides/python-java/animated-text/) for paragraph-level examples.

## **Export and Compatibility Notes**

- Saving to PPT or PPTX preserves the animation model, but the final playback is controlled by the presentation viewer.
- PDF and static images do not play animations. Use [HTML5 export](/slides/python-java/export-to-html5/), animated GIF, or [video conversion](/slides/python-java/convert-powerpoint-to-video/) when the output must show motion.
- For HTML5, enable [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) and, when needed, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions).
- Video rendering supports many common entrance, emphasis, exit, and motion-path effects, but not every PowerPoint effect is supported. Check the current [supported animations and effects](/slides/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) and test critical presentations with your target Aspose.Slides version.
- Advanced custom effects and effects imported from other presentation formats may be preserved in the file but render differently in PowerPoint, HTML5, or video. Validate the exported result rather than relying only on the effect name.

## **FAQ**

**Why does an animation appear in PowerPoint but not in a PDF?**

PDF is a static format, so animations and slide transitions do not play. Export to HTML5, animated GIF, or video when motion must be preserved.

**Why does an effect play differently in a video?**

Video export renders animations rather than storing the original PowerPoint behavior. Some advanced effects are unsupported or approximated. Review the supported-effects table and test the actual presentation before production use.

**Does moving a shape forward or backward change its animation order?**

No. Shape z-order controls overlap, while sequence order and triggers control animation playback. Change the timeline if you need a different playback order.
