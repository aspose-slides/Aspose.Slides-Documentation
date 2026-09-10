---
title: تخصيص وسوم المخططات في العروض التقديمية باستخدام Python
linktitle: وسمة المخطط
type: docs
url: /ar/python-java/chart-legend/
keywords:
- وسمة المخطط
- موضع الوسمة
- حجم الخط
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تخصيص وسوم المخططات باستخدام Aspose.Slides للغة Python عبر Java لتحسين عروض PowerPoint التقديمية بتنسيق وسمة مخصص."
---
## **نظرة عامة**

يوفر Aspose.Slides خيارات لتخصيص وسوم المخططات في عروض PowerPoint التقديمية. تُظهر هذه المقالة كيفية تحديد موضع وحجم الوسم، وتعيين حجم الخط للوسم بأكمله، وتطبيق التنسيق على مدخل وسمة فردي.

كما يغطي عدة سلوكيات ذات صلة في قسم الأسئلة الشائعة، بما في ذلك استخدام وضع عدم التراكب بحيث يترك مساحة لمنطقة الرسم لتستوعب الوسم، والسماح بلف تسميات الوسوم الطويلة أو استخدامها لفواصل أسطر، والسماح لتنسيق الوسم بالوراثة من سمة العرض التقديمي عندما لا يتم تطبيق إعدادات نصية أو تعبئة صريحة.

## **تحديد موضع الوسم**

لتعيين خصائص الوسم، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة.
3. إضافة مخطط إلى الشريحة.
4. تعيين خصائص الوسم.
5. حفظ العرض التقديمي كملف PPTX.

المثال التالي يحدد موضع وحجم وسمة المخطط.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# إنشاء عرض تقديمي فارغ.
presentation = Presentation()
try:
    # الحصول على مرجع إلى الشريحة.
    slide = presentation.getSlides().get_Item(0)

    # إضافة مخطط عمودي مجمع إلى الشريحة.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # تعيين خصائص الوسم.
    legend = chart.getLegend()
    legend.setX(50 / chart.getWidth())
    legend.setY(50 / chart.getHeight())
    legend.setWidth(100 / chart.getWidth())
    legend.setHeight(100 / chart.getHeight())

    # حفظ العرض التقديمي على القرص.
    presentation.save("Legend_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين حجم الخط للوسم**

يتيح Aspose.Slides للغة Python عبر Java تعيين حجم الخط للوسم. اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. إنشاء المخطط الافتراضي.
3. تعيين حجم الخط.
4. تعيين القيمة الدنيا للمحور.
5. تعيين القيمة القصوى للمحور.
6. حفظ العرض التقديمي على القرص.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# إنشاء عرض تقديمي فارغ.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)

    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMinValue(False)
    vertical_axis.setMinValue(-5)
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(10)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين حجم الخط لمدخل وسمة فردي**

يتيح Aspose.Slides للغة Python عبر Java تعيين حجم الخط للمدخلات الفردية للوسم. اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. إنشاء المخطط الافتراضي.
3. الوصول إلى مدخل وسمة.
4. تعيين حجم الخط.
5. حفظ العرض التقديمي على القرص.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# إنشاء عرض تقديمي فارغ.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()
    portion_format = text_format.getPortionFormat()

    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)
    portion_format.setFontItalic(NullableBool.True_)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**هل يمكنني تمكين الوسم بحيث يخصص المخطط مساحة له تلقائيًا بدلاً من تغطيته؟**

نعم. استخدم الدالة [setOverlay](https://reference.aspose.com/slides/ar/python-java/aspose.slides/legend/#setOverlay) مع القيمة `False` لتمكين وضع عدم التراكب؛ في هذه الحالة، ستصغر منطقة الرسم لاستيعاب الوسم.

**هل يمكنني إنشاء تسميات وسمة متعددة الأسطر؟**

نعم. يتم لف التسميات الطويلة تلقائيًا عندما تكون المساحة غير كافية؛ كما يتم دعم فواصل الأسطر القسرية عبر أحرف السطر الجديد في اسم السلسلة.

**كيف أجعل الوسم يتبع نظام ألوان سمة العرض التقديمي؟**

لا تقم بتعيين ألوان أو تعبئات أو خطوط صريحة للوسم أو نصه. سيتورث ذلك من السمة وسيتم تحديثه بشكل صحيح عند تغيير التصميم.