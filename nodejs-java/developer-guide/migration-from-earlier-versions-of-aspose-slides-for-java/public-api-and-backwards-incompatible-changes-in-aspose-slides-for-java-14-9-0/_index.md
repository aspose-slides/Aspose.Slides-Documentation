---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for Java 14.9.0
type: docs
weight: 80
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) classes, methods, properties and so on, any new restrictions and other [changes](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) introduced with the Aspose.Slides for Java 14.9.0 API.

{{% /alert %}} 
## **Public API Changes**
### **Added Methods for Replacing Image to PPImage, IPPImage**
New methods added:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

```javascript
    var presentation = new  com.aspose.slides.Presentation("presentation.pptx");
    // The first way
    // ...
    var imageData = presentation.getImages().get_Item(0).replaceImage(imageData);
    // The second way
    presentation.getImages().get_Item(1).replaceImage(presentation.getImages().get_Item(0));
    presentation.save("presentation_out.pptx", com.aspose.slides.SaveFormat.Pptx);
```
### **Added Methods for Saving Slides Keeping Page Numbers**
The following methods have been added:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

These methods allow to save specified presentation slides to PDF, XPS, TIFF, HTML formats. The 'slides' array allows to specify page numbers, starting from 1.

```javascript
    save(string, slides, SaveFormat);
```




```javascript
    var presentation = new  com.aspose.slides.Presentation(presentationFileName);
    var slides = new int[]{ 2, 3, 5 };// Array of slides positions
    presentation.save(outFileName, slides, com.aspose.slides.SaveFormat.Pdf);
```
### **Added the SmartArtLayoutType.Custom Enum Value**
This type of SmartArt layout represents diagram with custom template. Custom diagrams only can be loaded from presentation file and can't be created via method ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)
### **Added the SmartArtShape Class and ISmartArtShape Interface**
The Aspose.Slides.SmartArt.SmartArtShape class (and its interface Aspose.Slides.SmartArt.ISmartArtShape) add access to individual shapes inside SmartArt diagram. SmartArtShape can be used to change FillFormat, LineFormat, adding Hyperlinks etc.

{{% alert color="primary" %}} 

SmartArtShape does not supported IShape properties RawFrame, Frame, Rotation, X, Y, Width, Height and thrown System.NotSupportedException when attempting to access them.

{{% /alert %}} 

Example of usage:

```javascript
    var pres = new  com.aspose.slides.Presentation();
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, com.aspose.slides.SmartArtLayoutType.BasicBlockList);
    var node = smart.getAllNodes().get_Item(0);
    node.getShapes().forEach(function(shape) {
        shape.getFillFormat().setFillType(com.aspose.slides.FillType.Solid);
        shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    });
    pres.save("out.pptx", com.aspose.slides.SaveFormat.Pptx);
```
### **SmartArtShapeCollection class, ISmartArtShapeCollection interface and ISmartArtNode.getShapes() method have been added**
The Aspose.Slides.SmartArt.SmartArtShapeCollection class (and its interface Aspose.Slides.SmartArt.ISmartArtShapeCollection) add access to individual shapes inside SmartArt diagram. Collection contains shapes associated with SmartArtNode. Property SmartArtNode.Shapes returns collections of all shapes associated with the node.

{{% alert color="primary" %}} 

Depending of SmartArtLayoutType one SmartArtShape can be shared between several nodes.

{{% /alert %}} 

﻿

```javascript
    var pres = new  com.aspose.slides.Presentation();
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, com.aspose.slides.SmartArtLayoutType.BasicBlockList);
    var node = smart.getAllNodes().get_Item(0);
    node.getShapes().forEach(function(shape) {
        shape.getFillFormat().setFillType(com.aspose.slides.FillType.Solid);
        shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    });
    pres.save("out.pptx", com.aspose.slides.SaveFormat.Pptx);
```
