---
title: Slide Transition
type: docs
weight: 80
url: /java/slide-transition/
keywords: "PowerPoint slide transition, morph transition in Java"
description: "PowerPoint slide transition, PowerPoint morph transition in Java"
---


## **Overview**
{{% alert color="primary" %}} 

Aspose.Slides for Java also allows developers to manage or customize the slide transition effects of the slides. In this topic, we will discuss about controlling slide transitions with a great ease using Aspose.Slides for Java.

{{% /alert %}} 

To make it easier to understand, we have demonstrated the use of Aspose.Slides for Java to manage simple slide transitions. Developers can not only apply different slide transition effects on the slides, but also customize the behavior of these transition effects.

## **Simple Transition**
To create a simple slide transition effect, follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Id.
- Apply a Slide Transition Effect on the slide from one of the transition effects offered by Aspose.Slides for Java.
- Write the modified presentation as a PPT file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Transitions-SimpleTransition-SimpleTransition.java" >}}

## **Advanced Transition**
In the above section, we just applied a simple transition effect on the slide. Now, to make that simple transition effect even better and controlled, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Id or Position.
- Apply a Slide Transition Effect on the slide from one of the transition effects offered by Aspose.Slides for Java.
- You can also set the Speed of the transition to create a more customized effect.
- You can also set the transition to advance on click, after a specific time period or both. If the slide transition is enabled to Advance On Click then the transition will only advance when someone will click the mouse. Moreover, if the slide transition is enabled to Advance On Time, then the transition will advance automatically after the specific advance time will be passed.
- If you enable the slide transition to advance after a specific time period, you would also need to set the Advance Time for the slide transition.
- Write the modified presentation as a PPT file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Transitions-BetterTransition-BetterTransition.java" >}}

## **Manage Simple Slide Transition**
To make it easier to understand, we have demonstrated the use of Aspose.Slides for Java to manage simple slide transitions. Developers can not only apply different slide transition effects on the slides, but also customize the behavior of these transition effects.To create a simple slide transition effect, follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Apply a Slide Transition Type on the slide from one of the transition effects offered by Aspose.Slides for Java through **TransitionType** enum.
- Write the modified presentation file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Transitions-ManagingSimpleSlideTransitions-ManagingSimpleSlideTransitions.java" >}}

## **Manage Advanced Slide Transition**
In the above section, we just applied a simple transition effect on the slide. Now, to make that simple transition effect even better and controlled, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Apply a Slide Transition Type on the slide from one of the transition effects offered by Aspose.Slides for Java.
- You can also set the transition to Advance On Click, after a specific time period or both. If the slide transition is enabled to Advance On Click, the transition will only advance when someone will click the mouse. Moreover, if the Advance After Time property is set, the transition will advance automatically after the specified advance time will be passed.
- Write the modified presentation as a presentation file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Transitions-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.java" >}}

## **Set Transition Effect**
{{% alert color="primary" %}} 

Aspose.Slides for Java supports setting the transition effects like, from black, from left, from right etc. In this topic, we will see with example how to set the transition effects in Aspose.Slides.

{{% /alert %}} 

In order to set the Transition Effect. Please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Get reference of the slide.
- Setting the transition effect.
- Write the presentation as a PPTX file.

In the example given below, we have set the transition effects.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Transitions-SettingTheTransitionEffects-SettingTheTransitionEffects.java" >}}


## **Morph Transition**
{{% alert color="primary" %}} 

Aspose.Slides for Java now supports the Morph Transition. They represent new morph transition introduced in PowerPoint 2019.

{{% /alert %}} 

The Morph transition allows you to animate smooth movement from one slide to the next. This article describes the concept and how to use the Morph transition. To use the Morph transition effectively, you will need to have two slides with at least one object in common. The easiest way is to duplicate the slide and then move the object on the second slide to a different place.

The following code snippet shows you how to add a clone of the slide with some text to the presentation and set a transition of morph type to the second slide.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Transitions-SupportOfMorphTransition-SupportOfMorphTransition.java" >}}

## **Morph Transition Types**
New Aspose.Slides.SlideShow.TransitionMorphType enum has been added. It represents different types of Morph slide transition.

TransitionMorphType enum has three members:

- ByObject: Morph transition will be performed considering shapes as indivisible objects.
- ByWord: Morph transition will be performed with transferring text by words where possible.
- ByChar: Morph transition will be performed with transferring text by characters where possible.

The following code snippet shows you how to set morph transition to slide and change morph type:



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Transitions-SetTransitionMorphType-SetTransitionMorphType.java" >}}
