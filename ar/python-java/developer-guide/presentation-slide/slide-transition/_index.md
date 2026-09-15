---
title: إدارة انتقالات الشرائح في العروض التقديمية باستخدام Python عبر Java
linktitle: انتقال الشريحة
type: docs
weight: 80
url: /ar/python-java/slide-transition/
keywords:
- انتقال شريحة
- إضافة انتقال شريحة
- تطبيق انتقال شريحة
- انتقال شريحة متقدم
- انتقال Morph
- نوع الانتقال
- تأثير الانتقال
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تطبيق انتقالات الشرائح، تكوين التقدم التلقائي للشرائح، وتخصيص انتقال Morph وغيرها من تأثيرات الانتقال باستخدام Aspose.Slides للغات Python عبر Java."
---
## **نظرة عامة**

تتحكم انتقالات الشرائح في طريقة ظهور الشرائح خلال عرض الشرائح. باستخدام Aspose.Slides للغات Python عبر Java، يمكنك اختيار تأثير انتقال لكل شريحة، وتكوين الانتقال بالنقر بالماوس أو المؤقت، وضبط الخيارات الخاصة بكل تأثير. يستخدم هذا المقال أمثلة Python لتطبيق الانتقالات، وتحديد مدة انتقال دقيقة، وإدارة توقيت الشرائح، وإنشاء انتقال Morph بين شريحتين. تُظهر الأمثلة أيضًا كيفية حفظ الإعدادات إلى ملف PPTX.

## **إضافة انتقال شريحة**

لتطبيق انتقال، قم بتحميل عرض تقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وادخل إلى إعدادات انتقال الشريحة عبر [getSlideShowTransition](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/#getSlideShowTransition). استخدم [setType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/#setType) مع قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/transitiontype/) ثم احفظ العرض التقديمي.

التطبيق التالي يطبق انتقال Circle على الشريحة الأولى وانتقال Comb على الشريحة الثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle)
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb)

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **إضافة انتقال شريحة متقدم**

يمكنك تكوين مدة بقاء الشريحة على الشاشة وما إذا كان النقر بالماوس يتقدم بالعرض. تتحكم الطرق التالية في هذا السلوك:

- [setAdvanceOnClick](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) يسمح للمشاهد بالتقدم بالنقر بالماوس.
- [setAdvanceAfter](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) يفعّل التقدم التلقائي.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) يحدد التأخير قبل التقدم التلقائي، بالمللي ثانية.

فعّل كلا من النقر والانتقال المؤقت للسماح للمشاهد بالتحرك بالنقر أو الانتظار للمؤقت. لاستخدام المؤقت فقط، مرّر `False` إلى [setAdvanceOnClick](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). يتحكم التأخير في وقت تقدم عرض الشرائح؛ ولا يحدد مدة تأثير الانتقال البصري.

هذا المثال يُعيّن تأثيرات مختلفة للشرائح الثلاث الأولى ويفعل التقدم التلقائي بعد 3 و5 و7 ثوانٍ على التوالي. يمكن للنقرات أيضاً تقدم هذه الشرائح. استخدم ملف `input.pptx` يحتوي على ثلاث شرائح على الأقل.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 3:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Circle)
        first_transition.setAdvanceOnClick(True)
        first_transition.setAdvanceAfter(True)
        first_transition.setAdvanceAfterTime(3000)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Comb)
        second_transition.setAdvanceOnClick(True)
        second_transition.setAdvanceAfter(True)
        second_transition.setAdvanceAfterTime(5000)

        third_transition = presentation.getSlides().get_Item(2).getSlideShowTransition()
        third_transition.setType(TransitionType.Zoom)
        third_transition.setAdvanceOnClick(True)
        third_transition.setAdvanceAfter(True)
        third_transition.setAdvanceAfterTime(7000)

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

