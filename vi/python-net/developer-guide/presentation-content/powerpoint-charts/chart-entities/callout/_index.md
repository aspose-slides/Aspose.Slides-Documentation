---
title: Quản lý Callouts trong biểu đồ trình chiếu bằng Python
linktitle: Callout
type: docs
url: /vi/python-net/callout/
keywords:
- callout biểu đồ
- sử dụng callout
- nhãn dữ liệu
- định dạng nhãn
- Python
- Aspose.Slides
description: "Tạo và định dạng callout trong Aspose.Slides cho Python .NET với các ví dụ mã ngắn gọn, tương thích với PPT, PPTX và ODP để tự động hoá quy trình làm việc với bản trình chiếu."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với callout cho nhãn dữ liệu biểu đồ trong Aspose.Slides. Nó cho thấy cách sử dụng thuộc tính `show_label_as_data_callout` để hiển thị nhãn dưới dạng callout, cách cấu hình các thiết lập nhãn liên quan đến callout cho biểu đồ Doughnut, và lưu ý rằng callout và giao diện của chúng được giữ nguyên khi bản trình bày được xuất ra định dạng PDF, HTML5, SVG và các định dạng ảnh raster.

## **Sử dụng Callout**
Thuộc tính mới **show_label_as_data_callout** đã được thêm vào lớp **DataLabelFormat**, nó xác định liệu nhãn dữ liệu của biểu đồ được chỉ định sẽ được hiển thị dưới dạng data callout hay dưới dạng nhãn dữ liệu. Trong ví dụ dưới đây, chúng tôi đã thiết lập Callout.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].labels.default_data_label_format.show_label_as_data_callout = True
    chart.chart_data.series[0].labels[2].data_label_format.show_label_as_data_callout = False
    presentation.save("DisplayChartLabels_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Thiết lập Callout cho Biểu đồ Doughnut**
Aspose.Slides for Python via .NET hỗ trợ thiết lập hình dạng callout cho nhãn dữ liệu của series trong biểu đồ Doughnut. Dưới đây là ví dụ mẫu.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.DOUGHNUT, 10, 10, 500, 500, False)
    workBook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = False
    seriesIndex = 0
    while seriesIndex < 15:
        series = chart.chart_data.series.add(workBook.get_cell(0, 0, seriesIndex + 1, "SERIES " + str(seriesIndex)), chart.type)
        series.explosion = 0
        series.parent_series_group.doughnut_hole_size = 20
        series.parent_series_group.first_slice_angle = 351
        seriesIndex += 1
    categoryIndex = 0
    while categoryIndex < 15:
        chart.chart_data.categories.add(workBook.get_cell(0, categoryIndex + 1, 0, "CATEGORY " + str(categoryIndex)))
        i = 0
        while i < len(chart.chart_data.series):
            iCS = chart.chart_data.series[i]
            dataPoint = iCS.data_points.add_data_point_for_doughnut_series(workBook.get_cell(0, categoryIndex + 1, i + 1, 1))
            dataPoint.format.fill.fill_type = slides.FillType.SOLID
            dataPoint.format.line.fill_format.fill_type = slides.FillType.SOLID
            dataPoint.format.line.fill_format.solid_fill_color.color = draw.Color.white
            dataPoint.format.line.width = 1
            dataPoint.format.line.style = slides.LineStyle.SINGLE
            dataPoint.format.line.dash_style = slides.LineDashStyle.SOLID
            if i == len(chart.chart_data.series) - 1:
                lbl = dataPoint.label
                lbl.text_format.text_block_format.autofit_type = slides.TextAutofitType.SHAPE
                lbl.data_label_format.text_format.portion_format.font_bold = 1
                lbl.data_label_format.text_format.portion_format.latin_font = slides.FontData("DINPro-Bold")
                lbl.data_label_format.text_format.portion_format.font_height = 12
                lbl.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
                lbl.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.light_gray
                lbl.data_label_format.format.line.fill_format.solid_fill_color.color = draw.Color.white
                lbl.data_label_format.show_value = False
                lbl.data_label_format.show_category_name = True
                lbl.data_label_format.show_series_name = False
                lbl.data_label_format.show_leader_lines = True
                lbl.data_label_format.show_label_as_data_callout = False
                chart.validate_chart_layout()
                lbl.as_i_layoutable.x += 0.5
                lbl.as_i_layoutable.y += 0.5
            i += 1
        categoryIndex +=1 
    pres.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Callout có được giữ nguyên khi chuyển đổi bản trình bày sang PDF, HTML5, SVG hoặc hình ảnh không?**

Có. Callout là một phần của việc render biểu đồ, vì vậy khi bạn xuất ra [PDF](/slides/vi/python-net/convert-powerpoint-to-pdf/),[HTML5](/slides/vi/python-net/export-to-html5/),[SVG](/slides/vi/python-net/render-a-slide-as-an-svg-image/),hoặc[raster images](/slides/vi/python-net/convert-powerpoint-to-png/), chúng sẽ được giữ nguyên cùng với định dạng của slide.

**Phông chữ tùy chỉnh có hoạt động trong callout không, và giao diện của chúng có được giữ nguyên khi xuất không?**

Có. Aspose.Slides hỗ trợ [embedding fonts](/slides/vi/python-net/embedded-font/) vào bản trình bày và kiểm soát việc nhúng phông chữ khi xuất như [PDF](/slides/vi/python-net/convert-powerpoint-to-pdf/),đảm bảo callout trông giống nhau trên các hệ thống khác nhau.