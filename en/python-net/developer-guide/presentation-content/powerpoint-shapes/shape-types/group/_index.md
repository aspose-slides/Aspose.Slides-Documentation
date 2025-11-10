---
title: Group Presentation Shapes with Python
linktitle: Shape Group
type: docs
weight: 40
url: /python-net/group/
keywords:
- group shape
- shape group
- add group
- alternative text
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Learn to group and ungroup shapes in PowerPoint and OpenDocument decks using Aspose.Slides for Python—fast, step-by-step guide with free code."
---

## **Overview**

Grouping shapes allows you to treat multiple drawing objects as a single unit so you can move, resize, format, and transform them together. With Aspose.Slides for Python, you can create a [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), add and arrange child shapes inside it, and persist the result to PPTX. This article demonstrates how to add a group shape on a slide and how to access accessibility metadata such as Alt Text from shapes within the group, enabling cleaner structure and richer, more maintainable presentations.

## **Add Group Shapes**

Aspose.Slides supports working with group shapes on a slide. This feature lets you build richer presentations by treating multiple shapes as a single object. You can add new group shapes, access existing ones, populate them with child shapes, and read or modify any of their properties. To add a group shape to a slide:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a reference to a slide by index.
3. Add a [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) to the slide.
4. Add shapes to the new group shape.
5. Save the modified presentation as a PPTX file.

The example below shows how to add a group shape to a slide.

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add a group shape to the slide.
    group_shape = slide.shapes.add_group_shape()

    # Add shapes inside the group shape.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Write the PPTX file to disk.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Access the Alt Text Property**

This section explains how to read the Alt Text of shapes contained within a group shape on a slide using Aspose.Slides. To access the Alt Text of the shapes:

1. Instantiate the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class to represent a PPTX file.
2. Obtain a reference to the slide by its index.
3. Access the slide’s shapes collection.
4. Access the [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/).
5. Read the Alt Text property.

The example below retrieves the Alt Text of shapes contained within group shapes.

```py
import aspose.slides as slides

# Instantiate the Presentation class to open the PPTX file.
with slides.Presentation("group_shape.pptx") as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # Access the group shape.
            for child_shape in shape.shapes:
                # Access the Alt Text property.
                print(child_shape.alternative_text)
```

## **FAQ**

**Is nested grouping (a group inside a group) supported?**

Yes. [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) has a [parent_group](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/parent_group/) property, which directly indicates hierarchy support (a group can be a child of another group).

**How do I control the group’s z-order relative to other objects on the slide?**

Use the [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)’s [z_order_position](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/z_order_position/) property to inspect its position in the display stack.

**Can I prevent moving/editing/ungrouping?**

Yes. The group’s lock section is exposed via [group_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/group_shape_lock/), which lets you restrict operations on the object.
