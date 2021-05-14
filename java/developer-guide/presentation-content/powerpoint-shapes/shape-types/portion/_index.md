---
title: Portion
type: docs
weight: 10
url: /java/portion/
---

## **Get Position Coordinates of Portion**
[**getCoordinates()**](https://apireference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--) method has been added to [IPortion](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IPortion) and [Portion](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Portion) class which allows retrieving the coordinates of the beginning of the portion.

```java
// Instantiate Prseetation class that represents the PPTX
Presentation pres = new Presentation();
try {
    // Reshaping the context of presentation
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    ITextFrame textFrame = (ITextFrame) shape.getTextFrame();
    
    for (IParagraph paragraph : textFrame.getParagraphs()) 
    {
        for (IPortion portion : paragraph.getPortions()) 
        {
            Point2D.Float point = portion.getCoordinates();
            System.out.println("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```
