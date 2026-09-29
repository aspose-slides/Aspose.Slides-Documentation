---
title: Управление сериями данных диаграмм в презентациях на C++
linktitle: Серии данных
type: docs
url: /ru/cpp/chart-series/
keywords:
- серии диаграмм
- перекрытие серий
- цвет серии
- цвет категории
- имя серии
- точка данных
- промежуток между сериями
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как управлять сериями диаграмм, точками данных, ячейками рабочей книги, форматированием, перекрытием, шириной промежутка и отрицательными значениями в презентациях с C++."
---
## **Обзор**

Диаграмма хранит свои построенные данные в рабочей книге данных диаграммы. [IChartSeries](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartseries/) представляет один набор связанных значений, и каждый [IChartDataPoint](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatapoint/) в серии ссылается на одну или несколько ячеек рабочей книги. Объекты [IChartCategory](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartcategory/) предоставляют подписи или группирующие значения, общие для серий. Поэтому имя серии, категории и значения точек соединены с объектами [IChartDataCell](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatacell/), а не хранятся только как отображаемый текст.

Для типичной диаграммы категорий рабочая книга по умолчанию использует строку 0 для имён серий, столбец 0 для имён категорий и остальные ячейки для значений серий. Индексы листа, строки и столбца, передаваемые в [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdataworkbook/getcell/), нумеруются с нуля. Такой макет удобен, когда вы создаёте диаграмму с данными по умолчанию, но не следует предполагать, что каждая существующая диаграмма использует его. Для загруженной презентации проверьте ячейки, на которые ссылаются серии, категории и точки данных, перед изменением значений рабочей книги.

Настройки диаграммы имеют три разных уровня:

- Настройки уровня серии, такие как [IChartSeries::get_Format](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartseries/get_format/), задают внешний вид по умолчанию для всех точек в одной серии.
- Настройки отдельной точки, такие как [IChartDataPoint::get_Format](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatapoint/get_format/), переопределяют внешний вид серии для одной точки.
- Настройки группы применяются к совместимым сериям, принадлежащим одному [IChartSeriesGroup](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartseriesgroup/). Доступ к группе осуществляется через [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/), когда необходимо задать параметры, такие как перекрытие или ширина промежутка.

Когда не задано явное заполнение точки или серии, стиль и тема диаграммы определяют автоматический вид. Если присутствует как форматирование серии, так и точки, приоритет имеет форматирование точки.

![диаграмма-рядов-powerpoint](chart-series-powerpoint.png)

## **Установка перекрытия серий диаграммы**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartseries/get_overlap/) сообщает, насколько столбцы или полосы перекрываются в 2D‑диаграмме, от ‑100 до 100 процентов. Это только чтение проекции настройки у родительской группы серий. Вызовите [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) для обновления всех совместимых серий в этой группе. Эта опция применяется к типам диаграмм, отображающих сгруппированные столбцы или полосы; она не влияет на несвязанные группы серий в комбинированной диаграмме.

Следующий пример задаёт перекрытие для группы, содержащей первую серию:

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int8_t overlapPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

// Новая диаграмма содержит образцы серий, категорий и значений.
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Перекрытие серий](series_overlap.png)

## **Изменение цвета заливки серии**

Используйте [IChartSeries::get_Format](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartseries/get_format/) для задания заливки по умолчанию для всей серии. Если у точки уже задана явная заливка, её настройка [IChartDataPoint::get_Format](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatapoint/get_format/) переопределит заливку серии для этой точки.

Следующий пример применяет сплошную синюю заливку к первой серии:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesColor = Color::get_Blue();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);

