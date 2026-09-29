---
title: Zarządzanie skoroszytami wykresów w prezentacjach przy użyciu C++
linktitle: Skoroszyt wykresu
type: docs
weight: 70
url: /pl/cpp/chart-workbook/
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
- C++
- Aspose.Slides
description: "Odkryj Aspose.Slides dla C++: łatwo zarządzaj skoroszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane w swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z skoroszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu przy użyciu strumieni skoroszytu, używać komórek skoroszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Omówiono także pracę z zewnętrznymi skoroszytami jako źródłami danych wykresu. Przykłady demonstrują, jak utworzyć i przypisać zewnętrzny skoroszyt, pobrać ścieżkę zewnętrznego skoroszytu połączonego z wykresem oraz edytować dane wykresu, gdy skoroszyt jest dostępny.

Aby dowiedzieć się, jak obsługiwać komórki reprezentujące brakujące dane, zobacz [Control the Display of Empty Cells](/slides/pl/cpp/chart-series/) – wyjaśnia różnicę między pustą komórką a zerem oraz porównanie wykresu liniowego dostępnych trybów wyświetlania.

## **Dołączanie danych z ukrytych wierszy i kolumn**

Użyj [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) aby kontrolować, czy wykres rysuje dane z ukrytych wierszy i kolumn arkusza. Ustaw `true`, aby rysować tylko widoczne komórki, lub `false`, aby uwzględnić zarówno widoczne, jak i ukryte komórki. To ustawienie kontroluje rysowanie wykresu; nie ukrywa ani nie odsłania wierszy lub kolumn arkusza.

Pobierz [hidden-source-data.pptx](hidden-source-data.pptx) i umieść go w katalogu roboczym. Na pierwszym slajdzie znajduje się wykres kolumnowy jako pierwszy kształt. Osadzony arkusz, `Sheet1`, zawiera zakres źródłowy `A1:C4`. Wiersz 3 i kolumna C są ukryte, ale ich komórki nadal zawierają wartości.

| Wiersz arkusza | A: Month | B: Retail | C: Wholesale (ukryta kolumna) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (ukryty wiersz) | February | 40 | 60 |
| 4 | March | 20 | 50 |

Uzyskaj dostęp do komórek źródłowych przez [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) i odczytaj [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/), aby sprawdzić ich status ukrycia. Ta właściwość jest tylko do odczytu. W tym pliku B2 jest widoczny, B3 należy do ukrytego wiersza, a C2 do ukrytej kolumny; przykład wypisuje kolejno `False`, `True` i `True`.

W tym przykładzie odśwież dane wykresu po zmianie ustawienia rysowania: zachowaj osadzony skoroszyt przy użyciu [ReadWorkbookStream](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) i ponownie wczytaj go za pomocą [WriteWorkbookStream](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/). Przy włączaniu wszystkich komórek użyj także [SetRange](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdata/setrange/), aby przywrócić pełny zakres, w tym ukrytą kategorię February. Same zmiany flagi nie odświeżą pamięci podręcznej danych wykresu i etykiet kategorii w tym przykładzie.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <initializer_list>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"hidden-source-data.pptx");
auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    Console::WriteLine(u"B2 hidden: {0}", workbook->GetCell(0, u"B2")->get_IsHidden());
    Console::WriteLine(u"B3 hidden: {0}", workbook->GetCell(0, u"B3")->get_IsHidden());
    Console::WriteLine(u"C2 hidden: {0}", workbook->GetCell(0, u"C2")->get_IsHidden());

    auto workbookStream = chart->get_ChartData()->ReadWorkbookStream();
    for (auto visibleOnly : {true, false})
    {
        chart->set_PlotVisibleCellsOnly(visibleOnly);

        // Odśwież dane wykresu z osadzonego skoroszytu.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Przywróć pełny zakres źródłowy, w tym ukryte kategorie.
            chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$C$4");
        }

        auto outputPath = visibleOnly ? u"hidden_cells_True.pptx" : u"hidden_cells_False.pptx";
        presentation->Save(outputPath, Export::SaveFormat::Pptx);
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Przykład zapisuje `hidden_cells_True.pptx` z jedynie widocznymi wartościami Retail (10 i 20) oraz `hidden_cells_False.pptx` ze wszystkimi sześcioma wartościami. Poniższe obrazy ilustrują dwa tryby rysowania. Wiersz 3 i kolumna C pozostają ukryte w obu osadzonych skoroszytach.

