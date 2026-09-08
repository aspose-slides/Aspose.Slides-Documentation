---
title: Präsentationshyperlinks in Python via Java verwalten
linktitle: Hyperlink verwalten
type: docs
weight: 20
url: /de/python-java/manage-hyperlinks/
keywords:
- URL hinzufügen
- Hyperlink hinzufügen
- Hyperlink erstellen
- Hyperlink formatieren
- Hyperlink entfernen
- Hyperlink aktualisieren
- Texthyperlink
- Folienhyperlink
- Formhyperlink
- Bildhyperlink
- Videohyperlink
- veränderbarer Hyperlink
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Verwalten Sie Hyperlinks in PowerPoint- und OpenDocument-Präsentationen mühelos mit Aspose.Slides für Python via Java - verbessern Sie Interaktivität und Arbeitsabläufe in wenigen Minuten."
---
## **Einführung**

Ein Hyperlink ist ein Verweis auf ein Objekt, Daten oder einen Ort in etwas. Dies sind gängige Hyperlinks in PowerPoint‑Präsentationen:

* Links zu Websites innerhalb von Texten, Formen oder Medien
* Links zu Folien

Aspose.Slides für Python via Java ermöglicht es Ihnen, zahlreiche Aufgaben im Zusammenhang mit Hyperlinks in Präsentationen durchzuführen. 

