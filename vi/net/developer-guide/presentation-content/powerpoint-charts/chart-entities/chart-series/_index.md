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
description: "Tìm hiểu cách quản lý chuỗi biểu đồ, điểm dữ liệu, các ô trong sổ làm việc, định dạng, chồng chéo, độ rộng khoảng trống và các giá trị âm trong bản trình chiếu bằng C#."
---
## **Tổng quan**

Một biểu đồ lưu trữ dữ liệu đã vẽ trong một sổ làm việc dữ liệu biểu đồ. Một [IChartSeries](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseries/) đại diện cho một tập hợp các giá trị liên quan, và mỗi [IChartDataPoint](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatapoint/) trong chuỗi tham chiếu tới một hoặc nhiều ô trong sổ làm việc. Các đối tượng [IChartCategory](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartcategory/) cung cấp các nhãn hoặc giá trị nhóm được chia sẻ bởi các chuỗi. Vì vậy, tên chuỗi, các danh mục và giá trị điểm được kết nối với các đối tượng [IChartDataCell](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/) thay vì chỉ được lưu dưới dạng văn bản hiển thị.

Đối với một biểu đồ danh mục điển hình, sổ làm việc mặc định sử dụng hàng 0 cho tên chuỗi, cột 0 cho tên danh mục và các ô còn lại cho giá trị chuỗi. Các chỉ mục worksheet, hàng và cột được truyền vào [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/getcell/) là dựa trên chỉ số 0. Bố cục này hữu ích khi bạn tạo biểu đồ với dữ liệu mặc định, nhưng không nên cho rằng mọi biểu đồ hiện có đều sử dụng nó. Đối với một bản trình bày đã tải, hãy kiểm tra các ô được chuỗi, danh mục và các điểm dữ liệu tham chiếu trước khi thay đổi giá trị sổ làm việc.

Cài đặt biểu đồ có ba phạm vi khác nhau:

- Cài đặt mức chuỗi, chẳng hạn như [IChartSeries.Format](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseries/format/), cung cấp giao diện mặc định cho tất cả các điểm trong một chuỗi.
- Cài đặt mức điểm dữ liệu, chẳng hạn như [IChartDataPoint.Format](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatapoint/format/), ghi đè giao diện chuỗi cho một điểm.
- Cài đặt nhóm áp dụng cho các chuỗi tương thích thuộc cùng một [IChartSeriesGroup](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseriesgroup/). Truy cập nhóm qua [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseries/parentseriesgroup/) khi bạn cần đặt các tùy chọn như độ chồng chéo hoặc độ rộng khoảng trống.

Khi không có màu nền điểm hoặc chuỗi nào được đặt một cách rõ ràng, kiểu biểu đồ và chủ đề sẽ quyết định giao diện tự động. Khi cả định dạng chuỗi và điểm đều tồn tại, định dạng điểm sẽ có ưu tiên cho điểm đó.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Đặt Chồng Chéo Chuỗi Biểu Đồ**

[IChartSeries.Overlap](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseries/overlap/) báo cáo mức độ các thanh hoặc cột chồng lên nhau trong biểu đồ 2D, từ -100 tới 100 phần trăm. Đây là một phép chiếu chỉ đọc của cài đặt trên nhóm chuỗi cha. Đặt [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseriesgroup/overlap/) để cập nhật mọi chuỗi tương thích trong nhóm đó. Tùy chọn này áp dụng cho các loại biểu đồ hiển thị các thanh hoặc cột được nhóm lại; nó không ảnh hưởng đến các nhóm chuỗi không liên quan trong biểu đồ kết hợp.

Ví dụ sau đặt độ chồng chéo cho nhóm chứa chuỗi đầu tiên:

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

## **Thay Đổi Màu Nền Chuỗi**

Sử dụng [IChartSeries.Format](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseries/format/) để đặt màu nền mặc định cho toàn bộ chuỗi. Nếu một điểm đã có màu nền rõ ràng, cài đặt [IChartDataPoint.Format](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatapoint/format/) của nó sẽ ghi đè màu nền chuỗi cho điểm đó.

Ví dụ sau áp dụng màu nền xanh đậm đặc cho chuỗi đầu tiên:

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

## **Thay Đổi Tên Chuỗi**

