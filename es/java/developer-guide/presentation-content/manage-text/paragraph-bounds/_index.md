---
title: Obtener los límites de los párrafos de presentaciones en Java
linktitle: Límites de párrafos
type: docs
weight: 43
url: /es/java/paragraph-bounds/
keywords:
- límites de párrafo
- coordenada de párrafo
- tamaño de párrafo
- marco de texto
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda a obtener los límites de los párrafos en Aspose.Slides para Java y optimizar la posición del texto en presentaciones de PowerPoint."
---
## **Visión general**

Este artículo explica cómo obtener los límites, el tamaño y las coordenadas de los párrafos en Aspose.Slides. Muestra cómo obtener un rectángulo de párrafo a partir de un [ITextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/) utilizando [IParagraph.getRect](https://reference.aspose.com/slides/es/java/com.aspose.slides/IParagraph#getRect--), cómo obtener las coordenadas del párrafo dentro del marco de texto de una celda de tabla y destaca detalles importantes como unidades de medida, el efecto del ajuste de texto en los límites, la conversión a píxeles y los valores de formato de párrafo efectivos.

## **Obtener coordenadas rectangulares de un párrafo**

Utilice [IParagraph.getRect](https://reference.aspose.com/slides/es/java/com.aspose.slides/IParagraph#getRect--) para obtener el rectángulo delimitador de un párrafo.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    java.awt.geom.Rectangle2D.Float rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Obtener el tamaño de un párrafo dentro de un marco de texto de celda de tabla**

Para obtener el tamaño y las coordenadas de un [IParagraph](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraph/) en el marco de texto de una celda de tabla, utilice [IParagraph.getRect](https://reference.aspose.com/slides/es/java/com.aspose.slides/IParagraph#getRect--). El rectángulo devuelto es relativo al marco de texto de la celda de tabla, por lo que debe añadir la posición de la tabla y el desplazamiento de la celda cuando necesite coordenadas a nivel de diapositiva.

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

        java.awt.geom.Rectangle2D.Float paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.x + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.y + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width,
                paragraphRectangle.height);

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

**¿En qué unidades se miden las coordenadas de los párrafos?**

Se miden en puntos, donde 1 pulgada equivale a 72 puntos. Esto se aplica a todas las coordenadas y dimensiones de la diapositiva.

**¿El ajuste de texto afecta a los límites de un párrafo?**

Sí. Si [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) está habilitado para el [ITextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/), el texto se divide para ajustarse al ancho del área, lo que cambia los límites reales del párrafo.

**¿Se pueden mapear de forma fiable las coordenadas de los párrafos a píxeles en la imagen exportada?**

Sí. Convierta puntos a píxeles usando esta fórmula: píxeles = puntos × (DPI / 72). El resultado depende del DPI elegido para el renderizado o la exportación.

**¿Cómo obtener los parámetros de formato de párrafo "efectivo", teniendo en cuenta la herencia de estilo?**

Utilice la [estructura de datos de formato de párrafo efectivo](/slides/es/java/shape-effective-properties/); devuelve los valores finales consolidados para sangrías, espaciado, ajuste, RTL y más.