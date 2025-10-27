---
title: تخصيص محاور المخطط في العروض التقديمية باستخدام بايثون
linktitle: محور المخطط
type: docs
url: /ar/python-net/developer-guide/presentation-content/powerpoint-charts/chart-entities/chart-axis/
keywords:
- محور المخطط
- المحور العمودي
- المحور الأفقي
- تخصيص المحور
- معالجة المحور
- إدارة المحور
- خصائص المحور
- القيمة العظمى
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
description: "اكتشف كيف تستخدم Aspose.Slides for Python via .NET لتخصيص محاور المخطط في عروض PowerPoint وOpenDocument للتقارير والتصورات."
---

## **الحصول على القيم العظمى على المحور العمودي في المخططات**
Aspose.Slides for Python via .NET يسمح لك بالحصول على القيم الصغرى والعظمى على المحور العمودي. اتبع هذه الخطوات:

1. أنشئ مثالًا من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الوصول إلى الشريحة الأولى.
3. إضافة مخطط ببيانات افتراضية.
4. الحصول على القيمة العظمى الفعلية للمحور.
5. الحصول على القيمة الصغرى الفعلية للمحور.
6. الحصول على الوحدة الرئيسية الفعلية للمحور.
7. الحصول على الوحدة الثانوية الفعلية للمحور.
8. الحصول على مقياس الوحدة الرئيسية الفعلي للمحور.
9. الحصول على مقياس الوحدة الثانوية الفعلي للمحور.

هذا الكود النموذجي—تنفيذ للخطوات أعلاه—يوضح لك كيفية الحصول على القيم المطلوبة في بايثون:

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
Aspose.Slides يسمح لك بتبديل البيانات بسرعة بين المحاور—البيانات المعروضة على المحور العمودي (y-axis) تنتقل إلى المحور الأفقي (x-axis) والعكس بالعكس.

هذا الكود بايثون يوضح كيفية أداء مهمة تبديل البيانات بين المحاور في مخطط:

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

## **إلغاء تفعيل المحور العمودي للمخططات الخطية**

هذا الكود بايثون يوضح كيفية إخفاء المحور العمودي لمخطط خطي:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **إلغاء تفعيل المحور الأفقي للمخططات الخطية**

هذا الكود يوضح كيفية إخفاء المحور الأفقي لمخطط خطي:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **تغيير محور الفئة**

باستخدام خاصية **CategoryAxisType**، يمكنك تحديد نوع محور الفئة المفضل لديك (**date** أو **text**). يوضح هذا الكود في بايثون العملية:

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

## **تعيين تنسيق التاريخ لقيمة محور الفئة**
Aspose.Slides for Python via .NET يسمح لك بتعيين تنسيق التاريخ لقيمة محور الفئة. تُظهر العملية في هذا الكود بايثون:

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

## **تعيين زاوية الدوران لعنوان محور المخطط**
Aspose.Slides for Python via .NET يسمح لك بتعيين زاوية الدوران لعنوان محور المخطط. يُظهر هذا الكود بايثون العملية:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين موضع المحور في محور الفئة أو القيمة**
Aspose.Slides for Python via .NET يسمح لك بتعيين موضع المحور في محور الفئة أو القيمة. يوضح هذا الكود بايثون كيفية أداء المهمة:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **تفعيل تسمية وحدة العرض على محور قيمة المخطط**
Aspose.Slides for Python via .NET يسمح لك بتكوين مخطط لإظهار تسمية وحدة على محور قيمة المخطط. يُظهر هذا الكود بايثون العملية:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**كيف يمكنني تعيين القيمة التي يتقاطع عندها محور مع الآخر (تقاطع المحاور)؟**

المحاور توفر إعدادًا لـ[التقاطع](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/): يمكنك اختيار التقاطع عند الصفر، عند أعلى فئة/قيمة، أو عند قيمة عددية محددة. هذا مفيد لتحريك محور X للأعلى أو للأسفل أو لتسليط الضوء على خط أساس.

**كيف يمكنني وضع تسميات العلامات بالنسبة للمحور ( بجانب، خارجي، داخلي)؟**

حدد [موضع التسمية](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) إلى "cross"، "outside"، أو "inside". يؤثر ذلك على قابلية القراءة ويساعد في توفير المساحة، خاصة في المخططات الصغيرة.