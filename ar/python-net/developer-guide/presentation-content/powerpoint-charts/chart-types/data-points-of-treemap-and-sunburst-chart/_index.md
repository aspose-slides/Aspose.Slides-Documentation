---
title: تخصيص نقاط البيانات في مخططات شجرة الخريطة والدوائر المتشرقية في بايثون
linktitle: نقاط البيانات في مخططات شجرة الخريطة والدوائر المتشرقية
type: docs
url: /ar/python-net/developer-guide/presentation-content/powerpoint-charts/chart-types/data-points-of-treemap-and-sunburst-chart/
keywords:
- مخطط شجرة الخريطة
- مخطط الدوائر المتشرقية
- نقطة البيانات
- لون التسمية
- لون الفرع
- PowerPoint
- OpenDocument
- العرض التقديمي
- Python
- Aspose.Slides
description: "تعرف على كيفية إدارة نقاط البيانات في مخططات شجرة الخريطة والدوائر المتشرقية باستخدام Aspose.Slides for Python via .NET، المتوافق مع صيغ PowerPoint وOpenDocument."
---

## **مقدمة**

إلى جانب أنواع المخططات الأخرى في PowerPoint، هناك نوعان هرميان—**Treemap** و**Sunburst** (المعروفة أيضًا باسم Sunburst Graph، Sunburst Diagram، Radial Chart، Radial Graph، أو Multi-Level Pie Chart). تعرض هذه المخططات بيانات هرمية منظمة كشجرة—from الأوراق إلى أعلى الفرع. تُعرف الأوراق بنقاط بيانات السلسلة، ويُعرَّف كل مستوى تجميع متداخل لاحق بالفئة المقابلة. يتيح لك Aspose.Slides for Python via .NET تنسيق نقاط البيانات في مخططات Sunburst وTreemap باستخدام بايثون.

هذه مثال لمخطط Sunburst حيث تُعرّف البيانات في عمود Series1 عقد الأوراق، بينما تُعرّف الأعمدة الأخرى نقاط البيانات الهرمية:

![مثال على مخطط الدوائر المتشرقية](sunburst_example.png)

لنبدأ بإضافة مخطط Sunburst جديد إلى العرض التقديمي:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="انظر أيضًا" %}}
- [**إنشاء مخططات الدوائر المتشرقية**](/slides/ar/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

إذا كنت بحاجة إلى تنسيق نقاط بيانات المخطط، استخدم واجهات برمجة التطبيقات التالية:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/)، [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/)، والخاصية [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/). توفر هذه الواجهات إمكانية الوصول إلى تنسيق نقاط البيانات في مخططات Treemap وSunburst. يُستخدم [ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) للوصول إلى الفئات متعددة المستويات؛ وهو يمثل حاوية لكائنات [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/). هو في الأساس غلاف حول [ChartCategoryLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/) بخصائص إضافية خاصة بنقاط البيانات. يُظهر النوع [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) خاصيتين—[format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/format/) و[label](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/label/)—والتي تُوفر الوصول إلى الإعدادات المقابلة.

## **عرض قيم نقاط البيانات**

يوضح هذا القسم كيفية عرض القيمة لنقاط البيانات الفردية في مخططات Treemap وSunburst. ستشاهد كيفية تمكين تسميات القيم للنقاط المختارة.

اعرض قيمة نقطة البيانات "Leaf 4":

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![قيمة نقطة البيانات](data_point_value.png)

## **تعيين التسميات والألوان لنقاط البيانات**

يوضح هذا القسم كيفية تعيين تسميات وألوان مخصصة لنقاط البيانات الفردية في مخططات Treemap وSunburst. ستتعلم كيفية الوصول إلى نقطة بيانات محددة، وإسناد تسمية، وتطبيق تعبئة صلبة لتسليط الضوء على العقد المهمة.

عيّن تسمية "Branch 1" لعرض اسم السلسلة ("Series1") بدلاً من اسم الفئة، ثم عيّن لون النص إلى الأصفر:

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![تسمية ولون نقطة البيانات](data_point_color.png)

## **تعيين ألوان الفروع لنقاط البيانات**

استخدم ألوان الفروع للتحكم في كيفية تجميع العقد الأصلية والفرعية بصريًا في مخططات Treemap وSunburst. يوضح هذا القسم كيفية تعيين لون فرع مخصص لنقطة بيانات محددة بحيث يمكنك إبراز الأشجار الفرعية المهمة وتحسين قابلية قراءة المخطط.

غيّر لون فرع "Stem 4":

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

![لون الفرع](branch_color.png)

## **الأسئلة المتكررة**

**هل يمكنني تغيير ترتيب (الفرز) القطاعات في Sunburst/Treemap؟**

لا. يقوم PowerPoint بفرز القطاعات تلقائيًا (عادةً بالقيم التنازلية، باتجاه عقارب الساعة). تعكس Aspose.Slides هذا السلوك: لا يمكنك تغيير الترتيب مباشرة؛ يمكنك تحقيق ذلك من خلال معالجة البيانات مسبقًا.

**كيف يؤثر سمة العرض التقديمي على ألوان القطاعات والتسميات؟**

تورث ألوان المخطط سمة العرض التقديمي [theme/palette](/slides/ar/python-net/presentation-theme/) ما لم تقم بتعيين التعبئات/ الخطوط صراحة. للحصول على نتائج متسقة، احرص على تثبيت التعبئات الصلبة وتنسيق النص بالمستويات المطلوبة.

**هل سيحافظ التصدير إلى PDF/PNG على ألوان الفروع المخصصة وإعدادات التسميات؟**

نعم. عند تصدير العرض التقديمي، يتم حفظ إعدادات المخطط (التعبئات، التسميات) في صيغ الإخراج لأن Aspose.Slides يقوم بتطبيق تنسيق المخطط أثناء التصيير.

**هل يمكنني حساب الإحداثيات الفعلية لتسمية/عنصر لتحديد موقع طبقة مخصصة فوق المخطط؟**

نعم. بعد تحقق تخطيط المخطط، تتوفر `actual_x`/`actual_y` للعناصر (على سبيل المثال، [DataLabel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/))، مما يساعد على تحديد موضع الطبقات بدقة.