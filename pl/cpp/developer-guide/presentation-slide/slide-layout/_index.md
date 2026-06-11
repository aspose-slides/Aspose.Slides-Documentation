---
title: Zastosuj lub zmień układy slajdów w C++
linktitle: Układ slajdu
type: docs
weight: 60
url: /pl/cpp/slide-layout/
keywords:
- układ slajdu
- układ treści
- pole zastępcze
- projektowanie prezentacji
- projektowanie slajdu
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
- C++
- Aspose.Slides
description: "Zarządzaj i dostosowuj układy slajdów w Aspose.Slides dla C++. Poznaj typy układów, kontrolę pól zastępczych i widoczność stopki poprzez przykłady kodu C++."
---
## **Wprowadzenie**

Układ slajdu określa rozmieszczenie pól zastępczych i formatowanie treści na slajdzie. Kontroluje, które pola zastępcze są dostępne i gdzie się pojawiają. Układy slajdów pomagają szybko i konsekwentnie projektować prezentacje — niezależnie od tego, czy tworzysz coś prostego, czy bardziej złożonego. Niektóre z najczęściej używanych układów slajdów w programie PowerPoint to:

**Układ slajdu tytułowego** – Zawiera dwa pola tekstowe: jedno dla tytułu i drugie dla podtytułu.

**Układ tytuł i treść** – Zawiera mniejsze pole tytułu u góry oraz większe poniżej przeznaczone na główną treść (taką jak tekst, wypunktowania, wykresy, obrazy i inne).

**Układ pusty** – Nie zawiera żadnych pól zastępczych, co daje pełną kontrolę nad projektowaniem slajdu od podstaw.

Układy slajdów są częścią głównego slajdu (slide master), który jest slajdem najwyższego poziomu definiującym style układów w prezentacji. Możesz uzyskać dostęp i modyfikować układy slajdów poprzez główny slajd — korzystając z ich typu, nazwy lub unikalnego identyfikatora. Alternatywnie możesz edytować konkretny układ slajdu bezpośrednio w prezentacji.

