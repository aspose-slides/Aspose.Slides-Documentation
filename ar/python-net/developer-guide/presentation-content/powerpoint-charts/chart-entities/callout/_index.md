---
title: إدارة التعليقات التوضيحية في مخططات العرض التقديمي باستخدام Python
linktitle: ملاحظة توضيحية
type: docs
url: /ar/python-net/callout/
keywords:
- ملاحظة توضيحية للمخطط
- استخدام الملاحظة التوضيحية
- تسمية البيانات
- تنسيق التسمية
- Python
- Aspose.Slides
description: "إنشاء وتنسيق الملاحظات التوضيحية في Aspose.Slides for Python .NET مع أمثلة شفرة مختصرة، ومتوافق مع PPT و PPTX و ODP لأتمتة سير عمل العروض التقديمية."
---

## **استخدام التعليقات التوضيحية**
تم إضافة الخاصية الجديدة **ShowLabelAsDataCallout** إلى الفئة **DataLabelFormat** والواجهة **IDataLabelFormat**، التي تحدد ما إذا كان سيتم عرض تسمية بيانات المخطط المحدد كتعليق توضيحي للبيانات أو كتسمية بيانات. في المثال المعطى أدناه، قمنا بتعيين التعليقات التوضيحية.
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].labels.default_data_label_format.show_label_as_data_callout = True
    chart.chart_data.series[0].labels[2].data_label_format.show_label_as_data_callout = False
    presentation.save("DisplayChartLabels_out.pptx", slides.export.SaveFormat.PPTX)
```




## **تعيين تعليق توضيحي لمخطط الدونات**
توفر Aspose.Slides for Python عبر .NET دعمًا لتعيين شكل التعليق التوضيحي لتسمية بيانات السلسلة لمخطط الدونات. أدناه مثال عينة. 
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


## **أسئلة شائعة**

**هل يتم الحفاظ على التعليقات التوضيحية عند تحويل العرض التقديمي إلى PDF أو HTML5 أو SVG أو صور؟**

نعم. التعليقات التوضيحية هي جزء من عملية عرض المخطط، لذا عند تصديره إلى [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/)، [HTML5](/slides/ar/python-net/export-to-html5/)، [SVG](/slides/ar/python-net/render-a-slide-as-an-svg-image/)، أو [الصور النقطية](/slides/ar/python-net/convert-powerpoint-to-png/)، يتم الحفاظ عليها مع تنسيق الشريحة.

**هل تعمل الخطوط المخصصة في التعليقات التوضيحية، وهل يمكن الحفاظ على مظهرها عند التصدير؟**

نعم. تدعم Aspose.Slides [embedding fonts](/slides/ar/python-net/embedded-font/) في العرض التقديمي وتتحكم في تضمين الخطوط أثناء عمليات التصدير مثل [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/)، مما يضمن أن تبدو التعليقات التوضيحية نفسها عبر الأنظمة المختلفة.