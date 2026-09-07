---
title: Sección
type: docs
weight: 90
url: /es/python-java/examples/elements/section/
keywords:
- ejemplo de código
- sección
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Gestiona secciones de presentaciones en Aspose.Slides for Python via Java: agrega, accede, elimina y renombra secciones con ejemplos de código en Python."
---
Ejemplos para gestionar secciones de presentación—agregar, acceder, eliminar y renombrar programáticamente usando **Aspose.Slides for Python via Java**.

Instale el paquete como se describe en [Instalación](/slides/es/python-java/installation/). Cada ejemplo importa `asposeslides` antes de iniciar la JVM, y luego importa la API una vez que la JVM está en ejecución.

## **Agregar una sección**

Cree una sección que comience en una diapositiva específica.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Especifica la diapositiva que marca el inicio de la sección.
    presentation.getSections().addSection("New Section", slide)
finally:
    presentation.dispose()
```

## **Acceder a una sección**

Lea la información de la sección de una presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("My Section", slide)

    # Acceder a una sección por índice.
    section = presentation.getSections().get_Item(0)
    section_name = section.getName()
    print(section_name)
finally:
    presentation.dispose()
```

## **Eliminar una sección**

Elimine una sección añadida previamente.

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    section = presentation.getSections().addSection("Temporary Section", slide)

    # Eliminar la primera sección.
    presentation.getSections().removeSection(section)
finally:
    presentation.dispose()
```

## **Renombrar una sección**

Cambie el nombre de una sección existente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("Old Name", slide)

    section = presentation.getSections().get_Item(0)
    section.setName("New Name")
finally:
    presentation.dispose()
```