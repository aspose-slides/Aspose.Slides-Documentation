---
title: تعزيز عروض PowerPoint بالرسوم المتحركة في Python
linktitle: رسوم PowerPoint المتحركة
type: docs
weight: 150
url: /ar/python-net/powerpoint-animation/
keywords:
- إضافة حركة
- تحديث الحركة
- تغيير الحركة
- إزالة الحركة
- إدارة الحركة
- التحكم في الحركة
- تأثير الحركة
- رسوم PowerPoint المتحركة
- خط زمني للحركة
- رسوم متحركة تفاعلية
- رسوم متحركة مخصصة
- رسومات متحركة للأشكال
- مخطط متحرك
- نص متحرك
- شكل متحرك
- كائن OLE متحرك
- صورة متحركة
- جدول متحرك
- عرض PowerPoint
- Python
- Aspose.Slides
description: "استكشف قدرات Aspose.Slides للـ Python عبر .NET في التعامل مع رسوم PowerPoint المتحركة. يسلط هذا النظرة العامة الضوء على الميزات الرئيسية ويقدم رؤى لتعزيز عروضك التقديمية."
---
## **المقدمة**

تم تصميم العروض لتوصيل المعلومات، لذا فإن مظهرها البصري وسلوكها التفاعلي هما اعتباران أساسيان أثناء الإنشاء.

**PowerPoint animation** يتولى دورًا مهمًا في جعل العرض جذابًا وملفًا للانتباه للمشاهدين. توفر Aspose.Slides for Python via .NET مجموعة واسعة من الخيارات لإضافة الرسوم المتحركة إلى عرض PowerPoint. يمكنك:

- تطبيق تأثيرات حركة متنوعة على الأشكال، المخططات، الجداول، كائنات OLE، وعناصر أخرى.
- استخدام تأثيرات حركة متعددة على شكل واحد.
- التحكم في التأثيرات عبر خط الزمن الخاص بالحركة.
- إنشاء رسوم متحركة مخصصة.

في Aspose.Slides for Python via .NET، يمكن تطبيق تأثيرات الحركة على الأشكال. لأن كل عنصر على الشريحة—بما في ذلك النصوص، الصور، كائنات OLE، والجداول—يُعامل كشكل، يمكنك تطبيق تأثيرات الحركة على أي عنصر على الشريحة.

مساحة الأسماء [aspose.slides.animation](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/) توفر الفئات للعمل مع رسوم PowerPoint المتحركة.

## **التثبيت**

```bash
pip install aspose.slides
```

## **إضافة تأثير حركة إلى شكل في Python**

تعيش تأثيرات الحركة على التسلسل الرئيسي لشريحة. أضف شكلًا، ثم استدعِ `add_effect` على `slide.timeline.main_sequence`، مع تمرير نوع التأثير، النوع الفرعي له، والمحفز الذي يبدأه.

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

يحتوي الملف المحفوظ على تأثير واحد في الشريحة الأولى: المستطيل يطير من اليسار خلال ثانيتين عند نقر المقدم. عند إعادة فتحه وقراءة `slide.timeline.main_sequence` يتم إرجاع ذلك التأثير، وبالتالي يبقى الحركة محفوظة عبر الجولة وليس فقط في الذاكرة.

## **تأثيرات الحركة**

يدعم Aspose.Slides **150+ animation effects**، بما في ذلك التأثيرات الأساسية مثل Bounce وPathFootball وZoom، بالإضافة إلى التأثيرات المتخصصة مثل OLEObjectShow وOLEObjectOpen. يمكنك العثور على القائمة الكاملة في تعداد [EffectType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/effecttype/).

بالإضافة إلى ذلك، يمكن دمج هذه التأثيرات مع التأثيرات التالية:

- [ColorEffect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/seteffect/)

## **الرسوم المتحركة المخصصة**

للحصول على أمثلة Python كاملة تُنشئ، تفحص، وتعدل السلوكيات ومسارات الحركة القابلة للتحرير، راجع [الرسوم المتحركة المخصصة](/slides/ar/python-net/custom-animation/).

