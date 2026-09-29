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
description: "探索 Aspose.Slides for C++：輕鬆在 PowerPoint 與 OpenDocument 格式中管理圖表工作簿，簡化您的簡報資料。"
---
## **概述**

本篇文章說明如何在 Aspose.Slides 中使用圖表工作簿。它展示了如何透過工作簿串流讀寫圖表資料、使用工作簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

它也涵蓋了使用外部工作簿作為圖表資料來源的做法。範例示範如何建立並指派外部工作簿、取得連結至圖表的外部工作簿路徑，以及在工作簿可用時編輯圖表資料。

對於代表遺失資料的工作簿儲存格，請參閱[控制空儲存格的顯示](/slides/zh-hant/cpp/chart-series/)以了解空儲存格與零的差異，並查看折線圖比較可用的顯示模式。

## **包含隱藏列與欄的資料**

使用[IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/)來控制圖表是否只繪製可見工作表列與欄的資料。將其設為`true`則僅繪製可見儲存格，設為`false`則同時包含可見與隱藏儲存格。此設定僅影響圖表繪製，並不會隱藏或取消隱藏工作表列與欄。

下載[hidden-source-data.pptx](hidden-source-data.pptx)並放置於工作目錄。其第一張投影片的第一個圖形是一個柱狀圖。內嵌工作表`Sheet1`的來源範圍為`A1:C4`。第 3 列與 C 欄被隱藏，但其儲存格仍保有值。

| 工作表列 | A: 月份 | B: 零售 | C: 批發（隱藏欄） |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

透過[IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/)存取來源儲存格，並讀取[IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/)以檢查其隱藏狀態。此屬性為唯讀。在本檔案中，B2 為可見，B3 屬於隱藏列，C2 屬於隱藏欄；範例分別輸出`False`、`True`與`True`。

對於此範例，在變更繪製設定後請重新整理圖表資料：保留內嵌工作簿並使用[ReadWorkbookStream](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdata/readworkbookstream/)讀取，然後以[WriteWorkbookStream](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/)重新寫入。若要包含所有儲存格，還需使用[SetRange](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdata/setrange/)還原完整範圍，包含隱藏的 February 類別。僅變更旗標不足以刷新此樣本的快取圖表資料與類別標籤。

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

        // 從嵌入式工作簿重新整理圖表資料。
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // 還原完整的來源範圍，包括隱藏的類別。
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

此範例將 `hidden_cells_True.pptx` 以僅保留可見的 Retail 值 (10 與 20) 儲存，將 `hidden_cells_False.pptx` 以全部六個值儲存。下方圖片說明兩種繪製模式。第 3 列與 C 欄在兩個內嵌工作簿中皆保持隱藏。

| 僅可見儲存格（`true`） | 全部儲存格（`false`） |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

