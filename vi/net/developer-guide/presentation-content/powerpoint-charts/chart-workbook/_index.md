---
title: Quản lý workbook biểu đồ trong bản trình chiếu bằng .NET
linktitle: Workbook biểu đồ
type: docs
weight: 70
url: /vi/net/chart-workbook/
keywords:
- workbook biểu đồ
- dữ liệu biểu đồ
- ô workbook
- nhãn dữ liệu
- bảng tính
- nguồn dữ liệu
- workbook bên ngoài
- dữ liệu bên ngoài
- bộ nhớ đệm biểu đồ
- khôi phục workbook
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Khám phá Aspose.Slides cho .NET: dễ dàng quản lý workbook biểu đồ trong các định dạng PowerPoint và OpenDocument để tối ưu hoá dữ liệu bản trình chiếu của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sổ làm việc biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua luồng sổ làm việc, sử dụng các ô trong sổ làm việc làm nhãn dữ liệu biểu đồ, truy cập các bộ sưu tập worksheet, và chỉ định kiểu nguồn dữ liệu cho giá trị biểu đồ.

Nó cũng bao phủ việc làm việc với các sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một sổ làm việc bên ngoài, lấy đường dẫn của sổ làm việc bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi sổ làm việc có sẵn.

Đối với các ô sổ làm việc đại diện cho dữ liệu thiếu, xem [Kiểm soát Hiển thị các Ô Trống](/slides/vi/net/chart-series/) để biết sự khác biệt giữa ô trống và số 0, và so sánh biểu đồ đường của các chế độ hiển thị có sẵn.

## **Bao gồm Dữ liệu từ Các Hàng và Cột Ẩn**

Sử dụng [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) để kiểm soát xem biểu đồ có vẽ dữ liệu từ các hàng và cột worksheet ẩn hay không. Đặt nó thành `true` để chỉ vẽ các ô hiển thị, hoặc `false` để bao gồm cả ô hiển thị và ẩn. Cài đặt này kiểm soát việc vẽ biểu đồ; nó không ẩn hoặc hiện lại các hàng hoặc cột worksheet.

Tải xuống [hidden-source-data.pptx](hidden-source-data.pptx) và đặt nó vào thư mục làm việc. Slide đầu tiên của nó chứa một biểu đồ cột là hình dạng đầu tiên. Worksheet được nhúng, `Sheet1`, chứa phạm vi nguồn sau, `A1:C4`. Hàng 3 và cột C bị ẩn, nhưng các ô của chúng vẫn chứa giá trị.

| Hàng Worksheet | A: Tháng | B: Bán lẻ | C: Bán buôn (cột ẩn) |
| --- | --- | --- | --- |
| 2 | Tháng 1 | 10 | 30 |
| 3 (hàng ẩn) | Tháng 2 | 40 | 60 |
| 4 | Tháng 3 | 20 | 50 |

Truy cập các ô nguồn qua [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/chartdataworkbook/) và đọc [IChartDataCell.IsHidden](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/ishidden/) để kiểm tra trạng thái ẩn của chúng. Thuộc tính này chỉ đọc. Trong tệp này, B2 hiển thị, B3 thuộc hàng ẩn, và C2 thuộc cột ẩn; ví dụ in ra `False`, `True`, và `True` tương ứng.

Đối với ví dụ này, làm mới dữ liệu biểu đồ sau khi thay đổi cài đặt vẽ: giữ lại workbook được nhúng bằng [ReadWorkbookStream](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/readworkbookstream/) và tải lại bằng [WriteWorkbookStream](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/writeworkbookstream/). Khi bao gồm tất cả các ô, cũng sử dụng [SetRange](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/setrange/) để khôi phục toàn bộ phạm vi, bao gồm danh mục tháng 2 bị ẩn. Chỉ thay đổi flag không đủ để làm mới dữ liệu biểu đồ được lưu trong bộ nhớ đệm và nhãn danh mục của mẫu này.

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

        // Làm mới dữ liệu biểu đồ từ workbook được nhúng.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Khôi phục toàn bộ phạm vi nguồn, bao gồm các danh mục ẩn.
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

Ví dụ lưu `hidden_cells_True.pptx` chỉ với các giá trị Bán lẻ hiển thị (10 và 20), và `hidden_cells_False.pptx` với tất cả sáu giá trị. Các hình ảnh dưới đây được tạo từ các bản trình chiếu đã lưu sau khi mở lại; cả hai tệp đều giữ cài đặt vẽ đã được chỉ định. Hàng 3 và cột C vẫn ẩn trong cả hai workbook được nhúng.

