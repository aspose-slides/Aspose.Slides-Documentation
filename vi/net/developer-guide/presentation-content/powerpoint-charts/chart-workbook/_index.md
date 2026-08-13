---
title: Quản lý Workbook biểu đồ trong bản trình chiếu trên .NET
linktitle: Workbook Biểu đồ
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
description: "Khám phá Aspose.Slides cho .NET: dễ dàng quản lý workbook biểu đồ trong các định dạng PowerPoint và OpenDocument để tối ưu hóa dữ liệu bản trình chiếu của bạn."
---
## **Overview**

Bài viết này giải thích cách làm việc với workbook biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua stream workbook, sử dụng các ô workbook làm nhãn dữ liệu biểu đồ, truy cập bộ sưu tập worksheet, và chỉ định kiểu nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng đề cập đến việc làm việc với workbook bên ngoài như nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một workbook bên ngoài, lấy đường dẫn của workbook bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi workbook có sẵn.

## **Read and Write Chart Data from a Workbook**
Aspose.Slides cung cấp các phương thức [ReadWorkbookStream](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/readworkbookstream/) và [WriteWorkbookStream](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/writeworkbookstream/) cho phép bạn đọc và ghi workbook dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã được chỉnh sửa bằng Aspose.Cells). **Lưu ý** rằng dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc có cấu trúc tương tự nguồn.

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

## **Set a WorkBook Cell as a Chart Data Label**
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Thêm một biểu đồ Bubble với một số dữ liệu.
4. Truy cập series của biểu đồ.
5. Đặt ô workbook làm nhãn dữ liệu.
6. Lưu bản trình chiếu.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";
// Khởi tạo lớp trình chiếu đại diện cho một tệp trình chiếu 

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

## **Manage Worksheets**

Đoạn mã C# này minh họa một thao tác trong đó thuộc tính [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) được sử dụng để truy cập bộ sưu tập worksheet:

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

## **Specify the Data Source Type**

Đoạn mã C# này cho bạn cách chỉ định kiểu cho một nguồn dữ liệu:

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

## **Detect Unsupported Embedded Workbook Formats**

