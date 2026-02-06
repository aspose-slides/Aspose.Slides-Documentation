---
title: GroupShape
type: docs
weight: 170
url: /python-net/examples/elements/group-shape/
keywords:
- group
- add group shape
- access group shape
- remove group shape
- ungroup shapes
- code examples
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Work with group shapes in Python using Aspose.Slides: create and ungroup, reorder child shapes, set transforms and bounds across PowerPoint and OpenDocument."
---

Examples for creating groups of shapes, accessing them, ungrouping, and removal using **Aspose.Slides for Python via .NET**.

## **Add a Group Shape**

Create a group containing two basic shapes.

```py
def add_group_shape():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Add a group shape.
        group = slide.shapes.add_group_shape()
        group.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        group.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 60, 0, 50, 50)

        presentation.save("group.pptx", slides.export.SaveFormat.PPTX)
```

## **Access a Group Shape**

Retrieve the first group shape from a slide.

```py
def access_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Access the first group shape on the slide.
        first_group = None
        for shape in slide.shapes:
            if isinstance(shape, slides.GroupShape):
                first_group = shape
                break
```

## **Remove a Group Shape**

Delete a group shape from the slide.

```py
def remove_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Assuming the first shape is a group shape.
        group = slide.shapes[0]

        # Remove the group shape.
        slide.shapes.remove(group)

        presentation.save("group_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ungroup Shapes**

Move shapes out of a group container.

```py
def ungroup_shapes():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Assuming the first shape is a group shape.
        group = slide.shapes[0]

        # Move shapes out of the group.
        for shape in group.shapes:
            slide.shapes.add_clone(shape)

        slide.shapes.remove(group)

        presentation.save("shapes_ungrouped.pptx", slides.export.SaveFormat.PPTX)
```
