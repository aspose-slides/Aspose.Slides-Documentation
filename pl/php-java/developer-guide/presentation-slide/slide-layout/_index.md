---
title: Zastosuj lub zmień układy slajdów w PHP
linktitle: Układ slajdu
type: docs
weight: 60
url: /pl/php-java/slide-layout/
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
- PHP
- Aspose.Slides
description: "Zarządzaj i dostosowuj układy slajdów w Aspose.Slides dla PHP przy użyciu Javy. Poznaj typy układów, kontrolę pól zastępczych oraz widoczność stopki na przykładach kodu."
---
## **Wprowadzenie**

Układ slajdu definiuje rozmieszczenie pól zastępczych i formatowanie treści na slajdzie. Kontroluje, które pola zastępcze są dostępne i gdzie się pojawiają. Układy slajdów pomagają szybko i konsekwentnie projektować prezentacje — niezależnie od tego, czy tworzysz coś prostego, czy bardziej złożonego. Do najczęściej używanych układów slajdów w programie PowerPoint należą:

**Układ slajdu tytułowego** – Zawiera dwa pola tekstowe: jedno dla tytułu i jedno dla podtytułu.

**Układ tytuł i treść** – Zawiera mniejsze pole tytułu u góry oraz większe poniżej, przeznaczone na główną treść (taką jak tekst, wypunktowania, wykresy, obrazy i inne).

**Układ pusty** – Nie zawiera pól zastępczych, dając pełną kontrolę nad projektowaniem slajdu od podstaw.

Układy slajdów są częścią mastera slajdów, który jest slajdem najwyższego poziomu definiującym style układów dla prezentacji. Możesz uzyskać dostęp i modyfikować układy slajdów za pośrednictwem mastera slajdów — zarówno według typu, nazwy, jak i unikalnego identyfikatora. Alternatywnie możesz edytować konkretny układ slajdu bezpośrednio w prezentacji.

Aby pracować z układami slajdów w Aspose.Slides for PHP, możesz używać:

