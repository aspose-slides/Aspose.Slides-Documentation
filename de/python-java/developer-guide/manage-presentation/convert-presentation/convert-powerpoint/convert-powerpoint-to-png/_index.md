---
title: PowerPoint-Folien in PNG konvertieren in Python
linktitle: PowerPoint zu PNG
type: docs
weight: 30
url: /de/python-java/convert-powerpoint-to-png/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu PNG
- Präsentation zu PNG
- Folie zu PNG
- PPT zu PNG
- PPTX zu PNG
- PPT als PNG speichern
- PPTX als PNG speichern
- PPT nach PNG exportieren
- PPTX nach PNG exportieren
- Python
- Java
- Aspose.Slides
description: "PowerPoint-Folien in PNG-Bilder in Python via Java konvertieren. PPT-, PPTX- und ODP-Präsentationen mit benutzerdefinierten Skalierungen oder genauen Bildabmessungen exportieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint‑Präsentationen mit Aspose.Slides für Python via Java in PNG‑Bilder konvertiert. Sie können PPT-, PPTX‑ und ODP‑Dateien laden, jede Folie rendern und als separate PNG‑Datei speichern.

Die Beispiele zeigen zudem, wie man die Ausgabedimensionen mit Skalierungsfaktoren oder einer genauen Breite und Höhe steuern kann. Jeder Beispielcode startet bei Bedarf die Java‑Virtual‑Machine und gibt Präsentations‑ sowie Bildressourcen nach der Verwendung frei.

## **PowerPoint in PNG konvertieren**

1. Laden Sie die Eingabedatei mit der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
2. Rufen Sie die Folien über [Presentation.getSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSlides) ab.
3. Rendern Sie jede Folie mit [Slide.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getImage).
4. Speichern Sie jedes gerenderte Bild mit [ImageFormat.Png](https://reference.aspose.com/slides/de/python-java/aspose.slides/imageformat/#Png) und geben Sie anschließend dessen Ressourcen frei.

Das folgende Python‑Beispiel exportiert alle Folien in ihrer Standardgröße:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage()
        try:
            slide_image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **PowerPoint in PNG mit benutzerdefinierter Skalierung konvertieren**

Übergeben Sie horizontale und vertikale Skalierungsfaktoren an [Slide.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getImage), um die Ausgabedimensionen zu vergrößern oder zu verkleinern. Zum Beispiel erzeugt eine 720 × 540‑Punkt‑Folie, die mit einem Skalierungsfaktor von 2 auf beiden Achsen gerendert wird, ein 1440 × 1080‑Pixel‑Bild.

Verwenden Sie gleiche Skalierungsfaktoren, um das Seitenverhältnis der Folie beizubehalten. Unterschiedliche Faktoren strecken die Folie horizontal bzw. vertikal.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = 2.0
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"slide_scaled_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **PowerPoint in PNG mit benutzerdefinierter Größe konvertieren**

Um genaue Pixelabmessungen anzugeben, übergeben Sie ein Java‑`Dimension`‑Objekt mit gewünschter Breite und Höhe an [Slide.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getImage). Wählen Sie Abmessungen mit demselben Seitenverhältnis wie die Quellfolie, um Verzerrungen zu vermeiden.

Das folgende Beispiel speichert jede Folie als 960 × 720‑Pixel‑PNG‑Bild:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(image_size)
        try:
            slide_image.save(f"slide_sized_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Kann ich eine einzelne Form, beispielsweise ein Diagramm oder Bild, statt der gesamten Folie exportieren?**

Ja. Aspose.Slides unterstützt das [Erzeugen von Thumbnails für einzelne Formen](/slides/de/python-java/create-shape-thumbnails/), die Sie als PNG‑Bilder speichern können.

**Kann ich Präsentationen parallel auf einem Server konvertieren?**

Verwenden Sie für jeden Thread oder Prozess eine separate Präsentationsinstanz und eindeutige Ausgabepfade, um ein Überschreiben von Dateien zu vermeiden. Teilen Sie keine Präsentationsinstanz zwischen Threads. Siehe [Multithreading](/slides/de/python-java/multithreading/).

**Welche Einschränkungen gibt es in der Testversion beim Export nach PNG?**

Der Evaluierungsmodus fügt den Ausgabebildern ein Wasserzeichen hinzu und wendet [weitere Beschränkungen](/slides/de/python-java/licensing/) an. Durch das Anwenden einer Lizenz werden diese Einschränkungen entfernt.