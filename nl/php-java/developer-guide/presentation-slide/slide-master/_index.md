---
title: Beheer presentatie-masterdia's in PHP
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
- tijdelijke aanduiding
- masterdia klonen
- masterdia kopiëren
- masterdia dupliceren
- ongebruikte masterdia
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Beheer masterdia's in Aspose.Slides voor PHP via Java: toegang, bewerken, klonen, vergelijken en verwijderen van masterdia's in PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Een **masterdia** definieert gedeelde ontwerpinstellingen voor een groep dia's. Het kan gemeenschappelijke vormen, logo's, achtergronden, tekststijlen, thema‑instellingen en voettekstinstellingen bevatten. In PowerPoint is het bewerken van een masterdia de gebruikelijke manier om een presentatie consistent te houden zonder dezelfde opmaak op elke dia te herhalen.

Aspose.Slides for PHP via Java ondersteunt hetzelfde model. Een presentatie kan één of meer masterdia's bevatten, en elke masterdia kan meerdere lay‑outdia's bevatten. Normale dia's verwijzen meestal niet direct naar een masterdia. In plaats daarvan gebruikt een normale dia een lay‑outdia, en die lay‑outdia behoort tot een masterdia.

De hiërarchie is:

1. **Masterdia** – definieert het gedeelde ontwerp en thema.  
1. **Lay‑outdia** – definieert een specifieke rangschikking van tijdelijke aanduidingen en lay‑out‑niveau opmaak.  
1. **Normale dia** – bevat de daadwerkelijke presentatietoepassing en gebruikt één lay‑outdia.

