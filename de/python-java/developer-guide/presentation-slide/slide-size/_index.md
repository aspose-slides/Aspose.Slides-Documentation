---
title: Foliengröße einer Präsentation in Python über Java ändern
linktitle: Foliengröße
type: docs
weight: 70
url: /de/python-java/slide-size/
keywords:
- Foliengröße
- Seitenverhältnis
- Standard
- Breitbild
- 4:3
- 16:9
- Foliengröße festlegen
- Foliengröße ändern
- benutzerdefinierte Foliengröße
- besondere Foliengröße
- einzigartige Foliengröße
- Vollformat‑Folien
- Bildschirmtyp
- Nicht skalieren
- Passend machen
- Maximieren
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folien in PPT-, PPTX- und ODP-Dateien schnell mit Python über Java und Aspose.Slides skalieren und Präsentationen für jeden Bildschirm optimieren können, ohne Qualitätsverlust."
---
## **Einführung**

Aspose.Slides bietet umfassende Werkzeuge zum Anpassen der Foliengröße und des Seitenverhältnisses in PowerPoint‑Präsentationen, was sowohl für den Druck als auch für die Anzeige auf Bildschirmen entscheidend ist.

Beliebte Foliengrößen und Seitenverhältnisse:

- **Standard (Seitenverhältnis 4:3)**: Ideal für ältere Bildschirme und Geräte.
- **Widescreen (Seitenverhältnis 16:9)**: Empfohlen für moderne Projektoren und Displays.

Stellen Sie die Konsistenz Ihrer gesamten Präsentation sicher, da eine einheitliche Foliengröße und ein einheitliches Seitenverhältnis für alle Folien gelten. Für optimale Ergebnisse legen Sie die Folienabmessungen gleich zu Beginn des Erstellungsprozesses fest, um Komplikationen zu vermeiden.

{{% alert color="info" title="Note" %}}
Standardmäßig verwenden Präsentationen, die mit Aspose.Slides erstellt wurden, das Standard‑Seitenverhältnis 4:3.
{{% /alert %}}

## **Foliengröße in Präsentationen ändern**

Dieser Beispielcode zeigt, wie Sie die Foliengröße in einer Präsentation in Python über Java mit Aspose.Slides ändern:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres-4x3-aspect-ratio.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Benutzerdefinierte Foliengrößen in Präsentationen festlegen**

Wenn die üblichen Foliengrößen (4:3 und 16:9) für Ihre Arbeit nicht geeignet sind, können Sie eine bestimmte oder einzigartige Foliengröße verwenden. Beispielsweise, wenn Sie Vollformat‑Folien aus Ihrer Präsentation auf einem benutzerdefinierten Seitengestaltungsplan drucken möchten oder wenn Sie Ihre Präsentation auf bestimmten Bildschirmen anzeigen wollen, profitieren Sie wahrscheinlich von einer individuellen Größe für Ihre Präsentation.

Dieser Beispielcode zeigt, wie Sie mit Aspose.Slides für Python über Java eine benutzerdefinierte Foliengröße für eine Präsentation festlegen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-custom-slide-size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Folieninhalt nach Größenänderung behandeln**

Nachdem Sie die Foliengröße einer Präsentation geändert haben, können die Inhalte der Folien (Bilder oder Objekte usw.) verzerrt werden. Standardmäßig werden die Objekte automatisch so skaliert, dass sie zur neuen Foliengröße passen. Beim Ändern der Foliengröße einer Präsentation können Sie jedoch eine Einstellung festlegen, die bestimmt, wie Aspose.Slides mit den Inhalten auf den Folien umgeht.

Je nach gewünschtem Ergebnis können Sie eine der folgenden Einstellungen verwenden:

- [DoNotScale](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesizescaletype/#DoNotScale)
  
  Wenn Sie NICHT möchten, dass die Objekte auf den Folien skaliert werden, verwenden Sie diese Einstellung.

- [EnsureFit](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesizescaletype/#EnsureFit)
  
  Wenn Sie zu einer kleineren Foliengröße skalieren und Aspose.Slides die Objekte verkleinern soll, damit sie alle auf die Folien passen (damit Sie keinen Inhalt verlieren), verwenden Sie diese Einstellung.

- [Maximize](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesizescaletype/#Maximize)
  
  Wenn Sie zu einer größeren Foliengröße skalieren und Aspose.Slides die Objekte vergrößern soll, damit sie proportional zur neuen Foliengröße werden, verwenden Sie diese Einstellung.

Dieser Beispielcode zeigt, wie Sie die Einstellung [Maximize](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesizescaletype/#Maximize) verwenden, wenn Sie die Größe der Folien einer Präsentation ändern:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize)
finally:
    presentation.dispose()
```

## **FAQ**

**Kann ich eine benutzerdefinierte Foliengröße mit anderen Einheiten als Zoll festlegen (z. B. Punkte oder Millimeter)?**

Ja. Aspose.Slides verwendet intern Punkte, wobei 1 Punkt 1/72 Zoll entspricht. Sie können jede Einheit (wie Millimeter oder Zentimeter) in Punkte umrechnen und die umgerechneten Werte zur Definition von Folienbreite und -höhe verwenden.

**Beeinflusst eine sehr große benutzerdefinierte Foliengröße die Leistung und den Speicherverbrauch beim Rendern?**

Ja. Größere Folienabmessungen (in Punkten) in Kombination mit einer höheren Render‑Skala führen zu höherem Speicherverbrauch und längeren Verarbeitungszeiten. Streben Sie eine praktikable Foliengröße an und passen Sie die Render‑Skala nur nach Bedarf an, um die gewünschte Ausgabqualität zu erreichen.

**Kann ich eine nicht standardmäßige Foliengröße definieren und anschließend Folien aus Präsentationen mit unterschiedlichen Größen zusammenführen?**

Sie können keine [Präsentationen zusammenführen](/slides/de/python-java/merge-presentation/), wenn diese unterschiedliche Foliengrößen haben – passen Sie zuerst eine Präsentation an die Größe der anderen an. Beim Ändern der Foliengröße können Sie über die Option [SlideSizeScaleType](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesizescaletype/) festlegen, wie vorhandene Inhalte behandelt werden. Nach der Angleichung der Größen können Sie Folien zusammenführen und dabei die Formatierung beibehalten.

**Kann ich Thumbnails für einzelne Formen oder bestimmte Bereiche einer Folie erzeugen, und berücksichtigen diese die neue Foliengröße?**

Ja. Aspose.Slides kann Thumbnails für [gesamte Folien](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getImage) sowie für [ausgewählte Formen](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getImage) rendern. Die erzeugten Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider, sodass Bildausschnitt und Geometrie konsistent bleiben.