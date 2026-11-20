---
title: Dostosowywanie osi wykresu w prezentacjach .NET
linktitle: Oś wykresu
type: docs
url: /pl/net/chart-axis/
keywords:
- oś wykresu
- oś pionowa
- oś pozioma
- dostosuj oś
- manipuluj osią
- zarządzaj osią
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
description: "Poznaj sposób użycia Aspose.Slides dla .NET do dostosowywania osi wykresów w prezentacjach PowerPoint w raportach i wizualizacjach."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować osie wykresów przy użyciu Aspose.Slides dla .NET. Obejmuje on obliczone wartości osi, zamianę wierszy i kolumn wykresu, widoczność osi, interwały etykiet kategorii i znaczników podziałek, kategorie dat i ich formatowanie, obrót tytułu, pozycjonowanie osi, jednostki wyświetlania oraz skalowanie logarytmiczne.

## **Uzyskaj maksymalne wartości na pionowej osi wykresów**

Utwórz [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) i dodaj wykres powierzchniowy z domyślnymi danymi. Wywołaj [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) przed odczytaniem obliczonych wartości osi, aby układ wykresu był aktualny.

Odczytaj [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) i [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) dla granic osi oraz [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) i [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) dla interwałów podziałek. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) i [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) dostarczają skali jednostek czasu, co ma znaczenie dla osi dat. Przykład zapisuje te wartości w zmiennych lokalnych i zapisuje wykres.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
chart.ValidateChartLayout();

var maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
var minValue = chart.Axes.VerticalAxis.ActualMinValue;

var majorUnit = chart.Axes.VerticalAxis.ActualMajorUnit;
var minorUnit = chart.Axes.VerticalAxis.ActualMinorUnit;

var majorUnitScale = chart.Axes.VerticalAxis.ActualMajorUnitScale;
var minorUnitScale = chart.Axes.VerticalAxis.ActualMinorUnitScale;

presentation.Save("AxisValues_out.pptx", SaveFormat.Pptx);
```

## **Zamień dane między osiami**

Użyj [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) aby wymienić role serii i kategorii w danych wykresu. Każda poprzednia kategoria staje się serią, a każda poprzednia seria staje się kategorią. Zmienia to sposób grupowania danych; nie zamienia osi poziomej i pionowej. Przykład używa [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) aby powiązać domyślne dane z `Sheet1!A1:D5`, włączając wiersz nagłówka i kolumnę kategorii, przed zamianą wierszy i kolumn. Zapisuje wykres z czterema seriami i trzema kategoriami.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

chart.ChartData.SetRange("Sheet1!A1:D5");
chart.ChartData.SwitchRowColumn();

presentation.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
```

## **Odwróć kolejność rysowania osi**

Użyj [IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) aby odwrócić oś kategorii lub wartości. Na przykład wykres słupkowy poziomy może wyświetlać etapy projektu od góry do dołu w takiej samej kolejności jak arkusz: Planning, Development, Testing. Odwrócenie osi zmienia kierunek rysowania; nie sortuje ani nie przestawia danych w skoroszycie. Dla porównania, [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) wymienia role serii i kategorii.

