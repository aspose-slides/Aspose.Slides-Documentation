---
title: Forma di Gruppo
type: docs
weight: 170
url: /it/python-java/examples/elements/group-shape/
keywords:
- esempio di codice
- forma di gruppo
- aggiungi forma di gruppo
- accedi alla forma di gruppo
- rimuovi forma di gruppo
- separa forme
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Gestisci le forme di gruppo nelle presentazioni con Aspose.Slides for Python via Java: aggiungi, accedi, rimuovi e separa le forme nei file PowerPoint e OpenDocument."
---
Questo articolo dimostra come creare gruppi di forme, accedervi, rimuoverli e separare il loro contenuto usando **Aspose.Slides for Python via Java**.

Installa il pacchetto come descritto in [Installation](/slides/it/python-java/installation/). Ogni esempio importa `asposeslides` prima di avviare la JVM, poi importa l'API dopo che la JVM è in esecuzione.

## **Aggiungi una Forma di Gruppo**
Crea un gruppo contenente due forme di base.

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

## **Accedi a una Forma di Gruppo**
Recupera la prima forma di gruppo da una diapositiva.

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

## **Rimuovi una Forma di Gruppo**
Elimina una forma di gruppo dalla diapositiva.

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

## **Separare le forme**
Sposta una forma fuori da un contenitore di gruppo.

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

    # Sposta la forma fuori dal gruppo.
    slide.getShapes().addClone(rectangle)
    group.getShapes().remove(rectangle)
finally:
    presentation.dispose()
```