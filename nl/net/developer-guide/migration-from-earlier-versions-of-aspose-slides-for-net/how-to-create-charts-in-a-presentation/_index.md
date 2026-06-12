---
title: Hoe grafieken te maken in presentaties in .NET
linktitle: Grafiek maken
type: docs
weight: 30
url: /nl/net/how-to-create-charts-in-a-presentation/
keywords:
- migratie
- grafiek maken
- legacycode
- moderne code
- legacybenadering
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u grafieken kunt maken in PowerPoint PPT, PPTX en ODP-presentaties in .NET met Aspose.Slides, met zowel de legacy- als de moderne grafiek-API's."
---
{{% alert color="primary" %}} 

Een nieuwe [Aspose.Slides for .NET API](/slides/nl/net/) is uitgebracht en dit enige product ondersteunt nu de mogelijkheid om PowerPoint‑documenten vanaf nul te genereren en bestaande te bewerken.

{{% /alert %}} 
## **Ondersteuning voor Legacy‑code**
Om de legacy‑code te gebruiken die is ontwikkeld met Aspose.Slides for .NET‑versies ouder dan 13.x, moet je enkele kleine aanpassingen in je code doen; daarna werkt de code weer zoals voorheen. Alle klassen die voorheen aanwezig waren in de oude Aspose.Slides for .NET‑bibliotheek onder de namespaces Aspose.Slide en Aspose.Slides.Pptx, zijn nu samengevoegd in één enkele Aspose.Slides‑namespace. Bekijk het volgende eenvoudige codefragment voor het maken van een normale grafiek vanaf nul in een presentatie met de legacy Aspose.Slides‑API en volg de stappen die uitleggen hoe je migreert naar de nieuwe samengevoegde API.
## **Legacy Aspose.Slides for .NET Approach**
```c#
//Instantieer de PresentationEx-klasse die een PPTX‑bestand voorstelt
using (PresentationEx pres = new PresentationEx())
{
	//Verkrijg de eerste dia
	SlideEx sld = pres.Slides[0];

	// Voeg een grafiek toe met standaardgegevens
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//Instellen van de grafiektitel
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//Stel de eerste serie in om waarden weer te geven
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//Instellen van de index van het gegevensblad van de grafiek 
	int defaultWorksheetIndex = 0;

	//Ophalen van het werkblad met grafiekgegevens
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//Verwijder standaard gegenereerde series en categorieën
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//Nieuwe series toevoegen
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	//Nieuwe categorieën toevoegen
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	//Neem de eerste grafiekserie
	ChartSeriesEx series = chart.ChartData.Series[0];

	//Vul nu de seriedata in
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//Instellen van de opvulkleur voor de serie
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//Neem de tweede grafiekserie
	series = chart.ChartData.Series[1];

	//Vul nu de seriedata in
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//Instellen van de opvulkleur voor de serie
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//Maak aangepaste labels voor elke categorie voor de nieuwe series

	//Eerste label toont de categorienaam
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//Toon de serienaam voor het tweede label
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//Toon waarde voor het derde label
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//Toon waarde en aangepaste tekst
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "My text";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//Sla de presentatie op met de grafiek
	pres.Write(@"D:\AsposeChart.pptx");
}
```



## **New Aspose.Slides for .NET 13.x Approach**
``` csharp
//Instantieer de Presentation‑klasse die een PPTX‑bestand voorstelt//Instantieer de Presentation‑klasse die een PPTX‑bestand voorstelt
Presentation pres = new Presentation();

//Verkrijg de eerste dia
ISlide sld = pres.Slides[0];

// Voeg een grafiek toe met standaardgegevens
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//Instellen van de grafiektitel
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//Stel de eerste serie in om waarden weer te geven
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//Instellen van de index van het gegevensblad van de grafiek
int defaultWorksheetIndex = 0;

//Getting the chart data worksheet
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Verwijder standaard gegenereerde series en categorieën
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//Nieuwe series toevoegen
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//Nieuwe categorieën toevoegen
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//Neem de eerste grafiekserie
IChartSeries series = chart.ChartData.Series[0];

//Vul nu de seriedata in

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//Instellen van de opvulkleur voor de serie
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//Neem de tweede grafiekserie
series = chart.ChartData.Series[1];

//Vul nu de seriedata in
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Instellen van de opvulkleur voor de serie
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//Maak aangepaste labels voor elke categorie voor de nieuwe series

//Het eerste label toont de categorienaam
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//Toon waarde voor het derde label
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//Sla de presentatie op met de grafiek
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Bekijk het volgende eenvoudige codefragment voor het maken van een spreidingsgrafiek vanaf nul in een presentatie met de legacy Aspose.Slides‑API en hoe dit te realiseren met de nieuwe samengevoegde API.

## **Legacy Aspose.Slides for .NET Approach**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //Maak de standaardgrafiek
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //Ophalen van de index van het standaardgegevensblad van de grafiek
    int defaultWorksheetIndex = 0;

    //Toegang tot het gegevensblad van de grafiek
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //Verwijder demo‑series
    chart.ChartData.Series.Clear();

    //Nieuwe series toevoegen
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //Neem de eerste grafiekserie
    ChartSeriesEx series = chart.ChartData.Series[0];

    //Voeg nieuw punt (1:3) toe.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //Voeg nieuw punt (2:10) toe.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //Bewerk het type van de serie
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //Wijzigen van de marker van de grafiekserie
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //Neem de tweede grafiekserie
    series = chart.ChartData.Series[1];

    //Voeg nieuw punt (5:2) toe.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //Voeg nieuw punt (3:1) toe.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //Voeg nieuw punt (2:2) toe.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //Voeg nieuw punt (5:1) toe.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //Wijzigen van de marker van de grafiekserie
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```


## **New Aspose.Slides for .NET 13.x Approach**
``` csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//Aanmaken van de standaardgrafiek
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//Ophalen van de index van het standaardgegevensblad van de grafiek
int defaultWorksheetIndex = 0;

//Toegang tot het gegevensblad van de grafiek
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Verwijder demo‑series
chart.ChartData.Series.Clear();

//Nieuwe series toevoegen
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//Neem de eerste grafiekserie
IChartSeries series = chart.ChartData.Series[0];

//Voeg nieuw punt (1:3) toe.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//Voeg nieuw punt (2:10) toe.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//Bewerk het type van de serie
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//Wijzigen van de marker van de grafiekserie
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//Neem de tweede grafiekserie
series = chart.ChartData.Series[1];

//Voeg nieuw punt (5:2) toe.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//Voeg nieuw punt (3:1) toe.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//Voeg nieuw punt (2:2) toe.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//Voeg nieuw punt (5:1) toe.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//Wijzigen van de marker van de grafiekserie
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```