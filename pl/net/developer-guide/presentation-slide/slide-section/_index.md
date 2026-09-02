---
title: Zarządzanie sekcjami slajdów w prezentacjach w .NET
linktitle: Sekcja slajdu
type: docs
weight: 100
url: /pl/net/slide-section/
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
- .NET
- C#
- Aspose.Slides
description: "Zarządzaj sekcjami slajdów za pomocą Aspose.Slides dla .NET: twórz, zmieniaj nazwę, przestawiaj, pobieraj i przetwarzaj slajdy sekcji w prezentacjach PPTX."
---
## **Wprowadzenie**

Sekcje organizują kolejne slajdy w nazwane grupy bez zmiany zawartości slajdów. Za pomocą Aspose.Slides dla .NET możesz tworzyć, zmieniać kolejność, zmieniać nazwę, przeglądać i usuwać sekcje za pośrednictwem właściwości [Presentation.Sections](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/sections/).

Sekcje są szczególnie przydatne, gdy:

- duża prezentacja musi zostać podzielona na logiczne tematy lub rozdziały;
- różne grupy slajdów są przydzielane różnym współpracownikom;
- slajdy muszą być przetwarzane, przenoszone lub łączone jako grupy.

Wybieraj krótkie nazwy sekcji, które opisują cel grupowanych slajdów. Ponieważ sekcje są częścią struktury prezentacji, używaj interfejsów API sekcji, aby określić przynależność, zamiast wyprowadzać ją z pozycji slajdów.

## **Tworzenie i zarządzanie sekcjami**

