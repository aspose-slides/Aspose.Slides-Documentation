---
title: Benutzerdefinierte Form
type: docs
weight: 20
url: /php-java/custom-shape/
keywords: "PowerPoint-Form, benutzerdefinierte Form, PowerPoint-Präsentation, Java, Aspose.Slides für PHP über Java"
description: "Fügen Sie eine benutzerdefinierte Form in eine PowerPoint-Präsentation ein."
---

# Ändern einer Form mithilfe von Bearbeitungspunkten
Betrachten Sie ein Quadrat. In PowerPoint können Sie mithilfe von **Bearbeitungspunkten** 

* die Ecke des Quadrats nach innen oder außen verschieben
* die Krümmung für eine Ecke oder einen Punkt angeben
* neue Punkte zum Quadrat hinzufügen
* Punkte auf dem Quadrat manipulieren usw. 

Im Wesentlichen können Sie die beschriebenen Aufgaben an jeder Form ausführen. Mit Bearbeitungspunkten können Sie eine Form ändern oder eine neue Form aus einer bestehenden Form erstellen.

## **Tipps zur Formbearbeitung**

![overview_image](custom_shape_0.png)

Bevor Sie PowerPoint-Formen über Bearbeitungspunkte bearbeiten, sollten Sie diese Punkte zu Formen berücksichtigen:

* Eine Form (oder ihr Pfad) kann entweder geschlossen oder offen sein.
* Wenn eine Form geschlossen ist, fehlt ihr ein Start- oder Endpunkt. Wenn eine Form offen ist, hat sie einen Anfang und ein Ende.
* Alle Formen bestehen aus mindestens 2 Ankerpunkten, die durch Linien miteinander verbunden sind.
* Eine Linie ist entweder gerade oder gekrümmt. Ankerpunkte bestimmen die Art der Linie.
* Ankerpunkte existieren als Eckpunkte, gerade Punkte oder glatte Punkte:
  * Ein Eckpunkt ist ein Punkt, an dem 2 gerade Linien in einem Winkel zusammenkommen.
  * Ein glatter Punkt ist ein Punkt, an dem 2 Griffe in einer geraden Linie existieren und die Segmente der Linie in einer sanften Kurve zusammenlaufen. In diesem Fall sind alle Griffe vom Ankerpunkt durch einen gleichen Abstand getrennt.
  * Ein gerader Punkt ist ein Punkt, an dem 2 Griffe in einer geraden Linie existieren und die Segmente dieser Linie in einer sanften Kurve zusammenlaufen. In diesem Fall müssen die Griffe nicht durch einen gleichen Abstand vom Ankerpunkt getrennt sein.
* Durch Verschieben oder Bearbeiten von Ankerpunkten (was den Winkel der Linien ändert) können Sie das Aussehen einer Form ändern.

Um PowerPoint-Formen über Bearbeitungspunkte zu bearbeiten, stellt **Aspose.Slides** die [**GeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) Klasse und die [**IGeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath) Schnittstelle zur Verfügung.

