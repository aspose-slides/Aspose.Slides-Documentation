---
title: Shape Animation
type: docs
weight: 50
url: /java/shape-animation/
---

Animation is one of the most important parts of the presentations that make them more attractive and meaningful. Aspose.Slides for Java also allows developers to apply different kinds of animation effects on different kinds of shapes. In this topic, we will show how to apply animation effects on shapes.

Here we will apply the PathFootball effect (one of more than 150 available effects) on a TextBox that will be activated on clicking the bevel shape (some sort of button). To apply such animation effect, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an [IAutoShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IAutoShape) of Rectangle type.
- Add an [IAutoShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IAutoShape) of [Bevel](https://apireference.aspose.com/slides/java/com.aspose.slides/ShapeType#Bevel) type (which when clicked causes the animations to take effect).
- Create a sequence of effects on this [Bevel](https://apireference.aspose.com/slides/java/com.aspose.slides/ShapeType#Bevel) shape.
- Create a custom User Path.
- Add commands to the Path for moving.
- Write the presentation to the disk as a PPTX file.

This sample code, based on the steps above, shows you how to apply the PathFootball effect to a TextBox activated when the bevel shape gets clicked:

```java
// Instantiate PrseetationEx class that represents the PPTX
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Now create effect "PathFootball" for existing shape from scratch.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Add PathFootBall animation effect
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Create some kind of "button".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Create sequence of effects for this button.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

    // Create custom user path. Our object will be moved only after "button" click.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Created path is empty so we should add commands for moving.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    //Write the presentation as PPTX to disk
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```