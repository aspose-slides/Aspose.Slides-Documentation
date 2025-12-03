---
title: تحسين عروض PowerPoint التقديمية باستخدام الرسوم المتحركة في Java
linktitle: رسوم متحركة للـ PowerPoint
type: docs
weight: 150
url: /ar/java/powerpoint-animation/
keywords:
- إضافة رسوم متحركة
- تحديث الرسوم المتحركة
- تغيير الرسوم المتحركة
- إزالة الرسوم المتحركة
- إدارة الرسوم المتحركة
- التحكم في الرسوم المتحركة
- تأثير الرسوم المتحركة
- رسوم PowerPoint المتحركة
- خط الزمن للرسوم المتحركة
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
- Java
- Aspose.Slides
description: "استكشف إمكانيات Aspose.Slides for Java في معالجة الرسوم المتحركة لبرنامج PowerPoint. يسلط هذا الاستعراض العام الضوء على الميزات الرئيسية ويقدم رؤى لتعزيز عروضك التقديمية."
---

## **نظرة عامة**

نظرًا لأن العروض التقديمية تهدف إلى عرض شيء ما، فإن المظهر البصري والسلوك التفاعلي دائمًا ما يؤخذان في الاعتبار أثناء إنشائها.

**PowerPoint animation** يلعب دورًا مهمًا لجعل العرض التقديمي جذابًا ومثيرًا لاهتمام المشاهدين. تقدم Aspose.Slides for Java مجموعة واسعة من الخيارات لإضافة رسوم متحركة إلى عرض PowerPoint:

- تطبيق أنواع مختلفة من تأثيرات الرسوم المتحركة في PowerPoint على الأشكال، المخططات، الجداول، كائنات OLE وغيرها من عناصر العرض.
- استخدام تأثيرات متعددة للرسوم المتحركة في PowerPoint على شكل واحد.
- استخدام خط زمن للرسوم المتحركة للتحكم في تأثيرات الرسوم.
- إنشاء رسوم متحركة مخصصة.

في Aspose.Slides for Java، يمكن تطبيق تأثيرات رسوم متحركة مختلفة على الأشكال. نظرًا لأن كل عنصر على الشريحة بما في ذلك النص، الصور، كائن OLE، الجدول etc يُعتبر شكلًا، فهذا يعني أنه يمكننا تطبيق تأثير رسوم متحركة على كل عنصر في الشريحة.

