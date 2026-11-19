---
title: Quản lý Dữ liệu Dòng Biểu Đồ trong Bản Trình Chiếu bằng .NET
linktitle: Dòng Dữ Liệu
type: docs
url: /vi/net/chart-series/
keywords:
- dòng biểu đồ
- độ chồng chéo của dòng
- màu dòng
- màu danh mục
- tên dòng
- điểm dữ liệu
- khoảng trống giữa các dòng
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách quản lý các dòng biểu đồ, điểm dữ liệu, ô bảng tính, định dạng, độ chồng chéo, độ rộng khoảng trống và giá trị âm trong bản trình chiếu bằng C#."
---
## **Tổng quan**

Biểu đồ có thể lưu trữ các giá trị đã vẽ trong các ô của bảng tính hoặc trực tiếp dưới dạng các giá trị số nguyên thuỷ. Một [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) đại diện cho một tập hợp các giá trị liên quan, và mỗi [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) đại diện cho một điểm trong tập hợp đó. Các đối tượng [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) cung cấp các nhãn hoặc giá trị nhóm được các tập hợp chia sẻ. Trong các biểu đồ được tạo với dữ liệu mặc định, tên tập hợp, danh mục và giá trị điểm sử dụng các đối tượng [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) từ bảng tính của biểu đồ.

Đối với một biểu đồ danh mục điển hình, bảng tính mặc định sử dụng hàng 0 cho tên các tập hợp, cột 0 cho tên danh mục và các ô còn lại cho giá trị các tập hợp. Các chỉ mục worksheet, hàng và cột được truyền vào [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) là dạng chỉ số bắt đầu từ 0. Bố cục này hữu ích khi bạn tạo biểu đồ với dữ liệu mặc định, nhưng không nên cho rằng mọi biểu đồ hiện có đều sử dụng nó. Đối với một bản trình chiếu đã tải, hãy kiểm tra các ô được các tập hợp, danh mục và điểm dữ liệu tham chiếu trước khi thay đổi giá trị trong bảng tính.

Cài đặt biểu đồ có ba phạm vi khác nhau:

- Cài đặt ở mức tập hợp, chẳng hạn như [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/), cung cấp giao diện mặc định cho tất cả các điểm trong một tập hợp.
- Cài đặt ở mức điểm dữ liệu, chẳng hạn như [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/), ghi đè giao diện của tập hợp cho một điểm.
- Cài đặt nhóm áp dụng cho các tập hợp tương thích thuộc cùng một [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/). Truy cập nhóm qua [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) khi bạn cần đặt các tùy chọn như độ chồng chéo hoặc độ rộng khoảng trống.

Khi không có màu nền điểm hoặc tập hợp nào được chỉ định rõ ràng, kiểu biểu đồ và chủ đề sẽ xác định giao diện tự động. Khi cả định dạng tập hợp và điểm đều tồn tại, định dạng điểm sẽ có ưu tiên cho điểm đó.

![chart-series-powerpoint](chart-series-powerpoint.png)

