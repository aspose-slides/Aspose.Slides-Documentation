---
title: Quản lý Series Dữ liệu Biểu đồ trong Bản trình bày bằng .NET
linktitle: Series Dữ liệu
type: docs
url: /vi/net/chart-series/
keywords:
- series biểu đồ
- overlap series
- màu series
- màu danh mục
- tên series
- điểm dữ liệu
- khoảng cách series
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách quản lý series biểu đồ, điểm dữ liệu, ô workbook, định dạng, overlap, độ rộng khoảng cách và giá trị âm trong bản trình bày với C#."
---
## **Tổng quan**

Biểu đồ lưu trữ dữ liệu đã vẽ của nó trong một workbook dữ liệu biểu đồ. Một [IChartSeries](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseries/) đại diện cho một tập hợp các giá trị liên quan, và mỗi [IChartDataPoint](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatapoint/) trong series tham chiếu tới một hoặc nhiều ô trong workbook. Các đối tượng [IChartCategory](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartcategory/) cung cấp các nhãn hoặc giá trị nhóm được chia sẻ bởi các series. Vì vậy, tên series, các danh mục và giá trị điểm đều được kết nối tới các đối tượng [IChartDataCell](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/), thay vì chỉ được lưu dưới dạng văn bản hiển thị.

Đối với một biểu đồ loại danh mục tiêu chuẩn, workbook mặc định sử dụng hàng 0 cho tên series, cột 0 cho tên danh mục, và các ô còn lại cho các giá trị series. Các chỉ mục worksheet, hàng và cột được truyền cho [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/getcell/) là chỉ mục bắt đầu từ 0. Bố cục này hữu ích khi bạn tạo biểu đồ với dữ liệu mặc định, nhưng không nên giả định rằng mọi biểu đồ hiện có đều sử dụng nó. Đối với một bản trình bày đã tải, hãy kiểm tra các ô mà các series, danh mục và điểm dữ liệu tham chiếu trước khi thay đổi giá trị workbook.

Cài đặt biểu đồ có ba phạm vi khác nhau:

- Cài đặt cấp series, chẳng hạn như [IChartSeries.Format](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseries/format/), cung cấp giao diện mặc định cho tất cả các điểm trong một series.
- Cài đặt cấp điểm dữ liệu, chẳng hạn như [IChartDataPoint.Format](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatapoint/format/), ghi đè giao diện của series cho một điểm.
- Cài đặt nhóm áp dụng cho các series tương thích thuộc cùng một [IChartSeriesGroup](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseriesgroup/). Truy cập nhóm qua [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseries/parentseriesgroup/) khi bạn cần thiết lập các tùy chọn như overlap hoặc gap width.

Khi không có màu nền điểm hoặc series nào được đặt rõ ràng, kiểu biểu đồ và chủ đề sẽ quyết định giao diện tự động. Khi cả định dạng series và điểm đều tồn tại, định dạng điểm sẽ được ưu tiên cho điểm đó.

![Biểu đồ series trong PowerPoint](chart-series-powerpoint.png)

## **Đặt Overlap cho Series Biểu đồ**

[IChartSeries.Overlap](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseries/overlap/) báo cáo mức độ các thanh hoặc cột chồng lên nhau trong một biểu đồ 2D, từ -100 đến 100 phần trăm. Đây là một phép chiếu chỉ đọc của cài đặt trên nhóm series cha. Đặt [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseriesgroup/overlap/) để cập nhật mọi series tương thích trong nhóm đó. Tùy chọn này áp dụng cho các loại biểu đồ hiển thị các thanh hoặc cột nhóm; nó không ảnh hưởng tới các nhóm series không liên quan trong biểu đồ kết hợp.

Ví dụ sau đặt overlap cho nhóm chứa series đầu tiên:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// Biểu đồ mới chứa các series mẫu, danh mục và giá trị.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

Kết quả:

![Overlap của series](series_overlap.png)

## **Thay đổi màu nền của Series**

Sử dụng [IChartSeries.Format](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseries/format/) để đặt màu nền mặc định cho toàn bộ một series. Nếu một điểm đã có màu nền rõ ràng, cài đặt [IChartDataPoint.Format](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatapoint/format/) của nó sẽ ghi đè màu nền của series cho điểm đó.

Ví dụ sau áp dụng màu xanh đậm đặc cho series đầu tiên:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Blue;

