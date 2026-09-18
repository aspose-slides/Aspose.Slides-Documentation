---
title: إنشاء وتعديل سلوكيات الرسوم المتحركة المخصصة في JavaScript
linktitle: الرسوم المتحركة المخصصة
type: docs
weight: 151
url: /ar/nodejs-java/custom-animation/
keywords:
- الرسوم المتحركة المخصصة
- سلوك الرسوم المتحركة
- مسار الحركة
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إنشاء، فحص، وتعديل سلوكيات الرسوم المتحركة المخصصة ومسارات الحركة القابلة للتحرير في عروض PowerPoint باستخدام Aspose.Slides for Node.js عبر Java."
---
## **نظرة عامة**

تتيح لك سلوكيات الرسوم المتحركة المخصصة التحكم في العمليات الفردية داخل تأثير الرسوم المتحركة، مثل تغيير اللون، تدوير الشكل، أو اتباع مسار حركة قابل للتحرير. يوضح هذا الدليل كيفية إنشاء السلوكيات ودمجها، تكوين توقيتها، فحص وتعديل الرسوم المتحركة الحالية، والتحقق من أن خصائصها تُحفظ عند حفظ العرض وإعادة فتحه.

للتأثيرات المحددة مسبقًا ومحفزات النقر، راجع [رسوم متحركة الشكل](/slides/ar/nodejs-java/shape-animation/).

## **فهم نموذج الرسوم المتحركة**

يُنظم تأثير الرسوم المتحركة على شكل **الخط الزمني → التسلسل → التأثير → السلوكيات**:

