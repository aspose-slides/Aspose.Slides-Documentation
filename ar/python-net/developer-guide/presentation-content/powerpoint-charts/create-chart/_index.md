---
title: إنشاء أو تحديث مخططات PowerPoint التقديمية في بايثون
linktitle: إنشاء أو تحديث مخطط
type: docs
weight: 10
url: /ar/python-net/create-chart/
keywords:
- إضافة مخطط
- إنشاء مخطط
- تعديل مخطط
- تغيير مخطط
- تحديث مخطط
- مخطط مبعثر
- مخطط دائري
- مخطط خطي
- مخطط شجرة خريطة
- مخطط أسهم
- مخطط صندوق وويسكر
- مخطط قمع
- مخطط شمسي
- مخطط مدرج تكراري
- مخطط راداري
- مخطط متعدد الفئات
- عرض تقديمي PowerPoint
- بايثون
- Aspose.Slides
description: "تعرف على كيفية إنشاء وتخصيص المخططات في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لبايثون عبر .NET. يغطي إضافة وتنسيق وتعديل المخططات في العروض مع أمثلة عملية للشفرة بلغة بايثون."
---

## **نظرة عامة**

هذه المقالة توفر دليلًا شاملًا حول كيفية إنشاء وتخصيص المخططات باستخدام Aspose.Slides for Python عبر .NET. سوف تتعلم كيفية إضافة مخطط إلى شريحة برمجيًا، ملئه بالبيانات، وتطبيق خيارات تنسيق مختلفة لتتناسب مع متطلبات التصميم الخاصة بك. طوال المقالة، توضح أمثلة الكود التفصيلية كل خطوة، من تهيئة العرض التقديمي وكائن المخطط إلى تكوين السلاسل والمحاور والأساطير. باتباع هذا الدليل، ستحصل على فهم قوي لكيفية دمج إنشاء المخططات الديناميكية في تطبيقاتك، مما يبسط عملية إنشاء العروض التقديمية المستندة إلى البيانات.

## **إنشاء مخطط**

تساعد المخططات الأشخاص على تصور البيانات بسرعة واكتشاف رؤى قد لا تكون واضحة فورًا من جدول أو ورقة عمل.

**لماذا إنشاء المخططات؟**

باستخدام المخططات، يمكنك:

* تجميع أو تلخيص أو تلخيص كميات كبيرة من البيانات على شريحة واحدة في عرض تقديمي؛
* كشف الأنماط والاتجاهات في البيانات؛
* استنتاج الاتجاه والزخم للبيانات عبر الزمن أو بالنسبة لوحدة قياس معينة؛
* التعرف على القيم الشاذة، الانحرافات، الأخطاء، والبيانات غير المنطقية؛
* نقل أو تقديم بيانات معقدة.

في PowerPoint، يمكنك إنشاء المخططات عبر وظيفة *Insert* التي توفر قوالب لتصميم أنواع متعددة من المخططات. باستخدام Aspose.Slides، يمكنك إنشاء كل من المخططات العادية (المستندة إلى أنواع المخططات الشائعة) والمخططات المخصصة.

{{% alert color="primary" %}} 
استخدم تعداد [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) ضمن مساحة الاسم [Aspose.Slides.Charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/). القيم في هذا التعداد تتطابق مع أنواع المخططات المختلفة.
{{% /alert %}} 

### **إنشاء مخططات عمودية متجمعة**

