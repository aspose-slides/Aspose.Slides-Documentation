---
title: SmartArt
type: docs
weight: 140
url: /nl/python-java/examples/elements/smart-art/
keywords:
- codevoorbeeld
- SmartArt
- SmartArt toevoegen
- SmartArt benaderen
- SmartArt verwijderen
- SmartArt lay-out
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Werk met SmartArt in Aspose.Slides for Python via Java: voeg toe, benader, verwijder en wijzig diagramlay-outs in PowerPoint- en OpenDocument-presentaties."
---
Dit artikel toont hoe u SmartArt‑grafieken kunt toevoegen, benaderen, verwijderen en lay‑outs kunt wijzigen met **Aspose.Slides for Python via Java**.

Installeer het pakket zoals beschreven in [Installatie](/slides/nl/python-java/installation/). Elk voorbeeld importeert `asposeslides` voordat de JVM wordt gestart, en importeert vervolgens de API nadat de JVM draait.

## **SmartArt toevoegen**

Voeg een SmartArt‑afbeelding in met een van de ingebouwde lay‑outs.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)
finally:
    presentation.dispose()
```

## **SmartArt benaderen**

Haal het eerste SmartArt‑object op van een dia.

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    first_smart_art = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, SmartArt):
            first_smart_art = shape
            break
finally:
    presentation.dispose()
```

## **SmartArt verwijderen**

Verwijder een SmartArt‑vorm van de dia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    slide.getShapes().remove(smart_art)
finally:
    presentation.dispose()
```

## **SmartArt lay‑out wijzigen**

Werk het lay‑outtype bij van een bestaande SmartArt‑afbeelding.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.VerticalPictureList)
finally:
    presentation.dispose()
```