presentation.Save("series_color.pptx", SaveFormat.Pptx);
```

Kết quả:

![Màu của series](series_color.png)

## **Thay đổi tên Series**

Tên một series được lưu trong workbook dữ liệu biểu đồ và thường được hiển thị trong chú giải. Trong workbook mặc định được tạo cho một biểu đồ cột cụm, ô B1 nằm ở hàng 0, cột 1 và chứa tên của series đầu tiên. Các hằng số được đặt tên trong ví dụ sau làm rõ cấu trúc này:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesNameCell = workbook.GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

Bạn cũng có thể cập nhật ô đã được tham chiếu bởi [IChartSeries.Name](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseries/name/). Cách này tránh việc giả định một hàng và cột cụ thể trong một biểu đồ đã tồn tại:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var seriesNameCell = series.Name.AsCells[firstNameCellIndex];
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

Kết quả:

![Tên series](series_name.png)

## **Lấy màu nền tự động cho Series**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) trả về màu được tính dựa trên chỉ số series và kiểu biểu đồ. Đây là màu được sử dụng khi màu nền của series chưa được định nghĩa rõ ràng. Gọi phương thức này chỉ đọc màu đã tính; nó không gán màu mới.

Ví dụ sau in ra màu tự động của mỗi series mặc định:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

const int firstSlideIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var seriesCount = chart.ChartData.Series.Count;
for (var seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    var automaticColor = series.GetAutomaticSeriesColor();
    Console.WriteLine($"Series {seriesIndex}: {automaticColor.Name}");
}
```

Đầu ra mẫu cho kiểu biểu đồ mặc định:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Màu chính xác phụ thuộc vào kiểu biểu đồ và chủ đề.

## **Đặt màu nền đảo ngược cho Series Biểu đồ**

