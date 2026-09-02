---
title: Apply Shape Animations in Presentations Using JavaScript
linktitle: Shape Animation
type: docs
weight: 60
url: /nodejs-java/shape-animation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Learn how to add, inspect, and customize shape animations, timing, sounds, after-animation behavior, and animated text with Aspose.Slides for Node.js via Java."
---

## **Overview**

Aspose.Slides for Node.js via Java represents slide animations as effects in a slide timeline. An effect has a target shape, an animation type and subtype, a trigger, timing settings, and optional properties such as sound or after-animation behavior.

The timeline contains two kinds of sequences:

- The **main sequence** plays as the slide advances.
- An **interactive sequence** starts when its trigger shape is clicked.

Because text boxes, pictures, charts, tables, and other slide objects are [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) objects, you use the same [Sequence.addEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sequence/#addEffect) method for most slide content. The available effects are listed in the [EffectType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effecttype/) enumeration.

## **Add Shape Animations**

To add an animation, get the slide's main sequence and call [Sequence.addEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sequence/#addEffect) with the target shape, effect type, subtype, and trigger. For an effect that starts when another shape is clicked, create an interactive sequence whose trigger is that other shape.

The following example creates both types of animation and saves the result to `shape-animations.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
    targetShape.addTextFrame("Click to animate this shape");

    const mainSequence = slide.getTimeline().getMainSequence();
    const entranceEffect = mainSequence.addEffect(targetShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    entranceEffect.getTiming().setDuration(java.newFloat(1.5));

    const triggerShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 20, 20, 100, 40);
    triggerShape.addTextFrame("Move");

    const interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
    interactiveSequence.addEffect(targetShape, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    presentation.save("shape-animations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The trigger controls when an effect starts:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effecttriggertype/#OnClick) waits for a click in the main sequence, or for a click on the trigger shape in an interactive sequence.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) starts with the preceding effect.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) starts when the preceding effect finishes.

To animate a picture, chart, or another shape type, pass that object to [Sequence.addEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sequence/#addEffect) instead of `targetShape`. For chart-specific grouping options, see [Animated Charts](/slides/nodejs-java/animated-charts/).

## **Read Shape Animations**

Use [Sequence.getEffectsByShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sequence/#getEffectsByShape) when you know the target shape. To inspect every effect, enumerate the main sequence and every interactive sequence. Enumeration avoids assuming that a sequence contains an effect at index `0`.

The following example creates a shape with main-sequence and interactive effects, gets the effects that target the shape, and then enumerates every sequence on the slide.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function getEnumName(enumType, value) {
    for (const [name, enumValue] of Object.entries(enumType)) {
        if (enumValue === value) {
            return name;
        }
    }

    return String(value);
}

function printSequence(label, sequence) {
    console.log(`  ${label}: ${sequence.getCount()} effect(s)`);

    for (let i = 0; i < sequence.getCount(); i++) {
        const effect = sequence.get_Item(i);
        const targetName = effect.getTargetShape() == null ? "unknown" : effect.getTargetShape().getName();
        const typeName = getEnumName(aspose.slides.EffectType, effect.getType());
        const subtypeName = getEnumName(aspose.slides.EffectSubtype, effect.getSubtype());
        const triggerName = getEnumName(aspose.slides.EffectTriggerType, effect.getTiming().getTriggerType());
        console.log(`    ${typeName} ${subtypeName}; target: ${targetName}; trigger: ${triggerName}`);
    }
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    targetShape.addTextFrame("Animated shape");

    const mainSequence = slide.getTimeline().getMainSequence();
    mainSequence.addEffect(targetShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const triggerShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 20, 20, 100, 40);
    triggerShape.addTextFrame("Move");

    const interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
    interactiveSequence.addEffect(targetShape, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const targetEffects = mainSequence.getEffectsByShape(targetShape);
    console.log(`The main sequence contains ${targetEffects.length} effect(s) for ${targetShape.getName()}.`);

    printSequence("Main sequence", mainSequence);

    const interactiveSequences = slide.getTimeline().getInteractiveSequences();
    for (let i = 0; i < interactiveSequences.getCount(); i++) {
        const sequence = interactiveSequences.get_Item(i);
        const triggerName = sequence.getTriggerShape() == null ? "unknown" : sequence.getTriggerShape().getName();
        printSequence(`Interactive sequence ${i + 1}, trigger: ${triggerName}`, sequence);
    }
} finally {
    presentation.dispose();
}
```

If you only need the effects for one shape, first identify the shape by name, placeholder type, or another stable property; then call [Sequence.getEffectsByShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sequence/#getEffectsByShape). Do not assume that [ShapeCollection.get_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#get_Item) at index `0` is always the intended object.

## **Work with Inherited Placeholder Effects**

A placeholder on a normal slide can inherit animation behavior from the corresponding placeholder on its layout slide and master slide. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) returns that parent placeholder, or `null` when no parent exists.

In the following example presentation, the footer has **Random Bars** on the normal slide, **Split** on the layout slide, and **Fly In** on the master slide.

![Footer animation effect on the normal slide](slide-shape-animation.png)

![Footer placeholder animation effect on the layout slide](layout-shape-animation.png)

![Footer placeholder animation effect on the master slide](master-shape-animation.png)

The next example uses a placeholder hierarchy from a new presentation. It adds effects to a master placeholder, a layout placeholder, and the corresponding placeholder on a normal slide. Every call to [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) is checked before the returned shape is used.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function findPlaceholderWithBase(baseSlide, expectedBase) {
    const shapes = baseSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const basePlaceholder = shape.getBasePlaceholder();

        if (basePlaceholder == null) {
            continue;
        }

        if (expectedBase == null || basePlaceholder.getPlaceholder().getType() === expectedBase.getPlaceholder().getType()) {
            return shape;
        }
    }

    return null;
}

