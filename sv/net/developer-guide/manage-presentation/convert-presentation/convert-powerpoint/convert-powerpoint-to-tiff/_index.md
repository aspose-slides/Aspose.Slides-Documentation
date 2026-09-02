---
title: "Konvertera PowerPoint-presentationer till TIFF i .NET"
titlelink: "PowerPoint till TIFF"
type: docs
weight: 90
url: /sv/net/convert-powerpoint-to-tiff/
keywords:
- "konvertera PowerPoint"
- "konvertera OpenDocument"
- "konvertera presentation"
- "konvertera bildruta"
- "konvertera PPT"
- "konvertera PPTX"
- "PowerPoint till TIFF"
- "presentation till TIFF"
- "bildruta till TIFF"
- "PPT till TIFF"
- "PPTX till TIFF"
- "spara PPT som TIFF"
- "spara PPTX som TIFF"
- "exportera PPT till TIFF"
- "exportera PPTX till TIFF"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Lär dig hur du enkelt konverterar PowerPoint (PPT, PPTX)-presentationer till högkvalitativa TIFF-bilder med Aspose.Slides för .NET. C#-kodexempel."
---
## **Introduktion**

TIFF (**Tagged Image File Format**) är ett allmänt använt, förlustfritt rasterbildformat som är känt för sin enastående kvalitet och detaljerade bevarande av grafik. Formgivare, fotografer och bildredigerare väljer ofta TIFF för att behålla lager, färgprecision och ursprungliga inställningar i sina bilder.

Med Aspose.Slides kan du enkelt konvertera dina PowerPoint‑bilder (PPT, PPTX) och OpenDocument‑bilder (ODP) direkt till högkvalitativa TIFF‑bilder, vilket säkerställer att dina presentationer behåller maximal visuell trohet. 

## **Konvertera en presentation till TIFF**

Genom att använda [Spara](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/)‑metoden som tillhandahålls av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)-klassen kan du snabbt konvertera en hel PowerPoint‑presentation till TIFF. De resulterande TIFF‑bilderna motsvarar standardbildstorleken.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP etc.).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // Spara presentationen som TIFF.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **Konvertera en presentation till svartvitt TIFF**

Egenskapen [BwConversionMode](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/bwconversionmode/) i [TiffOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/)-klassen låter dig ange vilken algoritm som används när en färgad bild eller bildruta konverteras till en svartvit TIFF. Observera att denna inställning endast gäller när egenskapen [CompressionType](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/compressiontype/) är satt till `CCITT4` eller `CCITT3`.

{{% alert color="info" title="Obs" %}}
[TiffOptions.BwConversionMode](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/bwconversionmode/) är en export‑nivåinställning som väljer en pixel‑konverteringsalgoritm för hela TIFF‑bilden. För att definiera hur en enskild form ska visas när svartvitt läge är aktivt, använd [IShape.BlackWhiteMode](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/blackwhitemode/). Se [Styr svartvit rendering för former](/slides/sv/net/shape-formatting/#control-black-and-white-rendering-for-shapes) för exempel.
{{% /alert %}}

Låt oss säga att vi har filen "sample.pptx" med följande bildruta:

![En presentationsbild](slide_black_and_white.png)

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

Resultatet:

![Svartvit TIFF](TIFF_black_and_white.png)

## **Konvertera en presentation till TIFF med anpassad storlek**

Om du behöver en TIFF‑bild med specifika dimensioner kan du ange dina önskade värden med hjälp av egenskaperna som finns i [TiffOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/). Till exempel låter egenskapen [ImageSize](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/imagesize/) dig definiera storleken på den resulterande bilden.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP etc.).
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // Ställ in komprimeringstypen.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    Komprimeringstyper:
        Default - Anger standardkomprimeringsschemat (LZW).
        None - Anger ingen komprimering.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Djupet beror på komprimeringstypen och kan inte sättas manuellt.

    // Ställ in bildens DPI.
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // Ställ in bildstorleken.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // Spara presentationen som TIFF med angiven storlek.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **Konvertera en presentation till TIFF med anpassat bildpixelformat**

Genom att använda egenskapen [PixelFormat](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/pixelformat/) från [TiffOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions)-klassen kan du ange ditt föredragna pixelformat för den resulterande TIFF‑bilden.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP etc.).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat innehåller följande värden (enligt dokumentationen):
        Format1bppIndexed - 1 bit per pixel, indexerad.
        Format4bppIndexed - 4 bitar per pixel, indexerad.
        Format8bppIndexed - 8 bitar per pixel, indexerad.
        Format24bppRgb    - 24 bitar per pixel, RGB.
        Format32bppArgb   - 32 bitar per pixel, ARGB.
    */

    // Spara presentationen som TIFF med angiven bildstorlek.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tips" color="info" %}}
Ta en titt på Asposes [GRATIS PowerPoint till Poster‑konverterare](https://products.aspose.app/slides/sv/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Vanliga frågor**

**Kan jag konvertera en enskild bildruta istället för hela PowerPoint‑presentationen till TIFF?**

Ja. Aspose.Slides låter dig konvertera enskilda bildrutor från PowerPoint‑ och OpenDocument‑presentationer till TIFF‑bilder separat.

**Finns det någon begränsning för antalet bildrutor vid konvertering av en presentation till TIFF?**

Nej, Aspose.Slides pålägger inga begränsningar för antalet bildrutor. Du kan konvertera presentationer av vilken storlek som helst till TIFF‑format.

**Behålls PowerPoint‑animationer och övergångseffekter när bildrutor konverteras till TIFF?**

Nej, TIFF är ett statiskt bildformat. Därför bevaras inte animationer och övergångseffekter; endast stillbilder av bildrutorna exporteras.