Aspose.Slides không hỗ trợ định dạng workbook nhị phân Excel (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng thuộc tính `EmbeddedWorkbookType` trên [IChartData](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/) cùng với enumeration [WorkbookType](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua các biểu đồ đó.

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

        // Đọc hoặc sửa dữ liệu workbook của biểu đồ tại đây.
    }
}
```

## **External Workbook**

{{% alert color="info" %}} 
Trong [Aspose.Slides 19.4](https://docs.aspose.com/slides/vi/net/aspose-slides-for-net-19-4-release-notes/), chúng tôi đã triển khai hỗ trợ workbook bên ngoài làm nguồn dữ liệu cho biểu đồ.
{{% /alert %}} 

### **Create an External Workbook**
Sử dụng các phương thức **`ReadWorkbookStream`** và **`SetExternalWorkbook`**, bạn có thể tạo một workbook bên ngoài từ đầu hoặc chuyển một workbook nội bộ thành bên ngoài.

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

### **Set an External Workbook**
Sử dụng phương thức **`SetExternalWorkbook`**, bạn có thể gán một workbook bên ngoài cho biểu đồ như nguồn dữ liệu của nó. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới workbook bên ngoài (nếu workbook đó đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các workbook được lưu ở vị trí hoặc nguồn tài nguyên từ xa, bạn vẫn có thể sử dụng các workbook này làm nguồn dữ liệu bên ngoài. Nếu cung cấp đường dẫn tương đối cho một workbook bên ngoài, nó sẽ tự động được chuyển thành đường dẫn đầy đủ.

Đoạn mã C# này cho bạn cách đặt một workbook bên ngoài:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Đường dẫn đến thư mục tài liệu.
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

Tham số `ChartData` (trong phương thức `SetExternalWorkbook`) được dùng để chỉ định liệu một workbook excel có được tải hay không.

* Khi giá trị `ChartData` được đặt thành `false`, chỉ đường dẫn workbook được cập nhật—dữ liệu biểu đồ sẽ không được tải hoặc cập nhật từ workbook đích. Bạn có thể muốn sử dụng cài đặt này khi workbook đích không tồn tại hoặc không khả dụng. 
* Khi giá trị `ChartData` được đặt thành `true`, dữ liệu biểu đồ sẽ được cập nhật từ workbook đích.

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

### **Get the External Data Source Workbook Path of a Chart**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Tạo một đối tượng cho shape biểu đồ.
4. Tạo một đối tượng cho kiểu nguồn (`ChartDataSourceType`) đại diện cho nguồn dữ liệu của biểu đồ.
5. Xác định điều kiện liên quan dựa trên việc kiểu nguồn giống với kiểu nguồn dữ liệu workbook bên ngoài.

Đoạn mã C# này minh họa thao tác:

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

### **Edit Chart Data**

Bạn có thể chỉnh sửa dữ liệu trong workbook bên ngoài theo cùng cách như khi thay đổi nội dung của workbook nội bộ. Khi một workbook bên ngoài không thể được tải, một ngoại lệ sẽ được ném.

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

### **Recover a Workbook from the Chart Cache**

Nếu một biểu đồ sử dụng workbook bên ngoài bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo workbook của biểu đồ từ dữ liệu được lưu trong bộ nhớ đệm của bản trình chiếu. Tạo [LoadOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/), cấu hình [SpreadsheetOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/spreadsheetoptions/), và đặt [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/vi/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) thành `true` trước khi mở bản trình chiếu.

Ví dụ C# sau mở một bản trình chiếu mà biểu đồ của nó tham chiếu tới một workbook bên ngoài không khả dụng và truy cập dữ liệu đã khôi phục thông qua [IChart.ChartData](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichart/chartdata/) và [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

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

Nếu workbook bên ngoài không khả dụng và chế độ khôi phục bị tắt, Aspose.Slides sẽ ném ra `InvalidOperationException`. Chỉ bật khôi phục khi việc sử dụng dữ liệu biểu đồ được lưu trong bộ nhớ đệm là một giải pháp dự phòng chấp nhận được, vì bộ nhớ đệm có thể không chứa các thay đổi được thực hiện trên workbook bên ngoài sau lần cập nhật cuối cùng của bản trình chiếu.

## **FAQ**

**Tôi có thể xác định liệu một biểu đồ cụ thể có được liên kết với workbook bên ngoài hay nhúng không?**  
Có. Một biểu đồ có một [kiểu nguồn dữ liệu](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chartdata/datasourcetype/) và một [đường dẫn tới workbook bên ngoài](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chartdata/externalworkbookpath/); nếu nguồn là một workbook bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp bên ngoài đang được sử dụng.

**Các đường dẫn tương đối tới workbook bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**  
Đúng. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Điều này thuận tiện cho việc di động của dự án; tuy nhiên, lưu ý rằng bản trình chiếu sẽ lưu đường dẫn tuyệt đối trong tệp PPTX.

**Tôi có thể sử dụng các workbook nằm trên tài nguyên/mạng chia sẻ không?**  
Có, các workbook như vậy có thể được sử dụng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa trực tiếp các workbook từ xa bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè lên tệp XLSX bên ngoài khi lưu bản trình chiếu không?**  
Không. Bản trình chiếu lưu một [liên kết tới tệp bên ngoài](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chartdata/externalworkbookpath/) và sử dụng nó để đọc dữ liệu. Tệp bên ngoài không bị thay đổi khi bản trình chiếu được lưu.

**Tôi nên làm gì nếu tệp bên ngoài được bảo vệ bằng mật khẩu?**  
Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách thường dùng là gỡ bảo vệ trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, sử dụng [Aspose.Cells](/cells/net/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một workbook bên ngoài không?**  
Có. Mỗi biểu đồ lưu liên kết riêng của nó. Nếu tất cả chúng đều trỏ tới cùng một tệp, việc cập nhật tệp sẽ được phản ánh trong mỗi biểu đồ lần tiếp theo dữ liệu được tải.