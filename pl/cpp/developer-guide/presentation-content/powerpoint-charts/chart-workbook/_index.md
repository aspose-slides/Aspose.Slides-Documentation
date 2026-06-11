---
title: Zarządzaj skoroszytami wykresów w prezentacjach przy użyciu C++
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
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Odkryj Aspose.Slides dla C++: łatwo zarządzaj skoroszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane w swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z skoroszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu za pośrednictwem strumieni skoroszytów, używać komórek skoroszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu. Opisuje także pracę z zewnętrznymi skoroszytami jako źródłami danych wykresu. Przykłady demonstrują, jak utworzyć i przypisać zewnętrzny skoroszyt, pobrać ścieżkę zewnętrznego skoroszytu powiązanego z wykresem oraz edytować dane wykresu, gdy skoroszyt jest dostępny.

## **Odczyt i zapis danych wykresu z skoroszytu**

Aspose.Slides udostępnia metody [ReadWorkbookStream](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) i [WriteWorkbookStream](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/), które umożliwiają odczyt i zapis skoroszytów danych wykresu (zawierających dane wykresu edytowane przy pomocy Aspose.Cells). **Uwaga** że dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

``` cpp
auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto data = chart->get_ChartData();

System::SharedPtr<System::IO::MemoryStream> stream = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

Ten kod C++ demonstruje operację ustawienia skoroszytu danych wykresu:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Charts::ChartType::Pie, 50.0f, 50.0f, 500.0f, 400.0f);
chart->get_ChartData()->get_ChartDataWorkbook()->Clear(0);

intrusive_ptr<Aspose::Cells::IWorkbook> workbook;
try
{
    workbook = Aspose::Cells::Factory::CreateIWorkbook(new String("a1.xlsx"));
}
catch (Aspose::Cells::Systems::Exception& ex)
{
    System::Console::Write(System::String::FromWCS(ex.GetMessageExp()->value()));
}

intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
workbook->Save(cellsOutputStream, Aspose::Cells::SaveFormat_Xlsx);

cellsOutputStream->SetPosition(0);
System::SharedPtr<System::IO::MemoryStream> msout = ToSlidesMemoryStream(cellsOutputStream);

chart->get_ChartData()->WriteWorkbookStream(msout);

chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$B$9");
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);
pres->Save(u"response2.pptx", Export::SaveFormat::Pptx);
```

## **Ustaw komórkę WorkBook jako etykietę danych wykresu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .
2. Uzyskaj odwołanie do slajdu poprzez jego indeks.
3. Dodaj wykres bąbelkowy z pewnymi danymi.
4. Uzyskaj dostęp do serii wykresu.
5. Ustaw komórkę skoroszytu jako etykietę danych.
6. Zapisz prezentację.

Ten kod C++ pokazuje, jak ustawić komórkę skoroszytu jako etykietę danych wykresu:

``` cpp
System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// Instancjonuje klasę Presentation, która reprezentuje plik prezentacji 
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
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **Określ typ źródła danych**

Ten kod C++ pokazuje, jak określić typ dla źródła danych:

```c++
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

## **Wykryj nieobsługiwane formaty osadzonych skoroszytów**

Aspose.Slides nie obsługuje formatu binarnego skoroszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć metody `get_EmbeddedWorkbookType` w [IChartData](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdata/) razem z wyliczeniem [WorkbookType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/workbooktype/), aby wykryć nieobsługiwane formaty i pominąć te wykresy.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
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
        // Osadzony skoroszyt jest w formacie .xlsb, który nie jest obsługiwany.
        continue;
    }

    // Odczytaj lub modyfikuj tutaj dane skoroszytu wykresu.
}
```

## **Zewnętrzny skoroszyt**

{{% alert color="primary" %}} 
W wersji 19.4 [Aspose.Slides](https://releases.aspose.com/slides/pl/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) wprowadziliśmy obsługę zewnętrznych skoroszytów jako źródła danych dla wykresów.
{{% /alert %}} 

### **Utwórz zewnętrzny skoroszyt**

Używając metod **`ReadWorkbookStream`** i **`SetExternalWorkbook`**, możesz albo utworzyć od podstaw zewnętrzny skoroszyt, albo zamienić wewnętrzny skoroszyt w zewnętrzny.

Ten kod C++ demonstruje proces tworzenia zewnętrznego skoroszytu:

```c++
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

