---
title: Obtener los límites de los párrafos en presentaciones con Python
linktitle: Límites de párrafo
type: docs
weight: 43
url: /es/python-net/paragraph-bounds/
keywords:
- límites de párrafo
- coordenada de párrafo
- tamaño de párrafo
- marco de texto
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda a obtener los límites de los párrafos en Aspose.Slides para Python a través de .NET y optimizar la ubicación del texto en presentaciones de PowerPoint y OpenDocument."
---
## **Descripción general**

Este artículo explica cómo obtener los límites, el tamaño y las coordenadas de los párrafos en Aspose.Slides. Muestra cómo recuperar un rectángulo de párrafo a partir de un [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/) mediante [Paragraph.get_rect](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/get_rect/), cómo obtener las coordenadas del párrafo dentro de un TextFrame de celda de tabla, y destaca detalles importantes como las unidades de medida, el efecto del ajuste de texto sobre los límites, la conversión a píxeles y los valores de formato de párrafo “efectivo”.

## **Obtener coordenadas rectangulares de un párrafo**

Utilice [Paragraph.get_rect](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/get_rect/) para obtener el rectángulo delimitador de un párrafo.

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    paragraph = shape.text_frame.paragraphs[0]
    rectangle = paragraph.get_rect()
```

## **Obtener el tamaño de un párrafo dentro de un TextFrame de celda de tabla**

Para obtener el tamaño y las coordenadas de un [Paragraph](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/) en un TextFrame de celda de tabla, utilice [Paragraph.get_rect](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/get_rect/). El rectángulo devuelto es relativo al TextFrame de la celda de tabla, por lo que debe añadir la posición de la tabla y el desplazamiento de la celda cuando necesite coordenadas a nivel de diapositiva.

El siguiente ejemplo obtiene los límites del párrafo dentro de una celda de tabla y dibuja rectángulos en la diapositiva para visualizar esos límites:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("source.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]
    cell = table.rows[1][1]

    cell_x = table.x + cell.offset_x
    cell_y = table.y + cell.offset_y

    for paragraph in cell.text_frame.paragraphs:
        if paragraph.text == "":
            continue

        paragraph_rectangle = paragraph.get_rect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.shapes.add_auto_shape(
            slides.ShapeType.RECTANGLE,
            paragraph_rectangle_x,
            paragraph_rectangle_y,
            paragraph_rectangle.width,
            paragraph_rectangle.height)

        paragraph_bounds_shape.fill_format.fill_type = slides.FillType.NO_FILL
        paragraph_bounds_shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        paragraph_bounds_shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿En qué unidades se miden las coordenadas del párrafo?**

Se miden en puntos, donde 1 pulgada equivale a 72 puntos. Esto se aplica a todas las coordenadas y dimensiones de la diapositiva.

**¿Afecta el ajuste de texto a los límites del párrafo?**

Sí. Si [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframeformat/wrap_text/) está habilitado para el [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/), el texto se rompe para ajustarse al ancho del área, lo que cambia los límites reales del párrafo.

**¿Pueden mapearse de forma fiable las coordenadas del párrafo a píxeles en la imagen exportada?**

Sí. Convierta puntos a píxeles usando la fórmula: píxeles = puntos × (DPI / 72). El resultado depende del DPI elegido para el renderizado o la exportación.

**¿Cómo obtengo los parámetros de formato de párrafo “efectivo”, teniendo en cuenta la herencia de estilos?**

Utilice la [estructura de datos de formato de párrafo efectivo](/slides/es/python-net/shape-effective-properties/); devuelve los valores finales consolidados para sangrías, espaciado, ajuste, RTL y más.