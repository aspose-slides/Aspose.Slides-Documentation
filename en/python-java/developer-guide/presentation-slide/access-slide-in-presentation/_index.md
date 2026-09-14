---
title: Access Presentation Slides in Python
linktitle: Access Slide
type: docs
weight: 20
url: /python-java/access-slide-in-presentation/
keywords:
- access slide
- slide index
- slide id
- slide position
- change position
- slide properties
- slide number
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn how to access and manage slides in PowerPoint and OpenDocument presentations with Aspose.Slides for Python via Java. Boost productivity with code examples."
---

## **Overview**

This article explains how to access and manage slides in a presentation using Aspose.Slides. It shows how to retrieve slides by their zero-based index from the slides collection and how to access a slide by its unique ID using the [getSlideById](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlideById) method.

You will also learn how to change a slide’s position by using the [setSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#setSlideNumber) method and how to define the starting slide number for a presentation with the [setFirstSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#setFirstSlideNumber) method. The examples demonstrate loading a presentation, getting slide references, updating slide order or numbering, and saving the modified presentation.

## **Access a Slide by Index**

All slides in a presentation are arranged numerically based on the slide position starting from 0. The first slide is accessible through index 0; the second slide is accessed through index 1; etc.

The [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class, representing a presentation file, exposes all slides as a [SlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/) collection (collection of [Slide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) objects). This Python code shows you how to access a slide through its index:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Instantiate a Presentation object that represents a presentation file.
presentation = Presentation("demo.pptx")
try:
    # Access a slide using its index.
    slide = presentation.getSlides().get_Item(0)
finally:
    presentation.dispose()
```

## **Access a Slide by ID**

Each slide in a presentation has a unique ID associated with it. You can use the [getSlideById](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlideById) method (exposed by the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class) to target that ID. This Python code shows you how to provide a valid slide ID and access that slide through the [getSlideById](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlideById) method:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Instantiate a Presentation object that represents a presentation file.
presentation = Presentation("demo.pptx")
try:
    # Get a slide ID.
    slide_id = presentation.getSlides().get_Item(0).getSlideId()

    # Access the slide through its ID.
    slide = presentation.getSlideById(slide_id)
finally:
    presentation.dispose()
```

## **Change the Slide Position**

Aspose.Slides allows you to change a slide's position. For example, you can specify that the first slide should become the second slide.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Get the slide's reference (whose position you want to change) through its index.
1. Set a new position for the slide through the [setSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#setSlideNumber) method.
1. Save the modified presentation.

This Python code demonstrates an operation in which the slide in position 1 is moved to position 2:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instantiate a Presentation object that represents a presentation file.
presentation = Presentation("Presentation.pptx")
try:
    # Get the slide whose position will be changed.
    slide = presentation.getSlides().get_Item(0)

    # Set the new position for the slide.
    slide.setSlideNumber(2)

    # Save the modified presentation.
    presentation.save("helloworld_Pos.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The first slide became the second; the second slide became the first. When you change a slide's position, other slides are automatically adjusted.


## **Set the Slide Number**

Using the [setFirstSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#setFirstSlideNumber) method (exposed by the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class), you can specify a new number for the first slide in a presentation. This operation causes other slide numbers to be recalculated.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Get the slide number.
1. Set the slide number.
1. Save the modified presentation.

This Python code demonstrates an operation where the first slide number is set to 10:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instantiate a Presentation object that represents a presentation file.
presentation = Presentation("HelloWorld.pptx")
try:
    # Get the slide number.
    first_slide_number = presentation.getFirstSlideNumber()

    # Set the slide number.
    presentation.setFirstSlideNumber(10)

    # Save the modified presentation.
    presentation.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

If you prefer to skip the first slide, you can start the numbering from the second slide (and hide the numbering for the first slide) this way:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    # Set the number for the first presentation slide.
    presentation.setFirstSlideNumber(0)

    # Show slide numbers for all slides.
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(True)

    # Hide the slide number for the first slide.
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(False)

    # Save the modified presentation.
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Does the slide number a user sees match the collection’s zero-based index?**

The number shown on a slide can start from an arbitrary value (e.g., 10) and does not have to match the index; the relationship is controlled by the presentation’s [first slide number](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#setFirstSlideNumber) setting.

**Do hidden slides affect indexing?**

Yes. A hidden slide remains in the collection and is counted in indexing; "hidden" refers to display, not its position in the collection.

**Does a slide’s index change when other slides are added or removed?**

Yes. Indexes always reflect the current order in slides and are recalculated upon insert, delete, and move operations.
