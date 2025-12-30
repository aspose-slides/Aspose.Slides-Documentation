---
title: Verwalten von Präsentationsformen in PHP
linktitle: Formmanipulation
type: docs
weight: 40
url: /de/php-java/shape-manipulations/
keywords:
- PowerPoint-Form
- Präsentationsform
- Form auf Folie
- Form finden
- Form duplizieren
- Form entfernen
- Form ausblenden
- Formreihenfolge ändern
- Interop-Form-ID abrufen
- Alternativtext der Form
- Form-Layoutformate
- Form als SVG
- Form nach SVG
- Form ausrichten
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen in Aspose.Slides für PHP via Java erstellen, bearbeiten und optimieren und leistungsstarke PowerPoint-Präsentationen bereitstellen."
---

## **Eine Form auf einer Folie finden**
Dieses Thema beschreibt eine einfache Technik, die es Entwicklern erleichtert, eine bestimmte Form auf einer Folie zu finden, ohne deren interne Id zu verwenden. Es ist wichtig zu wissen, dass PowerPoint‑Präsentationsdateien keine Möglichkeit haben, Formen auf einer Folie zu identifizieren, außer über eine interne eindeutige Id. Es scheint für Entwickler schwierig zu sein, eine Form anhand ihrer internen eindeutigen Id zu finden. Alle Formen, die zu den Folien hinzugefügt werden, besitzen einen Alt‑Text. Wir empfehlen Entwicklern, den Alternativtext zu verwenden, um eine bestimmte Form zu finden. Sie können MS PowerPoint verwenden, um den Alternativtext für Objekte festzulegen, die Sie in Zukunft ändern möchten.

Nachdem Sie den Alternativtext einer gewünschten Form festgelegt haben, können Sie die Präsentation mit Aspose.Slides für PHP via Java öffnen und durch alle Formen einer Folie iterieren. Bei jeder Iteration können Sie den Alternativtext der Form prüfen, und die Form mit dem passenden Alternativtext ist die gesuchte Form. Um diese Technik besser zu demonstrieren, haben wir eine Methode erstellt, [findShape](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-), die das Auffinden einer bestimmten Form auf einer Folie übernimmt und dann einfach diese Form zurückgibt.
```php
  # Instanziiere eine Presentation-Klasse, die die Präsentationsdatei darstellt
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Alternativtext der zu findenden Form
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Shape Name: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```


