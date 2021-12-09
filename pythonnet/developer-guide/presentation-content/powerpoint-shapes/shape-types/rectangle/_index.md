---
title: Rectangle
type: docs
weight: 80
url: /pythonnet/rectangle/
keywords: "Create rectangle, PowerPoint shape, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Create rectangle in PowerPoint presentation in Python"
---


## **Create Simple Rectangle**
Like previous topics, this one is also about adding a shape and this time the shape we will discuss about is Rectangle. In this topic, we have described that how developers can add simple or formatted rectangles to their slides using Aspose.Slides for Python via .NET . To add a simple rectangle to a selected slide of the presentation, please follow the steps below:

1. Create an instance of [Presentation ](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation)class.
1. Obtain the reference of a slide by using its Index.
1. Add an IAutoShape of Rectangle type using AddAutoShape method exposed by IShapes object.
1. Write the modified presentation as a PPTX file.

In the example given below, we have added a simple rectangle to the first slide of the presentation.

```py
import aspose.slides as slides

# Instantiate Prseetation class that represents the PPTX
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Add autoshape of rectangle type
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    #Write the PPTX file to disk
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Create Formatted Rectangle**
To add a formatted rectangle to a slide, please follow the steps below:

1. Create an instance of [Presentation ](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation)class.
1. Obtain the reference of a slide by using its Index.
1. Add an IAutoShape of Rectangle type using AddAutoShape method exposed by IShapes object.
1. Set the Fill Type of the Rectangle to Solid.
1. Set the Color of the Rectangle using SolidFillColor.Color property as exposed by FillFormat object associated with the IShape object.
1. Set the Color of the lines of the Rectangle.
1. Set the Width of the lines of the Rectangle.
1. Write the modified presentation as PPTX file.
   The above steps are implemented in the example given below.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate Prseetation class that represents the PPTX
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Add autoshape of rectangle type
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Apply some formatting to rectangle shape
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Apply some formatting to the line of rectangle
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Write the PPTX file to disk
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

