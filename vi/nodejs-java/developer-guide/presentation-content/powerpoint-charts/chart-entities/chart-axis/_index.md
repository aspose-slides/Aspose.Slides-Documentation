---
title: Tùy chỉnh trục biểu đồ trong bản trình bày bằng JavaScript
linktitle: Trục biểu đồ
type: docs
url: /vi/nodejs-java/chart-axis/
keywords:
- trục biểu đồ
- trục dọc
- trục ngang
- tùy chỉnh trục
- điều chỉnh trục
- quản lý trục
- thuộc tính trục
- giá trị tối đa
- giá trị tối thiểu
- đường trục
- định dạng ngày
- tiêu đề trục
- vị trí trục
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Khám phá cách sử dụng JavaScript với Aspose.Slides cho Node.js thông qua Java để tùy chỉnh trục biểu đồ trong các bản trình bày PowerPoint cho báo cáo và hình ảnh minh họa."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh trục biểu đồ với Aspose.Slides cho Node.js thông qua Java. Nó bao gồm các giá trị trục đã tính toán, việc hoán đổi hàng và cột của biểu đồ, hiển thị trục, khoảng cách nhãn danh mục và dấu tick, danh mục ngày và định dạng, xoay tiêu đề, vị trí trục, đơn vị hiển thị và tỷ lệ lôgarit.

## **Lấy Giá Trị Tối Đa Trên Trục Dọc Trong Biểu Đồ**

Tạo một [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) và thêm một biểu đồ khu vực với dữ liệu mặc định. Gọi [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) trước khi đọc các giá trị trục đã tính toán để bố cục biểu đồ được cập nhật.

Đọc [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) và [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) để lấy giới hạn trục, và [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) và [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) để lấy khoảng cách dấu tick. [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) và [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) cung cấp các tỷ lệ đơn vị thời gian, có liên quan tới trục ngày. Ví dụ lưu các giá trị này vào các biến cục bộ và lưu biểu đồ.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    var majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    var majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    var minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hoán Đổi Dữ Liệu Giữa Các Trục**

Sử dụng [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) để đổi vai trò giữa series và categories trong dữ liệu biểu đồ. Mỗi category cũ sẽ trở thành một series, và mỗi series cũ sẽ trở thành một category. Điều này thay đổi cách nhóm dữ liệu; nó không hoán đổi các trục ngang và dọc. Ví dụ sử dụng [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) để ràng buộc dữ liệu mặc định vào `Sheet1!A1:D5`, bao gồm hàng tiêu đề và cột category, trước khi hoán đổi hàng và cột. Nó lưu một biểu đồ có bốn series và ba categories.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đảo Ngược Thứ Tự Vẽ Của Một Trục**

Sử dụng [setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/) để đảo ngược một trục category hoặc value. Ví dụ, một biểu đồ thanh ngang có thể hiển thị các giai đoạn dự án từ trên xuống dưới theo cùng thứ tự với bảng tính: Planning, Development, Testing. Đảo ngược trục thay đổi hướng vẽ; nó không sắp xếp hay đổi thứ tự dữ liệu trong workbook. Ngược lại, [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) đổi vai trò giữa series và categories.

