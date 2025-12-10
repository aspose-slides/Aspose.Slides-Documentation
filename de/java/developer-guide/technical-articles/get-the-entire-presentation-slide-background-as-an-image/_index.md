---
title: Gesamten Folienhintergrund aus einer Präsentation als Bild erhalten
linktitle: Gesamter Folienhintergrund
type: docs
weight: 95
url: /de/java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- Folienhintergrund
- endgültiger Hintergrund
- Hintergrund extrahieren
- gesamter Hintergrund
- Hintergrund zu Bild
- PPT-Hintergrund
- PPTX-Hintergrund
- ODP-Hintergrund
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Extrahieren Sie vollständige Folienhintergründe als Bilder aus PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Java und optimieren Sie visuelle Arbeitsabläufe."
---

## **Gesamten Folienhintergrund abrufen**

In PowerPoint-Präsentationen kann der Folienhintergrund aus vielen Elementen bestehen. Zusätzlich zu dem als [Folienhintergrund](/slides/de/java/presentation-background/) festgelegten Bild kann der endgültige Hintergrund vom Präsentationsthema, Farbschema und den Formen, die auf der Master‑Folie und Layout‑Folie platziert sind, beeinflusst werden.

Aspose.Slides für Java bietet keine einfache Methode, um den gesamten Folienhintergrund einer Präsentation als Bild zu extrahieren, aber Sie können die folgenden Schritte ausführen, um dies zu erreichen:
1. Laden Sie die Präsentation mit der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)-Klasse.
1. Holen Sie die Foliengröße aus der Präsentation.
1. Wählen Sie eine Folie aus.
1. Erstellen Sie eine temporäre Präsentation.
1. Setzen Sie die gleiche Foliengröße in der temporären Präsentation.
1. Klonen Sie die ausgewählte Folie in die temporäre Präsentation.
1. Löschen Sie die Formen von der geklonten Folie.
1. Konvertieren Sie die geklonte Folie in ein Bild.

Das folgende Codebeispiel extrahiert den gesamten Folienhintergrund einer Präsentation als Bild.
```java
var slideIndex = 0;
var imageScale = 1;

var presentation = new Presentation("sample.pptx");

var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);

var tempPresentation = new Presentation();

var slideWidth = (float)slideSize.getWidth();
var slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```


## **FAQ**

**Werden komplexe Farbverläufe, Texturen oder Bildfüllungen einer Masterfolie im resultierenden Hintergrundbild erhalten?**

Ja. Aspose.Slides rendert Farbverläufe, Bild- und Texturfüllungen, die auf der Folie, dem Layout oder der Masterfolie definiert sind. Wenn Sie das Aussehen von vererbten Mastern isolieren möchten, [setzen Sie einen eigenen Hintergrund](/slides/de/java/presentation-background/) auf der aktuellen Folie, bevor Sie exportieren.

**Kann ich dem resultierenden Hintergrundbild vor dem Speichern ein Wasserzeichen hinzufügen?**

Ja. Sie können eine [Wasserzeichen](/slides/de/java/watermark/)-Form oder ein Bild auf einer Arbeits-[Kopie der Folie](/slides/de/java/clone-slides/) (hinter anderem Inhalt platziert) hinzufügen und dann exportieren. So erhalten Sie ein Hintergrundbild, in das das Wasserzeichen eingebettet ist.

**Kann ich den Hintergrund für ein bestimmtes Layout oder einen Master erhalten, ohne ihn an eine vorhandene Folie zu binden?**

Ja. Greifen Sie auf den gewünschten Master oder das Layout zu, wenden Sie ihn auf eine [temporäre Folie](/slides/de/java/clone-slides/) mit der erforderlichen Größe an und exportieren Sie diese Folie, um den aus diesem Layout oder Master abgeleiteten Hintergrund zu erhalten.

**Gibt es Lizenzbeschränkungen, die den Bildexport beeinflussen?**

Renderfunktionen sind mit einer [gültigen Lizenz](/slides/de/java/licensing/) vollständig verfügbar. Im Evaluierungsmodus kann die Ausgabe Einschränkungen wie ein Wasserzeichen enthalten. Aktivieren Sie die Lizenz einmal pro Prozess, bevor Sie Batch-Exporte ausführen.