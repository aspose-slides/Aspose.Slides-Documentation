---
title: تعزيز عروض PowerPoint التقديمية بالرسوم المتحركة في PHP
linktitle: الرسوم المتحركة في PowerPoint
type: docs
weight: 150
url: /ar/php-java/powerpoint-animation/
keywords:
- إضافة رسوم متحركة
- تحديث رسوم متحركة
- تغيير رسوم متحركة
- إزالة رسوم متحركة
- إدارة رسوم متحركة
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
- PHP
- Aspose.Slides
description: "استكشف قدرات Aspose.Slides لـ PHP عبر Java في معالجة الرسوم المتحركة لعرض PowerPoint. ميزات رئيسية ورؤى لتعزيز عروضك التقديمية."
---

نظرًا لأن العروض التقديمية تهدف إلى عرض شيء ما، فإن مظهرها البصري وسلوكها التفاعلي يُؤخذ دائمًا في الاعتبار أثناء إنشائها.

**PowerPoint animation** يلعب دورًا مهمًا لجعل العرض التقديمي جذابًا ومبهجًا للمشاهدين. Aspose.Slides for PHP via Java يقدم مجموعة واسعة من الخيارات لإضافة الرسوم المتحركة إلى عرض PowerPoint:

- تطبيق أنواع مختلفة من تأثيرات الرسوم المتحركة في PowerPoint على الأشكال، المخططات، الجداول، كائنات OLE والعناصر الأخرى في العرض.
- استخدام عدة تأثيرات رسوم متحركة في PowerPoint على شكل واحد.
- استخدام خط زمني للرسوم المتحركة للتحكم في تأثيراتها.
- إنشاء رسوم متحركة مخصصة.

في Aspose.Slides for PHP via Java، يمكن تطبيق تأثيرات رسوم متحركة مختلفة على الأشكال. بما أن كل عنصر على الشريحة بما في ذلك النص، الصور، كائن OLE، الجدول إلخ يُعتبر شكلاً، فهذا يعني أنه يمكننا تطبيق تأثير الرسوم المتحركة على كل عنصر في الشريحة.

## **تأثيرات الرسوم المتحركة**
يدعم Aspose.Slides **أكثر من 150 تأثيرًا للرسوم المتحركة**، بما في ذلك تأثيرات الرسوم المتحركة الأساسية مثل Bounce وPathFootball وتأثير Zoom وتأثيرات محددة مثل OLEObjectShow و OLEObjectOpen. يمكنك العثور على قائمة كاملة لتأثيرات الرسوم المتحركة في تعداد [**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype).

بالإضافة إلى ذلك، يمكن استخدام هذه التأثيرات المتحركة في تركيبة معًا:
- [ColorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/php-java/aspose.slides/SetEffect)

## **رسوم متحركة مخصصة**
يمكن إنشاء **رسوم متحركة مخصصة** خاصة بك في Aspose.Slides. يمكن تحقيق ذلك إذا قمت بدمج عدة سلوكيات معًا في رسم متحرك مخصص جديد.

