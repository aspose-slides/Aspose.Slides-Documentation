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
description: "Leer hoe u eenvoudig PowerPoint‑presentaties (PPT, PPTX) kunt omzetten naar hoogwaardige TIFF‑afbeeldingen met Aspose.Slides voor .NET. C#‑codevoorbeelden."
---
## **Inleiding**

TIFF (**Tagged Image File Format**) is een veelgebruikt, verliesvrij rasterafbeeldingsformaat dat bekend staat om zijn uitzonderlijke kwaliteit en gedetailleerde behoud van grafische elementen. Ontwerpers, fotografen en desktop‑publishers kiezen vaak TIFF om lagen, kleurnauwkeurigheid en originele instellingen in hun afbeeldingen te behouden.

Met Aspose.Slides kun je moeiteloos je PowerPoint‑slides (PPT, PPTX) en OpenDocument‑slides (ODP) direct omzetten naar hoogwaardige TIFF‑afbeeldingen, zodat je presentaties maximale visuele getrouwheid behouden.

## **Een presentatie naar TIFF converteren**

Met behulp van de [Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/)‑methode die wordt geleverd door de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse, kun je snel een volledige PowerPoint‑presentatie naar TIFF converteren. De resulterende TIFF‑afbeeldingen corresponderen met de standaarddia‑grootte.

Deze C#‑code toont hoe je een PowerPoint‑presentatie naar TIFF kunt converteren:

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

## **Een presentatie naar zwart‑wit‑TIFF converteren**

De eigenschap [BwConversionMode](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/bwconversionmode/) in de [TiffOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/)‑klasse stelt je in staat om het algoritme te specificeren dat wordt gebruikt bij het omzetten van een gekleurde dia of afbeelding naar een zwart‑wit‑TIFF. Merk op dat deze instelling alleen van toepassing is wanneer de eigenschap [CompressionType](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/compressiontype/) is ingesteld op `CCITT4` of `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions.BwConversionMode](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/bwconversionmode/) is een export‑niveau instelling die een pixel‑conversie‑algoritme selecteert voor de volledige TIFF‑afbeelding. Om te bepalen hoe een individuele vorm moet worden weergegeven wanneer de zwart‑wit‑weergavemodus actief is, gebruik je [IShape.BlackWhiteMode](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/blackwhitemode/). Bekijk [Control Black-and-White Rendering for Shapes](/slides/nl/net/shape-formatting/#control-black-and-white-rendering-for-shapes) voor voorbeelden.
{{% /alert %}}

Stel, we hebben een "sample.pptx"-bestand met de volgende dia:

![Een presentatiedia](slide_black_and_white.png)

Deze C#‑code toont hoe je de gekleurde dia naar een zwart‑wit‑TIFF kunt omzetten:

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

![Zwart‑wit‑TIFF](TIFF_black_and_white.png)

## **Een presentatie naar TIFF met aangepaste afmeting converteren**

Als je een TIFF‑afbeelding met specifieke afmetingen nodig hebt, kun je de gewenste waarden instellen via de eigenschappen die beschikbaar zijn in [TiffOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/). Bijvoorbeeld, de eigenschap [ImageSize](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/imagesize/) stelt je in staat de afmeting van de resulterende afbeelding te definiëren.

Deze C#‑code toont hoe je een PowerPoint‑presentatie naar TIFF‑afbeeldingen met een aangepaste afmeting kunt converteren:

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
        Default - Geeft het standaardcompressieschema (LZW) aan.
        None - Geeft aan dat er geen compressie wordt toegepast.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // De diepte hangt af van het compressietype en kan niet handmatig worden ingesteld.

    // Stel de afbeelding‑DPI in.
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

## **Een presentatie naar TIFF met aangepast afbeelding‑pixelformaat converteren**

Met de eigenschap [PixelFormat](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/pixelformat/) van de [TiffOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions)‑klasse kun je het gewenste pixelformaat voor de resulterende TIFF‑afbeelding opgeven.

Deze C#‑code toont hoe je een PowerPoint‑presentatie naar een TIFF‑afbeelding met een aangepast pixelformaat kunt omzetten:

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
Bekijk de GRATIS PowerPoint‑naar‑Poster‑converter van Aspose.
{{% /alert %}}

## **Veelgestelde vragen**

**Kan ik een individuele dia in plaats van de volledige PowerPoint‑presentatie naar TIFF converteren?**

Ja. Aspose.Slides stelt je in staat om individuele dia's van PowerPoint‑ en OpenDocument‑presentaties afzonderlijk naar TIFF‑afbeeldingen te converteren.

**Is er een limiet aan het aantal dia's bij het converteren van een presentatie naar TIFF?**

Nee, Aspose.Slides legt geen limiet op aan het aantal dia's. Je kunt presentaties van elke omvang naar TIFF‑formaat converteren.

**Worden PowerPoint‑animaties en overgangseffecten behouden bij het converteren van dia's naar TIFF?**

Nee, TIFF is een statisch afbeeldingsformaat. Animaties en overgangseffecten worden dus niet behouden; alleen statische momentopnames van dia's worden geëxporteerd.