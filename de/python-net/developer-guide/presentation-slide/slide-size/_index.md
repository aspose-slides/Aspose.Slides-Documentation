---
title: Foliengröße in Präsentationen mit Python ändern
linktitle: Foliengröße
type: docs
weight: 70
url: /de/python-net/slide-size/
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
- Vollformatfolie
- Bildschirmtyp
- nicht skalieren
- Passend sicherstellen
- maximieren
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folien in PPT-, PPTX- und ODP-Dateien mit Python und Aspose.Slides schnell skalieren und Präsentationen für jeden Bildschirm optimieren, ohne Qualitätsverlust."
---
## **Einleitung**

Aspose.Slides bietet umfassende Werkzeuge zum Anpassen der Foliengröße und des Seitenverhältnisses in PowerPoint-Präsentationen, die sowohl für den Druck als auch für die Anzeige auf dem Bildschirm entscheidend sind. 

Beliebte Foliengrößen und Seitenverhältnisse:

- **Standard (4:3 Seitenverhältnis)**: Ideal für ältere Bildschirme und Geräte.
- **Widescreen (16:9 Seitenverhältnis)**: Empfohlen für moderne Projektoren und Anzeigen.

Stellen Sie die Konsistenz in Ihrer gesamten Präsentation sicher, da eine einheitliche Foliengröße und ein einheitliches Seitenverhältnis für alle Folien gelten. Für optimale Ergebnisse legen Sie die Folienabmessungen zu Beginn des Erstellungsprozesses Ihrer Präsentation fest, um Komplikationen zu vermeiden.

{{% alert color="primary" %}} 
Standardmäßig verwenden mit Aspose.Slides erstellte Präsentationen das Standard‑Seitenverhältnis 4:3.
{{% /alert %}}

## **Foliengröße in einer Präsentation ändern**

Dieser Beispielcode zeigt, wie Sie die Foliengröße in einer Präsentation in Python mit Aspose.Slides ändern können:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Benutzerdefinierte Foliengrößen festlegen**

Wenn die üblichen Foliengrößen (4:3 und 16:9) für Ihre Arbeit nicht geeignet sind, können Sie eine spezifische oder einzigartige Foliengröße verwenden. Beispielsweise, wenn Sie planen, Folien Ihrer Präsentation in voller Größe auf einem benutzerdefinierten Seitenlayout zu drucken oder wenn Sie Ihre Präsentation auf bestimmten Bildschirmen anzeigen möchten, profitieren Sie wahrscheinlich von einer benutzerdefinierten Größeneinstellung für Ihre Präsentation. 

Dieser Beispielcode zeigt, wie Sie Aspose.Slides für Python über .NET verwenden, um eine benutzerdefinierte Foliengröße für eine Präsentation in Python festzulegen:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4-Papiergröße
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Folieninhalt nach dem Ändern der Größe behandeln**

Nachdem Sie die Foliengröße einer Präsentation geändert haben, können die Inhalte der Folien (z. B. Bilder oder Objekte) verzerrt werden. Standardmäßig werden die Objekte automatisch skaliert, um zur neuen Foliengröße zu passen. Beim Ändern der Foliengröße einer Präsentation können Sie jedoch eine Einstellung festlegen, die bestimmt, wie Aspose.Slides mit den Inhalten auf den Folien umgeht.

Je nach dem, was Sie erreichen möchten, können Sie eine dieser Einstellungen verwenden:

- `DO_NOT_SCALE`

  Wenn Sie NICHT möchten, dass die Objekte auf den Folien skaliert werden, verwenden Sie diese Einstellung.

- `ENSURE_FIT`

  Wenn Sie zu einer kleineren Foliengröße skalieren möchten und Aspose.Slides die Folienobjekte verkleinern soll, damit sie alle auf die Folien passen (so vermeiden Sie Inhaltsverlust), verwenden Sie diese Einstellung.

- `MAXIMIZE`

  Wenn Sie zu einer größeren Foliengröße skalieren möchten und Aspose.Slides die Folienobjekte vergrößern soll, damit sie proportional zur neuen Foliengröße sind, verwenden Sie diese Einstellung.

Dieser Beispielcode zeigt, wie Sie die Einstellung `MAXIMIZE` beim Ändern der Foliengröße einer Präsentation verwenden:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**Kann ich eine benutzerdefinierte Foliengröße mit anderen Einheiten als Zoll festlegen (z. B. Punkte oder Millimeter)?**

Ja. Aspose.Slides verwendet intern Punkte, wobei 1 Punkt 1/72 Zoll entspricht. Sie können jede Einheit (wie Millimeter oder Zentimeter) in Punkte umrechnen und die umgerechneten Werte zur Definition von Folienbreite und -höhe verwenden.

**Wirkt sich eine sehr große benutzerdefinierte Foliengröße auf die Leistung und den Speicherverbrauch beim Rendern aus?**

Ja. Größere Folienabmessungen (in Punkten) in Kombination mit einem höheren Render‑Scale führen zu einem erhöhten Speicherverbrauch und längeren Verarbeitungszeiten. Streben Sie eine praktische Foliengröße an und passen Sie den Render‑Scale nur bei Bedarf an, um die gewünschte Ausgabequalität zu erreichen.

**Kann ich eine nicht standardmäßige Foliengröße definieren und dann Folien aus Präsentationen zusammenführen, die unterschiedliche Größen haben?**

Sie können nicht [Präsentationen zusammenführen](/slides/de/python-net/merge-presentation/), solange sie unterschiedliche Foliengrößen haben – passen Sie zunächst eine Präsentation an die andere an. Beim Ändern der Foliengröße können Sie auswählen, wie vorhandene Inhalte über die [SlideSizeScaleType](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidesizescaletype/)‑Option behandelt werden. Nach dem Angleichen der Größen können Sie Folien zusammenführen und dabei die Formatierung beibehalten.

**Kann ich Miniaturansichten für einzelne Formen oder bestimmte Bereiche einer Folie erstellen, und werden sie die neue Foliengröße berücksichtigen?**

Ja. Aspose.Slides kann Miniaturansichten für [gesamte Folien](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/get_image/) sowie für [ausgewählte Formen](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/get_image/) rendern. Die resultierenden Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider und gewährleisten eine konsistente Bildausschnitt und Geometrie.