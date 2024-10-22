---
title: Paragraph
type: docs
weight: 60
url: /nodejs-java/paragraph/
---


## Get Paragraph and Portion Coordinates in TextFrame ##
Using Aspose.Slides for Node.js via Java, developers can now get the rectangular coordinates for Paragraph inside paragraphs collection of TextFrame. It also allows you to get [the coordinates of portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion#getCoordinates--) inside portion collection of a paragraph. In this topic, we are going to demonstrate with the help of an example that how to get the rectangular coordinates for paragraph along with position of portion inside a paragraph.

```javascript
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    textFrame.getParagraphs().forEach(function(paragraph) {
        paragraph.getPortions().forEach(function(portion) {
            var point = portion.getCoordinates();
        });
    });
```


## **Get Rectangular Coordinates of Paragraph**
Using [**getRect()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph#getRect--) method developers can get paragraph bounds rectangle.

```javascript
    var pres = new aspose.slides.Presentation("HelloWorld.pptx");
    try {
        var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
        var textFrame = shape.getTextFrame();
        var rect = textFrame.getParagraphs().get_Item(0).getRect();
        console.log((((((("X: " + rect.x) + " Y: ") + rect.y) + " Width: ") + rect.width) + " Height: ") + rect.height);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Get size of paragraph and portion inside table cell text frame** ##

To get the [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) or [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph) size and coordinates in a table cell text frame, you can use the [Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion#getRect--) and [Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph#getRect--) methods.

This sample code demonstrates the described operation:

```javascript
    var pres = new aspose.slides.Presentation("source.pptx");
    try {
        var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
        var cell = tbl.getRows().get_Item(1).get_Item(1);
        var x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
        var y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();
        cell.getTextFrame().getParagraphs().forEach(function(para) {
            if (para.getText().equals("")) {
                continue;
            }
            var rect = para.getRect();
            var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, rect.getX() + x, rect.getY() + y, rect.getWidth(), rect.getHeight());
            shape.getFillFormat().setFillType(aspose.slides.FillType.NoFill);
            shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
            shape.getLineFormat().getFillFormat().setFillType(aspose.slides.FillType.Solid);
            para.getPortions().forEach(function(portion) {
                if (portion.getText().contains("0")) {
                    rect = portion.getRect();
                    shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, rect.getX() + x, rect.getY() + y, rect.getWidth(), rect.getHeight());
                    shape.getFillFormat().setFillType(aspose.slides.FillType.NoFill);
                }
            });
        });
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```
