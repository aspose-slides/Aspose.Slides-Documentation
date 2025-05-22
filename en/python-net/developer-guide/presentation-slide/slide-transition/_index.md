---
title: Manage Slide Transitions in Presentations Using Python
linktitle: Slide Transition
type: docs
weight: 90
url: /python-net/slide-transition/
keywords:
- slide transition
- add slide transition
- apply slide transition
- advanced slide transition
- morph transition
- transition type
- transition effect
- Python
- Aspose.Slides
description: "Discover how to customize slide transitions in Aspose.Slides for Python via .NET, with step-by-step guidance for PowerPoint and OpenDocument presentations."
---

## **Add Slide Transition**
To make it easier to understand, we have demonstrated the use of Aspose.Slides for Python via .NET to manage simple slide transitions. Developers can not only apply different slide transition effects on the slides but also customize the behavior of these transition effects. To create a simple slide transition effect, follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Apply a Slide Transition Type on the slide from one of the transition effects offered by Aspose.Slides for Python via .NET through TransitionType enum
1. Write the modified presentation file.

```py
import aspose.slides as slides

# Instantiate Presentation class to load the source presentation file
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Apply circle type transition on slide 1
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Apply comb type transition on slide 2
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Write the presentation to disk
    presentation.save("SampleTransition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Add Advanced Slide Transition**
In the above section, we just applied a simple transition effect on the slide. Now, to make that simple transition effect even better and controlled, please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Apply a Slide Transition Type on the slide from one of the transition effects offered by Aspose.Slides for Python via .NET
1. You can also set the transition to Advance On Click, after a specific time period or both.
1. If the slide transition is enabled to Advance On Click, the transition will only advance when someone will click the mouse. Moreover, if the Advance After Time property is set, the transition will advance automatically after the specified advance time will be passed.
1. Write the modified presentation as a presentation file.

```py
import aspose.slides as slides

# Instantiate Presentation class that represents a presentation file
with slides.Presentation(path + "BetterSlideTransitions.pptx") as pres:
    # Apply circle type transition on slide 1
    pres.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE


    # Set the transition time of 3 seconds
    pres.slides[0].slide_show_transition.advance_on_click = True
    pres.slides[0].slide_show_transition.advance_after_time = 3000

    # Apply comb type transition on slide 2
    pres.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB


    # Set the transition time of 5 seconds
    pres.slides[1].slide_show_transition.advance_on_click = True
    pres.slides[1].slide_show_transition.advance_after_time = 5000

    # Apply zoom type transition on slide 3
    pres.slides[2].slide_show_transition.type = slides.slideshow.TransitionType.ZOOM


    # Set the transition time of 7 seconds
    pres.slides[2].slide_show_transition.advance_on_click = True
    pres.slides[2].slide_show_transition.advance_after_time = 7000

    # Write the presentation to disk
    pres.save("SampleTransition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Morph Transition**
Aspose.Slides for Python via .NET now supports the [Morph Transition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/imorphtransition/). They represent a new morph transition introduced in PowerPoint 2019. The Morph transition allows you to animate smooth movement from one slide to the next. This article describes the concept and how to use the Morph transition. To use the Morph transition effectively, you will need to have two slides with at least one object in common. The easiest way is to duplicate the slide and then move the object on the second slide to a different place.

The following code snippet shows you how to add a clone of the slide with some text to the presentation and set a transition of [morph type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/imorphtransition/) to the second slide.



```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    autoshape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    autoshape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    presentation.slides.add_clone(presentation.slides[0])

    presentation.slides[1].shapes[0].x += 100
    presentation.slides[1].shapes[0].y += 50
    presentation.slides[1].shapes[0].width -= 200
    presentation.slides[1].shapes[0].height -= 10

    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```


## **Morph Transition Types**
New [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) enum has been added. It represents different types of Morph slide transition.

TransitionMorphType enum has three members:

- ByObject: Morph transition will be performed considering shapes as indivisible objects.
- ByWord: Morph transition will be performed with transferring text by words where possible.
- ByChar: Morph transition will be performed with transferring text by characters where possible.

The following code snippet shows you how to set morph transition to slide and change morph type:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    presentation.slides[0].slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```



## **Set Transition Effects**
Aspose.Slides for Python via .NET supports setting the transition effects like, from black, from left, from right etc. In order to set the Transition Effect. Please follow the steps below:

- Create an instance of [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)class.
- Get the reference of the slide.
- Setting the transition effect.
- Write the presentation as a [PPTX ](https://docs.fileformat.com/presentation/pptx/)file.

In the example given below, we have set the transition effects.

```py
import aspose.slides as slides

# Create an instance of Presentation class
with slides.Presentation(path + "AccessSlides.pptx") as presentation:

    # Set effect
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CUT
    presentation.slides[0].slide_show_transition.value.from_black = True

    # Write the presentation to disk
    presentation.save("SetTransitionEffects_out.pptx", slides.export.SaveFormat.PPTX)
```

