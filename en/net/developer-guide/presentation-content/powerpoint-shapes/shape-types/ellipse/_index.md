---
title: Add Ellipses to Presentations in .NET
linktitle: Ellipse
type: docs
weight: 30
url: /net/ellipse/
keywords:
- ellipse
- shape
- add ellipse
- create ellipse
- draw ellipse
- formatted ellipse
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Learn how to create, format, and manipulate ellipse shapes in Aspose.Slides for .NET across PPT and PPTX presentations—C# code examples included."
---


## **Create Ellipse**
In this topic, we will introduce developers about adding ellipse shapes to their slides using Aspose.Slides for .NET . Aspose.Slides for .NET provides an easier set of APIs to draw different kinds of shapes with just a few lines of code. To add a simple ellipse to a selected slide of the presentation, please follow the steps below:

1. Create an instance of [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class
1. Obtain the reference of a slide by using its Index
1. Add an AutoShape of Ellipse type using AddAutoShape method exposed by IShapes object
1. Write the modified presentation as a PPTX file

In the example given below, we have added an ellipse to the first slide.

```c#
// Instantiate Prseetation class that represents the PPTX
using (Presentation pres = new Presentation())
{

    // Get the first slide
    ISlide sld = pres.Slides[0];

    // Add autoshape of ellipse type
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    //Write the PPTX file to disk
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```



## **Create Formatted Ellipse**
To add a better formatted ellipse to a slide, please follow the steps below:

1. Create an instance of [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
1. Obtain the reference of a slide by using its Index.
1. Add an AutoShape of Ellipse type using AddAutoShape method exposed by IShapes object.
1. Set the Fill Type of the Ellipse to Solid.
1. Set the Color of the Ellipse using SolidFillColor.Color property as exposed by FillFormat object associated with the IShape object.
1. Set the Color of the lines of the Ellipse.
1. Set the Width of the lines of the Ellipse.
1. Write the modified presentation as a PPTX file.

In the example given below, we have added a formatted ellipse to the first slide of the presentation.

```c#
// Instantiate Prseetation class that represents the PPTX
using (Presentation pres = new Presentation())
{

    // Get the first slide
    ISlide sld = pres.Slides[0];

    // Add autoshape of ellipse type
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Apply some formatting to ellipse shape
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Apply some formatting to the line of Ellipse
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //Write the PPTX file to disk
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**How do I set the exact position and size of an ellipse with respect to the slide's units?**

Coordinates and sizes are typically specified **in points**. For predictable results, base your calculations on the slide size and convert required millimeters or inches to points before assigning values.

**How can I place an ellipse above or below other objects (control stacking order)?**

Adjust the drawing order of the object by bringing it to front or sending it to back. This lets the ellipse overlap other objects or reveal those beneath it.

**How do I animate the appearance or emphasis of an ellipse?**

[Apply](/slides/net/shape-animation/) entrance, emphasis, or exit effects to the shape, and configure triggers and timing to orchestrate when and how the animation plays.
