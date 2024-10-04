---
title: Acceder a la Diapositiva en la Presentación
type: docs
weight: 20
url: /es/python-net/access-slide-in-presentation/
keywords: "Acceder a la Presentación de PowerPoint, Acceder a diapositiva, Editar propiedades de la diapositiva, Cambiar posición de la diapositiva, Establecer número de diapositiva, índice, ID, posición Python, Aspose.Slides"
description: "Acceder a la diapositiva de PowerPoint por índice, ID o posición en Python. Editar propiedades de la diapositiva"
---

Aspose.Slides te permite acceder a las diapositivas de dos maneras: por índice y por ID.

## **Acceder a la Diapositiva por Índice**

Todas las diapositivas en una presentación están organizadas numéricamente según la posición de la diapositiva comenzando desde 0. La primera diapositiva se puede acceder a través del índice 0; la segunda diapositiva se accede a través del índice 1; etc.

La clase Presentation, que representa un archivo de presentación, expone todas las diapositivas como una colección [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) (colección de objetos [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)). Este código Python te muestra cómo acceder a una diapositiva a través de su índice:

```python
import aspose.slides as slides

# Instancia un objeto Presentation que representa un archivo de presentación
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Obtiene la referencia de una diapositiva a través de su índice
    slide = presentation.slides[0]
```

## **Acceder a la Diapositiva por ID**

Cada diapositiva en una presentación tiene un ID único asociado a ella. Puedes usar el método `get_slide_by_id(id)` (expuesto por la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)) para apuntar a ese ID. Este código Python te muestra cómo proporcionar un ID de diapositiva válido y acceder a esa diapositiva a través del método `get_slide_by_id(id)`:

```python
import aspose.slides as slides

# Instancia un objeto Presentation que representa un archivo de presentación
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Obtiene un ID de Diapositiva
    id = presentation.slides[0].slide_id
    # Accede a la diapositiva a través de su ID
    slide = presentation.get_slide_by_id(id)
```

## **Cambiar la Posición de la Diapositiva**

Aspose.Slides te permite cambiar la posición de una diapositiva. Por ejemplo, puedes especificar que la primera diapositiva debe convertirse en la segunda diapositiva.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtén la referencia de la diapositiva (cuyo posición deseas cambiar) a través de su índice.
1. Establece una nueva posición para la diapositiva a través de la propiedad `slide_number`. 
1. Guarda la presentación modificada.

Este código Python demuestra una operación en la que la diapositiva en la posición 1 se mueve a la posición 2:

```python
import aspose.slides as slides

# Instancia un objeto Presentation que representa un archivo de presentación
with slides.Presentation(path + "ChangePosition.pptx") as pres:
    # Obtiene la diapositiva cuya posición será cambiada
    sld = pres.slides[0]
    # Establece la nueva posición para la diapositiva
    sld.slide_number = 2
    # Guarda la presentación modificada
    pres.save("Aspose_out.pptx", slides.export.SaveFormat.PPTX)
```

La primera diapositiva se convirtió en la segunda; la segunda diapositiva se convirtió en la primera. Cuando cambias la posición de una diapositiva, otras diapositivas se ajustan automáticamente.


## **Establecer Número de Diapositiva**

Usando la propiedad `first_slide_number` (expuesta por la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)), puedes especificar un nuevo número para la primera diapositiva en una presentación. Esta operación hace que los números de las otras diapositivas se recalculen.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtén el número de la diapositiva.
1. Establece el número de la diapositiva.
1. Guarda la presentación modificada.

Este código Python demuestra una operación donde se establece el número de la primera diapositiva en 10:

```python
import aspose.slides as slides

# Instancia un objeto Presentation que representa un archivo de presentación
with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    # Obtiene el número de la diapositiva
    firstSlideNumber = presentation.first_slide_number
    # Establece el número de la diapositiva
    presentation.first_slide_number = 10
    # Guarda la presentación modificada
    presentation.save("Set_Slide_Number_out.pptx", slides.export.SaveFormat.PPTX)
```

Si prefieres omitir la primera diapositiva, puedes comenzar la numeración desde la segunda diapositiva (y ocultar la numeración de la primera diapositiva) de esta manera:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # Establece el número para la primera diapositiva de la presentación
    presentation.first_slide_number = 0

    # Muestra los números de diaposa para todas las diapositivas
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # Oculta el número de la diapositiva para la primera diapositiva
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # Guarda la presentación modificada
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```