Đối với biểu đồ trụ cụm, xem cách [thay đổi loại chuỗi 3D hoặc hình dạng thanh](/slides/vi/net/3d-chart/#change-the-3d-series-type-and-bar-shape) ảnh hưởng đến chuỗi đầu tiên.

## **Đặt Giá Trị Dòng Dữ Liệu Bằng Các Giá Trị Nguyên Thủy**

Sử dụng các giá trị nguyên thủy khi giá trị của các tập hợp đến từ dữ liệu hoặc tính toán trong ứng dụng và không cần tham chiếu tới ô của worksheet. Đặt [DataSourceTypeForValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforvalues/) thành [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) trước khi gán [Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/value/) của mỗi điểm qua [AsLiteralDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/idoublechartvalue/asliteraldouble/).

Cài đặt bộ sưu tập kiểm soát kiểu nguồn của tất cả các giá trị điểm trong tập hợp đó. [Value.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ibasechartvalue/datasourcetype/) của mỗi điểm báo cáo kiểu đã chọn; thay đổi nó thông qua cài đặt bộ sưu tập. Khi dùng `Worksheet`, sử dụng [AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/isinglecellchartvalue/ascell/) để truy cập ô được tham chiếu. Khi dùng `DoubleLiterals`, dùng `AsLiteralDouble` để đọc hoặc ghi số trực tiếp.

Ví dụ sau tạo một biểu đồ cột với các tập hợp và danh mục mặc định, sau đó gán các giá trị đã tính là 10, 20, … cho các điểm hiện có của tập hợp đầu tiên. Nó lưu bản trình chiếu, mở lại và in ra các giá trị đã lưu.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

series.DataPoints.DataSourceTypeForValues = DataSourceType.DoubleLiterals;
for (var i = 0; i < series.DataPoints.Count; i++)
{
    series.DataPoints[i].Value.AsLiteralDouble = (i + 1) * 10;
}

presentation.Save("numeric_literals.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("numeric_literals.pptx");
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedChart = (IChart)reopenedSlide.Shapes[0];
var reopenedSeries = reopenedChart.ChartData.Series[0];
foreach (var point in reopenedSeries.DataPoints)
{
    Console.WriteLine(point.Value.AsLiteralDouble);
}
```

Kiểu nguồn giá trị điểm tách biệt khỏi [IChartData.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/datasourcetype/), kiểu này xác định cấu hình bảng tính nội bộ hoặc ngoại vi của biểu đồ. Sử dụng các giá trị nguyên thủy không tự động loại bỏ bảng tính nhúng. Trong ví dụ này, bảng tính vẫn tồn tại để cung cấp nhãn danh mục, tên tập hợp và các tập hợp khác. Xem mục [Chart Workbook](/slides/vi/net/chart-workbook/) để biết cách quản lý bảng tính.

Đối với các biểu đồ scatter và bubble, đặt [DataSourceTypeForXValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforxvalues/) và [DataSourceTypeForYValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforyvalues/) để chọn nguồn cho [XValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/xvalue/) và [YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/). Biểu đồ bubble cũng sử dụng [DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforbubblesizes/) cho [BubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/bubblesize/). Đặt mỗi nguồn áp dụng thành `DoubleLiterals` trước khi gán số qua thuộc tính `AsLiteralDouble` của giá trị đó.

## **Đặt Độ Chồng Lên Nhau Của Các Tập Hợp Biểu Đồ**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) cho biết mức độ các thanh hoặc cột chồng lên nhau trong biểu đồ 2D, từ -100 tới 100 phần trăm. Đây là một phép chiếu chỉ đọc dựa trên cài đặt của nhóm tập hợp cha. Đặt [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) để cập nhật mọi tập hợp tương thích trong nhóm đó. Tùy chọn này áp dụng cho các loại biểu đồ hiển thị các thanh hoặc cột được nhóm lại; nó không ảnh hưởng tới các nhóm tập hợp không liên quan trong biểu đồ kết hợp.

Ví dụ sau đặt độ chồng chéo cho nhóm chứa tập hợp đầu tiên:

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

![The series overlap](series_overlap.png)

## **Thay Đổi Màu Nền Của Tập Hợp**

Sử dụng [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) để đặt màu nền mặc định cho toàn bộ một tập hợp. Nếu một điểm đã có màu nền riêng, cài đặt [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) của nó sẽ ghi đè màu nền của tập hợp cho điểm đó.

Ví dụ sau áp dụng màu nền xanh đậm đặc cho tập hợp đầu tiên:

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

![The color of the series](series_color.png)

## **Thay Đổi Tên Tập Hợp**

Tên tập hợp được lưu trong bảng tính dữ liệu của biểu đồ và thường được hiển thị trong chú giải. Trong bảng tính mặc định được tạo cho biểu đồ cột cụm, ô B1 là hàng 0, cột 1 và chứa tên của tập hợp đầu tiên. Các hằng số được đặt tên trong ví dụ sau làm rõ cấu trúc này:

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

Bạn cũng có thể cập nhật ô đã được [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/) tham chiếu. Cách này tránh việc giả định một hàng và cột cụ thể trong một biểu đồ hiện có:

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

![The series name](series_name.png)

### **Tạo Một Tập Hợp Với Tên Từ Nhiều Ô**

Tên tập hợp hợp thành hữu ích khi tên sản phẩm và kỳ báo cáo được lưu trong các ô bảng tính riêng biệt. Ví dụ, bạn có thể kết hợp `Product A` ở B1 và `2026` ở C1 thành một tên tập hợp duy nhất trong khi vẫn giữ cả hai phần liên kết tới ô nguồn của chúng.

Sử dụng [IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) để lấy phạm vi tên, sau đó truyền bộ sưu tập đó cho [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/). Tham số `skipHiddenCells` điều khiển việc có bao gồm các ô ẩn hay không: `true` loại bỏ chúng, `false` bao gồm chúng. Ví dụ này sử dụng `false` để bao gồm mọi ô trong phạm vi tên.

Ví dụ sau tạo một bản trình chiếu với một tập hợp và hai điểm dữ liệu. Các ô B1:C1 chỉ cung cấp tên tập hợp; A2:A3 cung cấp nhãn danh mục, và B2:B3 cung cấp các giá trị số.

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

// Separate cells supply the categories and numeric data points.
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

Tên tập hợp kết quả là `Product A 2026`, với một dấu cách giữa hai giá trị ô. Chú giải hiển thị nó như một mục duy nhất cho cả hai cột. Hình ảnh dưới đây được tạo từ bản trình chiếu đã lưu:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Lấy Màu Nền Tự Động Của Tập Hợp**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) trả về màu được tính dựa trên chỉ số tập hợp và kiểu biểu đồ. Đây là màu được dùng khi màu nền của tập hợp chưa được định nghĩa rõ ràng. Gọi phương thức chỉ đọc màu đã tính; nó không gán màu nền mới.

Ví dụ sau in ra màu tự động của mỗi tập hợp mặc định:

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

Kết quả mẫu cho kiểu biểu đồ mặc định:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Màu sắc cụ thể phụ thuộc vào kiểu biểu đồ và chủ đề.

## **Đặt Màu Nền Đảo Ngược Cho Một Tập Hợp Biểu Đồ**

Đối với các tập hợp thanh, cột và bubble, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) cho phép hiển thị các giá trị âm với màu nền khác. Đặt màu nền chuẩn của tập hợp thành màu đặc, bật tính năng đảo ngược, và gán màu âm qua [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Các số âm không thay đổi trong bảng tính; chỉ màu hiển thị của chúng thay đổi.

Ví dụ sau thay thế dữ liệu biểu đồ mặc định bằng một tập hợp. Hàng 0 của worksheet chứa tên tập hợp, cột 0 chứa tên danh mục, và cột 1 chứa các giá trị:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

Bạn có thể bật đảo ngược cho một điểm duy nhất qua [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Trong ví dụ sau, đảo ngược được tắt cho tập hợp và chỉ bật cho điểm đã chọn. Điểm này cũng được gán giá trị âm để hiệu ứng hiển thị:

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

## **Xóa Giá Trị Của Một Điểm Dữ Liệu Cụ Thể**

Để làm cho một điểm trống mà không xóa các điểm khác, đặt ô bảng tính nền của nó thành `null`. Đối với biểu đồ cột, giá trị đã vẽ có thể truy cập qua [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/). Điểm dữ liệu vẫn giữ vị trí danh mục, nhưng biểu đồ sẽ coi giá trị của nó là trống theo cài đặt giá trị trống của biểu đồ.

Ví dụ sau chỉ xóa điểm thứ hai trong tập hợp đầu tiên:

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

Biểu đồ scatter sử dụng các ô X và Y riêng biệt, và biểu đồ bubble còn dùng một ô kích thước. Chỉ xóa ô đại diện cho giá trị bạn muốn loại bỏ. Không gọi [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) khi bạn muốn giữ lại các điểm khác, vì phương pháp này sẽ xóa mọi điểm dữ liệu trong bộ sưu tập.

## **Kiểm Soát Việc Hiển Thị Các Ô Trống**

Các ô ẩn có chứa giá trị là một trường hợp riêng biệt so với các ô trống. Để bao gồm hoặc loại bỏ dữ liệu từ các hàng và cột worksheet ẩn, xem mục [Include Data from Hidden Rows and Columns](/slides/vi/net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Một ô bảng tính trống đại diện cho dữ liệu thiếu; một ô chứa `0` đại diện cho một giá trị số đã biết. Đặt [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) thành `null` để làm cho ô trở nên trống. Số 0 vẫn là 0 bất kể cài đặt ô trống.

Sử dụng [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) để chọn cách biểu đồ hiển thị các ô trống. Cài đặt này áp dụng cho toàn bộ biểu đồ. Nó thay đổi cách các khoảng trống được vẽ, mà không điền ô trống trong bảng tính bằng số 0 hoặc giá trị nội suy.

Ví dụ tự chứa dưới đây tạo một biểu đồ đường với một tập hợp, xóa giá trị cho Ngày 3, và lưu cùng một biểu đồ với mỗi chế độ. Không cần tập tin đầu vào. [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) sử dụng worksheet 0, cột 0 cho nhãn danh mục, và cột 1 cho giá trị; hàng 0 chứa tên tập hợp. Dữ liệu cuối cùng là `10, 20, empty, 30, 40`.

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

// Để ngày 3 thực sự trống, trong khi vẫn giữ lại danh mục và điểm dữ liệu của nó.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

Mỗi tệp đầu ra lưu chế độ đã được gán trước khi lưu: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, và `empty_cells_Span.pptx`. Để chỉ lưu một phiên bản, gán chế độ mong muốn và lưu bản trình chiếu một lần thay vì lặp qua các chế độ.

So sánh dưới đây hiển thị cùng một dữ liệu trong cả ba tệp. Ngày 3 là trống trong bảng tính trong mọi trường hợp:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Hiệu ứng hiển thị phụ thuộc vào loại biểu đồ. Biểu đồ đường làm ba chế độ dễ so sánh. Biểu đồ thanh và cột không có đường nối qua danh mục bị thiếu, vì vậy `Span` không tạo ra đoạn nối như trên; một cột thiếu và một cột có chiều cao 0 cũng có thể trông giống nhau. Tương tự, một biểu đồ scatter chỉ có dấu chấm không có đường nối. Đừng mong đợi ba kết quả rõ ràng cho mọi loại biểu đồ; hãy kiểm tra đầu ra cho loại bạn đang dùng.

## **Đặt Độ Rộng Khoảng Trống Giữa Các Tập Hợp**

Độ rộng khoảng trống là khoảng cách giữa các cụm thanh hoặc cột liền kề, tính bằng phần trăm của độ rộng thanh hoặc cột. Giống như độ chồng, nó thuộc về nhóm tập hợp cha chứ không phải một tập hợp riêng lẻ. Đặt [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) một lần cho nhóm. Giá trị lớn hơn tạo nhiều khoảng cách hơn giữa các cụm; giá trị nhỏ hơn làm chúng dày đặc hơn.

Ví dụ sau thay đổi độ rộng khoảng trống và chỉ lưu bản trình chiếu cuối cùng:

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

![The gap width](gap_width.png)

## **Hiển Thị Hoặc Ẩn Đường Nối Tập Hợp**

Đường nối tập hợp kết nối trực quan các phần liên quan của biểu đồ. Sử dụng [IChartSeriesGroup.HasSeriesLines](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/hasserieslines/) để hiển thị hoặc ẩn chúng trong các biểu đồ stacked bar và OfPie được hỗ trợ. Trong các biểu đồ stacked bar và column hai chiều, chúng nối các ranh giới chồng tương ứng qua các danh mục. Trong Pie of Pie và Bar of Pie, chúng nối biểu đồ chính với biểu đồ phụ. Cài đặt này không phải là một công cụ nối tổng quát cho các loại biểu đồ khác.

Truy cập nhóm qua [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/). Cài đặt áp dụng cho mọi tập hợp trong nhóm đó. [IChartSeries.HasSeriesLines](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/hasserieslines/) là thuộc tính chỉ đọc và phản ánh cài đặt của nhóm cha; thay đổi thuộc tính của nhóm để cập nhật.

Ví dụ sau tạo một biểu đồ [PieOfPie](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) với dữ liệu mặc định. Nó lưu cùng một biểu đồ với đường nối tập hợp được bật và sau đó tắt, tạo hai bản trình chiếu để so sánh.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 400);
var series = chart.ChartData.Series[0];
var seriesGroup = series.ParentSeriesGroup;

seriesGroup.HasSeriesLines = true;
presentation.Save("series_lines_enabled.pptx", SaveFormat.Pptx);

seriesGroup.HasSeriesLines = false;
presentation.Save("series_lines_disabled.pptx", SaveFormat.Pptx);
```

| Đường nối tập hợp bật | Đường nối tập hợp tắt |
| --- | --- |
| ![Pie of Pie chart with series lines enabled](series_lines_enabled.png) | ![Pie of Pie chart with series lines disabled](series_lines_disabled.png) |
| Hai đường nối kết nối phần bánh chính với phần bánh phụ. | Cả hai bánh vẫn hiển thị, nhưng các đường nối bị ẩn. |

Đường nối tập hợp khác với các đường dẫn nhãn dữ liệu (kết nối nhãn với các điểm dữ liệu), các đường lưới (đánh dấu các khoảng cách trên trục), và các đường trong biểu đồ đường (biểu thị giá trị dữ liệu). Cài đặt này không điều khiển các yếu tố trên.

## **FAQ**

**Các loại biểu đồ nào hỗ trợ tập dữ liệu?**

Tất cả các loại biểu đồ được liệt kê trong enum [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) đều sử dụng dữ liệu biểu đồ, nhưng các tập hợp của chúng không có cùng cấu trúc giá trị hoặc cùng cài đặt. Ví dụ, biểu đồ danh mục dùng danh mục và giá trị, biểu đồ scatter dùng giá trị X và Y, còn biểu đồ bubble thêm kích thước bong bóng. Hãy sử dụng phương pháp tạo điểm dữ liệu phù hợp với loại tập hợp. Các tùy chọn như độ chồng và độ rộng khoảng trống chỉ áp dụng cho các nhóm thanh hoặc cột tương thích.

**Nhóm tập hợp biểu đồ là gì?**

[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) chứa các tập hợp tương thích chia sẻ các cài đặt vẽ ở mức nhóm. Một biểu đồ kết hợp có thể chứa hơn một nhóm, vì vậy việc thay đổi nhóm thông qua một tập hợp không nhất thiết thay đổi mọi tập hợp trong biểu đồ.

**Biểu đồ mới tạo có chứa dữ liệu mặc định không?**

Có. Mặc định, [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) tạo các tập hợp, danh mục và giá trị mẫu. Bạn có thể chỉnh sửa các ô này hoặc xóa cả hai bộ sưu tập tập hợp và danh mục trước khi thêm một bộ dữ liệu tùy chỉnh hoàn toàn. Một overload cũng có thể tạo biểu đồ mà không có dữ liệu mặc định.

**Các đối tượng biểu đồ được liên kết với các ô bảng tính như thế nào?**

Tên tập hợp, nhãn danh mục và giá trị điểm dữ liệu tham chiếu đến các ô trong một [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/). Thay đổi một ô được tham chiếu sẽ cập nhật yếu tố biểu đồ tương ứng. Khi bạn xây dựng dữ liệu tùy chỉnh, hãy giữ các hàng danh mục và các hàng giá trị tập hợp đồng bộ để mỗi điểm được vẽ dưới đúng danh mục.

**Làm sao để xóa một điểm mà không xóa toàn bộ tập hợp?**

Đặt ô giá trị tương ứng thành `null` để giữ vị trí danh mục của điểm như một điểm trống. Chỉ dùng [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) khi bạn muốn xóa mọi điểm trong tập hợp đó. Nếu bạn cũng xóa các danh mục, hãy cập nhật mọi tập hợp để giá trị của chúng vẫn đồng bộ với bộ danh mục.

**Các điểm trống được hiển thị như thế nào?**

Kết quả phụ thuộc vào loại biểu đồ và [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/). Các biểu đồ được hỗ trợ có thể hiển thị khoảng trống dưới dạng khe hở, giá trị 0, hoặc bằng cách nối các điểm lân cận. Chọn cài đặt phù hợp với ý nghĩa của dữ liệu thiếu trong bản trình chiếu của bạn. Xem mục [Control the Display of Empty Cells](#control-the-display-of-empty-cells) để xem ví dụ đầy đủ và so sánh hình ảnh.

**Giá trị âm được định dạng như thế nào?**

Đối với các tập hợp thanh, cột và bubble được hỗ trợ, bật [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) và đặt [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Bạn có thể ghi đè hành vi này cho một điểm riêng lẻ bằng [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Các thuộc tính này ảnh hưởng đến định dạng, không thay đổi giá trị số được lưu.

**Định dạng nào thắng khi cả tập hợp và điểm đều được định dạng?**

Định dạng điểm dữ liệu rõ ràng sẽ có ưu tiên cho điểm đó. Các điểm khác vẫn sử dụng định dạng tập hợp rõ ràng hoặc, khi tập hợp không được định nghĩa, sẽ dùng kiểu và chủ đề biểu đồ tự động. Các thuộc tính nhóm như độ chồng và độ rộng khoảng trống kiểm soát bố cục và không phải là các ghi đè định dạng cấp điểm.

**Có giới hạn số lượng tập hợp một biểu đồ có thể chứa không?**

Aspose.Slides không đặt một giới hạn cố định riêng cho số lượng tập hợp. Trong thực tế, các ràng buộc của tệp trình chiếu, bộ nhớ khả dụng, thời gian render và khả năng đọc hiểu của biểu đồ sẽ quyết định một giới hạn thực tế.

**Nên thay đổi gì khi các cột quá gần nhau hoặc quá xa?**

Đặt [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) trên nhóm cha thích hợp. Tăng giá trị để mở rộng không gian giữa các cụm, hoặc giảm giá trị để các cụm gần nhau hơn.