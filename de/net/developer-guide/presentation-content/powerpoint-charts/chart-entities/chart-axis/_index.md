---
title: Diagrammachsen in Präsentationen in .NET anpassen
linktitle: Diagrammachse
type: docs
url: /de/net/chart-axis/
keywords:
- Diagrammachse
- Vertikale Achse
- Horizontale Achse
- Achse anpassen
- Achse manipulieren
- Achse verwalten
- Achseneigenschaften
- Maximalwert
- Minimalwert
- Achsenlinie
- Datumsformat
- Achsentitel
- Achsenposition
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aspose.Slides für .NET verwenden, um Diagrammachsen in PowerPoint-Präsentationen für Berichte und Visualisierungen anzupassen."
---

## **Ermitteln Sie die Maximalwerte auf der vertikalen Achse in Diagrammen**
Aspose.Slides für .NET ermöglicht das Abrufen der minimalen und maximalen Werte auf einer vertikalen Achse. Befolgen Sie diese Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu.
4. Ermitteln Sie den tatsächlichen Maximalwert auf der Achse.
5. Ermitteln Sie den tatsächlichen Minimalwert auf der Achse.
6. Ermitteln Sie die tatsächliche Haupteinheit der Achse.
7. Ermitteln Sie die tatsächliche Nebeneinheit der Achse.
8. Ermitteln Sie die tatsächliche Skala der Haupteinheit der Achse.
9. Ermitteln Sie die tatsächliche Skala der Nebeneinheit der Achse.

Dieses Beispielcode—eine Umsetzung der oben genannten Schritte—zeigt Ihnen, wie Sie die erforderlichen Werte in C# erhalten:
```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// Speichert die Präsentation
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```


## **Daten zwischen Achsen austauschen**
Aspose.Slides ermöglicht das schnelle Austauschen der Daten zwischen Achsen—die auf der vertikalen Achse (y-Achse) dargestellten Daten werden auf die horizontale Achse (x-Achse) und umgekehrt verschoben. 

Dieser C#‑Code zeigt Ihnen, wie Sie die Daten zwischen Achsen in einem Diagramm austauschen:
```c#
// Erstellt eine leere Präsentation
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//Vertauscht Zeilen und Spalten
	chart.ChartData.SwitchRowColumn();
		   
	 // Speichert die Präsentation
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```


## **Vertikale Achse für Liniendiagramme deaktivieren**

Dieser C#‑Code zeigt Ihnen, wie Sie die vertikale Achse in einem Liniendiagramm ausblenden:
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```


## **Horizontale Achse für Liniendiagramme deaktivieren**

Dieser Code zeigt Ihnen, wie Sie die horizontale Achse in einem Liniendiagramm ausblenden:
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```


## **Kategorienachse ändern**

Mit der Eigenschaft **CategoryAxisType** können Sie den gewünschten Kategorienachsentyp (**date** oder **text**) festlegen. Dieser C#‑Code demonstriert den Vorgang: 
```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes[0] as IChart;
    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;
    presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
}
```


## **Datumsformat für Kategorienachswerte festlegen**
Aspose.Slides für .NET ermöglicht das Festlegen des Datumsformats für einen Kategorienachswert. Der Vorgang wird in diesem C#‑Code demonstriert:
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Area, 50, 50, 450, 300);

	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	wb.Clear(0);

	chart.ChartData.Categories.Clear();
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Add(wb.GetCell(0, "A2", new DateTime(2015, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A3", new DateTime(2016, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A4", new DateTime(2017, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A5", new DateTime(2018, 1, 1).ToOADate()));

	IChartSeries series = chart.ChartData.Series.Add(ChartType.Line);
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B2", 1));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B3", 2));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B4", 3));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B5", 4));
	chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
	chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
	chart.Axes.HorizontalAxis.NumberFormat = "yyyy";
	pres.Save("test.pptx", SaveFormat.Pptx);
}
```


## **Drehwinkel für einen Diagrammachsentitel festlegen**
Aspose.Slides für .NET ermöglicht das Festlegen des Drehwinkels für einen Diagrammachsentitel. Dieser C#‑Code demonstriert den Vorgang:
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```


## **Achsenposition für eine Kategorien- oder Werteachse festlegen**
Aspose.Slides für .NET ermöglicht das Festlegen der Achsenposition in einer Kategorien‑ oder Werteachse. Dieser C#‑Code zeigt, wie die Aufgabe ausgeführt wird:
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```


## **Anzeigeeinheiten‑Beschriftung auf der Diagrammwertachse aktivieren**
Aspose.Slides für .NET ermöglicht die Konfiguration eines Diagramms, um eine Einheit‑Beschriftung auf seiner Diagrammwertachse anzuzeigen. Dieser C#‑Code demonstriert den Vorgang:
```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Wie lege ich den Wert fest, an dem eine Achse die andere schneidet (Achsenschnitt)?**

Achsen bieten eine [Kreuzungseinstellung](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/): Sie können wählen, bei Null, beim maximalen Kategorie-/Wert oder bei einem bestimmten numerischen Wert zu kreuzen. Dies ist nützlich, um die X‑Achse nach oben oder unten zu verschieben oder eine Basislinie zu betonen.

**Wie kann ich die Tick‑Beschriftungen relativ zur Achse positionieren (neben, außen, innen)?**

Setzen Sie die [Beschriftungsposition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) auf "cross", "outside" oder "inside". Dies beeinflusst die Lesbarkeit und hilft, insbesondere bei kleinen Diagrammen Platz zu sparen.