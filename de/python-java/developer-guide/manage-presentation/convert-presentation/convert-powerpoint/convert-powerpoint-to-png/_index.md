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
description: "PowerPoint-Folien in PNG-Bildern in Python über Java konvertieren. PPT-, PPTX- und ODP-Präsentationen mit benutzerdefinierten Skalen oder genauen Bildabmessungen exportieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie Sie Präsentationsfolien mit Aspose.Slides für Python über Java in PNG‑Bilder konvertieren. Sie können Präsentationen in Formaten wie PPT, PPTX und ODP laden, jede Folie rendern und sie als separate PNG‑Bilddatei speichern.

Die nachstehenden Beispiele zeigen das Rendering in der Standardskala, das Erhöhen der Skalierung, das Festlegen der Ausgabedimensionen in Pixeln und die Auswahl eines Gradienten‑Renderstils.

## **PowerPoint in PNG konvertieren**

Laden Sie eine Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) und greifen Sie über die Sammlung [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) auf ihre Folien zu. Das Beispiel rendert jede Folie mit [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) ohne Parameter, um ein Miniaturbild zu erzeugen. Anschließend wird [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) mit [ImageFormat.Png](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/#Png) aufgerufen, um jede gerenderte Folie als PNG‑Bild zu speichern.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage()
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}

Die parameterlose Überladung von [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) rendert mit einer Skalierung von 0,2. Beispielsweise erzeugt eine Folie mit 720 × 540 Punkten ein Miniaturbild von 144 × 108 Pixel. Um die Ausgabedimensionen zu steuern, verwenden Sie die Überladungen mit Skalierungsfaktoren oder einer expliziten Bildgröße, wie unten gezeigt.

{{% /alert %}}

## **PowerPoint in PNG mit benutzerdefinierten Abmessungen konvertieren**

Übergeben Sie horizontale und vertikale Skalierungsfaktoren an [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage), um die gerenderten Abmessungen zu steuern. In diesem Beispiel sind beide Faktoren 2, sodass eine Folie mit 720 × 540 Punkten ein Bild von 1440 × 1080 Pixel erzeugt. Gleiche Skalierungsfaktoren erhalten das Seitenverhältnis der Folie. Jedes gerenderte Bild wird im PNG‑Format gespeichert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = scale_x

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **PowerPoint in PNG mit benutzerdefinierter Größe konvertieren**

Um Ausgabedimensionen in Pixeln festzulegen, übergeben Sie an [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) eine Größe anstelle von Skalierungsfaktoren. Dieses Beispiel rendert jede Folie mit 960 × 720 Pixel und speichert das Ergebnis im PNG‑Format. Wählen Sie Dimensionen, die dem Seitenverhältnis der Folie entsprechen, um ein Verzerren des Bildes zu vermeiden.

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

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(image_size)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Einen Gradienten‑Renderstil auswählen**

Angenommen, eine Folie enthält Farbverläufe, aber die Übergänge im exportierten PNG erscheinen heller oder anders als in PowerPoint. Sie können die Methode [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setGradientStyle), die von [RenderingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/) geerbt wird, verwenden, um zu bestimmen, wie die Verläufe gerendert werden.

Laden Sie die Datei [gradient-styles.pptx](gradient-styles.pptx) herunter und legen Sie sie im Arbeitsverzeichnis der Anwendung ab. Die erste Folie enthält zwei lineare Verläufe: Cyan zu Orange oben und Blau zu Gelb unten. Jeder Verlauf hat zwei Stopps bei 0 % und 100 %.

Das folgende Beispiel lädt diese Präsentation und rendert dieselbe erste Folie in beiden Modi mit [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GradientStyle, ImageFormat, Presentation, RenderingOptions

presentation = Presentation("gradient-styles.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    gradient_styles = (GradientStyle.Default, GradientStyle.PowerPointUI)
    for style in gradient_styles:
        options = RenderingOptions()
        options.setGradientStyle(style)

        style_name = "Default" if style == GradientStyle.Default else "PowerPointUI"
        image = slide.getImage(options, 1.0, 1.0)
        try:
            image.save(f"gradient-{style_name}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

Die Bilder unten zeigen das Ergebnis derselben Folie, wobei beide Verläufe in jedem Bild zu sehen sind:

| Default | PowerPointUI |
| --- | --- |
| ![Cyan-zu-Orange- und Blau-zu-Gelb-Gradienten, gerendert mit Default](gradient-Default.png) | ![Die gleichen Gradienten, gerendert mit PowerPointUI](gradient-PowerPointUI.png) |

In diesem Beispiel erzeugt `Default` hellere Zwischenfarben, während `PowerPointUI` dunklere Zwischenfarben liefert. Der Unterschied hängt von den Farben und Stopps im Verlauf ab.

Wählen Sie `Default`, wenn die standardmäßige Aspose.Slides‑Ausgabe Ihren Anforderungen entspricht. Verwenden Sie `PowerPointUI`, wenn Ihre Priorität darin liegt, das Erscheinungsbild in PowerPoint möglichst genau nachzubilden. Vergleichen Sie beide Ausgaben mit Ihrem gewünschten Ergebnis; keine der beiden Optionen ist allgemein vorzuziehen.

## **FAQ**

**Wie kann ich eine bestimmte Form, z. B. ein Diagramm oder ein Bild, exportieren, anstatt die gesamte Folie?**

Aspose.Slides unterstützt das [Erstellen von Miniaturansichten für einzelne Formen](/slides/de/python-java/create-shape-thumbnails/), wodurch Sie eine Form als PNG‑Bild rendern können.

**Wird die parallele Konvertierung auf einem Server unterstützt?**

Ja. Verwenden Sie für jeden Thread oder Prozess eine separate Präsentationsinstanz; [nicht eine einzelne Instanz über Threads hinweg teilen](/slides/de/python-java/multithreading/).

**Was sind die Einschränkungen der Evaluierung bei der PNG‑Exportfunktion?**

Der Evaluierungsmodus fügt den Ausgabebildern ein Wasserzeichen hinzu und wendet [andere Einschränkungen](/slides/de/python-java/licensing/) an, bis eine Lizenz installiert ist.