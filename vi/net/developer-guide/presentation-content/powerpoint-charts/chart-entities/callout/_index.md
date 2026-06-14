---
title: Quản lý Callout trong biểu đồ bài thuyết trình trên .NET
linktitle: Gọi chú
type: docs
url: /vi/net/callout/
keywords:
- callout biểu đồ
- sử dụng callout
- nhãn dữ liệu
- định dạng nhãn
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tạo và định dạng callout trong Aspose.Slides cho .NET bằng các ví dụ mã C# ngắn gọn, tương thích với PPT và PPTX để tự động hoá quy trình làm việc với bài thuyết trình."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với callout cho nhãn dữ liệu biểu đồ trong Aspose.Slides. Nó cho thấy cách sử dụng thuộc tính `ShowLabelAsDataCallout` để hiển thị nhãn dưới dạng callout, cách cấu hình các cài đặt nhãn liên quan đến callout cho biểu đồ bánh donut, và lưu ý rằng callout và giao diện của chúng được bảo lưu khi bản trình chiếu được xuất ra PDF, HTML5, SVG và các định dạng ảnh raster.

## **Sử dụng Callout**
Thuộc tính mới **ShowLabelAsDataCallout** đã được thêm vào lớp **DataLabelFormat** và giao diện **IDataLabelFormat**, xác định liệu nhãn dữ liệu của biểu đồ được chỉ định sẽ được hiển thị dưới dạng callout hay là nhãn dữ liệu. Trong ví dụ dưới đây, chúng tôi đã thiết lập Callout.

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
    chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;
    presentation.Save("DisplayChartLabels_out.pptx", SaveFormat.Pptx);
}
```



## **Đặt Callout cho Biểu đồ Donut**
Aspose.Slides for .NET cung cấp hỗ trợ để đặt hình dạng callout cho nhãn dữ liệu series trên biểu đồ Donut. Dưới đây là ví dụ mẫu.

```c#
Presentation pres = new Presentation("testc.pptx");
ISlide slide = pres.Slides[0];
IChart chart = slide.Shapes.AddChart(ChartType.Doughnut, 10, 10, 500, 500, false);
IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
chart.HasLegend = false;
int seriesIndex = 0;
while (seriesIndex < 15)
{
	IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.Type);
	series.Explosion = 0;
	series.ParentSeriesGroup.DoughnutHoleSize = (byte)20;
	series.ParentSeriesGroup.FirstSliceAngle = 351;
	seriesIndex++;
}
int categoryIndex = 0;
while (categoryIndex < 15)
{
	chart.ChartData.Categories.Add(workBook.GetCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
	int i = 0;
	while (i < chart.ChartData.Series.Count)
	{
		IChartSeries iCS = chart.ChartData.Series[i];
		IChartDataPoint dataPoint = iCS.DataPoints.AddDataPointForDoughnutSeries(workBook.GetCell(0, categoryIndex + 1, i + 1, 1));
		dataPoint.Format.Fill.FillType = FillType.Solid;
		dataPoint.Format.Line.FillFormat.FillType = FillType.Solid;
		dataPoint.Format.Line.FillFormat.SolidFillColor.Color = Color.White;
		dataPoint.Format.Line.Width = 1;
		dataPoint.Format.Line.Style = LineStyle.Single;
		dataPoint.Format.Line.DashStyle = LineDashStyle.Solid;
		if (i == chart.ChartData.Series.Count - 1)
		{
			IDataLabel lbl = dataPoint.Label;
			lbl.TextFormat.TextBlockFormat.AutofitType = TextAutofitType.Shape;
			lbl.DataLabelFormat.TextFormat.PortionFormat.FontBold = NullableBool.True;
			lbl.DataLabelFormat.TextFormat.PortionFormat.LatinFont = new FontData("DINPro-Bold");
			lbl.DataLabelFormat.TextFormat.PortionFormat.FontHeight = 12;
			lbl.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
			lbl.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.LightGray;
			lbl.DataLabelFormat.Format.Line.FillFormat.SolidFillColor.Color = Color.White;
			lbl.DataLabelFormat.ShowValue = false;
			lbl.DataLabelFormat.ShowCategoryName = true;
			lbl.DataLabelFormat.ShowSeriesName = false;
			//lbl.DataLabelFormat.ShowLabelAsDataCallout = true;
			lbl.DataLabelFormat.ShowLeaderLines = true;
			lbl.DataLabelFormat.ShowLabelAsDataCallout = false;
			chart.ValidateChartLayout();
			lbl.AsILayoutable.X = (float)lbl.AsILayoutable.X + (float)0.5;
			lbl.AsILayoutable.Y = (float)lbl.AsILayoutable.Y + (float)0.5;
		}
		i++;
	}
	categoryIndex++;
}
pres.Save("chart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**Callout có được bảo lưu khi chuyển đổi bản trình chiếu sang PDF, HTML5, SVG hoặc ảnh không?**

Có. Callout là một phần của việc render biểu đồ, vì vậy khi bạn xuất ra [PDF](/slides/vi/net/convert-powerpoint-to-pdf/), [HTML5](/slides/vi/net/export-to-html5/), [SVG](/slides/vi/net/render-a-slide-as-an-svg-image/), hoặc [hình ảnh raster](/slides/vi/net/convert-powerpoint-to-png/), chúng sẽ được bảo lưu cùng với định dạng của slide.

**Phông chữ tùy chỉnh có hoạt động trong callout không, và giao diện của chúng có được bảo lưu khi xuất không?**

Có. Aspose.Slides hỗ trợ [nhúng phông chữ](/slides/vi/net/embedded-font/) vào bản trình chiếu và kiểm soát việc nhúng phông chữ trong các xuất như [PDF](/slides/vi/net/convert-powerpoint-to-pdf/), đảm bảo callout hiển thị giống nhau trên các hệ thống khác nhau.