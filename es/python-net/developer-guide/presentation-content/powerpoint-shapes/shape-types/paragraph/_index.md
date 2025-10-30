---
title: Obtener límites de párrafo de presentaciones en Python
linktitle: Párrafo
type: docs
weight: 60
url: /es/python-net/paragraph/
keywords:
- límites del párrafo
- límites de la porción de texto
- coordenada del párrafo
- coordenada de la porción
- tamaño del párrafo
- tamaño de la porción de texto
- marco de texto
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda cómo recuperar los límites de párrafo y de porción de texto en Aspose.Slides para Python mediante .NET para optimizar la posición del texto en presentaciones de PowerPoint y OpenDocument."
---

## **Obtener coordenadas de párrafo y porción en TextFrame**
Usando Aspose.Slides para Python mediante .NET, los desarrolladores ahora pueden obtener las coordenadas rectangulares de **Paragraph** dentro de la colección de párrafos de **TextFrame**. También permite obtener las coordenadas de la porción dentro de la colección de porciones de un párrafo. En este tema, demostraremos, con la ayuda de un ejemplo, cómo obtener las coordenadas rectangulares del párrafo junto con la posición de la porción dentro de un párrafo.

## **Obtener coordenadas rectangulares del párrafo**
El nuevo método **GetRect()** ha sido añadido. Permite obtener el rectángulo de límites del párrafo.

```py
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo de presentación
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **Obtener tamaño de párrafo y porción dentro del marco de texto de una celda de tabla** ##

Para obtener el tamaño y las coordenadas de la [Porción](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) o del [Párrafo](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) en el marco de texto de una celda de tabla, puede usar los métodos [IPortion.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) y [IParagraph.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/).

Este fragmento de código muestra la operación descrita:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "source.pptx") as pres:
    tbl = pres.slides[0].shapes[0]

    cell = tbl.rows[1][1]


    x = tbl.X + tbl.rows[1][1].offset_x
    y = tbl.Y + tbl.rows[1][1].offset_y

    for para in cell.text_frame.paragraphs:
        if para.text == "":
            continue

        rect = para.get_rect()
        shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                rect.x + x, rect.y + y, rect.width, rect.height)

        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        shape.line_format.fill_format.fill_type = slides.FillType.SOLID

        for portion in para.portions:
            if "0" in portion.text:
                rect = portion.get_rect()
                shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                        rect.x + x, rect.y + y, rect.width, rect.height)

                shape.fill_format.fill_type = slides.FillType.NO_FILL
```

## **FAQ**

**¿En qué unidades se devuelven las coordenadas de un párrafo y sus porciones de texto?**

En puntos, donde 1 pulgada = 72 puntos. Esto se aplica a todas las coordenadas y dimensiones en la diapositiva.

**¿El ajuste de línea afecta los límites de un párrafo?**

Sí. Si el [ajuste de línea](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) está habilitado en el [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), el texto se ajusta para caber en el ancho del área, lo que cambia los límites reales del párrafo.

**¿Se pueden mapear de forma confiable las coordenadas del párrafo a píxeles en la imagen exportada?**

Sí. Convierta puntos a píxeles usando: píxeles = puntos × (DPI / 72). El resultado depende del DPI elegido para el renderizado/exportación.

**¿Cómo obtener los parámetros de formato “efectivo” del párrafo, teniendo en cuenta la herencia de estilos?**

Utilice la [estructura de datos de formato de párrafo efectivo](/slides/es/python-net/shape-effective-properties/); devuelve los valores consolidados finales para sangrías, espaciado, ajuste, RTL y más.