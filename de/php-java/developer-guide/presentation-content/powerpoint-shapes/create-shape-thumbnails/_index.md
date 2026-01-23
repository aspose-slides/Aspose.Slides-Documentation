---
title: Miniaturbilder von Präsentationsformen in PHP erstellen
linktitle: Form-Miniaturbilder
type: docs
weight: 70
url: /de/php-java/create-shape-thumbnails/
keywords:
- Form-Miniaturbild
- Formbild
- Form rendern
- Form-Rendering
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erstellen Sie hochwertige Form-Miniaturbilder aus PowerPoint-Folien mit Aspose.Slides für PHP via Java – einfach Präsentationsminiaturbilder erzeugen und exportieren."
---

## **Übersicht**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java kann verwendet werden, um Präsentationsdateien zu erstellen, bei denen jede Seite einer Folie entspricht. Die Folien können angezeigt werden, indem die Präsentationsdateien mit Microsoft PowerPoint geöffnet werden. Entwickler müssen jedoch manchmal die Bilder der Formen separat in einem Bildbetrachter ansehen. In solchen Fällen hilft Aspose.Slides for PHP via Java, Miniaturbilder der Folienformen zu erzeugen.

{{% /alert %}} 

In diesem Thema zeigen wir, wie Miniaturbilder von Folien in verschiedenen Situationen generiert werden können:

- Generieren eines Form‑Miniaturbildes innerhalb einer Folie.
- Generieren eines Form‑Miniaturbildes für eine Folienform mit benutzerdefinierten Abmessungen.
- Generieren eines Form‑Miniaturbildes innerhalb der Grenzen des Aussehens einer Form.

## **Shape‑Thumbnail aus einer Folie generieren**
Um ein Shape‑Thumbnail aus einer beliebigen Folie mit Aspose.Slides for PHP via Java zu erzeugen, gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)-Klasse.
1. Holen Sie sich die Referenz einer beliebigen Folie über deren ID oder Index.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) der referenzierten Folie in der Standard‑Skalierung.
1. Speichern Sie das Miniaturbild in Ihrem gewünschten Bildformat.

Dieser Beispielcode zeigt, wie ein Shape‑Thumbnail aus einer Folie generiert wird:
```php
  # Instanziiere eine Presentation-Klasse, die die Präsentationsdatei darstellt
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Erstelle ein Bild in voller Auflösung
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # Speichere das Bild auf der Festplatte im PNG-Format
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


## **Thumbnail mit benutzerdefiniertem Skalierungsfaktor generieren**
Um das Shape‑Thumbnail einer Folie mit Aspose.Slides for PHP via Java zu erzeugen, gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)-Klasse.
1. Holen Sie sich die Referenz einer beliebigen Folie über deren ID oder Index.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) der referenzierten Folie mit benutzerdefinierten Abmessungen.
1. Speichern Sie das Miniaturbild in Ihrem gewünschten Bildformat.

Dieser Beispielcode zeigt, wie ein Shape‑Thumbnail auf Basis eines definierten Skalierungsfaktors generiert wird:
```php
  # Instanziiere eine Presentation-Klasse, die die Präsentationsdatei repräsentiert
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Erstelle ein Bild in voller Auflösung
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Speichere das Bild auf der Festplatte im PNG-Format
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


## **Thumbnail basierend auf Bounds‑basiertem Form‑Auftritt erstellen**
Diese Methode zum Erstellen von Miniaturbildern von Formen ermöglicht es Entwicklern, ein Miniaturbild innerhalb der Grenzen des Auftritts einer Form zu erzeugen. Dabei werden alle Form‑Effekte berücksichtigt. Das erzeugte Shape‑Thumbnail ist durch die Folien‑Bounds eingeschränkt. Um ein Miniaturbild einer Folienform im Rahmen ihres Auftritts zu erzeugen, gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)-Klasse.
1. Holen Sie sich die Referenz einer beliebigen Folie über deren ID oder Index.
1. Obtaining the thumbnail image of the referenced slide with shape bounds as appearance.
1. Speichern Sie das Miniaturbild in Ihrem gewünschten Bildformat.

Dieser Beispielcode basiert auf den obigen Schritten:
```php
  # Instanziiere eine Presentation-Klasse, die die Präsentationsdatei darstellt
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Erstelle ein Bild in voller Auflösung
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Speichere das Bild auf der Festplatte im PNG-Format
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

**Welche Bildformate können beim Speichern von Shape‑Thumbnails verwendet werden?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/), und weitere. Formen können auch als Vektor‑SVG [exportiert werden](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/), indem der Inhalt der Form als SVG gespeichert wird.

**Was unterscheidet Shape‑ und Appearance‑Bounds beim Rendern eines Thumbnails?**

`Shape` verwendet die Geometrie der Form; `Appearance` berücksichtigt [visuelle Effekte](/slides/de/php-java/shape-effect/) (Schatten, Leuchten usw.).

**Was geschieht, wenn eine Form als versteckt markiert ist? Wird sie trotzdem als Thumbnail gerendert?**

Eine versteckte Form bleibt Teil des Modells und kann gerendert werden; das versteckte Flag beeinflusst die Anzeige in der Präsentation, verhindert jedoch nicht die Generierung des Bildes der Form.

**Werden Gruppierungsformen, Diagramme, SmartArt und andere komplexe Objekte unterstützt?**

Ja. Jedes Objekt, das als [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) dargestellt wird (einschließlich [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) und [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)), kann als Thumbnail oder als SVG gespeichert werden.

**Beeinflussen systemweit installierte Schriftarten die Qualität von Thumbnails für Textformen?**

Ja. Sie sollten die erforderlichen Schriftarten bereitstellen (/slides/de/php-java/custom-font/) (oder [Schriftart‑Substitutionen konfigurieren](/slides/de/php-java/font-substitution/)), um unerwünschte Fallbacks und Textumfluss zu vermeiden.