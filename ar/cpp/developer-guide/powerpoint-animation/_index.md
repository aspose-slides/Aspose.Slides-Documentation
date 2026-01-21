---
title: تحسين عروض PowerPoint التقديمية باستخدام الرسوم المتحركة في C++
linktitle: تحريك PowerPoint
type: docs
weight: 150
url: /ar/cpp/powerpoint-animation/
keywords:
- إضافة تحريك
- تحديث التحريك
- تغيير التحريك
- إزالة التحريك
- إدارة التحريك
- التحكم في التحريك
- تأثير التحريك
- تحريك PowerPoint
- خط زمني للتحريك
- تحريك تفاعلي
- تحريك مخصص
- تحريك الأشكال
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
description: "تعرف على كيفية إضافة والتحكم في تأثيرات التحريك المتقدمة في Aspose.Slides لـ C++ لبناء عروض PowerPoint وOpenDocument ديناميكية."
---

نظرًا لأن العروض التقديمية تهدف إلى عرض شيء ما، فإن مظهرها البصري وسلوكها التفاعلي يُؤخذ دائمًا في الاعتبار أثناء إنشائها.

**تحريك PowerPoint** يلعب دورًا مهمًا لجعل العرض جذابًا وممتعًا للمشاهدين. Aspose.Slides للـ C++ يقدم مجموعة واسعة من الخيارات لإضافة تحريك إلى عرض PowerPoint:

- تطبيق أنواع مختلفة من تأثيرات تحريك PowerPoint على الأشكال، والمخططات، والجداول، وكائنات OLE، وعناصر العرض الأخرى.
- استخدام تأثيرات تحريك PowerPoint متعددة على شكل واحد.
- استخدام جدول زمني للتحريك للتحكم في تأثيرات التحريك.
- إنشاء تحريك مخصص.

في Aspose.Slides للـ C++، يمكن تطبيق تأثيرات تحريك مختلفة على الأشكال. ولكل عنصر في الشريحة بما في ذلك النص، والصور، وكائن OLE، والجدول، إلخ يُعتبر شكلًا، مما يعني أنه يمكننا تطبيق تأثير التحريك على كل عنصر في الشريحة.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation) **namespace** يوفّر فئات للعمل مع تحريكات PowerPoint.
## **تأثيرات التحريك**
يدعم Aspose.Slides **أكثر من 150 تأثير تحريك**، بما في ذلك تأثيرات التحريك الأساسية مثل Bounce، PathFootball، تأثير التكبير، وتأثيرات تحريك محددة مثل OLEObjectShow، OLEObjectOpen. يمكنك العثور على قائمة كاملة بتأثيرات التحريك في تعداد [**EffectType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) enumeration.

