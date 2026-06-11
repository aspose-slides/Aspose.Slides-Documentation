---
title: Usuwanie slajdów z prezentacji w .NET
linktitle: Usuń slajd
type: docs
weight: 30
url: /pl/net/remove-slide-from-presentation/
keywords:
- usuń slajd
- usunięcie slajdu
- usuń nieużywany slajd
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Bezproblemowo usuwaj slajdy z prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides dla .NET. Otrzymaj przejrzyste przykłady kodu C# i usprawnij swoją pracę."
---
## **Wprowadzenie**

Jeśli slajd (lub jego zawartość) staje się zbędny, możesz go usunąć. Aspose.Slides udostępnia klasę [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) zawierającą [ISlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection), które jest repozytorium wszystkich slajdów w prezentacji. Korzystając ze wskaźników (referencji lub indeksu) do znanego obiektu [ISlide](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/), możesz określić slajd, który chcesz usunąć. 

## **Usuwanie slajdu za pomocą referencji**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) .
1. Uzyskaj referencję do slajdu, który chcesz usunąć, poprzez jego ID lub indeks.
1. Usuń wskazany slajd z prezentacji.
1. Zapisz zmodyfikowaną prezentację. 

Ten kod C# pokazuje, jak usunąć slajd za pomocą referencji:

```c#
// Tworzy obiekt Presentation, który reprezentuje plik prezentacji
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{

    // Dostęp do slajdu poprzez jego indeks w kolekcji slajdów
    ISlide slide = pres.Slides[0];

    // Usuwa slajd za pomocą jego referencji
    pres.Slides.Remove(slide);

    // Zapisuje zmodyfikowaną prezentację
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Usuwanie slajdu według indeksu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) .
1. Usuń slajd z prezentacji poprzez jego pozycję indeksową.
1. Zapisz zmodyfikowaną prezentację. 

Ten kod C# pokazuje, jak usunąć slajd za pomocą indeksu:

```c#
// Tworzy obiekt Presentation, który reprezentuje plik prezentacji
using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
{

    // Usuwa slajd przy użyciu indeksu slajdu
    pres.Slides.RemoveAt(0);

    // Zapisuje zmodyfikowaną prezentację
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Usuwanie nieużywanych slajdów układu**

Aspose.Slides udostępnia metodę [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (z klasy [Compress](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/compress/)), aby umożliwić usunięcie niechcianych i nieużywanych slajdów układu. Ten kod C# pokazuje, jak usunąć slajd układu z prezentacji PowerPoint:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **Usuwanie nieużywanych slajdów master**

Aspose.Slides udostępnia metodę [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (z klasy [Compress](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/compress/)), aby umożliwić usunięcie niechcianych i nieużywanych slajdów master. Ten kod C# pokazuje, jak usunąć slajd master z prezentacji PowerPoint:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Co się dzieje z indeksami slajdów po usunięciu slajdu?**

Po usunięciu kolekcja ([slidecollection](https://reference.aspose.com/slides/pl/net/aspose.slides/slidecollection/)) jest przeliczana: każdy kolejny slajd przesuwa się w lewo o jedną pozycję, więc poprzednie numery indeksów stają się nieaktualne. Jeśli potrzebujesz stabilnego odwołania, użyj trwałego ID slajdu zamiast jego indeksu.

**Czy ID slajdu różni się od jego indeksu i czy zmienia się, gdy usunięte zostaną sąsiednie slajdy?**

Tak. Indeks określa pozycję slajdu i zmienia się, gdy slajdy są dodawane lub usuwane. ID slajdu jest trwałym identyfikatorem i nie zmienia się po usunięciu innych slajdów.

**Jak usunięcie slajdu wpływa na sekcje slajdów?**

Jeśli slajd należał do sekcji, sekcja po prostu będzie zawierała o jeden slajd mniej. Struktura sekcji pozostaje; jeśli sekcja stanie się pusta, możesz [usuń lub zorganizuj sekcje](/slides/pl/net/slide-section/) w razie potrzeby.

**Co się dzieje z notatkami i komentarzami dołączonymi do slajdu po jego usunięciu?**

[Notes](/slides/pl/net/presentation-notes/) i [comments](/slides/pl/net/presentation-comments/) są powiązane z konkretnym slajdem i zostają usunięte razem z nim. Zawartość innych slajdów pozostaje niezmieniona.

**Czym różni się usuwanie slajdów od czyszczenia nieużywanych układów/masterów?**

Usuwanie eliminuje konkretne normalne slajdy z prezentacji. Czyszczenie nieużywanych układów/masterów usuwa slajdy układu lub master, które nie są używane, zmniejszając rozmiar pliku bez zmiany zawartości pozostałych slajdów. Działania te są komplementarne: zazwyczaj najpierw usuwa się slajdy, a potem czyści nieużywane układy i mastery.