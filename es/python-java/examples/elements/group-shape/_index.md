---
title: Grupo de formas
type: docs
weight: 170
url: /es/python-java/examples/elements/group-shape/
keywords:
- ejemplo de código
- grupo de formas
- añadir grupo de formas
- acceder al grupo de formas
- eliminar grupo de formas
- desagrupar formas
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Gestiona grupos de formas en presentaciones con Aspose.Slides for Python via Java: añade, accede, elimina y desagrupa formas en archivos PowerPoint y OpenDocument."
---
Este artículo muestra cómo crear grupos de formas, acceder a ellos, eliminarlos y desagrupar su contenido utilizando **Aspose.Slides for Python via Java**.

Instale el paquete como se describe en [Instalación](/slides/es/python-java/installation/). Cada ejemplo importa `asposeslides` antes de iniciar la JVM y luego importa la API una vez que la JVM está en funcionamiento.

## **Agregar un grupo de formas**

Cree un grupo que contenga dos formas básicas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)
    group.getShapes().addAutoShape(ShapeType.Ellipse, 60, 0, 50, 50)
finally:
    presentation.dispose()
```

## **Acceder a un grupo de formas**

Recupere el primer grupo de formas de una diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)

    first_group = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, GroupShape):
            first_group = shape
            break
finally:
    presentation.dispose()
```

## **Eliminar un grupo de formas**

Elimine un grupo de formas de la diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()

    slide.getShapes().remove(group)
finally:
    presentation.dispose()
```

## **Desagrupar formas**

Mueva una forma fuera de un contenedor de grupo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    rectangle = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)

    # Mover la forma fuera del grupo.
    slide.getShapes().addClone(rectangle)
    group.getShapes().remove(rectangle)
finally:
    presentation.dispose()
```