---
title: Get Paragraph Bounds from Presentations in .NET
linktitle: Paragraph Bounds
type: docs
weight: 43
url: /net/paragraph-bounds/
keywords:
- paragraph bounds
- paragraph coordinate
- paragraph size
- text frame
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Learn how to retrieve paragraph bounds in Aspose.Slides for .NET to optimize text positioning in PowerPoint presentations."
---

## **Overview**

This article explains how to get the bounds, size, and coordinates of paragraphs in Aspose.Slides. It shows how to retrieve a paragraph rectangle from an [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) by using [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/), how to get paragraph coordinates inside a table cell text frame, and highlights important details such as measurement units, the effect of text wrapping on bounds, pixel conversion, and effective paragraph formatting values.

## **Get Rectangular Coordinates of a Paragraph**

Use [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) to get the bounding rectangle of a paragraph.

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];
var paragraph = shape.TextFrame.Paragraphs[0];
var rectangle = paragraph.GetRect();
```

## **Get the Size of a Paragraph Inside a Table Cell TextFrame**

To get the size and coordinates of an [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) in a table cell text frame, use [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/). The returned rectangle is relative to the table cell text frame, so add the table position and cell offset when you need slide-level coordinates.

The following example gets paragraph bounds inside a table cell and draws rectangles on the slide to visualize those bounds:

```csharp
using var presentation = new Presentation("source.pptx");
var slide = presentation.Slides[0];
var table = (ITable)slide.Shapes[0];
var cell = table.Rows[1][1];

var cellX = table.X + cell.OffsetX;
var cellY = table.Y + cell.OffsetY;

foreach (var paragraph in cell.TextFrame.Paragraphs)
{
    if (string.IsNullOrEmpty(paragraph.Text))
        continue;

    var paragraphRectangle = paragraph.GetRect();
    var paragraphRectangleX = paragraphRectangle.X + (float)cellX;
    var paragraphRectangleY = paragraphRectangle.Y + (float)cellY;

    var paragraphBoundsShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.Width,
        paragraphRectangle.Height);

    paragraphBoundsShape.FillFormat.FillType = FillType.NoFill;
    paragraphBoundsShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
    paragraphBoundsShape.LineFormat.FillFormat.FillType = FillType.Solid;
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **FAQ**

**In what units are paragraph coordinates measured?**

They are measured in points, where 1 inch equals 72 points. This applies to all coordinates and dimensions on the slide.

**Does word wrapping affect a paragraph’s bounds?**

Yes. If [TextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/wraptext/) is enabled for the [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/), the text breaks to fit the area width, which changes the paragraph’s actual bounds.

**Can paragraph coordinates be reliably mapped to pixels in the exported image?**

Yes. Convert points to pixels using this formula: pixels = points × (DPI / 72). The result depends on the DPI chosen for rendering or export.

**How do I get the "effective" paragraph formatting parameters, taking style inheritance into account?**

Use the [effective paragraph formatting data structure](/slides/net/shape-effective-properties/); it returns the final consolidated values for indents, spacing, wrapping, RTL, and more.
