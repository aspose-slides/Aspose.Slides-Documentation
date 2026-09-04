---
title: Notiz
type: docs
weight: 240
url: /de/python-java/examples/elements/note/
keywords:
- Codebeispiel
- Notiz
- Rednernotiz
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Arbeiten Sie mit Foliennotizen in Aspose.Slides für Python via Java: Hinzufügen, Lesen, Entfernen und Aktualisieren von Rednernoten in PowerPoint- und OpenDocument-Präsentationen."
---
Dieser Artikel demonstriert, wie man Notizfolien hinzufügt, liest, entfernt und aktualisiert, indem man **Aspose.Slides for Python via Java** verwendet.

Installieren Sie das Paket wie in [Installation](/slides/de/python-java/installation/) beschrieben. Jedes Beispiel importiert `asposeslides`, bevor die JVM gestartet wird, und importiert anschließend die API, nachdem die JVM läuft.

## **Notizfolie hinzufügen**

Erstellen Sie eine Notizfolie und weisen Sie ihr Text zu.

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

## **Auf eine Notizfolie zugreifen**

Lesen Sie Text von einer vorhandenen Notizfolie.

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

## **Eine Notizfolie entfernen**

Entfernen Sie die mit einer Folie verbundene Notizfolie.

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

## **Notiztext aktualisieren**

Ändern Sie den Text einer Notizfolie.

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