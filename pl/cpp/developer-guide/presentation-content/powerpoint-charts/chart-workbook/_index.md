---
title: Zarządzanie zeszytami wykresów w prezentacjach przy użyciu C++
linktitle: Zeszyt wykresu
type: docs
weight: 70
url: /pl/cpp/chart-workbook/
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
- C++
- Aspose.Slides
description: "Odkryj Aspose.Slides dla C++: łatwo zarządzaj zeszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane w swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z zeszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu przy użyciu strumieni zeszytów, używać komórek zeszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Artykuł opisuje również pracę z zewnętrznymi zeszytami jako źródłami danych wykresów. Przykłady demonstrują, jak utworzyć i przypisać zewnętrzny zeszyt, odczytać ścieżkę zewnętrznego zeszytu powiązanego z wykresem oraz edytować dane wykresu, gdy zeszyt jest dostępny.

Aby poznać różnicę między pustą komórką a zerem oraz porównać w trybie wykresu liniowego dostępne tryby wyświetlania, zobacz [Kontrolowanie wyświetlania pustych komórek](/slides/pl/cpp/chart-series/).

## **Uwzględnianie danych z ukrytych wierszy i kolumn**

Użyj [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) do kontrolowania, czy wykres rysuje dane z ukrytych wierszy i kolumn arkusza. Ustaw go na `true`, aby rysować tylko widoczne komórki, lub `false`, aby uwzględnić zarówno widoczne, jak i ukryte komórki. To ustawienie kontroluje rysowanie wykresu; nie ukrywa ani nie odkrywa wierszy lub kolumn arkusza.

Przykładowa prezentacja ([sample presentation](hidden-source-data.pptx)) zawiera wykres kolumnowy jako pierwszy kształt na pierwszym slajdzie. Osadzony arkusz, `Sheet1`, zawiera następujący zakres źródłowy, `A1:C4`. Wiersz 3 i kolumna C są ukryte, ale ich komórki nadal zawierają wartości.

| Wiersz arkusza | A: Miesiąc | B: Detal | C: Hurt (ukryta kolumna) |
| --- | --- | --- | --- |
| 2 | Styczeń | 10 | 30 |
| 3 (ukryty wiersz) | Luty | 40 | 60 |
| 4 | Marzec | 20 | 50 |

Uzyskaj dostęp do komórek źródłowych poprzez [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) i odczytaj [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/), aby sprawdzić ich status ukrycia. Ta właściwość jest tylko do odczytu. W tym pliku B2 jest widoczne, B3 należy do ukrytego wiersza, a C2 należy do ukrytej kolumny; przykład wypisuje `False`, `True` i `True` odpowiednio.

W tym przykładzie odśwież dane wykresu po zmianie ustawienia rysowania: zachowaj osadzony zeszyt przy pomocy [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) i wczytaj go ponownie przy pomocy [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/). Przy uwzględnianiu wszystkich komórek użyj również [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/), aby przywrócić pełny zakres, w tym ukrytą kategorię luty. Same zmiany flagi nie wystarczą, aby odświeżyć buforowane dane wykresu i etykiety kategorii w tym przykładzie.

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

        // Odśwież dane wykresu z osadzonego zeszytu.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Przywróć pełny zakres źródłowy, włączając ukryte kategorie.
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

Przykład zapisuje dwie wersje prezentacji: jedną zawierającą tylko widoczne wartości detaliczne (10 i 20) oraz drugą z wszystkimi sześcioma wartościami. Poniższe obrazy ilustrują dwa tryby rysowania. Wiersz 3 i kolumna C pozostają ukryte w obu osadzonych zeszytach.

| Tylko widoczne komórki (`true`) | Wszystkie komórki (`false`) |
| --- | --- |
| ![Tylko widoczne komórki: wartości detaliczne 10 i 20 dla stycznia i marca.](hidden_cells_True.png) | ![Wszystkie komórki: wartości detaliczne i hurtowe dla stycznia, lutego i marca.](hidden_cells_False.png) |

