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
description: "Clona o duplica rápidamente diapositivas de PowerPoint con Aspose.Slides para Python a través de .NET. Sigue nuestros claros ejemplos de código y consejos para automatizar la creación de PPT en segundos, aumentar la productividad y eliminar el trabajo manual."
---

## **Visión general**

Clonar es el proceso de crear una copia exacta o réplica de algo. Aspose.Slides para Python a través de .NET permite clonar cualquier diapositiva e insertar esa clonación en la presentación actual u otra presentación abierta. El proceso de clonación crea una nueva diapositiva que puedes modificar sin afectar a la original.

Existen varias formas de clonar una diapositiva:

- Clonar una diapositiva al final dentro de la misma presentación.
- Clonar una diapositiva a una posición específica dentro de la misma presentación.
- Clonar una diapositiva al final de otra presentación.
- Clonar una diapositiva a una posición específica en otra presentación.
- Clonar una diapositiva con su diapositiva maestra en otra presentación.

En Aspose.Slides para Python a través de .NET, la [slide collection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) expuesta por el objeto [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) proporciona los métodos `add_clone` e `insert_clone` para realizar estos tipos de clonación de diapositivas.

## **Clone at the End Within the Same Presentation**

Si deseas clonar una diapositiva dentro de la misma presentación y agregarla al final de las diapositivas existentes, utiliza el método `add_clone`. Sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtén la colección de diapositivas del objeto [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
3. Llama al método `add_clone` en la [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/), pasando la diapositiva que se va a clonar.
4. Guarda la presentación modificada.

En el ejemplo siguiente, la primera diapositiva (índice 0) se clona y se agrega al final de la presentación.
```py
import aspose.slides as slides

# Instanciar la clase Presentation para representar el archivo de presentación.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Clonar la diapositiva deseada al final de la colección de diapositivas en la misma presentación.
    presentation.slides.add_clone(presentation.slides[0])
    # Guardar la presentación modificada en disco.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Clone to a Specific Position Within the Same Presentation**

Si deseas clonar una diapositiva dentro de la misma presentación y colocarla en una posición diferente, utiliza el método `insert_clone`:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtén la colección de diapositivas del objeto [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
3. Llama al método `insert_clone` en la [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/), pasando la diapositiva que se va a clonar y el índice de destino para su nueva posición.
4. Guarda la presentación modificada.

En el ejemplo siguiente, la diapositiva en el índice 0 (posición 1) se clona al índice 1 (posición 2) dentro de la misma presentación.
```py
import aspose.slides as slides

# Instanciar la clase Presentation para representar el archivo de presentación.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Clonar la diapositiva deseada en la posición especificada (índice) dentro de la misma presentación.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Guardar la presentación modificada en disco.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Clone at the End of Another Presentation**

Si necesitas clonar una diapositiva de una presentación y agregarla al final de otra presentación:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) para la presentación origen (la que contiene la diapositiva a clonar).
2. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) para la presentación destino (donde se añadirá la diapositiva).
3. Obtén la colección de diapositivas de la presentación destino.
4. Llama a `add_clone` en la [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) de destino, pasando la diapositiva de la presentación origen.
5. Guarda la presentación destino modificada.

En el ejemplo siguiente, la diapositiva en el índice 0 en la presentación origen se clona al final de la presentación destino.
```py
import aspose.slides as slides

# Instanciar la clase Presentation para representar el archivo de presentación origen.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instanciar la clase Presentation para el PPTX de destino (donde se clonará la diapositiva).
    with slides.Presentation() as target_presentation:
        # Clonar la diapositiva deseada de la presentación origen al final de la colección de diapositivas en la presentación destino.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Guardar la presentación de destino en disco.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Clone to a Specific Position in Another Presentation**

Si necesitas clonar una diapositiva de una presentación e insertarla en otra presentación en una posición específica:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) para la presentación origen (la que contiene la diapositiva a clonar).
2. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) para la presentación destino (donde se añadirá la diapositiva).
3. Obtén la colección de diapositivas de la presentación destino.
4. Llama al método `insert_clone` en la [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) de destino, pasando la diapositiva de la presentación origen y el índice de destino deseado.
5. Guarda la presentación destino modificada.

En el ejemplo siguiente, la diapositiva en el índice 0 en la presentación origen se clona al índice 1 (posición 2) en la presentación destino.
```py
import aspose.slides as slides

