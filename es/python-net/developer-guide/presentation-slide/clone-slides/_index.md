---
title: Clonar diapositivas de PowerPoint en Python
linktitle: Clonar diapositivas
type: docs
weight: 40
url: /es/python-net/clone-slides/
keywords:
- clonar diapositiva
- copiar diapositiva
- guardar diapositiva
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Clone o duplique rápidamente diapositivas de PowerPoint con Aspose.Slides para Python a través de .NET. Siga nuestros claros ejemplos de código y consejos para automatizar la creación de PPT en segundos, aumentar la productividad y eliminar el trabajo manual."
---
## **Introducción**

Clonar es el proceso de crear una copia exacta o réplica de algo. Aspose.Slides también permite copiar (clonar) cualquier diapositiva y luego insertar la diapositiva clonada en la presentación actual o en cualquier otra presentación abierta. La clonación de diapositivas crea una nueva diapositiva que los desarrolladores pueden modificar sin afectar a la diapositiva original. Existen varias formas de clonar una diapositiva:

- Clonar al final de una presentación.
- Clonar en otra posición dentro de una presentación.
- Clonar al final de otra presentación.
- Clonar en otra posición en otra presentación.
- Clonar en una posición específica en otra presentación.

En Aspose.Slides for Python a través de .NET, la [colección de diapositivas](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidecollection/) expuesta por el objeto [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) proporciona los métodos `add_clone` e `insert_clone` para realizar estos tipos de clonación de diapositivas.

## **Instalación**

```bash
pip install aspose.slides
```

## **Clonar al final dentro de la misma presentación**

Si desea clonar una diapositiva dentro de la misma presentación y añadirla al final de las diapositivas existentes, use el método `add_clone`. Siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Obtenga la colección de diapositivas del objeto [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Llame al método `add_clone` en la [SlideCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidecollection/), pasando la diapositiva a clonar.
1. Guarde la presentación modificada.

En el ejemplo a continuación, la primera diapositiva (índice 0) se clona y se añade al final de la presentación.

```py
import aspose.slides as slides

# Instanciar la clase Presentation para representar el archivo de presentación.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Clonar la diapositiva deseada al final de la colección de diapositivas en la misma presentación.
    presentation.slides.add_clone(presentation.slides[0])
    # Guardar la presentación modificada en disco.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clonar a una posición específica dentro de la misma presentación**

Si desea clonar una diapositiva dentro de la misma presentación y colocarla en una posición diferente, use el método `insert_clone`:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Obtenga la colección de diapositivas del objeto [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Llame al método `insert_clone` en la [SlideCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidecollection/), pasando la diapositiva a clonar y el índice de destino para su nueva posición.
1. Guarde la presentación modificada.

En el ejemplo a continuación, la diapositiva en el índice 1 (posición 2) se clona al índice 2 (posición 3) dentro de la misma presentación.

```py
import aspose.slides as slides

# Instanciar la clase Presentation para representar el archivo de presentación.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Clonar la diapositiva deseada a la posición (índice) especificada dentro de la misma presentación.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Guardar la presentación modificada en disco.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clonar al final de otra presentación**

Si necesita clonar una diapositiva de una presentación y añadirla al final de otra presentación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) para la presentación de origen (la que contiene la diapositiva a clonar).
1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) para la presentación de destino (donde se añadirá la diapositiva).
1. Obtenga la colección de diapositivas de la presentación de destino.
1. Llame a `add_clone` en la [SlideCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidecollection/) de destino, pasando la diapositiva de la presentación de origen.
1. Guarde la presentación de destino modificada.

En el ejemplo a continuación, la diapositiva en el índice 0 de la presentación de origen se clona al final de la presentación de destino.

```py
import aspose.slides as slides

# Instanciar la clase Presentation para representar el archivo de presentación de origen.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instanciar la clase Presentation para el PPTX de destino (donde se clonará la diapositiva).
    with slides.Presentation() as target_presentation:
        # Clonar la diapositiva deseada de la presentación de origen al final de la colección de diapositivas en la presentación de destino.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Guardar la presentación de destino en disco.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clonar a una posición específica en otra presentación**

Si necesita clonar una diapositiva de una presentación e insertarla en otra presentación en una posición específica:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) para la presentación de origen (la que contiene la diapositiva a clonar).
1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) para la presentación de destino (donde se añadirá la diapositiva).
1. Obtenga la colección de diapositivas de la presentación de destino.
1. Llame al método `insert_clone` en la [SlideCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidecollection/) de destino, pasando la diapositiva de la presentación de origen y el índice de destino deseado.
1. Guarde la presentación de destino modificada.

En el ejemplo a continuación, la diapositiva en el índice 0 de la presentación de origen se clona al índice 2 (posición 3) en la presentación de destino.

```py
import aspose.slides as slides

