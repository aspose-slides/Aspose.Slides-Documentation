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
description: "Dowiedz się, jak dodawać i formatować etykiety danych wykresu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla .NET, aby uzyskać bardziej angażujące slajdy."
---
## **Wprowadzenie**

Etykiety danych wyświetlają informacje o seriach wykresu i pojedynczych punktach danych, pomagając czytelnikom identyfikować wartości i rozumieć wykres. Ten artykuł wyjaśnia, jak formatować wartości, wyświetlać procenty, odczytywać tekst etykiety, kontrolować etykiety poza maksymalnym zakresem osi, regulować odstępy etykiet osi kategorii oraz pozycjonować etykiety wykresu kołowego.

## **Ustaw precyzję danych w etykietach wykresu**

Użyj [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/), aby sformatować wartości serii. Ten przykład tworzy wykres liniowy z domyślnymi danymi, wyświetla jego tabelę danych i włącza etykiety wartości dla pierwszej serii. Format `#,##0.00` wyświetla separator tysięcy i dwa miejsca po przecinku bez zmiany wartości podstawowych.
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

## **Wyświetlanie procentów jako etykiety**

Dla wykresu słupkowego skumulowanego oblicz każdą wartość jako procent całkowitej sumy w swojej kategorii i przypisz tekst do [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). Ten przykład używa domyślnych danych wykresu i wyświetla procenty z dwoma miejscami po przecinku w czcionce o rozmiarze 8 punktów. Kategorie o sumie zerowej są pomijane, aby uniknąć dzielenia przez zero. Przelicz ponownie niestandardowy tekst etykiety, jeśli dane wykresu się zmienią.
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

Gdy wartości są przechowywane jako ułamki, użyj [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/), aby wyświetlać procenty. Ustaw [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) na `false`, aby zastosować format etykiety niezależnie od komórek źródłowych. Ten przykład tworzy wykres słupkowy skumulowany 100 % z czerwonymi i niebieskimi seriami w czterech kategoriach. Każda para wartości sumuje się do 1. Format etykiety `0.0%` wyświetla 0,30 jako 30,0 %, podczas gdy oś pionowa używa dwóch miejsc po przecinku. Obie serie używają białego tekstu etykiety o rozmiarze 10 punktów.
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

## **Odczyt rzeczywistego tekstu etykiet danych**

Użyj [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/), aby pobrać tekst wygenerowany na podstawie ustawień etykiety danych. Jest to przydatne przy wyciąganiu etykiet do raportów, przeszukiwaniu treści prezentacji lub walidacji wygenerowanych wykresów. W poniższym przykładzie domyślny [data label format](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) łączy nazwę każdej kategorii, nazwę serii i wartość. Jeden punkt formatuje swoją wartość jako procent, a inny używa własnego tekstu z [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).
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

Liczba przechowywana w punkcie danych pozostaje `0.75`, nawet gdy jej etykieta pokazuje `75%` wraz z nazwami kategorii i serii. Własny tekst zastępuje wygenerowany tekst etykiety. [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) zwraca powstały ciąg etykiety w obu przypadkach. Sprawdzaj [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) osobno, jak pokazano powyżej, gdy chcesz wyodrębnić tylko widoczne etykiety.

## **Kontrola etykiet danych poza maksymalnym zakresem osi**

Gdy ograniczasz zakres osi ręcznie, niektóre punkty danych mogą przekraczać jej maksimum. Użyj [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/), aby kontrolować, czy ich etykiety danych są wyświetlane. To ustawienie zmienia widoczność etykiet; nie zmienia zakresu osi ani wartości podstawowych danych. Poniższy przykład tworzy dwuwymiarowy skumulowany wykres słupkowy o wartościach 60 i 120. Ustawia [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) na `false` oraz [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) na 100 na osi pionowej. Pierwszy slajd pozwala na etykiety poza maksimum; kopia tego slajdu wyłącza je. Oba slajdy są zapisane w `DataLabelsOverMaximum.pptx`. Włącz etykiety wartości przy użyciu [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). Ustawienie na poziomie wykresu nie włącza wyświetlania wartości samo w sobie ani nie nadpisuje wyłączonego wyświetlania wartości w pojedynczej etykiecie. Ten przykład włącza wartości dla całej serii i używa [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/), aby umieścić etykiety na zewnętrznym końcu każdego słupka.
```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;

var firstCategory = workbook.GetCell(0, 1, 0, "Within range");
var secondCategory = workbook.GetCell(0, 2, 0, "Above maximum");

chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);

var seriesName = workbook.GetCell(0, 0, 1, "Values");
var series = chart.ChartData.Series.Add(seriesName, chart.Type);

var firstValue = workbook.GetCell(0, 1, 1, 60);
var secondValue = workbook.GetCell(0, 2, 1, 120);

series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);

series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;

chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 100;
chart.ShowDataLabelsOverMaximum = true;

var secondSlide = presentation.Slides.AddClone(slide);
var secondChart = (IChart)secondSlide.Shapes[0];
secondChart.ShowDataLabelsOverMaximum = false;

presentation.Save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
```

