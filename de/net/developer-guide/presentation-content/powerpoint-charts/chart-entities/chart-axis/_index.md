---
title: Diagrammachse
type: docs
url: /net/chart-axis/
keywords: "PowerPoint Diagrammachse, Präsentationsdiagramme, C#, .NET, Diagrammachse manipulieren, Diagrammdaten"
description: "Bearbeiten der PowerPoint-Diagrammachse in C# oder .NET"
---


## **Maximale Werte auf der vertikalen Achse von Diagrammen erhalten**
Aspose.Slides für .NET ermöglicht es Ihnen, die minimalen und maximalen Werte auf einer vertikalen Achse zu erhalten. Gehen Sie die folgenden Schritte durch:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Holen Sie sich den tatsächlichen Maximalwert auf der Achse.
1. Holen Sie sich den tatsächlichen Minimalwert auf der Achse.
1. Holen Sie sich die tatsächliche Hauptgröße der Achse.
1. Holen Sie sich die tatsächliche Nebenheit der Achse.
1. Holen Sie sich den tatsächlichen Hauptmaßstab der Achse.
1. Holen Sie sich den tatsächlichen Nebenmaßstab der Achse.

Dieser Beispielcode—eine Implementierung der obigen Schritte—zeigt, wie Sie die erforderlichen Werte in C# erhalten:

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
Aspose.Slides ermöglicht es Ihnen, die Daten zwischen Achsen schnell auszutauschen—die auf der vertikalen Achse (y-Achse) dargestellten Daten wechseln zur horizontalen Achse (x-Achse) und umgekehrt.

Dieser C#-Code zeigt Ihnen, wie Sie die Daten austauschen können:

```c#
// Erzeugt eine leere Präsentation
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// Wechselt zwischen Zeilen und Spalten
	chart.ChartData.SwitchRowColumn();
		   
	// Speichert die Präsentation
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```

## **Vertikale Achse für Liniendiagramme deaktivieren**

Dieser C#-Code zeigt, wie Sie die vertikale Achse für ein Liniendiagramm ausblenden:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Horizontale Achse für Liniendiagramme deaktivieren**

Dieser Code zeigt, wie Sie die horizontale Achse für ein Liniendiagramm ausblenden:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Ändern der Kategoriewerte**
Mit der **CategoryAxisType**-Eigenschaft können Sie Ihren bevorzugten Kategorieachsentyp (**Datum** oder **Text**) angeben. Dieser C#-Code demonstriert die Operation:

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

## **Festlegen des Datumsformats für Kategoriewerte**
Aspose.Slides für .NET ermöglicht Ihnen, das Datumsformat für einen Kategoriewert festzulegen. Die Operation wird in diesem C#-Code demonstriert:

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

## **Festlegen des Drehwinkels für die Achsentitel von Diagrammen**
Aspose.Slides für .NET ermöglicht Ihnen das Festlegen des Drehwinkels für einen Diagrammachsentitel. Dieser C#-Code demonstriert die Operation:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **Festlegen der Positionsachse in einer Kategorie- oder Wertachse**
Aspose.Slides für .NET ermöglicht Ihnen das Festlegen der Positionsachse in einer Kategorie- oder Wertachse. Dieser C#-Code zeigt, wie Sie die Aufgabe ausführen:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```

## **Aktivieren der Anzeigeeinheit für die Werteachse des Diagramms**
Aspose.Slides für .NET ermöglicht es Ihnen, ein Diagramm so zu konfigurieren, dass es ein Einheitsetikett auf seiner Werteachse anzeigt. Dieser C#-Code demonstriert die Operation:

```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```