---
title: PowerPoint-Folien in PNG konvertieren in PHP
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
description: "PowerPoint-Präsentationen schnell in hochwertige PNG-Bilder konvertieren mit Aspose.Slides für PHP über Java, wobei präzise, automatisierte Ergebnisse gewährleistet werden."
---

## **Über die PowerPoint-zu-PNG-Konvertierung**

Das PNG (Portable Network Graphics)-Format ist nicht so populär wie JPEG (Joint Photographic Experts Group), ist aber weiterhin sehr beliebt. 

**Anwendungsfall:** Wenn Sie ein komplexes Bild haben und die Größe kein Problem darstellt, ist PNG ein besseres Bildformat als JPEG. 

{{% alert title="Tipp" color="primary" %}} Vielleicht möchten Sie die kostenlosen Aspose **PowerPoint-zu-PNG-Konverter** ansehen: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) und [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Sie sind eine Live‑Umsetzung des auf dieser Seite beschriebenen Prozesses. {{% /alert %}}

## **PowerPoint in PNG konvertieren**

Gehen Sie wie folgt vor:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.
2. Rufen Sie das Folienobjekt aus der [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) Sammlung der [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) Klasse ab.
3. Verwenden Sie die Methode [Slide.getImage()](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage), um die Miniaturansicht für jede Folie zu erhalten.
4. Verwenden Sie die Methode [IImage.save(String formatName, int imageFormat)](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save), um die Folien‑Miniaturansicht im PNG-Format zu speichern.

Dieser PHP-Code zeigt, wie Sie eine PowerPoint-Präsentation in PNG konvertieren:
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

Wenn Sie PNG-Dateien in einem bestimmten Maßstab erhalten möchten, können Sie die Werte für `desiredX` und `desiredY` festlegen, die die Abmessungen der resultierenden Miniaturansicht bestimmen. 

Dieser Code demonstriert die beschriebene Vorgehensweise:
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

Wenn Sie PNG-Dateien in einer bestimmten Größe erhalten möchten, können Sie Ihre bevorzugten `width`‑ und `height`‑Argumente für `ImageSize` übergeben. 

Dieser Code zeigt, wie Sie ein PowerPoint in PNG konvertieren und dabei die Bildgröße angeben: 
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

**Wie kann ich nur eine bestimmte Form (z. B. Diagramm oder Bild) anstatt der gesamten Folie exportieren?**

Aspose.Slides unterstützt das [Erzeugen von Miniaturansichten für einzelne Formen](/slides/de/php-java/create-shape-thumbnails/); Sie können eine Form als PNG‑Bild rendern.

**Wird eine Parallelkonvertierung auf einem Server unterstützt?**

Ja, jedoch sollten Sie keine einzelne Präsentationsinstanz über Threads hinweg [teilen](/slides/de/php-java/multithreading/). Verwenden Sie pro Thread oder Prozess eine separate Instanz.

**Welche Einschränkungen gibt es in der Testversion beim Export nach PNG?**

Der Evaluierungsmodus fügt den Ausgabebildern ein Wasserzeichen hinzu und erzwingt [weitere Einschränkungen](/slides/de/php-java/licensing/), bis eine Lizenz aktiviert wird.