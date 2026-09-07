---
title: Slide Transition
type: docs
weight: 110
url: /python-java/examples/elements/slide-transition/
keywords:
- code example
- slide transition
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Apply and remove slide transitions and set automatic slide advance timings with Aspose.Slides for Python via Java code examples for PPT, PPTX, and ODP presentations."
---

This article demonstrates applying slide transition effects and timings with **Aspose.Slides for Python via Java**.

Install the package as described in [Installation](/slides/python-java/installation/). Each example imports `asposeslides` before starting the JVM, then imports the API after the JVM is running.

## **Add a Slide Transition**

Apply a fade transition effect to the first slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Apply a fade transition.
    slide.getSlideShowTransition().setType(TransitionType.Fade)
finally:
    presentation.dispose()
```

## **Access a Slide Transition**

Read the transition type currently assigned to a slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Push)

    # Access the transition type.
    transition_type = slide.getSlideShowTransition().getType()
finally:
    presentation.dispose()
```

## **Remove a Slide Transition**

Clear any transition effect. JPype exposes the Java constant named `None` as `None_` because `None` is a reserved word in Python.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Fade)

    # Remove the transition effect.
    slide.getSlideShowTransition().setType(TransitionType.None_)
finally:
    presentation.dispose()
```

## **Set Transition Duration**

Specify how long the slide is displayed before advancing automatically. This example advances after two seconds and also allows advancing with a mouse click. This timing controls slide advance, not the speed of the transition effect.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setAdvanceOnClick(True)
    slide.getSlideShowTransition().setAdvanceAfter(True)
    slide.getSlideShowTransition().setAdvanceAfterTime(2000)  # In milliseconds.
finally:
    presentation.dispose()
```
