---
title: Quản lý Dữ liệu Chuỗi Biểu đồ trong Bản trình bày bằng .NET
linktitle: Chuỗi Dữ liệu
type: docs
url: /vi/net/chart-series/
keywords:
- chuỗi biểu đồ
- chồng chuỗi
- màu chuỗi
- màu danh mục
- tên chuỗi
- điểm dữ liệu
- khoảng cách chuỗi
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách quản lý chuỗi biểu đồ, các điểm dữ liệu, các ô sổ làm việc, định dạng, chồng, độ rộng khoảng cách và các giá trị âm trong bản trình bày bằng C#."
---
## **Tổng quan**

Một biểu đồ lưu trữ dữ liệu đã vẽ trong một sổ làm việc dữ liệu biểu đồ. Một [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) đại diện cho một tập hợp các giá trị liên quan, và mỗi [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) trong chuỗi tham chiếu tới một hoặc nhiều ô trong sổ làm việc. Các đối tượng [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) cung cấp nhãn hoặc giá trị nhóm được chia sẻ bởi các chuỗi. Vì vậy, tên chuỗi, danh mục và giá trị điểm được kết nối với các đối tượng [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) thay vì chỉ được lưu dưới dạng văn bản hiển thị.

Đối với một biểu đồ danh mục điển hình, sổ làm việc mặc định sử dụng hàng 0 cho tên chuỗi, cột 0 cho tên danh mục và các ô còn lại cho giá trị chuỗi. Các chỉ mục worksheet, hàng và cột được truyền cho [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) là dựa trên chỉ số 0. Bố cục này hữu ích khi bạn tạo biểu đồ với dữ liệu mặc định, nhưng đừng giả định rằng mọi biểu đồ hiện có đều sử dụng nó. Đối với một bản trình bày đã tải, hãy kiểm tra các ô được chuỗi, danh mục và điểm dữ liệu tham chiếu trước khi thay đổi giá trị trong sổ làm việc.

Cài đặt biểu đồ có ba phạm vi khác nhau:

- Cài đặt cấp chuỗi, chẳng hạn như [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/), cung cấp giao diện mặc định cho tất cả các điểm trong một chuỗi.
- Cài đặt cấp điểm dữ liệu, chẳng hạn như [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/), ghi đè giao diện chuỗi cho một điểm.
- Cài đặt nhóm áp dụng cho các chuỗi tương thích thuộc cùng một [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/). Truy cập nhóm qua [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) khi bạn cần đặt các tùy chọn như độ chồng hoặc độ rộng khoảng cách.

Khi không có màu nền điểm hoặc chuỗi nào được đặt rõ ràng, kiểu biểu đồ và chủ đề sẽ quyết định giao diện tự động. Khi cả định dạng chuỗi và điểm đều tồn tại, định dạng điểm sẽ chiếm ưu tiên cho điểm đó.

![chuỗi biểu đồ PowerPoint](chart-series-powerpoint.png)

## **Đặt chồng chuỗi biểu đồ**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) báo cáo mức độ chồng của các thanh hoặc cột trong biểu đồ 2D, từ -100 đến 100 phần trăm. Đây là một phép chiếu chỉ đọc của cài đặt trên nhóm chuỗi cha. Đặt [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) để cập nhật mọi chuỗi tương thích trong nhóm đó. Tùy chọn này áp dụng cho các loại biểu đồ hiển thị các thanh hoặc cột được nhóm lại; nó không ảnh hưởng tới các nhóm chuỗi không liên quan trong biểu đồ kết hợp.

Ví dụ sau đặt chồng cho nhóm chứa chuỗi đầu tiên:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// Biểu đồ mới chứa các chuỗi mẫu, danh mục và giá trị.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

Kết quả:

![Chồng chuỗi](series_overlap.png)

## **Thay đổi màu nền chuỗi**

Sử dụng [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) để đặt màu nền mặc định cho toàn bộ chuỗi. Nếu một điểm đã có màu nền rõ ràng, cài đặt [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) của nó sẽ ghi đè màu nền chuỗi cho điểm đó.

Ví dụ sau áp dụng màu nền xanh đậm cho chuỗi đầu tiên:

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

![Màu của chuỗi](series_color.png)

## **Thay đổi tên chuỗi**

