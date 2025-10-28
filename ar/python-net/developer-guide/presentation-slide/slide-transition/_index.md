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
- انتقال Morph
- نوع الانتقال
- تأثير الانتقال
- Python
- Aspose.Slides
description: "اكتشف كيفية تخصيص انتقالات الشرائح في Aspose.Slides للبايثون عبر .NET، مع إرشادات خطوة بخطوة لعروض PowerPoint و OpenDocument."
---

## **نظرة عامة**

توفر Aspose.Slides للبايثون تحكمًا كاملاً في انتقالات الشرائح، بدءًا من اختيار نوع الانتقال إلى تكوين التوقيت والمحفزات كجزء من سير عمل العروض التقديمية الآلية. يمكنك ضبط الشرائح لتنتقل عند النقر و/أو بعد تأخير محدد وتحسين السلوك البصري بتأثيرات مثل القطع من اللون الأسود أو الدخول من اتجاه معين. كما تدعم المكتبة انتقال Morph الذي تم تقديمه في PowerPoint 2019، بما في ذلك أوضاع التحول حسب الكائن أو الكلمة أو الحرف لإنشاء حركة سلسة ومترابطة بين الشرائح.

## **إضافة انتقالات الشرائح**

للتسهيل على الفهم، يوضح هذا المثال كيفية استخدام Aspose.Slides للبايثون لإدارة انتقالات شرائح بسيطة. يمكن للمطورين تطبيق تأثيرات انتقال شريحة مختلفة على الشرائح وتخصيص سلوكها. لإنشاء انتقال شريحة بسيط، اتبع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. تطبيق انتقال شريحة باستخدام أحد التأثيرات من تعداد [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) .
1. حفظ ملف العرض المعدل.

```py
import aspose.slides as slides

# Instantiate the Presentation class to load a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Apply a circle transition to slide 1.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Apply a comb transition to slide 2.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Save the presentation to disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **إضافة انتقالات شرائح متقدمة**

في هذا القسم، طبقنا تأثير انتقال بسيط على شريحة. لجعل هذا التأثير أكثر تحكمًا وصقلًا، اتبع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. تطبيق انتقال شريحة باستخدام أحد التأثيرات من تعداد [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) .
1. تكوين الانتقال ليتقدم عند النقر، بعد فترة زمنية محددة، أو كليهما.
1. حفظ ملف العرض المعدل.

إذا تم تمكين **Advance On Click**، فإن الشريحة تتقدم فقط عند نقر المستخدم. إذا تم تعيين خاصية **Advance After Time**، فإن الشريحة تتقدم تلقائيًا بعد الفاصل الزمني المحدد.

```py
import aspose.slides as slides

# Instantiate the Presentation class to open a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # Apply a circle transition to slide 1.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Enable advance on click and set a 3-second auto-advance.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # Apply a comb transition to slide 2.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Enable advance on click and set a 5-second auto-advance.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # Apply a zoom transition to slide 3.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Enable advance on click and set a 7-second auto-advance.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # Save the presentation to disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **انتقال Morph**

تدعم Aspose.Slides للبايثون [انتقال Morph](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/)، الذي يحرك الانتقال السلس من شريحة إلى أخرى. يشرح هذا القسم كيفية استخدام انتقال Morph. لاستخدامه بفعالية، تحتاج إلى شريحتين تشتركان على كائن واحد على الأقل. أسهل طريقة هي استنساخ شريحة ثم نقل الكائن إلى موضع مختلف في الشريحة الثانية.

يظهر المقتطف التالي كيفية استنساخ شريحة تحتوي على نص وتطبيق انتقال Morph على الشريحة الثانية.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Clone the first slide to create a second slide with the same shapes for Morph continuity.
    slide1 = presentation.slides.add_clone(slide0)

    # Select the same rectangle on the second slide and change its position and size.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # Enable the Morph transition on the second slide to animate the shape changes smoothly.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **أنواع انتقال Morph**

يمثل تعداد [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) الأنواع المختلفة لانتقالات شرائح Morph.

يظهر المقتطف التالي كيفية تطبيق انتقال Morph على شريحة وتغيير نوع التحول:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين تأثيرات الانتقال**

تتيح لك Aspose.Slides للبايثون تعيين تأثيرات انتقال مثل **From Black**، **From Left**، **From Right**، إلخ. لتكوين تأثير الانتقال، اتبع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى الشريحة.
1. تعيين تأثير الانتقال المطلوب.
1. حفظ العرض كملف PPTX.

في المثال أدناه، قمنا بتعيين عدة تأثيرات انتقال.

```py
import aspose.slides as slides

# Instantiate the Presentation class to open a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Apply a Cut transition and enable From Black.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # Save the presentation to disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟**

نعم. اضبط [سرعة](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) الانتقال باستخدام إعداد [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) (مثلاً بطيء/متوسط/سريع).

**هل يمكنني إرفاق صوت بالانتقال وجعله يتكرر؟**

نعم. يمكنك تضمين صوت للانتقال والتحكم في سلوكه عبر إعدادات مثل وضع الصوت والتكرار (مثلاً [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/)، [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/)، [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/)، بالإضافة إلى البيانات الوصفية مثل [sound_is_built_in](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) و [sound_name](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**ما هي أسرع طريقة لتطبيق نفس الانتقال على جميع الشرائح؟**

قم بتكوين نوع الانتقال المطلوب في إعدادات الانتقال لكل شريحة؛ حيث تُحفظ الانتقالات لكل شريحة على حدة، فإن تطبيق نفس النوع على جميع الشرائح يعطي نتيجة متسقة.

**كيف يمكنني معرفة أي انتقال تم تعيينه حاليًا على شريحة؟**

تفقد [إعدادات الانتقال](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) الخاصة بالشريحة واقرأ [نوع الانتقال](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/); تلك القيمة تخبرك بالضبط أي تأثير تم تطبيقه.