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
- manipulowanie osią
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
description: "Poznaj, jak używać Aspose.Slides dla .NET do dostosowywania osi wykresów w prezentacjach PowerPoint w raportach i wizualizacjach."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować osie wykresu przy użyciu Aspose.Slides dla .NET. Obejmuje obliczone wartości osi, zamianę wierszy i kolumn wykresu, widoczność osi, interwały etykiet kategorii i znaczników podziałki, kategorie dat i formatowanie, obrót tytułu, pozycjonowanie osi, jednostki wyświetlania oraz skalowanie logarytmiczne.

## **Uzyskaj maksymalne wartości na osi pionowej wykresów**

Utwórz [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) i dodaj wykres obszarowy z domyślnymi danymi. Wywołaj [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) przed odczytaniem obliczonych wartości osi, aby układ wykresu był aktualny.

Odczytaj [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) i [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) dla limitów osi oraz [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) i [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) dla interwałów podziałek. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) i [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) dostarczają skali jednostek czasu, które są istotne dla osi dat. Przykład zapisuje te wartości w zmiennych lokalnych i zapisuje wykres.

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

Użyj [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) do wymiany ról serii i kategorii w danych wykresu. Każda poprzednia kategoria staje się serią, a każda poprzednia seria staje się kategorią. Zmienia to sposób grupowania danych; nie zamienia to osi poziomej i pionowej. Przykład używa [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) aby powiązać domyślne dane z `Sheet1!A1:D5`, włączając wiersz nagłówka i kolumnę kategorii, przed zamianą wierszy i kolumn. Zapisuje wykres z czterema seriami i trzema kategoriami.

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

## **Wyłącz oś pionową dla wykresów liniowych**

Ustaw [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) na `false` na osi pionowej, aby ją ukryć. Przykład tworzy wykres liniowy z domyślnymi danymi i zapisuje go z ukryta osią pionową.

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

## **Wyłącz oś poziomą dla wykresów liniowych**

Ustaw [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) na `false` na osi poziomej, aby ją ukryć. Przykład tworzy wykres liniowy z domyślnymi danymi i zapisuje go z ukryta osią poziomą.

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

## **Zmień oś kategorii**