Do pracy z układami slajdów w Aspose.Slides dla Androida możesz używać:
- Metody takie jak [get_LayoutSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_layoutslides/) i [get_Masters](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_masters/) w klasie [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
- Typy takie jak [ILayoutSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutplaceholdermanager/), oraz [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Aby dowiedzieć się więcej o pracy z głównymi slajdami, zapoznaj się z artykułem [Slide Master](/slides/pl/cpp/slide-master/).
{{% /alert %}}

## **Dodawanie układów slajdów do prezentacji**

Aby dostosować wygląd i strukturę swoich slajdów, możesz potrzebować dodać nowe układy slajdów do prezentacji. Aspose.Slides dla Androida umożliwia sprawdzenie, czy określony układ już istnieje, dodanie nowego w razie potrzeby oraz użycie go do wstawiania slajdów opartego na tym układzie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Uzyskaj dostęp do [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterlayoutslidecollection/).
1. Sprawdź, czy żądany układ slajdu już istnieje w kolekcji. Jeśli nie, dodaj potrzebny układ slajdu.
1. Dodaj pusty slajd oparty na nowym układzie slajdu.
1. Zapisz prezentację.
1. Zapisz prezentację.

Przykładowy kod C++ pokazuje, jak dodać układ slajdu do prezentacji PowerPoint:

```cpp
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Go through the layout slide types to select a layout slide.
auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
SharedPtr<ILayoutSlide> layoutSlide;
if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
}
else if (layoutSlides->GetByType(SlideLayoutType::Title) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
}

if (layoutSlide == nullptr)
{
    // Sytuacja, w której prezentacja nie zawiera wszystkich typów układów.
    // Plik prezentacji zawiera tylko typy układów Blank i Custom.
    // Jednak układy slajdów o typach niestandardowych mogą mieć rozpoznawalne nazwy,
    // takie jak "Title", "Title and Content" itp., które mogą być użyte do wyboru układu slajdu.
    // Możesz także polegać na zestawie typów kształtów pól zastępczych.
    // Na przykład slajd tytułowy powinien mieć tylko typ pola zastępczego Title i podobnie.
    for (int i = 0; i < layoutSlides->get_Count(); i++)
    {
        auto titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

        if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
        {
            layoutSlide = titleAndObjectLayoutSlide;
            break;
        }
    }

    if (layoutSlide == nullptr)
    {
        for (int i = 0; i < layoutSlides->get_Count(); i++)
        {
            auto titleLayoutSlide = layoutSlides->idx_get(i);

            if (titleLayoutSlide->get_Name() == u"Title")
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
        }

        if (layoutSlide == nullptr)
        {
            layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
            if (layoutSlide == nullptr)
            {
                layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
            }
        }
    }
}

// Dodaj pusty slajd przy użyciu dodanego układu slajdu.
presentation->get_Slides()->InsertEmptySlide(0, layoutSlide);

// Zapisz prezentację na dysku.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Usuwanie nieużywanych układów slajdów**

Aspose.Slides udostępnia metodę [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) z klasy [Compress](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/), umożliwiając usunięcie niechcianych i nieużywanych układów slajdów.

Przykładowy kod C++ pokazuje, jak usunąć układ slajdu z prezentacji PowerPoint:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Dodawanie pól zastępczych do układów slajdów**

Aspose.Slides udostępnia metodę [ILayoutSlide.get_PlaceholderManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/), która pozwala dodawać nowe pola zastępcze do układu slajdu.

Ten menedżer zawiera metody dla następujących typów pól zastępczych:

| PowerPoint Placeholder | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutplaceholdermanager/) Metoda |
| ---------------------- | ------------------------------------------------------------ |
| ![Zawartość](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Zawartość (pionowa)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Tekst](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Tekst (pionowy)](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Obraz](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Wykres](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Tabela](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Obraz online](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

Przykładowy kod C++ pokazuje, jak dodać nowe kształty pól zastępczych do układu pustego:

```cpp
auto presentation = MakeObject<Presentation>();

// Pobierz układ slajdu Blank.
auto layout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Pobierz menedżera pól zastępczych układu slajdu.
auto placeholderManager = layout->get_PlaceholderManager();

// Dodaj różne pola zastępcze do układu slajdu Blank.
placeholderManager->AddContentPlaceholder(20, 20, 310, 270);
placeholderManager->AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager->AddChartPlaceholder(20, 310, 310, 180);
placeholderManager->AddTablePlaceholder(350, 310, 350, 180);

// Dodaj nowy slajd z układem Blank.
auto newSlide = presentation->get_Slides()->AddEmptySlide(layout);

presentation->Save(u"Placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![Pola zastępcze na układzie slajdu](add_placeholders.png)

## **Ustawienie widoczności stopki dla układu slajdu**

W prezentacjach PowerPoint elementy stopki, takie jak data, numer slajdu i własny tekst, mogą być wyświetlane lub ukrywane w zależności od układu slajdu. Aspose.Slides dla Androida umożliwia kontrolowanie widoczności tych pól zastępczych stopki. Jest to przydatne, gdy chcesz, aby niektóre układy wyświetlały informacje o stopce, a inne pozostawały czyste i minimalistyczne.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz odniesienie do układu slajdu według jego indeksu.
1. Ustaw pole zastępcze stopki slajdu jako widoczne.
1. Ustaw pole zastępcze numeru slajdu jako widoczne.
1. Ustaw pole zastępcze daty i czasu jako widoczne.
1. Zapisz prezentację.

Przykładowy kod C++ pokazuje, jak ustawić widoczność stopki slajdu i wykonać powiązane zadania:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.ppt");
auto headerFooterManager = presentation->get_LayoutSlides()->idx_get(0)->get_HeaderFooterManager();

if (!headerFooterManager->get_IsFooterVisible())
{
    headerFooterManager->SetFooterVisibility(true);
}

if (!headerFooterManager->get_IsSlideNumberVisible())
{
    headerFooterManager->SetSlideNumberVisibility(true);
}

if (!headerFooterManager->get_IsDateTimeVisible())
{
    headerFooterManager->SetDateTimeVisibility(true);
}

headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"Presentation.ppt", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ustawienie widoczności stopki dziecka dla slajdu**

W prezentacjach PowerPoint elementy stopki, takie jak data, numer slajdu i własny tekst, mogą być kontrolowane na poziomie głównego slajdu, aby zapewnić spójność we wszystkich układach slajdów. Aspose.Slides dla Androida umożliwia ustawienie widoczności i treści tych pól zastępczych stopki na głównym slajdzie oraz propagowanie tych ustawień do wszystkich układów podrzędnych. To podejście zapewnia jednolitą informację o stopce w całej prezentacji.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz odniesienie do głównego slajdu według jego indeksu.
1. Ustaw pola zastępcze stopki głównego slajdu oraz wszystkich podrzędnych jako widoczne.
1. Ustaw pola zastępcze numeru slajdu głównego oraz wszystkich podrzędnych jako widoczne.
1. Ustaw pola zastępcze daty i czasu głównego oraz wszystkich podrzędnych jako widoczne.
1. Zapisz prezentację.

Przykładowy kod C++ demonstruje tę operację:

```cpp
auto presentation = MakeObject<Presentation>();

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();

headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Jaka jest różnica między głównym slajdem a układem slajdu?**

Główny slajd definiuje ogólny motyw i domyślne formatowanie, natomiast układy slajdów określają konkretne rozmieszczenie pól zastępczych dla różnych typów treści.

**Czy mogę skopiować układ slajdu z jednej prezentacji do drugiej?**

Tak, możesz sklonować układ slajdu z kolekcji układów slajdów jednej prezentacji, dostępnej za pomocą metody [get_LayoutSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_layoutslides/), i wstawić go do innej prezentacji, używając metody `AddClone`.

**Co się stanie, jeśli usunę układ slajdu, który jest nadal używany przez slajd?**

Jeśli spróbujesz usunąć układ slajdu, który jest nadal odwoływany przez co najmniej jeden slajd w prezentacji, Aspose.Slides zgłosi wyjątek [PptxEditException](https://reference.aspose.com/slides/pl/cpp/aspose.slides/pptxeditexception/). Aby temu zapobiec, użyj [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/), który bezpiecznie usuwa tylko nieużywane układy slajdów.