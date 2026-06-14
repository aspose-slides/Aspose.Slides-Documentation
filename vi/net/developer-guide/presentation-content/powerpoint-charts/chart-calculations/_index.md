---
title: "Tối ưu hoá tính toán biểu đồ cho bản trình chiếu trong .NET"
linktitle: "Tính toán biểu đồ"
type: docs
weight: 50
url: /vi/net/chart-calculations/
keywords:
- "tính toán biểu đồ"
- "các thành phần biểu đồ"
- "vị trí thành phần"
- "vị trí thực"
- "thành phần con"
- "thành phần cha"
- "giá trị biểu đồ"
- "giá trị thực"
- "PowerPoint"
- "bản trình chiếu"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Hiểu về tính toán biểu đồ, cập nhật dữ liệu và kiểm soát độ chính xác trong Aspose.Slides cho .NET cho PPT và PPTX, với các ví dụ mã C# thực tế."
---
## **Tổng quan**

Aspose.Slides cung cấp các API để làm việc với các phép tính và dữ liệu bố cục của biểu đồ trong bản trình chiếu. Bài viết này hướng dẫn cách lấy các giá trị thực tế của các thành phần biểu đồ, bao gồm vị trí và kích thước thực của các thành phần triển khai `IActualLayout` và các giá trị thực của trục biểu đồ. Nó cũng giải thích rằng các giá trị này được điền sau khi xác thực bố cục biểu đồ.

Thêm vào đó, bài viết trình bày cách lấy vị trí thực của các thành phần biểu đồ cha và cách ẩn các thành phần biểu đồ như tiêu đề, các trục, chú giải và các đường lưới. Những ví dụ này giúp bạn kiểm tra thông tin bố cục biểu đồ và kiểm soát khả năng hiển thị của các thành phần biểu đồ trong bản PowerPoint một cách lập trình.

## **Tính toán các giá trị thực của các thành phần biểu đồ**
Aspose.Slides for .NET cung cấp một API đơn giản để lấy các thuộc tính này. Điều này sẽ giúp bạn tính các giá trị thực của các thành phần biểu đồ. Các giá trị thực bao gồm vị trí của các thành phần triển khai giao diện IActualLayout (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) và các giá trị thực của trục (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();
    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Lưu bản trình chiếu
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **Tính toán vị trí thực của các thành phần biểu đồ cha**
Aspose.Slides for .NET cung cấp một API đơn giản để lấy các thuộc tính này. Các thuộc tính của IActualLayout cung cấp thông tin về vị trí thực của thành phần biểu đồ cha. Cần gọi phương thức IChart.ValidateChartLayout() trước để điền các thuộc tính bằng các giá trị thực.

```c#
// Tạo bản trình chiếu trống
using (Presentation pres = new Presentation())
{
   Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
   chart.ValidateChartLayout();

   double x = chart.PlotArea.ActualX;
   double y = chart.PlotArea.ActualY;
   double w = chart.PlotArea.ActualWidth;
   double h = chart.PlotArea.ActualHeight;
}
```

## **Ẩn các thành phần biểu đồ**
Bài này giúp bạn hiểu cách ẩn thông tin khỏi biểu đồ. Sử dụng Aspose.Slides cho .NET, bạn có thể ẩn **Tiêu đề, Trục dọc, Trục ngang** và **Các đường lưới** khỏi biểu đồ. Ví dụ mã dưới đây cho thấy cách sử dụng các thuộc tính này.

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Ẩn tiêu đề biểu đồ
    chart.HasTitle = false;

    ///Ẩn trục giá trị
    chart.Axes.VerticalAxis.IsVisible = false;

    //Hiển thị trục danh mục
    chart.Axes.HorizontalAxis.IsVisible = false;

    //Ẩn chú giải
    chart.HasLegend = false;

    //Ẩn các đường lưới chính
    chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series.RemoveAt(i);
    }

    IChartSeries series = chart.ChartData.Series[0];

    series.Marker.Symbol = MarkerStyleType.Circle;
    series.Labels.DefaultDataLabelFormat.ShowValue = true;
    series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.Top;
    series.Marker.Size = 15;

    //Đặt màu cho đường series
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Các sổ làm việc Excel bên ngoài có hoạt động như nguồn dữ liệu không, và điều đó ảnh hưởng như thế nào đến việc tính lại?**

Có. Một biểu đồ có thể tham chiếu tới một sổ làm việc bên ngoài: khi bạn kết nối hoặc làm mới nguồn bên ngoài, các công thức và giá trị được lấy từ sổ đó, và biểu đồ phản ánh các cập nhật trong quá trình mở/chỉnh sửa. API cho phép bạn [chỉ định sổ làm việc bên ngoài](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chartdata/setexternalworkbook/) đường dẫn và quản lý dữ liệu được liên kết.

**Tôi có thể tính toán và hiển thị các đường xu hướng mà không phải tự triển khai hồi quy không?**

Có. [Đường xu hướng](/slides/vi/net/trend-line/) (tuyến tính, hàm số mũ và các loại khác) được thêm và cập nhật bởi Aspose.Slides; các tham số của chúng được tính lại tự động từ dữ liệu chuỗi, vì vậy bạn không cần tự triển khai các phép tính.

**Nếu một bản trình bày có nhiều biểu đồ với liên kết bên ngoài, tôi có thể kiểm soát sổ làm việc nào mà mỗi biểu đồ sử dụng cho các giá trị được tính không?**

Có. Mỗi biểu đồ có thể trỏ tới [sổ làm việc bên ngoài](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chartdata/setexternalworkbook/) riêng của nó, hoặc bạn có thể tạo/thay thế một sổ làm việc bên ngoài cho từng biểu đồ một cách độc lập với các biểu đồ khác.