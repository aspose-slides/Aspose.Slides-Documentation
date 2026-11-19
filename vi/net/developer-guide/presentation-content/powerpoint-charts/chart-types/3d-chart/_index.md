---
title: Tùy chỉnh biểu đồ 3D trong các bản trình bày trên .NET
linktitle: Biểu đồ 3D
type: docs
url: /vi/net/3d-chart/
keywords:
- biểu đồ 3D
- quay
- độ sâu
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tạo biểu đồ 3D trong bản trình bày PowerPoint với Aspose.Slides cho .NET. Điều chỉnh góc quay, tỷ lệ chiều cao, độ sâu biểu đồ và khoảng cách giữa các series bằng các ví dụ C#."
---
## **Tổng quan**

Aspose.Slides for .NET cho phép bạn tùy chỉnh chế độ xem của biểu đồ 3D thông qua thuộc tính [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/) . Bài viết này minh họa cách điều chỉnh góc quay, tỷ lệ chiều cao, độ sâu, trục góc vuông, và khoảng cách giữa các series, sau đó lưu bản trình bày ở định dạng PPTX.

## **Đặt Góc Quay và Độ Sâu của Biểu Đồ 3D**

Ví dụ dưới đây tạo một [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) và sử dụng [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) để thêm một biểu đồ cột 3D xếp chồng vào slide đầu tiên của nó. Nó thay thế các series và danh mục mặc định bằng hai series, mỗi series chứa ba giá trị. Chỉ mục worksheet `0` xác định worksheet dữ liệu đầu tiên của biểu đồ; hàng `0` chứa tên series, và cột `0` chứa nhãn danh mục.

Các thuộc tính [RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) và [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) đặt góc quay của biểu đồ lần lượt là 40 và 270 độ. [DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) đặt độ sâu của biểu đồ bằng 150% chiều rộng, trong khi [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) bật trục góc vuông thay vì phối cảnh. Bản trình bày kết quả chứa biểu đồ đã được điền dữ liệu với các cài đặt chế độ xem 3D này.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

var values = new double[,] { { 20, 50, 30 }, { 30, 10, 60 } };

for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, 0, $"Category {categoryIndex + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

for (var seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, seriesIndex + 1, $"Series {seriesIndex + 1}");
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);

    for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }
}

chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **Điều Chỉnh Tỷ Lệ Chiều Cao của Biểu Đồ 3D**

Sử dụng [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) để đặt chiều cao của biểu đồ 3D dưới dạng phần trăm của chiều rộng của nó. Điều này thay đổi tỷ lệ của cảnh 3D mà không thay đổi kích thước đối tượng biểu đồ trên slide.

Ví dụ sau tạo một [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) chart với dữ liệu mặc định: ba series và bốn danh mục. Nó lưu ba bản trình bày với tỷ lệ chiều cao là 50%, 100% và 200%. Vị trí, chiều rộng và chiều cao của biểu đồ vẫn cố định. Dữ liệu, góc quay, độ sâu, khoảng cách giữa các series và định dạng đều giống nhau trong cả ba tệp; chỉ có tỷ lệ chiều cao thay đổi.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 460);
chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.DepthPercents = 100;
chart.ChartData.Series[0].ParentSeriesGroup.GapDepth = 150;

foreach (ushort heightPercent in new ushort[] { 50, 100, 200 })
{
    chart.Rotation3D.HeightPercents = heightPercent;
    presentation.Save($"chart_height_{heightPercent}.pptx", SaveFormat.Pptx);
}
```

Các hình ảnh dưới đây được xuất từ các bản trình bày đã tạo bằng Microsoft PowerPoint. Một tỷ lệ phần trăm nhỏ hơn tạo ra cảnh phẳng hơn, trong khi một tỷ lệ phần trăm lớn hơn tạo ra cảnh cao hơn trong cùng một đối tượng biểu đồ. PowerPoint cũng có thể điều chỉnh khoảng cách các tick trục và vị trí nhãn để vừa với cảnh.

| Chiều cao: 50% | Chiều cao: 100% | Chiều cao: 200% |
| --- | --- | --- |
| ![3D column chart with height set to 50 percent of its width](height_percent_50.png) | ![3D column chart with height set to 100 percent of its width](height_percent_100.png) | ![3D column chart with height set to 200 percent of its width](height_percent_200.png) |

Các thuộc tính này điều khiển các khía cạnh khác nhau của biểu đồ:

| Thuộc tính | Hiệu ứng |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | Chiều cao của cảnh 3D tính bằng phần trăm chiều rộng của nó. |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | Chiều cao của đối tượng biểu đồ trên slide, tính bằng điểm. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Độ sâu của cảnh 3D tính bằng phần trăm chiều rộng của nó. |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Khoảng cách giữa các series dọc theo trục độ sâu, tính bằng phần trăm chiều rộng của dấu đánh dấu. |

Cài đặt chiều cao ảnh hưởng đến các biểu đồ cột và thanh 3D, bao gồm các biến thể hình trụ, hình nón và hình kim tự tháp, cũng như các biểu đồ đường, diện tích, bánh và bề mặt 3D. So sánh ở trên sử dụng kiểu `Column3D` đã được xác nhận. Cài đặt này không thay đổi giao diện của biểu đồ 2D `ClusteredColumn` hoặc biểu đồ `BubbleWith3D`; những tên này là thành viên của enum [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Đối với các cài đặt giao diện biểu đồ khác, xem [Chart Formatting](/slides/vi/net/chart-formatting/).

## **Điều Chỉnh Khoảng Cách Giữa Các Series**

Sử dụng [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) để kiểm soát khoảng cách giữa các series dữ liệu dọc theo trục độ sâu của biểu đồ 3D, biểu thị dưới dạng phần trăm chiều rộng của dấu đánh dấu. Sử dụng giá trị từ **0 to 500**, bao gồm: `0` loại bỏ khoảng trống, trong khi các giá trị lớn hơn tăng khoảng cách. Với độ sâu biểu đồ cố định, tăng khoảng trống làm cho các dấu đánh dấu mỏng hơn dọc theo trục độ sâu.

Truy cập nhóm qua [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/). Cài đặt áp dụng cho mọi series trong nhóm đó, không chỉ series được dùng để truy cập. [IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) là chỉ đọc và phản ánh cài đặt của nhóm cha.

Cài đặt này ảnh hưởng đến các biểu đồ cột và thanh 3D, bao gồm các biến thể hình trụ, hình nón và hình kim tự tháp, cũng như các biểu đồ đường và diện tích 3D. Giao diện phụ thuộc vào việc các series được sắp xếp theo độ sâu, cụm hay xếp chồng. Để so sánh rõ ràng khoảng trống giữa các series riêng biệt, hãy sử dụng `ChartType.Column3D` từ enum [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/).

Các thuộc tính này điều khiển các khía cạnh khác nhau của biểu đồ:

| Thuộc tính | Hiệu ứng |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Khoảng cách giữa các series dọc theo trục độ sâu, tính bằng phần trăm chiều rộng của dấu đánh dấu. |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | Khoảng cách giữa các cụm cột hoặc thanh liền kề, tính bằng phần trăm chiều rộng của cột hoặc thanh. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Độ sâu tổng thể của biểu đồ, tính bằng phần trăm chiều rộng của biểu đồ. |

Ví dụ tự chứa dưới đây sử dụng dữ liệu biểu đồ mặc định, bao gồm ba series và bốn danh mục. Nó lưu hai bản trình bày với dữ liệu, góc quay, độ rộng khoảng trống và độ sâu biểu đồ giống hệt; chỉ độ sâu khoảng trống thay đổi.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 230);

chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.DepthPercents = 100;

var series = chart.ChartData.Series[0];
var group = series.ParentSeriesGroup;
group.GapWidth = 150;

foreach (ushort gapDepth in new ushort[] { 0, 500 })
{
    group.GapDepth = gapDepth;

    var fileName = $"series_gap_depth_{gapDepth}.pptx";
    presentation.Save(fileName, SaveFormat.Pptx);

}
```

