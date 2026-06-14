---
title: Tùy chỉnh Trục biểu đồ trong Bản trình chiếu bằng .NET
linktitle: Trục biểu đồ
type: docs
url: /vi/net/chart-axis/
keywords:
- trục biểu đồ
- trục dọc
- trục ngang
- tùy chỉnh trục
- điều chỉnh trục
- quản lý trục
- thuộc tính trục
- giá trị tối đa
- giá trị tối thiểu
- đường trục
- định dạng ngày
- tiêu đề trục
- vị trí trục
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Khám phá cách sử dụng Aspose.Slides cho .NET để tùy chỉnh trục biểu đồ trong bản trình chiếu PowerPoint cho báo cáo và trực quan hóa."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh các trục biểu đồ trong Aspose.Slides. Nó chỉ ra cách lấy giá trị trục thực tế, hoán đổi dữ liệu giữa các trục, ẩn trục dọc hoặc ngang cho biểu đồ đường, thay đổi loại trục danh mục, đặt định dạng ngày cho giá trị trục danh mục, xoay tiêu đề trục, đặt vị trí trục và hiển thị nhãn đơn vị trên trục giá trị.

## **Lấy Giá trị Tối đa trên Trục Dọc của Biểu đồ**
Aspose.Slides for .NET cho phép bạn lấy giá trị tối thiểu và tối đa trên trục dọc. Thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Truy cập slide đầu tiên.
1. Thêm một biểu đồ với dữ liệu mặc định.
1. Lấy giá trị tối đa thực tế trên trục.
1. Lấy giá trị tối thiểu thực tế trên trục.
1. Lấy đơn vị lớn thực tế của trục.
1. Lấy đơn vị nhỏ thực tế của trục.
1. Lấy tỉ lệ đơn vị lớn thực tế của trục.
1. Lấy tỉ lệ đơn vị nhỏ thực tế của trục.

Mã mẫu—một triển khai các bước trên—cho bạn cách lấy các giá trị cần thiết trong C#:

```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// Lưu bản trình chiếu
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```

## **Hoán đổi Dữ liệu giữa các Trục**
Aspose.Slides cho phép bạn nhanh chóng hoán đổi dữ liệu giữa các trục—dữ liệu hiển thị trên trục dọc (trục y) sẽ chuyển sang trục ngang (trục x) và ngược lại.

Mã C# này cho bạn cách thực hiện việc hoán đổi dữ liệu giữa các trục trên một biểu đồ:

```c#
 // Tạo bản trình chiếu trống
 using (Presentation pres = new Presentation())
 {
 	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
 
 	//Hoán đổi hàng và cột
 	chart.ChartData.SwitchRowColumn();
 		   
 	// Lưu bản trình chiếu
 	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
  }
```

## **Vô hiệu hoá Trục Dọc cho Biểu đồ Đường**

Mã C# này cho bạn cách ẩn trục dọc cho một biểu đồ đường:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Vô hiệu hoá Trục Ngang cho Biểu đồ Đường**

Mã này cho bạn cách ẩn trục ngang cho một biểu đồ đường:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Thay đổi Trục Danh mục**

Bằng thuộc tính **CategoryAxisType**, bạn có thể chỉ định loại trục danh mục mong muốn (**date** hoặc **text**). Mã C# dưới đây thể hiện thao tác:

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes[0] as IChart;
    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;
    presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
}
```

## **Đặt Định dạng Ngày cho Giá trị Trục Danh mục**
Aspose.Slides for .NET cho phép bạn đặt định dạng ngày cho một giá trị trục danh mục. Thao tác này được minh họa trong mã C# sau:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Area, 50, 50, 450, 300);

	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	wb.Clear(0);

	chart.ChartData.Categories.Clear();
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Add(wb.GetCell(0, "A2", new DateTime(2015, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A3", new DateTime(2016, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A4", new DateTime(2017, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A5", new DateTime(2018, 1, 1).ToOADate()));

	IChartSeries series = chart.ChartData.Series.Add(ChartType.Line);
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B2", 1));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B3", 2));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B4", 3));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B5", 4));
	chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
	chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
	chart.Axes.HorizontalAxis.NumberFormat = "yyyy";
	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **Đặt Góc Xoay cho Tiêu đề Trục Biểu đồ**
Aspose.Slides for .NET cho phép bạn đặt góc xoay cho tiêu đề trục biểu đồ. Mã C# này minh họa thao tác:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **Đặt Vị trí Trục trên Trục Danh mục hoặc Giá trị**
Aspose.Slides for .NET cho phép bạn đặt vị trí trục trong một trục danh mục hoặc giá trị. Mã C# này cho thấy cách thực hiện:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```

## **Bật Nhãn Đơn vị Hiển thị trên Trục Giá trị Biểu đồ**
Aspose.Slides for .NET cho phép bạn cấu hình biểu đồ để hiển thị nhãn đơn vị trên trục giá trị của nó. Mã C# này minh họa thao tác:

```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Làm thế nào để đặt giá trị mà một trục cắt qua trục kia (giao điểm trục)?**

Các trục cung cấp một [cài đặt giao cắt](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/axis/crosstype/): bạn có thể chọn cắt tại không, tại danh mục/giá trị tối đa, hoặc tại một giá trị số cụ thể. Điều này hữu ích để di chuyển trục X lên hoặc xuống hoặc để nhấn mạnh một đường cơ sở.

**Làm sao tôi có thể đặt vị trí nhãn đánh dấu so với trục (bên cạnh, bên ngoài, bên trong)?**

Đặt [vị trí nhãn](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/axis/majortickmark/) thành "cross", "outside" hoặc "inside". Điều này ảnh hưởng đến khả năng đọc và giúp tiết kiệm không gian, đặc biệt trên các biểu đồ nhỏ.