---
title: Zarządzanie skoroszytami wykresów w prezentacjach w .NET
linktitle: Skoroszyt wykresu
type: docs
weight: 70
url: /pl/net/chart-workbook/
keywords:
- skoroszyt wykresu
- dane wykresu
- komórka skoroszytu
- etykieta danych
- arkusz
- źródło danych
- zewnętrzny skoroszyt
- zewnętrzne dane
- pamięć podręczna wykresu
- odzyskiwanie skoroszytu
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Odkryj Aspose.Slides dla .NET: łatwo zarządzaj skoroszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z skoroszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu przy użyciu strumieni skoroszytów, używać komórek skoroszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Omówiono również pracę z zewnętrznymi skoroszytami jako źródłami danych wykresu. Przykłady pokazują, jak utworzyć i przypisać zewnętrzny skoroszyt, pobrać ścieżkę zewnętrznego skoroszytu powiązanego z wykresem oraz edytować dane wykresu, gdy skoroszyt jest dostępny.

W przypadku komórek skoroszytu reprezentujących brakujące dane zobacz [Kontroluj wyświetlanie pustych komórek](/slides/pl/net/chart-series/) aby poznać różnicę między pustą komórką a zero oraz porównanie trybów wyświetlania w wykresie liniowym.

## **Dołącz dane z ukrytych wierszy i kolumn**

Użyj [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/), aby kontrolować, czy wykres rysuje dane z ukrytych wierszy i kolumn arkusza. Ustaw `true`, aby rysować tylko widoczne komórki, lub `false`, aby uwzględnić zarówno widoczne, jak i ukryte komórki. To ustawienie kontroluje rysowanie wykresu; nie ukrywa ani nie odkrywa wierszy lub kolumn arkusza.

Przykładowa prezentacja ([sample presentation](hidden-source-data.pptx)) zawiera wykres kolumnowy jako pierwszą figurę na pierwszym slajdzie. Osadzony arkusz, `Sheet1`, zawiera następujący zakres źródłowy, `A1:C4`. Wiersz 3 i kolumna C są ukryte, ale ich komórki nadal zawierają wartości.

| Wiersz arkusza | A: Miesiąc | B: Detal | C: Hurt (ukryta kolumna) |
| --- | --- | --- | --- |
| 2 | Styczeń | 10 | 30 |
| 3 (ukryty wiersz) | Luty | 40 | 60 |
| 4 | Marzec | 20 | 50 |

Uzyskaj dostęp do komórek źródłowych poprzez [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) i odczytaj [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/), aby sprawdzić ich status ukrycia. Ta właściwość jest tylko do odczytu. W tym pliku B2 jest widoczne, B3 należy do ukrytego wiersza, a C2 do ukrytej kolumny; przykład wypisuje kolejno `False`, `True` i `True`.

