---
title: 使用 C++ 管理簡報中的圖表資料標籤
linktitle: 資料標籤
type: docs
url: /zh-hant/cpp/chart-data-label/
keywords:
- 圖表
- 資料標籤
- 資料精度
- 百分比
- 標籤距離
- 標籤位置
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "學習如何在 PowerPoint 簡報中使用 Aspose.Slides for C++ 添加與格式化圖表資料標籤，以打造更具吸引力的投影片。"
---
## **簡介**

資料標籤顯示圖表系列和個別資料點的資訊，協助讀者辨識數值並了解圖表。本文章說明如何格式化數值、顯示百分比、讀取標籤文字、控制超出座標軸最大值的標籤、調整類別軸標籤間距，以及定位圓餅圖標籤。

## **設定圖表資料標籤的資料精度**

使用 [set_NumberFormatOfValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_numberformatofvalues/) 來格式化系列值。此範例建立一個使用預設資料的折線圖，顯示其資料表，並為第一個系列啟用值標籤。格式 `#,##0.00` 會顯示千位分隔符號和兩個小數位，且不會變更底層的值。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 450, 300);
chart->set_HasDataTable(true);

auto series = chart->get_ChartData()->get_Series()->idx_get(0);
series->set_NumberFormatOfValues(u"#,##0.00");
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"PrecisionOfDatalabels_out.pptx", SaveFormat::Pptx);
```

## **將百分比顯示為標籤**

對於堆疊直條圖，將每個值計算為其類別總計的百分比，並將文字指派給 [get_TextFrameForOverriding](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ioverridabletext/get_textframeforoverriding/) 回傳的文字框。本範例使用預設圖表資料，並以 8 點字型顯示保留兩位小數的百分比。總計為零的類別會被跳過，以避免除以零。如果圖表資料變更，需重新計算自訂標籤文字。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Portion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <system/convert.h>
#include <vector>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 20, 20, 400, 400);

auto categoryTotals = std::vector<double>(chart->get_ChartData()->get_Categories()->get_Count(), 0.0);
for (auto k = 0; k < chart->get_ChartData()->get_Categories()->get_Count(); k++)
{
    for (auto i = 0; i < chart->get_ChartData()->get_Series()->get_Count(); i++)
    {
        auto series = chart->get_ChartData()->get_Series()->idx_get(i);
        auto pointValue = Convert::ToDouble(series->get_DataPoint(k)->get_Value()->get_Data());
        categoryTotals[k] += pointValue;
    }
}

for (auto x = 0; x < chart->get_ChartData()->get_Series()->get_Count(); x++)
{
    auto series = chart->get_ChartData()->get_Series()->idx_get(x);
    series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLegendKey(false);

    for (auto j = 0; j < series->get_DataPoints()->get_Count(); j++)
    {
        auto label = series->get_DataPoint(j)->get_Label();
        if (categoryTotals[j] == 0)
        {
            continue;
        }

        auto pointValue = Convert::ToDouble(series->get_DataPoint(j)->get_Value()->get_Data());
        auto dataPointPercent = (pointValue / categoryTotals[j]) * 100;

        auto portion = MakeObject<Portion>();
        portion->set_Text(String::Format(u"{0:F2} %", dataPointPercent));
        portion->get_PortionFormat()->set_FontHeight(8.0f);

        label->get_TextFrameForOverriding()->set_Text(u"");

        auto paragraph = label->get_TextFrameForOverriding()->get_Paragraphs()->idx_get(0);
        paragraph->get_Portions()->Add(portion);

        label->get_DataLabelFormat()->set_ShowValue(true);
        label->get_DataLabelFormat()->set_ShowSeriesName(false);
        label->get_DataLabelFormat()->set_ShowPercentage(false);
        label->get_DataLabelFormat()->set_ShowLegendKey(false);
        label->get_DataLabelFormat()->set_ShowCategoryName(false);
        label->get_DataLabelFormat()->set_ShowBubbleSize(false);
    }
}

presentation->Save(u"DisplayPercentageAsLabels_out.pptx", SaveFormat::Pptx);
```

## **使用圖表資料標籤設定百分號**

當值以分數形式儲存時，使用 [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_numberformat/) 來顯示百分比。將 `false` 傳遞給 [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_isnumberformatlinkedtosource/) 以使標籤格式獨立於來源儲存格。