presentation->Save(u"series_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Цвет серии](series_color.png)

## **Изменение имени серии**

Имя серии хранится в рабочей книге данных диаграммы и обычно отображается в легенде. В рабочей книге по умолчанию для сгруппированной столбчатой диаграммы ячейка B1 находится в строке 0, столбце 1 и содержит имя первой серии. Именованные константы в следующем примере делают эту структуру явной:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto seriesNameCell = workbook->GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Вы также можете обновить ячейку, уже используемую [IChartSeries::get_Name](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartseries/get_name/). Такой подход избегает предположений о конкретных строке и столбце в существующей диаграмме:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCellCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesNameCells = series->get_Name()->get_AsCells();
auto seriesNameCell = seriesNameCells->idx_get(firstNameCellIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Имя серии](series_name.png)

## **Получение автоматического цвета заливки серии**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) возвращает цвет, вычисленный из индекса серии и стиля диаграммы. Это цвет, используемый, когда заливка серии не определена явно. Вызов метода лишь читает вычисленный цвет; он не назначает новую заливку.

Следующий пример выводит автоматический цвет каждой серии по умолчанию:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Presentation;
using System::Console;
using System::String;

const int firstSlideIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
const int seriesCount = seriesCollection->get_Count();
for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    auto series = seriesCollection->idx_get(seriesIndex);
    auto automaticColor = series->GetAutomaticSeriesColor();
    auto colorName = automaticColor.get_Name();
    auto outputLine = String::Format(u"Series {0}: {1}", seriesIndex, colorName);
    Console::WriteLine(outputLine);
}

presentation->Dispose();
```

Пример вывода для стиля диаграммы по умолчанию:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Точные цвета зависят от стиля и темы диаграммы.

## **Установка инверсии цвета заливки для серии диаграммы**

Для столбчатых, колонных и пузырьковых серий [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) может отображать отрицательные значения другой заливкой. Задайте обычную заливку серии сплошной, включите инверсию и укажите цвет отрицательных значений через [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Отрицательные числа в рабочей книге остаются без изменений; меняется только их цвет отображения.

Следующий пример заменяет данные диаграммы по умолчанию одной серией. Строка 0 листа содержит имя серии, столбец 0 – имена категорий, столбец 1 – значения:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;
const int categoryCount = 3;

const String categoryNames[] = {u"Category 1", u"Category 2", u"Category 3"};
const int seriesValues[] = {-20, 50, -30};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

auto seriesCollection = chartData->get_Series();
seriesCollection->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Series 1");
auto seriesNameCell = workbook->GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, seriesName);
auto chartType = chart->get_Type();
auto series = seriesCollection->Add(seriesNameCell, chartType);

for (int categoryIndex = 0; categoryIndex < categoryCount; categoryIndex++)
{
    const int dataRowIndex = firstDataRowIndex + categoryIndex;
    auto categoryName = categoryNames[categoryIndex];
    const int seriesValue = seriesValues[categoryIndex];

    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);

    auto boxedSeriesValue = ObjectExt::Box<int>(seriesValue);
    auto valueCell = workbook->GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, boxedSeriesValue);
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->set_InvertIfNegative(true);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);

presentation->Save(u"inverted_solid_fill_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Инвертированный сплошной цвет заливки](inverted_solid_fill_color.png)

Инверсию можно включить для отдельной точки через [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). В следующем примере инверсия отключена для серии и включена только для выбранной точки. Точке также присвоено отрицательное значение, чтобы эффект был виден:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);
series->set_InvertIfNegative(false);

auto dataPoint = series->get_DataPoint(targetDataPointIndex);
auto boxedNegativeValue = ObjectExt::Box<int>(negativeValue);
dataPoint->get_YValue()->get_AsCell()->set_Value(boxedNegativeValue);
dataPoint->set_InvertIfNegative(true);

presentation->Save(u"data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Очистка конкретного значения точки данных**

Чтобы сделать одну точку пустой, не удаляя остальные, задайте её ячейку в рабочей книге `nullptr`. Для столбчатой диаграммы построенное значение доступно через [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/). Точка остаётся на той же позиции категории, но диаграмма рассматривает её значение как пустое в соответствии с настройками отображения пустых значений.

Следующий пример очищает только вторую точку в первой серии:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto dataPoint = series->get_DataPoint(targetDataPointIndex);
dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);

presentation->Save(u"clear_data_point_value.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Точечные диаграммы используют отдельные X‑ и Y‑ячейки, а пузырьковые диаграммы также используют ячейку размера. Очищайте только ту ячейку, которая представляет значение, которое вы хотите удалить. Не вызывайте [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) если хотите оставить остальные точки, поскольку этот метод удаляет все точки из коллекции.

## **Управление отображением пустых ячеек**

Скрытые ячейки, содержащие значения, — отдельный случай от пустых ячеек. Чтобы включать или исключать данные из скрытых строк и столбцов листа, смотрите [Include Data from Hidden Rows and Columns](/slides/ru/cpp/chart-workbook/#include-data-from-hidden-rows-and-columns).

Пустая ячейка рабочей книги представляет отсутствие данных; ячейка, содержащая `0`, представляет известное числовое значение. Вызовите [IChartDataCell::set_Value](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatacell/set_value/) с `nullptr`, чтобы сделать ячейку пустой. Числовой ноль остаётся нулём независимо от настройки отображения пустых ячеек.

Используйте [IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichart/set_displayblanksas/) для выбора способа отображения пустых ячеек. Эта настройка применяется ко всей диаграмме. Она изменяет способ построения пустот, не заполняя пустую ячейку нулём или интерполированным значением.

Следующий автономный пример создаёт линейную диаграмму с одной серией, очищает значение для 3‑го дня и сохраняет одну и ту же диаграмму в каждом режиме. Входной файл не требуется. [IChartDataWorkbook](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdataworkbook/) использует лист 0, столбец 0 для подписей категорий и столбец 1 для значений; строка 0 хранит имя серии. Финальные данные: `10, 20, empty, 30, 40`.

```cpp
#include <array>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DisplayBlanksAsType.h>
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
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using System::ObjectExt;
using System::String;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 40.0f, 40.0f, 640.0f, 400.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Measurements");
auto seriesNameCell = workbook->GetCell(0, 0, 1, seriesName);
auto series = chartData->get_Series()->Add(seriesNameCell, chart->get_Type());
auto values = std::array<int, 5>{10, 20, 25, 30, 40};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = String::Format(u"Day {0}", i + 1);
    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);
    auto boxedValue = ObjectExt::Box<int>(values[i]);
    auto valueCell = workbook->GetCell(0, i + 1, 1, boxedValue);
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// Оставить 3‑й день действительно пустым, при этом сохранить его категорию и точку данных.
workbook->GetCell(0, 3, 1)->set_Value(nullptr);

