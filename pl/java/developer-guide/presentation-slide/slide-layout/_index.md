---
title: Zastosowanie lub zmiana układów slajdów w Javie
linktitle: Układ slajdu
type: docs
weight: 60
url: /pl/java/slide-layout/
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
- układ pusty
- treść z podpisem
- obraz z podpisem
- tytuł i pionowy tekst
- pionowy tytuł i tekst
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Zarządzaj i dostosowuj układy slajdów w Aspose.Slides dla Javy. Poznaj typy układów, sterowanie polami zastępczymi i widoczność stopki za pomocą przykładów kodu w Javie."
---
## **Wprowadzenie**

Układ slajdu definiuje rozmieszczenie pól zastępczych i formatowanie treści na slajdzie. Kontroluje, które pola są dostępne i gdzie się pojawiają. Układy slajdów pomagają szybko i konsekwentnie projektować prezentacje — niezależnie od tego, czy tworzysz coś prostego, czy bardziej złożonego. Niektóre z najczęściej używanych układów slajdów w PowerPoint to:

**Układ slajdu tytułowego** – Zawiera dwa pola tekstowe: jedno dla tytułu i jedno dla podtytułu.

**Układ tytuł i zawartość** – Zawiera mniejsze pole tytułu u góry oraz większe poniżej dla głównej treści (takiej jak tekst, wypunktowanie, wykresy, obrazy i inne).

**Układ pusty** – Nie zawiera żadnych pól zastępczych, co daje pełną kontrolę nad projektowaniem slajdu od podstaw.

Układy slajdów są częścią slajdu wzorca (slide master), który jest slajdem najwyższego poziomu definiującym style układów dla całej prezentacji. Możesz uzyskać dostęp i modyfikować układy slajdów za pośrednictwem slajdu wzorca — po typie, nazwie lub unikalnym identyfikatorze. Alternatywnie możesz edytować konkretny układ slajdu bezpośrednio w prezentacji.

Aby pracować z układami slajdów w Aspose.Slides for Java, możesz używać:

- Metody takie jak [getLayoutSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getLayoutSlides--) i [getMasters](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getMasters--) w klasie [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/)
- Typy takie jak [ILayoutSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutplaceholdermanager/), i [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Aby dowiedzieć się więcej o pracy ze slajdami wzorca, zapoznaj się z artykułem [Slide Master](/slides/pl/java/slide-master/).
{{% /alert %}}

## **Dodawanie układów slajdów do prezentacji**

Aby dostosować wygląd i strukturę swoich slajdów, możesz potrzebować dodać nowe układy slajdów do prezentacji. Aspose.Slides for Java umożliwia sprawdzenie, czy dany układ już istnieje, dodanie nowego w razie potrzeby i użycie go do wstawiania slajdów opartego na tym układzie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
1. Uzyskaj dostęp do [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterlayoutslidecollection/).
1. Sprawdź, czy żądany układ slajdu już istnieje w kolekcji. Jeśli nie, dodaj potrzebny układ slajdu.
1. Dodaj pusty slajd oparty na nowym układzie slajdu.
1. Zapisz prezentację.

Poniższy kod Java pokazuje, jak dodać układ slajdu do prezentacji PowerPoint:

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
        // Plik prezentacji zawiera tylko układy Blank i Custom.
        // Jednak układy slajdów z typami niestandardowymi mogą mieć rozpoznawalne nazwy,
        // takie jak "Title", "Title and Content" itd., które można użyć do wyboru układu slajdu.
        // Można również polegać na zestawie typów kształtów pól zastępczych.
        // Na przykład slajd Tytułowy powinien mieć tylko typ pola zastępczego Title, i tak dalej.
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

    // Zapisz prezentację na dysk.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Usuwanie nieużywanych układów slajdów**

Aspose.Slides udostępnia metodę [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) z klasy [Compress](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compress/), aby pozwolić Ci usunąć niepotrzebne i nieużywane układy slajdów.

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

Aspose.Slides udostępnia metodę [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) , która pozwala dodać nowe pola zastępcze do układu slajdu.

Ten menedżer zawiera metody dla następujących typów pól zastępczych:

| Symbol zastępczy PowerPoint | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutplaceholdermanager/) Metoda |
| --------------------------- | ------------------------------------------------------------ |
| ![Content](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Poniższy kod Java demonstruje, jak dodać nowe kształty pól zastępczych do układu pustego:

```java
Presentation presentation = new Presentation();
try {
    // Pobierz układ slajdu Blank.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Pobierz menedżera pól zastępczych układu slajdu.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Dodaj różne pola zastępcze do układu slajdu Blank.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Dodaj nowy slajd z układem Blank.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Symbole zastępcze na slajdzie układu](add_placeholders.png)

## **Ustawianie widoczności stopki dla układu slajdu**

W prezentacjach PowerPoint elementy stopki, takie jak data, numer slajdu i własny tekst, mogą być wyświetlane lub ukrywane w zależności od układu slajdu. Aspose.Slides for Java pozwala kontrolować widoczność tych pól zastępczych stopki. Jest to przydatne, gdy chcesz, aby niektóre układy wyświetlały informacje stopki, a inne pozostawały czyste i minimalistyczne.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
1. Pobierz odwołanie do układu slajdu według jego indeksu.
1. Ustaw pole zastępcze stopki slajdu jako widoczne.
1. Ustaw pole zastępcze numeru slajdu jako widoczne.
1. Ustaw pole zastępcze daty/godziny jako widoczne.
1. Zapisz prezentację.

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

## **Ustawianie widoczności stopki potomnej dla slajdu**

W prezentacjach PowerPoint elementy stopki, takie jak data, numer slajdu i własny tekst, mogą być kontrolowane na poziomie slajdu głównego, aby zapewnić spójność we wszystkich układach slajdów. Aspose.Slides for Java umożliwia ustawienie widoczności i treści tych pól zastępczych stopki na slajdzie głównym i propagowanie tych ustawień do wszystkich podrzędnych układów slajdów. To podejście zapewnia jednolitą informację stopki w całej prezentacji.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu głównego według jego indeksu.
1. Ustaw wszystkie pola zastępcze stopki w slajdzie głównym i w jego podrzędnych układach jako widoczne.
1. Ustaw wszystkie pola zastępcze numeru slajdu w slajdzie głównym i w jego podrzędnych układach jako widoczne.
1. Ustaw wszystkie pola zastępcze daty/godziny w slajdzie głównym i w jego podrzędnych układach jako widoczne.
1. Zapisz prezentację.

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

**Jaka jest różnica między slajdem głównym a slajdem układu?**

Slajd główny definiuje ogólny motyw i domyślne formatowanie, natomiast slajdy układu określają konkretne rozmieszczenie pól zastępczych dla różnych typów treści.

**Czy mogę skopiować układ slajdu z jednej prezentacji do drugiej?**

Tak, możesz sklonować układ slajdu z kolekcji układów jednej prezentacji, dostępnej za pośrednictwem metody [getLayoutSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getLayoutSlides--), i wstawić go do innej prezentacji używając metody `addClone`.

**Co się stanie, jeśli usunę układ slajdu, który jest nadal używany przez inny slajd?**

Jeśli spróbujesz usunąć układ slajdu, który jest nadal referowany przynajmniej przez jeden slajd w prezentacji, Aspose.Slides zgłosi [PptxEditException](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pptxeditexception/). Aby tego uniknąć, użyj [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-), który bezpiecznie usuwa tylko te układy slajdów, które nie są używane.