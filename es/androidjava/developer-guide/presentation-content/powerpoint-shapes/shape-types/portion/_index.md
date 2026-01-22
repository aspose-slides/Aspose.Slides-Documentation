---
title: Administrar porciones de texto en presentaciones en Android
linktitle: Porción de texto
type: docs
weight: 70
url: /es/androidjava/portion/
keywords:
- porción de texto
- parte de texto
- coordenadas de texto
- posición de texto
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Aprenda a gestionar porciones de texto en presentaciones de PowerPoint usando Aspose.Slides para Android mediante Java, mejorando el rendimiento y la personalización."
---

## **Obtener coordenadas de una porción de texto**
[**getCoordinates()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getCoordinates--) se ha añadido a las clases [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) y [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) y permite obtener las coordenadas del inicio de la porción.
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

**¿Puedo aplicar un hipervínculo solo a una parte del texto dentro de un mismo párrafo?**

Sí, puedes [assign a hyperlink](/slides/es/androidjava/manage-hyperlinks/) a una porción individual; solo ese fragmento será clicable, no todo el párrafo.

**¿Cómo funciona la herencia de estilos: qué sobrescribe una Porción y qué se toma del Párrafo/Marco de texto?**

Las propiedades a nivel de [Portion] tienen la mayor precedencia. Si una propiedad no está establecida en la [Portion], el motor la toma del [Paragraph]; si tampoco está establecida allí, la toma del [TextFrame] o del estilo del [theme].

**¿Qué ocurre si la fuente especificada para una Porción falta en la máquina/servidor de destino?**

Se aplican las [Font substitution rules](/slides/es/androidjava/font-selection-sequence/). El texto puede refluír: las métricas, la división silábica y el ancho pueden cambiar, lo que afecta a una posición precisa.

**¿Puedo establecer una transparencia o degradado de relleno de texto específico de una Porción independientemente del resto del párrafo?**

Sí, el color, el relleno y la transparencia del texto a nivel de [Portion] pueden diferir de los fragmentos vecinos.