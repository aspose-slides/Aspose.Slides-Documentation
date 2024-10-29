---
title: Formenformatierung
type: docs
weight: 20
url: /de/php-java/shape-formatting/
keywords: "Form formatieren, Linien formatieren, Verbindungstile formatieren, Verlaufshintergrund, Musterfüllung, Bildfüllung, einfarbige Füllung, Formen drehen, 3D-Prägeffekte, 3D-Rotationseffekt, PowerPoint-Präsentation, Java, Aspose.Slides für PHP über Java"
description: "Form in PowerPoint-Präsentation formatieren"
---

In PowerPoint können Sie Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, können Sie Formen formatieren, indem Sie bestimmte Effekte auf ihre Bestandteile anwenden oder sie ändern. Darüber hinaus können Sie Formen formatieren, indem Sie Einstellungen festlegen, die bestimmen, wie sie (der Bereich darin) gefüllt werden.

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides für PHP über Java** bietet Schnittstellen und Eigenschaften, mit denen Sie Formen basierend auf bekannten Optionen in PowerPoint formatieren können.

## **Linien formatieren**

Mit Aspose.Slides können Sie Ihren bevorzugten Linienstil für eine Form angeben. Diese Schritte skizzieren ein solches Verfahren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie der Folie eine [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) hinzu.
4. Setzen Sie eine Farbe für die Linien der Form.
5. Setzen Sie die Breite der Linien der Form.
6. Setzen Sie den [Linienstil](https://reference.aspose.com/slides/php-java/aspose.slides/LineStyle) für die Linien der Form.
7. Setzen Sie den [Strichstil](https://reference.aspose.com/slides/php-java/aspose.slides/LineDashStyle) für die Linien der Form.
8. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser PHP-Code demonstriert eine Operation, bei der wir ein Rechteck `AutoShape` formatiert haben:

```php
  # Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
  $pres = new Presentation();
  try {
    # Holt die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Fügt eine Autoshape vom Rechtecktyp hinzu
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);
    # Setzt die Füllfarbe für die rechteckige Form
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    # Wendet einige Formatierungen auf die Linien des Rechtecks an
    $shp->getLineFormat()->setStyle(LineStyle->ThickThin);
    $shp->getLineFormat()->setWidth(7);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->Dash);
    # Setzt die Farbe für die Linie des Rechtecks
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Schreibt die PPTX-Datei auf die Festplatte
    $pres->save("RectShpLn_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Verbindungstile formatieren**
Dies sind die 3 Optionen für Verbindungstypen:

* Rund
* Gehrung
* Fase

Standardmäßig verwendet PowerPoint die Einstellung **Rund**, wenn zwei Linien in einem Winkel (oder an einer Ecke der Form) verbunden werden. Wenn Sie jedoch eine Form mit sehr scharfen Winkeln zeichnen möchten, sollten Sie **Gehrung** wählen.

![join-style-powerpoint](join-style-powerpoint.png)

Dieser Java-Code demonstriert eine Operation, bei der 3 Rechtecke (das Bild oben) mit den Verbindungstileinstellungen Gehrung, Fase und Rund erstellt wurden:

```php
  # Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
  $pres = new Presentation();
  try {
    # Holt die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Fügt 3 Rechteck-Autoshapes hinzu
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 100, 150, 75);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 150, 75);
    $shp3 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 250, 150, 75);
    # Setzt die Füllfarbe für die rechteckige Form
    $shp1->getFillFormat()->setFillType(FillType::Solid);
    $shp1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp3->getFillFormat()->setFillType(FillType::Solid);
    $shp3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Setzt die Breite der Linie
    $shp1->getLineFormat()->setWidth(15);
    $shp2->getLineFormat()->setWidth(15);
    $shp3->getLineFormat()->setWidth(15);
    # Setzt die Farbe für die Linie des Rechtecks
    $shp1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shp2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shp3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Setzt den Verbindung Stil
    $shp1->getLineFormat()->setJoinStyle(LineJoinStyle->Miter);
    $shp2->getLineFormat()->setJoinStyle(LineJoinStyle->Bevel);
    $shp3->getLineFormat()->setJoinStyle(LineJoinStyle->Round);
    # Fügt jedem Rechteck Text hinzu
    $shp1->getTextFrame()->setText("Gehrung Verbindung Stil");
    $shp2->getTextFrame()->setText("Fase Verbindung Stil");
    $shp3->getTextFrame()->setText("Rund Verbindung Stil");
    # Schreibt die PPTX-Datei auf die Festplatte
    $pres->save("RectShpLnJoin_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Verlaufshintergrund**
In PowerPoint ist der Verlaufshintergrund eine Formatierungsoption, die es Ihnen ermöglicht, einen kontinuierlichen Farbverlauf auf eine Form anzuwenden. Zum Beispiel können Sie zwei oder mehr Farben in einer Anordnung anwenden, in der eine Farbe allmählich in eine andere Farbe übergeht.

So verwenden Sie Aspose.Slides, um einen Verlaufshintergrund auf eine Form anzuwenden:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie der Folie eine [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) hinzu.
4. Setzen Sie den [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) der Form auf `Gradient`.
5. Fügen Sie Ihre 2 bevorzugten Farben mit definierten Positionen mithilfe der `Add`-Methoden hinzu, die von der `GradientStops`-Sammlung bereitgestellt werden, die mit der `GradientFormat`-Klasse verbunden ist.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser PHP-Code demonstriert eine Operation, bei der der Verlaufseffekt auf einer Ellipse verwendet wurde:

```php
  # Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
  $pres = new Presentation();
  try {
    # Holt die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Fügt eine Ellipsen-Autoshape hinzu
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 75, 150);
    # Wendet die Verlaufformatierung auf die Ellipse an
    $shp->getFillFormat()->setFillType(FillType::Gradient);
    $shp->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape->Linear);
    # Setzt die Richtung des Verlaufs
    $shp->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);
    # Fügt 2 Verlaufshaltepunkte hinzu
    $shp->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor->Purple);
    $shp->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor->Red);
    # Schreibt die PPTX-Datei auf die Festplatte
    $pres->save("EllipseShpGrad_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Musterfüllung**
In PowerPoint ist die Musterfüllung eine Formatierungsoption, die es Ihnen ermöglicht, ein zweifarbiges Design bestehend aus Punkten, Streifen, Kreuzschraffuren oder Kästchen auf eine Form anzuwenden. Darüber hinaus können Sie Ihre bevorzugten Farben für den Vordergrund und den Hintergrund Ihres Musters auswählen.

Aspose.Slides bietet über 45 vordefinierte Stile, die verwendet werden können, um Formen zu formatieren und Präsentationen zu bereichern. Selbst nachdem Sie ein vordefiniertes Muster gewählt haben, können Sie weiterhin die Farben angeben, die das Muster enthalten soll.

So verwenden Sie Aspose.Slides, um eine Musterfüllung auf eine Form anzuwenden:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie der Folie eine [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) hinzu.
4. Setzen Sie den [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) der Form auf `Pattern`.
5. Setzen Sie Ihren bevorzugten Musterstil für die Form.
6. Setzen Sie die [Hintergrundfarbe](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat#getBackColor--) für die [PatternFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat).
7. Setzen Sie die [Vordergrundfarbe](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat#getForeColor--) für die [PatternFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat).
8. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser PHP-Code demonstriert eine Operation, bei der eine Musterfüllung verwendet wurde, um ein Rechteck zu verschönern:

```php
  # Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
  $pres = new Presentation();
  try {
    # Holt die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Fügt eine rechteckige Autoshape hinzu
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # Setzt den Fülltyp auf Muster
    $shp->getFillFormat()->setFillType(FillType::Pattern);
    # Setzt den Musterstil
    $shp->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->Trellis);
    # Setzt die Hintergrund- und Vordergrundfarben des Musters
    $shp->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shp->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);
    # Schreibt die PPTX-Datei auf die Festplatte
    $pres->save("RectShpPatt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bildfüllung**
In PowerPoint ist die Bildfüllung eine Formatierungsoption, die es Ihnen ermöglicht, ein Bild in einer Form zu platzieren. Im Wesentlichen können Sie ein Bild als Hintergrund einer Form verwenden.

So verwenden Sie Aspose.Slides, um eine Form mit einem Bild zu füllen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Erhalten Sie die Referenz einer Folie über ihren Index.
3. Fügen Sie der Folie eine [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) hinzu.
4. Setzen Sie den [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) der Form auf `Picture`.
5. Setzen Sie den Bildfüllmodus auf Kachel.
6. Erstellen Sie ein `IPPImage`-Objekt mit dem Bild, das verwendet werden soll, um die Form zu füllen.
7. Setzen Sie die `Picture.Image`-Eigenschaft des `PictureFillFormat`-Objekts auf das neu erstellte `IPPImage`.
8. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser PHP-Code zeigt Ihnen, wie Sie eine Form mit einem Bild füllen:

```php
  # Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
  $pres = new Presentation();
  try {
    # Holt die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Fügt eine rechteckige Autoshape hinzu
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # Setzt den Fülltyp auf Bild
    $shp->getFillFormat()->setFillType(FillType::Picture);
    # Setzt den Bildfüllmodus
    $shp->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Tile);
    # Setzt das Bild
    $picture;
    $image = Images->fromFile("Tulips.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $shp->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Schreibt die PPTX-Datei auf die Festplatte
    $pres->save("RectShpPic_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Einfarbige Füllung**
In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die es Ihnen ermöglicht, eine Form mit einer einzigen Farbe zu füllen. Die gewählte Farbe ist in der Regel eine einfache Farbe. Die Farbe wird auf den Hintergrund der Form mit allen besonderen Effekten oder Änderungen angewendet.

So verwenden Sie Aspose.Slides, um eine einfarbige Füllung auf eine Form anzuwenden:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie der Folie eine [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) hinzu.
4. Setzen Sie den [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) der Form auf `Solid`.
5. Setzen Sie Ihre bevorzugte Farbe für die Form.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser PHP-Code zeigt Ihnen, wie Sie die einfarbige Füllung auf eine Box in PowerPoint anwenden:

```php
  # Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
  $pres = new Presentation();
  try {
    # Holt die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Fügt eine rechteckige Autoshape hinzu
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # Setzt den Fülltyp auf Einfarbig
    $shape->getFillFormat()->setFillType(FillType::Solid);
    # Setzt die Farbe für das Rechteck
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # Schreibt die PPTX-Datei auf die Festplatte
    $pres->save("RectShpSolid_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Transparenz festlegen**

In PowerPoint können Sie beim Füllen von Formen mit einfarbigen Farben, Verläufen, Bildern oder Texturen den Transparenzgrad angeben, der die Opazität einer Füllung bestimmt. Auf diese Weise zeigt beispielsweise der Hintergrund oder das Folienobjekt hinter (der Form) durch, wenn Sie einen niedrigen Transparenzgrad festlegen.

Aspose.Slides ermöglicht es Ihnen, den Transparenzgrad für eine Form auf folgende Weise festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie der Folie eine [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) hinzu.
4. Verwenden Sie `new Color`, wobei die Alpha-Komponente festgelegt wird.
5. Speichern Sie das Objekt als PowerPoint-Datei.

Dieser PHP-Code demonstriert den Prozess:

```php
  # Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Fügt eine feste Form hinzu
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 75, 175, 75, 150);
    # Fügt eine transparente Form über der festen Form hinzu
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 204, 102, 0, 128));
    # Schreibt die PPTX-Datei auf die Festplatte
    $pres->save("ShapeTransparentOverSolid_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Formen drehen**
Aspose.Slides ermöglicht es Ihnen, eine hinzugefügte Form auf einer Folie auf folgende Weise zu drehen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie der Folie eine [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) hinzu.
4. Drehen Sie die Form um die benötigten Grad.
5. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser PHP-Code zeigt Ihnen, wie Sie eine Form um 90 Grad drehen:

```php
  # Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
  $pres = new Presentation();
  try {
    # Holt die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Fügt eine rechteckige Autoshape hinzu
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # Dreht die Form um 90 Grad
    $shp->setRotation(90);
    # Schreibt die PPTX-Datei auf die Festplatte
    $pres->save("RectShpRot_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **3D-Prägeffekte hinzufügen**
Aspose.Slides ermöglicht es Ihnen, 3D-Prägeffekte zu einer Form hinzuzufügen, indem Sie die Eigenschaften der [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) entsprechend ändern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie der Folie eine [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) hinzu.
3. Legen Sie Ihre bevorzugten Parameter für die [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) Eigenschaften der Form fest.
4. Schreiben Sie die Präsentation auf die Festplatte.

Dieser PHP-Code zeigt Ihnen, wie Sie 3D-Prägeffekte zu einer Form hinzufügen:

```php
  # Erstellt eine Instanz der Präsentationsklasse
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Fügt eine Form zur Folie hinzu
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 30, 30, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $format = $shape->getLineFormat()->getFillFormat();
    $format->setFillType(FillType::Solid);
    $format->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);
    # Setzt die Eigenschaften der ThreeDFormat der Form
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    # Schreibt die Präsentation als PPTX-Datei
    $pres->save("Bavel_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **3D-Rotationseffekt hinzufügen**
Aspose.Slides ermöglicht es Ihnen, 3D-Rotationseffekte einer Form hinzuzufügen, indem Sie deren [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) Eigenschaften auf folgende Weise ändern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie der Folie eine [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) hinzu.
3. Geben Sie Ihre bevorzugten Figuren für [CameraType](https://reference.aspose.com/slides/php-java/aspose.slides/ICamera#getCameraType--) und [LightType](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRig#getLightType--) an.
4. Schreiben Sie die Präsentation auf die Festplatte.

Dieser PHP-Code zeigt Ihnen, wie Sie 3D-Rotationseffekte zu einer Form anwenden:

```php
  # Erstellt eine Instanz der Präsentationsklasse
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 200, 200);
    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Line, 30, 300, 200, 200);
    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(0, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    # Schreibt die Präsentation als PPTX-Datei
    $pres->save("Rotation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Formatierung zurücksetzen**

Dieser PHP-Code zeigt Ihnen, wie Sie die Formatierung in einer Folie zurücksetzen und die Position, Größe und Formatierung jeder Form, die einen Platzhalter auf [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutSlide) hat, auf ihre Standardwerte zurücksetzen:

```php
  $pres = new Presentation();
  try {
    foreach($pres->getSlides() as $slide) {
      # Jede Form auf der Folie, die einen Platzhalter im Layout hat, wird zurückgesetzt
      $slide->reset();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```