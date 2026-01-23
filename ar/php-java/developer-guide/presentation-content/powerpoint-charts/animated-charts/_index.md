---
title: تحريك مخططات PowerPoint في PHP
linktitle: مخططات متحركة
type: docs
weight: 80
url: /ar/php-java/animated-charts/
keywords:
- مخطط
- مخطط متحرك
- تحريك المخططات
- سلسلة المخطط
- فئة المخطط
- عنصر السلسلة
- عنصر الفئة
- إضافة تأثير
- نوع التأثير
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "أنشئ مخططات متحركة مذهلة باستخدام Aspose.Slides لـ PHP عبر Java. عزز العروض التقديمية بمرئيات ديناميكية في ملفات PPT و PPTX — ابدأ الآن."
---

{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java يدعم تحريك عناصر المخطط. يمكن تحريك **السلاسل**، **الفئات**، **عناصر السلسلة**، **عناصر الفئات** باستخدام طريقة [**Sequence::addEffect**](https://reference.aspose.com/slides/php-java/aspose.slides/sequence/#addEffect) واثنين من التعدادات [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectChartMajorGroupingType) و[**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectChartMinorGroupingType).

{{% /alert %}} 

## **تحريك سلسلة المخطط**
إذا كنت تريد تحريك سلسلة مخطط، اكتب الكود وفقًا للخطوات المذكورة أدناه:

1. تحميل عرض تقديمي.
2. الحصول على مرجع كائن المخطط.
3. تحريك السلسلة.
4. كتابة ملف العرض التقديمي إلى القرص.

في المثال التالي، قمنا بتحريك سلسلة المخطط.
```php
  # إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # الحصول على مرجع كائن المخطط
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # تحريك السلسلة
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # كتابة العرض التقديمي المعدل إلى القرص
    $pres->save("AnimatingSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تحريك فئة المخطط**
إذا كنت تريد تحريك فئة مخطط، اكتب الكود وفقًا للخطوات المذكورة أدناه:

1. تحميل عرض تقديمي.
2. الحصول على مرجع كائن المخطط.
3. تحريك الفئة.
4. كتابة ملف العرض التقديمي إلى القرص.

في المثال التالي، قمنا بتحريك فئة المخطط.
```php
  # إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي
  $pres = new Presentation("ExistingChart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $pres->save("Sample_Animation_C.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تحريك عنصر من السلسلة**
إذا كنت تريد تحريك عناصر السلسلة، اكتب الكود وفقًا للخطوات المذكورة أدناه:

1. تحميل عرض تقديمي.
2. الحصول على مرجع كائن المخطط.
3. تحريك عناصر السلسلة.
4. كتابة ملف العرض التقديمي إلى القرص.

في المثال التالي، لقد قمنا بتحريك عناصر السلسلة.
```php
  # إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # الحصول على مرجع كائن المخطط
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # تحريك عناصر السلسلة
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # كتابة ملف العرض التقديمي إلى القرص
    $pres->save("AnimatingSeriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تحريك عنصر من الفئة**
إذا كنت تريد تحريك عناصر الفئات، اكتب الكود وفقًا للخطوات المذكورة أدناه:

1. تحميل عرض تقديمي.
2. الحصول على مرجع كائن المخطط.
3. تحريك عناصر الفئات.
4. كتابة ملف العرض التقديمي إلى القرص.

في المثال التالي، لقد قمنا بتحريك عناصر الفئات.
```php
  # إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # الحصول على مرجع كائن المخطط
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # تحريك عناصر الفئات
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # كتابة ملف العرض التقديمي إلى القرص
    $pres->save("AnimatingCategoriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**هل يتم دعم أنواع التأثير المختلفة (مثل دخول، تأكيد، خروج) للمخطط كما هو الحال مع الأشكال العادية؟**

نعم. يتم اعتبار المخطط ككائن شكل، وبالتالي يدعم أنواع التأثير القياسية للرسوم المتحركة، بما في ذلك الدخول، والتأكيد، والخروج، مع التحكم الكامل عبر جدول زمني للشرائح وتسلسلات الرسوم المتحركة.

**هل يمكنني دمج تحريك المخطط مع انتقالات الشرائح؟**

نعم. [الانتقالات](/slides/ar/php-java/slide-transition/) تُطبق على الشريحة، بينما تُطبق تأثيرات التحريك على الكائنات داخل الشريحة. يمكنك استخدامهما معًا في نفس العرض التقديمي والتحكم فيهما بشكل مستقل.

**هل يتم الحفاظ على تحركات المخطط عند الحفظ إلى PPTX؟**

نعم. عندما تقوم بـ[حفظ إلى PPTX](/slides/ar/php-java/save-presentation/)، يتم الحفاظ على جميع تأثيرات التحريك وتتابعها لأنّها جزء من نموذج التحريك الأصلي للعرض التقديمي.

**هل يمكنني قراءة تحركات المخطط الحالية من عرض تقديمي وتعديلها؟**

نعم. توفر API إمكانية الوصول إلى الجدول الزمني للشرائح، والتسلسلات، والتأثيرات، مما يتيح لك فحص تحركات المخطط الحالية وتعديلها دون الحاجة إلى إعادة إنشاء كل شيء من الصفر.

**هل يمكنني إنتاج فيديو يتضمن تحركات المخطط باستخدام Aspose.Slides؟**

نعم. يمكنك [تصدير العرض التقديمي إلى فيديو](/slides/ar/php-java/convert-powerpoint-to-video/) مع الحفاظ على التحريكات، وتكوين التوقيتات وغيرها من إعدادات التصدير بحيث يعكس المقطع الناتج تشغيل الرسوم المتحركة.