---
title: Konvertera presentationsbilder till bildfiler i Python
linktitle: Bild till bildfil
type: docs
weight: 35
url: /sv/python-java/convert-slide/
keywords:
- konvertera bild
- exportera bild
- bild till bildfil
- spara bild som bildfil
- bild till EMF
- bild till PNG
- bild till JPEG
- bild till bitmap
- bild till TIFF
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Konvertera bilder från PPT-, PPTX- och ODP-presentationer till PNG, JPEG, GIF, TIFF, EMF och andra bildformat i Python med Aspose.Slides."
---
## **Introduktion**

Aspose.Slides for Python via Java kan rendera enskilda bildspel från PowerPoint- och OpenDocument-presentationer som PNG, JPEG, GIF, TIFF och andra bildformat.

För att konvertera en bild till en bildfil, följ dessa steg:

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Välj den bild som du vill rendera.
3. Om nödvändigt, konfigurera rendering med klassen [RenderingOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/renderingoptions/) eller [TiffOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/tiffoptions/).
4. Anropa metoden [Slide.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getImage). Den returnerar ett bildobjekt.
5. Spara bilden och ange utdataformatet med ett [ImageFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imageformat/)-värde.

## **Konvertera en bild till en PNG-bild**

Den enklaste konverteringen använder standardinställningarna för rendering. Det resulterande bildobjektet kan bearbetas i minnet eller sparas till en fil.

