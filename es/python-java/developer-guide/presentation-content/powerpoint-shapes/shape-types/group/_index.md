---
title: Formas de presentación en grupo con Python vía Java
linktitle: Grupo de formas
type: docs
weight: 40
url: /es/python-java/group/
keywords:
- grupo de formas
- grupo de formas
- añadir grupo
- texto alternativo
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprenda a agrupar y desagrupar formas en presentaciones de PowerPoint usando Aspose.Slides para Python mediante Java, una guía paso a paso con código Python gratuito."
---
## **Visión general**

Este artículo explica cómo trabajar con grupos de formas en Aspose.Slides. Muestra cómo añadir un grupo de formas a una diapositiva, colocar formas dentro de él y guardar la presentación actualizada. También demuestra cómo acceder a las formas almacenadas dentro de un grupo y leer su texto alternativo mediante [getAlternativeText](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getAlternativeText). Además, el artículo cubre brevemente capacidades relacionadas con los grupos de formas, como grupos anidados, orden Z y opciones de bloqueo.

## **Añadir un grupo de formas**

Aspose.Slides permite trabajar con grupos de formas en diapositivas. Esta función ayuda a los desarrolladores a crear presentaciones más ricas. Aspose.Slides for Python via Java soporta la adición y acceso a grupos de formas. Puede poblar un grupo de formas con otras formas o acceder a sus propiedades. Para añadir un grupo de formas a una diapositiva usando Aspose.Slides for Python via Java:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un grupo de formas a la diapositiva.
1. Añadir formas al grupo de formas.
1. Guardar la presentación modificada como archivo PPTX.

El siguiente ejemplo añade un grupo de formas a una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame, ShapeType

# Instanciar la clase Presentation.
presentation = Presentation()
try:
    # Obtener la primera diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Acceder a la colección de formas de la diapositiva.
    slide_shapes = slide.getShapes()

    # Añadir un grupo de formas a la diapositiva.
    group_shape = slide_shapes.addGroupShape()

    # Añadir formas dentro del grupo de formas.
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100)

    # Establecer el marco del grupo de formas.
    group_frame = ShapeFrame(100, 300, 500, 40, NullableBool.False_, NullableBool.False_, 0)
    group_shape.setFrame(group_frame)

    # Escribir el archivo PPTX en disco.
    presentation.save("GroupShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Acceder al texto alternativo**

Esta sección muestra cómo acceder al texto alternativo de las formas dentro de un grupo en una diapositiva. Para acceder a este texto usando Aspose.Slides for Python via Java:

1. Instanciar la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) que representa un archivo PPTX.
1. Obtener una referencia a una diapositiva por su índice.
1. Acceder a la colección de formas de la diapositiva.
1. Acceder al grupo de formas.
1. Leer el texto alternativo de sus formas mediante [getAlternativeText](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getAlternativeText).

El siguiente ejemplo accede al texto alternativo de las formas dentro de un grupo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation

# Instanciar la clase Presentation que representa el archivo PPTX.
presentation = Presentation("AltText.pptx")
try:
    # Obtener la primera diapositiva.
    slide = presentation.getSlides().get_Item(0)

    for i in range(slide.getShapes().size()):
        # Acceder a una forma en la colección de formas de la diapositiva.
        shape = slide.getShapes().get_Item(i)

        if isinstance(shape, GroupShape):
            # Acceder a las formas dentro del grupo.
            for j in range(shape.getShapes().size()):
                child_shape = shape.getShapes().get_Item(j)

                # Leer el texto alternativo.
                print(child_shape.getAlternativeText())
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Se admite el agrupamiento anidado (un grupo dentro de otro grupo)?**

Sí. [GroupShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/groupshape/) tiene un método [getParentGroup](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getParentGroup) que indica compatibilidad con jerarquías: un grupo puede ser hijo de otro grupo.

**¿Cómo controlo el orden Z del grupo respecto a otros objetos en la diapositiva?**

Utilice el método [getZOrderPosition](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getZOrderPosition) del objeto [GroupShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/groupshape/) para inspeccionar su posición en la pila de visualización.

**¿Puedo impedir mover, editar o desagrupar?**

Sí. Los bloqueos del grupo se exponen mediante [getGroupShapeLock](https://reference.aspose.com/slides/es/python-java/aspose.slides/groupshape/#getGroupShapeLock), lo que le permite restringir operaciones sobre el objeto.