بالإضافة إلى ذلك، يمكن استخدام هذه التأثيرات التحريكية معًا:
- [ColorEffect](https://reference.aspose.com/slides/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.set_effect)

## **تحريك مخصص**
يمكن إنشاء **تحريكات مخصصة** خاصة بك في Aspose.Slides. يمكن تحقيق ذلك إذا دمجت عدة سلوكيات معًا في تحريك مخصص جديد.

[**Behavior**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.behavior) هو وحدة بناء لأي تأثير تحريك PowerPoint. جميع تأثيرات التحريك هي في الواقع مجموعة من السلوكيات المتكوّنة في استراتيجية واحدة. يمكنك دمج السلوكيات في تحريك مخصص مرة واحدة وإعادة استخدامها في عروض أخرى. إذا أضفت سلوكًا جديدًا إلى تأثير تحريك PowerPoint قياسي - سيصبح تحريكًا مخصصًا آخر. على سبيل المثال، يمكنك إضافة سلوك تكرار إلى تحريك لجعله يتكرر عدة مرات.

[**Animation Point**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.point) هو نقطة يتم فيها تطبيق السلوك.

## **خط زمني للتحريك**
[**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) هي مجموعة من تأثيرات التحريك، تُطبق على شكل محدد.

[**AnimationTimeLine**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.animation_time_line) هي مجموعة من الـ Sequences تُستخدم في شريحة معينة. إنها محرك تحريك موجود منذ PowerPoint 2002. في الإصدارات السابقة من PowerPoint، كان من الصعب إضافة تأثيرات التحريك إلى العرض، وكان ذلك ممكنًا فقط عبر حلول بديلة مختلفة. يأتي الخط الزمني ليحل محل فئة AnimationSettings القديمة ويوفر نموذج كائن أوضح لتحريك PowerPoint. يمكن أن تحتوي شريحة واحدة على **خط زمني واحد فقط** للتحريك.

## **تحريك تفاعلي**
[**EffectTriggerType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) يتيح تعريف إجراءات المستخدم (مثل النقر على زر) التي تجعل تحريكًا معينًا يبدأ. تم إضافة المشغلات فقط في أحدث إصدارات PowerPoint.

## **تحريك الأشكال**
يسمح Aspose.Slides بتطبيق التحريك على الأشكال، التي قد تكون نصًا، أو مستطيلًا، أو خطًا، أو إطارًا، أو كائن OLE، وما إلى ذلك.

{{% alert color="primary" %}} 
اقرأ المزيد [**حول تحريك الأشكال**](/slides/ar/cpp/shape-animation/).
{{% /alert %}}

## **مخططات متحركة**
لإنشاء مخططات متحركة، يجب استخدام نفس الفئات المستخدمة للأشكال. ومع ذلك، يمكن تطبيق تحريك PowerPoint فقط على فئات المخطط أو سلاسل المخطط. يمكنك أيضًا تطبيق تأثير التحريك على عنصر الفئة أو عنصر السلسلة.

{{% alert color="primary" %}} 
اقرأ المزيد [**حول المخططات المتحركة**](/slides/ar/cpp/animated-charts/).
{{% /alert %}}

## **نص متحرك**
بالإضافة إلى النص المتحرك، يمكن أيضًا تطبيق التحريك على فقرة.

{{% alert color="primary" %}} 
اقرأ المزيد [**حول النص المتحرك**](/slides/ar/cpp/animated-text/).
{{% /alert %}}

## **الأسئلة المتكررة**

**هل سيُحافظ على التحريكات عند التصدير إلى PDF؟**

لا. PDF هو تنسيق ثابت، لذا لا تُشغل التحريكات و[انتقالات الشرائح](/slides/ar/cpp/slide-transition/). إذا كنت بحاجة إلى حركة، صدِّر إلى [HTML5](/slides/ar/cpp/export-to-html5/)، [GIF متحرك](/slides/ar/cpp/convert-powerpoint-to-animated-gif/)، أو [فيديو](/slides/ar/cpp/convert-powerpoint-to-video/) بدلاً من ذلك.

**هل يمكنني تحويل عرض تقديمي متحرك إلى فيديو والتحكم في معدل الإطارات وحجم الإطار؟**

نعم. يمكنك [تصدير العرض كإطارات](/slides/ar/cpp/convert-powerpoint-to-video/) وتشفيرها إلى فيديو (مثلاً باستخدام ffmpeg)، مع اختيار معدل الإطارات (FPS) والدقة. يتم تشغيل التحريكات وانتقالات الشرائح أثناء التصدير.

**هل ستظل التحريكات سليمة عند العمل مع ODP (ليس فقط PPTX)؟**

تُدعم صيغ PPT وPPTX وODP لل[قراءة](/slides/ar/cpp/open-presentation/) و[كتابة](/slides/ar/cpp/save-presentation/)، لكن اختلافات الصيغ قد تجعل بعض التأثيرات تظهر أو تتصرف بشكل مختلف قليلاً. يُنصح بالتحقق من الحالات الحرجة باستخدام عينات حقيقية.