---
title: Zastosowanie lub zmiana układów slajdów w JavaScript
linktitle: Układ slajdu
type: docs
weight: 60
url: /pl/nodejs-java/slide-layout/
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
- dwie zawartości
- porównanie
- tylko tytuł
- pusty układ
- zawartość z podpisem
- obraz z podpisem
- tytuł i pionowy tekst
- pionowy tytuł i tekst
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Zarządzaj i dostosowuj układy slajdów w Aspose.Slides dla Node.js. Poznaj typy układów, kontrolę pól zastępczych oraz widoczność stopki na przykładach kodu."
---
## **Wprowadzenie**

Układ slajdu określa rozmieszczenie pól zastępczych i formatowanie treści na slajdzie. Kontroluje, które pola zastępcze są dostępne i gdzie się pojawiają. Układy slajdów pomagają szybko i konsekwentnie projektować prezentacje — niezależnie od tego, czy tworzysz coś prostego, czy bardziej złożonego. Niektóre z najczęściej używanych układów slajdów w programie PowerPoint to:

**Układ slajdu tytułowego** – Zawiera dwa pola tekstowe: jedno dla tytułu i drugie dla podtytułu.

**Układ tytuł i zawartość** – Zawiera mniejsze pole tytułowe u góry oraz większe poniżej dla głównej treści (takiej jak tekst, listy punktowane, wykresy, obrazy i inne).

**Układ pusty** – Nie zawiera pól zastępczych, dając pełną kontrolę nad projektowaniem slajdu od podstaw.

Układy slajdów są częścią mistrza slajdów, który jest slajdem najwyższego poziomu definiującym style układów dla prezentacji. Możesz uzyskać dostęp i modyfikować układy slajdów poprzez mistrza slajdów — zarówno według ich typu, nazwy, jak i unikalnego identyfikatora. Alternatywnie możesz edytować konkretny układ slajdu bezpośrednio w prezentacji.

Aby pracować z układami slajdów w Aspose.Slides for Node.js, możesz użyć:

- Metody, takie jak [getLayoutSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getLayoutSlides) i [getMasters](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getMasters) w klasie [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/)
- Typy, takie jak [LayoutSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutplaceholdermanager/) i [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Aby dowiedzieć się więcej o pracy z mistrzami slajdów, zobacz artykuł [Slide Master](/slides/pl/nodejs-java/slide-master/).
{{% /alert %}}

## **Dodawanie układów slajdów do prezentacji**

Aby dostosować wygląd i strukturę swoich slajdów, możesz potrzebować dodać nowe układy slajdów do prezentacji. Aspose.Slides for Node.js umożliwia sprawdzenie, czy określony układ już istnieje, dodanie nowego w razie potrzeby i użycie go do wstawiania slajdów opartych na tym układzie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Uzyskaj dostęp do [MasterLayoutSlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterlayoutslidecollection/).
1. Sprawdź, czy żądany układ slajdu już istnieje w kolekcji. Jeśli nie, dodaj potrzebny układ slajdu.
1. Dodaj pusty slajd oparty na nowym układzie slajdu.
1. Zapisz prezentację.

```js
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Przejdź przez typy układów slajdów, aby wybrać układ slajdu.
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let layoutSlide = null;
    if (layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject)) != null) {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    } else {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Title));
    }

    if (layoutSlide == null) {
        // Sytuacja, w której prezentacja nie zawiera wszystkich typów układów.
        // Plik prezentacji zawiera tylko układy typu Blank i Custom.
        // Jednak układy slajdów o typach niestandardowych mogą mieć rozpoznawalne nazwy,
        // takie jak "Title", "Title and Content", etc., które mogą być użyte do wyboru układu slajdu.
        // Możesz także polegać na zestawie typów kształtów pól zastępczych.
        // Na przykład slajd Title powinien mieć tylko typ pola zastępczego Title, i tak dalej.
        for (let i = 0; i < layoutSlides.size(); i++) {
            let titleAndObjectLayoutSlide = layoutSlides.get_Item(i);
            if (titleAndObjectLayoutSlide.getName() === "Title and Object") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (let i = 0; i < layoutSlides.size(); i++) {
                let titleLayoutSlide = layoutSlides.get_Item(i);
                if (titleLayoutSlide.getName() === "Title") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject), "Title and Object");
                }
            }
        }
    }

    // Dodaj pusty slajd, używając dodanego układu slajdu.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Zapisz prezentację na dysku.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Usuwanie nieużywanych układów slajdów**

Aspose.Slides udostępnia metodę [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) z klasy [Compress](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/compress/), aby umożliwić usunięcie niechcianych i nieużywanych układów slajdów.

Poniższy kod JavaScript pokazuje, jak usunąć układ slajdu z prezentacji PowerPoint:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dodawanie pól zastępczych do układów slajdów**

Aspose.Slides udostępnia metodę [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager), która pozwala dodawać nowe pola zastępcze do układu slajdu.

Ten menedżer zawiera metody dla następujących typów pól zastępczych:

| Zastępnik PowerPoint | [LayoutPlaceholderManager] Metoda |
| -------------------- | --------------------------------- |
| ![Zawartość](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Zawartość (Pionowa)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Tekst](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Tekst (Pionowy)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Obraz](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Wykres](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Tabela](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Obraz online](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Poniższy kod JavaScript demonstruje, jak dodać nowe kształty pól zastępczych do układu pustego:

```js
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz układ slajdu typu Blank.
    let layout = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));

    // Pobierz menedżera pól zastępczych układu slajdu.
    let placeholderManager = layout.getPlaceholderManager();

    // Dodaj różne pola zastępcze do układu Blank.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Dodaj nowy slajd z układem Blank.
    let newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Pola zastępcze na slajdzie układu](add_placeholders.png)

