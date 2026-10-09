---
title: Quản lý Sổ công việc Biểu đồ trong Bản trình bày trên .NET
linktitle: Sổ công việc Biểu đồ
type: docs
weight: 70
url: /vi/net/chart-workbook/
keywords:
- sổ công việc biểu đồ
- dữ liệu biểu đồ
- ô sổ công việc
- nhãn dữ liệu
- trang tính
- nguồn dữ liệu
- sổ công việc bên ngoài
- dữ liệu bên ngoài
- bộ nhớ đệm biểu đồ
- khôi phục sổ công việc
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Khám phá Aspose.Slides cho .NET: dễ dàng quản lý sổ công việc biểu đồ trong các định dạng PowerPoint và OpenDocument để tối ưu hóa dữ liệu bản trình bày của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sổ công việc biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua các luồng sổ công việc, sử dụng các ô sổ công việc làm nhãn dữ liệu biểu đồ, truy cập bộ sưu tập trang tính, và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng bao phủ việc làm việc với sổ công việc bên ngoài như nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một sổ công việc bên ngoài, lấy đường dẫn của sổ công việc bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi sổ công việc có sẵn.

Đối với các ô sổ công việc thể hiện dữ liệu thiếu, xem [Kiểm soát việc hiển thị các ô trống](/slides/vi/net/chart-series/) để biết sự khác nhau giữa một ô trống và số 0, và so sánh biểu đồ đường của các chế độ hiển thị có sẵn.

## **Bao gồm dữ liệu từ các hàng và cột Ẩn**

Sử dụng [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) để kiểm soát liệu biểu đồ có vẽ dữ liệu từ các hàng và cột ẩn của trang tính hay không. Đặt thành `true` để chỉ vẽ các ô hiển thị, hoặc `false` để bao gồm cả các ô hiển thị và ẩn. Cài đặt này kiểm soát việc vẽ biểu đồ; nó không ẩn hoặc hiện các hàng hoặc cột của trang tính.

The [bản trình bày mẫu](hidden-source-data.pptx) contains a column chart as the first shape on its first slide. Trang tính nhúng, `Sheet1`, contains the following source range, `A1:C4`. Hàng 3 và cột C bị ẩn, nhưng các ô của chúng vẫn chứa giá trị.

| Hàng trang tính | A: Tháng | B: Bán lẻ | C: Bán buôn (cột ẩn) |
| --- | --- | --- | --- |
| 2 | Tháng 1 | 10 | 30 |
| 3 (hàng ẩn) | Tháng 2 | 40 | 60 |
| 4 | Tháng 3 | 20 | 50 |

Truy cập các ô nguồn qua [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) và đọc [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) để kiểm tra trạng thái ẩn của chúng. Thuộc tính này chỉ đọc. Trong file này, B2 hiển thị, B3 thuộc hàng ẩn, và C2 thuộc cột ẩn; ví dụ in ra `False`, `True`, và `True` tương ứng.

For this example, refresh the chart data after changing the plotting setting: retain the embedded workbook with [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) and reload it with [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/). Khi bao gồm tất cả các ô, cũng sử dụng [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) để khôi phục phạm vi đầy đủ, bao gồm danh mục tháng 2 ẩn. Chỉ thay đổi cờ không đủ để làm mới dữ liệu biểu đồ và nhãn danh mục được lưu trong mẫu này.

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

        // Làm mới dữ liệu biểu đồ từ sổ công việc nhúng.
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

The example saves two versions of the presentation: one with only the visible Retail values (10 and 20), and another with all six values. Các hình ảnh bên dưới được tạo từ các bản trình bày đã lưu sau khi mở lại chúng; cả hai tệp đều giữ cài đặt vẽ đã chỉ định. Hàng 3 và cột C vẫn ẩn trong cả hai sổ công việc nhúng.

| Chỉ các ô hiển thị (`true`) | Tất cả các ô (`false`) |
| --- | --- |
| ![Chỉ các ô hiển thị: Giá trị Bán lẻ 10 và 20 cho Tháng 1 và Tháng 3.](hidden_cells_True.png) | ![Tất cả các ô: Giá trị Bán lẻ và Bán buôn cho Tháng 1, Tháng 2 và Tháng 3.](hidden_cells_False.png) |

