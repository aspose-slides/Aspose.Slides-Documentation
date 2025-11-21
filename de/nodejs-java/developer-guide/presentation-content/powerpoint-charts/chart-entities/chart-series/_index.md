---
title: Diagrammserien
type: docs
url: /de/nodejs-java/chart-series/
keywords: "Diagrammserien, Serienfarbe, PowerPoint-Präsentation, Java, Aspose.Slides für Node.js via Java"
description: "Diagrammserien in PowerPoint-Präsentationen in JavaScript"
---

Eine Serie ist eine Zeile oder Spalte von Zahlen, die in einem Diagramm dargestellt wird.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Diagrammserien-Überlappung festlegen**

Mit der [ChartSeries.getOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) Methode können Sie festlegen, wie stark Balken und Säulen in einem 2D-Diagramm überlappen sollen (Bereich: -100 bis 100). Diese Eigenschaft gilt für alle Serien der übergeordneten Seriengruppe: Sie ist eine Projektion der entsprechenden Gruppeneigenschaft. Daher ist diese Eigenschaft schreibgeschützt.

Verwenden Sie die Lese/Schreib-Eigenschaft `ParentSeriesGroup.getOverlap`, um Ihren gewünschten Wert für `Overlap` festzulegen. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.  
1. Fügen Sie einem Folienlayout ein gruppiertes Säulendiagramm hinzu.  
1. Greifen Sie auf die erste Diagrammserie zu.  
1. Greifen Sie auf die `ParentSeriesGroup` der Diagrammserie zu und setzen Sie Ihren gewünschten Überlappungswert für die Serie.  
1. Schreiben Sie die geänderte Präsentation in eine PPTX-Datei.  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Fügt Diagramm hinzu
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0) {
        // Setzt die Serienüberlappung
        series.get_Item(0).getParentSeriesGroup().setOverlap(-30);
    }
    // Schreibt die Präsentationsdatei auf die Festplatte
    pres.save("SetChartSeriesOverlap_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Serienfarbe ändern**

Aspose.Slides für Node.js via Java ermöglicht es Ihnen, die Farbe einer Serie wie folgt zu ändern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.  
1. Fügen Sie ein Diagramm zur Folie hinzu.  
1. Greifen Sie auf die Serie zu, deren Farbe Sie ändern möchten.  
1. Legen Sie Ihren gewünschten Fülltyp und die Füllfarbe fest.  
1. Speichern Sie die geänderte Präsentation.  

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);
    point.setExplosion(30);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Farbe der Serienkategorie ändern**

Aspose.Slides für Node.js via Java ermöglicht es Ihnen, die Farbe einer Serienkategorie wie folgt zu ändern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.  
1. Fügen Sie ein Diagramm zur Folie hinzu.  
1. Greifen Sie auf die Serienkategorie zu, deren Farbe Sie ändern möchten.  
1. Legen Sie Ihren gewünschten Fülltyp und die Füllfarbe fest.  
1. Speichern Sie die geänderte Präsentation.  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Serienname ändern** 

Standardmäßig sind die Legendenbeschriftungen eines Diagramms die Inhalte der Zellen über jeder Spalte oder Zeile der Daten. 

In unserem Beispiel (Beispielbild), 

* die Spalten sind *Series 1, Series 2,* und *Series 3*;  
* die Zeilen sind *Category 1, Category 2, Category 3,* und *Category 4.*  

Aspose.Slides für Node.js via Java ermöglicht es Ihnen, einen Seriennamen in den Diagrammdaten und der Legende zu aktualisieren oder zu ändern.

Dieser JavaScript-Code zeigt, wie Sie den Namen einer Serie in den Diagrammdaten `ChartDataWorkbook` ändern:  
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Dieser JavaScript-Code zeigt, wie Sie den Namen einer Serie in ihrer Legende über `Series` ändern:  
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries().get_Item(0);
    var name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Füllfarbe für Diagrammserie festlegen**

