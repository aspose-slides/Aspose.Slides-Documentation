---
title: Avsnitt
type: docs
weight: 90
url: /sv/python-java/examples/elements/section/
keywords:
- kodexempel
- avsnitt
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Hantera presentationsavsnitt i Aspose.Slides för Python via Java: lägg till, kom åt, ta bort och byt namn på avsnitt med Python‑kodexempel."
---
Exempel på hantering av presentationsavsnitt—lägga till, komma åt, ta bort och byta namn på dem programatiskt med **Aspose.Slides for Python via Java**.

Installera paketet enligt beskrivningen i [Installation](/slides/sv/python-java/installation/). Varje exempel importerar `asposeslides` innan JVM startas, och importerar sedan API:et när JVM körs.

## **Lägg till ett avsnitt**

Skapa ett avsnitt som börjar på en specifik bild.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Ange den bild som markerar början av avsnittet.
    presentation.getSections().addSection("New Section", slide)
finally:
    presentation.dispose()
```

## **Kom åt ett avsnitt**

Läs avsnittsinformation från en presentation.

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

    # Åtkomst till ett avsnitt via index.
    section = presentation.getSections().get_Item(0)
    section_name = section.getName()
    print(section_name)
finally:
    presentation.dispose()
```

## **Ta bort ett avsnitt**

Ta bort ett tidigare tillagt avsnitt.

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

    # Ta bort det första avsnittet.
    presentation.getSections().removeSection(section)
finally:
    presentation.dispose()
```

## **Byt namn på ett avsnitt**

Ändra namnet på ett befintligt avsnitt.

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