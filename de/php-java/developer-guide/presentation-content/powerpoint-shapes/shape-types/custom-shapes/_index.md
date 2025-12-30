---
title: "Formen in Präsentationen mit PHP anpassen"
linktitle: "Benutzerdefinierte Form"
type: docs
weight: 20
url: /de/php-java/custom-shape/
keywords:
- benutzerdefinierte Form
- Form hinzufügen
- Form erstellen
- Form ändern
- Formgeometrie
- Geometriepfad
- Pfadpunkte
- Bearbeitungspunkte
- Punkt hinzufügen
- Punkt entfernen
- Bearbeitungsoperation
- abgerundete Ecke
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erstellen und Anpassen von Formen in PowerPoint‑Präsentationen mit Aspose.Slides für PHP über Java: Geometriepfade, abgerundete Ecken, zusammengesetzte Formen."
---

## **Form mit Bearbeitungspunkten ändern**
Betrachten Sie ein Quadrat. In PowerPoint können Sie mit **Bearbeitungspunkten** 

* den Eckpunkt des Quadrats hinein- oder herausziehen
* die Krümmung eines Eckpunkts oder Punktes festlegen
* neue Punkte zum Quadrat hinzufügen
* Punkte auf dem Quadrat manipulieren usw. 

Im Wesentlichen können Sie die beschriebenen Aufgaben mit jeder Form ausführen. Mit Bearbeitungspunkten können Sie eine Form ändern oder aus einer bestehenden Form eine neue erstellen. 

## **Tipps zur Formbearbeitung**

![overview_image](custom_shape_0.png)

Bevor Sie beginnen, PowerPoint‑Formen über Bearbeitungspunkte zu bearbeiten, sollten Sie diese Punkte zu Formen berücksichtigen:

* Eine Form (oder ihr Pfad) kann entweder geschlossen oder offen sein.
* Wenn eine Form geschlossen ist, hat sie keinen Anfang- oder Endpunkt. Wenn eine Form offen ist, hat sie einen Beginn und ein Ende. 
* Alle Formen bestehen aus mindestens 2 Ankerpunkten, die durch Linien miteinander verbunden sind
* Eine Linie ist entweder gerade oder gekrümmt. Ankerpunkte bestimmen die Art der Linie. 
* Ankerpunkte existieren als Eckpunkte, gerade Punkte oder glatte Punkte:
  * Ein Eckpunkt ist ein Punkt, an dem sich 2 gerade Linien in einem Winkel treffen. 
  * Ein glatter Punkt ist ein Punkt, an dem 2 Griffe in einer geraden Linie existieren und die Segmente der Linie in einer sanften Kurve zusammenlaufen. In diesem Fall sind alle Griffe vom Ankerpunkt mit gleichem Abstand getrennt. 
  * Ein gerader Punkt ist ein Punkt, an dem 2 Griffe in einer geraden Linie existieren und die Segmente der Linie in einer glatten Kurve zusammenlaufen. In diesem Fall müssen die Griffe nicht mit gleichem Abstand vom Ankerpunkt getrennt sein. 
* Durch Verschieben oder Bearbeiten von Ankerpunkten (die den Winkel der Linien ändern) können Sie das Aussehen einer Form verändern. 

Um PowerPoint‑Formen über Bearbeitungspunkte zu bearbeiten, stellt **Aspose.Slides** die Klasse [**GeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) und das Interface [**IGeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath) bereit.

