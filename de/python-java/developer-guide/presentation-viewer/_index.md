---
title: Erstellen eines Präsentationsviewers in Python via Java
linktitle: Präsentationsviewer
type: docs
weight: 50
url: /de/python-java/presentation-viewer/
keywords:
- Präsentation anzeigen
- Präsentationsviewer
- Präsentationsviewer erstellen
- PPT anzeigen
- PPTX anzeigen
- ODP anzeigen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erstellen Sie einen benutzerdefinierten Präsentationsviewer in Python via Java mit Aspose.Slides. Zeigen Sie PowerPoint- und OpenDocument-Dateien problemlos ohne Microsoft PowerPoint an."
---
## **Einleitung**

Aspose.Slides für Python via Java wird verwendet, um Präsentationsdateien mit Folien zu erstellen. Diese Folien können beispielsweise durch Öffnen der Präsentationen in Microsoft PowerPoint angezeigt werden. Manchmal müssen Entwickler jedoch Folien als Bilder in ihrem bevorzugten Bildbetrachter anzeigen oder einen eigenen Präsentationsbetrachter erstellen. In solchen Fällen ermöglicht Aspose.Slides den Export einer einzelnen Folie als Bild. Dieser Artikel beschreibt, wie das funktioniert.

## **Ein SVG-Bild aus einer Folie erzeugen**

Um mit Aspose.Slides ein SVG-Bild aus einer Präsentationsfolie zu erzeugen, folgen Sie bitte den nachstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse.
1. Holen Sie die Folienreferenz über ihren Index.
1. Öffnen Sie einen Byte-Stream.
1. Speichern Sie die Folie als SVG-Bild in den Stream und schreiben Sie sie in eine Datei.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import ByteArrayOutputStream

slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **SVG mit benutzerdefinierter Shape-ID erzeugen**

Aspose.Slides kann verwendet werden, um ein [SVG](https://docs.fileformat.com/page-description-language/svg/) aus einer Folie mit einer benutzerdefinierten Shape-ID zu erzeugen. Verwenden Sie dazu die Methode [SvgShape.setId](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgshape/#setId) von [SvgShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` kann verwendet werden, um die Shape-ID festzulegen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import ByteArrayOutputStream

class CustomSvgShapeFormattingController:
    def __init__(self, shape_start_index=0):
        self.shape_index = shape_start_index

    def formatShape(self, svg_shape, shape):
        svg_shape.setId(f"shape-{self.shape_index}")
        self.shape_index += 1


slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    controller = CustomSvgShapeFormattingController()
    controller_proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(controller_proxy)

    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream, svg_options)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Miniaturbild einer Folie erstellen**

Aspose.Slides unterstützt Sie beim Erzeugen von Miniaturbildern von Folien. Um mit Aspose.Slides ein Miniaturbild einer Folie zu erzeugen, folgen Sie bitte den nachstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse.
1. Holen Sie die Folienreferenz über ihren Index.
1. Erhalten Sie das Miniaturbild der referenzierten Folie in einem definierten Maßstab.
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat

slide_index = 0
scale_x = 1.0
scale_y = scale_x

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(scale_x, scale_y)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Miniaturbild einer Folie mit benutzerdefinierten Abmessungen erstellen**

Um ein Miniaturbild einer Folie mit benutzerdefinierten Abmessungen zu erzeugen, folgen Sie bitte den nachstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse.
1. Holen Sie die Folienreferenz über ihren Index.
1. Erhalten Sie das Miniaturbild der referenzierten Folie mit den definierten Abmessungen.
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat
from java.awt import Dimension

slide_index = 0
slide_size = Dimension(1200, 800)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(slide_size)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Miniaturbild einer Folie mit Sprechernotizen erstellen**

Um mit Aspose.Slides ein Miniaturbild einer Folie mit Sprechernotizen zu erzeugen, folgen Sie bitte den nachstehenden Schritten:

1. Erstellen Sie eine Instanz der [RenderingOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/renderingoptions/) Klasse.
1. Verwenden Sie die Methode [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) um die Position der Sprechernotizen festzulegen.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse.
1. Holen Sie die Folienreferenz über ihren Index.
1. Erhalten Sie das Miniaturbild der referenzierten Folie mit den Rendering-Optionen.
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, RenderingOptions

slide_index = 0
layouting_options = NotesCommentsLayoutingOptions()
layouting_options.setNotesPosition(NotesPositions.BottomTruncated)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layouting_options)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(rendering_options)
    try:
        image.save("output.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Live-Beispiel**

Sie können die kostenlose Anwendung [**Aspose.Slides Viewer**](https://products.aspose.app/slides/de/viewer/) ausprobieren, um zu sehen, was Sie mit der Aspose.Slides‑API implementieren können:

![Online-PowerPoint-Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Kann ich einen Präsentationsbetrachter in eine Webanwendung einbetten?**

Ja. Sie können Aspose.Slides serverseitig verwenden, um Folien als Bilder oder HTML zu rendern und im Browser anzuzeigen. Navigations- und Zoom‑Funktionen können mit JavaScript für ein interaktives Erlebnis implementiert werden.

**Was ist die beste Methode, um Folien in einem benutzerdefinierten Viewer anzuzeigen?**

Der empfohlene Ansatz besteht darin, jede Folie als Bild (z. B. PNG oder SVG) zu rendern oder mit Aspose.Slides in HTML zu konvertieren und die Ausgabe dann in einer Bildbox (für Desktop) oder einem HTML‑Container (für Web) anzuzeigen.

**Wie gehe ich mit großen Präsentationen mit vielen Folien um?**

Bei großen Decks sollten Sie ein Lazy‑Loading oder ein Rendering on‑Demand von Folien in Betracht ziehen. Das bedeutet, den Inhalt einer Folie nur zu erzeugen, wenn der Benutzer zu ihr navigiert, wodurch Speicher- und Ladezeiten reduziert werden.