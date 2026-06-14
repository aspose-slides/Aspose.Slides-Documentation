---
title: Quản lý Series dữ liệu biểu đồ trong bản trình bày bằng .NET
linktitle: Series dữ liệu
type: docs
url: /vi/net/chart-series/
keywords:
- series biểu đồ
- chồng lấn series
- màu series
- màu danh mục
- tên series
- điểm dữ liệu
- khoảng cách series
- PowerPoint
- trình bày
- .NET
- C#
- Aspose.Slides
description: "Học cách quản lý series biểu đồ trong C# cho PowerPoint (PPT/PPTX) với các ví dụ mã thực tế và các thực tiễn tốt nhất để nâng cao các bản trình bày dữ liệu của bạn."
---
## **Tổng quan**

Bài viết này mô tả vai trò của [ChartSeries](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chartseries/) trong Aspose.Slides for .NET, tập trung vào cách dữ liệu được cấu trúc và hiển thị trong các bản trình bày. Những đối tượng này cung cấp các thành phần cơ bản xác định các tập hợp điểm dữ liệu, danh mục và tham số hiển thị riêng lẻ trong một biểu đồ. Khi làm việc với [ChartSeries](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chartseries/), các nhà phát triển có thể tích hợp nguồn dữ liệu nền một cách liền mạch và duy trì kiểm soát hoàn toàn cách thông tin được hiển thị, tạo ra các bản trình bày động, dựa trên dữ liệu, truyền tải rõ ràng các insight và phân tích.

Series là một hàng hoặc cột các số được vẽ trên biểu đồ.

![chuỗi-biểu-đồ-powerpoint](chart-series-powerpoint.png)

## **Đặt độ chồng lấn của Series biểu đồ**

Thuộc tính [IChartSeriesOverlap](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseries/properties/overlap) điều khiển cách các thanh và cột chồng lên nhau trong biểu đồ 2D bằng cách chỉ định một phạm vi từ -100 đến 100. Vì thuộc tính này liên kết với nhóm series chứ không phải từng series riêng lẻ, nên nó chỉ đọc ở mức series. Để cấu hình giá trị chồng lấn, hãy sử dụng thuộc tính `ParentSeriesGroup.Overlap` có thể đọc/ghi, thuộc tính này áp dụng độ chồng lấn đã chỉ định cho tất cả các series trong cùng một nhóm.

Dưới đây là ví dụ C# minh họa cách tạo một bản trình bày, thêm biểu đồ cột nhóm, truy cập series đầu tiên, cấu hình thiết lập chồng lấn, và sau đó lưu kết quả dưới dạng tệp PPTX:

```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Thêm biểu đồ cột nhóm với dữ liệu mặc định.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // Đặt độ chồng lấn của series.
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // Lưu tệp bản trình bày vào đĩa.
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Độ chồng lấn của series](series_overlap.png)

## **Thay đổi màu tô nền của Series**

Aspose.Slides giúp bạn dễ dàng tùy chỉnh màu tô nền của series trong biểu đồ, cho phép làm nổi bật các điểm dữ liệu cụ thể và tạo ra các biểu đồ hấp dẫn về mặt trực quan. Điều này được thực hiện qua đối tượng [IFormat](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/iformat/), hỗ trợ nhiều loại tô, cấu hình màu và các tùy chọn định dạng nâng cao khác. Sau khi thêm biểu đồ vào một slide và truy cập series mong muốn, chỉ cần lấy series và áp dụng màu tô phù hợp. Ngoài việc tô đặc, bạn còn có thể sử dụng tô gradient hoặc pattern để tăng tính linh hoạt trong thiết kế. Khi đã thiết lập màu sắc theo yêu cầu, lưu bản trình bày để hoàn thiện giao diện mới.

Đoạn mã C# dưới đây cho thấy cách thay đổi màu của series đầu tiên:

```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Thêm biểu đồ cột nhóm với dữ liệu mặc định.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Đặt màu cho series đầu tiên.
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // Lưu tệp bản trình bày vào đĩa.
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Màu của series](series_color.png)

## **Thay đổi tên Series**

Aspose.Slides cung cấp cách đơn giản để sửa đổi tên của các series trong biểu đồ, giúp gắn nhãn dữ liệu một cách rõ ràng và có ý nghĩa. Bằng cách truy cập ô tính tương ứng trong dữ liệu biểu đồ, các nhà phát triển có thể tùy chỉnh cách dữ liệu được hiển thị. Việc sửa đổi này đặc biệt hữu ích khi cần cập nhật hoặc làm rõ tên series dựa trên ngữ cảnh của dữ liệu. Sau khi đổi tên series, lưu bản trình bày để giữ lại các thay đổi.

Đoạn mã C# dưới đây minh họa quy trình này:

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Thêm biểu đồ cột nhóm với dữ liệu mặc định.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Đặt tên cho series đầu tiên.
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // Lưu tệp bản trình bày vào đĩa.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

Đoạn mã C# tiếp theo cho thấy cách thay thế khác để đổi tên series:

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Thêm biểu đồ cột nhóm với dữ liệu mặc định.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Đặt tên cho series đầu tiên.
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // Lưu tệp bản trình bày vào đĩa.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Tên series](series_name.png)

## **Lấy màu tô tự động cho Series**

