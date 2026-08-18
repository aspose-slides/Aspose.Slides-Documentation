---
title: Zarządzanie nagłówkami i stopkami prezentacji w PHP
linktitle: Nagłówek i stopka
type: docs
weight: 140
url: /pl/php-java/presentation-header-and-footer/
keywords:
- nagłówek
- tekst nagłówka
- stopka
- tekst stopki
- ustaw nagłówek
- ustaw stopkę
- materiał pomocniczy
- notatki
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak zarządzać polami zastępczymi stopki, daty i godziny, numeru slajdu oraz nagłówka na slajdach, stronach notatek i materiałach pomocniczych przy użyciu Aspose.Slides dla PHP przez Java."
---
## **Przegląd**

PowerPoint używa różnych pól zastępczych nagłówka i stopki w zależności od typu strony. Aspose.Slides for PHP via Java umożliwia kontrolowanie tekstu i widoczności tych pól za pomocą klas menedżera nagłówka/stopki.

Dostępne pola zastępcze zależą od zakresu:

| Zakres | Nagłówek | Stopka | Data/godzina | Numer slajdu/strony |
|---|---|---|---|---|
| Zwykły slajd | Nie | Tak | Tak | Tak |
| Notatki główne | Tak | Tak | Tak | Tak |
| Notatka slajdu | Tak | Tak | Tak | Tak |
| Materiał pomocniczy główny | Tak | Tak | Tak | Tak |

Zwykły slajd prezentacji nie ma pola zastępczego nagłówka. Nagłówki są dostępne na stronach notatek i materiałach pomocniczych. Dla zwykłych slajdów użyj pól zastępczych stopki, daty/godziny i numeru slajdu.

Zakres zmiany zależy od używanego menedżera. Klasa [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideheaderfootermanager/) steruje jednym zwykłym slajdem. Klasa [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/notesslideheaderfootermanager/) steruje jedną notatką slajdu. Menedżerowie master i układu mogą również propagować ustawienia do zależnych slajdów, podczas gdy klasa [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) steruje materiałem pomocniczym głównym.

## **Ustaw stopkę, datę/godzinę i numery slajdów na zwykłych slajdach**

Dla zwykłych slajdów podstawowy przepływ pracy polega na uzyskaniu menedżera nagłówka/stopki każdego slajdu, ustawieniu tekstu stopki i daty/godziny, włączeniu wymaganych pól zastępczych i zapisaniu prezentacji. Numery slajdów generuje prezentacja, więc wystarczy kontrolować ich widoczność.

Użyj [`setFooterText`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseslideheaderfootermanager/setfootertext/) i [`setDateTimeText`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) do ustawiania tekstu oraz [`setFooterVisibility`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`setDateTimeVisibility`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) i [`setSlideNumberVisibility`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) aby wyświetlić odpowiednie pola zastępcze.

