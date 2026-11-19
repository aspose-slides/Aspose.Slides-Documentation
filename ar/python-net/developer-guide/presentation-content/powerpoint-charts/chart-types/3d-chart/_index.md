---
title: تخصيص المخططات ثلاثية الأبعاد في العروض التقديمية باستخدام Python
linktitle: مخطط 3D
type: docs
url: /ar/python-net/3d-chart/
keywords:
- مخطط ثلاثي الأبعاد
- دوران
- عمق
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إنشاء مخططات ثلاثية الأبعاد في عروض PowerPoint التقديمية باستخدام Aspose.Slides for Python via .NET. ضبط الدوران، نسب الارتفاع، عمق المخطط، والمسافة بين السلاسل مع أمثلة بايثون."
---
## **نظرة عامة**

Aspose.Slides for Python via .NET يتيح لك تخصيص عرض مخطط ثلاثي الأبعاد من خلال خاصية [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) . هذه المقالة توضح كيفية ضبط الدوران، نسب الارتفاع، العمق، المحاور القائمة الزاوية، والمسافة بين السلاسل، ثم حفظ العرض التقديمي بصيغة PPTX.

## **ضبط الدوران والعمق لمخطط ثلاثي الأبعاد**

المثال أدناه ينشئ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ويستخدم [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) لإضافة مخطط عمودي ثلاثي الأبعاد مكدس إلى الشريحة الأولى. يستبدل السلاسل والفئات الافتراضية بسلسلتين تحتوي كل منهما على ثلاث قيم. فهرس ورقة العمل `0` يحدد ورقة البيانات الأولى للمخطط؛ الصف `0` يحتوي على أسماء السلاسل، والعمود `0` يحتوي على تسميات الفئات.

خاصية [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) و[rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) تضبط دوران المخطط إلى 40 و270 درجة على التوالي. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) يحدد عمقه بنسبة 150% من عرضه، بينما [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) يفعّل المحاور القائمة الزاوية بدلًا من المنظور. العرض الناتج يحتوي على المخطط المملوء بهذه الإعدادات للعرض ثلاثي الأبعاد.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    
    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.get_cell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.chart_data.categories.add(category_cell)

    for series_index in range(2):
        series_cell = workbook.get_cell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.chart_data.series.add(series_cell, chart.type)

        for category_index in range(3):
            value_cell = workbook.get_cell(worksheet_index, category_index + 1, series_index + 1, values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ضبط نسب الارتفاع لمخطط ثلاثي الأبعاد**

استخدم [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) لتحديد ارتفاع المخطط ثلاثي الأبعاد كنسبة مئوية من عرضه. يغيّر ذلك نسب المشهد ثلاثي الأبعاد دون تغيير حجم عنصر المخطط على الشريحة.

المثال التالي ينشئ مخطط [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) بالبيانات الافتراضية: ثلاث سلاسل وأربع فئات. يحفظ ثلاث عروض تقديمية بنسب ارتفاع 50%، 100%، و200%. يبقى موضع المخطط وعرضه وارتفاعه ثابتًا. البيانات، الدوران، العمق، مسافة السلاسل، والتنسيق متطابقة في الملفات الثلاثة؛ فقط نسبة الارتفاع تتغير.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 460)
    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.depth_percents = 100
    chart.chart_data.series[0].parent_series_group.gap_depth = 150

    for height_percent in (50, 100, 200):
        chart.rotation_3d.height_percents = height_percent
        presentation.save(f"chart_height_{height_percent}.pptx", slides.export.SaveFormat.PPTX)
