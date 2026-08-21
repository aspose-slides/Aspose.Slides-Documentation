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
description: "Lär dig hur du enkelt konverterar PowerPoint-presentationer (PPT, PPTX) till högkvalitativa TIFF-bilder med Aspose.Slides för Android, med Java-kodexempel."
---
## **Introduktion**

TIFF (**Tagged Image File Format**) är ett allmänt använt, förlustfritt rasterbildformat som är känt för sin exceptionella kvalitet och detaljerade bevarande av grafik. Designers, fotografer och desktoppublicister väljer ofta TIFF för att behålla lager, färgprecision och ursprungliga inställningar i sina bilder.

Med Aspose.Slides kan du enkelt konvertera dina PowerPoint-bilder (PPT, PPTX) och OpenDocument-bilder (ODP) direkt till högkvalitativa TIFF-bilder, vilket säkerställer att dina presentationer behåller maximal visuell trohet.

## **Konvertera en presentation till TIFF**

Med metoden [save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) som tillhandahålls av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) kan du snabbt konvertera en hel PowerPoint-presentation till TIFF. De resulterande TIFF-bilderna motsvarar standardbildstorleken.

```java
import com.aspose.slides.*;

// Instansiera Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP, etc.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    // Spara presentationen som TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Konvertera en presentation till svartvitt TIFF**

Metoden [setBwConversionMode](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) i klassen [TiffOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tiffoptions/) låter dig ange vilken algoritm som ska användas när en färgad bild eller bild omvandlas till ett svartvitt TIFF. Observera att denna inställning endast gäller när metoden [setCompressionType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) är satt till `CCITT4` eller `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) är en exportnivåinställning som väljer en pixel‑konverteringsalgoritm för hela TIFF‑bilden. För att definiera hur en enskild form ska visas när svartvit visningsläge är aktivt, använd [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-). Se [Control Black-and-White Rendering for Shapes](/androidjava/shape-formatting/#control-black-and-white-rendering-for-shapes) för exempel.
{{% /alert %}}

Anta att vi har en "sample.pptx"-fil med följande bild:

![En presentationsbild](slide_black_and_white.png)

```java
import com.aspose.slides.*;

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

![Svartvitt TIFF](TIFF_black_and_white.png)

## **Konvertera en presentation till TIFF med anpassad storlek**

Om du behöver en TIFF‑bild med specifika dimensioner kan du ange dina önskade värden med metoder som finns i [TiffOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tiffoptions/). Till exempel låter metoden [setImageSize](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) dig definiera storleken på den resulterande bilden.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

// Instansiera Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP, etc.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // Ange komprimeringstypen.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    Komprimeringstyper:
        Default - Anger standards komprimeringsschema (LZW).
        None - Anger ingen komprimering.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Djupet beror på komprimeringstypen och kan inte ställas in manuellt.

    // Ställ in bildens DPI.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Ställ in bildstorlek.
    tiffOptions.setImageSize(new Size(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Spara presentationen som TIFF med den angivna storleken.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **Konvertera en presentation till TIFF med anpassat bildpixelformat**

Genom att använda metoden [setPixelFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) i klassen [TiffOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tiffoptions/) kan du ange önskat pixelformat för den resulterande TIFF‑bilden.

```java
import com.aspose.slides.*;

// Instansiera Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP, etc.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat innehåller följande värden (enligt dokumentationen):
        Format1bppIndexed - 1 bit per pixel, indexerad.
        Format4bppIndexed - 4 bitar per pixel, indexerad.
        Format8bppIndexed - 8 bitar per pixel, indexerad.
        Format24bppRgb    - 24 bitar per pixel, RGB.
        Format32bppArgb   - 32 bitar per pixel, ARGB.
    */
    
    // Spara presentationen som TIFF med det angivna pixelformatet.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
Kolla in Asposes [GRATIS PowerPoint till Poster‑konverterare](https://products.aspose.app/slides/sv/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Kan jag konvertera en enskild bild istället för hela PowerPoint-presentationen till TIFF?**

Ja. Aspose.Slides låter dig konvertera enskilda bilder från PowerPoint- och OpenDocument-presentationer till TIFF‑bilder separat.

**Finns det någon gräns för antal bilder när du konverterar en presentation till TIFF?**

Nej, Aspose.Slides påför inga begränsningar för antalet bilder. Du kan konvertera presentationer av vilken storlek som helst till TIFF‑format.

**Bevaras PowerPoint‑animationer och övergångseffekter när du konverterar bilder till TIFF?**

Nej, TIFF är ett statiskt bildformat. Därför bevaras inte animationer och övergångseffekter; endast statiska ögonblicksbilder av bilderna exporteras.