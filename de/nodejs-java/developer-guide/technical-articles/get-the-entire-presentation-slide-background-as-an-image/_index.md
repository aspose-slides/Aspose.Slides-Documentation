---
title: Den gesamten Folienhintergrund einer Präsentation als Bild abrufen
type: docs
weight: 95
url: /de/nodejs-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- Folie
- Hintergrund
- Folienhintergrund
- Hintergrund zu einem Bild
- PowerPoint
- PPT
- PPTX
- PowerPoint-Präsentation
- Node
- JavaScript
- Aspose.Slides für Node.js via Java
---

## **Den gesamten Folienhintergrund abrufen**

In PowerPoint‑Präsentationen kann der Folienhintergrund aus vielen Elementen bestehen. Zusätzlich zum als [Folienhintergrund](/slides/de/nodejs-java/presentation-background/) festgelegten Bild kann der endgültige Hintergrund vom Präsentationsthema, Farbschema und den Formen, die auf der Master‑Folie und der Layout‑Folie platziert sind, beeinflusst werden.

Aspose.Slides für Node.js über Java bietet keine einfache Methode, den gesamten Folienhintergrund einer Präsentation als Bild zu extrahieren, aber Sie können die nachfolgenden Schritte befolgen:
1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Ermitteln Sie die Foliengröße aus der Präsentation.
1. Wählen Sie eine Folie aus.
1. Erstellen Sie eine temporäre Präsentation.
1. Setzen Sie die gleiche Foliengröße in der temporären Präsentation.
1. Klonen Sie die ausgewählte Folie in die temporäre Präsentation.
1. Löschen Sie die Formen von der geklonten Folie.
1. Konvertieren Sie die geklonte Folie in ein Bild.

Das folgende Codebeispiel extrahiert den gesamten Folienhintergrund einer Präsentation als Bild.
```javascript
var slideIndex = 0;
var imageScale = 1;
var presentation = new aspose.slides.Presentation("sample.pptx");
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);
var tempPresentation = new aspose.slides.Presentation();
var slideWidth = slideSize.getWidth();
var slideHeight = slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();
var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", aspose.slides.ImageFormat.Png);
tempPresentation.dispose();
presentation.dispose();
```


## **FAQ**

**Werden komplexe Farbverläufe, Texturen oder Bildfüllungen einer Master‑Folie im resultierenden Hintergrundbild erhalten?**

Ja. Aspose.Slides rendert Farbverläufe, Bild‑ und Texturfüllungen, die auf der Folie, dem Layout oder dem Master definiert sind. Wenn Sie das Aussehen von vererbten Mastern isolieren müssen, [setzen Sie einen eigenen Hintergrund](/slides/de/nodejs-java/presentation-background/) auf der aktuellen Folie, bevor Sie exportieren.

**Kann ich vor dem Speichern ein Wasserzeichen zum resultierenden Hintergrundbild hinzufügen?**

Ja. Sie können ein [Wasserzeichen](/slides/de/nodejs-java/watermark/) als Form oder Bild auf einer Arbeits[kopie der Folie](/slides/de/nodejs-java/clone-slides/) (hinter anderem Inhalt platziert) hinzufügen und dann exportieren. So erzeugen Sie ein Hintergrundbild mit integriertem Wasserzeichen.

**Kann ich den Hintergrund für ein bestimmtes Layout oder einen Master erhalten, ohne ihn an eine vorhandene Folie zu binden?**

Ja. Greifen Sie auf den gewünschten Master oder das Layout zu, wenden Sie ihn auf einer [temporären Folie](/slides/de/nodejs-java/clone-slides/) mit der erforderlichen Größe an und exportieren Sie diese Folie, um den aus diesem Layout oder Master abgeleiteten Hintergrund zu erhalten.

**Gibt es Lizenzbeschränkungen, die den Bildexport beeinflussen?**

Rendering‑Funktionen sind mit einer [gültigen Lizenz](/slides/de/nodejs-java/licensing/) vollständig verfügbar. Im Evaluierungsmodus können Ausgaben Einschränkungen wie ein Wasserzeichen enthalten. Aktivieren Sie die Lizenz einmal pro Prozess, bevor Sie Batch‑Exporte ausführen.