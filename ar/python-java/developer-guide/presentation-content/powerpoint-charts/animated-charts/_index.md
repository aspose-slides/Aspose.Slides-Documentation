---
title: "تحريك مخططات PowerPoint في Python عبر Java"
linktitle: "مخططات متحركة"
type: docs
weight: 80
url: /ar/python-java/animated-charts/
keywords:
- مخطط
- مخطط متحرك
- تحريك المخطط
- سلسلة المخطط
- فئة المخطط
- عنصر السلسلة
- عنصر الفئة
- إضافة تأثير
- نوع التأثير
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "أنشئ مخططات متحركة مبهرة في Python عبر Java باستخدام Aspose.Slides. عزّز العروض التقديمية بمرئيات ديناميكية في ملفات PPT وPPTX—ابدأ الآن."
---
## **المقدمة**

Aspose.Slides for Python via Java يدعم تحريك عناصر المخطط. يمكن تحريك **Series**، **Categories**، **Series Elements** و **Category Elements** باستخدام طريقة [Sequence.addEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sequence/#addEffect) واثنين من التعدادات: [EffectChartMajorGroupingType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effectchartmajorgroupingtype/) و [EffectChartMinorGroupingType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effectchartminorgroupingtype/).

## **تحريك سلسلة المخطط**

إذا كنت تريد تحريك سلسلة مخطط، اكتب الشيفرة وفقًا للخطوات المذكورة أدناه:

1. تحميل عرض تقديمي.
1. الحصول على مرجع لكائن المخطط.
1. تحريك السلسلة.
1. كتابة ملف العرض التقديمي إلى القرص.

المثال التالي يحرك سلاسل المخطط. المخطط في ملف المثال يحتوي على ثلاث سلاسل، لذلك يتم إضافة تأثير واحد لكل فهرس من 0 إلى 2. لا يتحقق Aspose.Slides من الفهرس مقابل بيانات المخطط، وتُكتب أي تأثير مضاف لسلسلة غير موجودة إلى الملف لكنه لا يحرك شيئًا—احرص على أن يكون الفهرس أقل من عدد السلاسل في المخطط الخاص بك.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# تحميل العرض التقديمي.
presentation = Presentation("ExistingChart.pptx")
try:
    # الحصول على مرجع لكائن المخطط.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # تحريك عناصر المخطط.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # كتابة العرض التقديمي المعدل إلى القرص.
    presentation.save("AnimatingSeries_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تحريك فئة المخطط**

إذا كنت تريد تحريك فئة مخطط، اكتب الشيفرة وفقًا للخطوات المذكورة أدناه:

1. تحميل عرض تقديمي.
1. الحصول على مرجع لكائن المخطط.
1. تحريك الفئة.
1. كتابة ملف العرض التقديمي إلى القرص.

المثال التالي يحرك فئات المخطط.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# تحميل العرض التقديمي.
presentation = Presentation("ExistingChart.pptx")
try:
    # الحصول على مرجع لكائن المخطط.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # تحريك عناصر المخطط.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # كتابة العرض التقديمي المعدل إلى القرص.
    presentation.save("Sample_Animation_C.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **التحريك في عنصر سلسلة**

إذا كنت تريد تحريك عناصر السلسلة، اكتب الشيفرة وفقًا للخطوات المذكورة أدناه:

1. تحميل عرض تقديمي.
1. الحصول على مرجع لكائن المخطط.
1. تحريك عناصر السلسلة.
1. كتابة ملف العرض التقديمي إلى القرص.

المثال التالي يحرك عناصر السلسلة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# تحميل العرض التقديمي.
presentation = Presentation("ExistingChart.pptx")
try:
    # الحصول على مرجع لكائن المخطط.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # تحريك عناصر المخطط.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # كتابة العرض التقديمي المعدل إلى القرص.
    presentation.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **التحريك في عنصر فئة**

إذا كنت تريد تحريك عناصر الفئة، اكتب الشيفرة وفقًا للخطوات المذكورة أدناه:

1. تحميل عرض تقديمي.
1. الحصول على مرجع لكائن المخطط.
1. تحريك عناصر الفئة.
1. كتابة ملف العرض التقديمي إلى القرص.

المثال التالي يحرك عناصر الفئة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# تحميل العرض التقديمي.
presentation = Presentation("ExistingChart.pptx")
try:
    # الحصول على مرجع لكائن المخطط.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # تحريك عناصر المخطط.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # كتابة العرض التقديمي المعدل إلى القرص.
    presentation.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**هل يتم دعم أنواع تأثيرات مختلفة (مثل الدخول، التأكيد، الخروج) للمخططات كما هو الحال للأشكال العادية؟**

نعم. يُعامل المخطط كشكل، وبالتالي يدعم أنواع التأثيرات القياسية للرسوم المتحركة، بما في ذلك الدخول، التأكيد، والخروج، مع تحكم كامل عبر خط زمن الشريحة وتسلسلات الرسوم المتحركة.

**هل يمكنني الجمع بين تحريك المخطط وانتقالات الشريحة؟**

نعم. [Transitions](/slides/ar/python-java/slide-transition/) تُطبق على الشريحة، بينما تُطبق تأثيرات التحريك على الكائنات داخل الشريحة. يمكنك استخدام كليهما معًا في نفس العرض التقديمي والتحكم فيهما بشكل مستقل.

**هل يتم الحفاظ على تحريكات المخطط عند الحفظ إلى PPTX؟**

نعم. عندما تقوم بـ[save to PPTX](/slides/ar/python-java/save-presentation/)، يتم الحفاظ على جميع تأثيرات التحريك وترتيبها لأنّها جزء من نموذج الرسوم المتحركة الأصلي للعرض التقديمي.

**هل يمكنني قراءة تحريكات المخطط الموجودة في عرض تقديمي وتعديلها؟**

نعم. توفر الـ API إمكانية الوصول إلى خط زمن الشريحة، والتسلسلات، والتأثيرات، مما يسمح لك بفحص التحريكات الموجودة للمخطط وتعديلها دون الحاجة إلى إعادة إنشاء كل شيء من الصفر.

**هل يمكنني إنتاج فيديو يتضمن تحريكات المخطط باستخدام Aspose.Slides؟**

نعم. يمكنك [export a presentation to video](/slides/ar/python-java/convert-powerpoint-to-video/) مع الحفاظ على التحريكات، وضبط التوقيتات وإعدادات التصدير الأخرى بحيث يعكس المقطع الناتج التشغيل المتحرك.