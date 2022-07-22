---
title: Line
type: docs
weight: 50
url: /net/Line/
keywords: "Line, PowerPoint shape, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Add line in PowerPoint presentation in C# or .NET"
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

