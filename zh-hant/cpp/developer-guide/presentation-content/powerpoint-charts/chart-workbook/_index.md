---
title: 使用 C++ 管理簡報中的圖表工作簿
linktitle: 圖表工作簿
type: docs
weight: 70
url: /zh-hant/cpp/chart-workbook/
keywords:
- 圖表工作簿
- 圖表資料
- 工作簿儲存格
- 資料標籤
- 工作表
- 資料來源
- 外部工作簿
- 外部資料
- 圖表快取
- 工作簿復原
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "探索 Aspose.Slides for C++：在 PowerPoint 與 OpenDocument 格式中輕鬆管理圖表工作簿，簡化您的簡報資料。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用圖表工作簿。它展示了如何透過工作簿串流讀寫圖表資料、將工作簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

它亦涵蓋將外部工作簿作為圖表資料來源的使用方式。範例示範了如何建立並指派外部工作簿、取得連結至圖表的外部工作簿路徑，以及在工作簿可用時編輯圖表資料。

若工作簿儲存格代表缺少資料，請參閱[控制空白儲存格的顯示](/slides/zh-hant/cpp/chart-series/)以了解空白儲存格與零的差異，以及可用顯示模式的折線圖比較。

## **包含隱藏列與行的資料**

使用[IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) 來控制圖表是否繪製來自隱藏工作表列與欄的資料。將其設為 `true` 以僅繪製可見儲存格，或設為 `false` 以同時包含可見與隱藏儲存格。此設定控制圖表繪製；不會隱藏或取消隱藏工作表列或欄。

[範例簡報](hidden-source-data.pptx) 包含在其第一張投影片第一個形狀的柱狀圖。內嵌工作表 `Sheet1` 包含以下來源範圍 `A1:C4`。第 3 列與 C 欄已隱藏，但其儲存格仍包含數值。

| 工作表列 | A: 月份 | B: 零售 | C: 批發（隱藏欄） |
| --- | --- | --- | --- |
| 2 | 一月 | 10 | 30 |
| 3（隱藏列） | 二月 | 40 | 60 |
| 4 | 三月 | 20 | 50 |

透過[IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) 存取來源儲存格，並讀取[IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) 以檢查其是否隱藏。此屬性唯讀。在此檔案中，B2 為可見，B3 屬於隱藏列，C2 屬於隱藏欄；範例分別輸出 `False`、`True` 與 `True`。

對於此範例，在變更繪製設定後需重新整理圖表資料：使用[ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/)保留內嵌工作簿，並使用[WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/)重新載入。若要包含所有儲存格，亦需使用[SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/)以復原完整範圍，包括隱藏的二月類別。僅變更旗標不足以重新整理此範例的快取圖表資料與類別標籤。

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

        // 從嵌入的工作簿重新整理圖表資料。
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // 還原完整的來源範圍，包含隱藏的類別。
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

此範例會儲存兩個版本的簡報：一個僅含可見的零售數值 (10 與 20)，另一個則包含全部六個數值。下方影像說明兩種繪製模式。第 3 列與 C 欄在兩個內嵌工作簿中皆保持隱藏。

| 僅可見儲存格 (`true`) | 全部儲存格 (`false`) |
| --- | --- |
| ![僅可見儲存格：一月與三月的零售數值 10 與 20](hidden_cells_True.png) | ![全部儲存格：一月、二月與三月的零售與批發數值](hidden_cells_False.png) |

