---
title: Verkrijg de volledige dia‑achtergrond van een presentatie als afbeelding
linktitle: Volledige Dia‑Achtergrond
type: docs
weight: 95
url: /nl/cpp/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- dia‑achtergrond
- eind‑achtergrond
- achtergrond extraheren
- volledige achtergrond
- achtergrond naar afbeelding
- PPT‑achtergrond
- PPTX‑achtergrond
- ODP‑achtergrond
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Haalt volledige dia‑achtergronden als afbeeldingen uit PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides for C++, en stroomlijnt zo visuele workflows."
---
## **Overzicht**

In PowerPoint‑presentaties kan een dia‑achtergrond bestaan uit meerdere elementen, waaronder de afbeelding van de dia‑achtergrond, het presentatiethema, het kleurschema en objecten die op de master‑dia of lay‑out‑dia zijn geplaatst.

Dit artikel toont hoe u de volledige dia‑achtergrond als afbeelding kunt extraheren met Aspose.Slides. Omdat er geen enkele methode voor deze taak bestaat, omvat de aanpak het klonen van de geselecteerde dia naar een tijdelijke presentatie, het verwijderen van de vormen van de dia en vervolgens het omzetten van de resulterende dia‑achtergrond naar een afbeelding.

## **Haal de volledige dia‑achtergrond op**

Aspose.Slides for C++ biedt geen eenvoudige methode om de volledige presentatie‑dia‑achtergrond als afbeelding te extraheren, maar u kunt de onderstaande stappen volgen om dit te doen:
1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
1. Haal de dia‑grootte op uit de presentatie.
1. Selecteer een dia.
1. Maak een tijdelijke presentatie.
1. Stel dezelfde dia‑grootte in de tijdelijke presentatie in.
1. Kloon de geselecteerde dia naar de tijdelijke presentatie.
1. Verwijder de vormen van de geklonde dia.
1. Converteer de geklonde dia naar een afbeelding.

De onderstaande code‑voorbeeld extraheert de volledige presentatie‑dia‑achtergrond als afbeelding.
```cpp
auto slideIndex = 0;
auto imageScale = 1;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slides()->idx_get(slideIndex);

auto tempPresentation = System::MakeObject<Presentation>();

auto slideWidth = slideSize.get_Width();
auto slideHeight = slideSize.get_Height();
tempPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::DoNotScale);

auto clonedSlide = tempPresentation->get_Slides()->AddClone(slide);
clonedSlide->get_Shapes()->Clear();

auto background = clonedSlide->GetImage(imageScale, imageScale);
background->Save(u"output.png", ImageFormat::Png);

tempPresentation->Dispose();
presentation->Dispose();
```

## **FAQ**

**Worden complexe verlopen, texturen of afbeeldingsvullingen van een master‑dia behouden in de resulterende achtergrondafbeelding?**

Ja. Aspose.Slides rendert verlopen, afbeeldings‑ en textuurvullingen die op de dia, lay‑out of master zijn gedefinieerd. Als u het uiterlijk van geërfde masters wilt isoleren, [stel een eigen achtergrond](/slides/nl/cpp/presentation-background/) in op de huidige dia voordat u exporteert.

**Kan ik een watermerk toevoegen aan de resulterende achtergrondafbeelding voordat ik deze opsla?**

Ja. U kunt een [watermerk](/slides/nl/cpp/watermark/) vormen of afbeelding toevoegen op een werkende [kopie van de dia](/slides/nl/cpp/clone-slides/) (achter andere inhoud geplaatst) en vervolgens exporteren. Daarmee genereert u een achtergrondafbeelding met het watermerk ingebakken.

**Kan ik de achtergrond voor een specifiek lay‑out of master verkrijgen zonder deze aan een bestaande dia te koppelen?**

Ja. Open de gewenste master of lay‑out, pas deze toe op een [tijdelijke dia](/slides/nl/cpp/clone-slides/) met de vereiste grootte, en exporteer die dia om de achtergrond af te leiden van dat lay‑out of die master.

**Zijn er licentiebeperkingen die van invloed zijn op het exporteren van afbeeldingen?**

Renderfuncties zijn volledig beschikbaar met een [geldige licentie](/slides/nl/cpp/licensing/). In de evaluatiemodus kan de output beperkingen bevatten, zoals een watermerk. Activeer de licentie één keer per proces voordat u batch‑exporten uitvoert.