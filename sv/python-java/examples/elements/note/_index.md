---
title: Anteckning
type: docs
weight: 240
url: /sv/python-java/examples/elements/note/
keywords:
- kodexempel
- anteckning
- talarnot
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Arbeta med bildanteckningar i Aspose.Slides för Python via Java: lägg till, läs, ta bort och uppdatera talarnoteringar i PowerPoint- och OpenDocument-presentationer."
---
Denna artikel visar hur man lägger till, läser, tar bort och uppdaterar noteringsbilder med **Aspose.Slides for Python via Java**.

Installera paketet enligt beskrivningen i [Installation](/slides/sv/python-java/installation/). Varje exempel importerar `asposeslides` innan JVM startas, och importerar sedan API:et när JVM körs.

## **Lägg till en noteringsbild**

Skapa en noteringsbild och tilldela text till den.

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

## **Åtkomst till en noteringsbild**

Läs text från en befintlig noteringsbild.

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

## **Ta bort en noteringsbild**

Ta bort noteringsbilden som är kopplad till en bild.

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

## **Uppdatera noteringstext**

Ändra texten på en noteringsbild.

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