```

تم تصدير الصور التالية من العروض التقديمية المولدة باستخدام Microsoft PowerPoint. نسبة أصغر تنتج مشهدًا مسطحًا، بينما نسبة أكبر تنتج مشهدًا أطول داخل نفس عنصر المخطط. قد يقوم PowerPoint أيضًا بضبط فواصل علامات المحور وتنسيق التسميات لتلائم المشهد.

| الارتفاع: 50% | الارتفاع: 100% | الارتفاع: 200% |
| --- | --- | --- |
| ![مخطط عمودي ثلاثي الأبعاد بارتفاع مضبوط على 50٪ من عرضه](height_percent_50.png) | ![مخطط عمودي ثلاثي الأبعاد بارتفاع مضبوط على 100٪ من عرضه](height_percent_100.png) | ![مخطط عمودي ثلاثي الأبعاد بارتفاع مضبوط على 200٪ من عرضه](height_percent_200.png) |

تتحكم هذه الخصائص في جوانب مختلفة من المخطط:

| الخاصية | التأثير |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | ارتفاع المشهد ثلاثي الأبعاد كنسبة مئوية من عرضه. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | ارتفاع عنصر المخطط على الشريحة، بالنقاط. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | عمق المشهد ثلاثي الأبعاد كنسبة مئوية من عرضه. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | المسافة بين السلاسل على محور العمق، كنسبة مئوية من عرض العلامة. |

إعداد الارتفاع يؤثر على مخططات العمود والشريط ثلاثية الأبعاد، بما في ذلك المتغيرات الأسطوانية، المخروطية، والهرمية، بالإضافة إلى مخططات الخط، المساحة، الدائرة، والسطح ثلاثية الأبعاد. المقارنة أعلاه تستخدم النوع المؤكد `COLUMN_3D`. الإعداد لا يغيّر مظهر المخطط الثنائي الأبعاد `CLUSTERED_COLUMN` أو مخطط `BUBBLE_WITH_3D`؛ هذه الأسماء هي أعضاء في تعداد [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). لإعدادات مظهر المخطط الأخرى، راجع [تنسيق المخطط](/slides/ar/python-net/chart-formatting/).

## **ضبط الفجوة بين السلاسل**

استخدم [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) للتحكم في المسافة بين سلاسل البيانات على محور العمق في مخطط ثلاثي الأبعاد، معبرًا عنها كنسبة مئوية من عرض العلامة. استخدم القيم من **0 إلى 500**، متضمنًا: `0` يزيل الفجوة، بينما القيم الأكبر تزيد المسافة. مع عمق مخطط ثابت، زيادة الفجوة تجعل العلامات أرق على محور العمق.

الوصول إلى المجموعة يتم عبر [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/). الإعداد يطبق على كل السلاسل في تلك المجموعة، وليس فقط السلسلة المستخدمة للوصول إليها. [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) للقراءة فقط ويعكس إعداد المجموعة الأصل.

هذا الإعداد يؤثر على مخططات العمود والشريط ثلاثية الأبعاد، بما في ذلك المتغيرات الأسطوانية، المخروطية، والهرمية، إضافة إلى مخططات الخط والمساحة ثلاثية الأبعاد. المظهر يعتمد على ما إذا كانت السلاسل مرتبة في العمق، متجمعة، أو مكدسة. للحصول على مقارنة واضحة للفجوات بين السلاسل المنفصلة، استخدم `ChartType.COLUMN_3D` من تعداد [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/).

تتحكم هذه الخصائص في جوانب مختلفة من المخطط:

| الخاصية | التأثير |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | المسافة بين السلاسل على محور العمق، كنسبة مئوية من عرض العلامة. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | المسافة بين مجموعات الأعمدة أو الأشرطة المتجاورة، كنسبة مئوية من عرض العمود أو الشريط. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | عمق المخطط ككل، كنسبة مئوية من عرض المخطط. |

المثال التالي المستقل يستخدم بيانات المخطط الافتراضية، التي تحتوي على ثلاث سلاسل وأربع فئات. يحفظ عرضين تقديميين ببيانات، دوران، عرض الفجوة، وعمق المخطط متطابقة؛ فقط عمق الفجوة يتغير.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 230)

    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.depth_percents = 100

    series = chart.chart_data.series[0]
    group = series.parent_series_group
    group.gap_width = 150

    for gap_depth in (0, 500):
        group.gap_depth = gap_depth
        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

تم تصدير الصور التالية من العروض التقديمية المولدة باستخدام Microsoft PowerPoint.

| عمق الفجوة: 0% | عمق الفجوة: 500% |
| --- | --- |
| ![مخطط عمودي ثلاثي الأبعاد بدون فجوة بين السلاسل على محور العمق](gap_depth_0.png) | ![مخطط عمودي ثلاثي الأبعاد بفجوة 500٪ بين السلاسل على محور العمق](gap_depth_500.png) |

## **تغيير نوع السلسلة ثلاثية الأبعاد وشكل الشريط**

في مخطط أسطواني مجمع، يبدأ السلسلة الأولى بأشرطة أسطوانية. يقرأ المثال [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) و[ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) قبل وبعد كل تغيير.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_CYLINDER, 20, 20, 500, 300)
    series = chart.chart_data.series[0]
    
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.type = charts.ChartType.CLUSTERED_CONE
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.bar_3d_shape = charts.ChartShapeType.BOX
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    presentation.save("series_shape.pptx", slides.export.SaveFormat.PPTX)
```