W tym przykładzie odśwież dane wykresu po zmianie ustawienia rysowania: zachowaj osadzony skoroszyt przy pomocy [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) i wczytaj go ponownie przy użyciu [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/). Gdy uwzględniasz wszystkie komórki, użyj także [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/), aby przywrócić pełny zakres, w tym ukrytą kategorię luty. Same zmiana flagi nie wystarczy do odświeżenia danych wykresu i etykiet kategorii w pamięci podręcznej tego przykładu.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("hidden-source-data.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes[0] is IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    Console.WriteLine($"B2 hidden: {workbook.GetCell(0, "B2").IsHidden}");
    Console.WriteLine($"B3 hidden: {workbook.GetCell(0, "B3").IsHidden}");
    Console.WriteLine($"C2 hidden: {workbook.GetCell(0, "C2").IsHidden}");

    using var workbookStream = chart.ChartData.ReadWorkbookStream();
    foreach (var visibleOnly in new[] { true, false })
    {
        chart.PlotVisibleCellsOnly = visibleOnly;

        // Odśwież dane wykresu z osadzonego skoroszytu.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Przywróć pełny zakres źródłowy, w tym ukryte kategorie.
            chart.ChartData.SetRange("Sheet1!$A$1:$C$4");
        }

        presentation.Save($"hidden_cells_{visibleOnly}.pptx", SaveFormat.Pptx);
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Przykład zapisuje dwie wersje prezentacji: jedną tylko z widocznymi wartościami Detalu (10 i 20), oraz drugą ze wszystkimi sześcioma wartościami. Poniższe obrazy zostały wygenerowane z zapisanych prezentacji po ich ponownym otwarciu; oba pliki zachowują przypisane ustawienie rysowania. Wiersz 3 i kolumna C pozostają ukryte w obu osadzonych skoroszytach.

| Tylko widoczne komórki (`true`) | Wszystkie komórki (`false`) |
| --- | --- |
| ![Tylko widoczne komórki: wartości Detalu 10 i 20 dla stycznia i marca.](hidden_cells_True.png) | ![Wszystkie komórki: wartości Detalu i Hurtu dla stycznia, lutego i marca.](hidden_cells_False.png) |

Ukryta komórka zawierająca wartość różni się od pustej komórki. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) steruje tym, jak wyświetlane są brakujące wartości; nie dołącza ani nie wyklucza ukrytych danych źródłowych. Zobacz [Kontroluj wyświetlanie pustych komórek](/slides/pl/net/chart-series/#control-the-display-of-empty-cells) dla przykładu.

## **Pobierz zakres danych wykresu**

Przed aktualizacją danych skoroszytu w istniejącej prezentacji, sprawdź zakresy źródłowe, aby zidentyfikować, które komórki arkusza używa każdy wykres. Metoda [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) zwraca bieżący zakres danych jako formułę kwalifikowaną arkuszem, np. `Sheet1!$A$1:$D$5`. Tutaj `Sheet1` to nazwa arkusza, `!` oddziela ją od zakresu komórek, a `$A$1:$D$5` określa komórki od A1 do D5, włącznie. Znaki dolara oznaczają odwołania bezwzględne do wierszy i kolumn.

Metoda odczytuje bieżący zakres bez zmiany wykresu ani jego skoroszytu. Jeśli wykres nie używa skoroszytu jako źródła danych, zostaje zgłoszony [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Aby uzyskać więcej informacji, zobacz [ChartData API Reference](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/).

Ten przykład otwiera prezentację i sprawdza kształty bezpośrednio na każdym slajdzie pod kątem wykresów. Wypisuje nazwę każdego wykresu oraz zakres źródłowy. Jeśli wykres nie używa skoroszytu, wypisuje komunikat i przechodzi do kolejnego wykresu.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            try
            {
                var range = chart.ChartData.GetRange();
                Console.WriteLine($"{chart.Name}: {range}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"{chart.Name}: The chart does not use a workbook as its data source.");
            }
        }
    }
}
```

## **Odczyt i zapis danych wykresu ze skoroszytu**

Aspose.Slides for .NET udostępnia metody [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) i [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/), które umożliwiają odczyt i zapis skoroszytów danych wykresu (zawierających dane wykresu edytowane przy użyciu Aspose.Cells). **Uwaga** dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

Ten przykład używa prezentacji z wykresem jako pierwszej figury na pierwszym slajdzie. Odczytuje osadzony skoroszyt do strumienia, czyści istniejące serie i kategorie, a następnie zapisuje ten sam skoroszyt z powrotem. Zmiany pozostają w pamięci; przykład nie zapisuje prezentacji.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **Zweryfikuj układ wykresu po modyfikacji skoroszytu**

Gdy zastąpisz osadzony skoroszyt zmodyfikowanym, wykres zachowuje oryginalne kolekcje serii i kategorii. To niepasowanie może spowodować błąd [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) z komunikatem o indeksie poza zakresem. Wyczyść istniejące serie i kategorie przed zapisaniem zmodyfikowanego skoroszytu z powrotem do wykresu. Ten przykład używa wykresu będącego pierwszą figurą na pierwszym slajdzie. Komentarz wskazuje miejsce, w którym miałoby nastąpić edytowanie skoroszytu; działający przykład zapisuje oryginalny skoroszyt z powrotem i w pamięci weryfikuje układ.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    // Modyfikuj strumień skoroszytu tutaj, na przykład przy użyciu Aspose.Cells.

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
    chart.ValidateChartLayout();
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Czyszczenie kolekcji usuwa przestarzałe odwołania do danych przed zapisaniem skoroszytu. Przed użyciem wykresu odbuduj wymagane mapowania serii i kategorii dla zaktualizowanego skoroszytu.

## **Ustaw niestandardowe formaty liczb dla komórek skoroszytu**

Użyj [ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/), aby kontrolować, jak wyświetlane są wartości liczbowe w osadzonym skoroszycie wykresu. Na przykład raport może wymagać wyświetlenia współczynnika konwersji jako procentu z czterema miejscami po przecinku oraz współczynnika z pięcioma miejscami po przecinku. Zachowaj obie wartości jako liczbowe, aby były dostępne do obliczeń i rysowania wykresu.

Format liczbowy zmienia sposób wyświetlania, a nie przechowywaną wartość. Format `0.0000%` wyświetla `0.125` jako `12.5000%`; nie zamienia przechowywanej liczby na `12.5`. Podobnie, `0.00000` wyświetla `0.1234567` jako `0.12346` bez zaokrąglania przechowywanej wartości. Jeśli niestandardowy format jest pustym ciągiem (`""`), używany jest [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/).

Poniższy przykład tworzy wykres kolumnowy i uzyskuje dostęp do jego komórek przez [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/). W arkuszu 0, B2 zawiera współczynnik konwersji, a C2 współczynnik. Obie komórki dostarczają wartości wykresu. Przykład włącza także etykiety wartości połączone ze źródłowymi formatami.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 270, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
chart.HasTitle = false;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00";
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A2", "Sample");
chart.ChartData.Categories.Add(categoryCell);

var percentageCell = workbook.GetCell(0, "B2", 0.125);
percentageCell.CustomNumberFormat = "0.0000%";
var percentageName = workbook.GetCell(0, "B1", "Conversion rate");
var percentageSeries = chart.ChartData.Series.Add(percentageName, chart.Type);
percentageSeries.DataPoints.AddDataPointForBarSeries(percentageCell);

var precisionCell = workbook.GetCell(0, "C2", 0.1234567);
precisionCell.CustomNumberFormat = "0.00000";
var precisionName = workbook.GetCell(0, "C1", "Coefficient");
var precisionSeries = chart.ChartData.Series.Add(precisionName, chart.Type);
precisionSeries.DataPoints.AddDataPointForBarSeries(precisionCell);

foreach (var series in chart.ChartData.Series)
{
    var labelFormat = series.DataPoints[0].Label.DataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = true;
}

presentation.Save("CustomCellFormats.pptx", SaveFormat.Pptx);
```

