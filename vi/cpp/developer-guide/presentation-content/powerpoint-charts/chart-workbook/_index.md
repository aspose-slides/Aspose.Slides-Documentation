---
title: Quản lý Sổ làm việc Biểu đồ trong Bản trình chiếu sử dụng C++
linktitle: Sổ làm việc Biểu đồ
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
- sổ làm việc bên ngoài
- dữ liệu bên ngoài
- bộ nhớ đệm biểu đồ
- khôi phục sổ làm việc
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Khám phá Aspose.Slides cho C++: dễ dàng quản lý sổ làm việc biểu đồ trong các định dạng PowerPoint và OpenDocument để tối ưu hoá dữ liệu bản trình chiếu của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sổ làm việc biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua luồng sổ làm việc, sử dụng các ô sổ làm việc làm nhãn dữ liệu biểu đồ, truy cập các bộ sưu tập worksheet, và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng đề cập đến việc làm việc với sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một sổ làm việc bên ngoài, lấy đường dẫn của sổ làm việc bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi sổ làm việc khả dụng.

Đối với các ô sổ làm việc đại diện cho dữ liệu thiếu, hãy xem mục [Control the Display of Empty Cells](/slides/vi/cpp/chart-series/) để biết sự khác nhau giữa ô trống và số 0, và so sánh biểu đồ đường của các chế độ hiển thị có sẵn.

## **Bao gồm dữ liệu từ các hàng và cột ẩn**

Sử dụng [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) để kiểm soát việc biểu đồ vẽ dữ liệu từ các hàng và cột worksheet ẩn hay không. Đặt thành `true` để chỉ vẽ các ô hiển thị, hoặc `false` để bao gồm cả ô hiển thị và ẩn. Cài đặt này chỉ kiểm soát việc vẽ biểu đồ; nó không ẩn hoặc hiện các hàng hay cột worksheet.

[Sample presentation](hidden-source-data.pptx) chứa một biểu đồ cột là hình dạng đầu tiên trên slide đầu tiên. Worksheet được nhúng, `Sheet1`, có phạm vi nguồn sau, `A1:C4`. Hàng 3 và cột C bị ẩn, nhưng các ô của chúng vẫn chứa giá trị.

| Hàng worksheet | A: Tháng | B: Bán lẻ | C: Bán buôn (cột ẩn) |
| --- | --- | --- | --- |
| 2 | Tháng 1 | 10 | 30 |
| 3 (hàng ẩn) | Tháng 2 | 40 | 60 |
| 4 | Tháng 3 | 20 | 50 |

Truy cập các ô nguồn qua [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) và đọc [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) để kiểm tra trạng thái ẩn của chúng. Thuộc tính này chỉ đọc. Trong tệp này, B2 hiển thị, B3 thuộc hàng ẩn, và C2 thuộc cột ẩn; ví dụ in ra `False`, `True`, và `True` tương ứng.

Đối với ví dụ này, làm mới dữ liệu biểu đồ sau khi thay đổi cài đặt vẽ: giữ lại sổ làm việc được nhúng bằng [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) và tải lại bằng [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/). Khi bao gồm tất cả các ô, cũng sử dụng [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) để khôi phục phạm vi đầy đủ, bao gồm danh mục tháng 2 bị ẩn. Chỉ thay đổi cờ không đủ để làm mới dữ liệu biểu đồ và nhãn danh mục được lưu trong bộ nhớ cache của mẫu này.

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

        // Làm mới dữ liệu biểu đồ từ sổ làm việc được nhúng.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Khôi phục phạm vi nguồn đầy đủ, bao gồm các danh mục ẩn.
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

Ví dụ lưu hai phiên bản của bản trình chiếu: một chỉ có các giá trị Bán lẻ hiển thị (10 và 20), và một khác có tất cả sáu giá trị. Các hình ảnh dưới minh họa hai chế độ vẽ. Hàng 3 và cột C vẫn ẩn trong cả hai sổ làm việc được nhúng.

| Chỉ các ô hiển thị (`true`) | Tất cả các ô (`false`) |
| --- | --- |
| ![Chỉ các ô hiển thị: Giá trị Bán lẻ 10 và 20 cho Tháng 1 và Tháng 3.](hidden_cells_True.png) | ![Tất cả các ô: Giá trị Bán lẻ và Bán buôn cho Tháng 1, Tháng 2 và Tháng 3.](hidden_cells_False.png) |

