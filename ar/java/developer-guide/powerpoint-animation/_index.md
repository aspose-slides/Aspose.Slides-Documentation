---
title: تحسين عروض PowerPoint التقديمية باستخدام التحريكات في Java
linktitle: تحريك PowerPoint
type: docs
weight: 150
url: /ar/java/powerpoint-animation/
keywords:
- إضافة تحريك
- تحديث التحريك
- تغيير التحريك
- إزالة التحريك
- إدارة التحريك
- التحكم في التحريك
- تأثير التحريك
- تحريك PowerPoint
- خط زمن التحريك
- تحريك تفاعلي
- تحريك مخصص
- تحريك الشكل
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
description: "استكشف قدرات Aspose.Slides للغة Java في معالجة تحريكات PowerPoint. يسلط هذا الملخص العام الضوء على الميزات الرئيسية ويقدم رؤى لتحسين عروضك التقديمية."
---
## **المقدمة**

نظرًا لأن العروض التقديمية تهدف إلى عرض شيء ما، فإن مظهرها البصري وسلوكها التفاعلي يُؤخذ دائمًا في الاعتبار أثناء الإنشاء.

**PowerPoint animation** يلعب دورًا مهمًا في جعل العرض التقديمي جذابًا ومشوقًا للمشاهدين. توفر Aspose.Slides مجموعة واسعة من الخيارات لإضافة التحريكات إلى عروض PowerPoint:

- تطبيق أنماط مختلفه من تأثيرات تحريك PowerPoint على الأشكال، المخططات، الجداول، كائنات OLE، وعناصر العرض الأخرى.
- استخدام تأثيرات تحريك PowerPoint متعددة على شكل واحد.
- الاستفادة من خط الزمن للتحريك للسيطرة على تأثيرات التحريك.
- إنشاء تحريكات مخصصة.

في Aspose.Slides، يمكن تطبيق تأثيرات تحريك مختلفة على الأشكال. نظرًا لأن كل عنصر في الشريحة، بما في ذلك النصوص والصور وكائنات OLE والجداول، يُعد شكلًا، يمكن تطبيق تأثيرات التحريك على أي عنصر في الشريحة.

## **تأثيرات التحريك**
تدعم Aspose.Slides **150+ تأثير تحريك**، بما في ذلك تأثيرات التحريك الأساسية مثل Bounce، PathFootball، تأثير التكبير وتأثيرات تحريك محددة مثل OLEObjectShow، OLEObjectOpen. يمكنك العثور على قائمة كاملة بتأثيرات التحريك في تعداد [**EffectType**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/effecttype/) .

بالإضافة إلى ذلك، يمكن استخدام هذه تأثيرات التحريك بالاشتراك معًا:
- [ColorEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SetEffect)

## **تحريك مخصص**
يمكن إنشاء **تحريكات مخصصة** خاصة بك في Aspose.Slides. يمكن تحقيق ذلك إذا قمت بدمج عدة سلوكيات معًا في تحريك مخصص جديد.

[**Behavior**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Behavior) هو وحدة بناء لأي تأثير تحريك في PowerPoint. كل تأثيرات التحريك هي في الواقع مجموعة من السلوكيات المكوّنة في استراتيجية واحدة. يمكنك دمج السلوكيات في تحريك مخصص مرة واستخدامه مرة أخرى في عروض تقديمية أخرى. إذا أضفت سلوكًا جديدًا إلى تأثير تحريك PowerPoint القياسي - سيصبح تحريكًا مخصصًا آخر. على سبيل المثال، يمكنك إضافة سلوك التكرار إلى تحريك لجعله يتكرر عدة مرات.

[**Animation Point**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Point) هو النقطة التي يجب تطبيق السلوك عندها.

## **خط الزمن للتحريك**
[**Sequence**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Sequence) هي مجموعة من تأثيرات التحريك، تُطبّق على شكل محدد.

[**Timeline**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/AnimationTimeLine) هو مجموعة من الـSequences تُستخدم في شريحة محددة. إنه محرك تحريك موجود منذ PowerPoint 2002. في الإصدارات السابقة من PowerPoint، كان من الصعب إضافة تأثيرات تحريك إلى العرض، وكان ذلك ممكنًا فقط عبر حلول بديلة مختلفة. يأتي Timeline ليحل محل الفئة القديمة AnimationSettings ويوفر نموذج كائن أكثر وضوحًا لتحريك PowerPoint. يمكن لشفرة واحدة أن تحتوي على Timeline واحد فقط.

## **التحريك التفاعلي**
[**Trigger**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/EffectTriggerType) يتيح تعريف إجراءات المستخدم (مثل النقر على زر)، والتي تجعل تحريكًا معينًا يبدأ. تم إضافة الـTriggers فقط في أحدث إصدار من PowerPoint.

## **تحريك الشكل**
تسمح Aspose.Slides بتطبيق التحريك على الأشكال، والتي قد تكون نصًا، مستطيلًا، خطًا، إطارًا، كائن OLE، إلخ.

{{% alert color="info" %}} 
اقرأ المزيد [**حول تحريك الشكل**](/slides/ar/java/shape-animation/).
{{% /alert %}}

## **المخططات المتحركة**
لإنشاء مخططات متحركة، يجب عليك استخدام جميع الفئات نفسها كما هو الحال مع الأشكال. ومع ذلك، يمكن استخدام تحريك PowerPoint فقط على فئات المخطط أو سلاسل المخطط. يمكنك أيضًا تطبيق تأثير التحريك على عنصر فئة أو عنصر سلسلة.

{{% alert color="info" %}} 
اقرأ المزيد [**حول المخططات المتحركة**](/slides/ar/java/animated-charts/).
{{% /alert %}}

## **النص المتحرك**
إلى جانب النص المتحرك، يمكن أيضًا تطبيق التحريك على فقرة.

{{% alert color="info" %}} 
اقرأ المزيد [**حول النص المتحرك**](/slides/ar/java/animated-text/).
{{% /alert %}}

## **الأسئلة الشائعة**

### هل سيتم الحفاظ على التحريكات عند التصدير إلى PDF؟

لا. PDF هو تنسيق ثابت، لذلك لا تعمل التحريكات و[انتقالات الشرائح](/slides/ar/java/slide-transition/). إذا كنت تحتاج إلى حركة، قم بالتصدير إلى [HTML5](/slides/ar/java/export-to-html5/)، [GIF متحرك](/slides/ar/java/convert-powerpoint-to-animated-gif/)، أو [فيديو](/slides/ar/java/convert-powerpoint-to-video/) بدلاً من ذلك.

### هل يمكنني تحويل عرض تقديمي متحرك إلى فيديو والتحكم في معدل الإطارات وحجم الإطار؟

نعم. يمكنك [تحويل العرض إلى إطارات](/slides/ar/java/convert-powerpoint-to-video/) وترميزها إلى فيديو (مثلاً باستخدام ffmpeg)، مع اختيار عدد الإطارات في الثانية (FPS) والدقة. يتم تشغيل التحريكات وانتقالات الشرائح أثناء التحويل.

### هل ستبقى التحريكات سليمة عند العمل مع ODP (ليس فقط PPTX)؟

يتم دعم PPT وPPTX وODP لل[قراءة](/slides/ar/java/open-presentation/) و[كتابة](/slides/ar/java/save-presentation/)، لكن الاختلافات في التنسيق قد تجعل بعض التأثيرات تبدو أو تتصرف بشكل مختلف قليلًا. تحقق من الحالات الحرجة باستخدام عينات حقيقية.