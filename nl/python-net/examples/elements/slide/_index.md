---
title: Dia
type: docs
weight: 10
url: /nl/python-net/examples/elements/slide/
keywords:
- dia
- dia toevoegen
- dia benaderen
- dia-index
- dia klonen
- dia's herschikken
- dia verwijderen
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Dia's beheren in Python met Aspose.Slides: maken, klonen, herschikken, verbergen, achtergronden en afmetingen instellen, overgangen toepassen en exporteren voor PowerPoint en OpenDocument."
---
Dit artikel biedt een reeks voorbeelden die laten zien hoe u met dia's kunt werken met **Aspose.Slides for Python via .NET**. U leert hoe u dia's kunt toevoegen, benaderen, klonen, herschikken en verwijderen met behulp van de `Presentation`‑klasse.

Elk voorbeeld hieronder bevat een korte uitleg gevolgd door een codefragment in Python.

## **Dia toevoegen**

Om een nieuwe dia toe te voegen, moet u eerst een lay-out selecteren. In dit voorbeeld gebruiken we de `Blank` lay-out en voegen we een lege dia toe aan de presentatie.

```py
def add_slide():
    with slides.Presentation() as presentation:
        # Elke dia is gebaseerd op een lay-out, die zelf gebaseerd is op een masterdia.
        # Gebruik de lege lay-out om een nieuwe dia te maken.
        blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Voeg een nieuwe lege dia toe met de gekozen lay-out.
        presentation.slides.add_empty_slide(blank_layout)

        presentation.save("slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip:** Elke dia‑lay-out is afgeleid van een masterdia, die het algehele ontwerp en de placeholder‑structuur definieert. De afbeelding hieronder illustreert hoe masterdia's en hun bijbehorende lay-outs georganiseerd zijn in PowerPoint.

![Relatie tussen master en lay-out](master-layout-slide.png)

## **Dia's benaderen op index**

U kunt dia's benaderen met behulp van hun index. Dit is handig om door dia's te itereren of specifieke dia's te wijzigen.

```py
def access_slide():
    with slides.Presentation("slide.pptx") as presentation:
        # Dia benaderen op index.
        first_slide = presentation.slides[0]
```

## **Dia klonen**

Dit voorbeeld laat zien hoe u een bestaande dia kunt klonen. De gekloonde dia wordt automatisch aan het einde van de dia‑collectie toegevoegd.

```py
def clone_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Kloon de dia; hij wordt toegevoegd aan het einde van de presentatie.
        cloned_slide = presentation.slides.add_clone(slide)

        presentation.save("slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

## **Dia's herschikken**

U kunt de volgorde van dia's wijzigen door er één naar een nieuwe index te verplaatsen. In dit geval verplaatsen we een dia naar de eerste positie.

```py
def reorder_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[1]

        # Verplaats de dia naar de eerste positie (andere verschuiven omlaag).
        presentation.slides.reorder(0, slide)

        presentation.save("slide_reordered.pptx", slides.export.SaveFormat.PPTX)
```

## **Dia verwijderen**

Om een dia te verwijderen, verwijst u er eenvoudignaar en roept u `remove` aan. Dit voorbeeld verwijdert de eerste dia.

```py
def remove_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Verwijder de dia.
        presentation.slides.remove(slide)

        presentation.save("slide_removed.pptx", slides.export.SaveFormat.PPTX)
```