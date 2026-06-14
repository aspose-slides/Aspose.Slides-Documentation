---
title: Tùy chỉnh trục biểu đồ trong trình chiếu bằng JavaScript
linktitle: Trục biểu đồ
type: docs
url: /vi/nodejs-java/chart-axis/
keywords:
- trục biểu đồ
- trục dọc
- trục ngang
- tùy chỉnh trục
- thao tác trục
- quản lý trục
- thuộc tính trục
- giá trị tối đa
- giá trị tối thiểu
- đường trục
- định dạng ngày
- tiêu đề trục
- vị trí trục
- PowerPoint
- trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Khám phá cách sử dụng JavaScript với Aspose.Slides cho Node.js thông qua Java để tùy chỉnh trục biểu đồ trong các bản trình chiếu PowerPoint cho báo cáo và trực quan hoá."
---
## **Overview**

Bài viết này giải thích cách tùy chỉnh trục biểu đồ trong Aspose.Slides. Nó cho thấy cách lấy giá trị thực tế của trục, hoán đổi dữ liệu giữa các trục, ẩn trục dọc hoặc ngang cho biểu đồ đường, thay đổi loại trục danh mục, đặt định dạng ngày cho giá trị trục danh mục, xoay tiêu đề trục, đặt vị trí trục và hiển thị nhãn đơn vị trên trục giá trị.

## **Getting the Max Values on the Vertical Axis on Charts**

Aspose.Slides for Node.js via Java cho phép bạn lấy giá trị tối thiểu và tối đa trên một trục dọc. Thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
1. Truy cập slide đầu tiên.
1. Thêm một biểu đồ với dữ liệu mặc định.
1. Lấy giá trị tối đa thực tế trên trục.
1. Lấy giá trị tối thiểu thực tế trên trục.
1. Lấy đơn vị chính thực tế của trục.
1. Lấy đơn vị phụ thực tế của trục.
1. Lấy tỷ lệ đơn vị chính thực tế của trục.
1. Lấy tỷ lệ đơn vị phụ thực tế của trục.

Mã mẫu này—các bước thực hiện ở trên—cho bạn thấy cách lấy các giá trị cần thiết trong JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
    // Lưu bản trình chiếu
    pres.save("MaxValuesVerticalAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Swapping the Data between Axes**

Aspose.Slides cho phép bạn nhanh chóng hoán đổi dữ liệu giữa các trục—dữ liệu trên trục dọc (y) di chuyển sang trục ngang (x) và ngược lại.

Mã JavaScript này cho bạn thấy cách thực hiện việc hoán đổi dữ liệu giữa các trục trên một biểu đồ:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    // Chuyển đổi hàng và cột
    chart.getChartData().switchRowColumn();
    // Lưu bản trình chiếu
    pres.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Disabling the Vertical Axis for Line Charts**

Mã JavaScript này cho bạn thấy cách ẩn trục dọc cho một biểu đồ đường:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Disabling the Horizontal Axis for Line Charts**

Mã này cho bạn thấy cách ẩn trục ngang cho một biểu đồ đường:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Changing Category Axis**

Sử dụng thuộc tính **CategoryAxisType**, bạn có thể chỉ định loại trục danh mục ưa thích (**date** hoặc **text**). Đoạn mã này trong JavaScript thể hiện hoạt động:

```javascript
var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);
    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Setting the Date Format for Category Axis Value**

Aspose.Slides for Node.js via Java cho phép bạn đặt định dạng ngày cho một giá trị trục danh mục. Hoạt động này được minh họa trong mã JavaScript này:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 450, 300);
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(java.newInstanceSync("GregorianCalendar", 2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(java.newInstanceSync("GregorianCalendar", 2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(java.newInstanceSync("GregorianCalendar", 2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(java.newInstanceSync("GregorianCalendar", 2018, 1, 1))));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
const dayjs = require('dayjs');

function convertToOADate(date) {
    const baseDate = dayjs('1899-12-30');

    const days = date.diff(baseDate, 'day');

    const fractionalDay = (date.hour() / 24) +
                          (date.minute() / (60 * 24)) +
                          (date.second() / (60 * 24 * 60));

    const oaDate = days + fractionalDay;

    return String(oaDate);
}
```

## **Setting the Rotation Angle for Chart Axis Title**

Aspose.Slides for Node.js via Java cho phép bạn đặt góc xoay cho tiêu đề trục biểu đồ. Mã JavaScript này minh họa hoạt động:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Setting the Position Axis in a Category or Value Axis**

Aspose.Slides for Node.js via Java cho phép bạn đặt vị trí trục trong một trục danh mục hoặc trục giá trị. Mã JavaScript này cho thấy cách thực hiện:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Enabling the Display Unit label on Chart Value Axis**

Aspose.Slides for Node.js via Java cho phép bạn cấu hình biểu đồ để hiển thị nhãn đơn vị trên trục giá trị của biểu đồ. Mã JavaScript này minh họa hoạt động:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**How do I set the value at which one axis crosses the other (axis crossing)?**

Các trục cung cấp một [crossing setting](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/axis/setcrosstype/): bạn có thể chọn giao cắt tại không, tại danh mục/giá trị tối đa, hoặc tại một giá trị số cụ thể. Điều này hữu ích để di chuyển trục X lên hoặc xuống hoặc để nhấn mạnh một đường cơ sở.

**How can I position tick labels relative to the axis (alongside, outside, inside)?**

Đặt [label position](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/axis/setmajortickmark/) thành "cross", "outside" hoặc "inside". Điều này ảnh hưởng đến khả năng đọc và giúp tiết kiệm không gian, đặc biệt trên các biểu đồ nhỏ.