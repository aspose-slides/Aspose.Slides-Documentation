---
title: تحريك مخططات PowerPoint في جافا
linktitle: المخططات المتحركة
type: docs
weight: 80
url: /ar/java/animated-charts/
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
- Java
- Aspose.Slides
description: "إنشاء مخططات متحركة مذهلة في جافا باستخدام Aspose.Slides. عزز العروض التقديمية بصور ديناميكية في ملفات PPT و PPTX — ابدأ الآن."
---

{{% alert color="primary" %}} 

يدعم Aspose.Slides for Java تحريك عناصر المخطط. يمكن تحريك **Series**، **Categories**، **Series Elements**، **Categories Elements** باستخدام طريقة [**ISequence**.**addEffect**](https://reference.aspose.com/slides/java/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) واثنين من القيم الثابتة [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/java/com.aspose.slides/EffectChartMajorGroupingType) و[**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/java/com.aspose.slides/EffectChartMinorGroupingType).

{{% /alert %}} 

## **تحريك سلسلة المخطط**
إذا كنت ترغب في تحريك سلسلة مخطط، اكتب الكود وفقًا للخطوات المذكورة أدناه:

1. تحميل عرض تقديمي.
2. الحصول على مرجع كائن المخطط.
3. تحريك السلسلة.
4. كتابة ملف العرض التقديمي إلى القرص.

في المثال المعطى أدناه، قمنا بتحريك سلسلة المخطط.
```java
// إنشاء كائن من فئة Presentation الذي يمثل ملف عرض تقديمي
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // الحصول على مرجع كائن المخطط
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // تحريك السلسلة
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 0,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 1,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 2,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 3,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // حفظ العرض التقديمي المعدل إلى القرص
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تحريك فئة المخطط**
إذا كنت ترغب في تحريك فئة مخطط، اكتب الكود وفقًا للخطوات المذكورة أدناه:

1. تحميل عرض تقديمي.
2. الحصول على مرجع كائن المخطط.
3. تحريك الفئة.
4. كتابة ملف العرض التقديمي إلى القرص.

في المثال المعطى أدناه، قمنا بتحريك فئة المخطط.
```java
// إنشاء كائن من فئة Presentation الذي يمثل ملف عرض تقديمي
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0");

    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.ByCategory, 0, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 1, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 2, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 3, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    pres.save("Sample_Animation_C.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تحريك عنصر السلسلة**
إذا كنت ترغب في تحريك عناصر السلسلة، اكتب الكود وفقًا للخطوات المذكورة أدناه:

1. تحميل عرض تقديمي.
2. الحصول على مرجع كائن المخطط.
3. تحريك عناصر السلسلة.
4. كتابة ملف العرض التقديمي إلى القرص.

في المثال المعطى أدناه، قمنا بتحريك عناصر السلسلة.
```java
// إنشاء كائن من فئة Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // الحصول على مرجع كائن المخطط
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // تحريك عناصر السلسلة
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // حفظ ملف العرض التقديمي إلى القرص 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تحريك عنصر الفئة**
إذا كنت ترغب في تحريك عناصر الفئات، اكتب الكود وفقًا للخطوات المذكورة أدناه:

1. تحميل عرض تقديمي.
2. الحصول على مرجع كائن المخطط.
3. تحريك عناصر الفئات.
4. كتابة ملف العرض التقديمي إلى القرص.

في المثال المعطى أدناه، قمنا بتحريك عناصر الفئات.
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // الحصول على مرجع كائن المخطط
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // تحريك عناصر الفئات
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // حفظ ملف العرض التقديمي إلى القرص
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**هل يتم دعم أنواع التأثيرات المختلفة (مثل الدخول، التأكيد، الخروج) للمخططات كما في الأشكال العادية؟**
نعم. يُعامل المخطط ككائن شكل، لذا يدعم أنواع تأثيرات الرسوم المتحركة القياسية، بما في ذلك الدخول، والتأكيد، والخروج، مع تحكم كامل عبر خط زمني الشريحة وتسلسلات الرسوم المتحركة.

**هل يمكن دمج تحريك المخطط مع انتقالات الشرائح؟**
نعم. [Transitions](/slides/ar/java/slide-transition/) تُطبق على الشريحة، بينما تُطبق تأثيرات التحريك على الكائنات داخل الشريحة. يمكنك استخدام كلاهما معًا في نفس العرض التقديمي والتحكم فيهما بشكل مستقل.

**هل يتم حفظ تحريكات المخطط عند حفظ الملف إلى PPTX؟**
نعم. عندما تقوم بـ[save to PPTX](/slides/ar/java/save-presentation/)، يتم حفظ جميع تأثيرات الرسوم المتحركة وترتيبها لأنّها جزء من نموذج الرسوم المتحركة الأصلي للعرض التقديمي.

**هل يمكنني قراءة تحريكات المخطط الموجودة في عرض تقديمي وتعديلها؟**
نعم. توفر API إمكانية الوصول إلى خط زمني الشريحة، والتسلسلات، والتأثيرات، مما يتيح لك فحص تحريكات المخطط الموجودة وتعديلها دون الحاجة إلى إعادة إنشاء كل شيء من الصفر.

**هل يمكنني إنشاء فيديو يتضمن تحريكات المخطط باستخدام Aspose.Slides؟**
نعم. يمكنك [export a presentation to video](/slides/ar/java/convert-powerpoint-to-video/) مع الحفاظ على التحريكات، وضبط التوقيتات وإعدادات التصدير الأخرى بحيث يعكس المقطع الناتج تشغيل التحريكات.