### **Ustaw zewnętrzny skoroszyt**

Korzystając z metody **`IChartData::SetExternalWorkbook`**, możesz przypisać zewnętrzny skoroszyt do wykresu jako jego źródło danych. Metoda ta może także służyć do aktualizacji ścieżki do zewnętrznego skoroszytu (jeśli ten został przeniesiony).

Chociaż nie możesz edytować danych w skoroszytach przechowywanych w zdalnych lokalizacjach lub zasobach, możesz nadal używać takich skoroszytów jako zewnętrznego źródła danych. Jeśli podana zostanie względna ścieżka do zewnętrznego skoroszytu, zostaje ona automatycznie przekształcona w pełną ścieżkę.

Ten kod C++ pokazuje, jak ustawić zewnętrzny skoroszyt:

```c++
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

Parametr `updateChartData` (w metodzie `SetExternalWorkbook`) służy do określenia, czy skoroszyt Excel zostanie załadowany, czy nie.

* Gdy wartość `updateChartData` jest ustawiona na `false`, aktualizowana jest tylko ścieżka do skoroszytu — dane wykresu nie zostaną załadowane ani zaktualizowane z docelowego skoroszytu. Możesz użyć tego ustawienia w sytuacji, gdy docelowy skoroszyt nie istnieje lub jest niedostępny. 
* Gdy wartość `updateChartData` jest ustawiona na `true`, dane wykresu zostają zaktualizowane z docelowego skoroszytu.

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **Pobierz ścieżkę zewnętrznego skoroszytu źródła danych wykresu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu poprzez jego indeks.
3. Utwórz obiekt dla kształtu wykresu.
4. Utwórz obiekt dla typu źródła (`ChartDataSourceType`), które reprezentuje źródło danych wykresu.
5. Określ odpowiedni warunek na podstawie tego, czy typ źródła jest taki sam jak typ zewnętrznego skoroszytu.

Ten kod C++ demonstruje tę operację:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// Zapisuje prezentację
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **Edytuj dane wykresu**

Możesz edytować dane w zewnętrznych skoroszytach w taki sam sposób, w jaki wprowadzasz zmiany w zawartości wewnętrznych skoroszytów. Gdy zewnętrzny skoroszyt nie może zostać załadowany, zostaje rzucony wyjątek.

Ten kod C++ jest implementacją opisanego procesu:

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrznym czy osadzonym skoroszytem?**

Tak. Wykres posiada [typ źródła danych](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) oraz [ścieżkę do zewnętrznego skoroszytu](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); jeśli źródłem jest zewnętrzny skoroszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy względne ścieżki do zewnętrznych skoroszytów są obsługiwane i jak są przechowywane?**

Tak. Jeśli podasz względną ścieżkę, zostaje ona automatycznie przekształcona w ścieżkę bezwzględną. Jest to wygodne przy przenoszeniu projektu; jednak należy pamiętać, że prezentacja zapisze ścieżkę bezwzględną w pliku PPTX.

**Czy mogę używać skoroszytów znajdujących się na zasobach/udziałach sieciowych?**

Tak, takie skoroszyty mogą być używane jako zewnętrzne źródło danych. Jednak edycja zdalnych skoroszytów bezpośrednio z Aspose.Slides nie jest obsługiwana — mogą być używane wyłącznie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX przy zapisywaniu prezentacji?**

Nie. Prezentacja przechowuje [odnośnik do zewnętrznego pliku](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) i używa go do odczytu danych. Sam zewnętrzny plik nie jest modyfikowany podczas zapisywania prezentacji.

**Co zrobić, jeśli zewnętrzny plik jest chroniony hasłem?**

Aspose.Slides nie akceptuje hasła przy tworzeniu łącza. Typowe podejście polega na usunięciu ochrony z wyprzedzeniem lub przygotowaniu odszyfrowanej kopii (na przykład przy użyciu [Aspose.Cells](/cells/cpp/)) i połączeniu się z tą kopią.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego skoroszytu?**

Tak. Każdy wykres przechowuje własny odnośnik. Jeśli wszystkie wskazują na ten sam plik, aktualizacja tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym ładowaniu danych.