---
title: Applying Protection to Presentation
type: docs
weight: 60
url: /java/applying-protection-to-presentation/
---

{{% alert color="primary" %}} 

A common use for Aspose.Slides is to create, update and save Microsoft PowerPoint 2007 (PPTX) presentations as part of an automated workflow. Users of the application that uses Aspose.Slides this way get access to the output presentations. Protecting them from editing is a common concern. It is important that auto-generated presentations retain their original formatting and content.

This article explains how [presentations and slides are constructed](/slides/java/applying-protection-to-presentation/) and how Aspose.Slides for Java can [apply protection to](/slides/java/applying-protection-to-presentation/), and then [remove it from](/slides/java/applying-protection-to-presentation/) a presentation. This feature is unique to Aspose.Slides and, at the time of writing, is not available in Microsoft PowerPoint. It gives developers a way of controlling how the presentations their applications create are used.

{{% /alert %}} 
## **Composition of a Slide**
A PPTX slide is composed of a number of components like auto shapes, tables, OLE objects, grouped shapes, picture frames, video frames, connectors and the various other elements available to build up a presentation. In Aspose.Slides for Java, each element on a slide is turned into a Shape object. In other words, each element on the slide is either a Shape object or an object derived from the Shape object.The structure of PPTX is complex so unlike PPT, where a generic lock can be used for all type of shapes, there are different types of locks for different shape type. The BaseShapeLock class is the generic PPTX locking class. The following types of locks are supported in Aspose.Slides for Java for PPTX.

- AutoShapeLock locks auto shapes.
- ConnectorLock locks connecter shapes.
- GraphicalObjectLock locks graphical objects.
- GroupshapeLock locks group shapes.
- PictureFrameLock locks picture frames.
  Any action performed on all Shape objects in a Presentation object is applied to the whole presentation.
## **Applying and Removing Protection**
Applying protection ensures that a presentation cannot be edited. It is a useful technique for protecting a presentation's content.
## **Applying Protection to PPTX Shapes**
Aspose.Slides for Java provides the Shape class to handle a shape on the slide.

As mentioned earlier, each shape class has an associated shape lock class for protection. This article focuses on the NoSelect, NoMove and NoResize locks. These locks ensure that shapes cannot be selected (through mouse clicks or other selection methods), and it cannot be moved or resized.

The code samples that follow apply protection to all shapes types in a presentation.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-ApplyProtection-ApplyProtection.java" >}}
## **Removing Protection**
Protection applied using Aspose.Slides for .NET/Java can only be removed with Aspose.Slides for .NET/Java. To unlock a shape, set the value of the applied lock to false. The code sample that follows shows how to unlock shapes in a locked presentation.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-RemoveProtection-RemoveProtection.java" >}}




## **Summary**
{{% alert color="primary" %}} 

Aspose.Slides provides a number of options for applying protection to shapes in a presentation. It is possible to lock a particular shape, or loop through all the shapes in a presentation and lock all of them to effectively lock the presentation.Only Aspose.Slides for Java can remove protection from a presentation that is has previously protected. Remove protection by setting the value of a lock to false.

{{% /alert %}}
