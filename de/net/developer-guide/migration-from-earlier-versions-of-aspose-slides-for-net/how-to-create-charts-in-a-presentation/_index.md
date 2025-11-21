---
title: Wie man Diagramme in Präsentationen in .NET erstellt
linktitle: Diagramm erstellen
type: docs
weight: 30
url: /de/net/how-to-create-charts-in-a-presentation/
keywords:
- Migration
- Diagramm erstellen
- Legacy-Code
- moderner Code
- Legacy-Ansatz
- moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie in .NET mit Aspose.Slides Diagramme in PowerPoint PPT-, PPTX- und ODP-Präsentationen sowohl mit der Legacy- als auch mit der modernen Diagramm-API erstellen."
---

{{% alert color="primary" %}} 

Eine neue [Aspose.Slides for .NET API](/slides/de/net/) wurde veröffentlicht und unterstützt jetzt die Möglichkeit, PowerPoint‑Dokumente von Grund auf zu erzeugen und bestehende zu bearbeiten.

{{% /alert %}} 
## **Unterstützung für Legacy‑Code**
Um den mit älteren Versionen von Aspose.Slides für .NET (vor 13.x) entwickelten Legacy‑Code zu verwenden, müssen Sie einige kleine Änderungen an Ihrem Code vornehmen, damit dieser wie zuvor funktioniert. Alle Klassen, die im alten Aspose.Slides für .NET unter den Namespaces Aspose.Slide und Aspose.Slides.Pptx vorhanden waren, sind nun in einem einzigen Aspose.Slides‑Namespace zusammengeführt. Bitte sehen Sie sich das folgende einfache Code‑Snippet an, das zeigt, wie man ein normales Diagramm von Grund auf in einer Präsentation mit der Legacy‑Aspose.Slides‑API erstellt, und folgen Sie den Schritten, die die Migration zur neuen zusammengeführten API beschreiben.
## **Legacy‑Ansatz von Aspose.Slides für .NET**
```c#
//Instanziiere die PresentationEx-Klasse, die eine PPTX-Datei darstellt
using (PresentationEx pres = new PresentationEx())
{
	//Greife auf die erste Folie zu
	SlideEx sld = pres.Slides[0];

	// Füge ein Diagramm mit Standarddaten hinzu
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//Setze den Diagrammtitel
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//Setze die erste Serie, um Werte anzuzeigen
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//Setze den Index des Diagrammdatenblatts 
	int defaultWorksheetIndex = 0;

	//Hole das Diagrammdaten-Arbeitsblatt
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//Lösche standardmäßig generierte Serien und Kategorien
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//Füge neue Serien hinzu
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	//Füge neue Kategorien hinzu
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	//Nimm die erste Diagrammserie
	ChartSeriesEx series = chart.ChartData.Series[0];

	//Jetzt werden die Seriendaten befüllt
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//Setze die Füllfarbe für die Serie
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//Nimm die zweite Diagrammserie
	series = chart.ChartData.Series[1];

	//Jetzt werden die Seriendaten befüllt
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//Setze die Füllfarbe für die Serie
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//Erstelle benutzerdefinierte Beschriftungen für jede Kategorie der neuen Serie

	//Erste Beschriftung zeigt den Kategorienamen
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//Zeige den Seriennamen für die zweite Beschriftung
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//Zeige den Wert für die dritte Beschriftung
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//Zeige Wert und benutzerdefinierten Text
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "My text";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//Speichere die Präsentation mit dem Diagramm
	pres.Write(@"D:\AsposeChart.pptx");
}
```


## **Neuer Ansatz von Aspose.Slides für .NET 13.x**
``` csharp
//Instanziiere die Presentation-Klasse, die eine PPTX-Datei darstellt//Instanziiere die Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();

//Access first slide
ISlide sld = pres.Slides[0];

// Add chart with default data
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//Setting chart Title
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//Set first series to Show Values
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//Setting the index of chart data sheet
int defaultWorksheetIndex = 0;

//Getting the chart data worksheet
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Delete default generated series and categories
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//Adding new series
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//Adding new categories
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//Take first chart series
IChartSeries series = chart.ChartData.Series[0];

//Now populating series data
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//Setting fill color for series
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//Take second chart series
series = chart.ChartData.Series[1];

//Now populating series data
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Setting fill color for series
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//create custom labels for each of categories for new series
//first label will be show Category name
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//Show value for third label
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//Save presentation with chart
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```


Bitte sehen Sie sich das folgende einfache Code‑Snippet an, das zeigt, wie man ein Streudiagramm von Grund auf in einer Präsentation mit der Legacy‑Aspose.Slides‑API erstellt und wie man dies mit der neuen zusammengeführten API erreicht.

## **Legacy‑Ansatz von Aspose.Slides für .NET**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //Erstellen des Standarddiagramms
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //Abrufen des Index des Standarddatenblatts für das Diagramm
    int defaultWorksheetIndex = 0;

    //Zugriff auf das Diagrammdaten-Arbeitsblatt
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //Demo-Serien löschen
    chart.ChartData.Series.Clear();

    //Neue Serie hinzufügen
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //Erste Diagrammserie übernehmen
    ChartSeriesEx series = chart.ChartData.Series[0];

    //Neuen Punkt (1:3) dort hinzufügen.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //Neuen Punkt (2:10) hinzufügen
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //Typ der Serie bearbeiten
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //Diagrammserien-Marker ändern
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //Zweite Diagrammserie übernehmen
    series = chart.ChartData.Series[1];

    //Neuen Punkt (5:2) dort hinzufügen.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //Neuen Punkt (3:1) hinzufügen
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //Neuen Punkt (2:2) hinzufügen
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //Neuen Punkt (5:1) hinzufügen
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //Diagrammserien-Marker ändern
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```


## **Neuer Ansatz von Aspose.Slides für .NET 13.x**
``` csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//Erstellen des Standarddiagramms
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//Abrufen des Index des Standarddatenblatts für das Diagramm
int defaultWorksheetIndex = 0;

//Zugriff auf das Diagrammdaten-Arbeitsblatt
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Demo-Serien löschen
chart.ChartData.Series.Clear();

//Neue Serien hinzufügen
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//Erste Diagrammserie übernehmen
IChartSeries series = chart.ChartData.Series[0];

//Neuen Punkt (1:3) dort hinzufügen.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//Neuen Punkt (2:10) hinzufügen
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//Typ der Serie bearbeiten
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//Diagrammserien-Marker ändern
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//Zweite Diagrammserie übernehmen
series = chart.ChartData.Series[1];

//Neuen Punkt (5:2) dort hinzufügen.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//Neuen Punkt (3:1) hinzufügen
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//Neuen Punkt (2:2) hinzufügen
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//Neuen Punkt (5:1) hinzufügen
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//Diagrammserien-Marker ändern
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```
