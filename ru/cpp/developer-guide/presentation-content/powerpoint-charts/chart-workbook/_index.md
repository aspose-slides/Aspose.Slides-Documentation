---
title: "Управление рабочими книгами диаграмм в презентациях с использованием C++"
linktitle: "Рабочая книга диаграммы"
type: docs
weight: 70
url: /ru/cpp/chart-workbook/
keywords:
- "рабочая книга диаграммы"
- "данные диаграммы"
- "ячейка рабочей книги"
- "подпись данных"
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
description: "Откройте Aspose.Slides для C++: легко управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, чтобы оптимизировать данные вашей презентации."
---
## **Обзор**

В этой статье объясняется, как работать с рабочими книгами диаграмм в Aspose.Slides. Она показывает, как читать и записывать данные диаграммы через потоки рабочей книги, использовать ячейки рабочей книги в качестве подписей данных диаграммы, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграммы.

Она также охватывает работу с внешними рабочими книгами в качестве источников данных для диаграмм. Примеры демонстрируют, как создать и назначить внешнюю рабочую книгу, получить путь к внешней рабочей книге, связанной с диаграммой, и редактировать данные диаграммы, когда рабочая книга доступна.

Для ячеек рабочей книги, представляющих отсутствующие данные, см. [Управление отображением пустых ячеек](/slides/ru/cpp/chart-series/) для различий между пустой ячейкой и нулём, а также сравнение линейных диаграмм доступных режимов отображения.

## **Включать данные из скрытых строк и столбцов**

Используйте [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) для управления тем, будет ли диаграмма отображать данные из скрытых строк и столбцов листа. Установите `true`, чтобы отображать только видимые ячейки, или `false`, чтобы включать как видимые, так и скрытые ячейки. Эта настройка управляет построением диаграммы; она не скрывает и не делает видимыми строки или столбцы листа.

[Пример презентации](hidden-source-data.pptx) содержит столбчатую диаграмму в качестве первой фигуры на первом слайде. Встроенный лист `Sheet1` содержит следующий исходный диапазон `A1:C4`. Строка 3 и столбец C скрыты, но их ячейки всё равно содержат значения.

| Строка листа | A: Месяц | B: Розница | C: Опт (скрытый столбец) |
| --- | --- | --- | --- |
| 2 | Январь | 10 | 30 |
| 3 (скрытая строка) | Февраль | 40 | 60 |
| 4 | Март | 20 | 50 |

Получайте исходные ячейки через [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) и считывайте [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) для проверки их статуса скрытости. Это свойство только для чтения. В данном файле B2 видима, B3 принадлежит скрытой строке, а C2 – скрытому столбцу; пример выводит `False`, `True` и `True` соответственно.

Для этого примера обновите данные диаграммы после изменения настройки построения: сохраните встроенную рабочую книгу с помощью [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) и загрузите её снова с помощью [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/). При включении всех ячеек также используйте [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) для восстановления полного диапазона, включая скрытую категорию февраля. Простое изменение флага недостаточно для обновления кэшированных данных диаграммы и меток категорий в этом примере.

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

        // Обновить данные диаграммы из встроенной рабочей книги.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Восстановить полный исходный диапазон, включая скрытые категории.
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

Пример сохраняет две версии презентации: одну только с видимыми значениями розницы (10 и 20), другую со всеми шестью значениями. Ниже приведённые изображения иллюстрируют два режима построения. Строка 3 и столбец C остаются скрытыми в обеих встроенных рабочих книгах.

| Только видимые ячейки (`true`) | Все ячейки (`false`) |
| --- | --- |
| ![Только видимые ячейки: значения розницы 10 и 20 для Января и Марта.](hidden_cells_True.png) | ![Все ячейки: значения розницы и опта для Января, Февраля и Марта.](hidden_cells_False.png) |