![De hiërarchie van masterdia's, lay‑outdia's en normale dia's](slide-master_2.jpg)

In Aspose.Slides wordt een masterdia weergegeven door de [MasterSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslide/)‑klasse. Alle masterdia's in een presentatie zijn beschikbaar via de [Presentation.getMasters](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getMasters)‑methode, die een [MasterSlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslidecollection/)‑object retourneert.

{{% alert color="info" title="Erfenis" %}}

Wanneer dezelfde eigenschap op meer dan één niveau wordt gedefinieerd, wint het specifiekere niveau. Bijvoorbeeld, als een masterdia en een lay‑outdia beide een achtergrond definiëren, gebruiken dia's die op die lay‑out zijn gebaseerd de lay‑out‑achtergrond. Zie voor meer informatie over lay‑outdia's [Apply or Change Slide Layouts](/slides/nl/php-java/slide-layout/).

{{% /alert %}}

## **Masterdia’s Benaderen**

In PowerPoint kun je de masterdia‑weergave openen via **Beeld** > **Masterdia**.

![De masterdia‑opdracht op het PowerPoint‑tabblad Beeld](slide-master_3.jpg)

In Aspose.Slides gebruik je de `getMasters`‑methode om masterdia's te benaderen:

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

Je kunt ook de masterdia die door een normale dia wordt gebruikt via de bijbehorende lay‑out verkrijgen:

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

## **Wat Een Masterdia Bevat**

Een masterdia is een object dat op een dia lijkt. Het erft van [BaseSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseslide/), zodat het veel van dezelfde dia‑eigenschappen blootlegt die door normale en lay‑outdia's worden gebruikt. Master‑specifieke leden staan opgesomd op de [MasterSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslide/)‑API‑pagina.

Veelgebruikte masterdia‑leden omvatten:

| Lid | Doel |
| --- | --- |
| `getBackground` | Stelt de achtergrond van de masterdia in. |
| `getShapes` | Bevat vormen die op de master zijn geplaatst, zoals logo's, afbeeldingskaders en gedeelde tekst. |
| `getLayoutSlides` | Bevat de lay‑outdia's die bij de master horen. |
| `getThemeManager` | Biedt toegang tot de master‑thema‑API’s. |
| `getHeaderFooterManager` | Beheert kopteksten, voetteksten, datums en paginanummers voor de master en diens onderliggende lay‑outs. |
| `getDependingSlides` | Retourneert normale dia's die via hun lay‑outs afhankelijk zijn van de master. |

## **Een Afbeelding Aan Een Masterdia Toevoegen**

Wanneer je een afbeelding aan een masterdia toevoegt, verschijnt deze op dia's die lay‑outs van die master gebruiken. Dit is handig voor logo's, watermerken, decoratieve balken en andere terugkerende visuele elementen.

Het volgende voorbeeld voegt een logo toe aan de eerste masterdia:

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

Voor meer informatie over afbeeldingskaders, zie [Picture Frame](/slides/nl/php-java/picture-frame/).

## **Werken Met Tijdelijke Aanduidingen**

Tijdelijke aanduidingen worden normaal gedefinieerd op lay‑outdia's. De masterdia levert de gedeelde stijl en het thema die die lay‑outs erven, terwijl elke lay‑out beslist welke tijdelijke aanduidingen beschikbaar zijn en waar ze worden geplaatst.

In PowerPoint zijn de tijdelijke‑aanduiding‑opdrachten beschikbaar in de masterdia‑weergave.

![De opdracht Plaats Tijdelijke Aanduiding in de PowerPoint‑masterdia‑weergave](slide-master_5.png)

Om nieuwe tijdelijke aanduidingen toe te voegen met Aspose.Slides, werk je met de lay‑outdia die bij de master hoort:

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

Je kunt ook de vorm van bestaande tijdelijke aanduidingen op een masterdia opmaken. Het volgende voorbeeld zoekt de titel‑tijdelijke‑aanduiding en past een lineaire gradiëntenvulling toe:

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

![Opgepaste titel‑tijdelijke‑aanduiding geërfd door normale dia's](slide-master_8.png)

Voor meer opties rond tijdelijke aanduidingen en tekstopmaak, zie [Set Prompt Text in Placeholder](/slides/nl/php-java/manage-placeholder/) en [Text Formatting](/slides/nl/php-java/text-formatting/).

## **De Achtergrond Van Een Masterdia Wijzigen**

Een masterachtergrond wordt geërfd door lay‑outs en dia's die deze niet overschrijven. Het volgende voorbeeld stelt een effen achtergrondkleur in voor de eerste masterdia:

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

## **Een Masterdia Kopiëren Naar Een Andere Presentatie**

Gebruik `addClone` van [MasterSlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslidecollection/) om een masterdia te kopiëren naar een andere presentatie. De gekopieerde master kan vervolgens door lay‑outs en dia's in de bestemmingspresentatie worden gebruikt.

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

## **Meerdere Masterdia’s Toevoegen**

Een presentatie kan meerdere masterdia's bevatten. Dit is handig wanneer verschillende secties verschillende branding, paginacompositie of themainstellingen vereisen.

![PowerPoint‑opdrachten voor het invoegen en beheren van masterdia's](slide-master_9.jpg)

Het volgende voorbeeld kloont de standaardmaster, geeft het kloon een andere achtergrond, maakt een lay‑out onder die gekloonde master en voegt een nieuwe dia toe op basis van die lay‑out:

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

## **Masterdia’s Vergelijken**

Masterdia's kunnen worden vergeleken met de `equals`‑methode die is geërfd van [BaseSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseslide/). De vergelijking controleert structuur en statische inhoud, zoals vormen, tekst, opmaak, animaties en andere dia‑instellingen. Unieke identifiers, zoals dia‑ID's, of dynamische tijdelijke‑aanduidingswaarden, zoals de huidige datum, worden niet vergeleken.

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

## **Masterdia‑Weergave Als Standaardweergave Instellen**

Gebruik de `setLastView`‑methode op [ViewProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/viewproperties/) om de weergave te bepalen die PowerPoint bij het openen eerst laat zien. Het volgende voorbeeld opent de presentatie in masterdia‑weergave:

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

## **Ongebruikte Masterdia’s Verwijderen**

Soms bevatten presentaties masterdia's die door geen enkele normale dia meer worden gebruikt. Het verwijderen van ongebruikte masters kan de bestandsgrootte verkleinen en het beheer van sjablonen vereenvoudigen.

Gebruik `removeUnused` van [MasterSlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslidecollection/) om ongebruikte masters uit de `getMasters`‑collectie te verwijderen:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Je kunt ook de low‑code‑methode `removeUnusedMasterSlides` van de [Compress](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compress/)‑klasse gebruiken:

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

**Wat is het verschil tussen een masterdia en een lay‑outdia?**

Een masterdia definieert gedeelde ontwerpinstellingen zoals thema, achtergrond, gemeenschappelijke vormen en tekststijlen. Een lay‑outdia behoort tot een masterdia en definieert een specifieke rangschikking van tijdelijke aanduidingen. Een normale dia gebruikt een lay‑outdia en erft daardoor zowel van de lay‑out als van de master.

**Kan een presentatie meerdere masterdia's bevatten?**

Ja. Een presentatie kan meerdere masterdia's bevatten. Gebruik meerdere masters wanneer verschillende secties andere visuele systemen of branding nodig hebben.

**Moet ik tijdelijke aanduidingen toevoegen aan een masterdia of aan een lay‑outdia?**

In de meeste gevallen voeg je tijdelijke aanduidingen toe aan lay‑outdia's. Plaats gedeelde visuele elementen en gedeelde opmaak op de masterdia, en plaats inhoudelijke tijdelijke aanduidingen op de lay‑outs die normale dia's zullen gebruiken.

**Kan ik een masterdia verwijderen die nog in gebruik is?**

Nee. Een masterdia met afhankelijke dia's kan niet veilig direct worden verwijderd. Verplaats die dia's eerst naar lay‑outs onder een andere master, of gebruik een opschoonmethode die alleen ongebruikte masters verwijdert.