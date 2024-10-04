---
title: Párrafo
type: docs
weight: 60
url: /python-net/paragraph/
keywords: "Párrafo, porción, coordenadas de párrafo, coordenadas de porción, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Párrafo y porción en la presentación de PowerPoint en Python"
---

## **Obtener Coordenadas de Párrafo y Porción en TextFrame**
Usando Aspose.Slides para Python a través de .NET, los desarrolladores ahora pueden obtener las coordenadas rectangulares para Párrafos dentro de la colección de párrafos de TextFrame. También permite obtener las coordenadas de la porción dentro de la colección de porciones de un párrafo. En este tema, vamos a demostrar con la ayuda de un ejemplo cómo obtener las coordenadas rectangulares para un párrafo junto con la posición de la porción dentro de un párrafo.

## **Obtener Coordenadas Rectangulares de Párrafo**
Se ha añadido el nuevo método **GetRect()**. Permite obtener el rectángulo de límites del párrafo.

```py
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo de presentación
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **Obtener tamaño de párrafo y porción dentro del marco de texto de la celda de tabla** ##

Para obtener el tamaño y las coordenadas de [Porción](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) o [Párrafo](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) en el marco de texto de una celda de tabla, puedes usar los métodos [IPortion.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) y [IParagraph.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/).

Este código de muestra demuestra la operación descrita:

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