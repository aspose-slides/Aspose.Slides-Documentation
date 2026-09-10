---
title: إنشاء أو تحديث مخططات عرض PowerPoint في Python
linktitle: إنشاء أو تحديث المخططات
type: docs
weight: 10
url: /ar/python-net/create-chart/
keywords:
- إضافة مخطط
- إنشاء مخطط
- تحرير مخطط
- تغيير مخطط
- تحديث مخطط
- مخطط مبعثر
- مخطط دائري
- مخطط خطي
- مخطط شجري
- مخطط أسهم
- مخطط صندوق وشارب
- مخطط قمعي
- مخطط شمسي
- مخطط تدرجي
- مخطط راداري
- مخطط متعدد الفئات
- عرض PowerPoint
- بايثون
- Aspose.Slides
description: "تعرف على كيفية إنشاء وتخصيص المخططات في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides for Python عبر .NET. يغطي ذلك إضافة وتنسيق وتحرير المخططات في العروض مع أمثلة عملية للكود بلغة Python."
---
## **نظرة عامة**

هذه المقالة توضح كيفية إنشاء الرسوم البيانية وتخصيصها باستخدام Aspose.Slides for Python via .NET. ستتعلم كيفية إضافة رسم بياني إلى شريحة، ملئه بالبيانات، وتنسيقه ليتوافق مع متطلبات التصميم الخاصة بك. تغطي أمثلة الشيفرة إنشاء العروض التقديمية والرسوم البيانية، تكوين السلاسل، المحاور، والوسوم، ودمج توليد الرسوم البيانية في تطبيقاتك.

## **إنشاء رسم بياني**

تساعد الرسوم البيانية الأشخاص على تصور البيانات بسرعة واكتساب رؤى قد لا تكون واضحة فوراً من جدول أو جدول بيانات.

**لماذا ننشئ الرسوم البيانية؟**

باستخدام الرسوم البيانية، يمكنك:

* تجميع أو تكثيف أو تلخيص كميات كبيرة من البيانات على شريحة واحدة في عرض تقديمي؛
* كشف الأنماط والاتجاهات في البيانات؛
* استنتاج الاتجاه والزخم للبيانات بمرور الوقت أو بالنسبة لوحدة قياس معينة؛
* اكتشاف القيم المتطرفة، الانحرافات، الأخطاء، والبيانات غير المنطقية؛
* التواصل أو عرض البيانات المعقدة.

في PowerPoint، يمكنك إنشاء الرسوم البيانية من خلال وظيفة *Insert* التي توفر قوالب لتصميم أنواع متعددة من الرسوم البيانية. باستخدام Aspose.Slides، يمكنك إنشاء كل من الرسوم البيانية العادية (المستندة إلى أنواع الرسوم الشائعة) والرسوم البيانية المخصصة.

{{% alert color="info" title="ملاحظة" %}}
استخدم تعداد [ChartType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/charttype/) ضمن مساحة الاسم [Aspose.Slides.Charts](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/). القيم في هذا التعداد تتوافق مع أنواع مختلفة من الرسوم البيانية.
{{% /alert %}}

### **إنشاء رسوم عمودية متجمعة**

تشرح هذه الفقرة كيفية إنشاء رسوم عمودية متجمعة باستخدام Aspose.Slides for Python via .NET. ستتعلم كيفية تهيئة عرض تقديمي، إضافة رسم بياني، وتخصيص عناصره مثل العنوان، البيانات، السلاسل، الفئات، وتنسيقه. اتبع الخطوات أدناه لرؤية كيفية توليد رسم عمودي مجمع قياسي:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).  
1. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.  
1. إضافة رسم بياني ببعض البيانات وتحديد النوع `ChartType.CLUSTERED_COLUMN`.  
1. إضافة عنوان إلى الرسم البياني.  
1. الوصول إلى ورقة بيانات الرسم البياني.  
1. مسح جميع السلاسل والفئات الافتراضية.  
1. إضافة سلاسل وفئات جديدة.  
1. إضافة بيانات رسم بياني جديدة لسلسلة الرسم.  
1. تطبيق لون تعبئة على سلسلة الرسم.  
1. إضافة تسميات إلى سلسلة الرسم.  
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود Python يوضح كيفية إنشاء رسم عمودي مجمع:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation التي تمثل ملف PPTX.
with slides.Presentation() as presentation:

    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة مخطط عمودي مجمع مع البيانات الافتراضية.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # تعيين عنوان المخطط.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # تعيين فهرس ورقة بيانات المخطط.
    worksheet_index = 0

    # الحصول على دفتر بيانات المخطط.
    workbook = chart.chart_data.chart_data_workbook

    # حذف السلاسل والفئات المولدة افتراضيًا.
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

    # تعيين التسمية الأولى لعرض اسم الفئة.
    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    # تعيين السلسلة لعرض القيمة للتسمية الثالثة.
    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"
                
    # حفظ العرض التقديمي إلى القرص كملف PPTX.
    presentation.save("ClusteredColumnChart.pptx", slides.export.SaveFormat.PPTX)