此範例建立一個 100% 堆疊直條圖，包含四個類別的紅色與藍色系列。每對值加總為 1。標籤格式 `0.0%` 會將 0.30 顯示為 30.0%，而垂直座標軸使用兩位小數。兩個系列的標籤文字皆為白色、10 點字型。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/FillType.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);

chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;
for (auto i = 0; i < 4; i++)
{
    auto categoryCell = workbook->GetCell(worksheetIndex, i + 1, 0, ObjectExt::Box(String::Format(u"Category {0}", i + 1)));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
}

String seriesNames[] = { u"Reds", u"Blues" };
Color seriesColors[] = { Color::get_Red(), Color::get_Blue() };
double values[2][4] = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

for (auto i = 0; i < 2; i++)
{
    auto seriesCell = workbook->GetCell(worksheetIndex, 0, i + 1, ObjectExt::Box(seriesNames[i]));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesCell, chart->get_Type());
    for (auto j = 0; j < 4; j++)
    {
        auto valueCell = workbook->GetCell(worksheetIndex, j + 1, i + 1, ObjectExt::Box(values[i][j]));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
    }

    series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
    series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColors[i]);

    auto labelFormat = series->get_Labels()->get_DefaultDataLabelFormat();
    labelFormat->set_ShowValue(true);
    labelFormat->set_IsNumberFormatLinkedToSource(false);
    labelFormat->set_NumberFormat(u"0.0%");
    labelFormat->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
    labelFormat->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    labelFormat->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_White());
}

