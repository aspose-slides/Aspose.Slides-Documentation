---
title: Porción
type: docs
weight: 70
url: /es/androidjava/portion/
---

## **Obtener coordenadas de posición de la porción**
El método [**getCoordinates()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getCoordinates--) ha sido agregado a [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IPortion) y a la clase [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) que permite recuperar las coordenadas del inicio de la porción.

```java
// Instanciar la clase Presentation que representa el PPTX
Presentation pres = new Presentation();
try {
    // Reformulando el contexto de la presentación
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