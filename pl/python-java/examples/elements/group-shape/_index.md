---
title: Grupa kształtów
type: docs
weight: 170
url: /pl/python-java/examples/elements/group-shape/
keywords:
- przykład kodu
- grupa kształtów
- dodaj grupę kształtów
- uzyskaj dostęp do grupy kształtów
- usuń grupę kształtów
- rozgrupuj kształty
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Zarządzaj grupami kształtów w prezentacjach przy użyciu Aspose.Slides dla Pythona poprzez Javę: dodawaj, uzyskuj dostęp, usuwaj i rozgrupowuj kształty w plikach PowerPoint i OpenDocument."
---
Ten artykuł pokazuje, jak tworzyć grupy kształtów, uzyskiwać do nich dostęp, usuwać je i rozgrupowywać ich zawartość przy użyciu **Aspose.Slides for Python via Java**.

Zainstaluj pakiet zgodnie z opisem w [Installation](/slides/pl/python-java/installation/). Każdy przykład importuje `asposeslides` przed uruchomieniem JVM, a następnie importuje API po uruchomieniu maszyny wirtualnej.

## **Dodaj grupę kształtów**

Utwórz grupę zawierającą dwa podstawowe kształty.

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

## **Uzyskaj dostęp do grupy kształtów**

Pobierz pierwszy kształt grupy ze slajdu.

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

## **Usuń grupę kształtów**

Usuń grupę kształtów ze slajdu.

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

## **Rozgrupuj kształty**

Przenieś kształt poza kontener grupy.

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

    # Przenieś kształt poza grupę.
    slide.getShapes().addClone(rectangle)
    group.getShapes().remove(rectangle)
finally:
    presentation.dispose()
```