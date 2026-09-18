---
title: "تعزيز عروض PowerPoint التقديمية باستخدام الرسوم المتحركة في C++"
linktitle: "رسوم متحركة PowerPoint"
type: docs
weight: 150
url: /ar/cpp/powerpoint-animation/
keywords:
- إضافة رسوم متحركة
- تحديث الرسوم المتحركة
- تغيير الرسوم المتحركة
- إزالة الرسوم المتحركة
- إدارة الرسوم المتحركة
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
- C++
- Aspose.Slides
description: "تعلم كيفية إضافة والتحكم في تأثيرات الرسوم المتحركة المتقدمة في Aspose.Slides لـ C++ لإنشاء عروض PowerPoint وOpenDocument ديناميكية."
---
## **المقدمة**

نظرًا لأن العروض التقديمية تهدف إلى عرض شيء ما، فإن المظهر البصري والسلوك التفاعلي يُؤخذان دائمًا في الاعتبار أثناء الإنشاء.

تلعب **PowerPoint animation** دورًا مهمًا في جعل العرض التقديمي جذابًا ومشوقًا للمشاهدين. توفر Aspose.Slides مجموعة واسعة من الخيارات لإضافة رسوم متحركة إلى عروض PowerPoint:

- تطبيق أنواع مختلفة من تأثيرات PowerPoint animation على الأشكال، المخططات، الجداول، كائنات OLE، وعناصر أخرى في العرض التقديمي.
- استخدام تأثيرات PowerPoint animation متعددة على شكل واحد.
- استخدام خط الزمن للرسوم المتحركة للتحكم في تأثيرات الرسوم المتحركة.
- إنشاء رسوم متحركة مخصصة.

في Aspose.Slides، يمكن تطبيق تأثيرات رسوم متحركة مختلفة على الأشكال. نظرًا لأن كل عنصر على الشريحة، بما في ذلك النصوص، الصور، كائنات OLE، والجداول، يُعتبر شكلًا، يمكن تطبيق تأثيرات الرسوم المتحركة على أي عنصر في الشريحة.

يوفر نطاق الاسم [Aspose::Slides::Animation](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/) الفئات اللازمة للعمل مع رسوم PowerPoint المتحركة.

## **تأثيرات الرسوم المتحركة**

يدعم Aspose.Slides **أكثر من 150 تأثيرًا للرسوم المتحركة**، بما في ذلك التأثيرات الأساسية مثل Bounce وPathFootball وZoom، وتأثيرات محددة مثل OLEObjectShow وOLEObjectOpen. يمكنك العثور على القائمة الكاملة في تعداد [EffectType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/effecttype/).

بالإضافة إلى ذلك، يمكن استخدام هذه التأثيرات المتحركة بالاشتراك مع السلوكيات التالية:
- [ColorEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/seteffect/)

## **رسوم متحركة مخصصة**

للحصول على أمثلة C++ كاملة تُنشئ وتفحص وتعدل السلوكيات ومسارات الحركة القابلة للتحرير، انظر [Custom Animation](/slides/ar/cpp/custom-animation/).

يمكن إنشاء **رسوم متحركة مخصصة** خاصة بك في Aspose.Slides. يمكن تحقيق ذلك بدمج عدة سلوكيات في رسم متحرك مخصص جديد.

[Behavior](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/behavior/) هو كتلة بناء لتأثير رسوم PowerPoint المتحركة. قم بدمج السلوكيات لتخصيص تأثير، أو أضف سلوكًا لتوسيع تأثير محدد مسبقًا. يتم تكوين التكرار من خلال إعدادات التوقيت بدلاً من سلوك تكرار منفصل.

[Animation Point](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/point/) هو نقطة يُطبق عندها السلوك.

## **خط الزمن للرسوم المتحركة**

[Sequence](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/sequence/) هي مجموعة من تأثيرات الرسوم المتحركة التي يمكن أن تستهدف أشكالًا مختلفة.

