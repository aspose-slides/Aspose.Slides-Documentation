---
title: إدارة انتقالات الشرائح في العروض التقديمية باستخدام بايثون
linktitle: انتقال الشريحة
type: docs
weight: 90
url: /ar/python-net/slide-transition/
keywords:
- انتقال الشريحة
- إضافة انتقال الشريحة
- تطبيق انتقال الشريحة
- انتقال شريحة متقدم
- انتقال مورف
- نوع الانتقال
- تأثير الانتقال
- بايثون
- Aspose.Slides
description: اكتشف كيفية تخصيص انتقالات الشرائح في Aspose.Slides للغة بايثون عبر .NET، مع إرشادات خطوة بخطوة لعروض PowerPoint وOpenDocument.
---

## **نظرة عامة**

توفر Aspose.Slides للغة بايثون تحكمًا كاملاً في انتقالات الشرائح، من اختيار نوع الانتقال إلى تكوين التوقيت والمحفزات كجزء من سير عمل العروض التقديمية المؤتمتة. يمكنك ضبط الشرائح لتتقدم عند النقر و/أو بعد تأخير محدد وتحسين السلوك البصري باستخدام تأثيرات مثل القطع من السواد أو الدخول من اتجاهات معينة. كما تدعم المكتبة انتقال Morph الذي تم تقديمه في PowerPoint 2019، بما في ذلك الأنماط التي تتحول حسب الكائن أو الكلمة أو الحرف لإنشاء حركة سلسة ومترابطة بين الشرائح.

## **إضافة انتقالات الشرائح**

لتسهيل الفهم، يوضح هذا المثال كيفية استخدام Aspose.Slides للغة بايثون لإدارة انتقالات شرائح بسيطة. يمكن للمطورين تطبيق تأثيرات انتقال مختلفة على الشرائح وتخصيص سلوكها. لإنشاء انتقال شريحة بسيط، اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. تطبيق انتقال شريحة باستخدام أحد التأثيرات من تعداد [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/).
1. حفظ ملف العرض المعدل.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لتحميل ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:
    # تطبيق انتقال دائرة على الشريحة 1.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # تطبيق انتقال مشط على الشريحة 2.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **إضافة انتقالات شرائح متقدمة**

في هذا القسم، طبقنا تأثير انتقال بسيط على شريحة. لجعل هذا التأثير أكثر تحكمًا وصقلًا، اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. تطبيق انتقال شريحة باستخدام أحد التأثيرات من تعداد [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/).
1. تكوين الانتقال للتقدم عند النقر، بعد فترة زمنية محددة، أو كليهما.
1. حفظ ملف العرض المعدل.

إذا تم تمكين **التقدم عند النقر**، تتقدم الشريحة فقط عندما ينقر المستخدم. إذا تم ضبط خاصية **التقدم بعد الوقت**، تتقدم الشريحة تلقائيًا بعد الفاصل المحدد.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لفتح ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # تطبيق انتقال دائرة على الشريحة 1.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # تمكين التقدم عند النقر وتعيين تقدم تلقائي لمدة 3 ثوانٍ.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # تطبيق انتقال مشط على الشريحة 2.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # تمكين التقدم عند النقر وتعيين تقدم تلقائي لمدة 5 ثوانٍ.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # تطبيق انتقال تكبير على الشريحة 3.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # تمكين التقدم عند النقر وتعيين تقدم تلقائي لمدة 7 ثوانٍ.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **انتقال مورف**

تدعم Aspose.Slides للغة بايثون [انتقال Morph](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/)، والذي يحرك الانتقال السلس من شريحة إلى أخرى. يشرح هذا القسم كيفية استخدام انتقال Morph. لاستخدامه بفعالية، تحتاج إلى شريحتين مع كائن واحد على الأقل مشترك. أسهل طريقة هي استنساخ شريحة ثم نقل الكائن إلى موقع مختلف في الشريحة الثانية.

يظهر المقتطف التالي كيفية استنساخ شريحة تحتوي على نص وتطبيق انتقال Morph على الشريحة الثانية.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # استنساخ الشريحة الأولى لإنشاء شريحة ثانية بنفس الأشكال لاستمرارية Morph.
    slide1 = presentation.slides.add_clone(slide0)

    # اختيار نفس المستطيل على الشريحة الثانية وتغيير موقعه وحجمه.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # تمكين انتقال Morph على الشريحة الثانية لت animate تغييرات الشكل بسلاسة.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **أنواع انتقال مورف**

يمثل تعداد [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) الأنماط المختلفة لانتقالات شرائح Morph.

يظهر المقتطف التالي كيفية تطبيق انتقال Morph على شريحة وتغيير نوع morph:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين تأثيرات الانتقال**

تتيح لك Aspose.Slides للغة بايثون تعيين تأثيرات انتقال مثل **From Black**، **From Left**، **From Right**، إلخ. لتكوين تأثير الانتقال، اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع إلى الشريحة.
1. تعيين تأثير الانتقال المطلوب.
1. حفظ العرض كملف PPTX.

في المثال أدناه، قمنا بتعيين عدة تأثيرات انتقال.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لفتح ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # تطبيق انتقال قطع وتمكين From Black.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟**

نعم. قم بتعيين [السرعة] لانتقال الشريحة باستخدام إعداد [TransitionSpeed] (مثلاً بطيء/متوسط/سريع).

**هل يمكنني إرفاق صوت بالانتقال وجعله يتكرر؟**

نعم. يمكنك تضمين صوت للانتقال والتحكم في سلوكه عبر إعدادات مثل وضع الصوت وإعادة التكرار (مثلاً [sound]، [sound_mode]، [sound_loop]، بالإضافة إلى بيانات وصفية مثل [sound_is_built_in] و[sound_name]).

**ما هي أسرع طريقة لتطبيق نفس الانتقال على كل شريحة؟**

قم بتهيئة نوع الانتقال المطلوب في إعدادات انتقال كل شريحة؛ حيث يتم تخزين الانتقالات لكل شريحة، لذا تطبيق نفس النوع على جميع الشرائح يؤدي إلى نتيجة متسقة.

**كيف يمكنني التحقق من نوع الانتقال الحالي المحدد على شريحة؟**

افحص [إعدادات الانتقال] الخاصة بالشريحة واقرأ [نوع الانتقال]؛ هذه القيمة تخبرك بالضبط أي تأثير تم تطبيقه.