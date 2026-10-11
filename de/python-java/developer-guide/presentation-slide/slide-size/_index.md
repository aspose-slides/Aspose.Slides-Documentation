---
title: Ändern der Foliengröße in einer Präsentation mit Python über Java
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
- Benutzerdefinierte Foliengröße
- Besondere Foliengröße
- Einzigartige Foliengröße
- Vollformatfolie
- Bildschirmtyp
- Nicht skalieren
- Anpassen sicherstellen
- Maximieren
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folien in PPT-, PPTX- und ODP-Dateien schnell mit Python über Java und Aspose.Slides skalieren und Präsentationen für jeden Bildschirm optimieren, ohne Qualitätsverlust."
---
## **Einleitung**

Aspose.Slides bietet umfassende Werkzeuge zum Anpassen der Foliengröße und des Seitenverhältnisses in PowerPoint‑Präsentationen, die sowohl für den Druck als auch für die Anzeige auf Bildschirmen entscheidend sind.

Beliebte Foliengrößen und -verhältnisse:

- **Standard (Seitenverhältnis 4:3)**: Ideal für ältere Bildschirme und Geräte.
- **Widescreen (Seitenverhältnis 16:9)**: Empfohlen für moderne Projektoren und Displays.

Stellen Sie Konsistenz in Ihrer gesamten Präsentation sicher, da eine einheitliche Foliengröße und ein einheitliches Seitenverhältnis für alle Folien gelten. Für optimale Ergebnisse sollten Sie die Folienabmessungen zu Beginn des Erstellungsprozesses Ihrer Präsentation festlegen, um Komplikationen zu vermeiden.

{{% alert color="info" title="Note" %}}
Standardmäßig verwenden mit Aspose.Slides erstellte Präsentationen das Seitenverhältnis 4:3.
{{% /alert %}}

Notiz‑ und Handzettelseiten haben eigene Abmessungen, die von normalen Folien abweichen. Siehe [Notes Page Size](/slides/de/python-java/notes-size/), um deren Größe und Ausrichtung zu ändern.

## **Foliengröße in Präsentationen ändern**

Dieses Beispiel zeigt, wie Sie die Foliengröße einer Präsentation in Python über Java mit Aspose.Slides ändern:

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

Wenn Ihnen die gängigen Foliengrößen (4:3 und 16:9) für Ihre Arbeit nicht ausreichen, können Sie eine spezifische oder eindeutige Foliengröße verwenden. Beispielsweise profitieren Sie von einer benutzerdefinierten Größeneinstellung, wenn Sie Vollformat‑Folien Ihrer Präsentation auf einem eigenen Seitendesign ausdrucken oder Ihre Präsentation auf bestimmten Bildschirmtypen anzeigen möchten.

Dieses Beispiel zeigt, wie Sie Aspose.Slides für Python über Java verwenden, um für eine Präsentation eine benutzerdefinierte Foliengröße festzulegen:

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

Nachdem Sie die Foliengröße einer Präsentation geändert haben, können die Folieninhalte (Bilder oder Objekte usw.) verzerrt werden. Standardmäßig werden die Objekte automatisch an die neue Foliengröße angepasst. Beim Ändern der Foliengröße einer Präsentation können Sie jedoch eine Einstellung angeben, die bestimmt, wie Aspose.Slides mit den Inhalten auf den Folien umgeht.

Je nach gewünschtem Ergebnis können Sie eine der folgenden Einstellungen verwenden:

- [DoNotScale](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesizescaletype/#DoNotScale)

  Wenn Sie NICHT möchten, dass die Objekte auf den Folien skaliert werden, verwenden Sie diese Einstellung.

- [EnsureFit](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesizescaletype/#EnsureFit)

  Wenn Sie auf eine kleinere Foliengröße skalieren und Aspose.Slides die Folienobjekte verkleinern soll, damit alles auf die Folien passt (so vermeiden Sie Inhaltsverlust), verwenden Sie diese Einstellung.

- [Maximize](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesizescaletype/#Maximize)

  Wenn Sie auf eine größere Foliengröße skalieren und Aspose.Slides die Folienobjekte vergrößern soll, damit sie proportional zur neuen Foliengröße werden, verwenden Sie diese Einstellung.

Dieses Beispiel zeigt, wie Sie die [Maximize](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesizescaletype/#Maximize)‑Einstellung beim Ändern der Foliengröße einer Präsentation verwenden:

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

Ja. Größere Folienabmessungen (in Punkten) in Kombination mit einer höheren Render‑Skala führen zu höherem Speicherverbrauch und längeren Verarbeitungszeiten. Ziel ist eine praktikable Foliengröße; passen Sie die Render‑Skala nur bei Bedarf an, um die gewünschte Ausgabequalität zu erreichen.

**Kann ich eine nicht standardmäßige Foliengröße festlegen und dann Folien aus Präsentationen mit unterschiedlichen Größen zusammenführen?**

Sie können keine [merge presentations](/slides/de/python-java/merge-presentation/) durchführen, solange die Präsentationen unterschiedliche Foliengrößen haben — passen Sie zunächst eine Präsentation an die andere an. Beim Ändern der Foliengröße können Sie über die Option [SlideSizeScaleType](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesizescaletype/) festlegen, wie vorhandene Inhalte behandelt werden. Nach der Angleichung der Größen können Sie Folien zusammenführen und die Formatierung beibehalten.

**Kann ich Thumbnails für einzelne Formen oder bestimmte Bereiche einer Folie erzeugen, und werden diese die neue Foliengröße berücksichtigen?**

Ja. Aspose.Slides kann Thumbnails für [entire slides](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getImage) sowie für [selected shapes](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getImage) rendern. Die resultierenden Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider, wodurch ein konsistenter Bildausschnitt und korrekte Geometrie gewährleistet sind.