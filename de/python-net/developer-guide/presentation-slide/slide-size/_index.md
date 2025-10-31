---
title: Ändern der Foliengröße in Präsentationen mit Python
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
descriptions: "Erfahren Sie, wie Sie Folien in PPT-, PPTX- und ODP-Dateien mit Python und Aspose.Slides schnell ändern, Präsentationen für jeden Bildschirm optimieren, ohne Qualität zu verlieren."
---

## Foliengrößen in PowerPoint-Präsentationen

Aspose.Slides für Python via .NET ermöglicht es Ihnen, die Foliengröße oder das Seitenverhältnis in PowerPoint-Präsentationen zu ändern. Wenn Sie Ihre Präsentation drucken oder die Folien auf einem Bildschirm anzeigen möchten, müssen Sie auf die Foliengröße bzw. das Seitenverhältnis achten.

Dies sind die gängigsten Foliengrößen und Seitenverhältnisse:

- **Standard (Seitenverhältnis 4:3)**

  Wenn Ihre Präsentation auf relativ älteren Geräten oder Bildschirmen angezeigt oder betrachtet werden soll, möchten Sie möglicherweise diese Einstellung verwenden.

- **Breitbild (Seitenverhältnis 16:9)**

  Wenn Ihre Präsentation auf modernen Projektoren oder Bildschirmen angezeigt werden soll, möchten Sie möglicherweise diese Einstellung verwenden.

Sie können nicht mehrere Foliengrößen‑Einstellungen in einer einzigen Präsentation verwenden. Wenn Sie eine Foliengröße für eine Präsentation auswählen, wird diese Einstellung auf alle Folien der Präsentation angewendet.

Wenn Sie für Ihre Präsentationen eine spezielle Foliengröße verwenden möchten, empfehlen wir dringend, dies frühzeitig zu tun. Idealerweise sollten Sie Ihre bevorzugte Folie zu Beginn festlegen, d. h. bereits beim Erstellen der Präsentation – bevor Sie Inhalte hinzufügen. So vermeiden Sie Komplikationen, die durch (zukünftige) Änderungen der Foliengröße entstehen können.

{{% alert color="primary" %}} 
Wenn Sie Aspose.Slides zum Erstellen einer Präsentation verwenden, erhalten alle Folien der Präsentation automatisch die Standardgröße bzw. das Seitenverhältnis 4:3.
{{% /alert %}} 

## Ändern der Foliengröße in Präsentationen 

Dieses Beispiel zeigt, wie Sie die Foliengröße in einer Präsentation mit Python und Aspose.Slides ändern können:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## Festlegen benutzerdefinierter Foliengrößen in Präsentationen

Wenn die gängigen Foliengrößen (4:3 und 16:9) für Ihre Arbeit ungeeignet sind, können Sie eine bestimmte oder einzigartige Foliengröße verwenden. Zum Beispiel, wenn Sie Vollformatfolien Ihrer Präsentation auf einem benutzerdefinierten Seitenlayout ausdrucken oder die Präsentation auf bestimmten Bildschirmtypen anzeigen möchten, profitieren Sie wahrscheinlich von einer benutzerdefinierten Größeneinstellung für Ihre Präsentation.

Dieses Beispiel zeigt, wie Sie Aspose.Slides für Python via .NET verwenden, um eine benutzerdefinierte Foliengröße für eine Präsentation in Python festzulegen:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4-Papiergröße
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## Umgang mit Problemen beim Ändern der Foliengröße in Präsentationen

Nachdem Sie die Foliengröße einer Präsentation geändert haben, können die Inhalte der Folien (z. B. Bilder oder Objekte) verzerrt werden. Standardmäßig werden die Objekte automatisch auf die neue Foliengröße skaliert. Beim Ändern der Foliengröße einer Präsentation können Sie jedoch eine Einstellung festlegen, die bestimmt, wie Aspose.Slides mit den Inhalten auf den Folien umgeht.

Je nach dem, was Sie erreichen möchten, können Sie eine dieser Einstellungen verwenden:

- `DO_NOT_SCALE`

  Wenn Sie NICHT möchten, dass die Objekte auf den Folien skaliert werden, verwenden Sie diese Einstellung.

- `ENSURE_FIT`

  Wenn Sie auf eine kleinere Foliengröße skalieren möchten und Aspose.Slides die Objekte verkleinern soll, damit sie alle auf die Folien passen (so vermeiden Sie Datenverlust), verwenden Sie diese Einstellung.

- `MAXIMIZE`

  Wenn Sie auf eine größere Foliengröße skalieren möchten und Aspose.Slides die Objekte vergrößern soll, damit sie proportional zur neuen Foliengröße sind, verwenden Sie diese Einstellung.

Dieses Beispiel zeigt, wie Sie die Einstellung `MAXIMIZE` beim Ändern der Foliengröße einer Präsentation verwenden:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**Kann ich eine benutzerdefinierte Foliengröße mit anderen Einheiten als Zoll festlegen (z. B. Punkte oder Millimeter)?**

Ja. Aspose.Slides verwendet intern Punkte, wobei 1 Punkt 1/72 Zoll entspricht. Sie können jede Einheit (z. B. Millimeter oder Zentimeter) in Punkte umrechnen und die konvertierten Werte zur Festlegung der Folienbreite und -höhe verwenden.

**Wirkt sich eine sehr große benutzerdefinierte Foliengröße auf die Leistung und den Speicherverbrauch beim Rendern aus?**

Ja. Größere Folienabmessungen (in Punkten) in Kombination mit einer höheren Render‑Skala führen zu höherem Speicherverbrauch und längeren Verarbeitungszeiten. Ziel ist eine praktische Foliengröße, und der Render‑Scale sollte nur bei Bedarf angepasst werden, um die gewünschte Ausgabqualität zu erreichen.

**Kann ich eine nicht‑standardmäßige Foliengröße festlegen und anschließend Folien aus Präsentationen mit unterschiedlichen Größen zusammenführen?**

Sie können keine [Präsentationen zusammenführen](/slides/de/python-net/merge-presentation/), solange sie unterschiedliche Foliengrößen haben – passen Sie zuerst eine Präsentation an die andere an. Beim Ändern der Foliengröße können Sie über die Option [SlideSizeScaleType](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) festlegen, wie vorhandene Inhalte behandelt werden. Nach dem Angleichen der Größen können Sie die Folien zusammenführen und das Format beibehalten.

**Kann ich Miniaturansichten für einzelne Formen oder bestimmte Bereiche einer Folie erzeugen, und berücksichtigen sie die neue Foliengröße?**

Ja. Aspose.Slides kann Miniaturansichten für [gesamte Folien](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) sowie für [ausgewählte Formen](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) rendern. Die resultierenden Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider und gewährleisten ein konsistentes Bildausschnitt und Geometrie.