---
title: Formmanipulationen
type: docs
weight: 40
url: /php-java/formmanipulationen/
---

## **Form in Folie finden**
Dieses Thema beschreibt eine einfache Technik, um es Entwicklern zu erleichtern, eine bestimmte Form auf einer Folie zu finden, ohne ihre interne ID zu verwenden. Es ist wichtig zu wissen, dass PowerPoint-Präsentationsdateien keine Möglichkeit haben, Formen auf einer Folie außer einer internen eindeutigen ID zu identifizieren. Es scheint schwierig für Entwickler zu sein, eine Form anhand ihrer internen eindeutigen ID zu finden. Alle auf den Folien hinzugefügten Formen haben einen alternativen Text. Wir empfehlen Entwicklern, den alternativen Text zu verwenden, um eine bestimmte Form zu finden. Sie können MS PowerPoint verwenden, um den alternativen Text für Objekte festzulegen, die Sie in Zukunft ändern möchten.

Nachdem Sie den alternativen Text einer gewünschten Form festgelegt haben, können Sie diese Präsentation mit Aspose.Slides für PHP über Java öffnen und durch alle Formen iterieren, die einer Folie hinzugefügt wurden. Während jeder Iteration können Sie den alternativen Text der Form überprüfen, und die Form mit dem übereinstimmenden alternativen Text wäre die von Ihnen benötigte Form. Um diese Technik besser zu demonstrieren, haben wir eine Methode erstellt, [findShape](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-), die das Finden einer bestimmten Form in einer Folie erleichtert und dann einfach diese Form zurückgibt.

```php
  # Instanziieren Sie eine Präsentation-Klasse, die die Präsentationsdatei darstellt
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Alternativer Text der zu findenden Form
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Formname: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Form klonen**
Um eine Form in eine Folie mit Aspose.Slides für PHP über Java zu klonen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Greifen Sie auf die Formensammlung der Quellfolie zu.
1. Fügen Sie eine neue Folie zur Präsentation hinzu.
1. Klonen Sie Formen aus der Formensammlung der Quellfolie in die neue Folie.
1. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Das folgende Beispiel fügt einer Folie eine Gruppierungsform hinzu.

```php
  # Instanziieren Sie die Präsentationsklasse
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

## **Form entfernen**
Aspose.Slides für PHP über Java ermöglicht es Entwicklern, jede Form zu entfernen. Um die Form von einer Folie zu entfernen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Finden Sie die Form mit spezifischem Alternativtext.
1. Entfernen Sie die Form.
1. Speichern Sie die Datei auf der Festplatte.

