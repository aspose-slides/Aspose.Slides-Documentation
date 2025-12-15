---
title: Diagrammdatenserien in Präsentationen auf Android verwalten
linktitle: Datenserien
type: docs
url: /de/androidjava/chart-series/
keywords:
- Diagrammserie
- Serienüberlappung
- Serienfarbe
- Kategoriefarbe
- Serienname
- Datenpunkt
- Serienlücke
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammserien auf Android für PowerPoint (PPT/PPTX) verwalten können, mit praktischen Java-Codebeispielen und bewährten Methoden, um Ihre Datenpräsentationen zu verbessern."
---

Eine Serie ist eine Zeile oder Spalte von Zahlen, die in einem Diagramm dargestellt wird.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Setzen Sie die Überlappung der Diagrammserien**

Mit der [IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--)‑Methode können Sie bestimmen, wie stark Balken und Säulen in einem 2D‑Diagramm überlappen sollen (Bereich: -100 bis 100). Diese Eigenschaft gilt für alle Serien der übergeordneten Seriengruppe: Sie ist eine Projektion der entsprechenden Gruppeneigenschaft. Daher ist diese Eigenschaft schreibgeschützt.

Verwenden Sie die Schreib‑Methode `getParentSeriesGroup().setOverlap()`, um Ihren gewünschten Überlappungswert festzulegen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse.  
2. Fügen Sie einer Folie ein gruppiertes Säulendiagramm hinzu.  
3. Greifen Sie auf die erste Diagrammserie zu.  
4. Greifen Sie auf die `ParentSeriesGroup` der Diagrammserie zu und setzen Sie Ihren gewünschten Überlappungswert für die Serie.  
5. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Dieser Java‑Code zeigt Ihnen, wie Sie die Überlappung für eine Diagrammserie festlegen:
```java
Presentation pres = new Presentation();
try {
    // Fügt Diagramm hinzu
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Setzt Serienüberlappung
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // Schreibt die Präsentationsdatei auf die Festplatte
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Serienfarbe ändern**

Aspose.Slides für Android über Java ermöglicht das Ändern der Farbe einer Serie wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse.  
2. Fügen Sie der Folie ein Diagramm hinzu.  
3. Greifen Sie auf die Serie zu, deren Farbe Sie ändern möchten.  
4. Legen Sie Ihren gewünschten Fülltyp und Ihre gewünschte Füllfarbe fest.  
5. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code zeigt Ihnen, wie Sie die Farbe einer Serie ändern:
```java
Presentation pres = new Presentation("test.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);

    point.setExplosion(30);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Farbe der Serienkategorie ändern**

Aspose.Slides für Android über Java ermöglicht das Ändern der Farbe einer Serienkategorie wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse.  
2. Fügen Sie der Folie ein Diagramm hinzu.  
3. Greifen Sie auf die Serienkategorie zu, deren Farbe Sie ändern möchten.  
4. Legen Sie Ihren gewünschten Fülltyp und Ihre gewünschte Füllfarbe fest.  
5. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code zeigt Ihnen, wie Sie die Farbe einer Serienkategorie ändern:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);

    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Seriennamen ändern** 

Standardmäßig entsprechen die Legenden­namen eines Diagramms den Inhalten der Zellen über jeder Spalte oder Zeile der Daten.

In unserem Beispiel (Beispielbild) gilt:

* die Spalten sind *Series 1, Series 2,* und *Series 3*;  
* die Zeilen sind *Category 1, Category 2, Category 3,* und *Category 4*.

Aspose.Slides für Android über Java ermöglicht das Aktualisieren oder Ändern eines Seriennamens in den Diagrammdaten und in der Legende.