Aspose.Slides for .NET cho phép bạn lấy màu tô tự động cho series trong một vùng vẽ. Sau khi tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/), bạn có thể lấy tham chiếu đến slide mong muốn theo chỉ mục, sau đó thêm một biểu đồ bằng loại bạn muốn (ví dụ `ChartType.ClusteredColumn`). Bằng cách truy cập các series trong biểu đồ, bạn có thể lấy màu tô tự động.

Đoạn mã C# dưới đây mô tả chi tiết quy trình này:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Thêm biểu đồ cột nhóm với dữ liệu mặc định.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // Lấy màu tô của series.
        Color color = chart.ChartData.Series[i].GetAutomaticSeriesColor();
        Console.WriteLine($"Series {i} color: {color.Name}");
    }
}
```

Kết quả:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **Đặt màu tô đảo ngược cho Series biểu đồ**

Khi series dữ liệu của bạn chứa cả giá trị dương và âm, việc tô tất cả cột hoặc thanh bằng cùng một màu có thể làm biểu đồ khó đọc. Aspose.Slides for .NET cho phép bạn chỉ định màu tô đảo ngược — một màu tô riêng được áp dụng tự động cho các điểm dữ liệu nằm dưới zero — để các giá trị âm nổi bật ngay lập tức. Trong phần này, bạn sẽ học cách kích hoạt tùy chọn này, chọn màu phù hợp và lưu bản trình bày đã cập nhật.

Đoạn mã sau minh họa thao tác:

```cs
Color inverColor = Color.Red;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Thêm các danh mục mới.
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // Thêm một series mới.
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Điền dữ liệu cho series.
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));

    // Đặt các thiết lập màu cho series.
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;

    presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Màu tô đặc đảo ngược](inverted_solid_fill_color.png)

Bạn cũng có thể đảo ngược màu tô cho một điểm dữ liệu duy nhất thay vì toàn bộ series. Chỉ cần truy cập `IChartDataPoint` mong muốn và đặt thuộc tính `InvertIfNegative` thành `true`.

Đoạn mã sau cho thấy cách thực hiện:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200, true);

    chart.ChartData.Series.Clear();
    IChartSeries series = chart.ChartData.Series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);

    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

    // Đảo ngược màu nếu điểm dữ liệu ở chỉ mục 2 là âm.
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```

## **Xóa giá trị điểm dữ liệu cụ thể**

Đôi khi một biểu đồ chứa các giá trị thử nghiệm, ngoại lệ hoặc mục không còn sử dụng mà bạn cần loại bỏ mà không phải xây dựng lại toàn bộ series. Aspose.Slides for .NET cho phép bạn xác định bất kỳ điểm dữ liệu nào theo chỉ mục, xóa nội dung của nó và ngay lập tức làm mới vùng vẽ để các điểm còn lại dịch chuyển và các trục tự động thay đổi tỉ lệ.

Đoạn mã sau minh họa thao tác:

```cs
using (Presentation presentation = new Presentation("test_chart.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = (IChart)slide.Shapes[0];
    IChartSeries series = chart.ChartData.Series[0];

    foreach (IChartDataPoint dataPoint in series.DataPoints)
    {
        dataPoint.XValue.AsCell.Value = null;
        dataPoint.YValue.AsCell.Value = null;
    }

    series.DataPoints.Clear();

    presentation.Save("clear_data_points.pptx", SaveFormat.Pptx);
}
```

## **Đặt độ rộng khoảng cách của Series**

Khoảng cách (gap width) điều khiển mức độ không gian trống giữa các cột hoặc thanh liền kề — khoảng cách rộng hơn làm nổi bật các danh mục riêng lẻ, trong khi khoảng cách hẹp tạo nên vẻ gọn gàng, dày đặc hơn. Thông qua Aspose.Slides for .NET, bạn có thể tinh chỉnh tham số này cho toàn bộ series, đạt được sự cân bằng trực quan chính xác mà bản trình bày của bạn cần mà không làm thay đổi dữ liệu nền.

Đoạn mã dưới đây cho thấy cách đặt độ rộng khoảng cách cho một series:

```cs
ushort gapWidth = 30;

// Tạo một bản trình bày trống.
using (Presentation presentation = new Presentation())
{
    // Truy cập slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm một biểu đồ với dữ liệu mặc định.
    IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

    // Lưu bản trình bày vào đĩa.
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // Đặt giá trị GapWidth.
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // Lưu bản trình bày vào đĩa.
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Độ rộng khoảng cách](gap_width.png)

## **FAQ**

**Có giới hạn số lượng series mà một biểu đồ đơn có thể chứa không?**

Aspose.Slides không áp đặt giới hạn cố định cho số lượng series bạn thêm vào. Giới hạn thực tế phụ thuộc vào khả năng đọc hiểu của biểu đồ và lượng bộ nhớ có sẵn cho ứng dụng của bạn.

**Nếu các cột trong một cụm quá gần nhau hoặc quá xa nhau thì sao?**

Điều chỉnh thiết lập `GapWidth` cho series đó (hoặc cho nhóm series cha). Tăng giá trị sẽ làm rộng khoảng cách giữa các cột, trong khi giảm giá trị sẽ khiến chúng gần nhau hơn.