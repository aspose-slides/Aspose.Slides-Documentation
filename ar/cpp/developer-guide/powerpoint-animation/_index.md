---
title: تحسين عروض PowerPoint التقديمية بالرسوم المتحركة في C++
linktitle: رسوم متحركة PowerPoint
type: docs
weight: 150
url: /ar/cpp/powerpoint-animation/
keywords:
- إضافة رسوم متحركة
- تحديث الرسوم المتحركة
- تغيير الرسوم المتحركة
- إزالة الرسوم المتحركة
- إدارة الرسوم المتحركة
- التحكم في الرسوم المتحركة
- تأثير الرسوم المتحركة
- رسوم متحركة PowerPoint
- خط زمني للرسوم المتحركة
- رسوم متحركة تفاعلية
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
- C++
- Aspose.Slides
description: "تعرف على كيفية إضافة والتحكم في تأثيرات الرسوم المتحركة المتقدمة في Aspose.Slides for C++ لإنشاء عروض PowerPoint وOpenDocument ديناميكية."
---
## **المقدمة**

نظرًا لأن العروض التقديمية تهدف إلى عرض شيء ما، فإن المظهر البصري والسلوك التفاعلي لها يُؤخذ دائمًا في الاعتبار أثناء إنشائها.

**PowerPoint animation** يلعب دورًا مهمًا لجعل العرض جذابًا ومثيرًا للانتباه للمشاهدين. تقدم Aspose.Slides for C++ مجموعة واسعة من الخيارات لإضافة رسوم متحركة إلى عرض PowerPoint:

- تطبيق أنواع مختلفة من تأثيرات رسوم متحركة PowerPoint على الأشكال والرسوم البيانية والجداول وكائنات OLE وعناصر العرض الأخرى.
- استخدام تأثيرات رسوم متحركة PowerPoint متعددة على شكل واحد.
- استخدام مخطط زمني للرسوم المتحركة للتحكم في تأثيرات الرسوم المتحركة.
- إنشاء رسوم متحركة مخصصة.

في Aspose.Slides for C++، يمكن تطبيق تأثيرات رسوم متحركة مختلفة على الأشكال. بما أن كل عنصر في الشريحة بما في ذلك النصوص والصور وكائن OLE والجداول وما إلى ذلك يُعتبر شكلاً، فهذا يعني أنه يمكننا تطبيق تأثير الرسوم المتحركة على كل عنصر في الشريحة.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/ar/cpp/namespace/aspose.slides.animation) **namespace** يوفر فئات للعمل مع رسوم PowerPoint المتحركة.

## **تأثيرات الرسوم المتحركة**