[**Behavior**](https://reference.aspose.com/slides/php-java/aspose.slides/Behavior) هي وحدة بناء لأي تأثير رسوم متحركة في PowerPoint. جميع تأثيرات الرسوم المتحركة هي في الواقع مجموعة من السلوكيات التي تُركب في استراتيجية واحدة. يمكنك دمج السلوكيات في رسم متحرك مخصص مرة واحدة وإعادة استخدامها في عروض تقديمية أخرى. إذا أضفت سلوكًا جديدًا إلى تأثير رسوم متحركة قياسي في PowerPoint - سيصبح رسمًا متحركًا مخصصًا آخر. على سبيل المثال، يمكنك إضافة سلوك تكرار إلى رسم متحرك لجعله يتكرر عدة مرات.

[**Animation Point**](https://reference.aspose.com/slides/php-java/aspose.slides/Point) هو نقطة يُطبق عندها السلوك.

## **خط زمني للرسوم المتحركة**
[**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) هي مجموعة من تأثيرات الرسوم المتحركة، تُطبق على شكل محدد.

[**Timeline**](https://reference.aspose.com/slides/php-java/aspose.slides/AnimationTimeLine) هي مجموعة من الـ Sequences تُستخدم في شريحة محددة. إنها محرك للرسوم المتحركة تم تقديمه منذ PowerPoint 2002. في إصدارات PowerPoint السابقة، كان من الصعب إضافة تأثيرات رسوم متحركة إلى العرض، ويمكن تحقيق ذلك فقط عبر حلول بديلة مختلفة. يأتي الـ Timeline ليحل محل فئة AnimationSettings القديمة ويوفر نموذج كائن أكثر وضوحًا للرسوم المتحركة في PowerPoint. يمكن أن تحتوي شريحة واحدة على **خط زمني واحد** للرسوم المتحركة.

## **رسوم متحركة تفاعلية**
[**Trigger**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectTriggerType) يسمح بتحديد إجراءات المستخدم (مثل النقر على زر)، والتي ستجعل رسمًا متحركًا معينًا يبدأ. تم إضافة Triggers فقط في أحدث إصدارات PowerPoint.

## **رسوم متحركة للأشكال**
يسمح Aspose.Slides بتطبيق الرسوم المتحركة على الأشكال، والتي قد تكون نصًا، مستطيلًا، خطًا، إطارًا، كائن OLE، إلخ.
{{% alert color="primary" %}} 
اقرأ المزيد [**حول رسوم متحركة الأشكال**](/slides/ar/php-java/shape-animation/).
{{% /alert %}}

## **مخططات متحركة**
لإنشاء مخططات متحركة، يجب عليك استخدام جميع الفئات نفسها كما هو الحال مع الأشكال. ومع ذلك، من الممكن استخدام رسومات PowerPoint المتحركة فقط على فئات المخطط أو سلسلة المخطط. يمكنك أيضًا تطبيق تأثير الرسوم المتحركة على عنصر تصنيف أو عنصر سلسلة.
{{% alert color="primary" %}} 
اقرأ المزيد [**حول المخططات المتحركة**](/slides/ar/php-java/animated-charts/).
{{% /alert %}}

## **نص متحرك**
إلى جانب النص المتحرك، يمكن أيضًا تطبيق الرسوم المتحركة على فقرة.
{{% alert color="primary" %}} 
اقرأ المزيد [**حول النص المتحرك**](/slides/ar/php-java/animated-text/).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل ستُحافظ على الرسوم المتحركة عند التصدير إلى PDF؟**
لا. PDF هو تنسيق ثابت، لذا لا تُعرض الرسوم المتحركة و[انتقالات الشرائح](/slides/ar/php-java/slide-transition/). إذا كنت بحاجة إلى حركة، صدّر إلى [HTML5](/slides/ar/php-java/export-to-html5/)، [GIF متحرك](/slides/ar/php-java/convert-powerpoint-to-animated-gif/)، أو [فيديو](/slides/ar/php-java/convert-powerpoint-to-video/) بدلاً من ذلك.

**هل يمكنني تحويل عرض تقديمي متحرك إلى فيديو والتحكم في معدل الإطارات وحجم الإطار؟**
نعم. يمكنك [تصدير العرض كإطارات](/slides/ar/php-java/convert-powerpoint-to-video/) وترميزها إلى فيديو (مثلاً باستخدام ffmpeg)، مع اختيار عدد الإطارات في الثانية والدقة. تُعرض الرسوم المتحركة وانتقالات الشرائح أثناء التصدير.

**هل ستظل الرسوم المتحركة سليمة عند العمل مع ODP (وليس فقط PPTX)؟**
يتم دعم PPT وPPTX وODP لل[قراءة](/slides/ar/php-java/open-presentation/) وال[كتابة](/slides/ar/php-java/save-presentation/)، ولكن اختلافات التنسيق قد تجعل بعض التأثيرات تبدو أو تتصرف بشكل مختلف قليلًا. احرص على التحقق من الحالات الحرجة باستخدام عينات حقيقية.