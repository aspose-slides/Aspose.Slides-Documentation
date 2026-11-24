---
title: Управление книгами данных диаграмм в презентациях с помощью C++
linktitle: Книга диаграммы
type: docs
weight: 70
url: /ru/cpp/chart-workbook/
keywords:
- рабочая книга диаграммы
- данные диаграммы
- ячейка книги
- подпись данных
- лист
- источник данных
- внешняя книга
- внешние данные
- кеш диаграммы
- восстановление книги
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Откройте для себя Aspose.Slides для C++: легко управляйте книгами данных диаграмм в форматах PowerPoint и OpenDocument, упрощая работу с данными вашей презентации."
---
## **Обзор**

Эта статья объясняет, как работать с книгами данных диаграмм в Aspose.Slides. Она показывает, как читать и записывать данные диаграммы через потоки книги, использовать ячейки книги в качестве подписей данных диаграммы, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграммы.

Также рассматривается работа с внешними книгами как источниками данных диаграммы. Примеры демонстрируют, как создать и назначить внешнюю книгу, получить путь к внешней книге, связанную с диаграммой, и редактировать данные диаграммы, когда книга доступна.

Для ячеек книги, представляющих отсутствующие данные, см. [Control the Display of Empty Cells](/slides/ru/cpp/chart-series/) для различия между пустой ячейкой и нулём, а также сравнение режимов отображения на линейной диаграмме.

## **Включать данные из скрытых строк и столбцов**

Используйте [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) для управления тем, использует ли диаграмма данные из скрытых строк и столбцов листа. Установите значение `true`, чтобы строить только видимые ячейки, или `false`, чтобы включать как видимые, так и скрытые ячейки. Этот параметр управляет построением диаграммы; он не скрывает и не раскрывает строки или столбцы листа.

Пример презентации ([sample presentation](hidden-source-data.pptx)) содержит столбчатую диаграмму в виде первой фигуры на первом слайде. Встроенный лист `Sheet1` содержит следующий исходный диапазон `A1:C4`. Строка 3 и столбец C скрыты, но их ячейки по‑прежнему содержат значения.

| Строка листа | A: Месяц | B: Розничные продажи | C: Оптовые продажи (скрытый столбец) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (скрытая строка) | February | 40 | 60 |
| 4 | March | 20 | 50 |

Получайте доступ к исходным ячейкам через [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) и считывайте [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/), чтобы проверить их статус скрытия. Это свойство только для чтения. В этом файле B2 видима, B3 относится к скрытой строке, а C2 — к скрытому столбцу; пример выводит `False`, `True` и `True` соответственно.

Для этого примера обновите данные диаграммы после изменения настройки построения: сохраните встроенную книгу с помощью [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) и загрузите её заново с помощью [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/). При включении всех ячеек также используйте [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/), чтобы восстановить полный диапазон, включая скрытую категорию февраль. Простое изменение флага недостаточно для обновления кэшированных данных диаграммы и подписей категорий в этом примере.

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

        // Обновить данные диаграммы из встроенной книги.
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

Пример сохраняет две версии презентации: одну только с видимыми значениями розничных продаж (10 и 20), другую со всеми шестью значениями. Ниже приведённые изображения иллюстрируют два режима построения. Строка 3 и столбец C остаются скрытыми в обеих встроенных книгах.

| Только видимые ячейки (`true`) | Все ячейки (`false`) |
| --- | --- |
| ![Только видимые ячейки: значения розничных продаж 10 и 20 для января и марта.](hidden_cells_True.png) | ![Все ячейки: значения розничных и оптовых продаж для января, февраля и марта.](hidden_cells_False.png) |

