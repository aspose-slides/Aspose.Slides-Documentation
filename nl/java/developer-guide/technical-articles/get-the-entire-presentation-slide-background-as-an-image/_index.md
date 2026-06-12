---
title: Haal de volledige dia‑achtergrond van een presentatie op als afbeelding
linktitle: Volledige dia‑achtergrond
type: docs
weight: 95
url: /nl/java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- dia‑achtergrond
- definitieve achtergrond
- achtergrond extraheren
- volledige achtergrond
- achtergrond naar afbeelding
- PPT‑achtergrond
- PPTX‑achtergrond
- ODP‑achtergrond
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Extraheer volledige dia‑achtergronden als afbeeldingen uit PowerPoint- en OpenDocument‑presentaties met Aspose.Slides voor Java, waardoor visuele workflows worden gestroomlijnd."
---
## **Overzicht**

In PowerPoint‑presentaties kan een dia‑achtergrond bestaan uit meerdere elementen, waaronder de dia‑achtergrondafbeelding, het presentatiethema, het kleurenpalet en objecten die op de master‑dia of lay‑out‑dia zijn geplaatst.

Dit artikel laat zien hoe u de volledige dia‑achtergrond als afbeelding kunt extraheren met Aspose.Slides voor .NET. Omdat er geen enkele methode bestaat voor deze taak, bestaat de benadering uit het klonen van de geselecteerde dia naar een tijdelijke presentatie, het verwijderen van de dia‑vormen en vervolgens het converteren van de resulterende dia‑achtergrond naar een afbeelding.

## **De volledige dia‑achtergrond ophalen**

Aspose.Slides voor Java biedt geen eenvoudige methode om de volledige presentatie‑dia‑achtergrond als afbeelding te extraheren, maar u kunt de onderstaande stappen volgen om dit te doen:
1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse.
1. Haal de dia‑grootte op uit de presentatie.
1. Selecteer een dia.
1. Maak een tijdelijke presentatie.
1. Stel dezelfde dia‑grootte in voor de tijdelijke presentatie.
1. Clone de geselecteerde dia naar de tijdelijke presentatie.
1. Verwijder de vormen van de gekloonde dia.
1. Converteer de gekloonde dia naar een afbeelding.

De volgende code‑voorbeeld extrahert de volledige presentatie‑dia‑achtergrond als afbeelding.
```java
var slideIndex = 0;
var imageScale = 1;

var presentation = new Presentation("sample.pptx");

var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);

var tempPresentation = new Presentation();

var slideWidth = (float)slideSize.getWidth();
var slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```

## **FAQ**

**Worden complexe kleurverlopen, texturen of afbeeldingvullingen van een master‑dia bewaard in de resulterende achtergrondafbeelding?**

Ja. Aspose.Slides rendert kleurverloop‑, afbeelding‑ en textuurvullingen die zijn gedefinieerd op de dia, lay‑out of master. Als u de look wilt isoleren van overerfde masters, [een eigen achtergrond instellen](/slides/nl/java/presentation-background/) op de huidige dia vóór het exporteren.

**Kan ik een watermerk toevoegen aan de resulterende achtergrondafbeelding voordat ik deze opsla?**

Ja. U kunt een [watermerk](/slides/nl/java/watermark/) vorm of afbeelding toevoegen op een werkende [kopie van de dia](/slides/nl/java/clone-slides/) (achter andere inhoud geplaatst) en vervolgens exporteren. Hierdoor krijgt u een achtergrondafbeelding met het watermerk ingebakken.

**Kan ik de achtergrond voor een specifieke lay‑out of master ophalen zonder deze aan een bestaande dia te koppelen?**

Ja. Open de gewenste master of lay‑out, pas deze toe op een [tijdelijke dia](/slides/nl/java/clone-slides/) met de benodigde grootte, en exporteer die dia om de achtergrond af te leiden van die lay‑out of master.

**Zijn er licentiebeperkingen die van invloed zijn op het exporteren van afbeeldingen?**

Render‑functies zijn volledig beschikbaar met een [geldige licentie](/slides/nl/java/licensing/). In de evaluatiemodus kan de output beperkingen bevatten, zoals een watermerk. Activeer de licentie één keer per proces voordat u batch‑exporten uitvoert.