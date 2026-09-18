---
title: إنشاء وتعديل سلوكيات الرسوم المتحركة المخصصة في .NET
linktitle: رسوم متحركة مخصصة
type: docs
weight: 151
url: /ar/net/custom-animation/
keywords:
- رسوم متحركة مخصصة
- سلوك الرسوم المتحركة
- مسار الحركة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء وفحص وتعديل سلوكيات الرسوم المتحركة المخصصة ومسارات الحركة القابلة للتحرير في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ .NET."
---
## **نظرة عامة**

تتيح سلوكيات الرسوم المتحركة المخصصة لك التحكم في العمليات الفردية داخل تأثير الرسوم المتحركة، مثل تغيير اللون، تدوير الشكل، أو اتباع مسار حركة قابل للتحرير. يوضح هذا الدليل كيفية إنشاء سلوكيات ودمجها، وضبط توقيتها، وفحص وتعديل الرسوم المتحركة الموجودة، والتحقق من بقاء خصائصها محفوظة بعد حفظ وإعادة فتح العرض التقديمي.

للتعرف على التأثيرات المحددة مسبقًا ومؤشرات النقر، راجع [رسوم المتحركة للأشكال](/slides/ar/net/shape-animation/).

## **فهم نموذج الرسوم المتحركة**

يتم تنظيم الرسوم المتحركة كــ **Timeline → Sequence → Effect → Behaviors**:

- يحتوي [Timeline](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseslide/timeline/) الخاص بالشريحة على السلسلة الرئيسية والسلاسل التفاعلية.
- يحتوي [ISequence](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/isequence/) على تأثيرات، وقد يستهدف أشكالًا مختلفة.
- يحدد [IEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ieffect/) الشكل المستهدف، الإعداد المسبق، النوع الفرعي، وتوقيت التأثير.
- يحتوي [IEffect.Behaviors](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ieffect/behaviors/) على العمليات التي تنفّذ التأثير: تغيير اللون، التحريك، الدوران، تعيين خاصية، وما إلى ذلك.

## **إنشاء سلوكيات فردية**

استدعِ [ISequence.AddEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/isequence/addeffect/) لإنشاء تأثير والوصول إلى مجموعة [Behaviors](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ieffect/behaviors/). يمكن للإعداد المسبق ملء هذه المجموعة تلقائيًا. احتفظ بعملياته عند توسيع الإعداد المسبق، أو استخدم [Clear](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ibehaviorcollection/clear/) عندما تريد استبدالها عمدًا.

