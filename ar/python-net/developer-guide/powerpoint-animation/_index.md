---
title: "تعزيز عروض PowerPoint التقديمية باستخدام الرسوم المتحركة في Python"
linktitle: "رسوم PowerPoint المتحركة"
type: docs
weight: 150
url: /ar/python-net/powerpoint-animation/
keywords:
- "إضافة رسوم متحركة"
- "تحديث الرسوم المتحركة"
- "تغيير الرسوم المتحركة"
- "إزالة الرسوم المتحركة"
- "إدارة الرسوم المتحركة"
- "التحكم في الرسوم المتحركة"
- "تأثير الرسوم المتحركة"
- "رسوم PowerPoint المتحركة"
- "الجدول الزمني للرسوم المتحركة"
- "رسوم متحركة تفاعلية"
- "رسوم متحركة مخصصة"
- "رسوم متحركة للأشكال"
- "مخطط متحرك"
- "نص متحرك"
- "شكل متحرك"
- "كائن OLE متحرك"
- "صورة متحركة"
- "جدول متحرك"
- "عرض PowerPoint التقديمي"
- "Python"
- "Aspose.Slides"
description: "اكتشف قدرات Aspose.Slides لPython عبر .NET في معالجة رسوم PowerPoint المتحركة. تقدم هذه النظرة العامة لمحة عن الميزات الرئيسية وتوفر رؤى لتعزيز عروضك التقديمية."
---
## **المقدمة**

تم تصميم العروض التقديمية لنقل المعلومات، لذا فإن مظهرها البصري وسلوكها التفاعلي هما اعتبارات أساسية أثناء الإنشاء.

**PowerPoint animation** يلعب دورًا مهمًا في جعل العرض التقديمي جذابًا ومشوقًا للمشاهدين. توفر Aspose.Slides for Python via .NET مجموعة واسعة من الخيارات لإضافة الرسوم المتحركة إلى عرض PowerPoint. يمكنك:

- تطبيق تأثيرات رسوم متحركة متنوعة على الأ Shapes، المخططات، الجداول، كائنات OLE، والعناصر الأخرى.
- استخدام تأثيرات رسوم متحركة متعددة على شكل واحد.
- التحكم في التأثيرات عبر جدول زمني للرسوم المتحركة.
- إنشاء رسوم متحركة مخصصة.

في Aspose.Slides for Python via .NET، يمكن تطبيق تأثيرات الرسوم المتحركة على الأ Shapes. لأن كل عنصر على الشريحة — بما في ذلك النصوص، الصور، كائنات OLE، والجداول — يُعامل كشكل، يمكنك تطبيق تأثيرات الرسوم المتحركة على أي عنصر في الشريحة.

تقدم مساحة الاسم [aspose.slides.animation](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/) الفئات للعمل مع الرسوم المتحركة في PowerPoint.

## **التثبيت**

```bash
pip install aspose.slides
```

## **إضافة تأثير رسوم متحركة إلى شكل في Python**

تعيش تأثيرات الرسوم المتحركة ضمن التسلسل الرئيسي للشريحة. أضف شكلاً، ثم استدعِ `add_effect` على `slide.timeline.main_sequence`، مع تمرير نوع التأثير، النوع الفرعي له، والمحفز الذي يبدأه.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 100)
    shape.text_frame.text = "Animated shape"

    sequence = slide.timeline.main_sequence
    effect = sequence.add_effect(
        shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.LEFT,
        slides.animation.EffectTriggerType.ON_CLICK,
    )
    effect.timing.duration = 2.0

    presentation.save("animated.pptx", slides.export.SaveFormat.PPTX)
