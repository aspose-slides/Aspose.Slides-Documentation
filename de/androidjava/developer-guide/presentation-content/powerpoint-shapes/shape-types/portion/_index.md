---
title: Portion
type: docs
weight: 70
url: /de/androidjava/portion/
---

## **Position Koordinaten von Portion abrufen**
[**getCoordinates()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getCoordinates--) Methode wurde zur [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IPortion) und [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) Klasse hinzugefügt, die es ermöglicht, die Koordinaten des Anfangs der Portion abzurufen.

```java
// Instanziiere die Präsentationsklasse, die das PPTX repräsentiert
Presentation pres = new Presentation();
try {
    // Den Kontext der Präsentation umgestalten
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