Poniższy przykład end‑to‑end stosuje tę samą stopkę, tekst daty/godziny i widoczność numeru slajdu we wszystkich zwykłych slajdach:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getSlides() as $slide) {
        $headerFooterManager = $slide->getHeaderFooterManager();

        $headerFooterManager->setFooterText("Company Confidential");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_slide_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Jeśli potrzebujesz zaktualizować tylko jeden slajd, uzyskaj ten slajd bezpośrednio przez metodę [`getSlides`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/getslides/) zamiast iterować po całej kolekcji.

## **Ustaw nagłówki i stopki w notatkach głównych**

Notatki główne definiują wspólne formatowanie i zachowanie pól zastępczych dla stron notatek. Użyj klasy [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masternotesslideheaderfootermanager/) gdy chcesz zmienić tylko same notatki główne.

Poniższy przykład ustawia nagłówek, stopkę i tekst daty/godziny w notatkach głównych oraz czyni wszystkie obsługiwane pola zastępcze widocznymi w tym masterze:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Notes header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Notes footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Metoda [`getMasterNotesSlide`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masternotesslidemanager/getmasternotesslide/) zwraca `null`, gdy prezentacja nie zawiera notatek głównych.

## **Zastosuj ustawienia notatek głównych do podrzędnych notatek slajdów**

Notatki główne mogą stosować ustawienia nagłówka i stopki zarówno do siebie, jak i do wszystkich zależnych notatek slajdów. Skorzystaj z dedykowanych metod propagacji w klasie [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masternotesslideheaderfootermanager/) gdy te same ustawienia mają być zastosowane w całej hierarchii notatek.

Na przykład, metody [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) i [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) aktualizują nagłówek notatek głównych oraz wszystkie nagłówki podrzędne. Dostępne są odpowiednie metody dla stopki, daty/godziny i numerów slajdów.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderAndChildHeadersText("Notes header");
        $headerFooterManager->setHeaderAndChildHeadersVisibility(true);

        $headerFooterManager->setFooterAndChildFootersText("Notes footer");
        $headerFooterManager->setFooterAndChildFootersVisibility(true);

        $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");
        $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

        $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    $presentation->save("presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Metody propagacji użyte powyżej to [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) oraz [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Ustaw nagłówki i stopki w pojedynczej notatce slajdu**

Notatka slajdu należy do konkretnego zwykłego slajdu. Skorzystaj z jej klasy [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/notesslideheaderfootermanager/) gdy chcesz dostosować tylko tę stronę notatek.

Metoda [`addNotesSlide`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/notesslidemanager/addnotesslide/) zwraca notatkę slajdu dla bieżącego slajdu i tworzy ją, jeśli jeszcze nie istnieje. Poniższy przykład konfiguruje stronę notatek powiązaną z pierwszym slajdem prezentacji:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
    $headerFooterManager = $notesSlide->getHeaderFooterManager();

    $headerFooterManager->setHeaderText("Header for the first notes page");
    $headerFooterManager->setHeaderVisibility(true);

    $headerFooterManager->setFooterText("Footer for the first notes page");
    $headerFooterManager->setFooterVisibility(true);

    $headerFooterManager->setDateTimeText("Date and time text");
    $headerFooterManager->setDateTimeVisibility(true);

    $headerFooterManager->setSlideNumberVisibility(true);

    $presentation->save("presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Jeśli najpierw propagujesz ustawienia z notatek głównych, a następnie zmieniasz pojedynczą notatkę slajdu, późniejsze ustawienia per‑slajd pozwalają dostosować tę stronę notatek niezależnie.

## **Ustaw nagłówki i stopki w materiale pomocniczym głównym**

Strony materiału pomocniczego używają mastera materiału pomocniczego dla swoich pól zastępczych nagłówka, stopki, daty/godziny i numeru strony. W przeciwieństwie do notatek, ustawienia materiału pomocniczego są zarządzane poprzez master materiału pomocniczego, a nie pojedyncze slajdy materiału pomocniczego.

Użyj metody [`getMasterHandoutSlide`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterhandoutslidemanager/getmasterhandoutslide/) aby uzyskać dostęp do mastera materiału pomocniczego. Jeśli nie jest obecny, wywołaj [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterhandoutslidemanager/setdefaultmasterhandoutslide/) aby utworzyć domyślny master materiału pomocniczego.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();

    if (java_is_null($masterHandoutSlide)) {
        $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();
    }

    if (!java_is_null($masterHandoutSlide)) {
        $headerFooterManager = $masterHandoutSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Handout header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Handout footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_handout_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Zrozum zakres i dziedziczenie**

Wybierz menedżera nagłówka/stopki odpowiadającego zakresowi, który chcesz zmienić:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideheaderfootermanager/) zmienia ustawienia stopki, daty/godziny i numeru slajdu dla jednego zwykłego slajdu.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslideheaderfootermanager/) kontroluje slajd układu i może propagować obsługiwane ustawienia do zależnych slajdów.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslideheaderfootermanager/) kontroluje główny master slajdu i może propagować obsługiwane ustawienia do zależnych slajdów.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masternotesslideheaderfootermanager/) kontroluje notatki główne i może propagować ustawienia do wszystkich zależnych notatek slajdów.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/notesslideheaderfootermanager/) zmienia jedną notatkę slajdu i obsługuje pole zastępcze nagłówka oprócz stopki, daty/godziny i numeru slajdu.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) zmienia master materiału pomocniczego i obsługuje wszystkie cztery typy pól zastępczych.

Używaj propagacji z mastera lub układu, gdy to samo ustawienie ma obowiązywać w całej ich hierarchii. Używaj menedżera pojedynczego slajdu lub notatki, gdy potrzebne jest lokalne ustawienie dla jednej strony.

## **FAQ**

**Czy mogę dodać nagłówek do zwykłego slajdu?**

Nie. PowerPoint nie definiuje pola zastępczego nagłówka dla zwykłych slajdów. Na zwykłych slajdach użyj pól zastępczych stopki, daty/godziny i numeru slajdu. Pola nagłówka są dostępne na stronach notatek i materiałach pomocniczych.

**Co zrobić, gdy pole zastępcze stopki, daty/godziny lub numeru slajdu nie jest widoczne?**

Użyj odpowiedniego menedżera nagłówka/stopki, aby sprawdzić jego widoczność i w razie potrzeby ją włączyć. Na przykład, metoda [`isFooterVisible`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseslideheaderfootermanager/isfootervisible/) informuje, czy pole stopki jest obecne, a [`setFooterVisibility`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) zmienia jego widoczność.

**Jak rozpocząć numerację slajdów od wartości innej niż 1?**

Wywołaj metodę [`setFirstSlideNumber`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/setfirstslidenumber/) prezentacji. Pola numeru slajdu wtedy użyją zaktualizowanej sekwencji numeracji.

**Co się dzieje z nagłówkami i stopkami podczas eksportu do PDF, obrazów lub HTML?**

Widoczne elementy nagłówka i stopki są renderowane razem z pozostałą treścią prezentacji w formacie wyjściowym. Ich wygląd zależy od typu strony, która jest eksportowana, oraz od ustawień widoczności odpowiednich pól zastępczych.