| Chỉ các ô hiển thị (`true`) | Tất cả các ô (`false`) |
| --- | --- |
| ![Chỉ các ô hiển thị: Giá trị Bán lẻ 10 và 20 cho Tháng 1 và Tháng 3.](hidden_cells_True.png) | ![Tất cả các ô: Giá trị Bán lẻ và Bán buôn cho Tháng 1, Tháng 2 và Tháng 3.](hidden_cells_False.png) |

Một ô ẩn chứa giá trị khác với một ô trống. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichart/displayblanksas/) kiểm soát cách hiển thị các giá trị thiếu; nó không bao gồm hay loại trừ dữ liệu nguồn ẩn. Xem [Kiểm soát Hiển thị các Ô Trống](/slides/vi/net/chart-series/#control-the-display-of-empty-cells) để xem ví dụ.

## **Đọc và Ghi Dữ liệu Biểu đồ từ Workbook**

Aspose.Slides cho .NET cung cấp các phương thức [ReadWorkbookStream](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/readworkbookstream/) và [WriteWorkbookStream](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/writeworkbookstream/) cho phép bạn đọc và ghi các workbook dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã được chỉnh sửa bằng Aspose.Cells). **Lưu ý** dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc phải có cấu trúc tương tự nguồn.

Ví dụ này mở `chart.pptx`, tệp này phải chứa một biểu đồ là hình dạng đầu tiên trên slide đầu tiên. Nó đọc workbook được nhúng vào một luồng, xóa các series và category hiện có, và ghi lại cùng một workbook. Các thay đổi vẫn ở trong bộ nhớ; ví dụ không lưu bản trình chiếu.

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

### **Xác thực Bố cục Biểu đồ Sau Khi Sửa Workbook**

Khi bạn thay thế một workbook được nhúng bằng một workbook đã sửa, biểu đồ vẫn giữ các bộ sưu tập series và category ban đầu. Sự không khớp này có thể khiến [IChart.ValidateChartLayout](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichart/validatechartlayout/) thất bại với lỗi chỉ mục ngoài phạm vi. Hãy xóa các series và category hiện có trước khi ghi lại workbook đã cập nhật vào biểu đồ. Ví dụ này yêu cầu `chart.pptx` có biểu đồ là hình dạng đầu tiên trên slide đầu tiên. Các chú thích đánh dấu vị trí sẽ thực hiện chỉnh sửa workbook; ví dụ có thể chạy sẽ ghi lại workbook gốc và xác thực bố cục trong bộ nhớ.

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

    // Sửa đổi luồng workbook ở đây, ví dụ, sử dụng Aspose.Cells.

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

Việc xóa các bộ sưu tập loại bỏ các tham chiếu dữ liệu lỗi thời trước khi workbook được ghi lại. Hãy xây dựng lại bất kỳ ánh xạ series và category cần thiết cho workbook đã cập nhật trước khi sử dụng biểu đồ.

## **Đặt Ô Workbook làm Nhãn Dữ liệu Biểu đồ**

Bạn có thể sử dụng văn bản từ các ô workbook làm nhãn dữ liệu cho biểu đồ. Các bước sau cho thấy cách liên kết các nhãn trong biểu đồ bong bóng với các ô trong workbook dữ liệu của nó.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/).
2. Truy cập slide đầu tiên bằng chỉ mục bắt đầu từ 0.
3. Thêm một biểu đồ bong bóng với dữ liệu mặc định.
4. Truy cập series của biểu đồ.
5. Đặt ô workbook làm nhãn dữ liệu.
6. Lưu bản trình chiếu.

Ví dụ này mở `chart2.pptx`, tệp này phải chứa ít nhất một slide, và thêm một biểu đồ bong bóng với dữ liệu mặc định. Nó sử dụng các ô A10:A12 trên worksheet 0 cho ba nhãn đầu tiên trong series đầu tiên, bật nhãn từ ô, và lưu kết quả vào `resultchart.pptx`.

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

Thuộc tính [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/worksheets/) cung cấp quyền truy cập vào các worksheet trong một chart workbook. Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và in tên mỗi worksheet ra console.

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

## **Chỉ định Kiểu Nguồn Dữ liệu**

