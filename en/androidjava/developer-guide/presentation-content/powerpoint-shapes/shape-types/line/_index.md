---
title: Add Line Shapes to Presentations on Android
linktitle: Line
type: docs
weight: 50
url: /androidjava/Line/
keywords:
- line
- create line
- add line
- plain line
- configure line
- customize line
- dash style
- arrow head
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Learn to manipulate line formatting in PowerPoint presentations with Aspose.Slides for Android. Discover properties, methods, and Java examples."
---

## **Overview**

Aspose.Slides allows you to add line shapes to PowerPoint slides programmatically. This article shows how to create a simple line and how to customize a line so it appears as an arrow.

You will learn how to add a line shape to a slide, adjust its visual appearance, and save the updated presentation. The examples focus on practical line formatting settings such as style, width, dash pattern, arrowhead options, and fill color.

## **Create a Plain Line**

To add a simple plain line to a selected slide of the presentation, please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Line type using [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) method exposed by [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) object.
- Write the modified presentation as a PPTX file.

In the example given below, we have added a line to the first slide of the presentation.

```java
// Instantiate PresentationEx class that represents the PPTX file
Presentation pres = new Presentation();
try {
    // Get the first slide
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Add an AutoShape of type line
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Write the PPTX to Disk
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Create an Arrow-Shaped Line**

Aspose.Slides for Android via Java also allows developers to configure some properties of the line to make it look more appealing. Let's try to configure few properties of a line to make it look like an arrow. Please follow the steps below to do so:

- Create an instance of [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Line type using [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) method exposed by [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) object.
- Set the [Line Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineStyle) to one of the styles as offered by Aspose.Slides for Android via Java.
- Set the Width of the line.
- Set the [Dash Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineDashStyle) of the line to one of the styles offered by Aspose.Slides for Android via Java.
- Set the [Arrow Head Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) and [Length](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) of the start point of the line.
- Set the [Arrow Head Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) and [Length](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) of the end point of the line.
- Write the modified presentation as a PPTX file.

```java
// Instantiate PresentationEx class that represents the PPTX file
Presentation pres = new Presentation();
try {
    // Get the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Add an AutoShape of type line
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Apply some formatting on the line
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Write the PPTX to Disk
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Can I convert a regular line into a connector so it "snaps" to shapes?**

No. A regular line (an [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/) of type [Line](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/)) does not automatically become a connector. To make it snap to shapes, use the dedicated [Connector](https://reference.aspose.com/slides/androidjava/com.aspose.slides/connector/) type and the [corresponding APIs](/slides/androidjava/connector/) for connections.

**What should I do if a line’s properties are inherited from the theme and it’s hard to determine the final values?**

[Read the effective properties](/slides/androidjava/shape-effective-properties/) through the [ILineFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilinefillformateffectivedata/) interfaces—these already account for inheritance and theme styles.

**Can I lock a line against editing (moving, resizing)?**

Yes. Shapes provide [lock objects](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) that let you disallow editing operations.
