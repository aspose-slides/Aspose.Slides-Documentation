---
title: Konwertuj prezentacje PowerPoint na TIFF w systemie Android
titlelink: PowerPoint na TIFF
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
- PowerPoint na TIFF
- prezentacja na TIFF
- slajd na TIFF
- PPT na TIFF
- PPTX na TIFF
- zapisz PPT jako TIFF
- zapisz PPTX jako TIFF
- eksportuj PPT do TIFF
- eksportuj PPTX do TIFF
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak łatwo konwertować prezentacje PowerPoint (PPT, PPTX) na wysokiej jakości obrazy TIFF przy użyciu Aspose.Slides dla Androida, z przykładami kodu w Javie."
---
## **Wprowadzenie**

TIFF (**Tagged Image File Format**) jest powszechnie używanym, bezstratnym formatem rastrowym, znanym z wyjątkowej jakości i szczegółowego zachowania grafiki. Projektanci, fotografowie i wydawcy komputerowi często wybierają TIFF, aby zachować warstwy, dokładność kolorów i oryginalne ustawienia w swoich obrazach.

Korzystając z Aspose.Slides, możesz łatwo przekonwertować swoje slajdy PowerPoint (PPT, PPTX) i slajdy OpenDocument (ODP) bezpośrednio na wysokiej jakości obrazy TIFF, zapewniając maksymalną wierność wizualną prezentacji.

## **Konwersja prezentacji do formatu TIFF**

Korzystając z metody [save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/), możesz szybko przekonwertować całą prezentację PowerPoint na TIFF. Powstałe obrazy TIFF odpowiadają domyślnemu rozmiarowi slajdu.

Ten kod pokazuje, jak przekonwertować prezentację PowerPoint na TIFF:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji (PPT, PPTX, ODP itd.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    // Zapisz prezentację jako TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Konwersja prezentacji do czarno‑białego TIFF**

Metoda [setBwConversionMode](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) w klasie [TiffOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tiffoptions/) umożliwia określenie algorytmu używanego podczas konwersji kolorowego slajdu lub obrazu na czarno‑biały TIFF. Uwaga: to ustawienie działa tylko wtedy, gdy metoda [setCompressionType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) jest ustawiona na `CCITT4` lub `CCITT3`.

Załóżmy, że mamy plik „sample.pptx” z następującym slajdem:

![Slajd prezentacji](slide_black_and_white.png)

Ten kod pokazuje, jak przekonwertować kolorowy slajd na czarno‑biały TIFF:

```java
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

![Czarno‑biały TIFF](TIFF_black_and_white.png)

## **Konwersja prezentacji do TIFF o niestandardowym rozmiarze**

Jeśli potrzebujesz obrazu TIFF o określonych wymiarach, możesz ustawić żądane wartości za pomocą metod dostępnych w klasie [TiffOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tiffoptions/). Na przykład metoda [setImageSize](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) pozwala zdefiniować rozmiar wynikowego obrazu.

Ten kod pokazuje, jak przekonwertować prezentację PowerPoint na obrazy TIFF o niestandardowym rozmiarze:

```java
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

    INotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Zapisz prezentację jako TIFF o określonym rozmiarze.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **Konwersja prezentacji do TIFF z niestandardowym formatem pikseli obrazu**

Korzystając z metody [setPixelFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) klasy [TiffOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tiffoptions/), możesz określić preferowany format pikseli dla wynikowego obrazu TIFF.

Ten kod pokazuje, jak przekonwertować prezentację PowerPoint na obraz TIFF z niestandardowym formatem pikseli:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji (PPT, PPTX, ODP itd.).
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
    
    // Zapisz prezentację jako TIFF o określonym rozmiarze obrazu.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Sprawdź darmowy konwerter PowerPoint na plakat od Aspose [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/pl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Czy mogę konwertować pojedynczy slajd zamiast całej prezentacji PowerPoint na TIFF?**

Tak. Aspose.Slides umożliwia konwersję poszczególnych slajdów z prezentacji PowerPoint i OpenDocument na obrazy TIFF oddzielnie.

**Czy istnieje limit liczby slajdów przy konwersji prezentacji do TIFF?**

Nie, Aspose.Slides nie nakłada żadnych ograniczeń na liczbę slajdów. Możesz konwertować prezentacje dowolnej wielkości do formatu TIFF.

**Czy animacje i efekty przejścia PowerPoint są zachowywane przy konwersji slajdów do TIFF?**

Nie, TIFF jest formatem obrazu statycznego. Dlatego animacje i efekty przejścia nie są zachowywane; eksportowane są jedynie statyczne migawki slajdów.