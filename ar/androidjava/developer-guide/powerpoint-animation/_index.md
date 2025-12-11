---
title: تعزيز عروض PowerPoint التقديمية بالحركات على Android
linktitle: حركة PowerPoint
type: docs
weight: 150
url: /ar/androidjava/powerpoint-animation/
keywords:
- إضافة حركة
- تحديث الحركة
- تغيير الحركة
- إزالة الحركة
- إدارة الحركة
- التحكم بالحركة
- تأثير الحركة
- حركة PowerPoint
- خط زمني للحركة
- حركة تفاعلية
- حركة مخصصة
- حركة الشكل
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
description: "استكشف إمكانيات Aspose.Slides لنظام Android عبر Java في معالجة حركات PowerPoint. يقدم هذا الملخص العام نظرة على الميزات الرئيسية."
---

نظرًا لأن العروض التقديمية تهدف إلى عرض شيء ما، فإن مظهرها البصري وسلوكها التفاعلي يُؤخذ دائمًا في الاعتبار أثناء إنشائها.

**PowerPoint animation** يلعب دورًا مهمًا لجعل العرض التقديمي جذابًا وملفتًا للانتباه للمتلقين. تقدم Aspose.Slides for Android عبر Java مجموعة واسعة من الخيارات لإضافة حركة إلى عروض PowerPoint:

- تطبيق أنواع مختلفة من تأثيرات حركة PowerPoint على الأشكال، المخططات، الجداول، كائنات OLE وغيرها من عناصر العرض.
- استخدام تأثيرات حركة PowerPoint متعددة على شكل واحد.
- استخدام جدول زمني للحركة للتحكم في تأثيرات الحركة.
- إنشاء حركة مخصصة.

في Aspose.Slides for Android عبر Java، يمكن تطبيق تأثيرات حركية مختلفة على الأشكال. بما أن كل عنصر على الشريحة بما في ذلك النصوص، الصور، كائن OLE، الجداول وما إلى ذلك يُعتبر شكلاً، فهذا يعني أنه يمكننا تطبيق تأثيرات حركة على كل عنصر في الشريحة.

## **تأثيرات الحركة**
يدعم Aspose.Slides **أكثر من 150 تأثير حركة**، بما في ذلك تأثيرات الحركة الأساسية مثل Bounce، PathFootball، تأثير التكبير وغيرها، وكذلك تأثيرات حركة محددة مثل OLEObjectShow و OLEObjectOpen. يمكنك العثور على قائمة كاملة لتأثيرات الحركة في تعداد [**EffectType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype/).

بالإضافة إلى ذلك، يمكن دمج هذه التأثيرات الحركية مع بعضها:

- [ColorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SetEffect)

## **حركة مخصصة**
يمكنك إنشاء **حركات مخصصة** خاصة بك في Aspose.Slides. يمكن تحقيق ذلك بدمج سلوكيات متعددة معًا في حركة مخصصة جديدة.

[**Behavior**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Behavior) هو وحدة بناء لأي تأثير حركة PowerPoint. جميع تأثيرات الحركة هي في الواقع مجموعة من السلوكيات المكوَّنة في استراتيجية واحدة. يمكنك دمج السلوكيات في حركة مخصصة مرة واحدة وإعادة استخدامها في عروض تقديمية أخرى. إذا أضفت سلوكًا جديدًا إلى تأثير حركة PowerPoint القياسي - سيصبح ذلك حركة مخصصة أخرى. على سبيل المثال، يمكنك إضافة سلوك تكرار إلى حركة لجعلها تتكرر عدة مرات.

[**Animation Point**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Point) هو النقطة التي يجب تطبيق السلوك فيها.

## **خط زمني للحركة**
[**Sequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) هي مجموعة من تأثيرات الحركة، تُطبق على شكل محدد.

[**Timeline**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AnimationTimeLine) هي مجموعة من الـ Sequences تُستخدم في شريحة معينة. إنها محرك حركة موجود منذ PowerPoint 2002. في إصدارات PowerPoint السابقة، كان من الصعب إضافة تأثيرات حركة إلى العرض التقديمي، وكان ذلك ممكنًا فقط عبر حلول بديلة مختلفة. يأتي الـ Timeline ليحل محل فئة AnimationSettings القديمة ويوفر نموذج كائن أوضح لحركة PowerPoint. يمكن أن تحتوي الشريحة على **خط زمني واحد** فقط للحركة.

## **حركة تفاعلية**
[**Trigger**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectTriggerType) يسمح بتحديد إجراءات المستخدم (مثل النقر على زر)، التي تجعل حركة معينة تبدأ. تم إضافة الـ Triggers فقط في أحدث إصدارات PowerPoint.

## **حركة الأشكال**
تتيح Aspose.Slides تطبيق الحركة على الأشكال، والتي قد تكون نصًا، مستطيلًا، خطًا، إطارًا، كائن OLE، وغيرها.

{{% alert color="primary" %}} 
اقرأ المزيد [**حول حركة الأشكال**](/slides/ar/androidjava/shape-animation/).
{{% /alert %}}

## **مخططات متحركة**
لإنشاء مخططات متحركة، يجب استخدام جميع الفئات نفسها كما هو الحال مع الأشكال. ومع ذلك، يمكن استخدام حركة PowerPoint فقط على فئات المخطط أو سلاسل المخطط. يمكنك أيضًا تطبيق تأثير حركة على عنصر فئة أو عنصر سلسلة.

{{% alert color="primary" %}} 
اقرأ المزيد [**حول المخططات المتحركة**](/slides/ar/androidjava/animated-charts/).
{{% /alert %}}

## **نص متحرك**
بالإضافة إلى النص المتحرك، يمكن أيضًا تطبيق الحركة على فقرة.

{{% alert color="primary" %}} 
اقرأ المزيد [**حول النص المتحرك**](/slides/ar/androidjava/animated-text/).
{{% /alert %}}

## **الأسئلة المتكررة**

**هل سيتم الحفاظ على الحركات عند التصدير إلى PDF؟**
لا. PDF هو تنسيق ثابت، لذلك لا تُشغل الحركات و[انتقالات الشرائح](/slides/ar/androidjava/slide-transition/). إذا كنت بحاجة إلى حركة، قم بالتصدير إلى [HTML5](/slides/ar/androidjava/export-to-html5/)، [GIF متحرك](/slides/ar/androidjava/convert-powerpoint-to-animated-gif/)، أو [فيديو](/slides/ar/androidjava/convert-powerpoint-to-video/) بدلاً من ذلك.

**هل يمكنني تحويل عرض تقديمي متحرك إلى فيديو والتحكم في معدل الإطارات وحجم الإطار؟**
نعم. يمكنك [تصدير العرض كإطارات](/slides/ar/androidjava/convert-powerpoint-to-video/) وترميزها إلى فيديو (مثلاً باستخدام ffmpeg)، مع اختيار معدل الإطارات (FPS) والدقة. تُشغل الحركات وانتقالات الشرائح أثناء التصدير.

**هل ستظل الحركات سليمة عند العمل مع ODP (ليس فقط PPTX)؟**
يتم دعم PPT وPPTX وODP لل[قراءة](/slides/ar/androidjava/open-presentation/) و[كتابة](/slides/ar/androidjava/save-presentation/)، لكن اختلافات التنسيق قد تجعل بعض التأثيرات تظهر أو تتصرف بشكل مختلف قليلاً. تحقق من الحالات الحرجة باستخدام نماذج حقيقية.