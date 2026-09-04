---
title: Tinta
type: docs
weight: 180
url: /es/python-java/examples/elements/ink/
keywords:
- ejemplo de código
- tinta
- acceder a la tinta
- eliminar tinta
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Acceda y elimine formas de tinta en presentaciones de Aspose.Slides para Python via Java, incluyendo archivos PPT, PPTX y ODP."
---
Este artículo ofrece ejemplos de cómo acceder a formas de tinta existentes y eliminarlas usando **Aspose.Slides for Python via Java**.

Instale el paquete como se describe en [Installation](/slides/es/python-java/installation/). Cada ejemplo importa `asposeslides` antes de iniciar la JVM y luego importa la API una vez que la JVM está en ejecución.

{{% alert color="info" title="Note" %}}
Las formas de tinta representan la entrada del usuario desde dispositivos especializados. Aspose.Slides no puede crear nuevos trazos de tinta de forma programática, pero puede leer y modificar la tinta existente.
{{% /alert %}}

## **Acceder a la tinta**

Lea las etiquetas de la primera forma de tinta en una diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().get_Item(0)
    if isinstance(shape, Ink):
        tags = shape.getCustomData().getTags()
        if tags.size() > 0:
            tag_name = tags.getNameByIndex(0)
            # Use tag_name según sea necesario.
finally:
    presentation.dispose()
```

## **Eliminar tinta**

Elimine una forma de tinta de la diapositiva si existe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    ink = None
    for shape in slide.getShapes():
        if isinstance(shape, Ink):
            ink = shape
            break

    if ink is not None:
        slide.getShapes().remove(ink)
finally:
    presentation.dispose()
```