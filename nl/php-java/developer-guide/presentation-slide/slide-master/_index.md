---
title: Beheer dia-masters van presentaties in PHP
linktitle: Dia-master
type: docs
weight: 70
url: /nl/php-java/slide-master/
keywords:
- dia-master
- masterdia
- PPT-masterdia
- meerdere masterdia's
- masterdia's vergelijken
- achtergrond
- placeholder
- masterdia klonen
- masterdia kopiëren
- masterdia dupliceren
- ongebruikte masterdia
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Beheer dia-masters in Aspose.Slides voor PHP via Java: openen, bewerken, klonen, vergelijken en verwijderen van masterdia's in PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Een **slide master** definieert gedeelde ontwerpinstellingen voor een groep dia's. Het kan gemeenschappelijke vormen, logo's, achtergronden, tekststijlen, themainstellingen en voettekstinstellingen bevatten. In PowerPoint is het bewerken van een slide master de gebruikelijke manier om een presentatie consistent te houden zonder dezelfde opmaak op elke dia te herhalen.

Aspose.Slides voor PHP via Java ondersteunt hetzelfde model. Een presentatie kan één of meer master‑dia's bevatten, en elke master‑dia kan meerdere layout‑dia's bevatten. Normale dia's verwijzen meestal niet direct naar een master‑dia. In plaats daarvan gebruikt een normale dia een layout‑dia, en die layout‑dia behoort tot een master‑dia.

De hiërarchie is:

1. **Slide master** – definieert het gedeelde ontwerp en thema.  
1. **Layout slide** – definieert een specifieke indeling van placeholders en layout‑niveau opmaak.  
1. **Normal slide** – bevat de feitelijke presentatiewaarde en gebruikt één layout‑dia.

