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
description: "了解如何在使用 C++ 的簡報中管理圖表系列、資料點、工作簿儲存格、格式設定、重疊、間距寬度以及負值。"
---
## **概觀**

圖表在圖表資料工作簿中儲存其繪製的資料。 [IChartSeries](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseries/) 代表一組相關值，且系列中的每個 [IChartDataPoint](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapoint/) 參照一個或多個工作簿儲存格。 [IChartCategory](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartcategory/) 物件提供系列共用的標籤或分組值。因此，系列名稱、類別與資料點值會連結到 [IChartDataCell](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatacell/) 物件，而不僅僅以顯示文字儲存。

對於一般的類別圖表，預設工作簿使用第 0 列儲存系列名稱，第 0 欄儲存類別名稱，其餘儲存格則存放系列數值。傳遞給 [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) 的工作表、列與欄索引皆為零基礎。此佈局在建立預設資料的圖表時很有用，但不要假設每個現有圖表都使用此佈局。對於已載入的簡報，請先檢查系列、類別與資料點所參照的儲存格，再變更工作簿的值。

圖表設定有三種不同的範圍：

- 系列層級設定，例如 [IChartSeries::get_Format](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseries/get_format/)，提供整個系列所有資料點的預設外觀。
- 資料點層級設定，例如 [IChartDataPoint::get_Format](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapoint/get_format/)，會覆寫該資料點的系列外觀。
- 群組設定套用於屬於相同 [IChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseriesgroup/) 的相容系列。當您需要設定重疊或間距寬度等選項時，請透過 [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) 取得群組。

若未明確設定資料點或系列的填色，圖表樣式與主題會決定自動外觀。當系列與資料點同時設定格式時，資料點格式會優先套用於該資料點。

![圖表系列 PowerPoint](chart-series-powerpoint.png)

## **設定圖表系列重疊**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseries/get_overlap/) 回報 2D 圖表中長條或柱狀的重疊比例，範圍為 -100 到 100%。它是父系列群組設定的唯讀投射。呼叫 [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) 可更新該群組中所有相容系列。此選項適用於顯示分組長條或柱狀的圖表類型；不會影響組合圖表中不相關的系列群組。

以下範例設定包含第一個系列的群組的重疊：

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

// 新圖表包含範例系列、類別和數值。
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![系列重疊](series_overlap.png)

## **變更系列填色**

使用 [IChartSeries::get_Format](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseries/get_format/) 來設定整個系列的預設填色。如果資料點已明確設定填色，其 [IChartDataPoint::get_Format](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapoint/get_format/) 會覆寫該資料點的系列填色。

以下範例將第一個系列的填色設定為實心藍色：

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

![系列顏色](series_color.png)

## **變更系列名稱**

系列名稱儲存在圖表資料工作簿中，通常會顯示在圖例中。對於分群柱狀圖的預設工作簿，儲存格 B1 位於第 0 列第 1 欄，包含第一個系列的名稱。下列範例中的具名常數明確說明了這個結構：

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

您也可以直接更新 [IChartSeries::get_Name](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseries/get_name/) 已參照的儲存格。此方式避免在現有圖表中假設特定的列與欄：

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

![系列名稱](series_name.png)

## **取得自動系列填色**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) 會回傳根據系列索引與圖表樣式計算出的顏色。這是未明確定義系列填色時使用的顏色。呼叫此方法會讀取計算出的顏色；不會指派新的填色。

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

實際顏色取決於圖表樣式與主題。

## **為圖表系列設定反轉填色**

對於長條、柱狀與氣泡系列，[IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) 可在負值時使用不同的填色。先將系列的常規填色設定為實心，啟用反轉，然後透過 [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) 指定負值顏色。負數在工作簿中保持不變；只有顯示的顏色會改變。

以下範例以單一系列取代預設圖表資料。工作表第 0 列包含系列名稱，第 0 欄包含類別名稱，第 1 欄包含數值：

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

![反轉實心填色](inverted_solid_fill_color.png)

您也可以透過 [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) 為單一資料點啟用反轉。以下範例在系列中停用反轉，僅對選取的資料點啟用，且該資料點被指派負值以顯示效果：

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

若要讓單一資料點變為空白而不移除其他點，請將其對應的工作簿儲存格設定為 `nullptr`。對於柱狀圖，繪製的值可透過 [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/) 取得。資料點仍保留在相同的類別位置，但圖表會根據空白值設定將其視為空白。

以下範例僅清除第一個系列的第二個資料點：

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

散佈圖使用分開的 X 與 Y 儲存格，氣泡圖亦使用尺寸儲存格。僅清除您欲移除之值對應的儲存格。若想保留其他點，請勿呼叫 [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapointcollection/clear/)，因為該方法會移除集合中的全部資料點。

## **控制空白儲存格的顯示方式**

