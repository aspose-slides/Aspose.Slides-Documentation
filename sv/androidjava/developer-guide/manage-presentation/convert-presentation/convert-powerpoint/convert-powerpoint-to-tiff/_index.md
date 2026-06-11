---
title: Konvertera PowerPoint-presentationer till TIFF på Android
titlelink: PowerPoint till TIFF
type: docs
weight: 90
url: /sv/androidjava/convert-powerpoint-to-tiff/
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
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du enkelt kan konvertera PowerPoint (PPT, PPTX)-presentationer till högkvalitativa TIFF-bilder med Aspose.Slides för Android, med Java-kodexempel."
---
## **Introduktion**

TIFF (**Tagged Image File Format**) är ett allmänt använt, förlustfritt rasterbildformat känt för sin exceptionella kvalitet och detaljerade bevarande av grafik. Designers, fotografer och desktoputgivare väljer ofta TIFF för att behålla lager, färgnoggrannhet och ursprungliga inställningar i sina bilder.

Med Aspose.Slides kan du enkelt konvertera dina PowerPoint‑bilder (PPT, PPTX) och OpenDocument‑bilder (ODP) direkt till högkvalitativa TIFF‑bilder, vilket säkerställer att dina presentationer behåller maximal visuell trohet. 

## **Konvertera en presentation till TIFF**

Genom att använda metoden [save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) som tillhandahålls av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) kan du snabbt konvertera en hel PowerPoint‑presentation till TIFF. De resulterande TIFF‑bilderna motsvarar standardstorleken på bilden.

Denna kod visar hur du konverterar en PowerPoint‑presentation till TIFF:

```java
// Instansiera Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP, etc.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    // Spara presentationen som TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Konvertera en presentation till svart‑vit TIFF**

Metoden [setBwConversionMode](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) i klassen [TiffOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tiffoptions/) låter dig specificera algoritmen som används när en färgad bild eller bild konverteras till en svart‑vit TIFF. Observera att denna inställning endast gäller när metoden [setCompressionType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) är satt till `CCITT4` eller `CCITT3`.

Låt oss säga att vi har en "sample.pptx"-fil med följande bild:

![En presentationsbild](slide_black_and_white.png)

Denna kod visar hur du konverterar den färgade bilden till en svart‑vit TIFF:

```java
TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setCompressionType(TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(BlackWhiteConversionMode.Dithering);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Svart‑vit TIFF](TIFF_black_and_white.png)

## **Konvertera en presentation till TIFF med anpassad storlek**

Om du behöver en TIFF‑bild med specifika dimensioner kan du ange önskade värden med metoderna i [TiffOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tiffoptions/). Till exempel låter metoden [setImageSize](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) dig definiera storleken på den resulterande bilden.

Denna kod visar hur du konverterar en PowerPoint‑presentation till TIFF‑bilder med anpassad storlek:

```java
// Instansiera Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP, etc.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // Ange komprimeringstypen.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    Komprimeringstyper:
        Default - Anger standardkomprimeringsschemat (LZW).
        None - Anger ingen komprimering.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Djupet beror på komprimeringstypen och kan inte ställas in manuellt.

    // Ange bildens DPI.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Ange bildstorlek.
    tiffOptions.setImageSize(new Size(1728, 1078));

    INotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Spara presentationen som TIFF med den angivna storleken.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **Konvertera en presentation till TIFF med anpassat bildpixelformat**

Genom att använda metoden [setPixelFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) från klassen [TiffOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tiffoptions/) kan du specificera önskat pixelformat för den resulterande TIFF‑bilden.

Denna kod visar hur du konverterar en PowerPoint‑presentation till en TIFF‑bild med anpassat pixelformat:

```java
// Instansiera Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP, etc.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat innehåller följande värden (enligt dokumentationen):
        Format1bppIndexed - 1 bit per pixel, indexerad.
        Format4bppIndexed - 4 bit per pixel, indexerad.
        Format8bppIndexed - 8 bit per pixel, indexerad.
        Format24bppRgb    - 24 bit per pixel, RGB.
        Format32bppArgb   - 32 bit per pixel, ARGB.
    */
    
    // Spara presentationen som TIFF med den angivna bildstorleken.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Kolla in Asposes [GRATIS PowerPoint‑till‑Poster‑konverterare](https://products.aspose.app/slides/sv/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Kan jag konvertera en enskild bild istället för hela PowerPoint‑presentationen till TIFF?**

Ja. Aspose.Slides låter dig konvertera enskilda bilder från PowerPoint‑ och OpenDocument‑presentationer till TIFF‑bilder separat.

**Finns det någon begränsning på antalet bilder när du konverterar en presentation till TIFF?**

Nej, Aspose.Slides har inga begränsningar för antalet bilder. Du kan konvertera presentationer av vilken storlek som helst till TIFF‑format.

**Bevaras PowerPoint‑animationer och övergångseffekter när man konverterar bilder till TIFF?**

Nej, TIFF är ett statiskt bildformat. Därför bevaras inte animationer och övergångseffekter; endast statiska ögonblicksbilder av bilder exporteras.