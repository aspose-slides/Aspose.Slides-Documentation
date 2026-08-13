---
title: PowerPoint‑presentaties naar TIFF converteren in C++
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
description: "Leer hoe u eenvoudig PowerPoint‑presentaties (PPT, PPTX) kunt converteren naar hoogwaardige TIFF‑afbeeldingen met Aspose.Slides voor C++, inclusief code‑voorbeelden."
---
## **Inleiding**

TIFF (**Tagged Image File Format**) is een veelgebruikt, verliesvrij rasterafbeeldingsformaat dat bekend staat om zijn uitzonderlijke kwaliteit en de gedetailleerde bewaring van grafische elementen. Ontwerpers, fotografen en desktop‑uitgevers kiezen vaak voor TIFF om lagen, kleurnauwkeurigheid en oorspronkelijke instellingen in hun afbeeldingen te behouden.

Met Aspose.Slides kun je moeiteloos je PowerPoint‑dia’s (PPT, PPTX) en OpenDocument‑dia’s (ODP) rechtstreeks omzetten naar hoogwaardige TIFF‑afbeeldingen, zodat je presentaties de maximale visuele getrouwheid behouden.

## **Een presentatie naar TIFF converteren**

Met de [Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/)‑methode van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)-klasse kun je snel een volledige PowerPoint‑presentatie naar TIFF converteren. De resulterende TIFF‑afbeeldingen hebben de standaard dia‑grootte.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Maak een instantie van de Presentation-klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) voorstelt.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Sla de presentatie op als TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Een presentatie naar zwart‑wit TIFF converteren**

De methode [set_BwConversionMode](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) in de [TiffOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/)-klasse stelt je in staat het algoritme te specificeren dat wordt gebruikt bij het omzetten van een gekleurde dia of afbeelding naar een zwart‑wit TIFF. Merk op dat deze instelling alleen van toepassing is wanneer de [set_CompressionType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/set_compressiontype/)‑methode is ingesteld op `CCITT4` of `CCITT3`.

Stel dat we een bestand “sample.pptx” hebben met de volgende dia:

![Een presentatiedia](slide_black_and_white.png)

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

## **Een presentatie naar TIFF met aangepaste grootte converteren**

Als je een TIFF‑afbeelding met specifieke afmetingen nodig hebt, kun je de gewenste waarden instellen via de methoden die beschikbaar zijn in [TiffOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/). Bijvoorbeeld, de [set_ImageSize](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/set_imagesize/)‑methode stelt je in staat de grootte van de resulterende afbeelding te definiëren.

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

// Maak een instantie van de Presentation-klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) voorstelt.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Stel het compressietype in.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
Compressietypen:
    Default - Geeft het standaard compressieschema op (LZW).
    None - Geeft aan dat er geen compressie is.
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

## **Een presentatie naar TIFF met aangepast pixel‑formaat converteren**

Met de [set_PixelFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/set_pixelformat/)‑methode van de [TiffOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/)-klasse kun je het gewenste pixel‑formaat voor de resulterende TIFF‑afbeelding opgeven.

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instantieer de Presentation-klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) voorstelt.
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
Bekijk Aspose's [GRATIS PowerPoint‑naar‑Poster‑converter](https://products.aspose.app/slides/nl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

### Kan ik een individuele dia in plaats van een volledige PowerPoint‑presentatie naar TIFF converteren?

Ja. Aspose.Slides maakt het mogelijk om individuele dia’s uit PowerPoint‑ en OpenDocument‑presentaties afzonderlijk naar TIFF‑afbeeldingen te converteren.

### Is er een limiet aan het aantal dia’s bij het converteren van een presentatie naar TIFF?

Nee, Aspose.Slides legt geen beperkingen op aan het aantal dia’s. Je kunt presentaties van elke omvang naar TIFF‑formaat converteren.

### Worden PowerPoint‑animaties en overgangseffecten bewaard bij het converteren van dia’s naar TIFF?

Nee, TIFF is een statisch afbeeldingformaat. Daarom worden animaties en overgangseffecten niet bewaard; alleen statische momentopnamen van de dia’s worden geëxporteerd.