Một ô ẩn chứa giá trị khác với ô trống. [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) kiểm soát cách hiển thị các giá trị thiếu; nó không bao gồm hay loại bỏ dữ liệu nguồn ẩn. Xem [Control the Display of Empty Cells](/slides/vi/cpp/chart-series/#control-the-display-of-empty-cells) để biết ví dụ.

## **Lấy phạm vi dữ liệu của biểu đồ**

Trước khi cập nhật dữ liệu sổ làm việc trong một bản trình chiếu hiện có, kiểm tra các phạm vi nguồn để xác định ô worksheet nào mà mỗi biểu đồ sử dụng. Phương thức [IChartData::GetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) trả về phạm vi dữ liệu hiện tại dưới dạng công thức có định danh worksheet, chẳng hạn `Sheet1!$A$1:$D$5`. Ở đây, `Sheet1` là tên worksheet, `!` ngăn cách nó với phạm vi ô, và `$A$1:$D$5` xác định các ô từ A1 đến D5, bao gồm cả hai. Dấu `$` chỉ tham chiếu tuyệt đối cho hàng và cột.

Phương thức đọc phạm vi hiện tại mà không thay đổi biểu đồ hay sổ làm việc. Nếu biểu đồ không sử dụng sổ làm việc làm nguồn dữ liệu, nó sẽ ném ra [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/). Để biết thêm chi tiết, hãy xem [ChartData API Reference](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/).

Ví dụ này mở một bản trình chiếu và kiểm tra các hình dạng trực tiếp trên mỗi slide để tìm biểu đồ. Nó in ra tên và phạm vi nguồn của mỗi biểu đồ. Nếu một biểu đồ không sử dụng sổ làm việc, nó sẽ in thông báo và tiếp tục sang biểu đồ tiếp theo.

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

## **Đọc và ghi dữ liệu biểu đồ từ sổ làm việc**

Aspose.Slides for C++ cung cấp các phương thức [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) và [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) cho phép bạn đọc và ghi sổ làm việc dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã được chỉnh sửa bằng Aspose.Cells). **Lưu ý** rằng dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc có cấu trúc tương tự như nguồn.

Ví dụ này sử dụng một bản trình chiếu có biểu đồ là hình dạng đầu tiên trên slide đầu tiên. Nó đọc sổ làm việc được nhúng vào một luồng, xóa các series và category hiện có, và ghi lại cùng một sổ làm việc. Các thay đổi vẫn ở trong bộ nhớ; ví dụ không lưu bản trình chiếu.

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

### **Xác thực bố cục biểu đồ sau khi sửa đổi sổ làm việc**

Khi bạn thay thế sổ làm việc được nhúng bằng một sổ làm việc đã sửa đổi, biểu đồ vẫn giữ các bộ sưu tập series và category gốc. Sự không khớp này có thể khiến [IChart::ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) thất bại với lỗi chỉ mục vượt quá phạm vi. Hãy xóa các series và category hiện có trước khi ghi lại sổ làm việc đã cập nhật vào biểu đồ. Ví dụ này sử dụng một biểu đồ là hình dạng đầu tiên trên slide đầu tiên. Các chú thích đánh dấu nơi sẽ thực hiện việc chỉnh sửa sổ làm việc; ví dụ chạy được sẽ ghi lại sổ làm việc gốc và xác thực bố cục trong bộ nhớ.

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

    // Sửa đổi stream sổ làm việc ở đây, ví dụ sử dụng Aspose.Cells.

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

Xóa các bộ sưu tập sẽ loại bỏ các tham chiếu dữ liệu cũ trước khi sổ làm việc được ghi lại. Hãy xây dựng lại bất kỳ series và ánh xạ category cần thiết nào cho sổ làm việc đã cập nhật trước khi sử dụng biểu đồ.

## **Đặt ô sổ làm việc làm nhãn dữ liệu biểu đồ**

Bạn có thể sử dụng văn bản từ các ô sổ làm việc làm nhãn dữ liệu biểu đồ.

