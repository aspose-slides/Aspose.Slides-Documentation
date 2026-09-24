---
title: Zarządzanie seriami danych wykresu w prezentacjach w .NET
linktitle: Serie danych
type: docs
url: /pl/net/chart-series/
keywords:
- serie wykresu
- nakładanie serii
- kolor serii
- kolor kategorii
- nazwa serii
- punkt danych
- przerwa serii
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak zarządzać seriami wykresu, punktami danych, komórkami skoroszytu, formatowaniem, nakładaniem, szerokością przerwy i wartościami ujemnymi w prezentacjach przy użyciu C#."
---
## **Przegląd**

Wykres przechowuje swoje dane wykreślone w skoroszycie danych wykresu. IChartSeries reprezentuje jeden zestaw powiązanych wartości, a każdy IChartDataPoint w serii odwołuje się do jednej lub kilku komórek skoroszytu. IChartCategory dostarcza etykiety lub wartości grupujące współdzielone przez serie. Nazwa serii, kategorie i wartości punktów są więc połączone z obiektami IChartDataCell, a nie przechowywane wyłącznie jako tekst wyświetlany.

Dla typowego wykresu kategorialnego domyślny skoroszyt używa wiersza 0 do nazw serii, kolumny 0 do nazw kategorii oraz pozostałych komórek do wartości serii. Indeksy arkusza, wiersza i kolumny przekazywane do IChartDataWorkbook.GetCell są zerowe. Ten układ jest przydatny, gdy tworzysz wykres z danymi domyślnymi, ale nie zakładaj, że każdy istniejący wykres go używa. W załadowanej prezentacji sprawdź komórki odwoływane przez serie, kategorie i punkty danych przed zmianą wartości w skoroszycie.

Ustawienia wykresu mają trzy różne zakresy:

- Ustawienia na poziomie serii, takie jak IChartSeries.Format, zapewniają domyślny wygląd wszystkich punktów w jednej serii.  
- Ustawienia punktu danych, takie jak IChartDataPoint.Format, nadpisują wygląd serii dla jednego punktu.  
- Ustawienia grupy dotyczą zgodnych serii, które należą do tej samej IChartSeriesGroup. Dostęp do grupy uzyskujesz poprzez IChartSeries.ParentSeriesGroup, gdy potrzebujesz ustawić opcje takie jak overlap lub szerokość przerwy.

Gdy nie jest ustawione żadne explicite wypełnienie punktu lub serii, styl wykresu i motyw określają automatyczny wygląd. Gdy istnieje zarówno formatowanie serii, jak i punktu, formatowanie punktu ma pierwszeństwo dla tego punktu.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ustaw nakładanie serii wykresu**

[IChartSeries.Overlap](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartseries/overlap/) raportuje, jak bardzo paski lub kolumny nakładają się na siebie w wykresie 2D, w przedziale od -100 do 100 procent. Jest to odczytywalna projekcja ustawienia na grupę serii nadrzędną. Ustaw [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartseriesgroup/overlap/), aby zaktualizować każdą zgodną serię w tej grupie. Opcja ta ma zastosowanie do typów wykresów wyświetlających grupowane paski lub kolumny; nie wpływa na niepowiązane grupy serii w wykresie kombinowanym.

Przykład ustawiający nakładanie dla grupy zawierającej pierwszą serię:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// Nowy wykres zawiera przykładowe serie, kategorie i wartości.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

Wynik:

![The series overlap](series_overlap.png)

## **Zmień kolor wypełnienia serii**

Użyj [IChartSeries.Format](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartseries/format/), aby ustawić domyślne wypełnienie dla całej serii. Jeśli punkt ma już explicite wypełnienie, jego ustawienie [IChartDataPoint.Format](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatapoint/format/) nadpisuje wypełnienie serii dla tego punktu.

Przykład stosujący jednolite niebieskie wypełnienie do pierwszej serii:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Blue;

