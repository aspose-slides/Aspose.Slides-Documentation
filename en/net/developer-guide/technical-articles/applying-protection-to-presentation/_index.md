---
title: Restrict Presentation Edits with Shape Locks in .NET
linktitle: Restrict Presentation Edits
type: docs
weight: 70
url: /net/applying-protection-to-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Learn how to lock and unlock shapes in PPTX presentations with Aspose.Slides for .NET to restrict selection, movement, resizing, and grouping."
---

## **Background**

A common use for Aspose.Slides for .NET is to create, update, and save PowerPoint (PPTX) presentations as part of an automated workflow. When users receive these presentations, restricting changes to shapes can help preserve the intended layout and content.

This article explains how shapes are organized on slides and how to apply and remove shape locks in a PPTX presentation. These locks let you restrict specific editing operations on individual shapes.

## **Composition of a Slide**

A presentation slide is composed of components such as autoshapes, tables, OLE objects, grouped shapes, picture frames, video frames, connectors, and other elements used to build a presentation. In Aspose.Slides for .NET, each element on a slide is represented by an object that implements the [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) interface or inherits from a class that does.

Different shape types expose different locking options. The [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) interface is the base interface for shape locks. Aspose.Slides for .NET provides the following lock interfaces:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) locks autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) locks connector shapes.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) locks graphical objects.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) locks group shapes.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) locks picture frames.  

To apply locks across a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), iterate through its slides and set the appropriate locks on each supported shape.

## **Apply and Remove Protection**

Compatible presentation editors use shape locks to restrict individual editing operations. File encryption and document-level write protection are separate [presentation protection settings](/slides/net/password-protected-presentation/).

### **Apply Protection to PPTX Shapes**

Aspose.Slides for .NET provides the [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) interface to work with shapes on a slide.

The example sets [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/), and [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) to `true` for autoshapes, with equivalent locks for group shapes, connectors, and picture frames. Connectors use [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) for movement; groups also use [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) to restrict grouping.

The example loads an existing PPTX presentation, checks the shapes in each slide's shape collection, and saves a copy with these restrictions applied. Shapes outside the four handled types are left unchanged. The loop does not traverse the child shapes inside a group.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Remove Protection**

To remove a shape lock, set its value to `false`. The following example loads a presentation with shape locks and clears the selection, movement, and resizing restrictions through [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/), and [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). It also clears [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) and saves a copy of the presentation. Other lock settings are left unchanged.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ProtectedSample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Preserve a Picture Crop**

Place a photo named `photo.jpg` in the working directory. The example crops 12% from the left and 8% from the right, then sets [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) on the picture frame. This flag restricts further cropping and preserves the existing crop.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var photoBytes = File.ReadAllBytes("photo.jpg");
var photo = presentation.Images.AddImage(photoBytes);

var pictureFrame = shapes.AddPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
pictureFrame.PictureFormat.CropLeft = 12;
pictureFrame.PictureFormat.CropRight = 8;
pictureFrame.PictureFrameLock.AspectRatioLocked = false;
pictureFrame.PictureFrameLock.CropLocked = true;

presentation.Save("PictureLocked.pptx", SaveFormat.Pptx);
```

`PictureLocked.pptx` stores the crop lock as `true`. In PowerPoint, the **Crop** command is disabled when the photo is selected.

### **Keep a Diagram Grouped**

The example groups a rectangle and an arrow, then sets [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) on the group itself to keep the diagram’s components together. Other edits, such as moving the group or changing a component’s fill, remain available.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var groupShape = shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
groupShape.Shapes.AddAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
groupShape.GroupShapeLock.UngroupingLocked = true;

presentation.Save("DiagramLocked.pptx", SaveFormat.Pptx);
```

`DiagramLocked.pptx` stores the ungrouping lock as `true`. In PowerPoint, the **Ungroup** command is disabled when the whole diagram is selected.

### **Report Existing Shape Locks**

To review a template, open it and read the lock object for each shape. [NoLocks](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/nolocks/) is `true` when all flags on that object are disabled and `false` when at least one is enabled. A group and its children have separate lock objects, so inspect the children even when the group has no locks.

This example checks movement for autoshapes, picture frames, and groups, cropping for pictures, and ungrouping for groups. It reports the flags it recognizes and marks shape types it does not inspect.

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("Sample.pptx");
foreach (var slide in presentation.Slides)
{
    Inspect(slide.Shapes, slide.SlideNumber, "");
}

static void Inspect(IShapeCollection shapes, int slideNumber, string prefix)
{
    foreach (var shape in shapes)
    {
        var path = prefix + shape.Name;
        var label = $"Slide {slideNumber} | {path} | {shape.GetType().Name}";
        var flags = new List<string>();
        IBaseShapeLock shapeLock;

        switch (shape)
        {
            case IGroupShape group:
                shapeLock = group.ShapeLock;
                if (group.ShapeLock.UngroupingLocked) flags.Add("UngroupingLocked");
                if (group.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IPictureFrame picture:
                shapeLock = picture.ShapeLock;
                if (picture.ShapeLock.CropLocked) flags.Add("CropLocked");
                if (picture.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IAutoShape autoShape:
                shapeLock = autoShape.ShapeLock;
                if (autoShape.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            default:
                Console.WriteLine($"{label} | Uninspected");
                continue;
        }

        if (!shapeLock.NoLocks)
        {
            var restrictions = flags.Count > 0 ? string.Join(", ", flags) : "Active flag not identified";
            Console.WriteLine($"{label} | {restrictions}");
        }

        if (shape is IGroupShape parent)
            Inspect(parent.Shapes, slideNumber, path + "/");
    }
}
```

Suppose slide 1 of `Sample.pptx` contains a group named `Layout` with ungrouping locked, a picture named `Photo` inside it with cropping locked, and an unlocked rectangle named `Free`. The report skips `Free` and prints these two lines:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

The report reads stored shape-level editing flags without changing them or saving the presentation. Document-level write protection is a separate setting, and enforcement of each flag depends on the editor.

### **Conclusion**

Aspose.Slides for .NET lets you restrict specific editing operations on individual shapes or apply the same restrictions across slides. Choose the locks supported by each shape type, and set their values to `false` when you need to remove those restrictions.

## **FAQ**

**Can I combine shape locks and password protection in the same presentation?**

Yes. Shape locks restrict specific editing operations, while [password protection](/slides/net/password-protected-presentation/) can restrict opening or modifying the presentation. You can use both in the same file.

**Can I restrict editing on specific slides without affecting others?**

Yes. Apply locks only to shapes on the selected slides. This does not change the lock settings on other slides.

**How can I apply locks to individual shapes inside a group?**

Iterate through the group's [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) collection and apply the appropriate locks to each child shape. Repeat this for any nested groups, following the traversal in the reporting example.
