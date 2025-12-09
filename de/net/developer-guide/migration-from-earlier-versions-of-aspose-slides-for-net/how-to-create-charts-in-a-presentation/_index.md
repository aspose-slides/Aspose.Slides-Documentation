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
- Moderner Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramme in PowerPoint PPT, PPTX und ODP Präsentationen in .NET mit Aspose.Slides sowohl mit der Legacy- als auch mit der modernen Diagramm-API erstellen."
---

{{% alert color="primary" %}} 

Eine neue [Aspose.Slides for .NET API](/slides/de/net/) wurde veröffentlicht und dieses einzelne Produkt unterstützt nun die Möglichkeit, PowerPoint-Dokumente von Grund auf zu erstellen und vorhandene zu bearbeiten.

{{% /alert %}} 
## **Unterstützung für Legacy-Code**
Um den mit Aspose.Slides für .NET vor Version 13.x entwickelten Legacy-Code zu verwenden, müssen Sie einige kleine Änderungen an Ihrem Code vornehmen, und der Code funktioniert wie zuvor. Alle Klassen, die im alten Aspose.Slides für .NET unter den Namespaces Aspose.Slide und Aspose.Slides.Pptx vorhanden waren, sind jetzt in einem einzigen Aspose.Slides-Namespace zusammengeführt. Bitte sehen Sie sich das folgende einfache Code-Snippet an, das zeigt, wie man ein normales Diagramm von Grund auf in einer Präsentation mit der Legacy-Aspose.Slides-API erstellt, und folgen Sie den Schritten, die beschreiben, wie man zur neuen zusammengeführten API migriert.
## **Legacy Aspose.Slides für .NET Ansatz**
```c#
//Instanziieren Sie die PresentationEx-Klasse, die eine PPTX-Datei darstellt
using (PresentationEx pres = new PresentationEx())
{
	//Zugriff auf die erste Folie
	SlideEx sld = pres.Slides[0];

	// Diagramm mit Standarddaten hinzufügen
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//Diagrammtitel festlegen
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//Erste Serie auf Werte anzeigen setzen
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//Index des Diagrammdatenblatts festlegen 
	int defaultWorksheetIndex = 0;

	//Abrufen des Diagrammdaten-Arbeitsblatts
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//Standardmäßig generierte Serien und Kategorien löschen
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//Neue Serie hinzufügen
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	//Neue Kategorien hinzufügen
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	//Erste Diagrammserie übernehmen
	ChartSeriesEx series = chart.ChartData.Series[0];

	//Jetzt werden die Seriendaten befüllt
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//Füllfarbe für Serie festlegen
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//Zweite Diagrammserie übernehmen
	series = chart.ChartData.Series[1];

	//Jetzt werden die Seriendaten befüllt
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//Füllfarbe für Serie festlegen
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//eigene Beschriftungen für jede Kategorie der neuen Serie erstellen

	//Erste Beschriftung zeigt den Kategorienamen
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//Serienname für zweite Beschriftung anzeigen
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//Wert für dritte Beschriftung anzeigen
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//Wert und benutzerdefinierten Text anzeigen
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "My text";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//Präsentation mit Diagramm speichern
	pres.Write(@"D:\AsposeChart.pptx");
}
```




## **Neuer Aspose.Slides für .NET 13.x Ansatz**
``` csharp
//Instanziieren Sie die Presentation‑Klasse, die eine PPTX‑Datei darstellt//Instanziieren Sie die Presentation‑Klasse, die eine PPTX‑Datei darstellt
Presentation pres = new Presentation();

//Zugriff auf die erste Folie
ISlide sld = pres.Slides[0];

// Diagramm mit Standarddaten hinzufügen
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//Diagrammtitel festlegen
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//Erste Serie auf Werte anzeigen setzen
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//Index des Diagrammdatenblatts festlegen
int defaultWorksheetIndex = 0;

//Abrufen des Diagrammdaten‑Arbeitsblatts
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Standardmäßig generierte Serien und Kategorien löschen
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//Neue Serie hinzufügen
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//Neue Kategorien hinzufügen
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//Erste Diagrammserie übernehmen
IChartSeries series = chart.ChartData.Series[0];

//Jetzt werden die Seriendaten befüllt
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//Füllfarbe für Serie festlegen
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//Zweite Diagrammserie übernehmen
series = chart.ChartData.Series[1];

//Jetzt werden die Seriendaten befüllt
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Füllfarbe für Serie festlegen
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//Benutzerdefinierte Beschriftungen für jede Kategorie der neuen Serie erstellen

//Erste Beschriftung zeigt den Kategorienamen
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//Wert für dritte Beschriftung anzeigen
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//Präsentation mit Diagramm speichern
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```


Bitte sehen Sie sich das folgende einfache Code-Snippet an, das zeigt, wie man ein Streudiagramm von Grund auf in einer Präsentation mit der Legacy-Aspose.Slides-API erstellt und wie man dies mit der neuen zusammengeführten API erreicht.

## **Legacy Aspose.Slides für .NET Ansatz**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //Erstellen des Standarddiagramms
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //Abrufen des Index des Standard-Diagrammdaten-Arbeitsblatts
    int defaultWorksheetIndex = 0;

    //Zugriff auf das Diagrammdaten-Arbeitsblatt
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //Demo-Serien löschen
    chart.ChartData.Series.Clear();

    //Neue Serien hinzufügen
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



## **Neuer Aspose.Slides für .NET 13.x Ansatz**
``` csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//Erstellen des Standarddiagramms
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//Abrufen des Index des Standard-Diagrammdaten-Arbeitsblatts
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
