---
title: Acceder a diapositivas en presentaciones con Python
linktitle: Acceder a diapositiva
type: docs
weight: 20
url: /es/python-net/access-slide-in-presentation/
keywords:
- acceder a diapositiva
- índice de diapositiva
- id de diapositiva
- posición de diapositiva
- cambiar posición
- propiedades de la diapositiva
- número de diapositiva
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda cómo acceder y administrar diapositivas en presentaciones de PowerPoint y OpenDocument con Aspose.Slides para Python a través de .NET. Mejore la productividad con ejemplos de código."
---

## **Descripción general**

Este artículo explica cómo acceder a diapositivas específicas en una presentación de PowerPoint usando Aspose.Slides para Python. Muestra cómo abrir una presentación, referenciar diapositivas por índice o por ID único, y leer información básica de la diapositiva necesaria para la navegación dentro del archivo. Con estas técnicas, podrá localizar de manera fiable la diapositiva exacta que desea inspeccionar o procesar.

## **Acceder a una diapositiva por índice**

Las diapositivas en una presentación se indexan por posición comenzando en 0. La primera diapositiva tiene índice 0, la segunda tiene índice 1, y así sucesivamente.

La clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) (que representa un archivo de presentación) expone diapositivas a través de una [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) de objetos [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/).

El siguiente código Python muestra cómo acceder a una diapositiva por su índice:

```python
import aspose.slides as slides

# Create a Presentation that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Get a slide by its index.
    slide = presentation.slides[0]
```

## **Acceder a una diapositiva por ID**

Cada diapositiva en una presentación tiene un ID único asociado. Puede usar el método [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) (expuesto por la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)) para dirigirse a ese ID. 

El siguiente código Python muestra cómo proporcionar un ID de diapositiva válido y acceder a esa diapositiva mediante el método [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/):

```python
import aspose.slides as slides

# Create a Presentation that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Get a slide ID.
    id = presentation.slides[0].slide_id
    # Access the slide by its ID.
    slide = presentation.get_slide_by_id(id)
```

## **Cambiar la posición de una diapositiva**

Aspose.Slides le permite cambiar la posición de una diapositiva. Por ejemplo, puede hacer que la primera diapositiva se convierta en la segunda.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtener una referencia a la diapositiva cuya posición desea cambiar por su índice.
1. Establecer una nueva posición para la diapositiva mediante la propiedad [slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/).
1. Guardar la presentación modificada.

El siguiente código Python mueve la diapositiva en la posición 1 a la posición 2:

```python
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Get the slide whose position will be changed.
    slide = presentation.slides[0]
    # Set the new position for the slide.
    slide.slide_number = 2
    # Save the modified presentation.
    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)
```

La primera diapositiva se convierte en la segunda; la segunda diapositiva se convierte en la primera. Cuando cambia la posición de una diapositiva, las demás diapositivas se ajustan automáticamente.

## **Establecer el número de diapositiva**

Usando la propiedad [first_slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) (expuesta por la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)), puede especificar un nuevo número para la primera diapositiva de una presentación. Esta operación hace que los demás números de diapositiva se recalculen.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Establecer el número de diapositiva.
1. Guardar la presentación modificada.

El siguiente código Python demuestra una operación donde el número de la primera diapositiva se establece en 10:

```python
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Set the slide number.
    presentation.first_slide_number = 10
    # Save the modified presentation.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

Si prefiere omitir la primera diapositiva, puede comenzar la numeración a partir de la segunda diapositiva (y ocultar el número en la primera diapositiva) de la siguiente manera:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # Set the number for the first slide in the presentation.
    presentation.first_slide_number = 0

    # Show slide numbers for all slides.
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # Hide the slide number on the first slide.
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # Save the modified presentation.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿El número de diapositiva que ve el usuario coincide con el índice basado en cero de la colección?**

La numeración mostrada en una diapositiva puede comenzar desde un valor arbitrario (p. ej., 10) y no tiene que coincidir con el índice; la relación está controlada por la configuración del primer número de diapositiva de la presentación.

**¿Las diapositivas ocultas afectan la indexación?**

Sí. Una diapositiva oculta permanece en la colección y se cuenta en la indexación; "oculto" se refiere a la visualización, no a su posición en la colección.

**¿Cambia el índice de una diapositiva cuando se añaden o eliminan otras diapositivas?**

Sí. Los índices siempre reflejan el orden actual de las diapositivas y se recalculan al insertar, eliminar o mover diapositivas.