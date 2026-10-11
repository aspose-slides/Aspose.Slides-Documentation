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
- Benutzerdefinierte Foliengröße
- Spezielle Foliengröße
- Einzigartige Foliengröße
- Vollformatfolie
- Bildschirmtyp
- Nicht skalieren
- Passend sicherstellen
- Maximieren
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folien in PPT-, PPTX- und ODP-Dateien mit Python und Aspose.Slides schnell ändern können, um Präsentationen für jeden Bildschirm zu optimieren, ohne Qualitätsverlust."
---
## **Einleitung**

Aspose.Slides bietet umfassende Werkzeuge zum Anpassen der Foliengröße und des Seitenverhältnisses in PowerPoint‑Präsentationen, die sowohl für den Druck als auch für die Anzeige auf Bildschirmen entscheidend sind.  

Beliebte Foliengrößen und Verhältnisse:

- **Standard (Seitenverhältnis 4:3)**: Ideal für ältere Bildschirme und Geräte.  
- **Widescreen (Seitenverhältnis 16:9)**: Empfohlen für moderne Projektoren und Displays.  

Stellen Sie die Konsistenz Ihrer gesamten Präsentation sicher, da eine einheitliche Foliengröße und ein einheitliches Seitenverhältnis für alle Folien gelten. Für optimale Ergebnisse setzen Sie die Folienabmessungen zu Beginn des Erstellungsprozesses fest, um Komplikationen zu vermeiden.

{{% alert color="info" title="Note" %}}
Standardmäßig verwenden Präsentationen, die mit Aspose.Slides erstellt wurden, das Seitenverhältnis 4:3.  
{{% /alert %}}

Notiz- und Handout‑Seiten haben andere Abmessungen als reguläre Folien. Siehe [Größe der Notizseite](/slides/de/python-net/notes-size/), um deren Größe und Ausrichtung zu ändern.

## **Foliengröße in einer Präsentation ändern**

 Dieser Beispielcode zeigt, wie Sie die Foliengröße in einer Präsentation in Python mit Aspose.Slides ändern:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN_16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-16x9-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Benutzerdefinierte Foliengrößen angeben**

Wenn die gängigen Foliengrößen (4:3 und 16:9) für Ihre Arbeit nicht geeignet sind, können Sie eine bestimmte oder einzigartige Foliengröße verwenden. Beispielsweise, wenn Sie Vollformat‑Folien aus Ihrer Präsentation auf einem benutzerdefinierten Seitenlayout drucken möchten oder wenn Sie die Präsentation auf bestimmten Bildschirmtypen anzeigen wollen, profitieren Sie wahrscheinlich von einer benutzerdefinierten Größe.

Dieser Beispielcode zeigt, wie Sie Aspose.Slides für Python via .NET verwenden, um eine benutzerdefinierte Foliengröße für eine Präsentation in Python festzulegen:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4 Papiergröße
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Folieninhalt nach Größenänderung behandeln**

Nachdem Sie die Foliengröße einer Präsentation geändert haben, können die Inhalte der Folien (Bilder oder Objekte usw.) verzerrt werden. Standardmäßig werden die Objekte automatisch auf die neue Foliengröße skaliert. Beim Ändern der Foliengröße können Sie jedoch eine Einstellung festlegen, die bestimmt, wie Aspose.Slides mit den Inhalten auf den Folien umgeht.

Je nach dem, was Sie erreichen möchten, können Sie eine der folgenden Einstellungen verwenden:

- `DO_NOT_SCALE`

  Wenn Sie NICHT möchten, dass die Objekte auf den Folien skaliert werden, verwenden Sie diese Einstellung.

- `ENSURE_FIT`

  Wenn Sie zu einer kleineren Foliengröße skalieren und Aspose.Slides die Objekte verkleinern soll, damit sie alle auf die Folien passen (so vermeiden Sie Inhaltsverlust), verwenden Sie diese Einstellung.

- `MAXIMIZE`

  Wenn Sie zu einer größeren Foliengröße skalieren und Aspose.Slides die Objekte vergrößern soll, damit sie proportional zur neuen Foliengröße sind, verwenden Sie diese Einstellung.

Dieser Beispielcode zeigt, wie Sie die Einstellung `MAXIMIZE` beim Ändern der Foliengröße einer Präsentation verwenden:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**Kann ich eine benutzerdefinierte Foliengröße mit anderen Einheiten als Zoll festlegen (z. B. Punkte oder Millimeter)?**

Ja. Aspose.Slides verwendet intern Punkte, wobei 1 Punkt 1/72 Zoll entspricht. Sie können jede Einheit (wie Millimeter oder Zentimeter) in Punkte umrechnen und die umgerechneten Werte zur Definition von Folienbreite und -höhe verwenden.

**Beeinflusst eine sehr große benutzerdefinierte Foliengröße die Leistung und den Speicherverbrauch während des Renderns?**

Ja. Größere Folienabmessungen (in Punkten) kombiniert mit höherer Render‑Skala führen zu erhöhtem Speicherverbrauch und längeren Verarbeitungszeiten. Streben Sie eine praktische Foliengröße an und passen Sie die Render‑Skala nur bei Bedarf an, um die gewünschte Ausgabequalität zu erzielen.

**Kann ich eine nicht standardmäßige Foliengröße definieren und dann Folien aus Präsentationen mit unterschiedlichen Größen zusammenführen?**

Sie können keine [Präsentationen zusammenführen](/slides/de/python-net/merge-presentation/), solange sie unterschiedliche Foliengrößen haben – skalieren Sie zunächst eine Präsentation, damit sie zur anderen passt. Beim Ändern der Foliengröße können Sie festlegen, wie vorhandene Inhalte über die Option [SlideSizeScaleType](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidesizescaletype/) behandelt werden. Nach dem Angleichen der Größen können Sie Folien zusammenführen und das Format beibehalten.

**Kann ich Thumbnails für einzelne Formen oder bestimmte Bereiche einer Folie erzeugen, und berücksichtigen diese die neue Foliengröße?**

Ja. Aspose.Slides kann Thumbnails für [gesamte Folien](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/get_image/) sowie für [ausgewählte Formen](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/get_image/) rendern. Die resultierenden Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider, sodass Bildausschnitt und Geometrie konsistent bleiben.