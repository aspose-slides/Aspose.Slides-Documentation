---
title: Textabschnitte in Präsentationen mit PHP verwalten
linktitle: Textabschnitt
type: docs
weight: 70
url: /de/php-java/portion/
keywords:
- Textabschnitt
- Textteil
- Textkoordinaten
- Textposition
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Textabschnitte in PowerPoint-Präsentationen mit Aspose.Slides für PHP via Java verwalten, um Leistung und Anpassung zu steigern."
---

## **Koordinaten eines Textabschnitts abrufen**
Die Methode [**getCoordinates()**](https://reference.aspose.com/slides/php-java/aspose.slides/portion/getcoordinates/) wurde zur Klasse [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) hinzugefügt, die das Abrufen der Koordinaten des Beginns des Abschnitts ermöglicht.
```php
  # Instanziiere die Presentation-Klasse, die die PPTX darstellt
  $pres = new Presentation();
  try {
    # Ändere den Kontext der Präsentation
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    foreach($textFrame->getParagraphs() as $paragraph) {
      foreach($paragraph->getPortions() as $portion) {
        $point = $portion->getCoordinates();
        echo("X: " . $point->$x . " Y: " . $point->$y);
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Kann ich einen Hyperlink nur auf einen Teil des Textes innerhalb eines einzelnen Absatzes anwenden?**

Ja, Sie können [einen Hyperlink zuweisen](/slides/de/php-java/manage-hyperlinks/) zu einem einzelnen Portion; nur dieser Abschnitt ist anklickbar, nicht der gesamte Absatz.

**Wie funktioniert die Stilvererbung: Was überschreibt ein Portion und was wird von Paragraph/TextFrame übernommen?**

Portion‑Level‑Eigenschaften haben die höchste Priorität. Wenn eine Eigenschaft nicht auf dem [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) festgelegt ist, übernimmt die Engine sie vom [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/); ist sie dort ebenfalls nicht festgelegt, wird sie vom [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) oder vom [theme](https://reference.aspose.com/slides/php-java/aspose.slides/theme/) Stil übernommen.

**Was passiert, wenn die für einen Portion angegebene Schriftart auf dem Zielrechner/Server fehlt?**

[Schriftart‑Ersetzungsregeln](/slides/de/php-java/font-selection-sequence/) gelten. Der Text kann umfließen: Metriken, Silbentrennung und Breite können sich ändern, was für präzises Positionieren wichtig ist.

**Kann ich eine portion‑spezifische Textfüll‑Transparenz oder einen Farbverlauf unabhängig vom Rest des Absatzes festlegen?**

Ja, Textfarbe, Füllung und Transparenz auf der [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) Ebene können sich von benachbarten Fragmenten unterscheiden.