---
title: Định dạng biểu đồ trong bản trình bày .NET
linktitle: Định dạng biểu đồ
type: docs
weight: 60
url: /vi/net/chart-formatting/
keywords:
- định dạng biểu đồ
- định dạng biểu đồ
- thực thể biểu đồ
- thuộc tính biểu đồ
- cài đặt biểu đồ
- tùy chọn biểu đồ
- thuộc tính phông chữ
- viền bo tròn
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách định dạng biểu đồ trong Aspose.Slides cho .NET và nâng cao bản trình bày PowerPoint của bạn với phong cách chuyên nghiệp, bắt mắt."
---
## **Tổng quan**

Bài viết này giải thích cách định dạng biểu đồ trong bài thuyết trình PowerPoint bằng cách sử dụng Aspose.Slides. Nó cho thấy cách tùy chỉnh các thành phần chính của biểu đồ như trục, đường lưới, tiêu đề, chú giải, khu vực vẽ và màu nền tường để cải thiện diện mạo và khả năng đọc dữ liệu biểu đồ.

Nó cũng trình bày cách đặt thuộc tính phông chữ cho văn bản biểu đồ, áp dụng định dạng số có sẵn và tùy chỉnh cho dữ liệu biểu đồ, và bật góc bo tròn cho vùng biểu đồ. Cùng nhau, các ví dụ này cho thấy cách kiểm soát cả kiểu dáng trực quan và cách trình bày dữ liệu của biểu đồ trong một bài thuyết trình.

## **Định dạng các thực thể biểu đồ**
Aspose.Slides for .NET cho phép nhà phát triển thêm biểu đồ tùy chỉnh vào các slide từ đầu. Bài viết này giải thích cách định dạng các thực thể biểu đồ khác nhau bao gồm trục danh mục và trục giá trị của biểu đồ.

Aspose.Slides for .NET cung cấp một API đơn giản để quản lý các thực thể biểu đồ khác nhau và định dạng chúng bằng các giá trị tùy chỉnh:

1. Tạo một thể hiện của lớp **Presentation**.
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một biểu đồ với dữ liệu mặc định cùng với bất kỳ loại nào mong muốn (trong ví dụ này chúng ta sẽ sử dụng ChartType.LineWithMarkers).
1. Truy cập Trục Giá trị của biểu đồ và đặt các thuộc tính sau:
   1. Đặt **Line format** cho các đường lưới chính của Trục Giá trị
   1. Đặt **Line format** cho các đường lưới phụ của Trục Giá trị
   1. Đặt **Number Format** cho Trục Giá trị
   1. Đặt **Min, Max, Major and Minor units** cho Trục Giá trị
   1. Đặt **Text Properties** cho dữ liệu Trục Giá trị
   1. Đặt **Title** cho Trục Giá trị
   1. Đặt **Line Format** cho Trục Giá trị
1. Truy cập Trục Danh mục của biểu đồ và đặt các thuộc tính sau:
   1. Đặt **Line format** cho các đường lưới chính của Trục Danh mục
   1. Đặt **Line format** cho các đường lưới phụ của Trục Danh mục
   1. Đặt **Text Properties** cho dữ liệu Trục Danh mục
   1. Đặt **Title** cho Trục Danh mục
   1. Đặt **Label Positioning** cho Trục Danh mục
   1. Đặt **Rotation Angle** cho nhãn Trục Danh mục
1. Truy cập Chú giải của biểu đồ và đặt **Text Properties** cho chúng
1. Đặt hiển thị chú giải biểu đồ mà không bị chồng lên biểu đồ
1. Truy cập **Secondary Value Axis** của biểu đồ và đặt các thuộc tính sau:
   1. Bật **Value Axis** phụ
   1. Đặt **Line Format** cho Trục Giá trị phụ
   1. Đặt **Number Format** cho Trục Giá trị phụ
   1. Đặt **Min, Max, Major and Minor units** cho Trục Giá trị phụ
1. Bây giờ vẽ chuỗi biểu đồ đầu tiên trên Trục Giá trị phụ
1. Đặt màu nền tường phía sau biểu đồ
1. Đặt màu nền khu vực vẽ biểu đồ
1. Ghi bài thuyết trình đã sửa đổi vào tệp PPTX

```c#
// Khởi tạo bản trình bày// Khởi tạo bản trình bày
Presentation pres = new Presentation();

// Truy cập slide đầu tiên
ISlide slide = pres.Slides[0];

// Thêm biểu đồ mẫu
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// Đặt tiêu đề biểu đồ
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// Đặt định dạng đường lưới chính cho trục giá trị
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Đặt định dạng đường lưới phụ cho trục giá trị
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Đặt định dạng số cho trục giá trị
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Đặt giá trị tối đa, tối thiểu cho biểu đồ
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Đặt thuộc tính văn bản trục giá trị
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// Đặt tiêu đề trục giá trị
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Primary Axis";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// Đặt định dạng đường trục giá trị : Bây giờ đã lỗi thời
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// Đặt định dạng đường lưới chính cho trục danh mục
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Đặt định dạng đường lưới phụ cho trục danh mục
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Đặt thuộc tính văn bản trục danh mục
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Đặt tiêu đề danh mục
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Sample Category";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Đặt vị trí nhãn trục danh mục
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Đặt góc quay nhãn trục danh mục
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Đặt thuộc tính văn bản chú giải
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Hiển thị chú giải biểu đồ mà không chồng lên biểu đồ

chart.Legend.Overlay = true;
            
// Vẽ chuỗi đầu tiên trên trục giá trị phụ
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Đặt màu tường phía sau biểu đồ
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Đặt màu khu vực vẽ
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Lưu bản trình bày
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```



