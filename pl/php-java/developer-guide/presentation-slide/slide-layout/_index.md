---
title: Zastosuj lub zmień układy slajdów w PHP
linktitle: Układ slajdu
type: docs
weight: 60
url: /pl/php-java/slide-layout/
keywords:
- układ slajdu
- układ zawartości
- symbol zastępczy
- projektowanie prezentacji
- projektowanie slajdu
- nieużywany układ
- widoczność stopki
- slajd tytułowy
- tytuł i zawartość
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
- PHP
- Aspose.Slides
description: "Zastosuj, twórz i modyfikuj układy slajdów w Aspose.Slides dla PHP przy użyciu Java, dodawaj placeholdery, usuwaj nieużywane układy i kontroluj widoczność stopki."
---
## **Przegląd**

Układ slajdu określa pozycje i formatowanie elementów zastępczych, takich jak tytuły, tekst, obrazy, wykresy i tabele. Zastosowanie układu nadaje slajdom spójną strukturę, jednocześnie pozwalając każdemu slajdowi zawierać własną treść.

Najczęściej używane układy obejmują:

- **Tytułowy slajd**: Zawiera placeholdery tytułu i podtytułu.
- **Tytuł i zawartość**: Zawiera placeholder tytułu oraz ogólny placeholder zawartości.
- **Pusty**: Nie zawiera placeholderów zawartości i jest przydatny, gdy każdy kształt będzie rozmieszczany ręcznie.

## **Zrozumienie dziedziczenia układów**

Prezentacja ma trzy powiązane poziomy:

1. A [master slide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslide/) definiuje motyw, wspólne formatowanie, tła i obiekty wspólne.
1. A [layout slide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslide/) należy do mastera i definiuje określony układ placeholderów.
1. A [normal slide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/) używa jednego układu i przechowuje wprowadzoną treść dla tego slajdu.

Normalny slajd dziedziczy motyw i formatowanie z układu, a układ dziedziczy z mastera. Wartość ustawiona bezpośrednio na normalnym slajdzie nadpisuje dziedziczoną wartość na tym poziomie. Gdy tworzony jest normalny slajd, jego kształty placeholderów są generowane na podstawie wybranego układu, podczas gdy wprowadzona do tych placeholderów treść należy do normalnego slajdu.

Dodaj wymagane placeholdery do układu przed tworzeniem z niego slajdów. Dodanie kolejnego placeholdera do układu później nie dodaje automatycznie odpowiadającego kształtu placeholdera do istniejących normalnych slajdów.

Ta relacja ma dwa ważne konsekwencje:

- Zmiana dziedziczonego formatowania lub istniejącej geometrii placeholderów w układzie może zaktualizować każdy slajd od niego zależny. Przed edytowaniem układu, który jest już używany, sprawdź jego zależne slajdy i przejrzyj wynikową prezentację.
- Układ, który jest nadal używany przez slajd, nie może zostać usunięty. Najpierw przypisz jego zależne slajdy do innego układu lub usuwaj tylko nieużywane układy.

Aby uzyskać więcej informacji o najwyższym poziomie tej hierarchii, zobacz [Slide Master](/slides/pl/php-java/slide-master/).

Aby ukryć dziedziczone logotypy lub dekoracyjne kształty mastera na jednym slajdzie lub poprzez współdzielony układ, zobacz [Control the Visibility of Master Graphics](/slides/pl/php-java/slide-master/). Przykład porównuje dwa slajdy korzystające z tego samego mastera.

## **Wybierz i zastosuj układ slajdu**

Używaj typu układu, gdy prezentacja korzysta ze standardowych definicji układów PowerPointa. Nazwy układów można edytować i mogą być lokalizowane, więc wybór oparty na nazwie jest mniej niezawodny, chyba że kontrolujesz szablon źródłowy.

