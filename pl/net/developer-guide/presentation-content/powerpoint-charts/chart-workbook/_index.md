---
title: Zarządzanie zeszytami wykresów w prezentacjach w .NET
linktitle: Zeszyt wykresu
type: docs
weight: 70
url: /pl/net/chart-workbook/
keywords:
- zeszyt wykresu
- dane wykresu
- komórka zeszytu
- etykieta danych
- arkusz
- źródło danych
- zewnętrzny zeszyt
- zewnętrzne dane
- pamięć podręczna wykresu
- odzyskiwanie zeszytu
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Odkryj Aspose.Slides dla .NET: łatwo zarządzaj zeszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z zeszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu za pomocą strumieni zeszytów, używać komórek zeszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Omówiono także pracę z zewnętrznymi zeszytami jako źródłami danych wykresu. Przykłady pokazują, jak utworzyć i przypisać zewnętrzny zeszyt, odczytać ścieżkę zewnętrznego zeszytu powiązanego z wykresem oraz edytować dane wykresu, gdy zeszyt jest dostępny.

Aby dowiedzieć się, jak obsługiwać komórki zeszytu reprezentujące brakujące dane, zobacz [Kontrolowanie wyświetlania pustych komórek](/slides/pl/net/chart-series/) – różnice między pustą komórką a zerem oraz porównanie trybów wyświetlania w wykresie liniowym.

## **Dołączanie danych z ukrytych wierszy i kolumn**

Użyj [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) aby kontrolować, czy wykres rysuje dane z ukrytych wierszy i kolumn arkusza. Ustaw `true`, aby rysować tylko widoczne komórki, lub `false`, aby uwzględnić zarówno widoczne, jak i ukryte komórki. To ustawienie steruje rysowaniem wykresu; nie ukrywa ani nie odsłania wierszy czy kolumn arkusza.

Pobierz [hidden-source-data.pptx](hidden-source-data.pptx) i umieść go w katalogu roboczym. Na pierwszym slajdzie znajduje się wykres słupkowy jako pierwsza forma. Osadzony arkusz, `Sheet1`, zawiera następujący zakres źródłowy: `A1:C4`. Wiersz 3 i kolumna C są ukryte, ale ich komórki nadal zawierają wartości.

| Wiersz arkusza | A: Miesiąc | B: Detal | C: Hurt (ukryta kolumna) |
| --- | --- | --- | --- |
| 2 | Styczeń | 10 | 30 |
| 3 (ukryty wiersz) | Luty | 40 | 60 |
| 4 | Marzec | 20 | 50 |

Uzyskaj dostęp do komórek źródłowych przez [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdata/chartdataworkbook/) i odczytaj [IChartDataCell.IsHidden](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdatacell/ishidden/), aby sprawdzić ich status ukrycia. Ta właściwość jest tylko do odczytu. W tym pliku B2 jest widoczny, B3 należy do ukrytego wiersza, a C2 do ukrytej kolumny; przykład wypisuje kolejno `False`, `True` i `True`.

Dla tego przykładu odśwież dane wykresu po zmianie ustawienia rysowania: zachowaj osadzony zeszyt przy użyciu [ReadWorkbookStream](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdata/readworkbookstream/) i załaduj go ponownie przy pomocy [WriteWorkbookStream](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdata/writeworkbookstream/). Podczas uwzględniania wszystkich komórek użyj także [SetRange](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdata/setrange/), aby przywrócić pełny zakres, w tym ukryty luty. Samo zmienienie flagi nie wystarczy do odświeżenia pamięci podręcznej danych wykresu i etykiet kategorii w tym przykładzie.

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

        // Odśwież dane wykresu z osadzonego zeszytu.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Przywróć pełny zakres źródłowy, włącznie z ukrytymi kategoriami.
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

Przykład zapisuje `hidden_cells_True.pptx` z tylko widocznymi wartościami Detalu (10 i 20) oraz `hidden_cells_False.pptx` ze wszystkimi sześcioma wartościami. Obrazy poniżej zostały wyrenderowane z zapisanych prezentacji po ich ponownym otwarciu; oba pliki zachowują ustawione wcześniej rysowanie. Wiersz 3 i kolumna C pozostają ukryte w obu osadzonych zeszytach.