Ví dụ này tạo một biểu đồ cột 3D với dữ liệu mặc định và đặt hai tên series bằng cách sử dụng các nguồn dữ liệu khác nhau. Tên đầu tiên sử dụng một chuỗi literal; tên thứ hai sử dụng ô C1 trên worksheet 0. Kiểu liệt kê [DataSourceType](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/datasourcetype/) chọn nguồn cho mỗi tên. Kết quả được lưu vào `pres.pptx`.

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

## **Phát hiện Định dạng Workbook Nhúng Không được Hỗ trợ**

Aspose.Slides không hỗ trợ định dạng workbook nhị phân Excel (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng thuộc tính [EmbeddedWorkbookType](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) trên [IChartData](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/) cùng với kiểu liệt kê [WorkbookType](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua các biểu đồ đó. Ví dụ này kiểm tra các shape trên slide đầu tiên của `sample.pptx`, bỏ qua các shape không phải biểu đồ, và in thông báo chẩn đoán cho mỗi biểu đồ có workbook .xlsb được nhúng.

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

    // Đọc hoặc chỉnh sửa dữ liệu workbook biểu đồ được hỗ trợ tại đây.
}
```

## **Workbook Ngoài**

Aspose.Slides hỗ trợ sử dụng workbook bên ngoài làm nguồn dữ liệu cho các biểu đồ.

### **Tạo Workbook Ngoài**

Sử dụng [ReadWorkbookStream](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/readworkbookstream/) và [SetExternalWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/setexternalworkbook/) để xuất workbook biểu đồ được nhúng ra một tệp và liên kết biểu đồ với workbook bên ngoài đó.

Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định, ghi workbook của nó vào `externalWorkbook1.xlsx`, và đóng luồng xuất trước khi gán tệp làm nguồn dữ liệu cho biểu đồ. Nó lưu bản trình chiếu đã liên kết vào `externalWorkbook.pptx`.

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

### **Đặt Workbook Ngoài**

Bằng cách sử dụng phương thức [SetExternalWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/setexternalworkbook/), bạn có thể gán một workbook bên ngoài cho biểu đồ làm nguồn dữ liệu của nó. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới workbook bên ngoài (nếu workbook đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các workbook lưu trữ ở vị trí hoặc tài nguyên từ xa, bạn vẫn có thể sử dụng các workbook đó như một nguồn dữ liệu bên ngoài. Nếu cung cấp đường dẫn tương đối cho workbook bên ngoài, nó sẽ tự động được chuyển thành đường dẫn đầy đủ.

Ví dụ này yêu cầu `externalWorkbook.xlsx` trong thư mục làm việc. Worksheet có tên `Sheet1` phải chứa một tên series ở B1, các tên category ở A2:A4, và các giá trị số tại B2:B4. Ví dụ tạo một biểu đồ tròn, liên kết workbook, và sử dụng [SetRange](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/setrange/) để ánh xạ A1:B4 thành một series và ba category. Nó lưu kết quả vào `Presentation_with_externalWorkbook.pptx`.

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

Tham số `updateChartData` của [SetExternalWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/setexternalworkbook/) kiểm soát việc có tải workbook hay không.

* Khi `updateChartData` là `false`, chỉ đường dẫn workbook được cập nhật. Dữ liệu biểu đồ không được tải hoặc cập nhật từ workbook mục tiêu, vì vậy workbook có thể không khả dụng.
* Khi `updateChartData` là `true`, dữ liệu biểu đồ được cập nhật từ workbook mục tiêu.

Ví dụ sau gán một URL placeholder với `updateChartData` đặt thành `false`. Nó giữ lại dữ liệu mặc định của biểu đồ tròn và lưu bản trình chiếu mà không tải workbook không khả dụng.

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

### **Lấy Đường dẫn Workbook Nguồn Dữ liệu Ngoài của Biểu đồ**

Để xác định workbook được liên kết với một biểu đồ, trước tiên kiểm tra xem biểu đồ có sử dụng nguồn dữ liệu bên ngoài không. Nếu có, bạn có thể lấy đường dẫn workbook bằng các bước sau.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/).
2. Truy cập slide đầu tiên bằng chỉ mục bắt đầu từ 0.
3. Kiểm tra rằng hình dạng đầu tiên là biểu đồ.
4. Đọc kiểu nguồn dữ liệu của biểu đồ.
5. Nếu nguồn là một workbook bên ngoài, đọc đường dẫn của nó.

Ví dụ này mở `externalWorkbook.pptx`, được tạo trong ví dụ trước, và kiểm tra hình dạng đầu tiên trên slide đầu tiên. Nếu đó là một biểu đồ được liên kết với một workbook bên ngoài, ví dụ in [ExternalWorkbookPath](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/externalworkbookpath/) ra console. Sau đó nó lưu một bản sao của bản trình chiếu vào `Result.pptx`.

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

### **Chỉnh sửa Dữ liệu Biểu đồ**

Bạn có thể chỉnh sửa dữ liệu trong workbook bên ngoài theo cùng cách bạn thay đổi nội dung của workbook nội bộ. Khi một workbook ngoại không thể được tải, một ngoại lệ sẽ được ném.

Ví dụ này yêu cầu `presentation.pptx` có một biểu đồ là hình dạng đầu tiên trên slide đầu tiên và một workbook bên ngoài có thể truy cập được. Nó đặt giá trị được hỗ trợ bởi ô của điểm dữ liệu đầu tiên trong series đầu tiên thành 100 và lưu bản trình chiếu vào `presentation_out.pptx`. Việc chỉnh sửa giá trị ô có thể cập nhật tệp XLSX bên ngoài được liên kết, vì vậy hãy sử dụng một bản sao nếu bạn cần giữ nguyên workbook gốc.

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

### **Khôi phục Workbook từ Bộ nhớ Đệm Biểu đồ**

Nếu một biểu đồ sử dụng workbook bên ngoài bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo workbook biểu đồ từ dữ liệu được lưu trong bộ nhớ đệm của bản trình chiếu. Tạo [LoadOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/), cấu hình [SpreadsheetOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/spreadsheetoptions/) của nó, và đặt [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/vi/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) thành `true` trước khi mở bản trình chiếu.

Ví dụ C# sau mở `presentation.pptx`, trong đó hình dạng đầu tiên trên slide đầu tiên phải là một biểu đồ tham chiếu tới một workbook bên ngoài không khả dụng, và truy cập dữ liệu đã khôi phục thông qua [IChart.ChartData](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichart/chartdata/) và [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

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

    // Đọc hoặc chỉnh sửa dữ liệu workbook đã khôi phục tại đây.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Nếu workbook bên ngoài không khả dụng và việc khôi phục bị tắt, Aspose.Slides sẽ ném ra một [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Chỉ bật khôi phục khi việc sử dụng dữ liệu biểu đồ được lưu trong bộ nhớ đệm là một phương án chấp nhận được, vì bộ nhớ đệm có thể không chứa các thay đổi đã thực hiện trên workbook bên ngoài sau lần cập nhật cuối cùng của bản trình chiếu.

## **Câu hỏi thường gặp**

**Tôi có thể xác định liệu một biểu đồ cụ thể có liên kết tới workbook bên ngoài hay workbook nhúng không?**

Có. Một biểu đồ có [kiểu nguồn dữ liệu](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chartdata/datasourcetype/) và một [đường dẫn tới workbook bên ngoài](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chartdata/externalworkbookpath/); nếu nguồn là một workbook bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn một tệp bên ngoài đang được sử dụng.

**Đường dẫn tương đối tới workbook bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Bản trình chiếu lưu đường dẫn tuyệt đối trong tệp PPTX, vì vậy việc di chuyển workbook có thể yêu cầu cập nhật liên kết.

**Tôi có thể sử dụng các workbook nằm trên tài nguyên/mạng chia sẻ không?**

Có, các workbook như vậy có thể được dùng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa trực tiếp các workbook từ xa bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè lên tệp XLSX bên ngoài khi lưu bản trình chiếu không?**

Bản trình chiếu lưu một [liên kết tới tệp bên ngoài](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chartdata/externalworkbookpath/). Việc chỉnh sửa dữ liệu biểu đồ dựa trên ô cũng có thể cập nhật tệp XLSX địa phương được liên kết. Hãy sử dụng một bản sao của workbook nếu bạn cần giữ nguyên workbook gốc.

**Tôi nên làm gì nếu tệp bên ngoài được bảo mật bằng mật khẩu?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách thường dùng là gỡ bỏ bảo mật trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, sử dụng [Aspose.Cells](https://reference.aspose.com/cells/net/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một workbook bên ngoài không?**

Có. Mỗi biểu đồ lưu liên kết riêng của nó. Nếu tất cả chúng trỏ tới cùng một tệp, việc cập nhật tệp sẽ được phản ánh trong mỗi biểu đồ lần tiếp theo dữ liệu được tải.