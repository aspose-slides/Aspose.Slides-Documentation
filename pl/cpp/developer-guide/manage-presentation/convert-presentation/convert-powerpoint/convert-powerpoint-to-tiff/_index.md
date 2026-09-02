---
title: Konwertowanie prezentacji PowerPoint do TIFF w C++
titlelink: PowerPoint do TIFF
type: docs
weight: 90
url: /pl/cpp/convert-powerpoint-to-tiff/
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
- zapisać PPT jako TIFF
- zapisać PPTX jako TIFF
- eksportować PPT do TIFF
- eksportować PPTX do TIFF
- C++
- Aspose.Slides
description: "Dowiedz się, jak łatwo konwertować prezentacje PowerPoint (PPT, PPTX) na wysokiej jakości obrazy TIFF przy użyciu Aspose.Slides dla C++, z przykładami kodu."
---
## **Wprowadzenie**

TIFF (**Tagged Image File Format**) to szeroko stosowany, bezstratny format rastrowych obrazów znany ze swojej wyjątkowej jakości i szczegółowego zachowania grafiki. Projektanci, fotografowie i wydawcy komputerowi często wybierają TIFF, aby zachować warstwy, dokładność kolorów i oryginalne ustawienia w swoich obrazach.

Korzystając z Aspose.Slides, możesz bez wysiłku konwertować swoje slajdy PowerPoint (PPT, PPTX) oraz slajdy OpenDocument (ODP) bezpośrednio na wysokiej jakości obrazy TIFF, zapewniając maksymalną wierność wizualną prezentacji.

## **Konwertowanie prezentacji do formatu TIFF**

Korzystając z metody [Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save/) udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/), możesz szybko przekształcić całą prezentację PowerPoint do formatu TIFF. Powstałe obrazy TIFF odpowiadają domyślnemu rozmiarowi slajdu.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji (PPT, PPTX, ODP itp.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Zapisz prezentację jako TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Konwertowanie prezentacji do czarno-białego TIFF**

Metoda [set_BwConversionMode](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) w klasie [TiffOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/tiffoptions/) umożliwia określenie algorytmu używanego przy konwersji kolorowego slajdu lub obrazu do czarno-białego TIFF. Zauważ, że to ustawienie ma zastosowanie tylko wtedy, gdy metoda [set_CompressionType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) jest ustawiona na `CCITT4` lub `CCITT3`.

{{% alert color="info" title="Uwaga" %}}
[TiffOptions::set_BwConversionMode](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) jest ustawieniem na poziomie eksportu, które wybiera algorytm konwersji pikseli dla całego obrazu TIFF. Aby określić, jak ma wyglądać pojedynczy kształt, gdy aktywny jest tryb czarno-biały, użyj [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/set_blackwhitemode/). Zobacz [Control Black-and-White Rendering for Shapes](/slides/pl/cpp/shape-formatting/#control-black-and-white-rendering-for-shapes) po przykłady.
{{% /alert %}}

Załóżmy, że mamy plik „sample.pptx” z następującym slajdem:

![Slajd prezentacji](slide_black_and_white.png)

```cpp
#include <DOM/Presentation.h>
#include <Export/BlackWhiteConversionMode.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Wynik:

![Czarno‑biały TIFF](TIFF_black_and_white.png)

## **Konwertowanie prezentacji do TIFF o niestandardowym rozmiarze**

Jeśli potrzebujesz obrazu TIFF o określonych wymiarach, możesz ustawić żądane wartości przy użyciu metod dostępnych w [TiffOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/tiffoptions/). Na przykład metoda [set_ImageSize](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/tiffoptions/set_imagesize/) pozwala określić rozmiar wynikowego obrazu.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji (PPT, PPTX, ODP itp.).
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Ustaw typ kompresji.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
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
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// Ustaw rozmiar obrazu.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Zapisz prezentację jako TIFF o określonym rozmiarze.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **Konwertowanie prezentacji do TIFF z niestandardowym formatem pikseli obrazu**

Korzystając z metody [set_PixelFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) klasy [TiffOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/tiffoptions/), możesz określić preferowany format pikseli dla powstałego obrazu TIFF.

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji (PPT, PPTX, ODP itp.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat zawiera następujące wartości (zgodnie z dokumentacją):
    Format1bppIndexed - 1 bit na piksel, indeksowany.
    Format4bppIndexed - 4 bity na piksel, indeksowany.
    Format8bppIndexed - 8 bitów na piksel, indeksowany.
    Format24bppRgb    - 24 bity na piksel, RGB.
    Format32bppArgb   - 32 bity na piksel, ARGB.
*/

// Zapisz prezentację jako TIFF o określonym rozmiarze obrazu.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Porada" color="info" %}}
Sprawdź darmowy konwerter PowerPoint do plakatu od Aspose: [DARMOWY konwerter PowerPoint do plakatu](https://products.aspose.app/slides/pl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Czy mogę konwertować pojedynczy slajd zamiast całej prezentacji PowerPoint do TIFF?**

Tak. Aspose.Slides umożliwia konwertowanie pojedynczych slajdów z prezentacji PowerPoint i OpenDocument na obrazy TIFF osobno.

**Czy istnieje limit liczby slajdów przy konwersji prezentacji do TIFF?**

Nie, Aspose.Slides nie nakłada żadnych ograniczeń dotyczących liczby slajdów. Możesz konwertować prezentacje dowolnej wielkości do formatu TIFF.

**Czy animacje i efekty przejść PowerPoint są zachowywane przy konwersji slajdów do TIFF?**

Nie, TIFF jest formatem obrazu statycznego. Dlatego animacje i efekty przejść nie są zachowywane; eksportowane są jedynie statyczne migawki slajdów.