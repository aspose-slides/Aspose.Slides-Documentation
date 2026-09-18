---
title: "تعزيز عروض PowerPoint التقديمية بالحركات في .NET"
linktitle: "حركة PowerPoint"
type: docs
weight: 150
url: /ar/net/powerpoint-animation/
keywords:
- إضافة حركة
- تحديث حركة
- تغيير حركة
- إزالة حركة
- إدارة حركة
- تحكم في الحركة
- تأثير الحركة
- حركة PowerPoint
- خط زمني للحركة
- حركة تفاعلية
- حركة مخصصة
- حركة الأشكال
- مخطط متحرك
- نص متحرك
- شكل متحرك
- كائن OLE متحرك
- صورة متحركة
- جدول متحرك
- عرض PowerPoint تقديمي
- .NET
- C#
- Aspose.Slides
description: "استكشف قدرات Aspose.Slides ل‏.NET في التعامل مع حركات PowerPoint. يسلط هذا النظرة العامة الضوء على الميزات الرئيسية ويوفر رؤى لتعزيز عروضك التقديمية."
---
## **المقدمة**

نظرًا لأن العروض التقديمية تهدف إلى تقديم شيء ما، فإن المظهر البصري والسلوك التفاعلي دائمًا ما يُؤخذ في الاعتبار أثناء الإنشاء.

**PowerPoint animation** يلعب دورًا مهمًا في جعل العرض التقديمي جذابًا ومشوقًا للمشاهدين. توفر Aspose.Slides for .NET مجموعة واسعة من الخيارات لإضافة حركات إلى عروض PowerPoint:

- تطبيق أنواع مختلفة من تأثيرات حركات PowerPoint على الأشكال، والرسوم البيانية، والجداول، وكائنات OLE، وعناصر أخرى في العرض.
- استخدام تأثيرات حركات PowerPoint متعددة على شكل واحد.
- الاستفادة من مخطط زمني للرسوم المتحركة للتحكم في تأثيرات الحركات.
- إنشاء حركات مخصصة.

في Aspose.Slides for .NET، يمكن تطبيق تأثيرات حركية مختلفة على الأشكال. نظرًا لأن كل عنصر على الشريحة، بما في ذلك النصوص، والصور، وكائنات OLE، والجداول، يُعتبر شكلاً، يمكن تطبيق تأثيرات الحركية على أي عنصر في الشريحة.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/) النطاق يوفر فئات للعمل مع حركات PowerPoint.

## **تأثيرات الحركة**

Aspose.Slides يدعم **أكثر من 150 تأثير حركة**، بما في ذلك التأثيرات الأساسية مثل Bounce وPathFootball وZoom، بالإضافة إلى تأثيرات محددة مثل OLEObjectShow وOLEObjectOpen. يمكنك العثور على قائمة كاملة بالتأثيرات في تعداد [EffectType](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/effecttype).

بالإضافة إلى ذلك، يمكن استخدام هذه التأثيرات الحركية مع ما يلي:
- [ColorEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/seteffect)

## **حركة مخصصة**

للحصول على أمثلة C# كاملة تنشئ وتفحص وتعدّل السلوكيات ومسارات الحركة القابلة للتعديل، راجع [Custom Animation](/slides/ar/net/custom-animation/).

يمكن إنشاء **حركات مخصصة** خاصة بك في Aspose.Slides. يمكن تحقيق ذلك بدمج عدة سلوكيات معًا في حركة مخصصة جديدة.

[Behavior](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/behavior) هو وحدة بناء لتأثير حركة PowerPoint. امزج السلوكيات لتخصيص تأثير، أو أضف سلوكًا لتوسيع تأثير معرف مسبقًا. يتم تكوين التكرار عبر إعدادات التوقيت بدلاً من سلوك تكرار منفصل.

[Animation Point](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/point) هو نقطة يُطبق عندها سلوك معين.

