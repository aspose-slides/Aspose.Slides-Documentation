---
title: Zastosuj lub zmień układy slajdów w systemie Android
linktitle: Układ slajdu
type: docs
weight: 60
url: /pl/androidjava/slide-layout/
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
- dwie treści
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
- Android
- Java
- Aspose.Slides
description: "Zarządzaj i dostosowuj układy slajdów w Aspose.Slides dla systemu Android. Poznaj typy układów, kontrolę pól zastępczych oraz widoczność stopki za pomocą przykładów kodu w języku Java."
---
## **Wprowadzenie**

Układ slajdu definiuje rozmieszczenie pól zastępczych i formatowanie treści na slajdzie. Kontroluje, które pola zastępcze są dostępne i gdzie się pojawiają. Układy slajdów pomagają szybko i konsekwentnie projektować prezentacje — niezależnie od tego, czy tworzysz coś prostego, czy bardziej złożonego. Niektóre z najczęściej używanych układów slajdów w programie PowerPoint to:

**Układ slajdu tytułowego** – Zawiera dwa pola tekstowe: jedno dla tytułu i jedno dla podtytułu.

**Układ tytuł i treść** – Zawiera mniejsze pole tytułu u góry oraz większe poniżej dla głównej treści (takiej jak tekst, wypunktowania, wykresy, obrazy i inne).

**Układ pusty** – Nie zawiera pól zastępczych, dając pełną kontrolę nad projektowaniem slajdu od podstaw.

Układy slajdów są częścią wzorca slajdu, który jest slajdem najwyższego poziomu definiującym style układów dla prezentacji. Możesz uzyskać dostęp i modyfikować slajdy układu za pośrednictwem wzorca slajdu — według ich typu, nazwy lub unikalnego identyfikatora. Alternatywnie możesz edytować konkretny slajd układu bezpośrednio w prezentacji.