Följande Python-exempel renderar den första bilden och sparar den som en PNG-bild:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage()
    try:
        image.save("Slide_0.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Konvertera bilder till bildfiler med anpassade storlekar**

Använd överlagringen av [Slide.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getImage) som accepterar ett [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html)-värde för att rendera en bild med exakta pixeldimensioner.

Följande exempel skapar en 1820 × 1040 JPEG-bild:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

image_size = Dimension(1820, 1040)

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(image_size)
    try:
        image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Konvertera bilder med anteckningar och kommentarer till bildfiler**

Som standard innehåller bildfilerna inga anteckningar eller kommentarer. Skicka ett [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notescommentslayoutingoptions/)-objekt till metoden [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) för att styra var anteckningar och kommentarer visas.

Följande exempel placerar avkortade anteckningar under bilden och kommentarer till höger om den:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Color

scale_x = 2.0
scale_y = scale_x

comments_area_color = Color(250, 235, 215)

layout_options = NotesCommentsLayoutingOptions()
layout_options.setNotesPosition(NotesPositions.BottomTruncated)
layout_options.setCommentsPosition(CommentsPositions.Right)
layout_options.setCommentsAreaWidth(500)
layout_options.setCommentsAreaColor(comments_area_color)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("Presentation_with_notes_and_comments.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(rendering_options, scale_x, scale_y)
    try:
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
För konvertering av bild till bildfil, skicka inte [BottomFull](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notespositions/#BottomFull) till metoden [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Anteckningar kan innehålla mer text än den fasta bildstorleken kan rymma. Använd istället [BottomTruncated](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notespositions/#BottomTruncated).
{{% /alert %}}

## **Konvertera bilder till bildfiler med TIFF-alternativ**

Klassen [TiffOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/tiffoptions/) låter dig kontrollera storlek, upplösning och andra egenskaper för den renderade TIFF-bilden.

Följande exempel renderar den första bilden som en 2160 × 2880 TIFF-bild med 300 DPI:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, TiffOptions
from java.awt import Dimension

image_size = Dimension(2160, 2880)

tiff_options = TiffOptions()
tiff_options.setImageSize(image_size)
tiff_options.setDpiX(300)
tiff_options.setDpiY(300)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(tiff_options)
    try:
        image.save("output.tiff", ImageFormat.Tiff)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
TIFF-stöd garanteras inte i Java-versioner tidigare än JDK 9.
{{% /alert %}}

## **Konvertera alla bilder till bildfiler**

Iterera genom bildsamlingen för att konvertera hela presentationen till en serie bilder. Dolda bilder inkluderas såvida du inte explicit hoppar över dem.

Följande exempel renderar varje bild som en JPEG-bild med horisontella och vertikala skalfaktorer på 2:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = scale_x

presentation = Presentation("Presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for index in range(slide_count):
        slide = presentation.getSlides().get_Item(index)
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"Slide_{index}.jpg", ImageFormat.Jpeg)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Skapa Enhanced Metafile-utdata**

Enhanced Metafile (EMF) är användbart när vektorgrafik måste utbytas med Microsoft Office eller andra Windows‑applikationer som stöder Windows‑metafiler. Till skillnad från en pixelbaserad bild kan en EMF behålla vektorritningsoperationer som kan skalas utan samma förlust av skärpa. EMF är dock främst ett kompatibilitetsformat för applikationer med stöd för Windows‑metafiler, inte ett universellt utbytesformat. Dessutom kan komplext bildinnehåll, såsom bitmapbilder och vissa effekter, lagras som rasteriserade element i vektormetafilen.

### **Exportera en bild till EMF**

Metoden [Slide.writeAsEmf](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/) skriver en [Slide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/) till ett måldataström i EMF-format. Följande exempel läser in en presentation, väljer den första bilden och skriver den till en EMF‑filström:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = FileOutputStream("Slide_0.emf")
    try:
        slide.writeAsEmf(emf_stream)
    finally:
        emf_stream.close()
finally:
    presentation.dispose()
```

Den som anropar äger strömmen som skickas till [Slide.writeAsEmf](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/) och är ansvarig för att stänga den, som visas ovan.

### **Konvertera en SVG-bild till EMF och lägg till den i en presentation**

Använd [SvgImage.writeAsEmf](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgimage/) för att konvertera SVG‑innehåll till EMF. De resulterande byten kan läggas till i presentationen via [ImageCollection.addImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagecollection/#addImage) och placeras på en bild med [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addPictureFrame).

Följande exempel skapar en [SvgImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgimage/) från SVG‑markup, konverterar den till en EMF i minnet, infogar metafilen på den första bilden och sparar presentationen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage
from java.io import ByteArrayOutputStream

svg_content = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>"
svg_image = SvgImage(svg_content)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = ByteArrayOutputStream()
    try:
        svg_image.writeAsEmf(emf_stream)

        emf_data = emf_stream.toByteArray()
        image = presentation.getImages().addImage(emf_data)
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image)
    finally:
        emf_stream.close()

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgimage/) tar inte ägandeskap av destinationsströmmen. En [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) lagrar all genererad data i minnet, så ingen återställning av positionen behövs innan anropet av [ByteArrayOutputStream.toByteArray](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html#toByteArray--). Den returnerade byte‑arrayen förblir giltig efter att strömmen har stängts.

EMF‑generering är tillgänglig på de operativsystem som stöds av den valda Aspose.Slides for Python via Java och JDK‑konfigurationen, men rendering kan skilja sig mellan plattformar när teckensnitt eller grafikberoenden saknas. Installera de teckensnitt som används i källinnehållet eller konfigurera lämpliga ersättningar, följ [plattformskraven](/slides/sv/python-java/system-requirements/) för Aspose.Slides for Python via Java, och validera resultatet i den mål‑EMF‑användande applikationen. Linux‑ och macOS‑applikationer har ofta begränsad eller inkonsekvent support för att visa och redigera Windows‑metafiler.

## **Färgrik Emoji-rendering**

{{% alert title="Note" color="info" %}}
För att rendera färgade emojis korrekt när du konverterar presentationsbilder till bildfiler måste de emoji‑teckensnitt som används i presentationen vara installerade och tillgängliga på systemet som utför konverteringen. Till exempel, om presentationen använder **Segoe UI Emoji** och detta teckensnitt saknas, kan emojis visas i monokrom i utdatasbilderna.
{{% /alert %}}

## **Vanliga frågor**

**Stöder Aspose.Slides rendering av bilder med animationer?**

Nej. Metoden [Slide.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getImage) renderar en statisk bild av bilden och exporterar inte animationer.

**Kan dolda bilder exporteras som bildfiler?**

Ja. Dolda bilder kan renderas som vanliga bilder. Inkludera dem i bearbetningsloopen, som visas i exemplet ovan.

**Behålls skuggor och andra effekter i bildfilerna?**

Ja. Aspose.Slides renderar skuggor, transparens och andra stödda grafiska effekter i bildfilerna.