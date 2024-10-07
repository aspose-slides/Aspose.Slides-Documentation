---
title: رسوم متحركة في PowerPoint
type: docs
weight: 150
url: /cpp/powerpoint-animation/
keywords: "رسوم متحركة في PowerPoint"
description: "رسوم متحركة في PowerPoint، رسوم متحركة في شرائح PowerPoint باستخدام Aspose.Slides."
---

نظرًا لأن العروض التقديمية تهدف إلى تقديم شيء ما، فإن مظهرها البصري وسلوكها التفاعلي يؤخذان دائمًا في الاعتبار أثناء إنشائها.

**رسوم متحركة PowerPoint** تلعب دورًا مهمًا لجعل العرض التقديمي جذابًا وجذابًا للمشاهدين. توفر Aspose.Slides لـ C++ مجموعة واسعة من الخيارات لإضافة الرسوم المتحركة إلى العرض التقديمي لـ PowerPoint:

- تطبيق أنواع مختلفة من تأثيرات الرسوم المتحركة في PowerPoint على الأشكال والرسوم البيانية والجداول وكائنات OLE وغيرها من عناصر العرض التقديمي.
- استخدام تأثيرات الرسوم المتحركة المتعددة على شكل واحد.
- استخدام جدول زمني للرسوم المتحركة للتحكم في تأثيرات الرسوم المتحركة.
- إنشاء رسوم متحركة مخصصة.

في Aspose.Slides لـ C++، يمكن تطبيق تأثيرات الرسوم المتحركة المختلفة على الأشكال. حيث أن كل عنصر على الشريحة بما في ذلك النص والصور وكائن OLE والجداول يتم اعتباره شكلًا، فهذا يعني أنه يمكننا تطبيق تأثير الرسوم المتحركة على كل عنصر في الشريحة.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation) **namespace** يوفر فئات للعمل مع رسوم متحركة PowerPoint.
## **تأثيرات الرسوم المتحركة**
تدعم Aspose.Slides **150+ تأثيرات متحركة**، بما في ذلك تأثيرات الرسوم المتحركة الأساسية مثل Bounce وPathFootball وتأثير Zoom وتأثيرات الرسوم المتحركة المحددة مثل OLEObjectShow وOLEObjectOpen. يمكنك العثور على قائمة كاملة بتأثيرات الرسوم المتحركة في [**EffectType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) التعداد.

بالإضافة إلى ذلك، يمكن استخدام هذه التأثيرات المتحركة مع بعضها:

- [ColorEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.color_effect/t)
- [CommandEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.set_effect)

## **الرسوم المتحركة المخصصة**
من الممكن إنشاء **رسوم متحركة مخصصة** خاصة بك في Aspose.Slides. 
يمكن تحقيق ذلك إذا قمت بدمج عدة سلوكيات معًا في رسوم متحركة مخصصة جديدة.

[**Behavior**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.behavior) هي وحدة بناء لأي تأثير من تأثيرات الرسوم المتحركة في PowerPoint. جميع تأثيرات الرسوم المتحركة هي في الواقع مجموعة من السلوكيات المكونة في استراتيجية واحدة. يمكنك دمج السلوكيات في رسوم متحركة مخصصة مرة واحدة وإعادة استخدامها في عروض تقديمية أخرى. إذا قمت بإضافة سلوك جديد إلى تأثير الرسوم المتحركة القياسي في PowerPoint - فسيكون رسوم متحركة مخصصة أخرى. على سبيل المثال، يمكنك إضافة سلوك التكرار إلى الرسوم المتحركة لجعلها تتكرر عدة مرات.

[**Animation Point**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.point) هي نقطة يجب تطبيق السلوك عليها.

## **جدول زمني للرسوم المتحركة**
[**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) هي مجموعة من تأثيرات الرسوم المتحركة، تطبق على شكل معين.

[**AnimationTimeLine**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.animation_time_line) هي مجموعة من التسلسلات المستخدمة في شريحة معينة. إنها محرك الرسوم المتحركة الممثل منذ PowerPoint 2002. في إصدارات PowerPoint السابقة، كان من الصعب إضافة تأثيرات الرسوم المتحركة إلى العرض التقديمي، وهو ما كان يمكنك تحقيقه فقط مع حلول تفصيلية مختلفة. يأتي الجدول الزمني ليحل محل فئة AnimationSettings القديمة ويوفر نموذج كائن أكثر وضوحًا لرسوم متحركة PowerPoint. يمكن أن تحتوي الشريحة الواحدة على جدول زمني للرسوم المتحركة واحد فقط.
## **الرسوم المتحركة التفاعلية**
[**EffectTriggerType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) يسمح بتحديد إجراءات المستخدم (مثل النقر على الزر) التي ستؤدي إلى بدء رسوم متحركة معينة. تمت إضافة المحفزات فقط في أحدث إصدار من PowerPoint.

## **رسوم متحركة للأشكال**
تسمح Aspose.Slides بتطبيق الرسوم المتحركة على الأشكال، التي يمكن أن تكون في الواقع نصًا، أو مستطيلًا، أو خطًا، أو إطارًا، أو كائن OLE، وما إلى ذلك.

{{% alert color="primary" %}} 
اقرأ المزيد [**حول رسوم متحركة الأشكال**](/slides/cpp/shape-animation/).
{{% /alert %}}

## **الرسوم البيانية المتحركة**
لإنشاء رسوم بيانية متحركة، يجب عليك استخدام نفس الفئات كما في الأشكال. ومع ذلك، من الممكن استخدام الرسوم المتحركة في PowerPoint فقط على فئات الرسوم البيانية أو سلسلة الرسوم البيانية. يمكنك أيضًا تطبيق تأثير الرسوم المتحركة على عنصر فئة أو عنصر سلسلة.

{{% alert color="primary" %}} 
اقرأ المزيد [**حول الرسوم البيانية المتحركة**](/slides/cpp/animated-charts/).
{{% /alert %}}

## **النص المتحرك**
باستثناء النص المتحرك، من الممكن أيضًا تطبيق الرسوم المتحركة على فقرة.

{{% alert color="primary" %}} 
اقرأ المزيد [**حول النص المتحرك**](/slides/cpp/animated-text/).
{{% /alert %}}