```

الناتج:

![The clustered column chart](clustered_column_chart.png)

### **إنشاء رسوم مبعثرة**

تُستخدم الرسوم المبعثرة (المعروفة أيضاً باسم scatter plots أو x‑y graphs) غالباً للتحقق من الأنماط أو إظهار الارتباطات بين متغيرين.

استخدم رسم مبعثر عندما:

* لديك بيانات عددية مزدوجة.  
* لديك متغيران يتطابقان معاً بشكل جيد.  
* تريد تحديد ما إذا كان المتغيران مرتبطين.  
* لديك متغير مستقل له قيم متعددة لمتغير تابع.

هذا الكود Python يوضح كيفية إنشاء رسم مبعثر مع علامات مختلفة لكل سلسلة:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation.
with slides.Presentation() as presentation:

    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # إنشاء مخطط مبعثر افتراضي.
    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 20, 20, 500, 300)

    # تعيين فهرس ورقة بيانات المخطط.
    worksheet_index = 0

    # الحصول على دفتر بيانات المخطط.
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

الناتج:

![The scatter chart](scatter_chart.png)

### **إنشاء رسوم دائرية**

تُعد الرسوم الدائرية الأفضل لإظهار علاقة الجزء إلى الكل في البيانات، خاصةً عندما تحتوي البيانات على تسميات فئوية مع قيم رقمية. ومع ذلك، إذا احتوت بياناتك على العديد من الأجزاء أو التسميات، قد ترغب في النظر إلى استخدام رسم شريطي بدلاً من ذلك.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).  
1. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.  
1. إضافة رسم بياني بالبيانات الافتراضية وتحديد النوع `ChartType.PIE`.  
1. الوصول إلى دفتر بيانات الرسم ([ChartDataWorkbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/)).  
1. مسح السلاسل والفئات الافتراضية.  
1. إضافة سلاسل وفئات جديدة.  
1. إضافة بيانات رسم بياني جديدة للسلسلة.  
1. إضافة نقاط جديدة للرسم وتطبيق ألوان مخصصة على قطاعات الرسم الدائري.  
1. ضبط التسميات للسلسلة.  
1. تفعيل خطوط القائد لتسميات السلسلة.  
1. ضبط زاوية الدوران للرسم الدائري.  
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود Python يوضح كيفية إنشاء رسم دائري:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation التي تمثل ملف PPTX.
with slides.Presentation() as presentation:

    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة مخطط مع بياناته الافتراضية.
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    # تعيين عنوان المخطط.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # تعيين فهرس ورقة بيانات المخطط.
    worksheet_index = 0

    # الحصول على دفتر بيانات المخطط.
    workbook = chart.chart_data.chart_data_workbook

    # حذف السلاسل والفئات المولدة افتراضيًا.
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

    # تعيين حد القطاع.
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # تعيين حد القطاع.
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # تعيين حد القطاع.
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

    # تعيين السلسلة لعرض خطوط القائد للمخطط.
    series.labels.default_data_label_format.show_leader_lines = True

    # تعيين زاوية الدوران لقطاعات المخطط الدائري.
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # حفظ العرض التقديمي إلى القرص كملف PPTX.
    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```

الناتج:

![The pie chart](pie_chart.png)

### **إنشاء رسوم خطية**

تُعد الرسوم الخطية (المعروفة أيضاً باسم line graphs) الأفضل في الحالات التي تريد فيها إظهار تغير القيم بمرور الوقت. باستخدام رسم خطي، يمكنك مقارنة كمية كبيرة من البيانات مرة واحدة، تعقب التغييرات والاتجاهات عبر الزمن، تسليط الضوء على الشذوذ في سلاسل البيانات، وأكثر من ذلك.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).  
1. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.  
1. إضافة رسم بياني بالبيانات الافتراضية وتحديد النوع `ChartType.LINE`.  
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود Python يوضح كيفية إنشاء رسم خطي:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 20, 20, 500, 300)
    
    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```

افتراضيًا، يتم ربط نقاط الرسم الخطي بخطوط مستمرة مستقيمة. إذا رغبت في ربط النقاط بخطوط متقطعة، يمكنك تحديد نوع الخط المتقطع المفضل كما يلي:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

    for series in line_chart.chart_data.series:
        series.format.line.dash_style = slides.LineDashStyle.DASH

    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```

الناتج:

![The line chart](line_chart.png)

### **إنشاء رسوم شجرية (Tree Map)**

تُعد رسوم الشجرة (Tree Map) الأفضل لبيانات المبيعات عندما تريد إظهار الحجم النسبي لفئات البيانات وجذب الانتباه بسرعة إلى العناصر التي تُعد مساهمات كبيرة داخل كل فئة.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).  
1. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.  
1. إضافة رسم بياني بالبيانات الافتراضية وتحديد النوع `ChartType.TREEMAP`.  
1. الوصول إلى دفتر بيانات الرسم ([ChartDataWorkbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/)).  
1. مسح السلاسل والفئات الافتراضية.  
1. إضافة سلاسل وفئات جديدة.  
1. إضافة بيانات رسم بياني جديدة للسلسلة.  
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود Python يوضح كيفية إنشاء رسم شجري:

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

الناتج:

![The treemap chart](treemap_chart.png)

### **إنشاء رسوم أسهم (Stock)**

تُستخدم رسوم الأسهم لعرض البيانات المالية مثل الأسعار الافتتاحية، العلوية، الدنيا، والإغلاق، مما يساعد على تحليل اتجاهات السوق وتقلباته. توفر رؤى أساسية حول أداء الأسهم، وتساعد المستثمرين والمحللين على اتخاذ قرارات مستنيرة.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).  
1. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.  
1. إضافة رسم بياني بالبيانات الافتراضية وتحديد النوع `ChartType.OPEN_HIGH_LOW_CLOSE`.  
1. الوصول إلى دفتر بيانات الرسم ([ChartDataWorkbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/)).  
1. مسح السلاسل والفئات الافتراضية.  
1. إضافة سلاسل وفئات جديدة.  
1. إضافة بيانات رسم بياني جديدة للسلسلة.  
1. تحديد تنسيق خطوط العلو‑الدنيا.  
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود Python يوضح كيفية إنشاء رسم أسهم:

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

الناتج:

![The stock chart](stock_chart.png)

### **إنشاء رسوم الصندوق والشارب (Box and Whisker)**

تُستخدم رسوم الصندوق والشارب لعرض توزيع البيانات من خلال تلخيص مقاييس إحصائية رئيسية مثل الوسيط، الأرباع، والقيم المتطرفة المحتملة. هي مفيدة جداً في التحليل الاستكشافي للبيانات والدراسات الإحصائية لتفهّم تباين البيانات بسرعة وتحديد أي شذوذ.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).  
1. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.  
1. إضافة رسم بياني بالبيانات الافتراضية وتحديد النوع `ChartType.BOX_AND_WHISKER`.  
1. الوصول إلى دفتر بيانات الرسم ([ChartDataWorkbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/)).  
1. مسح السلاسل والفئات الافتراضية.  
1. إضافة سلاسل وفئات جديدة.  
1. إضافة بيانات رسم بياني جديدة للسلسلة.  
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود Python يوضح كيفية إنشاء رسم صندوق وشارب:

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

