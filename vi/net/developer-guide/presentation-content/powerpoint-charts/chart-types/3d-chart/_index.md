---
title: Tùy chỉnh biểu đồ 3D trong các bản trình chiếu bằng .NET
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
description: "Tìm hiểu cách tạo và tùy chỉnh biểu đồ 3D trong Aspose.Slides cho .NET, hỗ trợ các tệp PPT và PPTX—nâng cao các bản trình chiếu của bạn ngay hôm nay."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh biểu đồ 3D trong Aspose.Slides bằng cách cấu hình các thiết lập `Rotation3D` như `RotationX`, `RotationY`, `DepthPercents` và `RightAngleAxes`. Nó hướng dẫn tạo một bản trình chiếu, thêm biểu đồ 3D với dữ liệu mặc định, áp dụng các thiết lập hiển thị 3D cần thiết và lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

## **Đặt các thuộc tính RotationX, RotationY và DepthPercents cho biểu đồ 3D**
Aspose.Slides for .NET cung cấp một API đơn giản để đặt các thuộc tính này. Bài viết dưới đây sẽ giúp bạn cách thiết lập các thuộc tính khác nhau như X, Y Rotation, **DepthPercents** v.v. Mã mẫu áp dụng việc thiết lập các thuộc tính đã nêu ở trên.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Truy cập slide đầu tiên.
1. Thêm biểu đồ với dữ liệu mặc định.
1. Đặt các thuộc tính Rotation3D.
1. Ghi bản trình chiếu đã chỉnh sửa vào tệp PPTX.

```c#
// Tạo một thể hiện của lớp Presentation
Presentation presentation = new Presentation();
           
// Truy cập slide đầu tiên
ISlide slide = presentation.Slides[0];

// Thêm biểu đồ với dữ liệu mặc định
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// Đặt chỉ mục của bảng dữ liệu biểu đồ
int defaultWorksheetIndex = 0;

// Lấy worksheet dữ liệu biểu đồ
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Thêm series
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

// Thêm danh mục
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

// Đặt các thuộc tính Rotation3D
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// Lấy series biểu đồ thứ hai
IChartSeries series = chart.ChartData.Series[1];

// Bây giờ đang điền dữ liệu cho series
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Đặt giá trị OverLap
series.ParentSeriesGroup.Overlap = 100;         

// Ghi bản trình chiếu ra đĩa
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **Câu hỏi thường gặp**

**Các loại biểu đồ nào hỗ trợ chế độ 3D trong Aspose.Slides?**

Aspose.Slides hỗ trợ các biến thể 3D của biểu đồ cột, bao gồm Column 3D, Clustered Column 3D, Stacked Column 3D và 100% Stacked Column 3D, cùng với các loại 3D liên quan được khai báo trong enumeration [ChartType](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/charttype/). Để có danh sách chính xác và cập nhật, hãy kiểm tra các thành viên của [ChartType](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/charttype/) trong tài liệu API của phiên bản đã cài đặt.

**Tôi có thể lấy hình raster của biểu đồ 3D để báo cáo hoặc trên web không?**

Có. Bạn có thể xuất biểu đồ ra hình ảnh thông qua [chart API](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/getimage/) hoặc [render toàn bộ slide](/slides/vi/net/convert-powerpoint-to-png/) sang các định dạng như PNG hoặc JPEG. Điều này hữu ích khi bạn cần một bản xem trước pixel-perfect hoặc muốn nhúng biểu đồ vào tài liệu, bảng điều khiển hoặc trang web mà không cần PowerPoint.

**Hiệu năng của việc xây dựng và render các biểu đồ 3D lớn như thế nào?**

Hiệu năng phụ thuộc vào khối lượng dữ liệu và độ phức tạp về hình ảnh. Để đạt kết quả tốt nhất, nên giữ tối thiểu các hiệu ứng 3D, tránh sử dụng các kết cấu nặng trên tường và vùng vẽ, giới hạn số điểm dữ liệu trên mỗi series khi có thể, và render với kích thước đầu ra phù hợp (độ phân giải và kích thước) để đáp ứng nhu cầu hiển thị hoặc in ấn.