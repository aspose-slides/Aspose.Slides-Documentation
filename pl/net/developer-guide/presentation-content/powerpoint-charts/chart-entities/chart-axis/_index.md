---
title: Dostosowywanie osi wykresów w prezentacjach w .NET
linktitle: Oś wykresu
type: docs
url: /pl/net/chart-axis/
keywords:
- oś wykresu
- oś pionowa
- oś pozioma
- dostosowywanie osi
- manipulacja osią
- zarządzanie osią
- właściwości osi
- wartość maksymalna
- wartość minimalna
- linia osi
- format daty
- tytuł osi
- pozycja osi
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak używać Aspose.Slides dla .NET do dostosowywania osi wykresów w prezentacjach PowerPoint w raportach i wizualizacjach."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować osie wykresu w Aspose.Slides. Pokazuje, jak pobrać rzeczywiste wartości osi, zamienić dane między osiami, ukryć pionową lub poziomą oś w wykresach liniowych, zmienić typ osi kategorii, ustawić format daty dla wartości osi kategorii, obrócić tytuł osi, ustawić położenie osi oraz wyświetlić etykietę jednostki na osi wartości.

## **Uzyskanie maksymalnych wartości na osi pionowej w wykresach**
Aspose.Slides dla .NET umożliwia pobranie minimalnych i maksymalnych wartości na osi pionowej. Postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj wykres z domyślnymi danymi.
1. Pobierz rzeczywistą maksymalną wartość na osi.
1. Pobierz rzeczywistą minimalną wartość na osi.
1. Pobierz rzeczywistą jednostkę główną osi.
1. Pobierz rzeczywistą jednostkę poboczną osi.
1. Pobierz rzeczywistą skalę jednostki głównej osi.
1. Pobierz rzeczywistą skalę jednostki pobocznej osi.

Ten przykładowy kod — implementacja powyższych kroków — pokazuje, jak uzyskać wymagane wartości w C#:

```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// Zapisuje prezentację
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```

## **Zamiana danych między osiami**
Aspose.Slides umożliwia szybką zamianę danych między osiami — dane wyświetlane na osi pionowej (y‑axis) przechodzą na oś poziomą (x‑axis) i odwrotnie.

Ten kod w C# pokazuje, jak wykonać zamianę danych między osiami wykresu:

```c#
 // Tworzy pustą prezentację
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//Przełącza wiersze i kolumny
		   
	// Zapisuje prezentację
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```

## **Ukrycie osi pionowej w wykresach liniowych**

Ten kod w C# pokazuje, jak ukryć oś pionową w wykresie liniowym:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Ukrycie osi poziomej w wykresach liniowych**

Ten kod pokazuje, jak ukryć oś poziomą w wykresie liniowym:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Zmiana osi kategorii**

Korzystając z właściwości **CategoryAxisType**, możesz określić preferowany typ osi kategorii (**date** lub **text**). Ten kod w C# demonstruje tę operację:

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes[0] as IChart;
    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;
    presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
}
```

## **Ustawienie formatu daty dla wartości osi kategorii**
Aspose.Slides dla .NET umożliwia ustawienie formatu daty dla wartości osi kategorii. Operacja jest pokazana w poniższym kodzie C#:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Area, 50, 50, 450, 300);

	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	wb.Clear(0);

	chart.ChartData.Categories.Clear();
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Add(wb.GetCell(0, "A2", new DateTime(2015, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A3", new DateTime(2016, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A4", new DateTime(2017, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A5", new DateTime(2018, 1, 1).ToOADate()));

	IChartSeries series = chart.ChartData.Series.Add(ChartType.Line);
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B2", 1));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B3", 2));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B4", 3));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B5", 4));
	chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
	chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
	chart.Axes.HorizontalAxis.NumberFormat = "yyyy";
	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **Ustawienie kąta obrotu tytułu osi wykresu**
Aspose.Slides dla .NET pozwala ustawić kąt obrotu tytułu osi wykresu. Ten kod w C# demonstruje tę operację:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **Ustawienie pozycji osi na osi kategorii lub wartości**
Aspose.Slides dla .NET umożliwia ustawienie pozycji osi w osi kategorii lub wartości. Ten kod w C# pokazuje, jak wykonać to zadanie:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```

## **Włączenie wyświetlania etykiety jednostki na osi wartości wykresu**
Aspose.Slides dla .NET pozwala skonfigurować wykres tak, aby wyświetlał etykietę jednostki na osi wartości. Ten kod w C# demonstruje tę operację:

```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Jak ustawić wartość, w której jedna oś przecina drugą (przecięcie osi)?**

Osie oferują [ustawienie crossing](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/axis/crosstype/): możesz wybrać przecięcie w zerze, w maksymalnej kategorii/wartości lub w określonej wartości liczbowej. Jest to przydatne przy przesuwaniu osi X w górę lub w dół lub do podkreślenia linii bazowej.

**Jak ustawić położenie etykiet podziałek względem osi (obok, na zewnątrz, wewnątrz)?**

Ustaw [pozycję etykiety](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/axis/majortickmark/) na „cross”, „outside” lub „inside”. Ma to wpływ na czytelność i pomaga oszczędzać miejsce, zwłaszcza w małych wykresach.