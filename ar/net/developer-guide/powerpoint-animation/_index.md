---
title: تعزيز عروض PowerPoint التقديمية باستخدام الرسوم المتحركة في .NET
linktitle: رسوم متحركة PowerPoint
type: docs
weight: 150
url: /ar/net/powerpoint-animation/
keywords:
- إضافة رسوم متحركة
- تحديث رسوم متحركة
- تغيير رسوم متحركة
- حذف رسوم متحركة
- إدارة رسوم متحركة
- التحكم في الرسوم المتحركة
- تأثير الرسوم المتحركة
- رسوم متحركة PowerPoint
- خط الزمن للرسوم المتحركة
- رسوم متحركة تفاعلية
- رسوم متحركة مخصصة
- رسوم متحركة الشكل
- مخطط متحرك
- نص متحرك
- شكل متحرك
- كائن OLE متحرك
- صورة متحركة
- جدول متحرك
- عرض PowerPoint
- .NET
- C#
- Aspose.Slides
description: "استكشف قدرات Aspose.Slides لـ .NET في معالجة الرسوم المتحركة لعروض PowerPoint. يقدم هذا الملخص العام الميزات الرئيسية ويقدم رؤى لتعزيز عروضك التقديمية."
---

## **نظرة عامة**

نظرًا لأن العروض التقديمية تهدف إلى عرض شيء ما، فإن المظهر البصري والسلوك التفاعلي دائمًا ما يُؤخذان في الاعتبار أثناء الإنشاء.

**PowerPoint animation** يلعب دورًا مهمًا في جعل العرض جذابًا ومشوقًا للمشاهدين. توفر Aspose.Slides for .NET مجموعة واسعة من الخيارات لإضافة رسومات متحركة إلى عروض PowerPoint:

- تطبيق أنواع مختلفة من تأثيرات الرسوم المتحركة على الأشكال والرسوم البيانية والجداول وكائنات OLE وعناصر العرض الأخرى.
- استخدام تأثيرات رسوم متحركة متعددة على شكل واحد.
- الاستفادة من جدول زمني للرسوم المتحركة للتحكم في تأثيرات الرسوم المتحركة.
- إنشاء رسومات متحركة مخصصة.

في Aspose.Slides for .NET، يمكن تطبيق تأثيرات رسومية مختلفة على الأشكال. نظرًا لأن كل عنصر على الشريحة، بما في ذلك النصوص والصور وكائنات OLE والجداول، يُعامل كشكل، يمكن تطبيق تأثيرات الرسوم المتحركة على أي عنصر في الشريحة.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/)namespace​ توفر فئات للعمل مع رسوم PowerPoint المتحركة.

## **تأثيرات الرسوم المتحركة**

يدعم Aspose.Slides **أكثر من 150 تأثيرًا للرسوم المتحركة**، بما في ذلك التأثيرات الأساسية مثل Bounce وPathFootball وZoom، بالإضافة إلى التأثيرات الخاصة مثل OLEObjectShow وOLEObjectOpen. يمكنك العثور على قائمة كاملة بتأثيرات الرسوم المتحركة في تعداد [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype).

بالإضافة إلى ذلك، يمكن دمج هذه التأثيرات مع ما يلي:

- [ColorEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/seteffect)

## **رسوم متحركة مخصصة**

يمكنك إنشاء **رسوم متحركة مخصصة** في Aspose.Slides. يتحقق ذلك بدمج عدة سلوكيات معًا لتكوين رسم متحرك مخصص جديد.

