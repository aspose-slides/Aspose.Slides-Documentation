---
title: Zarządzanie etykietami danych wykresu w prezentacjach w .NET
linktitle: Etykieta danych
type: docs
url: /pl/net/chart-data-label/
keywords:
- wykres
- etykieta danych
- precyzja danych
- procent
- odległość etykiety
- położenie etykiety
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak dodawać i formatować etykiety danych wykresu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla .NET, aby uzyskać bardziej atrakcyjne slajdy."
---
## **Wstęp**

Etykiety danych wyświetlają informacje o seriach wykresu i poszczególnych punktach danych, pomagając czytelnikom rozpoznawać wartości i rozumieć wykres. Ten artykuł wyjaśnia, jak formatować wartości, wyświetlać procenty, odczytywać tekst etykiet, regulować odstępy etykiet osi kategorii oraz pozycjonować etykiety wykresów kołowych.

## **Ustaw precyzję danych w etykietach wykresu**

Użyj [NumberFormatOfValues](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartseries/numberformatofvalues/), aby sformatować wartości serii. Ten przykład tworzy wykres liniowy z domyślnymi danymi, wyświetla jego tabelę danych i włącza etykiety wartości dla pierwszej serii. Format `#,##0.00` wyświetla separator tysięcy i dwie miejsca po przecinku, nie zmieniając przy tym wartości podstawowych.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
chart.HasDataTable = true;

var series = chart.ChartData.Series[0];
series.NumberFormatOfValues = "#,##0.00";
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
```

## **Wyświetl procent jako etykiety**

W przypadku wykresu kolumnowego skumulowanego, oblicz każdą wartość jako procent sumy w swojej kategorii i przypisz tekst do [TextFrameForOverriding](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). Ten przykład używa domyślnych danych wykresu i wyświetla procenty z dwoma miejscami po przecinku w czcionce 8 punktów. Kategorie o sumie zerowej są pomijane, aby uniknąć dzielenia przez zero. Przelicz tekst etykiety niestandardowej, jeśli dane wykresu ulegną zmianie.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);

var categoryTotals = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        var series = chart.ChartData.Series[i];
        var pointValue = Convert.ToDouble(series.DataPoints[k].Value.Data);
        categoryTotals[k] += pointValue;
    }
}

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    var series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        var label = series.DataPoints[j].Label;
        if (categoryTotals[j] == 0)
        {
            continue;
        }

        var pointValue = Convert.ToDouble(series.DataPoints[j].Value.Data);
        var dataPointPercent = (pointValue / categoryTotals[j]) * 100;

        var portion = new Portion();
        portion.Text = string.Format("{0:F2} %", dataPointPercent);
        portion.PortionFormat.FontHeight = 8f;

        label.TextFrameForOverriding.Text = "";

        var paragraph = label.TextFrameForOverriding.Paragraphs[0];
        paragraph.Portions.Add(portion);

        label.DataLabelFormat.ShowValue = true;
        label.DataLabelFormat.ShowSeriesName = false;
        label.DataLabelFormat.ShowPercentage = false;
        label.DataLabelFormat.ShowLegendKey = false;
        label.DataLabelFormat.ShowCategoryName = false;
        label.DataLabelFormat.ShowBubbleSize = false;
    }
}

presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **Ustaw znak procenta w etykietach danych wykresu**

Gdy wartości są przechowywane jako ułamki, użyj [NumberFormat](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/idatalabelformat/numberformat/), aby wyświetlać procenty. Ustaw [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) na `false`, aby zastosować format etykiety niezależnie od komórek źródłowych.

Ten przykład tworzy wykres kolumnowy skumulowany 100% z serią czerwoną i niebieską w czterech kategoriach. Każda para wartości sumuje się do 1. Format etykiety `0.0%` wyświetla 0.30 jako 30,0%, podczas gdy oś pionowa używa dwóch miejsc po przecinku. Obie serie używają białego tekstu etykiety o rozmiarze 10 punktów.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
int worksheetIndex = 0;
for (int i = 0; i < 4; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

string[] seriesNames = { "Reds", "Blues" };
Color[] seriesColors = { Color.Red, Color.Blue };
double[,] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

for (int i = 0; i < seriesNames.Length; i++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, i + 1, seriesNames[i]);
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);
    for (int j = 0; j < 4; j++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, j + 1, i + 1, values[i, j]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColors[i];

    var labelFormat = series.Labels.DefaultDataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = false;
    labelFormat.NumberFormat = "0.0%";
    labelFormat.TextFormat.PortionFormat.FontHeight = 10;
    labelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
}

presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **Odczytaj rzeczywisty tekst etykiet danych**

Użyj [GetActualLabelText](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/idatalabel/getactuallabeltext/), aby pobrać tekst generowany przez ustawienia etykiety danych. Jest to przydatne przy wyodrębnianiu etykiet do raportów, przeszukiwaniu treści prezentacji lub weryfikacji wygenerowanych wykresów. W poniższym przykładzie domyślny [format etykiety danych](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/idatalabelformat/) łączy nazwę każdej kategorii, nazwę serii oraz wartość. Jeden punkt formatuje swoją wartość jako procent, a inny używa tekstu niestandardowego z [TextFrameForOverriding](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Q1"));
chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Q2"));

var north = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "North"), chart.Type);
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 0.25));
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 0.75));

var south = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "South"), chart.Type);
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 0.40));
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 0.60));

foreach (var series in chart.ChartData.Series)
{
    var format = series.Labels.DefaultDataLabelFormat;
    format.ShowCategoryName = true;
    format.ShowSeriesName = true;
    format.ShowValue = true;
}

north.Labels[1].DataLabelFormat.IsNumberFormatLinkedToSource = false;
north.Labels[1].DataLabelFormat.NumberFormat = "0%";
south.Labels[0].TextFrameForOverriding.Text = "Reviewed";

foreach (var series in chart.ChartData.Series)
{
    foreach (var point in series.DataPoints)
    {
        var label = point.Label;
        if (!label.IsVisible)
        {
            continue;
        }

        Console.WriteLine($"Value: {point.Value.Data}; label: {label.GetActualLabelText()}");
    }
}
```

