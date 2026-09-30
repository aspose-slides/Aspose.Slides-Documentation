---
title: Tùy chỉnh chú giải biểu đồ trong bài thuyết trình trên .NET
linktitle: Chú giải biểu đồ
type: docs
url: /vi/net/chart-legend/
keywords:
- chú giải biểu đồ
- vị trí chú giải
- kích thước phông chữ
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tùy chỉnh chú giải biểu đồ với Aspose.Slides cho .NET để tối ưu hóa bài thuyết trình PowerPoint với định dạng chú giải được thiết kế riêng."
---
## **Tổng quan**

Aspose.Slides for .NET cung cấp các tùy chọn để tùy chỉnh chú giải biểu đồ trong bài thuyết trình PowerPoint. Bài viết này cho thấy cách đặt vị trí và kích thước cho chú giải, thiết lập kích thước phông chữ cho toàn bộ chú giải, định dạng một mục chú giải riêng lẻ, và ẩn hoặc khôi phục các mục đã chọn.

FAQ đề cập đến các hành vi liên quan, bao gồm việc dành không gian cho chú giải, hiển thị nhãn nhiều dòng, và kế thừa định dạng từ giao diện chủ đề của bài thuyết trình.

## **Vị trí chú giải**

Sử dụng các thuộc tính legend [X](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/x/), [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/y/), [Width](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/width/), và [Height](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/height/) để chỉ định vị trí và kích thước của nó dưới dạng tỉ lệ của kích thước biểu đồ.

Ví dụ này tạo một bài thuyết trình và thêm một biểu đồ cột nhóm với dữ liệu mặc định vào slide đầu tiên. Việc chia các độ lệch và kích thước mong muốn của chú giải cho chiều rộng và chiều cao của biểu đồ sẽ chuyển chúng thành các giá trị tương đối: chú giải được dịch 50 điểm từ góc trái trên của biểu đồ và có kích thước 100 × 100 điểm.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Diễn đạt vị trí và kích thước của chú giải tương đối với biểu đồ.
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

presentation.Save("legend_position.pptx", SaveFormat.Pptx);
```

## **Đặt kích thước phông chữ của chú giải**

Sử dụng thuộc tính legend [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/textformat/) để truy cập định dạng văn bản và thiết lập [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) tính bằng điểm.

Ví dụ này tạo một biểu đồ với dữ liệu mặc định và đặt văn bản chú giải thành 20 điểm. Nó cũng tắt việc tự động xác định giới hạn cho trục dọc và đặt phạm vi từ -5 đến 10.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = -5;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 10;

presentation.Save("legend_font_size.pptx", SaveFormat.Pptx);
```

## **Đặt kích thước phông chữ cho một mục chú giải riêng lẻ**

Sử dụng bộ sưu tập legend [Entries](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/entries/) để truy cập định dạng cho một mục cụ thể. Các chỉ mục mục bắt đầu từ 0, vì vậy chỉ mục `1` đề cập tới mục thứ hai.

Ví dụ này tạo một biểu đồ cột nhóm mà dữ liệu mặc định bao gồm ít nhất hai series. Nó định dạng mục chú giải thứ hai với chữ đậm, nghiêng và màu xanh có kích thước 20 điểm.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
var textFormat = chart.Legend.Entries[1].TextFormat;

textFormat.PortionFormat.FontBold = NullableBool.True;
textFormat.PortionFormat.FontHeight = 20;
textFormat.PortionFormat.FontItalic = NullableBool.True;
textFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
textFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("legend_entry_format.pptx", SaveFormat.Pptx);
```

## **Ẩn các mục chú giải riêng lẻ**

Để loại bỏ một series phụ khỏi chú giải trong khi vẫn giữ dữ liệu của nó hiển thị, thiết lập [ILegendEntryProperties.Hide](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegendentryproperties/hide/) thành `true` thông qua [IChartSeries.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/relatedlegendentry/). Điều này chỉ ẩn mục chú giải đã chọn; nó không xóa series hoặc các điểm dữ liệu của nó. Thiết lập [IChart.HasLegend](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/haslegend/) thành `false`, ngược lại, sẽ ẩn toàn bộ chú giải.

Ví dụ dưới đây tạo một biểu đồ cột nhóm với nhiều series sử dụng dữ liệu mặc định. Nó ẩn mục chú giải của series thứ hai (chỉ mục `1`) và lưu bài thuyết trình. Sau đó khôi phục mục bằng cách đặt `Hide` thành `false` và lưu một bản sao thứ hai. Các cột vẫn hiển thị trong cả hai tệp.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 200);
chart.HasLegend = true;

var legendEntry = chart.ChartData.Series[1].RelatedLegendEntry;

legendEntry.Hide = true;
presentation.Save("hidden_legend_entry.pptx", SaveFormat.Pptx);

// Khôi phục cùng mục mà không thay đổi dữ liệu biểu đồ.
legendEntry.Hide = false;
presentation.Save("restored_legend_entry.pptx", SaveFormat.Pptx);
```

Sự so sánh dưới đây hiển thị cùng một biểu đồ với tất cả các mục chú giải hiển thị và với mục thứ hai bị ẩn. Các cột của series thứ hai vẫn không thay đổi.

![So sánh biểu đồ với tất cả các mục chú giải hiển thị và với Series 2 bị ẩn khỏi chú giải; tất cả các cột vẫn hiển thị.](hide-legend-entry.png)

Trong biểu đồ cột, thanh và đường, các mục chú giải xác định series. Đối với biểu đồ tròn, chúng xác định các điểm dữ liệu riêng lẻ (miếng bánh), vì vậy hãy sử dụng [IChartDataPoint.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/relatedlegendentry/) trên miếng bánh được chọn. API tài liệu thuộc tính này cho các loại biểu đồ `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` và `BarOfPie`. Đừng cho rằng nó áp dụng cho biểu đồ vòng donut, vì chúng không nằm trong danh sách đó.

## **FAQ**

**Can I make the chart allocate space for the legend instead of overlaying it?**

Có. Đặt [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) thành `false` để dành không gian cho chú giải thay vì cho phép nó chồng lên khu vực vẽ.

**Can I make multiline legend labels?**

Có. Nhãn dài có thể xuống dòng khi chiều rộng sẵn có không đủ. Bạn cũng có thể sử dụng ký tự xuống dòng trong tên series để yêu cầu ngắt dòng.

**How do I make the legend follow the presentation theme's color scheme?**

Để các màu, nền và phông chữ của chú giải không được thiết lập để nó có thể kế thừa định dạng từ chủ đề. Định dạng rõ ràng sẽ ghi đè các cài đặt chủ đề tương ứng.