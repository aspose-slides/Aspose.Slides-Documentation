---
title: إنشاء وتعديل سلوكيات الرسوم المتحركة المخصصة في Python عبر Java
linktitle: الرسوم المتحركة المخصصة
type: docs
weight: 151
url: /ar/python-java/custom-animation/
keywords:
- رسوم متحركة مخصصة
- سلوك الرسوم المتحركة
- مسار الحركة
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إنشاء وفحص وتعديل سلوكيات الرسوم المتحركة المخصصة ومسارات الحركة القابلة للتحرير في عروض PowerPoint التقديمية باستخدام Aspose.Slides للـ Python عبر Java."
---
## **نظرة عامة**

تتيح لك سلوكيات الرسوم المتحركة المخصصة التحكم في عمليات فردية داخل تأثير الرسوم المتحركة، مثل تغيير اللون أو تدوير شكل أو تتبع مسار حركة قابل للتحرير. يُظهر هذا الدليل كيفية إنشاء سلوكيات ودمجها، وتكوين توقيتها، وفحص وتعديل الرسوم المتحركة الحالية، والتحقق من بقاء خصائصها محفوظةً بعد حفظ وإعادة فتح العرض التقديمي.

للتأثيرات المحددة مسبقًا ومفاتيح النقر، راجع [رسوم المتحركة للشكل](/slides/ar/python-java/shape-animation/).

## **فهم نموذج الرسوم المتحركة**

تنظم الرسوم المتحركة على النحو التالي **الجدول الزمني → التسلسل → التأثير → السلوكيات**:

- تُعيد طريقة [getTimeline](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/#getTimeline) جدول زمني للشفرة، والذي يحتوي على التسلسل الرئيسي والتسلسلات التفاعلية.
- يحتوي [Sequence](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sequence/) على تأثيرات، قد تستهدف أشكالًا مختلفة.
- يحدد [Effect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effect/) الشكل المستهدف، والإعداد المسبق، والنوع الفرعي، وتوقيت التأثير.
- التجميع الذي تُعيده [Effect.getBehaviors](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effect/#getBehaviors) يحتوي على العمليات التي تُنَفِّذ التأثير: تغيير اللون، التحريك، التدوير، تعيين خاصية، وما إلى ذلك.

## **إنشاء سلوكيات فردية**

استدعِ [Sequence.addEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sequence/#addEffect) لإنشاء تأثير والوصول إلى مجموعة [getBehaviors](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effect/#getBehaviors). يمكن لإعداد مسبق أن يملأ هذه المجموعة تلقائيًا. احتفظ بعملياته عند توسيع الإعداد المسبق، أو استخدم [clear](https://reference.aspose.com/slides/ar/python-java/aspose.slides/behaviorcollection/#clear) عند استبدالها عمدًا.

[BehaviorFactory](https://reference.aspose.com/slides/ar/python-java/aspose.slides/behaviorfactory/) تُنشئ الأنواع الثمانية للسلوك الموضحة أدناه. يتم تغطية الحركة في [إنشاء مسار حركة](#build-a-motion-path). يتضمن كل مقطع استيراداته ويبدأ JVM إذا لزم الأمر. يتم إنشاء كائنات النقاط والمصفوفات في Java عبر JPype حيث يتطلب API ذلك. تُبيّن أمثلة التحرير اللاحقة أي ملف إخراج تُستخدم.

### **التدوير**

استخدم [createRotationEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/behaviorfactory/#createRotationEffect) لإنشاء تدوير. تُحدِّد [getBy](https://reference.aspose.com/slides/ar/python-java/aspose.slides/rotationeffect/#getBy) زاوية نسبية بالدرجات؛ وتحدِّد [getFrom](https://reference.aspose.com/slides/ar/python-java/aspose.slides/rotationeffect/#getFrom) و[getTo](https://reference.aspose.com/slides/ar/python-java/aspose.slides/rotationeffect/#getTo) نقاط النهاية.

يبدأ المثال بتأثير Spin، يستبدل عمليات الإعداد المسبق بسلوك تدوير واحد، ويعطي تلك العملية مدة قدرها ثانيتان. تُعبِّر زاوية نسبية قدرها 90 درجة عن ربع دورة من اتجاه الشكل الابتدائي، لذا لا حاجة إلى زاوية بدء صريحة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    rotation = factory.createRotationEffect()
    rotation.setBy(90)
    rotation.getTiming().setDuration(2)

    effect.getBehaviors().add(rotation)

    presentation.save("rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`rotation.pptx` يحتوي على شكل واحد وسلوك تدوير واحد. تُستخدم المجموعة، والتوقيت، وأمثلة تحرير التدوير أدناه هذا الملف.

### **التحجيم**

استخدم [createScaleEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/behaviorfactory/#createScaleEffect) بنسب X/Y: تُصفِّف [getFrom](https://reference.aspose.com/slides/ar/python-java/aspose.slides/scaleeffect/#getFrom) و[getTo](https://reference.aspose.com/slides/ar/python-java/aspose.slides/scaleeffect/#getTo) الحجم الابتدائي والنهائي، بينما تُصفِّف [getBy](https://reference.aspose.com/slides/ar/python-java/aspose.slides/scaleeffect/#getBy) تغيرًا نسبيًا. هنا، يعني 100 الحجم الأصلي.

يكبر المثال البعدين من 100٪ إلى 125٪ خلال ثانيتين. الحفاظ على نسب أفقية ورأسية متساوية يحافظ على تناسب الشكل؛ النسب المختلفة ستمدد بُعدًا أكثر من الآخر.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setFrom(Point2DFloat(100, 100))
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    effect.getBehaviors().add(scale)

    presentation.save("scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **اللون**

استخدم [createColorEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/behaviorfactory/#createColorEffect) لتغيير التعبئة من الأزرق إلى البرتقالي. [getFrom](https://reference.aspose.com/slides/ar/python-java/aspose.slides/coloreffect/#getFrom) و[getTo](https://reference.aspose.com/slides/ar/python-java/aspose.slides/coloreffect/#getTo) هما ألوان؛ [getBy](https://reference.aspose.com/slides/ar/python-java/aspose.slides/coloreffect/#getBy) هو إزاحة لون. تُحدِّد [Behavior.getProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/behavior/#getProperties) السمة التي تُحَرَّك.

يُهيَّأ ملء الشكل الصلب إلى الأزرق، مُطابقًا لون البدء في الرسوم المتحركة. اختيار سمة ملء اللون يُخبر السلوك أي جزء من الشكل يُغيّر؛ فالنقاط النهائية للون وحدها لا تحدد تلك السمة. يصف التأثير المحفوظ انتقالًا لمدة ثانيتين إلى البرتقالي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, FillType, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    color = factory.createColorEffect()
    color.getProperties().add(BehaviorProperty.getFillColor().getValue())
    color.getFrom().setColor(Color.BLUE)
    color.getTo().setColor(Color(255, 165, 0))
    color.getTiming().setDuration(2)

    effect.getBehaviors().add(color)

    presentation.save("color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **الفلتر**

استخدم [createFilterEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/behaviorfactory/#createFilterEffect) لاختيار مسح. تُحدِّد [getType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/filtereffect/#getType)، [getSubtype](https://reference.aspose.com/slides/ar/python-java/aspose.slides/filtereffect/#getSubtype)، و[getReveal](https://reference.aspose.com/slides/ar/python-java/aspose.slides/filtereffect/#getReveal) الفلتر، الاتجاه، وما إذا كان سيُظهر أو يخفي الشكل.

يضبط هذا المثال مسحًا لمدة ثانيتين يُظهر الشكل باستخدام النوع الفرعي للاتجاه إلى اليمين. تنتمي إعدادات الفلتر إلى السلوك داخل التأثير، لذا تُضبط بعد إزالة عمليات الإعداد المسبق الأصلية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, FilterEffectRevealType, FilterEffectSubtype, FilterEffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    filter = factory.createFilterEffect()
    filter.setType(FilterEffectType.Wipe)
    filter.setSubtype(FilterEffectSubtype.Right)
    filter.setReveal(FilterEffectRevealType.In)
    filter.getTiming().setDuration(2)

    effect.getBehaviors().add(filter)

    presentation.save("filter.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **الخاصية**

استخدم [createPropertyEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/behaviorfactory/#createPropertyEffect) لتحريك الشفافية. [getFrom](https://reference.aspose.com/slides/ar/python-java/aspose.slides/propertyeffect/#getFrom)، [getTo](https://reference.aspose.com/slides/ar/python-java/aspose.slides/propertyeffect/#getTo)، و[getBy](https://reference.aspose.com/slides/ar/python-java/aspose.slides/propertyeffect/#getBy) هي سلاسل تُفسَّر باستخدام [getValueType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/propertyeffect/#getValueType) و[getCalcMode](https://reference.aspose.com/slides/ar/python-java/aspose.slides/propertyeffect/#getCalcMode). اختر نقاط النهاية أو إزاحة نسبية بدلاً من تعيين الثلاثة معًا عشوائيًا.

هنا، السمة المختارة هي الشفافية، وتمثل السلاسل الرقمية تغيرًا من شفافية 25٪ إلى شفافية كاملة. يصف الاستيفاء الخطي تغيرًا تدريجيًا بين تلك القيم. عند تكييف هذا المثال لسمة أخرى، اختر نوع قيمة وقيم نهائية مناسبة لتلك السمة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, PropertyCalcModeType, PropertyValueType, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    property = factory.createPropertyEffect()
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue())
    property.setValueType(PropertyValueType.Number)
    property.setCalcMode(PropertyCalcModeType.Linear)
    property.setFrom("0.25")
    property.setTo("1")
    property.getTiming().setDuration(2)

    effect.getBehaviors().add(property)

    presentation.save("property.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **التعيين**

استخدم [createSetEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/behaviorfactory/#createSetEffect) لتعيين الرؤية عبر [getTo](https://reference.aspose.com/slides/ar/python-java/aspose.slides/seteffect/#getTo). لا يُجري سلوك التعيين استيفاءً بين النقاط النهائية.

يختار المثال سمة الرؤية ويُعيّن السلسلة `visible` عند تشغيل السلوك. الشكل المستطيل مرئي بالفعل في هذا العرض التقديمي البسيط، لذا قد لا يُظهر التعيين تغييرًا بصريًا واضحًا بحد ذاته. تُعدُّ هذه العملية مفيدة كجزء من تأثير أكبر يتحكم أيضًا في توقيت إظهار أو إخفاء الشكل.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    set = factory.createSetEffect()
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue())
    set.setTo("visible")

    effect.getBehaviors().add(set)

    presentation.save("set.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **الأمر**

استخدم [createCommandEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/behaviorfactory/#createCommandEffect) واضبط [getType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/commandeffect/#getType)، [getCommandString](https://reference.aspose.com/slides/ar/python-java/aspose.slides/commandeffect/#getCommandString)، و[getShapeTarget](https://reference.aspose.com/slides/ar/python-java/aspose.slides/commandeffect/#getShapeTarget). ضع ملف تسجيل WAV باسم `sample.wav` في دليل العمل. يُضمِّن هذا المثال الملف باستخدام [addAudioFrameEmbedded](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) ويربط أمر تشغيل بإطار الصوت.

إطار الصوت هو كل من هدف التأثير وهدف الأمر. يربط هذا طلب التشغيل بالتسجيل المضمّن؛ فالسلسلة الأمرية بمفردها لا تحدد كائن الوسائط الذي يجب التحكم فيه. يُضبط التأثير للبدء عند النقر أثناء عرض الشرائح.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path

from asposeslides.api import BehaviorFactory, CommandEffectType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("sample.wav").read_bytes()
    audio_bytes = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(audio_bytes)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audio)

    effect = slide.getTimeline().getMainSequence().addEffect(audio_frame, EffectType.MediaPlay, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    command = factory.createCommandEffect()
    command.setType(CommandEffectType.Call)
    command.setCommandString("play")
    command.setShapeTarget(audio_frame)

    effect.getBehaviors().add(command)

    presentation.save("command.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

يُحفظ الأمر في `command.pptx`؛ لا يُشغَل التسجيل. يتطلب التشغيل مشغل عروض تقديمية يدعم الأمر وهدف وسائطه.

## **إدارة مجموعة السلوكيات**

يدعم [BehaviorCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/behaviorcollection/) عمليات [add](https://reference.aspose.com/slides/ar/python-java/aspose.slides/behaviorcollection/#add)، [insert](https://reference.aspose.com/slides/ar/python-java/aspose.slides/behaviorcollection/#insert)، [remove](https://reference.aspose.com/slides/ar/python-java/aspose.slides/behaviorcollection/#remove)، و[removeAt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/behaviorcollection/#removeAt). يفتح هذا المثال `rotation.pptx`، يضيف تحجيمًا، ينقله قبل التدوير، ثم يزيل التدوير. يغيّر إزالة وإعادة إدخال الكائن نفسه موضعه المخزن دون إنشاء نسخة.

تغيّر تسلسل التعديلات المجموعة من تدوير–تحجيم إلى تحجيم–تدوير، ثم إلى تحجيم فقط. تُشير الفهارس إلى المجموعة الحالية، لذا يستخدم الإزالة فهرس التدوير الجديد بعد إعادة الترتيب. تُؤكد العدّد النهائي أي سلوك سيُحفظ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    behaviors = effect.getBehaviors()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    behaviors.add(scale)

    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.removeAt(1)

    for behavior in behaviors:
        print(behavior.getClass().getSimpleName())

    presentation.save("collection-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

الناتج هو `ScaleEffect`: يبقى التحجيم فقط. لا يُحدِّد ترتيب المجموعة، بحد ذاته، جدولة السلوكيات واحدةً تلو الأخرى. نظّف المجموعة فقط عند استبدال جميع عملياتها.

## **تكوين توقيت السلوك**

يُظهر [Behavior.getTiming](https://reference.aspose.com/slides/ar/python-java/aspose.slides/behavior/#getTiming) [Timing](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/)، بشكل مستقل عن [Effect.getTiming](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effect/#getTiming). يحدد توقيت التأثير جدولة التأثير المحيط؛ يصف توقيت السلوك عملية داخله.

### **تعيين المدة، التأخير، التكرار، والتسارع**

افتح `rotation.pptx` واضبط المدة ([getDuration](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#getDuration)) وتأخير المشغل ([getTriggerDelayTime](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#getTriggerDelayTime)) بالثواني، ثم اضبط عدد التكرارات عبر [setRepeatCount](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#getAccelerate) و[getDecelerate](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#getDecelerate) هما كسور من المدة؛ حافظ على مجموعهما لا يتجاوز 1.

الملف الإدخالي هو الملف الذي أنشئ في مثال التدوير، حيث يُعرف أن السلوك الأول هو تدوير. يغيّر هذا المثال توقيت السلوك فقط؛ يظل زاوية 90 درجة كما هي. يُسهِّل فصل الزاوية عن التوقيت تعديل السرعة دون الحاجة إلى إعادة بناء الرسوم المتحركة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    rotation = effect.getBehaviors().get_Item(0)
    rotation.getTiming().setDuration(2)
    rotation.getTiming().setTriggerDelayTime(0.5)
    rotation.getTiming().setRepeatCount(3)
    rotation.getTiming().setAccelerate(0.2)
    rotation.getTiming().setDecelerate(0.2)

    presentation.save("timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

يستخدم السلوك مدة ثانيتين، وتأخير نصف ثانية، وعدد تكرار 3. تُستخدم أول 20٪ وآخر 20٪ من مدته للتسارع والتباطؤ.

تشمل سياسات التكرار الأخرى [getRepeatDuration](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#getRepeatDuration)، [getRepeatUntilEndSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#getRepeatUntilEndSlide)، و[getRepeatUntilNextClick](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#getRepeatUntilNextClick)؛ اختر سياسةً بدلًا من تمكينها جميعًا. يُعيد [getAutoReverse](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#getAutoReverse) تشغيل الرسوم المتحركة بالعكس بعد المرور الأمامي. ينطبق التسارع والتباطؤ على التغييرات المستمرة، وليس على التعيينات المتقطعة أو الأوامر.

## **إنشاء مسار حركة**

استخدم [createMotionEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/behaviorfactory/#createMotionEffect) لإنشاء حركة. تُصفِّف [getFrom](https://reference.aspose.com/slides/ar/python-java/aspose.slides/motioneffect/#getFrom)، [getTo](https://reference.aspose.com/slides/ar/python-java/aspose.slides/motioneffect/#getTo)، و[getBy](https://reference.aspose.com/slides/ar/python-java/aspose.slides/motioneffect/#getBy) إحداثيات أو إزاحات نسبية. لإنشاء مسار قابل للتحرير، أنشئ [MotionPath](https://reference.aspose.com/slides/ar/python-java/aspose.slides/motionpath/) وعينه باستخدام [MotionEffect.setPath](https://reference.aspose.com/slides/ar/python-java/aspose.slides/motioneffect/#setPath). تُخزّن [MotionPath](https://reference.aspose.com/slides/ar/python-java/aspose.slides/motionpath/) أوامر المسار.

يختار [MotionCommandPathType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/motioncommandpathtype/) العملية:

| الأمر | النقاط | المعنى |
| --- | --- | --- |
| MoveTo | واحدة | تعيين موضع البداية. |
| LineTo | واحدة | الانتقال على مقطع مستقيم إلى نقطة النهاية. |
| CurveTo | ثلاثة | اتباع منحنى تكعيبي يحدده نقطتا تحكم ونقطة النهاية. |
| CloseLoop | لا شيء | العودة إلى موضع البداية. |
| End | لا شيء | إنهاء المسار. |

يصف [MotionPathPointsType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/motionpathpointstype/) خصائص تحرير النقاط، مثل الزوايا أو النقاط السلسة. لا يحلّ محل نوع الأمر. استخدم نوع نقطة المنحنى لمثال المنحنى أدناه، ونوع نقطة الزاوية للمقاطع المستقيمة.

تنظّم إحداثيات المسار وفق أبعاد الشريحة: إزاحة X بقيمة 0.25 تمثّل ربع عرض الشريحة، وليس 0.25 نقطة. Y الموجبة تتجه لأسفل. تحدد الأوامر المطلقة المواضع في نظام إحداثيات المسار؛ وتحدد الأوامر النسبية الإزاحات من الموضع الحالي. هذا منفصل عن [getOrigin](https://reference.aspose.com/slides/ar/python-java/aspose.slides/motioneffect/#getOrigin)، الذي يختار إطار مرجعي للمسار، و[getPathEditMode](https://reference.aspose.com/slides/ar/python-java/aspose.slides/motioneffect/#getPathEditMode)، الذي يتحكم في كيفية تحرك المسار عندما يتحرك الشكل.

### **إنشاء مسار مستقيم**

أنشئ سلوك حركة بنقطة بداية، مقطع مستقيم واحد، وأمر إنهاء. يأخذ [MotionPath.add](https://reference.aspose.com/slides/ar/python-java/aspose.slides/motionpath/#add) نوع الأمر، نقاطه، نوع النقطة، وعلم الإحداثيات النسبية.

يُحدِّد أمر البداية (0, 0)، وينتهي الخط عند (0.25, 0)، مما يمنح المسار إزاحة أفقية قدرها ربع عرض الشريحة. لا يحتوي أمر النهاية على نقاط إحداثية. بمجرد تعيين المسار، يربط إضافة سلوك الحركة إلى التأثير ذلك المسار بالمستطيل.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, MotionCommandPathType, MotionOriginType, MotionPath, MotionPathPointsType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    motion = factory.createMotionEffect()
    motion.setOrigin(MotionOriginType.Layout)
    motion.getTiming().setDuration(2)

    path = MotionPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0, 0)])
    path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
    path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.25, 0)])
    path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)
    path_points_3 = jpype.JArray(Point2DFloat)(0)
    path.add(MotionCommandPathType.End, path_points_3, MotionPathPointsType.None_, False)

    motion.setPath(path)
    effect.getBehaviors().add(motion)

    presentation.save("motion.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`motion.pptx` يحتوي على سلوك حركة واحد بثلاثة أوامر مسار. تُستخدم أمثلة تحرير الملفات التالية هذا البنية المعروفة.

### **مقارنة الإحداثيات المطلقة والنسبية**

هذان كائلا المسار يصفان نفس المسار. ينتهي الأمر المطلق عند (0.3, 0.1)؛ يضيف الأمر النسبي (0.1, 0.1) إلى الموضع الحالي، أي (0.2, 0).

يبدأ كلا المسارين من نفس الموضع. بالنسبة للخط النسبي، أضف إزاحتي X وY إلى الموضع الحالي للحصول على نقطة النهاية؛ بالنسبة للخط المطلق، اقرأ نقطة النهاية مباشرة. سيؤدي تبديل العلم دون تحويل الإحداثيات إلى مسار مختلف.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPath, MotionPathPointsType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

absolute_path = MotionPath()
path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
absolute_path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.3, 0.1)])
absolute_path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)

relative_path = MotionPath()
path_points_3 = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
relative_path.add(MotionCommandPathType.MoveTo, path_points_3, MotionPathPointsType.Auto, False)
path_points_4 = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0.1)])
relative_path.add(MotionCommandPathType.LineTo, path_points_4, MotionPathPointsType.Corner, True)
```

عيّن أي من المسارين إلى سلوك حركة لاستخدامه في عرض تقديمي. يحدد الوسيط البولياني الأخير إحداثيات نسبية لذلك الأمر.

### **استبدال خط بمنحنى**

افتح `motion.pptx` واستبدل أمر الخط بمنحنى تكعيبي. قدّم نقطتي التحكم أولًا، ثم نقطة النهاية.

توفر الموضع الابتدائي بالأمر السابق. تشكِّل النقطتان الأوليتان المنحنى، بينما النقطة الثالثة هي وجهته؛ ليست ثلاث وجهات متتالية. يضمن تحديث نوع الأمر، نوع تحرير النقاط، ومصفوفة النقاط معًا اتساق القطاع مع الشكل الهندسي الجديد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo)
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0), Point2DFloat(0.2, 0.1), Point2DFloat(0.3, 0.1)])
    path.get_Item(1).setPoints(path_points)

    presentation.save("curve.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

لا يزال المسار في `curve.pptx` يحتوي على ثلاثة أوامر؛ الآن يُعرِّف الأمر الأوسط منحنى.

## **فحص وتحرير مسار محفوظ**

كل [MotionCmdPath](https://reference.aspose.com/slides/ar/python-java/aspose.slides/motioncmdpath/) يُظهر [getPoints](https://reference.aspose.com/slides/ar/python-java/aspose.slides/motioncmdpath/#getPoints)، [getCommandType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/motioncmdpath/#getCommandType)، [getPointsType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/motioncmdpath/#getPointsType)، و[isRelative](https://reference.aspose.com/slides/ar/python-java/aspose.slides/motioncmdpath/#isRelative). تستخدم الأمثلة التالية المسار ذو الثلاثة أوامر المعروف في `motion.pptx`. بالنسبة للمدخلات العشوائية، حدِّد التأثير المقصود وتحقق من أنواع الأوامر وعدد النقاط قبل التحرير حسب الفهرس.

### **قراءة الأوامر والإحداثيات**

اقرأ المسار دون تغييره. لا تحتاج أوامر End وCloseLoop إلى نقاط، لذا احرص على السماح بمصفوفة نقاط فارغة.

تُظهر النتيجة كل نوع أمر رقمي مع علم الإحداثيات النسبية قبل سرد نقاطه. يتيح لك ذلك تمييز نقطة النهاية عن إزاحة قبل تعديل المسار. يُظهر المنحنى ثلاث نقاط، بينما يسرد الخط المستقيم في هذا الملف نقطة واحدة فقط.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    for segment in path:
        print(f"{segment.getCommandType()}, relative: {segment.isRelative()}")
        if segment.getPoints() is not None:
            for point in segment.getPoints():
                print(f"X={point.x}, Y={point.y}")
finally:
    presentation.dispose()
```

تحتوي القائمة على نقطة بداية، وخط مطلق ينتهي عند (0.25, 0)، وأمر End.

### **تغيير نقطة النهاية**

افتح `motion.pptx` واستبدل مصفوفة نقاط الخط لتحريك نقطة النهاية.

في ملف الإدخال، الفهرس 0 هو أمر البداية والفهرس 1 هو الخط. استبدال النقطة الوحيدة للخط يغيّر وجهته دون تغيير نوع الأمر أو توقيته أو موضعه في المجموعة. نظرًا لاستخدام الأمر إحداثيات مطلقة، يُحدِّد الزوج الجديد موضعًا بدلاً من إزاحة مضافة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    motion = effect.getBehaviors().get_Item(0)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.4, 0.1)])
    motion.getPath().get_Item(1).setPoints(path_points)

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ينتهي الخط في `motion-endpoint.pptx` عند (0.4, 0.1)؛ يبقى الملف الأصلي دون تغيير.

### **استبدال مقطع**

استخدم [insert](https://reference.aspose.com/slides/ar/python-java/aspose.slides/motionpath/#insert) و[removeAt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/motionpath/#removeAt) لاستبدال الخط في `motion.pptx`. يدفع الإدراج الخط القديم إلى الفهرس 2.

يوضح هذا استبدال كائن أمر بدلاً من تحرير إحداثياته الحالية. بعد الإدراج، تحتوي المجموعة مؤقتًا على أمر البداية، والخط الجديد، والخط القديم، وأمر End. يحذف إزالة الفهرس 2 الخط القديم ويترك المسار الجديد في مكانه.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0.1)])
    path.insert(1, MotionCommandPathType.LineTo, path_points, MotionPathPointsType.Corner, False)
    path.removeAt(2)

    presentation.save("motion-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

لا يزال المسار المحفوظ يحتوي على ثلاثة أوامر، مع خط جديد ينتهي عند (0.2, 0.1) وأمر End في النهاية.

## **تعديل والتحقق من سلوك موجود**

عندما يكون فهرس السلوك غير معروف، حدده حسب النوع. يفتح هذا المثال `rotation.pptx`، يجد [RotationEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/rotationeffect/)، يغيّر الزاوية، ويتحقق من القيمة المحفوظة بعد إعادة الفتح.

يسمح فحص النوع بتخطي السلوكيات التي ليست تدويرات. القراءة الثانية تُحمِّل الملف المحفوظ في كائن عرض تقديمي منفصل، لذا يتحقق المقارنة من البيانات المستمرة بدلاً من القيمة التي لا زالت في الذاكرة. لا يزال هذا المثال يفترض أن التأثير المعروف هو الأول في التسلسل الرئيسي؛ لا يضمن اختيار سلوك حسب النوع العثور على التأثير الصحيح في عرض تقديمي عشوائي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    for behavior in effect.getBehaviors():
        if isinstance(behavior, RotationEffect):
            rotation = behavior
            rotation.setBy(180)

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx)

    reopened = Presentation("rotation-edited.pptx")
    try:
        saved_effect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

        for behavior in saved_effect.getBehaviors():
            if isinstance(behavior, RotationEffect):
                rotation = behavior
                print(f"Rotation preserved: {abs(rotation.getBy() - 180) < 0.001}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

الناتج هو `Rotation preserved: True`. طبق نمط فحص النوع نفسه على سلوكيات أخرى. لإجراء تحقق شامل من الحفظ، قارن الشكل المستهدف، التأثير، أنوع السلوكيات وترتيبها، التوقيت، وأوامر المسار. استخدم تسامحًا رقميًا للقيم العشرية. لعرض تقديمي ذات تخطيط رسومي غير معروف، راجع [قراءة رسوم المتحركة للأشكال](/slides/ar/python-java/shape-animation/#read-shape-animations) لتصفح التسلسلات الرئيسية والتفاعلية.

## **ترتيب السلوكيات، الإعدادات المسبقة، والتشغيل**

الترتيب في [BehaviorCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/behaviorcollection/) هو الترتيب المخزن لعمليات التأثير. لا يُعَدّ قائمة تشغيل ينتظر فيها كل سلوك تلقائيًا السلوك السابق. يحدد التوقيت والتأثير المحيط الجدولة. يمكن أن تتداخل السلوكيات، وقد تتفاعل العمليات على نفس الخاصية عبر [getAdditive](https://reference.aspose.com/slides/ar/python-java/aspose.slides/behavior/#getAdditive) و[getAccumulate](https://reference.aspose.com/slides/ar/python-java/aspose.slides/behavior/#getAccumulate). لا تُستخدم إعادة ترتيب المجموعة وحدها لجدولة “تحريك، ثم تدوير”؛ استخدم توقيتًا صريحًا أو تأثيرات منفصلة كما هو موضح في [رسوم المتحركة للشكل](/slides/ar/python-java/shape-animation/).

يصف [getType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effect/#getType) و[getSubtype](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effect/#getSubtype) للتأثير الإعداد المسبق. ليسا وصفًا كاملاً لشجرة سلوكيات مُعدلة. اختر الإعداد المسبق والنوع الفرعي قبل تخصيص السلوكيات: قد يُعيد تغيير الإعداد المسبق إنشاء المجموعة ويُهْمِل عملياتك المخصَّصة. على سبيل المثال، قد يستبدل تغيير تأثير Spin المخصَّص إلى Fade سلوك التدوير بسلوكيات تعيين وفلتر. افحص المجموعة مرة أخرى بعد تغيير إعداد مسبق أو نوع فرعي. قد يؤدي مسح سلوكيات الإعداد المسبق أيضًا إلى إزالة عمليات الرؤية أو التهيئة التي يحتاجها الإعداد المسبق. تستخدم الأمثلة أشكالًا مرئية وتستبدل السلوكيات؛ لا تُعيد بناء تنفيذ كل إعداد مسبق.

## **توافق الصيغ**

شجرة سلوكيات محفوظة لا تضمن تشغيلًا متطابقًا في كل عارض أو مُحَوِّل تصدير. تحقق من البيانات المحفوظة ومخرجات العرض بشكل منفصل.

| الصيغة أو المخرجات | ما يجب التحقق منه |
| --- | --- |
| PPTX | استخدمها الصيغة الأساسية لهذه الأمثلة. أعد فتحها للتحقق من شجرة السلوكيات القابلة للتحرير، ثم اختبر التشغيل في إصدار PowerPoint المستهدف. |
| PPT | قد يختلف التمثيل الثنائي القديم عن PPTX. اختبر دورة حفظ وإعادة فتح منفصلة وتشغيل؛ لا تستنتج دعم كل تركيبة مخصصة من نجاح مخرجات PPTX. |
| PDF, PNG, JPEG، وغيرها من صور الشرائح الثابتة | تحتوي على تمثيل ثابت للشرائح، ولا تشمل خط زمني لتشغيل السلوكيات أو إطار نهائي مضمون للرسوم المتحركة. |
| [HTML5](/slides/ar/python-java/export-to-html5/) | يمكنه تشغيل الرسوم المتحركة المدعومة عندما تُفعَّل رسوم المتحركة للأشكال في خيارات التصدير. اختبر تركيبات مخصصة في المتصفح. |
| [GIF متحرك](/slides/ar/python-java/convert-powerpoint-to-animated-gif/) | يخزن الإطارات المُرسَمة، لا السلوكيات القابلة للتحرير أو التفاعل بنقر. تحقق من الحركة المُرسَمة فعليًا. |
| [فيديو](/slides/ar/python-java/convert-powerpoint-to-video/) | يرسم إطارات الرسوم المتحركة ويُشفرها كفيديو. الدعم مقيد بـ [الرسوم المتحركة والتأثيرات المدعومة](/slides/ar/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) للمُحَوِّل؛ لا تتحول الأوامر والأحداث التفاعلية إلى خط زمني قابل للتحرير. |

## **الأسئلة المتكررة**

**لماذا يحتوي التأثير على سلوكيات قبل أن أضيف أي منها؟**

إنشاء تأثير مُعرف مسبقًا قد يُنشئ عملياته الأساسية. افحصها قبل اتخاذ قرار إما توسيع الإعداد المسبق أو استبدال سلوكياته.

**هل يجعل نقل سلوك إلى البداية تشغيله أولًا؟**

ليس بالضرورة. ترتيب المجموعة ليس بديلاً عن التوقيت. تحقق من التأخيرات، والمدة، وتفاعلات العمليات على نفس الخاصية.

**لماذا لا يحتوي أمر End على نقاط؟**

إنه يُشير إلى نهاية المسار ولا يحتاج إلى إحداثيات. تحقَّق من مصفوفة نقاط فارغة عند فحص مسار مقروء من ملف.

**هل يكفي جولة ناجحة لتأكيد التشغيل؟**

لا. إعادة الفتح تُؤكِّد حفظ الخصائص التي فحصتها. اختبر مشغل عرض الشرائح أو تصدير الرسوم المتحركة بشكل منفصل لتأكيد سلوكه البصري.