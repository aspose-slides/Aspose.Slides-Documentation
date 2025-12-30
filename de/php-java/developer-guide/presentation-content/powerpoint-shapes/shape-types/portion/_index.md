---
title: Verwalten von Textabschnitten in Präsentationen mit PHP
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
description: "Erfahren Sie, wie Sie Textabschnitte in PowerPoint-Präsentationen mit Aspose.Slides für PHP über Java verwalten, um Leistung und Anpassung zu steigern."
---

## **Koordinaten eines Textabschnitts abrufen**
[**getCoordinates()**](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getCoordinates--) Methode wurde zu [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IPortion) und [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) hinzugefügt und ermöglicht das Abrufen der Koordinaten des Beginns des Abschnitts.
```php
  # Instanziieren Sie die Presentation-Klasse, die die PPTX darstellt
  $pres = new Presentation();
  try {
    # Umformen des Kontextes der Präsentation
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

**Kann ich einem nur einem Teil des Textes in einem einzelnen Absatz einen Hyperlink zuweisen?**

Ja, Sie können einem einzelnen Abschnitt einen [Hyperlink zuweisen](/slides/de/php-java/manage-hyperlinks/); nur dieses Fragment ist anklickbar, nicht der gesamte Absatz.

**Wie funktioniert die Vererbung von Stilen: Was überschreibt ein Portion und was wird von Paragraph/TextFrame übernommen?**

Eigenschaften auf Portion-Ebene haben die höchste Priorität. Wenn eine Eigenschaft nicht am [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) festgelegt ist, übernimmt die Engine sie vom [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/); ist sie dort ebenfalls nicht gesetzt, vom [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) oder vom [theme](https://reference.aspose.com/slides/php-java/aspose.slides/theme/) Stil.

**Was passiert, wenn die für einen Portion angegebene Schriftart auf dem Zielrechner/Server fehlt?**

[Regeln für die Schriftart-Ersetzung](/slides/de/php-java/font-selection-sequence/) gelten. Der Text kann umfließen: Metriken, Silbentrennung und Breite können sich ändern, was für präzise Positionierung wichtig ist.

**Kann ich eine portionsspezifische Textfüll-Transparenz oder einen Farbverlauf unabhängig vom restlichen Absatz festlegen?**

Ja, Textfarbe, Füllung und Transparenz auf [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) Ebene können sich von benachbarten Fragmenten unterscheiden.