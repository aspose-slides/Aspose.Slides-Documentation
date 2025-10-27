---
title: إدارة انتقالات الشرائح في العروض التقديمية باستخدام بايثون
linktitle: انتقال الشريحة
type: docs
weight: 90
url: /ar/python-net/slide-transition/
keywords:
- slide transition
- add slide transition
- apply slide transition
- advanced slide transition
- morph transition
- transition type
- transition effect
- Python
- Aspose.Slides
description: "اكتشف كيفية تخصيص انتقالات الشرائح في Aspose.Slides للبايثون عبر .NET، مع إرشادات خطوة بخطوة لعروض PowerPoint وOpenDocument."
---

## **نظرة عامة**

توفر Aspose.Slides للبايثون تحكمًا كاملًا في انتقالات الشرائح، بدءًا من اختيار نوع الانتقال إلى تكوين التوقيت والمحفزات كجزء من سير عمل العروض التقديمية المؤتمتة. يمكنك ضبط تقدم الشرائح عند النقر و/أو بعد تأخير محدد وتنعيم السلوك البصري بتأثيرات مثل القطع من اللون الأسود أو الدخول من اتجاه معين. تدعم المكتبة أيضًا انتقال Morph الذي تم تقديمه في PowerPoint 2019، بما في ذلك أوضاع التحول بحسب الكائن أو الكلمة أو الحرف لإنشاء حركة سلسة ومتناسقة بين الشرائح.

## **إضافة انتقالات الشرائح**

لتسهيل الفهم، يوضح هذا المثال كيفية استخدام Aspose.Slides للبايثون لإدارة انتقالات الشرائح البسيطة. يمكن للمطورين تطبيق تأثيرات انتقال مختلفة على الشرائح وتخصيص سلوكها. لإنشاء انتقال شريحة بسيط، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. تطبيق انتقال شريحة باستخدام أحد التأثيرات من تعداد [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) .
3. حفظ ملف العرض المعدل.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لتحميل ملف عرض.
with slides.Presentation("sample.pptx") as presentation:
    # تطبيق انتقال دائرة على الشريحة 1.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # تطبيق انتقال مشط على الشريحة 2.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # حفظ العرض إلى القرص.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **إضافة انتقالات شرائح متقدمة**

في هذا القسم، طبقنا تأثير انتقال بسيط على شريحة. لجعل هذا التأثير أكثر تحكمًا وأناقة، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. تطبيق انتقال شريحة باستخدام أحد التأثيرات من تعداد [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) .
3. تكوين الانتقال للتقدم عند النقر، أو بعد فترة زمنية محددة، أو كليهما.
4. حفظ ملف العرض المعدل.

إذا تم تمكين **Advance On Click**، فإن الشريحة تتقدم فقط عندما ينقر المستخدم. إذا تم ضبط خاصية **Advance After Time**، فإن الشريحة تتقدم تلقائيًا بعد الفاصل الزمني المحدد.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لفتح ملف عرض.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # تطبيق انتقال دائرة على الشريحة 1.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # تمكين التقدم عند النقر وضبط تقدم تلقائي بعد 3 ثوانٍ.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # تطبيق انتقال مشط على الشريحة 2.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # تمكين التقدم عند النقر وضبط تقدم تلقائي بعد 5 ثوانٍ.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # تطبيق انتقال تكبير على الشريحة 3.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # تمكين التقدم عند النقر وضبط تقدم تلقائي بعد 7 ثوانٍ.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # حفظ العرض إلى القرص.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **انتقال Morph**

يدعم Aspose.Slides للبايثون [انتقال Morph](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/)، الذي يحرك الانتقال السلس من شريحة إلى أخرى. يشرح هذا القسم كيفية استخدام انتقال Morph. لاستخدامه بشكل فعال، تحتاج إلى شريحتين تشتركان على كائن واحد على الأقل. أسهل طريقة هي تكرار شريحة ثم نقل الكائن إلى موضع مختلف في الشريحة الثانية.

المقتطف التالي يوضح كيفية استنساخ شريحة تحتوي على نص وتطبيق انتقال Morph على الشريحة الثانية.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # استنساخ الشريحة الأولى لإنشاء شريحة ثانية بنفس الأشكال لاستمرار Morph.
    slide1 = presentation.slides.add_clone(slide0)

    # تحديد نفس المستطيل في الشريحة الثانية وتغيير موقعه وحجمه.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # تمكين انتقال Morph على الشريحة الثانية لتحريك تغييرات الشكل بسلاسة.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **أنواع انتقال Morph**

يمثل تعداد [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) الأنواع المختلفة لانتقالات شرائح Morph.

المقتطف التالي يوضح كيفية تطبيق انتقال Morph على شريحة وتغيير نوع التحول:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ضبط مؤثرات الانتقال**

يسمح لك Aspose.Slides للبايثون بتعيين مؤثرات انتقال مثل **From Black**، **From Left**، **From Right**، وغيرها. لتكوين مؤثر انتقال، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة.
3. تعيين مؤثر الانتقال المطلوب.
4. حفظ العرض كملف PPTX.

في المثال أدناه، قمنا بتعيين عدة مؤثرات انتقال.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لفتح ملف عرض.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # تطبيق انتقال قطع وتمكين From Black.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # حفظ العرض إلى القرص.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟**

نعم. اضبط [سرعة](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) الانتقال باستخدام إعداد [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) (مثلًا بطيء/متوسط/سريع).

**هل يمكنني إرفاق صوت بالانتقال وجعله يتكرر؟**

نعم. يمكنك تضمين صوت للانتقال والتحكم في سلوكه عبر إعدادات مثل وضع الصوت والتكرار (مثلًا [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/)، [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/)، [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/)، بالإضافة إلى بيانات وصفية مثل [sound_is_built_in](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) و[sound_name](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**ما هي أسرع طريقة لتطبيق نفس الانتقال على كل الشرائح؟**

قم بتكوين نوع الانتقال المطلوب في إعدادات الانتقال لكل شريحة؛ تُحفظ الانتقالات لكل شريحة على حدة، لذا تطبيق نفس النوع على جميع الشرائح يمنحك نتيجة متسقة.

**كيف يمكنني التحقق من الانتقال المحدد حاليًا على شريحة؟**

افحص [إعدادات الانتقال](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) الخاصة بالشريحة واقرأ [نوع الانتقال](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/)؛ ستوضح لك هذه القيمة بالضبط أي مؤثر تم تطبيقه.