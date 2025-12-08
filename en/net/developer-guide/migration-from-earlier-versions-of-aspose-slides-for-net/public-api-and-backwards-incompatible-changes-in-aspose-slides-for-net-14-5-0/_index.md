---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for .NET 14.5.0
linktitle: Aspose.Slides for .NET 14.5.0
type: docs
weight: 70
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- migration
- legacy code
- modern code
- legacy approach
- modern approach
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Review public API updates and breaking changes in Aspose.Slides for .NET to smoothly migrate your PowerPoint PPT, PPTX and ODP presentation solutions."
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) classes, methods, properties and so on, any new [restrictions](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) and other [changes](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) introduced with the Aspose.Slides for .NET 14.5.0 API.

{{% /alert %}} 
## **Public API and Backwards Incompatible Changes**
### **Added Interfaces, Classes, Properties and Methods**
#### **Added the Aspose.Slides.IPresentationInfo Interface and PresentationInfo Class**
Represent info about presentation.

- The Boolean property IsEncrypted gets True if a presentation is encrypted, otherwise gets False.
- The property LoadFormat LoadFormat gets type of a presentation.
#### **Added the Aspose.Slides.IShape.IsGrouped Property**
The property Aspose.Slides.IShape.IsGrouped determines whether a shape is grouped.
#### **Added the Aspose.Slides.IShape.ParentGroup Property**
The property Aspose.Slides.IShape.ParentGroup returns the parent GroupShape object if a shape is grouped. Otherwise it returns null.
#### **Added the Aspose.Slides.IShapeCollection.AddGroupShape() Method**
The method Aspose.Slides.IShapeCollection.AddGroupShape() creates a new GroupShape and adds it to the end of the collection.
The GroupShape frame size and position will be fitted to the content when new shape is added.
#### **Added the Aspose.Slides.IShapeCollection.Clear() Method**
The method Aspose.Slides.IShapeCollection.Clear() removes all shapes from the collection.
#### **Added the Aspose.Slides.IShapeCollection.InsertGroupShape(int) Method**
The method Aspose.Slides.IShapeCollection.InsertGroupShape(int) creates a new GroupShape and inserts it into the collection at the specified index position.
The GroupShape frame size and position will be fitted to content when a new shape is added.
#### **Added the IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream) Methods**
These methods allow to receive information about a presentation file or stream without full loading the presentation.
#### **Added the IPresentationFactory PresentationFactory.Instance Property**
This property allows developers to use the factory functionality without instantiation.
### **Restrictions**
#### **Restrictions to IShape.Frame**
Restrictions have been added for using undefined values for IShape.Frame. Code that attempts to assign an undefined frame to IShape.Frame doesn't make sense in most case (particularly when the parent GroupShape is multiple nested into other {{GroupShape}}s). For example:

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 

or

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

Such code can lead to unclear situations. So restrictions have been added for using undefined values for IShape.Frame. Values of x, y, width, height, flipH, flipV and rotationAngle must be defined (and not set to float.NaN or NullableBool.NotDefined). The example code above now throws an ArgumentException exception.
This applies to these use cases:

``` csharp

 IShape shape = ...;

shape.Frame = ...; // Cannot be undefined

IShapeCollection shapes = ...;

// x, y, width, height parameters cannot be float.NaN:

{

    shapes.AddAudioFrameCD(...);

    shapes.AddAudioFrameEmbedded(...);

    shapes.AddAudioFrameLinked(...);

    shapes.AddAutoShape(...);

    shapes.AddChart(...);

    shapes.AddConnector(...);

    shapes.AddOleObjectFrame(...);

    shapes.AddPictureFrame(...);

    shapes.AddSmartArt(...);

    shapes.AddTable(...);

    shapes.AddVideoFrame(...);

    shapes.InsertAudioFrameEmbedded(...);

    shapes.InsertAudioFrameLinked(...);

    shapes.InsertAutoShape(...);

    shapes.InsertChart(...);

    shapes.InsertConnector(...);

    shapes.InsertOleObjectFrame(...);

    shapes.InsertPictureFrame(...);

    shapes.InsertTable(...);

    shapes.InsertVideoFrame(...);

}


``` 

But IShape.RawFrame frame properties can be undefined. This make sense when a shape is linked to a placeholder. Then the undefined shape frame values are overridden from the parent placeholder shape. If there is no parent placeholder shape, then that shape uses default values when it evaluates effective frame based on its IShape.RawFrame. The default values are 0 and NullableBool.False for x, y, width, height, flipH, flipV and rotationAngle. For example:

``` csharp

 IShape shape = ...; // shape is linked to placeholder

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// now shape inherits x, y, height, flipH, flipV values form placeholder and overrides width=100 and rotationAngle=0.

``` 
### **Changed Properties**
#### **Changed the Aspose.Slides.IShapeCollection.Parent Property Name and Type**
- The Aspose.Slides.IShapeCollection.Parent property's type has been changed from ISlideComponent to the new IGroupShape interface. The IGroupShape interface is a descendant of ISlideComponent so existing code needs no adaptations.
- The name of the Aspose.Slides.IShapeCollection.Parent property has been changed from Parent to ParentGroup.
#### **Changed the Aspose.Slides.IShapeFrame.FlipH, .FlipV Properties Types**
- The Aspose.Slides.IShapeFrame.FlipH property'a type has been changed from bool to NullableBool.
- The IShape.Frame property return an effective instance of IShapeFrame (all of which properties have defined effective values).
- The IShape.RawFrame property return an instance of IShapeFrame of which each property can have undefined value (particularly FlipH or FlipV can have value NullableBool.NotDefined).