Tên chuỗi được lưu trong sổ làm việc dữ liệu biểu đồ và thường được hiển thị trong chú giải. Trong sổ làm việc mặc định được tạo cho biểu đồ cột cụm, ô B1 nằm ở hàng 0, cột 1 và chứa tên của chuỗi đầu tiên. Các hằng số được đặt tên trong ví dụ sau làm rõ cấu trúc này:

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

Bạn cũng có thể cập nhật ô đã được [IChartSeries.Name](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseries/name/) tham chiếu. Cách tiếp cận này tránh việc giả định một hàng và cột cụ thể trong biểu đồ hiện có:

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

## **Lấy Màu Nền Tự Động Của Chuỗi**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) trả về màu được tính dựa trên chỉ mục chuỗi và kiểu biểu đồ. Đây là màu được sử dụng khi màu nền chuỗi không được định nghĩa một cách rõ ràng. Gọi phương thức này chỉ đọc màu đã tính; nó không gán màu nền mới.

Ví dụ sau in màu tự động của mỗi chuỗi mặc định:

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

Đầu ra ví dụ cho kiểu biểu đồ mặc định:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Màu sắc cụ thể phụ thuộc vào kiểu biểu đồ và chủ đề.

## **Đặt Màu Nền Đảo Ngược Cho Một Chuỗi Biểu Đồ**

