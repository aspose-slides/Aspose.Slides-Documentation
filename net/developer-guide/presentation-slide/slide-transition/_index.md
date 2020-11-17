---
title: Slide Transition
type: docs
weight: 80
url: /net/slide-transition/
keywords: "PowerPoint slide transition, morph transition"
description: "PowerPoint slide transition, PowerPoint morph transition with Aspose.Slides."
---

## **Add Slide Transition**
To make it easier to understand, we have demonstrated the use of Aspose.Slides for .NET to manage simple slide transitions. Developers can not only apply different slide transition effects on the slides but also customize the behavior of these transition effects. To create a simple slide transition effect, follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Apply a Slide Transition Type on the slide from one of the transition effects offered by Aspose.Slides for .NET through TransitionType enum
1. Write the modified presentation file.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Transitions-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cs" >}}
## **Add Advanced Slide Transition**
In the above section, we just applied a simple transition effect on the slide. Now, to make that simple transition effect even better and controlled, please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Apply a Slide Transition Type on the slide from one of the transition effects offered by Aspose.Slides for .NET
1. You can also set the transition to Advance On Click, after a specific time period or both.
1. If the slide transition is enabled to Advance On Click, the transition will only advance when someone will click the mouse. Moreover, if the Advance After Time property is set, the transition will advance automatically after the specified advance time will be passed.
1. Write the modified presentation as a presentation file.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Transitions-BetterSlideTransitions-BetterSlideTransitions.cs" >}}
## **Morph Transition**
Aspose.Slides for .NET now supports the [Morph Transition](https://apireference.aspose.com/net/slides/aspose.slides.slideshow/imorphtransition). They represent a new morph transition introduced in PowerPoint 2019. The Morph transition allows you to animate smooth movement from one slide to the next. This article describes the concept and how to use the Morph transition. To use the Morph transition effectively, you will need to have two slides with at least one object in common. The easiest way is to duplicate the slide and then move the object on the second slide to a different place.

The following code snippet shows you how to add a clone of the slide with some text to the presentation and set a transition of [morph type](https://apireference.aspose.com/net/slides/aspose.slides.slideshow/imorphtransition/properties/morphtype) to the second slide.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Slides-Transitions-SupportOfMorphTransition-SupportOfMorphTransition.cs" >}}
## **Morph Transition Types**
New [Aspose.Slides.SlideShow.TransitionMorphType](https://apireference.aspose.com/net/slides/aspose.slides.slideshow/transitionmorphtype) enum has been added. It represents different types of Morph slide transition.

TransitionMorphType enum has three members:

- ByObject: Morph transition will be performed considering shapes as indivisible objects.
- ByWord: Morph transition will be performed with transferring text by words where possible.
- ByChar: Morph transition will be performed with transferring text by characters where possible.

The following code snippet shows you how to set morph transition to slide and change morph type:



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Slides-Transitions-SetTransitionMorphType-SetTransitionMorphType.cs" >}}
## **Set Transition Effects**
Aspose.Slides for .NET supports setting the transition effects like, from black, from left, from right etc. In order to set the Transition Effect. Please follow the steps below:

- Create an instance of [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)class.
- Get the reference of the slide.
- Setting the transition effect.
- Write the presentation as a [PPTX ](https://wiki.fileformat.com/presentation/pptx/)file.

In the example given below, we have set the transition effects.



{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Transitions-SetTransitionEffects-SetTransitionEffects.cs" >}}
