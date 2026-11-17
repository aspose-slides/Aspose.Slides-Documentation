---
title: إدارة انتقالات الشرائح في العروض التقديمية باستخدام Python عبر Java
linktitle: انتقال الشريحة
type: docs
weight: 80
url: /ar/python-java/slide-transition/
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
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تطبيق انتقالات الشرائح، تكوين التقدم التلقائي للشرائح، وتخصيص تأثيرات Morph وغيرها من تأثيرات الانتقال باستخدام Aspose.Slides للـ Python عبر Java."
---
## **نظرة عامة**

تتحكم انتقالات الشرائح في طريقة ظهور الشرائح أثناء عرض الشرائح. باستخدام Aspose.Slides للـ Python عبر Java، يمكنك اختيار تأثير الانتقال لكل شريحة، وتكوين التقدم بالنقر بالماوس أو المؤقت، وضبط الخيارات الخاصة بكل تأثير. يستخدم هذا المقال أمثلة بايثون لتطبيق الانتقالات، وتعيين مدة انتقال دقيقة، وإدارة توقيت الشرائح، وإنشاء انتقال Morph بين شريحتين. تُظهر الأمثلة أيضًا كيفية حفظ الإعدادات إلى ملف PPTX.

## **إضافة انتقال شريحة**

لتطبيق انتقال، قم بتحميل عرض تقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ثم الوصول إلى إعدادات انتقال الشريحة عبر [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition). استخدم [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) مع قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/)، ثم احفظ العرض التقديمي.

الت المثال التالي يطبق انتقال Circle على الشريحة الأولى وانتقال Comb على الشريحة الثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

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

## **انتقال العجلة**

استخدم [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) لاختيار Wheel من تعداد [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/). ثم استدعِ [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) للوصول إلى إعدادات [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/). تتحكم طريقة [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) في عدد القطاعات الشعاعية التي تكشف الشريحة الهدف.

ينشئ المثال زوجين متماثلين من الشرائح. يبدأ كل زوج بشريحة سوداء وينتهي بمستطيل ذهبي يغطي الشريحة بالكامل. تستخدم كلتا شريحتين الهدف نفس السرعة البطيئة التي تُحدد بـ [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) ونفس المدة الصريحة 8000 مللي ثانية التي تُحدد بـ [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration). يتغير عدد الأسنان فقط.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionSpeed, TransitionType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())
    height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())

    slides = presentation.getSlides()
    black_slide = slides.get_Item(0)
    black_slide.getShapes().clear()
    background = black_slide.getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Solid)
    background.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    destination_slide = slides.addClone(black_slide)
    rectangle = destination_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, width, height)
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color(255, 215, 0))
    rectangle.getTextFrame().setText("Wheel transition")

    slides.addClone(black_slide)
    slides.addClone(destination_slide)
    for slide_index, spokes in ((1, 1), (3, 8)):
        transition = slides.get_Item(slide_index).getSlideShowTransition()
        transition.setType(TransitionType.Wheel)
        wheel_transition = transition.getValue()
        wheel_transition.setSpokes(spokes)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(8000)

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

افتح `wheel-transitions.pptx` في PowerPoint وابدأ عرض الشرائح. انتقل من الشريحة 1 إلى الشريحة 2 لتشاهده دورة واحدة مع اتجاه عقربي تكشف المستطيل الذهبي. ثم انتقل من الشريحة 3 إلى الشريحة 4 لترى ثمان قطاعات شعاعية تكشف المستطيل نفسه في آن واحد.

## **إضافة انتقال شريحة متقدم**

يمكنك تكوين مدة بقاء الشريحة على الشاشة وما إذا كان النقر بالماوس يقدّم عرض الشرائح. تتحكم الطرق التالية في هذا السلوك:

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) يتيح للمشاهد التقدم بالنقر.
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) يفعّل التقدم التلقائي.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) يحدّد التأخير قبل التقدم التلقائي، بالمللي ثانية.

فعّل كل من التقدم بالنقر والوقت لتتيح للمشاهد التقدم بالنقر أو الانتظار للمؤقت. لاستخدام المؤقت فقط، مرّر `False` إلى [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). يتحكم التأخير في وقت تقديم عرض الشرائح؛ ولا يحدد مدة تأثير الانتقال البصري.

