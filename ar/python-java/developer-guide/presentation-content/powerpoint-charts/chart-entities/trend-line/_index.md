---
title: إضافة خطوط الاتجاه إلى مخططات العرض في بايثون
linktitle: خط الاتجاه
type: docs
url: /ar/python-java/trend-line/
keywords:
- مخطط
- خط الاتجاه
- خط الاتجاه الأسي
- خط الاتجاه الخطي
- خط الاتجاه اللوغاريتمي
- خط الاتجاه للمتوسط المتحرك
- خط الاتجاه المتعدد الحدود
- خط الاتجاه القوي
- خط الاتجاه المخصص
- PowerPoint
- عرض
- Python
- Java
- Aspose.Slides
description: "أضف خطوط الاتجاه وخصصها بسرعة في مخططات PowerPoint باستخدام Aspose.Slides for Python عبر Java — دليل عملي لجذب جمهورك."
---
## **نظرة عامة**

توضح هذه المقالة كيفية إضافة خطوط الاتجاه إلى مخططات العرض باستخدام Aspose.Slides. وتظهر كيفية إنشاء مخطط، إضافة خطوط الاتجاه إلى سلاسل المخطط، والعمل مع عدة أنواع من خطوط الاتجاه، بما في ذلك الأسية، الخطية، اللوغاريتمية، المتوسط المتحرك، المتعدد الحدود، والقوة.

كما توضح كيفية إضافة خط مخصص إلى المخطط عن طريق إدراج شكل خط، وتضم سؤالًا شائعًا قصيرًا حول قيم إسقاط خط الاتجاه إلى الأمام وإلى الخلف وما إذا كانت خطوط الاتجاه تُحافظ عليها أثناء تصدير العرض إلى PDF أو SVG وعند تحويل المخططات إلى صور.

## **إضافة خط اتجاه**

توفر Aspose.Slides for Python via Java واجهة برمجة تطبيقات بسيطة لإدارة خطوط الاتجاه المختلفة للمخططات:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. الحصول على مرجع إلى شريحة بواسطة فهرسها.
3. إضافة مخطط ببيانات افتراضية والنوع المطلوب (هذا المثال يستخدم [ChartType.ClusteredColumn](https://reference.aspose.com/slides/ar/python-java/aspose.slides/charttype/#ClusteredColumn)).
4. إضافة خط اتجاه أسي إلى السلسلة 1 في المخطط.
5. إضافة خط اتجاه خطي إلى السلسلة 1 في المخطط.
6. إضافة خط اتجاه لوغاريتمي إلى السلسلة 2 في المخطط.
7. إضافة خط اتجاه متوسط متحرك إلى السلسلة 2 في المخطط.
8. إضافة خط اتجاه متعدد حدود إلى السلسلة 3 في المخطط.
9. إضافة خط اتجاه قوة إلى السلسلة 3 في المخطط.
10. حفظ العرض المعدل في ملف PPTX.

الشفرة التالية تنشئ مخططًا مع خطوط الاتجاه.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

# إنشاء نسخة من فئة Presentation.
presentation = Presentation()
try:
    # إنشاء مخطط أعمدة متجمعة.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    # إضافة خط اتجاه أسي إلى السلسلة 1 في المخطط.
    exponential_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential)
    exponential_trend_line.setDisplayEquation(False)
    exponential_trend_line.setDisplayRSquaredValue(False)

    # إضافة خط اتجاه خطي إلى السلسلة 1 في المخطط.
    linear_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear)
    linear_trend_line.setTrendlineType(TrendlineType.Linear)
    linear_trend_line.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trend_line.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # إضافة خط اتجاه لوغاريتمي إلى السلسلة 2 في المخطط.
    logarithmic_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trend_line.setTrendlineType(TrendlineType.Logarithmic)
    logarithmic_trend_line.addTextFrameForOverriding("New log trend line")

    # إضافة خط اتجاه متوسط متحرك إلى السلسلة 2 في المخطط.
    moving_average_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trend_line.setTrendlineType(TrendlineType.MovingAverage)
    moving_average_trend_line.setPeriod(jpype.JByte(3))
    moving_average_trend_line.setTrendlineName("New TrendLine Name")

    # إضافة خط اتجاه متعدد حدود إلى السلسلة 3 في المخطط.
    polynomial_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trend_line.setTrendlineType(TrendlineType.Polynomial)
    polynomial_trend_line.setForward(1)
    polynomial_trend_line.setOrder(jpype.JByte(3))

    # إضافة خط اتجاه قوة إلى السلسلة 3 في المخطط.
    power_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Power)
    power_trend_line.setTrendlineType(TrendlineType.Power)
    power_trend_line.setBackward(1)

    # حفظ العرض.
    presentation.save("ChartTrendLines_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إضافة خط مخصص**

توفر Aspose.Slides for Python عبر Java واجهة برمجة تطبيقات بسيطة لإضافة خطوط مخصصة إلى المخطط. لإضافة خط عادي إلى مخطط على شريحة مختارة، اتبع الخطوات التالية:

- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
- الحصول على مرجع إلى شريحة بواسطة فهرسها.
- إنشاء مخطط جديد باستخدام طريقة [addChart](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addChart) من الفئة [ShapeCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/).
- إضافة شكل خط باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addAutoShape) مع [ShapeType.Line](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapetype/#Line).
- ضبط لون خط الشكل.
- حفظ العرض المعدل في ملف PPTX.

الشفرة التالية تنشئ مخططًا بخط مخصص.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# إنشاء نسخة من فئة Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0)

    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("Presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**ماذا يعني 'forward' و 'backward' لخط الاتجاه؟**

إنها أطوال خط الاتجاه المُسقطة إلى الأمام أو الخلف: بالنسبة لمخططات التبعثر (XY)، يتم قياسها بوحدات المحور؛ بالنسبة للمخططات غير التبعثرية، يتم قياسها بعدد الفئات. يُسمح فقط بالقيم غير السالبة.

**هل سيُحافظ على خط الاتجاه عند تصدير العرض إلى PDF أو SVG، أو عند تحويل شريحة إلى صورة؟**

نعم. تقوم Aspose.Slides بتحويل العروض إلى [PDF](/slides/ar/python-java/convert-powerpoint-to-pdf/)/[SVG](/slides/ar/python-java/render-a-slide-as-an-svg-image/) وتُنشئ صورًا للمخططات؛ تُحافظ خطوط الاتجاه، كجزء من المخطط، على وجودها خلال هذه العمليات. كما تتوفر طريقة لـ [تصدير صورة للمخطط](/slides/ar/python-java/create-shape-thumbnails/) نفسها.