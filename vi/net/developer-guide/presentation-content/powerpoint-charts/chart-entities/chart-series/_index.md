---
title: Quản lý chuỗi dữ liệu biểu đồ trong bản trình chiếu bằng .NET
linktitle: Chuỗi dữ liệu
type: docs
url: /vi/net/chart-series/
keywords:
- chuỗi biểu đồ
- chồng chéo chuỗi
- màu chuỗi
- màu danh mục
- tên chuỗi
- điểm dữ liệu
- khoảng trống chuỗi
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách quản lý chuỗi biểu đồ, điểm dữ liệu, các ô workbook, định dạng, chồng chéo, độ rộng khoảng trống và các giá trị âm trong bản trình chiếu bằng C#."
---
## **Tổng quan**

Biểu đồ có thể lưu các giá trị đã vẽ trong các ô của workbook hoặc trực tiếp dưới dạng literal số. Một [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) đại diện cho một tập hợp các giá trị liên quan, và mỗi [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) đại diện cho một điểm trong tập hợp đó. Các đối tượng [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) cung cấp các nhãn hoặc giá trị nhóm được chia sẻ bởi các series. Trong các biểu đồ được tạo với dữ liệu mặc định, tên series, danh mục và giá trị điểm sử dụng các đối tượng [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) từ workbook của biểu đồ.

Đối với một biểu đồ danh mục điển hình, workbook mặc định sử dụng hàng 0 cho tên series, cột 0 cho tên danh mục và các ô còn lại cho giá trị series. Các chỉ mục Worksheet, row và column được truyền vào [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) là dạng zero‑based. Bố cục này hữu ích khi bạn tạo biểu đồ với dữ liệu mặc định, nhưng không nên cho rằng mọi biểu đồ hiện có đều sử dụng nó. Đối với một bản trình bày đã tải, hãy kiểm tra các ô được series, categories và data points tham chiếu trước khi thay đổi giá trị workbook.

Cài đặt biểu đồ có ba phạm vi khác nhau:

- Cài đặt ở mức Series, chẳng hạn như [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/), cung cấp giao diện mặc định cho tất cả các điểm trong một series.
- Cài đặt ở mức Data‑point, chẳng hạn như [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/), ghi đè giao diện series cho một điểm.
- Cài đặt nhóm áp dụng cho các series tương thích thuộc cùng một [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/). Truy cập nhóm qua [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) khi bạn cần đặt các tùy chọn như overlap hoặc gap width.

Khi không có fill explicit cho điểm hoặc series, kiểu biểu đồ và theme sẽ xác định giao diện tự động. Khi cả hai đều tồn tại, định dạng điểm sẽ có ưu tiên cho điểm đó.

![Sê‑ri biểu đồ PowerPoint](chart-series-powerpoint.png)

## **Đặt giá trị series bằng literal số**

Sử dụng literal số khi giá trị series đến từ dữ liệu hoặc tính toán trong ứng dụng và không cần tham chiếu tới ô worksheet. Đặt [DataSourceTypeForValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforvalues/) thành [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) trước khi gán [Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/value/) cho mỗi điểm qua [AsLiteralDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/idoublechartvalue/asliteraldouble/).

Cài đặt của collection kiểm soát kiểu nguồn của tất cả các giá trị điểm trong series đó. [Value.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ibasechartvalue/datasourcetype/) của mỗi điểm báo cáo kiểu đã chọn; thay đổi nó qua cài đặt của collection. Khi dùng `Worksheet`, sử dụng [AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/isinglecellchartvalue/ascell/) để truy cập ô được tham chiếu. Khi dùng `DoubleLiterals`, sử dụng `AsLiteralDouble` để đọc hoặc ghi số trực tiếp.

Ví dụ sau tạo một biểu đồ cột với series và categories mặc định, sau đó gán các giá trị tính toán 10, 20, … cho các điểm hiện có của series đầu tiên. Nó lưu bản trình bày, mở lại và in các giá trị đã lưu.

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

Kiểu nguồn giá trị điểm tách biệt với [IChartData.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/datasourcetype/), chỉ định cấu hình workbook nội bộ hoặc ngoại vi của biểu đồ. Sử dụng literal số không tự động loại bỏ workbook nhúng. Trong ví dụ này, workbook vẫn còn để cung cấp nhãn danh mục, tên series và các series khác. Xem [Workbook biểu đồ](/slides/vi/net/chart-workbook/) để quản lý workbook.

