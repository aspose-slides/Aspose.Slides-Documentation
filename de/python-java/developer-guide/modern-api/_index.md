---
title: Bildverarbeitung mit der Modernen API in Python verbessern
linktitle: Moderne API
type: docs
weight: 237
url: /de/python-java/modern-api/
keywords:
- moderne API
- Zeichnen
- Folien-Thumbnail
- Folie zu Bild
- Form-Thumbnail
- Form zu Bild
- Präsentations-Thumbnail
- Präsentation zu Bildern
- Bild hinzufügen
- Bild einfügen
- Python
- Java
- Aspose.Slides
description: "Modernisieren Sie die Bildverarbeitung in Python über Java: Rendern Sie Folien und Formen, fügen Sie Bilder hinzu und migrieren Sie veraltete Bildaufrufe zur Aspose.Slides Modernen API."
---
## **Einleitung**

Aspose.Slides for Python via Java greift über JPype auf die Java‑Bibliothek zu. Die veraltete Bildverarbeitungs‑API nutzte [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) und [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) aus `java.awt`.

Die Java‑Bibliothek hat diese Bild‑APIs ab Version 24.4 veraltet. Die Moderne API verwendet [IImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/iimage/), um Bilder zu laden, zu rendern und zu speichern. Verwenden Sie sie für neuen Python‑Code und beim Migrieren bestehender Bildverarbeitungs‑Workflows.

{{% alert color="info" title="Hinweis" %}}

Die unten stehenden alten Methodennamen dienen nur als Migrationsreferenz. Sie sind in aktuellen Releases nicht mehr verfügbar. Die ausführbaren Beispiele nutzen die Moderne API.

Diese Änderung entfernt nicht jeden `java.awt`‑Typ: Überladungen für Bildgröße und Musterfarbe akzeptieren weiterhin [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) und [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html).

{{% /alert %}}

## **Moderne API**

Die wichtigsten Bild‑Verarbeitungstypen sind:

- [IImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/iimage/) — repräsentiert ein Raster‑ oder Vektorbild.
- [ImageFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/imageformat/) — liefert Konstanten für Bilddateiformate.
- [Images](https://reference.aspose.com/slides/de/python-java/aspose.slides/images/) — erstellt Bilder, zum Beispiel mit [Images.fromFile](https://reference.aspose.com/slides/de/python-java/aspose.slides/images/#fromFile).

Verwenden Sie [Slide.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getImage) oder [Shape.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getImage), um eine Folie bzw. ein Shape zu rendern. Verwenden Sie [Presentation.getImages](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getImages) mit Rendering‑Optionen, um mehrere Folien zu rendern. Die Überladung ohne Argumente gibt stattdessen die Bildsammlung der Präsentation zurück.

Laden Sie ein Bild mit [Images.fromFile](https://reference.aspose.com/slides/de/python-java/aspose.slides/images/#fromFile), fügen Sie es mit [ImageCollection.addImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagecollection/#addImage) hinzu oder aktualisieren Sie ein vorhandenes Präsentationsbild mit [PPImage.replaceImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/#replaceImage). Beide Bild‑Sammlungs‑Operationen akzeptieren [IImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/iimage/).

Geben Sie jedes Bild, das Sie laden oder rendern, über seinen `dispose`‑Methodenaufruf in einem `finally`‑Block frei. Geben Sie die Präsentation mit [Presentation.dispose](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#dispose) frei.

### **Umgebung für Python vorbereiten**

Installieren Sie die Pakete wie in [Installation](/slides/de/python-java/installation/) beschrieben. Jedes Beispiel importiert `asposeslides`, bevor die JVM gestartet wird, und importiert anschließend die API, nachdem die JVM läuft. Die Beispiele lassen die JVM aktiv, damit sie wiederverwendet werden kann. Siehe [Einschränkungen und API‑Unterschiede](/slides/de/python-java/limitations-and-api-differences/#import-the-library) für Hinweise zu Notebook‑ und JVM‑Lebenszyklus.

Beispiele, die `pres.pptx` öffnen, benötigen eine Präsentation im Arbeitsverzeichnis. Beispiele, die `image.png` laden, benötigen eine vorhandene Bilddatei.

### **Bild laden und Folie rendern**

Dieses Beispiel fügt der ersten Folie ein Bild hinzu und speichert die Folie als JPEG‑Bild. [IImage.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/iimage/#save) schreibt das gerenderte Bild im angegebenen Format.

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

## **Alten Code durch Moderne API ersetzen**

Ersetzen Sie veraltete Thumbnail‑Aufrufe durch Methoden, die [IImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/iimage/) zurückgeben, und speichern Sie das Ergebnis mit [IImage.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/iimage/#save). Damit entfällt die Notwendigkeit, gerenderte Bilder an [ImageIO.write](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#write-java.awt.image.RenderedImage-java.lang.String-java.io.File-) zu übergeben.

### **Eine Folie in einer angegebenen Größe rendern**

Ersetzen Sie den veralteten Aufruf `slide.getThumbnail(image_size)` durch [Slide.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getImage) mit derselben Bildgröße.

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

### **Ein Folien‑Thumbnail erhalten**

Ersetzen Sie den veralteten Aufruf `slide.getThumbnail()` durch [Slide.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getImage) ohne Argumente.

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

### **Ein Shape‑Thumbnail erhalten**

Ersetzen Sie den veralteten Aufruf `shape.getThumbnail()` durch [Shape.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getImage). Stellen Sie sicher, dass die Folie ein Shape enthält, bevor Sie darauf zugreifen.

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

### **Ein Präsentations‑Thumbnail erhalten**

Ersetzen Sie den veralteten Aufruf `presentation.getThumbnails(options, image_size)` durch [Presentation.getImages](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getImages). Verwenden Sie [RenderingOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/renderingoptions/), um das Rendering zu konfigurieren.

Iterieren Sie direkt über das zurückgegebene Array mit Python‑`enumerate`. Geben Sie jedes zurückgegebene Bild in einem `finally`‑Block frei, damit ein Speicher‑Fehler nicht dazu führt, dass verbleibende Bilder nicht freigegeben werden.

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

### **Ein Bild zu einer Präsentation hinzufügen**

Ersetzen Sie das Laden über [ImageIO.read](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#read-java.io.File-) durch [Images.fromFile](https://reference.aspose.com/slides/de/python-java/aspose.slides/images/#fromFile) und übergeben Sie das resultierende Bild anschließend an [ImageCollection.addImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagecollection/#addImage). Fügen Sie das Bild der Folie hinzu und speichern Sie die Präsentation.

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

## **Veraltete Methoden und deren Ersatz in der Modernen API**

Die Tabellen verwenden Python‑Aufrufnotation. Die Namen in der Legacy‑Spalte zeigen entfernte APIs; verwenden Sie die verlinkten Ersatzmethoden. Die modernen Bild‑Render‑Methoden geben [IImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/iimage/)‑Objekte zurück statt Java‑BufferedImages.

### **Presentation**

[Presentation.getImages](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getImages) gibt ein Array gerenderter Bilder zurück, wenn es mit Rendering‑Optionen aufgerufen wird.

| Legacy‑Aufruf | Moderne Alternative |
| --- | --- |
| `presentation.getThumbnails(options)` | [getImages](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getImages) mit `options` |
| `presentation.getThumbnails(options, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getImages) mit `options, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides)` | [getImages](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getImages) mit `options, slides` |
| `presentation.getThumbnails(options, slides, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getImages) mit `options, slides, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides, image_size)` | [getImages](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getImages) mit `options, slides, image_size` |
| `presentation.getThumbnails(options, image_size)` | [getImages](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getImages) mit `options, image_size` |

Hierbei ist `slides` ein Java‑`int[]` mit ein‑basierten Foliennummern; erstellen Sie es mit `jpype.JArray(jpype.JInt)([1, 3])`, um die Folien 1 und 3 auszuwählen. `image_size` ist eine [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html).

### **Shape**

| Legacy‑Aufruf | Moderne Alternative |
| --- | --- |
| `shape.getThumbnail()` | [getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getImage) ohne Argumente |
| `shape.getThumbnail(bounds, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getImage) mit `bounds, scale_x, scale_y` |

### **Slide**

| Legacy‑Aufruf | Moderne Alternative |
| --- | --- |
| `slide.getThumbnail()` | [getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getImage) ohne Argumente |
| `slide.getThumbnail(scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getImage) mit `scale_x, scale_y` |
| `slide.getThumbnail(options)` | [getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getImage) mit `options` |
| `slide.getThumbnail(options, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getImage) mit `options, scale_x, scale_y` |
| `slide.getThumbnail(options, image_size)` | [getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getImage) mit `options, image_size` |
| `slide.getThumbnail(tiff_options)` | [getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getImage) mit `tiff_options` |
| `slide.getThumbnail(image_size)` | [getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getImage) mit `image_size` |
| `slide.renderToGraphics(options, graphics)` | Keine direkte Entsprechung; stattdessen zu einem Bild rendern |
| `slide.renderToGraphics(options, graphics, scale_x, scale_y)` | Keine direkte Entsprechung; stattdessen zu einem Bild rendern |
| `slide.renderToGraphics(options, graphics, image_size)` | Keine direkte Entsprechung; stattdessen zu einem Bild rendern |

Hierbei ist `options` ein [RenderingOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/renderingoptions/), und `tiff_options` ist ein [TiffOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffoptions/).

### **Output**

| Legacy‑Aufruf | Moderne Alternative |
| --- | --- |
| `output.add(path, buffered_image)` | [Output.add](https://reference.aspose.com/slides/de/python-java/aspose.slides/output/#add) mit `path, image`, wobei `image` ein [IImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/iimage/) ist |

### **ImageCollection**

| Legacy‑Aufruf | Moderne Alternative |
| --- | --- |
| `collection.addImage(buffered_image)` | [ImageCollection.addImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagecollection/#addImage) mit einem [IImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/iimage/) |

### **PPImage**

| Legacy‑Aufruf | Moderne Alternative |
| --- | --- |
| `picture.getSystemImage()` | [PPImage.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/#getImage) |

Um den Inhalt eines bestehenden Präsentationsbildes zu ersetzen, verwenden Sie [PPImage.replaceImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/#replaceImage) mit einem [IImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/iimage/).

### **PatternFormat**

| Legacy‑Aufruf | Moderne Alternative |
| --- | --- |
| `pattern.getTileImage(style_color)` | [PatternFormat.getTile](https://reference.aspose.com/slides/de/python-java/aspose.slides/patternformat/#getTile) mit `style_color` |
| `pattern.getTileImage(background, foreground)` | [PatternFormat.getTile](https://reference.aspose.com/slides/de/python-java/aspose.slides/patternformat/#getTile) mit `background, foreground` |

Die Farb‑Parameter bleiben Java‑[Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html)‑Objekte.

### **PatternFormatEffectiveData**

Für effektive Musterdaten, die von der Java‑API über JPype zurückgegeben werden, behält die Ersatzmethode den Namen `getTileIImage`.

| Legacy‑Aufruf | Moderne Alternative |
| --- | --- |
| `effective_pattern.getTileImage(background, foreground)` | `effective_pattern.getTileIImage(background, foreground)`, liefert ein [IImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/iimage/) |

## **API‑Unterstützung für Graphics2D**

Die veralteten `renderToGraphics`‑Überladungen zeichneten in einen vom Aufrufer bereitgestellten [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)‑Kontext. Die Moderne API bietet keinen direkten Ersatz, der in diesen Kontext zeichnet.

Verwenden Sie [Slide.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getImage), um eine Folie zu rendern, oder [Presentation.getImages](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getImages), um mehrere Folien zu rendern, und speichern Sie die zurückgegebenen Bilder mit [IImage.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/iimage/#save). Anwendungen, die das Folien‑Rendering mit eigenem Java‑Zeichnen kombinierten, müssen den Kompositionsschritt anpassen.

## **FAQ**

**Warum wurde die alte Java‑Bild‑API ersetzt?**

Die Moderne API verlagert Laden, Rendern und Speichern von Bildern auf [IImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/iimage/). Dadurch erhalten diese Workflows eine einheitliche Bildabstraktion anstelle von Java‑BufferedImages oder einem Java‑Graphics‑Kontext.

**Benötige ich weiterhin Java und JPype?**

Ja. Aspose.Slides for Python via Java läuft weiterhin auf der JVM. Die Moderne API ändert nur die Bild‑Verarbeitungs‑Aufrufe, nicht die Laufzeit‑Voraussetzungen. Siehe [System Requirements](/slides/de/python-java/system-requirements/).

**Wie gebe ich Bilder in Python frei?**

Rufen Sie `dispose` für jedes Bild, das Sie laden oder rendern, in einem `finally`‑Block auf. Wenn Sie mehrere Folien rendern, geben Sie jedes Bild im zurückgegebenen Array frei. Geben Sie die Präsentation separat mit [Presentation.dispose](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#dispose) frei.

**Garantiert der Umstieg auf die Moderne API schnellere Thumbnail‑Erstellung?**

Eine Leistungssteigerung ist nicht garantiert. Die Ersatzmethoden unterstützen Rendering‑Optionen, Skalierung und Bildgrößen; messen Sie die Leistung mit Ihren Präsentationen und Ausgabeeinstellungen.

**Warum gibt der Bild‑Getter manchmal eine Sammlung zurück?**

[Presentation.getImages](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getImages) ohne Argumente gibt eingebettete Präsentationsbilder zurück. Die Überladungen mit Rendering‑Optionen geben gerenderte Folienbilder zurück.