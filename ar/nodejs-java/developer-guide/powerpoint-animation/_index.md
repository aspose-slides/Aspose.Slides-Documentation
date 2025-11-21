---
title: الرسوم المتحركة PowerPoint
type: docs
weight: 150
url: /ar/nodejs-java/powerpoint-animation/
keywords: "الرسوم المتحركة PowerPoint"
description: "الرسوم المتحركة PowerPoint، رسوم متحركة لشرائح PowerPoint باستخدام Aspose.Slides."
---

نظرًا لأن العروض التقديمية تهدف إلى عرض شيء ما، فإن مظهرها البصري وسلوكها التفاعلي يُؤخذ دائمًا في الاعتبار أثناء إنشائها.

**PowerPoint animation** تلعب دورًا مهمًا لجعل العرض جذابًا ومثيرًا للانتباه للمشاهدين. تقدم Aspose.Slides for Node.js via Java مجموعة واسعة من الخيارات لإضافة الرسوم المتحركة إلى عرض PowerPoint:

- تطبيق أنواع مختلفة من تأثيرات الرسوم المتحركة في PowerPoint على الأشكال، والمخططات، والجداول، وكائنات OLE وعناصر العرض التقديمي الأخرى.
- استخدام عدة تأثيرات رسوم متحركة في PowerPoint على شكل واحد.
- استخدام جدول زمني للرسوم المتحركة للتحكم في تأثيرات الرسوم المتحركة.
- إنشاء رسومات متحركة مخصصة.

في Aspose.Slides for Node.js via Java، يمكن تطبيق تأثيرات رسومية متحركة مختلفة على الأشكال. نظرًا لأن كل عنصر على الشريحة بما في ذلك النص، والصور، وكائن OLE، والجدول إلخ يُعتبر شكلًا، فهذا يعني أنه يمكننا تطبيق تأثير الرسوم المتحركة على كل عنصر في الشريحة.

## **تأثيرات الرسوم المتحركة**
يدعم Aspose.Slides **150+ تأثيرًا للرسوم المتحركة**، بما في ذلك تأثيرات أساسية مثل Bounce وPathFootball وتأثير التكبير Zoom وتffects محددة مثل OLEObjectShow و OLEObjectOpen. يمكنك العثور على قائمة كاملة لتأثيرات الرسوم المتحركة في تعداد [**EffectType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effecttype/).

بالإضافة إلى ذلك، يمكن استخدام هذه التأثيرات المتحركة معًا:
- [ColorEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SetEffect)

## **رسوم متحركة مخصصة**
من الممكن إنشاء **رسوم متحركة مخصصة** خاصة بك في Aspose.Slides. يمكن تحقيق ذلك إذا قمت بدمج عدة سلوكيات معًا في رسوم متحركة مخصصة جديدة.

[**Behavior**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Behavior) هو وحدة بناء لأي تأثير رسوم متحركة في PowerPoint. جميع تأثيرات الرسوم المتحركة هي في الواقع مجموعة من السلوكيات المكوَّنة في استراتيجية واحدة. يمكنك دمج السلوكيات في رسوم متحركة مخصصة مرة واحدة وإعادة استخدامها في عروض تقديمية أخرى. إذا أضفت سلوكًا جديدًا إلى تأثير رسوم متحركة قياسي في PowerPoint - سيصبح ذلك رسمًا متحركًا مخصصًا آخر. على سبيل المثال، يمكنك إضافة سلوك تكرار إلى رسم متحرك لجعله يتكرر عدة مرات.

[**Animation Point**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Point) هو نقطة يتم فيها تطبيق السلوك.

## **خط زمني للرسوم المتحركة**
[**Sequence**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence) هي مجموعة من تأثيرات الرسوم المتحركة، تُطبق على شكل معين.

