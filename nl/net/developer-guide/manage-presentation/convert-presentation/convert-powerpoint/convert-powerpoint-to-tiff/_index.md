---
title: PowerPoint-presentaties naar TIFF converteren in .NET
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
description: "Leer hoe u eenvoudig PowerPoint (PPT, PPTX) presentaties naar hoogwaardige TIFF‑afbeeldingen kunt converteren met Aspose.Slides voor .NET. C#‑codevoorbeelden."
---
## **Introductie**

TIFF (**Tagged Image File Format**) is een veelgebruikt, verliesvrij rasterafbeeldingsformaat dat bekend staat om zijn uitzonderlijke kwaliteit en gedetailleerde behoud van grafische elementen. Ontwerpers, fotografen en desktop‑uitgevers kiezen vaak TIFF om lagen, kleurnauwkeurigheid en originele instellingen in hun afbeeldingen te behouden.

Met Aspose.Slides kunt u moeiteloos uw PowerPoint‑dia's (PPT, PPTX) en OpenDocument‑dia's (ODP) rechtstreeks omzetten naar hoogwaardige TIFF‑afbeeldingen, zodat uw presentaties maximale visuele getrouwheid behouden. 

## **Een presentatie converteren naar TIFF**

Met de [Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/)‑methode die wordt geleverd door de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse, kunt u snel een volledige PowerPoint‑presentatie naar TIFF converteren. De resulterende TIFF‑afbeeldingen komen overeen met de standaarddia‑grootte.

Deze C#‑code toont hoe u een PowerPoint‑presentatie naar TIFF converteert:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer de Presentation‑klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // Sla de presentatie op als TIFF.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **Een presentatie converteren naar zwart-wit TIFF**

De eigenschap [BwConversionMode](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/bwconversionmode/) in de [TiffOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/)‑klasse stelt u in staat het algoritme op te geven dat wordt gebruikt bij het converteren van een gekleurde dia of afbeelding naar een zwart-wit TIFF. Merk op dat deze instelling alleen van toepassing is wanneer de eigenschap [CompressionType](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/compressiontype/) is ingesteld op `CCITT4` of `CCITT3`.

{{% alert color="info" title="Opmerking" %}}
[TiffOptions.BwConversionMode](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/bwconversionmode/) is een export‑niveau instelling die een pixel‑conversie‑algoritme selecteert voor de volledige TIFF‑afbeelding. Om te definiëren hoe een individueel vormelement moet verschijnen wanneer de zwart‑wit weergavemodus actief is, gebruikt u [IShape.BlackWhiteMode](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/blackwhitemode/). Zie [Control Black-and-White Rendering for Shapes](/net/shape-formatting/#control-black-and-white-rendering-for-shapes) voor voorbeelden.
{{% /alert %}}

Stel dat we een bestand "sample.pptx" hebben met de volgende dia:

![Een presentatiedia](slide_black_and_white.png)

Deze C#‑code toont hoe u de gekleurde dia naar een zwart‑wit TIFF converteert:

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

Het resultaat:

![Zwart‑wit TIFF](TIFF_black_and_white.png)

## **Een presentatie converteren naar TIFF met aangepaste grootte**

Als u een TIFF‑afbeelding met specifieke afmetingen nodig heeft, kunt u de gewenste waarden instellen via de eigenschappen die beschikbaar zijn in [TiffOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/). Bijvoorbeeld, de eigenschap [ImageSize](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/imagesize/) stelt u in staat de grootte van de resulterende afbeelding te definiëren.

Deze C#‑code toont hoe u een PowerPoint‑presentatie naar TIFF‑afbeeldingen met een aangepaste grootte converteert:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer de Presentation‑klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // Stel het compressietype in.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    Compressietypen:
        Default - Geeft het standaard compressieschema (LZW) aan.
        None - Geeft aan dat er geen compressie wordt toegepast.
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

## **Een presentatie converteren naar TIFF met aangepast pixel‑formaat**

Met de eigenschap [PixelFormat](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/pixelformat/) van de [TiffOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions)‑klasse kunt u het gewenste pixel‑formaat voor de resulterende TIFF‑afbeelding opgeven.

Deze C#‑code toont hoe u een PowerPoint‑presentatie naar een TIFF‑afbeelding met een aangepast pixel‑formaat converteert:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer de Presentation‑klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
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

{{% alert title="Tip" color="info" %}}
Bekijk Aspose's [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/nl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Kan ik een enkele dia in plaats van de volledige PowerPoint‑presentatie naar TIFF converteren?**

Ja. Aspose.Slides stelt u in staat afzonderlijke dia's uit PowerPoint‑ en OpenDocument‑presentaties afzonderlijk naar TIFF‑afbeeldingen te converteren.

**Is er een limiet aan het aantal dia's bij het converteren van een presentatie naar TIFF?**

Nee, Aspose.Slides legt geen beperkingen op aan het aantal dia's. U kunt presentaties van elke grootte naar TIFF‑formaat converteren.

**Worden PowerPoint‑animaties en overgangseffecten behouden bij het converteren van dia's naar TIFF?**

Nee, TIFF is een statisch afbeeldingsformaat. Daarom worden animaties en overgangseffecten niet behouden; alleen statische snapshots van dia's worden geëxporteerd.