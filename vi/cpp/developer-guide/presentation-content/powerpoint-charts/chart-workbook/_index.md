---
title: Quản lý Workbook Biểu đồ trong Bản trình bày bằng C++
linktitle: Workbook Biểu đồ
type: docs
weight: 70
url: /vi/cpp/chart-workbook/
keywords:
- workbook biểu đồ
- dữ liệu biểu đồ
- ô workbook
- nhãn dữ liệu
- bảng tính
- nguồn dữ liệu
- workbook bên ngoài
- dữ liệu bên ngoài
- bộ nhớ cache biểu đồ
- khôi phục workbook
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Khám phá Aspose.Slides cho C++: dễ dàng quản lý workbook biểu đồ trong các định dạng PowerPoint và OpenDocument để tối ưu dữ liệu bản trình bày của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sổ làm việc biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ qua luồng workbook, sử dụng các ô workbook làm nhãn dữ liệu biểu đồ, truy cập bộ sưu tập worksheet và chỉ định loại nguồn dữ liệu cho giá trị biểu đồ.

Nó cũng đề cập đến việc làm việc với workbook bên ngoài như là nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một workbook bên ngoài, lấy đường dẫn của workbook bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi workbook khả dụng.

## **Đọc và ghi dữ liệu biểu đồ từ một Workbook**

Aspose.Slides cung cấp các phương thức [ReadWorkbookStream](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) và [WriteWorkbookStream](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) cho phép bạn đọc và ghi workbook dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã được chỉnh sửa bằng Aspose.Cells). **Note** dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc phải có cấu trúc tương tự nguồn.

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

Mã C++ này minh họa thao tác đặt một workbook dữ liệu biểu đồ:

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

## **Đặt ô WorkBook làm Nhãn dữ liệu biểu đồ**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Thêm biểu đồ Bubble với một số dữ liệu.
4. Truy cập series của biểu đồ.
5. Đặt ô workbook làm nhãn dữ liệu.
6. Lưu bản trình bày.

Mã C++ này cho bạn cách đặt một ô workbook làm nhãn dữ liệu biểu đồ:

``` cpp
System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// Tạo một đối tượng lớp Presentation đại diện cho tệp bản trình bày 
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

## **Quản lý Worksheets**

Mã C++ này minh họa một thao tác trong đó phương thức [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) được sử dụng để truy cập bộ sưu tập worksheet:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **Chỉ định Loại nguồn dữ liệu**

Mã C++ này cho bạn cách chỉ định một loại cho nguồn dữ liệu:

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

## **Phát hiện Định dạng Workbook Nhúng không được hỗ trợ**

Aspose.Slides không hỗ trợ định dạng workbook nhị phân Excel (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng phương thức `get_EmbeddedWorkbookType` trên [IChartData](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdata/) cùng với enumeration [WorkbookType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua các biểu đồ đó.

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
        // Workbook nhúng ở định dạng .xlsb, không được hỗ trợ.
        continue;
    }

    // Đọc hoặc chỉnh sửa dữ liệu workbook của biểu đồ tại đây.
}
```

## **Workbook bên ngoài**

