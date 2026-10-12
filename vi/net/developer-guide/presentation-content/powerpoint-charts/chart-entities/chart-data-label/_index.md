---
title: Quản lý Nhãn Dữ Liệu Biểu Đồ trong Bài Trình Chiếu .NET
linktitle: Nhãn Dữ Liệu
type: docs
url: /vi/net/chart-data-label/
keywords:
- biểu đồ
- nhãn dữ liệu
- độ chính xác dữ liệu
- phần trăm
- khoảng cách nhãn
- vị trí nhãn
- PowerPoint
- bài trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách thêm và định dạng nhãn dữ liệu biểu đồ trong các bản trình chiếu PowerPoint bằng Aspose.Slides cho .NET để tạo các slide hấp dẫn hơn."
---
## **Giới thiệu**

Nhãn dữ liệu hiển thị thông tin về các chuỗi biểu đồ và các điểm dữ liệu riêng lẻ, giúp người đọc xác định giá trị và hiểu biểu đồ. Bài viết này giải thích cách định dạng giá trị, hiển thị phần trăm, đọc văn bản nhãn, kiểm soát nhãn vượt quá giá trị tối đa của trục, điều chỉnh khoảng cách nhãn trục danh mục và vị trí nhãn biểu đồ tròn.

## **Đặt Độ Chính Xác Dữ Liệu trong Nhãn Dữ Liệu Biểu Đồ**

Sử dụng [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) để định dạng giá trị của chuỗi. Ví dụ này tạo một biểu đồ đường với dữ liệu mặc định, hiển thị bảng dữ liệu của nó và bật nhãn giá trị cho chuỗi đầu tiên. Định dạng `#,##0.00` hiển thị dấu phân cách hàng nghìn và hai chữ số thập phân mà không thay đổi giá trị gốc.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
chart.HasDataTable = true;

