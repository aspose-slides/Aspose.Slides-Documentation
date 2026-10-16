---
title: إضافة خطوط الاتجاه إلى مخططات العروض التقديمية في Python
linktitle: خط الاتجاه
type: docs
url: /ar/python-net/trend-line/
keywords:
- مخطط
- خط الاتجاه
- خط الاتجاه الأسّي
- خط الاتجاه الخطي
- خط الاتجاه اللوغاريتمي
- خط الاتجاه المتوسط المتحرك
- خط الاتجاه متعدد الحدود
- خط الاتجاه القوي
- خط الاتجاه المخصص
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "أضف خطوط الاتجاه وخصصها بسرعة في مخططات PowerPoint باستخدام Aspose.Slides للبايثون عبر .NET — دليل عملي لجذب انتباه جمهورك."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية إضافة خطوط الاتجاه إلى مخططات العروض التقديمية باستخدام Aspose.Slides. تُظهر كيفية إنشاء مخطط، وإضافة خطوط اتجاه إلى سلاسل المخطط، والعمل مع عدة أنواع من خطوط الاتجاه، بما في ذلك الأسية، الخطية، اللوغاريتمية، المتوسط المتحرك، متعددة الحدود، والقوة. كما تصف كيفية إضافة خط مخصص إلى المخطط عن طريق إدراج شكل خط، وتضم سؤالًا شائعًا قصيرًا حول قيم إظهار خط الاتجاه إلى الأمام والخلف وما إذا كانت خطوط الاتجاه محفوظة أثناء التصدير إلى PDF أو SVG وعند تصيير المخططات كصور.

## **إضافة خط اتجاه**

استخدم [TrendlineCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinecollection/add/) لإضافة خط اتجاه إلى سلسلة مخطط، وتحديد نوعه باستخدام [TrendlineType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinetype/). يُنشئ المثال مخطط أعمدة مُجمّع ببيانات افتراضية ويضيف خطي اتجاه إلى كل من السلاسل الثلاث.

يخفي خط الاتجاه الأسّي معادلته وقيمة R المربعة عبر [display_equation](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_equation/) و[display_r_squared_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_r_squared_value/)، بينما يكون خط الاتجاه الخطّي باللون الأحمر. يستخدم خط الاتجاه اللوغاريتمي [add_text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/add_text_frame_for_overriding/) لتسمية مخصصة. يستخدم المتوسط المتحرك [period](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/period/) يساوي ثلاث نقاط بيانات و[trendline_name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/trendline_name/) مخصص.

