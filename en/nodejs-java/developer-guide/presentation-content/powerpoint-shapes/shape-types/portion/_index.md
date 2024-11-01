---
title: Portion
type: docs
weight: 70
url: /nodejs-java/portion/
---

## **Get Position Coordinates of Portion**
[**getCoordinates()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion#getCoordinates--) method has been added to [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) class which allows retrieving the coordinates of the beginning of the portion.

```javascript
// Instantiate Prseetation class that represents the PPTX
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Reshaping the context of presentation
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const paragraph = textFrame.getParagraphs().get_Item(i);
        for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
            const portion = paragraph.getPortions().get_Item(j);
            var point = portion.getCoordinates();
            console.log("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
