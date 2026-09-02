---
title: Quản lý workbook biểu đồ trong bài thuyết trình trên .NET
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
- bộ nhớ cache biểu đồ
- khôi phục workbook
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Khám phá Aspose.Slides cho .NET: quản lý workbook biểu đồ trong PowerPoint và các định dạng OpenDocument một cách dễ dàng để tối ưu hoá dữ liệu bài thuyết trình của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sổ làm việc biểu đồ trong Aspose.Slides. Nó chỉ ra cách đọc và ghi dữ liệu biểu đồ thông qua luồng sổ làm việc, sử dụng các ô trong sổ làm việc làm nhãn dữ liệu biểu đồ, truy cập bộ sưu tập worksheet, và chỉ định kiểu nguồn dữ liệu cho các giá trị biểu đồ.

Bạn cũng sẽ được hướng dẫn làm việc với workbook bên ngoài làm nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một workbook bên ngoài, lấy đường dẫn của workbook bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi workbook có sẵn.

## **Đọc và Ghi Dữ liệu Biểu đồ từ Workbook**
Aspose.Slides cung cấp các phương thức [ReadWorkbookStream](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/readworkbookstream/) và [WriteWorkbookStream](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/writeworkbookstream/) cho phép bạn đọc và ghi workbook dữ liệu biểu đồ (chứa dữ liệu biểu đồ được chỉnh sửa bằng Aspose.Cells). **Lưu ý** rằng dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc phải có cấu trúc tương tự nguồn.

Đoạn mã C# sau minh họa một thao tác mẫu:

```c#
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

## **Đặt một WorkBook Cell làm Chart Data Label**
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/)  
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.  
3. Thêm một biểu đồ Bubble với một số dữ liệu.  
4. Truy cập series của biểu đồ.  
5. Đặt ô workbook làm nhãn dữ liệu.  
6. Lưu bài thuyết trình.  

Đoạn mã C# sau cho bạn cách đặt một ô workbook làm nhãn dữ liệu biểu đồ:

```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Tạo một lớp Presentation đại diện cho tệp bài thuyết trình 

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

## **Quản lý Worksheets**
Đoạn mã C# sau minh họa một thao tác trong đó thuộc tính [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) được sử dụng để truy cập bộ sưu tập worksheet:

``` csharp
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Chỉ định Kiểu Nguồn Dữ liệu**
Đoạn mã C# sau cho bạn cách chỉ định một kiểu cho nguồn dữ liệu:

```c#
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