Đối với biểu đồ scatter và bubble, đặt [DataSourceTypeForXValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforxvalues/) và [DataSourceTypeForYValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforyvalues/) để chọn nguồn cho [XValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/xvalue/) và [YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/). Biểu đồ bubble cũng sử dụng [DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforbubblesizes/) cho [BubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/bubblesize/). Đặt mỗi nguồn áp dụng thành `DoubleLiterals` trước khi gán số qua thuộc tính `AsLiteralDouble` của giá trị ấy.

## **Đặt mức chồng chéo series biểu đồ**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) báo cáo mức độ các cột hoặc thanh chồng lên nhau trong biểu đồ 2D, từ -100 đến 100 phần trăm. Đây là một phép chiếu chỉ đọc dựa trên cài đặt của nhóm series cha. Đặt [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) để cập nhật mọi series tương thích trong nhóm đó. Tùy chọn này áp dụng cho các loại biểu đồ hiển thị các thanh hoặc cột được nhóm; nó không ảnh hưởng đến các nhóm series không liên quan trong biểu đồ kết hợp.

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

![Sự chồng chéo series](series_overlap.png)

## **Thay đổi màu tô series**

Sử dụng [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) để đặt màu tô mặc định cho toàn bộ series. Nếu một điểm đã có màu tô explicit, cài đặt [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) của nó sẽ ghi đè màu tô series cho điểm đó.

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

## **Thay đổi tên series**

Tên series được lưu trong workbook dữ liệu biểu đồ và thường được hiển thị trong legend. Trong workbook mặc định được tạo cho biểu đồ cột nhóm, ô B1 nằm ở hàng 0, cột 1 và chứa tên của series đầu tiên. Các hằng số có tên trong ví dụ sau làm rõ cấu trúc này:

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

![Tên series](series_name.png)

### **Tạo một series với tên từ nhiều ô**

Tên series hợp thành hữu ích khi tên sản phẩm và kỳ báo cáo được lưu trong các ô workbook riêng biệt. Ví dụ, bạn có thể kết hợp `Product A` ở B1 và `2026` ở C1 thành một tên series duy nhất trong khi vẫn giữ cả hai phần liên kết tới ô nguồn.

Sử dụng [IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) để lấy phạm vi tên, sau đó truyền collection đó vào [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/). Tham số `skipHiddenCells` kiểm soát việc có bao gồm các ô ẩn hay không: `true` loại trừ, `false` bao gồm. Ví dụ này dùng `false` để bao gồm mọi ô trong phạm vi tên.

Ví dụ sau tạo một bản trình bày với một series và hai điểm dữ liệu. Các ô B1:C1 chỉ cung cấp tên series; A2:A3 cung cấp nhãn danh mục, và B2:B3 cung cấp các giá trị số.

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

// Hai ô này cung cấp tên series.
workbook.GetCell(0, 0, 1, "Product A");
workbook.GetCell(0, 0, 2, "2026");
var nameCells = workbook.GetCellCollection("Sheet1!$B$1:$C$1", skipHiddenCells: false);
var series = chart.ChartData.Series.Add(nameCells, ChartType.ClusteredColumn);

// Các ô riêng biệt cung cấp các danh mục và các điểm dữ liệu số.
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

Tên series kết quả là `Product A 2026`, với một khoảng trống giữa hai giá trị ô. Legend hiển thị nó như một mục cho cả hai cột. Hình dưới được render từ bản trình bày đã lưu:

![Biểu đồ cột với giá trị Bắc và Nam và tên series hợp thành Product A 2026 trong legend](composite_series_name.png)

## **Lấy màu tô series tự động**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) trả về màu được tính dựa trên chỉ số series và kiểu biểu đồ. Đây là màu được sử dụng khi màu tô series chưa được định nghĩa rõ ràng. Gọi phương thức chỉ đọc màu đã tính; nó không gán fill mới.

Ví dụ sau in màu tự động của mỗi series mặc định:

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

Màu cụ thể phụ thuộc vào kiểu biểu đồ và theme.

## **Đặt màu tô nghịch đảo cho một series biểu đồ**