للتحقق مما إذا كان التقدم المؤقت مفعلاً، استدعِ [getAdvanceAfter](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter). وجود تأخير مخزن لا يعني بالضرورة أن المؤقت نشط.

المثال التالي يفتح الملف المحفوظ أعلاه، يُبلغ عن كل مؤقت مفعّل، ويعطل التقدم التلقائي للشرائح التي لديها تأخير أكبر من ثانيتين. يُفعّل النقرات لتلك الشرائح ويحفظ الإعدادات المحدثة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("advanced-transitions.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()

        if transition.getAdvanceAfter():
            print(f"Slide {slide.getSlideNumber()}: advance after {transition.getAdvanceAfterTime()} ms.")

            if transition.getAdvanceAfterTime() > 2000:
                transition.setAdvanceAfter(False)
                transition.setAdvanceOnClick(True)

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **التحكم في توقيت الانتقال بدقة**

استخدم [setDuration](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/#setDuration) لتحديد الطول الدقيق لتأثير الانتقال بالمللي ثانية. تُظهر طريقة [getSlideShowTransition](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/#getSlideShowTransition) للشفرة هذه الإعدادات عبر فئة [SlideShowTransition](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/):

| الطريقة | الغرض |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/#setDuration) | يحدد مدة تأثير الانتقال نفسه، بالمللي ثانية. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | يحدد التأخير قبل تقدم الشريحة تلقائياً، بالمللي ثانية. مرّر `True` إلى [setAdvanceAfter](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) لتفعيل هذا المؤقت. |
| [setSpeed](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/#setSpeed) | يختار فئة سرعة محددة مسبقًا من تعداد [TransitionSpeed](https://reference.aspose.com/slides/ar/python-java/aspose.slides/transitionspeed/): Slow أو Medium أو Fast. تُستَخدم عندما لا يتم تحديد مدة صريحة. |

يتحكم [setDuration](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/#setDuration) فقط في تأثير الانتقال؛ ولا يحدد مدة بقاء الشريحة مرئية. اضبط تأخير التقدم التلقائي بشكل منفصل. عندما لا تُحدَّد مدة صريحة، تحدد Aspose.Slides مدة التأثير بناءً على نوع الانتقال وقيمة [getSpeed](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/#getSpeed).

### **تطبيق نفس المدة على كل شريحة**

لتحقيق إيقاع ثابت، طبّق نفس التأثير والمدة الدقيقة على كل شريحة. يحمّل هذا المثال `input.pptx`، يختار Fade من تعداد [TransitionType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/transitiontype/)، ويعطي كل انتقال مدة قدرها 750 مللي ثانية. يفعّل كذلك التقدم التلقائي بعد 5،000 مللي ثانية ويعطل التقدم بالنقر بالماوس، ثم يحفظ النتيجة كملف PPTX.

```python
import jpype
import asposeslides

if not jpase.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Fade)
        transition.setDuration(750)

        # تكوين التقدم التلقائي بشكل مستقل عن مدة التأثير.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **تعيين مدد مختلفة للشرائح الفردية**

يمكن للشرائح المختلفة أن تستخدم مدد تأثير مختلفة. على سبيل المثال، استخدم انتقالًا قصيرًا لشريحة العنوان وانتقالًا أطول لمقدمة القسم. يحدد هذا المثال 500 مللي ثانية للشفرة الأولى و1،200 مللي ثانية للشفرة الثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Fade)
        first_transition.setDuration(500)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Push)
        second_transition.setDuration(1200)

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

### **تنسيق الانتقالات مع المخرجات المتحركة**

عند إعداد [animated GIF](/slides/ar/python-java/convert-powerpoint-to-animated-gif/)، أو [HTML5 presentation](/slides/ar/python-java/export-to-html5/)، أو [video](/slides/ar/python-java/convert-powerpoint-to-video/)، حدد مدد انتقال دقيقة قبل التصدير لتطابق الإيقاع المرغوب. على سبيل المثال، استخدم تلاشيًا بمدة 600 مللي ثانية بين المشاهد، وضبط تأخير تقدم كل شريحة بشكل منفصل للسماح بوقت السرد أو المحتوى.

بالنسبة للـ GIF والفيديو، نسّق معدل إطارات الإخراج مع مدة التأثير: 600 مللي ثانية تعادل 18 إطارًا عند 30 إطارًا في الثانية. في HTML5، فعّل الانتقالات المتحركة في إعدادات التصدير. تحقق من تأثيرات وتوقيتات الصيغة المُختارة، وعاين الناتج لتأكيد التزامن.

### **قراءة مدة انتقال موجودة**

استدعِ [getDuration](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/#getDuration) قبل تعديل الانتقال لتحديد ما إذا كانت قيمة صريحة مخزنة. القيمة `-1` تعني عدم وجود مدة صريحة؛ والقيمة غير السالبة تحدد المدّة المخزنة بالمللي ثانية. القيمة غير المضبوطة ليست مدة التشغيل المحسوبة: تستخدم Aspose.Slides نوع الانتقال وقيمة [getSpeed](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/#getSpeed) لتحديد ذلك. قد يهيئ تعيين نوع الانتقال مدةً، لذا افحص الإعدادات الأصلية أولاً.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        duration = transition.getDuration()

        if duration >= 0:
            print(f"Slide {slide.getSlideNumber()}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.getSlideNumber()}: no explicit duration; timing depends on transition type {transition.getType()} and speed {transition.getSpeed()}.")
finally:
    presentation.dispose()
```

## **انتقال Morph**

يقوم انتقال Morph بتحريك التغييرات بين الكائنات على الشرائح المتتالية. لإنشاء تأثير Morph بسيط، استنسخ شريحة، حرّك أو غيّر حجم كائن على النسخة، وطبق انتقال Morph على الشريحة الثانية. يُعطي هذا للانتقال الكائنات المقابلة لتتحرك بين حالتهم الأصلية والمعدَّلة.

المثال التالي يخلق شريحة تحتوي على مستطيل نص، يستنسخ الشريحة، ويغيّر موضع وحجم المستطيل على النسخة. ثم يختار Morph من تعداد [TransitionType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/transitiontype/) للشفرة الثانية. افتح الملف المحفوظ في عارض عروض يدعم Morph لرؤية التأثير أثناء عرض الشرائح.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, ShapeType

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    rectangle = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100)
    rectangle.getTextFrame().setText("Morph transition")

    second_slide = presentation.getSlides().addClone(first_slide)
    moved_rectangle = second_slide.getShapes().get_Item(0)
    moved_rectangle.setX(moved_rectangle.getX() + 100)
    moved_rectangle.setY(moved_rectangle.getY() + 50)
    moved_rectangle.setWidth(moved_rectangle.getWidth() - 200)
    moved_rectangle.setHeight(moved_rectangle.getHeight() - 10)

    second_slide.getSlideShowTransition().setType(TransitionType.Morph)

    presentation.save("morph-transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **أنواع انتقال Morph**

يتحكم تعداد [TransitionMorphType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/transitionmorphtype/) في طريقة مطابقة المحتوى وتحريكه:

- [ByObject](https://reference.aspose.com/slides/ar/python-java/aspose.slides/transitionmorphtype/#ByObject) يعامل كل شكل ككائن كامل.
- [ByWord](https://reference.aspose.com/slides/ar/python-java/aspose.slides/transitionmorphtype/#ByWord) يحرك النص بمطابقة الكلمات حيثما أمكن.
- [ByChar](https://reference.aspose.com/slides/ar/python-java/aspose.slides/transitionmorphtype/#ByChar) يحرك النص بمطابقة الأحرف حيثما أمكن.

استخدم [setType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/#setType) لتحديد Morph قبل الوصول إلى [getValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/#getValue). تكون القيمة بعدها مثالًا من فئة [MorphTransition](https://reference.aspose.com/slides/ar/python-java/aspose.slides/morphtransition/)، وتختار طريقة المطابقة عبر طريقة [setMorphType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/morphtransition/#setMorphType).

يفتح المثال التالي العرض التقديمي الذي تم إنشاؤه في القسم السابق ويضبط الشريحة الثانية لاستخدام تحريك Morph المبني على الكلمات.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, TransitionMorphType, MorphTransition

presentation = Presentation("morph-transition.pptx")
try:
    if presentation.getSlides().size() >= 2:
        transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        transition.setType(TransitionType.Morph)
        transition_value = transition.getValue()

        if isinstance(transition_value, MorphTransition):
            morph_transition = transition_value
            morph_transition.setMorphType(TransitionMorphType.ByWord)
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **تعيين تأثيرات الانتقال**

بعض الانتقالات تكشف عن خيارات إضافية، مثل الاتجاه أو ما إذا كان يبدأ التأثير من شاشة سوداء. تعتمد الخيارات المتاحة على الانتقال المحدد عبر [setType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/#setType). حدّد النوع أولاً، ثم استخدم الفئة المناسبة من [getValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/#getValue).

المثال التالي يطبق انتقال Cut على الشريحة الأولى من `input.pptx`. يستدعي [setFromBlack](https://reference.aspose.com/slides/ar/python-java/aspose.slides/optionalblacktransition/#setFromBlack) عبر فئة [OptionalBlackTransition](https://reference.aspose.com/slides/ar/python-java/aspose.slides/optionalblacktransition/) لجعل الانتقال يبدأ من شاشة سوداء.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, OptionalBlackTransition

presentation = Presentation("input.pptx")
try:
    transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
    transition.setType(TransitionType.Cut)
    transition_value = transition.getValue()

    if isinstance(transition_value, OptionalBlackTransition):
        cut_transition = transition_value
        cut_transition.setFromBlack(True)
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx)
    else:
        print("Cut transition options are unavailable.")
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟**

نعم. يُفضل استخدام [setDuration](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/#setDuration) عندما تحتاج إلى مدة تأثير دقيقة بالمللي ثانية. استخدم [setSpeed](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/#setSpeed) عندما تكون فئة [TransitionSpeed](https://reference.aspose.com/slides/ar/python-java/aspose.slides/transitionspeed/) المحددة مسبقًا—Slow أو Medium أو Fast—كافية ولا توجد مدة صريحة. تتحكم هذه الإعدادات في تأثير الانتقال بشكل مستقل عن تأخير التقدم التلقائي.

**هل يمكنني ربط صوت بانتقال وجعله يتكرر؟**

نعم. عيّن صوتًا مدمجًا عبر [setSound](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/#setSound)، مرّر StartSound من تعداد [TransitionSoundMode](https://reference.aspose.com/slides/ar/python-java/aspose.slides/transitionsoundmode/) إلى [setSoundMode](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/#setSoundMode)، وفعل [setSoundLoop](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/#setSoundLoop) بـ `True`. يتكرر الصوت حتى حدث صوتي التالي في عرض الشرائح.

**ما أسرع طريقة لتطبيق نفس الانتقال على جميع الشرائح؟**

قم بالتكرار عبر مجموعة [getSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSlides) في العرض التقديمي واستدعِ [setType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/#setType) بنفس القيمة لكل انتقال شريحة. اضبط أي إعدادات توقيت أو تأثير في نفس الحلقة للحفاظ على سلوك متسق عبر الشرائح.

**كيف يمكنني التحقق من الانتقال المحدد حاليًا على شريحة؟**

استدعِ [getType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowtransition/#getType) على نتيجة [getSlideShowTransition](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/#getSlideShowTransition) للشفرة. تُرجع قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/transitiontype/)؛ _None يعني أنه لا يُطبق أي تأثير انتقال.