## **Phát hiện Các Định dạng Embedded Workbook không được hỗ trợ**
Aspose.Slides không hỗ trợ định dạng workbook nhị phân Excel (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng thuộc tính `EmbeddedWorkbookType` trên [IChartData](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/) cùng với enumeration [WorkbookType](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua những biểu đồ đó.

```csharp
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
            // Workbook được nhúng ở định dạng .xlsb, không được hỗ trợ.
            continue;
        }

        // Đọc hoặc chỉnh sửa dữ liệu workbook biểu đồ ở đây.
    }
}
```

## **External Workbook**
{{% alert color="primary" %}} 
Trong [Aspose.Slides 19.4](https://docs.aspose.com/slides/vi/net/aspose-slides-for-net-19-4-release-notes/), chúng tôi đã triển khai hỗ trợ cho workbook bên ngoài làm nguồn dữ liệu cho biểu đồ.
{{% /alert %}} 

### **Tạo một External Workbook**
Sử dụng các phương thức **`ReadWorkbookStream`** và **`SetExternalWorkbook`**, bạn có thể tạo một workbook bên ngoài từ đầu hoặc chuyển một workbook nội bộ thành bên ngoài.

Đoạn mã C# sau minh họa quy trình tạo workbook bên ngoài:

```c#
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

### **Gán một External Workbook**
Sử dụng phương thức **`SetExternalWorkbook`**, bạn có thể gán một workbook bên ngoài cho một biểu đồ làm nguồn dữ liệu. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới workbook bên ngoài (nếu workbook đó đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các workbook được lưu trữ ở vị trí hoặc tài nguyên từ xa, bạn vẫn có thể sử dụng các workbook đó làm nguồn dữ liệu bên ngoài. Nếu đường dẫn tương đối cho một workbook bên ngoài được cung cấp, nó sẽ tự động được chuyển thành đường dẫn đầy đủ.

Đoạn mã C# sau cho bạn cách gán một workbook bên ngoài:

```c#
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

Tham số `ChartData` (trong phương thức `SetExternalWorkbook`) được dùng để chỉ định liệu một workbook Excel có được tải hay không. 

* Khi giá trị `ChartData` được đặt thành `false`, chỉ đường dẫn workbook được cập nhật — dữ liệu biểu đồ sẽ không được tải hoặc cập nhật từ workbook mục tiêu. Bạn có thể muốn sử dụng thiết lập này khi workbook mục tiêu không tồn tại hoặc không khả dụng. 
* Khi giá trị `ChartData` được đặt thành `true`, dữ liệu biểu đồ sẽ được cập nhật từ workbook mục tiêu.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Lấy Đường dẫn External Data Source Workbook của Một Chart**
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/)  
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.  
3. Tạo một đối tượng cho shape biểu đồ.  
4. Tạo một đối tượng cho kiểu nguồn (`ChartDataSourceType`) đại diện cho nguồn dữ liệu của biểu đồ.  
5. Xác định điều kiện liên quan dựa trên việc kiểu nguồn giống với kiểu nguồn dữ liệu workbook bên ngoài.  

Đoạn mã C# sau minh họa thao tác:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[1];
    IChart chart = (IChart)slide.Shapes[0];
    ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        string path = chart.ChartData.ExternalWorkbookPath;
    }
    
    // Lưu bài thuyết trình
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **Chỉnh sửa Chart Data**
Bạn có thể chỉnh sửa dữ liệu trong các workbook bên ngoài giống như việc thay đổi nội dung của các workbook nội bộ. Khi một workbook bên ngoài không thể được tải, một ngoại lệ sẽ được ném.

Đoạn mã C# sau là triển khai của quy trình đã mô tả:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **Khôi phục Workbook từ Chart Cache**
Nếu một biểu đồ sử dụng một workbook bên ngoài bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo workbook của biểu đồ từ dữ liệu được lưu trong bộ nhớ cache của bản trình bày. Tạo [LoadOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/), cấu hình [SpreadsheetOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/spreadsheetoptions/), và đặt [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/vi/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) thành `true` trước khi mở bản trình bày.

Ví dụ C# sau mở một bản trình bày mà biểu đồ tham chiếu một workbook bên ngoài không khả dụng và truy cập dữ liệu đã khôi phục thông qua [IChart.ChartData](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichart/chartdata/) và [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

```csharp
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

// Đọc hoặc chỉnh sửa dữ liệu workbook đã khôi phục ở đây.
```

Nếu workbook bên ngoài không khả dụng và việc khôi phục bị tắt, Aspose.Slides sẽ ném `InvalidOperationException`. Chỉ bật khôi phục khi việc sử dụng dữ liệu biểu đồ đã cache là một phương án dự phòng chấp nhận được, vì cache có thể không chứa các thay đổi được thực hiện trên workbook bên ngoài sau khi bản trình bày được cập nhật lần cuối.

## **FAQ**

**Tôi có thể xác định xem một biểu đồ cụ thể có liên kết tới workbook bên ngoài hay được nhúng không?**  
Có. Một biểu đồ có [kiểu nguồn dữ liệu](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chartdata/datasourcetype/) và một [đường dẫn tới workbook bên ngoài](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chartdata/externalworkbookpath/); nếu nguồn là một workbook bên ngoài, bạn có thể đọc đường dẫn đầy đủ để đảm bảo một tệp bên ngoài đang được sử dụng.

**Các đường dẫn tương đối tới workbook bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**  
Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Điều này thuận tiện cho việc di động dự án; tuy nhiên, lưu ý rằng bản trình bày sẽ lưu đường dẫn tuyệt đối trong tệp PPTX.

**Tôi có thể sử dụng workbook nằm trên tài nguyên/mạng chia sẻ không?**  
Có, những workbook như vậy có thể được dùng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa trực tiếp các workbook từ xa bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể dùng làm nguồn.

**Aspose.Slides có ghi đè lên tệp XLSX bên ngoài khi lưu bản trình bày không?**  
Không. Bản trình bày lưu một [liên kết tới tệp bên ngoài](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chartdata/externalworkbookpath/), và sử dụng nó để đọc dữ liệu. Tệp bên ngoài không bị thay đổi khi bản trình bày được lưu.

**Tôi nên làm gì nếu tệp bên ngoài được bảo mật bằng mật khẩu?**  
Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách thường dùng là gỡ bỏ bảo mật trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, dùng [Aspose.Cells](/cells/net/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một workbook bên ngoài không?**  
Có. Mỗi biểu đồ lưu liên kết riêng của mình. Nếu chúng đều trỏ tới cùng một tệp, việc cập nhật tệp sẽ được phản ánh trong mỗi biểu đồ lần tiếp theo dữ liệu được tải.