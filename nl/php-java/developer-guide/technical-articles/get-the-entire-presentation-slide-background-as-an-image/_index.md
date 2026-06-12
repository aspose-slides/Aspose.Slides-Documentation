---
title: De volledige slide-achtergrond uit een presentatie als afbeelding ophalen
linktitle: Complete slide-achtergrond
type: docs
weight: 95
url: /nl/php-java/get-the-entire-presentation-slide-background-as-an-image/
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
- PHP
- Aspose.Slides
description: "Exporteer volledige slide-achtergronden als afbeeldingen uit PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor PHP via Java, waardoor visuele workflows worden gestroomlijnd."
---
## **Overzicht**

In PowerPoint‑presentaties kan een slide‑achtergrond bestaan uit meerdere elementen, waaronder de achtergrondafbeelding van de slide, het presentatiethema, het kleurschema en objecten die op de master‑slide of de layout‑slide zijn geplaatst.

Dit artikel laat zien hoe u de volledige slide‑achtergrond kunt extraheren als afbeelding met Aspose.Slides. Omdat er geen enkele methode voor deze taak bestaat, omvat de werkwijze het klonen van de geselecteerde slide naar een tijdelijke presentatie, het verwijderen van de shapes van die slide en vervolgens het omzetten van de verkregen slide‑achtergrond naar een afbeelding.

## **Verkrijg de volledige slide‑achtergrond**

Aspose.Slides for PHP via Java biedt geen eenvoudige methode om de volledige slide‑achtergrond van een presentatie als afbeelding te extraheren, maar u kunt de onderstaande stappen volgen om dit te doen:
1. Laad de presentatie met de [Presentatie](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse.
1. Haal de slide‑grootte op uit de presentatie.
1. Selecteer een slide.
1. Maak een tijdelijke presentatie aan.
1. Stel dezelfde slide‑grootte in voor de tijdelijke presentatie.
1. Kloon de geselecteerde slide naar de tijdelijke presentatie.
1. Verwijder de shapes van de gekloonde slide.
1. Converteer de gekloonde slide naar een afbeelding.

De volgende code‑voorbeeld extraheert de volledige slide‑achtergrond van de presentatie als een afbeelding.
```php
$slideIndex = 0;
$imageScale = 1;

$presentation = new Presentation("sample.pptx");

$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item($slideIndex);

$tempPresentation = new Presentation();

$slideWidth = $slideSize->getWidth();
$slideHeight = $slideSize->getHeight();
$tempPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::DoNotScale);

$clonedSlide = $tempPresentation->getSlides()->addClone($slide);
$clonedSlide->getShapes()->clear();

$background = clonedSlide->getImage($imageScale, $imageScale);
$background->save("output->png", ImageFormat::Png);

$tempPresentation->dispose();
$presentation->dispose();
```

## **FAQ**

**Worden complexe kleurverlopen, texturen of afbeeldingvullingen van een master‑slide behouden in de resulterende achtergrondafbeelding?**

Ja. Aspose.Slides rendert kleurverlopen, afbeelding‑ en textuurvullingen die op de slide, layout of master zijn gedefinieerd. Als u de weergave wilt isoleren van geërfde masters, [een eigen achtergrond instellen](/slides/nl/php-java/presentation-background/) op de huidige slide vóór het exporteren.

**Kan ik een watermerk toevoegen aan de resulterende achtergrondafbeelding vóór het opslaan?**

Ja. U kunt een [watermerk](/slides/nl/php-java/watermark/) shape of afbeelding toevoegen op een werkende [kopie van de slide](/slides/nl/php-java/clone-slides/) (achter andere inhoud geplaatst) en daarna exporteren. Zo genereert u een achtergrondafbeelding met het watermerk ingebakken.

**Kan ik de achtergrond van een specifieke layout of master verkrijgen zonder deze te koppelen aan een bestaande slide?**

Ja. Open de gewenste master of layout, pas deze toe op een [tijdelijke slide](/slides/nl/php-java/clone-slides/) met de vereiste grootte, en exporteer die slide om de achtergrond die uit die layout of master is afgeleid te verkrijgen.

**Zijn er licentiebeperkingen die invloed hebben op het exporteren van afbeeldingen?**

Render‑functies zijn volledig beschikbaar met een [geldige licentie](/slides/nl/php-java/licensing/). In evaluatiemodus kan de output beperkingen bevatten, zoals een watermerk. Activeer de licentie eenmaal per proces voordat u batch‑exports uitvoert.