يدعم Aspose.Slides **أكثر من 150 تأثيرًا للرسوم المتحركة**، بما في ذلك التأثيرات الأساسية مثل Bounce وPathFootball وتأثير Zoom، وتأثيرات محددة مثل OLEObjectShow و OLEObjectOpen. يمكنك العثور على قائمة كاملة لتأثيرات الرسوم المتحركة في تعداد [**EffectType**](https://reference.aspose.com/slides/ar/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31).

بالإضافة إلى ذلك، يمكن استخدام هذه التأثيرات المتحركة معًا:

- [ColorEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.animation.set_effect)

## **الرسوم المتحركة المخصصة**

يمكن إنشاء **رسوم متحركة مخصصة** في Aspose.Slides.

يمكن تحقيق ذلك إذا جمعت عدة سلوكيات معًا في رسوم متحركة مخصصة جديدة.

[**Behavior**](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.animation.behavior) هي وحدة بناء لأي تأثير رسوم متحركة في PowerPoint. جميع تأثيرات الرسوم المتحركة هي في الواقع مجموعة من السلوكيات المكونة في استراتيجية واحدة. يمكنك دمج السلوكيات في رسوم متحركة مخصصة مرة واحدة وإعادة استخدامها في عروض تقديمية أخرى. إذا أضفت سلوكًا جديدًا إلى تأثير رسوم متحركة PowerPoint قياسي - سيصبح ذلك رسومًا متحركة مخصصة أخرى. على سبيل المثال، يمكنك إضافة سلوك تكرار إلى رسوم متحركة لجعلها تتكرر عدة مرات.

[**Animation Point**](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.animation.point) هي نقطة يتم فيها تطبيق السلوك.

## **خط الزمن للرسوم المتحركة**

[**Sequence**](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.animation.sequence) هي مجموعة من تأثيرات الرسوم المتحركة، تُطبق على شكل معين.

[**AnimationTimeLine**](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.animation.animation_time_line) هي مجموعة من الـSequences تُستخدم في شريحة محددة. إنها محرك رسوم متحركة موجود منذ PowerPoint 2002. في إصدارات PowerPoint السابقة، كان من الصعب إضافة تأثيرات رسوم متحركة إلى العرض، وكان لا يمكن تحقيق ذلك إلا بطرق مختلفة. يأتي المخطط الزمني ليحل محل فئة AnimationSettings القديمة ويوفر نموذج كائن أوضح للرسوم المتحركة في PowerPoint. يمكن أن تحتوي الشريحة الواحدة على مخطط زمني واحد فقط للرسوم المتحركة.

## **الرسوم المتحركة التفاعلية**

[**EffectTriggerType**](https://reference.aspose.com/slides/ar/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) يسمح بتعريف إجراءات المستخدم (مثل النقر على زر) التي ستُشغّل رسومًا متحركة معينة. تم إضافة المشغلات فقط في أحدث إصدار من PowerPoint.

## **رسوم متحركة للأشكال**

يسمح Aspose.Slides بتطبيق الرسوم المتحركة على الأشكال، والتي قد تكون في الواقع نصًا أو مستطيلًا أو خطًا أو إطارًا أو كائن OLE، إلخ.

{{% alert color="info" %}} 
اقرأ المزيد [**حول رسوم متحركة الأشكال**](/slides/ar/cpp/shape-animation/).
{{% /alert %}}

## **الرسوم البيانية المتحركة**

لإنشاء رسوم بيانية متحركة، يجب استخدام نفس الفئات المستخدمة للأشكال. ومع ذلك، يمكن استخدام رسوم PowerPoint المتحركة فقط على فئات الرسم البياني أو سلاسل الرسم البياني. يمكنك أيضًا تطبيق تأثير الرسوم المتحركة على عنصر فئة أو عنصر سلسلة.

{{% alert color="info" %}} 
اقرأ المزيد [**حول الرسوم البيانية المتحركة**](/slides/ar/cpp/animated-charts/).
{{% /alert %}}

## **النص المتحرك**

بالإضافة إلى النص المتحرك، يمكن أيضًا تطبيق الرسوم المتحركة على فقرة.

{{% alert color="info" %}} 
اقرأ المزيد [**حول النص المتحرك**](/slides/ar/cpp/animated-text/).
{{% /alert %}}

## **الأسئلة الشائعة**

### هل ستُحافظ على الرسوم المتحركة عند التصدير إلى PDF؟

لا. PDF هو تنسيق ثابت، لذلك لا تُشغل الرسوم المتحركة و[انتقالات الشرائح](/slides/ar/cpp/slide-transition/). إذا كنت بحاجة إلى الحركة، صدّر إلى [HTML5](/slides/ar/cpp/export-to-html5/)، أو [GIF متحرك](/slides/ar/cpp/convert-powerpoint-to-animated-gif/)، أو [فيديو](/slides/ar/cpp/convert-powerpoint-to-video/) بدلاً من ذلك.

### هل يمكنني تحويل عرض متحرك إلى فيديو والتحكم في معدل الإطارات وحجم الإطار؟

نعم. يمكنك [تصدير العرض كإطارات](/slides/ar/cpp/convert-powerpoint-to-video/) وترميزها إلى فيديو (مثلاً باستخدام ffmpeg)، مع اختيار عدد الإطارات في الثانية (FPS) والدقة. تُشغل الرسوم المتحركة وانتقالات الشرائح أثناء التصدير.

### هل ستبقى الرسوم المتحركة سليمة عند العمل مع ODP (ليس فقط PPTX)؟

يُدعم PPT وPPTX وODP لل[قراءة](/slides/ar/cpp/open-presentation/) و[كتابة](/slides/ar/cpp/save-presentation/)، ولكن الاختلافات في التنسيق قد تجعل بعض التأثيرات تظهر أو تتصرف بشكل مختلف قليلاً. يجب التحقق من الحالات الحرجة باستخدام عينات حقيقية.