---
title: Quản lý nhãn dữ liệu biểu đồ trong bài thuyết trình trên Android
linktitle: Nhãn dữ liệu
type: docs
url: /vi/androidjava/chart-data-label/
keywords:
- biểu đồ
- nhãn dữ liệu
- độ chính xác dữ liệu
- phần trăm
- khoảng cách nhãn
- vị trí nhãn
- PowerPoint
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách thêm và định dạng nhãn dữ liệu biểu đồ trong các bài thuyết trình PowerPoint bằng Aspose.Slides cho Android qua Java để có các slide hấp dẫn hơn."
---
## **Giới thiệu**

Nhãn dữ liệu trên biểu đồ hiển thị chi tiết về chuỗi dữ liệu của biểu đồ hoặc các điểm dữ liệu riêng lẻ. Chúng cho phép người đọc nhanh chóng nhận diện chuỗi dữ liệu và đồng thời làm cho biểu đồ dễ hiểu hơn.

## **Đặt độ chính xác dữ liệu trong nhãn dữ liệu biểu đồ**

Đoạn mã Java này cho bạn thấy cách đặt độ chính xác dữ liệu trong một nhãn dữ liệu biểu đồ:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    
    chart.setDataTable(true);
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00");

    pres.save("output.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hiển thị phần trăm dưới dạng nhãn**

Aspose.Slides for Android qua Java cho phép bạn đặt nhãn phần trăm trên các biểu đồ hiển thị. Đoạn mã Java này minh họa cách thực hiện:

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);
    IChartSeries series;
    double[] total_for_Cat = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        IChartCategory cat = chart.getChartData().getCategories().get_Item(k);
    
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            total_for_Cat[k] = total_for_Cat[k] + (double) (chart.getChartData().getSeries().get_Item(i).getDataPoints().get_Item(k).getValue().getData());
        }
    }
    
    double dataPontPercent = 0f;
    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);
    
        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel lbl = series.getDataPoints().get_Item(j).getLabel();
            dataPontPercent = (double) ((series.getDataPoints().get_Item(j).getValue().getData())) / (double) (total_for_Cat[j]) * 100;
    
            IPortion port = new Portion();
            port.setText(String.format("{0:F2} %.2f", dataPontPercent));
            port.getPortionFormat().setFontHeight(8f);
            lbl.getTextFrameForOverriding().setText("");
            IParagraph para = lbl.getTextFrameForOverriding().getParagraphs().get_Item(0);
            para.getPortions().add(port);
    
            lbl.getDataLabelFormat().setShowSeriesName(false);
            lbl.getDataLabelFormat().setShowPercentage(false);
            lbl.getDataLabelFormat().setShowLegendKey(false);
            lbl.getDataLabelFormat().setShowCategoryName(false);
            lbl.getDataLabelFormat().setShowBubbleSize(false);
        }
    }
    
    // Lưu bài thuyết trình chứa biểu đồ
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Đặt ký hiệu phần trăm trong nhãn dữ liệu biểu đồ**

Đoạn mã Java này cho bạn cách đặt ký hiệu phần trăm cho một nhãn dữ liệu biểu đồ:

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    // Lấy tham chiếu slide qua chỉ mục của nó
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Tạo biểu đồ PercentsStackedColumn trên slide
    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    
    // Đặt NumberFormatLinkedToSource thành false
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    
    chart.getChartData().getSeries().clear();
    int defaultWorksheetIndex = 0;
    
    // Lấy worksheet dữ liệu biểu đồ
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    
    // Thêm series mới
    IChartSeries series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.30));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.50));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.80));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    
    // Đặt màu nền cho series
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Đặt các thuộc tính LabelFormat
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Thêm series mới
    IChartSeries series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.70));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.50));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.20));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    
    // Đặt kiểu và màu Fill
    series2.getFormat().getFill().setFillType(FillType.Solid);
    series2.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    
    // Ghi bài thuyết trình ra đĩa
    pres.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Đặt khoảng cách nhãn khỏi trục**

Đoạn mã Java này cho bạn cách đặt khoảng cách nhãn khỏi trục danh mục khi bạn làm việc với biểu đồ được vẽ từ các trục:

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    // Lấy tham chiếu của slide
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Tạo một biểu đồ trên slide
    IChart ch = sld.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    
    // Đặt khoảng cách nhãn khỏi trục
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    
    // Ghi bài thuyết trình ra đĩa
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Điều chỉnh vị trí nhãn**

Khi bạn tạo một biểu đồ không dựa trên bất kỳ trục nào như biểu đồ tròn, các nhãn dữ liệu của biểu đồ có thể quá gần mép. Trong trường hợp đó, bạn phải điều chỉnh vị trí nhãn dữ liệu sao cho các đường dẫn được hiển thị rõ ràng.

Đoạn mã Java này cho bạn cách điều chỉnh vị trí nhãn trên biểu đồ tròn:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);

    IChartSeriesCollection series = chart.getChartData().getSeries();
    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);

    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **Câu hỏi thường gặp**

**Làm thế nào để ngăn nhãn dữ liệu chồng lên nhau trên các biểu đồ dày đặc?**

Kết hợp việc đặt nhãn tự động, các đường dẫn, và giảm kích thước phông chữ; nếu cần, ẩn một số trường (ví dụ, danh mục) hoặc chỉ hiển thị nhãn cho các điểm cực đoan/quan trọng.

**Làm thế nào để tắt nhãn chỉ cho các giá trị bằng 0, âm hoặc trống?**

Lọc các điểm dữ liệu trước khi bật nhãn và tắt hiển thị cho các giá trị bằng 0, giá trị âm, hoặc giá trị thiếu theo quy tắc đã định.

**Làm thế nào để đảm bảo kiểu nhãn nhất quán khi xuất ra PDF/hình ảnh?**

Thiết lập rõ ràng phông chữ (họ, kích thước) và xác minh phông chữ có sẵn ở phía render để tránh việc fallback.