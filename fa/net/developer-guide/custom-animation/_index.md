---
title: ایجاد و اصلاح رفتارهای سفارشی انیمیشن در .NET
linktitle: انیمیشن سفارشی
type: docs
weight: 151
url: /fa/net/custom-animation/
keywords:
- انیمیشن سفارشی
- رفتار انیمیشن
- مسیر حرکتی
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "ایجاد، بررسی و اصلاح رفتارهای سفارشی انیمیشن و مسیرهای حرکتی قابل ویرایش در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای .NET."
---
## **بررسی کلی**

رفتارهای سفارشی انیمیشن به شما امکان کنترل عملیات فردی در یک اثر انیمیشن را می‌دهند، مانند تغییر رنگ، چرخاندن یک شکل یا دنبال کردن مسیر حرکتی قابل ویرایش. این راهنما نحوه ایجاد و ترکیب رفتارها، پیکربندی زمان‌بندی آن‌ها، بررسی و اصلاح انیمیشن‌های موجود، و اطمینان از حفظ ویژگی‌های آن‌ها پس از ذخیره و بازگشایی یک ارائه را نشان می‌دهد.

برای اثرهای پیش‌تعریف‌شده و واکنش‌های کلیک، به [انیمیشن شکل](/slides/fa/net/shape-animation/) مراجعه کنید.

## **درک مدل انیمیشن**

یک انیمیشن به صورت **Timeline → Sequence → Effect → Behaviors** سازماندهی می‌شود:

- **Timeline** اسلاید ([Timeline](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseslide/timeline/)) شامل توالی اصلی و توالی‌های تعاملی آن است.
- **Sequence** یک [ISequence](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/isequence/) است که اثرها را شامل می‌شود و ممکن است به شکل‌های مختلفی هدف بگیرد.
- **Effect** یک [IEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ieffect/) است که شکل هدف، پیش‌تنظیم، زیرنوع و زمان‌بندی اثر را شناسایی می‌کند.
- **Behaviors** در [IEffect.Behaviors](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ieffect/behaviors/) شامل عملیات‌هایی است که اثر را پیاده‌سازی می‌کنند: تغییر رنگ، جابجا شدن، چرخش، تنظیم یک ویژگی و غیره.

## **ایجاد رفتارهای تک‌تک**

برای ایجاد یک اثر و دسترسی به مجموعهٔ [Behaviors](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ieffect/behaviors/) آن، از [ISequence.AddEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/isequence/addeffect/) استفاده کنید. یک پیش‌تنظیم می‌تواند این مجموعه را به‌صورت خودکار پر کند. هنگام گسترش پیش‌تنظیم، عملیات آن را نگه دارید یا هنگام جایگزینی عمداً از [Clear](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ibehaviorcollection/clear/) استفاده کنید.