* Eine [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) Instanz repräsentiert einen Geometriestandardpfad des [IGeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape) Objekts.
* Um den `GeometryPath` von der `IGeometryShape` Instanz abzurufen, können Sie die Methode [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#getGeometryPaths--) verwenden.
* Um den `GeometryPath` für eine Form festzulegen, können Sie diese Methoden verwenden: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) für *fest definierte Formen* und [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) für *komplexe Formen*.
* Um Segmente hinzuzufügen, können Sie die Methoden unter [IGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath) verwenden.
* Mithilfe der Methoden [IGeometryPath.setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#setStroke-boolean-) und [IGeometryPath.setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#setFillMode-byte-) können Sie das Aussehen eines Geometriestandardpfads festlegen.
* Mit der Methode [IGeometryPath.getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#getPathData--) können Sie den Geometriestandardpfad eines `GeometryShape` als Array von Pfadsegmenten abrufen.
* Um zusätzliche Optionen zur Anpassung der Formgeometrie zuzugreifen, können Sie [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) in [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) umwandeln.
* Verwenden Sie die Methoden [geometryPathToGraphicsPath](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) und [graphicsPathToGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (aus der [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil) Klasse), um [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) zwischen [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) hin und her umzuwandeln.

## **Einfache Bearbeitungsoperationen**

Dieser PHP-Code zeigt Ihnen, wie Sie

**Eine Linie** am Ende eines Pfades hinzufügen:

```php

```
**Eine Linie** an einer bestimmten Position auf einem Pfad hinzufügen:

```php

```
**Eine kubische Bezier-Kurve** am Ende eines Pfades hinzufügen:

```php

```
**Eine kubische Bezier-Kurve** an einer bestimmten Position auf einem Pfad hinzufügen:

```php

```
**Eine quadratische Bezier-Kurve** am Ende eines Pfades hinzufügen:

```php

```
**Eine quadratische Bezier-Kurve** an einer bestimmten Position auf einem Pfad hinzufügen:

```php

```
**Einen gegebenen Bogen** zu einem Pfad hinzufügen:

```php

```
**Die aktuelle Figur** eines Pfades schließen:

```php

```
**Die Position für den nächsten Punkt** festlegen:

```php

```
**Das Pfadsegment** an einem bestimmten Index entfernen:

```php

```

## **Benutzerdefinierte Punkte zur Form hinzufügen**
1. Erstellen Sie eine Instanz der [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) Klasse und setzen Sie den [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType) Typ.
2. Holen Sie sich eine Instanz der [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) Klasse von der Form.
3. Fügen Sie einen neuen Punkt zwischen den beiden oberen Punkten auf dem Pfad hinzu.
4. Fügen Sie einen neuen Punkt zwischen den beiden unteren Punkten auf dem Pfad hinzu.
5. Wenden Sie den Pfad auf die Form an.

Dieser PHP-Code zeigt Ihnen, wie Sie benutzerdefinierte Punkte zu einer Form hinzufügen:

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

## Punkte von der Form entfernen

1. Erstellen Sie eine Instanz der [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) Klasse und setzen Sie den [ShapeType::Heart](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType) Typ.
2. Holen Sie sich eine Instanz der [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) Klasse von der Form.
3. Entfernen Sie das Segment für den Pfad.
4. Wenden Sie den Pfad auf die Form an.

Dieser PHP-Code zeigt Ihnen, wie Sie Punkte von einer Form entfernen:

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

##  **Benutzerdefinierte Form erstellen**

1. Berechnen Sie die Punkte für die Form.
2. Erstellen Sie eine Instanz der [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) Klasse.
3. Füllen Sie den Pfad mit den Punkten.
4. Erstellen Sie eine Instanz der [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) Klasse.
5. Wenden Sie den Pfad auf die Form an.

Dieser Java-Code zeigt Ihnen, wie Sie eine benutzerdefinierte Form erstellen:

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


## **Komplexe benutzerdefinierte Form erstellen**

1. Erstellen Sie eine Instanz der [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) Klasse.
2. Erstellen Sie eine erste Instanz der [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) Klasse.
3. Erstellen Sie eine zweite Instanz der [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) Klasse.
4. Wenden Sie die Pfade auf die Form an.

Dieser PHP-Code zeigt Ihnen, wie Sie eine komplexe benutzerdefinierte Form erstellen:

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

Dieser PHP-Code zeigt Ihnen, wie Sie eine benutzerdefinierte Form mit abgerundeten Ecken (nach innen) erstellen:

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

## **GeometryPath in java.awt.Shape konvertieren** 

1. Erstellen Sie eine Instanz der [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) Klasse.
2. Erstellen Sie eine Instanz der [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) Klasse.
3. Konvertieren Sie die [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) Instanz in die [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) Instanz mithilfe von [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil).
4. Wenden Sie die Pfade auf die Form an.

Dieser PHP-Code – eine Implementierung der oben genannten Schritte – demonstriert den **GeometryPath** zu **GraphicsPath** Konvertierungsprozess:

```php
  $pres = new Presentation();
  try {
    # Erstellen Sie eine neue Form
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    # Holen Sie sich den Geometriestandardpfad der Form
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);
    # Erstellen Sie einen neuen Grafikpfad mit Text
    $graphicsPath;
    $font = new Font("Arial", Font->PLAIN, 40);
    $text = "Text in der Form";
    $img = new BufferedImage(100, 100, BufferedImage->TYPE_INT_ARGB);
    $g2 = $img->createGraphics();
    try {
      $glyphVector = $font->createGlyphVector($g2->getFontRenderContext(), $text);
      $graphicsPath = $glyphVector->getOutline(20.0, -$glyphVector->getVisualBounds()->getY() + 10);
    } finally {
      $g2->dispose();
    }
    # Konvertieren Sie den Grafikpfad in einen Geometriestandardpfad
    $textPath = ShapeUtil->graphicsPathToGeometryPath($graphicsPath);
    $textPath->setFillMode(PathFillModeType::Normal);
    # Kombinieren Sie den neuen Geometriestandardpfad und den ursprünglichen Geometriestandardpfad zur Form
    $shape->setGeometryPaths(array($originalPath, $textPath ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example5_image](custom_shape_5.png)