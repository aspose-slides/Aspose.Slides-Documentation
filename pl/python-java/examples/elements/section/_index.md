---
title: Sekcja
type: docs
weight: 90
url: /pl/python-java/examples/elements/section/
keywords:
- przykład kodu
- sekcja
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Zarządzaj sekcjami prezentacji w Aspose.Slides for Python via Java: dodawaj, uzyskuj dostęp, usuwaj i zmieniaj nazwy sekcji przy użyciu przykładów kodu w Pythonie."
---
Przykłady zarządzania sekcjami prezentacji — dodawanie, dostęp, usuwanie i zmienianie ich nazw programowo przy użyciu **Aspose.Slides for Python via Java**.

Zainstaluj pakiet zgodnie z opisem w [Installation](/slides/pl/python-java/installation/). Każdy przykład importuje `asposeslides` przed uruchomieniem JVM, a następnie importuje API po uruchomieniu JVM.

## **Dodaj sekcję**

Utwórz sekcję rozpoczynającą się od konkretnego slajdu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Określ slajd, który oznacza początek sekcji.
    presentation.getSections().addSection("New Section", slide)
finally:
    presentation.dispose()
```

## **Dostęp do sekcji**

Odczytaj informacje o sekcji z prezentacji.

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

    # Uzyskaj dostęp do sekcji po indeksie.
    section = presentation.getSections().get_Item(0)
    section_name = section.getName()
    print(section_name)
finally:
    presentation.dispose()
```

## **Usuń sekcję**

Usuń wcześniej dodaną sekcję.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    section = presentation.getSections().addSection("Temporary Section", slide)

    # Usuń pierwszą sekcję.
    presentation.getSections().removeSection(section)
finally:
    presentation.dispose()
```

## **Zmień nazwę sekcji**

Zmień nazwę istniejącej sekcji.

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