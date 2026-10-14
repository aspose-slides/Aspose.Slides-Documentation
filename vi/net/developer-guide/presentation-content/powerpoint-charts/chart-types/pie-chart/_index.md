---
title: Tùy chỉnh biểu đồ tròn trong bài thuyết trình bằng .NET
linktitle: Biểu đồ tròn
type: docs
url: /vi/net/pie-chart/
keywords:
- biểu đồ tròn
- quản lý biểu đồ
- tùy chỉnh biểu đồ
- tùy chọn biểu đồ
- cài đặt biểu đồ
- tùy chọn vẽ
- màu lát
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tạo và tùy chỉnh biểu đồ tròn trong .NET với Aspose.Slides. Cấu hình biểu đồ phụ, hiển thị nhãn dữ liệu và áp dụng màu lát tự động trong PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với biểu đồ tròn trong Aspose.Slides. Nó cho thấy cách cấu hình các tùy chọn biểu đồ phụ cho biểu đồ Pie of Pie và Bar of Pie, và cách bật tính năng tự động tô màu các lát trong biểu đồ tròn tiêu chuẩn.

Các ví dụ tập trung vào các nhiệm vụ tùy chỉnh biểu đồ như thêm biểu đồ vào slide, điều chỉnh cài đặt chuỗi và nhãn, thay thế dữ liệu biểu đồ mặc định bằng các danh mục và giá trị tùy chỉnh, và lưu bản trình bày đã cập nhật.

## **Tùy chọn biểu đồ phụ cho biểu đồ Pie of Pie và Bar of Pie**

Aspose.Slides for .NET hỗ trợ các tùy chọn biểu đồ phụ cho biểu đồ Pie of Pie và Bar of Pie. Các tùy chọn này kiểm soát kích thước của biểu đồ phụ và cách các điểm dữ liệu được chia giữa hai biểu đồ.

Ví dụ sau tạo một biểu đồ Pie of Pie trong một bản trình bày mới và hiển thị giá trị các điểm dữ liệu dưới dạng nhãn. Thuộc tính [SecondPieSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/secondpiesize/) đặt kích thước biểu đồ phụ bằng 149% so với biểu đồ chính. [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitby/) chọn cách phân chia dựa trên phần trăm, và [PieSplitPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitposition/) đặt ngưỡng ở 53%.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
var series = chart.ChartData.Series[0];

// Display values and configure the secondary plot.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.SecondPieSize = 149;
seriesGroup.PieSplitBy = PieSplitType.ByPercentage;
seriesGroup.PieSplitPosition = 53;

presentation.Save("pie_of_pie.pptx", SaveFormat.Pptx);
```

### **Chọn danh mục cho biểu đồ phụ**

Sử dụng phân chia tùy chỉnh khi bạn muốn nhóm các danh mục cụ thể trong biểu đồ phụ bất kể giá trị phần trăm của chúng. Ví dụ, một báo cáo bán hàng có thể hiển thị Online và Events cùng nhau để người đọc có thể so sánh hai kênh này, mặc dù chúng chiếm 35% và 10% tổng doanh thu.

Đặt [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitby/) thành [PieSplitType.Custom](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplittype/) và chọn các điểm qua [PieSplitCustomPoints](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitcustompoints/). Phương thức [Add](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/add/) của bộ sưu tập chấp nhận một chỉ số bắt đầu từ 0 trong chuỗi hoặc một đối tượng điểm dữ liệu. Trong ví dụ này, chỉ số 1 chọn Online, và điểm ở chỉ số 3 chọn Events. Partners cũng được thêm tạm thời, sau đó loại bỏ bằng cách sử dụng [Remove](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/remove/).

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 200);

// Thay thế dữ liệu mặc định bằng doanh số theo kênh.
var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "Retail", "Online", "Partners", "Events" };
var values = new[] { 40, 35, 15, 10 };
var seriesNameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.PieSplitBy = PieSplitType.Custom;
seriesGroup.IsColorVaried = true;

// Chọn Online theo chỉ mục bắt đầu từ 0 và Events theo đối tượng điểm dữ liệu.
seriesGroup.PieSplitCustomPoints.Add(1);
seriesGroup.PieSplitCustomPoints.Add(series.DataPoints[3]);

// Loại bỏ Partners khỏi lựa chọn mà không xóa dữ liệu nguồn của nó.
seriesGroup.PieSplitCustomPoints.Add(2);
seriesGroup.PieSplitCustomPoints.Remove(series.DataPoints[2]);

presentation.Save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
```

Online (35) và Events (10) xuất hiện dưới dạng các lát riêng biệt trong biểu đồ phụ. Trong biểu đồ chính, chúng được đại diện bởi một lát kết hợp có giá trị 45, cùng với Retail (40) và Partners (15). Việc loại bỏ Partners khỏi lựa chọn tùy chỉnh giữ nó trong biểu đồ chính; nó không loại bỏ danh mục hoặc giá trị của nó khỏi dữ liệu nguồn của biểu đồ.

Hình ảnh sau đây hiển thị bản trình bày đã lưu trong PowerPoint:

![Biểu đồ Pie of Pie với Online và Events trong biểu đồ phụ và giá trị kết hợp của chúng là 45 trong biểu đồ chính](pie_of_pie_custom.png)

## **Đặt màu tự động cho các lát biểu đồ tròn**

Aspose.Slides for .NET có thể tự động cấp phát các màu khác nhau cho các lát của biểu đồ tròn. Ví dụ sau tạo một biểu đồ tròn với tiêu đề ở giữa và thay thế dữ liệu mặc định bằng ba danh mục quý và giá trị của chúng. Thuộc tính [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) hiển thị các giá trị 20, 50 và 30 dưới dạng nhãn, trong khi [IsColorVaried](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/iscolorvaried/) bật màu sắc riêng cho mỗi lát.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// Thêm tiêu đề biểu đồ ở giữa.
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// Thay thế dữ liệu mặc định bằng cách sử dụng bảng tính đầu tiên.
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "First Qtr", "2nd Qtr", "3rd Qtr" };
var values = new[] { 20, 50, 30 };
var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

// Hiển thị giá trị và gán các màu khác nhau cho các lát.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.ParentSeriesGroup.IsColorVaried = true;

presentation.Save("pie.pptx", SaveFormat.Pptx);
```

## **Câu hỏi thường gặp**

**Các biến thể Pie of Pie và Bar of Pie có được hỗ trợ không?**

Có, thư viện [hỗ trợ](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) một biểu đồ phụ cho các biểu đồ tròn, bao gồm các loại Pie of Pie và Bar of Pie.

**Tôi có thể xuất riêng biểu đồ dưới dạng hình ảnh (ví dụ, PNG) không?**

Có, bạn có thể [xuất biểu đồ dưới dạng hình ảnh](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (ví dụ PNG) mà không cần xuất toàn bộ bản trình bày.