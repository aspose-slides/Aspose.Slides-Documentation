---
title: Zarządzanie sekcjami slajdów w prezentacjach w języku Java
linktitle: Sekcja slajdu
type: docs
weight: 90
url: /pl/java/slide-section/
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
- Java
- Aspose.Slides
description: "Zarządzaj sekcjami slajdów za pomocą Aspose.Slides for Java: twórz, zmieniaj nazwę, zmieniaj kolejność, pobieraj i przetwarzaj slajdy sekcji w prezentacjach PPTX."
---
## **Wprowadzenie**

Sekcje organizują kolejne slajdy w nazwane grupy bez zmiany zawartości slajdów. W Aspose.Slides dla języka Java można tworzyć, zmieniać kolejność, zmieniać nazwy, przeglądać i usuwać sekcje za pomocą metody [Presentation.getSections](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getSections--) .

Sekcje są szczególnie przydatne, gdy:

- duża prezentacja musi zostać podzielona na logiczne tematy lub rozdziały;
- różne grupy slajdów są przydzielane różnym współpracownikom;
- slajdy muszą być przetwarzane, przenoszone lub scalane jako grupy.

Wybieraj krótkie nazwy sekcji, które opisują cel grupowanych slajdów. Ponieważ sekcje są częścią struktury prezentacji, używaj API sekcji do określania przynależności zamiast wywnioskowywać ją z pozycji slajdów.

## **Tworzenie i zarządzanie sekcjami**

Użyj [ISectionCollection.addSection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) , aby utworzyć sekcję, podając jej nazwę i slajd początkowy. Aspose.Slides określa, które slajdy należą do sekcji, na podstawie bieżącej struktury sekcji w prezentacji.

Ten sam [ISectionCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isectioncollection/) umożliwia także:

- przeniesienie sekcji wraz ze slajdami przy użyciu [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-);
- usunięcie tylko definicji sekcji za pomocą [ISectionCollection.removeSection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-), zachowując jej slajdy;
- usunięcie sekcji i jej slajdów przy użyciu [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-);
- dodanie pustej sekcji na końcu przy pomocy [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-).

Poniższy przykład tworzy dwie sekcje, przenosi jedną z nich, usuwa ją wraz ze slajdami i dodaje pustą sekcję:

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

Po wykonaniu tych operacji prezentacja zawiera sekcję `Introduction` wraz ze swoimi slajdami oraz pustą sekcję `Appendix`. Sekcja `Results` i jej slajdy zostały usunięte.

## **Zmienianie nazw sekcji**

Aby zmienić nazwę sekcji, wywołaj jej metodę [ISection.setName](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isection/#setName-java.lang.String-). Slajdy i pozycja sekcji pozostają niezmienione.

Poniższy przykład tworzy sekcję i zmienia jej nazwę:

```java
import com.aspose.slides.ISection;
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

## **Pobieranie slajdów z sekcji**

Metoda [Presentation.getSections](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getSections--) zwraca [ISectionCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isectioncollection/), którą można iterować. Dla każdej [ISection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isection/) wywołaj [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isection/#getSlidesListOfSection--) , aby uzyskać slajdy aktualnie do niej należące. Metoda zwraca [ISectionSlideCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isectionslidecollection/), zapewniającą licznik, dostęp indeksowany i iterację.

Poniższy przykład tworzy dwie wypełnione sekcje i jedną pustą, a następnie wypisuje dla każdej sekcji jej [name](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isection/#getName--), [identifier](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isection/#getSectionId--), [starting slide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isection/#getStartedFromSlide--), liczbę slajdów oraz numery slajdów. Używa [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isectionslidecollection/#get_Item-int-) do odczytania pierwszego slajdu oraz rozszerzonej instrukcji `for` do przetworzenia każdego slajdu. Dla pustej sekcji zwrócona kolekcja ma rozmiar zero, metoda nie jest wywoływana, a iteracja nie wykonuje żadnych operacji.

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

Przynależność do sekcji jest określana przez strukturę sekcji w prezentacji. Nie obliczaj ręcznie zakresu sekcji na podstawie [ISection.getStartedFromSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isection/#getStartedFromSlide--), indeksów slajdów i startowego slajdu kolejnej sekcji.

Edycje strukturalne mogą zmienić zarówno zwracane slajdy dla sekcji, jak i ich numery. Obejmuje to zmianę kolejności slajdów, klonowanie slajdu do sekcji, przenoszenie sekcji wraz ze slajdami, usuwanie slajdów oraz usuwanie sekcji. Następny przykład wywołuje [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isection/#getSlidesListOfSection--) po każdej takiej zmianie zamiast zakładać stałe granice sekcji.

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

Wywołuj [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isection/#getSlidesListOfSection--) ponownie, gdy slajdy lub sekcje są zmieniane kolejnością, klonowane, przenoszone lub usuwane. Dzięki temu dalsze przetwarzanie pozostaje zgodne z aktualną strukturą prezentacji.

Format PPT (PowerPoint 97–2003) nie zachowuje metadanych sekcji. Używaj tego przepływu pracy z formatem obsługującym sekcje, takim jak PPTX; konwersja do PPT usuwa strukturę sekcji potrzebną do późniejszej iteracji.

## **FAQ**

**Czy sekcje są zachowywane podczas zapisywania w formacie PPT (PowerPoint 97–2003)?**

Nie. Format PPT nie obsługuje metadanych sekcji, więc grupowanie sekcji zostaje utracone przy zapisie do .ppt.

**Czy całą sekcję można „ukryć”?**

Nie. Sekcja nie ma stanu widoczności. Aby ukryć jej zawartość, wywołaj [ISlide.setHidden](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islide/#setHidden-boolean-) dla każdego slajdu w sekcji.

**Jak znaleźć sekcję zawierającą dany slajd?**

Iteruj po kolekcji zwróconej przez [Presentation.getSections](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getSections--), wywołaj [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isection/#getSlidesListOfSection--) dla każdej sekcji i porównaj zwrócone slajdy z docelowym slajdem. Dla niepustej sekcji [ISection.getStartedFromSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isection/#getStartedFromSlide--) zwraca jej pierwszy slajd; dla pustej sekcji zwraca `null`.