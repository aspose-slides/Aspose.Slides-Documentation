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
- propiedades de diapositiva
- número de diapositiva
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda cómo acceder y administrar diapositivas en presentaciones PowerPoint y OpenDocument con Aspose.Slides para Python a través de .NET. Aumente la productividad con ejemplos de código."
---

## **Visión general**

Este artículo explica cómo acceder a diapositivas específicas en una presentación de PowerPoint usando Aspose.Slides para Python. Muestra cómo abrir una presentación, referenciar diapositivas por índice o por ID único, y leer información básica de la diapositiva necesaria para la navegación dentro del archivo. Con estas técnicas, puede localizar de forma fiable la diapositiva exacta que desea inspeccionar o procesar.

## **Acceder a una diapositiva por índice**

Las diapositivas en una presentación se indexan por posición comenzando en 0. La primera diapositiva tiene índice 0, la segunda diapositiva tiene índice 1, y así sucesivamente.

La clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) (que representa un archivo de presentación) expone las diapositivas a través de una [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) de objetos [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/).

El siguiente código Python muestra cómo acceder a una diapositiva por su índice:
```python
import aspose.slides as slides

# Crear una Presentación que representa un archivo de presentación.
with slides.Presentation("sample.pptx") as presentation:
    # Obtener una diapositiva por su índice.
    slide = presentation.slides[0]
```


## **Acceder a una diapositiva por ID**

Cada diapositiva en una presentación tiene un ID único asociado. Puede usar el método [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) (expuesto por la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)) para dirigirse a ese ID.

El siguiente código Python muestra cómo proporcionar un ID de diapositiva válido y acceder a esa diapositiva mediante el método [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/):
```python
import aspose.slides as slides

# Crear una Presentación que representa un archivo de presentación.
with slides.Presentation("sample.pptx") as presentation:
    # Obtener el ID de la diapositiva.
    id = presentation.slides[0].slide_id
    # Acceder a la diapositiva por su ID.
    slide = presentation.get_slide_by_id(id)
```


## **Cambiar la posición de una diapositiva**

Aspose.Slides le permite cambiar la posición de una diapositiva. Por ejemplo, puede hacer que la primera diapositiva pase a ser la segunda.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtener una referencia a la diapositiva cuya posición desea cambiar mediante su índice.
3. Establecer una nueva posición para la diapositiva a través de la propiedad [slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/).
4. Guardar la presentación modificada.

El siguiente código Python mueve la diapositiva en la posición 1 a la posición 2:
```python
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo de presentación.
with slides.Presentation("sample.pptx") as presentation:
    # Obtener la diapositiva cuya posición será cambiada.
    slide = presentation.slides[0]
    # Establecer la nueva posición para la diapositiva.
    slide.slide_number = 2
    # Guardar la presentación modificada.
    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)
```


La primera diapositiva pasa a ser la segunda; la segunda diapositiva pasa a ser la primera. Cuando cambia la posición de una diapositiva, las demás diapositivas se ajustan automáticamente.

## **Establecer el número de diapositiva**

Usando la propiedad [first_slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) (expuesta por la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)), puede especificar un nuevo número para la primera diapositiva de una presentación. Esta operación hace que los números de las demás diapositivas se recalculen.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Establecer el número de diapositiva.
3. Guardar la presentación modificada.

El siguiente código Python demuestra una operación donde el número de la primera diapositiva se establece en 10:
```python
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo de presentación.
with slides.Presentation("sample.pptx") as presentation:
    # Establecer el número de la diapositiva.
    presentation.first_slide_number = 10
    # Guardar la presentación modificada.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```


Si prefiere omitir la primera diapositiva, puede comenzar la numeración desde la segunda diapositiva (y ocultar el número en la primera diapositiva) así:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # Establecer el número para la primera diapositiva de la presentación.
    presentation.first_slide_number = 0

    # Mostrar los números de diapositiva en todas las diapositivas.
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # Ocultar el número de diapositiva en la primera diapositiva.
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # Guardar la presentación modificada.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**¿El número de diapositiva que ve el usuario coincide con el índice basado en cero de la colección?**

La numeración mostrada en una diapositiva puede comenzar desde un valor arbitrario (por ejemplo, 10) y no tiene que coincidir con el índice; la relación está controlada por la configuración de [first slide number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) de la presentación.

**¿Las diapositivas ocultas afectan la indexación?**

Sí. Una diapositiva oculta permanece en la colección y se cuenta en la indexación; "oculta" se refiere a la visualización, no a su posición en la colección.

**¿Cambia el índice de una diapositiva cuando se añaden o eliminan otras diapositivas?**

Sí. Los índices siempre reflejan el orden actual de las diapositivas y se recalculan al insertar, eliminar y mover diapositivas.