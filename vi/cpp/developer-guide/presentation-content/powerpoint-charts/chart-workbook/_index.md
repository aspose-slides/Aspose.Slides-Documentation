---
title: Quản lý Workbook biểu đồ trong bản trình chiếu sử dụng C++
linktitle: Workbook biểu đồ
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
- bộ nhớ đệm biểu đồ
- khôi phục workbook
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Khám phá Aspose.Slides cho C++: quản lý workbook biểu đồ trong các định dạng PowerPoint và OpenDocument một cách dễ dàng để tối ưu hóa dữ liệu bản trình chiếu của bạn."
---
## **Tổng quan**

Bài viết sẽ giải thích cách làm việc với chart workbooks trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua luồng workbook, sử dụng các ô workbook làm nhãn dữ liệu biểu đồ, truy cập các bộ sưu tập worksheet, và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.

Bài viết cũng đề cập đến việc làm việc với workbook bên ngoài làm nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một workbook bên ngoài, lấy đường dẫn của workbook bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi workbook khả dụng.

Đối với các ô workbook đại diện cho dữ liệu thiếu, xem [Control the Display of Empty Cells](/slides/vi/cpp/chart-series/) để biết sự khác nhau giữa ô trống và số 0, và so sánh trong biểu đồ đường các chế độ hiển thị có sẵn.

## **Bao gồm dữ liệu từ các hàng và cột ẩn**

Sử dụng [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) để kiểm soát liệu biểu đồ có vẽ dữ liệu từ các hàng và cột worksheet ẩn hay không. Đặt thành `true` để chỉ vẽ các ô hiển thị, hoặc `false` để bao gồm cả ô hiển thị và ẩn. Cài đặt này điều khiển việc vẽ biểu đồ; nó không ẩn hoặc hiện lại các hàng hoặc cột worksheet.

Tải xuống [hidden-source-data.pptx](hidden-source-data.pptx) và đặt nó vào thư mục làm việc. Slide đầu tiên chứa một biểu đồ cột là shape đầu tiên. Worksheet nhúng, `Sheet1`, chứa phạm vi nguồn sau, `A1:C4`. Hàng 3 và cột C bị ẩn, nhưng các ô của chúng vẫn có giá trị.

| Hàng worksheet | A: Tháng | B: Bán lẻ | C: Bán buôn (cột ẩn) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

Truy cập các ô nguồn thông qua [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) và đọc [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) để kiểm tra trạng thái ẩn của chúng. Thuộc tính này chỉ đọc. Trong tệp này, B2 hiển thị, B3 thuộc hàng ẩn, và C2 thuộc cột ẩn; ví dụ in ra `False`, `True`, và `True` tương ứng.

Đối với ví dụ này, làm mới dữ liệu biểu đồ sau khi thay đổi cài đặt vẽ: giữ lại workbook nhúng bằng [ReadWorkbookStream](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) và tải lại bằng [WriteWorkbookStream](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/). Khi bao gồm tất cả các ô, cũng sử dụng [SetRange](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdata/setrange/) để khôi phục lại toàn bộ phạm vi, bao gồm danh mục tháng February bị ẩn. Chỉ thay đổi cờ không đủ để làm mới dữ liệu biểu đồ và nhãn danh mục được lưu trong bộ nhớ đệm của mẫu này.

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

        // Làm mới dữ liệu biểu đồ từ workbook nhúng.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Khôi phục toàn bộ phạm vi nguồn, bao gồm các danh mục ẩn.
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

Ví dụ lưu `hidden_cells_True.pptx` chỉ với các giá trị Bán lẻ hiển thị (10 và 20), và `hidden_cells_False.pptx` với cả sáu giá trị. Các hình ảnh dưới đây minh họa hai chế độ vẽ. Hàng 3 và cột C vẫn ẩn trong cả hai workbook nhúng.

| Chỉ các ô hiển thị (`true`) | Tất cả các ô (`false`) |
| --- | --- |
| ![Chỉ các ô hiển thị: Giá trị Bán lẻ 10 và 20 cho tháng January và March.](hidden_cells_True.png) | ![Tất cả các ô: Giá trị Bán lẻ và Bán buôn cho tháng January, February và March.](hidden_cells_False.png) |

