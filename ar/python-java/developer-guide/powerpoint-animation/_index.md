---
title: تحسين عروض PowerPoint التقديمية باستخدام الرسوم المتحركة في Python عبر Java
linktitle: رسوم متحركة PowerPoint
type: docs
weight: 150
url: /ar/python-java/powerpoint-animation/
keywords:
- إضافة رسم متحرك
- تحديث رسم متحرك
- تغيير رسم متحرك
- إزالة رسم متحرك
- إدارة رسم متحرك
- التحكم في الرسم المتحرك
- تأثير رسم متحرك
- رسوم PowerPoint المتحركة
- خط زمن الرسم المتحرك
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
- Python
- Java
- Aspose.Slides
description: "استكشف إمكانيات Aspose.Slides لـ Python عبر Java في معالجة رسوم PowerPoint المتحركة. يسلط هذا النظرة العامة الضوء على الميزات الرئيسية ويوفر رؤى لتحسين عروضك التقديمية."
---
## **مقدمة**

يتم أخذ كل من المظهر البصري والسلوك التفاعلي في الاعتبار عند إنشاء العروض التقديمية.

**PowerPoint animation** يلعب دورًا مهمًا في جعل العرض التقديمي ملفتًا للانتباه وجذابًا للمشاهدين. توفر Aspose.Slides مجموعة واسعة من الخيارات لإضافة الرسوم المتحركة إلى عروض PowerPoint التقديمية:
- تطبيق أنواع مختلفة من تأثيرات الرسوم المتحركة في PowerPoint على الأشكال والمخططات والجداول وكائنات OLE والعناصر الأخرى للعرض.
- استخدام تأثيرات رسوم متحركة متعددة لبرنامج PowerPoint على شكل واحد.
- استخدام خط الزمن للرسوم المتحركة للتحكم في تأثيرات الرسوم المتحركة.
- إنشاء رسوم متحركة مخصصة.

## **تأثيرات الرسوم المتحركة**
تدعم Aspose.Slides **أكثر من 150 تأثيرًا للرسوم المتحركة**، بما في ذلك تأثيرات الرسوم المتحركة الأساسية مثل Bounce وPathFootball وZoom، بالإضافة إلى تأثيرات متخصصة مثل OLEObjectShow و OLEObjectOpen. يمكنك العثور على قائمة كاملة بتأثيرات الرسوم المتحركة في تعداد [EffectType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effecttype/).

بالإضافة إلى ذلك، يمكن استخدام تأثيرات الرسوم المتحركة التالية بالتزامن مع تلك المذكورة أعلاه:
- [ColorEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/seteffect/)

## **رسوم متحركة مخصصة**
يمكن إنشاء **رسوم متحركة مخصصة** في Aspose.Slides.
يمكنك القيام بذلك عن طريق دمج عدة سلوكيات في رسم متحرك مخصص جديد.

