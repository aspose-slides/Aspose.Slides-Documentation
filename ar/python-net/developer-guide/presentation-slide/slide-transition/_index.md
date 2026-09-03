---
title: إدارة انتقالات الشرائح في العروض التقديمية باستخدام Python
linktitle: انتقال الشريحة
type: docs
weight: 90
url: /ar/python-net/slide-transition/
keywords:
- انتقال الشريحة
- إضافة انتقال شريحة
- تطبيق انتقال شريحة
- انتقال شريحة متقدم
- انتقال Morph
- نوع الانتقال
- تأثير الانتقال
- PowerPoint
- OpenDocument
- العرض التقديمي
- Python
- Aspose.Slides
description: "تطبيق انتقالات الشرائح، تهيئة التقدم التلقائي للشرائح، وتخصيص انتقال Morph وغيرها من تأثيرات الانتقال باستخدام Aspose.Slides للبايثون عبر .NET."
---
## **نظرة عامة**

تتحكم انتقالات الشرائح في طريقة ظهور الشرائح أثناء عرض الشرائح. باستخدام Aspose.Slides for Python عبر .NET، يمكنك اختيار تأثير انتقال لكل شريحة، وتكوين التقدم بالنقر بالفأرة أو المؤقت، وضبط الخيارات الخاصة بالتأثير. تستخدم هذه المقالة أمثلة بايثون لتطبيق الانتقالات، وتحديد مدد الانتقال الدقيقة، وإدارة توقيت الشرائح، وإنشاء انتقال Morph بين شريحتين. توضح الأمثلة أيضًا كيفية حفظ الإعدادات في ملف PPTX.

## **إضافة انتقال شريحة**

لتطبيق انتقال، قم بتحميل عرض تقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) و الوصول إلى خاصية [slide_show_transition](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/slide_show_transition/) للشريحة. اضبط [type](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/type/) على قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/transitiontype/) ، ثم احفظ العرض التقديمي.

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

## **إضافة انتقال شريحة متقدم**

يمكنك تكوين مدة بقاء الشريحة على الشاشة وما إذا كان النقر بالفأرة يتقدم بالعرض. الخصائص التالية تتحكم في هذا السلوك:

- [advance_on_click](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) يسمح للمستخدم بالتقدم بالنقر بالفأرة.
- [advance_after](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) يفعّل التقدم التلقائي.
- [advance_after_time](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) يحدد التأخير قبل التقدم التلقائي، بالمللي ثانية.

فعّل كل من النقر والوقت للسماح للمستخدم بالتقدم بالنقر أو الانتظار للمؤقت. لاستخدام المؤقت فقط، اضبط [advance_on_click](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) على `False`. يتحكم التأخير في وقت تقدم العرض، وليس في مدة تأثير الانتقال البصري.

هذا المثال يعيّن تأثيرات مختلفة للشرائح الثلاث الأولى ويفعل التقدم التلقائي بعد 3 و5 و7 ثوانٍ على التوالي. يمكن للنقرات أيضًا تقديم هذه الشرائح. استخدم ملف `input.pptx` يحتوي على ثلاث شرائح على الأقل.

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

للتحقق مما إذا كان التقدم المؤقت مفعلًا، اقرأ [advance_after](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). التخزين المتأخر لا يشير وحده إلى تفعيل المؤقت.

المثال التالي يفتح الملف المحفوظ أعلاه، يُبلغ عن كل مؤقت مفعل، ويعطل التقدم التلقائي للشرائح التي لديها تأخير أكبر من ثانيتين. يُفعّل النقرات لتلك الشرائح ويحفظ الإعدادات المحدثة.

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

استخدم [duration](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/duration/) لتحديد الطول الدقيق لتأثير الانتقال بالمللي ثانية. خاصية [slide_show_transition](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/slide_show_transition/) للشفرة تكشف عن هذه الإعدادات عبر [SlideShowTransition](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/):