Użyj [ISectionCollection.AddSection](https://reference.aspose.com/slides/pl/net/aspose.slides/sectioncollection/addsection/), aby utworzyć sekcję, podając jej nazwę i slajd początkowy. Aspose.Slides określa, które slajdy należą do sekcji, na podstawie bieżącej struktury sekcji w prezentacji.

Ta sama [ISectionCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/isectioncollection/) umożliwia także:

- przenieść sekcję wraz z jej slajdami, używając [ISectionCollection.ReorderSectionWithSlides](https://reference.aspose.com/slides/pl/net/aspose.slides/sectioncollection/reordersectionwithslides/);
- usunąć tylko definicję sekcji przy użyciu [ISectionCollection.RemoveSection](https://reference.aspose.com/slides/pl/net/aspose.slides/sectioncollection/removesection/), zachowując jej slajdy;
- usunąć sekcję i jej slajdy przy użyciu [ISectionCollection.RemoveSectionWithSlides](https://reference.aspose.com/slides/pl/net/aspose.slides/sectioncollection/removesectionwithslides/);
- dodać pustą sekcję na końcu przy użyciu [ISectionCollection.AppendEmptySection](https://reference.aspose.com/slides/pl/net/aspose.slides/sectioncollection/appendemptysection/).

Przykład poniżej tworzy dwie sekcje, przenosi jedną z nich, usuwa ją wraz ze slajdami i dodaje pustą sekcję:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var titleSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var resultsSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", titleSlide);
var resultsSection = presentation.Sections.AddSection("Results", resultsSlide);

presentation.Sections.ReorderSectionWithSlides(resultsSection, 0);
presentation.Sections.RemoveSectionWithSlides(resultsSection);
presentation.Sections.AppendEmptySection("Appendix");
```

Po tych operacjach prezentacja zawiera sekcję `Introduction` wraz ze swoimi slajdami oraz pustą sekcję `Appendix`. Sekcja `Results` i jej slajdy zostały usunięte.

## **Zmienianie nazw sekcji**

Aby zmienić nazwę sekcji, ustaw jej właściwość [ISection.Name](https://reference.aspose.com/slides/pl/net/aspose.slides/isection/name/). Slajdy sekcji i jej pozycja pozostają niezmienione.

Przykład poniżej tworzy sekcję i zmienia jej nazwę:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var section = presentation.Sections.AddSection("Overview", slide);
section.Name = "Introduction";
```

## **Pobieranie slajdów z sekcji**

Właściwość [Presentation.Sections](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/sections/) zwraca [ISectionCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/isectioncollection/), który możesz wyliczyć. Dla każdej [ISection](https://reference.aspose.com/slides/pl/net/aspose.slides/isection/) wywołaj [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/pl/net/aspose.slides/isection/getslideslistofsection/), aby uzyskać slajdy, które aktualnie do niej należą. Metoda zwraca [ISectionSlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/isectionslidecollection/), który zapewnia liczbę, dostęp indeksowany i możliwość iteracji.

Poniższy przykład tworzy dwie wypełnione sekcje i jedną pustą sekcję, a następnie wypisuje każdej sekcji jej [nazwa](https://reference.aspose.com/slides/pl/net/aspose.slides/isection/name/), [identyfikator](https://reference.aspose.com/slides/pl/net/aspose.slides/isection/sectionid/), [slajd początkowy](https://reference.aspose.com/slides/pl/net/aspose.slides/isection/startedfromslide/), liczbę slajdów i numery slajdów. Używa indeksera kolekcji, aby odczytać pierwszy slajd, oraz pętli foreach do przetworzenia każdego slajdu. Dla pustej sekcji zwrócona kolekcja ma liczbę równą zero, indekser nie jest używany, a iteracja nie wykonuje żadnych kroków.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", firstSlide);
presentation.Sections.AddSection("Details", thirdSlide);
presentation.Sections.AppendEmptySection("Appendix");

foreach (var section in presentation.Sections)
{
    var sectionSlides = section.GetSlidesListOfSection();
    var startingSlide = section.StartedFromSlide == null ? "none" : section.StartedFromSlide.SlideNumber.ToString();

    Console.WriteLine($"Section: {section.Name}");
    Console.WriteLine($"ID: {section.SectionId}");
    Console.WriteLine($"Starting slide: {startingSlide}");
    Console.WriteLine($"Slide count: {sectionSlides.Count}");

    if (sectionSlides.Count > 0)
    {
        Console.WriteLine($"First slide via indexer: {sectionSlides[0].SlideNumber}");
    }

    Console.Write("Slide numbers:");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}
```

Członkostwo w sekcji jest określane przez strukturę sekcji w prezentacji. Nie obliczaj ręcznie zakresu sekcji na podstawie [ISection.StartedFromSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/isection/startedfromslide/), indeksów slajdów i slajdu początkowego kolejnej sekcji.

Zmiany strukturalne mogą zmienić zarówno slajdy zwracane dla sekcji, jak i ich numery. Obejmuje to zmianę kolejności slajdów, klonowanie slajdu do sekcji, przenoszenie sekcji wraz z jej slajdami, usuwanie slajdów i usuwanie sekcji. W następnym przykładzie wywołuje się [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/pl/net/aspose.slides/isection/getslideslistofsection/) po każdej takiej zmianie, zamiast zachowywać założenia dotyczące wcześniejszych granic sekcji.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var firstSection = presentation.Sections.AddSection("First", firstSlide);
var secondSection = presentation.Sections.AddSection("Second", thirdSlide);

static void PrintSectionSlides(string label, ISection section)
{
    var sectionSlides = section.GetSlidesListOfSection();
    Console.Write($"{label} ({sectionSlides.Count} slides):");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}

PrintSectionSlides("Initially", firstSection);

var slidesBeforeClone = firstSection.GetSlidesListOfSection();
presentation.Slides.AddClone(slidesBeforeClone[0], firstSection);
PrintSectionSlides("After cloning into the section", firstSection);

var slidesBeforeReorder = firstSection.GetSlidesListOfSection();
var firstSectionPosition = slidesBeforeReorder[0].SlideNumber - 1;
presentation.Slides.Reorder(firstSectionPosition, slidesBeforeReorder[slidesBeforeReorder.Count - 1]);
PrintSectionSlides("After reordering slides", firstSection);

presentation.Sections.ReorderSectionWithSlides(firstSection, 1);
PrintSectionSlides("After moving the section", firstSection);

var slidesBeforeRemoval = firstSection.GetSlidesListOfSection();
presentation.Slides.Remove(slidesBeforeRemoval[0]);
PrintSectionSlides("After removing a slide", firstSection);

presentation.Sections.RemoveSectionWithSlides(secondSection);
foreach (var section in presentation.Sections)
{
    PrintSectionSlides("Remaining section", section);
}
```

Wywołuj ponownie [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/pl/net/aspose.slides/isection/getslideslistofsection/) za każdym razem, gdy slajdy lub sekcje są przestawiane, klonowane, przenoszone lub usuwane. Dzięki temu dalsze przetwarzanie pozostaje zgodne z bieżącą strukturą prezentacji.

Format PPT (PowerPoint 97–2003) nie zachowuje metadanych sekcji. Użyj tego przepływu pracy z formatem obsługującym sekcje, takim jak PPTX; konwersja do PPT usuwa strukturę sekcji potrzebną do późniejszego wyliczania.

## **FAQ**

**Czy sekcje są zachowywane przy zapisywaniu w formacie PPT (PowerPoint 97–2003)?**

Nie. Format PPT nie obsługuje metadanych sekcji, dlatego grupowanie sekcji zostaje utracone przy zapisywaniu do .ppt.

**Czy cała sekcja może być „ukryta”?**

Nie. Sekcja nie posiada stanu widoczności. Aby ukryć jej zawartość, ustaw właściwość [ISlide.Hidden](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/hidden/) dla każdego slajdu w sekcji.

**Jak mogę znaleźć sekcję, która zawiera określony slajd?**

Wylicz [Presentation.Sections](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/sections/), wywołaj [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/pl/net/aspose.slides/isection/getslideslistofsection/) dla każdej sekcji i porównaj zwrócone slajdy z docelowym slajdem. Dla niepustej sekcji [ISection.StartedFromSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/isection/startedfromslide/) zwraca jej pierwszy slajd; dla pustej sekcji zwraca `null`.