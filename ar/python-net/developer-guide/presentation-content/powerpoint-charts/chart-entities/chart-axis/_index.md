---
title: تخصيص محاور المخططات في العروض التقديمية باستخدام بايثون
linktitle: محور المخطط
type: docs
url: /ar/python-net/chart-axis/
keywords:
- محور المخطط
- المحور العمودي
- المحور الأفقي
- تخصيص المحور
- معالجة المحور
- إدارة المحور
- خصائص المحور
- القيمة القصوى
- القيمة الصغرى
- خط المحور
- تنسيق التاريخ
- عنوان المحور
- موضع المحور
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "اكتشف كيفية استخدام Aspose.Slides لبايثون عبر .NET لتخصيص محاور المخططات في عروض PowerPoint و OpenDocument التقديمية للتقارير والتصورات."
---

## **الحصول على القيم القصوى للمحور العمودي في المخططات**
Aspose.Slides for Python عبر .NET تتيح لك الحصول على القيم الصغرى والعظمى على محور عمودي. اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط ببيانات افتراضية.
1. الحصول على القيمة القصوى الفعلية على المحور.
1. الحصول على القيمة الصغرى الفعلية على المحور.
1. الحصول على الوحدة الرئيسية الفعلية للمحور.
1. الحصول على الوحدة الفرعية الفعلية للمحور.
1. الحصول على مقياس الوحدة الرئيسية الفعلية للمحور.
1. الحصول على مقياس الوحدة الفرعية الفعلية للمحور.

هذا الكود المثال—تنفيذ للخطوات أعلاه—يظهر لك كيفية الحصول على القيم المطلوبة في Python:
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
	
	# يحفظ العرض التقديمي
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```


## **تبديل البيانات بين المحاور**
Aspose.Slides يسمح لك بسرعة بتبديل البيانات بين المحاور—البيانات الموجودة على المحور العمودي (y-axis) تنتقل إلى المحور الأفقي (x-axis) والعكس بالعكس.

هذا الكود Python يوضح كيفية تنفيذ مهمة تبديل البيانات بين المحاور في مخطط:
```py
import aspose.slides.charts as charts
import aspose.slides as slides

# إنشاء عرض تقديمي فارغ
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    #تبديل الصفوف والأعمدة
    chart.chart_data.switch_row_column()
            
    # حفظ العرض التقديمي
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```


## **تعطيل المحور العمودي للمخططات الخطية**

هذا الكود Python يوضح لك كيفية إخفاء المحور العمودي لمخطط خطي:
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```


## **تعطيل المحور الأفقي للمخططات الخطية**

هذا الكود يوضح لك كيفية إخفاء المحور الأفقي لمخطط خطي:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```


## **تغيير محور الفئة**

باستخدام الخاصية **CategoryAxisType**، يمكنك تحديد نوع محور الفئة المفضل لديك (**date** أو **text**). هذا الكود في Python يوضح العملية:
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


## **ضبط تنسيق التاريخ لقيمة محور الفئة**
Aspose.Slides for Python عبر .NET تتيح لك ضبط تنسيق التاريخ لقيمة محور الفئة. تم توضيح العملية في هذا الكود Python:
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


## **ضبط زاوية الدوران لعنوان محور المخطط**
Aspose.Slides for Python عبر .NET تتيح لك ضبط زاوية الدوران لعنوان محور المخطط. هذا الكود Python يوضح العملية:
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```


## **ضبط موضع المحور في محور الفئة أو قيم المحور**
Aspose.Slides for Python عبر .NET تتيح لك ضبط موضع المحور في محور الفئة أو قيم المحور. هذا الكود Python يوضح كيفية تنفيذ المهمة:
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```


## **تمكين ملصق وحدة العرض على محور قيم المخطط**
Aspose.Slides for Python عبر .NET تتيح لك تكوين المخطط لإظهار ملصق وحدة على محور قيم المخطط. هذا الكود Python يوضح العملية:
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**كيف يمكنني تعيين القيمة التي يتقاطع عندها محور مع الآخر (تقاطع المحور)؟**

توفر المحاور [إعداد التقاطع](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/): يمكنك اختيار التقاطع عند الصفر أو عند أقصى فئة/قيمة أو عند قيمة رقمية محددة. هذا مفيد لتحريك محور X إلى الأعلى أو الأسفل أو لتأكيد خط أساس.

**كيف يمكنني موضع تسميات العلامات بالنسبة للمحور (جنبًا إلى جنب، خارجًا، داخلًا)؟**

قم بتعيين [موقع التسمية](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) إلى "cross" أو "outside" أو "inside". يؤثر ذلك على قابلية القراءة ويساعد في توفير المساحة، خاصةً في المخططات الصغيرة.