```

يحتوي الملف المحفوظ على تأثير واحد في الشريحة الأولى: المستطيل يتحرك من اليسار خلال ثانيتين عندما ينقر المقدم. عند إعادة فتحه وقراءة `slide.timeline.main_sequence` يتم إرجاع ذلك التأثير، لذا يبقى الرسوم المتحركة محفوظًا عبر الرحلة الكاملة وليس مجرد وجوده في الذاكرة.

## **تأثيرات الرسوم المتحركة**

يدعم Aspose.Slides **أكثر من 150 تأثيرًا للرسوم المتحركة**، بما في ذلك التأثيرات الأساسية مثل Bounce وPathFootball وZoom، فضلاً عن التأثيرات المتخصصة مثل OLEObjectShow وOLEObjectOpen. يمكنك العثور على القائمة الكاملة في تعداد [EffectType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/effecttype/).

بالإضافة إلى ذلك، يمكن دمج هذه التأثيرات المتحركة مع التأثيرات التالية:

- [ColorEffect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/seteffect/)

## **رسوم متحركة مخصصة**

يمكنك إنشاء **رسوم متحركة مخصصة** خاصة بك في Aspose.Slides عن طريق دمج سلوكيات متعددة في تأثير واحد.

[Behavior](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/behavior/) هو الوحدة الأساسية لأي تأثير رسومي في PowerPoint. كل تأثير رسوم متحركة هو في الأساس مجموعة من السلوكيات المرتبة في استراتيجية أو جدول زمني واحد. يمكنك تجميع السلوكيات في رسم متحرك مخصص مرة واحدة وإعادة استخدامها عبر عروض أخرى. إذا أضفت سلوكًا جديدًا إلى تأثير رسوم متحركة قياسي في PowerPoint، يصبح رسمًا متحركًا مخصصًا — على سبيل المثال، إضافة سلوك تكرار لجعل الرسوم المتحركة تُشغل عدة مرات.

[Animation Point](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/point/) يحدد اللحظة أو الموضع الذي يُطبق فيه سلوك (إطار رئيسي).

## **جدول زمني للرسوم المتحركة**

[Sequence](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/sequence/) هي مجموعة من تأثيرات الرسوم المتحركة المطبقة على شكل معين.

[Timeline](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/animationtimeline/) هي مجموعة التسلسلات المستخدمة على شريحة معينة. تم تقديمها في PowerPoint 2002. في الإصدارات السابقة من PowerPoint، كان إضافة تأثيرات الرسوم المتحركة صعبًا وغالبًا ما يتطلب حلولاً بديلة. يستبدل Timeline الفئة القديمة `AnimationSettings` ويوفر نموذج كائن أوضح للرسوم المتحركة في PowerPoint. يمكن لكل شريحة أن تحتوي على جدول زمني واحد فقط للرسوم المتحركة.

## **رسوم متحركة تفاعلية**

[Trigger](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/effecttriggertype/) يتيح لك تعريف إجراءات المستخدم (مثل نقر زر) التي تبدأ رسومًا متحركة معينة. تمت إضافة المشغلات فقط في أحدث إصدارات PowerPoint.

## **رسوم متحركة للأشكال**

يسمح لك Aspose.Slides بتطبيق رسوم متحركة على الأ Shapes — مثل النصوص، المستطيلات، الخطوط، الإطارات، كائنات OLE، وغيرها.

{{% alert color="primary" %}}
اقرأ المزيد [**حول رسوم متحركة للأشكال**](/slides/ar/python-net/shape-animation/).
{{% /alert %}}

## **مخططات متحركة**

لإنشاء مخططات متحركة، استخدم نفس الفئات التي تستخدمها للأشكال. ومع ذلك، يمكن تطبيق الرسوم المتحركة في PowerPoint فقط على فئات المخطط أو سلاسل المخطط. يمكنك أيضًا تطبيق تأثير رسوم متحركة على عنصر فئة فردي أو عنصر سلسلة.

{{% alert color="primary" %}}
اقرأ المزيد [**حول المخططات المتحركة**](/slides/ar/python-net/animated-charts/).
{{% /alert %}}

## **نص متحرك**

بالإضافة إلى تحريك النص، يمكنك تطبيق الرسوم المتحركة على فقرة.

{{% alert color="primary" %}}
اقرأ المزيد [**حول النص المتحرك**](/slides/ar/python-net/animated-text/).
{{% /alert %}}

## **الأسئلة الشائعة**

### هل ستظل الرسوم المتحركة محفوظة عند التصدير إلى PDF؟

لا. PDF هو تنسيق ثابت، لذا لا تُشغَّل الرسوم المتحركة و[تحولات الشرائح](/slides/ar/python-net/slide-transition/). إذا كنت بحاجة إلى حركة، صدِّر إلى [HTML5](/slides/ar/python-net/export-to-html5/)، أو [GIF متحرك](/slides/ar/python-net/convert-powerpoint-to-animated-gif/)، أو [فيديو](/slides/ar/python-net/convert-powerpoint-to-video/) بدلاً من ذلك.

### هل يمكنني تحويل عرض تقديمي متحرك إلى فيديو والتحكم في معدل الإطارات وحجم الإطار؟

نعم. يمكنك [تصدير العرض التقديمي كإطارات](/slides/ar/python-net/convert-powerpoint-to-video/) وترميزها إلى فيديو (مثلاً باستخدام ffmpeg)، مع اختيار عدد الإطارات في الثانية والدقة. تُشغل الرسوم المتحركة وتحولات الشرائح أثناء التصدير.

### هل ستبقى الرسوم المتحركة سليمة عند العمل مع ODP (وليست فقط PPTX)؟

يتم دعم PPT وPPTX وODP لل[قراءة](/slides/ar/python-net/open-presentation/) و[كتابة](/slides/ar/python-net/save-presentation/)، لكن الاختلافات في الصيغ تعني أن بعض التأثيرات قد تبدو أو تتصرف بشكل مختلف قليلًا. تحقق من الحالات الحرجة باستخدام عينات حقيقية.