auto modes = std::array<DisplayBlanksAsType, 3>{DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span};
for (auto mode : modes)
{
    chart->set_DisplayBlanksAs(mode);
    auto outputPath = String::Format(u"empty_cells_{0}.pptx", mode);
    presentation->Save(outputPath, SaveFormat::Pptx);
}

presentation->Dispose();
```

Каждый файл вывода сохраняет режим, выбранный перед сохранением: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` и `empty_cells_Span.pptx`. Чтобы сохранить только одну версию, задайте нужный режим и сохраните презентацию один раз вместо перебора режимов.

Сравнение ниже показывает одинаковые данные во всех трёх файлах. 3‑й день пуст в рабочей книге во всех случаях:

![Линейные диаграммы с одинаковыми данными: Gap разрывает линию в 3‑м дне, Zero опускает линию до нуля, а Span соединяет 2‑й и 4‑й день.](display_blanks_as.png)

Видимый эффект зависит от типа диаграммы. Линейная диаграмма удобно сравнивать все три режима. Бар‑ и столбчатые диаграммы не имеют линии, соединяющей пропущенную категорию, поэтому `Span` не может создать соединительный сегмент, показанный выше; отсутствующий столбец и столбец нулевой высоты могут также выглядеть одинаково. Аналогично, точечная диаграмма только с маркерами не имеет соединительной линии. Не ожидайте трёх различных результатов для каждого типа диаграммы; проверьте вывод для используемого типа.

## **Установка ширины промежутка между сериями**