{{% alert color="primary" %}} 
Trong [Aspose.Slides](https://releases.aspose.com/slides/vi/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4, chúng tôi đã triển khai hỗ trợ workbooks bên ngoài làm nguồn dữ liệu cho biểu đồ.
{{% /alert %}} 

### **Tạo một Workbook bên ngoài**

Sử dụng các phương thức **`ReadWorkbookStream`** và **`SetExternalWorkbook`**, bạn có thể tạo một workbook bên ngoài từ đầu hoặc biến một workbook nội bộ thành bên ngoài.

Mã C++ này minh họa quá trình tạo workbook bên ngoài:

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

### **Đặt một Workbook bên ngoài**

Sử dụng phương thức **`IChartData::SetExternalWorkbook`**, bạn có thể gán một workbook bên ngoài cho biểu đồ như là nguồn dữ liệu của nó. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới workbook bên ngoài (nếu workbook đó đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các workbook được lưu trữ ở vị trí hoặc tài nguyên từ xa, bạn vẫn có thể sử dụng những workbook đó làm nguồn dữ liệu bên ngoài. Nếu cung cấp đường dẫn tương đối cho một workbook bên ngoài, nó sẽ tự động được chuyển đổi thành đường dẫn đầy đủ.

Mã C++ này cho bạn cách đặt một workbook bên ngoài:

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

Tham số `updateChartData` (được đặt dưới phương thức `SetExternalWorkbook`) được dùng để chỉ định liệu một workbook Excel có được tải hay không. 

* Khi giá trị `updateChartData` được đặt là `false`, chỉ đường dẫn workbook được cập nhật — dữ liệu biểu đồ sẽ không được tải hoặc cập nhật từ workbook đích. Bạn có thể muốn sử dụng cài đặt này khi workbook đích không tồn tại hoặc không khả dụng. 
* Khi giá trị `updateChartData` được đặt là `true`, dữ liệu biểu đồ sẽ được cập nhật từ workbook đích.

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **Lấy Đường dẫn Workbook Nguồn Dữ liệu Bên ngoài của một Biểu đồ**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Tạo một đối tượng cho hình dạng biểu đồ.
4. Tạo một đối tượng cho loại nguồn (`ChartDataSourceType`) đại diện cho nguồn dữ liệu của biểu đồ.
5. Chỉ định điều kiện phù hợp dựa trên việc loại nguồn giống với loại nguồn dữ liệu workbook bên ngoài.

Mã C++ này minh họa thao tác:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// Lưu bản trình bày
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **Chỉnh sửa Dữ liệu Biểu đồ**

Bạn có thể chỉnh sửa dữ liệu trong workbook bên ngoài theo cùng cách như khi thay đổi nội dung của workbook nội bộ. Khi một workbook bên ngoài không thể được tải, một ngoại lệ sẽ được ném.

Mã C++ này là một triển khai của quy trình đã mô tả:

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Khôi phục Workbook từ Bộ nhớ Cache của Biểu đồ**

Nếu một biểu đồ sử dụng một workbook bên ngoài bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo workbook biểu đồ từ dữ liệu đã được lưu trong bản trình bày. Tạo [LoadOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/), cấu hình nó với [set_SpreadsheetOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), và gọi [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) với `true` trước khi mở bản trình bày.

Ví dụ C++ sau mở một bản trình bày mà biểu đồ tham chiếu một workbook bên ngoài không khả dụng và truy cập dữ liệu đã được khôi phục qua [IChart::get_ChartData](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichart/get_chartdata/) và [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

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

Nếu workbook bên ngoài không khả dụng và tính năng khôi phục bị tắt, Aspose.Slides ném ra một `System::InvalidOperationException`. Chỉ bật tính năng khôi phục khi việc sử dụng dữ liệu biểu đồ đã được lưu trong cache là một dự phòng chấp nhận được, vì cache có thể không chứa các thay đổi được thực hiện trên workbook bên ngoài sau lần cập nhật bản trình bày cuối cùng.

## **Câu hỏi thường gặp**

**Tôi có thể xác định liệu một biểu đồ cụ thể có liên kết tới workbook bên ngoài hay nhúng không?**  
Có. Một biểu đồ có một [loại nguồn dữ liệu](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) và một [đường dẫn tới workbook bên ngoài](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); nếu nguồn là một workbook bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn một tệp bên ngoài đang được sử dụng.

**Các đường dẫn tương đối tới workbook bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**  
Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Điều này tiện lợi cho tính di động của dự án; tuy nhiên, hãy lưu ý rằng bản trình bày sẽ lưu đường dẫn tuyệt đối trong tệp PPTX.

**Tôi có thể sử dụng các workbook nằm trên tài nguyên/mạng chia sẻ không?**  
Có, các workbook đó có thể được dùng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa trực tiếp các workbook từ xa bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè lên file XLSX bên ngoài khi lưu bản trình bày không?**  
Không. Bản trình bày lưu một [liên kết tới file bên ngoài](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) và sử dụng liên kết này để đọc dữ liệu. File bên ngoài không bị thay đổi khi bản trình bày được lưu.

**Nếu file bên ngoài được bảo vệ bằng mật khẩu, tôi nên làm gì?**  
Aspose.Slides không chấp nhận mật khẩu khi tạo liên kết. Một cách thường dùng là gỡ bảo vệ trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, bằng cách sử dụng [Aspose.Cells](/cells/cpp/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một workbook bên ngoài không?**  
Có. Mỗi biểu đồ lưu liên kết riêng của mình. Nếu tất cả chúng đều trỏ tới cùng một file, việc cập nhật file sẽ được phản ánh trong mỗi biểu đồ khi dữ liệu được tải lại.