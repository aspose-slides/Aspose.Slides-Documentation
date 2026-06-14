---
title: Tạo hoặc Cập nhật Biểu đồ Bài thuyết trình PowerPoint trong .NET
linktitle: Tạo hoặc Cập nhật Biểu đồ
type: docs
weight: 10
url: /vi/net/create-chart/
keywords:
- thêm biểu đồ
- tạo biểu đồ
- chỉnh sửa biểu đồ
- thay đổi biểu đồ
- cập nhật biểu đồ
- biểu đồ phân tán
- biểu đồ tròn
- biểu đồ đường
- biểu đồ cây bản đồ
- biểu đồ chứng khoán
- biểu đồ hộp và râu
- biểu đồ phễu
- biểu đồ sunburst
- biểu đồ histogram
- biểu đồ radar
- biểu đồ nhiều danh mục
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tạo và tùy chỉnh biểu đồ trong bài thuyết trình PowerPoint sử dụng Aspose.Slides cho .NET. Thêm, định dạng và chỉnh sửa biểu đồ với các ví dụ mã thực tế bằng C#."
---
## **Tổng quan**

Bài viết này cung cấp hướng dẫn toàn diện về cách tạo và tùy chỉnh biểu đồ bằng Aspose.Slides cho .NET. Bạn sẽ học cách thêm biểu đồ vào slide một cách lập trình, đưa dữ liệu vào, và áp dụng các tùy chọn định dạng khác nhau để phù hợp với yêu cầu thiết kế của mình. Toàn bộ bài viết bao gồm các ví dụ mã chi tiết minh họa từng bước, từ việc khởi tạo bản trình bày và đối tượng biểu đồ đến cấu hình series, trục và chú giải. Khi làm theo hướng dẫn này, bạn sẽ nắm vững cách tích hợp việc tạo biểu đồ động vào các ứng dụng .NET, giúp đơn giản hoá quá trình tạo các bản trình diễn dựa trên dữ liệu.

## **Tạo biểu đồ**

Biểu đồ giúp người dùng nhanh chóng hình dung dữ liệu và rút ra những insight mà có thể không ngay lập tức thấy được từ bảng tính hoặc bảng dữ liệu.

**Tại sao cần tạo biểu đồ?**

Sử dụng biểu đồ, bạn có thể:

* tổng hợp, nén hoặc tóm tắt lượng dữ liệu lớn trên một slide trong bản trình bày;
* hiển thị các mẫu và xu hướng trong dữ liệu;
* suy ra hướng và động lực của dữ liệu theo thời gian hoặc theo một đơn vị đo lường cụ thể;
* phát hiện các ngoại lệ, lệch chuẩn, sai sót và dữ liệu vô nghĩa;
* truyền đạt hoặc trình bày dữ liệu phức tạp.

Trong PowerPoint, bạn có thể tạo biểu đồ thông qua chức năng *Insert*, cung cấp các mẫu để thiết kế nhiều loại biểu đồ. Khi sử dụng Aspose.Slides, bạn có thể tạo cả biểu đồ thông thường (dựa trên các loại biểu đồ phổ biến) và biểu đồ tùy chỉnh.

{{% alert color="primary" %}}
Sử dụng enumeration [ChartType](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/charttype/) trong không gian tên [Aspose.Slides.Charts](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/). Các giá trị trong enumeration này tương ứng với các loại biểu đồ khác nhau.
{{% /alert %}}

### **Tạo biểu đồ Cột Gom Nhóm**

Phần này giải thích cách tạo biểu đồ cột gom nhóm bằng Aspose.Slides cho .NET. Bạn sẽ học cách khởi tạo một bản trình bày, thêm biểu đồ và tùy chỉnh các yếu tố như tiêu đề, dữ liệu, series, danh mục và kiểu dáng. Thực hiện các bước dưới đây để xem cách một biểu đồ cột gom nhóm tiêu chuẩn được tạo ra:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Lấy tham chiếu đến slide bằng chỉ mục của nó.
1. Thêm một biểu đồ với một số dữ liệu và chỉ định loại `ChartType.ClusteredColumn`.
1. Thêm tiêu đề cho biểu đồ.
1. Truy cập worksheet dữ liệu của biểu đồ.
1. Xóa tất cả series và danh mục mặc định.
1. Thêm series và danh mục mới.
1. Thêm dữ liệu biểu đồ mới cho series.
1. Áp dụng màu nền cho series.
1. Thêm nhãn cho series.
1. Lưu bản trình bày đã sửa dưới dạng file PPTX.

