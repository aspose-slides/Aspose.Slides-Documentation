---
title: Usuwanie slajdów z prezentacji na Androidzie
linktitle: Usuń slajd
type: docs
weight: 30
url: /pl/androidjava/remove-slide-from-presentation/
keywords:
- usuń slajd
- usuń slajd
- usuń nieużywany slajd
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Bezproblemowo usuń slajdy z prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Androida. Uzyskaj przejrzyste przykłady kodu Java i usprawnij swój przepływ pracy."
---
## **Introduction**

Jeśli slajd (lub jego zawartość) staje się zbędny, możesz go usunąć. Aspose.Slides udostępnia klasę [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/), która kapsułkuje [ISlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidecollection/), będącą repozytorium wszystkich slajdów w prezentacji. Korzystając z wskaźników (referencji lub indeksu) do znanego obiektu [ISlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/), możesz określić slajd, który chcesz usunąć.

## **Remove a Slide by Reference**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu, który chcesz usunąć, przy użyciu jego ID lub indeksu.
1. Usuń wskazany slajd z prezentacji.
1. Zapisz zmodyfikowaną prezentację.

Poniższy kod Java pokazuje, jak usunąć slajd przy użyciu referencji:

```java
// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
Presentation pres = new Presentation("demo.pptx");
try {
    // Uzyskaj dostęp do slajdu poprzez jego indeks w kolekcji slajdów
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Usuwa slajd przy użyciu jego referencji
    pres.getSlides().remove(slide);
    
    // Zapisuje zmodyfikowaną prezentację
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Remove a Slide by Index**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
1. Usuń slajd z prezentacji, podając jego pozycję indeksową.
1. Zapisz zmodyfikowaną prezentację.

Poniższy kod Java pokazuje, jak usunąć slajd przy użyciu indeksu:

```java
// Tworzy obiekt Presentation, który reprezentuje plik prezentacji
Presentation pres = new Presentation("demo.pptx");
try {
    // Usuwa slajd poprzez jego indeks
    pres.getSlides().removeAt(0);
    
    // Zapisuje zmodyfikowaną prezentację
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Remove Unused Layout Slides**

Aspose.Slides udostępnia metodę [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (z klasy [Compress](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/)), która umożliwia usunięcie niechcianych i nieużywanych slajdów układu. Poniższy kod Java pokazuje, jak usunąć slajd układu z prezentacji PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Remove Unused Master Slides**

Aspose.Slides udostępnia metodę [removeUnusedMasterSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (z klasy [Compress](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/)), która umożliwia usunięcie niechcianych i nieużywanych slajdów master. Poniższy kod Java pokazuje, jak usunąć slajd master z prezentacji PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```

## **FAQ**

**What happens to slide indexes after I delete a slide?**

Po usunięciu kolekcja [collection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slidecollection/) ponownie indeksuje się: każdy kolejny slajd przesuwa się o jedną pozycję w lewo, więc poprzednie numery indeksów stają się nieaktualne. Jeśli potrzebujesz trwałego odniesienia, użyj trwałego identyfikatora (ID) każdego slajdu zamiast jego indeksu.

**Is a slide’s ID different from its index, and does it change when neighboring slides are deleted?**

Tak. Indeks określa pozycję slajdu i zmienia się, gdy slajdy są dodawane lub usuwane. ID slajdu jest trwałym identyfikatorem i nie zmienia się, gdy usunięte zostaną inne slajdy.

**How does deleting a slide affect slide sections?**

Jeśli slajd należał do sekcji, ta sekcja po prostu będzie zawierała o jeden slajd mniej. Struktura sekcji pozostaje niezmieniona; jeśli sekcja stanie się pusta, możesz [remove or reorganize sections](/slides/pl/androidjava/slide-section/) w razie potrzeby.

**What happens to notes and comments attached to a slide when it’s deleted?**

[Notes](/slides/pl/androidjava/presentation-notes/) i [comments](/slides/pl/androidjava/presentation-comments/) są powiązane z konkretnym slajdem i zostają usunięte razem z nim. Zawartość innych slajdów pozostaje niezmieniona.

**How is deleting slides different from cleaning up unused layouts/masters?**

Usuwanie eliminuje konkretne zwykłe slajdy z zestawu. Czyszczenie nieużywanych układów/masterów usuwa slajdy układu lub master, do których nic nie odwołuje się, zmniejszając rozmiar pliku bez zmiany zawartości pozostałych slajdów. Działania te są komplementarne: zazwyczaj najpierw usuwa się slajdy, a potem czyści nieużywane układy/mastery.