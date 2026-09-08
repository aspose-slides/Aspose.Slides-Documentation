---
title: تعزيز عروض PowerPoint التقديمية بالحركات في Python عبر Java
linktitle: حركة PowerPoint
type: docs
weight: 150
url: /ar/python-java/powerpoint-animation/
keywords:
- إضافة حركة
- تحديث حركة
- تغيير حركة
- إزالة حركة
- إدارة حركة
- التحكم في الحركة
- تأثير الحركة
- حركة PowerPoint
- خط زمني للحركة
- حركة تفاعلية
- حركة مخصصة
- حركة الشكل
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
description: "استكشف قدرات Aspose.Slides لـ Python عبر Java في التعامل مع حركات PowerPoint. يقدم هذا الملخص العام أهم الميزات ويوفر رؤى لتحسين عروضك التقديمية."
---
## **المقدمة**

نظرًا لأن العروض التقديمية تهدف إلى عرض شيء ما، فإن المظهر البصري والسلوك التفاعلي دائمًا ما يُؤخذ في الاعتبار أثناء الإنشاء.

**حركة PowerPoint** تلعب دورًا مهمًا في جعل العرض التقديمي جذابًا ومشوقًا للمشاهدين. توفر Aspose.Slides مجموعة واسعة من الخيارات لإضافة حركات إلى عروض PowerPoint:

- تطبيق أنواع مختلفة من تأثيرات حركة PowerPoint على الأشكال، المخططات، الجداول، كائنات OLE، وعناصر العرض الأخرى.
- استخدام تأثيرات حركة متعددة على شكل واحد.
- الاستفادة من خط الزمن للتحكم في تأثيرات الحركة.
- إنشاء حركات مخصصة.

في Aspose.Slides، يمكن تطبيق تأثيرات حركة متنوعة على الأشكال. نظرًا لأن كل عنصر على الشريحة، بما في ذلك النص، الصور، كائنات OLE، والجداول، يُعتبر شكلًا، يمكن تطبيق تأثيرات الحركة على أي عنصر في الشريحة.

## **تأثيرات الحركة**
يدعم Aspose.Slides **أكثر من 150 تأثير حركة**، بما في ذلك تأثيرات الحركة الأساسية مثل Bounce و PathFootball و Zoom وتأثيرات الحركة الخاصة مثل OLEObjectShow و OLEObjectOpen. يمكنك العثور على قائمة كاملة لتأثيرات الحركة في تعداد [EffectType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effecttype/).

بالإضافة إلى ذلك، يمكن دمج هذه تأثيرات الحركة مع:

- [ColorEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/seteffect/)

## **حركة مخصصة**
يمكنك إنشاء **حركات مخصصة** في Aspose.Slides. يمكن تحقيق ذلك إذا جمعت عدة سلوكيات معًا في حركة مخصصة جديدة.

[Behavior](https://reference.aspose.com/slides/ar/python-java/aspose.slides/behavior/) هو وحدة بناء أي تأثير حركة في PowerPoint. جميع تأثيرات الحركة هي في الواقع مجموعة من السلوكيات المكوّنة لاستراتيجية واحدة. يمكنك دمج السلوكيات في حركة مخصصة مرة واحدة وإعادة استخدامها في عروض تقديمية أخرى. إذا أضفت سلوكًا جديدًا إلى تأثير حركة PowerPoint قياسي، سيصبح ذلك حركة مخصصة أخرى. على سبيل المثال، يمكنك إضافة سلوك تكرار إلى حركة لجعلها تتكرر عدة مرات.

[Point](https://reference.aspose.com/slides/ar/python-java/aspose.slides/point/) هو النقطة التي يجب تطبيق السلوك عليها.

## **خط زمن الحركة**
[Sequence](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sequence/) هو مجموعة من تأثيرات الحركة، تُطبق على شكل محدد.

[AnimationTimeLine](https://reference.aspose.com/slides/ar/python-java/aspose.slides/animationtimeline/) هو مجموعة من الـ Sequences تُستخدم في شريحة محددة. يمثل هذا محرك الحركة منذ PowerPoint 2002. في إصدارات PowerPoint السابقة، كان من الصعب إضافة تأثيرات حركة إلى العرض، وكان ذلك ممكنًا فقط عبر حلول بديلة مختلفة. يأتي خط الزمن كبديل لفئة AnimationSettings القديمة ويوفر نموذج كائن أوضح لحركة PowerPoint. يمكن أن تحتوي الشريحة الواحدة على **خط زمن حركة واحد فقط**.

## **الحركة التفاعلية**
[EffectTriggerType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effecttriggertype/) يسمح بتحديد إجراءات المستخدم (مثل النقر على زر) التي تجعل حركة معينة تبدأ. تمت إضافة المشغلات فقط في أحدث نسخة من PowerPoint.

## **حركة الشكل**
تتيح Aspose.Slides تطبيق الحركة على الأشكال، التي قد تكون نصًا، مستطيلًا، خطًا، إطارًا، كائن OLE، إلخ.

{{% alert color="info" title="ملاحظة" %}} 
اقرأ المزيد [About Shape Animation](/slides/ar/python-java/shape-animation/).
{{% /alert %}}

## **المخططات المتحركة**
لإنشاء مخططات متحركة، يجب استخدام نفس الفئات المستخدمة للأشكال. ومع ذلك، يمكن تطبيق حركة PowerPoint فقط على فئات المخطط أو سلاسل المخطط. يمكنك أيضًا تطبيق تأثير حركة على عنصر فئة أو عنصر سلسلة.

{{% alert color="info" title="ملاحظة" %}} 
اقرأ المزيد [About Animated Charts](/slides/ar/python-java/animated-charts/).
{{% /alert %}}

## **النص المتحرك**
إلى جانب النص المتحرك، يمكن أيضًا تطبيق الحركة على فقرة.

{{% alert color="info" title="ملاحظة" %}} 
اقرأ المزيد [About Animated Text](/slides/ar/python-java/animated-text/).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل سيتم الحفاظ على الحركات عند التصدير إلى PDF؟**
لا. PDF هو تنسيق ثابت، لذا لا تُشغل الحركات و[انتقالات الشرائح](/slides/ar/python-java/slide-transition/). إذا كنت بحاجة إلى حركة، صدّر إلى [HTML5](/slides/ar/python-java/export-to-html5/)، [GIF متحرك](/slides/ar/python-java/convert-powerpoint-to-animated-gif/)، أو [فيديو](/slides/ar/python-java/convert-powerpoint-to-video/) بدلاً من ذلك.

**هل يمكنني تحويل عرض تقديمي متحرك إلى فيديو والتحكم في معدل الإطارات وحجم الإطار؟**
نعم. يمكنك [تصدير العرض كإطارات](/slides/ar/python-java/convert-powerpoint-to-video/) وترميزها إلى فيديو (مثلاً باستخدام ffmpeg)، مع اختيار عدد الإطارات في الثانية والدقة. تُشغل الحركات وانتقالات الشرائح أثناء التصدير.

**هل ستظل الحركات سليمة عند العمل مع ODP (وليس فقط PPTX)؟**
يتم دعم PPT وPPTX وODP لل[القراءة](/slides/ar/python-java/open-presentation/) و[الكتابة](/slides/ar/python-java/save-presentation/)، لكن اختلافات الصيغ قد تجعل بعض التأثيرات تبدو أو تتصرف بشكل مختلف قليلاً. تحقق من الحالات الحرجة باستخدام عينات حقيقية.