- Metody takie jak [getLayoutSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getLayoutSlides) i [getMasters](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getMasters) w klasie [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/)
- Typy takie jak [LayoutSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutplaceholdermanager/), oraz [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Aby dowiedzieć się więcej o pracy z masterami slajdów, zapoznaj się z artykułem [Slide Master](/slides/pl/php-java/slide-master/).
{{% /alert %}}

## **Dodawanie układów slajdów do prezentacji**

Aby dostosować wygląd i strukturę swoich slajdów, możesz potrzebować dodać nowe układy slajdów do prezentacji. Aspose.Slides for PHP umożliwia sprawdzenie, czy dany układ już istnieje, dodanie nowego w razie potrzeby oraz użycie go do wstawiania slajdów opartych na tym układzie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
1. Uzyskaj dostęp do [MasterLayoutSlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterlayoutslidecollection/).
1. Sprawdź, czy żądany układ slajdu już istnieje w kolekcji. Jeśli nie, dodaj potrzebny układ slajdu.
1. Dodaj pusty slajd oparty na nowym układzie slajdu.
1. Zapisz prezentację.

Poniższy kod PHP pokazuje, jak dodać układ slajdu do prezentacji PowerPoint:

```php
// Utwórz instancję klasy Presentation reprezentującej plik PowerPoint.
$presentation = new Presentation("Sample.pptx");
try {
    // Przejdź przez typy układów slajdów, aby wybrać układ slajdu.
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }

    if (java_is_null($layoutSlide)) {
        // Sytuacja, w której prezentacja nie zawiera wszystkich typów układów.
        // Plik prezentacji zawiera tylko typy układów Blank i Custom.
        // Jednak układy slajdów z typami niestandardowymi mogą mieć rozpoznawalne nazwy,
        // takie jak "Title", "Title and Content", itp., które można wykorzystać do wyboru układu slajdu.
        // Można również opierać się na zestawie typów kształtów pól zastępczych.
        // Na przykład slajd tytułowy powinien mieć tylko typ pola zastępczego Title, i tak dalej.
        foreach($layoutSlides as $titleAndObjectLayoutSlide) {
            if (java_values($titleAndObjectLayoutSlide->getName()) == "Title and Object") {
                $layoutSlide = $titleAndObjectLayoutSlide;
                break;
            }
        }

        if (java_is_null($layoutSlide)) {
            foreach($layoutSlides as $titleLayoutSlide) {
                if (java_values($titleLayoutSlide->getName()) == "Title") {
                    $layoutSlide = $titleLayoutSlide;
                    break;
                }
            }

            if (java_is_null($layoutSlide)) {
                $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Blank);
                if (java_is_null($layoutSlide)) {
                    $layoutSlide = $layoutSlides->add(SlideLayoutType::TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Dodaj pusty slajd używając dodanego układu slajdu.
    $presentation->getSlides()->insertEmptySlide(0, $layoutSlide);

    // Zapisz prezentację na dysku.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Usuwanie nieużywanych układów slajdów**

Aspose.Slides udostępnia metodę [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) z klasy [Compress](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compress/), pozwalającą usunąć niechciane i nieużywane układy slajdów.

Poniższy kod PHP pokazuje, jak usunąć układ slajdu z prezentacji PowerPoint:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Dodawanie pól zastępczych do układów slajdów**

Aspose.Slides udostępnia metodę [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslide/#getPlaceholderManager), która umożliwia dodawanie nowych pól zastępczych do układu slajdu.

Menedżer ten zawiera metody dla następujących typów pól zastępczych:

| Pole zastępcze PowerPoint | [LayoutPlaceholderManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutplaceholdermanager/) Method |
| -------------------------- | ------------------------------------------------------------ |
| ![Treść](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Treść (pionowa)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Tekst](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Tekst (pionowy)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Obraz](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Wykres](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Tabela](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Obraz online](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Poniższy kod PHP demonstruje, jak dodać nowe kształty pól zastępczych do układu pustego slajdu:

```php
$presentation = new Presentation();
try {
    // Pobierz układ slajdu Blank.
    $layout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Pobierz menedżera pól zastępczych układu slajdu.
    $placeholderManager = $layout->getPlaceholderManager();

    // Dodaj różne pola zastępcze do układu slajdu Blank.
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    // Dodaj nowy slajd z układem Blank.
    $newSlide = $presentation->getSlides()->addEmptySlide($layout);

    $presentation->save("Placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Pola zastępcze na układzie slajdu](add_placeholders.png)

## **Ustawianie widoczności stopki dla układu slajdu**

W prezentacjach PowerPoint elementy stopki, takie jak data, numer slajdu i własny tekst, mogą być wyświetlane lub ukrywane w zależności od układu slajdu. Aspose.Slides for PHP umożliwia kontrolowanie widoczności tych pól zastępczych stopki. Jest to przydatne, gdy chcesz, aby niektóre układy wyświetlały informacje stopki, a inne pozostawały czyste i minimalistyczne.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
1. Pobierz odniesienie do układu slajdu za pomocą jego indeksu.
1. Ustaw pole zastępcze stopki slajdu jako widoczne.
1. Ustaw pole zastępcze numeru slajdu jako widoczne.
1. Ustaw pole zastępcze daty i czasu jako widoczne.
1. Zapisz prezentację.

Poniższy kod PHP pokazuje, jak ustawić widoczność stopki slajdu i wykonać powiązane zadania:

```php
$presentation = new Presentation("Presentation.ppt");
try {
    $headerFooterManager = $presentation->getLayoutSlides()->get_Item(0)->getHeaderFooterManager();

    if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
    }

    if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
    }

    if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
    }

    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("Presentation.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

## **Ustawianie widoczności stopki potomka dla slajdu**

W prezentacjach PowerPoint elementy stopki, takie jak data, numer slajdu i własny tekst, mogą być kontrolowane na poziomie mastera slajdów, aby zapewnić spójność we wszystkich układach slajdów. Aspose.Slides for PHP umożliwia ustawienie widoczności i zawartości tych pól zastępczych stopki na masterze oraz propagowanie tych ustawień do wszystkich potomnych układów slajdów. Takie podejście zapewnia jednolitą informację stopki w całej prezentacji.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
1. Pobierz odniesienie do mastera slajdu za pomocą jego indeksu.
1. Ustaw pola zastępcze stopki mastera i wszystkich potomnych jako widoczne.
1. Ustaw pola zastępcze numeru slajdu mastera i wszystkich potomnych jako widoczne.
1. Ustaw pola zastępcze daty i czasu mastera i wszystkich potomnych jako widoczne.
1. Zapisz prezentację.

Poniższy kod PHP demonstruje tę operację:

```php
$presentation = new Presentation("presentation.ppt");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();

    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Jaka jest różnica między masterem slajdu a układem slajdu?**

Master slajdu definiuje ogólny motyw i domyślne formatowanie, natomiast układy slajdów określają konkretne rozmieszczenie pól zastępczych dla różnych typów treści.

**Czy mogę skopiować układ slajdu z jednej prezentacji do drugiej?**

Tak, możesz sklonować układ slajdu z kolekcji układów slajdów jednej prezentacji, dostępnej przez metodę [getLayoutSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getLayoutSlides), i wstawić go do innej prezentacji za pomocą metody `addClone`.

**Co się stanie, jeśli usunę układ slajdu, który jest nadal używany przez slajd?**

Jeśli spróbujesz usunąć układ slajdu, który jest nadal odwoływany przynajmniej przez jeden slajd w prezentacji, Aspose.Slides zgłosi wyjątek [PptxEditException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptxeditexception/). Aby tego uniknąć, użyj [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compress/#removeUnusedLayoutSlides), który bezpiecznie usuwa tylko nieużywane układy slajdów.