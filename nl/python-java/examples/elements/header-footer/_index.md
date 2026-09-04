---
title: Koptekst en voettekst
type: docs
weight: 220
url: /nl/python-java/examples/elements/header-footer/
keywords:
- codevoorbeeld
- koptekst
- voettekst
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Beheer dia-koppen en -voetteksten met Aspose.Slides voor Python via Java: voeg datums, paginanummers en aangepaste tekst toe in PPT-, PPTX- en ODP-presentaties."
---
Dit artikel laat zien hoe u voetteksten kunt toevoegen en datum- en tijds-plaatsaanduidingen kunt bijwerken met **Aspose.Slides for Python via Java**.

Installeer het pakket zoals beschreven in [Installation](/slides/nl/python-java/installation/). Elk voorbeeld importeert `asposeslides` voordat de JVM wordt gestart, en importeert vervolgens de API nadat de JVM actief is.

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

Wijzig de datum- en tijds-plaatsaanduiding op een dia.

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