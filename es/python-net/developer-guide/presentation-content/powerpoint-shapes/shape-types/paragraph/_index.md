---
title: Obtener los límites del párrafo de presentaciones en Python
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
description: "Aprenda cómo obtener los límites del párrafo y de la porción de texto en Aspose.Slides para Python mediante .NET para optimizar la posición del texto en presentaciones de PowerPoint y OpenDocument."
---

## **Obtener coordenadas del párrafo y la porción en TextFrame**
Usando Aspose.Slides for Python via .NET, los desarrolladores pueden ahora obtener las coordenadas rectangulares para **Paragraph** dentro de la colección de párrafos de **TextFrame**. También permite obtener las coordenadas de la porción dentro de la colección de porciones de un párrafo. En este tema, demostraremos con un ejemplo cómo obtener las coordenadas rectangulares del párrafo junto con la posición de la porción dentro de un párrafo.

## **Obtener coordenadas rectangulares del párrafo**
El nuevo método **GetRect()** ha sido añadido. Permite obtener el rectángulo de los límites del párrafo.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **Obtener tamaño del párrafo y la porción dentro del marco de texto de una celda de tabla** ##

Para obtener el tamaño y las coordenadas del [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) o del [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) en un marco de texto de celda de tabla, puede usar los métodos [IPortion.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) y [IParagraph.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/).

Este código de ejemplo demuestra la operación descrita:

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

## **Preguntas frecuentes**

**¿En qué unidades se devuelven las coordenadas de un párrafo y de las porciones de texto?**

En puntos, donde 1 pulgada = 72 puntos. Esto se aplica a todas las coordenadas y dimensiones en la diapositiva.

**¿Afecta el ajuste de texto a los límites del párrafo?**

Sí. Si el [ajuste](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) está habilitado en el [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), el texto se divide para adaptarse al ancho del área, lo que cambia los límites reales del párrafo.

**¿Se pueden mapear de forma fiable las coordenadas del párrafo a píxeles en la imagen exportada?**

Sí. Convierta puntos a píxeles usando: píxeles = puntos × (DPI / 72). El resultado depende del DPI elegido para el renderizado/exportación.

**¿Cómo obtener los parámetros de formato "efectivo" del párrafo, teniendo en cuenta la herencia de estilos?**

Utilice la [estructura de datos de formato de párrafo efectivo](/slides/es/python-net/shape-effective-properties/); devuelve los valores consolidados finales para sangrías, espaciado, ajuste, RTL y más.