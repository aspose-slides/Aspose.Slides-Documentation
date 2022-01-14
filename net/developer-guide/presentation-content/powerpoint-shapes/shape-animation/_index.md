---
title: Shape Animation
type: docs
weight: 50
url: /net/shape-animation/
keywords: "PowerPoint animation, Animation effect, Apply animation, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Apply PowerPoint animation in C# or .NET"
---

Animations are visual effects that can be applied to texts, images, shapes, or charts. They give life to presentations or its constituents. 

### Why Use Animations in Presentations?

Using animations, you can 

* control the flow of information
* emphasize important points
* increase interest or participation among your audience
* make content easier to read or assimilate or process
* draw your readers or viewers attention to important parts in a presentation

PowerPoint provides many options and tools for animations and animation effects across the **entrance**, **exit**, **emphasis**, and **motion paths** categories. 

### **Animations in Aspose.Slides**

* Aspose.Slides provides the classes and types you need to work with animations under the [Aspose.Slides.Animation](http://www.aspose.com/api/net/slides/aspose.slides.animation/) namespace,

* Aspose.Slides provides over **150 animation effects** under the [EffectType](https://apireference.aspose.com/slides/net/aspose.slides.animation/effecttype) enumeration. These effects are effectively the same effects used in PowerPoint or their equivalents.

## **Apply Animation to Object or Textbox or XXX**

~~XXX~~

This C# code shows you how to add ~~XXX~~:

```c#

```



## **Apply Animation to Shape**

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) class.
2. Obtain a slide reference through its index.
3. Add a `rectangle` [IAutoShape](https://apireference.aspose.com/slides/net/aspose.slides/iautoshape). 
4. Add a `Bevel` [IAutoShape](https://apireference.aspose.com/slides/net/aspose.slides/iautoshape) (when this object is clicked, the animation gets played).
5. Create a sequence of effects on the bevel shape.
6. Create a custom `UserPath`.
7. Add commands for moving to the `UserPath`.
8. Write the presentation to disk as a PPTX file.

This C# code shows you how to apply the `PathFootball` (path football) effect to a shape:

```c#
// Instantiates a presentation class that represents a presentation file.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Creates PathFootball effect for existing shape from scratch.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // Adds PathFootBall animation effect.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Creates some kind of "button".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Creates a sequence of effects for the button.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Creates a custom user path. Our object will be moved only after the button is clicked.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Adds commands for moving since created path is empty
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // Writes the PPTX file to disk
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **Get Duration of Animation**

The duration of an animation (in seconds) is the total time it takes the animation to complete one cycle. ~~XXX - What is duration of an animation?~~

This C# code shows you how to get the duration for an animation:

```c#

```
