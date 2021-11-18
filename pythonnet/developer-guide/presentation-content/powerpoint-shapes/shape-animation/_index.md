---
title: Shape Animation
type: docs
weight: 50
url: /pythonnet/shape-animation/
keywords: "PowerPoint animation, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Create PowerPoint animation in Python"
---

Animation is one of the most important parts of the presentations that make them more attractive and meaningful. Aspose.Slides for Python via .NET also allows developers to apply different kinds of animation effects on different kinds of shapes. There is a separate namespace [Aspose.Slides.Animation](http://www.aspose.com/api/net/slides/aspose.slides.animation/) that provides classes to handle the animations on PPTX presentations. In this topic, we will show how to apply animation effects on shapes.

Here we will apply the PathFootball effect (one of more than 150 available effects) on a TextBox that will be activated on clicking the bevel shape (some sort of button). To apply such animation effect, please follow the steps below:

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its Index.
- Add an IAutoShape of Rectangle type.
- Add an IAutoShape of [Bevel type](http://www.aspose.com/api/net/slides/aspose.slides/shapetype) (clicking on which, animations will take effect).
- Create sequence of effects on this Bevel shape.
- Create custom User Path.
- Add commands to the Path for moving.
- Write the presentation to the disk as a PPTX file.

```py
// Instantiate PrseetationEx class that represents the PPTX
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Now create effect "PathFootball" for existing shape from scratch.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // Add PathFootBall animation effect
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Create some kind of "button".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Create sequence of effects for this button.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Create custom user path. Our object will be moved only after "button" click.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Created path is empty so we should add commands for moving.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    //Write the presentation as PPTX to disk
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