function getEnumName(enumType, value) {
    for (const [name, enumValue] of Object.entries(enumType)) {
        if (enumValue === value) {
            return name;
        }
    }

    return String(value);
}

function printEffects(source, effects) {
    console.log(`${source}: ${effects.length} effect(s)`);

    for (const effect of effects) {
        const typeName = getEnumName(aspose.slides.EffectType, effect.getType());
        const subtypeName = getEnumName(aspose.slides.EffectSubtype, effect.getSubtype());
        console.log(`  ${typeName} ${subtypeName}`);
    }
}

const presentation = new aspose.slides.Presentation();
try {
    const layoutSlide = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    const layoutPlaceholder = findPlaceholderWithBase(layoutSlide, null);

    if (layoutPlaceholder == null) {
        throw new Error("The layout slide does not contain a placeholder linked to its master slide.");
    }

    const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
    layoutSlide.getMasterSlide().getTimeline().getMainSequence().addEffect(masterPlaceholder, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Bottom, aspose.slides.EffectTriggerType.OnClick);
    layoutSlide.getTimeline().getMainSequence().addEffect(layoutPlaceholder, aspose.slides.EffectType.Split, aspose.slides.EffectSubtype.VerticalIn, aspose.slides.EffectTriggerType.OnClick);

    const slide = presentation.getSlides().addEmptySlide(layoutSlide);
    const slidePlaceholder = findPlaceholderWithBase(slide, layoutPlaceholder);

    if (slidePlaceholder == null) {
        throw new Error("The slide does not contain a placeholder linked to its layout slide.");
    }

    slide.getTimeline().getMainSequence().addEffect(slidePlaceholder, aspose.slides.EffectType.RandomBars, aspose.slides.EffectSubtype.Horizontal, aspose.slides.EffectTriggerType.OnClick);
    printEffects("Normal slide", slide.getTimeline().getMainSequence().getEffectsByShape(slidePlaceholder));

    const baseLayoutPlaceholder = slidePlaceholder.getBasePlaceholder();
    if (baseLayoutPlaceholder != null) {
        printEffects("Layout slide", layoutSlide.getTimeline().getMainSequence().getEffectsByShape(baseLayoutPlaceholder));

        const baseMasterPlaceholder = baseLayoutPlaceholder.getBasePlaceholder();
        if (baseMasterPlaceholder != null) {
            printEffects("Master slide", layoutSlide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(baseMasterPlaceholder));
        }
    }

    presentation.save("placeholder-animations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Change Animation Timing**

The PowerPoint **Timing** dialog maps to the properties of [Timing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/timing/).

![PowerPoint Timing dialog for an animation effect](shape-animation.png)

- **Start** maps to [Timing.getTriggerType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/timing/#getTriggerType).
- **Duration** maps to [Timing.getDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/timing/#getDuration), in seconds.
- **Delay** maps to [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/timing/#getTriggerDelayTime), in seconds.
- **Repeat** maps to [Timing.getRepeatCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick), or [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Rewind when done playing** maps to [Timing.getRewind](https://reference.aspose.com/slides/nodejs-java/aspose.slides/timing/#getRewind).

This independent example adds an effect, changes its timing through the object returned by [Sequence.addEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sequence/#addEffect), and saves the result. Keeping the returned [Effect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/) reference avoids an unnecessary collection index.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    shape.addTextFrame("Timed animation");

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    effect.getTiming().setDuration(java.newFloat(2.0));
    effect.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    effect.getTiming().setRepeatUntilNextClick(false);
    effect.getTiming().setRepeatUntilEndSlide(false);
    effect.getTiming().setRepeatCount(java.newFloat(2.0));
    effect.getTiming().setRewind(true);

    presentation.save("shape-animation-timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Use one repeat mode intentionally. Combining a repeat count with an "until" flag can produce confusing results in different viewers. When changing repeat modes, set [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) and [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide) before [Timing.setRepeatCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/timing/#setRepeatCount), because setting either flag also changes the active repeat mode.

## **Add and Extract Animation Sounds**

An animation effect can reference embedded audio through [Effect.getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setStopPreviousSound) tells an effect to stop audio started by an earlier effect.

### **Add a Sound to an Effect**

The following example expects a local audio file named `animation-sound.wav`. It creates two effects, embeds that file as the sound for the first effect, and configures the second effect to stop the sound. It uses the objects returned by [Sequence.addEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sequence/#addEffect), so no sequence index is required.

```javascript
const fs = require("fs");
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const firstShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 100, 240, 80);
    const secondShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 400, 100, 240, 80);
    firstShape.addTextFrame("Starts sound");
    secondShape.addTextFrame("Stops sound");

    const sequence = slide.getTimeline().getMainSequence();
    const firstEffect = sequence.addEffect(firstShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    const secondEffect = sequence.addEffect(secondShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const audioData = java.newArray("byte", Array.from(fs.readFileSync("animation-sound.wav")));
    const effectSound = presentation.getAudios().addAudio(audioData);
    firstEffect.setSound(effectSound);
    secondEffect.setStopPreviousSound(true);

    presentation.save("shape-animation-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Extract Embedded Effect Sounds**

The following example expects a local presentation named `presentation-with-animation-sounds.pptx`. It scans both main and interactive sequences and writes every embedded effect sound to the `extracted-animation-sounds` directory. The extension is selected from the audio MIME type exposed by [Audio.getContentType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audio/#getContentType).

```javascript
const fs = require("fs");
const path = require("path");
const aspose = { slides: require("aspose.slides.via.java") };

function getAudioExtension(contentType) {
    const normalizedType = contentType == null ? "" : contentType.toLowerCase();

    if (normalizedType === "audio/mpeg") {
        return ".mp3";
    }

    if (normalizedType === "audio/mp4") {
        return ".m4a";
    }

    if (normalizedType === "audio/ogg") {
        return ".ogg";
    }

    if (normalizedType === "audio/wav" || normalizedType === "audio/x-wav") {
        return ".wav";
    }

    return ".bin";
}

function saveSounds(sequence, outputDirectory, soundIndex) {
    for (let i = 0; i < sequence.getCount(); i++) {
        const effect = sequence.get_Item(i);

        if (effect.getSound() == null) {
            continue;
        }

        const extension = getAudioExtension(effect.getSound().getContentType());
        const outputPath = path.join(outputDirectory, `effect-sound-${soundIndex}${extension}`);
        fs.writeFileSync(outputPath, Buffer.from(effect.getSound().getBinaryData()));
        soundIndex++;
    }

    return soundIndex;
}

const outputDirectory = "extracted-animation-sounds";
fs.mkdirSync(outputDirectory, { recursive: true });

const presentation = new aspose.slides.Presentation("presentation-with-animation-sounds.pptx");
try {
    let soundIndex = 1;

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        soundIndex = saveSounds(slide.getTimeline().getMainSequence(), outputDirectory, soundIndex);

        const interactiveSequences = slide.getTimeline().getInteractiveSequences();
        for (let sequenceIndex = 0; sequenceIndex < interactiveSequences.getCount(); sequenceIndex++) {
            soundIndex = saveSounds(interactiveSequences.get_Item(sequenceIndex), outputDirectory, soundIndex);
        }
    }

    console.log(`Extracted ${soundIndex - 1} sound file(s) to ${path.resolve(outputDirectory)}.`);
} finally {
    presentation.dispose();
}
```

For large audio objects, use [Audio.getStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audio/#getStream) and copy the stream to a file instead of loading the entire object into a byte array.

## **Set After-Animation Behavior**

The **After animation** option controls what happens to a shape after its effect finishes.

![PowerPoint Effect Options dialog showing After animation settings](shape-after-animation.png)

The [AfterAnimationType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/) enumeration supports leaving the shape unchanged, changing its color, hiding it after the animation, or hiding it on the next click. When the type is [AfterAnimationType.Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#Color), set [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#getAfterAnimationColor) as well.

This independent example creates an effect, sets its after-animation behavior through the returned effect object, and saves the result.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    shape.addTextFrame("Dim after animation");

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    effect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("shape-animation-after-effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Changing the type away from [AfterAnimationType.Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#Color) clears the after-animation color setting.

## **Animate Text**

Text animation has two related controls:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textanimation/#getBuildType) controls whether paragraphs appear together or by paragraph level.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#getAnimateTextType) controls whether text appears all at once, by word, or by letter. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) sets the delay between words or letters. A positive value is a percentage of the effect duration; a negative value is a delay in seconds.

The following independent example animates the words in a text box. [BuildType.AsOneObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/buildtype/#AsOneObject) disables paragraph-by-paragraph building so that the word setting applies to the entire text frame.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 560, 100);
    textBox.addTextFrame("Aspose.Slides animates this sentence word by word.");

    const effect = slide.getTimeline().getMainSequence().addEffect(textBox, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    effect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    effect.setDelayBetweenTextParts(java.newFloat(20.0));

    presentation.save("animated-text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

To build a text box by paragraph, set [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) (or another paragraph level). To target a single paragraph with its own effect, use the [Sequence.addEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sequence/#addEffect) overload that accepts a [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/). See [Animated Text](/slides/nodejs-java/animated-text/) for paragraph-level examples.

## **Export and Compatibility Notes**

- Saving to PPT or PPTX preserves the animation model, but the final playback is controlled by the presentation viewer.
- PDF and static images do not play animations. Use [HTML5 export](/slides/nodejs-java/export-to-html5/), animated GIF, or [video conversion](/slides/nodejs-java/convert-powerpoint-to-video/) when the output must show motion.
- For HTML5, enable [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes) and, when needed, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions).
- Video rendering supports many common entrance, emphasis, exit, and motion-path effects, but not every PowerPoint effect is supported. Check the current [supported animations and effects](/slides/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) and test critical presentations with your target Aspose.Slides version.
- Advanced custom effects and effects imported from other presentation formats may be preserved in the file but render differently in PowerPoint, HTML5, or video. Validate the exported result rather than relying only on the effect name.

## **FAQ**

**Why does an animation appear in PowerPoint but not in a PDF?**

PDF is a static format, so animations and slide transitions do not play. Export to HTML5, animated GIF, or video when motion must be preserved.

**Why does an effect play differently in a video?**

Video export renders animations rather than storing the original PowerPoint behavior. Some advanced effects are unsupported or approximated. Review the supported-effects table and test the actual presentation before production use.

**Does moving a shape forward or backward change its animation order?**

No. Shape z-order controls overlap, while sequence order and triggers control animation playback. Change the timeline if you need a different playback order.
