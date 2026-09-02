---
title: Zastosuj lub zmień układy slajdów w PHP
linktitle: Układ slajdu
type: docs
weight: 60
url: /pl/php-java/slide-layout/
keywords:
- układ slajdu
- układ treści
- element zastępczy
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
- PHP
- Aspose.Slides
description: "Zastosuj, twórz i modyfikuj układy slajdów w Aspose.Slides dla PHP poprzez Java, dodawaj elementy zastępcze, usuwaj nieużywane układy i kontroluj widoczność stopki."
---
## **Przegląd**

Układ slajdu definiuje pozycje i formatowanie elementów zastępczych, takich jak tytuły, tekst, obrazy, wykresy i tabele. Zastosowanie układu nadaje slajdom spójną strukturę, jednocześnie pozwalając każdemu slajdowi zawierać własną treść.

Najczęściej używane układy to:

- **Slajd tytułowy**: Zawiera elementy zastępcze tytułu i podtytułu.
- **Tytuł i zawartość**: Zawiera element zastępczy tytułu oraz ogólnego przeznaczenia element zastępczy zawartości.
- **Pusty**: Nie zawiera elementów zastępczych treści i jest przydatny, gdy każdy kształt będzie pozycjonowany ręcznie.

## **Zrozum dziedziczenie układów**

Prezentacja ma trzy powiązane poziomy:

1. A [slajd-mistrz](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslide/) definiuje motyw, współdzielone formatowanie, tła i wspólne obiekty.
1. A [układ slajdu](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslide/) należy do mistrza i definiuje konkretny układ elementów zastępczych.
1. A [normalny slajd](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/) używa jednego układu i przechowuje wprowadzone dla niego treści.

Normalny slajd dziedziczy motyw i formatowanie ze swojego układu, a układ dziedziczy od swojego mistrza. Wartość ustawiona bezpośrednio na normalnym slajdzie zastępuje dziedziczoną wartość na tym poziomie. Gdy tworzony jest normalny slajd, jego kształty zastępcze są generowane na podstawie wybranego układu, natomiast treść wprowadzona do tych elementów należy do normalnego slajdu.

Dodaj wymagane elementy zastępcze do układu przed utworzeniem z niego slajdów. Dodanie kolejnego elementu zastępczego do układu później nie spowoduje automatycznego dodania odpowiadającego kształtu zastępczego do istniejących normalnych slajdów.

Ta zależność ma dwa ważne konsekwencje:

- Zmiana dziedziczonego formatowania lub istniejącej geometrii elementu zastępczego w układzie może zaktualizować każdy slajd, który od niego zależy. Przed edycją układu już używanego, sprawdź jego zależne slajdy i przejrzyj wynikową prezentację.
- Układ, który jest nadal używany przez slajd, nie może zostać usunięty. Przypisz najpierw jego zależne slajdy do innego układu lub usuń tylko nieużywane układy.

Po więcej informacji o najwyższym poziomie tej hierarchii zobacz [Slide Master](/slides/pl/php-java/slide-master/).

## **Wybierz i zastosuj układ slajdu**

Używaj typu układu, gdy prezentacja korzysta ze standardowych definicji układów PowerPoint. Nazwy układów można edytować i lokalizować, więc wybór oparty na nazwie jest mniej niezawodny, chyba że kontrolujesz szablon źródłowy.

