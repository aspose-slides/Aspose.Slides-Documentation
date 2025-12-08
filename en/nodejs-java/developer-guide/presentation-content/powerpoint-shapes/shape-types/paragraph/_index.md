---
title: Get Paragraph Bounds from Presentations in JavaScript
linktitle: Paragraph
type: docs
weight: 60
url: /nodejs-java/paragraph/
keywords:
- paragraph bounds
- text portion bounds
- paragraph coordinate
- portion coordinate
- paragraph size
- text portion size
- text frame
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Learn how to retrieve paragraph and text-portion bounds in JavaScript with Aspose.Slides for Node.js to optimize text positioning in PowerPoint presentations."
---


## **Get Paragraph and Portion Coordinates in TextFrame**
Using Aspose.Slides for Node.js via Java, developers can now get the rectangular coordinates for Paragraph inside paragraphs collection of TextFrame. It also allows you to get [the coordinates of portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion#getCoordinates--) inside portion collection of a paragraph. In this topic, we are going to demonstrate with the help of an example that how to get the rectangular coordinates for paragraph along with position of portion inside a paragraph.

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
var textFrame = shape.getTextFrame();
for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
    const paragraph = textFrame.getParagraphs().get_Item(i);
    for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
        const portion = paragraph.getPortions().get_Item(j);
        var point = portion.getCoordinates();
    }
}
```


## **Get Rectangular Coordinates of Paragraph**
Using [**getRect()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph#getRect--) method developers can get paragraph bounds rectangle.

```javascript
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    var rect = textFrame.getParagraphs().get_Item(0).getRect();
    console.log("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Get size of paragraph and portion inside table cell text frame**

To get the [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) or [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph) size and coordinates in a table cell text frame, you can use the [Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion#getRect--) and [Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph#getRect--) methods.

This sample code demonstrates the described operation:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var cell = tbl.getRows().get_Item(1).get_Item(1);
    var x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    var y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();
    
    for (let i = 0; i < cell.getTextFrame().getParagraphs().getCount(); i++) {
        const para = cell.getTextFrame().getParagraphs().get_Item(i);
        if (para.getText() === "") {
            continue;
        }
        var rect = para.getRect();
        var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        for (let j = 0; j < para.getPortions().getCount(); j++) {
            const portion = para.getPortions().get_Item(j);
            if (portion.getText().includes("0")) {
                rect = portion.getRect();
                shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
                shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            }
        }
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**In what units are the coordinates returned for a paragraph and text portions measured?**

In points, where 1 inch = 72 points. This applies to all coordinates and dimensions on the slide.

**Does word wrapping affect a paragraph’s bounds?**

Yes. If [wrapping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) is enabled in the [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/), the text breaks to fit the area width, which changes the paragraph’s actual bounds.

**Can paragraph coordinates be reliably mapped to pixels in the exported image?**

Yes. Convert points to pixels using: pixels = points × (DPI / 72). The result depends on the DPI chosen for rendering/export.

**How do I get the "effective" paragraph formatting parameters, taking style inheritance into account?**

Use the [effective paragraph formatting data structure](/slides/nodejs-java/shape-effective-properties/); it returns the final consolidated values for indents, spacing, wrapping, RTL, and more.
