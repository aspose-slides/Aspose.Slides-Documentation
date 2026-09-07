---
title: SmartArt
type: docs
weight: 140
url: /es/python-java/examples/elements/smart-art/
keywords:
- ejemplo de código
- SmartArt
- añadir SmartArt
- acceder a SmartArt
- eliminar SmartArt
- diseño de SmartArt
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Trabaje con SmartArt en Aspose.Slides para Python a través de Java: añada, acceda, elimine y cambie los diseños de diagramas en presentaciones de PowerPoint y OpenDocument."
---
Este artículo muestra cómo añadir gráficos SmartArt, acceder a ellos, eliminarlos y cambiar los diseños utilizando **Aspose.Slides for Python via Java**.

Instale el paquete como se describe en [Instalación](/slides/es/python-java/installation/). Cada ejemplo importa `asposeslides` antes de iniciar la JVM y, a continuación, importa la API una vez que la JVM está en ejecución.

## **Añadir SmartArt**

Inserte un gráfico SmartArt usando uno de los diseños predefinidos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)
finally:
    presentation.dispose()
```

## **Acceder a SmartArt**

Recupere el primer objeto SmartArt de una diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    first_smart_art = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, SmartArt):
            first_smart_art = shape
            break
finally:
    presentation.dispose()
```

## **Eliminar SmartArt**

Elimine una forma SmartArt de la diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    slide.getShapes().remove(smart_art)
finally:
    presentation.dispose()
```

## **Cambiar el diseño de SmartArt**

Actualice el tipo de diseño de un gráfico SmartArt existente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.VerticalPictureList)
finally:
    presentation.dispose()
```