* Eine [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath)-Instanz repräsentiert einen Geometriepfad des [IGeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape)-Objekts.
* Um das `GeometryPath` von der `IGeometryShape`‑Instanz abzurufen, können Sie die Methode [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#getGeometryPaths--) verwenden.
* Um den `GeometryPath` für eine Form festzulegen, können Sie diese Methoden verwenden: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) für *solide Formen* und [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) für *komposite Formen*.
* Um Segmente hinzuzufügen, können Sie die Methoden unter [IGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath) verwenden.
* Mit den Methoden [IGeometryPath.setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#setStroke-boolean-) und [IGeometryPath.setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#setFillMode-byte-) können Sie das Aussehen eines Geometriepfads festlegen.
* Mit der Methode [IGeometryPath.getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#getPathData--) können Sie den Geometriepfad einer `GeometryShape` als Array von Pfadsegmenten abrufen.
* Um weitere Anpassungsoptionen für Formgeometrien zu erhalten, können Sie [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) in [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) konvertieren.
* Verwenden Sie die Methoden [geometryPathToGraphicsPath](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) und [graphicsPathToGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (aus der Klasse [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil)), um [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) in [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) hin und her zu konvertieren.

## **Einfache Bearbeitungsoperationen**

Dieser PHP‑Code zeigt Ihnen, wie Sie

**Zeile hinzufügen** zum Ende eines Pfads
```php

```

**Zeile hinzufügen** an einer angegebenen Position eines Pfads:
```php

```

**Kubische Bézier‑Kurve hinzufügen** am Ende eines Pfads:
```php

```

**Kubische Bézier‑Kurve hinzufügen** an der angegebenen Position eines Pfads:
```php

```

**Quadratische Bézier‑Kurve hinzufügen** am Ende eines Pfads:
```php

```

**Quadratische Bézier‑Kurve hinzufügen** an einer angegebenen Position eines Pfads:
```php

```

**Einen gegebenen Bogen anhängen** an einen Pfad:
```php

```

**Die aktuelle Figur** eines Pfads schließen:
```php

```

**Position für den nächsten Punkt festlegen**:
```php

```

**Pfadsegment entfernen** an einem angegebenen Index:
```php

```


## **Benutzerdefinierte Punkte zu einer Form hinzufügen**

1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) und setzen Sie den Typ [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType).
2. Holen Sie eine Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) aus der Form.
3. Fügen Sie einen neuen Punkt zwischen den beiden oberen Punkten des Pfads hinzu.
4. Fügen Sie einen neuen Punkt zwischen den beiden unteren Punkten des Pfads hinzu.
5. Wenden Sie den Pfad auf die Form an.

Dieser PHP‑Code zeigt, wie man benutzerdefinierte Punkte zu einer Form hinzufügt:
```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);
    $shape->setGeometryPath($geometryPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![example1_image](custom_shape_1.png)

## **Punkte aus einer Form entfernen**

1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) und setzen Sie den Typ [ShapeType::Heart](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType).
2. Holen Sie eine Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) aus der Form.
3. Entfernen Sie das Segment des Pfads.
4. Wenden Sie den Pfad auf die Form an.

Dieser PHP‑Code zeigt, wie man Punkte aus einer Form entfernt:
```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);
    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);
    $shape->setGeometryPath($path);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![example2_image](custom_shape_2.png)

## **Benutzerdefinierte Form erstellen**

1. Berechnen Sie die Punkte für die Form.
2. Erstellen Sie eine Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).
3. Füllen Sie den Pfad mit den Punkten.
4. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).
5. Wenden Sie den Pfad auf die Form an.