# Instanciar la clase Presentation para representar el archivo de presentación origen.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instanciar la clase Presentation para el PPTX de destino (donde se va a clonar la diapositiva).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Insertar una copia de la primera diapositiva del origen en el índice 2 de la presentación destino.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Guardar la presentación de destino en disco.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Clone a Slide with Its Master Slide into Another Presentation**

Si necesitas clonar una diapositiva **con su maestra** de una presentación y usarla en otra, primero clona la diapositiva maestra requerida de la presentación origen a la presentación destino. Luego usa esa maestra de destino al clonar la diapositiva. El método `add_clone(Slide, MasterSlide)` espera una **diapositiva maestra de la presentación destino**, no de la origen.

Para clonar una diapositiva con su maestra, sigue estos pasos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) para la presentación origen (la que contiene la diapositiva a clonar).
2. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) para la presentación destino.
3. Acceder a la diapositiva origen que se va a clonar y a su diapositiva maestra.
4. Obtener la [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) de la colección de maestros de la presentación destino.
5. Llamar a `add_clone` en la [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) de destino, pasando la maestra origen para clonarla en el destino.
6. Obtener la [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) de la colección de diapositivas de la presentación destino.
7. Llamar a `add_clone` en la [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) de destino, pasando la diapositiva origen y la maestra clonada del destino.
8. Guardar la presentación destino modificada.

En el ejemplo siguiente, la diapositiva en el índice 0 en la presentación origen se clona al final de la presentación destino usando la maestra clonada del origen.
```py
import aspose.slides as slides

# Instanciar la clase Presentation para representar el archivo de presentación origen.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Instanciar la clase Presentation para la presentación de destino donde se clonará la diapositiva.
    with slides.Presentation() as target_presentation:
        # Obtener la primera diapositiva de la presentación origen.
        source_slide = source_presentation.slides[0]
        # Obtener la diapositiva maestra utilizada por la primera diapositiva.
        source_master = source_slide.layout_slide.master_slide
        # Clonar la diapositiva maestra en la colección de maestros de la presentación de destino.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Clonar la diapositiva de la presentación origen al final de la presentación de destino usando la maestra clonada.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Guardar la presentación de destino en disco.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Clone at the End in a Specified Section**

Con Aspose.Slides para Python a través de .NET, puedes clonar una diapositiva de una sección de una presentación e insertarla en otra sección dentro de la misma presentación. Para ello, utiliza el método `add_clone(Slide, Section)` de la clase [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/).

El siguiente ejemplo en Python muestra cómo clonar una diapositiva e insertar la clonación en una sección especificada:
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
    # Clonar la diapositiva creada anteriormente en la sección "Section2".
    presentation.slides.add_clone(slide, section)
    # Guardar la presentación como archivo PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **Preguntas frecuentes**

**¿Se clonan las notas del presentador y los comentarios del revisor?**

Sí. La página de notas y los comentarios de revisión se incluyen en la clonación. Si no los deseas, [elíminalos](/slides/es/python-net/presentation-notes/) después de la inserción.

**¿Cómo se gestionan los gráficos y sus fuentes de datos?**

Se copian el objeto del gráfico, el formato y los datos incrustados. Si el gráfico estaba enlazado a una fuente externa (p. ej., un libro de trabajo incrustado como OLE), ese enlace se conserva como un [objeto OLE](/slides/es/python-net/manage-ole/). Después de moverlo entre archivos, verifica la disponibilidad de los datos y el comportamiento de actualización.

**¿Puedo controlar la posición de inserción y las secciones de la clonación?**

Sí. Puedes insertar la clonación en un índice de diapositiva específico y colocarla en una [sección](/slides/es/python-net/slide-section/) elegida. Si la sección de destino no existe, créala primero y luego mueve la diapositiva a ella.