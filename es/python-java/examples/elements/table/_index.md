---
title: Tabla
type: docs
weight: 120
url: /es/python-java/examples/elements/table/
keywords:
- ejemplo de código
- tabla
- añadir tabla
- acceder tabla
- eliminar tabla
- combinar celdas
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Trabajar con tablas en Aspose.Slides for Python via Java: añadir, acceder, eliminar y combinar celdas en presentaciones de PowerPoint y OpenDocument."
---
Ejemplos para añadir tablas, acceder a ellas, eliminarlas y combinar celdas usando **Aspose.Slides for Python via Java**.

Instale el paquete como se describe en [Installation](/slides/es/python-java/installation/). Cada ejemplo importa `asposeslides` antes de iniciar la JVM, y luego importa la API una vez que la JVM está en ejecución.

## **Agregar una tabla**

Cree una tabla sencilla con dos filas y dos columnas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)
finally:
    presentation.dispose()
```

## **Acceder a una tabla**

Recupere la primera forma de tabla en la diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    # Acceder a la primera tabla en la diapositiva.
    first_table = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Table):
            first_table = shape
            break
finally:
    presentation.dispose()
```

## **Eliminar una tabla**

Elimine una tabla de una diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    slide.getShapes().remove(table)
finally:
    presentation.dispose()
```

## **Combinar celdas de tabla**

Combine celdas adyacentes de una tabla en una única celda.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    # Combinar celdas.
    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), False)
finally:
    presentation.dispose()
```