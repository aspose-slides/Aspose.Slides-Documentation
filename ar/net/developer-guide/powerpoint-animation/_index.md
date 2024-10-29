---
title: الرسوم المتحركة في PowerPoint
type: docs
weight: 150
url: /ar/net/powerpoint-animation/
keywords: "الرسوم المتحركة, تأثيرات الرسوم المتحركة, رسوم متحركة PowerPoint, الجدول الزمني للرسوم المتحركة, الرسوم المتحركة التفاعلية, رسوم متحركة الأشكال, الرسوم المتحركة للمخططات, النص المتحرك, عرض PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "رسوم متحركة وعناصر في عرض PowerPoint باستخدام C# أو .NET"
---

نظرًا لأن العروض التقديمية تهدف إلى عرض شيء ما، فإن مظهرها المرئي وسلوكها التفاعلي يتم اعتباره دائمًا أثناء إنشائها.

**تعتبر الرسوم المتحركة PowerPoint** أمرًا مهمًا لجعل العرض جذابًا ومثيرًا للاهتمام للمشاهدين. يوفر Aspose.Slides for .NET مجموعة واسعة من الخيارات لإضافة الرسوم المتحركة إلى عرض PowerPoint:

- تطبيق أنواع مختلفة من تأثيرات الرسوم المتحركة PowerPoint على الأشكال والمخططات والجداول والأشياء OLE وعناصر العرض الأخرى.
- استخدام تأثيرات الرسوم المتحركة المتعددة على شكل واحد.
- استخدام الجدول الزمني للرسوم المتحركة للسيطرة على تأثيرات الرسوم المتحركة.
- إنشاء رسوم متحركة مخصصة.

في Aspose.Slides for .NET، يمكن تطبيق تأثيرات الرسوم المتحركة المختلفة على الأشكال. حيث يتم اعتبار كل عنصر على الشريحة بما في ذلك النصوص والصور والأشياء OLE والجداول وما إلى ذلك كشكل، مما يعني أنه يمكننا تطبيق تأثير الرسوم المتحركة على كل عنصر في الشريحة.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/net/aspose.slides.animation/) **namespace** يوفر فئة للعمل مع الرسوم المتحركة PowerPoint.
## **تأثيرات الرسوم المتحركة**
يدعم Aspose.Slides **أكثر من 150 تأثير رسومي**، بما في ذلك تأثيرات الرسوم المتحركة الأساسية مثل نقلة، PathFootball، تأثير التكبير وتأثيرات الرسوم المتحركة المحددة مثل OLEObjectShow و OLEObjectOpen. يمكنك العثور على قائمة كاملة بتأثيرات الرسوم المتحركة في [**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype)التعداد.

بالإضافة إلى ذلك، يمكن استخدام تأثيرات الرسوم المتحركة هذه بالاقتران معها:

- [ColorEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/seteffect)
## **الرسوم المتحركة المخصصة**
من الممكن إنشاء **رسوم متحركة مخصصة** خاصة بك في Aspose.Slides. 
يمكن تحقيق ذلك إذا قمت بدمج عدة سلوكيات معًا في رسوم متحركة مخصصة جديدة.

[**السلوك**](https://reference.aspose.com/slides/net/aspose.slides.animation/behavior) هو وحدة بناء لأي تأثير رسومي PowerPoint. جميع تأثيرات الرسوم المتحركة هي في الواقع مجموعة من السلوكيات المركبة في استراتيجية واحدة. يمكنك دمج السلوكيات في رسوم متحركة مخصصة مرة واحدة وإعادة استخدامها في عروض تقديمية أخرى. إذا قمت بإضافة سلوك جديد إلى تأثير الرسوم المتحركة PowerPoint القياسي - ستصبح رسمًا متحركًا مخصصًا آخر. على سبيل المثال، يمكنك إضافة سلوك التكرار إلى الرسوم المتحركة لجعلها تتكرر عدة مرات.

[**نقطة الرسوم المتحركة**](https://reference.aspose.com/slides/net/aspose.slides.animation/point) هي النقطة التي يجب تطبيق السلوك فيها.
## **الجدول الزمني للرسوم المتحركة**
[**التسلسل**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) هو مجموعة من تأثيرات الرسوم المتحركة، المُطبقة على شكل معين.

[**الجدول الزمني**](https://reference.aspose.com/slides/net/aspose.slides.animation/animationtimeline) هو مجموعة من التسلسلات المستخدمة في شريحة معينة. إنها محرك الرسوم المتحركة المتاح منذ PowerPoint 2002. في الإصدار السابق من PowerPoint، كان من الصعب إضافة تأثيرات الرسوم المتحركة إلى العرض، مما كان يمكن تحقيقه فقط مع حلول مختلفة. جاء الجدول الزمني ليحل محل فئة AnimationSettings القديمة ويقدم نموذج كائن أكثر وضوحًا لرسوم متحركة PowerPoint. يمكن أن تحتوي شريحة واحدة على جدول زمني واحد فقط للرسوم المتحركة.
## **الرسوم المتحركة التفاعلية**
[**المشغل**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttriggertype) يتيح تعريف إجراءات المستخدم (مثل نقرة زر)، والتي ستجعل رسوم متحركة معينة تبدأ. تم إضافة المشغلات في أحدث إصدار من PowerPoint فقط.
## **رسوم متحركة الأشكال**
يسمح Aspose.Slides بتطبيق الرسوم المتحركة على الأشكال، التي يمكن أن تكون فعلًا نصًا أو مستطيلًا أو خطًا أو إطارًا أو كائن OLE، إلخ.

{{% alert color="primary" %}} 
اقرأ المزيد [**عن رسوم متحركة الأشكال**](/slides/ar/net/shape-animation/).
{{% /alert %}}

## **المخططات المتحركة**
لإنشاء مخططات متحركة، يجب عليك استخدام جميع الفئات نفسها كما هو الحال بالنسبة للأشكال. ومع ذلك، من الممكن استخدام الرسوم المتحركة PowerPoint فقط على فئات المخطط أو سلسلة المخطط. يمكنك أيضًا تطبيق تأثير الرسوم المتحركة على عنصر فئة أو عنصر سلسلة.

{{% alert color="primary" %}} 
اقرأ المزيد [**عن المخططات المتحركة**](/slides/ar/net/animated-charts/).
{{% /alert %}}

## **النص المتحرك**
بالإضافة إلى النص المتحرك، من الممكن أيضًا تطبيق الرسوم المتحركة على فقرة.

{{% alert color="primary" %}} 
اقرأ المزيد [**عن النص المتحرك**](/slides/ar/net/animated-text/).
{{% /alert %}}