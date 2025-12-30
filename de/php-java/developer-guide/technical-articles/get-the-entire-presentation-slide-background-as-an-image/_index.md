---
title: Den gesamten Folienhintergrund aus einer Präsentation als Bild extrahieren
linktitle: Gesamter Folienhintergrund
type: docs
weight: 95
url: /de/php-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- Folienhintergrund
- Endgültiger Hintergrund
- Hintergrund extrahieren
- Kompletter Hintergrund
- Hintergrund zu Bild
- PPT-Hintergrund
- PPTX-Hintergrund
- ODP-Hintergrund
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Extrahieren Sie vollständige Folienhintergründe als Bilder aus PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP via Java und optimieren Sie damit visuelle Arbeitsabläufe."
---

## **Den gesamten Folienhintergrund abrufen**

In PowerPoint‑Präsentationen kann der Folienhintergrund aus vielen Elementen bestehen. Zusätzlich zu dem als [Folienhintergrund](/slides/de/php-java/presentation-background/) festgelegten Bild kann der endgültige Hintergrund vom Präsentationsthema, Farbschema und den Formen, die auf der Master‑Folie und Layout‑Folie platziert sind, beeinflusst werden.

Aspose.Slides für PHP via Java bietet keine einfache Methode, um den gesamten Folienhintergrund einer Präsentation als Bild zu extrahieren, aber Sie können die folgenden Schritte ausführen:
1. Laden Sie die Präsentation mit der [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/presentation/) Klasse.  
2. Ermitteln Sie die Foliengröße aus der Präsentation.  
3. Wählen Sie eine Folie aus.  
4. Erstellen Sie eine temporäre Präsentation.  
5. Setzen Sie die gleiche Foliengröße in der temporären Präsentation.  
6. Klonen Sie die ausgewählte Folie in die temporäre Präsentation.  
7. Löschen Sie die Formen von der geklonten Folie.  
8. Konvertieren Sie die geklonte Folie in ein Bild.

Das folgende Codebeispiel extrahiert den gesamten Folienhintergrund einer Präsentation als Bild.
```php
$slideIndex = 0;
$imageScale = 1;

$presentation = new Presentation("sample.pptx");

$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item($slideIndex);

$tempPresentation = new Presentation();

$slideWidth = $slideSize->getWidth();
$slideHeight = $slideSize->getHeight();
$tempPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::DoNotScale);

$clonedSlide = $tempPresentation->getSlides()->addClone($slide);
$clonedSlide->getShapes()->clear();

$background = clonedSlide->getImage($imageScale, $imageScale);
$background->save("output->png", ImageFormat::Png);

$tempPresentation->dispose();
$presentation->dispose();
```


## **FAQ**

**Werden komplexe Verläufe, Texturen oder Bildfüllungen von einer Master‑Folie im resultierenden Hintergrundbild erhalten?**

Ja. Aspose.Slides rendert Gradient-, Bild- und Texturfüllungen, die auf der Folie, dem Layout oder dem Master definiert sind. Wenn Sie das Aussehen von geerbten Mastern isolieren müssen, [setzen Sie einen eigenen Hintergrund](/slides/de/php-java/presentation-background/) auf der aktuellen Folie, bevor Sie exportieren.

**Kann ich dem resultierenden Hintergrundbild vor dem Speichern ein Wasserzeichen hinzufügen?**

Ja. Sie können ein [Wasserzeichen](/slides/de/php-java/watermark/) als Form oder Bild auf einer Arbeits-[Kopie der Folie](/slides/de/php-java/clone-slides/) (hinter anderem Inhalt platziert) hinzufügen und dann exportieren. Dadurch entsteht ein Hintergrundbild, in das das Wasserzeichen eingebettet ist.

**Kann ich den Hintergrund für ein bestimmtes Layout oder einen Master erhalten, ohne ihn an eine vorhandene Folie zu binden?**

Ja. Greifen Sie auf den gewünschten Master oder das Layout zu, wenden Sie es auf eine [temporäre Folie](/slides/de/php-java/clone-slides/) mit der erforderlichen Größe an und exportieren Sie diese Folie, um den aus diesem Layout oder Master abgeleiteten Hintergrund zu erhalten.

**Gibt es Lizenzbeschränkungen, die den Bildexport beeinflussen?**

Rendering‑Funktionen sind mit einer [gültigen Lizenz](/slides/de/php-java/licensing/) vollständig verfügbar. Im Evaluierungsmodus kann die Ausgabe Einschränkungen wie ein Wasserzeichen enthalten. Aktivieren Sie die Lizenz einmal pro Prozess, bevor Sie Batch‑Exporte ausführen.