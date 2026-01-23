---
title: Absatzgrenzen aus Präsentationen in PHP ermitteln
linktitle: Absatz
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
- Textrahmen
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Absatz- und Textabschnittsgrenzen in Aspose.Slides für PHP über Java abrufen, um die Textpositionierung in PowerPoint-Präsentationen zu optimieren."
---

## **Absatz‑ und Abschnittskoordinaten in einem TextFrame abrufen**
Mit Aspose.Slides für PHP über Java können Entwickler jetzt die rechteckigen Koordinaten für einen Absatz innerhalb der Absatzsammlung eines TextFrames erhalten. Außerdem können Sie die [the coordinates of portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getCoordinates) innerhalb der Abschnittssammlung eines Absatzes abrufen. In diesem Thema zeigen wir anhand eines Beispiels, wie Sie die rechteckigen Koordinaten für einen Absatz zusammen mit der Position eines Abschnitts innerhalb eines Absatzes erhalten.
```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```



## **Rechteckige Koordinaten eines Absatzes abrufen**
Mit der [**getRect()**](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect)‑Methode können Entwickler das Begrenzungsrechteck des Absatzes erhalten.
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


## **Größe eines Absatzes und Abschnitts in einem TextFrame einer Tabellenzelle abrufen**

Um die Größe und Koordinaten des [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion)‑ oder [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph)‑Objekts in einem TextFrame einer Tabellenzelle zu erhalten, können Sie die Methoden [Portion::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getRect) und [Paragraph::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect) verwenden.

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

**In welchen Einheiten werden die Koordinaten für einen Absatz und Textabschnitte zurückgegeben?**

In Punkten, wobei 1 Zoll = 72 Punkte ist. Dies gilt für alle Koordinaten und Abmessungen auf der Folie.

**Beeinflusst die Zeilenumbruch‑Funktion die Grenzen eines Absatzes?**

Ja. Wenn das [wrapping](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setwraptext/) im [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) aktiviert ist, wird der Text umgebrochen, um die Breite des Bereichs zu füllen, wodurch sich die tatsächlichen Grenzen des Absatzes ändern.

**Können Absatzkoordinaten zuverlässig in Pixel im exportierten Bild umgerechnet werden?**

Ja. Konvertieren Sie Punkte in Pixel mit: pixels = points × (DPI / 72). Das Ergebnis hängt vom für das Rendering/Export gewählten DPI ab.

**Wie erhalte ich die „effektiven“ Absatzformatierungsparameter unter Berücksichtigung der Stilvererbung?**

Verwenden Sie die [effective paragraph formatting data structure](/slides/de/php-java/shape-effective-properties/); sie gibt die endgültigen konsolidierten Werte für Einzüge, Abstände, Umbruch, RTL und mehr zurück.