---
title: تخصيص نقاط البيانات في مخططات Treemap و Sunburst في بايثون
linktitle: نقاط البيانات في مخططات Treemap و Sunburst
type: docs
url: /ar/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap chart
- sunburst chart
- data point
- label color
- branch color
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "تعرف على كيفية إدارة نقاط البيانات في مخططات Treemap و Sunburst باستخدام Aspose.Slides لبايثون عبر .NET، المتوافقة مع صيغ PowerPoint و OpenDocument."
---

## **مقدمة**

من بين أنواع مخططات PowerPoint الأخرى، هناك نوعان هرمّيان — **Treemap** و **Sunburst** (المعروف أيضًا باسم Sunburst Graph أو Sunburst Diagram أو Radial Chart أو Radial Graph أو Multi-Level Pie Chart). تعرض هذه المخططات بيانات هرمية منظمة كشجرة — من الأوراق إلى أعلى الفرع. تُعرّف الأوراق بنقاط بيانات السلسلة، ويُعرّف كل مستوى تجميع متداخل لاحق بالفئة المقابلة. يتيح لك Aspose.Slides لبايثون عبر .NET تنسيق نقاط البيانات في مخططات Sunburst و Treemap باستخدام بايثون.

فيما يلي مخطط Sunburst حيث تُعرّف البيانات في عمود Series1 عقد الأوراق، بينما تُعرّف الأعمدة الأخرى نقاط البيانات الهرمية:

![Sunburst chart example](sunburst_example.png)

لنبدأ بإضافة مخطط Sunburst جديد إلى العرض التقديمي:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="انظر أيضاً" %}}
- [**إنشاء مخططات Sunburst**](/slides/ar/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

إذا كنت بحاجة إلى تنسيق نقاط بيانات المخطط، استخدم واجهات برمجة التطبيقات التالية:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/)، [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/)، وخاصية [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/). توفر هذه الواجهات وصولًا إلى تنسيق نقاط البيانات في مخططات Treemap و Sunburst. يُستخدم [ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) للوصول إلى الفئات متعددة المستويات؛ وهو يمثل حاوية لكائنات [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/). وهو في الأساس غلاف حول [ChartCategoryLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/) مع خصائص إضافية خاصة بنقاط البيانات. يكشف نوع [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) عن خاصيتين — [format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/format/) و [label](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/label/) — اللتين توفران وصولًا إلى الإعدادات المقابلة.

## **عرض قيم نقاط البيانات**

يوضح هذا القسم كيفية عرض القيمة لنقاط البيانات الفردية في مخططات Treemap و Sunburst. سترى كيفية تمكين تسميات القيم للنقاط المحددة.

عرض قيمة نقطة البيانات "Leaf 4":

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![Data point value](data_point_value.png)

## **تعيين التسميات والألوان لنقاط البيانات**

يوضح هذا القسم كيفية تعيين تسميات وألوان مخصصة لنقاط البيانات الفردية في مخططات Treemap و Sunburst. ستتعلم كيفية الوصول إلى نقطة بيانات معينة، وتعيين تسمية، وتطبيق تعبئة صلبة لتسليط الضوء على العقد المهمة.

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

استخدم ألوان الفروع للتحكم في كيفية تجميع العقد الأصلية والفرعية بصريًا في مخططات Treemap و Sunburst. يوضح هذا القسم كيفية تعيين لون فرع مخصص لنقطة بيانات معينة لتسلط الضوء على الأشجار الفرعية المهمة وتحسين قابلية قراءة المخطط.

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

**هل يمكنني تغيير ترتيب (الفرز) الأقسام في Sunburst/Treemap؟**

لا. يقوم PowerPoint بفرز الأقسام تلقائيًا (عادةً حسب القيم المتناقصة، باتجاه عقارب الساعة). يعكس Aspose.Slides هذا السلوك: لا يمكنك تغيير الترتيب مباشرةً؛ بل تقوم بذلك عبر معالجة البيانات مسبقًا.

**كيف يؤثر سمة العرض التقديمي على ألوان الأقسام والتسميات؟**

تورث ألوان المخطط سمة العرض التقديمي [theme/palette](/slides/ar/python-net/presentation-theme/) ما لم تقم بتعيين التعبئات/الخطوط صراحةً. للحصول على نتائج متسقة، ثبت التعبئات الصلبة وتنسيق النص في المستويات المطلوبة.

**هل سيحافظ التصدير إلى PDF/PNG على ألوان الفروع المخصصة وإعدادات التسميات؟**

نعم. عند تصدير العرض التقديمي، تُحافظ إعدادات المخطط (التعبئات، التسميات) في تنسيقات الإخراج لأن Aspose.Slides يُطبق تنسيقات المخطط أثناء العرض.

**هل يمكنني حساب الإحداثيات الفعلية لتسمية/عنصر لتحديد موقع تراكب مخصص فوق المخطط؟**

نعم. بعد التحقق من تخطيط المخطط، تكون `actual_x`/`actual_y` متاحة للعناصر (على سبيل المثال، [DataLabel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/))، مما يساعد في تحديد موضع التراكبات بدقة.