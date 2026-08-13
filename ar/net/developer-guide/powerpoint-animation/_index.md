---
title: تعزيز عروض PowerPoint التقديمية باستخدام الرسوم المتحركة في .NET
linktitle: رسوم PowerPoint المتحركة
type: docs
weight: 150
url: /ar/net/powerpoint-animation/
keywords:
- إضافة حركة
- تحديث الحركة
- تغيير الحركة
- إزالة الحركة
- إدارة الحركة
- التحكم في الحركة
- تأثير الحركة
- رسوم PowerPoint المتحركة
- خط زمن الحركة
- حركة تفاعلية
- حركة مخصصة
- حركة الشكل
- مخطط متحرك
- نص متحرك
- شكل متحرك
- كائن OLE متحرك
- صورة متحركة
- جدول متحرك
- عرض PowerPoint التقديمي
- .NET
- C#
- Aspose.Slides
description: "استكشف إمكانات Aspose.Slides لـ .NET في معالجة رسوم PowerPoint المتحركة. يقدم هذا الاستعراض العام أبرز الميزات ويمنحك رؤى لتعزيز عروضك التقديمية."
---
## **المقدمة**

نظرًا لأن العروض التقديمية تهدف إلى عرض شيء ما، فإن مظهرها البصري وسلوكها التفاعلي يؤخذ دائمًا في الاعتبار أثناء الإنشاء.

**PowerPoint animation** يلعب دورًا مهمًا في جعل العرض التقديمي جذابًا ومشوقًا للمشاهدين. توفر Aspose.Slides for .NET مجموعة واسعة من الخيارات لإضافة الرسوم المتحركة إلى عروض PowerPoint:

- تطبيق أنواع مختلفة من تأثيرات PowerPoint animation على الأشكال، الرسوم البيانية، الجداول، كائنات OLE، وعناصر العرض التقديمي الأخرى.
- استخدام تأثيرات PowerPoint animation متعددة على شكل واحد.
- استغلال خط الزمن للرسوم المتحركة للتحكم في تأثيرات الحركة.
- إنشاء رسوم متحركة مخصصة.

في Aspose.Slides for .NET، يمكن تطبيق تأثيرات حركة مختلفة على الأشكال. نظرًا لأن كل عنصر على الشريحة، بما في ذلك النصوص والصور وكائنات OLE والجداول، يُعتبر شكلاً، يمكن تطبيق تأثيرات الحركة على أي عنصر في الشريحة.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/) namespace يوفر فئات للعمل مع رسوم PowerPoint المتحركة.

## **تأثيرات الحركة**

يدعم Aspose.Slides **150+ تأثير حركة**, بما في ذلك التأثيرات الأساسية مثل Bounce وPathFootball وZoom، بالإضافة إلى التأثيرات المحددة مثل OLEObjectShow وOLEObjectOpen. يمكنك العثور على قائمة كاملة لتأثيرات الحركة في تعداد [EffectType](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/effecttype).

بالإضافة إلى ذلك، يمكن استخدام هذه التأثيرات المتحركة بالاشتراك مع ما يلي:

- [ColorEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/seteffect)

## **حركة مخصصة**

يمكن إنشاء **رسوم متحركة مخصصة** خاصة بك في Aspose.Slides. يمكن تحقيق ذلك بدمج عدة سلوكيات معًا في رسم متحرك مخصص جديد.

[Behaviour](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/behavior) هو وحدة بناء لأي تأثير حركة في PowerPoint. جميع تأثيرات الحركة هي في الأساس مجموعة من السلوكيات المجمعة في استراتيجية واحدة. يمكنك دمج السلوكيات في رسم متحرك مخصص مرة واحدة وإعادة استخدامها في عروض تقديمية أخرى. إذا أضفت سلوكًا جديدًا إلى تأثير حركة قياسي في PowerPoint، سيصبح رسمًا متحركًا مخصصًا آخر. على سبيل المثال، يمكنك إضافة سلوك تكرار إلى حركة لجعلها تتكرر عدة مرات.

