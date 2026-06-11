---
title: Jak tworzyć wykresy w prezentacjach w .NET
linktitle: Utwórz wykres
type: docs
weight: 30
url: /pl/net/how-to-create-charts-in-a-presentation/
keywords:
- migracja
- tworzenie wykresu
- stary kod
- nowoczesny kod
- stare podejście
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak tworzyć wykresy w prezentacjach PowerPoint PPT, PPTX i ODP w .NET przy użyciu Aspose.Slides, korzystając zarówno ze starszych, jak i nowoczesnych interfejsów API wykresów."
---
{{% alert color="primary" %}} 
Opublikowano nowy [Aspose.Slides for .NET API](/slides/pl/net/), który teraz umożliwia generowanie dokumentów PowerPoint od podstaw oraz edycję istniejących.
{{% /alert %}} 
## **Wsparcie dla starszego kodu**
Aby używać starszego kodu opracowanego w wersjach Aspose.Slides for .NET wcześniejszych niż 13.x, należy wprowadzić niewielkie zmiany w kodzie, po czym będzie on działał tak jak wcześniej. Wszystkie klasy, które znajdowały się w starszych wersjach Aspose.Slides for .NET w przestrzeniach nazw Aspose.Slide i Aspose.Slides.Pptx, zostały teraz połączone w jedną przestrzeń nazw Aspose.Slides. Zapoznaj się z poniższym prostym fragmentem kodu tworzącym zwykły wykres od podstaw w prezentacji przy użyciu starszego API Aspose.Slides i postępuj według kroków opisujących migrację do nowego, połączonego API.
## **Podejście Legacy Aspose.Slides for .NET**
```c#
//Utwórz instancję klasy PresentationEx reprezentującej plik PPTX
using (PresentationEx pres = new PresentationEx())
{
	//Uzyskaj dostęp do pierwszego slajdu
	SlideEx sld = pres.Slides[0];

	// Dodaj wykres z domyślnymi danymi
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//Ustawianie tytułu wykresu
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//Ustaw pierwszą serię, aby wyświetlała wartości
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//Ustawianie indeksu arkusza danych wykresu 
	int defaultWorksheetIndex = 0;

	//Pobieranie arkusza danych wykresu
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//Usuń domyślnie wygenerowane serie i kategorie
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//Dodawanie nowych serii
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	//Dodawanie nowych kategorii
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	//Weź pierwszą serię wykresu
	ChartSeriesEx series = chart.ChartData.Series[0];

	//Teraz wypełniamy dane serii
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//Ustawianie koloru wypełnienia serii
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//Weź drugą serię wykresu
	series = chart.ChartData.Series[1];

	//Teraz wypełniamy dane serii
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//Ustawianie koloru wypełnienia serii
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//Utwórz niestandardowe etykiety dla każdej kategorii nowej serii

	//pierwsza etykieta będzie wyświetlać nazwę kategorii
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//Wyświetl nazwę serii dla drugiej etykiety
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//Wyświetl wartość dla trzeciej etykiety
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//Wyświetl wartość i własny tekst
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "My text";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//Zapisz prezentację z wykresem
	pres.Write(@"D:\AsposeChart.pptx");
}
```

## **Nowe podejście Aspose.Slides for .NET 13.x**
``` csharp
//Utwórz instancję klasy Presentation, która reprezentuje plik PPTX//Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();

//Uzyskaj dostęp do pierwszego slajdu
ISlide sld = pres.Slides[0];

// Dodaj wykres z domyślnymi danymi
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//Ustawianie tytułu wykresu
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//Ustaw pierwszą serię, aby wyświetlała wartości
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//Ustawianie indeksu arkusza danych wykresu
int defaultWorksheetIndex = 0;

//Pobieranie arkusza danych wykresu
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Usuń domyślnie wygenerowane serie i kategorie
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//Dodawanie nowych serii
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//Dodawanie nowych kategorii
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//Weź pierwszą serię wykresu
IChartSeries series = chart.ChartData.Series[0];

//Teraz wypełniamy dane serii

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//Ustawianie koloru wypełnienia serii
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//Weź drugą serię wykresu
series = chart.ChartData.Series[1];

//Teraz wypełniamy dane serii
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Ustawianie koloru wypełnienia serii
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//Utwórz niestandardowe etykiety dla każdej kategorii nowej serii

//pierwsza etykieta będzie wyświetlać nazwę kategorii
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//Wyświetl wartość dla trzeciej etykiety
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//Zapisz prezentację z wykresem
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Zapoznaj się z poniższym prostym fragmentem kodu tworzącym wykres rozrzutu od podstaw w prezentacji przy użyciu starszego API Aspose.Slides oraz z tym, jak osiągnąć to samo przy użyciu nowego, połączonego API.

## **Podejście Legacy Aspose.Slides for .NET**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //Tworzenie domyślnego wykresu
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //Pobieranie indeksu domyślnego arkusza danych wykresu
    int defaultWorksheetIndex = 0;

    //Uzyskiwanie dostępu do arkusza danych wykresu
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //Usuń serie demonstracyjną
    chart.ChartData.Series.Clear();

    //Dodaj nową serię
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //Pobierz pierwszą serię wykresu
    ChartSeriesEx series = chart.ChartData.Series[0];

    //Dodaj nowy punkt (1:3) tam.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //Dodaj nowy punkt (2:10)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //Edytuj typ serii
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //Zmiana znacznika serii wykresu
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //Pobierz drugą serię wykresu
    series = chart.ChartData.Series[1];

    //Dodaj nowy punkt (5:2) tam.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //Dodaj nowy punkt (3:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //Dodaj nowy punkt (2:2)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //Dodaj nowy punkt (5:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //Zmiana znacznika serii wykresu
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```

## **Nowe podejście Aspose.Slides for .NET 13.x**
``` csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//Tworzenie domyślnego wykresu
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//Pobieranie indeksu domyślnego arkusza danych wykresu
int defaultWorksheetIndex = 0;

//Uzyskiwanie dostępu do arkusza danych wykresu
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Usuń serię demonstracyjną
chart.ChartData.Series.Clear();

//Dodaj nową serię
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//Pobierz pierwszą serię wykresu
IChartSeries series = chart.ChartData.Series[0];

//Dodaj nowy punkt (1:3) tam.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//Dodaj nowy punkt (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//Edytuj typ serii
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//Zmiana znacznika serii wykresu
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//Pobierz drugą serię wykresu
series = chart.ChartData.Series[1];

//Dodaj nowy punkt (5:2) tam.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//Dodaj nowy punkt (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//Dodaj nowy punkt (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//Dodaj nowy punkt (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//Zmiana znacznika serii wykresu
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```