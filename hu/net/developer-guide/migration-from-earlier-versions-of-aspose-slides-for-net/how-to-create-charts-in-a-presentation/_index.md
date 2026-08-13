---
title: Diagramok létrehozása prezentációkban .NET-ben
linktitle: Diagram létrehozása
type: docs
weight: 30
url: /hu/net/how-to-create-charts-in-a-presentation/
keywords:
- migráció
- diagram létrehozása
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre diagramokat PowerPoint PPT, PPTX és ODP prezentációkban .NET környezetben az Aspose.Slides segítségével, mind legacy, mind modern diagram API-k használatával."
---
{{% alert color="info" %}} 

Megjelent egy új [Aspose.Slides for .NET API](/slides/hu/net/), és most ez a termék képes PowerPoint dokumentumokat előállítani a semmiből, valamint a meglévőket szerkeszteni.

{{% /alert %}} 
## **Legacy kód támogatása**
Annak érdekében, hogy a 13.x előtti Aspose.Slides for .NET verziókkal készült legacy kódot használhassa, néhány kisebb módosításra van szükség a kódban, és a kód úgy fog működni, mint korábban. Az összes régi Aspose.Slides for .NET osztály, amely az Aspose.Slide és az Aspose.Slides.Pptx névtérben szerepelt, most egyetlen Aspose.Slides névtérbe lett egyesítve. Tekintse meg az alábbi egyszerű kódrészletet, amely bemutatja, hogyan hozhat létre normál diagramot a prezentációban a semmiből a régi Aspose.Slides API-val, és kövesse a lépéseket az új, egyesített API-ra való áttéréshez.
## **Legacy Aspose.Slides for .NET megközelítés**
```c#
using System.Drawing;

//PPTX fájlt képviselő PresentationEx osztály példányosítása
using (PresentationEx pres = new PresentationEx())
{
	//Első dia elérése
	SlideEx sld = pres.Slides[0];

	// Diagram hozzáadása alapértelmezett adatokkal
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//Setting chart Title
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//Az első sorozat beállítása az értékek megjelenítésére
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//A diagram adatlap indexének beállítása 
	int defaultWorksheetIndex = 0;

	//A diagram adatlapjának lekérése
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//Az alapértelmezett generált sorozatok és kategóriák törlése
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//Új sorozat hozzáadása
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	//Új kategóriák hozzáadása
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	//Az első diagram sorozat kivétele
	ChartSeriesEx series = chart.ChartData.Series[0];

	//Sorozat adatainak feltöltése
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//Kitöltő szín beállítása a sorozathoz
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//A második diagram sorozat kivétele
	series = chart.ChartData.Series[1];

	//Sorozat adatainak feltöltése
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//Kitöltő szín beállítása a sorozathoz
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//Egyéni címkék létrehozása az új sorozat minden kategóriájához

	//az első címke a kategória nevét fogja mutatni
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//A második címken a sorozat neve jelenik meg
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//A harmadik címkén az érték jelenik meg
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//Érték és egyéni szöveg megjelenítése
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "My text";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//Prezentáció mentése diagrammal
	pres.Write(@"D:\AsposeChart.pptx");
}
```



## **Új Aspose.Slides for .NET 13.x megközelítés**
``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

//Presentation osztály példányosítása, amely PPTX fájlt képvisel//Presentation osztály példányosítása, amely PPTX fájlt képvisel
Presentation pres = new Presentation();

//Első dia elérése
ISlide sld = pres.Slides[0];

// Diagram hozzáadása alapértelmezett adatokkal
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//Diagram címének beállítása
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//Diagram adatlap indexének beállítása
int defaultWorksheetIndex = 0;

//Getting the chart data worksheet
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Alapértelmezett generált sorozatok és kategóriák törlése
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//Új sorozat hozzáadása
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//Az első sorozat beállítása az értékek megjelenítésére
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//Új kategóriák hozzáadása
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//Az első diagram sorozat kivétele
IChartSeries series = chart.ChartData.Series[0];

//Sorozat adatainak feltöltése

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//Kitöltő szín beállítása a sorozathoz
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//A második diagram sorozat kivétele
series = chart.ChartData.Series[1];

//Sorozat adatainak feltöltése
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Kitöltő szín beállítása a sorozathoz
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//Egyéni címkék létrehozása minden kategóriához az új sorozatban

//az első címke a kategória nevét fogja mutatni
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//Show value for third label
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//Prezentáció mentése diagrammal
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Tekintse meg az alábbi egyszerű kódrészletet, amely bemutatja, hogyan hozhat létre szórt diagramot a prezentációban a semmiből a régi Aspose.Slides API-val, és hogyan valósítható meg ez az új, egyesített API-val.

## **Legacy Aspose.Slides for .NET megközelítés**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //Alapértelmezett diagram létrehozása
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //Alapértelmezett diagram adatlap indexének lekérése
    int defaultWorksheetIndex = 0;

    //Diagram adatlap elérése
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //Demo sorozat törlése
    chart.ChartData.Series.Clear();

    //Új sorozat hozzáadása
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //Első diagram sorozat kivétele
    ChartSeriesEx series = chart.ChartData.Series[0];

    //Új pont (1:3) hozzáadása.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //Új pont (2:10) hozzáadása
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //Sorozat típusának módosítása
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //Diagram sorozat jelölőjének módosítása
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //Második diagram sorozat kivétele
    series = chart.ChartData.Series[1];

    //Új pont (5:2) hozzáadása.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //Új pont (3:1) hozzáadása
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //Új pont (2:2) hozzáadása
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //Új pont (5:1) hozzáadása
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //Diagram sorozat jelölőjének módosítása
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```


## **Új Aspose.Slides for .NET 13.x megközelítés**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//Az alapértelmezett diagram létrehozása
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//Az alapértelmezett diagram adatlap indexének lekérése
int defaultWorksheetIndex = 0;

//Diagram adatlap elérése
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Demo sorozat törlése
chart.ChartData.Series.Clear();

//Új sorozat hozzáadása
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//Első diagram sorozat kivétele
IChartSeries series = chart.ChartData.Series[0];

//Új pont (1:3) hozzáadása.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//Új pont (2:10) hozzáadása
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//Sorozat típusának módosítása
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//Diagram sorozat jelölőjének módosítása
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//Második diagram sorozat kivétele
series = chart.ChartData.Series[1];

//Új pont (5:2) hozzáadása.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//Új pont (3:1) hozzáadása
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//Új pont (2:2) hozzáadása
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//Új pont (5:1) hozzáadása
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//Diagram sorozat jelölőjének módosítása
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```