---
title: Koptekst en Voettekst
type: docs
weight: 220
url: /nl/python-java/examples/elements/header-footer/
keywords:
- code voorbeeld
- koptekst
- voettekst
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Beheer dia-kopteksten en -voetteksten met Aspose.Slides for Python via Java: voeg datum, dia-nummers en aangepaste tekst toe in PPT-, PPTX- en ODP-presentaties."
---
Dit artikel toont hoe u voetteksten kunt toevoegen en datum- en tijd-plaatsaanduidingen kunt bijwerken met **Aspose.Slides for Python via Java**.

Installeer het pakket zoals beschreven in [Installation](/slides/nl/python-java/installation/). Elk voorbeeld importeert `asposeslides` voordat de JVM wordt gestart, en importeert vervolgens de API nadat de JVM draait.

## **Voettekst toevoegen**

Voeg tekst toe aan het voettekstgebied van een dia en maak deze zichtbaar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setFooterText("My footer")
    slide.getHeaderFooterManager().setFooterVisibility(True)
finally:
    presentation.dispose()
```

## **Datum en tijd bijwerken**

Pas de datum- en tijd-plaatsaanduiding op een dia aan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setDateTimeText("01/01/2024")
    slide.getHeaderFooterManager().setDateTimeVisibility(True)
finally:
    presentation.dispose()
```