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
- dane zewnętrzne
- pamięć podręczna wykresu
- odzyskiwanie zeszytu
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Odkryj Aspose.Slides dla .NET: łatwo zarządzaj zeszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane w prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z zeszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu za pośrednictwem strumieni zeszytów, używać komórek zeszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Opisuje także pracę z zewnętrznymi zeszytami jako źródłami danych wykresu. Przykłady demonstrują, jak utworzyć i przypisać zewnętrzny zeszyt, pobrać ścieżkę zewnętrznego zeszytu powiązanego z wykresem oraz edytować dane wykresu, gdy zeszyt jest dostępny.

## **Odczyt i zapis danych wykresu z zeszytu**
Aspose.Slides udostępnia metody [ReadWorkbookStream](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdata/readworkbookstream/) i [WriteWorkbookStream](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdata/writeworkbookstream/), które pozwalają odczytywać i zapisywać zeszyty danych wykresu (zawierające dane wykresu edytowane przy użyciu Aspose.Cells). **Uwaga** dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

Ten kod C# demonstruje przykładową operację:

```c#
using (Presentation pres = new Presentation("chart.pptx"))
{
    Chart chart = (Chart) pres.Slides[0].Shapes[0];
    IChartData data = chart.ChartData;

    MemoryStream stream = data.ReadWorkbookStream();

    data.Series.Clear();
    data.Categories.Clear();

    stream.Position = 0;
    data.WriteWorkbookStream(stream);
}
```

## **Ustaw komórkę zeszytu jako etykietę danych wykresu**
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
3. Dodaj wykres bąbelkowy z danymi.
4. Uzyskaj dostęp do serii wykresu.
5. Ustaw komórkę zeszytu jako etykietę danych.
6. Zapisz prezentację.

Ten kod C# pokazuje, jak ustawić komórkę zeszytu jako etykietę danych wykresu:

```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji 

using (Presentation pres = new Presentation("chart2.pptx"))
{
    ISlide slide = pres.Slides[0];


    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);

    IChartSeriesCollection series = chart.ChartData.Series;

    series[0].Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

    IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

    series[0].Labels[0].ValueFromCell = wb.GetCell(0, "A10", lbl0);
    series[0].Labels[1].ValueFromCell = wb.GetCell(0, "A11", lbl1);
    series[0].Labels[2].ValueFromCell = wb.GetCell(0, "A12", lbl2);

    pres.Save("resultchart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Zarządzanie arkuszami**

Ten kod C# demonstruje operację, w której właściwość [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) jest używana do uzyskania dostępu do kolekcji arkuszy:

``` csharp
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Określenie typu źródła danych**

Ten kod C# pokazuje, jak określić typ źródła danych:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.ChartData.Series[0].Name;
    
    val.DataSourceType = DataSourceType.StringLiterals;
    val.Data = "LiteralString";

    val = chart.ChartData.Series[1].Name;
    val.Data = chart.ChartData.ChartDataWorkbook.GetCell(0, "B1", "NewCell");

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Wykrywanie nieobsługiwanych formatów osadzonych zeszytów**

Aspose.Slides nie obsługuje binarnego formatu zeszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Można użyć właściwości `EmbeddedWorkbookType` w [IChartData](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdata/) razem z wyliczeniem [WorkbookType](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/workbooktype/), aby wykrywać nieobsługiwane formaty i pomijać te wykresy.

```csharp
using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        if (shape is not IChart chart) continue;

        var chartData = chart.ChartData;

        if (chartData.DataSourceType == ChartDataSourceType.InternalWorkbook &&
            chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro)
        {
            // Osadzony zeszyt jest w formacie .xlsb, który nie jest obsługiwany.
            continue;
        }

        // Odczytaj lub zmodyfikuj dane zeszytu wykresu tutaj.
    }
}
```

## **Zewnętrzny zeszyt**

