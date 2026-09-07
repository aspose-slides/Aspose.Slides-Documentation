---
title: Sekce
type: docs
weight: 90
url: /cs/python-java/examples/elements/section/
keywords:
- ukázka kódu
- sekce
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Spravujte sekce prezentace v Aspose.Slides for Python via Java: přidávejte, získávejte, odstraňujte a přejmenovávejte sekce pomocí příkladů kódu v Pythonu."
---
Příklady pro správu sekcí prezentace — přidávat, získávat, odstraňovat a přejmenovávat je programově pomocí **Aspose.Slides for Python via Java**.

Nainstalujte balíček podle popisu v [Installation](/slides/cs/python-java/installation/). Každý příklad načte `asposeslides` před spuštěním JVM a poté načte API po spuštění JVM.

## **Přidat sekci**

Vytvořte sekci, která začíná na konkrétním snímku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Určete snímek, který označuje začátek sekce.
    presentation.getSections().addSection("New Section", slide)
finally:
    presentation.dispose()
```

## **Přístup k sekci**

Přečtěte informace o sekci z prezentace.

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

    # Přístup k sekci podle indexu.
    section = presentation.getSections().get_Item(0)
    section_name = section.getName()
    print(section_name)
finally:
    presentation.dispose()
```

## **Odstranit sekci**

Odstraňte dříve přidanou sekci.

```python
import jpape
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    section = presentation.getSections().addSection("Temporary Section", slide)

    # Odeberte první sekci.
    presentation.getSections().removeSection(section)
finally:
    presentation.dispose()
```

## **Přejmenovat sekci**

Změňte název existující sekce.

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