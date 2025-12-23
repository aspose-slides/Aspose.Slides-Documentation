---
title: PowerPoint-Folien in PNG konvertieren mit PHP
linktitle: PowerPoint zu PNG
type: docs
weight: 30
url: /de/php-java/convert-powerpoint-to-png/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu PNG
- Präsentation zu PNG
- Folie zu PNG
- PPT zu PNG
- PPTX zu PNG
- PPT als PNG speichern
- PPTX als PNG speichern
- PPT nach PNG exportieren
- PPTX nach PNG exportieren
- PHP
- Aspose.Slides
description: "Konvertieren Sie PowerPoint-Präsentationen schnell in hochwertige PNG-Bilder mit Aspose.Slides für PHP über Java und erzielen dabei präzise, automatisierte Ergebnisse."
---

## **Über die PowerPoint-zu-PNG-Konvertierung**

Das PNG‑Format (Portable Network Graphics) ist nicht so verbreitet wie JPEG (Joint Photographic Experts Group), aber es ist immer noch sehr beliebt. 

**Anwendungsfall:** Wenn Sie ein komplexes Bild haben und die Größe kein Problem darstellt, ist PNG ein besseres Bildformat als JPEG. 

{{% alert title="Tipp" color="primary" %}} Vielleicht möchten Sie sich die kostenlosen Aspose **PowerPoint‑zu‑PNG‑Konverter** ansehen: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) und [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Sie sind eine Live‑Umsetzung des auf dieser Seite beschriebenen Prozesses. {{% /alert %}}

## **PowerPoint in PNG konvertieren**

Gehen Sie dabei wie folgt vor:

1. Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Holen Sie das Folienobjekt aus der Sammlung [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) unter dem Interface [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide).
3. Verwenden Sie die Methode [ISlide.getImage()](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide), um das Miniaturbild für jede Folie zu erhalten.
4. Verwenden Sie die Methode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)), um das Folien‑Miniaturbild im PNG‑Format zu speichern.

Dieser PHP‑Code zeigt, wie Sie eine PowerPoint‑Präsentation in PNG konvertieren:
```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage();
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **PowerPoint in PNG mit benutzerdefinierten Abmessungen konvertieren**

Wenn Sie PNG‑Dateien in einem bestimmten Maßstab erhalten möchten, können Sie die Werte für `desiredX` und `desiredY` festlegen, die die Abmessungen des resultierenden Miniaturbilds bestimmen. 

Dieser Code demonstriert die beschriebene Vorgang:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $scaleX = 2.0;
    $scaleY = 2.0;
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($scaleX, $scaleY);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **PowerPoint in PNG mit benutzerdefinierter Größe konvertieren**

Wenn Sie PNG‑Dateien in einer bestimmten Größe erhalten möchten, können Sie Ihre gewünschten `width`‑ und `height`‑Argumente für `ImageSize` übergeben. 

Dieser Code zeigt, wie Sie eine PowerPoint‑Datei in PNG konvertieren, während Sie die Größe der Bilder festlegen: 
```php
  $pres = new Presentation("pres.pptx");
  try {
    $size = new Java("java.awt.Dimension", 960, 720);
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($size);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Wie kann ich nur eine bestimmte Form (z. B. Diagramm oder Bild) statt der gesamten Folie exportieren?**

Aspose.Slides unterstützt das [Erzeugen von Miniaturansichten für einzelne Formen](/slides/de/php-java/create-shape-thumbnails/); Sie können eine Form in ein PNG‑Bild rendern.

**Wird die parallele Konvertierung auf einem Server unterstützt?**

Ja, aber [teilen Sie nicht](/slides/de/php-java/multithreading/) eine einzelne Präsentationsinstanz über Threads hinweg. Verwenden Sie pro Thread oder Prozess eine separate Instanz.

**Welche Einschränkungen gibt es in der Testversion beim Export nach PNG?**

Der Evaluierungsmodus fügt den Ausgabebildern ein Wasserzeichen hinzu und erzwingt [weitere Einschränkungen](/slides/de/php-java/licensing/), bis eine Lizenz angewendet wird.