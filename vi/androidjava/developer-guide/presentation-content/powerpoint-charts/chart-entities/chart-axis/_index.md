---
title: Tùy chỉnh trục biểu đồ trong bản trình bày trên Android
linktitle: Trục Biểu Đồ
type: docs
url: /vi/androidjava/chart-axis/
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
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Khám phá cách sử dụng Aspose.Slides cho Android qua Java để tùy chỉnh trục biểu đồ trong bản trình bày PowerPoint cho báo cáo và trực quan hoá."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh trục biểu đồ trong Aspose.Slides. Nó cho thấy cách lấy giá trị thực tế của trục, hoán đổi dữ liệu giữa các trục, ẩn trục dọc hoặc trục ngang cho biểu đồ đường, thay đổi loại trục danh mục, đặt định dạng ngày cho các giá trị trục danh mục, xoay tiêu đề trục, đặt vị trí trục và hiển thị nhãn đơn vị trên trục giá trị.

## **Lấy các giá trị tối đa trên trục dọc của biểu đồ**
Aspose.Slides for Android via Java cho phép bạn lấy giá trị tối thiểu và tối đa trên trục dọc. Thực hiện các bước sau:

1. Tạo một thực thể của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
1. Truy cập slide đầu tiên.
1. Thêm biểu đồ với dữ liệu mặc định.
1. Lấy giá trị tối đa thực tế trên trục.
1. Lấy giá trị tối thiểu thực tế trên trục.
1. Lấy đơn vị chính thực tế của trục.
1. Lấy đơn vị phụ thực tế của trục.
1. Lấy thang đo đơn vị chính thực tế của trục.
1. Lấy thang đo đơn vị phụ thực tế của trục.

Mã mẫu—một triển khai của các bước trên—cho bạn thấy cách lấy các giá trị cần thiết trong Java:

```java
Presentation pres = new Presentation();
try {
	Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
	chart.validateChartLayout();

	double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
	double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

	double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
	double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();

	// Lưu bản trình bày
	pres.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Hoán đổi dữ liệu giữa các trục**
Aspose.Slides cho phép bạn nhanh chóng hoán đổi dữ liệu giữa các trục—dữ liệu trên trục dọc (y‑axis) chuyển sang trục ngang (x‑axis) và ngược lại.

Mã Java này cho bạn thấy cách thực hiện việc hoán đổi dữ liệu giữa các trục trên biểu đồ:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//Chuyển đổi hàng và cột
	// Lưu bản trình bày
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Vô hiệu hoá trục dọc cho biểu đồ đường**

Mã Java này cho bạn thấy cách ẩn trục dọc cho biểu đồ đường:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getVerticalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Vô hiệu hoá trục ngang cho biểu đồ đường**

Mã này cho bạn thấy cách ẩn trục ngang cho biểu đồ đường:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getHorizontalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Thay đổi trục danh mục**

Bằng thuộc tính **CategoryAxisType**, bạn có thể chỉ định loại trục danh mục ưa thích (**date** hoặc **text**). Đoạn mã Java dưới đây minh họa thao tác này:

```java
Presentation presentation = new Presentation("ExistingChart.pptx");
try {
	IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
	chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
	chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
	chart.getAxes().getHorizontalAxis().setMajorUnit(1);
	chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);
	presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

## **Đặt định dạng ngày cho các giá trị trục danh mục**
Aspose.Slides for Android via Java cho phép bạn đặt định dạng ngày cho một giá trị trục danh mục. Thao tác được trình bày trong đoạn mã Java này:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
	
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
public static String convertToOADate(GregorianCalendar date) throws ParseException
{
    double oaDate;
    SimpleDateFormat myFormat = new SimpleDateFormat("dd MM yyyy");
    java.util.Date baseDate = myFormat.parse("30 12 1899");
    Long days = TimeUnit.DAYS.convert(date.getTimeInMillis() - baseDate.getTime(), TimeUnit.MILLISECONDS);
    oaDate = (double) days + ((double) date.get(Calendar.HOUR_OF_DAY) / 24) + ((double) date.get(Calendar.MINUTE) / (60 * 24)) + ((double) date.get(Calendar.SECOND) / (60 * 24 * 60));
    return String.valueOf(oaDate);
}
```

## **Đặt góc xoay cho tiêu đề trục biểu đồ**
Aspose.Slides for Android via Java cho phép bạn đặt góc xoay cho tiêu đề trục biểu đồ. Đoạn mã Java này minh họa thao tác:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Đặt vị trí trục trên trục danh mục hoặc giá trị**
Aspose.Slides for Android via Java cho phép bạn đặt vị trí trục trong một trục danh mục hoặc giá trị. Đoạn mã Java này cho bạn thấy cách thực hiện:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bật hiển thị nhãn đơn vị trên trục giá trị của biểu đồ**
Aspose.Slides for Android via Java cho phép bạn cấu hình biểu đồ để hiển thị nhãn đơn vị trên trục giá trị của nó. Đoạn mã Java này minh họa thao tác:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Làm thế nào để thiết lập giá trị tại điểm hai trục giao nhau (giao cắt trục)?**

Các trục cung cấp một [cài đặt giao cắt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/axis/#setCrossType-int-): bạn có thể chọn giao cắt ở giá trị zero, ở giá trị danh mục/giá trị tối đa, hoặc ở một giá trị số cụ thể. Tùy chọn này hữu ích để di chuyển trục X lên hoặc xuống hoặc để nhấn mạnh một đường cơ sở.

**Làm thế nào để đặt vị trí nhãn đánh dấu so với trục (bên cạnh, bên ngoài, bên trong)?**

Đặt [vị trí nhãn](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) thành "cross", "outside", hoặc "inside". Điều này ảnh hưởng đến khả năng đọc và giúp tiết kiệm không gian, đặc biệt trên các biểu đồ nhỏ.