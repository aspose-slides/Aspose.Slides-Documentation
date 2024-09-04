---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for Java 14.5.0
type: docs
weight: 40
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) classes, methods, properties and so on, any new [restrictions](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) and other [changes](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) introduced with the Aspose.Slides for Java 14.5.0 API.

{{% /alert %}} 
## **Public API and Backwards Incompatible Changes**
### **Added Classes and Methods**
#### **Added the Aspose.Slides.IPresentationInfo interface and PresentationInfo Classes**
Represent info about presentation.

Method Boolean isEncrypted() gets True if a presentation is encrypted, otherwise gets False.

Method LoadFormat getLoadFormat() gets the presentation type.
#### **Added the Aspose.Slides.IShape.isGrouped() Method**
The method Aspose.Slides.IShape.isGrouped() determines whether the shape is grouped.
#### **Added the Aspose.Slides.IShape.getParentGroup() Method**
The method Aspose.Slides.IShape.getParentGroup() returns the parent GroupShape object if the shape is grouped. Otherwise it returns null.
#### **Added the Aspose.Slides.IShapeCollection.addGroupShape() Method**
The method Aspose.Slides.IShapeCollection.addGroupShape() creates a new GroupShape and adds it to the end of the collection.

The GroupShape frame size and position will be fitted to content when new shape will be added into the GroupShape.
#### **Added the Aspose.Slides.IShapeCollection.clear() Method**
The method Aspose.Slides.IShapeCollection.clear() removes all shapes from the collection.
#### **Added Aspose.Slides.IShapeCollection.insertGroupShape(int) Method**
The method Aspose.Slides.IShapeCollection.insertGroupShape(int) creates a new GroupShape and inserts it to the collection at the specified index.
GroupShape frame size and position will be fitted to content when new shape will be added into the GroupShape.
#### **Added the IPresentationFactory.getPresentationInfo(string file), IPresentatoinFactory.getPresentationInfo(InputStream stream) Methods**
These methods allow developers to receive information about a presentation file/stream without full presentation loading.
#### **Added the IPresentationFactory PresentationFactory.getInstance() Method**
Allows using the factory functionality without instantiation.
### **Restrictions**
#### **Restrictions had been added for using undefined values for IShape.getFrame()**
Code that attempts to assign an undefined frame to IShape.setFrame(IShapeFrame) doesn't make sense in general cases (particularly when the parent GroupShape is multiple nested into other {{GroupShape}}s). For example:

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

or

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

Such code can lead to unclear situations. So restrictions have been added for using undefined values for IShape.Frame. The values of x, y, width, height, flipH, flipV and rotationAngle must be defined (not Float.NaN or NullableBool.NotDefined). The example code above now throws an ArgumentException exception.
This applies to these use cases:

``` java

 IShape shape = ...;

shape.setFrame(...); // cannot be undefined

IShapeCollection shapes = ...;

// x, y, width, height parameters cannot be Float.NaN:

{

    shapes.addAudioFrameCD(...);

    shapes.addAudioFrameEmbedded(...);

    shapes.addAudioFrameLinked(...);

    shapes.addAutoShape(...);

    shapes.addChart(...);

    shapes.addConnector(...);

    shapes.addOleObjectFrame(...);

    shapes.addPictureFrame(...);

    shapes.addSmartArt(...);

    shapes.addTable(...);

    shapes.addVideoFrame(...);

    shapes.insertAudioFrameEmbedded(...);

    shapes.insertAudioFrameLinked(...);

    shapes.insertAutoShape(...);

    shapes.insertChart(...);

    shapes.insertConnector(...);

    shapes.insertOleObjectFrame(...);

    shapes.insertPictureFrame(...);

    shapes.insertTable(...);

    shapes.insertVideoFrame(...);

}

```

But the IShape.getRawFrame() frame can be undefined. This make sense when a shape is linked to a placeholder. Then undefined shape frame values are overridden from the parent placeholder shape. If there is no parent placeholder shape for that shape then it uses default values when it evaluates effective frame based on its IShape.getRawFrame(). Default values are 0 and NullableBool.False for x, y, width, height, flipH, flipV and rotationAngle. For example:

``` java

 IShape shape = ...; // shape is linked to placeholder

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// now shape inherits x, y, height, flipH, flipV values form placeholder and overrides width=100 and rotationAngle=0.

```
### **Changed Properties**
#### **Changed the Type and Name of the Aspose.Slides.IShapeCollection.getParent() Method**
The type of the Aspose.Slides.IShapeCollection.Parent property has been changed from ISlideComponent to the new IGroupShape interface. The IGroupShape interface is a descendant of the ISlideComponent so existing code needs no adaptation.

The name of the Aspose.Slides.IShapeCollection.getParent() method has been changed from getParent to getParentGroup().
#### **Change the Type of the Aspose.Slides.IShapeFrame.getFlipH() and .getFlipV() Methods**
The type of the Aspose.Slides.IShapeFrame.getFlipH() method has been changed from bool to NullableBool.

The IShape.getFrame() method returns the effective instance of IShapeFrame (all of which properties have defined effective values).

The IShape.getRawFrame() method returns an IShapeFrame instance of which each property can have undefined value (particularly FlipH or FlipV can have value NullableBool.NotDefined).
