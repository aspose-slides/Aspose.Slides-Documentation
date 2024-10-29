---
title: Diagrammserien
type: docs
url: /de/java/chart-series/
keywords: "Diagrammserien, Serienfarbe, PowerPoint-Präsentation, Java, Aspose.Slides für Java"
description: "Diagrammserien in PowerPoint-Präsentationen in Java"
---

Eine Serie ist eine Reihe oder Spalte von Zahlen, die in einem Diagramm dargestellt werden.

![diagramm-serien-powerpoint](chart-series-powerpoint.png)

## **Diagrammserienüberlappung festlegen**

Mit der [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) Eigenschaft können Sie angeben, wie viel sich Balken und Spalten in einem 2D-Diagramm überlappen sollen (Bereich: -100 bis 100). Diese Eigenschaft gilt für alle Serien der übergeordneten Seriengruppe: dies ist eine Projektion der entsprechenden Gruppeneigenschaft. Daher ist diese Eigenschaft schreibgeschützt.

Verwenden Sie die `ParentSeriesGroup.Overlap` Lese-/Schreib-Eigenschaft, um Ihren bevorzugten Wert für `Overlap` festzulegen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Fügen Sie ein gruppiertes Säulendiagramm auf einer Folie hinzu.
3. Greifen Sie auf die erste Diagrammserie zu.
4. Greifen Sie auf die `ParentSeriesGroup` der Diagrammserie zu und legen Sie Ihren bevorzugten Überlappungswert für die Serie fest.
5. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie die Überlappung für eine Diagrammserie festlegen:

```java
Presentation pres = new Presentation();
try {
    // Fügt ein Diagramm hinzu
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Legt die Überlappung der Serie fest
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // Schreibt die Präsentationsdatei auf die Festplatte
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Serienfarbe ändern**
Aspose.Slides für Java ermöglicht es Ihnen, die Farbe einer Serie wie folgt zu ändern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Fügen Sie ein Diagramm auf der Folie hinzu.
3. Greifen Sie auf die Serie zu, deren Farbe Sie ändern möchten.
4. Legen Sie Ihren bevorzugten Fülltyp und die Füllfarbe fest.
5. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie die Farbe einer Serie ändern:

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
Aspose.Slides für Java ermöglicht es Ihnen, die Farbe einer Serienkategorie wie folgt zu ändern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Fügen Sie ein Diagramm auf der Folie hinzu.
3. Greifen Sie auf die Serienkategorie zu, deren Farbe Sie ändern möchten.
4. Legen Sie Ihren bevorzugten Fülltyp und die Füllfarbe fest.
5. Speichern Sie die modifizierte Präsentation.

Dieser Code in Java zeigt Ihnen, wie Sie die Farbe einer Serienkategorie ändern:

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

## **Namen der Serie ändern**

Standardmäßig sind die Legendenamen für ein Diagramm die Inhalte der Zellen über jeder Spalte oder Zeile von Daten.

In unserem Beispiel (Beispielbild),

* die Spalten sind *Serie 1, Serie 2,* und *Serie 3*;
* die Zeilen sind *Kategorie 1, Kategorie 2, Kategorie 3,* und *Kategorie 4.* 

Aspose.Slides für Java ermöglicht es Ihnen, einen Seriennamen in den Diagrammdaten und der Legende zu aktualisieren oder zu ändern.

Dieser Java-Code zeigt Ihnen, wie Sie den Namen einer Serie in ihren Diagrammdaten `ChartDataWorkbook` ändern:

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

Dieser Java-Code zeigt Ihnen, wie Sie den Namen einer Serie in ihrer Legende über `Series` ändern:

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

Aspose.Slides für Java ermöglicht es Ihnen, die automatische Füllfarbe für Diagrammserien innerhalb eines Diagrammbereichs wie folgt festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Erhalten Sie eine Referenz auf die Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Standarddaten basierend auf Ihrem bevorzugten Typ hinzu (im folgenden Beispiel haben wir `ChartType.ClusteredColumn` verwendet).
4. Greifen Sie auf die Diagrammserie zu und setzen Sie die Füllfarbe auf Automatisch.
5. Speichern Sie die Präsentation in einer PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie die automatische Füllfarbe für eine Diagrammserie festlegen:

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

## **Füllfarben der Diagrammserie umkehren**
Aspose.Slides ermöglicht es Ihnen, die umgekehrte Füllfarbe für Diagrammserien innerhalb eines Diagrammbereichs wie folgt festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Erhalten Sie eine Referenz auf die Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Standarddaten basierend auf Ihrem bevorzugten Typ hinzu (im folgenden Beispiel haben wir `ChartType.ClusteredColumn` verwendet).
4. Greifen Sie auf die Diagrammserie zu und setzen Sie die Füllfarbe auf invertiert.
5. Speichern Sie die Präsentation in einer PPTX-Datei.

Dieser Java-Code demonstriert die Operation:

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

    // Nimmt die erste Diagrammserie und füllt deren Seriendaten aus.
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

## **Serie umkehren, wenn der Wert negativ ist**
Aspose.Slides ermöglicht es Ihnen, Umkehrungen über die Eigenschaften `IChartDataPoint.InvertIfNegative` und `ChartDataPoint.InvertIfNegative` festzulegen. Wenn eine Umkehrung über die Eigenschaften festgelegt wird, kehrt der Datenpunkt seine Farben um, wenn er einen negativen Wert erhält.

Dieser Java-Code demonstriert die Operation:

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

## **Datenpunkte einer bestimmten Serie leeren**
Aspose.Slides für Java ermöglicht es Ihnen, die `DataPoints` Daten für eine bestimmte Diagrammserie wie folgt zu leeren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Erhalten Sie die Referenz auf eine Folie über ihren Index.
3. Erhalten Sie die Referenz auf ein Diagramm über seinen Index.
4. Iterieren Sie über alle Diagramm `DataPoints` und setzen Sie `XValue` und `YValue` auf null.
5. Leeren Sie alle `DataPoints` für bestimmte Diagrammserien.
6. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Java-Code demonstriert die Operation:

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

## **Lückenbreite der Serie festlegen**
Aspose.Slides für Java ermöglicht es Ihnen, die Lückenbreite einer Serie über die **`GapWidth`** Eigenschaft wie folgt festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu.
4. Greifen Sie auf eine beliebige Diagrammserie zu.
5. Setzen Sie die `GapWidth`-Eigenschaft.
6. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Code in Java zeigt Ihnen, wie Sie die Lückenbreite einer Serie festlegen:

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
    
    // Ruft das Diagrammdatenblatt ab
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
    
    // Füllt die Seriendaten aus
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Setzt den Wert von GapWidth
    series.getParentSeriesGroup().setGapWidth(50);
    
    // Speichert die Präsentation auf der Festplatte
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```