### **إنشاء رسوم قمعية (Funnel)**

تُستخدم الرسوم القمعية لتصوير عمليات تتضمن مراحل متتالية، حيث يقل حجم البيانات كلما انتقل من خطوة إلى أخرى. هي مفيدة خاصةً لتحليل معدلات التحويل، تحديد الاختناقات، وتتبع كفاءة عمليات المبيعات أو التسويق.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).  
1. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.  
1. إضافة رسم بياني بالبيانات الافتراضية وتحديد النوع `ChartType.FUNNEL`.  
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود Python يوضح كيفية إنشاء رسم قمعي:

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

الناتج:

![The funnel chart](funnel_chart.png)

### **إنشاء رسوم شمسية (Sunburst)**

تُستخدم الرسوم الشمسية لتصوير البيانات الهرمية، حيث تُعرض المستويات كحلقات متراكبة. تساعد على توضيح علاقات الجزء إلى الكل وتُعد مثالية لتمثيل الفئات المتداخلة والفروع الفرعية بصورة واضحة ومضغوطة.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).  
1. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.  
1. إضافة رسم بياني بالبيانات الافتراضية وتحديد النوع `ChartType.SUNBURST`.  
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود Python يوضح كيفية إنشاء رسم شمسية:

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

الناتج:

![The sunburst chart](sunburst_chart.png)

### **إنشاء رسوم تدرجية (Histogram)**

تُستخدم الرسوم التدرجية لتصوير توزيع البيانات العددية من خلال تجميع القيم إلى فئات أو صناديق. هي مفيدة لتحديد أنماط البيانات مثل التردد، الانحراف، والانتشار، وللكشف عن القيم المتطرفة في مجموعة البيانات.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).  
1. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.  
1. إضافة رسم بياني ببعض البيانات وتحديد النوع `ChartType.HISTOGRAM`.  
1. الوصول إلى دفتر بيانات الرسم ([ChartDataWorkbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/)).  
1. مسح السلاسل والفئات الافتراضية.  
1. إضافة سلسلة جديدة وملئها بنقاط البيانات. لا توجد فئات في التدرج؛ يتم حساب الصناديق من القيم.  
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود Python يوضح كيفية إنشاء رسم تدرجي:

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

الناتج:

![The histogram chart](histogram_chart.png)

### **إنشاء رسوم رادارية (Radar)**

تُستخدم الرسوم الرادارية لعرض بيانات متعددة المتغيرات في تنسيق ثنائي الأبعاد، مما يتيح مقارنة عدة متغيرات في آن واحد. هي مفيدة لتحديد الأنماط، النقاط القوية والضعيفة عبر مقاييس أداء أو خصائص متعددة.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).  
1. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.  
1. إضافة رسم بياني ببعض البيانات وتحديد النوع `ChartType.RADAR`.  
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود Python يوضح كيفية إنشاء رسم راداري:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 500, 300)
    presentation.save("RadarChart.pptx", slides.export.SaveFormat.PPTX)
