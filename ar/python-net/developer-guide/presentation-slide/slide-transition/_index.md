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
- PowerPoint
- OpenDocument
- العرض التقديمي
- Python
- Aspose.Slides
description: "تطبيق انتقالات الشرائح، تكوين تقدم الشرائح التلقائي، وتخصيص انتقال Morph وغيرها من تأثيرات الانتقال باستخدام Aspose.Slides للبايثون عبر .NET."
---
## **نظرة عامة**

تتحكم انتقالات الشرائح في كيفية ظهور الشرائح أثناء عرض الشرائح. باستخدام Aspose.Slides for Python عبر .NET، يمكنك اختيار تأثير الانتقال لكل شريحة، وتكوين التقدم بالنقر بالفأرة أو المؤقت، وتعديل الخيارات الخاصة بالتأثير. يستخدم هذا المقال أمثلة بايثون لتطبيق الانتقالات، وتحديد مدد الانتقال الدقيقة، وإدارة توقيت الشرائح، وإنشاء انتقال Morph بين شريحتين. تظهر الأمثلة أيضًا كيفية حفظ الإعدادات في ملف PPTX.

## **إضافة انتقال شريحة**

لتطبيق انتقال، قم بتحميل عرض تقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) والوصول إلى خاصية [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/). اضبط خاصية [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) إلى قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) ثم احفظ العرض التقديمي.

