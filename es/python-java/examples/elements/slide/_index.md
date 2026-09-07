---
title: Diapositiva
type: docs
weight: 10
url: /es/python-java/examples/elements/slide/
keywords:
- ejemplo de código
- diapositiva
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Administrar diapositivas en Aspose.Slides para Python mediante Java: agregar, acceder, clonar, reordenar y eliminar diapositivas con ejemplos de código Python para presentaciones PowerPoint y OpenDocument."
---
Este artículo ofrece ejemplos que demuestran cómo agregar, acceder, clonar, reordenar y eliminar diapositivas usando **Aspose.Slides for Python via Java**.

Instale el paquete como se describe en [Instalación](/slides/es/python-java/installation/). Cada ejemplo importa `asposeslides` antes de iniciar la JVM y luego importa la API después de que la JVM esté en funcionamiento.

## **Agregar una diapositiva**

Para agregar una nueva diapositiva, primero seleccione un diseño. Este ejemplo utiliza un diseño en blanco para añadir una diapositiva vacía a la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    presentation.getSlides().addEmptySlide(blank_layout)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Nota" %}}
Cada diseño de diapositiva se deriva de una diapositiva maestra, que define el diseño general y la estructura de los marcadores de posición. La imagen a continuación ilustra cómo se organizan las diapositivas maestras y sus diseños asociados en PowerPoint.
{{% /alert %}}

![Relación entre maestra y diseño](master-layout-slide.png)

## **Acceder a diapositivas por índice**

Acceda a las diapositivas usando su índice basado en cero, o encuentre el índice de una diapositiva a partir de una referencia. Esto es útil para iterar o modificar diapositivas específicas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # Añadir otra diapositiva vacía.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(blank_layout)

    # Acceder a las diapositivas por índice.
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().get_Item(1)

    # Obtener el índice de una diapositiva a partir de una referencia, luego acceder a ella por índice.
    second_slide_index = presentation.getSlides().indexOf(second_slide)
    second_slide_by_index = presentation.getSlides().get_Item(second_slide_index)
finally:
    presentation.dispose()
```

## **Clonar una diapositiva**

Clone una diapositiva existente. La diapositiva clonada se añade automáticamente al final de la colección de diapositivas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    cloned_slide_index = presentation.getSlides().indexOf(cloned_slide)
finally:
    presentation.dispose()
```

## **Reordenar diapositivas**

Cambie el orden de las diapositivas moviendo una a un nuevo índice. Este ejemplo mueve una diapositiva clonada a la primera posición.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    presentation.getSlides().reorder(0, cloned_slide)
finally:
    presentation.dispose()
```

## **Eliminar una diapositiva**

Elimine una diapositiva pasando su referencia a la colección de diapositivas. Este ejemplo agrega una segunda diapositiva y luego elimina la original, dejando solo la nueva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    second_slide = presentation.getSlides().addEmptySlide(blank_layout)

    first_slide = presentation.getSlides().get_Item(0)
    presentation.getSlides().remove(first_slide)
finally:
    presentation.dispose()
```