توضح هذه الفقرة كيفية إنشاء مخططات عمودية متجمعة باستخدام Aspose.Slides for Python عبر .NET. ستتعلم كيفية تهيئة عرض تقديمي، إضافة مخطط، وتخصيص عناصره مثل العنوان والبيانات والسلاسل والفئات والتنسيق. اتبع الخطوات أدناه لرؤية كيفية إنشاء مخطط عمودي متجمع قياسي:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة مخطط مع بعض البيانات وتحديد النوع `ChartType.CLUSTERED_COLUMN`.
1. إضافة عنوان إلى المخطط.
1. الوصول إلى ورقة بيانات المخطط.
1. مسح جميع السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. إضافة بيانات مخطط جديدة لسلسلة المخطط.
1. تطبيق لون تعبئة على سلسلة المخطط.
1. إضافة تسميات إلى سلسلة المخطط.
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود بلغة Python يوضح كيفية إنشاء مخطط عمودي متجمع:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن Presentation الذي يمثل ملف PPTX.
with slides.Presentation() as presentation:

    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة مخطط عمودي متجمع بالبيانات الافتراضية.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # تعيين عنوان المخطط.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # ضبط السلسلة الأولى لإظهار القيم.
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # تحديد فهرس ورقة بيانات المخطط.
    worksheet_index = 0

    # الحصول على دفتر عمل بيانات المخطط.
    workbook = chart.chart_data.chart_data_workbook

    # حذف السلاسل والفئات الافتراضية التي تم إنشاؤها.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # إضافة سلاسل جديدة.
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

    # إضافة فئات جديدة.
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

    # الحصول على السلسلة الأولى للمخطط.
    series = chart.chart_data.series[0]

    # ملء بيانات السلسلة.
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # تعيين لون التعبئة للسلسلة.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # الحصول على السلسلة الثانية للمخطط.
    series = chart.chart_data.series[1]

    # ملء بيانات السلسلة.
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    # تعيين لون التعبئة للسلسلة.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    # تعيين التسمية الأولى لإظهار اسم الفئة.
    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    # تعيين السلسلة لإظهار القيمة للتسمية الثالثة.
    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"
                
    # حفظ العرض التقديمي إلى القرص كملف PPTX.
    presentation.save("ClusteredColumnChart.pptx", slides.export.SaveFormat.PPTX)
```


النتيجة:

![مخطط عمودي متجمع](clustered_column_chart.png)

### **إنشاء مخططات تبscatter**

مخططات التشتت (المعروفة أيضًا باسم مخططات النقط أو رسومات x‑y) تُستخدم عادة للتحقق من الأنماط أو إظهار الارتباطات بين متغيرين.

استخدم مخطط التشتت عندما:

* لديك بيانات عددية مقترنة.
* لديك متغيران يتكاملان معًا.
* تريد تحديد ما إذا كان المتغيران مرتبطين.
* لديك متغير مستقل له قيم متعددة للمتغير التابع.

هذا الكود بلغة Python يوضح كيفية إنشاء مخطط تشتت مع سلسلة علامات مختلفة:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن Presentation.
with slides.Presentation() as presentation:

    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # إنشاء مخطط تشتت افتراضي.
    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 20, 20, 500, 300)

    # تعيين فهرس ورقة بيانات المخطط.
    worksheet_index = 0

    # الحصول على دفتر عمل بيانات المخطط.
    workbook = chart.chart_data.chart_data_workbook

    # حذف السلسلة الافتراضية.
    chart.chart_data.series.clear()

    # إضافة سلاسل جديدة.
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 3, "Series 2"), chart.type)

    # الحصول على السلسلة الأولى للمخطط.
    series = chart.chart_data.series[0]

    # إضافة نقطة جديدة (1:3) إلى السلسلة.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 1, 1), workbook.get_cell(worksheet_index, 2, 2, 3))

    # إضافة نقطة جديدة (2:10).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 1, 2), workbook.get_cell(worksheet_index, 3, 2, 10))

    # تغيير نوع السلسلة.
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # تغيير علامة سلسلة المخطط.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # الحصول على السلسلة الثانية للمخطط.
    series = chart.chart_data.series[1]

    # إضافة نقطة جديدة (5:2) إلى سلسلة المخطط.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 5), workbook.get_cell(worksheet_index, 2, 4, 2))

    # إضافة نقطة جديدة (3:1).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 3, 3), workbook.get_cell(worksheet_index, 3, 4, 1))

    # إضافة نقطة جديدة (2:2).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 4, 3, 2), workbook.get_cell(worksheet_index, 4, 4, 2))

    # إضافة نقطة جديدة (5:1).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 5, 3, 5), workbook.get_cell(worksheet_index, 5, 4, 1))

    # تغيير علامة سلسلة المخطط.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("ScatterChart.pptx", slides.export.SaveFormat.PPTX)
```



النتيجة:

![مخطط تشتت](scatter_chart.png)

### **إنشاء مخططات دائرية**

