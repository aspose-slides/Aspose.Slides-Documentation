---
title: Slide Transition
type: docs
weight: 80
url: /nodejs-java/slide-transition/
keywords: "PowerPoint slide transition, morph transition in JavaScript"
description: "PowerPoint slide transition, PowerPoint morph transition in JavaScript"
---


## **Overview**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java also allows developers to manage or customize the slide transition effects of the slides. In this topic, we will discuss about controlling slide transitions with a great ease using Aspose.Slides for Node.js via Java.

{{% /alert %}} 

To make it easier to understand, we have demonstrated the use of Aspose.Slides for Node.js via Java to manage simple slide transitions. Developers can not only apply different slide transition effects on the slides, but also customize the behavior of these transition effects.

## **Add Slide Transition**
To create a simple slide transition effect, follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class.
1. Apply a Slide Transition Type on the slide from one of the transition effects offered by Aspose.Slides for Node.js via Java through TransitionType enum
1. Write the modified presentation file.

```javascript
// Instantiate Presentation class to load the source presentation file
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Apply circle type transition on slide 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Apply comb type transition on slide 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Write the presentation to disk
    presentation.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Add Advanced Slide Transition**
In the above section, we just applied a simple transition effect on the slide. Now, to make that simple transition effect even better and controlled, please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class.
1. Apply a Slide Transition Type on the slide from one of the transition effects offered by Aspose.Slides for Node.js via Java
1. You can also set the transition to Advance On Click, after a specific time period or both.
1. If the slide transition is enabled to Advance On Click, the transition will only advance when someone will click the mouse. Moreover, if the Advance After Time property is set, the transition will advance automatically after the specified advance time will be passed.
1. Write the modified presentation as a presentation file.

```javascript
// Instantiate Presentation class that represents a presentation file
var pres = new aspose.slides.Presentation("BetterSlideTransitions.pptx");
try {
    // Apply circle type transition on slide 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Set the transition time of 3 seconds
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);
    // Apply comb type transition on slide 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Set the transition time of 5 seconds
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);
    // Apply zoom type transition on slide 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(aspose.slides.TransitionType.Zoom);
    // Set the transition time of 7 seconds
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);
    // Write the presentation to disk
    pres.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph Transition**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java now supports the [Morph Transition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MorphTransition). They represent new morph transition introduced in PowerPoint 2019.

{{% /alert %}} 

The Morph transition allows you to animate smooth movement from one slide to the next. This article describes the concept and how to use the Morph transition. To use the Morph transition effectively, you will need to have two slides with at least one object in common. The easiest way is to duplicate the slide and then move the object on the second slide to a different place.

The following code snippet shows you how to add a clone of the slide with some text to the presentation and set a transition of [morph type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TransitionType) to the second slide.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var autoshape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));
    var shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Morph Transition Types**
New [TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TransitionMorphType) enum has been added. It represents different types of Morph slide transition.

TransitionMorphType enum has three members:

- ByObject: Morph transition will be performed considering shapes as indivisible objects.
- ByWord: Morph transition will be performed with transferring text by words where possible.
- ByChar: Morph transition will be performed with transferring text by characters where possible.

The following code snippet shows you how to set morph transition to slide and change morph type:

```javascript
var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setMorphType(aspose.slides.TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Set Transition Effects**
Aspose.Slides for Node.js via Java supports setting the transition effects like, from black, from left, from right etc. In order to set the Transition Effect. Please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
- Get the reference of the slide.
- Setting the transition effect.
- Write the presentation as a [PPTX ](https://docs.fileformat.com/presentation/pptx/)file.

In the example given below, we have set the transition effects.

```javascript
// Create an instance of Presentation class
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Set effect
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Cut);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setFromBlack(true);
    // Write the presentation to disk
    presentation.save("SetTransitionEffects_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