Một ô ẩn chứa giá trị khác với một ô trống. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) kiểm soát cách hiển thị các giá trị thiếu; nó không bao gồm hay loại trừ dữ liệu nguồn ẩn. Xem [Kiểm soát việc hiển thị các ô trống](/slides/vi/net/chart-series/#control-the-display-of-empty-cells) để biết ví dụ.

## **Lấy phạm vi dữ liệu của biểu đồ**

Trước khi cập nhật dữ liệu sổ công việc trong một bản trình bày hiện có, kiểm tra các phạm vi nguồn để xác định ô trang tính nào được biểu đồ sử dụng. Phương thức [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) trả về phạm vi dữ liệu hiện tại dưới dạng công thức có định danh trang tính, chẳng hạn `Sheet1!$A$1:$D$5`. Ở đây, `Sheet1` là tên trang tính, `!` ngăn cách nó với phạm vi ô, và `$A$1:$D$5` chỉ các ô A1 đến D5, bao gồm cả. Dấu `$` biểu thị tham chiếu tuyệt đối cho hàng và cột.

Phương thức đọc phạm vi hiện tại mà không thay đổi biểu đồ hoặc sổ công việc của nó. Nếu biểu đồ không sử dụng sổ công việc làm nguồn dữ liệu, nó sẽ ném ra [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Để biết thêm thông tin, xem [Tham chiếu API ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/).

Ví dụ này mở một bản trình bày và kiểm tra các hình dạng trực tiếp trên mỗi slide để tìm biểu đồ. Nó in tên mỗi biểu đồ và phạm vi nguồn. Nếu một biểu đồ không sử dụng sổ công việc, nó in thông báo và tiếp tục với biểu đồ tiếp theo.

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

## **Đọc và ghi dữ liệu biểu đồ từ sổ công việc**

Aspose.Slides for .NET cung cấp các phương thức [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) và [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) cho phép bạn đọc và ghi sổ công việc dữ liệu biểu đồ (chứa dữ liệu biểu đồ được chỉnh sửa bằng Aspose.Cells). **Lưu ý** rằng dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc phải có cấu trúc tương tự như nguồn.

Ví dụ này sử dụng một bản trình bày có biểu đồ là hình dạng đầu tiên trên slide đầu tiên. Nó đọc sổ công việc nhúng vào một luồng, xóa các chuỗi và danh mục hiện có, và ghi lại cùng một sổ công việc. Các thay đổi vẫn ở trong bộ nhớ; ví dụ không lưu bản trình bày.

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

### **Xác thực bố cục biểu đồ sau khi sửa đổi sổ công việc**

Khi bạn thay thế sổ công việc nhúng bằng một sổ đã chỉnh sửa, biểu đồ vẫn giữ các bộ sưu tập chuỗi và danh mục gốc. Sự không khớp này có thể khiến [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) thất bại với lỗi chỉ mục ngoài phạm vi. Xóa các chuỗi và danh mục hiện có trước khi ghi sổ công việc đã cập nhật trở lại biểu đồ. Ví dụ này sử dụng một biểu đồ là hình dạng đầu tiên trên slide đầu tiên. Nhận xét đánh dấu nơi sẽ chỉnh sửa sổ công việc; ví dụ có thể chạy sẽ ghi sổ công việc gốc trở lại và xác thực bố cục trong bộ nhớ.

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

    // Sửa đổi luồng sổ công việc ở đây, ví dụ, sử dụng Aspose.Cells.

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

Xóa các bộ sưu tập loại bỏ các tham chiếu dữ liệu cũ trước khi sổ công việc được ghi lại. Xây dựng lại bất kỳ chuỗi và ánh xạ danh mục cần thiết cho sổ công việc đã cập nhật trước khi sử dụng biểu đồ.

## **Đặt ô sổ công việc làm nhãn dữ liệu biểu đồ**

Bạn có thể sử dụng văn bản từ các ô sổ công việc làm nhãn dữ liệu biểu đồ.

Ví dụ này thêm một biểu đồ bong bóng với dữ liệu mặc định vào slide đầu tiên của một bản trình bày hiện có. Nó sử dụng các ô A10:A12 trên worksheet 0 cho ba nhãn đầu tiên trong chuỗi đầu tiên, bật nhãn từ ô, và lưu bản trình bày đã cập nhật.

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

## **Quản lý trang tính**

Thuộc tính [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) cung cấp truy cập tới các trang tính trong một sổ công việc biểu đồ. Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và in tên mỗi trang tính ra console.

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

Ví dụ này tạo một biểu đồ cột 3D với dữ liệu mặc định và đặt hai tên chuỗi bằng các nguồn dữ liệu khác nhau. Tên đầu tiên sử dụng chuỗi ký tự; tên thứ hai sử dụng ô C1 trên worksheet 0. Phân loại [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) chọn nguồn cho mỗi tên. Ví dụ lưu bản trình bày với các tên chuỗi đã cập nhật.

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

## **Phát hiện các định dạng sổ công việc nhúng không được hỗ trợ**

Aspose.Slides không hỗ trợ định dạng sổ công việc nhị phân Excel (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng thuộc tính [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) trên [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) cùng với phân loại [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua các biểu đồ đó. Ví dụ này kiểm tra các hình dạng trên slide đầu tiên của một bản trình bày hiện có, bỏ qua các hình không phải biểu đồ, và in thông điệp chẩn đoán cho mỗi biểu đồ có sổ công việc .xlsb nhúng.

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

    // Đọc hoặc sửa đổi dữ liệu sổ công việc biểu đồ được hỗ trợ ở đây.
}
```

## **Sổ công việc bên ngoài**

Aspose.Slides hỗ trợ sử dụng sổ công việc bên ngoài làm nguồn dữ liệu cho biểu đồ.

### **Tạo sổ công việc bên ngoài**

Sử dụng [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) và [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) để xuất sổ công việc biểu đồ nhúng ra file và liên kết biểu đồ với sổ công việc bên ngoài đó.

Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và xuất sổ công việc của nó. Nó đóng luồng đầu ra trước khi gán sổ công việc bên ngoài làm nguồn dữ liệu cho biểu đồ, sau đó lưu bản trình bày đã liên kết.

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

### **Đặt sổ công việc bên ngoài**

Bằng cách sử dụng phương thức [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/), bạn có thể gán một sổ công việc bên ngoài cho biểu đồ làm nguồn dữ liệu. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới sổ công việc bên ngoài (nếu sổ đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các sổ công việc được lưu ở vị trí từ xa hoặc tài nguyên, bạn vẫn có thể sử dụng các sổ này làm nguồn dữ liệu bên ngoài. Nếu cung cấp đường dẫn tương đối cho sổ công việc bên ngoài, nó sẽ tự động chuyển sang đường dẫn đầy đủ.

Ví dụ này sử dụng một sổ công việc bên ngoài mà worksheet có tên `Sheet1` chứa tên chuỗi ở B1, tên danh mục ở A2:A4, và giá trị số ở B2:B4. Ví dụ tạo một biểu đồ tròn, liên kết sổ công việc, và sử dụng [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) để ánh xạ A1:B4 thành một chuỗi và ba danh mục. Nó lưu bản trình bày với biểu đồ đã liên kết.

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

Tham số `updateChartData` của [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) kiểm soát việc có tải sổ công việc hay không.

* Khi `updateChartData` là `false`, chỉ đường dẫn sổ công việc được cập nhật. Dữ liệu biểu đồ không được tải hoặc cập nhật từ sổ công việc mục tiêu, vì vậy sổ công việc có thể không khả dụng.
* Khi `updateChartData` là `true`, dữ liệu biểu đồ được cập nhật từ sổ công việc mục tiêu.

Ví dụ sau gán một URL placeholder với `updateChartData` đặt thành `false`. Nó giữ dữ liệu mặc định của biểu đồ tròn và lưu bản trình bày mà không tải sổ công việc không khả dụng.

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

### **Lấy đường dẫn sổ công việc nguồn dữ liệu bên ngoài của biểu đồ**

Để xác định sổ công việc được liên kết với một biểu đồ, kiểm tra xem biểu đồ có sử dụng nguồn dữ liệu bên ngoài không và lấy đường dẫn sổ công việc của nó.

Ví dụ này kiểm tra hình dạng đầu tiên trên slide đầu tiên của một bản trình bày có sổ công việc bên ngoài được liên kết. Nếu đó là một biểu đồ được liên kết với sổ công việc bên ngoài, ví dụ in [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) ra console. Sau đó nó lưu một bản sao của bản trình bày.

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

Bạn có thể chỉnh sửa dữ liệu trong sổ công việc bên ngoài giống như cách bạn thay đổi nội dung của sổ công việc nội bộ. Khi một sổ công việc bên ngoài không thể tải, một ngoại lệ sẽ được ném ra.

Ví dụ này sử dụng một biểu đồ là hình dạng đầu tiên trên slide đầu tiên và được liên kết với một sổ công việc bên ngoài có thể truy cập. Nó đặt giá trị dựa trên ô của điểm dữ liệu đầu tiên trong chuỗi đầu tiên thành 100 và lưu bản trình bày đã cập nhật. Chỉnh sửa giá trị ô có thể cập nhật file XLSX bên ngoài được liên kết, vì vậy hãy sử dụng một bản sao nếu bạn cần bảo tồn sổ công việc gốc.

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

### **Khôi phục sổ công việc từ bộ nhớ đệm biểu đồ**

Nếu một biểu đồ sử dụng sổ công việc bên ngoài bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo sổ công việc biểu đồ từ dữ liệu được lưu trong bộ nhớ đệm của bản trình bày. Tạo [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/), cấu hình [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/), và đặt [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) thành `true` trước khi mở bản trình bày.

Ví dụ C# sau khôi phục dữ liệu sổ công việc cho một biểu đồ là hình dạng đầu tiên trên slide đầu tiên và tham chiếu đến một sổ công việc bên ngoài không khả dụng. Nó truy cập dữ liệu đã khôi phục qua [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) và [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

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

    // Đọc hoặc sửa đổi dữ liệu sổ công việc đã khôi phục ở đây.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Nếu sổ công việc bên ngoài không khả dụng và chế độ khôi phục bị tắt, Aspose.Slides ném ra một [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Chỉ bật khôi phục khi việc sử dụng dữ liệu biểu đồ đã lưu trong bộ nhớ đệm là một hướng đi chấp nhận được, vì bộ nhớ đệm có thể không chứa các thay đổi đã thực hiện trên sổ công việc bên ngoài sau lần cập nhật cuối cùng của bản trình bày.

## **FAQ**

**Tôi có thể xác định liệu một biểu đồ cụ thể có được liên kết với sổ công việc bên ngoài hay sổ công việc nhúng không?**

Có. Một biểu đồ có [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) và một [path to an external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/); nếu nguồn là một sổ công việc bên ngoài, bạn có thể đọc toàn bộ đường dẫn để chắc chắn rằng một tệp bên ngoài đang được sử dụng.

**Các đường dẫn tương đối tới sổ công việc bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Bản trình bày lưu đường dẫn tuyệt đối trong tệp PPTX, vì vậy việc di chuyển sổ công việc có thể yêu cầu cập nhật liên kết.

**Tôi có thể sử dụng sổ công việc nằm trên tài nguyên/mạng chia sẻ không?**

Có, các sổ công việc như vậy có thể được sử dụng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa trực tiếp các sổ công việc từ xa bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè lên file XLSX bên ngoài khi lưu bản trình bày không?**

Bản trình bày lưu một [link to the external file](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/). Việc chỉnh sửa dữ liệu biểu đồ dựa trên ô cũng có thể cập nhật file XLSX cục bộ đã liên kết. Hãy sử dụng một bản sao của sổ công việc nếu bản gốc phải được giữ nguyên.

**Nếu file bên ngoài được bảo vệ bằng mật khẩu, tôi nên làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách phổ biến là gỡ bảo vệ trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, bằng [Aspose.Cells](https://reference.aspose.com/cells/net/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một sổ công việc bên ngoài không?**

Có. Mỗi biểu đồ lưu liên kết riêng của mình. Nếu chúng đều trỏ tới cùng một tệp, việc cập nhật tệp đó sẽ được phản ánh trong mỗi biểu đồ vào lần tiếp theo dữ liệu được tải.