Đối với các chuỗi thanh, cột và bong bóng, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseries/invertifnegative/) có thể hiển thị các giá trị âm bằng một màu nền khác. Đặt màu nền chuỗi thường thành đặc, bật tính năng đảo ngược, và gán màu cho giá trị âm qua [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Các số âm vẫn giữ nguyên trong sổ làm việc; chỉ màu hiển thị của chúng thay đổi.

Ví dụ sau thay thế dữ liệu biểu đồ mặc định bằng một chuỗi. Hàng 0 của worksheet chứa tên chuỗi, cột 0 chứa tên danh mục, và cột 1 chứa các giá trị:

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

Bạn có thể bật đảo ngược cho một điểm thông qua [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Trong ví dụ sau, tính năng đảo ngược bị tắt cho chuỗi và chỉ được bật cho điểm đã chọn. Điểm này cũng được gán một giá trị âm để hiệu ứng hiển thị:

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

## **Xóa Giá Trị Điểm Dữ Liệu Cụ Thể**

Để làm cho một điểm trở nên trống mà không xóa các điểm khác, đặt ô sổ làm việc hỗ trợ của nó thành `null`. Đối với biểu đồ cột, giá trị đã vẽ có thể truy cập qua [IChartDataPoint.YValue](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatapoint/yvalue/). Điểm dữ liệu vẫn giữ vị trí danh mục, nhưng biểu đồ sẽ coi giá trị của nó là trống theo cài đặt về giá trị trống của biểu đồ.

Ví dụ sau xóa chỉ điểm thứ hai trong chuỗi đầu tiên:

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

Biểu đồ phân tán sử dụng các ô X và Y riêng biệt, và biểu đồ bong bóng còn sử dụng một ô kích thước. Chỉ xóa ô đại diện cho giá trị bạn muốn loại bỏ. Không gọi [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatapointcollection/clear/) khi bạn muốn giữ các điểm còn lại, vì phương thức này sẽ xóa mọi điểm dữ liệu trong bộ sưu tập.

## **Đặt Độ Rộng Khoảng Trống Giữa Các Chuỗi**

Độ rộng khoảng trống là khoảng cách giữa các cụm thanh hoặc cột liền kề, được biểu thị dưới dạng phần trăm của chiều rộng thanh hoặc cột. Giống như độ chồng chéo, nó thuộc về nhóm chuỗi cha chứ không phải một chuỗi riêng lẻ. Đặt [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) một lần cho nhóm. Giá trị lớn hơn tạo ra nhiều không gian hơn giữa các cụm; giá trị nhỏ hơn làm chúng dày đặc hơn.

Ví dụ sau thay đổi độ rộng khoảng trống và chỉ lưu bản trình bày cuối cùng:

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

## **Câu Hỏi Thường Gặp**

**Các loại biểu đồ nào hỗ trợ chuỗi dữ liệu?**

Tất cả các loại biểu đồ được biểu diễn bằng enumeration [ChartType](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/charttype/) đều sử dụng dữ liệu biểu đồ, nhưng các chuỗi của chúng không phải luôn có cùng cấu trúc giá trị hoặc cùng cài đặt. Ví dụ, biểu đồ danh mục sử dụng danh mục và giá trị, biểu đồ phân tán sử dụng giá trị X và Y, và biểu đồ bong bóng còn thêm kích thước bong bóng. Hãy dùng phương pháp tạo điểm dữ liệu phù hợp với loại chuỗi. Các tùy chọn như độ chồng chéo và độ rộng khoảng trống chỉ áp dụng cho các nhóm thanh hoặc cột tương thích.

**Một nhóm chuỗi biểu đồ là gì?**

Một [IChartSeriesGroup](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseriesgroup/) chứa các chuỗi tương thích chia sẻ các cài đặt vẽ ở mức nhóm. Một biểu đồ kết hợp có thể chứa nhiều hơn một nhóm, vì vậy việc thay đổi nhóm thông qua một chuỗi không nhất thiết thay đổi mọi chuỗi trong biểu đồ.

**Biểu đồ mới tạo có chứa dữ liệu mặc định không?**

Có. Theo mặc định, [IShapeCollection.AddChart](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/addchart/) tạo các chuỗi, danh mục và giá trị mẫu. Bạn có thể chỉnh sửa các ô này hoặc xóa cả bộ sưu tập chuỗi và danh mục trước khi thêm một bộ dữ liệu tùy chỉnh hoàn toàn. Một overload cũng có thể tạo biểu đồ mà không có dữ liệu mặc định.

**Các đối tượng biểu đồ được kết nối với các ô trong sổ làm việc như thế nào?**

Tên chuỗi, nhãn danh mục và giá trị điểm dữ liệu tham chiếu tới các ô trong một [IChartDataWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/). Thay đổi một ô được tham chiếu sẽ cập nhật phần tử biểu đồ tương ứng. Khi bạn xây dựng dữ liệu tùy chỉnh, hãy giữ các hàng danh mục và các hàng giá trị chuỗi đồng bộ để mỗi điểm được vẽ dưới danh mục dự kiến.

**Làm sao để xóa một điểm mà không xóa toàn bộ chuỗi?**

Đặt ô giá trị tương ứng thành `null` để giữ vị trí danh mục của điểm như một điểm trống. Chỉ sử dụng [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatapointcollection/clear/) khi bạn muốn xóa tất cả các điểm trong chuỗi đó. Nếu bạn cũng xóa các danh mục, hãy cập nhật mọi chuỗi sao cho giá trị của chúng vẫn đồng bộ với bộ sưu tập danh mục.

**Các điểm trống được hiển thị như thế nào?**

Kết quả phụ thuộc vào loại biểu đồ và [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichart/displayblanksas/). Các biểu đồ hỗ trợ có thể hiển thị điểm trống dưới dạng khoảng trống, giá trị 0, hoặc bằng cách nối các điểm liền kề. Chọn cài đặt phù hợp với ý nghĩa của dữ liệu thiếu trong bản trình bày của bạn.

**Các giá trị âm được định dạng như thế nào?**

Đối với các chuỗi thanh, cột và bong bóng được hỗ trợ, bật [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseries/invertifnegative/) và đặt [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Bạn có thể ghi đè hành vi cho một điểm riêng lẻ bằng [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Các thuộc tính này ảnh hưởng đến định dạng, không phải giá trị số lưu trữ.

**Thuộc tính định dạng nào thắng khi cả chuỗi và điểm đều được định dạng?**

Định dạng điểm dữ liệu rõ ràng sẽ có ưu tiên cho điểm đó. Các điểm khác vẫn dùng định dạng chuỗi rõ ràng hoặc, nếu chuỗi không có định dạng, sẽ dùng kiểu biểu đồ và chủ đề tự động. Các thuộc tính nhóm như độ chồng chéo và độ rộng khoảng trống kiểm soát bố cục và không phải là sự ghi đè định dạng mức điểm.

**Có giới hạn số lượng chuỗi mà một biểu đồ có thể chứa không?**

Aspose.Slides không áp đặt một giới hạn cố định riêng biệt cho số chuỗi. Trong thực tế, các ràng buộc của tệp bản trình bày, bộ nhớ khả dụng, thời gian render và khả năng đọc biểu đồ sẽ quyết định mức giới hạn thực tế.

**Tôi nên thay đổi gì khi các cột quá gần nhau hoặc quá xa nhau?**

Đặt [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) trên nhóm chuỗi cha thích hợp. Tăng giá trị để mở rộng không gian giữa các cụm, hoặc giảm giá trị để các cụm lại gần nhau hơn.