---
title: Diapositiva
type: docs
weight: 10
url: /es/python-net/examples/elements/slide/
keywords:
- diapositiva
- agregar diapositiva
- acceder a la diapositiva
- índice de diapositiva
- clonar diapositiva
- reordenar diapositivas
- eliminar diapositiva
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Gestiona diapositivas en Python con Aspose.Slides: crea, clona, reordena, oculta, establece fondos y tamaño, aplica transiciones y exporta para PowerPoint y OpenDocument."
---
Este artículo ofrece una serie de ejemplos que demuestran cómo trabajar con diapositivas utilizando **Aspose.Slides for Python via .NET**. Aprenderá cómo agregar, acceder, clonar, reorganizar y eliminar diapositivas usando la clase `Presentation`.

Cada ejemplo a continuación incluye una breve explicación seguida de un fragmento de código en Python.

## **Agregar una diapositiva**

Para añadir una nueva diapositiva, primero debe seleccionar una disposición. En este ejemplo, utilizamos la disposición `Blank` y añadimos una diapositiva vacía a la presentación.

```py
def add_slide():
    with slides.Presentation() as presentation:
        # Cada diapositiva se basa en una disposición, que a su vez se basa en una diapositiva maestra.
        # Utiliza la disposición Blank para crear una nueva diapositiva.
        blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Añade una nueva diapositiva vacía usando la disposición seleccionada.
        presentation.slides.add_empty_slide(blank_layout)

        presentation.save("slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Consejo:** Cada disposición de diapositiva se deriva de una diapositiva maestra, que define el diseño general y la estructura de marcadores de posición. La imagen a continuación ilustra cómo se organizan las diapositivas maestras y sus disposiciones asociadas en PowerPoint.

![Relación entre maestro y disposición](master-layout-slide.png)

## **Acceder a diapositivas por índice**

Puede acceder a las diapositivas mediante su índice. Esto es útil para iterar o modificar diapositivas específicas.

```py
def access_slide():
    with slides.Presentation("slide.pptx") as presentation:
        # Accede a una diapositiva por índice.
        first_slide = presentation.slides[0]
```

## **Clonar una diapositiva**

Este ejemplo muestra cómo clonar una diapositiva existente. La diapositiva clonada se añade automáticamente al final de la colección de diapositivas.

```py
def clone_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Clona la diapositiva; se añadirá al final de la presentación.
        cloned_slide = presentation.slides.add_clone(slide)

        presentation.save("slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

## **Reordenar diapositivas**

Puede cambiar el orden de las diapositivas moviendo una a un nuevo índice. En este caso, movemos una diapositiva a la primera posición.

```py
def reorder_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[1]

        # Mueve la diapositiva a la primera posición (las demás se desplazan hacia abajo).
        presentation.slides.reorder(0, slide)

        presentation.save("slide_reordered.pptx", slides.export.SaveFormat.PPTX)
```

## **Eliminar una diapositiva**

Para eliminar una diapositiva, simplemente haga referencia a ella y llame a `remove`. Este ejemplo elimina la primera diapositiva.

```py
def remove_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Elimina la diapositiva.
        presentation.slides.remove(slide)

        presentation.save("slide_removed.pptx", slides.export.SaveFormat.PPTX)
```