---
title: Präsentationsfolien in Python in Bilder konvertieren
linktitle: Folie zu Bild
type: docs
weight: 35
url: /de/python-java/convert-slide/
keywords: 
- Folie konvertieren
- Folie exportieren
- Folie zu Bild
- Folie als Bild speichern
- Folie zu EMF
- Folie zu PNG
- Folie zu JPEG
- Folie zu Bitmap
- Folie zu TIFF
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Konvertieren Sie Folien aus PPT-, PPTX- und ODP‑Präsentationen in PNG, JPEG, GIF, TIFF, EMF und weitere Bildformate in Python mit Aspose.Slides."
---
## **Einführung**

Aspose.Slides for Python via Java kann einzelne Folien von PowerPoint- und OpenDocument‑Präsentationen als PNG, JPEG, GIF, TIFF und andere Bildformate rendern.

Um eine Folie in ein Bild zu konvertieren, führen Sie folgende Schritte aus:

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) .
2. Wählen Sie die Folie aus, die Sie rendern möchten.
3. Konfigurieren Sie bei Bedarf das Rendering mit der Klasse [RenderingOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/renderingoptions/) oder [TiffOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffoptions/) .
4. Rufen Sie die Methode [Slide.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getImage) auf. Sie gibt ein Bildobjekt zurück.
5. Speichern Sie das Bild und geben Sie das Ausgabeformat mit einem [ImageFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/imageformat/)‑Wert an.

## **Folien in ein PNG‑Bild konvertieren**

Die einfachste Konvertierung verwendet die Standard‑Render‑Einstellungen. Das resultierende Bildobjekt kann im Speicher verarbeitet oder in einer Datei gespeichert werden.

Das folgende Python‑Beispiel rendert die erste Folie und speichert sie als PNG‑Bild:

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

## **Folien mit benutzerdefinierten Größen in Bilder konvertieren**

Verwenden Sie die Überladung von [Slide.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getImage), die einen [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html)‑Wert akzeptiert, um eine Folie mit genauen Pixelmaßen zu rendern.

Das folgende Beispiel erstellt ein JPEG‑Bild mit 1820 × 1040 Pixel:

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

## **Folien mit Notizen und Kommentaren in Bilder konvertieren**

Standardmäßig enthalten Folienbilder keine Notizen oder Kommentare. Übergeben Sie ein [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/notescommentslayoutingoptions/)‑Objekt an die Methode [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions), um zu steuern, wo Notizen und Kommentare angezeigt werden.

