---
title: Diagrammdatenserien in Präsentationen mit Java verwalten
linktitle: Datenserien
type: docs
url: /de/java/chart-series/
keywords:
- Diagrammserien
- Serienüberlappung
- Serienfarbe
- Kategoriefarbe
- Serienname
- Datenpunkt
- Serienabstand
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammserien in Java für PowerPoint (PPT/PPTX) verwalten, mit praktischen Codebeispielen und bewährten Methoden, um Ihre Datenpräsentationen zu verbessern."
---

Eine Serie ist eine Zeile oder Spalte von Zahlen, die in einem Diagramm dargestellt werden.

![Diagramm-Serie-Powerpoint](chart-series-powerpoint.png)

## **Diagrammserien-Überlappung festlegen**

Mit der [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) Eigenschaft können Sie festlegen, wie stark Balken und Säulen in einem 2D‑Diagramm überlappen sollen (Bereich: -100 bis 100). Diese Eigenschaft gilt für alle Serien der übergeordneten Seriengruppe: Sie ist eine Projektion der entsprechenden Gruppeneigenschaft. Daher ist diese Eigenschaft schreibgeschützt. 

Verwenden Sie die Lese‑/Schreib‑Eigenschaft `ParentSeriesGroup.Overlap`, um Ihren gewünschten Wert für `Overlap` festzulegen. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.  
1. Fügen Sie einem Folie ein gruppiertes Säulendiagramm hinzu.  
1. Greifen Sie auf die erste Diagrammserie zu.  
1. Greifen Sie auf die `ParentSeriesGroup` der Diagrammserie zu und setzen Sie den gewünschten Überlappungswert für die Serie.  
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.  

Dieser Java‑Code zeigt, wie Sie die Überlappung für eine Diagrammserie festlegen:
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

Aspose.Slides for Java ermöglicht das Ändern der Farbe einer Serie wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.  
1. Fügen Sie ein Diagramm zur Folie hinzu.  
1. Greifen Sie auf die Serie zu, deren Farbe Sie ändern möchten.  
1. Legen Sie den gewünschten Fülltyp und die Füllfarbe fest.  
1. Speichern Sie die geänderte Präsentation.  

Dieser Java‑Code zeigt, wie Sie die Farbe einer Serie ändern:
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

Aspose.Slides for Java ermöglicht das Ändern der Farbe einer Serienkategorie wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.  
1. Fügen Sie ein Diagramm zur Folie hinzu.  
1. Greifen Sie auf die Serienkategorie zu, deren Farbe Sie ändern möchten.  
1. Legen Sie den gewünschten Fülltyp und die Füllfarbe fest.  
1. Speichern Sie die geänderte Präsentation.  

Dieser Code in Java zeigt, wie Sie die Farbe einer Serienkategorie ändern:
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


## **Serienname ändern** 

Standardmäßig werden die Legendenbezeichnungen für ein Diagramm aus den Zellen über jeder Spalte oder Zeile der Daten übernommen. 

In unserem Beispiel (Beispielbild),

* die Spalten sind *Series 1, Series 2,* und *Series 3*;  
* die Zeilen sind *Category 1, Category 2, Category 3,* und *Category 4.*  

Aspose.Slides for Java ermöglicht das Aktualisieren oder Ändern des Seriennamens in den Diagrammdaten und in der Legende. 

Dieser Java‑Code zeigt, wie man den Seriennamen in den Diagrammdaten `ChartDataWorkbook` ändert:
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


Dieser Java‑Code zeigt, wie man den Seriennamen in der Legende über `Series` ändert:
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


## **Füllfarbe für Diagrammserie festlegen**

Aspose.Slides for Java ermöglicht das Festlegen der automatischen Füllfarbe für Diagrammserien im Plot‑Bereich wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.  
1. Holen Sie sich die Referenz einer Folie über ihren Index.  
1. Fügen Sie ein Diagramm mit Standarddaten basierend auf Ihrem gewünschten Typ hinzu (im Beispiel unten haben wir `ChartType.ClusteredColumn` verwendet).  
1. Greifen Sie auf die Diagrammserie zu und setzen Sie die Füllfarbe auf Automatisch.  
1. Speichern Sie die Präsentation in einer PPTX‑Datei.  

