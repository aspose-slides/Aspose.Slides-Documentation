---
title: Vergelijk presentatiedia's in Python
linktitle: Dia's vergelijken
type: docs
weight: 50
url: /nl/python-java/compare-slides/
keywords:
- dia's vergelijken
- dia-vergelijking
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Vergelijk PowerPoint- en OpenDocument-presentaties programmatically met Aspose.Slides voor Python via Java. Identificeer dia-verschillen in code snel."
---
## **Overzicht**

Aspose.Slides maakt het mogelijk om dia's, layoutdia's en masterdia's te vergelijken met behulp van de [equals](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/#equals) methode die wordt geleverd door de [BaseSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/) klasse. Deze methode retourneert `True` wanneer de vergeleken dia's identiek zijn in hun structuur en statische inhoud.

## **Twee dia's vergelijken**

De [equals](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/#equals) methode in de [BaseSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/) klasse retourneert `True` voor dia's, layoutdia's en masterdia's die identiek zijn in structuur en statische inhoud.

Twee dia's zijn gelijk als al hun vormen, stijlen, tekst, animaties en andere instellingen gelijk zijn. De vergelijking houdt geen rekening met unieke identificatiewaarden, zoals dia-IDs, of dynamische inhoud, zoals de huidige datum in een datum-plaatsaanduiding.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

source_presentation = Presentation("AccessSlides.pptx")
try:
    target_presentation = Presentation("HelloWorld.pptx")
    try:
        for i in range(source_presentation.getMasters().size()):
            for j in range(target_presentation.getMasters().size()):
                if source_presentation.getMasters().get_Item(i).equals(target_presentation.getMasters().get_Item(j)):
                    print(f"AccessSlides MasterSlide#{i} is equal to HelloWorld MasterSlide#{j}")
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Veelgestelde vragen**

**Heeft het feit dat een dia verborgen is invloed op de vergelijking van de dia's zelf?**

[Verborgen status](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getHidden) is een eigenschap op presentatieniveau/afspeelniveau, geen visuele inhoud. De gelijkheid van twee specifieke dia's wordt bepaald door hun structuur en statische inhoud; het feit dat een dia verborgen is, maakt de dia's niet verschillend.

**Worden hyperlinks en hun parameters in aanmerking genomen?**

Ja. Links maken deel uit van de statische inhoud van een dia. Als de URL of de hyperlink-actie verschilt, wordt dit doorgaans beschouwd als een verschil in de statische inhoud.

**Als een diagram verwijst naar een extern Excel-bestand, wordt de inhoud van dat bestand dan in aanmerking genomen?**

Nee. De vergelijking wordt uitgevoerd op basis van de dia's zelf. Externe gegevensbronnen worden meestal niet gelezen op het moment van vergelijken; alleen wat aanwezig is in de structuur en statische toestand van de dia wordt in overweging genomen.