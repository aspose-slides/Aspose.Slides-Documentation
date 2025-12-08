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
- benutzerdefinierte Foliengröße
- spezielle Foliengröße
- einzigartige Foliengröße
- Vollformatfolie
- Bildschirttyp
- nicht skalieren
- Passend anpassen
- maximieren
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
descriptions: "Erfahren Sie, wie Sie Folien in PPT-, PPTX- und ODP-Dateien mit Python und Aspose.Slides schnell skalieren und Präsentationen für jeden Bildschirm optimieren, ohne Qualitätsverlust."
---

## Foliengrößen in PowerPoint-Präsentationen

Aspose.Slides for Python via .NET ermöglicht es Ihnen, die Foliengröße oder das Seitenverhältnis in PowerPoint-Präsentationen zu ändern. Wenn Sie Ihre Präsentation drucken oder die Folien auf einem Bildschirm anzeigen möchten, müssen Sie auf die Foliengröße bzw. das Seitenverhältnis achten. 

Dies sind die gängigsten Foliengrößen und Seitenverhältnisse:

- **Standard (4:3 Seitenverhältnis)**

  Wenn Ihre Präsentation auf relativ älteren Geräten oder Bildschirmen angezeigt oder betrachtet werden soll, möchten Sie möglicherweise diese Einstellung verwenden. 

- **Widescreen (16:9 Seitenverhältnis)** 

  Wenn Ihre Präsentation auf modernen Projektoren oder Bildschirmen gezeigt werden soll, möchten Sie möglicherweise diese Einstellung verwenden. 

Sie können nicht mehrere Foliengrößeneinstellungen in einer einzigen Präsentation verwenden. Wenn Sie eine Foliengröße für eine Präsentation auswählen, wird diese Einstellung auf alle Folien der Präsentation angewendet. 

Wenn Sie lieber eine spezielle Foliengröße für Ihre Präsentationen verwenden möchten, empfehlen wir dringend, dies früh zu tun. Idealerweise sollten Sie Ihre bevorzugte Folie zu Beginn festlegen, d. h. bereits beim Einrichten der Präsentation – bevor Sie Inhalte hinzufügen. Auf diese Weise vermeiden Sie Komplikationen, die durch (zukünftige) Änderungen der Foliengröße entstehen können. 

{{% alert color="primary" %}} 

 Wenn Sie Aspose.Slides zum Erstellen einer Präsentation verwenden, erhalten alle Folien in der Präsentation automatisch die Standardgröße bzw. das 4:3‑Seitenverhältnis.

{{% /alert %}} 

## Ändern der Foliengröße in Präsentationen 

 Dieses Beispielcode zeigt, wie Sie die Foliengröße in einer Präsentation in Python mit Aspose.Slides ändern:
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```


## Angeben benutzerdefinierter Foliengrößen in Präsentationen

Wenn Ihnen die gängigen Foliengrößen (4:3 und 16:9) für Ihre Arbeit nicht passen, können Sie eine bestimmte oder eindeutige Foliengröße verwenden. Zum Beispiel, wenn Sie beabsichtigen, Vollgröße‑Folien Ihrer Präsentation auf einem benutzerdefinierten Seitenlayout zu drucken oder die Präsentation auf bestimmten Bildschirmtypen anzuzeigen, profitieren Sie wahrscheinlich von einer benutzerdefinierten Größeneinstellung für Ihre Präsentation. 

Dieses Beispielcode zeigt, wie Sie Aspose.Slides for Python via .NET verwenden, um in Python eine benutzerdefinierte Foliengröße für eine Präsentation festzulegen:
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4 Papiergröße
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```


## Umgang mit Problemen beim Ändern der Foliengröße in Präsentationen

Nachdem Sie die Foliengröße einer Präsentation geändert haben, können die Inhalte der Folien (z. B. Bilder oder Objekte) verzerrt werden. Standardmäßig werden die Objekte automatisch an die neue Foliengröße angepasst. Beim Ändern der Foliengröße einer Präsentation können Sie jedoch eine Einstellung festlegen, die bestimmt, wie Aspose.Slides mit den Folieninhalten umgeht.

Je nach dem, was Sie beabsichtigen, können Sie eine dieser Einstellungen verwenden:

- `DO_NOT_SCALE`

  Wenn Sie NICHT möchten, dass die Objekte auf den Folien skaliert werden, verwenden Sie diese Einstellung.

- `ENSURE_FIT`

  Wenn Sie zu einer kleineren Foliengröße skalieren möchten und Aspose.Slides die Folienobjekte verkleinern soll, damit sie alle auf die Folien passen (so vermeiden Sie den Verlust von Inhalten), verwenden Sie diese Einstellung. 

- `MAXIMIZE`

  Wenn Sie zu einer größeren Foliengröße skalieren möchten und Aspose.Slides die Folienobjekte vergrößern soll, damit sie proportional zur neuen Foliengröße sind, verwenden Sie diese Einstellung. 

Dieses Beispielcode zeigt, wie Sie die Einstellung `MAXIMIZE` beim Ändern der Foliengröße einer Präsentation verwenden:
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```


## **FAQ**

**Kann ich eine benutzerdefinierte Foliengröße mit anderen Einheiten als Zoll festlegen (zum Beispiel Punkte oder Millimeter)?**

Ja. Aspose.Slides verwendet intern Punkte, wobei 1 Punkt 1/72 Zoll entspricht. Sie können jede Einheit (z. B. Millimeter oder Zentimeter) in Punkte umrechnen und die umgerechneten Werte zur Festlegung von Folienbreite und -höhe verwenden.

**Wird eine sehr große benutzerdefinierte Foliengröße die Leistung und den Speicherverbrauch beim Rendern beeinträchtigen?**

Ja. Größere Folienmaße (in Punkten) in Kombination mit einem höheren Render‑Skalenfaktor führen zu erhöhtem Speicherverbrauch und längeren Verarbeitungszeiten. Ziel ist eine praktikable Foliengröße; passen Sie den Render‑Skalenfaktor nur bei Bedarf an, um die gewünschte Ausgabequalität zu erreichen.

**Kann ich eine nicht standardmäßige Foliengröße definieren und dann Folien aus Präsentationen zusammenführen, die unterschiedliche Größen haben?**

Sie können nicht [merge presentations](/slides/de/python-net/merge-presentation/) durchführen, solange die Präsentationen unterschiedliche Foliengrößen haben – zuerst müssen Sie eine Präsentation auf die Größe der anderen anpassen. Beim Ändern der Foliengröße können Sie über die Option [SlideSizeScaleType](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) festlegen, wie vorhandene Inhalte behandelt werden. Nach dem Angleichen der Größen können Sie Folien zusammenführen und dabei die Formatierung beibehalten.

**Kann ich Miniaturansichten für einzelne Formen oder bestimmte Bereiche einer Folie erstellen, und berücksichtigen sie die neue Foliengröße?**

Ja. Aspose.Slides kann Miniaturansichten für [entire slides](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) sowie für [selected shapes](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) rendern. Die resultierenden Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider, wodurch eine konsistente Bildkomposition und Geometrie gewährleistet wird.