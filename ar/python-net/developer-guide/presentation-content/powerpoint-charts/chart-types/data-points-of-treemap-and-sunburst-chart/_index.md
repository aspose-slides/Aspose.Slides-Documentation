---
title: تخصيص نقاط البيانات في مخططات الشجرة التفصيلية والدوائر المتقزحة في Python
linktitle: نقاط البيانات في مخططات الشجرة التفصيلية والدوائر المتقزحة
type: docs
url: /ar/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- مخطط شجرة تفصيلية
- مخطط دوائر متقزحة
- نقطة بيانات
- لون التسمية
- لون الفرع
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعرّف على كيفية إدارة نقاط البيانات في مخططات الشجرة التفصيلية والدوائر المتقزحة باستخدام Aspose.Slides for Python عبر .NET، مع دعم صيغ PowerPoint وOpenDocument."
---

## **المقدمة**

من بين أنواع المخططات الأخرى في PowerPoint، هناك نوعان هرميان—**الشجرة التفصيلية** و**الدوائر المتقزحة** (المعروفة أيضًا باسم مخطط دوائر متقزحة، مخطط دوائر شمسية، مخطط دائري شعاعي، أو مخطط فطيرة متعدد المستويات). تعرض هذه المخططات البيانات الهرمية المنظمة كشجرة—من الأوراق إلى أعلى الفرع. تُعرّف الأوراق بنقاط بيانات السلسلة، ويُعرّف كل مستوى تجميع متداخل لاحقًا بالفئة المقابلة. يتيح لك Aspose.Slides for Python عبر .NET تنسيق نقاط البيانات في مخططات الدوائر المتقزحة والشجرة التفصيلية باستخدام Python.

إليك مثال على مخطط دوائر متقزحة حيث تُعرّف البيانات في عمود Series1 عقد الأوراق، بينما تُعرّف الأعمدة الأخرى نقاط البيانات الهرمية:

![Sunburst chart example](sunburst_example.png)

لنبدأ بإضافة مخطط دوائر متقزحة جديد إلى العرض التقديمي:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="انظر أيضًا" %}}
- [**إنشاء مخططات دوائر متقزحة**](/slides/ar/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

إذا كنت بحاجة إلى تنسيق نقاط البيانات في المخطط، استخدم واجهات البرمجة (APIs) التالية:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/)، [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/)، وخاصية [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/). توفر هذه الواجهات إمكانية الوصول إلى تنسيق نقاط البيانات في مخططات الشجرة التفصيلية والدوائر المتقزحة. يُستخدم [ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) للوصول إلى الفئات متعددة المستويات؛ وهو يمثل حاوية لكائنات [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/). وهو في الأساس غلاف حول [ChartCategoryLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/) مع خصائص إضافية خاصة بنقاط البيانات. يُظهر نوع [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) خاصيتين—[format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/format/) و[label](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/label/)—اللتين توفران وصولًا إلى الإعدادات المقابلة.

## **عرض قيم نقاط البيانات**

توضح هذه الفقرة كيفية عرض القيمة لنقطة بيانات منفردة في مخططات الشجرة التفصيلية والدوائر المتقزحة. ستتعرف على كيفية تمكين تسميات القيم للنقاط المختارة.

عرض قيمة نقطة البيانات "Leaf 4":

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![Data point value](data_point_value.png)

## **تعيين التسميات والألوان لنقاط البيانات**

توضح هذه الفقرة كيفية تعيين تسميات وألوان مخصصة لنقطة بيانات منفردة في مخططات الشجرة التفصيلية والدوائر المتقزحة. ستتعلم كيفية الوصول إلى نقطة بيانات محددة، تعيين تسمية، وتطبيق تعبئة صلبة لتسليط الضوء على العقد المهمة.

عيّن تسمية البيانات "Branch 1" لإظهار اسم السلسلة ("Series1") بدلاً من اسم الفئة، ثم عيّن لون النص إلى الأصفر:

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![Data point's label and color](data_point_color.png)

## **تعيين ألوان الفروع لنقاط البيانات**

استخدم ألوان الفروع للتحكم في كيفية تجميع العقد الأم والفرعية بصريًا في مخططات الشجرة التفصيلية والدوائر المتقزحة. تُظهر هذه الفقرة كيفية تعيين لون فرع مخصص لنقطة بيانات معينة لتسليط الضوء على الأشجار الفرعية المهمة وتحسين قابلية القراءة للمخطط.

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

## **الأسئلة الشائعة**

**هل يمكنني تغيير ترتيب (الفرز) القطاعات في مخطط الدوائر المتقزحة/الشجرة التفصيلية؟**

لا. يقوم PowerPoint بفرز القطاعات تلقائيًا (عادةً بالقيم التنازلية، باتجاه عقارب الساعة). ي mirrored Aspose.Slides هذا السلوك: لا يمكنك تغيير الترتيب مباشرةً؛ يمكنك تحقيق ذلك عبر معالجة البيانات مسبقًا.

**كيف يؤثر سمة العرض التقديمي على ألوان القطاعات والتسميات؟**

ترث ألوان المخطط سمة/لوحة ألوان العرض التقديمي ([theme/palette](/slides/ar/python-net/presentation-theme/)) ما لم تقم بتعيين التعبئات/الخطوط صراحةً. للحصول على نتائج ثابتة، ثبت التعبئات الصلبة وتنسيق النص على المستويات المطلوبة.

**هل سيحافظ تصدير إلى PDF/PNG على ألوان الفروع المخصصة وإعدادات التسميات؟**

نعم. عند تصدير العرض التقديمي، يتم الحفاظ على إعدادات المخطط (التعبئات، التسميات) في تنسيقات الإخراج لأن Aspose.Slides يرسم المخطط بالتنسيق المطبّق.

**هل يمكنني حساب الإحداثيات الفعلية لتسمية/عنصر لتحديد موقع تراكب مخصص فوق المخطط؟**

نعم. بعد التحقق من تخطيط المخطط، تكون `actual_x`/`actual_y` متاحة للعناصر (على سبيل المثال، [DataLabel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/))، مما يساعد على تحديد موقع التراكبات بدقة.