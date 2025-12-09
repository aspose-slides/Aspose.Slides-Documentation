---
title: Diagramm-Datenbeschriftung
type: docs
url: /de/nodejs-java/chart-data-label/
keywords: "Diagrammdatenbeschriftung, Beschriftungsabstand, Java, Aspose.Slides für Node.js via Java"
description: "PowerPoint-Diagrammdatenbeschriftung und Abstand in JavaScript festlegen"
---

Datenbeschriftungen in einem Diagramm zeigen Details zur Diagrammdatenreihe oder zu einzelnen Datenpunkten. Sie ermöglichen es den Lesern, Datenreihen schnell zu identifizieren, und sie machen Diagramme leichter verständlich.

## **Präzision der Daten in Diagrammdatenbeschriftungen festlegen**

Dieser JavaScript‑Code zeigt, wie man die Datenpräzision in einer Diagrammbeschriftung einstellt:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Prozentwerte als Beschriftungen anzeigen**

Aspose.Slides für Node.js über Java ermöglicht es, Prozentbeschriftungen in angezeigten Diagrammen festzulegen. Dieser JavaScript‑Code demonstriert die Vorgehensweise:
```javascript
// Erstellt eine Instanz der Presentation-Klasse
var pres = new aspose.slides.Presentation();
try {
    // Holt die erste Folie
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);
    var series;
    var total_for_Cat = new double[chart.getChartData().getCategories().size()];
    for (var k = 0; k < chart.getChartData().getCategories().size(); k++) {
        var cat = chart.getChartData().getCategories().get_Item(k);
        for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
            total_for_Cat[k] = total_for_Cat[k] + chart.getChartData().getSeries().get_Item(i).getDataPoints().get_Item(k).getValue().getData();
        }
    }
    var dataPontPercent = 0.0;
    for (var x = 0; x < chart.getChartData().getSeries().size(); x++) {
        series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);
        for (var j = 0; j < series.getDataPoints().size(); j++) {
            var lbl = series.getDataPoints().get_Item(j).getLabel();
            dataPontPercent = (series.getDataPoints().get_Item(j).getValue().getData() / total_for_Cat[j]) * 100;
            var port = new aspose.slides.Portion();
            port.setText(java.callStaticMethodSync("java.lang.String", "format", "{0:F2} %.2f", dataPontPercent));
            port.getPortionFormat().setFontHeight(8.0);
            lbl.getTextFrameForOverriding().setText("");
            var para = lbl.getTextFrameForOverriding().getParagraphs().get_Item(0);
            para.getPortions().add(port);
            lbl.getDataLabelFormat().setShowSeriesName(false);
            lbl.getDataLabelFormat().setShowPercentage(false);
            lbl.getDataLabelFormat().setShowLegendKey(false);
            lbl.getDataLabelFormat().setShowCategoryName(false);
            lbl.getDataLabelFormat().setShowBubbleSize(false);
        }
    }
    // Speichert die Präsentation mit dem Diagramm
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Prozentzeichen bei Diagrammbeschriftungen festlegen**

Dieser JavaScript‑Code zeigt, wie man das Prozentzeichen für eine Diagrammbeschriftung festlegt:
```javascript
// Erstellt eine Instanz der Presentation-Klasse
var pres = new aspose.slides.Presentation();
try {
    // Holt einen Verweis auf die Folie über ihren Index
    var slide = pres.getSlides().get_Item(0);
    // Erstellt das PercentsStackedColumn-Diagramm auf einer Folie
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    // Setzt NumberFormatLinkedToSource auf false
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    chart.getChartData().getSeries().clear();
    var defaultWorksheetIndex = 0;
    // Holt das Arbeitsblatt mit den Diagrammdaten
    var workbook = chart.getChartData().getChartDataWorkbook();
    // Fügt neue Serie hinzu
    var series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    // Setzt die Füllfarbe der Serie
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Setzt die Eigenschaften des LabelFormat
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Fügt eine weitere Serie hinzu
    var series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.7));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.5));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.2));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    // Setzt Fülltyp und Farbe
    series2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    // Schreibt die Präsentation auf die Festplatte
    pres.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Beschriftungsabstände von der Achse festlegen**

Dieser JavaScript‑Code zeigt, wie man den Abstand der Beschriftung von einer Kategorienachse einstellt, wenn man ein Diagramm hat, das anhand von Achsen geplottet wird:
```javascript
// Erstellt eine Instanz der Presentation-Klasse
var pres = new aspose.slides.Presentation();
try {
    // Holt einen Verweis auf die Folie
    var sld = pres.getSlides().get_Item(0);
    // Erstellt ein Diagramm auf der Folie
    var ch = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    // Setzt den Beschriftungsabstand von einer Achse
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    // Schreibt die Präsentation auf die Festplatte
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Beschriftungsposition anpassen**

Wenn Sie ein Diagramm erstellen, das keine Achse verwendet, wie z.B. ein Kreisdiagramm, können die Datenbeschriftungen des Diagramms zu nahe am Rand liegen. In einem solchen Fall müssen Sie die Position der Datenbeschriftung anpassen, sodass die Führungs­linien klar dargestellt werden.

Dieser JavaScript‑Code zeigt, wie man die Beschriftungsposition in einem Kreisdiagramm anpasst:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    var series = chart.getChartData().getSeries();
    var label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71);
    label.setY(0.04);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **FAQ**

**Wie kann ich verhindern, dass Datenbeschriftungen bei dichten Diagrammen überlappen?**

Kombinieren Sie automatische Beschriftungsplatzierung, Führungs­linien und reduzierte Schriftgröße; bei Bedarf können Sie einige Felder (z. B. die Kategorie) ausblenden oder Beschriftungen nur für extreme/Schlüsselpunkte anzeigen.

**Wie kann ich Beschriftungen nur für null, negative oder leere Werte deaktivieren?**

Filtern Sie Datenpunkte, bevor Sie Beschriftungen aktivieren, und schalten Sie die Anzeige für Werte von 0, negative Werte oder fehlende Werte gemäß einer definierten Regel aus.

**Wie kann ich einen konsistenten Beschriftungsstil beim Exportieren in PDF/Bilder sicherstellen?**

Legen Sie Schriftarten (Familie, Größe) explizit fest und stellen Sie sicher, dass die Schriftart auf der Rendering‑Seite verfügbar ist, um ein Zurückgreifen auf Ersatzschriften zu vermeiden.