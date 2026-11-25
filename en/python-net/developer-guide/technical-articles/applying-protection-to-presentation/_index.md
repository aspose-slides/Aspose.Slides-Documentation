---
title: Restrict Presentation Edits with Shape Locks in Python
linktitle: Restrict Presentation Edits
type: docs
weight: 70
url: /python-net/applying-protection-to-presentation/
keywords:
- prevent edits
- protect from editing
- lock shape
- lock position
- lock select
- lock resizing
- lock grouping
- PowerPoint
- PPTX
- presentation
- Python
- Aspose.Slides
description: "Learn how to lock and unlock shapes in PPTX presentations with Aspose.Slides for Python via .NET to restrict selection, movement, resizing, and grouping."
---

## **Background**

A common use for Aspose.Slides for Python via .NET is to create, update, and save PowerPoint (PPTX) presentations as part of an automated workflow. When users receive these presentations, restricting changes to shapes can help preserve the intended layout and content.

This article explains how shapes are organized on slides and how to apply and remove shape locks in a PPTX presentation. These locks let you restrict specific editing operations on individual shapes.

## **Composition of a Slide**

A presentation slide is composed of components such as autoshapes, tables, OLE objects, grouped shapes, picture frames, video frames, connectors, and other elements used to build a presentation. In Aspose.Slides for Python via .NET, each element on a slide is represented by an object that inherits from the [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) class.

Different shape types expose different locking options. The [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) class is the base class for shape locks. Aspose.Slides for Python via .NET provides the following lock classes:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) locks autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) locks connector shapes.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) locks graphical objects.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) locks group shapes.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) locks picture frames.  

To apply locks across a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), iterate through its slides and set the appropriate locks on each supported shape.

## **Apply and Remove Protection**

Compatible presentation editors use shape locks to restrict individual editing operations. File encryption and document-level write protection are separate [presentation protection settings](/slides/python-net/password-protected-presentation/).

### **Apply Protection to PPTX Shapes**

Aspose.Slides for Python via .NET provides the [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) class to work with shapes on a slide.

The example sets [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/), and [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) to `True` for autoshapes, with equivalent locks for group shapes, connectors, and picture frames. Connectors use [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) for movement; groups also use [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) to restrict grouping.

The example loads an existing PPTX presentation, checks the shapes in each slide's shape collection, and saves a copy with these restrictions applied. Shapes outside the four handled types are left unchanged. The loop does not traverse the child shapes inside a group.

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True

    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Remove Protection**

To remove a shape lock, set its value to `False`. The following example loads a presentation with shape locks and clears the selection, movement, and resizing restrictions through [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/), and [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). It also clears [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) and saves a copy of the presentation. Other lock settings are left unchanged.

```python
import aspose.slides as slides

with slides.Presentation("ProtectedSample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False

    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Preserve a Picture Crop**

Place a photo named `photo.jpg` in the working directory. The example crops 12% from the left and 8% from the right, then sets [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) on the picture frame. This flag restricts further cropping and preserves the existing crop.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.images.add_image(photo_bytes)

    picture_frame = shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 30, 270, 160, photo)
    picture_frame.picture_format.crop_left = 12
    picture_frame.picture_format.crop_right = 8
    picture_frame.shape_lock.aspect_ratio_locked = False
    picture_frame.shape_lock.crop_locked = True

    presentation.save("PictureLocked.pptx", slides.export.SaveFormat.PPTX)
```

`PictureLocked.pptx` stores the crop lock as `True`. In PowerPoint, the **Crop** command is disabled when the photo is selected.

### **Keep a Diagram Grouped**

The example groups a rectangle and an arrow, then sets [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) on the group itself to keep the diagram’s components together. Other edits, such as moving the group or changing a component’s fill, remain available.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    group_shape = shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 70, 90, 50)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 190, 80, 60, 30)
    group_shape.shape_lock.ungrouping_locked = True

    presentation.save("DiagramLocked.pptx", slides.export.SaveFormat.PPTX)
```

`DiagramLocked.pptx` stores the ungrouping lock as `True`. In PowerPoint, the **Ungroup** command is disabled when the whole diagram is selected.

### **Report Existing Shape Locks**

To review a template, open it and read the lock object for each shape. [no_locks](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/no_locks/) is `True` when all flags on that object are disabled and `False` when at least one is enabled. A group and its children have separate lock objects, so inspect the children even when the group has no locks.

This example checks movement for autoshapes, picture frames, and groups, cropping for pictures, and ungrouping for groups. It reports the flags it recognizes and marks shape types it does not inspect.

```python
import aspose.slides as slides


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = prefix + shape.name
        label = f"Slide {slide_number} | {path} | {type(shape).__name__}"
        if not isinstance(shape, (slides.GroupShape, slides.PictureFrame, slides.AutoShape)):
            print(f"{label} | Uninspected")
            continue

        shape_lock = shape.shape_lock
        if not shape_lock.no_locks:
            flags = []
            if isinstance(shape, slides.GroupShape) and shape_lock.ungrouping_locked:
                flags.append("ungrouping_locked")
            if isinstance(shape, slides.PictureFrame) and shape_lock.crop_locked:
                flags.append("crop_locked")
            if shape_lock.position_locked:
                flags.append("position_locked")
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, slides.GroupShape):
            inspect_shapes(shape.shapes, slide_number, path + "/")


with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        inspect_shapes(slide.shapes, slide.slide_number)
```

Suppose slide 1 of `Sample.pptx` contains a group named `Layout` with ungrouping locked, a picture named `Photo` inside it with cropping locked, and an unlocked rectangle named `Free`. The report skips `Free` and prints these two lines:

```text
Slide 1 | Layout | GroupShape | ungrouping_locked
Slide 1 | Layout/Photo | PictureFrame | crop_locked
```

The report reads stored shape-level editing flags without changing them or saving the presentation. Document-level write protection is a separate setting, and enforcement of each flag depends on the editor.

### **Conclusion**

Aspose.Slides for Python via .NET lets you restrict specific editing operations on individual shapes or apply the same restrictions across slides. Choose the locks supported by each shape type, and set their values to `False` when you need to remove those restrictions.

## **FAQ**

**Can I combine shape locks and password protection in the same presentation?**

Yes. Shape locks restrict specific editing operations, while [password protection](/slides/python-net/password-protected-presentation/) can restrict opening or modifying the presentation. You can use both in the same file.

**Can I restrict editing on specific slides without affecting others?**

Yes. Apply locks only to shapes on the selected slides. This does not change the lock settings on other slides.

**How can I apply locks to individual shapes inside a group?**

Iterate through the group's [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) collection and apply the appropriate locks to each child shape. Repeat this for any nested groups, following the traversal in the reporting example.
