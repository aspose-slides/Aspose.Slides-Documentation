---
title: Slide Transition
type: docs
weight: 90
url: /net/slide-transition/
keywords: "Add slide transition, PowerPoint slide transition, morph transition, advanced slide transition, transition effects, C#, Csharp, .NET, Aspose.Slides"
description: " Add PowerPoint slide transition and transition effects in C# or .NET "
---

## **Add Slide Transition**
To make it easier to understand, we have demonstrated the use of Aspose.Slides for .NET to manage simple slide transitions. Developers can not only apply different slide transition effects on the slides but also customize the behavior of these transition effects. To create a simple slide transition effect, follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Apply a Slide Transition Type on the slide from one of the transition effects offered by Aspose.Slides for .NET through TransitionType enum
1. Write the modified presentation file.

```c#
// Instantiate Presentation class to load the source presentation file
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // Apply circle type transition on slide 1
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // Apply comb type transition on slide 2
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // Write the presentation to disk
    presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```


## **Add Advanced Slide Transition**
In the above section, we just applied a simple transition effect on the slide. Now, to make that simple transition effect even better and controlled, please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Apply a Slide Transition Type on the slide from one of the transition effects offered by Aspose.Slides for .NET
1. You can also set the transition to Advance On Click, after a specific time period or both.
1. If the slide transition is enabled to Advance On Click, the transition will only advance when someone will click the mouse. Moreover, if the Advance After Time property is set, the transition will advance automatically after the specified advance time will be passed.
1. Write the modified presentation as a presentation file.

```c#
// Instantiate Presentation class that represents a presentation file
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{

    // Apply circle type transition on slide 1
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


    // Set the transition time of 3 seconds
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // Apply comb type transition on slide 2
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


    // Set the transition time of 5 seconds
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // Apply zoom type transition on slide 3
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


    // Set the transition time of 7 seconds
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // Write the presentation to disk
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

Additionally, using the [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) property, you can check whether a slide transition has been configured to move to the next slide or disable the setting.

This C# code demonstrates the operation:

```c#
// Instantiates a Presentation class that represents a presentation file
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // Gets the slide Transition
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // Checks wthether the Advance After Time setting is enabled
        if (slideTransition.AdvanceAfter)
        {
            // Prints the Advance After Time value
            Console.WriteLine("The slide #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // Disables the transition after a specific time if the AdvancedAfterTime value is greater than 2 seconds
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```

## **Morph Transition**
Aspose.Slides for .NET now supports the [Morph Transition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition). They represent a new morph transition introduced in PowerPoint 2019. The Morph transition allows you to animate smooth movement from one slide to the next. This article describes the concept and how to use the Morph transition. To use the Morph transition effectively, you will need to have two slides with at least one object in common. The easiest way is to duplicate the slide and then move the object on the second slide to a different place.

The following code snippet shows you how to add a clone of the slide with some text to the presentation and set a transition of [morph type](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) to the second slide.



```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Morph Transition in PowerPoint Presentations";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}

```


## **Morph Transition Types**
New [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype) enum has been added. It represents different types of Morph slide transition.

TransitionMorphType enum has three members:

- ByObject: Morph transition will be performed considering shapes as indivisible objects.
- ByWord: Morph transition will be performed with transferring text by words where possible.
- ByChar: Morph transition will be performed with transferring text by characters where possible.

The following code snippet shows you how to set morph transition to slide and change morph type:

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```



## **Set Transition Effects**
Aspose.Slides for .NET supports setting the transition effects like, from black, from left, from right etc. In order to set the Transition Effect. Please follow the steps below:

- Create an instance of [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
- Get the reference of the slide.
- Setting the transition effect.
- Write the presentation as a [PPTX ](https://docs.fileformat.com/presentation/pptx/)file.

In the example given below, we have set the transition effects.

```c#
// Create an instance of Presentation class
Presentation presentation = new Presentation("AccessSlides.pptx");

// Set effect
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// Write the presentation to disk
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```

