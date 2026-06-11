---
title: Zastosowanie lub zmiana układów slajdów w .NET
linktitle: Układ slajdu
type: docs
weight: 60
url: /pl/net/slide-layout/
keywords:
- układ slajdu
- układ treści
- pole zastępcze
- projektowanie prezentacji
- projektowanie slajdów
- nieużywany układ
- widoczność stopki
- slajd tytułowy
- tytuł i treść
- nagłówek sekcji
- dwa elementy treści
- porównanie
- tylko tytuł
- pusty układ
- treść z podpisem
- obraz z podpisem
- tytuł i pionowy tekst
- pionowy tytuł i tekst
- PowerPoint
- OpenDocument
- prezentacja
- C#
- .NET
- Aspose.Slides
description: "Zarządzaj i dostosowuj układy slajdów w Aspose.Slides dla .NET. Poznaj typy układów, kontrolę pól zastępczych i widoczność stopek za pomocą przykładów kodu C#."
---
## **Wprowadzenie**

Układ slajdu definiuje rozmieszczenie pól zastępczych i formatowanie treści na slajdzie. Kontroluje, które pola zastępcze są dostępne i gdzie się pojawiają. Układy slajdów pomagają szybko i konsekwentnie projektować prezentacje — niezależnie od tego, czy tworzysz coś prostego, czy bardziej złożonego. Niektóre z najczęściej używanych układów slajdów w programie PowerPoint to:

**Układ slajdu tytułowego** – Zawiera dwa pola zastępcze tekstu: jedno dla tytułu i jedno dla podtytułu.

**Układ tytuł i treść** – Zawiera mniejsze pole tytułu u góry oraz większe poniżej dla głównej treści (takiej jak tekst, wypunktowanie, wykresy, obrazy i inne).

**Układ pusty** – Nie zawiera żadnych pól zastępczych, dając pełną kontrolę nad projektowaniem slajdu od podstaw.

Układy slajdów są częścią wzorca slajdu (slide master), który jest slajdem najwyższego poziomu definiującym style układów w całej prezentacji. Do układów slajdów możesz uzyskać dostęp i modyfikować je poprzez wzorzec slajdu — po typie, nazwie lub unikalnym identyfikatorze. Alternatywnie możesz edytować konkretny układ slajdu bezpośrednio w prezentacji.

Aby pracować z układami slajdów w Aspose.Slides dla .NET, możesz używać:

