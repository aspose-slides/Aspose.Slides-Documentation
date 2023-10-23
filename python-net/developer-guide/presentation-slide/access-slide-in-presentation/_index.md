---
title: Access Slide in Presentation
type: docs
weight: 20
url: /python-net/access-slide-in-presentation/
keywords: "Access PowerPoint Presentation, Access slide, Edit slide properties, Change slide position, Set slide number, index, ID, position  Python, Aspose.Slides"
description: "Access PowerPoint slide by index, ID, or position in Python. Edit slide properties"
---

Aspose.Slides allows you to access slides in two ways: by index and by ID.

## **Access Slide by Index**

All slides in a presentation are arranged numerically based on the slide position starting from 0. The first slide is accessible through index 0; the second slide is accessed through index 1; etc.

The Presentation class, representing a presentation file, exposes all slides as an [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) collection (collection of [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) objects). This Python code shows you how to access a slide through its index:

```python
import aspose.slides as slides

# Instantiates a Presentation object that represents a presentation file
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Gets a slide's reference through its index
    slide = presentation.slides[0]
```

## **Access Slide by ID**

Each slide in a presentation has a unique ID associated with it. You can use the `get_slide_by_id(id)` method (exposed by the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class) to target that ID. This Python code shows you how to provide a valid slide ID and access that slide through the `get_slide_by_id(id)` method:

```python
import aspose.slides as slides

# Instantiates a Presentation object that represents a presentation file
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Gets a Slide ID
    id = presentation.slides[0].slide_id
    # Accesses the slide through its ID
    slide = presentation.get_slide_by_id(id)
```

## **Change Slide Position**

Aspose.Slides allow you to change a slide position. For example, you can specify that the first slide should become the second slide.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get the slide's reference (whose position you want to change) through its index
1. Set a new position for the slide through the `slide_number` property. 
1. Save the modified presentation.

This Python code demonstrates an operation in which the slide in position 1 is moved to position 2:

```python
import aspose.slides as slides

# Instantiates a Presentation object that represents a presentation file
with slides.Presentation(path + "ChangePosition.pptx") as pres:
    # Gets the slide whose position will be changed
    sld = pres.slides[0]
    # Sets the new position for the slide
    sld.slide_number = 2
    # Saves the modified presentation
    pres.save("Aspose_out.pptx", slides.export.SaveFormat.PPTX)
```

The first slide became the second; the second slide became the first. When you change a slide's position, other slides are automatically adjusted.


## **Set Slide Number**

Using the `first_slide_number` property (exposed by the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class), you can specify a new number for the first slide in a presentation. This operation causes other slide numbers to be recalculated.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get the slide number.
1. Set the slide number.
1. Save the modified presentation.

This Python code demonstrates an operation where the first slide number is set to 10:

```python
import aspose.slides as slides

# Instantiates a Presentation object that represents a presentation file
with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    # Gets the slide number
    firstSlideNumber = presentation.first_slide_number
    # Sets the slide number
    presentation.first_slide_number = 10
    # Saves the modified presentation
    presentation.save("Set_Slide_Number_out.pptx", slides.export.SaveFormat.PPTX)
```

If you prefer to skip the first slide, you can start the numbering from the second slide (and hide the numbering for the first slide) this way: xxx

```python

```

