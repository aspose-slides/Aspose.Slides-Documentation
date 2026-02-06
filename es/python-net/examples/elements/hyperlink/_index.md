---
title: Hipervínculo
type: docs
weight: 130
url: /es/python-net/examples/elements/hyperlink/
keywords:
- hipervínculo
- añadir hipervínculo
- acceder al hipervínculo
- eliminar hipervínculo
- actualizar hipervínculo
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Añade, edita y elimina hipervínculos en Python con Aspose.Slides: texto de enlaces, formas, diapositivas, URL y correo electrónico; define destinos y acciones para PPT, PPTX y ODP."
---
Demuestra cómo añadir, acceder, eliminar y actualizar hipervínculos en formas usando **Aspose.Slides for Python via .NET**.

## **Añadir un hipervínculo**

Crea una forma rectangular con un hipervínculo que apunta a un sitio web externo.

```py
def add_hyperlink():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 50)
        shape.text_frame.text = "Aspose"

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com")

        presentation.save("hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **Acceder a un hipervínculo**

Lee la información del hipervínculo desde la porción de texto de una forma.

```py
def access_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        hyperlink = text_portion.portion_format.hyperlink_click
```

## **Eliminar un hipervínculo**

Elimina el hipervínculo del texto de una forma.

```py
def remove_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = None

        presentation.save("hyperlink_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Actualizar un hipervínculo**

Cambia el destino de un hipervínculo existente. Usa `HyperlinkManager` para modificar el texto que ya contiene un hipervínculo, lo que imita cómo PowerPoint actualiza los hipervínculos de forma segura.

```py
def update_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        # Cambiar un hipervínculo dentro de un texto existente debe hacerse mediante
        # HyperlinkManager en lugar de establecer la propiedad directamente.
        # Esto imita cómo PowerPoint actualiza de forma segura los hipervínculos.
        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://new.example.com")

        presentation.save("hyperlink_updated.pptx", slides.export.SaveFormat.PPTX)
```