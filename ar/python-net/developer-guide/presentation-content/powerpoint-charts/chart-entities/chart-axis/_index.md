---
title: محور الرسم البياني
type: docs
url: /ar/python-net/chart-axis/
keywords: "محور الرسم البياني في PowerPoint، الرسوم البيانية التقديمية، بايثون، manipulate محور الرسم البياني، بيانات الرسم البياني"
description: "تعديل محور الرسم البياني في PowerPoint باستخدام بايثون"
---


## **الحصول على القيم القصوى على المحور العمودي في الرسوم البيانية**
Aspose.Slides لبايثون عبر .NET يتيح لك الحصول على القيم الدنيا والقصوى على محور عمودي. اتبع هذه الخطوات:

1. أنشئ مثيل من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. الوصول إلى الشريحة الأولى.
1. إضافة رسم بياني مع بيانات افتراضية.
1. الحصول على القيمة القصوى الفعلية على المحور.
1. الحصول على القيمة الدنيا الفعلية على المحور.
1. الحصول على الوحدة الرئيسية الفعلية للمحور.
1. الحصول على الوحدة الفرعية الفعلية للمحور.
1. الحصول على مقياس الوحدة الرئيسية الفعلية للمحور.
1. الحصول على مقياس الوحدة الفرعية الفعلية للمحور.

هذا الرمز النموذجي - تنفيذ للخطوات أعلاه - يوضح لك كيفية الحصول على القيم المطلوبة في بايثون:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
	chart.validate_chart_layout()

	maxValue = chart.axes.vertical_axis.actual_max_value
	minValue = chart.axes.vertical_axis.actual_min_value

	majorUnit = chart.axes.horizontal_axis.actual_major_unit
	minorUnit = chart.axes.horizontal_axis.actual_minor_unit
	
	# Saves the presentation
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```


## **تبديل البيانات بين المحاور**
Aspose.Slides يتيح لك بسرعة تبديل البيانات بين المحاور - البيانات الممثلة على المحور العمودي (محور y) تنتقل إلى المحور الأفقي (محور x) والعكس صحيح.

يظهر لك هذا الرمز في بايثون كيفية إجراء مهمة تبديل البيانات بين المحاور على رسم بياني:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Creates empty presentation
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    #Switches rows and columns
    chart.chart_data.switch_row_column()
            
    # Saves presentation
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تعطيل المحور العمودي لرسوم بيانية الخطوط**

يوضح لك هذا الرمز في بايثون كيفية إخفاء المحور العمودي لرسم بياني للخط:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **تعطيل المحور الأفقي لرسوم بيانية الخطوط**

يظهر لك هذا الرمز كيفية إخفاء المحور الأفقي لرسم بياني للخط:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **تغيير محور الفئات**

باستخدام خاصية **CategoryAxisType**، يمكنك تحديد نوع محور الفئات المفضل لديك (**تاريخ** أو **نص**). يظهر هذا الرمز في بايثون العملية:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS
    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين تنسيق التاريخ لقيمة محور الفئات**
Aspose.Slides لبايثون عبر .NET يتيح لك تعيين تنسيق التاريخ لقيمة محور الفئات. يتم توضيح العملية في هذا الرمز في بايثون:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
from datetime import date

def to_oadate(dt):
    delta = dt - date(1899, 12, 30)
    return delta.days + (delta.seconds + delta.microseconds / 1e6) / (24 * 3600)

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 50, 50, 450, 300)

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    chart.chart_data.categories.add(wb.get_cell(0, "A2", to_oadate(date(2015, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", to_oadate(date(2016, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", to_oadate(date(2017, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", to_oadate(date(2018, 1, 1))))

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B2", 1))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B3", 2))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B4", 3))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B5", 4))
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"
    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين زاوية الدوران لعنوان محور الرسم البياني**
Aspose.Slides لبايثون عبر .NET يتيح لك تعيين زاوية الدوران لعنوان محور الرسم البياني. يوضح هذا الرمز في بايثون العملية:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين محور الوضع في محور الفئات أو القيم**
Aspose.Slides لبايثون عبر .NET يتيح لك تعيين محور الوضع في محور الفئات أو القيم. يظهر هذا الرمز في بايثون كيفية إجراء المهمة:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **تمكين عرض وحدة التسمية على محور قيمة الرسم البياني**
Aspose.Slides لبايثون عبر .NET يتيح لك تكوين رسم بياني لعرض وحدة تسمية على محور قيمة الرسم البياني. يتم توضيح العملية في هذا الرمز في بايثون:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```