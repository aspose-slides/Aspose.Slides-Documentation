---
title: 管理使用 C++ 的簡報中的圖表活頁簿
linktitle: 圖表活頁簿
type: docs
weight: 70
url: /zh-hant/cpp/chart-workbook/
keywords:
- 圖表活頁簿
- 圖表資料
- 活頁簿儲存格
- 資料標籤
- 工作表
- 資料來源
- 外部活頁簿
- 外部資料
- 圖表快取
- 活頁簿復原
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "探索 Aspose.Slides for C++：輕鬆在 PowerPoint 與 OpenDocument 格式中管理圖表活頁簿，以簡化您的簡報資料。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圖表活頁簿。它展示了如何透過活頁簿串流讀寫圖表資料、使用活頁簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

此外還說明如何將外部活頁簿作為圖表資料來源。範例示範了如何建立與指派外部活頁簿、取得連結到圖表的外部活頁簿路徑，以及在活頁簿可用時編輯圖表資料。

## **從活頁簿讀寫圖表資料**

Aspose.Slides 提供 [ReadWorkbookStream](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) 與 [WriteWorkbookStream](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) 方法，可讓您讀寫圖表資料活頁簿（包含使用 Aspose.Cells 編輯的圖表資料）。**注意** 圖表資料必須以相同方式組織，或具備與來源相似的結構。

``` cpp
auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto data = chart->get_ChartData();

System::SharedPtr<System::IO::MemoryStream> stream = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

此 C++ 程式碼示範設定圖表資料活頁簿的操作：

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Charts::ChartType::Pie, 50.0f, 50.0f, 500.0f, 400.0f);
chart->get_ChartData()->get_ChartDataWorkbook()->Clear(0);

intrusive_ptr<Aspose::Cells::IWorkbook> workbook;
try
{
    workbook = Aspose::Cells::Factory::CreateIWorkbook(new String("a1.xlsx"));
}
catch (Aspose::Cells::Systems::Exception& ex)
{
    System::Console::Write(System::String::FromWCS(ex.GetMessageExp()->value()));
}

intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
workbook->Save(cellsOutputStream, Aspose::Cells::SaveFormat_Xlsx);

cellsOutputStream->SetPosition(0);
System::SharedPtr<System::IO::MemoryStream> msout = ToSlidesMemoryStream(cellsOutputStream);

chart->get_ChartData()->WriteWorkbookStream(msout);

chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$B$9");
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);
pres->Save(u"response2.pptx", Export::SaveFormat::Pptx);
```

## **將活頁簿儲存格設為圖表資料標籤**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。  
1. 透過索引取得投影片的參考。  
1. 新增一個 Bubble 圖表並填入資料。  
1. 存取圖表系列。  
1. 將活頁簿儲存格設定為資料標籤。  
1. 儲存簡報。

此 C++ 程式碼說明如何將活頁簿儲存格設定為圖表資料標籤：

``` cpp
System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// 實例化一個表示簡報檔案的 Presentation 類別 
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
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **指定資料來源類型**

此 C++ 程式碼說明如何為資料來源指定類型：

```c++
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

## **偵測不支援的內嵌活頁簿格式**

Aspose.Slides 不支援可嵌入某些圖表的 Excel 二進位活頁簿（.xlsb）格式。您可以使用 [IChartData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdata/) 的 `get_EmbeddedWorkbookType` 方法，結合 [WorkbookType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/workbooktype/) 列舉，偵測不支援的格式並跳過那些圖表。

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
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
        // 嵌入式活頁簿為 .xlsb 格式，尚不支援。
        continue;
    }

    // 在此讀取或修改圖表活頁簿資料。
}
```

## **外部活頁簿**

{{% alert color="primary" %}} 
在 [Aspose.Slides](https://releases.aspose.com/slides/zh-hant/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4 版中，我們實作了對外部活頁簿作為圖表資料來源的支援。 
{{% /alert %}} 

### **建立外部活頁簿**

使用 **`ReadWorkbookStream`** 與 **`SetExternalWorkbook`** 方法，您可以從頭建立外部活頁簿，或將內部活頁簿轉為外部活頁簿。

此 C++ 程式碼示範外部活頁簿的建立流程：

```c++
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

