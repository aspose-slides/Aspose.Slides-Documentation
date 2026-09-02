---
title: Zarządzanie sekcjami slajdów w prezentacjach przy użyciu JavaScript
linktitle: Sekcja slajdu
type: docs
weight: 90
url: /pl/nodejs-java/slide-section/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Zarządzaj sekcjami slajdów przy pomocy Aspose.Slides dla Node.js via Java: twórz, zmieniaj nazwę, zmieniaj kolejność, pobieraj i przetwarzaj slajdy sekcji w prezentacjach PPTX."
---
## **Wstęp**

Sekcje organizują kolejne slajdy w nazwane grupy bez zmieniania treści slajdów. Za pomocą Aspose.Slides for Node.js poprzez Java możesz tworzyć, zmieniać kolejność, zmieniać nazwę, przeglądać i usuwać sekcje przy użyciu metody [Presentation.getSections](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getSections).

Sekcje są szczególnie przydatne, gdy:

- duża prezentacja musi być podzielona na logiczne tematy lub rozdziały;
- różne grupy slajdów są przydzielane różnym współpracownikom;
- slajdy muszą być przetwarzane, przenoszone lub łączone jako grupy.

Wybieraj zwięzłe nazwy sekcji, które opisują cel grupowanych slajdów. Ponieważ sekcje są częścią struktury prezentacji, używaj interfejsów API sekcji do określania przynależności zamiast wyprowadzania jej z pozycji slajdów.

## **Tworzenie i zarządzanie sekcjami**

