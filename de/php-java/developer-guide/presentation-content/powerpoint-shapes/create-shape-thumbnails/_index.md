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
- Formdarstellung
- visuelle Begrenzungen
- Formbegrenzungen
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erstellen Sie hochwertige Miniaturbilder von Formen aus PowerPoint‑Folien mit Aspose.Slides für PHP via Java – einfach Präsentations‑Miniaturbilder erzeugen und exportieren."
---
## **Einleitung**

Aspose.Slides wird verwendet, um Präsentationsdateien zu erstellen, bei denen jede Seite eine Folie ist. Diese Folien können angezeigt werden, indem die Präsentationsdateien mit Microsoft PowerPoint geöffnet werden. Manchmal müssen Entwickler jedoch die Bilder der Formen separat in einem Bildbetrachter betrachten. In solchen Fällen hilft Aspose.Slides beim Erzeugen von Miniaturbildern der Folienformen. Wie diese Funktion verwendet wird, wird in diesem Artikel beschrieben.

Dieser Artikel erklärt, wie Miniaturbilder von Folien auf verschiedene Arten erzeugt werden können:

- Erzeugen eines Miniaturbildes einer Form innerhalb einer Folie.
- Erzeugen eines Miniaturbildes einer Form mit benutzerdefinierten Abmessungen.
- Erzeugen eines Miniaturbildes innerhalb der Begrenzungen des Erscheinungsbildes einer Form.

## **Miniaturbild einer Form aus einer Folie generieren**
Um ein Miniaturbild einer Form aus einer beliebigen Folie mit Aspose.Slides für PHP via Java zu erzeugen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation)-Klasse.
2. Holen Sie sich die Referenz einer beliebigen Folie über ihre ID oder ihren Index.
3. [Abrufen des Form-Miniaturbildes](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/#getImage) der referenzierten Folie in Standardgröße.
4. Speichern Sie das Miniaturbild im gewünschten Bildformat.

Der folgende Beispielcode zeigt, wie ein Miniaturbild einer Form aus einer Folie erzeugt wird:

```php
  # Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Erstellen Sie ein Bild in voller Auflösung
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # Speichern Sie das Bild auf der Festplatte im PNG-Format
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

## **Miniaturbild mit benutzerdefiniertem Skalierungsfaktor generieren**
Um das Miniaturbild einer Form aus einer Folie mit Aspose.Slides für PHP via Java zu erzeugen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation)-Klasse.
2. Holen Sie sich die Referenz einer beliebigen Folie über ihre ID oder ihren Index.
3. [Abrufen des Form-Miniaturbildes](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/#getImage) der referenzierten Folie mit benutzerdefinierten Abmessungen.
4. Speichern Sie das Miniaturbild im gewünschten Bildformat.

Der folgende Beispielcode zeigt, wie ein Miniaturbild einer Form anhand eines definierten Skalierungsfaktors erzeugt wird:

```php
  # Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Erstellen Sie ein Bild in voller Auflösung
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Speichern Sie das Bild auf der Festplatte im PNG-Format
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

## **Miniaturbild basierend auf den Begrenzungen des Erscheinungsbildes einer Form erstellen**
Diese Methode ermöglicht es Entwicklern, ein Miniaturbild innerhalb der Begrenzungen des Erscheinungsbildes einer Form zu erzeugen. Dabei werden alle Formeffekte berücksichtigt. Das erzeugte Miniaturbild ist durch die Folienbegrenzungen eingeschränkt. So erzeugen Sie ein Miniaturbild einer Folienform im Erscheinungsbildbereich:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation)-Klasse.
2. Holen Sie sich die Referenz einer beliebigen Folie über ihre ID oder ihren Index.
3. Holen Sie das Miniaturbild der referenzierten Folie mit den Formbegrenzungen als Erscheinungsbild.
4. Speichern Sie das Miniaturbild im gewünschten Bildformat.

Der folgende Beispielcode basiert auf den oben genannten Schritten:

