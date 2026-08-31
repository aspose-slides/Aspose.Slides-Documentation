---
title: Zarządzanie arkuszami wykresów w prezentacjach przy użyciu C++
linktitle: Arkusz wykresu
type: docs
weight: 70
url: /pl/cpp/chart-workbook/
keywords:
- arkusz wykresu
- dane wykresu
- komórka arkusza
- etykieta danych
- arkusz
- źródło danych
- zewnętrzny arkusz
- zewnętrzne dane
- pamięć podręczna wykresu
- odzyskiwanie arkusza
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Odkryj Aspose.Slides dla C++: łatwo zarządzaj arkuszami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane w swojej prezentacji."
---
## **Omówienie**

Ten artykuł wyjaśnia, jak pracować z arkuszami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu za pomocą strumieni arkuszy, używać komórek arkusza jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Omówiono także pracę z zewnętrznymi arkuszami jako źródłami danych wykresu. Przykłady demonstrują, jak utworzyć i przypisać zewnętrzny arkusz, pobrać ścieżkę zewnętrznego arkusza powiązanego z wykresem oraz edytować dane wykresu, gdy arkusz jest dostępny.

## **Odczyt i zapis danych wykresu z arkusza**

Aspose.Slides udostępnia metody [ReadWorkbookStream](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) i [WriteWorkbookStream](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/), które pozwalają na odczyt i zapis arkuszy danych wykresu (zawierających dane wykresu edytowane przy użyciu Aspose.Cells). **Uwaga** – dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

``` cpp
#include <DOM/Chart/Chart.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slide(0)->get_Shape(0));
auto data = chart->get_ChartData();

auto = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

### **Weryfikacja układu wykresu po modyfikacji arkusza**

Gdy zamienisz osadzony arkusz na zmodyfikowany, wykres zachowuje pierwotne kolekcje serii i kategorii. To niezgodność może spowodować błąd w [IChart::ValidateChartLayout](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichart/validatechartlayout/) z powodu indeksu poza zakresem. Wyczyść istniejące serie i kategorie przed zapisaniem zaktualizowanego arkusza z powrotem do wykresu.

```cpp
// Po modyfikacji strumienia arkusza (np. przy użyciu Aspose.Cells)
auto updatedWorkbook = chartData->ReadWorkbookStream();

// Wyczyść istniejące odwołania do danych.
chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

updatedWorkbook->set_Position(0);
chartData->WriteWorkbookStream(updatedWorkbook);

chart->ValidateChartLayout();
```

Wyczyszczenie kolekcji zapewnia, że struktura danych wykresu jest spójna z nowym arkuszem, co pozwala metodzie `ValidateChartLayout` zakończyć działanie bez błędów.

## **Ustawienie komórki arkusza jako etykiety danych wykresu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz referencję slajdu za pośrednictwem jego indeksu.
1. Dodaj wykres bąbelkowy z przykładowymi danymi.
1. Uzyskaj dostęp do serii wykresu.
1. Ustaw komórkę arkusza jako etykietę danych.
1. Zapisz prezentację.

Ten kod C++ pokazuje, jak ustawić komórkę arkusza jako etykietę danych wykresu:

``` cpp
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
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// Tworzy instancję klasy Presentation, która reprezentuje plik prezentacji 
auto pres = System::MakeObject<Presentation>(u"chart2.pptx");

auto slide = pres->get_Slides()->idx_get(0);

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Bubble, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto series = chart->get_ChartData()->get_Series();

series->idx_get(0)->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLabelValueFromCell(true);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

series->idx_get(0)->get_Labels()->idx_get(0)->set_ValueFromCell(wb->GetCell(0, u"A10", System::ObjectExt::Box<System::String>(lbl0)));
series->idx_get(0)->get_Labels()->idx_get(1)->set_ValueFromCell(wb->GetCell(0, u"A11", System::ObjectExt::Box<System::String>(lbl1)));
series->idx_get(0)->get_Labels()->idx_get(2)->set_ValueFromCell(wb->GetCell(0, u"A12", System::ObjectExt::Box<System::String>(lbl2)));