Dieser Java‑Code zeigt, wie Sie die automatische Füllfarbe für eine Diagrammserie festlegen:
```java
Presentation pres = new Presentation();
try {
    // Erstellt ein gruppiertes Säulendiagramm
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Setzt das Füllformat der Serien auf automatisch
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


## **Umgekehrte Füllfarben für Diagrammserie festlegen**

Aspose.Slides ermöglicht das Festlegen der umgekehrten Füllfarbe für Diagrammserien im Plot‑Bereich wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.  
1. Holen Sie sich die Referenz einer Folie über ihren Index.  
1. Fügen Sie ein Diagramm mit Standarddaten basierend auf Ihrem gewünschten Typ hinzu (im Beispiel unten haben wir `ChartType.ClusteredColumn` verwendet).  
1. Greifen Sie auf die Diagrammserie zu und setzen Sie die Füllfarbe auf umkehren.  
1. Speichern Sie die Präsentation in einer PPTX‑Datei.  

Dieser Java‑Code demonstriert die Operation:
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


## **Serie invertieren, wenn Wert negativ ist**

Aspose.Slides ermöglicht das Setzen von Invertierungen über die `IChartDataPoint.InvertIfNegative`‑ und `ChartDataPoint.InvertIfNegative`‑Eigenschaften. Wenn eine Invertierung über diese Eigenschaften gesetzt wird, invertiert der Datenpunkt seine Farben, sobald er einen negativen Wert erhält. 

Dieser Java‑Code demonstriert die Operation:
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


## **Daten bestimmter Datenpunkte löschen**

Aspose.Slides for Java ermöglicht das Löschen der `DataPoints`‑Daten für eine bestimmte Diagrammserie wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.  
2. Holen Sie die Referenz einer Folie über ihren Index.  
3. Holen Sie die Referenz eines Diagramms über seinen Index.  
4. Durchlaufen Sie alle Diagramm‑`DataPoints` und setzen Sie `XValue` und `YValue` auf null.  
5. Löschen Sie alle `DataPoints` für die spezifische Diagrammserie.  
6. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.  

Dieser Java‑Code demonstriert die Operation:
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


## **Serienlückenbreite festlegen**

Aspose.Slides for Java ermöglicht das Festlegen der Lückenbreite einer Serie über die **`GapWidth`**‑Eigenschaft wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.  
1. Greifen Sie auf die erste Folie zu.  
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.  
1. Greifen Sie auf eine beliebige Diagrammserie zu.  
1. Setzen Sie die `GapWidth`‑Eigenschaft.  
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.  

Dieser Code in Java zeigt, wie Sie die Lückenbreite einer Serie festlegen:
```java
// Erstellt leere Präsentation 
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie der Präsentation zu
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Fügt ein Diagramm mit Standarddaten hinzu
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // Legt den Index des Diagrammdatenblatts fest
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
    
    // Befüllt die Seriendaten
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Setzt den GapWidth-Wert
    series.getParentSeriesGroup().setGapWidth(50);
    
    // Speichert die Präsentation auf der Festplatte
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Gibt es ein Limit, wie viele Serien ein einzelnes Diagramm enthalten kann?**

Aspose.Slides imposiert keine feste Obergrenze für die Anzahl der Serien, die Sie hinzufügen. Die praktische Grenze wird durch die Lesbarkeit des Diagramms und den verfügbaren Speicher Ihrer Anwendung bestimmt.

**Was ist, wenn die Spalten innerhalb eines Clusters zu eng beieinander liegen oder zu weit auseinander?**

Passen Sie die `GapWidth`‑Einstellung für diese Serie (oder ihre übergeordnete Seriengruppe) an. Durch Erhöhen des Wertes vergrößern Sie den Abstand zwischen den Spalten, durch Verringern des Wertes bringen Sie sie näher zusammen.