---
title: Diagrammlegenden in Präsentationen mit JavaScript anpassen
linktitle: Diagrammlegende
type: docs
url: /de/nodejs-java/chart-legend/
keywords:
- Diagrammlegende
- Legendenposition
- Schriftgröße
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Passen Sie Diagrammlegenden mit Aspose.Slides für Node.js via Java an, um PowerPoint-Präsentationen mit maßgeschneiderter Legend-Formatierung zu optimieren."
---
## **Übersicht**

Aspose.Slides für Node.js via Java bietet Optionen zum Anpassen von Diagrammlegenden in PowerPoint-Präsentationen. Dieser Artikel zeigt, wie man eine Legende positioniert und dimensioniert, die Schriftgröße für die gesamte Legende festlegt, einen einzelnen Legendeneintrag formatiert und ausgewählte Einträge ausblendet oder wiederherstellt.

Die FAQ behandelt verwandte Verhaltensweisen, einschließlich des Reservierens von Platz für die Legende, der Anzeige mehrzeiliger Beschriftungen und dem Erben von Formatierungen aus dem Präsentationsthema.

## **Legendenpositionierung**

Verwenden Sie die Methoden [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setwidth/), und [setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setheight/) der Legende, um deren Position und Größe als Bruchteile der Diagrammabmessungen anzugeben.

Dieses Beispiel erstellt eine Präsentation und fügt der ersten Folie ein gruppiertes Säulendiagramm mit Standarddaten hinzu. Durch Teilen der gewünschten Legendenversätze und -abmessungen durch die Breite und Höhe des Diagramms werden sie in relative Werte umgewandelt: Die Legende ist um 50 Punkte vom oberen linken Eck des Diagramms versetzt und hat die Größe 100 × 100 Punkte.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Geben Sie die Position und Größe der Legende relativ zum Diagramm an.
    chart.getLegend().setX(java.newFloat(50 / chart.getWidth()));
    chart.getLegend().setY(java.newFloat(50 / chart.getHeight()));
    chart.getLegend().setWidth(java.newFloat(100 / chart.getWidth()));
    chart.getLegend().setHeight(java.newFloat(100 / chart.getHeight()));

    presentation.save("legend_position.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Schriftgröße einer Legende festlegen**

Verwenden Sie die Methode [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/gettextformat/), um auf die Textformatierung der Legende zuzugreifen, und verwenden Sie [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight), um die Schriftgröße in Punkten festzulegen.

Dieses Beispiel erstellt ein Diagramm mit Standarddaten und setzt den Legendentext auf 20 Punkte. Es deaktiviert außerdem die automatischen Grenzen der vertikalen Achse und legt deren Bereich von -5 bis 10 fest.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Schriftgröße eines einzelnen Legendeneintrags festlegen**

Verwenden Sie die von der Methode [getEntries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/getentries/) der Legende zurückgegebene Auflistung, um die Formatierung eines bestimmten Eintrags zu erhalten. Eintragsindizes beginnen bei Null, sodass Index `1` den zweiten Eintrag bezeichnet.

Dieses Beispiel erstellt ein gruppiertes Säulendiagramm, dessen Standarddaten mindestens zwei Datenreihen enthalten. Es formatiert den zweiten Legendeneintrag fett, kursiv und mit blauem 20‑Punkte‑Text.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    var blue = java.getStaticFieldValue("java.awt.Color", "BLUE");
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(blue);

    presentation.save("legend_entry_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Einzelne Legendeneinträge ausblenden**

Um eine Hilfsreihe aus der Legende auszuschließen, während ihre Daten sichtbar bleiben, rufen Sie [LegendEntryProperties.setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) mit `true` über [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getrelatedlegendentry/) auf. Dadurch wird nur der ausgewählte Legendeneintrag ausgeblendet; die Reihe oder ihre Datenpunkte werden nicht entfernt. Im Gegensatz dazu blendet ein Aufruf von [Chart.setLegend](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setlegend/) mit `false` die gesamte Legende aus.

Das nachstehende Beispiel erstellt ein gruppiertes Säulendiagramm mit mehreren Reihen unter Verwendung von Standarddaten. Es blendet den Legendeneintrag der zweiten Reihe (Index `1`) aus und speichert die Präsentation. Anschließend wird der Eintrag durch Aufruf von [setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) mit `false` wiederhergestellt und eine zweite Kopie gespeichert. Die Säulen bleiben in beiden Dateien sichtbar.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    var legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);

    // Stelle denselben Eintrag wieder her, ohne die Diagrammdaten zu ändern.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der Vergleich unten zeigt dasselbe Diagramm mit allen sichtbaren Einträgen und mit dem ausgeblendeten zweiten Eintrag. Die Säulen der zweiten Reihe bleiben unverändert.

![Vergleich eines Diagramms mit allen sichtbaren Legendeneinträgen und mit Serie 2, die in der Legende ausgeblendet ist; alle Säulen bleiben sichtbar.](hide-legend-entry.png)

In Säulen-, Balken- und Liniendiagrammen identifizieren Legendeneinträge Reihen. Bei Kreisdiagrammen identifizieren sie einzelne Datenpunkte (Scheiben); verwenden Sie stattdessen [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) auf der ausgewählten Scheibe. Die API dokumentiert diese Datenpunkt‑Methode für die Diagrammtypen `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` und `BarOfPie`. Gehen Sie nicht davon aus, dass sie für Donut‑Diagramme gilt, die in dieser Liste nicht enthalten sind.

## **FAQ**

**Kann ich das Diagramm dazu bringen, Platz für die Legende zu reservieren, anstatt sie zu überlagern?**

Ja. Rufen Sie [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/) mit `false` auf, um Platz für die Legende zu reservieren, anstatt zuzulassen, dass sie den Plot‑Bereich überlagert.

**Kann ich mehrzeilige Legendebeschriftungen erstellen?**

Ja. Lange Beschriftungen können umbrechen, wenn die verfügbare Breite nicht ausreicht. Sie können außerdem Zeilenumbruch‑Zeichen in Reihen‑Namen verwenden, um Zeilenumbrüche zu erzwingen.

**Wie bringe ich die Legende dazu, dem Farbschema des Präsentationsthemas zu folgen?**

Lassen Sie die Farben, Füllungen und Schriftarten der Legende ungeändert, damit sie die Themenformatierung erben kann. Explizite Formatierungen überschreiben die entsprechenden Theme‑Einstellungen.