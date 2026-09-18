---
title: إنشاء وتعديل سلوكيات الرسوم المتحركة المخصصة في Java
linktitle: الرسوم المتحركة المخصصة
type: docs
weight: 151
url: /ar/java/custom-animation/
keywords:
- الرسوم المتحركة المخصصة
- سلوك الرسوم المتحركة
- مسار الحركة
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "إنشاء وفحص وتعديل سلوكيات الرسوم المتحركة المخصصة ومسارات الحركة القابلة للتحرير في عروض PowerPoint باستخدام Aspose.Slides for Java."
---
## **نظرة عامة**

تسمح سلوكيات الرسوم المتحركة المخصصة بالتحكم في العمليات الفردية داخل تأثير الرسوم المتحركة، مثل تغيير اللون، تدوير الشكل، أو اتباع مسار حركة قابل للتحرير. يوضح هذا الدليل كيفية إنشاء السلوكيات وت组合ها، وتكوين توقيتها، وفحص الرسوم المتحركة الحالية وتعديلها، والتحقق من بقاء خصائصها عند حفظ وإعادة فتح العرض التقديمي.

للأثر المسبق ومُشغلات النقر، انظر [رسوم المتحركة الشكلية](/slides/ar/java/shape-animation/).

## **فهم نموذج الرسوم المتحركة**

تنظم الرسوم المتحركة كـ **الجدول الزمني → التسلسل → التأثير → السلوكيات**:

