---
title: Presentation Locking
type: docs
weight: 110
url: /net/presentation-locking/
---

## **Presentation Locking**
A common use for **Aspose.Slides** is to create, update and save Microsoft PowerPoint 2007 (PPTX) presentations as part of an automated workflow. Users of the application that uses Aspose.Slides this way get access to the output presentations. Protecting them from editing is a common concern. It is important that auto-generated presentations retain their original formatting and content.

This explains how presentations and slides are constructed and how Aspose.Slides for .NET can apply protection to, and then remove it from a presentation. This feature is unique to Aspose.Slides and, at the time of writing, is not available in Microsoft PowerPoint. It gives developers a way of controlling how the presentations their applications create are used.
## **Composition of a Slide**
A PPTX slide is composed of a number of components like auto shapes, tables, OLE objects, grouped shapes, picture frames, video frames, connectors and the various other elements available to build up a presentation.

In Aspose.Slides for .NET, each element on a slide is turned into a Shape object. In other words, each element on the slide is either a Shape object or an object derived from the Shape object.

The structure of PPTX is complex so unlike PPT, where a generic lock can be used for all type of shapes, there are different types of locks for different shape type. The BaseShapeLock class is the generic PPTX locking class. The following types of locks are supported in Aspose.Slides for .NET for PPTX.

- AutoShapeLock locks auto shapes.
- ConnectorLock locks connecter shapes.
- GraphicalObjectLock locks graphical objects.
- GroupshapeLock locks group shapes.
- PictureFrameLock locks picture frames.

Any action performed on all Shape objects in a Presentation object is applied to the whole presentation.
## **Apply and Remove Protection**
Applying protection ensures that a presentation cannot be edited. It is a useful technique for protecting a presentation's content.

**Applying Protection to PPTX Shapes**

Aspose.Slides for .NET provides the Shape class to handle a shape on the slide.

As mentioned earlier, each shape class has an associated shape lock class for protection. This article focuses on the NoSelect, NoMove and NoResize locks. These locks ensure that shapes cannot be selected (through mouse clicks or other selection methods), and it cannot be moved or resized.

The code samples that follow apply protection to all shapes types in a presentation.

``` csharp
using Aspose.Slides;

//Instatiate Presentation class that represents a PPTX file
using (Presentation pTemplate = new Presentation("Applying Protection.pptx"))
{
	//Traversing through all the slides in the presentation
	foreach (ISlide slide in pTemplate.Slides)
	{
		//Travesing through all the shapes in the slides
		foreach (IShape shape in slide.Shapes)
		{
			//if shape is autoshape
			if (shape is IAutoShape)
			{
				//Type casting to Auto shape and  getting auto shape lock
				IAutoShape Ashp = (IAutoShape)shape;
				IAutoShapeLock AutoShapeLock = Ashp.ShapeLock;

				//Applying shapes locks
				AutoShapeLock.PositionLocked = true;
				AutoShapeLock.SelectLocked = true;
				AutoShapeLock.SizeLocked = true;
			}
			//if shape is group shape
			else if (shape is IGroupShape)
			{
				//Type casting to group shape and  getting group shape lock
				IGroupShape Group = (IGroupShape)shape;
				IGroupShapeLock groupShapeLock = Group.ShapeLock;

				//Applying shapes locks
				groupShapeLock.GroupingLocked = true;
				groupShapeLock.PositionLocked = true;
				groupShapeLock.SelectLocked = true;
				groupShapeLock.SizeLocked = true;
			}
			//if shape is a connector
			else if (shape is IConnector)
			{
				//Type casting to connector shape and  getting connector shape lock
				IConnector Conn = (IConnector)shape;
				IConnectorLock ConnLock = Conn.ShapeLock;

				//Applying shapes locks
				ConnLock.PositionMove = true;
				ConnLock.SelectLocked = true;
				ConnLock.SizeLocked = true;
			}
			//if shape is picture frame
			else if (shape is IPictureFrame)
			{
				//Type casting to picture frame shape and  getting picture frame shape lock
				IPictureFrame Pic = (IPictureFrame)shape;
				IPictureFrameLock PicLock = Pic.ShapeLock;

				//Applying shapes locks
				PicLock.PositionLocked = true;
				PicLock.SelectLocked = true;
				PicLock.SizeLocked = true;
			}
		}
	}

	//Saving the presentation file
	pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
``` 

**Removing Protection**

Protection applied using Aspose.Slides for .NET can only be removed with Aspose.Slides for .NET. To unlock a shape, set the value of the applied lock to false. The code sample that follows shows how to unlock shapes in a locked presentation.

``` csharp
using Aspose.Slides;

//Open the desired presentation
using (Presentation pTemplate = new Presentation("ProtectedSample.pptx"))
{
	//Traversing through all the slides in presentation
	foreach (ISlide slide in pTemplate.Slides)
	{
		//Travesing through all the shapes in the slides
		foreach (IShape shape in slide.Shapes)
		{
			//if shape is autoshape
			if (shape is IAutoShape)
			{
				//Type casting to Auto shape and  getting auto shape lock
				IAutoShape Ashp = (IAutoShape)shape;
				IAutoShapeLock AutoShapeLock = Ashp.ShapeLock;

				//Applying shapes locks
				AutoShapeLock.PositionLocked = false;
				AutoShapeLock.SelectLocked = false;
				AutoShapeLock.SizeLocked = false;
			}
			//if shape is group shape
			else if (shape is IGroupShape)
			{
				//Type casting to group shape and  getting group shape lock
				IGroupShape Group = (IGroupShape)shape;
				IGroupShapeLock groupShapeLock = Group.ShapeLock;

				//Applying shapes locks
				groupShapeLock.GroupingLocked = false;
				groupShapeLock.PositionLocked = false;
				groupShapeLock.SelectLocked = false;
				groupShapeLock.SizeLocked = false;
			}
			//if shape is Connector shape
			else if (shape is IConnector)
			{
				//Type casting to connector shape and  getting connector shape lock
				IConnector Conn = (IConnector)shape;
				IConnectorLock ConnLock = Conn.ShapeLock;

				//Applying shapes locks
				ConnLock.PositionMove = false;
				ConnLock.SelectLocked = false;
				ConnLock.SizeLocked = false;
			}
			//if shape is picture frame
			else if (shape is IPictureFrame)
			{
				//Type casting to pitcture frame shape and  getting picture frame shape lock
				IPictureFrame Pic = (IPictureFrame)shape;
				IPictureFrameLock PicLock = Pic.ShapeLock;

				//Applying shapes locks
				PicLock.PositionLocked = false;
				PicLock.SelectLocked = false;
				PicLock.SizeLocked = false;
			}
		}
	}

	//Saving the presentation file
	pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
``` 
## **Download Sample Code**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)
