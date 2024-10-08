---
title: Kreisdiagramm
type: docs
url: /de/net/pie-chart/
keywords: "Kreisdiagramm, Plot-Optionen, Segmentfarben, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Plot-Optionen und Segmentfarben für Kreisdiagramme in PowerPoint-Präsentationen in C# oder .NET"
---

## **Zweite Plot-Optionen für Kreisdiagramm und Balkendiagramm**
Aspose.Slides für .NET unterstützt nun zweite Plot-Optionen für Kreisdiagramme und Balkendiagramme. In diesem Thema werden wir anhand eines Beispiels sehen, wie man diese Optionen mit Aspose.Slides festlegt. Bitte folgen Sie den nachstehenden Schritten, um die Eigenschaften anzugeben:

1. Instanziieren Sie das [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klassenobjekt.
1. Fügen Sie ein Diagramm zur Folie hinzu.
1. Geben Sie die zweiten Plot-Optionen des Diagramms an.
1. Schreiben Sie die Präsentation auf die Festplatte.

Im folgenden Beispiel haben wir verschiedene Eigenschaften des Kreisdiagramms festgelegt.

```c#
// Erstellen Sie eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation();

// Fügen Sie ein Diagramm zur Folie hinzu
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// Verschiedene Eigenschaften festlegen
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// Schreiben Sie die Präsentation auf die Festplatte
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```




## **Automatische Segmentfarben für das Kreisdiagramm festlegen**
Aspose.Slides für .NET bietet eine einfache API zum Festlegen automatischer Segmentfarben für das Kreisdiagramm. Der Beispielcode wendet die oben genannten Eigenschaften an.

1. Erstellen Sie eine Instanz der Presentation-Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit den Standarddaten hinzu.
1. Setzen Sie den Diagramm-Titel.
1. Setzen Sie die erste Serie auf "Werte anzeigen".
1. Setzen Sie den Index des Diagrammdatenblatts.
1. Holen Sie sich das Diagramm-Datenarbeitsblatt.
1. Löschen Sie die standardmäßig generierten Serien und Kategorien.
1. Fügen Sie neue Kategorien hinzu.
1. Fügen Sie neue Serien hinzu.

Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

```c#
// Instanziieren Sie die Presentation-Klasse, die die PPTX-Datei darstellt
using (Presentation presentation = new Presentation())
{
	// Instanziieren Sie die Presentation-Klasse, die die PPTX-Datei darstellt
	Presentation presentation = new Presentation();

	// Greifen Sie auf die erste Folie zu
	ISlide slides = presentation.Slides[0];

	// Fügen Sie ein Diagramm mit den Standarddaten hinzu
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// Setzen Sie den Diagramm-Titel
	chart.ChartTitle.AddTextFrameForOverriding("Beispieltitel");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// Setzen Sie die erste Serie auf "Werte anzeigen"
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// Setzen Sie den Index des Diagrammdatenblatts
	int defaultWorksheetIndex = 0;

	// Holen Sie sich das Diagramm-Datenarbeitsblatt
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// Löschen Sie die standardmäßig generierten Serien und Kategorien
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// Hinzufügen neuer Kategorien
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "1. Quartal"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2. Quartal"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3. Quartal"));

	// Hinzufügen neuer Serien
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Serie 1"), chart.Type);

	// Jetzt die Daten der Serie befüllen
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```