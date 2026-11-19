---
title: Tùy chỉnh biểu đồ 3D trong bản trình bày bằng C++
linktitle: Biểu đồ 3D
type: docs
url: /vi/cpp/3d-chart/
keywords:
- biểu đồ 3D
- xoay
- độ sâu
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Tạo biểu đồ 3D trong bản trình chiếu PowerPoint với Aspose.Slides cho C++. Điều chỉnh góc quay, tỷ lệ chiều cao, độ sâu biểu đồ và khoảng cách giữa các chuỗi bằng các ví dụ C++."
---
## **Tổng quan**

Aspose.Slides for C++ cho phép bạn tùy chỉnh chế độ xem của biểu đồ 3D thông qua [IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/). Bài viết này trình bày cách điều chỉnh góc quay, tỷ lệ chiều cao, độ sâu, trục góc vuông và khoảng cách giữa các chuỗi, sau đó lưu bản trình bày ở định dạng PPTX.

## **Đặt góc quay và độ sâu cho biểu đồ 3D**

Ví dụ dưới tạo một [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) và sử dụng [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) để thêm một biểu đồ cột 3D xếp chồng vào slide đầu tiên. Nó thay thế các chuỗi và danh mục mặc định bằng hai chuỗi, mỗi chuỗi chứa ba giá trị. Chỉ mục bảng tính `0` xác định bảng dữ liệu đầu tiên của biểu đồ; hàng `0` chứa tên chuỗi, và cột `0` chứa nhãn danh mục.

Các phương thức [set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) và [set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) đặt góc quay của biểu đồ lần lượt là 40 và 270 độ. [set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) đặt độ sâu bằng 150 % chiều rộng, trong khi [set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/) bật trục góc vuông thay vì phối cảnh. Bản trình bày kết quả chứa biểu đồ đã được thiết lập các cài đặt 3D này.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

double values[2][3] = { { 20, 50, 30 }, { 30, 10, 60 } };

for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    auto categoryName = String::Format(u"Category {0}", categoryIndex + 1);
    auto categoryCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, 0, ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
}

for (auto seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    auto seriesName = String::Format(u"Series {0}", seriesIndex + 1);
    auto seriesCell = workbook->GetCell(worksheetIndex, 0, seriesIndex + 1, ObjectExt::Box(seriesName));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesCell, chart->get_Type());

    for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        auto valueCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, ObjectExt::Box(values[seriesIndex][categoryIndex]));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
    }
}

chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_RotationX(40);
chart->get_Rotation3D()->set_RotationY(270);
chart->get_Rotation3D()->set_DepthPercents(150);

presentation->Save(u"Rotation3D_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Điều chỉnh tỷ lệ chiều cao của biểu đồ 3D**

Sử dụng [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) để đặt chiều cao của biểu đồ 3D dưới dạng phần trăm của chiều rộng. Điều này thay đổi tỷ lệ của cảnh 3D mà không thay đổi kích thước đối tượng biểu đồ trên slide.

Ví dụ sau tạo một biểu đồ [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) với dữ liệu mặc định: ba chuỗi và bốn danh mục. Nó lưu ba bản trình bày với tỷ lệ chiều cao lần lượt là 50 %, 100 % và 200 %. Vị trí, chiều rộng và chiều cao của biểu đồ vẫn cố định. Dữ liệu, góc quay, độ sâu, khoảng cách chuỗi và định dạng đều giống nhau trong ba tệp; chỉ tỷ lệ chiều cao thay đổi.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 460);
chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_DepthPercents(100);
chart->get_ChartData()->get_Series()->idx_get(0)->get_ParentSeriesGroup()->set_GapDepth(150);

