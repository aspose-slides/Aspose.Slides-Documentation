---
title: Zarządzanie sekcjami slajdów w prezentacjach przy użyciu PHP
linktitle: Sekcja slajdu
type: docs
weight: 90
url: /pl/php-java/slide-section/
keywords:
- utwórz sekcję
- dodaj sekcję
- edytuj sekcję
- zmień sekcję
- nazwa sekcji
- pobierz slajdy sekcji
- przetwarzaj slajdy sekcji
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Zarządzaj sekcjami slajdów przy użyciu Aspose.Slides dla PHP via Java: twórz, zmieniaj nazwę, zmieniaj kolejność, pobieraj i przetwarzaj slajdy sekcji w prezentacjach PPTX."
---
## **Wprowadzenie**

Sekcje organizują kolejne slajdy w nazwane grupy bez zmiany zawartości slajdów. Za pomocą Aspose.Slides dla PHP poprzez Java możesz tworzyć, zmieniać kolejność, zmieniać nazwę, przeglądać i usuwać sekcje za pomocą metody [Presentation::getSections](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation/#getSections).

Sekcje są szczególnie przydatne, gdy:

- duża prezentacja musi zostać podzielona na logiczne tematy lub rozdziały;
- różne grupy slajdów są przydzielane różnym współpracownikom;
- slajdy muszą być przetwarzane, przenoszone lub łączone jako grupy.

Wybieraj zwięzłe nazwy sekcji, które opisują przeznaczenie grupowanych slajdów. Ponieważ sekcje są częścią struktury prezentacji, używaj interfejsów API sekcji do określania przynależności zamiast wyprowadzania jej z pozycji slajdów.

## **Tworzenie i zarządzanie sekcjami**

Użyj [SectionCollection::addSection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SectionCollection/#addSection), aby utworzyć sekcję, podając jej nazwę i slajd początkowy. Aspose.Slides określa, które slajdy należą do sekcji, na podstawie bieżącej struktury sekcji w prezentacji.

Ta sama [SectionCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SectionCollection/) umożliwia również:

- przenieść sekcję wraz z jej slajdami, używając [SectionCollection::reorderSectionWithSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SectionCollection/#reorderSectionWithSlides);
- usunąć tylko definicję sekcji przy użyciu [SectionCollection::removeSection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SectionCollection/#removeSection), zachowując jej slajdy;
- usunąć sekcję i jej slajdy przy użyciu [SectionCollection::removeSectionWithSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SectionCollection/#removeSectionWithSlides);
- dodać pustą sekcję na końcu przy użyciu [SectionCollection::appendEmptySection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SectionCollection/#appendEmptySection).

Poniższy przykład tworzy dwie sekcje, przenosi jedną z nich, usuwa ją wraz ze slajdami i dodaje pustą sekcję:

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

Po tych operacjach prezentacja zawiera sekcję `Introduction` wraz ze swoimi slajdami oraz pustą sekcję `Appendix`. Sekcja `Results` i jej slajdy zostały usunięte.

## **Zmienianie nazw sekcji**

Aby zmienić nazwę sekcji, wywołaj jej metodę [Section::setName](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Section/#setName). Slajdy sekcji i jej pozycja pozostają niezmienione.

Poniższy przykład tworzy sekcję i zmienia jej nazwę:

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

## **Pobieranie slajdów z sekcji**

Metoda [Presentation::getSections](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation/#getSections) zwraca [SectionCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SectionCollection/), którą możesz przetwarzać przy użyciu indeksu. Dla każdej [Section](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Section/) wywołaj [Section::getSlidesListOfSection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Section/#getSlidesListOfSection), aby uzyskać slajdy aktualnie do niej należące. Metoda zwraca [SectionSlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SectionSlideCollection/), które udostępnia liczbę i dostęp indeksowany.

Poniższy przykład tworzy dwie wypełnione sekcje i jedną pustą sekcję, a następnie wypisuje dla każdej sekcji jej [name](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Section/#getName), [identifier](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Section/#getSectionId), [starting slide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Section/#getStartedFromSlide), liczbę slajdów oraz numery slajdów. Używa [SectionCollection::get_Item](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SectionCollection/#get_Item) i [SectionSlideCollection::get_Item](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SectionSlideCollection/#get_Item) do dostępu indeksowanego. Dla pustej sekcji zwrócona kolekcja ma rozmiar zero i metoda `get_Item` nie jest wywoływana.

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

Członkostwo w sekcji jest określane przez strukturę sekcji w prezentacji. Nie obliczaj ręcznie zakresu sekcji na podstawie [Section::getStartedFromSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Section/#getStartedFromSlide), indeksów slajdów i slajdu początkowego kolejnej sekcji.

Edytowanie struktury może zmienić zarówno zwracane slajdy dla sekcji, jak i ich numery. Obejmuje to zmianę kolejności slajdów, klonowanie slajdu do sekcji, przenoszenie sekcji wraz ze slajdami, usuwanie slajdów oraz usuwanie sekcji. Następny przykład wywołuje [Section::getSlidesListOfSection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Section/#getSlidesListOfSection) po każdej takiej zmianie zamiast zachowywania założeń o poprzednich granicach sekcji.

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

Wywołuj [Section::getSlidesListOfSection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Section/#getSlidesListOfSection) ponownie, gdy tylko slajdy lub sekcje są przestawiane, klonowane, przenoszone lub usuwane. Dzięki temu dalsze przetwarzanie jest zgodne z bieżącą strukturą prezentacji.

Format PPT (PowerPoint 97–2003) nie zachowuje metadanych sekcji. Użyj tego przepływu pracy w formacie obsługującym sekcje, takim jak PPTX; konwersja do PPT usuwa strukturę sekcji potrzebną do późniejszej iteracji.

## **FAQ**

**Czy sekcje są zachowywane przy zapisie do formatu PPT (PowerPoint 97–2003)?**

Nie. Format PPT nie obsługuje metadanych sekcji, więc grupowanie sekcji jest tracone przy zapisie do .ppt.

**Czy całą sekcję można „ukryć”?**

Nie. Sekcja nie posiada stanu widoczności. Aby ukryć jej zawartość, wywołaj [Slide::setHidden](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Slide/#setHidden) dla każdego slajdu w sekcji.

**Jak znaleźć sekcję zawierającą dany slajd?**

Iteruj po kolekcji zwróconej przez [Presentation::getSections](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation/#getSections), wywołaj [Section::getSlidesListOfSection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Section/#getSlidesListOfSection) dla każdej sekcji i porównaj zwrócone slajdy z docelowym slajdem. Dla niepustej sekcji [Section::getStartedFromSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Section/#getStartedFromSlide) zwraca jej pierwszy slajd; dla pustej sekcji zwraca `null`.