---
title: Prevent Presentation Edits with Shape Locks
linktitle: Prevent Presentation Edits
type: docs
weight: 10
url: /cpp/applying-protection-to-presentation/
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
- C++
- Aspose.Slides
description: "Discover how Aspose.Slides for C++ locks or unlocks shapes in PPT, PPTX and ODP files, securing presentations while allowing controlled edits and faster delivery."
---

## **Background**

A common use for Aspose.Slides is to create, update, and save Microsoft PowerPoint (PPTX) presentations as part of an automated workflow. Users of applications that employ Aspose.Slides in this way have access to the generated presentations, so protecting them from editing is a common concern. It is important that automatically generated presentations retain their original formatting and content.

This article explains how presentations and slides are structured and how Aspose.Slides for C++ can apply protection to a presentation and later remove it. It provides developers with a way to control how the presentations their applications generate are used.

## **Composition of a Slide**

A presentation slide is composed of components such as autoshapes, tables, OLE objects, grouped shapes, picture frames, video frames, connectors, and other elements used to build a presentation. In Aspose.Slides for C++, each element on a slide is represented by an object that implements the [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) interface or inherits from a class that does.

The structure of PPTX is complex, so unlike PPT, where a generic lock can be used for all types of shapes, different shape types require different locks. The [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) interface is the generic locking class for PPTX. The following types of locks are supported in Aspose.Slides for C++ for PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) locks autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) locks connector shapes.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) locks graphical objects.  
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) locks group shapes.  
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) locks picture frames.   

Any action performed on all shape objects in a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) object is applied to the entire presentation.

## **Apply and Remove Protection**

Applying protection ensures that a presentation cannot be edited. It is a useful technique for protecting the presentation’s content.

### **Apply Protection to PPTX Shapes**

Aspose.Slides for C++ provides the [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) interface to work with shapes on a slide.

As mentioned earlier, each shape class has an associated shape-lock class for protection. This article focuses on the NoSelect, NoMove, and NoResize locks. These locks ensure that shapes cannot be selected (through mouse clicks or other selection methods) and that they cannot be moved or resized.

The code sample that follow apply protection to all shape types in a presentation.

```cpp
// Instantiate the Presentation class that represents a PPTX file.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Traversing all the slides in the presentation.
for (auto&& slide : presentation->get_Slides())	{

	// Traversing all the shapes in the slide.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Type-casting the shape to an autoshape and obtaining its shape lock.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(true);
			autoShapeLock->set_SelectLocked(true);
			autoShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Type-casting the shape to a group shape and obtaining its shape lock.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(true);
			groupShapeLock->set_PositionLocked(true);
			groupShapeLock->set_SelectLocked(true);
			groupShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Type-casting the shape to a connector shape and obtaining its shape lock.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(true);
			connectorShapeLock->set_SelectLocked(true);
			connectorShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Type-casting the shape to a picture frame and obtaining its shape lock.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(true);
			pictureFrameLock->set_SelectLocked(true);
			pictureFrameLock->set_SizeLocked(true);
		}
	}
}

// Saving the presentation file.
presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Remove Protection**

To unlock a shape, set the applied lock’s value to `false`. The following code sample shows how to unlock shapes in a locked presentation.

```cpp
// Instantiate the Presentation class that represents a PPTX file.
auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

// Traversing all the slides in the presentation.
for (auto&& slide : presentation->get_Slides())	{

	// Traversing all the shapes in the slide.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Type-casting the shape to an autoshape and obtaining its shape lock.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(false);
			autoShapeLock->set_SelectLocked(false);
			autoShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Type-casting the shape to a group shape and obtaining its shape lock.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(false);
			groupShapeLock->set_PositionLocked(false);
			groupShapeLock->set_SelectLocked(false);
			groupShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Type-casting the shape to a connector shape and obtaining its shape lock.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(false);
			connectorShapeLock->set_SelectLocked(false);
			connectorShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Type-casting the shape to a picture frame and obtaining its shape lock.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(false);
			pictureFrameLock->set_SelectLocked(false);
			pictureFrameLock->set_SizeLocked(false);
		}
	}
}

// Saving the presentation file.
presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Conclusion**

Aspose.Slides offers several options for protecting shapes in a presentation. You can lock an individual shape or iterate through all the shapes in a presentation and lock each one to effectively secure the entire file. You can remove the protection by setting the lock value to `false`.

## **FAQ**

**Can I combine shape locks and password protection in the same presentation?**

Yes. Locks limit editing of objects inside the file, while [password protection](/slides/cpp/password-protected-presentation/) controls access to opening and/or saving changes. These mechanisms complement each other and work together.

**Can I restrict editing on specific slides without affecting others?**

Yes. Apply locks to the shapes on the selected slides; the remaining slides will stay editable.

**Do shape locks apply to grouped objects and connectors?**

Yes. Dedicated lock types are supported for groups, connectors, graphic objects, and other shape kinds.
