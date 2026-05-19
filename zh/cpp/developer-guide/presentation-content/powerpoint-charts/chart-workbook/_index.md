---
title: 使用 C++ 在演示文稿中管理图表工作簿
linktitle: 图表工作簿
type: docs
weight: 70
url: /zh/cpp/chart-workbook/
keywords:
- 图表工作簿
- 图表数据
- 工作簿单元格
- 数据标签
- 工作表
- 数据源
- 外部工作簿
- 外部数据
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解适用于 C++ 的 Aspose.Slides：轻松管理 PowerPoint 和 OpenDocument 格式中的图表工作簿，以简化演示文稿数据。"
---
## **概述**

本文说明了如何在 Aspose.Slides 中使用图表工作簿。演示了如何通过工作簿流读取和写入图表数据、使用工作簿单元格作为图表数据标签、访问工作表集合以及为图表数值指定数据源类型。

还介绍了将外部工作簿用作图表数据源的操作示例。示例展示了如何创建并分配外部工作簿、获取与图表关联的外部工作簿路径以及在工作簿可用时编辑图表数据。

## **从工作簿读取和写入图表数据**

Aspose.Slides 提供了 [ReadWorkbookStream](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) 和 [WriteWorkbookStream](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) 方法，可用于读取和写入图表数据工作簿（其中的图表数据可使用 Aspose.Cells 进行编辑）。**注意**：图表数据必须以相同方式组织，或具有类似于源的结构。

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

下面的 C++ 代码演示了设置图表数据工作簿的操作：

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

## **将工作簿单元格设为图表数据标签**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个带有数据的气泡图。  
4. 访问图表系列。  
5. 将工作簿单元格设为数据标签。  
6. 保存演示文稿。

下面的 C++ 代码展示了如何将工作簿单元格设为图表数据标签：

``` cpp
System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// 实例化一个表示演示文稿文件的 Presentation 类
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

下面的 C++ 代码演示了使用 [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) 方法访问工作表集合的操作：

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **指定数据源类型**

下面的 C++ 代码展示了如何为数据源指定类型：

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

## **检测不支持的嵌入式工作簿格式**

Aspose.Slides 不支持可以嵌入某些图表的 Excel 二进制工作簿（.xlsb）格式。您可以在 [IChartData](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdata/) 上使用 `get_EmbeddedWorkbookType` 方法，并结合 [WorkbookType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/workbooktype/) 枚举来检测不支持的格式并跳过这些图表。

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
        // 嵌入式工作簿为 .xlsb 格式，不受支持。
        continue;
    }

    // 在此读取或修改图表工作簿数据。
}
```

## **外部工作簿**

{{% alert color="primary" %}} 
在 [Aspose.Slides](https://releases.aspose.com/slides/zh/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4 版中，我们实现了对外部工作簿作为图表数据源的支持。 
{{% /alert %}} 

### **创建外部工作簿**

使用 **`ReadWorkbookStream`** 和 **`SetExternalWorkbook`** 方法，您可以从头创建外部工作簿，或将内部工作簿设为外部工作簿。

下面的 C++ 代码演示了外部工作簿的创建过程：

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

### **设置外部工作簿**

使用 **`IChartData::SetExternalWorkbook`** 方法，您可以将外部工作簿分配给图表作为其数据源。该方法还可用于更新外部工作簿的路径（如果工作簿已移动）。

虽然无法编辑存储在远程位置或资源中的工作簿数据，但仍可以将这些工作簿用作外部数据源。如果提供了外部工作簿的相对路径，系统会自动将其转换为完整路径。

下面的 C++ 代码展示了如何设置外部工作簿：

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

`SetExternalWorkbook` 方法中的 `updateChartData` 参数用于指定是否加载 Excel 工作簿。

* 当 `updateChartData` 设置为 `false` 时，仅更新工作簿路径——图表数据不会从目标工作簿加载或更新。若目标工作簿不存在或不可用，可使用此设置。  
* 当 `updateChartData` 设置为 `true` 时，图表数据会从目标工作簿进行更新。

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **获取图表的外部数据源工作簿路径**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 为图表形状创建对象。  
4. 为表示图表数据源的源类型（`ChartDataSourceType`）创建对象。  
5. 根据源类型与外部工作簿数据源类型相同的情况指定相应条件。

下面的 C++ 代码演示了该操作：

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

### **编辑图表数据**

您可以像编辑内部工作簿一样编辑外部工作簿中的数据。当外部工作簿无法加载时，会抛出异常。

下面的 C++ 代码实现了上述过程：

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **常见问题**

**我能判断特定图表是链接到外部工作簿还是嵌入式工作簿吗？**

可以。图表拥有 [data source type](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) 和 [path to an external workbook](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/)；如果源是外部工作簿，您可以读取完整路径以确认使用的是外部文件。

**是否支持外部工作簿的相对路径？它们是如何存储的？**

支持。若指定相对路径，系统会自动转换为绝对路径。这对项目可移植性很有帮助；但请注意，演示文稿会在 PPTX 文件中存储该绝对路径。

**可以使用位于网络资源/共享上的工作簿吗？**

可以，这类工作簿可作为外部数据源使用。但 Aspose.Slides 不支持直接编辑远程工作簿——只能将其用作数据源。

**保存演示文稿时，Aspose.Slides 会覆盖外部 XLSX 吗？**

不会。演示文稿仅存储 [link to the external file](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/)，在读取数据时使用该链接。保存演示文稿时不会修改外部文件本身。

**如果外部文件受密码保护该怎么办？**

Aspose.Slides 在链接时不接受密码。常见做法是事先移除保护或准备一个已解密的副本（例如使用 [Aspose.Cells](/cells/cpp/)），并链接到该副本。

**多个图表可以引用同一个外部工作簿吗？**

可以。每个图表都会存储自己的链接。如果它们都指向同一文件，更新该文件后，下次加载数据时所有图表都会反映出更改。