Das folgende Beispiel platziert gekürzte Notizen unterhalb der Folie und Kommentare rechts davon:

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
Für die Folien‑zu‑Bild‑Konvertierung übergeben Sie nicht [BottomFull](https://reference.aspose.com/slides/de/python-java/aspose.slides/notespositions/#BottomFull) an die Methode [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/de/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Notizen können mehr Text enthalten, als die feste Bildgröße aufnehmen kann. Verwenden Sie stattdessen [BottomTruncated](https://reference.aspose.com/slides/de/python-java/aspose.slides/notespositions/#BottomTruncated).
{{% /alert %}}

## **Folien in Bilder mit TIFF‑Optionen konvertieren**

Die Klasse [TiffOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffoptions/) ermöglicht die Steuerung von Größe, Auflösung und anderen Eigenschaften des gerenderten TIFF‑Bildes.

Das folgende Beispiel rendert die erste Folie als TIFF‑Bild mit 2160 × 2880 Pixel bei 300 DPI:

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
TIFF‑Unterstützung ist in Java‑Versionen vor JDK 9 nicht garantiert.
{{% /alert %}}

## **Alle Folien in Bilder konvertieren**

Iterieren Sie über die Folien‑Collection, um die gesamte Präsentation in eine Reihe von Bildern zu konvertieren. Versteckte Folien werden einbezogen, sofern Sie sie nicht ausdrücklich überspringen.

Das folgende Beispiel rendert jede Folie als JPEG‑Bild mit horizontalen und vertikalen Skalierungsfaktoren von 2:

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

## **Enhanced Metafile‑Ausgabe erstellen**

Enhanced Metafile (EMF) ist nützlich, wenn vektorbasierten Grafiken mit Microsoft Office oder anderen Windows‑Anwendungen, die Windows‑Metadateien unterstützen, ausgetauscht werden müssen. Im Gegensatz zu einem pixelbasierten Bild kann ein EMF Vektorzeichenoperationen beibehalten, die sich skalieren lassen, ohne dass die Schärfe verloren geht. EMF ist jedoch hauptsächlich ein Kompatibilitätsformat für Anwendungen mit Windows‑Metadatei‑Unterstützung und kein universelles Austauschformat. Darüber hinaus kann komplexer Folieninhalt, wie Bitmap‑Bilder und einige Effekte, als gerasterte Elemente im Vektor‑Metadatei‑Container gespeichert werden.

### **Eine Folie nach EMF exportieren**

Die Methode [Slide.writeAsEmf](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/) schreibt eine [Slide](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/) in einen Ziel‑Stream im EMF‑Format. Das folgende Beispiel lädt eine Präsentation, wählt die erste Folie aus und schreibt sie in einen EMF‑Dateistream:

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

Der Aufrufer besitzt den an [Slide.writeAsEmf](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/) übergebenen Stream und ist für das Schließen verantwortlich, wie oben gezeigt.

### **Ein SVG‑Bild in EMF konvertieren und zu einer Präsentation hinzufügen**

Verwenden Sie [SvgImage.writeAsEmf](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgimage/), um SVG‑Inhalt in EMF zu konvertieren. Die resultierenden Bytes können über [ImageCollection.addImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagecollection/#addImage) zur Präsentation hinzugefügt und mit [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addPictureFrame) auf einer Folie platziert werden.

Das folgende Beispiel erstellt ein [SvgImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgimage/) aus SVG‑Markup, konvertiert es in ein EMF im Speicher, fügt die Metadatei auf der ersten Folie ein und speichert die Präsentation:

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

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgimage/) übernimmt nicht den Besitz des Ziel‑Streams. Ein [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) speichert alle erzeugten Daten im Speicher, sodass vor dem Aufruf von [ByteArrayOutputStream.toByteArray](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html#toByteArray--) kein Zurücksetzen der Position erforderlich ist. Das zurückgegebene Byte‑Array bleibt nach dem Schließen des Streams gültig.

Die EMF‑Erzeugung ist auf den von Aspose.Slides for Python via Java und der JDK‑Konfiguration unterstützten Betriebssystemen verfügbar, jedoch kann das Rendering plattformabhängig variieren, wenn Schriftarten oder Grafik‑Abhängigkeiten nicht verfügbar sind. Installieren Sie die in den Quellinhalten verwendeten Schriftarten oder konfigurieren Sie geeignete Ersatzoptionen, folgen Sie den [platform requirements](/slides/de/python-java/system-requirements/) für Aspose.Slides for Python via Java und prüfen Sie das Ergebnis in der Ziel‑EMF‑verwendenden Anwendung. Linux‑ und macOS‑Anwendungen haben oft eingeschränkte oder inkonsistente Unterstützung für die Anzeige und Bearbeitung von Windows‑Metadateien.

## **Farb‑Emoji‑Rendering**

{{% alert title="Note" color="info" %}}
Um Farbemojis beim Konvertieren von Präsentationsfolien in Bilder korrekt zu rendern, müssen die in der Präsentation verwendeten Emoji‑Schriftarten auf dem System, das die Konvertierung durchführt, installiert und verfügbar sein. Beispielsweise, wenn die Präsentation **Segoe UI Emoji** verwendet und diese Schriftart fehlt, können Emojis in den Ausgabebildern monochrom erscheinen.
{{% /alert %}}

## **FAQ**

**Unterstützt Aspose.Slides das Rendern von Folien mit Animationen?**

Nein. Die Methode [Slide.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getImage) rendert ein statisches Bild der Folie und exportiert keine Animationen.

**Können versteckte Folien als Bilder exportiert werden?**

Ja. Versteckte Folien können wie reguläre Folien gerendert werden. Schließen Sie sie in die Verarbeitungsschleife ein, wie im obigen Beispiel gezeigt.

**Werden Schatten und andere Effekte in Folienbildern beibehalten?**

Ja. Aspose.Slides rendert Schatten, Transparenz und andere unterstützte grafische Effekte in Folienbildern.