## **تأثيرات الرسوم المتحركة**
يدعم Aspose.Slides **أكثر من 150 تأثيرًا للرسوم المتحركة**، بما في ذلك التأثيرات الأساسية مثل Bounce، PathFootball، تأثير التكبير وتأثيرات خاصة مثل OLEObjectShow، OLEObjectOpen. يمكنك العثور على قائمة كاملة لتأثيرات الرسوم المتحركة في تعداد [**EffectType**](https://reference.aspose.com/slides/java/com.aspose.slides/effecttype/) .

بالإضافة إلى ذلك، يمكن استخدام هذه التأثيرات معًا:

- [ColorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/java/com.aspose.slides/SetEffect)

## **الرسوم المتحركة المخصصة**
يمكنك إنشاء **رسوم متحركة مخصصة** في Aspose.Slides. 
يمكن تحقيق ذلك إذا قمت بدمج سلوكيات متعددة معًا في رسم متحرك مخصص جديد.

[**Behavior**](https://reference.aspose.com/slides/java/com.aspose.slides/Behavior) هو وحدة بناء أي تأثير رسوم متحركة في PowerPoint. جميع تأثيرات الرسوم المتحركة هي في الواقع مجموعة من السلوكيات المكوَّنة في استراتيجية واحدة. يمكنك دمج السلوكيات في رسم متحرك مخصص مرة واستخدامه في عروض تقديمية أخرى. إذا أضفت سلوكًا جديدًا إلى تأثير رسوم متحركة قياسي في PowerPoint، سيصبح ذلك رسمًا متحركًا مخصصًا آخر. على سبيل المثال، يمكنك إضافة سلوك تكرار إلى رسم متحرك لجعله يكرر نفسه عدة مرات.

[**Animation Point**](https://reference.aspose.com/slides/java/com.aspose.slides/Point) هو النقطة التي يجب تطبيق السلوك عندها.

## **خط زمن الرسوم المتحركة**
[**Sequence**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence) هو مجموعة من تأثيرات الرسوم المتحركة، تُطبق على شكل محدد.

[**Timeline**](https://reference.aspose.com/slides/java/com.aspose.slides/AnimationTimeLine) هو مجموعة من الـ Sequences تُستخدم في شريحة معينة. يُمثِّل محرك الرسوم المتحركة منذ PowerPoint 2002. في إصدارات PowerPoint السابقة، كان من الصعب إضافة تأثيرات رسوم متحركة إلى العرض، وكان ذلك ممكنًا فقط عبر حلول بديلة مختلفة. جاء الـ Timeline ليحل محل فئة AnimationSettings القديمة ويقدم نموذج كائن أكثر وضوحًا للرسوم المتحركة في PowerPoint. يمكن أن تحتوي شريحة واحدة على **خط زمن واحد** فقط للرسوم المتحركة.

## **الرسوم المتحركة التفاعلية**
[**Trigger**](https://reference.aspose.com/slides/java/com.aspose.slides/EffectTriggerType) يسمح بتعريف إجراءات المستخدم (مثل النقر على زر) التي ستجعل رسماً متحركًا معينًا يبدأ. تمت إضافة الـ Triggers فقط في أحدث إصدارات PowerPoint.

## **رسوم متحركة للأشكال**
تسمح Aspose.Slides بتطبيق رسوم متحركة على الأشكال، التي يمكن أن تكون نصًا، مستطيلًا، خطًا، إطارًا، كائن OLE، إلخ.

{{% alert color="primary" %}} 
اقرأ المزيد [**حول حركة الشكل**](/slides/ar/java/shape-animation/).
{{% /alert %}}

## **مخططات متحركة**
لإنشاء مخططات متحركة، يجب استخدام نفس الفئات كما هو الحال مع الأشكال. ومع ذلك، يمكن استخدام رسوم متحركة PowerPoint فقط على فئات المخطط أو سلسلات المخطط. يمكنك أيضًا تطبيق تأثير رسوم متحركة على عنصر فئة أو عنصر سلسلة.

{{% alert color="primary" %}} 
اقرأ المزيد [**حول المخططات المتحركة**](/slides/ar/java/animated-charts/).
{{% /alert %}}

## **نص متحرك**
إلى جانب النص المتحرك، يمكن أيضًا تطبيق رسوم متحركة على فقرة.

{{% alert color="primary" %}} 
اقرأ المزيد [**حول النص المتحرك**](/slides/ar/java/animated-text/).
{{% /alert %}}

## **الأسئلة المتكررة**

**هل ستُحَفظ الرسوم المتحركة عند التصدير إلى PDF؟**

لا. PDF هو تنسيق ثابت، لذا لا تُشَغَّل الرسوم المتحركة و[انتقالات الشرائح](/slides/ar/java/slide-transition/). إذا كنت تحتاج إلى حركة، صدّر إلى [HTML5](/slides/ar/java/export-to-html5/)، [GIF متحرك](/slides/ar/java/convert-powerpoint-to-animated-gif/)، أو [فيديو](/slides/ar/java/convert-powerpoint-to-video/) بدلاً من ذلك.

**هل يمكنني تحويل عرض تقديمي متحرك إلى فيديو والتحكم في معدل الإطارات وحجم الإطار؟**

نعم. يمكنك [تصدير العرض كإطارات](/slides/ar/java/convert-powerpoint-to-video/) وترميزها إلى فيديو (مثلاً باستخدام ffmpeg)، مع اختيار عدد الإطارات في الثانية (FPS) والدقة. تُشَغَّل الرسوم المتحركة وانتقالات الشرائح أثناء التصدير.

**هل ستظل الرسوم المتحركة سليمة عند العمل مع ODP (ليس فقط PPTX)؟**

تُدعم PPT وPPTX وODP لل[القراءة](/slides/ar/java/open-presentation/) و[الكتابة](/slides/ar/java/save-presentation/)، لكن اختلافات الصيغ قد تجعل بعض التأثيرات تبدو أو تتصرف بشكل مختلف قليلًا. احرص على التحقق من الحالات الحرجة باستخدام عينات فعلية.