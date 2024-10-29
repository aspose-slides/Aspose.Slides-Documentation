---
title: إنشاء الرسوم البيانية في عرض PowerPoint باستخدام Python
linktitle: إنشاء الرسم البياني
type: docs
weight: 10
url: /ar/python-net/create-chart/
keywords: "إنشاء رسم بياني، رسم بياني متناثر، رسم بياني دائري، رسم بياني للخرائط الشجرية، رسم بياني للأسهم، رسم بياني للصندوق والشعيرات، رسم بياني مدرج، رسم بياني القمع، رسم بياني أشعة الشمس، رسم بياني متعدد الفئات، عرض PowerPoint، Python، Aspose.Slides لـ Python عبر .NET"
description: "إنشاء رسم بياني في عرض PowerPoint باستخدام Python"
---

## **إنشاء رسم بياني**

تساعد الرسوم البيانية الناس على تصور البيانات بسرعة والحصول على رؤى قد لا تكون واضحة على الإطلاق من جدول أو ورقة عمل.

**لماذا إنشاء رسوم بيانية؟**

باستخدام الرسوم البيانية، يمكنك

* تجميع أو تلخيص كميات كبيرة من البيانات على شريحة واحدة في عرض تقديمي
* كشف الأنماط والاتجاهات في البيانات
* استنتاج الاتجاه والزخم للبيانات بمرور الوقت أو بالنسبة لوحدة قياس معينة
* كشف النقاط الشاذة والانحرافات والأخطاء والبيانات غير المنطقية، إلخ.
* التواصل أو تقديم بيانات معقدة

في PowerPoint، يمكنك إنشاء الرسوم البيانية من خلال وظيفة الإدراج، التي توفر قوالب تُستخدم لتصميم أنواع متعددة من الرسوم البيانية. باستخدام Aspose.Slides، يمكنك إنشاء رسوم بيانية عادية (استنادًا إلى أنواع الرسوم البيانية الشائعة) ورسوم بيانية مخصصة.

{{% alert color="primary" %}}

لتمكينك من إنشاء الرسوم البيانية، يوفر Aspose.Slides تعيين [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) ضمن مساحة اسم [Aspose.Slides.Charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/). تتوافق الأعضاء تحت هذا العد مع أنواع الرسوم البيانية المختلفة.

{{% /alert %}}

### **إنشاء رسوم بيانية عادية**
1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع الشريحة من خلال فهرسها.
1. أضف رسمًا بيانيًا مع بعض البيانات وحدد نوع الرسم البياني المفضل لديك.
1. أضف عنوانًا للرسم البياني.
1. الوصول إلى ورقة بيانات الرسم البياني.
1. امسح جميع السلاسل والفئات الافتراضية.
1. أضف سلاسل وفئات جديدة.
1. أضف بعض البيانات الجديدة للرسم البياني لسلاسل الرسم البياني.
1. أضف لون تعبئة لسلسلة الرسم البياني.
1. أضف تسميات لسلاسل الرسم البياني.
1. اكتب العرض المعدل كملف PPTX.

