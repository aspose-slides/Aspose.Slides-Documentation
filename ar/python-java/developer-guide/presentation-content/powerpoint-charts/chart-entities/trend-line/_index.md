---
title: إضافة خطوط الاتجاه إلى مخططات العروض التقديمية في بايثون
linktitle: خط الاتجاه
type: docs
url: /ar/python-java/trend-line/
keywords:
- مخطط
- خط اتجاه
- خط اتجاه أسي
- خط اتجاه خطي
- خط اتجاه لوغاريتمي
- خط اتجاه متوسط متحرك
- خط اتجاه متعدد الحدود
- خط اتجاه القوة
- خط اتجاه مخصص
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "أضف خطوط الاتجاه وتخصيصها بسرعة في مخططات PowerPoint باستخدام Aspose.Slides للبايثون عبر جافا — دليل عملي لجذب جمهورك."
---
## **نظرة عامة**

هذا المقال يشرح كيفية إضافة خطوط الاتجاه إلى مخططات العروض باستخدام Aspose.Slides. يوضح كيفية إنشاء مخطط، إضافة خطوط الاتجاه إلى سلاسل المخطط، والعمل مع عدة أنواع من خطوط الاتجاه، بما في ذلك الأسي، الخطي، اللوغاريتمي، المتوسط المتحرك، متعدد الحدود، والقدرة.

كما يصف كيفية إضافة خط مخصص إلى مخطط عن طريق إدراج شكل خط، ويتضمن أسئلة متكررة قصيرة حول قيم إظهار إتجاه الخط إلى الأمام وإلى الخلف وما إذا كانت خطوط الاتجاه تُحفظ أثناء التصدير إلى PDF أو SVG وعند تحويل المخططات إلى صور.

## **إضافة خط اتجاه**

