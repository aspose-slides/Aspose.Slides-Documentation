---
title: مخططات متحركة
type: docs
weight: 80
url: /ar/net/animated-charts/
keywords: "مخططات، سلسلة المخططات، تحريك عرض PowerPoint، PPTX، PPT، C#، Csharp، Aspose.Slides for .NET"
description: "سلسلة مخططات PowerPoint والتحريكات في C# أو .NET"
---

يدعم Aspose.Slides for .NET تحريك عناصر المخطط. يمكن تحريك **السلاسل**، **الفئات**، **عناصر السلاسل**، **عناصر الفئات** باستخدام طريقة [**ISequence**.**AddEffect** ](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/methods/addeffect) واثنين من القيم enum [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effectchartmajorgroupingtype) و[**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effectchartminorgroupingtype).

## **تحريك سلسلة المخطط**
إذا أردت تحريك سلسلة مخطط، اكتب الشيفرة وفق الخطوات التالية:

1. تحميل عرض تقديمي.
1. الحصول على مرجع كائن المخطط.
1. تحريك السلسلة.
1. كتابة ملف العرض التقديمي إلى القرص.

في المثال أدناه، قمنا بتحريك سلاسل المخطط.
```c#
// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي 
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

    // كتابة العرض التقديمي المعدل إلى القرص 
    presentation.Save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
}
```


## **تحريك فئة المخطط**
إذا أردت تحريك فئة مخطط، اكتب الشيفرة وفق الخطوات التالية:

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

    // كتابة ملف العرض التقديمي إلى القرص
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **تحريك عنصر السلسلة**
إذا أردت تحريك عناصر السلسلة، اكتب الشيفرة وفق الخطوات التالية:

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

     // كتابة ملف العرض التقديمي إلى القرص 
     presentation.Save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
 }
```


## **تحريك عنصر الفئة**
إذا أردت تحريك عناصر الفئات، اكتب الشيفرة وفق الخطوات التالية:

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

    // كتابة ملف العرض التقديمي إلى القرص
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**هل تدعم المخططات أنواع تأثير مختلفة (مثل الدخول، التركيز، الخروج) كما تدعم الأشكال العادية؟**

نعم. تُعامل المخططات كأشكال، لذا تدعم أنواع تأثير الرسوم المتحركة القياسية، بما في ذلك الدخول، التركيز، والخروج، مع تحكم كامل عبر جدول زمني للشرائح وسلاسل الرسوم المتحركة.

**هل يمكنني دمج تحريك المخطط مع انتقالات الشرائح؟**

نعم. [Transitions](/slides/ar/net/slide-transition/) تنطبق على الشريحة، في حين تنطبق تأثيرات الرسوم المتحركة على الكائنات داخل الشريحة. يمكنك استخدامهما معًا في نفس العرض التقديمي والتحكم فيهما بشكل مستقل.

**هل تُحفظ تحريكات المخطط عند حفظ الملف بصيغة PPTX؟**

نعم. عند [save to PPTX](/slides/ar/net/save-presentation/)، تُحفظ جميع تأثيرات الرسوم المتحركة وترتيبها لأنه جزء من نموذج الرسوم المتحركة الأصلي للعرض التقديمي.

**هل يمكنني قراءة تحريكات المخطط الموجودة في عرض تقديمي وتعديلها؟**

نعم. توفر [API](https://reference.aspose.com/slides/net/aspose.slides.animation/) إمكانية الوصول إلى جدول زمني للشرائح، والسلاسل، والتأثيرات، مما يتيح لك فحص تحريكات المخطط الحالية وتعديلها دون الحاجة لإعادة إنشائها من الصفر.

**هل يمكنني إنشاء فيديو يتضمن تحريكات المخطط باستخدام Aspose.Slides؟**

نعم. يمكنك [export a presentation to video](/slides/ar/net/convert-powerpoint-to-video/) مع الحفاظ على التحريكات، وضبط التوقيتات وإعدادات التصدير الأخرى بحيث يعكس المقطع الناتج التشغيل المتحرك.