[Behavior](https://reference.aspose.com/slides/ar/python-java/aspose.slides/behavior/) هو العنصر الأساسي لأي تأثير رسوم متحركة في PowerPoint. كل تأثير رسوم متحركة يتكون من مجموعة من السلوكيات المدمجة في استراتيجية واحدة. يمكنك دمج السلوكيات في رسم متحرك مخصص مرة واحدة وإعادة استخدامها في عروض تقديمية أخرى. إضافة سلوك جديد إلى تأثير رسوم متحركة قياسي في PowerPoint يخلق رسمًا متحركًا مخصصًا آخر. على سبيل المثال، يمكنك إضافة سلوك تكرار لجعل الرسوم المتحركة تتكرر عدة مرات.

[Point](https://reference.aspose.com/slides/ar/python-java/aspose.slides/point/) هو النقطة التي يجب تطبيق السلوك عندها.

## **خط زمن الرسوم المتحركة**
[Sequence](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sequence/) هي مجموعة من تأثيرات الرسوم المتحركة المطبقة على شكل محدد.

[AnimationTimeLine](https://reference.aspose.com/slides/ar/python-java/aspose.slides/animationtimeline/) هو مجموعة من التسلسلات المستخدمة على شريحة معينة. يمثل محرك الرسوم المتحركة الذي تم تقديمه في PowerPoint 2002. في إصدارات PowerPoint السابقة، كان إضافة تأثيرات الرسوم المتحركة إلى عرض تقديمي صعبًا ويتطلب حلولًا بديلة. يستبدل خط الزمن الفئة القديمة AnimationSettings ويوفر نموذج كائن أوضح للرسوم المتحركة في PowerPoint. يمكن أن تحتوي الشريحة على خط زمن واحد فقط للرسوم المتحركة.

## **رسوم متحركة تفاعلية**
[EffectTriggerType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effecttriggertype/) يتيح لك تعريف إجراءات المستخدم (مثل النقر على زر) التي تبدأ رسمًا متحركًا محددًا. تمت إضافة المحفزات فقط في أحدث نسخة من PowerPoint.

## **رسوم متحركة للأشكال**
تتيح لك Aspose.Slides تطبيق الرسوم المتحركة على الأشكال، والتي يمكن أن تمثل النصوص، والمستطيلات، والخطوط، والإطارات، وكائنات OLE، وعناصر أخرى.

{{% alert color="info" title="Note" %}}
اقرأ المزيد [حول رسوم متحركة للأشكال](/slides/ar/python-java/shape-animation/).
{{% /alert %}}

## **مخططات متحركة**
لإنشاء مخططات متحركة، استخدم نفس الفئات كما هو الحال للأشكال. ومع ذلك، يمكن استخدام رسوم متحركة PowerPoint فقط على فئات المخطط أو سلاسل المخطط. يمكنك أيضًا تطبيق تأثير رسوم متحرك على عنصر فئة أو عنصر سلسلة.

{{% alert color="info" title="Note" %}}
اقرأ المزيد [حول المخططات المتحركة](/slides/ar/python-java/animated-charts/).
{{% /alert %}}

## **نص متحرك**
بالإضافة إلى تحريك النص، يمكنك تطبيق الرسوم المتحركة على فقرة.

{{% alert color="info" title="Note" %}}
اقرأ المزيد [حول النص المتحرك](/slides/ar/python-java/animated-text/).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل ستظل الرسوم المتحركة محفوظة عند التصدير إلى PDF؟**

لا. PDF هو تنسيق ثابت، لذلك لا تُشغل الرسوم المتحركة و[slide transitions](/slides/ar/python-java/slide-transition/). إذا كنت بحاجة إلى حركة، صدّر إلى [HTML5](/slides/ar/python-java/export-to-html5/)، أو [animated GIF](/slides/ar/python-java/convert-powerpoint-to-animated-gif/)، أو [video](/slides/ar/python-java/convert-powerpoint-to-video/) بدلاً من ذلك.

**هل يمكنني تحويل عرض تقديمي متحرك إلى فيديو والتحكم في معدل الإطارات وحجم الإطار؟**

نعم. يمكنك [render the presentation as frames](/slides/ar/python-java/convert-powerpoint-to-video/) وتشفيرها إلى فيديو (مثلاً باستخدام ffmpeg)، مع اختيار عدد الإطارات في الثانية (FPS) والدقة. تُشغل الرسوم المتحركة وانتقالات الشرائح أثناء عملية التصدير.

**هل ستبقى الرسوم المتحركة سليمة عند العمل مع ODP (ليس فقط PPTX)؟**

يتم دعم PPT وPPTX وODP لل[reading](/slides/ar/python-java/open-presentation/) و[writing](/slides/ar/python-java/save-presentation/)، ولكن اختلافات التنسيق قد تجعل بعض التأثيرات تبدو أو تعمل بشكل مختلف قليلاً. يُنصح بالتحقق من الحالات الحرجة باستخدام عينات حقيقية.