هذا الرمز بلغة Python يوضح لك كيفية إنشاء رسم بياني عادي:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# أنشئ مثيلًا من فئة Presentation التي تمثل ملف PPTX
with slides.Presentation() as pres:

    # الوصول إلى الشريحة الأولى
    sld = pres.slides[0]

    # إضافة الرسم البياني مع البيانات الافتراضية
    chart = sld.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 0, 0, 500, 500)

    # تعيين عنوان الرسم البياني
    chart.chart_title.add_text_frame_for_overriding("عنوان عشوائي")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
    chart.chart_title.height = 20
    chart.has_title = True

    # تعيين السلسلة الأولى لإظهار القيم
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # تعيين فهرس ورقة البيانات للرسم البياني
    defaultWorksheetIndex = 0

    # الحصول على ورقة بيانات الرسم البياني
    fact = chart.chart_data.chart_data_workbook

    # حذف السلاسل والفئات الافتراضية المولدة
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    s = len(chart.chart_data.series)
    s = len(chart.chart_data.categories)

    # إضافة سلاسل جديدة
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "السلسلة 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "السلسلة 2"), chart.type)

    # إضافة فئات جديدة
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "الفئة 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "الفئة 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "الفئة 3"))

    # أخذ السلسلة الأولى للرسم البياني
    series = chart.chart_data.series[0]

    # الآن يتم ملء بيانات السلسلة

    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

    # تعيين لون التعبئة للسلسلة
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red


    # أخذ السلسلة الثانية للرسم البياني
    series = chart.chart_data.series[1]

    # الآن يتم ملء بيانات السلسلة
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # تعيين لون التعبئة للسلسلة
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    # ستظهر التسمية الأولى اسم الفئة
    lbl = series.data_points[0].label
    lbl.data_label_format.show_category_name = True

    lbl = series.data_points[1].label
    lbl.data_label_format.show_series_name = True

    # إظهار القيمة للتسمية الثالثة
    lbl = series.data_points[2].label
    lbl.data_label_format.show_value = True
    lbl.data_label_format.show_series_name = True
    lbl.data_label_format.separator = "/"
                
    # حفظ العرض مع الرسم البياني
    pres.save("AsposeChart_out-1.pptx", slides.export.SaveFormat.PPTX)
```


### **إنشاء الرسوم البيانية المتناثرة**
تستخدم الرسوم البيانية المتناثرة (المعروفة أيضًا باسم المخططات المتناثرة أو المخططات x-y) غالبًا للتحقق من الأنماط أو لإظهار العلاقات بين متغيرين.

قد ترغب في استخدام الرسم البياني المتناثر عندما 

* يكون لديك بيانات رقمية متزاوجة
* لديك متغيران يتناسبان بشكل جيد معًا
* تريد تحديد ما إذا كان هناك ارتباط بين متغيرين
* لديك متغير مستقل له قيم متعددة لمتغير تابع

هذا الرمز بلغة Python يوضح لك كيفية إنشاء الرسوم البيانية المتناثرة مع مجموعة مختلفة من العلامات:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    slide = pres.slides[0]

    # إنشاء الرسم البياني الافتراضي
    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 0, 0, 400, 400)

    # الحصول على فهرس ورقة بيانات الرسم البياني الافتراضية
    defaultWorksheetIndex = 0

    # الحصول على ورقة بيانات الرسم البياني
    fact = chart.chart_data.chart_data_workbook

    # حذف السلاسل التجريبية
    chart.chart_data.series.clear()

    # إضافة سلاسل جديدة
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "السلسلة 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 3, "السلسلة 2"), chart.type)

    # أخذ السلسلة الأولى للرسم البياني
    series = chart.chart_data.series[0]

    # إضافة نقطة جديدة (1:3) هناك.
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 1), fact.get_cell(defaultWorksheetIndex, 2, 2, 3))

    # إضافة نقطة جديدة (2:10)
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 2), fact.get_cell(defaultWorksheetIndex, 3, 2, 10))

    # تعديل نوع السلسلة
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # تغيير علامة سلسلة الرسم البياني
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # أخذ السلسلة الثانية للرسم البياني
    series = chart.chart_data.series[1]

    # إضافة نقطة جديدة (5:2) هناك.
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 2, 3, 5), fact.get_cell(defaultWorksheetIndex, 2, 4, 2))

    # إضافة نقطة جديدة (3:1)
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 3, 3, 3), fact.get_cell(defaultWorksheetIndex, 3, 4, 1))

    # إضافة نقطة جديدة (2:2)
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 4, 3, 2), fact.get_cell(defaultWorksheetIndex, 4, 4, 2))

    # إضافة نقطة جديدة (5:1)
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 5, 3, 5), fact.get_cell(defaultWorksheetIndex, 5, 4, 1))

    # تغيير علامة سلسلة الرسم البياني
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    pres.save("AsposeChart_out-2.pptx", slides.export.SaveFormat.PPTX)
```

### **إنشاء الرسوم البيانية الدائرية**

