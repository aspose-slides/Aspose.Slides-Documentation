---
title: Encabezado y pie de página
type: docs
weight: 220
url: /es/python-java/examples/elements/header-footer/
keywords:
- ejemplo de código
- encabezado
- pie de página
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Controla los encabezados y pies de página de las diapositivas con Aspose.Slides para Python via Java: agrega fechas, números de diapositiva y texto personalizado en presentaciones PPT, PPTX y ODP."
---
Este artículo muestra cómo agregar pies de página y actualizar los marcadores de posición de fecha y hora usando **Aspose.Slides for Python via Java**.

Instale el paquete como se describe en [Installation](/slides/es/python-java/installation/). Cada ejemplo importa `asposeslides` antes de iniciar la JVM y, a continuación, importa la API una vez que la JVM está en funcionamiento.

## **Agregar un pie de página**
Agregue texto al área de pie de página de una diapositiva y hágalo visible.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setFooterText("My footer")
    slide.getHeaderFooterManager().setFooterVisibility(True)
finally:
    presentation.dispose()
```

## **Actualizar fecha y hora**
Modifique el marcador de posición de fecha y hora en una diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setDateTimeText("01/01/2024")
    slide.getHeaderFooterManager().setDateTimeVisibility(True)
finally:
    presentation.dispose()
```