[**Timeline**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AnimationTimeLine) هي مجموعة من الSequences تُستخدم في شريحة معينة. تم تقديم محرك الرسوم المتحركة هذا منذ PowerPoint 2002. في إصدارات PowerPoint السابقة، كان من الصعب إضافة تأثيرات الرسوم المتحركة إلى العرض، وكان ذلك ممكنًا فقط عبر حلول بديلة مختلفة. يأتي الخط الزمني ليحل محل الفئة القديمة AnimationSettings ويُوفر نموذج كائن أكثر وضوحًا للرسوم المتحركة في PowerPoint. يمكن أن تحتوي شريحة واحدة على خط زمني للرسوم المتحركة واحد فقط.

## **رسوم متحركة تفاعلية**
[**Trigger**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EffectTriggerType) يسمح بتحديد إجراءات المستخدم (مثل النقر على زر) التي ستُشغِل تشغيل رسم متحرك معين. تم إضافة المشغلات فقط في أحدث إصدار من PowerPoint.

## **رسوم متحركة للأشكال**
تسمح Aspose.Slides بتطبيق الرسوم المتحركة على الأشكال، التي قد تكون نصًا، أو مربعًا، أو خطًا، أو إطارًا، أو كائن OLE، إلخ.

{{% alert color="primary" %}} 
اقرأ المزيد [**حول الرسوم المتحركة للأشكال**](/slides/ar/nodejs-java/shape-animation/).
{{% /alert %}}

## **مخططات متحركة**
لإنشاء مخططات متحركة، يجب عليك استخدام نفس الفئات المستخدمة للأشكال. ومع ذلك، يمكن استخدام رسوم متحركة في PowerPoint فقط على فئات المخطط أو سلاسل المخطط. يمكنك أيضًا تطبيق تأثير الرسوم المتحركة على عنصر فئة أو عنصر سلسلة.

{{% alert color="primary" %}} 
اقرأ المزيد [**حول المخططات المتحركة**](/slides/ar/nodejs-java/animated-charts/).
{{% /alert %}}

## **نص متحرك**
بالإضافة إلى النص المتحرك، يمكن أيضًا تطبيق الرسوم المتحركة على فقرة.

{{% alert color="primary" %}} 
اقرأ المزيد [**حول النص المتحرك**](/slides/ar/nodejs-java/animated-text/).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل ستُحافظ على الرسوم المتحركة عند التصدير إلى PDF؟**
لا. PDF هو تنسيق ثابت، لذلك لا تُشغل الرسوم المتحركة و[انتقالات الشرائح](/slides/ar/nodejs-java/slide-transition/). إذا كنت تحتاج إلى حركة، فصدّر إلى [HTML5](/slides/ar/nodejs-java/export-to-html5/)، [GIF متحرك](/slides/ar/nodejs-java/convert-powerpoint-to-animated-gif/)، أو [فيديو](/slides/ar/nodejs-java/convert-powerpoint-to-video/) بدلاً من ذلك.

**هل يمكنني تحويل عرض تقديمي متحرك إلى فيديو والتحكم في معدل الإطارات وحجم الإطار؟**
نعم. يمكنك [تصدير العرض كإطارات](/slides/ar/nodejs-java/convert-powerpoint-to-video/) وترميزها إلى فيديو (مثلاً باستخدام ffmpeg)، مع اختيار عدد الإطارات في الثانية والدقة. تُشغل الرسوم المتحركة وانتقالات الشرائح أثناء التصدير.

**هل ستبقى الرسوم المتحركة سليمة عند العمل مع ODP (وليس فقط PPTX)؟**
يُدعم PPT وPPTX وODP لل[قراءة](/slides/ar/nodejs-java/open-presentation/) و[كتابة](/slides/ar/nodejs-java/save-presentation/)، لكن اختلافات الصيغ قد تجعل بعض التأثيرات تبدو أو تتصرف بصورة مختلفة قليلاً. تحقق من الحالات الحرجة باستخدام عينات فعلية.