---
title: Create Line Shapes in Presentations with Python
linktitle: Line
type: docs
weight: 50
url: /python-net/line/
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
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn to manipulate line formatting in PowerPoint and OpenDocument presentations with Aspose.Slides for Python via .NET. Discover properties, methods, and examples."
---

## **Overview**

Aspose.Slides for Python via .NET supports adding different kinds of shapes to the slides. In this topic, we will start working with shapes by adding lines to the slides. Using Aspose.Slides, developers can not only create simple lines , but some fancy lines can also be drawn on the slides.

## **Create Plain Lines**

Use Aspose.Slides to add a plain line to a slide as a simple separator or connector. To add a plain line to a selected slide in a presentation, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to the slide by index.
1. Add an [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) of type `LINE` using the `add_auto_shape` method on the [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) object.
1. Save the presentation as a PPTX file.

In the example below, a line is added to the first slide of the presentation.

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:

    # Get the first slide.
    slide = presentation.slides[0]

    # Add an auto shape of type LINE.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Save the presentation as a PPTX file.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Create Arrow-Shaped Lines**

Aspose.Slides lets you configure line properties to make them more visually appealing. Below, we configure a few properties of a line to make it look like an arrow. Follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to a slide by index.
1. Add an [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) of type `LINE` using the `add_auto_shape` method on the [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) object.
1. Set the [line style](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/).
1. Set the line width.
1. Set the line’s [dash style](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/).
1. Set the [arrowhead style](https://reference.aspose.com/slides/python-net/aspose.slides/linearrowheadstyle/) and length for the line’s start point.
1. Set the arrowhead style and length for the line’s end point.
1. Save the presentation as a PPTX file.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class that represents the PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add an auto shape of type LINE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Apply formatting to the line.
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # Save the presentation as a PPTX file.
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I convert a regular line into a connector so it "snaps" to shapes?**

No. A regular line (an [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) of type [LINE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/)) does not automatically become a connector. To make it snap to shapes, use the dedicated [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/) type and the [corresponding APIs](/slides/python-net/connector/) for connections.

**What should I do if a line’s properties are inherited from the theme and it’s hard to determine the final values?**

[Read the effective properties](/slides/python-net/shape-effective-properties/) through the [ILineFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilinefillformateffectivedata/) classes—these already account for inheritance and theme styles.

**Can I lock a line against editing (moving, resizing)?**

Yes. Shapes provide [lock objects](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) that let you [disallow editing operations](/slides/python-net/applying-protection-to-presentation/).