| الخاصية | الغرض |
| --- | --- |
| [duration](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | يحدد مدة تأثير الانتقال نفسه، بالمللي ثانية. |
| [advance_after_time](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | يحدد التأخير قبل التقدم التلقائي للشفرة، بالمللي ثانية. فعل [advance_after](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) لتفعيل هذا المؤقت. |
| [speed](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | يختار فئة سرعة معرفة مسبقًا من [TransitionSpeed](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/transitionspeed/): SLOW، MEDIUM، أو FAST. تُستَخدم عندما لا تُحدَّد مدة دقيقة. |

[duration](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/duration/) يتحكم فقط في تأثير الانتقال؛ لا يحدد مدة بقاء الشريحة مرئية. اضبط تأخير التقدم التلقائي منفصلًا. عندما لا تُحدَّد مدة صريحة، يحدد Aspose.Slides مدة التأثير بناءً على نوع الانتقال و[speed](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/speed/).

### **تطبيق نفس المدة على كل شريحة**

للحفاظ على وتيرة ثابتة، طبّق نفس التأثير والمدة الدقيقة على كل شريحة. هذا المثال يحمل `input.pptx`، يختار Fade من [TransitionType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/transitiontype/)، ويعطي كل انتقال مدة 750 مللي ثانية. يفعّل التقدم التلقائي بعد 5 000 مللي ثانية ويعطّل التقدم بالنقر، ثم يحفظ النتيجة كملف PPTX.

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

يمكن للشرائح المختلفة أن تستخدم مدد تأثير مختلفة. على سبيل المثال، استخدم انتقالًا قصيرًا لشريحة العنوان وانتقالًا أطول لمقدمة قسم. هذا المثال يحدد 500 مللي ثانية للشفرة الأولى و1 200 مللي ثانية للشفرة الثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

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

عند التحضير لـ [animated GIF](/slides/ar/python-net/convert-powerpoint-to-animated-gif/)، [HTML5 presentation](/slides/ar/python-net/export-to-html5/)، أو [video](/slides/ar/python-net/convert-powerpoint-to-video/)، اضبط مدد الانتقال الدقيقة قبل التصدير لتطابق الإيقاع المرغوب. على سبيل المثال، استخدم تلاشي 600 مللي ثانية بين المشاهد، وعدّل تأخير تقدم كل شريحة بشكل منفصل لإتاحة الوقت للتعليق الصوتي أو المحتوى.

بالنسبة للـ GIF والفيديو، نسّق معدل الإطارات للمخرجات مع مدة التأثير: 600 مللي ثانية تعادل 18 إطارًا عند 30 إطارًا في الثانية. في HTML5، فعّل الانتقالات المتحركة في إعدادات التصدير. تحقق من التأثيرات وخيارات التوقيت المدعومة للصيغة المختارة، ومعاينة النتيجة لتأكيد التزامن.

### **قراءة مدة انتقال موجودة**

اقرأ [duration](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/duration/) قبل تعديل الانتقال لتحديد ما إذا كانت قيمة صريحة مخزنة. القيمة `-1` تعني عدم وجود مدة صريحة؛ القيمة غير السالبة تحدد المدة المخزنة بالمللي ثانية. القيمة غير المضبوطة ليست مدة التشغيل المحسوبة: يستخدم Aspose.Slides نوع الانتقال و[speed](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/speed/) لتحديد تلك المدة. قد يهيئ ضبط نوع الانتقال مدةً، لذا افحص الإعدادات الأصلية أولًا.

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

يُحرك انتقال Morph التغييرات بين الكائنات على الشرائح المتتالية. لإنشاء تأثير Morph بسيط، استنسخ شريحة، حرك أو غيّر حجم كائن على النسخة، وطبّق انتقال Morph على الشريحة الثانية. يمنح ذلك الكائنات المطابقة للانتقال القدرة على التحرك بين حالتها الأصلية والمعدلة.

المثال التالي ينشئ شريحة بها مستطيل نص، ينسخ الشريحة، ويغيّر موقع وحجم المستطيل على النسخة. ثم يختار Morph من تعداد [TransitionType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/transitiontype/) للشفرة الثانية. افتح الملف المحفوظ في عارض عروض يدعم Morph لرؤية التأثير أثناء عرض الشرائح.

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

تعداد [TransitionMorphType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/transitionmorphtype/) يتحكم في كيفية مطابقة Morph وتحريك المحتوى:

- [BY_OBJECT](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/transitionmorphtype/) يعالج كل شكل ككائن كامل.
- [BY_WORD](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/transitionmorphtype/) يحرك النص بمطابقة الكلمات إن أمكن.
- [BY_CHAR](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/transitionmorphtype/) يحرك النص بمطابقة الأحرف إن أمكن.

اضبط [type](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/type/) للانتقال إلى Morph قبل الوصول إلى [value](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/value/). ثم توفر القيمة كائن [MorphTransition](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/morphtransition/)، خاصية [morph_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/morphtransition/morph_type/) التي تحدد وضع المطابقة.

هذا المثال يفتح العرض التقديمي الذي تم إنشاؤه في القسم السابق ويضبط الشريحة الثانية لتستخدم تحريك Morph بناءً على الكلمات.

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

بعض الانتقالات تكشف عن خيارات إضافية، مثل الاتجاه أو ما إذا كان يبدأ التأثير من شاشة سوداء. تعتمد الخيارات المتاحة على [type](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/type/) الانتقال المختار. اضبط النوع أولاً، ثم استخدم كائن الانتقال المناسب من [value](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/value/).

المثال التالي يطبّق انتقال Cut على الشريحة الأولى من `input.pptx`. يضبط [from_black](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) عبر [OptionalBlackTransition](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/optionalblacktransition/) لجعل الانتقال يبدأ من شاشة سوداء.

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

## **FAQ**

**هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟**

نعم. يفضَّل استخدام [duration](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/duration/) عندما تحتاج إلى مدة تأثير دقيقة بالمللي ثانية. استخدم [speed](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/speed/) عندما تكون فئة [TransitionSpeed](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/transitionspeed/) مسبقة التعريف—SLOW، MEDIUM، أو FAST—كافية ولا توجد مدة صريحة محددة. تتحكم هذه الإعدادات في تأثير الانتقال بشكل مستقل عن تأخير التقدم التلقائي.

**هل يمكن إرفاق صوت بالانتقال وجعله يتكرر؟**

نعم. عيّن صوتًا مضمنًا إلى [sound](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/sound/)، اضبط [sound_mode](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) إلى START_SOUND من تعداد [TransitionSoundMode](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/transitionsoundmode/)، وفعل [sound_loop](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). سيستمر الصوت في التكرار حتى حدث صوتي التالي في عرض الشرائح.

**ما هو أسرع طريقة لتطبيق نفس الانتقال على جميع الشرائح؟**

تكرار عبر مجموعة [slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/slides/ar/) للعرض التقديمي وضبط [type](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/type/) لكل شريحة إلى نفس القيمة. اضبط أي خيارات توقيت وتأثير داخل نفس الحلقة للحفاظ على سلوك موحد عبر الشرائح.

**كيف يمكنني التحقق من الانتقال الحالي المطبق على شريحة؟**

اقرأ خاصية [type](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/slideshowtransition/type/) من [slide_show_transition](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/slide_show_transition/) للشفرة. ستُرجع قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.slideshow/transitiontype/)، حيث يعني NONE عدم تطبيق أي تأثير انتقال.