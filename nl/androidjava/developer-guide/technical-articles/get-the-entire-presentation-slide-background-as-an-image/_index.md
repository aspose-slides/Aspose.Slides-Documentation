---
title: Haal de volledige dia-achtergrond uit een presentatie op als afbeelding
linktitle: Volledige dia-achtergrond
type: docs
weight: 95
url: /nl/androidjava/get-the-entire-presentation-slide-background-as-an-image/
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
- Android
- Java
- Aspose.Slides
description: "Extraheer volledige dia-achtergronden als afbeeldingen uit PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Android via Java, en stroomlijn de visuele werkprocessen."
---
## **Overzicht**

In PowerPoint‑presentaties kan een dia‑achtergrond bestaan uit meerdere elementen, waaronder de afbeelding van de dia‑achtergrond, het presentatiethema, het kleurenpalet en objecten die op de master‑dia of lay‑out‑dia zijn geplaatst.

Dit artikel toont hoe u de volledige dia‑achtergrond als een afbeelding kunt extraheren met Aspose.Slides voor .NET. Omdat er geen enkele methode voor deze taak bestaat, omvat de aanpak het klonen van de geselecteerde dia naar een tijdelijke presentatie, het verwijderen van de vormen op de dia, en vervolgens het omzetten van de resulterende dia‑achtergrond naar een afbeelding.

## **Haal de volledige dia‑achtergrond op**

Aspose.Slides voor Android via Java biedt geen eenvoudige methode om de volledige dia‑achtergrond van een presentatie als afbeelding te extraheren, maar u kunt de onderstaande stappen volgen om dit te doen:
1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)-klasse.
1. Haal de dia‑grootte op uit de presentatie.
1. Selecteer een dia.
1. Maak een tijdelijke presentatie aan.
1. Stel dezelfde dia‑grootte in voor de tijdelijke presentatie.
1. Kloon de geselecteerde dia naar de tijdelijke presentatie.
1. Verwijder de vormen van de gekloonde dia.
1. Converteer de gekloonde dia naar een afbeelding.

Het volgende code‑voorbeeld haalt de volledige dia‑achtergrond van de presentatie op als afbeelding.
```java
int slideIndex = 0;
int imageScale = 1;

Presentation presentation = new Presentation("sample.pptx");

Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(slideIndex);

Presentation tempPresentation = new Presentation();

float slideWidth = (float)slideSize.getWidth();
float slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

ISlide clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

IImage background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```

## **FAQ**

**Zullen complexe verlopen, texturen of afbeeldingvullingen van een master‑dia behouden blijven in de resulterende achtergrondafbeelding?**

Ja. Aspose.Slides renderen gradient‑, afbeelding‑ en textuurvullingen die op de dia, lay‑out of master zijn gedefinieerd. Als u het uiterlijk wilt isoleren van overgeërfde masters, [set an own background](/slides/nl/androidjava/presentation-background/) op de huidige dia voordat u exporteert.

**Kan ik een watermerk toevoegen aan de resulterende achtergrondafbeelding voordat ik deze opsla?**

Ja. U kunt een [add a watermark](/slides/nl/androidjava/watermark/) vorm of afbeelding toevoegen op een werkende [copy of the slide](/slides/nl/androidjava/clone-slides/) (geplaatst achter andere inhoud) en vervolgens exporteren. Hiermee kunt u een achtergrondafbeelding genereren met het watermerk ingebakken.

**Kan ik de achtergrond voor een specifieke lay‑out of master krijgen zonder deze te koppelen aan een bestaande dia?**

Ja. Open de gewenste master of lay‑out, pas deze toe op een [temporary slide](/slides/nl/androidjava/clone-slides/) met de vereiste grootte, en exporteer die dia om de achtergrond te verkrijgen die is afgeleid van die lay‑out of master.

**Zijn er licentie‑beperkingen die van invloed zijn op het exporteren van afbeeldingen?**

Render‑features zijn volledig beschikbaar met een [valid license](/slides/nl/androidjava/licensing/). In evaluatiemodus kan de output beperkingen bevatten, zoals een watermerk. Activeer de licentie één keer per proces voordat u batch‑exports uitvoert.