{{% alert color="primary" %}} 
W [Aspose.Slides 19.4](https://docs.aspose.com/slides/pl/net/aspose-slides-for-net-19-4-release-notes/) wprowadziliśmy obsługę zewnętrznych zeszytów jako źródła danych dla wykresów.
{{% /alert %}} 

### **Utworzenie zewnętrznego zeszytu**
Korzystając z metod **`ReadWorkbookStream`** i **`SetExternalWorkbook`**, możesz albo utworzyć od podstaw zewnętrzny zeszyt, albo uczynić wewnętrzny zeszyt zewnętrznym.

Ten kod C# demonstruje proces tworzenia zewnętrznego zeszytu:

```c#
using (Presentation pres = new Presentation())
{
    const string workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
    using (FileStream fileStream = new FileStream(workbookPath, FileMode.Create))
    {
        byte[] workbookData = chart.ChartData.ReadWorkbookStream().ToArray();
        fileStream.Write(workbookData, 0, workbookData.Length);
    }
    
    chart.ChartData.SetExternalWorkbook(Path.GetFullPath(workbookPath));

    pres.Save("externalWorkbook.pptx", SaveFormat.Pptx);
}
```

### **Ustawienie zewnętrznego zeszytu**
Korzystając z metody **`SetExternalWorkbook`**, możesz przypisać zewnętrzny zeszyt do wykresu jako jego źródło danych. Metoda ta może także służyć do aktualizacji ścieżki do zewnętrznego zeszytu (jeśli ten został przeniesiony).

Choć nie możesz edytować danych w zeszytach przechowywanych w zdalnych lokalizacjach lub zasobach, możesz nadal używać takich zeszytów jako zewnętrznego źródła danych. Jeśli podana jest ścieżka względna do zewnętrznego zeszytu, zostaje ona automatycznie przekształcona w pełną ścieżkę.

Ten kod C# pokazuje, jak ustawić zewnętrzny zeszyt:

```c#
// Ścieżka do katalogu dokumentów.
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.ChartData;
                    
    chartData.SetExternalWorkbook(Path.GetFullPath("externalWorkbook.xlsx"));
              

    chartData.Series.Add(chartData.ChartDataWorkbook.GetCell(0, "B1"), ChartType.Pie);
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B2"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B3"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B4"));

    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A2"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A3"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A4"));
    pres.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
}
```

Parametr `ChartData` (w metodzie `SetExternalWorkbook`) służy do określenia, czy zeszyt Excel zostanie załadowany.

- Gdy wartość `ChartData` jest ustawiona na `false`, aktualizowana jest tylko ścieżka do zeszytu — dane wykresu nie będą ładowane ani aktualizowane z docelowego zeszytu. Użyj tego ustawienia, gdy docelowy zeszyt nie istnieje lub jest niedostępny. 
- Gdy wartość `ChartData` jest ustawiona na `true`, dane wykresu są aktualizowane z docelowego zeszytu.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Uzyskanie ścieżki zewnętrznego zeszytu źródła danych wykresu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
3. Utwórz obiekt dla kształtu wykresu.
4. Utwórz obiekt typu źródła (`ChartDataSourceType`), które reprezentuje źródło danych wykresu.
5. Określ odpowiedni warunek, bazując na tym, że typ źródła jest taki sam jak typ źródła danych zewnętrznego zeszytu.

Ten kod C# demonstruje tę operację:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[1];
    IChart chart = (IChart)slide.Shapes[0];
    ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        string path = chart.ChartData.ExternalWorkbookPath;
    }
    
    // Zapisuje prezentację
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **Edycja danych wykresu**

Możesz edytować dane w zewnętrznych zeszytach w taki sam sposób, jak zmieniasz zawartość wewnętrznych zeszytów. Gdy zewnętrzny zeszyt nie może zostać załadowany, zostaje zgłoszony wyjątek.

Ten kod C# jest implementacją opisanego procesu:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **Odzyskanie zeszytu z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznego zeszytu, który jest brakujący lub niedostępny, Aspose.Slides może odtworzyć zeszyt wykresu z danych zapisanych w pamięci podręcznej prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/), skonfiguruj jego [SpreadsheetOptions](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/spreadsheetoptions/) i ustaw [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pl/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) na `true` przed otwarciem prezentacji.

Poniższy przykład C# otwiera prezentację, której wykres odwołuje się do niedostępnego zewnętrznego zeszytu, i uzyskuje dostęp do odzyskanych danych za pośrednictwem [IChart.ChartData](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichart/chartdata/) oraz [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

```csharp
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        RecoverWorkbookFromChartCache = true
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

var chart = (IChart)presentation.Slides[0].Shapes[0];
var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

// Odczytaj lub zmodyfikuj dane odzyskanego zeszytu tutaj.
```

Jeśli zewnętrzny zeszyt jest niedostępny, a odzyskiwanie jest wyłączone, Aspose.Slides zgłasza `InvalidOperationException`. Włącz odzyskiwanie tylko wtedy, gdy użycie danych wykresu z pamięci podręcznej jest akceptowalnym rozwiązaniem awaryjnym, ponieważ pamięć podręczna może nie zawierać zmian wprowadzonych do zewnętrznego zeszytu po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrznym czy osadzonym zeszytem?**

Tak. Wykres posiada [typ źródła danych](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chartdata/datasourcetype/) oraz [ścieżkę do zewnętrznego zeszytu](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chartdata/externalworkbookpath/); jeśli źródłem jest zewnętrzny zeszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy obsługiwane są ścieżki względne do zewnętrznych zeszytów i w jaki sposób są one przechowywane?**

Tak. Jeśli podasz ścieżkę względną, zostanie ona automatycznie przekształcona w ścieżkę bezwzględną. Ułatwia to przenoszenie projektów; jednak pamiętaj, że prezentacja zapisze ścieżkę bezwzględną w pliku PPTX.

**Czy mogę używać zeszytów znajdujących się na zasobach/udostępnieniach sieciowych?**

Tak, takie zeszyty mogą być używane jako zewnętrzne źródło danych. Jednak edycja zdalnych zeszytów bezpośrednio z Aspose.Slides nie jest obsługiwana — mogą być używane wyłącznie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX podczas zapisywania prezentacji?**

Nie. Prezentacja przechowuje [odnośnik do zewnętrznego pliku](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chartdata/externalworkbookpath/) i używa go do odczytu danych. Sam zewnętrzny plik nie jest modyfikowany przy zapisywaniu prezentacji.

**Co zrobić, jeśli zewnętrzny plik jest chroniony hasłem?**

Aspose.Slides nie przyjmuje hasła podczas tworzenia odnośnika. Typowe rozwiązanie to usunięcie ochrony wcześniej lub przygotowanie odszyfrowanej kopii (na przykład przy użyciu [Aspose.Cells](/cells/net/)) i odwołanie się do tej kopii.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego zeszytu?**

Tak. Każdy wykres przechowuje własny odnośnik. Jeśli wszystkie wskazują na ten sam plik, aktualizacja tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym wczytaniu danych.