Aspose.Slides für Node.js via Java ermöglicht es Ihnen, die automatische Füllfarbe für Diagrammserien im Diagrammbereich wie folgt festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.  
1. Holen Sie sich den Verweis auf eine Folie über deren Index.  
1. Fügen Sie ein Diagramm mit Standarddaten basierend auf Ihrem gewünschten Typ hinzu (im Beispiel unten verwenden wir `ChartType.ClusteredColumn`).  
1. Greifen Sie auf die Diagrammserie zu und setzen Sie die Füllfarbe auf Automatisch.  
1. Speichern Sie die Präsentation in einer PPTX-Datei.  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Erzeugt ein gruppiertes Säulendiagramm
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 50, 600, 400);
    // Setzt das Füllformat der Serien auf automatisch
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }
    // Schreibt die Präsentationsdatei auf die Festplatte
    pres.save("AutoFillSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Invertierte Füllfarben für Diagrammserie festlegen**

Aspose.Slides ermöglicht es Ihnen, die invertierten Füllfarben für Diagrammserien im Diagrammbereich wie folgt festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.  
1. Holen Sie sich den Verweis auf eine Folie über deren Index.  
1. Fügen Sie ein Diagramm mit Standarddaten basierend auf Ihrem gewünschten Typ hinzu (im Beispiel unten verwenden wir `ChartType.ClusteredColumn`).  
1. Greifen Sie auf die Diagrammserie zu und setzen Sie die Füllfarbe auf Invertiert.  
1. Speichern Sie die Präsentation in einer PPTX-Datei.  

```javascript
var inverColor = java.getStaticFieldValue("java.awt.Color", "RED");
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Fügt neue Serien und Kategorien hinzu
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));
    // Nimmt die erste Diagrammserie und füllt deren Seriendaten.
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    var seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    pres.save("SetInvertFillColorChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Serie invertieren, wenn Wert negativ ist**

Aspose.Slides ermöglicht es Ihnen, Invertierungen über die `ChartDataPoint.setInvertIfNegative`‑Methode festzulegen. Wenn eine Invertierung über die Eigenschaften gesetzt wird, invertiert der Datenpunkt seine Farben, sobald er einen negativen Wert erhält. 

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();
    var chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));
    chartSeries.setInvertIfNegative(false);
    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Daten bestimmter Datenpunkte löschen**

Aspose.Slides für Node.js via Java ermöglicht es Ihnen, die `DataPoints`‑Daten einer bestimmten Diagrammserie wie folgt zu löschen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.  
2. Holen Sie sich den Verweis auf eine Folie über deren Index.  
3. Holen Sie sich den Verweis auf ein Diagramm über dessen Index.  
4. Iterieren Sie über alle Diagramm-`DataPoints` und setzen Sie `XValue` und `YValue` auf null.  
5. Löschen Sie alle`DataPoints` für die spezifische Diagrammserie.  
6. Schreiben Sie die geänderte Präsentation in eine PPTX-Datei.  

```javascript
var pres = new aspose.slides.Presentation("TestChart.pptx");
try {
    var sl = pres.getSlides().get_Item(0);
    var chart = sl.getShapes().get_Item(0);
    for (let i = 0; i < chart.getChartData().getSeries().get_Item(0).getDataPoints().size(); i++) {
        let dataPoint = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(i);
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }
    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();
    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Lückenbreite der Serie festlegen**

Aspose.Slides für Node.js via Java ermöglicht es Ihnen, die Lückenbreite einer Serie über die **`GapWidth`**‑Eigenschaft wie folgt festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.  
1. Greifen Sie auf die erste Folie zu.  
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.  
1. Greifen Sie auf irgendeine Diagrammserie zu.  
1. Setzen Sie die Eigenschaft `GapWidth`.  
1. Schreiben Sie die geänderte Präsentation in eine PPTX-Datei.  

```javascript
// Erstellt leere Präsentation
var pres = new aspose.slides.Presentation();
try {
    // Greift auf die erste Folie der Präsentation zu
    var slide = pres.getSlides().get_Item(0);
    // Fügt ein Diagramm mit Standarddaten hinzu
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 0, 0, 500, 500);
    // Setzt den Index des Diagrammdatenblatts
    var defaultWorksheetIndex = 0;
    // Holt das Diagrammdaten-Arbeitsblatt
    var fact = chart.getChartData().getChartDataWorkbook();
    // Fügt Serien hinzu
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Fügt Kategorien hinzu
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Nimmt die zweite Diagrammserie
    var series = chart.getChartData().getSeries().get_Item(1);
    // Befüllt die Seriendaten
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Setzt den GapWidth-Wert
    series.getParentSeriesGroup().setGapWidth(50);
    // Speichert die Präsentation auf die Festplatte
    pres.save("GapWidth_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Gibt es ein Limit, wie viele Serien ein einzelnes Diagramm enthalten kann?**

Aspose.Slides setzt keine feste Obergrenze für die Anzahl der hinzuzufügenden Serien. Die praktische Grenze wird durch die Lesbarkeit des Diagramms und den verfügbaren Speicher Ihrer Anwendung bestimmt.

**Was ist, wenn die Säulen innerhalb eines Clusters zu dicht beieinander oder zu weit auseinander liegen?**

Passen Sie die Lückenbreite‑Einstellung für diese Serie (oder deren übergeordnete Seriengruppe) an. Durch Erhöhen des Wertes vergrößern Sie den Abstand zwischen den Säulen, durch Verringern bringen Sie sie näher zusammen.