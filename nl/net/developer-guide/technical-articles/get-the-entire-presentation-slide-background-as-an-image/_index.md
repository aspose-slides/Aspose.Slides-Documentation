---
title: Verkrijg de volledige dia-achtergrond van een presentatie als afbeelding
linktitle: Volledige dia-achtergrond
type: docs
weight: 95
url: /nl/net/get-the-entire-presentation-slide-background-as-an-image/
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
- .NET
- C#
- Aspose.Slides
description: "Exporteer volledige dia-achtergronden als afbeeldingen uit PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor .NET, waardoor visuele werkstromen worden gestroomlijnd."
---
## **Overzicht**

In PowerPoint‑presentaties kan een dia‑achtergrond bestaan uit meerdere elementen, waaronder de afbeelding van de dia‑achtergrond, het presentatiethema, het kleurenpalet en objecten die op de master‑dia of de layout‑dia zijn geplaatst.

Dit artikel laat zien hoe u de volledige dia‑achtergrond kunt extraheren als afbeelding met Aspose.Slides voor .NET. Omdat er geen enkele methode bestaat voor deze taak, omvat de aanpak het klonen van de geselecteerde dia naar een tijdelijke presentatie, het verwijderen van de dia‑vormen en vervolgens het omzetten van de resulterende dia‑achtergrond naar een afbeelding.

## **Verkrijg de volledige dia‑achtergrond**

Aspose.Slides voor .NET biedt geen eenvoudige methode om de volledige presentatie‑dia‑achtergrond als afbeelding te extraheren, maar u kunt de volgende stappen volgen om dit te doen:
1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse.
2. Haal de dia‑grootte op uit de presentatie.
3. Selecteer een dia.
4. Maak een tijdelijke presentatie aan.
5. Stel dezelfde dia‑grootte in voor de tijdelijke presentatie.
6. Kloon de geselecteerde dia naar de tijdelijke presentatie.
7. Verwijder de vormen van de gekloonde dia.
8. Converteer de gekloonde dia naar een afbeelding.

De volgende codevoorbeeld haalt de volledige presentatie‑dia‑achtergrond op als afbeelding.
```cs
var slideIndex = 0;
var imageScale = 1;

using var presentation = new Presentation("sample.pptx");

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[slideIndex];

using var tempPresentation = new Presentation();    
tempPresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.Slides.AddClone(slide);
clonedSlide.Shapes.Clear();

using var background = clonedSlide.GetImage(imageScale, imageScale);
background.Save("output.png", ImageFormat.Png);
```

## **Veelgestelde vragen**

**Worden complexe verlopen, texturen of afbeeldingvullingen van een master‑dia behouden in de resulterende achtergrondafbeelding?**

Ja. Aspose.Slides rendert verloop‑, afbeelding‑ en textuurvullingen die op de dia, layout of master zijn gedefinieerd. Als u het uiterlijk wilt scheiden van geërfde masters, [stel een eigen achtergrond](/slides/nl/net/presentation-background/) in op de huidige dia voordat u exporteert.

**Kan ik een watermerk toevoegen aan de resulterende achtergrondafbeelding voordat ik deze opsla?**

Ja. U kunt een [watermerk](/slides/nl/net/watermark/) vorm of afbeelding toevoegen op een werkende [kopie van de dia](/slides/nl/net/clone-slides/) (achter de overige inhoud geplaatst) en vervolgens exporteren. Zo kunt u een achtergrondafbeelding genereren met het watermerk ingebakken.

**Kan ik de achtergrond van een specifieke layout of master verkrijgen zonder deze aan een bestaande dia te koppelen?**

Ja. Open de gewenste master of layout, pas deze toe op een [tijdelijke dia](/slides/nl/net/clone-slides/) met de vereiste afmetingen, en exporteer die dia om de achtergrond te verkrijgen die voortkomt uit die layout of master.

**Zijn er licentiebeperkingen die van invloed zijn op het exporteren van afbeeldingen?**

Render‑functionaliteiten zijn volledig beschikbaar met een [geldige licentie](/slides/nl/net/licensing/). In evaluatiemodus kan de output beperkingen bevatten, zoals een watermerk. Activeer de licentie één keer per proces voordat u batch‑exports uitvoert.