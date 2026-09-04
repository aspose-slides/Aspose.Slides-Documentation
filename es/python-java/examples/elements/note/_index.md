---
title: Nota
type: docs
weight: 240
url: /es/python-java/examples/elements/note/
keywords:
- ejemplo de código
- nota
- nota del ponente
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Trabaje con notas de diapositivas en Aspose.Slides para Python a través de Java: añada, lea, elimine y actualice notas del ponente en presentaciones de PowerPoint y OpenDocument."
---
Este artículo muestra cómo agregar, leer, eliminar y actualizar diapositivas de notas utilizando **Aspose.Slides for Python via Java**.

Instale el paquete según se describe en [Installation](/slides/es/python-java/installation/). Cada ejemplo importa `asposeslides` antes de iniciar la JVM y luego importa la API una vez que la JVM está en ejecución.

## **Agregar una diapositiva de notas**

Cree una diapositiva de notas y asigne texto a ella.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")
finally:
    presentation.dispose()
```

## **Acceder a una diapositiva de notas**

Lea el texto de una diapositiva de notas existente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")

    notes = notes_slide.getNotesTextFrame().getText()
    print(notes)
finally:
    presentation.dispose()
```

## **Eliminar una diapositiva de notas**

Elimine la diapositiva de notas asociada a una diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getNotesSlideManager().addNotesSlide()
    slide.getNotesSlideManager().removeNotesSlide()
finally:
    presentation.dispose()
```

## **Actualizar el texto de notas**

Cambie el texto de una diapositiva de notas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("Old")
    notes_slide.getNotesTextFrame().setText("Updated")
finally:
    presentation.dispose()
```