## **Form duplizieren**
Um eine Form auf einer Folie mit Aspose.Slides für PHP via Java zu klonen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Holen Sie die Referenz einer Folie anhand ihres Index.
1. Greifen Sie auf die Formensammlung der Quellfolie zu.
1. Fügen Sie der Präsentation eine neue Folie hinzu.
1. Klonen Sie Formen aus der Formensammlung der Quellfolie in die neue Folie.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Das folgende Beispiel fügt einer Folie eine Gruppierung von Formen hinzu.
```php
  # Instanziiere die Presentation-Klasse
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # Schreibe die PPTX-Datei auf die Festplatte
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Eine Form entfernen**
Aspose.Slides für PHP via Java ermöglicht es Entwicklern, jede Form zu entfernen. Um eine Form von einer Folie zu entfernen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Greifen Sie auf die erste Folie zu.
1. Suchen Sie die Form mit einem bestimmten AlternativeText.
1. Entfernen Sie die Form.
1. Speichern Sie die Datei auf dem Laufwerk.
```php
  # Präsentationsobjekt erstellen
  $pres = new Presentation();
  try {
    # Erste Folie abrufen
    $sld = $pres->getSlides()->get_Item(0);
    # Autoshape des Typs Rechteck hinzufügen
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # Präsentation auf die Festplatte speichern
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Eine Form ausblenden**
Aspose.Slides für PHP via Java ermöglicht es Entwicklern, jede Form auszublenden. Um eine Form von einer Folie auszublenden, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Greifen Sie auf die erste Folie zu.
1. Suchen Sie die Form mit einem bestimmten AlternativeText.
1. Blenden Sie die Form aus.
1. Speichern Sie die Datei auf dem Laufwerk.
```php
  # Instanziiere Presentation-Klasse, die das PPTX darstellt
  $pres = new Presentation();
  try {
    # Erste Folie abrufen
    $sld = $pres->getSlides()->get_Item(0);
    # Autoshape vom Typ Rechteck hinzufügen
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # Präsentation auf die Festplatte speichern
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Reihenfolge von Formen ändern**
Aspose.Slides für PHP via Java ermöglicht es Entwicklern, Formen neu anzuordnen. Das Neuanordnen legt fest, welche Form im Vordergrund und welche im Hintergrund liegt. Um die Reihenfolge von Formen auf einer Folie zu ändern, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie eine Form hinzu.
1. Fügen Sie etwas Text in den Textrahmen der Form ein.
1. Fügen Sie eine weitere Form mit denselben Koordinaten hinzu.
1. Ordnen Sie die Formen neu.
1. Speichern Sie die Datei auf dem Laufwerk.
```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Watermark Text Watermark Text Watermark Text");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Interop‑Shape‑ID abrufen**
Aspose.Slides für PHP via Java ermöglicht es Entwicklern, einen eindeutigen Shape‑Bezeichner im Folien‑Kontext zu erhalten, im Gegensatz zur Methode [getUniqueId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getUniqueId--) die einen eindeutigen Bezeichner im Präsentations‑Kontext liefert. Die Methode [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getOfficeInteropShapeId--) wurde den Schnittstellen [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) und der Klasse [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/Shape) hinzugefügt. Der von [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getOfficeInteropShapeId--) zurückgegebene Wert entspricht dem Id‑Wert des Microsoft.Office.Interop.PowerPoint.Shape‑Objekts. Unten ist ein Beispielcode angegeben.
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Abrufen der eindeutigen Shape-Kennung im Folienbereich
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Alternativen Text für eine Form festlegen**
Aspose.Slides für PHP via Java ermöglicht es Entwicklern, AlternateText (Alternativtext) einer beliebigen Form festzulegen.
Formen in einer Präsentation können über die Methoden [AlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setAlternativeText-java.lang.String-) oder [Shape Name](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setName-java.lang.String-) unterschieden werden.
Die Methoden [setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setAlternativeText-java.lang.String-) und [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getAlternativeText--) können sowohl mit Aspose.Slides als auch mit Microsoft PowerPoint gelesen oder gesetzt werden.
Durch die Verwendung dieser Methode können Sie eine Form kennzeichnen und verschiedene Vorgänge durchführen, wie das Entfernen einer Form, das Ausblenden einer Form oder das Neuordnen von Formen auf einer Folie.
Um den AlternateText einer Form festzulegen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie der Folie eine beliebige Form hinzu.
1. Führen Sie einige Arbeiten mit der neu hinzugefügten Form aus.
1. Durchlaufen Sie die Formen, um eine Form zu finden.
1. Setzen Sie den AlternativeText.
1. Speichern Sie die Datei auf dem Laufwerk.
```php
  # Instanziiere die Presentation-Klasse, die das PPTX repräsentiert
  $pres = new Presentation();
  try {
    # Erste Folie abrufen
    $sld = $pres->getSlides()->get_Item(0);
    # Autoshape des Typs Rechteck hinzufügen
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("User Defined");
      }
    }
    # Präsentation auf die Festplatte speichern
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Layout‑Formate für eine Form zugreifen**
Aspose.Slides für PHP via Java bietet eine einfache API, um auf Layout‑Formate einer Form zuzugreifen. Dieser Artikel zeigt, wie Sie auf Layout‑Formate zugreifen können.

Unten ist ein Beispielcode angegeben.
```php
  $pres = new Presentation("pres.pptx");
  try {
    foreach($pres->getLayoutSlides() as $layoutSlide) {
      foreach($layoutSlide->getShapes() as $shape) {
        $fillFormats = $shape->getFillFormat();
        $lineFormats = $shape->getLineFormat();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Eine Form als SVG rendern**
Jetzt unterstützt Aspose.Slides für PHP via Java das Rendern einer Form als SVG. Die Methode [writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (und ihre Überladung) wurde der Klasse [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/Shape) und der Schnittstelle [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) hinzugefügt. Diese Methode ermöglicht das Speichern des Inhalts einer Form als SVG‑Datei. Das nachfolgende Code‑Snippet zeigt, wie man die Form einer Folie in eine SVG‑Datei exportiert.
```php
  $pres = new Presentation("TestExportShapeToSvg.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "SingleShape.svg");
    try {
      $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->writeAsSvg($stream);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Eine Form ausrichten**
Aspose.Slides ermöglicht das Ausrichten von Formen entweder relativ zu den Folienrändern oder relativ zueinander. Zu diesem Zweck wurde die überladene Methode [SlidesUtil.alignShape()](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) hinzugefügt. Die Aufzählung [ShapesAlignmentType](https://reference.aspose.com/slides/php-java/aspose.slides/ShapesAlignmentType) definiert mögliche Ausrichtungsoptionen.

**Beispiel 1**

Der untenstehende Quellcode richtet die Formen mit den Indizes 1, 2 und 4 am oberen Rand der Folie aus.
```php
  $pres = new Presentation("example.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape1 = $slide->getShapes()->get_Item(1);
    $shape2 = $slide->getShapes()->get_Item(2);
    $shape3 = $slide->getShapes()->get_Item(4);
    SlideUtil->alignShapes(ShapesAlignmentType::AlignTop, true, $pres->getSlides()->get_Item(0), array($slide->getShapes()->indexOf($shape1), $slide->getShapes()->indexOf($shape2), $slide->getShapes()->indexOf($shape3) ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


**Beispiel 2**

Das nachfolgende Beispiel zeigt, wie man die gesamte Sammlung von Formen relativ zur untersten Form in der Sammlung ausrichtet.
```php
  $pres = new Presentation("example.pptx");
  try {
    SlideUtil->alignShapes(ShapesAlignmentType::AlignBottom, false, $pres->getSlides()->get_Item(0));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Spiegelungseigenschaften**
In Aspose.Slides bietet die Klasse [ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) Kontrolle über die horizontale und vertikale Spiegelung von Formen über die Eigenschaften `flipH` und `flipV`. Beide Eigenschaften sind vom Typ [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/), wobei `True` eine Spiegelung, `False` keine Spiegelung und `NotDefined` das Standardverhalten bedeutet. Diese Werte sind über den [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) einer Form zugänglich.

Um die Spiegelungseinstellungen zu ändern, wird eine neue Instanz von [ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) mit der aktuellen Position und Größe der Form, den gewünschten Werten für `flipH` und `flipV` sowie dem Rotationswinkel erstellt. Durch Zuweisung dieser Instanz zum [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) der Form und dem Speichern der Präsentation werden die Spiegelungstransformationen angewendet und in die Ausgabedatei geschrieben.

Angenommen, wir haben eine Datei sample.pptx, in der die erste Folie eine einzelne Form mit den Standard‑Spiegelungseinstellungen enthält, wie unten gezeigt.

![The shape to be flipped](shape_to_be_flipped.png)

Das folgende Code‑Beispiel ruft die aktuellen Spiegelungseigenschaften der Form ab und spiegelt sie sowohl horizontal als auch vertikal.
```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // Die horizontale Spiegelungs‑Eigenschaft der Form abrufen.
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // Die vertikale Spiegelungs‑Eigenschaft der Form abrufen.
    $verticalFlip = $shape->getFrame()->getFlipV();
    echo "Vertical flip: ", $verticalFlip, "\n";

    $x = $shape->getFrame()->getX();
    $y = $shape->getFrame()->getY();
    $width = $shape->getFrame()->getWidth();
    $height = $shape->getFrame()->getHeight();
    $flipH = NullableBool::True; // Horizontal spiegeln.
    $flipV = NullableBool::True; // Horizontal spiegeln.
    $rotation = $shape->getFrame()->getRotation();

    $shape->setFrame(new ShapeFrame($x, $y, $width, $height, $flipH, $flipV, $rotation));

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


![Die gespiegelte Form](flipped_shape.png)

## **FAQ**

**Kann ich Formen (Vereinigung/Schnitt/Unterschied) auf einer Folie wie in einem Desktop‑Editor kombinieren?**

Es gibt keine integrierte API für boolesche Operationen. Sie können dies annähern, indem Sie die gewünschte Kontur selbst erstellen – z. B. die resultierende Geometrie (über [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)) berechnen und eine neue Form mit dieser Kontur erzeugen, optional die Originalformen entfernen.

**Wie kann ich die Stapelreihenfolge (Z‑Order) steuern, sodass eine Form immer „oben“ bleibt?**

Ändern Sie die Einfüge‑/Verschiebe‑Reihenfolge innerhalb der [shapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes)‑Sammlung der Folie. Für vorhersehbare Ergebnisse finalisieren Sie die Z‑Reihenfolge nach allen anderen Folienänderungen.

**Kann ich eine Form „sperren“, um zu verhindern, dass Benutzer sie in PowerPoint bearbeiten?**

Ja. Setzen Sie [shape-level protection flags](/slides/de/php-java/applying-protection-to-presentation/) (z. B. Auswahl, Bewegung, Größenänderung, Textbearbeitung sperren). Bei Bedarf spiegeln Sie die Einschränkungen im Master oder Layout. Beachten Sie, dass dies ein UI‑Schutz ist und keine Sicherheitsfunktion; für stärkeren Schutz kombinieren Sie ihn mit dateibezogenen Einschränkungen wie [Empfehlungen für schreibgeschützte Dateien oder Passwörter](/slides/de/php-java/password-protected-presentation/).