---
title: Konvertera PowerPoint-presentationer till TIFF i PHP
titlelink: PowerPoint till TIFF
type: docs
weight: 90
url: /sv/php-java/convert-powerpoint-to-tiff/
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
- PHP
- Aspose.Slides
description: "Lär dig hur du enkelt kan konvertera PowerPoint (PPT, PPTX) presentationer till högkvalitativa TIFF‑bilder med Aspose.Slides för PHP via Java, med kodexempel."
---
## **Introduktion**

TIFF (**Tagged Image File Format**) är ett allmänt använt, förlustfritt rasterbildformat känt för sin exceptionella kvalitet och detaljerade bevarande av grafik. Formgivare, fotografer och desktop‑utgivare väljer ofta TIFF för att bevara lager, färgprecision och ursprungliga inställningar i sina bilder.

Med Aspose.Slides kan du enkelt konvertera dina PowerPoint‑bilder (PPT, PPTX) och OpenDocument‑bilder (ODP) direkt till högkvalitativa TIFF‑bilder, så att dina presentationer behåller maximal visuell trohet. 

## **Konvertera en presentation till TIFF**

Med hjälp av metoden [save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#save) som tillhandahålls av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) kan du snabbt konvertera en hel PowerPoint‑presentation till TIFF. De resulterande TIFF‑bilderna motsvarar standardbildstorleken.

Den här koden visar hur du konverterar en PowerPoint‑presentation till TIFF:

```php
// Instansiera Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP, etc.).
$presentation = new Presentation("presentation.pptx");
try {
    // Spara presentationen som TIFF.
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```

## **Konvertera en presentation till svart‑vit TIFF**

Metoden [setBwConversionMode](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tiffoptions/#setBwConversionMode) i klassen [TiffOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tiffoptions/) låter dig ange vilken algoritm som används när en färgad bild eller bild konverteras till en svart‑vit TIFF. Observera att denna inställning endast gäller när metoden [setCompressionType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tiffoptions/#getCompressionType) är satt till `CCITT4` eller `CCITT3`.

{{% alert color="info" title="Obs" %}}

[TiffOptions::setBwConversionMode](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tiffoptions/#setBwConversionMode) är en exportnivå‑inställning som väljer en pixel‑konverteringsalgoritm för hela TIFF‑bilden. För att definiera hur en enskild form ska visas när svart‑vit visningsläge är aktivt, använd [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#setBlackWhiteMode). Se [Control Black-and-White Rendering for Shapes](/slides/sv/php-java/shape-formatting/#control-black-and-white-rendering-for-shapes) för exempel.

{{% /alert %}}

Låt oss säga att vi har en "sample.pptx"-fil med följande bild:

![A presentation slide](slide_black_and_white.png)

Den här koden visar hur du konverterar den färgade bilden till en svart‑vit TIFF:

```php
$tiffOptions = new TiffOptions();
$tiffOptions->setCompressionType(TiffCompressionTypes::CCITT4);
$tiffOptions->setBwConversionMode(BlackWhiteConversionMode::Dithering);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

Resultatet:

![Black-and-White TIFF](TIFF_black_and_white.png)

## **Konvertera en presentation till TIFF med anpassad storlek**

Om du behöver en TIFF‑bild med specifika dimensioner kan du ange önskade värden med metoderna som finns i [TiffOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tiffoptions/). Till exempel låter metoden [setImageSize](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tiffoptions/#getImageSize) dig definiera storleken på den resulterande bilden.

Den här koden visar hur du konverterar en PowerPoint‑presentation till TIFF‑bilder med anpassad storlek:

```php
// Instansiera Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP, etc.).
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // Ange kompressionstypen.
    $tiffOptions->setCompressionType(TiffCompressionTypes::Default);
    /*
    Komprimeringstyper:
        Default - Anger standard komprimeringsschema (LZW).
        None - Anger ingen kompression.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Djupet beror på kompressionstypen och kan inte ställas in manuellt.

    // Ange bildens DPI.
    $tiffOptions->setDpiX(200);
    $tiffOptions->setDpiY(200);

    // Ange bildstorlek.
    $tiffOptions->setImageSize(new Java("java.awt.Dimension", 1728, 1078));

    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // Spara presentationen som TIFF med angiven storlek.
    $presentation->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

## **Konvertera en presentation till TIFF med anpassat bildpixelformat**

Med metoden [setPixelFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tiffoptions/#getPixelFormat) från klassen [TiffOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tiffoptions/) kan du ange ditt föredragna pixelformat för den resulterande TIFF‑bilden.

Den här koden visar hur du konverterar en PowerPoint‑presentation till en TIFF‑bild med ett anpassat pixelformat:

```php
// Instansiera Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP, etc.).
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat innehåller följande värden (enligt dokumentationen):
        Format1bppIndexed - 1 bit per pixel, indexerad.
        Format4bppIndexed - 4 bitar per pixel, indexerad.
        Format8bppIndexed - 8 bitar per pixel, indexerad.
        Format24bppRgb    - 24 bitar per pixel, RGB.
        Format32bppArgb   - 32 bitar per pixel, ARGB.
    */

    // Spara presentationen som TIFF med angiven bildstorlek.
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Tips" color="info" %}}

Kolla in Asposes [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/sv/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **Vanliga frågor**

**Kan jag konvertera en enskild bild i stället för hela PowerPoint‑presentationen till TIFF?**

Ja. Aspose.Slides låter dig konvertera enskilda bilder från PowerPoint‑ och OpenDocument‑presentationer till TIFF‑bilder separat.

**Finns det någon begränsning för antalet bilder när man konverterar en presentation till TIFF?**

Nej, Aspose.Slides påför inga restriktioner för antalet bilder. Du kan konvertera presentationer av vilken storlek som helst till TIFF‑format.

**Behålls PowerPoint‑animationer och övergångseffekter när man konverterar bilder till TIFF?**

Nej, TIFF är ett statiskt bildformat. Därför bevaras inte animationer och övergångseffekter; endast statiska ögonblicksbilder av bildspresentationen exporteras.