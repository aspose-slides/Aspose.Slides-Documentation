---
title: Quản lý Sổ làm việc Biểu đồ trong Bản trình bày bằng .NET
linktitle: Sổ làm việc Biểu đồ
type: docs
weight: 70
url: /vi/net/chart-workbook/
keywords:
- sổ làm việc biểu đồ
- dữ liệu biểu đồ
- ô sổ làm việc
- nhãn dữ liệu
- bảng tính
- nguồn dữ liệu
- sổ làm việc bên ngoài
- dữ liệu bên ngoài
- bộ nhớ đệm biểu đồ
- khôi phục sổ làm việc
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Khám phá Aspose.Slides cho .NET: dễ dàng quản lý sổ làm việc biểu đồ trong các định dạng PowerPoint và OpenDocument để tối ưu hóa dữ liệu bản trình bày của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sổ làm việc biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua luồng sổ làm việc, sử dụng các ô sổ làm việc làm nhãn dữ liệu biểu đồ, truy cập bộ sưu tập worksheet và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng đề cập đến việc làm việc với sổ làm việc bên ngoài như nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một sổ làm việc bên ngoài, lấy đường dẫn của sổ làm việc bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi sổ làm việc có sẵn.

Đối với các ô sổ làm việc đại diện cho dữ liệu thiếu, hãy xem mục [Kiểm soát hiển thị các ô trống](/slides/vi/net/chart-series/) để hiểu sự khác biệt giữa ô trống và số 0, cùng so sánh biểu đồ đường cho các chế độ hiển thị có sẵn.

## **Bao gồm dữ liệu từ các hàng và cột ẩn**

Sử dụng [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) để điều khiển liệu biểu đồ có vẽ dữ liệu từ các hàng và cột worksheet ẩn hay không. Đặt giá trị thành `true` để chỉ vẽ các ô hiển thị, hoặc `false` để bao gồm cả ô hiển thị và ẩn. Cài đặt này kiểm soát việc vẽ biểu đồ; nó không ẩn hoặc hiện các hàng hay cột worksheet.

[File mẫu](hidden-source-data.pptx) chứa một biểu đồ cột là hình dạng đầu tiên trên slide đầu tiên. Worksheet được nhúng, `Sheet1`, chứa phạm vi nguồn sau, `A1:C4`. Hàng 3 và cột C bị ẩn, nhưng các ô của chúng vẫn chứa giá trị.

| Hàng worksheet | A: Tháng | B: Bán lẻ | C: Bán buôn (cột ẩn) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

Truy cập các ô nguồn thông qua [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) và đọc [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) để kiểm tra trạng thái ẩn của chúng. Thuộc tính này chỉ đọc. Trong tệp này, B2 hiển thị, B3 thuộc hàng ẩn, và C2 thuộc cột ẩn; ví dụ sẽ in ra `False`, `True`, và `True` tương ứng.

