---
title: Zarządzanie sekcjami slajdów w prezentacjach na Androidzie
linktitle: Sekcja slajdu
type: docs
weight: 90
url: /pl/androidjava/slide-section/
keywords:
- tworzenie sekcji
- dodawanie sekcji
- edycja sekcji
- zmiana sekcji
- nazwa sekcji
- pobieranie slajdów sekcji
- przetwarzanie slajdów sekcji
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Zarządzaj sekcjami slajdów przy użyciu Aspose.Slides dla Androida w Javie: twórz, zmieniaj nazwy, zmieniaj kolejność, pobieraj i przetwarzaj slajdy sekcji w prezentacjach PPTX."
---
## **Introduction**

Sekcje organizują kolejne slajdy w nazwane grupy bez zmieniania treści slajdu. Za pomocą Aspose.Slides dla Androida przez Java możesz tworzyć, zmieniać kolejność, zmieniać nazwę, przeglądać i usuwać sekcje za pomocą metody [Presentation.getSections](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getSections--).

Sekcje są szczególnie przydatne, gdy:

- duża prezentacja wymaga podzielenia na logiczne tematy lub rozdziały;
- różne grupy slajdów są przydzielane różnym współpracownikom;
- slajdy muszą być przetwarzane, przenoszone lub łączone jako grupy.

Wybieraj krótkie nazwy sekcji, które opisują cel grupowanych slajdów. Ponieważ sekcje są częścią struktury prezentacji, używaj API sekcji do określania przynależności zamiast wyprowadzania jej z pozycji slajdów.

## **Create and Manage Sections**

Użyj [ISectionCollection.addSection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) aby utworzyć sekcję, określając jej nazwę i slajd początkowy. Aspose.Slides określa, które slajdy należą do sekcji, na podstawie bieżącej struktury sekcji w prezentacji.

Ta sama [ISectionCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isectioncollection/) pozwala również:

- przenieść sekcję razem z jej slajdami, używając [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-);
- usunąć tylko definicję sekcji za pomocą [ISectionCollection.removeSection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-), zachowując jej slajdy;
- usunąć sekcję wraz z jej slajdami za pomocą [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-);
- dodać pustą sekcję na końcu za pomocą [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-).

Poniższy przykład tworzy dwie sekcje, przenosi jedną z nich, usuwa ją razem ze slajdami oraz dodaje pustą sekcję:

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide titleSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    ISection resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

Po tych operacjach prezentacja zawiera sekcję `Introduction` wraz ze swoimi slajdami oraz pustą sekcję `Appendix`. Sekcja `Results` i jej slajdy zostały usunięte.

## **Rename Sections**

Aby zmienić nazwę sekcji, wywołaj jej metodę [ISection.setName](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isection/#setName-java.lang.String-). Slajdy sekcji oraz jej pozycja pozostają niezmienione.

Poniższy przykład tworzy sekcję i zmienia jej nazwę:

```java
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISection section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Retrieve Slides from Sections**

Metoda [Presentation.getSections](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getSections--) zwraca [ISectionCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isectioncollection/), po którym możesz iterować. Dla każdej [ISection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isection/), wywołaj [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) aby uzyskać slajdy aktualnie do niej należące. Metoda zwraca [ISectionSlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isectionslidecollection/), które zapewnia liczbę, dostęp indeksowany oraz iterację.

Poniższy przykład tworzy dwie wypełnione sekcje i jedną pustą sekcję, a następnie wypisuje dla każdej sekcji jej [nazwa](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isection/#getName--), [identyfikator](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isection/#getSectionId--), [slajd początkowy](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isection/#getStartedFromSlide--), liczbę slajdów oraz numery slajdów. Używa [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isectionslidecollection/#get_Item-int-) aby odczytać pierwszy slajd oraz rozszerzonej instrukcji `for` do przetworzenia każdego slajdu. Dla pustej sekcji zwrócona kolekcja ma rozmiar zero, metoda nie jest wywoływana, a iteracja nie wykonuje żadnych operacji.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    for (ISection section : presentation.getSections()) {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        String startingSlide = section.getStartedFromSlide() == null ? "none" : Integer.toString(section.getStartedFromSlide().getSlideNumber());

        System.out.println("Section: " + section.getName());
        System.out.println("ID: " + section.getSectionId());
        System.out.println("Starting slide: " + startingSlide);
        System.out.println("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            System.out.println("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        System.out.print("Slide numbers:");
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

Przynależność do sekcji jest określana przez strukturę sekcji w prezentacji. Nie obliczaj ręcznie zakresu sekcji na podstawie [ISection.getStartedFromSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isection/#getStartedFromSlide--), indeksów slajdów oraz slajdu początkowego kolejnej sekcji.

Edycje strukturalne mogą zmienić zarówno slajdy zwracane dla sekcji, jak i ich numery. Obejmuje to zmianę kolejności slajdów, klonowanie slajdu do sekcji, przenoszenie sekcji wraz ze slajdami, usuwanie slajdów i usuwanie sekcji. Następny przykład wywołuje [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) po każdej takiej zmianie zamiast zachowywać założenia o poprzednich granicach sekcji.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

import java.util.function.BiConsumer;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISection firstSection = presentation.getSections().addSection("First", firstSlide);
    ISection secondSection = presentation.getSections().addSection("Second", thirdSlide);

    BiConsumer<String, ISection> printSectionSlides = (label, section) -> {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        System.out.printf("%s (%d slides):", label, sectionSlides.size());
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    };

    printSectionSlides.accept("Initially", firstSection);

    ISectionSlideCollection slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides.accept("After cloning into the section", firstSection);

    ISectionSlideCollection slidesBeforeReorder = firstSection.getSlidesListOfSection();
    int firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    presentation.getSlides().reorder(firstSectionPosition, slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1));
    printSectionSlides.accept("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides.accept("After moving the section", firstSection);

    ISectionSlideCollection slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides.accept("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    for (ISection section : presentation.getSections()) {
        printSectionSlides.accept("Remaining section", section);
    }
} finally {
    presentation.dispose();
}
```

Wywołuj ponownie [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) gdy tylko slajdy lub sekcje są przestawiane, klonowane, przenoszone lub usuwane. Dzięki temu dalsze przetwarzanie będzie zgodne z aktualną strukturą prezentacji.

Format PPT (PowerPoint 97–2003) nie zachowuje metadanych sekcji. Używaj tego przepływu pracy z formatem obsługującym sekcje, takim jak PPTX; konwersja do PPT usuwa strukturę sekcji potrzebną do późniejszej iteracji.

## **FAQ**

**Czy sekcje są zachowywane przy zapisie w formacie PPT (PowerPoint 97–2003)?**

Nie. Format PPT nie obsługuje metadanych sekcji, więc grupowanie sekcji jest tracone podczas zapisywania jako .ppt.

**Czy całą sekcję można "ukryć"?**

Nie. Sekcja nie ma stanu widoczności. Aby ukryć jej zawartość, wywołaj [ISlide.setHidden](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/#setHidden-boolean-) dla każdego slajdu w sekcji.

**Jak mogę znaleźć sekcję, która zawiera dany slajd?**

Iteruj po kolekcji zwróconej przez [Presentation.getSections](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getSections--), wywołaj [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) dla każdej sekcji i porównaj zwrócone slajdy z docelowym slajdem. Dla niepustej sekcji [ISection.getStartedFromSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) zwraca jej pierwszy slajd; dla pustej sekcji zwraca `null`.