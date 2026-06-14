---
title: Cách Tạo Biểu Đồ trong Bản Trình Chiếu bằng .NET
linktitle: Tạo Biểu Đồ
type: docs
weight: 30
url: /vi/net/how-to-create-charts-in-a-presentation/
keywords:
- di chuyển
- tạo biểu đồ
- mã legacy
- mã hiện đại
- phương pháp legacy
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách tạo biểu đồ trong các bản trình chiếu PowerPoint PPT, PPTX và ODP bằng .NET với Aspose.Slides sử dụng cả API biểu đồ legacy và hiện đại."
---
{{% alert color="primary" %}} 
Một API [Aspose.Slides for .NET API](/slides/vi/net/) mới đã được phát hành và giờ sản phẩm duy nhất này hỗ trợ khả năng tạo tài liệu PowerPoint từ đầu và chỉnh sửa các tài liệu hiện có.
{{% /alert %}} 
## **Hỗ trợ cho Mã Legacy**
Để sử dụng mã legacy được phát triển với các phiên bản Aspose.Slides cho .NET trước 13.x, bạn cần thực hiện một số thay đổi nhỏ trong mã của mình và mã sẽ hoạt động như trước. Tất cả các lớp từng có trong Aspose.Slides cho .NET cũ dưới các namespace Aspose.Slide và Aspose.Slides.Pptx hiện đã được hợp nhất trong một namespace Aspose.Slides duy nhất. Vui lòng xem đoạn mã mẫu đơn giản dưới đây để tạo biểu đồ thường từ đầu trong bản trình chiếu bằng API Aspose.Slides legacy và làm theo các bước mô tả cách di chuyển sang API hợp nhất mới.
## **Cách Tiếp Cận Legacy Aspose.Slides cho .NET**
```c#
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

	//Bây giờ điền dữ liệu cho series
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//Đặt màu nền cho series
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//Lấy series biểu đồ thứ hai
	series = chart.ChartData.Series[1];

	//Bây giờ điền dữ liệu cho series
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//Đặt màu nền cho series
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//tạo nhãn tùy chỉnh cho mỗi danh mục cho series mới

	//nhãn đầu tiên sẽ hiển thị tên danh mục
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

	//Lưu bản trình chiếu với biểu đồ
	pres.Write(@"D:\AsposeChart.pptx");
}
```



## **Cách Tiếp Cận Mới Aspose.Slides cho .NET 13.x**
``` csharp
//Khởi tạo lớp Presentation đại diện cho file PPTX
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

//Đặt series đầu tiên để hiển thị giá trị
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

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

//Thêm danh mục mới
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//Lấy series biểu đồ đầu tiên
IChartSeries series = chart.ChartData.Series[0];

//Bây giờ điền dữ liệu cho series

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//Đặt màu nền cho series
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//Lấy series biểu đồ thứ hai
series = chart.ChartData.Series[1];

//Bây giờ điền dữ liệu cho series
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Đặt màu nền cho series
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//tạo nhãn tùy chỉnh cho mỗi danh mục cho series mới

//nhãn đầu tiên sẽ hiển thị tên danh mục
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//Hiển thị giá trị cho nhãn thứ ba
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//Lưu bản trình chiếu với biểu đồ
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```
Vui lòng xem đoạn mã mẫu đơn giản dưới đây để tạo biểu đồ phân tán từ đầu trong bản trình chiếu bằng API Aspose.Slides legacy và cách thực hiện nó với API hợp nhất mới.
## **Cách Tiếp Cận Legacy Aspose.Slides cho .NET**
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

    //Xóa series mẫu
    chart.ChartData.Series.Clear();

    //Thêm series mới
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //Lấy series biểu đồ đầu tiên
    ChartSeriesEx series = chart.ChartData.Series[0];

    //Thêm điểm mới (1:3) vào đó.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //Thêm điểm mới (2:10)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //Chỉnh sửa kiểu của series
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //Thay đổi dấu hiệu của series biểu đồ
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //Lấy series biểu đồ thứ hai
    series = chart.ChartData.Series[1];

    //Thêm điểm mới (5:2) vào đó.
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

    //Thay đổi dấu hiệu của series biểu đồ
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```


## **Cách Tiếp Cận Mới Aspose.Slides cho .NET 13.x**
``` csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//Tạo biểu đồ mặc định
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//Lấy chỉ mục worksheet dữ liệu biểu đồ mặc định
int defaultWorksheetIndex = 0;

//Truy cập worksheet dữ liệu biểu đồ
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Xóa series mẫu
chart.ChartData.Series.Clear();

//Thêm series mới
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//Lấy series biểu đồ đầu tiên
IChartSeries series = chart.ChartData.Series[0];

//Thêm điểm mới (1:3) vào đó.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//Thêm điểm mới (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//Chỉnh sửa kiểu của series
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//Thay đổi dấu hiệu của series biểu đồ
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//Lấy series biểu đồ thứ hai
series = chart.ChartData.Series[1];

//Thêm điểm mới (5:2) vào đó.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//Thêm điểm mới (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//Thêm điểm mới (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//Thêm điểm mới (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//Thay đổi dấu hiệu của series biểu đồ
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```