Скрытая ячейка, содержащая значение, отличается от пустой ячейки. [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) управляет тем, как отображаются отсутствующие значения; он не включает и не исключает скрытые исходные данные. См. [Управление отображением пустых ячеек](/slides/ru/cpp/chart-series/#control-the-display-of-empty-cells) для примера.

## **Получить диапазон данных диаграммы**

Перед обновлением данных рабочей книги в существующей презентации проверьте исходные диапазоны, чтобы определить, какие ячейки листа использует каждая диаграмма. Метод [IChartData::GetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) возвращает текущий диапазон данных в виде формулы, квалифицированной листом, например `Sheet1!$A$1:$D$5`. Здесь `Sheet1` – имя листа, `!` разделяет его от диапазона ячеек, а `$A$1:$D$5` обозначает ячейки от A1 до D5 включительно. Знаки доллара указывают на абсолютные ссылки на строки и столбцы.

Метод считывает текущий диапазон без изменения диаграммы или её рабочей книги. Если диаграмма не использует рабочую книгу в качестве источника данных, генерируется исключение [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/). Для получения дополнительной информации смотрите [Справочник API ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/).

Этот пример открывает презентацию и проверяет фигуры напрямую на каждом слайде в поисках диаграмм. Он выводит имя каждой диаграммы и её исходный диапазон. Если диаграмма не использует рабочую книгу, выводится сообщение и обработка продолжается со следующей диаграммой.

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

## **Чтение и запись данных диаграммы из рабочей книги**

Aspose.Slides для C++ предоставляет методы [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) и [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/), позволяющие читать и записывать рабочие книги данных диаграмм (содержащие данные, отредактированные с помощью Aspose.Cells). **Примечание**: данные диаграммы должны быть организованы точно так же или иметь структуру, аналогичную исходной.

Этот пример использует презентацию с диаграммой в качестве первой фигуры на первом слайде. Он читает встроенную рабочую книгу в поток, очищает существующие серии и категории, и записывает ту же рабочую книгу обратно. Изменения остаются в памяти; пример не сохраняет презентацию.

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

### **Проверка расположения диаграммы после изменения рабочей книги**

Когда вы заменяете встроенную рабочую книгу модифицированной, диаграмма сохраняет исходные коллекции серий и категорий. Это несоответствие может привести к ошибке [IChart::ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) с исключением «index out of range». Очистите существующие серии и категории перед записью обновлённой рабочей книги обратно в диаграмму. Этот пример использует диаграмму, которая является первой фигурой на первом слайде. Комментарий отмечает место, где должно происходить редактирование рабочей книги; исполняемый пример записывает оригинальную рабочую книгу обратно и проверяет расположение в памяти.

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

    // Измените поток рабочей книги здесь, например, используя Aspose.Cells.

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

Очистка коллекций удаляет устаревшие ссылки на данные перед записью рабочей книги. Восстановите необходимые сопоставления серий и категорий для обновлённой рабочей книги перед использованием диаграммы.

## **Установить пользовательские числовые форматы для ячеек рабочей книги**

Используйте [IChartDataCell::set_CustomNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_customnumberformat/) для управления тем, как числовые значения отображаются в встроенной рабочей книге диаграммы. Например, в отчёте может потребоваться вывести коэффициент конверсии в виде процента с четырёхдесятичными знаками и коэффициент с пятью десятичными знаками. Оставляйте оба значения числовыми, чтобы они оставались доступными для вычислений и построения диаграмм.

Числовой формат изменяет только отображение, а не сохраняемое значение. Формат `0.0000%` отображает `0.125` как `12.5000%`; он не заменяет сохранённое число на `12.5`. Аналогично, `0.00000` отображает `0.1234567` как `0.12346` без округления сохранённого значения. Если пользовательский формат – пустая строка (`""`), используется формат, заданный через [set_PresetNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_presetnumberformat/).

Следующий пример создаёт столбчатую диаграмму и получает доступ к её ячейкам через [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/). На листе 0 ячейка B2 содержит коэффициент конверсии, а C2 – коэффициент. Обе ячейки поставляют значения для диаграммы. Пример также включает подписи значений, связанные с исходными форматами.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 270, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
chart->set_HasTitle(false);

chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00");
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(0);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto categoryCell = workbook->GetCell(0, u"A2", ObjectExt::Box<String>(u"Sample"));
chart->get_ChartData()->get_Categories()->Add(categoryCell);

auto percentageCell = workbook->GetCell(0, u"B2", ObjectExt::Box<double>(0.125));
percentageCell->set_CustomNumberFormat(u"0.0000%");
auto percentageName = workbook->GetCell(0, u"B1", ObjectExt::Box<String>(u"Conversion rate"));
auto percentageSeries = chart->get_ChartData()->get_Series()->Add(percentageName, chart->get_Type());
percentageSeries->get_DataPoints()->AddDataPointForBarSeries(percentageCell);

auto precisionCell = workbook->GetCell(0, u"C2", ObjectExt::Box<double>(0.1234567));
precisionCell->set_CustomNumberFormat(u"0.00000");
auto precisionName = workbook->GetCell(0, u"C1", ObjectExt::Box<String>(u"Coefficient"));
auto precisionSeries = chart->get_ChartData()->get_Series()->Add(precisionName, chart->get_Type());
precisionSeries->get_DataPoints()->AddDataPointForBarSeries(precisionCell);

for (auto series : IterateOver(chart->get_ChartData()->get_Series()))
{
    auto labelFormat = series->get_DataPoint(0)->get_Label()->get_DataLabelFormat();
    labelFormat->set_ShowValue(true);
    labelFormat->set_IsNumberFormatLinkedToSource(true);
}

presentation->Save(u"CustomCellFormats.pptx", Export::SaveFormat::Pptx);
```

Форматы ячеек рабочей книги отдельны от форматов, задаваемых непосредственно на осях диаграммы или подписьях данных. В этом примере каждый подпись отображает значение исходной ячейки, потому что [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) вызывается с `true`, и следует исходному числовому формату, поскольку [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_isnumberformatlinkedtosource/) вызывается с `true`. После сохранения и повторного открытия презентации подписи показывают `12.5000%` и `0.12346`, как показано ниже. Вертикальная ось использует собственный формат `0.00`, заданный через [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_numberformat/), при этом [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isnumberformatlinkedtosource/) вызывается с `false`.

Чтобы задать отдельный формат подписи, отключите привязку к источнику, установив флаг в `false`, и задайте формат через [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_numberformat/). Это не изменит формат ячейки рабочей книги. Например, независимый формат подписи `0.00` отобразит первое значение как `0.13`, тогда как B2 всё равно будет показывать `12.5000%`. Смотрите [Подписи данных диаграммы](/slides/ru/cpp/chart-data-label/#set-percentage-sign-with-chart-data-labels) для прямого форматирования подписей.

Изображение ниже получено из сохранённой презентации после её повторного открытия:

![Столбчатая диаграмма с подписью, связанной с источником, показывающая 12.5000% и 0.12346, и независимым числовым форматом оси.](custom-cell-formats.png)

## **Установить ячейку рабочей книги в качестве подписи данных диаграммы**

Вы можете использовать текст из ячеек рабочей книги в качестве подписей данных диаграммы.

Этот пример добавляет пузырьковую диаграмму с данными по умолчанию на первый слайд существующей презентации. Он использует ячейки A10:A12 на листе 0 для первых трёх подписей первой серии, включает подписи из ячеек и сохраняет обновлённую презентацию.

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

## **Управление листами**

Метод [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) предоставляет доступ к листам в рабочей книге диаграммы. Этот пример создаёт круговую диаграмму с данными по умолчанию и выводит имена каждого листа в консоль.

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

## **Указать тип источника данных**

Значения точек серии также могут храниться непосредственно как числовые литералы. См. [Установить значения рядов с использованием числовых литералов](/slides/ru/cpp/chart-series/#set-series-values-using-numeric-literals) для полного примера, сохраняющего и читающего их. Тип источника значений точек отделён от внутренней или внешней конфигурации рабочей книги диаграммы; использование числовых литералов само по себе не удаляет встроенную рабочую книгу.

Этот пример создаёт 3D столбчатую диаграмму с данными по умолчанию и задаёт два имени серий, используя разные источники данных. Первое имя задаётся строковым литералом; второе использует ячейку C1 на листе 0. Перечисление [DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) выбирает источник для каждого имени. Пример сохраняет презентацию с обновлёнными именами серий.

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

## **Обнаружить неподдерживаемые форматы встроенных рабочих книг**

Aspose.Slides не поддерживает двоичный формат рабочей книги Excel (.xlsb), который может быть встроен в некоторые диаграммы. Вы можете использовать метод [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) на [IChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/) вместе с перечислением [WorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/) для обнаружения неподдерживаемых форматов и пропуска таких диаграмм. Этот пример инспектирует фигуры на первом слайде существующей презентации, пропускает не‑диаграммные фигуры и выводит диагностическое сообщение для каждой диаграммы с встроенной рабочей книгой .xlsb.

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

    // Читаем или изменяем поддерживаемые данные рабочей книги диаграммы здесь.
}
```

## **Внешняя рабочая книга**

Aspose.Slides поддерживает использование внешних рабочих книг в качестве источника данных для диаграмм.

### **Создать внешнюю рабочую книгу**

Используйте [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) и [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) для экспорта встроенной рабочей книги диаграммы в файл и связывания диаграммы с этой внешней рабочей книгой.

Этот пример создаёт круговую диаграмму с данными по умолчанию и экспортирует её рабочую книгу. Он закрывает поток вывода перед назначением внешней рабочей книги в качестве источника данных диаграммы, затем сохраняет связанную презентацию.

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

### **Установить внешнюю рабочую книгу**

С помощью метода [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) вы можете назначить внешнюю рабочую книгу диаграмме в качестве её источника данных. Этот метод также может использоваться для обновления пути к внешней рабочей книге (если она была перемещена).

Хотя редактировать данные в рабочих книгах, хранящихся в удалённых местах или ресурсах, нельзя, такие книги всё равно могут использоваться в качестве внешнего источника данных. Если указан относительный путь к внешней рабочей книге, он автоматически преобразуется в полный путь.

Этот пример использует внешнюю рабочую книгу, лист которой `Sheet1` содержит имя серии в B1, имена категорий в A2:A4 и числовые значения в B2:B4. Пример создаёт круговую диаграмму, связывает рабочую книгу и использует [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) для сопоставления A1:B4 с одной серией и тремя категориями. Пример сохраняет презентацию со связанным графиком.

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

Параметр `updateChartData` метода [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) управляет тем, будет ли загружена рабочая книга.

* Когда `updateChartData` равно `false`, обновляется только путь к рабочей книге. Данные диаграммы не загружаются и не обновляются из целевой рабочей книги, поэтому она может быть недоступна.
* Когда `updateChartData` равно `true`, данные диаграммы обновляются из целевой рабочей книги.

Следующий пример назначает запасной URL с `updateChartData`, установленным в `false`. Он сохраняет данные по умолчанию круговой диаграммы и сохраняет презентацию без загрузки недоступной рабочей книги.

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

### **Получить путь к рабочей книге внешнего источника данных диаграммы**

Чтобы определить, к какой рабочей книге привязана диаграмма, проверьте, использует ли диаграмма внешний источник данных, и получите путь к её рабочей книге.

Этот пример проверяет первую фигуру на первом слайде презентации, содержащей связанную внешнюю рабочую книгу. Если это диаграмма, связанная с внешней рабочей книгой, пример выводит [get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) в консоль. Затем сохраняет копию презентации.

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

### **Редактировать данные диаграммы**

Вы можете редактировать данные во внешних рабочих книгах так же, как в случае внутренних. Если внешнюю рабочую книгу невозможно загрузить, генерируется исключение.

Этот пример использует диаграмму, которая является первой фигурой на первом слайде и связана с доступной внешней рабочей книгой. Он задаёт значение первого пункта первой серии, привязанное к ячейке, равным 100 и сохраняет обновлённую презентацию. Редактирование значений ячеек может обновлять связанный внешний файл XLSX, поэтому используйте копию, если необходимо сохранить оригинал.

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

### **Восстановить рабочую книгу из кэша диаграммы**

Если диаграмма использует внешнюю рабочую книгу, которая отсутствует или недоступна, Aspose.Slides может восстановить рабочую книгу диаграммы из кэшированных данных презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/), настройте его с помощью [set_SpreadsheetOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), и вызовите [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) с `true` перед открытием презентации.

