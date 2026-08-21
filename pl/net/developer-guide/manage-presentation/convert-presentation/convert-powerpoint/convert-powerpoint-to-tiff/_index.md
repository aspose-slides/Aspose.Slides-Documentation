---
title: Konwertuj prezentacje PowerPoint do TIFF w .NET
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

TIFF (**Tagged Image File Format**) to szeroko stosowany, bezstratny format rastrowych obrazów, znany z wyjątkowej jakości i szczegółowego zachowania grafiki. Projektanci, fotografowie i wydawcy komputerowi często wybierają TIFF, aby zachować warstwy, dokładność kolorów i pierwotne ustawienia w swoich obrazach.

Korzystając z Aspose.Slides, możesz bez wysiłku konwertować swoje slajdy PowerPoint (PPT, PPTX) oraz slajdy OpenDocument (ODP) bezpośrednio na wysokiej jakości obrazy TIFF, zapewniając maksymalną wierność wizualną prezentacji.

## **Konwertuj prezentację do formatu TIFF**

Używając metody [Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/save/) udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/), możesz szybko konwertować całą prezentację PowerPoint na TIFF. Powstałe obrazy TIFF odpowiadają domyślnemu rozmiarowi slajdu.

Ten kod w C# demonstruje, jak konwertować prezentację PowerPoint do TIFF:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Utwórz obiekt klasy Presentation, który reprezentuje plik prezentacji (PPT, PPTX, ODP, itp.).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // Zapisz prezentację jako TIFF.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **Konwertuj prezentację do czarno-białego TIFF**

Właśćność [BwConversionMode](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/bwconversionmode/) w klasie [TiffOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/) pozwala określić algorytm używany przy konwertowaniu kolorowego slajdu lub obrazu na czarno-biały TIFF. Uwaga, to ustawienie ma zastosowanie tylko wtedy, gdy właściwość [CompressionType](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/compressiontype/) jest ustawiona na `CCITT4` lub `CCITT3`.

{{% alert color="info" title="Uwaga" %}}

[TiffOptions.BwConversionMode](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/bwconversionmode/) jest ustawieniem na poziomie eksportu, które wybiera algorytm konwersji pikseli dla całego obrazu TIFF. Aby określić, jak powinien wyglądać pojedynczy kształt w trybie czarno-białym, użyj [IShape.BlackWhiteMode](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/blackwhitemode/). Zobacz [Kontrolowanie renderowania czarno-białego dla kształtów](/net/shape-formatting/#control-black-and-white-rendering-for-shapes) po przykłady.

{{% /alert %}}

Załóżmy, że mamy plik „sample.pptx” z następującym slajdem:

![Slajd prezentacji](slide_black_and_white.png)

Ten kod w C# demonstruje, jak konwertować kolorowy slajd na czarno-biały TIFF:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Konwertuj prezentację do formatu TIFF z niestandardowym rozmiarem**

Jeśli potrzebujesz obrazu TIFF o określonych wymiarach, możesz ustawić żądane wartości przy pomocy właściwości dostępnych w [TiffOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/). Na przykład właściwość [ImageSize](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/imagesize/) pozwala określić rozmiar wynikowego obrazu.

Ten kod w C# demonstruje, jak konwertować prezentację PowerPoint na obrazy TIFF o niestandardowym rozmiarze:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Utwórz obiekt klasy Presentation, który reprezentuje plik prezentacji (PPT, PPTX, ODP, itp.).
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

    // Zapisz prezentację jako TIFF w określonym rozmiarze.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **Konwertuj prezentację do TIFF z niestandardowym formatem pikseli obrazu**

Korzystając z właściwości [PixelFormat](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/pixelformat/) klasy [TiffOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions), możesz określić preferowany format pikseli dla wynikowego obrazu TIFF.

Ten kod w C# demonstruje, jak konwertować prezentację PowerPoint na obraz TIFF z niestandardowym formatem pikseli:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Utwórz obiekt klasy Presentation, który reprezentuje plik prezentacji (PPT, PPTX, ODP, itp.).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat zawiera następujące wartości (jak podano w dokumentacji):
        Format1bppIndexed - 1 bit na piksel, indeksowany.
        Format4bppIndexed - 4 bity na piksel, indeksowany.
        Format8bppIndexed - 8 bitów na piksel, indeksowany.
        Format24bppRgb    - 24 bity na piksel, RGB.
        Format32bppArgb   - 32 bity na piksel, ARGB.
    */

    // Zapisz prezentację jako TIFF w określonym rozmiarze obrazu.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Wskazówka" color="info" %}}

Sprawdź darmowy konwerter Aspose „PowerPoint do plakatu” [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/pl/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **FAQ**

**Czy mogę konwertować pojedynczy slajd zamiast całej prezentacji PowerPoint do formatu TIFF?**

Tak. Aspose.Slides umożliwia konwersję pojedynczych slajdów z prezentacji PowerPoint i OpenDocument na obrazy TIFF osobno.

**Czy istnieje limit liczby slajdów przy konwertowaniu prezentacji do TIFF?**

Nie, Aspose.Slides nie nakłada żadnych ograniczeń dotyczących liczby slajdów. Możesz konwertować prezentacje dowolnego rozmiaru do formatu TIFF.

**Czy animacje i efekty przejść PowerPoint są zachowywane przy konwertowaniu slajdów do TIFF?**

Nie, TIFF jest formatem obrazu statycznego. Dlatego animacje i efekty przejść nie są zachowywane; eksportowane są jedynie statyczne migawki slajdów.