包含數值的隱藏儲存格不同於空白儲存格。[IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) 控制缺少值的顯示方式；它不會包含或排除隱藏的來源資料。請參閱[控制空白儲存格的顯示](/slides/zh-hant/cpp/chart-series/#control-the-display-of-empty-cells)以了解範例。

## **取得圖表的資料範圍**

在更新現有簡報的工作簿資料之前，請檢查來源範圍以辨識每個圖表使用的工作表儲存格。[IChartData::GetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) 方法會回傳目前的資料範圍，形式為工作表限定的公式，例如 `Sheet1!$A$1:$D$5`。此處，`Sheet1` 為工作表名稱，`!` 為分隔符，`$A$1:$D$5` 標示 A1 到 D5（含）之儲存格。美元符號表示絕對列與欄的參照。

此方法在不更改圖表或其工作簿的情況下讀取目前範圍。如果圖表未使用工作簿作為資料來源，則會拋出[System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/)。欲了解更多資訊，請參閱[ChartData API 參考](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/)。

此範例會開啟簡報並直接在每張投影片上檢查形狀是否為圖表。它會輸出每個圖表的名稱與來源範圍。如果圖表未使用工作簿，則輸出訊息並繼續處理下一個圖表。

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

## **從工作簿讀寫圖表資料**

Aspose.Slides for C++ 提供[ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/)與[WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/)方法，讓您能讀寫圖表資料工作簿（其中的圖表資料可由 Aspose.Cells 編輯）。**注意** 圖表資料必須以相同方式組織，或具有類似來源的結構。

此範例使用一個在首張投影片上第一個形狀為圖表的簡報。它將內嵌工作簿讀入串流，清除現有系列與類別，然後寫回相同工作簿。變更只保留在記憶體中；此範例不會儲存簡報。

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

### **修改工作簿後驗證圖表版面配置**

當您以修改過的工作簿取代內嵌工作簿時，圖表會保留原始的系列與類別集合。此不匹配可能導致[IChart::ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/)因索引超出範圍而失敗。寫回更新的工作簿之前，請先清除現有的系列與類別。此範例使用首張投影片上第一個形狀的圖表。註解標示了工作簿編輯的所在位置；可執行的範例將原始工作簿寫回，並在記憶體中驗證版面配置。

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

    // 在此修改工作簿串流，例如使用 Aspose.Cells。

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

在寫回工作簿之前，清除集合可移除過時的資料參照。使用圖表前，重新建構更新後工作簿所需的系列與類別對映。

## **為工作簿儲存格設定自訂數字格式**

使用[IChartDataCell::set_CustomNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_customnumberformat/) 以控制數值在圖表內嵌工作簿中的顯示方式。例如，報告可能需要將轉換率以四位小數的百分比顯示，且將係數以五位小數顯示。兩個值皆保持為數值，以便於計算與圖表繪製。

數字格式僅影響顯示，不會改變儲存的值。格式`0.0000%`會將`0.125`顯示為`12.5000%`；不會將儲存的數字替換為`12.5`。同樣地，`0.00000`會將`0.1234567`顯示為`0.12346`，且不會四捨五入儲存的值。若自訂格式為空字串(`""`)，則改用透過[set_PresetNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_presetnumberformat/)指定的格式。

以下範例建立柱狀圖，並透過[IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/)存取其儲存格。於工作表 0 中，B2 包含轉換率，C2 包含係數。兩個儲存格皆提供圖表值。此範例亦啟用與來源格式連結的值標籤。

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

工作簿儲存格格式與直接設定於圖表坐標軸或資料標籤的格式分開。在此範例中，每個標籤會顯示其來源儲存格的值，因為[set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/)以`true`呼叫，且因為[set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_isnumberformatlinkedtosource/)以`true`呼叫而遵循來源數字格式。儲存並重新開啟簡報後，標籤會顯示`12.5000%`與`0.12346`，如下圖所示。縱軸使用其自身的`0.00`格式，透過[set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_numberformat/)設定，且[set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isnumberformatlinkedtosource/)以`false`呼叫。

若要獨立格式化資料標籤，將其來源連結旗標設為`false`，並透過[set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_numberformat/)指定格式。此不會變更工作簿儲存格的格式。例如，獨立的標籤格式`0.00`會將第一個值顯示為`0.13`，而 B2 仍顯示`12.5000%`。請參閱[圖表資料標籤](/slides/zh-hant/cpp/chart-data-label/#set-percentage-sign-with-chart-data-labels)了解直接標籤格式化。

以下影像是從重新開啟後儲存的簡報中渲染的：

![柱狀圖，來源連結標籤顯示 12.5000% 與 0.12346，且縱軸獨立格式化為數值軸](custom-cell-formats.png)

## **將工作簿儲存格設定為圖表資料標籤**

您可以使用工作簿儲存格中的文字作為圖表資料標籤。

此範例在現有簡報的第一張投影片加入預設資料的氣泡圖。它使用工作表 0 的儲存格 A10:A12 作為第一系列的前三個標籤，啟用來自儲存格的標籤，並儲存更新後的簡報。

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

## **管理工作表**

[IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) 方法提供存取圖表工作簿中工作表的功能。此範例建立預設資料的圓餅圖，並將每個工作表名稱輸出至主控台。

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

## **指定資料來源類型**

此範例建立預設資料的 3D 柱狀圖，並使用不同的資料來源設定兩個系列名稱。第一個名稱使用字串字面值；第二個名稱使用工作表 0 中的儲存格 C1。[DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) 列舉選擇每個名稱的來源。此範例會以更新後的系列名稱儲存簡報。

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

## **偵測不支援的內嵌工作簿格式**

Aspose.Slides 不支援可嵌入於某些圖表中的 Excel 二進位工作簿 (.xlsb) 格式。您可以在[IChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/)上使用[get_EmbeddedWorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/)方法，搭配[WorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/)列舉，以偵測不支援的格式並跳過這些圖表。此範例檢查現有簡報第一張投影片的形狀，跳過非圖表形狀，並為每個內嵌 .xlsb 工作簿的圖表輸出診斷訊息。

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

    // 在此讀取或修改支援的圖表工作簿資料。
}
```

## **外部工作簿**

Aspose.Slides 支援使用外部工作簿作為圖表的資料來源。

### **建立外部工作簿**

使用[ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/)與[SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/)可將內嵌圖表工作簿匯出至檔案，並將圖表連結至該外部工作簿。

此範例建立預設資料的圓餅圖並匯出其工作簿。於指派外部工作簿為圖表資料來源之前關閉輸出串流，然後儲存已連結的簡報。

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

### **設定外部工作簿**

使用[SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) 方法，您可以將外部工作簿指派給圖表作為其資料來源。此方法亦可用於更新外部工作簿的路徑（若該檔案已被搬移）。

雖然無法編輯儲存在遠端位置或資源中的工作簿資料，但仍可將此類工作簿作為外部資料來源。若提供外部工作簿的相對路徑，系統會自動轉換為完整路徑。

此範例使用外部工作簿，其工作表 `Sheet1` 在 B1 包含系列名稱、A2:A4 包含類別名稱，B2:B4 包含數值。範例建立圓餅圖，連結該工作簿，並使用[SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/)將 A1:B4 對映為一個系列與三個類別。最後以已連結圖表的方式儲存簡報。

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

[SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) 的 `updateChartData` 參數控制是否載入工作簿。

- 當 `updateChartData` 為 `false` 時，僅更新工作簿路徑。圖表資料不會從目標工作簿載入或更新，因而工作簿可以不存在。
- 當 `updateChartData` 為 `true` 時，圖表資料會從目標工作簿更新。

以下範例將佔位符 URL 指派給`updateChartData`為`false`。它保留圓餅圖的預設資料，並於不載入無法取得的工作簿情況下儲存簡報。

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

### **取得圖表的外部資料來源工作簿路徑**

若要辨識連結至圖表的工作簿，請檢查圖表是否使用外部資料來源，並取得其工作簿路徑。

此範例檢查具有已連結外部工作簿之簡報的第一張投影片上第一個形狀。若該形狀為連結至外部工作簿的圖表，範例會將[get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/)輸出至主控台。然後儲存簡報的副本。

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

### **編輯圖表資料**

您可以像編輯內部工作簿內容一樣編輯外部工作簿的資料。若外部工作簿無法載入，會拋出例外。

此範例使用第一張投影片上第一個形狀的圖表，且該圖表連結至可存取的外部工作簿。它將第一系列第一資料點的儲存格值設為 100，並儲存更新後的簡報。編輯儲存格值可更新連結的外部 XLSX 檔案，若需保留原始工作簿，請使用副本。

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

### **從圖表快取恢復工作簿**

若圖表使用的外部工作簿遺失或無法取得，Aspose.Slides 可從簡報中快取的資料重建圖表工作簿。建立[LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/)，使用[set_SpreadsheetOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) 進行設定，並在開啟簡報前以 `true` 呼叫[ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/)。

以下 C++ 範例為第一張投影片上第一個形狀的圖表（參照無法取得的外部工作簿）復原工作簿資料。它透過[IChart::get_ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/)與[IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/)存取復原的資料：

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

    // 在此讀取或修改已復原的工作簿資料。
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

若外部工作簿無法取得且未啟用復原，Aspose.Slides 會拋出[System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/)。僅在使用快取圖表資料作為可接受的備援時才啟用復原，因為快取可能不包含簡報最後更新後對外部工作簿所做的變更。

## **常見問題**

**我可以判斷特定圖表是連結至外部工作簿還是內嵌工作簿嗎？**

可以。圖表具有[data source type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/)以及[path to an external workbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/)；若來源是外部工作簿，您可以讀取完整路徑以確認使用了外部檔案。

**是否支援外部工作簿的相對路徑，且它們如何儲存？**

支援。若您指定相對路徑，系統會自動轉換為絕對路徑。簡報會將絕對路徑儲存在 PPTX 檔案中，搬移工作簿時可能需要更新連結。

**我可以使用位於網路資源/共享上的工作簿嗎？**

可以，此類工作簿可作為外部資料來源使用。但不支援直接從 Aspose.Slides 編輯遠端工作簿——只能作為來源使用。

**Aspose.Slides 在儲存簡報時會覆寫外部 XLSX 檔案嗎？**

簡報會儲存[link to the external file](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/)。編輯以儲存格為基礎的圖表資料亦可能更新連結的本機 XLSX 檔案。若原始檔案必須保持不變，請使用工作簿的副本。

**如果外部檔案受密碼保護，我該怎麼辦？**

Aspose.Slides 在連結時不接受密碼。常見的做法是事先移除保護或製作已解密的副本（例如使用[Aspose.Cells](https://reference.aspose.com/cells/cpp/))，再連結至該副本。

**多個圖表可以參考相同的外部工作簿嗎？**

可以。每個圖表會儲存自己的連結。若皆指向同一檔案，更新該檔案後，在下次載入資料時，所有圖表皆會反映變更。