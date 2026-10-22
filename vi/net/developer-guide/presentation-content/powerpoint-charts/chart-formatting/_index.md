---
title: Định dạng biểu đồ trong bài thuyết trình bằng .NET
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
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách định dạng biểu đồ trong Aspose.Slides cho .NET và nâng cao bài thuyết trình PowerPoint của bạn với trục tùy chỉnh, phông chữ, định dạng số và viền bỉu đồ bo tròn."
---
## **Tổng quan**

Bài viết này giải thích cách định dạng biểu đồ trong bản trình bày PowerPoint bằng cách sử dụng Aspose.Slides. Nó cho thấy cách tùy chỉnh các thành phần chính của biểu đồ như trục, đường lưới, tiêu đề, chú giải, khu vực vẽ và màu nền tường để cải thiện ngoại hình và khả năng đọc dữ liệu biểu đồ.

Nó cũng trình bày cách thiết lập thuộc tính phông chữ cho văn bản biểu đồ, áp dụng các định dạng số có sẵn cho dữ liệu biểu đồ và bật bo tròn góc cho khu vực biểu đồ. Những ví dụ này cho thấy cách kiểm soát cả phong cách trực quan và cách trình bày dữ liệu của các biểu đồ trong bản trình bày.

## **Định dạng các thực thể biểu đồ**

Sử dụng [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) để định dạng tiêu đề biểu đồ, trục, đường lưới, chú giải và khu vực vẽ. Ví dụ này tạo một biểu đồ đường có các điểm đánh dấu và dữ liệu mặc định, sau đó áp dụng các kiểu văn bản và đường riêng biệt cho trục giá trị và trục danh mục của nó. Kích thước phông chữ và độ rộng đường được chỉ định bằng điểm; nhãn danh mục được xoay 45 độ.

Trục giá trị sử dụng [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) độc lập với các ô nguồn. Thang đo chạy từ -2 đến 15, với khoảng cách lớn là 2 và khoảng cách nhỏ là 0.5. Ví dụ cũng kết hợp định dạng phần trăm với [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/) được đặt thành hàng nghìn, vì vậy hãy điều chỉnh các thiết lập này phù hợp với ý nghĩa và quy mô dữ liệu của bạn. Chú giải nằm ngoài khu vực vẽ vì [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/) bị tắt. Màu nền tường sau và sàn được cấu hình thông qua [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) và [Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/), nhưng những bề mặt này chỉ hiển thị trong biểu đồ 3D.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
var chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

var valueAxisText = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
valueAxisText.FontBold = NullableBool.True;
valueAxisText.FontHeight = 16;
valueAxisText.FontItalic = NullableBool.True;
valueAxisText.FillFormat.FillType = FillType.Solid;
valueAxisText.FillFormat.SolidFillColor.Color = Color.DarkGreen;
valueAxisText.LatinFont = new FontData("Times New Roman");

chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
var valueAxisTitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valueAxisTitle.Text = "Primary Axis";
valueAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valueAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valueAxisTitle.PortionFormat.FontHeight = 20;
valueAxisTitle.PortionFormat.FontBold = NullableBool.True;
valueAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

var categoryAxisText = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
categoryAxisText.FontBold = NullableBool.True;
categoryAxisText.FontHeight = 16;
categoryAxisText.FontItalic = NullableBool.True;
categoryAxisText.FillFormat.FillType = FillType.Solid;
categoryAxisText.FillFormat.SolidFillColor.Color = Color.Blue;
categoryAxisText.LatinFont = new FontData("Arial");

chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

var categoryAxisTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
categoryAxisTitle.Text = "Sample Category";
categoryAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
categoryAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
categoryAxisTitle.PortionFormat.FontHeight = 20;
categoryAxisTitle.PortionFormat.FontBold = NullableBool.True;
categoryAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

var legendText = chart.Legend.TextFormat.PortionFormat;
legendText.FontBold = NullableBool.True;
legendText.FontHeight = 16;
legendText.FontItalic = NullableBool.True;
legendText.FillFormat.FillType = FillType.Solid;
legendText.FillFormat.SolidFillColor.Color = Color.DarkRed;

chart.Legend.Overlay = false;

chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;

chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

presentation.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```

## **Đặt thuộc tính phông chữ cho biểu đồ**

Đặt kích thước phông chữ mặc định cho văn bản biểu đồ thông qua [Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/). Ví dụ tạo một biểu đồ cột nhóm với phông chữ 20 điểm và bật nhãn giá trị cho chuỗi đầu tiên thông qua [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). Các yếu tố văn bản có cài đặt phông chữ riêng có thể ghi đè lên mặc định của biểu đồ.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
chart.TextFormat.PortionFormat.FontHeight = 20;
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
```

## **Đặt định dạng số**

Sử dụng [IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/) để áp dụng một định dạng số có sẵn cho các ô bảng tính của biểu đồ. Ví dụ này tạo một biểu đồ cột nhóm với dữ liệu mặc định, dựa trên ô và áp dụng chỉ số định dạng 10 (`0.00%`) cho mỗi ô giá trị chuỗi. Điều này thay đổi cách hiển thị giá trị trong bảng tính mà không thay đổi số liệu gốc; ví dụ, 0.25 sẽ hiển thị dưới dạng 25.00%. Định dạng trục và nhãn dữ liệu có thể được cấu hình riêng biệt.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
var series = chart.ChartData.Series;