يمكنك إنشاء **رسوم متحركة مخصصة** في Aspose.Slides بدمج سلوكيات متعددة في تأثير واحد.

[Behavior](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/behavior/) هو بناء أساسي لتأثير حركة PowerPoint. دمج السلوكيات لتخصيص تأثير، أو إضافة سلوك لتوسيع تأثير مُعرّف مسبقًا. يتم تكوين التكرار عبر إعدادات التوقيت بدلًا من سلوك تكرار منفصل.

[Animation Point](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/point/) يحدد اللحظة أو الموقع الذي يُطبق فيه سلوك (إطار رئيسي).

## **خط زمني للرسوم المتحركة**

[Sequence](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/sequence/) هي مجموعة من تأثيرات الحركة التي يمكن أن تستهدف أشكالًا مختلفة.

[Timeline](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/animationtimeline/) هو مجموعة التسلسلات المستخدمة على شريحة معينة. تم تقديمه في PowerPoint 2002. في إصدارات PowerPoint السابقة، كان إضافة تأثيرات الحركة صعبًا وغالبًا ما يتطلب حلولًا بديلة. يستبدل Timeline الفئة القديمة `AnimationSettings` ويوفر نموذج كائن أوضح لحركة PowerPoint. يمكن لكل شريحة أن تحتوي على خط زمني واحد فقط للحركة.

## **الرسوم المتحركة التفاعلية**

[Trigger](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/effecttriggertype/) يتيح لك تعريف إجراءات المستخدم (مثل نقر زر) التي تبدأ حركة محددة. تمت إضافة المشغلات فقط في أحدث إصدارات PowerPoint.

## **رسوم متحركة للأشكال**

يسمح لك Aspose.Slides بتطبيق الرسوم المتحركة على الأشكال—مثل النصوص، المستطيلات، الخطوط، الإطارات، كائنات OLE، وأكثر.

{{% alert color="info" title="Note" %}}
Read more [**حول رسوم متحركة للأشكال**](/slides/ar/python-net/shape-animation/).
{{% /alert %}}

## **مخططات متحركة**

لإنشاء مخططات متحركة، استخدم نفس الفئات التي تستخدمها للأشكال. ومع ذلك، لا يمكن تطبيق رسوم PowerPoint المتحركة إلا على فئات المخطط أو سلاسل المخطط. يمكنك أيضًا تطبيق تأثير حركة على عنصر فئة فردي أو عنصر سلسلة.

{{% alert color="info" title="Note" %}}
Read more [**حول مخططات متحركة**](/slides/ar/python-net/animated-charts/).
{{% /alert %}}

## **نص متحرك**

بالإضافة إلى تحريك النص، يمكنك تطبيق حركة على فقرة.

{{% alert color="info" title="Note" %}}
Read more [**حول نص متحرك**](/slides/ar/python-net/animated-text/).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل سيتم الحفاظ على الرسوم المتحركة عند التصدير إلى PDF؟**

No. PDF is a static format, so animations and [slide transitions](/slides/ar/python-net/slide-transition/) don’t play. If you need motion, export to [HTML5](/slides/ar/python-net/export-to-html5/), [animated GIF](/slides/ar/python-net/convert-powerpoint-to-animated-gif/), or [video](/slides/ar/python-net/convert-powerpoint-to-video/) instead.

**هل يمكنني تحويل عرض تقديمي متحرك إلى فيديو والتحكم في معدل الإطارات وحجم الإطار؟**

Yes. You can [render the presentation as frames](/slides/ar/python-net/convert-powerpoint-to-video/) and encode them into a video (e.g., via ffmpeg), choosing the FPS and resolution. Animations and slide transitions are played during rendering.

**هل ستظل الرسوم المتحركة سليمة عند العمل مع ODP (وليس فقط PPTX)؟**

PPT, PPTX, and ODP are supported for [reading](/slides/ar/python-net/open-presentation/) and [writing](/slides/ar/python-net/save-presentation/), but this does not guarantee animation preservation. Custom animation data can be lost when converting to ODP. See [Custom Animation](/slides/ar/python-net/custom-animation/) for examples and guidance on checking format compatibility.