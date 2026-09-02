---
title: Konwertowanie prezentacji PowerPoint do formatu TIFF w JavaScript
titlelink: PowerPoint do TIFF
type: docs
weight: 90
url: /pl/nodejs-java/convert-powerpoint-to-tiff/
keywords:
- konwertować PowerPoint
- konwertować OpenDocument
- konwertować prezentację
- konwertować slajd
- konwertować PPT
- konwertować PPTX
- PowerPoint do TIFF
- prezentacja do TIFF
- slajd do TIFF
- PPT do TIFF
- PPTX do TIFF
- zapisz PPT jako TIFF
- zapisz PPTX jako TIFF
- eksportuj PPT do TIFF
- eksportuj PPTX do TIFF
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak łatwo konwertować prezentacje PowerPoint (PPT, PPTX) na wysokiej jakości obrazy TIFF przy użyciu Aspose.Slides dla Node.js, z przykładami kodu JavaScript."
---
## **Wprowadzenie**

TIFF (**Tagged Image File Format**) jest szeroko stosowanym, bezstratnym formatem obrazu rastrowego, znanym ze swojej wyjątkowej jakości i szczegółowego zachowania grafiki. Projektanci, fotografowie i wydawcy desktopowi często wybierają TIFF, aby zachować warstwy, dokładność kolorów i pierwotne ustawienia w swoich obrazach.

Korzystając z Aspose.Slides, możesz bez trudu konwertować swoje slajdy PowerPoint (PPT, PPTX) oraz slajdy OpenDocument (ODP) bezpośrednio do wysokiej jakości obrazów TIFF, zapewniając, że Twoje prezentacje zachowają maksymalną wierność wizualną.

## **Konwertowanie prezentacji do TIFF**

Korzystając z metody [save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/), możesz szybko przekonwertować całą prezentację PowerPoint na TIFF. Powstałe obrazy TIFF odpowiadają domyślnemu rozmiarowi slajdu.

Ten kod JavaScript demonstruje, jak przekonwertować prezentację PowerPoint na TIFF:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji (PPT, PPTX, ODP itp.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // Zapisz prezentację jako TIFF.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Konwertowanie prezentacji do czarno-białego TIFF**

Metoda [setBwConversionMode](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) w klasie [TiffOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tiffoptions/) pozwala określić algorytm używany przy konwertowaniu kolorowego slajdu lub obrazu na czarno-biały TIFF. Zwróć uwagę, że to ustawienie ma zastosowanie tylko wtedy, gdy metoda [setCompressionType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) jest ustawiona na `CCITT4` lub `CCITT3`.

{{% alert color="info" title="Uwaga" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) jest ustawieniem na poziomie eksportu, które wybiera algorytm konwersji pikseli dla całego obrazu TIFF. Aby określić, jak ma wyglądać pojedynczy kształt, gdy włączony jest tryb wyświetlania czarno-białego, użyj [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#setBlackWhiteMode). Zobacz [Control Black-and-White Rendering for Shapes](/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes) po przykłady.
{{% /alert %}}

Powiedzmy, że mamy plik „sample.pptx” z następującym slajdem:

![Slajd prezentacji](slide_black_and_white.png)

Ten kod JavaScript demonstruje, jak przekonwertować kolorowy slajd na czarno-biały TIFF:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(aspose.slides.BlackWhiteConversionMode.Dithering);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Wynik:

![Czarno-biały TIFF](TIFF_black_and_white.png)

## **Konwertowanie prezentacji do TIFF z niestandardowym rozmiarem**

Jeśli potrzebujesz obrazu TIFF o określonych wymiarach, możesz ustawić żądane wartości przy użyciu metod dostępnych w klasie [TiffOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tiffoptions/). Na przykład metoda [setImageSize](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tiffoptions/#setImageSize) pozwala określić rozmiar wynikowego obrazu.

Ten kod JavaScript demonstruje, jak przekonwertować prezentację PowerPoint na obrazy TIFF o niestandardowym rozmiarze:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji (PPT, PPTX, ODP itp.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // Ustaw typ kompresji.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    Typy kompresji:
        Default - Określa domyślny schemat kompresji (LZW).
        None - Określa brak kompresji.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Głębia koloru jest kontrolowana przez format pikseli (zobacz przykład poniżej); CCITT3 i CCITT4 zawsze generują 1 bit na piksel.

    // Ustaw DPI obrazu.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Ustaw rozmiar obrazu.
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Zapisz prezentację jako TIFF z określonym rozmiarem.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **Konwertowanie prezentacji do TIFF z niestandardowym formatem pikseli obrazu**

Korzystając z metody [setPixelFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) klasy [TiffOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tiffoptions/), możesz określić preferowany format pikseli dla wynikowego obrazu TIFF.

Ten kod JavaScript demonstruje, jak przekonwertować prezentację PowerPoint na obraz TIFF z niestandardowym formatem pikseli:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji (PPT, PPTX, ODP itd.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat zawiera następujące wartości (zgodnie z dokumentacją):
        Format1bppIndexed - 1 bit na piksel, indeksowany.
        Format4bppIndexed - 4 bity na piksel, indeksowany.
        Format8bppIndexed - 8 bitów na piksel, indeksowany.
        Format24bppRgb    - 24 bity na piksel, RGB.
        Format32bppArgb   - 32 bity na piksel, ARGB.
    */

    /// Zapisz prezentację jako TIFF o określonym rozmiarze obrazu.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Wskazówka" color="info" %}}
Zapoznaj się z [DARMOWYM konwerterem PowerPoint do plakatu](https://products.aspose.app/slides/pl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Czy mogę konwertować pojedynczy slajd zamiast całej prezentacji PowerPoint na TIFF?**

Tak. Aspose.Slides umożliwia konwertowanie pojedynczych slajdów z prezentacji PowerPoint i OpenDocument na obrazy TIFF oddzielnie.

**Czy istnieje limit liczby slajdów przy konwertowaniu prezentacji do TIFF?**

Nie, Aspose.Slides nie nakłada żadnych ograniczeń na liczbę slajdów. Możesz konwertować prezentacje dowolnego rozmiaru do formatu TIFF.

**Czy animacje i efekty przejść PowerPoint są zachowywane przy konwertowaniu slajdów do TIFF?**

Nie, TIFF jest formatem obrazu statycznego. Dlatego animacje i efekty przejść nie są zachowywane; eksportowane są jedynie statyczne migawki slajdów.