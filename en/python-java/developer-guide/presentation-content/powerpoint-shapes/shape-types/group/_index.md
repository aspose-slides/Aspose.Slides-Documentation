---
title: Group Presentation Shapes in Python via Java
linktitle: Shape Group
type: docs
weight: 40
url: /python-java/group/
keywords:
- group shape
- shape group
- add group
- alternative text
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Learn to group and ungroup shapes in PowerPoint decks using Aspose.Slides for Python via Java—a step-by-step guide with free Python code."
---

## **Overview**

This article explains how to work with group shapes in Aspose.Slides. It shows how to add a group shape to a slide, place shapes inside it, and save the updated presentation. It also demonstrates how to access shapes stored inside a group and read their alternative text using [getAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText). In addition, the article briefly covers related group-shape capabilities such as nested groups, z-order, and locking options.

## **Add a Group Shape**

Aspose.Slides supports working with group shapes on slides. This feature helps developers create richer presentations. Aspose.Slides for Python via Java supports adding and accessing group shapes. You can populate a group shape with shapes or access its properties. To add a group shape to a slide using Aspose.Slides for Python via Java:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add a group shape to the slide.
1. Add shapes to the group shape.
1. Save the modified presentation as a PPTX file.

The example below adds a group shape to a slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame, ShapeType

# Instantiate the Presentation class.
presentation = Presentation()
try:
    # Get the first slide.
    slide = presentation.getSlides().get_Item(0)

    # Access the slide's shape collection.
    slide_shapes = slide.getShapes()

    # Add a group shape to the slide.
    group_shape = slide_shapes.addGroupShape()

    # Add shapes inside the group shape.
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100)

    # Set the group shape's frame.
    group_frame = ShapeFrame(100, 300, 500, 40, NullableBool.False_, NullableBool.False_, 0)
    group_shape.setFrame(group_frame)

    # Write the PPTX file to disk.
    presentation.save("GroupShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Access Alternative Text**

This section shows how to access the alternative text of shapes inside a group on a slide. To access this text using Aspose.Slides for Python via Java:

1. Instantiate the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class that represents a PPTX file.
1. Get a reference to a slide by its index.
1. Access the slide's shape collection.
1. Access the group shape.
1. Read the alternative text of its shapes using [getAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText).

The example below accesses the alternative text of shapes inside a group:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation

# Instantiate the Presentation class that represents the PPTX file.
presentation = Presentation("AltText.pptx")
try:
    # Get the first slide.
    slide = presentation.getSlides().get_Item(0)

    for i in range(slide.getShapes().size()):
        # Access a shape in the slide's shape collection.
        shape = slide.getShapes().get_Item(i)

        if isinstance(shape, GroupShape):
            # Access the shapes inside the group.
            for j in range(shape.getShapes().size()):
                child_shape = shape.getShapes().get_Item(j)

                # Read the alternative text.
                print(child_shape.getAlternativeText())
finally:
    presentation.dispose()
```

## **FAQ**

**Is nested grouping (a group inside a group) supported?**

Yes. [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/) has a [getParentGroup](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getParentGroup) method, which indicates hierarchy support: a group can be a child of another group.

**How do I control the group's z-order relative to other objects on the slide?**

Use the [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/) object's [getZOrderPosition](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getZOrderPosition) method to inspect its position in the display stack.

**Can I prevent moving, editing, or ungrouping?**

Yes. The group's locks are exposed via [getGroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getGroupShapeLock), which lets you restrict operations on the object.
