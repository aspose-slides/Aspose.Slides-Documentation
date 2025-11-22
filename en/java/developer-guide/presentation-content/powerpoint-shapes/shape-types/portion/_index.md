---
title: Manage Text Portions in Presentations Using Java
linktitle: Text Portion
type: docs
weight: 70
url: /java/portion/
keywords:
- text portion
- text part
- text coordinates
- text position
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Learn how to manage text portions in PowerPoint presentations using Aspose.Slides for Java, boosting performance and customization."
---

## **Get Position Coordinates of Portion**
[**getCoordinates()**](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--) method has been added to [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IPortion) and [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) class which allows retrieving the coordinates of the beginning of the portion.

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
