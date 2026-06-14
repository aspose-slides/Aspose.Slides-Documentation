---
title: Tối ưu tính toán biểu đồ cho bản trình bày trong C++
linktitle: Tính toán Biểu đồ
type: docs
weight: 50
url: /vi/cpp/chart-calculations/
keywords:
- tính toán biểu đồ
- thành phần biểu đồ
- vị trí phần tử
- vị trí thực
- phần tử con
- phần tử cha
- giá trị biểu đồ
- giá trị thực
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Hiểu về tính toán biểu đồ, cập nhật dữ liệu và kiểm soát độ chính xác trong Aspose.Slides cho C++ cho PPT và PPTX, với các ví dụ mã C++ thực tế."
---
## **Tổng quan**

Aspose.Slides cung cấp các API để làm việc với các phép tính biểu đồ và dữ liệu bố cục trong bản trình bày. Bài viết này cho thấy cách lấy các giá trị thực của các phần tử biểu đồ, bao gồm vị trí và kích thước thực của các phần tử triển khai `IActualLayout` và các giá trị thực của các trục biểu đồ. Nó cũng giải thích rằng các giá trị này được điền sau khi xác thực bố cục biểu đồ.

Ngoài ra, bài viết minh họa cách lấy vị trí thực của các phần tử biểu đồ cha và cách ẩn các thành phần biểu đồ như tiêu đề, trục, chú giải và đường lưới. Cùng nhau, các ví dụ này giúp bạn kiểm tra thông tin bố cục biểu đồ và kiểm soát khả năng hiển thị của các phần tử biểu đồ trong bản trình bày PowerPoint một cách lập trình.

## **Tính toán các giá trị thực của các phần tử biểu đồ**
Aspose.Slides for C++ cung cấp một API đơn giản để lấy các thuộc tính này. Điều này sẽ giúp bạn tính toán các giá trị thực của các phần tử biểu đồ. Các giá trị thực bao gồm vị trí của các phần tử triển khai giao diện IActualLayout (IActualLayout::get_ActualX(), IActualLayout::get_ActualY(), IActualLayout::get_ActualWidth(), IActualLayout::get_ActualHeight()) và các giá trị thực của các trục (IAxis::get_ActualMaxValue(), IAxis::get_ActualMinValue(), IAxis::get_ActualMajorUnit(), IAxis::get_ActualMinorUnit(), IAxis::get_ActualMajorUnitScale(), IAxis::get_ActualMinorUnitScale()).

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Lưu bản trình bày
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **Tính toán vị trí thực của các phần tử biểu đồ cha**
Aspose.Slides for C++ cung cấp một API đơn giản để lấy các thuộc tính này. Các phương thức của IActualLayout cung cấp thông tin về vị trí thực của phần tử biểu đồ cha. Cần gọi phương thức IChart::ValidateChartLayout() trước đó để điền các thuộc tính với các giá trị thực.

``` cpp
// Tạo bản trình bày trống
auto pres = System::MakeObject<Presentation>();

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();
```

## **Ẩn các phần tử biểu đồ**
Chủ đề này giúp bạn hiểu cách ẩn thông tin khỏi biểu đồ. Sử dụng Aspose.Slides cho C++ bạn có thể ẩn **Tiêu đề, Trục dọc, Trục ngang** và **Đường lưới** khỏi biểu đồ. Ví dụ mã dưới đây cho thấy cách sử dụng các thuộc tính này.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **Đặt phạm vi dữ liệu cho biểu đồ**
Aspose.Slides cho C++ đã cung cấp API đơn giản nhất để đặt phạm vi dữ liệu cho biểu đồ một cách dễ dàng. Để đặt phạm vi dữ liệu cho biểu đồ:

- Mở một thể hiện của lớp Presentation chứa biểu đồ.
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
- Duyệt qua tất cả các shape để tìm biểu đồ mong muốn.
- Truy cập dữ liệu biểu đồ và đặt phạm vi.
- Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Các ví dụ mã sau đây cho thấy cách cập nhật biểu đồ.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}

## **Câu hỏi thường gặp**

**Các sổ làm việc Excel bên ngoài có hoạt động như nguồn dữ liệu không, và điều này ảnh hưởng như thế nào đến việc tính lại?**

Yes. Một biểu đồ có thể tham chiếu tới một sổ làm việc bên ngoài: khi bạn kết nối hoặc làm mới nguồn bên ngoài, công thức và giá trị được lấy từ sổ làm việc đó, và biểu đồ phản ánh các cập nhật trong quá trình mở/chỉnh sửa. API cho phép bạn [chỉ định sổ làm việc bên ngoài](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) đường dẫn và quản lý dữ liệu liên kết.

**Tôi có thể tính và hiển thị các đường xu hướng mà không tự triển khai hồi quy không?**

Yes. [Đường xu hướng](/slides/vi/cpp/trend-line/) (tuyến tính, exponential và các loại khác) được thêm và cập nhật bởi Aspose.Slides; các tham số của chúng được tính lại từ dữ liệu chuỗi một cách tự động, vì vậy bạn không cần tự triển khai các phép tính.

**Nếu một bản trình bày có nhiều biểu đồ với liên kết bên ngoài, tôi có thể kiểm soát sổ làm việc nào mỗi biểu đồ sử dụng để tính các giá trị không?**

Yes. Mỗi biểu đồ có thể trỏ tới [sổ làm việc bên ngoài](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) riêng của nó, hoặc bạn có thể tạo/thay thế một sổ làm việc bên ngoài cho từng biểu đồ một cách độc lập với các biểu đồ khác.