presentation->Save(u"SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
```

## **讀取資料標籤的實際文字**

使用 [GetActualLabelText](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabel/getactuallabeltext/) 取得資料標籤設定所產生的文字。這在為報告擷取標籤、搜尋簡報內容或驗證產生的圖表時很有用。在下方範例中，預設的 [data label format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/) 結合了每個類別名稱、系列名稱與數值。某個資料點將其數值格式化為百分比，另一個則使用來自 [get_TextFrameForOverriding](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ioverridabletext/get_textframeforoverriding/) 的自訂文字。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto firstCategoryCell = workbook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Q1"));
chart->get_ChartData()->get_Categories()->Add(firstCategoryCell);
auto secondCategoryCell = workbook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Q2"));
chart->get_ChartData()->get_Categories()->Add(secondCategoryCell);

auto northSeriesCell = workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"North"));
auto north = chart->get_ChartData()->get_Series()->Add(northSeriesCell, chart->get_Type());
auto northFirstValueCell = workbook->GetCell(0, 1, 1, ObjectExt::Box(0.25));
north->get_DataPoints()->AddDataPointForBarSeries(northFirstValueCell);
auto northSecondValueCell = workbook->GetCell(0, 2, 1, ObjectExt::Box(0.75));
north->get_DataPoints()->AddDataPointForBarSeries(northSecondValueCell);

auto southSeriesCell = workbook->GetCell(0, 0, 2, ObjectExt::Box<String>(u"South"));
auto south = chart->get_ChartData()->get_Series()->Add(southSeriesCell, chart->get_Type());
auto southFirstValueCell = workbook->GetCell(0, 1, 2, ObjectExt::Box(0.40));
south->get_DataPoints()->AddDataPointForBarSeries(southFirstValueCell);
auto southSecondValueCell = workbook->GetCell(0, 2, 2, ObjectExt::Box(0.60));
south->get_DataPoints()->AddDataPointForBarSeries(southSecondValueCell);

for (auto i = 0; i < chart->get_ChartData()->get_Series()->get_Count(); i++)
{
    auto series = chart->get_ChartData()->get_Series()->idx_get(i);
    auto format = series->get_Labels()->get_DefaultDataLabelFormat();
    format->set_ShowCategoryName(true);
    format->set_ShowSeriesName(true);
    format->set_ShowValue(true);
}

north->get_Label(1)->get_DataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
north->get_Label(1)->get_DataLabelFormat()->set_NumberFormat(u"0%");
south->get_Label(0)->get_TextFrameForOverriding()->set_Text(u"Reviewed");

for (auto i = 0; i < chart->get_ChartData()->get_Series()->get_Count(); i++)
{
    auto series = chart->get_ChartData()->get_Series()->idx_get(i);
    for (auto j = 0; j < series->get_DataPoints()->get_Count(); j++)
    {
        auto point = series->get_DataPoint(j);
        auto label = point->get_Label();
        if (!label->get_IsVisible())
        {
            continue;
        }

        Console::WriteLine(String::Format(u"Value: {0}; label: {1}", point->get_Value()->get_Data(), label->GetActualLabelText()));
    }
}
```

資料點中儲存的數值仍為 `0.75`，即使其標籤顯示 `75%` 並附帶類別與系列名稱。自訂文字會取代產生的標籤文字。[GetActualLabelText](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabel/getactuallabeltext/) 在兩種情況下皆返回最終的標籤字串。若只想擷取可見的標籤，請另行檢查如上所示的 [get_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabel/get_isvisible/)。

## **控制超出座標軸最大值的資料標籤**

當手動限制座標軸範圍時，某些資料點可能超過其最大值。使用 [set_ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_showdatalabelsovermaximum/) 來控制是否顯示其資料標籤。此設定僅變更標籤可見性，並不會改變座標軸範圍或底層資料數值。

下面的範例建立一個 2D 群組直條圖，值為 60 與 120。它在垂直座標軸上將 [set_IsAutomaticMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticmaxvalue/) 設為 `false`，並將 [set_MaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_maxvalue/) 設為 100。第一張投影片允許標籤超過最大值；其副本則停用此功能。兩張投影片皆儲存為 `DataLabelsOverMaximum.pptx`。

使用 [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) 啟用值標籤。圖表層級的設定不會自行啟用值顯示，也不會覆寫個別標籤被停用的值顯示。此範例為整個系列啟用值，並使用 [set_Position](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_position/) 將標籤放置在每個柱狀圖的外側端點。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/LegendDataLabelPosition.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

auto firstCategory = workbook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Within range"));
auto secondCategory = workbook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Above maximum"));

chart->get_ChartData()->get_Categories()->Add(firstCategory);
chart->get_ChartData()->get_Categories()->Add(secondCategory);

auto seriesName = workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Values"));
auto series = chart->get_ChartData()->get_Series()->Add(seriesName, chart->get_Type());

auto firstValue = workbook->GetCell(0, 1, 1, ObjectExt::Box(60));
auto secondValue = workbook->GetCell(0, 2, 1, ObjectExt::Box(120));

series->get_DataPoints()->AddDataPointForBarSeries(firstValue);
series->get_DataPoints()->AddDataPointForBarSeries(secondValue);

series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
series->get_Labels()->get_DefaultDataLabelFormat()->set_Position(LegendDataLabelPosition::OutsideEnd);

chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMaxValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MaxValue(100);
chart->set_ShowDataLabelsOverMaximum(true);

auto secondSlide = presentation->get_Slides()->AddClone(slide);
auto secondChart = ExplicitCast<IChart>(secondSlide->get_Shape(0));
secondChart->set_ShowDataLabelsOverMaximum(false);

presentation->Save(u"DataLabelsOverMaximum.pptx", SaveFormat::Pptx);
```

以下圖片顯示 Microsoft PowerPoint 呈現的已儲存投影片。設定為 `true` 時，標籤 **120** 在上限處可見；設定為 `false` 時，則隱藏。標籤 **60** 仍保持可見，座標軸最大值仍為 **100**，且第二個資料點在兩種情況下皆為 **120**。

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
此範例使用具有值座標軸的 2D 直條圖。不具值座標軸的圖表（例如圓餅圖和環形圖），無法以此方式限制座標軸最大值。
{{% /alert %}}

## **設定標籤與座標軸的距離**

使用 [set_LabelOffset](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_labeloffset/) 來控制類別座標軸標籤與座標軸之間的距離。該值為類別軸標籤最大字型大小的百分比。本範例建立一個群組直條圖，並將水平座標軸標籤偏移設定為 500。此設定會影響類別座標軸標籤，而非附加於單一資料點的標籤。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset(500);

presentation->Save(u"SetCategoryAxisLabelDistance_out.pptx", SaveFormat::Pptx);
```

## **調整標籤位置**

在圓餅圖上，調整資料標籤位置以改善間距並為引線留出空間。

此範例顯示第一個資料點的值，將其標籤放置在切片外側，並使用 [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilayoutable/set_x/) 與 [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilayoutable/set_y/) 調整其偏移量。這些偏移量分別相對於圖表的寬度與高度。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/LegendDataLabelPosition.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 200, 200);
auto series = chart->get_ChartData()->get_Series();

