---
title: Line
type: docs
weight: 50
url: /python-net/line/
keywords: "Line, PowerPoint shape, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Add line in PowerPoint presentation in Python"
---

Aspose.Slides for Python via .NET supports adding different kinds of shapes to the slides. In this topic, we will start working with shapes by adding lines to the slides. Using Aspose.Slides for Python via .NET, developers can not only create simple lines , but some fancy lines can also be drawn on the slides.
## **Create Plain Line**
To add a simple plain line to a selected slide of the presentation, please follow the steps below:

- Create an instance of [Presentation ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/)class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Line type using [add_auto_shape](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/ishapecollection/) method exposed by Shapes object.
- Write the modified presentation as a PPTX file.

In the example given below, we have added a line to the first slide of the presentation.

```py
import aspose.slides as slides

# Instantiate PresentationEx class that represents the PPTX file
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Add an autoshape of type line
    sld.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    #Write the PPTX to Disk
    pres.save("LineShape1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Create Arrow Shaped Line**
Aspose.Slides for Python via .NET also allows developers to configure some properties of the line to make it look more appealing. Let's try to configure few properties of a line to make it look like an arrow. Please follow the steps below to do so:

- Create an instance of [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class).
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Line type using AddAutoShape method exposed by Shapes object.
- Set the Line Style to one of the styles as offered by Aspose.Slides for Python via .NET.
- Set the Width of the line.
- Set the [Dash Style](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/linedashstyle/) of the line to one of the styles offered by Aspose.Slides for Python via .NET.
- Set the [Arrow Head Style](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/linearrowheadstyle/) and Length of the start point of the line.
- Set the Arrow Head Style and Length of the end point of the line.
- Write the modified presentation as a PPTX file.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate PresentationEx class that represents the PPTX file
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Add an autoshape of type line
    shp = sld.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Apply some formatting on the line
    shp.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shp.line_format.width = 10

    shp.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shp.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shp.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shp.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shp.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    #Write the PPTX to Disk
    pres.save("LineShape2_out.pptx", slides.export.SaveFormat.PPTX)
```