Poniższy przykład tworzy wykres słupkowy poziomy z trzema etapami i jedną serią. Zapisuje prezentację z trzema slajdami: normalna kolejność, odwrócone kategorie i odwrócone wartości. Każda kopia używa tego samego zestawu danych, a na każdej kopii odwrócona jest tylko jedna oś.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredBar, 50, 40, 620, 320);
chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredBar);
var stages = new[] { "Planning", "Development", "Testing" };
var values = new[] { 10, 30, 20 };
for (var i = 0; i < stages.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, stages[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

// Slajd 2: wyświetl pierwszą kategorię na górze.
var categorySlide = presentation.Slides.AddClone(slide);
var categoryChart = (IChart)categorySlide.Shapes[0];
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// Utrzymaj poziomą oś wartości na dole.
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// Slajd 3: odwróć tylko poziomą skalę numeryczną.
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

Odwrócenie osi może również przenieść prostopadłą oś na przeciwległą stronę wykresu. [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) kontroluje, gdzie druga oś przecina konfigurowaną oś. Na slajdzie 2 ustawienie jej na `Maximum` na odwróconej osi kategorii utrzymuje poziomą oś wartości u dołu. Aby określić konkretny punkt przecięcia, użyj [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Sprawdź ustawienia przecięcia przy zmianie kierunku, szczególnie jeśli wykres ma już własny punkt przecięcia. Ustaw `IsPlotOrderReversed` z powrotem na `false`, aby przywrócić normalny kierunek rysowania; ustawienia przecięcia są odrębne.

| Normalna kolejność (slajd 1) | Odwrócone kategorie (slajd 2) | Odwrócone wartości (slajd 3) |
| --- | --- | --- |
| ![Wykres słupkowy poziomy z normalnym porządkiem osi kategorii i wartości](axis-order-normal.png) | ![Wykres słupkowy poziomy z kategoriami wyświetlanymi od góry do dołu](axis-order-categories-reversed.png) | ![Wykres słupkowy poziomy z odwróconą osią wartości i zerem po prawej](axis-order-values-reversed.png) |
| Kategorie rosną od dołu do góry; wartości zwiększają się od lewej do prawej. | Planning, Development i Testing przebiegają od góry do dołu. Wartości i kolejność wierszy w skoroszycie pozostają niezmienione. | Kategorie zachowują swój normalny porządek; wartości rosną od prawej do lewej. Oś kategorii przecina zero po prawej stronie. |

## **Ukryj pionową oś w wykresach liniowych**

Ustaw [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) na `false` na osi pionowej, aby ją ukryć. Przykład tworzy wykres liniowy z domyślnymi danymi i zapisuje go z ukrytą osią pionową.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.VerticalAxis.IsVisible = false;

presentation.Save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
```

## **Ukryj poziomą oś w wykresach liniowych**

Ustaw [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) na `false` na osi poziomej, aby ją ukryć. Przykład tworzy wykres liniowy z domyślnymi danymi i zapisuje go z ukrytą osią poziomą.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.HorizontalAxis.IsVisible = false;

presentation.Save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
```

## **Pokaż lub ukryj linie siatki wykresu**

Odczytaj [ShowMajorGridLines](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/showmajorgridlines/) i [ShowMinorGridLines](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/showminorgridlines/), aby sprawdzić, które linie siatki wyświetla oś. Obie właściwości są tylko do odczytu. Użyj wypełnienia linii [MinorGridLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/minorgridlinesformat/), aby pokazać lub ukryć drobne linie siatki. Ustaw jednolite wypełnienie z widocznym kolorem, aby je pokazać, lub użyj `FillType.NoFill`, aby je ukryć. Odpowiednie ustawienie dla głównych linii siatki znajduje się w [MajorGridLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorgridlinesformat/)`.Line.FillFormat`. Zmiana wypełnienia linii siatki zachowuje widoczność osi i znaczniki podziałek.

Pionowa oś tego skumulowanego wykresu słupkowego zaczyna się od widocznych głównych linii siatki i ukrytych drobnych linii siatki. Przykład najpierw pokazuje drobne linie siatki w pomarańczowym kolorze, potem ponownie je ukrywa przed zapisaniem prezentacji.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
var axis = chart.Axes.VerticalAxis;
Console.WriteLine($"Initial: major={axis.ShowMajorGridLines}, minor={axis.ShowMinorGridLines}");

var minorFill = axis.MinorGridLinesFormat.Line.FillFormat;
minorFill.FillType = FillType.Solid;
minorFill.SolidFillColor.Color = Color.DarkOrange;
Console.WriteLine($"Enabled: minor={axis.ShowMinorGridLines}");

minorFill.FillType = FillType.NoFill;
Console.WriteLine($"Hidden: major={axis.ShowMajorGridLines}, minor={axis.ShowMinorGridLines}");

presentation.Save("ChartGridlines.pptx", SaveFormat.Pptx);
```

| Drobne linie siatki włączone | Drobne linie siatki ukryte |
| --- | --- |
| ![Pomarańczowe drobne linie siatki pomiędzy głównymi liniami siatki na osi pionowej](minor-gridlines-enabled.png) | ![Ten sam wykres słupkowy z widocznymi tylko głównymi liniami siatki](minor-gridlines-hidden.png) |

## **Zmień oś kategorii**

Ustaw [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) aby wybrać oś kategorii daty lub tekstu. Ten przykład wymaga pliku `ExistingChart.pptx`, z wykresem jako pierwszym kształtem na pierwszym slajdzie oraz komórkami kategorii zawierającymi numeryczne wartości dat Excel. Zmienia poziomą oś na oś dat. Ustawienie [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) na `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) na `1` oraz [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) na miesiące ustawia główne podziały co miesiąc.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

var chart = (IChart) slide.Shapes[0];
chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
chart.Axes.HorizontalAxis.MajorUnit = 1;
chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
```

### **Określ typ osi kategorii na podstawie danych**

Wywołaj [SetCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/setcategoryaxistypeautomatically/) po wypełnieniu kategorii, a następnie odczytaj [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/categoryaxistype/) aby sprawdzić wybór. Jest to przydatne, gdy ten sam wykres otrzymuje albo etykiety tekstowe, albo numeryczne wartości dat. Metoda określa typ w momencie wywołania; nie włącza trybu trwałego, który ponownie ocenia późniejsze zmiany danych. Wywołaj ją ponownie po zamianie kategorii.

Poniższy przykład tworzy wykres z kategoriami tekstowymi i wypisuje `Text`. Następnie zamienia wartości komórek kategorii na daty i ponownie wywołuje metodę, która wypisuje `Date`. Daty są przechowywane jako numeryczne wartości OLE Automation zwracane przez [DateTime.ToOADate](https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tooadate), a nie jako ciągi dat. [CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/customnumberformat/) kontroluje, jak te wartości są wyświetlane; nie konwertuje tekstu na numeryczne daty. Więcej o komórkach kategorii znajdziesz w [Skoroszyt wykresu](/slides/pl/net/chart-workbook/).

Używaj automatycznego określania, gdy wiadomo, że dane wejściowe zawierają kategorie tekstowe lub numeryczne daty, tak jak w tym przykładzie. Dla zwykłych etykiet liczbowych, mieszanych kategorii lub pustych danych, jawnie ustaw [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/categoryaxistype/) aby pasował do zamierzonego znaczenia. Same wartości liczbowe nie ustalają, że kategorie reprezentują daty.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var seriesName = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesName, chart.Type);
var labels = new[] { "First", "Second", "Third" };

for (var i = 0; i < labels.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, labels[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, (i + 1) * 10);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.SetCategoryAxisTypeAutomatically();
Console.WriteLine(axis.CategoryAxisType); // Tekst

var dates = new[] { new DateTime(2026, 1, 1), new DateTime(2026, 1, 2), new DateTime(2026, 2, 1) };

for (var i = 0; i < dates.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0);
    categoryCell.Value = dates[i].ToOADate();
    categoryCell.CustomNumberFormat = "yyyy-mm-dd";
}

axis.SetCategoryAxisTypeAutomatically();
Console.WriteLine(axis.CategoryAxisType); // Data

presentation.Save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
```

## **Kontroluj interwały etykiet osi kategorii**

Gdy wykres ma wiele kategorii, zmniejsz liczbę widocznych etykiet osi bez usuwania kategorii lub punktów danych. Ustaw [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) na `false`, a następnie ustaw [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) na żądany interwał kategorii. Dla tekstowych kategorii w ich normalnym porządku liczenie zaczyna się od pierwszej kategorii:

| Interwał | Etykiety wyświetlane w przykładzie |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

Interwał `3` wyświetla każdą trzecią etykietę, ukrywając dwie etykiety pomiędzy wyświetlanymi. Nie usuwa to odpowiadających kolumn. Automatyczne rozmieszczanie wybiera interwał w zależności od dostępnej przestrzeni; nie musi wyświetlać każdej etykiety.

Znaczniki podziałek mają osobne sterowanie. Ustaw [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) na `false` i użyj [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) aby ustawić ich interwał. Na przykład `1` zachowuje znacznik podziałki przy każdym interwale kategorii, podczas gdy etykiety pojawiają się tylko co trzecią kategorię. Ustaw [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) aby był widoczny, aby zobaczyć rezultat. Przywrócenie dowolnej właściwości automatycznego rozmieszczania do `true` pozwala wykresowi ponownie wybrać ten interwał.

Poniższy samodzielny przykład tworzy 24 kategorie i jedną serię, a następnie zapisuje trzy slajdy w `CategoryAxisIntervals.pptx`: automatyczne rozmieszczanie, ręczne rozmieszczanie etykiet z niezależnymi znacznikami podziałek oraz przywrócone automatyczne rozmieszczanie. Dwie kopie zachowują oryginalne dane wykresu. Nie wymaga prezentacji wejściowej. Poziomy tekst etykiety ułatwia dostrzeżenie różnicy w gęstości.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.HasLegend = false;
chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredColumn);
for (var i = 0; i < 24; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, 10 + i % 6 * 5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.CategoryAxisType = CategoryAxisType.Text;
axis.TextFormat.TextBlockFormat.RotationAngle = 0;
axis.TextFormat.PortionFormat.FontHeight = 12;
axis.MajorTickMark = TickMarkType.Outside;
axis.IsAutomaticTickLabelSpacing = true;
axis.IsAutomaticTickMarksSpacing = true;

// Slajd 2: pokaż każdą trzecią etykietę, ale zachowaj znacznik podziałki dla każdej kategorii.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// Slajd 3: pozwól wykresowi ponownie wybrać oba interwały.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**Automatyczne rozmieszczanie (slajd 1):** W tym renderze każda druga etykieta kategorii jest wyświetlana i łamie się na dwie linie. Wynik automatyczny może się różnić w zależności od rozmiaru wykresu, czcionek i renderera.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Ręczne rozmieszczanie (slajd 2):** Każda trzecia etykieta jest wyświetlana w jednej linii, podczas gdy znaczniki podziałek pozostają przy każdym interwale kategorii. Wszystkie 24 kolumny, w tym te bez etykiet, pozostają widoczne z tymi samymi wartościami. Slajd 3 przywraca automatyczny wygląd przedstawiony powyżej.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **Wybierz prawidłową oś i interwał**

Użyj tego interwału liczby kategorii dla tekstowej osi kategorii, np. osi kategorii wykresu kolumnowego, liniowego, powierzchniowego lub słupkowego. W wykresie kolumnowym jest to oś pozioma. W wykresie słupkowym poziomym oś kategorii jest pionowa, więc zastosuj te ustawienia do [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Rozstawienie znaczników podziałek dotyczy również osi serii w wykresach, które ją posiadają.

Nie używaj rozmieszczania etykiet kategorii do ustawiania skali numerycznej osi wartości. Na osi wartości [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) określa różnicę wartości: na przykład główna jednostka `10` tworzy podziały w punktach 0, 10, 20 itd., gdy oś zaczyna się od zera. Interwał etykiety kategorii `3` liczy natomiast pozycje kategorii, niezależnie od ich wartości danych. Wykresy punktowe i bąbelkowe używają osi wartości, a nie tekstowej osi kategorii. Dla osi dat użyj jednostek i skal opartych na czasie, jak opisano w [Zmień oś kategorii](#change-a-category-axis).

## **Ustaw format daty dla wartości osi kategorii**

Przykład zastępuje domyślne dane wykresu czterema rocznymi wartościami. Daty są przechowywane jako numery seryjne OLE Automation w pierwszym arkuszu (indeks `0`). Ustaw [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) na oś dat, wyłącz [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/), i przypisz `yyyy` do [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/), aby etykiety kategorii wyświetlały czterocyfrowe lata niezależnie od formatowania komórek.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
for (var i = 0; i < 4; i++)
{
    var date = new DateTime(2015 + i, 1, 1);
    var categoryCell = workbook.GetCell(0, i + 1, 0, date.ToOADate());
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, i + 1);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.HorizontalAxis.NumberFormat = "yyyy";

presentation.Save("DateAxisFormat.pptx", SaveFormat.Pptx);
```

## **Ustaw kąt obrotu tytułu osi wykresu**

Włącz [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) na osi pionowej, podaj tekst tytułu i ustaw [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) aby obrócić tytuł. Kąt jest mierzony w stopniach; ten przykład zapisuje wykres kolumnowy z tytułem osi wartości obróconym o 90 stopni.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("Value");
chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

presentation.Save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
```

## **Ustaw pozycję osi na osi kategorii lub wartości**

Użyj [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) aby kontrolować, czy oś wartości przecina oś kategorii między kategoriami, czy na znacznikach kategorii. Właściwość ta dotyczy osi kategorii. Przykład ustawia ją na `true` na poziomej osi kategorii wykresu kolumnowego i zapisuje wynik.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

presentation.Save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
```

## **Ustaw jednostkę wyświetlania na osi wartości wykresu**

Ustaw [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) aby skalować etykiety na osi wartości bez zmiany podstawowych danych. Przy ustawieniu [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) na `Millions`, wartość 60 000 000 jest wyświetlana jako 60. Przykład tworzy wykres kolumnowy i zastosowuje jednostkę wyświetlania miliony do jego osi pionowej.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

## **Skonfiguruj logarytmiczną oś wartości**

Logarytmiczna oś wartości jest przydatna, gdy dodatnie wartości rozciągają się na kilka rzędów wielkości. Na przykład usługa może otrzymywać 10, 100, 1 000, 10 000 i 100 000 żądań w pięciu okresach. Na skali liniowej mniejsze wartości znajdują się blisko siebie w pobliżu zera. Skala logarytmiczna ułatwia porównanie ich względnego wzrostu: równe odległości oznaczają równe stosunki, a nie równe różnice.

Ustaw [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) na `true` na osi wartości i użyj [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) aby wybrać podstawę. Zmienia to sposób wyświetlania istniejących wartości; nie zmienia danych ani nie dodaje logarytmicznej linii trendu. Linia trendu reprezentuje dopasowaną zależność w danych i jest osobną funkcją.

### **Wybierz oś wartości i podstawę**

W wykresie liniowym lub kolumnowym oś wartości to [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). W wykresie słupkowym poziomym jest to [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). Wykresy punktowe i bąbelkowe mają dwie osie wartości, więc wybierz oś poziomą dla wartości X, oś pionową dla wartości Y lub obie. Nie stosuj skalowania logarytmicznego do osi kategorii.

Domyślna podstawa logarytmu to `10`. Dla wykresów PPTX użyj podstawy od `2` do `1000`, włącznie; obsługiwane są również podstawy ułamkowe, takie jak `2.5`. Przy podstawie `10` kolejne potęgi, takie jak 10, 100, 1 000 i 10 000, są rozmieszczone równomiernie.

### **Porównaj skalowanie liniowe i logarytmiczne**

Poniższy samodzielny przykład tworzy wykres liniowy z pięcioma liczbami żądań na pierwszym slajdzie, a następnie klonuje ten slajd i włącza logarytmiczną oś wartości o podstawie 10 na drugim. Oba slajdy zachowują te same dane.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 30, 40, 660, 200);

chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
var values = new double[] { 10, 100, 1000, 10000, 100000 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Period {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Keep the first slide linear and change only the copy's value-axis scale.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Skala liniowa (slajd 1):** Równe odległości pionowe reprezentują równe różnice w liczbie żądań. Największa wartość dominuje wykres, co utrudnia rozróżnienie mniejszych wartości.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Skala logarytmiczna (slajd 2):** Równe odległości pionowe reprezentują równe proporcje. Każdy okres ma dziesięciokrotnie więcej żądań niż poprzedni, więc punkty tworzą prostą rosnącą linię na skali o podstawie 10. Etykiety osi nadal pokazują oryginalne liczby żądań.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Obsługa zerowych i ujemnych wartości**

Skala logarytmiczna może wyświetlać wyłącznie wartości ściśle dodatnie. Sprawdź dane przed jej włączeniem. Jeśli zero lub wartości ujemne są istotne, zachowaj skalę liniową lub pokaż je osobno. Jeśli wykluczenie tych wartości jest uzasadnione w analizie, wyjaśnij pominięcie. Nie zastępuj ich cicho małymi liczbami dodatnimi, ponieważ zmienia to znaczenie danych. Każde ręcznie ustawione minimum lub maksimum dla osi logarytmicznej musi również być dodatnie.

## **FAQ**

**Jak ustawić wartość, w której jedna oś przecina drugą (przecięcie osi)?**  
Użyj [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) aby wybrać sposób przecięcia. Aby określić numeryczną wartość przecięcia, ustaw [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Te ustawienia pozwalają przenieść przecięcie osi na odpowiednią linię bazową.

**Jak mogę pozycjonować etykiety znaczników względem osi?**  
Ustaw [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) używając [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo` lub `None`. Aby kontrolować same znaczniki podziałek, użyj [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) lub [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/); są one oddzielne od pozycjonowania etykiet.