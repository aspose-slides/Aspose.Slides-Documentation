---
title: Obtener los límites de los párrafos de presentaciones en Python mediante Java
linktitle: Límites de párrafo
type: docs
weight: 43
url: /es/python-java/paragraph-bounds/
keywords:
- límites de párrafo
- coordenada de párrafo
- tamaño de párrafo
- marco de texto
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Aprenda a obtener los límites de los párrafos en Aspose.Slides para Python mediante Java y optimizar la posición del texto en presentaciones de PowerPoint."
---
## **Visión general**

Este artículo explica cómo obtener los límites, el tamaño y las coordenadas de los párrafos en Aspose.Slides. Muestra cómo obtener un rectángulo de párrafo a partir de un [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/) utilizando [Paragraph.getRect](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraph/#getRect), cómo obtener las coordenadas del párrafo dentro del marco de texto de una celda de tabla y destaca detalles importantes como las unidades de medida, el efecto del ajuste de texto en los límites, la conversión a píxeles y los valores de formato de párrafo efectivo.

## **Obtener coordenadas rectangulares de un párrafo**

Utiliza [Paragraph.getRect](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraph/#getRect) para obtener el rectángulo delimitador de un párrafo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    rectangle = paragraph.getRect()
finally:
    presentation.dispose()
```

## **Obtener el tamaño de un párrafo dentro del marco de texto de una celda de tabla**

Para obtener el tamaño y las coordenadas de un [Paragraph](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraph/) en un marco de texto de una celda de tabla, usa [Paragraph.getRect](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraph/#getRect). El rectángulo devuelto es relativo al marco de texto de la celda, por lo que debes añadir la posición de la tabla y el desplazamiento de la celda cuando necesites coordenadas a nivel de diapositiva.

El siguiente ejemplo obtiene los límites del párrafo dentro de una celda de tabla y dibuja rectángulos en la diapositiva para visualizar esos límites:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation("source.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)
    cell = table.getRows().get_Item(1).get_Item(1)

    cell_x = table.getX() + cell.getOffsetX()
    cell_y = table.getY() + cell.getOffsetY()

    for paragraph in cell.getTextFrame().getParagraphs():
        if not paragraph.getText():
            continue

        paragraph_rectangle = paragraph.getRect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, paragraph_rectangle_x, paragraph_rectangle_y, paragraph_rectangle.width, paragraph_rectangle.height)

        paragraph_bounds_shape.getFillFormat().setFillType(FillType.NoFill)
        paragraph_bounds_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
        paragraph_bounds_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿En qué unidades se miden las coordenadas del párrafo?**

Se miden en puntos, donde 1 pulgada equivale a 72 puntos. Esto se aplica a todas las coordenadas y dimensiones de la diapositiva.

**¿El ajuste de texto afecta a los límites de un párrafo?**

Sí. Si [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setWrapText) está habilitado para el [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/), el texto se divide para ajustarse al ancho del área, lo que cambia los límites reales del párrafo.

**¿Se pueden mapear de forma fiable las coordenadas del párrafo a píxeles en la imagen exportada?**

Sí. Convierte puntos a píxeles usando esta fórmula: píxeles = puntos x (DPI / 72). El resultado depende del DPI elegido para el renderizado o la exportación.

**¿Cómo obtener los parámetros de formato de párrafo “efectivo”, teniendo en cuenta la herencia de estilos?**

Utiliza la [estructura de datos de formato de párrafo efectivo](/slides/es/python-java/shape-effective-properties/); devuelve los valores consolidados finales para sangrías, espaciado, ajuste, RTL y más.