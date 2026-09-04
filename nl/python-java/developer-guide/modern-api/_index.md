---
title: Verbeter de afbeeldingverwerking met de Moderne API in Python
linktitle: Moderne API
type: docs
weight: 237
url: /nl/python-java/modern-api/
keywords:
- moderne API
- tekenen
- dia-miniatuur
- dia naar afbeelding
- vorm-miniatuur
- vorm naar afbeelding
- presentatie-miniatuur
- presentatie naar afbeeldingen
- afbeelding toevoegen
- foto toevoegen
- Python
- Java
- Aspose.Slides
description: "Moderniseer de afbeeldingverwerking in Python via Java: render dia's en vormen, voeg afbeeldingen toe, en migreer verouderde imaging‑aanroepen naar de Aspose.Slides Moderne API."
---
## **Introductie**

Aspose.Slides voor Python via Java benadert de Java‑bibliotheek via JPype. De legacy‑image‑verwerking‑API gebruikte [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) en [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) van `java.awt`.

De Java‑bibliotheek heeft deze imaging‑API’s vanaf versie 24.4 verouderd verklaard. De Moderne API gebruikt [IImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/iimage/) om afbeeldingen te laden, te renderen en op te slaan. Gebruik deze voor nieuwe Python‑code en bij het migreren van bestaande image‑verwerkings‑workflows.

{{% alert color="info" title="Note" %}}
De oude methodenamen hieronder zijn migratiereferénces. Ze zijn niet meer beschikbaar in de huidige releases. De uitvoerbare voorbeelden gebruiken de Moderne API.
{{% /alert %}}

## **Moderne API**

De belangrijkste image‑verwerkingstypen zijn:

