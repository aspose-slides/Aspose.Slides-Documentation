---
title: Jak vytvořit grafy v prezentacích v .NET
linktitle: Vytvořit graf
type: docs
weight: 30
url: /cs/net/how-to-create-charts-in-a-presentation/
keywords:
- migrace
- vytvořit graf
- starý kód
- moderní kód
- starý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak vytvářet grafy v prezentacích PowerPoint PPT, PPTX a ODP v .NET pomocí Aspose.Slides s využitím jak starých, tak moderních API pro grafy."
---
{{% alert color="primary" %}} 
Byla vydána nová [Aspose.Slides for .NET API](/slides/cs/net/) a nyní tento jediný produkt podporuje schopnost vytvářet PowerPoint dokumenty od nuly a upravovat existující.
{{% /alert %}} 
## **Podpora starého kódu**
Aby bylo možné použít starý kód vyvinutý pro Aspose.Slides for .NET ve verzích starších než 13.x, musíte v kódu provést drobné úpravy a kód bude fungovat jako dříve. Všechny třídy, které byly v starém Aspose.Slides for .NET pod jmennými prostory Aspose.Slide a Aspose.Slides.Pptx, jsou nyní sloučeny do jediného jmenného prostoru Aspose.Slides. Podívejte se na následující jednoduchý úryvek kódu pro vytvoření běžného grafu od nuly v prezentaci pomocí legacy Aspose.Slides API a následujte kroky popisující, jak migrovat na nové sloučené API.
## **Legacy Aspose.Slides for .NET přístup**
```c#
//Instancujte třídu PresentationEx, která představuje soubor PPTX
using (PresentationEx pres = new PresentationEx())
{
	//Získat první snímek
	SlideEx sld = pres.Slides[0];

	// Přidat graf s výchozími daty
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//Nastavení názvu grafu
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//Nastavit první sérii, aby zobrazovala hodnoty
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//Nastavení indexu listu dat grafu 
	int defaultWorksheetIndex = 0;

	//Získání listu dat grafu
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//Odstranit výchozí generované série a kategorie
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//Přidání nové série
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	//Přidání nových kategorií
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	//Vezměte první sérii grafu
	ChartSeriesEx series = chart.ChartData.Series[0];

	//Nyní naplňujeme data série
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//Nastavení barvy výplně pro sérii
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//Vezměte druhou sérii grafu
	series = chart.ChartData.Series[1];

	//Nyní naplňujeme data série
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//Nastavení barvy výplně pro sérii
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//Vytvořit vlastní popisky pro každou kategorii nové série

	//První popisek bude zobrazovat název kategorie
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//Zobrazit název série pro druhý popisek
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//Zobrazit hodnotu pro třetí popisek
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//Zobrazit hodnotu a vlastní text
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "My text";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//Uložit prezentaci s grafem
	pres.Write(@"D:\AsposeChart.pptx");
}
```

## **Nový Aspose.Slides for .NET 13.x přístup**
``` csharp
//Instancujte třídu Presentation, která představuje soubor PPTX//Instancujte třídu Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();

//Přístup k prvnímu snímku
ISlide sld = pres.Slides[0];

// Přidat graf s výchozími daty
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//Nastavení názvu grafu
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//Nastavit první sérii, aby zobrazovala hodnoty
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//Nastavení indexu listu dat grafu
int defaultWorksheetIndex = 0;

//Získání listu dat grafu
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Odstranit výchozí generované série a kategorie
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//Přidání nové série
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//Přidání nových kategorií
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//Vezměte první sérii grafu
IChartSeries series = chart.ChartData.Series[0];

//Nyní naplňujeme data série

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//Nastavení barvy výplně pro sérii
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//Vezměte druhou sérii grafu
series = chart.ChartData.Series[1];

//Nyní naplňujeme data série
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Nastavení barvy výplně pro sérii
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//Vytvořit vlastní popisky pro každou kategorii nové série

//První popisek bude zobrazovat název kategorie
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//Zobrazit hodnotu pro třetí popisek
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//Uložit prezentaci s grafem
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```
Podívejte se na následující jednoduchý úryvek kódu pro vytvoření rozptylového grafu od nuly v prezentaci pomocí legacy Aspose.Slides API a jak toho dosáhnout s novým sloučeným API.
## **Legacy Aspose.Slides for .NET přístup**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //Vytváření výchozího grafu
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //Získání indexu výchozího listu dat grafu
    int defaultWorksheetIndex = 0;

    //Přístup k listu dat grafu
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //Odstranit demonstrační sérii
    chart.ChartData.Series.Clear();

    //Přidat novou sérii
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //Vezměte první sérii grafu
    ChartSeriesEx series = chart.ChartData.Series[0];

    //Přidat nový bod (1:3) tam.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //Přidat nový bod (2:10)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //Upravit typ série
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //Změna značky série grafu
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //Vezměte druhou sérii grafu
    series = chart.ChartData.Series[1];

    //Přidat nový bod (5:2) tam.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //Přidat nový bod (3:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //Přidat nový bod (2:2)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //Přidat nový bod (5:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //Změna značky série grafu
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```

## **Nový Aspose.Slides for .NET 13.x přístup**
``` csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//Vytváří se výchozí graf
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//Získání indexu výchozího listu dat grafu
int defaultWorksheetIndex = 0;

//Přístup k listu dat grafu
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Odstranit demonstrační sérii
chart.ChartData.Series.Clear();

//Přidat novou sérii
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//Vezměte první sérii grafu
IChartSeries series = chart.ChartData.Series[0];

//Přidat nový bod (1:3) tam.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//Přidat nový bod (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//Upravit typ série
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//Změna značky série grafu
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//Vezměte druhou sérii grafu
series = chart.ChartData.Series[1];

//Přidat nový bod (5:2) tam.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//Přidat nový bod (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//Přidat nový bod (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//Přidat nový bod (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//Změna značky série grafu
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```