Aby pracować z układami slajdów w Aspose.Slides dla Androida, możesz używać:
- Metody takie jak [getLayoutSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) i [getMasters](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getMasters--) w klasie [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/)
- Typy takie jak [ILayoutSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/), oraz [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Aby dowiedzieć się więcej o pracy z wzorcami slajdów, zapoznaj się z artykułem [Wzorzec slajdu](/slides/pl/androidjava/slide-master/).
{{% /alert %}}

## **Dodawanie układów slajdów do prezentacji**

Aby dostosować wygląd i strukturę swoich slajdów, możesz potrzebować dodać nowe układy slajdów do prezentacji. Aspose.Slides dla Androida umożliwia sprawdzenie, czy konkretny układ już istnieje, dodanie nowego w razie potrzeby oraz użycie go do wstawiania slajdów opartych na tym układzie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
2. Uzyskaj dostęp do [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterlayoutslidecollection/).
3. Sprawdź, czy żądany układ slajdu już istnieje w kolekcji. Jeśli nie, dodaj potrzebny układ slajdu.
4. Dodaj pusty slajd oparty na nowym układzie slajdu.
5. Zapisz prezentację.

Poniższy kod Java demonstruje, jak dodać układ slajdu do prezentacji PowerPoint:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Przejdź przez typy układów slajdów, aby wybrać układ slajdu.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // Sytuacja, w której prezentacja nie zawiera wszystkich typów układów.
        // Plik prezentacji zawiera tylko typy układów Blank i Custom.
        // Jednak układy slajdów o niestandardowych typach mogą mieć rozpoznawalne nazwy,
        // takie jak "Title", "Title and Content", itd., które można wykorzystać do wyboru układu slajdu.
        // Można także polegać na zestawie typów kształtów pól zastępczych.
        // Na przykład slajd tytułowy powinien mieć tylko typ pola zastępczego Title i tak dalej.
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName().equals("Title and Object")) {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName().equals("Title")) {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Dodaj pusty slajd przy użyciu dodanego układu slajdu.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Zapisz prezentację na dysku.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Usuwanie nieużywanych układów slajdów**

Aspose.Slides udostępnia metodę [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) z klasy [Compress](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/), umożliwiając usunięcie niechcianych i nieużywanych układów slajdów.

Poniższy kod Java pokazuje, jak usunąć układ slajdu z prezentacji PowerPoint:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dodawanie pól zastępczych do układów slajdów**

Aspose.Slides udostępnia metodę [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) , która umożliwia dodawanie nowych pól zastępczych do układu slajdu.

Ten menedżer zawiera metody dla następujących typów pól zastępczych:

| Pole zastępcze PowerPoint | Metoda |
| -------------------------- | ------------------------------------------------------------ |
| ![Zawartość](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Zawartość (pionowa)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Tekst](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Tekst (pionowy)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Obraz](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Wykres](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Tabela](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Obraz online](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Poniższy kod Java demonstruje, jak dodać nowe kształty pól zastępczych do układu pustego:

```java
Presentation presentation = new Presentation();
try {
    // Pobierz pusty układ slajdu.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Pobierz menedżera pól zastępczych układu slajdu.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Dodaj różne pola zastępcze do pustego układu slajdu.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Dodaj nowy slajd z pustym układem.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Pola zastępcze na slajdzie układu](add_placeholders.png)

## **Ustawianie widoczności stopki dla układu slajdu**

W prezentacjach PowerPoint elementy stopki, takie jak data, numer slajdu i niestandardowy tekst, mogą być wyświetlane lub ukrywane w zależności od układu slajdu. Aspose.Slides dla Androida umożliwia kontrolowanie widoczności tych pól zastępczych stopki. Jest to przydatne, gdy chcesz, aby niektóre układy wyświetlały informacje stopy, a inne pozostawały czyste i minimalistyczne.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
2. Pobierz odniesienie do układu slajdu według jego indeksu.
3. Ustaw pole zastępcze stopki slajdu jako widoczne.
4. Ustaw pole zastępcze numeru slajdu jako widoczne.
5. Ustaw pole zastępcze daty i czasu jako widoczne.
6. Zapisz prezentację.

Poniższy kod Java pokazuje, jak ustawić widoczność stopki slajdu i wykonać powiązane zadania:

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

    if (!headerFooterManager.isFooterVisible()) {
        headerFooterManager.setFooterVisibility(true);
    }

    if (!headerFooterManager.isSlideNumberVisible()) {
        headerFooterManager.setSlideNumberVisibility(true);
    }

    if (!headerFooterManager.isDateTimeVisible()) {
        headerFooterManager.setDateTimeVisibility(true);
    }

    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("Presentation.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

## **Ustawianie widoczności stopki potomków dla slajdu**

W prezentacjach PowerPoint elementy stopki, takie jak data, numer slajdu i niestandardowy tekst, mogą być kontrolowane na poziomie slajdu wzorca, aby zapewnić spójność we wszystkich układach slajdów. Aspose.Slides dla Androida umożliwia ustawienie widoczności i zawartości tych pól zastępczych stopki na slajdzie wzorca oraz propagowanie tych ustawień do wszystkich podrzędnych układów slajdów. Takie podejście zapewnia jednolite informacje stopki w całej prezentacji.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
2. Pobierz odniesienie do slajdu wzorca według jego indeksu.
3. Ustaw pola zastępcze stopki wzorca oraz wszystkich podrzędnych jako widoczne.
4. Ustaw pola zastępcze numeru slajdu wzorca oraz wszystkich podrzędnych jako widoczne.
5. Ustaw pola zastępcze daty i czasu wzorca oraz wszystkich podrzędnych jako widoczne.
6. Zapisz prezentację.

Poniższy kod Java demonstruje tę operację:

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Jaka jest różnica między slajdem wzorca a slajdem układu?**

Slajd wzorca definiuje ogólny motyw i domyślne formatowanie, natomiast slajdy układu określają konkretne rozmieszczenie pól zastępczych dla różnych typów treści.

**Czy mogę skopiować slajd układu z jednej prezentacji do drugiej?**

Tak, możesz sklonować slajd układu z kolekcji slajdów układu jednej prezentacji, dostępnej przez metodę [getLayoutSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getLayoutSlides--), i wstawić go do innej prezentacji przy użyciu metody `addClone`.

**Co się stanie, jeśli usunę układ slajdu, który jest nadal używany przez slajd?**

Jeśli spróbujesz usunąć układ slajdu, który jest nadal odwoływany przynajmniej przez jeden slajd w prezentacji, Aspose.Slides zgłosi wyjątek [PptxEditException](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pptxeditexception/). Aby tego uniknąć, użyj [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-), który bezpiecznie usuwa tylko układy slajdów nieużywane.