presentation.Save("series_color.pptx", SaveFormat.Pptx);
```

Wynik:

![The color of the series](series_color.png)

## **Zmień nazwę serii**

Nazwa serii jest przechowywana w skoroszycie danych wykresu i zwykle wyświetlana w legendzie. W domyślnym skoroszycie utworzonym dla wykresu kolumnowego grupowanego komórka B1 znajduje się w wierszu 0, kolumnie 1 i zawiera nazwę pierwszej serii. Stałe nazwane w poniższym przykładzie wyraźnie opisują tę strukturę:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesNameCell = workbook.GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

Możesz także zaktualizować komórkę już odwoływaną przez [IChartSeries.Name](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartseries/name/). To podejście unika zakładania konkretnego wiersza i kolumny w istniejącym wykresie:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var seriesNameCell = series.Name.AsCells[firstNameCellIndex];
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

Wynik:

![The series name](series_name.png)

## **Pobierz automatyczny kolor wypełnienia serii**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) zwraca kolor obliczony na podstawie indeksu serii i stylu wykresu. Jest to kolor używany, gdy wypełnienie serii nie zostało explicite zdefiniowane. Wywołanie metody odczytuje obliczony kolor; nie przypisuje nowego wypełnienia.

Przykład wypisujący automatyczny kolor każdej domyślnej serii:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

const int firstSlideIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var seriesCount = chart.ChartData.Series.Count;
for (var seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    var automaticColor = series.GetAutomaticSeriesColor();
    Console.WriteLine($"Series {seriesIndex}: {automaticColor.Name}");
}
```

Przykładowe wyjście dla domyślnego stylu wykresu:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Dokładne kolory zależą od stylu i motywu wykresu.

## **Ustaw odwrócony kolor wypełnienia dla serii wykresu**

