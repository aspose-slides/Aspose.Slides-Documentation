---
title: Tùy chỉnh biểu đồ 3D trong các bản trình chiếu .NET
linktitle: Biểu đồ 3D
type: docs
url: /vi/net/3d-chart/
keywords:
- biểu đồ 3D
- xoay
- độ sâu
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tạo biểu đồ 3D trong các bản trình chiếu PowerPoint với Aspose.Slides cho .NET. Điều chỉnh góc quay, tỷ lệ chiều cao, độ sâu biểu đồ và khoảng cách giữa các dãy với các ví dụ C#."
---
## **Tổng quan**

Aspose.Slides for .NET cho phép bạn tùy chỉnh chế độ xem của biểu đồ 3D thông qua thuộc tính [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/) . Bài viết này trình bày cách điều chỉnh góc quay, tỷ lệ chiều cao, độ sâu, trục góc vuông và khoảng cách giữa các dãy, sau đó lưu bản trình chiếu ở định dạng PPTX.

## **Đặt góc quay và độ sâu cho biểu đồ 3D**

Ví dụ dưới đây tạo một [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) và sử dụng [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) để thêm một biểu đồ cột 3D chồng vào slide đầu tiên. Nó thay thế các dãy và danh mục mặc định bằng hai dãy, mỗi dãy chứa ba giá trị. Chỉ mục bảng tính `0` xác định bảng dữ liệu đầu tiên của biểu đồ; hàng `0` chứa tên dãy, và cột `0` chứa nhãn danh mục.

Các thuộc tính [RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) và [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) đặt góc quay của biểu đồ lần lượt là 40 và 270 độ. [DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) đặt độ sâu bằng 150% chiều rộng của nó, trong khi [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) bật trục góc vuông thay vì phối cảnh. Bản trình chiếu kết quả chứa biểu đồ đã được điền dữ liệu với các thiết lập hiển thị 3D này.

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

## **Áp dụng tô hình ảnh cho bề mặt biểu đồ 3D**

Biểu đồ 3D có ba bề mặt mà bạn có thể tô riêng biệt: [side wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/sidewall/), [back wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/), và [floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/). Đặt [fill type](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) của bề mặt đã chọn thành `Picture` và chỉ định một hình ảnh. Đặt cả [picture fill mode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) và [picture type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartwall/picturetype/) của bề mặt thành `Stretch` để ảnh được kéo dãn một bản sao trên toàn bề mặt.

Lưu [arrow.png](arrow.png) vào thư mục làm việc. Ví dụ quay biểu đồ và tăng giá trị tối đa trên trục đứng để sàn hiển thị giữa các cột. Sau đó nó sao chép slide hai lần trước khi áp dụng mũi tên vào một bề mặt khác trên mỗi slide. Ba biểu đồ đều giữ cùng dữ liệu, góc nhìn và nền.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 20, 30, 680, 480);
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 30;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 24;

var backSlide = presentation.Slides.AddClone(slide);
var floorSlide = presentation.Slides.AddClone(slide);
var backChart = (IChart)backSlide.Shapes[0];
var floorChart = (IChart)floorSlide.Shapes[0];

var imageBytes = File.ReadAllBytes("arrow.png");
var arrow = presentation.Images.AddImage(imageBytes);

foreach (var surface in new[] { chart.SideWall, backChart.BackWall, floorChart.Floor })
{
    var fill = surface.Format.Fill;
    fill.FillType = FillType.Picture;
    fill.PictureFillFormat.Picture.Image = arrow;
    fill.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    surface.PictureType = PictureType.Stretch;
}

