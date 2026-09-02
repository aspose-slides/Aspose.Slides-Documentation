---
title: Konvertera PowerPoint-presentationer till TIFF i C++
titlelink: PowerPoint till TIFF
type: docs
weight: 90
url: /sv/cpp/convert-powerpoint-to-tiff/
keywords:
- konvertera PowerPoint
- konvertera OpenDocument
- konvertera presentation
- konvertera bildruta
- konvertera PPT
- konvertera PPTX
- PowerPoint till TIFF
- presentation till TIFF
- bildruta till TIFF
- PPT till TIFF
- PPTX till TIFF
- spara PPT som TIFF
- spara PPTX som TIFF
- exportera PPT till TIFF
- exportera PPTX till TIFF
- C++
- Aspose.Slides
description: "Lär dig hur du enkelt konverterar PowerPoint (PPT, PPTX)-presentationer till högkvalitativa TIFF-bilder med Aspose.Slides för C++, med kodexempel."
---
## **Introduktion**

TIFF (**Tagged Image File Format**) är ett allmänt använt, förlustfritt rasterbildformat känt för sin enastående kvalitet och detaljerade bevarande av grafik. Designers, fotografer och desktop‑publishers väljer ofta TIFF för att behålla lager, färgprecision och originalinställningar i sina bilder.

Med Aspose.Slides kan du enkelt konvertera dina PowerPoint‑bilder (PPT, PPTX) och OpenDocument‑bilder (ODP) direkt till högkvalitativa TIFF‑filer, vilket säkerställer att dina presentationer behåller maximal visuell trohet.

## **Konvertera en presentation till TIFF**

Genom att använda metoden [Spara](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/) som tillhandahålls av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) kan du snabbt konvertera en hel PowerPoint‑presentation till TIFF. De resulterande TIFF‑bilderna motsvarar standardbildstorleken.

Denna C++‑kod visar hur du konverterar en PowerPoint‑presentation till TIFF:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Skapa en instans av Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP osv.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Spara presentationen som TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Konvertera en presentation till svart‑vit TIFF**

Metoden [set_BwConversionMode](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) i klassen [TiffOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/tiffoptions/) låter dig ange algoritmen som används när en färgad bild eller bildruta konverteras till en svart‑vit TIFF. Observera att denna inställning endast gäller när metoden [set_CompressionType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) är satt till `CCITT4` eller `CCITT3`.

{{% alert color="info" title="Obs" %}}
[TiffOptions::set_BwConversionMode](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) är en exportnivå‑inställning som väljer en pixel‑konverteringsalgoritm för hela TIFF‑bilden. För att definiera hur en enskild form ska visas när svart‑vit visningsläge är aktivt, använd [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/set_blackwhitemode/). Se [Control Black-and-White Rendering for Shapes](/slides/sv/cpp/shape-formatting/#control-black-and-white-rendering-for-shapes) för exempel.
{{% /alert %}}

Anta att vi har en fil named "sample.pptx" med följande bildruta:

![En presentationsbild](slide_black_and_white.png)

Denna C++‑kod visar hur du konverterar den färgade bildrutan till en svart‑vit TIFF:

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

Resultatet:

![Svart‑vit TIFF](TIFF_black_and_white.png)

## **Konvertera en presentation till TIFF med anpassad storlek**

Om du behöver en TIFF‑bild med specifika dimensioner kan du ange dina önskade värden med metoderna i [TiffOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/tiffoptions/). Till exempel låter metoden [set_ImageSize](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/tiffoptions/set_imagesize/) dig definiera storleken på den resulterande bilden.

Denna C++‑kod visar hur du konverterar en PowerPoint‑presentation till TIFF‑bilder med en anpassad storlek:

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

// Skapa en instans av Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP osv.).
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Ange komprimeringstypen.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
Komprimeringstyper:
    Default - Anger standards komprimeringsschema (LZW).
    None - Anger ingen kompression.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// Djupet beror på komprimeringstypen och kan inte sättas manuellt.

// Ange bildens DPI.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// Ange bildstorlek.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Spara presentationen som TIFF med angiven storlek.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **Konvertera en presentation till TIFF med anpassat bild‑pixel‑format**

Genom att använda metoden [set_PixelFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) från klassen [TiffOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/tiffoptions/) kan du ange önskat pixel‑format för den resulterande TIFF‑bilden.

Denna C++‑kod visar hur du konverterar en PowerPoint‑presentation till en TIFF‑bild med ett anpassat pixel‑format:

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Skapa en instans av Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP osv.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat innehåller följande värden (enligt dokumentationen):
    Format1bppIndexed - 1 bit per pixel, indexerat.
    Format4bppIndexed - 4 bitar per pixel, indexerat.
    Format8bppIndexed - 8 bitar per pixel, indexerat.
    Format24bppRgb    - 24 bitar per pixel, RGB.
    Format32bppArgb   - 32 bitar per pixel, ARGB.
*/

// Spara presentationen som TIFF med angiven bildstorlek.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Tips" color="info" %}}
Kolla in Asposes [GRATIS PowerPoint‑till‑poster‑konverterare](https://products.aspose.app/slides/sv/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Kan jag konvertera en enskild bildruta istället för hela PowerPoint‑presentationen till TIFF?**

Ja. Aspose.Slides låter dig konvertera enskilda bildrutor från PowerPoint‑ och OpenDocument‑presentationer till TIFF‑bilder separat.

**Finns det någon gräns för antalet bildrutor vid konvertering av en presentation till TIFF?**

Nej, Aspose.Slides har inga begränsningar för antalet bildrutor. Du kan konvertera presentationer av valfri storlek till TIFF‑format.

**Bevaras PowerPoint‑animationer och övergångseffekter när bildrutor konverteras till TIFF?**

Nej, TIFF är ett statiskt bildformat. Därför bevaras inte animationer eller övergångseffekter; endast statiska ögonblicksbilder av bildrutorna exporteras.