Dla serii paskowych, kolumnowych i bąbelkowych [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartseries/invertifnegative/) może wyświetlać wartości ujemne innym wypełnieniem. Ustaw regularne wypełnienie serii na jednolite, włącz odwracanie i przypisz kolor wartości ujemnej za pomocą [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Liczby ujemne pozostają niezmienione w skoroszycie; zmienia się tylko ich kolor wyświetlania.

Przykład zamieniający domyślne dane wykresu na jedną serię. Wiersz arkusza 0 zawiera nazwę serii, kolumna 0 – nazwy kategorii, a kolumna 1 – wartości:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;

var categoryNames = new[] { "Category 1", "Category 2", "Category 3" };
var seriesValues = new[] { -20, 50, -30 };

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
var series = chartData.Series.Add(seriesNameCell, chart.Type);

for (var categoryIndex = 0; categoryIndex < categoryNames.Length; categoryIndex++)
{
    var dataRowIndex = firstDataRowIndex + categoryIndex;
    var categoryName = categoryNames[categoryIndex];
    var seriesValue = seriesValues[categoryIndex];

    var categoryCell = workbook.GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
    chartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertIfNegative = true;
series.InvertedSolidFillColor.Color = Color.Red;

presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
```

Wynik:

![The inverted solid fill color](inverted_solid_fill_color.png)

Możesz włączyć odwracanie dla jednego punktu poprzez [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). W poniższym przykładzie odwracanie jest wyłączone dla serii i włączone tylko dla wybranego punktu. Punkt otrzymuje także wartość ujemną, aby efekt był widoczny:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertedSolidFillColor.Color = Color.Red;
series.InvertIfNegative = false;

var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = negativeValue;
dataPoint.InvertIfNegative = true;

presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
```

## **Wyczyść konkretną wartość punktu danych**

Aby uczynić jeden punkt pustym bez usuwania pozostałych punktów, ustaw jego komórkę w skoroszycie na `null`. Dla wykresu kolumnowego wartość wykreślana jest dostępna przez [IChartDataPoint.YValue](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatapoint/yvalue/). Punkt danych pozostaje na tej samej pozycji kategorii, ale wykres traktuje jego wartość jako pustą zgodnie z ustawieniami pustych wartości wykresu.

Przykład czyszczący tylko drugi punkt w pierwszej serii:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = null;

presentation.Save("clear_data_point_value.pptx", SaveFormat.Pptx);
```

Wykresy punktowe używają oddzielnych komórek X i Y, a wykresy bąbelkowe także komórki rozmiaru. Wyczyść tylko tę komórkę, która reprezentuje wartość, którą chcesz usunąć. Nie wywołuj [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatapointcollection/clear/), gdy chcesz zachować pozostałe punkty, ponieważ metoda ta usuwa wszystkie punkty danych z kolekcji.

## **Kontroluj wyświetlanie pustych komórek**

Pusta komórka skoroszytu oznacza brak danych; komórka zawierająca `0` oznacza znaną wartość liczbową. Ustaw [IChartDataCell.Value](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatacell/value/) na `null`, aby uczynić komórkę pustą. Liczba zero pozostaje zerem niezależnie od ustawienia pustej komórki.

Użyj [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichart/displayblanksas/), aby wybrać, jak wykres wyświetla puste komórki. To ustawienie ma zastosowanie do całego wykresu. Zmienia sposób wykreślania pustych miejsc, nie wypełniając pustej komórki w skoroszycie zerem ani interpolowaną wartością.

Samodzielny przykład tworzy wykres liniowy z jedną serią, czyści wartość dla Dnia 3 i zapisuje wykres w każdym trybie. Nie wymaga pliku wejściowego. IChartDataWorkbook używa arkusza 0, kolumny 0 do etykiet kategorii i kolumny 1 do wartości; wiersz 0 przechowuje nazwę serii. Końcowe dane to `10, 20, empty, 30, 40`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(0, 0, 1, "Measurements");
var series = chartData.Series.Add(seriesNameCell, chart.Type);
var values = new[] { 10, 20, 25, 30, 40 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Day {i + 1}");
    chartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Zostaw dzień 3 naprawdę pusty, zachowując jego kategorię i punkt danych.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

Każdy plik wyjściowy przechowuje tryb przypisany przed zapisem: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` i `empty_cells_Span.pptx`. Aby zapisać tylko jedną wersję, ustaw żądany tryb i zapisz prezentację raz, zamiast iterować po trybach.

Porównanie poniżej pokazuje te same dane w trzech plikach. Dzień 3 jest pusty w skoroszycie we wszystkich przypadkach:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Widoczny efekt zależy od typu wykresu. Wykres liniowy ułatwia porównanie wszystkich trzech trybów. Wykresy paskowe i kolumnowe nie mają linii łączącej brakującą kategorię, więc `Span` nie może stworzyć segmentu łączącego, jak pokazano powyżej; brakująca kolumna i kolumna o wysokości zero mogą wyglądać podobnie. Podobnie wykres punktowy z jedynie znacznikami nie ma linii łączącej. Nie oczekuj trzech odrębnych wyników dla każdego typu wykresu; sprawdź wyjście dla używanego typu.

## **Ustaw szerokość przerwy serii**

Szerokość przerwy to odstęp między sąsiadującymi grupami pasków lub kolumn, wyrażony jako procent szerokości paska lub kolumny. Podobnie jak nakładanie, należy do grupy serii nadrzędnej, a nie do jednej serii. Ustaw [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) raz dla grupy. Większa wartość tworzy więcej miejsca między grupami; mniejsza wartość powoduje ich większą gęstość.

Przykład zmieniający szerokość przerwy i zapisujący tylko ostateczną prezentację:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int gapWidthPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.GapWidth = gapWidthPercent;

presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
```

Wynik:

![The gap width](gap_width.png)

## **FAQ**

**Które typy wykresów obsługują serie danych?**

Wszystkie typy wykresów reprezentowane przez wyliczenie [ChartType](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/charttype/) używają danych wykresu, ale ich serie nie mają takiej samej struktury wartości ani ustawień. Na przykład wykresy kategorialne używają kategorii i wartości, wykresy punktowe X i Y, a wykresy bąbelkowe dodatkowo rozmiary bąbelka. Używaj metody tworzenia punktu danych odpowiadającej typowi serii. Opcje takie jak nakładanie i szerokość przerwy mają zastosowanie wyłącznie do zgodnych grup pasków lub kolumn.

**Czym jest grupa serii wykresu?**

[IChartSeriesGroup](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartseriesgroup/) zawiera kompatybilne serie, które współdzielą ustawienia poziomu grupy. Wykres kombinowany może zawierać więcej niż jedną grupę, więc zmiana grupy osiągnięta przez jedną serię niekoniecznie zmienia wszystkie serie w wykresie.

**Czy nowo utworzony wykres zawiera domyślne dane?**

Tak. Domyślnie [IShapeCollection.AddChart](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/addchart/) tworzy przykładowe serie, kategorie i wartości. Możesz edytować te komórki lub wyczyścić zarówno kolekcje serii, jak i kategorii przed dodaniem własnego zestawu danych. Przeciążenie może także utworzyć wykres bez domyślnych danych.

**Jak obiekty wykresu są połączone z komórkami skoroszytu?**

Nazwy serii, etykiety kategorii i wartości punktów danych odwołują się do komórek w [IChartDataWorkbook](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdataworkbook/). Zmiana odwoływanej komórki aktualizuje odpowiedni element wykresu. Tworząc własne dane, utrzymuj wiersze kategorii i wiersze wartości serii wyrównane, aby każdy punkt był wykreślony pod właściwą kategorią.

**Jak wyczyścić jeden punkt zamiast całej serii?**

Ustaw odpowiednią komórkę wartości na `null`, aby zachować pozycję kategorii punktu jako pusty punkt. Używaj [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatapointcollection/clear/) tylko wtedy, gdy chcesz usunąć wszystkie punkty z danej serii. Jeśli usuwasz także kategorie, zaktualizuj wszystkie serie, aby ich wartości pozostały wyrównane z kolekcją kategorii.

**Jak wyświetlane są puste punkty?**

Wynik zależy od typu wykresu i [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichart/displayblanksas/). Obsługiwane wykresy mogą wyświetlać luki, wartości zero lub łączyć sąsiednie punkty. Wybierz ustawienie odpowiadające znaczeniu brakujących danych w prezentacji. Zobacz „Kontroluj wyświetlanie pustych komórek” po kompletny przykład i porównanie wizualne.

**Jak formatowane są wartości ujemne?**

Dla obsługiwanych serii paskowych, kolumnowych i bąbelkowych włącz [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartseries/invertifnegative/) i ustaw [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Zachowanie można nadpisać dla pojedynczego punktu za pomocą [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Właściwości te wpływają na formatowanie, a nie na przechowywane wartości liczbowe.

**Które formatowanie wygrywa, gdy zarówno seria, jak i punkt są formatowane?**

Explicite formatowanie punktu danych ma pierwszeństwo dla tego punktu. Inne punkty kontynuują używanie explicite formatu serii lub, gdy format serii nie jest zdefiniowany, automatycznego stylu wykresu i motywu. Właściwości grupy, takie jak nakładanie i szerokość przerwy, kontrolują układ i nie są nadpisaniami formatowania poziomu punktu.

**Czy istnieje limit liczby serii, które wykres może zawierać?**

Aspose.Slides nie narzuca oddzielnego stałego limitu liczby serii. W praktyce ograniczenia wynikają z rozmiaru pliku prezentacji, dostępnej pamięci, czasu renderowania i czytelności wykresu.

**Co zmienić, gdy kolumny są za blisko siebie lub zbyt daleko?**

Ustaw [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) na odpowiedniej grupie serii nadrzędnej. Zwiększ wartość, aby poszerzyć przestrzeń między grupami, lub zmniejsz ją, aby przybliżyć grupy.