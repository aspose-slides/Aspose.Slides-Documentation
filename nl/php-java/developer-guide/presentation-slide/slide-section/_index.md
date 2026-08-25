---
title: Beheer dia-secties in presentaties met PHP
linktitle: Dia-sectie
type: docs
weight: 90
url: /nl/php-java/slide-section/
keywords:
- sectie maken
- sectie toevoegen
- sectie bewerken
- sectie wijzigen
- sectienaam
- sectiedia's ophalen
- sectiedia's verwerken
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Beheer dia-secties met Aspose.Slides voor PHP via Java: maak, hernoem, herschik, haal op en verwerk sectiedia's in PPTX-presentaties."
---
## **Inleiding**

Secties organiseren opeenvolgende dia's in genaamde groepen zonder de inhoud van de dia's te wijzigen. Met Aspose.Slides voor PHP via Java kunt u secties maken, herschikken, hernoemen, inspecteren en verwijderen via de [Presentation::getSections](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation/#getSections) methode.

Secties zijn vooral nuttig wanneer:

- een grote presentatie moet worden opgedeeld in logische onderwerpen of hoofdstukken;
- verschillende groepen dia's worden toegewezen aan verschillende collega's;
- dia's moeten worden verwerkt, verplaatst of samengevoegd als groepen.

Kies beknopte sectienaam die het doel van de gegroepeerde dia's beschrijven. Omdat secties deel uitmaken van de structuur van de presentatie, gebruikt u de sectie‑API's om lidmaatschap te bepalen in plaats van dit af te leiden van de positie van dia's.

## **Secties aanmaken en beheren**

Gebruik [SectionCollection::addSection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SectionCollection/#addSection) om een sectie te maken door de naam en de startdia op te geven. Aspose.Slides bepaalt welke dia's tot de sectie behoren vanuit de huidige sectiestructuur van de presentatie.

Dezelfde [SectionCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SectionCollection/) biedt u ook de mogelijkheid om:

- een sectie samen met de bijbehorende dia's verplaatsen met [SectionCollection::reorderSectionWithSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SectionCollection/#reorderSectionWithSlides);
- alleen de sectiedefinitie verwijderen met [SectionCollection::removeSection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SectionCollection/#removeSection), waardoor de dia's behouden blijven;
- een sectie en de bijbehorende dia's verwijderen met [SectionCollection::removeSectionWithSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SectionCollection/#removeSectionWithSlides);
- een lege sectie aan het einde toevoegen met [SectionCollection::appendEmptySection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SectionCollection/#appendEmptySection).

Het volgende voorbeeld maakt twee secties, verplaatst er één, verwijdert deze samen met de bijbehorende dia's en voegt een lege sectie toe:

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $titleSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $resultsSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);

    $presentation->getSections()->addSection("Introduction", $titleSlide);
    $resultsSection = $presentation->getSections()->addSection("Results", $resultsSlide);

    $presentation->getSections()->reorderSectionWithSlides($resultsSection, 0);
    $presentation->getSections()->removeSectionWithSlides($resultsSection);
    $presentation->getSections()->appendEmptySection("Appendix");
} finally {
    $presentation->dispose();
}
```

Na deze bewerkingen bevat de presentatie de sectie `Introduction` met haar dia's en een lege sectie `Appendix`. De sectie `Results` en de bijbehorende dia's zijn verwijderd.

## **Secties hernoemen**

Om een sectie te hernoemen, roept u de [Section::setName](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Section/#setName) methode aan. De dia's van de sectie en de positie blijven ongewijzigd.

Het volgende voorbeeld maakt een sectie en wijzigt de naam:

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $section = $presentation->getSections()->addSection("Overview", $slide);
    $section->setName("Introduction");
} finally {
    $presentation->dispose();
}
```

## **Dia's ophalen uit secties**

De [Presentation::getSections](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation/#getSections) methode retourneert een [SectionCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SectionCollection/) die u indexgewijs kunt verwerken. Voor elke [Section](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Section/) roept u [Section::getSlidesListOfSection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Section/#getSlidesListOfSection) aan om de dia's te verkrijgen die momenteel tot die sectie behoren. De methode retourneert een [SectionSlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SectionSlideCollection/), die een telling en indexgerichte toegang biedt.

Het volgende voorbeeld maakt twee gevulde secties en één lege sectie, en print vervolgens voor elke sectie de [naam](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Section/#getName), [identificatie](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Section/#getSectionId), [startdia](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Section/#getStartedFromSlide), het aantal dia's en de dia‑nummers. Het gebruikt [SectionCollection::get_Item](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SectionCollection/#get_Item) en [SectionSlideCollection::get_Item](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SectionSlideCollection/#get_Item) voor indextoegang. Voor de lege sectie heeft de geretourneerde collectie een grootte van nul en wordt `get_Item` niet aangeroepen.

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $thirdSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $presentation->getSections()->addSection("Introduction", $firstSlide);
    $presentation->getSections()->addSection("Details", $thirdSlide);
    $presentation->getSections()->appendEmptySection("Appendix");

    $sections = $presentation->getSections();
    $sectionCount = java_values($sections->size());
    for ($sectionIndex = 0; $sectionIndex < $sectionCount; $sectionIndex++) {
        $section = $sections->get_Item($sectionIndex);
        $sectionSlides = $section->getSlidesListOfSection();
        $startingSlide = java_is_null($section->getStartedFromSlide()) ? "none" : java_values($section->getStartedFromSlide()->getSlideNumber());
        $slideCount = java_values($sectionSlides->size());

        echo "Section: " . java_values($section->getName()) . PHP_EOL;
        echo "ID: " . java_values($section->getSectionId()) . PHP_EOL;
        echo "Starting slide: " . $startingSlide . PHP_EOL;
        echo "Slide count: " . $slideCount . PHP_EOL;

        if ($slideCount > 0) {
            echo "First slide via get_Item: " . java_values($sectionSlides->get_Item(0)->getSlideNumber()) . PHP_EOL;
        }

        echo "Slide numbers:";
        for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
            $slide = $sectionSlides->get_Item($slideIndex);
            echo " " . java_values($slide->getSlideNumber());
        }
        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Het lidmaatschap van een sectie wordt bepaald door de sectiestructuur van de presentatie. Bereken het bereik van een sectie niet handmatig op basis van [Section::getStartedFromSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Section/#getStartedFromSlide), dia‑indexen en de startdia van de volgende sectie.

Structurele bewerkingen kunnen zowel de voor een sectie geretourneerde dia's als hun dia‑nummers wijzigen. Dit omvat het herschikken van dia's, het klonen van een dia naar een sectie, een sectie samen met haar dia's verplaatsen, dia's verwijderen en secties verwijderen. Het volgende voorbeeld roept [Section::getSlidesListOfSection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Section/#getSlidesListOfSection) aan na elke dergelijke wijziging in plaats van aannames over de eerdere grenzen van de sectie te behouden.

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $thirdSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $firstSection = $presentation->getSections()->addSection("First", $firstSlide);
    $secondSection = $presentation->getSections()->addSection("Second", $thirdSlide);

    $printSectionSlides = function ($label, $section) {
        $sectionSlides = $section->getSlidesListOfSection();
        $slideCount = java_values($sectionSlides->size());
        echo $label . " (" . $slideCount . " slides):";
        for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
            $slide = $sectionSlides->get_Item($slideIndex);
            echo " " . java_values($slide->getSlideNumber());
        }
        echo PHP_EOL;
    };

    $printSectionSlides("Initially", $firstSection);

    $slidesBeforeClone = $firstSection->getSlidesListOfSection();
    $presentation->getSlides()->addClone($slidesBeforeClone->get_Item(0), $firstSection);
    $printSectionSlides("After cloning into the section", $firstSection);

    $slidesBeforeReorder = $firstSection->getSlidesListOfSection();
    $firstSectionPosition = java_values($slidesBeforeReorder->get_Item(0)->getSlideNumber()) - 1;
    $lastSlideIndex = java_values($slidesBeforeReorder->size()) - 1;
    $presentation->getSlides()->reorder($firstSectionPosition, $slidesBeforeReorder->get_Item($lastSlideIndex));
    $printSectionSlides("After reordering slides", $firstSection);

    $presentation->getSections()->reorderSectionWithSlides($firstSection, 1);
    $printSectionSlides("After moving the section", $firstSection);

    $slidesBeforeRemoval = $firstSection->getSlidesListOfSection();
    $presentation->getSlides()->remove($slidesBeforeRemoval->get_Item(0));
    $printSectionSlides("After removing a slide", $firstSection);

    $presentation->getSections()->removeSectionWithSlides($secondSection);
    $remainingSections = $presentation->getSections();
    $remainingSectionCount = java_values($remainingSections->size());
    for ($sectionIndex = 0; $sectionIndex < $remainingSectionCount; $sectionIndex++) {
        $section = $remainingSections->get_Item($sectionIndex);
        $printSectionSlides("Remaining section", $section);
    }
} finally {
    $presentation->dispose();
}
```

Roep [Section::getSlidesListOfSection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Section/#getSlidesListOfSection) opnieuw aan telkens wanneer dia's of secties worden herschikt, gekloond, verplaatst of verwijderd. Dit houdt de vervolgverwerking in overeenstemming met de huidige presentatiestructuur.

Het PPT‑formaat (PowerPoint 97–2003) behoudt geen sectiemetadata. Gebruik deze werkwijze met een formaat dat secties ondersteunt, zoals PPTX; converteren naar PPT verwijdert de sectiestructuur die nodig is voor latere iteratie.

## **FAQ**

**Worden secties bewaard bij het opslaan naar het PPT‑formaat (PowerPoint 97–2003)?**

Nee. Het PPT‑formaat ondersteunt geen sectiemetadata, waardoor de sectiegroepering verloren gaat bij opslaan naar .ppt.

**Kan een volledige sectie "verborgen" worden?**

Nee. Een sectie heeft geen weergavestatus. Om de inhoud te verbergen, roept u [Slide::setHidden](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Slide/#setHidden) aan voor elke dia in de sectie.

**Hoe kan ik de sectie vinden die een dia bevat?**

Loop door de collectie die geretourneerd wordt door [Presentation::getSections](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation/#getSections), roep voor elke sectie [Section::getSlidesListOfSection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Section/#getSlidesListOfSection) aan en vergelijk de geretourneerde dia's met de doel‑dia. Voor een niet‑lege sectie geeft [Section::getStartedFromSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Section/#getStartedFromSlide) de eerste dia terug; voor een lege sectie geeft het `null` terug.