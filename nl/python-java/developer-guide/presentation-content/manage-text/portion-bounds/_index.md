---
title: Tekstdeelgrenzen opvragen uit presentaties in Python via Java
linktitle: Deelgrenzen
type: docs
weight: 47
url: /nl/python-java/portion-bounds/
keywords:
- tekstdeelgrenzen
- tekstdeel
- tekstonderdeel
- tekstcoördinaten
- tekstpositie
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u tekstdeelgrenzen kunt ophalen in PowerPoint-presentaties met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Een tekstdeel (portion) vertegenwoordigt een specifiek fragment van tekst binnen een alinea en stelt je in staat om met dat fragment onafhankelijk van de omliggende inhoud te werken. In Aspose.Slides kunnen delen worden gebruikt wanneer je de grenzen van een tekstfragment wilt opvragen, opmaak alleen op een deel van een alinea wilt toepassen, of het gedrag van tekst op een gedetailleerder niveau wilt beheren.

Dit artikel laat zien hoe je de begrenzende rechthoek van een deel kunt verkrijgen met [Portion.getRect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/#getRect). Het laat ook zien hoe je de coördinaten van het begin van een deel kunt verkrijgen met [Portion.getCoordinates](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/#getCoordinates). Bovendien worden veelvoorkomende scenario’s rondom delen belicht, zoals het toepassen van een hyperlink op een enkel tekstfragment, inzicht in hoe opmaak wordt overgeërfd via deel, alinea, tekstframe en thema, en het omgaan met gevallen waarin een opgegeven lettertype niet beschikbaar is.

## **Begrenzing van een tekstdeel opvragen**

Gebruik [Portion.getRect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/#getRect) om de begrenzende rechthoek van een tekstdeel op te halen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            rectangle = portion.getRect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
finally:
    presentation.dispose()
```

## **Coördinaten van een tekstdeel opvragen**

Gebruik [Portion.getCoordinates](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/#getCoordinates) om de coördinaten van het begin van een tekstdeel op te halen:

```python
import jpade
import asposeslides

if not jpade.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            point = portion.getCoordinates()
            print(f"X = {point.x}; Y = {point.y}")
finally:
    presentation.dispose()
```

## **Veelgestelde vragen**

**Kan ik een hyperlink toepassen op slechts een deel van de tekst binnen één alinea?**

Ja, je kunt [een hyperlink toewijzen](/slides/nl/python-java/manage-hyperlinks/) aan een individueel deel; alleen dat fragment is klikbaar, niet de hele alinea.

**Hoe werkt stijl‑overerving: wat overschrijft een deel, en wat wordt overgenomen van een alinea of tekstframe?**

Eigenschappen op deel‑niveau hebben de hoogste prioriteit. Als een eigenschap niet is ingesteld op de [Portion](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/), haalt Aspose.Slides deze van de [Paragraph](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/). Als die er ook niet staat, gebruikt Aspose.Slides de stijl van het [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/) of van het [theme](https://reference.aspose.com/slides/nl/python-java/aspose.slides/theme/).

**Wat gebeurt er als het opgegeven lettertype voor een deel ontbreekt op de doelmachine of server?**

[Lettertype‑vervangingsregels](/slides/nl/python-java/font-selection-sequence/) worden toegepast. De tekst kan opnieuw worden gerangschikt: maten, afbreking en breedte kunnen veranderen, wat van belang is voor precieze positionering.

**Kan ik een deel‑specifieke tekstvulling, transparantie of een verloop instellen onafhankelijk van de rest van de alinea?**

Ja, tekstkleur, vulling en transparantie op [Portion](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/)-niveau kunnen afwijken van aangrenzende fragmenten.