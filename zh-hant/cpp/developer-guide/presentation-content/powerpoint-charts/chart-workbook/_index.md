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
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "探索 Aspose.Slides for C++：輕鬆在 PowerPoint 與 OpenDocument 格式中管理圖表工作簿，簡化簡報資料。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圖表工作簿。它展示了如何透過工作簿串流讀寫圖表資料、使用工作簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

此外，本文還涵蓋了將外部工作簿作為圖表資料來源的使用方式。範例說明了如何建立並指派外部工作簿、取得與圖表連結的外部工作簿路徑，以及在工作簿可取得時編輯圖表資料。

## **從工作簿讀寫圖表資料**

Aspose.Slides 提供了 [ReadWorkbookStream](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) 與 [WriteWorkbookStream](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) 方法，可讓您讀寫圖表資料工作簿（其中的圖表資料可由 Aspose.Cells 編輯）。**注意** 圖表資料必須以相同的方式組織，或具有類似於來源的結構。

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

此 C++ 程式碼示範設定圖表資料工作簿的操作：

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

## **將工作簿儲存格設為圖表資料標籤**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。  
1. 透過索引取得投影片的參考。  
1. 加入含有資料的 Bubble 圖表。  
1. 存取圖表系列。  
1. 將工作簿儲存格設定為資料標籤。  
1. 儲存簡報。

此 C++ 程式碼示範如何將工作簿儲存格設為圖表資料標籤：

``` cpp
System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// 實例化表示簡報檔案的 Presentation 類別 
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

此 C++ 程式碼示範如何為資料來源指定類型：

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

## **偵測不支援的內嵌工作簿格式**

Aspose.Slides 不支援可嵌入某些圖表的 Excel 二進位工作簿（.xlsb）格式。您可以在 [IChartData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdata/) 上使用 `get_EmbeddedWorkbookType` 方法，搭配 [WorkbookType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/workbooktype/) 列舉來偵測不支援的格式，並跳過這些圖表。

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
        // 內嵌工作簿為 .xlsb 格式，該格式不受支援。
        continue;
    }

    // 在此讀取或修改圖表工作簿資料。
}
```

## **外部工作簿**

{{% alert color="primary" %}} 
在 [Aspose.Slides](https://releases.aspose.com/slides/zh-hant/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4 版中，我們實作了對外部工作簿作為圖表資料來源的支援。 
{{% /alert %}} 

### **建立外部工作簿**

使用 **`ReadWorkbookStream`** 與 **`SetExternalWorkbook`** 方法，您可以從頭建立外部工作簿，或將內部工作簿轉為外部工作簿。

此 C++ 程式碼示範外部工作簿的建立流程：

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

### **設定外部工作簿**

使用 **`IChartData::SetExternalWorkbook`** 方法，您可以將外部工作簿指派為圖表的資料來源。此方法亦可用於更新外部工作簿的路徑（若該工作簿已搬移）。

雖然無法直接編輯儲存在遠端位置或資源中的工作簿資料，但仍可將此類工作簿作為外部資料來源使用。若提供外部工作簿的相對路徑，系統會自動轉換為完整路徑。

此 C++ 程式碼示範如何設定外部工作簿：

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

`updateChartData` 參數（位於 `SetExternalWorkbook` 方法下）用於指定是否載入 Excel 工作簿。

* 當 `updateChartData` 值設定為 `false` 時，僅更新工作簿路徑——圖表資料不會從目標工作簿載入或更新。當目標工作簿不存在或無法取得時，您可能會使用此設定。  
* 當 `updateChartData` 值設定為 `true` 時，圖表資料會從目標工作簿更新。

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **取得圖表的外部資料來源工作簿路徑**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。  
1. 透過索引取得投影片的參考。  
1. 為圖表圖形建立物件。  
1. 為來源（`ChartDataSourceType`）類型建立物件，該類型代表圖表的資料來源。  
1. 根據來源類型與外部工作簿資料來源類型相同的情況，指定相關條件。

此 C++ 程式碼示範此操作：

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// 儲存簡報
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **編輯圖表資料**

您可以像編輯內部工作簿內容一樣編輯外部工作簿的資料。若無法載入外部工作簿，則會拋出例外。

此 C++ 程式碼實作上述流程：

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **常見問題**

**我能否判斷特定圖表是連結到外部工作簿還是內嵌工作簿？**

可以。圖表具有 [資料來源類型](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) 與 [外部工作簿路徑](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/)；若來源是外部工作簿，您可以讀取完整路徑以確認使用的是外部檔案。

**是否支援外部工作簿的相對路徑，且它們如何被儲存？**

支援。若您指定相對路徑，系統會自動轉換為絕對路徑。這對於專案可移植性很方便；但請留意，簡報會將絕對路徑儲存在 PPTX 檔案中。

**我可以使用位於網路資源/共享中的工作簿嗎？**

可以，這類工作簿可作為外部資料來源。但直接從 Aspose.Slides 編輯遠端工作簿並不受支援——只能將其作為來源使用。

**儲存簡報時，Aspose.Slides 會覆寫外部 XLSX 檔案嗎？**

不會。簡報會儲存一個 [指向外部檔案的連結](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/)，並在讀取資料時使用該連結。儲存簡報時不會修改外部檔案本身。

**如果外部檔案受密碼保護，我該怎麼辦？**

Aspose.Slides 在連結時不接受密碼。常見做法是事先移除保護，或先產生一個已解密的副本（例如使用 [Aspose.Cells](/cells/cpp/)），再連結至該副本。

**多個圖表可以參考同一個外部工作簿嗎？**

可以。每個圖表都會儲存自己的連結。如果它們都指向相同的檔案，更新該檔案後，下次載入資料時所有圖表皆會反映此變更。