---
title: Zarządzanie książkami wykresów w prezentacjach w .NET
linktitle: Książka wykresu
type: docs
weight: 70
url: /pl/net/chart-workbook/
keywords:
- książka wykresu
- dane wykresu
- komórka skoroszytu
- etykieta danych
- arkusz
- źródło danych
- zewnętrzny skoroszyt
- zewnętrzne dane
- bufor wykresu
- odzyskiwanie skoroszytu
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Odkryj Aspose.Slides dla .NET: łatwo zarządzaj książkami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane w swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z książkami roboczymi wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu za pomocą strumieni książek, używać komórek książki jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Opisuje również pracę z zewnętrznymi książkami jako źródłami danych wykresu. Przykłady demonstrują, jak utworzyć i przypisać zewnętrzną książkę, pobrać ścieżkę zewnętrznej książki połączonej z wykresem oraz edytować dane wykresu, gdy książka jest dostępna.

Dla komórek książki reprezentujących brakujące dane, zobacz [Kontrola wyświetlania pustych komórek](/slides/pl/net/chart-series/) aby poznać różnicę między pustą komórką a zerem oraz porównanie wykresu liniowego dostępnych trybów wyświetlania.

## **Dołączanie danych z ukrytych wierszy i kolumn**

Użyj [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) aby kontrolować, czy wykres rysuje dane z ukrytych wierszy i kolumn arkusza. Ustaw na `true`, aby rysować tylko widoczne komórki, lub `false`, aby uwzględnić zarówno widoczne, jak i ukryte komórki. To ustawienie kontroluje rysowanie wykresu; nie ukrywa ani nie odkrywa wierszy lub kolumn arkusza.

Z [przykładową prezentacją](hidden-source-data.pptx) zawiera wykres kolumnowy jako pierwszy obiekt na pierwszym slajdzie. Osadzony arkusz, `Sheet1`, zawiera następujący zakres źródłowy, `A1:C4`. Wiersz 3 i kolumna C są ukryte, ale ich komórki nadal zawierają wartości.

| Wiersz arkusza | A: Miesiąc | B: Sprzedaż detaliczna | C: Sprzedaż hurtowa (ukryta kolumna) |
| --- | --- | --- | --- |
| 2 | Styczeń | 10 | 30 |
| 3 (ukryty wiersz) | Luty | 40 | 60 |
| 4 | Marzec | 20 | 50 |

Uzyskaj dostęp do komórek źródłowych poprzez [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) i odczytaj [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) aby sprawdzić ich ukryty status. Ta właściwość jest tylko do odczytu. W tym pliku B2 jest widoczne, B3 należy do ukrytego wiersza, a C2 do ukrytej kolumny; przykład wyświetla `False`, `True` i `True` odpowiednio.

W tym przykładzie odśwież dane wykresu po zmianie ustawienia rysowania: zachowaj osadzony skoroszyt przy pomocy [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) i ponownie wczytaj go przy pomocy [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/). Gdy uwzględniasz wszystkie komórki, użyj także [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) aby przywrócić pełny zakres, włączając ukrytą kategorię luty. Jedynie zmiana flagi nie wystarczy do odświeżenia buforowanych danych wykresu i etykiet kategorii w tym przykładzie.

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

Przykład zapisuje dwie wersje prezentacji: jedną z jedynie widocznymi wartościami Sprzedaży detalicznej (10 i 20), oraz drugą ze wszystkimi sześcioma wartościami. Poniższe obrazy zostały wygenerowane z zapisanych prezentacji po ich ponownym otwarciu; oba pliki zachowują przypisane ustawienie rysowania. Wiersz 3 i kolumna C pozostają ukryte w obu osadzonych skoroszytach.

| Tylko widoczne komórki (`true`) | Wszystkie komórki (`false`) |
| --- | --- |
| ![Tylko widoczne komórki: wartości Sprzedaży detalicznej 10 i 20 dla stycznia i marca.](hidden_cells_True.png) | ![Wszystkie komórki: wartości Sprzedaży detalicznej i hurtowej dla stycznia, lutego i marca.](hidden_cells_False.png) |

