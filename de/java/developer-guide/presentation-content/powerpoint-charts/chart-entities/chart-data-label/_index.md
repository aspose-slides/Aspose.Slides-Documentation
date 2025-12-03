---
title: Diagrammdatenbeschriftungen in Präsentationen mit Java verwalten
linktitle: Datenbeschriftung
type: docs
url: /de/java/chart-data-label/
keywords:
- Diagramm
- Datenbeschriftung
- Datenpräzision
- Prozentsatz
- Beschriftungsabstand
- Beschriftungsposition
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammdatenbeschriftungen in PowerPoint-Präsentationen mit Aspose.Slides für Java hinzufügen und formatieren, um ansprechendere Folien zu erstellen."
---

Datenbeschriftungen in einem Diagramm zeigen Details zu den Diagrammdatenreihen oder einzelnen Datenpunkten an. Sie ermöglichen es Lesern, Datenreihen schnell zu identifizieren, und sie machen Diagramme zudem leichter verständlich.

## **Präzision der Daten in Diagrammdatenbeschriftungen festlegen**

Dieser Java‑Code zeigt, wie Sie die Datenpräzision in einer Diagrammbeschriftung festlegen:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    
    chart.setDataTable(true);
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00");

    pres.save("output.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Prozentsatz als Beschriftungen anzeigen**

Aspose.Slides für Java ermöglicht das Festlegen von Prozent‑Beschriftungen in angezeigten Diagrammen. Dieser Java‑Code demonstriert die Vorgehensweise:
```java
// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Ruft die erste Folie ab
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);
    IChartSeries series;
    double[] total_for_Cat = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        IChartCategory cat = chart.getChartData().getCategories().get_Item(k);
    
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            total_for_Cat[k] = total_for_Cat[k] + (double) (chart.getChartData().getSeries().get_Item(i).getDataPoints().get_Item(k).getValue().getData());
        }
    }
    
    double dataPontPercent = 0f;
    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);
    
        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel lbl = series.getDataPoints().get_Item(j).getLabel();
            dataPontPercent = (double) ((series.getDataPoints().get_Item(j).getValue().getData())) / (double) (total_for_Cat[j]) * 100;
    
            IPortion port = new Portion();
            port.setText(String.format("{0:F2} %.2f", dataPontPercent));
            port.getPortionFormat().setFontHeight(8f);
            lbl.getTextFrameForOverriding().setText("");
            IParagraph para = lbl.getTextFrameForOverriding().getParagraphs().get_Item(0);
            para.getPortions().add(port);
    
            lbl.getDataLabelFormat().setShowSeriesName(false);
            lbl.getDataLabelFormat().setShowPercentage(false);
            lbl.getDataLabelFormat().setShowLegendKey(false);
            lbl.getDataLabelFormat().setShowCategoryName(false);
            lbl.getDataLabelFormat().setShowBubbleSize(false);
        }
    }
    
    // Speichert die Präsentation, die das Diagramm enthält
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Prozentzeichen in Diagrammbeschriftungen festlegen**

Dieser Java‑Code zeigt, wie Sie das Prozentzeichen für eine Diagrammbeschriftung festlegen:
```java
// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Holt die Referenz einer Folie über ihren Index
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Erstellt das PercentsStackedColumn-Diagramm auf einer Folie
    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    
    // Setzt NumberFormatLinkedToSource auf false
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    
    chart.getChartData().getSeries().clear();
    int defaultWorksheetIndex = 0;
    
    // Holt das Arbeitsblatt der Diagrammdaten
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    
    // Fügt eine neue Serie hinzu
    IChartSeries series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.30));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.50));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.80));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    
    // Setzt die Füllfarbe der Serie
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Setzt die Eigenschaften des LabelFormats
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Fügt eine neue Serie hinzu
    IChartSeries series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.70));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.50));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.20));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    
    // Setzt den Fülltyp und die Farbe
    series2.getFormat().getFill().setFillType(FillType.Solid);
    series2.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    
    // Schreibt die Präsentation auf die Festplatte
    pres.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Abstände der Beschriftungen** von der Achse

Dieser Java‑Code zeigt, wie Sie den Abstand der Beschriftung von einer Kategorien‑Achse festlegen, wenn Sie ein Diagramm mit Achsen verwenden:
```java
// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Holt die Referenz einer Folie
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Erstellt ein Diagramm auf der Folie
    IChart ch = sld.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    
    // Setzt den Beschriftungsabstand von einer Achse
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    
    // Schreibt die Präsentation auf die Festplatte
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Beschriftungsposition anpassen**

Wenn Sie ein Diagramm erstellen, das keine Achsen verwendet, wie etwa ein Kreis‑Diagramm, können die Datenbeschriftungen zu nahe am Rand liegen. In einem solchen Fall müssen Sie die Position der Beschriftung anpassen, damit die Verbindungslinien deutlich angezeigt werden.

Dieser Java‑Code zeigt, wie Sie die Position der Beschriftung in einem Kreis‑Diagramm anpassen:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);

    IChartSeriesCollection series = chart.getChartData().getSeries();
    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);

    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **FAQ**

**Wie kann ich verhindern, dass Datenbeschriftungen bei dichten Diagrammen überlappen?**

Kombinieren Sie automatische Beschriftungsplatzierung, Verbindungslinien und reduzierte Schriftgröße; falls nötig, blenden Sie einige Felder (z. B. die Kategorie) aus oder zeigen Sie Beschriftungen nur für extreme bzw. wichtige Punkte an.

**Wie kann ich Beschriftungen nur für Null‑, negative‑ oder leere Werte deaktivieren?**

Filtern Sie Datenpunkte, bevor Sie Beschriftungen aktivieren, und schalten Sie die Anzeige für Werte von 0, negative Werte oder fehlende Werte gemäß einer definierten Regel aus.

**Wie kann ich einen einheitlichen Beschriftungsstil beim Exportieren in PDF/Bilder sicherstellen?**

Legen Sie Schriftarten (Familie, Größe) explizit fest und prüfen Sie, dass die Schrift auf der Renderseite verfügbar ist, um ein Zurückgreifen auf Ersatzschriften zu vermeiden.