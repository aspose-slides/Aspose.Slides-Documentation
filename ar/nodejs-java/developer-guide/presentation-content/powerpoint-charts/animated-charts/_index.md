---
title: المخططات المتحركة
type: docs
weight: 80
url: /ar/nodejs-java/animated-charts/
---

{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java يدعم تحريك عناصر المخطط. يمكن تحريك **السلاسل**، **الفئات**، **عناصر السلسلة**، **عناصر الفئات** باستخدام طريقة [**Sequence**.**addEffect**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence#addEffect-aspose.slides.IChart-int-int-int-int-int-) واثنين من القيم enum [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EffectChartMajorGroupingType) و[**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EffectChartMinorGroupingType).

{{% /alert %}} 

## **تحريك سلاسل المخطط**
إذا أردت تحريك سلسلة مخطط، اكتب الكود وفق الخطوات التالية:

1. تحميل عرض تقديمي.
1. الحصول على مرجع كائن المخطط.
1. تحريك السلسلة.
1. كتابة ملف العرض التقديمي إلى القرص.

في المثال أدناه، قمنا بتحريك سلاسل المخطط.
```javascript
// إنشاء كائن Presentation الذي يمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // الحصول على مرجع كائن المخطط
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // تحريك السلسلة
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // كتابة العرض التقديمي المعدل إلى القرص
    pres.save("AnimatingSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تحريك فئة المخطط**
إذا أردت تحريك فئة مخطط، اكتب الكود وفق الخطوات التالية:

1. تحميل عرض تقديمي.
1. الحصول على مرجع كائن المخطط.
1. تحريك الفئة.
1. كتابة ملف العرض التقديمي إلى القرص.

في المثال أدناه، قمنا بتحريك فئة المخطط.
```javascript
// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    pres.save("Sample_Animation_C.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تحريك عنصر السلسلة**
إذا أردت تحريك عناصر السلسلة، اكتب الكود وفق الخطوات التالية:

1. تحميل عرض تقديمي.
1. الحصول على مرجع كائن المخطط.
1. تحريك عناصر السلسلة.
1. كتابة ملف العرض التقديمي إلى القرص.

في المثال أدناه، قمنا بتحريك عناصر السلسلة.
```javascript
// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // الحصول على مرجع كائن المخطط
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // تحريك عناصر السلسلة
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // كتابة ملف العرض التقديمي إلى القرص
    pres.save("AnimatingSeriesElements_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تحريك عنصر الفئة**
إذا أردت تحريك عناصر الفئات، اكتب الكود وفق الخطوات التالية:

1. تحميل عرض تقديمي.
1. الحصول على مرجع كائن المخطط.
1. تحريك عناصر الفئات.
1. كتابة ملف العرض التقديمي إلى القرص.

في المثال أدناه، قمنا بتحريك عناصر الفئات.
```javascript
// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // الحصول على مرجع كائن المخطط
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // تحريك عناصر الفئات
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // كتابة ملف العرض التقديمي إلى القرص
    pres.save("AnimatingCategoriesElements_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة الشائعة**

**هل يتم دعم أنواع التأثير المختلفة (مثل الدخول، التأكيد، الخروج) للمخططات كما هو الحال مع الأشكال العادية؟**

نعم. يُعامل المخطط كشكل، لذا يدعم أنواع تأثيرات الرسوم المتحركة القياسية، بما في ذلك الدخول، التأكيد، والخروج، مع تحكم كامل عبر خط زمني للشريحة وتسلسلات الرسوم المتحركة.

**هل يمكن الجمع بين تحريك المخطط وانتقالات الشرائح؟**

نعم. [Transitions](/slides/ar/nodejs-java/slide-transition/) تُطبق على الشريحة، بينما تُطبق تأثيرات الرسوم المتحركة على الكائنات داخل الشريحة. يمكنك استخدام كليهما معًا في نفس العرض التقديمي والتحكم فيهما بشكل مستقل.

**هل يتم الحفاظ على تحريكات المخطط عند حفظه كملف PPTX؟**

نعم. عندما تقوم [save to PPTX](/slides/ar/nodejs-java/save-presentation/)، تُحافظ جميع تأثيرات الرسوم المتحركة وترتيبها لأنها جزء من نموذج الرسوم المتحركة الأصلي للعرض التقديمي.

**هل يمكنني قراءة تحريكات المخطط الموجودة في عرض تقديمي وتعديلها؟**

نعم. تُوفر الواجهة البرمجية الوصول إلى خط زمني الشريحة، التسلسلات، والتأثيرات، مما يتيح لك فحص تحريكات المخطط الحالية وتعديلها دون الحاجة لإعادة إنشائها من الصفر.

**هل يمكنني إنتاج فيديو يتضمن تحريكات المخطط باستخدام Aspose.Slides؟**

نعم. يمكنك [export a presentation to video](/slides/ar/nodejs-java/convert-powerpoint-to-video/) مع الحفاظ على التحريكات، وضبط التوقيتات وإعدادات التصدير الأخرى بحيث يعكس المقطع النهائي تشغيل الرسوم المتحركة.