---
title: Transición de diapositiva
type: docs
weight: 110
url: /es/python-java/examples/elements/slide-transition/
keywords:
- ejemplo de código
- transición de diapositiva
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Aplicar y eliminar transiciones de diapositivas y establecer temporizaciones de avance automático de diapositivas con ejemplos de código de Aspose.Slides para Python vía Java para presentaciones PPT, PPTX y ODP."
---
Este artículo muestra cómo aplicar efectos de transición de diapositivas y temporizaciones con **Aspose.Slides for Python via Java**.

Instale el paquete como se describe en [Installation](/slides/es/python-java/installation/). Cada ejemplo importa `asposeslides` antes de iniciar la JVM, y luego importa la API una vez que la JVM está en ejecución.

## **Agregar una transición de diapositiva**

Aplique un efecto de transición de desvanecimiento a la primera diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Aplicar una transición de desvanecimiento.
finally:
    presentation.dispose()
```

## **Acceder a una transición de diapositiva**

Lea el tipo de transición asignado actualmente a una diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Push)

    # Acceder al tipo de transición.
    transition_type = slide.getSlideShowTransition().getType()
finally:
    presentation.dispose()
```

## **Eliminar una transición de diapositiva**

Elimine cualquier efecto de transición. JPype expone la constante Java llamada `None` como `None_` porque `None` es una palabra reservada en Python.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Fade)

    # Eliminar el efecto de transición.
    slide.getSlideShowTransition().setType(TransitionType.None_)
finally:
    presentation.dispose()
```

## **Establecer la duración de la transición**

Especifique cuánto tiempo se muestra la diapositiva antes de avanzar automáticamente. Este ejemplo avanza después de dos segundos y también permite avanzar con un clic del ratón. Este temporizador controla el avance de la diapositiva, no la velocidad del efecto de transición.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setAdvanceOnClick(True)
    slide.getSlideShowTransition().setAdvanceAfter(True)
    slide.getSlideShowTransition().setAdvanceAfterTime(2000)  # En milisegundos.
finally:
    presentation.dispose()
```