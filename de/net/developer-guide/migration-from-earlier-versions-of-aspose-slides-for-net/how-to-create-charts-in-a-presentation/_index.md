---
title: Wie man Diagramme in einer Präsentation erstellt
type: docs
weight: 30
url: /de/net/how-to-create-charts-in-a-presentation/
---

{{% alert color="primary" %}} 

Eine neue [Aspose.Slides für .NET API](/slides/de/net/) wurde veröffentlicht und unterstützt jetzt diese einzelne Produktfunktion, PowerPoint-Dokumente von Grund auf neu zu erstellen und vorhandene zu bearbeiten.

{{% /alert %}} 
## **Unterstützung für Legacy-Code**
Um den Legacy-Code zu verwenden, der mit Aspose.Slides für .NET-Versionen vor 13.x entwickelt wurde, müssen Sie einige kleinere Änderungen an Ihrem Code vornehmen, damit der Code wie früher funktioniert. Alle Klassen, die in der alten Aspose.Slides für .NET unter den Namespaces Aspose.Slide und Aspose.Slides.Pptx vorhanden waren, sind jetzt im einzelnen Aspose.Slides-Namespace zusammengeführt. Bitte werfen Sie einen Blick auf das folgende einfache Codeschnipsel, um ein normales Diagramm von Grund auf in einer Präsentation mit der alten Aspose.Slides API zu erstellen, und folgen Sie den Schritten, die beschreiben, wie man zur neuen zusammengeführten API migriert.
## **Legacy Aspose.Slides für .NET-Ansatz**
```c#
//Instanziierung der PresentationEx-Klasse, die die PPTX-Datei darstellt
using (PresentationEx pres = new PresentationEx())
{
	//Zugriff auf die erste Folie
	SlideEx sld = pres.Slides[0];

	// Diagramm mit Standarddaten hinzufügen
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//Diagrammtitel einstellen
	chart.ChartTitle.Text.Text = "Beispieltitel";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//Erste Serie auf Werte anzeigen
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//Index des Diagrammdatenblatts festlegen 
	int defaultWorksheetIndex = 0;

	//Das Diagrammdatenarbeitsblatt abrufen
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//Standardmäßig generierte Serien und Kategorien löschen
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//Neue Serien hinzufügen
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Serie 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Serie 2"), chart.Type);

	//Neue Kategorien hinzufügen
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Kategorie 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Kategorie 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Kategorie 3"));

	//Erste Diagrammserie auswählen
	ChartSeriesEx series = chart.ChartData.Series[0];

	//Jetzt die Seriendaten füllen
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//Füllfarbe für Serie festlegen
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//Zweite Diagrammserie auswählen
	series = chart.ChartData.Series[1];

	//Jetzt die Seriendaten füllen
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//Füllfarbe für Serie festlegen
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//Benutzerdefinierte Etiketten für jede Kategorie der neuen Serie erstellen

	//erste Etikette zeigt den Kategorienamen
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//Markieren des Seriennamens für die zweite Etikette
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//Wert für dritte Etikette anzeigen
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//Wert und benutzerdefinierten Text anzeigen
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "Mein Text";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//Präsentation mit Diagramm speichern
	pres.Write(@"D:\AsposeChart.pptx");
}
```



## **Neuer Ansatz von Aspose.Slides für .NET 13.x**
``` csharp
//Instanziierung der Presentation-Klasse, die die PPTX-Datei darstellt
Presentation pres = new Presentation();

//Zugriff auf die erste Folie
ISlide sld = pres.Slides[0];

//Diagramm mit Standarddaten hinzufügen
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//Diagrammtitel einstellen
//chart.ChartTitle.TextFrameForOverriding.Text = "Beispieltitel";
chart.ChartTitle.AddTextFrameForOverriding("Beispieltitel");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//Erste Serie auf Werte anzeigen
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//Index des Diagrammdatenblatts festlegen
int defaultWorksheetIndex = 0;

//Das Diagrammdatenarbeitsblatt abrufen
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Standardmäßig generierte Serien und Kategorien löschen
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//Neue Serien hinzufügen
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Serie 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Serie 2"), chart.Type);

//Neue Kategorien hinzufügen
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Kategorie 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Kategorie 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Kategorie 3"));

//Erste Diagrammserie auswählen
IChartSeries series = chart.ChartData.Series[0];

//Jetzt die Seriendaten füllen

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//Füllfarbe für Serie festlegen
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//Zweite Diagrammserie auswählen
series = chart.ChartData.Series[1];

//Jetzt die Seriendaten füllen
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Füllfarbe für Serie festlegen
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//Benutzerdefinierte Etiketten für jede Kategorie der neuen Serie erstellen

//erste Etikette zeigt den Kategorienamen
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//Wert für dritte Etikette anzeigen
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//Präsentation mit Diagramm speichern
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Bitte werfen Sie einen Blick auf das folgende einfache Codeschnipsel, um ein Streudiagramm von Grund auf in einer Präsentation mit der alten Aspose.Slides API zu erstellen und wie man es mit der neuen zusammengeführten API erreichen kann.

## **Legacy Aspose.Slides für .NET-Ansatz**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //Erstellen des Standarddiagramms
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //Erhalten des Standarddiagrammdatenarbeitsblattindex
    int defaultWorksheetIndex = 0;

    //Zugriff auf das Diagrammdatenarbeitsblatt
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //Demo-Serie löschen
    chart.ChartData.Series.Clear();

    //Neue Serien hinzufügen
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Serie 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Serie 2"), chart.Type);

    //Erste Diagrammserie auswählen
    ChartSeriesEx series = chart.ChartData.Series[0];

    //Neuen Punkt (1:3) hinzufügen.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //Neuen Punkt (2:10) hinzufügen
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //Typ der Serie bearbeiten
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //Marker des Diagrammserien ändern
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //Zweite Diagrammserie auswählen
    series = chart.ChartData.Series[1];

    //Neuen Punkt (5:2) hinzufügen.
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

    //Marker des Diagrammserien ändern
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

//Erhalten des Standarddiagrammdatenarbeitsblattindex
int defaultWorksheetIndex = 0;

//Zugriff auf das Diagrammdatenarbeitsblatt
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Demo-Serie löschen
chart.ChartData.Series.Clear();

//Neue Serien hinzufügen
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Serie 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Serie 2"), chart.Type);

//Erste Diagrammserie auswählen
IChartSeries series = chart.ChartData.Series[0];

//Neuen Punkt (1:3) hinzufügen.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//Neuen Punkt (2:10) hinzufügen
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//Typ der Serie bearbeiten
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//Marker des Diagrammserien ändern
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyle.Type.Star;

//Zweite Diagrammserie auswählen
series = chart.ChartData.Series[1];

//Neuen Punkt (5:2) hinzufügen.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//Neuen Punkt (3:1) hinzufügen
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//Neuen Punkt (2:2) hinzufügen
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//Neuen Punkt (5:1) hinzufügen
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//Marker des Diagrammserien ändern
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyle.Type.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```