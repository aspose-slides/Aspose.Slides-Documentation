---
title: Konwertowanie prezentacji PowerPoint do TIFF na Androidzie
titlelink: PowerPoint do TIFF
type: docs
weight: 90
url: /pl/androidjava/convert-powerpoint-to-tiff/
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
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak łatwo konwertować prezentacje PowerPoint (PPT, PPTX) na wysokiej jakości obrazy TIFF przy użyciu Aspose.Slides dla Androida, z przykładami kodu w języku Java."
---
## **Wprowadzenie**

TIFF (**Tagged Image File Format**) jest szeroko używanym, bezstratnym formatem obrazu rastrowego, znanym z wyjątkowej jakości i szczegółowego zachowania grafiki. Projektanci, fotografowie i wydawcy stacjonarni często wybierają TIFF, aby zachować warstwy, dokładność kolorów i pierwotne ustawienia w swoich obrazach.

Używając Aspose.Slides, możesz łatwo konwertować swoje slajdy PowerPoint (PPT, PPTX) i slajdy OpenDocument (ODP) bezpośrednio na obrazy TIFF wysokiej jakości, zapewniając, że Twoje prezentacje zachowują maksymalną wierność wizualną. 

## **Konwertowanie prezentacji do formatu TIFF**

Używając metody [save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/), możesz szybko przekonwertować całą prezentację PowerPoint do TIFF. Powstałe obrazy TIFF odpowiadają domyślnemu rozmiarowi slajdu.

Ten kod demonstruje, jak przekonwertować prezentację PowerPoint do TIFF:

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji (PPT, PPTX, ODP itp.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    // Zapisz prezentację jako TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Konwertowanie prezentacji do czarno-białego TIFF**

Metoda [setBwConversionMode](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) w klasie [TiffOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tiffoptions/) pozwala określić algorytm używany przy konwersji kolorowego slajdu lub obrazu do czarno-białego TIFF. Uwaga: to ustawienie ma zastosowanie tylko wtedy, gdy metoda [setCompressionType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) jest ustawiona na `CCITT4` lub `CCITT3`.

{{% alert color="info" title="Uwaga" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) jest ustawieniem na poziomie eksportu, które wybiera algorytm konwersji pikseli dla całego obrazu TIFF. Aby określić, jak ma wyglądać poszczególny kształt w trybie czarno-białym, użyj [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-). Zobacz [Kontrola renderowania czarno-białego dla kształtów](/androidjava/shape-formatting/#control-black-and-white-rendering-for-shapes) for examples.
{{% /alert %}}

Załóżmy, że mamy plik "sample.pptx" z następującym slajdem:

![Slajd prezentacji](slide_black_and_white.png)

Ten kod demonstruje, jak przekonwertować kolorowy slajd do czarno-białego TIFF:

```java
import com.aspose.slides.*;

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setCompressionType(TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(BlackWhiteConversionMode.Dithering);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Wynik:

![Czarno-biały TIFF](TIFF_black_and_white.png)

## **Konwertowanie prezentacji do TIFF o niestandardowym rozmiarze**

Jeśli potrzebujesz obrazu TIFF o określonych wymiarach, możesz ustawić żądane wartości przy użyciu metod dostępnych w [TiffOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tiffoptions/). Na przykład metoda [setImageSize](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) pozwala określić rozmiar wynikowego obrazu.

Ten kod demonstruje, jak przekonwertować prezentację PowerPoint do obrazów TIFF o niestandardowym rozmiarze:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji (PPT, PPTX, ODP itp.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // Ustaw typ kompresji.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
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
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Ustaw rozmiar obrazu.
    tiffOptions.setImageSize(new Size(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Zapisz prezentację jako TIFF z określonym rozmiarem.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **Konwertowanie prezentacji do TIFF z niestandardowym formatem pikseli obrazu**

Używając metody [setPixelFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) z klasy [TiffOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tiffoptions/), możesz określić preferowany format pikseli dla wynikowego obrazu TIFF.

Ten kod demonstruje, jak przekonwertować prezentację PowerPoint do obrazu TIFF z niestandardowym formatem pikseli:

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji (PPT, PPTX, ODP itp.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat zawiera następujące wartości (zgodnie z dokumentacją):
        Format1bppIndexed - 1 bit na piksel, indeksowany.
        Format4bppIndexed - 4 bity na piksel, indeksowany.
        Format8bppIndexed - 8 bitów na piksel, indeksowany.
        Format24bppRgb    - 24 bity na piksel, RGB.
        Format32bppArgb   - 32 bity na piksel, ARGB.
    */
    
    // Zapisz prezentację jako TIFF w określonym formacie pikseli.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Wskazówka" color="info" %}}
Sprawdź darmowy konwerter PowerPoint do plakatu firmy Aspose: [DARMOWY konwerter PowerPoint do plakatu](https://products.aspose.app/slides/pl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Czy mogę konwertować pojedynczy slajd zamiast całej prezentacji PowerPoint do formatu TIFF?**

Tak. Aspose.Slides pozwala konwertować poszczególne slajdy z prezentacji PowerPoint i OpenDocument na obrazy TIFF osobno.

**Czy istnieje limit liczby slajdów przy konwersji prezentacji do formatu TIFF?**

Nie, Aspose.Slides nie narzuca żadnych ograniczeń co do liczby slajdów. Możesz konwertować prezentacje dowolnego rozmiaru do formatu TIFF.

**Czy animacje i efekty przejść PowerPoint są zachowywane przy konwersji slajdów do formatu TIFF?**

Nie, TIFF jest formatem obrazu statycznego. Dlatego animacje i efekty przejść nie są zachowywane; eksportowane są jedynie statyczne migawki slajdów.