pres->Save(u"resultchart.pptx", SaveFormat::Pptx);
```

## **Zarządzanie arkuszami**

Ten kod C++ demonstruje operację, w której metoda [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) jest używana do uzyskania dostępu do kolekcji arkuszy:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataWorksheet.h>
#include <DOM/Chart/IChartDataWorksheetCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **Określanie typu źródła danych**

Ten kod C++ pokazuje, jak określić typ źródła danych:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto chartData = chart->get_ChartData();
auto val = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

val->set_DataSourceType(DataSourceType::StringLiterals);
val->set_Data(System::ObjectExt::Box<System::String>(u"LiteralString"));
val = chartData->get_Series()->idx_get(1)->get_Name();
val->set_Data(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1", System::ObjectExt::Box<System::String>(u"NewCell")));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Wykrywanie nieobsługiwanych formatów osadzonych arkuszy**

Aspose.Slides nie obsługuje formatu binarnego arkusza Excela (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć metody `get_EmbeddedWorkbookType` na interfejsie [IChartData](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdata/) wraz z wyliczeniem [WorkbookType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/workbooktype/), aby wykryć nieobsługiwane formaty i pominąć takie wykresy.

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/WorkbookType.h>
#include <DOM/IChart.h>
#include <DOM/ISlide.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : System::IterateOver(slide->get_Shapes()))
{
    if (!System::ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = System::ExplicitCast<IChart>(shape);
    auto chartData = chart->get_ChartData();

    if (chartData->get_DataSourceType() == ChartDataSourceType::InternalWorkbook &&
        chartData->get_EmbeddedWorkbookType() == WorkbookType::WorkbookBinaryMacro)
    {
        // Osadzony arkusz jest w formacie .xlsb, który nie jest obsługiwany.
        continue;
    }

    // Odczytaj lub zmodyfikuj tutaj dane arkusza wykresu.
}
```

## **Zewnętrzny arkusz**

{{% alert color="info" %}} 
W [Aspose.Slides](https://releases.aspose.com/slides/pl/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4 wprowadzono obsługę zewnętrznych arkuszy jako źródła danych dla wykresów.
{{% /alert %}} 

### **Utworzenie zewnętrznego arkusza**

Korzystając z metod **`ReadWorkbookStream`** i **`SetExternalWorkbook`**, możesz zarówno utworzyć zewnętrzny arkusz od podstaw, jak i zamienić wewnętrzny arkusz w zewnętrzny.

Ten kod C++ demonstruje proces tworzenia zewnętrznego arkusza:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

const System::String workbookPath = u"externalWorkbook1.xlsx";

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f);
auto chartData = chart->get_ChartData();

{
    System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(workbookPath, System::IO::FileMode::Create);

    System::ArrayPtr<uint8_t> workbookData = chartData->ReadWorkbookStream()->ToArray();
    fileStream->Write(workbookData, 0, workbookData->get_Length());
}

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(workbookPath));

pres->Save(u"externalWorkbook.pptx", SaveFormat::Pptx);
```

### **Ustawienie zewnętrznego arkusza**

Za pomocą metody **`IChartData::SetExternalWorkbook`** możesz przypisać zewnętrzny arkusz do wykresu jako jego źródło danych. Metoda ta może również służyć do aktualizacji ścieżki do zewnętrznego arkusza (jeśli arkusz został przeniesiony).

Choć nie możesz edytować danych w arkuszach przechowywanych w zdalnych lokalizacjach lub zasobach, możesz nadal używać takich arkuszy jako zewnętrznego źródła danych. Jeśli podana zostanie względna ścieżka do zewnętrznego arkusza, zostanie ona automatycznie przekształcona w pełną ścieżkę.

Ten kod C++ pokazuje, jak ustawić zewnętrzny arkusz:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, false);
auto chartData = chart->get_ChartData();

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(u"externalWorkbook.xlsx"));

chartData->get_Series()->Add(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1"), ChartType::Pie);
auto dataPoints = chartData->get_Series()->idx_get(0)->get_DataPoints();
auto workbook = chartData->get_ChartDataWorkbook();
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B2"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B3"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B4"));

auto categories = chartData->get_Categories();
categories->Add(workbook->GetCell(0, u"A2"));
categories->Add(workbook->GetCell(0, u"A3"));
categories->Add(workbook->GetCell(0, u"A4"));
pres->Save(u"Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
```

Parametr `updateChartData` (w metodzie `SetExternalWorkbook`) określa, czy arkusz Excel zostanie załadowany.