تُعد المخططات الدائرية مثالية لإظهار العلاقة بين الجزء والكامل في البيانات، خاصة عندما تحتوي البيانات على تسميات فئوية مع قيم عددية. ومع ذلك، إذا كانت بياناتك تحتوي على العديد من الأجزاء أو التسميات، قد ترغب في استخدام مخطط شريطي بدلاً من ذلك.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة مخطط ببيانات افتراضية وتحديد النوع `ChartType.PIE`.
1. الوصول إلى دفتر عمل بيانات المخطط ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).
1. مسح السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. إضافة بيانات مخطط جديدة لسلسلة المخطط.
1. إضافة نقاط جديدة للمخطط وتطبيق ألوان مخصصة على قطاعات المخطط الدائري.
1. ضبط التسميات للسلاسل.
1. تمكين خطوط القادة لتسميات السلاسل.
1. ضبط زاوية الدوران للمخطط الدائري.
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود بلغة Python يوضح كيفية إنشاء مخطط دائري:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن Presentation الذي يمثل ملف PPTX.
with slides.Presentation() as presentation:

    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة مخطط مع البيانات الافتراضية.
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    # تعيين عنوان المخطط.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # ضبط السلسلة الأولى لإظهار القيم.
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # تعيين فهرس ورقة بيانات المخطط.
    worksheet_index = 0

    # الحصول على دفتر عمل بيانات المخطط.
    workbook = chart.chart_data.chart_data_workbook

    # حذف السلاسل والفئات الافتراضية التي تم إنشاؤها.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # إضافة فئات جديدة.
    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "First Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "2nd Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "3rd Qtr"))

    # إضافة سلاسل جديدة.
    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # ملء بيانات السلسلة.
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # تعيين لون القطاع.
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan

    # تعيين حدود القطاع.
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # تعيين حدود القطاع.
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # تعيين حدود القطاع.
    point2.format.line.fill_format.fill_type = slides.FillType.SOLID
    point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
    point2.format.line.width = 2.0
    point2.format.line.style = slides.LineStyle.THIN_THIN
    point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    # إنشاء تسميات مخصصة لكل فئة في السلسلة الجديدة.
    label1 = series.data_points[0].label

    label1.data_label_format.show_value = True

    label2 = series.data_points[1].label
    label2.data_label_format.show_value = True
    label2.data_label_format.show_legend_key = True
    label2.data_label_format.show_percentage = True

    label3 = series.data_points[2].label
    label3.data_label_format.show_series_name = True
    label3.data_label_format.show_percentage = True

    # ضبط السلسلة لإظهار خطوط القادة للمخطط.
    series.labels.default_data_label_format.show_leader_lines = True

    # تعيين زاوية الدوران لقطاعات المخطط الدائري.
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # حفظ العرض التقديمي إلى القرص كملف PPTX.
    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```


النتيجة:

![مخطط دائري](pie_chart.png)

### **إنشاء مخططات خطية**

تُستخدم مخططات الخط (المعروفة أيضًا باسم رسومات الخط) في الحالات التي ترغب فيها بإظهار تغيّر القيم عبر الزمن. باستخدام مخطط خط، يمكنك مقارنة كمية كبيرة من البيانات في وقت واحد، تتبع التغييرات والاتجاهات عبر الزمن، تسليط الضوء على الشذوذ في سلاسل البيانات، وأكثر من ذلك.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة مخطط ببيانات افتراضية وتحديد النوع `ChartType.LINE`.
1. الوصول إلى دفتر عمل بيانات المخطط ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).
1. مسح السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. إضافة بيانات مخطط جديدة لسلسلة المخطط.
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود بلغة Python يوضح كيفية إنشاء مخطط خطي:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 20, 20, 500, 300)
    
    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```


افتراضيًا، يتم ربط النقاط في مخطط الخط بخطوط مستمرة مستقيمة. إذا رغبت في ربط النقاط بشرطات متقطعة، يمكنك تحديد نوع الشرط المفضل كما يلي:
```python
line_chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

for series in line_chart.chart_data.series:
    series.format.line.dash_style = slides.charts.LineDashStyle.DASH
```


النتيجة:

![مخطط خطي](line_chart.png)

### **إنشاء مخططات شجرة خريطة**

تُستخدم مخططات شجرة الخريطة لبيانات المبيعات عندما ترغب في إظهار الحجم النسبي لفئات البيانات وجذب الانتباه بسرعة إلى العناصر الكبيرة المساهمة داخل كل فئة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة مخطط ببيانات افتراضية وتحديد النوع `ChartType.TREEMAP`.
1. الوصول إلى دفتر عمل بيانات المخطط ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).
1. مسح السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. إضافة بيانات مخطط جديدة لسلسلة المخطط.
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود بلغة Python يوضح كيفية إنشاء مخطط شجرة خريطة:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.TREEMAP, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # الفرع 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # الفرع 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D8", 3))

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    presentation.save("TreeMap.pptx", slides.export.SaveFormat.PPTX)
```


النتيجة:

![مخطط شجرة خريطة](treemap_chart.png)

### **إنشاء مخططات أسهم**

تُستخدم مخططات الأسهم لعرض البيانات المالية مثل أسعار الفتح، الأعلى، الأدنى، والإغلاق، مما يساعد على تحليل اتجاهات السوق وتقلباته. توفر هذه المخططات رؤى أساسية حول أداء السهم، وتساعد المستثمرين والمحللين في اتخاذ قرارات مستنيرة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة مخطط ببيانات افتراضية وتحديد النوع `ChartType.OPEN_HIGH_LOW_CLOSE`.
1. الوصول إلى دفتر عمل بيانات المخطط ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).
1. مسح السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. إضافة بيانات مخطط جديدة لسلسلة المخطط.
1. تحديد تنسيق خطوط HiLowLines.
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود بلغة Python يوضح كيفية إنشاء مخطط أسهم:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 20, 20, 500, 300, False)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "A"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "B"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C"))

    chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Open"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "High"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 3, "Low"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 4, "Close"), chart.type)

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 1, 72))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 1, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 1, 38))

    series = chart.chart_data.series[1]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 2, 172))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 2, 57))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 2, 57))

    series = chart.chart_data.series[2]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 3, 13))

    series = chart.chart_data.series[3]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 4, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 4, 38))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 4, 50))

    chart.chart_data.series_groups[0].up_down_bars.has_up_down_bars = True
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for ser in chart.chart_data.series:
        ser.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("StockChart.pptx", slides.export.SaveFormat.PPTX)
```


النتيجة:

![مخطط أسهم](stock_chart.png)

### **إنشاء مخططات الصندوق والوشاح**

تُستخدم مخططات الصندوق والوشاح لعرض توزيع البيانات عبر تلخيص مقاييس إحصائية رئيسية مثل الوسيط، الأرباع، والقيم الشاذة المحتملة. إنها مفيدة بشكل خاص في التحليل الاستكشافي للبيانات والدراسات الإحصائية لفهم تباين البيانات بسرعة وتحديد أي شذوذ.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة مخطط ببيانات افتراضية وتحديد النوع `ChartType.BOX_AND_WHISKER`.
1. الوصول إلى دفتر عمل بيانات المخطط ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).
1. مسح السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. إضافة بيانات مخطط جديدة لسلسلة المخطط.
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود بلغة Python يوضح كيفية إنشاء مخطط صندوق ووشاح:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 1"))

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B1", 15))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B2", 41))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B3", 16))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B4", 10))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B5", 23))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B6", 16))

    presentation.save("BoxAndWhiskerChart.pptx", slides.export.SaveFormat.PPTX)
```


### **إنشاء مخططات القمع**

تُستخدم مخططات القمع لتصوير العمليات التي تشمل مراحل متسلسلة، حيث يقل حجم البيانات كلما انتقلت من خطوة إلى التالية. إنها مفيدة بشكل خاص لتحليل معدلات التحويل، تحديد الاختناقات، وتتبع كفاءة عمليات المبيعات أو التسويق.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة مخطط ببيانات افتراضية وتحديد النوع `ChartType.FUNNEL`.
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود بلغة Python يوضح كيفية إنشاء مخطط قمع:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 4"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 5"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 6"))

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B1", 50))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B2", 100))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B3", 200))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B4", 300))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B5", 400))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B6", 500))

    presentation.save("FunnelChart.pptx", slides.export.SaveFormat.PPTX)
```


