---
title: تخصيص محاور المخطط في العروض التقديمية باستخدام بايثون
linktitle: محور المخطط
type: docs
url: /ar/python-net/chart-axis/
keywords:
- محور المخطط
- المحور الرأسي
- المحور الأفقي
- تخصيص المحور
- تعديل المحور
- إدارة المحور
- خصائص المحور
- القيمة القصوى
- القيمة الدنيا
- خط المحور
- تنسيق التاريخ
- عنوان المحور
- موضع المحور
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "اكتشف كيفية استخدام Aspose.Slides للبايثون عبر .NET لتخصيص محاور المخطط في عروض PowerPoint وOpenDocument للتقارير والمرئيات."
---

## **الحصول على القيم القصوى على المحور الرأسي في المخططات**
Aspose.Slides للبايثون عبر .NET يتيح لك الحصول على القيم الدنيا والقصوى على المحور الرأسي. اتبع هذه الخطوات:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الوصول إلى الشريحة الأولى.
3. إضافة مخطط ببيانات افتراضية.
4. الحصول على القيمة القصوى الفعلية على المحور.
5. الحصول على القيمة الدنيا الفعلية على المحور.
6. الحصول على الوحدة الرئيسية الفعلية للمحور.
7. الحصول على الوحدة الفرعية الفعلية للمحور.
8. الحصول على مقياس الوحدة الرئيسية الفعلي للمحور.
9. الحصول على مقياس الوحدة الفرعية الفعلي للمحور.

يظهر هذا الكود التجريبي—تنفيذ للخطوات أعلاه—كيفية الحصول على القيم المطلوبة في بايثون:

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

## **تبادل البيانات بين المحاور**
Aspose.Slides يتيح لك تبادل البيانات بسرعة بين المحاور—البيانات الممثلة على المحور الرأسي (محور y) تنتقل إلى المحور الأفقي (محور x) والعكس.

يعرض هذا الكود بايثون كيفية تنفيذ مهمة تبادل البيانات بين المحاور في مخطط:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# ينشئ عرضًا تقديميًا فارغًا
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    # يبدل الصفوف والأعمدة
    chart.chart_data.switch_row_column()
            
    # يحفظ العرض التقديمي
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تعطيل المحور الرأسي لرسوم الخط**

يعرض هذا الكود بايثون كيفية إخفاء المحور الرأسي لرسوم الخط:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **تعطيل المحور الأفقي لرسوم الخط**

يعرض هذا الكود كيفية إخفاء المحور الأفقي لرسوم الخط:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **تغيير محور الفئة**

باستخدام الخاصية **CategoryAxisType**، يمكنك تحديد نوع محور الفئة المفضل لديك (**date** أو **text**). يوضح هذا الكود بايثون العملية:

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

## **تحديد تنسيق التاريخ لقيمة محور الفئة**
Aspose.Slides للبايثون عبر .NET يتيح لك تحديد تنسيق التاريخ لقيمة محور الفئة. يتم توضيح العملية في هذا الكود بايثون:

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

## **تحديد زاوية الدوران لعنوان محور المخطط**
Aspose.Slides للبايثون عبر .NET يتيح لك تحديد زاوية الدوران لعنوان محور المخطط. يوضح هذا الكود بايثون العملية:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **تحديد موضع المحور في محور الفئة أو القيمة**
Aspose.Slides للبايثون عبر .NET يتيح لك تحديد موضع المحور في محور الفئة أو القيمة. يوضح هذا الكود بايثون كيفية تنفيذ المهمة:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **تمكين ملصق وحدة العرض على محور قيمة المخطط**
Aspose.Slides للبايثون عبر .NET يتيح لك تكوين مخطط لإظهار ملصق وحدة على محور قيمة المخطط. يوضح هذا الكود بايثون العملية:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**كيف يمكنني تحديد القيمة التي يتقاطع عندها محور مع الآخر (تقاطع المحاور)؟**

المحاور توفر [إعداد التقاطع](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/): يمكنك اختيار التقاطع عند الصفر، أو عند الفئة/القيمة القصوى، أو عند قيمة رقمية محددة. هذا مفيد لتحريك محور X لأعلى أو لأسفل أو لتسليط الضوء على خط أساسي.

**كيف يمكنني وضع تسميات العلامات نسبة إلى المحور (بجانب، خارج، داخل)؟**

حدد [موضع التسمية](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) إلى "cross"، أو "outside"، أو "inside". يؤثر ذلك على قابلية القراءة ويساعد على توفير مساحة، خاصةً في المخططات الصغيرة.