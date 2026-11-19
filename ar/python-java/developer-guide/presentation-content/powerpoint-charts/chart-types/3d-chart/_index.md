---
title: "تخصيص المخططات ثلاثية الأبعاد في العروض التقديمية باستخدام بايثون"
linktitle: "مخطط 3D"
type: docs
url: /ar/python-java/3d-chart/
keywords:
- "مخطط ثلاثي الأبعاد"
- "دوران"
- "عمق"
- "PowerPoint"
- "عرض تقديمي"
- "Python"
- "Java"
- "Aspose.Slides"
description: "إنشاء مخططات ثلاثية الأبعاد في عروض PowerPoint التقديمية باستخدام Aspose.Slides للغة بايثون عبر جافا. تعديل الدوران، نسب الارتفاع، عمق المخطط، والمسافات بين السلاسل باستخدام أمثلة بايثون."
---
## **نظرة عامة**

تتيح لك Aspose.Slides للغة Python عبر Java تخصيص عرض مخطط ثلاثي الأبعاد من خلال طريقة [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D). توضح هذه المقالة كيفية تعديل الدوران، نسب الارتفاع، العمق، المحاور بزاوية قائمة، والمسافات بين السلاسل، ثم حفظ العرض التقديمي بتنسيق PPTX.

## **تعيين الدوران والعمق لمخطط ثلاثي الأبعاد**

المثال أدناه ينشئ كائنًا من [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ويستخدم [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) لإضافة مخطط عمودي ثلاثي الأبعاد مكدس إلى الشريحة الأولى. يستبدل السلاسل والفئات الافتراضية بسلسلتين يحتوي كل منهما على ثلاثة قيم. يحدد فهرس ورقة العمل `0` ورقة البيانات الأولى للمخطط؛ الصف `0` يحتوي على أسماء السلاسل، والعمود `0` يحتوي على تسميات الفئات.

تقوم طريقتا [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) و[setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) بتعيين دوران المخطط إلى 40 و270 درجة على التوالي. تقوم طريقة [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) بتعيين عمقه إلى 150 % من عرضه، بينما تُفعِّل طريقة [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) المحاور بزاوية قائمة بدلاً من المنظور. يحتوي العرض التقديمي الناتج على المخطط المملوء بهذه إعدادات العرض الثلاثية الأبعاد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.getCell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.getChartData().getCategories().add(category_cell)

    for series_index in range(2):
        series_cell = workbook.getCell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())

        for category_index in range(3):
            value_cell = workbook.getCell(worksheet_index, category_index + 1, series_index + 1, jpype.JDouble(values[series_index][category_index]))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ضبط نسب الارتفاع لمخطط ثلاثي الأبعاد**

استخدم [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) لتعيين ارتفاع المخطط الثلاثي الأبعاد كنسبة مئوية من عرضه. يغيّر هذا من نسب المشهد الثلاثي الأبعاد دون تعديل حجم كائن المخطط على الشريحة.

