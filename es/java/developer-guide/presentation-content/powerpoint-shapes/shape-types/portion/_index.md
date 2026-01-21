---
title: Gestionar porciones de texto en presentaciones con Java
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
description: "Aprenda a gestionar porciones de texto en presentaciones de PowerPoint utilizando Aspose.Slides para Java, mejorando el rendimiento y la personalización."
---

## **Obtener coordenadas de una porción de texto**
el método [**getCoordinates()**](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--) se ha añadido a las clases [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) y [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) que permiten obtener las coordenadas del comienzo de la porción.
```java
// Instanciar la clase Presentation que representa el PPTX
Presentation pres = new Presentation();
try {
    // Reformando el contexto de la presentación
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

**¿Puedo aplicar un hipervínculo solo a una parte del texto dentro de un único párrafo?**

Sí, puedes [asignar un hipervínculo](/slides/es/java/manage-hyperlinks/) a una porción individual; solo ese fragmento será clicable, no todo el párrafo.

**¿Cómo funciona la herencia de estilos: qué anula una Porción y qué se toma del Párrafo/TextFrame?**

Las propiedades a nivel de Porción tienen la mayor precedencia. Si una propiedad no está establecida en la [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/), el motor la toma del [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/); si tampoco está establecida allí, la toma del [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) o del estilo del [theme](https://reference.aspose.com/slides/java/com.aspose.slides/theme/).

**¿Qué ocurre si la fuente especificada para una Porción falta en la máquina/servidor de destino?**

Se aplican las [reglas de sustitución de fuentes](/slides/es/java/font-selection-sequence/). El texto puede redistribuirse: las métricas, la hyphenation y el ancho pueden cambiar, lo que es importante para un posicionamiento preciso.

**¿Puedo establecer la transparencia o el degradado de relleno de texto específico de una Porción independientemente del resto del párrafo?**

Sí, el color del texto, el relleno y la transparencia a nivel de [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) pueden ser diferentes de los fragmentos vecinos.