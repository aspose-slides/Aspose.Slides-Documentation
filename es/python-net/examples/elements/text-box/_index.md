---
title: Caja de texto
type: docs
weight: 40
url: /es/python-net/examples/elements/text-box/
keywords:
- caja de texto
- agregar caja de texto
- acceder a caja de texto
- eliminar caja de texto
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Crear y dar formato a cajas de texto en Python con Aspose.Slides: establecer fuentes, alineación, ajuste de texto, autoajuste y enlaces para pulir diapositivas para PowerPoint y OpenDocument."
---
En Aspose.Slides, un **cuadro de texto** está representado por un `AutoShape`. Prácticamente cualquier forma puede contener texto, pero un cuadro de texto típico no tiene relleno ni borde y solo muestra texto.

Esta guía explica cómo agregar, acceder y eliminar cuadros de texto mediante código.

## **Agregar un Cuadro de Texto**

Un cuadro de texto es simplemente un `AutoShape` sin relleno ni borde y con texto formateado. Así se crea uno:

```py
def add_text_box():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Crear una forma rectangular (por defecto con relleno, borde y sin texto).
        text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 75, 150, 100)

        # Eliminar el relleno y el borde para que parezca una caja de texto típica.
        text_box.fill_format.fill_type = slides.FillType.NO_FILL
        text_box.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        # Establecer formato de texto.
        paragraph_format = text_box.text_frame.paragraphs[0].paragraph_format
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = drawing.Color.black

        # Asignar el contenido de texto real.
        text_box.text_frame.text = "Some text..."

        presentation.save("text_box.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Nota:** Cualquier `AutoShape` que contenga un `TextFrame` no vacío puede funcionar como un cuadro de texto.

## **Acceder a Cuadros de Texto por Contenido**

Para encontrar todos los cuadros de texto que contengan una palabra clave específica (p. ej., "Slide"), recorre las formas y verifica su texto:

```py
def access_text_box():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        for shape in slide.shapes:
            # Sólo AutoShapes pueden contener texto editable.
            if isinstance(shape, slides.AutoShape):
                if "Slide" in shape.text_frame.text:
                    # Hacer algo con la caja de texto coincidente.
                    pass
```

## **Eliminar Cuadros de Texto por Contenido**

Este ejemplo encuentra y elimina todos los cuadros de texto en la primera diapositiva que contienen una palabra clave específica:

```py
def remove_text_boxes():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        # Encontrar las formas a eliminar que son AutoShapes que contienen la palabra "Slide".
        shapes_to_remove = [
            shape for shape in slide.shapes
            if isinstance(shape, slides.AutoShape) and "Slide" in shape.text_frame.text
        ]

        # Eliminar cada forma coincidente de la diapositiva.
        for shape in shapes_to_remove:
            slide.shapes.remove(shape)

        presentation.save("text_boxes_removed.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Consejo:** Siempre crea una copia de la colección de formas antes de modificarla durante la iteración para evitar errores de modificación de la colección.