- تُعيد طريقة [getTimeline](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseslide/#getTimeline--) جدول زمني للشريحة، والذي يحتوي على التسلسل الرئيسي والتسلسلات التفاعلية.
- يحتوي [ISequence](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isequence/) على تأثيرات، قد تستهدف أشكالًا مختلفة.
- يحدد [IEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ieffect/) شكل الهدف، والإعداد المسبق، والنوع الفرعي، وتوقيت التأثير.
- المجموعة التي تُرجعها [IEffect.getBehaviors](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ieffect/#getBehaviors--) تحتوي على العمليات التي تُنفّذ التأثير: تغيير اللون، التحريك، الدوران، ضبط خاصية، إلخ.

## **إنشاء سلوكيات فردية**

استدعِ [ISequence.addEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) لإنشاء تأثير والوصول إلى مجموعة [getBehaviors](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ieffect/#getBehaviors--). يمكن أن يملأ إعداد مسبق هذه المجموعة تلقائيًا. احتفظ بعملياتها عند تمديد الإعداد المسبق، أو استخدم [clear](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibehaviorcollection/#clear--) عند استبدالها عمدًا.

[IBehaviorFactory](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibehaviorfactory/) ينشئ الأنواع الثمانية للسلوك الموضحة أدناه. يُغطي الحركة في [إنشاء مسار حركة](#build-a-motion-path). يتضمن كل مقطع استيراداته؛ ضع عبارات التنفيذ داخل طريقة. تحدد أمثلة التحرير اللاحقة ملف الإخراج الذي تستخدمه.

### **الدوران**

استخدم [createRotationEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) لإنشاء دوران. يحدد [getBy](https://reference.aspose.com/slides/ar/java/com.aspose.slides/irotationeffect/#getBy--) زاوية نسبية بالدرجات؛ يحدِّد [getFrom](https://reference.aspose.com/slides/ar/java/com.aspose.slides/irotationeffect/#getFrom--) و[getTo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/irotationeffect/#getTo--) نقاط النهاية.

يبدأ المثال بتأثير Spin، يستبدل عمليات الإعداد المسبق بدورة دوران واحدة، ويعطي تلك العملية مدة ثانيتين. تعبر الزاوية النسبية 90 درجة عن ربع دورة من اتجاه الشكل الأصلي، لذا لا يلزم تحديد زاوية بدء صريحة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IRotationEffect rotation = factory.createRotationEffect();
    rotation.setBy(90f);
    rotation.getTiming().setDuration(2f);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` يحتوي على شكل واحد وسلوك دوران واحد. تُستخدم المجموعة، التوقيت، وأمثلة تعديل الدوران أدناه هذا الملف.

### **التحجيم**

استخدم [createScaleEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) مع نسب X/Y: يصف [getFrom](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iscaleeffect/#getFrom--) و[getTo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iscaleeffect/#getTo--) الحجم الابتدائي والنهائي، بينما يصف [getBy](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iscaleeffect/#getBy--) تغييرًا نسبيًا. هنا، 100 تعني الحجم الأصلي.

ينمو المثال البعدين من 100% إلى 125% خلال ثانيتين. الحفاظ على النسب الأفقية والعمودية المتساوية يحافظ على نسب الشكل؛ النسب المختلفة ستمدد بُعدًا أكثر من الآخر.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new Point2D.Float(100, 100));
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **اللون**

استخدم [createColorEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibehaviorfactory/#createColorEffect--) لتغيير التعبئة من الأزرق إلى البرتقالي. [getFrom](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icoloreffect/#getFrom--) و[getTo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icoloreffect/#getTo--) هما ألوان؛ [getBy](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icoloreffect/#getBy--) هو إزاحة لونية. يحدد [IBehavior.getProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibehavior/#getProperties--) الخاصية التي تُحرك.

يُهيأ تعبئة الشكل الصلبة إلى اللون الأزرق، مطابقةً لون البداية في الرسوم المتحركة. يحدد اختيار خاصية تعبئة اللون السلوك ما الجزء الذي يغيّر؛ لا تُحدد نقاط النهاية اللونية الخاصية نفسها. يصف التأثير المُحفظ انتقالًا إلى البرتقالي خلال ثانيتين.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IColorEffect color = factory.createColorEffect();
    color.getProperties().add(BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(Color.BLUE);
    Color orange = new Color(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **الفلتر**

استخدم [createFilterEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) لتحديد مسح. يحدد [getType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifiltereffect/#getType--)، [getSubtype](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifiltereffect/#getSubtype--)، و[getReveal](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifiltereffect/#getReveal--) الفلتر، الاتجاه، وما إذا كان سيُظهر أو يُخفي الشكل.

يضبط هذا المثال مسحًا لمدة ثانيتين يُظهر الشكل باستخدام النوع الفرعي للاتجاه إلى اليمين. تنتمي إعدادات الفلتر إلى السلوك داخل التأثير، لذا تُضبط بعد إزالة عمليات الإعداد المسبق الأصلية.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IFilterEffect filter = factory.createFilterEffect();
    filter.setType(FilterEffectType.Wipe);
    filter.setSubtype(FilterEffectSubtype.Right);
    filter.setReveal(FilterEffectRevealType.In);
    filter.getTiming().setDuration(2f);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **الخاصية**

استخدم [createPropertyEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) لتحريك الشفافية. [getFrom](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipropertyeffect/#getFrom--)، [getTo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipropertyeffect/#getTo--)، و[getBy](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipropertyeffect/#getBy--) هي سلاسل تُفسَّر باستخدام [getValueType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipropertyeffect/#getValueType--) و[getCalcMode](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipropertyeffect/#getCalcMode--). اختر نقاط النهاية أو إزاحة نسبية بدلاً من ضبط الثلاثة معًا دون تمييز.

في هذا المثال، الخاصية المختارة هي الشفافية، والسلاسل الرقمية تُمثل تغييرًا من شفافية 25% إلى شفافية كاملة. يصف الاستيفاء الخطي تغييرًا تدريجيًا بين القيم. عند تعديل المثال لخاصية أخرى، اختر نوع قيمة وقيم نهائية مناسبة لتلك الخاصية.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IPropertyEffect property = factory.createPropertyEffect();
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(PropertyValueType.Number);
    property.setCalcMode(PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2f);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **التعيين**

استخدم [createSetEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibehaviorfactory/#createSetEffect--) لتعيين الرؤية عبر [getTo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iseteffect/#getTo--). لا يُجري سلوك التعيين استيفاءً بين نقاط النهاية.

يختار المثال خاصية الرؤية ويُعيّن السلسلة `visible` عندما يُنفّذ السلوك. المستطيل مرئي بالفعل في هذا العرض التقديمي البسيط، لذا قد لا ينتج عن التعيين تغييرًا بصريًا واضحًا بمفرده. تُعد هذه العملية مفيدة كجزء من تأثير أكبر يتحكم أيضًا في وقت إخفاء أو إظهار الشكل.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    ISetEffect set = factory.createSetEffect();
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **الأمر**

استخدم [createCommandEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) وضع ضبط [getType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icommandeffect/#getType--)، [getCommandString](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icommandeffect/#getCommandString--)، و[getShapeTarget](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icommandeffect/#getShapeTarget--). ضع ملف تسجيل WAV باسم `sample.wav` في دليل العمل. يدمج هذا المثال الملف باستخدام [addAudioFrameEmbedded](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) ويربط أمر تشغيل بالإطار الصوتي.

إطار الصوت هو هدف التأثير وأيضًا هدف الأمر. يربط ذلك طلب التشغيل بالتسجيل المدمج؛ لا تُحدِّد سلسلة الأمر نفسها أي كائن وسائط يتحكم فيه. يُضبط التأثير للبدء عند النقر أثناء عرض الشرائح.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    try (FileInputStream audioStream = new FileInputStream("sample.wav")) {
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        IEffect effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        IBehaviorFactory factory = new BehaviorFactory();
        ICommandEffect command = factory.createCommandEffect();
        command.setType(CommandEffectType.Call);
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Unable to read sample.wav: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

يحفظ الأمر في `command.pptx`؛ ولا يُشغل التسجيل. يتطلب تشغيل التسجيل مشغِّل عرض شرائح يدعم الأمر وهدف وسائطه.

## **إدارة مجموعة السلوكيات**

[IBehaviorCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibehaviorcollection/) يدعم [add](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-)، [insert](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-)، [remove](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-)، و[removeAt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibehaviorcollection/#removeAt-int-). يفتح هذا المثال `rotation.pptx`، يضيف تحجيمًا، ينقله قبل الدوران، ويزيل الدوران. يغيّر إزالة وإعادة إدخال نفس الكائن موقعه المخزن دون إنشاء نسخة.

تغيّر تسلسل التعديلات المجموعة من دوران‑تحجيم إلى تحجيم‑دوران، ثم إلى تحجيم فقط. تشير الفهارس إلى المجموعة الحالية، لذا يستخدم الإزالة الفهرس الجديد للدوران بعد إعادة الترتيب. يؤكّد العد النهائي أي سلوك سيُحفظ.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (IBehavior behavior : behaviors)
        System.out.println(behavior.getClass().getSimpleName());

    presentation.save("collection-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

الناتج هو `ScaleEffect`: يبقى التحجيم فقط. لا يُسبب ترتيب المجموعة بمفرده جدولة السلوكيات واحدًا بعد الآخر. امسح المجموعة فقط عند استبدال جميع عملياتها.

## **تكوين توقيت السلوك**

[IBehavior.getTiming](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibehavior/#getTiming--) يُظهر [ITiming](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/)، مستقلًا عن [IEffect.getTiming](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ieffect/#getTiming--). يحدد توقيت التأثير الجدولة العامة للتأثير؛ يصف توقيت السلوك عملية داخل ذلك.

### **تعيين المدة، التأخير، التكرار، والتسارع**

افتح `rotation.pptx` واضبط المدة باستخدام [getDuration](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#getDuration--) وتأخير المشغل باستخدام [getTriggerDelayTime](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#getTriggerDelayTime--) بالثواني، ثم ضبط عدد التكرارات عبر [setRepeatCount](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#setRepeatCount-float-). [getAccelerate](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#getAccelerate--) و[getDecelerate](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#getDecelerate--) هما كسور من المدة؛ حافظ على مجموعهما لا يتجاوز 1.

ملف الإدخال هو الملف المُنشأ في مثال الدوران، حيث يُعرف أن السلوك الأول هو دوران. يغيّر هذا المثال توقيت ذلك السلوك فقط؛ يظل زاويته 90 درجة محفوظة. يسهّل فصل الزاوية عن التوقيت تعديل الوتيرة دون إعادة بناء الرسوم المتحركة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IRotationEffect rotation = (IRotationEffect)effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2f);
    rotation.getTiming().setTriggerDelayTime(0.5f);
    rotation.getTiming().setRepeatCount(3f);
    rotation.getTiming().setAccelerate(0.2f);
    rotation.getTiming().setDecelerate(0.2f);

    presentation.save("timing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يستخدم السلوك مدة ثانيتين، تأخيرًا نصف ثانية، وعدد تكرار 3. يُستَخدم أول 20٪ وآخر 20٪ من المدة للتسارع والتباطؤ.

سياسات التكرار الأخرى تشمل [getRepeatDuration](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#getRepeatDuration--)، [getRepeatUntilEndSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--)، و[getRepeatUntilNextClick](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--); اختر سياسةً واحدةً بدلًا من تفعيل كلهن معًا. تُعيد [getAutoReverse](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiming/#getAutoReverse--) تشغيل الرسوم المتحركة بالعكس بعد المرور للأمام. ينطبق التسارع والتباطؤ على التغييرات المستمرة، وليس على التعيينات المتقطعة أو الأوامر.

## **إنشاء مسار حركة**

استخدم [createMotionEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) لإنشاء حركة. تصف [getFrom](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imotioneffect/#getFrom--) و[getTo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imotioneffect/#getTo--) و[getBy](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imotioneffect/#getBy--) إحداثيات أو إزاحات مبنية على النسب المئوية. لإنشاء مسار قابل للتحرير، أنشئ [MotionPath](https://reference.aspose.com/slides/ar/java/com.aspose.slides/motionpath/) وعيّنها عبر [IMotionEffect.setPath](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-). تخزن [IMotionPath](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imotionpath/) أوامر المسار.

[MotionCommandPathType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/motioncommandpathtype/) يحدد العملية:

| الأمر | النقاط | المعنى |
| --- | --- | --- |
| MoveTo | واحدة | تعيين موضع البداية. |
| LineTo | واحدة | التحرك على مقطع مستقيم إلى نقطته النهائية. |
| CurveTo | ثلاث | اتباع منحنى مكعّب يُحدَّد بنقطتي تحكم ونقطة نهائية. |
| CloseLoop | لا شيء | العودة إلى موضع البداية. |
| End | لا شيء | إنهاء المسار. |

[MotionPathPointsType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/motionpathpointstype/) يصف خصائص تحرير النقاط، مثل نقاط الزاوية أو النقاط الملساء. لا يُستبدل بنوع الأمر. استخدم نوع نقطة المنحنى للمثال المنحني أدناه، ونوع نقطة الزاوية للقطاعات المستقيمة.

إحداثيات المسار مُطبَّقة على أبعاد الشريحة: إزاحة X بقيمة 0.25 تمثل ربع عرض الشريحة، وليس 0.25 نقطة. Y الموجبة تتجه إلى الأسفل. تُحدد الأوامر المطلقة المواضع في نظام إحداثيات المسار؛ وتُحدد الأوامر النسبية الإزاحات من الموضع الحالي. هذا منفصل عن [getOrigin](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imotioneffect/#getOrigin--) الذي يختار إطار مرجعي للمسار، و[getPathEditMode](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imotioneffect/#getPathEditMode--) الذي يتحكم في كيفية تحرك المسار عند تحريك الشكل.

### **إنشاء مسار مستقيم**

أنشئ سلوك حركة بنقطة بدء، قطعة مستقيمة واحدة، وأمر نهاية. تتلقى [IMotionPath.add](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imotionpath/#add-int-java.awt.geom.Point2D.Float---int-boolean-) نوع الأمر، نقاطه، نوع النقطة، وعلم إحداثيات نسبية.

يؤسس أمر البداية (0, 0)، وينتهي الخط عند (0.25, 0)، مما يمنح المسار إزاحة أفقية بربع عرض الشريحة. لا يحتوي أمر النهاية على نقاط إحداثيات. بمجرد تعيين المسار، يربط إضافة سلوك الحركة إلى التأثير ذلك المسار بالمستطيل.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IMotionEffect motion = factory.createMotionEffect();
    motion.setOrigin(MotionOriginType.Layout);
    motion.getTiming().setDuration(2f);

    IMotionPath path = new MotionPath();
    path.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new Point2D.Float[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` يحتوي على سلوك حركة واحد بثلاثة أوامر مسار. تُستخدم أمثلة تحرير الملفات التالية هذا الهيكل المعروف.

### **مقارنة الإحداثيات المطلقة والنسبية**

هذان الكائنان يصفان نفس المسار. ينتهي الأمر المطلق عند (0.3, 0.1)؛ يضيف الأمر النسبي (0.1, 0.1) إلى الموضع الحالي، لينتهي عند (0.2, 0).

كلا المسارين يبدأان من نفس الموضع. للخط النسبي، أضف إزاحات X وY إلى الموضع الحالي للحصول على نقطة النهاية؛ للخط المطلق، اقرأ نقطة النهاية مباشرة. سيتغيّر المسار إذا غيرت العلم دون تحويل الإحداثيات.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

عيّن أي من المسارين إلى سلوك حركة لاستخدامه في عرض تقديمي. يختار الوسيط البولياني الأخير الإحداثيات النسبية لذلك الأمر.

### **استبدال خط بمنحنى**

افتح `motion.pptx` واستبدل أمر الخط بمنحنى مكعّب. زوِّد نقطتي التحكم أولًا، ثم نقطة النهاية.

توفر الأوامر السابقة الموضع الابتدائي. تشكِّل النقطتان الأوليان المنحنى، بينما تمثّل الثالثة وجهته؛ ليست ثلاث نقاط وجهات متتابعة. يُحافظ تحديث نوع الأمر، نوع تحرير النقاط، ومصفوفة النقاط معًا على تناسق القطعة مع الهندسة الجديدة.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.1f, 0), new Point2D.Float(0.2f, 0.1f), new Point2D.Float(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

المسار في `curve.pptx` لا يزال يحتوي على ثلاثة أوامر؛ الآن يعرّف الأمر الأوسط منحنى.

## **فحص وتحرير مسار محفوظ**

كل [IMotionCmdPath](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imotioncmdpath/) يُظهر [getPoints](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imotioncmdpath/#getPoints--)، [getCommandType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imotioncmdpath/#getCommandType--)، [getPointsType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imotioncmdpath/#getPointsType--)، و[isRelative](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imotioncmdpath/#isRelative--). تستخدم الأمثلة التالية المسار ذو الثلاث أوامر في `motion.pptx`. للمدخلات العشوائية، حدِّد التأثير المقصود وتحقق من أنواع الأوامر وعدد النقاط قبل التحرير عبر الفهرس.

### **قراءة الأوامر والإحداثيات**

اقرأ المسار دون تغييره. لا تحتاج أوامر النهاية وإغلاق الحلقة إلى نقاط، لذا قد تحتاج إلى مصفوفة نقاط فارغة.

تُظهر المخرجات كل نوع أمر رقمي مع علم الإحداثيات النسبية قبل سرد نقاطه. يُتيح لك ذلك التفريق بين نقطة نهائية وإزاحة قبل تعديل المسار. سيُظهر منحنى ثلاث نقاط، بينما يذكر الخط المستقيم في هذا الملف نقطة واحدة فقط.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (Point2D.Float point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

تتضمن القائمة نقطة بدء، وخطًا مطلقًا ينتهي عند (0.25, 0)، وأمر النهاية.

### **تغيير نقطة النهاية**

افتح `motion.pptx` واستبدل مصفوفة نقاط الخط لتحريك نقطة النهاية.

في ملف الإدخال، الفهرس 0 هو أمر البداية والفهرس 1 هو الخط. استبدال النقطة الوحيدة للخط يغيّر وجهته دون تغيير نوع الأمر أو توقيته أو موقعه في المجموعة. بما أن الأمر يستخدم إحداثيات مطلقة، فإن الزوج الجديد يحدد موضعًا وليس إزاحةً مضافة.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

الخط في `motion-endpoint.pptx` ينتهي عند (0.4, 0.1)؛ الملف الأصلي يبقى دون تغيير.

### **استبدال مقطع**

استخدم [insert](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imotionpath/#insert-int-int-java.awt.geom.Point2D.Float---int-boolean-) و[removeAt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imotionpath/#removeAt-int-) لاستبدال الخط في `motion.pptx`. يُعيد الإدراج إزاحة الخط القديم إلى الفهرس 2.

يوضح هذا استبدال كائن أمر بدلاً من تحرير إحداثياته الحالية. بعد الإدراج، تحتوي المجموعة مؤقتًا على أمر البداية، الخط الجديد، الخط القديم، وأمر النهاية. حذف الفهرس 2 يتخلّص من الخط القديم ويترك المسار الجديد في مكانه.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

المسار المحفوظ لا يزال يحتوي على ثلاثة أوامر، والخط الجديد ينتهي عند (0.2, 0.1) وأمر النهاية يبقى آخرًا.

## **تعديل والتحقق من سلوك موجود**

عند عدم معرفة فهرس السلوك، حدِّده بالنوع. يفتح هذا المثال `rotation.pptx`، يجد [IRotationEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/irotationeffect/)، يغيّر الزاوية، ويتحقق من القيمة المحفوظة بعد إعادة الفتح.

يتيح فحص النوع تخطي السلوكيات التي ليست دورانات. يقرأ التحميل الثاني الملف المحفوظ إلى كائن عرض تقديمي منفصل، لذا تتحقق المقارنة من البيانات المستمرة وليس من القيمة المتواجدة في الذاكرة. لا يزال هذا المثال يفترض أن التأثير المعروف هو الأول في التسلسل الرئيسي؛ لا يضمن اختيار سلوك بالنوع تحديد التأثير الصحيح في عرض تقديمي عشوائي.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (IBehavior behavior : effect.getBehaviors())
    {
        if (behavior instanceof IRotationEffect) {
            IRotationEffect rotation = (IRotationEffect) behavior;
            rotation.setBy(180f);
        }
    }

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("rotation-edited.pptx");
    try {
        IEffect savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (IBehavior behavior : savedEffect.getBehaviors())
        {
            if (behavior instanceof IRotationEffect) {
                IRotationEffect rotation = (IRotationEffect) behavior;
                System.out.println("Rotation preserved: " + (Math.abs(rotation.getBy() - 180f) < 0.001f));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

الناتج هو `Rotation preserved: true`. طبّق نمط فحص النوع نفسه على سلوكيات أخرى. للتحقق الكامل من الحفظ، قارن شكل الهدف، التأثير، أنواع السلوكيات وترتيبها، التوقيت، وأوامر المسار. استخدم تسامحًا عدديًا للقيم ذات الفاصلة العائمة. لعروض تقديمية ذات تخطيط رسوم متحركة غير معروف، راجع [قراءة رسوم المتحركة للأشكال](/slides/ar/java/shape-animation/#read-shape-animations) لتجوال التسلسلات الرئيسية والتفاعلية.

## **ترتيب السلوكيات، الإعدادات المسبقة، والتشغيل**

ترتيب السلوكيات في [IBehaviorCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibehaviorcollection/) هو الترتيب المخزن لعمليات التأثير. ليس قائمة تشغيل ينتظر فيها كل سلوك تلقائيًا السلوك السابق. يحدد التوقيت والتأثير المحيط الجدولة. يمكن أن تتداخل السلوكيات، وقد تتفاعل العمليات على نفس الخاصية عبر [getAdditive](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibehavior/#getAdditive--) و[getAccumulate](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibehavior/#getAccumulate--). لا تستخدم إعادة ترتيب المجموعة وحدها لجدولة "تحريك، ثم دوران"؛ استخدم توقيتًا صريحًا أو تأثيرات منفصلة كما هو موضح في [رسوم المتحركة الشكلية](/slides/ar/java/shape-animation/).

يصف [getType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ieffect/#getType--) و[getSubtype](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ieffect/#getSubtype--) في التأثير الإعداد المسبق. لا يقدمان وصفًا كاملاً لشجرة سلوكيات مُعدَّلة. اختر الإعداد المسبق والنوع الفرعي قبل تخصيص السلوكيات: قد يؤدي تغيير الإعداد المسبق إلى إعادة بناء المجموعة وإلغاء عملياتك المخصصة. على سبيل المثال، قد يستبدل تغيير تأثير Spin المخصَّص إلى Fade سلوك الدوران بسلوكيات تعيين وفلتر. افحص المجموعة مرة أخرى بعد تغيير إعداد مسبق أو نوع فرعي. قد يؤدي مسح سلوكيات الإعداد المسبق أيضًا إلى إزالة عمليات الرؤية أو التهيئة التي يحتاجها الإعداد المسبق. تستخدم الأمثلة أشكالًا مرئية وتستبدل السلوكيات؛ لا تعيد بناء كل تنفيذ لإعداد مسبق.

## **توافق الصيغ**

شجرة السلوكيات المحفوظة لا تضمن تشغيلًا متطابقًا في كل عارض أو مترجم تصدير. افحص البيانات المحفوظة والإخراج المرسوم بشكل منفصل.

| الصيغة أو المخرج | ما الذي يجب التحقق منه |
| --- | --- |
| PPTX | استخدمها كالصيغة الأساسية لهذه الأمثلة. أعد فتحها للتحقق من شجرة السلوكيات القابلة للتحرير، ثم افحص التشغيل في نسخة PowerPoint المستهدفة. |
| PPT | يمكن أن يختلف التمثيل الثنائي القديم عن PPTX. اختبر دورة حفظ‑إعادة فتح منفصلة وتشغيل؛ لا تستنتج دعم كل تركيبة مخصصة من نجاح مخرجات PPTX. |
| PDF, PNG, JPEG، وصور الشرائح الثابتة الأخرى | تحتوي على تمثيل شريحة ثابت، لا خط زمني تشغيل قابل للتشغيل أو إطار نهائي للرسوم المتحركة مضمَّن. |
| [HTML5](/slides/ar/java/export-to-html5/) | يمكنه تشغيل الرسوم المتحركة المدعومة عندما يُفعَّل رسم متحركة الشكل في خيارات التصدير. اختبر تركيبات مخصصة في المتصفح. |
| [GIF متحرك](/slides/ar/java/convert-powerpoint-to-animated-gif/) | يخزن إطارات مُرسَّمة، لا سلوكيات قابلة للتحرير أو تفاعلات بنقر. افحص الحركة المرسومة فعليًا. |
| [فيديو](/slides/ar/java/convert-powerpoint-to-video/) | يرسُم إطارات الرسوم المتحركة ويشفرها كفيديو. يدعم فقط [الرسوم المتحركة والتأثيرات المدعومة](/slides/ar/java/convert-powerpoint-to-video/#supported-animations-and-effects)؛ لا تتحول الأوامر والأحداث التفاعلية إلى خط زمني قابل للتحرير. |

## **الأسئلة الشائعة**

**لماذا يحتوي التأثير على سلوكيات قبل أن أضيف أي شيء؟**

إنشاء تأثير مُعد مسبقًا قد يُنشئ عملياته الأساسية. افحصها قبل اتخاذ قرار إما بتمديد الإعداد المسبق أو استبدال سلوكياته.

**هل يجعل نقل سلوك إلى البداية تشغيله أولًا؟**

ليس بالضرورة. ترتيب المجموعة ليس بديلاً عن التوقيت. افحص التأخيرات، والمدة، والتفاعلات بين عمليات الخصائص نفسها.

**لماذا لا يحتوي أمر النهاية على نقاط؟**

يُشير إلى نهاية المسار ولا يحتاج إلى إحداثيات. تحقق من مصفوفة نقاط فارغة عند فحص مسار مقروء من ملف.

**هل يكفي جولة حفظ‑إعادة فتح ناجحة لتأكيد التشغيل؟**

لا. تؤكد إعادة الفتح حفظ الخصائص التي فحصتها. اختبر مشغِّل عرض الشرائح أو تصدير الرسوم المتحركة بشكل منفصل لتأكيد سلوكه البصري.