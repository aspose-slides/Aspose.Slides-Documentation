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
- Form zu SVG
- Form ausrichten
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erlernen Sie das Erstellen, Bearbeiten und Optimieren von Formen in Aspose.Slides für PHP via Java und liefern Sie leistungsstarke PowerPoint-Präsentationen."
---

## **Eine Form auf einer Folie finden**
Dieses Thema beschreibt eine einfache Technik, die es Entwicklern erleichtert, eine bestimmte Form auf einer Folie zu finden, ohne ihre interne Id zu verwenden. Es ist wichtig zu wissen, dass PowerPoint‑Präsentationsdateien keine Möglichkeit haben, Formen auf einer Folie zu identifizieren, außer über eine interne eindeutige Id. Es scheint für Entwickler schwierig zu sein, eine Form anhand ihrer internen eindeutigen Id zu finden. Allen Formen, die den Folien hinzugefügt werden, ist ein Alternativtext zugeordnet. Wir empfehlen Entwicklern, den Alternativtext zu verwenden, um eine bestimmte Form zu finden. Sie können MS PowerPoint verwenden, um den Alternativtext für Objekte zu definieren, die Sie in Zukunft ändern möchten.

Nachdem Sie den Alternativtext einer gewünschten Form festgelegt haben, können Sie diese Präsentation mit Aspose.Slides for PHP via Java öffnen und alle Formen auf einer Folie durchlaufen. Während jeder Iteration können Sie den Alternativtext der Form prüfen und die Form mit dem passenden Alternativtext wäre die von Ihnen gesuchte Form. Um diese Technik anschaulicher zu demonstrieren, haben wir eine Methode, [findShape](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) erstellt, die das Finden einer bestimmten Form in einer Folie übernimmt und anschließend einfach diese Form zurückgibt.
```php
  # Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei repräsentiert
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


## **Eine Form duplizieren**
Um eine Form auf einer Folie mit Aspose.Slides for PHP via Java zu duplizieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)‑Klasse.
1. Rufen Sie die Referenz einer Folie über deren Index ab.
1. Greifen Sie auf die Form‑Sammlung der Quellfolie zu.
1. Fügen Sie der Präsentation eine neue Folie hinzu.
1. Duplizieren Sie Formen aus der Form‑Sammlung der Quellfolie in die neue Folie.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Das folgende Beispiel fügt einer Folie eine Gruppierung von Formen hinzu.
```php
  # Instanziiere Presentation-Klasse
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
Aspose.Slides for PHP via Java ermöglicht Entwicklern das Entfernen beliebiger Formen. Um eine Form von einer Folie zu entfernen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)‑Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Suchen Sie die Form mit dem gewünschten AlternativeText.
1. Entfernen Sie die Form.
1. Speichern Sie die Datei auf dem Datenträger.
```php
  # Presentation-Objekt erstellen
  $pres = new Presentation();
  try {
    # Erste Folie abrufen
    $sld = $pres->getSlides()->get_Item(0);
    # Autoform vom Typ Rechteck hinzufügen
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
    # Präsentation auf Festplatte speichern
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Eine Form ausblenden**
Aspose.Slides for PHP via Java ermöglicht Entwicklern das Ausblenden beliebiger Formen. Um eine Form von einer Folie auszublenden, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)‑Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Suchen Sie die Form mit dem gewünschten AlternativeText.
1. Blenden Sie die Form aus.
1. Speichern Sie die Datei auf dem Datenträger.
```php
  # Instanziiere Presentation-Klasse, die die PPTX repräsentiert
  $pres = new Presentation();
  try {
    # Erste Folie abrufen
    $sld = $pres->getSlides()->get_Item(0);
    # Autoform vom Typ Rechteck hinzufügen
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
    # Präsentation auf Festplatte speichern
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Reihenfolge einer Form ändern**
Aspose.Slides for PHP via Java ermöglicht Entwicklern das Neuordnen von Formen. Das Neuordnen legt fest, welche Form im Vordergrund bzw. im Hintergrund liegt. Um die Reihenfolge einer Form auf einer Folie zu ändern, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)‑Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie eine Form hinzu.
1. Fügen Sie Text in den Textbereich der Form ein.
1. Fügen Sie eine weitere Form mit denselben Koordinaten hinzu.
1. Ordnen Sie die Formen neu an.
1. Speichern Sie die Datei auf dem Datenträger.
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


