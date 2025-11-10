---
title: Ellipse
type: docs
weight: 30
url: /nodejs-java/ellipse/
---


{{% alert color="primary" %}} 

In this topic, we will introduce developers about adding ellipse shapes to their slides using Aspose.Slides for Node.js via Java. Aspose.Slides for Node.js via Java provides an easier set of APIs to draw different kinds of shapes with just a few lines of code.

{{% /alert %}} 

## **Create Ellipse**
To add a simple ellipse to a selected slide of the presentation, please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Ellipse type using [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) method exposed by [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) object.
- Write the modified presentation as a PPTX file.

In the example given below, we have added an ellipse to the first slide

```javascript
// Instantiate Presentation class that represents the PPTX
var pres = new aspose.slides.Presentation();
try {
    // Get the first slide
    var sld = pres.getSlides().get_Item(0);
    // Add AutoShape of ellipse type
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Write the PPTX file to disk
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Create Formatted Ellipse**
To add a better formatted ellipse to a slide, please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Ellipse type using [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) method exposed by [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) object.
- Set the Fill Type of the Ellipse to Solid.
- Set the Color of the Ellipse using SolidFillColor.Color property as exposed by [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillFormat) object associated with the [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) object.
- Set the Color of the lines of the Ellipse.
- Set the Width of the lines of the Ellipse.
- Write the modified presentation as a PPTX file.

In the example given below, we have added a formatted ellipse to the first slide of the presentation.

```javascript
// Instantiate Presentation class that represents the PPTX
var pres = new aspose.slides.Presentation();
try {
    // Get the first slide
    var sld = pres.getSlides().get_Item(0);
    // Add AutoShape of ellipse type
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Apply some formatting to ellipse shape
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Chocolate));
    // Apply some formatting to the line of Ellipse
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Write the PPTX file to disk
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
 
## **FAQ**

**How do I set the exact position and size of an ellipse with respect to the slide's units?**

Coordinates and sizes are typically specified **in points**. For predictable results, base your calculations on the slide size and convert required millimeters or inches to points before assigning values.

**How can I place an ellipse above or below other objects (control stacking order)?**

Adjust the drawing order of the object by bringing it to front or sending it to back. This lets the ellipse overlap other objects or reveal those beneath it.

**How do I animate the appearance or emphasis of an ellipse?**

[Apply](/slides/nodejs-java/shape-animation/) entrance, emphasis, or exit effects to the shape, and configure triggers and timing to orchestrate when and how the animation plays.
