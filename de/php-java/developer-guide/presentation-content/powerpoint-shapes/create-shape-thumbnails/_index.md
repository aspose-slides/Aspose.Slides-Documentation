---
title: Erstellen von Miniaturbildern von Präsentationsformen in PHP
linktitle: Form-Miniaturbilder
type: docs
weight: 70
url: /de/php-java/create-shape-thumbnails/
keywords:
- Form Miniaturbild
- Form Bild
- Form rendern
- Formdarstellung
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erzeugen Sie hochwertige Miniaturbilder von Formen aus PowerPoint-Folien mit Aspose.Slides für PHP via Java – erstellen und exportieren Sie Präsentations-Miniaturbilder ganz einfach."
---

## **Übersicht**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java kann verwendet werden, um Präsentationsdateien zu erstellen, bei denen jede Seite einer Folie entspricht. Die Folien können angezeigt werden, indem die Präsentationsdateien mit Microsoft PowerPoint geöffnet werden. Entwickler müssen jedoch manchmal die Bilder der Formen separat in einem Bildbetrachter ansehen. In solchen Fällen hilft Aspose.Slides for PHP via Java, Miniaturbilder der Folienformen zu erzeugen.

{{% /alert %}} 

In diesem Thema zeigen wir, wie man Folien-Miniaturbilder in verschiedenen Situationen erzeugt:

- Erzeugen eines Formen-Miniaturbildes innerhalb einer Folie.
- Erzeugen eines Formen-Miniaturbildes für eine Folienform mit benutzerdefinierten Abmessungen.
- Erzeugen eines Formen-Miniaturbildes innerhalb der Grenzen des Erscheinungsbildes einer Form.

## **Form-Miniaturbild aus einer Folie erzeugen**
Um ein Formen-Miniaturbild aus einer beliebigen Folie mit Aspose.Slides for PHP via Java zu erzeugen, gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)-Klasse.
1. Rufen Sie die Referenz einer beliebigen Folie anhand ihrer ID oder ihres Indexes ab.
1. [Holen Sie das Miniaturbild der Form](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getImage--) der referenzierten Folie in der Standardskala.
1. Speichern Sie das Miniaturbild im gewünschten Bildformat.

Dieser Beispielcode zeigt, wie man ein Formen-Miniaturbild aus einer Folie erzeugt:
```php
  # Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei repräsentiert
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Erstellen Sie ein Bild in voller Auflösung
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # Speichern Sie das Bild im PNG-Format auf der Festplatte
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Miniaturbild mit benutzerdefiniertem Skalierungsfaktor erzeugen**
Um das Formen-Miniaturbild einer Folie mit Aspose.Slides for PHP via Java zu erzeugen, gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)-Klasse.
1. Rufen Sie die Referenz einer beliebigen Folie anhand ihrer ID oder ihres Indexes ab.
1. [Holen Sie das Miniaturbild der Form](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getImage-int-float-float-) der referenzierten Folie mit benutzerdefinierten Abmessungen.
1. Speichern Sie das Miniaturbild im gewünschten Bildformat.

Dieser Beispielcode zeigt, wie man ein Formen-Miniaturbild basierend auf einem definierten Skalierungsfaktor erzeugt:
```php
  # Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Erstellen Sie ein Bild im Vollmaßstab
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Speichern Sie das Bild im PNG-Format auf der Festplatte
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Miniaturbild basierend auf Grenzen der Formdarstellung erstellen**
Diese Methode zur Erstellung von Miniaturbildern von Formen ermöglicht es Entwicklern, ein Miniaturbild innerhalb der Grenzen des Erscheinungsbildes der Form zu erzeugen. Dabei werden alle Formeffekte berücksichtigt. Das erzeugte Formen-Miniaturbild ist durch die Foliengrenzen eingeschränkt. Um ein Miniaturbild einer Folienform innerhalb ihrer Erscheinungsgrenzen zu erzeugen, gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)-Klasse.
1. Rufen Sie die Referenz einer beliebigen Folie anhand ihrer ID oder ihres Indexes ab.
1. Holen Sie das Miniaturbild der referenzierten Folie mit den Formgrenzen als Erscheinungsbild.
1. Speichern Sie das Miniaturbild im gewünschten Bildformat.

Dieser Beispielcode basiert auf den oben genannten Schritten:
```php
  # Instanziieren Sie eine Presentation‑Klasse, die die Präsentationsdatei repräsentiert
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Erstellen Sie ein Bild im Vollmaßstab
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Speichern Sie das Bild auf der Festplatte im PNG‑Format
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Welche Bildformate können beim Speichern von Formen-Miniaturbildern verwendet werden?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/), und andere. Formen können auch als Vektor‑SVG [exportiert werden](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/), indem der Inhalt der Form als SVG gespeichert wird.

**Was ist der Unterschied zwischen Shape- und Appearance-Grenzen beim Rendern eines Miniaturbildes?**

`Shape` verwendet die Geometrie der Form; `Appearance` berücksichtigt [visuelle Effekte](/slides/de/php-java/shape-effect/) (Schatten, Leuchten usw.).

**Was passiert, wenn eine Form als verborgen markiert ist? Wird sie trotzdem als Miniaturbild gerendert?**

Eine verborgene Form bleibt Teil des Modells und kann gerendert werden; das verborgene Flag beeinflusst die Darstellung in der Präsentation, verhindert jedoch nicht die Erzeugung des Bildes der Form.

**Werden Gruppenkörper, Diagramme, SmartArt und andere komplexe Objekte unterstützt?**

Ja. Jedes als [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) dargestellte Objekt (einschließlich [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/), und [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)) kann als Miniaturbild oder als SVG gespeichert werden.

**Beeinflussen systeminstallierte Schriftarten die Qualität von Miniaturbildern für Textformen?**

Ja. Sie sollten die erforderlichen Schriftarten [bereitstellen](/slides/de/php-java/custom-font/) (oder [Schriftart‑Substitutionen konfigurieren](/slides/de/php-java/font-substitution/)), um unerwünschte Rückfälle und Textumbruch zu vermeiden.