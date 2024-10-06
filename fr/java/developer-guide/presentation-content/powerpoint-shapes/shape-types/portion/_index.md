---
title: Portion
type: docs
weight: 70
url: /java/portion/
---

## **Obtenir les coordonnées de position de la portion**
La méthode [**getCoordinates()**](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--) a été ajoutée à [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IPortion) et à la classe [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) qui permet de récupérer les coordonnées du début de la portion.

```java
// Instancier la classe Prseetation qui représente le PPTX
Presentation pres = new Presentation();
try {
    // Redéfinir le contexte de la présentation
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