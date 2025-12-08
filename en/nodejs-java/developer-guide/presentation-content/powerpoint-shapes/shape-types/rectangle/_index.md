---
title: Add Rectangles to Presentations in JavaScript
linktitle: Rectangle
type: docs
weight: 80
url: /nodejs-java/rectangle/
keywords:
- add rectangle
- create rectangle
- rectangle shape
- simple rectangle
- formatted rectangle
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Boost your PowerPoint presentations by adding rectangles with JavaScript and Aspose.Slides for Node.js—easily design and modify shapes programmatically."
---

{{% alert color="primary" %}} 

Like previous topics, this one is also about adding a shape and this time the shape we will discuss about is **Rectangle**. In this topic, we have described that how developers can add simple or formatted rectangles to their slides using Aspose.Slides for Node.js via Java.

{{% /alert %}} 

## **Add Rectangle to Slide**
To add a simple rectangle to a selected slide of the presentation, please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) of Rectangle type using [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) method exposed by [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) object.
- Write the modified presentation as a PPTX file.

In the example given below, we have added a simple rectangle to the first slide of the presentation.

```javascript
// Instantiate Prseetation class that represents the PPTX
var pres = new aspose.slides.Presentation();
try {
    // Get the first slide
    var sld = pres.getSlides().get_Item(0);
    // Add AutoShape of ellipse type
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Write the PPTX file to disk
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Add Formatted Rectangle to Slide**
To add a formatted rectangle to a slide, please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) of Rectangle type using [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) method exposed by [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) object.
- Set the [Fill Type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillType) of the Rectangle to Solid.
- Set the Color of the Rectangle using [SolidFillColor.setColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) method as exposed by [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillFormat) object associated with the [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) object.
- Set the Color of the lines of the Rectangle.
- Set the Width of the lines of the Rectangle.
- Write the modified presentation as PPTX file.

The above steps are implemented in the example given below.

```javascript
// Instantiate Prseetation class that represents the PPTX
var pres = new aspose.slides.Presentation();
try {
    // Get the first slide
    var sld = pres.getSlides().get_Item(0);
    // Add AutoShape of ellipse type
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Apply some formatting to ellipse shape
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // Apply some formatting to the line of Ellipse
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Write the PPTX file to disk
    pres.save("RecShp2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**How do I add a rectangle with rounded corners?**

Use the rounded-corner [shape type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/) and adjust the corner radius in the shape’s properties; rounding can also be applied per corner via geometry adjustments.

**How do I fill a rectangle with an image (texture)?**

Select the picture [fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/), provide the image source, and configure [stretching/tiling modes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/).

**Can a rectangle have shadow and glow?**

Yes. [Outer/inner shadow, glow, and soft edges](/slides/nodejs-java/shape-effect/) are available with adjustable parameters.

**Can I turn a rectangle into a button with a hyperlink?**

Yes. [Assign a hyperlink](/slides/nodejs-java/manage-hyperlinks/) to the shape click (jump to a slide, file, web address, or e-mail).

**How can I protect a rectangle from moving and changes?**

[Use shape locks](/slides/nodejs-java/applying-protection-to-presentation/): you can forbid moving, resizing, selection, or text editing to preserve the layout.

**Can I convert a rectangle to a raster image or SVG?**

Yes. You can [render the shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) to an image with a specified size/scale or [export it as SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) for vector use.

**How do I quickly get the actual (effective) properties of a rectangle considering theme and inheritance?**

[Use the shape’s effective properties](/slides/nodejs-java/shape-effective-properties/): the API returns computed values that account for theme styles, layout, and local settings, simplifying formatting analysis.
