---
title: Administrar porciones de texto en presentaciones en Android
linktitle: Porción de texto
type: docs
weight: 70
url: /es/androidjava/portion/
keywords:
- porción de texto
- fragmento de texto
- coordenadas de texto
- posición de texto
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Aprenda cómo administrar porciones de texto en presentaciones de PowerPoint usando Aspose.Slides para Android vía Java, mejorando el rendimiento y la personalización."
---

## **Obtener coordenadas de una porción de texto**
[**getCoordinates()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getCoordinates--) se ha añadido a las clases [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IPortion) y [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) que permiten recuperar las coordenadas del inicio de la porción.
```java
// Instanciar la clase Presentation que representa el PPTX
Presentation pres = new Presentation();
try {
    // Reconfigurar el contexto de la presentación
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


## **FAQ**

**¿Puedo aplicar un hipervínculo solo a una parte del texto dentro de un mismo párrafo?**

Sí, puedes [asignar un hipervínculo](/slides/es/androidjava/manage-hyperlinks/) a una porción individual; solo ese fragmento será clicable, no todo el párrafo.

**¿Cómo funciona la herencia de estilos: qué sobrescribe una Porción y qué se toma del Párrafo/TextFrame?**

Las propiedades a nivel de Porción tienen la mayor precedencia. Si una propiedad no está establecida en la [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/), el motor la toma del [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/); si tampoco está establecida allí, del [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) o del estilo del [theme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/theme/).

**¿Qué ocurre si la fuente especificada para una Porción no está presente en la máquina/servidor de destino?**

Se aplican las [reglas de sustitución de fuentes](/slides/es/androidjava/font-selection-sequence/). El texto puede reorganizarse: las métricas, el guionado y el ancho pueden cambiar, lo que importa para un posicionamiento preciso.

**¿Puedo establecer una transparencia o degradado de relleno de texto específico para una Porción independiente del resto del párrafo?**

Sí, el color del texto, el relleno y la transparencia a nivel de [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) pueden diferir de los fragmentos vecinos.