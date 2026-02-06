---
title: SlideTransition
type: docs
weight: 110
url: /python-net/examples/elements/slide-transition/
keywords:
- slide transition
- add slide transition
- access slide transition
- remove slide transition
- transition duration
- code examples
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Control slide transitions in Python with Aspose.Slides: choose types, speed, sound, and timing to polish presentations in PPT, PPTX and ODP."
---

Demonstrates applying slide transition effects and timings with **Aspose.Slides for Python via .NET**.

## **Add a Slide Transition**

Apply a fade transition effect to the first slide.

```py
def add_slide_transition():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Apply a fade transition.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.FADE

        presentation.save("slide_transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Access a Slide Transition**

Read the transition type currently assigned to a slide.

```py
def access_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Access the transition type.
        transition_type = slide.slide_show_transition.type
```

## **Remove a Slide Transition**

Clear any transition effect by setting the type to `NONE`.

```py
def remove_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Remove transition by setting none.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.NONE

        presentation.save("slide_transition_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Transition Duration**

Specify how long the slide is displayed before advancing automatically.

```py
def set_transition_duration():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        slide.slide_show_transition.advance_on_click = True
        slide.slide_show_transition.advance_after_time = 2000  # in milliseconds.

        presentation.save("transition_duration.pptx", slides.export.SaveFormat.PPTX)
```
