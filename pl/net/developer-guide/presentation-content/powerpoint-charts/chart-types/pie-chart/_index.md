---
title: Dostosuj wykresy kołowe w prezentacjach w .NET
linktitle: Wykres kołowy
type: docs
url: /pl/net/pie-chart/
keywords:
- wykres kołowy
- zarządzanie wykresem
- dostosowywanie wykresu
- opcje wykresu
- ustawienia wykresu
- opcje wykresu
- kolor fragmentu
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Twórz i dostosowuj wykresy kołowe w .NET przy użyciu Aspose.Slides. Konfiguruj drugorzędne wykresy, wyświetlaj etykiety danych i stosuj automatyczne kolory fragmentów w programie PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z wykresami kołowymi w Aspose.Slides. Pokazuje, jak skonfigurować opcje drugorzędnego wykresu dla wykresów Pie of Pie i Bar of Pie oraz jak włączyć automatyczne kolorowanie fragmentów w standardowym wykresie kołowym.

Przykłady koncentrują się na zadaniach związanych z dostosowywaniem wykresów, takich jak dodawanie wykresu na slajd, modyfikowanie ustawień serii i etykiet, zastępowanie domyślnych danych wykresu własnymi kategoriami i wartościami oraz zapisywanie zaktualizowanej prezentacji.

## **Opcje drugorzędnego wykresu dla wykresów Pie of Pie i Bar of Pie**

Aspose.Slides dla .NET obsługuje opcje drugorzędnego wykresu dla wykresów Pie of Pie i Bar of Pie. Opcje te kontrolują rozmiar drugorzędnego wykresu oraz sposób podziału punktów danych pomiędzy dwa wykresy.

Poniższy przykład tworzy wykres Pie of Pie w nowej prezentacji i wyświetla wartości punktów danych jako etykiety. Właściwość [SecondPieSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/secondpiesize/) ustawia rozmiar drugorzędnego wykresu na 149 % głównego wykresu. [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitby/) wybiera podział oparty na procentach, a [PieSplitPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitposition/) ustawia próg na 53 %.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
var series = chart.ChartData.Series[0];

// Display values and configure the secondary plot.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.SecondPieSize = 149;
seriesGroup.PieSplitBy = PieSplitType.ByPercentage;
seriesGroup.PieSplitPosition = 53;

presentation.Save("pie_of_pie.pptx", SaveFormat.Pptx);
```

### **Wybierz kategorie dla drugorzędnego wykresu**

Użyj własnego podziału, gdy chcesz grupować określone kategorie w drugorzędnym wykresie niezależnie od ich wartości procentowych. Na przykład raport sprzedaży może pokazywać Online i Events razem, aby czytelnicy mogli porównać te dwa kanały, mimo że stanowią one 35 % i 10 % całkowitej sprzedaży.

Ustaw [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitby/) na [PieSplitType.Custom](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplittype/) i wybierz punkty za pomocą [PieSplitCustomPoints](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitcustompoints/). Metoda [Add](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/add/) kolekcji akceptuje albo indeks zerowy w serii, albo obiekt punktu danych. W tym przykładzie indeks 1 wybiera Online, a punkt pod indeksem 3 wybiera Events. Partners jest również dodany tymczasowo, a następnie wykluczony przy użyciu [Remove](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/remove/).

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 200);

// Zastąp domyślne dane sprzedażą wg kanału.
var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "Retail", "Online", "Partners", "Events" };
var values = new[] { 40, 35, 15, 10 };
var seriesNameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.PieSplitBy = PieSplitType.Custom;
seriesGroup.IsColorVaried = true;

// Wybierz Online według jego indeksu zerowego oraz Events według obiektu punktu danych.
seriesGroup.PieSplitCustomPoints.Add(1);
seriesGroup.PieSplitCustomPoints.Add(series.DataPoints[3]);

// Wyklucz Partners z wyboru bez usuwania jego danych źródłowych.
seriesGroup.PieSplitCustomPoints.Add(2);
seriesGroup.PieSplitCustomPoints.Remove(series.DataPoints[2]);

presentation.Save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
```

Online (35) i Events (10) pojawiają się jako osobne fragmenty w drugorzędnym wykresie. W głównym wykresie są reprezentowane jedną połączoną częścią o wartości 45, obok Retail (40) i Partners (15). Usunięcie Partners z własnego wyboru pozostawia go w głównym wykresie; nie usuwa to kategorii ani jej wartości z danych źródłowych wykresu.

Poniższy obrazek przedstawia zapisaną prezentację w programie PowerPoint:

![Pie of Pie chart with Online and Events in the secondary plot and their combined value of 45 in the primary plot](pie_of_pie_custom.png)

## **Ustaw automatyczne kolory fragmentów wykresu kołowego**

Aspose.Slides dla .NET może automatycznie przypisywać różne kolory fragmentom wykresu kołowego. Poniższy przykład tworzy wykres kołowy z wyśrodkowanym tytułem i zastępuje domyślne dane trzema kwartalnymi kategoriami oraz ich wartościami. Właściwość [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) wyświetla wartości 20, 50 i 30 jako etykiety, natomiast [IsColorVaried](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/iscolorvaried/) umożliwia nadanie odrębnego koloru każdemu fragmentowi.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// Dodaj wyśrodkowany tytuł wykresu.
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// Zastąp domyślne dane używając pierwszego arkusza.
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "First Qtr", "2nd Qtr", "3rd Qtr" };
var values = new[] { 20, 50, 30 };
var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

// Pokaż wartości i przypisz różne kolory fragmentom.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.ParentSeriesGroup.IsColorVaried = true;

presentation.Save("pie.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Czy warianty Pie of Pie i Bar of Pie są obsługiwane?**

Tak, biblioteka [obsługuje](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) drugorzędny wykres dla wykresów kołowych, w tym typy Pie of Pie i Bar of Pie.

**Czy mogę wyeksportować sam wykres jako obraz (na przykład PNG)?**

Tak, możesz [wyeksportować sam wykres jako obraz](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (takie jak PNG) bez eksportowania całej prezentacji.