تستخدم الرسوم البيانية الدائرية بشكل أفضل لإظهار العلاقة بين الجزء والكل في البيانات، خاصة عندما تحتوي البيانات على تسميات فئوية مع قيم عددية. ومع ذلك، إذا كانت بياناتك تحتوي على العديد من الأجزاء أو التسميات، فقد ترغب في اعتبار استخدام رسم بياني شريطي بدلاً من ذلك.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع الشريحة من خلال فهرسها.
1. أضف رسمًا بيانيًا مع البيانات الافتراضية جنبًا إلى جنب مع النوع المطلوب (في هذه الحالة، `ChartType.PIE`).
1. الوصول إلى بيانات الرسم البياني IChartDataWorkbook.
1. امسح السلاسل والفئات الافتراضية.
1. أضف سلاسل وفئات جديدة.
1. أضف بيانات جديدة للرسم البياني منذ السلسلة.
1. أضف نقاط جديدة للرسوم البيانية وأضف ألوان مخصصة لقطاعات الرسم البياني الدائري.
1. تعيين تسميات للسلاسل.
1. تعيين خطوط الاتصال لتسميات السلاسل.
1. تعيين زاوية الدوران لشرائح الرسم البياني الدائري.
1. اكتب العرض المعدل إلى ملف PPTX.

هذا الرمز بلغة Python يوضح لك كيفية إنشاء رسم بياني دائري:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# أنشئ مثيلًا من فئة Presentation التي تمثل ملف PPTX
with slides.Presentation() as presentation:

    # الوصول إلى الشريحة الأولى
    slide = presentation.slides[0]

    # إضافة رسم بياني مع البيانات الافتراضية
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # تعيين عنوان الرسم البياني
    chart.chart_title.add_text_frame_for_overriding("عنوان عشوائي")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
    chart.chart_title.height = 20
    chart.has_title = True

    # تعيين السلسلة الأولى لإظهار القيم
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # تعيين فهرس ورقة البيانات للرسم البياني
    defaultWorksheetIndex = 0

    # الحصول على ورقة بيانات الرسم البياني
    fact = chart.chart_data.chart_data_workbook

    # حذف السلاسل والفئات الافتراضية المولدة
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # إضافة فئات جديدة
    chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "الربع الأول"))
    chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "الربع الثاني"))
    chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "الربع الثالث"))

    # إضافة سلاسل جديدة
    series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "السلسلة 1"), chart.type)

    # الآن يتم ملء بيانات السلسلة
    series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

    # لا تعمل في النسخة الجديدة
    # إضافة نقاط جديدة وتعيين لون القطاع
    # series.IsColorVaried = True
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan
    # تعيين حدود القطاع
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # تعيين حدود القطاع
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # تعيين حدود القطاع
    point2.format.line.fill_format.fill_type = slides.FillType.SOLID
    point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
    point2.format.line.width = 2.0
    point2.format.line.style = slides.LineStyle.THIN_THIN
    point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    # إنشاء تسميات مخصصة لكل من الفئات للسلسلة الجديدة
    lbl1 = series.data_points[0].label

    # lbl.show_category_name = True
    lbl1.data_label_format.show_value = True

    lbl2 = series.data_points[1].label
    lbl2.data_label_format.show_value = True
    lbl2.data_label_format.show_legend_key = True
    lbl2.data_label_format.show_percentage = True

    lbl3 = series.data_points[2].label
    lbl3.data_label_format.show_series_name = True
    lbl3.data_label_format.show_percentage = True

    # عرض خطوط القيادة للرسم البياني
    series.labels.default_data_label_format.show_leader_lines = True

    # تعيين زاوية الدوران لقطاعات الرسم البياني الدائري
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # حفظ العرض مع الرسم البياني
    presentation.save("PieChart_out-3.pptx", slides.export.SaveFormat.PPTX)
