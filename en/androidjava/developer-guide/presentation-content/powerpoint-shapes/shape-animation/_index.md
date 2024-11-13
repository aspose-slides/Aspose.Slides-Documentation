---
title: Shape Animation
type: docs
weight: 60
url: /androidjava/shape-animation/
keywords: 
- shape
- animation
- effect
- add effects
- get effects
- extract effects
- apply animation
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides for Android via Java
description: "Apply PowerPoint animation in Java"
---

Animations are visual effects that can be applied to texts, images, shapes, or [charts](https://docs.aspose.com/slides/androidjava/animated-charts/). They give life to presentations or its constituents.

## **Why Use Animations in Presentations?**

Using animations, you can 

* control the flow of information
* emphasize important points
* increase interest or participation among your audience
* make content easier to read or assimilate or process
* draw your readers or viewers attention to important parts in a presentation

PowerPoint provides many options and tools for animations and animation effects across the **entrance**, **exit**, **emphasis**, and **motion paths** categories. 

## **Animations in Aspose.Slides**

* Aspose.Slides provides the classes and types you need to work with animations under the `Aspose.Slides.Animation` namespace,
* Aspose.Slides provides over **150 animation effects** under the [EffectType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype) enumeration. These effects are essentially the same (or equivalent) effects used in PowerPoint.

## **Apply Animation to TextBox**

Aspose.Slides for Android via Java allows you to apply animation to the text in a shape.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
2. Obtain a slide reference through its index.
3. Add a `rectangle` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape).
4. Add text to [IAutoShape.TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Get a main sequence of effects.
6. Add an animation effect to [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape).
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

Besides applying animations to text, you can also apply animations to a single [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph). See [**Animated Text**](/slides/androidjava/animated-text/).

{{% /alert %}} 

## **Apply Animation to PictureFrame**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
2. Get a slide's reference through its index.
3. Add or get a [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe) on the slide.
4. Get the main sequence of effects.
5. Add an animation effect to [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe).
6. Write the presentation to disk as a PPTX file.

This Java code shows you how to apply the `Fly` effect to a picture frame:

```java
// Instantiates a presentation class that represents a presentation file.
Presentation pres = new Presentation();
try {
    // Load Image to be added in presentaiton image collection
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Adds picture frame to slide
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

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

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
2. Get a slide's reference through its index.
3. Add a `rectangle` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape).
4. Add a `Bevel` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) (when this object is clicked, the animation gets played).
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

The following examples show you how to use the `getEffectsByShape` method from the [ISequence](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isequence/) interface to get all animation effects applied to a shape.

**Example 1: Get animation effects applied to a shape on a normal slide**

Previously, you learned how to add animation effects to shapes in PowerPoint presentations. The following sample code shows you how to get the effects applied to the first shape on the first normal slide in the presentation `AnimExample_out.pptx`.

```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Gets the main animation sequence of the slide.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Gets the first shape on the first slide.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Gets animation effects applied to the shape.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**Example 2: Get all animation effects, including those inherited from placeholders**

If a shape on a normal slide has placeholders that are on the layout slide and/or master slide, and animation effects have been added to these placeholders, then all effects of the shape will be played during the slide show, including those inherited from the placeholders.

Let's say we have a PowerPoint presentation file `sample.pptx` with one slide containg only a footer shape with the text "Made with Aspose.Slides" and the **Random Bars** effect is applied to the shape.

![Slide shape animation effect](slide-shape-animation.png)

Let's also assume that the **Split** effect is applied to the footer placeholder on the **layout** slide.

![Layout shape animation effect](layout-shape-animation.png)

And finally, the **Fly In** effect is applied to the footer placeholder on the **master** slide.

![Master shape animation effect](master-shape-animation.png)

The following sample code shows you how to use the `getBasePlaceholder` method from the [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) interface to access the shape placeholders and get the animation effects applied to the footer shape, including those inherited from placeholders located on the layout and master slides.

```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

presentation.dispose();

System.out.println("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);
```
```java
static void printEffects(IEffect[] effects)
{
    for (IEffect effect : effects)
    {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}
```

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Change Animation Effect Timing Properties**

Aspose.Slides for Android via Java allows you to change the Timing properties of an animation effect.

This is the Animation Timing pane in Microsoft PowerPoint:

![example1_image](shape-animation.png)

These are the correspondences between PowerPoint Timing and [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--) properties:

- PowerPoint Timing **Start** drop-down list matches the [Effect.Timing.TriggerType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerType--) property.
- PowerPoint Timing **Duration** matches the [Effect.Timing.Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getDuration--) property. The duration of an animation (in seconds) is the total time it takes the animation to complete one cycle.
- PowerPoint Timing **Delay** matches the [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--) property.

This is how you change the Effect Timing properties:

1. [Apply](#apply-animation-to-shape) or get the animation effect.
2. Set new values for the [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--) properties you need.
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

## **Animation Effect Sound**

Aspose.Slides provides these properties to allow you to work with sounds in animation effects: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Add Animation Effect Sound**

This Java code shows you how to add an animation effect sound and stop it when the next effect starts:

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Adds audio to presentation audio collection
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Gets the main sequence of the slide.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Gets the first effect of the main sequence
    IEffect firstEffect = sequence.get_Item(0);

    // Сhecks the effect for "No Sound"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Adds sound for the first effect
        firstEffect.setSound(effectSound);
    }

    // Gets the first interactive sequence of the slide.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Sets the effect "Stop previous sound" flag
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Writes the PPTX file to disk
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Extract Animation Effect Sound**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/androidjava/aspose.slides/presentation/) class.
2. Get a slide’s reference through its index. 
3. Get the main sequence of effects. 
4. Extract the [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) embedded to each animation effect.

