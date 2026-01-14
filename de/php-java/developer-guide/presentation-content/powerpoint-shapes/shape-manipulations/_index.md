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
- Form-Alternativtext
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
Dieses Thema beschreibt eine einfache Technik, um es Entwicklern zu erleichtern, eine bestimmte Form auf einer Folie zu finden, ohne deren interne Id zu verwenden. Es ist wichtig zu wissen, dass PowerPoint‑Präsentationsdateien keine Möglichkeit haben, Formen auf einer Folie zu identifizieren, außer über eine interne eindeutige Id. Für Entwickler ist es schwierig, eine Form über ihre interne eindeutige Id zu finden. Allen Formen, die zu den Folien hinzugefügt werden, ist ein Alternativtext zugeordnet. Wir empfehlen Entwicklern, den Alternativtext zum Finden einer bestimmten Form zu verwenden. Sie können MS PowerPoint nutzen, um den Alternativtext für Objekte festzulegen, die Sie in Zukunft ändern möchten.

Nachdem Sie den Alternativtext einer gewünschten Form festgelegt haben, können Sie die Präsentation mit Aspose.Slides for PHP via Java öffnen und alle zu einer Folie hinzugefügten Formen durchlaufen. Bei jeder Iteration können Sie den Alternativtext der Form prüfen, und die Form mit dem passenden Alternativtext ist die gesuchte Form. Um diese Technik anschaulicher zu demonstrieren, haben wir die Methode [findShape](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) erstellt, die das Finden einer bestimmten Form in einer Folie übernimmt und dann einfach diese Form zurückgibt.
```php
  # Instanziieren Sie eine Presentation‑Klasse, die die Präsentationsdatei repräsentiert
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
Um eine Form auf eine Folie zu duplizieren mithilfe von Aspose.Slides for PHP via Java:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Holen Sie die Referenz einer Folie über deren Index.
1. Greifen Sie auf die Formsammlung der Quellfolie zu.
1. Fügen Sie der Präsentation eine neue Folie hinzu.
1. Duplizieren Sie Formen aus der Formsammlung der Quellfolie in die neue Folie.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Das nachstehende Beispiel fügt einer Folie eine Gruppenform hinzu.
```php
  # Instanziieren Sie die Presentation-Klasse
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # Schreiben Sie die PPTX-Datei auf die Festplatte
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Eine Form entfernen**
Aspose.Slides for PHP via Java ermöglicht Entwicklern das Entfernen beliebiger Formen. So entfernen Sie eine Form von einer Folie:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Greifen Sie auf die erste Folie zu.
1. Suchen Sie die Form mit dem gewünschten AlternativeText.
1. Entfernen Sie die Form.
1. Speichern Sie die Datei auf dem Datenträger.
```php
  # Präsentationsobjekt erstellen
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
Aspose.Slides for PHP via Java ermöglicht Entwicklern das Ausblenden beliebiger Formen. So blenden Sie eine Form auf einer Folie aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Greifen Sie auf die erste Folie zu.
1. Suchen Sie die Form mit dem gewünschten AlternativeText.
1. Blenden Sie die Form aus.
1. Speichern Sie die Datei auf dem Datenträger.
```php
  # Instanziieren Sie die Presentation‑Klasse, die die PPTX darstellt
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


## **Formreihenfolge ändern**
Aspose.Slides for PHP via Java ermöglicht Entwicklern das Neuanordnen von Formen. Durch das Neuanordnen wird festgelegt, welche Form im Vordergrund und welche im Hintergrund liegt. So ändern Sie die Reihenfolge von Formen auf einer Folie:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie eine Form hinzu.
1. Fügen Sie der Textstruktur der Form Text hinzu.
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