المثال التالي ينشئ مخططًا من النوع [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) بالبيانات الافتراضية: ثلاث سلاسل وأربع فئات. يحفظ ثلاث عروض تقديمية بنسب ارتفاع 50 %، 100 %، و200 %. يبقى موضع المخطط وعرضه وارتفاعه ثابتًا. البيانات، الدوران، العمق، مسافة السلاسل، والتنسيق متطابقة في جميع الملفات الثلاثة؛ تتغير فقط نسبة الارتفاع.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460)
    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setDepthPercents(100)
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150)

    for height_percent in [50, 100, 200]:
        chart.getRotation3D().setHeightPercents(height_percent)
        presentation.save(f"chart_height_{height_percent}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

توضح الصور التالية نفس إعدادات الارتفاع في المثال المكافئ لمنصة .NET وتم تصديرها باستخدام Microsoft PowerPoint. النسبة الأصغر تنتج مشهدًا مسطحًا، بينما النسبة الأكبر تنتج مشهدًا أطول داخل نفس كائن المخطط. قد يقوم PowerPoint أيضًا بضبط فواصل علامات المحور ووضع التسميات لتناسب المشهد.

| الارتفاع: 50% | الارتفاع: 100% | الارتفاع: 200% |
| --- | --- | --- |
| ![مخطط عمودي ثلاثي الأبعاد بارتفاع 50 % من عرضه](height_percent_50.png) | ![مخطط عمودي ثلاثي الأبعاد بارتفاع 100 % من عرضه](height_percent_100.png) | ![مخطط عمودي ثلاثي الأبعاد بارتفاع 200 % من عرضه](height_percent_200.png) |

تتحكم هذه الطرق في جوانب مختلفة من المخطط:

| Method | Effect |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | ارتفاع المشهد الثلاثي الأبعاد كنسبة مئوية من عرضه. |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | ارتفاع كائن المخطط على الشريحة، بالنقاط. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | عمق المشهد الثلاثي الأبعاد كنسبة مئوية من عرضه. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | المسافة بين السلاسل على محور العمق، كنسبة مئوية من عرض العلامة. |

تؤثر إعدادات الارتفاع على مخططات العمود والشريط الثلاثية الأبعاد، بما في ذلك الأشكال الأسطوانية، المخروطية، والهرمية، وكذلك مخططات الخط، المنطقة، الفطيرة، والسطح الثلاثية الأبعاد. المقارنة أعلاه تستخدم النوع المؤكد `Column3D`. لا يغيّر الإعداد مظهر مخطط `ClusteredColumn` ثنائي الأبعاد أو مخطط `BubbleWith3D`؛ هذه الأسماء هي أعضاء من فئة [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). للحصول على إعدادات أخرى لمظهر المخطط، راجع [Chart Formatting](/slides/ar/python-java/chart-formatting/).

## **ضبط الفجوة بين السلاسل**

استخدم [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) للتحكم في المسافة بين سلاسل البيانات على طول محور العمق في مخطط ثلاثي الأبعاد، معبرًا عنها كنسبة مئوية من عرض العلامة. استخدم قيمًا بين **0 إلى 500** شاملًا: `0` يزيل الفجوة، بينما القيم الأكبر تزيد المسافة. مع عمق مخطط ثابت، يؤدي زيادة الفجوة إلى جعل العلامات أرفع على محور العمق.

الوصول إلى المجموعة يتم عبر [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup). ينطبق الإعداد على كل سلسلة في تلك المجموعة، وليس فقط السلسلة المستخدمة للوصول إليها. تُعيد طريقة [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) قيمة الفجوة في العمق وتعكس إعداد المجموعة الأصلية.

يؤثر هذا الإعداد على مخططات العمود والشريط الثلاثية الأبعاد، بما في ذلك الأشكال الأسطوانية، المخروطية، والهرمية، وكذلك مخططات الخط والمنطقة الثلاثية الأبعاد. يعتمد المظهر على ما إذا كانت السلاسل مرتبة في العمق، متجمعة، أو مكدسة. للحصول على مقارنة واضحة للفجوات بين السلاسل المنفصلة، استخدم `ChartType.Column3D` من فئة [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/).

تتحكم هذه الطرق في جوانب مختلفة من المخطط:

| Method | Effect |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | المسافة بين السلاسل على محور العمق، كنسبة مئوية من عرض العلامة. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | المسافة بين مجموعات الأشرطة أو الأعمدة المتجاورة، كنسبة مئوية من عرض العمود أو الشريط. |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | عمق المخطط الكلي، كنسبة مئوية من عرض المخطط. |

المثال التالي المستقل يستخدم بيانات المخطط الافتراضية، التي تحتوي على ثلاث سلاسل وأربع فئات. يحفظ عرضي تقديميين ببيانات، دوران، عرض الفجوة، وعمق المخطط متطابقة؛ يتغيّر فقط عمق الفجوة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230)

    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setDepthPercents(100)

    series = chart.getChartData().getSeries().get_Item(0)
    group = series.getParentSeriesGroup()
    group.setGapWidth(150)

    for gap_depth in [0, 500]:
        group.setGapDepth(gap_depth)

        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, SaveFormat.Pptx)
