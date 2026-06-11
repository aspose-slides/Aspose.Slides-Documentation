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
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Odkryj Aspose.Slides dla .NET: łatwo zarządzaj skoroszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z skoroszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu przy użyciu strumieni skoroszytów, używać komórek skoroszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu. Omówiono również pracę z zewnętrznymi skoroszytami jako źródłami danych wykresu. Przykłady pokazują, jak utworzyć i przypisać zewnętrzny skoroszyt, pobrać ścieżkę zewnętrznego skoroszytu połączonego z wykresem oraz edytować dane wykresu, gdy skoroszyt jest dostępny.

## **Odczyt i zapis danych wykresu z skoroszytu**
Aspose.Slides udostępnia metody [ReadWorkbookStream](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdata/readworkbookstream/) i [WriteWorkbookStream](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdata/writeworkbookstream/), które pozwalają odczytywać i zapisywać skoroszyty danych wykresu (zawierające dane wykresu edytowane przy użyciu Aspose.Cells). **Uwaga** dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

Poniższy kod C# demonstruje przykładową operację:

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

## **Ustaw komórkę skoroszytu jako etykietę danych wykresu**
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
3. Dodaj wykres bąbelkowy z pewnymi danymi.
4. Uzyskaj dostęp do serii wykresu.
5. Ustaw komórkę skoroszytu jako etykietę danych.
6. Zapisz prezentację.

Poniższy kod C# pokazuje, jak ustawić komórkę skoroszytu jako etykietę danych wykresu:

```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Tworzy obiekt klasy prezentacji, który reprezentuje plik prezentacji

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

Poniższy kod C# demonstruje operację, w której właściwość [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) jest używana do uzyskania dostępu do kolekcji arkuszy:

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

Poniższy kod C# pokazuje, jak określić typ źródła danych:

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

## **Wykrywanie nieobsługiwanych formatów osadzonych skoroszytów**

Aspose.Slides nie obsługuje binarnego formatu skoroszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć właściwości `EmbeddedWorkbookType` na interfejsie [IChartData](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartdata/) wraz z wyliczeniem [WorkbookType](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/workbooktype/), aby wykrywać nieobsługiwane formaty i pomijać takie wykresy.

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
            // Osadzony skoroszyt jest w formacie .xlsb, który nie jest obsługiwany.
            continue;
        }

        // Odczytaj lub zmodyfikuj dane skoroszytu wykresu tutaj.
    }
}
```

## **Zewnętrzny skoroszyt**

{{% alert color="primary" %}} 
W wersji [Aspose.Slides 19.4](https://docs.aspose.com/slides/pl/net/aspose-slides-for-net-19-4-release-notes/) wprowadzono obsługę zewnętrznych skoroszytów jako źródła danych dla wykresów.
{{% /alert %}} 

### **Utworzenie zewnętrznego skoroszytu**
Korzystając z metod **`ReadWorkbookStream`** i **`SetExternalWorkbook`**, możesz utworzyć zewnętrzny skoroszyt od podstaw lub zmienić wewnętrzny skoroszyt w zewnętrzny.

Poniższy kod C# demonstruje proces tworzenia zewnętrznego skoroszytu:

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

### **Ustawienie zewnętrznego skoroszytu**
Korzystając z metody **`SetExternalWorkbook`**, możesz przypisać zewnętrzny skoroszyt do wykresu jako jego źródło danych. Metoda ta może również służyć do aktualizacji ścieżki do zewnętrznego skoroszytu (jeśli został on przeniesiony). Chociaż nie możesz edytować danych w skoroszytach przechowywanych w zdalnych lokalizacjach lub zasobach, możesz nadal używać takich skoroszytów jako zewnętrznego źródła danych. Jeśli podana zostanie względna ścieżka do zewnętrznego skoroszytu, zostaje ona automatycznie przekształcona na pełną ścieżkę.

Poniższy kod C# pokazuje, jak ustawić zewnętrzny skoroszyt:

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

Parametr `ChartData` (w metodzie `SetExternalWorkbook`) służy do określenia, czy skoroszyt Excel zostanie załadowany.

* Gdy wartość `ChartData` jest ustawiona na `false`, aktualizowana jest tylko ścieżka do skoroszytu – dane wykresu nie zostaną załadowane ani zaktualizowane z docelowego skoroszytu. Możesz użyć tego ustawienia, gdy docelowy skoroszyt nie istnieje lub jest niedostępny.  
* Gdy wartość `ChartData` jest ustawiona na `true`, dane wykresu zostają zaktualizowane z docelowego skoroszytu.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.ChartData;

    (chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

    pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Pobranie ścieżki skoroszytu zewnętrznego źródła danych wykresu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
3. Utwórz obiekt dla kształtu wykresu.
4. Utwórz obiekt typu źródła (`ChartDataSourceType`), który reprezentuje źródło danych wykresu.
5. Określ odpowiedni warunek, bazując na tym, że typ źródła jest taki sam jak typ zewnętrznego skoroszytu.

Poniższy kod C# demonstruje tę operację:

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

Możesz edytować dane w zewnętrznych skoroszytach tak samo, jak wprowadzisz zmiany w zawartości wewnętrznych skoroszytów. Gdy zewnętrzny skoroszyt nie może zostać załadowany, zostaje zgłoszony wyjątek.

Poniższy kod C# jest implementacją opisanej procedury:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest połączony z zewnętrznym czy osadzonym skoroszytem?**

Tak. Wykres posiada [typ źródła danych](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chartdata/datasourcetype/) oraz [ścieżkę do zewnętrznego skoroszytu](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chartdata/externalworkbookpath/); jeśli źródłem jest zewnętrzny skoroszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy względne ścieżki do zewnętrznych skoroszytów są obsługiwane i jak są przechowywane?**

Tak. Jeśli podasz względną ścieżkę, zostanie ona automatycznie przekształcona na ścieżkę bezwzględną. Jest to wygodne przy przenoszeniu projektu; jednak należy pamiętać, że prezentacja zapisze ścieżkę bezwzględną w pliku PPTX.

**Czy mogę używać skoroszytów znajdujących się na zasobach/udostępnieniach sieciowych?**

Tak, takie skoroszyty mogą być używane jako zewnętrzne źródło danych. Jednak edycja zdalnych skoroszytów bezpośrednio z Aspose.Slides nie jest obsługiwana – mogą być używane wyłącznie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX podczas zapisywania prezentacji?**

Nie. Prezentacja przechowuje [odwołanie do zewnętrznego pliku](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chartdata/externalworkbookpath/), które jest używane do odczytu danych. Sam zewnętrzny plik nie jest modyfikowany podczas zapisywania prezentacji.

**Co powinienem zrobić, jeśli zewnętrzny plik jest chroniony hasłem?**

Aspose.Slides nie przyjmuje hasła przy tworzeniu odwołania. Typowe podejście polega na wcześniejszym usunięciu zabezpieczenia lub przygotowaniu odszyfrowanej kopii (na przykład przy użyciu [Aspose.Cells](/cells/net/)) i odwołaniu się do tej kopii.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego skoroszytu?**

Tak. Każdy wykres przechowuje własne odwołanie. Jeśli wszystkie wskazują na ten sam plik, aktualizacja tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym wczytaniu danych.