| Tylko widoczne komórki (`true`) | Wszystkie komórki (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

Ukryta komórka zawierająca wartość różni się od pustej komórki. [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichart/get_displayblanksas/) kontroluje, jak wyświetlane są brakujące wartości; nie obejmuje ani nie wyklucza ukrytych danych źródłowych. Zobacz [Control the Display of Empty Cells](/slides/pl/cpp/chart-series/#control-the-display-of-empty-cells) po przykład.

## **Odczyt i zapis danych wykresu ze skoroszytu**

Aspose.Slides for C++ udostępnia metody [ReadWorkbookStream](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) i [WriteWorkbookStream](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/), które umożliwiają odczyt i zapis skoroszytów danych wykresu (zawierających dane wykresu edytowane przy użyciu Aspose.Cells). **Uwaga**: dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

Ten przykład otwiera `chart.pptx`, który musi zawierać wykres jako pierwszy kształt na pierwszym slajdzie. Odczytuje osadzony skoroszyt do strumienia, czyści istniejące serie i kategorie oraz zapisuje ten sam skoroszyt z powrotem. Zmiany pozostają w pamięci; przykład nie zapisuje prezentacji.

```cpp
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart.pptx");
auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    auto workbookStream = chartData->ReadWorkbookStream();

    chartData->get_Series()->Clear();
    chartData->get_Categories()->Clear();

    workbookStream->set_Position(0);
    chartData->WriteWorkbookStream(workbookStream);
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

### **Weryfikacja układu wykresu po modyfikacji skoroszytu**

Gdy zamienisz osadzony skoroszyt na zmodyfikowany, wykres zachowuje pierwotne kolekcje serii i kategorii. To niezgodność może spowodować błąd [IChart::ValidateChartLayout](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichart/validatechartlayout/) z komunikatem o indeksie poza zakresem. Wyczyść istniejące serie i kategorie przed zapisem zaktualizowanego skoroszytu z powrotem do wykresu. Przykład wymaga `chart.pptx` z wykresem jako pierwszym kształtem na pierwszym slajdzie. Komentarz zaznacza miejsce, w którym miałoby nastąpić edytowanie skoroszytu; działający przykład zapisuje oryginalny skoroszyt z powrotem i weryfikuje układ w pamięci.

```cpp
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart.pptx");
auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    auto workbookStream = chartData->ReadWorkbookStream();

    // Modyfikuj strumień skoroszytu tutaj, na przykład przy użyciu Aspose.Cells.

    chartData->get_Series()->Clear();
    chartData->get_Categories()->Clear();

    workbookStream->set_Position(0);
    chartData->WriteWorkbookStream(workbookStream);
    chart->ValidateChartLayout();
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Czyszczenie kolekcji usuwa przestarzałe odniesienia przed zapisem skoroszytu. Przed użyciem wykresu zaktualizuj wymagane mapowania serii i kategorii dla zmienionego skoroszytu.

## **Ustawienie komórki skoroszytu jako etykiety danych wykresu**

Można używać tekstu z komórek skoroszytu jako etykiet danych wykresu. Poniższe kroki pokazują, jak połączyć etykiety w wykresie bąbelkowym z komórkami w jego skoroszycie danych.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu przez indeks zerowy.
3. Dodaj wykres bąbelkowy z danymi domyślnymi.
4. Uzyskaj dostęp do serii wykresu.
5. Ustaw komórkę skoroszytu jako etykietę danych.
6. Zapisz prezentację.

Ten przykład otwiera `chart2.pptx`, który musi zawierać przynajmniej jeden slajd, i dodaje wykres bąbelkowy z danymi domyślnymi. Używa komórek A10:A12 w arkuszu 0 dla pierwszych trzech etykiet w pierwszej serii, włącza etykiety z komórek i zapisuje wynik jako `resultchart.pptx`.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart2.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Bubble, 50, 50, 600, 400, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLabelValueFromCell(true);
auto firstLabelCell = workbook->GetCell(0, u"A10", ObjectExt::Box<String>(u"Label 0 cell value"));
auto secondLabelCell = workbook->GetCell(0, u"A11", ObjectExt::Box<String>(u"Label 1 cell value"));
auto thirdLabelCell = workbook->GetCell(0, u"A12", ObjectExt::Box<String>(u"Label 2 cell value"));
series->get_Labels()->idx_get(0)->set_ValueFromCell(firstLabelCell);
series->get_Labels()->idx_get(1)->set_ValueFromCell(secondLabelCell);
series->get_Labels()->idx_get(2)->set_ValueFromCell(thirdLabelCell);

presentation->Save(u"resultchart.pptx", Export::SaveFormat::Pptx);
```

## **Zarządzanie arkuszami**

Metoda [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) zapewnia dostęp do arkuszy w skoroszycie wykresu. Ten przykład tworzy wykres kołowy z danymi domyślnymi i wypisuje nazwę każdego arkusza na konsolę.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataWorksheet.h>
#include <DOM/Chart/IChartDataWorksheetCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 500);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

for (auto i = 0; i < workbook->get_Worksheets()->get_Count(); i++)
{
    Console::WriteLine(workbook->get_Worksheets()->idx_get(i)->get_Name());
}
```

## **Określenie typu źródła danych**

Ten przykład tworzy wykres kolumnowy 3D z danymi domyślnymi i ustawia dwie nazwy serii przy użyciu różnych źródeł danych. Pierwsza nazwa używa literału ciągu znaków; druga używa komórki C1 w arkuszu 0. Właściwość wyliczeniowa [DataSourceType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/datasourcetype/) wybiera źródło dla każdej nazwy. Wynik jest zapisywany jako `pres.pptx`.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 600, 400, true);
auto literalName = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

literalName->set_DataSourceType(DataSourceType::StringLiterals);
literalName->set_Data(ObjectExt::Box<String>(u"LiteralString"));

auto cellName = chart->get_ChartData()->get_Series()->idx_get(1)->get_Name();
auto nameCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, u"C1", ObjectExt::Box<String>(u"NewCell"));
cellName->set_DataSourceType(DataSourceType::Worksheet);
cellName->set_Data(nameCell);

