---
title: 使用 C++ 在簡報中管理圖表工作簿
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
description: "探索適用於 C++ 的 Aspose.Slides：輕鬆管理 PowerPoint 與 OpenDocument 格式的圖表工作簿，簡化簡報資料。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中使用圖表工作簿。它展示了如何透過工作簿串流讀寫圖表資料、將工作簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

它也涵蓋了將外部工作簿作為圖表資料來源的使用方式。範例示範如何建立並指派外部工作簿、取得連結至圖表的外部工作簿路徑，以及在工作簿可用時編輯圖表資料。

## **從工作簿讀寫圖表資料**

Aspose.Slides 提供 [ReadWorkbookStream](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) 與 [WriteWorkbookStream](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) 方法，讓您讀寫包含以 Aspose.Cells 編輯的圖表資料之工作簿。**注意** 圖表資料必須以相同方式組織，或具類似於來源的結構。

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

### **在工作簿修改後驗證圖表佈局**

當您以已修改的工作簿取代內嵌工作簿時，圖表仍保留原始的系列與類別集合。此不匹配可能導致 [IChart::ValidateChartLayout](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichart/validatechartlayout/) 因索引超出範圍而失敗。寫回已更新的工作簿之前，請先清除現有的系列與類別。

```cpp
// 在修改工作簿串流後（例如使用 Aspose.Cells）
auto updatedWorkbook = chartData->ReadWorkbookStream();

// 清除現有的資料參考。
chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

updatedWorkbook->set_Position(0);
chartData->WriteWorkbookStream(updatedWorkbook);

chart->ValidateChartLayout();
```

清除集合可確保圖表資料結構與新工作簿一致，讓 `ValidateChartLayout` 能順利完成而不產生錯誤。

## **將工作簿儲存格設定為圖表資料標籤**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 新增一個氣泡圖並提供一些資料。  
4. 存取圖表系列。  
5. 將工作簿儲存格設定為資料標籤。  
6. 儲存簡報。

以下 C++ 程式碼示範如何將工作簿儲存格設定為圖表資料標籤：

```cpp
// 建立一個代表簡報檔案的 Presentation 類別實例
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

## **管理工作表**

此 C++ 程式碼示範使用 [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) 方法存取工作表集合的操作：

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

## **指定資料來源類型**

此 C++ 程式碼展示如何為資料來源指定類型：

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

## **偵測不支援的內嵌工作簿格式**

Aspose.Slides 不支援某些圖表中可內嵌的 Excel 二進位工作簿 (.xlsb) 格式。您可以使用 [IChartData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdata/) 上的 `get_EmbeddedWorkbookType` 方法，搭配 [WorkbookType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/workbooktype/) 列舉，偵測不支援的格式並跳過那些圖表。

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
        // 嵌入的工作簿為 .xlsb 格式，不受支援。
        continue;
    }

    // 在此讀取或修改圖表工作簿資料。
}
```

## **外部工作簿**

{{% alert color="info" %}} 
在 [Aspose.Slides](https://releases.aspose.com/slides/zh-hant/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4 版中，我們實作了對外部工作簿作為圖表資料來源的支援。 
{{% /alert %}} 

### **建立外部工作簿**

使用 **`ReadWorkbookStream`** 與 **`SetExternalWorkbook`** 方法，您可以從頭建立外部工作簿，或將內部工作簿轉為外部工作簿。

以下 C++ 程式碼示範外部工作簿的建立過程：

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

### **設定外部工作簿**

使用 **`IChartData::SetExternalWorkbook`** 方法，您可以將外部工作簿指派給圖表作為資料來源。此方法亦可用於更新外部工作簿的路徑（若該檔案已被移動）。

雖然無法直接編輯儲存在遠端位置或資源中的工作簿資料，但仍可將此類工作簿作為外部資料來源使用。若提供相對路徑，系統會自動轉換為完整路徑。

以下 C++ 程式碼示範如何設定外部工作簿：

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

`SetExternalWorkbook` 方法中的 `updateChartData` 參數用於指定是否載入 Excel 工作簿。

* 當 `updateChartData` 值設定為 `false` 時，僅會更新工作簿路徑——圖表資料不會從目標工作簿載入或更新。當目標工作簿不存在或無法取得時，可使用此設定。  
* 當 `updateChartData` 值設定為 `true` 時，圖表資料會從目標工作簿更新。

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

### **取得圖表外部資料來源工作簿路徑**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 建立圖表形狀的物件。  
4. 建立代表圖表資料來源的 `ChartDataSourceType` 物件。  
5. 根據來源類型與外部工作簿資料來源類型相同的條件，指定相關條件。

以下 C++ 程式碼示範此操作：

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

// 保存簡報
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **編輯圖表資料**

您可以像編輯內部工作簿內容一樣編輯外部工作簿的資料。若無法載入外部工作簿，會拋出例外。

以下 C++ 程式碼實作上述流程：

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

### **從圖表快取中復原工作簿**

如果圖表使用的外部工作簿遺失或無法取得，Aspose.Slides 可從簡報中快取的資料重建圖表工作簿。建立 [LoadOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/)，使用 [set_SpreadsheetOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) 進行配置，並在開啟簡報前將 [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) 設為 `true`。

以下 C++ 範例開啟一份圖表參照不可用外部工作簿的簡報，並透過 [IChart::get_ChartData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichart/get_chartdata/) 與 [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) 取得復原的資料：

```cpp
auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto chart = System::ExplicitCast<IChart>(shape);

auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

// 在此讀取或修改復原的工作簿資料。

presentation->Dispose();
```

若外部工作簿不可用且未啟用復原，Aspose.Slides 會拋出 `System::InvalidOperationException`。僅在接受使用快取圖表資料作為可接受的備援時才啟用復原，因為快取可能不包含外部工作簿在簡報最後一次更新之後所做的變更。

## **常見問題**

**我能判斷特定圖表是連結到外部工作簿還是內嵌工作簿嗎？**

可以。圖表具有 [資料來源類型](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) 以及 [外部工作簿路徑](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/)。若來源是外部工作簿，您即可讀取完整路徑以確認使用了外部檔案。

**是否支援相對路徑至外部工作簿？它們如何儲存？**

支援。若指定相對路徑，系統會自動轉換為絕對路徑。這對專案可移植性很方便；但請注意簡報會在 PPTX 檔案中儲存絕對路徑。

**我可以使用位於網路資源/共享資料夾的工作簿嗎？**

可以，這類工作簿可作為外部資料來源使用。但 Aspose.Slides 不支援直接編輯遠端工作簿——只能作為來源使用。

**Aspose.Slides 會在儲存簡報時覆寫外部 XLSX 嗎？**

不會。簡報只儲存指向外部檔案的 [連結](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/)，並於讀取資料時使用該連結。簡報儲存時不會修改外部檔案本身。

**如果外部檔案受密碼保護，我該怎麼辦？**

Aspose.Slides 連結時不接受密碼。常見做法是事先移除保護或先準備一個已解密的副本（例如使用 [Aspose.Cells](/cells/cpp/)），再連結該副本。

**多個圖表可以參照同一個外部工作簿嗎？**

可以。每個圖表都會儲存自己的連結。如果它們指向同一個檔案，更新該檔案後，下次載入資料時所有圖表皆會反映變更。