Dieses Java‑Beispiel zeigt, wie man eine benutzerdefinierte Form erstellt:
```php
  $points = new Java("java.util.ArrayList");
  $R = 100;
  $r = 50;
  $step = 72;
  for($angle = -90; $angle < 270; $angle += $step) {
    $radians = $angle * java("java.lang.Math")->PI / 180.0;
    $x = $R * java("java.lang.Math")->cos($radians);
    $y = $R * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
    $radians = java("java.lang.Math")->PI * $angle . $step / 2 / 180.0;
    $x = $r * java("java.lang.Math")->cos($radians);
    $y = $r * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
  }
  $starPath = new GeometryPath();
  $starPath->moveTo($points->get(0));
  for($i = 1; $i < java_values($points->size()) ; $i++) {
    $starPath->lineTo($points->get($i));
  }
  $starPath->closeFigure();
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $R * 2, $R * 2);
    $shape->setGeometryPath($starPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![example3_image](custom_shape_3.png)

## **Zusammengesetzte benutzerdefinierte Form erstellen**

1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).
2. Erstellen Sie eine erste Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).
3. Erstellen Sie eine zweite Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).
4. Wenden Sie die Pfade auf die Form an.

Dieser PHP‑Code zeigt, wie man eine zusammengesetzte benutzerdefinierte Form erstellt:
```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath0 = new GeometryPath();
    $geometryPath0->moveTo(0, 0);
    $geometryPath0->lineTo($shape->getWidth(), 0);
    $geometryPath0->lineTo($shape->getWidth(), $shape->getHeight() / 3);
    $geometryPath0->lineTo(0, $shape->getHeight() / 3);
    $geometryPath0->closeFigure();
    $geometryPath1 = new GeometryPath();
    $geometryPath1->moveTo(0, $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight());
    $geometryPath1->lineTo(0, $shape->getHeight());
    $geometryPath1->closeFigure();
    $shape->setGeometryPaths(array($geometryPath0, $geometryPath1 ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![example4_image](custom_shape_4.png)

## **Benutzerdefinierte Form mit abgerundeten Ecken erstellen**

Dieser PHP‑Code zeigt, wie man eine benutzerdefinierte Form mit gekrümmten Ecken (nach innen) erstellt:
```php
  $shapeX = 20.0;
  $shapeY = 20.0;
  $shapeWidth = 300.0;
  $shapeHeight = 200.0;
  $leftTopSize = 50.0;
  $rightTopSize = 20.0;
  $rightBottomSize = 40.0;
  $leftBottomSize = 10.0;
  $pres = new Presentation();
  try {
    $childShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);
    $geometryPath = new GeometryPath();
    $point1 = new Point2DFloat($leftTopSize, 0);
    $point2 = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $point3 = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $point4 = new Point2DFloat($leftBottomSize, $shapeHeight);
    $point5 = new Point2DFloat(0, $leftTopSize);
    $geometryPath->moveTo($point1);
    $geometryPath->lineTo($point2);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($point3);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($point4);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($point5);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();
    $childShape->setGeometryPath($geometryPath);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Ermitteln, ob die Geometrie einer Form geschlossen ist**

Eine geschlossene Form ist definiert als eine, bei der alle Seiten verbunden sind und eine einzige Grenze ohne Lücken bilden. Eine solche Form kann eine einfache geometrische Form oder ein komplexes benutzerdefiniertes Kontur sein. Das folgende Codebeispiel zeigt, wie man prüft, ob die Geometrie einer Form geschlossen ist:
```php
function isGeometryClosed($geometryShape)
{
    $isClosed = null;

    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $dataLength = count(java_values($geometryPath->getPathData()));
        if ($dataLength === 0) {
            continue;
        }

        $lastSegment = java_values($geometryPath->getPathData())[$dataLength - 1];
        $isClosed = $lastSegment->getPathCommand() === PathCommandType::Close;

        if ($isClosed === false) {
            return false;
        }
    }

    return $isClosed === true;
}
```


## **GeometryPath in java.awt.Shape konvertieren**

1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).
2. Erstellen Sie eine Instanz der Klasse [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).
3. Konvertieren Sie die [java.awt.Shape]-Instanz mittels [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil) in eine [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath)-Instanz.
4. Wenden Sie die Pfade auf die Form an.

Dieser PHP‑Code — eine Umsetzung der obigen Schritte — demonstriert den **GeometryPath**‑zu‑**GraphicsPath**‑Konvertierungsprozess:
```php
  $pres = new Presentation();
  try {
    # Neue Form erstellen
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    # Geometriepfad der Form abrufen
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);
    # Neuer Grafikpfad mit Text erstellen
    $graphicsPath;
    $font = new Font("Arial", Font->PLAIN, 40);
    $text = "Text in shape";
    $img = new BufferedImage(100, 100, BufferedImage->TYPE_INT_ARGB);
    $g2 = $img->createGraphics();
    try {
      $glyphVector = $font->createGlyphVector($g2->getFontRenderContext(), $text);
      $graphicsPath = $glyphVector->getOutline(20.0, -$glyphVector->getVisualBounds()->getY() + 10);
    } finally {
      $g2->dispose();
    }
    # Grafikpfad in Geometriepfad konvertieren
    $textPath = ShapeUtil->graphicsPathToGeometryPath($graphicsPath);
    $textPath->setFillMode(PathFillModeType::Normal);
    # Kombination aus neuem Geometriepfad und Ursprungspfad der Form setzen
    $shape->setGeometryPaths(array($originalPath, $textPath ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![example5_image](custom_shape_5.png)

## **FAQ**

**Was passiert mit Füllung und Kontur, nachdem die Geometrie ersetzt wurde?**

Der Stil bleibt bei der Form; es ändert sich nur die Kontur. Füllung und Kontur werden automatisch auf die neue Geometrie angewendet.

**Wie kann ich eine benutzerdefinierte Form zusammen mit ihrer Geometrie korrekt drehen?**

Verwenden Sie die Methode [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setrotation/) der Form; die Geometrie dreht sich mit der Form, weil sie an das eigene Koordinatensystem der Form gebunden ist.

**Kann ich eine benutzerdefinierte Form in ein Bild konvertieren, um das Ergebnis zu „sperren“?**

Ja. Exportieren Sie den gewünschten [slide](/slides/de/php-java/convert-powerpoint-to-png/)-Bereich oder die [shape](/slides/de/php-java/create-shape-thumbnails/)-Selbst in ein Rasterformat; das vereinfacht die weitere Arbeit mit aufwändigen Geometrien.