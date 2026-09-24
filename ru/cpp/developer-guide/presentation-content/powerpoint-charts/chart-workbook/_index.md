---
title: "Управление рабочими книгами диаграмм в презентациях с помощью C++"
linktitle: "Рабочая книга диаграммы"
type: docs
weight: 70
url: /ru/cpp/chart-workbook/
keywords:
- "рабочая книга диаграммы"
- "данные диаграммы"
- "ячейка рабочей книги"
- "метка данных"
- "лист"
- "источник данных"
- "внешняя рабочая книга"
- "внешние данные"
- "кеш диаграммы"
- "восстановление рабочей книги"
- "PowerPoint"
- "презентация"
- "C++"
- "Aspose.Slides"
description: "Откройте для себя Aspose.Slides для C++: легко управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая работу с данными ваших презентаций."
---
## **Обзор**

Эта статья объясняет, как работать с книгами диаграмм в Aspose.Slides. Описывается, как читать и записывать данные диаграмм через потоки книг, использовать ячейки книги в качестве меток данных диаграммы, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграмм.

Статья также охватывает работу с внешними книгами в качестве источников данных диаграмм. В примерах демонстрируется, как создать и назначить внешнюю книгу, получить путь к внешней книге, связанной с диаграммой, и редактировать данные диаграммы, когда книга доступна.

Для ячеек книги, представляющих отсутствующие данные, см. [Control the Display of Empty Cells](/slides/ru/cpp/chart-series/) для различий между пустой ячейкой и нулём, а также сравнение линейных диаграмм доступных режимов отображения.

## **Чтение и запись данных диаграммы из книги**

Aspose.Slides предоставляет методы [ReadWorkbookStream](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) и [WriteWorkbookStream](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/), позволяющие читать и записывать книги данных диаграмм (содержащие данные, отредактированные в Aspose.Cells). **Примечание**: данные диаграммы должны быть организованы одинаково или иметь структуру, аналогичную исходным.

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

### **Проверка макета диаграммы после изменения книги**

Когда вы заменяете встроенную книгу изменённой, диаграмма сохраняет свои исходные коллекции рядов и категорий. Это несоответствие может вызвать ошибку в [IChart::ValidateChartLayout](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichart/validatechartlayout/) с сообщением о выходе индекса за пределы диапазона. Очистите существующие ряды и категории перед записью обновлённой книги обратно в диаграмму.

```cpp
// После изменения потока рабочей книги (например, с использованием Aspose.Cells)
auto updatedWorkbook = chartData->ReadWorkbookStream();

// Очистить существующие ссылки на данные.
chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

updatedWorkbook->set_Position(0);
chartData->WriteWorkbookStream(updatedWorkbook);

chart->ValidateChartLayout();
```

Очистка коллекций гарантирует согласованность структуры данных диаграммы с новой книгой, позволяя `ValidateChartLayout` завершиться без ошибок.

## **Установить ячейку книги в качестве метки данных диаграммы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте пузырьковую диаграмму с некоторыми данными.
4. Доступ к рядам диаграммы.
5. Установите ячейку книги в качестве метки данных.
6. Сохраните презентацию.

Этот C++‑код показывает, как установить ячейку книги в качестве метки данных диаграммы:

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

// Создает экземпляр класса Presentation, представляющего файл презентации 
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

Этот C++‑код демонстрирует операцию, в которой используется метод [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) для доступа к коллекции листов:

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

## **Указание типа источника данных**

Этот C++‑код показывает, как указать тип для источника данных:

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

## **Обнаружение неподдерживаемых форматов встроенных книг**

