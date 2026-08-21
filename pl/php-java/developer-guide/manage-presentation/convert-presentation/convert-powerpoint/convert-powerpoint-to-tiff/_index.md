---
title: Konwertowanie prezentacji PowerPoint do formatu TIFF w PHP
titlelink: PowerPoint do TIFF
type: docs
weight: 90
url: /pl/php-java/convert-powerpoint-to-tiff/
keywords:
- konwertuj PowerPoint
- konwertuj OpenDocument
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do TIFF
- prezentacja do TIFF
- slajd do TIFF
- PPT do TIFF
- PPTX do TIFF
- zapisz PPT jako TIFF
- zapisz PPTX jako TIFF
- eksportuj PPT do TIFF
- eksportuj PPTX do TIFF
- PHP
- Aspose.Slides
description: "Dowiedz się, jak łatwo konwertować prezentacje PowerPoint (PPT, PPTX) na wysokiej jakości obrazy TIFF przy użyciu Aspose.Slides dla PHP poprzez Java, wraz z przykładami kodu."
---
## **Wprowadzenie**

TIFF (**Tagged Image File Format**) jest powszechnie używanym, bezstratnym formatem obrazu rastrowego, znanym z wyjątkowej jakości i dokładnego zachowania grafiki. Projektanci, fotografowie i wydawcy komputerowi często wybierają TIFF, aby zachować warstwy, dokładność kolorów i pierwotne ustawienia w swoich obrazach.

Korzystając z Aspose.Slides, możesz bez trudu konwertować swoje slajdy PowerPoint (PPT, PPTX) i slajdy OpenDocument (ODP) bezpośrednio na wysokiej jakości obrazy TIFF, zapewniając, że Twoje prezentacje zachowają maksymalną wierność wizualną. 

## **Konwertowanie prezentacji do formatu TIFF**

Korzystając z metody [save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#save) udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/), możesz szybko przekonwertować całą prezentację PowerPoint do formatu TIFF. Powstałe obrazy TIFF odpowiadają domyślnemu rozmiarowi slajdu.

Ten kod demonstruje, jak przekonwertować prezentację PowerPoint do formatu TIFF:

```php
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji (PPT, PPTX, ODP itp.).
$presentation = new Presentation("presentation.pptx");
try {
    // Zapisz prezentację jako TIFF.
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```

## **Konwertowanie prezentacji do czarno-białego TIFF**

Metoda [setBwConversionMode](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tiffoptions/#setBwConversionMode) w klasie [TiffOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tiffoptions/) umożliwia określenie algorytmu używanego przy konwersji kolorowego slajdu lub obrazu do czarno-białego TIFF. Zwróć uwagę, że to ustawienie obowiązuje tylko wtedy, gdy metoda [setCompressionType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tiffoptions/#getCompressionType) jest ustawiona na `CCITT4` lub `CCITT3`.

{{% alert color="info" title="Uwaga" %}}
[TiffOptions::setBwConversionMode](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tiffoptions/#setBwConversionMode) jest ustawieniem na poziomie eksportu, które wybiera algorytm konwersji pikseli dla całego obrazu TIFF. Aby określić, jak ma się wyświetlać pojedynczy kształt w trybie czarno-białym, użyj [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#setBlackWhiteMode). Zobacz [Control Black-and-White Rendering for Shapes](/php-java/shape-formatting/#control-black-and-white-rendering-for-shapes) po przykłady.
{{% /alert %}}

Załóżmy, że mamy plik "sample.pptx" z następującym slajdem:

![Slajd prezentacji](slide_black_and_white.png)

Ten kod demonstruje, jak przekonwertować kolorowy slajd do czarno-białego TIFF:

```php
$tiffOptions = new TiffOptions();
$tiffOptions->setCompressionType(TiffCompressionTypes::CCITT4);
$tiffOptions->setBwConversionMode(BlackWhiteConversionMode::Dithering);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Czarno-biały TIFF](TIFF_black_and_white.png)

## **Konwertowanie prezentacji do TIFF o niestandardowym rozmiarze**

Jeśli potrzebujesz obrazu TIFF o określonych wymiarach, możesz ustawić żądane wartości używając metod dostępnych w klasie [TiffOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tiffoptions/). Na przykład metoda [setImageSize](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tiffoptions/#getImageSize) pozwala określić rozmiar wynikowego obrazu.

Ten kod demonstruje, jak przekonwertować prezentację PowerPoint do obrazów TIFF o niestandardowym rozmiarze:

```php
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji (PPT, PPTX, ODP itp.).
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // Ustaw typ kompresji.
    $tiffOptions->setCompressionType(TiffCompressionTypes::Default);
    /*
    Typy kompresji:
        Default - Określa domyślny schemat kompresji (LZW).
        None - Określa brak kompresji.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Głębokość zależy od typu kompresji i nie może być ustawiona ręcznie.

    // Ustaw DPI obrazu.
    $tiffOptions->setDpiX(200);
    $tiffOptions->setDpiY(200);

    // Ustaw rozmiar obrazu.
    $tiffOptions->setImageSize(new Java("java.awt.Dimension", 1728, 1078));

    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // Zapisz prezentację jako TIFF z określonym rozmiarem.
    $presentation->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

## **Konwertowanie prezentacji do TIFF z niestandardowym formatem pikseli obrazu**

Korzystając z metody [setPixelFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tiffoptions/#getPixelFormat) z klasy [TiffOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tiffoptions/), możesz określić preferowany format pikseli dla powstałego obrazu TIFF.

Ten kod demonstruje, jak przekonwertować prezentację PowerPoint do obrazu TIFF z niestandardowym formatem pikseli:

```php
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji (PPT, PPTX, ODP itp.).
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat zawiera następujące wartości (zgodnie z dokumentacją):
        Format1bppIndexed - 1 bit na piksel, indeksowany.
        Format4bppIndexed - 4 bity na piksel, indeksowany.
        Format8bppIndexed - 8 bitów na piksel, indeksowany.
        Format24bppRgb    - 24 bity na piksel, RGB.
        Format32bppArgb   - 32 bity na piksel, ARGB.
    */

    // Zapisz prezentację jako TIFF z określonym rozmiarem obrazu.
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Wskazówka" color="info" %}}
Sprawdź [DARMOWY konwerter PowerPoint na plakat](https://products.aspose.app/slides/pl/conversion/convert-ppt-to-poster-online) od Aspose.
{{% /alert %}}

## **FAQ**

**Czy mogę przekonwertować pojedynczy slajd zamiast całej prezentacji PowerPoint do formatu TIFF?**

Tak. Aspose.Slides umożliwia konwersję poszczególnych slajdów z prezentacji PowerPoint i OpenDocument na obrazy TIFF osobno.

**Czy istnieje limit liczby slajdów przy konwertowaniu prezentacji do TIFF?**

Nie, Aspose.Slides nie nakłada żadnych ograniczeń na liczbę slajdów. Możesz konwertować prezentacje dowolnej wielkości do formatu TIFF.

**Czy animacje i efekty przejść PowerPoint są zachowywane przy konwersji slajdów do TIFF?**

Nie, TIFF jest formatem obrazu statycznego. W związku z tym animacje i efekty przejść nie są zachowywane; eksportowane są jedynie statyczne migawki slajdów.