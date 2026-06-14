---
title: Quản lý sổ làm việc biểu đồ trong bản trình chiếu bằng С++
linktitle: Sổ làm việc biểu đồ
type: docs
weight: 70
url: /vi/cpp/chart-workbook/
keywords:
- sổ làm việc biểu đồ
- dữ liệu biểu đồ
- ô sổ làm việc
- nhãn dữ liệu
- bảng tính
- nguồn dữ liệu
- sổ làm việc ngoại vi
- dữ liệu ngoại vi
- PowerPoint
- bản trình chiếu
- С++
- Aspose.Slides
description: "Khám phá Aspose.Slides cho С++: quản lý sổ làm việc biểu đồ trong PowerPoint và định dạng OpenDocument một cách dễ dàng để tối ưu dữ liệu bản trình chiếu của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sổ làm việc biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua luồng sổ làm việc, sử dụng các ô sổ làm việc làm nhãn dữ liệu biểu đồ, truy cập bộ sưu tập worksheet, và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng đề cập đến việc làm việc với các sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một sổ làm việc ngoại vi, lấy đường dẫn của sổ làm việc ngoại vi được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi sổ làm việc có sẵn.

## **Đọc và ghi dữ liệu biểu đồ từ sổ làm việc**

Aspose.Slides cung cấp các phương thức [ReadWorkbookStream](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) và [WriteWorkbookStream](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) cho phép bạn đọc và ghi sổ làm việc dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã được chỉnh sửa bằng Aspose.Cells). **Lưu ý** rằng dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc phải có cấu trúc tương tự như nguồn.

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

Đoạn mã C++ này minh họa thao tác thiết lập sổ làm việc dữ liệu biểu đồ:

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

## **Đặt ô WorkBook làm Nhãn Dữ liệu Biểu đồ**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Thêm một biểu đồ Bubble với một số dữ liệu.
4. Truy cập vào chuỗi biểu đồ.
5. Đặt ô sổ làm việc làm nhãn dữ liệu.
6. Lưu bản trình chiếu.

Đoạn mã C++ này cho bạn cách đặt một ô sổ làm việc làm nhãn dữ liệu cho biểu đồ:

``` cpp
System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// Khởi tạo một lớp Presentation đại diện cho tệp bản trình chiếu 
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

## **Quản lý Worksheet**

Đoạn mã C++ này minh họa một thao tác trong đó phương thức [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) được sử dụng để truy cập bộ sưu tập worksheet:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **Chỉ định Loại Nguồn Dữ liệu**

Đoạn mã C++ này cho bạn cách chỉ định một loại cho nguồn dữ liệu:

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

## **Phát hiện Định dạng Sổ làm việc Nhúng Không được Hỗ trợ**

Aspose.Slides không hỗ trợ định dạng sổ làm việc nhị phân Excel (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng phương thức `get_EmbeddedWorkbookType` trên [IChartData](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdata/) cùng với enumeration [WorkbookType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua các biểu đồ đó.

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
        // Sổ làm việc nhúng ở định dạng .xlsb, không được hỗ trợ.
        continue;
    }

    // Đọc hoặc sửa đổi dữ liệu sổ làm việc biểu đồ tại đây.
}
```

## **Sổ làm việc Ngoại vi**

