---
title: ایجاد و اصلاح رفتارهای انیمیشن سفارشی در JavaScript
linktitle: انیمیشن سفارشی
type: docs
weight: 151
url: /fa/nodejs-java/custom-animation/
keywords:
- انیمیشن سفارشی
- رفتار انیمیشن
- مسیر حرکت
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "ایجاد، بررسی و اصلاح رفتارهای انیمیشن سفارشی و مسیرهای حرکت قابل ویرایش در ارائه‌های PowerPoint با Aspose.Slides برای Node.js از طریق Java."
---
## **بررسی کلی**

رفتارهای سفارشی انیمیشن به شما امکان می‌دهند تا عملیات‌های فردی داخل یک اثر انیمیشنی را کنترل کنید، مانند تغییر رنگ، چرخاندن شکل یا دنبال کردن مسیر حرکت قابل ویرایش. این راهنما نشان می‌دهد چگونه رفتارها را ایجاد و ترکیب کنید، زمان‌بندی آن‌ها را پیکربندی کنید، انیمیشن‌های موجود را بررسی و اصلاح کنید و اطمینان حاصل کنید که ویژگی‌های آن‌ها پس از ذخیره و بازگشایی ارائه باقی می‌مانند.

برای اثرهای از پیش تعریف شده و محرک‌های کلیک، به [انیمیشن شکل](/slides/fa/nodejs-java/shape-animation/) مراجعه کنید.

## **درک مدل انیمیشن**

یک انیمیشن به‌صورت **Timeline → Sequence → Effect → Behaviors** سازماندهی می‌شود:

- متد [getTimeline](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseslide/#getTimeline) زمان‌بند اسلاید را برمی‌گرداند که شامل توالی اصلی و توالی‌های تعاملی آن است.
- یک [Sequence](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sequence/) شامل اثرها است که ممکن است به شکل‌های مختلف هدف بدهند.
- یک [Effect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effect/) یک شکل هدف، پیش تنظیم، زیرنوع و زمان‌بندی اثر را شناسایی می‌کند.
- نگهداری که توسط [Effect.getBehaviors](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effect/#getBehaviors) برگردانده می‌شود، شامل عملیات‌هایی است که اثر را پیاده‌سازی می‌کنند: تغییر رنگ، جابجا شدن، چرخاندن، تنظیم یک ویژگی و غیره.

## **ایجاد رفتارهای فردی**

برای ایجاد یک اثر و دسترسی به مجموعهٔ [getBehaviors](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effect/#getBehaviors) متد [Sequence.addEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sequence/#addEffect) را فراخوانی کنید. یک پیش تنظیم می‌تواند این مجموعه را به‌صورت خودکار پر کند. هنگام گسترش پیش تنظیم، عملیات‌های آن را نگه دارید، یا زمانی که به‌صورت آگاهانه می‌خواهید جایگزین کنید از [clear](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/behaviorcollection/#clear) استفاده کنید.

[BehaviorFactory](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/behaviorfactory/) هشت نوع رفتار را که در ادامه تصویر شده‌اند ایجاد می‌کند. حرکت در بخش [ساخت یک مسیر حرکت](#build-a-motion-path) مورد بررسی قرار می‌گیرد. هر قطعه شامل واردات ماژول‌های مربوطه است و می‌تواند به‌عنوان اسکریپت Node.js با بسته‌های `aspose.slides.via.java` و `java` نصب شده اجرا شود. قبل از مثال‌های خواندن خروجی، مثال‌های ایجاد فایل را اجرا کنید. مثال‌های ویرایش بعدی مشخص می‌کنند که از کدام فایل خروجی استفاده می‌شود.

### **چرخش**

از [createRotationEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/behaviorfactory/#createRotationEffect) برای ایجاد یک چرخش استفاده کنید. [getBy](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/rotationeffect/#getBy) زاویهٔ نسبی را بر حسب درجه مشخص می‌کند؛ [getFrom](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/rotationeffect/#getFrom) و [getTo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/rotationeffect/#getTo) نقاط انتهایی را تعریف می‌کنند.

مثال با یک اثر Spin شروع می‌شود، عملیات پیش تنظیم آن را با یک رفتار چرخش جایگزین می‌کند و به آن یک مدت زمان دو ثانیه می‌دهد. یک زاویهٔ نسبی ۹۰ درجه یک چرخش یک‌چهارم دور نسبت به جهت اولیهٔ شکل است، بنابراین نیازی به زاویهٔ شروع صریح نیست.

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

`rotation.pptx` شامل یک شکل و یک رفتار چرخش است. مجموعه، زمان‌بندی و مثال‌های ویرایش چرخش زیر از این فایل استفاده می‌کنند.

### **مقیاس**

از [createScaleEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/behaviorfactory/#createScaleEffect) با درصدهای X/Y استفاده کنید: [getFrom](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/scaleeffect/#getFrom) و [getTo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/scaleeffect/#getTo) اندازهٔ شروع و پایان را توصیف می‌کنند، در حالی که [getBy](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/scaleeffect/#getBy) تغییر نسبی را بیان می‌کند. در اینجا ۱۰۰ به معنی اندازهٔ اصلی است.

مثال هر دو بُعد را از ۱۰۰٪ به ۱۲۵٪ در دو ثانیه بزرگ می‌کند. استفاده از درصدهای مساوی افقی و عمودی نسبت شکل را حفظ می‌کند؛ درصدهای متفاوت یک بُعد را نسبت به دیگری کشیده می‌کند.

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

### **رنگ**

از [createColorEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/behaviorfactory/#createColorEffect) برای تغییر پر از آبی به نارنجی استفاده کنید. [getFrom](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/coloreffect/#getFrom) و [getTo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/coloreffect/#getTo) رنگ‌ها هستند؛ [getBy](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/coloreffect/#getBy) یک انحراف رنگی است. [Behavior.getProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/behavior/#getProperties) ویژگی انیمیشن‌شده را شناسایی می‌کند.

پر ثابت شکل به رنگ آبی مقداردهی اولیه می‌شود که با رنگ شروع انیمیشن مطابقت دارد. انتخاب ویژگی fill-color به رفتار می‌گوید کدام بخش از شکل تغییر کند؛ تنها نقاط انتهایی رنگ این ویژگی را شناسایی نمی‌کنند. اثر ذخیره‌شده یک انتقال دو ثانیه‌ای به نارنجی را توصیف می‌کند.

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

### **فیلتر**

از [createFilterEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/behaviorfactory/#createFilterEffect) برای انتخاب یک پاک‌کن استفاده کنید. [getType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/filtereffect/#getType)، [getSubtype](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/filtereffect/#getSubtype) و [getReveal](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/filtereffect/#getReveal) فیلتر، جهت و اینکه شکل نمایش داده شود یا مخفی شود را مشخص می‌کنند.

این مثال یک پاک‌کن دو ثانیه‌ای که شکل را با جهت راست نشان می‌دهد، پیکربندی می‌کند. تنظیمات فیلتر به رفتار داخل اثر تعلق دارند، بنابراین پس از حذف عملیات اصلی پیش تنظیم، پیکربندی می‌شوند.

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

### **ویژگی**

از [createPropertyEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/behaviorfactory/#createPropertyEffect) برای انیمیشن شفافیت استفاده کنید. [getFrom](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/propertyeffect/#getFrom)، [getTo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/propertyeffect/#getTo) و [getBy](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/propertyeffect/#getBy) رشته‌هایی هستند که با استفاده از [getValueType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/propertyeffect/#getValueType) و [getCalcMode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/propertyeffect/#getCalcMode) تفسیر می‌شوند. به‌جای تنظیم همزمان سه مقدار، یا نقاط انتهایی یا یک انحراف نسبی را انتخاب کنید.

در اینجا ویژگی انتخاب‌شده شفافیت است و رشته‌های عددی تغییر از ۲۵٪ شفافیت به شفافیت کامل را نشان می‌دهند. درون‌یابی خطی یک تغییر تدریجی بین این مقادیر توصیف می‌کند. هنگام بکارگیری این مثال برای ویژگی دیگر، نوع مقدار و نقاط انتهایی متناسب با آن ویژگی را انتخاب کنید.

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

### **تنظیم**

از [createSetEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/behaviorfactory/#createSetEffect) برای تعیین ویژگی visibility از طریق [getTo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/seteffect/#getTo) استفاده کنید. یک رفتار set بین نقاط انتهایی درون‌یابی نمی‌کند.

مثال ویژگی visibility را انتخاب می‌کند و رشتهٔ `visible` را هنگام اجرای رفتار اختصاص می‌دهد. در این ارائهٔ ساده مستطیل از پیش قابل مشاهده است، بنابراین این انتساب به تنهایی تغییری واضح در تصویر ایجاد نمی‌کند. چنین عملیاتی به‌عنوان بخشی از یک اثر بزرگ‌تر مفید است که زمان نمایش یا مخفی شدن شکل را نیز کنترل می‌کند.

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

### **دستور**

از [createCommandEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/behaviorfactory/#createCommandEffect) استفاده کنید و [getType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/commandeffect/#getType)، [getCommandString](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/commandeffect/#getCommandString) و [getShapeTarget](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/commandeffect/#getShapeTarget) را پیکربندی کنید. یک فایل صوتی WAV به نام `sample.wav` را در پوشهٔ کاری قرار دهید. این مثال آن را با [addAudioFrameEmbedded](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) جاسازی می‌کند و یک فرمان play را به فریم صوتی وصل می‌نماید.

فریم صوتی هم هدف اثر و هم هدف فرمان است. این اتصال درخواست پخش را به ضبط جاسازی‌شده متصل می‌کند؛ یک رشتهٔ فرمان به تنهایی شی رسانه‌ای مورد کنترل را مشخص نمی‌کند. اثر برای شروع با کلیک حین نمایش اسلاید پیکربندی شده است.

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

ذخیره فرمان را در `command.pptx` ذخیره می‌کند؛ صدا را پخش نمی‌کند. پخش نیاز به یک پخش‌کنندهٔ اسلاید دارد که فرمان و هدف رسانه‌ای آن را پشتیبانی کند.

## **مدیریت مجموعه رفتارها**

[BehaviorCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/behaviorcollection/) از متدهای [add](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/behaviorcollection/#add)، [insert](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/behaviorcollection/#insert)، [remove](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/behaviorcollection/#remove) و [removeAt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/behaviorcollection/#removeAt) پشتیبانی می‌کند. این مثال `rotation.pptx` را باز می‌کند، مقیاس‌بندی را اضافه می‌کند، آن را پیش از چرخش می‌گذارد و سپس چرخش را حذف می‌کند. حذف و دوباره‌درج شیء یکسان موقعیت ذخیره‌شدهٔ آن را بدون ایجاد یک کپی تغییر می‌دهد.

دنبالهٔ ویرایش‌ها مجموعه را از rotation–scale به scale–rotation و سپس به صرفاً scale تغییر می‌دهد. ایندکس‌ها به مجموعهٔ جاری اشاره دارند، بنابراین حذف از ایندکس جدید چرخش پس از reorder انجام می‌شود. شمارش نهایی تأیید می‌کند کدام رفتار ذخیره خواهد شد.

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

خروجی `ScaleEffect` است: فقط مقیاس‌گذاری باقی می‌ماند. ترتیب مجموعه به‌تنهایی رفتارها را یکی پس از دیگری زمان‌بندی نمی‌کند. تنها زمانی که تمام عملیات‌ها را جایگزین می‌کنید، مجموعه را پاک کنید.

## **پیکربندی زمان‌بندی رفتار**

[Behavior.getTiming](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/behavior/#getTiming) دسترسی به [Timing](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/) را مستقل از [Effect.getTiming](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effect/#getTiming) فراهم می‌کند. زمان‌بندی اثر، اثر در برگیرندهٔ خود را زمان‌بندی می‌کند؛ زمان‌بندی رفتار، یک عملیات داخل آن را توصیف می‌کند.

### **تنظیم مدت زمان، تأخیر، تکرار و شتاب**

`rotation.pptx` را باز کنید و مدت زمان ([getDuration](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/#getDuration)) و تأخیر محرک ([getTriggerDelayTime](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/#getTriggerDelayTime)) را بر حسب ثانیه تعیین کنید، سپس تعداد تکرار را از طریق [setRepeatCount](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/#setRepeatCount) پیکربندی کنید. [getAccelerate](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/#getAccelerate) و [getDecelerate](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/#getDecelerate) کسری از مدت زمان هستند؛ مجموع آن‌ها حداکثر باید ۱ باشد.

فایل ورودی همان فایلی است که در مثال چرخش ایجاد شد و اولین رفتار آن یک چرخش است. این مثال تنها زمان‌بندی آن رفتار را تغییر می‌دهد؛ زاویهٔ ۹۰ درجه دست نخورده باقی می‌ماند. نگه داشتن زاویه و زمان‌بندی به‌صورت جداگانه، تنظیم سرعت را بدون بازسازی انیمیشن آسان‌تر می‌کند.

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

این رفتار از مدت زمان دو ثانیه، تأخیر نیم‌ثانیه‌ای و تعداد تکرار ۳ بهره می‌برد. ۲۰٪ اول و آخر مدت زمان آن برای شتاب و کاهش شتاب استفاده می‌شود.

سیاست‌های تکرار دیگر شامل [getRepeatDuration](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/#getRepeatDuration)، [getRepeatUntilEndSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide) و [getRepeatUntilNextClick](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) هستند؛ یک سیاست را انتخاب کنید به‌جای فعال‌سازی همهٔ آنها به‌طور همزمان. [getAutoReverse](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/#getAutoReverse) پس از پیش‌رفت، انیمیشن را به‌طرف معکوس پخش می‌کند. شتاب و کاهش شتاب بر تغییرات پیوسته اعمال می‌شوند، نه بر انتساب‌های گسسته یا دستورات.

## **ساخت مسیر حرکت**

از [createMotionEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/behaviorfactory/#createMotionEffect) برای ایجاد حرکت استفاده کنید. [getFrom](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/motioneffect/#getFrom)، [getTo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/motioneffect/#getTo) و [getBy](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/motioneffect/#getBy) مختصات یا جابجایی‌های مبتنی بر درصد را توصیف می‌کنند. برای مسیری قابل ویرایش، یک [MotionPath](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/motionpath/) ایجاد کنید و با [MotionEffect.setPath](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/motioneffect/#setPath) آن را اختصاص دهید. [MotionPath](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/motionpath/) دستورات مسیر را ذخیره می‌کند.

[MotionCommandPathType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/motioncommandpathtype/) عملیات را انتخاب می‌کند:

| دستور | نقاط | معنی |
| --- | --- | --- |
| MoveTo | یک | تنظیم موقعیت شروع. |
| LineTo | یک | حرکت به‌صورت یک segment مستقیم تا نقطهٔ انتهایی آن. |
| CurveTo | سه | دنبال کردن یک منحنی مکعبی که توسط دو نقطهٔ کنترل و یک نقطهٔ انتهایی تعریف می‌شود. |
| CloseLoop | هیچ | بازگشت به موقعیت شروع. |
| End | هیچ | پایان مسیر. |

[MotionPathPointsType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/motionpathpointstype/) خصوصیات ویرایش نقطه را توصیف می‌کند، مانند نقاط گوشه یا صاف. این نوع جایگزین نوع دستور نمی‌شود. برای مثال منحنی زیر، از نوع نقطهٔ منحنی استفاده کنید و برای بخش‌های مستقیم از نوع نقطهٔ گوشه.

مختصات مسیر نسبت به ابعاد اسلاید نرمال‌سازی می‌شوند: جابه‌جایی X برابر ۰.۲۵ یعنی یک‌چهارم عرض اسلاید، نه ۰.۲۵ پوینت. Y مثبت به سمت پایین می‌رود. دستورات مطلق موقعیت‌ها را در سامانهٔ مختصات مسیر مشخص می‌کنند؛ دستورات نسبی جابه‌جایی‌ها را نسبت به موقعیت جاری تعریف می‌کنند. این موضوع جدا از [getOrigin](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/motioneffect/#getOrigin) است که قاب مرجع مسیر را انتخاب می‌کند و [getPathEditMode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/motioneffect/#getPathEditMode) که نحوهٔ حرکت مسیر هنگام جابه‌جایی شکل را کنترل می‌کند.

### **ایجاد مسیر مستقیم**

یک رفتار حرکت با نقطهٔ شروع، یک بخش مستقیم و یک دستور پایان ایجاد کنید. [MotionPath.add](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/motionpath/#add) نوع دستور، نقاط آن، نوع نقطه و پرچم مختصات نسبی را می‌گیرد.

دستور شروع (۰, ۰) را تنظیم می‌کند و خط به (۰.۲۵, ۰) می‌رسد که مسیر را یک‌چهارم عرض اسلاید افقی می‌کند. دستور پایان هیچ نقطه‌ای ندارد. پس از اختصاص مسیر، افزودن رفتار حرکت به اثر، این مسیر را به مستطیل متصل می‌کند.

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

`motion.pptx` شامل یک رفتار حرکت با سه دستور مسیر است. مثال‌های ویرایش فایل زیر از این ساختار شناخته‌شده استفاده می‌کنند.

### **مقایسهٔ مختصات مطلق و نسبی**

این دو شیء مسیر همان مسیر را توصیف می‌کنند. دستور مطلق در (۰.۳, ۰.۱) پایان می‌یابد؛ دستور نسبی (۰.۱, ۰.۱) را به موقعیت جاری (۰.۲, ۰) اضافه می‌کند.

هر دو مسیر از همان موقعیت شروع می‌شوند. برای خط نسبی، آفست‌های X و Y را به موقعیت جاری اضافه کنید تا نقطهٔ انتها به دست آید؛ برای خط مطلق، نقطهٔ انتها را مستقیماً بخوانید. تغییر پرچم بدون تبدیل مختصات مسیر متفاوتی ایجاد می‌کند.

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

هر یک از مسیرها را به یک رفتار حرکت اختصاص دهید تا در ارائه استفاده شود. آرگومان بولی نهایی مختصات نسبی را برای آن دستور انتخاب می‌کند.

### **جایگزینی یک خط با منحنی**

`motion.pptx` را باز کنید و دستور خط آن را با یک منحنی مکعبی جایگزین کنید. ابتدا دو نقطهٔ کنترل را ارائه دهید، سپس نقطهٔ انتهایی را.

موقعیت شروع توسط دستور قبلی تأمین می‌شود. دو نقطهٔ اول شکل‌دهندهٔ منحنی هستند، در حالی که سومین نقطه مقصد نهایی است؛ آن‌ها سه مقصد متوالی نیستند. به‌روز‌رسانی همزمان نوع دستور، نوع ویرایش نقطه و آرایهٔ نقاط، بخش را با هندسهٔ جدید سازگار نگه می‌دارد.

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

مسیر در `curve.pptx` همچنان سه دستور دارد؛ دستور میانی آن اکنون یک منحنی را تعریف می‌کند.

## **بررسی و ویرایش مسیر ذخیره‌شده**

هر [MotionCmdPath](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/motioncmdpath/) [getPoints](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/motioncmdpath/#getPoints)، [getCommandType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/motioncmdpath/#getCommandType)، [getPointsType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/motioncmdpath/#getPointsType) و [isRelative](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/motioncmdpath/#isRelative) را در اختیار می‌گذارد. مثال‌های زیر از مسیر سه‌دستوری شناخته‌شده در `motion.pptx` استفاده می‌کنند. برای ورودی دلخواه، قبل از ویرایش بر اساس ایندکس، اثر مورد نظر را پیدا کنید و انواع دستورات و تعداد نقاط را بررسی کنید.

### **خواندن دستورات و مختصات**

مسیر را بدون تغییر بخوانید. دستورات end و close-loop نیازی به نقطه ندارند، بنابراین آرایهٔ نقطه می‌تواند null باشد.

خروجی هر نوع دستور عددی را همراه با پرچم مختصات نسبی قبل از فهرست کردن نقاطش نمایش می‌دهد. این امکان را می‌دهد قبل از تغییر مسیر، نقطهٔ انتهایی را از جابجایی تشخیص دهید. یک منحنی سه نقطه، در حالی که خط مستقیم در این فایل فقط یک نقطه دارد، فهرست می‌شود.

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

فهرست شامل یک نقطهٔ شروع، یک خط مطلق که در (۰.۲۵, ۰) پایان می‌یابد و یک دستور end است.

### **تغییر نقطهٔ انتهایی**

`motion.pptx` را باز کنید و آرایهٔ نقطهٔ خط را جایگزین کنید تا نقطهٔ انتهایی آن جابه‌جا شود.

در فایل ورودی، ایندکس ۰ دستور شروع است و ایندکس ۱ خط است. جایگزینی نقطهٔ تک‌تای این خط، مقصد آن را بدون تغییر نوع دستور، زمان‌بندی یا موقعیت در مجموعه تغییر می‌دهد. چون دستور از مختصات مطلق استفاده می‌کند، جفت جدید موقعیت را توصیف می‌کند نه یک جابجایی افزایشی.

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

خط در `motion-endpoint.pptx` در (۰.۴, ۰.۱) پایان می‌یابد؛ فایل اصلی دست نخورده می‌ماند.

### **جایگزینی یک بخش**

از [insert](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/motionpath/#insert) و [removeAt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/motionpath/#removeAt) برای جایگزینی خط در `motion.pptx` استفاده کنید. درج خط جدید، خط قبلی را به ایندکس ۲ می‌برد.

این روش نشان می‌دهد که به‌جای ویرایش مختصات موجود، شیء دستور را جایگزین می‌کنیم. پس از درج، مجموعه موقتاً شامل دستور شروع، خط جدید، خط قدیم و دستور end می‌شود. حذف ایندکس ۲ خط قدیم را حذف می‌کند و مسیر جدید باقی می‌ماند.

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

مسیر ذخیره‌شده همچنان سه دستور دارد؛ خط جدید در (۰.۲, ۰.۱) پایان می‌یابد و دستور end در انتها باقی می‌ماند.

## **تغییر و تأیید یک رفتار موجود**

وقتی ایندکس رفتار شناخته نیست، با نوع آن انتخاب کنید. این مثال `rotation.pptx` را باز می‌کند، [RotationEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/rotationeffect/) را می‌یابد، زاویه را تغییر می‌دهد و پس از بازگشایی، مقدار ذخیره‌شده را بررسی می‌کند.

بررسی نوع، حلقه را از رفتارهای غیرچرخشی عبور می‌دهد. بار دوم فایل ذخیره‌شده را در یک شیء ارائهٔ جداگانه می‌خواند، بنابراین مقایسه داده‌های ماندگار را بررسی می‌کند نه مقدار همچنان در حافظه. این مثال هنوز فرض می‌کند اثر شناخته‌شده اولین عنصر در توالی اصلی است؛ انتخاب رفتار بر‌اساس نوع، لزوماً اثر صحیح را در ارائه‌ای دلخواه پیدا نمی‌کند.

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

خروجی `Rotation preserved: true` است. همان الگوی بررسی نوع را می‌توانید برای رفتارهای دیگر به‌کار ببرید. برای بررسی کامل نگهداری، شکل هدف، اثر، انواع و ترتیب رفتارها، زمان‌بندی و دستورات مسیر را مقایسه کنید. برای مقادیر نقطه شناور از تحمل عددی استفاده کنید. برای ارائه‌ای با طرح انیمیشن ناشناخته، به [Read Shape Animations](/slides/fa/nodejs-java/shape-animation/#read-shape-animations) برای پیمایش توالی اصلی و تعاملی مراجعه کنید.

## **ترتیب رفتارها، پیش تنظیم‌ها و پخش**

ترتیب در [BehaviorCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/behaviorcollection/) ترتیب ذخیره‌شدهٔ عملیات یک اثر است. این یک لیست پخش نیست که هر رفتار به‌صورت خودکار منتظر قبلی باشد. زمان‌بندی و اثر محاط‌کننده زمان‌بندی را تعیین می‌کنند. رفتارها می‌توانند هم‌پوشانی داشته باشند و عملیات روی یک ویژگی می‌توانند از طریق [getAdditive](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/behavior/#getAdditive) و [getAccumulate](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/behavior/#getAccumulate) با هم تعامل داشته باشند. فقط بر اساس ترتیب مجموعه برای زمان‌بندی «جابجا کردن، سپس چرخاندن» استفاده نشود؛ زمان‌بندی صریح یا اثرهای جداگانه همان‌طور که در [انیمیشن شکل](/slides/fa/nodejs-java/shape-animation/) توضیح داده شده است، به کار ببرید.

[getType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effect/#getType) و [getSubtype](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effect/#getSubtype) اثر، پیش تنظیم آن را توصیف می‌کنند. اینها توصیف کاملی از درخت رفتار ویرایش‌شده نیستند. پیش تنظیم و زیرنوع را پیش از سفارشی‌سازی رفتارها انتخاب کنید: تغییر پیش تنظیم می‌تواند مجموعه را بازسازی و عملیات سفارشی شما را حذف کند. به‌عنوان مثال، تغییر یک اثر Spin سفارشی به Fade می‌تواند رفتار چرخش را با رفتارهای set و filter جایگزین کند. پس از تغییر پیش تنظیم یا زیرنوع، مجموعه را دوباره بررسی کنید. پاک کردن رفتارهای پیش تنظیم نیز می‌تواند عملیات نمایش یا مقداردهی اولیه‌ای که پیش تنظیم به آن نیاز دارد، حذف کند. مثال‌ها به‌صورتی عمدی از شکل‌های قابل مشاهده استفاده می‌کنند و رفتارها را جایگزین می‌کنند؛ آن‌ها تمام پیاده‌سازی هر پیش تنظیم را بازسازی نمی‌کنند.

## **سازگاری فرمت‌ها**

یک درخت رفتار حفظ‌شده تضمین‌کنندهٔ پخش یکسان در همهٔ نمایشگرها یا رندرورهای خروجی نیست. داده‌های ذخیره‌شده و خروجی رندر شده را جداگانه بررسی کنید.

| قالب یا خروجی | چه چیزی را باید بررسی کرد |
| --- | --- |
| PPTX | به‌عنوان فرمت اصلی برای این مثال‌ها استفاده کنید. آن را دوباره باز کنید تا درخت رفتار ویرایش‌پذیر را تأیید کنید، سپس پخش را در نسخهٔ موردنظر PowerPoint بررسی کنید. |
| PPT | نمایش باینری قدیمی می‌تواند متفاوت از PPTX باشد. یک دورهٔ ذخیره‑و‑بازگشایی جداگانه و پخش را تست کنید؛ از موفقیت خروجی PPTX برای استنتاج پشتیبانی از هر ترکیب سفارشی استفاده نکنید. |
| PDF, PNG, JPEG و سایر تصاویر اسلاید ثابت | شامل نمای ثابت اسلاید هستند، نه خط زمان‌پذیر قابل پخش یا فریم نهایی انیمیشن تضمین‌شده. |
| [HTML5](/slides/fa/nodejs-java/export-to-html5/) | می‌تواند انیمیشن‌های پشتیبانی‌شده را زمانی که انیمیشن شکل در گزینه‌های خروجی فعال باشد، پخش کند. ترکیب‌های سفارشی را در مرورگر تست کنید. |
| [Animated GIF](/slides/fa/nodejs-java/convert-powerpoint-to-animated-gif/) | فریم‌های رندر شده را ذخیره می‌کند، نه رفتارهای قابل ویرایش یا تعامل کلیک‑محور. حرکت رندر شده واقعی را بررسی کنید. |
| [Video](/slides/fa/nodejs-java/convert-powerpoint-to-video/) | فریم‌های انیمیشن را رندر و به‌صورت ویدیو رمزگذاری می‌کند. پشتیبانی محدود به [انیمیشن‌ها و افکت‌های پشتیبانی‌شده](/slides/fa/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) رندرور است؛ دستورات و رویدادهای تعاملی تبدیل به خط زمان قابل ویرایش نمی‌شوند. |

## **سؤالات متداول**

**چرا اثر من قبل از اضافه کردن رفتار، حاوی رفتارها است؟**

ایجاد یک اثر پیش‌تنظیم‌شده می‌تواند عملیات‌های زیرساختی آن را ایجاد کند. قبل از تصمیم‌گیری برای گسترش پیش‌تنظیم یا جایگزینی رفتارها، آن‌ها را بررسی کنید.

**آیا حرکت یک رفتار به ابتدای مجموعه باعث می‌شود اول پخش شود؟**

لازم نیست. ترتیب مجموعه جایگزین زمان‌بندی نیست. تأخیرها، مدت زمان‌ها و تعاملات بین عملیات بر روی یک ویژگی را بررسی کنید.

**چرا یک دستور end هیچ نقطه‌ای ندارد؟**

این دستور پایان مسیر است و نیازی به مختصات ندارد. هنگام بررسی مسیری که از فایل خوانده می‌شود، به‌دنبال آرایهٔ نقطهٔ null باشید.

**آیا یک دور رفت و آمد موفق برای تأیید پخش کافی است؟**

نه. بازگشایی صرفاً حفظ ویژگی‌هایی را که بررسی کرده‌اید تأیید می‌کند. پخش‌کنندهٔ اسلایدشو یا خروجی انیمیشن را جداگانه تست کنید تا رفتار بصری آن را تأیید کنید.