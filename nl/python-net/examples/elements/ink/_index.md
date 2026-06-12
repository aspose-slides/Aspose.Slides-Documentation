---
title: Inkt
type: docs
weight: 180
url: /nl/python-net/examples/elements/ink/
keywords:
- inkt
- ink benaderen
- ink verwijderen
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Werk digitale inkt op dia's in Python met Aspose.Slides: voeg penstreken toe, bewerk paden, stel kleur en breedte in, en exporteer resultaten voor PowerPoint en OpenDocument."
---
Biedt voorbeelden van het benaderen van bestaande inkvormen en het verwijderen ervan met **Aspose.Slides for Python via .NET**.

> ❗ **Opmerking:** Inkvormen vertegenwoordigen gebruikersinvoer van gespecialiseerde apparaten. Aspose.Slides kan geen nieuwe inktstreken programmatig aanmaken, maar je kunt bestaande inkt lezen en aanpassen.

## **Toegang tot Inkt**

Haal de eerste inkvorm van een dia op.

```py
def access_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        first_ink = None
        for shape in slide.shapes:
            if isinstance(shape, slides.ink.Ink):
                first_ink = shape
                break
```

## **Inkt verwijderen**

Verwijder een inkvorm van de dia.

```py
def remove_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        # Aannemende dat de eerste vorm een Ink-object is.
        ink = slide.shapes[0]

        slide.shapes.remove(ink)

        presentation.save("ink_removed.pptx", slides.export.SaveFormat.PPTX)
```