含值的隱藏儲存格不同於空儲存格。[IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichart/get_displayblanksas/)控制遺失值的顯示方式，並不會包含或排除隱藏的來源資料。請參閱[控制空儲存格的顯示](/slides/zh-hant/cpp/chart-series/#control-the-display-of-empty-cells)取得範例。

## **讀寫來自工作簿的圖表資料**

Aspose.Slides for C++ 提供[ReadWorkbookStream](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdata/readworkbookstream/)與[WriteWorkbookStream](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/)方法，讓您能讀寫圖表資料工作簿（包含使用 Aspose.Cells 編輯的圖表資料）。**注意**圖表資料必須以相同方式組織，或具有類似於來源的結構。

此範例開啟 `chart.pptx`（必須在第一張投影片的第一個圖形為圖表），將內嵌工作簿讀入串流，清除現有的系列與類別，然後將相同的工作簿寫回。變更僅保留於記憶體中，範例不會儲存簡報。

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

### **驗證工作簿修改後的圖表佈局**

當您以已修改的工作簿取代內嵌工作簿時，圖表仍保留原始的系列與類別集合。此不匹配可能導致[IChart::ValidateChartLayout](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichart/validatechartlayout/)因索引超出範圍而失敗。寫回更新的工作簿前請先清除現有的系列與類別。本範例需要 `chart.pptx`，其第一張投影片的第一個圖形為圖表。註解標示了工作簿編輯會發生的地方；可執行的範例寫回原始工作簿並在記憶體中驗證佈局。

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

    // 在此修改工作簿串流，例如，使用 Aspose.Cells.

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

清除集合可在寫回工作簿之前移除過時的資料參考。於使用圖表前，為已更新的工作簿重新建構任何必要的系列與類別對應。

## **將工作簿儲存格設為圖表資料標籤**

您可以使用工作簿儲存格的文字作為圖表資料標籤。以下步驟示範如何在氣泡圖中將標籤連結至其資料工作簿中的儲存格。

1. 建立[Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/)類別的實例。  
2. 以零基索引存取第一張投影片。  
3. 新增預設資料的氣泡圖。  
4. 取得圖表系列。  
5. 將工作簿儲存格設為資料標籤。  
6. 儲存簡報。

此範例開啟 `chart2.pptx`（必須至少有一張投影片），並加入預設資料的氣泡圖。它使用工作表 0 上的儲存格 A10:A12 作為第一系列前三個標籤，啟用來自儲存格的標籤，並將結果儲存為 `resultchart.pptx`。

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

[IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) 方法提供對圖表工作簿中工作表的存取。本範例建立預設資料的圓餅圖，並將每個工作表名稱印至主控台。

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

此範例建立預設資料的 3D 柱狀圖，並以不同資料來源設定兩個系列名稱。第一個名稱使用字串常值；第二個名稱使用工作表 0 上的儲存格 C1。[DataSourceType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/datasourcetype/) 列舉用來為每個名稱選擇來源。結果儲存為 `pres.pptx`。

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

## **偵測不支援的嵌入式工作簿格式**

Aspose.Slides 不支援某些圖表中可能嵌入的 Excel 二進位工作簿（.xlsb）格式。您可以在[IChartData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdata/) 上使用[get_EmbeddedWorkbookType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) 方法，搭配[WorkbookType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/workbooktype/) 列舉，偵測不支援的格式並跳過這些圖表。此範例檢查 `sample.pptx` 第一張投影片的形狀，跳過非圖表形狀，並對每個含有嵌入 .xlsb 工作簿的圖表列印診斷訊息。

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

    // 在此讀取或修改受支援的圖表工作簿資料。
}
```

## **外部工作簿**

Aspose.Slides 支援使用外部工作簿作為圖表的資料來源。

### **建立外部工作簿**

使用[ReadWorkbookStream](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdata/readworkbookstream/)與[SetExternalWorkbook](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/)將內嵌圖表工作簿匯出為檔案，並將圖表連結至該外部工作簿。

此範例建立預設資料的圓餅圖，將其工作簿寫入 `externalWorkbook1.xlsx`，然後在指派檔案為圖表資料來源前關閉輸出串流。最後將連結後的簡報儲存為 `externalWorkbook.pptx`。

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

### **指派外部工作簿**

使用[SetExternalWorkbook](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/)方法，您可以將外部工作簿指定為圖表的資料來源。此方法同樣可用於更新外部工作簿的路徑（例如工作簿已移動）。

雖然無法直接編輯儲存在遠端位置或資源中的工作簿，但仍可將此類工作簿作為外部資料來源使用。若提供相對路徑，系統會自動轉換為完整路徑。

此範例需要工作目錄中存在 `externalWorkbook.xlsx`。其工作表 `Sheet1` 必須在 B1 包含系列名稱、A2:A4 包含類別名稱、B2:B4 包含數值。範例建立圓餅圖、連結工作簿，並使用[SetRange](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdata/setrange/)將 A1:B4 對映至一個系列與三個類別。結果儲存為 `Presentation_with_externalWorkbook.pptx`。

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

[SetExternalWorkbook](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) 的 `updateChartData` 參數決定是否載入工作簿。

* 當 `updateChartData` 為 `false` 時，僅更新工作簿路徑。圖表資料不會從目標工作簿載入或更新，因此工作簿可以不存在。  
* 當 `updateChartData` 為 `true` 時，圖表資料會從目標工作簿更新。

以下範例將 `updateChartData` 設為 `false`，指派一個佔位符 URL。它保留圓餅圖的預設資料，且在未載入不可用的工作簿情況下儲存簡報。

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

若要識別連結至圖表的工作簿，首先檢查圖表是否使用外部資料來源。若是，您可以依照以下步驟取得工作簿路徑。

1. 建立[Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/)類別的實例。  
2. 以零基索引存取第一張投影片。  
3. 確認第一個圖形是圖表。  
4. 讀取圖表資料來源類型。  
5. 若來源為外部工作簿，讀取其路徑。

此範例開啟先前建立的 `externalWorkbook.pptx`，檢查第一張投影片的第一個圖形。若該圖形為連結至外部工作簿的圖表，範例會將[get_ExternalWorkbookPath](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/)印至主控台，然後將簡報的副本儲存為 `Result.pptx`。

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

您可以以與編輯內部工作簿相同的方式編輯外部工作簿的資料。若無法載入外部工作簿，將拋出例外。

此範例需要 `presentation.pptx`（第一張投影片的第一個圖形為圖表）以及可存取的外部工作簿。它將第一系列第一資料點的儲存格值設定為 100，並將簡報儲存為 `presentation_out.pptx`。編輯儲存格值會更新連結的外部 XLSX 檔案，若需保留原始工作簿，請使用副本。

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

### **從圖表快取復原工作簿**

若圖表使用的外部工作簿遺失或不可用，Aspose.Slides 可以從簡報中快取的資料重建圖表工作簿。建立[LoadOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/)，使用[set_SpreadsheetOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) 設定，並於開啟簡報前呼叫[ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) 並設為 `true`。

以下 C++ 範例開啟 `presentation.pptx`（第一張投影片的第一個圖形必須是參照不可用外部工作簿的圖表），並透過[IChart::get_ChartData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichart/get_chartdata/)與[IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/)存取復原的資料：

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

如果外部工作簿不可用且未啟用復原，Aspose.Slides 會拋出[System::InvalidOperationException](https://reference.aspose.com/slides/zh-hant/cpp/system/details_invalidoperationexception/)。僅在接受使用快取圖表資料作為可接受的備援時才啟用復原，因為快取可能不包含外部工作簿在簡報最後一次更新後所做的變更。

## **FAQ**

**我能否判斷特定圖表是連結至外部工作簿還是內嵌工作簿？**

可以。圖表具有[資料來源類型](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chartdata/get_datasourcetype/)與[外部工作簿路徑](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/)，若來源為外部工作簿，您即可讀取完整路徑以確認使用了外部檔案。

**是否支援相對路徑的外部工作簿，且它們如何儲存？**

支援。若指定相對路徑，系統會自動轉換為絕對路徑。簡報會在 PPTX 檔案中儲存絕對路徑，搬移工作簿後可能需要更新連結。

**我可以使用位於網路資源或共享資料夾的工作簿嗎？**

可以，這類工作簿可作為外部資料來源使用。但不支援直接從 Aspose.Slides 編輯遠端工作簿——只能作為來源使用。

**Aspose.Slides 在儲存簡報時會覆寫外部 XLSX 嗎？**

簡報會儲存指向外部檔案的[連結](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/)。編輯以儲存格為基礎的圖表資料也可能會更新本機的 XLSX 檔案。若原始檔案必須保持不變，請使用該工作簿的副本。

**若外部檔案受密碼保護該怎麼辦？**

Aspose.Slides 在連結時不接受密碼。常見做法是事先移除保護或先建立解密的副本（例如使用[Aspose.Cells](https://reference.aspose.com/cells/cpp/)），再連結該副本。

**多個圖表可以參照同一個外部工作簿嗎？**

可以。每個圖表會儲存自己的連結。若它們皆指向相同檔案，更新該檔案後，下次載入資料時每個圖表皆會反映變更。