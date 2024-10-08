---
title: رسوم متحركة في PowerPoint
type: docs
weight: 150
url: /ar/php-java/powerpoint-animation/
keywords: "رسوم متحركة في PowerPoint"
description: "رسوم متحركة في PowerPoint، رسوم متحركة لشريحة PowerPoint مع Aspose.Slides."
---

نظرًا لأن العروض التقديمية تهدف إلى تقديم شيء ما، يتم دائمًا مراعاة مظهرها البصري وسلوكها التفاعلي أثناء إنشائها.

**رسوم متحركة في PowerPoint** تلعب دورًا مهمًا لجعل العرض التقديمي جذابًا ولافتًا للنظر للمشاهدين. تقدم Aspose.Slides لـ PHP عبر Java مجموعة واسعة من الخيارات لإضافة الرسوم المتحركة إلى عرض PowerPoint:

- تطبيق أنواع مختلفة من تأثيرات الرسوم المتحركة في PowerPoint على الأشكال، الرسوم البيانية، الجداول، كائنات OLE وعناصر العرض الأخرى.
- استخدام تأثيرات ترقيعية متعددة على شكل واحد.
- استخدام الجدول الزمني للرسوم المتحركة للتحكم في تأثيرات الرسوم المتحركة.
- إنشاء رسوم متحركة مخصصة.

في Aspose.Slides لـ PHP عبر Java، يمكن تطبيق تأثيرات الرسوم المتحركة المختلفة على الأشكال. حيث أن كل عنصر على الشريحة بما في ذلك النص، الصور، كائن OLE، الجدول، إلخ يعتبر شكلًا، يعني ذلك أننا يمكننا تطبيق تأثير الرسوم المتحركة على كل عنصر من عناصر الشريحة.

## **تأثيرات الرسوم المتحركة**
تدعم Aspose.Slides أكثر من **150 تأثيرًا للرسوم المتحركة**، بما في ذلك تأثيرات الرسوم المتحركة الأساسية مثل Bounce، PathFootball، تأثير Zoom وتأثيرات الرسوم المتحركة الخاصة مثل OLEObjectShow، OLEObjectOpen. يمكنك العثور على قائمة كاملة من تأثيرات الرسوم المتحركة في [**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype) التعداد.

بالإضافة إلى ذلك، يمكن استخدام هذه التأثيرات في مجموعة مع هذه:

- [ColorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/php-java/aspose.slides/SetEffect)

## **الرسوم المتحركة المخصصة**
من الممكن إنشاء **رسوم متحركة مخصصة** في Aspose.Slides.
يمكن تحقيق ذلك إذا قمت بدمج عدة سلوكيات معًا في رسوم متحركة مخصصة جديدة.

[**السلوك**](https://reference.aspose.com/slides/php-java/aspose.slides/Behavior) هو وحدة بناء أي تأثير رسوم متحركة في PowerPoint. جميع تأثيرات الرسوم المتحركة هي في الواقع مجموعة من السلوكيات المجمعة في استراتيجية واحدة. يمكنك دمج السلوكيات في رسوم متحركة مخصصة مرة واحدة وإعادة استخدامها في عروض تقديمية أخرى. إذا أضفت سلوكًا جديدًا إلى تأثير الرسوم المتحركة القياسي في PowerPoint - فسيكون ذلك رسومًا متحركة مخصصة أخرى. على سبيل المثال، يمكنك إضافة سلوك التكرار إلى الرسوم المتحركة لجعلها تتكرر عدة مرات.

[**نقطة الرسوم المتحركة**](https://reference.aspose.com/slides/php-java/aspose.slides/Point) هي نقطة يجب تطبيق السلوك عليها.

## **جدول الزمن للرسوم المتحركة**
[**التسلسل**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) هو مجموعة من تأثيرات الرسوم المتحركة التي تطبق على شكل معين.

[**الجدول الزمني**](https://reference.aspose.com/slides/php-java/aspose.slides/AnimationTimeLine) هو مجموعة من التسلسلات المستخدمة في شريحة معينة. إنه محرك الرسوم المتحركة الذي تم تمثيله منذ PowerPoint 2002. في إصدارات PowerPoint السابقة، كان من الصعب إضافة تأثيرات الرسوم المتحركة إلى العرض التقديمي، مما كان ممكنًا فقط من خلال حلول بديلة مختلفة. يأتي الجدول الزمني ليحل محل فئة AnimationSettings القديمة ويوفر نموذج كائن أكثر وضوحًا للرسوم المتحركة في PowerPoint. يمكن أن تحتوي الشريحة على جدول زمني واحد فقط للرسوم المتحركة.

## **الرسوم المتحركة التفاعلية**
[**المحفز**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectTriggerType) يسمح بتحديد إجراءات المستخدم (مثل النقر على الزر)، التي ستبدأ رسومًا متحركة معينة. تمت إضافة المحفزات إلى أحدث إصدار من PowerPoint فقط.

## **رسوم متحركة للأشكال**
تسمح Aspose.Slides بتطبيق الرسوم المتحركة على الأشكال، والتي يمكن أن تكون في الواقع نصًا، مستطيلًا، خطًا، إطارًا، كائن OLE، إلخ.

{{% alert color="primary" %}} 
اقرأ المزيد [**عن رسوم متحركة الأشكال**](/slides/ar/php-java/shape-animation/).
{{% /alert %}}

## **الرسوم البيانية المتحركة**
لإنشاء رسوم بيانية متحركة، يجب استخدام نفس الفئات المستخدمة للأشكال. ومع ذلك، من الممكن استخدام الرسوم المتحركة في PowerPoint فقط على فئات الرسوم البيانية أو سلسلة الرسوم البيانية. يمكنك أيضًا تطبيق تأثير الرسوم المتحركة على عنصر الفئة أو عنصر السلسلة.

{{% alert color="primary" %}} 
اقرأ المزيد [**عن الرسوم البيانية المتحركة**](/slides/ar/php-java/animated-charts/).
{{% /alert %}}

## **النص المتحرك**
باستثناء النص المتحرك، من الممكن أيضًا تطبيق الرسوم المتحركة على فقرة.

{{% alert color="primary" %}} 
اقرأ المزيد [**عن النص المتحرك**](/slides/ar/php-java/animated-text/).
{{% /alert %}}