Các hình ảnh dưới đây được xuất từ các bản trình bày đã tạo bằng Microsoft PowerPoint.

| Khoảng trống: 0% | Khoảng trống: 500% |
| --- | --- |
| ![3D column chart with no gap between series along the depth axis](gap_depth_0.png) | ![3D column chart with a 500 percent gap between series along the depth axis](gap_depth_500.png) |

## **Thay Đổi Loại Series 3D và Hình Dạng Thanh**

Trong biểu đồ hình trụ cụm, series đầu tiên bắt đầu với hình dạng thanh trụ. Ví dụ đọc [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) và [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/) trước và sau mỗi thay đổi.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Type = ChartType.ClusteredCone;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Bar3DShape = ChartShapeType.Box;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

presentation.Save("series_shape.pptx", SaveFormat.Pptx);
```

| Thay đổi cho series đầu tiên | `Type` | `Bar3DShape` |
| --- | --- | --- |
| Tạo biểu đồ | `ClusteredCylinder` | `Cylinder` |
| Đặt `Type` thành `ClusteredCone` | `ClusteredCone` | `Cone` |
| Đặt `Bar3DShape` thành `Box` | `ClusteredColumn3D` | `Box` |

Đặt hình dạng thành `Box` cũng thay đổi loại series thành `ClusteredColumn3D`. Nếu mã của bạn phân nhánh dựa trên loại series, hãy đọc `series.Type` sau khi thay đổi hình dạng. Một giá trị đã được lưu trong bộ nhớ đệm trước khi gán vẫn sẽ chọn nhánh `ClusteredCone`.

![PowerPoint comparison showing the first series as cylinders, cones, and rectangular columns from left to right](series-shapes.png)

## **FAQ**

**Các loại biểu đồ nào hỗ trợ chế độ 3D trong Aspose.Slides?**

Aspose.Slides hỗ trợ các biến thể 3D của biểu đồ cột, bao gồm Column 3D, Clustered Column 3D, Stacked Column 3D và 100% Stacked Column 3D, cùng với các loại 3D liên quan được lộ ra qua enum [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Để có danh sách chính xác và cập nhật, kiểm tra các thành viên của [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) trong tài liệu API của phiên bản đã cài đặt.

**Tôi có thể lấy hình ảnh raster của biểu đồ 3D cho báo cáo hoặc web không?**

Có. Bạn có thể xuất biểu đồ thành ảnh bằng [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) hoặc [render toàn bộ slide](/slides/vi/net/convert-powerpoint-to-png/) thành các định dạng như PNG hoặc JPEG. Điều này hữu ích khi bạn cần bản xem trước raster hoặc muốn nhúng biểu đồ vào tài liệu, bảng điều khiển hoặc trang web mà không cần PowerPoint.

**Hiệu năng khi xây dựng và render các biểu đồ 3D lớn như thế nào?**

Hiệu năng phụ thuộc vào khối lượng dữ liệu và độ phức tạp hình ảnh. Để đạt kết quả tốt nhất, hãy giữ hiệu ứng 3D ở mức tối thiểu, tránh sử dụng kết cấu nặng trên các tường và vùng vẽ, hạn chế số điểm dữ liệu mỗi series khi có thể, và render với kích thước đầu ra phù hợp (độ phân giải và kích thước) để đáp ứng nhu cầu hiển thị hoặc in.