---
title: تحريك مخططات PowerPoint في PHP
linktitle: مخططات متحركة
type: docs
weight: 80
url: /ar/php-java/animated-charts/
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
- PHP
- Aspose.Slides
description: "أنشئ مخططات متحركة مذهلة باستخدام Aspose.Slides للـ PHP عبر Java. حسّن العروض التقديمية بصور ديناميكية في ملفات PPT و PPTX — ابدأ الآن."
---

{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java يدعم تحريك عناصر المخطط. يمكن تحريك **Series**، **Categories**، **Series Elements**، **Categories Elements** باستخدام الطريقة [**ISequence**.**addEffect**](https://reference.aspose.com/slides/php-java/aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) واثنين من الـ enums [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectChartMajorGroupingType) و[**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectChartMinorGroupingType).

{{% /alert %}} 

## **تحريك سلسلة المخطط**
إذا كنت ترغب في تحريك سلسلة مخطط، اكتب الشيفرة وفق الخطوات التالية:

1. تحميل عرض تقديمي.
1. الحصول على مرجع كائن المخطط.
1. تحريك السلسلة.
1. كتابة ملف العرض التقديمي إلى القرص.

في المثال أدناه، حركنا سلسلة المخطط.
```php
  # إنشاء فئة Presentation التي تمثل ملف عرض تقديمي
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
إذا كنت ترغب في تحريك فئة مخطط، اكتب الشيفرة وفق الخطوات التالية:

1. تحميل عرض تقديمي.
1. الحصول على مرجع كائن المخطط.
1. تحريك الفئة.
1. كتابة ملف العرض التقديمي إلى القرص.

في المثال أدناه، حركنا فئة المخطط.
```php
  # إنشاء فئة Presentation التي تمثل ملف عرض تقديمي
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


## **تحريك عنصر في السلسلة**
إذا كنت ترغب في تحريك عناصر السلسلة، اكتب الشيفرة وفق الخطوات التالية:

1. تحميل عرض تقديمي.
1. الحصول على مرجع كائن المخطط.
1. تحريك عناصر السلسلة.
1. كتابة ملف العرض التقديمي إلى القرص.

في المثال أدناه، قمنا بتحريك عناصر السلسلة.
```php
  # إنشاء فئة Presentation التي تمثل ملف عرض تقديمي
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


## **تحريك عنصر في الفئة**
إذا كنت ترغب في تحريك عناصر الفئات، اكتب الشيفرة وفق الخطوات التالية:

1. تحميل عرض تقديمي.
1. الحصول على مرجع كائن المخطط.
1. تحريك عناصر الفئات.
1. كتابة ملف العرض التقديمي إلى القرص.

في المثال أدناه، قمنا بتحريك عناصر الفئات.
```php
  # إنشاء فئة Presentation التي تمثل ملف عرض تقديمي
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


## **الأسئلة المتكررة**

**هل يتم دعم أنواع تأثير مختلفة (مثل الدخول، التأكيد، الخروج) للمخططات كما هو الحال مع الأشكال العادية؟**

نعم. يُعامل المخطط كشكل، لذا يدعم أنواع تأثيرات الرسوم المتحركة القياسية، بما في ذلك الدخول، التأكيد، والخروج، مع تحكم كامل عبر جدول زمني للشرائح وتسلسلات الرسوم المتحركة.

**هل يمكن دمج تحريك المخطط مع انتقالات الشرائح؟**

نعم. [Transitions](/slides/ar/php-java/slide-transition/) تُطبق على الشريحة، بينما تُطبق تأثيرات التحريك على العناصر داخل الشريحة. يمكنك استخدامهما معًا في نفس العرض التقديمي والتحكم فيهما بشكل مستقل.

**هل يتم حفظ تحريكات المخطط عند الحفظ إلى PPTX؟**

نعم. عند [save to PPTX](/slides/ar/php-java/save-presentation/)، تُحفظ جميع تأثيرات التحريك وترتيبها لأنّها جزء من نموذج التحريك الأصلي للعرض التقديمي.

**هل يمكن قراءة تحريكات المخطط الموجودة في عرض تقديمي وتعديلها؟**

نعم. توفر API الوصول إلى جدول زمني للشرائح، والتسلسلات، والتأثيرات، مما يسمح لك بفحص تحريكات المخطط الحالية وتعديلها دون الحاجة لإعادة إنشائها من البداية.

**هل يمكن إنشاء فيديو يتضمن تحريكات المخطط باستخدام Aspose.Slides؟**

نعم. يمكنك [export a presentation to video](/slides/ar/php-java/convert-powerpoint-to-video/) مع الحفاظ على التحريكات، وتكوين توقيتات وإعدادات تصدير أخرى بحيث يعكس المقطع الناتج تشغيل التحريكات.