Mã C# sau minh họa cách tạo biểu đồ cột gom nhóm:

```c#
// Khởi tạo lớp Presentation.
using (Presentation presentation = new Presentation())
{
    // Truy cập slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm biểu đồ cột gom nhóm với dữ liệu mặc định.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // Đặt tiêu đề biểu đồ.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Đặt series đầu tiên để hiển thị giá trị.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // Đặt chỉ mục của bảng dữ liệu biểu đồ.
    int worksheetIndex = 0;

    // Lấy workbook dữ liệu biểu đồ.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Xóa series và danh mục được tạo mặc định.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Thêm series mới.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    // Thêm danh mục mới.
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    // Lấy series biểu đồ đầu tiên.
    IChartSeries series = chart.ChartData.Series[0];

    // Điền dữ liệu cho series.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Đặt màu nền cho series.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // Lấy series biểu đồ thứ hai.
    series = chart.ChartData.Series[1];

    // Điền dữ liệu cho series.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // Đặt màu nền cho series.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // Đặt nhãn đầu tiên để hiển thị tên danh mục.
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // Đặt series để hiển thị giá trị cho nhãn thứ ba.
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // Lưu bản trình bày vào đĩa dưới dạng file PPTX.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Biểu đồ Cột Gom Nhóm](clustered_column_chart.png)

### **Tạo biểu đồ Scatter**

Biểu đồ Scatter (còn gọi là scatter plot hoặc đồ thị x-y) thường được sử dụng để kiểm tra các mẫu hoặc thể hiện mối tương quan giữa hai biến.

Sử dụng biểu đồ scatter khi:

* Bạn có dữ liệu số cặp đôi.
* Hai biến có liên quan chặt chẽ với nhau.
* Bạn muốn xác định liệu hai biến có liên quan hay không.
* Bạn có một biến độc lập có nhiều giá trị cho một biến phụ thuộc.

Mã C# dưới đây cho thấy cách tạo biểu đồ scatter với một loạt marker khác nhau:

```c#
// Khởi tạo lớp Presentation.
using (Presentation presentation = new Presentation())
{
    // Truy cập slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Tạo biểu đồ scatter mặc định.
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // Đặt chỉ mục của bảng dữ liệu biểu đồ.
    int worksheetIndex = 0;

    // Lấy workbook dữ liệu biểu đồ.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Xóa series mặc định.
    chart.ChartData.Series.Clear();

    // Thêm series mới.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 3, "Series 2"), chart.Type);

    // Lấy series biểu đồ đầu tiên.
    IChartSeries series = chart.ChartData.Series[0];

    // Thêm một điểm mới (1:3) vào series.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 1, 1), workbook.GetCell(worksheetIndex, 2, 2, 3));

    // Thêm một điểm mới (2:10).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 1, 2), workbook.GetCell(worksheetIndex, 3, 2, 10));

    // Thay đổi loại series.
    series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

    // Thay đổi marker của series biểu đồ.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Star;

    // Lấy series biểu đồ thứ hai.
    series = chart.ChartData.Series[1];

    // Thêm một điểm mới (5:2) vào series biểu đồ.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 3, 5), workbook.GetCell(worksheetIndex, 2, 4, 2));

    // Thêm một điểm mới (3:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 3, 3), workbook.GetCell(worksheetIndex, 3, 4, 1));

    // Thêm một điểm mới (2:2).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 4, 3, 2), workbook.GetCell(worksheetIndex, 4, 4, 2));

    // Thêm một điểm mới (5:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 5, 3, 5), workbook.GetCell(worksheetIndex, 5, 4, 1));

    // Thay đổi marker của series biểu đồ.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Circle;

    // Lưu bản trình bày vào đĩa dưới dạng file PPTX.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Biểu đồ Scatter](scatter_chart.png)

### **Tạo biểu đồ Pie**

Biểu đồ Pie thích hợp để hiển thị mối quan hệ phần‑trong‑toàn của dữ liệu, đặc biệt khi dữ liệu có các nhãn phân loại kèm giá trị số. Tuy nhiên, nếu dữ liệu của bạn có quá nhiều phần hoặc nhãn, bạn có thể cân nhắc sử dụng biểu đồ cột thay thế.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Lấy tham chiếu đến slide bằng chỉ mục của nó.
1. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại `ChartType.Pie`.
1. Truy cập workbook dữ liệu của biểu đồ ([IChartDataWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/)).
1. Xóa series và danh mục mặc định.
1. Thêm series và danh mục mới.
1. Thêm dữ liệu biểu đồ mới cho series.
1. Thêm các điểm mới cho biểu đồ và áp dụng màu tùy chỉnh cho các sector của biểu đồ Pie.
1. Đặt nhãn cho series.
1. Bật các đường dẫn (leader lines) cho nhãn series.
1. Đặt góc xoay cho biểu đồ Pie.
1. Lưu bản trình chiếu đã sửa dưới dạng file PPTX.

Mã C# sau cho thấy cách tạo biểu đồ Pie:

```c#
// Khởi tạo lớp Presentation.
using (Presentation presentation = new Presentation())
{
    // Truy cập slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm biểu đồ với dữ liệu mặc định.
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    // Đặt tiêu đề biểu đồ.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Đặt series đầu tiên để hiển thị giá trị.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // Đặt chỉ mục của bảng dữ liệu biểu đồ.
    int worksheetIndex = 0;

    // Lấy workbook dữ liệu biểu đồ.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Xóa series và danh mục được tạo mặc định.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Thêm danh mục mới.
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    // Thêm series mới.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Điền dữ liệu cho series.
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Đặt màu cho sector.
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // Đặt viền cho sector.
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // Đặt viền cho sector.
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // Đặt viền cho sector.
    point2.Format.Line.FillFormat.FillType = FillType.Solid;
    point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
    point2.Format.Line.Width = 2.0;
    point2.Format.Line.Style = LineStyle.ThinThin;
    point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

    // Tạo nhãn tùy chỉnh cho mỗi danh mục trong series mới.
    IDataLabel label1 = series.DataPoints[0].Label;

    label1.DataLabelFormat.ShowValue = true;

    IDataLabel label2 = series.DataPoints[1].Label;
    label2.DataLabelFormat.ShowValue = true;
    label2.DataLabelFormat.ShowLegendKey = true;
    label2.DataLabelFormat.ShowPercentage = true;

    IDataLabel label3 = series.DataPoints[2].Label;
    label3.DataLabelFormat.ShowSeriesName = true;
    label3.DataLabelFormat.ShowPercentage = true;

    // Đặt series để hiển thị leader lines cho biểu đồ.
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    // Đặt góc xoay cho các sector của biểu đồ pie.
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // Lưu bản trình bày vào đĩa dưới dạng file PPTX.
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Biểu đồ Pie](pie_chart.png)

### **Tạo biểu đồ Line**

Biểu đồ Line (còn gọi là line graph) thích hợp trong các trường hợp bạn muốn thể hiện sự thay đổi giá trị theo thời gian. Bằng biểu đồ line, bạn có thể so sánh một lượng lớn dữ liệu cùng một lúc, theo dõi các thay đổi và xu hướng qua thời gian, làm nổi bật các bất thường trong series dữ liệu, và nhiều hơn nữa.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Lấy tham chiếu đến slide bằng chỉ mục của nó.
1. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại `ChartType.Line`.
1. Truy cập workbook dữ liệu của biểu đồ ([IChartDataWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/)).
1. Xóa series và danh mục mặc định.
1. Thêm series và danh mục mới.
1. Thêm dữ liệu biểu đồ mới cho series.
1. Lưu bản trình chiếu đã sửa dưới dạng file PPTX.

Mã C# sau cho thấy cách tạo biểu đồ line:

```c#
using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

Mặc định, các điểm trên biểu đồ line được nối bằng các đường thẳng liên tục. Nếu bạn muốn các điểm được nối bằng nét gạch, bạn có thể chỉ định kiểu dash mong muốn như sau:

```c#
foreach (IChartSeries series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```

Kết quả:

![Biểu đồ Line](line_chart.png)

### **Tạo biểu đồ Tree Map**

Biểu đồ Tree Map thích hợp cho dữ liệu bán hàng khi bạn muốn hiển thị kích thước tương đối của các danh mục dữ liệu và nhanh chóng thu hút sự chú ý tới các mục đóng góp lớn trong mỗi danh mục.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Lấy tham chiếu đến slide bằng chỉ mục của nó.
1. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại `ChartType.Treemap`.
1. Truy cập workbook dữ liệu của biểu đồ ([IChartDataWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/)).
1. Xóa series và danh mục mặc định.
1. Thêm series và danh mục mới.
1. Thêm dữ liệu biểu đồ mới cho series.
1. Lưu bản trình chiếu đã sửa dưới dạng file PPTX.

Mã C# dưới đây cho thấy cách tạo biểu đồ tree map:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // Nhánh 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // Nhánh 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Treemap);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D8", 3));

    series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

    presentation.Save("Treemap.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Biểu đồ Treemap](treemap_chart.png)

### **Tạo biểu đồ Stock**

Biểu đồ Stock được dùng để hiển thị dữ liệu tài chính như giá mở cửa, cao nhất, thấp nhất và đóng cửa, giúp phân tích xu hướng thị trường và độ biến động. Chúng cung cấp những hiểu biết quan trọng về hiệu suất cổ phiếu, hỗ trợ nhà đầu tư và nhà phân tích đưa ra quyết định sáng suốt.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Lấy tham chiếu đến slide bằng chỉ mục của nó.
1. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại `ChartType.OpenHighLowClose`.
1. Truy cập workbook dữ liệu của biểu đồ ([IChartDataWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/)).
1. Xóa series và danh mục mặc định.
1. Thêm series và danh mục mới.
1. Thêm dữ liệu biểu đồ mới cho series.
1. Chỉ định định dạng HiLowLines.
1. Lưu bản trình chiếu đã sửa dưới dạng file PPTX.

Mã C# sau cho thấy cách tạo biểu đồ stock:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "A"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "B"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C"));

    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Open"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "High"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 3, "Low"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 4, "Close"), chart.Type);

    IChartSeries series = chart.ChartData.Series[0];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 1, 72));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 1, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 1, 38));

    series = chart.ChartData.Series[1];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 2, 172));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 2, 57));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 2, 57));

    series = chart.ChartData.Series[2];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 3, 13));

    series = chart.ChartData.Series[3];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 4, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 4, 38));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 4, 50));

    chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
    chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

    foreach (IChartSeries ser in chart.ChartData.Series)
    {
        ser.Format.Line.FillFormat.FillType = FillType.NoFill;
    }

    chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Biểu đồ Stock](stock_chart.png)

