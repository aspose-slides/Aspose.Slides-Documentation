---
title: Tối ưu tính toán biểu đồ cho các bản trình chiếu trong Java
linktitle: Tính toán biểu đồ
type: docs
weight: 50
url: /vi/java/chart-calculations/
keywords:
- tính toán biểu đồ
- các phần tử biểu đồ
- vị trí phần tử
- vị trí thực
- phần tử con
- phần tử cha
- giá trị biểu đồ
- giá trị thực
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Hiểu về tính toán biểu đồ, cập nhật dữ liệu và kiểm soát độ chính xác trong Aspose.Slides for Java cho PPT và PPTX, với các ví dụ mã Java thực tế."
---
## **Tổng quan**

Aspose.Slides cung cấp các API để làm việc với các phép tính biểu đồ và dữ liệu bố cục trong các bản trình chiếu. Bài viết này cho thấy cách lấy các giá trị thực của các phần tử biểu đồ, bao gồm vị trí thực và kích thước thực của các phần tử thực thi `IActualLayout` và các giá trị thực của các trục biểu đồ. Nó cũng giải thích rằng các giá trị này được điền sau khi xác thực bố cục biểu đồ.

Ngoài ra, bài viết minh họa cách lấy vị trí thực của các phần tử biểu đồ cha và cách ẩn các thành phần biểu đồ như tiêu đề, các trục, chú giải và các đường lưới. Cùng với nhau, những ví dụ này giúp bạn kiểm tra thông tin bố cục biểu đồ và điều khiển khả năng hiển thị của các phần tử biểu đồ trong các bản trình chiếu PowerPoint một cách lập trình.

## **Tính các giá trị thực của phần tử biểu đồ**
Aspose.Slides for Java cung cấp một API đơn giản để lấy các thuộc tính này. Các thuộc tính của [IAxis](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IAxis) interface cung cấp thông tin về vị trí thực của phần tử trục biểu đồ ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IAxis#getActualMinorUnitScale--)). Cần gọi phương thức [IChart.validateChartLayout()](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChart#validateChartLayout--) trước để điền các thuộc tính bằng các giá trị thực.

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    
    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    
    double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tính vị trí thực của các phần tử biểu đồ cha**
Aspose.Slides for Java cung cấp một API đơn giản để lấy các thuộc tính này. Các thuộc tính của [IActualLayout](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IActualLayout) interface cung cấp thông tin về vị trí thực của phần tử biểu đồ cha ([IActualLayout.getActualX](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IActualLayout#getActualHeight--)). Cần gọi phương thức [IChart.validateChartLayout()](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChart#validateChartLayout--) trước để điền các thuộc tính bằng các giá trị thực.

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ẩn các phần tử biểu đồ**
Chủ đề này giúp bạn hiểu cách ẩn thông tin trên biểu đồ. Sử dụng Aspose.Slides for Java, bạn có thể ẩn **Tiêu đề**, **Trục dọc**, **Trục ngang** và **Đường lưới** trên biểu đồ. Đoạn mã dưới đây cho thấy cách sử dụng các thuộc tính này.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Ẩn tiêu đề biểu đồ
    chart.setTitle(false);

    ///Ẩn trục Giá trị
    chart.getAxes().getVerticalAxis().setVisible(false);

    //Hiển thị trục danh mục
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //Ẩn chú giải
    chart.setLegend(false);

    //Ẩn các đường lưới chính
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().removeAt(i);
    }

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getMarker().setSymbol(MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);

    //Đặt màu đường chuỗi
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Các sổ làm việc Excel bên ngoài có hoạt động như nguồn dữ liệu không và điều đó ảnh hưởng như thế nào đến việc tính lại?**

Có. Một biểu đồ có thể tham chiếu đến một sổ làm việc bên ngoài: khi bạn kết nối hoặc làm mới nguồn bên ngoài, các công thức và giá trị sẽ được lấy từ sổ làm việc đó, và biểu đồ sẽ phản ánh các cập nhật trong quá trình mở/chỉnh sửa. API cho phép bạn [specify the external workbook](https://reference.aspose.com/slides/vi/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) đường dẫn và quản lý dữ liệu liên kết.

**Tôi có thể tính toán và hiển thị các đường xu hướng mà không tự triển khai hồi quy không?**

Có. [Trendlines](/slides/vi/java/trend-line/) (tuyến tính, hàm mũ và các loại khác) được Aspose.Slides thêm vào và cập nhật; các tham số của chúng được tính lại tự động từ dữ liệu chuỗi, vì vậy bạn không cần phải tự viết các phép tính.

**Nếu một bản trình chiếu có nhiều biểu đồ với liên kết bên ngoài, tôi có thể kiểm soát sổ làm việc nào mỗi biểu đồ sử dụng để tính giá trị không?**

Có. Mỗi biểu đồ có thể chỉ tới [external workbook](https://reference.aspose.com/slides/vi/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) riêng của nó, hoặc bạn có thể tạo/thay thế sổ làm việc bên ngoài cho từng biểu đồ một cách độc lập với các biểu đồ khác.