[IBehaviorFactory](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ibehaviorfactory/) هشت نوع رفتار را که در ادامه نشان داده می‌شود ایجاد می‌کند. مسیر حرکتی در بخش [ساخت مسیر حرکتی](#build-a-motion-path) پوشش داده شده است. هر مثال ساخت یک برنامه کامل است؛ مثال‌های ویرایشی بعدی مشخص می‌کنند که از کدام فایل خروجی استفاده می‌شود.

### **چرخش**

برای ایجاد یک چرخش از [CreateRotationEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) استفاده کنید. متد [By](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/irotationeffect/by/) زاویه نسبی را برحسب درجه مشخص می‌کند؛ [From](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/irotationeffect/from/) و [To](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/irotationeffect/to/) نقاط انتهایی را تعریف می‌کنند.

مثال با یک اثر Spin شروع می‌شود، عملیات پیش‌تنظیم آن را با یک رفتار چرخش جایگزین می‌کند و به آن مدت زمان دو ثانیه می‌دهد. یک زاویه نسبی ۹۰ درجه، یک چرخش یک‌چهارم‌دور از جهت ابتدایی شکل است، بنابراین نیازی به زاویهٔ شروع صریح نیست.

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

`rotation.pptx` شامل یک شکل و یک رفتار چرخش است. مجموعه، زمان‌بندی و مثال‌های ویرایش چرخش در ادامه از این فایل استفاده می‌کنند.

### **مقیاس**

از [CreateScaleEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) با درصدهای X/Y استفاده کنید: [From](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/iscaleeffect/from/) و [To](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/iscaleeffect/to/) به ترتیب اندازهٔ شروع و پایان را توصیف می‌کنند، در حالی که [By](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/iscaleeffect/by/) تغییر نسبی را توصیف می‌کند. در اینجا، ۱۰۰ به معنی اندازهٔ اصلی است.

مثال هر دو بعد را از ۱۰۰٪ به ۱۲۵٪ در طول دو ثانیه افزایش می‌دهد. استفاده از درصدهای مساوی افقی و عمودی نسبت شکل را حفظ می‌کند؛ درصدهای متفاوت یک بعد را نسبت به دیگری کشیده می‌کنند.

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

### **رنگ**

برای تغییر پر از آبی به نارنجی از [CreateColorEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) استفاده کنید. [From](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/icoloreffect/from/) و [To](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/icoloreffect/to/) رنگ‌ها هستند؛ [By](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/icoloreffect/by/) یک جابجایی رنگی است. [IBehavior.Properties](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ibehavior/properties/) ویژگی‌ ای که انیمیشن می‌شود را شناسایی می‌کند.

پر جامد شکل به رنگ آبی مقداردهی اولیه می‌شود تا با رنگ شروع انیمیشن منطبق باشد. انتخاب ویژگی fill-color به رفتار می‌گوید کدام بخش شکل تغییر کند؛ خود رنگ‌های انتهایی این ویژگی را مشخص نمی‌کنند. اثر ذخیره‌شده یک انتقال دو ثانیه‌ای به نارنجی توصیف می‌کند.

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

### **فیلتر**

برای انتخاب یک پاک‌کن (wipe) از [CreateFilterEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) استفاده کنید. [Type](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ifiltereffect/type/)، [Subtype](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ifiltereffect/subtype/) و [Reveal](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ifiltereffect/reveal/) به ترتیب فیلتر، جهت و اینکه شکل را نشان یا مخفی کند، مشخص می‌کنند.

این مثال یک پاک‌کن دو ثانیه‌ای که با جهت راست (right-direction) شکل را نشان می‌دهد پیکربندی می‌کند. تنظیمات فیلتر جزو رفتار داخل اثر هستند، بنابراین پس از حذف عملیات اصلی پیش‌تنظیم، تنظیم می‌شوند.

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

### **ویژگی**

برای انیمیشن شفافیت (opacity) از [CreatePropertyEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) استفاده کنید. [From](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ipropertyeffect/from/)، [To](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ipropertyeffect/to/) و [By](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ipropertyeffect/by/) رشته‌هایی هستند که با استفاده از [ValueType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ipropertyeffect/valuetype/) و [CalcMode](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ipropertyeffect/calcmode/) تفسیر می‌شوند. به جای تنظیم سه مقدار به‌هم‌تن بصورت هم‌زمان، یا نقاط انتهایی یا یک جابجایی نسبی را انتخاب کنید.

در اینجا، ویژگی انتخاب‌شده opacity است و رشته‌های عددی تغییر از ۲۵٪ شفافیت به شفافیت کامل را نشان می‌دهند. درون‌یابی خطی یک تغییر تدریجی بین این مقادیر توصیف می‌کند. هنگام اعمال این مثال به ویژگی دیگری، نوع مقدار و مقادیر نقاط انتهایی متناسب با آن ویژگی را انتخاب کنید.

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

### **تنظیم (Set)**

برای اختصاص حالت نمایش از [CreateSetEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ibehaviorfactory/createseteffect/) و [To](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/iseteffect/to/) استفاده کنید. یک رفتار Set بین نقاط انتهایی درون‌یابی نمی‌شود.

مثال ویژگی visibility را انتخاب می‌کند و رشتهٔ `visible` را هنگام اجرای رفتار اختصاص می‌دهد. مستطیل در این ارائهٔ حداقلی از قبل قابل مشاهده است، بنابراین این انتساب ممکن است به تنهایی تغییر بصری واضحی نداشته باشد. چنین عملیاتی به عنوان بخشی از یک اثر بزرگتر مفید است که زمان نمایش یا مخفی شدن شکل را نیز کنترل می‌کند.

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

### **دستور (Command)**

از [CreateCommandEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) استفاده کنید و [Type](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/icommandeffect/type/)، [CommandString](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/icommandeffect/commandstring/) و [ShapeTarget](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/icommandeffect/shapetarget/) را پیکربندی کنید. یک فایل صوتی WAV به نام `sample.wav` را در پوشهٔ کاری قرار دهید. این مثال آن را با [AddAudioFrameEmbedded](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/addaudioframeembedded/) جاسازی می‌کند و یک دستور پخش به فریم صوتی متصل می‌سازد.

فریم صوتی هم هدف اثر و هم هدف دستور است. این باعث می‌شود درخواست پخش به ضبط جاسازی‌شده متصل شود؛ یک رشتهٔ دستور به تنهایی مشخص نمی‌کند کدام شی رسانه‌ای کنترل شود. اثر برای شروع با کلیک در طول نمایش اسلاید تنظیم می‌شود.

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

ذخیره‌سازی دستور را در `command.pptx` ذخیره می‌کند؛ ضبط را پخش نمی‌کند. برای پخش نیاز به بازیکنی دارید که از این دستور و هدف رسانه‌ای آن پشتیبانی کند.

## **مدیریت مجموعهٔ رفتارها**

[IBehaviorCollection](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ibehaviorcollection/) از روش‌های [Add](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ibehaviorcollection/add/)، [Insert](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ibehaviorcollection/insert/)، [Remove](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ibehaviorcollection/remove/)، و [RemoveAt](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ibehaviorcollection/removeat/) پشتیبانی می‌کند. این مثال `rotation.pptx` را باز می‌کند، مقیاس‌بندی را اضافه می‌کند، قبل از چرخش جابجا می‌کند و چرخش را حذف می‌کند. حذف و دوباره‌درج همان شی باعث تغییر موقعیت ذخیره‌شده آن می‌شود بدون این که یک نسخهٔ دیگر ساخته شود.

دنبالهٔ ویرایش‌ها مجموعه را از rotation–scale به scale–rotation و سپس به فقط scale تغییر می‌دهد. ایندکس‌ها به مجموعهٔ فعلی اشاره دارند، بنابراین حذف از ایندکس جدید چرخش پس از بازآرایی انجام می‌شود. شمارش نهایی نشان می‌دهد کدام رفتار ذخیره خواهد شد.

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

خروجی `ScaleEffect` است: فقط مقیاس‌بندی باقی می‌ماند. ترتیب مجموعه به‌تنهایی رفتارها را یکی پس از دیگری زمان‌بندی نمی‌کند. هنگام جایگزینی تمام عملیات، از `Clear` استفاده کنید.

## **پیکربندی زمان‌بندی رفتار**

[IBehavior.Timing](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ibehavior/timing/) [ITiming](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/) را به‌صورت مستقل از [IEffect.Timing](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ieffect/timing/) در اختیار می‌گذارد. زمان‌بندی اثر کلان‌اثر را زمان‌بندی می‌کند؛ زمان‌بندی رفتار توصیف‌کنندهٔ یک عملیات داخل آن است.

### **تنظیم مدت زمان، تأخیر، تکرار و شتاب**

`rotation.pptx` را باز کنید و [Duration](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/duration/) و [TriggerDelayTime](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/triggerdelaytime/) را به ثانیه تنظیم کنید، سپس [RepeatCount](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/repeatcount/) را پیکربندی کنید. [Accelerate](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/accelerate/) و [Decelerate](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/decelerate/) کسری از مدت زمان هستند؛ مجموع آن‌ها نباید بیش از ۱ باشد.

فایل ورودی همان فایلی است که در مثال چرخش ایجاد شد و اولین رفتار آن یک چرخش است. این مثال فقط زمان‌بندی آن رفتار را تغییر می‌دهد؛ زاویهٔ ۹۰ درجه همان‌جا می‌ماند. جدا نگه داشتن زاویه و زمان‌بندی، تنظیم سرعت را بدون بازسازی کل انیمیشن آسان‌تر می‌کند.

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

این رفتار از یک مدت زمان دو ثانیه، تأخیر نیم ثانیه‌ای و تعداد تکرار ۳ استفاده می‌کند. ۲۰٪ اول و ۲۰٪ آخر مدت زمان برای شتاب و کاهش سرعت استفاده می‌شود.

سیاست‌های تکرار دیگر شامل [RepeatDuration](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/repeatduration/)، [RepeatUntilEndSlide](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/repeatuntilendslide/)، و [RepeatUntilNextClick](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/repeatuntilnextclick/) هستند؛ تنها یکی را انتخاب کنید نه همه را به‌هم. [AutoReverse](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/autoreverse/) پس از اجرای پیشرو، انیمیشن را به عقب می‌چرخاند. شتاب و کاهش سرعت برای تغییرات پیوسته اعمال می‌شود، نه برای انتساب‌های گسسته یا دستورات.

## **ساخت مسیر حرکتی**

از [CreateMotionEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) برای ایجاد حرکت استفاده کنید. متدهای [From](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/imotioneffect/from/)، [To](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/imotioneffect/to/) و [By](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/imotioneffect/by/) مختصات یا جابجایی‌های درصدی را توصیف می‌کنند. برای داشتن مسیر قابل ویرایش، یک [MotionPath](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/motionpath/) ایجاد کنید و به [IMotionEffect.Path](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/imotioneffect/path/) اختصاص دهید. [IMotionPath](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/imotionpath/) دستورات مسیر را ذخیره می‌کند.

[MotionCommandPathType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/motioncommandpathtype/) نوع عملیات را انتخاب می‌کند:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | تعیین موقعیت شروع. |
| LineTo | One | حرکت در طول یک قطعهٔ مستقیم تا نقطهٔ انتها. |
| CurveTo | Three | دنبال کردن یک منحنی مکعبی تعریف‌شده توسط دو نقطهٔ کنترل و یک نقطهٔ انتها. |
| CloseLoop | None | بازگشت به موقعیت شروع. |
| End | None | پایان مسیر. |

[MotionPathPointsType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/motionpathpointstype/) ویژگی‌های ویرایش نقطه‌ها را توصیف می‌کند، مانند نقطهٔ گوشه‌ای یا هموار. این نوع نقطه جایگزین نوع فرمان نمی‌شود. برای مثال منحنی زیر از نوع نقطهٔ منحنی استفاده کنید و برای قطعات مستقیم از نوع نقطهٔ گوشه‌ای.

مختصات مسیر نسبت به ابعاد اسلاید نرمال‌سازی می‌شوند: جابه‌جایی X برابر ۰٫۲۵ نشان‌دهندهٔ یک‌چهارم عرض اسلاید است، نه ۰٫۲۵ پیکسل. مقدار Y مثبت به سمت پایین است. دستورات مطلق موقعیت‌ها را در سامانهٔ مختصات مسیر مشخص می‌کنند؛ دستورات نسبی جابجایی نسبت به موقعیت فعلی را نشان می‌دهند. این موضوع جدا از [Origin](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/imotioneffect/origin/) است که چارچوب مرجع مسیر را انتخاب می‌کند، و [PathEditMode](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/imotioneffect/patheditmode/) که نحوهٔ جابه‌جایی مسیر هنگام جابه‌جایی شکل را کنترل می‌کند.

### **ساخت مسیر مستقیم**

یک رفتار حرکتی با نقطهٔ شروع، یک قطعهٔ مستقیم و یک دستور پایان ایجاد کنید. متد [IMotionPath.Add](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/imotionpath/add/) نوع فرمان، نقاط آن، نوع نقطه، و پرچم مختصات نسبی را می‌پذیرد.

دستور شروع (۰,۰) را تعیین می‌کند و خط به (۰٫۲۵, ۰) ختم می‌شود که مسیر یک جابجایی افقی یک‌چهارم عرض اسلاید می‌شود. دستور پایان هیچ نقطه‌ای ندارد. پس از اختصاص مسیر، افزودن رفتار حرکتی به اثر، این مسیر را به مستطیل متصل می‌کند.

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

`motion.pptx` شامل یک رفتار حرکتی با سه دستور مسیر است. مثال‌های ویرایشی زیر از این ساختار شناخته‌شده استفاده می‌کنند.

### **مقایسهٔ مختصات مطلق و نسبی**

این دو شیء مسیر همان مسیر را توصیف می‌کنند. دستور مطلق در (۰٫۳, ۰٫۱) پایان می‌یابد؛ دستور نسبی (۰٫۱, ۰٫۱) را به موقعیت فعلی (۰٫۲, ۰) اضافه می‌کند.

هر دو مسیر از همان موقعیت شروع می‌شوند. برای خط نسبی، مقادیر X و Y را به موقعیت فعلی اضافه می‌کنید تا نقطهٔ انتها به دست آید؛ برای خط مطلق، نقطهٔ انتها را مستقیماً می‌خوانید. تغییر پرچم بدون تبدیل مختصات مسیر متفاوتی تولید می‌کند.

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

هر یک از این مسیرها را به یک رفتار حرکتی اختصاص دهید تا در ارائه استفاده شوند. آرگومان بولی نهایی برای آن دستور، مختصات نسبی را انتخاب می‌کند.

### **جایگزینی یک خط با یک منحنی**

`motion.pptx` را باز کنید و دستور خط آن را با یک منحنی مکعبی جایگزین کنید. ابتدا دو نقطهٔ کنترل و سپس نقطهٔ انتها را فراهم کنید.

موقعیت شروع توسط دستور قبلی تأمین می‌شود. دو نقطهٔ اول منحنی را شکل می‌دهند، در حالی که نقطهٔ سوم مقصد نهایی است؛ این‌ها سه مقصد متوالی نیستند. به‌روز کردن نوع دستور، نوع نقطه‌ و آرایهٔ نقاط به طور همزمان، قطعه را با هندسهٔ جدید سازگار نگه می‌دارد.

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

در `curve.pptx` مسیر هنوز سه دستور دارد؛ دستور میانی اکنون یک منحنی را تعریف می‌کند.

## **بررسی و ویرایش یک مسیر ذخیره‌شده**

هر [IMotionCmdPath](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/imotioncmdpath/) ویژگی‌های [Points](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/imotioncmdpath/points/)، [CommandType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/imotioncmdpath/commandtype/)، [PointsType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/imotioncmdpath/pointstype/) و [IsRelative](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/imotioncmdpath/isrelative/) را نشان می‌دهد. مثال‌های زیر از مسیر سه‑دستوری شناخته‌شده در `motion.pptx` استفاده می‌کنند. برای ورودی‌های دلخواه، قبل از ویرایش با اندیس، اثر مورد نظر را پیدا کنید و نوع دستورها و تعداد نقاط را بررسی کنید.

### **خواندن دستورات و مختصات**

مسیر را بدون تغییر بخوانید. دستورات End و CloseLoop نیازی به نقطه ندارند، بنابراین آرایهٔ نقطهٔ تهی را در نظر بگیرید.

خروجی هر دستور را با پرچم مختصات نسبی قبل از فهرست نقاط نشان می‌دهد. این امکان را می‌دهد که قبل از ویرایش مسیر، تشخیص دهید که نقطهٔ انتها است یا جابجایی. یک منحنی سه نقطه را فهرست می‌کند، در حالی که خط مستقیم در این فایل تنها یک نقطه دارد.

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

فهرست شامل یک نقطهٔ شروع، یک خط مطلق به (۰٫۲۵, ۰) و یک دستور End است.

### **تغییر نقطهٔ انتها**

`motion.pptx` را باز کنید و آرایهٔ نقاط خط را برای جابجایی نقطهٔ انتها جایگزین کنید.

در فایل ورودی، اندیس ۰ دستور شروع و اندیس ۱ خط است. جایگزینی نقطهٔ تک خط، مقصد آن را بدون تغییر نوع دستور، زمان‌بندی یا موقعیت در مجموعه تغییر می‌دهد. چون دستور از مختصات مطلق استفاده می‌کند، جفت جدید یک موقعیت را نشان می‌دهد نه یک جابجایی افزایشی.

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

خط در `motion-endpoint.pptx` به (۰٫۴, ۰٫۱) پایان می‌یابد؛ فایل اصلی تغییر نکرده است.

### **جایگزینی یک قطعه**

از [Insert](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/imotionpath/insert/) و [RemoveAt](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/imotionpath/removeat/) برای جایگزینی خط در `motion.pptx` استفاده کنید. درج خط جدید باعث می‌شود خط قدیمی به اندیس ۲ منتقل شود.

این نشان می‌دهد که یک شیء دستور را جایگزین می‌کنیم نه مختصات موجود آن را ویرایش می‌کنیم. پس از درج، مجموعه موقتاً شامل دستور شروع، خط جدید، خط قدیمی و دستور End می‌شود. حذف اندیس ۲ خط قدیمی را حذف می‌کند و مسیر جدید جای خود را می‌گیرد.

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

مسیر ذخیره‌شده هنوز سه دستور دارد؛ خط جدید به (۰٫۲, ۰٫۱) پایان می‌یابد و دستور End در انتهاست.

## **تعديل و تأیید یک رفتار موجود**

وقتی ایندکس رفتار ناشناخته باشد، آن را بر اساس نوع انتخاب کنید. این مثال `rotation.pptx` را باز می‌کند، [IRotationEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/irotationeffect/) را می‌یابد، زاویه را تغییر می‌دهد و پس از بازگشایی مجدد مقدار ذخیره‌شده را بررسی می‌کند.

بررسی نوع باعث می‌شود حلقه رفتارهایی که چرخش نیستند را نادیده بگیرد. بارگذاری دوم فایل ذخیره‌شده را به شیء ارائهٔ جداگانه‌ای می‌خواند، بنابراین مقایسه داده‌های حفظ‌شده نه مقدار در حافظه را می‌سنجد. این مثال همچنان فرض می‌کند اثر شناخته‌شده اولین اثر در توالی اصلی است؛ انتخاب رفتار بر اساس نوع لزوماً اثر درست را در یک ارائهٔ دلخواه پیدا نمی‌کند.

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

خروجی `Rotation preserved: True` است. الگوی بررسی نوع را برای رفتارهای دیگر نیز اعمال کنید. برای یک بررسی کامل حفظ، شکل هدف، اثر، انواع و ترتیب رفتارها، زمان‌بندی و دستورات مسیر را مقایسه کنید. برای ارائه‌ای با طرح انیمیشن ناشناخته، به [خواندن انیمیشن‌های شکل](/slides/fa/net/shape-animation/#read-shape-animations) برای پیمایش توالی‌های اصلی و تعاملی مراجعه کنید.

## **ترتیب رفتارها، پیش‌تنظیم‌ها و پخش**

ترتیب در [IBehaviorCollection](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ibehaviorcollection/) همان ترتیب ذخیره‌شدهٔ عملیات‌های یک اثر است. این یک لیست پخش نیست که هر رفتار به‌طور خودکار منتظر رفتار قبلی بماند. زمان‌بندی و اثر حاوی آن برنامه زمان‌بندی را تعیین می‌کند. رفتارها می‌توانند همپوشانی داشته باشند و عملیات‌های یک‌موردی می‌توانند از طریق [Additive](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ibehavior/additive/) و [Accumulate](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ibehavior/accumulate/) با هم تعامل داشته باشند. برای زمان‌بندی «جا به جایی، سپس چرخش» فقط با بازآرایی مجموعه کافی نیست؛ از زمان‌بندی صریح یا اثرهای جداگانه همان‌طور که در [انیمیشن شکل](/slides/fa/net/shape-animation/) توضیح داده شده استفاده کنید.

[Type](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ieffect/type/) و [Subtype](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ieffect/subtype/) اثر، پیش‌تنظیم آن را توصیف می‌کنند. اینها توصیف کامل یک درخت رفتار ویرایش‌شده نیستند. پیش‌تنظیم و زیرنوع را پیش از سفارشی‌سازی رفتارها انتخاب کنید: تغییر پیش‌تنظیم می‌تواند مجموعه را بازسازی کرده و عملیات سفارشی شما را از بین ببرد. به‌عنوان مثال، تغییر یک اثر Spin سفارشی به Fade می‌تواند رفتار چرخش را با رفتارهای set و filter جایگزین کند. پس از تغییر پیش‌تنظیم یا زیرنوع، مجموعه را دوباره بررسی کنید. پاک کردن رفتارهای پیش‌تنظیم می‌تواند عملیات‌های نمایانی یا مقداردهی اولیه‌ای که پیش‌تنظیم نیاز دارد را نیز حذف کند. مثال‌ها به‌طور عمدی از اشکال قابل مشاهده استفاده می‌کنند و رفتارها را جایگزین می‌کنند؛ آنها تمام پیاده‌سازی پیش‌تنظیم‌ها را بازسازی نمی‌کنند.

## **سازگاری فرمت‌ها**

حفظ درخت رفتار تضمین‌کنندهٔ پخش یکسان در هر نمایشگر یا رندر کنندهٔ خروجی نیست. داده‌های ذخیره‌شده و خروجی رندر شده را جداگانه بررسی کنید.

| فرمت یا خروجی | مواردی که باید بررسی شود |
| --- | --- |
| PPTX | به‌عنوان فرمت اصلی برای این مثال‌ها استفاده شود. پس از بازگشایی، درخت رفتار ویرایش‌پذیر را تأیید کنید، سپس پخش را در نسخهٔ PowerPoint مورد نظر بررسی کنید. |
| PPT | نمایندگی باینری قدیمی می‌تواند متفاوت از PPTX باشد. یک چرخهٔ ذخیره‑بازگشایی جداگانه و پخش را تست کنید؛ از موفقیت خروجی PPTX برای فرض پشتیبانی از هر ترکیب سفارشی نتیجه‌گیری نکنید. |
| PDF, PNG, JPEG و سایر تصاویر اسلایدهای ثابت | شامل نمایهٔ ثابت اسلاید هستند، نه یک خط زمان قابل پخش یا فریم نهایی انیمیشن تضمین‌شده. |
| [HTML5](/slides/fa/net/export-to-html5/) | هنگام فعال‌سازی انیمیشن شکل در گزینه‌های خروجی، انیمیشن‌های پشتیبانی‌شده را می‌تواند پخش کند. ترکیب‌های سفارشی را در مرورگر تست کنید. |
| [Animated GIF](/slides/fa/net/convert-powerpoint-to-animated-gif/) | فریم‌های رندر شده را ذخیره می‌کند، نه رفتارهای ویرایش‌پذیر یا تعاملات مبتنی بر کلیک. حرکت رندر شدهٔ واقعی را بررسی کنید. |
| [Video](/slides/fa/net/convert-powerpoint-to-video/) | فریم‌های انیمیشن را رندر و به‌صورت ویدئو رمزگذاری می‌کند. پشتیبانی محدود به [انیمیشن‌ها و اثرهای پشتیبانی‌شده](/slides/fa/net/convert-powerpoint-to-video/#supported-animations-and-effects) رندر کننده است؛ دستورات و رویدادهای تعاملی به یک خط زمان ویرایش‌پذیر تبدیل نمی‌شوند. |

## **سؤالات متداول**

**چرا اثر من قبل از اضافه کردن هر چیزی شامل رفتارها است؟**

ایجاد یک اثر پیش‌تعریف‌شده ممکن است عملیات زیربنایی آن را ایجاد کند. قبل از تصمیم‌گیری برای گسترش پیش‌تنظیم یا جایگزینی رفتارها، آن‌ها را بررسی کنید.

**آیا جابجایی یک رفتار به ابتدا باعث می‌شود اول اجرا شود؟**

لزوماً نیست. ترتیب مجموعه جایگزین زمان‌بندی نیست. تأخیرها، مدت زمان‌ها و تعاملات بین عملیات‌های یک ویژگی را بررسی کنید.

**چرا یک دستور End هیچ نقطه‌ای ندارد؟**

این دستور پایان مسیر را علامت‌گذاری می‌کند و نیازی به مختصات ندارد. هنگام بررسی مسیر خوانده‌شده از یک فایل، برای آرایهٔ نقطهٔ تهی بررسی کنید.

**آیا یک دور موفق به‌تنهایی تأیید پخش می‌شود؟**

نه. بازگشایی حفظ ویژگی‌هایی که بررسی کردید را تأیید می‌کند. برای تأیید رفتار بصری، پخش‌کنندهٔ اسلایدشو یا خروجی انیمیشن‌دار را جداگانه تست کنید.