### **Tạo biểu đồ Box and Whisker**

Biểu đồ Box and Whisker được dùng để hiển thị phân bố dữ liệu bằng cách tóm tắt các chỉ số thống kê chính như trung vị, tứ phân vị và các ngoại lệ tiềm năng. Chúng rất hữu ích trong phân tích dữ liệu khám phá và các nghiên cứu thống kê để nhanh chóng hiểu được độ biến thiên của dữ liệu và xác định các bất thường.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Lấy tham chiếu đến slide bằng chỉ mục của nó.
1. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại `ChartType.BoxAndWhisker`.
1. Truy cập workbook dữ liệu của biểu đồ ([IChartDataWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/)).
1. Xóa series và danh mục mặc định.
1. Thêm series và danh mục mới.
1. Thêm dữ liệu biểu đồ mới cho series.
1. Lưu bản trình chiếu đã sửa dưới dạng file PPTX.

Mã C# dưới đây cho thấy cách tạo biểu đồ box and whisker:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

    series.QuartileMethod = QuartileMethodType.Exclusive;
    series.ShowMeanLine = true;
    series.ShowMeanMarkers = true;
    series.ShowInnerPoints = true;
    series.ShowOutlierPoints = true;

    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B1", 15));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B2", 41));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B3", 16));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B4", 10));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B5", 23));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B6", 16));

    presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
}
```

### **Tạo biểu đồ Funnel**

Biểu đồ Funnel được dùng để trực quan hoá các quy trình gồm các giai đoạn tuần tự, trong đó khối lượng dữ liệu giảm dần khi tiến từ bước này sang bước tiếp theo. Chúng đặc biệt hữu ích để phân tích tỷ lệ chuyển đổi, xác định các nút thắt và theo dõi hiệu suất của quy trình bán hàng hoặc marketing.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Lấy tham chiếu đến slide bằng chỉ mục của nó.
1. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại `ChartType.Funnel`.
1. Lưu bản trình chiếu đã sửa dưới dạng file PPTX.

Mã C# sau cho thấy cách tạo biểu đồ funnel:

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B1", 50));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B2", 100));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B3", 200));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B4", 300));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B5", 400));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B6", 500));

    presentation.Save("Funnel.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Biểu đồ Funnel](funnel_chart.png)

### **Tạo biểu đồ Sunburst**

Biểu đồ Sunburst được dùng để trực quan hoá dữ liệu phân cấp, hiển thị các mức độ dưới dạng các vòng đồng tâm. Chúng giúp minh hoạ mối quan hệ phần‑trong‑toàn và là lựa chọn lý tưởng để biểu diễn các danh mục và tiểu mục lồng nhau một cách rõ ràng, gọn gàng.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Lấy tham chiếu đến slide bằng chỉ mục của nó.
1. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại `ChartType.Sunburst`.
1. Lưu bản trình chiếu đã sửa dưới dạng file PPTX.

Mã C# dưới đây cho thấy cách tạo biểu đồ sunburst:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // Nhánh 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // Nhánh 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D8", 3));

    presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Biểu đồ Sunburst](sunburst_chart.png)

### **Tạo biểu đồ Histogram**

Biểu đồ Histogram được dùng để biểu diễn phân bố của dữ liệu số bằng cách nhóm các giá trị vào các khoảng (bins). Chúng đặc biệt hữu ích để phát hiện các mẫu dữ liệu như tần suất, độ lệch và độ phân tán, cũng như để tìm ngoại lệ trong một tập dữ liệu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Lấy tham chiếu đến slide bằng chỉ mục của nó.
1. Thêm một biểu đồ với một số dữ liệu và chỉ định loại `ChartType.Histogram`.
1. Truy cập workbook dữ liệu của biểu đồ ([IChartDataWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/)).
1. Xóa series và danh mục mặc định.
1. Thêm series và danh mục mới.
1. Lưu bản trình chiếu đã sửa dưới dạng file PPTX.

Mã C# sau cho thấy cách tạo biểu đồ histogram:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Histogram, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Histogram);
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A1", 15));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A2", -41));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A3", 16));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A4", 10));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A5", -23));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A6", 16));

    chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

    presentation.Save("Histogram.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Biểu đồ Histogram](histogram_chart.png)

### **Tạo biểu đồ Radar**

Biểu đồ Radar được dùng để hiển thị dữ liệu đa biến trong một định dạng hai chiều, cho phép so sánh nhiều biến đồng thời. Chúng đặc biệt hữu ích để xác định các mẫu, điểm mạnh và điểm yếu qua nhiều chỉ số hiệu suất hoặc thuộc tính.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Lấy tham chiếu đến slide bằng chỉ mục của nó.
1. Thêm một biểu đồ với một số dữ liệu và chỉ định loại `ChartType.Radar`.
1. Lưu bản trình chiếu đã sửa dưới dạng file PPTX.

Mã C# dưới đây cho thấy cách tạo biểu đồ radar:

```c#
using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Biểu đồ Radar](radar_chart.png)

