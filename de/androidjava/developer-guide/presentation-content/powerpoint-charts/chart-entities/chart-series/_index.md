---
title: Diagrammserie
type: docs
url: /de/androidjava/chart-series/
keywords: "Diagrammserie, Serienfarbe, PowerPoint-Präsentation, Java, Aspose.Slides für Android über Java"
description: "Diagrammserien in PowerPoint-Präsentationen in Java"
---

Eine Serie ist eine Reihe oder Spalte von Zahlen, die in einem Diagramm dargestellt werden.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Diagrammserienüberlappung festlegen**

Mit der [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) Eigenschaft können Sie angeben, wie stark Balken und Säulen in einem 2D-Diagramm überlappen sollen (Bereich: -100 bis 100). Diese Eigenschaft gilt für alle Serien der übergeordneten Seriengruppe: dies ist eine Projektion der entsprechenden Gruppen-Eigenschaft. Daher ist diese Eigenschaft schreibgeschützt.

Verwenden Sie die lese- und schreibbare Eigenschaft `ParentSeriesGroup.Overlap`, um Ihren bevorzugten Wert für `Overlap` festzulegen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
1. Fügen Sie ein gruppiertes Säulendiagramm auf einer Folie hinzu.
1. Greifen Sie auf die erste Diagrammserie zu.
1. Greifen Sie auf die `ParentSeriesGroup` der Diagrammserie zu und legen Sie Ihren bevorzugten Überlappungswert für die Serie fest.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Java-Code zeigt, wie Sie die Überlappung für eine Diagrammserie festlegen:

```java
Presentation pres = new Presentation();
try {
    // Füge ein Diagramm hinzu
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Setzt die Serienüberlappung
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // Schreibt die Präsentationsdatei auf die Festplatte
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Serienfarbe ändern**
Aspose.Slides für Android über Java ermöglicht es Ihnen, die Farbe einer Serie auf folgende Weise zu ändern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
1. Fügen Sie das Diagramm auf der Folie hinzu.
1. Greifen Sie auf die Serie zu, deren Farbe Sie ändern möchten. 
1. Legen Sie Ihren bevorzugten Fülltyp und die Füllfarbe fest.
1. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code zeigt, wie Sie die Farbe einer Serie ändern:

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

## **Serienkategoriefarbe ändern**
Aspose.Slides für Android über Java ermöglicht es Ihnen, die Farbe einer Serienkategorie auf folgende Weise zu ändern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
1. Fügen Sie das Diagramm auf der Folie hinzu.
1. Greifen Sie auf die Serienkategorie zu, deren Farbe Sie ändern möchten.
1. Legen Sie Ihren bevorzugten Fülltyp und die Füllfarbe fest.
1. Speichern Sie die modifizierte Präsentation.

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

Standardmäßig sind die Legendenamen für ein Diagramm die Inhalte der Zellen über jeder Spalte oder Zeile der Daten. 

In unserem Beispiel (Beispielbild), 

* die Spalten sind *Serie 1, Serie 2,* und *Serie 3*;
* die Zeilen sind *Kategorie 1, Kategorie 2, Kategorie 3,* und *Kategorie 4.* 

Aspose.Slides für Android über Java ermöglicht es Ihnen, einen Seriennamen in seinen Diagrammdaten und der Legende zu aktualisieren oder zu ändern.

Dieser Java-Code zeigt, wie Sie den Namen einer Serie in den Diagrammdaten `ChartDataWorkbook` ändern:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("Neuer Name");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Dieser Java-Code zeigt, wie Sie den Seriennamen in seiner Legende über `Series` ändern:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("Neuer Name");
} finally {
    if (pres != null) pres.dispose();
}
```

## **Füllfarbe der Diagrammserie festlegen**

Aspose.Slides für Android über Java ermöglicht es Ihnen, die automatische Füllfarbe für Diagrammserien im Plotbereich folgendermaßen festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
1. Erhalten Sie eine Referenz auf eine Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten basierend auf Ihrem bevorzugten Typ hinzu (im folgenden Beispiel haben wir `ChartType.ClusteredColumn` verwendet).
1. Greifen Sie auf die Diagrammserie zu und setzen Sie die Füllfarbe auf Automatisch.
1. Speichern Sie die Präsentation in einer PPTX-Datei.

Dieser Java-Code zeigt, wie Sie die automatische Füllfarbe für eine Diagrammserie festlegen:

```java
Presentation pres = new Presentation();
try {
    // Erstellt ein gruppiertes Säulendiagramm
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Setzt das Serienfüllformat auf automatisch
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

## **Invertierte Füllfarben für die Diagrammserie festlegen**
Aspose.Slides ermöglicht es Ihnen, die invertierte Füllfarbe für Diagrammserien im Plotbereich folgendermaßen festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
1. Erhalten Sie eine Referenz auf eine Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten basierend auf Ihrem bevorzugten Typ hinzu (im folgenden Beispiel haben wir `ChartType.ClusteredColumn` verwendet).
1. Greifen Sie auf die Diagrammserie zu und setzen Sie die Füllfarbe auf invertiert.
1. Speichern Sie die Präsentation in einer PPTX-Datei.

Dieser Java-Code demonstriert den Vorgang:

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Fügt neue Serien und Kategorien hinzu
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Serie 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Kategorie 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Kategorie 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Kategorie 3"));

    // Nimmt die erste Diagrammserie und füllt ihre Seriendaten aus.
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
Aspose.Slides ermöglicht es Ihnen, Inversionen über die `IChartDataPoint.InvertIfNegative` und `ChartDataPoint.InvertIfNegative` Eigenschaften festzulegen. Wenn eine Inversion über die Eigenschaften festgelegt wird, invertiert der Datenpunkt seine Farben, wenn er einen negativen Wert erhält. 

Dieser Java-Code demonstriert den Vorgang:

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

## **Bestimmte Datenpunkte löschen**
Aspose.Slides für Android über Java ermöglicht es Ihnen, die Daten von `DataPoints` für eine bestimmte Diagrammserie auf folgende Weise zu löschen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Erhalten Sie die Referenz einer Folie über ihren Index.
3. Erhalten Sie die Referenz eines Diagramms über seinen Index.
4. Iterieren Sie durch alle Diagramm-`DataPoints` und setzen Sie `XValue` und `YValue` auf null.
5. Löschen Sie alle `DataPoints` für spezifische Diagrammserien.
6. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Java-Code demonstriert den Vorgang:

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

## **Gap Width der Serie festlegen**
Aspose.Slides für Android über Java ermöglicht es Ihnen, die Gap Width einer Serie über die **`GapWidth`** Eigenschaft folgendermaßen festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Greifen Sie auf eine beliebige Diagrammserie zu.
1. Setzen Sie die `GapWidth` Eigenschaft.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Code in Java zeigt, wie Sie die Gap Width einer Serie festlegen:

```java
// Erstellt eine leere Präsentation 
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie der Präsentation zu
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Fügt ein Diagramm mit Standarddaten hinzu
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // Setzt den Index des Diagrammdatenblatts
    int defaultWorksheetIndex = 0;
    
    // Holt das Diagrammdatenarbeitsblatt
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Fügt Serien hinzu
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Serie 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Serie 2"), chart.getType());
    
    // Fügt Kategorien hinzu
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Kategorie 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Kategorie 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Kategorie 3"));
    
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
    
    // Speichert die Präsentation auf der Festplatte
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```