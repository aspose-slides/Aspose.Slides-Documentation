---
title: Obtener los límites de los párrafos de presentaciones en PHP
linktitle: Límites de párrafo
type: docs
weight: 43
url: /es/php-java/paragraph-bounds/
keywords:
- límites de párrafo
- coordenada de párrafo
- tamaño de párrafo
- marco de texto
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda cómo obtener los límites de los párrafos en Aspose.Slides para PHP vía Java para optimizar la posición del texto en presentaciones de PowerPoint."
---
## **Visión general**

Este artículo explica cómo obtener los límites, el tamaño y las coordenadas de los párrafos en Aspose.Slides. Muestra cómo recuperar un rectángulo de párrafo de un [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/) usando [Paragraph::getRect](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/getrect/), cómo obtener las coordenadas del párrafo dentro del marco de texto de una celda de tabla, y destaca detalles importantes como unidades de medida, el efecto del ajuste de texto en los límites, la conversión a píxeles y los valores de formato de párrafo efectivos.

## **Obtener coordenadas rectangulares de un párrafo**

Utilice [Paragraph::getRect](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/getrect/) para obtener el rectángulo delimitador de un párrafo.

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $rectangle = $paragraph->getRect();
} finally {
    $presentation->dispose();
}
```

## **Obtener el tamaño de un párrafo dentro de un TextFrame de celda de tabla**

Para obtener el tamaño y las coordenadas de un [Paragraph](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/) en un marco de texto de una celda de tabla, utilice [Paragraph::getRect](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/getrect/). El rectángulo devuelto es relativo al marco de texto de la celda de tabla, por lo que debe añadir la posición de la tabla y el desplazamiento de la celda cuando necesite coordenadas a nivel de diapositiva.

El siguiente ejemplo obtiene los límites del párrafo dentro de una celda de tabla y dibuja rectángulos en la diapositiva para visualizar esos límites:

```php
$presentation = new Presentation("source.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);
    $cell = $table->getRows()->get_Item(1)->get_Item(1);

    $cellX = java_values($table->getX()) + java_values($cell->getOffsetX());
    $cellY = java_values($table->getY()) + java_values($cell->getOffsetY());

    foreach ($cell->getTextFrame()->getParagraphs() as $paragraph) {
        if ($paragraph->getText() == "") {
            continue;
        }

        $paragraphRectangle = $paragraph->getRect();
        $paragraphRectangleX = java_values($paragraphRectangle->getX()) + $cellX;
        $paragraphRectangleY = java_values($paragraphRectangle->getY()) + $cellY;
        $paragraphRectangleWidth = java_values($paragraphRectangle->getWidth());
        $paragraphRectangleHeight = java_values($paragraphRectangle->getHeight());

        $paragraphBoundsShape = $slide->getShapes()->addAutoShape(
            ShapeType::Rectangle,
            $paragraphRectangleX,
            $paragraphRectangleY,
            $paragraphRectangleWidth,
            $paragraphRectangleHeight
        );

        $paragraphBoundsShape->getFillFormat()->setFillType(FillType::NoFill);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Preguntas frecuentes**

**¿En qué unidades se miden las coordenadas del párrafo?**

Se miden en puntos, donde 1 pulgada equivale a 72 puntos. Esto se aplica a todas las coordenadas y dimensiones de la diapositiva.

**¿Afecta el ajuste de texto a los límites de un párrafo?**

Sí. Si [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/setwraptext/) está habilitado para el [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/), el texto se ajusta para encajar al ancho del área, lo que modifica los límites reales del párrafo.

**¿Se pueden mapear de forma fiable las coordenadas del párrafo a píxeles en la imagen exportada?**

Sí. Convierta los puntos a píxeles usando esta fórmula: píxeles = puntos × (DPI / 72). El resultado depende del DPI seleccionado para el renderizado o la exportación.

**¿Cómo obtener los parámetros de formato de párrafo "efectivo", teniendo en cuenta la herencia de estilos?**

Utilice la [estructura de datos de formato de párrafo efectivo](/slides/es/php-java/shape-effective-properties/); devuelve los valores consolidados finales para sangrías, espaciado, ajuste, RTL y más.