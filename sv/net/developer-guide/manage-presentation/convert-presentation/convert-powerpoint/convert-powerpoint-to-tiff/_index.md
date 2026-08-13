---
title: Konvertera PowerPoint-presentationer till TIFF i .NET
titlelink: PowerPoint till TIFF
type: docs
weight: 90
url: /sv/net/convert-powerpoint-to-tiff/
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
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du enkelt konverterar PowerPoint (PPT, PPTX) presentationer till högkvalitativa TIFF-bilder med Aspose.Slides för .NET. C# kodexempel."
---
## **Introduktion**

TIFF (**Tagged Image File Format**) är ett allmänt använt, förlustfritt rasterbildformat som är känt för sin exceptionella kvalitet och detaljerade bevarande av grafik. Formgivare, fotografer och desktop‑utgivare väljer ofta TIFF för att bibehålla lager, färgnoggrannhet och ursprungliga inställningar i sina bilder.

Med Aspose.Slides kan du enkelt konvertera dina PowerPoint‑bilder (PPT, PPTX) och OpenDocument‑bilder (ODP) direkt till högkvalitativa TIFF‑bilder, vilket säkerställer att dina presentationer behåller maximal visuell trohet. 

## **Konvertera en presentation till TIFF**

Genom att använda metoden [Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/) som tillhandahålls av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) kan du snabbt konvertera en hel PowerPoint-presentation till TIFF. De resulterande TIFF‑bilderna motsvarar standardstorleken på bilden.

Denna C#‑kod demonstrerar hur du konverterar en PowerPoint-presentation till TIFF:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP, etc.).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // Spara presentationen som TIFF.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **Konvertera en presentation till svart‑vit TIFF**

Egenskapen [BwConversionMode](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/bwconversionmode/) i klassen [TiffOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/) låter dig ange vilken algoritm som ska användas när en färgad bild eller bildruta konverteras till en svart‑vit TIFF. Observera att denna inställning endast gäller när egenskapen [CompressionType](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/compressiontype/) är satt till `CCITT4` eller `CCITT3`.

Anta att vi har en fil "sample.pptx" med följande bildruta:

![En presentationsbild](slide_black_and_white.png)

Denna C#‑kod demonstrerar hur du konverterar den färgade bildrutan till en svart‑vit TIFF:

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

![Svart‑vit TIFF](TIFF_black_and_white.png)

## **Konvertera en presentation till TIFF med anpassad storlek**

Om du behöver en TIFF‑bild med specifika mått kan du ange önskade värden med hjälp av egenskaper som finns i [TiffOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/). Till exempel låter egenskapen [ImageSize](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/imagesize/) dig definiera storleken på den resulterande bilden.

Denna C#‑kod demonstrerar hur du konverterar en PowerPoint-presentation till TIFF‑bilder med en anpassad storlek:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP, etc.).
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // Ange komprimeringstypen.
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

    // Ange bildens DPI.
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // Ange bildstorleken.
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

Genom att använda egenskapen [PixelFormat](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/pixelformat/) från klassen [TiffOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions) kan du ange ditt föredragna pixelformat för den resulterande TIFF‑bilden.

Denna C#‑kod demonstrerar hur du konverterar en PowerPoint-presentation till en TIFF‑bild med ett anpassat pixelformat:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP, etc.).
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

{{% alert title="Tip" color="info" %}}
Kolla in Asposes [GRATIS PowerPoint till Poster‑konverterare](https://products.aspose.app/slides/sv/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Vanliga frågor**

### Kan jag konvertera en enskild bildruta istället för hela PowerPoint-presentationen till TIFF?

Ja. Aspose.Slides låter dig konvertera enskilda bildrutor från PowerPoint- och OpenDocument-presentationer till TIFF‑bilder separat.

### Finns det någon gräns för antalet bildrutor när man konverterar en presentation till TIFF?

Nej, Aspose.Slides har inga begränsningar för antalet bildrutor. Du kan konvertera presentationer av vilken storlek som helst till TIFF‑format.

### Bevaras PowerPoint‑animationer och övergångseffekter när man konverterar bildrutor till TIFF?

Nej, TIFF är ett statiskt bildformat. Därför bevaras inte animationer och övergångseffekter; endast statiska ögonblicksbilder av bildrutorna exporteras.