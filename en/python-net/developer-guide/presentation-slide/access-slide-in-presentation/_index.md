---
title: Access Slides in Presentations with Python
linktitle: Access Slide
type: docs
weight: 20
url: /python-net/access-slide-in-presentation/
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
description: "Learn how to access and manage slides in PowerPoint and OpenDocument presentations with Aspose.Slides for Python via .NET. Boost productivity with code examples."
---

## **Overview**

This article explains how to access specific slides in a PowerPoint presentation using Aspose.Slides for Python. It shows how to open a presentation, reference slides by index or by unique ID, and read basic slide information needed for navigation within the file. With these techniques, you can reliably locate the exact slide you want to inspect or process.

## **Access a Slide by Index**

Slides in a presentation are indexed by position starting at 0. The first slide has index 0, the second slide has index 1, and so on.

The [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class (which represents a presentation file) exposes slides through a [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) of [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) objects.

The following Python code shows how to access a slide by its index:

```python
import aspose.slides as slides

# Create a Presentation that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Get a slide by its index.
    slide = presentation.slides[0]
```

## **Access a Slide by ID**

Each slide in a presentation has a unique ID associated with it. You can use the [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) method (exposed by the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class) to target that ID. 

The following Python code shows how to provide a valid slide ID and access that slide through the [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) method:

```python
import aspose.slides as slides

# Create a Presentation that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Get a slide ID.
    id = presentation.slides[0].slide_id
    # Access the slide by its ID.
    slide = presentation.get_slide_by_id(id)
```

## **Change a Slide's Position**

Aspose.Slides allows you to change a slide’s position. For example, you can make the first slide become the second.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to the slide whose position you want to change by its index.
1. Set a new position for the slide through the [slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) property.
1. Save the modified presentation.

The following Python code moves the slide in position 1 to position 2:

```python
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Get the slide whose position will be changed.
    slide = presentation.slides[0]
    # Set the new position for the slide.
    slide.slide_number = 2
    # Save the modified presentation.
    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)
```

The first slide becomes the second; the second slide becomes the first. When you change a slide’s position, other slides are adjusted automatically.

## **Set the Slide Number**

Using the [first_slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) property (exposed by the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class), you can specify a new number for the first slide in a presentation. This operation causes other slide numbers to be recalculated.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Set the slide number.
1. Save the modified presentation.

The following Python code demonstrates an operation where the first slide number is set to 10:

```python
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Set the slide number.
    presentation.first_slide_number = 10
    # Save the modified presentation.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

If you prefer to skip the first slide, you can start numbering from the second slide (and hide the number on the first slide) like this:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # Set the number for the first slide in the presentation.
    presentation.first_slide_number = 0

    # Show slide numbers for all slides.
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # Hide the slide number on the first slide.
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # Save the modified presentation.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Does the slide number a user sees match the collection’s zero-based index?**

The number shown on a slide can start from an arbitrary value (e.g., 10) and does not have to match the index; the relationship is controlled by the presentation’s [first slide number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) setting.

**Do hidden slides affect indexing?**

Yes. A hidden slide remains in the collection and is counted in indexing; "hidden" refers to display, not its position in the collection.

**Does a slide’s index change when other slides are added or removed?**

Yes. Indexes always reflect the current order in slides and are recalculated upon insert, delete, and move operations.
