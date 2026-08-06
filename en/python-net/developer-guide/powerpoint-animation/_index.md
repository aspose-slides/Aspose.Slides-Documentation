---
title: Enhance PowerPoint Presentations with Animations in Python
linktitle: PowerPoint Animation
type: docs
weight: 150
url: /python-net/powerpoint-animation/
keywords:
- add animation
- update animation
- change animation
- remove animation
- manage animation
- control animation
- animation effect
- PowerPoint animation
- animation timeline
- interactive animation
- custom animation
- shape animation
- animated chart
- animated text
- animated shape
- animated OLE object
- animated image
- animated table
- PowerPoint presentation
- Python
- Aspose.Slides
description: "Explore the capabilities of Aspose.Slides for Python via .NET in handling PowerPoint animations. This general overview highlights key features and offers insights to enhance your presentations."
---

## **Introduction**

Presentations are designed to convey information, so their visual appearance and interactive behavior are key considerations during creation.

**PowerPoint animation** plays an important role in making a presentation eye-catching and engaging for viewers. Aspose.Slides for Python via .NET provides a wide range of options to add animation to a PowerPoint presentation. You can:

- Apply various animation effects to shapes, charts, tables, OLE objects, and other elements.
- Use multiple animation effects on a single shape.
- Control effects through the animation timeline.
- Create custom animations.

In Aspose.Slides for Python via .NET, animation effects can be applied to shapes. Because every element on a slide—including text, pictures, OLE objects, and tables—is treated as a shape, you can apply animation effects to any element on the slide.

The [aspose.slides.animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) namespace provides the classes for working with PowerPoint animations.

## **Installation**

```bash
pip install aspose.slides
```

## **Add an Animation Effect to a Shape in Python**

Animation effects live on a slide's main sequence. Add a shape, then call `add_effect` on
`slide.timeline.main_sequence`, passing the effect type, its subtype, and the trigger that starts it.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 100)
    shape.text_frame.text = "Animated shape"

    sequence = slide.timeline.main_sequence
    effect = sequence.add_effect(
        shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.LEFT,
        slides.animation.EffectTriggerType.ON_CLICK,
    )
    effect.timing.duration = 2.0

    presentation.save("animated.pptx", slides.export.SaveFormat.PPTX)
```

The saved file contains one effect on the first slide: the rectangle flies in from the left over two
seconds when the presenter clicks. Reopening it and reading `slide.timeline.main_sequence` returns
that effect, so the animation survives the round trip rather than only existing in memory.

## **Animation Effects**

Aspose.Slides supports **150+ animation effects**, including basic effects such as Bounce, PathFootball, and Zoom, as well as specialized effects like OLEObjectShow and OLEObjectOpen. You can find the full list in the [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/) enumeration.

Additionally, these animation effects can be combined with the following effects:

- [ColorEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/seteffect/)

## **Custom Animation**

You can create your own **custom animations** in Aspose.Slides by combining multiple behaviors into a single effect.

[Behavior](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behavior/) is the basic building block of any PowerPoint animation effect. Every animation effect is essentially a set of behaviors arranged into one strategy or timeline. You can assemble behaviors into a custom animation once and reuse it across other presentations. If you add a new behavior to a standard PowerPoint animation effect, it becomes a custom animation—for example, adding a repeat behavior to make the animation play several times.

[Animation Point](https://reference.aspose.com/slides/python-net/aspose.slides.animation/point/) marks the moment or position at which a behavior is applied (a keyframe).

## **Animation Time Line**

[Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) is a collection of animation effects applied to a specific shape.

[Timeline](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animationtimeline/) is the set of sequences used on a specific slide. It was introduced in PowerPoint 2002. In earlier versions of PowerPoint, adding animation effects was difficult and often required workarounds. Timeline replaces the old `AnimationSettings` class and provides a clearer object model for PowerPoint animation. Each slide can have only one animation timeline.

## **Interactive Animation**

[Trigger](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/) allows you to define user actions (e.g., a button click) that start a specific animation. Triggers were added only in the latest versions of PowerPoint.

## **Shape Animation**

Aspose.Slides lets you apply animations to shapes—such as text, rectangles, lines, frames, OLE objects, and more.

{{% alert color="primary" %}}

Read more [**About Shape Animation**](/slides/python-net/shape-animation/).

{{% /alert %}}

## **Animated Charts**

To create animated charts, use the same classes as you do for shapes. However, PowerPoint animations can be applied only to chart categories or chart series. You can also apply an animation effect to an individual category element or series element.

{{% alert color="primary" %}}

Read more [**About Animated Charts**](/slides/python-net/animated-charts/).

{{% /alert %}}

## **Animated text**

In addition to animating text, you can apply animation to a paragraph.

{{% alert color="primary" %}}

Read more [**About Animated Text**](/slides/python-net/animated-text/).

{{% /alert %}}

## **FAQ**

### Will animations be preserved when exporting to PDF?

No. PDF is a static format, so animations and [slide transitions](/slides/python-net/slide-transition/) don’t play. If you need motion, export to [HTML5](/slides/python-net/export-to-html5/), [animated GIF](/slides/python-net/convert-powerpoint-to-animated-gif/), or [video](/slides/python-net/convert-powerpoint-to-video/) instead.

### Can I turn an animated presentation into a video and control the frame rate and frame size?

Yes. You can [render the presentation as frames](/slides/python-net/convert-powerpoint-to-video/) and encode them into a video (e.g., via ffmpeg), choosing the FPS and resolution. Animations and slide transitions are played during rendering.

### Will animations remain intact when working with ODP (not just PPTX)?

PPT, PPTX, and ODP are supported for [reading](/slides/python-net/open-presentation/) and [writing](/slides/python-net/save-presentation/), but format differences mean certain effects may look or behave slightly differently. Validate critical cases with real samples.