presentation->Save(u"pres.pptx", Export::SaveFormat::Pptx);
```

## **Wykrywanie nieobsługiwanych formatów osadzonych skoroszytów**

Aspose.Slides nie obsługuje binarnego formatu skoroszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Można użyć metody [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) na interfejsie [IChartData](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdata/) razem z wyliczeniem [WorkbookType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/workbooktype/), aby wykrywać nieobsługiwane formaty i pomijać takie wykresy. Ten przykład przegląda kształty na pierwszym slajdzie `sample.pptx`, pomija kształty niebędące wykresami i wypisuje komunikat diagnostyczny dla każdego wykresu z osadzonym skoroszytem .xlsb.

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/WorkbookType.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto shape : IterateOver(slide->get_Shapes()))
{
    auto chart = AsCast<IChart>(shape);
    if (chart == nullptr)
    {
        continue;
    }

    auto chartData = chart->get_ChartData();
    auto isInternalWorkbook = chartData->get_DataSourceType() == ChartDataSourceType::InternalWorkbook;
    auto isBinaryMacro = chartData->get_EmbeddedWorkbookType() == WorkbookType::WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console::WriteLine(u"Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // Odczytaj lub zmodyfikuj obsługiwane dane skoroszytu wykresu tutaj.
}
```

## **Zewnętrzny skoroszyt**

Aspose.Slides obsługuje użycie zewnętrznych skoroszytów jako źródła danych dla wykresów.

### **Utworzenie zewnętrznego skoroszytu**

Użyj [ReadWorkbookStream](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) i [SetExternalWorkbook](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/), aby wyeksportować osadzony skoroszyt wykresu do pliku i powiązać wykres z tym zewnętrznym skoroszytem.

Ten przykład tworzy wykres kołowy z danymi domyślnymi, zapisuje jego skoroszyt jako `externalWorkbook1.xlsx` i zamyka strumień wyjściowy przed przypisaniem pliku jako źródła danych wykresu. Zapisuje połączoną prezentację jako `externalWorkbook.pptx`.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600);
auto workbookPath = IO::Path::GetFullPath(u"externalWorkbook1.xlsx");
auto workbookStream = chart->get_ChartData()->ReadWorkbookStream();
auto fileStream = IO::File::Create(workbookPath);
workbookStream->CopyTo(fileStream);
fileStream->Close();

