---
title: Tinta
type: docs
weight: 180
url: /es/python-net/examples/elements/ink/
keywords:
- tinta
- acceso a tinta
- eliminar tinta
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Manipula tinta digital en diapositivas en Python con Aspose.Slides: añade trazos de lápiz, edita rutas, establece color y grosor, y exporta los resultados para PowerPoint y OpenDocument."
---
Proporciona ejemplos de cómo acceder a formas de tinta existentes y eliminarlas utilizando **Aspose.Slides for Python via .NET**.

> ❗ **Nota:** Las formas de tinta representan la entrada del usuario a partir de dispositivos especializados. Aspose.Slides no puede crear nuevos trazos de tinta programáticamente, pero puedes leer y modificar la tinta existente.

## **Acceso a tinta**

Obtén la primera forma de tinta de una diapositiva.

```py
def access_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        first_ink = None
        for shape in slide.shapes:
            if isinstance(shape, slides.ink.Ink):
                first_ink = shape
                break
```

## **Eliminar tinta**

Elimina una forma de tinta de la diapositiva.

```py
def remove_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        # Suponiendo que la primera forma es un objeto Ink.
        ink = slide.shapes[0]

        slide.shapes.remove(ink)

        presentation.save("ink_removed.pptx", slides.export.SaveFormat.PPTX)
```