隱藏且包含值的儲存格與真正的空白儲存格屬於不同情況。若要包含或排除來自隱藏工作表列與欄的資料，請參閱 [Include Data from Hidden Rows and Columns](/slides/zh-hant/cpp/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空白工作簿儲存格代表遺失的資料；儲存格內的 `0` 代表已知的數值。呼叫 [IChartDataCell::set_Value](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatacell/set_value/) 並傳入 `nullptr` 可使儲存格變為空白。數值零不會因空白儲存格設定而改變。

使用 [IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichart/set_displayblanksas/) 來選擇圖表如何顯示空白儲存格。此設定套用於整個圖表，會改變空白的繪製方式，而不會以零或插值值填入空白工作簿儲存格。

以下獨立範例建立一個具有單一系列的折線圖，清除第 3 天的值，並以每種模式儲存相同的圖表。此範例不需要輸入檔案。[IChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdataworkbook/) 使用工作表 0，第 0 欄作為類別標籤，第 1 欄作為數值；第 0 列保存系列名稱。最終資料為 `10, 20, empty, 30, 40`。

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

// 將第 3 天真正留空，同時保留其類別和資料點。
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

每個輸出檔案在儲存前會記錄使用的模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx` 與 `empty_cells_Span.pptx`。若只需一個版本，請設定所需模式後僅儲存一次簡報，而非對所有模式迭代。

下表比較了三個檔案中相同資料的呈現。第 3 天在工作簿中皆為空白：

![折線圖的空白顯示方式：Gap 在第 3 天斷開線段，Zero 使線段下降至零，Span 連接第 2 天與第 4 天。](display_blanks_as.png)

可見效果取決於圖表類型。折線圖可以清楚比較三種模式。長條圖與柱狀圖沒有連接線可跨過缺失的類別，因此 `Span` 無法產生上圖所示的連接段；缺少的柱與零高度的柱看起來也很相似。散佈圖若僅有標記亦不會有連接線。請勿期望每種圖表類型都會產生三個不同結果；請檢查您使用的圖表類型的輸出。

## **設定系列間距寬度**

間距寬度是相鄰長條或柱狀叢集之間的空間，以長條或柱狀寬度的百分比表示。與重疊類似，它屬於父系列群組，而非單一系列。對該群組呼叫一次 [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/)。較大的值會在叢集間創造更多空間，較小的值則使叢集更密集。

以下範例變更間距寬度，並僅儲存最終的簡報：

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

![間距寬度](gap_width.png)

## **常見問題集**

**哪種圖表類型支援資料系列？**

所有由 [ChartType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/charttype/) 列舉的圖表類型皆使用圖表資料，但它們的系列並不具備相同的值結構或設定。例如，類別圖表使用類別與數值，散佈圖使用 X 與 Y 值，氣泡圖則額外使用氣泡大小。請使用符合系列類型的資料點建立方法。諸如重疊與間距寬度之類的選項僅適用於相容的長條或柱狀群組。

**什麼是圖表系列群組？**

[IChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseriesgroup/) 包含共享群組層級繪製設定的相容系列。組合圖表可包含多個群組，因此透過單一系列取得的群組設定不一定會影響圖表中的所有系列。

**新建立的圖表會包含預設資料嗎？**

會。預設情況下，[IShapeCollection::AddChart](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/addchart/) 會建立示範系列、類別與數值。您可以編輯這些儲存格，或在加入完全自訂的資料集之前先清除系列與類別集合。也有重載方式可建立不含預設資料的圖表。

**圖表物件如何與工作簿儲存格連結？**

系列名稱、類別標籤與資料點數值皆參照 [IChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdataworkbook/) 中的儲存格。變更參照的儲存格會更新相應的圖表元素。建立自訂資料時，請保持類別列與系列值列對齊，以確保每個資料點繪製於正確的類別下。

**如何只清除單一資料點而不是整個系列？**

將相關的值儲存格設為 `nullptr`，以保留該資料點的類別位置作為空白點。只有在您想移除該系列所有資料點時才呼叫 [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapointcollection/clear/)。若同時移除類別，請更新所有系列，使其值仍與類別集合保持對齊。

**空白資料點會如何顯示？**

結果取決於圖表類型與 [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichart/get_displayblanksas/)。支援的圖表可將空白顯示為間隙、零值或連接相鄰點。請選擇與您簡報中遺失資料意涵相符的設定。完整範例與視覺比較請參閱 [控制空白儲存格的顯示方式](#control-the-display-of-empty-cells)。

**負值會如何格式化？**

對於支援的長條、柱狀與氣泡系列，呼叫 [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) 並透過 [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) 設定顏色。您亦可使用 [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) 為單一資料點覆寫此行為。這些方法僅影響格式，並不改變儲存的數值。

**當系列與資料點同時設定格式時，哪個會生效？**

明確的資料點格式會優先套用於該資料點。其他資料點會繼續使用明確的系列格式，若系列格式未定義，則使用自動圖表樣式與主題。群組設定（例如重疊與間距寬度）屬於版面配置，並不會覆寫資料點層級的格式。

**圖表能容納的系列數量是否有限制？**

Aspose.Slides 並未設定固定的系列數量上限。實務上，簡報檔案的限制、可用記憶體、渲染時間與圖表可讀性會決定實用的上限。

**當柱狀圖的柱子過於接近或過於分散時，我該如何調整？**

對適當的父系列群組呼叫 [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/)。增大數值會擴寬叢集之間的間距，減小則使叢集更靠近。