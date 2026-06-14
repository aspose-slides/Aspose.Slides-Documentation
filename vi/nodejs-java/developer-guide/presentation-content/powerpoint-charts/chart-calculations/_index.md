---
title: Tối ưu tính toán biểu đồ cho bản trình chiếu trong JavaScript
linktitle: Tính toán biểu đồ
type: docs
weight: 50
url: /vi/nodejs-java/chart-calculations/
keywords:
- tính toán biểu đồ
- thành phần biểu đồ
- vị trí thành phần
- vị trí thực tế
- thành phần con
- thành phần cha
- giá trị biểu đồ
- giá trị thực tế
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Hiểu về tính toán biểu đồ, cập nhật dữ liệu và kiểm soát độ chính xác trong Aspose.Slides cho Node.js cho PPT và PPTX, với các ví dụ mã JavaScript thực tế."
---
## **Tổng quan**

Aspose.Slides cung cấp các API để làm việc với các phép tính biểu đồ và dữ liệu bố cục trong bản trình chiếu. Bài viết này cho thấy cách lấy các giá trị thực tế của các thành phần biểu đồ, bao gồm vị trí và kích thước thực của các thành phần và các giá trị thực tế của các trục biểu đồ. Nó cũng giải thích rằng các giá trị này được điền sau khi xác thực bố cục biểu đồ.

Ngoài ra, bài viết trình bày cách lấy vị trí thực tế của các thành phần biểu đồ cha và cách ẩn các thành phần biểu đồ như tiêu đề, các trục, chú giải và các đường lưới. Cùng với nhau, các ví dụ này giúp bạn kiểm tra thông tin bố cục biểu đồ và kiểm soát khả năng hiển thị của các thành phần biểu đồ trong bản trình chiếu PowerPoint một cách lập trình.

## **Tính Giá Trị Thực Của Các Thành Phần Biểu Đồ**

Aspose.Slides for Node.js via Java cung cấp một API đơn giản để lấy các thuộc tính này. Các thuộc tính của lớp [Axis](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Axis) cung cấp thông tin về vị trí thực tế của thành phần trục biểu đồ ([Axis.getActualMaxValue](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Axis#getActualMaxValue--), [Axis.getActualMinValue](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Axis#getActualMinValue--), [Axis.getActualMajorUnit](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Axis#getActualMajorUnit--), [Axis.getActualMinorUnit](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Axis#getActualMinorUnit--), [Axis.getActualMajorUnitScale](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Axis#getActualMajorUnitScale--), [Axis.getActualMinorUnitScale](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Axis#getActualMinorUnitScale--)). Cần phải gọi phương thức [Chart.validateChartLayout()](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Chart#validateChartLayout--) trước đó để điền các thuộc tính bằng các giá trị thực tế.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tính Vị Trí Thực Của Các Thành Phần Biểu Đồ Cha**

Aspose.Slides for Node.js via Java cung cấp một API đơn giản để lấy các thuộc tính này. Các thuộc tính của lớp `ActualLayout` cung cấp thông tin về vị trí thực tế của thành phần biểu đồ cha `ActualLayout.getActualX`, `ActualLayout.getActualY`, `ActualLayout.getActualWidth`, `ActualLayout.getActualHeight`. Cần phải gọi phương thức [Chart.validateChartLayout()](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Chart#validateChartLayout--) trước đó để điền các thuộc tính bằng các giá trị thực tế.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ẩn Thông Tin Từ Biểu Đồ**

Chủ đề này giúp bạn hiểu cách ẩn thông tin khỏi biểu đồ. Sử dụng Aspose.Slides for Node.js via Java bạn có thể ẩn **Tiêu đề, Trục dọc, Trục ngang** và **Đường lưới** khỏi biểu đồ. Ví dụ mã dưới đây cho thấy cách sử dụng các thuộc tính này.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 140, 118, 320, 370);
    // Ẩn tiêu đề biểu đồ
    chart.setTitle(false);
    // /Ẩn trục giá trị
    chart.getAxes().getVerticalAxis().setVisible(false);
    // Hiển thị trục danh mục
    chart.getAxes().getHorizontalAxis().setVisible(false);
    // Ẩn chú giải
    chart.setLegend(false);
    // Ẩn các đường lưới chính
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().removeAt(i);
    }
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);
    // Đặt màu dòng chuỗi
    series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
    pres.save("HideInformationFromChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Các sổ làm việc Excel bên ngoài có hoạt động như nguồn dữ liệu không, và điều đó ảnh hưởng như thế nào đến việc tính lại?**

Có. Một biểu đồ có thể tham chiếu tới một sổ làm việc bên ngoài: khi bạn kết nối hoặc làm mới nguồn bên ngoài, các công thức và giá trị được lấy từ sổ làm việc đó, và biểu đồ phản ánh các cập nhật trong quá trình mở/chỉnh sửa. API cho phép bạn [xác định đường dẫn tới sổ làm việc bên ngoài](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) và quản lý dữ liệu được liên kết.

**Tôi có thể tính toán và hiển thị các đường xu hướng mà không tự triển khai hồi quy không?**

Có. [Các đường xu hướng](/slides/vi/nodejs-java/trend-line/) (tuyến tính, hàm mũ và các loại khác) được Aspose.Slides thêm vào và cập nhật; các tham số của chúng được tính lại tự động từ dữ liệu chuỗi, vì vậy bạn không cần phải tự triển khai các phép tính.

**Nếu một bản trình chiếu có nhiều biểu đồ với liên kết bên ngoài, tôi có thể kiểm soát sổ làm việc nào mà mỗi biểu đồ sử dụng để tính toán giá trị không?**

Có. Mỗi biểu đồ có thể trỏ tới [sổ làm việc bên ngoài](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) riêng của nó, hoặc bạn có thể tạo/thay thế một sổ làm việc bên ngoài cho từng biểu đồ một cách độc lập với các biểu đồ khác.