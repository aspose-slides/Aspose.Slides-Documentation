---
title: Dodaj linie trendu do wykresów w prezentacji w .NET
linktitle: Linia trendu
type: docs
url: /pl/net/trend-line/
keywords:
- wykres
- linia trendu
- wykładnicza linia trendu
- liniowa linia trendu
- logarytmiczna linia trendu
- linia trendu średniej kroczącej
- wielomianowa linia trendu
- potęgowa linia trendu
- własna linia trendu
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Szybko dodaj i dostosuj linie trendu w wykresach PowerPoint przy użyciu Aspose.Slides dla .NET — praktyczny przewodnik, aby przyciągnąć uwagę odbiorców."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dodać linie trendu do wykresów w prezentacji przy użyciu Aspose.Slides. Pokazuje, jak utworzyć wykres, dodać linie trendu do serii wykresu oraz pracować z kilkoma typami linii trendu, w tym wykładniczą, liniową, logarytmiczną, średnią kroczącą, wielomianową i potęgową.

Opisuje także, jak dodać własną linię do wykresu poprzez wstawienie kształtu linii, oraz zawiera krótkie FAQ dotyczące wartości projekcji linii trendu w przód i w tył oraz tego, czy linie trendu są zachowywane podczas eksportu do PDF lub SVG i przy renderowaniu wykresów jako obrazy.

## **Dodaj linię trendu**

