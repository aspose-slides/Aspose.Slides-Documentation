---
title: Zmień rozmiar i orientację strony notatek w PHP
linktitle: Rozmiar strony notatek
type: docs
weight: 10
url: /pl/php-java/notes-size/
keywords:
- rozmiar strony notatek
- orientacja notatek
- notatki poziome
- notatki pionowe
- rozmiar materiałów dodatkowych
- PowerPoint
- prezentacja
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Odczytaj i zmień wymiary strony notatek w Aspose.Slides dla PHP przy użyciu Java, zmień orientację, zweryfikuj zapisane rozmiary oraz wyeksportuj notatki lub materiały dodatkowe do PDF i obrazów."
---
## **Przegląd**

Użyj [Presentation::getNotesSize](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/getnotessize/), aby uzyskać dostęp do ustawień strony notatek prezentacji. Zwraca ona obiekt [NotesSize](https://reference.aspose.com/slides/pl/php-java/aspose.slides/notessize/), którego metoda [setSize](https://reference.aspose.com/slides/pl/php-java/aspose.slides/notessize/setsize/) ustawia wymiary strony. Chociaż obiekt ustawień nie może być wymieniony, nowe wymiary można przypisać przy użyciu tej metody.

Szerokość i wysokość podawane są w **punktach**, przy założeniu 72 punktów na cal. Na przykład 900 × 600 punktów to 12,5 × 8 ⅓ cala. Ustawienia te dotyczą całej prezentacji, a nie notatek pojedynczego slajdu.

| Ustawienie | Cel |
| --- | --- |
| [Presentation::getNotesSize](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/getnotessize/) | Kontroluje wymiary strony notatek oraz wymiary strony używane przy eksporcie materiałów dodatkowych. |
| [Presentation::getSlideSize](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/getslidesize/) | Kontroluje wymiary zwykłych slajdów prezentacji poprzez [SlideSize](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidesize/). |

Zmiana jednego ustawienia nie powoduje automatycznej zmiany drugiego. Zmiana orientacji strony notatek nie obraca również zwykłych slajdów. Zobacz [Slide Size](/slides/pl/php-java/slide-size/), aby zmienić rozmiar zwykłych slajdów.

Poniższe przykłady używają istniejącego pliku `sample.pptx`. W przykładach eksportu użyj prezentacji zawierającej co najmniej jeden slajd z notatkami prelegenta. Każdy przykład może być uruchomiony samodzielnie po załadowaniu mostu PHP/Java oraz wrappera Aspose.Slides PHP. Wartości liczbowe zwracane przez Javę są konwertowane na wartości PHP przy pomocy `java_values` przed porównaniem lub obliczeniami.

## **Odczyt rozmiaru i orientacji strony notatek**

Odczytaj szerokość i wysokość i porównaj je, aby określić orientację: szersza strona to krajobraz, wyższa – portret, a równe wymiary opisują stronę kwadratową. Ten przykład wyświetla rzeczywiste wymiary w punktach, nie zakładając standardowego rozmiaru papieru.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();
    $orientation = "Square";

    if (java_values($size->getWidth()) > java_values($size->getHeight())) {
        $orientation = "Landscape";
    } else if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $orientation = "Portrait";
    }

    echo "Notes page: " . java_values($size->getWidth()) . " x " . java_values($size->getHeight()) . " points" . PHP_EOL;
    echo "Orientation: " . $orientation . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Przełączenie na krajobraz bez zmiany rozmiaru papieru**

