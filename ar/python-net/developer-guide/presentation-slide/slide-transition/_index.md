---
title: إدارة انتقالات الشرائح في العروض التقديمية باستخدام Python
linktitle: انتقال الشريحة
type: docs
weight: 90
url: /ar/python-net/slide-transition/
keywords:
- انتقال شريحة
- إضافة انتقال شريحة
- تطبيق انتقال شريحة
- انتقال شريحة متقدم
- انتقال مورف
- نوع الانتقال
- تأثير الانتقال
- Python
- Aspose.Slides
description: "اكتشف كيفية تخصيص انتقالات الشرائح في Aspose.Slides for Python عبر .NET، مع إرشادات خطوة بخطوة لعروض PowerPoint و OpenDocument."
---

## **نظرة عامة**

توفر Aspose.Slides for Python تحكمًا كاملاً في انتقالات الشرائح، بدءًا من اختيار نوع الانتقال إلى تكوين التوقيت والمحفزات كجزء من سير عمل العروض التقديمية الآلية. يمكنك ضبط تقدم الشرائح عند النقر و/أو بعد تأخير محدد وتعديل السلوك البصري باستخدام تأثيرات مثل القص من الأسود أو الدخول من اتجاه محدد. كما تدعم المكتبة انتقال Morph الذي تم تقديمه في PowerPoint 2019، بما في ذلك الأنماط التي تتحول وفقًا للكائن أو الكلمة أو الحرف لإنشاء حركة سلسة ومتناسقة بين الشرائح.

## **إضافة انتقالات الشرائح**

لتسهيل الفهم، يوضح هذا المثال كيفية استخدام Aspose.Slides for Python لإدارة انتقالات الشرائح البسيطة. يمكن للمطورين تطبيق تأثيرات انتقال مختلفة على الشرائح وتخصيص سلوكها. لإنشاء انتقال شريحة بسيط، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. تطبيق انتقال شريحة باستخدام أحد التأثيرات من تعداد [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) .
1. حفظ ملف العرض التقديمي المعدل.
```py
import aspose.slides as slides

# إنشاء كائن من الفئة Presentation لتحميل ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:
    # تطبيق انتقال دائرة على الشريحة 1.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # تطبيق انتقال مشط على الشريحة 2.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **إضافة انتقالات شرائح متقدمة**

في هذا القسم، قمنا بتطبيق تأثير انتقال بسيط على شريحة. لجعل هذا التأثير أكثر تحكمًا وتلميعًا، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. تطبيق انتقال شريحة باستخدام أحد التأثيرات من تعداد [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) .
1. تكوين الانتقال لتقدم عند النقر، بعد فترة زمنية محددة، أو كليهما.
1. حفظ ملف العرض التقديمي المعدل.

إذا تم تمكين **Advance On Click**، فإن الشريحة تتقدم فقط عندما ينقر المستخدم. إذا تم تعيين خاصية **Advance After Time**، فإن الشريحة تتقدم تلقائيًا بعد الفاصل الزمني المحدد.
```py
import aspose.slides as slides

# إنشاء كائن من الفئة Presentation لفتح ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # تطبيق انتقال دائرة على الشريحة 1.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # تمكين التقدم عند النقر وتعيين تقدم تلقائي بعد 3 ثوانٍ.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # تطبيق انتقال مشط على الشريحة 2.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # تمكين التقدم عند النقر وتعيين تقدم تلقائي بعد 5 ثوانٍ.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # تطبيق انتقال تكبير على الشريحة 3.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # تمكين التقدم عند النقر وتعيين تقدم تلقائي بعد 7 ثوانٍ.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **انتقال مورف**

يدعم Aspose.Slides for Python [Morph transition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/)، الذي يحرك الحركة السلسة من شريحة إلى أخرى. يشرح هذا القسم كيفية استخدام انتقال Morph. لاستخدامه بفعالية، تحتاج إلى شريحتين على الأقل تشتركان في كائن واحد. أسهل طريقة هي تكرار شريحة ثم نقل الكائن إلى موقع مختلف في الشريحة الثانية.

يعرض المقتطف البرمجي التالي كيفية استنساخ شريحة تحتوي على نص وتطبيق انتقال Morph على الشريحة الثانية.
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # استنساخ الشريحة الأولى لإنشاء شريحة ثانية بنفس الأشكال لضمان استمرارية Morph.
    slide1 = presentation.slides.add_clone(slide0)

    # اختيار نفس المستطيل في الشريحة الثانية وتغيير موضعه وحجمه.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # تمكين انتقال Morph في الشريحة الثانية لتسوية تحريك تغييرات الشكل بسلاسة.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **أنواع انتقال مورف**

يمثل تعداد [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) أنواع انتقال شريحة Morph المختلفة.

يعرض المقتطف البرمجي التالي كيفية تطبيق انتقال Morph على شريحة وتغيير نوع morph:
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين تأثيرات الانتقال**

يتيح لك Aspose.Slides for Python تعيين تأثيرات انتقال مثل **From Black**، **From Left**، **From Right**، وغيرها. لتكوين تأثير الانتقال، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. احصل على مرجع إلى الشريحة.
1. حدد تأثير الانتقال المطلوب.
1. احفظ العرض التقديمي كملف PPTX.

في المثال أدناه، حددنا عدة تأثيرات انتقال.
```py
import aspose.slides as slides

# إنشاء كائن من الفئة Presentation لفتح ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # تطبيق انتقال قطع وتمكين From Black.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **أسئلة شائعة**

**هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟**

نعم. اضبط [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) للانتقال باستخدام إعداد [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) (مثلاً بطيء/متوسط/سريع).

**هل يمكنني إرفاق صوت بالانتقال وجعله يتكرر؟**

نعم. يمكنك تضمين صوت للانتقال والتحكم في سلوكه عبر إعدادات مثل وضع الصوت وإعادة التكرار (مثل [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/)، [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/)، [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/)، بالإضافة إلى بيانات تعريفية مثل [sound_is_built_in](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) و[sound_name](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**ما هي أسرع طريقة لتطبيق نفس الانتقال على كل شريحة؟**

قم بتهيئة نوع الانتقال المطلوب في إعدادات انتقال كل شريحة؛ حيث يتم تخزين الانتقالات لكل شريحة على حدة، لذا فإن تطبيق نفس النوع على جميع الشرائح يمنح نتيجة متسقة.

**كيف يمكنني معرفة أي انتقال تم تعيينه حاليًا على شريحة؟**

تحقق من [transition settings](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) الخاصة بالشريحة واقرأ [transition type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/); هذه القيمة تخبرك بالضبط أي تأثير تم تطبيقه.