```

### **إنشاء الرسوم البيانية الخطية**

تستخدم الرسوم البيانية الخطية (المعروفة أيضًا باسم المخططات الخطية) بشكل أفضل في المواقف التي تريد فيها إظهار التغيرات في القيم بمرور الوقت. باستخدام الرسم البياني الخطي، يمكنك مقارنة الكثير من البيانات في وقت واحد، وتتبع التغيرات والاتجاهات على مدار الوقت، وإبراز الشذوذ في سلسلة البيانات، إلخ.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع الشريحة من خلال فهرسها.
1. أضف رسمًا بيانيًا مع البيانات الافتراضية جنبًا إلى جنب مع النوع المطلوب (في هذه الحالة، `ChartType.Line`).
1. الوصول إلى بيانات الرسم البياني [IChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdataworkbook/).
1. امسح السلاسل والفئات الافتراضية.
1. أضف سلاسل وفئات جديدة.
1. أضف بيانات جديدة للرسم البياني لسلسلة الرسم البياني.
1. اكتب العرض المعدل إلى ملف PPTX.

هذا الرمز بلغة Python يوضح لك كيفية إنشاء رسم بياني خطي:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    lineChart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)
    
    pres.save("lineChart.pptx", slides.export.SaveFormat.PPTX)
```

بشكل افتراضي، يتم ربط النقاط على الرسم البياني الخطي بواسطة خطوط مستقيمة مستمرة. إذا كنت تريد ربط النقاط بواسطة خطوط منقطة بدلاً من ذلك، يمكنك تحديد نوع النقاط المفضل لديك بهذه الطريقة:

```python
lineChart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

for series in lineChart.chart_data.series:
    series.format.line.dash_style = slides.charts.LineDashStyle.DASH
```

### **إنشاء الرسوم البيانية للخرائط الشجرية**

تُستخدم الرسوم البيانية للخرائط الشجرية بشكل أفضل لبيانات المبيعات عندما ترغب في إظهار الحجم النسبي لفئات البيانات و(في نفس الوقت) جذب الانتباه بسرعة إلى العناصر التي تسهم بشكل كبير في كل فئة.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع الشريحة من خلال فهرسها.
1. أضف رسمًا بيانيًا مع البيانات الافتراضية جنبًا إلى جنب مع النوع المطلوب (في هذه الحالة، `ChartType.TREEMAP`).
1. الوصول إلى بيانات الرسم البياني IChartDataWorkbook.
1. امسح السلاسل والفئات الافتراضية.
1. أضف سلاسل وفئات جديدة.
1. أضف بيانات جديدة للرسم البياني لسلسلة الرسم البياني.
1. اكتب العرض المعدل إلى ملف PPTX.

