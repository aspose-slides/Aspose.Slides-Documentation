---
title: Eliminar diapositiva de la presentación
type: docs
weight: 30
url: /python-net/remove-slide-from-presentation/
keywords: "Eliminar diapositiva, Borrar diapositiva, PowerPoint, Presentación, Python, Aspose.Slides"
description: "Eliminar diapositiva de PowerPoint por referencia o índice en Python"

---

Si una diapositiva (o su contenido) se vuelve redundante, puedes eliminarla. Aspose.Slides proporciona la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) que encapsula [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/), que es un repositorio para todas las diapositivas en una presentación. Utilizando punteros (referencia o índice) para un objeto [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/), puedes especificar la diapositiva que deseas eliminar.

## **Eliminar Diapositiva por Referencia**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtén una referencia de la diapositiva que deseas eliminar a través de su ID o Índice.
1. Elimina la diapositiva referenciada de la presentación.
1. Guarda la presentación modificada.

Este código Python te muestra cómo eliminar una diapositiva a través de su referencia:

```python
import aspose.slides as slides

# Instancia un objeto Presentation que representa un archivo de presentación
with slides.Presentation(path + "RemoveSlideUsingReference.pptx") as pres:
    # Accede a una diapositiva a través de su índice en la colección de diapositivas
    slide = pres.slides[0]

    # Elimina una diapositiva a través de su referencia
    pres.slides.remove(slide)

    # Guarda la presentación modificada
    pres.save("modified_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Eliminar Diapositiva por Índice**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Elimina la diapositiva de la presentación a través de su posición de índice.
1. Guarda la presentación modificada.

Este código Python te muestra cómo eliminar una diapositiva a través de su índice:

```python
import aspose.slides as slides

# Instancia un objeto Presentation que representa un archivo de presentación
with slides.Presentation(path + "RemoveSlideUsingIndex.pptx") as pres:
    # Elimina una diapositiva a través de su índice de diapositiva
    pres.slides.remove_at(0)

    # Guarda la presentación modificada
    pres.save("modified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Eliminar Diapositiva de Diseño No Utilizada**

Aspose.Slides proporciona el método `remove_unused_layout_slides(pres)` (de la clase [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/)) para permitirte eliminar diapositivas de diseño no deseadas y no utilizadas. Este código Python te muestra cómo eliminar una diapositiva de diseño de una presentación de PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_layout_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Eliminar Diapositiva Maestra No Utilizada**

Aspose.Slides proporciona el método `remove_unused_master_slides(pres)` (de la clase [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/)) para permitirte eliminar diapositivas maestras no deseadas y no utilizadas. Este código Python te muestra cómo eliminar una diapositiva maestra de una presentación de PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_master_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```