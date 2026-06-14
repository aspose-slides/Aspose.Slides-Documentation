---
title: Tùy chỉnh trục biểu đồ trong bản trình bày bằng Java
linktitle: Trục biểu đồ
type: docs
url: /vi/java/chart-axis/
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
- Java
- Aspose.Slides
description: "Khám phá cách sử dụng Aspose.Slides cho Java để tùy chỉnh trục biểu đồ trong bản trình bày PowerPoint cho báo cáo và trực quan hóa."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh trục biểu đồ trong Aspose.Slides. Nó cho thấy cách lấy giá trị thực tế của trục, hoán đổi dữ liệu giữa các trục, ẩn trục dọc hoặc ngang cho biểu đồ đường, thay đổi loại trục danh mục, đặt định dạng ngày cho giá trị trục danh mục, xoay tiêu đề trục, đặt vị trí trục và hiển thị nhãn đơn vị trên trục giá trị.

## **Lấy Các Giá Trị Tối Đa Trên Trục Dọc Trong Biểu Đồ**

Aspose.Slides for Java cho phép bạn lấy giá trị tối thiểu và tối đa trên trục dọc. Thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
2. Truy cập slide đầu tiên.
3. Thêm một biểu đồ với dữ liệu mặc định.
4. Lấy giá trị tối đa thực tế trên trục.
5. Lấy giá trị tối thiểu thực tế trên trục.
6. Lấy đơn vị chính thực tế của trục.
7. Lấy đơn vị phụ thực tế của trục.
8. Lấy tỷ lệ đơn vị chính thực tế của trục.
9. Lấy tỷ lệ đơn vị phụ thực tế của trục.

Mã mẫu này—một triển khai các bước trên—cho bạn cách lấy các giá trị yêu cầu trong Java:

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

## **Hoán Đổi Dữ Liệu Giữa Các Trục**

Aspose.Slides cho phép bạn nhanh chóng hoán đổi dữ liệu giữa các trục—dữ liệu hiển thị trên trục dọc (y-axis) chuyển sang trục ngang (x-axis) và ngược lại. 

Mã Java này cho bạn cách thực hiện việc hoán đổi dữ liệu giữa các trục trên biểu đồ:

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

## **Vô Hiệu Hóa Trục Dọc Cho Biểu Đồ Đường**

Mã Java này cho bạn cách ẩn trục dọc cho biểu đồ đường:

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

## **Vô Hiệu Hóa Trục Ngang Cho Biểu Đồ Đường**

Mã này cho bạn cách ẩn trục ngang cho biểu đồ đường:

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

## **Thay Đổi Trục Danh Mục**

Sử dụng thuộc tính **CategoryAxisType**, bạn có thể chỉ định loại trục danh mục ưa thích của mình (**date** hoặc **text**). Mã này trong Java minh họa thao tác: 

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

## **Đặt Định Dạng Ngày Cho Giá Trị Trục Danh Mục**

Aspose.Slides for Java cho phép bạn đặt định dạng ngày cho giá trị trục danh mục. Thao tác này được minh họa trong mã Java này:

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

## **Đặt Góc Xoay Cho Tiêu Đề Trục Biểu Đồ**

Aspose.Slides for Java cho phép bạn đặt góc xoay cho tiêu đề trục biểu đồ. Mã Java này minh họa thao tác:

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

## **Đặt Vị Trí Trục Trên Trục Danh Mục Hoặc Giá Trị**

Aspose.Slides for Java cho phép bạn đặt vị trí trục trong trục danh mục hoặc trục giá trị. Mã Java này cho thấy cách thực hiện tác vụ:

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

## **Bật Nhãn Đơn Vị Hiển Thị Trên Trục Giá Trị Biểu Đồ**

Aspose.Slides for Java cho phép bạn cấu hình biểu đồ để hiển thị nhãn đơn vị trên trục giá trị của biểu đồ. Mã Java này minh họa thao tác:

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

## **Câu Hỏi Thường Gặp**

**Làm thế nào để đặt giá trị mà tại đó một trục cắt qua trục còn lại (giao điểm trục)?**

Các trục cung cấp một [cài đặt giao điểm](https://reference.aspose.com/slides/vi/java/com.aspose.slides/axis/#setCrossType-int-): bạn có thể chọn giao ở giá trị 0, ở danh mục/giá trị tối đa, hoặc ở một giá trị số cụ thể. Điều này hữu ích để dịch trục X lên hoặc xuống hoặc để nhấn mạnh một đường cơ sở.

**Làm thế nào tôi có thể đặt vị trí nhãn tick so với trục (bên cạnh, ngoài, trong)?**

Đặt [vị trí nhãn](https://reference.aspose.com/slides/vi/java/com.aspose.slides/axis/#setMajorTickMark-int-) thành "cross", "outside" hoặc "inside". Điều này ảnh hưởng đến khả năng đọc và giúp tiết kiệm không gian, đặc biệt trên các biểu đồ nhỏ.