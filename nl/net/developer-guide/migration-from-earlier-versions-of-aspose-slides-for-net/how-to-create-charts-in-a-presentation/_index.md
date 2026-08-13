---
title: Hoe diagrammen maken in presentaties in .NET
linktitle: Diagram maken
type: docs
weight: 30
url: /nl/net/how-to-create-charts-in-a-presentation/
keywords:
- migratie
- diagram maken
- legacy code
- moderne code
- legacy‑aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u diagrammen maakt in PowerPoint PPT, PPTX en ODP presentaties in .NET met Aspose.Slides, zowel met de legacy als de moderne diagram‑API's."
---
{{% alert color="info" %}} 

Er is een nieuwe [Aspose.Slides for .NET API](/slides/nl/net/) uitgebracht en nu ondersteunt dit enkele product de mogelijkheid om PowerPoint‑documenten vanaf nul te genereren en bestaande documenten te bewerken.

{{% /alert %}} 
## **Ondersteuning voor legacy‑code**
Om de legacy‑code te gebruiken die is ontwikkeld met Aspose.Slides voor .NET‑versies vóór 13.x, moet u enkele kleine aanpassingen in uw code doen zodat deze weer werkt zoals voorheen. Alle klassen die aanwezig waren in de oude Aspose.Slides voor .NET onder de namespaces Aspose.Slide en Aspose.Slides.Pptx zijn nu samengevoegd in één enkele Aspose.Slides‑namespace. Bekijk het onderstaande eenvoudige codefragment voor het maken van een standaardgrafiek vanaf nul in een presentatie met de legacy Aspose.Slides‑API en volg de stappen die beschrijven hoe u migreert naar de nieuwe samengevoegde API.
## **Legacy Aspose.Slides for .NET‑aanpak**
```c#
using System.Drawing;

//Instantie van de PresentationEx-klasse die een PPTX-bestand vertegenwoordigt
using (PresentationEx pres = new PresentationEx())
{
	//Toegang tot de eerste dia
	SlideEx sld = pres.Slides[0];

	// Grafiek toevoegen met standaardgegevens
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//Instellen van grafiektitel
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//Eerste serie instellen om waarden weer te geven
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//Instellen van de index van het gegevensblad van de grafiek 
	int defaultWorksheetIndex = 0;

	//Ophalen van het gegevenswerkblad van de grafiek
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//Standaard gegenereerde reeksen en categorieën verwijderen
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

	//Nu de gegevens van de serie vullen
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//Vulkleur voor serie instellen
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//Neem de tweede grafiekserie
	series = chart.ChartData.Series[1];

	//Nu de gegevens van de serie vullen
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//Vulkleur voor serie instellen
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//Aangepaste labels maken voor elke categorie voor de nieuwe serie

	//Eerste label toont de categorienaam
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//Toon serienaam voor het tweede label
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

	//Presentatie met grafiek opslaan
	pres.Write(@"D:\AsposeChart.pptx");
}
```



## **Nieuwe Aspose.Slides for .NET 13.x‑aanpak**
``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

//Instantie van de Presentation-klasse die een PPTX-bestand vertegenwoordigt//Instantie van de Presentation-klasse die een PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation();

//Toegang tot de eerste dia
ISlide sld = pres.Slides[0];

// Grafiek toevoegen met standaardgegevens
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//Instellen van grafiektitel
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//Instellen van de index van het gegevensblad van de grafiek
int defaultWorksheetIndex = 0;

//Ophalen van het gegevenswerkblad van de grafiek
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Standaard gegenereerde reeksen en categorieën verwijderen
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//Nieuwe series toevoegen
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//Eerste serie instellen om waarden weer te geven
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//Nieuwe categorieën toevoegen
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//Neem de eerste grafiekserie
IChartSeries series = chart.ChartData.Series[0];

//Nu de gegevens van de serie vullen

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//Vulkleur voor serie instellen
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//Neem de tweede grafiekserie
series = chart.ChartData.Series[1];

//Nu de gegevens van de serie vullen
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Vulkleur voor serie instellen
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//Aangepaste labels maken voor elke categorie voor de nieuwe serie

//Eerste label toont de categorienaam
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//Toon waarde voor het derde label
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//Presentatie met grafiek opslaan
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Bekijk het onderstaande eenvoudige codefragment voor het maken van een spreidingsgrafiek vanaf nul in een presentatie met de legacy Aspose.Slides‑API en hoe u dit bereikt met de nieuwe samengevoegde API.

## **Legacy Aspose.Slides for .NET‑aanpak**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //Standaardgrafiek maken
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //Het index van het standaardgegevensblad van de grafiek ophalen
    int defaultWorksheetIndex = 0;

    //Toegang tot het gegevensblad van de grafiek
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //Demo-reeksen verwijderen
    chart.ChartData.Series.Clear();

    //Nieuwe reeksen toevoegen
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //Eerste grafiekreeks nemen
    ChartSeriesEx series = chart.ChartData.Series[0];

    //Nieuw punt (1:3) toevoegen daar.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //Nieuw punt (2:10) toevoegen
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //Type van de reeks bewerken
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //Markering van de grafiekreeks wijzigen
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //Tweede grafiekreeks nemen
    series = chart.ChartData.Series[1];

    //Nieuw punt (5:2) toevoegen daar.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //Nieuw punt (3:1) toevoegen
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //Nieuw punt (2:2) toevoegen
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //Nieuw punt (5:1) toevoegen
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //Markering van de grafiekreeks wijzigen
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```


## **Nieuwe Aspose.Slides for .NET 13.x‑aanpak**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//Standaardgrafiek maken
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//Het index van het standaardgegevensblad van de grafiek ophalen
int defaultWorksheetIndex = 0;

//Toegang tot het gegevensblad van de grafiek
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Demo-reeksen verwijderen
chart.ChartData.Series.Clear();

//Nieuwe reeksen toevoegen
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//Eerste grafiekreeks nemen
IChartSeries series = chart.ChartData.Series[0];

//Nieuw punt (1:3) toevoegen daar.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//Nieuw punt (2:10) toevoegen
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//Type van de reeks bewerken
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//Markering van de grafiekreeks wijzigen
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//Tweede grafiekreeks nemen
series = chart.ChartData.Series[1];

//Nieuw punt (5:2) toevoegen daar.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//Nieuw punt (3:1) toevoegen
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//Nieuw punt (2:2) toevoegen
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//Nieuw punt (5:1) toevoegen
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//Markering van de grafiekreeks wijzigen
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```