التطبيق التالي يطبق انتقال Circle على الشريحة الأولى وانتقال Comb على الشريحة الثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE
        presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

        presentation.save("slide-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

## **انتقال العجلة**

خاصية [spokes](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/spokes/) لـ [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) تتحكم في عدد القطاعات الشعاعية التي تكشف الشريحة المستهدفة. اضبط خاصية انتقال الشريحة [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) إلى WHEEL من [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) قبل الوصول إلى [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) كـ [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/).

هذا المثال ينشئ زوجين متطابقين من الشرائح: شريحة سوداء تتبعها شريحة تحتوي على مستطيل ذهبي. تستخدم الشرائح المستهدفة عدد أسنان (spokes) 1 و 8، مع نفس [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) ومدة صريحة [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) تبلغ 8000 مللي ثانية لجعل الفرق سهلًا للملاحظة.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    black_slide = presentation.slides[0]
    black_slide.shapes.clear()
    black_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    black_slide.background.fill_format.fill_type = slides.FillType.SOLID
    black_slide.background.fill_format.solid_fill_color.preset_color = slides.PresetColor.BLACK

    destination_slide = presentation.slides.add_clone(black_slide)
    rectangle = destination_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, slide_width, slide_height)
    rectangle.fill_format.fill_type = slides.FillType.SOLID
    rectangle.fill_format.solid_fill_color.preset_color = slides.PresetColor.GOLD
    rectangle.text_frame.text = "Wheel transition"

    presentation.slides.add_clone(black_slide)
    presentation.slides.add_clone(destination_slide)

    spoke_counts = [1, 8]
    for i, spoke_count in enumerate(spoke_counts):
        transition = presentation.slides[i * 2 + 1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.WHEEL
        wheel_transition = transition.value
        wheel_transition.spokes = spoke_count
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 8000

    presentation.save("wheel-transitions.pptx", slides.export.SaveFormat.PPTX)
```

افتح العرض المُخرَج في PowerPoint وشغِّل عرض الشرائح. انتقل من الشريحة 1 إلى الشريحة 2، ثم من الشريحة 3 إلى الشريحة 4. في تشغيل PowerPoint، يُظهر عدد الأسنان المؤكد 1 الشريحة بحركة واحدة مع اتجاه عقرب الساعة؛ ويظهر العدد 8 الشريحة عبر ثمانية قطاعات شعاعية في آنٍ واحد. محتوى الشريحة والوقت المتعلق بالانتقال متطابقان، لذا الفرق هو عدد قطاعات الكشف.

## **إضافة انتقال شريحة متقدم**

يمكنك تكوين مدة بقاء الشريحة على الشاشة وما إذا كان النقر بالفأرة يتقدم بالعرض. تتحكم الخصائص التالية في هذا السلوك:

- [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) يسمح للمستخدم بالتقدم بالنقر بالفأرة.
- [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) يفعّل التقدم التلقائي.
- [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) يحدد التأخير قبل التقدم التلقائي، بالمللي ثانية.

فعّل كل من التقدم بالنقر والوقت للسماح للمستخدم بالمتابعة بالنقر أو الانتظار حتى ينتهي المؤقت. لاستخدام المؤقت فقط، اضبط [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) إلى `False`. يتحكم التأخير في موعد تقدم العرض؛ ولا يحدد مدة تأثير الانتقال البصري.

يعين هذا المثال تأثيرات مختلفة للشرائح الثلاث الأولى ويُفعّل التقدم التلقائي بعد 3 و5 و7 ثوانٍ على التوالي. يمكن للنقرات الفأرة أيضًا تحقيق تقدم هذه الشرائح. استخدم ملف `input.pptx` يحتوي على ثلاث شرائح على الأقل.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 3:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.CIRCLE
        first_transition.advance_on_click = True
        first_transition.advance_after = True
        first_transition.advance_after_time = 3000

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.COMB
        second_transition.advance_on_click = True
        second_transition.advance_after = True
        second_transition.advance_after_time = 5000

        third_transition = presentation.slides[2].slide_show_transition
        third_transition.type = slides.slideshow.TransitionType.ZOOM
        third_transition.advance_on_click = True
        third_transition.advance_after = True
        third_transition.advance_after_time = 7000

        presentation.save("advanced-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least three slides.")
```

للتحقق مما إذا كان التقدم الزمني مفعّلًا، اقرأ [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). التخزين المؤقت للمدة لا يعني أن المؤقت نشط.

المثال التالي يفتح الملف المحفوظ أعلاه، يبلّغ عن كل مؤقت مفعّل، ويعطّل التقدم التلقائي للشرائح التي لها تأخير أكبر من ثانيتين. يفعّل النقرات للفأرة لتلك الشرائح ويحفظ الإعدادات المحدثة.

```python
import aspose.slides as slides

with slides.Presentation("advanced-transitions.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition

        if transition.advance_after:
            print(f"Slide {slide.slide_number}: advance after {transition.advance_after_time} ms.")

            if transition.advance_after_time > 2000:
                transition.advance_after = False
                transition.advance_on_click = True

    presentation.save("adjusted-transitions.pptx", slides.export.SaveFormat.PPTX)
```

## **التحكم الدقيق في توقيت الانتقال**

استخدم [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) لتحديد الطول الدقيق لتأثير الانتقال بالمللي ثانية. خاصية [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) في الشريحة تكشف عن هذه الإعدادات عبر [SlideShowTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/):

| الخاصية | الغرض |
| --- | --- |
| [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | يضبط مدة تأثير الانتقال نفسه، بالمللي ثانية. |
| [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | يضبط التأخير قبل تقدم الشريحة تلقائيًا، بالمللي ثانية. فعل [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) لتفعيل هذا المؤقت. |
| [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | يختار فئة سرعة مسبقة التعريف من [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/): SLOW أو MEDIUM أو FAST. يستخدم عندما لا يتم تحديد مدة دقيقة. |

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) يتحكم فقط في تأثير الانتقال؛ ولا يحدّد مدة بقاء الشريحة مرئية. اضبط تأخير التقدم التلقائي بشكل منفصل. عندما لا تُحدّد مدة صريحة، يحدد Aspose.Slides مدة التأثير بناءً على نوع الانتقال وقيمة [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/).

<!-- visual-explanation:slide-transition:start -->
[![الأشرطة المنفصلة تحدد مدة الانتقال 750 مللي ثانية وإعداد التقدم التلقائي 5000 مللي ثانية.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*المثال المشترك يعطي كل شريحة انتقال Fade مدته 750 مللي ثانية ويُفعّل التقدم التلقائي بعد 5,000 مللي ثانية. مدة الانتقال تتحكم في التأثير؛ والتقدم يتحكم في موعد مغادرة الشريحة. هذه الأشرطة تمثّل إعدادات تخطيطية، وليست مخططًا زمنيًا مقاسًا.*
<!-- visual-explanation:slide-transition:end -->

### **تطبيق نفس المدة على كل شريحة**

للحصول على وتيرة ثابتة، طبّق نفس التأثير والمدة الدقيقة على كل شريحة. يحمل هذا المثال ملف `input.pptx`، يختار Fade من [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/)، ويعطي كل انتقال مدة 750 مللي ثانية. يُفعّل التقدم التلقائي بعد 5,000 مللي ثانية ويعطل التقدم بالنقر، ثم يحفظ النتيجة كملف PPTX.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # تكوين التقدم التلقائي بشكل مستقل عن مدة التأثير.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **تعيين مدد مختلفة للشرائح الفردية**

يمكن للشرائح المختلفة أن تستخدم مدد تأثير مختلفة. على سبيل المثال، استخدم انتقالًا قصيرًا لشريحة العنوان وانتقالًا أطول لمقدمة القسم. يضبط هذا المثال 500 مللي ثانية للشريحة الأولى و1,200 مللي ثانية للثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.FADE
        first_transition.duration = 500

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.PUSH
        second_transition.duration = 1200

        presentation.save("individual-transition-durations.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

### **تنسيق الانتقالات مع المخرجات المتحركة**

عند إعداد [animated GIF](/slides/ar/python-net/convert-powerpoint-to-animated-gif/)، [HTML5 presentation](/slides/ar/python-net/export-to-html5/)، أو [video](/slides/ar/python-net/convert-powerpoint-to-video/)، حدّد مدد الانتقال الدقيقة قبل التصدير لتتناسب مع الوتيرة المطلوبة. على سبيل المثال، استخدم انتقال Fade مدته 600 مللي ثانية بين المشاهد، واضبط تأخير التقدم لكل شريحة بشكل منفصل للسماح بوقت للسرد أو المحتوى.

بالنسبة للـ GIF والفيديو، نسّق معدل الإطارات مع مدة التأثير: 600 مللي ثانية تعادل 18 إطارًا عند 30 إطارًا في الثانية. في HTML5، فعّل الانتقالات المتحركة في إعدادات التصدير. تحقق من تأثيرات وتوقيتات الصيغة المُصدرة المدعومة، وعاين المخرج للتأكد من التزامن.

### **قراءة مدة انتقال موجودة**

اقرأ [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) قبل تعديل الانتقال لتحديد ما إذا كانت قيمة صريحة مخزنة. القيمة `-1` تعني عدم وجود مدة صريحة؛ والقيمة غير السلبية تحدد المدة المخزنة بالمللي ثانية. القيمة غير المضبوطة ليست مدة التشغيل المحسوبة: يستخدم Aspose.Slides نوع الانتقال و[speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) لتحديد تلك المدة. ضبط نوع الانتقال قد يهيئ مدة، لذا افحص الإعدادات الأصلية أولاً.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        duration = transition.duration

        if duration >= 0:
            print(f"Slide {slide.slide_number}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.slide_number}: no explicit duration; timing depends on {transition.type} and {transition.speed}.")
```

## **انتقال Morph**

يُحاكي انتقال Morph التغييرات بين الكائنات في الشرائح المتتالية. لإنشاء تأثير Morph بسيط، استنساخ شريحة، حرك أو غير حجم كائن على النسخة، ثم طبّق انتقال Morph على الشريحة الثانية. يمنح ذلك الانتقال الكائنات المقابلة لتتحرك بين حالتها الأصلية والمعدّلة.

ينشئ المثال التالي شريحة تحتوي على مستطيل نصي، ينسخ الشريحة، ويغيّر موضع وحجم المستطيل على النسخة. ثم يختار Morph من تعداد [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) للشريحة الثانية. افتح الملف المحفوظ في عارض عرض يدعم Morph لتشاهد التأثير أثناء عرض الشرائح.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    rectangle = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    rectangle.text_frame.text = "Morph transition"

    second_slide = presentation.slides.add_clone(first_slide)
    moved_rectangle = second_slide.shapes[0]
    moved_rectangle.x += 100
    moved_rectangle.y += 50
    moved_rectangle.width -= 200
    moved_rectangle.height -= 10

    second_slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("morph-transition.pptx", slides.export.SaveFormat.PPTX)
```

## **أنواع انتقال Morph**

تعداد [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) يحدد كيف يطابق Morph ويُحرك المحتوى:

- [BY_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) يعامل كل شكل ككائن كامل.
- [BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) يُحرك النص بمطابقة الكلمات حيثما أمكن.
- [BY_CHAR](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) يُحرك النص بمطابقة الأحرف حيثما أمكن.

اضبط خاصية الانتقال [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) إلى Morph قبل الوصول إلى [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/). ثم توفر القيمة كائن [MorphTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/)، الذي تختار من خلال خاصية [morph_type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/morph_type/) وضعية المطابقة.

يفتح هذا المثال العرض الذي تم إنشاؤه في القسم السابق ويضبط الشريحة الثانية لاستخدام تحريك Morph على أساس الكلمات.

```python
import aspose.slides as slides

with slides.Presentation("morph-transition.pptx") as presentation:
    if len(presentation.slides) >= 2:
        transition = presentation.slides[1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.MORPH
        morph_transition = transition.value

        if isinstance(morph_transition, slides.slideshow.MorphTransition):
            morph_transition.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
            presentation.save("morph-by-word.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
```

## **تعيين تأثيرات الانتقال**

بعض الانتقالات تكشف عن خيارات إضافية، مثل الاتجاه أو ما إذا كان التأثير يبدأ من شاشة سوداء. الخيارات المتاحة تعتمد على [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) الانتقال المختار. اضبط النوع أولًا، ثم استخدم الكائن المناسب من [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/).

التطبيق التالي يطبق انتقال Cut على الشريحة الأولى من `input.pptx`. يضبط [from_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) عبر [OptionalBlackTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/) لجعل الانتقال يبدأ من شاشة سوداء.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    transition = presentation.slides[0].slide_show_transition
    transition.type = slides.slideshow.TransitionType.CUT
    cut_transition = transition.value

    if isinstance(cut_transition, slides.slideshow.OptionalBlackTransition):
        cut_transition.from_black = True
        presentation.save("cut-from-black.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Cut transition options are unavailable.")
```

## **الأسئلة المتكررة**

**هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟**

نعم. يفضَّل استخدام [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) عندما تحتاج إلى مدة تأثير دقيقة بالمللي ثانية. استخدم [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) عندما تكون فئة سرعة مسبقة التعريف من [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) — SLOW أو MEDIUM أو FAST — كافية ولا تُحدَّد مدة صريحة. تتحكم هذه الإعدادات في تأثير الانتقال بشكل مستقل عن تأخير التقدم التلقائي.

**هل يمكنني إرفاق صوت بالانتقال وجعله يتكرَّر؟**

نعم. عيّن صوتًا مضمّنًا إلى [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/)، واضبط [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) إلى START_SOUND من تعداد [TransitionSoundMode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionsoundmode/)، وفعل [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). يتكرَّر الصوت حتى يحدث حدث صوتي آخر في عرض الشرائح.

**ما هي أسرع طريقة لتطبيق نفس الانتقال على كل شريحة؟**

مرّر عبر مجموعة [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) في العرض واضبط خاصية [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) لكل شريحة إلى نفس القيمة. اضبط أي خيارات توقيت وتأثير داخل نفس الحلقة للحفاظ على سلوك متسق عبر الشرائح.

**كيف يمكنني التحقق من الانتقال الحالي المُعيّن على شريحة؟**

اقرأ خاصية [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) من خاصية [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) الخاصة بالشريحة. تُعيد قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/); القيمة NONE تعني عدم تطبيق أي تأثير انتقال.