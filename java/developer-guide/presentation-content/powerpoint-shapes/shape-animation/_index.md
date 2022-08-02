---
title: Shape Animation
type: docs
weight: 60
url: /java/shape-animation/
keywords: "PowerPoint animation, Animation effect, Apply animation, PowerPoint presentation, Java, Aspose.Slides for Java"
description: "Apply PowerPoint animation in Java"
---

Animations are visual effects that can be applied to texts, images, shapes, or [charts](https://docs.aspose.com/slides/java/animated-charts/). They give life to presentations or its constituents. 

### **Why Use Animations in Presentations?**

Using animations, you can 

* control the flow of information
* emphasize important points
* increase interest or participation among your audience
* make content easier to read or assimilate or process
* draw your readers or viewers attention to important parts in a presentation

PowerPoint provides many options and tools for animations and animation effects across the **entrance**, **exit**, **emphasis**, and **motion paths** categories. 

### **Animations in Aspose.Slides**

* Aspose.Slides provides the classes and types you need to work with animations under the `Aspose.Slides.Animation` namespace,
* Aspose.Slides provides over **150 animation effects** under the [EffectType](https://reference.aspose.com/slides/java/com.aspose.slides/effecttype) enumeration. These effects are essentially the same (or equivalent) effects used in PowerPoint.

## **Apply Animation to TextBox**

Aspose.Slides for Java allows you to apply animation to the text in a shape. 

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
2. Obtain a slide reference through its index.
3. Add a `rectangle` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape). 
4. Add text to [IAutoShape.TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Get a main sequence of effects.
6. Add an animation effect to [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape). 
7. Set the `TextAnimation.BuildType` property to the value from `BuildType` Enumeration.
8. Write the presentation to disk as a PPTX file.

This Java code shows you how to apply the `Fade` effect to AutoShape and set the text animation to *By 1st Level Paragraphs* value:

```java
// Instantiates a presentation class that represents a presentation file.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Adds new AutoShape with text
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Gets the main sequence of the slide.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Adds Fade animation effect to shape
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animates shape text by 1st level paragraphs
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Save the PPTX file to disk
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

Besides applying animations to text, you can also apply animations to a single [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph). See [**Animated Text**](/slides/java/animated-text/).

{{% /alert %}} 

## **Apply Animation to PictureFrame**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
2. Get a slide's reference through its index.
3. Add or get a [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe) on the slide. 
4. Get the main sequence of effects.
5. Add an animation effect to [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe).
6. Write the presentation to disk as a PPTX file.

This Java code shows you how to apply the `Fly` effect to a picture frame:

```java
// Instantiates a presentation class that represents a presentation file.
Presentation pres = new Presentation();
try {
    // Load Image to be added in presentaiton image collection
    byte[] imageBytes = Files.readAllBytes(Paths.get("aspose-logo.jpg"));
    IPPImage image = pres.getImages().addImage(imageBytes);

    // Adds picture frame to slide
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);

    // Gets the main sequence of the slide.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Adds Fly from Left animation effect to picture frame
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Save the PPTX file to disk
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Apply Animation to Shape**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
2. Get a slide's reference through its index.
3. Add a `rectangle` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape). 
4. Add a `Bevel` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) (when this object is clicked, the animation gets played).
5. Create a sequence of effects on the bevel shape.
6. Create a custom `UserPath`.
7. Add commands for moving to the `UserPath`.
8. Write the presentation to disk as a PPTX file.

This Java code shows you how to apply the `PathFootball` (path football) effect to a shape:

```java
// Instantiate a Presentation class that represents a PPTX file.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Creates PathFootball effect for existing shape from scratch.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Adds the PathFootBall animation effect
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Creates some kind of "button".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Creates a sequence of effects for this button.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Creates a custom user path. Our object will be moved only after the button is clicked.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Adds commands for moving since created path is empty.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Writes the PPTX file to disk
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Get the Animation Effects Applied to Shape**

You may decide to find out the all animation effects applied to a single shape. 

This Java code shows you how to get the all effects applied to a specific shape:

```java
// Instantiates a presentation class that represents a presentation file.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Gets the main sequence of the slide.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Gets the first shape on slide.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Gets all animation effects applied to the shape.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (pres != null) pres.dispose();
}
```

## **Change Animation Effect Timing Properties**

Aspose.Slides for Java allows you to change the Timing properties of an animation effect.

This is the Animation Timing pane in Microsoft PowerPoint:

![example1_image](shape-animation.png)

These are the correspondences between PowerPoint Timing and [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--) properties:

- PowerPoint Timing **Start** drop-down list matches the [Effect.Timing.TriggerType](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerType--) property. 
- PowerPoint Timing **Duration** matches the [Effect.Timing.Duration](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getDuration--) property. The duration of an animation (in seconds) is the total time it takes the animation to complete one cycle. 
- PowerPoint Timing **Delay** matches the [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerDelayTime--) property. 

This is how you change the Effect Timing properties:

1. [Apply](#apply-animation-to-shape) or get the animation effect.
2. Set new values for the [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--) properties you need. 
3. Save the modified PPTX file.

This Java code demonstrates the operation:

```java
// Instantiates a presentation class that represents a presentation file.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Gets the main sequence of the slide.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Gets the first effect of main sequence.
    IEffect effect = sequence.get_Item(0);

    // Changes effect TriggerType to start on click
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Changes effect Duration
    effect.getTiming().setDuration(3f);

    // Changes effect TriggerDelayTime
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Saves the PPTX file to disk
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