### **Tạo biểu đồ Multi‑Category**

Biểu đồ Multi‑Category được dùng để hiển thị dữ liệu có nhiều nhóm phân loại, cho phép bạn so sánh giá trị qua nhiều chiều cùng lúc. Chúng đặc biệt hữu ích khi cần phân tích xu hướng và mối quan hệ trong các bộ dữ liệu phức tạp, đa lớp.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Lấy tham chiếu đến slide bằng chỉ mục của nó.
1. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại `ChartType.ClusteredColumn`.
1. Truy cập workbook dữ liệu của biểu đồ ([IChartDataWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/)).
1. Xóa series và danh mục mặc định.
1. Thêm series và danh mục mới.
1. Thêm dữ liệu biểu đồ mới cho series.
1. Lưu bản trình chiếu đã sửa dưới dạng file PPTX.

Mã C# sau cho thấy cách tạo biểu đồ multi‑category:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    int worksheetIndex = 0;

    IChartCategory category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c2", "A"));
    category.GroupingLevels.SetGroupingItem(1, "Group1");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c3", "B"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c4", "C"));
    category.GroupingLevels.SetGroupingItem(1, "Group2");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c5", "D"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c6", "E"));
    category.GroupingLevels.SetGroupingItem(1, "Group3");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c7", "F"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c8", "G"));
    category.GroupingLevels.SetGroupingItem(1, "Group4");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c9", "H"));

    // Thêm một series.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "D1", "Series 1"), ChartType.ClusteredColumn);

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D2", 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D3", 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D4", 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D5", 40));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D6", 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D7", 60));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D8", 70));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D9", 80));

    // Lưu bản trình bày với biểu đồ.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Biểu đồ Multi‑Category](multi_category_chart.png)