Следующий пример на C++ восстанавливает данные рабочей книги для диаграммы, являющейся первой фигурой на первом слайде и ссылающейся на недоступную внешнюю рабочую книгу. Он получает восстановленные данные через [IChart::get_ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) и [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

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

    // Прочитать или изменить восстановленные данные рабочей книги здесь.
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Если внешняя рабочая книга недоступна и восстановление отключено, Aspose.Slides генерирует [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/). Включайте восстановление только тогда, когда использование кэшированных данных диаграммы допустимо, поскольку кэш может не содержать изменений, сделанных во внешней рабочей книге после последнего обновления презентации.

## **Часто задаваемые вопросы**

**Могу ли я определить, связана ли конкретная диаграмма с внешней или встроенной рабочей книгой?**

Да. Диаграмма имеет [тип источника данных](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) и [путь к внешней рабочей книге](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); если источник – внешняя рабочая книга, вы можете прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**

Да. Если указать относительный путь, он автоматически преобразуется в абсолютный. Презентация сохраняет абсолютный путь в файле PPTX, поэтому при перемещении рабочей книги может потребоваться обновить ссылку.

**Можно ли использовать рабочие книги, размещённые на сетевых ресурсах/общих папках?**

Да, такие рабочие книги могут использоваться в качестве внешнего источника данных. Однако редактирование удалённых рабочих книг напрямую из Aspose.Slides не поддерживается — они могут использоваться только как источник.

**Перезаписывает ли Aspose.Slides внешний файл XLSX при сохранении презентации?**

Презентация хранит [ссылку на внешний файл](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Редактирование данных, привязанных к ячейкам, может также обновлять связанный локальный файл XLSX. Используйте копию рабочей книги, если оригинал должен остаться неизменным.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при связывании. Обычно снимают защиту заранее или подготавливают расшифрованную копию (например, с помощью [Aspose.Cells](https://reference.aspose.com/cells/cpp/)) и связывают с этой копией.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**

Да. Каждая диаграмма хранит свою собственную ссылку. Если они указывают на один и тот же файл, обновление этого файла отразится в каждой диаграмме при следующей загрузке данных.