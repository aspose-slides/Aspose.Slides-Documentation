---
title: Tạo biểu đồ bằng VSTO và Aspose.Slides cho .NET
linktitle: Tạo biểu đồ
type: docs
weight: 80
url: /vi/net/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- tạo biểu đồ
- di chuyển
- VSTO
- tự động hóa Office
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách tự động tạo biểu đồ PowerPoint trong C#. Hướng dẫn từng bước này cho thấy tại sao Aspose.Slides cho .NET là một giải pháp thay thế nhanh hơn và mạnh mẽ hơn so với Microsoft.Office.Interop."
---
## **Tổng quan**

Bài viết này trình bày cách tạo và tùy chỉnh biểu đồ trong bài thuyết trình Microsoft PowerPoint một cách lập trình bằng C#. Với Aspose.Slides cho .NET, bạn có thể tự động tạo các biểu đồ chuyên nghiệp, dựa trên dữ liệu mà không cần dựa vào Microsoft Office hoặc các thư viện Interop. API cung cấp một bộ tính năng phong phú để xây dựng biểu đồ cột, biểu đồ tròn, biểu đồ đường, và nhiều loại khác — tất cả với khả năng kiểm soát toàn diện về giao diện, dữ liệu và bố cục. Dù bạn đang tạo báo cáo, bảng điều khiển hay bài thuyết trình doanh nghiệp, Aspose.Slides giúp bạn cung cấp các hình ảnh minh họa chất lượng cao trực tiếp từ ứng dụng .NET của mình.

## **Ví dụ VSTO**

Phần này trình bày cách tạo biểu đồ trong một bài thuyết trình Microsoft PowerPoint bằng **VSTO (Visual Studio Tools for Office)**. Với VSTO, bạn có thể lập trình tạo và tùy chỉnh biểu đồ bằng cách kết hợp tự động hóa PowerPoint và Excel. Ví dụ được cung cấp cho thấy cách thêm **biểu đồ cột nhóm 3D**, điền dữ liệu từ một bảng tính Excel, điều chỉnh định dạng và bố cục, và lưu bản thuyết trình cuối cùng — tất cả từ một ứng dụng .NET.

1. Tạo một thể hiện của bài thuyết trình Microsoft PowerPoint.  
1. Thêm một slide trống vào bài thuyết trình.  
1. Thêm một biểu đồ cột nhóm 3D và truy cập vào nó.  
1. Tạo một thể hiện mới của workbook Microsoft Excel và tải dữ liệu biểu đồ.  
1. Truy cập worksheet dữ liệu biểu đồ bằng thể hiện workbook Excel.  
1. Đặt phạm vi dữ liệu biểu đồ trong worksheet và loại bỏ series 2 và 3 khỏi biểu đồ.  
1. Sửa đổi dữ liệu danh mục của biểu đồ trong worksheet dữ liệu biểu đồ.  
1. Sửa đổi dữ liệu series 1 trong worksheet dữ liệu biểu đồ.  
1. Truy cập tiêu đề biểu đồ và đặt các thuộc tính liên quan tới phông chữ.  
1. Truy cập trục giá trị của biểu đồ và đặt đơn vị chính, đơn vị phụ, giá trị tối đa và giá trị tối thiểu.  
1. Truy cập trục độ sâu (series) của biểu đồ và loại bỏ nó — chỉ có một series được sử dụng trong ví dụ này.  
1. Đặt góc quay của biểu đồ theo hướng X và Y.  
1. Lưu bài thuyết trình.  
1. Đóng các thể hiện Microsoft Excel và PowerPoint.

```c#
EnsurePowerPointIsRunning(true, true);

// Tạo một đối tượng slide.
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

// Truy cập slide đầu tiên của bản trình chiếu.
objSlide = objPres.Slides[1];

// Chọn slide đầu tiên và đặt bố cục cho nó.
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

// Thêm một biểu đồ mặc định vào slide.
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20, 30, 400, 300);

// Truy cập biểu đồ đã được thêm.
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

// Truy cập dữ liệu biểu đồ.
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

// Tạo một thể hiện của workbook Excel để làm việc với dữ liệu biểu đồ.
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

// Truy cập worksheet dữ liệu cho biểu đồ.
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

// Đặt phạm vi dữ liệu cho biểu đồ.
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

// Áp dụng phạm vi được chỉ định vào bảng dữ liệu biểu đồ.
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

// Đặt giá trị cho các danh mục và dữ liệu series tương ứng.
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

// Đặt tiêu đề biểu đồ.
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 Sales";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

// Truy cập trục giá trị của biểu đồ.
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

// Đặt các giá trị cho các đơn vị trục.
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

// Truy cập trục độ sâu của biểu đồ.
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

// Đặt góc quay của biểu đồ.
ppChart.Rotation = 20;   // Giá trị Y
ppChart.Elevation = 15;  // Giá trị X
ppChart.RightAngleAxes = false;

// Lưu bản trình chiếu dưới dạng tệp PPTX.
objPres.SaveAs("VSTO_Sample_Chart.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

// Đóng workbook và bản trình chiếu.
dataWorkbook.Application.Quit();
objPres.Application.Quit();
```