Một ô ẩn có chứa giá trị khác với một ô trống. [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichart/get_displayblanksas/) kiểm soát cách hiển thị các giá trị thiếu; nó không bao gồm hoặc loại trừ dữ liệu nguồn ẩn. Xem [Control the Display of Empty Cells](/slides/vi/cpp/chart-series/#control-the-display-of-empty-cells) để biết ví dụ.

## **Đọc và ghi dữ liệu biểu đồ từ một Workbook**

Aspose.Slides for C++ cung cấp các phương thức [ReadWorkbookStream](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) và [WriteWorkbookStream](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) cho phép bạn đọc và ghi các workbook dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã được chỉnh sửa bằng Aspose.Cells). **Lưu ý** rằng dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc phải có cấu trúc tương tự nguồn.

Ví dụ này mở `chart.pptx`, phải chứa một biểu đồ là shape đầu tiên trên slide đầu tiên. Nó đọc workbook nhúng vào một luồng, xóa các series và category hiện có, và ghi lại cùng một workbook. Các thay đổi vẫn ở trong bộ nhớ; ví dụ không lưu bản trình bày.

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

### **Xác thực bố cục biểu đồ sau khi chỉnh sửa Workbook**

Khi bạn thay thế một workbook nhúng bằng một workbook đã sửa đổi, biểu đồ vẫn giữ các bộ sưu tập series và category gốc. Sự không khớp này có thể gây lỗi cho [IChart::ValidateChartLayout](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichart/validatechartlayout/) với lỗi chỉ mục vượt ra ngoài phạm vi. Hãy xóa các series và category hiện có trước khi ghi workbook đã cập nhật trở lại biểu đồ. Ví dụ này yêu cầu `chart.pptx` có một biểu đồ là shape đầu tiên trên slide đầu tiên. Bình luận đánh dấu nơi sẽ chỉnh sửa workbook; ví dụ thực thi ghi lại workbook gốc và xác thực bố cục trong bộ nhớ.

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

    // Sửa đổi luồng workbook ở đây, ví dụ, sử dụng Aspose.Cells.

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

Việc xóa các bộ sưu tập loại bỏ các tham chiếu dữ liệu lỗi thời trước khi workbook được ghi lại. Hãy xây dựng lại bất kỳ ánh xạ series và category nào cần thiết cho workbook đã cập nhật trước khi sử dụng biểu đồ.

## **Đặt một ô Workbook làm nhãn dữ liệu biểu đồ**

Bạn có thể sử dụng văn bản từ các ô workbook làm nhãn dữ liệu cho biểu đồ. Các bước sau cho thấy cách liên kết các nhãn trong biểu đồ bubble với các ô trong workbook dữ liệu của nó.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Truy cập slide đầu tiên bằng chỉ mục bắt đầu từ 0.
3. Thêm một biểu đồ bubble với dữ liệu mặc định.
4. Truy cập series của biểu đồ.
5. Đặt ô workbook làm nhãn dữ liệu.
6. Lưu bản trình bày.

Ví dụ này mở `chart2.pptx`, phải chứa ít nhất một slide, và thêm một biểu đồ bubble với dữ liệu mặc định. Nó sử dụng các ô A10:A12 trên worksheet 0 cho ba nhãn đầu tiên trong series đầu tiên, bật nhãn từ ô, và lưu kết quả thành `resultchart.pptx`.

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

## **Quản lý Worksheets**

Phương thức [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) cung cấp quyền truy cập vào các worksheet trong một chart workbook. Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và in tên mỗi worksheet ra console.

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

## **Chỉ định loại nguồn dữ liệu**

Ví dụ này tạo một biểu đồ cột 3D với dữ liệu mặc định và đặt hai tên series bằng các nguồn dữ liệu khác nhau. Tên đầu tiên sử dụng một literal string; tên thứ hai sử dụng ô C1 trên worksheet 0. Kiểu liệt kê [DataSourceType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/datasourcetype/) chọn nguồn cho mỗi tên. Kết quả được lưu thành `pres.pptx`.

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