for (uint16_t heightPercent : { 50, 100, 200 })
{
    chart->get_Rotation3D()->set_HeightPercents(heightPercent);
    auto fileName = String::Format(u"chart_height_{0}.pptx", heightPercent);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

Các hình ảnh dưới đây được xuất từ ví dụ .NET tương đương bằng Microsoft PowerPoint và minh họa cùng một cài đặt chiều cao. Phần trăm thấp hơn tạo ra cảnh phẳng hơn, trong khi phần trăm cao hơn tạo ra cảnh cao hơn trong cùng một đối tượng biểu đồ. PowerPoint cũng có thể điều chỉnh khoảng cách các dấu tick và vị trí nhãn trục để phù hợp với cảnh.

| Chiều cao: 50% | Chiều cao: 100% | Chiều cao: 200% |
| --- | --- | --- |
| ![Biểu đồ cột 3D với chiều cao đặt bằng 50 % chiều rộng](height_percent_50.png) | ![Biểu đồ cột 3D với chiều cao đặt bằng 100 % chiều rộng](height_percent_100.png) | ![Biểu đồ cột 3D với chiều cao đặt bằng 200 % chiều rộng](height_percent_200.png) |

Các phương thức này kiểm soát các khía cạnh khác nhau của biểu đồ:

| Phương thức | Hiệu ứng |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | Chiều cao của cảnh 3D dưới dạng phần trăm của chiều rộng. |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | Chiều cao của đối tượng biểu đồ trên slide, tính bằng điểm. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Độ sâu của cảnh 3D dưới dạng phần trăm của chiều rộng. |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Khoảng cách giữa các chuỗi dọc theo trục độ sâu, tính bằng phần trăm của chiều rộng đánh dấu. |

Cài đặt chiều cao ảnh hưởng đến các biểu đồ cột và thanh 3D, bao gồm các biến thể trụ, nón và kim tự tháp, cũng như các biểu đồ đường, diện tích, bánh và bề mặt 3D. So sánh ở trên sử dụng kiểu `Column3D` đã được xác minh. Cài đặt này không thay đổi giao diện của biểu đồ `ClusteredColumn` 2D hay biểu đồ `BubbleWith3D`; những tên này là thành viên của liệt kê [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Đối với các cài đặt giao diện biểu đồ khác, xem [Chart Formatting](/slides/vi/cpp/chart-formatting/).

## **Điều chỉnh khoảng cách giữa các chuỗi**

Sử dụng [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) để kiểm soát khoảng cách giữa các chuỗi dữ liệu dọc theo trục độ sâu của biểu đồ 3D, biểu thị dưới dạng phần trăm của chiều rộng đánh dấu. Giá trị hợp lệ từ **0 đến 500**, bao gồm: `0` loại bỏ khoảng cách, trong khi các giá trị lớn hơn làm tăng khoảng cách. Khi độ sâu biểu đồ cố định, việc tăng khoảng cách làm cho các đánh dấu mỏng hơn dọc theo trục độ sâu.

Truy cập nhóm qua [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/). Cài đặt áp dụng cho mọi chuỗi trong nhóm đó, không chỉ chuỗi được dùng để truy cập. [IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/) trả về cài đặt của nhóm cha.

Cài đặt này ảnh hưởng đến các biểu đồ cột và thanh 3D, bao gồm các biến thể trụ, nón và kim tự tháp, cũng như các biểu đồ đường và diện tích 3D. Giao diện phụ thuộc vào việc các chuỗi được sắp xếp theo độ sâu, nhóm lại hay xếp chồng. Để so sánh rõ ràng khoảng cách giữa các chuỗi riêng biệt, hãy sử dụng `ChartType::Column3D` từ liệt kê [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/).

Các phương thức này kiểm soát các khía cạnh khác nhau của biểu đồ:

| Phương thức | Hiệu ứng |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Khoảng cách giữa các chuỗi dọc theo trục độ sâu, tính bằng phần trăm của chiều rộng đánh dấu. |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | Khoảng cách giữa các cụm thanh hoặc cột liền kề, tính bằng phần trăm của chiều rộng thanh hoặc cột. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Độ sâu tổng thể của biểu đồ, tính bằng phần trăm của chiều rộng biểu đồ. |

Ví dụ tự chứa dưới đây sử dụng dữ liệu biểu đồ mặc định, bao gồm ba chuỗi và bốn danh mục. Nó lưu hai bản trình bày với dữ liệu, góc quay, khoảng cách rộng và độ sâu biểu đồ giống nhau; chỉ độ sâu khoảng cách thay đổi.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 230);

chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_DepthPercents(100);

auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto group = series->get_ParentSeriesGroup();
group->set_GapWidth(150);

for (uint16_t gapDepth : { 0, 500 })
{
    group->set_GapDepth(gapDepth);

    auto fileName = String::Format(u"series_gap_depth_{0}.pptx", gapDepth);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

Các hình ảnh dưới đây được xuất từ ví dụ .NET tương đương bằng Microsoft PowerPoint và minh họa cùng một cài đặt độ sâu khoảng cách.

| Độ sâu khoảng cách: 0% | Độ sâu khoảng cách: 500% |
| --- | --- |
| ![Biểu đồ cột 3D không có khoảng cách giữa các chuỗi dọc theo trục độ sâu](gap_depth_0.png) | ![Biểu đồ cột 3D với khoảng cách 500 % giữa các chuỗi dọc theo trục độ sâu](gap_depth_500.png) |

## **Thay đổi loại chuỗi 3D và hình dạng thanh**

Trong biểu đồ trụ nhóm, chuỗi đầu tiên bắt đầu với các thanh trụ. Ví dụ đọc [IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/) và [IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/) trước và sau mỗi thay đổi.

```cpp
#include <DOM/Chart/ChartShapeType.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enum.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto printSeries = [&series]()
{
    auto type = Enum<ChartType>::GetName(series->get_Type());
    auto shape = Enum<ChartShapeType>::GetName(series->get_Bar3DShape());
    Console::WriteLine(u"{0} | {1}", type, shape);
};

printSeries();

series->set_Type(ChartType::ClusteredCone);
printSeries();

series->set_Bar3DShape(ChartShapeType::Box);
printSeries();

presentation->Save(u"series_shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

| Thay đổi ở chuỗi đầu tiên | `get_Type` | `get_Bar3DShape` |
| --- | --- | --- |
| Tạo biểu đồ | `ClusteredCylinder` | `Cylinder` |
| Gọi [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_type/) với `ClusteredCone` | `ClusteredCone` | `Cone` |
| Gọi [set_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_bar3dshape/) với `Box` | `ClusteredColumn3D` | `Box` |

Đặt hình dạng thành `Box` cũng thay đổi loại chuỗi thành `ClusteredColumn3D`. Nếu mã của bạn phân nhánh dựa trên loại chuỗi, hãy gọi `series->get_Type()` sau khi thay đổi hình dạng. Giá trị được lưu trước khi thay đổi sẽ vẫn chọn nhánh `ClusteredCone`.

![So sánh PowerPoint hiển thị chuỗi đầu tiên dưới dạng trụ, nón và cột hình chữ nhật từ trái sang phải](series-shapes.png)

## **Câu hỏi thường gặp**

**Các loại biểu đồ nào hỗ trợ chế độ 3D trong Aspose.Slides?**

Aspose.Slides hỗ trợ các biến thể 3D của biểu đồ cột, bao gồm Column 3D, Clustered Column 3D, Stacked Column 3D và 100 % Stacked Column 3D, cùng các loại 3D liên quan được khai báo trong liệt kê [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Để biết danh sách chính xác và cập nhật, hãy kiểm tra các thành viên của [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) trong tài liệu API của phiên bản bạn đã cài đặt.

**Tôi có thể lấy ảnh raster của biểu đồ 3D để đưa vào báo cáo hoặc trang web không?**

Có. Bạn có thể xuất biểu đồ thành hình ảnh bằng [Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) hoặc [render toàn bộ slide](/slides/vi/cpp/convert-powerpoint-to-png/) sang các định dạng như PNG hoặc JPEG. Điều này hữu ích khi bạn cần bản xem trước raster hoặc muốn nhúng biểu đồ vào tài liệu, bảng điều khiển hoặc trang web mà không cần PowerPoint.

**Hiệu năng của việc tạo và render các biểu đồ 3D lớn như thế nào?**

Hiệu năng phụ thuộc vào khối lượng dữ liệu và độ phức tạp về hình ảnh. Để đạt kết quả tốt nhất, hãy giữ hiệu ứng 3D ở mức tối thiểu, tránh dùng kết cấu nặng trên các bề mặt tường và vùng vẽ, hạn chế số điểm dữ liệu mỗi chuỗi khi có thể, và render với kích thước đầu ra (độ phân giải và kích thước) phù hợp với nhu cầu hiển thị hoặc in.