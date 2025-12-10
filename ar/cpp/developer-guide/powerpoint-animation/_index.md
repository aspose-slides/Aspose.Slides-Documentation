---
title: تحسين عروض PowerPoint باستخدام الرسوم المتحركة في C++
linktitle: رسوم متحركة PowerPoint
type: docs
weight: 150
url: /ar/cpp/powerpoint-animation/
keywords:
- إضافة رسوم متحركة
- تحديث رسوم متحركة
- تغيير رسوم متحركة
- إزالة رسوم متحركة
- إدارة رسوم متحركة
- التحكم في رسوم متحركة
- تأثير الرسوم المتحركة
- رسوم متحركة PowerPoint
- خط زمني للرسوم المتحركة
- رسوم متحركة تفاعلية
- رسوم متحركة مخصصة
- رسوم متحركة الشكل
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
description: "تعلم كيفية إضافة والتحكم في تأثيرات الرسوم المتحركة المتقدمة في Aspose.Slides for C++ لإنشاء عروض PowerPoint وOpenDocument ديناميكية."
---

نظرًا لأن العروض التقديمية تهدف إلى عرض شيء ما، فإن مظهرها البصري وسلوكها التفاعلي يُؤخذان دائمًا في الاعتبار أثناء إنشائها.

**PowerPoint animation** يلعب دورًا مهمًا لجعل العرض جذابًا وملفتًا للانتباه. Aspose.Slides for C++ يقدم مجموعة واسعة من الخيارات لإضافة الرسوم المتحركة إلى عرض PowerPoint:

- تطبيق أنواع مختلفة من تأثيرات الرسوم المتحركة في PowerPoint على الأشكال، المخططات، الجداول، كائنات OLE وغيرها من عناصر العرض.
- استخدام تأثيرات رسومية متعددة على شكل واحد.
- استخدام خط زمني للرسوم المتحركة للتحكم في تأثيرات الرسوم.
- إنشاء رسوم متحركة مخصصة.

في Aspose.Slides for C++، يمكن تطبيق تأثيرات رسومية مختلفة على الأشكال. نظرًا لأن كل عنصر على الشريحة بما في ذلك النصوص، الصور، كائن OLE، الجداول إلخ يُعتبر شكلًا، فهذا يعني أنه يمكننا تطبيق تأثير الرسوم المتحركة على كل عنصر من عناصر الشريحة.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation) **namespace** يوفر فئات للعمل مع رسوم متحركة في PowerPoint.
## **Animation Effects**
Aspose.Slides يدعم **150+ animation effects**، بما في ذلك تأثيرات أساسية مثل Bounce وPathFootball وZoom effect وتاثيرات خاصة مثل OLEObjectShow وOLEObjectOpen. يمكنك العثور على قائمة كاملة لتأثيرات الرسوم المتحركة في [**EffectType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31)enumeration.

بالإضافة إلى ذلك، يمكن الجمع بين هذه التأثيرات مع:

- [ColorEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.color_effect/t)
- [CommandEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.set_effect)

## **Custom Animation**
من الممكن إنشاء **رسوم متحركة مخصصة** في Aspose.Slides. يمكن تحقيق ذلك إذا قمت بدمج سلوكيات متعددة معًا في رسم متحرك مخصص جديد.

[**Behavior**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.behavior) هو وحدة بناء لأي تأثير رسوم متحركة في PowerPoint. جميع تأثيرات الرسوم المتحركة هي في الواقع مجموعة من السلوكيات المجمعة في استراتيجية واحدة. يمكنك دمج السلوكيات في رسم متحرك مخصص مرة واحدة وإعادة استخدامها في عروض تقديمية أخرى. إذا أضفت سلوكًا جديدًا إلى تأثير رسوم متحركة قياسي في PowerPoint - سيصبح رسمًا متحركًا مخصصًا آخر. على سبيل المثال، يمكنك إضافة سلوك تكرار إلىرسوم متحركة لجعلها تتكرر عدة مرات.

