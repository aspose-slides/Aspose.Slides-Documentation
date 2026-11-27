---
title: Định dạng biểu đồ trong .NET
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
- trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách định dạng biểu đồ trong Aspose.Slides cho .NET và nâng cao bản trình chiếu PowerPoint của bạn với các trục, phông chữ, định dạng số và viền biểu đồ bo tròn tùy chỉnh."
---
## **Tổng quan**

Bài viết này giải thích cách định dạng biểu đồ trong bản trình chiếu PowerPoint bằng cách sử dụng Aspose.Slides. Nó cho thấy cách tùy chỉnh các thành phần chính của biểu đồ như trục, đường lưới, tiêu đề, chú giải, khu vực vẽ và các lớp nền tường để cải thiện giao diện và khả năng đọc dữ liệu biểu đồ.

Nó cũng minh họa cách đặt thuộc tính phông chữ cho văn bản biểu đồ, áp dụng các định dạng số có sẵn cho dữ liệu biểu đồ và bật góc bo tròn cho vùng biểu đồ. Cùng nhau, các ví dụ này cho thấy cách kiểm soát cả kiểu dáng trực quan và cách trình bày dữ liệu của biểu đồ trong bản trình chiếu.

Để có các lớp nền và viền riêng biệt cho các khoảng tăng và giảm, hãy xem [ví dụ biểu đồ chứng khoán](/slides/vi/net/create-chart/#create-stock-charts).

## **Định dạng Các Thực Thể Biểu Đồ**

Sử dụng [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) để định dạng tiêu đề biểu đồ, trục, đường lưới, chú giải và khu vực vẽ. Ví dụ này tạo một biểu đồ đường với các điểm đánh dấu và dữ liệu mặc định, sau đó áp dụng các kiểu văn bản và đường riêng biệt cho trục giá trị và trục danh mục của nó. Kích thước phông chữ và độ rộng đường được chỉ định bằng điểm; nhãn danh mục được xoay 45 độ.

Trục giá trị sử dụng [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) một cách độc lập với các ô nguồn. Dải giá trị của nó chạy từ -2 đến 15, với khoảng cách lớn là 2 và khoảng cách nhỏ là 0.5. Ví dụ cũng kết hợp định dạng phần trăm với [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/) được đặt là hàng nghìn, vì vậy hãy điều chỉnh các cài đặt này phù hợp với ý nghĩa và quy mô dữ liệu của bạn. Chú giải nằm ngoài khu vực vẽ vì [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/) bị tắt. Các lớp nền tường và nền sàn được cấu hình thông qua [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) và [Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/), nhưng các bề mặt này chỉ hiển thị trong biểu đồ 3D.

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

## **Đặt Thuộc Tính Phông Chữ cho Biểu Đồ**

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

## **Tái Sử Dụng Định Dạng Khung Văn Bản cho Chú Giải Biểu Đồ**

Để đồng bộ chú giải với tiêu đề slide, đặt phông chữ trong [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) của đoạn văn đầu tiên. Gọi [CopyFrom](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyfrom/) trên [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformattedtextcontainer/textformat/) của chú giải. Nó sẽ đọc các cài đặt khung văn bản, định dạng của đoạn văn đầu tiên và các thuộc tính phông chữ mặc định của đoạn đó. Định dạng được áp dụng trực tiếp cho các phần riêng lẻ hoặc cho các đoạn sau sẽ chỉ áp dụng cục bộ cho nguồn.

Ví dụ sử dụng tiêu đề in đậm, phông Calibri 26 điểm màu xanh hải quân làm mẫu. Sau khi định dạng chú giải, nó dùng [CopyTo](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyto/) để áp dụng cùng một định dạng cho một chú thích riêng biệt.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var heading = shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
var sourceTextFrame = heading.AddTextFrame("Quarterly sales");
var font = sourceTextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
font.LatinFont = new FontData("Calibri");
font.FontHeight = 26;
font.FontBold = NullableBool.True;
font.FillFormat.FillType = FillType.Solid;
font.FillFormat.SolidFillColor.Color = Color.FromArgb(32, 64, 96);

var chart = shapes.AddChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
chart.Style = StyleType.Style3;
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.GetCell(0, 0, 1).Value = "Retail";
workbook.GetCell(0, 0, 2).Value = "Online";
workbook.GetCell(0, 0, 3).Value = "Wholesale";
for (var quarter = 1; quarter <= 4; quarter++)
    workbook.GetCell(0, quarter, 0).Value = $"Q{quarter}";

chart.HasLegend = true;
chart.Legend.Position = LegendPositionType.Bottom;
chart.Legend.TextFormat.CopyFrom(sourceTextFrame);

var caption = shapes.AddAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
var captionTextFrame = caption.AddTextFrame("Sales in millions of dollars");
chart.Legend.TextFormat.CopyTo(captionTextFrame);

presentation.Save("legend-formatting.pptx", SaveFormat.Pptx);
```

Trong bản trình chiếu đã lưu, chú giải và chú thích khớp với tiêu đề về kích thước, độ đậm và màu sắc. Chú giải vẫn hiển thị tên các chuỗi, và chú thích giữ nguyên nội dung của mình. Nếu một phần trong chú thích đã có kích thước phông chữ rõ ràng, kích thước đó sẽ ưu tiên hơn so với mặc định đoạn được sao chép.

| Before copying | After copying |
| --- | --- |
| ![Biểu đồ doanh thu hàng quý với nhãn chú giải đen thông thường và chú thích đen](legend-formatting-before.png) | ![Biểu đồ tương tự với nhãn chú giải màu xanh hải quân lớn hơn, đậm và chú thích phù hợp](legend-formatting.png) |

## **Đặt Định Dạng Số**

Sử dụng [IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/) để áp dụng định dạng số có sẵn cho các ô trong bảng tính biểu đồ. Ví dụ này tạo một biểu đồ cột nhóm với dữ liệu mặc định dựa trên ô và áp dụng chỉ mục định dạng 10 (`0.00%`) cho mỗi ô giá trị chuỗi. Điều này thay đổi cách hiển thị giá trị trong bảng tính mà không thay đổi số liệu gốc; ví dụ, 0.25 sẽ hiển thị là 25.00%. Định dạng trục và nhãn dữ liệu có thể được cấu hình riêng biệt.

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

Bảng sau liệt kê các chỉ mục định dạng số có sẵn cùng với các định dạng Excel tiêu biểu cho ngôn ngữ tiếng Anh (Hoa Kỳ). Các chuỗi định dạng và cách hiển thị chính xác có thể khác nhau tùy ứng dụng và ngôn ngữ, đặc biệt đối với tiền tệ và ngày tháng. Một số định dạng Excel cũng khác so với mặc định trong tiêu chuẩn OOXML, như mô tả trong [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

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

## **Đặt Viền Bo Tròn cho Vùng Biểu Đồ**

Kích hoạt [IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/) để bo tròn các góc của vùng biểu đồ. Ví dụ tạo một biểu đồ cột nhóm và sử dụng [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) để đặt viền của nó thành màu xám đặc và kiểu đường đơn trước khi lưu bản trình chiếu.

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

## **Chỉnh Sửa Chú Thích Biểu Đồ Hiện Có**

Một biểu đồ có thể chứa các hình dạng tùy chỉnh, chẳng hạn như chú thích văn bản giải thích trạng thái của báo cáo. Truy cập các hình dạng này qua [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/), cũng được liệt kê dưới [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/) trong Tham chiếu API Biểu Đồ. Bộ sưu tập [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) của nó chứa các hình dạng thuộc biểu đồ.

Một hộp văn bản thông thường đặt lên trên biểu đồ thuộc về slide, ngay cả khi nó trông giống như một phần của biểu đồ. Duyệt qua [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) sẽ tìm thấy biểu đồ và các hình dạng slide thông thường, nhưng không liệt kê các hình dạng riêng lẻ bên trong biểu đồ. Tiêu đề biểu đồ và nhãn dữ liệu là các thành phần biểu đồ riêng biệt, không phải là chú thích tùy chỉnh trong bộ sưu tập này.

Tải xuống [chart-annotations.pptx](chart-annotations.pptx) và đặt nó trong thư mục làm việc của ứng dụng. Slide đầu tiên của nó chứa một biểu đồ với chú thích chưa nhóm ghi "Preliminary results", một đường thuộc biểu đồ, và một hộp văn bản slide thông thường ghi "Slide overlay". Ví dụ tìm biểu đồ đầu tiên trên slide đó và thay đổi chú thích thành "Final results" khi báo cáo sẵn sàng công bố. Nó kiểm tra xem bộ sưu tập có rỗng không và chỉ chỉnh sửa một [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) có [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) không null và chứa văn bản mong muốn.

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

Đường và hộp văn bản slide vẫn không thay đổi. Các hình ảnh sau đây hiển thị đầu vào và kết quả đã lưu, mở lại:

| Before editing | After editing |
| --- | --- |
| ![Chú thích biểu đồ ghi Kết quả sơ bộ](chart-annotations-before.png) | ![Chú thích biểu đồ ghi Kết quả cuối cùng](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Ví dụ chỉ kiểm tra các hình dạng thuộc biểu đồ ở cấp cao nhất. Nếu một chú thích nằm trong một [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), hãy kiểm tra bộ sưu tập [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) của nhóm đó nữa. Lặp lại quá trình này một cách đệ quy cho các nhóm lồng nhau, áp dụng cùng các kiểm tra văn bản cho các hình dạng con của chúng. Một nhóm tự nó là một container; không nên xem nó như một hộp văn bản.
{{% /alert %}}

## **FAQ**

**Tôi có thể đặt lớp nền bán trong suốt cho cột/khu vực trong khi giữ viền không trong suốt không?**

Có. Độ trong suốt của lớp nền và viền được cấu hình riêng biệt. Điều này hữu ích để cải thiện khả năng đọc của lưới và dữ liệu trong các biểu đồ dày đặc.

**Làm thế nào để xử lý các nhãn dữ liệu khi chúng chồng lên nhau?**

Giảm kích thước phông chữ, tắt các thành phần nhãn không cần thiết (ví dụ, danh mục), điều chỉnh vị trí nhãn, chỉ hiển thị nhãn cho các điểm đã chọn nếu cần, hoặc chuyển định dạng sang "giá trị + chú giải".

**Tôi có thể áp dụng lớp nền gradient hoặc họa tiết cho chuỗi không?**

Có. Các chuỗi hỗ trợ lớp nền đồng nhất, gradient và họa tiết. Trong thực tế, nên sử dụng gradient một cách hạn chế và tránh các kết hợp làm giảm độ tương phản với lưới và văn bản.