Aby zmienić jedynie orientację, zamień istniejącą szerokość i wysokość miejscami. Dzięki temu zachowane zostaną długości obu boków, w tym wymiary niestandardowego papieru. Warunek poniżej zapobiega zmianie strony już w orientacji krajobrazowej na portretową oraz pozostawia stronę kwadratową bez zmian.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();

    if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $width = java_values($size->getWidth());
        $size->setSize(java_values($size->getHeight()), $width);
        $presentation->getNotesSize()->setSize($size);
    }

    $presentation->save("landscape-notes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Dla orientacji portretowej użyj tego samego przypisania, gdy `java_values($size->getWidth()) > java_values($size->getHeight())`. Nie zamieniaj wymiarów A4 ani Letter, chyba że chcesz również zmienić rozmiar papieru.

## **Ustawienie i weryfikacja niestandardowego rozmiaru strony notatek**

Przypisz oba wymiary jednocześnie, a następnie użyj [Presentation::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/save/), aby zapisać prezentację. Ten przykład ustawia krajobrazową stronę 900 × 600 punktów, zapisuje ją jako PPTX i ponownie otwiera zapisany plik, aby sprawdzić zachowane wartości. Porównanie dopuszcza tolerancję 0,01 punktu dla liczb zmiennoprzecinkowych; nie jest to gwarancja precyzji dla każdego formatu pliku.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $expectedSize = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($expectedSize);

    $presentation->save("custom-notes.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom-notes.pptx");
    try {
        $actualSize = $reopened->getNotesSize()->getSize();
        $widthMatches = abs(java_values($actualSize->getWidth()) - java_values($expectedSize->getWidth())) < 0.01;
        $heightMatches = abs(java_values($actualSize->getHeight()) - java_values($expectedSize->getHeight())) < 0.01;
        $preserved = $widthMatches && $heightMatches;

        echo "Stored notes page: " . java_values($actualSize->getWidth()) . " x " . java_values($actualSize->getHeight()) . " points" . PHP_EOL;
        echo "Size preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Oczekiwany wynik to `900 x 600 points` oraz `Size preserved: true`. Sprawdzenie nowo otwartej prezentacji weryfikuje zapisany plik, a nie jedynie ustawienia w pamięci.

## **Eksport notatek i materiałów dodatkowych**

Wymiary strony określają dostępny obszar dla układów notatek lub materiałów dodatkowych. Nie włączają one tych układów same z siebie – należy również skonfigurować opcje eksportu. Eksport zwykłych slajdów nadal używa wymiarów slajdu.

### **Eksport notatek do PDF i PNG**

Przypisz [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/notescommentslayoutingoptions/) do [PdfOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions), aby uwzględnić notatki w PDF. Ten przykład renderuje także pierwszy slajd z notatkami do PNG przy użyciu [Slide::getImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/#getImage) oraz [RenderingOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/renderingoptions/).

Tryb [BottomTruncated](https://reference.aspose.com/slides/pl/php-java/aspose.slides/notespositions/) zachowuje notatki na jednej stronie; notatki, które nie mieszczą się, mogą być obcięte. PDF używa stron 900 × 600 punktów. Przy skali obrazu 1 × 1 użytej poniżej PNG ma wymiary 900 × 600 pikseli. Punkty opisują geometrię strony; piksele opisują wynik rastrowy, którego rozmiar zależy także od skali renderowania.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\RenderingOptions;
use aspose\slides\ImageFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new NotesCommentsLayoutingOptions();
    $layout->setNotesPosition(NotesPositions::BottomTruncated);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("notes.pdf", SaveFormat::Pdf, $pdfOptions);

    $renderingOptions = new RenderingOptions();
    $renderingOptions->setSlidesLayoutOptions($layout);

    $image = $presentation->getSlides()->get_Item(0)->getImage($renderingOptions, 1, 1);
    try {
        $image->save("first-slide-notes.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

W przypadku eksportu PDF z długimi notatkami tryb [BottomFull](https://reference.aspose.com/slides/pl/php-java/aspose.slides/notespositions/) pozwala na dodanie dodatkowych stron w razie potrzeby. Nie używaj tego trybu z wywołaniem obrazu pojedynczego slajdu przedstawionym powyżej, ponieważ nie jest ono obsługiwane. Po zmianie rozmiaru sprawdź wyjście pod kątem przyciętych notatek oraz położenia istniejących obiektów master‑notatek; zmiana samej wielkości strony nie powinna być traktowana jako gwarancja, że cała zawartość się zmieści. Zobacz [Convert PowerPoint to PDF with Notes](/slides/pl/php-java/convert-powerpoint-to-pdf-with-notes/) po więcej informacji o eksporcie notatek.

### **Eksport materiałów dodatkowych do PDF**

Użyj [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/handoutlayoutingoptions/) dla wielu miniatur slajdów na jednej stronie. Poniższy przykład ustawia stronę 900 × 600 punktów i używa [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/pl/php-java/aspose.slides/handouttype/), aby rozmieszczać do czterech slajdów na stronie. Ustawienie poziome określa kolejność slajdów; orientacja strony pochodzi z jej szerokości i wysokości.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PdfOptions;
use aspose\slides\HandoutLayoutingOptions;
use aspose\slides\HandoutType;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new HandoutLayoutingOptions();
    $layout->setHandout(HandoutType::Handouts4Horizontal);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("handouts.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Zmiana rozmiaru strony zmienia obszar dostępny dla siatki materiałów dodatkowych, nie zmieniając wymiarów źródłowych slajdów. Dla obrazów materiałów dodatkowych użyj [Presentation::getImages](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/getimages/) z układem materiałów dodatkowych, a nie metody obrazu pojedynczego slajdu. W Aspose.Slides renderowanie materiałów dodatkowych na poziomie prezentacji korzysta z wymiarów strony notatek, natomiast wywołanie obrazu pojedynczego slajdu nie generuje strony materiałów dodatkowych. Zobacz [Handout Mode](/slides/pl/php-java/convert-powerpoint-in-handout-mode/) po opcje układów.

## **Rozmiar strony w przeglądarkach, przy eksporcie i drukowaniu**

Traktuj rozmiar zapisanej prezentacji, rozmiar eksportowanej strony i rozmiar papieru drukowanego jako odrębne elementy:

- **Przeglądarki prezentacji:** Przeglądarka może wyświetlać lub drukować notatki według własnych reguł układu. Jeśli inna aplikacja zapisze plik, otwórz go ponownie i sprawdź wymiary – konwersja formatów w tej aplikacji może je znormalizować.
- **Formaty eksportu:** Przykłady PDF z notatkami i materiałami dodatkowymi powyżej używają skonfigurowanych wymiarów strony. Obrazy rastrowe używają wymiarów w pełnych pikselach i skali renderowania, więc ułamkowe wartości punktów mogą być zaokrąglane w wyjściu obrazu. Eksport zwykłych slajdów nie wykorzystuje rozmiaru strony notatek.
- **Sterowniki drukarek:** Wybór papieru, automatyczne obracanie i ustawienia dopasowania do strony mogą zmienić fizyczny wydruk bez zmiany wymiarów zapisanych w prezentacji lub PDF. Dla konkretnego rozmiaru papieru dopasuj ustawienia drukarki i sprawdź podgląd wydruku.

## **FAQ**

**Czy mogę ustawić rozmiar notatek tylko dla jednego slajdu?**

Rozmiar strony notatek jest ustawieniem na poziomie całej prezentacji. Poszczególne slajdy mogą mieć różną treść notatek, ale ta właściwość nie zapewnia odrębnego rozmiaru strony dla każdego slajdu.

**Dlaczego zmiana orientacji notatek nie zmieniła moich slajdów?**

Strony notatek i zwykłe slajdy mają niezależne wymiary. Użyj ustawień rozmiaru zwykłych slajdów, gdy chcesz zmienić rozmiar samych slajdów.

**Dlaczego mój zapisany lub wydrukowany wynik ma inny rozmiar?**

Najpierw otwórz ponownie zapisaną prezentację i porównaj wymiary notatek. Jeśli się zmieniły, sprawdź, czy zapis lub konwersja pliku w innej aplikacji zmodyfikowała ustawienia strony. Jeśli nie, zweryfikuj układ eksportu, skalę obrazu, ustawienia przeglądarki oraz wybór papieru w drukarce.