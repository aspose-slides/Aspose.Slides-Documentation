---
title: 在 C++ 演示文稿中管理图表数据系列
linktitle: 数据系列
type: docs
url: /zh/cpp/chart-series/
keywords:
- 图表系列
- 系列重叠
- 系列颜色
- 类别颜色
- 系列名称
- 数据点
- 系列间隙
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何在 C++ 演示文稿中管理图表系列、数据点、工作簿单元格、格式设置、重叠、间隙宽度和负值。"
---
## **概述**

图表将其绘制的数据存储在图表数据工作簿中。一个[IChartSeries](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartseries/)表示一组相关的数值，系列中的每个[IChartDataPoint](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatapoint/)对应一个或多个工作簿单元格。[IChartCategory](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartcategory/)对象提供系列共享的标签或分组值。因此，系列名称、类别和点值都连接到[IChartDataCell](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatacell/)对象，而不是仅以显示文本的形式存储。

对于典型的类别图，默认工作簿使用第 0 行存放系列名称，第 0 列存放类别名称，其余单元格存放系列数值。传递给[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdataworkbook/getcell/)的工作表、行和列索引均为从零开始。这种布局在创建带有默认数据的图表时很有用，但不要假设每个现有图表都使用它。对于已加载的演示文稿，在更改工作簿值之前，请检查系列、类别和数据点引用的单元格。

图表设置有三种不同的作用域：

- 系列级别设置，例如[IChartSeries::get_Format](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartseries/get_format/)，为整个系列的所有点提供默认外观。
- 数据点级别设置，例如[IChartDataPoint::get_Format](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatapoint/get_format/)，覆盖该点的系列外观。
- 组设置适用于属于同一[IChartSeriesGroup](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartseriesgroup/)的兼容系列。当需要设置如重叠或间隙宽度等选项时，通过[IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/)访问该组。

当未显式设置点或系列填充时，图表样式和主题决定自动外观。当同时存在系列和点的格式设置时，点的格式设置优先于该点的系列格式。

![图表系列-PowerPoint](chart-series-powerpoint.png)

## **设置图表系列重叠**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartseries/get_overlap/)报告 2D 图表中条形或柱形的重叠程度，范围从 -100% 到 100%。它是对父系列组中该设置的只读投影。调用[IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/)可更新该组中所有兼容系列。此选项适用于显示分组条形或柱形的图表类型；对组合图中不相关的系列组没有影响。

下面的示例为包含第一个系列的组设置重叠：

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

// 新图表包含示例系列、类别和数值。
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果：

![系列重叠](series_overlap.png)

## **更改系列填充颜色**

使用[IChartSeries::get_Format](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartseries/get_format/)为整个系列设置默认填充。如果某个点已经具有显式填充，其[IChartDataPoint::get_Format](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatapoint/get_format/)设置将覆盖该点的系列填充。

下面的示例为第一个系列应用纯蓝色填充：

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

结果：

![系列颜色](series_color.png)

## **更改系列名称**

系列名称存储在图表数据工作簿中，通常显示在图例中。在为聚类柱形图创建的默认工作簿中，单元格 B1（第 0 行，第 1 列）包含第一个系列的名称。下面示例中的命名常量明确了该结构：

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

您也可以更新[IChartSeries::get_Name](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartseries/get_name/)已经引用的单元格。此方式避免在现有图表中假设特定的行列：

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

结果：

![系列名称](series_name.png)

## **获取自动系列填充颜色**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/)返回根据系列索引和图表样式计算的颜色。这是系列填充未显式定义时使用的颜色。调用该方法只读取计算得到的颜色，不会分配新的填充。

下面的示例打印每个默认系列的自动颜色：

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

默认图表样式的示例输出：

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

具体颜色取决于图表样式和主题。

## **为图表系列设置负值反转填充颜色**

对于条形、柱形和气泡系列，[IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/)可以在负值时使用不同的填充。将常规系列填充设为实色，启用反转，并通过[IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/)指定负值颜色。负数在工作簿中保持不变，只有显示颜色会改变。

下面的示例将默认图表数据替换为单一系列。工作表第 0 行包含系列名称，第 0 列包含类别名称，第 1 列包含数值：

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

结果：

![反转实色填充颜色](inverted_solid_fill_color.png)

您可以通过[IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/)为单个点启用反转。在下面的示例中，系列的反转被禁用，仅为选定的点启用，并为该点分配负值，以便效果可见：

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

## **清除特定数据点的值**

要使某一点为空而不删除其他点，请将其对应的工作簿单元格设为`nullptr`。对于柱形图，绘制的数值可通过[IChartDataPoint::get_YValue](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/)获取。数据点仍保留在相同的类别位置，但图表会根据空值设置将其视为空白。

下面的示例仅清除第一系列的第二个点：

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

散点图使用单独的 X 和 Y 单元格，气泡图还使用大小单元格。仅清除表示您希望移除的数值的单元格。不要在想保留其他点时调用[IChartDataPointCollection::Clear](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatapointcollection/clear/)，因为该方法会移除集合中的所有数据点。

