---
title: Obtener los límites de los párrafos de presentaciones en Android
linktitle: Límites de párrafo
type: docs
weight: 43
url: /es/androidjava/paragraph-bounds/
keywords:
- límites de párrafo
- coordenada de párrafo
- tamaño de párrafo
- marco de texto
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Aprenda cómo obtener los límites de los párrafos en Aspose.Slides para Android mediante Java para optimizar la posición del texto en presentaciones de PowerPoint."
---
## **Visión general**

Este artículo explica cómo obtener los límites, el tamaño y las coordenadas de los párrafos en Aspose.Slides. Muestra cómo recuperar un rectángulo de párrafo de un [ITextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/) usando [IParagraph.getRect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IParagraph#getRect--), cómo obtener las coordenadas del párrafo dentro de un marco de texto de celda de tabla, y destaca detalles importantes como las unidades de medida, el efecto del ajuste de texto en los límites, la conversión a píxeles y los valores de formato de párrafo efectivos.

## **Obtener coordenadas rectangulares de un párrafo**

Utilice [IParagraph.getRect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IParagraph#getRect--) para obtener el rectángulo delimitador de un párrafo.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    android.graphics.RectF rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Obtener el tamaño de un párrafo dentro de un marco de texto de celda de tabla**

Para obtener el tamaño y las coordenadas de un [IParagraph](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraph/) en un marco de texto de celda de tabla, utilice [IParagraph.getRect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IParagraph#getRect--). El rectángulo devuelto es relativo al marco de texto de la celda de la tabla, por lo que debe añadir la posición de la tabla y el desplazamiento de la celda cuando necesite coordenadas a nivel de diapositiva.

El siguiente ejemplo obtiene los límites del párrafo dentro de una celda de tabla y dibuja rectángulos en la diapositiva para visualizar esos límites:

```java
Presentation presentation = new Presentation("source.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);
    ICell cell = table.getRows().get_Item(1).get_Item(1);

    double cellX = table.getX() + cell.getOffsetX();
    double cellY = table.getY() + cell.getOffsetY();

    for (IParagraph paragraph : cell.getTextFrame().getParagraphs())
    {
        if (paragraph.getText().isEmpty())
            continue;

        android.graphics.RectF paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.left + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.top + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width(),
                paragraphRectangle.height());

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿En qué unidades se miden las coordenadas del párrafo?**

Se miden en puntos, donde 1 pulgada equivale a 72 puntos. Esto se aplica a todas las coordenadas y dimensiones de la diapositiva.

**¿Afecta el ajuste de texto a los límites del párrafo?**

Sí. Si [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) está habilitado para el [ITextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/), el texto se ajusta para encajar en el ancho del área, lo que cambia los límites reales del párrafo.

**¿Se pueden mapear de forma fiable las coordenadas del párrafo a píxeles en la imagen exportada?**

Sí. Convierta puntos a píxeles usando esta fórmula: píxeles = puntos × (DPI / 72). El resultado depende del DPI seleccionado para el renderizado o la exportación.

**¿Cómo obtener los parámetros de formato de párrafo “efectivos”, teniendo en cuenta la herencia de estilos?**

Utilice la [estructura de datos de formato de párrafo efectivo](/slides/es/androidjava/shape-effective-properties/); devuelve los valores consolidados finales para sangrías, espaciado, ajuste, RTL y más.