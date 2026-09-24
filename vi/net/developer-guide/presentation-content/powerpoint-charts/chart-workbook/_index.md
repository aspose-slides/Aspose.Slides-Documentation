---
title: Quản lý Sổ làm việc Biểu đồ trong Bản trình chiếu bằng .NET
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
- sổ làm việc ngoại
- dữ liệu ngoại
- bộ nhớ đệm biểu đồ
- phục hồi sổ làm việc
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Khám phá Aspose.Slides cho .NET: dễ dàng quản lý sổ làm việc biểu đồ trong định dạng PowerPoint và OpenDocument để tối ưu hóa dữ liệu bản trình chiếu của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sổ làm việc biểu đồ trong Aspose.Slides. Nó chỉ ra cách đọc và ghi dữ liệu biểu đồ thông qua luồng sổ làm việc, sử dụng các ô sổ làm việc làm nhãn dữ liệu biểu đồ, truy cập bộ sưu tập worksheet, và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng bao gồm việc làm việc với sổ làm việc bên ngoài như nguồn dữ liệu biểu đồ. Các ví dụ minh họa cách tạo và gán một sổ làm việc bên ngoài, lấy đường dẫn của sổ làm việc bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi sổ làm việc có sẵn.

Đối với các ô sổ làm việc đại diện cho dữ liệu thiếu, hãy xem [Kiểm soát việc hiển thị các ô trống](/slides/vi/net/chart-series/) để biết sự khác biệt giữa ô trống và giá trị zero, và so sánh biểu đồ đường của các chế độ hiển thị khả dụng.

## **Đọc và Ghi Dữ liệu Biểu đồ từ Sổ làm việc**
Aspose.Slides cung cấp các phương thức [ReadWorkbookStream](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/readworkbookstream/) và [WriteWorkbookStream](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/writeworkbookstream/) cho phép bạn đọc và ghi sổ làm việc dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã được chỉnh sửa bằng Aspose.Cells). **Note** rằng dữ liệu biểu đồ phải được tổ chức theo cùng một cách hoặc có cấu trúc tương tự như nguồn.

Mã C# này minh họa một thao tác mẫu:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation pres = new Presentation("chart.pptx"))
{
    Chart chart = (Chart) pres.Slides[0].Shapes[0];
    IChartData data = chart.ChartData;

    MemoryStream stream = data.ReadWorkbookStream();

    data.Series.Clear();
    data.Categories.Clear();

    stream.Position = 0;
    data.WriteWorkbookStream(stream);
}
```

### **Xác thực Bố cục Biểu đồ Sau khi Sửa đổi Sổ làm việc**

Khi bạn thay thế một sổ làm việc nhúng bằng một sổ làm việc đã chỉnh sửa, biểu đồ sẽ giữ lại các bộ sưu tập series và category gốc. Sự không khớp này có thể khiến [IChart.ValidateChartLayout](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichart/validatechartlayout/) thất bại với lỗi chỉ mục vượt quá phạm vi. Hãy xóa các series và category hiện có trước khi ghi sổ làm việc đã cập nhật trở lại biểu đồ.

```csharp
// Sau khi sửa đổi luồng workbook (ví dụ, sử dụng Aspose.Cells)
using var updatedWorkbook = chartData.ReadWorkbookStream();

// Xóa các tham chiếu dữ liệu hiện có.
chartData.Series.Clear();
chartData.Categories.Clear();

updatedWorkbook.Position = 0;
chartData.WriteWorkbookStream(updatedWorkbook);

