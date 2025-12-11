---
title: "تعزيز عروض PowerPoint التقديمية بالرسوم المتحركة على Android"
linktitle: "الرسوم المتحركة في PowerPoint"
type: docs
weight: 150
url: /ar/androidjava/powerpoint-animation/
keywords:
- إضافة الرسوم المتحركة
- تحديث الرسوم المتحركة
- تغيير الرسوم المتحركة
- إزالة الرسوم المتحركة
- إدارة الرسوم المتحركة
- التحكم في الرسوم المتحركة
- تأثير الرسوم المتحركة
- رسوم متحركة لبرنامج PowerPoint
- خط زمن الرسوم المتحركة
- الرسوم المتحركة التفاعلية
- رسوم متحركة مخصصة
- رسوم متحركة للأشكال
- مخطط متحرك
- نص متحرك
- شكل متحرك
- كائن OLE متحرك
- صورة متحركة
- جدول متحرك
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "استكشف قدرات Aspose.Slides للـ Android عبر Java في معالجة الرسوم المتحركة لملفات PowerPoint. يوفر هذا الملخص العام أبرز الميزات."
---

نظرًا لأن العروض التقديمية مصممة لتقديم شيء ما، فإن مظهرها البصري وسلوكها التفاعلي يُؤخذان دائمًا في الاعتبار أثناء إنشائها.

**PowerPoint animation** يلعب دورًا مهمًا لجعل العرض جذابًا وممتعًا للمشاهدين. يوفر Aspose.Slides for Android via Java مجموعة واسعة من الخيارات لإضافة الرسوم المتحركة إلى عرض PowerPoint:

- تطبيق أنواع مختلفة من تأثيرات الرسوم المتحركة على الأشكال والمخططات والجداول وكائنات OLE والعناصر الأخرى في العرض.
- استخدام تأثيرات رسومية متعددة على شكل واحد.
- استخدام خط الزمن للرسوم المتحركة للتحكم في التأثيرات.
- إنشاء رسومات متحركة مخصصة.

في Aspose.Slides for Android via Java، يمكن تطبيق تأثيرات رسومية مختلفة على الأشكال. بما أن كل عنصر في الشريحة بما في ذلك النصوص والصور وكائن OLE والجدول وما إلى ذلك يُعتبر شكلًا، فهذا يعني أنه يمكننا تطبيق تأثير الرسوم المتحركة على كل عنصر في الشريحة.

## **تأثيرات الرسوم المتحركة**
يدعم Aspose.Slides **150+ تأثيرًا للرسوم المتحركة**، بما في ذلك التأثيرات الأساسية مثل Bounce وPathFootball وتأثير التكبير، وتأثيرات رسومية محددة مثل OLEObjectShow وOLEObjectOpen. يمكنك العثور على قائمة كاملة لتأثيرات الرسوم المتحركة في [**EffectType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype/) enumeration.

بالإضافة إلى ذلك، يمكن استخدام هذه التأثيرات بالاشتراك مع:

- [ColorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SetEffect)

## **رسوم متحركة مخصصة**
يمكن إنشاء **رسوم متحركة مخصصة** خاصة بك في Aspose.Slides. يمكن تحقيق ذلك بدمج سلوكيات متعددة معًا في رسم متحرك مخصص جديد.

[**Behavior**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Behavior) هو وحدة بناء لأي تأثير رسوم متحركة في PowerPoint. جميع تأثيرات الرسوم المتحركة هي في الواقع مجموعة من السلوكيات المجمعة في استراتيجية واحدة. يمكنك دمج السلوكيات في رسم متحرك مخصص مرة واحدة وإعادة استخدامها في عروض تقديمية أخرى. إذا أضفت سلوكًا جديدًا إلى تأثير رسوم متحركة قياسي في PowerPoint - سيصبح رسمًا متحركًا مخصصًا آخر. على سبيل المثال، يمكنك إضافة سلوك تكرار إلى رسم متحرك لجعله يتكرر عدة مرات.

[**Animation Point**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Point) هو النقطة التي يجب تطبيق السلوك فيها.