Formaty komórek skoroszytu są odrębne od formatów ustawianych bezpośrednio na osiach wykresu lub etykietach danych. W tym przykładzie każda etykieta wyświetla wartość swojej komórki źródłowej, ponieważ [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) jest włączone, a dodatkowo stosuje źródłowy format liczbowy, ponieważ [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) jest `true`. Po zapisaniu i ponownym otwarciu prezentacji etykiety wyświetlają `12.5000%` i `0.12346`, jak pokazano niżej. Oś pionowa używa własnego [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) `0.00`, przy czym [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) jest ustawione na `false`.

Aby sformatować etykietę danych niezależnie, ustaw jej flagę połączenia ze źródłem na `false` i przypisz jej [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/). Nie zmienia to formatu komórki skoroszytu. Na przykład niezależny format etykiety `0.00` wyświetli pierwszą wartość jako `0.13`, podczas gdy B2 nadal wyświetla `12.5000%`. Zobacz [Chart Data Labels](/slides/pl/net/chart-data-label/#set-percentage-sign-with-chart-data-labels) dla bezpośredniego formatowania etykiet.

Obraz poniżej został wygenerowany z zapisanej prezentacji po jej ponownym otwarciu:

![Wykres kolumnowy z etykietami połączonymi ze źródłem, pokazującymi 12,5000% i 0,12346 oraz niezależnie sformatowaną osią liczbową.](custom-cell-formats.png)

## **Ustaw komórkę skoroszytu jako etykietę danych wykresu**

Możesz używać tekstu z komórek skoroszytu jako etykiet danych wykresu.

Ten przykład dodaje wykres bąbelkowy z domyślnymi danymi do pierwszego slajdu istniejącej prezentacji. Używa komórek A10:A12 w arkuszu 0 jako pierwszych trzech etykiet w pierwszej serii, włącza etykiety pochodzące z komórek i zapisuje zaktualizowaną prezentację.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart2.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
var series = chart.ChartData.Series[0];
var workbook = chart.ChartData.ChartDataWorkbook;

series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;
series.Labels[0].ValueFromCell = workbook.GetCell(0, "A10", "Label 0 cell value");
series.Labels[1].ValueFromCell = workbook.GetCell(0, "A11", "Label 1 cell value");
series.Labels[2].ValueFromCell = workbook.GetCell(0, "A12", "Label 2 cell value");

presentation.Save("resultchart.pptx", SaveFormat.Pptx);
```

## **Zarządzaj arkuszami**

Właściwość [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) zapewnia dostęp do arkuszy w skoroszycie wykresu. Ten przykład tworzy wykres kołowy z domyślnymi danymi i wypisuje nazwę każdego arkusza w konsoli.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
var workbook = chart.ChartData.ChartDataWorkbook;

for (var i = 0; i < workbook.Worksheets.Count; i++)
{
    Console.WriteLine(workbook.Worksheets[i].Name);
}
```

## **Określ typ źródła danych**

Wartości punktów serii mogą być również przechowywane bezpośrednio jako literały liczbowe. Zobacz [Set Series Values Using Numeric Literals](/slides/pl/net/chart-series/#set-series-values-using-numeric-literals) dla pełnego przykładu, w którym są one zapisywane i odczytywane. Typ źródła punktów serii jest odrębny od wewnętrznej lub zewnętrznej konfiguracji skoroszytu wykresu; użycie literałów liczbowych samo w sobie nie usuwa osadzonego skoroszytu.

Ten przykład tworzy trójwymiarowy wykres kolumnowy z domyślnymi danymi i ustawia dwie nazwy serii, korzystając z różnych źródeł danych. Pierwsza nazwa używa literału tekstowego; druga korzysta z komórki C1 w arkuszu 0. Enum [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) wybiera źródło dla każdej nazwy. Przykład zapisuje prezentację z zaktualizowanymi nazwami serii.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
var literalName = chart.ChartData.Series[0].Name;

literalName.DataSourceType = DataSourceType.StringLiterals;
literalName.Data = "LiteralString";

var cellName = chart.ChartData.Series[1].Name;
var nameCell = chart.ChartData.ChartDataWorkbook.GetCell(0, "C1", "NewCell");
cellName.DataSourceType = DataSourceType.Worksheet;
cellName.Data = nameCell;

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **Wykryj nieobsługiwane formaty osadzonych skoroszytów**

Aspose.Slides nie obsługuje binarnego formatu skoroszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć właściwości [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) na [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) wraz z enumem [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/), aby wykryć nieobsługiwane formaty i pominąć te wykresy. Ten przykład przegląda kształty na pierwszym slajdzie istniejącej prezentacji, pomija kształty niebędące wykresami i wypisuje komunikat diagnostyczny dla każdego wykresu z osadzonym skoroszytem .xlsb.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
    {
        continue;
    }

    var chartData = chart.ChartData;
    var isInternalWorkbook = chartData.DataSourceType == ChartDataSourceType.InternalWorkbook;
    var isBinaryMacro = chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console.WriteLine("Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

        // Odczytaj lub zmodyfikuj obsługiwane dane skoroszytu wykresu tutaj.
}
```

## **Zewnętrzny skoroszyt**

Aspose.Slides obsługuje używanie zewnętrznych skoroszytów jako źródła danych dla wykresów.

### **Utwórz zewnętrzny skoroszyt**

Użyj [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) i [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/), aby wyeksportować osadzony skoroszyt wykresu do pliku i połączyć wykres z tym zewnętrznym skoroszytem.

Ten przykład tworzy wykres kołowy z domyślnymi danymi i eksportuje jego skoroszyt. Zamknięcie strumienia wyjściowego następuje przed przypisaniem zewnętrznego skoroszytu jako źródła danych wykresu, po czym zapisuje połączoną prezentację.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
var workbookPath = Path.GetFullPath("externalWorkbook1.xlsx");

using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var fileStream = File.Create(workbookPath))
{
    workbookStream.CopyTo(fileStream);
}

chart.ChartData.SetExternalWorkbook(workbookPath);
presentation.Save("externalWorkbook.pptx", SaveFormat.Pptx);
```

### **Ustaw zewnętrzny skoroszyt**

Korzystając z metody [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/), możesz przypisać zewnętrzny skoroszyt do wykresu jako jego źródło danych. Metoda może być także użyta do zaktualizowania ścieżki do zewnętrznego skoroszytu (jeśli został przeniesiony).

Chociaż nie możesz edytować danych w skoroszytach przechowywanych w zdalnych lokalizacjach lub zasobach, możesz nadal używać takich skoroszytów jako zewnętrznego źródła danych. Jeśli podano względną ścieżkę do zewnętrznego skoroszytu, zostanie ona automatycznie przekształcona w pełną ścieżkę.

Ten przykład używa zewnętrznego skoroszytu, którego arkusz o nazwie `Sheet1` zawiera nazwę serii w B1, nazwy kategorii w A2:A4 oraz wartości liczbowe w B2:B4. Przykład tworzy wykres kołowy, łączy skoroszyt i używa [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/), aby zmapować A1:B4 na jedną serię i trzy kategorie. Zapisuje prezentację z połączonym wykresem.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
var chartData = chart.ChartData;
var workbookPath = Path.GetFullPath("externalWorkbook.xlsx");

chartData.SetExternalWorkbook(workbookPath);
chartData.SetRange("Sheet1!$A$1:$B$4");

presentation.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
```

Parametr `updateChartData` metody [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) kontroluje, czy skoroszyt zostanie załadowany.

* Gdy `updateChartData` jest `false`, aktualizowana jest tylko ścieżka do skoroszytu. Dane wykresu nie są ładowane ani aktualizowane z docelowego skoroszytu, więc skoroszyt może być niedostępny.
* Gdy `updateChartData` jest `true`, dane wykresu są aktualizowane z docelowego skoroszytu.

Poniższy przykład przypisuje adres URL jako zastępczy, z `updateChartData` ustawionym na `false`. Zachowuje domyślne dane wykresu kołowego i zapisuje prezentację bez ładowania niedostępnego skoroszytu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);

chart.ChartData.SetExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);
presentation.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
```

### **Uzyskaj ścieżkę skoroszytu źródła zewnętrznego wykresu**

Aby zidentyfikować skoroszyt połączony z wykresem, sprawdź, czy wykres używa zewnętrznego źródła danych i odczytaj jego ścieżkę.

Ten przykład przegląda pierwszą figurę na pierwszym slajdzie prezentacji z połączonym zewnętrznym skoroszytem. Jeśli jest to wykres połączony z zewnętrznym skoroszytem, przykład wypisuje [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) w konsoli. Następnie zapisuje kopię prezentacji.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("externalWorkbook.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    if (chartData.DataSourceType == ChartDataSourceType.ExternalWorkbook)
    {
        Console.WriteLine(chartData.ExternalWorkbookPath);
    }
    else
    {
        Console.WriteLine("The chart does not use an external workbook.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

### **Edytuj dane wykresu**

Możesz edytować dane w zewnętrznych skoroszytach w taki sam sposób, w jaki dokonujesz zmian w zawartości wewnętrznych skoroszytów. Gdy zewnętrzny skoroszyt nie może zostać załadowany, zostaje zgłoszony wyjątek.

Ten przykład używa wykresu będącego pierwszą figurą na pierwszym slajdzie i połączonego z dostępnym zewnętrznym skoroszytem. Ustawia wartość opartą na komórce pierwszego punktu danych w pierwszej serii na 100 i zapisuje zaktualizowaną prezentację. Edycja wartości w komórkach może zaktualizować powiązany zewnętrzny plik XLSX, więc użyj kopii, jeśli musisz zachować oryginalny skoroszyt.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var series = chart.ChartData.Series;
    if (series.Count > 0 && series[0].DataPoints.Count > 0)
    {
        var valueCell = series[0].DataPoints[0].Value.AsCell;
        if (valueCell != null)
        {
            valueCell.Value = 100;
            presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
        }
        else
        {
            Console.WriteLine("The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console.WriteLine("The chart has no data points to edit.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **Odzyskaj skoroszyt z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznego skoroszytu, który jest brakujący lub niedostępny, Aspose.Slides może odtworzyć skoroszyt wykresu z danych zapisanych w pamięci podręcznej prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/), skonfiguruj jego [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/), i ustaw [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) na `true` przed otwarciem prezentacji.

Poniższy przykład w C# odzyskuje dane skoroszytu dla wykresu będącego pierwszą figurą na pierwszym slajdzie i odwołującego się do niedostępnego zewnętrznego skoroszytu. Dostęp do odzyskanych danych uzyskuje się przez [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) i [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

var spreadsheetOptions = new SpreadsheetOptions
{
    RecoverWorkbookFromChartCache = true
};
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = spreadsheetOptions
};

using var presentation = new Presentation("presentation.pptx", loadOptions);
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

    // Odczytaj lub zmodyfikuj odzyskane dane skoroszytu tutaj.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Jeśli zewnętrzny skoroszyt jest niedostępny i odzyskiwanie jest wyłączone, Aspose.Slides zgłasza [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Włącz odzyskiwanie tylko wtedy, gdy użycie danych wykresu z pamięci podręcznej jest akceptowalnym rozwiązaniem awaryjnym, ponieważ pamięć podręczna może nie zawierać zmian wprowadzonych w zewnętrznym skoroszycie po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrznym czy osadzonym skoroszytem?**

Tak. Wykres posiada [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) oraz [path to an external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/); jeśli źródłem jest zewnętrzny skoroszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy względne ścieżki do zewnętrznych skoroszytów są obsługiwane i jak są przechowywane?**

Tak. Jeśli podasz względną ścieżkę, zostaje ona automatycznie przekształcona w ścieżkę bezwzględną. Prezentacja przechowuje ścieżkę bezwzględną w pliku PPTX, więc przeniesienie skoroszytu może wymagać aktualizacji linku.

**Czy mogę używać skoroszytów znajdujących się na zasobach/udostępnieniach sieciowych?**

Tak, takie skoroszyty mogą być używane jako zewnętrzne źródło danych. Jednak edycja zdalnych skoroszytów bezpośrednio z poziomu Aspose.Slides nie jest obsługiwana – mogą być używane jedynie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX przy zapisywaniu prezentacji?**

Prezentacja przechowuje [link to the external file](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/). Edycja danych wykresu opartej na komórkach może również aktualizować połączony lokalny plik XLSX. Użyj kopii skoroszytu, jeśli oryginał musi pozostać niezmieniony.

**Co zrobić, gdy zewnętrzny plik jest zabezpieczony hasłem?**

Aspose.Slides nie akceptuje hasła przy łączeniu. Typowym podejściem jest usunięcie ochrony wcześniej lub przygotowanie odkodowanej kopii (na przykład przy użyciu [Aspose.Cells](https://reference.aspose.com/cells/net/)) i połączenie się z tą kopią.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego skoroszytu?**

Tak. Każdy wykres przechowuje własny link. Jeśli wszystkie wskazują na ten sam plik, aktualizacja tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym ładowaniu danych.