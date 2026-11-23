---
title: إدارة انتقالات الشرائح في العروض التقديمية باستخدام Python عبر Java
linktitle: انتقال الشريحة
type: docs
weight: 80
url: /ar/python-java/slide-transition/
keywords:
- انتقال الشريحة
- إضافة انتقال شريحة
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
description: "تطبيق انتقالات الشرائح، تكوين التقدم التلقائي للشرائح، وتخصيص Morph وتأثيرات الانتقال الأخرى باستخدام Aspose.Slides للغة Python عبر Java."
---
## **نظرة عامة**

تتحكم انتقالات الشرائح في طريقة ظهور الشرائح أثناء عرض الشرائح. باستخدام Aspose.Slides للغة Python عبر Java، يمكنك اختيار تأثير انتقال لكل شريحة، وتكوين التقدم بالنقر بالفأرة أو المؤقت، وضبط الخيارات الخاصة بكل تأثير. يستخدم هذا المقال أمثلة بلغة Python لتطبيق الانتقالات، وتعيين مدد انتقال دقيقة، وإدارة توقيت الشرائح، وإنشاء انتقال Morph بين شريحتين. تُظهر الأمثلة أيضًا كيفية حفظ الإعدادات في ملف PPTX.

## **إضافة انتقال للشرائح**

لتطبيق انتقال، قم بتحميل عرض تقديمي باستخدام فئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) والوصول إلى إعدادات انتقال الشريحة عبر [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition). استخدم [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) بقيمة من تعداد [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/)، ثم احفظ العرض التقديمي.

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

## **انتقال العجلة**

استخدم [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) لاختيار Wheel من [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/). ثم استدعِ [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) للوصول إلى إعدادات [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/). تتحكم طريقة [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) في عدد القطاعات الشعاعية التي تكشف الشريحة الوجهة.

يقوم المثال بإنشاء زوجين متطابقين من الشرائح. يبدأ كل زوج بشريحة سوداء وينتهي بمستطيل ذهبي يغطي الشريحة بالكامل. تستخدم كل الشرائح الوجهة نفس السرعة البطيئة التي تم ضبطها بـ[setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) ونفس المدة الصريحة 8,000 مللي ثانية التي تم ضبطها بـ[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration). يتغير عدد القطاعات فقط.

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

افتح `wheel-transitions.pptx` في PowerPoint وابدأ عرض الشرائح. انتقل من الشريحة 1 إلى الشريحة 2 لتشاهد حركة دورانية واحدة تكشف المستطيل الذهبي. ثم انتقل من الشريحة 3 إلى الشريحة 4 لتشاهد ثماني قطاعات شعاعية تكشف المستطيل نفسه في آن واحد.

## **تلاشي من خلال اللون الأسود باستخدام انتقال Reveal**

اضبط نوع انتقال الشريحة الوجهة إلى Reveal، ثم استدعِ [setThroughBlack](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/#setThroughBlack) على إعدادات [RevealTransition](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/). ينشئ المثال شريحة مصدر بلون فسيلي وشريحة وجهة بلون مرجاني، ثم يستنسخهما. يستخدم كل زوج نفس انتقال Reveal مدته ثانيتان. فقط الزوج الثاني يتلاشى عبر اللون الأسود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, PresetColor, Presentation, SaveFormat, ShapeType
from asposeslides.api import TransitionLeftRightDirectionType, TransitionSpeed, TransitionType


def style_slide(slide, background_color, label):
    slide.getBackground().setType(BackgroundType.OwnBackground)
    fill = slide.getBackground().getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setPresetColor(background_color)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130)
    shape.getTextFrame().setText(label)
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setFontHeight(44)


presentation = Presentation()
try:
    source = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addClone(source)
    style_slide(source, PresetColor.Teal, "Source")
    style_slide(destination, PresetColor.Coral, "Destination")

    presentation.getSlides().addClone(source)
    cloned_destination = presentation.getSlides().addClone(destination)
    for slide in (destination, cloned_destination):
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Reveal)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(2000)

        reveal = transition.getValue()
        reveal.setDirection(TransitionLeftRightDirectionType.Left)
        reveal.setThroughBlack(slide is cloned_destination)

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

افتح `reveal-transitions.pptx` في PowerPoint وابدأ عرض الشرائح. انتقل من الشريحة 1 إلى الشريحة 2 لتشاهد الفسيلي يتلاشى مباشرةً إلى المرجاني. ثم انتقل من الشريحة 3 إلى الشريحة 4. سيتظلم الشاشة مؤقتًا إلى اللون الأسود القريب قبل ظهور شريحة المرجاني. تحتفظ كلتا الشريحتين بألوان الخلفية الأصلية.

الصفوف أدناه تُظهر إطارات من PowerPoint بفواصل نصف ثانية. قارن الإطار الأوسط في كل صف لتلاحظ التأثير.