- Właściwości takich jak [LayoutSlides](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/layoutslides/) i [Masters](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/masters/) w klasie [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/)
- Typów takich jak [ILayoutSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutplaceholdermanager/) oraz [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Aby dowiedzieć się więcej o pracy ze slajdami-mistrzami, przeczytaj artykuł [Slide Master](/slides/pl/net/slide-master/).
{{% /alert %}}

## **Dodaj układy slajdów do prezentacji**

Aby dostosować wygląd i strukturę swoich slajdów, możesz potrzebować dodać nowe układy slajdów do prezentacji. Aspose.Slides dla .NET umożliwia sprawdzenie, czy dany układ już istnieje, dodanie nowego w razie potrzeby i użycie go do wstawiania slajdów opartych na tym układzie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
1. Uzyskaj dostęp do [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterlayoutslidecollection/).
1. Sprawdź, czy żądany układ slajdu już istnieje w kolekcji. Jeśli nie, dodaj potrzebny układ slajdu.
1. Dodaj pusty slajd oparty na nowym układzie slajdu.
1. Zapisz prezentację.

Poniższy kod C# pokazuje, jak dodać układ slajdu do prezentacji PowerPoint:

```cs
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Przejdź przez typy układów slajdów, aby wybrać układ slajdu.
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // Sytuacja, w której prezentacja nie zawiera wszystkich typów układów.
        // Plik prezentacji zawiera tylko typy układów Blank i Custom.
        // Jednak układy slajdów z typami niestandardowymi mogą mieć rozpoznawalne nazwy,
        // takie jak "Title", "Title and Content", itp., które mogą być użyte do wyboru układu slajdu.
        // Możesz również oprzeć się na zestawie typów kształtów pól zastępczych.
        // Na przykład slajd tytułowy powinien mieć tylko typ pola zastępczego Title, i tak dalej.
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Title and Object")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Title")
                {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null)
            {
                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Dodaj pusty slajd przy użyciu dodanego układu slajdu.
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // Zapisz prezentację na dysku.  
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Usuń nieużywane układy slajdów**

Aspose.Slides udostępnia metodę [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) z klasy [Compress](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/compress/), aby umożliwić usunięcie niechcianych i nieużywanych układów slajdów.

Poniższy kod C# pokazuje, jak usunąć układ slajdu z prezentacji PowerPoint:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(presentation);
    
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Dodaj pola zastępcze do układów slajdów**

Aspose.Slides udostępnia właściwość [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutslide/placeholdermanager/), która pozwala dodawać nowe pola zastępcze do układu slajdu.

Ten menedżer zawiera metody dla następujących typów pól zastępczych:

| Placeholder PowerPoint | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutplaceholdermanager/) Metoda |
| ---------------------- | ------------------------------------------------------------ |
| ![Content](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

Poniższy kod C# demonstruje, jak dodać nowe kształty pól zastępczych do układu pustego:

```cs
using (var presentation = new Presentation())
{
    // Pobierz układ slajdu Blank.
    ILayoutSlide layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Pobierz menedżera pól zastępczych układu slajdu.
    ILayoutPlaceholderManager placeholderManager = layout.PlaceholderManager;

    // Dodaj różne pola zastępcze do układu slajdu Blank.
    placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
    placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
    placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

    // Dodaj nowy slajd z układem Blank.
    ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

    presentation.Save("Placeholders.pptx", SaveFormat.Pptx);
}
```

Rezultat:

![The placeholders on the layout slide](add_placeholders.png)

## **Ustaw widoczność stopki dla układu slajdu**

W prezentacjach PowerPoint elementy stopki, takie jak data, numer slajdu i własny tekst, mogą być wyświetlane lub ukrywane w zależności od układu slajdu. Aspose.Slides dla .NET pozwala kontrolować widoczność tych pól zastępczych stopki. Jest to przydatne, gdy chcesz, aby niektóre układy wyświetlały informacje stopki, a inne pozostały czyste i minimalistyczne.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
1. Pobierz odwołanie do układu slajdu po jego indeksie.
1. Ustaw pole stopki slajdu jako widoczne.
1. Ustaw pole numeru slajdu jako widoczne.
1. Ustaw pole daty i godziny jako widoczne.
1. Zapisz prezentację.

Poniższy kod C# pokazuje, jak ustawić widoczność stopki slajdu i wykonać powiązane operacje:

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.LayoutSlides[0].HeaderFooterManager;

    if (!headerFooterManager.IsFooterVisible)
    {
        headerFooterManager.SetFooterVisibility(true);
    }

    if (!headerFooterManager.IsSlideNumberVisible)
    {
        headerFooterManager.SetSlideNumberVisibility(true);
    }

    if (!headerFooterManager.IsDateTimeVisible)
    {
        headerFooterManager.SetDateTimeVisibility(true);
    }

    headerFooterManager.SetFooterText("Footer text");
    headerFooterManager.SetDateTimeText("Date and time text");

    presentation.Save("Presentation.ppt", SaveFormat.Ppt);
}
```

## **Ustaw widoczność stopki potomnych układów slajdu**

W prezentacjach PowerPoint elementy stopki, takie jak data, numer slajdu i własny tekst, mogą być kontrolowane na poziomie slajdu‑mistrza, aby zapewnić spójność we wszystkich układach slajdów. Aspose.Slides dla .NET umożliwia ustawienie widoczności i treści tych pól zastępczych stopki na slajdzie‑mistrzu i propagowanie tych ustawień do wszystkich potomnych układów slajdu. Takie podejście zapewnia jednolite informacje stopki w całej prezentacji.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu‑mistrza po jego indeksie.
1. Ustaw wszystkie pola stopki w mistrzu i w jego dzieciach jako widoczne.
1. Ustaw wszystkie pola numeru slajdu w mistrzu i w jego dzieciach jako widoczne.
1. Ustaw wszystkie pola daty i godziny w mistrzu i w jego dzieciach jako widoczne.
1. Zapisz prezentację.

Poniższy kod C# demonstruje tę operację:

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;

    headerFooterManager.SetFooterAndChildFootersVisibility(true);
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Footer text");
    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Jaka jest różnica między slajdem master a układem slajdu?**

Slajd master definiuje ogólny motyw i domyślne formatowanie, natomiast układy slajdów określają konkretne rozmieszczenie pól zastępczych dla różnych typów treści.

**Czy mogę skopiować układ slajdu z jednej prezentacji do drugiej?**

Tak, możesz sklonować układ slajdu z kolekcji [LayoutSlides](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/layoutslides/) jednej prezentacji i wstawić go do innej za pomocą metody `AddClone`.

**Co się stanie, jeśli usunę układ slajdu, który jest nadal używany przez slajd?**

Jeśli spróbujesz usunąć układ slajdu, który jest nadal referencjonowany przynajmniej przez jeden slajd w prezentacji, Aspose.Slides zgłosi [PptxEditException](https://reference.aspose.com/slides/pl/net/aspose.slides/pptxeditexception/). Aby tego uniknąć, użyj [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/), który bezpiecznie usuwa tylko nieużywane układy slajdów.