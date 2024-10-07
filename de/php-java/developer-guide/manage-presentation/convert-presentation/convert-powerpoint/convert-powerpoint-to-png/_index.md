---
title: PowerPoint in PNG umwandeln
type: docs
weight: 30
url: /php-java/convert-powerpoint-to-png/
keywords: PowerPoint in PNG, PPT in PNG, PPTX in PNG, java, Aspose.Slides für PHP über Java
description: PowerPoint-Präsentation in PNG umwandeln
---

## **Über die Umwandlung von PowerPoint in PNG**

Das PNG (Portable Network Graphics)-Format ist nicht so populär wie JPEG (Joint Photographic Experts Group), aber es ist dennoch sehr beliebt.

**Anwendungsfall:** Wenn Sie ein komplexes Bild haben und die Größe keine Rolle spielt, ist PNG ein besseres Bildformat als JPEG.

{{% alert title="Tipp" color="primary" %}} Sie sollten die kostenlosen **PowerPoint zu PNG-Konverter** von Aspose ausprobieren: [PPTX in PNG](https://products.aspose.app/slides/conversion/pptx-to-png) und [PPT in PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Sie sind eine Live-Implementierung des auf dieser Seite beschriebenen Prozesses. {{% /alert %}}

## **PowerPoint in PNG umwandeln**

Befolgen Sie diese Schritte:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2. Holen Sie sich das Folienobjekt aus der [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--)-Sammlung unter dem [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide)-Interface.
3. Verwenden Sie die [ISlide.getImage()](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide)-Methode, um das Thumbnail für jede Folie zu erhalten.
4. Verwenden Sie die  [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat))-Methode, um das Folien-Thumbnail im PNG-Format zu speichern.

Dieser PHP-Code zeigt Ihnen, wie Sie eine PowerPoint-Präsentation in PNG umwandeln:

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

## **PowerPoint in PNG mit benutzerdefinierten Abmessungen umwandeln**

Wenn Sie PNG-Dateien in einem bestimmten Maßstab erhalten möchten, können Sie die Werte für `desiredX` und `desiredY` festlegen, die die Abmessungen des resultierenden Thumbnails bestimmen.

Dieser Code demonstriert die beschriebene Operation:

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

## **PowerPoint in PNG mit benutzerdefinierter Größe umwandeln**

Wenn Sie PNG-Dateien in einer bestimmten Größe erhalten möchten, können Sie Ihre bevorzugten `width`- und `height`-Argumente für `ImageSize` übergeben.

Dieser Code zeigt Ihnen, wie Sie eine PowerPoint in PNG umwandeln, während Sie die Größe für die Bilder angeben:

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