var series = chart.ChartData.Series[0];
series.NumberFormatOfValues = "#,##0.00";
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
```

## **Hiển Thị Phần Trăm dưới Dạng Nhãn**

Đối với biểu đồ cột chồng, tính mỗi giá trị dưới dạng phần trăm của tổng danh mục của nó và gán văn bản cho [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). Ví dụ này sử dụng dữ liệu biểu đồ mặc định và hiển thị phần trăm với hai chữ số thập phân trong phông chữ 8 điểm. Các danh mục có tổng bằng không sẽ bị bỏ qua để tránh chia cho zero. Tính lại văn bản nhãn tùy chỉnh nếu dữ liệu biểu đồ thay đổi.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);

var categoryTotals = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        var series = chart.ChartData.Series[i];
        var pointValue = Convert.ToDouble(series.DataPoints[k].Value.Data);
        categoryTotals[k] += pointValue;
    }
}

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    var series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        var label = series.DataPoints[j].Label;
        if (categoryTotals[j] == 0)
        {
            continue;
        }

        var pointValue = Convert.ToDouble(series.DataPoints[j].Value.Data);
        var dataPointPercent = (pointValue / categoryTotals[j]) * 100;

        var portion = new Portion();
        portion.Text = string.Format("{0:F2} %", dataPointPercent);
        portion.PortionFormat.FontHeight = 8f;

        label.TextFrameForOverriding.Text = "";

        var paragraph = label.TextFrameForOverriding.Paragraphs[0];
        paragraph.Portions.Add(portion);

        label.DataLabelFormat.ShowValue = true;
        label.DataLabelFormat.ShowSeriesName = false;
        label.DataLabelFormat.ShowPercentage = false;
        label.DataLabelFormat.ShowLegendKey = false;
        label.DataLabelFormat.ShowCategoryName = false;
        label.DataLabelFormat.ShowBubbleSize = false;
    }
}

presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **Đặt Dấu Phần Trăm với Nhãn Dữ Liệu Biểu Đồ**

Khi giá trị được lưu dưới dạng phân số, sử dụng [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) để hiển thị phần trăm. Đặt [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) thành `false` để áp dụng định dạng nhãn một cách độc lập với các ô nguồn.

Ví dụ này tạo một biểu đồ cột chồng 100% với các chuỗi màu đỏ và xanh dương trên bốn danh mục. Mỗi cặp giá trị cộng lại thành 1. Định dạng nhãn `0.0%` hiển thị 0.30 thành 30.0%, trong khi trục dọc sử dụng hai chữ số thập phân. Cả hai chuỗi đều sử dụng văn bản nhãn màu trắng, kích thước 10 điểm.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
int worksheetIndex = 0;
for (int i = 0; i < 4; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

string[] seriesNames = { "Reds", "Blues" };
Color[] seriesColors = { Color.Red, Color.Blue };
double[,] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

for (int i = 0; i < seriesNames.Length; i++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, i + 1, seriesNames[i]);
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);
    for (int j = 0; j < 4; j++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, j + 1, i + 1, values[i, j]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColors[i];

    var labelFormat = series.Labels.DefaultDataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = false;
    labelFormat.NumberFormat = "0.0%";
    labelFormat.TextFormat.PortionFormat.FontHeight = 10;
    labelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
}

presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **Đọc Văn Bản Thực Tế của Nhãn Dữ Liệu**

Sử dụng [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) để lấy văn bản được tạo ra bởi các thiết lập của nhãn dữ liệu. Điều này hữu ích khi trích xuất nhãn cho báo cáo, tìm kiếm nội dung bản trình bày hoặc xác thực các biểu đồ đã tạo. Trong ví dụ dưới đây, [định dạng nhãn dữ liệu](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) mặc định kết hợp mỗi tên danh mục, tên chuỗi và giá trị. Một điểm định dạng giá trị của nó dưới dạng phần trăm, và một điểm khác sử dụng văn bản tùy chỉnh từ [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Q1"));
chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Q2"));

var north = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "North"), chart.Type);
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 0.25));
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 0.75));

var south = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "South"), chart.Type);
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 0.40));
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 0.60));

foreach (var series in chart.ChartData.Series)
{
    var format = series.Labels.DefaultDataLabelFormat;
    format.ShowCategoryName = true;
    format.ShowSeriesName = true;
    format.ShowValue = true;
}

north.Labels[1].DataLabelFormat.IsNumberFormatLinkedToSource = false;
north.Labels[1].DataLabelFormat.NumberFormat = "0%";
south.Labels[0].TextFrameForOverriding.Text = "Reviewed";

foreach (var series in chart.ChartData.Series)
{
    foreach (var point in series.DataPoints)
    {
        var label = point.Label;
        if (!label.IsVisible)
        {
            continue;
        }

        Console.WriteLine($"Value: {point.Value.Data}; label: {label.GetActualLabelText()}");
    }
}
```

Số lưu trong một điểm dữ liệu vẫn giữ là `0.75`, ngay cả khi nhãn của nó hiển thị `75%` cùng với tên danh mục và chuỗi. Văn bản tùy chỉnh thay thế văn bản nhãn được tạo ra. [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) trả về chuỗi nhãn kết quả trong cả hai trường hợp. Kiểm tra [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) riêng biệt, như shown above, khi bạn muốn trích xuất chỉ các nhãn hiển thị.

## **Kiểm Soát Nhãn Dữ Liệu Vượt Quá Giá Trị Tối Đa Của Trục**

Khi bạn giới hạn phạm vi trục một cách thủ công, một số điểm dữ liệu có thể vượt quá giá trị tối đa của nó. Sử dụng [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) để kiểm soát việc hiển thị nhãn dữ liệu của chúng. Cài đặt này thay đổi khả năng hiển thị nhãn; nó không thay đổi phạm vi trục hay các giá trị dữ liệu gốc.

Ví dụ dưới đây tạo một biểu đồ cột cụm 2D với các giá trị 60 và 120. Nó đặt [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) thành `false` và [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) thành 100 trên trục dọc. Slide đầu tiên cho phép nhãn vượt quá giá trị tối đa; một bản sao của slide đó tắt chúng. Cả hai slide được lưu trong `DataLabelsOverMaximum.pptx`.