### **Tạo biểu đồ Map**

Biểu đồ Map được dùng để trực quan hoá dữ liệu địa lý bằng cách gắn thông tin vào các vị trí cụ thể như quốc gia, tiểu bang hoặc thành phố. Chúng rất hữu ích để phân tích xu hướng khu vực, dữ liệu nhân khẩu học và phân bố không gian một cách rõ ràng và hấp dẫn.

Mã C# dưới đây cho thấy cách tạo biểu đồ map:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Biểu đồ Map](map_chart.png)

### **Tạo biểu đồ Combination**

Biểu đồ Combination (hoặc combo chart) kết hợp hai hoặc nhiều loại biểu đồ trong một đồ thị. Biểu đồ này cho phép bạn làm nổi bật, so sánh hoặc kiểm tra sự khác biệt giữa hai hoặc nhiều bộ dữ liệu, giúp xác định mối quan hệ giữa chúng.

![Biểu đồ Combination](combination_chart.png)

Mã C# sau cho thấy cách tạo biểu đồ combination như trên trong một bản trình chiếu PowerPoint:

```c#
private static void CreateComboChart()
{
    using (Presentation presentation = new Presentation())
    {
        IChart chart = CreateChartWithFirstSeries(presentation.Slides[0]);

        AddSecondSeriesToChart(chart);
        AddThirdSeriesToChart(chart);

        SetPrimaryAxesFormat(chart);
        SetSecondaryAxesFormat(chart);

        presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart CreateChartWithFirstSeries(ISlide slide)
{
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Đặt tiêu đề biểu đồ
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    IPortionFormat portionFormat = 
       chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    // Đặt chú giải biểu đồ
    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    // Xóa series và danh mục được tạo mặc định
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Thêm danh mục mới
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 4, 0, "Category 4"));

    // Thêm series đầu tiên
    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 4.3));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 3.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

private static void AddSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 2.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 4.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 1.8));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 2, 2.8));
}

private static void AddThirdSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), ChartType.Line);

    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 1, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 2, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 3, 3, 3.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 4, 3, 5.0));

    series.PlotOnSecondAxis = true;
}

private static void SetPrimaryAxesFormat(IChart chart)
{
    // Đặt trục ngang
    IAxis horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    // Đặt trục dọc
    IAxis verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    // Đặt màu cho lưới chính dọc
    ILineFillFormat majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

private static void SetSecondaryAxesFormat(IChart chart)
{
    // Đặt trục ngang phụ
    IAxis secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    // Đặt trục dọc phụ
    IAxis secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

private static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    IPortionFormat titlePortionFormat =
        axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```