```

الناتج:

![The radar chart](radar_chart.png)

### **إنشاء رسوم متعددة الفئات (Multi-Category)**

تُستخدم الرسوم متعددة الفئات لعرض بيانات تتضمن أكثر من تجميع تصنيفي، مما يسمح بمقارنة القيم عبر أبعاد متعددة في آن واحد. هي مفيدة عندما تحتاج إلى تحليل الاتجاهات والعلاقات داخل مجموعات بيانات معقدة متعددة الطبقات.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).  
1. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.  
1. إضافة رسم بياني بالبيانات الافتراضية وتحديد النوع `ChartType.CLUSTERED_COLUMN`.  
1. الوصول إلى دفتر بيانات الرسم ([ChartDataWorkbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/)).  
1. مسح السلاسل والفئات الافتراضية.  
1. إضافة سلاسل وفئات جديدة.  
1. إضافة بيانات رسم بياني جديدة للسلسلة.  
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود Python يوضح كيفية إنشاء رسم متعدد الفئات:

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

الناتج:

![The multi-category chart](multi_category_chart.png)

### **إنشاء رسوم خرائط (Map)**

تُستخدم رسوم الخرائط لتصوير البيانات الجغرافية عن طريق ربط المعلومات بمواقع محددة مثل البلدان أو الولايات أو المدن. هي مفيدة لتحليل الاتجاهات الإقليمية، البيانات الديموغرافية، والتوزيعات المكانية بطريقة واضحة وجذابة بصرياً.

هذا الكود Python يوضح كيفية إنشاء رسم خريطة:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 20, 20, 500, 300)
    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

الناتج:

![The map chart](map_chart.png)

### **إنشاء رسوم مركبة (Combination)**

الرسم المركب (أو combo chart) يجمع نوعين أو أكثر من الرسوم البيانية في رسم بياني واحد. يتيح لك هذا الرسم تسليط الضوء، المقارنة، أو فحص الفروق بين مجموعتين أو أكثر من البيانات، مما يساعدك على تحديد العلاقات بينها.

![The combination chart](combination_chart.png)

الكود Python التالي يوضح كيفية إنشاء الرسم المركب المعروض أعلاه في عرض PowerPoint:

```python
import aspose.slides.charts as charts
import aspose.pydrawing as draw
import aspose.slides as slides

def create_combo_chart():
    with slides.Presentation() as presentation:
        chart = create_chart_with_first_series(presentation.slides[0])

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", slides.export.SaveFormat.PPTX)


def create_chart_with_first_series(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    # تعيين عنوان المخطط.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Chart Title")
    chart.chart_title.overlay = False
    title_paragraph = chart.chart_title.text_frame_for_overriding.paragraphs[0]
    title_format = title_paragraph.paragraph_format.default_portion_format

    title_format.font_bold = slides.NullableBool.FALSE
    title_format.font_height = 18

    # تعيين وسيلة إيضاح المخطط.
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.portion_format.font_height = 12

    # حذف السلاسل والفئات المولدة افتراضيًا.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    worksheet_index = 0
    workbook = chart.chart_data.chart_data_workbook

    # إضافة فئات جديدة.
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 4, 0, "Category 4"))

    # إضافة السلسلة الأولى.
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 4.3))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 2.5))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 3.5))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 4.5))

    return chart


def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 2.4))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 4.4))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 1.8))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 2.8))


def add_third_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.LINE)

    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 1, 3, 2.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 2, 3, 2.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 3, 3, 3.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 4, 3, 5.0))

    series.plot_on_second_axis = True


def set_primary_axes_format(chart):
    # تعيين المحور الأفقي.
    horizontal_axis = chart.axes.horizontal_axis
    horizontal_axis.text_format.portion_format.font_height = 12.0
    horizontal_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(horizontal_axis, "X Axis")

    # تعيين المحور العمودي.
    vertical_axis = chart.axes.vertical_axis
    vertical_axis.text_format.portion_format.font_height = 12.0
    vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(vertical_axis, "Y Axis 1")

    # تعيين لون خطوط الشبكة العمودية الرئيسية.
    major_grid_lines_format = vertical_axis.major_grid_lines_format.line.fill_format
    major_grid_lines_format.fill_type = slides.FillType.SOLID
    major_grid_lines_format.solid_fill_color.color = draw.Color.from_argb(217, 217, 217)


def set_secondary_axes_format(chart):
    # تعيين المحور الأفقي الثانوي.
    secondary_horizontal_axis = chart.axes.secondary_horizontal_axis
    secondary_horizontal_axis.position = charts.AxisPositionType.BOTTOM
    secondary_horizontal_axis.cross_type = charts.CrossesType.MAXIMUM
    secondary_horizontal_axis.is_visible = False
    secondary_horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    # تعيين المحور العمودي الثانوي.
    secondary_vertical_axis = chart.axes.secondary_vertical_axis
    secondary_vertical_axis.position = charts.AxisPositionType.RIGHT
    secondary_vertical_axis.text_format.portion_format.font_height = 12.0
    secondary_vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(secondary_vertical_axis, "Y Axis 2")