![تشغيل PowerPoint مع تعطيل تلاشي عبر الأسود (أعلى) وتمكينه (أسفل). الصف السفلي فقط يمر عبر اللون الأسود القريب.](reveal-through-black.png)

## **إضافة انتشار شريحة متقدم**

يمكنك تكوين مدة بقاء الشريحة على الشاشة وما إذا كان النقر بالفأرة سيُقدّم عرض الشرائح. تتحكم الطرق التالية في هذا السلوك:

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) يسمح للمستخدم بالتقدم بالنقر بالفأرة.
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) يفعّل التقدم التلقائي.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) يحدد التأخير قبل التقدم التلقائي، بالمللي ثانية.

فعّل كلا من النقر والتقدم المؤقت لتسمح للمستخدم بالتقدم بالنقر أو الانتظار حتى المؤقت. لاستخدام المؤقت فقط، مرّر `False` إلى [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). يتحكم التأخير في متى يتقدم عرض الشرائح؛ لا يحدد مدة تأثير الانتقال البصري.

يُعيّن هذا المثال تأثيرات مختلفة للشرائح الثلاث الأولى ويُفعّل التقدم التلقائي بعد 3 و 5 و 7 ثوانٍ على التوالي. يمكن للنقرات بالفأرة أيضًا أن تُقدّم هذه الشرائح. استخدم ملف `input.pptx` يحتوي على ثلاث شرائح على الأقل.

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

للتحقق مما إذا كان التقدم المؤقت مفعّلًا، استدعِ [getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter). التخزين المؤقت للتأخير وحده لا يدل على أنّ المؤقت نشط.

المثال التالي يفتح الملف المحفوظ أعلاه، يردّ كل مؤقت مفعّل، ويعطّل التقدم التلقائي للشرائح التي لديها تأخير أكبر من ثانيتين. يعيد تفعيل النقر بالفأرة لتلك الشرائح ويحفظ الإعدادات المحدثة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

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

استخدم [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) لتحديد الطول الدقيق لتأثير الانتقال بالمللي ثانية. تُظهر طريقة [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) للشفرة هذه الإعدادات عبر [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/):

| الطريقة | الغرض |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | يحدّد مدة تأثير الانتقال نفسه، بالمللي ثانية. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | يحدّد التأخير قبل أن تتقدم الشريحة تلقائيًا، بالمللي ثانية. مرّر `True` إلى [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) لتفعيل هذا المؤقت. |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | يختار فئة سرعة مُحددة مسبقًا من تعداد [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/): Slow أو Medium أو Fast. يُستَخدم عندما لا تُحدَّد مدة صريحة. |

