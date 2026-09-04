---
title: Notatka
type: docs
weight: 240
url: /pl/python-java/examples/elements/note/
keywords:
- przykład kodu
- notatka
- notatka prelegenta
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Pracuj z notatkami slajdów w Aspose.Slides for Python via Java: dodawaj, odczytuj, usuwaj i aktualizuj notatki prelegenta w prezentacjach PowerPoint i OpenDocument."
---
Ten artykuł pokazuje, jak dodawać, odczytywać, usuwać i aktualizować slajdy notatek przy użyciu **Aspose.Slides for Python via Java**.

Zainstaluj pakiet zgodnie z opisem w [Installation](/slides/pl/python-java/installation/). Każdy przykład importuje `asposeslides` przed uruchomieniem JVM, a następnie importuje API po uruchomieniu JVM.

## **Dodaj slajd notatek**

Utwórz slajd notatek i przypisz do niego tekst.

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

## **Uzyskaj dostęp do slajdu notatek**

Odczytaj tekst istniejącego slajdu notatek.

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

    notes = notes_slide.getNotesTextFrame().getText()
    print(notes)
finally:
    presentation.dispose()
```

## **Usuń slajd notatek**

Usuń slajd notatek powiązany ze slajdem.

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

## **Zaktualizuj tekst notatek**

Zmień tekst slajdu notatek.

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