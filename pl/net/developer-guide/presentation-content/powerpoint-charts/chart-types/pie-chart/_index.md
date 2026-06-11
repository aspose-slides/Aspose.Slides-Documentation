---
title: Dostosowywanie wykresów kołowych w prezentacjach w .NET
linktitle: Wykres kołowy
type: docs
url: /pl/net/pie-chart/
keywords:
- wykres kołowy
- zarządzanie wykresem
- dostosowywanie wykresu
- opcje wykresu
- ustawienia wykresu
- opcje rysowania
- kolor wycinka
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i dostosowywać wykresy kołowe w .NET przy użyciu Aspose.Slides, eksportowalne do PowerPoint, przyspieszając opowiadanie historii danych w kilka sekund."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z wykresami kołowymi w Aspose.Slides. Pokazuje, jak skonfigurować opcje drugiego wykresu dla wykresów Pie of Pie i Bar of Pie oraz jak włączyć automatyczne kolorowanie wycinków w standardowym wykresie kołowym.

Przykłady koncentrują się na praktycznych krokach dostosowywania wykresu, takich jak dodawanie wykresu do slajdu, dostosowywanie ustawień serii i etykiet, zastępowanie domyślnych danych wykresu własnymi kategoriami i wartościami oraz zapisywanie zaktualizowanej prezentacji.

## **Opcje drugiego wykresu dla wykresów Pie of Pie i Bar of Pie**

Aspose.Slides for .NET obsługuje teraz opcje drugiego wykresu dla wykresów Pie of Pie lub Bar of Pie. W tym temacie zobaczymy na przykładzie, jak określić te opcje przy użyciu Aspose.Slides. Aby określić właściwości, postępuj zgodnie z poniższymi krokami:

1. Utwórz obiekt klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
1. Dodaj wykres na slajdzie.
1. Określ opcje drugiego wykresu.
1. Zapisz prezentację na dysku.

W poniższym przykładzie ustawiliśmy różne właściwości wykresu Pie of Pie.

```c#
// Utwórz instancję klasy Presentation
Presentation presentation = new Presentation();

// Dodaj wykres na slajdzie
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// Ustaw różne właściwości
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// Zapisz prezentację na dysku
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```

## **Ustaw automatyczne kolory wycinków wykresu kołowego**

Aspose.Slides for .NET udostępnia prosty interfejs API do ustawiania automatycznych kolorów wycinków wykresu kołowego. Przykładowy kod zastosowuje ustawienie wyżej wspomnianych właściwości.

1. Utwórz instancję klasy Presentation.
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj wykres z domyślnymi danymi.
1. Ustaw tytuł wykresu.
1. Ustaw pierwszą serię na Pokazywanie wartości.
1. Ustaw indeks arkusza danych wykresu.
1. Pobierz arkusz danych wykresu.
1. Usuń domyślnie wygenerowane serie i kategorie.
1. Dodaj nowe kategorie.
1. Dodaj nowe serie.

Zapisz zmodyfikowaną prezentację do pliku PPTX.

```c#
// Utwórz instancję klasy Presentation reprezentującej plik PPTX
using (Presentation presentation = new Presentation())
{
	// Utwórz instancję klasy Presentation reprezentującej plik PPTX
	Presentation presentation = new Presentation();

	// Uzyskaj dostęp do pierwszego slajdu
	ISlide slides = presentation.Slides[0];

	// Dodaj wykres z domyślnymi danymi
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// Ustawienie tytułu wykresu
	chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// Ustaw pierwszą serię na Pokazywanie wartości
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// Ustawienie indeksu arkusza danych wykresu
	int defaultWorksheetIndex = 0;

	// Pobieranie arkusza danych wykresu
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// Usuń domyślnie wygenerowane serie i kategorie
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// Dodawanie nowych kategorii
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "First Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2nd Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3rd Qtr"));

	// Dodawanie nowych serii
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);

	// Teraz wypełnianie danych serii
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**Czy warianty 'Pie of Pie' i 'Bar of Pie' są obsługiwane?**

Tak, biblioteka [obsługuje](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/charttype/) dodatkowy wykres dla wykresów kołowych, w tym typy 'Pie of Pie' i 'Bar of Pie'.

**Czy mogę wyeksportować sam wykres jako obraz (na przykład PNG)?**

Tak, możesz [wyeksportować sam wykres jako obraz](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/getimage/) (np. PNG) bez całej prezentacji.