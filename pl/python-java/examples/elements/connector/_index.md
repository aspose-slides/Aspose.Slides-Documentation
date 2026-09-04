---
title: Łącznik
type: docs
weight: 190
url: /pl/python-java/examples/elements/connector/
keywords:
- przykład kodu
- łącznik
- dodaj łącznik
- uzyskaj dostęp do łącznika
- usuń łącznik
- ponownie połącz kształty
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak dodawać, uzyskiwać dostęp, usuwać i ponownie łączyć kształty przy użyciu łączników w Aspose.Slides dla Pythona poprzez Javę w prezentacjach PPT, PPTX i ODP."
---
Ten artykuł pokazuje, jak łączyć kształty za pomocą łączników i zmieniać ich cele, używając **Aspose.Slides for Python via Java**.

Zainstaluj pakiet, postępując zgodnie z instrukcją w [Installation](/slides/pl/python-java/installation/). Każdy przykład importuje `asposeslides` przed uruchomieniem JVM, a następnie importuje API po uruchomieniu JVM.

## **Dodaj łącznik**

Wstaw kształt łącznika pomiędzy dwa punkty na slajdzie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)
finally:
    presentation.dispose()
```

## **Uzyskaj dostęp do łącznika**

Pobierz pierwszy kształt łącznika dodany do slajdu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Connector, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    # Uzyskaj dostęp do pierwszego łącznika na slajdzie.
    connector = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Connector):
            connector = shape
            break
finally:
    presentation.dispose()
```

## **Usuń łącznik**

Usuń łącznik ze slajdu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    slide.getShapes().remove(connector)
finally:
    presentation.dispose()
```

## **Połącz ponownie kształty**

Dołącz łącznik do dwóch kształtów, przypisując cele początkowy i końcowy.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)
    shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 50, 50)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    connector.setStartShapeConnectedTo(shape1)
    connector.setEndShapeConnectedTo(shape2)
finally:
    presentation.dispose()
```