Đối với ví dụ này, hãy làm mới dữ liệu biểu đồ sau khi thay đổi cài đặt vẽ: giữ lại sổ làm việc được nhúng bằng [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) và tải lại bằng [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/). Khi bao gồm tất cả các ô, cũng sử dụng [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) để khôi phục phạm vi đầy đủ, bao gồm danh mục February bị ẩn. Chỉ thay đổi cờ không đủ để làm mới dữ liệu biểu đồ và nhãn danh mục được lưu trong bộ nhớ đệm của mẫu này.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("hidden-source-data.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes[0] is IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    Console.WriteLine($"B2 hidden: {workbook.GetCell(0, "B2").IsHidden}");
    Console.WriteLine($"B3 hidden: {workbook.GetCell(0, "B3").IsHidden}");
    Console.WriteLine($"C2 hidden: {workbook.GetCell(0, "C2").IsHidden}");

    using var workbookStream = chart.ChartData.ReadWorkbookStream();
    foreach (var visibleOnly in new[] { true, false })
    {
        chart.PlotVisibleCellsOnly = visibleOnly;

        // Làm mới dữ liệu biểu đồ từ sổ làm việc được nhúng.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Khôi phục phạm vi nguồn đầy đủ, bao gồm các danh mục ẩn.
            chart.ChartData.SetRange("Sheet1!$A$1:$C$4");
        }

        presentation.Save($"hidden_cells_{visibleOnly}.pptx", SaveFormat.Pptx);
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Ví dụ lưu hai phiên bản của bản trình bày: một chỉ có các giá trị Retail hiển thị (10 và 20), và một khác với cả sáu giá trị. Các hình ảnh dưới đây được tạo từ các bản trình bày đã lưu sau khi mở lại; cả hai tệp đều giữ cài đặt vẽ đã chỉ định. Hàng 3 và cột C vẫn ẩn trong cả hai sổ làm việc được nhúng.

| Chỉ các ô hiển thị (`true`) | Tất cả các ô (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

Một ô ẩn có giá trị khác với một ô trống. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) kiểm soát cách hiển thị các giá trị thiếu; nó không bao gồm hay loại bỏ dữ liệu nguồn ẩn. Xem mục [Kiểm soát hiển thị các ô trống](/slides/vi/net/chart-series/#control-the-display-of-empty-cells) để biết ví dụ.

## **Lấy phạm vi dữ liệu của biểu đồ**

Trước khi cập nhật dữ liệu sổ làm việc trong một bản trình bày hiện có, hãy kiểm tra các phạm vi nguồn để xác định ô worksheet nào được mỗi biểu đồ sử dụng. Phương thức [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) trả về phạm vi dữ liệu hiện tại dưới dạng công thức có chỉ định worksheet, ví dụ `Sheet1!$A$1:$D$5`. Ở đây, `Sheet1` là tên worksheet, `!` ngăn cách nó với phạm vi ô, và `$A$1:$D$5` chỉ các ô từ A1 đến D5, bao gồm cả chúng. Dấu đô la biểu thị tham chiếu hàng và cột tuyệt đối.

Phương thức này đọc phạm vi hiện tại mà không thay đổi biểu đồ hoặc sổ làm việc của nó. Nếu biểu đồ không sử dụng sổ làm việc làm nguồn dữ liệu, nó sẽ ném ra [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Để biết thêm thông tin, xem [Tham chiếu API ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/).

Ví dụ này mở một bản trình bày và kiểm tra các hình dạng trực tiếp trên mỗi slide để tìm biểu đồ. Nó in ra tên và phạm vi nguồn của mỗi biểu đồ. Nếu một biểu đồ không sử dụng sổ làm việc, nó sẽ in thông báo và tiếp tục sang biểu đồ tiếp theo.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            try
            {
                var range = chart.ChartData.GetRange();
                Console.WriteLine($"{chart.Name}: {range}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"{chart.Name}: The chart does not use a workbook as its data source.");
            }
        }
    }
}
```

## **Đọc và ghi dữ liệu biểu đồ từ sổ làm việc**

Aspose.Slides for .NET cung cấp các phương thức [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) và [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) cho phép bạn đọc và ghi sổ làm việc dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã chỉnh sửa bằng Aspose.Cells). **Lưu ý** rằng dữ liệu biểu đồ phải được tổ chức theo cùng một cách hoặc phải có cấu trúc tương tự như nguồn.

Ví dụ này sử dụng một bản trình bày có biểu đồ là hình dạng đầu tiên trên slide đầu tiên. Nó đọc sổ làm việc được nhúng vào một luồng, xóa các series và category hiện có, và ghi lại cùng một sổ làm việc. Các thay đổi vẫn còn trong bộ nhớ; ví dụ không lưu bản trình bày.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **Xác thực bố cục biểu đồ sau khi sửa đổi sổ làm việc**

Khi bạn thay thế một sổ làm việc được nhúng bằng một sổ làm việc đã sửa, biểu đồ vẫn giữ lại các collection series và category gốc. Sự không khớp này có thể gây lỗi cho [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) với lỗi chỉ mục ngoài phạm vi. Hãy xóa các series và category hiện có trước khi ghi sổ làm việc đã cập nhật trở lại biểu đồ. Ví dụ này sử dụng một biểu đồ là hình dạng đầu tiên trên slide đầu tiên. Các chú thích đánh dấu nơi việc chỉnh sửa sổ làm việc sẽ diễn ra; ví dụ có thể chạy sẽ ghi lại sổ làm việc gốc và xác thực bố cục trong bộ nhớ.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    // Sửa đổi luồng sổ làm việc ở đây, ví dụ, bằng cách sử dụng Aspose.Cells.

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
    chart.ValidateChartLayout();
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Xóa các collection loại bỏ các tham chiếu dữ liệu cũ trước khi sổ làm việc được ghi lại. Hãy xây dựng lại bất kỳ mapping series và category nào cần thiết cho sổ làm việc đã cập nhật trước khi sử dụng biểu đồ.

## **Đặt định dạng số tùy chỉnh cho các ô sổ làm việc**

Sử dụng [ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) để kiểm soát cách các giá trị số hiển thị trong sổ làm việc được nhúng của biểu đồ. Ví dụ, một báo cáo có thể cần tỷ lệ chuyển đổi hiển thị dưới dạng phần trăm với bốn chữ số thập phân và một hệ số hiển thị với năm chữ số thập phân. Giữ cả hai giá trị ở dạng số để chúng vẫn có thể được dùng cho các phép tính và vẽ biểu đồ.

Định dạng số chỉ thay đổi cách hiển thị, không thay đổi giá trị lưu trữ. Định dạng `0.0000%` hiển thị `0.125` thành `12.5000%`; nó không thay thế số được lưu bằng `12.5`. Tương tự, `0.00000` hiển thị `0.1234567` thành `0.12346` mà không làm tròn giá trị lưu. Nếu định dạng tùy chỉnh là chuỗi rỗng (`""`), sẽ sử dụng [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/) thay thế.

Ví dụ dưới đây tạo một biểu đồ cột và truy cập các ô của nó thông qua [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/). Trên worksheet 0, B2 chứa tỷ lệ chuyển đổi và C2 chứa hệ số. Cả hai ô đều cung cấp giá trị cho biểu đồ. Ví dụ cũng bật nhãn giá trị liên kết với định dạng nguồn.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 270, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
chart.HasTitle = false;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00";
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A2", "Sample");
chart.ChartData.Categories.Add(categoryCell);

var percentageCell = workbook.GetCell(0, "B2", 0.125);
percentageCell.CustomNumberFormat = "0.0000%";
var percentageName = workbook.GetCell(0, "B1", "Conversion rate");
var percentageSeries = chart.ChartData.Series.Add(percentageName, chart.Type);
percentageSeries.DataPoints.AddDataPointForBarSeries(percentageCell);

var precisionCell = workbook.GetCell(0, "C2", 0.1234567);
precisionCell.CustomNumberFormat = "0.00000";
var precisionName = workbook.GetCell(0, "C1", "Coefficient");
var precisionSeries = chart.ChartData.Series.Add(precisionName, chart.Type);
precisionSeries.DataPoints.AddDataPointForBarSeries(precisionCell);

foreach (var series in chart.ChartData.Series)
{
    var labelFormat = series.DataPoints[0].Label.DataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = true;
}

presentation.Save("CustomCellFormats.pptx", SaveFormat.Pptx);
```

Định dạng ô sổ làm việc tách biệt khỏi các định dạng được đặt trực tiếp trên trục biểu đồ hoặc nhãn dữ liệu. Trong ví dụ này, mỗi nhãn hiển thị giá trị của ô nguồn vì [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) được bật, và tuân theo định dạng số nguồn vì [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) là `true`. Sau khi lưu và mở lại bản trình bày, các nhãn hiển thị `12.5000%` và `0.12346`, như hình dưới. Trục dọc sử dụng [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) riêng của nó là `0.00`, với [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) đặt thành `false`.

Để định dạng một nhãn dữ liệu một cách độc lập, đặt cờ liên kết nguồn thành `false` và gán [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/). Điều này không thay đổi định dạng của ô sổ làm việc. Ví dụ, một định dạng nhãn độc lập `0.00` sẽ hiển thị giá trị đầu tiên là `0.13`, trong khi B2 vẫn hiển thị `12.5000%`. Xem mục [Nhãn dữ liệu biểu đồ](/slides/vi/net/chart-data-label/#set-percentage-sign-with-chart-data-labels) để biết cách định dạng nhãn trực tiếp.

Hình ảnh dưới đây được tạo từ bản trình bày đã lưu sau khi mở lại:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **Đặt một ô sổ làm việc làm nhãn dữ liệu biểu đồ**

Bạn có thể sử dụng văn bản từ các ô sổ làm việc làm nhãn dữ liệu biểu đồ.

Ví dụ này thêm một biểu đồ bubble với dữ liệu mặc định vào slide đầu tiên của một bản trình bày hiện có. Nó sử dụng các ô A10:A12 trên worksheet 0 cho ba nhãn đầu tiên trong series đầu tiên, bật nhãn từ ô, và lưu bản trình bày đã cập nhật.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart2.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
var series = chart.ChartData.Series[0];
var workbook = chart.ChartData.ChartDataWorkbook;

series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;
series.Labels[0].ValueFromCell = workbook.GetCell(0, "A10", "Label 0 cell value");
series.Labels[1].ValueFromCell = workbook.GetCell(0, "A11", "Label 1 cell value");
series.Labels[2].ValueFromCell = workbook.GetCell(0, "A12", "Label 2 cell value");

presentation.Save("resultchart.pptx", SaveFormat.Pptx);
```

## **Quản lý Worksheets**

Thuộc tính [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) cung cấp quyền truy cập vào các worksheet trong một sổ làm việc biểu đồ. Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và in tên mỗi worksheet ra console.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
var workbook = chart.ChartData.ChartDataWorkbook;

for (var i = 0; i < workbook.Worksheets.Count; i++)
{
    Console.WriteLine(workbook.Worksheets[i].Name);
}
```

## **Chỉ định loại nguồn dữ liệu**

Các giá trị điểm series cũng có thể được lưu trữ trực tiếp dưới dạng số nguyên. Xem mục [Đặt giá trị series bằng số nguyên](/slides/vi/net/chart-series/#set-series-values-using-numeric-literals) để có ví dụ đầy đủ về việc lưu và đọc chúng. Loại nguồn của các giá trị điểm tách biệt khỏi cấu hình sổ làm việc nội bộ hoặc bên ngoài của biểu đồ; việc sử dụng số nguyên không tự động loại bỏ sổ làm việc được nhúng.

Ví dụ này tạo một biểu đồ cột 3D với dữ liệu mặc định và đặt hai tên series bằng các nguồn dữ liệu khác nhau. Tên đầu tiên sử dụng literal chuỗi; tên thứ hai sử dụng ô C1 trên worksheet 0. Phân loại [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) xác định nguồn cho mỗi tên. Ví dụ lưu bản trình bày với các tên series đã cập nhật.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
var literalName = chart.ChartData.Series[0].Name;

literalName.DataSourceType = DataSourceType.StringLiterals;
literalName.Data = "LiteralString";

var cellName = chart.ChartData.Series[1].Name;
var nameCell = chart.ChartData.ChartDataWorkbook.GetCell(0, "C1", "NewCell");
cellName.DataSourceType = DataSourceType.Worksheet;
cellName.Data = nameCell;

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **Phát hiện định dạng sổ làm việc nhúng không được hỗ trợ**

Aspose.Slides không hỗ trợ định dạng sổ làm việc Excel nhị phân (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng thuộc tính [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) trên [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) cùng với liệt kê [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua các biểu đồ đó. Ví dụ này kiểm tra các hình dạng trên slide đầu tiên của một bản trình bày hiện có, bỏ qua các hình dạng không phải biểu đồ, và in thông báo chẩn đoán cho mỗi biểu đồ có sổ làm việc .xlsb được nhúng.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
    {
        continue;
    }

    var chartData = chart.ChartData;
    var isInternalWorkbook = chartData.DataSourceType == ChartDataSourceType.InternalWorkbook;
    var isBinaryMacro = chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console.WriteLine("Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // Đọc hoặc sửa đổi dữ liệu sổ làm việc biểu đồ được hỗ trợ tại đây.
}
```

## **Sổ làm việc bên ngoài**

Aspose.Slides hỗ trợ sử dụng sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ.

### **Tạo một sổ làm việc bên ngoài**

Sử dụng [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) và [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) để xuất sổ làm việc biểu đồ được nhúng ra file và liên kết biểu đồ với sổ làm việc bên ngoài đó.

Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và xuất sổ làm việc của nó. Nó đóng luồng xuất trước khi gán sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ, sau đó lưu bản trình bày đã liên kết.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
var workbookPath = Path.GetFullPath("externalWorkbook1.xlsx");

using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var fileStream = File.Create(workbookPath))
{
    workbookStream.CopyTo(fileStream);
}

chart.ChartData.SetExternalWorkbook(workbookPath);
presentation.Save("externalWorkbook.pptx", SaveFormat.Pptx);
```

### **Đặt một sổ làm việc bên ngoài**

Bằng cách sử dụng phương thức [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/), bạn có thể gán một sổ làm việc bên ngoài cho biểu đồ làm nguồn dữ liệu. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới sổ làm việc bên ngoài (nếu sổ làm việc đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các sổ làm việc lưu trữ ở vị trí từ xa hoặc tài nguyên, bạn vẫn có thể sử dụng các sổ làm việc đó làm nguồn dữ liệu bên ngoài. Nếu đường dẫn tương đối cho sổ làm việc bên ngoài được cung cấp, nó sẽ tự động được chuyển đổi thành đường dẫn đầy đủ.

Ví dụ này sử dụng một sổ làm việc bên ngoài có worksheet tên `Sheet1` chứa tên series trong B1, tên danh mục trong A2:A4, và giá trị số trong B2:B4. Ví dụ tạo một biểu đồ tròn, liên kết sổ làm việc, và sử dụng [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) để ánh xạ A1:B4 thành một series và ba danh mục. Nó lưu bản trình bày với biểu đồ đã liên kết.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
var chartData = chart.ChartData;
var workbookPath = Path.GetFullPath("externalWorkbook.xlsx");

chartData.SetExternalWorkbook(workbookPath);
chartData.SetRange("Sheet1!$A$1:$B$4");

presentation.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
```

Tham số `updateChartData` của [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) kiểm soát việc có tải sổ làm việc hay không.

* Khi `updateChartData` là `false`, chỉ đường dẫn sổ làm việc được cập nhật. Dữ liệu biểu đồ không được tải hoặc cập nhật từ sổ làm việc đích, vì vậy sổ làm việc có thể không có sẵn.
* Khi `updateChartData` là `true`, dữ liệu biểu đồ được cập nhật từ sổ làm việc đích.

Ví dụ sau gán một URL placeholder với `updateChartData` đặt thành `false`. Nó giữ nguyên dữ liệu mặc định của biểu đồ tròn và lưu bản trình bày mà không tải sổ làm việc không khả dụng.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);

chart.ChartData.SetExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);
presentation.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
```

### **Lấy đường dẫn sổ làm việc nguồn dữ liệu bên ngoài của một biểu đồ**

Để xác định sổ làm việc được liên kết với một biểu đồ, kiểm tra xem biểu đồ có sử dụng nguồn dữ liệu bên ngoài không và lấy đường dẫn sổ làm việc của nó.

Ví dụ này kiểm tra hình dạng đầu tiên trên slide đầu tiên của một bản trình bày có sổ làm việc bên ngoài đã liên kết. Nếu đó là một biểu đồ được liên kết với sổ làm việc bên ngoài, ví dụ sẽ in ra [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) trên console. Sau đó nó lưu một bản sao của bản trình bày.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("externalWorkbook.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    if (chartData.DataSourceType == ChartDataSourceType.ExternalWorkbook)
    {
        Console.WriteLine(chartData.ExternalWorkbookPath);
    }
    else
    {
        Console.WriteLine("The chart does not use an external workbook.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

### **Chỉnh sửa dữ liệu biểu đồ**

Bạn có thể chỉnh sửa dữ liệu trong các sổ làm việc bên ngoài tương tự như thay đổi nội dung của sổ làm việc nội bộ. Khi một sổ làm việc bên ngoài không thể được tải, một ngoại lệ sẽ được ném.

Ví dụ này sử dụng một biểu đồ là hình dạng đầu tiên trên slide đầu tiên và được liên kết với một sổ làm việc bên ngoài có thể truy cập. Nó đặt giá trị dựa trên ô của điểm dữ liệu đầu tiên trong series đầu tiên thành 100 và lưu bản trình bày đã cập nhật. Việc chỉnh sửa giá trị ô có thể cập nhật file XLSX bên ngoài được liên kết, vì vậy hãy sử dụng bản sao nếu bạn cần bảo lưu sổ làm việc gốc.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var series = chart.ChartData.Series;
    if (series.Count > 0 && series[0].DataPoints.Count > 0)
    {
        var valueCell = series[0].DataPoints[0].Value.AsCell;
        if (valueCell != null)
        {
            valueCell.Value = 100;
            presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
        }
        else
        {
            Console.WriteLine("The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console.WriteLine("The chart has no data points to edit.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **Khôi phục sổ làm việc từ bộ nhớ đệm của biểu đồ**

Nếu một biểu đồ sử dụng sổ làm việc bên ngoài bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo sổ làm việc biểu đồ từ dữ liệu được lưu trong bộ nhớ đệm của bản trình bày. Tạo [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/), cấu hình [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/), và đặt [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) thành `true` trước khi mở bản trình bày.

Ví dụ C# sau đây khôi phục dữ liệu sổ làm việc cho một biểu đồ là hình dạng đầu tiên trên slide đầu tiên và tham chiếu đến một sổ làm việc bên ngoài không khả dụng. Nó truy cập dữ liệu đã khôi phục qua [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) và [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

var spreadsheetOptions = new SpreadsheetOptions
{
    RecoverWorkbookFromChartCache = true
};
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = spreadsheetOptions
};

using var presentation = new Presentation("presentation.pptx", loadOptions);
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

    // Đọc hoặc sửa đổi dữ liệu sổ làm việc đã khôi phục ở đây.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Nếu sổ làm việc bên ngoài không khả dụng và chức năng khôi phục bị tắt, Aspose.Slides sẽ ném ra một [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Chỉ bật khôi phục khi việc sử dụng dữ liệu biểu đồ đã lưu trong bộ nhớ đệm là chấp nhận được, vì bộ nhớ đệm có thể không chứa các thay đổi đã thực hiện trên sổ làm việc bên ngoài sau khi bản trình bày được cập nhật lần cuối.

## **FAQ**

**Tôi có thể xác định xem một biểu đồ cụ thể có liên kết tới sổ làm việc bên ngoài hay sổ làm việc được nhúng không?**

Có. Một biểu đồ có [loại nguồn dữ liệu](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) và một [đường dẫn tới sổ làm việc bên ngoài](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/); nếu nguồn là sổ làm việc bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp bên ngoài đang được sử dụng.

**Các đường dẫn tương đối tới sổ làm việc bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Bản trình bày lưu đường dẫn tuyệt đối trong tệp PPTX, vì vậy việc di chuyển sổ làm việc có thể yêu cầu cập nhật liên kết.

**Tôi có thể sử dụng sổ làm việc nằm trên tài nguyên/điểm chia sẻ mạng không?**

Có, các sổ làm việc như vậy có thể được dùng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa trực tiếp các sổ làm việc từ xa bằng Aspose.Slides không được hỗ trợ—chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè lên file XLSX bên ngoài khi lưu bản trình bày không?**

Bản trình bày lưu một [liên kết tới file bên ngoài](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/). Việc chỉnh sửa dữ liệu biểu đồ dựa trên ô cũng có thể cập nhật file XLSX địa phương đã liên kết. Hãy sử dụng một bản sao của sổ làm việc nếu cần giữ nguyên bản gốc.

**Nếu file bên ngoài được bảo vệ bằng mật khẩu thì tôi nên làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Cách thường dùng là loại bỏ bảo vệ trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, bằng [Aspose.Cells](https://reference.aspose.com/cells/net/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một sổ làm việc bên ngoài không?**

Có. Mỗi biểu đồ lưu liên kết riêng của mình. Nếu chúng đều trỏ tới cùng một file, việc cập nhật file đó sẽ được phản ánh trong mỗi biểu đồ vào lần kế tiếp dữ liệu được tải.