هذا الرمز بلغة Python يوضح لك كيفية إنشاء رسم بياني للخرائط الشجرية:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.TREEMAP, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    # الفرع 1
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C1", "ورقة 1"))
    leaf.grouping_levels.set_grouping_item(1, "جذع 1")
    leaf.grouping_levels.set_grouping_item(2, "فرع 1")

    chart.chart_data.categories.add(wb.get_cell(0, "C2", "ورقة 2"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C3", "ورقة 3"))
    leaf.grouping_levels.set_grouping_item(1, "جذع 2")

    chart.chart_data.categories.add(wb.get_cell(0, "C4", "ورقة 4"))


    # الفرع 2
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C5", "ورقة 5"))
    leaf.grouping_levels.set_grouping_item(1, "جذع 3")
    leaf.grouping_levels.set_grouping_item(2, "فرع 2")

    chart.chart_data.categories.add(wb.get_cell(0, "C6", "ورقة 6"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C7", "ورقة 7"))
    leaf.grouping_levels.set_grouping_item(1, "جذع 4")

    chart.chart_data.categories.add(wb.get_cell(0, "C8", "ورقة 8"))

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D8", 3))

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    pres.save("Treemap-4.pptx", slides.export.SaveFormat.PPTX)
```

### **إنشاء الرسوم البيانية للأسهم**
1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع الشريحة من خلال فهرسها.
1. أضف رسمًا بيانيًا مع البيانات الافتراضية جنبًا إلى جنب مع النوع المطلوب (ChartType.OPEN_HIGH_LOW_CLOSE).
1. الوصول إلى بيانات الرسم البياني IChartDataWorkbook.
1. امسح السلاسل والفئات الافتراضية.
1. أضف سلاسل وفئات جديدة.
1. أضف بيانات جديدة للرسم البياني لسلسلة الرسم البياني.
1. حدد تنسيق HiLowLines.
1. اكتب العرض المعدل إلى ملف PPTX.

مثال للرمز بلغة Python المستخدم لإنشاء رسم بياني للأسهم:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 50, 50, 600, 400, False)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    wb = chart.chart_data.chart_data_workbook

    chart.chart_data.categories.add(wb.get_cell(0, 1, 0, "A"))
    chart.chart_data.categories.add(wb.get_cell(0, 2, 0, "B"))
    chart.chart_data.categories.add(wb.get_cell(0, 3, 0, "C"))

    chart.chart_data.series.add(wb.get_cell(0, 0, 1, "افتتاح"), chart.type)
    chart.chart_data.series.add(wb.get_cell(0, 0, 2, "أعلى"), chart.type)
    chart.chart_data.series.add(wb.get_cell(0, 0, 3, "أدنى"), chart.type)
    chart.chart_data.series.add(wb.get_cell(0, 0, 4, "إغلاق"), chart.type)

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 1, 72))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 1, 25))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 1, 38))

    series = chart.chart_data.series[1]
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 2, 172))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 2, 57))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 2, 57))

    series = chart.chart_data.series[2]
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 3, 12))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 3, 12))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 3, 13))

    series = chart.chart_data.series[3]
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 4, 25))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 4, 38))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 4, 50))

    chart.chart_data.series_groups[0].up_down_bars.has_up_down_bars = True
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for ser in chart.chart_data.series:
        ser.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    pres.save("output-5.pptx", slides.export.SaveFormat.PPTX)
```


### **إنشاء الرسوم البيانية للصندوق والشعيرات**
1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع الشريحة من خلال فهرسها.
1. أضف رسمًا بيانيًا مع البيانات الافتراضية جنبًا إلى جنب مع النوع المطلوب (ChartType.BOX_AND_WHISKER).
1. الوصول إلى بيانات الرسم البياني IChartDataWorkbook.
1. امسح السلاسل والفئات الافتراضية.
1. أضف سلاسل وفئات جديدة.
1. أضف بيانات جديدة للرسم البياني لسلسلة الرسم البياني.
1. اكتب العرض المعدل إلى ملف PPTX.

هذا الرمز بلغة Python يوضح لك كيفية إنشاء رسم بياني للصندوق والشعيرات:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.add(wb.get_cell(0, "A1", "الفئة 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A2", "الفئة 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", "الفئة 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", "الفئة 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", "الفئة 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A6", "الفئة 1"))

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B1", 15))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B2", 41))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B3", 16))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B4", 10))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B5", 23))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B6", 16))


    pres.save("BoxAndWhisker-6.pptx", slides.export.SaveFormat.PPTX)
```


### **إنشاء رسوم بيانية القمع**
1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع الشريحة من خلال فهرسها.
1. أضف رسمًا بيانيًا مع البيانات الافتراضية جنبًا إلى جنب مع النوع المطلوب (ChartType.Funnel).
1. اكتب العرض المعدل إلى ملف PPTX.

هذا الرمز بلغة Python يوضح لك كيفية إنشاء رسم بياني القمع:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.add(wb.get_cell(0, "A1", "الفئة 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A2", "الفئة 2"))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", "الفئة 3"))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", "الفئة 4"))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", "الفئة 5"))
    chart.chart_data.categories.add(wb.get_cell(0, "A6", "الفئة 6"))

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B1", 50))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B2", 100))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B3", 200))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B4", 300))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B5", 400))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B6", 500))

    pres.save("Funnel-7.pptx", slides.export.SaveFormat.PPTX)
```

### **إنشاء الرسوم البيانية للأشعة الشمسية**
1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع الشريحة من خلال فهرسها.
1. أضف رسمًا بيانيًا مع البيانات الافتراضية جنبًا إلى جنب مع النوع المطلوب (في هذه الحالة، `ChartType.SUNBURST`).
1. اكتب العرض المعدل إلى ملف PPTX.

