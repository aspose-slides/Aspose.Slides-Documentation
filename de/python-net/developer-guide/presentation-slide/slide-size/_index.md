---
title: Foliengröße
type: docs
weight: 70
url: /de/python-net/slide-size/
keywords: "Folie festlegen, Foliengröße bearbeiten, PowerPoint-Präsentation, benutzerdefinierte Foliengröße, Folienprobleme lösen, Python, Aspose.Slides"
descriptions: "Foliegröße oder Seitenverhältnis in PowerPoint in Python festlegen und bearbeiten"
---

## Foliengrößen in PowerPoint-Präsentationen

Aspose.Slides für Python über .NET ermöglicht es Ihnen, die Foliengröße oder das Seitenverhältnis in PowerPoint-Präsentationen zu ändern. Wenn Sie Ihre Präsentation drucken oder die Folien auf einem Bildschirm anzeigen möchten, müssen Sie auf die Foliengröße oder das Seitenverhältnis achten. 

Dies sind die gängigsten Foliengrößen und Seitenverhältnisse:

- **Standard (4:3 Seitenverhältnis)**

  Wenn Ihre Präsentation auf relativ älteren Geräten oder Bildschirmen angezeigt oder angesehen wird, sollten Sie diese Einstellung verwenden. 

- **Breitbild (16:9 Seitenverhältnis)** 

  Wenn Ihre Präsentation auf modernen Projektoren oder Displays gesehen wird, sollten Sie diese Einstellung verwenden. 

Sie können nicht mehrere Foliengrößeneinstellungen in einer einzigen Präsentation verwenden. Wenn Sie eine Foliengröße für eine Präsentation auswählen, wird diese Foliengrößeneinstellung auf alle Folien in der Präsentation angewendet. 

Wenn Sie eine spezielle Foliengröße für Ihre Präsentationen verwenden möchten, empfehlen wir Ihnen dringend, dies frühzeitig zu tun. Idealerweise sollten Sie Ihre bevorzugte Foliengröße zu Beginn festlegen, d.h. wenn Sie die Präsentation einrichten—bevor Sie Inhalte zur Präsentation hinzufügen. Auf diese Weise vermeiden Sie Komplikationen, die aus (künftigen) Änderungen an der Größe der Folien resultieren. 

{{% alert color="primary" %}} 

 Wenn Sie Aspose.Slides verwenden, um eine Präsentation zu erstellen, erhalten alle Folien in der Präsentation automatisch die Standardgröße oder das 4:3 Seitenverhältnis.

{{% /alert %}} 

## Ändern der Foliengröße in Präsentationen 

 Dieser Beispielcode zeigt Ihnen, wie Sie die Foliengröße in einer Präsentation in Python mit Aspose.Slides ändern:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## Benutzerdefinierte Foliengrößen in Präsentationen festlegen

Wenn Sie die gängigen Foliengrößen (4:3 und 16:9) als ungeeignet für Ihre Arbeit empfinden, können Sie entscheiden, eine spezifische oder einzigartige Foliengröße zu verwenden. Beispielsweise, wenn Sie vorhaben, Folien in voller Größe von Ihrer Präsentation in einem benutzerdefinierten Seitenlayout zu drucken oder wenn Sie Ihre Präsentation auf bestimmten Bildschirmtypen anzeigen möchten, werden Sie wahrscheinlich von der Verwendung einer benutzerdefinierten Größeneinstellung für Ihre Präsentation profitieren. 

Dieser Beispielcode zeigt Ihnen, wie Sie Aspose.Slides für Python über .NET verwenden, um eine benutzerdefinierte Foliengröße für eine Präsentation in Python festzulegen:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4 Papiergröße
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## Probleme beim Ändern der Größe von Folien in Präsentationen lösen

Nachdem Sie die Foliengröße für eine Präsentation geändert haben, können die Inhalte der Folien (Bilder oder Objekte, zum Beispiel) verzerrt werden. Standardmäßig werden die Objekte automatisch in der Größe angepasst, um zur neuen Foliengröße zu passen. Wenn Sie jedoch die Foliengröße einer Präsentation ändern, können Sie eine Einstellung festlegen, die bestimmt, wie Aspose.Slides mit den Inhalten auf den Folien umgeht.

Je nachdem, was Sie tun oder erreichen möchten, können Sie eine dieser Einstellungen verwenden:

- `DO_NOT_SCALE`

  Wenn Sie die Objekte auf den Folien NICHT in der Größe ändern möchten, verwenden Sie diese Einstellung.

- `ENSURE_FIT`

  Wenn Sie auf eine kleinere Foliengröße skalieren möchten und Sie möchten, dass Aspose.Slides die Objekte der Folien so verkleinert, dass sie alle auf die Folien passen (auf diese Weise vermeiden Sie den Verlust von Inhalten), verwenden Sie diese Einstellung. 

- `MAXIMIZE`

  Wenn Sie auf eine größere Foliengröße skalieren möchten und Sie möchten, dass Aspose.Slides die Objekte der Folien vergrößert, um sie proportional zur neuen Foliengröße zu machen, verwenden Sie diese Einstellung. 

Dieser Beispielcode zeigt Ihnen, wie Sie die Einstellung `MAXIMIZE` verwenden, wenn Sie die Größe einer Folie einer Präsentation ändern:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```