Ví dụ này thêm một biểu đồ bong bóng với dữ liệu mặc định vào slide đầu tiên của một bản trình chiếu hiện có. Nó sử dụng các ô A10:A12 trên worksheet 0 cho ba nhãn đầu tiên trong series đầu tiên, bật nhãn từ ô, và lưu bản trình chiếu đã cập nhật.

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

Phương thức [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) cung cấp quyền truy cập vào các worksheet trong sổ làm việc biểu đồ. Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và in ra tên mỗi worksheet lên console.

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

Ví dụ này tạo một biểu đồ cột 3D với dữ liệu mặc định và đặt hai tên series bằng các nguồn dữ liệu khác nhau. Tên đầu tiên sử dụng chuỗi ký tự, tên thứ hai sử dụng ô C1 trên worksheet 0. Phân loại [DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) xác định nguồn cho mỗi tên. Ví dụ lưu bản trình chiếu với các tên series đã cập nhật.

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

## **Phát hiện định dạng sổ làm việc được nhúng không được hỗ trợ**

Aspose.Slides không hỗ trợ định dạng sổ làm việc Excel nhị phân (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể dùng phương thức [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) trên [IChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/) kết hợp với phân loại [WorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/) để phát hiện các định dạng không hỗ trợ và bỏ qua những biểu đồ đó. Ví dụ này kiểm tra các hình dạng trên slide đầu tiên của một bản trình chiếu hiện có, bỏ qua các hình không phải biểu đồ, và in ra thông báo chẩn đoán cho mỗi biểu đồ có sổ làm việc .xlsb được nhúng.

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

    // Đọc hoặc chỉnh sửa dữ liệu sổ làm việc biểu đồ được hỗ trợ tại đây.
}
```

## **Sổ làm việc bên ngoài**

Aspose.Slides hỗ trợ sử dụng sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ.

### **Tạo sổ làm việc bên ngoài**

Sử dụng [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) và [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) để xuất sổ làm việc biểu đồ được nhúng ra file và liên kết biểu đồ tới sổ làm việc bên ngoài đó.

Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và xuất sổ làm việc của nó. Nó đóng luồng xuất trước khi gán sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ, sau đó lưu bản trình chiếu đã liên kết.

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

### **Đặt sổ làm việc bên ngoài**

Bằng cách dùng phương thức [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/), bạn có thể gán một sổ làm việc bên ngoài cho biểu đồ làm nguồn dữ liệu. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới sổ làm việc bên ngoài (nếu sổ đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các sổ làm việc được lưu trữ ở vị trí từ xa hoặc tài nguyên, bạn vẫn có thể dùng những sổ này làm nguồn dữ liệu bên ngoài. Nếu cung cấp đường dẫn tương đối cho sổ làm việc bên ngoài, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối.

Ví dụ này sử dụng một sổ làm việc bên ngoài có worksheet tên `Sheet1` chứa tên series ở B1, tên danh mục ở A2:A4, và các giá trị số ở B2:B4. Ví dụ tạo một biểu đồ tròn, liên kết sổ làm việc, và dùng [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) để ánh xạ A1:B4 thành một series và ba danh mục. Nó lưu bản trình chiếu với biểu đồ được liên kết.

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

Tham số `updateChartData` của [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) kiểm soát việc có tải sổ làm việc hay không.

* Khi `updateChartData` là `false`, chỉ cập nhật đường dẫn sổ làm việc. Dữ liệu biểu đồ không được tải hoặc cập nhật từ sổ làm việc đích, nên sổ làm việc có thể không tồn tại.
* Khi `updateChartData` là `true`, dữ liệu biểu đồ được cập nhật từ sổ làm việc đích.

Ví dụ sau gán một URL placeholder với `updateChartData` đặt thành `false`. Nó giữ dữ liệu mặc định của biểu đồ tròn và lưu bản trình chiếu mà không tải sổ làm việc không khả dụng.

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

### **Lấy đường dẫn sổ làm việc nguồn dữ liệu bên ngoài của biểu đồ**

Để xác định sổ làm việc được liên kết với một biểu đồ, kiểm tra xem biểu đồ có sử dụng nguồn dữ liệu bên ngoài không và lấy đường dẫn sổ làm việc của nó.

Ví dụ này kiểm tra hình dạng đầu tiên trên slide đầu tiên của một bản trình chiếu có sổ làm việc bên ngoài được liên kết. Nếu đó là một biểu đồ được liên kết với sổ làm việc bên ngoài, ví dụ sẽ in [get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) lên console. Sau đó nó lưu một bản sao của bản trình chiếu.

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

Bạn có thể chỉnh sửa dữ liệu trong sổ làm việc bên ngoài giống như khi thay đổi nội dung của sổ làm việc nội bộ. Khi một sổ làm việc bên ngoài không thể tải, một ngoại lệ sẽ được ném ra.

Ví dụ này sử dụng một biểu đồ là hình dạng đầu tiên trên slide đầu tiên và được liên kết với một sổ làm việc bên ngoài có thể truy cập. Nó đặt giá trị dựa trên ô của điểm dữ liệu đầu tiên trong series đầu tiên thành 100 và lưu bản trình chiếu đã cập nhật. Việc chỉnh sửa giá trị ô có thể cập nhật file XLSX bên ngoài được liên kết, vì vậy hãy sử dụng bản sao nếu bạn cần giữ nguyên sổ làm việc gốc.

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

### **Khôi phục sổ làm việc từ bộ nhớ cache của biểu đồ**

Nếu một biểu đồ sử dụng sổ làm việc bên ngoài bị mất hoặc không khả dụng, Aspose.Slides có thể tái tạo sổ làm việc biểu đồ từ dữ liệu được cache trong bản trình chiếu. Tạo [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/), cấu hình nó với [set_SpreadsheetOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), và gọi [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) với `true` trước khi mở bản trình chiếu.

Ví dụ C++ sau khôi phục dữ liệu sổ làm việc cho một biểu đồ là hình dạng đầu tiên trên slide đầu tiên và tham chiếu đến một sổ làm việc bên ngoài không khả dụng. Nó truy cập dữ liệu đã khôi phục qua [IChart::get_ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) và [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

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

    // Đọc hoặc chỉnh sửa dữ liệu sổ làm việc đã khôi phục ở đây.
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Nếu sổ làm việc bên ngoài không khả dụng và khôi phục bị tắt, Aspose.Slides sẽ ném ra [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/). Chỉ bật khôi phục khi việc sử dụng dữ liệu biểu đồ đã cache là giải pháp chấp nhận được, vì cache có thể không chứa các thay đổi đã thực hiện trên sổ làm việc bên ngoài sau lần cập nhật cuối cùng của bản trình chiếu.

## **FAQ**

**Tôi có thể xác định được một biểu đồ cụ thể có được liên kết với sổ làm việc bên ngoài hay là sổ làm việc được nhúng không?**

Có. Một biểu đồ có [data source type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) và một [path to an external workbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); nếu nguồn là sổ làm việc bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp ngoại vi đang được sử dụng.

**Các đường dẫn tương đối tới sổ làm việc bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Bản trình chiếu lưu đường dẫn tuyệt đối trong file PPTX, vì vậy việc di chuyển sổ làm việc có thể yêu cầu cập nhật liên kết.

**Tôi có thể sử dụng sổ làm việc nằm trên tài nguyên/mạng chia sẻ không?**

Có, những sổ làm việc đó có thể được sử dụng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa sổ làm việc từ xa trực tiếp bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè lên file XLSX bên ngoài khi lưu bản trình chiếu không?**

Bản trình chiếu lưu một [link to the external file](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Việc chỉnh sửa dữ liệu biểu đồ dựa trên ô cũng có thể cập nhật file XLSX cục bộ đã liên kết. Hãy sử dụng bản sao của sổ làm việc nếu bản gốc phải được giữ nguyên.

**Nếu file bên ngoài được bảo mật bằng mật khẩu, tôi nên làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi tạo liên kết. Một cách thường được dùng là bỏ bảo mật trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, dùng [Aspose.Cells](https://reference.aspose.com/cells/cpp/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một sổ làm việc bên ngoài không?**

Có. Mỗi biểu đồ lưu liên kết riêng của mình. Nếu chúng đều trỏ tới cùng một tệp, việc cập nhật tệp sẽ được phản ánh trong mỗi biểu đồ vào lần tải dữ liệu tiếp theo.