| Tylko widoczne komórki (`true`) | Wszystkie komórki (`false`) |
| --- | --- |
| ![Tylko widoczne komórki: wartości Detalu 10 i 20 dla stycznia i marca.](hidden_cells_True.png) | ![Wszystkie komórki: wartości Detalu i Hurtu dla stycznia, lutego i marca.](hidden_cells_False.png) |

Ukryta komórka zawierająca wartość różni się od pustej komórki. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichart/displayblanksas/) kontroluje, jak wyświetlane są brakujące wartości; nie obejmuje ani nie wyklucza ukrytych danych źródłowych. Zobacz [Kontrolowanie wyświetlania pustych komórek](/slides/pl/net/chart-series/#control-the-display-of-empty-cells) po przykład.

## **Odczyt i zapis danych wykresu z zeszytu**

Aspose.Slides for .NET udostępnia metody [ReadWorkbookStream](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdata/readworkbookstream/) i [WriteWorkbookStream](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdata/writeworkbookstream/), które pozwalają odczytywać i zapisywać zeszyty danych wykresu (zawierające dane wykresu edytowane przy użyciu Aspose.Cells). **Uwaga**, dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

Ten przykład otwiera `chart.pptx`, który musi zawierać wykres jako pierwszą formę na pierwszym slajdzie. Odczytuje osadzony zeszyt do strumienia, czyści istniejące serie i kategorie oraz zapisuje ten sam zeszyt z powrotem. Zmiany pozostają w pamięci; przykład nie zapisuje prezentacji.

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

### **Walidacja układu wykresu po modyfikacji zeszytu**

Kiedy zastępujesz osadzony zeszyt zmodyfikowanym, wykres zachowuje swoje oryginalne kolekcje serii i kategorii. To niezgodność może spowodować błąd [IChart.ValidateChartLayout](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichart/validatechartlayout/) z komunikatem „index out of range”. Wyczyść istniejące serie i kategorie przed zapisaniem zaktualizowanego zeszytu z powrotem do wykresu. Ten przykład wymaga `chart.pptx` z wykresem jako pierwszą formą na pierwszym slajdzie. Komentarz wskazuje miejsce, w którym odbywałaby się edycja zeszytu; działający przykład zapisuje oryginalny zeszyt z powrotem i waliduje układ w pamięci.

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

    // Modyfikuj strumień zeszytu tutaj, na przykład używając Aspose.Cells.

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

Czyszczenie kolekcji usuwa nieaktualne odniesienia danych przed zapisaniem zeszytu. Przed użyciem wykresu zbuduj wymagane mapowania serii i kategorii dla zaktualizowanego zeszytu.

## **Ustawienie komórki zeszytu jako etykiety danych wykresu**

Możesz używać tekstu z komórek zeszytu jako etykiet danych wykresu. Poniższe kroki pokazują, jak powiązać etykiety w wykresie bąbelkowym z komórkami jego zeszytu danych.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu za pomocą indeksu zerowego.
3. Dodaj wykres bąbelkowy z domyślnymi danymi.
4. Uzyskaj dostęp do serii wykresu.
5. Ustaw komórkę zeszytu jako etykietę danych.
6. Zapisz prezentację.

Ten przykład otwiera `chart2.pptx`, który musi zawierać co najmniej jeden slajd, i dodaje wykres bąbelkowy z domyślnymi danymi. Używa komórek A10:A12 w arkuszu 0 dla pierwszych trzech etykiet w pierwszej serii, włącza etykiety z komórek i zapisuje wynik do `resultchart.pptx`.

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

## **Zarządzanie arkuszami**

Właściwość [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdataworkbook/worksheets/) zapewnia dostęp do arkuszy w zeszycie wykresu. Ten przykład tworzy wykres kołowy z domyślnymi danymi i wypisuje nazwę każdego arkusza w konsoli.

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

## **Określenie typu źródła danych**

Ten przykład tworzy wykres słupkowy 3D z domyślnymi danymi i ustawia dwie nazwy serii przy użyciu różnych źródeł danych. Pierwsza nazwa korzysta z literału łańcuchowego; druga używa komórki C1 w arkuszu 0. Wymiennik [DataSourceType](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/datasourcetype/) wybiera źródło dla każdej nazwy. Wynik zostaje zapisany do `pres.pptx`.

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

## **Wykrywanie nieobsługiwanych formatów osadzonych zeszytów**

Aspose.Slides nie obsługuje formatu binarnego zeszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć właściwości [EmbeddedWorkbookType](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) na obiekcie [IChartData](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdata/) wraz z wymiennikiem [WorkbookType](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/workbooktype/) do wykrywania nieobsługiwanych formatów i pomijania takich wykresów. Ten przykład przegląda kształty na pierwszym slajdzie `sample.pptx`, pomija kształty niebędące wykresami i wypisuje komunikat diagnostyczny dla każdego wykresu z osadzonym zeszytem .xlsb.

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

    // Odczytaj lub zmodyfikuj obsługiwane dane zeszytu wykresu tutaj.
}
```

## **Zewnętrzny zeszyt**

Aspose.Slides obsługuje używanie zewnętrznych zeszytów jako źródła danych dla wykresów.

### **Utworzenie zewnętrznego zeszytu**

Użyj [ReadWorkbookStream](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdata/readworkbookstream/) i [SetExternalWorkbook](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdata/setexternalworkbook/), aby wyeksportować osadzony zeszyt wykresu do pliku i powiązać wykres z tym zewnętrznym zeszytem.

Ten przykład tworzy wykres kołowy z domyślnymi danymi, zapisuje jego zeszyt do `externalWorkbook1.xlsx` i zamyka strumień wyjściowy przed przypisaniem pliku jako źródła danych wykresu. Zapisuje połączoną prezentację do `externalWorkbook.pptx`.

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

### **Ustawienie zewnętrznego zeszytu**

Za pomocą metody [SetExternalWorkbook](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdata/setexternalworkbook/) możesz przypisać zewnętrzny zeszyt do wykresu jako jego źródło danych. Metoda może być również użyta do aktualizacji ścieżki do zewnętrznego zeszytu (jeżeli został on przeniesiony).

Chociaż nie możesz edytować danych w zeszytach przechowywanych w zdalnych lokalizacjach lub zasobach, możesz nadal używać takich zeszytów jako zewnętrznego źródła danych. Jeśli podana jest względna ścieżka do zewnętrznego zeszytu, zostaje ona automatycznie przekształcona w pełną ścieżkę.

Ten przykład wymaga `externalWorkbook.xlsx` w katalogu roboczym. Jego arkusz o nazwie `Sheet1` musi zawierać nazwę serii w B1, nazwy kategorii w A2:A4 oraz wartości liczbowe w B2:B4. Przykład tworzy wykres kołowy, powiązuje zeszyt i używa [SetRange](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdata/setrange/) do mapowania A1:B4 na jedną serię i trzy kategorie. Zapisuje wynik do `Presentation_with_externalWorkbook.pptx`.

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

Parametr `updateChartData` metody [SetExternalWorkbook](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdata/setexternalworkbook/) kontroluje, czy zeszyt jest ładowany.

* Gdy `updateChartData` jest `false`, aktualizowana jest tylko ścieżka do zeszytu. Dane wykresu nie są ładowane ani aktualizowane z docelowego zeszytu, więc zeszyt może być niedostępny.
* Gdy `updateChartData` jest `true`, dane wykresu są aktualizowane z docelowego zeszytu.

Poniższy przykład przypisuje przykładowy adres URL z `updateChartData` ustawionym na `false`. Zachowuje domyślne dane wykresu kołowego i zapisuje prezentację bez ładowania niedostępnego zeszytu.

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

### **Uzyskanie ścieżki zewnętrznego zeszytu danych wykresu**

Aby zidentyfikować zeszyt powiązany z wykresem, najpierw sprawdź, czy wykres używa zewnętrznego źródła danych. Jeśli tak, możesz odczytać ścieżkę zeszytu, wykonując następujące kroki.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu za pomocą indeksu zerowego.
3. Sprawdź, czy pierwsza forma jest wykresem.
4. Odczytaj typ źródła danych wykresu.
5. Jeśli źródłem jest zewnętrzny zeszyt, odczytaj jego ścieżkę.

Ten przykład otwiera `externalWorkbook.pptx`, utworzony w poprzednim przykładzie, i analizuje pierwszą formę na pierwszym slajdzie. Jeśli jest to wykres powiązany z zewnętrznym zeszytem, przykład wypisuje [ExternalWorkbookPath](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdata/externalworkbookpath/) w konsoli. Następnie zapisuje kopię prezentacji do `Result.pptx`.

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

### **Edycja danych wykresu**

Możesz edytować dane w zewnętrznych zeszytach tak samo, jak w wewnętrznych. Gdy zewnętrzny zeszyt nie może zostać załadowany, zostaje zgłoszony wyjątek.

Ten przykład wymaga `presentation.pptx` z wykresem jako pierwszą formą na pierwszym slajdzie oraz dostępnego zewnętrznego zeszytu. Ustawia wartość komórkową pierwszego punktu danych w pierwszej serii na 100 i zapisuje prezentację do `presentation_out.pptx`. Edycja wartości komórek może aktualizować powiązany zewnętrzny plik XLSX, więc użyj kopii, jeśli musisz zachować oryginalny zeszyt.

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

### **Odzyskiwanie zeszytu z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznego zeszytu, który jest brakujący lub niedostępny, Aspose.Slides może odtworzyć zeszyt wykresu z danych zapisanych w pamięci podręcznej prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/), skonfiguruj jego [SpreadsheetOptions](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/spreadsheetoptions/), i ustaw [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pl/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) na `true` przed otwarciem prezentacji.

Poniższy przykład C# otwiera `presentation.pptx`, którego pierwsza forma na pierwszym slajdzie musi być wykresem odwołującym się do niedostępnego zewnętrznego zeszytu, i uzyskuje odzyskane dane poprzez [IChart.ChartData](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichart/chartdata/) oraz [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

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

    // Odczytaj lub zmodyfikuj tutaj odzyskane dane zeszytu.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Jeśli zewnętrzny zeszyt jest niedostępny, a odzyskiwanie jest wyłączone, Aspose.Slides zgłasza [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Włączaj odzyskiwanie tylko wtedy, gdy użycie danych z pamięci podręcznej wykresu jest dopuszczalnym rozwiązaniem, ponieważ pamięć podręczna może nie zawierać zmian dokonanych w zewnętrznym zeszycie po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrznym, czy osadzonym zeszytem?**

Tak. Wykres ma [typ źródła danych](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chartdata/datasourcetype/) oraz [ścieżkę do zewnętrznego zeszytu](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chartdata/externalworkbookpath/); jeśli źródłem jest zewnętrzny zeszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy obsługiwane są względne ścieżki do zewnętrznych zeszytów i jak są one przechowywane?**

Tak. Jeśli podasz względną ścieżkę, zostaje ona automatycznie skonwertowana na ścieżkę bezwzględną. Prezentacja zapisuje ścieżkę bezwzględną w pliku PPTX, więc przeniesienie zeszytu może wymagać aktualizacji łącza.

**Czy mogę używać zeszytów znajdujących się w zasobach sieciowych/udostępnionych?**

Tak, takie zeszyty mogą być używane jako zewnętrzne źródło danych. Jednak edycja zdalnych zeszytów bezpośrednio z Aspose.Slides nie jest obsługiwana — mogą być używane jedynie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX przy zapisie prezentacji?**

Prezentacja przechowuje [odnośnik do pliku zewnętrznego](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chartdata/externalworkbookpath/). Edycja danych wykresu powiązanych z komórkami może również zaktualizować powiązany lokalny plik XLSX. Użyj kopii zeszytu, jeśli oryginał musi pozostać niezmieniony.

**Co zrobić, gdy zewnętrzny plik jest zabezpieczony hasłem?**

Aspose.Slides nie akceptuje hasła przy łączeniu. Typowym podejściem jest usunięcie ochrony wcześniej lub przygotowanie odszyfrowanej kopii (np. przy użyciu [Aspose.Cells](https://reference.aspose.com/cells/net/)) i podlinkowanie do tej kopii.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego zeszytu?**

Tak. Każdy wykres przechowuje własny odnośnik. Jeśli wszystkie wskazują na ten sam plik, aktualizacja tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym ładowaniu danych.