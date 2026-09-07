---
title: Sectie
type: docs
weight: 90
url: /nl/python-java/examples/elements/section/
keywords:
- codevoorbeeld
- sectie
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Beheer presentatiesecties in Aspose.Slides for Python via Java: voeg secties toe, open ze, verwijder ze en hernoem ze met Python‑codevoorbeelden."
---
Voorbeelden voor het beheren van presentatiesecties—toevoegen, openen, verwijderen en hernoemen via code met **Aspose.Slides for Python via Java**.

Installeer het pakket zoals beschreven in [Installation](/slides/nl/python-java/installation/). Elk voorbeeld importeert `asposeslides` voordat de JVM wordt gestart, en importeert vervolgens de API nadat de JVM draait.

## **Sectie toevoegen**

Maak een sectie aan die begint bij een specifieke dia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Specificeer de dia die het begin van de sectie aangeeft.
    presentation.getSections().addSection("New Section", slide)
finally:
    presentation.dispose()
```

## **Sectie openen**

Lees de sectie‑informatie uit een presentatie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("My Section", slide)

    # Toegang tot een sectie op index.
    section = presentation.getSections().get_Item(0)
    section_name = section.getName()
    print(section_name)
finally:
    presentation.dispose()
```

## **Sectie verwijderen**

Verwijder een eerder toegevoegde sectie.

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

    # Verwijder de eerste sectie.
    presentation.getSections().removeSection(section)
finally:
    presentation.dispose()
```

## **Sectie hernoemen**

Wijzig de naam van een bestaande sectie.

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