---
title: Quản lý Nhãn Dữ liệu Biểu đồ trong Bản trình chiếu Sử dụng JavaScript
linktitle: Nhãn Dữ liệu
type: docs
url: /vi/nodejs-java/chart-data-label/
keywords:
- biểu đồ
- nhãn dữ liệu
- độ chính xác dữ liệu
- phần trăm
- khoảng cách nhãn
- vị trí nhãn
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách thêm và định dạng nhãn dữ liệu biểu đồ trong bản trình chiếu PowerPoint bằng JavaScript và Aspose.Slides cho Node.js thông qua Java để tạo các slide sinh động hơn."
---
## **Giới thiệu**

Nhãn dữ liệu trên biểu đồ hiển thị chi tiết về chuỗi dữ liệu hoặc các điểm dữ liệu riêng lẻ. Chúng giúp người đọc nhanh chóng nhận diện chuỗi dữ liệu và cũng làm cho biểu đồ dễ hiểu hơn.

## **Đặt độ chính xác của dữ liệu trong nhãn dữ liệu biểu đồ**

Đoạn mã JavaScript này cho bạn cách đặt độ chính xác của dữ liệu trong một nhãn dữ liệu biểu đồ:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Hiển thị phần trăm dưới dạng nhãn**

Aspose.Slides cho Node.js thông qua Java cho phép bạn đặt nhãn phần trăm trên các biểu đồ hiển thị. Đoạn mã JavaScript này trình bày cách thực hiện:

```javascript
// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);
    var series;
    var total_for_Cat = new double[chart.getChartData().getCategories().size()];
    for (var k = 0; k < chart.getChartData().getCategories().size(); k++) {
        var cat = chart.getChartData().getCategories().get_Item(k);
        for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
            total_for_Cat[k] = total_for_Cat[k] + chart.getChartData().getSeries().get_Item(i).getDataPoints().get_Item(k).getValue().getData();
        }
    }
    var dataPontPercent = 0.0;
    for (var x = 0; x < chart.getChartData().getSeries().size(); x++) {
        series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);
        for (var j = 0; j < series.getDataPoints().size(); j++) {
            var lbl = series.getDataPoints().get_Item(j).getLabel();
            dataPontPercent = (series.getDataPoints().get_Item(j).getValue().getData() / total_for_Cat[j]) * 100;
            var port = new aspose.slides.Portion();
            port.setText(java.callStaticMethodSync("java.lang.String", "format", "{0:F2} %.2f", dataPontPercent));
            port.getPortionFormat().setFontHeight(8.0);
            lbl.getTextFrameForOverriding().setText("");
            var para = lbl.getTextFrameForOverriding().getParagraphs().get_Item(0);
            para.getPortions().add(port);
            lbl.getDataLabelFormat().setShowSeriesName(false);
            lbl.getDataLabelFormat().setShowPercentage(false);
            lbl.getDataLabelFormat().setShowLegendKey(false);
            lbl.getDataLabelFormat().setShowCategoryName(false);
            lbl.getDataLabelFormat().setShowBubbleSize(false);
        }
    }
    // Lưu bản trình chiếu chứa biểu đồ
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đặt ký hiệu phần trăm cho nhãn dữ liệu biểu đồ**

Đoạn mã JavaScript này cho bạn cách đặt ký hiệu phần trăm cho nhãn dữ liệu biểu đồ:

```javascript
// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation();
try {
    // Lấy tham chiếu slide qua chỉ số của nó
    var slide = pres.getSlides().get_Item(0);
    // Tạo biểu đồ PercentsStackedColumn trên slide
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    // Đặt NumberFormatLinkedToSource thành false
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    chart.getChartData().getSeries().clear();
    var defaultWorksheetIndex = 0;
    // Lấy worksheet dữ liệu biểu đồ
    var workbook = chart.getChartData().getChartDataWorkbook();
    // Thêm series mới
    var series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    // Đặt màu nền cho series
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Đặt các thuộc tính LabelFormat
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Thêm series mới
    var series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.7));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.5));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.2));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    // Đặt loại và màu nền
    series2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    // Ghi bản trình chiếu ra đĩa
    pres.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đặt khoảng cách nhãn so với trục**

Đoạn mã JavaScript này cho bạn cách đặt khoảng cách nhãn so với trục danh mục khi bạn làm việc với biểu đồ được vẽ từ các trục:

```javascript
// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation();
try {
    // Lấy tham chiếu slide
    var sld = pres.getSlides().get_Item(0);
    // Tạo biểu đồ trên slide
    var ch = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    // Đặt khoảng cách nhãn khỏi trục
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    // Ghi bản trình chiếu ra đĩa
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Điều chỉnh vị trí nhãn**

Khi bạn tạo một biểu đồ không dựa vào bất kỳ trục nào như biểu đồ tròn, các nhãn dữ liệu của biểu đồ có thể quá gần cạnh. Trong trường hợp đó, bạn cần điều chỉnh vị trí của nhãn dữ liệu sao cho các đường dẫn (leader lines) hiển thị rõ ràng.

Đoạn mã JavaScript này cho bạn cách điều chỉnh vị trí nhãn trên biểu đồ tròn:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    var series = chart.getChartData().getSeries();
    var label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71);
    label.setY(0.04);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **FAQ**

**Làm thế nào tôi có thể ngăn các nhãn dữ liệu chồng lên nhau trên các biểu đồ dày đặc?**

Kết hợp việc tự động đặt nhãn, các đường dẫn và giảm kích thước phông chữ; nếu cần, ẩn một số trường (ví dụ, danh mục) hoặc chỉ hiển thị nhãn cho các điểm cực đoan/quan trọng.

**Làm thế nào tôi có thể tắt nhãn chỉ cho các giá trị bằng không, âm hoặc trống?**

Lọc các điểm dữ liệu trước khi bật nhãn và tắt hiển thị cho các giá trị bằng 0, giá trị âm hoặc giá trị thiếu theo quy tắc đã định.

**Làm thế nào tôi có thể đảm bảo phong cách nhãn nhất quán khi xuất ra PDF/hình ảnh?**

Đặt rõ ràng phông chữ (gia đình, kích thước) và xác nhận rằng phông chữ có sẵn ở phía render để tránh việc sử dụng phông chữ dự phòng.