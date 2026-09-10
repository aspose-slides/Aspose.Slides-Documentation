---
title: "Quản lý Callout trong Biểu đồ Trình chiếu bằng Python"
linktitle: "Gọi chú"
type: docs
url: /vi/python-java/callout/
keywords:
- "callout biểu đồ"
- "sử dụng callout"
- "nhãn dữ liệu"
- "định dạng nhãn"
- "PowerPoint"
- "trình chiếu"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Tạo và định dạng callout trong Aspose.Slides cho Python qua Java với các ví dụ mã ngắn gọn, tương thích với PPT và PPTX để tự động hóa quy trình làm việc với trình chiếu."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với callout cho nhãn dữ liệu biểu đồ trong Aspose.Slides. Nó cho thấy cách sử dụng phương thức [setShowLabelAsDataCallout](https://reference.aspose.com/slides/vi/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) để hiển thị nhãn dưới dạng callout, cách cấu hình các thiết lập nhãn liên quan đến callout cho biểu đồ bánh vòng, và lưu ý rằng các callout và dạng hiển thị của chúng được giữ nguyên khi xuất bản trình chiếu sang PDF, HTML5, SVG và các định dạng ảnh raster.

## **Sử dụng Callout**

Các phương thức [getShowLabelAsDataCallout](https://reference.aspose.com/slides/vi/python-java/aspose.slides/datalabelformat/#getShowLabelAsDataCallout) và [setShowLabelAsDataCallout](https://reference.aspose.com/slides/vi/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) của lớp [DataLabelFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/datalabelformat/) xác định xem nhãn dữ liệu biểu đồ có được hiển thị dưới dạng callout hay là nhãn dữ liệu thông thường.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 500, 400)
    labels = chart.getChartData().getSeries().get_Item(0).getLabels()
    default_label_format = labels.getDefaultDataLabelFormat()
    default_label_format.setShowValue(True)
    default_label_format.setShowLabelAsDataCallout(True)
    labels.get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(False)

    presentation.save("DisplayCharts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt Callout cho Biểu đồ bánh vòng**

Aspose.Slides for Python via Java hỗ trợ việc đặt hình dạng callout cho nhãn dữ liệu chuỗi của biểu đồ bánh vòng. Ví dụ sau minh họa cách thực hiện.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat, TextAutofitType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.Doughnut, 10, 10, 500, 500, False)
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(False)

    for series_index in range(15):
        series_cell = workbook.getCell(0, 0, series_index + 1, f"SERIES {series_index}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        series.setExplosion(0)
        series.getParentSeriesGroup().setDoughnutHoleSize(jpype.JByte(20))
        series.getParentSeriesGroup().setFirstSliceAngle(351)

    for category_index in range(15):
        category_cell = workbook.getCell(0, category_index + 1, 0, f"CATEGORY {category_index}")
        chart.getChartData().getCategories().add(category_cell)
        for i in range(chart.getChartData().getSeries().size()):
            series = chart.getChartData().getSeries().get_Item(i)
            data_cell = workbook.getCell(0, category_index + 1, i + 1, jpype.JInt(1))
            data_point = series.getDataPoints().addDataPointForDoughnutSeries(data_cell)
            data_point.getFormat().getFill().setFillType(FillType.Solid)
            line_format = data_point.getFormat().getLine()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)
            line_format.setWidth(1)
            line_format.setStyle(LineStyle.Single)
            line_format.setDashStyle(LineDashStyle.Solid)
            if i == chart.getChartData().getSeries().size() - 1:
                label = data_point.getLabel()
                label.getTextFormat().getTextBlockFormat().setAutofitType(TextAutofitType.Shape)
                label_format = label.getDataLabelFormat()
                portion_format = label_format.getTextFormat().getPortionFormat()
                portion_format.setFontBold(NullableBool.True_)
                font = FontData("DINPro-Bold")
                portion_format.setLatinFont(font)
                portion_format.setFontHeight(12)
                portion_format.getFillFormat().setFillType(FillType.Solid)
                portion_format.getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY)
                label_format.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.WHITE)
                label_format.setShowValue(False)
                label_format.setShowCategoryName(True)
                label_format.setShowSeriesName(False)
                label_format.setShowLeaderLines(True)
                label_format.setShowLabelAsDataCallout(False)
                chart.validateChartLayout()
                label.setX(label.getX() + 0.5)
                label.setY(label.getY() + 0.5)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Callout có được giữ lại khi chuyển đổi bản trình chiếu sang PDF, HTML5, SVG hoặc ảnh không?**

Có. Callout là một phần của quá trình render biểu đồ, vì vậy khi bạn xuất sang [PDF](/slides/vi/python-java/convert-powerpoint-to-pdf/), [HTML5](/slides/vi/python-java/export-to-html5/), [SVG](/slides/vi/python-java/render-a-slide-as-an-svg-image/), hoặc [raster images](/slides/vi/python-java/convert-powerpoint-to-png/), chúng sẽ được giữ nguyên cùng với định dạng của slide.

**Phông chữ tùy chỉnh có hoạt động trong callout và dạng hiển thị của chúng có được giữ lại khi xuất không?**

Có. Aspose.Slides hỗ trợ [embedding fonts](/slides/vi/python-java/embedded-font/) vào bản trình chiếu và kiểm soát việc nhúng phông chữ khi xuất ra như [PDF](/slides/vi/python-java/convert-powerpoint-to-pdf/), đảm bảo callout trông giống nhau trên các hệ thống khác nhau.