النتيجة:

![مخطط قمع](funnel_chart.png)

### **إنشاء مخططات الشمسية**

تُستخدم مخططات الشمسية لتصوير البيانات الهرمية، حيث تُظهر المستويات كحلقة متحدة المركز. تساعد هذه المخططات في توضيح العلاقات بين الجزء والكامل وتُعد مثالية لتمثيل الفئات المتداخلة والفرعية بشكل واضح ومُدمج.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة مخطط ببيانات افتراضية وتحديد النوع `ChartType.SUNBURST`.
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود بلغة Python يوضح كيفية إنشاء مخطط شمسي:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # الفرع 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # الفرع 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D8", 3))

    presentation.save("SunburstChart.pptx", slides.export.SaveFormat.PPTX)
```


النتيجة:

![مخطط شمسي](sunburst_chart.png)

### **إنشاء مخططات المدرج التكراري**

تُستخدم مخططات المدرج التكراري لتمثيل توزيع البيانات الرقمية من خلال تجميع القيم في فواصل أو صناديق. إنها مفيدة بشكل خاص لتحديد أنماط البيانات مثل التكرار، الانحراف، والانتشار، وكذلك لاكتشاف القيم الشاذة في مجموعة البيانات.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة مخطط ببعض البيانات وتحديد النوع `ChartType.HISTOGRAM`.
1. الوصول إلى دفتر عمل بيانات المخطط ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).
1. مسح السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود بلغة Python يوضح كيفية إنشاء مخطط المدرج التكراري:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A1", 15))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A2", -41))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A3", 16))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A4", 10))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A5", -23))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A6", 16))

    chart.axes.horizontal_axis.aggregation_type = charts.AxisAggregationType.AUTOMATIC

    presentation.save("HistogramChart.pptx", slides.export.SaveFormat.PPTX)
```


النتيجة:

![مخطط المدرج التكراري](histogram_chart.png)

### **إنشاء مخططات رادارية**

تُستخدم مخططات الرادار لعرض البيانات المتعددة المتغيرات في تنسيق ثنائي الأبعاد، مما يسمح بالمقارنة السهلة للمتغيرات المتعددة في آن واحد. إنها مفيدة بشكل خاص لتحديد الأنماط، نقاط القوة، والضعف عبر مجموعة من مؤشرات الأداء أو السمات.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة مخطط ببعض البيانات وتحديد النوع `ChartType.RADAR`.
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود بلغة Python يوضح كيفية إنشاء مخطط راداري:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 500, 300)
    presentation.save("RadarСhart.pptx", slides.export.SaveFormat.PPTX)
```


النتيجة:

![مخطط راداري](radar_chart.png)

### **إنشاء مخططات متعددة الفئات**

تُستخدم مخططات متعددة الفئات لعرض بيانات تنطوي على أكثر من تجميع تصنيفي واحد، مما يتيح لك مقارنة القيم عبر أبعاد متعددة في آن واحد. إنها مفيدة بشكل خاص عندما تحتاج إلى تحليل الاتجاهات والعلاقات داخل مجموعات بيانات معقدة متعددة الطبقات.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة مخطط ببيانات افتراضية وتحديد النوع `ChartType.CLUSTERED_COLUMN`.
1. الوصول إلى دفتر عمل بيانات المخطط ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).
1. مسح السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. إضافة بيانات مخطط جديدة لسلسلة المخطط.
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود بلغة Python يوضح كيفية إنشاء مخطط متعدد الفئات:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    worksheet_index = 0

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c2", "A"))
    category.grouping_levels.set_grouping_item(1, "Group1")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c3", "B"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c4", "C"))
    category.grouping_levels.set_grouping_item(1, "Group2")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c5", "D"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c6", "E"))
    category.grouping_levels.set_grouping_item(1, "Group3")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c7", "F"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c8", "G"))
    category.grouping_levels.set_grouping_item(1, "Group4")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c9", "H"))

    # إضافة سلسلة.
    series = chart.chart_data.series.add(workbook.get_cell(0, "D1", "Series 1"), charts.ChartType.CLUSTERED_COLUMN)

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D2", 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D3", 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D4", 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D5", 40))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D6", 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D7", 60))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D8", 70))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D9", 80))

    # حفظ العرض التقديمي مع المخطط.
    presentation.save("MultiCategoryChart.pptx", slides.export.SaveFormat.PPTX)
```



