---
title: ایجاد و تعديل رفتارهای سفارشی انیمیشن در پایتون از طریق جاوا
linktitle: انیمیشن سفارشی
type: docs
weight: 151
url: /fa/python-java/custom-animation/
keywords:
- انیمیشن سفارشی
- رفتار انیمیشن
- مسیر حرکت
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "ایجاد، بازرسی و تعديل رفتارهای سفارشی انیمیشن و مسیرهای حرکتی قابل ویرایش در ارائه‌های PowerPoint با Aspose.Slides برای پایتون از طریق جاوا."
---
## **نمای کلی**

رفتارهای سفارشی انیمیشن به شما امکان می‌دهند عملیات‌های منفرد داخل یک اثر انیمیشنی را کنترل کنید، مانند تغییر رنگ، چرخاندن شکل، یا پیروی از مسیر حرکتی قابل ویرایش. این راهنما نشان می‌دهد چگونه رفتارها را ایجاد و ترکیب کنید، زمان‌بندی آن‌ها را پیکربندی کنید، انیمیشن‌های موجود را بررسی و اصلاح کنید و تأیید کنید که ویژگی‌های آن‌ها پس از ذخیره و بازگشایی ارائه حفظ می‌شوند.

برای اثرهای پیش‌تعریف‌شده و ماشه‌های کلیک، به [انیمیشن شکل](/slides/fa/python-java/shape-animation/) مراجعه کنید.

## **درک مدل انیمیشن**

یک انیمیشن به شکل **Timeline → Sequence → Effect → Behaviors** سازماندهی می‌شود:

- متد [getTimeline](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/#getTimeline) زمان‌بندی اسلاید را برمی‌گرداند که شامل توالی اصلی و توالی‌های تعاملی آن است.
- یک [Sequence](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sequence/) شامل اثرهاست که ممکن است به شکل‌های متفاوتی هدف بگیرند.
- یک [Effect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effect/) شکل هدف، پیش‌تنظیم، زیرنوع و زمان‌بندی اثر را شناسایی می‌کند.
- مجموعه‌ای که توسط [Effect.getBehaviors](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effect/#getBehaviors) برگردانده می‌شود، عملیات‌هایی را که اثر را پیاده‌سازی می‌کنند شامل می‌شود: تغییر رنگ، جابجا شدن، چرخش، تنظیم ویژگی و غیره.

## **ایجاد رفتارهای منفرد**

برای ایجاد یک اثر و دسترسی به مجموعه [getBehaviors](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effect/#getBehaviors) از متد [Sequence.addEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sequence/#addEffect) استفاده کنید. یک پیش‌تنظیم می‌تواند این مجموعه را به‌طور خودکار پر کند. هنگام گسترش پیش‌تنظیم، عملیات آن را حفظ کنید یا هنگام جایگزینی عمدی از [clear](https://reference.aspose.com/slides/fa/python-java/aspose.slides/behaviorcollection/#clear) استفاده کنید.

[BehaviorFactory](https://reference.aspose.com/slides/fa/python-java/aspose.slides/behaviorfactory/) هشت نوع رفتار نشان‌داده‌شده در زیر را ایجاد می‌کند. حرکت در بخش [ساخت مسیر حرکتی](#build-a-motion-path) پوشش داده شده است. هر تکه کد شامل وارد کردن‌ها و در صورت نیاز راه‌اندازی JVM است. اشیاء نقطه‌ای و آرایه‌های جاوا از طریق JPype ایجاد می‌شوند وقتی API به آن‌ها نیاز دارد. مثال‌های ویرایشی بعدی نشان می‌دهند از چه فایلی استفاده می‌کنند.

### **چرخش**

از [createRotationEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/behaviorfactory/#createRotationEffect) برای ایجاد چرخش استفاده کنید. [getBy](https://reference.aspose.com/slides/fa/python-java/aspose.slides/rotationeffect/#getBy) زاویه نسبی را برحسب درجه مشخص می‌کند؛ [getFrom](https://reference.aspose.com/slides/fa/python-java/aspose.slides/rotationeffect/#getFrom) و [getTo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/rotationeffect/#getTo) نقطه‌های انتهایی را تعریف می‌کنند.

مثال با یک اثر Spin شروع می‌شود، عملیات پیش‌تنظیم آن را با یک رفتار چرخش جایگزین می‌کند و به آن عملیات مدت زمان دو ثانیه اختصاص می‌دهد. زاویه نسبی 90 درجه یک چرخش یک‌چهارم‌شبکه نسبت به جهت اولیه شکل را بیان می‌کند، بنابراین نیازی به زاویه شروع صریح نیست.

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

`rotation.pptx` شامل یک شکل و یک رفتار چرخش است. مجموعه، زمان‌بندی و مثال‌های ویرایشی چرخش در زیر از این فایل استفاده می‌کنند.

### **مقیاس**

از [createScaleEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/behaviorfactory/#createScaleEffect) با درصدهای X/Y استفاده کنید: [getFrom](https://reference.aspose.com/slides/fa/python-java/aspose.slides/scaleeffect/#getFrom) و [getTo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/scaleeffect/#getTo) اندازه اولیه و نهایی را توصیف می‌کنند، در حالی که [getBy](https://reference.aspose.com/slides/fa/python-java/aspose.slides/scaleeffect/#getBy) تغییر نسبی را توصیف می‌کند. اینجا، 100 به معنای اندازه اصلی است.

مثال هر دو بعد را از 100٪ به 125٪ در طول دو ثانیه افزایش می‌دهد. استفاده از درصدهای افقی و عمودی برابر نسبت شکل را حفظ می‌کند؛ درصدهای متفاوت یک بعد را بیشتر از دیگری می‌کشاند.

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

### **رنگ**

از [createColorEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/behaviorfactory/#createColorEffect) برای تغییر پر از آبی به نارنجی استفاده کنید. [getFrom](https://reference.aspose.com/slides/fa/python-java/aspose.slides/coloreffect/#getFrom) و [getTo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/coloreffect/#getTo) رنگ‌ها هستند؛ [getBy](https://reference.aspose.com/slides/fa/python-java/aspose.slides/coloreffect/#getBy) جابجایی رنگ است. [Behavior.getProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/behavior/#getProperties) ویژگی انیمیشن‌شده را شناسایی می‌کند.

پر جامد شکل به رنگ آبی مقداردهی اولیه می‌شود تا با رنگ شروع انیمیشن مطابقت داشته باشد. انتخاب ویژگی پر-رنگ به رفتار می‌گوید کدام بخش شکل تغییر کند؛ نقاط انتهایی رنگ به تنهایی آن ویژگی را شناسایی نمی‌کنند. اثر ذخیره‌شده انتقال دو ثانیه‌ای به نارنجی را توصیف می‌کند.

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

### **فیلتر**

از [createFilterEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/behaviorfactory/#createFilterEffect) برای انتخاب یک پاک‌کن استفاده کنید. [getType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/filtereffect/#getType)، [getSubtype](https://reference.aspose.com/slides/fa/python-java/aspose.slides/filtereffect/#getSubtype) و [getReveal](https://reference.aspose.com/slides/fa/python-java/aspose.slides/filtereffect/#getReveal) فیلتر، جهت و اینکه شکل را آشکار یا پنهان کنند، مشخص می‌کنند.

این مثال یک پاک‌کن دو ثانیه‌ای که شکل را با زیرنوع جهت راست آشکار می‌کند، پیکربندی می‌کند. تنظیمات فیلتر متعلق به رفتار داخل اثر هستند، بنابراین پس از حذف عملیات اصلی پیش‌تنظیم پیکربندی می‌شوند.

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

### **ویژگی**

از [createPropertyEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/behaviorfactory/#createPropertyEffect) برای انیمیشن شفافیت استفاده کنید. [getFrom](https://reference.aspose.com/slides/fa/python-java/aspose.slides/propertyeffect/#getFrom)، [getTo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/propertyeffect/#getTo) و [getBy](https://reference.aspose.com/slides/fa/python-java/aspose.slides/propertyeffect/#getBy) رشته‌هایی هستند که با [getValueType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/propertyeffect/#getValueType) و [getCalcMode](https://reference.aspose.com/slides/fa/python-java/aspose.slides/propertyeffect/#getCalcMode) تفسیر می‌شوند. به‌جای تنظیم همزمان سه مقدار، انتهای مسیر یا جابجایی نسبی را انتخاب کنید.

اینجا ویژگی انتخاب‌شده شفافیت است و رشته‌های عددی تغییر از 25٪ شفافیت به شفافیت کامل را نشان می‌دهند. درون‌یابی خطی توصیف‌کننده تغییر تدریجی بین این مقادیر است. هنگام سازگار کردن این مثال با ویژگی دیگر، نوع مقدار و مقادیر انتهایی مناسب آن ویژگی را انتخاب کنید.

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

### **تنظیم**

از [createSetEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/behaviorfactory/#createSetEffect) برای اختصاص قابلیت دیداری از طریق [getTo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/seteffect/#getTo) استفاده کنید. رفتار تنظیم بین نقاط انتهایی درونی‌سازی نمی‌کند.

مثال ویژگی دیداری را انتخاب می‌کند و رشته `visible` را زمانی که رفتار اجرا می‌شود اختصاص می‌دهد. مستطیل در این ارائهٔ کوچک‌وار از قبل قابل مشاهده است، بنابراین این تخصیص ممکن است به‌تنهایی تغییری بصری آشکار ندهد. چنین عملیاتی به‌عنوان بخشی از یک اثر بزرگ‌تر که زمان نمایش یا مخفی شدن شکل را نیز کنترل می‌کند، مفید است.

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

### **دستور**

از [createCommandEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/behaviorfactory/#createCommandEffect) و پیکربندی [getType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/commandeffect/#getType)، [getCommandString](https://reference.aspose.com/slides/fa/python-java/aspose.slides/commandeffect/#getCommandString) و [getShapeTarget](https://reference.aspose.com/slides/fa/python-java/aspose.slides/commandeffect/#getShapeTarget) استفاده کنید. یک فایل صوتی WAV به نام `sample.wav` را در پوشهٔ کاری قرار دهید. این مثال آن را با [addAudioFrameEmbedded](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) جاسازی می‌کند و یک دستور پخش به قاب صوتی الصاق می‌کند.

قاب صوتی هم هدف اثر و هم هدف فرمان است. این اتصال درخواست پخش را به ضبط جاسازی‌شده می‌پیوندد؛ یک رشتهٔ فرمان به‌تنهایی شیء رسانه‌ای که باید کنترل شود را شناسایی نمی‌کند. اثر طوری پیکربندی می‌شود که با کلیک در طول ارائه شروع شود.

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

ذخیره‌سازی فرمان را در `command.pptx` ذخیره می‌کند؛ آن را پخش نمی‌کند. اجرای دوباره نیاز به پخش‌کنندهٔ ارائه‌ای دارد که از فرمان و هدف رسانه‌ای آن پشتیبانی کند.

## **مدیریت مجموعهٔ رفتارها**

[BehaviorCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/behaviorcollection/) از متدهای [add](https://reference.aspose.com/slides/fa/python-java/aspose.slides/behaviorcollection/#add)، [insert](https://reference.aspose.com/slides/fa/python-java/aspose.slides/behaviorcollection/#insert)، [remove](https://reference.aspose.com/slides/fa/python-java/aspose.slides/behaviorcollection/#remove) و [removeAt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/behaviorcollection/#removeAt) پشتیبانی می‌کند. این مثال `rotation.pptx` را باز می‌کند، مقیاس‌بندی اضافه می‌کند، پیش از چرخش جابه‌جا می‌کند و چرخش را حذف می‌کند. حذف و قرار دادن مجدد همان شیء موقعیت ذخیره‌شده آن را بدون ایجاد نسخهٔ جدید تغییر می‌دهد.

دنبالهٔ ویرایش‌ها مجموعه را از چرخش‑مقیاس به مقیاس‑چرخش و سپس به فقط مقیاس تغییر می‌دهد. شاخص‌ها به مجموعهٔ فعلی اشاره دارند، بنابراین حذف از شاخص جدید چرخش پس از ترتیب‌گذاری مجدد استفاده می‌کند. شمارش نهایی تأیید می‌کند کدام رفتار ذخیره خواهد شد.

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

خروجی `ScaleEffect` است: فقط مقیاس باقی می‌ماند. ترتیب مجموعه به تنهایی رفتارها را یکی پس از دیگری زمان‌بندی نمی‌کند. فقط زمانی مجموعه را خالی کنید که تمام عملیات آن را جایگزین می‌کنید.

## **پیکربندی زمان‌بندی رفتار**

[Behavior.getTiming](https://reference.aspose.com/slides/fa/python-java/aspose.slides/behavior/#getTiming) زمان‌بندی [Timing](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/) را به‌صورت مستقل از [Effect.getTiming](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effect/#getTiming) افشا می‌کند. زمان‌بندی اثر، اثر محاط‌کننده را زمان‌بندی می‌کند؛ زمان‌بندی رفتار، عملیاتی داخل آن را توصیف می‌کند.

### **تنظیم مدت زمان، تأخیر، تکرار و شتاب**

`rotation.pptx` را باز کنید و مدت زمان ([getDuration](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#getDuration)) و تأخیر ماشه ([getTriggerDelayTime](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#getTriggerDelayTime)) را بر حسب ثانیه تنظیم کنید، سپس تعداد تکرار را از طریق [setRepeatCount](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#setRepeatCount) پیکربندی کنید. [getAccelerate](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#getAccelerate) و [getDecelerate](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#getDecelerate) کسرهایی از مدت زمان هستند؛ مجموع آن‌ها حداکثر 1 باشد.

فایل ورودی همان فایلی است که در مثال چرخش ساخته شد و در آن اولین رفتار یک چرخش شناخته شده است. این مثال تنها زمان‌بندی آن رفتار را تغییر می‌دهد؛ زاویهٔ 90 درجه همچنان باقی می‌ماند. جدا نگه داشتن زاویه و زمان‌بندی، تنظیم سرعت را بدون بازسازی انیمیشن آسان‌تر می‌کند.

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

رفتار دو ثانیهٔ مدت زمان، نیم‌ثانیهٔ تأخیر و تعداد تکرار 3 دارد. 20٪ اول و 20٪ آخر مدت زمان برای شتاب و کاهشش استفاده می‌شود.

سیاست‌های تکرار دیگر شامل [getRepeatDuration](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#getRepeatDuration)، [getRepeatUntilEndSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#getRepeatUntilEndSlide) و [getRepeatUntilNextClick](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#getRepeatUntilNextClick) هستند؛ یک سیاست را انتخاب کنید نه اینکه همه را همزمان فعال کنید. [getAutoReverse](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#getAutoReverse) پس از عبور جلو، انیمیشن را به‌عکس اجرا می‌کند. شتاب و کاهش برای تغییرات پیوسته اعمال می‌شود، نه برای اختصاص‌های گسسته یا فرمان‌ها.

## **ساخت مسیر حرکتی**

از [createMotionEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/behaviorfactory/#createMotionEffect) برای ایجاد حرکت استفاده کنید. [getFrom](https://reference.aspose.com/slides/fa/python-java/aspose.slides/motioneffect/#getFrom)، [getTo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/motioneffect/#getTo) و [getBy](https://reference.aspose.com/slides/fa/python-java/aspose.slides/motioneffect/#getBy) مختصات یا جابجایی‌های مبتنی بر درصد را توصیف می‌کنند. برای یک مسیر قابل ویرایش، یک [MotionPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/motionpath/) ایجاد کنید و آن را با [MotionEffect.setPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/motioneffect/#setPath) اختصاص دهید. [MotionPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/motionpath/) دستورات مسیر را ذخیره می‌کند.

[MotionCommandPathType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/motioncommandpathtype/) عملیات را انتخاب می‌کند:

| فرمان | نقاط | معنی |
| --- | --- | --- |
| MoveTo | One | تعیین موقعیت شروع. |
| LineTo | One | حرکت در یک قطعهٔ مستقیم به نقطهٔ انتهایی آن. |
| CurveTo | Three | پیروی از یک منحنی مکعبی تعریف‌شده توسط دو نقطهٔ کنترل و یک نقطهٔ انتهایی. |
| CloseLoop | None | بازگشت به موقعیت شروع. |
| End | None | پایان مسیر. |

[MotionPathPointsType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/motionpathpointstype/) ویژگی‌های ویرایش نقطه را توصیف می‌کند، مانند نقطهٔ گوشه‌ای یا صاف. این نوع نقطه جایگزین نوع فرمان نمی‌شود. برای مثال منحنی زیر از نوع نقطهٔ منحنی استفاده کنید و برای قطعات مستقیم از نوع نقطهٔ گوشه‌ای.

مختصات مسیر به ابعاد اسلاید نرمال‌سازی می‌شوند: جابه‌جایی X برابر 0.25 نمایانگر یک‌چهارم عرض اسلاید است، نه 0.25 نقطه. Y مثبت به سمت پایین می‌رود. دستورات مطلق موقعیت‌ها را در سیستم مختصات مسیر مشخص می‌کنند؛ دستورات نسبی جابجایی‌ها را از موقعیت فعلی تعیین می‌کنند. این موضوع جدا از [getOrigin](https://reference.aspose.com/slides/fa/python-java/aspose.slides/motioneffect/#getOrigin) است که چارچوب مرجع مسیر را انتخاب می‌کند و [getPathEditMode](https://reference.aspose.com/slides/fa/python-java/aspose.slides/motioneffect/#getPathEditMode) که نحوهٔ حرکت مسیر هنگام جابه‌جایی شکل را کنترل می‌کند.

### **ایجاد مسیر مستقیم**

یک رفتار حرکتی با یک نقطهٔ شروع، یک قطعهٔ مستقیم و یک فرمان پایان ایجاد کنید. [MotionPath.add](https://reference.aspose.com/slides/fa/python-java/aspose.slides/motionpath/#add) نوع فرمان، نقاط آن، نوع نقطه و پرچم مختصات نسبی را می‌گیرد.

فرمان شروع (0, 0) را تعیین می‌کند و خط به (0.25, 0) ختم می‌شود، که جابه‌جایی افقی یک‌چهارم عرض اسلاید را می‌دهد. فرمان پایان هیچ نقطه‌ای ندارد. پس از اختصاص مسیر، افزودن رفتار حرکتی به اثر، این مسیر را به مستطیل متصل می‌کند.

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

`motion.pptx` شامل یک رفتار حرکتی با سه فرمان مسیر است. مثال‌های ویرایش فایل زیر از این ساختار شناخته‌شده استفاده می‌کنند.

### **مقایسه مختصات مطلق و نسبی**

این دو شیء مسیر همان مسیر را توصیف می‌کنند. فرمان مطلق در (0.3, 0.1) پایان می‌یابد؛ فرمان نسبی (0.1, 0.1) را به موقعیت فعلی (0.2, 0) اضافه می‌کند.

هر دو مسیر از همان موقعیت آغاز می‌شوند. برای خط نسبی، افست‌های X و Y را به موقعیت فعلی اضافه کنید تا نقطهٔ انتهایی به‌دست آید؛ برای خط مطلق، مستقیماً نقطهٔ انتهایی را بخوانید. تغییر پرچم بدون تبدیل مختصات مسیری متفاوت تولید می‌کند.

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

هر یک از مسیرها را به یک رفتار حرکتی اختصاص دهید تا در ارائه استفاده شود. آرگومان بولی نهایی مختصات نسبی برای آن فرمان را انتخاب می‌کند.

### **جایگزینی خط با منحنی**

`motion.pptx` را باز کنید و فرمان خط آن را با یک منحنی مکعبی جایگزین کنید. ابتدا دو نقطهٔ کنترل را وارد کنید، سپس نقطهٔ انتهایی را بدهید.

موقعیت شروع توسط فرمان پیشین فراهم می‌شود. دو نقطهٔ اول شکل منحنی را تعیین می‌کنند، در حالی که نقطهٔ سوم مقصد نهایی است؛ آن‌ها سه مقصد متوالی نیستند. به‌روز‌رسانی همزمان نوع فرمان، نوع ویرایش نقطه و آرایهٔ نقطه‌ها، قطعه را با هندسهٔ جدید سازگار نگه می‌دارد.

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

مسیر در `curve.pptx` هنوز سه فرمان دارد؛ فرمان میانی اکنون یک منحنی را تعریف می‌کند.

## **بررسی و ویرایش مسیر ذخیره‌شده**

هر [MotionCmdPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/motioncmdpath/) متدهای [getPoints](https://reference.aspose.com/slides/fa/python-java/aspose.slides/motioncmdpath/#getPoints)، [getCommandType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/motioncmdpath/#getCommandType)، [getPointsType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/motioncmdpath/#getPointsType) و [isRelative](https://reference.aspose.com/slides/fa/python-java/aspose.slides/motioncmdpath/#isRelative) را افشا می‌کند. مثال‌های زیر از مسیر سه‌فرمانی شناخته‌شده در `motion.pptx` استفاده می‌کنند. برای ورودی دلخواه، اثر مورد نظر را پیدا کنید و قبل از ویرایش توسط ایندکس، نوع فرمان و تعداد نقاط را بررسی کنید.

### **خواندن فرمان‌ها و مختصات**

مسیر را بدون تغییر بخوانید. فرمان‌های End و CloseLoop نیازی به نقاط ندارند، بنابراین اجازهٔ آرایهٔ نقطهٔ تهی را بدهید.

خروجی هر نوع فرمان عددی را همراه پرچم مختصات نسبی قبل از فهرست کردن نقاط نشان می‌دهد. این به شما امکان می‌دهد قبل از تغییر مسیر، نقطهٔ انتهایی را از جابجایی تشخیص دهید. یک منحنی سه نقطه فهرست می‌کند، در حالی که خط مستقیم در این فایل تنها یک نقطه دارد.

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

این فهرست شامل یک نقطهٔ شروع، یک خط مطلق که در (0.25, 0) پایان می‌یابد و یک فرمان End است.

### **تغییر نقطهٔ انتهایی**

`motion.pptx` را باز کنید و آرایهٔ نقطهٔ خط را جایگزین کنید تا نقطهٔ انتهای آن جابجا شود.

در فایل ورودی، ایندکس 0 فرمان شروع و ایندکس 1 خط است. جایگزینی نقطهٔ تک‌تایی خط مقصد آن را تغییر می‌دهد بدون اینکه نوع فرمان، زمان‌بندی یا موقعیت در مجموعه تغییر کند. چون فرمان از مختصات مطلق استفاده می‌کند، جفت جدید یک موقعیت را نشان می‌دهد نه یک جابجایی افزوده‌شده.

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

خط در `motion-endpoint.pptx` در (0.4, 0.1) پایان می‌یابد؛ فایل اصلی تغییر نمی‌کند.

### **جایگزینی یک بخش**

از [insert](https://reference.aspose.com/slides/fa/python-java/aspose.slides/motionpath/#insert) و [removeAt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/motionpath/#removeAt) برای جایگزینی خط در `motion.pptx` استفاده کنید. درج خط جدید، خط قبلی را به ایندکس 2 منتقل می‌کند.

این روش جایگزینی یک شیء فرمان را نشان می‌دهد نه ویرایش مختصات موجود. پس از درج، مجموعه به‌طور موقت شامل فرمان شروع، خط جدید، خط قدیم و فرمان End می‌شود. حذف ایندکس 2 خط قدیم را حذف می‌کند و مسیر جدید در جای خود می‌ماند.

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

مسیر ذخیره‌شده هنوز سه فرمان دارد؛ خط جدید در (0.2, 0.1) پایان می‌یابد و فرمان End آخرین است.

## **اصلاح و تأیید یک رفتار موجود**

زمانی که ایندکس رفتار ناشناخته باشد، با نوع آن انتخاب کنید. این مثال `rotation.pptx` را باز می‌کند، [RotationEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/rotationeffect/) آن را پیدا می‌کند، زاویه را تغییر می‌دهد و مقدار ذخیره‌شده را پس از بازگشایی بررسی می‌کند.

بررسی نوع به حلقه اجازه می‌دهد رفتارهایی که چرخش نیستند را رد کند. بار دوم فایل ذخیره‌شده را در یک شیء ارائهٔ جداگانه می‌خواند، بنابراین مقایسه داده‌های پایدار را به‌جای مقدار باقی‌مانده در حافظه انجام می‌دهد. این مثال همچنان فرض می‌کند اثر شناخته‌شده اولین در توالی اصلی است؛ انتخاب رفتار بر اساس نوع لزوماً اثر صحیح را در ارائهٔ دلخواه پیدا نمی‌کند.

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

خروجی `Rotation preserved: True` است. الگوی بررسی نوع را برای سایر رفتارها نیز اعمال کنید. برای یک بررسی کامل حفظ، شکل هدف، اثر، انواع و ترتیب رفتارها، زمان‌بندی و فرمان‌های مسیر را مقایسه کنید. برای مقادیر عددی از تحمل عددی برای مقادیر با نقطه شناور استفاده کنید. برای ارائه‌ای با طرح انیمیشن ناشناخته، به [خواندن انیمیشن‌های شکل](/slides/fa/python-java/shape-animation/#read-shape-animations) برای پیمایش توالی‌های اصلی و تعاملی مراجعه کنید.

## **ترتیب رفتارها، پیش‌تنظیم‌ها و پخش**

ترتیب در [BehaviorCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/behaviorcollection/) ترتیب ذخیره‌شده عملیات‌های یک اثر است. این یک لیست پخش نیست که هر رفتار به‌طور خودکار منتظر رفتار قبلی باشد. زمان‌بندی و اثر محاط‌کننده برنامه‌ریزی را تعیین می‌کنند. رفتارها می‌توانند هم‌پوشان شوند و عملیات روی همان ویژگی ممکن است از طریق [getAdditive](https://reference.aspose.com/slides/fa/python-java/aspose.slides/behavior/#getAdditive) و [getAccumulate](https://reference.aspose.com/slides/fa/python-java/aspose.slides/behavior/#getAccumulate) با یکدیگر تعامل داشته باشند. فقط با بازآرایی مجموعه به‌تنهایی «جابجا، سپس چرخش» زمان‌بندی نمی‌شود؛ از زمان‌بندی صریح یا اثرهای جداگانه همان‌طور که در [انیمیشن شکل](/slides/fa/python-java/shape-animation/) توضیح داده شده استفاده کنید.

[Effect.getType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effect/#getType) و [Effect.getSubtype](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effect/#getSubtype) پیش‌تنظیم آن را توصیف می‌کنند. این توصیف کامل درخت رفتارهای ویرایش‌شده نیست. پیش‌تنظیم و زیرنوع را قبل از سفارشی‌سازی رفتارها انتخاب کنید: تغییر پیش‌تنظیم می‌تواند مجموعه را بازسازی کرده و عملیات سفارشی شما را حذف کند. برای مثال، تغییر یک اثر Spin سفارشی به Fade می‌تواند رفتار چرخش را با رفتارهای set و filter جایگزین کند. پس از تغییر پیش‌تنظیم یا زیرنوع، دوباره مجموعه را بررسی کنید. پاک کردن رفتارهای پیش‌تنظیم ممکن است عملیات دیداری یا مقداردهی اولیه‌ای که پیش‌تنظیم نیاز دارد را نیز حذف کند. مثال‌ها عمداً از شکل‌های قابل مشاهده استفاده می‌کنند و رفتارها را جایگزین می‌کنند؛ آن‌ها پیاده‌سازی هر پیش‌تنظیم را بازتولید نمی‌کنند.

## **سازگاری قالب‌ها**

یک درخت رفتار محفوظ‌شده تضمین‌کنندهٔ پخش یکسان در همهٔ نمایشگرها یا رندرهای خروجی نیست. داده‌های ذخیره‌شده و خروجی رندر شده را جداگانه بررسی کنید.

| قالب یا خروجی | آنچه باید تأیید شود |
| --- | --- |
| PPTX | به‌عنوان قالب اصلی برای این مثال‌ها استفاده کنید. آن را بازگشایی کنید تا درخت رفتار ویرایشی را تأیید کنید، سپس پخش را در نسخهٔ PowerPoint موردنظر بررسی کنید. |
| PPT | نمایش باینری قدیمی ممکن است با PPTX متفاوت باشد. یک چرخهٔ ذخیره‑بازگشایی جداگانه و پخش را تست کنید؛ از موفقیت خروجی PPTX برای همهٔ ترکیب‌های سفارشی نتیجه‌گیری نکنید. |
| PDF, PNG, JPEG و سایر تصاویر اسلاید ثابت | حاوی نمای ثابت اسلاید هستند، نه یک زمان‌بندی رفتار قابل پخش یا قاب نهایی انیمیشن تضمین‌شده. |
| [HTML5](/slides/fa/python-java/export-to-html5/) | می‌تواند انیمیشن‌های پشتیبانی‌شده را هنگام فعال‌سازی انیمیشن شکل در گزینه‌های خروجی پخش کند. ترکیب‌های سفارشی را در مرورگر تست کنید. |
| [Animated GIF](/slides/fa/python-java/convert-powerpoint-to-animated-gif/) | فریم‌های رندرشده را ذخیره می‌کند، نه رفتارهای ویرایشی یا تعاملات ماشه‑محور. حرکت رندر شده واقعی را بررسی کنید. |
| [Video](/slides/fa/python-java/convert-powerpoint-to-video/) | فریم‌های انیمیشن را رندر و به‌صورت ویدیو رمزگذاری می‌کند. پشتیبانی محدود به [انیمیشن‌ها و اثرهای پشتیبانی‌شده](/slides/fa/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) رندر کننده است؛ فرمان‌ها و رویدادهای تعاملی تبدیل به یک زمان‌بندی ویرایشی نمی‌شوند. |

## **سوالات متداول**

**چرا اثر من قبل از افزودن هرچیزی شامل رفتارهاست؟**

ایجاد یک اثر پیش‌تنظیم‌شده می‌تواند عملیات‌های زیرین آن را ایجاد کند. قبل از تصمیم به گسترش پیش‌تنظیم یا جایگزینی رفتارهای آن، آن‌ها را بررسی کنید.

**آیا جابه‌جایی رفتار به ابتدای مجموعه باعث می‌شود ابتدا اجرا شود؟**

لزماً نه. ترتیب مجموعه جایگزین زمان‌بندی نمی‌شود. تأخیرها، مدت زمان‌ها و تعاملات بین عملیات روی همان ویژگی را بررسی کنید.

**چرا یک فرمان End هیچ نقطه‌ای ندارد؟**

این فرمان انتهای مسیر را نشان می‌دهد و نیازی به مختصات ندارد. هنگام بررسی مسیر خوانده‌شده از یک فایل، برای آرایهٔ نقطهٔ تهی بررسی کنید.

**آیا یک دور کامل موفق کافی برای تأیید پخش است؟**

نه. بازگشایی حفظ ویژگی‌هایی را که بررسی کرده‌اید تأیید می‌کند. پخش‌کنندهٔ اسلایدشو یا خروجی انیمیشن را جداگانه تست کنید تا رفتار بصری آن را تأیید کنید.