```php
  # Erstellen Sie ein Präsentationsobjekt
  $pres = new Presentation();
  try {
    # Holen Sie sich die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Fügen Sie eine Autoform vom Typ Rechteck hinzu
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "Benutzerdefiniert";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # Speichern Sie die Präsentation auf der Festplatte
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Form ausblenden**
Aspose.Slides für PHP über Java ermöglicht es Entwicklern, jede Form auszublenden. Um die Form von einer Folie auszublenden, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Finden Sie die Form mit spezifischem Alternativtext.
1. Blenden Sie die Form aus.
1. Speichern Sie die Datei auf der Festplatte.

```php
  # Instanziieren Sie die Präsentationsklasse, die die PPTX darstellt
  $pres = new Presentation();
  try {
    # Holen Sie sich die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Fügen Sie eine Autoform vom Typ Rechteck hinzu
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "Benutzerdefiniert";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # Speichern Sie die Präsentation auf der Festplatte
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Formenreihenfolge ändern**
Aspose.Slides für PHP über Java ermöglicht es Entwicklern, die Formen neu anzuordnen. Das Neuordnen der Form legt fest, welche Form vorne oder hinten ist. Um die Form von einer Folie neu anzuordnen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie eine Form hinzu.
1. Fügen Sie etwas Text im Textfeld der Form hinzu.
1. Fügen Sie eine weitere Form mit denselben Koordinaten hinzu.
1. Schulen Sie die Formen neu.
1. Speichern Sie die Datei auf der Festplatte.

```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Wasserzeichen Text Wasserzeichen Text Wasserzeichen Text");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Interop Shape ID abrufen**
Aspose.Slides für PHP über Java ermöglicht es Entwicklern, einen eindeutigen Formidentifikator im Folienumfang im Gegensatz zur [getUniqueId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getUniqueId--) Methode abzurufen, die einen eindeutigen Identifikator im Präsentationsumfang ermöglicht. Die Methode [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getOfficeInteropShapeId--) wurde zu den Schnittstellen [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) und [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/Shape) hinzugefügt. Der von der Methode [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getOfficeInteropShapeId--) zurückgegebene Wert entspricht dem Wert der ID des Microsoft.Office.Interop.PowerPoint.Shape-Objekts. Im Folgenden ist ein Beispielcode gegeben.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Eindeutigen Formidentifikator im Folienumfang abrufen
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Alternativen Text für eine Form festlegen**
Aspose.Slides für PHP über Java ermöglicht es Entwicklern, den Alternativtext jeder Form festzulegen. Formen in einer Präsentation können durch die [AlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setAlternativeText-java.lang.String-) oder [Formname](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setName-java.lang.String-) Methode unterschieden werden. Die Methoden [setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setAlternativeText-java.lang.String-) und [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getAlternativeText--) können mit Aspose.Slides sowie Microsoft PowerPoint gelesen oder festgelegt werden. Mit dieser Methode können Sie eine Form kennzeichnen und verschiedene Operationen ausführen, wie das Entfernen einer Form, das Ausblenden einer Form oder das Neuordnen von Formen auf einer Folie. Um den Alternativtext einer Form festzulegen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie eine beliebige Form zur Folie hinzu.
1. Arbeiten Sie mit der neu hinzugefügten Form.
1. Durchlaufen Sie die Formen, um eine Form zu finden.
1. Legen Sie den Alternativtext fest.
1. Speichern Sie die Datei auf der Festplatte.

```php
  # Instanziieren Sie die Präsentationsklasse, die die PPTX darstellt
  $pres = new Presentation();
  try {
    # Holen Sie sich die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Fügen Sie eine Autoform vom Typ Rechteck hinzu
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("Benutzerdefiniert");
      }
    }
    # Speichern Sie die Präsentation auf der Festplatte
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Layoutformate für Formen abrufen**
Aspose.Slides für PHP über Java bietet eine einfache API, um Layoutformate für eine Form abzurufen. Dieser Artikel zeigt, wie Sie auf Layoutformate zugreifen können.

Nachfolgend finden Sie einen Beispielcode.

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

## **Formen als SVG rendern**
Jetzt unterstützt Aspose.Slides für PHP über Java das Rendern einer Form als SVG. Die Methode [writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (und ihre Überladung) wurde zur [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/Shape) Klasse und der [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) Schnittstelle hinzugefügt. Diese Methode ermöglicht es, den Inhalt der Form als SVG-Datei zu speichern. Der unten stehende Code zeigt, wie Sie die Form einer Folie in eine SVG-Datei exportieren.

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

## **Ausrichtung von Formen**
Aspose.Slides ermöglicht es, Formen entweder relativ zu den Folienrändern oder relativ zueinander auszurichten. Zu diesem Zweck wurde die überladene Methode [SlidesUtil.alignShape()](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) hinzugefügt. Die Enumeration [ShapesAlignmentType](https://reference.aspose.com/slides/php-java/aspose.slides/ShapesAlignmentType) definiert mögliche Ausrichtungsoptionen.

**Beispiel 1**

Der Quellcode unten richtet die Formen mit den Indizes 1, 2 und 4 entlang der oberen Kante der Folie aus.

```php
  $pres = new Presentation("example.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape1 = $slide->getShapes()->get_Item(1);
    $shape2 = $slide->getShapes()->get_Item(2);
    $shape3 = $slide->getShapes()->get_Item(4);
    SlideUtil->alignShapes(ShapesAlignmentType::AlignTop, true, $pres->getSlides()->get_Item(0), array($slide->getShapes()->indexOf($shape1), $slide->getShapes()->indexOf($shape2), $slide->getShapes()->indexOf($shape3)));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Beispiel 2**

Das folgende Beispiel zeigt, wie man die gesamte Sammlung von Formen relativ zur ganz unteren Form in der Sammlung ausrichtet.

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