## **控制空单元格的显示方式**

空工作簿单元格代表缺失数据；包含`0`的单元格代表已知的数值。调用[IChartDataCell::set_Value](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatacell/set_value/)并传入`nullptr`即可使单元格为空。数值零始终保持为零，无论空单元格设置为何。

使用[IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichart/set_displayblanksas/)选择图表如何显示空单元格。此设置适用于整个图表，会改变空白的绘制方式，但不会将空工作簿单元格填充为零或插值。

下面的自包含示例创建一个包含一个系列的折线图，清除第 3 天的值，并以每种模式分别保存同一个图表。无需输入文件。[IChartDataWorkbook](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdataworkbook/)使用工作表 0，第 0 列作为类别标签，第 1 列作为数值；第 0 行保存系列名称。最终数据为`10, 20, empty, 30, 40`。

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

// 将第 3 天真正设为空，同时保留其类别和数据点。
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

每个输出文件在保存前会存储相应的模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`和`empty_cells_Span.pptx`。若只需一种版本，可在保存演示文稿前设置所需模式，而不是遍历所有模式。

下面的比较展示了三个文件中相同的数据。第 3 天在工作簿中始终为空：

![折线图显示相同数据：Gap 在第 3 天断开线段，Zero 将线段降到零，Span 将第 2 天连接到第 4 天。](display_blanks_as.png)

可见效果取决于图表类型。折线图能够直观比较所有三种模式。条形图和柱形图由于缺少跨缺失类别的连线，`Span` 无法产生上图所示的连接段；缺失的柱形和零高度的柱形在视觉上也可能相似。同样，仅有标记的散点图没有连线。不要期望每种图表类型都产生三种不同结果；请检查所使用图表类型的实际输出。

## **设置系列间隙宽度**

间隙宽度是相邻条形或柱形簇之间的间距，以条形或柱形宽度的百分比表示。与重叠类似，它属于父系列组，而非单个系列。对组调用一次[IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/)即可。较大的数值会在簇之间创建更多空间，较小的数值则使它们更紧密。

下面的示例更改间隙宽度并仅保存最终的演示文稿：

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

结果：

![间隙宽度](gap_width.png)

## **常见问题**

**哪些图表类型支持数据系列？**

所有由[ChartType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/charttype/)枚举表示的图表类型都使用图表数据，但它们的系列并非都具有相同的数值结构或设置。例如，类别图使用类别和数值，散点图使用 X 和 Y 值，气泡图还添加气泡大小。使用与系列类型匹配的数据点创建方法。重叠和间隙宽度等选项仅适用于兼容的条形或柱形组。

**什么是图表系列组？**

[IChartSeriesGroup](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartseriesgroup/)包含共享组级绘制设置的兼容系列。组合图可以包含多个组，因此通过某一系列访问的组的更改不一定会影响图表中的所有系列。

**新创建的图表是否包含默认数据？**

是的。默认情况下，[IShapeCollection::AddChart](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishapecollection/addchart/)会创建示例系列、类别和数值。您可以编辑这些单元格，或在添加完全自定义的数据集之前清除系列和类别集合。还有重载可以创建不带默认数据的图表。

**图表对象如何与工作簿单元格关联？**

系列名称、类别标签和数据点数值引用[IChartDataWorkbook](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdataworkbook/)中的单元格。更改引用的单元格会更新相应的图表元素。构建自定义数据时，请保持类别行和系列值行对齐，以便每个点绘制在预期的类别下。

**如何只清除一个点而不是整个系列？**

将相关的值单元格设为`nullptr`，即可保留该点的类别位置为一个空点。仅在希望删除该系列所有点时才调用[IChartDataPointCollection::Clear](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatapointcollection/clear/)。如果同时删除类别，请更新所有系列，使其数值仍与类别集合保持对齐。

**空点如何显示？**

结果取决于图表类型和[IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichart/get_displayblanksas/)。支持的图表可以将空白显示为间隙、零值或通过连接相邻点来显示。选择与演示文稿中缺失数据含义相匹配的设置。请参阅[控制空单元格的显示方式](#control-the-display-of-empty-cells)获取完整示例和可视化比较。

**负值如何格式化？**

对于支持的条形、柱形和气泡系列，调用[IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/)并通过[IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/)设置颜色。您也可以使用[IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/)为单个点覆盖此行为。这些方法影响格式，而不改变存储的数值。

**当系列和点都进行格式化时，哪个生效？**

显式的数据点格式化对该点具有优先权。其他点继续使用显式的系列格式，或在未定义系列格式时使用自动的图表样式和主题。组设置（如重叠和间隙宽度）控制布局，不属于点级别的格式覆盖。

**图表能够包含的系列数量是否有限制？**

Aspose.Slides 并未设置单独的固定系列计数上限。实际上，演示文稿文件的限制、可用内存、渲染时间以及图表的可读性会决定实际可用的上限。

**当柱形间距过近或过远时该怎么办？**

对相应的父系列组调用[IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/)。增大数值可扩大簇之间的间距，减小数值则使簇更紧凑。