def set_axis_title(axis, axis_title):
    axis.has_title = True
    axis.title.overlay = False
    title_portion_format = axis.title.add_text_frame_for_overriding(axis_title).paragraphs[0].paragraph_format.default_portion_format
    title_portion_format.font_bold = slides.NullableBool.FALSE
    title_portion_format.font_height = 12.0
```

## **تحديث الرسوم البيانية**

يتيح Aspose.Slides for Python via .NET تحديث بيانات الرسوم، التنسيق، والتنسيق لتبقى عروض PowerPoint الخاصة بك محدثة.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) لفتح العرض التقديمي الذي يحتوي على الرسم.  
1. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.  
1. استعراض جميع الأشكال للعثور على الرسم.  
1. الوصول إلى ورقة بيانات الرسم.  
1. تعديل سلاسل بيانات الرسم بتغيير قيم السلسلة.  
1. إضافة سلسلة جديدة وتعبئة بياناتها.  
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود Python يوضح كيفية تحديث رسم بياني:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# إنشاء كائن من فئة Presentation التي تمثل ملف PPTX.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape

            # تعيين فهرس ورقة بيانات المخطط.
            worksheet_index = 0

            # الحصول على دفتر بيانات المخطط.
            workbook = chart.chart_data.chart_data_workbook

            # تعديل أسماء فئات المخطط.
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

## **تحديد نطاق البيانات لرسم بياني**

يتيح Aspose.Slides for Python via .NET استخدام نطاق ورقة عمل معين كمصدر بيانات للرسم البياني. يتحكم هذا في الخلايا التي تزود الرسم بسلسلة وفئات، ويسمح لك بتحديث الرسم ليعكس التغييرات في الورقة.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) لفتح العرض التقديمي الذي يحتوي على الرسم.  
1. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.  
1. استعراض جميع الأشكال للعثور على الرسم.  
1. الوصول إلى بيانات الرسم وتحديد النطاق.  
1. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود Python يوضح كيفية تحديد نطاق البيانات لرسم بياني:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# إنشاء كائن من فئة Presentation التي تمثل ملف PPTX.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            chart.chart_data.set_range("Sheet1!A1:B4")

    presentation.save("DataRange.pptx", slides.export.SaveFormat.PPTX)
```

## **استخدام العلامات الافتراضية في الرسوم البيانية**

عند استخدام العلامات الافتراضية في الرسوم البيانية، يحصل كل سلسلة على رمز علامة مختلف تلقائيًا.

هذا الكود Python يوضح كيفية تعيين علامة سلسلة رسم تلقائيًا:

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

## **الأسئلة المتكررة**

**ما هي أنواع الرسوم البيانية المدعومة من قبل Aspose.Slides for Python via .NET؟**

يدعم Aspose.Slides for Python via .NET مجموعة واسعة من أنواع الرسوم البيانية، بما في ذلك العمودية، الخطية، الدائرية، المساحية، المبعثرة، التدرجية، الرادارية، والعديد غيرها. تتيح لك هذه المرونة اختيار النوع الأنسب لاحتياجاتك في تصور البيانات.

**كيف يمكنني إضافة رسم بياني جديد إلى شريحة؟**

لإضافة رسم بياني، تقوم أولاً بإنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/)، ثم تستعيد الشريحة المطلوبة باستخدام فهرسها، ثم تستدعي الطريقة لإضافة رسم بياني، مع تحديد نوع الرسم والبيانات الأولية. يدمج هذا العملية الرسم مباشرةً في العرض التقديمي.

**كيف يمكنني تحديث البيانات المعروضة في رسم بياني؟**

يمكنك تحديث بيانات الرسم من خلال الوصول إلى دفتر بياناته ([ChartDataWorkbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/))، مسح أي سلاسل وفئات افتراضية، ثم إضافة بياناتك المخصصة. يتيح لك ذلك تحديث الرسم برمجيًا ليعكس أحدث البيانات.

**هل يمكن تخصيص مظهر الرسم البياني؟**

نعم، يوفر Aspose.Slides for Python via .NET خيارات تخصيص واسعة. يمكنك تعديل الألوان، الخطوط، التسميات، الوسوم، وعناصر التنسيق الأخرى لتكييف مظهر الرسم وفقًا لمتطلبات التصميم الخاصة بك.