{{% alert color="info" title="Hinweis" %}} 
Sie können den einfachen, [kostenlosen Online‑PowerPoint‑Editor](https://products.aspose.app/slides/de/editor) von Aspose ausprobieren.
{{% /alert %}} 

## **URL‑Hyperlinks hinzufügen**

### **URL‑Hyperlinks zu Text hinzufügen**

Dieser Python‑Code zeigt, wie Sie einem Text einen Website‑Hyperlink hinzufügen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **URL‑Hyperlinks zu Formen oder Rahmen hinzufügen**

Dieses Beispiel in Python via Java zeigt, wie Sie einer Form einen Website‑Hyperlink hinzufügen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **URL‑Hyperlinks zu Medien hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von Hyperlinks zu Bildern, Audio‑ und Videodateien. 

Dieser Beispielcode zeigt, wie Sie einem **Bild** einen Hyperlink hinzufügen:

```python
import jpype
import asposeslides

if not jpase.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    # Fügt Bild zur Präsentation hinzu
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    # Erstellt Bildrahmen auf Folie 1 basierend auf dem vorher hinzugefügten Bild
    picture_frame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    picture_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    picture_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dieser Beispielcode zeigt, wie Sie einer **Audiodatei** einen Hyperlink hinzufügen:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = presentation.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio)

    audio_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    audio_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dieser Beispielcode zeigt, wie Sie einem **Video** einen Hyperlink hinzufügen:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.avi").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video)

    video_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    video_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tipp" %}} 
Sie können *[OLE verwalten](/slides/de/python-java/manage-ole/)* ansehen.
{{% /alert %}}

## **Hyperlinks zum Erstellen eines Inhaltsverzeichnisses verwenden**

Da Hyperlinks Verweise auf Objekte oder Orte ermöglichen, können Sie sie zum Erstellen eines Inhaltsverzeichnisses verwenden. 

Dieser Beispielcode zeigt, wie Sie ein Inhaltsverzeichnis mit Hyperlinks erstellen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    content_table = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    content_table.getFillFormat().setFillType(FillType.NoFill)
    content_table.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    content_table.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    content_table.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hyperlinks formatieren**

### **Farbe**

Mit der Eigenschaft [Hyperlink.setColorSource](https://reference.aspose.com/slides/de/python-java/aspose.slides/hyperlink/#setColorSource) in der Klasse [Hyperlink](https://reference.aspose.com/slides/de/python-java/aspose.slides/hyperlink/) können Sie die Farbe von Hyperlinks festlegen und auch Farbinformationen von Hyperlinks abrufen. Die Funktion wurde erstmals in PowerPoint 2019 eingeführt, sodass Änderungen an dieser Eigenschaft nicht für ältere PowerPoint‑Versionen gelten.

Dieser Beispielcode demonstriert einen Vorgang, bei dem Hyperlinks mit unterschiedlichen Farben zur gleichen Folie hinzugefügt wurden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This is a sample of colored hyperlink.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This is a sample of usual hyperlink.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hyperlinks aus Präsentationen entfernen**

### **Hyperlinks aus Text entfernen**

Dieser Python‑Code zeigt, wie Sie den Hyperlink aus einem Text in einer Präsentationsfolie entfernen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, AutoShape

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None:
                for paragraph in text_frame.getParagraphs():
                    for portion in paragraph.getPortions():
                        portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick()

    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Hyperlinks aus Formen oder Rahmen entfernen**

Dieser Python‑Code zeigt, wie Sie den Hyperlink aus einer Form in einer Präsentationsfolie entfernen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        shape.getHyperlinkManager().removeHyperlinkClick()
    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Veränderbarer Hyperlink**

Die Klasse [Hyperlink](https://reference.aspose.com/slides/de/python-java/aspose.slides/hyperlink/) ist veränderbar. Mit dieser Klasse können Sie die Werte folgender Eigenschaften ändern:

- [setTargetFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/hyperlink/#setTargetFrame)
- [setTooltip](https://reference.aspose.com/slides/de/python-java/aspose.slides/hyperlink/#setTooltip)
- [setHistory](https://reference.aspose.com/slides/de/python-java/aspose.slides/hyperlink/#setHistory)
- [setHighlightClick](https://reference.aspose.com/slides/de/python-java/aspose.slides/hyperlink/#setHighlightClick)
- [setStopSoundOnClick](https://reference.aspose.com/slides/de/python-java/aspose.slides/hyperlink/#setStopSoundOnClick)

Der Codeausschnitt zeigt, wie Sie einer Folie einen Hyperlink hinzufügen und später dessen Tooltip bearbeiten:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    # Ändert den Tooltip des bereits hinzugefügten Hyperlinks
    portion_format.getHyperlinkClick().setTooltip("Aspose: the File Format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Unterstützte Eigenschaften in HyperlinkQueries**

Sie können [HyperlinkQueries](https://reference.aspose.com/slides/de/python-java/aspose.slides/hyperlinkqueries/) von einer Präsentation, Folie oder einem Text, für den der Hyperlink definiert ist, abrufen. 

- [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getHyperlinkQueries)
- [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#getHyperlinkQueries)

Die Klasse [HyperlinkQueries](https://reference.aspose.com/slides/de/python-java/aspose.slides/hyperlinkqueries/) unterstützt diese Methoden und Eigenschaften: 

- [getHyperlinkClicks](https://reference.aspose.com/slides/de/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks)
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/de/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers)
- [getAnyHyperlinks](https://reference.aspose.com/slides/de/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)
- [removeAllHyperlinks](https://reference.aspose.com/slides/de/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)

## **FAQ**

**Wie kann ich eine interne Navigation nicht nur zu einer Folie, sondern zu einem „Abschnitt“ oder der ersten Folie eines Abschnitts erstellen?**

Abschnitte in PowerPoint sind Gruppierungen von Folien; die Navigation zielt technisch auf eine bestimmte Folie. Um „zu einem Abschnitt zu navigieren“, verlinken Sie typischerweise zu dessen erster Folie.

**Kann ich einem Master‑Folienelement einen Hyperlink zuweisen, sodass er auf allen Folien funktioniert?**

Ja. Master‑Folienelemente und Layout‑Elemente unterstützen Hyperlinks. Solche Links erscheinen auf den untergeordneten Folien und sind während der Diashow anklickbar.

**Werden Hyperlinks beim Exportieren in PDF, HTML, Bilder oder Video beibehalten?**

In [PDF](/slides/de/python-java/convert-powerpoint-to-pdf/) und [HTML](/slides/de/python-java/convert-powerpoint-to-html/) ja – Links werden im Allgemeinen beibehalten. Beim Exportieren in [Bilder](/slides/de/python-java/convert-powerpoint-to-png/) und [Video](/slides/de/python-java/convert-powerpoint-to-video/) bleibt die Klickbarkeit aufgrund der Natur dieser Formate (Raster‑Frames/Video unterstützen keine Hyperlinks) erhalten.