Aspose.Slides не поддерживает двоичный формат книги Excel (.xlsb), который может быть встроен в некоторые диаграммы. Вы можете использовать метод `get_EmbeddedWorkbookType` на [IChartData](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdata/) вместе с перечислением [WorkbookType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/workbooktype/) для обнаружения неподдерживаемых форматов и пропуска таких диаграмм.

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
        // Встроенная рабочая книга в формате .xlsb, который не поддерживается.
        continue;
    }

    // Здесь читайте или изменяйте данные рабочей книги диаграммы.
}
```

## **Внешняя книга**

Aspose.Slides поддерживает использование внешних книг в качестве источника данных для диаграмм.

### **Создание внешней книги**

С помощью методов **`ReadWorkbookStream`** и **`SetExternalWorkbook`** вы можете либо создать внешнюю книгу с нуля, либо сделать внутреннюю книгу внешней.

Этот C++‑код демонстрирует процесс создания внешней книги:

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

### **Установка внешней книги**

С помощью метода **`IChartData::SetExternalWorkbook`** вы можете назначить внешнюю книгу диаграмме в качестве её источника данных. Этот метод также можно использовать для обновления пути к внешней книге (если она была перемещена).

Хотя редактировать данные в книгах, хранящихся в удалённых местах или ресурсах, нельзя, такие книги всё равно можно использовать как внешний источник данных. Если указан относительный путь к внешней книге, он автоматически преобразуется в абсолютный путь.

Этот C++‑код показывает, как установить внешнюю книгу:

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

Параметр `updateChartData` (в методе `SetExternalWorkbook`) используется для указания, будет ли загружаться Excel‑книга.

* Когда значение `updateChartData` установлено в `false`, обновляется только путь к книге — данные диаграммы не загружаются и не обновляются из целевой книги. Такой вариант полезен, когда целевая книга отсутствует или недоступна.  
* Когда значение `updateChartData` установлено в `true`, данные диаграммы обновляются из целевой книги.

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

### **Получение пути к книге внешнего источника данных диаграммы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Создайте объект для формы диаграммы.
4. Создайте объект для типа источника (`ChartDataSourceType`), представляющего источник данных диаграммы.
5. Укажите соответствующее условие в зависимости от того, совпадает ли тип источника с типом внешней книги.

Этот C++‑код демонстрирует операцию:

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

// Сохраняет презентацию
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **Редактирование данных диаграммы**

Вы можете редактировать данные во внешних книгах так же, как изменяете содержимое внутренних книг. Если внешняя книга не может быть загружена, генерируется исключение.

Этот C++‑код реализует описанный процесс:

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

### **Восстановление книги из кэша диаграммы**

Если диаграмма использует внешнюю книгу, которой нет или она недоступна, Aspose.Slides может восстановить книгу диаграммы из данных, кэшированных в презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/), настройте их с помощью [set_SpreadsheetOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), и вызовите [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) со значением `true` перед открытием презентации.

Следующий пример на C++ открывает презентацию, в которой диаграмма ссылается на недоступную внешнюю книгу, и получает восстановленные данные через [IChart::get_ChartData](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichart/get_chartdata/) и [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

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

Если внешняя книга недоступна и восстановление отключено, Aspose.Slides бросает `System::InvalidOperationException`. Включайте восстановление только тогда, когда использование кэшированных данных диаграммы является приемлемым вариантом, так как кэш может не содержать изменений, внесённых во внешнюю книгу после последнего обновления презентации.

## **Часто задаваемые вопросы**

**Могу ли я определить, связана ли конкретная диаграмма с внешней или встроенной книгой?**

Да. У диаграммы есть [тип источника данных](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) и [путь к внешней книге](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); если источник — внешняя книга, вы можете считывать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним книгам, и как они хранятся?**

Да. При указании относительного пути он автоматически преобразуется в абсолютный. Это удобно для переносимости проекта; однако в файле PPTX сохраняется абсолютный путь.

**Можно ли использовать книги, расположенные на сетевых ресурсах/общих папках?**

Да, такие книги могут использоваться как внешний источник данных. Однако прямое редактирование удалённых книг из Aspose.Slides не поддерживается — их можно только использовать как источник.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

Нет. Презентация хранит [ссылку на внешний файл](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) и использует её только для чтения данных. Сам внешний файл не изменяется при сохранении презентации.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при установке ссылки. Обычно снимают защиту заранее или подготавливают дешифрованную копию (например, с помощью [Aspose.Cells](/cells/cpp/)) и ссылаются на неё.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю книгу?**

Да. Каждая диаграмма хранит свою собственную ссылку. Если все они указывают на один и тот же файл, обновление этого файла отразится во всех диаграммах при следующей загрузке данных.