Poniższy przykład szuka **Tytuł i zawartość** w pierwszym mistrzu. Jeśli ten układ jest niedostępny, celowo przechodzi do **Pusty**. Drugi warunek null jest potrzebny, ponieważ prezentacja może zawierać wyłącznie własne układy. Wybrany układ jest następnie stosowany do pierwszego normalnego slajdu za pomocą metody [Slide.setLayoutSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/#setLayoutSlide).

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

Zmiana układu slajdu nie usuwa zwykłych kształtów dodanych bezpośrednio do slajdu. Jednak pozycje elementów zastępczych, dziedziczone formatowanie oraz powiązania między istniejącymi elementami a nowym układem mogą się zmienić, więc sprawdź wynik przy przełączaniu między znacznie różnymi układami.

## **Dodaj układ slajdu**

Wybór i tworzenie to odrębne operacje. Poprzedni przykład wybiera istniejący układ; nie tworzy go. Aby utworzyć układ, wywołaj metodę [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterlayoutslidecollection/#add) na kolekcji układów docelowego mistrza.

Poniższy przykład zawsze dodaje nowy układ **Tytuł i zawartość** o nazwie `Report Title and Content`, a potem dodaje normalny slajd oparty na nim. Nazwy układów muszą być unikalne w obrębie kolekcji.

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

Dodawaj układ tylko wtedy, gdy szablon naprawdę potrzebuje kolejnej wielokrotnego użycia struktury. Jeśli odpowiedni układ już istnieje, wybierz i użyj go ponownie zamiast tworzyć duplikat.

## **Dodaj elementy zastępcze do układu slajdu**

Metoda [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslide/#getPlaceholderManager) udostępnia [LayoutPlaceholderManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutplaceholdermanager/) do dodawania kształtów zastępczych do układu.

| Element zastępczy PowerPoint | Metoda `LayoutPlaceholderManager` |
| ---------------------------- | --------------------------------- |
| ![Zawartość](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Zawartość (pionowa)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Tekst](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Tekst (pionowy)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Obraz](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Wykres](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabela](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Obraz online](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Poniższy przykład weryfikuje, czy układ **Pusty** istnieje, dodaje do niego cztery elementy zastępcze, a następnie tworzy normalny slajd korzystający z zmodyfikowanego układu. Kolejność jest zamierzona: elementy zastępcze są dodawane przed utworzeniem normalnego slajdu, aby Aspose.Slides mógł wygenerować odpowiadające kształty zastępcze na tym slajdzie.

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

![Elementy zastępcze na slajdzie układu](add_placeholders.png)

{{% alert color="warning" title="Ostrzeżenie" %}}
Zmiana dziedziczonego formatowania lub geometrii istniejących elementów zastępczych w układzie może wpływać na zależne slajdy. Nowo dodany element zastępczy nie jest automatycznie wstawiany do istniejących normalnych slajdów. Testuj zmiany układu na kopii prezentacji i sprawdzaj każdy zależny slajd.
{{% /alert %}}

## **Usuń nieużywane układy slajdów**

Użyj metody [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compress/#removeUnusedLayoutSlides), aby usunąć układy, do których nie odnosi się żaden normalny slajd. Metoda pozostawia nienaruszone układy nadal używane.

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

Aby usunąć konkretny układ, najpierw użyj jego metody [hasDependingSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslide/#hasDependingSlides) lub [getDependingSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslide/#getDependingSlides). Przypisz wszystkie zależne slajdy przed wywołaniem [LayoutSlide.remove](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslide/#remove). Próba usunięcia używanego układu powoduje zgłoszenie [PptxEditException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptxeditexception/).

## **Kontroluj widoczność stopki w układzie slajdu**

Układ ma własne elementy zastępcze stopki, numeru slajdu i daty/czasu. Użyj metody [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslide/#getHeaderFooterManager), aby sterować tymi elementami w jednym układzie. Jest to przydatne, gdy na przykład układy zawartości mają wyświetlać stopki, a układy tytułów nie.

Poniższy przykład wybiera układ w bezpieczny sposób i ustawia jego elementy stopki jako widoczne:

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

## **Kontroluj widoczność stopki w slajdzie-mistrzu i jego układach podrzędnych**

Aby zastosować spójne ustawienia stopki w całej hierarchii mistrza, użyj metody [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslide/#getHeaderFooterManager). Metody propagacji [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslideheaderfootermanager/) działają na mistrzu oraz jego zależnych układach i normalnych slajdach; nie są skierowane wyłącznie do jednego normalnego slajdu.

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

**Jaka jest różnica między slajdem‑mistrzem a układem slajdu?**

Slajd‑mistrz definiuje motyw prezentacji i współdzielone formatowanie. Układ slajdu należy do mistrza i definiuje jedną wielokrotnego użycia konfigurację elementów zastępczych. Normalne slajdy używają tych układów i przechowują treści specyficzne dla slajdu.

**Czy mogę skopiować układ slajdu z jednej prezentacji do drugiej?**

Tak. Dodaj kopię do docelowej kolekcji za pomocą metody [addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/globallayoutslidecollection/#addClone). Przy kopiowaniu między prezentacjami sprawdź również czcionki, motywy, obrazy i inne zasoby używane przez źródłowy układ.

**Co się stanie, gdy zmodyfikuję układ już używany?**

Zależne slajdy dziedziczą zmiany układu, chyba że nadpiszą dotknięte formatowanie lub obiekty lokalnie. Geometria elementów zastępczych i dziedziczone style mogą więc zmienić się jednocześnie na wielu slajdach. Użyj [getDependingSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslide/#getDependingSlides), aby zidentyfikować dotknięte slajdy przed edycją układu.

**Co się stanie, jeśli usunę układ, który jest nadal używany?**

Aspose.Slides zgłosi [PptxEditException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptxeditexception/). Najpierw przypisz zależne slajdy do innego układu lub użyj [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compress/#removeUnusedLayoutSlides), aby usunąć tylko niepowiązane układy.