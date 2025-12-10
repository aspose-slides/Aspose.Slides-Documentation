---
title: تحريك مخططات PowerPoint في C++
linktitle: مخططات متحركة
type: docs
weight: 80
url: /ar/cpp/animated-charts/
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
- C++
- Aspose.Slides
description: "أنشئ مخططات متحركة مذهلة في C++ باستخدام Aspose.Slides. عزز العروض التقديمية بصور ديناميكية في ملفات PPT و PPTX—ابدأ الآن."
---

## **تحريك سلسلة الرسم البياني**
If you want to animate a chart series, write the code according to the steps listed below:

1. تحميل عرض تقديمي.
1. الحصول على مرجع كائن الرسم البياني.
1. تحريك السلسلة.
1. كتابة ملف العرض التقديمي إلى القرص.

In the example given below, we animated chart series.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **تحريك عنصر في السلسلة**
If you want to animate series elements, write the code according to the steps listed below:

1. تحميل عرض تقديمي.
1. الحصول على مرجع كائن الرسم البياني.
1. تحريك عناصر السلسلة.
1. كتابة ملف العرض التقديمي إلى القرص.

In the example given below, we have animated series' elements.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeriesElements-AnimatingSeriesElements.cpp" >}}

## **تحريك فئة الرسم البياني**
If you want to animate a chart series, write the code according to the steps listed below:

1. تحميل عرض تقديمي.
1. الحصول على مرجع كائن الرسم البياني.
1. تحريك الفئة.
1. كتابة ملف العرض التقديمي إلى القرص.

In the example given below, we animated chart category.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **تحريك عنصر الفئة**
If you want to animate categories elements, write the code according to the steps listed below:

1. تحميل عرض تقديمي.
1. الحصول على مرجع كائن الرسم البياني.
1. تحريك عناصر الفئات.
1. كتابة ملف العرض التقديمي إلى القرص.

In the example given below, we have animated categories elements.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingCategoriesElements-AnimatingCategoriesElements.cpp" >}}

## **الأسئلة المتكررة**

**هل يتم دعم أنواع التأثير المختلفة (مثل الدخول، والتأكيد، والخروج) للرسوم البيانية كما هو الحال مع الأشكال العادية؟**

Yes. A chart is treated as a shape, so it supports the standard animation effect types, including entrance, emphasis, and exit, with full control via the slide's timeline and animation sequences.

**هل يمكنني دمج تحريك الرسم البياني مع انتقالات الشرائح؟**

Yes. [Transitions](/slides/ar/cpp/slide-transition/) apply to the slide, while animation effects apply to objects on the slide. You can use both together in the same presentation and control them independently.

**هل يتم حفظ تحركات الرسم البياني عند حفظه كملف PPTX؟**

Yes. When you [save to PPTX](/slides/ar/cpp/save-presentation/), all animation effects and their ordering are preserved because they are part of the presentation's native animation model.

**هل يمكنني قراءة تحركات الرسم البياني الموجودة في عرض تقديمي وتعديلها؟**

Yes. The [API](https://reference.aspose.com/slides/cpp/aspose.slides.animation/) provides access to the slide timeline, sequences, and effects, allowing you to inspect existing chart animations and adjust them without recreating everything from scratch.

**هل يمكنني إنشاء فيديو يتضمن تحركات الرسم البياني باستخدام Aspose.Slides؟**

Yes. You can [export a presentation to video](/slides/ar/cpp/convert-powerpoint-to-video/) while preserving animations, configuring timings and other export settings so the resulting clip reflects the animated playback.