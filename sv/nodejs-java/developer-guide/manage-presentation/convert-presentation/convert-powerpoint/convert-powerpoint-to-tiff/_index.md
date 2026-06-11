---
title: Konvertera PowerPoint-presentationer till TIFF i JavaScript
titlelink: PowerPoint till TIFF
type: docs
weight: 90
url: /sv/nodejs-java/convert-powerpoint-to-tiff/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du enkelt konverterar PowerPoint (PPT, PPTX) presentationer till högkvalitativa TIFF-bilder med Aspose.Slides för Node.js, med JavaScript-kodexempel."
---
## **Introduktion**

TIFF (**Tagged Image File Format**) är ett allmänt använt, förlustfritt rasterbildformat som är känt för sin exceptionella kvalitet och detaljerade bevarande av grafik. Formgivare, fotografer och desktop‑publicister väljer ofta TIFF för att behålla lager, färgnoggrannhet och ursprungliga inställningar i sina bilder.

Med Aspose.Slides kan du enkelt konvertera dina PowerPoint‑bilder (PPT, PPTX) och OpenDocument‑bilder (ODP) direkt till högkvalitativa TIFF‑bilder, vilket säkerställer att dina presentationer behåller maximal visuell trohet.

## **Konvertera en presentation till TIFF**

Genom att använda metoden [save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) som tillhandahålls av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) kan du snabbt konvertera en hel PowerPoint‑presentation till TIFF. De resulterande TIFF‑bilderna motsvarar standardbildstorleken.

Denna JavaScript‑kod demonstrerar hur man konverterar en PowerPoint‑presentation till TIFF:

```js
// Instansiera Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP, etc.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // Spara presentationen som TIFF.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Konvertera en presentation till svartvitt TIFF**

Metoden [setBwConversionMode](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) i klassen [TiffOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tiffoptions/) låter dig specificera algoritmen som används när en färgad bild eller bildruta konverteras till ett svartvitt TIFF. Observera att denna inställning endast gäller när metoden [setCompressionType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) är satt till `CCITT4` eller `CCITT3`.

Låt oss säga att vi har en fil "sample.pptx" med följande bildruta:

![En presentationsbild](slide_black_and_white.png)

Denna JavaScript‑kod demonstrerar hur man konverterar den färgade bildrutan till ett svartvitt TIFF:

```js
let tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(aspose.slides.BlackWhiteConversionMode.Dithering);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Svartvitt TIFF](TIFF_black_and_white.png)

## **Konvertera en presentation till TIFF med anpassad storlek**

Om du behöver en TIFF‑bild med specifika dimensioner kan du ange önskade värden med metoder som finns i [TiffOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tiffoptions/). Till exempel låter metoden [setImageSize](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tiffoptions/#setImageSize) dig definiera storleken på den resulterande bilden.

Denna JavaScript‑kod demonstrerar hur man konverterar en PowerPoint‑presentation till TIFF‑bilder med anpassad storlek:

```js
// Instansiera Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP, etc.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // Ange komprimeringstypen.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
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
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Ange bildstorleken.
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Spara presentationen som TIFF med angiven storlek.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **Konvertera en presentation till TIFF med anpassat bildpixelformat**

Genom att använda metoden [setPixelFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) från klassen [TiffOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tiffoptions/) kan du ange ditt föredragna pixelformat för den resulterande TIFF‑bilden.

Denna JavaScript‑kod demonstrerar hur man konverterar en PowerPoint‑presentation till en TIFF‑bild med anpassat pixelformat:

```js
// Instansiera Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP, etc.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat innehåller följande värden (enligt dokumentationen):
        Format1bppIndexed - 1 bit per pixel, indexerad.
        Format4bppIndexed - 4 bitar per pixel, indexerad.
        Format8bppIndexed - 8 bitar per pixel, indexerad.
        Format24bppRgb    - 24 bitar per pixel, RGB.
        Format32bppArgb   - 32 bitar per pixel, ARGB.
    */

    /// Spara presentationen som TIFF med angiven bildstorlek.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Kolla in Asposes [GRATIS PowerPoint till Poster‑konverterare](https://products.aspose.app/slides/sv/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Vanliga frågor**

**Kan jag konvertera en enskild bildruta istället för hela PowerPoint‑presentationen till TIFF?**

Ja. Aspose.Slides låter dig konvertera enskilda bildrutor från PowerPoint‑ och OpenDocument‑presentationer till TIFF‑bilder separat.

**Finns det någon gräns för antalet bildrutor när man konverterar en presentation till TIFF?**

Nej, Aspose.Slides pålägger inga begränsningar på antalet bildrutor. Du kan konvertera presentationer av vilken storlek som helst till TIFF‑format.

**Bevaras PowerPoint‑animationer och övergångseffekter när man konverterar bildrutor till TIFF?**

Nej, TIFF är ett statiskt bildformat. Därför bevaras inte animationer och övergångseffekter; endast statiska ögonblicksbilder av bildrutorna exporteras.