Đối với series thanh, cột và bong bóng, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseries/invertifnegative/) có thể hiển thị các giá trị âm bằng một màu nền khác. Đặt màu nền series thường thành dạng đặc, bật chế độ đảo, và gán màu giá trị âm qua [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Các số âm vẫn giữ nguyên trong workbook; chỉ màu hiển thị của chúng thay đổi.

Ví dụ sau thay thế dữ liệu biểu đồ mặc định bằng một series. Hàng 0 của worksheet chứa tên series, cột 0 chứa tên danh mục, và cột 1 chứa các giá trị:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;

var categoryNames = new[] { "Category 1", "Category 2", "Category 3" };
var seriesValues = new[] { -20, 50, -30 };

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
var series = chartData.Series.Add(seriesNameCell, chart.Type);

for (var categoryIndex = 0; categoryIndex < categoryNames.Length; categoryIndex++)
{
    var dataRowIndex = firstDataRowIndex + categoryIndex;
    var categoryName = categoryNames[categoryIndex];
    var seriesValue = seriesValues[categoryIndex];

    var categoryCell = workbook.GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
    chartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertIfNegative = true;
series.InvertedSolidFillColor.Color = Color.Red;

presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
```

Kết quả:

![Màu nền rắn đảo ngược](inverted_solid_fill_color.png)

Bạn có thể bật đảo cho một điểm thông qua [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Trong ví dụ sau, đảo được tắt cho series và chỉ bật cho điểm đã chọn. Điểm này cũng được gán một giá trị âm để hiệu ứng hiển thị:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertedSolidFillColor.Color = Color.Red;
series.InvertIfNegative = false;

var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = negativeValue;
dataPoint.InvertIfNegative = true;

presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
```

## **Xóa giá trị điểm dữ liệu cụ thể**

Để làm cho một điểm trống mà không xóa các điểm khác, đặt ô workbook hỗ trợ của nó thành `null`. Đối với biểu đồ cột, giá trị đã vẽ có thể truy cập qua [IChartDataPoint.YValue](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatapoint/yvalue/). Điểm dữ liệu vẫn ở vị trí danh mục cũ, nhưng biểu đồ sẽ xem giá trị của nó là trống theo cài đặt giá trị trống của biểu đồ.

Ví dụ sau chỉ xóa điểm thứ hai trong series đầu tiên:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = null;

presentation.Save("clear_data_point_value.pptx", SaveFormat.Pptx);
```

Biểu đồ phân tán sử dụng các ô X và Y riêng biệt, và biểu đồ bong bóng cũng sử dụng ô kích thước. Chỉ xóa ô đại diện cho giá trị bạn muốn loại bỏ. Không gọi [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatapointcollection/clear/) khi bạn muốn giữ các điểm còn lại, vì phương thức đó sẽ xóa mọi điểm dữ liệu trong bộ sưu tập.

## **Kiểm soát hiển thị các ô trống**

Các ô ẩn chứa giá trị là một trường hợp riêng so với các ô trống. Để bao gồm hoặc loại trừ dữ liệu từ các hàng và cột worksheet ẩn, xem [Include Data from Hidden Rows and Columns](/slides/vi/net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Một ô workbook trống đại diện cho dữ liệu thiếu; một ô chứa `0` đại diện cho một giá trị số đã biết. Đặt [IChartDataCell.Value](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/value/) thành `null` để làm ô trống. Số không vẫn giữ là số không bất kể cài đặt ô trống.

Sử dụng [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichart/displayblanksas/) để chọn cách biểu đồ hiển thị các ô trống. Cài đặt này áp dụng cho toàn bộ biểu đồ. Nó thay đổi cách các khoảng trống được vẽ, mà không lấp đầy ô workbook trống bằng số 0 hoặc giá trị nội suy.

Ví dụ tự chứa sau tạo một biểu đồ đường với một series, xóa giá trị cho Ngày 3, và lưu cùng một biểu đồ với từng chế độ. Không cần tệp đầu vào. [IChartDataWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/) sử dụng worksheet 0, cột 0 cho nhãn danh mục, và cột 1 cho giá trị; hàng 0 giữ tên series. Dữ liệu cuối cùng là `10, 20, empty, 30, 40`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(0, 0, 1, "Measurements");
var series = chartData.Series.Add(seriesNameCell, chart.Type);
var values = new[] { 10, 20, 25, 30, 40 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Day {i + 1}");
    chartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Leave Day 3 genuinely empty, while retaining its category and data point.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

Mỗi tệp đầu ra lưu chế độ được gán trước khi lưu: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, và `empty_cells_Span.pptx`. Để lưu chỉ một phiên bản, gán chế độ mong muốn và lưu bản trình bày một lần thay vì lặp qua các chế độ.

So sánh dưới đây cho thấy cùng một dữ liệu trong ba tệp. Ngày 3 là trống trong workbook trong mọi trường hợp:

![Biểu đồ đường với dữ liệu giống nhau: Gap ngắt đường tại Ngày 3, Zero hạ đường xuống 0, và Span kết nối Ngày 2 tới Ngày 4.](display_blanks_as.png)

Hiệu ứng hiển thị phụ thuộc vào loại biểu đồ. Một biểu đồ đường dễ dàng so sánh ba chế độ. Các biểu đồ thanh và cột không có đường nối qua danh mục thiếu, vì vậy `Span` không thể tạo đoạn nối như trên; một cột thiếu và một cột có chiều cao zero cũng có thể trông giống nhau. Tương tự, một biểu đồ phân tán chỉ có dấu hiệu không có đường nối. Đừng mong đợi ba kết quả riêng biệt cho mọi loại biểu đồ; hãy kiểm tra kết quả cho loại bạn đang sử dụng.

## **Đặt độ rộng khoảng cách giữa các Series**

Độ rộng khoảng cách là khoảng cách giữa các cụm thanh hoặc cột kề nhau, được biểu thị dưới dạng phần trăm của độ rộng thanh hoặc cột. Giống như overlap, nó thuộc về nhóm series cha chứ không phải một series riêng. Đặt [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) một lần cho nhóm. Giá trị lớn hơn tạo không gian rộng hơn giữa các cụm; giá trị nhỏ hơn làm chúng dày đặc hơn.

Ví dụ sau thay đổi độ rộng khoảng cách và chỉ lưu bản trình bày cuối cùng:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int gapWidthPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.GapWidth = gapWidthPercent;

presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
```

Kết quả:

![Độ rộng khoảng cách](gap_width.png)

## **FAQ**

**Loại biểu đồ nào hỗ trợ series dữ liệu?**

Tất cả các loại biểu đồ được đại diện bởi enumeration [ChartType](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/charttype/) đều sử dụng dữ liệu biểu đồ, nhưng series của chúng không phải đều có cùng cấu trúc giá trị hoặc cài đặt. Ví dụ, biểu đồ danh mục sử dụng danh mục và giá trị, biểu đồ phân tán sử dụng giá trị X và Y, và biểu đồ bong bóng thêm kích thước bong bóng. Sử dụng phương pháp tạo điểm dữ liệu phù hợp với loại series. Các tùy chọn như overlap và gap width chỉ áp dụng cho các nhóm thanh hoặc cột tương thích.

**Nhóm series biểu đồ là gì?**

Một [IChartSeriesGroup](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseriesgroup/) chứa các series tương thích chia sẻ cài đặt vẽ mức nhóm. Một biểu đồ kết hợp có thể chứa nhiều hơn một nhóm, vì vậy việc thay đổi nhóm thông qua một series không nhất thiết thay đổi mọi series trong biểu đồ.

**Biểu đồ mới tạo có chứa dữ liệu mặc định không?**

Có. Mặc định, [IShapeCollection.AddChart](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/addchart/) tạo các series mẫu, danh mục và giá trị. Bạn có thể chỉnh sửa các ô đó hoặc xóa cả các bộ sưu tập series và danh mục trước khi thêm một bộ dữ liệu tùy chỉnh hoàn toàn. Một overload cũng có thể tạo biểu đồ không có dữ liệu mặc định.

**Các đối tượng biểu đồ được kết nối với các ô workbook như thế nào?**

Tên series, nhãn danh mục và giá trị điểm dữ liệu tham chiếu tới các ô trong một [IChartDataWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/). Thay đổi một ô được tham chiếu sẽ cập nhật phần tử biểu đồ tương ứng. Khi bạn xây dựng dữ liệu tùy chỉnh, hãy giữ các hàng danh mục và các hàng giá trị series đồng bộ để mỗi điểm được vẽ dưới danh mục dự định.

**Làm sao để xóa một điểm thay vì toàn bộ series?**

Đặt ô giá trị liên quan thành `null` để giữ vị trí danh mục của điểm như một điểm trống. Chỉ sử dụng [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatapointcollection/clear/) khi bạn muốn xóa tất cả các điểm khỏi series đó. Nếu bạn cũng xóa các danh mục, hãy cập nhật mọi series sao cho giá trị của chúng vẫn đồng bộ với bộ sưu tập danh mục.

**Các điểm trống được hiển thị như thế nào?**

Kết quả phụ thuộc vào loại biểu đồ và [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichart/displayblanksas/). Các biểu đồ được hỗ trợ có thể hiển thị khoảng trống dưới dạng khoảng trống, giá trị zero, hoặc bằng cách nối các điểm lân cận. Chọn cài đặt phù hợp với ý nghĩa của dữ liệu thiếu trong bài thuyết trình của bạn. Xem [Control the Display of Empty Cells](#control-the-display-of-empty-cells) để có ví dụ đầy đủ và so sánh trực quan.

**Giá trị âm được định dạng như thế nào?**

Đối với các series thanh, cột và bong bóng được hỗ trợ, bật [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseries/invertifnegative/) và đặt [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Bạn có thể ghi đè hành vi cho một điểm riêng lẻ bằng [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Các thuộc tính này ảnh hưởng đến định dạng, không phải giá trị số lưu trữ.

**Định dạng nào được ưu tiên khi cả series và điểm đều được định dạng?**

Định dạng điểm dữ liệu cụ thể sẽ được ưu tiên cho điểm đó. Các điểm khác vẫn sẽ sử dụng định dạng series rõ ràng hoặc, nếu không có định dạng series, thì kiểu và chủ đề biểu đồ tự động. Các thuộc tính nhóm như overlap và gap width kiểm soát bố cục và không phải là ghi đè định dạng cấp điểm.

**Có giới hạn số lượng series mà một biểu đồ có thể chứa không?**

Aspose.Slides không áp đặt một giới hạn cố định cho số series. Trong thực tế, các ràng buộc của tệp trình bày, bộ nhớ có sẵn, thời gian render và độ đọc được của biểu đồ sẽ quyết định một giới hạn thực tế.

**Tôi nên thay đổi gì khi các cột quá gần nhau hoặc quá xa nhau?**

Đặt [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) trên nhóm series cha thích hợp. Tăng giá trị để làm rộng khoảng cách giữa các cụm, hoặc giảm để làm chúng gần nhau hơn.