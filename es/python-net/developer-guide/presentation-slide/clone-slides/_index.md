---
title: Clonar Diapositivas
type: docs
weight: 40
url: /es/python-net/clone-slides/
keywords: "Clonar diapositiva, Copiar diapositiva, Guardar copia de diapositiva, PowerPoint, Presentación, Python, Aspose.Slides"
description: "Clonar diapositiva de PowerPoint en Python"
---

## **Clonar Diapositivas en Presentación**
Clonar es el proceso de hacer una copia exacta o réplica de algo. Aspose.Slides para Python a través de .NET también permite hacer una copia o clon de cualquier diapositiva y luego insertar esa diapositiva clonada en la presentación actual o en otra presentación abierta. El proceso de clonación de diapositivas crea una nueva diapositiva que puede ser modificada por los desarrolladores sin cambiar la diapositiva original. Hay varias formas posibles de clonar una diapositiva:

- Clonar al Final dentro de una Presentación.
- Clonar en Otra Posición dentro de la Presentación.
- Clonar al Final en otra Presentación.
- Clonar en Otra Posición en otra Presentación.
- Clonar en una posición específica en otra Presentación.

En Aspose.Slides para Python a través de .NET, (una colección de [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) objetos) expuesta por el objeto [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) proporciona los métodos [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) y [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) para realizar los tipos de clonación de diapositivas mencionados anteriormente.

## **Clonar al Final Dentro de una Presentación**
Si deseas clonar una diapositiva y luego usarla dentro del mismo archivo de presentación al final de las diapositivas existentes, utiliza el método [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) de acuerdo con los pasos que se indican a continuación:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Instancia la clase [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) referenciando la colección de Diapositivas expuesta por el objeto [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
3. Llama al método [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) expuesto por el objeto [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) y pasa la diapositiva que se va a clonar como un parámetro al método [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/).
4. Escribe el archivo de presentación modificado.

En el ejemplo dado a continuación, hemos clonado una diapositiva (en la primera posición – índice cero – de la presentación) al final de la presentación.

```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo de presentación
with slides.Presentation(path + "CloneWithinSamePresentationToEnd.pptx") as pres:
    # Clonar la diapositiva deseada al final de la colección de diapositivas en la misma presentación
    slds = pres.slides

    slds.add_clone(pres.slides[0])

    # Escribir la presentación modificada en el disco
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Clonar en Otra Posición Dentro de la Presentación**
Si deseas clonar una diapositiva y luego usarla dentro del mismo archivo de presentación pero en una posición diferente, utiliza el método [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/):

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Instancia la clase haciendo referencia a la colección **Slides** expuesta por el objeto [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
3. Llama al método [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) expuesto por el objeto [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) y pasa la diapositiva a clonar junto con el índice para la nueva posición como un parámetro al método [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).
4. Escribe la presentación modificada como un archivo PPTX.

En el ejemplo dado a continuación, hemos clonado una diapositiva (en el índice cero – posición 1 – de la presentación) al índice 1 – Posición 2 – de la presentación.

```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo de presentación
with slides.Presentation(path + "CloneWithInSamePresentation.pptx") as pres:
    # Clonar la diapositiva deseada al final de la colección de diapositivas en la misma presentación
    slds = pres.slides

    # Clonar la diapositiva deseada al índice especificado en la misma presentación
    slds.insert_clone(2, pres.slides[1])

    # Escribir la presentación modificada en el disco
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Clonar al Final en Otra Presentación**
Si necesitas clonar una diapositiva de una presentación y usarla en otro archivo de presentación, al final de las diapositivas existentes:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) que contiene la presentación de la cual se clonará la diapositiva.
2. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) que contiene la presentación de destino a la que se añadirá la diapositiva.
3. Instancia la clase [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) haciendo referencia a la colección **Slides** expuesta por el objeto Presentation de la presentación de destino.
4. Llama al método [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) expuesto por el objeto [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) y pasa la diapositiva de la presentación de origen como un parámetro al método [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/).
5. Escribe el archivo de presentación de destino modificado.

En el ejemplo dado a continuación, hemos clonado una diapositiva (del primer índice de la presentación de origen) al final de la presentación de destino.

