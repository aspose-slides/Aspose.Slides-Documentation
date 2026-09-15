---
title: Prevent Presentation Edits with Shape Locks
linktitle: Prevent Presentation Edits
type: docs
weight: 60
url: /python-java/applying-protection-to-presentation/
keywords:
- prevent edits
- protect from editing
- lock shape
- lock position
- lock select
- lock size
- lock grouping
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Discover how Aspose.Slides for Python via Java locks or unlocks shapes in PPT, PPTX and ODP files, securing presentations while allowing controlled edits and faster delivery."
---

## **Background**

A common use for Aspose.Slides is to create, update, and save Microsoft PowerPoint (PPTX) presentations as part of an automated workflow. Users of applications that employ Aspose.Slides in this way have access to the generated presentations, so protecting them from editing is a common concern. It is important that automatically generated presentations retain their original formatting and content.

This article explains how presentations and slides are structured and how Aspose.Slides for Python via Java can apply protection to a presentation and later remove it. It provides developers with a way to control how the presentations their applications generate are used.

## **Composition of a Slide**

A presentation slide is composed of components such as autoshapes, tables, OLE objects, grouped shapes, picture frames, video frames, connectors, and other elements used to build a presentation. In Aspose.Slides for Python via Java, each element on a slide is represented by an object that inherits from the [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) class.

The structure of PPTX is complex, so unlike PPT, where a generic lock can be used for all types of shapes, different shape types require different locks. The [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) class is the generic locking class for PPTX. The following types of locks are supported in Aspose.Slides for Python via Java for PPTX:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) locks autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) locks connector shapes.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) locks graphical objects.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) locks group shapes.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) locks picture frames.  

Any action performed on all shape objects in a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) object is applied to the entire presentation.

## **Apply and Remove Protection**

Applying protection ensures that a presentation cannot be edited. It is a useful technique for protecting the presentation’s content.

### **Apply Protection to PPTX Shapes**

Aspose.Slides for Python via Java provides the [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) class to work with shapes on a slide.

As mentioned earlier, each shape class has an associated shape-lock class for protection. This article focuses on the NoSelect, NoMove, and NoResize locks. These locks ensure that shapes cannot be selected (through mouse clicks or other selection methods) and that they cannot be moved or resized.

The code sample that follows applies protection to all shape types in a presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# Instantiate the Presentation class that represents a PPTX file.
presentation = Presentation("Sample.pptx")
try:
    # Traverse all the slides in the presentation.
    for slide in presentation.getSlides():
        # Traverse all the shapes in the slide.
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

    # Save the presentation file.
    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Remove Protection**

To unlock a shape, set the applied lock’s value to `False`. The following code sample shows how to unlock shapes in a locked presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# Instantiate the Presentation class that represents a PPTX file.
presentation = Presentation("ProtectedSample.pptx")
try:
    # Traverse all the slides in the presentation.
    for slide in presentation.getSlides():
        # Traverse all the shapes in the slide.
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

    # Save the presentation file.
    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Conclusion**

Aspose.Slides offers several options for protecting shapes in a presentation. You can lock an individual shape or iterate through all the shapes in a presentation and lock each one to effectively secure the entire file. You can remove the protection by setting the lock value to `False`.

## **FAQ**

**Can I combine shape locks and password protection in the same presentation?**

Yes. Locks limit editing of objects inside the file, while [password protection](/slides/python-java/password-protected-presentation/) controls access to opening and/or saving changes. These mechanisms complement each other and work together.

**Can I restrict editing on specific slides without affecting others?**

Yes. Apply locks to the shapes on the selected slides; the remaining slides will stay editable.

**Do shape locks apply to grouped objects and connectors?**

Yes. Dedicated lock types are supported for groups, connectors, graphic objects, and other shape kinds.