هذا المثال يعيّن تأثيرات مختلفة للشرائح الثلاث الأولى ويفعّل التقدم التلقائي بعد 3، 5، 7 ثوانٍ على التوالي. يمكن أيضًا النقر بالماوس لتقدم هذه الشرائح. استخدم ملف `input.pptx` يحتوي على ثلاث شرائح على الأقل.

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

للتحقق مما إذا كان التقدم الزمني مفعلاً، استدعِ [getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter). مجرد وجود تأخير مخزن لا يعني أن المؤقت نشط.

المثال التالي يفتح الملف المحفوظ أعلاه، يبلغ عن كل مؤقت مفعّل، ويعطل التقدم التلقائي للشرائح التي لديها تأخير يزيد عن ثانيتين. يفعّل النقر بالماوس لتلك الشرائح ويحفظ الإعدادات المحدثة.

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

## **التحكم الدقيق في توقيت الانتقال**

استخدم [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) لتحديد الطول الدقيق لتأثير الانتقال بالمللي ثانية. تكشف طريقة الشريحة [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) عن هذه الإعدادات عبر فئة [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/) :

| طريقة | الغرض |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | يحدد مدة تأثير الانتقال ذاته، بالمللي ثانية. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | يحدد التأخير قبل تقدم الشريحة تلقائيًا، بالمللي ثانية. مرّر `True` إلى [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) لتفعيل هذا المؤقت. |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | يختار فئة سرعة مسبقة التعريف من تعداد [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/): Slow، Medium، Fast. تُستَخدم عندما لا تُحدّد مدة صريحة. |

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) يتحكم فقط في تأثير الانتقال؛ ولا يحدد مدة بقاء الشريحة مرئية. اضبط تأخير التقدم التلقائي بشكل منفصل. عندما لا تُحدّد مدة صريحة، يحدد Aspose.Slides مدة التأثير بناءً على نوع الانتقال وقيمة [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*المثال المشترك يمنح كل شريحة انتقال Fade بمدة 750 مللي ثانية ويفعّل التقدم التلقائي بعد 5 000 مللي ثانية. مدة الانتقال تتحكم في التأثير؛ والتقدم يتحكم في موعد مغادرة الشريحة. هذه الأشرطة تمثل إعدادات تخطيطية، ليست مخططًا زمنيًا مُقاسًا.*
<!-- visual-explanation:slide-transition:end -->

### **تطبيق نفس المدة على كل شريحة**

لضمان وتيرة ثابتة، طبّق نفس التأثير ونفس المدة الدقيقة على كل شريحة. هذا المثال يحمل `input.pptx`، يختار Fade من تعداد [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/)، ويعطي كل انتقال مدة 750 مللي ثانية. يفعّل التقدم التلقائي بعد 5 000 مللي ثانية ويعطل التقدم بنقرة الفأرة، ثم يحفظ النتيجة كملف PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
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

### **تحديد مدد مختلفة للشرائح الفردية**

يمكن للشرائح المختلفة أن تستخدم مدد تأثير مختلفة. على سبيل المثال، استخدم انتقالًا سريعًا لشريحة العنوان وانتقالًا أطول لمقدمة القسم. هذا المثال يحدد 500 مللي ثانية للشريحة الأولى و1 200 مللي ثانية للثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

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

عند إعداد [animated GIF](/slides/ar/python-java/convert-powerpoint-to-animated-gif/)، [HTML5 presentation](/slides/ar/python-java/export-to-html5/)، أو [video](/slides/ar/python-java/convert-powerpoint-to-video/)، عيّن مدد الانتقال الدقيقة قبل التصدير لتتناسب مع الإيقاع المطلوب. على سبيل المثال، استخدم تلاشيًا بمدة 600 مللي ثانية بين المشاهد، واضبط تأخير تقدم كل شريحة بصورة منفصلة لإتاحة الوقت للشرح الصوتي أو المحتوى.

بالنسبة للـ GIF والفيديو، نسّق معدل إطارات الإخراج مع مدة التأثير: 600 مللي ثانية تعادل 18 إطارًا عند 30 إطارًا في الثانية. في HTML5، فعّل الانتقالات المتحركة في إعدادات التصدير. تحقّق من تأثيرات وتوقيتات الصيغة المُختارة، واستعرض الإخراج للتأكد من التزامن.

### **قراءة مدة الانتقال الموجودة**

استدعِ [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) قبل تعديل الانتقال لتحديد ما إذا كانت قيمة صريحة مُخزّنة. القيمة `-1` تعني عدم وجود مدة صريحة؛ القيمة غير السالبة تُحدّد المدة المخزّنة بالمللي ثانية. القيمة غير المُحددة ليست مدة التشغيل المحتسبة: يستخدم Aspose.Slides نوع الانتقال وقيمة [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) لتحديد تلك المدة. قد يُنشئ تعيين نوع الانتقال مدةً مبدئية، لذا افحص الإعدادات الأصلية أولًا.

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

يُحرك انتقال Morph التغييرات بين الكائنات على الشرائح المتتالية. لإنشاء تأثير Morph بسيط، استنسخ شريحة، انقل أو غير حجم كائن على النسخة، وطبق انتقال Morph على الشريحة الثانية. هذا يمنح الكائنات المتطابقة انتقالًا بينها من الحالة الأصلية إلى المعدلة.

المثال التالي ينشئ شريحة تحتوي على مستطيل نصي، ينسخ الشريحة، ويغيّر موضع وحجم المستطيل على النسخة. ثم يختار Morph من تعداد [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) للشريحة الثانية. افتح الملف المحفوظ في عارض يدعم Morph لتشاهد التأثير أثناء عرض الشرائح.

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

يتحكم تعداد [TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) في طريقة مطابقة وتحريك المحتوى:

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) يتعامل مع كل شكل ككائن كامل.
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) يُحرك النص بمطابقة الكلمات حيثما أمكن.
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) يُحرك النص بمطابقة الأحرف حيثما أمكن.