[**Animation Point**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.point) هو النقطة التي يجب تطبيق السلوك عندها.

## **Animation Time Line**
[**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) هي مجموعة من تأثيرات الرسوم المتحركة، تُطبّق على شكل محدد.

[**AnimationTimeLine**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.animation_time_line) هي مجموعة من الـSequences تُستخدم في شريحة معينة. تم تمثيله كمحرك رسوم متحركة منذ PowerPoint 2002. في إصدارات PowerPoint السابقة، كان من الصعب إضافة تأثيرات رسومية إلى العرض، ولم يُتحقق ذلك إلا عبر حلول بديلة مختلفة. يأتي الخط الزمني ليحل محل فئة AnimationSettings القديمة ويقدم نموذج كائن أوضح لرسوم متحركة PowerPoint. يمكن لشريحة أن تحتوي على **خط زمني للرسوم المتحركة** واحد فقط.

## **Interactive Animation**
[**EffectTriggerType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) يسمح بتعريف إجراءات المستخدم (مثل النقر على زر) التي ستجعل رسمًا متحركًا معينًا يبدأ. تم إضافة المشغلات فقط في أحدث إصدارات PowerPoint.

## **Shape Animation**
Aspose.Slides يسمح بتطبيق الرسوم المتحركة على الأشكال، والتي يمكن أن تكون نصًا، مستطيلًا، خطًا، إطارًا، كائن OLE، إلخ.

{{% alert color="primary" %}} 
اقرأ المزيد [**About Shape Animation**](/slides/ar/cpp/shape-animation/).
{{% /alert %}}

## **Animated Charts**
لإنشاء مخططات متحركة، يجب استخدام نفس الفئات المستخدمة للأشكال. ومع ذلك، يمكن تطبيق رسوم متحركة PowerPoint فقط على فئات المخطط أو سلاسل المخطط. يمكنك أيضًا تطبيق تأثير الرسوم المتحركة على عنصر فئة أو عنصر سلسلة.

{{% alert color="primary" %}} 
اقرأ المزيد [**About Animated Charts**](/slides/ar/cpp/animated-charts/).
{{% /alert %}}

## **Animated Text**
بالإضافة إلى النص المتحرك، يمكن أيضًا تطبيق الرسوم المتحركة على فقرة.

{{% alert color="primary" %}} 
اقرأ المزيد [**About Animated Text**](/slides/ar/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

**Will animations be preserved when exporting to PDF?**

لا. PDF هو تنسيق ثابت، لذا الرسوم المتحركة و[slide transitions](/slides/ar/cpp/slide-transition/) لا تُشغل. إذا كنت بحاجة إلى حركة، صدّر إلى [HTML5](/slides/ar/cpp/export-to-html5/)، [animated GIF](/slides/ar/cpp/convert-powerpoint-to-animated-gif/)، أو [video](/slides/ar/cpp/convert-powerpoint-to-video/) بدلاً من ذلك.

**Can I turn an animated presentation into a video and control the frame rate and frame size?**

نعم. يمكنك [render the presentation as frames](/slides/ar/cpp/convert-powerpoint-to-video/) وترميزها إلى فيديو (مثلاً عبر ffmpeg)، مع اختيار معدل الإطارات والدقة. تُشغل الرسوم المتحركة والانتقالات أثناء عملية التصيير.

**Will animations remain intact when working with ODP (not just PPTX)?**

تُدعم صيغ PPT وPPTX وODP لل[reading](/slides/ar/cpp/open-presentation/) و[writing](/slides/ar/cpp/save-presentation/)، لكن اختلاف الصيغ قد يؤدي إلى ظهور بعض التأثيرات أو سلوكها بشكل مختلف قليلاً. يُنصَح بالتحقق من الحالات الحرجة باستخدام عينات واقعية.