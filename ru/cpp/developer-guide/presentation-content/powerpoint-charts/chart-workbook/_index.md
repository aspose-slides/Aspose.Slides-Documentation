---
title: Рабочая тетрадь диаграмм
type: docs
weight: 70
url: /cpp/chart-workbook/
keywords: "Рабочая тетрадь диаграмм, данные диаграмм, презентация PowerPoint, C++, CPP, Aspose.Slides для C++"
description: "Рабочая тетрадь диаграмм в презентации PowerPoint на C++"
---

## **Установить данные диаграммы из рабочей тетради**

Aspose.Slides предоставляет методы [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data#a1bc3d9eaafc86814336b6c23bffd8e2e) и [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data#a3f42c5e16bf1fd1d4e69579bffc6ce8e), которые позволяют читать и записывать рабочие тетради данных диаграмм (содержащие данные диаграмм, отредактированные с помощью Aspose.Cells). **Обратите внимание**, что данные диаграммы должны быть организованы аналогичным образом или иметь структуру, схожую с источником.

```cpp
auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto data = chart->get_ChartData();

System::SharedPtr<System::IO::MemoryStream> stream = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

Этот код на C++ демонстрирует операцию по установке рабочей тетради данных диаграммы:

```cpp
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

## **Установить ячейку рабочей тетради в качестве метки данных диаграммы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму пузырьков с некоторыми данными.
1. Получите доступ к сериям диаграммы.
1. Установите ячейку рабочей тетради в качестве метки данных.
1. Сохраните презентацию.

Этот код на C++ показывает, как установить ячейку рабочей тетради в качестве метки данных диаграмы:

```cpp
System::String lbl0 = u"Значение ячейки метки 0";
System::String lbl1 = u"Значение ячейки метки 1";
System::String lbl2 = u"Значение ячейки метки 2";

// Создание экземпляра класса Presentation, который представляет файл презентации
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

## **Управление листами**

Этот код на C++ демонстрирует операцию, при которой свойство [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_workbook#a8a5bfd5f6d389c497fe0d9ff4037d928) используется для доступа к коллекции листов:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **Указать тип источника данных**

Этот код на C++ показывает, как указать тип для источника данных:

```cpp
auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto chartData = chart->get_ChartData();
auto val = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

val->set_DataSourceType(DataSourceType::StringLiterals);
val->set_Data(System::ObjectExt::Box<System::String>(u"ЛитералСтрока"));
val = chartData->get_Series()->idx_get(1)->get_Name();
val->set_Data(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1", System::ObjectExt::Box<System::String>(u"НоваяЯчейка")));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Внешняя рабочая тетрадь**

{{% alert color="primary" %}} 
В [Aspose.Slides](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-19-4-release-notes/) 19.4 мы реализовали поддержку внешних рабочих тетрадей в качестве источника данных для диаграмм.
{{% /alert %}} 

### **Создание внешней рабочей тетради**

С помощью методов **`ReadWorkbookStream`** и **`SetExternalWorkbook`** вы можете либо создать внешнюю рабочую тетрадь с нуля, либо сделать внутреннюю рабочую тетрадь внешней.

Этот код на C++ демонстрирует процесс создания внешней рабочей тетради:

```cpp
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

### **Установить внешнюю рабочую тетрадь**

Используя метод **`IChartData.SetExternalWorkbook`**, вы можете назначить внешнюю рабочую тетрадь диаграмме в качестве источника данных. Этот метод также может использоваться для обновления пути к внешней рабочей тетради (если последняя была перемещена).

Хотя вы не можете редактировать данные в рабочих тетрадях, хранящихся в удаленных местах или ресурсах, вы все равно можете использовать такие рабочие тетради в качестве внешнего источника данных. Если предоставлен относительный путь для внешней рабочей тетради, он автоматически преобразуется в полный путь.

Этот код на C++ показывает, как установить внешнюю рабочую тетрадь:

```cpp
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

Параметр `updateChartData` (в методе `SetExternalWorkbook`) используется для указания того, будет ли загружена рабочая тетрадь Excel или нет. 

* Когда значение `updateChartData` установлено в `false`, обновляется только путь к рабочей тетради — данные диаграммы не будут загружены или обновлены из целевой рабочей тетради. Вы можете использовать эту настройку, когда целевая рабочая тетрадь не существует или недоступна. 
* Когда значение `updateChartData` установлено в `true`, данные диаграммы обновляются из целевой рабочей тетради.

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **Получить путь к внешнему источнику данных диаграммы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Создайте объект для фигуры диаграммы.
1. Создайте объект для типа источника (`ChartDataSourceType`), который представляет источник данных диаграммы.
1. Укажите соответствующее условие на основании того, что тип источника совпадает с типом источника данных внешней рабочей тетради.

Этот код на C++ демонстрирует операцию:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// Сохраняет презентацию
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **Редактировать данные диаграммы**

Вы можете редактировать данные во внешних рабочих тетрадях так же, как вносить изменения в содержимое внутренних рабочих тетрадей. Когда внешняя рабочая тетрадь не может быть загружена, возникает исключение.

Этот код на C++ является реализацией описанного процесса:

```cpp
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```