---
title: Portion
type: docs
weight: 70
url: /de/java/portion/
---

## **Positionkoordinaten der Portion abrufen**
[**getCoordinates()**](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--) Methode wurde zur [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IPortion) und [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) Klasse hinzugefügt, die es ermöglicht, die Koordinaten des Beginns der Portion abzurufen.

```java
// Instanziere die Präsentation-Klasse, die die PPTX repräsentiert
Presentation pres = new Presentation();
try {
    // Umformung des Kontexts der Präsentation
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