Ví dụ dưới đây tạo một biểu đồ thanh ngang với ba giai đoạn và một series. Nó lưu một bản trình bày với ba slide: thứ tự bình thường, categories đảo ngược, và values đảo ngược. Mỗi bản sao sử dụng cùng tập dữ liệu, và chỉ một trục được đảo ngược trong mỗi bản sao.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredBar);
    var stages = ["Planning", "Development", "Testing"];
    var values = [10, 30, 20];
    for (var i = 0; i < stages.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // Slide 2: hiển thị danh mục đầu tiên ở trên cùng.
    var categorySlide = presentation.getSlides().addClone(slide);
    var categoryChart = categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Giữ trục giá trị ngang ở phía dưới.
    categoryChart.getAxes().getVerticalAxis().setCrossType(aspose.slides.CrossesType.Maximum);

    // Slide 3: đảo ngược chỉ thang số ngang.
    var valueSlide = presentation.getSlides().addClone(slide);
    var valueChart = valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đảo ngược một trục cũng có thể di chuyển trục vuông góc sang phía đối diện của biểu đồ. [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) điều khiển vị trí trục còn lại cắt qua trục đang cấu hình. Trong slide 2, gọi nó với `aspose.slides.CrossesType.Maximum` trên trục category đã đảo ngược sẽ giữ trục value ngang ở phía dưới. Để đặt một điểm cắt cụ thể, sử dụng [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Kiểm tra cài đặt cắt khi thay đổi hướng, đặc biệt nếu biểu đồ đã có một điểm cắt tùy chỉnh. Gọi `setPlotOrderReversed` với `false` để khôi phục hướng vẽ bình thường; cài đặt cắt là riêng biệt.

| Thứ tự bình thường (slide 1) | Categories đảo ngược (slide 2) | Values đảo ngược (slide 3) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| Categories chạy từ dưới lên trên; values tăng từ trái sang phải. | Planning, Development và Testing chạy từ trên xuống dưới. Values và thứ tự hàng trong workbook không thay đổi. | Categories giữ nguyên thứ tự bình thường; values tăng từ phải sang trái. Trục category cắt tại zero ở bên phải. |

## **Ẩn Trục Dọc Cho Biểu Đồ Đường**

Gọi [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) với `false` trên trục dọc để ẩn nó. Ví dụ tạo một biểu đồ đường với dữ liệu mặc định và lưu lại với trục dọc bị ẩn.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ẩn Trục Ngang Cho Biểu Đồ Đường**

Gọi [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) với `false` trên trục ngang để ẩn nó. Ví dụ tạo một biểu đồ đường với dữ liệu mặc định và lưu lại với trục ngang bị ẩn.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thay Đổi Trục Category**

Sử dụng [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) để chọn một trục category dạng ngày hoặc văn bản. Ví dụ này yêu cầu `ExistingChart.pptx`, với một biểu đồ là hình dạng đầu tiên trên slide đầu và các ô category chứa giá trị ngày Excel dạng số. Nó thay đổi trục ngang thành trục ngày. Gọi [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) với `false`, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) với `1`, và [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) với `TimeUnitType.Months` để đặt các dấu tick lớn ở khoảng một tháng.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kiểm Soát Khoảng Cách Nhãn Trục Category**

Khi một biểu đồ có nhiều categories, giảm số lượng nhãn trục hiển thị mà không loại bỏ các categories hoặc điểm dữ liệu. Gọi [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) với `false`, sau đó truyền khoảng cách category mong muốn vào [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/). Đối với các category dạng văn bản theo thứ tự bình thường, việc đếm bắt đầu từ category đầu tiên:

| Khoảng | Nhãn được hiển thị trong ví dụ |
| --- | --- |
| `1` | Danh mục 1, Danh mục 2, Danh mục 3, ... Danh mục 24 |
| `2` | Danh mục 1, Danh mục 3, Danh mục 5, ... Danh mục 23 |
| `3` | Danh mục 1, Danh mục 4, Danh mục 7, ... Danh mục 22 |

Khoảng `3` sẽ hiển thị mỗi nhãn thứ ba, để hai nhãn ẩn giữa các nhãn hiển thị. Nó không loại bỏ các cột tương ứng. Khoảng cách tự động chọn một khoảng dựa trên không gian khả dụng; nó không nhất thiết hiển thị mọi nhãn.

Dấu tick có các điều khiển riêng. Gọi [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) với `false` và sử dụng [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) để đặt khoảng cách của chúng. Ví dụ, `1` giữ một dấu tick ở mỗi khoảng category trong khi nhãn chỉ xuất hiện mỗi ba category. Sử dụng [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) với kiểu hiển thị để bạn có thể thấy kết quả. Gọi bất kỳ setter khoảng cách tự động nào với `true` một lần nữa sẽ cho phép biểu đồ tự chọn khoảng cách.

Ví dụ tự chứa dưới đây tạo 24 categories và một series, sau đó lưu ba slide trong `CategoryAxisIntervals.pptx`: khoảng cách tự động, khoảng cách nhãn thủ công với các dấu tick độc lập, và khôi phục khoảng cách tự động. Hai bản sao giữ nguyên dữ liệu biểu đồ gốc. Không cần bản trình bày đầu vào. Văn bản nhãn ngang làm cho sự khác biệt về mật độ dễ quan sát.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredColumn);
    for (var i = 0; i < 24; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(aspose.slides.CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(aspose.slides.TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Slide 2: hiển thị mỗi nhãn thứ ba, nhưng giữ một dấu tick cho mỗi danh mục.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Slide 3: để biểu đồ tự chọn cả hai khoảng cách một lần nữa.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatic spacing (slide 1):** Trong bản vẽ này, mỗi nhãn category thứ hai được hiển thị và xuống dòng thành hai dòng. Kết quả tự động có thể thay đổi tùy thuộc vào kích thước biểu đồ, phông chữ và bộ dựng.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Manual spacing (slide 2):** Mỗi nhãn thứ ba được hiển thị trên một dòng, trong khi các dấu tick vẫn ở mỗi khoảng category. Tất cả 24 cột, bao gồm cả những cột không có nhãn, vẫn hiển thị với cùng giá trị. Slide 3 khôi phục lại giao diện tự động được hiển thị ở trên.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **Chọn Trục và Khoảng Đúng**

Sử dụng khoảng đếm category này cho một trục category dạng văn bản, như trục category của biểu đồ cột, đường, khu vực hoặc thanh. Trong biểu đồ cột, nó là trục ngang. Trong biểu đồ thanh ngang, trục category là trục dọc, vì vậy áp dụng các cài đặt này cho trục được trả về bởi [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Khoảng cách dấu tick cũng áp dụng cho trục series trong các biểu đồ có trục series.

Không sử dụng khoảng cách nhãn category để đặt thang số của một trục value. Trên trục value, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) chỉ định sự chênh lệch giá trị: ví dụ, một đơn vị lớn `10` tạo các dấu tick tại 0, 10, 20, … khi trục bắt đầu từ zero. Khoảng nhãn category `3` thay vào đó đếm vị trí category, bất kể giá trị dữ liệu của chúng. Các biểu đồ scatter và bubble sử dụng trục value thay vì trục category dạng văn bản. Đối với trục ngày, sử dụng các đơn vị lớn và thang thời gian như mô tả trong [Change a Category Axis](#change-a-category-axis).

## **Đặt Định Dạng Ngày Cho Giá Trị Trục Category**

Ví dụ này thay thế dữ liệu biểu đồ mặc định bằng bốn giá trị hàng năm. Các ngày được lưu dưới dạng số serial OLE Automation trong worksheet đầu tiên (chỉ mục `0`), tính là số ngày kể từ ngày 30 tháng 12 năm 1899 cho các ngày này. phép tính JavaScript sử dụng timestamp UTC và chia sự chênh lệch cho 86.400.000 mili giây mỗi ngày. Sử dụng [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) với `CategoryAxisType.Date`, gọi [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) với `false`, và truyền `yyyy` vào [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) để nhãn category hiển thị năm bốn chữ số độc lập với định dạng ô.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var baseDate = Date.UTC(1899, 11, 30);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    for (var i = 0; i < 4; i++) {
        var date = Date.UTC(2015 + i, 0, 1);
        var categoryCell = workbook.getCell(0, i + 1, 0, (date - baseDate) / 86400000);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt Góc Xoay Cho Tiêu Đề Trục Biểu Đồ**

Gọi [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) với `true` trên trục dọc, cung cấp văn bản tiêu đề, và sử dụng [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) để xoay tiêu đề. Góc đo bằng độ; ví dụ này lưu một biểu đồ cột với tiêu đề trục value được xoay 90 độ.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt Vị Trí Trục Trên Trục Category Hoặc Value**

Sử dụng [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) để kiểm soát việc trục value cắt trục category giữa các category hay tại các dấu tick của category. Cài đặt này áp dụng cho các trục category. Ví dụ đặt nó thành `true` trên trục category ngang của biểu đồ cột và lưu kết quả.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt Đơn Vị Hiển Thị Trên Trục Value Của Biểu Đồ**

Sử dụng [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) để thu phóng các nhãn trên trục value mà không thay đổi dữ liệu gốc. Khi [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) được đặt thành `Millions`, một giá trị 60.000.000 sẽ hiển thị là 60. Ví dụ tạo một biểu đồ cột và áp dụng đơn vị hiển thị triệu cho trục dọc của nó.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Cấu Hình Trục Value Lôgarit**

Trục value lôgarit hữu ích khi các giá trị dương trải qua nhiều bậc magnitude. Ví dụ, một dịch vụ có thể nhận 10, 100, 1.000, 10.000 và 100.000 yêu cầu trong năm giai đoạn. Trên thang đo tuyến tính, các giá trị nhỏ hơn xuất hiện gần nhau gần zero. Thang lôgarit giúp so sánh tăng trưởng tương đối dễ hơn: khoảng cách bằng nhau đại diện cho tỷ lệ bằng nhau thay vì chênh lệch bằng nhau.

Gọi [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) với `true` trên trục value và sử dụng [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) để chọn cơ số. Điều này thay đổi cách hiển thị các giá trị hiện có; nó không thay đổi dữ liệu hoặc thêm đường xu hướng lôgarit. Đường xu hướng đại diện cho mối quan hệ khớp trong dữ liệu và là một tính năng riêng.

### **Chọn Trục Value Và Cơ Số**

Đối với biểu đồ đường hoặc cột, trục value được trả về bởi [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Đối với biểu đồ thanh ngang, nó được trả về bởi [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/). Các biểu đồ scatter và bubble có hai trục value, vì vậy chọn trục ngang cho giá trị X, trục dọc cho giá trị Y, hoặc cả hai. Không áp dụng tỷ lệ lôgarit cho trục category.

Cơ số lôgarit mặc định là `10`. Đối với biểu đồ PPTX, sử dụng cơ số từ `2` tới `1000`, bao gồm; các cơ số phân số như `2.5` cũng được hỗ trợ. Với cơ số `10`, các lũy thừa liên tiếp như 10, 100, 1.000 và 10.000 có khoảng cách đều.

### **So Sánh Thang Đường Thẳng và Lôgarit**

Ví dụ tự chứa dưới đây tạo một biểu đồ đường với năm số lượng yêu cầu trên slide đầu tiên, sau đó sao chép slide đó và bật trục value lôgarit cơ số 10 trên slide thứ hai. Cả hai slide giữ nguyên dữ liệu.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    var values = [10, 100, 1000, 10000, 100000];

    for (var i = 0; i < values.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Giữ slide đầu tiên ở dạng tuyến tính và chỉ thay đổi thang trục giá trị của bản sao.
    var logarithmicSlide = presentation.getSlides().addClone(slide);
    var logarithmicChart = logarithmicSlide.getShapes().get_Item(0);
    var valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Thang tuyến tính (slide 1):** Khoảng cách dọc bằng nhau đại diện cho chênh lệch bằng nhau trong số lượng yêu cầu. Giá trị lớn nhất chi phối biểu đồ, làm cho các giá trị nhỏ hơn khó phân biệt.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Thang lôgarit (slide 2):** Khoảng cách dọc bằng nhau đại diện cho tỷ lệ bằng nhau. Mỗi giai đoạn có số lượng yêu cầu gấp mười lần giai đoạn trước, vì vậy các điểm tạo thành một đường thẳng tăng trên thang cơ số 10. Các nhãn trục vẫn hiển thị số lượng yêu cầu gốc.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Xử Lý Giá Trị Zero và Âm**

Thang lôgarit chỉ có thể hiển thị các giá trị dương thuần túy. Kiểm tra dữ liệu trước khi bật. Nếu giá trị zero hoặc âm có ý nghĩa, giữ thang tuyến tính hoặc hiển thị chúng riêng biệt. Nếu việc loại bỏ những giá trị này phù hợp với phân tích, giải thích lý do loại bỏ. Không thay thế chúng một cách âm thầm bằng các số dương nhỏ, vì điều này thay đổi ý nghĩa của dữ liệu. Bất kỳ giá trị tối thiểu hoặc tối đa nào được cấu hình thủ công cho trục lôgarit cũng phải là dương.

## **FAQ**

**Làm sao để đặt giá trị nơi một trục cắt trục kia (điểm cắt trục)?**

Sử dụng [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) để chọn hành vi cắt. Để chỉ định một giá trị cắt số, sử dụng [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Các cài đặt này cho phép bạn di chuyển điểm cắt trục đến một đường cơ sở phù hợp.

**Làm sao để định vị nhãn dấu tick so với trục?**

Gọi [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) với [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo`, hoặc `None`. Để kiểm soát các dấu tick, sử dụng [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) hoặc [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/); chúng tách biệt với việc định vị nhãn.