---
title: SmartArt
type: docs
weight: 140
url: /nl/python-net/examples/elements/smart-art/
keywords:
- SmartArt
- SmartArt toevoegen
- SmartArt openen
- SmartArt verwijderen
- SmartArt lay-out
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Maak en bewerk SmartArt in Python met Aspose.Slides: voeg knooppunten toe, wijzig lay-outs en stijlen, converteer naar vormen met precisie, en exporteer naar PPT, PPTX en ODP."
---
Toont hoe je SmartArt-afbeeldingen kunt toevoegen, openen, verwijderen en lay-outs kunt wijzigen met **Aspose.Slides for Python via .NET**.

## **Add SmartArt**
Voeg een SmartArt-afbeelding in met behulp van een van de ingebouwde lay-outs.

```py
def add_smart_art():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        smart_art = slide.shapes.add_smart_art(50, 50, 400, 300, slides.smartart.SmartArtLayoutType.BASIC_PROCESS)

        presentation.save("smart_art.pptx", slides.export.SaveFormat.PPTX)
```

## **Access SmartArt**
Haal het eerste SmartArt-object op van een dia.

```py
def access_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Open de eerste SmartArt-vorm.
        first_smart_art = next(shape for shape in slide.shapes if isinstance(shape, slides.smartart.SmartArt))
```

## **Remove SmartArt**
Verwijder een SmartArt-vorm van de dia.

```py
def remove_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Aannemende dat de eerste vorm een SmartArt-object is.
        smart_art = slide.shapes[0]

        slide.shapes.remove(smart_art)

        presentation.save("smart_art_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Change SmartArt Layout**
Werk het type lay-out bij van een bestaande SmartArt-afbeelding.

```py
def change_smart_art_layout():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Aannemende dat de eerste vorm een SmartArt-object is.
        smart_art = slide.shapes[0]

        # Wijzig de SmartArt-lay-out.
        smart_art.layout = slides.smartart.SmartArtLayoutType.VERTICAL_PICTURE_LIST

        presentation.save("smart_art_changed.pptx", slides.export.SaveFormat.PPTX)
```