[Behaviour](https://reference.aspose.com/slides/net/aspose.slides.animation/behavior) هو وحدة بناء لأي تأثير رسم متحرك في PowerPoint. جميع تأثيرات الرسوم المتحركة هي أساسًا مجموعة من السلوكيات المجمعة في استراتيجية واحدة. يمكنك دمج السلوكيات في رسم متحرك مخصص مرة واحدة وإعادة استخدامه في عروض أخرى. إذا أضفت سلوكًا جديدًا إلى تأثير رسم متحرك قياسي في PowerPoint، سيصبح رسمًا متحركًا مخصصًا آخر. على سبيل المثال، يمكنك إضافة سلوك تكرار إلى رسم متحرك لجعله يتكرر عدة مرات.

[Animation Point](https://reference.aspose.com/slides/net/aspose.slides.animation/point) هو النقطة التي يجب تطبيق السلوك عندها.

## **خط الزمن للرسوم المتحركة**

[Sequence](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) هي مجموعة من تأثيرات الرسوم المتحركة المطبقة على شكل معين.

[Timeline](https://reference.aspose.com/slides/net/aspose.slides.animation/animationtimeline) هي مجموعة من السلاسل المستخدمة في شريحة محددة. إنها محرك رسوم متحركة تم تقديمه في PowerPoint 2002. في الإصدارات السابقة من PowerPoint، كان إضافة تأثيرات الرسوم المتحركة إلى العروض أمرًا صعبًا ولا يمكن تحقيقه إلا عبر حلول ملتوية متعددة. يستبدل الخط الزمني الفئة القديمة AnimationSettings ويوفر نموذج كائن أكثر وضوحًا للرسوم المتحركة في PowerPoint. يمكن أن تحتوي الشريحة على خط زمن واحد فقط للرسوم المتحركة.

## **رسوم متحركة تفاعلية**

[Trigger](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttriggertype) يسمح لك بتعريف إجراءات المستخدم (مثل النقر على زر) التي ستبدأ رسمًا متحركًا محددًا. تم تقديم المشغلات في أحدث إصدارات PowerPoint.

## **رسوم متحركة للأشكال**

يتيح Aspose.Slides تطبيق الرسوم المتحركة على الأشكال، والتي قد تشمل النصوص، المستطيلات، الخطوط، الإطارات، كائنات OLE، وأكثر.

{{% alert color="primary" %}} 
اقرأ المزيد [**حول الرسوم المتحركة للأشكال**](/slides/ar/net/shape-animation/).
{{% /alert %}}

## **رسوم متحركة للمخططات**

لإنشاء مخططات متحركة، يجب استخدام نفس الفئات المستخدمة للأشكال. ومع ذلك، لا يمكن تطبيق رسوم PowerPoint المتحركة إلا على فئات المخطط أو سلاسل المخطط. يمكنك أيضًا تطبيق تأثيرات الرسوم المتحركة على عنصر فئة أو عنصر سلسلة.

{{% alert color="primary" %}} 
اقرأ المزيد [**حول المخططات المتحركة**](/slides/ar/net/animated-charts/).
{{% /alert %}}

## **نص متحرك**

إلى جانب النص المتحرك، يمكن أيضًا تطبيق الرسوم المتحركة على فقرة.

{{% alert color="primary" %}} 
اقرأ المزيد [**حول النص المتحرك**](/slides/ar/net/animated-text/).
{{% /alert %}}

## **FAQ**

**هل سيتم الحفاظ على الرسوم المتحركة عند التصدير إلى PDF؟**

لا. PDF تنسيق ثابت، لذا لا تُشغل الرسوم المتحركة و[انتقالات الشرائح](/slides/ar/net/slide-transition/). إذا كنت بحاجة إلى حركة، صدّر إلى [HTML5](/slides/ar/net/export-to-html5/)، [GIF متحرك](/slides/ar/net/convert-powerpoint-to-animated-gif/)، أو [فيديو](/slides/ar/net/convert-powerpoint-to-video/) بدلاً من ذلك.

**هل يمكنني تحويل عرض تقديمي متحرك إلى فيديو والتحكم في معدل الإطارات وحجم الإطار؟**

نعم. يمكنك [تصدير العرض كإطارات](/slides/ar/net/convert-powerpoint-to-video/) وترميزها إلى فيديو (مثلاً عبر ffmpeg)، مع اختيار عدد الإطارات في الثانية والدقة. تُشغل الرسوم المتحركة وانتقالات الشرائح أثناء التصدير.

**هل ستظل الرسوم المتحركة سليمة عند العمل مع ODP (ليس فقط PPTX)؟**

تدعم PPT وPPTX وODP لل[القراءة](/slides/ar/net/open-presentation/) و[الكتابة](/slides/ar/net/save-presentation/)، لكن الاختلافات في الصيغ قد تجعل بعض التأثيرات تظهر أو تتصرف بشكل مختلف قليلاً. تحقق من الحالات الحرجة باستخدام عينات حقيقية.