# Instanciar la clase Presentation para representar el archivo de presentación de origen.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instanciar la clase Presentation para el PPTX de destino (donde se va a clonar la diapositiva).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Insertar una copia de la primera diapositiva del origen en el índice 2 de la presentación de destino.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Guardar la presentación de destino en disco.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clonar una diapositiva con su diapositiva maestra en otra presentación**

Si necesita clonar una diapositiva **con su maestra** de una presentación y usarla en otra, primero clone la diapositiva maestra necesaria de la presentación de origen a la presentación de destino. Luego utilice esa maestra de destino al clonar la diapositiva. El método `add_clone(Slide, MasterSlide)` espera una **diapositiva maestra de la presentación de destino**, no de la de origen.

Para clonar una diapositiva con su maestra, siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) para la presentación de origen (la que contiene la diapositiva a clonar).
1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) para la presentación de destino.
1. Acceda a la diapositiva de origen que se va a clonar y a su diapositiva maestra.
1. Obtenga la [MasterSlideCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/masterslidecollection/) de la colección de maestras de la presentación de destino.
1. Llame a `add_clone` en la [MasterSlideCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/masterslidecollection/) de destino, pasando la maestra de origen para clonarla en el destino.
1. Obtenga la [SlideCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidecollection/) de la colección de diapositivas de la presentación de destino.
1. Llame a `add_clone` en la [SlideCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidecollection/) de destino, pasando la diapositiva de origen y la maestra de destino clonada.
1. Guarde la presentación de destino modificada.

En el ejemplo a continuación, la diapositiva en el índice 0 de la presentación de origen se clona al final de la presentación de destino usando la maestra clonada del origen.

```py
import aspose.slides as slides

# Instanciar la clase Presentation para representar el archivo de presentación de origen.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Instanciar la clase Presentation para la presentación de destino donde se clonará la diapositiva.
    with slides.Presentation() as target_presentation:
        # Obtener la primera diapositiva de la presentación de origen.
        source_slide = source_presentation.slides[0]
        # Obtener la diapositiva maestra utilizada por la primera diapositiva.
        source_master = source_slide.layout_slide.master_slide
        # Clonar la diapositiva maestra en la colección de maestras de la presentación de destino.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Clonar la diapositiva de la presentación de origen al final de la presentación de destino usando la maestra clonada.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Guardar la presentación de destino en disco.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clonar al final en una sección especificada**

Con Aspose.Slides for Python a través de .NET, puede clonar una diapositiva de una sección de una presentación e insertarla en otra sección dentro de la misma presentación. Para ello, utilice el método `add_clone(Slide, Section)` de la clase [SlideCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidecollection/).

El siguiente ejemplo en Python muestra cómo clonar una diapositiva e insertar el clon en una sección especificada:

```py
import aspose.slides as slides

# Crear una nueva presentación en blanco.
with slides.Presentation() as presentation:
    # Añadir una diapositiva vacía basada en el diseño de la primera diapositiva.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Añadir una forma elíptica a la nueva diapositiva; esta diapositiva se clonará más tarde.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Añadir otra diapositiva vacía basada en el diseño de la primera diapositiva.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Crear una sección llamada "Section2" que comienza en slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # Clonar la diapositiva creada previamente en la sección "Section2".
    presentation.slides.add_clone(slide, section)
    # Guardar la presentación como archivo PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Asegurar que el tamaño de la diapositiva coincida**

Al clonar diapositivas en otra presentación, asegúrese de que la presentación de destino tenga el mismo tamaño de diapositiva que la de origen. Si los tamaños de las diapositivas difieren, Aspose.Slides no redimensiona automáticamente las formas clonadas; sus coordenadas y dimensiones originales se conservan, lo que puede provocar que el contenido aparezca desalineado o se extienda más allá de los límites de la diapositiva.

Puede establecer el tamaño de diapositiva de la presentación de destino para que coincida con el de origen antes de clonar la maestra y la diapositiva:

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

Haga esto antes de clonar la maestra y la diapositiva.

## **Preguntas frecuentes**

**¿Se clonan las notas del orador y los comentarios del revisor?**

Sí. La página de notas y los comentarios de revisión se incluyen en el clon. Si no los desea, [elímalos](/slides/es/python-net/presentation-notes/) después de la inserción.

**¿Cómo se gestionan los gráficos y sus fuentes de datos?**

El objeto del gráfico, su formato y los datos incrustados se copian. Si el gráfico estaba vinculado a una fuente externa (p. ej., un libro de trabajo incrustado OLE), ese vínculo se conserva como un [objeto OLE](/slides/es/python-net/manage-ole/). Después de moverlo entre archivos, verifique la disponibilidad de los datos y el comportamiento de actualización.

**¿Puedo controlar la posición de inserción y las secciones del clon?**

Sí. Puede insertar el clon en un índice de diapositiva específico y colocarlo en una [sección](/slides/es/python-net/slide-section/) elegida. Si la sección de destino no existe, créela primero y luego mueva la diapositiva a ella.