```php
  # Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Erstellen Sie ein Bild in voller Auflösung
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Speichern Sie das Bild auf der Festplatte im PNG-Format
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

## **Tatsächliche visuelle Begrenzungen einer Form ermitteln**

Die Rahmen­eigenschaften von [Shape](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/) — `Shape::getX()`, `Shape::getY()`, `Shape::getWidth()` und `Shape::getHeight()` — beschreiben das Rechteck, das im Präsentationsmodell gespeichert ist. Der tatsächlich gerenderte Inhalt kann über diesen Rahmen hinausgehen oder ein anderes achsen­ausgerichtetes Rechteck einnehmen. Drehungen, Konturen, Pfeilspitzen, Textlayout und -überlauf, generierte SmartArt‑Geometrie und andere Rendering‑Effekte können den belegten Bereich verändern.

Verwenden Sie [Shape::getVisualBounds](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/#getVisualBounds), um diesen belegten Bereich zu berechnen, ohne ein Bild zu erstellen. Die Methode gibt ein [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) in Folienkoordinaten zurück. Das zurückgegebene Rechteck ist nicht auf die Folie zugeschnitten, sodass seine Koordinaten negativ sein können, wenn der Inhalt über den Ursprung der Folie hinausgeht.

Das folgende Beispiel ermittelt und vergleicht den Rahmen und die visuellen Begrenzungen:

```php
  $presentation = new Presentation("example.pptx");
  try {
      $slide = $presentation->getSlides()->get_Item(0);
      $shape = $slide->getShapes()->get_Item(0);

      $visualBounds = $shape->getVisualBounds();

      $frameX = $shape->getX();
      $frameY = $shape->getY();
      $frameWidth = $shape->getWidth();
      $frameHeight = $shape->getHeight();

      $visualX = $visualBounds->getX();
      $visualY = $visualBounds->getY();
      $visualWidth = $visualBounds->getWidth();
      $visualHeight = $visualBounds->getHeight();

      echo "Frame bounds (x, y, width, height): $frameX, $frameY, $frameWidth, $frameHeight\n";
      echo "Visual bounds (x, y, width, height): $visualX, $visualY, $visualWidth, $visualHeight\n";
  } finally {
      $presentation->dispose();
  }
```

Das gleiche [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) kann verwendet werden, um benachbarte Formen links, rechts, oben oder unten auszurichten; genügend Platz in einem erzeugten Layout zu reservieren; oder Inhalte außerhalb eines zulässigen Bereichs zu erkennen. Visuelle Begrenzungen sind besonders nützlich für SmartArt, Textfelder, Pfeile, Bilder, gedrehte Formen und Gruppierungen, bei denen der gespeicherte Rahmen das vollständige gerenderte Ergebnis nicht darstellt.

Verwenden Sie [Shape::getVisualBounds](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/#getVisualBounds), wenn Sie Koordinaten für Layout oder Validierung benötigen und kein Bitmap benötigen. Verwenden Sie [Shape::getImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/#getImage), wenn Sie die Form rendern müssen. Mit [ShapeThumbnailBounds](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapethumbnailbounds/) bestimmt `ShapeThumbnailBounds::Shape` die Bildgröße anhand der Formbegrenzungen, einschließlich Kontur‑Einstellungen, während `ShapeThumbnailBounds::Appearance` die Größe anhand des Erscheinungsbildes der Form bestimmt und das Ergebnis auf die Folienbegrenzungen beschränkt. Im Gegensatz dazu gibt `Shape::getVisualBounds` nur das berechnete Rechteck zurück und schneidet es nicht an die Folie zu.

## **FAQ**

**Welche Bildformate können beim Speichern von Form‑Miniaturbildern verwendet werden?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/de/php-java/aspose.slides/imageformat/), und weitere. Formen können auch als Vektor‑SVG [exportiert werden](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/writeassvg/), indem ihr Inhalt als SVG gespeichert wird.

**Was ist der Unterschied zwischen den Begrenzungen „Shape“ und „Appearance“ beim Rendern eines Miniaturbildes?**

`Shape` verwendet die Geometrie der Form; `Appearance` berücksichtigt die [visuellen Effekte](/slides/de/php-java/shape-effect/) (Schatten, Leuchten usw.).

**Was passiert, wenn eine Form als verborgen markiert ist? Wird sie trotzdem als Miniaturbild gerendert?**

Eine verborgene Form bleibt Teil des Modells und kann gerendert werden; das Verborgen‑Flag beeinflusst die Anzeige in einer Diashow, verhindert jedoch nicht die Erzeugung des Form‑Bildes.

**Werden Gruppierungsformen, Diagramme, SmartArt und andere komplexe Objekte unterstützt?**

Ja. Jedes Objekt, das als [Shape](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/) dargestellt wird (einschließlich [GroupShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/de/php-java/aspose.slides/chart/) und [SmartArt](https://reference.aspose.com/slides/de/php-java/aspose.slides/smartart/)), kann als Miniaturbild oder als SVG gespeichert werden.

**Beeinflussen systemweit installierte Schriftarten die Qualität von Miniaturbildern für Textformen?**

Ja. Sie sollten die erforderlichen Schriftarten bereitstellen (/slides/de/php-java/custom-font/) (oder [Schriftarten‑Ersetzungen konfigurieren](/slides/de/php-java/font-substitution/)), um unerwünschte Rückfallschriftarten und Textumbrüche zu vermeiden.