## **Cập nhật biểu đồ**

Aspose.Slides cho .NET cho phép bạn cập nhật biểu đồ PowerPoint bằng cách sửa đổi dữ liệu, định dạng và kiểu dáng. Tính năng này đơn giản hoá quá trình duy trì bản trình bày luôn đồng bộ với nội dung động và đảm bảo biểu đồ phản ánh chính xác dữ liệu hiện tại cùng tiêu chuẩn hình ảnh.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) đại diện cho bản trình bày chứa biểu đồ.
1. Lấy tham chiếu đến slide bằng chỉ mục của nó.
1. Duyệt qua tất cả các shape để tìm biểu đồ.
1. Truy cập worksheet dữ liệu của biểu đồ.
1. Sửa đổi series dữ liệu bằng cách thay đổi giá trị series.
1. Thêm series mới và điền dữ liệu cho nó.
1. Lưu bản trình bày đã sửa dưới dạng file PPTX.

Mã C# dưới đây cho thấy cách cập nhật một biểu đồ:

```c#
const string chartName = "My chart";

// Khởi tạo lớp Presentation đại diện cho tệp PPTX.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Truy cập slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            // Đặt chỉ mục của bảng dữ liệu biểu đồ.
            int worksheetIndex = 0;

            // Lấy workbook dữ liệu biểu đồ.
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Thay đổi tên danh mục của biểu đồ.
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // Lấy series đầu tiên của biểu đồ.
            IChartSeries series = chart.ChartData.Series[0];

            // Cập nhật dữ liệu cho series.
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // Đang sửa đổi tên series.
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // Lấy series thứ hai của biểu đồ.
            series = chart.ChartData.Series[1];

            // Cập nhật dữ liệu cho series.
            workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2"); // Đang sửa đổi tên series.
            series.DataPoints[0].Value.Data = 23;
            series.DataPoints[1].Value.Data = 67;
            series.DataPoints[2].Value.Data = 99;

            // Thêm một series mới.
            series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), chart.Type);

            // Điền dữ liệu cho series.
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 3, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 3, 50));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 3, 30));

            chart.Type = ChartType.ClusteredCylinder;
        }
    }

    // Lưu bản trình bày kèm biểu đồ.
    presentation.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
}
```

