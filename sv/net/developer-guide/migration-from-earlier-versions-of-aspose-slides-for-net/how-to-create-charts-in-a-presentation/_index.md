---
title: Hur man skapar diagram i presentationer i .NET
linktitle: Skapa diagram
type: docs
weight: 30
url: /sv/net/how-to-create-charts-in-a-presentation/
keywords:
- migrering
- skapa diagram
- legacy-kod
- modern kod
- legacy-metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du skapar diagram i PowerPoint PPT, PPTX och ODP presentationer i .NET med Aspose.Slides med både legacy- och moderna diagram-API:er."
---
{{% alert color="primary" %}} 
En ny [Aspose.Slides for .NET API](/slides/sv/net/) har släppts och nu stöder denna enda produkt möjligheten att generera PowerPoint‑dokument från grunden och redigera befintliga.
{{% /alert %}} 
## **Support för äldre kod**
För att kunna använda den äldre koden som utvecklats med Aspose.Slides för .NET versioner före 13.x, måste du göra några mindre ändringar i din kod så att den fungerar som tidigare. Alla klasser som fanns i den gamla Aspose.Slides för .NET under namnutrymmena Aspose.Slide och Aspose.Slides.Pptx har nu slagits samman i ett enda Aspose.Slides‑namnutrymme. Titta på följande enkla kodexempel för att skapa ett normalt diagram från grunden i en presentation med den äldre Aspose.Slides‑API:n och följ stegen som beskriver hur du migrerar till den nya sammanslagna API:n.
## **Legacy‑metod för Aspose.Slides för .NET**
```c#
//Instansiera PresentationEx‑klassen som representerar PPTX‑fil
using (PresentationEx pres = new PresentationEx())
{
	//Access first slide
	// Lägg till diagram med standarddata
	//Ställer in diagramtitel
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//Ställ in första serien så att värden visas
	//Ställer in index för diagramdatablad 
	int defaultWorksheetIndex = 0;

	//Hämtar diagrammets dataarbetsblad
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//Ta bort standardgenererade serier och kategorier
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//Lägger till ny serie
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	//Lägger till nya kategorier
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	//Hämta första diagramserien
	ChartSeriesEx series = chart.ChartData.Series[0];

	//Populerar nu seriedata
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//Ställer in fyllnadsfärg för serien
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;

	//Hämta andra diagramserien
	series = chart.ChartData.Series[1];

	//Populerar nu seriedata
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//Ställer in fyllnadsfärg för serien
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;

	//Skapa anpassade etiketter för varje kategori för den nya serien
	//Den första etiketten visar kategorinamn
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//Visa serienamn för andra etiketten
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//Visa värde för tredje etiketten
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//Visa värde och anpassad text
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "My text";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//Spara presentationen med diagram
	pres.Write(@"D:\AsposeChart.pptx");
}
```



## **Ny Aspose.Slides för .NET 13.x‑metod**
```csharp
//Instansiera Presentation‑klassen som representerar PPTX‑fil//Instansiera Presentation‑klassen som representerar PPTX‑fil
Presentation pres = new Presentation();

//Access first slide
// Hämta första bilden
ISlide sld = pres.Slides[0];

// Add chart with default data
// Lägg till diagram med standarddata
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//Setting chart Title
// Ställer in diagramtitel
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//Set first series to Show Values
// Ställ in första serien så att värden visas
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//Setting the index of chart data sheet
// Ställer in index för diagramdatablad
int defaultWorksheetIndex = 0;

//Getting the chart data worksheet
// Hämtar diagrammets dataarbetsblad
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Delete default generated series and categories
// Ta bort standardgenererade serier och kategorier
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//Adding new series
// Lägger till ny serie
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//Adding new categories
// Lägger till nya kategorier
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//Take first chart series
// Hämta första diagramserien
IChartSeries series = chart.ChartData.Series[0];

//Now populating series data
// Populerar nu seriedata

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//Setting fill color for series
// Ställer in fyllnadsfärg för serien
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//Take second chart series
// Hämta andra diagramserien
series = chart.ChartData.Series[1];

//Now populating series data
// Populerar nu seriedata
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Setting fill color for series
// Ställer in fyllnadsfärg för serien
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//create custom labels for each of categories for new series
// Skapa anpassade etiketter för varje kategori för den nya serien

//first label will be show Category name
// Den första etiketten visar kategorinamn
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//Show value for third label
// Visa värde för tredje etiketten
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//Save presentation with chart
// Spara presentationen med diagram
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Titta på följande enkla kodexempel för att skapa ett spridningsdiagram från grunden i en presentation med den äldre Aspose.Slides‑API:n och hur du uppnår det med den nya sammanslagna API:n.

## **Legacy‑metod för Aspose.Slides för .NET**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //Skapar standarddiagram
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //Hämtar index för standarddatablad för diagrammet
    int defaultWorksheetIndex = 0;

    //Kommer åt diagrammets dataarbetsblad
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //Ta bort demonstrationsserier
    chart.ChartData.Series.Clear();

    //Lägg till ny serie
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //Hämta första diagramserien
    ChartSeriesEx series = chart.ChartData.Series[0];

    //Lägg till ny punkt (1:3) där.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //Lägg till ny punkt (2:10)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //Redigera serietypen
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //Ändrar diagramseriens markör
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //Hämta andra diagramserien
    series = chart.ChartData.Series[1];

    //Lägg till ny punkt (5:2) där.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //Lägg till ny punkt (3:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //Lägg till ny punkt (2:2)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //Lägg till ny punkt (5:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //Ändrar diagramseriens markör
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```


## **Ny Aspose.Slides för .NET 13.x‑metod**
```csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

// Skapar standarddiagram
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

// Hämtar index för standarddatablad för diagrammet
int defaultWorksheetIndex = 0;

// Kommer åt diagrammets dataarbetsblad
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Ta bort demonstrationsserier
chart.ChartData.Series.Clear();

// Lägg till ny serie
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

// Hämta första diagramserien
IChartSeries series = chart.ChartData.Series[0];

// Lägg till ny punkt (1:3) där.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

// Lägg till ny punkt (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

// Redigera serietypen
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

// Ändrar diagramseriens markör
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

// Hämta andra diagramserien
series = chart.ChartData.Series[1];

// Lägg till ny punkt (5:2) där.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

// Lägg till ny punkt (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

// Lägg till ny punkt (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

// Lägg till ny punkt (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

// Ändrar diagramseriens markör
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```