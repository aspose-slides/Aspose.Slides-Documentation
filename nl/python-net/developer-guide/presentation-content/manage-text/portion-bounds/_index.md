---
title: Tekstgedeelte grenzen ophalen uit presentaties in Python
linktitle: Gedeelte Grenzen
type: docs
weight: 47
url: /nl/python-net/portion-bounds/
keywords:
- tekstgedeelte grenzen
- tekstgedeelte
- tekstdeel
- tekstcoördinaten
- tekstpositie
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u tekstgedeelte grenzen kunt ophalen in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Python via .NET."
---
## **Overzicht**

Een tekstgedeelte vertegenwoordigt een specifiek fragment tekst binnen een paragraaf en stelt u in staat om met dat fragment onafhankelijk van de omliggende inhoud te werken. In Aspose.Slides kunnen gedeelten worden gebruikt wanneer u de grenzen van een tekstfragment moet ophalen, opmaak alleen op een deel van een paragraaf toepassen, of het tekstgedrag op een meer gedetailleerd niveau beheersen. Dit artikel laat zien hoe u de begrenzende rechthoek van een gedeelte kunt ophalen met behulp van [Portion.get_rect](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/get_rect/). Het laat ook zien hoe u de coördinaten van het begin van een gedeelte kunt verkrijgen met behulp van [Portion.get_coordinates](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/get_coordinates/). Daarnaast belicht het veelvoorkomende scenario's met betrekking tot gedeelten, zoals het toepassen van een hyperlink op een enkel tekstfragment, het begrijpen van hoe opmaak wordt opgelost via gedeelte, paragraaf, tekstframe en thema‑erfenis, en het behandelen van gevallen waarin een opgegeven lettertype niet beschikbaar is.

## **Grenzen van een tekstgedeelte ophalen**

Gebruik [Portion.get_rect](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/get_rect/) om de begrenzende rechthoek van een tekstgedeelte op te halen:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            rectangle = portion.get_rect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
```

## **Coördinaten van een tekstgedeelte ophalen**

Gebruik [Portion.get_coordinates](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/get_coordinates/) om de coördinaten van het begin van een tekstgedeelte op te halen:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print(f"X = {point.x}; Y = {point.y}")
```

## **FAQ**

**Kan ik een hyperlink alleen op een deel van de tekst binnen één paragraaf toepassen?**

Ja, u kunt een [een hyperlink toewijzen](/slides/nl/python-net/manage-hyperlinks/) aan een individueel gedeelte; alleen dat fragment zal klikbaar zijn, niet de gehele paragraaf.

**Hoe werkt stijl‑overerving: wat overschrijft een gedeelte, en wat wordt genomen van een paragraaf of tekstframe?**

Eigenschappen op gedeelte‑niveau hebben de hoogste prioriteit. Als een eigenschap niet is ingesteld op de [Portion](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/), neemt Aspose.Slides deze van de [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/). Als deze daar ook niet is ingesteld, gebruikt Aspose.Slides de stijl van het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) of het [theme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/theme/) .

**Wat gebeurt er als het opgegeven lettertype voor een gedeelte ontbreekt op de doelmachine of server?**

[Lettertype‑vervangingsregels](/slides/nl/python-net/font-selection-sequence/) worden toegepast. De tekst kan opnieuw worden opgemaakt: metriek, afbreking en breedte kunnen wijzigen, wat van belang is voor precieze positionering.

**Kan ik transparantie of een verloop voor tekstvulling specifiek voor een gedeelte instellen, onafhankelijk van de rest van de paragraaf?**

Ja, tekstkleur, vulling en transparantie op de [Portion](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/) -niveau kunnen verschillen van naastgelegen fragmenten.