## **Đặt phạm vi dữ liệu cho biểu đồ**

Aspose.Slides cho .NET cung cấp khả năng định nghĩa một phạm vi dữ liệu cụ thể từ worksheet làm nguồn cho dữ liệu biểu đồ. Điều này cho phép bạn ánh xạ trực tiếp một phần của worksheet vào biểu đồ, kiểm soát các ô nào sẽ đóng góp vào series và danh mục của biểu đồ. Nhờ vậy, bạn có thể dễ dàng cập nhật và đồng bộ biểu đồ với các thay đổi dữ liệu mới nhất trong worksheet, đảm bảo bản trình bày PowerPoint luôn phản ánh thông tin hiện tại và chính xác.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) đại diện cho bản trình bày chứa biểu đồ.
1. Lấy tham chiếu đến slide bằng chỉ mục của nó.
1. Duyệt qua tất cả các shape để tìm biểu đồ.
1. Truy cập dữ liệu biểu đồ và đặt phạm vi.
1. Lưu bản trình bày đã sửa dưới dạng file PPTX.

Mã C# dưới đây cho thấy cách đặt phạm vi dữ liệu cho biểu đồ:

```c#
const string chartName = "My chart";

// Khởi tạo lớp Presentation đại diện cho tệp PPTX.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Truy cập slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            chart.ChartData.SetRange("Sheet1!A1:B4");
        }
    }

    presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
}
```

## **Sử dụng marker mặc định trong biểu đồ**

Khi sử dụng marker mặc định trong biểu đồ, mỗi series sẽ tự động nhận một ký hiệu marker mặc định khác nhau.

Mã C# dưới đây cho thấy cách tự động đặt marker cho series biểu đồ:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "C1"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 24));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "C2"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 23));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C3"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, -10));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "C4"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 1, null));

    IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

    // Điền dữ liệu cho series.
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Các loại biểu đồ nào được Aspose.Slides cho .NET hỗ trợ?**

Aspose.Slides cho .NET hỗ trợ đa dạng các loại biểu đồ, bao gồm bar, line, pie, area, scatter, histogram, radar và nhiều loại khác. Sự linh hoạt này cho phép bạn chọn loại biểu đồ phù hợp nhất cho nhu cầu trực quan hoá dữ liệu của mình.

**Làm thế nào để thêm một biểu đồ mới vào slide?**

Để thêm một biểu đồ, trước tiên bạn tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation), lấy slide mong muốn bằng chỉ mục, sau đó gọi phương thức thêm biểu đồ, chỉ định loại biểu đồ và dữ liệu khởi tạo. Quá trình này sẽ tích hợp biểu đồ trực tiếp vào bản trình bày của bạn.

**Làm sao để cập nhật dữ liệu hiển thị trong biểu đồ?**

Bạn có thể cập nhật dữ liệu của biểu đồ bằng cách truy cập workbook dữ liệu của nó ([IChartDataWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/)), xóa các series và danh mục mặc định, rồi thêm dữ liệu tùy chỉnh của bạn. Điều này cho phép bạn làm mới biểu đồ một cách lập trình để phản ánh dữ liệu mới nhất.

**Có thể tùy chỉnh giao diện của biểu đồ không?**

Có, Aspose.Slides cho .NET cung cấp nhiều tùy chọn tùy chỉnh. Bạn có thể thay đổi màu sắc, phông chữ, nhãn, chú giải và các yếu tố định dạng khác để điều chỉnh giao diện biểu đồ sao cho phù hợp với yêu cầu thiết kế của mình.