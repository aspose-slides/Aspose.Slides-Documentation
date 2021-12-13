---
title: Shape Animation
type: docs
weight: 50
url: /python-net/shape-animation/
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
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate PrseetationEx class that represents the PPTX
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Now create effect "PathFootball" for existing shape from scratch.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # Add PathFootBall animation effect
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Create some kind of "button".
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Create sequence of effects for this button.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Create custom user path. Our object will be moved only after "button" click.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Created path is empty so we should add commands for moving.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    #Write the presentation as PPTX to disk
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

