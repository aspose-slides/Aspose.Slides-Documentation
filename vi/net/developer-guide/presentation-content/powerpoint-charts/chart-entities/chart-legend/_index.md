---
title: Tùy chỉnh chú giải biểu đồ trong bản trình bày .NET
linktitle: Chú giải biểu đồ
type: docs
url: /vi/net/chart-legend/
keywords:
- chú giải biểu đồ
- vị trí chú giải
- kích thước phông chữ
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tùy chỉnh chú giải biểu đồ với Aspose.Slides cho .NET để tối ưu hóa các bản trình bày PowerPoint với định dạng chú giải được điều chỉnh."
---
## **Tổng quan**

Aspose.Slides cung cấp các tùy chọn để tùy chỉnh chú giải biểu đồ trong bản trình bày PowerPoint. Bài viết này mô tả cách đặt vị trí và kích thước của chú giải, đặt kích thước phông chữ cho toàn bộ chú giải, và áp dụng định dạng cho một mục chú giải riêng lẻ.

Nó cũng bao gồm một số hành vi liên quan trong phần FAQ, bao gồm việc sử dụng chế độ không chồng lên để khu vực vẽ nhường chỗ cho chú giải, cho phép nhãn chú giải dài tự động xuống dòng hoặc sử dụng dấu ngắt dòng, và cho phép định dạng chú giải kế thừa từ giao diện chủ đề của bản trình bày khi không áp dụng cài đặt màu văn bản và nền rõ ràng.

## **Định vị chú giải**
Để đặt các thuộc tính của chú giải, vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
- Lấy tham chiếu của slide.
- Thêm biểu đồ vào slide.
- Đặt các thuộc tính của chú giải.
- Ghi bản trình bày dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã đặt vị trí và kích thước cho chú giải biểu đồ.

```c#
// Tạo một thể hiện của lớp Presentation
Presentation presentation = new Presentation();

// Lấy tham chiếu của slide
ISlide slide = presentation.Slides[0];

// Thêm biểu đồ cột nhóm vào slide
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Đặt các thuộc tính của chú giải
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// Ghi bản trình bày ra đĩa
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```



## **Đặt kích thước phông chữ cho chú giải**
Aspose.Slides cho .NET cho phép các nhà phát triển thiết lập kích thước phông chữ cho chú giải. Vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp `Presentation`.
- Tạo biểu đồ mặc định.
- Đặt kích thước phông chữ.
- Đặt giá trị trục tối thiểu.
- Đặt giá trị trục tối đa.
- Ghi bản trình bày ra đĩa.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
	chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
	chart.Axes.VerticalAxis.MinValue = -5;
	chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
	chart.Axes.VerticalAxis.MaxValue = 10;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Đặt kích thước phông chữ cho một mục chú giải riêng lẻ**
Aspose.Slides cho .NET cho phép các nhà phát triển thiết lập kích thước phông chữ cho các mục chú giải riêng lẻ. Vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp `Presentation`.
- Tạo biểu đồ mặc định.
- Truy cập mục chú giải.
- Đặt kích thước phông chữ.
- Đặt giá trị trục tối thiểu.
- Đặt giá trị trục tối đa.
- Ghi bản trình bày ra đĩa.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartTextFormat tf = chart.Legend.Entries[1].TextFormat;

	tf.PortionFormat.FontBold = NullableBool.True;
	tf.PortionFormat.FontHeight = 20;
	tf.PortionFormat.FontItalic = NullableBool.True;
	tf.PortionFormat.FillFormat.FillType = FillType.Solid; ;
	tf.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Liệu tôi có thể bật chú giải để biểu đồ tự động dành không gian cho nó thay vì chồng lên không?**

Có. Sử dụng chế độ không chồng lên ([Overlay](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/legend/overlay/) = `false`); trong trường hợp này, khu vực vẽ sẽ thu nhỏ để nhường chỗ cho chú giải.

**Tôi có thể tạo nhãn chú giải đa dòng không?**

Có. Nhãn dài sẽ tự động xuống dòng khi không đủ không gian; việc chèn ngắt dòng bắt buộc được hỗ trợ bằng ký tự xuống dòng trong tên series.

**Làm thế nào để chú giải tuân theo bảng màu của chủ đề bản trình bày?**

Không đặt màu sắc/nền/phông chữ cụ thể cho chú giải hoặc văn bản của nó. Khi đó chúng sẽ kế thừa từ chủ đề và sẽ cập nhật đúng khi thiết kế thay đổi.