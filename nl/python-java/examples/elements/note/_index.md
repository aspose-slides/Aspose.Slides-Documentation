---
title: Notitie
type: docs
weight: 240
url: /nl/python-java/examples/elements/note/
keywords:
- codevoorbeeld
- notitie
- sprekernotitie
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Werken met slidesnotities in Aspose.Slides voor Python via Java: notities toevoegen, lezen, verwijderen en bijwerken in PowerPoint- en OpenDocument-presentaties."
---
Dit artikel laat zien hoe je notitieslides kunt toevoegen, lezen, verwijderen en bijwerken met **Aspose.Slides for Python via Java**.

Installeer het pakket zoals beschreven in [Installation](/slides/nl/python-java/installation/). Elk voorbeeld importeert `asposeslides` voordat de JVM wordt gestart en importeert vervolgens de API nadat de JVM draait.

## **Notitieslide toevoegen**

Maak een notitieslide aan en wijs er tekst aan toe.

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

## **Toegang tot een notitieslide**

Lees de tekst van een bestaande notitieslide.

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

## **Notitieslide verwijderen**

Verwijder de notitieslide die bij een slide hoort.

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

## **Notitietekst bijwerken**

Verander de tekst van een notitieslide.

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