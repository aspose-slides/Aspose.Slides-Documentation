---
title: Enhance PowerPoint Presentations with Animations in .NET
linktitle: PowerPoint Animation
type: docs
weight: 150
url: /net/powerpoint-animation/
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
- .NET
- C#
- Aspose.Slides
description: "Explore the capabilities of Aspose.Slides for .NET in handling PowerPoint animations. This general overview highlights key features and offers insights to enhance your presentations."
---

## **Overview**

Since presentations are meant to present something, their visual appearance and interactive behavior are always taken into account during creation.

**PowerPoint animation** plays an important role in making a presentation eye-catching and engaging for viewers. Aspose.Slides for .NET provides a wide range of options to add animations to PowerPoint presentations:

- Apply various types of PowerPoint animation effects to shapes, charts, tables, OLE objects, and other presentation elements.
- Use multiple PowerPoint animation effects on a single shape.
- Utilize the animation timeline to control animation effects.
- Create custom animations.

In Aspose.Slides for .NET, various animation effects can be applied to shapes. Since every element on a slide, including text, pictures, OLE objects, and tables, is considered a shape, animation effects can be applied to any element on the slide.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/) namespace provides classes to work with PowerPoint animations.

## **Animation Effects**

Aspose.Slides supports **150+ animation effects**, including basic effects like Bounce, PathFootball, and Zoom, as well as specific effects like OLEObjectShow and OLEObjectOpen. You can find a complete list of animation effects in the [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype) enumeration.

Additionally, these animation effects can be used in combination with the following:

- [ColorEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/seteffect)

## **Custom Animation**

It is possible to create your own **custom animations** in Aspose.Slides. This can be achieved by combining several behaviors together into a new custom animation.

[Behaviour](https://reference.aspose.com/slides/net/aspose.slides.animation/behavior) is a building block of any PowerPoint animation effect. All animation effects are essentially a set of behaviors composed into one strategy. You can combine behaviors into a custom animation once and reuse it in other presentations. If you add a new behavior to a standard PowerPoint animation effect, it will become another custom animation. For example, you can add a repeat behavior to an animation to make it repeat a few times.

[Animation Point](https://reference.aspose.com/slides/net/aspose.slides.animation/point) is a point at which a behavior should be applied.

## **Animation Time Line**

[Sequence](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) is a collection of animation effects applied to a specific shape.

[Timeline](https://reference.aspose.com/slides/net/aspose.slides.animation/animationtimeline) is a set of sequences used in a specific slide. It is an animation engine introduced in PowerPoint 2002. In earlier versions of PowerPoint, adding animation effects to presentations was challenging and could only be achieved with various workarounds. The timeline replaces the old AnimationSettings class and provides a clearer object model for PowerPoint animations. A slide can have only one animation timeline.

## **Interactive Animation**

[Trigger](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttriggertype) allows you to define user actions (e.g., a button click) that will initiate a specific animation. Triggers were introduced in the latest version of PowerPoint.

## **Shape Animation**

Aspose.Slides allows you to apply animations to shapes, which can include text, rectangles, lines, frames, OLE objects, and more.

{{% alert color="primary" %}} 
Read more [**About Shape Animation**](/slides/net/shape-animation/).
{{% /alert %}}

## **Animated Charts**

To create animated charts, you should use the same classes as for the shapes. However, PowerPoint animations can only be applied to chart categories or chart series. You can also apply animation effects to a category element or a series element.

{{% alert color="primary" %}} 
Read more [**About Animated Charts**](/slides/net/animated-charts/).
{{% /alert %}}

## **Animated Text**

Except animated text, it is also possible to apply animation to a paragraph.

{{% alert color="primary" %}} 
Read more [**About Animated Text**](/slides/net/animated-text/).
{{% /alert %}}

## **FAQ**

**Will animations be preserved when exporting to PDF?**

No. PDF is a static format, so animations and [slide transitions](/slides/net/slide-transition/) don’t play. If you need motion, export to [HTML5](/slides/net/export-to-html5/), [animated GIF](/slides/net/convert-powerpoint-to-animated-gif/), or [video](/slides/net/convert-powerpoint-to-video/) instead.

**Can I turn an animated presentation into a video and control the frame rate and frame size?**

Yes. You can [render the presentation as frames](/slides/net/convert-powerpoint-to-video/) and encode them into a video (e.g., via ffmpeg), choosing the FPS and resolution. Animations and slide transitions are played during rendering.

**Will animations remain intact when working with ODP (not just PPTX)?**

PPT, PPTX, and ODP are supported for [reading](/slides/net/open-presentation/) and [writing](/slides/net/save-presentation/), but format differences mean certain effects may look or behave slightly differently. Validate critical cases with real samples.
