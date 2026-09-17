---
title: Enhance PowerPoint Presentations with Animations on Android
linktitle: PowerPoint Animation
type: docs
weight: 150
url: /androidjava/powerpoint-animation/
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
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Explore the capabilities of Aspose.Slides for Android via Java in handling PowerPoint animations. This general overview highlights key features."
---

## **Introduction**

Since presentations are meant to present something, their visual appearance and interactive behavior are always taken into account during creation.

**PowerPoint animation** plays an important role in making a presentation eye-catching and engaging for viewers. Aspose.Slides provides a wide range of options to add animations to PowerPoint presentations:

- Apply various types of PowerPoint animation effects to shapes, charts, tables, OLE objects, and other presentation elements.
- Use multiple PowerPoint animation effects on a single shape.
- Utilize the animation timeline to control animation effects.
- Create custom animations.

In Aspose.Slides, various animation effects can be applied to shapes. Since every element on a slide, including text, pictures, OLE objects, and tables, is considered a shape, animation effects can be applied to any element on the slide.

## **Animation Effects**
Aspose.Slides supports **150+ animation effects**, including basic effects such as Bounce, PathFootball, and Zoom, and specific effects such as OLEObjectShow and OLEObjectOpen. You can find a full listing in the [EffectType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype/) class.

Additionally, these animation effects can be used in combination with the following behaviors:

- [ColorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SetEffect)

## **Custom Animation**

For complete Java examples that create, inspect, and modify behaviors and editable motion paths, see [Custom Animation](/slides/java/custom-animation/).

It is possible to create your own **custom animations** in Aspose.Slides. This can be achieved by combining several behaviors into a new custom animation.

[Behavior](https://reference.aspose.com/slides/androidjava/com.aspose.slides/behavior/) is a building block of a PowerPoint animation effect. Combine behaviors to customize an effect, or add a behavior to extend a predefined effect. Repetition is configured through timing settings rather than a separate repeat behavior.

[Animation Point](https://reference.aspose.com/slides/androidjava/com.aspose.slides/point/) is a point at which a behavior should be applied.

## **Animation Time Line**
[Sequence](https://reference.aspose.com/slides/androidjava/com.aspose.slides/sequence/) is a collection of animation effects that can target different shapes.

[Timeline](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animationtimeline/) is a set of sequences used in a specific slide. It is an animation engine introduced in PowerPoint 2002. In earlier versions of PowerPoint, adding animation effects to presentations was challenging and could only be achieved with various workarounds. The timeline provides a clearer object model for PowerPoint animations. A slide can have only one animation timeline.

## **Interactive Animation**
[Trigger](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttriggertype/) allows you to define user actions, such as a button click, that start a particular animation.

## **Shape Animation**
Aspose.Slides allows you to apply animations to shapes, which can include text, rectangles, lines, frames, OLE objects, and more.

{{% alert color="info" title="Note" %}}
Read more [**About Shape Animation**](/slides/androidjava/shape-animation/).
{{% /alert %}}

## **Animated Charts**
To create animated charts, you should use the same classes as for shapes. However, PowerPoint animations can only be applied to chart categories or chart series. You can also apply animation effects to a category element or a series element.

{{% alert color="info" title="Note" %}}
Read more [**About Animated Charts**](/slides/androidjava/animated-charts/).
{{% /alert %}}

## **Animated Text**
In addition to animating text, you can apply animation to a paragraph.

{{% alert color="info" title="Note" %}}
Read more [**About Animated Text**](/slides/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

**Will animations be preserved when exporting to PDF?**

No. PDF is a static format, so animations and [slide transitions](/slides/androidjava/slide-transition/) don’t play. If you need motion, export to [HTML5](/slides/androidjava/export-to-html5/), [animated GIF](/slides/androidjava/convert-powerpoint-to-animated-gif/), or [video](/slides/androidjava/convert-powerpoint-to-video/) instead.

**Can I turn an animated presentation into a video and control the frame rate and frame size?**

Yes. You can [render the presentation as frames](/slides/androidjava/convert-powerpoint-to-video/) and encode them into a video (e.g., via ffmpeg), choosing the FPS and resolution. Animations and slide transitions are played during rendering.

**Will animations remain intact when working with ODP (not just PPTX)?**

PPT, PPTX, and ODP are supported for [reading](/slides/androidjava/open-presentation/) and [writing](/slides/androidjava/save-presentation/), but this does not guarantee animation preservation. Custom animation data can be lost when converting to ODP. See [Custom Animation for Java](/slides/java/custom-animation/) for examples and guidance on checking format compatibility.
