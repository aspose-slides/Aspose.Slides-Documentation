---
title: Diagrammachse
type: docs
url: /de/net/chart-axis/
keywords: "PowerPoint-Diagrammachse, Präsentationsdiagramme, C#, .NET, Diagrammachse manipulieren, Diagrammdaten"
description: "PowerPoint-Diagrammachse in C# oder .NET bearbeiten"
---

## **Ermitteln der Maximalwerte auf der vertikalen Achse in Diagrammen**
Aspose.Slides für .NET ermöglicht das Abrufen der Minimal‑ und Maximalwerte einer vertikalen Achse. Folgen Sie diesen Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Klasse.  
2. Greifen Sie auf die erste Folie zu.  
3. Fügen Sie ein Diagramm mit Standarddaten hinzu.  
4. Ermitteln Sie den tatsächlichen Maximalwert der Achse.  
5. Ermitteln Sie den tatsächlichen Minimalwert der Achse.  
6. Ermitteln Sie die tatsächliche Hauptintervallgröße der Achse.  
7. Ermitteln Sie die tatsächliche Nebenintervallgröße der Achse.  
8. Ermitteln Sie die tatsächliche Skala des Hauptintervalls der Achse.  
9. Ermitteln Sie die tatsächliche Skala des Nebenintervalls der Achse.  

Dieser Beispielcode – eine Umsetzung der oben genannten Schritte – zeigt, wie Sie die erforderlichen Werte in C# erhalten:
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


## **Austauschen der Daten zwischen Achsen**
Aspose.Slides ermöglicht das schnelle Vertauschen von Daten zwischen Achsen – die auf der vertikalen Achse (y‑Achse) dargestellten Daten werden zur horizontalen Achse (x‑Achse) verschoben und umgekehrt.  

Dieser C#‑Code zeigt, wie Sie den Datentausch zwischen Achsen in einem Diagramm durchführen:
```c#
 // Erstellt leere Präsentation
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// Vertauscht Zeilen und Spalten
	chart.ChartData.SwitchRowColumn();
		   
	// Speichert die Präsentation
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```


## **Deaktivieren der vertikalen Achse für Liniendiagramme**

Dieser C#‑Code zeigt, wie Sie die vertikale Achse eines Liniendiagramms ausblenden:
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```


## **Deaktivieren der horizontalen Achse für Liniendiagramme**

Dieser Code zeigt, wie Sie die horizontale Achse eines Liniendiagramms ausblenden:
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```


## **Ändern der Kategorienachse**

Mit der Eigenschaft **CategoryAxisType** können Sie den bevorzugten Typ der Kategorienachse festlegen (**date** oder **text**). Dieser C#‑Code demonstriert die Vorgehensweise: 
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


## **Festlegen des Datumsformats für den Wert einer Kategorienachse**
Aspose.Slides für .NET ermöglicht das Festlegen des Datumsformats für einen Kategorienachsenwert. Der Vorgang wird in diesem C#‑Code demonstriert:
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


## **Festlegen des Rotationswinkels für den Diagrammachsentitel**
Aspose.Slides für .NET ermöglicht das Festlegen des Rotationswinkels für einen Diagrammachsentitel. Dieser C#‑Code demonstriert den Vorgang:
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```


## **Festlegen der Position der Achse in einer Kategorien- oder Wertachse**
Aspose.Slides für .NET ermöglicht das Festlegen der Position der Achse in einer Kategorien‑ oder Wertachse. Dieser C#‑Code zeigt, wie die Aufgabe ausgeführt wird:
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```


## **Aktivieren der Anzeige der Einheit in der Diagrammwertachse**
Aspose.Slides für .NET ermöglicht das Konfigurieren eines Diagramms, um ein Einheitsetikett in seiner Diagrammwertachse anzuzeigen. Dieser C#‑Code demonstriert den Vorgang:
```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Wie lege ich den Wert fest, an dem eine Achse die andere schneidet (Achsenkreuzung)?**

Achsen bieten eine [crossing setting](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/): Sie können wählen, ob die Achse bei Null, beim maximalen Kategorie‑/Wertbereich oder bei einem bestimmten numerischen Wert kreuzt. Das ist nützlich, um die X‑Achse nach oben oder unten zu verschieben oder eine Basislinie zu betonen.

**Wie positioniere ich die Tick‑Beschriftungen relativ zur Achse (nebeneinander, außen, innen)?**

Stellen Sie die [label position](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) auf „cross“, „outside“ oder „inside“. Das beeinflusst die Lesbarkeit und hilft, Platz zu sparen, insbesondere bei kleinen Diagrammen.