---
title: Anpassen von Tortendiagrammen in Präsentationen mit JavaScript
linktitle: Tortendiagramm
type: docs
url: /de/nodejs-java/pie-chart/
keywords:
- Tortendiagramm
- Diagramm verwalten
- Diagramm anpassen
- Diagrammoptionen
- Diagrammeinstellungen
- Plot-Optionen
- Segmentfarbe
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erstellen und Anpassen von Tortendiagrammen in JavaScript mit Aspose.Slides für Node.js via Java. Sekundäre Plots konfigurieren, Datenbeschriftungen anzeigen und automatische Segmentfarben in PowerPoint anwenden."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Tortendiagrammen in Aspose.Slides arbeitet. Er zeigt, wie man sekundäre Plot‑Optionen für Pie of Pie‑ und Bar of Pie‑Diagramme konfiguriert und wie man die automatische Farbzuweisung für ein Standard‑Tortendiagramm aktiviert.

Die Beispiele konzentrieren sich auf Diagrammanpassungen wie das Hinzufügen eines Diagramms zu einer Folie, das Anpassen von Reihen‑ und Beschriftungseinstellungen, das Ersetzen von Standard‑Diagrammdaten durch benutzerdefinierte Kategorien und Werte sowie das Speichern der aktualisierten Präsentation.

## **Optionen für das sekundäre Diagramm bei Pie of Pie- und Bar of Pie-Diagrammen**

Aspose.Slides for Node.js via Java unterstützt sekundäre Plot‑Optionen für Pie of Pie‑ und Bar of Pie‑Diagramme. Diese Optionen steuern die Größe des sekundären Plots und wie Datenpunkte zwischen den beiden Plots aufgeteilt werden.

Das folgende Beispiel erstellt ein Pie of Pie‑Diagramm in einer neuen Präsentation und zeigt Datenpunktwerte als Beschriftungen an. Die Methode [setSecondPieSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setSecondPieSize) setzt die Größe des sekundären Plots auf 149 % des Hauptplots. [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) wählt eine prozentbasierte Aufteilung, und [setPieSplitPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) legt den Schwellenwert auf 53 % fest.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    const series = chart.getChartData().getSeries().get_Item(0);

    // Werte anzeigen und den sekundären Plot konfigurieren.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Kategorien für das sekundäre Diagramm auswählen**

Verwenden Sie benutzerdefiniertes Splitten, wenn Sie bestimmte Kategorien im sekundären Plot zusammenfassen möchten, unabhängig von deren prozentualen Werten. Zum Beispiel könnte ein Verkaufsbericht Online und Events zusammen anzeigen, sodass Leser diese beiden Kanäle vergleichen können, obwohl sie 35 % bzw. 10 % des Gesamtumsatzes ausmachen.

Rufen Sie [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) mit [PieSplitType.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplittype/#Custom) auf und wählen Sie die Punkte über [getPieSplitCustomPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints) aus. Die [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#add)-Methode der Sammlung akzeptiert einen nullbasierten Index in der Reihe; verwenden Sie [addItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#addItem), um ein Datenpunktobjekt hinzuzufügen. In diesem Beispiel wählt Index 1 Online aus, und der Punkt bei Index 3 wählt Events aus. Partners wird ebenfalls vorübergehend hinzugefügt und dann mit [removeItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#removeItem) entfernt.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 600, 200);

    // Standarddaten durch Verkauf nach Kanal ersetzen.
    const workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    const values = [ 40, 35, 15, 10 ];
    const seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Online anhand seines nullbasierten Index auswählen und Events anhand seines Datenpunktobjekts.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Partners aus der Auswahl ausschließen, ohne die Quelldaten zu löschen.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) und Events (10) erscheinen als separate Segmente im sekundären Plot. Im primären Plot werden sie durch ein kombiniertes Segment mit dem Wert 45 dargestellt, zusammen mit Retail (40) und Partners (15). Das Entfernen von Partners aus der benutzerdefinierten Auswahl lässt es im primären Plot erhalten; die Kategorie oder ihr Wert werden nicht aus den Quelldaten des Diagramms entfernt.

Das folgende Bild zeigt die gespeicherte Präsentation in PowerPoint:

![Pie of Pie-Diagramm mit Online und Events im sekundären Plot und ihrem kombinierten Wert von 45 im primären Plot](pie_of_pie_custom.png)

## **Automatische Farben für Torten‑Diagrammabschnitte festlegen**

Aspose.Slides for Node.js via Java kann automatisch unterschiedlichen Tortenabschnitten verschiedene Farben zuweisen. Das folgende Beispiel erstellt ein Tortendiagramm mit zentriertem Titel und ersetzt die Standarddaten durch drei Quartalskategorien und deren Werte. Die Methode [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue) zeigt die Werte 20, 50 und 30 als Beschriftungen an, während [setColorVaried](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setColorVaried) für jeden Abschnitt eine eigene Farbe aktiviert.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);

    // Zentrierten Diagrammtitel hinzufügen.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Standarddaten mit dem ersten Arbeitsblatt ersetzen.
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    const values = [ 20, 50, 30 ];
    const seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // Werte anzeigen und den Segmenten unterschiedliche Farben zuweisen.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Werden die Pie of Pie- und Bar of Pie-Varianten unterstützt?**

Ja, die Bibliothek [unterstützt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) ein sekundäres Diagramm für Tortendiagramme, einschließlich der Typen Pie of Pie und Bar of Pie.

**Kann ich nur das Diagramm als Bild exportieren (z. B. PNG)?**

Ja, Sie können [exportiere das Diagramm selbst als Bild](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) (wie PNG) exportieren, ohne die gesamte Präsentation zu exportieren.