## **خط الزمن للرسوم المتحركة**

[Sequence](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/sequence) هي مجموعة من تأثيرات الرسوم المتحركة التي يمكن أن تستهدف أشكالًا مختلفة.

[Timeline](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/animationtimeline) هو مجموعة من التسلسلات المستخدمة في شريحة محددة. وهو محرك الرسوم المتحركة الذي تم تقديمه في PowerPoint 2002. في الإصدارات السابقة من PowerPoint، كان إضافة تأثيرات الحركة إلى العروض صعبًا ولا يمكن تحقيقه إلا من خلال حلول بديلة متعددة. يحل الخط الزمني محل فئة AnimationSettings القديمة ويوفر نموذج كائن أوضح لحركات PowerPoint. يمكن أن تحتوي الشريحة على خط زمن واحد فقط.

## **الرسوم المتحركة التفاعلية**

[Trigger](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/effecttriggertype) يتيح لك تعريف إجراءات المستخدم (مثل نقرة زر) التي ستبدأ حركة معينة. تم تقديم المشغلات في أحدث إصدارات PowerPoint.

## **حركة الأشكال**

يسمح لك Aspose.Slides بتطبيق الرسوم المتحركة على الأشكال، والتي يمكن أن تشمل النصوص، المستطيلات، الخطوط، الإطارات، كائنات OLE، وغير ذلك.

{{% alert color="info" title="Note" %}}
اقرأ المزيد [**About Shape Animation**](/slides/ar/net/shape-animation/).
{{% /alert %}}

## **الرسوم البيانية المتحركة**

لإنشاء رسوم بيانية متحركة، يجب عليك استخدام نفس الفئات المستخدمة للأشكال. ومع ذلك، لا يمكن تطبيق رسوم PowerPoint المتحركة إلا على فئات المخطط أو سلسلة المخطط. يمكنك أيضًا تطبيق تأثيرات الحركة على عنصر فئة أو عنصر سلسلة.

{{% alert color="info" title="Note" %}}
اقرأ المزيد [**About Animated Charts**](/slides/ar/net/animated-charts/).
{{% /alert %}}

## **نص متحرك**

بالإضافة إلى تحريك النص، يمكنك تطبيق الحركة على فقرة.

{{% alert color="info" title="Note" %}}
اقرأ المزيد [**About Animated Text**](/slides/ar/net/animated-text/).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل سيتم الحفاظ على الحركات عند التصدير إلى PDF؟**

لا. PDF هو تنسيق ثابت، لذا لا تُشغل الحركات و[slide transitions](/slides/ar/net/slide-transition/). إذا كنت بحاجة إلى حركة، صدّر إلى [HTML5](/slides/ar/net/export-to-html5/)، [animated GIF](/slides/ar/net/convert-powerpoint-to-animated-gif/)، أو [video](/slides/ar/net/convert-powerpoint-to-video/) بدلاً من ذلك.

**هل يمكنني تحويل عرض تقديمي متحرك إلى فيديو والتحكم في معدل الإطارات وحجم الإطار؟**

نعم. يمكنك [render the presentation as frames](/slides/ar/net/convert-powerpoint-to-video/) وترميزها إلى فيديو (مثلاً باستخدام ffmpeg)، مع اختيار عدد الإطارات في الثانية (FPS) والدقة. تُشغل الحركات وانتقالات الشرائح أثناء عملية التصيير.

**هل ستظل الحركات سليمة عند العمل مع ODP (ليس فقط PPTX)؟**

يتم دعم PPT وPPTX وODP لل[reading](/slides/ar/net/open-presentation/) و[writing](/slides/ar/net/save-presentation/)، لكن هذا لا يضمن الحفاظ على الحركات. قد يتم فقدان بيانات الحركات المخصصة عند التحويل إلى ODP. راجع [Custom Animation](/slides/ar/net/custom-animation/) للحصول على مثال مختبر وقيود الصيغة.