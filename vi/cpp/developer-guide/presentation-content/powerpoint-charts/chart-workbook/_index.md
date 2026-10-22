---
title: Quản lý sổ làm việc biểu đồ trong bản trình chiếu bằng C++
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
- sổ làm việc bên ngoài
- dữ liệu bên ngoài
- bộ nhớ cache biểu đồ
- khôi phục sổ làm việc
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Khám phá Aspose.Slides cho C++: dễ dàng quản lý sổ làm việc biểu đồ trong các định dạng PowerPoint và OpenDocument để tối ưu hóa dữ liệu bản trình chiếu của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sách đồ thị trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu đồ thị thông qua luồng workbook, sử dụng các ô workbook làm nhãn dữ liệu đồ thị, truy cập các bộ sưu tập worksheet, và chỉ định kiểu nguồn dữ liệu cho các giá trị đồ thị.

Nó cũng bao gồm việc làm việc với các workbook bên ngoài làm nguồn dữ liệu cho đồ thị. Các ví dụ minh họa cách tạo và gán một workbook bên ngoài, lấy đường dẫn của workbook bên ngoài được liên kết với đồ thị, và chỉnh sửa dữ liệu đồ thị khi workbook khả dụng.

Đối với các ô workbook đại diện cho dữ liệu thiếu, xem [Kiểm soát việc hiển thị ô trống](/slides/vi/cpp/chart-series/) để biết sự khác biệt giữa ô trống và số 0, và so sánh biểu đồ đường của các chế độ hiển thị khả dụng.

## **Bao gồm dữ liệu từ các hàng và cột ẩn**

Sử dụng [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) để điều khiển việc đồ thị chỉ vẽ dữ liệu từ các hàng và cột worksheet được hiển thị. Đặt `true` để chỉ vẽ các ô hiển thị, hoặc `false` để bao gồm cả ô hiển thị và ô ẩn. Cài đặt này kiểm soát việc vẽ đồ thị; nó không ẩn hoặc hiện các hàng hoặc cột worksheet.

[Sample presentation](hidden-source-data.pptx) chứa một biểu đồ cột là hình dạng đầu tiên trên slide đầu tiên. Worksheet được nhúng, `Sheet1`, chứa phạm vi nguồn `A1:C4`. Hàng 3 và cột C bị ẩn, nhưng các ô của chúng vẫn chứa giá trị.

| Hàng worksheet | A: Tháng | B: Bán lẻ | C: Bán buôn (cột ẩn) |
| --- | --- | --- | --- |
| 2 | Tháng 1 | 10 | 30 |
| 3 (hàng ẩn) | Tháng 2 | 40 | 60 |
| 4 | Tháng 3 | 20 | 50 |

Truy cập các ô nguồn thông qua [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) và đọc [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) để kiểm tra trạng thái ẩn của chúng. Thuộc tính này chỉ đọc. Trong tệp này, B2 hiển thị, B3 thuộc hàng ẩn, và C2 thuộc cột ẩn; ví dụ in ra `False`, `True`, và `True` tương ứng.

Đối với ví dụ này, làm mới dữ liệu đồ thị sau khi thay đổi cài đặt vẽ: giữ lại workbook được nhúng bằng [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) và tải lại bằng [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/). Khi bao gồm tất cả các ô, cũng sử dụng [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) để khôi phục phạm vi đầy đủ, bao gồm danh mục tháng 2 bị ẩn. Chỉ thay đổi cờ không đủ để làm mới dữ liệu đồ thị và nhãn danh mục đã được lưu trong mẫu này.

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

        // Làm mới dữ liệu biểu đồ từ workbook được nhúng.
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

Ví dụ lưu hai phiên bản của bản trình bày: một phiên bản chỉ có các giá trị Bán lẻ hiển thị (10 và 20), và một phiên bản có tất cả sáu giá trị. Các hình ảnh dưới đây minh họa hai chế độ vẽ. Hàng 3 và cột C vẫn ẩn trong cả hai workbook được nhúng.

