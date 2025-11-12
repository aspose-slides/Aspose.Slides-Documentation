---
title: Presentación de Formas Agrupadas con Python
linktitle: Grupo de Formas
type: docs
weight: 40
url: /es/python-net/group/
keywords:
- grupo forma
- grupo de formas
- agregar grupo
- texto alternativo
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprenda a agrupar y desagrupar formas en presentaciones PowerPoint y OpenDocument usando Aspose.Slides para Python: guía paso a paso, rápida y con código gratuito."
---

## **Visión general**

Agrupar formas le permite tratar varios objetos de dibujo como una única unidad, de modo que pueda mover, redimensionar, formatear y transformar conjuntamente. Con Aspose.Slides para Python, puede crear un [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), agregar y organizar formas secundarias dentro de él, y guardar el resultado en PPTX. Este artículo demuestra cómo agregar una forma de grupo en una diapositiva y cómo acceder a los metadatos de accesibilidad, como el Texto alternativo, de las formas dentro del grupo, lo que permite una estructura más limpia y presentaciones más ricas y mantenibles.

## **Agregar formas de grupo**

Aspose.Slides admite el trabajo con formas de grupo en una diapositiva. Esta característica le permite crear presentaciones más ricas al tratar varias formas como un único objeto. Puede agregar nuevas formas de grupo, acceder a las existentes, rellenarlas con formas secundarias y leer o modificar cualquiera de sus propiedades. Para agregar una forma de grupo a una diapositiva:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenga una referencia a una diapositiva por índice.
3. Agregue un [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) a la diapositiva.
4. Agregue formas a la nueva forma de grupo.
5. Guarde la presentación modificada como un archivo PPTX.

El siguiente ejemplo muestra cómo agregar una forma de grupo a una diapositiva.

```py
import aspose.slides as slides

# Instanciar la clase Presentation.
with slides.Presentation() as presentation:
    # Obtener la primera diapositiva.
    slide = presentation.slides[0]

    # Agregar una forma de grupo a la diapositiva.
    group_shape = slide.shapes.add_group_shape()

    # Agregar formas dentro de la forma de grupo.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Guardar el archivo PPTX en disco.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Acceder a la propiedad Texto alternativo**

Esta sección explica cómo leer el Texto alternativo de las formas contenidas dentro de una forma de grupo en una diapositiva usando Aspose.Slides. Para acceder al Texto alternativo de las formas:

1. Instanciar la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) para representar un archivo PPTX.
2. Obtener una referencia a la diapositiva por su índice.
3. Acceder a la colección de formas de la diapositiva.
4. Acceder al [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/).
5. Leer la propiedad Texto alternativo.

El siguiente ejemplo recupera el Texto alternativo de las formas contenidas dentro de formas de grupo.

```py
import aspose.slides as slides

# Instanciar la clase Presentation para abrir el archivo PPTX.
with slides.Presentation("group_shape.pptx") as presentation:
    # Obtener la primera diapositiva.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # Acceder a la forma de grupo.
            for child_shape in shape.shapes:
                # Acceder a la propiedad Texto alternativo.
                print(child_shape.alternative_text)
```

## **FAQ**

**¿Se admite la agrupación anidada (un grupo dentro de otro grupo)?**

Sí. [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) tiene una propiedad [parent_group](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/parent_group/) que indica directamente el soporte de jerarquía (un grupo puede ser hijo de otro grupo).

**¿Cómo controlo el orden Z del grupo en relación con otros objetos en la diapositiva?**

Utilice la propiedad [z_order_position](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/z_order_position/) del [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) para inspeccionar o cambiar su posición en la pila de visualización.

**¿Puedo evitar mover/editar/desagrupar?**

Sí. La sección de bloqueo del grupo se expone mediante [group_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/group_shape_lock/), lo que le permite restringir operaciones sobre el objeto.