---
title: PowerPoint-presentaties omzetten naar TIFF in C++
titlelink: PowerPoint naar TIFF
type: docs
weight: 90
url: /nl/cpp/convert-powerpoint-to-tiff/
keywords:
- PowerPoint omzetten
- OpenDocument omzetten
- presentatie omzetten
- dia omzetten
- PPT omzetten
- PPTX omzetten
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
description: "Leer hoe u eenvoudig PowerPoint (PPT, PPTX) presentaties kunt omzetten naar hoogwaardige TIFF-afbeeldingen met Aspose.Slides voor C++, inclusief code-voorbeelden."
---
## **Inleiding**

TIFF (**Tagged Image File Format**) is een veelgebruikt, verliesvrij rasterafbeeldingsformaat dat bekend staat om zijn uitzonderlijke kwaliteit en gedetailleerde behoud van graphics. Ontwerpers, fotografen en desktopuitgevers kiezen vaak voor TIFF om lagen, kleurnauwkeurigheid en oorspronkelijke instellingen in hun afbeeldingen te behouden.

Met Aspose.Slides kunt u moeiteloos uw PowerPoint-dia’s (PPT, PPTX) en OpenDocument-dia’s (ODP) rechtstreeks omzetten naar hoogwaardige TIFF-afbeeldingen, zodat uw presentaties de maximale visuele getrouwheid behouden.

## **Een presentatie omzetten naar TIFF**

Met de [Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/)-methode van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)-klasse kunt u snel een volledige PowerPoint-presentatie naar TIFF omzetten. De resulterende TIFF-afbeeldingen komen overeen met de standaarddia-grootte.

Deze C++‑code toont hoe u een PowerPoint‑presentatie naar TIFF kunt converteren:

```cpp
// Instantieer de Presentation-klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Sla de presentatie op als TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Een presentatie omzetten naar zwart-wit TIFF**

De methode [set_BwConversionMode](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) in de [TiffOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/)-klasse stelt u in staat het algoritme te specificeren dat wordt gebruikt bij het converteren van een gekleurde dia of afbeelding naar een zwart-wit TIFF. Let op dat deze instelling alleen van toepassing is wanneer de [set_CompressionType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/set_compressiontype/)-methode is ingesteld op `CCITT4` of `CCITT3`.

Stel dat we een bestand "sample.pptx" hebben met de volgende dia:

![Een presentatiedia](slide_black_and_white.png)

Deze C++‑code toont hoe u de gekleurde dia naar een zwart-wit TIFF kunt converteren:

```cpp
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Het resultaat:

![Zwart-wit TIFF](TIFF_black_and_white.png)

## **Een presentatie omzetten naar TIFF met aangepaste grootte**

Als u een TIFF-afbeelding met specifieke afmetingen nodig heeft, kunt u uw gewenste waarden instellen met behulp van de methoden die beschikbaar zijn in [TiffOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/). De [set_ImageSize](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/set_imagesize/)-methode bijvoorbeeld stelt u in staat de grootte van de resulterende afbeelding te definiëren.

Deze C++‑code toont hoe u een PowerPoint‑presentatie naar TIFF‑afbeeldingen met een aangepaste grootte kunt omzetten:

```cpp
// Instantieer de Presentation-klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
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

## **Een presentatie omzetten naar TIFF met aangepast pixelformaat**

Met de [set_PixelFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/set_pixelformat/)-methode van de [TiffOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/)-klasse kunt u het gewenste pixelformaat voor de resulterende TIFF-afbeelding opgeven.

Deze C++‑code toont hoe u een PowerPoint‑presentatie naar een TIFF‑afbeelding met een aangepast pixelformaat kunt converteren:

```cpp
// Instantieer de Presentation-klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
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

{{% alert title="Tip" color="primary" %}}
Bekijk de [GRATIS PowerPoint-naar-poster-converter](https://products.aspose.app/slides/nl/conversion/convert-ppt-to-poster-online) van Aspose.
{{% /alert %}}

## **Veelgestelde vragen**

**Kan ik een individuele dia in plaats van een volledige PowerPoint-presentatie naar TIFF converteren?**

Ja. Aspose.Slides stelt u in staat individuele dia’s uit PowerPoint- en OpenDocument-presentaties afzonderlijk naar TIFF-afbeeldingen te converteren.

**Is er een limiet aan het aantal dia’s bij het converteren van een presentatie naar TIFF?**

Nee, Aspose.Slides legt geen beperkingen op aan het aantal dia’s. U kunt presentaties van elke omvang naar het TIFF-formaat converteren.

**Worden PowerPoint-animaties en overgangseffecten behouden bij het converteren van dia’s naar TIFF?**

Nee, TIFF is een statisch afbeeldingsformaat. Daarom worden animaties en overgangseffecten niet behouden; alleen statische momentopnamen van de dia’s worden geëxporteerd.