Ustaw [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) aby wybrać oś kategorii daty lub tekstu. Ten przykład wymaga `ExistingChart.pptx`, z wykresem jako pierwszym kształtem na pierwszym slajdzie oraz komórkami kategorii zawierającymi numeryczne wartości dat w Excelu. Zmienia oś poziomą na oś daty. Ustawienie [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) na `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) na `1` i [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) na miesiące umieszcza główne podziały co miesiąc.

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

## **Kontroluj interwały etykiet osi kategorii**

Gdy wykres ma wiele kategorii, zmniejsz liczbę widocznych etykiet osi bez usuwania kategorii lub punktów danych. Ustaw [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) na `false`, a następnie ustaw [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) na żądany interwał kategorii. Dla tekstowych kategorii w ich normalnym porządku, liczenie zaczyna się od pierwszej kategorii:

| Interwał | Etykiety wyświetlane w przykładzie |
| --- | --- |
| `1` | Kategoria 1, Kategoria 2, Kategoria 3, ... Kategoria 24 |
| `2` | Kategoria 1, Kategoria 3, Kategoria 5, ... Kategoria 23 |
| `3` | Kategoria 1, Kategoria 4, Kategoria 7, ... Kategoria 22 |

Interwał `3` wyświetla każdą trzecią etykietę, pozostawiając dwie ukryte pomiędzy wyświetlanymi. Nie usuwa to odpowiadających kolumn. Automatyczne rozmieszczanie wybiera interwał na podstawie dostępnej przestrzeni; niekoniecznie wyświetla każdą etykietę.

Znaczniki podziałek mają oddzielne sterowanie. Ustaw [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) na `false` i użyj [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) aby ustawić ich interwał. Na przykład `1` zachowuje znacznik podziałki przy każdym interwale kategorii, podczas gdy etykiety pojawiają się tylko co trzecią kategorię. Ustaw [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) na widoczny styl, aby zobaczyć rezultat. Ustawienie którejkolwiek z właściwości automatycznego rozmieszczania z powrotem na `true` pozwala wykresowi ponownie wybrać ten interwał.

Poniższy samodzielny przykład tworzy 24 kategorie i jedną serię, a następnie zapisuje trzy slajdy w `CategoryAxisIntervals.pptx`: automatyczne rozmieszczanie, ręczne rozmieszczanie etykiet z niezależnymi znacznikami podziałek oraz przywrócone automatyczne rozmieszczanie. Dwie kopie zachowują oryginalne dane wykresu. Nie wymaga żadnej prezentacji wejściowej. Poziomy tekst etykiety ułatwia dostrzeżenie różnicy w gęstości.

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

**Automatyczne rozmieszczanie (slajd 1):** W tej prezentacji co druga etykieta kategorii jest wyświetlana i łamie się na dwa wiersze. Automatyczny wynik może się różnić w zależności od rozmiaru wykresu, czcionek i renderera.

![Automatyczne rozmieszczanie etykiet kategorii przy wszystkich 24 widocznych kolumnach](category-axis-automatic.png)

**Ręczne rozmieszczanie (slajd 2):** Co trzecia etykieta jest wyświetlana w jednej linii, podczas gdy znaczniki podziałek pozostają przy każdym interwale kategorii. Wszystkie 24 kolumny, w tym te bez etykiet, pozostają widoczne z tymi samymi wartościami. Slajd 3 przywraca automatyczny wygląd przedstawiony powyżej.

![Manualny interwał etykiet kategorii co trzy przy wszystkich 24 widocznych kolumnach](category-axis-manual.png)

### **Wybierz właściwą oś i interwał**

Użyj tego interwału liczby kategorii dla tekstowej osi kategorii, takiej jak oś kategorii wykresu kolumnowego, liniowego, obszarowego lub słupkowego. W wykresie kolumnowym jest to oś pozioma. W wykresie słupkowym poziomym oś kategorii jest pionowa, więc zastosuj te ustawienia do [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Rozmieszczanie znaczników podziałek ma również zastosowanie do osi serii w wykresach, które taką posiadają.

Nie używaj rozmieszczania etykiet kategorii do ustawiania skali numerycznej osi wartości. Na osi wartości [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) określa różnicę w wartościach: na przykład jednostka główna `10` generuje znaczniki przy 0, 10, 20 itd., gdy oś zaczyna się od zera. Interwał etykiet kategorii `3` liczy pozycje kategorii, niezależnie od ich wartości danych. Wykresy punktowe i bąbelkowe używają osi wartości, a nie tekstowej osi kategorii. Dla osi dat użyj jednostek i skali opartych na czasie, jak opisano w [Change a Category Axis](#change-a-category-axis).

## **Ustaw format daty dla wartości osi kategorii**

Przykład zamienia domyślne dane wykresu na cztery roczne wartości. Daty są przechowywane jako numery seryjne OLE Automation w pierwszym arkuszu (indeks `0`). Ustaw [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) na oś dat, wyłącz [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/), i przypisz `yyyy` do [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/), aby etykiety kategorii wyświetlały czterocyfrowe lata niezależnie od formatowania komórki.

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

Użyj [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) aby kontrolować, czy oś wartości przecina oś kategorii pomiędzy kategoriami czy na znacznikach kategorii. Właściwość ta dotyczy osi kategorii. Przykład ustawia ją na `true` na poziomej osi kategorii wykresu kolumnowego i zapisuje wynik.

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

Ustaw [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) aby skalować etykiety na osi wartości bez zmiany podstawowych danych. Przy ustawieniu [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) na `Millions`, wartość 60 000 000 jest wyświetlana jako 60. Przykład tworzy wykres kolumnowy i stosuje jednostkę wyświetlania w milionach do jego osi pionowej.

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

Logarytmiczna oś wartości jest przydatna, gdy dodatnie wartości rozciągają się na kilka rzędów wielkości. Na przykład usługa może otrzymywać 10, 100, 1 000, 10 000 i 100 000 żądań w pięciu okresach. Na skali liniowej mniejsze wartości są blisko siebie w pobliżu zera. Skala logarytmiczna ułatwia porównanie ich względnego wzrostu: równe odległości reprezentują równe stosunki, a nie równe różnice.

Ustaw [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) na `true` na osi wartości i użyj [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) aby wybrać podstawę. Zmienia to sposób wyświetlania istniejących wartości; nie zmienia danych ani nie dodaje logarytmicznej linii trendu. Linia trendu reprezentuje dopasowany związek w danych i jest odrębną funkcją.

### **Wybierz oś wartości i podstawę**

W wykresie liniowym lub kolumnowym oś wartości to [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). W wykresie słupkowym poziomym jest to [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). Wykresy punktowe i bąbelkowe mają dwie osie wartości, więc wybierz oś poziomą dla wartości X, oś pionową dla wartości Y lub obie. Nie stosuj skalowania logarytmicznego do osi kategorii.

Domyślna podstawa logarytmiczna to `10`. Dla wykresów PPTX użyj podstawy od `2` do `1000`, włącznie; obsługiwane są również podstawy ułamkowe, takie jak `2.5`. Przy podstawie `10` kolejne potęgi, takie jak 10, 100, 1 000 i 10 000, są równomiernie rozmieszczone.

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

// Zachowaj pierwszą slajd w skali liniowej i zmień tylko skalę osi wartości w kopii.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Skala liniowa (slajd 1):** Równe odległości pionowe reprezentują równe różnice w liczbie żądań. Największa wartość dominuje wykres, utrudniając rozróżnienie mniejszych wartości.

![Wykres liniowy w PowerPoint pokazujący pięć liczby żądań na liniowej osi wartości](value-axis-linear.png)

**Skala logarytmiczna (slajd 2):** Równe odległości pionowe reprezentują równe stosunki. Każdy okres ma dziesięć razy więcej żądań niż poprzedni, więc punkty tworzą prostą rosnącą linię na skali o podstawie 10. Etykiety osi nadal pokazują oryginalne liczby żądań.

![Te same pięć liczby żądań w PowerPoint na logarytmicznej osi wartości o podstawie 10](value-axis-logarithmic.png)

### **Obsługa zer i wartości ujemnych**

Skala logarytmiczna może wyświetlać tylko ściśle dodatnie wartości. Sprawdź dane przed jej włączeniem. Jeśli zero lub wartości ujemne mają znaczenie, zachowaj skalę liniową lub pokaż je osobno. Jeśli wykluczenie tych wartości jest odpowiednie dla analizy, wyjaśnij pominięcie. Nie zastępuj ich cicho małymi liczbami dodatnimi, ponieważ zmienia to znaczenie danych. Każde ręcznie skonfigurowane minimum lub maksimum dla osi logarytmicznej musi również być dodatnie.

## **FAQ**

**Jak ustawić wartość, w której jedna oś przecina drugą (przecięcie osi)?**

Użyj [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) aby wybrać zachowanie przy przecięciu. Aby określić numeryczną wartość przecięcia, ustaw [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Te ustawienia pozwalają przenieść przecięcie osi na odpowiednią linię bazową.

**Jak mogę pozycjonować etykiety podziałek względem osi?**

Ustaw [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) używając [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo` lub `None`. Aby sterować samymi znacznikami podziałek, użyj [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) lub [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/); są one oddzielne od pozycjonowania etykiet.