## **Interop‑Form‑ID abrufen**
Aspose.Slides for PHP via Java ermöglicht Entwicklern das Abrufen einer eindeutigen Form‑Kennung im Folien‑Umfang im Gegensatz zur Methode [getUniqueId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getuniqueid/), die eine eindeutige Kennung im Präsentations‑Umfang liefert. Die Methode [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getofficeinteropshapeid/) wurde zur Klasse [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) hinzugefügt. Der von [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getofficeinteropshapeid/) zurückgegebene Wert entspricht dem Id‑Wert des Microsoft.Office.Interop.PowerPoint.Shape‑Objekts. Unten steht ein Beispielcode.
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Einzigartige Formkennung im Folienbereich abrufen
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Alternativtext für eine Form festlegen**
Aspose.Slides for PHP via Java ermöglicht Entwicklern das Festlegen von AlternateText für jede Form. Formen in einer Präsentation können über den `Alternative Text` oder die Methode [Shape Name](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/) unterschieden werden. Die Methoden [setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) und [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) können sowohl mit Aspose.Slides als auch mit Microsoft PowerPoint gelesen bzw. gesetzt werden. Mit dieser Methode können Sie einer Form ein Tag zuweisen und verschiedene Vorgänge durchführen, z. B. das Entfernen, Ausblenden oder Neuanordnen von Formen auf einer Folie. So legen Sie den AlternateText einer Form fest:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie der Folie eine beliebige Form hinzu.
1. Arbeiten Sie mit der neu hinzugefügten Form.
1. Durchlaufen Sie die Formen, um eine Form zu finden.
1. Setzen Sie den AlternativeText.
1. Speichern Sie die Datei auf dem Datenträger.
```php
  # Instanziieren Sie die Presentation-Klasse, die die PPTX darstellt
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


## **Layout‑Formate für eine Form zugreifen**
Aspose.Slides for PHP via Java stellt eine einfache API zum Zugriff auf Layout‑Formate für eine Form bereit. Dieser Artikel zeigt, wie Sie auf Layout‑Formate zugreifen können.

Unten steht ein Beispielcode.
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
Jetzt unterstützt Aspose.Slides for PHP via Java das Rendern einer Form als SVG. Die Methode [writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) (und ihre Überladung) wurde zur Klasse [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) hinzugefügt. Diese Methode ermöglicht das Speichern des Inhalts einer Form als SVG‑Datei. Das unten stehende Code‑Snippet zeigt, wie Sie die Form einer Folie in eine SVG‑Datei exportieren.
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

Der nachstehende Quellcode richtet die Formen mit den Indizes 1, 2 und 4 entlang der oberen Folienkante aus.
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

Das folgende Beispiel zeigt, wie die gesamte Formsammlung relativ zur untersten Form in der Sammlung ausgerichtet wird.
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


## **Flip‑Eigenschaften**

In Aspose.Slides stellt die Klasse [ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) die Kontrolle über horizontales und vertikales Spiegeln von Formen über die Eigenschaften `flipH` und `flipV` bereit. Beide Eigenschaften sind vom Typ [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) und können den Wert `True` für ein Spiegeln, `False` für kein Spiegeln oder `NotDefined` für das Standardverhalten annehmen. Diese Werte sind über das [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) einer Form zugänglich.

Um die Flip‑Einstellungen zu ändern, wird eine neue Instanz von [ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) mit der aktuellen Position und Größe der Form, den gewünschten Werten für `flipH` und `flipV` sowie dem Rotationswinkel erstellt. Durch das Zuweisen dieser Instanz zum [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) der Form und das Speichern der Präsentation werden die Spiegeltransformationen angewendet und in die Ausgabedatei übernommen.

Angenommen, wir haben eine Datei sample.pptx, in der die erste Folie eine einzelne Form mit den Standard‑Flip‑Einstellungen enthält, wie unten gezeigt.

![The shape to be flipped](shape_to_be_flipped.png)

Der folgende Beispielcode liest die aktuellen Flip‑Eigenschaften der Form aus und spiegelt sie sowohl horizontal als auch vertikal.
```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // Die horizontale Flip-Eigenschaft der Form abrufen.
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // Die vertikale Flip-Eigenschaft der Form abrufen.
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

![The flipped shape](flipped_shape.png)

## **FAQ**

**Kann ich Formen (Vereinigung/Schnitt/Menge) auf einer Folie wie in einem Desktop‑Editor kombinieren?**

Es gibt keine eingebaute Boolesche‑Operation‑API. Sie können dies annähern, indem Sie die gewünschte Kontur selbst konstruieren – z. B. die resultierende Geometrie (via [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)) berechnen und eine neue Form mit dieser Kontur erstellen, ggf. die Originale entfernen.

**Wie kann ich die Stapelungsreihenfolge (Z‑Order) steuern, sodass eine Form immer „oben“ bleibt?**

Ändern Sie die Einfüge‑/Verschiebe‑Reihenfolge innerhalb der [shapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes)-Sammlung der Folie. Für vorhersehbare Ergebnisse sollten Sie die Z‑Order nach allen anderen Folien‑Modifikationen finalisieren.

**Kann ich eine Form „sperren“, um zu verhindern, dass Nutzer sie in PowerPoint bearbeiten?**

Ja. Setzen Sie [Form‑Schutz‑Flags](/slides/de/php-java/applying-protection-to-presentation/) (z. B. Auswahl, Bewegung, Größenänderung, Textbearbeitung sperren). Bei Bedarf spiegeln Sie Beschränkungen auf dem Master oder Layout wider. Beachten Sie, dass dies ein UI‑Schutz ist, keine Sicherheitsfunktion; für stärkeren Schutz kombinieren Sie ihn mit Dateischutz wie [Lese‑empfehlungen oder Passwörtern](/slides/de/php-java/password-protected-presentation/).