---
title: Prevent Presentation Edits with Shape Locks in Python
linktitle: Prevent Presentation Edits
type: docs
weight: 70
url: /python-net/applying-protection-to-presentation/
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
- Aspose.Slides
description: "Discover how Aspose.Slides for Python via .NET locks or unlocks shapes in PPT, PPTX and ODP files, securing presentations while allowing controlled edits and faster delivery."
---

{{% alert color="primary" %}} 

A common use for Aspose.Slides is to create, update and save Microsoft PowerPoint 2007 (PPTX) presentations as part of an automated workflow. Users of the application that uses Aspose.Slides this way get access to the output presentations. Protecting them from editing is a common concern. It is important that auto-generated presentations retain their original formatting and content.

This article explains how [presentations and slides are constructed](/slides/python-net/applying-protection-to-presentation/) and how Aspose.Slides for Python via .NET can [apply protection to](/slides/python-net/applying-protection-to-presentation/), and then [remove it from](/slides/python-net/applying-protection-to-presentation/) a presentation. This feature is unique to Aspose.Slides and, at the time of writing, is not available in Microsoft PowerPoint. It gives developers a way of controlling how the presentations their applications create are used.

{{% /alert %}} 
## **Composition of a Slide**
A PPTX slide is composed of a number of components like auto shapes, tables, OLE objects, grouped shapes, picture frames, video frames, connectors and the various other elements available to build up a presentation.

In Aspose.Slides for Python via .NET, each element on a slide is turned into a Shape object. In other words, each element on the slide is either a Shape object or an object derived from the Shape object.

The structure of PPTX is complex so unlike PPT, where a generic lock can be used for all type of shapes, there are different types of locks for different shape type. The BaseShapeLock class is the generic PPTX locking class. The following types of locks are supported in Aspose.Slides for Python via .NET for PPTX.

- AutoShapeLock locks auto shapes.
- ConnectorLock locks connecter shapes.
- GraphicalObjectLock locks graphical objects.
- GroupshapeLock locks group shapes.
- PictureFrameLock locks picture frames.

Any action performed on all Shape objects in a Presentation object is applied to the whole presentation.
## **Applying and Removing Protection**
Applying protection ensures that a presentation cannot be edited. It is a useful technique for protecting a presentation's content.
### **Applying Protection to PPTX Shapes**
Aspose.Slides for Python via .NET provides the Shape class to handle a shape on the slide.

As mentioned earlier, each shape class has an associated shape lock class for protection. This article focuses on the NoSelect, NoMove and NoResize locks. These locks ensure that shapes cannot be selected (through mouse clicks or other selection methods), and it cannot be moved or resized.

The code samples that follow apply protection to all shapes types in a presentation.

```py
import aspose.slides as slides

#Instatiate Presentation class that represents a PPTX file
with slides.Presentation(path + "RectPicFrame.pptx") as pres:
    #ISlide object for accessing the slides in the presentation
    slide = pres.slides[0]

    #Traversing through all the slides in the presentation
    for slide in pres.slides:
        for shape in slide.shapes:
            #if shape is autoshape
            if type(shape) is slides.AutoShape:
                auto_shape_lock = shape.shape_lock

                #Applying shapes locks
                auto_shape_lock.position_locked = True
                auto_shape_lock.select_locked = True
                auto_shape_lock.size_locked = True

            #if shape is group shape
            elif type(shape) is slides.GroupShape:
                group_shape_lock = shape.shape_lock

                #Applying shapes locks
                group_shape_lock.grouping_locked = True
                group_shape_lock.position_locked = True
                group_shape_lock.select_locked = True
                group_shape_lock.size_locked = True

            #if shape is a connector
            elif type(shape) is slides.Connector:
                connector_lock = shape.shape_lock

                #Applying shapes locks
                connector_lock.position_move = True
                connector_lock.select_locked = True
                connector_lock.size_locked = True
            #if shape is picture frame
            elif type(shape) is slides.PictureFrame:
                #Type casting to pitcture frame shape and  getting picture frame shape lock
                picture_lock = shape.shape_lock

                #Applying shapes locks
                picture_lock.position_locked = True
                picture_lock.select_locked = True
                picture_lock.size_locked = True

    #Saving the presentation file
    pres.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```


### **Removing Protection**
Protection applied using Aspose.Slides for Python via .NET can only be removed with Aspose.Slides for Python via .NET. To unlock a shape, set the value of the applied lock to false. The code sample that follows shows how to unlock shapes in a locked presentation.

```py
import aspose.slides as slides

#Open the desired presentation
with slides.Presentation("ProtectedSample.pptx") as pres:
    for slide in pres.slides:
        for shape in slide.shapes:
            
            if type(shape) is slides.AutoShape: 
                auto_shape_lock = shape.shape_lock

                #Applying shapes locks
                auto_shape_lock.position_locked = False
                auto_shape_lock.select_locked = False
                auto_shape_lock.size_locked = False
            
            elif type(shape) is slides.GroupShape:  
                group_shape_lock = shape.shape_lock

                #Applying shapes locks
                group_shape_lock.grouping_locked = False
                group_shape_lock.position_locked = False
                group_shape_lock.select_locked = False
                group_shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                connector_lock = shape.shape_lock

                #Applying shapes locks
                connector_lock.position_move = False
                connector_lock.select_locked = False
                connector_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                picture_lock = shape.shape_lock

                #Applying shapes locks
                picture_lock.position_locked = False
                picture_lock.select_locked = False
                picture_lock.size_locked = False
    #Saving the presentation file
    pres.save("RemoveProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```



### **Summary**
{{% alert color="primary" %}} 

Aspose.Slides provides a number of options for applying protection to shapes in a presentation. It is possible to lock a particular shape, or loop through all the shapes in a presentation and lock all of them to effectively lock the presentation.

Only Aspose.Slides for Python via .NET can remove protection from a presentation that is has previously protected. Remove protection by setting the value of a lock to false.

{{% /alert %}} 