finally:
    presentation.dispose()
```

توضح الصور التالية نفس إعدادات عمق الفجوة في المثال المكافئ لمنصة .NET وتم تصديرها باستخدام Microsoft PowerPoint.

| عمق الفجوة: 0% | عمق الفجوة: 500% |
| --- | --- |
| ![مخطط عمودي ثلاثي الأبعاد بدون فجوة بين السلاسل على محور العمق](gap_depth_0.png) | ![مخطط عمودي ثلاثي الأبعاد بفجوة 500 % بين السلاسل على محور العمق](gap_depth_500.png) |

## **تغيير نوع السلسلة الثلاثية الأبعاد وشكل الشريط**

في مخطط أسطوانة متجمع، يبدأ السلسلة الأولى بشكل شريط أسطوانة. يطبع المثال القيم الصحيحة التي تُرجعها طريقتا [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) و[ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) قبل وبعد كل تغيير. يُظهر الجدول أسماء الثوابت المقابلة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartShapeType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)
    
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setType(ChartType.ClusteredCone)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setBar3DShape(ChartShapeType.Box)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    presentation.save("series_shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| تغيير السلسلة الأولى | نوع السلسلة | شكل الشريط |
| --- | --- | --- |
| إنشاء المخطط | `ClusteredCylinder` | `Cylinder` |
| تعيين نوع السلسلة إلى `ClusteredCone` | `ClusteredCone` | `Cone` |
| تعيين شكل الشريط إلى `Box` | `ClusteredColumn3D` | `Box` |

تغيير الشكل إلى `Box` يغيّر أيضًا نوع السلسلة إلى `ClusteredColumn3D`. إذا كان الكود يعتمد على نوع السلسلة، استدعِ `series.getType()` بعد تغيير الشكل. القيمة المخزنة مسبقًا قبل التعيين لا تزال تُحدِّد فرع `ClusteredCone`.

![مقارنة PowerPoint تُظهر السلسلة الأولى كأنابيب أسطوانية، مخاريط، وأعمدة مستطيلة من اليسار إلى اليمين](series-shapes.png)

## **الأسئلة الشائعة**

**أي أنواع المخططات تدعم وضع 3D في Aspose.Slides?**

تدعم Aspose.Slides متغيّرات 3D لمخططات الأعمدة، بما في ذلك Column 3D وClustered Column 3D وStacked Column 3D و100 % Stacked Column 3D، إلى جانب الأنواع الثلاثية الأبعاد ذات الصلة التي تُعرض عبر فئة [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). للحصول على قائمة دقيقة ومحدثة، راجع أعضاء [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) في مرجع API للإصدار المثبَّت لديك.

**هل يمكنني الحصول على صورة نقطية لمخطط 3D لتقرير أو للويب؟**

نعم. يمكنك تصدير المخطط إلى صورة باستخدام [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) أو [render the entire slide](/slides/ar/python-java/convert-powerpoint-to-png/) إلى صيغ مثل PNG أو JPEG. هذا مفيد عندما تحتاج إلى معاينة نقطية أو تريد تضمين المخطط في مستندات، لوحات معلومات، أو صفحات ويب دون الحاجة إلى PowerPoint.

**ما مدى كفاءة بناء وعرض مخططات 3D الكبيرة؟**

تعتمد الكفاءة على حجم البيانات وتعقيد المشهد البصري. للحصول على أفضل النتائج، احرص على تقليل التأثيرات الثلاثية الأبعاد، تجنب القوام الثقيلة على الجدران ومناطق الرسم، حدِّد عدد نقاط البيانات لكل سلسلة قدر الإمكان، وقم بالعرض بحجم مناسب (دقة وأبعاد) ليتوافق مع الشاشة أو متطلبات الطباعة.