## **Phát hiện các định dạng Workbook nhúng không được hỗ trợ**

Aspose.Slides không hỗ trợ định dạng workbook nhị phân Excel (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng phương thức [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) trên [IChartData](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdata/) cùng với kiểu liệt kê [WorkbookType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua các biểu đồ đó. Ví dụ này kiểm tra các shape trên slide đầu tiên của `sample.pptx`, bỏ qua các shape không phải biểu đồ, và in thông báo chuẩn đoán cho mỗi biểu đồ có workbook .xlsb nhúng.

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

    // Đọc hoặc chỉnh sửa dữ liệu workbook biểu đồ được hỗ trợ ở đây.
}
```

## **Workbook bên ngoài**

Aspose.Slides hỗ trợ sử dụng workbook bên ngoài làm nguồn dữ liệu cho các biểu đồ.

### **Tạo một Workbook bên ngoài**

Sử dụng [ReadWorkbookStream](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) và [SetExternalWorkbook](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) để xuất một chart workbook nhúng ra file và liên kết biểu đồ với workbook bên ngoài đó.

Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định, ghi workbook của nó vào `externalWorkbook1.xlsx`, và đóng luồng xuất trước khi gán file làm nguồn dữ liệu cho biểu đồ. Nó lưu bản trình bày đã liên kết thành `externalWorkbook.pptx`.

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

### **Gán một Workbook bên ngoài**

Sử dụng phương thức [SetExternalWorkbook](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/), bạn có thể gán một workbook bên ngoài cho biểu đồ như nguồn dữ liệu của nó. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới workbook bên ngoài (nếu nó đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các workbook lưu trữ ở vị trí hoặc tài nguyên từ xa, bạn vẫn có thể sử dụng các workbook đó làm nguồn dữ liệu bên ngoài. Nếu cung cấp một đường dẫn tương đối cho workbook bên ngoài, nó sẽ tự động được chuyển thành đường dẫn đầy đủ.

Ví dụ này yêu cầu `externalWorkbook.xlsx` trong thư mục làm việc. Worksheet có tên `Sheet1` phải chứa một tên series trong B1, các tên danh mục trong A2:A4, và các giá trị số trong B2:B4. Ví dụ tạo một biểu đồ tròn, liên kết workbook, và sử dụng [SetRange](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdata/setrange/) để ánh xạ A1:B4 thành một series và ba danh mục. Nó lưu kết quả thành `Presentation_with_externalWorkbook.pptx`.

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

Tham số `updateChartData` của [SetExternalWorkbook](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) kiểm soát việc có tải workbook hay không.

* Khi `updateChartData` là `false`, chỉ cập nhật đường dẫn workbook. Dữ liệu biểu đồ không được tải hoặc cập nhật từ workbook mục tiêu, vì vậy workbook có thể không khả dụng.
* Khi `updateChartData` là `true`, dữ liệu biểu đồ được cập nhật từ workbook mục tiêu.

Ví dụ sau gán một URL placeholder với `updateChartData` đặt là `false`. Nó giữ dữ liệu mặc định của biểu đồ tròn và lưu bản trình bày mà không tải workbook không khả dụng.

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

### **Lấy đường dẫn Workbook nguồn dữ liệu bên ngoài của một biểu đồ**

Để xác định workbook được liên kết với một biểu đồ, trước tiên kiểm tra xem biểu đồ có sử dụng nguồn dữ liệu bên ngoài hay không. Nếu có, bạn có thể lấy đường dẫn workbook bằng các bước sau.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
2. Truy cập slide đầu tiên bằng chỉ mục bắt đầu từ 0.
3. Kiểm tra shape đầu tiên có phải là một biểu đồ hay không.
4. Đọc loại nguồn dữ liệu của biểu đồ.
5. Nếu nguồn là một workbook bên ngoài, đọc đường dẫn của nó.

Ví dụ này mở `externalWorkbook.pptx`, được tạo trong ví dụ trước, và kiểm tra shape đầu tiên trên slide đầu tiên. Nếu nó là một biểu đồ được liên kết với một workbook bên ngoài, ví dụ in [get_ExternalWorkbookPath](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) ra console. Sau đó nó lưu một bản sao của bản trình bày thành `Result.pptx`.

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

### **Chỉnh sửa dữ liệu biểu đồ**

Bạn có thể chỉnh sửa dữ liệu trong workbook bên ngoài giống như khi thay đổi nội dung của workbook nội bộ. Khi một workbook bên ngoài không thể được tải, một ngoại lệ sẽ được ném.

Ví dụ này yêu cầu `presentation.pptx` có một biểu đồ là shape đầu tiên trên slide đầu tiên và một workbook bên ngoài có thể truy cập. Nó đặt giá trị ô của điểm dữ liệu đầu tiên trong series đầu tiên thành 100 và lưu bản trình bày thành `presentation_out.pptx`. Việc chỉnh sửa giá trị ô có thể cập nhật file XLSX bên ngoài đã liên kết, vì vậy hãy sử dụng một bản sao nếu bạn cần giữ nguyên workbook gốc.

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

### **Phục hồi một Workbook từ bộ nhớ đệm của biểu đồ**

Nếu một biểu đồ sử dụng một workbook bên ngoài bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo workbook biểu đồ từ dữ liệu được lưu trong bộ nhớ đệm của bản trình bày. Tạo [LoadOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/), cấu hình nó với [set_SpreadsheetOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), và gọi [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) với `true` trước khi mở bản trình bày.

Ví dụ C++ sau mở `presentation.pptx`, shape đầu tiên trên slide đầu tiên phải là một biểu đồ tham chiếu tới một workbook bên ngoài không khả dụng, và truy cập dữ liệu đã phục hồi thông qua [IChart::get_ChartData](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichart/get_chartdata/) và [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

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

    // Đọc hoặc chỉnh sửa dữ liệu workbook đã khôi phục ở đây.
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Nếu workbook bên ngoài không khả dụng và chế độ phục hồi bị tắt, Aspose.Slides ném một [System::InvalidOperationException](https://reference.aspose.com/slides/vi/cpp/system/details_invalidoperationexception/). Hãy bật phục hồi chỉ khi việc sử dụng dữ liệu biểu đồ đã lưu trong bộ nhớ đệm là một giải pháp chấp nhận được, vì bộ nhớ đệm có thể không chứa các thay đổi được thực hiện trên workbook bên ngoài sau khi bản trình bày được cập nhật lần cuối.

## **Câu hỏi thường gặp**

**Tôi có thể xác định liệu một biểu đồ cụ thể có liên kết tới workbook bên ngoài hay workbook nhúng không?**

Có. Một biểu đồ có [data source type](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) và một [path to an external workbook](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); nếu nguồn là một workbook bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp bên ngoài đang được sử dụng.

**Các đường dẫn tương đối tới workbook bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Bản trình bày lưu đường dẫn tuyệt đối trong tệp PPTX, vì vậy việc di chuyển workbook có thể yêu cầu cập nhật liên kết.

**Tôi có thể sử dụng workbook nằm trên các nguồn tài nguyên/mạng chia sẻ không?**

Có, các workbook như vậy có thể được dùng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa trực tiếp workbook từ xa bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè file XLSX bên ngoài khi lưu bản trình bày không?**

Bản trình bày lưu một [link to the external file](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Việc chỉnh sửa dữ liệu biểu đồ dựa trên ô cũng có thể cập nhật file XLSX địa phương đã liên kết. Hãy sử dụng một bản sao của workbook nếu bản gốc phải được giữ nguyên.

**Nếu file bên ngoài được bảo vệ bằng mật khẩu, tôi phải làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách thường dùng là gỡ bảo vệ trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, dùng [Aspose.Cells](https://reference.aspose.com/cells/cpp/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một workbook bên ngoài không?**

Có. Mỗi biểu đồ lưu liên kết riêng của mình. Nếu chúng đều trỏ tới cùng một file, việc cập nhật file đó sẽ được phản ánh trong mỗi biểu đồ lần sau khi dữ liệu được tải.