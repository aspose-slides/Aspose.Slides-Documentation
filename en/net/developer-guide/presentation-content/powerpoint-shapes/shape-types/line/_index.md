---
title: Add Line Shapes to Presentations in .NET
linktitle: Line
type: docs
weight: 50
url: /net/Line/
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
- .NET
- C#
- Aspose.Slides
description: "Learn to manipulate line formatting in PowerPoint presentations with Aspose.Slides for .NET. Discover properties, methods, and examples."
---

Aspose.Slides for .NET supports adding different kinds of shapes to the slides. In this topic, we will start working with shapes by adding lines to the slides. Using Aspose.Slides for .NET, developers can not only create simple lines , but some fancy lines can also be drawn on the slides.
## **Create Plain Line**
To add a simple plain line to a selected slide of the presentation, please follow the steps below:

- Create an instance of [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Line type using [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index) method exposed by Shapes object.
- Write the modified presentation as a PPTX file.

In the example given below, we have added a line to the first slide of the presentation.

```c#
// Instantiate PresentationEx class that represents the PPTX file
using (Presentation pres = new Presentation())
{
    // Get the first slide
    ISlide sld = pres.Slides[0];

    // Add an autoshape of type line
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Write the PPTX to Disk
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```


## **Create Arrow Shaped Line**
Aspose.Slides for .NET also allows developers to configure some properties of the line to make it look more appealing. Let's try to configure few properties of a line to make it look like an arrow. Please follow the steps below to do so:

- Create an instance of [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/aspose.slides/)[](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Line type using AddAutoShape method exposed by Shapes object.
- Set the Line Style to one of the styles as offered by Aspose.Slides for .NET.
- Set the Width of the line.
- Set the [Dash Style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) of the line to one of the styles offered by Aspose.Slides for .NET.
- Set the [Arrow Head Style](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) and Length of the start point of the line.
- Set the Arrow Head Style and Length of the end point of the line.
- Write the modified presentation as a PPTX file.

```c#
// Instantiate PresentationEx class that represents the PPTX file
using (Presentation pres = new Presentation())
{

    // Get the first slide
    ISlide sld = pres.Slides[0];

    // Add an autoshape of type line
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Apply some formatting on the line
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    //Write the PPTX to Disk
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Can I convert a regular line into a connector so it "snaps" to shapes?**

No. A regular line (an [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) of type [Line](https://reference.aspose.com/slides/net/aspose.slides/shapetype/)) does not automatically become a connector. To make it snap to shapes, use the dedicated [Connector](https://reference.aspose.com/slides/net/aspose.slides/connector/) type and the [corresponding APIs](/slides/net/connector/) for connections.

**What should I do if a line’s properties are inherited from the theme and it’s hard to determine the final values?**

[Read the effective properties](/slides/net/shape-effective-properties/) through the [ILineFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilinefillformateffectivedata/) interfaces—these already account for inheritance and theme styles.

**Can I lock a line against editing (moving, resizing)?**

Yes. Shapes provide [lock objects](https://reference.aspose.com/slides/net/aspose.slides/autoshape/autoshapelock/) that let you [disallow editing operations](/slides/net/applying-protection-to-presentation/).
