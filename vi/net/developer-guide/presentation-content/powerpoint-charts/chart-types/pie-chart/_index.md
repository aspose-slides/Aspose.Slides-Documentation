---
title: Tùy chỉnh biểu đồ tròn trong bản trình bày .NET
linktitle: Biểu đồ tròn
type: docs
url: /vi/net/pie-chart/
keywords:
- biểu đồ tròn
- quản lý biểu đồ
- tùy chỉnh biểu đồ
- các tùy chọn biểu đồ
- cài đặt biểu đồ
- các tùy chọn vẽ
- màu lá
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách tạo và tùy chỉnh biểu đồ tròn trong .NET với Aspose.Slides, có thể xuất ra PowerPoint, nâng cao kể chuyện dữ liệu của bạn trong vài giây."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với biểu đồ tròn trong Aspose.Slides. Nó chỉ ra cách cấu hình tùy chọn biểu đồ phụ cho biểu đồ Pie of Pie và Bar of Pie, và cách bật tự động tô màu các lát cho biểu đồ tròn tiêu chuẩn.

Các ví dụ tập trung vào các bước tùy chỉnh biểu đồ thực tế như thêm biểu đồ vào slide, điều chỉnh cài đặt chuỗi và nhãn, thay thế dữ liệu biểu đồ mặc định bằng các danh mục và giá trị tùy chỉnh, và lưu bản trình bày đã cập nhật.

## **Tùy chọn biểu đồ phụ cho Pie of Pie và Bar of Pie**

Aspose.Slides cho .NET hiện hỗ trợ tùy chọn biểu đồ phụ cho biểu đồ Pie of Pie hoặc Bar of Pie. Trong chủ đề này, chúng ta sẽ xem qua ví dụ cách chỉ định các tùy chọn này bằng Aspose.Slides. Để chỉ định các thuộc tính, vui lòng thực hiện các bước sau:

1. Tạo một đối tượng lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Thêm biểu đồ vào slide.
1. Chỉ định tùy chọn biểu đồ phụ cho biểu đồ.
1. Ghi bản trình bày ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã thiết lập các thuộc tính khác nhau của biểu đồ Pie of Pie.

```c#
 // Create an instance of Presentation class
Presentation presentation = new Presentation();

// Add chart on slide
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// Set different properties
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// Write presentation to disk
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```

## **Đặt màu tự động cho các lát của biểu đồ tròn**

Aspose.Slides cho .NET cung cấp API đơn giản để đặt màu tự động cho các lát của biểu đồ tròn. Mã mẫu áp dụng các cài đặt thuộc tính đã nêu ở trên.

1. Tạo một instance của lớp Presentation.
1. Truy cập slide đầu tiên.
1. Thêm biểu đồ với dữ liệu mặc định.
1. Đặt tiêu đề cho biểu đồ.
1. Đặt series đầu tiên hiển thị giá trị.
1. Đặt chỉ mục của bảng dữ liệu biểu đồ.
1. Lấy worksheet dữ liệu biểu đồ.
1. Xóa series và danh mục được tạo mặc định.
1. Thêm danh mục mới.
1. Thêm series mới.

Ghi bản trình bày đã chỉnh sửa vào tệp PPTX.

```c#
 // Khởi tạo lớp Presentation đại diện cho tệp PPTX
using (Presentation presentation = new Presentation())
{
	// Khởi tạo lớp Presentation đại diện cho tệp PPTX
	Presentation presentation = new Presentation();

	// Truy cập slide đầu tiên
	ISlide slides = presentation.Slides[0];

	// Thêm biểu đồ với dữ liệu mặc định
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// Đặt tiêu đề biểu đồ
	chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// Đặt series đầu tiên hiển thị giá trị
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// Đặt chỉ mục của bảng dữ liệu biểu đồ
	int defaultWorksheetIndex = 0;

	// Lấy worksheet dữ liệu biểu đồ
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// Xóa series và danh mục được tạo mặc định
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// Thêm danh mục mới
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "First Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2nd Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3rd Qtr"));

	// Thêm series mới
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);

	// Bây giờ điền dữ liệu cho series
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**Các biến thể 'Pie of Pie' và 'Bar of Pie' có được hỗ trợ không?**

Có, thư viện [hỗ trợ](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/charttype/) biểu đồ phụ cho các biểu đồ tròn, bao gồm các loại 'Pie of Pie' và 'Bar of Pie'.

**Tôi có thể xuất chỉ biểu đồ dưới dạng hình ảnh (ví dụ, PNG) không?**

Có, bạn có thể [xuất biểu đồ dưới dạng hình ảnh](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/getimage/) (ví dụ PNG) mà không cần xuất toàn bộ bản trình bày.