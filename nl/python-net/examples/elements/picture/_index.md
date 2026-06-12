---
title: Afbeelding
type: docs
weight: 50
url: /nl/python-net/examples/elements/picture/
keywords:
- afbeelding
- afbeeldingsframe
- afbeelding toevoegen
- afbeelding benaderen
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Werken met afbeeldingen in Python met Aspose.Slides: invoegen, vervangen, bijsnijden, comprimeren, transparantie en effecten aanpassen, vormen vullen en exporteren naar PPT, PPTX en ODP."
---
Toont hoe je afbeeldingen kunt invoegen en benaderen vanuit in‑memory afbeeldingen met **Aspose.Slides for Python via .NET**. De onderstaande voorbeelden maken een afbeelding in het geheugen, plaatsen deze op een dia en halen hem vervolgens op.

## **Afbeelding toevoegen**

Deze code laadt een afbeelding van een bestand en voegt deze in als een afbeeldingsframe op de eerste dia.

```py
def add_picture():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Laad een afbeelding van een bestand.
        with open("image.png", "rb") as image_stream:
            # Voeg de afbeelding toe aan de presentatieresources.
            image = presentation.images.add_image(image_stream)

        # Voeg een afbeeldingsframe toe die de afbeelding toont op de eerste dia.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        presentation.save("picture.pptx", slides.export.SaveFormat.PPTX)
```

## **Afbeelding benaderen**

Dit voorbeeld controleert of een dia een afbeeldingsframe bevat en benadert vervolgens de eerste die gevonden wordt.

```py
def access_picture():
    with slides.Presentation("picture.pptx") as presentation:
        slide = presentation.slides[0]

        # Benader het eerste afbeeldingsframe op de dia.
        picture_frame = next(shape for shape in slide.shapes if isinstance(shape, slides.PictureFrame))
```