auto label = series->idx_get(0)->get_Label(0);
label->get_DataLabelFormat()->set_ShowValue(true);
label->get_DataLabelFormat()->set_Position(LegendDataLabelPosition::OutsideEnd);
label->set_X(0.71f);
label->set_Y(0.04f);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
```

![調整後資料標籤位置的圓餅圖](pie-chart-adjusted-label.png)

## **格式化引線**

當圓餅圖的標籤位於切片外側時，引線可協助讀者將每個數值對應到正確的切片。使用對比色且稍微加粗的線條可讓這些連接更易於辨識，而加入透明度與虛線樣式則可使線條在視覺上不突兀。

使用 [get_LeaderLinesFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelcollection/get_leaderlinesformat/) 於系列的資料標籤集合層級格式化引線。`series->get_Labels()->get_LeaderLinesFormat()->get_Line()` 中的設定會套用到整個集合，而非單一標籤。

此範例建立一個使用預設資料的圓餅圖，將數值顯示於切片外側，並使用 [set_ShowLeaderLines](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showleaderlines/) 啟用引線。它透過 [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilayoutable/set_x/) 與 [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilayoutable/set_y/) 偏移量（以圖表寬度與高度的比例表示）將兩個標籤移離切片更遠。此範例不需要輸入的簡報檔。

由 [get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_fillformat/) 回傳的填充格式用於設定實心藍色，α值為 191（255 為滿值），約為 25% 透明度。[set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) 將粗細設為 2 點，[set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/) 則使線條呈虛線。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartLinesFormat.h>
#include <DOM/Chart/LegendDataLabelPosition.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/LineDashStyle.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 80, 50, 560, 400);
chart->set_HasLegend(false);

auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto labelFormat = series->get_Labels()->get_DefaultDataLabelFormat();
labelFormat->set_ShowValue(true);
labelFormat->set_Position(LegendDataLabelPosition::OutsideEnd);
labelFormat->set_ShowLeaderLines(true);

// 將兩個標籤從切片移得更遠。
series->get_Label(0)->set_X(0.10f);
series->get_Label(0)->set_Y(-0.05f);
series->get_Label(1)->set_X(-0.10f);
series->get_Label(1)->set_Y(0.05f);

auto line = series->get_Labels()->get_LeaderLinesFormat()->get_Line();
line->get_FillFormat()->set_FillType(FillType::Solid);
line->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(191, 30, 90, 160));
line->set_Width(2);
line->set_DashStyle(LineDashStyle::Dash);

presentation->Save(u"FormattedLeaderLines.pptx", SaveFormat::Pptx);
```

啟用引線並不保證每個標籤都會產生線條。可見性取決於標籤的位置與圖表的版面配置行為。在此範例中，兩個被移動的標籤具有可見的引線；靠近切片的標籤則不需要引線。

以下圖片顯示使用 Aspose.Slides 呈現的已儲存 `FormattedLeaderLines.pptx`：

![藍色、半透明虛線引線連接兩個外部標籤與其切片的圓餅圖](formatted-leader-lines.png)

## **在直條圖上方新增多列資料標籤**

此範例建立一個直條圖，在繪圖區上方放置兩列資料標籤。系列 A 顯示可見的柱狀圖，而系列 B 與系列 C 提供額外的標籤。透過移除填充與輪廓將它們的柱狀圖隱藏。[set_Overlap](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) 方法使三個系列在相同的類別中心對齊。

[get_PlotArea](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_plotarea/) 設定為標籤列保留空間。經過 [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) 計算預設位置後，使用 [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilayoutable/set_x/) 與 [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilayoutable/set_y/) 保持水平對齊，並套用垂直偏移以將標籤排列成兩列。這些數字仍為連結至系列數值的資料標籤；只有列標題是獨立的文字圖形。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/LegendDataLabelPosition.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartPlotArea.h>
#include <DOM/Chart/LayoutTargetType.h>
#include <DOM/FillType.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/ShapeType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 40, 40, 640, 200);
chart->set_HasTitle(false);
chart->set_HasLegend(false);
chart->get_TextFormat()->get_PortionFormat()->set_FontHeight(12);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

String categories[] = { u"North", u"South", u"East", u"West" };
String seriesNames[] = { u"Series A", u"Series B", u"Series C" };
double seriesValues[3][4] = {
    { 35, 42, 28, 47 },
    { 22, 31, 19, 26 },
    { 12, 16, 14, 18 }
};