{{% alert color="primary" %}} 
Trong [Aspose.Slides](https://releases.aspose.com/slides/vi/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4, chúng tôi đã triển khai hỗ trợ cho sổ làm việc ngoại vi làm nguồn dữ liệu cho biểu đồ.
{{% /alert %}} 

### **Tạo một Sổ làm việc Ngoại vi**

Sử dụng các phương thức **`ReadWorkbookStream`** và **`SetExternalWorkbook`**, bạn có thể tạo một sổ làm việc ngoại vi từ đầu hoặc chuyển một sổ làm việc nội bộ thành ngoại vi.

Đoạn mã C++ này minh họa quy trình tạo sổ làm việc ngoại vi:

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

### **Gán một Sổ làm việc Ngoại vi**

Sử dụng phương thức **`IChartData::SetExternalWorkbook`**, bạn có thể gán một sổ làm việc ngoại vi cho biểu đồ làm nguồn dữ liệu. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới sổ làm việc ngoại vi (nếu sổ làm việc đó đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các sổ làm việc được lưu trữ ở vị trí hoặc tài nguyên từ xa, bạn vẫn có thể sử dụng các sổ làm việc đó làm nguồn dữ liệu ngoại vi. Nếu cung cấp đường dẫn tương đối cho một sổ làm việc ngoại vi, nó sẽ tự động được chuyển đổi thành đường dẫn đầy đủ.

Đoạn mã C++ này cho bạn cách gán một sổ làm việc ngoại vi:

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

Tham số `updateChartData` (được sử dụng trong phương thức `SetExternalWorkbook`) dùng để chỉ định có tải sổ làm việc Excel hay không.

* Khi giá trị của `updateChartData` được đặt thành `false`, chỉ đường dẫn sổ làm việc được cập nhật — dữ liệu biểu đồ sẽ không được tải hoặc cập nhật từ sổ làm việc mục tiêu. Bạn có thể muốn sử dụng cài đặt này khi sổ làm việc mục tiêu không tồn tại hoặc không khả dụng. 
* Khi giá trị của `updateChartData` được đặt thành `true`, dữ liệu biểu đồ sẽ được cập nhật từ sổ làm việc mục tiêu.

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **Lấy Đường dẫn Sổ làm việc Nguồn Dữ liệu Ngoại của Biểu đồ**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
2. Lấy tham chiếu của slide thông qua chỉ mục của nó.
3. Tạo một đối tượng cho hình dạng biểu đồ.
4. Tạo một đối tượng cho loại nguồn (`ChartDataSourceType`) đại diện cho nguồn dữ liệu của biểu đồ.
5. Chỉ định điều kiện liên quan dựa trên việc loại nguồn bằng với loại nguồn dữ liệu sổ làm việc ngoại vi.

Đoạn mã C++ này minh họa thao tác:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// Lưu bản trình chiếu
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **Chỉnh sửa Dữ liệu Biểu đồ**

Bạn có thể chỉnh sửa dữ liệu trong các sổ làm việc ngoại vi giống như cách bạn thay đổi nội dung của các sổ làm việc nội bộ. Khi không thể tải một sổ làm việc ngoại vi, một ngoại lệ sẽ được ném.

Đoạn mã C++ này là một triển khai của quy trình đã mô tả:

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Câu hỏi thường gặp**

**Tôi có thể xác định một biểu đồ cụ thể có liên kết đến sổ làm việc ngoại vi hay nhúng không?**

Có. Một biểu đồ có một [loại nguồn dữ liệu](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) và một [đường dẫn tới sổ làm việc ngoại vi](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); nếu nguồn là một sổ làm việc ngoại vi, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp ngoại vi đang được sử dụng.

**Các đường dẫn tương đối tới sổ làm việc ngoại vi có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển đổi thành đường dẫn tuyệt đối. Điều này tiện lợi cho việc di chuyển dự án; tuy nhiên, lưu ý rằng bản trình chiếu sẽ lưu đường dẫn tuyệt đối trong tệp PPTX.

**Tôi có thể sử dụng sổ làm việc nằm trên tài nguyên/mạng chia sẻ không?**

Có, các sổ làm việc như vậy có thể được dùng làm nguồn dữ liệu ngoại vi. Tuy nhiên, việc chỉnh sửa các sổ làm việc từ xa trực tiếp bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể được sử dụng làm nguồn.

**Aspose.Slides có ghi đè lên tệp XLSX ngoại vi khi lưu bản trình chiếu không?**

Không. Bản trình chiếu lưu một [liên kết tới tệp ngoại vi](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) và sử dụng nó để đọc dữ liệu. Tệp ngoại vi tự nó không bị thay đổi khi bản trình chiếu được lưu.

**Tôi nên làm gì nếu tệp ngoại vi được bảo vệ bằng mật khẩu?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách thường được dùng là gỡ bỏ bảo vệ trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, sử dụng [Aspose.Cells](/cells/cpp/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một sổ làm việc ngoại vi không?**

Có. Mỗi biểu đồ lưu trữ liên kết riêng của nó. Nếu tất cả đều trỏ đến cùng một tệp, việc cập nhật tệp đó sẽ được phản ánh trong từng biểu đồ lần tiếp theo dữ liệu được tải.