Użyj [SectionCollection.addSection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sectioncollection/#addSection) aby utworzyć sekcję, podając jej nazwę i slajd początkowy. Aspose.Slides określa, które slajdy należą do sekcji na podstawie bieżącej struktury sekcji w prezentacji.

Ta sama [SectionCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sectioncollection/) pozwala także na:

- przeniesienie sekcji wraz z jej slajdami, używając [SectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sectioncollection/#reorderSectionWithSlides);
- usunięcie tylko definicji sekcji za pomocą [SectionCollection.removeSection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sectioncollection/#removeSection), zachowując jej slajdy;
- usunięcie sekcji wraz z jej slajdami przy pomocy [SectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sectioncollection/#removeSectionWithSlides);
- dodanie pustej sekcji na końcu przy pomocy [SectionCollection.appendEmptySection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sectioncollection/#appendEmptySection).

Poniższy przykład tworzy dwie sekcje, przenosi jedną z nich, usuwa ją wraz ze slajdami i dodaje pustą sekcję:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const titleSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    const resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

Po tych operacjach prezentacja zawiera sekcję `Introduction` wraz ze swoimi slajdami oraz pustą sekcję `Appendix`. Sekcja `Results` i jej slajdy zostały usunięte.

## **Zmienianie nazw sekcji**

Aby zmienić nazwę sekcji, wywołaj jej metodę [Section.setName](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/section/#setName). Slajdy sekcji i jej pozycja pozostają niezmienione.

Poniższy przykład tworzy sekcję i zmienia jej nazwę:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Pobieranie slajdów z sekcji**

Metoda [Presentation.getSections](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getSections) zwraca [SectionCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sectioncollection/), którą można uzyskać przez indeks. Dla każdej [Section](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/section/) wywołaj [Section.getSlidesListOfSection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/section/#getSlidesListOfSection), aby uzyskać slajdy, które aktualnie do niej należą. Metoda zwraca [SectionSlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sectionslidecollection/), które udostępnia liczbę elementów i dostęp indeksowy.

Poniższy przykład tworzy dwie wypełnione sekcje i jedną pustą sekcję, a następnie wypisuje dla każdej sekcji jej [name](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/section/#getName), [identifier](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/section/#getSectionId), [starting slide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/section/#getStartedFromSlide), liczbę slajdów oraz numery slajdów. Używa [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sectionslidecollection/#get_Item) do odczytu zarówno pierwszego slajdu, jak i każdego slajdu w kolekcji. Dla pustej sekcji zwrócona kolekcja ma rozmiar zero, dostęp indeksowy jest pomijany, a pętla nie wykonuje żadnych operacji.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    const sections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < sections.size(); sectionIndex++) {
        const section = sections.get_Item(sectionIndex);
        const sectionSlides = section.getSlidesListOfSection();
        const startingSlideObject = section.getStartedFromSlide();
        const startingSlide = startingSlideObject === null ? "none" : startingSlideObject.getSlideNumber().toString();

        console.log("Section: " + section.getName());
        console.log("ID: " + section.getSectionId().toString());
        console.log("Starting slide: " + startingSlide);
        console.log("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            console.log("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        let slideNumbers = "Slide numbers:";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            slideNumbers += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(slideNumbers);
    }
} finally {
    presentation.dispose();
}
```

Przynależność do sekcji określana jest przez strukturę sekcji w prezentacji. Nie obliczaj zakresu sekcji ręcznie na podstawie [Section.getStartedFromSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/section/#getStartedFromSlide), indeksów slajdów i slajdu początkowego kolejnej sekcji.

Modyfikacje strukturalne mogą zmienić zarówno slajdy zwracane dla sekcji, jak i ich numery. Obejmuje to zmianę kolejności slajdów, klonowanie slajdu do sekcji, przenoszenie sekcji wraz ze slajdami, usuwanie slajdów oraz usuwanie sekcji. Następny przykład wywołuje [Section.getSlidesListOfSection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/section/#getSlidesListOfSection) po każdej takiej zmianie zamiast polegać na wcześniejszych założeniach o granicach sekcji.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const firstSection = presentation.getSections().addSection("First", firstSlide);
    const secondSection = presentation.getSections().addSection("Second", thirdSlide);

    const printSectionSlides = (label, section) => {
        const sectionSlides = section.getSlidesListOfSection();
        let output = label + " (" + sectionSlides.size() + " slides):";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            output += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(output);
    };

    printSectionSlides("Initially", firstSection);

    const slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides("After cloning into the section", firstSection);

    const slidesBeforeReorder = firstSection.getSlidesListOfSection();
    const firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    const lastSlideInSection = slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1);
    presentation.getSlides().reorder(firstSectionPosition, lastSlideInSection);
    printSectionSlides("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides("After moving the section", firstSection);

    const slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    const remainingSections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < remainingSections.size(); sectionIndex++) {
        printSectionSlides("Remaining section", remainingSections.get_Item(sectionIndex));
    }
} finally {
    presentation.dispose();
}
```

Wywołuj [Section.getSlidesListOfSection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/section/#getSlidesListOfSection) ponownie za każdym razem, gdy slajdy lub sekcje są przemieszczane, klonowane, przenoszone lub usuwane. Dzięki temu dalsze przetwarzanie pozostaje zgodne z bieżącą strukturą prezentacji.

Format PPT (PowerPoint 97–2003) nie zachowuje metadanych sekcji. Używaj tego przepływu pracy z formatem obsługującym sekcje, takim jak PPTX; konwersja do PPT usuwa strukturę sekcji potrzebną do późniejszych iteracji.

## **FAQ**

**Czy sekcje są zachowywane przy zapisywaniu w formacie PPT (PowerPoint 97–2003)?**

Nie. Format PPT nie obsługuje metadanych sekcji, więc grupowanie sekcji zostaje utracone przy zapisywaniu do .ppt.

**Czy cała sekcja może być „ukryta”?**

Nie. Sekcja nie ma stanu widoczności. Aby ukryć jej zawartość, wywołaj [Slide.setHidden](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/#setHidden) dla każdego slajdu w sekcji.

**Jak mogę znaleźć sekcję zawierającą dany slajd?**

Uzyskaj dostęp do każdej sekcji w kolekcji zwróconej przez [Presentation.getSections](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getSections), wywołaj [Section.getSlidesListOfSection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/section/#getSlidesListOfSection) dla każdej sekcji i porównaj zwrócone slajdy z docelowym slajdem. Dla niepustej sekcji [Section.getStartedFromSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/section/#getStartedFromSlide) zwraca jej pierwszy slajd; dla pustej sekcji zwraca `null`.