## **Ustaw widoczność stopki dla układu slajdu**

W prezentacjach PowerPoint elementy stopki, takie jak data, numer slajdu i tekst niestandardowy, mogą być wyświetlane lub ukrywane w zależności od układu slajdu. Aspose.Slides for Node.js pozwala kontrolować widoczność tych pól zastępczych stopki. Jest to przydatne, gdy chcesz, aby niektóre układy wyświetlały informacje stopki, a inne pozostawały czyste i minimalistyczne.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Uzyskaj referencję do układu slajdu według jego indeksu.
1. Ustaw pole zastępcze stopki slajdu jako widoczne.
1. Ustaw pole zastępcze numeru slajdu jako widoczne.
1. Ustaw pole zastępcze daty i czasu jako widoczne.
1. Zapisz prezentację.

```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

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

    presentation.save("Presentation.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

## **Ustaw widoczność stopki potomnej dla slajdu**

W prezentacjach PowerPoint elementy stopki, takie jak data, numer slajdu i tekst niestandardowy, mogą być kontrolowane na poziomie slajdu mistrza, aby zapewnić spójność we wszystkich układach slajdów. Aspose.Slides for Node.js umożliwia ustawienie widoczności i treści tych pól zastępczych stopki na slajdzie mistrza i propagowanie tych ustawień do wszystkich podrzędnych układów slajdów. To podejście zapewnia jednolitą informację o stopce w całej prezentacji.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu mistrza według jego indeksu.
1. Ustaw pola zastępcze stopki mistrza oraz wszystkich podrzędnych jako widoczne.
1. Ustaw pola zastępcze numeru slajdu mistrza oraz wszystkich podrzędnych jako widoczne.
1. Ustaw pola zastępcze daty i czasu mistrza oraz wszystkich podrzędnych jako widoczne.
1. Zapisz prezentację.

```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Jaka jest różnica między slajdem mistrza a układem slajdu?**

Slajd mistrza określa ogólny motyw i domyślne formatowanie, podczas gdy układy slajdów definiują konkretne rozmieszczenie pól zastępczych dla różnych rodzajów treści.

**Czy mogę skopiować układ slajdu z jednej prezentacji do drugiej?**

Tak, możesz sklonować układ slajdu z kolekcji układów slajdów jednej prezentacji, dostępnej za pomocą metody [getLayoutSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getLayoutSlides), i wstawić go do innej prezentacji używając metody `addClone`.

**Co się stanie, jeśli usunę układ slajdu, który jest nadal używany przez slajd?**

Jeśli spróbujesz usunąć układ slajdu, który jest nadal odwoływany przynajmniej przez jeden slajd w prezentacji, Aspose.Slides rzuci wyjątek [PptxEditException](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pptxeditexception/). Aby tego uniknąć, użyj [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides), który bezpiecznie usuwa tylko układy slajdów nieużywane.