[Animation Point](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/point) هو نقطة يتم تطبيق سلوك عليها.

## **خط الزمن للحركة**

[Sequence](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/sequence) هي مجموعة من تأثيرات الحركة المطبقة على شكل محدد.

[Timeline](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/animationtimeline) هي مجموعة من السلاسل المستخدمة في شريحة محددة. إنها محرك رسوم متحركة تم تقديمه في PowerPoint 2002. في الإصدارات السابقة من PowerPoint، كان إضافة تأثيرات الحركة إلى العروض صعبًا ولا يمكن تحقيقه إلا عبر حلول بديلة متعددة. يستبدل خط الزمن الفئة القديمة AnimationSettings ويوفر نموذج كائن أوضح للرسوم المتحركة في PowerPoint. يمكن أن تحتوي الشريحة على خط زمن واحد فقط للحركة.

## **الرسوم المتحركة التفاعلية**

[Trigger](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/effecttriggertype) يسمح لك بتعريف إجراءات المستخدم (مثل النقر على زر) التي ستبدأ حركة محددة. تم تقديم المشغلات في أحدث إصدار من PowerPoint.

## **رسوم المتحركة للأشكال**

Aspose.Slides يسمح لك بتطبيق الرسوم المتحركة على الأشكال، والتي يمكن أن تشمل النص، المستطيلات، الخطوط، الإطارات، كائنات OLE، وأكثر.

{{% alert color="info" %}} 
اقرأ المزيد [**حول رسوم المتحركة للأشكال**](/slides/ar/net/shape-animation/).
{{% /alert %}}

## **الرسوم البيانية المتحركة**

لإنشاء رسوم بيانية متحركة، يجب عليك استخدام نفس الفئات المستخدمة للأشكال. ومع ذلك، لا يمكن تطبيق رسوم PowerPoint المتحركة إلا على فئات المخطط أو سلاسل المخطط. يمكنك أيضًا تطبيق تأثيرات الحركة على عنصر فئة أو عنصر سلسلة.

{{% alert color="info" %}} 
اقرأ المزيد [**حول الرسوم البيانية المتحركة**](/slides/ar/net/animated-charts/).
{{% /alert %}}

## **النص المتحرك**

إلى جانب النص المتحرك، يمكن أيضًا تطبيق الحركة على فقرة.

{{% alert color="info" %}} 
اقرأ المزيد [**حول النص المتحرك**](/slides/ar/net/animated-text/).
{{% /alert %}}

## **الأسئلة المتكررة**

### هل ستظل الرسوم المتحركة محفوظة عند التصدير إلى PDF؟

لا. PDF هو تنسيق ثابت، لذا لا تُشغل الرسوم المتحركة و[انتقالات الشرائح](/slides/ar/net/slide-transition/). إذا كنت تحتاج إلى الحركة، قم بالتصدير إلى [HTML5](/slides/ar/net/export-to-html5/)، [GIF متحرك](/slides/ar/net/convert-powerpoint-to-animated-gif/)، أو [فيديو](/slides/ar/net/convert-powerpoint-to-video/) بدلاً من ذلك.

### هل يمكنني تحويل عرض تقديمي متحرك إلى فيديو والتحكم في معدل الإطارات وحجم الإطار؟

نعم. يمكنك [render the presentation as frames](/slides/ar/net/convert-powerpoint-to-video/) وترميزها إلى فيديو (مثلاً عبر ffmpeg)، مع اختيار عدد الإطارات في الثانية والدقة. تُشغل الرسوم المتحركة وانتقالات الشرائح أثناء عملية التصيير.

### هل ستظل الرسوم المتحركة سليمة عند العمل مع ODP (ليس فقط PPTX)؟

يُدعم PPT وPPTX وODP لل[قراءة](/slides/ar/net/open-presentation/) و[كتابة](/slides/ar/net/save-presentation/)، لكن اختلافات التنسيق قد تجعل بعض التأثيرات تظهر أو تتصرف بشكل مختلف قليلاً. تحقق من الحالات الحرجة باستخدام عينات حقيقية.