Ukryta komórka zawierająca wartość różni się od pustej komórki. [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) steruje tym, jak wyświetlane są brakujące wartości; nie obejmuje ani nie wyklucza ukrytych danych źródłowych. Zobacz [Kontrolowanie wyświetlania pustych komórek](/slides/pl/cpp/chart-series/#control-the-display-of-empty-cells) dla przykładu.

## **Pobieranie zakresu danych wykresu**

Przed aktualizacją danych zeszytu w istniejącej prezentacji sprawdź zakresy źródłowe, aby zidentyfikować, które komórki arkusza używa każdy wykres. Metoda [IChartData::GetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) zwraca bieżący zakres danych jako formułę kwalifikowaną arkuszem, np. `Sheet1!$A$1:$D$5`. W tym przykładzie `Sheet1` to nazwa arkusza, znak `!` oddziela ją od zakresu komórek, a `$A$1:$D$5` określa komórki od A1 do D5 włącznie. Znaki `$` oznaczają odwołania bezwzględne do wierszy i kolumn.

Metoda odczytuje bieżący zakres bez zmieniania wykresu ani jego zeszytu. Jeśli wykres nie używa zeszytu jako źródła danych, zostaje zgłoszony wyjątek [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/). Więcej informacji znajdziesz w [ChartData API Reference](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/).

Ten przykład otwiera prezentację i sprawdza kształty bezpośrednio na każdym slajdzie pod kątem wykresów. Wypisuje nazwę każdego wykresu oraz jego zakres źródłowy. Jeśli wykres nie używa zeszytu, wypisuje komunikat i przechodzi do kolejnego wykresu.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

for (auto slide : IterateOver(presentation->get_Slides()))
{
    for (auto shape : IterateOver(slide->get_Shapes()))
    {
        auto chart = AsCast<IChart>(shape);
        if (chart != nullptr)
        {
            try
            {
                auto range = chart->get_ChartData()->GetRange();
                Console::WriteLine(u"{0}: {1}", chart->get_Name(), range);
            }
            catch (const InvalidOperationException&)
            {
                Console::WriteLine(u"{0}: The chart does not use a workbook as its data source.", chart->get_Name());
            }
        }
    }
}
```

## **Odczyt i zapis danych wykresu z zeszytu**

Aspose.Slides for C++ udostępnia metody [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) i [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/), które umożliwiają odczyt i zapis zeszytów danych wykresu (zawierających dane edytowane przy pomocy Aspose.Cells). **Note** że dane wykresu muszą być uporządkowane w ten sam sposób lub mieć strukturę podobną do źródła.

Ten przykład używa prezentacji z wykresem jako pierwszym kształtem na pierwszym slajdzie. Odczytuje osadzony zeszyt do strumienia, usuwa istniejące serie i kategorie, a następnie zapisuje ten sam zeszyt z powrotem. Zmiany pozostają w pamięci; przykład nie zapisuje prezentacji.

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

### **Walidacja układu wykresu po modyfikacji zeszytu**

Gdy zamieniasz osadzony zeszyt na zmodyfikowany, wykres zachowuje pierwotne kolekcje serii i kategorii. Ta niezgodność może spowodować niepowodzenie [IChart::ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) z błędem indeksu poza zakresem. Wyczyść istniejące serie i kategorie przed zapisaniem zaktualizowanego zeszytu z powrotem do wykresu. Ten przykład używa wykresu będącego pierwszym kształtem na pierwszym slajdzie. Komentarz wskazuje, gdzie mogłaby odbyć się edycja zeszytu; uruchamialny przykład zapisuje pierwotny zeszyt i waliduje układ w pamięci.

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

    // Modyfikuj strumień zeszytu tutaj, na przykład przy użyciu Aspose.Cells.

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

Czyszczenie kolekcji usuwa przestarzałe odwołania do danych przed zapisaniem zeszytu. Przed użyciem wykresu odbuduj wymagane mapowania serii i kategorii dla zaktualizowanego zeszytu.

## **Ustawienie komórki zeszytu jako etykiety danych wykresu**

Możesz używać tekstu z komórek zeszytu jako etykiet danych wykresu.

Ten przykład dodaje wykres bąbelkowy z domyślnymi danymi do pierwszego slajdu istniejącej prezentacji. Używa komórek A10:A12 w arkuszu 0 dla pierwszych trzech etykiet w pierwszej serii, włącza etykiety z komórek i zapisuje zaktualizowaną prezentację.

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

Metoda [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) zapewnia dostęp do arkuszy w zeszycie wykresu. Ten przykład tworzy wykres kołowy z domyślnymi danymi i wypisuje nazwę każdego arkusza w konsoli.

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

Ten przykład tworzy trójwymiarowy wykres kolumnowy z domyślnymi danymi i ustawia dwie nazwy serii przy użyciu różnych źródeł danych. Pierwsza nazwa jest stałym ciągiem znaków; druga używa komórki C1 w arkuszu 0. Wyliczenie [DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) wybiera źródło dla każdej nazwy. Przykład zapisuje prezentację z zaktualizowanymi nazwami serii.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
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

## **Wykrywanie nieobsługiwanych formatów osadzonych zeszytów**

Aspose.Slides nie obsługuje binarnego formatu zeszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć metody [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) na interfejsie [IChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/) wraz z wyliczeniem [WorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/), aby wykryć nieobsługiwane formaty i pominąć te wykresy. Ten przykład przegląda kształty na pierwszym slajdzie istniejącej prezentacji, pomija kształty niebędące wykresami i wypisuje komunikat diagnostyczny dla każdego wykresu z osadzonym zeszytem .xlsb.

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

    // Odczytaj lub zmodyfikuj obsługiwane dane zeszytu wykresu tutaj.
}
```

## **Zewnętrzny zeszyt**

Aspose.Slides obsługuje użycie zewnętrznych zeszytów jako źródła danych dla wykresów.

### **Utworzenie zewnętrznego zeszytu**

Użyj [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) i [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/), aby wyeksportować osadzony zeszyt wykresu do pliku i powiązać wykres z tym zewnętrznym zeszytem.

Ten przykład tworzy wykres kołowy z domyślnymi danymi i eksportuje jego zeszyt. Zamyka strumień wyjściowy przed przypisaniem zewnętrznego zeszytu jako źródła danych wykresu, a następnie zapisuje połączoną prezentację.

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

### **Ustawienie zewnętrznego zeszytu**

Przy pomocy metody [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) możesz przypisać zewnętrzny zeszyt do wykresu jako jego źródło danych. Metoda ta może również służyć do aktualizacji ścieżki do zewnętrznego zeszytu (jeśli został on przeniesiony).

Nie możesz edytować danych w zeszytach przechowywanych w zdalnych lokalizacjach lub zasobach, ale możesz nadal używać takich zeszytów jako zewnętrznego źródła danych. Jeśli podana zostanie ścieżka względna do zewnętrznego zeszytu, zostanie ona automatycznie przekształcona w pełną ścieżkę.

Ten przykład używa zewnętrznego zeszytu, którego arkusz o nazwie `Sheet1` zawiera nazwę serii w B1, nazwy kategorii w A2:A4 oraz wartości liczbowe w B2:B4. Przykład tworzy wykres kołowy, łączy zeszyt i używa [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/), aby zamapować A1:B4 na jedną serię i trzy kategorie. Zapisuje prezentację z połączonym wykresem.

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

Parametr `updateChartData` metody [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) określa, czy zeszyt ma być załadowany.

* Gdy `updateChartData` ma wartość `false`, aktualizowana jest tylko ścieżka do zeszytu. Dane wykresu nie są ładowane ani aktualizowane z docelowego zeszytu, więc zeszyt może być niedostępny.
* Gdy `updateChartData` ma wartość `true`, dane wykresu są aktualizowane z docelowego zeszytu.

Poniższy przykład przypisuje przykładowy adres URL z ustawionym `updateChartData` na `false`. Zachowuje domyślne dane wykresu kołowego i zapisuje prezentację bez ładowania niedostępnego zeszytu.

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

### **Pobranie ścieżki zewnętrznego zeszytu źródłowego wykresu**

Aby zidentyfikować zeszyt powiązany z wykresem, sprawdź, czy wykres używa zewnętrznego źródła danych i odczytaj jego ścieżkę.

Ten przykład przegląda pierwszy kształt na pierwszym slajdzie prezentacji z podłączonym zewnętrznym zeszytem. Jeśli jest to wykres połączony z zewnętrznym zeszytem, przykład wypisuje [get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) w konsoli. Następnie zapisuje kopię prezentacji.

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

Możesz edytować dane w zewnętrznych zeszytach tak samo, jak w wewnętrznych. Gdy zewnętrzny zeszyt nie może zostać załadowany, zostaje zgłoszony wyjątek.

Ten przykład używa wykresu będącego pierwszym kształtem na pierwszym slajdzie i połączonego z dostępnym zewnętrznym zeszytem. Ustawia wartość opartą na komórce pierwszego punktu danych w pierwszej serii na 100 i zapisuje zaktualizowaną prezentację. Edycja wartości komórek może aktualizować podłączony zewnętrzny plik XLSX, dlatego warto używać kopii, jeśli trzeba zachować oryginalny zeszyt.

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

### **Odzyskiwanie zeszytu z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznego zeszytu, który jest brakujący lub niedostępny, Aspose.Slides może odtworzyć zeszyt wykresu z danych buforowanych w prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/), skonfiguruj go za pomocą [set_SpreadsheetOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), i wywołaj [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) z wartością `true` przed otwarciem prezentacji.

Poniższy przykład w C++ odzyskuje dane zeszytu dla wykresu będącego pierwszym kształtem na pierwszym slajdzie i odwołującego się do niedostępnego zewnętrznego zeszytu. Dostęp do odzyskanych danych uzyskuje się przez [IChart::get_ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) oraz [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

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

    // Odczytaj lub zmodyfikuj odzyskane dane zeszytu tutaj.
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Jeśli zewnętrzny zeszyt jest niedostępny i odzyskiwanie jest wyłączone, Aspose.Slides zgłasza [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/). Włącz odzyskiwanie tylko wtedy, gdy użycie buforowanych danych wykresu jest dopuszczalnym rozwiązaniem awaryjnym, ponieważ pamięć podręczna może nie zawierać zmian wprowadzonych w zewnętrznym zeszycie po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest połączony z zewnętrznym czy osadzonym zeszytem?**

Tak. Wykres posiada [data source type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) oraz [path to an external workbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); jeśli źródłem jest zewnętrzny zeszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy obsługiwane są ścieżki względne do zewnętrznych zeszytów i jak są one przechowywane?**

Tak. Jeśli podasz ścieżkę względną, zostaje ona automatycznie przekształcona na ścieżkę bezwzględną. Prezentacja przechowuje ścieżkę bezwzględną w pliku PPTX, więc przeniesienie zeszytu może wymagać aktualizacji linku.

**Czy mogę używać zeszytów znajdujących się w zasobach sieciowych/udostępnionych?**

Tak, takie zeszyty mogą być używane jako zewnętrzne źródło danych. Jednak edycja zdalnych zeszytów bezpośrednio z Aspose.Slides nie jest obsługiwana — mogą być używane jedynie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX przy zapisie prezentacji?**

Prezentacja przechowuje [link to the external file](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Edycja danych wykresu opartych na komórkach może także zaktualizować podłączony lokalny plik XLSX. Użyj kopii zeszytu, jeśli oryginał musi pozostać niezmieniony.

**Co zrobić, gdy zewnętrzny plik jest zabezpieczony hasłem?**

Aspose.Slides nie przyjmuje hasła przy łączeniu. Typowym podejściem jest wcześniejsze usunięcie ochrony lub przygotowanie odszyfrowanej kopii (np. przy użyciu [Aspose.Cells](https://reference.aspose.com/cells/cpp/)) i podłączenie się do tej kopii.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego zeszytu?**

Tak. Każdy wykres przechowuje własny link. Jeśli wszystkie odwołują się do tego samego pliku, aktualizacja tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym wczytaniu danych.