---
title: Tối ưu tính toán biểu đồ cho bản trình chiếu trên Android
linktitle: Tính toán biểu đồ
type: docs
weight: 50
url: /vi/androidjava/chart-calculations/
keywords:
- tính toán biểu đồ
- các thành phần biểu đồ
- vị trí thành phần
- vị trí thực
- thành phần con
- thành phần cha
- giá trị biểu đồ
- giá trị thực
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Hiểu về tính toán biểu đồ, cập nhật dữ liệu và kiểm soát độ chính xác trong Aspose.Slides cho Android cho PPT và PPTX, kèm theo các ví dụ mã Java thực tiễn."
---
## **Tổng quan**

Aspose.Slides cung cấp các API để làm việc với các phép tính biểu đồ và dữ liệu bố cục trong các bản trình chiếu. Bài viết này cho thấy cách lấy các giá trị thực của các thành phần biểu đồ, bao gồm vị trí và kích thước thực của các thành phần triển khai `IActualLayout` và các giá trị thực của các trục biểu đồ. Nó cũng giải thích rằng các giá trị này được điền sau khi xác thực bố cục biểu đồ.

Ngoài ra, bài viết còn trình bày cách lấy vị trí thực của các thành phần biểu đồ cha và cách ẩn các thành phần của biểu đồ như tiêu đề, các trục, chú giải và các đường lưới. Những ví dụ này giúp bạn kiểm tra thông tin bố cục biểu đồ và kiểm soát hiển thị của các thành phần biểu đồ trong bản PowerPoint một cách lập trình.

## **Tính toán giá trị thực của các thành phần biểu đồ**
Aspose.Slides for Android qua Java cung cấp một API đơn giản để lấy các thuộc tính này. Các thuộc tính của giao diện [IAxis](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IAxis) cung cấp thông tin về vị trí thực của thành phần trục biểu đồ ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IAxis#getActualMinorUnitScale--)). Cần phải gọi phương thức [IChart.validateChartLayout()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChart#validateChartLayout--) trước để điền các thuộc tính với các giá trị thực.

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

## **Tính toán vị trí thực của các thành phần biểu đồ cha**
Aspose.Slides cho Android qua Java cung cấp một API đơn giản để lấy các thuộc tính này. Các thuộc tính của giao diện [IActualLayout](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IActualLayout) cung cấp thông tin về vị trí thực của thành phần biểu đồ cha ([IActualLayout.getActualX](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IActualLayout#getActualHeight--)). Cần phải gọi phương thức [IChart.validateChartLayout()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChart#validateChartLayout--) trước để điền các thuộc tính với các giá trị thực.

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

## **Ẩn các thành phần biểu đồ**
Chủ đề này giúp bạn hiểu cách ẩn thông tin khỏi biểu đồ. Sử dụng Aspose.Slides cho Android qua Java, bạn có thể ẩn **Tiêu đề, Trục dọc, Trục ngang** và **Đường lưới** của biểu đồ. Ví dụ mã dưới đây cho thấy cách sử dụng các thuộc tính này.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Ẩn tiêu đề biểu đồ
    chart.setTitle(false);

    ///Ẩn trục giá trị
    chart.getAxes().getVerticalAxis().setVisible(false);

    //Hiển thị trục danh mục
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //Ẩn chú giải
    chart.setLegend(false);

    //Ẩn các dòng lưới chính
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

    //Setting series line color
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Các sổ làm việc Excel bên ngoài có hoạt động như nguồn dữ liệu không, và điều đó ảnh hưởng như thế nào đến việc tính lại?**

Có. Một biểu đồ có thể tham chiếu tới một sổ làm việc bên ngoài: khi bạn kết nối hoặc làm mới nguồn bên ngoài, các công thức và giá trị sẽ được lấy từ sổ làm việc đó, và biểu đồ sẽ phản ánh các cập nhật trong quá trình mở/chỉnh sửa. API cho phép bạn [specify the external workbook](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) đường dẫn và quản lý dữ liệu liên kết.

**Tôi có thể tính và hiển thị các đường xu hướng mà không phải tự triển khai hồi quy không?**

Có. [Trendlines](/slides/vi/androidjava/trend-line/) (đường thẳng, hàm mũ và các loại khác) được Aspose.Slides thêm vào và cập nhật; các tham số của chúng được tính lại tự động từ dữ liệu chuỗi, vì vậy bạn không cần tự thực hiện các phép tính.

**Nếu một bản trình chiếu có nhiều biểu đồ với liên kết bên ngoài, tôi có thể kiểm soát sổ làm việc nào mỗi biểu đồ sử dụng để tính các giá trị không?**

Có. Mỗi biểu đồ có thể trỏ tới [external workbook](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) riêng của mình, hoặc bạn có thể tạo/thay thế một sổ làm việc bên ngoài cho mỗi biểu đồ một cách độc lập với các biểu đồ khác.