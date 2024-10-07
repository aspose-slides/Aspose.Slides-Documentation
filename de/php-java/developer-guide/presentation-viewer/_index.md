---
title: Präsentationsviewer
type: docs
weight: 50
url: /php-java/presentation-viewer/
keywords: "PowerPoint PPT Viewer"
description: "PowerPoint PPT Viewer "
---

{{% alert color="primary" %}} 

Aspose.Slides für PHP über Java wird verwendet, um Präsentationsdateien mit Folien zu erstellen. Diese Folien können durch das Öffnen von Präsentationen mit Microsoft PowerPoint angesehen werden. Manchmal müssen Entwickler jedoch Folien auch als Bilder in ihrem bevorzugten Bildbetrachter anzeigen oder ihren eigenen Präsentationsviewer erstellen. In solchen Fällen ermöglicht Aspose.Slides für PHP über Java das Exportieren einer einzelnen Folie als Bild. Dieser Artikel beschreibt, wie man das macht.

{{% /alert %}} 

## **Live-Beispiel**
Sie können die kostenlose App [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) ausprobieren, um zu sehen, was Sie mit der Aspose.Slides API implementieren können:

[](https://products.aspose.app/slides/viewer/)

[![todo:image_alt_text](slides-viewer.png)](https://products.aspose.app/slides/viewer/)

## **SVG-Bild aus Folie generieren**
Um mit Aspose.Slides für PHP über Java ein SVG-Bild aus einer gewünschten Folie zu generieren, folgen Sie bitte den folgenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
- Erhalten Sie die Referenz der gewünschten Folie, indem Sie deren ID oder Index verwenden.
- Holen Sie das SVG-Bild in einem Speicherdatenstrom.
- Speichern Sie den Speicherdatenstrom in einer Datei.

```php
  # Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
  $pres = new Presentation("CreateSlidesSVGImage.pptx");
  try {
    # Greifen Sie auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Erstellen Sie ein Speicherdatenstrom-Objekt
    $svgStream = new Java("java.io.FileOutputStream", "Aspose_out.svg");
    # Generieren Sie das SVG-Bild der Folie und speichern Sie es im Speicherdatenstrom
    $sld->writeAsSvg($svgStream);
    $svgStream->close();
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

## **SVG mit benutzerdefinierten Form-IDs generieren**
Aspose.Slides für PHP über Java kann verwendet werden, um [SVG](https://docs.fileformat.com/page-description-language/svg/) aus einer Folie mit benutzerdefinierter Form-ID zu generieren. Dazu verwenden Sie die ID-Eigenschaft von [ISvgShape](https://reference.aspose.com/slides/php-java/aspose.slides/ISvgShape), die die benutzerdefinierte ID der Formen im generierten SVG darstellt. Der CustomSvgShapeFormattingController kann verwendet werden, um die Form-ID festzulegen.

```php

  class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    function __construct() {
      $this->m_shapeIndex = 0;
    }

    function __construct($shapeStartIndex) {
      $this->m_shapeIndex = $shapeStartIndex;
    }

    function formatShape($svgShape, $shape) {
      $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
  }

  $pres = new Presentation("pptxFileName.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "Aspose_out.svg");
    try {
      $svgOptions = new SVGOptions();
      $shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(), null, java("com.aspose.slides.ISvgShapeFormattingController"));
      $svgOptions->setShapeFormattingController($shapeFormattingController);
      $pres->getSlides()->get_Item(0)->writeAsSvg($stream, $svgOptions);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

## **Miniaturbildbild von Folien erstellen**
Aspose.Slides für PHP über Java hilft Ihnen, Miniaturbilder der Folien zu generieren. Um das Miniaturbild einer gewünschten Folie mit Aspose.Slides für PHP über Java zu generieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Erhalten Sie die Referenz einer gewünschten Folie, indem Sie deren ID oder Index verwenden.
1. Holen Sie das Miniaturbild der referenzierten Folie in einem bestimmten Maßstab.
1. Speichern Sie das Miniaturbild in einem beliebigen gewünschten Bildformat.

```php
  # Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
  $pres = new Presentation("ThumbnailFromSlide.pptx");
  try {
    # Greifen Sie auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Erstellen Sie ein Full-Scale-Bild
    $slideImage = $sld->getImage(1.0, 1.0);
    # Speichern Sie das Bild auf der Festplatte im JPEG-Format
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **Miniaturbild mit benutzerdefinierten Abmessungen erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Erhalten Sie die Referenz einer gewünschten Folie, indem Sie deren ID oder Index verwenden.
1. Holen Sie das Miniaturbild der referenzierten Folie in einem bestimmten Maßstab.
1. Speichern Sie das Miniaturbild in einem beliebigen gewünschten Bildformat.

```php
  # Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
  $pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
  try {
    # Greifen Sie auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Benutzerdefinierte Dimension
    $desiredX = 1200;
    $desiredY = 800;
    # Abgerufener skalierter Wert von X und Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    # Erstellen Sie ein Full-Scale-Bild
    $slideImage = $sld->getImage($ScaleX, $ScaleY);
    # Speichern Sie das Bild auf der Festplatte im JPEG-Format
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **Miniaturbild aus Folie im Notizfolienansicht erstellen**
Um das Miniaturbild einer gewünschten Folie in der Notizfolienansicht mit Aspose.Slides für PHP über Java zu generieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Erhalten Sie die Referenz einer gewünschten Folie, indem Sie deren ID oder Index verwenden.
1. Holen Sie das Miniaturbild der referenzierten Folie in einem bestimmten Maßstab in der Notizfolienansicht.
1. Speichern Sie das Miniaturbild in einem beliebigen gewünschten Bildformat.

Der folgende Codeschnipsel erzeugt ein Miniaturbild der ersten Folie einer Präsentation in der Notizfolienansicht.

```php
  # Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
  $pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
  try {
    # Greifen Sie auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Benutzerdefinierte Dimension
    $desiredX = 1200;
    $desiredY = 800;
    # Abgerufener skalierter Wert von X und Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    $opts = new RenderingOptions();
    $opts->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    # Erstellen Sie ein Full-Scale-Bild
    $slideImage = $sld->getImage($opts, $ScaleX, $ScaleY);
    # Speichern Sie das Bild auf der Festplatte im JPEG-Format
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    $pres->dispose();
  }
```