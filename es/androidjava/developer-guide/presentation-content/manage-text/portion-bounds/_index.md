---
title: Obtener los límites de la porción de texto de presentaciones en Android
linktitle: Límites de la porción
type: docs
weight: 47
url: /es/androidjava/portion-bounds/
keywords:
- límites de la porción de texto
- porción de texto
- parte de texto
- coordenadas de texto
- posición de texto
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Aprenda cómo obtener los límites de la porción de texto en presentaciones de PowerPoint usando Aspose.Slides para Android mediante Java."
---
## **Visión general**

Una porción de texto representa un fragmento específico de texto dentro de un párrafo y permite trabajar con ese fragmento de forma independiente del contenido circundante. En Aspose.Slides, las porciones pueden usarse cuando necesitas obtener los límites de un fragmento de texto, aplicar formato solo a una parte de un párrafo o controlar el comportamiento del texto a un nivel más detallado.

Este artículo muestra cómo obtener el rectángulo delimitador de una porción utilizando [IPortion.getRect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPortion#getRect--). También muestra cómo obtener las coordenadas del comienzo de una porción mediante [IPortion.getCoordinates](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPortion#getCoordinates--). Además, destaca escenarios comunes relacionados con las porciones, como aplicar un hipervínculo a un único fragmento de texto, comprender cómo se resuelve el formato a través de la herencia de porción, párrafo, marco de texto y tema, y manejar casos en los que una fuente especificada no está disponible.

## **Obtener los límites de una porción de texto**

Utiliza [IPortion.getRect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPortion#getRect--) para recuperar el rectángulo delimitador de una porción de texto:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            android.graphics.RectF rectangle = portion.getRect();
            System.out.println("X = " + rectangle.left + "; Y = " + rectangle.top + "; Width = " + rectangle.width() + "; Height = " + rectangle.height());
        }
    }
} finally {
    presentation.dispose();
}
```

## **Obtener las coordenadas de una porción de texto**

Utiliza [IPortion.getCoordinates](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPortion#getCoordinates--) para recuperar las coordenadas del comienzo de una porción de texto:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            PointF point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Puedo aplicar un hipervínculo solo a una parte del texto dentro de un único párrafo?**

Sí, puedes [asignar un hipervínculo](/slides/es/androidjava/manage-hyperlinks/) a una porción individual; solo ese fragmento será clicable, no todo el párrafo.

**¿Cómo funciona la herencia de estilos: qué sobrescribe una porción y qué se toma de un párrafo o marco de texto?**

Las propiedades a nivel de porción tienen la mayor precedencia. Si una propiedad no está establecida en el [IPortion](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iportion/), Aspose.Slides la toma del [IParagraph](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraph/). Si tampoco está establecida allí, Aspose.Slides usa el estilo del [ITextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/) o del [theme](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/theme/).

**¿Qué ocurre si la fuente especificada para una porción no está presente en la máquina o servidor de destino?**

Se aplican las [reglas de sustitución de fuentes](/slides/es/androidjava/font-selection-sequence/). El texto puede refluír: las métricas, la guionación y el ancho pueden cambiar, lo que es importante para una posición precisa.

**¿Puedo establecer transparencia de relleno de texto o un degradado específicos de la porción de forma independiente del resto del párrafo?**

Sí, el color del texto, el relleno y la transparencia a nivel de [IPortion] pueden diferir de los fragmentos vecinos.