### **設定外部活頁簿**

使用 **`IChartData::SetExternalWorkbook`** 方法，您可以將外部活頁簿指派給圖表作為資料來源。此方法亦可用於更新外部活頁簿的路徑（如果該檔案已搬移）。

雖然無法編輯儲存在遠端位置或資源中的活頁簿資料，但仍可將此類活頁簿作為外部資料來源使用。如果提供相對路徑，系統會自動轉換為完整路徑。

此 C++ 程式碼說明如何設定外部活頁簿：

```c++
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

`SetExternalWorkbook` 方法中的 `updateChartData` 參數用來指定是否載入 Excel 活頁簿。

* 當 `updateChartData` 設為 `false` 時，僅會更新活頁簿路徑——圖表資料不會從目標活頁簿載入或更新。若目標活頁簿不存在或無法取得，建議使用此設定。  
* 當 `updateChartData` 設為 `true` 時，圖表資料會從目標活頁簿更新。

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **取得圖表的外部資料來源活頁簿路徑**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。  
1. 透過索引取得投影片的參考。  
1. 建立圖表形狀的物件。  
1. 建立代表圖表資料來源的 `ChartDataSourceType` 物件。  
1. 依據來源類型與外部活頁簿資料來源類型相同，指定相關條件。

此 C++ 程式碼示範上述操作：

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// Saves the presentation
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **編輯圖表資料**

您可以像編輯內部活頁簿內容一樣編輯外部活頁簿的資料。若無法載入外部活頁簿，會拋出例外。

此 C++ 程式碼實作了上述流程：

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **從圖表快取恢復活頁簿**

如果圖表使用的外部活頁簿遺失或無法取得，Aspose.Slides 可以從簡報中快取的資料重建圖表活頁簿。建立 [LoadOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/)，使用 [set_SpreadsheetOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) 進行設定，並在開啟簡報前將 [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) 設為 `true`。

以下 C++ 範例開啟一個圖表參照不可取得外部活頁簿的簡報，並透過 [IChart::get_ChartData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichart/get_chartdata/) 與 [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) 取得恢復的資料：

```cpp
auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto chart = System::ExplicitCast<IChart>(shape);

auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Read or modify the recovered workbook data here.

presentation->Dispose();
```

若外部活頁簿不可取得且未啟用恢復，Aspose.Slides 會拋出 `System::InvalidOperationException`。僅在接受以快取圖表資料作為可接受的備援時才啟用恢復，因為快取可能不包含簡報最後一次更新後對外部活頁簿所做的變更。

## **常見問題**

**我能判斷特定圖表是連結到外部活頁簿還是內嵌活頁簿嗎？**

可以。圖表具有 [data source type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) 與 [path to an external workbook](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/)，若來源為外部活頁簿，您可以讀取完整路徑以確認使用的是外部檔案。

**是否支援外部活頁簿的相對路徑？它們如何被儲存？**

支援。若您提供相對路徑，系統會自動轉換為絕對路徑。這對專案可攜性很有幫助；但請注意簡報會在 PPTX 檔案中儲存絕對路徑。

**我可以使用位於網路資源/共用資料夾的活頁簿嗎？**

可以，這類活頁簿可作為外部資料來源。但直接從 Aspose.Slides 編輯遠端活頁簿並不受支援——只能作為來源使用。

**Aspose.Slides 在儲存簡報時會覆寫外部 XLSX 嗎？**

不會。簡報僅儲存 [link to the external file](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/)，並於讀取資料時使用該連結。儲存簡報時不會修改外部檔案本身。

**如果外部檔案受密碼保護，我該怎麼辦？**

Aspose.Slides 連結時不接受密碼。常見做法是事先移除保護或先建立一個已解密的副本（例如使用 [Aspose.Cells](/cells/cpp/)），再連結至該副本。

**多個圖表可以參照同一個外部活頁簿嗎？**

可以。每個圖表都會儲存各自的連結。若它們指向同一檔案，更新該檔案後，下次載入資料時所有圖表都會反映變更。