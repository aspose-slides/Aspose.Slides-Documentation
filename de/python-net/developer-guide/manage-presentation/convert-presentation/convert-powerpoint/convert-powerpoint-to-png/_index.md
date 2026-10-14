---
title: PowerPoint-Folien in PNG mit Python konvertieren
linktitle: PowerPoint zu PNG
type: docs
weight: 30
url: /de/python-net/convert-powerpoint-to-png/
keywords:
- PowerPoint in PNG konvertieren
- Präsentation in PNG konvertieren
- Folie in PNG konvertieren
- PPT in PNG konvertieren
- PPTX in PNG konvertieren
- ODP in PNG konvertieren
- PowerPoint zu PNG
- Präsentation zu PNG
- Folie zu PNG
- PPT zu PNG
- PPTX zu PNG
- ODP zu PNG
- Python
- Aspose.Slides
description: "PowerPoint- und OpenDocument-Präsentationen schnell in hochwertige PNG-Bilder konvertieren mit Aspose.Slides für Python via .NET, wobei präzise, automatisierte Ergebnisse gewährleistet werden."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Präsentationsfolien in PNG‑Bilder konvertiert, wobei Aspose.Slides für Python via .NET verwendet wird. Sie können Präsentationen in Formaten wie PPT, PPTX und ODP laden, jede Folie rendern und sie als separates PNG‑Bild speichern.

Die nachfolgenden Beispiele demonstrieren das Rendering in der Standardskala, das Erhöhen der Skalierung, das Festlegen der Ausgabedimensionen in Pixeln und die Auswahl eines Gradienten‑Rendering‑Stils.

## **PowerPoint in PNG konvertieren**

Laden Sie eine Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) und greifen Sie über die Sammlung [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) auf die Folien zu. Das Beispiel rendert jede Folie mit [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) ohne Parameter, um ein Miniaturbild zu erzeugen. Anschließend wird [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) mit [ImageFormat.PNG](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) aufgerufen, um jede gerenderte Folie als PNG‑Bild zu speichern.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert color="info" title="Note" %}}
Die parameterlose Überladung von [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) rendert mit einer Skalierung von 0.2. Zum Beispiel erzeugt eine Folie mit den Maßen 720 × 540 Punkte ein Miniaturbild von 144 × 108 Pixel. Um die Ausgabedimensionen zu steuern, verwenden Sie die Überladungen mit Skalierungsfaktoren oder einer expliziten Bildgröße, wie unten gezeigt.
{{% /alert %}}

## **PowerPoint in PNG mit benutzerdefinierten Abmessungen konvertieren**

Übergeben Sie horizontale und vertikale Skalierungsfaktoren an [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/), um die gerenderten Abmessungen zu steuern. In diesem Beispiel sind beide Faktoren 2, sodass eine Folie mit den Maßen 720 × 540 Punkte ein Bild von 1440 × 1080 Pixel erzeugt. Gleiche Skalierungsfaktoren erhalten das Seitenverhältnis der Folie. Jede Bild wird im PNG‑Format mit [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) gespeichert.

```python
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **PowerPoint in PNG mit benutzerdefinierter Größe konvertieren**

Um die Ausgabedimensionen in Pixeln anzugeben, übergeben Sie eine Größe an [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) anstelle von Skalierungsfaktoren. Dieses Beispiel rendert jede Folie mit 960 × 720 Pixeln und speichert das Ergebnis mit [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). Wählen Sie Abmessungen, die dem Seitenverhältnis der Folie entsprechen, um ein Verzerren des Bildes zu vermeiden.

```python
import aspose.slides as slides

image_size = slides.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(image_size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Wählen Sie einen Gradienten-Rendering-Stil**

Angenommen, eine Folie enthält Farbverläufe, aber die Übergänge im exportierten PNG erscheinen heller oder anders als in PowerPoint. Sie können die Eigenschaft [gradient_style](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/gradient_style/) von [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) verwenden, um zu bestimmen, wie die Verläufe gerendert werden.

Laden Sie [gradient-styles.pptx](gradient-styles.pptx) herunter und legen Sie sie im Arbeitsverzeichnis der Anwendung ab. Die erste Folie enthält zwei lineare Verläufe: Cyan zu Orange oben und Blau zu Gelb unten. Jeder Verlauf hat zwei Stoppunkte bei 0 % und 100 %.

Das folgende Beispiel lädt diese Präsentation und rendert die gleiche erste Folie in beiden Modi mit [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/).

```python
import aspose.slides as slides

with slides.Presentation("gradient-styles.pptx") as presentation:
    slide = presentation.slides[0]

    gradient_styles = [slides.GradientStyle.DEFAULT, slides.GradientStyle.POWER_POINT_UI]
    for style in gradient_styles:
        options = slides.export.RenderingOptions()
        options.gradient_style = style

        with slide.get_image(options, 1.0, 1.0) as image:
            image.save(f"gradient-{style.name}.png", slides.ImageFormat.PNG)
```

Die nachstehenden Bilder zeigen die Ausgabe derselben Folie, wobei in jedem Bild beide Verläufe zu sehen sind:

| Default | PowerPointUI |
| --- | --- |
| ![Cyan-zu-Orange- und Blau-zu-Gelb-Verläufe gerendert mit Default](gradient-Default.png) | ![Dieselbe Verläufe gerendert mit PowerPointUI](gradient-PowerPointUI.png) |

In diesem Beispiel erzeugt `DEFAULT` hellere Zwischenfarben, während `POWER_POINT_UI` dunklere Zwischenfarben erzeugt. Der Unterschied hängt von den Farben und den Stoppunkten im Verlauf ab.

Wählen Sie `DEFAULT`, wenn die standardmäßige Aspose.Slides‑Ausgabe Ihren Anforderungen entspricht. Verwenden Sie `POWER_POINT_UI`, wenn Ihre Priorität darin besteht, das Aussehen in PowerPoint nachzuahmen. Vergleichen Sie beide Ausgaben mit dem gewünschten Ergebnis; keine der beiden Modi ist allgemein vorzuziehen.

## **FAQ**

**Wie kann ich eine bestimmte Form, z. B. ein Diagramm oder ein Bild, anstatt der gesamten Folie exportieren?**

Aspose.Slides unterstützt das [Erzeugen von Miniaturansichten für einzelne Formen](/slides/de/python-net/create-shape-thumbnails/), sodass Sie eine Form als PNG‑Bild rendern können.

**Wird die parallele Konvertierung auf einem Server unterstützt?**

Ja. Verwenden Sie für jeden Thread oder Prozess eine separate Präsentationsinstanz; [teilen Sie keine einzelne Instanz über Threads hinweg](/slides/de/python-net/multithreading/).

**Welche Einschränkungen gelten im Evaluationsmodus beim Exportieren nach PNG?**

Im Evaluationsmodus wird den Ausgabebildern ein Wasserzeichen hinzugefügt und es werden [weitere Einschränkungen](/slides/de/python-net/licensing/) angewendet, bis eine Lizenz installiert ist.