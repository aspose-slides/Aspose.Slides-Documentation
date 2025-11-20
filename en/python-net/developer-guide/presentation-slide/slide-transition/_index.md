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

## **Overview**

Aspose.Slides for Python provides full control over slide transitions, from selecting a transition type to configuring timing and triggers as part of automated presentation workflows. You can set slides to advance on click and/or after a specified delay and refine visual behavior with effects such as cuts from black or directional entrances. The library also supports the Morph transition introduced in PowerPoint 2019, including modes that morph by object, word, or character to create smooth, cohesive motion between slides.

## **Add Slide Transitions**

To make this easier to understand, this example demonstrates how to use Aspose.Slides for Python to manage simple slide transitions. Developers can apply different slide transition effects to slides and customize their behavior. To create a simple slide transition, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Apply a slide transition using one of the effects from the [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) enum.
1. Save the modified presentation file.

```py
import aspose.slides as slides

# Instantiate the Presentation class to load a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Apply a circle transition to slide 1.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Apply a comb transition to slide 2.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Save the presentation to disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Add Advanced Slide Transitions**

In this section, we applied a simple transition effect to a slide. To make that effect more controlled and polished, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Apply a slide transition using one of the effects from the [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) enum.
1. Configure the transition to Advance On Click, after a specific time period, or both.
1. Save the modified presentation file.

If **Advance On Click** is enabled, the slide advances only when the user clicks. If the **Advance After Time** property is set, the slide advances automatically after the specified interval.

```py
import aspose.slides as slides

# Instantiate the Presentation class to open a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # Apply a circle transition to slide 1.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Enable advance on click and set a 3-second auto-advance.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # Apply a comb transition to slide 2.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Enable advance on click and set a 5-second auto-advance.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # Apply a zoom transition to slide 3.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Enable advance on click and set a 7-second auto-advance.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # Save the presentation to disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph Transition**

Aspose.Slides for Python supports the [Morph transition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/), which animates the smooth movement from one slide to the next. This section explains how to use the Morph transition. To use it effectively, you need two slides with at least one object in common. The easiest approach is to duplicate a slide and then move the object to a different position on the second slide.

The following code snippet shows how to clone a slide that contains text and apply a Morph transition to the second slide.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Clone the first slide to create a second slide with the same shapes for Morph continuity.
    slide1 = presentation.slides.add_clone(slide0)

    # Select the same rectangle on the second slide and change its position and size.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # Enable the Morph transition on the second slide to animate the shape changes smoothly.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph Transition Types**

The [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) enum represents the different types of Morph slide transitions.

The following code snippet shows how to apply a Morph transition to a slide and change the morph type:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Transition Effects**

Aspose.Slides for Python lets you set transition effects such as **From Black**, **From Left**, **From Right**, etc. To configure a transition effect, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to the slide.
1. Set the desired transition effect.
1. Save the presentation as a PPTX file.

In the example below, we set several transition effects.

```py
import aspose.slides as slides

# Instantiate the Presentation class to open a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Apply a Cut transition and enable From Black.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # Save the presentation to disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I control the playback speed of a slide transition?**

Yes. Set the transition’s [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) using the [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) setting (e.g., slow/medium/fast).

**Can I attach audio to a transition and make it loop?**

Yes. You can embed a sound for the transition and control behavior via settings like sound mode and looping (e.g., [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/), plus metadata such as [sound_is_built_in](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) and [sound_name](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**What’s the fastest way to apply the same transition to every slide?**

Configure the desired transition type on each slide’s transition settings; transitions are stored per slide, so applying the same type across all slides gives a consistent result.

**How can I check which transition is currently set on a slide?**

Inspect the slide’s [transition settings](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) and read its [transition type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/); that value tells you exactly which effect is applied.
