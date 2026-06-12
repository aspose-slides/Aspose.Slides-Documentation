---
title: Beheer tekstgedeelten in presentaties met Python
linktitle: Tekstgedeelte
type: docs
weight: 70
url: /nl/python-net/portion/
keywords:
- tekstgedeelte
- tekstdeel
- tekstcoördinaten
- tekstpositie
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u tekstgedeelten kunt beheren in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Python via .NET, waardoor de prestaties en maatwerkverbeterd worden."
---
## **Inleiding**

Een tekstgedeelte vertegenwoordigt een specifiek fragment tekst binnen een alinea en stelt je in staat om met dat fragment onafhankelijk van de omringende inhoud te werken. In Aspose.Slides kunnen gedeelten worden gebruikt wanneer je de positie van een tekstfragment moet opvragen, opmaak alleen op een deel van een alinea moet toepassen, of het gedrag van tekst op een gedetailleerder niveau moet controleren.

## **Coördinaten van Tekstgedeelten Opvragen**

De [get_coordinates](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/get_coordinates/) methode is toegevoegd aan de [Portion](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/) klasse, die het ophalen van de coördinaten van tekstgedeelten mogelijk maakt:

```py
import aspose.slides as slides

with slides.Presentation("HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame = shape.text_frame

    for paragraph in text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Corrdinates X =" + str(point.x) + " Corrdinates Y =" + str(point.y))
```

## **FAQ**

**Kan ik een hyperlink toepassen op slechts een deel van de tekst binnen één alinea?**

Ja, je kunt een [hyperlink toewijzen](/slides/nl/python-net/manage-hyperlinks/) aan een individueel gedeelte; alleen dat fragment zal aanklikbaar zijn, niet de hele alinea.

**Hoe werkt stijl‑overerving: wat overschrijft een Portion en wat wordt overgenomen van Paragraph/TextFrame?**

Eigenschappen op Portion‑niveau hebben de hoogste prioriteit. Als een eigenschap niet is ingesteld op de [Portion](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/), neemt de engine deze over van de [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/); als deze daar ook niet is ingesteld, van de [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) of van de stijl van het [theme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/theme/).

**Wat gebeurt er als het voor een Portion opgegeven lettertype ontbreekt op de doelmachine/server?**

[Lettertypevervangingsregels](/slides/nl/python-net/font-selection-sequence/) worden toegepast. De tekst kan opnieuw worden opgemaakt: metriek, afbreking en breedte kunnen veranderen, wat van belang is voor nauwkeurige positionering.

**Kan ik een op Portion specifieke tekstvulling, transparantie of gradient instellen, onafhankelijk van de rest van de alinea?**

Ja, tekstopmaak, vulling en transparantie op het [Portion](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/) niveau kunnen afwijken van aangrenzende fragmenten.