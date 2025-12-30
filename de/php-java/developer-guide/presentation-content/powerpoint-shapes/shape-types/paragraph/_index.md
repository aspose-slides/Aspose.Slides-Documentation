---
title: "Absatzgrenzen aus Präsentationen in PHP abrufen"
linktitle: "Absatz"
type: docs
weight: 60
url: /de/php-java/paragraph/
keywords:
- Absatzgrenzen
- Textabschnittsgrenzen
- Absatzkoordinate
- Abschnittskoordinate
- Absatzgröße
- Textabschnittsgröße
- Textfeld
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Absatz- und Textabschnittsgrenzen in Aspose.Slides für PHP über Java abrufen, um die Textpositionierung in PowerPoint-Präsentationen zu optimieren."
---

## **Abrufen von Absatz- und Portionkoordinaten in einem TextFrame**
Mit Aspose.Slides für PHP über Java können Entwickler jetzt die rechteckigen Koordinaten für einen Paragraphen innerhalb der Absatzsammlung eines TextFrames erhalten. Es ermöglicht auch das Abrufen [die Koordinaten der Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getCoordinates--) innerhalb der Portionensammlung eines Absatzes. In diesem Thema zeigen wir anhand eines Beispiels, wie man die rechteckigen Koordinaten für einen Absatz zusammen mit der Position der Portion innerhalb eines Absatzes ermittelt.
```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```


## **Abrufen der rechteckigen Koordinaten eines Paragraphen**
Mit der Methode [**getRect()**](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraph#getRect--) können Entwickler das Begrenzungsrechteck des Absatzes erhalten.
```php
  $pres = new Presentation("HelloWorld.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    $rect = $textFrame->getParagraphs()->get_Item(0)->getRect();
    echo("X: " . $rect->$x . " Y: " . $rect->$y . " Width: " . $rect->$width . " Height: " . $rect->$height);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Ermitteln der Größe eines Absatzes und einer Portion innerhalb eines TextFrames einer Tabellenzelle**
Um die Größe und Koordinaten einer [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) oder eines [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph) in einem TextFrame einer Tabellenzelle zu erhalten, können Sie die Methoden [IPortion.getRect](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getRect--) und [IParagraph.getRect](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraph#getRect--) verwenden.

Dieser Beispielcode demonstriert die beschriebene Operation:
```php
  $pres = new Presentation("source.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $cell = $tbl->getRows()->get_Item(1)->get_Item(1);
    $x = $tbl->getX() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetX();
    $y = $tbl->getY() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetY();
    foreach($cell->getTextFrame()->getParagraphs() as $para) {
      if ($para->getText()->equals("")) {
        continue;
      }
      $rect = $para->getRect();
      $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
      $shape->getFillFormat()->setFillType(FillType::NoFill);
      $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
      $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
      foreach($para->getPortions() as $portion) {
        if ($portion->getText()->contains("0")) {
          $rect = $portion->getRect();
          $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
          $shape->getFillFormat()->setFillType(FillType::NoFill);
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**In welchen Einheiten werden die Koordinaten für einen Absatz und Textportionen zurückgegeben?**

In Punkten, wobei 1 Zoll = 72 Punkte entspricht. Dies gilt für alle Koordinaten und Abmessungen auf der Folie.

**Beeinflusst Wortumbruch die Begrenzung eines Absatzes?**

Ja. Wenn [wrapping](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setwraptext/) im [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) aktiviert ist, bricht der Text um, um die Breite des Bereichs zu füllen, wodurch sich die tatsächliche Begrenzung des Absatzes ändert.

**Können Absatzkoordinaten zuverlässig in Pixel im exportierten Bild umgewandelt werden?**

Ja. Konvertieren Sie Punkte in Pixel mithilfe von: pixels = points × (DPI / 72). Das Ergebnis hängt vom für die Darstellung/den Export gewählten DPI ab.

**Wie erhalte ich die „effektiven“ Absatzformatierungsparameter unter Berücksichtigung der Stilvererbung?**

Verwenden Sie die [effective paragraph formatting data structure](/slides/de/php-java/shape-effective-properties/); sie gibt die endgültigen konsolidierten Werte für Einzüge, Abstand, Umbruch, RTL und mehr zurück.