Bật nhãn giá trị bằng [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). Cài đặt ở mức biểu đồ không tự động bật hiển thị giá trị hoặc ghi đè việc tắt hiển thị giá trị của một nhãn riêng lẻ. Ví dụ này bật giá trị cho toàn bộ chuỗi và sử dụng [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) để đặt nhãn ở đầu ngoài của mỗi cột.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;

var firstCategory = workbook.GetCell(0, 1, 0, "Within range");
var secondCategory = workbook.GetCell(0, 2, 0, "Above maximum");

chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);

var seriesName = workbook.GetCell(0, 0, 1, "Values");
var series = chart.ChartData.Series.Add(seriesName, chart.Type);

var firstValue = workbook.GetCell(0, 1, 1, 60);
var secondValue = workbook.GetCell(0, 2, 1, 120);

series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);

series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;

chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 100;
chart.ShowDataLabelsOverMaximum = true;

var secondSlide = presentation.Slides.AddClone(slide);
var secondChart = (IChart)secondSlide.Shapes[0];
secondChart.ShowDataLabelsOverMaximum = false;

presentation.Save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
```

Các hình ảnh dưới đây cho thấy các slide đã lưu được Microsoft PowerPoint render. Với `true`, nhãn **120** hiển thị ở rìa trên; với `false`, nó bị ẩn. Nhãn **60** vẫn hiển thị, giá trị tối đa của trục vẫn là **100**, và điểm dữ liệu thứ hai vẫn là **120** trong cả hai trường hợp.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Ví dụ này sử dụng biểu đồ cột 2D với trục giá trị. Các biểu đồ không có trục giá trị, như biểu đồ tròn và vòng donut, không có giá trị tối đa của trục để giới hạn theo cách này.
{{% /alert %}}

## **Đặt Khoảng Cách Nhãn Từ Trục**

Sử dụng [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) để kiểm soát khoảng cách giữa các nhãn trục danh mục và trục. Giá trị là phần trăm của kích thước phông chữ tối đa của các nhãn trục. Ví dụ này tạo một biểu đồ cột cụm và đặt độ lệch nhãn trục ngang thành 500. Cài đặt này ảnh hưởng đến nhãn trục danh mục chứ không phải nhãn gắn vào các điểm dữ liệu riêng lẻ.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
chart.Axes.HorizontalAxis.LabelOffset = 500;

presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **Điều Chỉnh Vị Trí Nhãn**

Trong biểu đồ tròn, điều chỉnh vị trí nhãn dữ liệu để cải thiện khoảng cách và tạo chỗ cho các đường nối.

Ví dụ này hiển thị giá trị của điểm dữ liệu đầu tiên, đặt nhãn của nó bên ngoài phần của biểu đồ, và điều chỉnh độ lệch [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) và [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/). Các độ lệch này tương đối với chiều rộng và chiều cao của biểu đồ, tương ứng.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);
var series = chart.ChartData.Series;

var label = series[0].Labels[0];
label.DataLabelFormat.ShowValue = true;
label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
label.X = 0.71f;
label.Y = 0.04f;

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

![Biểu đồ tròn với vị trí nhãn dữ liệu đã điều chỉnh](pie-chart-adjusted-label.png)

## **Thêm Nhiều Hàng Nhãn Dữ Liệu Phía Trên Biểu Đồ Cột**

Ví dụ này tạo một biểu đồ cột với hai hàng nhãn dữ liệu phía trên khu vực vẽ. Chuỗi A hiển thị các cột có thể nhìn thấy, trong khi Chuỗi B và Chuỗi C cung cấp các nhãn bổ sung. Các cột của chúng bị ẩn bằng cách loại bỏ màu nền và viền. Thuộc tính [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) căn chỉnh cả ba chuỗi tại cùng trung tâm danh mục.

Cài đặt [PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) dành chỗ cho các hàng nhãn. Sau khi [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) tính toán vị trí mặc định, [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) và [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) giữ cân bằng ngang và áp dụng độ lệch dọc để sắp xếp các nhãn thành hai hàng. Các số vẫn là nhãn dữ liệu liên kết với giá trị của chuỗi; chỉ tiêu đề hàng là các hình dạng văn bản riêng.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 640, 200);
chart.HasTitle = false;
chart.HasLegend = false;
chart.TextFormat.PortionFormat.FontHeight = 12;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

string[] categories = { "North", "South", "East", "West" };
string[] seriesNames = { "Series A", "Series B", "Series C" };
double[,] seriesValues = {
    { 35, 42, 28, 47 },
    { 22, 31, 19, 26 },
    { 12, 16, 14, 18 }
};

for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
{
    var categoryCell = workbook.GetCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
    chart.ChartData.Categories.Add(categoryCell);
}

for (int seriesIndex = 0; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var seriesCell = workbook.GetCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
    var series = chart.ChartData.Series.Add(seriesCell, ChartType.ClusteredColumn);

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var valueCell = workbook.GetCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    if (seriesIndex > 0)
    {
        // Ẩn các cột của B và C, nhưng giữ lại nhãn dữ liệu của chúng.
        series.Format.Fill.FillType = FillType.NoFill;
        series.Format.Line.FillFormat.FillType = FillType.NoFill;
        var labelFormat = series.Labels.DefaultDataLabelFormat;
        labelFormat.ShowValue = true;
        labelFormat.TextFormat.PortionFormat.FontHeight = 12;
        var labelFill = labelFormat.TextFormat.PortionFormat.FillFormat;
        labelFill.FillType = FillType.Solid;
        labelFill.SolidFillColor.Color = Color.Black;
        labelFormat.Position = LegendDataLabelPosition.InsideBase;
    }
}

// Align all three series with the same category centers.
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// Use fewer gridlines for this compact example.
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// Reserve space above the plot for two rows of data labels.
chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;
chart.PlotArea.X = 0.15f;
chart.PlotArea.Y = 0.32f;
chart.PlotArea.Width = 0.80f;
chart.PlotArea.Height = 0.48f;
chart.ValidateChartLayout();

for (int seriesIndex = 1; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    float rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var dataLabel = series.DataPoints[categoryIndex].Label;
        // Giữ vị trí ngang mặc định. Y là một độ dịch từ
        // vị trí nhãn mặc định, được biểu diễn dưới dạng tỷ lệ chiều cao biểu đồ.
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // Chỉ tiêu đề hàng là một hình dạng văn bản riêng biệt.
    var rowHeading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, chart.X, chart.Y + rowTop * chart.Height, 85, 18);
    rowHeading.FillFormat.FillType = FillType.NoFill;
    rowHeading.LineFormat.FillFormat.FillType = FillType.NoFill;
    rowHeading.AddTextFrame(seriesNames[seriesIndex]);
    rowHeading.TextFrame.TextFrameFormat.MarginTop = 0;
    rowHeading.TextFrame.TextFrameFormat.MarginBottom = 0;
    var headingFormat = rowHeading.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    headingFormat.FontHeight = 12;
    headingFormat.FillFormat.FillType = FillType.Solid;
    headingFormat.FillFormat.SolidFillColor.Color = Color.Black;
}

presentation.Save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
```

![Biểu đồ cột với hai hàng nhãn dữ liệu phía trên khu vực vẽ](multiple-rows-of-labels.png)

## **Câu Hỏi Thường Gặp**

**Làm thế nào để ngăn nhãn dữ liệu chồng lên nhau trên các biểu đồ dày đặc?**  
Kết hợp việc đặt nhãn tự động, đường nối và giảm kích thước phông chữ; nếu cần, ẩn một số trường (ví dụ, danh mục) hoặc chỉ hiển thị nhãn cho các giá trị cực đoan hoặc các điểm then chốt.

**Làm thế nào để tắt nhãn chỉ cho các giá trị zero, âm hoặc rỗng?**  
Lọc các điểm dữ liệu trước khi bật nhãn và tắt hiển thị cho các giá trị bằng 0, giá trị âm hoặc giá trị thiếu theo quy tắc đã định.

**Làm thế nào để đảm bảo kiểu nhãn nhất quán khi xuất ra PDF/hình ảnh?**  
Cài đặt rõ ràng họ phông chữ và kích thước, và xác minh phông chữ có sẵn trong môi trường render để tránh việc thay thế.