- [IImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/iimage/) — vertegenwoordigt een raster‑ of vectorafbeelding.
- [ImageFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imageformat/) — biedt constanten voor afbeeldingsbestandsformaten.
- [Images](https://reference.aspose.com/slides/nl/python-java/aspose.slides/images/) — maakt afbeeldingen, bijvoorbeeld met [Images.fromFile](https://reference.aspose.com/slides/nl/python-java/aspose.slides/images/#fromFile).

Gebruik [Slide.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getImage) of [Shape.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getImage) om één dia of vorm te renderen. Gebruik [Presentation.getImages](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getImages) met renderopties om meerdere dia's te renderen. De overload zonder argumenten retourneert in plaats daarvan de afbeeldingscollectie van de presentatie.

Laad een afbeelding met [Images.fromFile](https://reference.aspose.com/slides/nl/python-java/aspose.slides/images/#fromFile), voeg deze toe met [ImageCollection.addImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagecollection/#addImage), of werk een bestaande presentatieweergave bij met [PPImage.replaceImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/ppimage/#replaceImage). Beide bewerkingen op de afbeeldingscollectie accepteren [IImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/iimage/).

Maak elke afbeelding die je laadt of rendert vrij door zijn `dispose`‑methode aan te roepen in een `finally`‑block. Maak de presentatie vrij met [Presentation.dispose](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#dispose).

### **Bereid de Python‑omgeving voor**

Installeer de pakketten zoals beschreven in [Installation](/slides/nl/python-java/installation/). Elk voorbeeld importeert `asposeslides` vóór het starten van de JVM, daarna wordt de API geïmporteerd nadat de JVM draait. De voorbeelden laten de JVM actief zodat deze hergebruikt kan worden. Zie [Limitations and API Differences](/slides/nl/python-java/limitations-and-api-differences/#import-the-library) voor notebook‑ en JVM‑levenscyclusrichtlijnen.

Voorbeelden die `pres.pptx` openen vereisen een presentatie in de werkdirectory. Voorbeelden die `image.png` laden vereisen een bestaand afbeeldingsbestand.

### **Laad een afbeelding en render een dia**

Dit voorbeeld voegt een afbeelding toe aan de eerste dia en slaat de dia op als een JPEG‑afbeelding. [IImage.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/iimage/#save) schrijft de gerenderde afbeelding in het opgegeven formaat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Images, Presentation, ShapeType
from java.awt import Dimension

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    image_size = Dimension(1920, 1080)
    slide_image = slide.getImage(image_size)
    try:
        slide_image.save("slide1.jpeg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

## **Vervangen van oude code met de Moderne API**

Vervang legacy‑thumbnail‑aanroepen door methoden die [IImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/iimage/) retourneren, en sla het resultaat vervolgens op met [IImage.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/iimage/#save). Hierdoor is het niet meer nodig om gerenderde afbeeldingen door te geven aan [ImageIO.write](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#write-java.awt.image.RenderedImage-java.lang.String-java.io.File-).

### **Render een dia met een gespecificeerde grootte**

Vervang de legacy‑aanroep `slide.getThumbnail(image_size)` door [Slide.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getImage) met dezelfde afbeeldingsgrootte.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        image_size = Dimension(1920, 1080)
        slide_image = presentation.getSlides().get_Item(0).getImage(image_size)
        try:
            slide_image.save("image.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Een dia‑miniatuur ophalen**

Vervang de legacy‑aanroep `slide.getThumbnail()` door [Slide.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getImage) zonder argumenten.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide_image = presentation.getSlides().get_Item(0).getImage()
        try:
            slide_image.save("slide1.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Een vorm‑miniatuur ophalen**

Vervang de legacy‑aanroep `shape.getThumbnail()` door [Shape.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getImage). Controleer dat de dia een vorm bevat voordat je er toegang toe krijgt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getShapes().size() > 0:
            shape_image = slide.getShapes().get_Item(0).getImage()
            try:
                shape_image.save("shape.png", ImageFormat.Png)
            finally:
                shape_image.dispose()
        else:
            print("The first slide contains no shapes.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Een presentatie‑miniatuur ophalen**

Vervang de legacy‑aanroep `presentation.getThumbnails(options, image_size)` door [Presentation.getImages](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getImages). Gebruik [RenderingOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/renderingoptions/) om het renderen te configureren.

Itereer direct over de geretourneerde array met Python’s `enumerate`. Ruim elke geretourneerde afbeelding op in een `finally`‑block zodat een opslagfout de overige afbeeldingen niet onopgeruimd laat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    rendering_options = RenderingOptions()
    image_size = Dimension(1920, 1080)
    images = presentation.getImages(rendering_options, image_size)
    try:
        for index, image in enumerate(images, start=1):
            image.save(f"slide{index}.png", ImageFormat.Png)
    finally:
        for image in images:
            image.dispose()
finally:
    presentation.dispose()
```

### **Een afbeelding aan een presentatie toevoegen**

Vervang het laden via [ImageIO.read](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#read-java.io.File-) door [Images.fromFile](https://reference.aspose.com/slides/nl/python-java/aspose.slides/images/#fromFile), en geef vervolgens de resulterende afbeelding door aan [ImageCollection.addImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagecollection/#addImage). Voeg de afbeelding toe aan de dia en sla de presentatie op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)
    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Verouderde methoden en hun vervanging in de Moderne API**

De tabellen gebruiken Python‑aanroepnotatie. Namen in de legacy‑kolom duiden verwijderde API’s aan; gebruik de gekoppelde vervangende methoden. De moderne rendermethoden retourneren [IImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/iimage/) objecten in plaats van Java‑buffered images.

### **Presentation**

[Presentation.getImages](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getImages) retourneert een array van gerenderde afbeeldingen wanneer het wordt aangeroepen met renderopties.

| Legacy oproep | Moderne vervanging |
| --- | --- |
| `presentation.getThumbnails(options)` | [getImages](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getImages) met `options` |
| `presentation.getThumbnails(options, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getImages) met `options, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides)` | [getImages](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getImages) met `options, slides` |
| `presentation.getThumbnails(options, slides, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getImages) met `options, slides, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides, image_size)` | [getImages](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getImages) met `options, slides, image_size` |
| `presentation.getThumbnails(options, image_size)` | [getImages](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getImages) met `options, image_size` |

Hier is `slides` een Java `int[]` met één‑gebaseerde slidennummers; maak het aan met `jpype.JArray(jpype.JInt)([1, 3])` om dia 1 en 3 te selecteren. `image_size` is een [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html).

### **Shape**

| Legacy oproep | Moderne vervanging |
| --- | --- |
| `shape.getThumbnail()` | [getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getImage) zonder argumenten |
| `shape.getThumbnail(bounds, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getImage) met `bounds, scale_x, scale_y` |

### **Slide**

| Legacy oproep | Moderne vervanging |
| --- | --- |
| `slide.getThumbnail()` | [getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getImage) zonder argumenten |
| `slide.getThumbnail(scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getImage) met `scale_x, scale_y` |
| `slide.getThumbnail(options)` | [getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getImage) met `options` |
| `slide.getThumbnail(options, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getImage) met `options, scale_x, scale_y` |
| `slide.getThumbnail(options, image_size)` | [getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getImage) met `options, image_size` |
| `slide.getThumbnail(tiff_options)` | [getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getImage) met `tiff_options` |
| `slide.getThumbnail(image_size)` | [getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getImage) met `image_size` |
| `slide.renderToGraphics(options, graphics)` | Geen directe vervanging; render naar een afbeelding in plaats daarvan |
| `slide.renderToGraphics(options, graphics, scale_x, scale_y)` | Geen directe vervanging; render naar een afbeelding in plaats daarvan |
| `slide.renderToGraphics(options, graphics, image_size)` | Geen directe vervanging; render naar een afbeelding in plaats daarvan |

Hier is `options` een [RenderingOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/renderingoptions/), en `tiff_options` een [TiffOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/tiffoptions/).

### **Output**

| Legacy oproep | Moderne vervanging |
| --- | --- |
| `output.add(path, buffered_image)` | [Output.add](https://reference.aspose.com/slides/nl/python-java/aspose.slides/output/#add) met `path, image`, waarbij `image` een [IImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/iimage/) is |

### **ImageCollection**

| Legacy oproep | Moderne vervanging |
| --- | --- |
| `collection.addImage(buffered_image)` | [ImageCollection.addImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagecollection/#addImage) met een [IImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/iimage/) |

### **PPImage**

| Legacy oproep | Moderne vervanging |
| --- | --- |
| `picture.getSystemImage()` | [PPImage.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/ppimage/#getImage) |

Om de inhoud van een bestaand presentatie‑beeld te vervangen, gebruik [PPImage.replaceImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/ppimage/#replaceImage) met een [IImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/iimage/).

### **PatternFormat**

| Legacy oproep | Moderne vervanging |
| --- | --- |
| `pattern.getTileImage(style_color)` | [PatternFormat.getTile](https://reference.aspose.com/slides/nl/python-java/aspose.slides/patternformat/#getTile) met `style_color` |
| `pattern.getTileImage(background, foreground)` | [PatternFormat.getTile](https://reference.aspose.com/slides/nl/python-java/aspose.slides/patternformat/#getTile) met `background, foreground` |

De kleurargumenten blijven Java‑[Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html)‑objecten.

### **PatternFormatEffectiveData**

Voor effectieve patroon‑data die door de Java‑API via JPype wordt teruggegeven, behoudt de vervangende methode de naam `getTileIImage`.

| Legacy oproep | Moderne vervanging |
| --- | --- |
| `effective_pattern.getTileImage(background, foreground)` | `effective_pattern.getTileIImage(background, foreground)`, retourneert een [IImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/iimage/) |

## **API‑ondersteuning voor Graphics2D**

De legacy‑overloads van `renderToGraphics` tekenden in een door de aanroeper geleverde [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)‑context. De Moderne API heeft geen directe vervanging die naar die context tekent.

Gebruik [Slide.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getImage) om een dia te renderen of [Presentation.getImages](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getImages) om meerdere dia's te renderen, en sla vervolgens de geretourneerde afbeeldingen op met [IImage.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/iimage/#save). Toepassingen die dia‑rendering combineerden met aangepaste Java‑tekeningen moeten hun compositiestap aanpassen.

## **FAQ**

**Waarom is de oude Java‑imaging‑API vervangen?**

De Moderne API verplaatst het laden, renderen en opslaan van afbeeldingen naar [IImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/iimage/). Dit geeft deze workflows een gemeenschappelijke afbeeldingsabstractie in plaats van Java‑buffered images of een Java‑graphics‑context bloot te stellen.

**Heb ik nog steeds Java en JPype nodig?**

Ja. Aspose.Slides voor Python via Java draait nog steeds op de JVM. De Moderne API wijzigt alleen de image‑verwerkings‑aanroepen, niet de runtime‑vereisten. Zie [System Requirements](/slides/nl/python-java/system-requirements/).

**Hoe maak ik afbeeldingen vrij in Python?**

Roep `dispose` aan op elke afbeelding die je laadt of rendert in een `finally`‑block. Als je meerdere dia's rendert, maak dan elke afbeelding in de geretourneerde array vrij. Maak de presentatie apart vrij met [Presentation.dispose](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#dispose).

**Garandeert het overstappen op de Moderne API snellere thumbnail‑generatie?**

Geen prestatie‑verbetering is gegarandeerd. De vervangingen ondersteunen render‑opties, schalen en afbeeldingsgroottes; meet de prestaties met jouw presentaties en output‑instellingen.

**Waarom levert de afbeeldings‑getter soms een collectie?**

[Presentation.getImages](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getImages) zonder argumenten retourneert ingebedde presentatiewerkafbeeldingen. De overloads met renderopties retourneren de gerenderde dia‑afbeeldingen.