chart->get_ChartData()->SetExternalWorkbook(workbookPath);
presentation->Save(u"externalWorkbook.pptx", Export::SaveFormat::Pptx);
```

### **Ustawienie zewnętrznego skoroszytu**

Za pomocą metody [SetExternalWorkbook](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) można przypisać zewnętrzny skoroszyt do wykresu jako jego źródło danych. Metoda ta może być także użyta do aktualizacji ścieżki do zewnętrznego skoroszytu (jeśli został przeniesiony).

Chociaż nie można edytować danych w skoroszytach przechowywanych w zdalnych lokalizacjach lub zasobach, można nadal używać takich skoroszytów jako zewnętrznego źródła danych. Jeśli podano względną ścieżkę do zewnętrznego skoroszytu, zostaje ona automatycznie przekształcona w pełną ścieżkę.

Przykład wymaga pliku `externalWorkbook.xlsx` w katalogu roboczym. Jego arkusz o nazwie `Sheet1` musi zawierać nazwę serii w B1, nazwy kategorii w A2:A4 oraz wartości liczbowe w B2:B4. Przykład tworzy wykres kołowy, łączy skoroszyt i używa [SetRange](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdata/setrange/) do mapowania A1:B4 na jedną serię i trzy kategorie. Zapisuje wynik jako `Presentation_with_externalWorkbook.pptx`.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600, true);
auto chartData = chart->get_ChartData();
auto workbookPath = IO::Path::GetFullPath(u"externalWorkbook.xlsx");

chartData->SetExternalWorkbook(workbookPath);
chartData->SetRange(u"Sheet1!$A$1:$B$4");

presentation->Save(u"Presentation_with_externalWorkbook.pptx", Export::SaveFormat::Pptx);
```

Parametr `updateChartData` metody [SetExternalWorkbook](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) kontroluje, czy skoroszyt zostanie załadowany.

* Gdy `updateChartData` ma wartość `false`, aktualizowana jest tylko ścieżka do skoroszytu. Dane wykresu nie są ładowane ani aktualizowane z docelowego skoroszytu, więc skoroszyt może być niedostępny.
* Gdy `updateChartData` ma wartość `true`, dane wykresu są aktualizowane z docelowego skoroszytu.

Poniższy przykład przypisuje przykładowy URL z `updateChartData` ustawionym na `false`. Zachowuje domyślne dane wykresu kołowego i zapisuje prezentację bez ładowania niedostępnego skoroszytu.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600, true);

chart->get_ChartData()->SetExternalWorkbook(u"https://example.com/unavailable-workbook.xlsx", false);
presentation->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", Export::SaveFormat::Pptx);
```

### **Pobranie ścieżki zewnętrznego skoroszytu źródła danych wykresu**

Aby zidentyfikować skoroszyt powiązany z wykresem, najpierw sprawdź, czy wykres używa zewnętrznego źródła danych. Jeśli tak, możesz pobrać ścieżkę do skoroszytu, wykonując następujące kroki.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu przez indeks zerowy.
3. Sprawdź, czy pierwszy kształt jest wykresem.
4. Odczytaj typ źródła danych wykresu.
5. Jeśli źródłem jest zewnętrzny skoroszyt, odczytaj jego ścieżkę.

Ten przykład otwiera `externalWorkbook.pptx`, utworzony w poprzednim przykładzie, i sprawdza pierwszy kształt na pierwszym slajdzie. Jeśli jest to wykres połączony ze zewnętrznym skoroszytem, przykład wypisuje [get_ExternalWorkbookPath](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) na konsolę. Następnie zapisuje kopię prezentacji jako `Result.pptx`.

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"externalWorkbook.pptx");
auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    if (chartData->get_DataSourceType() == ChartDataSourceType::ExternalWorkbook)
    {
        Console::WriteLine(chartData->get_ExternalWorkbookPath());
    }
    else
    {
        Console::WriteLine(u"The chart does not use an external workbook.");
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}

presentation->Save(u"Result.pptx", Export::SaveFormat::Pptx);
```

### **Edycja danych wykresu**

Można edytować dane w zewnętrznych skoroszytach tak samo, jak w wewnętrznych. Gdy zewnętrzny skoroszyt nie może zostać załadowany, zostaje zgłoszony wyjątek.

