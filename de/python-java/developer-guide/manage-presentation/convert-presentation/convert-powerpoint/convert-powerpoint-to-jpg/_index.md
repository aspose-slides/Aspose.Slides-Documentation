---
title: PPT und PPTX in JPG konvertieren in Python
linktitle: PowerPoint zu JPG
type: docs
weight: 60
url: /de/python-java/convert-powerpoint-to-jpg/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PowerPoint zu JPG
- PPT zu JPG
- PPTX zu JPG
- Folie als JPG speichern
- PPT nach JPG exportieren
- PPTX nach JPG exportieren
- Python
- Java
- Aspose.Slides
description: "PowerPoint-Folien (PPT, PPTX) in JPG-Bilder in Python via Java konvertieren. Benutzerdefinierte Bildabmessungen festlegen und Notizen sowie Kommentare mit Aspose.Slides rendern."
---
## **Einleitung**

Aspose.Slides for Python via Java ermöglicht das Konvertieren von PowerPoint- und OpenDocument-Präsentationen (PPT, PPTX und ODP) in JPEG‑Bilder. Sie können jede Folie oder eine ausgewählte Folie exportieren, um Thumbnails zu erstellen, einen Präsentations‑Viewer aufzubauen oder Folienvorschauen in einer Website oder Anwendung einzubetten.

## **PowerPoint PPT/PPTX in JPG konvertieren**

1. Laden Sie die Präsentation mit [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
2. Rufen Sie die Folien mit [getSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSlides) ab.
3. Rufen Sie [Slide.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getImage) mit horizontalen und vertikalen Skalierungsfaktoren auf, um jede Folie zu rendern.
4. Speichern Sie jedes gerenderte Bild als JPEG mit [ImageFormat.Jpeg](https://reference.aspose.com/slides/de/python-java/aspose.slides/imageformat/#Jpeg) und geben Sie dann die Bildressourcen frei.

{{% alert color="info" title="Hinweis" %}}
Das Exportieren nach JPG erzeugt für jede Folie ein separates Bild. Speichern Sie das gerenderte Bild, anstatt die Präsentation direkt in ein Bildformat zu speichern.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        slide_image = slide.getImage(1.0, 1.0)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **PowerPoint PPT/PPTX in JPG mit benutzerdefinierten Abmessungen konvertieren**

Berechnen Sie horizontale und vertikale Skalierungsfaktoren anhand der gewünschten Pixelabmessungen und der Originalgröße der Folie und übergeben Sie diese an [Slide.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getImage). Das folgende Beispiel erzeugt ein Bild von 1200 × 800 Pixel für jede Folie.

Die Verwendung unterschiedlicher Skalierungsfaktoren kann die Folie strecken. Um das Seitenverhältnis beizubehalten, verwenden Sie denselben Skalierungsfaktor für beide Achsen; die resultierende Breite und Höhe entsprechen dann den ursprünglichen Folienproportionen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    desired_width = 1200
    desired_height = 800
    slide_size = presentation.getSlideSize().getSize()
    scale_x = desired_width / slide_size.getWidth()
    scale_y = desired_height / slide_size.getHeight()

    for slide in presentation.getSlides():
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Kommentare beim Speichern von Folien als Bilder rendern**

Verwenden Sie [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/notescommentslayoutingoptions/), um Notizen und Kommentare zu konfigurieren, und wenden Sie das Layout über [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) an. Dieses Beispiel positioniert Notizen am unteren Rand, schneidet nicht passende Notizen ab und zeigt Kommentare rechts in einem 200 Pixel breiten Bereich an. Es speichert jede gerenderte Folie als JPG‑Bild.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomTruncated)
    layout_options.setCommentsPosition(CommentsPositions.Right)
    layout_options.setCommentsAreaWidth(200)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout_options)
    image_size = Dimension(740, 960)

    for slide in presentation.getSlides():
        slide_image = slide.getImage(rendering_options, image_size)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Kann ich mehrere Folien oder Präsentationen in JPG konvertieren?**

Ja. Die Beispiele durchlaufen alle Folien und speichern für jede Folie ein JPG. Um mehrere Präsentationen zu verarbeiten, wiederholen Sie die Konvertierung für jede Eingabedatei und verwenden Sie separate Ausgabeverzeichnisse oder eindeutige Dateinamen, um ein Überschreiben von Bildern zu vermeiden.

**Sind Diagramme, SmartArt, Tabellen und Formen in den Bildern enthalten?**

Diese Objekte werden als Teil der Folie gerendert. Stellen Sie die von der Präsentation verwendeten Schriftarten in der Konvertierungsumgebung bereit, um Unterschiede durch Schriftartersatz zu verringern.

**Wie kann ich den Speicherverbrauch beim Export großer Präsentationen reduzieren?**

Verarbeiten Sie Bilder einzeln, geben Sie jedes Bild nach dem Speichern wieder frei und vermeiden Sie unnötig große Ausgabedimensionen. Der Speicherbedarf hängt vom Folieninhalt und der Bildgröße ab.

## **Siehe auch**

- [PowerPoint in PNG konvertieren](/slides/de/python-java/convert-powerpoint-to-png/).
- [Eine Folie als SVG‑Bild rendern](/slides/de/python-java/render-a-slide-as-an-svg-image/).