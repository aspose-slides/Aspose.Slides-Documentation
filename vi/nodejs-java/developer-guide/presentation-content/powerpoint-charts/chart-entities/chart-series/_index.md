---
title: Quản lý Dữ liệu Series trong Biểu đồ trên Bản trình chiếu bằng JavaScript
linktitle: Series Dữ liệu
type: docs
url: /vi/nodejs-java/chart-series/
keywords:
- series biểu đồ
- độ chồng lấp series
- màu series
- màu danh mục
- tên series
- điểm dữ liệu
- khoảng cách series
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách quản lý series biểu đồ trong JavaScript cho PowerPoint (PPT/PPTX) với các ví dụ mã thực tế và các thực tiễn tốt nhất để nâng cao các bản trình chiếu dữ liệu của bạn."
---
## **Tổng quan**

Bài viết này mô tả vai trò của [ChartSeries](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/) trong Aspose.Slides, tập trung vào cách dữ liệu được tổ chức và trực quan hoá trong các bản trình chiếu. Các đối tượng này cung cấp các yếu tố nền tảng xác định từng tập hợp các điểm dữ liệu, danh mục và các tham số hiển thị trong biểu đồ. Khi làm việc với [ChartSeries](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/), các nhà phát triển có thể dễ dàng tích hợp nguồn dữ liệu nền và duy trì kiểm soát đầy đủ cách thông tin được hiển thị, tạo ra các bản trình chiếu động, dựa trên dữ liệu và truyền đạt rõ ràng các hiểu biết và phân tích.

Một series là một hàng hoặc cột các số được vẽ trên biểu đồ.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Đặt Overlap cho Series trong Biểu đồ**

Với phương thức [ChartSeries.getOverlap](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/#getOverlap), bạn có thể chỉ định mức độ chồng lắp của các thanh và cột trên biểu đồ 2D (phạm vi: -100 đến 100). Thuộc tính này áp dụng cho tất cả các series của nhóm series cha: đây là phép chiếu của thuộc tính nhóm phù hợp. Do đó, thuộc tính này chỉ đọc.

Sử dụng thuộc tính đọc/ghi `ParentSeriesGroup.getOverlap` để đặt giá trị `Overlap` mong muốn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
1. Thêm một biểu đồ cột nhóm trên một slide.
1. Truy cập series biểu đồ đầu tiên.
1. Truy cập `ParentSeriesGroup` của series và đặt giá trị overlap mong muốn cho series.
1. Ghi bản trình chiếu đã chỉnh sửa ra file PPTX.

Đoạn mã JavaScript sau cho thấy cách đặt overlap cho một series trong biểu đồ:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Thêm biểu đồ
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0) {
        // Đặt độ chồng lấp series
        series.get_Item(0).getParentSeriesGroup().setOverlap(-30);
    }
    // Ghi file bản trình chiếu ra đĩa
    pres.save("SetChartSeriesOverlap_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Thay đổi màu của Series**

Aspose.Slides for Node.js via Java cho phép bạn thay đổi màu của một series như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
1. Thêm biểu đồ trên slide.
1. Truy cập series mà bạn muốn thay đổi màu.
1. Đặt kiểu và màu nền mong muốn.
1. Lưu bản trình chiếu đã chỉnh sửa.

Đoạn mã JavaScript sau cho thấy cách thay đổi màu của một series:

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);
    point.setExplosion(30);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Thay đổi màu của Danh mục Series**

Aspose.Slides for Node.js via Java cho phép bạn thay đổi màu của một danh mục trong series như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
1. Thêm biểu đồ trên slide.
1. Truy cập danh mục của series mà bạn muốn thay đổi màu.
1. Đặt kiểu và màu nền mong muốn.
1. Lưu bản trình chiếu đã chỉnh sửa.

Đoạn mã JavaScript sau cho thấy cách thay đổi màu của một danh mục trong series:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Thay đổi Tên của Series** 

Mặc định, tên trong chú giải cho một biểu đồ là nội dung của các ô ở trên mỗi cột hoặc hàng dữ liệu.

Trong ví dụ của chúng tôi (hình mẫu),

* các cột là *Series 1, Series 2,* và *Series 3*;
* các hàng là *Category 1, Category 2, Category 3,* và *Category 4*.

Aspose.Slides for Node.js via Java cho phép bạn cập nhật hoặc thay đổi tên của một series trong dữ liệu biểu đồ và chú giải.

Đoạn mã JavaScript sau cho thấy cách thay đổi tên của một series trong `ChartDataWorkbook` của dữ liệu biểu đồ:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Đoạn mã JavaScript sau cho thấy cách thay đổi tên của một series trong chú giải thông qua `Series`:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries().get_Item(0);
    var name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đặt Màu Đổ cho Series trong Biểu đồ**

