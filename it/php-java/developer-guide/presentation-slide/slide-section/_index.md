---
title: Gestire le sezioni di diapositive nelle presentazioni con PHP
linktitle: Sezione di Diapositiva
type: docs
weight: 90
url: /it/php-java/slide-section/
keywords:
- creare sezione
- aggiungere sezione
- modificare sezione
- cambiare sezione
- nome della sezione
- recuperare diapositive della sezione
- elaborare diapositive della sezione
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Gestire le sezioni di diapositive con Aspose.Slides per PHP via Java: creare, rinominare, riordinare, recuperare ed elaborare le diapositive delle sezioni nelle presentazioni PPTX."
---
## **Introduzione**

Le sezioni organizzano diapositive consecutive in gruppi nominati senza modificare il contenuto della diapositiva. Con Aspose.Slides per PHP via Java, è possibile creare, riordinare, rinominare, ispezionare e rimuovere le sezioni tramite il metodo [Presentation::getSections](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation/#getSections).

Le sezioni sono particolarmente utili quando:

- una presentazione di grandi dimensioni deve essere divisa in argomenti o capitoli logici;
- diversi gruppi di diapositive sono assegnati a collaboratori diversi;
- le diapositive devono essere elaborate, spostate o unite come gruppi.

Scegli nomi di sezione concisi che descrivano lo scopo delle diapositive raggruppate. Poiché le sezioni fanno parte della struttura della presentazione, usa le API delle sezioni per determinare l’appartenenza invece di derivarla dalle posizioni delle diapositive.

## **Creare e Gestire le Sezioni**

Usa [SectionCollection::addSection](https://reference.aspose.com/slides/it/php-java/aspose.slides/SectionCollection/#addSection) per creare una sezione specificando il suo nome e la diapositiva iniziale. Aspose.Slides determina a quali diapositive appartiene la sezione dalla struttura delle sezioni corrente della presentazione.

La stessa [SectionCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/SectionCollection/) consente anche di:

- spostare una sezione insieme alle sue diapositive usando [SectionCollection::reorderSectionWithSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/SectionCollection/#reorderSectionWithSlides);
- rimuovere solo la definizione della sezione con [SectionCollection::removeSection](https://reference.aspose.com/slides/it/php-java/aspose.slides/SectionCollection/#removeSection), mantenendo le sue diapositive;
- rimuovere una sezione e le sue diapositive con [SectionCollection::removeSectionWithSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/SectionCollection/#removeSectionWithSlides);
- aggiungere una sezione vuota alla fine con [SectionCollection::appendEmptySection](https://reference.aspose.com/slides/it/php-java/aspose.slides/SectionCollection/#appendEmptySection).

L’esempio seguente crea due sezioni, ne sposta una, la rimuove insieme alle sue diapositive e aggiunge una sezione vuota:

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

Dopo queste operazioni, la presentazione contiene la sezione `Introduction` con le sue diapositive e una sezione vuota `Appendix`. La sezione `Results` e le sue diapositive sono state rimosse.

## **Rinominare le Sezioni**

Per rinominare una sezione, chiama il suo metodo [Section::setName](https://reference.aspose.com/slides/it/php-java/aspose.slides/Section/#setName). Le diapositive e la posizione della sezione rimangono inalterate.

L’esempio seguente crea una sezione e ne cambia il nome:

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

## **Recuperare le Diapositive dalle Sezioni**

Il metodo [Presentation::getSections](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation/#getSections) restituisce una [SectionCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/SectionCollection/) che puoi elaborare per indice. Per ciascuna [Section](https://reference.aspose.com/slides/it/php-java/aspose.slides/Section/), chiama [Section::getSlidesListOfSection](https://reference.aspose.com/slides/it/php-java/aspose.slides/Section/#getSlidesListOfSection) per ottenere le diapositive che attualmente vi appartengono. Il metodo restituisce una [SectionSlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/SectionSlideCollection/), che fornisce un conteggio e l’accesso indicizzato.

L’esempio seguente crea due sezioni popolate e una sezione vuota, quindi stampa per ogni sezione il suo [name](https://reference.aspose.com/slides/it/php-java/aspose.slides/Section/#getName), [identifier](https://reference.aspose.com/slides/it/php-java/aspose.slides/Section/#getSectionId), [starting slide](https://reference.aspose.com/slides/it/php-java/aspose.slides/Section/#getStartedFromSlide), il conteggio delle diapositive e i numeri delle diapositive. Utilizza [SectionCollection::get_Item](https://reference.aspose.com/slides/it/php-java/aspose.slides/SectionCollection/#get_Item) e [SectionSlideCollection::get_Item](https://reference.aspose.com/slides/it/php-java/aspose.slides/SectionSlideCollection/#get_Item) per l’accesso indicizzato. Per la sezione vuota, la collezione restituita ha dimensione zero e `get_Item` non viene chiamato.

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

L’appartenenza a una sezione è determinata dalla struttura delle sezioni della presentazione. Non calcolare manualmente l’intervallo di una sezione da [Section::getStartedFromSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/Section/#getStartedFromSlide), gli indici delle diapositive e la diapositiva iniziale della sezione successiva.

Le modifiche strutturali possono cambiare sia le diapositive restituite per una sezione sia i loro numeri. Ciò include riordinare le diapositive, clonare una diapositiva in una sezione, spostare una sezione insieme alle sue diapositive, rimuovere diapositive e rimuovere sezioni. L’esempio successivo chiama [Section::getSlidesListOfSection](https://reference.aspose.com/slides/it/php-java/aspose.slides/Section/#getSlidesListOfSection) dopo ogni tale modifica invece di mantenere assunzioni sui precedenti confini della sezione.

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

Chiama nuovamente [Section::getSlidesListOfSection](https://reference.aspose.com/slides/it/php-java/aspose.slides/Section/#getSlidesListOfSection) ogni volta che le diapositive o le sezioni vengono riordinate, clonate, spostate o rimosse. Questo mantiene l’elaborazione successiva allineata con la struttura corrente della presentazione.

Il formato PPT (PowerPoint 97–2003) non conserva i metadati delle sezioni. Usa questo flusso di lavoro con un formato che supporta le sezioni, come PPTX; la conversione in PPT rimuove la struttura delle sezioni necessaria per le iterazioni successive.

## **FAQ**

**Le sezioni vengono preservate quando si salva nel formato PPT (PowerPoint 97–2003)?**

No. Il formato PPT non supporta i metadati delle sezioni, quindi il raggruppamento delle sezioni viene perso quando si salva in .ppt.

**È possibile “nascondere” un’intera sezione?**

No. Una sezione non ha uno stato di visibilità. Per nascondere il suo contenuto, chiama [Slide::setHidden](https://reference.aspose.com/slides/it/php-java/aspose.slides/Slide/#setHidden) per ciascuna diapositiva nella sezione.

**Come posso trovare la sezione che contiene una diapositiva?**

Scorri la collezione restituita da [Presentation::getSections](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation/#getSections), chiama [Section::getSlidesListOfSection](https://reference.aspose.com/slides/it/php-java/aspose.slides/Section/#getSlidesListOfSection) per ogni sezione e confronta le diapositive restituite con la diapositiva target. Per una sezione non vuota, [Section::getStartedFromSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/Section/#getStartedFromSlide) restituisce la sua prima diapositiva; per una sezione vuota, restituisce `null`.