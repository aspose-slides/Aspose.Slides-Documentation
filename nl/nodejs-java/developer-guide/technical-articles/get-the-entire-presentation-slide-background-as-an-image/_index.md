---
title: De gehele dia-achtergrond uit een presentatie als afbeelding ophalen
linktitle: Gehele dia-achtergrond
type: docs
weight: 95
url: /nl/nodejs-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- dia-achtergrond
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Exporteer volledige dia-achtergronden als afbeeldingen uit PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Node.js via Java, en stroomlijn visuele workflows."
---
## **Overzicht**

In PowerPoint‑presentaties kan een dia‑achtergrond bestaan uit meerdere elementen, waaronder de afbeelding van de dia‑achtergrond, het presentatiethema, het kleurenpalet en objecten die op de meester‑dia of lay‑out‑dia geplaatst zijn.

Dit artikel laat zien hoe je de volledige dia‑achtergrond als afbeelding kunt extraheren met Aspose.Slides. Omdat er geen enkele methode voor deze taak bestaat, omvat de aanpak het klonen van de geselecteerde dia naar een tijdelijke presentatie, het verwijderen van de dia‑vormen en vervolgens het omzetten van de resulterende dia‑achtergrond naar een afbeelding.

## **Haal de volledige dia‑achtergrond op**

Aspose.Slides for Node.js via Java biedt geen eenvoudige methode om de volledige dia‑achtergrond van een presentatie als afbeelding te extraheren, maar je kunt de onderstaande stappen volgen om dit te doen:
1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
1. Haal de dia‑grootte op uit de presentatie.
1. Selecteer een dia.
1. Maak een tijdelijke presentatie aan.
1. Stel dezelfde dia‑grootte in voor de tijdelijke presentatie.
1. Kloon de geselecteerde dia naar de tijdelijke presentatie.
1. Verwijder de vormen van de gekloonde dia.
1. Converteer de gekloonde dia naar een afbeelding.

De onderstaande code‑voorbeeld extraheert de volledige dia‑achtergrond van de presentatie als afbeelding.
```javascript
var slideIndex = 0;
var imageScale = 1;
var presentation = new aspose.slides.Presentation("sample.pptx");
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);
var tempPresentation = new aspose.slides.Presentation();
var slideWidth = slideSize.getWidth();
var slideHeight = slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();
var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", aspose.slides.ImageFormat.Png);
tempPresentation.dispose();
presentation.dispose();
```

## **Veelgestelde vragen**

**Worden complexe kleurverlopen, texturen of afbeeldingvullingen van een meester‑dia behouden in de resulterende achtergrondafbeelding?**

Ja. Aspose.Slides rendert kleurverlopen, afbeelding‑ en textuurvullingen die op de dia, lay‑out of meester zijn gedefinieerd. Als je het uiterlijk wilt isoleren van overgeërfde meesters, [stel een eigen achtergrond](/slides/nl/nodejs-java/presentation-background/) in voor de huidige dia vóór het exporteren.

**Kan ik een watermerk toevoegen aan de resulterende achtergrondafbeelding voordat ik deze opsla?**

Ja. Je kunt een [watermerk](/slides/nl/nodejs-java/watermark/) vorm of afbeelding toevoegen op een werkende [kopie van de dia](/slides/nl/nodejs-java/clone-slides/) (achter andere inhoud geplaatst) en vervolgens exporteren. Zo kun je een achtergrondafbeelding genereren met het watermerk erin verwerkt.

**Kan ik de achtergrond van een specifieke lay‑out of meester ophalen zonder deze te koppelen aan een bestaande dia?**

Ja. Open de gewenste meester of lay‑out, pas deze toe op een [tijdelijke dia](/slides/nl/nodejs-java/clone-slides/) met de benodigde grootte, en exporteer die dia om de achtergrond te verkrijgen die is afgeleid van die lay‑out of meester.

**Zijn er licentie‑beperkingen die van invloed zijn op het exporteren van afbeeldingen?**

Render‑functies zijn volledig beschikbaar met een [geldige licentie](/slides/nl/nodejs-java/licensing/). In evalutiemodus kan de uitvoer beperkingen bevatten, zoals een watermerk. Activeer de licentie één keer per proces voordat je batch‑exporten uitvoert.