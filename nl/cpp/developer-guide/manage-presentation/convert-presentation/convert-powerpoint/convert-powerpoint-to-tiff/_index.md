---
title: PowerPoint-presentaties naar TIFF converteren in C++
titlelink: PowerPoint naar TIFF
type: docs
weight: 90
url: /nl/cpp/convert-powerpoint-to-tiff/
keywords:
- PowerPoint converteren
- OpenDocument converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar TIFF
- presentatie naar TIFF
- dia naar TIFF
- PPT naar TIFF
- PPTX naar TIFF
- PPT opslaan als TIFF
- PPTX opslaan als TIFF
- PPT exporteren naar TIFF
- PPTX exporteren naar TIFF
- C++
- Aspose.Slides
description: "Leer hoe u eenvoudig PowerPoint (PPT, PPTX) presentaties naar hoogwaardige TIFF-afbeeldingen kunt converteren met Aspose.Slides voor C++, inclusief codevoorbeelden."
---
## **Introductie**

TIFF (**Tagged Image File Format**) is een veelgebruikt, verliesvrij rasterafbeeldingsformaat dat bekend staat om zijn uitzonderlijke kwaliteit en nauwkeurige weergave van grafische elementen. Ontwerpers, fotografen en desktop‑uitgevers kiezen vaak TIFF om lagen, kleurnauwkeurigheid en oorspronkelijke instellingen in hun afbeeldingen te behouden.

Met Aspose.Slides kun je moeiteloos je PowerPoint‑dia's (PPT, PPTX) en OpenDocument‑dia's (ODP) direct omzetten naar TIFF‑afbeeldingen van hoge kwaliteit, zodat je presentaties de maximale visuele getrouwheid behouden.

## **Presentatie converteren naar TIFF**

Met behulp van de [Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/)‑methode van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse kun je snel een volledige PowerPoint‑presentatie naar TIFF converteren. De gegenereerde TIFF‑afbeeldingen hebben dezelfde afmetingen als de standaard dia‑grootte.

Deze C++‑code laat zien hoe je een PowerPoint‑presentatie naar TIFF kunt converteren:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Maak een instantie van de Presentation‑klasse die een presentatie‑bestand (PPT, PPTX, ODP, enz.) voorstelt.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Sla de presentatie op als TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Presentatie converteren naar Zwart‑wit TIFF**

De methode [set_BwConversionMode](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) in de [TiffOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/)‑klasse stelt je in staat het algoritme te bepalen dat wordt gebruikt bij het omzetten van een gekleurde dia of afbeelding naar een zwart‑wit TIFF. Merk op dat deze instelling alleen van toepassing is wanneer de [set_CompressionType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/set_compressiontype/)‑methode is ingesteld op `CCITT4` of `CCITT3`.

{{% alert color="info" title="Opmerking" %}}
[TiffOptions::set_BwConversionMode](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) is een export‑niveau instelling die een pixel‑conversie‑algoritme selecteert voor de volledige TIFF‑afbeelding. Om te bepalen hoe een individuele vorm moet worden weergegeven wanneer de zwart‑wit weergavemodus actief is, gebruik je [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/set_blackwhitemode/). Zie [Control Black-and-White Rendering for Shapes](/slides/nl/cpp/shape-formatting/#control-black-and-white-rendering-for-shapes) voor voorbeelden.
{{% /alert %}}

Stel dat we een bestand "sample.pptx" hebben met de volgende dia:

![Een presentatiedia](slide_black_and_white.png)

Deze C++‑code laat zien hoe je de gekleurde dia kunt omzetten naar een zwart‑wit TIFF:

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

Het resultaat:

![Zwart‑wit TIFF](TIFF_black_and_white.png)

## **Presentatie converteren naar TIFF met aangepaste grootte**

Als je een TIFF‑afbeelding met specifieke afmetingen nodig hebt, kun je de gewenste waarden instellen via de methoden die beschikbaar zijn in [TiffOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/). Bijvoorbeeld, de [set_ImageSize](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/set_imagesize/)‑methode stelt je in staat de grootte van de resulterende afbeelding te definiëren.

Deze C++‑code laat zien hoe je een PowerPoint‑presentatie naar TIFF‑afbeeldingen met een aangepaste grootte kunt converteren:

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

// Maak een instantie van de Presentation‑klasse die een presentiebestand (PPT, PPTX, ODP, enz.) voorstelt.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Stel het compressietype in.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
Compressietypen:
    Default - Geeft het standaard compressieschema aan (LZW).
    None - Geeft geen compressie aan.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// De diepte hangt af van het compressietype en kan niet handmatig worden ingesteld.

// Stel de DPI van de afbeelding in.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// Stel de afbeeldingsgrootte in.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Sla de presentatie op als TIFF met de opgegeven grootte.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **Presentatie converteren naar TIFF met aangepast afbeeldings‑pixelformaat**

Met de [set_PixelFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/set_pixelformat/)‑methode van de [TiffOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/)‑klasse kun je het gewenste pixelformaat voor de resulterende TIFF‑afbeelding opgeven.

Deze C++‑code laat zien hoe je een PowerPoint‑presentatie naar een TIFF‑afbeelding met een aangepast pixelformaat kunt converteren:

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Maak een instantie van de Presentation‑klasse die een presentiebestand (PPT, PPTX, ODP, enz.) voorstelt.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat bevat de volgende waarden (zoals vermeld in de documentatie):
    Format1bppIndexed - 1 bit per pixel, geïndexeerd.
    Format4bppIndexed - 4 bits per pixel, geïndexeerd.
    Format8bppIndexed - 8 bits per pixel, geïndexeerd.
    Format24bppRgb    - 24 bits per pixel, RGB.
    Format32bppArgb   - 32 bits per pixel, ARGB.
*/

// Sla de presentatie op als TIFF met de opgegeven afbeeldingsgrootte.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Tip" color="info" %}}
Bekijk de [GRATIS PowerPoint‑naar‑Poster‑converter](https://products.aspose.app/slides/nl/conversion/convert-ppt-to-poster-online) van Aspose.
{{% /alert %}}

## **Veelgestelde vragen**

**Kan ik een individuele dia converteren in plaats van een volledige PowerPoint‑presentatie naar TIFF?**

Ja. Aspose.Slides stelt je in staat individuele dia's van PowerPoint‑ en OpenDocument‑presentaties afzonderlijk naar TIFF‑afbeeldingen te converteren.

**Is er een limiet aan het aantal dia's bij het converteren van een presentatie naar TIFF?**

Nee, Aspose.Slides legt geen beperkingen op aan het aantal dia's. Je kunt presentaties van elke omvang naar TIFF‑formaat converteren.

**Worden PowerPoint‑animaties en transitie‑effecten behouden bij het converteren van dia's naar TIFF?**

Nee, TIFF is een statisch afbeeldingsformaat. Daarom worden animaties en transitie‑effecten niet behouden; er wordt alleen een statische momentopname van de dia’s geëxporteerd.