presentation.Save("chart-surfaces.pptx", SaveFormat.Pptx);
```

Microsoft PowerPoint hiển thị ba slide như sau.

| Tường bên | Tường sau | Sàn |
| --- | --- | --- |
| ![Mũi tên chỉ vào biểu đồ dọc theo tường bên](side-wall.png) | ![Mũi tên chỉ sang phải trên tường sau](back-wall.png) | ![Mũi tên chỉ sang phải trên sàn giữa các cột](floor.png) |

## **Điều chỉnh tỷ lệ chiều cao của biểu đồ 3D**

Sử dụng [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) để đặt chiều cao của biểu đồ 3D dưới dạng phần trăm chiều rộng của nó. Điều này thay đổi tỷ lệ của cảnh 3D mà không thay đổi kích thước đối tượng biểu đồ trên slide.

Ví dụ sau tạo một biểu đồ [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) với dữ liệu mặc định: ba dãy và bốn danh mục. Nó lưu ba bản trình chiếu với tỷ lệ chiều cao là 50%, 100% và 200%. Vị trí, chiều rộng và chiều cao của biểu đồ vẫn cố định. Dữ liệu, góc quay, độ sâu, khoảng cách dãy và định dạng đều giống nhau trong ba tệp; chỉ tỷ lệ chiều cao thay đổi.

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

Các hình ảnh dưới đây được xuất từ các bản trình chiếu tạo ra bằng Microsoft PowerPoint. Phần trăm thấp hơn tạo ra cảnh phẳng hơn, trong khi phần trăm cao hơn tạo ra cảnh cao hơn trong cùng một đối tượng biểu đồ. PowerPoint cũng có thể điều chỉnh khoảng cách ghi nhãn trục và vị trí nhãn để phù hợp với cảnh.

| Chiều cao: 50% | Chiều cao: 100% | Chiều cao: 200% |
| --- | --- | --- |
| ![Biểu đồ cột 3D với chiều cao đặt bằng 50% chiều rộng](height_percent_50.png) | ![Biểu đồ cột 3D với chiều cao đặt bằng 100% chiều rộng](height_percent_100.png) | ![Biểu đồ cột 3D với chiều cao đặt bằng 200% chiều rộng](height_percent_200.png) |

Các thuộc tính này kiểm soát các khía cạnh khác nhau của biểu đồ:

| Thuộc tính | Ảnh hưởng |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | Chiều cao của cảnh 3D dưới dạng phần trăm chiều rộng của nó. |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | Chiều cao của đối tượng biểu đồ trên slide, tính bằng point. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Độ sâu của cảnh 3D dưới dạng phần trăm chiều rộng của nó. |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Khoảng cách giữa các dãy dọc theo trục độ sâu, tính bằng phần trăm chiều rộng của marker. |

Cài đặt chiều cao ảnh hưởng đến các biểu đồ cột và thanh 3D, bao gồm các biến thể hình trụ, nón và kim tự tháp, cũng như các biểu đồ đường, vùng, tròn và bề mặt 3D. So sánh ở trên sử dụng loại `Column3D` đã được xác thực. Cài đặt này không thay đổi giao diện của biểu đồ `ClusteredColumn` 2D hoặc biểu đồ `BubbleWith3D`; các tên này là thành viên của enumeration [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Đối với các cài đặt giao diện biểu đồ khác, xem [Chart Formatting](/slides/vi/net/chart-formatting/).

## **Điều chỉnh khoảng cách giữa các dãy**

Sử dụng [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) để kiểm soát khoảng cách giữa các dãy dữ liệu dọc theo trục độ sâu của biểu đồ 3D, tính bằng phần trăm chiều rộng của marker. Sử dụng các giá trị từ **0 đến 500**, bao gồm: `0` loại bỏ khoảng cách, trong khi các giá trị lớn hơn tăng khoảng cách. Với độ sâu biểu đồ cố định, tăng khoảng cách làm cho các marker mỏng hơn dọc theo trục độ sâu.

Truy cập nhóm thông qua [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/). Cài đặt áp dụng cho mọi dãy trong nhóm đó, không chỉ dãy được dùng để truy cập. [IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) là chỉ đọc và phản ánh cài đặt của nhóm cha.

Cài đặt này ảnh hưởng đến các biểu đồ cột và thanh 3D, bao gồm các biến thể hình trụ, nón và kim tự tháp, cũng như các biểu đồ đường và vùng 3D. Giao diện phụ thuộc vào việc các dãy được sắp xếp theo độ sâu, nhóm lại hay chồng lên nhau. Để so sánh rõ ràng khoảng cách giữa các dãy riêng biệt, hãy sử dụng `ChartType.Column3D` từ enumeration [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/).

Các thuộc tính này kiểm soát các khía cạnh khác nhau của biểu đồ:

| Thuộc tính | Ảnh hưởng |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Khoảng cách giữa các dãy dọc theo trục độ sâu, tính bằng phần trăm chiều rộng của marker. |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | Khoảng cách giữa các cụm thanh hoặc cột liền kề, tính bằng phần trăm chiều rộng của thanh hoặc cột. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Độ sâu tổng thể của biểu đồ, tính bằng phần trăm chiều rộng của biểu đồ. |

Ví dụ tự chứa dưới đây sử dụng dữ liệu biểu đồ mặc định, bao gồm ba dãy và bốn danh mục. Nó lưu hai bản trình chiếu với dữ liệu, góc quay, độ rộng khoảng cách và độ sâu biểu đồ giống nhau; chỉ độ sâu khoảng cách thay đổi.

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

Các hình ảnh dưới đây được xuất từ các bản trình chiếu tạo ra bằng Microsoft PowerPoint.

| Độ sâu khoảng cách: 0% | Độ sâu khoảng cách: 500% |
| --- | --- |
| ![Biểu đồ cột 3D không có khoảng cách giữa các dãy dọc theo trục độ sâu](gap_depth_0.png) | ![Biểu đồ cột 3D có khoảng cách 500% giữa các dãy dọc theo trục độ sâu](gap_depth_500.png) |

## **Thay đổi loại dãy 3D và hình dạng cột**

Trong một biểu đồ hình trụ nhóm, dãy đầu tiên bắt đầu với hình dạng cột hình trụ. Ví dụ đọc [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) và [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/) trước và sau mỗi lần thay đổi.

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

| Thay đổi cho dãy đầu tiên | `Type` | `Bar3DShape` |
| --- | --- | --- |
| Tạo biểu đồ | `ClusteredCylinder` | `Cylinder` |
| Đặt `Type` thành `ClusteredCone` | `ClusteredCone` | `Cone` |
| Đặt `Bar3DShape` thành `Box` | `ClusteredColumn3D` | `Box` |

Đặt hình dạng thành `Box` cũng thay đổi loại dãy thành `ClusteredColumn3D`. Nếu mã của bạn phân nhánh dựa trên loại dãy, hãy đọc `series.Type` sau khi thay đổi hình dạng. Một giá trị được lưu trữ trước khi gán vẫn sẽ chọn nhánh `ClusteredCone`.

![So sánh PowerPoint hiển thị dãy đầu tiên dưới dạng cột hình trụ, nón và cột hình chữ nhật từ trái sang phải](series-shapes.png)

## **Câu hỏi thường gặp**

**Các loại biểu đồ nào hỗ trợ chế độ 3D trong Aspose.Slides?**

Aspose.Slides hỗ trợ các biến thể 3D của biểu đồ cột, bao gồm Column 3D, Clustered Column 3D, Stacked Column 3D và 100% Stacked Column 3D, cùng với các loại 3D liên quan được khai báo trong enumeration [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Để biết danh sách chính xác, cập nhật, kiểm tra các thành viên của [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) trong tài liệu API của phiên bản bạn đang sử dụng.

**Tôi có thể lấy hình ảnh raster của biểu đồ 3D cho báo cáo hoặc web không?**

Có. Bạn có thể xuất biểu đồ thành hình ảnh bằng [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) hoặc [render toàn slide](/slides/vi/net/convert-powerpoint-to-png/) ra các định dạng như PNG hoặc JPEG. Điều này hữu ích khi bạn cần bản xem trước raster hoặc muốn nhúng biểu đồ vào tài liệu, bảng điều khiển hoặc trang web mà không cần PowerPoint.

**Hiệu năng khi xây dựng và render các biểu đồ 3D lớn như thế nào?**

Hiệu năng phụ thuộc vào khối lượng dữ liệu và độ phức tạp hình ảnh. Để có kết quả tốt nhất, nên giảm tối thiểu các hiệu ứng 3D, tránh sử dụng kết cấu nặng trên tường và vùng vẽ, hạn chế số điểm dữ liệu mỗi dãy khi có thể, và render với kích thước đầu ra phù hợp (độ phân giải và kích thước) để đáp ứng nhu cầu hiển thị hoặc in ấn.