Ширина промежутка — это расстояние между соседними кластерами столбцов или полос, выраженное в процентах от их ширины. Как и перекрытие, она относится к родительской группе серий, а не к отдельной серии. Вызовите [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) один раз для группы. Большее значение создаёт больше пространства между кластерами; меньшее — делает их плотнее.

Следующий пример меняет ширину промежутка и сохраняет только финальную презентацию:

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const uint16_t gapWidthPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_GapWidth(gapWidthPercent);

presentation->Save(u"gap_width_30.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Ширина промежутка](gap_width.png)

## **FAQ**

**Какие типы диаграмм поддерживают серии данных?**

Все типы диаграмм, представленные перечислением [ChartType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/charttype/), используют данные диаграммы, но их серии не всегда имеют одинаковую структуру значений или настройки. Например, диаграммы категорий используют категории и значения, точечные диаграммы используют X и Y, а пузырьковые добавляют размер пузыря. Используйте метод создания точек данных, соответствующий типу серии. Параметры, такие как перекрытие и ширина промежутка, применимы только к совместимым группам столбцов или полос.

**Что такое группа серий диаграммы?**

[IChartSeriesGroup](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartseriesgroup/) содержит совместимые серии, которые разделяют настройки построения на уровне группы. Комбинированная диаграмма может содержать более одной группы, поэтому изменение группы, полученной через одну серию, не обязательно меняет все серии в диаграмме.

**Создаётся ли в новой диаграмме набор данных по умолчанию?**

Да. По умолчанию [IShapeCollection::AddChart](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/addchart/) создаёт образцы серий, категорий и значений. Вы можете изменить эти ячейки или очистить коллекции серий и категорий перед добавлением полностью пользовательского набора данных. Есть перегрузка, позволяющая создать диаграмму без данных по умолчанию.

**Как объекты диаграммы связаны с ячейками рабочей книги?**

Имена серий, подписи категорий и значения точек данных ссылаются на ячейки в [IChartDataWorkbook](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdataworkbook/). Изменение ссылки ячейки обновляет соответствующий элемент диаграммы. При построении пользовательских данных следите, чтобы строки категорий и строки значений серий были согласованы, чтобы каждая точка отображалась под нужной категорией.

**Как очистить одну точку, а не всю серию?**

Установите соответствующую ячейку значения в `nullptr`, чтобы точка сохранила позицию категории как пустую. Вызывайте [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) только тогда, когда нужно удалить все точки из серии. Если вы также удаляете категории, обновите все серии, чтобы их значения оставались согласованы с коллекцией категорий.

**Как отображаются пустые точки?**

Результат зависит от типа диаграммы и [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichart/get_displayblanksas/). Поддерживаемые диаграммы могут отображать пустоты как разрывы, как нулевые значения или соединяя соседние точки. Выберите настройку, соответствующую смыслу отсутствующих данных в вашей презентации. Смотрите раздел [Управление отображением пустых ячеек](#control-the-display-of-empty-cells) для полного примера и визуального сравнения.

**Как форматируются отрицательные значения?**

Для поддерживаемых столбчатых, колонных и пузырьковых серий вызовите [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) и задайте цвет через [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Поведение отдельной точки можно переопределить с помощью [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). Эти методы влияют на форматирование, а не на хранимые числовые значения.

**Какой формат выигрывает, если и серия, и точка имеют настройки?**

Явное форматирование отдельной точки имеет приоритет для этой точки. Другие точки продолжают использовать явный формат серии или, если он не определён, автоматический стиль и тему диаграммы. Настройки группы, такие как перекрытие и ширина промежутка, управляют расположением и не являются переопределением форматирования точек.

**Есть ли ограничение на количество серий в диаграмме?**

Aspose.Slides не накладывает отдельного фиксированного ограничения на количество серий. На практике ограничивают ограничения формата файла презентации, доступная память, время рендеринга и читаемость диаграммы.

**Что изменить, если столбцы слишком близко или слишком далеко друг от друга?**

Вызовите [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) у соответствующей родительской группы серий. Увеличьте значение, чтобы расширить пространство между кластерами, или уменьшите его, чтобы сблизить кластеры.