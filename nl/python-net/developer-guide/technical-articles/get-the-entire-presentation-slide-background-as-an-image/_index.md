---
title: De volledige dia‑achtergrond van een presentatie als afbeelding ophalen
linktitle: Volledige dia‑achtergrond
type: docs
weight: 95
url: /nl/python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- dia
- achtergrond
- dia‑achtergrond
- uiteindelijke achtergrond
- achtergrond naar afbeelding
- PowerPoint
- OpenDocument
- presentatie
- PPT
- PPTX
- ODP
- Python
- Aspose.Slides
description: "Extraheer volledige dia‑achtergronden als afbeeldingen uit PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor Python via .NET, waardoor visuele workflows worden geoptimaliseerd."
---
## **Overzicht**

In PowerPoint‑presentaties kan de achtergrond van een dia bestaan uit meerdere elementen, waaronder de dia‑achtergrondafbeelding, het presentatiethema, het kleurschema en objecten die op de master‑dia of lay‑out‑dia zijn geplaatst.

Dit artikel laat zien hoe u de volledige dia‑achtergrond als afbeelding kunt extraheren met Aspose.Slides. Omdat er geen enkele methode voor deze taak bestaat, bestaat de aanpak uit het klonen van de geselecteerde dia naar een tijdelijke presentatie, het verwijderen van de vormelementen van de dia, en vervolgens het omzetten van de resulterende dia‑achtergrond naar een afbeelding.

## **Verkrijg de volledige dia‑achtergrond**

Aspose.Slides voor Python biedt geen eenvoudige methode om de volledige presentatiedia‑achtergrond als afbeelding te extraheren, maar u kunt de volgende stappen volgen om dit te doen:
1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal de dia‑grootte op uit de presentatie.
1. Selecteer een dia.
1. Maak een tijdelijke presentatie aan.
1. Stel dezelfde dia‑grootte in voor de tijdelijke presentatie.
1. Kloon de geselecteerde dia naar de tijdelijke presentatie.
1. Verwijder de vormen van de gekloonde dia.
1. Converteer de gekloonde dia naar een afbeelding.

Het onderstaande code‑voorbeeld extrahert de volledige presentatiedia‑achtergrond als afbeelding.
```py
slide_index = 0
image_scale = 1

with slides.Presentation("sample.pptx") as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[slide_index]

    with slides.Presentation() as temp_presentation:
        temp_presentation.slide_size.set_size(
            slide_size.width, slide_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)

        cloned_slide = temp_presentation.slides.add_clone(slide)
        cloned_slide.shapes.clear()

        with cloned_slide.get_image(image_scale, image_scale) as background:
            background.save("output.png", slides.ImageFormat.PNG)
```

## **FAQ**

**Worden complexe verlopen, texturen of foto‑vullingen van een master‑dia behouden in de resulterende achtergrondafbeelding?**

Ja. Aspose.Slides rendert verloop‑, foto‑ en textuurvullingen die op de dia, lay‑out of master zijn gedefinieerd. Als u de weergave wilt isoleren van geërfde masters, [stel een eigen achtergrond](/slides/nl/python-net/presentation-background/) in op de huidige dia vóór het exporteren.

**Kan ik een watermerk toevoegen aan de resulterende achtergrondafbeelding voordat ik deze opsla?**

Ja. U kunt een [watermerk](/slides/nl/python-net/watermark/) vorm of afbeelding toevoegen op een werkende [kopie van de dia](/slides/nl/python-net/clone-slides/) (achter andere inhoud geplaatst) en vervolgens exporteren. Daarmee kunt u een achtergrondafbeelding genereren met het watermerk er permanent in verwerkt.

**Kan ik de achtergrond verkrijgen voor een specifiek lay‑out of master zonder deze aan een bestaande dia te koppelen?**

Ja. Open de gewenste master of lay‑out, pas deze toe op een [tijdelijke dia](/slides/nl/python-net/clone-slides/) met de vereiste afmetingen, en exporteer die dia om de achtergrond te verkrijgen die uit die lay‑out of master is afgeleid.

**Zijn er licentiebeperkingen die van invloed zijn op het exporteren van afbeeldingen?**

Render‑functies zijn volledig beschikbaar met een [geldige licentie](/slides/nl/python-net/licensing/). In de evaluatiemodus kan de uitvoer beperkingen bevatten, zoals een watermerk. Activeer de licentie één keer per proces voordat u batch‑exporten uitvoert.