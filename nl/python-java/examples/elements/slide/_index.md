---
title: Dia
type: docs
weight: 10
url: /nl/python-java/examples/elements/slide/
keywords:
- codevoorbeeld
- dia
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Beheer dia's in Aspose.Slides for Python via Java: voeg toe, benader, kloon, herschik en verwijder dia's met Python-codevoorbeelden voor PowerPoint- en OpenDocument-presentaties."
---
Dit artikel geeft voorbeelden die laten zien hoe u dia's kunt toevoegen, benaderen, klonen, herschikken en verwijderen met **Aspose.Slides for Python via Java**.

Installeer het pakket zoals beschreven in [Installation](/slides/nl/python-java/installation/). Elk voorbeeld importeert `asposeslides` voordat de JVM wordt gestart, en importeert daarna de API zodra de JVM draait.

## **Dia toevoegen**

Om een nieuwe dia toe te voegen, selecteert u eerst een indeling. Dit voorbeeld gebruikt een lege indeling om een lege dia aan de presentatie toe te voegen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    presentation.getSlides().addEmptySlide(blank_layout)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Elke dia‑indeling is afgeleid van een masterdia, die het algehele ontwerp en de tijdelijke‑plaatsstructuur definieert. De afbeelding hieronder illustreert hoe masterdia's en hun bijbehorende indelingen in PowerPoint zijn georganiseerd.
{{% /alert %}}

![Relatie tussen master en indeling](master-layout-slide.png)

## **Dia's benaderen op index**

Benader dia's met hun index die bij nul begint, of zoek de index van een dia op basis van een referentie. Dit is handig voor het itereren door of het wijzigen van specifieke dia's.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # Voeg nog een lege dia toe.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(blank_layout)

    # Benader dia's op index.
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().get_Item(1)

    # Haal de index van een dia op vanuit een referentie, en benader deze vervolgens op index.
    second_slide_index = presentation.getSlides().indexOf(second_slide)
    second_slide_by_index = presentation.getSlides().get_Item(second_slide_index)
finally:
    presentation.dispose()
```

## **Een dia klonen**

Kloon een bestaande dia. De gekloonde dia wordt automatisch toegevoegd aan het einde van de diacollectie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    cloned_slide_index = presentation.getSlides().indexOf(cloned_slide)
finally:
    presentation.dispose()
```

## **Dia's herschikken**

Wijzig de volgorde van dia's door er één naar een nieuwe index te verplaatsen. Dit voorbeeld verplaatst een gekloonde dia naar de eerste positie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    presentation.getSlides().reorder(0, cloned_slide)
finally:
    presentation.dispose()
```

## **Een dia verwijderen**

Verwijder een dia door zijn referentie door te geven aan de diacollectie. Dit voorbeeld voegt een tweede dia toe en verwijdert vervolgens de originele, zodat alleen de nieuwe overblijft.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    second_slide = presentation.getSlides().addEmptySlide(blank_layout)

    first_slide = presentation.getSlides().get_Item(0)
    presentation.getSlides().remove(first_slide)
finally:
    presentation.dispose()
```