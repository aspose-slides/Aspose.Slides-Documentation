---
title: 在 C++ 簡報中管理圖表資料系列
linktitle: 資料系列
type: docs
url: /zh-hant/cpp/chart-series/
keywords:
- 圖表系列
- 系列重疊
- 系列顏色
- 類別顏色
- 系列名稱
- 資料點
- 系列間距
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何在簡報中使用 C++ 管理圖表系列、資料點、工作簿儲存格、格式設定、重疊、間距寬度與負值。"
---
## **概觀**

圖表將其繪製的資料儲存在圖表資料工作簿中。 [IChartSeries](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseries/) 代表一組相關的值，而系列中的每個 [IChartDataPoint](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapoint/) 都對應到一個或多個工作簿儲存格。 [IChartCategory](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartcategory/) 物件提供系列共用的標籤或分組值。系列名稱、類別與點的值因此連結到 [IChartDataCell](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatacell/) 物件，而不只是儲存為顯示文字。

對於一般的類別圖表，預設工作簿使用第 0 列放置系列名稱，第 0 行放置類別名稱，其餘儲存格放置系列值。傳遞給 [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) 的工作表、列與欄索引都是零基的。此布局在使用預設資料建立圖表時很便利，但請勿假設每個既有圖表都採用此布局。對於已載入的簡報，在變更工作簿值之前，請先檢查系列、類別與資料點所參照的儲存格。

圖表設定有三種不同的作用範圍：

- 系列層級設定，例如 [IChartSeries::get_Format](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseries/get_format/)，提供整個系列中所有點的預設外觀。
- 資料點層級設定，例如 [IChartDataPoint::get_Format](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapoint/get_format/)，會覆寫該點的系列外觀。
- 群組設定套用於屬於相同 [IChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseriesgroup/) 的相容系列。當需要設定重疊或間距寬度等選項時，請透過 [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) 取得群組。

當未明確設定點或系列的填色時，圖表樣式與佈景主題會決定自動外觀。當同時存在系列與點的格式設定時，點的格式會優先套用於該點。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **設定圖表系列的重疊度**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseries/get_overlap/) 回報 2D 圖表中長條或柱狀的重疊程度，範圍從 -100% 到 100%。它是父系列群組設定的唯讀投影。呼叫 [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) 可更新該群組中所有相容的系列。此選項適用於顯示分組長條或柱狀的圖表類型；對組合圖表中不相關的系列群組不會產生影響。

以下範例設定包含第一個系列的群組的重疊度：

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

// 新圖表包含示範系列、類別和數值。
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The series overlap](series_overlap.png)

## **變更系列的填色**

使用 [IChartSeries::get_Format](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseries/get_format/) 可為整個系列設定預設填色。如果某個點已明確設定填色，則其 [IChartDataPoint::get_Format](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapoint/get_format/) 會覆寫該系列的填色。

以下範例將第一個系列的填色設為實心藍色：

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

結果：

![The color of the series](series_color.png)

## **變更系列名稱**

系列名稱儲存在圖表資料工作簿中，通常會顯示在圖例中。在預設為叢集柱狀圖所建立的工作簿中，儲存格 B1 位於第 0 列第 1 行，內含第一個系列的名稱。以下範例中的具名常數明確說明了此結構：

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

您也可以直接更新 [IChartSeries::get_Name](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseries/get_name/) 所參照的儲存格。此作法避免在既有圖表中假設特定的列與行：

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

結果：

![The series name](series_name.png)

## **取得自動系列填色**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) 會回傳依系列索引與圖表樣式計算出的顏色。這是當系列填色未明確定義時所使用的顏色。呼叫此方法僅會讀取計算出的顏色；並不會指派新的填色。

以下範例列印每個預設系列的自動顏色：

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

預設圖表樣式的範例輸出：

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

實際顏色取決於圖表樣式與佈景主題。

## **為圖表系列設定反轉填色**

對於長條、柱狀與氣泡系列，[IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) 可以在顯示負值時使用不同的填色。將系列的常規填色設為實心、啟用反轉，並透過 [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) 指定負值的顏色。負數在工作簿中保持不變；僅其顯示顏色會改變。

以下範例以單一系列取代預設圖表資料。工作表第 0 列放置系列名稱，第 0 行放置類別名稱，第 1 列放置數值：

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

