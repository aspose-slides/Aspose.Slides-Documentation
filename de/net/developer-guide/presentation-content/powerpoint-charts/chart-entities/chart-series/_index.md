---
title: Chart-Serie
type: docs
url: /de/net/chart-series/
keywords: "Chart-Serie, Serienfarbe, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Chart-Serien in PowerPoint-Präsentationen in C# oder .NET"
---

Eine Serie ist eine Zeile oder Spalte von Zahlen, die in einem Diagramm dargestellt wird.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Diagrammserienüberlappung festlegen**

Mit der [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) -Eigenschaft können Sie angeben, wie stark Balken und Säulen in einem 2D-Diagramm überlappen sollen (Bereich: -100 bis 100). Diese Eigenschaft gilt für alle Serien der übergeordneten Seriengruppe: Dies ist eine Projektion der entsprechenden Gruppeneigenschaft. Daher ist diese Eigenschaft schreibgeschützt.

Verwenden Sie die `ParentSeriesGroup.Overlap` -Eigenschaft (lese/schreib), um Ihren bevorzugten Wert für `Overlap` festzulegen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) -Klasse.
2. Fügen Sie ein gruppiertes Säulendiagramm auf einer Folie hinzu.
3. Greifen Sie auf die erste Diagrammserie zu.
4. Greifen Sie auf die `ParentSeriesGroup` der Diagrammserie zu und legen Sie Ihren bevorzugten Überlappungswert für die Serie fest.
5. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser C#-Code zeigt Ihnen, wie Sie die Überlappung für eine Diagrammserie festlegen:

```c#
using (Presentation presentation = new Presentation())
{
    // Fügt ein Diagramm hinzu
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.ChartData.Series;
    if (series[0].Overlap == 0)
    {
        // Setzt die Serienüberlappung
        series[0].ParentSeriesGroup.Overlap = -30;
    }

    // Schreibt die Präsentationsdatei auf die Festplatte
    presentation.Save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
}
```

## **Serienfarbe ändern**
Aspose.Slides für .NET ermöglicht es Ihnen, die Farbe einer Serie folgendermaßen zu ändern:

1. Erstellen Sie eine Instanz der `Presentation` -Klasse.
2. Fügen Sie ein Diagramm auf der Folie hinzu.
3. Greifen Sie auf die Serie zu, deren Farbe Sie ändern möchten.
4. Stellen Sie Ihren bevorzugten Fülltyp und Füllfarbe ein.
5. Speichern Sie die modifizierte Präsentation.

Dieser C#-Code zeigt Ihnen, wie Sie die Farbe einer Serie ändern:

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 600, 400);
	IChartDataPoint point = chart.ChartData.Series[0].DataPoints[1];
	
	point.Explosion = 30;
	point.Format.Fill.FillType = FillType.Solid;
	point.Format.Fill.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Farbe der Serienkategorie ändern**
Aspose.Slides für .NET erlaubt es Ihnen, die Farbe einer Serienkategorie folgendermaßen zu ändern:

1. Erstellen Sie eine Instanz der `Presentation` -Klasse.
2. Fügen Sie ein Diagramm auf der Folie hinzu.
3. Greifen Sie auf die Serienkategorie zu, deren Farbe Sie ändern möchten.
4. Stellen Sie Ihren bevorzugten Fülltyp und Füllfarbe ein.
5. Speichern Sie die modifizierte Präsentation.

Dieser C#-Code zeigt Ihnen, wie Sie die Farbe einer Serienkategorie ändern:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartDataPoint point = chart.ChartData.Series[0].DataPoints[0];
	
	point.Format.Fill.FillType = FillType.Solid;
	point.Format.Fill.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Serienname ändern** 

Standardmäßig sind die Legendennamen für ein Diagramm die Inhalte der Zellen über jeder Spalte oder Zeile von Daten. 

In unserem Beispiel (Beispielfoto),

* die Spalten sind *Serie 1, Serie 2,* und *Serie 3*;
* die Zeilen sind *Kategorie 1, Kategorie 2, Kategorie 3,* und *Kategorie 4.* 

Aspose.Slides für .NET ermöglicht es Ihnen, einen Seriennamen in seinen Diagrammdaten und in der Legende zu aktualisieren oder zu ändern. 

Dieser C#-Code zeigt Ihnen, wie Sie einen Seriennamen in seinen Diagrammdaten `ChartDataWorkbook` ändern:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = "Neuer Name";
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

