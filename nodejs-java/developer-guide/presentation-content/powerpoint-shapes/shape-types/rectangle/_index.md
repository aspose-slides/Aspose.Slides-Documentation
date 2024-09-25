---
title: Rectangle
type: docs
weight: 80
url: /nodejs-java/rectangle/
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
    var pres = new  aspose.slides.Presentation();
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
    var pres = new  aspose.slides.Presentation();
    try {
        // Get the first slide
        var sld = pres.getSlides().get_Item(0);
        // Add AutoShape of ellipse type
        var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
        // Apply some formatting to ellipse shape
        shp.getFillFormat().setFillType(aspose.slides.FillType.Solid);
        shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
        // Apply some formatting to the line of Ellipse
        shp.getLineFormat().getFillFormat().setFillType(aspose.slides.FillType.Solid);
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