Poniższy przykład szuka **Title and Content** na pierwszym masterze. Jeśli ten układ jest niedostępny, celowo przechodzi do **Blank**. Drugi warunek null jest potrzebny, ponieważ prezentacja może zawierać wyłącznie układy niestandardowe. Wybrany układ jest następnie zastosowany do pierwszego normalnego slajdu za pomocą metody [Slide.setLayoutSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/#setLayoutSlide).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $targetLayout = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($targetLayout)) {
        $targetLayout = $layoutSlides->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($targetLayout)) {
        throw new \RuntimeException("The first master does not contain a suitable layout slide.");
    }

    $presentation->getSlides()->get_Item(0)->setLayoutSlide($targetLayout);
    $presentation->save("output-with-new-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Zmiana układu slajdu nie usuwa zwykłych kształtów dodanych bezpośrednio do slajdu. Jednak pozycje placeholderów, dziedziczone formatowanie oraz odpowiadające sobie istniejące placeholdery i nowy układ mogą się zmienić, dlatego sprawdź wynik przy przełączaniu między znacznie różnymi układami.

## **Dodaj układ slajdu**

Wybór i tworzenie to osobne operacje. Poprzedni przykład wybiera istniejący układ; nie tworzy go. Aby utworzyć układ, wywołaj metodę [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterlayoutslidecollection/#add) na kolekcji układów docelowego mastera.

Poniższy przykład zawsze dodaje nowy **Title and Content** o nazwie `Report Title and Content`, a następnie dodaje normalny slajd oparty na nim. Nazwy układów muszą być unikalne w ramach kolekcji.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $reportLayout = $masterSlide->getLayoutSlides()->add(SlideLayoutType::TitleAndObject, "Report Title and Content");
    $presentation->getSlides()->addEmptySlide($reportLayout);

    $presentation->save("output-with-report-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Dodaj układ tylko wtedy, gdy szablon naprawdę potrzebuje kolejnej struktury wielokrotnego użytku. Jeśli odpowiedni układ już istnieje, wybierz i użyj go ponownie zamiast tworzyć duplikat.

## **Dodaj placeholdery do układu slajdu**

Metoda [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslide/#getPlaceholderManager) dostarcza [LayoutPlaceholderManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutplaceholdermanager/) do dodawania kształtów placeholderów do układu.

| Placeholder PowerPoint              | `LayoutPlaceholderManager` Method |
| ----------------------------------- | --------------------------------- |
| ![Content](content.png)             | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png)                   | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png)       | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png)             | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png)                 | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png)                 | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)                 | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png)    | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Poniższy przykład sprawdza, czy układ **Blank** istnieje, dodaje do niego cztery placeholdery, a następnie tworzy normalny slajd wykorzystujący zmodyfikowany układ. Kolejność jest zamierzona: placeholdery są dodawane przed utworzeniem normalnego slajdu, dzięki czemu Aspose.Slides może wygenerować odpowiadające im kształty placeholderów na tym slajdzie.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    if (java_is_null($blankLayout)) {
        throw new \RuntimeException("The presentation does not contain a Blank layout slide.");
    }

    $placeholderManager = $blankLayout->getPlaceholderManager();
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    $presentation->getSlides()->addEmptySlide($blankLayout);
    $presentation->save("output-with-placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Placeholdery na układzie slajdu](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Zmiana dziedziczonego formatowania lub geometrii istniejących placeholderów układu może wpływać na zależne slajdy. Nowo dodany placeholder układu nie jest automatycznie wprowadzany do istniejących normalnych slajdów. Testuj zmiany układu na kopii prezentacji i sprawdź każdy zależny slajd.
{{% /alert %}}

## **Usuń nieużywane układy slajdów**

Użyj metody [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compress/#removeUnusedLayoutSlides), aby usunąć układy, do których nie odnosi się żaden normalny slajd. Metoda pozostawia nietknięte układy, które są nadal używane.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("output-without-unused-layouts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Aby usunąć konkretny układ, najpierw użyj jego metody [hasDependingSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslide/#hasDependingSlides) lub [getDependingSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslide/#getDependingSlides). Przypisz ponownie wszystkie zależne slajdy przed wywołaniem [LayoutSlide.remove](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslide/#remove). Próba usunięcia używanego układu powoduje zgłoszenie [PptxEditException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptxeditexception/).

## **Kontroluj widoczność stopki na układzie slajdu**

Układ ma własne placeholdery stopki, numeru slajdu i daty‑czasu. Użyj metody [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslide/#getHeaderFooterManager), aby kontrolować te placeholdery dla jednego układu. Jest to przydatne, gdy np. układy zawartości powinny wyświetlać stopki, a układy tytułowe nie.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($layoutSlide)) {
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($layoutSlide)) {
        throw new \RuntimeException("The presentation does not contain a suitable layout slide.");
    }

    $headerFooterManager = $layoutSlide->getHeaderFooterManager();
    $headerFooterManager->setFooterVisibility(true);
    $headerFooterManager->setSlideNumberVisibility(true);
    $headerFooterManager->setDateTimeVisibility(true);
    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("output-with-layout-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kontroluj widoczność stopki na masterze i jego podrzędnych układach**

Aby zastosować spójne ustawienia stopki w całej hierarchii mastera, użyj metody [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslide/#getHeaderFooterManager). Metody propagacji z [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslideheaderfootermanager/) działają na masterze oraz jego zależnych układach slajdów i normalnych slajdach; nie dotyczą pojedynczego normalnego slajdu.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);
    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("output-with-master-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Jaka jest różnica między master slajdem a layout slajdem?**

Master slajd definiuje motyw prezentacji i współdzielone formatowanie. Layout slajd należy do mastera i określa jedną wielokrotnego użytku konfigurację placeholderów. Normalne slajdy używają tych układów i przechowują treść specyficzną dla slajdu.

**Czy mogę skopiować layout slajdu z jednej prezentacji do drugiej?**

Tak. Dodaj kopię do docelowej kolekcji za pomocą metody [addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/globallayoutslidecollection/#addClone). Przy kopiowaniu między prezentacjami sprawdź również czcionki, motywy, obrazy i inne zasoby używane przez źródłowy układ.

**Co się dzieje, gdy modyfikuję układ, który jest już używany?**

Zależne slajdy dziedziczą zmiany układu, chyba że lokalnie nadpisują dotknięte formatowanie lub obiekty. Geometria placeholderów i dziedziczony styl mogą więc zmienić się na wielu slajdach jednocześnie. Użyj [getDependingSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslide/#getDependingSlides), aby zidentyfikować, które slajdy są dotknięte przed edycją układu.

**Co się stanie, jeśli usunę układ, który jest nadal używany?**

Aspose.Slides zgłasza [PptxEditException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptxeditexception/). Najpierw przypisz ponownie zależne slajdy, lub użyj [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compress/#removeUnusedLayoutSlides), aby usunąć tylko nieodwoływane układy.