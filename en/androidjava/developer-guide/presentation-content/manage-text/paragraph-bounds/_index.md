---
title: Get Paragraph Bounds from Presentations on Android
linktitle: Paragraph Bounds
type: docs
weight: 43
url: /androidjava/paragraph-bounds/
keywords:
- paragraph bounds
- paragraph coordinate
- paragraph size
- text frame
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Learn how to retrieve paragraph bounds in Aspose.Slides for Android via Java to optimize text positioning in PowerPoint presentations."
---

## **Overview**

This article explains how to get the bounds, size, and coordinates of paragraphs in Aspose.Slides. It shows how to retrieve a paragraph rectangle from an [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) by using [IParagraph.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraph#getRect--), how to get paragraph coordinates inside a table cell text frame, and highlights important details such as measurement units, the effect of text wrapping on bounds, pixel conversion, and effective paragraph formatting values.

## **Get Rectangular Coordinates of a Paragraph**

Use [IParagraph.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraph#getRect--) to get the bounding rectangle of a paragraph.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    android.graphics.RectF rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Get the Size of a Paragraph Inside a Table Cell TextFrame**

To get the size and coordinates of an [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) in a table cell text frame, use [IParagraph.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraph#getRect--). The returned rectangle is relative to the table cell text frame, so add the table position and cell offset when you need slide-level coordinates.

The following example gets paragraph bounds inside a table cell and draws rectangles on the slide to visualize those bounds:

```java
Presentation presentation = new Presentation("source.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);
    ICell cell = table.getRows().get_Item(1).get_Item(1);

    double cellX = table.getX() + cell.getOffsetX();
    double cellY = table.getY() + cell.getOffsetY();

    for (IParagraph paragraph : cell.getTextFrame().getParagraphs())
    {
        if (paragraph.getText().isEmpty())
            continue;

        android.graphics.RectF paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.left + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.top + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width(),
                paragraphRectangle.height());

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**In what units are paragraph coordinates measured?**

They are measured in points, where 1 inch equals 72 points. This applies to all coordinates and dimensions on the slide.

**Does word wrapping affect a paragraph’s bounds?**

Yes. If [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) is enabled for the [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/), the text breaks to fit the area width, which changes the paragraph’s actual bounds.

**Can paragraph coordinates be reliably mapped to pixels in the exported image?**

Yes. Convert points to pixels using this formula: pixels = points × (DPI / 72). The result depends on the DPI chosen for rendering or export.

**How do I get the "effective" paragraph formatting parameters, taking style inheritance into account?**

Use the [effective paragraph formatting data structure](/slides/androidjava/shape-effective-properties/); it returns the final consolidated values for indents, spacing, wrapping, RTL, and more.