استخدم [TrendlineCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinecollection/#add) لإضافة خط اتجاه إلى سلسلة مخطط، مع تحديد نوعه عبر [TrendlineType](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinetype/). يُنشئ المثال مخطط أعمدة مجمع ببيانات افتراضية ويضيف خطي اتجاه إلى كل من السلاسل الثلاثة.

يخفي خط الاتجاه الأسي معادلته وقيمة R‑squared عبر [setDisplayEquation](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayEquation) و[setDisplayRSquaredValue](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayRSquaredValue)، بينما يكون خط الاتجاه الخطي أحمر. يستخدم خط الاتجاه اللوغاريتمي [addTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#addTextFrameForOverriding) لتسمية مخصصة. يستخدم المتوسط المتحرك [setPeriod](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setPeriod) لثلاث نقاط بيانات و[setTrendlineName](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setTrendlineName) مخصص.

يحتوي خط الاتجاه متعدد الحدود على رتبة ثلاثة، يتم تعيينها عبر [setOrder](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setOrder) ويمتد فئة واحدة إلى الأمام عبر [setForward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setForward). يمتد خط الاتجاه بالقوة فئة واحدة إلى الخلف عبر [setBackward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setBackward).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    first_series = chart.getChartData().getSeries().get_Item(0)

    exponential_trendline = first_series.getTrendLines().add(TrendlineType.Exponential)
    exponential_trendline.setDisplayEquation(False)
    exponential_trendline.setDisplayRSquaredValue(False)

    linear_trendline = first_series.getTrendLines().add(TrendlineType.Linear)
    linear_trendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    second_series = chart.getChartData().getSeries().get_Item(1)

    logarithmic_trendline = second_series.getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trendline.addTextFrameForOverriding("New log trend line")

    moving_average_trendline = second_series.getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trendline.setPeriod(jpype.JByte(3))
    moving_average_trendline.setTrendlineName("New TrendLine Name")

    third_series = chart.getChartData().getSeries().get_Item(2)

    polynomial_trendline = third_series.getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trendline.setForward(1)
    polynomial_trendline.setOrder(jpype.JByte(3))

    power_trendline = third_series.getTrendLines().add(TrendlineType.Power)
    power_trendline.setBackward(1)

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين تقاطع خط الاتجاه**

استخدم [setIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setIntercept) لتثبيت قيمة Y لخط الاتجاه عند X = 0. يتم دعم هذا الإعداد لخطوط الاتجاه الخطي، الأسي، ومتعدد الحدود.

على سبيل المثال، قد يحتاج نموذج تكلفة الإنتاج إلى البدء بتكاليف ثابتة معروفة مقدارها 100، حتى عندما تشير القياسات عند أحجام إنتاج غير صفرية إلى أساس مختلف. بالنسبة لخط الاتجاه الخطي، يقيّد تثبيت التقاطع المعادلة `y = ax + b` إلى `b = 100`؛ ويتم تعديل الانحدار وفق البيانات تحت هذا القيد. هذا لا يعني مجرد تحريك خط مُناسب مسبقًا. تتحكم إعدادات تقاطع المحاور في موضع التقاط المحاور، وليس في معاملات خط الاتجاه المُناسب.

المثال التالي ينشئ مخططًا مبعثرًا (XY) بحجوم إنتاج من 1 إلى 4 وتكاليف 170، 200، 230، و260. يحفظ المخطط بالتقاطع التلقائي الافتراضي، ثم يضبط التقاطع إلى 100 ويحفظ ملف PPTX ثاني. يختلف الملفان فقط في إعداد التقاطع. يُظهر خط الاتجاه معادلته ويمتد إلى X = 0.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, TrendlineType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    name_cell = workbook.getCell(0, 0, 1, "Production cost")
    series = chart.getChartData().getSeries().add(name_cell, ChartType.ScatterWithMarkers)
    costs = [170, 200, 230, 260]

    for i in range(len(costs)):
        x_cell = workbook.getCell(0, i + 1, 0, i + 1)
        y_cell = workbook.getCell(0, i + 1, 1, costs[i])
        series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    trendline = series.getTrendLines().add(TrendlineType.Linear)
    trendline.setDisplayEquation(True)
    trendline.setBackward(1)

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx)

    trendline.setIntercept(100)
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

مع الحساب التلقائي، تُنتج هذه البيانات `y = 30x + 140`. ضبط التقاطع إلى 100 ينتج تقريبًا `y = 43.33x + 100`: القيمة المُناسبة عند الصفر تتطابق مع الأساس المعروف، بينما لا يمر الخط بعد الآن عبر كل نقطة بيانات.

| التقاطع التلقائي | تقاطع ثابت 100 |
| --- | --- |
| ![خط الاتجاه الخطي مع تقاطع محسوب تلقائيًا بقيمة 140](intercept-automatic.png) | ![خط الاتجاه الخطي مع تقاطع ثابت بقيمة 100](intercept-fixed.png) |

تستخدم الصورتان نفس البيانات ومقاييس المحاور. تُمتد خطوط الاتجاه إلى X = 0 لإظهار تقاطعاتها.

بشكل افتراضي، تُعيد [getIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#getIntercept) القيمة `NaN`، التي تمثل تقاطعًا غير محدد بدلاً من الصفر. ثم يُحسب التقاطع تلقائيًا من البيانات.

## **إضافة خط مخصص**

الخط المخصص هو شكل يُرسم فوق المخطط بدلاً من أن يكون خط اتجاه يُحسب من بيانات السلاسل. يستخدم هذا المثال [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) لإضافة خط أفقي إلى الشريحة فوق المخطط. يُحدَّد موضع الخط بإحداثيات الشريحة، مقاسًا بالنقاط، لذا يبدأ عند الحافة اليسرى للمخطط ويقع في منتصف ارتفاعه. عرضه يطابق عرض المخطط. تُتيح طريقة [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) الوصول إلى تنسيق الخط لتطبيق لون أحمر صلب.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0)
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**ماذا يعني “forward” و “backward” بالنسبة لخط الاتجاه؟**

هما طولا خط الاتجاه المُمتد إلى الأمام أو الخلف: بالنسبة لمخططات المبعثر (XY) — بوحدات المحور؛ بالنسبة للمخططات غير المبعثرة — بعدد الفئات. يُسمح فقط بالقيم غير السالبة.

**هل يتم حفظ خط الاتجاه عند تصدير العرض التقديمي إلى PDF أو SVG، أو عند تحويل الشريحة إلى صورة؟**

نعم. يقوم Aspose.Slides بتحويل العروض التقديمية إلى [PDF](/slides/ar/python-java/convert-powerpoint-to-pdf/) أو [SVG](/slides/ar/python-java/render-a-slide-as-an-svg-image/) ويُحَوِّل المخططات إلى صور؛ تُحفظ خطوط الاتجاه، كجزء من المخطط، أثناء هذه العمليات. كما تتوفر طريقة لـ [export an image of the chart](/slides/ar/python-java/create-shape-thumbnails/) نفسها.