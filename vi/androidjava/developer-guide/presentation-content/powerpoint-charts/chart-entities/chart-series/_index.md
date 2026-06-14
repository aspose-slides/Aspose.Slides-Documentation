---
title: Quản lý Series dữ liệu biểu đồ trong bài thuyết trình trên Android
linktitle: Series dữ liệu
type: docs
url: /vi/androidjava/chart-series/
keywords:
- series biểu đồ
- chồng lấp series
- màu series
- màu danh mục
- tên series
- điểm dữ liệu
- khoảng trống series
- PowerPoint
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách quản lý series biểu đồ trên Android cho PowerPoint (PPT/PPTX) với các ví dụ mã Java thực tế và các phương pháp hay nhất để nâng cao các bài thuyết trình dữ liệu của bạn."
---
## **Tổng quan**

Bài viết này mô tả vai trò của [ChartSeries](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/chartseries/) trong Aspose.Slides, tập trung vào cách dữ liệu được cấu trúc và trực quan hóa trong các bài thuyết trình. Những đối tượng này cung cấp các yếu tố nền tảng xác định từng tập hợp điểm dữ liệu, danh mục và các tham số hiển thị trong biểu đồ. Khi làm việc với [ChartSeries](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/chartseries/), các nhà phát triển có thể tích hợp liền mạch các nguồn dữ liệu nền và duy trì kiểm soát hoàn toàn cách thông tin được hiển thị, tạo ra các bài thuyết trình động, dựa trên dữ liệu, truyền tải rõ ràng những hiểu biết và phân tích.

Một series là một hàng hoặc cột các số được vẽ trên biểu đồ.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Thiết lập chồng lấp Series biểu đồ**

Với phương thức [IChartSeries.getOverlap](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartseries/#getOverlap--) bạn có thể xác định mức độ các thanh và cột chồng lên nhau trên biểu đồ 2D (phạm vi: -100 tới 100). Thuộc tính này áp dụng cho tất cả các series của nhóm series cha: đây là một phép chiếu của thuộc tính nhóm tương ứng. Do đó, thuộc tính này chỉ đọc.

Sử dụng phương thức ghi `getParentSeriesGroup().setOverlap()` để đặt giá trị chồng lấp mong muốn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
1. Thêm một biểu đồ cột cụm vào một slide.
1. Truy cập series biểu đồ đầu tiên.
1. Truy cập `ParentSeriesGroup` của series và đặt giá trị chồng lấp mong muốn cho series.
1. Ghi bài thuyết trình đã sửa đổi ra tệp PPTX.

Đoạn mã Java sau cho thấy cách thiết lập chồng lấp cho một series biểu đồ:

```java
Presentation pres = new Presentation();
try {
    // Thêm biểu đồ
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Đặt chồng lấp series
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // Ghi tệp bài thuyết trình ra đĩa
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thay đổi màu Series**

Aspose.Slides for Android via Java cho phép bạn thay đổi màu của một series theo cách sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
1. Thêm biểu đồ vào slide.
1. Truy cập series mà bạn muốn thay đổi màu.
1. Đặt kiểu nền và màu nền mong muốn.
1. Lưu bài thuyết trình đã sửa đổi.

Đoạn mã Java sau cho thấy cách thay đổi màu của một series:

```java
Presentation pres = new Presentation("test.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);

    point.setExplosion(30);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thay đổi màu Danh mục Series**

Aspose.Slides for Android via Java cho phép bạn thay đổi màu của một danh mục series theo cách sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
1. Thêm biểu đồ vào slide.
1. Truy cập danh mục series mà bạn muốn thay đổi màu.
1. Đặt kiểu nền và màu nền mong muốn.
1. Lưu bài thuyết trình đã sửa đổi.

Đoạn mã Java sau cho thấy cách thay đổi màu của một danh mục series:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);

    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thay đổi Tên Series**

Mặc định, tên trong chú giải của biểu đồ được lấy từ nội dung các ô ở trên mỗi cột hoặc hàng dữ liệu.

Trong ví dụ của chúng tôi (hình mẫu),

* các cột là *Series 1, Series 2,* và *Series 3*;
* các hàng là *Category 1, Category 2, Category 3,* và *Category 4*.

Aspose.Slides for Android via Java cho phép bạn cập nhật hoặc thay đổi tên series trong dữ liệu biểu đồ và chú giải của nó.

Đoạn mã Java sau cho thấy cách thay đổi tên series trong `ChartDataWorkbook` của dữ liệu biểu đồ:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Đoạn mã Java sau cho thấy cách thay đổi tên series trong chú giải thông qua `Series`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) pres.dispose();
}
```

## **Đặt màu nền tự động cho Series biểu đồ**

Aspose.Slides for Android via Java cho phép bạn đặt màu nền tự động cho series biểu đồ trong vùng vẽ biểu đồ theo cách sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
1. Lấy tham chiếu đến slide theo chỉ số của nó.
1. Thêm một biểu đồ với dữ liệu mặc định dựa trên loại bạn muốn (trong ví dụ dưới, chúng tôi dùng `ChartType.ClusteredColumn`).
1. Truy cập series biểu đồ và đặt màu nền thành Automatic.
1. Lưu bài thuyết trình ra tệp PPTX.

Đoạn mã Java sau cho thấy cách đặt màu nền tự động cho một series biểu đồ:

```java
Presentation pres = new Presentation();
try {
    // Tạo biểu đồ cột cụm
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Đặt định dạng màu nền series thành tự động
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // Ghi tệp bài thuyết trình ra đĩa
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Đặt màu nền đảo ngược cho Series biểu đồ**

Aspose.Slides cho phép bạn đặt màu nền đảo ngược cho series biểu đồ trong vùng vẽ biểu đồ theo cách sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
1. Lấy tham chiếu đến slide theo chỉ số của nó.
1. Thêm một biểu đồ với dữ liệu mặc định dựa trên loại bạn muốn (trong ví dụ dưới, chúng tôi dùng `ChartType.ClusteredColumn`).
1. Truy cập series biểu đồ và đặt màu nền thành invert.
1. Lưu bài thuyết trình ra tệp PPTX.

Đoạn mã Java sau minh họa thao tác này:

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Thêm series và danh mục mới
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // Lấy series biểu đồ đầu tiên và điền dữ liệu cho series.
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    Color seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    
    pres.save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Đặt Series đảo ngược khi Giá trị là Âm**

Aspose.Slides cho phép bạn thiết lập chế độ đảo ngược thông qua thuộc tính `IChartDataPoint.InvertIfNegative` và `ChartDataPoint.InvertIfNegative`. Khi thiết lập đảo ngược bằng các thuộc tính này, điểm dữ liệu sẽ thay đổi màu khi nhận giá trị âm.

Đoạn mã Java sau minh họa thao tác này:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();

    IChartSeries chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));

    chartSeries.setInvertIfNegative(false);

    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);

    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Xóa Dữ liệu Điểm Cụ thể**