結果：

![The inverted solid fill color](inverted_solid_fill_color.png)

您也可以透過 [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) 為單一資料點啟用反轉。在下列範例中，系列的反轉功能被關閉，僅為選取的點啟用，且該點同時被指派負值以顯示效果：

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

## **清除特定資料點的值**

若要讓某一點變為空白而不移除其他點，請將其對應的工作簿儲存格設為 `nullptr`。對於柱狀圖，繪製的值可透過 [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/) 取得。資料點仍保留在相同的類別位置，但圖表會依據空白值設定將其視為空白。

以下範例僅清除第一個系列中的第二個點：

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

散佈圖使用獨立的 X 與 Y 儲存格，氣泡圖亦使用大小儲存格。僅清除代表您想移除之數值的儲存格。若想保留其他點，請勿呼叫 [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapointcollection/clear/)，因為該方法會移除集合中的所有資料點。

## **設定系列的間距寬度**

間距寬度是相鄰長條或柱狀叢集之間的空間，以長條或柱狀寬度的百分比表示。與重疊度相同，它屬於父系列群組，而非單一系列。對該群組呼叫一次 [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) 即可。較大的數值會在叢集之間產生更大的空間，較小的數值則使叢集更緊密。

以下範例變更間距寬度，並僅保存最終的簡報：

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

結果：

![The gap width](gap_width.png)

## **常見問題集**

**哪些圖表類型支援資料系列？**

所有由 [ChartType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/charttype/) 列舉表示的圖表類型皆使用圖表資料，但其系列的值結構或設定並不完全相同。例如，類別圖表使用類別與值，散佈圖使用 X 與 Y 值，氣泡圖則另加氣泡大小。請使用與系列類型相符的資料點建立方法。重疊度與間距寬度等選項僅套用於相容的長條或柱狀群組。

**什麼是圖表系列群組？**

[IChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseriesgroup/) 包含共享群組層級繪圖設定的相容系列。組合圖表可以包含多個群組，因此透過其中一個系列取得的群組設定不一定會影響圖表中的所有系列。

**新建立的圖表會包含預設資料嗎？**

會。預設情況下，[IShapeCollection::AddChart](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/addchart/) 會建立示範系列、類別與值。您可以編輯這些儲存格，或在加入完全自訂的資料集之前先清除系列和類別集合。亦可使用其他重載來建立不含預設資料的圖表。

**圖表物件如何與工作簿儲存格連結？**

系列名稱、類別標籤與資料點值皆參照 [IChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdataworkbook/) 中的儲存格。變更被參照的儲存格會更新相應的圖表元素。建立自訂資料時，請保持類別列與系列值列的對齊，以確保每個點都繪製於正確的類別下。

**如何只清除單一點而不是整個系列？**

將相關的值儲存格設為 `nullptr`，即可保留該點的類別位置但使其成為空白點。僅在需要移除該系列所有點時才呼叫 [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapointcollection/clear/)。若同時移除類別，請更新所有系列，使其值仍與類別集合保持對齊。

**空白點會如何顯示？**

顯示結果取決於圖表類型與 [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichart/get_displayblanksas/)。支援的圖表可以將空白顯示為間隙、零值，或連接相鄰點。請選擇最符合簡報中遺失資料意涵的設定。

**負值會如何格式化？**

對於受支援的長條、柱狀與氣泡系列，呼叫 [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) 並透過 [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) 設定顏色。您也可使用 [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) 為個別資料點覆寫此行為。這些方法僅影響格式，並不會改變儲存的數值。

**當系列與資料點同時有格式設定時，哪個生效？**

明確的資料點格式會優先於系列格式，僅對該點生效。其他點則繼續使用系列的明確格式，或在系列未定義格式時使用自動圖表樣式與佈景主題。群組設定（如重疊度與間距寬度）屬於版面配置，並非資料點層級的格式覆寫。

**圖表可以包含多少個系列？是否有限制？**

Aspose.Slides 本身沒有設定固定的系列數上限。實務上，簡報檔案的限制、可用記憶體、渲染時間以及圖表的可讀性會決定實際可接受的上限。

**當柱狀圖的間距過近或過遠時，該怎麼調整？**

對相應的父系列群組呼叫 [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/)。將數值調高可擴大叢集之間的間距，調低則可使叢集更靠近。