---
title: Paragraph
type: docs
weight: 60
url: /python-net/paragraph/
keywords: "Paragraph, portion, paragraph coordinate, portion coordinate, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Paragraph and portion in PowerPoint presentation in Python"
---

## **Get Paragraph and Portion Coordinates in TextFrame**
Using Aspose.Slides for Python via .NET, developers can now get the rectangular coordinates for Paragraph inside paragraphs collection of TextFrame. It also allows you to get the coordinates of portion inside portion collection of a paragraph. In this topic, we are going to demonstrate with the help of an example that how to get the rectangular coordinates for paragraph along with position of portion inside a paragraph.

## **Get Rectangular Coordinates of Paragraph**
The new method **GetRect()** has been added. It allows to get paragraph bounds rectangle.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **Get size of paragraph and portion inside table cell text frame** ##

To get the [Portion](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/portion/) or [Paragraph](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/paragraph/) size and coordinates in a table cell text frame, you can use the [IPortion.GetRect](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/iportion/) and [IParagraph.GetRect](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/iparagraph/) methods.

This sample code demonstrates the described operation:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "source.pptx") as pres:
    tbl = pres.slides[0].shapes[0]

    cell = tbl.rows[1][1]


    x = tbl.X + tbl.rows[1][1].offset_x
    y = tbl.Y + tbl.rows[1][1].offset_y

    for para in cell.text_frame.paragraphs:
        if para.text == "":
            continue

        rect = para.get_rect()
        shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                rect.x + x, rect.y + y, rect.width, rect.height)

        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        shape.line_format.fill_format.fill_type = slides.FillType.SOLID

        for portion in para.portions:
            if "0" in portion.text:
                rect = portion.get_rect()
                shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                        rect.x + x, rect.y + y, rect.width, rect.height)

                shape.fill_format.fill_type = slides.FillType.NO_FILL
```