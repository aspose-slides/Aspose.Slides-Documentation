---
title: Jak vytvářet grafy v prezentacích v .NET
linktitle: Vytvořit graf
type: docs
weight: 30
url: /cs/net/how-to-create-charts-in-a-presentation/
keywords:
- migrace
- vytvořit graf
- zastaralý kód
- moderní kód
- zastaralý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Zjistěte, jak vytvářet grafy v prezentacích PowerPoint PPT, PPTX a ODP v .NET s Aspose.Slides pomocí jak legacy, tak moderních API pro grafy."
---
{{% alert color="info" %}}
Nové [Aspose.Slides for .NET API](/slides/cs/net/) bylo vydáno a nyní tento jediný produkt podporuje možnost generovat PowerPoint dokumenty od nuly a upravovat existující.
{{% /alert %}}
## **Podpora pro starý kód**
Aby bylo možné použít starý kód vyvinutý v Aspose.Slides pro .NET ve verzích před 13.x, je třeba provést drobné úpravy v kódu, po nichž bude kód fungovat jako dříve. Všechny třídy, které byly v starém Aspose.Slides pro .NET pod jmennými prostory Aspose.Slide a Aspose.Slides.Pptx, jsou nyní sloučeny do jediného jmenného prostoru Aspose.Slides. Podívejte se na níže uvedený jednoduchý ukázkový kód pro vytvoření běžného grafu od nuly v prezentaci pomocí legacy Aspose.Slides API a následujte kroky popisující, jak migrovat na nové sloučené API.
## **Legacy Aspose.Slides pro .NET přístup**
```c#
using System.Drawing;

//Vytvořte instanci třídy PresentationEx, která představuje soubor PPTX
using (PresentationEx pres = new PresentationEx())
{
	//Přístup k první snímku
	SlideEx sld = pres.Slides[0];

	// Přidat graf s výchozími daty
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//Nastavení názvu grafu
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//Nastavit první řadu, aby zobrazovala hodnoty
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//Nastavení indexu listu dat grafu 
	int defaultWorksheetIndex = 0;

	//Získání listu dat grafu
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//Smazat výchozí generované řady a kategorie
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//Přidání nové řady
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	//Přidání nových kategorií
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	//Získat první řadu grafu
	ChartSeriesEx series = chart.ChartData.Series[0];

	//Nyní naplňujeme data řady
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//Nastavení barvy výplně pro řadu
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//Získat druhou řadu grafu
	series = chart.ChartData.Series[1];

	//Nyní naplňujeme data řady
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//Nastavení barvy výplně pro řadu
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//Vytvořit vlastní popisky pro každou kategorii pro novou řadu

	//první popisek bude zobrazovat název kategorie
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//Zobrazit název řady pro druhý popisek
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

## **Nový Aspose.Slides pro .NET 13.x přístup**
``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

//Vytvořte instanci třídy Presentation, která představuje soubor PPTX//Vytvořte instanci třídy Presentation, která představuje soubor PPTX
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

//Nastavení indexu listu dat grafu
int defaultWorksheetIndex = 0;

//Získání listu dat grafu
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Smazat výchozí generované řady a kategorie
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//Přidání nové řady
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//Nastavit první řadu, aby zobrazovala hodnoty
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//Přidání nových kategorií
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//Získat první řadu grafu
IChartSeries series = chart.ChartData.Series[0];

//Nyní naplňujeme data řady

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//Nastavení barvy výplně pro řadu
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//Získat druhou řadu grafu
series = chart.ChartData.Series[1];

//Nyní naplňujeme data řady
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Nastavení barvy výplně pro řadu
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//Vytvořit vlastní popisky pro každou kategorii pro novou řadu

//první popisek bude zobrazovat název kategorie
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

Podívejte se na níže uvedený jednoduchý ukázkový kód pro vytvoření rozptylového grafu od nuly v prezentaci pomocí legacy Aspose.Slides API a jak to provést s novým sloučeným API.
## **Legacy Aspose.Slides pro .NET přístup**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //Vytváří se výchozí graf
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //Získání indexu výchozího listu dat grafu
    int defaultWorksheetIndex = 0;

    //Přístup k listu dat grafu
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //Smazat ukázkovou řadu
    chart.ChartData.Series.Clear();

    //Přidat novou řadu
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //Získat první řadu grafu
    ChartSeriesEx series = chart.ChartData.Series[0];

    //Přidat nový bod (1:3) zde.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //Přidat nový bod (2:10)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //Upravit typ řady
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //Změna značky řady grafu
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //Získat druhou řadu grafu
    series = chart.ChartData.Series[1];

    //Přidat nový bod (5:2) zde.
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

    //Změna značky řady grafu
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```

## **Nový Aspose.Slides pro .NET 13.x přístup**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//Vytváří výchozí graf
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//Získání indexu výchozího listu dat grafu
int defaultWorksheetIndex = 0;

//Přístup k listu dat grafu
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Smazat ukázkovou řadu
chart.ChartData.Series.Clear();

//Přidat novou řadu
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//Získat první řadu grafu
IChartSeries series = chart.ChartData.Series[0];

//Přidat nový bod (1:3) zde.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//Přidat nový bod (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//Upravit typ řady
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//Změna značky řady grafu
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//Získat druhou řadu grafu
series = chart.ChartData.Series[1];

//Přidat nový bod (5:2) zde.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//Přidat nový bod (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//Přidat nový bod (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//Přidat nový bod (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//Změna značky řady grafu
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```