Dieser C#-Code zeigt Ihnen, wie Sie einen Seriennamen in seiner Legende über `Series` ändern:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.ChartData.Series[0];
    
    IStringChartValue name = series.Name;
    name.AsCells[0].Value = "Neuer Name";   
}
```

## **Füllfarbe der Diagrammserie festlegen**

Aspose.Slides für .NET ermöglicht es Ihnen, die automatische Füllfarbe für Diagrammserien innerhalb eines Plotbereichs folgendermaßen festzulegen:

1. Erstellen Sie eine Instanz der `Presentation` -Klasse.
2. Erhalten Sie den Verweis auf eine Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Standarddaten basierend auf Ihrem bevorzugten Typ hinzu (im folgenden Beispiel haben wir `ChartType.ClusteredColumn` verwendet).
4. Greifen Sie auf die Diagrammserie zu und setzen Sie die Füllfarbe auf Automatisch.
5. Speichern Sie die Präsentation in einer PPTX-Datei.

Dieser C#-Code zeigt Ihnen, wie Sie die automatische Füllfarbe für eine Diagrammserie festlegen:

```c#
using (Presentation presentation = new Presentation())
{
    // Erstellt ein gruppiertes Säulendiagramm
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Setzt das Füllformat der Serie auf automatisch
    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series[i].GetAutomaticSeriesColor();
    }

    // Schreibt die Präsentationsdatei auf die Festplatte
    presentation.Save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
}
```

## **Füllfarben der Diagrammserie invertieren**
Aspose.Slides ermöglicht es Ihnen, die invertierte Füllfarbe für Diagrammserien innerhalb eines Plotbereichs folgendermaßen festzulegen:

1. Erstellen Sie eine Instanz der `Presentation` -Klasse.
2. Erhalten Sie den Verweis auf eine Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Standarddaten basierend auf Ihrem bevorzugten Typ hinzu (im folgenden Beispiel haben wir `ChartType.ClusteredColumn` verwendet).
4. Greifen Sie auf die Diagrammserie zu und setzen Sie die Füllfarbe auf invertiert.
5. Speichern Sie die Präsentation in einer PPTX-Datei.

Dieser C#-Code demonstriert die Operation:

```c#
Color inverColor = Color.Red;
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Fügt neue Serien und Kategorien hinzu
    chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Serie 1"), chart.Type);
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Kategorie 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Kategorie 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Kategorie 3"));

    // Nimmt die erste Diagrammserie und füllt deren Serien-Daten.
    IChartSeries series = chart.ChartData.Series[0];
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;
    pres.Save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);               
}
```

## **Die Serie invertieren, wenn der Wert negativ ist**
Aspose.Slides ermöglicht es Ihnen, Invertierungen über die`IChartDataPoint.InvertIfNegative` und `ChartDataPoint.InvertIfNegative` -Eigenschaften festzulegen. Wenn eine Umkehrung mit den Eigenschaften festgelegt wird, invertiert der Datenpunkt seine Farben, wenn er einen negativen Wert erhält.

Dieser C#-Code demonstriert die Operation:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
	IChartSeriesCollection series = chart.ChartData.Series;
	chart.ChartData.Series.Clear();

	series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -2));
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

	series[0].InvertIfNegative = false;

	series[0].DataPoints[2].InvertIfNegative = true;

	pres.Save("out.pptx", SaveFormat.Pptx);
}
```

## **Spezifische Datenpunkte löschen**
Aspose.Slides für .NET ermöglicht es Ihnen, die `DataPoints`-Daten für eine spezifische Diagrammserie folgendermaßen zu löschen:

1. Erstellen Sie eine Instanz der `Presentation` -Klasse.
2. Erhalten Sie den Bezug zu einer Folie über ihren Index.
3. Erhalten Sie den Bezug zu einem Diagramm über seinen Index.
4. Durchlaufen Sie alle Diagramm `DataPoints` und setzen Sie `XValue` und `YValue` auf null.
5. Löschen Sie alle `DataPoints` für spezifische Diagrammserien.
6. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser C#-Code demonstriert die Operation:

```c#
using (Presentation pres = new Presentation("TestChart.pptx"))
{
	ISlide sl = pres.Slides[0];

	IChart chart = (IChart)sl.Shapes[0];

	foreach (IChartDataPoint dataPoint in chart.ChartData.Series[0].DataPoints)
	{
		dataPoint.XValue.AsCell.Value = null;
		dataPoint.YValue.AsCell.Value = null;
	}

	chart.ChartData.Series[0].DataPoints.Clear();

	pres.Save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
}
```

## **Gap-Breite der Serie festlegen**
Aspose.Slides für .NET ermöglicht es Ihnen, die Gap-Breite einer Serie über die **`GapWidth`** -Eigenschaft folgendermaßen festzulegen:

1. Erstellen Sie eine Instanz der `Presentation` -Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu.
4. Greifen Sie auf eine beliebige Diagrammserie zu.
5. Setzen Sie die `GapWidth` -Eigenschaft.
6. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser C#-Code zeigt Ihnen, wie Sie die Gap-Breite einer Serie festlegen:

```c#
// Erstellt eine leere Präsentation 
Presentation presentation = new Presentation();

// Greift auf die erste Folie der Präsentation zu
ISlide slide = presentation.Slides[0];

// Fügt ein Diagramm mit Standarddaten hinzu
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 0, 0, 500, 500);

// Setzt den Index des Diagrammdatensatzes
int defaultWorksheetIndex = 0;

// Erhält das Diagrammdatensatzblatt
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Fügt Serien hinzu
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Serie 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Serie 2"), chart.Type);

// Fügt Kategorien hinzu
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Kategorie 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Kategorie 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Kategorie 3"));

// Nimmt die zweite Diagrammserie
IChartSeries series = chart.ChartData.Series[1];

// Füllt die Serien-Daten
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Setzt den GapWidth-Wert
series.ParentSeriesGroup.GapWidth = 50;

// Speichert die Präsentation auf der Festplatte
presentation.Save("GapWidth_out.pptx", SaveFormat.Pptx);
```