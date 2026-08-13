---
title: Hur man skapar diagram i presentationer i .NET
linktitle: Skapa diagram
type: docs
weight: 30
url: /sv/net/how-to-create-charts-in-a-presentation/
keywords:
- migrering
- skapa diagram
- äldre kod
- modern kod
- äldre tillvägagångssätt
- modernt tillvägagångssätt
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur man skapar diagram i PowerPoint PPT, PPTX och ODP‑presentationer i .NET med Aspose.Slides med både äldre och moderna diagram‑API:er."
---
{{% alert color="info" %}} 

En ny [Aspose.Slides for .NET API](/slides/sv/net/) har släppts och nu stödjer denna enda produkt möjligheten att generera PowerPoint-dokument från grunden och redigera befintliga.

{{% /alert %}} 
## **Stöd för äldre kod**
För att använda den äldre koden som utvecklats med Aspose.Slides for .NET versioner före 13.x måste du göra några mindre ändringar i din kod så att den fungerar som tidigare. Alla klasser som fanns i den gamla Aspose.Slides for .NET under Aspose.Slide- och Aspose.Slides.Pptx-namnutrymmena har nu slagits ihop i ett enda Aspose.Slides-namnutrymme. Titta på det följande enkla kodexemplet för att skapa ett vanligt diagram från grunden i en presentation med den äldre Aspose.Slides API:n och följ stegen som beskriver hur du migrerar till den nya sammanslagna API:n.
## **Legacy Aspose.Slides för .NET tillvägagångssätt**
```c#
using System.Drawing;

//Instansiera PresentationEx-klass som representerar PPTX-fil
using (PresentationEx pres = new PresentationEx())
{
	//Åtkomst till första bilden
	SlideEx sld = pres.Slides[0];

	// Lägg till diagram med standarddata
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//Ställer in diagramtitel
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//Ställ in första serien att visa värden
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//Ställer in indexet för diagramdatablad
	int defaultWorksheetIndex = 0;

	//Hämtar diagrammets dataarbetsblad
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//Radera standardgenererade serier och kategorier
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

	//Ta första diagramserien
	ChartSeriesEx series = chart.ChartData.Series[0];

	//Fyller nu serie-data
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//Ställer in fyllnadsfärg för serien
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//Ta andra diagramserien
	series = chart.ChartData.Series[1];

	//Fyller nu serie-data
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//Ställer in fyllnadsfärg för serien
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//skapa anpassade etiketter för varje kategori för ny serie

	//första etiketten visar kategorinamn
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

	//Spara presentation med diagram
	pres.Write(@"D:\AsposeChart.pptx");
}
```

## **Nytt Aspose.Slides för .NET 13.x tillvägagångssätt**
``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

//Instansiera Presentation-klass som representerar PPTX-fil//Instansiera Presentation-klass som representerar PPTX-fil
Presentation pres = new Presentation();

//Åtkomst till första bilden
ISlide sld = pres.Slides[0];

// Lägg till diagram med standarddata
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//Ställer in diagramtitel
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//Ställer in indexet för diagramdatablad
int defaultWorksheetIndex = 0;

//Hämtar diagrammets dataarbetsblad
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Radera standardgenererade serier och kategorier
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//Lägger till ny serie
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//Ställ in första serien att visa värden
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//Lägger till nya kategorier
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//Ta första diagramserien
IChartSeries series = chart.ChartData.Series[0];

//Fyller nu serie-data

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//Ställer in fyllnadsfärg för serien
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//Ta andra diagramserien
series = chart.ChartData.Series[1];

//Fyller nu serie-data
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Ställer in fyllnadsfärg för serien
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//skapa anpassade etiketter för varje kategori för ny serie

//första etiketten visar kategorinamn
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//Visa värde för tredje etiketten
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//Spara presentation med diagram
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Titta på det följande enkla kodexemplet för att skapa ett spridningsdiagram från grunden i en presentation med den äldre Aspose.Slides API:n och hur du uppnår det med den nya sammanslagna API:n.

## **Legacy Aspose.Slides för .NET tillvägagångssätt**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //Skapar standarddiagrammet
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //Hämtar standarddiagrammets dataarbetsbladsindex
    int defaultWorksheetIndex = 0;

    //Åtkomst till diagrammets dataarbetsblad
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //Radera demoserier
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

    //Redigera serietyp
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

## **Nytt Aspose.Slides för .NET 13.x tillvägagångssätt**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//Skapar standarddiagrammet
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//Hämtar standarddiagrammets dataarbetsbladsindex
int defaultWorksheetIndex = 0;

//Åtkomst till diagrammets dataarbetsblad
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Radera demoserier
chart.ChartData.Series.Clear();

//Lägg till ny serie
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//Hämta första diagramserien
IChartSeries series = chart.ChartData.Series[0];

//Lägg till ny punkt (1:3) där.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//Lägg till ny punkt (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//Redigera serietypen
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//Ändrar diagramseriens markör
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//Hämta andra diagramserien
series = chart.ChartData.Series[1];

//Lägg till ny punkt (5:2) där.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//Lägg till ny punkt (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//Lägg till ny punkt (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//Lägg till ny punkt (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//Ändrar diagramseriens markör
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```