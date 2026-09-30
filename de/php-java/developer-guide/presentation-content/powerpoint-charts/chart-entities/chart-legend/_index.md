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
description: "Passen Sie Diagrammlegenden mit Aspose.Slides für PHP über Java an, um PowerPoint-Präsentationen mit individuell formatierter Legende zu optimieren."
---
## **Übersicht**

Aspose.Slides für PHP über Java bietet Optionen zum Anpassen von Diagrammlegenden in PowerPoint-Präsentationen. Dieser Artikel zeigt, wie man eine Legende positioniert und ihre Größe festlegt, die Schriftgröße für die gesamte Legende einstellt, einen einzelnen Legendeintrag formatiert und ausgewählte Einträge ausblendet oder wiederherstellt.

Die FAQ behandelt verwandte Verhaltensweisen, einschließlich der Reservierung von Platz für die Legende, der Anzeige mehrzeiliger Beschriftungen und der Vererbung von Formatierungen aus dem Präsentationsthema.

## **Legendenpositionierung**

Verwenden Sie die Methoden [setX](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/php-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setwidth/), und [setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setheight/) der Legende, um deren Position und Größe als Bruchteile der Diagrammabmessungen festzulegen.

Dieses Beispiel erstellt eine Präsentation und fügt der ersten Folie ein gruppiertes Säulendiagramm mit Standarddaten hinzu. Durch das Teilen der gewünschten Legendenversätze und -abmessungen durch die Breite und Höhe des Diagramms werden sie in relative Werte umgewandelt: Die Legende ist um 50 Punkte vom oberen linken Eckpunkt des Diagramms versetzt und hat die Größe 100 × 100 Punkte. Das Beispiel verwendet java_values, um die vom PHP/Java Bridge zurückgegebenen Diagrammabmessungen vor der Division in PHP‑Zahlen zu konvertieren.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

    $chartWidth = java_values($chart->getWidth());
    $chartHeight = java_values($chart->getHeight());

    // Geben Sie die Position und Größe der Legende relativ zum Diagramm an.
    $chart->getLegend()->setX(50 / $chartWidth);
    $chart->getLegend()->setY(50 / $chartHeight);
    $chart->getLegend()->setWidth(100 / $chartWidth);
    $chart->getLegend()->setHeight(100 / $chartHeight);

    $presentation->save("legend_position.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Schriftgröße einer Legende festlegen**

Verwenden Sie die Methode [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/gettextformat/) , um auf die Textformatierung der Legende zuzugreifen, und verwenden Sie [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) , um die Schriftgröße in Punkten festzulegen.

Dieses Beispiel erstellt ein Diagramm mit Standarddaten und setzt den Legendentext auf 20 Punkte. Es deaktiviert außerdem automatische Grenzen für die vertikale Achse und legt deren Wertebereich von -5 bis 10 fest.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);

    $presentation->save("legend_font_size.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Schriftgröße eines einzelnen Legendeintrags festlegen**

Verwenden Sie die von der Methode [getEntries](https://reference.aspose.com/slides/php-java/aspose.slides/legend/getentries/) der Legende zurückgegebene Sammlung, um die Formatierung eines bestimmten Eintrags zuzugreifen. Eintragsindizes beginnen bei null, sodass Index `1` den zweiten Eintrag bezeichnet.

Dieses Beispiel erstellt ein gruppiertes Säulendiagramm, dessen Standarddaten mindestens zwei Serien enthalten. Es formatiert den zweiten Legendeintrag mit fett, kursiv und blauem Text in 20 Punkten.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $textFormat = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();

    $textFormat->getPortionFormat()->setFontBold(NullableBool::True);
    $textFormat->getPortionFormat()->setFontHeight(20);
    $textFormat->getPortionFormat()->setFontItalic(NullableBool::True);
    $textFormat->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $textFormat->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("legend_entry_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Einzelne Legendeinträge ausblenden**

Um eine Hilfsserie aus der Legende auszuschließen, während ihre Daten sichtbar bleiben, rufen Sie [LegendEntryProperties::setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) mit `true` über [ChartSeries::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getrelatedlegendentry/) auf. Dadurch wird nur der ausgewählte Legendeintrag ausgeblendet; die Serie oder ihre Datenpunkte werden nicht entfernt. Im Gegensatz dazu blendet ein Aufruf von [Chart::setLegend](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setlegend/) mit `false` die gesamte Legende aus.

Das nachstehende Beispiel erstellt ein gruppiertes Säulendiagramm mit mehreren Serien unter Verwendung von Standarddaten. Es blendet den Legendeintrag der zweiten Serie (Index `1`) aus und speichert die Präsentation. Anschließend wird der Eintrag durch Aufruf von [setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) mit `false` wiederhergestellt und eine zweite Kopie gespeichert. Die Säulen bleiben in beiden Dateien sichtbar.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(true);

    $legendEntry = $chart->getChartData()->getSeries()->get_Item(1)->getRelatedLegendEntry();

    $legendEntry->setHide(true);
    $presentation->save("hidden_legend_entry.pptx", SaveFormat::Pptx);

    // Wiederherstellen des gleichen Eintrags ohne Änderung der Diagrammdaten.
    $legendEntry->setHide(false);
    $presentation->save("restored_legend_entry.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Der Vergleich unten zeigt dasselbe Diagramm mit allen sichtbaren Einträgen und mit dem ausgeblendeten zweiten Eintrag. Die Säulen der zweiten Serie bleiben unverändert.

![Vergleich eines Diagramms mit allen sichtbaren Legendeinträgen und mit ausgeblendeter Serie 2 in der Legende; alle Säulen bleiben sichtbar.](hide-legend-entry.png)

In Säulen-, Balken- und Liniendiagrammen identifizieren Legendeinträge die Serien. Bei Tortendiagrammen identifizieren sie einzelne Datenpunkte (Schnitte), daher verwenden Sie stattdessen [ChartDataPoint::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) für den ausgewählten Abschnitt. Die API dokumentiert diese Datenpunkt‑Methode für die Diagrammtypen `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` und `BarOfPie`. Gehen Sie nicht davon aus, dass sie für Donut‑Diagramme gilt, die nicht in dieser Liste enthalten sind.

## **FAQ**

**Kann ich das Diagramm dazu bringen, Platz für die Legende zu reservieren, anstatt sie zu überlagern?**

Ja. Rufen Sie [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/) mit `false` auf, um Platz für die Legende zu reservieren, anstatt zuzulassen, dass sie den Plot‑Bereich überlappt.

**Kann ich mehrzeilige Legendenbeschriftungen erstellen?**

Ja. Lange Beschriftungen können umbrechen, wenn die verfügbare Breite nicht ausreicht. Sie können außerdem Zeilenumbrüche in Seriennamen einfügen, um Zeilenumbrüche zu erzwingen.

**Wie lasse ich die Legende dem Farbschema des Präsentationsthemas folgen?**

Lassen Sie die Farben, Füllungen und Schriftarten der Legende unverändert, damit sie die Theme‑Formatierung erben kann. Explizite Formatierungen überschreiben die entsprechenden Theme‑Einstellungen.