[IAnimationTimeLine](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ianimationtimeline/) هي مجموعة من التسلسلات تُستخدم في شريحة محددة. إنها محرك رسوم متحركة تم تقديمه في PowerPoint 2002. في الإصدارات السابقة من PowerPoint، كان إضافة تأثيرات الرسوم المتحركة إلى العروض صعبًا ولا يمكن تحقيقه إلا من خلال حلول بديلة متعددة. يوفر الخط الزمني نموذج كائن أوضح للرسوم المتحركة في PowerPoint. يمكن أن تحتوي الشريحة على خط زمن رسوم متحركة واحد فقط.

## **رسوم متحركة تفاعلية**

[Trigger](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/effecttriggertype/) يتيح لك تعريف إجراءات المستخدم، مثل النقر على زر، لتشغيل رسوم متحركة معينة.

## **رسوم متحركة للأشكال**

تسمح لك Aspose.Slides بتطبيق رسوم متحركة على الأشكال، والتي يمكن أن تشمل النصوص، المستطيلات، الخطوط، الإطارات، كائنات OLE، وأكثر.

{{% alert color="info" title="Note" %}}
اقرأ المزيد [**حول الرسوم المتحركة للأشكال**](/slides/ar/cpp/shape-animation/).
{{% /alert %}}

## **المخططات المتحركة**

لإنشاء مخططات متحركة، يجب عليك استخدام نفس الفئات المستخدمة للأشكال. ومع ذلك، يمكن تطبيق رسوم PowerPoint المتحركة فقط على فئات المخطط أو سلاسل المخطط. يمكنك أيضًا تطبيق تأثيرات الرسوم المتحركة على عنصر فئة أو عنصر سلسلة.

{{% alert color="info" title="Note" %}}
اقرأ المزيد [**حول المخططات المتحركة**](/slides/ar/cpp/animated-charts/).
{{% /alert %}}

## **النص المتحرك**

بالإضافة إلى تحريك النص، يمكنك تطبيق رسوم متحركة على فقرة.

{{% alert color="info" title="Note" %}}
اقرأ المزيد [**حول النص المتحرك**](/slides/ar/cpp/animated-text/).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل سيتم الحفاظ على الرسوم المتحركة عند التصدير إلى PDF؟**

لا. PDF هو تنسيق ثابت، لذا لا تُشغل الرسوم المتحركة و[الانتقالات بين الشرائح](/slides/ar/cpp/slide-transition/). إذا كنت بحاجة إلى حركة، فقم بالتصدير إلى [HTML5](/slides/ar/cpp/export-to-html5/)، أو [GIF متحرك](/slides/ar/cpp/convert-powerpoint-to-animated-gif/)، أو [فيديو](/slides/ar/cpp/convert-powerpoint-to-video/) بدلاً من ذلك.

**هل يمكنني تحويل عرض تقديمي متحرك إلى فيديو والتحكم في معدل الإطارات وحجم الإطار؟**

نعم. يمكنك [تصدير العرض التقديمي كإطارات](/slides/ar/cpp/convert-powerpoint-to-video/) وتشفيرها إلى فيديو (مثلاً باستخدام ffmpeg)، مع اختيار عدد الإطارات في الثانية (FPS) والدقة. تُشغل الرسوم المتحركة وانتقالات الشرائح أثناء التصدير.

**هل ستبقى الرسوم المتحركة سليمة عند العمل مع ODP (ليس فقط PPTX)؟**

تُدعم صيغ PPT وPPTX وODP لل[قراءة](/slides/ar/cpp/open-presentation/) و[كتابة](/slides/ar/cpp/save-presentation/)، ولكن هذا لا يضمن الحفاظ على الرسوم المتحركة. قد تُفقد بيانات الرسوم المتحركة المخصصة عند التحويل إلى ODP. راجع [Custom Animation](/slides/ar/cpp/custom-animation/) للحصول على أمثلة وإرشادات حول التحقق من توافق الصيغة.