| تغيير للسلسلة الأولى | `type` | `bar_3d_shape` |
| --- | --- | --- |
| إنشاء المخطط | `CLUSTERED_CYLINDER` | `CYLINDER` |
| ضبط `type` إلى `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| ضبط `bar_3d_shape` إلى `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

ضبط الشكل إلى `BOX` يغيّر أيضًا نوع السلسلة إلى `CLUSTERED_COLUMN_3D`. إذا كان الكود يتفرع بناءً على نوع السلسلة، اقرأ `series.type` بعد تغيير الشكل. قيمة مخزنة قبل الإسناد ما زالت تختار فرع `CLUSTERED_CONE`.

![مقارنة PowerPoint تُظهر السلسلة الأولى كأسطوانات، مخاريط، وأعمدة مستطيلة من اليسار إلى اليمين](series-shapes.png)

## **الأسئلة الشائعة**

**ما هي أنواع المخططات التي تدعم وضع 3D في Aspose.Slides؟**

Aspose.Slides يدعم المتغيرات ثلاثية الأبعاد لمخططات الأعمدة، بما في ذلك Column 3D، Clustered Column 3D، Stacked Column 3D، و100% Stacked Column 3D، بالإضافة إلى الأنواع الثلاثية الأبعاد ذات الصلة التي تظهر من خلال تعداد [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). للحصول على قائمة دقيقة ومحدثة، تحقق من أعضاء [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) في مرجع API للإصدار المثبت لديك.

**هل يمكنني الحصول على صورة نقطية لمخطط ثلاثي الأبعاد لتقرير أو للويب؟**

نعم. يمكنك تصدير المخطط إلى صورة باستخدام [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) أو [تحويل الشريحة بأكملها](/slides/ar/python-net/convert-powerpoint-to-png/) إلى صيغ مثل PNG أو JPEG. هذا مفيد عندما تحتاج إلى معاينة نقطية أو ترغب في تضمين المخطط في مستندات، لوحات معلومات، أو صفحات ويب دون الحاجة إلى PowerPoint.

**ما مدى أداء بناء ورسم مخططات ثلاثية الأبعاد كبيرة؟**

الأداء يعتمد على حجم البيانات وتعقيد العرض البصري. للحصول على أفضل النتائج، حافظ على الحد الأدنى من التأثيرات الثلاثية الأبعاد، تجنّب القوام الثقيلة على الجدار ومساحات الرسم، قلل عدد نقاط البيانات لكل سلسلة عندما يكون ذلك ممكنًا، ورّسّخ إلى مخرجات بالحجم المناسب (الدقة والأبعاد) لت匹配 العرض أو الطباعة المطلوبة.