---
title: Konvertera PowerPoint-presentationer till TIFF i Python
linktitle: PowerPoint till TIFF
type: docs
weight: 90
url: /sv/python-java/convert-powerpoint-to-tiff/
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
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du enkelt kan konvertera PowerPoint (PPT, PPTX)-presentationer till högkvalitativa TIFF-bilder med Aspose.Slides för Python via Java, med kodexempel."
---
## **Introduktion**

TIFF (**Tagged Image File Format**) är ett rasterbildformat som stöder flera sidor och förlustfri kompression. Det är användbart för att lagra renderade bildrutor i en enda bildfil.

Använd Aspose.Slides för Python via Java för att konvertera PowerPoint‑presentationer (PPT, PPTX) och OpenDocument‑presentationer (ODP) till TIFF. Varje exempel nedan startar Java‑virtuell maskin om det behövs och frigör presentationen efter användning.

## **Konvertera en presentation till TIFF**

Genom att använda metoden [save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save) som tillhandahålls av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) kan du snabbt konvertera en hel PowerPoint‑presentation till TIFF. Den resulterande flersidiga TIFF‑filen innehåller en renderad bild av varje bildruta i standardstorlek.

Den här koden visar hur man konverterar en PowerPoint‑presentation till TIFF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # Spara alla bildrutor i en flersidig TIFF-fil.
    presentation.save("output.tiff", SaveFormat.Tiff)
finally:
    presentation.dispose()
```

## **Konvertera en presentation till svartvitt TIFF**

Metoden [setBwConversionMode](https://reference.aspose.com/slides/sv/python-java/aspose.slides/tiffoptions/#setBwConversionMode) i klassen [TiffOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/tiffoptions/) gör det möjligt att ange algoritmen som används när en färgad bildruta eller bild konverteras till ett svartvitt TIFF. Observera att den här inställningen endast gäller när metoden [setCompressionType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/tiffoptions/#setCompressionType) är satt till [TiffCompressionTypes.CCITT4](https://reference.aspose.com/slides/sv/python-java/aspose.slides/tiffcompressiontypes/#CCITT4) eller [TiffCompressionTypes.CCITT3](https://reference.aspose.com/slides/sv/python-java/aspose.slides/tiffcompressiontypes/#CCITT3).

{{% alert color="info" title="Note" %}}

[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/sv/python-java/aspose.slides/tiffoptions/#setBwConversionMode) är en exportnivåinställning som väljer en pixelkonverteringsalgoritm för hela TIFF‑bilden. För att definiera hur en enskild form ska visas när svartvitt läge är aktivt, använd [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#setBlackWhiteMode). Se [Control Black-and-White Rendering for Shapes](/slides/sv/python-java/shape-formatting/#control-black-and-white-rendering-for-shapes) för exempel.

{{% /alert %}}

Anta att vi har en fil ”sample.pptx” med följande bildruta:

![En presentationsbild](slide_black_and_white.png)

Den här koden visar hur man konverterar den färgade bildrutan till ett svartvitt TIFF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteConversionMode, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions

tiff_options = TiffOptions()
tiff_options.setCompressionType(TiffCompressionTypes.CCITT4)
tiff_options.setBwConversionMode(BlackWhiteConversionMode.Dithering)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

Resultatet:

![Svartvitt TIFF](TIFF_black_and_white.png)

## **Konvertera en presentation till TIFF med anpassad storlek**

Om du behöver en TIFF‑bild med specifika dimensioner kan du ange dina önskade värden med metoder som finns i [TiffOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/tiffoptions/). Till exempel gör metoden [setImageSize](https://reference.aspose.com/slides/sv/python-java/aspose.slides/tiffoptions/#setImageSize) det möjligt att definiera storleken på den resulterande bilden.

Den här koden visar hur man konverterar en PowerPoint‑presentation till TIFF‑bilder med anpassad storlek:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setCompressionType(TiffCompressionTypes.Default)

    # Ställ in den horisontella och vertikala upplösningen.
    tiff_options.setDpiX(200)
    tiff_options.setDpiY(200)

    # Ställ in utmatningsdimensionerna i pixlar.
    image_size = Dimension(1728, 1078)
    tiff_options.setImageSize(image_size)

    # Inkludera de kompletta talarnoterna under varje bildruta.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    tiff_options.setSlidesLayoutOptions(notes_options)

    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

## **Konvertera en presentation till TIFF med ett anpassat bildpixelformat**

Genom att använda metoden [setPixelFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/tiffoptions/#setPixelFormat) i klassen [TiffOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/tiffoptions/) kan du ange ditt föredragna pixelformat för den resulterande TIFF‑bilden.

Den här koden visar hur man konverterar en PowerPoint‑presentation till en TIFF‑bild med ett anpassat pixelformat:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImagePixelFormat, Presentation, SaveFormat, TiffOptions

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setPixelFormat(ImagePixelFormat.Format8bppIndexed)

    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

{{% alert title="Tip" color="success" %}}

Kolla in Asposes [GRATIS PowerPoint till Poster‑konverterare](https://products.aspose.app/slides/sv/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **FAQ**

**Kan jag konvertera en enskild bildruta istället för en hel PowerPoint‑presentation till TIFF?**

Ja. Aspose.Slides gör det möjligt att konvertera enskilda bildrutor från PowerPoint‑ och OpenDocument‑presentationer till TIFF‑bilder separat.

**Finns det någon begränsning på antalet bildrutor när man konverterar en presentation till TIFF?**

Det finns ingen fast gräns för antal bildrutor vid TIFF‑export. Tillgängligt minne, bildrutors komplexitet och utskriftsdimensioner påverkar storleken på presentationer du kan bearbeta.

**Bevaras PowerPoint‑animationer och övergångseffekter när man konverterar bildrutor till TIFF?**

Nej, TIFF är ett statiskt bildformat. Därför bevaras inte animationer och övergångseffekter; endast statiska ögonblicksbilder av bildrutor exporteras.