---
title: Cách tạo biểu đồ trong bản trình chiếu trong .NET
linktitle: Tạo biểu đồ
type: docs
weight: 30
url: /vi/net/how-to-create-charts-in-a-presentation/
keywords:
- di chuyển
- tạo biểu đồ
- mã legacy
- mã hiện đại
- cách tiếp cận legacy
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách tạo biểu đồ trong các bản trình chiếu PowerPoint PPT, PPTX và ODP trong .NET với Aspose.Slides bằng cả hai API biểu đồ legacy và hiện đại."
---
{{% alert color="info" %}} 
Một phiên bản mới của [Aspose.Slides for .NET API](/slides/vi/net/) đã được phát hành và hiện nay sản phẩm duy nhất này hỗ trợ khả năng tạo tài liệu PowerPoint từ đầu và chỉnh sửa các tài liệu hiện có.
{{% /alert %}} 
## **Hỗ trợ mã Legacy**
Để sử dụng mã legacy được phát triển với các phiên bản Aspose.Slides for .NET trước 13.x, bạn cần thực hiện một số thay đổi nhỏ trong mã của mình và mã sẽ hoạt động như trước. Tất cả các lớp đã có trong Aspose.Slides for .NET cũ dưới các không gian tên Aspose.Slide và Aspose.Slides.Pptx hiện đã được hợp nhất thành một không gian tên Aspose.Slides duy nhất. Vui lòng xem đoạn mã mẫu đơn giản sau để tạo biểu đồ thường từ đầu trong bản trình chiếu bằng API Aspose.Slides legacy và làm theo các bước mô tả cách di chuyển sang API hợp nhất mới.
## **Legacy Aspose.Slides for .NET Approach**
```c#
using System.Drawing;

//Khởi tạo lớp PresentationEx đại diện cho file PPTX
using (PresentationEx pres = new PresentationEx())
{
	//Truy cập slide đầu tiên
	SlideEx sld = pres.Slides[0];

	// Thêm biểu đồ với dữ liệu mặc định
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//Đặt tiêu đề biểu đồ
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//Đặt series đầu tiên để hiển thị giá trị
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//Đặt chỉ mục của sheet dữ liệu biểu đồ
	int defaultWorksheetIndex = 0;

	//Lấy worksheet dữ liệu biểu đồ
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//Xóa series và danh mục được tạo mặc định
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//Thêm series mới
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	//Thêm danh mục mới
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	//Lấy series biểu đồ đầu tiên
	ChartSeriesEx series = chart.ChartData.Series[0];

	//Bây giờ đang điền dữ liệu cho series
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//Đặt màu nền cho series
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//Lấy series biểu đồ thứ hai
	series = chart.ChartData.Series[1];

	//Bây giờ đang điền dữ liệu cho series
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//Đặt màu nền cho series
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//Tạo nhãn tùy chỉnh cho mỗi danh mục cho series mới

	//Nhãn đầu tiên sẽ hiển thị tên danh mục
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//Hiển thị tên series cho nhãn thứ hai
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//Hiển thị giá trị cho nhãn thứ ba
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//Hiển thị giá trị và văn bản tùy chỉnh
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "My text";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//Lưu bản trình chiếu kèm biểu đồ
	pres.Write(@"D:\AsposeChart.pptx");
}
```

## **New Aspose.Slides for .NET 13.x Approach**
``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

//Khởi tạo lớp Presentation đại diện cho file PPTX file//Khởi tạo lớp Presentation đại diện cho file PPTX file
Presentation pres = new Presentation();

//Truy cập slide đầu tiên
ISlide sld = pres.Slides[0];

// Thêm biểu đồ với dữ liệu mặc định
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//Đặt tiêu đề biểu đồ
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//Đặt chỉ mục của sheet dữ liệu biểu đồ
int defaultWorksheetIndex = 0;

//Lấy worksheet dữ liệu biểu đồ
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Xóa series và danh mục được tạo mặc định
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//Thêm series mới
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//Đặt series đầu tiên để hiển thị giá trị
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//Thêm danh mục mới
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//Lấy series biểu đồ đầu tiên
IChartSeries series = chart.ChartData.Series[0];

//Bây giờ đang điền dữ liệu cho series

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//Đặt màu nền cho series
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//Lấy series biểu đồ thứ hai
series = chart.ChartData.Series[1];

//Bây giờ đang điền dữ liệu cho series
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Đặt màu nền cho series
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//Tạo nhãn tùy chỉnh cho mỗi danh mục cho series mới

//Nhãn đầu tiên sẽ hiển thị tên danh mục
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//Hiển thị giá trị cho nhãn thứ ba
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//Lưu bản trình chiếu kèm biểu đồ
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Vui lòng xem đoạn mã mẫu đơn giản sau để tạo biểu đồ phân tán từ đầu trong bản trình chiếu bằng API Aspose.Slides legacy và cách thực hiện nó với API hợp nhất mới.
## **Legacy Aspose.Slides for .NET Approach**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //Tạo biểu đồ mặc định
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //Lấy chỉ mục worksheet dữ liệu biểu đồ mặc định
    int defaultWorksheetIndex = 0;

    //Truy cập worksheet dữ liệu biểu đồ
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //Xóa series demo
    chart.ChartData.Series.Clear();

    //Thêm series mới
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //Lấy series biểu đồ đầu tiên
    ChartSeriesEx series = chart.ChartData.Series[0];

    //Thêm điểm mới (1:3) ở đó.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //Thêm điểm mới (2:10)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //Chỉnh sửa loại series
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //Thay đổi marker của series biểu đồ
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //Lấy series biểu đồ thứ hai
    series = chart.ChartData.Series[1];

    //Thêm điểm mới (5:2) ở đó.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //Thêm điểm mới (3:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //Thêm điểm mới (2:2)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //Thêm điểm mới (5:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //Thay đổi marker của series biểu đồ
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```

## **New Aspose.Slides for .NET 13.x Approach**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//Tạo biểu đồ mặc định
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//Lấy chỉ mục worksheet dữ liệu biểu đồ mặc định
int defaultWorksheetIndex = 0;

//Truy cập worksheet dữ liệu biểu đồ
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Xóa series demo
chart.ChartData.Series.Clear();

//Thêm series mới
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//Lấy series biểu đồ đầu tiên
IChartSeries series = chart.ChartData.Series[0];

//Thêm điểm mới (1:3) ở đây.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//Thêm điểm mới (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//Chỉnh sửa loại series
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//Thay đổi marker của series biểu đồ
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//Lấy series biểu đồ thứ hai
series = chart.ChartData.Series[1];

//Thêm điểm mới (5:2) ở đây.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//Thêm điểm mới (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//Thêm điểm mới (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//Thêm điểm mới (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//Thay đổi marker của series biểu đồ
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```