Użyj [ITrendlineCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendlinecollection/add/) aby dodać linię trendu do serii wykresu, wybierając jej typ za pomocą [TrendlineType](https://reference.aspose.com/slides/net/aspose.slides.charts/trendlinetype/). Przykład tworzy skumulowany wykres słupkowy z domyślnymi danymi i dodaje dwie linie trendu do każdej z trzech serii.

Linia trendu wykładnicza ukrywa równanie i wartość R‑kwadrat za pomocą [DisplayEquation](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayequation/) i [DisplayRSquaredValue](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayrsquaredvalue/), podczas gdy linia trendu liniowa jest czerwona. Linia trendu logarytmiczna używa [AddTextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/addtextframeforoverriding/) do własnej etykiety. Średnia krocząca używa [Period](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/period/) równą trzem punktom danych oraz własnej [TrendlineName](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/trendlinename/).

Linia trendu wielomianowa ma [Order](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/order/) równą trzem i rozciąga jedną kategorię w przód za pomocą [Forward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/forward/). Linia trendu potęgowa rozciąga jedną kategorię w tył za pomocą [Backward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/backward/).

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

var firstSeries = chart.ChartData.Series[0];

var exponentialTrendline = firstSeries.TrendLines.Add(TrendlineType.Exponential);
exponentialTrendline.DisplayEquation = false;
exponentialTrendline.DisplayRSquaredValue = false;

var linearTrendline = firstSeries.TrendLines.Add(TrendlineType.Linear);
linearTrendline.Format.Line.FillFormat.FillType = FillType.Solid;
linearTrendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

var secondSeries = chart.ChartData.Series[1];

var logarithmicTrendline = secondSeries.TrendLines.Add(TrendlineType.Logarithmic);
logarithmicTrendline.AddTextFrameForOverriding("New log trend line");

var movingAverageTrendline = secondSeries.TrendLines.Add(TrendlineType.MovingAverage);
movingAverageTrendline.Period = 3;
movingAverageTrendline.TrendlineName = "New TrendLine Name";

var thirdSeries = chart.ChartData.Series[2];

var polynomialTrendline = thirdSeries.TrendLines.Add(TrendlineType.Polynomial);
polynomialTrendline.Forward = 1;
polynomialTrendline.Order = 3;

var powerTrendline = thirdSeries.TrendLines.Add(TrendlineType.Power);
powerTrendline.Backward = 1;

presentation.Save("ChartTrendLines.pptx", SaveFormat.Pptx);
```

## **Ustaw przecięcie linii trendu**

Użyj [Intercept](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/intercept/) aby ustawić wartość Y linii trendu przy X = 0. To ustawienie jest obsługiwane dla linii trendu liniowych, wykładniczych i wielomianowych.

Na przykład model kosztów produkcji może wymagać rozpoczęcia od znanych stałych kosztów w wysokości 100, nawet gdy pomiary przy niezerowych wolumenach produkcji sugerują inną bazę. Dla linii trendu liniowej, ustalenie interceptu ogranicza równanie `y = ax + b` do `b = 100`; nachylenie jest dopasowywane do danych przy tym ograniczeniu. Nie powoduje to po prostu przesunięcia już dopasowanej linii. Ustawienia przecięcia osi kontrolują, gdzie osie wykresu się spotykają, a nie współczynniki dopasowanej linii trendu.

Przykład poniżej tworzy wykres rozrzutu (XY) z wolumenami produkcji od 1 do 4 oraz kosztami 170, 200, 230 i 260. Zapisuje wykres z domyślnym automatycznym interceptem, ustawia intercept na 100 i zapisuje drugi plik PPTX. Dwa pliki różnią się wyłącznie ustawieniem interceptu. Linia trendu wyświetla swoje równanie i rozciąga się do X = 0.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var nameCell = workbook.GetCell(0, 0, 1, "Production cost");
var series = chart.ChartData.Series.Add(nameCell, ChartType.ScatterWithMarkers);
double[] costs = { 170, 200, 230, 260 };

for (var i = 0; i < costs.Length; i++)
{
    var xCell = workbook.GetCell(0, i + 1, 0, i + 1);
    var yCell = workbook.GetCell(0, i + 1, 1, costs[i]);
    series.DataPoints.AddDataPointForScatterSeries(xCell, yCell);
}

var trendline = series.TrendLines.Add(TrendlineType.Linear);
trendline.DisplayEquation = true;
trendline.Backward = 1;

presentation.Save("AutomaticIntercept.pptx", SaveFormat.Pptx);

trendline.Intercept = 100;
presentation.Save("FixedIntercept.pptx", SaveFormat.Pptx);
```

Przy automatycznym obliczaniu, te dane dają `y = 30x + 140`. Ustawienie interceptu na 100 daje natomiast około `y = 43.33x + 100`: dopasowana wartość przy zerze odpowiada znanej bazie, a linia nie przechodzi już przez każdy punkt danych.

| Automatyczny intercept | Stały intercept 100 |
| --- | --- |
| ![Linia trendu liniowa z automatycznie obliczonym interceptem 140](intercept-automatic.png) | ![Linia trendu liniowa ze stałym interceptem 100](intercept-fixed.png) |

Oba obrazy używają tych samych danych i skal osi. Linie trendu są rozciągnięte do X = 0, aby pokazać ich intercepty.

Domyślnie właściwość zawiera `double.NaN`, co oznacza nieokreślony intercept, a nie zero. Intercept jest wtedy obliczany automatycznie na podstawie danych.

## **Dodaj własną linię**

Własna linia to kształt narysowany nad wykresem, a nie linia trendu obliczana na podstawie danych serii. Ten przykład używa [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) aby dodać poziomą linię do slajdu nad wykresem. Pozycja linii jest określona w koordynatach slajdu, mierzona w punktach, więc zaczyna się od lewej krawędzi wykresu i znajduje się w połowie wysokości wykresu. Jej szerokość jest równa szerokości wykresu. [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) nadaje linii jednolity czerwony kolor.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

var line = slide.Shapes.AddAutoShape(ShapeType.Line, chart.X, chart.Y + chart.Height / 2, chart.Width, 0);
line.LineFormat.FillFormat.FillType = FillType.Solid;
line.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("AddCustomLines.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Co oznaczają „forward” i „backward” w kontekście linii trendu?**

Są to długości linii trendu projekowane w przód lub w tył: dla wykresów rozrzutu (XY) — w jednostkach osi; dla wykresów innych niż rozrzut — w liczbie kategorii. Dozwolone są tylko wartości nieujemne.

**Czy linia trendu będzie zachowana przy eksportowaniu prezentacji do PDF lub SVG, lub przy renderowaniu slajdu jako obrazu?**

Tak. Aspose.Slides konwertuje prezentacje do [PDF](/slides/pl/net/convert-powerpoint-to-pdf/) lub [SVG](/slides/pl/net/render-a-slide-as-an-svg-image/) i renderuje wykresy jako obrazy; linie trendu, jako część wykresu, są zachowywane podczas tych operacji. Dostępna jest również metoda do [wyeksportowania obrazu wykresu](/slides/pl/net/create-shape-thumbnails/).