Poniższe obrazy pokazują zapisane slajdy renderowane przez Microsoft PowerPoint. Przy `true` etykieta **120** jest widoczna przy górnej granicy; przy `false` jest ukryta. Etykieta **60** pozostaje widoczna, maksimum osi pozostaje **100**, a drugi punkt danych pozostaje **120** w obu przypadkach.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![Wykres PowerPoint pokazujący etykietę wartości 120 przy maksymalnym zakresie osi 100](data-labels-over-maximum-true.png) | ![Wykres PowerPoint ukrywający etykietę wartości 120 przy maksymalnym zakresie osi 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Ten przykład używa dwuwymiarowego wykresu słupkowego z osią wartości. Wykresy bez osi wartości, takie jak wykresy kołowe i pierścieniowe, nie mają maksymalnego zakresu osi, który można w ten sposób ograniczyć.
{{% /alert %}}

## **Ustaw odległość etykiety od osi**

Użyj [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/), aby kontrolować odległość między etykietami osi kategorii a osią. Wartość jest procentem maksymalnego rozmiaru czcionki etykiet osi. Ten przykład tworzy wykres słupkowy skumulowany i ustawia przesunięcie etykiety osi poziomej na 500. To ustawienie wpływa na etykiety osi kategorii, a nie na etykiety przypisane do poszczególnych punktów danych.
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

W wykresie kołowym dostosuj pozycje etykiet danych, aby poprawić odstępy i zrobić miejsce dla linii prowadzących. Ten przykład wyświetla wartość pierwszego punktu danych, umieszcza jego etykietę poza wycinką i dostosowuje jej przesunięcia [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) oraz [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/). Te przesunięcia są względne względem szerokości i wysokości wykresu.
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

## **Formatuj linie prowadzące**

Gdy etykiety wykresu kołowego znajdują się poza wycinkami, linie prowadzące pomagają czytelnikom dopasować każdą wartość do właściwej wycinki. Kontrastowy kolor i nieco grubsza linia mogą ułatwić śledzenie tych połączeń, a przezroczystość i styl przerywany sprawiają, że linie są wizualnie mało uciążliwe. Użyj [LeaderLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabelcollection/leaderlinesformat/), aby sformatować linie prowadzące na poziomie kolekcji etykiet danych serii. Ustawienia w `series.Labels.LeaderLinesFormat.Line` dotyczą całej kolekcji, a nie pojedynczej etykiety. Ten przykład tworzy wykres kołowy z domyślnymi danymi, wyświetla wartości poza wycinkami i włącza [ShowLeaderLines](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showleaderlines/). Przesuwa dwie etykiety dalej od ich wycinków przy użyciu przesunięń [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) i [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/), wyrażonych jako ułamki szerokości i wysokości wykresu. Nie wymaga wejściowej prezentacji. Format [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) linii ustawia pełny niebieski kolor z wartością alfa 191 z 255, co daje około 25 % przezroczystości. [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) ustawia grubość na 2 punkty, a [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) sprawia, że linia jest przerywana.
```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 80, 50, 560, 400);
chart.HasLegend = false;

var series = chart.ChartData.Series[0];

var labelFormat = series.Labels.DefaultDataLabelFormat;
labelFormat.ShowValue = true;
labelFormat.Position = LegendDataLabelPosition.OutsideEnd;
labelFormat.ShowLeaderLines = true;

// Przesuń dwie etykiety dalej od ich wycinków.
series.Labels[0].X = 0.10f;
series.Labels[0].Y = -0.05f;
series.Labels[1].X = -0.10f;
series.Labels[1].Y = 0.05f;

var line = series.Labels.LeaderLinesFormat.Line;
line.FillFormat.FillType = FillType.Solid;
line.FillFormat.SolidFillColor.Color = Color.FromArgb(191, 30, 90, 160);
line.Width = 2;
line.DashStyle = LineDashStyle.Dash;

presentation.Save("FormattedLeaderLines.pptx", SaveFormat.Pptx);
```

Włączenie linii prowadzących nie gwarantuje, że linia pojawi się przy każdej etykiecie. Widoczność zależy od położenia etykiety i zachowania układu wykresu. W tym przykładzie dwie przesunięte etykiety mają widoczne linie prowadzące; etykiety pozostające blisko wycinków nie potrzebują ich. Poniższy obraz pokazuje zapisany plik `FormattedLeaderLines.pptx` renderowany przy użyciu Aspose.Slides:
![Wykres kołowy z niebieskimi, półprzezroczystymi, przerywanymi liniami prowadzącymi łączącymi dwie zewnętrzne etykiety z ich wycinkami](formatted-leader-lines.png)

## **Dodaj wiele wierszy etykiet danych nad wykresem słupkowym**

Ten przykład tworzy wykres słupkowy z dwoma wierszami etykiet danych nad obszarem wykresu. Seria A wyświetla widoczne słupki, natomiast Serie B i C dostarczają dodatkowe etykiety. Ich słupki są ukryte poprzez usunięcie wypełnienia i konturu. Właśćiwość [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) wyrównuje wszystkie trzy serie do tych samych środków kategorii. Ustawienia [PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) rezerwują miejsce na wiersze etykiet. Po obliczeniu domyślnych pozycji przez [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/), [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) i [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) zachowują wyrównanie poziome i stosują pionowe przesunięcia, aby rozmieszczyć etykiety w dwóch wierszach. Liczby pozostają etykietami danych powiązanymi z wartościami serii; tylko nagłówki wierszy są oddzielnymi kształtami tekstowymi.
```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 640, 200);
chart.HasTitle = false;
chart.HasLegend = false;
chart.TextFormat.PortionFormat.FontHeight = 12;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

string[] categories = { "North", "South", "East", "West" };
string[] seriesNames = { "Series A", "Series B", "Series C" };
double[,] seriesValues = {
    { 35, 42, 28, 47 },
    { 22, 31, 19, 26 },
    { 12, 16, 14, 18 }
};

for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
{
    var categoryCell = workbook.GetCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
    chart.ChartData.Categories.Add(categoryCell);
}

for (int seriesIndex = 0; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var seriesCell = workbook.GetCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
    var series = chart.ChartData.Series.Add(seriesCell, ChartType.ClusteredColumn);

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var valueCell = workbook.GetCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    if (seriesIndex > 0)
    {
        // Ukryj kolumny B i C, ale zachowaj ich etykiety danych.
        series.Format.Fill.FillType = FillType.NoFill;
        series.Format.Line.FillFormat.FillType = FillType.NoFill;
        var labelFormat = series.Labels.DefaultDataLabelFormat;
        labelFormat.ShowValue = true;
        labelFormat.TextFormat.PortionFormat.FontHeight = 12;
        var labelFill = labelFormat.TextFormat.PortionFormat.FillFormat;
        labelFill.FillType = FillType.Solid;
        labelFill.SolidFillColor.Color = Color.Black;
        labelFormat.Position = LegendDataLabelPosition.InsideBase;
    }
}

// Wyrównaj wszystkie trzy serie do tych samych środków kategorii.
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// Użyj mniejszej liczby linii siatki w tym zwartym przykładzie.
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// Zarezerwuj miejsce nad obszarem wykresu dla dwóch wierszy etykiet danych.
chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;
chart.PlotArea.X = 0.15f;
chart.PlotArea.Y = 0.32f;
chart.PlotArea.Width = 0.80f;
chart.PlotArea.Height = 0.48f;
chart.ValidateChartLayout();

for (int seriesIndex = 1; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    float rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var dataLabel = series.DataPoints[categoryIndex].Label;
        // Zachowaj domyślną pozycję poziomą. Y jest przesunięciem od
        // domyślnej pozycji etykiety, wyrażonego jako ułamek wysokości wykresu.
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // Tylko nagłówek wiersza jest oddzielnym kształtem tekstowym.
    var rowHeading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, chart.X, chart.Y + rowTop * chart.Height, 85, 18);
    rowHeading.FillFormat.FillType = FillType.NoFill;
    rowHeading.LineFormat.FillFormat.FillType = FillType.NoFill;
    rowHeading.AddTextFrame(seriesNames[seriesIndex]);
    rowHeading.TextFrame.TextFrameFormat.MarginTop = 0;
    rowHeading.TextFrame.TextFrameFormat.MarginBottom = 0;
    var headingFormat = rowHeading.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    headingFormat.FontHeight = 12;
    headingFormat.FillFormat.FillType = FillType.Solid;
    headingFormat.FillFormat.SolidFillColor.Color = Color.Black;
}

presentation.Save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
```
![Wykres słupkowy z dwoma wierszami etykiet danych nad obszarem wykresu](multiple-rows-of-labels.png)

## **FAQ**

**Jak mogę zapobiec nakładaniu się etykiet danych na gęstych wykresach?**  
Połącz automatyczne rozmieszczanie etykiet, linie prowadzące i zmniejszoną wielkość czcionki; w razie potrzeby ukryj niektóre pola (np. kategorię) lub wyświetlaj etykiety tylko dla wartości skrajnych lub kluczowych punktów.

**Jak mogę wyłączyć etykiety tylko dla zerowych, ujemnych lub pustych wartości?**  
Przefiltruj punkty danych przed włączeniem etykiet i wyłącz wyświetlanie dla wartości równych 0, wartości ujemnych lub brakujących, zgodnie z określoną regułą.

**Jak zapewnić spójny styl etykiet podczas eksportu do PDF/obrazów?**  
Jawnie ustaw rodzinę i rozmiar czfonty oraz sprawdź, czy czfont jest dostępna w środowisku renderującym, aby uniknąć użycia alternatywy.