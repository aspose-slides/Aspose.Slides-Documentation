---
title: Konwertuj prezentacje PowerPoint do formatu TIFF w .NET
titlelink: PowerPoint do TIFF
type: docs
weight: 90
url: /pl/net/convert-powerpoint-to-tiff/
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
  - .NET
  - C#
  - Aspose.Slides
description: "Dowiedz się, jak łatwo konwertować prezentacje PowerPoint (PPT, PPTX) na wysokiej jakości obrazy TIFF przy użyciu Aspose.Slides dla .NET. Przykłady kodu w C#."
---
## **Wprowadzenie**

TIFF (**Tagged Image File Format**) jest powszechnie używanym, bezstratnym formatem obrazu rastrowego, znanym ze swojej wyjątkowej jakości i szczegółowego zachowania grafiki. Projektanci, fotografowie i publikatorzy komputerowi często wybierają TIFF, aby zachować warstwy, dokładność kolorów i pierwotne ustawienia w swoich obrazach.

Korzystając z Aspose.Slides, możesz bezwysiłkowo konwertować swoje slajdy PowerPoint (PPT, PPTX) oraz slajdy OpenDocument (ODP) bezpośrednio na obrazy TIFF wysokiej jakości, zapewniając, że Twoje prezentacje zachowają maksymalną wierność wizualną.

## **Konwertowanie prezentacji do formatu TIFF**

Używając metody [Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/save/) udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/), możesz szybko skonwertować całą prezentację PowerPoint do formatu TIFF. Powstałe obrazy TIFF odpowiadają domyślnemu rozmiarowi slajdu.

Ten kod C# demonstruje, jak skonwertować prezentację PowerPoint do formatu TIFF:

```cs
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji (PPT, PPTX, ODP, itp.).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // Zapisz prezentację jako TIFF.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **Konwertowanie prezentacji do czarno-białego TIFF**

Właściwość [BwConversionMode](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/bwconversionmode/) w klasie [TiffOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/) umożliwia określenie algorytmu używanego podczas konwertowania kolorowego slajdu lub obrazu na czarno-biały TIFF. Należy zauważyć, że to ustawienie działa tylko wtedy, gdy właściwość [CompressionType](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/compressiontype/) jest ustawiona na `CCITT4` lub `CCITT3`.

Załóżmy, że mamy plik "sample.pptx" z następującym slajdem:

![Slajd prezentacji](slide_black_and_white.png)

Ten kod C# demonstruje, jak skonwertować kolorowy slajd do czarno-białego TIFF:

```cs
TiffOptions tiffOptions = new TiffOptions
{
    CompressionType = TiffCompressionTypes.CCITT4,
    BwConversionMode = BlackWhiteConversionMode.Dithering
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    presentation.Save("output.tiff", SaveFormat.Tiff, tiffOptions);
}
```

Wynik:

![Czarnobiały TIFF](TIFF_black_and_white.png)

## **Konwertowanie prezentacji do formatu TIFF o niestandardowym rozmiarze**

Jeśli potrzebujesz obrazu TIFF o określonych wymiarach, możesz ustawić żądane wartości przy użyciu właściwości dostępnych w klasie [TiffOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/). Na przykład, właściwość [ImageSize](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/imagesize/) pozwala zdefiniować rozmiar powstałego obrazu.

Ten kod C# demonstruje, jak skonwertować prezentację PowerPoint do obrazów TIFF o niestandardowym rozmiarze:

```cs
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji (PPT, PPTX, ODP, itp.).
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // Ustaw typ kompresji.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
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
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // Ustaw rozmiar obrazu.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // Zapisz prezentację jako TIFF o określonym rozmiarze.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **Konwertowanie prezentacji do formatu TIFF z niestandardowym formatem pikseli obrazu**

Korzystając z właściwości [PixelFormat](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/pixelformat/) klasy [TiffOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions), możesz określić preferowany format pikseli dla powstałego obrazu TIFF.

Ten kod C# demonstruje, jak skonwertować prezentację PowerPoint do obrazu TIFF z niestandardowym formatem pikseli:

```cs
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji (PPT, PPTX, ODP, itp.).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat zawiera następujące wartości (zgodnie z dokumentacją):
        Format1bppIndexed - 1 bit na piksel, indeksowany.
        Format4bppIndexed - 4 bity na piksel, indeksowany.
        Format8bppIndexed - 8 bitów na piksel, indeksowany.
        Format24bppRgb    - 24 bity na piksel, RGB.
        Format32bppArgb   - 32 bity na piksel, ARGB.
    */

    // Zapisz prezentację jako TIFF o określonym rozmiarze obrazu.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tip" color="primary" %}}
Sprawdź darmowy konwerter PowerPoint do plakatu firmy Aspose [DARMOWY konwerter PowerPoint do plakatu](https://products.aspose.app/slides/pl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Czy mogę konwertować pojedynczy slajd zamiast całej prezentacji PowerPoint na TIFF?**

Tak. Aspose.Slides umożliwia konwertowanie pojedynczych slajdów z prezentacji PowerPoint i OpenDocument na obrazy TIFF osobno.

**Czy istnieje jakiś limit liczby slajdów przy konwertowaniu prezentacji do TIFF?**

Nie, Aspose.Slides nie nakłada żadnych ograniczeń na liczbę slajdów. Możesz konwertować prezentacje o dowolnym rozmiarze do formatu TIFF.

**Czy animacje i efekty przejść PowerPoint są zachowywane przy konwertowaniu slajdów do TIFF?**

Nie, TIFF jest formatem obrazu statycznego. Dlatego animacje i efekty przejść nie są zachowywane; eksportowane są jedynie statyczne migawki slajdów.