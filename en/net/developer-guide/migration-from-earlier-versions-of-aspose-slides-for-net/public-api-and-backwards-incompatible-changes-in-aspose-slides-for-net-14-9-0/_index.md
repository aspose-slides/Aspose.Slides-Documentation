---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for .NET 14.9.0
linktitle: Aspose.Slides for .NET 14.9.0
type: docs
weight: 110
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
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

This page lists all [added](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) or [removed](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) classes, methods, properties and so on, and other changes introduced with the Aspose.Slides for .NET 14.9.0 API.

{{% /alert %}} 
## **Public API Changes**
#### **Inheritance from ICollection and Generic IEnumerable Interfaces Added to ISmartArtNodeCollection**
The class Aspose.Slides.SmartArt.SmartArtNodeCollection (and the related interface Aspose.Slides.SmartArt.ISmartArtNodeCollection) inherit the generic interface IEnumerable<ISmartArtNode> and interface ICollection.
#### **SmartArtLayoutType.Custom Enum Value Added**
The Custom SmartArt layout type represents a diagram with a custom template. Custom diagrams can only be loaded from a presentation file and can't be created via the ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom) method.
#### **SmartArtShape Class and ISmartArtShape Interface Added**
The Aspose.Slides.SmartArt.SmartArtShape class (and its interface Aspose.Slides.SmartArt.ISmartArtShape) give access to individual shapes in a SmartArt diagram. SmartArtShape can be used to change FillFormat, LineFormat, adding Hyperlinks and other tasks.

{{% alert color="primary" %}} 

**Note**: SmartArtShape does not support the IShape properties RawFrame, Frame, Rotation, X, Y, Width, Height and throws a System.NotSupportedException when attempting to access them.

Example of usage:

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **SmartArtShapeCollection Class, ISmartArtShapeCollection Interface and ISmartArtNode.Shapes Property Added**
The Aspose.Slides.SmartArt.SmartArtShapeCollection class (and its interface Aspose.Slides.SmartArt.ISmartArtShapeCollection) add access to individual shapes in a SmartArt diagram. The collection contains shapes associated with SmartArtNode. The SmartArtNode.Shapes property returns collections of all shapes associated with the node.

{{% alert color="primary" %}} 

**Note**: depending on the SmartArtLayoutType one SmartArtShape can be shared between several nodes.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **Methods for Saving Slides with Page Numbers Keeping Added**
The following methods have been added:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

These methods allow developers to save specified presentation slides to PDF, XPS, TIFF, HTML formats. The 'slides' array is used to specify page numbers, starting from 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Array of slides positions

presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **Methods for Replacing Images Added to PPImage, IPPImage**
New methods added:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);

//First method

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);

//Second method

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);

//Third method

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

``` 
