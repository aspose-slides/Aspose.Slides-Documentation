---
title: Управление рабочими книгами диаграмм в презентациях с использованием C++
linktitle: Рабочая книга диаграммы
type: docs
weight: 70
url: /ru/cpp/chart-workbook/
keywords:
- рабочая книга диаграммы
- данные диаграммы
- ячейка рабочей книги
- метка данных
- лист
- источник данных
- внешняя рабочая книга
- внешние данные
- кеш диаграмм
- восстановление рабочей книги
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Откройте для себя Aspose.Slides для C++: легко управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, чтобы оптимизировать данные вашей презентации."
---
## **Обзор**

Эта статья объясняет, как работать с рабочими книгами диаграмм в Aspose.Slides. Она показывает, как читать и записывать данные диаграмм через потоки рабочих книг, использовать ячейки рабочей книги в качестве меток данных, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграммы.

Также рассматривается работа с внешними рабочими книгами в качестве источников данных диаграммы. Примеры демонстрируют, как создать и назначить внешнюю рабочую книгу, получить путь к внешней рабочей книге, привязанной к диаграмме, и редактировать данные диаграммы, когда рабочая книга доступна.

## **Чтение и запись данных диаграммы из рабочей книги**

Aspose.Slides предоставляет методы [ReadWorkbookStream](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) и [WriteWorkbookStream](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/), позволяющие считывать и записывать рабочие книги данных диаграмм (содержащие данные диаграмм, отредактированные с помощью Aspose.Cells). **Note** что данные диаграммы должны быть организованы одинаковым образом или иметь структуру, схожую с исходной.

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

Этот код C++ демонстрирует операцию установки рабочей книги данных диаграммы:

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

## **Установка ячейки рабочей книги в качестве метки данных диаграммы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте пузырчатую диаграмму с некоторыми данными.
4. Получите доступ к сериям диаграммы.
5. Установите ячейку рабочей книги в качестве метки данных.
6. Сохраните презентацию.

Этот код C++ показывает, как установить ячейку рабочей книги в качестве метки данных диаграммы:

``` cpp
System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// Создает объект класса Presentation, представляющий файл презентации 
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

Этот код C++ демонстрирует использование метода [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) для доступа к коллекции листов:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **Указание типа источника данных**

Этот код C++ показывает, как указать тип для источника данных:

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

## **Обнаружение неподдерживаемых встроенных форматов рабочей книги**

Aspose.Slides не поддерживает бинарный формат рабочей книги Excel (.xlsb), который может быть встроен в некоторые диаграммы. Вы можете использовать метод `get_EmbeddedWorkbookType` на [IChartData](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdata/) вместе с перечислением [WorkbookType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/workbooktype/) для обнаружения неподдерживаемых форматов и пропуска таких диаграмм.

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
        // Встроенная рабочая книга в формате .xlsb, который не поддерживается.
        continue;
    }

    // Здесь можно читать или изменять данные рабочей книги диаграммы.
}
```

## **Внешняя рабочая книга**

{{% alert color="primary" %}} 
В [Aspose.Slides](https://releases.aspose.com/slides/ru/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4 мы внедрили поддержку внешних рабочих книг в качестве источника данных для диаграмм.
{{% /alert %}} 

### **Создание внешней рабочей книги**

С помощью методов **`ReadWorkbookStream`** и **`SetExternalWorkbook`** вы можете либо создать внешнюю рабочую книгу с нуля, либо сделать внутреннюю рабочую книгу внешней.

Этот код C++ демонстрирует процесс создания внешней рабочей книги:

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

### **Установка внешней рабочей книги**

С помощью метода **`IChartData::SetExternalWorkbook`** вы можете назначить внешнюю рабочую книгу диаграмме в качестве её источника данных. Этот метод также может использоваться для обновления пути к внешней рабочей книге (если она была перемещена).

Хотя вы не можете редактировать данные в рабочих книгах, хранящихся в удалённых местах или ресурсах, такие книги всё равно могут использоваться как внешний источник данных. Если указан относительный путь к внешней рабочей книге, он автоматически преобразуется в полный путь.

Этот код C++ показывает, как установить внешнюю рабочую книгу:

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

Параметр `updateChartData` (в методе `SetExternalWorkbook`) используется для указания, будет ли загружена Excel‑рабочая книга.

* Когда значение `updateChartData` установлено в `false`, обновляется только путь к рабочей книге — данные диаграммы не загружаются и не обновляются из целевой рабочей книги. Это можно использовать, когда целевая рабочая книга отсутствует или недоступна. 
* Когда значение `updateChartData` установлено в `true`, данные диаграммы обновляются из целевой рабочей книги.

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **Получение пути к внешней рабочей книге источника данных диаграммы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Создайте объект для формы диаграммы.
4. Создайте объект для типа источника (`ChartDataSourceType`), представляющего источник данных диаграммы.
5. Укажите соответствующее условие, основываясь на том, что тип источника совпадает с типом внешней рабочей книги.

Этот код C++ демонстрирует операцию:

```c++
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

### **Редактирование данных диаграммы**

Вы можете редактировать данные во внешних рабочих книгах так же, как изменяете содержимое внутренних рабочих книг. Когда внешняя рабочая книга не может быть загружена, генерируется исключение.

Этот код C++ реализует описанный процесс:

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Восстановление рабочей книги из кэша диаграммы**

Если диаграмма использует внешнюю рабочую книгу, которой нет или она недоступна, Aspose.Slides может восстановить рабочую книгу диаграммы из данных, кэшированных в презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/), настройте его с помощью [set_SpreadsheetOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), и вызовите [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) со значением `true` перед открытием презентации.

Следующий пример C++ открывает презентацию, в которой диаграмма ссылается на недоступную внешнюю рабочую книгу, и получает восстановленные данные через [IChart::get_ChartData](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichart/get_chartdata/) и [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

```cpp
auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto chart = System::ExplicitCast<IChart>(shape);

auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Read or modify the recovered workbook data here.

presentation->Dispose();
```

Если внешняя рабочая книга недоступна и восстановление отключено, Aspose.Slides бросает `System::InvalidOperationException`. Включайте восстановление только тогда, когда использование кэшированных данных диаграммы является приемлемой альтернативой, поскольку кэш может не содержать изменения, внесённые во внешнюю рабочую книгу после последнего обновления презентации.

## **Часто задаваемые вопросы**

**Могу ли я определить, привязана ли конкретная диаграмма к внешней или встроенной рабочей книге?**

Да. Диаграмма имеет [type of data source](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) и [path to an external workbook](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); если источник — внешняя рабочая книга, вы можете прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**

Да. Если указать относительный путь, он автоматически преобразуется в абсолютный. Это удобно для переносимости проекта; однако помните, что презентация сохраняет абсолютный путь в файле PPTX.

**Можно ли использовать рабочие книги, расположенные на сетевых ресурсах/общих папках?**

Да, такие рабочие книги могут использоваться как внешний источник данных. Однако прямое редактирование удалённых рабочих книг из Aspose.Slides не поддерживается — они могут использоваться только как источник.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

Нет. Презентация сохраняет [link to the external file](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) и использует его только для чтения данных. Сам внешний файл не изменяется при сохранении презентации.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при связывании. Обычно удаляют защиту заранее или готовят расшифрованную копию (например, с помощью [Aspose.Cells](/cells/cpp/)) и связываются с этой копией.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**

Да. Каждая диаграмма хранит свою собственную ссылку. Если они указывают на один и тот же файл, изменение этого файла будет отображено в каждой диаграмме при следующей загрузке данных.