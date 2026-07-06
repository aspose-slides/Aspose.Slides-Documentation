---
title: Obtener los límites de la porción de texto de presentaciones en Java
linktitle: Límites de la porción
type: docs
weight: 47
url: /es/java/portion-bounds/
keywords:
- límites de porción de texto
- porción de texto
- parte de texto
- coordenadas de texto
- posición de texto
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda cómo obtener los límites de la porción de texto en presentaciones de PowerPoint usando Aspose.Slides para Java."
---
## **Descripción general**

Una porción de texto representa un fragmento específico de texto dentro de un párrafo y le permite trabajar con ese fragmento de forma independiente del contenido circundante. En Aspose.Slides, las porciones pueden usarse cuando necesita obtener los límites de un fragmento de texto, aplicar formato solo a una parte de un párrafo o controlar el comportamiento del texto a un nivel más detallado.

Este artículo muestra cómo obtener el rectángulo delimitador de una porción mediante [IPortion.getRect](https://reference.aspose.com/slides/es/java/com.aspose.slides/IPortion#getRect--). También muestra cómo obtener las coordenadas del inicio de una porción mediante [IPortion.getCoordinates](https://reference.aspose.com/slides/es/java/com.aspose.slides/IPortion#getCoordinates--). Además, destaca escenarios comunes relacionados con porciones, como aplicar un hipervínculo a un único fragmento de texto, comprender cómo se resuelve el formato a través de la herencia de porción, párrafo, cuadro de texto y tema, y manejar casos en los que una fuente especificada no está disponible.

## **Obtener los límites de una porción de texto**

Use [IPortion.getRect](https://reference.aspose.com/slides/es/java/com.aspose.slides/IPortion#getRect--) para recuperar el rectángulo delimitador de una porción de texto:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Rectangle2D.Float rectangle = portion.getRect();
            System.out.println("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Obtener las coordenadas de una porción de texto**

Use [IPortion.getCoordinates](https://reference.aspose.com/slides/es/java/com.aspose.slides/IPortion#getCoordinates--) para recuperar las coordenadas del comienzo de una porción de texto:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Point2D.Float point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Puedo aplicar un hipervínculo solo a una parte del texto dentro de un solo párrafo?**

Sí, puedes [asignar un hipervínculo](/slides/es/java/manage-hyperlinks/) a una porción individual; solo ese fragmento será clicable, no todo el párrafo.

**¿Cómo funciona la herencia de estilo: qué anula una porción y qué se toma de un párrafo o cuadro de texto?**

Las propiedades a nivel de porción tienen la mayor precedencia. Si una propiedad no está establecida en el [IPortion](https://reference.aspose.com/slides/es/java/com.aspose.slides/iportion/), Aspose.Slides la toma del [IParagraph](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraph/). Si tampoco está establecida allí, Aspose.Slides usa el estilo del [ITextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/) o del [theme](https://reference.aspose.com/slides/es/java/com.aspose.slides/theme/).

**¿Qué ocurre si la fuente especificada para una porción no está disponible en la máquina o servidor de destino?**

Se aplican las [reglas de sustitución de fuentes](/slides/es/java/font-selection-sequence/). El texto puede reorganizarse: las métricas, la separación silábica y el ancho pueden cambiar, lo que es importante para un posicionamiento preciso.

**¿Puedo establecer la transparencia o un degradado de relleno de texto específico de una porción independientemente del resto del párrafo?**

Sí, el color de texto, el relleno y la transparencia a nivel de [IPortion](https://reference.aspose.com/slides/es/java/com.aspose.slides/iportion/) pueden ser diferentes de los fragmentos adyacentes.