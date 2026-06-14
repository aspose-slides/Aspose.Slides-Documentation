---
title: Tùy chỉnh thanh lỗi trong biểu đồ trình chiếu bằng .NET
linktitle: Thanh lỗi
type: docs
url: /vi/net/error-bar/
keywords:
- thanh lỗi
- giá trị tùy chỉnh
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách thêm và tùy chỉnh thanh lỗi trong biểu đồ với Aspose.Slides cho .NET—tối ưu hoá trực quan dữ liệu trong các bản trình chiếu PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với thanh lỗi trong biểu đồ trình chiếu bằng cách sử dụng Aspose.Slides. Nó cho thấy cách thêm thanh lỗi vào một chuỗi biểu đồ, cấu hình thiết lập thanh lỗi X và Y, và áp dụng các kiểu giá trị khác nhau như cố định, phần trăm và giá trị tùy chỉnh.

Nó cũng trình bày cách chỉ định giá trị thanh lỗi tùy chỉnh cho các điểm dữ liệu riêng lẻ trong một chuỗi bằng cách sử dụng bộ sưu tập điểm dữ liệu tương ứng. Ngoài ra, bài viết bao gồm các ghi chú ngắn về cách thanh lỗi hoạt động khi xuất, khả năng tương thích với các dấu đánh dấu và nhãn dữ liệu, và nơi tìm các lớp tham chiếu API và enum liên quan.

## **Thêm thanh lỗi**
Aspose.Slides for .NET cung cấp một API đơn giản để quản lý giá trị thanh lỗi. Mã mẫu được áp dụng khi sử dụng kiểu giá trị tùy chỉnh. Để chỉ định một giá trị, hãy sử dụng thuộc tính **ErrorBarCustomValues** của một điểm dữ liệu cụ thể trong bộ sưu tập **DataPoints** của chuỗi:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Thêm một biểu đồ bong bóng vào slide mong muốn.
1. Truy cập chuỗi biểu đồ đầu tiên và đặt định dạng thanh lỗi X.
1. Truy cập chuỗi biểu đồ đầu tiên và đặt định dạng thanh lỗi Y.
1. Đặt giá trị và định dạng cho các thanh.
1. Ghi bản trình chiếu đã chỉnh sửa ra tập tin PPTX.

```c#
// Tạo bản trình chiếu trống
using (Presentation presentation = new Presentation())
{
    // Tạo biểu đồ bong bóng
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Thêm thanh lỗi và thiết lập định dạng
    IErrorBarsFormat errBarX = chart.ChartData.Series[0].ErrorBarsXFormat;
    IErrorBarsFormat errBarY = chart.ChartData.Series[0].ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Fixed;
    errBarX.Value = 0.1f;
    errBarY.ValueType = ErrorBarValueType.Percentage;
    errBarY.Value = 5;
    errBarX.Type = ErrorBarType.Plus;
    errBarY.Format.Line.Width = 2;
    errBarX.HasEndCap = true;

    // Lưu bản trình chiếu
    presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```

## **Thêm giá trị thanh lỗi tùy chỉnh**
Aspose.Slides for .NET cung cấp một API đơn giản để quản lý giá trị thanh lỗi tùy chỉnh. Mã mẫu được áp dụng khi thuộc tính **IErrorBarsFormat.ValueType** bằng **Custom**. Để chỉ định một giá trị, hãy sử dụng thuộc tính **ErrorBarCustomValues** của một điểm dữ liệu cụ thể trong bộ sưu tập **DataPoints** của chuỗi:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Thêm một biểu đồ bong bóng vào slide mong muốn.
1. Truy cập chuỗi biểu đồ đầu tiên và đặt định dạng thanh lỗi X.
1. Truy cập chuỗi biểu đồ đầu tiên và đặt định dạng thanh lỗi Y.
1. Truy cập các điểm dữ liệu riêng lẻ của chuỗi biểu đồ và đặt giá trị thanh lỗi cho từng điểm dữ liệu.
1. Đặt giá trị và định dạng cho các thanh.
1. Ghi bản trình chiếu đã chỉnh sửa ra tập tin PPTX.

```c#
// Tạo bản trình chiếu trống
using (Presentation presentation = new Presentation())
{
    // Tạo biểu đồ bong bóng
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Thêm thanh lỗi tùy chỉnh và thiết lập định dạng của nó
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;

    // Truy cập điểm dữ liệu của chuỗi biểu đồ và đặt giá trị thanh lỗi cho điểm riêng lẻ
    IChartDataPointCollection points = series.DataPoints;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    // Đặt thanh lỗi cho các điểm của chuỗi biểu đồ
    for (int i = 0; i < points.Count; i++)
    {
        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
    }

    // Lưu bản trình chiếu
    presentation.Save("ErrorBarsCustomValues_out.pptx", SaveFormat.Pptx);
}
```

## **Câu hỏi thường gặp**

**Điều gì xảy ra với thanh lỗi khi xuất bản trình chiếu sang PDF hoặc hình ảnh?**

Chúng được render như một phần của biểu đồ và được giữ nguyên trong quá trình chuyển đổi cùng với phần còn lại của định dạng biểu đồ, với giả sử phiên bản hoặc trình render tương thích.

**Thanh lỗi có thể kết hợp với dấu đánh dấu và nhãn dữ liệu không?**

Có. Thanh lỗi là một yếu tố riêng biệt và tương thích với dấu đánh dấu và nhãn dữ liệu; nếu các yếu tố chồng lên nhau, bạn có thể cần điều chỉnh định dạng.

**Tôi có thể tìm danh sách các thuộc tính và enum để làm việc với thanh lỗi trong API ở đâu?**

Trong tài liệu API: lớp [ErrorBarsFormat](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/errorbarsformat/) và các enum liên quan [ErrorBarType](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/errorbartype/) và [ErrorBarValueType](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/errorbarvaluetype/).