This Java code shows you how to extract the sound embedded in an animation effect:

```java
// Instantiates a presentation class that represents a presentation file.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Gets the main sequence of the slide.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Extracts the effect sound in byte array
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **After Animation**

Aspose.Slides for Android via Java allows you to change the After animation property of an animation effect.

This is the Animation Effect pane and extended menu in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

PowerPoint Effect **After animation** drop-down list matches these properties: 

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) property which describes the After animation type :
  * PowerPoint **More Colors** matches the [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color) type;
  * PowerPoint **Don't Dim** list item matches the [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) type (default after animation type);
  * PowerPoint **Hide After Animation** item matches the [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation) type;
  * PowerPoint **Hide on Next Mouse Click** item matches the [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) type;
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) property which defines an after animation color format. This property works in conjunction with the [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color) type. If you change the type to another, the after animation color will be cleared.

This Java code shows you how to change an after animation effect:

```java
// Instantiates a presentation class that represents a presentation file
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Gets the first effect of the main sequence
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Changes the after animation type to Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Sets the after animation dim color
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Writes the PPTX file to disk
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animate Text**

Aspose.Slides provides these properties to allow you to work with an animation effect's *Animate text* block:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) which describes an animate text type of the effect. The shape text can be animated:
  - All at once ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) type)
  - By word ([AnimateTextType.ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByWord) type)
  - By letter ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByLetter) type)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) sets a delay between the animated text parts (words or letters). A positive value specifies the percentage of effect duration. A negative value specifies the delay in seconds.

This is how you can change the Effect Animate text properties:

1. [Apply](#apply-animation-to-shape) or get the animation effect.
2. Set the [setBuildType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) property to [BuildType.AsOneObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/buildtype/#AsOneObject) value to turn off the *By Paragraphs* animation mode.
3. Set new values for the [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) and [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) properties.
4. Save the modified PPTX file.

This Java code demonstrates the operation:

```java
// Instantiates a presentation class that represents a presentation file.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Gets the first effect of the main sequence
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Changes the effect Text animation type to "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Changes the effect Animate text type to "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Sets the delay between words to 20% of effect duration
    firstEffect.setDelayBetweenTextParts(20f);

    // Writes the PPTX file to disk
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