Aspose.Slides for Node.js via Java cho phép bạn đặt màu đổ tự động cho series trong vùng vẽ biểu đồ như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một biểu đồ với dữ liệu mặc định dựa trên kiểu bạn muốn (trong ví dụ dưới, chúng tôi dùng `ChartType.ClusteredColumn`).
1. Truy cập series biểu đồ và đặt màu đổ thành Automatic.
1. Lưu bản trình chiếu ra file PPTX.

Đoạn mã JavaScript sau cho thấy cách đặt màu đổ tự động cho một series trong biểu đồ:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Tạo biểu đồ cột nhóm
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 50, 600, 400);
    // Đặt định dạng màu tự động cho series
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }
    // Ghi file bản trình chiếu ra đĩa
    pres.save("AutoFillSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đặt Màu Đổ Đảo Ngược cho Series trong Biểu đồ**

Aspose.Slides cho phép bạn đặt màu đổ đảo ngược cho series trong vùng vẽ biểu đồ như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một biểu đồ với dữ liệu mặc định dựa trên kiểu bạn muốn (trong ví dụ dưới, chúng tôi dùng `ChartType.ClusteredColumn`).
1. Truy cập series biểu đồ và đặt màu đổ thành invert.
1. Lưu bản trình chiếu ra file PPTX.

Đoạn mã JavaScript sau minh họa thao tác:

```javascript
var inverColor = java.getStaticFieldValue("java.awt.Color", "RED");
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Thêm series và danh mục mới
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));
    // Lấy series biểu đồ đầu tiên và điền dữ liệu series cho nó.
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    var seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    pres.save("SetInvertFillColorChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đặt Series Đảo Khi Giá Trị Là Negơtive**

Aspose.Slides cho phép bạn thiết lập đảo ngược thông qua phương thức `ChartDataPoint.setInvertIfNegative`. Khi đảo ngược được thiết lập bằng các thuộc tính, điểm dữ liệu sẽ đổi màu khi nhận giá trị âm.

Đoạn mã JavaScript sau minh họa thao tác:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();
    var chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));
    chartSeries.setInvertIfNegative(false);
    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Xóa Dữ liệu của Các Điểm Dữ liệu Cụ Thể**

Aspose.Slides for Node.js via Java cho phép bạn xóa dữ liệu `DataPoints` cho một series cụ thể trong biểu đồ như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
3. Lấy tham chiếu tới một biểu đồ bằng chỉ mục của nó.
4. Duyệt qua tất cả `DataPoints` của biểu đồ và đặt `XValue` và `YValue` thành null.
5. Xóa toàn bộ `DataPoints` cho series biểu đồ cụ thể.
6. Ghi bản trình chiếu đã chỉnh sửa ra file PPTX.

Đoạn mã JavaScript sau minh họa thao tác:

```javascript
var pres = new aspose.slides.Presentation("TestChart.pptx");
try {
    var sl = pres.getSlides().get_Item(0);
    var chart = sl.getShapes().get_Item(0);
    for (let i = 0; i < chart.getChartData().getSeries().get_Item(0).getDataPoints().size(); i++) {
        let dataPoint = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(i);
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }
    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();
    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đặt Khoảng Cách Giữa Các Series (Gap Width)**

Aspose.Slides for Node.js via Java cho phép bạn đặt **`GapWidth`** cho một series như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
1. Truy cập slide đầu tiên.
1. Thêm biểu đồ với dữ liệu mặc định.
1. Truy cập bất kỳ series nào của biểu đồ.
1. Đặt thuộc tính `GapWidth`.
1. Ghi bản trình chiếu đã chỉnh sửa ra file PPTX.

Đoạn mã JavaScript sau cho thấy cách đặt Gap Width cho một series:

```javascript
// Tạo bản trình chiếu trống
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên của bản trình chiếu
    var slide = pres.getSlides().get_Item(0);
    // Thêm biểu đồ với dữ liệu mặc định
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 0, 0, 500, 500);
    // Đặt chỉ số của bảng dữ liệu biểu đồ
    var defaultWorksheetIndex = 0;
    // Lấy worksheet dữ liệu biểu đồ
    var fact = chart.getChartData().getChartDataWorkbook();
    // Thêm series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Thêm danh mục
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Lấy series biểu đồ thứ hai
    var series = chart.getChartData().getSeries().get_Item(1);
    // Điền dữ liệu cho series
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Đặt giá trị GapWidth
    series.getParentSeriesGroup().setGapWidth(50);
    // Lưu bản trình chiếu ra đĩa
    pres.save("GapWidth_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Có giới hạn nào về số lượng series mà một biểu đồ có thể chứa không?**

Aspose.Slides không đặt giới hạn cố định cho số lượng series bạn thêm. Giới hạn thực tế phụ thuộc vào khả năng đọc biểu đồ và bộ nhớ khả dụng cho ứng dụng của bạn.

**Nếu các cột trong một cụm quá gần nhau hoặc quá xa nhau thì phải làm gì?**

Điều chỉnh cài đặt Gap Width cho series đó (hoặc nhóm series cha). Tăng giá trị sẽ làm rộng khoảng cách giữa các cột, giảm giá trị sẽ làm chúng gần nhau hơn.