[IBehaviorFactory](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ibehaviorfactory/) ينشئ الأنواع الثمانية للسلوك الموضحة أدناه. يتم تغطية الحركة في [إنشاء مسار حركة](#build-a-motion-path). كل مثال إنشاء هو برنامج كامل؛ أمثلة التحرير اللاحقة تشير إلى ملف الإخراج الذي تستخدمه.

### **الدوران**

استخدم [CreateRotationEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) لإنشاء دوران. يحدد [By](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/irotationeffect/by/) زاوية نسبية بالدرجات؛ يحدد [From](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/irotationeffect/from/) و[To](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/irotationeffect/to/) النقاط النهائية.

يبدأ المثال بتأثير Spin، ويستبدل عمليات الإعداد المسبق بسلوك دوران واحد، ويعطي هذا السلوك مدة ثانيتين. تعبر زاوية نسبية مقدار 90 درجة عن ربع دورة من التوجه الأصلي للشكل، لذا لا يلزم تحديد زاوية بدء صريحة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var rotation = factory.CreateRotationEffect();
rotation.By = 90f;
rotation.Timing.Duration = 2f;

effect.Behaviors.Add(rotation);

presentation.Save("rotation.pptx", SaveFormat.Pptx);
```

`rotation.pptx` يحتوي على شكل واحد وسلوك دوران واحد. تُستخدم المجموعة، التوقيت، وأمثلة تحرير الدوران أدناه هذا الملف.

### **التحجيم**

استخدم [CreateScaleEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) مع نسب X/Y: يصف [From](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/iscaleeffect/from/) و[To](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/iscaleeffect/to/) الحجم الابتدائي والنهائي، بينما يصف [By](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/iscaleeffect/by/) تغييرًا نسبيًا. هنا، 100 تعني الحجم الأصلي.

ينمو المثال كلا البعدين من 100% إلى 125% خلال ثانيتين. الحفاظ على نسب أفقية وعمودية متساوية يحافظ على نسب الشكل؛ نسب مختلفة ستُطيل بُعدًا أكثر من الآخر.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.From = new PointF(100, 100);
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

effect.Behaviors.Add(scale);

presentation.Save("scale.pptx", SaveFormat.Pptx);
```

### **اللون**

استخدم [CreateColorEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) لتغيير التعبئة من الأزرق إلى البرتقالي. [From](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/icoloreffect/from/) و[To](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/icoloreffect/to/) هما ألوان؛ [By](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/icoloreffect/by/) هو إزاحة لون. يحدد [IBehavior.Properties](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ibehavior/properties/) الخاصية التي تُجرى عليها الرسوم المتحركة.

تم تهيئة تعبئة الشكل الصلبة إلى اللون الأزرق، مطابقةً للون البدء في الرسوم المتحركة. اختيار خاصية لون التعبئة يخبر السلوك أي جزء من الشكل يُغيّر؛ نقاط اللون وحدها لا تحدد تلك الخاصية. تصف التأثير المحفوظ انتقالًا لمدة ثانيتين إلى البرتقالي.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Blue;

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var color = factory.CreateColorEffect();
color.Properties.Add(BehaviorProperty.FillColor);
color.From.Color = Color.Blue;
color.To.Color = Color.Orange;
color.Timing.Duration = 2f;

effect.Behaviors.Add(color);

presentation.Save("color.pptx", SaveFormat.Pptx);
```

### **الفلتر**

استخدم [CreateFilterEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) لاختيار مسح. يحدد [Type](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ifiltereffect/type/)، [Subtype](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ifiltereffect/subtype/)، و[Reveal](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ifiltereffect/reveal/) الفلتر، الاتجاه، وما إذا كان يُظهر أو يُخفي الشكل.

يضبط هذا المثال مسحًا لمدة ثانيتين يكشف الشكل باستخدام النوع الفرعي باتجاه اليمين. إعدادات الفلتر تنتمي إلى السلوك داخل التأثير، لذا تُضبط بعد إزالة عمليات الإعداد المسبق الأصلية.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var filter = factory.CreateFilterEffect();
filter.Type = FilterEffectType.Wipe;
filter.Subtype = FilterEffectSubtype.Right;
filter.Reveal = FilterEffectRevealType.In;
filter.Timing.Duration = 2f;

effect.Behaviors.Add(filter);

presentation.Save("filter.pptx", SaveFormat.Pptx);
```

### **الخاصية**

استخدم [CreatePropertyEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) لتحريك الشفافية. [From](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ipropertyeffect/from/)، [To](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ipropertyeffect/to/)، و[By](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ipropertyeffect/by/) هي سلاسل تُفسّر باستخدام [ValueType](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ipropertyeffect/valuetype/) و[CalcMode](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ipropertyeffect/calcmode/). اختر نقاط النهاية أو إزاحة نسبية بدلاً من تعيين الثلاثة جميعًا بشكل عشوائي.

في هذا المثال، الخاصية المختارة هي الشفافية، والسلاسل العددية تمثل تغييرًا من شفافية 25% إلى شفافية كاملة. يصف الاستيفاء الخطي تغيّرًا تدريجيًا بين تلك القيم. عند تكييف هذا المثال لخاصية أخرى، اختر نوع قيمة وقيم نهائية مناسبة لتلك الخاصية.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var property = factory.CreatePropertyEffect();
property.Properties.Add(BehaviorProperty.StyleOpacity);
property.ValueType = PropertyValueType.Number;
property.CalcMode = PropertyCalcModeType.Linear;
property.From = "0.25";
property.To = "1";
property.Timing.Duration = 2f;

effect.Behaviors.Add(property);

presentation.Save("property.pptx", SaveFormat.Pptx);
```

### **التعيين**

استخدم [CreateSetEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ibehaviorfactory/createseteffect/) لتعيين الرؤية عبر [To](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/iseteffect/to/). لا يُجري سلوك التعيين استيفاءً بين النقاط النهائية.

يختار المثال خاصية الرؤية ويُعين السلسلة `visible` عند تشغيل السلوك. المستطيل مرئي بالفعل في هذا العرض التقديمي البسيط، لذا قد لا يُظهر التعيين تغييرًا بصريًا واضحًا بمفرده. يكون مثل هذا السلوك مفيدًا كجزء من تأثير أكبر يتحكم أيضًا في متى يصبح الشكل مخفيًا أو مرئيًا.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var set = factory.CreateSetEffect();
set.Properties.Add(BehaviorProperty.StyleVisibility);
set.To = "visible";

effect.Behaviors.Add(set);

presentation.Save("set.pptx", SaveFormat.Pptx);
```

### **الأمر**

استخدم [CreateCommandEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) واضبط [Type](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/icommandeffect/type/)، [CommandString](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/icommandeffect/commandstring/)، و[ShapeTarget](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/icommandeffect/shapetarget/). ضع ملف تسجيل WAV باسم `sample.wav` في دليل العمل. يدمج هذا المثال الملف باستخدام [AddAudioFrameEmbedded](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/addaudioframeembedded/) ويُرفق أمر تشغيل بإطار الصوت.

إطار الصوت هو هدف كل من التأثير والأمر. يربط ذلك طلب التشغيل بالتسجيل المضمّن؛ سلسلة الأوامر وحدها لا تحدد كائن الوسائط الذي يجب التحكم فيه. يُضبط التأثير للبدء عند النقر أثناء عرض الشرائح.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("sample.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

var effect = slide.Timeline.MainSequence.AddEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var command = factory.CreateCommandEffect();
command.Type = CommandEffectType.Call;
command.CommandString = "play";
command.ShapeTarget = audioFrame;

effect.Behaviors.Add(command);

presentation.Save("command.pptx", SaveFormat.Pptx);
```

يحفظ الأمر في `command.pptx`؛ لا يُشغل التسجيل. يتطلّب التشغيل مشغل عروض شرائح يدعم الأمر وهدف الوسائط الخاص به.

## **إدارة مجموعة السلوكيات**

[IBehaviorCollection](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ibehaviorcollection/) تدعم [Add](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ibehaviorcollection/add/)، [Insert](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ibehaviorcollection/insert/)، [Remove](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ibehaviorcollection/remove/)، و[RemoveAt](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ibehaviorcollection/removeat/). يفتح هذا المثال `rotation.pptx`، يضيف تحجيمًا، ينقله قبل الدوران، ويزيل الدوران. يحذف وإعادة إدراج نفس الكائن يغيّر موقعه المخزن دون إنشاء نسخة.

تغيّر سلسلة التعديلات المجموعة من دوران–تحجيم إلى تحجيم–دوران، ثم إلى تحجيم فقط. تُشير الفهارس إلى المجموعة الحالية، لذا يستخدم الإزالة فهرس الدوران الجديد بعد إعادة الترتيب. يؤكد العد النهائي أي سلوك سيتم حفظه.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var behaviors = effect.Behaviors;

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

behaviors.Add(scale);

behaviors.Remove(scale);
behaviors.Insert(0, scale);
behaviors.RemoveAt(1);

foreach (var behavior in behaviors)
    Console.WriteLine(behavior.GetType().Name);

presentation.Save("collection-edited.pptx", SaveFormat.Pptx);
```

الناتج هو `ScaleEffect`: يبقى فقط التحجيم. لا يحدد ترتيب المجموعة، بحد ذاته، جدولة السلوكيات واحدة بعد الأخرى. امسح المجموعة فقط عندما تستبدل جميع عملياتها.

## **ضبط توقيت السلوك**

[IBehavior.Timing](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ibehavior/timing/) يكشف عن [ITiming](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/)، بشكل مستقل عن [IEffect.Timing](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ieffect/timing/). يحدد توقيت التأثير جدول التأثير المُحاط؛ يصف توقيت السلوك عملية داخل هذا التأثير.

### **تحديد المدة، التأخير، التكرار، والتسارع**

افتح `rotation.pptx` واضبط [Duration](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/duration/) و[TriggerDelayTime](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/triggerdelaytime/) بالثواني، ثم اضبط [RepeatCount](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/repeatcount/). [Accelerate](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/accelerate/) و[Decelerate](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/decelerate/) هما كسور من المدة؛ احرص على أن لا يتجاوز مجموعهما 1.

الملف الإدخالي هو الملف الذي تم إنشاؤه في مثال الدوران، حيث يُعرف أن السلوك الأول هو دوران. يغيّر هذا المثال توقيت ذلك السلوك فقط؛ تبقى زاوية 90 درجة كما هي. يبسط فصل الزاوية عن التوقيت تعديل السرعة دون الحاجة لإعادة إنشاء الرسوم المتحركة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var rotation = (IRotationEffect)effect.Behaviors[0];
rotation.Timing.Duration = 2f;
rotation.Timing.TriggerDelayTime = 0.5f;
rotation.Timing.RepeatCount = 3f;
rotation.Timing.Accelerate = 0.2f;
rotation.Timing.Decelerate = 0.2f;

presentation.Save("timing.pptx", SaveFormat.Pptx);
```

يستخدم السلوك مدة ثانيتين، تأخير نصف ثانية، وعدد تكرار 3. تُستَخدم أول 20% وآخر 20% من مدته للتسارع والتباطؤ.

تشمل سياسات التكرار الأخرى [RepeatDuration](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/repeatduration/)، [RepeatUntilEndSlide](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/repeatuntilendslide/)، و[RepeatUntilNextClick](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/repeatuntilnextclick/); اختر سياسة واحدة بدلاً من تمكينها جميعًا معًا. [AutoReverse](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/autoreverse/) يُعيد تشغيل الرسوم المتحركة بالعكس بعد المرور الأمامي. يُطبق التسارع والتباطؤ على التغييرات المستمرة، لا على التعيينات أو الأوامر المتقطعة.

## **إنشاء مسار حركة**

استخدم [CreateMotionEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) لإنشاء حركة. يصف [From](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/imotioneffect/from/)، [To](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/imotioneffect/to/)، و[By](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/imotioneffect/by/) إحداثيات أو إزاحات بنسسب مئوية. لإنشاء مسار قابل للتحرير، أنشئ [MotionPath](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/motionpath/) وعينه إلى [IMotionEffect.Path](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/imotioneffect/path/). يخزن [IMotionPath](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/imotionpath/) أوامر المسار.

[MotionCommandPathType](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/motioncommandpathtype/) يحدد العملية:

| الأمر | النقاط | المعنى |
| --- | --- | --- |
| MoveTo | واحدة | تعيين موضع البداية. |
| LineTo | واحدة | الانتقال على مقطع مستقيم إلى نقطة النهاية. |
| CurveTo | ثلاث | اتباع منحنى مكعب يحدده نقطتا تحكم ونقطة النهاية. |
| CloseLoop | لا شيء | العودة إلى موضع البداية. |
| End | لا شيء | إنهاء المسار. |

[MotionPathPointsType](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/motionpathpointstype/) يصف خصائص تحرير النقاط، مثل النقاط الزاوية أو السلسة. لا يحل محل نوع الأمر. استخدم نوع نقطة المنحنى للمثال المنحنى أدناه، ونوع نقطة الزاوية للمقاطع المستقيمة.

إحداثيات المسار مُعّادة إلى أبعاد الشريحة: إزاحة X مقدارها 0.25 تمثل ربع عرض الشريحة، ليست 0.25 نقطة. القيم الموجبة لـ Y تتجه للأسفل. الأوامر المطلقة تحدد مواضع في نظام إحداثيات المسار؛ الأوامر النسبية تحدد إزاحات من الموضع الحالي. هذا منفصل عن [Origin](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/imotioneffect/origin/)، الذي يختار إطار مرجعي للمسار، و[PathEditMode](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/imotioneffect/patheditmode/)، الذي يتحكم في كيفية تحرك المسار عندما يُحرك الشكل.

### **إنشاء مسار مستقيم**

أنشئ سلوك حركة بنقطة بداية، مقطع مستقيم واحد، وأمر نهاية. يأخذ [IMotionPath.Add](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/imotionpath/add/) نوع الأمر، نقاطه، نوع النقطة، وعلم الإحداثيات النسبية.

يحدد الأمر الابتدائي (0, 0)، وتنتهي الخط إلى (0.25, 0)، مما يمنح الطريق إزاحة أفقية ربع عرض الشريحة. لا يحتوي أمر النهاية على نقاط إحداثية. بمجرد تعيين المسار، يضيف سلوك الحركة إلى التأثير وربط هذا الطريق بالمستطيل.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var motion = factory.CreateMotionEffect();
motion.Origin = MotionOriginType.Layout;
motion.Timing.Duration = 2f;

var path = new MotionPath();
path.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
path.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
path.Add(MotionCommandPathType.End, Array.Empty<PointF>(), MotionPathPointsType.None, false);

motion.Path = path;
effect.Behaviors.Add(motion);

presentation.Save("motion.pptx", SaveFormat.Pptx);
```

`motion.pptx` يحتوي على سلوك حركة واحد بثلاثة أوامر مسار. تستخدم أمثلة تحرير الملفات التالية هذا الهيكل المعروف.

### **مقارنة الإحداثيات المطلقة والنسبية**

هذان الكائنان يصفان نفس الطريق. ينتهي الأمر المطلق عند (0.3, 0.1)؛ يضيف الأمر النسبي (0.1, 0.1) إلى الموضع الحالي، (0.2, 0).

كلا المسارين يبدأان من نفس الموضع. للخط النسبي، أضف إزاحتي X وY إلى الموضع الحالي للحصول على نقطة النهاية؛ للخط المطلق، اقرأ نقطة النهاية مباشرة. تغيير العلم دون تحويل الإحداثيات سيؤدي إلى وصف طريق مختلف.

```csharp
using System.Drawing;
using Aspose.Slides.Animation;

var absolutePath = new MotionPath();
absolutePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

var relativePath = new MotionPath();
relativePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

عيّن أي من المسارين إلى سلوك حركة لاستخدامه في عرض تقديمي. يحدد الوسيط البولياني الأخير الإحداثيات النسبية لذلك الأمر.

### **استبدال خط بمنحنى**

افتح `motion.pptx` واستبدل أمر الخط بمنحنى مكعب. قدّم أولاً نقطتي التحكم، ثم نقطة النهاية.

توفر الأمر السابق الموضع الابتدائي. تشكّل أول نقطتين المنحنى، بينما الثالثة هي وجهتها؛ ليست ثلاث وجهات متتالية. يضمن تحديث نوع الأمر، نوع تحرير النقاط، ومصفوفة النقاط معًا توافق المقطع مع هندسته الجديدة.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path[1].CommandType = MotionCommandPathType.CurveTo;
path[1].PointsType = MotionPathPointsType.CurveSmooth;
path[1].Points = new[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) };

presentation.Save("curve.pptx", SaveFormat.Pptx);
```

المسار في `curve.pptx` لا يزال يضم ثلاثة أوامر؛ أمره الأوسط يعرّف الآن منحنى.

## **فحص وتحرير مسار محفوظ**

يُظهر كل [IMmotionCmdPath](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/imotioncmdpath/) [Points](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/imotioncmdpath/points/)، [CommandType](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/imotioncmdpath/commandtype/)، [PointsType](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/imotioncmdpath/pointstype/)، و[IsRelative](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/imotioncmdpath/isrelative/). تستخدم الأمثلة التالية المسار المكون من ثلاثة أوامر في `motion.pptx`. بالنسبة لأي مدخل عشوائي، حدّد التأثير المقصود وتحقق من أنواع الأوامر وعدد النقاط قبل التحرير حسب الفهرس.

### **قراءة الأوامر والإحداثيات**

اقرأ المسار دون تغييره. لا تحتاج أوامر End وCloseLoop إلى نقاط، لذا يجب السماح بمصفوفة نقاط فارغة.

تُظهر النتيجة كل أمر مع علم إحداثياته النسبية قبل سرد نقاطه. يتيح لك ذلك التمييز بين نقطة النهاية وإزاحة قبل تعديل المسار. المنحنى سيُظهر ثلاث نقاط، بينما الخط المستقيم في هذا الملف يُظهر نقطة واحدة فقط.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
foreach (var segment in path)
{
    Console.WriteLine($"{segment.CommandType}, relative: {segment.IsRelative}");
    if (segment.Points != null)
        foreach (var point in segment.Points)
            Console.WriteLine($"X={point.X}, Y={point.Y}");
}
```

القائمة تحتوي على نقطة بدء، خط مطلق ينتهي عند (0.25, 0)، وأمر End.

### **تغيير نقطة النهاية**

افتح `motion.pptx` واستبدل مصفوفة نقاط الخط لتحريك نقطة النهاية.

في الملف الإدخالي، الفهرس 0 هو الأمر الابتدائي والفهرس 1 هو الخط. استبدال النقطة الوحيدة للخط يغيّر وجهته دون تغيير نوع الأمر أو توقيته أو موقعه في المجموعة. لأن الأمر يستخدم إحداثيات مطلقة، فإن الزوج الجديد يحدد موضعًا وليس إزاحة مضافة.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var motion = (IMotionEffect)effect.Behaviors[0];
motion.Path[1].Points = new[] { new PointF(0.4f, 0.1f) };

presentation.Save("motion-endpoint.pptx", SaveFormat.Pptx);
```

الخط في `motion-endpoint.pptx` ينتهي عند (0.4, 0.1)؛ الملف الأصلي يبقى دون تغيير.

### **استبدال مقطع**

استخدم [Insert](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/imotionpath/insert/) و[RemoveAt](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/imotionpath/removeat/) لاستبدال الخط في `motion.pptx`. يؤدي الإدراج إلى إزاحة الخط القديم إلى الفهرس 2.

يظهر هذا استبدال كائن أمر بدلاً من تحرير إحداثياته الحالية. بعد الإدراج، تحتوي المجموعة مؤقتًا على الأمر الابتدائي، الخط الجديد، الخط القديم، وأمر End. يحذف إزالة الفهرس 2 الخط القديم ويترك الطريق الجديد في مكانه.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path.Insert(1, MotionCommandPathType.LineTo, new[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
path.RemoveAt(2);

presentation.Save("motion-edited.pptx", SaveFormat.Pptx);
```

المسار المحفوظ لا يزال يحتوي على ثلاثة أوامر، حيث ينتهي الخط الجديد عند (0.2, 0.1) وأمر End هو الأخير.

## **تعديل والتحقق من سلوك موجود**

عند عدم معرفة فهرس السلوك، حدده بالنوع. يفتح هذا المثال `rotation.pptx`، يجد [IRotationEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/irotationeffect/)، يغيّر الزاوية، ويتحقق من القيمة المحفوظة بعد إعادة الفتح.

يتيح فحص النوع تخطي السلوكيات التي ليست دورانًا. يقرأ التحميل الثاني الملف المحفوظ إلى كائن عرض تقديمي منفصل، لذا تتحقق المقارنة من البيانات المستمرة بدلاً من القيمة المتبقية في الذاكرة. لا يزال هذا المثال يفترض أن التأثير المعروف هو الأول في السلسلة الرئيسية؛ تحديد السلوك بالنوع لا يضمن العثور على التأثير الصحيح في عرض تقديمي عشوائي.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in effect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        rotation.By = 180f;
}

presentation.Save("rotation-edited.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("rotation-edited.pptx");
var savedEffect = reopened.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in savedEffect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        Console.WriteLine($"Rotation preserved: {Math.Abs(rotation.By - 180f) < 0.001f}");
}
```

الناتج هو `Rotation preserved: True`. طبّق نمط فحص النوع نفسه على سلوكيات أخرى. لفحص حفظ كامل، قارن الشكل المستهدف، التأثير، أنواع السلوكيات وترتيبها، التوقيت، وأوامر المسار. استخدم تسامحًا عدديًا للقيم العائمة. لعروض تقديمية ذات تخطيط رسوم متحركة غير معروف، راجع [قراءة رسوم المتحركة للأشكال](/slides/ar/net/shape-animation/#read-shape-animations) لت traversing السلاسل الرئيسية والتفاعلية.

## **ترتيب السلوكيات، الإعدادات المسبقة، والتشغيل**

الترتيب في [IBehaviorCollection](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ibehaviorcollection/) هو الترتيب المخزن لعمليات التأثير. ليس قائمة تشغيل ينتظر كل سلوك فيها السلوك السابق تلقائيًا. يحدد التوقيت والتأثير المحيط الجدولة. يمكن أن تتداخل السلوكيات، وقد تتفاعل العمليات على الخاصية نفسها عبر [Additive](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ibehavior/additive/) و[Accumulate](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ibehavior/accumulate/). لا تستخدم إعادة ترتيب المجموعة بمفردها لجدولة “تحريك، ثم دوران”; استخدم توقيتًا صريحًا أو تأثيرات منفصلة كما هو موضح في [رسوم المتحركة للأشكال](/slides/ar/net/shape-animation/).

يصف [Type](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ieffect/type/) و[Subtype](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ieffect/subtype/) التأثير إعداداً مسبقًا. ليسا وصفًا كاملاً لشجرة سلوكيات مُعدّلة. اختر الإعداد المسبق والنوع الفرعي قبل تخصيص السلوكيات: قد يُعيد تغيير الإعداد المسبق بناء المجموعة ويقضي على عملياتك المخصصة. على سبيل المثال، قد يستبدل تغيير تأثير Spin مخصص إلى Fade سلوك الدوران بسلوكيات تعيين وفلتر. افحص المجموعة مرة أخرى بعد تغيير إعداد مسبق أو نوع فرعي. قد يؤدي مسح سلوكيات الإعداد المسبق أيضًا إلى إزالة عمليات الرؤية أو التهيئة التي يحتاجها الإعداد المسبق. تستخدم الأمثلة أشكالًا مرئية وتستبدل السلوكيات؛ لا تعيد بناء تنفيذ كل إعداد مسبق.

## **توافق الصيغ**

شجرة سلوكيات محفوظة لا تضمن تشغيلًا متطابقًا في كل عارض أو مُصدِّر. تحقق من البيانات المحفوظة والإخراج المُصوَّر بشكل منفصل.

| الصيغة أو الإخراج | ما يجب التحقق منه |
| --- | --- |
| PPTX | استخدم كصيغة أساسية لهذه الأمثلة. أعد فتحه للتحقق من شجرة السلوكيات القابلة للتحرير، ثم افحص التشغيل في إصدار PowerPoint المستهدف. |
| PPT | قد يختلف التمثيل الثنائي legacy عن PPTX. نفّذ دورة حفظ وإعادة فتح منفصلة واختبر التشغيل؛ لا تستنتج دعم كل تركيبة مخصصة من نجاح إخراج PPTX. |
| PDF, PNG, JPEG, وصور شرائح ثابتة أخرى | تحتوي على تمثيل شريحة ثابت، لا جدول سلوكيات قابل للتشغيل ولا إطار نهائي مضمون للرسوم المتحركة. |
| [HTML5](/slides/ar/net/export-to-html5/) | يمكنه تشغيل الرسوم المتحركة المدعومة عندما يُفعَّل خيار رسوم المتحركة للأشكال في خيارات التصدير. اختبر التركيبات المخصصة في المتصفح. |
| [Animated GIF](/slides/ar/net/convert-powerpoint-to-animated-gif/) | يخزن الإطارات المُصوَّرة، لا السلوكيات القابلة للتحرير أو التفاعلات المستندة إلى النقر. تحقق من الحركة الفعلية المُصوَّرة. |
| [Video](/slides/ar/net/convert-powerpoint-to-video/) | يُصوِّر إطارات الرسوم المتحركة ويُشفِّرها كفيديو. الدعم محدود إلى [الرسوم المتحركة والتأثيرات المدعومة](/slides/ar/net/convert-powerpoint-to-video/#supported-animations-and-effects); لا تتحول الأوامر والأحداث التفاعلية إلى جدول زمني قابل للتحرير. |

## **الأسئلة الشائعة**

**لماذا يحتوي التأثير على سلوكيات قبل أن أضيف أي شيء؟**

إن إنشاء تأثير مُحدد مسبقًا قد يُنشئ عملياته الأساسية. افحصها قبل أن تقرّر توسيع الإعداد المسبق أو استبدال سلوكياته.

**هل يجعل نقل سلوك إلى البداية تشغيله أولاً؟**

ليس بالضرورة. ترتيب المجموعة ليس بديلاً عن التوقيت. تحقق من التأخيرات، المدّات، والتفاعلات بين العمليات على الخاصية نفسها.

**لماذا لا يحتوي أمر End على نقاط؟**

يُحدِّد نهاية المسار ولا يحتاج إلى إحداثيات. تحقق من مصفوفة نقاط فارغة عند فحص مسار مقروء من ملف.

**هل جولة كاملة ناجحة كافية لتأكيد التشغيل؟**

لا. إعادة الفتح تؤكد حفظ الخصائص التي فحصتها. اختبر مشغل الشرائح أو التصدير المتحرك بشكل منفصل لتأكيد سلوكه البصري.