Ukryta komórka zawierająca wartość różni się od pustej komórki. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) kontroluje, jak wyświetlane są brakujące wartości; nie obejmuje ani nie wyklucza ukrytych danych źródłowych. Zobacz [Kontrola wyświetlania pustych komórek](/slides/pl/net/chart-series/#control-the-display-of-empty-cells) dla przykładu.

## **Pobieranie zakresu danych wykresu**

Przed aktualizacją danych skoroszytu w istniejącej prezentacji, sprawdź zakresy źródłowe, aby zidentyfikować, które komórki arkusza używa każdy wykres. Metoda [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) zwraca bieżący zakres danych jako formułę kwalifikowaną arkuszem, np. `Sheet1!$A$1:$D$5`. Tutaj `Sheet1` jest nazwą arkusza, `!` oddziela ją od zakresu komórek, a `$A$1:$D$5` określa komórki od A1 do D5 włącznie. Znaki dolara oznaczają bezwzględne odwołania do wierszy i kolumn.

Metoda odczytuje bieżący zakres bez zmiany wykresu ani jego skoroszytu. Jeśli wykres nie używa skoroszytu jako źródła danych, zgłasza [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Aby uzyskać więcej informacji, zobacz [ChartData API Reference](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/).

Ten przykład otwiera prezentację i sprawdza kształty bezpośrednio na każdym slajdzie pod kątem wykresów. Wyświetla nazwę każdego wykresu oraz zakres źródłowy. Jeśli wykres nie używa skoroszytu, wypisuje komunikat i przechodzi do kolejnego wykresu.

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

## **Odczyt i zapis danych wykresu z skoroszytu**

Aspose.Slides dla .NET udostępnia metody [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) i [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/), które pozwalają odczytywać i zapisywać skoroszyty danych wykresu (zawierające dane wykresu edytowane przy użyciu Aspose.Cells). **Uwaga** że dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

Ten przykład używa prezentacji z wykresem jako pierwszym obiektem na pierwszym slajdzie. Odczytuje osadzony skoroszyt do strumienia, czyści istniejące serie i kategorie oraz zapisuje ten sam skoroszyt z powrotem. Zmiany pozostają w pamięci; przykład nie zapisuje prezentacji.

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

### **Walidacja układu wykresu po modyfikacji skoroszytu**

Gdy zamienisz osadzony skoroszyt na zmodyfikowany, wykres zachowuje oryginalne kolekcje serii i kategorii. To niezgodność może spowodować, że [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) zakończy się niepowodzeniem z błędem indeksu poza zakresem. Wyczyść istniejące serie i kategorie przed zapisaniem zmodyfikowanego skoroszytu z powrotem do wykresu. Ten przykład używa wykresu, który jest pierwszym obiektem na pierwszym slajdzie. Komentarz oznacza miejsce, w którym miałoby nastąpić edytowanie skoroszytu; uruchamialny przykład zapisuje oryginalny skoroszyt z powrotem i waliduje układ w pamięci.

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

    // Zmodyfikuj strumień skoroszytu tutaj, na przykład przy użyciu Aspose.Cells.

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

Wyczyszczenie kolekcji usuwa nieaktualne odwołania do danych przed zapisaniem skoroszytu. Przed użyciem wykresu odtwórz wymagane mapowania serii i kategorii dla zaktualizowanego skoroszytu.

## **Ustawianie własnych formatów liczbowych dla komórek skoroszytu**

Użyj [ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) aby kontrolować, jak wyświetlane są wartości liczbowe w osadzonym skoroszycie wykresu. Na przykład raport może wymagać wyświetlenia stawki konwersji jako procentu z czterema miejscami po przecinku oraz współczynnika z pięcioma miejscami po przecinku. Zachowaj obie wartości jako liczby, aby pozostawały dostępne do obliczeń i rysowania wykresu.

Format liczbowy zmienia wyświetlanie, a nie przechowywaną wartość. Format `0.0000%` wyświetla `0.125` jako `12.5000%`; nie zastępuje przechowywanej liczby `12.5`. Podobnie, `0.00000` wyświetla `0.1234567` jako `0.12346` bez zaokrąglania przechowywanej wartości. Jeśli własny format jest pustym ciągiem (`""`), zamiast niego używany jest [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/).

Poniższy przykład tworzy wykres kolumnowy i uzyskuje dostęp do jego komórek za pośrednictwem [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/). W arkuszu 0, B2 zawiera stawkę konwersji, a C2 współczynnik. Obie komórki dostarczają wartości wykresu. Przykład również włącza etykiety wartości powiązane z formatami źródłowymi.

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

Formaty komórek skoroszytu są oddzielne od formatów ustawionych bezpośrednio na osiach wykresu lub etykietach danych. W tym przykładzie każda etykieta wyświetla wartość swojej komórki źródłowej, ponieważ [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) jest włączone, a format liczbowy jest powiązany ze źródłem, ponieważ [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) ma wartość `true`. Po zapisaniu i ponownym otwarciu prezentacji, etykiety wyświetlają `12.5000%` i `0.12346`, jak pokazano poniżej. Pionowa oś używa własnego [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) `0.00`, przy czym [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) ma wartość `false`.

Aby sformatować etykietę danych niezależnie, ustaw jej flagę powiązania ze źródłem na `false` i przypisz jej [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/). Nie zmienia to formatu komórki skoroszytu. Na przykład niezależny format etykiety `0.00` wyświetla pierwszą wartość jako `0.13`, podczas gdy B2 wciąż wyświetla `12.5000%`. Zobacz [Chart Data Labels](/slides/pl/net/chart-data-label/#set-percentage-sign-with-chart-data-labels) w celu bezpośredniego formatowania etykiet.

![Wykres kolumnowy z etykietami połączonymi ze źródłem pokazującymi 12.5000% i 0.12346 oraz niezależnie sformatowaną osią liczbową.](custom-cell-formats.png)

## **Ustawienie komórki skoroszytu jako etykiety danych wykresu**

Możesz używać tekstu z komórek skoroszytu jako etykiet danych wykresu.

Ten przykład dodaje wykres bąbelkowy z domyślnymi danymi do pierwszego slajdu istniejącej prezentacji. Używa komórek A10:A12 w arkuszu 0 dla pierwszych trzech etykiet w pierwszej serii, włącza etykiety z komórek i zapisuje zaktualizowaną prezentację.

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

Właściwość [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) zapewnia dostęp do arkuszy w skoroszycie wykresu. Ten przykład tworzy wykres kołowy z domyślnymi danymi i wypisuje nazwę każdego arkusza na konsoli.

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

Ten przykład tworzy trójwymiarowy wykres kolumnowy z domyślnymi danymi i ustawia dwie nazwy serii, używając różnych źródeł danych. Pierwsza nazwa jest łańcuchem znakowym, druga używa komórki C1 w arkuszu 0. Wyliczenie [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) wybiera źródło dla każdej nazwy. Przykład zapisuje prezentację z zaktualizowanymi nazwami serii.

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

## **Wykrywanie nieobsługiwanych formatów osadzonych skoroszytów**

Aspose.Slides nie obsługuje binarnego formatu skoroszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć właściwości [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) w [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) razem z wyliczeniem [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/), aby wykrywać nieobsługiwane formaty i pomijać te wykresy. Ten przykład sprawdza kształty na pierwszym slajdzie istniejącej prezentacji, pomija kształty niebędące wykresami i wypisuje komunikat diagnostyczny dla każdego wykresu z osadzonym skoroszytem .xlsb.

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

    // Odczytaj lub zmodyfikuj tutaj obsługiwane dane skoroszytu wykresu.
}
```

## **Zewnętrzny skoroszyt**

Aspose.Slides obsługuje używanie zewnętrznych skoroszytów jako źródła danych dla wykresów.

### **Utworzenie zewnętrznego skoroszytu**

Użyj [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) i [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) aby wyeksportować osadzony skoroszyt wykresu do pliku i połączyć wykres z tym zewnętrznym skoroszytem.

Ten przykład tworzy wykres kołowy z domyślnymi danymi i eksportuje jego skoroszyt. Zamka strumień wyjściowy przed przypisaniem zewnętrznego skoroszytu jako źródła danych wykresu, a następnie zapisuje połączoną prezentację.

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

### **Ustawienie zewnętrznego skoroszytu**

Używając metody [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/), możesz przypisać zewnętrzny skoroszyt do wykresu jako jego źródło danych. Metoda ta może być również użyta do aktualizacji ścieżki do zewnętrznego skoroszytu (jeśli został on przeniesiony).

Chociaż nie możesz edytować danych w skoroszytach przechowywanych w zdalnych lokalizacjach lub zasobach, nadal możesz używać takich skoroszytów jako zewnętrznego źródła danych. Jeśli podana zostanie ścieżka względna do zewnętrznego skoroszytu, zostanie ona automatycznie przekształcona w pełną ścieżkę.

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

* Gdy `updateChartData` ma wartość `false`, aktualizowana jest jedynie ścieżka do skoroszytu. Dane wykresu nie są ładowane ani aktualizowane z docelowego skoroszytu, więc skoroszyt może być niedostępny.
* Gdy `updateChartData` ma wartość `true`, dane wykresu są aktualizowane z docelowego skoroszytu.

Poniższy przykład przypisuje przykładowy adres URL z `updateChartData` ustawionym na `false`. Zachowuje domyślne dane wykresu kołowego i zapisuje prezentację bez ładowania niedostępnego skoroszytu.

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

### **Pobranie ścieżki skoroszytu źródła danych zewnętrznych wykresu**

Aby zidentyfikować skoroszyt połączony z wykresem, sprawdź, czy wykres używa zewnętrznego źródła danych i pobierz jego ścieżkę.

Ten przykład sprawdza pierwszy kształt na pierwszym slajdzie prezentacji z połączonym zewnętrznym skoroszytem. Jeśli jest to wykres połączony z zewnętrznym skoroszytem, przykład wypisuje [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) na konsoli. Następnie zapisuje kopię prezentacji.

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

Możesz edytować dane w zewnętrznych skoroszytach w taki sam sposób, w jaki wprowadzasz zmiany w zawartości wewnętrznych skoroszytów. Gdy zewnętrzny skoroszyt nie może zostać załadowany, zostaje rzucony wyjątek.

Ten przykład używa wykresu, który jest pierwszym kształtem na pierwszym slajdzie i jest połączony z dostępnym zewnętrznym skoroszytem. Ustawia wartość opartą na komórce pierwszego punktu danych w pierwszej serii na 100 i zapisuje zaktualizowaną prezentację. Edycja wartości komórek może aktualizować połączony zewnętrzny plik XLSX, więc użyj kopii, jeśli musisz zachować oryginalny skoroszyt.

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

### **Odzyskiwanie skoroszytu z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznego skoroszytu, który jest brakujący lub niedostępny, Aspose.Slides może odtworzyć skoroszyt wykresu z danych buforowanych w prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/), skonfiguruj jego [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/), i ustaw [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) na `true` przed otwarciem prezentacji.

Poniższy przykład w C# odzyskuje dane skoroszytu dla wykresu, który jest pierwszym kształtem na pierwszym slajdzie i odwołuje się do niedostępnego zewnętrznego skoroszytu. Uzyskuje dostęp do odzyskanych danych poprzez [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) i [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

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

    // Odczytaj lub zmodyfikuj tutaj odzyskane dane skoroszytu.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Jeśli zewnętrzny skoroszyt jest niedostępny i odzyskiwanie jest wyłączone, Aspose.Slides zgłasza [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Włącz odzyskiwanie tylko wtedy, gdy użycie buforowanych danych wykresu jest akceptowalnym rozwiązaniem awaryjnym, ponieważ pamięć podręczna może nie zawierać zmian wprowadzonych w zewnętrznym skoroszycie po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest połączony z zewnętrznym czy osadzonym skoroszytem?**

Tak. Wykres posiada [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) oraz [path to an external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/); jeśli źródłem jest zewnętrzny skoroszyt, można odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy ścieżki względne do zewnętrznych skoroszytów są obsługiwane i jak są przechowywane?**

Tak. Jeśli podasz ścieżkę względną, zostanie ona automatycznie przekształcona w ścieżkę bezwzględną. Prezentacja przechowuje ścieżkę bezwzględną w pliku PPTX, więc przeniesienie skoroszytu może wymagać aktualizacji odnośnika.

**Czy mogę używać skoroszytów znajdujących się na zasobach/udziałach sieciowych?**

Tak, takie skoroszyty mogą być używane jako zewnętrzne źródło danych. Jednak edycja zdalnych skoroszytów bezpośrednio z Aspose.Slides nie jest obsługiwana — mogą być używane wyłącznie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX przy zapisywaniu prezentacji?**

Prezentacja przechowuje [link to the external file](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/). Edycja danych wykresu opartych na komórkach może również aktualizować połączony lokalny plik XLSX. Użyj kopii skoroszytu, jeśli oryginał musi pozostać niezmieniony.

**Co zrobić, jeśli zewnętrzny plik jest chroniony hasłem?**

Aspose.Slides nie akceptuje hasła przy łączeniu. Powszechnym podejściem jest usunięcie ochrony wcześniej lub przygotowanie odszyfrowanej kopii (na przykład przy użyciu [Aspose.Cells](https://reference.aspose.com/cells/net/)) i połączenie się z tą kopią.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego skoroszytu?**

Tak. Każdy wykres przechowuje własny odnośnik. Jeśli wszystkie wskazują na ten sam plik, aktualizacja tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym wczytaniu danych.