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

Since presentations are meant to present something, their visual appearance and interactive behavior is always considered while creating them.

**PowerPoint animation** plays an important role in order to make presentation eye-catching and attractive for the viewers. Aspose.Slides for Python via .NET offers a wide range of options to add animation to PowerPoint presentation:

- apply various types of PowerPoint animation effects on shapes, charts, tables, OLE Objects and other presentation elements.
- use multiple PowerPoint animation effects on a shape.
- use animation timeline to control animation effects.
- create custom animation.

In Aspose.Slides for Python via .NET, various animations effects can be applied on the shapes. As every element on the slide including text, pictures, OLE Object, table etc is considered as a shape, it means we can apply animation effect on every element of a slide.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) **namespace** provides classes to work with PowerPoint animations.
## **Animation Effects**
Aspose.Slides supports **150+ animation effects**, including basic animation effects like Bounce, PathFootball, Zoom effect and specific animation effects as OLEObjectShow, OLEObjectOpen. You can find a full listing of animation effects in [**EffectType** ](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/)enumeration.

Additionally, these animation effects can be used in combination with them:

- [ColorEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/seteffect/)
## **Custom Animation**
It is possible to create your own **custom animations** in Aspose.Slides. 
This can be achieved if you combine several behaviours together into a new custom animation.

[**Behaviour**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behavior/) is a building unit of any PowerPoint animation effect. All animation effects are actually a set of behaviours composed into one strategy. You can combine behaviours into a custom animation once and reuse it in other presentations. If you add a new behaviour into a standard PowerPoint animation effect - it will be another custom animation. For example, you can add repeat behaviour to an animation to make it repeat a few times.

[**Animation Point**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/point/) is a point where behaviour should be applied.
## **Animation Time Line**
[**Sequence**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) is a collection of animation effects, applied on a concrete shape.

[**Timeline**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animationtimeline/) is a set of Sequences used in a concrete slide. It is an animation engine represented since PowerPoint 2002. In previous Powerpoint versions, it was challenging to add animation effects to presentation, which could be achieved only with different workarounds. Timeline comes to replace on old AnimationSettings class and provide more clear object model for PowerPoint animation. One slide can have only one animation timeline.
## **Interactive Animation**
[**Trigger**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/) allows to define user actions (e.g. button click), that will make a certain animation start. Triggers have been added into the latest PowerPoint version only.
## **Shape Animation**
Aspose.Slides allows to apply animation to shapes, that can be actually text, rectangle, line, frame, OLE Object, etc.

{{% alert color="primary" %}} 
Read more [**About Shape Animation**](/slides/python-net/shape-animation/).
{{% /alert %}}

## **Animated Charts**
To create animated charts, you should use all the same classes as for the shapes. However, it is possible to use PowerPoint animation only on chart categories or chart series. You can also apply animation effect to a category element or series element.

{{% alert color="primary" %}} 
Read more [**About Animated Charts**](/slides/python-net/animated-charts/).
{{% /alert %}}

## **Animated text**
Except animated text, it is also possible to apply animation to a paragraph.

{{% alert color="primary" %}} 
Read more [**About Animated Text**](/slides/python-net/animated-text/).
{{% /alert %}}