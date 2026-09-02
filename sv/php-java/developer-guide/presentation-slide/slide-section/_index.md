---
title: "Hantera bildsektioner i presentationer med PHP"
linktitle: "Bildsektion"
type: docs
weight: 90
url: /sv/php-java/slide-section/
keywords:
- skapa sektion
- lägga till sektion
- redigera sektion
- ändra sektion
- sektionsnamn
- hämta sektionens bilder
- bearbeta sektionbilder
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Hantera bildsektioner med Aspose.Slides för PHP via Java: skapa, byta namn, omordna, hämta och bearbeta sektionbilder i PPTX-presentationer."
---
## **Introduktion**

Sektioner organiserar på varandra följande bilder i namngivna grupper utan att ändra bildens innehåll. Med Aspose.Slides för PHP via Java kan du skapa, omordna, byta namn, granska och ta bort sektioner via metoden [Presentation::getSections](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation/#getSections).

Sektioner är särskilt användbara när:

- en stor presentation behöver delas upp i logiska ämnen eller kapitel;
- olika grupper av bilder tilldelas olika medarbetare;
- bilder måste bearbetas, flyttas eller slås ihop som grupper.

Välj koncisa sektionsnamn som beskriver syftet med de grupperade bilderna. Eftersom sektioner är en del av presentationens struktur, använd sektions‑API:erna för att fastställa medlemskap istället för att härleda det från bildpositioner.

## **Skapa och hantera sektioner**

Använd [SectionCollection::addSection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SectionCollection/#addSection) för att skapa en sektion genom att ange dess namn och startbild. Aspose.Slides bestämmer vilka bilder som tillhör sektionen utifrån presentationens aktuella sektionsstruktur.

Samma [SectionCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SectionCollection/) låter dig också:

- flytta en sektion tillsammans med dess bilder genom att använda [SectionCollection::reorderSectionWithSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SectionCollection/#reorderSectionWithSlides);
- ta bort endast sektionens definition med [SectionCollection::removeSection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SectionCollection/#removeSection), vilket behåller dess bilder;
- ta bort en sektion och dess bilder med [SectionCollection::removeSectionWithSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SectionCollection/#removeSectionWithSlides);
- lägga till en tom sektion i slutet med [SectionCollection::appendEmptySection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SectionCollection/#appendEmptySection).

Följande exempel skapar två sektioner, flyttar en av dem, tar bort den tillsammans med dess bilder och lägger till en tom sektion:

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

Efter dessa operationer innehåller presentationen sektionen `Introduction` med dess bilder samt en tom sektion `Appendix`. Sektionen `Results` och dess bilder har tagits bort.

## **Byt namn på sektioner**

För att byta namn på en sektion, anropa dess [Section::setName](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Section/#setName)-metod. Sektionens bilder och position förblir oförändrade.

Följande exempel skapar en sektion och ändrar dess namn:

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

## **Hämta bilder från sektioner**

[Presentation::getSections](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation/#getSections)-metoden returnerar en [SectionCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SectionCollection/) som du kan bearbeta enligt index. För varje [Section](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Section/), anropa [Section::getSlidesListOfSection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Section/#getSlidesListOfSection) för att hämta de bilder som för närvarande tillhör den. Metoden returnerar en [SectionSlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SectionSlideCollection/), som tillhandahåller en räknare och indexerad åtkomst.

Följande exempel skapar två fyllda sektioner och en tom sektion, och skriver sedan ut varje sektions namn, identifierare, startbild, antalet bilder och bildnummer. Det använder [SectionCollection::get_Item](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SectionCollection/#get_Item) och [SectionSlideCollection::get_Item](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SectionSlideCollection/#get_Item) för indexerad åtkomst. För den tomma sektionen har den returnerade samlingen storlek noll och `get_Item` anropas inte.

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

Sektionsmedlemskap bestäms av presentationens sektionsstruktur. Beräkna inte en sektions intervall manuellt utifrån [Section::getStartedFromSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Section/#getStartedFromSlide), bildindex och nästa sektions startbild.

Strukturella ändringar kan förändra både de bilder som returneras för en sektion och deras bildnummer. Detta inkluderar omordning av bilder, kloning av en bild in i en sektion, flytt av en sektion tillsammans med dess bilder, borttagning av bilder och borttagning av sektioner. Nästa exempel anropar [Section::getSlidesListOfSection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Section/#getSlidesListOfSection) efter varje sådan förändring istället för att behålla antaganden om sektionens tidigare gränser.

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

Anropa [Section::getSlidesListOfSection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Section/#getSlidesListOfSection) igen när bilder eller sektioner omordnas, klonas, flyttas eller tas bort. Detta håller efterföljande bearbetning i linje med den aktuella presentationsstrukturen.

PPT‑formatet (PowerPoint 97–2003) behåller inte sektionsmetadata. Använd detta arbetsflöde med ett format som stödjer sektioner, som PPTX; konvertering till PPT tar bort sektionsstrukturen som behövs för senare iteration.

## **Vanliga frågor**

**Behålls sektioner när man sparar till PPT (PowerPoint 97–2003)-formatet?**

Nej. PPT-formatet stödjer inte sektionsmetadata, så sektionsgruppering går förlorad när man sparar till .ppt.

**Kan en hel sektion ”gömmas”?**

Nej. En sektion har inget synlighetstillstånd. För att gömma dess innehåll, anropa [Slide::setHidden](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Slide/#setHidden) för varje bild i sektionen.

**Hur kan jag hitta sektionen som innehåller en bild?**

Loopa igenom samlingen som returneras av [Presentation::getSections](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation/#getSections), anropa [Section::getSlidesListOfSection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Section/#getSlidesListOfSection) för varje sektion och jämför de returnerade bilderna med mål‑bilden. För en icke‑tom sektion returnerar [Section::getStartedFromSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Section/#getStartedFromSlide) dess första bild; för en tom sektion returnerar den `null`.