النتيجة:

![مخطط متعدد الفئات](multi_category_chart.png)

### **إنشاء مخططات الخريطة**

تُستخدم مخططات الخريطة لتصوير البيانات الجغرافية عبر ربط المعلومات بمواقع محددة مثل دول أو ولايات أو مدن. إنها مفيدة بشكل خاص لتحليل الاتجاهات الإقليمية، البيانات الديموغرافية، والتوزيعات المكانية بطريقة واضحة وجذابة بصريًا.

هذا الكود بلغة Python يوضح كيفية إنشاء مخطط خريطة:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 20, 20, 500, 300)
    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```


النتيجة:

![مخطط خريطة](map_chart.png)

### **إنشاء مخططات مركبة**

المخطط المركب (أو مخطط الجمع) هو مخطط يجمع نوعين أو أكثر من المخططات في رسم بياني واحد. يتيح هذا النوع من المخططات إبراز أو مقارنة أو مراجعة الفروقات بين مجموعتين أو أكثر من البيانات، مما يمكنك من التعرف على أي علاقات بينها.

![مخطط مركب](combination_chart.png)

هذا الكود بلغة Python يوضح كيفية إنشاء مخطط مركب في عرض تقديمي PowerPoint:
```python
import aspose.slides as slides
import aspose.slides.charts as charts


def create_combo_chart():
    presentation = slides.Presentation()

    chart = create_chart(presentation.slides[0])
    add_first_series_to_chart(chart)
    add_second_series_to_chart(chart)

    presentation.save("ComboChart.pptx", slides.export.SaveFormat.PPTX)


def create_chart(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    series = chart.chart_data.series[1]

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    return chart


def add_first_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), charts.ChartType.SCATTER_WITH_SMOOTH_LINES)

    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 0, 1, 3), workbook.get_cell(worksheet_index, 0, 2, 5))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 3, 10), workbook.get_cell(worksheet_index, 1, 4, 13))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 20), workbook.get_cell(worksheet_index, 2, 4, 15))

    series.plot_on_second_axis = True


def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 5, "Series 4"), charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS)

    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 3, 5), workbook.get_cell(worksheet_index, 1, 4, 2))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 5, 10), workbook.get_cell(worksheet_index, 1, 6, 7))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 5, 15), workbook.get_cell(worksheet_index, 2, 6, 12))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 5, 12), workbook.get_cell(worksheet_index, 3, 6, 9))

    series.plot_on_second_axis = True
