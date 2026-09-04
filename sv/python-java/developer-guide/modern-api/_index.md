---
title: Förbättra bildbehandling med det moderna API:t i Python
linktitle: Modernt API
type: docs
weight: 237
url: /sv/python-java/modern-api/
keywords:
- modernt API
- ritning
- bildminiatyr
- bild till bild
- formminiatyr
- form till bild
- presentationsminiatyr
- presentation till bilder
- lägg till bild
- lägg till bild
- Python
- Java
- Aspose.Slides
description: "Modernisera bildbehandling i Python via Java: rendera bilder och former, lägg till bilder, och migrera föråldrade bildanrop till Aspose.Slides Moderna API."
---
## **Introduktion**

Aspose.Slides for Python via Java åtkomst till Java‑biblioteket via JPype. Dess äldre bildbehandlings‑API använde [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) och [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) från `java.awt`.

Java‑biblioteket avskaffade dessa bild‑API:er från version 24.4. Det moderna API:t använder [IImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/iimage/) för att läsa in, rendera och spara bilder. Använd det för ny Python‑kod och när du migrerar befintliga bildbehandlingsarbetsflöden.

{{% alert color="info" title="Note" %}}
De gamla metodnamnen nedan är migrationsreferenser. De är inte längre tillgängliga i nuvarande versioner. De körbara exemplen använder det moderna API:t.
{{% /alert %}}

## **Modernt API**

De viktigaste bildbehandlingstyperna är:

- [IImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/iimage/) — representerar en raster‑ eller vektorbild.
- [ImageFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imageformat/) — tillhandahåller bildfilformatkonstanter.
- [Images](https://reference.aspose.com/slides/sv/python-java/aspose.slides/images/) — skapar bilder, till exempel med [Images.fromFile](https://reference.aspose.com/slides/sv/python-java/aspose.slides/images/#fromFile).

Använd [Slide.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getImage) eller [Shape.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getImage) för att rendera en bild eller form. Använd [Presentation.getImages](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getImages) med renderingsalternativ för att rendera flera bilder. Överlagringen utan argument returnerar presentationens bildsamling istället.

Läs in en bild med [Images.fromFile](https://reference.aspose.com/slides/sv/python-java/aspose.slides/images/#fromFile), lägg till den med [ImageCollection.addImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagecollection/#addImage), eller uppdatera en befintlig presentationsbild med [PPImage.replaceImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/#replaceImage). Båda bildsamlingens operationer accepterar [IImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/iimage/).

Frigör varje bild du läser in eller renderar genom att anropa dess `dispose`‑metod i ett `finally`‑block. Frigör presentationen med [Presentation.dispose](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#dispose).

### **Förbered Python‑miljön**

Installera paketen enligt beskrivningen i [Installation](/slides/sv/python-java/installation/). Varje exempel importerar `asposeslides` innan JVM startas, sedan importerar det API:t när JVM körs. Exemplen låter JVM fortsätta köra så att den kan återanvändas. Se [Begränsningar och API‑skillnader](/slides/sv/python-java/limitations-and-api-differences/#import-the-library) för vägledning om notebook‑ och JVM‑livscykeln.

Exempel som öppnar `pres.pptx` kräver en presentation i arbetskatalogen. Exempel som läser in `image.png` kräver en befintlig bildfil.

### **Läs in en bild och rendera en bild**

Detta exempel lägger till en bild på den första bilden och sparar bilden som en JPEG‑fil. [IImage.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/iimage/#save) skriver den renderade bilden i det angivna formatet.

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

## **Ersätta gammal kod med modernt API**

Ersätt äldre miniatyr‑anrop med metoder som returnerar [IImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/iimage/), och spara sedan resultatet med [IImage.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/iimage/#save). Detta eliminerar behovet av att skicka renderade bilder till [ImageIO.write](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#write-java.awt.image.RenderedImage-java.lang.String-java.io.File-).

### **Rendera en bild i en angiven storlek**

Ersätt det äldre anropet `slide.getThumbnail(image_size)` med [Slide.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getImage) med samma bildstorlek.

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

### **Hämta en bilds miniatyr**

Ersätt det äldre anropet `slide.getThumbnail()` med [Slide.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getImage) utan argument.

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

### **Hämta en formminiatyr**

Ersätt det äldre anropet `shape.getThumbnail()` med [Shape.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getImage). Kontrollera att bilden innehåller en form innan du hämtar den.

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

### **Hämta en presentationsminiatyr**

Ersätt det äldre anropet `presentation.getThumbnails(options, image_size)` med [Presentation.getImages](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getImages). Använd [RenderingOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/renderingoptions/) för att konfigurera rendering.

Iterera över den returnerade arrayen direkt med Pythons `enumerate`. Frigör varje returnerad bild i ett `finally`‑block så att ett spara‑fel inte lämnar återstående bilder ofrigjorda.

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

### **Lägga till en bild i en presentation**

Ersätt inläsning via [ImageIO.read](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#read-java.io.File-) med [Images.fromFile](https://reference.aspose.com/slides/sv/python-java/aspose.slides/images/#fromFile), och skicka sedan den resulterande bilden till [ImageCollection.addImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagecollection/#addImage). Lägg till bilden på bilden och spara presentationen.

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

## **Avskrivna metoder och deras ersättningar i modernt API**

Tabellerna använder Python‑anropsnotation. Namnen i den äldre kolumnen identifierar borttagna API:er; använd de länkade ersättningsmetoderna. De moderna bildrenderingsmetoderna returnerar [IImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/iimage/)‑objekt istället för Java‑buffrade bilder.

### **Presentation**

[Presentation.getImages](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getImages) returnerar en array av renderade bilder när den anropas med renderingsalternativ.

| Gammalt anrop | Modern ersättning |
| --- | --- |
| `presentation.getThumbnails(options)` | [getImages](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getImages) med `options` |
| `presentation.getThumbnails(options, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getImages) med `options, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides)` | [getImages](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getImages) med `options, slides` |
| `presentation.getThumbnails(options, slides, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getImages) med `options, slides, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides, image_size)` | [getImages](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getImages) med `options, slides, image_size` |
| `presentation.getThumbnails(options, image_size)` | [getImages](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getImages) med `options, image_size` |

Här är `slides` en Java `int[]` med ett‑baserade bildnummer; skapa den med `jpype.JArray(jpype.JInt)([1, 3])` för att välja bilderna 1 och 3. `image_size` är en [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html).

### **Shape**

| Gammalt anrop | Modern ersättning |
| --- | --- |
| `shape.getThumbnail()` | [getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getImage) med inga argument |
| `shape.getThumbnail(bounds, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getImage) med `bounds, scale_x, scale_y` |

### **Slide**

| Gammalt anrop | Modern ersättning |
| --- | --- |
| `slide.getThumbnail()` | [getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getImage) med inga argument |
| `slide.getThumbnail(scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getImage) med `scale_x, scale_y` |
| `slide.getThumbnail(options)` | [getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getImage) med `options` |
| `slide.getThumbnail(options, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getImage) med `options, scale_x, scale_y` |
| `slide.getThumbnail(options, image_size)` | [getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getImage) med `options, image_size` |
| `slide.getThumbnail(tiff_options)` | [getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getImage) med `tiff_options` |
| `slide.getThumbnail(image_size)` | [getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getImage) med `image_size` |
| `slide.renderToGraphics(options, graphics)` | Ingen direkt ersättning; rendera till en bild istället |
| `slide.renderToGraphics(options, graphics, scale_x, scale_y)` | Ingen direkt ersättning; rendera till en bild istället |
| `slide.renderToGraphics(options, graphics, image_size)` | Ingen direkt ersättning; rendera till en bild istället |

Här är `options` ett [RenderingOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/renderingoptions/), och `tiff_options` är ett [TiffOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/tiffoptions/).

### **Output**

| Gammalt anrop | Modern ersättning |
| --- | --- |
| `output.add(path, buffered_image)` | [Output.add](https://reference.aspose.com/slides/sv/python-java/aspose.slides/output/#add) med `path, image`, där `image` är ett [IImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/iimage/) |

### **ImageCollection**

| Gammalt anrop | Modern ersättning |
| --- | --- |
| `collection.addImage(buffered_image)` | [ImageCollection.addImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagecollection/#addImage) med ett [IImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/iimage/) |

### **PPImage**

| Gammalt anrop | Modern ersättning |
| --- | --- |
| `picture.getSystemImage()` | [PPImage.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/#getImage) |

För att ersätta innehållet i en befintlig presentationsbild, använd [PPImage.replaceImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/#replaceImage) med ett [IImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/iimage/).

### **PatternFormat**

| Gammalt anrop | Modern ersättning |
| --- | --- |
| `pattern.getTileImage(style_color)` | [PatternFormat.getTile](https://reference.aspose.com/slides/sv/python-java/aspose.slides/patternformat/#getTile) med `style_color` |
| `pattern.getTileImage(background, foreground)` | [PatternFormat.getTile](https://reference.aspose.com/slides/sv/python-java/aspose.slides/patternformat/#getTile) med `background, foreground` |

Färgangivelserna förblir Java [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html)-objekt.

### **PatternFormatEffectiveData**

För effektiv mönsterdata som returneras av Java‑API:t via JPype behåller ersättningsmetoden namnet `getTileIImage`.

| Gammalt anrop | Modern ersättning |
| --- | --- |
| `effective_pattern.getTileImage(background, foreground)` | `effective_pattern.getTileIImage(background, foreground)`, som returnerar ett [IImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/iimage/) |

## **API‑stöd för Graphics2D**

De äldre `renderToGraphics`‑överlagringarna ritade in i ett Graphics2D‑kontext som levererades av anroparen. Det moderna API:t har ingen direkt ersättning som ritar in i detta kontext.

Använd [Slide.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getImage) för att rendera en bild eller [Presentation.getImages](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getImages) för att rendera flera bilder, och spara sedan de returnerade bilderna med [IImage.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/iimage/#save). Applikationer som kombinerade bildrendering med egen Java‑ritning måste anpassa sitt sammansättningssteg.

## **FAQ**

**Varför ersattes det gamla Java‑bild‑API:t?**

Det moderna API:t flyttar bildinläsning, rendering och sparning till [IImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/iimage/). Detta ger dessa arbetsflöden en gemensam bildabstraktion i stället för att exponera Java‑buffrade bilder eller ett Java‑grafik‑kontext.

**Behöver jag fortfarande Java och JPype?**

Ja. Aspose.Slides for Python via Java kör fortfarande på JVM. Det moderna API:t ändrar bildbehandlingsanropen, inte körkraven. Se [System Requirements](/slides/sv/python-java/system-requirements/).

**Hur frigör jag bilder i Python?**

Anropa `dispose` på varje bild du läser in eller renderar i ett `finally`‑block. Om du renderar flera bilder, frigör varje bild i den returnerade arrayen. Frigör presentationen separat med [Presentation.dispose](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#dispose).

**Garanterar byte till det moderna API:t snabbare miniatyrgenerering?**

Ingen förbättring av prestanda är garanterad. Ersättningsmetoderna stödjer renderingsalternativ, skalning och bildstorlekar; mät prestanda med dina presentationer och utskriftsinställningar.

**Varför returnerar bildhämtaren ibland en samling?**

[Presentation.getImages](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getImages) utan argument returnerar inbäddade presentationsbilder. Dess överlagringar med renderingsalternativ returnerar renderade bildbilder.