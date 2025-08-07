---
title: Prevent Presentation Edits with Shape Locks
linktitle: Prevent Presentation Edits
type: docs
weight: 70
url: /net/applying-protection-to-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Discover how Aspose.Slides for .NET locks or unlocks shapes in PPT, PPTX and ODP files, securing presentations while allowing controlled edits and faster delivery."
---

## **Background**

A common use for Aspose.Slides is to create, update, and save Microsoft PowerPoint (PPTX) presentations as part of an automated workflow. Users of applications that employ Aspose.Slides in this way have access to the generated presentations, so protecting them from editing is a common concern. It is important that automatically generated presentations retain their original formatting and content.

This article explains how presentations and slides are structured and how Aspose.Slides for .NET can apply protection to a presentation and later remove it. It provides developers with a way to control how the presentations their applications generate are used.

## **Composition of a Slide**

A presentation slide is composed of a number of components, such as autoshapes, tables, OLE objects, grouped shapes, picture frames, video frames, connectors, and various other elements used to build a presentation. In Aspose.Slides for .NET, each element on a slide is turned into a [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape/) object. In other words, each element on the slide is either a [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape/) object or an object derived from the [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape/) object.

The structure of PPTX is complex, so unlike PPT, where a generic lock can be used for all types of shapes, different shape types require different locks. The [BaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/baseshapelock/) class is the generic locking class for PPTX. The following types of locks are supported in Aspose.Slides for .NET for PPTX:

- [AutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/autoshapelock/) locks autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/connectorlock/) locks connector shapes.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/graphicalobjectlock/) locks graphical objects.  
- [GroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/groupshapelock/) locks group shapes.  
- [PictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/pictureframelock/) locks picture frames.  

Any action performed on all [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape/) objects in a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) object is applied to the entire presentation.

## **Apply and Remove Protection**

Applying protection ensures that a presentation cannot be edited. It is a useful technique for protecting the presentation’s content.

### **Apply Protection to PPTX Shapes**

Aspose.Slides for .NET provides the [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape/) class to work with shapes on a slide.

As mentioned earlier, each shape class has an associated shape-lock class for protection. This article focuses on the NoSelect, NoMove, and NoResize locks. These locks ensure that shapes cannot be selected (through mouse clicks or other selection methods) and that they cannot be moved or resized.

The code sample that follow apply protection to all shape types in a presentation.

```cs
// Instantiate the Presentation class that represents a PPTX file.
using Presentation presentation = new Presentation("Sample.pptx");

// Traversing all the slides in the presentation.
foreach (ISlide slide in presentation.Slides)
{
    // Traversing all the shapes in the slide.
    foreach (IShape shape in slide.Shapes)
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
        else if (shape is IConnector connector)
        {
            connector.ShapeLock.PositionMove = true;
            connector.ShapeLock.SelectLocked = true;
            connector.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

// Saving the presentation file.
presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Remove Protection**

To unlock a shape, set the applied lock’s value to `false`. The following code sample shows how to unlock shapes in a locked presentation.

```cs
// Load the presentation.
using Presentation presentation = new Presentation("ProtectedSample.pptx");

// Traversing all the slides in the presentation.
foreach (ISlide slide in presentation.Slides)
{
    // Traversing all the shapes in the slide.
    foreach (IShape shape in slide.Shapes)
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
        else if (shape is IConnector connector)
        {
            connector.ShapeLock.PositionMove = false;
            connector.ShapeLock.SelectLocked = false;
            connector.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

// Saving the presentation file.
presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Conclusion**

Aspose.Slides offers several options for protecting shapes in a presentation. You can lock an individual shape or iterate through all the shapes in a presentation and lock each one to effectively secure the entire file. You can remove the protection by setting the lock value to `false`.