- تُعيد طريقة [getTimeline](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseslide/#getTimeline) الخط الزمني للشرائح، الذي يحتوي على التسلسل الرئيسي والتسلسلات التفاعلية.
- يحتوي [Sequence](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sequence/) على التأثيرات، وقد يستهدف أشكالًا مختلفة.
- يحدد [Effect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effect/) الشكل المستهدف، والإعداد المسبق، والنوع الفرعي، وتوقيت التأثير.
- تحتوي المجموعة التي تُعيدها [Effect.getBehaviors](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effect/#getBehaviors) على العمليات التي تُنفّذ التأثير: تغيير اللون، التحرك، التدوير، تعيين خاصية، وما إلى ذلك.

## **إنشاء سلوكيات فردية**

استدعِ [Sequence.addEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sequence/#addEffect) لإنشاء تأثير والوصول إلى مجموعة [getBehaviors](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effect/#getBehaviors). يمكن أن يملأ إعداد مسبق هذه المجموعة تلقائيًا. احتفظ بعملياتها عند توسيع الإعداد المسبق، أو استخدم [clear](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/behaviorcollection/#clear) عند استبدالها عن قصد.

[BehaviorFactory](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/behaviorfactory/) ينشئ الأنواع الثمانية للسلوكيات الموضحة أدناه. يتم تغطية الحركة في [إنشاء مسار حركة](#build-a-motion-path). يحتوي كل مقطع على استيراداته ويمكن تشغيله كسكريبت Node.js مع تثبيت حزم `aspose.slides.via.java` و `java`. شغّل أمثلة إنشاء الملفات قبل أمثلة قراءة الإخراج. توضح أمثلة التحرير اللاحقة أي ملف إخراج تُستخدم.

### **التدوير**

استخدم [createRotationEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/behaviorfactory/#createRotationEffect) لإنشاء تدوير. تُحدِّد [getBy](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/rotationeffect/#getBy) زاوية نسبية بالدرجات؛ وتُحدِّد [getFrom](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/rotationeffect/#getFrom) و [getTo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/rotationeffect/#getTo) نقطتي النهاية.

يبدأ المثال بتأثير Spin، يستبدل عمليات الإعداد المسبق بسلوك تدوير واحد، ويعطي تلك العملية مدة ثانيتين. تعبر الزاوية النسبية 90 درجة عن ربع دورة من توجيه الشكل الأصلي، لذا لا يلزم تحديد زاوية بدء صريحة.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Spin, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const rotation = factory.createRotationEffect();
    rotation.setBy(90);
    rotation.getTiming().setDuration(2);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يحتوي `rotation.pptx` على شكل واحد وسلوك تدوير واحد. تُستخدم المجموعة، التوقيت، وأمثلة تعديل التدوير أدناه هذا الملف.

### **التحجيم**

استخدم [createScaleEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/behaviorfactory/#createScaleEffect) بنسب X/Y: تُصفّف [getFrom](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/scaleeffect/#getFrom) و [getTo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/scaleeffect/#getTo) الحجم الابتدائي والنهايى، بينما يصف [getBy](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/scaleeffect/#getBy) تغييرًا نسبيًا. هنا، 100 تعني الحجم الأصلي.

ينمِّى المثال كلا البعدين من 100٪ إلى 125٪ خلال ثانيتين. استخدام نسب أفقية ورأسية متساوية يحافظ على نسب الشكل؛ نسب مختلفة ستمدد أحد البعدين أكثر من الآخر.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.GrowShrink, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setFrom(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(100), java.newFloat(100)));
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **اللون**

استخدم [createColorEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/behaviorfactory/#createColorEffect) لتغيير التعبئة من الأزرق إلى البرتقالي. تُعدّ [getFrom](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/coloreffect/#getFrom) و [getTo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/coloreffect/#getTo) ألوانًا؛ و [getBy](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/coloreffect/#getBy) إزاحة لون. تُحدِّد [Behavior.getProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/behavior/#getProperties) السمة المتحركة.

تُهيَّأ تعبئة الشكل الصلبة إلى اللون الأزرق، لتطابق لون بدء الرسوم المتحركة. يحدد اختيار سمة تعبئة اللون أي جزء من الشكل يتغيّر؛ نقاط اللون النهائية وحدها لا تُحدِّد السمة. يصف التأثير المحفوظ انتقالًا لمدة ثانيتين إلى البرتقالي.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.ChangeFillColor, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const color = factory.createColorEffect();
    color.getProperties().add(aspose.slides.BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **الفلتر**

استخدم [createFilterEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/behaviorfactory/#createFilterEffect) لاختيار مسح. تُحدِّد [getType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/filtereffect/#getType)، و [getSubtype](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/filtereffect/#getSubtype)، و [getReveal](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/filtereffect/#getReveal) الفلتر، الاتجاه، وما إذا كان يُظهر أو يُخفي الشكل.

يضبط هذا المثال مسحًا لمدة ثانيتين يُظهر الشكل باستخدام النوع الفرعي للاتجاه إلى اليمين. إعدادات الفلتر تنتمي إلى السلوك داخل التأثير، لذا تُضبط بعد إزالة عمليات الإعداد المسبق الأصلية.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Wipe, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const filter = factory.createFilterEffect();
    filter.setType(aspose.slides.FilterEffectType.Wipe);
    filter.setSubtype(aspose.slides.FilterEffectSubtype.Right);
    filter.setReveal(aspose.slides.FilterEffectRevealType.In);
    filter.getTiming().setDuration(2);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **الخاصية**

استخدم [createPropertyEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/behaviorfactory/#createPropertyEffect) لتحريك الشفافية. تُعدّ [getFrom](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/propertyeffect/#getFrom)، و [getTo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/propertyeffect/#getTo)، و [getBy](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/propertyeffect/#getBy) سلاسل تُفسَّر باستخدام [getValueType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/propertyeffect/#getValueType) و [getCalcMode](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/propertyeffect/#getCalcMode). اختر نقاط النهاية أو إزاحة نسبية بدلًا من ضبط الثلاثة جميعًا بلا تمييز.

هنا، السمة المختارة هي الشفافية، والسلاسل الرقمية تمثّل تغيرًا من شفافية 25٪ إلى شفافية كاملة. يصف الاستيفاء الخطي تغيرًا تدريجيًا بين تلك القيم. عند تكييف هذا المثال لسمة أخرى، اختر نوع قيمة وقيم نقطة نهائية مناسبة لتلك السمة.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const property = factory.createPropertyEffect();
    property.getProperties().add(aspose.slides.BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(aspose.slides.PropertyValueType.Number);
    property.setCalcMode(aspose.slides.PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **التعيين**

استخدم [createSetEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/behaviorfactory/#createSetEffect) لتعيين الرؤية عبر [getTo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/seteffect/#getTo). لا يُجري سلوك التعيين استيفاءً بين نقطتي النهاية.

يختار المثال سمة الرؤية ويُعيّن السلسلة `visible` عندما يُنفّذ السلوك. المستطيل مرئي بالفعل في هذا العرض القليل، لذا قد لا ينتج عن التعيين تغييرًا بصريًا واضحًا بمفرده. تكون مثل هذه العملية مفيدة كجزء من تأثير أكبر يتحكم أيضًا في توقيت إخفاء أو إظهار الشكل.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const set = factory.createSetEffect();
    set.getProperties().add(aspose.slides.BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **الأمر**

استخدم [createCommandEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/behaviorfactory/#createCommandEffect) واضبط [getType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/commandeffect/#getType)، و [getCommandString](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/commandeffect/#getCommandString)، و [getShapeTarget](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/commandeffect/#getShapeTarget). ضع ملف تسجيل WAV باسم `sample.wav` في دليل العمل. يدمج هذا المثال الملف باستخدام [addAudioFrameEmbedded](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) ويُرفق أمر تشغيل لإطار الصوت.

يكون إطار الصوت هو كلّ من هدف التأثير وهدف الأمر. يربط ذلك طلب التشغيل بالتسجيل المدمج؛ سلسلة الأوامر وحدها لا تُحدِّد أي كائن وسائط يتحكم فيه. يُضبط التأثير للبدء عند النقر أثناء عرض الشرائح.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        const effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, aspose.slides.EffectType.MediaPlay, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        const factory = new aspose.slides.BehaviorFactory();
        const command = factory.createCommandEffect();
        command.setType(java.newByte(aspose.slides.CommandEffectType.Call));
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        audioStream.close();
    }
} finally {
    presentation.dispose();
}
```

يحفظ الأمر في `command.pptx`؛ لا يقوم بتشغيل التسجيل. يتطلّب التشغيل مشغل عروض شرائح يدعم الأمر والوسيط المستهدف.

## **إدارة مجموعة السلوكيات**

يدعم [BehaviorCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/behaviorcollection/) عمليات [add](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/behaviorcollection/#add)، و [insert](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/behaviorcollection/#insert)، و [remove](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/behaviorcollection/#remove)، و [removeAt](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/behaviorcollection/#removeAt). يفتح هذا المثال `rotation.pptx`، يضيف تحجيمًا، ينقله قبل التدوير، ثم يزيل التدوير. يؤدي الإزالة وإعادة الإدراج لنفس الكائن إلى تغيير موقعه المخزن دون إنشاء نسخة.

تغيّر تسلسل التعديلات المجموعة من تدوير‑تحجيم إلى تحجيم‑تدوير، ثم إلى تحجيم فقط. تشير الفهارس إلى المجموعة الحالية، لذا يستخدم الإزالة فهرس التدوير الجديد بعد إعادة الترتيب. تؤكد العدّة النهائية أي سلوك سيُحفظ.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const behaviors = effect.getBehaviors();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (let i = 0; i < behaviors.getCount(); i++) {
        const behavior = behaviors.get_Item(i);
        console.log(behavior.getClass().getSimpleName());
    }

    presentation.save("collection-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

الناتج هو `ScaleEffect`: يبقى التحجيم فقط. لا يحدد ترتيب المجموعة، بحد ذاته، جدولة السلوكيات واحدةً تلو الأخرى. امسح المجموعة فقط عند استبدال جميع عملياتها.

## **تكوين توقيت السلوك**

تُظهر [Behavior.getTiming](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/behavior/#getTiming) كائن [Timing](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/)، مستقلاً عن [Effect.getTiming](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effect/#getTiming). يحدد توقيت التأثير جدولة التأثير المحيط؛ يصف توقيت السلوك عملية داخل ذلك التأثير.

### **تعيين المدة، التأخير، التكرار، والتسارع**

افتح `rotation.pptx` واضبط المدة باستخدام [getDuration](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#getDuration) والتأخير عند المشغّل باستخدام [getTriggerDelayTime](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#getTriggerDelayTime) بالثواني، ثم اضبط عدد التكرارات عبر [setRepeatCount](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#getAccelerate) و [getDecelerate](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#getDecelerate) هما كسور من المدة؛ حافظ على مجموعهما بحد أقصى 1.

ملف الإدخال هو الملف المُنشأ في مثال التدوير، حيث يُعرف أن السلوك الأول هو تدوير. يغيّر هذا المثال توقيت ذلك السلوك فقط؛ تبقى زاوية الـ90 درجة كما هي. يجعل الفصل بين الزاوية والتوقيت تعديل السرعة أسهل دون الحاجة لإعادة بناء الرسوم المتحركة.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const rotation = effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2);
    rotation.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    rotation.getTiming().setRepeatCount(3);
    rotation.getTiming().setAccelerate(java.newFloat(0.2));
    rotation.getTiming().setDecelerate(java.newFloat(0.2));

    presentation.save("timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يستخدم السلوك مدة ثانيتين، وتأخير نصف ثانية، وعدد تكرار 3. تُستخدم أول وآخر 20٪ من مدتها للتسارع والتباطؤ.

تشمل سياسات التكرار الأخرى [getRepeatDuration](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#getRepeatDuration)، و [getRepeatUntilEndSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide)، و [getRepeatUntilNextClick](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick)؛ اختر سياسةً واحدةً بدلًا من تفعيلها جميعًا معًا. تُعيد [getAutoReverse](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#getAutoReverse) تشغيل الرسوم المتحركة عكسيًا بعد المرور للأمام. يطبق التسارع والتباطؤ على التغييرات المستمرة، وليس على التعيينات المتقطعة أو الأوامر.

## **إنشاء مسار حركة**

استخدم [createMotionEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/behaviorfactory/#createMotionEffect) لإنشاء حركة. تصف [getFrom](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/motioneffect/#getFrom)، و [getTo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/motioneffect/#getTo)، و [getBy](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/motioneffect/#getBy) إحداثيات أو إزاحات بنسبة مئوية. لإنشاء مسار قابل للتحرير، أنشئ كائن [MotionPath](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/motionpath/) وعيّنه باستخدام [MotionEffect.setPath](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/motioneffect/#setPath). يخزن [MotionPath](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/motionpath/) أوامر المسار.

يختار [MotionCommandPathType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/motioncommandpathtype/) العملية:

| الأمر | النقاط | المعنى |
| --- | --- | --- |
| MoveTo | واحدة | تعيين موضع البداية. |
| LineTo | واحدة | التحرك على مقطع مستقيم إلى نقطته النهائية. |
| CurveTo | ثلاث | اتباع منحنى ثلاثي الحدَّد بنقطتي تحكم ونقطة نهائية. |
| CloseLoop | لا شيء | الرجوع إلى موضع البداية. |
| End | لا شيء | إنهاء المسار. |

يصف [MotionPathPointsType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/motionpathpointstype/) خصائص تحرير النقاط، مثل نقاط الزاوية أو السلسة. لا يحلّ محل نوع الأمر. استخدم نوع نقطة المنحنى لمثال المنحنى أدناه، ونوع نقطة الزاوية للقطاعات المستقيمة.

إحداثيات المسار مُطابقة لأبعاد الشريحة: إزاحة X بقيمة 0.25 تمثّل ربع عرض الشريحة، وليس 0.25 نقطة. Y الموجبة تتجه إلى الأسفل. تحدد الأوامر المطلقة المواضع في نظام إحداثيات المسار؛ تحدد الأوامر النسبية الإزاحات من الموضع الحالي. هذا منفصل عن [getOrigin](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/motioneffect/#getOrigin)، الذي يختار إطار مرجعي للمسار، وعن [getPathEditMode](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/motioneffect/#getPathEditMode)، الذي يتحكم في كيفية تحرك المسار عندما يتحرك الشكل.

### **إنشاء مسار مستقيم**

أنشئ سلوك حركة بنقطة بدء، قطعة مستقيمة واحدة، وأمر إنهاء. يأخذ [MotionPath.add](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/motionpath/#add) نوع الأمر، نقاطه، نوع النقطة، وعلم الإحداثيات النسبية.

يُنشئ الأمر الأول (0, 0)، وتنتهي الخطّة عند (0.25, 0) مِما يمنح المسار إزاحة أفقية ربع عرض الشريحة. لا يحتوي أمر النهاية على إحداثيات. بعد تعيين المسار، يربط إضافة سلوك الحركة إلى التأثير ذلك المسار بالمستطيل.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.PathRight, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const motion = factory.createMotionEffect();
    motion.setOrigin(aspose.slides.MotionOriginType.Layout);
    motion.getTiming().setDuration(2);

    const path = new aspose.slides.MotionPath();
    path.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
    path.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.25), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.add(aspose.slides.MotionCommandPathType.End, java.newArray("java.awt.geom.Point2D$Float", []), aspose.slides.MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يحتوي `motion.pptx` على سلوك حركة واحد مع ثلاثة أوامر مسار. تستخدم أمثلة تعديل الملفات التالية هذا الهيكل المعروف.

### **مقارنة الإحداثيات المطلقة والنسبية**

هذان الكائنان للمسار يصفان نفس المسار. ينتهي الأمر المطلق عند (0.3, 0.1)؛ يضيف الأمر النسبي (0.1, 0.1) إلى الموضع الحالي، (0.2, 0).

كلا المسارين يبدآن من نفس الموضع. بالنسبة للخط النسبي، أضف إزاحتي X وY إلى الموضع الحالي للحصول على نقطة النهاية؛ بالنسبة للخط المطلق، اقرأ نقطة النهاية مباشرة. سيؤدي تغيير العلم دون تحويل الإحداثيات إلى مسار مختلف.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const absolutePath = new aspose.slides.MotionPath();
absolutePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
absolutePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);

const relativePath = new aspose.slides.MotionPath();
relativePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
relativePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, true);
```

عيّن أحد المسارين إلى سلوك حركة لاستخدامه في عرض تقديمي. يحدد الوسيط البولياني الأخير ما إذا كانت الإحداثيات نسبية لذلك الأمر.

### **استبدال خط بمنحنى**

افتح `motion.pptx` واستبدل أمر الخط بمنحنى مكعب. زوّد أولاً نقطتي التحكم، ثم نقطة النهاية.

يُزوَّد الموضع الابتدائي بالأمر السابق. تشكِّل النقطتان الأوليتان المنحنى، بينما النقطة الثالثة هي وجهته؛ ليست ثلاث نقاط متتالية لوجهات. يضمن تحديث نوع الأمر، نوع تحرير النقاط، ومصفوفة النقاط معًا بقاء القطعة متسقةً مع هندستها الجديدة.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.get_Item(1).setCommandType(aspose.slides.MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(aspose.slides.MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]));

    presentation.save("curve.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ما زال المسار في `curve.pptx` يحتوي على ثلاثة أوامر؛ الأمر الأوسط الآن يحدِّد منحنى.

## **فحص وتعديل مسار محفوظ**

كل [MotionCmdPath](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/motioncmdpath/) يُظهر [getPoints](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/motioncmdpath/#getPoints)، و [getCommandType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/motioncmdpath/#getCommandType)، و [getPointsType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/motioncmdpath/#getPointsType)، و [isRelative](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/motioncmdpath/#isRelative). تستخدم الأمثلة التالية المسار الثلاثي الأوامر المعروف في `motion.pptx`. بالنسبة إلى إدخال عشوائي، حدِّد التأثير المستهدف وتحقّق من أنواع الأوامر وعدد النقاط قبل التحرير حسب الفهرس.

### **قراءة الأوامر والإحداثيات**

اقرأ المسار دون تغييره. لا تحتاج أوامر End و CloseLoop إلى نقاط، لذا يجب السماح بمصفوفة نقاط فارغة.

تُطبع أزواج كل نوع أمر رقمي مع علم الإحداثيات النسبية قبل سرد نقاطه. يتيح لك ذلك التمييز بين نقطة النهاية والإزاحة قبل تعديل المسار. سيُظهر المنحنى ثلاث نقاط، بينما يُظهر الخط المستقيم في هذا الملف نقطة واحدة فقط.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    for (let i = 0; i < path.getCount(); i++) {
        const segment = path.get_Item(i);
        console.log(segment.getCommandType() + ", relative: " + segment.isRelative());
        const points = segment.getPoints();
        if (points != null) {
            for (const point of points) {
                console.log("X=" + point.getX() + ", Y=" + point.getY());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

يتضمن السرد نقطة بدء، خطًا مطلقًا ينتهي عند (0.25, 0)، وأمر End.

### **تغيير نقطة النهاية**

افتح `motion.pptx` واستبدل مصفوفة نقاط الخط لتحريك نقطة النهاية.

في ملف الإدخال، الفهرس 0 هو أمر البدء والفهرس 1 هو الخط. يؤدي استبدال النقطة الوحيدة للخط إلى تغيير وجهته دون تعديل نوع الأمر أو توقيته أو موقعه في المجموعة. لأن الأمر يستخدم إحداثيات مطلقة، فإن الزوج الجديد يحدد موضعًا وليس إزاحةً مضافةً.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const motion = effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.4), java.newFloat(0.1))]));

    presentation.save("motion-endpoint.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ينتهي الخط في `motion-endpoint.pptx` عند (0.4, 0.1)؛ الملف الأصلي لم يتغيّر.

### **استبدال قطعة**

استخدم [insert](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/motionpath/#insert) و [removeAt](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/motionpath/#removeAt) لاستبدال الخط في `motion.pptx`. يدفع الإدراج الخط القديم إلى الفهرس 2.

يوضح هذا استبدال كائن أمر بدلاً من تحرير إحداثياته الحالية. بعد الإدراج، تحتوي المجموعة مؤقتًا على أمر البدء، الخط الجديد، الخط القديم، وأمر End. يزيل حذف الفهرس 2 الخط القديم ويترك المسار الجديد في مكانه.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.insert(1, aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ما زال المسار المحفوظ يحتوي على ثلاثة أوامر، حيث ينتهي الخط الجديد عند (0.2, 0.1) وأمر End يكون الأخير.

## **تعديل والتحقق من سلوك موجود**

عند عدم معرفة فهرس السلوك، حدده حسب النوع. يفتح هذا المثال `rotation.pptx`، يجد [RotationEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/rotationeffect/)، يغيّر الزاوية، ويتحقق من القيمة المحفوظة بعد إعادة الفتح.

تسمح فحص النوع بتخطي السلوكيات التي ليست تدويرات. يقرأ التحميل الثاني الملف المحفوظ في كائن عرض تقديمي منفصل، لذا تتحقق المقارنة من البيانات المستمرة بدلاً من القيمة التي لا تزال في الذاكرة. لا يزال هذا المثال يفترض أن التأثير المعروف هو الأول في التسلسل الرئيسي؛ لا يضمن اختيار سلوك حسب النوع العثور على التأثير الصحيح في عرض تقديمي عشوائي.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (let i = 0; i < effect.getBehaviors().getCount(); i++) {
        const behavior = effect.getBehaviors().get_Item(i);
        if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
            const rotation = behavior;
            rotation.setBy(180);
        }
    }

    presentation.save("rotation-edited.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("rotation-edited.pptx");
    try {
        const savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (let i = 0; i < savedEffect.getBehaviors().getCount(); i++) {
            const behavior = savedEffect.getBehaviors().get_Item(i);
            if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
                const rotation = behavior;
                console.log("Rotation preserved: " + (Math.abs(rotation.getBy() - 180) < 0.001));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

الناتج هو `Rotation preserved: true`. طبّق نمط فحص النوع نفسه على سلوكيات أخرى. للتحقق الكامل من الحفظ، قارن الشكل المستهدف، التأثير، أنواع السلوكيات وترتيبها، التوقيت، وأوامر المسار. استخدم تحمّلاً رقميًا للقيم العائمة. بالنسبة إلى عرض تقديمي ذو تخطيط رسوم متحركة غير معروف، راجع [قراءة رسوم متحركة الشكل](/slides/ar/nodejs-java/shape-animation/#read-shape-animations) لاستعراض التسلسلات الرئيسية والتفاعلية.

## **ترتيب السلوكيات، الإعدادات المسبقة، والتشغيل**

الترتيب في [BehaviorCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/behaviorcollection/) هو ترتيب التخزين لعمليات التأثير. ليس قائمة تشغيل تجعل كل سلوك ينتظر تلقائيًا السابق. يحدّد التوقيت والتأثير المُحيط الجدولة. يمكن أن تتداخل السلوكيات، وتُتفاعل العمليات على نفس الخاصية عبر [getAdditive](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/behavior/#getAdditive) و [getAccumulate](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/behavior/#getAccumulate). لا تستخدم إعادة ترتيب المجموعة وحدها لجدولة “تحريك، ثم تدوير”، بل استخدم توقيتًا صريحًا أو تأثيرات منفصلة كما هو موضح في [رسوم متحركة الشكل](/slides/ar/nodejs-java/shape-animation/).

يصف [getType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effect/#getType) و [getSubtype](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effect/#getSubtype) للتأثير الإعداد المسبق له. لا يشكلان وصفًا كاملًا لشجرة سلوكيات مُعدلة. اختر الإعداد المسبق والنوع الفرعي قبل تخصيص السلوكيات: قد يؤدي تغيير الإعداد المسبق إلى إعادة بناء المجموعة وإهمال عملياتك المخصصة. على سبيل المثال، قد يستبدل تغيير تأثير Spin المُخصَّص إلى Fade سلوك التدوير بسلوكيات Set و Filter. افحص المجموعة مرة أخرى بعد تغيير إعداد مسبق أو نوع فرعي. قد يؤدي مسح سلوكيات الإعداد المسبق أيضًا إلى إزالة عمليات الرؤية أو التهيئة التي يحتاجها الإعداد المسبق. تستخدم الأمثلة شكلاً مرئيًا وتستبدل السلوكيات دون إعادة بناء تنفيذ كل إعداد مسبق.

## **توافق الصيغ**

لا يضمن حفظ شجرة السلوكيات تشغيلاً متطابقًا في كل مشاهد أو مُصدّر. افحص البيانات المحفوظة والناتج المرسوم بشكل منفصل.

| الصيغة أو الإخراج | ما يلزم التحقق منه |
| --- | --- |
| PPTX | استخدمها كالصيغة الأساسية للأمثلة. أعد فتحها للتحقق من شجرة السلوكيات القابلة للتعديل، ثم افحص التشغيل في نسخة PowerPoint المطلوبة. |
| PPT | قد يختلف تمثيل الثنائي القديم عن PPTX. اختبر دورة حفظ‑إعادة فتح منفصلة وتشغيل؛ لا تستنتج دعم كل تركيبة مخصصة من نجاح إخراج PPTX. |
| PDF, PNG, JPEG، وغيرها من صور الشرائح الثابتة | تحتوي على تمثيل ثابت للشرائح، وليس جدول سلوكيات قابل للتشغيل أو إطار رسومي نهائي مضمون. |
| [HTML5](/slides/ar/nodejs-java/export-to-html5/) | يستطيع تشغيل الرسوم المتحركة المدعومة عندما يُفعَّل رسم الشكل المتحرك في خيارات التصدير. جرّب التركيبات المخصصة في المتصفح. |
| [GIF متحرك](/slides/ar/nodejs-java/convert-powerpoint-to-animated-gif/) | يخزن إطارات مرسومة، وليس سلوكيات قابلة للتعديل أو تفاعلات نقر. تحقّق من الحركة الفعلية المرسومة. |
| [فيديو](/slides/ar/nodejs-java/convert-powerpoint-to-video/) | يرسم إطارات الرسوم المتحركة ويُرمِّزها كفيديو. الدعم محدود إلى [الرسوم المتحركة والتأثيرات المدعومة](/slides/ar/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) للمُصدِّر؛ لا تصبح الأوامر والأحداث التفاعلية جدولًا قابلًا للتعديل. |

## **الأسئلة الشائعة**

**لماذا يحتوي التأثير على سلوكيات قبل أن أضيف أي شيء؟**

قد يُنشئ تأثير محدد مسبقًا عملياته الأساسية. افحصها قبل اتخاذ قرار إما توسيع الإعداد المسبق أو استبدال سلوكياته.

**هل يؤدي نقل سلوك إلى البداية إلى تشغيله أولًا؟**

ليس بالضرورة. ترتيب المجموعة ليس بديلاً عن التوقيت. افحص التأخيرات، والمدة، والتفاعلات بين العمليات على نفس الخاصية.

**لماذا لا يحتوي أمر End على نقاط؟**

يُحدد نهاية المسار ولا يحتاج إلى إحداثيات. تحقق من مصفوفة نقاط فارغة عند فحص مسار مُقرأ من ملف.

**هل يكفي نجاح جولة كاملة لتأكيد التشغيل؟**

لا. يؤكّد إعادة الفتح حفظ الخصائص التي فحصتها. اختبر مشغّل عروض الشرائح أو التصدير المتحرك بصورة منفصلة لتأكيد سلوكه البصري.