```py
import aspose.slides as slides

# Instanciar la clase Presentation para cargar el archivo de presentación de origen
with slides.Presentation(path + "CloneAtEndOfAnother.pptx") as srcPres:
    # Instanciar la clase Presentation para la metodología de PPTX de destino (donde se clona la diapositiva)
    with slides.Presentation() as destPres:
        # Clonar la diapositiva deseada de la presentación de origen al final de la colección de diapositivas en la presentación de destino
        slds = destPres.slides
        slds.add_clone(srcPres.slides[0])

        # Escribir la presentación de destino en el disco
        destPres.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Clonar en Otra Posición en Otra Presentación**
Si necesitas clonar una diapositiva de una presentación y usarla en otro archivo de presentación, en una posición específica:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) que contiene la presentación de origen de la cual se clonará la diapositiva.
2. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) que contiene la presentación a la que se añadirá la diapositiva.
3. Instancia la clase [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) haciendo referencia a la colección de Diapositivas expuesta por el objeto Presentation de la presentación de destino.
4. Llama al método [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) y pasa la diapositiva de la presentación de origen junto con la posición deseada como un parámetro al método [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).
5. Escribe el archivo de presentación de destino modificado.

En el ejemplo dado a continuación, hemos clonado una diapositiva (del índice cero de la presentación de origen) al índice 1 (posición 2) de la presentación de destino.

```py
import aspose.slides as slides

# Instanciar la clase Presentation para cargar el archivo de presentación de origen
with slides.Presentation(path + "CloneAtEndOfAnother.pptx") as srcPres:
    # Instanciar la clase Presentation para la metodología de PPTX de destino (donde se clona la diapositiva)
    with slides.Presentation("Aspose2_out.pptx") as destPres:
        slds = destPres.slides
        slds.insert_clone(2, srcPres.slides[0])

        # Escribir la presentación de destino en el disco
        destPres.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Clonar en una Posición Específica en Otra Presentación**
Si necesitas clonar una diapositiva con una diapositiva maestra de una presentación y usarla en otra presentación, primero necesitas clonar la diapositiva maestra deseada de la presentación de origen a la presentación de destino. Luego necesitas usar esa diapositiva maestra para clonar la diapositiva con la diapositiva maestra. El método **add_clone(ISlide, IMasterSlide)** espera una diapositiva maestra de la presentación de destino en lugar de la de la presentación de origen. Para clonar la diapositiva con una maestra, sigue los pasos a continuación:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) que contiene la presentación de origen de la cual se clonará la diapositiva.
2. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) que contiene la presentación de destino a la que se clonará la diapositiva.
3. Accede a la diapositiva que se va a clonar junto con la diapositiva maestra.
4. Instancia la clase [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) haciendo referencia a la colección de Maestras expuesta por el objeto [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) de la presentación de destino.
5. Llama al método [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) expuesto por el objeto [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) y pasa la maestra de la presentación de origen a clonar como un parámetro al método [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/).
6. Instancia la clase [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) haciendo referencia a la colección de Diapositivas expuesta por el objeto [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) de la presentación de destino.
7. Llama al método [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) y pasa la diapositiva de la presentación de origen a clonar y la diapositiva maestra como un parámetro al método [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/).
8. Escribe el archivo de presentación de destino modificado.

En el ejemplo dado a continuación, hemos clonado una diapositiva con una maestra (en el índice cero de la presentación de origen) al final de la presentación de destino utilizando una maestra de la diapositiva de origen.

```py
import aspose.slides as slides

# Instanciar la clase Presentation para cargar el archivo de presentación de origen
with slides.Presentation(path + "CloneToAnotherPresentationWithMaster.pptx") as srcPres:
    # Instanciar la clase Presentation para la presentación de destino (donde se clonará la diapositiva)
    with slides.Presentation() as destPres:
        # Instanciar ISlide de la colección de diapositivas en la presentación de origen junto con
        # la diapositiva maestra
        sourceSlide = srcPres.slides[0]
        sourceMaster = sourceSlide.layout_slide.master_slide

        # Clonar la diapositiva maestra deseada de la presentación de origen a la colección de maestras en la presentación de destino
        masters = destPres.masters
        destMaster = sourceSlide.layout_slide.master_slide

        # Clonar la diapositiva maestra deseada de la presentación de origen a la colección de maestras en la presentación de destino
        iSlide = masters.add_clone(sourceMaster)

        # Clonar la diapositiva deseada de la presentación de origen con la maestra deseada al final de la colección de diapositivas en la presentación de destino
        slds = destPres.slides
        slds.add_clone(sourceSlide, iSlide, True)

        # Clonar la diapositiva maestra deseada de la presentación de origen a la colección de maestras en la presentación de destino.
        # Guardar la presentación de destino en el disco
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```


## Clonar al Final en una Sección Específica

Con Aspose.Slides para Python a través de .NET, puedes clonar una diapositiva de una sección de una presentación e inserting esa diapositiva en otra sección en la misma presentación. En este caso, tienes que usar el método [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) de la interfaz [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/).

Este código Python te muestra cómo clonar una diapositiva y insertar la diapositiva clonada en una sección especificada:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100) # para clonar
    
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    section = pres.sections.add_section("Sección2", slide2)

    pres.slides.add_clone(slide, section)
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```