```


## **تحديث المخططات**

تمكنك Aspose.Slides for Python عبر .NET من تحديث مخططات PowerPoint من خلال تعديل بيانات المخطط، تنسيقه، وتنسيقه. تُبسّط هذه الوظيفة عملية الحفاظ على تحديث العروض التقديمية بالمحتوى الديناميكي وتضمن أن المخططات تعكس بدقة البيانات الحالية والمعايير البصرية.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي تمثل العرض التقديمي الذي يحتوي على مخطط.
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. استعراض جميع الأشكال للعثور على المخطط.
1. الوصول إلى ورقة بيانات المخطط.
1. تعديل سلاسل بيانات المخطط بتغيير قيم السلاسل.
1. إضافة سلسلة جديدة وتعبئة بياناتها.
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود بلغة Python يوضح كيفية تحديث مخطط:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# إنشاء كائن Presentation الذي يمثل ملف PPTX.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape

            # تعيين فهرس ورقة بيانات المخطط.
            worksheet_index = 0

            # الحصول على دفتر عمل بيانات المخطط.
            workbook = chart.chart_data.chart_data_workbook

            # تغيير أسماء فئات المخطط.
            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            # الحصول على السلسلة الأولى للمخطط.
            series = chart.chart_data.series[0]

            # تحديث بيانات السلسلة.
            workbook.get_cell(worksheet_index, 0, 1, "New_Series1")  # تعديل اسم السلسلة.
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            # الحصول على السلسلة الثانية للمخطط.
            series = chart.chart_data.series[1]

            # تحديث بيانات السلسلة.
            workbook.get_cell(worksheet_index, 0, 2, "New_Series2")  # تعديل اسم السلسلة.
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            # إضافة سلسلة جديدة.
            series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), chart.type)

            # ملء بيانات السلسلة.
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 3, 20))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 3, 50))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 3, 30))

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

            # حفظ العرض التقديمي مع المخطط.
            presentation.save("ModifiedChart.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين نطاق البيانات للمخططات**

توفر Aspose.Slides for Python عبر .NET مرونة تحديد نطاق بيانات معين من ورقة عمل كمصدر لبيانات المخطط الخاص بك. يعني ذلك أنه يمكنك ربط جزء من ورقة العمل مباشرة بالمخطط، مما يسمح لك بالتحكم في الخلايا التي تُساهم في سلاسل المخطط وفئاته. وبالتالي، يمكنك بسهولة تحديث وتزامن مخططاتك مع أحدث تغييرات البيانات في ورقة العمل، لضمان أن عروض PowerPoint تعكس معلومات دقيقة ومُحدَّثة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي تمثل العرض التقديمي الذي يحتوي على مخطط.
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. استعراض جميع الأشكال للعثور على المخطط.
1. الوصول إلى بيانات المخطط وتعيين النطاق.
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود بلغة Python يوضح كيفية تعيين نطاق بيانات لمخطط:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# إنشاء كائن Presentation الذي يمثل ملف PPTX.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            chart.chart_data.set_range("Sheet1!A1:B4")

    presentation.save("DataRange.pptx", slides.export.SaveFormat.PPTX)
```


## **استخدام العلامات الافتراضية في المخططات**

عند استخدام العلامات الافتراضية في المخططات، يحصل كل سلسلة مخطط على رمز علامة افتراضي مختلف تلقائيًا.

هذا الكود بلغة Python يوضح كيفية تعيين علامة سلسلة مخطط تلقائيًا:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "C1"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 1, 24))

    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "C2"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 1, 23))

    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C3"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 1, -10))

    chart.chart_data.categories.add(workbook.get_cell(0, 4, 0, "C4"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 1, None))

    series2 = chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "Series 2"), chart.type)

    # ملء بيانات السلسلة.
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 2, 30))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 2, 10))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 2, 60))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 2, 40))

    chart.has_legend = True
    chart.legend.overlay = False

    presentation.save("DefaultMarkersInChart.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة الشائعة**

**ما أنواع المخططات التي تدعمها Aspose.Slides for Python عبر .NET؟**

تدعم Aspose.Slides for Python عبر .NET مجموعة واسعة من أنواع المخططات، بما في ذلك العمودي، الخط، الدائري، المنطقة، التشتت، المدرج التكراري، الراداري، وغيرها الكثير. تتيح لك هذه المرونة اختيار النوع الأنسب لتصوير البيانات وفقًا لاحتياجاتك.

**كيف أضيف مخططًا جديدًا إلى شريحة؟**

لإضافة مخطط، قم أولاً بإنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، احصل على الشريحة المطلوبة باستخدام فهرسها، ثم استدعِ الطريقة لإضافة مخطط، مع تحديد نوع المخطط والبيانات الأولية. يدمج ذلك المخطط مباشرةً في عرضك التقديمي.

**كيف يمكنني تحديث البيانات المعروضة في مخطط؟**

يمكنك تحديث بيانات المخطط بالوصول إلى دفتر عمل بياناته ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/))، مسح أي سلاسل وفئات افتراضية، ثم إضافة بياناتك المخصصة. يتيح لك ذلك تحديث المخطط برمجيًا ليعكس أحدث البيانات.

**هل يمكن تخصيص مظهر المخطط؟**

نعم، توفر Aspose.Slides for Python عبر .NET خيارات تخصيص واسعة. يمكنك تعديل الألوان، الخطوط، التسميات، الأساطير، وعناصر التنسيق الأخرى لتناسب متطلبات التصميم الخاصة بك.