يمتلك خط الاتجاه متعدد الحدود [order](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/order/) بقيمة ثلاثة ويمتد فئة واحدة إلى الأمام عبر [forward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/forward/). يمتد خط الاتجاه القوي فئة واحدة إلى الخلف عبر [backward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/backward/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    first_series = chart.chart_data.series[0]

    exponential_trendline = first_series.trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    exponential_trendline.display_equation = False
    exponential_trendline.display_r_squared_value = False

    linear_trendline = first_series.trend_lines.add(charts.TrendlineType.LINEAR)
    linear_trendline.format.line.fill_format.fill_type = slides.FillType.SOLID
    linear_trendline.format.line.fill_format.solid_fill_color.r = 255
    linear_trendline.format.line.fill_format.solid_fill_color.g = 0
    linear_trendline.format.line.fill_format.solid_fill_color.b = 0

    second_series = chart.chart_data.series[1]

    logarithmic_trendline = second_series.trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    logarithmic_trendline.add_text_frame_for_overriding("New log trend line")

    moving_average_trendline = second_series.trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    moving_average_trendline.period = 3
    moving_average_trendline.trendline_name = "New TrendLine Name"

    third_series = chart.chart_data.series[2]

    polynomial_trendline = third_series.trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    polynomial_trendline.forward = 1
    polynomial_trendline.order = 3

    power_trendline = third_series.trend_lines.add(charts.TrendlineType.POWER)
    power_trendline.backward = 1

    presentation.save("ChartTrendLines.pptx", slides.export.SaveFormat.PPTX)
```

## **ضبط تقاطع خط الاتجاه**

استخدم [intercept](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/intercept/) لتثبيت قيمة Y لخط الاتجاه عند X = 0. هذا الإعداد مدعوم لخطوط الاتجاه الخطية، الأسية، ومتعددة الحدود.

على سبيل المثال، قد يحتاج نموذج تكلفة الإنتاج إلى البدء بتكاليف ثابتة معروفة قدرها 100، حتى عندما تشير القياسات عند أحجام إنتاج غير صفرية إلى خط أساس مختلف. بالنسبة لخط الاتجاه الخطّي، يؤدي تثبيت التقاطع إلى قيد المعادلة `y = ax + b` إلى `b = 100`؛ يتم تعديل الانحدار ليتناسب مع البيانات تحت هذا القيد. لا يتم ببساطة نقل خط تم ملاءمته مسبقًا. تتحكم إعدادات تقاطع المحاور في موضع التقاء محاور المخطط، وليس في معاملات خط الاتجاه الملائم.

ينشئ المثال التالي مخططًا مبعثرًا (XY) بأحجام إنتاج من 1 إلى 4 وتكاليف 170 و200 و230 و260. يحفظ المخطط بالتقاطع التلقائي الافتراضي، ثم يضبط التقاطع إلى 100 ويحفظ ملف PPTX ثاني. تختلف الملفان فقط في إعداد التقاطع. يعرض خط الاتجاه معادلته ويمتد إلى X = 0.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_MARKERS, 20, 20, 480, 210)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    name_cell = workbook.get_cell(0, 0, 1, "Production cost")
    series = chart.chart_data.series.add(name_cell, charts.ChartType.SCATTER_WITH_MARKERS)
    costs = [170, 200, 230, 260]

    for i, cost in enumerate(costs):
        x_cell = workbook.get_cell(0, i + 1, 0, i + 1)
        y_cell = workbook.get_cell(0, i + 1, 1, cost)
        series.data_points.add_data_point_for_scatter_series(x_cell, y_cell)

    trendline = series.trend_lines.add(charts.TrendlineType.LINEAR)
    trendline.display_equation = True
    trendline.backward = 1

    presentation.save("AutomaticIntercept.pptx", slides.export.SaveFormat.PPTX)

    trendline.intercept = 100
    presentation.save("FixedIntercept.pptx", slides.export.SaveFormat.PPTX)
```

مع الحساب التلقائي، تُنتج هذه البيانات `y = 30x + 140`. ضبط التقاطع إلى 100 ينتج تقريبًا `y = 43.33x + 100`: القيمة الملائمة عند الصفر تطابق الخط الأساسي المعروف، بينما لا يمر الخط بعد الآن عبر كل نقطة بيانات.

| تقاطع تلقائي | تقاطع ثابت بقيمة 100 |
| --- | --- |
| ![Linear trend line with an automatically calculated intercept of 140](intercept-automatic.png) | ![Linear trend line with a fixed intercept of 100](intercept-fixed.png) |

تستخدم الصورتان نفس البيانات ومقاييس المحاور. يتم تمديد خطوط الاتجاه إلى X = 0 لتظهر تقاطعاتها.

بشكل افتراضي، تحتوي الخاصية على `float("nan")`، التي تمثل تقاطعًا غير محدد بدلًا من الصفر. ثم يتم حساب التقاطع تلقائيًا من البيانات.

## **إضافة خط مخصص**

الخط المخصص هو شكل يُرسم فوق المخطط بدلاً من كونه خط اتجاه محسوبًا من بيانات السلسلة. يستخدم هذا المثال [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) لإضافة خط أفقي إلى الشريحة فوق المخطط. يتم تحديد موضع الخط بإحداثيات الشريحة، مقاسة بالنقاط، لذا يبدأ عند الحافة اليسرى للمخطط ويقع في منتصف ارتفاع المخطط. عرضه يطابق عرض المخطط. تُعطي الخاصية [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) الخط لونًا أحمر صلبًا.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)

    line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, chart.x, chart.y + chart.height / 2, chart.width, 0)
    line.line_format.fill_format.fill_type = slides.FillType.SOLID
    line.line_format.fill_format.solid_fill_color.r = 255
    line.line_format.fill_format.solid_fill_color.g = 0
    line.line_format.fill_format.solid_fill_color.b = 0

    presentation.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**ماذا تعني 'forward' و 'backward' لخط الاتجاه؟**

إنها أطوال خط الاتجاه الممتدة إلى الأمام أو الخلف: بالنسبة للمخططات المبعثرة (XY) — بوحدات المحور؛ بالنسبة للمخططات غير المبعثرة — بعدد الفئات. يُسمح فقط بالقيم غير السالبة.

**هل سيُحفظ خط الاتجاه عند تصدير العرض التقديمي إلى PDF أو SVG، أو عند تصيير شريحة كصورة؟**

Yes. Aspose.Slides converts presentations to [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/) or [SVG](/slides/ar/python-net/render-a-slide-as-an-svg-image/) and renders charts to images; trend lines, as part of the chart, are preserved during these operations. A method also available to [تصدير صورة للمخطط](/slides/ar/python-net/create-shape-thumbnails/) itself.