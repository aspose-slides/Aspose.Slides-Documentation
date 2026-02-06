---
title: Slide
type: docs
weight: 10
url: /python-net/examples/elements/slide/
keywords:
- slide
- add slide
- access slide
- slide index
- clone slide
- reorder slides
- remove slide
- code examples
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Manage slides in Python with Aspose.Slides: create, clone, reorder, hide, set backgrounds and size, apply transitions, and export for PowerPoint and OpenDocument."
---

This article provides a series of examples that demonstrate how to work with slides using **Aspose.Slides for Python via .NET**. You’ll learn how to add, access, clone, reorder, and remove slides using the `Presentation` class.

Each example below includes a brief explanation followed by a code snippet in Python.

## **Add a Slide**

To add a new slide, you must first select a layout. In this example, we use the `Blank` layout and add an empty slide to the presentation.

```py
def add_slide():
    with slides.Presentation() as presentation:
        # Each slide is based on a layout, which itself is based on a master slide.
        # Use the Blank layout to create a new slide.
        blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Add a new empty slide using the selected layout.
        presentation.slides.add_empty_slide(blank_layout)

        presentation.save("slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip:** Each slide layout is derived from a master slide, which defines the overall design and placeholder structure. The image below illustrates how master slides and their associated layouts are organized in PowerPoint.

![Master and Layout Relationship](master-layout-slide.png)

## **Access Slides by Index**

You can access slides using their index. This is useful for iterating through or modifying specific slides.

```py
def access_slide():
    with slides.Presentation("slide.pptx") as presentation:
        # Access a slide by index.
        first_slide = presentation.slides[0]
```

## **Clone a Slide**

This example demonstrates how to clone an existing slide. The cloned slide is automatically added to the end of the slide collection.

```py
def clone_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Clone the slide; it will be added at the end of the presentation.
        cloned_slide = presentation.slides.add_clone(slide)

        presentation.save("slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

## **Reorder Slides**

You can change the order of slides by moving one to a new index. In this case, we move a slide to the first position.

```py
def reorder_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[1]

        # Move the slide to the first position (others shift down).
        presentation.slides.reorder(0, slide)

        presentation.save("slide_reordered.pptx", slides.export.SaveFormat.PPTX)
```

## **Remove a Slide**

To remove a slide, simply reference it and call `remove`. This example removes the first slide.

```py
def remove_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Remove the slide.
        presentation.slides.remove(slide)

        presentation.save("slide_removed.pptx", slides.export.SaveFormat.PPTX)
```