Скрытая ячейка, содержащая значение, отличается от пустой ячейки. [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) управляет тем, как отображаются отсутствующие значения; он не включает и не исключает скрытые исходные данные. См. [Control the Display of Empty Cells](/slides/ru/cpp/chart-series/#control-the-display-of-empty-cells) для примера.

## **Получить диапазон данных диаграммы**

Перед обновлением данных книги в существующей презентации проверьте исходные диапазоны, чтобы определить, какие ячейки листа используют каждая диаграмма. Метод [IChartData::GetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) возвращает текущий диапазон данных в виде формулы, квалифицированной листом, например `Sheet1!$A$1:$D$5`. Здесь `Sheet1` — имя листа, `!` разделяет его от диапазона ячеек, а `$A$1:$D$5` указывает ячейки от A1 до D5 включительно. Доллары обозначают абсолютные ссылки на строки и столбцы.

Метод считывает текущий диапазон без изменения диаграммы или её книги. Если диаграмма не использует книгу в качестве источника данных, генерируется исключение [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/). Подробнее см. в [ChartData API Reference](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/).

В этом примере открывается презентация и непосредственно на каждом слайде проверяются фигуры на наличие диаграмм. Выводятся имя каждой диаграммы и её исходный диапазон. Если диаграмма не использует книгу, выводится сообщение и переход к следующей диаграмме.

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

## **Чтение и запись данных диаграммы из книги**

Aspose.Slides для C++ предоставляет методы [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) и [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/), позволяющие считывать и записывать книги данных диаграмм (содержащие данные диаграмм, отредактированные с помощью Aspose.Cells). **Примечание**: данные диаграммы должны быть организованы тем же способом или иметь структуру, аналогичную исходной.

Этот пример использует презентацию, где диаграмма является первой фигурой на первом слайде. Он считывает встроенную книгу в поток, очищает существующие серии и категории, и записывает ту же книгу обратно. Изменения остаются в памяти; пример не сохраняет презентацию.

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

### **Проверка компоновки диаграммы после изменения книги**

Когда вы заменяете встроенную книгу модифицированной, диаграмма сохраняет свои исходные коллекции серий и категорий. Это несоответствие может вызвать ошибку [IChart::ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) с индексом вне диапазона. Очистите существующие серии и категории перед записью обновлённой книги обратно в диаграмму. Этот пример использует диаграмму, являющуюся первой фигурой на первом слайде. Комментарий указывает, где будет происходить редактирование книги; исполняемый пример записывает оригинальную книгу обратно и проверяет компоновку в памяти.

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

    // Измените поток книги здесь, например, используя Aspose.Cells.

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

Очистка коллекций удаляет устаревшие ссылки на данные перед записью книги обратно. Перед использованием диаграммы восстановите необходимые сопоставления серий и категорий для обновлённой книги.

## **Выбор способа хранения меток категорий**

Вызовите [IChartCategoryCollection::set_UseCells](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategorycollection/set_usecells/) у пустой коллекции категорий перед добавлением меток. Используйте ячейки листа для меток, ссылающихся на данные книги или формирующих иерархию, например кварталы, сгруппированные по годам. Для меток одного уровня, не требующих ссылок на ячейки, используйте строковые литералы. Эта настройка применяется только к категориям. Оба примера диаграмм используют ячейки листа для числовых значений серий.

Пример создаёт две столбчатые диаграммы и выводит режим хранения и метки `Q1 Q2 Q3 Q4` для каждой. Для меток, основанных на листе, [IChartCategory::get_AsCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategory/get_ascell/) предоставляет доступ к базовой ячейке, а [IChartDataCell::get_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_value/) возвращает её метку. Для литеральных меток строка читается напрямую из [IChartCategory::get_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategory/get_value/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategory.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <initializer_list>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

for (auto useCells : {true, false})
{
    auto x = useCells ? 20 : 360;
    auto chart = shapes->AddChart(ChartType::ClusteredColumn, x, 20, 320, 250);
    auto data = chart->get_ChartData();
    auto categories = data->get_Categories();
    data->get_Series()->Clear();
    categories->Clear();
    categories->set_UseCells(useCells);

    auto workbook = data->get_ChartDataWorkbook();
    auto seriesName = workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Sales"));
    auto series = data->get_Series()->Add(seriesName, chart->get_Type());
    for (auto row = 1; row <= 4; ++row)
    {
        auto label = String::Format(u"Q{0}", row);
        auto labelValue = ObjectExt::Box<String>(label);
        if (useCells)
        {
            auto labelCell = workbook->GetCell(0, row, 0, labelValue);
            categories->Add(labelCell);
        }
        else
        {
            categories->Add(labelValue);
        }

        auto valueCell = workbook->GetCell(0, row, 1, ObjectExt::Box<int32_t>(row * 10));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
    }

    Console::Write(u"UseCells = {0}:", categories->get_UseCells());
    for (auto category : IterateOver(categories))
    {
        auto label = categories->get_UseCells() ? category->get_AsCell()->get_Value() : category->get_Value();
        Console::Write(u" {0}", label->ToString());
    }
    Console::WriteLine();
}

presentation->Save(u"category-labels.pptx", Export::SaveFormat::Pptx);
```

## **Установка пользовательских числовых форматов для ячеек книги**

Используйте [IChartDataCell::set_CustomNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_customnumberformat/) , чтобы управлять отображением числовых значений в встроенной книге диаграммы. Например, в отчёте может потребоваться показывать коэффициент преобразования в виде процента с четырьмя знаками после запятой и коэффициент с пятью знаками после запятой. Оставляйте оба значения числовыми, чтобы они оставались доступными для вычислений и построения диаграмм.

Числовой формат меняет только отображение, а не сохраняемое значение. Формат `0.0000%` отображает `0.125` как `12.5000%`; он не заменяет сохранённое число на `12.5`. Аналогично, `0.00000` отображает `0.1234567` как `0.12346` без округления сохранённого значения. Если пользовательский формат задан пустой строкой (`""`), используется формат, назначенный через [set_PresetNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_presetnumberformat/).

В следующем примере создаётся столбчатая диаграмма и её ячейки получаются через [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/). На листе 0 ячейка B2 содержит коэффициент преобразования, а C2 — коэффициент. Обе ячейки предоставляют значения для диаграммы. Пример также включает подписи значений, привязанные к исходным форматам.

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

Форматы ячеек книги отличаются от форматов, задаваемых непосредственно на осях диаграммы или подпирах данных. В этом примере каждая подпись отображает значение своей исходной ячейки, потому что [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) вызывается со значением `true`, и использует исходный числовой формат, поскольку [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_isnumberformatlinkedtosource/) вызывается со значением `true`. После сохранения и повторного открытия презентации подписи отображают `12.5000%` и `0.12346`, как показано ниже. Вертикальная ось использует собственный формат `0.00`, назначенный через [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_numberformat/), при этом [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isnumberformatlinkedtosource/) вызывается со значением `false`.

Чтобы отформатировать подпись данных независимо, установите её флаг ссылки на источник в `false` и задайте формат через [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_numberformat/). Это не изменит формат ячейки книги. Например, независимый формат подписи `0.00` отображает первое значение как `0.13`, тогда как B2 по‑прежнему отображает `12.5000%`. См. [Chart Data Labels](/slides/ru/cpp/chart-data-label/#set-percentage-sign-with-chart-data-labels) для прямого форматирования подписей.

Изображение ниже было получено из сохранённой презентации после её повторного открытия:

![Столбчатая диаграмма с метками, связанными с источником, показывающими 12.5000% и 0.12346, и независимо отформатированной числовой осью.](custom-cell-formats.png)

## **Установка ячейки книги в качестве подписи данных диаграммы**

Вы можете использовать текст из ячеек книги в качестве подписей данных диаграммы.

В этом примере добавляется пузырьковая диаграмма с данными по умолчанию на первый слайд существующей презентации. Он использует ячейки A10:A12 на листе 0 для первых трёх меток первой серии, включает подписи из ячеек и сохраняет обновлённую презентацию.

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

Метод [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) предоставляет доступ к листам в книге диаграммы. В этом примере создаётся круговая диаграмма с данными по умолчанию и выводятся имена всех листов в консоль.

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

## **Указание типа источника данных**

Значения точек серии также могут храниться непосредственно как числовые литералы. См. [Set Series Values Using Numeric Literals](/slides/ru/cpp/chart-series/#set-series-values-using-numeric-literals) для полного примера их сохранения и чтения. Тип источника значений точек отдельный от внутренней или внешней конфигурации книги диаграммы; использование числовых литералов само по себе не удаляет встроенную книгу.

В этом примере создаётся 3‑D столбчатая диаграмма с данными по умолчанию и задаются две названия серий, используя разные источники данных. Первое название использует строковый литерал; второе использует ячейку C1 на листе 0. Перечисление [DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) выбирает источник для каждого названия. Пример сохраняет презентацию с обновлёнными названиями серий.

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
#include <Export/SaveFormat> 
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto  ... // (No comments present in the original code to translate)
```

## **Обнаружение неподдерживаемых форматов встроенных книг**

Aspose.Slides не поддерживает двоичный формат книги Excel (.xlsb), который может быть встроен в некоторые диаграммы. Вы можете использовать метод [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) у [IChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/) совместно с перечислением [WorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/), чтобы обнаружить неподдерживаемые форматы и пропустить такие диаграммы. В этом примере проверяются фигуры на первом слайде существующей презентации, пропускаются не‑диаграммные фигуры и выводится диагностическое сообщение для каждой диаграммы со встроенной книгой .xlsb.

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

    // Считать или изменить поддерживаемые данные книги диаграммы здесь.
}
```

## **Внешняя книга**

Aspose.Slides поддерживает использование внешних книг в качестве источника данных для диаграмм.

### **Создание внешней книги**

Используйте [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) и [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) , чтобы экспортировать встроенную книгу диаграммы в файл и связать диаграмму с этой внешней книгой.

В этом примере создаётся круговая диаграмма с данными по умолчанию и экспортируется её книга. Выводной поток закрывается перед назначением внешней книги в качестве источника данных диаграммы, затем сохраняется связанная презентация.

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

### **Назначение внешней книги**

С помощью метода [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) можно назначить внешнюю книгу диаграмме в качестве её источника данных. Этот метод также можно использовать для обновления пути к внешней книге (если она была перемещена).

Хотя вы не можете редактировать данные в книгах, хранящихся в удалённых местах или ресурсах, их всё равно можно использовать как внешний источник данных. Если указан относительный путь к внешней книге, он автоматически преобразуется в полный путь.

В этом примере используется внешняя книга, лист которой `Sheet1` содержит название серии в B1, названия категорий в A2:A4 и числовые значения в B2:B4. Пример создаёт круговую диаграмму, связывает книгу и использует [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) , чтобы сопоставить A1:B4 одной серии и трём категориям. Пример сохраняет презентацию со связанной диаграммой.

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

Параметр `updateChartData` метода [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) управляет тем, будет ли загружена книга.

* Когда `updateChartData` равно `false`, обновляется только путь к книге. Данные диаграммы не загружаются и не обновляются из целевой книги, поэтому книга может быть недоступна.
* Когда `updateChartData` равно `true`, данные диаграммы обновляются из целевой книги.

В следующем примере присваивается фиктивный URL с `updateChartData`, установленным в `false`. Сохраняются значения по умолчанию круговой диаграммы, и презентация сохраняется без загрузки недоступной книги.

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

### **Получение пути к книге внешнего источника данных диаграммы**

Чтобы определить книгу, связанную с диаграммой, проверьте, использует ли диааграмма внешний источник данных, и получите путь к её книге.

В этом примере проверяется первая фигура на первом слайде презентации со связанным внешним файлом книги. Если это диаграмма, связанная с внешней книгой, пример выводит [get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) в консоль. Затем сохраняется копия презентации.

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

### **Редактирование данных диаграммы**

Вы можете редактировать данные во внешних книгах так же, как меняете содержание внутренних книг. Когда внешняя книга не может быть загружена, выбрасывается исключение.

В этом примере используется диаграмма, первая фигура на первом слайде, связанная с доступной внешней книгой. Он задаёт значение первой точки данных первой серии, основанное на ячейке, равным 100, и сохраняет обновлённую презентацию. Изменение значений ячеек может обновить связанный внешний файл XLSX, поэтому используйте копию, если необходимо сохранить оригинальную книгу.

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

### **Восстановление книги из кэша диаграммы**

Если диаграмма использует внешнюю книгу, которой нет или она недоступна, Aspose.Slides может восстановить книгу диаграммы из данных, кэшированных в презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/), настройте его с помощью [set_SpreadsheetOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), и вызовите [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) со значением `true` перед открытием презентации.

В следующем примере на C++ восстанавливаются данные книги для диаграммы, первая фигура на первом слайде, ссылающейся на недоступную внешнюю книгу. Доступ к восстановленным данным осуществляется через [IChart::get_ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) и [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

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

    // Считать или изменить восстановленные данные книги здесь.
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Если внешняя книга недоступна и восстановление отключено, Aspose.Slides генерирует [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/). Включайте восстановление только тогда, когда использование кэшированных данных диаграммы является приемлемой альтернативой, так как кэш может не содержать изменения, внесённые во внешнюю книгу после последнего обновления презентации.

## **FAQ**

**Могу ли я определить, связана ли конкретная диаграмма с внешней или встроенной книгой?**

Да. У диаграммы есть [тип источника данных](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) и [путь к внешней книге](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); если источник — внешняя книга, вы можете прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним книгам, и как они хранятся?**

Да. Если указать относительный путь, он автоматически преобразуется в абсолютный. Презентация сохраняет абсолютный путь в файле PPTX, поэтому при перемещении книги может потребоваться обновить ссылку.

**Можно ли использовать книги, находящиеся на сетевых ресурсах/общих папках?**

Да, такие книги можно использовать в качестве внешнего источника данных. Однако редактирование удалённых книг напрямую из Aspose.Slides не поддерживается — они могут использоваться только как источник.

**Перезаписывает ли Aspose.Slides внешний файл XLSX при сохранении презентации?**

Презентация сохраняет [ссылку на внешний файл](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Редактирование данных диаграммы, привязанных к ячейкам, также может обновлять связанный локальный файл XLSX. Используйте копию книги, если оригинал должен оставаться неизменным.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при связывании. Обычно сначала снимают защиту или подготавливают дешифрованную копию (например, с помощью [Aspose.Cells](https://reference.aspose.com/cells/cpp/)) и связывают её.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю книгу?**

Да. Каждая диаграмма хранит свою собственную ссылку. Если они указывают на один и тот же файл, обновление этого файла будет отражено во всех диаграммах при следующей загрузке данных.