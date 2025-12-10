---
title: Manage Slide Transitions in Presentations Using C++
linktitle: Slide Transition
type: docs
weight: 80
url: /cpp/slide-transition/
keywords:
- slide transition
- add slide transition
- apply slide transition
- advanced slide transition
- morph transition
- transition type
- transition effect
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Discover how to customize slide transitions in Aspose.Slides for C++, with step-by-step guidance for PowerPoint and OpenDocument presentations."
---


## **Add Slide Transition**
To make it easier to understand, we have demonstrated the use of Aspose.Slides for C++ to manage simple slide transitions. Developers can not only apply different slide transition effects on the slides, but also customize the behavior of these transition effects. To create a simple slide transition effect, follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. Apply a Slide Transition Type on the slide from one of the transition effects offered by Aspose.Slides for C++ through TransitionType enum.
1. Write the modified presentation file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **Add Advanced Slide Transition**
In the above section, we just applied a simple transition effect on the slide. Now, to make that simple transition effect even better and controlled, please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. Apply a Slide Transition Type on the slide from one of the transition effects offered by Aspose.Slides for C++
1. You can also set the transition to Advance On Click, after a specific time period or both.
1. If the slide transition is enabled to Advance On Click, the transition will only advance when someone will click the mouse. Moreover, if the Advance After Time property is set, the transition will advance automatically after the specified advance time will be passed.
1. Write the modified presentation as a presentation file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}


## **Morph Transition**
Aspose.Slides for C++ now supports the Morph Transition. They represent new morph transition introduced in PowerPoint 2019. The Morph transition allows you to animate smooth movement from one slide to the next. This article describes the concept and how to use the Morph transition. To use the Morph transition effectively, you will need to have two slides with at least one object in common. The easiest way is to duplicate the slide and then move the object on the second slide to a different place.

The following code snippet shows you how to add a clone of the slide with some text to the presentation and set a transition of morph type to the second slide.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **Morph Transition Types**
New Aspose.Slides.SlideShow.TransitionMorphType enum has been added. It represents different types of Morph slide transition.

TransitionMorphType enum has three members:

- ByObject: Morph transition will be performed considering shapes as indivisible objects.
- ByWord: Morph transition will be performed with transferring text by words where possible.
- ByChar: Morph transition will be performed with transferring text by characters where possible.

The following code snippet shows you how to set morph transition to slide and change morph type:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}


## **Set Transition Effects**
Aspose.Slides for C++ supports setting the transition effects like, from black, from left, from right etc. In order to set the Transition Effect. Please follow the steps below:

- Create an instance of Presentation class.
- Get reference of the slide.
- Setting the transition effect.
- Write the presentation as a PPTX file.

In the example given below, we have set the transition effects.


{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}

## **FAQ**

**Can I control the playback speed of a slide transition?**

Yes. Set the transition’s [speed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_speed/) using the [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) setting (e.g., slow/medium/fast).

**Can I attach audio to a transition and make it loop?**

Yes. You can embed a sound for the transition and control behavior via settings like sound mode and looping (e.g., [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_sound/), [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundmode/), [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundloop/), plus metadata such as [set_SoundIsBuiltIn](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundisbuiltin/) and [set_SoundName](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundname/)).

**What’s the fastest way to apply the same transition to every slide?**

Configure the desired transition type on each slide’s transition settings; transitions are stored per slide, so applying the same type across all slides gives a consistent result.

**How can I check which transition is currently set on a slide?**

Inspect the slide’s [transition settings](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_slideshowtransition/) and read its [transition type](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/get_type/); that value tells you exactly which effect is applied.
