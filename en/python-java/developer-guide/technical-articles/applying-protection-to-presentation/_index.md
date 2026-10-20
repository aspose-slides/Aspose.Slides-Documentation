---
title: Restrict Presentation Edits with Shape Locks in Python
linktitle: Restrict Presentation Edits
type: docs
weight: 60
url: /python-java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Learn how to lock and unlock shapes in PPTX presentations with Aspose.Slides for Python via Java to restrict selection, movement, resizing, and grouping."
---

## **Background**

A common use for Aspose.Slides for Python via Java is to create, update, and save PowerPoint (PPTX) presentations as part of an automated workflow. When users receive these presentations, restricting changes to shapes can help preserve the intended layout and content.

This article explains how shapes are organized on slides and how to apply and remove shape locks in a PPTX presentation. These locks let you restrict specific editing operations on individual shapes.

## **Composition of a Slide**

A presentation slide is composed of components such as autoshapes, tables, OLE objects, grouped shapes, picture frames, video frames, connectors, and other elements used to build a presentation. In Aspose.Slides for Python via Java, each element on a slide is represented by an object that inherits from the [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) class.

Different shape types expose different locking options. The [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) class is the base class for shape locks. Aspose.Slides for Python via Java provides the following lock classes:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) locks autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) locks connector shapes.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) locks graphical objects.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) locks group shapes.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) locks picture frames.  

To apply locks across a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), iterate through its slides and set the appropriate locks on each supported shape.

## **Apply and Remove Protection**

Shape locks restrict operations such as selecting, moving, and resizing shapes. They do not make the entire presentation uneditable.

### **Apply Protection to PPTX Shapes**

Aspose.Slides for Python via Java provides the [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) class to work with shapes on a slide.

The example calls [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked), and [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) with `True` for autoshapes, with equivalent locks for group shapes, connectors, and picture frames. Connectors use [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) for movement; groups also use [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) to restrict grouping.

The example loads an existing PPTX presentation, checks the shapes in each slide's shape collection, and saves a copy with these restrictions applied. Shapes outside the four handled types are left unchanged. The loop does not traverse the child shapes inside a group.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(True)
                auto_shape_lock.setSelectLocked(True)
                auto_shape_lock.setSizeLocked(True)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(True)
                group_shape_lock.setPositionLocked(True)
                group_shape_lock.setSelectLocked(True)
                group_shape_lock.setSizeLocked(True)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(True)
                connector_shape_lock.setSelectLocked(True)
                connector_shape_lock.setSizeLocked(True)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(True)
                picture_frame_lock.setSelectLocked(True)
                picture_frame_lock.setSizeLocked(True)

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Remove Protection**

To remove a shape lock, set its value to `False`. The following example loads a presentation with shape locks and clears the selection, movement, and resizing restrictions through [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/), and [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). It also removes the grouping restriction by passing `False` to [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) and saves a copy of the presentation. Other lock settings are left unchanged.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("ProtectedSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(False)
                auto_shape_lock.setSelectLocked(False)
                auto_shape_lock.setSizeLocked(False)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(False)
                group_shape_lock.setPositionLocked(False)
                group_shape_lock.setSelectLocked(False)
                group_shape_lock.setSizeLocked(False)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(False)
                connector_shape_lock.setSelectLocked(False)
                connector_shape_lock.setSizeLocked(False)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(False)
                picture_frame_lock.setSelectLocked(False)
                picture_frame_lock.setSizeLocked(False)

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Conclusion**

Aspose.Slides for Python via Java lets you restrict specific editing operations on individual shapes or apply the same restrictions across slides. Choose the locks supported by each shape type, and set their values to `False` when you need to remove those restrictions.

## **FAQ**

**Can I combine shape locks and password protection in the same presentation?**

Yes. Shape locks restrict specific editing operations, while [password protection](/slides/python-java/password-protected-presentation/) can restrict opening or modifying the presentation. You can use both in the same file.

**Can I restrict editing on specific slides without affecting others?**

Yes. Apply locks only to shapes on the selected slides. This does not change the lock settings on other slides.

**How can I apply locks to individual shapes inside a group?**

Iterate through the collection returned by the group's [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) method and apply the appropriate locks to each child shape. Repeat this for any nested groups. The examples above process only the slide's shape collection, so they do not set locks on individual group members.
