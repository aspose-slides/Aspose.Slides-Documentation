---
title: إنشاء وتعديل سلوكيات الرسوم المتحركة المخصصة على Android
linktitle: رسوم متحركة مخصصة
type: docs
weight: 151
url: /ar/androidjava/custom-animation/
keywords:
- رسوم متحركة مخصصة
- سلوك الرسوم المتحركة
- مسار الحركة
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إنشاء وفحص وتعديل سلوكيات الرسوم المتحركة المخصصة ومسارات الحركة القابلة للتحرير في عروض PowerPoint التقديمية باستخدام Aspose.Slides للـ Android عبر Java."
---
## **نظرة عامة**

تتيح لك سلوكيات الرسوم المتحركة المخصصة التحكم في العمليات الفردية داخل تأثير الرسوم المتحركة، مثل تغيير اللون، دوران الشكل، أو تتبع مسار حركة قابل للتحرير. يوضح هذا الدليل كيفية إنشاء السلوكيات وجمعها، تكوين توقيتها، فحص وتعديل الرسوم المتحركة الموجودة، والتحقق من بقاء خصائصها بعد حفظ وإعادة فتح العرض التقديمي.

للتأثيرات المحددة مسبقًا ومشغلات النقر، راجع [رسوم المتحركة الشكلية](/slides/ar/androidjava/shape-animation/).

## **فهم نموذج الرسوم المتحركة**

يتم تنظيم الرسوم المتحركة على النحو التالي **الخط الزمني → التسلسل → التأثير → السلوكيات**:

- طريقة [getTimeline](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseslide/#getTimeline--) تُعيد خط الزمن للشرائح، الذي يحتوي على تسلسله الرئيسي والتسلسلات التفاعلية.
- تحتوي [ISequence](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isequence/) على تأثيرات، قد تستهدف أشكالًا مختلفة.
- تحدد [IEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ieffect/) الشكل المستهدف، الإعداد المسبق، النوع الفرعي، وتوقيت التأثير.
- المجموعة التي تُرجعها [IEffect.getBehaviors](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ieffect/#getBehaviors--) تحتوي على العمليات التي تنفذ التأثير: تغيير اللون، التحريك، الدوران، ضبط خاصية، وما إلى ذلك.

## **إنشاء سلوكيات فردية**

استدعِ [ISequence.addEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) لإنشاء تأثير والوصول إلى مجموعة [getBehaviors](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ieffect/#getBehaviors--). يمكن للإعداد المسبق ملء هذه المجموعة تلقائيًا. احتفظ بعملياته عند توسيع الإعداد المسبق، أو استخدم [clear](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibehaviorcollection/#clear--) عندما تستبدله عمدًا.

[IBehaviorFactory](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibehaviorfactory/) تنشئ الأنواع الثمانية للسلوكيات الموضحة أدناه. يتم تغطية الحركة في [إنشاء مسار حركة](#build-a-motion-path). كل مقتطف يتضمن استيراداته؛ ضع عبارات التنفيذ داخل طريقة. توضح أمثلة التحرير اللاحقة ملف الإخراج الذي تستخدمه. على Android، استبدل أسماء ملفات العينة بمسارات كاملة في دليل يمكن للتطبيق الوصول إليه، مثل دليل ملفات تطبيقك.

### **دوران**

استخدم [createRotationEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) لإنشاء دوران. يحدد [getBy](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/irotationeffect/#getBy--) زاوية نسبية بالدرجات؛ يحدد [getFrom](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/irotationeffect/#getFrom--) و[getTo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/irotationeffect/#getTo--) نقاط النهاية.

يبدأ المثال بتأثير Spin، يستبدل عملياته المسبقة بسلوك دوران واحد، ويعطي هذا السلوك مدة ثانيتين. زاوية نسبية قدرها 90 درجة تمثل ربع دورة من توجيه الشكل الابتدائي، لذا لا تحتاج إلى زاوية بدء صريحة.

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

`rotation.pptx` يحتوي على شكل واحد وسلوك دوران واحد. تُستخدم المجموعة، التوقيت، وأمثلة تحرير الدوران أدناه هذا الملف.

### **تحجيم**

استخدم [createScaleEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) مع نسب X/Y: يصف [getFrom](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iscaleeffect/#getFrom--) و[getTo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iscaleeffect/#getTo--) الحجم الابتدائي والنهائي، بينما يصف [getBy](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iscaleeffect/#getBy--) تغييرًا نسبيًا. هنا، 100 تعني الحجم الأصلي.

ينمو المثال البُعدين من 100٪ إلى 125٪ خلال ثانيتين. الحفاظ على نسب أفقية ورأسية متساوية يحافظ على نسب الشكل؛ النسب المختلفة ستمدد بُعدًا أكثر من الآخر.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new PointF(100, 100));
    scale.setTo(new PointF(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **لون**

استخدم [createColorEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibehaviorfactory/#createColorEffect--) لتغيير التعبئة من الأزرق إلى البرتقالي. [getFrom](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icoloreffect/#getFrom--) و[getTo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icoloreffect/#getTo--) هما ألوان؛ [getBy](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icoloreffect/#getBy--) هو إزاحة لون. يحدد [IBehavior.getProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibehavior/#getProperties--) الخاصية التي يتم تحريكها.

تم تهيئة تعبئة الشكل الصلبة إلى الأزرق لتطابق لون بدء الرسوم المتحركة. اختيار خاصية لون التعبئة يخبر السلوك أي جزء من الشكل يجب تغييره؛ نقاط اللون وحدها لا تحدد تلك الخاصية. يصف التأثير المحفوظ انتقالًا لمدة ثانيتين إلى البرتقالي.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int orange = Color.rgb(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **مرشح**

استخدم [createFilterEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) لاختيار مسح. يحدد [getType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifiltereffect/#getType--)، [getSubtype](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifiltereffect/#getSubtype--)، و[getReveal](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifiltereffect/#getReveal--) المرشح، الاتجاه، وما إذا كان سيظهر أو يخفى الشكل.

يضبط هذا المثال مسحًا مدته ثانيتان يكشف الشكل باستخدام النوع الفرعي للاتجاه إلى اليمين. إعدادات المرشح تنتمي إلى السلوك داخل التأثير، لذا يتم تكوينها بعد إزالة عمليات الإعداد المسبق الأصلية.

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

### **خاصية**

استخدم [createPropertyEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) لتحريك الشفافية. [getFrom](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipropertyeffect/#getFrom--)، [getTo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipropertyeffect/#getTo--)، و[getBy](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipropertyeffect/#getBy--) هي سلاسل نصية تُفسَّر باستخدام [getValueType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipropertyeffect/#getValueType--) و[getCalcMode](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipropertyeffect/#getCalcMode--). اختر نقاط النهاية أو إزاحة نسبية بدلاً من ضبط الثلاثة جميعًا عشوائيًا.

هنا، الخاصية المختارة هي الشفافية، والسلاسل الرقمية تمثل تغييرًا من شفافية 25٪ إلى شفافية كاملة. يصف الاستيفاء الخطي تغييرًا تدريجيًا بين تلك القيم. عند تعديل هذا المثال لخاصية أخرى، اختر نوع قيمة وقيم نهائية مناسبة لتلك الخاصية.

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

### **تعيين**

استخدم [createSetEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibehaviorfactory/#createSetEffect--) لتعيين الرؤية عبر [getTo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iseteffect/#getTo--). سلوك التعيين لا يستنتج بين نقاط النهاية.

يختار المثال خاصية الرؤية ويعطي السلسلة النصية `visible` عندما يُنفّذ السلوك. المستطيل مرئي بالفعل في هذا العرض التقديمي البسيط، لذا قد لا ينتج عن التعيين تغييرًا بصريًا واضحًا بمفرده. مفيد كهذا السلوك كجزء من تأثير أكبر يتحكم أيضًا بموعد إخفاء أو إظهار الشكل.

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

استخدم [createCommandEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) واضبط [getType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icommandeffect/#getType--)، [getCommandString](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icommandeffect/#getCommandString--)، و[getShapeTarget](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icommandeffect/#getShapeTarget--). ضع تسجيل صوتي بصيغة WAV اسمه `sample.wav` في دليل العمل. يضمّن هذا المثال الملف باستخدام [addAudioFrameEmbedded](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) ويربط أمر تشغيل بالإطار الصوتي.

الإطار الصوتي هو كل من هدف التأثير وهدف الأمر. يربط هذا طلب التشغيل بالتسجيل المضمّن؛ سلسلة الأمر وحدها لا تحدد أي كائن وسائط يجب التحكم به. يُضبط التأثير للبدء عند النقر خلال عرض الشرائح.

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

يحفظ الأمر في `command.pptx`؛ ولا يقوم بتشغيل التسجيل. يتطلب التشغيل مشغل عرض شرائح يدعم الأمر والوسيط المستهدف.

## **إدارة مجموعة السلوكيات**

[IBehaviorCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibehaviorcollection/) تدعم [add](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-)، [insert](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-)، [remove](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-)، و[removeAt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibehaviorcollection/#removeAt-int-). يفتح هذا المثال `rotation.pptx`، يضيف تحجيمًا، ينقله قبل الدوران، ثم يزيل الدوران. إزالة وإعادة إدخال نفس الكائن يغيّر موضعه المخزن دون إنشاء نسخة.

تغيّر تسلسل التعديلات المجموعة من دوران–تحجيم إلى تحجيم–دوران، ثم إلى تحجيم فقط. الإندكسات تشير إلى المجموعة الحالية، لذا يستخدم الإزالة إندكس الدوران الجديد بعد إعادة الترتيب. يُؤكّد العد النهائي أي سلوك سيتم حفظه.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new PointF(125, 125));
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

الناتج هو `ScaleEffect`: يبقى التحجيم فقط. لا يحدد ترتيب المجموعة، بحد ذاته، جدولة السلوكيات بعضها بعد بعض. امسح المجموعة فقط عند استبدال جميع عملياتها.

## **تكوين توقيت السلوك**

[IBehavior.getTiming](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibehavior/#getTiming--) يكشف عن [ITiming](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itiming/)، مستقلًا عن [IEffect.getTiming](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ieffect/#getTiming--). يحدد توقيت التأثير الجدولة للتأثير المحيط؛ توقيت السلوك يصف عملية داخل ذلك.

### **تحديد المدة، التأخير، التكرار، والتسريع**

افتح `rotation.pptx` وضبط المدة عبر [getDuration](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itiming/#getDuration--) وتأخير المشغل عبر [getTriggerDelayTime](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--) بالثواني، ثم اضبط عدد التكرارات باستخدام [setRepeatCount](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-). [getAccelerate](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itiming/#getAccelerate--) و[getDecelerate](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itiming/#getDecelerate--) هي كسور من المدة؛ حافظ على مجموعهما لا يزيد عن 1.

ملف الإدخال هو الملف الذي أنشئ في مثال الدوران، حيث يُعرف أن السلوك الأول هو دوران. يغيّر هذا المثال توقيت ذلك السلوك فقط؛ يظل زاوية الـ 90 درجة ثابتة. إبقاء الزاوية والتوقيت منفصلين يجعل تعديل السرعة أسهل دون الحاجة لإعادة بناء الرسوم المتحركة.

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

السلوك يستخدم مدة ثانيتين، تأخير نصف ثانية، وعدد تكرار 3. تُستَخدم أول 20% وآخر 20% من المدة للتسريع والتباطؤ.

تشمل سياسات التكرار الأخرى [getRepeatDuration](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itiming/#getRepeatDuration--)، [getRepeatUntilEndSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--)، و[getRepeatUntilNextClick](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--); اختر سياسة واحدة بدلاً من تمكينها جميعًا معًا. [getAutoReverse](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itiming/#getAutoReverse--) يعيد تشغيل الرسوم المتحركة بالعكس بعد المرور التقدمي. يُطبق التسريع والتباطؤ على التغييرات المستمرة، لا على التعيينات المتقطعة أو الأوامر.

## **إنشاء مسار حركة**

استخدم [createMotionEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) لإنشاء حركة. تصف [getFrom](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imotioneffect/#getFrom--)، [getTo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imotioneffect/#getTo--)، و[getBy](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imotioneffect/#getBy--) إحداثيات أو إزاحات نسبة مئوية. لإنشاء مسار قابل للتحرير، أنشئ [MotionPath](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/motionpath/) وعيّنه عبر [IMotionEffect.setPath](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-). تخزن [IMotionPath](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imotionpath/) أوامر المسار.

[MotionCommandPathType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/motioncommandpathtype/) يحدد العملية:

| الأمر | النقاط | المعنى |
| --- | --- | --- |
| MoveTo | واحد | تعيين موضع البداية. |
| LineTo | واحد | التحرك على طول قطعة مستقيمة إلى نقطة النهاية. |
| CurveTo | ثلاثة | تتبع منحنى تكعيبي يُحدَّد بنقطتي تحكم ونقطة النهاية. |
| CloseLoop | لا شيء | العودة إلى موضع البداية. |
| End | لا شيء | إنهاء المسار. |

[MotionPathPointsType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/motionpathpointstype/) يصف خصائص تحرير النقاط، مثل نقاط الزاوية أو السلاسة. لا يحل محل نوع الأمر. استخدم نوع نقطة المنحنى للمثال المنحني أدناه، ونوع نقطة الزاوية للقطع المستقيمة.

إحداثيات المسار مُعّدة إلى أبعاد الشريحة: إزاحة X بقيمة 0.25 تمثل ربع عرض الشريحة، وليس 0.25 نقطة. Y الموجبة تتجه إلى الأسفل. الأوامر المطلقة تحدد مواضعًا في نظام إحداثيات المسار؛ الأوامر النسبية تحدد إزاحات من الموضع الحالي. هذا منفصل عن [getOrigin](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imotioneffect/#getOrigin--) الذي يحدد إطار مرجع المسار، و[getPathEditMode](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imotioneffect/#getPathEditMode--) الذي يتحكم في كيفية تحرك المسار عندما يتحرك الشكل.

### **إنشاء مسار مستقيم**

أنشئ سلوك حركة بنقطة بداية، قطعة مستقيمة واحدة، وأمر نهاية. يأخذ [IMotionPath.add](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imotionpath/#add-int-android.graphics.PointF---int-boolean-) نوع الأمر، نقاطه، نوع النقطة، وعلم الإحداثيات النسبية.

يُحدد أمر البداية (0, 0)، والخط ينتهي عند (0.25, 0)، مما يعطي المسار إزاحة أفقية ربع عرض الشريحة. لا يحمل أمر النهاية أي نقاط إحداثية. بمجرد تعيين المسار، يربط إضافة سلوك الحركة إلى التأثير ذلك المسار بالمستطيل.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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
    path.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new PointF[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` يحتوي على سلوك حركة واحد مع ثلاثة أوامر مسار. تُستخدم أمثلة تحرير الملفات التالية هذا الهيكل المعروف.

### **مقارنة الإحداثيات المطلقة والنسبية**

هذان كائكان للمسار يصفان نفس المسار. الأمر المطلق ينتهي عند (0.3, 0.1)؛ الأمر النسبي يضيف (0.1, 0.1) إلى الموضع الحالي، (0.2, 0).

يتبدأ كلا المسارين من نفس الموضع. للخط النسبي، أضف إزاحتي X وY إلى الموضع الحالي للحصول على نقطة النهاية؛ للخط المطلق، اقرأ نقطة النهاية مباشرة. تغيير العلم دون تحويل الإحداثيات سيصف مسارًا مختلفًا.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

عيّن أي مسار إلى سلوك حركة لاستخدامه في عرض تقديمي. يحدد المعامل البولياني الأخير الإحداثيات النسبية لذلك الأمر.

### **استبدال خط بمنحنى**

افتح `motion.pptx` واستبدل أمر الخط بمنحنى تكعيبي. قدم نقطتي التحكم أولًا، ثم نقطة النهاية.

توفر الأمر السابق الموضع الابتدائي. النقطتان الأوليتان تشكلان المنحنى، بينما الثالثة هي وجهته؛ ليست ثلاث وجهات متتالية. تحديث نوع الأمر، نوع تحرير النقاط، ومصفوفة النقاط معًا يحافظ على تماسك الجزء مع الهندسة الجديدة.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new PointF[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

المسار في `curve.pptx` لا يزال يحتوي على ثلاثة أوامر؛ الآن الأمر الأوسط يعرّف منحنى.

## **فحص وتحرير مسار محفوظ**

كل [IMotionCmdPath](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imotioncmdpath/) يكشف عن [getPoints](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imotioncmdpath/#getPoints--)، [getCommandType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imotioncmdpath/#getCommandType--)، [getPointsType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imotioncmdpath/#getPointsType--)، و[isRelative](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imotioncmdpath/#isRelative--). تستخدم الأمثلة التالية المسار المعروف المكوّن من ثلاثة أوامر في `motion.pptx`. للمدخلات العشوائية، حدِّد التأثير المقصود وتحقق من أنواع الأوامر وعدد النقاط قبل التحرير حسب الفهرس.

### **قراءة الأوامر والإحداثيات**

اقرأ المسار دون تغييره. أوامر النهاية وإغلاق الحلقة لا تحتاج إلى نقاط، لذا استعد لمصفوفة نقاط فارغة.

القائمة تُظهر كل نوع أمر رقمي مع علم الإحداثيات النسبية قبل سرد نقاطه. يتيح لك ذلك التفريق بين نقطة النهاية وإزاحة قبل تعديل المسار. المنحنى سيُظهر ثلاث نقاط، بينما الخط المستقيم في هذا الملف يعرض نقطة واحدة فقط.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (PointF point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

القائمة تحتوي على نقطة بداية، وخط مطلق ينتهي عند (0.25, 0)، وأمر نهاية.

### **تغيير نقطة النهاية**

افتح `motion.pptx` واستبدل مصفوفة نقاط الخط لتحريك نقطة النهاية.

في ملف الإدخال، الفهرس 0 هو أمر البداية والفهرس 1 هو الخط. استبدال النقطة الوحيدة للخط يغيّر وجهته دون تغيير نوع الأمر أو توقيته أو موضعه في المجموعة. بما أن الأمر يستخدم إحداثيات مطلقة، فإن الزوج الجديد يحدد موضعًا وليس إزاحة مضافة.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new PointF[] { new PointF(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

الخط في `motion-endpoint.pptx` ينتهي عند (0.4, 0.1)؛ الملف الأصلي يظل دون تغيير.

### **استبدال مقطع**

استخدم [insert](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imotionpath/#insert-int-int-android.graphics.PointF---int-boolean-) و[removeAt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imotionpath/#removeAt-int-) لاستبدال الخط في `motion.pptx`. يؤدي الإدراج إلى إزاحته إلى الفهرس 2.

يوضح هذا استبدال كائن أمر بدلاً من تحرير إحداثياته الحالية. بعد الإدراج، تحتوي المجموعة مؤقتًا على أمر البداية، الخط الجديد، الخط القديم، وأمر النهاية. إزالة الفهرس 2 تُهمل الخط القديم وتترك المسار الجديد في مكانه.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new PointF[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

المسار المحفوظ لا يزال يحتوي على ثلاثة أوامر، مع الخط الجديد ينتهي عند (0.2, 0.1) وأمر النهاية في الأخير.

## **تعديل والتحقق من سلوك موجود**

عندما يكون فهرس السلوك غير معروف، حدده بنوعه. يفتح هذا المثال `rotation.pptx`، يجد [IRotationEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/irotationeffect/)، يغيّر الزاوية، ويتحقق من القيمة المحفوظة بعد إعادة الفتح.

يسمح فحص النوع بتجاوز السلوكيات التي ليست دورانات. القراءة الثانية تُحمِّل الملف المحفوظ في كائن عرض تقديمي منفصل، بحيث تُقارن البيانات المستمرة بدلاً من القيمة المخزنة في الذاكرة. لا يزال هذا المثال يفترض أن التأثير المعروف هو الأول في التسلسل الرئيسي؛ اختيار سلوك حسب النوع لا يضمن العثور على التأثير الصحيح في عرض تقديمي عشوائي.

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

الناتج هو `Rotation preserved: true`. طبّق نمط فحص النوع نفسه على سلوكيات أخرى. للتحقق الكامل من الحفظ، قارن الشكل الهدف، التأثير، أنواع السلوكيات وترتيبها، التوقيت، وأوامر المسار. استخدم تسامحًا رقميًا للقيم ذات الفاصلة العائمة. لعرض تقديمي بترتيب رسوم متحركة غير معروف، راجع [قراءة رسوم متحركة الشكل](/slides/ar/androidjava/shape-animation/#read-shape-animations) لاستكشاف التسلسلات الرئيسية والتفاعلية.

## **ترتيب السلوكيات، الإعدادات المسبقة، والتشغيل**

الترتيب في [IBehaviorCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibehaviorcollection/) هو الترتيب المخزن لعمليات التأثير. ليس قائمة تشغيل تُجبر كل سلوك على الانتظار حتى يكتمل السابق. يُحدِّد التوقيت والتأثير المحيط الجدولة. يمكن أن تتداخل السلوكيات، وقد تتفاعل العمليات على نفس الخاصية عبر [getAdditive](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibehavior/#getAdditive--) و[getAccumulate](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibehavior/#getAccumulate--). لا تُعيد ترتيب المجموعة وحدها جدولة "تحريك، ثم دوران"؛ استخدم توقيتًا صريحًا أو تأثيرات منفصلة كما هو موضح في [رسوم المتحركة الشكلية](/slides/ar/androidjava/shape-animation/).

يُحدد [getType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ieffect/#getType--) و[getSubtype](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ieffect/#getSubtype--) للتأثير إعدادًا مسبقًا. لا يُعَدّ ذلك وصفًا كاملاً لشجرة السلوكيات المُعدَّلة. اختر الإعداد المسبق والنوع الفرعي قبل تخصيص السلوكيات: قد يعيد تغيير الإعداد المسبق بناء المجموعة ويتجاهل عملياتك المخصَّصة. على سبيل المثال، تغيير تأثير Spin مخصص إلى Fade قد يُستبدل سلوك الدوران بسلوكيات تعيين ومرشح. فحص المجموعة مرة أخرى بعد تغيير إعداد مسبق أو نوع فرعي. مسح سلوكيات الإعداد المسبق قد يزيل أيضًا عمليات الرؤية أو التهيئة التي يحتاجها الإعداد المسبق. الأمثلة تستخدم أشكالًا مرئية وتستبدل السلوكيات؛ لا تُعيد بناء كل تنفيذ لإعداد مسبق.

## **توافق الصيغ**

شجرة سلوكيات محفوظة لا تضمن تشغيلًا متطابقًا في كل عارض أو مُصدِّر. تحقق من البيانات المحفوظة والمخرجات المرسومة بشكل منفصل.

| الصيغة أو المخرجات | ما يجب التحقق منه |
| --- | --- |
| PPTX | استخدمها كالصيغة الأساسية لهذه الأمثلة. أعد فتحها للتحقق من شجرة السلوكيات القابلة للتحرير، ثم اختبر التشغيل في نسخة PowerPoint المستهدفة. |
| PPT | قد تختلف تمثيلات الباينري القديمة عن PPTX. اختبر دورة حفظ وإعادة فتح منفصلة وتشغيل؛ لا تستنتج الدعم لكل تركيبة مخصصة من نجاح PPTX فقط. |
| PDF, PNG, JPEG، وغيرها من صور الشرائح الثابتة | تحتوي على تمثيل ثابت للشريحة، لا على جدول زمني قابل للتشغيل أو إطار نهائي مضمون للرسوم المتحركة. |
| [HTML5](/slides/ar/androidjava/export-to-html5/) | يمكنه تشغيل الرسوم المتحركة المدعومة عندما يتم تمكين رسوم متحركة الشكل في خيارات التصدير. اختبر التركيبات المخصصة في المتصفح. |
| [GIF متحرك](/slides/ar/androidjava/convert-powerpoint-to-animated-gif/) | يخزن إطارات مُرسومة، لا سلوكيات قابلة للتحرير أو تفاعلات نقر. تحقق من الحركة المرسومة فعليًا. |
| [فيديو](/slides/ar/androidjava/convert-powerpoint-to-video/) | يرسم إطارات الرسوم المتحركة ويُشفِّرها كفيديو. الدعم محدود إلى [الرسوم المتحركة والتأثيرات المدعومة](/slides/ar/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects)؛ لا يتحول الأمر أو الأحداث التفاعلية إلى جدول زمني قابل للتحرير. |

## **الأسئلة الشائعة**

**لماذا يحتوي تأثيري على سلوكيات قبل أن أضيف أي شيء؟**  
إنشاء تأثير مُعرَّف مسبقًا قد يُنشئ عملياته الأساسية. افحصها قبل اتخاذ قرار إما بتمديد الإعداد المسبق أو استبدال سلوكياته.

**هل نقل سلوك إلى البداية يجعله يُشغَل أولًا؟**  
ليس بالضرورة. ترتيب المجموعة لا يُعوض عن التوقيت. تحقق من التأخيرات، المدد، والتفاعلات بين العمليات على نفس الخاصية.

**لماذا لا يحتوي أمر النهاية على نقاط؟**  
يُشير إلى نهاية المسار ولا يحتاج إلى إحداثيات. تحقق من مصفوفة نقاط فارغة عند فحص مسار مقروء من ملف.

**هل جولة ناجحة حفظ-إعادة فتح كافية لتأكيد التشغيل؟**  
لا. إعادة الفتح تُؤكِّد حفظ الخصائص التي فحصتها. اختبر مشغل عرض الشرائح أو تصدير الرسوم المتحركة منفصلًا لتأكيد سلوكه البصري.