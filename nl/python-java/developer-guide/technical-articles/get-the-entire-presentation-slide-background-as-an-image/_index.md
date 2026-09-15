---
title: De volledige slide-achtergrond uit een presentatie als afbeelding ophalen
linktitle: Complete slide-achtergrond
type: docs
weight: 95
url: /nl/python-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- slide-achtergrond
- definitieve achtergrond
- achtergrond extraheren
- volledige achtergrond
- achtergrond naar afbeelding
- PPT-achtergrond
- PPTX-achtergrond
- ODP-achtergrond
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Exporteer volledige slide-achtergronden als afbeeldingen uit PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Python via Java, waardoor visuele werkstromen worden vereenvoudigd."
---
## **Overzicht**

In PowerPoint‑presentaties kan een slide‑achtergrond bestaan uit meerdere elementen, waaronder de slide‑achtergrondafbeelding, het presentatiethema, het kleurenschema en objecten die op de master‑slide of layout‑slide geplaatst zijn.

Dit artikel laat zien hoe u de volledige slide‑achtergrond kunt extraheren als afbeelding met Aspose.Slides for Python via Java. Omdat er geen enkele methode bestaat voor deze taak, omvat de aanpak het klonen van de geselecteerde slide naar een tijdelijke presentatie, het verwijderen van de slide‑vormen en vervolgens het omzetten van de resulterende slide‑achtergrond naar een afbeelding.

## **De volledige slide‑achtergrond ophalen**

Aspose.Slides for Python via Java biedt geen eenvoudige methode om de volledige slide‑achtergrond van een presentatie als afbeelding te extraheren, maar u kunt de onderstaande stappen volgen om dit te doen:

1. Laad de presentatie met de [Presentatie](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.
1. Haal de slide‑grootte op uit de presentatie.
1. Selecteer een slide.
1. Maak een tijdelijke presentatie.
1. Stel dezelfde slide‑grootte in op de tijdelijke presentatie.
1. Kloon de geselecteerde slide naar de tijdelijke presentatie.
1. Verwijder de vormen van de gekloonde slide.
1. Zet de gekloonde slide om naar een afbeelding.

De volgende code‑voorbeeld extraheert de volledige slide‑achtergrond van de presentatie als afbeelding.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, ImageFormat

slide_index = 0
image_scale = 1.0

presentation = Presentation("sample.pptx")
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(slide_index)

    temp_presentation = Presentation()
    try:
        slide_width = jpype.JFloat(slide_size.getWidth())
        slide_height = jpype.JFloat(slide_size.getHeight())
        temp_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)

        cloned_slide = temp_presentation.getSlides().addClone(slide)
        cloned_slide.getShapes().clear()

        background = cloned_slide.getImage(image_scale, image_scale)
        try:
            background.save("output.png", ImageFormat.Png)
        finally:
            background.dispose()
    finally:
        temp_presentation.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Worden complexe verlopen, texturen of afbeeldingvullingen van een master‑slide behouden in de resulterende achtergrondafbeelding?**

Ja. Aspose.Slides rendert verloop‑, afbeelding‑ en textuurvullingen die op de slide, lay‑out of master gedefinieerd zijn. Als u het uiterlijk wilt isoleren van geërfde masters, [stel een aangepaste achtergrond](/slides/nl/python-java/presentation-background/) in op de huidige slide vóór het exporteren.

**Kan ik een watermerk toevoegen aan de resulterende achtergrondafbeelding vóór het opslaan?**

Ja. U kunt een watermerkvorm of -afbeelding toevoegen op een werkende [kopie van de slide](/slides/nl/python-java/clone-slides/) (achter andere inhoud geplaatst) en daarna exporteren. Hiermee genereert u een achtergrondafbeelding met het watermerk ingebakken.

**Kan ik de achtergrond van een specifieke lay‑out of master ophalen zonder deze te koppelen aan een bestaande slide?**

Ja. Toegang tot de gewenste master of lay‑out, pas deze toe op een [tijdelijke slide](/slides/nl/python-java/clone-slides/) met de vereiste grootte, en exporteer die slide om de van die lay‑out of master afgeleide achtergrond te verkrijgen.

**Zijn er licentie‑beperkingen die van invloed zijn op het exporteren van afbeeldingen?**

Render‑functies zijn volledig beschikbaar met een [geldige licentie](/slides/nl/python-java/licensing/). In evaluatiemodus kan de uitvoer beperkingen bevatten, zoals een watermerk. Activeer de licentie éénmaal per proces vóór het uitvoeren van batch‑exporten.