chart.ValidateChartLayout();
```

Việc xóa các bộ sưu tập đảm bảo cấu trúc dữ liệu biểu đồ đồng nhất với sổ làm việc mới, cho phép `ValidateChartLayout` hoàn thành mà không gặp lỗi.

## **Đặt một ô WorkBook làm Nhãn Dữ liệu Biểu đồ**
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide thông qua chỉ số của nó.
1. Thêm một biểu đồ Bubble với một số dữ liệu.
1. Truy cập series của biểu đồ.
1. Đặt ô workbook làm nhãn dữ liệu.
1. Lưu bản trình chiếu.

Mã C# này cho thấy cách đặt một ô workbook làm nhãn dữ liệu biểu đồ:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";
// Khởi tạo một lớp Presentation đại diện cho tệp bản trình chiếu

using (Presentation pres = new Presentation("chart2.pptx"))
{
    ISlide slide = pres.Slides[0];


    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);

    IChartSeriesCollection series = chart.ChartData.Series;

    series[0].Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

    IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

    series[0].Labels[0].ValueFromCell = wb.GetCell(0, "A10", lbl0);
    series[0].Labels[1].ValueFromCell = wb.GetCell(0, "A11", lbl1);
    series[0].Labels[2].ValueFromCell = wb.GetCell(0, "A12", lbl2);

    pres.Save("resultchart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Quản lý các Worksheet**

Mã C# này minh họa một thao tác trong đó thuộc tính [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) được sử dụng để truy cập bộ sưu tập worksheet:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Chỉ định Loại Nguồn Dữ liệu**

Mã C# này cho thấy cách chỉ định một loại cho nguồn dữ liệu:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.ChartData.Series[0].Name;
    
    val.DataSourceType = DataSourceType.StringLiterals;
    val.Data = "LiteralString";

    val = chart.ChartData.Series[1].Name;
    val.Data = chart.ChartData.ChartDataWorkbook.GetCell(0, "B1", "NewCell");

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Phát hiện Định dạng Sổ làm việc Nhúng Không được Hỗ trợ**

Aspose.Slides không hỗ trợ định dạng sổ làm việc Excel nhị phân (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng thuộc tính `EmbeddedWorkbookType` trên [IChartData](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/) cùng với enumeration [WorkbookType](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua những biểu đồ đó.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        if (shape is not IChart chart) continue;

        var chartData = chart.ChartData;

        if (chartData.DataSourceType == ChartDataSourceType.InternalWorkbook &&
            chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro)
        {
            // Workbook nhúng ở định dạng .xlsb, không được hỗ trợ.
            continue;
        }

        // Đọc hoặc chỉnh sửa dữ liệu workbook của biểu đồ ở đây.
    }
}
```

## **Workbook Ngoại**

Aspose.Slides hỗ trợ việc sử dụng workbook ngoại làm nguồn dữ liệu cho các biểu đồ.

### **Tạo một Workbook Ngoại**

Sử dụng các phương thức **`ReadWorkbookStream`** và **`SetExternalWorkbook`**, bạn có thể tạo một workbook ngoại từ đầu hoặc biến một workbook nội thành ngoại.

Mã C# này minh họa quy trình tạo workbook ngoại:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    const string workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
    using (FileStream fileStream = new FileStream(workbookPath, FileMode.Create))
    {
        byte[] workbookData = chart.ChartData.ReadWorkbookStream().ToArray();
        fileStream.Write(workbookData, 0, workbookData.Length);
    }
    
    chart.ChartData.SetExternalWorkbook(Path.GetFullPath(workbookPath));

    pres.Save("externalWorkbook.pptx", SaveFormat.Pptx);
}
```

### **Đặt một Workbook Ngoại**
Sử dụng phương thức **`SetExternalWorkbook`**, bạn có thể gán một workbook ngoại cho biểu đồ làm nguồn dữ liệu. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới workbook ngoại (nếu workbook đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các workbook được lưu ở vị trí từ xa hoặc trên tài nguyên, bạn vẫn có thể dùng các workbook đó làm nguồn dữ liệu ngoại. Nếu cung cấp đường dẫn tương đối cho một workbook ngoại, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối.

Mã C# này cho thấy cách đặt một workbook ngoại:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Đường dẫn tới thư mục tài liệu.
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.ChartData;
                    
    chartData.SetExternalWorkbook(Path.GetFullPath("externalWorkbook.xlsx"));
                  

    chartData.Series.Add(chartData.ChartDataWorkbook.GetCell(0, "B1"), ChartType.Pie);
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B2"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B3"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B4"));

    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A2"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A3"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A4"));
    pres.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
}
```

Tham số `ChartData` (trong phương thức `SetExternalWorkbook`) được dùng để chỉ định việc có nạp workbook Excel hay không.