![De hiërarchie van master‑dia's, layout‑dia's en normale dia's](slide-master_2.jpg)

In Aspose.Slides wordt een slide master weergegeven door de [MasterSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslide/)‑klasse. Alle master‑dia's in een presentatie zijn toegankelijk via de [Presentation.getMasters](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getMasters)‑methode, die een [MasterSlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslidecollection/)‑object retourneert.

{{% alert color="info" title="Inheritance" %}}
Wanneer dezelfde eigenschap op meer dan één niveau wordt gedefinieerd, wint het specifiekere niveau. Bijvoorbeeld, als een master‑dia en een layout‑dia beide een achtergrond definiëren, gebruiken dia's gebaseerd op die layout de layout‑achtergrond. Voor meer informatie over layout‑dia's, zie [Apply or Change Slide Layouts](/slides/nl/php-java/slide-layout/).
{{% /alert %}}

## **Toegang tot Slide Masters**

In PowerPoint kun je de Slide Master‑weergave openen via **Beeld** > **Slide Master**.

![De Slide Master‑opdracht in het PowerPoint‑tabblad Beeld](slide-master_3.jpg)

In Aspose.Slides gebruik je de `getMasters`‑methode om master‑dia's op te vragen:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlideCount = $presentation->getMasters()->size();
    $firstMasterLayoutSlideCount = $firstMasterSlide->getLayoutSlides()->size();

    echo "Master slides: " . $masterSlideCount . PHP_EOL;
    echo "Layouts in the first master: " . $firstMasterLayoutSlideCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Je kunt ook de master‑dia ophalen die door een normale dia wordt gebruikt via zijn layout:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $masterSlide = $layoutSlide->getMasterSlide();
    $masterSlideName = $masterSlide->getName();

    echo $masterSlideName . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Wat een Slide Master Bevat**

Een master‑dia is een dia‑achtig object. Het breidt [BaseSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseslide/) uit, waardoor het veel van dezelfde dia‑eigenschappen beschikbaar maakt die normale en layout‑dia's gebruiken. Master‑specifieke leden staan vermeld op de API‑pagina van [MasterSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslide/).

Veelgebruikte master‑dia‑leden zijn onder andere:

| Lid | Doel |
| --- | --- |
| `getBackground` | Stelt de master‑niveau dia‑achtergrond in. |
| `getShapes` | Bevat vormen die op de master zijn geplaatst, zoals logo's, afbeeldingkaders en gedeelde tekst. |
| `getLayoutSlides` | Bevat de layout‑dia's die bij de master horen. |
| `getThemeManager` | Biedt toegang tot de master‑thema‑API’s. |
| `getHeaderFooterManager` | Beheert kop‑ en voetteksten, datums en dia‑nummers voor de master en diens onderliggende layouts. |
| `getDependingSlides` | Retourneert normale dia's die via hun layouts afhankelijk zijn van de master. |

## **Een Afbeelding Toevoegen aan een Slide Master**

Wanneer je een afbeelding toevoegt aan een master‑dia, wordt deze getoond op dia's die layouts van die master gebruiken. Dit is handig voor logo's, watermerken, decoratieve banden en andere herhaalde visuele elementen.

Het volgende voorbeeld voegt een logo toe aan de eerste master‑dia:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $logoImage = Images::fromFile("logo.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($logoImage);
    } finally {
        $logoImage->dispose();
    }

    $masterSlide->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        80,
        80,
        $presentationImage
    );

    $presentation->save("presentation-with-logo.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Voor meer informatie over afbeeldingkaders, zie [Picture Frame](/slides/nl/php-java/picture-frame/).

## **Zichtbaarheid van Master‑Grafieken Beheren**

Gebruik [BaseSlide::setShowMasterShapes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseslide/#setShowMasterShapes) om geërfde master‑grafieken, zoals logo's of decoratieve vormen, te verbergen zonder ze van de master te verwijderen. Geef `false` door aan [Slide::setShowMasterShapes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#setShowMasterShapes) op de dia die die grafieken moet weglaten en houd het op `true` voor dia's die ze moeten weergeven.

Het volgende zelfstandige voorbeeld maakt een blauwe decoratieve band op een master en twee dia's die dezelfde lege layout gebruiken. De band is zichtbaar op de eerste dia en verborgen op de tweede. Er is geen invoerpresentatie of afbeelding nodig.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $layoutSlide = $masterSlide->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $layoutSlide->setShowMasterShapes(true);

    $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
    $band = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 60, $slideHeight);
    $bandColor = new Java("java.awt.Color", 70, 130, 180);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor($bandColor);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $visibleSlide = $presentation->getSlides()->get_Item(0);
    $visibleSlide->setLayoutSlide($layoutSlide);
    $visibleSlide->getShapes()->clear();

    $hiddenSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $visibleSlide->setShowMasterShapes(true);
    $hiddenSlide->setShowMasterShapes(false);

    $presentation->save("master-graphics.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het voorbeeld maakt gebruik van de **Blank**‑layout die wordt geleverd met een nieuwe presentatie en verwijdert de eigen placeholders van de initiële dia.

### **Kies de Reikwijdte van de Instelling**

Een normale dia gebruikt zijn master via [Slide::getLayoutSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#getLayoutSlide) en [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/#getMasterSlide). De eigenschap op een individuele dia instellen heeft alleen effect op die dia. Het doorgeven van `false` aan [LayoutSlide::setShowMasterShapes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/#setShowMasterShapes) verbergt master‑grafieken voor alle dia's die die gedeelde layout gebruiken, zelfs als hun eigen instelling `true` is. Om grafieken alleen op één dia te verbergen, wijzig je de dia‑eigenschap en laat je de gedeelde layout ongewijzigd.

De instelling wordt niet ondersteund als een zichtbaarheid‑controle op de master‑dia zelf. Op een master geeft [getShowMasterShapes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslide/#getShowMasterShapes) altijd `false` terug, en het doorgeven van `true` aan [setShowMasterShapes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslide/#setShowMasterShapes) veroorzaakt een uitzondering. Pas de methode toe op een normale dia of een layout.

### **Grafieken Onderscheiden van de Achtergrond**

| Handeling | Effect |
| --- | --- |
| Master‑grafieken verbergen | Beheert de zichtbaarheid van geërfde master‑vormen zonder ze te verwijderen of de eigen vormen van de dia te wijzigen. |
| Dia‑achtergrondvulling wijzigen | Wijzigt de achtergrondkleur, -gradient of -afbeelding. Master‑grafieken zijn afzonderlijke vormen en kunnen zichtbaar blijven boven die achtergrond. Zie [Presentation Background](/slides/nl/php-java/presentation-background/). |
| Een vorm van de master verwijderen | Verwijdert de gedeelde bronvorm, zodat deze niet meer beschikbaar is voor enige dia die die master gebruikt. |

## **Werken met Placeholders**

Placeholders worden normaal gedefinieerd op layout‑dia's. De master‑dia levert de gedeelde stijl en het thema waar deze layouts van erven, terwijl elke layout beslist welke placeholders beschikbaar zijn en waar ze worden geplaatst.

In PowerPoint zijn placeholder‑opdrachten beschikbaar in de Slide Master‑weergave.

![De opdracht Placeholder invoegen in de PowerPoint Slide Master‑weergave](slide-master_5.png)

Om nieuwe placeholders toe te voegen met Aspose.Slides, werk je met de layout‑dia die bij de master hoort:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $blankLayoutSlideName = "Custom Blank";
    $blankLayoutSlide = $masterSlide->getLayoutSlides()->add(
        SlideLayoutType::Blank,
        $blankLayoutSlideName
    );

    $blankLayoutSlide->getPlaceholderManager()->addTextPlaceholder(
        60,
        120,
        600,
        80
    );

    $presentation->getSlides()->addEmptySlide($blankLayoutSlide);
    $presentation->save("presentation-with-placeholder.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Je kunt ook de vorm van een bestaande placeholder op een master‑dia opmaken. Het volgende voorbeeld vindt de titel‑placeholder en past een lineaire gradientvulling toe:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $titlePlaceholder = findPlaceholder($masterSlide, PlaceholderType::Title);

    if (!java_is_null($titlePlaceholder)) {
        $redGradientColor = java("java.awt.Color")->RED;
        $purpleGradientColor = new Java("java.awt.Color", 128, 0, 128);

        $fillFormat = $titlePlaceholder->getFillFormat();
        $fillFormat->setFillType(FillType::Gradient);
        $gradientFormat = $fillFormat->getGradientFormat();
        $gradientFormat->setGradientShape(GradientShape::Linear);
        $gradientStops = $gradientFormat->getGradientStops();
        $gradientStops->add(0, $redGradientColor);
        $gradientStops->add(255, $purpleGradientColor);
    }

    $presentation->save("presentation-title-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

function findPlaceholder($masterSlide, $placeholderType)
{
    $shapesCount = java_values($masterSlide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapesCount; $shapeIndex++) {
        $shape = $masterSlide->getShapes()->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();

        if (!java_is_null($placeholder) && java_values($placeholder->getType()) == $placeholderType) {
            return $shape;
        }
    }

    return null;
}
```

![Opgemaakte titel‑placeholder die geërfd wordt door normale dia's](slide-master_8.png)

Voor meer placeholder‑ en tekstopmaakopties, zie [Set Prompt Text in Placeholder](/slides/nl/php-java/manage-placeholder/) en [Text Formatting](/slides/nl/php-java/text-formatting/).

## **Een Slide Master‑Achtergrond Wijzigen**

Een master‑achtergrond wordt geërfd door layouts en dia's die deze niet overschrijven. Het volgende voorbeeld stelt een effen achtergrondkleur in voor de eerste master‑dia:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $forestGreenColor = new Java("java.awt.Color", 34, 139, 34);

    $background = $masterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($forestGreenColor);

    $presentation->save("presentation-master-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Voor gerelateerde onderwerpen, zie [Presentation Background](/slides/nl/php-java/presentation-background/) en [Presentation Theme](/slides/nl/php-java/presentation-theme/).

## **Een Slide Master Kloon naar Een Andere Presentatie**

Gebruik `addClone` vanuit [MasterSlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslidecollection/) om een master‑dia te kopiëren naar een andere presentatie. De gekopieerde master kan vervolgens worden gebruikt door layouts en dia's in de bestemmingspresentatie.

```php
$sourcePresentation = new Presentation("source.pptx");
$destinationPresentation = new Presentation("destination.pptx");
try {
    $sourceMasterSlide = $sourcePresentation->getMasters()->get_Item(0);
    $clonedMasterSlide = $destinationPresentation->getMasters()->addClone($sourceMasterSlide);

    $destinationPresentation->save("destination-with-master.pptx", SaveFormat::Pptx);
} finally {
    $destinationPresentation->dispose();
    $sourcePresentation->dispose();
}
```

Als je normale dia's samen met hun master wilt klonen, zie [Clone Slides](/slides/nl/php-java/clone-slides/).

## **Meerdere Slide Masters Toevoegen**

Een presentatie kan meerdere master‑dia's bevatten. Dit is nuttig wanneer verschillende secties verschillende branding, paginastuctuur of themainstellingen vereisen.

![PowerPoint‑opdrachten voor het invoegen en beheren van master‑dia's](slide-master_9.jpg)

Het volgende voorbeeld kloont de standaard master, geeft de kloon een andere achtergrond, maakt een layout onder die gekloonde master en voegt een nieuwe dia toe gebaseerd op die layout:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
    $sectionMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);
    $lightSteelBlueColor = new Java("java.awt.Color", 176, 196, 222);

    $background = $sectionMasterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($lightSteelBlueColor);

    $sourceBlankLayout = $defaultMasterSlide->getLayoutSlides()->get_Item(0);
    $sectionBlankLayout = $sectionMasterSlide->getLayoutSlides()->addClone($sourceBlankLayout);

    $presentation->getSlides()->addEmptySlide($sectionBlankLayout);
    $presentation->save("presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Slide Masters Vergelijken**

Master‑dia's kunnen worden vergeleken met de `equals`‑methode die is overgeërfd van [BaseSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseslide/). De vergelijking controleert structuur en statische inhoud, zoals vormen, tekst, opmaak, animaties en andere dia‑instellingen. Unieke identifiers, zoals dia‑ID's, of dynamische placeholder‑waarden, zoals de huidige datum, worden niet vergeleken.

```php
$firstPresentation = new Presentation("first.pptx");
$secondPresentation = new Presentation("second.pptx");
try {
    $firstPresentationMasterCount = java_values($firstPresentation->getMasters()->size());
    $secondPresentationMasterCount = java_values($secondPresentation->getMasters()->size());

    for ($firstMasterIndex = 0; $firstMasterIndex < $firstPresentationMasterCount; $firstMasterIndex++) {
        for ($secondMasterIndex = 0; $secondMasterIndex < $secondPresentationMasterCount; $secondMasterIndex++) {
            $firstMasterSlide = $firstPresentation->getMasters()->get_Item($firstMasterIndex);
            $secondMasterSlide = $secondPresentation->getMasters()->get_Item($secondMasterIndex);
            $areMasterSlidesEqual = $firstMasterSlide->equals($secondMasterSlide);

            if ($areMasterSlidesEqual) {
                echo "first.pptx master #" . $firstMasterIndex .
                    " equals second.pptx master #" . $secondMasterIndex . PHP_EOL;
            }
        }
    }
} finally {
    $secondPresentation->dispose();
    $firstPresentation->dispose();
}
```

Voor meer informatie, zie [Compare Presentation Slides](/slides/nl/php-java/compare-slides/).

## **Slide Master‑Weergave Instellen als Standaardweergave**

Gebruik de `setLastView`‑methode op [ViewProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/viewproperties/) om de weergave te bepalen die PowerPoint eerst opent. Het volgende voorbeeld opent de presentatie in Slide Master‑weergave:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Voor meer weergave‑instellingen, zie [Save Presentation](/slides/nl/php-java/save-presentation/).

## **Ongebruikte Master‑Dia's Verwijderen**

Presentaties bevatten soms master‑dia's die niet meer door normale dia's worden gebruikt. Het verwijderen van ongebruikte masters kan de bestandsgrootte verkleinen en het onderhoud van sjablonen vereenvoudigen.

Gebruik `removeUnused` vanuit [MasterSlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslidecollection/) om ongebruikte masters uit de `getMasters`‑collectie te verwijderen:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Je kunt ook de low‑code `removeUnusedMasterSlides`‑methode uit de [Compress](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compress/)‑klasse gebruiken:

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Wat is het verschil tussen een slide master en een layout slide?**

Een slide master definieert gedeelde ontwerpinstellingen zoals thema, achtergrond, gemeenschappelijke vormen en tekststijlen. Een layout slide behoort tot een master‑dia en definieert een specifieke rangschikking van placeholders. Een normale dia gebruikt een layout slide, waardoor hij zowel van de layout als van de master erft.

**Kan één presentatie meerdere slide masters bevatten?**

Ja. Een presentatie kan meerdere slide masters bevatten. Gebruik meerdere masters wanneer verschillende secties verschillende visuele systemen of branding nodig hebben.

**Moet ik placeholders toevoegen aan een master‑dia of een layout‑dia?**

In de meeste gevallen voeg je placeholders toe aan layout‑dia's. Plaats gedeelde visuele elementen en gedeelde opmaak op de master‑dia, en zet de inhoud‑placeholders op de layouts die normale dia's zullen gebruiken.

**Kan ik een master‑dia verwijderen die nog wordt gebruikt?**

Nee. Een master‑dia met afhankelijke dia's kan niet veilig direct worden verwijderd. Verplaats die dia's eerst naar layouts onder een andere master, of gebruik een opruimingsmethode voor ongebruikte masters die alleen masters verwijdert die niet in gebruik zijn.