for (auto categoryIndex = 0; categoryIndex < 4; categoryIndex++)
{
    auto categoryCell = workbook->GetCell(0, categoryIndex + 1, 0, ObjectExt::Box(categories[categoryIndex]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
}

for (auto seriesIndex = 0; seriesIndex < 3; seriesIndex++)
{
    auto seriesCell = workbook->GetCell(0, 0, seriesIndex + 1, ObjectExt::Box(seriesNames[seriesIndex]));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesCell, ChartType::ClusteredColumn);

    for (auto categoryIndex = 0; categoryIndex < 4; categoryIndex++)
    {
        auto valueCell = workbook->GetCell(0, categoryIndex + 1, seriesIndex + 1, ObjectExt::Box(seriesValues[seriesIndex][categoryIndex]));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
    }

    if (seriesIndex > 0)
    {
        // 隱藏 B 和 C 的柱狀圖，但保留它們的資料標籤。
        series->get_Format()->get_Fill()->set_FillType(FillType::NoFill);
        series->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
        auto labelFormat = series->get_Labels()->get_DefaultDataLabelFormat();
        labelFormat->set_ShowValue(true);
        labelFormat->get_TextFormat()->get_PortionFormat()->set_FontHeight(12);
        auto labelFill = labelFormat->get_TextFormat()->get_PortionFormat()->get_FillFormat();
        labelFill->set_FillType(FillType::Solid);
        labelFill->get_SolidFillColor()->set_Color(Color::get_Black());
        labelFormat->set_Position(LegendDataLabelPosition::InsideBase);
    }
}

// 將所有三個系列的類別中心對齊。
chart->get_ChartData()->get_Series()->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(100);

// 在此精簡範例中使用較少的格線。
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMajorUnit(false);
chart->get_Axes()->get_VerticalAxis()->set_MajorUnit(10);

// 在繪圖區上方保留空間，以放置兩列資料標籤。
chart->get_PlotArea()->set_LayoutTargetType(LayoutTargetType::Inner);
chart->get_PlotArea()->set_X(0.15f);
chart->get_PlotArea()->set_Y(0.32f);
chart->get_PlotArea()->set_Width(0.80f);
chart->get_PlotArea()->set_Height(0.48f);
chart->ValidateChartLayout();

for (auto seriesIndex = 1; seriesIndex < 3; seriesIndex++)
{
    auto series = chart->get_ChartData()->get_Series()->idx_get(seriesIndex);
    auto rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

    for (auto categoryIndex = 0; categoryIndex < 4; categoryIndex++)
    {
        auto dataLabel = series->get_DataPoint(categoryIndex)->get_Label();
        // 保持預設的水平位置。Y 為相對於
        // 預設標籤位置的偏移，以圖表高度的比例表示。
        dataLabel->set_X(0);
        dataLabel->set_Y(rowTop - dataLabel->get_ActualY() / chart->get_Height());
    }

    // 僅列標題為獨立的文字圖形。
    auto rowHeading = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, chart->get_X(), chart->get_Y() + rowTop * chart->get_Height(), 85, 18);
    rowHeading->get_FillFormat()->set_FillType(FillType::NoFill);
    rowHeading->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
    rowHeading->AddTextFrame(seriesNames[seriesIndex]);
    rowHeading->get_TextFrame()->get_TextFrameFormat()->set_MarginTop(0);
    rowHeading->get_TextFrame()->get_TextFrameFormat()->set_MarginBottom(0);
    auto headingFormat = rowHeading->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
    headingFormat->set_FontHeight(12);
    headingFormat->get_FillFormat()->set_FillType(FillType::Solid);
    headingFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
}

presentation->Save(u"multiple-rows-of-labels.pptx", SaveFormat::Pptx);
```

![繪圖區上方有兩列資料標籤的直條圖](multiple-rows-of-labels.png)

## **FAQ**

**如何防止在密集圖表上資料標籤重疊？**

結合自動標籤放置、引線與縮小字型大小；如有需要，可隱藏某些欄位（例如類別），或僅顯示極端值或關鍵點的標籤。

**如何僅對零、負或空值停用標籤？**

在啟用標籤之前先篩選資料點，並根據定義的規則關閉對 0、負值或遺失值的顯示。

**如何在匯出為 PDF/圖片時確保標籤樣式一致？**

明確設定字型系列與大小，並確認該字型在渲染環境中可用，以避免自動替代。