يُتحكم [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) فقط في تأثير الانتقال؛ لا يحدّد مدة بقاء الشريحة مرئية. قم بتكوين تأخير التقدم التلقائي بشكل منفصل. عندما لا تُحدَّد مدة صريحة، يحدد Aspose.Slides مدة التأثير بناءً على نوع الانتقال وقيمة [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![الأشرطة المنفصلة تُظهر مدة الانتقال 750 مللي ثانية وإعداد التقدم التلقائي 5,000 مللي ثانية.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*يعطي المثال المشترك لكل شريحة انتقال Fade مدته 750 مللي ثانية ويفعّل التقدم التلقائي بعد 5,000 مللي ثانية بشكل منفصل. تتحكم مدة الانتقال في التأثير؛ يتحكم التقدم في وقت مغادرة الشريحة. هذه الأشرطة تمثّل إعدادات تخطيطية، ليست مخططًا زمنيًا مُقاسًا مُجمعًا.*
<!-- visual-explanation:slide-transition:end -->

### **تطبيق نفس المدة على كل شريحة**

لتحقيق وتيرة ثابتة، طبق نفس التأثير والمدة الدقيقة على كل شريحة. يقوم هذا المثال بتحميل `input.pptx`، يختار Fade من تعداد [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/)، ويعطي كل انتقال مدة 750 مللي ثانية. يُفعّل التقدم التلقائي بعد 5,000 مللي ثانية ويعطل التقدم بالنقر، ثم يحفظ النتيجة كملف PPTX.

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

        # ضبط التقدم التلقائي بشكل مستقل عن مدة التأثير.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **تعيين مدد مختلفة للشرائح الفردية**

يمكن للشرائح المختلفة استخدام مدد تأثير مختلفة. على سبيل المثال، استخدم انتقالًا قصيرًا لشريحة العنوان وانتقالًا أطول لمقدمة القسم. يحدد هذا المثال 500 مللي ثانية للشرائح الأولى و1,200 مللي ثانية للشرائح الثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

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

عند إعداد [GIF المتحرك](/slides/ar/python-java/convert-powerpoint-to-animated-gif/) أو [عرض HTML5](/slides/ar/python-java/export-to-html5/) أو [فيديو](/slides/ar/python-java/convert-powerpoint-to-video/)، ضع مدد انتقال دقيقة قبل التصدير لتتناسب مع الوتيرة المقصودة. على سبيل المثال، استخدم تلاشيًا مدته 600 مللي ثانية بين المشاهد، واضبط تأخير تقدم كل شريحة بشكل منفصل للسماح بالوقت لسردها أو محتواها.

بالنسبة للـ GIF والفيديو، نسّق معدل الإطارات للمخرجات مع مدة التأثير: 600 مللي ثانية تعادل 18 إطارًا عند 30 إطارًا في الثانية. في HTML5، فعّل الانتقالات المتحركة في إعدادات التصدير. تحقق من التأثيرات وخيارات التوقيت المدعومة من تنسيق التصدير المختار، واعرض المعاينة للتأكد من التزامن.

### **قراءة مدة انتقال موجودة**

استدعِ [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) قبل تعديل الانتقال لتحديد ما إذا كانت قيمة صريحة مخزَّنة. القيمة `-1` تعني عدم وجود مدة صريحة؛ القيمة غير السالبة تحدد المدة المخزَّنة بالمللي ثانية. القيمة غير المحددة ليست مدة التشغيل المحسوبة: يستخدم Aspose.Slides نوع الانتقال وقيمة [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) لتحديد تلك المدة. قد تُنشئ تعيين نوع الانتقال مدةً مبدئية، لذا تحقق من الإعدادات الأصلية أولًا.

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

يُحرك انتقال Morph التغييرات بين الكائنات على الشرائح المتتالية. لإنشاء تأثير Morph بسيط، استنسخ شريحة، انقل أو عدّل حجم كائن على النسخة، وطبق انتقال Morph على الشريحة الثانية. يمنح ذلك الانتقال الكائنات المقابلة لتُحرك بين حالتها الأصلية والمعدَّلة.

ينشئ المثال التالي شريحة تحتوي على مستطيل نصي، يستنسخ الشريحة، ويغيّر موقع وحجم المستطيل على النسخة. ثمّ يختار Morph من تعداد [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) للشريحة الثانية. افتح الملف المحفوظ في عارض عروض يدعم Morph لتلاحظ التأثير أثناء عرض الشرائح.

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

يتحكم تعداد [TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) في طريقة مطابقة وتحريك المحتوى خلال Morph:

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) يعامل كل شكل ككائن كامل.
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) يحرك النص بمطابقة الكلمات قدر الإمكان.
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) يحرك النص بمطابقة الأحرف قدر الإمكان.

استخدم [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) لاختيار Morph قبل الوصول إلى [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue). تكون القيمة عندئذٍ كائنًا من فئة [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/)، وتختار طريقة المطابقة عبر طريقة [setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType).

يفتح هذا المثال العرض التقديمي الذي أنشئ في القسم السابق ويضبط الشريحة الثانية لاستخدام تحريك Morph على أساس الكلمات.

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

تُظهر بعض الانتقالات خيارات إضافية، مثل الاتجاه أو ما إذا كان يبدأ التأثير من شاشة سوداء. تعتمد الخيارات المتاحة على الانتقال المُختار عبر [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType). اضبط النوع أولًا، ثم استخدم الفئة المناسبة عبر [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue).

يطبق المثال التالي انتقال Cut على الشريحة الأولى من `input.pptx`. يستدعي [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack) عبر فئة [OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/) لجعل الانتقال يبدأ من شاشة سوداء.

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

## **الأسئلة الشائعة**

**هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟**

نعم. يفضَّل استخدام [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) عندما تحتاج إلى مدة تأثير دقيقة بالمللي ثانية. استخدم [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) عندما تكون فئة سرعة مُحدَّدة مسبقًا من [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/)—Slow أو Medium أو Fast—كافية ولا تُحدَّد مدة صريحة. تتحكم هذه الإعدادات في تأثير الانتقال بشكل مستقل عن تأخير التقدم التلقائي.

**هل يمكنني إرفاق صوت بانتقال وجعله يتكرر؟**

نعم. عيّن صوتًا مضمّنًا عبر [setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound)، مرّر `StartSound` من تعداد [TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/) إلى [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode)، وفعل [setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop) بالقيمة `True`. يتكرر الصوت حتى حدث صوتي التالي في عرض الشرائح.

**ما أسرع طريقة لتطبيق نفس الانتقال على جميع الشرائح؟**

ا المستخدم حلقة عبر مجموعة [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) في العرض التقديمي واستدعِ [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) بنفس القيمة لكل شريحة. عيّن أي إعدادات توقيت وتأثير داخل نفس الحلقة للحفاظ على سلوك موحد عبر جميع الشرائح.

**كيف يمكنني التحقق من الانتقال الحالي المطبق على شريحة؟**

استدعِ [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType) على نتيجة [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) للشريحة. تُعيد قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/)؛ `None_` يعني عدم تطبيق أي تأثير انتقال.