## **Đặt Thuộc tính Phông chữ cho Biểu đồ**
Aspose.Slides for .NET hỗ trợ việc đặt các thuộc tính liên quan tới phông chữ cho biểu đồ. Vui lòng làm theo các bước sau để đặt thuộc tính phông chữ cho biểu đồ.

- Khởi tạo đối tượng lớp Presentation.
- Thêm biểu đồ vào slide.
- Đặt kích thước phông chữ.
- Lưu bài thuyết trình đã chỉnh sửa.

Ví dụ mẫu dưới đây được đưa ra.

```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```




## **Đặt Định dạng Số**
Aspose.Slides for .NET cung cấp một API đơn giản để quản lý định dạng dữ liệu biểu đồ:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một biểu đồ với dữ liệu mặc định cùng với bất kỳ loại nào mong muốn (ví dụ này sử dụng **ChartType.ClusteredColumn**).
1. Đặt định dạng số có sẵn từ các giá trị preset có thể.
1. Duyệt qua các ô dữ liệu biểu đồ trong mỗi chuỗi biểu đồ và đặt định dạng số cho dữ liệu biểu đồ.
1. Lưu bài thuyết trình.
1. Đặt định dạng số tùy chỉnh.
1. Duyệt qua các ô dữ liệu biểu đồ trong mỗi chuỗi biểu đồ và đặt một định dạng số khác cho dữ liệu biểu đồ.
1. Lưu bài thuyết trình.

```c#
// Khởi tạo bản trình bày// Khởi tạo bản trình bày
Presentation pres = new Presentation();

// Truy cập slide đầu tiên của bản trình bày
ISlide slide = pres.Slides[0];

// Thêm biểu đồ cột nhóm mặc định
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// Truy cập bộ sưu tập chuỗi biểu đồ
IChartSeriesCollection series = chart.ChartData.Series;

// Đặt định dạng số preset
// Duyệt qua mỗi chuỗi biểu đồ
foreach (ChartSeries ser in series)
{
    // Duyệt qua mỗi ô dữ liệu trong chuỗi
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // Đặt định dạng số
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// Lưu bản trình bày
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

Các giá trị định dạng số preset có thể sử dụng cùng với chỉ số preset của chúng được liệt kê dưới đây:

|**0**|Chung|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Đặt Đường viền Bo tròn cho Vùng Biểu đồ**
Aspose.Slides for .NET hỗ trợ việc đặt vùng biểu đồ. Các thuộc tính **IChart.HasRoundedCorners** và **Chart.HasRoundedCorners** đã được thêm vào Aspose.Slides.

1. Khởi tạo đối tượng lớp `Presentation`.
1. Thêm biểu đồ vào slide.
1. Đặt kiểu và màu nền cho biểu đồ
1. Đặt thuộc tính góc bo tròn thành True.
1. Lưu bài thuyết trình đã chỉnh sửa.

Ví dụ mẫu dưới đây được đưa ra.

```c#
using (Presentation presentation = new Presentation())
{
	ISlide slide = presentation.Slides[0];
	IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
	chart.LineFormat.FillFormat.FillType = FillType.Solid;
	chart.LineFormat.Style = LineStyle.Single;
	chart.HasRoundedCorners = true;

	presentation.Save("out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt màu nền bán trong suốt cho cột/khu vực trong khi vẫn giữ viền không trong suốt không?**

Có. Độ trong suốt của màu nền và đường viền được cấu hình riêng biệt. Điều này hữu ích để cải thiện khả năng đọc của lưới và dữ liệu trong các biểu đồ dày đặc.

**Làm sao tôi có thể xử lý các nhãn dữ liệu khi chúng bị chồng lên nhau?**

Giảm kích thước phông chữ, tắt các thành phần nhãn không cần thiết (ví dụ, danh mục), đặt độ lệch/vị trí nhãn, chỉ hiển thị nhãn cho các điểm đã chọn nếu cần, hoặc chuyển định dạng sang "giá trị + chú giải".

**Tôi có thể áp dụng màu nền gradient hoặc họa tiết cho chuỗi dữ liệu không?**

Có. Cả màu nền đặc và gradient/họa tiết thường đều khả dụng. Trong thực tế, hãy sử dụng gradient một cách tiết kiệm và tránh các kết hợp làm giảm độ tương phản với lưới và văn bản.