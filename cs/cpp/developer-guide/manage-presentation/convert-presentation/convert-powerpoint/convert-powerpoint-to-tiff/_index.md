---
title: Převod prezentací PowerPoint do TIFF v C++
titlelink: PowerPoint do TIFF
type: docs
weight: 90
url: /cs/cpp/convert-powerpoint-to-tiff/
keywords:
- převod PowerPoint
- převod OpenDocument
- převod prezentace
- převod snímku
- převod PPT
- převod PPTX
- PowerPoint do TIFF
- prezentace do TIFF
- snímek do TIFF
- PPT do TIFF
- PPTX do TIFF
- uložit PPT jako TIFF
- uložit PPTX jako TIFF
- export PPT do TIFF
- export PPTX do TIFF
- C++
- Aspose.Slides
description: "Naučte se snadno převádět prezentace PowerPoint (PPT, PPTX) do vysoce kvalitních TIFF obrázků pomocí Aspose.Slides pro C++ s ukázkovým kódem."
---
## **Úvod**

TIFF (**Tagged Image File Format**) je široce používaný bezztrátový rastrový formát obrázků, známý pro vynikající kvalitu a detailní zachování grafiky. Návrháři, fotografové a desktopoví vydavatelé často volí TIFF k zachování vrstev, barevné přesnosti a původních nastavení v jejich obrázcích.

Pomocí Aspose.Slides můžete snadno převést své PowerPoint snímky (PPT, PPTX) a OpenDocument snímky (ODP) přímo na vysoce kvalitní TIFF obrázky, čímž zajistíte, že vaše prezentace zachovají maximální vizuální věrnost.

## **Převod prezentace do TIFF**

Pomocí metody [Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/) poskytované třídou [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) můžete rychle převést celou PowerPoint prezentaci do TIFF. Výsledné TIFF obrázky odpovídají výchozí velikosti snímku.

Tento C++ kód ukazuje, jak převést PowerPoint prezentaci do TIFF:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instantiate the Presentation class that represents a presentation file (PPT, PPTX, ODP, etc.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Save the presentation as TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Převod prezentace do černobílého TIFF**

Metoda [set_BwConversionMode](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/) umožňuje určit algoritmus používaný při převodu barevného snímku nebo obrázku do černobílého TIFF. Všimněte si, že toto nastavení platí pouze tehdy, když je metoda [set_CompressionType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) nastavena na `CCITT4` nebo `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions::set_BwConversionMode](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) je nastavení na úrovni exportu, které vybírá algoritmus konverze pixelů pro celý TIFF obrázek. Chcete-li určit, jak má jednotlivý tvar vypadat, když je aktivní černobílý režim zobrazení, použijte [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/set_blackwhitemode/). Viz [Control Black-and-White Rendering for Shapes](/cpp/shape-formatting/#control-black-and-white-rendering-for-shapes) pro příklady.
{{% /alert %}}

Řekněme, že máme soubor "sample.pptx" s následujícím snímkem:

![Snímek prezentace](slide_black_and_white.png)

Tento C++ kód ukazuje, jak převést barevný snímek do černobílého TIFF:

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

Výsledek:

![Černobílý TIFF](TIFF_black_and_white.png)

## **Převod prezentace do TIFF s vlastní velikostí**

Pokud potřebujete TIFF obrázek s konkrétními rozměry, můžete nastavit požadované hodnoty pomocí metod dostupných ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/). Například metoda [set_ImageSize](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/set_imagesize/) vám umožní definovat velikost výsledného obrázku.

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

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Nastavte typ komprese.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
Typy komprese:
    Default - Určuje výchozí schéma komprese (LZW).
    None - Určuje žádnou kompresi.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// Hloubka závisí na typu komprese a nelze ji nastavit ručně.

// Nastavte DPI obrazu.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// Nastavte velikost obrazu.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Uložte prezentaci jako TIFF s určenou velikostí.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **Převod prezentace do TIFF s vlastním formátem pixelů obrázku**

Pomocí metody [set_PixelFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) ze třídy [TiffOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/) můžete určit preferovaný formát pixelů pro výsledný TIFF obrázek.

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat obsahuje následující hodnoty (jak je uvedeno v dokumentaci):
    Format1bppIndexed - 1 bit na pixel, indexovaný.
    Format4bppIndexed - 4 bity na pixel, indexovaný.
    Format8bppIndexed - 8 bitů na pixel, indexovaný.
    Format24bppRgb    - 24 bitů na pixel, RGB.
    Format32bppArgb   - 32 bitů na pixel, ARGB.
*/

// Uložte prezentaci jako TIFF s určenou velikostí obrázku.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Tip" color="info" %}}
Prohlédněte si bezplatný převodník PowerPoint na plakát od Aspose: [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/cs/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Často kladené otázky**

**Mohu převést jednotlivý snímek místo celé PowerPoint prezentace do TIFF?**

Ano. Aspose.Slides vám umožňuje převádět jednotlivé snímky z PowerPoint i OpenDocument prezentací do TIFF obrázků samostatně.

**Existuje nějaký limit počtu snímků při převodu prezentace do TIFF?**

Ne, Aspose.Slides neklade žádná omezení na počet snímků. Můžete převést prezentace libovolné velikosti do formátu TIFF.

**Zůstávají při převodu snímků do TIFF zachovány animace a přechodové efekty PowerPointu?**

Ne, TIFF je statický formát obrázku. Animace a přechodové efekty tedy nejsou zachovány; jsou exportovány pouze statické snímky snímků.