Liczba przechowywana w punkcie danych pozostaje `0.75`, nawet gdy jego etykieta wyświetla `75%` wraz z nazwą kategorii i serii. Tekst niestandardowy zastępuje wygenerowany tekst etykiety. [GetActualLabelText](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/idatalabel/getactuallabeltext/) zwraca powstały ciąg etykiety w obu przypadkach. Sprawdzaj [IsVisible](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/idatalabel/isvisible/) osobno, jak pokazano powyżej, gdy chcesz wyodrębnić tylko widoczne etykiety.

## **Ustaw odległość etykiety od osi**

Użyj [LabelOffset](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/iaxis/labeloffset/), aby kontrolować odległość między etykietami osi kategorii a samą osią. Wartość jest procentem maksymalnego rozmiaru czcionki etykiet osi. Ten przykład tworzy wykres kolumnowy grupowany i ustawia przesunięcie etykiety osi poziomej na 500. To ustawienie wpływa na etykiety osi kategorii, a nie na etykiety przypisane do poszczególnych punktów danych.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
chart.Axes.HorizontalAxis.LabelOffset = 500;

presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **Dostosuj położenie etykiety**

W wykresie kołowym dostosuj pozycje etykiet danych, aby poprawić odstępy i zrobić miejsce na linie prowadzące.

Ten przykład wyświetla wartość pierwszego punktu danych, umieszcza jego etykietę poza wycinkiem i dostosowuje przesunięcia w [X](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ilayoutable/x/) i [Y](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ilayoutable/y/). Te przesunięcia są względne względem szerokości i wysokości wykresu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);
var series = chart.ChartData.Series;

var label = series[0].Labels[0];
label.DataLabelFormat.ShowValue = true;
label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
label.X = 0.71f;
label.Y = 0.04f;

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

![Wykres kołowy z dostosowaną pozycją etykiety danych](pie-chart-adjusted-label.png)

## **FAQ**

**Jak mogę zapobiec nakładaniu się etykiet danych na gęstych wykresach?**

Połącz automatyczne rozmieszczanie etykiet, linie prowadzące i zmniejszoną wielkość czcionki; w razie potrzeby ukryj niektóre pola (np. kategorię) lub wyświetlaj etykiety tylko dla wartości skrajnych lub kluczowych punktów.

**Jak mogę wyłączyć etykiety tylko dla wartości zerowych, ujemnych lub pustych?**

Przefiltruj punkty danych przed włączeniem etykiet i wyłącz wyświetlanie dla wartości równych 0, wartości ujemnych lub brakujących, zgodnie z określoną regułą.

**Jak mogę zapewnić spójny styl etykiet przy eksportowaniu do PDF/obrazów?**

Ustaw explicite rodzinę i rozmiar czcionki oraz zweryfikuj, że czcionka jest dostępna w środowisku renderowania, aby uniknąć jej zastąpienia.