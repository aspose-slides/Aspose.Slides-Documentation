---
title: تخصيص نقاط البيانات في مخططات Treemap و Sunburst في Python
linktitle: نقاط البيانات في مخططات Treemap و Sunburst
type: docs
url: /ar/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- مخطط شجرة الخريطة
- مخطط شمسية
- نقطة بيانات
- لون التسمية
- لون الفروع
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعرف على كيفية إدارة نقاط البيانات في مخططات Treemap و Sunburst باستخدام Aspose.Slides for Python عبر .NET، المتوافقة مع صيغ PowerPoint و OpenDocument."
---

## **المقدمة**

من بين أنواع مخططات PowerPoint الأخرى، هناك نوعان هرميان — **Treemap** و **Sunburst** (المعروف أيضاً باسم Sunburst Graph أو Sunburst Diagram أو Radial Chart أو Radial Graph أو Multi-Level Pie Chart). تُظهر هذه المخططات البيانات الهرمية المنظمة كشجرة — من الأوراق إلى أعلى الفرع. تُعرف الأوراق بنقاط بيانات السلسلة، وكل مستوى تجميع متداخل لاحق يُعرف بالفئة المقابلة. يتيح لك Aspose.Slides for Python عبر .NET تنسيق نقاط البيانات في مخططات Sunburst و Treemap باستخدام Python.

فيما يلي مخطط Sunburst حيث تُعرّف البيانات في عمود Series1 عقد الأوراق، بينما تُعرّف الأعمدة الأخرى نقاط البيانات الهرمية:

![Sunburst chart example](sunburst_example.png)

لنبدا بإضافة مخطط Sunburst جديد إلى العرض التقديمي:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="انظر أيضًا" %}}
- [**إنشاء مخططات Sunburst**](/slides/ar/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

إذا كنت بحاجة إلى تنسيق نقاط بيانات المخطط، استخدم واجهات برمجة التطبيقات التالية:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/), [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/), والخاصية [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/). تُوفر لك هذه العناصر الوصول إلى تنسيق نقاط البيانات في مخططات Treemap و Sunburst. يُستخدم [ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) للوصول إلى الفئات المتعددة المستويات؛ وهو يمثل حاوية لكائنات [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/). هو في الأساس غلاف حول [ChartCategoryLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/) مع خصائص إضافية خاصة بنقاط البيانات. يُظهر نوع [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) خاصيتين — [format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/format/) و [label](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/label/) — اللتين توفران الوصول إلى الإعدادات المقابلة.

## **عرض قيم نقاط البيانات**

يُظهر هذا القسم كيفية عرض القيمة لنقاط البيانات الفردية في مخططات Treemap و Sunburst. ستتعرف على كيفية تمكين تسميات القيم للنقاط المحددة.

عرض قيمة نقطة البيانات "Leaf 4":

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![Data point value](data_point_value.png)

## **تعيين التسميات والألوان لنقاط البيانات**

يُظهر هذا القسم كيفية تعيين تسميات مخصصة وألوان لنقاط البيانات الفردية في مخططات Treemap و Sunburst. ستتعلم كيفية الوصول إلى نقطة بيانات محددة، تعيين تسمية، وتطبيق تعبئة صلبة لتسليط الضوء على العقد المهمة.

عيّن تسمية "Branch 1" لعرض اسم السلسلة ("Series1") بدلاً من اسم الفئة، ثم عيّن لون النص إلى الأصفر:

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![Data point's label and color](data_point_color.png)

## **تعيين ألوان الفروع لنقاط البيانات**

استخدم ألوان الفروع للتحكم في كيفية تجميع العقد الأصلية والفرعية بصرياً في مخططات Treemap و Sunburst. يُظهر هذا القسم كيفية تعيين لون فرع مخصص لنقطة بيانات معينة حتى تتمكن من تمييز الأشجار الفرعية المهمة وتحسين قابلية قراءة المخطط.

تغيير لون فرع "Stem 4":

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
    data_points = chart.chart_data.series[0].data_points

    stem4_branch = data_points[9].data_point_levels[1]
    
    stem4_branch.format.fill.fill_type = slides.FillType.SOLID
    stem4_branch.format.fill.solid_fill_color.color = draw.Color.red
      
    presentation.save("branch_color.pptx", slides.export.SaveFormat.PPTX)
```

![Branch color](branch_color.png)

## **الأسئلة المتكررة**

**هل يمكنني تغيير ترتيب (الفرز) القطاعات في Sunburst/Treemap؟**

لا. يقوم PowerPoint بفرز القطاعات تلقائياً (عادةً بالقيم المتناقصة، باتجاه عقارب الساعة). يطابق Aspose.Slides هذا السلوك: لا يمكنك تغيير الترتيب مباشرة؛ بل تقوم بذلك عبر معالجة البيانات مسبقاً.

**كيف يؤثر سمة العرض التقديمي على ألوان القطاعات والتسميات؟**

تورث ألوان المخطط سمة/لوحة ألوان العرض التقديمي [/slides/python-net/presentation-theme/](/slides/ar/python-net/presentation-theme/) ما لم تقم بتعيين التعبئات/الخطوط صراحةً. للحصول على نتائج ثابتة، قم بتثبيت التعبئات الصلبة وتنسيق النص في المستويات المطلوبة.

**هل سيحافظ التصدير إلى PDF/PNG على ألوان الفروع المخصصة وإعدادات التسميات؟**

نعم. عند تصدير العرض التقديمي، تُحفظ إعدادات المخطط (التعبئات، التسميات) في تنسيقات الإخراج لأن Aspose.Slides يُعيد الرسم بتنسيق المخطط المطبّق.

**هل يمكنني حساب الإحداثيات الفعلية لتسمية/عنصر لتحديد موضع طبقة مخصصة فوق المخطط؟**

نعم. بعد التحقق من تخطيط المخطط، تكون `actual_x`/`actual_y` متاحة للعناصر (على سبيل المثال، [DataLabel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/))، مما يساعد في تحديد موضع الطبقات بدقة.