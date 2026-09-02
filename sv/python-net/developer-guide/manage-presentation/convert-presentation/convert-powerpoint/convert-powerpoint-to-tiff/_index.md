---
title: Konvertera PowerPoint-presentationer till TIFF i Python
titlelink: PowerPoint till TIFF
type: docs
weight: 90
url: /sv/python-net/convert-powerpoint-to-tiff/
keywords:
- konvertera PowerPoint
- konvertera OpenDocument
- konvertera presentation
- konvertera bild
- PowerPoint till TIFF
- OpenDocument till TIFF
- presentation till TIFF
- bild till TIFF
- PPT till TIFF
- PPTX till TIFF
- ODP till TIFF
- Python
- Aspose.Slides
description: "Lär dig hur du enkelt konverterar PowerPoint (PPT, PPTX) och OpenDocument (ODP) presentationer till högkvalitativa TIFF-bilder med Aspose.Slides för Python via .NET. Steg-för-steg guide med kodexempel inkluderade."
---
## **Introduktion**

TIFF (**Tagged Image File Format**) är ett allmänt använt, förlustfritt rasterbildformat som är känt för sin exceptionella kvalitet och detaljerade bevarande av grafik. Designers, fotografer och desktoputgivare väljer ofta TIFF för att bevara lager, färgprecision och ursprungliga inställningar i sina bilder.

Med Aspose.Slides kan du enkelt konvertera dina PowerPoint-bilder (PPT, PPTX) och OpenDocument-bilder (ODP) direkt till TIFF-bilder av hög kvalitet, vilket säkerställer att dina presentationer behåller maximal visuell trohet.

## **Konvertera en presentation till TIFF**

Genom att använda metoden [save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/#methods) som tillhandahålls av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) kan du snabbt konvertera en hel PowerPoint-presentation till TIFF. De resulterande TIFF-bilderna motsvarar standardstorleken på bilden.

Den här Python-koden visar hur man konverterar en PowerPoint-presentation till TIFF:

```py
import aspose.slides as slides

# Instansiera Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP, osv).
with slides.Presentation("presentation.pptx") as presentation:
    # Spara presentationen som TIFF.
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF)
```

## **Konvertera en presentation till svartvitt TIFF**

Egenskapen [bw_conversion_mode](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) i klassen [TiffOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/tiffoptions/) låter dig ange vilken algoritm som används när du konverterar en färgad bild eller ett färgat bildspel till ett svartvitt TIFF. Observera att denna inställning endast gäller när egenskapen [compression_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/tiffoptions/compression_type/) är satt till `CCITT4` eller `CCITT3`.

{{% alert color="info" title="Obs" %}}
[TiffOptions.bw_conversion_mode](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) är en exportnivåinställning som väljer en pixelkonverteringsalgoritm för hela TIFF-bilden. För att definiera hur en enskild form ska visas när svartvitt läge är aktivt, använd [Shape.black_white_mode](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/black_white_mode/). Se [Control Black-and-White Rendering for Shapes](/python-net/shape-formatting/#control-black-and-white-rendering-for-shapes) för exempel.
{{% /alert %}}

Anta att vi har en "sample.pptx"-fil med följande bild:

![A presentation slide](slide_black_and_white.png)

Den här Python-koden visar hur man konverterar den färgade bilden till ett svartvitt TIFF:

```py
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.compression_type = slides.export.TiffCompressionTypes.CCITT4
tiff_options.bw_conversion_mode = slides.export.BlackWhiteConversionMode.DITHERING

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

Resultatet:

![Black-and-White TIFF](TIFF_black_and_white.png)

## **Konvertera en presentation till TIFF med anpassad storlek**

Om du behöver en TIFF-bild med specifika dimensioner kan du ange önskade värden med hjälp av egenskaper som finns i [TiffOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/tiffoptions/). Till exempel låter egenskapen [image_size](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/tiffoptions/image_size/) dig definiera storleken på den resulterande bilden.

Den här Python-koden visar hur man konverterar en PowerPoint-presentation till TIFF-bilder med anpassad storlek:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

# Instansiera Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP, osv).
with slides.Presentation("sample.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    # Ange kompressionstypen.
    tiff_options.compression_type = slides.export.TiffCompressionTypes.DEFAULT
    """
    Kompressionstyper:
        Default - Anger standardkompressionsschemat (LZW).
        None - Anger ingen kompression.
        CCITT3
        CCITT4
        LZW
        RLE
    """

    # Ange bildens DPI.
    tiff_options.dpi_x = 200
    tiff_options.dpi_y = 200

    # Ange bildstorleken.
    tiff_options.image_size = drawing.Size(1728, 1078)

    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL
    tiff_options.slides_layout_options = notes_options

    # Spara presentationen som TIFF med angiven storlek.
    presentation.save("custom_size.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

## **Konvertera en presentation till TIFF med anpassat bildpixelformat**

Genom att använda egenskapen [pixel_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/tiffoptions/pixel_format/) från klassen [TiffOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/tiffoptions/) kan du ange ditt föredragna pixelformat för den resulterande TIFF-bilden.

Den här Python-koden visar hur man konverterar en PowerPoint-presentation till en TIFF-bild med anpassat pixelformat:

```py
import aspose.slides as slides

# Instansiera Presentation-klassen som representerar en presentationsfil (PPT, PPTX, ODP, osv).
with slides.Presentation("Presentation.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    tiff_options.pixel_format = slides.export.ImagePixelFormat.FORMAT_8BPP_INDEXED
    """
    ImagePixelFormat contains the following values (as stated in the documentation):
        FORMAT_1BPP_INDEXED - 1 bit per pixel, indexed.
        FORMAT_4BPP_INDEXED - 4 bits per pixel, indexed.
        FORMAT_8BPP_INDEXED - 8 bits per pixel, indexed.
        FORMAT_24BPP_RGB    - 24 bits per pixel, RGB.
        FORMAT_32BPP_ARGB   - 32 bits per pixel, ARGB.
    """

    # Spara presentationen som TIFF med angivet pixelformat.
    presentation.save("Custom_Image_Pixel_Format.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

{{% alert title="Tips" color="info" %}}
Kolla in Asposes [GRATIS PowerPoint till Poster-omvandlare](https://products.aspose.app/slides/sv/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Kan jag konvertera en enskild bild i stället för en hel PowerPoint-presentation till TIFF?**

Ja. Aspose.Slides låter dig konvertera enskilda bilder från PowerPoint- och OpenDocument-presentationer till TIFF-bilder separat.

**Finns det någon gräns för antalet bilder när man konverterar en presentation till TIFF?**

Ingen. Aspose.Slides påför inga begränsningar för antalet bilder. Du kan konvertera presentationer av vilken storlek som helst till TIFF-format.

**Bevaras PowerPoint-animationer och övergångseffekter när man konverterar bilder till TIFF?**

Nej, TIFF är ett statiskt bildformat. Därför bevaras inte animationer och övergångseffekter; endast statiska ögonblicksbilder av bilder exporteras.