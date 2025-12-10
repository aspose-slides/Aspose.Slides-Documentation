---
title: Administrar porciones de texto en presentaciones usando Java
linktitle: Porción de texto
type: docs
weight: 70
url: /es/java/portion/
keywords:
- porción de texto
- parte de texto
- coordenadas de texto
- posición de texto
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda cómo administrar porciones de texto en presentaciones de PowerPoint usando Aspose.Slides para Java, mejorando el rendimiento y la personalización."
---

## **Obtener coordenadas de una porción de texto**
El método [**getCoordinates()**](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--) ha sido añadido a las clases [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IPortion) y [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) que permiten obtener las coordenadas del inicio de la porción.
```java
// Instanciar la clase Presentation que representa el PPTX
Presentation pres = new Presentation();
try {
    // Reformar el contexto de la presentación
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


## **Preguntas frecuentes**

**¿Puedo aplicar un hipervínculo solo a una parte del texto dentro de un solo párrafo?**

Sí, puedes [asignar un hipervínculo](/slides/es/java/manage-hyperlinks/) a una porción individual; solo ese fragmento será clicable, no todo el párrafo.

**¿Cómo funciona la herencia de estilos: qué sobrescribe una Porción y qué se hereda del Párrafo/TextFrame?**

Las propiedades a nivel de Porción tienen la mayor precedencia. Si una propiedad no está establecida en la [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/), el motor la toma del [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/); si tampoco está establecida allí, la toma del [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) o del estilo del [theme](https://reference.aspose.com/slides/java/com.aspose.slides/theme/).

**¿Qué ocurre si la fuente especificada para una Porción no está disponible en la máquina/servidor de destino?**

Se aplican las [reglas de sustitución de fuentes](/slides/es/java/font-selection-sequence/). El texto puede refluenciar: métricas, guiones y anchura pueden cambiar, lo que afecta al posicionamiento preciso.

**¿Puedo establecer una transparencia o degradado de relleno de texto específico de una Porción de forma independiente al resto del párrafo?**

Sí, el color de texto, el relleno y la transparencia a nivel de [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) pueden ser diferentes de los fragmentos vecinos.