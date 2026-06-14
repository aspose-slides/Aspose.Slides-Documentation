---
title: Quản lý Callout trong Biểu đồ Bản trình chiếu bằng Java
linktitle: Gọi chú
type: docs
url: /vi/java/callout/
keywords:
- callout biểu đồ
- sử dụng callout
- nhãn dữ liệu
- định dạng nhãn
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tạo và tạo kiểu callout trong Aspose.Slides cho Java với các ví dụ mã ngắn gọn, tương thích với PPT và PPTX để tự động hoá quy trình làm việc với bản trình chiếu."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với callout cho nhãn dữ liệu biểu đồ trong Aspose.Slides. Nó chỉ ra cách sử dụng phương thức `setShowLabelAsDataCallout` để hiển thị nhãn dưới dạng callout, cách cấu hình các cài đặt nhãn liên quan đến callout cho biểu đồ Doughnut, và lưu ý rằng các callout và dạng hiển thị của chúng được giữ nguyên khi bản trình chiếu được xuất ra các định dạng PDF, HTML5, SVG và hình ảnh raster.

## **Sử dụng Callout**

Đã thêm các phương thức mới [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) và [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) vào lớp [DataLabelFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/datalabelformat) và giao diện [IDataLabelFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idatalabelformat). Các phương thức này xác định liệu nhãn dữ liệu của biểu đồ được chỉ định có được hiển thị dưới dạng callout dữ liệu hay dưới dạng nhãn dữ liệu.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 500, 400);
    
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowLabelAsDataCallout(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(false);
    
    pres.save("DisplayCharts.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Đặt Callout cho Biểu đồ Doughnut**

Aspose.Slides for Java hỗ trợ thiết lập hình dạng callout cho nhãn dữ liệu của chuỗi trong biểu đồ Doughnut. Dưới đây là ví dụ mẫu.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Doughnut, 10, 10, 500, 500, false);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(false);
    int seriesIndex = 0;
    while (seriesIndex < 15)
    {
        IChartSeries series = chart.getChartData().getSeries().add(workBook.getCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.getType());
        series.setExplosion(0);
        series.getParentSeriesGroup().setDoughnutHoleSize((byte)20);
        series.getParentSeriesGroup().setFirstSliceAngle(351);
        seriesIndex++;
    }
    int categoryIndex = 0;
    while (categoryIndex < 15)
    {
        chart.getChartData().getCategories().add(workBook.getCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
        int i = 0;
        while (i < chart.getChartData().getSeries().size())
        {
            IChartSeries iCS = chart.getChartData().getSeries().get_Item(i);
            IChartDataPoint dataPoint = iCS.getDataPoints().addDataPointForDoughnutSeries(workBook.getCell(0, categoryIndex + 1, i + 1, 1));
            dataPoint.getFormat().getFill().setFillType(FillType.Solid);
            dataPoint.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
            dataPoint.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.awt.Color.WHITE);
            dataPoint.getFormat().getLine().setWidth(1);
            dataPoint.getFormat().getLine().setStyle(LineStyle.Single);
            dataPoint.getFormat().getLine().setDashStyle(LineDashStyle.Solid);
            if (i == chart.getChartData().getSeries().size() - 1)
            {
                IDataLabel lbl = dataPoint.getLabel();
                lbl.getTextFormat().getTextBlockFormat().setAutofitType(TextAutofitType.Shape);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setLatinFont(new FontData("DINPro-Bold"));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.LIGHT_GRAY);
                lbl.getDataLabelFormat().getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.awt.Color.WHITE);
                lbl.getDataLabelFormat().setShowValue(false);
                lbl.getDataLabelFormat().setShowCategoryName(true);
                lbl.getDataLabelFormat().setShowSeriesName(false);
                lbl.getDataLabelFormat().setShowLeaderLines(true);
                lbl.getDataLabelFormat().setShowLabelAsDataCallout(false);
                chart.validateChartLayout();
                lbl.setX((float) lbl.getX()+ (float)0.5);
                lbl.setY((float)lbl.getY()+ (float)0.5);
            }
            i++;
        }
        categoryIndex++;
    }
    pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Liệu các callout có được giữ nguyên khi chuyển đổi bản trình chiếu sang PDF, HTML5, SVG hoặc hình ảnh không?**

**Có.** Callout là một phần của việc render biểu đồ, vì vậy khi bạn xuất ra [PDF](/slides/vi/java/convert-powerpoint-to-pdf/), [HTML5](/slides/vi/java/export-to-html5/), [SVG](/slides/vi/java/render-a-slide-as-an-svg-image/) hoặc [raster images](/slides/vi/java/convert-powerpoint-to-png/), chúng được giữ nguyên cùng với định dạng của slide.

**Phông chữ tùy chỉnh có hoạt động trong callout không, và dạng hiển thị của chúng có được giữ nguyên khi xuất không?**

**Có.** Aspose.Slides hỗ trợ [embedding fonts](/slides/vi/java/embedded-font/) vào bản trình chiếu và kiểm soát việc nhúng phông chữ trong quá trình xuất như [PDF](/slides/vi/java/convert-powerpoint-to-pdf/), đảm bảo các callout trông giống nhau trên các hệ thống khác nhau.