---
title: PowerPoint-presentaties converteren naar TIFF in .NET
titlelink: PowerPoint naar TIFF
type: docs
weight: 90
url: /nl/net/convert-powerpoint-to-tiff/
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
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u eenvoudig PowerPoint‑presentaties (PPT, PPTX) naar hoogwaardige TIFF‑afbeeldingen kunt converteren met Aspose.Slides voor .NET. C#‑codevoorbeelden."
---
## **Inleiding**

TIFF (**Tagged Image File Format**) is een veelgebruikt, verliesvrij rasterafbeeldingsformaat dat bekend staat om zijn uitzonderlijke kwaliteit en gedetailleerde behoud van grafische inhoud. Ontwerpers, fotografen en desktop‑uitgevers kiezen vaak voor TIFF om lagen, kleurnauwkeurigheid en de oorspronkelijke instellingen in hun afbeeldingen te behouden.

Met Aspose.Slides kunt u moeiteloos uw PowerPoint‑dia’s (PPT, PPTX) en OpenDocument‑dia’s (ODP) rechtstreeks omzetten naar hoogwaardige TIFF‑afbeeldingen, zodat uw presentaties de maximale visuele nauwkeurigheid behouden.

## **Een presentatie converteren naar TIFF**

Met de [Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/)‑methode die wordt geleverd door de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse, kunt u snel een volledige PowerPoint‑presentatie omzetten naar TIFF. De gegenereerde TIFF‑afbeeldingen hebben de standaard dia‑grootte.

Deze C#‑code laat zien hoe u een PowerPoint‑presentatie omzet naar TIFF:

```cs
// Maak een instantie van de Presentation‑klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // Sla de presentatie op als TIFF.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **Een presentatie converteren naar zwart‑wit TIFF**

De eigenschap [BwConversionMode](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/bwconversionmode/) in de klasse [TiffOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/) stelt u in staat om het algoritme te specificeren dat wordt gebruikt bij het omzetten van een gekleurde dia of afbeelding naar een zwart‑wit TIFF. Let op dat deze instelling alleen van toepassing is wanneer de eigenschap [CompressionType](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/compressiontype/) is ingesteld op `CCITT4` of `CCITT3`.

Laten we aannemen dat we een bestand "sample.pptx" hebben met de volgende dia:

![Een presentatiedia](slide_black_and_white.png)

Deze C#‑code laat zien hoe u de gekleurde dia omzet naar een zwart‑wit TIFF:

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

Het resultaat:

![Zwart‑wit TIFF](TIFF_black_and_white.png)

## **Een presentatie converteren naar TIFF met aangepaste grootte**

Als u een TIFF‑afbeelding met specifieke afmetingen nodig heeft, kunt u de gewenste waarden instellen via de eigenschappen die beschikbaar zijn in [TiffOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/). Bijvoorbeeld, de eigenschap [ImageSize](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/imagesize/) stelt u in staat de grootte van de resulterende afbeelding te definiëren.

Deze C#‑code laat zien hoe u een PowerPoint‑presentatie omzet naar TIFF‑afbeeldingen met een aangepaste grootte:

```cs
// Maak een instantie van de Presentation‑klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // Stel het compressietype in.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    Compressietypen:
        Default - Geeft het standaard compressieschema (LZW) aan.
        None - Geeft aan dat er geen compressie is.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // De diepte hangt af van het compressietype en kan niet handmatig worden ingesteld.

    // Stel de DPI van de afbeelding in.
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // Stel de afbeeldingsgrootte in.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // Sla de presentatie op als TIFF met de opgegeven grootte.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **Een presentatie converteren naar TIFF met aangepast pixelformaat**

Met de eigenschap [PixelFormat](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/pixelformat/) van de klasse [TiffOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions) kunt u het gewenste pixelformaat voor de resulterende TIFF‑afbeelding opgeven.

Deze C#‑code laat zien hoe u een PowerPoint‑presentatie omzet naar een TIFF‑afbeelding met een aangepast pixelformaat:

```cs
// Maak een instantie van de Presentation‑klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat bevat de volgende waarden (zoals vermeld in de documentatie):
        Format1bppIndexed - 1 bit per pixel, geïndexeerd.
        Format4bppIndexed - 4 bits per pixel, geïndexeerd.
        Format8bppIndexed - 8 bits per pixel, geïndexeerd.
        Format24bppRgb    - 24 bits per pixel, RGB.
        Format32bppArgb   - 32 bits per pixel, ARGB.
    */

    // Sla de presentatie op als TIFF met de opgegeven afbeeldingsgrootte.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tip" color="primary" %}}
Bekijk de [GRATIS PowerPoint‑naar‑poster converter](https://products.aspose.app/slides/nl/conversion/convert-ppt-to-poster-online) van Aspose.
{{% /alert %}}

## **Veelgestelde vragen**

**Kan ik een individuele dia converteren in plaats van de volledige PowerPoint‑presentatie naar TIFF?**

Ja. Aspose.Slides maakt het mogelijk om afzonderlijke dia's uit PowerPoint‑ en OpenDocument‑presentaties om te zetten naar TIFF‑afbeeldingen.

**Is er een limiet aan het aantal dia's bij het converteren van een presentatie naar TIFF?**

Nee, Aspose.Slides legt geen beperkingen op aan het aantal dia's. U kunt presentaties van elke grootte omzetten naar het TIFF‑formaat.

**Worden PowerPoint‑animaties en overgangseffecten bewaard bij het converteren van dia's naar TIFF?**

Nee, TIFF is een statisch afbeeldingsformaat. Daarom worden animaties en overgangseffecten niet bewaard; alleen statische momentopnames van de dia's worden geëxporteerd.