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
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till TIFF
- presentation till TIFF
- bild till TIFF
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

TIFF (**Tagged Image File Format**) är ett allmänt använt, förlustfritt rasterbildformat känt för sin exceptionella kvalitet och detaljerade bevarande av grafik. Designers, fotografer och desktop‑utgivare väljer ofta TIFF för att behålla lager, färgprecision och ursprungliga inställningar i sina bilder.

Med Aspose.Slides kan du enkelt konvertera dina PowerPoint‑bilder (PPT, PPTX) och OpenDocument‑bilder (ODP) direkt till högkvalitativa TIFF‑bilder, vilket säkerställer att dina presentationer behåller maximal visuell trohet.

## **Konvertera en presentation till TIFF**

Genom att använda [Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/)‑metoden som tillhandahålls av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)-klassen kan du snabbt konvertera en hel PowerPoint‑presentation till TIFF. De resulterande TIFF‑bilderna motsvarar standardbildstorleken.

Denna C++‑kod demonstrerar hur du konverterar en PowerPoint‑presentation till TIFF:

```cpp
// Instansiera Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP, etc.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Spara presentationen som TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Konvertera en presentation till svart‑vit TIFF**

Metoden [set_BwConversionMode](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) i [TiffOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/tiffoptions/)-klassen låter dig ange algoritmen som används när du konverterar en färgad bild eller bild till en svart‑vit TIFF. Observera att denna inställning endast gäller när [set_CompressionType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/tiffoptions/set_compressiontype/)‑metoden är satt till `CCITT4` eller `CCITT3`.

Låt säga att vi har en fil "sample.pptx" med följande bild:

![En presentationsbild](slide_black_and_white.png)

Denna C++‑kod demonstrerar hur du konverterar den färgade bilden till en svart‑vit TIFF:

```cpp
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

Om du behöver en TIFF‑bild med specifika dimensioner kan du ange dina önskade värden med hjälp av metoder som finns i [TiffOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/tiffoptions/). Till exempel låter [set_ImageSize](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/tiffoptions/set_imagesize/)‑metoden dig definiera storleken på den resulterande bilden.

Denna C++‑kod demonstrerar hur du konverterar en PowerPoint‑presentation till TIFF‑bilder med anpassad storlek:

```cpp
// Instansiera Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP, etc.).
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Ange komprimeringstyp.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
Komprimeringstyper:
    Default - Anger standard komprimeringsschema (LZW).
    None - Anger ingen komprimering.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// Djupet beror på komprimeringstypen och kan inte ställas in manuellt.

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

## **Konvertera en presentation till TIFF med anpassat bildpixelformat**

Genom att använda [set_PixelFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/tiffoptions/set_pixelformat/)‑metoden från [TiffOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/tiffoptions/)-klassen kan du ange ditt föredragna pixelformat för den resulterande TIFF‑bilden.

Denna C++‑kod demonstrerar hur du konverterar en PowerPoint‑presentation till en TIFF‑bild med anpassat pixelformat:

```cpp
// Instansiera Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP, etc.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat innehåller följande värden (enligt dokumentationen):
    Format1bppIndexed - 1 bit per pixel, indexerad.
    Format4bppIndexed - 4 bitar per pixel, indexerad.
    Format8bppIndexed - 8 bitar per pixel, indexerad.
    Format24bppRgb    - 24 bitar per pixel, RGB.
    Format32bppArgb   - 32 bitar per pixel, ARGB.
*/

// Spara presentationen som TIFF med angiven bildstorlek.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Tips" color="primary" %}}
Kolla in Asposes [GRATIS PowerPoint till Poster‑konverterare](https://products.aspose.app/slides/sv/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Vanliga frågor**

**Kan jag konvertera en enskild bild istället för hela PowerPoint‑presentationen till TIFF?**

Ja. Aspose.Slides låter dig konvertera enskilda bilder från PowerPoint‑ och OpenDocument‑presentationer till TIFF‑bilder separat.

**Finns det någon gräns för antalet bilder när du konverterar en presentation till TIFF?**

Nej, Aspose.Slides har inga begränsningar för antalet bilder. Du kan konvertera presentationer av vilken storlek som helst till TIFF‑format.

**Bevaras PowerPoint‑animationer och övergångseffekter när du konverterar bilder till TIFF?**

Nej, TIFF är ett statiskt bildformat. Därför bevaras inte animationer och övergångseffekter; endast stillbilder av bilder exporteras.