* Gdy wartość `updateChartData` jest ustawiona na `false`, aktualizowana jest tylko ścieżka do arkusza – dane wykresu nie zostaną załadowane ani zaktualizowane z docelowego arkusza. Użyj tej opcji, gdy docelowy arkusz nie istnieje lub jest niedostępny.  
* Gdy wartość `updateChartData` jest ustawiona na `true`, dane wykresu zostaną zaktualizowane z docelowego arkusza.

```c++
#include <DOM/Chart/ChartData.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **Pobranie ścieżki zewnętrznego źródła danych arkusza wykresu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz referencję slajdu za pośrednictwem jego indeksu.
1. Utwórz obiekt reprezentujący kształt wykresu.
1. Utwórz obiekt typu źródła (`ChartDataSourceType`), który reprezentuje źródło danych wykresu.
1. Określ odpowiedni warunek w zależności od tego, czy typ źródła jest taki sam jak typ zewnętrznego źródła danych arkusza.

Ten kod C++ demonstruje tę operację:

```c++
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// Saves the presentation
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **Edycja danych wykresu**

Możesz edytować dane w zewnętrznych arkuszach tak samo, jak w wewnętrznych. Gdy zewnętrzny arkusz nie może zostać załadowany, zostaje wyrzucony wyjątek.

Ten kod C++ implementuje opisany proces:

```c++
#include <DOM/Chart/Chart.h>
#include <DOM/Chart/ChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Odzyskanie arkusza z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznego arkusza, który jest nieobecny lub niedostępny, Aspose.Slides może odtworzyć arkusz wykresu z danych przechowywanych w pamięci podręcznej prezentacji. Utwórz obiekt [LoadOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/), skonfiguruj go metodą [set_SpreadsheetOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), a następnie wywołaj [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) z wartością `true` przed otwarciem prezentacji.

Poniższy przykład C++ otwiera prezentację, w której wykres odwołuje się do niedostępnego zewnętrznego arkusza, i uzyskuje dostęp do odtworzonych danych poprzez [IChart::get_ChartData](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichart/get_chartdata/) oraz [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

```cpp
auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto chart = System::ExplicitCast<IChart>(shape);

auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Odczytaj lub zmodyfikuj tutaj odzyskane dane arkusza.

presentation->Dispose();
```

Jeśli zewnętrzny arkusz jest niedostępny, a odzyskiwanie jest wyłączone, Aspose.Slides zgłasza `System::InvalidOperationException`. Włącz odzyskiwanie tylko wtedy, gdy korzystanie z danych z pamięci podręcznej wykresu jest akceptowalną alternatywą, ponieważ pamięć podręczna może nie zawierać zmian wprowadzonych w zewnętrznym arkuszu po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrznym, czy osadzonym arkuszem?**

Tak. Wykres posiada [typ źródła danych](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) oraz [ścieżkę do zewnętrznego arkusza](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); jeśli źródłem jest zewnętrzny arkusz, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy względne ścieżki do zewnętrznych arkuszy są obsługiwane i jak są przechowywane?**

Tak. Jeśli podasz względną ścieżkę, zostanie ona automatycznie przekształcona w ścieżkę absolutną. Ułatwia to przenoszenie projektu; pamiętaj jednak, że prezentacja zapisze ścieżkę absolutną w pliku PPTX.

**Czy mogę używać arkuszy znajdujących się na zasobach sieciowych/udziałach?**

Tak, takie arkusze mogą być używane jako zewnętrzne źródło danych. Jednak edycja zdalnych arkuszy bezpośrednio z Aspose.Slides nie jest obsługiwana – mogą być używane wyłącznie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX podczas zapisywania prezentacji?**

Nie. Prezentacja przechowuje [link do zewnętrznego pliku](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) i używa go do odczytu danych. Sam plik zewnętrzny nie jest modyfikowany przy zapisie prezentacji.

**Co zrobić, jeśli zewnętrzny plik jest chroniony hasłem?**

Aspose.Slides nie przyjmuje hasła przy łączeniu. Typowym rozwiązaniem jest usunięcie ochrony wcześniej lub przygotowanie odszyfrowanej kopii (np. przy użyciu [Aspose.Cells](/cells/cpp/)) i podlinkowanie do tej kopii.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego arkusza?**

Tak. Każdy wykres przechowuje własny link. Jeśli wszystkie wskazują ten sam plik, aktualizacja tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym wczytaniu danych.