* Khi giá trị `ChartData` được đặt là `false`, chỉ đường dẫn workbook được cập nhật — dữ liệu biểu đồ sẽ không được nạp hoặc cập nhật từ workbook mục tiêu. Bạn có thể dùng thiết lập này khi workbook mục tiêu không tồn tại hoặc không khả dụng.
* Khi giá trị `ChartData` được đặt là `true`, dữ liệu biểu đồ sẽ được cập nhật từ workbook mục tiêu.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Lấy Đường dẫn Workbook Nguồn Dữ liệu Ngoại của Biểu đồ**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide thông qua chỉ số của nó.
1. Tạo một đối tượng cho shape biểu đồ.
1. Tạo một đối tượng cho loại nguồn (`ChartDataSourceType`) đại diện cho nguồn dữ liệu của biểu đồ.
1. Chỉ định điều kiện phù hợp dựa trên việc loại nguồn giống với loại nguồn dữ liệu workbook ngoại.

Mã C# này minh họa thao tác:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[1];
    IChart chart = (IChart)slide.Shapes[0];
    ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        string path = chart.ChartData.ExternalWorkbookPath;
    }
    
    // Lưu bản trình chiếu
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **Chỉnh sửa Dữ liệu Biểu đồ**

Bạn có thể chỉnh sửa dữ liệu trong workbook ngoại tương tự như khi thay đổi nội dung của workbook nội. Khi một workbook ngoại không thể được nạp, một ngoại lệ sẽ được ném ra.

Mã C# này là một triển khai của quy trình đã mô tả:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **Phục hồi Workbook từ Bộ nhớ Đệm Biểu đồ**

Nếu một biểu đồ sử dụng một workbook ngoại bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo workbook biểu đồ từ dữ liệu đã được lưu trong bộ nhớ đệm của bản trình chiếu. Tạo [LoadOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/), cấu hình [SpreadsheetOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/spreadsheetoptions/), và đặt [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/vi/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) thành `true` trước khi mở bản trình chiếu.

Ví dụ C# sau mở một bản trình chiếu mà biểu đồ của nó tham chiếu tới một workbook ngoại không khả dụng và truy cập dữ liệu đã phục hồi qua [IChart.ChartData](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichart/chartdata/) và [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        RecoverWorkbookFromChartCache = true
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

var chart = (IChart)presentation.Slides[0].Shapes[0];
var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

// Read or modify the recovered workbook data here.
```

Nếu workbook ngoại không khả dụng và tính năng phục hồi bị tắt, Aspose.Slides sẽ ném ra một `InvalidOperationException`. Chỉ bật phục hồi khi việc sử dụng dữ liệu biểu đồ đã được lưu trong bộ nhớ đệm là một phương án dự phòng chấp nhận được, vì bộ nhớ đệm có thể không chứa các thay đổi đã được thực hiện trên workbook ngoại sau khi bản trình chiếu được cập nhật lần cuối.

## **Câu hỏi thường gặp**

**Tôi có thể xác định liệu một biểu đồ cụ thể có liên kết tới workbook ngoại hay nhúng không?**

Có. Một biểu đồ có một [data source type](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chartdata/datasourcetype/) và một [path to an external workbook](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chartdata/externalworkbookpath/); nếu nguồn là một workbook ngoại, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp ngoại đang được sử dụng.

**Có hỗ trợ đường dẫn tương đối tới workbook ngoại không, và chúng được lưu như thế nào?**

Có. Khi bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Điều này thuận lợi cho việc di động dự án; tuy nhiên, hãy lưu ý rằng bản trình chiếu sẽ lưu đường dẫn tuyệt đối trong tệp PPTX.

**Tôi có thể sử dụng workbook nằm trên các tài nguyên/mạng chia sẻ không?**

Có, các workbook như vậy có thể được dùng làm nguồn dữ liệu ngoại. Tuy nhiên, việc chỉnh sửa trực tiếp các workbook từ xa bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè lên tệp XLSX ngoại khi lưu bản trình chiếu không?**

Không. Bản trình chiếu lưu một [link to the external file](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chartdata/externalworkbookpath/) và dùng nó để đọc dữ liệu. Tệp ngoại bản thân không bị sửa đổi khi bản trình chiếu được lưu.

**Nếu tệp ngoại được bảo vệ bằng mật khẩu, tôi nên làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách thường dùng là gỡ bỏ bảo mật trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, bằng cách sử dụng [Aspose.Cells](/cells/net/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một workbook ngoại không?**

Có. Mỗi biểu đồ lưu liên kết riêng của nó. Nếu chúng đều trỏ tới cùng một tệp, việc cập nhật tệp đó sẽ được phản ánh trong mỗi biểu đồ lần tiếp theo dữ liệu được tải.