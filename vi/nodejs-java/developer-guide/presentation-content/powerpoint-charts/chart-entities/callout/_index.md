---
title: Quản lý Callout trong biểu đồ trình chiếu bằng JavaScript
linktitle: Callout
type: docs
url: /vi/nodejs-java/callout/
keywords:
- callout biểu đồ
- sử dụng callout
- nhãn dữ liệu
- định dạng nhãn
- PowerPoint
- trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tạo và định dạng callout trong Aspose.Slides cho Node.js thông qua Java với các ví dụ mã ngắn gọn, tương thích với PPT và PPTX để tự động hoá quy trình làm việc với trình chiếu."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với callout cho nhãn dữ liệu biểu đồ trong Aspose.Slides. Nó cho thấy cách sử dụng phương thức `setShowLabelAsDataCallout` để hiển thị nhãn dưới dạng callout, cách cấu hình các cài đặt nhãn liên quan đến callout cho biểu đồ Doughnut, và lưu ý rằng callout và giao diện của chúng được giữ nguyên khi bản trình chiếu được xuất ra PDF, HTML5, SVG và các định dạng ảnh raster.

## **Sử dụng Callout**

Đã thêm các phương thức mới [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/DataLabelFormat#getShowLabelAsDataCallout--) và [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/DataLabelFormat#setShowLabelAsDataCallout-boolean-) vào lớp [DataLabelFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/datalabelformat) và lớp [DataLabelFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/datalabelformat). Các phương thức này xác định liệu nhãn dữ liệu của biểu đồ được chỉ định có được hiển thị dưới dạng callout dữ liệu hay là nhãn dữ liệu.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 500, 400);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowLabelAsDataCallout(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(false);
    pres.save("DisplayCharts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đặt Callout cho Biểu đồ Doughnut**

Aspose.Slides cho Node.js thông qua Java cung cấp hỗ trợ thiết lập hình dạng callout cho nhãn dữ liệu của series trong biểu đồ Doughnut. Dưới đây là ví dụ mẫu.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Doughnut, 10, 10, 500, 500, false);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(false);
    var seriesIndex = 0;
    while (seriesIndex < 15) {
        var series = chart.getChartData().getSeries().add(workBook.getCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.getType());
        series.setExplosion(0);
        series.getParentSeriesGroup().setDoughnutHoleSize(20);
        series.getParentSeriesGroup().setFirstSliceAngle(351);
        seriesIndex++;
    }
    var categoryIndex = 0;
    while (categoryIndex < 15) {
        chart.getChartData().getCategories().add(workBook.getCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
        var i = 0;
        while (i < chart.getChartData().getSeries().size()) {
            var iCS = chart.getChartData().getSeries().get_Item(i);
            var dataPoint = iCS.getDataPoints().addDataPointForDoughnutSeries(workBook.getCell(0, categoryIndex + 1, i + 1, 1));
            dataPoint.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
            dataPoint.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            dataPoint.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
            dataPoint.getFormat().getLine().setWidth(1);
            dataPoint.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
            dataPoint.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
            if (i == (chart.getChartData().getSeries().size() - 1)) {
                var lbl = dataPoint.getLabel();
                lbl.getTextFormat().getTextBlockFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setLatinFont(new aspose.slides.FontData("DINPro-Bold"));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
                lbl.getDataLabelFormat().getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
                lbl.getDataLabelFormat().setShowValue(false);
                lbl.getDataLabelFormat().setShowCategoryName(true);
                lbl.getDataLabelFormat().setShowSeriesName(false);
                lbl.getDataLabelFormat().setShowLeaderLines(true);
                lbl.getDataLabelFormat().setShowLabelAsDataCallout(false);
                chart.validateChartLayout();
                lbl.setX(lbl.getX() + 0.5);
                lbl.setY(lbl.getY() + 0.5);
            }
            i++;
        }
        categoryIndex++;
    }
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Liệu callout có được giữ nguyên khi chuyển đổi bản trình chiếu sang PDF, HTML5, SVG hoặc hình ảnh không?**

**Có. Callout là một phần của việc render biểu đồ, vì vậy khi bạn xuất sang [PDF](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/), [HTML5](/slides/vi/nodejs-java/export-to-html5/), [SVG](/slides/vi/nodejs-java/render-a-slide-as-an-svg-image/), hoặc [raster images](/slides/vi/nodejs-java/convert-powerpoint-to-png/), chúng sẽ được giữ nguyên cùng với định dạng của slide.**

**Phông chữ tùy chỉnh có hoạt động trong callout không, và giao diện của chúng có thể được giữ nguyên khi xuất không?**

**Có. Aspose.Slides hỗ trợ [embedding fonts](/slides/vi/nodejs-java/embedded-font/) vào bản trình chiếu và kiểm soát việc nhúng phông chữ trong các quá trình xuất như [PDF](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/), đảm bảo callout hiển thị giống nhau trên các hệ thống khác nhau.**