Tên chuỗi được lưu trong sổ làm việc dữ liệu biểu đồ và thường được hiển thị trong chú giải. Trong sổ làm việc mặc định được tạo cho biểu đồ cột nhóm, ô B1 nằm ở hàng 0, cột 1 và chứa tên của chuỗi đầu tiên. Các hằng số được đặt tên trong ví dụ sau làm cho cấu trúc này rõ ràng:

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

Bạn cũng có thể cập nhật ô đã được [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/) tham chiếu. Cách tiếp cận này tránh việc giả định một hàng và cột cụ thể trong một biểu đồ hiện có:

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

![Tên chuỗi](series_name.png)

### **Tạo chuỗi với tên từ nhiều ô**

Tên chuỗi tổng hợp hữu ích khi tên sản phẩm và kỳ báo cáo được lưu trong các ô sổ làm việc riêng biệt. Ví dụ, bạn có thể kết hợp `Product A` trong B1 và `2026` trong C1 thành một tên chuỗi duy nhất trong khi vẫn giữ cả hai phần liên kết với ô nguồn của chúng.

Sử dụng [IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) để lấy phạm vi tên, sau đó truyền bộ sưu tập đó vào [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/). Tham số `skipHiddenCells` kiểm soát việc có bao gồm các ô ẩn hay không: `true` loại bỏ chúng, `false` bao gồm chúng. Ví dụ này sử dụng `false` để bao gồm mọi ô trong phạm vi tên.

Ví dụ sau tạo một bản trình bày với một chuỗi và hai điểm dữ liệu. Các ô B1:C1 chỉ cung cấp tên chuỗi; A2:A3 cung cấp nhãn danh mục, và B2:B3 cung cấp các giá trị số.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
chart.HasLegend = true;

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// Hai ô này cung cấp tên chuỗi.
workbook.GetCell(0, 0, 1, "Product A");
workbook.GetCell(0, 0, 2, "2026");
var nameCells = workbook.GetCellCollection("Sheet1!$B$1:$C$1", skipHiddenCells: false);
var series = chart.ChartData.Series.Add(nameCells, ChartType.ClusteredColumn);

// Các ô riêng biệt cung cấp danh mục và các điểm dữ liệu số.
var northCategory = workbook.GetCell(0, 1, 0, "North");
var southCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(northCategory);
chart.ChartData.Categories.Add(southCategory);
var northValue = workbook.GetCell(0, 1, 1, 120);
var southValue = workbook.GetCell(0, 2, 1, 150);
series.DataPoints.AddDataPointForBarSeries(northValue);
series.DataPoints.AddDataPointForBarSeries(southValue);