Aspose.Slides for Android via Java cho phép bạn xóa dữ liệu `DataPoints` cho một series biểu đồ cụ thể theo cách sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của slide qua chỉ số của nó.
3. Lấy tham chiếu của biểu đồ qua chỉ số của nó.
4. Duyệt tất cả `DataPoints` của biểu đồ và đặt `XValue` và `YValue` thành null.
5. Xóa toàn bộ `DataPoints` cho series biểu đồ cụ thể.
6. Ghi bài thuyết trình đã sửa đổi ra tệp PPTX.

Đoạn mã Java sau minh họa thao tác này:

```java
Presentation pres = new Presentation("TestChart.pptx");
try {
    ISlide sl = pres.getSlides().get_Item(0);

    IChart chart = (IChart)sl.getShapes().get_Item(0);

    for (IChartDataPoint dataPoint : chart.getChartData().getSeries().get_Item(0).getDataPoints())
    {
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }

    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Đặt Độ rộng Khoảng trống của Series**

Aspose.Slides for Android via Java cho phép bạn thiết lập Độ rộng Khoảng trống (`GapWidth`) của một series thông qua thuộc tính **`GapWidth`** theo cách sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
1. Truy cập slide đầu tiên.
1. Thêm biểu đồ với dữ liệu mặc định.
1. Truy cập bất kỳ series nào của biểu đồ.
1. Đặt thuộc tính `GapWidth`.
1. Ghi bài thuyết trình đã sửa đổi ra tệp PPTX.

Đoạn mã Java sau cho thấy cách thiết lập Độ rộng Khoảng trống cho một series:

```java
// Tạo bài thuyết trình trống
Presentation pres = new Presentation();
try {
    // Truy cập slide đầu tiên của bài thuyết trình
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Thêm biểu đồ với dữ liệu mặc định
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // Đặt chỉ mục của bảng dữ liệu biểu đồ
    int defaultWorksheetIndex = 0;
    
    // Lấy worksheet dữ liệu biểu đồ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Thêm series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Thêm danh mục
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Lấy series biểu đồ thứ hai
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Đổ dữ liệu cho series
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Đặt giá trị GapWidth
    series.getParentSeriesGroup().setGapWidth(50);
    
    // Lưu bài thuyết trình ra đĩa
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Có giới hạn về số lượng series mà một biểu đồ có thể chứa không?**

Aspose.Slides không áp đặt mức giới hạn cố định cho số series bạn thêm. Giới hạn thực tế phụ thuộc vào khả năng đọc của biểu đồ và lượng bộ nhớ có sẵn cho ứng dụng của bạn.

**Nếu các cột trong một cụm quá gần nhau hoặc quá xa nhau thì phải làm gì?**

Điều chỉnh cài đặt `GapWidth` cho series đó (hoặc cho nhóm series cha). Tăng giá trị sẽ làm rộng khoảng cách giữa các cột, giảm giá trị sẽ làm chúng gần nhau hơn.