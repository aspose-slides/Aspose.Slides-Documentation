---
title: تحريك المخططات في PowerPoint باستخدام .NET
linktitle: مخططات متحركة
type: docs
weight: 80
url: /ar/net/animated-charts/
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
- .NET
- C#
- Aspose.Slides
description: "أنشئ مخططات متحركة مذهلة في .NET باستخدام Aspose.Slides. عزّز العروض التقديمية بمرئيات ديناميكية في ملفات PPT وPPTX—ابدأ الآن."
---

يدعم Aspose.Slides for .NET تحريك عناصر المخطط. يمكن تحريك **السلاسل**، **الفئات**، **عناصر السلسلة**، **عناصر الفئات** باستخدام طريقة [**ISequence**.**AddEffect**](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/methods/addeffect) واثنين من التعدادات [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effectchartmajorgroupingtype) و[**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effectchartminorgroupingtype).
## **تحريك سلسلة المخطط**
إذا كنت تريد تحريك سلسلة مخطط، اكتب الكود وفق الخطوات المذكورة أدناه:

1. تحميل عرض تقديمي.
1. الحصول على مرجع كائن المخطط.
1. تحريك السلسلة.
1. كتابة ملف العرض التقديمي إلى القرص.

في المثال أدناه، قمنا بتحريك سلسلة المخطط.
```c#
// إنشاء كائن Presentation الذي يمثل ملف عرض تقديمي 
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // الحصول على مرجع كائن المخطط
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // تحريك السلسلة
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
    EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 0,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 1,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 2,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 3,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // حفظ العرض التقديمي المعدل إلى القرص 
    presentation.Save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
}
```


## **تحريك فئة المخطط**
إذا كنت تريد تحريك فئة مخطط، اكتب الكود وفق الخطوات المذكورة أدناه:

1. تحميل عرض تقديمي.
1. الحصول على مرجع كائن المخطط.
1. تحريك الفئة.
1. كتابة ملف العرض التقديمي إلى القرص.

في المثال أدناه، قمنا بتحريك فئة المخطط.
```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // الحصول على مرجع كائن المخطط
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // تحريك عناصر الفئات
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // حفظ ملف العرض التقديمي إلى القرص
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **تحريك عنصر السلسلة**
إذا كنت تريد تحريك عناصر السلسلة، اكتب الكود وفق الخطوات المذكورة أدناه:

1. تحميل عرض تقديمي.
1. الحصول على مرجع كائن المخطط.
1. تحريك عناصر السلسلة.
1. كتابة ملف العرض التقديمي إلى القرص.

في المثال أدناه، قمنا بتحريك عناصر السلسلة.
```c#
// تحميل عرض تقديمي
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // الحصول على مرجع كائن المخطط
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // تحريك عناصر السلسلة
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // حفظ ملف العرض التقديمي إلى القرص
    presentation.Save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **تحريك عنصر الفئة**
إذا كنت تريد تحريك عناصر الفئات، اكتب الكود وفق الخطوات المذكورة أدناه:

1. تحميل عرض تقديمي.
1. الحصول على مرجع كائن المخطط.
1. تحريك عناصر الفئات.
1. كتابة ملف العرض التقديمي إلى القرص.

في المثال أدناه، قمنا بتحريك عناصر الفئات.
```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // الحصول على مرجع كائن المخطط
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // تحريك عناصر الفئات
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // حفظ ملف العرض التقديمي إلى القرص
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة الشائعة**

**هل يتم دعم أنواع تأثير مختلفة (مثل الدخول، التشديد، الخروج) للمخططات كما هو الحال للأشكال العادية؟**

نعم. يُعامل المخطط كشكل، لذا فإنه يدعم أنواع تأثيرات الرسوم المتحركة القياسية، بما في ذلك الدخول، التشديد، والخروج، مع التحكم الكامل عبر خط زمن الشريحة وتسلسلات الرسوم المتحركة.

**هل يمكن الجمع بين تحريك المخطط وانتقالات الشريحة؟**

نعم. [الانتقالات](/slides/ar/net/slide-transition/) تُطبق على الشريحة، بينما تُطبق تأثيرات الرسوم المتحركة على الكائنات داخل الشريحة. يمكنك استخدامهما معًا في نفس العرض التقديمي والتحكم فيهما بشكل مستقل.

**هل تُحفظ تحريكات المخطط عند حفظ الملف كـ PPTX؟**

نعم. عند [الحفظ كـ PPTX](/slides/ar/net/save-presentation/)، تُحفظ جميع تأثيرات الرسوم المتحركة وترتيبها لأنّها جزء من نموذج الرسوم المتحركة الأصلي للعرض التقديمي.

**هل يمكنني قراءة تحريكات المخطط الموجودة في عرض تقديمي وتعديلها؟**

نعم. توفر الـ[API](https://reference.aspose.com/slides/net/aspose.slides.animation/) إمكانية الوصول إلى خط زمن الشريحة، التسلسلات، والتأثيرات، مما يسمح لك بفحص تحريكات المخطط الحالية وتعديلها دون الحاجة إلى إعادة إنشاء كل شيء من الصفر.

**هل يمكنني إنتاج فيديو يتضمن تحريكات المخطط باستخدام Aspose.Slides؟**

نعم. يمكنك [تصدير العرض التقديمي إلى فيديو](/slides/ar/net/convert-powerpoint-to-video/) مع الحفاظ على الرسوم المتحركة، وتكوين الفواصل الزمنية وإعدادات التصدير الأخرى بحيث يعكس الفيديو النهائي تشغيل الرسوم المتحركة.