## **Die Interop‑Form‑ID abrufen**
Aspose.Slides for PHP via Java ermöglicht Entwicklern das Abrufen einer eindeutigen Form‑Kennung im Folien‑Umfang im Gegensatz zur [getUniqueId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getuniqueid/)‑Methode, die eine eindeutige Kennung im Präsentations‑Umfang liefert. Die Methode [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getofficeinteropshapeid/) wurde zur Klasse [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) hinzugefügt. Der von [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getofficeinteropshapeid/) zurückgegebene Wert entspricht dem Id‑Wert des Microsoft.Office.Interop.PowerPoint.Shape‑Objekts. Unten ist ein Beispielcode angegeben.
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Eindeutigen Formbezeichner im Folienbereich abrufen
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Alternativen Text für eine Form festlegen**
Aspose.Slides for PHP via Java ermöglicht Entwicklern das Festlegen von AlternateText für jede Form. Formen in einer Präsentation können durch den `Alternative Text` oder die [Shape Name](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/)‑Methode unterschieden werden. Mit den Methoden [setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) und [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) können Sie über Aspose.Slides bzw. Microsoft PowerPoint lesen oder schreiben. Mit dieser Methode können Sie eine Form kennzeichnen und verschiedene Vorgänge wie Entfernen, Ausblenden oder Neuordnen von Formen auf einer Folie ausführen. Um das AlternateText einer Form festzulegen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)‑Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie der Folie eine beliebige Form hinzu.
1. Arbeiten Sie mit der neu hinzugefügten Form.
1. Durchsuchen Sie die Formen, um die gewünschte Form zu finden.
1. Setzen Sie den AlternativeText.
1. Speichern Sie die Datei auf dem Datenträger.
```php
  # Instanz der Presentation-Klasse, die die PPTX darstellt
  $pres = new Presentation();
  try {
    # Erste Folie abrufen
    $sld = $pres->getSlides()->get_Item(0);
    # Autoform vom Typ Rechteck hinzufügen
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
    # Präsentation auf Festplatte speichern
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Layoutformate für eine Form abrufen**
Aspose.Slides for PHP via Java stellt eine einfache API zum Abrufen von Layoutformaten für eine Form bereit. Dieser Artikel zeigt, wie Sie Layoutformate zugreifen können.

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
Jetzt unterstützt Aspose.Slides for PHP via Java das Rendern einer Form als SVG. Die Methode [writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) (und ihre Überladung) wurde der Klasse [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) hinzugefügt. Diese Methode ermöglicht das Speichern des Inhalts der Form als SVG‑Datei. Das nachfolgende Code‑Snippet zeigt, wie die Form einer Folie in eine SVG‑Datei exportiert wird.
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
Aspose.Slides ermöglicht das Ausrichten von Formen entweder relativ zu den Folienrändern oder relativ zueinander. Zu diesem Zweck wurde die überladene Methode [SlidesUtil::alignShapes](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/alignshapes/) hinzugefügt. Die Aufzählung [ShapesAlignmentType](https://reference.aspose.com/slides/php-java/aspose.slides/shapesalignmenttype/) definiert mögliche Ausrichtungsoptionen.

**Beispiel 1**

Der nachstehende Quellcode richtet die Formen mit den Indizes 1, 2 und 4 am oberen Rand der Folie aus.
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

Das folgende Beispiel zeigt, wie die gesamte Form‑Sammlung relativ zur untersten Form der Sammlung ausgerichtet wird.
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


## **Spiegeleigenschaften**

In Aspose.Slides stellt die Klasse [ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) die Kontrolle über horizontales und vertikales Spiegeln von Formen über die Eigenschaften `flipH` und `flipV` bereit. Beide Eigenschaften sind vom Typ [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) und können den Wert `True` für ein Spiegeln, `False` für kein Spiegeln oder `NotDefined` für das Standardverhalten annehmen. Diese Werte sind über den [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) einer Form zugänglich.

Um die Spiegeleinstellungen zu ändern, wird eine neue [ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/)‑Instanz mit der aktuellen Position und Größe der Form sowie den gewünschten Werten für `flipH` und `flipV` und dem Rotationswinkel erstellt. Durch Zuweisen dieser Instanz zum [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) der Form und Speichern der Präsentation werden die Spiegeltransformationen angewendet und in die Ausgabedatei übernommen.

Angenommen, wir haben eine Datei sample.pptx, in der die erste Folie eine einzelne Form mit den Standard‑Spiegeleinstellungen enthält, wie unten abgebildet.

![Die zu spiegelnde Form](shape_to_be_flipped.png)

Der folgende Code liest die aktuellen Spiegeleigenschaften der Form aus und spiegelt sie sowohl horizontal als auch vertikal.
```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // Den horizontalen Spiegelungswert der Form abrufen.
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // Den vertikalen Spiegelungswert der Form abrufen.
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


Das Ergebnis:

![Die gespiegelte Form](flipped_shape.png)

## **FAQ**

**Kann ich Formen (Vereinigung/ Schnittmenge/ Subtraktion) auf einer Folie wie in einem Desktop‑Editor kombinieren?**

Es gibt keine integrierte Boolean‑Operation‑API. Sie können dies annähern, indem Sie die gewünschte Kontur selbst erstellen – z. B. die resultierende Geometrie (via [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)) berechnen und eine neue Form mit dieser Kontur erzeugen, optional die Originale entfernen.

**Wie kann ich die Stapelreihenfolge (Z‑Order) steuern, sodass eine Form immer „oben“ bleibt?**

Ändern Sie die Einfüge‑/Verschiebe‑Reihenfolge innerhalb der [shapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes)‑Sammlung der Folie. Für vorhersehbare Ergebnisse finalisieren Sie die Z‑Order nach allen anderen Folienänderungen.

**Kann ich eine Form „sperren“, damit Benutzer sie in PowerPoint nicht bearbeiten können?**

Ja. Setzen Sie schützende Flags auf Form‑Ebene (z. B. Auswahl, Bewegung, Größenänderung, Textbearbeitung). Bei Bedarf spiegeln Sie Einschränkungen im Master oder Layout wider. Dies ist ein UI‑Schutz, kein Sicherheitsmerkmal; für stärkeren Schutz kombinieren Sie ihn mit Dateischutz‑Optionen wie Lese‑Only‑Empfehlungen oder Passwörtern [/slides/php-java/password-protected-presentation/].