presentation.Save("composite_series_name.pptx", SaveFormat.Pptx);
```

Tên chuỗi tạo ra là `Product A 2026`, với một khoảng trắng giữa hai giá trị ô. Chú giải hiển thị nó như một mục cho cả hai cột. Hình ảnh dưới đây được tạo từ bản trình bày đã lưu:

![Biểu đồ cột với giá trị Bắc và Nam và tên chuỗi tổng hợp Product A 2026 trong chú giải](composite_series_name.png)

## **Lấy màu nền tự động của chuỗi**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) trả về màu được tính dựa trên chỉ số chuỗi và kiểu biểu đồ. Đây là màu được sử dụng khi màu nền chuỗi không được định nghĩa rõ ràng. Gọi phương thức này chỉ đọc màu đã tính; nó không gán màu nền mới.

Ví dụ sau in ra màu tự động của mỗi chuỗi mặc định:

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

Màu cụ thể phụ thuộc vào kiểu biểu đồ và chủ đề.

## **Đặt màu nền đảo ngược cho chuỗi biểu đồ**

Đối với các chuỗi thanh, cột và bong bóng, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) có thể hiển thị các giá trị âm bằng một màu nền khác. Đặt màu nền chuỗi thường thành màu rắn, bật tính năng đảo ngược và gán màu giá trị âm qua [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Các số âm không thay đổi trong sổ làm việc; chỉ màu hiển thị của chúng thay đổi.

Ví dụ sau thay thế dữ liệu biểu đồ mặc định bằng một chuỗi. Hàng worksheet 0 chứa tên chuỗi, cột 0 chứa tên danh mục, và cột 1 chứa các giá trị:

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

Bạn có thể bật đảo ngược cho một điểm thông qua [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Trong ví dụ sau, đảo ngược bị tắt cho chuỗi và chỉ bật cho điểm được chọn. Điểm này cũng được gán giá trị âm để hiệu ứng hiển thị:

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

Để làm cho một điểm trống mà không xóa các điểm khác, đặt ô sổ làm việc hỗ trợ của nó thành `null`. Đối với biểu đồ cột, giá trị được vẽ có sẵn qua [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/). Điểm dữ liệu vẫn ở vị trí danh mục tương tự, nhưng biểu đồ sẽ coi giá trị của nó là trống theo cài đặt giá trị trống của biểu đồ.

Ví dụ sau chỉ xóa điểm thứ hai trong chuỗi đầu tiên:

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

Biểu đồ phân tán sử dụng các ô X và Y riêng biệt, và biểu đồ bong bóng cũng sử dụng một ô kích thước. Chỉ xóa ô đại diện cho giá trị bạn muốn loại bỏ. Không gọi [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) khi bạn muốn giữ các điểm còn lại, vì phương thức này sẽ xóa mọi điểm dữ liệu trong bộ sưu tập.

## **Kiểm soát hiển thị các ô trống**

Các ô ẩn chứa giá trị là một trường hợp riêng so với các ô trống. Để bao gồm hoặc loại bỏ dữ liệu từ các hàng và cột worksheet ẩn, xem [Include Data from Hidden Rows and Columns](/slides/vi/net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Một ô workbook trống đại diện cho dữ liệu thiếu; một ô chứa `0` đại diện cho một giá trị số đã biết. Đặt [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) thành `null` để làm ô trống. Số 0 vẫn là 0 bất kể cài đặt ô trống.

Sử dụng [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) để chọn cách biểu đồ hiển thị các ô trống. Cài đặt này áp dụng cho toàn bộ biểu đồ. Nó thay đổi cách các khoảng trống được vẽ, mà không điền ô workbook trống bằng số 0 hoặc giá trị nội suy.

Ví dụ tự chứa sau tạo một biểu đồ đường với một chuỗi, xóa giá trị cho Ngày 3, và lưu biểu đồ cùng một lúc với mỗi chế độ. Không cần tệp đầu vào. [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) sử dụng worksheet 0, cột 0 cho nhãn danh mục, và cột 1 cho các giá trị; hàng 0 giữ tên chuỗi. Dữ liệu cuối cùng là `10, 20, empty, 30, 40`.

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

// Để Ngày 3 thực sự trống, trong khi vẫn giữ lại danh mục và điểm dữ liệu của nó.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

Mỗi tệp đầu ra lưu chế độ đã gán trước khi lưu: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, và `empty_cells_Span.pptx`. Để lưu chỉ một phiên bản, gán chế độ mong muốn và lưu bản trình bày một lần thay vì lặp qua các chế độ.

So sánh phía dưới cho thấy cùng một dữ liệu trong ba tệp. Ngày 3 là trống trong workbook trong mọi trường hợp:

![Biểu đồ đường với dữ liệu giống nhau: Gap ngắt đoạn tại Ngày 3, Zero hạ đường xuống 0, và Span nối Ngày 2 tới Ngày 4.](display_blanks_as.png)

Hiệu ứng hiển thị phụ thuộc vào loại biểu đồ. Một biểu đồ đường làm cho ba chế độ dễ so sánh. Biểu đồ thanh và cột không có đường nối qua danh mục thiếu, vì vậy `Span` không thể tạo đoạn nối như trên; một cột thiếu và một cột có chiều cao 0 cũng có thể trông giống nhau. Tương tự, một biểu đồ phân tán chỉ có điểm đánh dấu không có đường nối. Đừng mong đợi ba kết quả riêng biệt cho mọi loại biểu đồ; hãy kiểm tra đầu ra cho loại bạn đang dùng.

## **Đặt độ rộng khoảng cách chuỗi**

Độ rộng khoảng cách là khoảng cách giữa các cụm thanh hoặc cột kề nhau, biểu thị dưới dạng phần trăm của chiều rộng thanh hoặc cột. Giống như chồng, nó thuộc về nhóm chuỗi cha thay vì một chuỗi riêng. Đặt [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) một lần cho nhóm. Giá trị lớn hơn tạo nhiều không gian hơn giữa các cụm; giá trị nhỏ hơn làm chúng dày đặc hơn.

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

## **Câu hỏi thường gặp**

**Loại biểu đồ nào hỗ trợ dữ liệu chuỗi?**

Tất cả các loại biểu đồ được đại diện bởi enum [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) sử dụng dữ liệu biểu đồ, nhưng chuỗi của chúng không phải luôn có cùng cấu trúc giá trị hoặc cùng cài đặt. Ví dụ, biểu đồ danh mục sử dụng danh mục và giá trị, biểu đồ phân tán sử dụng giá trị X và Y, và biểu đồ bong bóng thêm kích thước bong bóng. Hãy sử dụng phương pháp tạo điểm dữ liệu phù hợp với loại chuỗi. Các tùy chọn như chồng và độ rộng khoảng cách chỉ áp dụng cho các nhóm thanh hoặc cột tương thích.

**Nhóm chuỗi biểu đồ là gì?**

Một [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) chứa các chuỗi tương thích chia sẻ các cài đặt vẽ ở mức nhóm. Một biểu đồ kết hợp có thể chứa hơn một nhóm, vì vậy việc thay đổi nhóm được truy cập qua một chuỗi không nhất thiết thay đổi mọi chuỗi trong biểu đồ.

**Biểu đồ mới tạo có dữ liệu mặc định không?**

Có. Theo mặc định, [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) tạo các chuỗi, danh mục và giá trị mẫu. Bạn có thể chỉnh sửa các ô này hoặc xóa cả hai bộ sưu tập chuỗi và danh mục trước khi thêm một bộ dữ liệu tùy chỉnh hoàn toàn. Một overload cũng có thể tạo biểu đồ mà không có dữ liệu mặc định.

**Các đối tượng biểu đồ được kết nối với các ô workbook như thế nào?**

Tên chuỗi, nhãn danh mục và giá trị điểm dữ liệu tham chiếu tới các ô trong một [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/). Thay đổi một ô được tham chiếu sẽ cập nhật phần tử biểu đồ tương ứng. Khi bạn xây dựng dữ liệu tùy chỉnh, hãy giữ các hàng danh mục và hàng giá trị chuỗi cân bằng để mỗi điểm được vẽ dưới danh mục dự kiến.

**Làm sao để xóa một điểm thay vì toàn bộ chuỗi?**

Đặt ô giá trị tương ứng thành `null` để giữ vị trí danh mục của điểm đó như một điểm trống. Chỉ sử dụng [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) khi bạn muốn xóa mọi điểm trong chuỗi đó. Nếu bạn cũng xóa danh mục, hãy cập nhật mọi chuỗi để giá trị của chúng vẫn phù hợp với bộ danh mục.

**Các điểm trống được hiển thị như thế nào?**

Kết quả phụ thuộc vào loại biểu đồ và [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/). Các biểu đồ hỗ trợ có thể hiển thị khoảng trống dưới dạng khoảng cách, giá trị 0, hoặc bằng cách nối các điểm lân cận. Chọn cài đặt phù hợp với ý nghĩa của dữ liệu thiếu trong bản trình bày của bạn. Xem [Kiểm soát hiển thị các ô trống](#control-the-display-of-empty-cells) để xem ví dụ đầy đủ và so sánh hình ảnh.

**Các giá trị âm được định dạng như thế nào?**

Đối với các chuỗi thanh, cột và bong bóng được hỗ trợ, bật [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) và đặt [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Bạn có thể ghi đè hành vi cho một điểm riêng lẻ bằng [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Các thuộc tính này ảnh hưởng đến định dạng, không phải các giá trị số được lưu.

**Định dạng nào thắng khi cả chuỗi và điểm đều được định dạng?**

Định dạng điểm dữ liệu cụ thể luôn chiếm ưu tiên cho điểm đó. Các điểm khác vẫn sử dụng định dạng chuỗi rõ ràng hoặc, nếu định dạng chuỗi chưa được xác định, kiểu và chủ đề biểu đồ tự động. Các thuộc tính nhóm như chồng và độ rộng khoảng cách điều khiển bố cục và không phải là ghi đè định dạng cấp điểm.

**Có giới hạn số chuỗi mà một biểu đồ có thể chứa không?**

Aspose.Slides không áp đặt một giới hạn cố định riêng cho số chuỗi. Trong thực tế, các ràng buộc của tệp trình bày, bộ nhớ khả dụng, thời gian render và khả năng đọc biểu đồ quyết định giới hạn thực tế.

**Nên thay đổi gì khi các cột quá gần nhau hoặc quá xa?**

Đặt [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) trên nhóm chuỗi cha thích hợp. Tăng giá trị để mở rộng không gian giữa các cụm, hoặc giảm nó để đưa các cụm lại gần nhau hơn.