---
title: Ellipse
type: docs
weight: 10
url: /java/ellipse/
---


{{% alert color="primary" %}} 

In this topic, we will introduce developers about adding ellipse shapes to their slides using Aspose.Slides for Java. Aspose.Slides for Java provides an easier set of APIs to draw different kinds of shapes with just a few lines of code.

{{% /alert %}} 

## **Create Ellipse**
To add a simple ellipse to a selected slide of the presentation, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Ellipse type using [addAutoShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) method exposed by [IShapeCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) object.
- Write the modified presentation as a PPTX file.

In the example given below, we have added an ellipse to the first slide

```java
// Instantiate Presentation class that represents the PPTX
Presentation pres = new Presentation();
try {
    // Get the first slide
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Add AutoShape of ellipse type
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // Write the PPTX file to disk
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Create Formatted Ellipse**
To add a better formatted ellipse to a slide, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Ellipse type using [addAutoShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) method exposed by [IShapeCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) object.
- Set the Fill Type of the Ellipse to Solid.
- Set the Color of the Ellipse using SolidFillColor.Color property as exposed by [FillFormat](https://apireference.aspose.com/slides/java/com.aspose.slides/IFillFormat) object associated with the [IShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IShape) object.
- Set the Color of the lines of the Ellipse.
- Set the Width of the lines of the Ellipse.
- Write the modified presentation as a PPTX file.

In the example given below, we have added a formatted ellipse to the first slide of the presentation.

```java
// Instantiate Presentation class that represents the PPTX
Presentation pres = new Presentation();
try {
    // Get the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Add AutoShape of ellipse type
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Apply some formatting to ellipse shape
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Apply some formatting to the line of Ellipse
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Write the PPTX file to disk
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