| Chỉ các ô hiển thị (`true`) | Tất cả các ô (`false`) |
| --- | --- |
| ![Chỉ các ô hiển thị: Giá trị Bán lẻ 10 và 20 cho Tháng 1 và Tháng 3.](hidden_cells_True.png) | ![Tất cả các ô: Giá trị Bán lẻ và Bán buôn cho Tháng 1, Tháng 2 và Tháng 3.](hidden_cells_False.png) |

Một ô ẩn chứa giá trị khác với một ô trống. [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) kiểm soát cách hiển thị các giá trị thiếu; nó không bao gồm hoặc loại bỏ dữ liệu nguồn ẩn. Xem [Kiểm soát việc hiển thị ô trống](/slides/vi/cpp/chart-series/#control-the-display-of-empty-cells) để biết ví dụ.

## **Lấy phạm vi dữ liệu của một đồ thị**

Trước khi cập nhật dữ liệu workbook trong một bản trình bày hiện có, kiểm tra các phạm vi nguồn để xác định ô worksheet nào mỗi đồ thị sử dụng. Phương thức [IChartData::GetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) trả về phạm vi dữ liệu hiện tại dưới dạng công thức có chỉ định worksheet, ví dụ `Sheet1!$A$1:$D$5`. Ở đây, `Sheet1` là tên worksheet, `!` ngăn cách nó với phạm vi ô, và `$A$1:$D$5` xác định các ô A1 đến D5, bao gồm. Dấu `$` chỉ tham chiếu tuyệt đối theo hàng và cột.

Phương thức đọc phạm vi hiện tại mà không thay đổi đồ thị hoặc workbook của nó. Nếu đồ thị không sử dụng workbook làm nguồn dữ liệu, nó sẽ ném [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/). Để biết thêm thông tin, xem [ChartData API Reference](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/).

Ví dụ này mở một bản trình bày và kiểm tra các hình dạng trực tiếp trên mỗi slide để tìm đồ thị. Nó in ra tên mỗi đồ thị và phạm vi nguồn. Nếu một đồ thị không sử dụng workbook, nó in thông báo và tiếp tục với đồ thị tiếp theo.

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

## **Đọc và ghi dữ liệu đồ thị từ một workbook**

Aspose.Slides cho C++ cung cấp các phương thức [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) và [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) cho phép bạn đọc và ghi các workbook dữ liệu đồ thị (chứa dữ liệu đồ thị được chỉnh sửa bằng Aspose.Cells). **Lưu ý** rằng dữ liệu đồ thị phải được tổ chức theo cùng cách hoặc phải có cấu trúc tương tự như nguồn.

Ví dụ này sử dụng một bản trình bày có đồ thị là hình dạng đầu tiên trên slide đầu tiên. Nó đọc workbook được nhúng vào một luồng, xóa các series và category hiện có, và ghi lại workbook giống hệt. Các thay đổi vẫn ở trong bộ nhớ; ví dụ không lưu bản trình bày.

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

### **Xác thực bố cục đồ thị sau khi sửa đổi workbook**

Khi bạn thay thế một workbook được nhúng bằng một workbook đã chỉnh sửa, đồ thị vẫn giữ lại các collection series và category ban đầu. Sự không khớp này có thể làm cho [IChart::ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) thất bại với lỗi “index out of range”. Hãy xóa các series và category hiện có trước khi ghi workbook đã cập nhật trở lại đồ thị. Ví dụ này sử dụng một đồ thị là hình dạng đầu tiên trên slide đầu tiên. Bình luận đánh dấu vị trí mà việc chỉnh sửa workbook sẽ diễn ra; ví dụ chạy được sẽ ghi lại workbook gốc và xác thực bố cục trong bộ nhớ.

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

Việc xóa các collection loại bỏ các tham chiếu dữ liệu cũ trước khi workbook được ghi lại. Hãy xây dựng lại bất kỳ series và mapping category nào cần thiết cho workbook đã cập nhật trước khi sử dụng đồ thị.

## **Đặt định dạng số tùy chỉnh cho các ô workbook**

Sử dụng [IChartDataCell::set_CustomNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_customnumberformat/) để kiểm soát cách các giá trị số hiển thị trong workbook được nhúng của đồ thị. Ví dụ, một báo cáo có thể cần hiển thị tỷ lệ chuyển đổi dưới dạng phần trăm với bốn chữ số thập phân và hệ số dưới dạng năm chữ số thập phân. Giữ cả hai giá trị ở dạng số để chúng vẫn có thể dùng cho tính toán và vẽ đồ thị.

Định dạng số chỉ thay đổi cách hiển thị, không thay đổi giá trị được lưu. Định dạng `0.0000%` hiển thị `0.125` thành `12.5000%`; nó không thay thế số đã lưu bằng `12.5`. Tương tự, `0.00000` hiển thị `0.1234567` thành `0.12346` mà không làm tròn giá trị đã lưu. Nếu định dạng tùy chỉnh là chuỗi rỗng (`""`), định dạng được gán qua [set_PresetNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_presetnumberformat/) sẽ được dùng thay thế.

Ví dụ sau tạo một biểu đồ cột và truy cập các ô của nó thông qua [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/). Trên worksheet 0, B2 chứa tỷ lệ chuyển đổi và C2 chứa hệ số. Cả hai ô đều cung cấp giá trị cho đồ thị. Ví dụ cũng bật nhãn giá trị liên kết với định dạng nguồn.

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

Định dạng ô workbook riêng biệt với định dạng được đặt trực tiếp trên các trục đồ thị hoặc nhãn dữ liệu. Trong ví dụ này, mỗi nhãn hiển thị giá trị ô nguồn vì [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) được gọi với `true`, và theo định dạng số nguồn vì [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_isnumberformatlinkedtosource/) được gọi với `true`. Sau khi lưu và mở lại bản trình bày, các nhãn hiển thị `12.5000%` và `0.12346`, như hình dưới. Trục dọc sử dụng định dạng riêng `0.00`, được gán qua [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_numberformat/), với [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isnumberformatlinkedtosource/) được gọi với `false`.

Để định dạng một nhãn dữ liệu một cách độc lập, đặt cờ liên kết nguồn của nó thành `false` và gán định dạng qua [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_numberformat/). Điều này không thay đổi định dạng của ô workbook. Ví dụ, một định dạng nhãn độc lập `0.00` sẽ hiển thị giá trị đầu tiên là `0.13`, trong khi B2 vẫn hiển thị `12.5000%`. Xem [Chart Data Labels](/slides/vi/cpp/chart-data-label/#set-percentage-sign-with-chart-data-labels) để biết cách định dạng nhãn trực tiếp.

Hình ảnh dưới được tạo từ bản trình bày đã lưu sau khi mở lại:

![Biểu đồ cột với nhãn liên kết nguồn hiển thị 12.5000% và 0.12346 và trục số được định dạng độc lập.](custom-cell-formats.png)

## **Đặt một ô workbook làm nhãn dữ liệu đồ thị**

Bạn có thể sử dụng văn bản từ các ô workbook làm nhãn dữ liệu cho đồ thị.

Ví dụ này thêm một biểu đồ bong bóng với dữ liệu mặc định vào slide đầu tiên của một bản trình bày hiện có. Nó sử dụng các ô A10:A12 trên worksheet 0 cho ba nhãn đầu tiên trong series đầu tiên, bật nhãn từ các ô, và lưu bản trình bày đã cập nhật.

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

Phương thức [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) cung cấp quyền truy cập vào các worksheet trong workbook của đồ thị. Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và in tên mỗi worksheet ra console.

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

## **Chỉ định kiểu nguồn dữ liệu**

Giá trị điểm series cũng có thể được lưu trực tiếp dưới dạng số nguyên. Xem [Set Series Values Using Numeric Literals](/slides/vi/cpp/chart-series/#set-series-values-using-numeric-literals) để có ví dụ đầy đủ về việc lưu và đọc chúng. Kiểu nguồn của các giá trị điểm tách biệt với cấu hình workbook nội bộ hoặc ngoại vi của đồ thị; việc sử dụng các số nguyên không tự động loại bỏ workbook được nhúng.

Ví dụ này tạo một biểu đồ cột 3D với dữ liệu mặc định và đặt hai tên series bằng các nguồn dữ liệu khác nhau. Tên đầu tiên sử dụng một chuỗi nguyên mẫu; tên thứ hai sử dụng ô C1 trên worksheet 0. Phân loại [DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) chọn nguồn cho mỗi tên. Ví dụ lưu bản trình bày với các tên series đã cập nhật.

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

## **Phát hiện các định dạng Workbook được nhúng không được hỗ trợ**

Aspose.Slides không hỗ trợ định dạng workbook nhị phân Excel (.xlsb) có thể được nhúng trong một số đồ thị. Bạn có thể sử dụng phương thức [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) trên [IChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/) cùng với phân loại [WorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua các đồ thị đó. Ví dụ này kiểm tra các hình dạng trên slide đầu tiên của một bản trình bày hiện có, bỏ qua các hình không phải đồ thị, và in thông báo chẩn đoán cho mỗi đồ thị có workbook .xlsb được nhúng.

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

    // Đọc hoặc sửa đổi dữ liệu workbook biểu đồ được hỗ trợ ở đây.
}
```

## **Workbook bên ngoài**

Aspose.Slides hỗ trợ sử dụng workbook bên ngoài làm nguồn dữ liệu cho đồ thị.

### **Tạo một Workbook bên ngoài**

Sử dụng [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) và [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) để xuất workbook đồ thị được nhúng ra file và liên kết đồ thị với workbook bên ngoài đó.

Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và xuất workbook của nó. Nó đóng luồng đầu ra trước khi gán workbook bên ngoài làm nguồn dữ liệu cho đồ thị, sau đó lưu bản trình bày đã liên kết.

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

### **Đặt một Workbook bên ngoài**

Bằng cách sử dụng phương thức [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/), bạn có thể gán một workbook bên ngoài cho một đồ thị làm nguồn dữ liệu. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới workbook bên ngoài (nếu workbook đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các workbook được lưu ở vị trí từ xa hoặc tài nguyên, bạn vẫn có thể sử dụng các workbook đó làm nguồn dữ liệu bên ngoài. Nếu đường dẫn tương đối cho workbook bên ngoài được cung cấp, nó sẽ tự động được chuyển thành đường dẫn đầy đủ.

Ví dụ này sử dụng một workbook bên ngoài mà worksheet có tên `Sheet1` chứa tên series ở B1, tên danh mục ở A2:A4, và các giá trị số ở B2:B4. Ví dụ tạo một biểu đồ tròn, liên kết workbook, và sử dụng [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) để ánh xạ A1:B4 thành một series và ba danh mục. Nó lưu bản trình bày với đồ thị đã liên kết.

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

Tham số `updateChartData` của [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) điều khiển việc có tải workbook hay không.

* Khi `updateChartData` là `false`, chỉ đường dẫn workbook được cập nhật. Dữ liệu đồ thị không được tải hoặc cập nhật từ workbook mục tiêu, do đó workbook có thể không khả dụng.
* Khi `updateChartData` là `true`, dữ liệu đồ thị được cập nhật từ workbook mục tiêu.

Ví dụ sau gán một URL placeholder với `updateChartData` đặt là `false`. Nó giữ lại dữ liệu mặc định của biểu đồ tròn và lưu bản trình bày mà không tải workbook không khả dụng.

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

### **Lấy đường dẫn Workbook nguồn dữ liệu bên ngoài của một đồ thị**

Để xác định workbook được liên kết với một đồ thị, kiểm tra xem đồ thị có sử dụng nguồn dữ liệu bên ngoài hay không và lấy đường dẫn workbook của nó.

Ví dụ này kiểm tra hình dạng đầu tiên trên slide đầu tiên của một bản trình bày có workbook bên ngoài được liên kết. Nếu đó là một đồ thị được liên kết với workbook bên ngoài, ví dụ sẽ in [get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) ra console. Sau đó nó lưu một bản sao của bản trình bày.

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

### **Chỉnh sửa dữ liệu đồ thị**

Bạn có thể chỉnh sửa dữ liệu trong các workbook bên ngoài giống như khi bạn thay đổi nội dung của workbook nội bộ. Khi một workbook bên ngoài không thể tải, một ngoại lệ sẽ được ném.

Ví dụ này sử dụng một đồ thị là hình dạng đầu tiên trên slide đầu tiên và được liên kết với một workbook bên ngoài có thể truy cập được. Nó đặt giá trị dựa trên ô của điểm dữ liệu đầu tiên trong series đầu tiên thành 100 và lưu bản trình bày đã cập nhật. Chỉnh sửa giá trị ô có thể cập nhật file XLSX bên ngoài liên kết, vì vậy hãy sử dụng một bản sao nếu bạn cần giữ nguyên workbook gốc.

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

### **Khôi phục Workbook từ bộ nhớ cache của đồ thị**

Nếu một đồ thị sử dụng workbook bên ngoài bị mất hoặc không khả dụng, Aspose.Slides có thể tái tạo workbook của đồ thị từ dữ liệu được lưu trong cache của bản trình bày. Tạo [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/), cấu hình nó với [set_SpreadsheetOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), và gọi [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) với `true` trước khi mở bản trình bày.

Ví dụ C++ sau khôi phục dữ liệu workbook cho một đồ thị là hình dạng đầu tiên trên slide đầu tiên và tham chiếu tới một workbook bên ngoài không khả dụng. Nó truy cập dữ liệu đã khôi phục qua [IChart::get_ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) và [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

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

    // Đọc hoặc sửa đổi dữ liệu workbook đã khôi phục ở đây.
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Nếu workbook bên ngoài không khả dụng và chức năng khôi phục bị tắt, Aspose.Slides sẽ ném một [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/). Chỉ bật khôi phục khi việc sử dụng dữ liệu đồ thị đã được lưu trong cache là một giải pháp chấp nhận được, vì cache có thể không chứa các thay đổi đã được thực hiện trên workbook bên ngoài sau lần cuối cùng bản trình bày được cập nhật.

## **Câu hỏi thường gặp**

**Tôi có thể xác định được một đồ thị cụ thể có liên kết tới workbook bên ngoài hay workbook được nhúng không?**

Có. Một đồ thị có [data source type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) và một [path to an external workbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); nếu nguồn là một workbook bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp bên ngoài đang được sử dụng.

**Các đường dẫn tương đối tới workbook bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Bản trình bày lưu đường dẫn tuyệt đối trong file PPTX, vì vậy việc di chuyển workbook có thể yêu cầu cập nhật liên kết.

**Tôi có thể sử dụng workbook nằm trên các tài nguyên/điểm chia sẻ mạng không?**

Có, các workbook như vậy có thể được dùng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa workbook từ xa trực tiếp bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè lên file XLSX bên ngoài khi lưu bản trình bày không?**

Bản trình bày lưu một [link to the external file](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Việc chỉnh sửa dữ liệu đồ thị dựa trên ô cũng có thể cập nhật file XLSX địa phương được liên kết. Hãy sử dụng một bản sao của workbook nếu bản gốc phải được giữ nguyên.

**Nếu file bên ngoài được bảo vệ bằng mật khẩu, tôi nên làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi tạo liên kết. Một cách thường dùng là gỡ bảo vệ trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, dùng [Aspose.Cells](https://reference.aspose.com/cells/cpp/)) và liên kết đến bản sao đó.

**Nhiều đồ thị có thể tham chiếu cùng một workbook bên ngoài không?**

Có. Mỗi đồ thị lưu liên kết của riêng mình. Nếu chúng đều trỏ tới cùng một tệp, việc cập nhật tệp đó sẽ được phản ánh trong mỗi đồ thị vào lần tiếp theo dữ liệu được tải.