foreach (var chartSeries in series)
{
    foreach (var dataPoint in chartSeries.DataPoints)
    {
        dataPoint.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

presentation.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

Bảng sau liệt kê các chỉ số định dạng số có sẵn cùng với các định dạng Excel đại diện cho ngôn ngữ Anh (Hoa Kỳ). Các chuỗi định dạng chính xác và cách hiển thị có thể khác nhau tùy theo ứng dụng và ngôn ngữ, đặc biệt đối với tiền tệ và ngày tháng. Một số định dạng Excel cũng khác so với mặc định trong chuẩn OOXML, như mô tả trong [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Chỉ mục | Định dạng |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Bật bo tròn góc cho khu vực biểu đồ**

Bật [IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/) để bo tròn các góc của khu vực biểu đồ. Ví dụ tạo một biểu đồ cột nhóm và sử dụng [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) để đặt đường viền của nó thành màu xám đặc và kiểu đường đơn trước khi lưu bản trình bày.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
chart.LineFormat.FillFormat.FillType = FillType.Solid;
chart.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chart.LineFormat.Style = LineStyle.Single;
chart.HasRoundedCorners = true;

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **Chỉnh sửa chú thích biểu đồ hiện có**

Một biểu đồ có thể chứa các hình dạng tùy chỉnh, chẳng hạn như chú thích văn bản giải thích trạng thái của báo cáo. Truy cập các hình dạng này thông qua [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/), cũng được liệt kê dưới [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/) trong Tham chiếu API của Chart. Bộ sưu tập [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) của nó chứa các hình dạng thuộc sở hữu của biểu đồ.

Một hộp văn bản thông thường được đặt lên trên biểu đồ thuộc về slide, ngay cả khi nó trông giống như một phần của biểu đồ. Duyệt qua [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) sẽ tìm thấy biểu đồ và các hình dạng slide thông thường, nhưng không liệt kê các hình dạng riêng lẻ bên trong biểu đồ. Tiêu đề biểu đồ và nhãn dữ liệu là các phần tử biểu đồ riêng biệt, không phải là chú thích tùy chỉnh trong bộ sưu tập này.

Tải xuống [chart-annotations.pptx](chart-annotations.pptx) và đặt nó trong thư mục làm việc của ứng dụng. Slide đầu tiên của nó chứa một biểu đồ với một chú thích chưa nhóm ghi "Preliminary results", một đường thuộc sở hữu biểu đồ và một hộp văn bản slide thông thường ghi "Slide overlay". Ví dụ tìm biểu đồ đầu tiên trên slide đó và thay đổi chú thích thành "Final results" khi báo cáo đã sẵn sàng để xuất bản. Nó kiểm tra xem bộ sưu tập có rỗng không và chỉ chỉnh sửa một [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) có [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) không null và chứa văn bản mong đợi.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-annotations.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.OfType<IChart>().FirstOrDefault();

if (chart == null || chart.UserShapes.Shapes.Count == 0)
{
    Console.WriteLine("No chart or chart-owned shapes found.");
    return;
}

var updated = false;
foreach (var shape in chart.UserShapes.Shapes)
{
    if (shape is IAutoShape annotation && 
        annotation.TextFrame != null && 
        annotation.TextFrame.Text == "Preliminary results")
    {
        annotation.TextFrame.Text = "Final results";
        updated = true;
        break;
    }
}

if (updated)
{
    presentation.Save("chart-annotations-updated.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No matching text annotation found.");
}
```

Đường và hộp văn bản slide vẫn không thay đổi. Các hình ảnh sau cho thấy đầu vào và kết quả đã lưu, mở lại:

| Trước khi chỉnh sửa | Sau khi chỉnh sửa |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Ví dụ chỉ kiểm tra các hình dạng thuộc sở hữu cấp cao nhất của biểu đồ. Nếu một chú thích nằm bên trong một [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), cũng cần kiểm tra bộ sưu tập [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) của nhóm đó. Lặp lại quá trình này một cách đệ quy cho các nhóm lồng nhau, áp dụng cùng các kiểm tra văn bản cho các hình dạng con của chúng. Một nhóm tự nó là một bộ chứa; không nên coi nó là một hộp văn bản.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Tôi có thể đặt màu nền bán trong suốt cho các cột/khu vực trong khi giữ viền không trong suốt không?**

Có. Độ trong suốt của nền và đường viền được cấu hình riêng biệt. Điều này hữu ích để cải thiện khả năng đọc lưới và dữ liệu trong các hình ảnh mật độ cao.

**Làm sao xử lý các nhãn dữ liệu khi chúng chồng lên nhau?**

Giảm kích thước phông chữ, tắt các thành phần nhãn không cần thiết (ví dụ, danh mục), điều chỉnh vị trí nhãn, chỉ hiển thị nhãn cho các điểm được chọn nếu cần, hoặc chuyển định dạng sang "giá trị + chú giải".

**Tôi có thể áp dụng nền gradient hoặc hoa văn cho chuỗi dữ liệu không?**

Có. Các chuỗi hỗ trợ nền đặc, gradient và hoa văn. Thực tế, hãy sử dụng gradient một cách tiết kiệm và tránh các kết hợp làm giảm độ tương phản với lưới và văn bản.