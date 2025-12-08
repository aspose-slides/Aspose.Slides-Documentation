---
title: تخصيص نقاط البيانات في مخططات Treemap و Sunburst باستخدام Python
linktitle: نقاط البيانات في مخططات Treemap و Sunburst
type: docs
url: /ar/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- مخطط treemap
- مخطط sunburst
- نقطة بيانات
- لون التسمية
- لون الفرع
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعرف على كيفية إدارة نقاط البيانات في مخططات treemap و sunburst باستخدام Aspose.Slides for Python عبر .NET، ومتوافق مع تنسيقات PowerPoint و OpenDocument."
---

## **المقدمة**

إلى جانب أنواع مخططات PowerPoint الأخرى، هناك نوعان هرميان — **Treemap** و **Sunburst** (المعروف أيضًا باسم مخطط Sunburst، مخطط Sunburst، مخطط شعاعي، رسم بياني شعاعي، أو مخطط فطيرة متعدد المستويات). تعرض هذه المخططات بيانات هرمية منظمة كشجرة — من الأوراق إلى أعلى الفرع. تُعرف الأوراق بنقاط بيانات السلسلة، ويُحدد كل مستوى تجميع متداخل لاحق بالفئة المقابلة. يسمح Aspose.Slides for Python via .NET لك بتنسيق نقاط بيانات مخططات Sunburst و Treemap في Python.

إليك مثال على مخطط Sunburst حيث تُعرّف البيانات في عمود Series1 عقد الأوراق، بينما تُعرّف الأعمدة الأخرى نقاط البيانات الهرمية:

![مثال على مخطط Sunburst](sunburst_example.png)

لنبدأ بإضافة مخطط Sunburst جديد إلى العرض التقديمي:
```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```


{{% alert color="primary" title="انظر أيضًا" %}}
- [**إنشاء مخططات Sunburst**](/slides/ar/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

إذا كنت بحاجة إلى تنسيق نقاط بيانات المخطط، استخدم واجهات برمجة التطبيقات التالية:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/)، [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/)، وخاصية [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/). تُتيح لك الوصول إلى تنسيق نقاط البيانات في مخططات Treemap و Sunburst. يُستخدم ChartDataPointLevelsManager للوصول إلى الفئات متعددة المستويات؛ فهو يمثل حاوية لكائنات ChartDataPointLevel. وهو في الأساس غلاف حول ChartCategoryLevelsManager مع خصائص إضافية خاصة بنقاط البيانات. نوع ChartDataPointLevel يكشف عن خاصيتين — [format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/format/) و [label](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/label/) — واللتان توفران الوصول إلى الإعدادات المقابلة.

## **عرض قيم نقاط البيانات**

يوضح هذا القسم كيفية عرض القيمة لنقطة بيانات فردية في مخططات Treemap و Sunburst. ستتعرف على كيفية تمكين تسميات القيم للنقاط المحددة.

عرض قيمة نقطة البيانات "Leaf 4":
```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```


![قيمة نقطة البيانات](data_point_value.png)

## **ضبط التسميات والألوان لنقاط البيانات**

يوضح هذا القسم كيفية تعيين تسميات وألوان مخصصة لنقطة بيانات فردية في مخططات Treemap و Sunburst. ستتعلم كيفية الوصول إلى نقطة بيانات محددة، وتعيين تسمية، وتطبيق تعبئة صلبة لتسليط الضوء على العقد المهمة.

ضبط تسمية البيانات "Branch 1" لعرض اسم السلسلة ("Series1") بدلاً من اسم الفئة، ثم تعيين لون النص إلى أصفر:
```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```


![تسمية ولون نقطة البيانات](data_point_color.png)

## **ضبط ألوان الفروع لنقاط البيانات**

استخدم ألوان الفروع للتحكم في كيفية تجميع العقد الأصلية والفرعية بصريًا في مخططات Treemap و Sunburst. يوضح هذا القسم كيفية تعيين لون فرع مخصص لنقطة بيانات معينة لتسليط الضوء على الأشجار الفرعية المهمة وتحسين قابلية قراءة المخطط.

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


![لون الفرع](branch_color.png)

## **الأسئلة المتكررة**

**هل يمكنني تغيير ترتيب (فرز) المقاطع في مخطط Sunburst/Treemap؟**

لا. يقوم PowerPoint بفرز المقاطع تلقائيًا (عادةً حسب القيم المتناقصة، باتجاه عقارب الساعة). يطابق Aspose.Slides هذا السلوك: لا يمكنك تغيير الترتيب مباشرة؛ يمكنك تحقيق ذلك عبر معالجة البيانات مسبقًا.

**كيف يؤثر سمة العرض التقديمي على ألوان المقاطع والتسميات؟**

ترث ألوان المخطط سمة/لوحة ألوان العرض التقديمي ما لم تقم بتعيين التعبئات/الخطوط صراحةً. للحصول على نتائج متسقة، احرص على تثبيت التعبئات الصلبة وتنسيق النص في المستويات المطلوبة.

**هل سيحافظ التصدير إلى PDF/PNG على ألوان الفروع المخصصة وإعدادات التسميات؟**

نعم. عند تصدير العرض التقديمي، تُحفظ إعدادات المخطط (التعبئات، التسميات) في صيغ الإخراج لأن Aspose.Slides يقوم بتصوير المخطط مع تطبيق تنسيقه.

**هل يمكنني حساب الإحداثيات الفعلية لتسمية/عنصر من أجل وضع طبقة تغطية مخصصة فوق المخطط؟**

نعم. بعد التحقق من تخطيط المخطط، تتوفر `actual_x`/`actual_y` للعناصر (على سبيل المثال، [DataLabel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/))، مما يساعد في وضع الطبقات بدقة.