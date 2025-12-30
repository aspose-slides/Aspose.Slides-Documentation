---
title: Diagrammlegenden in Präsentationen mit PHP anpassen
linktitle: Diagrammlegende
type: docs
url: /de/php-java/chart-legend/
keywords:
- Diagrammlegende
- Legendenposition
- Schriftgröße
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Passen Sie Diagrammlegenden mit Aspose.Slides für PHP via Java an, um PowerPoint-Präsentationen mit individuell gestalteter Legendenformatierung zu optimieren."
---

## **Legendenpositionierung**
Um die Eigenschaften der Legende festzulegen, befolgen Sie bitte die untenstehenden Schritte:

- Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Holen Sie die Referenz der Folie.
- Fügen Sie der Folie ein Diagramm hinzu.
- Legen Sie die Eigenschaften der Legende fest.
- Speichern Sie die Präsentation als PPTX-Datei.

Im nachfolgenden Beispiel haben wir die Position und Größe der Diagrammlegende festgelegt.
```php
  # Instanz der Klasse Presentation erstellen
  $pres = new Presentation();
  try {
    # Referenz der Folie abrufen
    $slide = $pres->getSlides()->get_Item(0);
    # Ein gruppiertes Säulendiagramm auf der Folie hinzufügen
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);
    # Legenden-Eigenschaften festlegen
    $chart->getLegend()->setX(50 / $chart->getWidth());
    $chart->getLegend()->setY(50 / $chart->getHeight());
    $chart->getLegend()->setWidth(100 / $chart->getWidth());
    $chart->getLegend()->setHeight(100 / $chart->getHeight());
    # Präsentation auf die Festplatte schreiben
    $pres->save("Legend_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Schriftgröße einer Legende festlegen**
Aspose.Slides für PHP via Java ermöglicht Entwicklern, die Schriftgröße der Legende festzulegen. Befolgen Sie bitte die untenstehenden Schritte:

- Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Erstellen Sie das Standarddiagramm.
- Legen Sie die Schriftgröße fest.
- Setzen Sie den minimalen Achsenwert.
- Setzen Sie den maximalen Achsenwert.
- Speichern Sie die Präsentation auf dem Datenträger.
```php
  # Instanz der Klasse Presentation erstellen
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Schriftgröße einer einzelnen Legende festlegen**
Aspose.Slides für PHP via Java ermöglicht Entwicklern, die Schriftgröße einzelner Legendeinträge festzulegen. Befolgen Sie bitte die untenstehenden Schritte:

- Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Erstellen Sie das Standarddiagramm.
- Zugriff auf den Legendeintrag.
- Legen Sie die Schriftgröße fest.
- Setzen Sie den minimalen Achsenwert.
- Setzen Sie den maximalen Achsenwert.
- Speichern Sie die Präsentation auf dem Datenträger.
```php
  # Instanz der Klasse Presentation erstellen
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $tf = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();
    $tf->getPortionFormat()->setFontBold(NullableBool::True);
    $tf->getPortionFormat()->setFontHeight(20);
    $tf->getPortionFormat()->setFontItalic(NullableBool::True);
    $tf->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $tf->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Kann ich die Legende aktivieren, sodass das Diagramm automatisch Platz dafür reserviert, anstatt sie zu überlagern?**

Ja. Verwenden Sie den Nicht‑Überlagerungsmodus ([setOverlay(false)](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/)); in diesem Fall verkleinert sich der Diagrammbereich, um die Legende aufzunehmen.

**Kann ich mehrzeilige Legendenbeschriftungen erstellen?**

Ja. Lange Beschriftungen werden automatisch umgebrochen, wenn nicht genug Platz vorhanden ist; erzwungene Zeilenumbrüche werden mittels Zeilenumbruchzeichen im Seriennamen unterstützt.

**Wie kann ich die Legende an das Farbschema des Präsentationsthemas anpassen?**

Setzen Sie keine expliziten Farben/Füllungen/Schriften für die Legende oder ihren Text. Sie erben dann vom Theme und werden bei Änderungen des Designs korrekt aktualisiert.