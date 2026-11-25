---
title: Restrict Presentation Edits with Shape Locks on Android
linktitle: Restrict Presentation Edits
type: docs
weight: 60
url: /androidjava/applying-protection-to-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Learn how to lock and unlock shapes in PPTX presentations with Aspose.Slides for Android via Java to restrict selection, movement, resizing, and grouping."
---

## **Overview**

A common use for Aspose.Slides for Android via Java is to create, update, and save PowerPoint (PPTX) presentations as part of an automated workflow. When users receive these presentations, restricting changes to shapes can help preserve the intended layout and content.

This article explains how shapes are organized on slides and how to apply and remove shape locks in a PPTX presentation. These locks let you restrict specific editing operations on individual shapes.

## **Composition of a Slide**

A presentation slide is composed of components such as autoshapes, tables, OLE objects, grouped shapes, picture frames, video frames, connectors, and other elements used to build a presentation. In Aspose.Slides for Android via Java, each element on a slide is represented by an object that implements the [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) interface or inherits from a class that does.

Different shape types expose different locking options. The [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) interface is the base interface for shape locks. Aspose.Slides for Android via Java provides the following lock interfaces:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) locks autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) locks connector shapes.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) locks graphical objects.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) locks group shapes.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) locks picture frames.  

To apply locks across a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), iterate through its slides and set the appropriate locks on each supported shape.

## **Apply and Remove Protection**

Compatible presentation editors use shape locks to restrict individual editing operations. File encryption and document-level write protection are separate [presentation protection settings](/slides/androidjava/password-protected-presentation/).

### **Apply Protection to PPTX Shapes**

Aspose.Slides for Android via Java provides the [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) interface to work with shapes on a slide.

The example calls [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), and [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) with `true` for autoshapes, with equivalent locks for group shapes, connectors, and picture frames. Connectors use [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) for movement; groups also use [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) to restrict grouping.

The example loads an existing PPTX presentation, checks the shapes in each slide's shape collection, and saves a copy with these restrictions applied. Shapes outside the four handled types are left unchanged. The loop does not traverse the child shapes inside a group.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Remove Protection**

To remove a shape lock, set its value to `false`. The following example loads a presentation with shape locks and clears the selection, movement, and resizing restrictions through [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/), and [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/). It also removes the grouping restriction by passing `false` to [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) and saves a copy of the presentation. Other lock settings are left unchanged.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ProtectedSample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Preserve a Picture Crop**

Place a photo named `photo.jpg` in the working directory. The example crops 12% from the left and 8% from the right, then calls [setCropLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) on the picture frame’s lock. Passing `true` restricts further cropping and preserves the existing crop.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage photo;
    try (FileInputStream input = new FileInputStream("photo.jpg")) {
        photo = presentation.getImages().addImage(input);
    }

    IPictureFrame pictureFrame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);

    IPictureFrameLock pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` stores the crop lock as `true`. In PowerPoint, the **Crop** command is disabled when the photo is selected.

### **Keep a Diagram Grouped**

The example groups a rectangle and an arrow, then calls [setUngroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) on the group’s lock to keep the diagram’s components together. Other edits, such as moving the group or changing a component’s fill, remain available.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IGroupShape groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` stores the ungrouping lock as `true`. In PowerPoint, the **Ungroup** command is disabled when the whole diagram is selected.

### **Report Existing Shape Locks**

To review a template, open it and read the lock object for each shape. The [getNoLocks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/#getNoLocks--) method returns `true` when all flags on that object are disabled and `false` when at least one is enabled. A group and its children have separate lock objects, so inspect the children even when the group has no locks.

This example checks movement for autoshapes, picture frames, and groups. It also checks cropping for pictures and ungrouping for groups. The report lists the enabled flags it recognizes and marks shape types it does not inspect.

```java
import com.aspose.slides.*;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.List;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            List<String> flags = new ArrayList<>();
            IBaseShapeLock shapeLock;

            if (shape instanceof IGroupShape) {
                IGroupShapeLock groupLock = ((IGroupShape) shape).getGroupShapeLock();
                shapeLock = groupLock;
                if (groupLock.getUngroupingLocked()) flags.add("UngroupingLocked");
                if (groupLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IPictureFrame) {
                IPictureFrameLock pictureLock = ((IPictureFrame) shape).getPictureFrameLock();
                shapeLock = pictureLock;
                if (pictureLock.getCropLocked()) flags.add("CropLocked");
                if (pictureLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IAutoShape) {
                IAutoShapeLock autoShapeLock = ((IAutoShape) shape).getAutoShapeLock();
                shapeLock = autoShapeLock;
                if (autoShapeLock.getPositionLocked()) flags.add("PositionLocked");
            } else {
                System.out.println(label + " | Uninspected");
                continue;
            }

            if (!shapeLock.getNoLocks()) {
                String restrictions = !flags.isEmpty() ? TextUtils.join(", ", flags) : "Active flag not identified";
                System.out.println(label + " | " + restrictions);
            }

            if (shape instanceof IGroupShape) {
                inspect(((IGroupShape) shape).getShapes(), slideNumber, path + "/");
            }
        }
    }
}

ShapeLockReport report = new ShapeLockReport();
Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        report.inspect(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

Suppose slide 1 of `Sample.pptx` contains a group named `Layout` with ungrouping locked, a picture named `Photo` inside it with cropping locked, and an unlocked rectangle named `Free`. The report skips `Free` and prints these two lines:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

The report reads the stored shape-level editing flags without changing them or saving the presentation. Document-level write protection is a separate setting, and enforcement of each flag depends on the editor.

### **Conclusion**

Aspose.Slides for Android via Java lets you restrict specific editing operations on individual shapes or apply the same restrictions across slides. Choose the locks supported by each shape type, and set their values to `false` when you need to remove those restrictions.

## **FAQ**

**Can I combine shape locks and password protection in the same presentation?**

Yes. Shape locks restrict specific editing operations, while [password protection](/slides/androidjava/password-protected-presentation/) can restrict opening or modifying the presentation. You can use both in the same file.

**Can I restrict editing on specific slides without affecting others?**

Yes. Apply locks only to shapes on the selected slides. This does not change the lock settings on other slides.

**How can I apply locks to individual shapes inside a group?**

Iterate through the collection returned by the group's [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) method and apply the appropriate locks to each child shape. Repeat this for any nested groups, following the traversal in the reporting example.
