---
title: تسميات بيانات الرسم البياني
type: docs
url: /python-net/chart-data-label/
keywords: "تسمية بيانات الرسم البياني,مسافة التسمية, بايثون, Aspose.Slides for Python via .NET"
description: "تعيين تسمية بيانات الرسم البياني ومسافتها في بايثون"
---

تظهر تسميات البيانات على الرسم البياني تفاصيل حول سلسلة بيانات الرسم البياني أو نقاط البيانات الفردية. تتيح للقراء التعرف بسرعة على سلسلات البيانات وتسهّل أيضًا فهم الرسم البياني.

## **تعيين دقة البيانات في تسميات بيانات الرسم البياني**

هذا الرمز بلغة بايثون يعرض كيفية تعيين دقة البيانات في تسمية بيانات الرسم البياني:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
	chart.has_data_table = True
	chart.chart_data.series[0].number_format_of_values = "#,##0.00"

	pres.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **عرض النسبة المئوية كتسميات**
تتيح لك Aspose.Slides for Python via .NET تعيين تسميات النسبة المئوية على الرسوم البيانية المعروضة. هذا الرمز بلغة بايثون يوضح العملية:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)
    series = chart.chart_data.series[0]
    total_for_Cat = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        cat = chart.chart_data.categories[k]
        for i in range(len(chart.chart_data.series)):
            total_for_Cat[k] += chart.chart_data.series[i].data_points[k].value.data

dataPontPercent = 0

for x in range(len(chart.chart_data.series)):
    series = chart.chart_data.series[x]
    series.labels.default_data_label_format.show_legend_key = False

    for j in range(len(series.data_points)):
        lbl = series.data_points[j].label
        dataPontPercent = series.data_points[j].value.data / total_for_Cat[j] * 100

        port = slides.Portion()
        port.text = "{0:.2f} %".format(dataPontPercent)
        port.portion_format.font_height = 8
        lbl.text_frame_for_overriding.text = ""
        para = lbl.text_frame_for_overriding.paragraphs[0]
        para.portions.add(port)

        lbl.data_label_format.show_series_name = False
        lbl.data_label_format.show_percentage = False
        lbl.data_label_format.show_legend_key = False
        lbl.data_label_format.show_category_name = False
        lbl.data_label_format.show_bubble_size = False

# Saves the presentation containing the chart
presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين علامة النسبة المئوية مع تسميات بيانات الرسم البياني**
هذا الرمز بلغة بايثون يوضح لك كيفية تعيين علامة النسبة المئوية لتسمية بيانات الرسم البياني:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Creates an instance of Presentation class
with slides.Presentation() as presentation:

    # Gets a slide's reference through its index
    slide = presentation.slides[0]

    # Creates the PercentsStackedColumn chart on a slide
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    # Sets the NumberFormatLinkedToSource to false
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    defaultWorksheetIndex = 0

    # Gets the chart data worksheet
    workbook = chart.chart_data.chart_data_workbook

    # Adds new series
    series = chart.chart_data.series.add(workbook.get_cell(defaultWorksheetIndex, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 4, 1, 0.65))

    # Sets the fill color of series
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Sets the LabelFormat properties
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # Adds new series
    series2 = chart.chart_data.series.add(workbook.get_cell(defaultWorksheetIndex, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 4, 2, 0.35))

    # Sets Fill type and color
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # Writes the presentation to disk
    presentation.save("SetDatalabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين مسافة التسمية من المحور**
هذا الرمز بلغة بايثون يعرض كيفية تعيين مسافة التسمية من محور الفئة عند التعامل مع رسم بياني مرسوم من المحاور:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

	# Creates an instance of the Presentation class
with slides.Presentation() as presentation:
    # Gets a slide's reference
    sld = presentation.slides[0]
    
    # Creates a chart on the slide
    ch = sld.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Sets the label distance from an axis
    ch.axes.horizontal_axis.label_offset = 500

    # Writes the presentation to disk
    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تعديل موقع التسمية**

عند إنشاء رسم بياني لا يعتمد على أي محور مثل الرسم البياني الدائري، قد تنتهي تسميات بيانات الرسم البياني بالقرب من حافته. في مثل هذه الحالة، يجب تعديل موقع التسمية للبيانات حتى يتم عرض خطوط الوصل بشكل واضح.

هذا الرمز بلغة بايثون يعرض كيفية تعديل موقع التسمية على رسم بياني دائري:

```python
import aspose.slides as slides


with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.PIE, 50, 50, 200, 200)

    series = chart.chart_data.series
    label = series[0].labels[0]

    label.data_label_format.show_value = True
    label.data_label_format.position = slides.charts.LegendDataLabelPosition.OUTSIDE_END
    label.x = 0.71
    label.y = 0.04

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)