استخدم [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) لاختيار Morph قبل الوصول إلى [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue). ستكون القيمة بعد ذلك نسخة من فئة [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/)، وتختار طريقة المطابقة عبر طريقة [setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType).

هذا المثال يفتح العرض التقديمي الذي تم إنشاؤه في القسم السابق ويُعدّل الشريحة الثانية لتستخدم تحريكًا مبنيًا على الكلمات.

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

تكشف بعض الانتقالات عن خيارات إضافية، مثل الاتجاه أو ما إذا كان التأثير يبدأ من شاشة سوداء. تعتمد الخيارات المتاحة على الانتقال المُختار عبر [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType). حدد النوع أولًا، ثم استخدم الفئة المناسبة عبر [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue).

المثال التالي يطبق انتقال Cut على الشريحة الأولى من `input.pptx`. يستدعي [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack) عبر فئة [OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/) لجعل الانتقال يبدأ من شاشة سوداء.

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

**هل يمكنني التحكم بسرعة تشغيل انتقال الشريحة؟**

نعم. يفضل استخدام [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) عندما تحتاج إلى مدة تأثير دقيقة بالمللي ثانية. استخدم [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) عندما تكون فئة [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) مسبقة التعريف (Slow، Medium، Fast) كافية ولا تُحدّد مدة صريحة. تتحكم هذه الإعدادات في تأثير الانتقال بشكل مستقل عن تأخير التقدم التلقائي.

**هل يمكنني إرفاق صوت بالانتقال وجعله يتكرر؟**

نعم. عيّن صوتًا مضمّنًا عبر [setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound)، مرّر قيمة StartSound من تعداد [TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/) إلى [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode)، وفعل [setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop) بـ `True`. سيستمر الصوت في التكرار حتى الحدث الصوتي التالي في عرض الشرائح.

**ما أسرع طريقة لتطبيق نفس الانتقال على كل شريحة؟**

قم بالتكرار عبر مجموعة [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) في العرض التقديمي وادعُ [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) بنفس القيمة لكل شريحة. عيّن أي توقيتات وخيارات تأثير في نفس الحلقة للحفاظ على سلوك متسق عبر الشرائح.

**كيف يمكنني التحقق من الانتقال الحالي المعين على شريحة؟**

استدعِ [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType) على نتيجة [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) للشريحة. ستُعيد قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/); القيمة None_ تعني عدم تطبيق أي تأثير انتقال.