## **خط زمن الرسوم المتحركة**
[**Sequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) هو مجموعة من تأثيرات الرسوم المتحركة، تُطبق على شكل معين.

[**Timeline**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AnimationTimeLine) هو مجموعة من الـSequences تُستخدم في شريحة معينة. يُمثل محرك الرسوم المتحركة منذ PowerPoint 2002. في إصدارات PowerPoint السابقة، كان من الصعب إضافة تأثيرات الرسوم المتحركة إلى العرض، وكان يمكن تحقيق ذلك فقط عبر حلول بديلة مختلفة. يأتي الـTimeline ليحل محل فئة AnimationSettings القديمة ويوفر نموذج كائن أوضح للرسوم المتحركة في PowerPoint. يمكن أن تحتوي شريحة واحدة على **خط زمن واحد** فقط.

## **رسوم متحركة تفاعلية**
[**Trigger**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectTriggerType) يسمح بتعريف إجراءات المستخدم (مثل النقر على زر) التي ستجعل رسمًا متحركًا معينًا يبدأ. تم إضافة المشغلات فقط في أحدث إصدارات PowerPoint.

## **رسوم متحركة للأشكال**
يسمح Aspose.Slides بتطبيق الرسوم المتحركة على الأشكال، والتي قد تكون نصًا أو مستطيلًا أو خطًا أو إطارًا أو كائن OLE، إلخ.

{{% alert color="primary" %}} 
اقرأ المزيد [**About Shape Animation**](/slides/ar/androidjava/shape-animation/).
{{% /alert %}}

## **مخططات متحركة**
لإنشاء مخططات متحركة، يجب استخدام نفس الفئات المستخدمة للأشكال. ومع ذلك، يمكن استخدام الرسوم المتحركة في PowerPoint فقط على فئات المخطط أو سلاسل المخطط. يمكنك أيضًا تطبيق تأثير الرسوم المتحركة على عنصر فئة أو عنصر سلسلة.

{{% alert color="primary" %}} 
اقرأ المزيد [**About Animated Charts**](/slides/ar/androidjava/animated-charts/).
{{% /alert %}}

## **نص متحرك**
إلى جانب النص المتحرك، يمكن أيضًا تطبيق الرسوم المتحركة على فقرة.

{{% alert color="primary" %}} 
اقرأ المزيد [**About Animated Text**](/slides/ar/androidjava/animated-text/).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل سيتم الاحتفاظ بالرسوم المتحركة عند التصدير إلى PDF؟**

لا. PDF هو تنسيق ثابت، لذلك لا تُشغل الرسوم المتحركة و[انتقالات الشرائح](/slides/ar/androidjava/slide-transition/). إذا كنت تحتاج إلى حركة، صدّر إلى [HTML5](/slides/ar/androidjava/export-to-html5/)، [GIF متحرك](/slides/ar/androidjava/convert-powerpoint-to-animated-gif/)، أو [فيديو](/slides/ar/androidjava/convert-powerpoint-to-video/) بدلاً من ذلك.

**هل يمكنني تحويل عرض تقديمي متحرك إلى فيديو والتحكم في معدل الإطارات وحجم الإطار؟**

نعم. يمكنك [تصيير العرض كإطارات](/slides/ar/androidjava/convert-powerpoint-to-video/) وترميزها إلى فيديو (مثلاً باستخدام ffmpeg)، مع اختيار FPS والدقة. تُشغل الرسوم المتحركة وانتقالات الشرائح أثناء التصيير.

**هل ستظل الرسوم المتحركة سليمة عند العمل مع ODP (ليس فقط PPTX)؟**

تُدعم صيغ PPT وPPTX وODP لل[القراءة](/slides/ar/androidjava/open-presentation/) و[الكتابة](/slides/ar/androidjava/save-presentation/)، لكن اختلافات الصيغ قد تجعل بعض التأثيرات تظهر أو تتصرف بشكل مختلف قليلًا. تحقق من الحالات الحرجة باستخدام عينات فعلية.