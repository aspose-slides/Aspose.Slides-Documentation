---
title: Obtener límites de párrafo de presentaciones en JavaScript
linktitle: Límites de párrafo
type: docs
weight: 43
url: /es/nodejs-java/paragraph-bounds/
keywords:
- límites de párrafo
- coordenada de párrafo
- tamaño de párrafo
- marco de texto
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a recuperar los límites de los párrafos en Aspose.Slides para Node.js mediante Java para optimizar la posición del texto en presentaciones de PowerPoint."
---
## **Descripción general**

Este artículo explica cómo obtener los límites, el tamaño y las coordenadas de los párrafos en Aspose.Slides. Muestra cómo recuperar un rectángulo de párrafo de un [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/) mediante [Paragraph.getRect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/getrect/), cómo obtener las coordenadas del párrafo dentro del cuadro de texto de una celda de tabla y destaca detalles importantes como unidades de medida, el efecto del ajuste de texto en los límites, la conversión a píxeles y los valores de formato de párrafo efectivos.

## **Obtener coordenadas rectangulares de un párrafo**

Use [Paragraph.getRect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/getrect/) para obtener el rectángulo delimitador de un párrafo.

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    const rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Obtener el tamaño de un párrafo dentro de un TextFrame de celda de tabla**

Para obtener el tamaño y las coordenadas de un [Paragraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/) en el cuadro de texto de una celda de tabla, use [Paragraph.getRect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/getrect/). El rectángulo devuelto es relativo al TextFrame de la celda de tabla, por lo que debe añadir la posición de la tabla y el desplazamiento de la celda cuando necesite coordenadas a nivel de diapositiva.

El siguiente ejemplo obtiene los límites del párrafo dentro de una celda de tabla y dibuja rectángulos en la diapositiva para visualizar esos límites:

```javascript
const presentation = new aspose.slides.Presentation("source.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);
    const cell = table.getRows().get_Item(1).get_Item(1);

    const cellX = table.getX() + cell.getOffsetX();
    const cellY = table.getY() + cell.getOffsetY();
    const paragraphs = cell.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        if (paragraph.getText() === "") {
            continue;
        }

        const paragraphRectangle = paragraph.getRect();
        const paragraphRectangleX = paragraphRectangle.x + cellX;
        const paragraphRectangleY = paragraphRectangle.y + cellY;
        const paragraphRectangleWidth = paragraphRectangle.width;
        const paragraphRectangleHeight = paragraphRectangle.height;

        const paragraphBoundsShape = slide.getShapes().addAutoShape(
            aspose.slides.ShapeType.Rectangle,
            java.newFloat(paragraphRectangleX),
            java.newFloat(paragraphRectangleY),
            java.newFloat(paragraphRectangleWidth),
            java.newFloat(paragraphRectangleHeight));

        paragraphBoundsShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**¿En qué unidades se miden las coordenadas del párrafo?**

Se miden en puntos, donde 1 pulgada equivale a 72 puntos. Esto se aplica a todas las coordenadas y dimensiones en la diapositiva.

**¿Afecta el ajuste de texto a los límites de un párrafo?**

Sí. Si [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframeformat/setwraptext/) está habilitado para el [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/), el texto se ajusta para encajar en el ancho del área, lo que cambia los límites reales del párrafo.

**¿Se pueden mapear de forma fiable las coordenadas del párrafo a píxeles en la imagen exportada?**

Sí. Convierta los puntos a píxeles usando esta fórmula: píxeles = puntos × (DPI / 72). El resultado depende del DPI seleccionado para el renderizado o la exportación.

**¿Cómo obtener los parámetros de formato de párrafo “efectivos”, teniendo en cuenta la herencia de estilos?**

Utilice la [effective paragraph formatting data structure](/slides/es/nodejs-java/shape-effective-properties/); devuelve los valores finales consolidados de sangrías, espaciado, ajuste, RTL y más.