هذا الرمز بلغة Python يوضح لك كيفية إنشاء رسم بياني لشمسية:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    # الفرع 1
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C1", "ورقة 1"))
    leaf.grouping_levels.set_grouping_item(1, "جذع 1")
    leaf.grouping_levels.set_grouping_item(2, "فرع 1")

    chart.chart_data.categories.add(wb.get_cell(0, "C2", "ورقة 2"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C3", "ورقة 3"))
    leaf.grouping_levels.set_grouping_item(1, "جذع 2")

    chart.chart_data.categories.add(wb.get_cell(0, "C4", "ورقة 4"))

    # الفرع 2
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C5", "ورقة 5"))
    leaf.grouping_levels.set_grouping_item(1, "جذع 3")
    leaf.grouping_levels.set_grouping_item(2, "فرع 2")

    chart.chart_data.categories.add(wb.get_cell(0, "C6", "ورقة 6"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C7", "ورقة 7"))
    leaf.grouping_levels.set_grouping_item(1, "جذع 4")

    chart.chart_data.categories.add(wb.get_cell(0, "C8", "ورقة 8"))

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D8", 3))

    pres.save("Sunburst-8.pptx", slides.export.SaveFormat.PPTX)
```


### **إنشاء الرسوم البيانية المدروجة**
1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع الشريحة من خلال فهرسها.
1. أضف بعض الرسوم البيانية مع بعض البيانات وحدد نوع الرسم البياني المفضل لديك (`ChartType.HISTOGRAM` في هذه الحالة).
1. الوصول إلى بيانات الرسم البياني `IChartDataWorkbook`.
1. امسح السلاسل والفئات الافتراضية.
1. أضف سلاسل وفئات جديدة.
1. اكتب العرض المعدل إلى ملف PPTX.

هذا الرمز بلغة Python يوضح لك كيفية إنشاء رسم بياني مدرج:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.HISTOGRAM, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A1", 15))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A2", -41))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A3", 16))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A4", 10))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A5", -23))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A6", 16))

    chart.axes.horizontal_axis.aggregation_type = charts.AxisAggregationType.AUTOMATIC

    pres.save("Histogram-9.pptx", slides.export.SaveFormat.PPTX)
```

### **إنشاء الرسوم البيانية الخطية**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي تمثل عرض PowerPoint.
1. احصل على مرجع الشريحة من خلال فهرسها.
1. أضف رسمًا بيانيًا مع بعض البيانات وحدد نوع الرسم البياني المفضل لديك (`ChartType.RADAR` في هذه الحالة).
1. اكتب العرض المعدل إلى ملف PPTX.

هذا الرمز بلغة Python يوضح لك كيفية إنشاء رسم بياني خطي:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 400, 300)
    pres.save("Radar-chart.pptx", slides.export.SaveFormat.PPTX)
```

### **إنشاء الرسوم البيانية متعددة الفئات**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع الشريحة من خلال فهرسها.
1. أضف رسمًا بيانيًا مع البيانات الافتراضية جنبًا إلى جنب مع النوع المطلوب (ChartType.ClusteredColumn).
1. الوصول إلى بيانات الرسم البياني IChartDataWorkbook.
1. امسح السلاسل والفئات الافتراضية.
1. أضف سلاسل وفئات جديدة.
1. أضف بيانات جديدة للرسم البياني لسلسلة الرسم البياني.
1. اكتب العرض المعدل إلى ملف PPTX.

هذا الرمز بلغة Python يوضح لك كيفية إنشاء رسم بياني متعدد الفئات:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]

    ch = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 600, 450)
    ch.chart_data.series.clear()
    ch.chart_data.categories.clear()


    fact = ch.chart_data.chart_data_workbook
    fact.clear(0)
    defaultWorksheetIndex = 0

    category = ch.chart_data.categories.add(fact.get_cell(0, "c2", "A"))
    category.grouping_levels.set_grouping_item(1, "مجموعة 1")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c3", "B"))

    category = ch.chart_data.categories.add(fact.get_cell(0, "c4", "C"))
    category.grouping_levels.set_grouping_item(1, "مجموعة 2")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c5", "D"))

    category = ch.chart_data.categories.add(fact.get_cell(0, "c6", "E"))
    category.grouping_levels.set_grouping_item(1, "مجموعة 3")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c7", "F"))

    category = ch.chart_data.categories.add(fact.get_cell(0, "c8", "G"))
    category.grouping_levels.set_grouping_item(1, "مجموعة 4")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c9", "H"))

    # إضافة السلاسل
    series = ch.chart_data.series.add(fact.get_cell(0, "D1", "السلسلة 1"), charts.ChartType.CLUSTERED_COLUMN)

    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D2", 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D3", 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D4", 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D5", 40))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D6", 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D7", 60))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D8", 70))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D9", 80))
    
    # حفظ العرض مع الرسم البياني
    pres.save("AsposeChart_out-10.pptx", slides.export.SaveFormat.PPTX)
```

### **إنشاء رسوم بيانية الخريطة**

إن رسم بياني الخريطة هو تمثيل بصري لمنطقة تحتوي على بيانات. تستخدم رسوم بيانية الخريطة بشكل أفضل لمقارنة البيانات أو القيم عبر المناطق الجغرافية.

هذا الرمز بلغة Python يوضح لك كيفية إنشاء رسم بياني للخريطة:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 50, 50, 500, 400, False)
    pres.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

### **إنشاء الرسوم البيانية المركبة**

الرسم البياني المركب (أو الرسم البياني المشترك) هو رسم بياني يجمع بين رسمين أو أكثر على رسم بياني واحد. تتيح لك مثل هذه الرسوم البيانية تسليط الضوء على الفروق أو مراجعة الاختلافات بين مجموعتين أو أكثر من البيانات. بهذه الطريقة، ترى العلاقة (إن وجدت) بين مجموعات البيانات.

![combination-chart-ppt](combination-chart-ppt.png)

هذا الرمز بلغة Python يوضح لك كيفية إنشاء رسم بياني مركب في PowerPoint:

```python
import aspose.slides as slides
import aspose.slides.charts as charts


def create_combo_chart():
    pres = slides.Presentation()
    chart = create_chart(pres.slides[0])
    add_first_series_to_chart(chart)
    add_second_series_to_chart(chart)
    pres.save("combo-chart.pptx", slides.export.SaveFormat.PPTX)


def create_chart(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "السلسلة 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "السلسلة 2"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "الفئة 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "الفئة 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "الفئة 3"))

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

    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "السلسلة 3"), charts.ChartType.SCATTER_WITH_SMOOTH_LINES)

    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 0, 1, 3), workbook.get_cell(worksheet_index, 0, 2, 5))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 3, 10), workbook.get_cell(worksheet_index, 1, 4, 13))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 20), workbook.get_cell(worksheet_index, 2, 4, 15))

    series.plot_on_second_axis = True

def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 5, "السلسلة 4"), charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS)

    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 3, 5), workbook.get_cell(worksheet_index, 1, 4, 2))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 5, 10), workbook.get_cell(worksheet_index, 1, 6, 7))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 5, 15), workbook.get_cell(worksheet_index, 2, 6, 12))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 5, 12), workbook.get_cell(worksheet_index, 3, 6, 9))

    series.plot_on_second_axis = True
```

## **تحديث الرسوم البيانية**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي تمثل العرض الذي يحتوي على الرسم البياني.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. استعرض كل الأشكال للبحث عن الرسم البياني المطلوب.
4. الوصول إلى ورقة بيانات الرسم البياني.
5. قم بتعديل بيانات سلسلة الرسم البياني عن طريق تغيير قيم السلسلة.
6. أضف سلسلة جديدة واملأ البيانات بها.
7. اكتب العرض المعدل كملف PPTX.

هذا الرمز بلغة Python يوضح لك كيفية تحديث رسم بياني:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# أنشئ مثيلًا من فئة Presentation التي تمثل ملف PPTX
with slides.Presentation(path + "ExistingChart.pptx") as pres:

    # الوصول إلى الشريحة الأولى
    sld = pres.slides[0]

    # إضافة الرسم البياني مع البيانات الافتراضية
    chart = sld.shapes[0]

    # تعيين فهرس ورقة البيانات للرسم البياني
    defaultWorksheetIndex = 0

    # الحصول على ورقة بيانات الرسم البياني
    fact = chart.chart_data.chart_data_workbook


    # تغيير اسم الفئة للرسم البياني
    fact.get_cell(defaultWorksheetIndex, 1, 0, "الفئة المعدلة 1")
    fact.get_cell(defaultWorksheetIndex, 2, 0, "الفئة المعدلة 2")


    # أخذ السلسلة الأول للرسم البياني
    series = chart.chart_data.series[0]

    # الآن تحديث بيانات السلسلة
    fact.get_cell(defaultWorksheetIndex, 0, 1, "السلسلة الجديدة") # تعديل اسم السلسلة
    series.data_points[0].value.data = 90
    series.data_points[1].value.data = 123
    series.data_points[2].value.data = 44

    # أخذ السلسلة الثانية للرسم البياني
    series = chart.chart_data.series[1]

    # الآن تحديث بيانات السلسلة
    fact.get_cell(defaultWorksheetIndex, 0, 2, "السلسلة الجديدة") # تعديل اسم السلسلة
    series.data_points[0].value.data = 23
    series.data_points[1].value.data = 67
    series.data_points[2].value.data = 99


    # الآن، إضافة سلسلة جديدة
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 3, "السلسلة 3"), chart.type)

    # أخذ السلسلة الثالثة للرسم البياني
    series = chart.chart_data.series[2]

    # الآن ملء بيانات السلسلة
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 3, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 3, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 3, 30))

    chart.type = charts.ChartType.CLUSTERED_CYLINDER

    # حفظ العرض مع الرسم البياني
    pres.save("AsposeChartModified_out-11.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين نطاق البيانات للرسوم البيانية**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي تمثل العرض الذي يحتوي على الرسم البياني.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. استعرض كل الأشكال للبحث عن الرسم البياني المطلوب.
4. الوصول إلى بيانات الرسم البياني وتعيين النطاق.
5. احفظ العرض المعدل كملف PPTX.

هذا الرمز بلغة Python يوضح لك كيفية تعيين نطاق البيانات لرسم بياني:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# أنشئ مثيلًا من فئة Presentation التي تمثل ملف PPTX
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # الوصول إلى الشريحة الأولى وإضافة الرسم البياني مع البيانات الافتراضية
    slide = presentation.slides[0]
    chart = slide.shapes[0]
    chart.chart_data.set_range("Sheet1!A1:B4")
    presentation.save("SetDataRange_out-12.pptx", slides.export.SaveFormat.PPTX)
```


## **استخدام العلامات الافتراضية في الرسوم البيانية**
عندما تستخدم علامة افتراضية في الرسوم البيانية، تحصل كل سلسلة رسم بياني على رموز علامة افتراضية مختلفة تلقائيًا.

هذا الرمز بلغة Python يوضح لك كيفية تعيين علامة سلسلة الرسم البياني تلقائيًا:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    fact = chart.chart_data.chart_data_workbook
    chart.chart_data.series.add(fact.get_cell(0, 0, 1, "السلسلة 1"), chart.type)
    series = chart.chart_data.series[0]

    chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "C1"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 1, 1, 24))
    chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "C2"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 2, 1, 23))
    chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "C3"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 3, 1, -10))
    chart.chart_data.categories.add(fact.get_cell(0, 4, 0, "C4"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 4, 1, None))

    chart.chart_data.series.add(fact.get_cell(0, 0, 2, "السلسلة 2"), chart.type)
    # أخذ السلسلة الثانية للرسم البياني
    series2 = chart.chart_data.series[1]

    # الآن يتم ملء بيانات السلسلة
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 1, 2, 30))
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 2, 2, 10))
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 3, 2, 60))
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 4, 2, 40))

    chart.has_legend = True
    chart.legend.overlay = False

    pres.save("DefaultMarkersInChart-13.pptx", slides.export.SaveFormat.PPTX)
```