Đối với series thanh, cột và bubble, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) có thể hiển thị các giá trị âm với màu khác. Đặt màu tô series thường thành màu đặc, bật tính năng invert, và gán màu âm qua [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Các số âm vẫn không thay đổi trong workbook; chỉ màu hiển thị thay đổi.

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

![Màu tô đặc nghịch đảo](inverted_solid_fill_color.png)

Bạn có thể bật invert cho một điểm qua [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Trong ví dụ sau, invert bị tắt cho toàn bộ series và chỉ bật cho điểm đã chọn. Điểm này cũng được gán giá trị âm để hiệu ứng hiển thị:

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

Để làm trống một điểm mà không xóa các điểm khác, đặt ô workbook hỗ trợ của nó thành `null`. Đối với biểu đồ cột, giá trị đã vẽ có sẵn qua [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/). Điểm dữ liệu vẫn giữ vị trí danh mục, nhưng biểu đồ sẽ coi giá trị là trống theo cài đặt blank‑value của biểu đồ.

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

Biểu đồ scatter dùng các ô X và Y riêng biệt, và biểu đồ bubble còn dùng ô kích thước. Chỉ xóa ô đại diện cho giá trị bạn muốn loại bỏ. Không gọi [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) khi bạn muốn giữ các điểm còn lại, vì phương thức này sẽ xóa mọi điểm dữ liệu trong collection.

## **Kiểm soát hiển thị các ô trống**

Các ô ẩn chứa giá trị là một trường hợp riêng biệt so với các ô trống. Để bao gồm hoặc loại bỏ dữ liệu từ các hàng và cột worksheet ẩn, xem [Include Data from Hidden Rows and Columns](/slides/vi/net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Một ô workbook trống biểu thị dữ liệu thiếu; một ô chứa `0` biểu thị một giá trị số đã biết. Đặt [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) thành `null` để làm ô trống. Số không vẫn là số không bất kể cài đặt ô trống.

Sử dụng [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) để chọn cách biểu đồ hiển thị các ô trống. Cài đặt này áp dụng cho toàn bộ biểu đồ. Nó thay đổi cách các khoảng trống được vẽ, mà không điền ô workbook trống bằng số 0 hay giá trị nội suy.

Ví dụ tự chứa sau tạo một biểu đồ đường với một series, xóa giá trị cho Ngày 3, và lưu cùng một biểu đồ với mỗi chế độ. Không cần tệp đầu vào. [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) dùng worksheet 0, cột 0 cho nhãn danh mục, và cột 1 cho giá trị; hàng 0 chứa tên series. Dữ liệu cuối cùng là `10, 20, empty, 30, 40`.

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

// Để lại Ngày 3 thực sự trống, trong khi vẫn giữ lại danh mục và điểm dữ liệu của nó.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

Mỗi tệp đầu ra lưu chế độ được gán trước khi lưu: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, và `empty_cells_Span.pptx`. Để lưu chỉ một phiên bản, gán chế độ mong muốn và lưu bản trình bày một lần thay vì lặp qua các chế độ.

So sánh dưới đây cho thấy cùng một dữ liệu trong ba tệp. Ngày 3 trống trong workbook trong mọi trường hợp:

![Biểu đồ đường với dữ liệu giống nhau: Gap làm ngắt đường tại Ngày 3, Zero hạ đường xuống 0, và Span nối Ngày 2 tới Ngày 4.](display_blanks_as.png)

Hiệu ứng hiển thị phụ thuộc vào loại biểu đồ. Biểu đồ đường giúp so sánh ba chế độ dễ dàng. Biểu đồ thanh và cột không có đường để nối qua danh mục thiếu, vì vậy `Span` không thể tạo đoạn nối như trên; một cột thiếu và một cột có chiều cao 0 cũng có thể trông giống nhau. Tương tự, biểu đồ scatter chỉ có marker không có đường nối. Đừng mong ba kết quả riêng biệt cho mọi loại biểu đồ; hãy kiểm tra đầu ra cho loại bạn đang dùng.

## **Đặt độ rộng khoảng trống giữa series**

Độ rộng khoảng trống là khoảng cách giữa các cụm thanh hoặc cột kề nhau, tính bằng phần trăm của chiều rộng thanh hoặc cột. Giống như overlap, nó thuộc về nhóm series cha chứ không phải một series riêng. Đặt [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) một lần cho nhóm. Giá trị lớn hơn tạo nhiều không gian hơn giữa các cụm; giá trị nhỏ hơn làm chúng dày đặc hơn.

Ví dụ sau thay đổi độ rộng khoảng trống và lưu chỉ bản trình bày cuối cùng:

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

![Độ rộng khoảng trống](gap_width.png)

## **Câu hỏi thường gặp**

**Loại biểu đồ nào hỗ trợ series dữ liệu?**

Tất cả các loại biểu đồ được đại diện bởi enumeration [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) đều sử dụng dữ liệu biểu đồ, nhưng series của chúng không có cùng cấu trúc giá trị hoặc cài đặt. Ví dụ, biểu đồ danh mục dùng categories và values, biểu đồ scatter dùng X và Y values, và biểu đồ bubble thêm bubble sizes. Hãy dùng phương pháp tạo data‑point phù hợp với loại series. Các tùy chọn như overlap và gap width chỉ áp dụng cho các nhóm thanh hoặc cột tương thích.

**Nhóm series biểu đồ là gì?**

[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) chứa các series tương thích chia sẻ các cài đặt plotting ở mức nhóm. Một biểu đồ kết hợp có thể chứa hơn một nhóm, vì vậy việc thay đổi nhóm thông qua một series không nhất thiết sẽ thay đổi mọi series trong biểu đồ.

**Biểu đồ mới tạo có dữ liệu mặc định không?**

Có. Theo mặc định, [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) tạo các series, categories và values mẫu. Bạn có thể chỉnh sửa các ô đó hoặc xóa cả hai collection series và category trước khi thêm một bộ dữ liệu hoàn toàn tùy chỉnh. Một overload cũng có thể tạo biểu đồ không có dữ liệu mặc định.

**Các đối tượng biểu đồ được kết nối tới các ô workbook như thế nào?**

Tên series, nhãn danh mục và giá trị data‑point tham chiếu tới các ô trong một [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/). Thay đổi ô được tham chiếu sẽ cập nhật yếu tố biểu đồ tương ứng. Khi bạn xây dựng dữ liệu tùy chỉnh, hãy giữ các hàng danh mục và các hàng giá trị series đồng nhất để mỗi điểm được vẽ dưới danh mục mong muốn.

**Làm sao để xóa một điểm mà không xóa toàn bộ series?**

Đặt ô giá trị tương ứng thành `null` để giữ vị trí danh mục của điểm như một điểm trống. Chỉ sử dụng [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) khi bạn muốn xóa tất cả các điểm trong series đó. Nếu bạn cũng xóa các danh mục, hãy cập nhật mọi series để giữ giá trị của chúng đồng bộ với collection danh mục.

**Các điểm trống được hiển thị như thế nào?**

Kết quả phụ thuộc vào loại biểu đồ và [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/). Các biểu đồ hỗ trợ có thể hiển thị khoảng trống, giá trị 0, hoặc bằng cách nối các điểm lân cận. Chọn cài đặt phù hợp với ý nghĩa của dữ liệu thiếu trong bản trình bày của bạn. Xem [Kiểm soát hiển thị các ô trống](#control-the-display-of-empty-cells) để xem ví dụ đầy đủ và so sánh hình ảnh.

**Các giá trị âm được định dạng như thế nào?**

Đối với các series thanh, cột và bubble được hỗ trợ, bật [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) và đặt [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Bạn có thể ghi đè hành vi cho một điểm riêng lẻ bằng [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Các thuộc tính này ảnh hưởng đến định dạng, không phải giá trị số được lưu.

**Khi cả series và điểm đều được định dạng, định dạng nào thắng?**

Định dạng explicit của data‑point có ưu tiên cho điểm đó. Các điểm khác vẫn sử dụng định dạng series explicit hoặc, khi series không có định dạng, dùng style và theme tự động của biểu đồ. Các thuộc tính nhóm như overlap và gap width điều khiển bố cục và không phải là ghi đè định dạng ở mức điểm.

**Có giới hạn số lượng series mà một biểu đồ có thể chứa không?**

Aspose.Slides không đặt giới hạn cố định riêng cho số series. Thực tế, các ràng buộc của file trình bày, bộ nhớ khả dụng, thời gian render và khả năng đọc biểu đồ quyết định giới hạn thực tế.

**Nên thay đổi gì khi các cột quá gần nhau hoặc quá xa?**

Đặt [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) trên nhóm series cha phù hợp. Tăng giá trị để mở rộng khoảng cách giữa các cụm, hoặc giảm để đưa các cụm lại gần nhau hơn.