```c#
public static void EnsurePowerPointIsRunning(bool blnAddPresentation)
{
    EnsurePowerPointIsRunning(blnAddPresentation, false);
}

public static void EnsurePowerPointIsRunning()
{
    EnsurePowerPointIsRunning(false, false);
}

public static void EnsurePowerPointIsRunning(bool blnAddPresentation, bool blnAddSlide)
{
    string strName = null;

    // Cố gắng truy cập thuộc tính Name. Nếu nó ném ra ngoại lệ, khởi động một thể hiện mới của PowerPoint.
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }

    // blnAddPresentation được dùng để đảm bảo rằng một bản trình chiếu đã được tải.
    if (blnAddPresentation == true)
    {
        try
        {
            strName = objPres.Name;
        }
        catch (Exception ex)
        {
            objPres = objPPT.Presentations.Add(MsoTriState.msoTrue);
        }
    }

    // blnAddSlide được dùng để đảm bảo rằng có ít nhất một slide trong bản trình chiếu.
    if (blnAddSlide)
    {
        try
        {
            strName = objPres.Slides[1].Name;
        }
        catch (Exception ex)
        {
            Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;
            Microsoft.Office.Interop.PowerPoint.CustomLayout objCustomLayout = null;
            objCustomLayout = objPres.SlideMaster.CustomLayouts[1];
            objSlide = objPres.Slides.AddSlide(1, objCustomLayout);
            objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutText;
            objCustomLayout = null;
            objSlide = null;
        }
    }
}
```

Kết quả:

![Biểu đồ được tạo bằng VSTO](chart-created-using-VSTO.png)

## **Ví dụ Aspose.Slides cho .NET**

Ví dụ sau đây cho thấy cách tạo một biểu đồ đơn giản trong bài thuyết trình PowerPoint bằng Aspose.Slides cho .NET. Đoạn mã này minh họa cách thêm **biểu đồ cột nhóm 3D**, điền dữ liệu mẫu và tùy chỉnh giao diện của nó. Chỉ với vài dòng mã, bạn có thể tạo biểu đồ động và tích hợp chúng vào bài thuyết trình mà không cần sử dụng Microsoft Office.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/).  
1. Lấy tham chiếu đến slide đầu tiên.  
1. Thêm một biểu đồ cột nhóm 3D và truy cập vào nó.  
1. Truy cập dữ liệu biểu đồ.  
1. Loại bỏ Series 2 và Series 3 không dùng.  
1. Sửa đổi các danh mục biểu đồ bằng cách cập nhật nhãn.  
1. Cập nhật giá trị của Series 1.  
1. Truy cập tiêu đề biểu đồ và đặt các thuộc tính phông chữ.  
1. Cấu hình trục giá trị của biểu đồ, bao gồm đơn vị chính, đơn vị phụ, giá trị tối đa và tối thiểu.  
1. Đặt góc quay của biểu đồ trên các trục X và Y.  
1. Lưu bài thuyết trình ở định dạng PPTX.

```cs
// Tạo một bản trình chiếu trống.
using (Presentation presentation = new Presentation())
{
    // Truy cập slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm một biểu đồ mặc định.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20, 30, 400, 300);

    // Lấy dữ liệu biểu đồ.
    IChartData chartData = chart.ChartData;

    // Xóa các series mặc định dư thừa.
    chartData.Series.RemoveAt(1);
    chartData.Series.RemoveAt(1);

    // Sửa đổi tên danh mục của biểu đồ.
    chartData.Categories[0].AsCell.Value = "Bikes";
    chartData.Categories[1].AsCell.Value = "Accessories";
    chartData.Categories[2].AsCell.Value = "Repairs";
    chartData.Categories[3].AsCell.Value = "Clothing";

    // Đặt chỉ mục của worksheet dữ liệu biểu đồ.
    int worksheetIndex = 0;

    // Lấy workbook dữ liệu biểu đồ.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Sửa đổi giá trị series của biểu đồ.
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 1000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2500));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 4000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 3000));

    // Đặt tiêu đề biểu đồ.
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("2007 Sales");
    IPortionFormat format = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
    format.FontItalic = NullableBool.True;
    format.FontHeight = 18;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    // Đặt các tùy chọn trục.
    chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

    chart.Axes.VerticalAxis.MaxValue = 4000.0F;
    chart.Axes.VerticalAxis.MinValue = 0.0F;
    chart.Axes.VerticalAxis.MajorUnit = 2000.0F;
    chart.Axes.VerticalAxis.MinorUnit = 1000.0F;
    chart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

    // Đặt góc quay của biểu đồ.
    chart.Rotation3D.RotationX = 15;
    chart.Rotation3D.RotationY = 20;

    // Lưu bản trình chiếu dưới dạng tệp PPTX.
    presentation.Save("Aspose_Sample_Chart.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Biểu đồ được tạo bằng Aspose.Slides cho .NET](chart-created-using-aspose-slides.png)

## **Câu hỏi thường gặp**

**Tôi có thể tạo các loại biểu đồ khác như biểu đồ tròn, đường hoặc cột với Aspose.Slides không?**

Có. Aspose.Slides cho .NET hỗ trợ nhiều loại [biểu đồ](/slides/vi/net/create-chart/), bao gồm biểu đồ tròn, biểu đồ đường, biểu đồ cột, biểu đồ phân tán, biểu đồ bong bóng và nhiều hơn nữa. Bạn có thể chỉ định loại biểu đồ mong muốn bằng cách sử dụng enumeration [ChartType](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/charttype/) khi thêm biểu đồ.

**Tôi có thể áp dụng các kiểu hoặc chủ đề tùy chỉnh cho biểu đồ không?**

Có. Bạn có thể tùy chỉnh hoàn toàn giao diện biểu đồ, bao gồm màu sắc, phông chữ, màu nền, đường viền, lưới và bố cục. Tuy nhiên, việc áp dụng các chủ đề Office chính xác như trong PowerPoint đòi hỏi phải thiết lập thủ công các kiểu riêng lẻ.

**Tôi có thể xuất biểu đồ dưới dạng hình ảnh riêng biệt khỏi slide không?**

Có, Aspose.Slides cho phép bạn xuất bất kỳ hình dạng nào — bao gồm biểu đồ — thành một hình ảnh riêng (ví dụ PNG, JPEG) bằng phương thức `GetImage` trên [shape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/) của biểu đồ.