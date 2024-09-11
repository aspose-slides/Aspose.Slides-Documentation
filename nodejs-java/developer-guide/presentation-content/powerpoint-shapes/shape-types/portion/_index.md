---
title: Portion
type: docs
weight: 70
url: /nodejs-java/portion/
---

## **Get Position Coordinates of Portion**
[**getCoordinates()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IPortion#getCoordinates--) method has been added to [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interfaces/IPortion) and [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) class which allows retrieving the coordinates of the beginning of the portion.

```javascript
    // Instantiate Prseetation class that represents the PPTX
    var pres = new  aspose.slides.Presentation();
    try {
        // Reshaping the context of presentation
        var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
        var textFrame = shape.getTextFrame();
        textFrame.getParagraphs().forEach(function(paragraph) {
            paragraph.getPortions().forEach(function(portion) {
                var point = portion.getCoordinates();
                console.log((("X: " + point.x) + " Y: ") + point.y);
            });
        });
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```