Ten przykład wymaga `presentation.pptx` z wykresem jako pierwszym kształtem na pierwszym slajdzie oraz dostępnego zewnętrznego skoroszytu. Ustawia wartość komórki pierwszego punktu danych w pierwszej serii na 100 i zapisuje prezentację jako `presentation_out.pptx`. Edycja wartości komórek może aktualizować połączony zewnętrzny plik XLSX, więc użyj kopii, jeśli musisz zachować oryginalny skoroszyt.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto series = chart->get_ChartData()->get_Series();
    if (series->get_Count() > 0 && series->idx_get(0)->get_DataPoints()->get_Count() > 0)
    {
        auto valueCell = series->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell();
        if (valueCell != nullptr)
        {
            valueCell->set_Value(ObjectExt::Box<int32_t>(100));
            presentation->Save(u"presentation_out.pptx", Export::SaveFormat::Pptx);
        }
        else
        {
            Console::WriteLine(u"The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console::WriteLine(u"The chart has no data points to edit.");
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

### **Odtworzenie skoroszytu z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznego skoroszytu, który jest brakujący lub niedostępny, Aspose.Slides może odtworzyć skoroszyt wykresu z danych zapisanych w pamięci podręcznej prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/), skonfiguruj go za pomocą [set_SpreadsheetOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), i wywołaj [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) z wartością `true` przed otwarciem prezentacji.

Poniższy przykład C++ otwiera `presentation.pptx`, którego pierwszy kształt na pierwszym slajdzie musi być wykresem odwołującym się do niedostępnego zewnętrznego skoroszytu, i uzyskuje dostęp do odzyskanych danych przez [IChart::get_ChartData](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichart/get_chartdata/) oraz [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/SpreadsheetOptions.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);
auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

    // Odczytaj lub zmodyfikuj odzyskane dane skoroszytu tutaj.
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Jeśli zewnętrzny skoroszyt jest niedostępny i odzyskiwanie jest wyłączone, Aspose.Slides zgłasza [System::InvalidOperationException](https://reference.aspose.com/slides/pl/cpp/system/details_invalidoperationexception/). Włącz odzyskiwanie tylko wtedy, gdy użycie danych wykresu z pamięci podręcznej jest dopuszczalnym rozwiązaniem awaryjnym, ponieważ pamięć podręczna może nie zawierać zmian dokonanych w zewnętrznym skoroszycie po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany ze zewnętrznym czy osadzonym skoroszytem?**

Tak. Wykres posiada [data source type](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) oraz [path to an external workbook](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); jeśli źródłem jest zewnętrzny skoroszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy obsługiwane są względne ścieżki do zewnętrznych skoroszytów i jak są przechowywane?**

Tak. Jeśli podasz względną ścieżkę, jest ona automatycznie konwertowana na ścieżkę bezwzględną. Prezentacja zapisuje ścieżkę bezwzględną w pliku PPTX, więc przeniesienie skoroszytu może wymagać aktualizacji odnośnika.

**Czy mogę używać skoroszytów znajdujących się na zasobach sieciowych/udziałach?**

Tak, takie skoroszyty mogą być używane jako zewnętrzne źródło danych. Jednak edycja zdalnych skoroszytów bezpośrednio z Aspose.Slides nie jest obsługiwana – mogą być używane wyłącznie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX przy zapisywaniu prezentacji?**

Prezentacja przechowuje [link do pliku zewnętrznego](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Edycja danych wykresu powiązanych z komórkami może również zaktualizować połączony lokalny plik XLSX. Użyj kopii skoroszytu, jeśli oryginał musi pozostać niezmieniony.

**Co zrobić, gdy plik zewnętrzny jest zabezpieczony hasłem?**

Aspose.Slides nie akceptuje hasła przy łączeniu. Typowym rozwiązaniem jest usunięcie ochrony wcześniej lub przygotowanie odszyfrowanej kopii (np. przy użyciu [Aspose.Cells](https://reference.aspose.com/cells/cpp/)) i powiązanie z tą kopią.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego skoroszytu?**

Tak. Każdy wykres przechowuje własny odnośnik. Jeśli wszystkie wskazują ten sam plik, aktualizacja tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym ładowaniu danych.