Dieser Java‑Code zeigt, wie Sie den Namen einer Serie in den Diagrammdaten `ChartDataWorkbook` ändern:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Dieser Java‑Code zeigt, wie Sie den Namen einer Serie in der Legende über `Series` ändern:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) pres.dispose();
}
```


## **Füllfarbe der Diagrammserie festlegen**

Aspose.Slides für Android über Java ermöglicht das Festlegen der automatischen Füllfarbe für Diagrammserien im Plot‑Bereich wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse.  
2. Holen Sie sich die Referenz einer Folie über deren Index.  
3. Fügen Sie ein Diagramm mit Standarddaten basierend auf Ihrem gewünschten Typ hinzu (im Beispiel unten verwenden wir `ChartType.ClusteredColumn`).  
4. Greifen Sie auf die Diagrammserie zu und setzen Sie die Füllfarbe auf Automatic.  
5. Speichern Sie die Präsentation in einer PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie die automatische Füllfarbe für eine Diagrammserie festlegen:
```java
Presentation pres = new Presentation();
try {
    // Erstellt ein gruppiertes Säulendiagramm
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Setzt das Füllformat der Serie auf automatisch
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // Schreibt die Präsentationsdatei auf die Festplatte
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Invertierte Füllfarbe für eine Diagrammserie festlegen**

Aspose.Slides ermöglicht das Festlegen der invertierten Füllfarbe für Diagrammserien im Plot‑Bereich wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse.  
2. Holen Sie sich die Referenz einer Folie über deren Index.  
3. Fügen Sie ein Diagramm mit Standarddaten basierend auf Ihrem gewünschten Typ hinzu (im Beispiel unten verwenden wir `ChartType.ClusteredColumn`).  
4. Greifen Sie auf die Diagrammserie zu und setzen Sie die Füllfarbe auf invert.  
5. Speichern Sie die Präsentation in einer PPTX‑Datei.

Dieser Java‑Code demonstriert den Vorgang:
```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Fügt neue Serien und Kategorien hinzu
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // Nimmt die erste Diagrammserie und füllt deren Seriendaten.
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    Color seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    
    pres.save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Serie invertieren, wenn der Wert negativ ist**

Aspose.Slides ermöglicht das Invertieren über die Eigenschaften `IChartDataPoint.InvertIfNegative` und `ChartDataPoint.InvertIfNegative`. Wenn ein Invertieren über diese Eigenschaften gesetzt wird, invertiert der Datenpunkt seine Farben, sobald er einen negativen Wert erhält.

Dieser Java‑Code demonstriert den Vorgang:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();

    IChartSeries chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));

    chartSeries.setInvertIfNegative(false);

    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);

    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Spezifische Punktdaten löschen**

Aspose.Slides für Android über Java ermöglicht das Löschen der `DataPoints`‑Daten für eine bestimmte Diagrammserie wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse.  
2. Holen Sie sich die Referenz einer Folie über deren Index.  
3. Holen Sie sich die Referenz eines Diagramms über dessen Index.  
4. Durchlaufen Sie alle `DataPoints` des Diagramms und setzen Sie `XValue` und `YValue` auf null.  
5. Löschen Sie alle `DataPoints` für die gewünschte Diagrammserie.  
6. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Dieser Java‑Code demonstriert den Vorgang:
```java
Presentation pres = new Presentation("TestChart.pptx");
try {
    ISlide sl = pres.getSlides().get_Item(0);

    IChart chart = (IChart)sl.getShapes().get_Item(0);

    for (IChartDataPoint dataPoint : chart.getChartData().getSeries().get_Item(0).getDataPoints())
    {
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }

    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Serien‑Lückenbreite festlegen**

Aspose.Slides für Android über Java ermöglicht das Festlegen der Lückenbreite einer Serie über die **`GapWidth`**‑Eigenschaft wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse.  
2. Greifen Sie auf die erste Folie zu.  
3. Fügen Sie ein Diagramm mit Standarddaten hinzu.  
4. Greifen Sie auf eine beliebige Diagrammserie zu.  
5. Setzen Sie die Eigenschaft `GapWidth`.  
6. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie die Lückenbreite einer Serie festlegen:
```java
// Erstellt eine leere Präsentation 
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie der Präsentation zu
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Fügt ein Diagramm mit Standarddaten hinzu
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // Setzt den Index des Diagramm-Datenblatts
    int defaultWorksheetIndex = 0;
    
    // Holt das Diagrammdaten-Arbeitsblatt
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Fügt Serien hinzu
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Fügt Kategorien hinzu
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Nimmt die zweite Diagrammserie
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Füllt die Seriendaten
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Setzt den GapWidth-Wert
    series.getParentSeriesGroup().setGapWidth(50);
    
    // Speichert die Präsentation auf die Festplatte
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Gibt es eine Obergrenze für die Anzahl der Serien in einem einzelnen Diagramm?**

Aspose.Slides setzt keine feste Obergrenze für die Anzahl der hinzugefügten Serien. Die praktische Grenze wird durch die Lesbarkeit des Diagramms und den verfügbaren Speicher Ihrer Anwendung bestimmt.

**Was tun, wenn die Säulen innerhalb eines Clusters zu eng beieinander oder zu weit auseinander liegen?**

Passen Sie die Einstellung `GapWidth` für diese Serie (oder ihre übergeordnete Seriengruppe) an. Ein höherer Wert vergrößert den Abstand zwischen den Säulen, ein niedrigerer Wert verringert ihn.