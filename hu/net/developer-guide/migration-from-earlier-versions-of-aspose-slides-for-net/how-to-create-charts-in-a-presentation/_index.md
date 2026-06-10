---
title: Hogyan hozzunk létre diagramokat prezentációkban .NET-ben
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
description: "Tanulja meg, hogyan hozhat létre diagramokat PowerPoint PPT, PPTX és ODP prezentációkban .NET alatt az Aspose.Slides segítségével, mind az örökölt, mind a modern diagram API-k használatával."
---
{{% alert color="primary" %}} 
Új [Aspose.Slides for .NET API](/slides/hu/net/) került kiadásra, és most ez a termék képes PowerPoint dokumentumok létrehozására a semmiből, valamint a meglévők szerkesztésére.
{{% /alert %}} 
## **Support for Legacy Code**
Az 13.x előtti Aspose.Slides for .NET verziókkal fejlesztett örökölt kód használatához néhány kisebb módosítást kell végrehajtani a kódban, és a kód újra úgy fog működni, mint korábban. Az összes osztály, amelyek az egykori Aspose.Slides for .NET-ben az Aspose.Slide és az Aspose.Slides.Pptx névterek alatt voltak, most egyetlen Aspose.Slides névtérbe lettek egyesítve. Kérjük, tekintse meg az alábbi egyszerű kódrészletet, amely egy normál diagram létrehozását mutatja a prezentációban az örökölt Aspose.Slides API használatával, és kövesse a lépéseket, amelyek leírják a migrálást az új egyesített API-ra.
## **Legacy Aspose.Slides for .NET Approach**
```c#
//PPTX fájlt képviselő PresentationEx osztály példányosítása
using (PresentationEx pres = new PresentationEx())
{
	//Első dia elérése
	SlideEx sld = pres.Slides[0];

	// Alapértelmezett adatokkal diagram hozzáadása
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//Diagram címének beállítása
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//Az első sorozat beállítása értékek megjelenítésére
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//A diagram adatlap indexének beállítása 
	int defaultWorksheetIndex = 0;

	//A diagram adatlap lekérése
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

	//Kitöltőszín beállítása a sorozathoz
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//A második diagram sorozat kivétele
	series = chart.ChartData.Series[1];

	//Sorozat adatainak feltöltése
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//Kitöltőszín beállítása a sorozathoz
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//Egyéni címkék létrehozása az új sorozat minden kategóriájához

	//Az első címke a kategórianév megjelenítését fogja tartalmazni
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//A második címke a sorozat nevét mutatja
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//A harmadik címke az értéket mutatja
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



## **New Aspose.Slides for .NET 13.x Approach**
```csharp
//PPTX fájlt képviselő Presentation osztály példányosítása//PPTX fájlt képviselő Presentation osztály példányosítása
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

//Az első sorozat beállítása értékek megjelenítésére
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//A diagram adatlap indexének beállítása
int defaultWorksheetIndex = 0;

//A diagram adatlap lekérése
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Alapértelmezett generált sorozatok és kategóriák törlése
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//Új sorozatok hozzáadása
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

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

//Kitöltőszín beállítása a sorozathoz
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//A második diagram sorozat kivétele
series = chart.ChartData.Series[1];

//Sorozat adatainak feltöltése
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Kitöltőszín beállítása a sorozathoz
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//Egyéni címkék létrehozása az új sorozat minden kategóriájához

//Az első címke a kategórianév megjelenítését fogja tartalmazni
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//A harmadik címke az értéket mutatja
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//Prezentáció mentése diagrammal
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Kérjük, tekintse meg az alábbi egyszerű kódrészletet, amely egy szórt diagram létrehozását mutatja a prezentációban az örökölt Aspose.Slides API-val, és hogyan valósítható meg az új egyesített API-val.

## **Legacy Aspose.Slides for .NET Approach**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //Az alapértelmezett diagram létrehozása
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //Az alapértelmezett diagram adatlap indexének lekérése
    int defaultWorksheetIndex = 0;

    //A diagram adatlap elérése
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //Demó sorozat törlése
    chart.ChartData.Series.Clear();

    //Új sorozat hozzáadása
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //Az első diagram sorozat kivétele
    ChartSeriesEx series = chart.ChartData.Series[0];

    //Új pont hozzáadása (1:3) ott.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //Új pont hozzáadása (2:10)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //Sorozattípus szerkesztése
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //Diagram sorozat jelölő módosítása
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //A második diagram sorozat kivétele
    series = chart.ChartData.Series[1];

    //Új pont hozzáadása (5:2) ott.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //Új pont hozzáadása (3:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //Új pont hozzáadása (2:2)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //Új pont hozzáadása (5:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //Diagram sorozat jelölő módosítása
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```


## **New Aspose.Slides for .NET 13.x Approach**
``` csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//Az alapértelmezett diagram létrehozása
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//Az alapértelmezett diagram adatlap indexének lekérése
int defaultWorksheetIndex = 0;

//A diagram adatlap elérése
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Demó sorozat törlése
chart.ChartData.Series.Clear();

//Új sorozat hozzáadása
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//Az első diagram sorozat kivétele
IChartSeries series = chart.ChartData.Series[0];

//Új pont hozzáadása (1:3) ott.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//Új pont hozzáadása (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//Sorozattípus szerkesztése
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//Diagram sorozat jelölő módosítása
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//A második diagram sorozat kivétele
series = chart.ChartData.Series[1];

//Új pont hozzáadása (5:2) ott.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//Új pont hozzáadása (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//Új pont hozzáadása (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//Új pont hozzáadása (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//Diagram sorozat jelölő módosítása
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```