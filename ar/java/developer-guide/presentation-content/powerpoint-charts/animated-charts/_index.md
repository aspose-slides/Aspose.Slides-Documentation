---
title: تحريك مخططات PowerPoint في Java
linktitle: مخططات متحركة
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
description: "أنشئ مخططات متحركة مذهلة في Java باستخدام Aspose.Slides. عزّز العروض التقديمية بصور ديناميكية في ملفات PPT و PPTX — ابدأ الآن."
---

{{% alert color="primary" %}} 
Aspose.Slides for Java يدعم تحريك عناصر المخطط. **Series**، **Categories**، **Series Elements**، **Categories Elements** يمكن تحريكها باستخدام طريقة [**ISequence**.**addEffect**](https://reference.aspose.com/slides/java/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) واثنين من التعدادات [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/java/com.aspose.slides/EffectChartMajorGroupingType) و[**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/java/com.aspose.slides/EffectChartMinorGroupingType).
{{% /alert %}} 

## **تحريك سلسلة المخطط**
إذا كنت تريد تحريك سلسلة مخطط، اكتب الشيفرة وفقًا للخطوات المذكورة أدناه:

1. تحميل عرض تقديمي.
1. الحصول على مرجع كائن المخطط.
1. تحريك السلسلة.
1. كتابة ملف العرض التقديمي إلى القرص.

في المثال أدناه، قمنا بتحريك سلسلة المخطط.
```java
// إنشاء كلاس Presentation الذي يمثل ملف عرض تقديمي
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

    // كتابة العرض التقديمي المعدل إلى القرص
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تحريك فئة المخطط**
إذا كنت تريد تحريك فئة المخطط، اكتب الشيفرة وفقًا للخطوات المذكورة أدناه:

1. تحميل عرض تقديمي.
1. الحصول على مرجع كائن المخطط.
1. تحريك الفئة.
1. كتابة ملف العرض التقديمي إلى القرص.

في المثال أدناه، قمنا بتحريك فئة المخطط.
```java
// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

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


## **تحريك عنصر سلسلة**
إذا كنت تريد تحريك عناصر السلسلة، اكتب الشيفرة وفقًا للخطوات المذكورة أدناه:

1. تحميل عرض تقديمي.
1. الحصول على مرجع كائن المخطط.
1. تحريك عناصر السلسلة.
1. كتابة ملف العرض التقديمي إلى القرص.

في المثال أدناه، قمنا بتحريك عناصر السلسلة.
```java
// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي
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

    // كتابة ملف العرض التقديمي إلى القرص 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تحريك عنصر فئة**
إذا كنت تريد تحريك عناصر الفئات، اكتب الشيفرة وفقًا للخطوات المذكورة أدناه:

1. تحميل عرض تقديمي.
1. الحصول على مرجع كائن المخطط.
1. تحريك عناصر الفئات.
1. كتابة ملف العرض التقديمي إلى القرص.

في المثال أدناه، قمنا بتحريك عناصر الفئات.
```java
// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي
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

    // كتابة ملف العرض التقديمي إلى القرص
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**هل يتم دعم أنواع تأثيرات مختلفة (مثل الدخول، التشديد، الخروج) للمخططات كما في الأشكال العادية؟**  
نعم. يتم التعامل مع المخطط ككائن شكل، وبالتالي يدعم أنواع التأثير القياسية بما في ذلك الدخول، والتشديد، والخروج، مع تحكم كامل عبر خط زمني الشريحة وتسلسلات التحريك.

**هل يمكن دمج تحريك المخطط مع انتقالات الشرائح؟**  
نعم. [الانتقالات](/slides/ar/java/slide-transition/) تطبق على الشريحة، بينما تأثيرات التحريك تطبق على الكائنات داخل الشريحة. يمكنك استخدامهما معًا في نفس العرض والتحكم بهما بشكل مستقل.

**هل يتم الحفاظ على تحريك المخطط عند الحفظ إلى PPTX؟**  
نعم. عند [حفظ إلى PPTX](/slides/ar/java/save-presentation/)، يتم الحفاظ على جميع تأثيرات التحريك وترتيبها لأنها جزء من نموذج التحريك الأصلي للعرض.

**هل يمكنني قراءة تحريكات المخطط الموجودة في عرض تقديمي وتعديلها؟**  
نعم. توفر الواجهة البرمجية وصولاً إلى خط زمني الشريحة، والتسلسلات، والتأثيرات، مما يتيح لك فحص تحريكات المخطط الحالية وتعديلها دون الحاجة إلى إعادة إنشائها من الصفر.

**هل يمكنني إنتاج فيديو يتضمن تحريكات المخطط باستخدام Aspose.Slides؟**  
نعم. يمكنك [تصدير العرض التقديمي إلى فيديو](/slides/ar/java/convert-powerpoint-to-video/) مع الحفاظ على التحريكات، وتكوين التوقيتات وإعدادات التصدير الأخرى بحيث يعكس المقطع الناتج تشغيل التحريكات.