---
title: Den gesamten Folienhintergrund einer Präsentation als Bild extrahieren
linktitle: Gesamter Folienhintergrund
type: docs
weight: 95
url: /de/androidjava/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- Folienhintergrund
- finaler Hintergrund
- Hintergrund extrahieren
- gesamter Hintergrund
- Hintergrund zu Bild
- PPT-Hintergrund
- PPTX-Hintergrund
- ODP-Hintergrund
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Extrahieren Sie vollständige Folienhintergründe als Bilder aus PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Android via Java und vereinfachen Sie visuelle Arbeitsabläufe."
---

## **Den gesamten Folienhintergrund abrufen**

In PowerPoint-Präsentationen kann der Folienhintergrund aus vielen Elementen bestehen. Neben dem als [Folienhintergrund](/slides/de/androidjava/presentation-background/) festgelegten Bild kann der endgültige Hintergrund vom Präsentationsthema, Farbschema und von den Formen beeinflusst werden, die auf der Master‑Folien und Layout‑Folien platziert sind.

Aspose.Slides für Android über Java bietet keine einfache Methode, um den gesamten Folienhintergrund einer Präsentation als Bild zu extrahieren, aber Sie können die nachstehenden Schritte ausführen:
1. Laden Sie die Präsentation mit der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Klasse.
1. Ermitteln Sie die Foliengröße aus der Präsentation.
1. Wählen Sie eine Folie aus.
1. Erstellen Sie eine temporäre Präsentation.
1. Setzen Sie dieselbe Foliengröße in der temporären Präsentation.
1. Klonen Sie die ausgewählte Folie in die temporäre Präsentation.
1. Löschen Sie die Formen von der geklonten Folie.
1. Konvertieren Sie die geklonte Folie in ein Bild.

Das folgende Codebeispiel extrahiert den gesamten Folienhintergrund der Präsentation als Bild.
```java
int slideIndex = 0;
int imageScale = 1;

Presentation presentation = new Presentation("sample.pptx");

Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(slideIndex);

Presentation tempPresentation = new Presentation();

float slideWidth = (float)slideSize.getWidth();
float slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

ISlide clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

IImage background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```


## **FAQ**

**Werden komplexe Farbverläufe, Texturen oder Bildfüllungen einer Master‑Folien im resultierenden Hintergrundbild beibehalten?**

Ja. Aspose.Slides rendert Farbverläufe, Bild‑ und Texturfüllungen, die auf der Folie, dem Layout oder dem Master definiert sind. Wenn Sie das Aussehen von geerbten Mastern isolieren müssen, [setzen Sie einen eigenen Hintergrund](/slides/de/androidjava/presentation-background/) auf der aktuellen Folie, bevor Sie exportieren.

**Kann ich dem resultierenden Hintergrundbild vor dem Speichern ein Wasserzeichen hinzufügen?**

Ja. Sie können ein [Wasserzeichen](/slides/de/androidjava/watermark/) als Form oder Bild auf einer Arbeits-[Kopie der Folie](/slides/de/androidjava/clone-slides/) (hinter anderem Inhalt platziert) hinzufügen und anschließend exportieren. So erhalten Sie ein Hintergrundbild, in das das Wasserzeichen eingebettet ist.

**Kann ich den Hintergrund für ein bestimmtes Layout oder einen Master erhalten, ohne ihn an eine vorhandene Folie zu binden?**

Ja. Greifen Sie auf den gewünschten Master oder das Layout zu, wenden Sie es auf eine [temporäre Folie](/slides/de/androidjava/clone-slides/) mit der erforderlichen Größe an und exportieren Sie diese Folie, um den aus diesem Layout oder Master abgeleiteten Hintergrund zu erhalten.

**Gibt es Lizenzbeschränkungen, die den Bildexport beeinträchtigen?**

Render‑Funktionen sind mit einer [gültigen Lizenz](/slides/de/androidjava/licensing/) vollständig verfügbar. Im Evaluierungsmodus kann die Ausgabe Beschränkungen wie ein Wasserzeichen enthalten. Aktivieren Sie die Lizenz einmal pro Prozess, bevor Sie Batch‑Exporte durchführen.