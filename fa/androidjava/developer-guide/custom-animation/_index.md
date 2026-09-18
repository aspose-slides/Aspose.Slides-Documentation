---
title: ایجاد و اصلاح رفتارهای سفارشی انیمیشن در Android
linktitle: انیمیشن سفارشی
type: docs
weight: 151
url: /fa/androidjava/custom-animation/
keywords:
- انیمیشن سفارشی
- رفتار انیمیشن
- مسیر حرکتی
- پاورپوینت
- ارائه
- Android
- Java
- Aspose.Slides
description: "ایجاد، بررسی و اصلاح رفتارهای سفارشی انیمیشن و مسیرهای حرکتی قابل ویرایش در ارائه‌های PowerPoint با Aspose.Slides برای Android از طریق Java."
---
## **نمای کلی**

رفتارهای سفارشی انیمیشن به شما اجازه می‌دهند عملیات‌های فردی درون یک اثر انیمیشن را کنترل کنید، مانند تغییر رنگ، چرخاندن یک شکل، یا دنبال کردن مسیر حرکتی قابل ویرایش. این راهنما نحوه ایجاد و ترکیب رفتارها، پیکربندی زمان‌بندی آن‌ها، بررسی و اصلاح انیمیشن‌های موجود، و اطمینان از باقی ماندن ویژگی‌های آن‌ها پس از ذخیره و بازگشایی یک ارائه را نشان می‌دهد.

برای افکت‌های پیش‌فرض و تحریک‌های کلیک، به [انیمیشن شکل](/slides/fa/androidjava/shape-animation/) مراجعه کنید.

## **درک مدل انیمیشن**

یک انیمیشن به شکل **Timeline → Sequence → Effect → Behaviors** سازماندهی می‌شود:

- متد [getTimeline](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseslide/#getTimeline--) زمان‌بندی اسلاید را برمی‌گرداند که شامل توالی اصلی و توالی‌های تعاملی آن است.
- یک [ISequence](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isequence/) حاوی افکت‌هاست که ممکن است به اشکال مختلفی هدف‌گیری کند.
- یک [IEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/) شکل هدف، پیش‌تنظیم، زیرنوع و زمان‌بندی افکت را شناسایی می‌کند.
- مجموعه‌ای که توسط [IEffect.getBehaviors](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#getBehaviors--) برگردانده می‌شود حاوی عملیات‌هایی است که اثر را پیاده‌سازی می‌کنند: تغییر رنگ، حرکت، چرخش، تنظیم یک ویژگی و غیره.

## **ایجاد رفتارهای تک‌تکه**

برای ایجاد یک افکت و دسترسی به مجموعه [getBehaviors](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#getBehaviors--)، متد [ISequence.addEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) را فراخوانی کنید. یک پیش‌تنظیم می‌تواند این مجموعه را به‌صورت خودکار پر کند. وقتی پیش‌تنظیم را گسترش می‌دهید، عملیات آن را حفظ کنید یا برای جایگزینی عمدی از [clear](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibehaviorcollection/#clear--) استفاده کنید.

[IBehaviorFactory](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibehaviorfactory/) هشت نوع رفتار را که در زیر نشان داده شده است می‌سازد. حرکت در بخش [ساخت مسیر حرکتی](#build-a-motion-path) پوشش داده شده است. هر قطعه کد شامل ایمپورت‌های مربوطه است؛ دستورات قابل اجرا را داخل یک متد قرار دهید. مثال‌های ویرایشی بعدی بیان می‌کنند که از کدام فایل خروجی استفاده می‌شود. در اندروید، نام‌های فایل نمونه را با مسیرهای کامل در یک پوشه قابل دسترس برای برنامه، مانند پوشه files برنامه‌تان، جایگزین کنید.

### **چرخش**

از [createRotationEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) برای ایجاد چرخش استفاده کنید. [getBy](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/irotationeffect/#getBy--) زاویه نسبی را برحسب درجه مشخص می‌کند؛ [getFrom](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/irotationeffect/#getFrom--) و [getTo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/irotationeffect/#getTo--) نقطه‌های انتهایی را تعریف می‌کنند.

این مثال با یک افکت Spin شروع می‌شود، عملیات پیش‌تنظیم آن را با یک رفتار چرخش جایگزین می‌کند و به آن عملیات مدت زمان دو ثانیه می‌دهد. یک زاویه نسبی 90 درجه یک چرخش یک‌چهارم دور نسبت به جهت اولیه شکل است، بنابراین نیازی به زاویه شروع صریح نیست.

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

`rotation.pptx` شامل یک شکل و یک رفتار چرخش است. مجموعه، زمان‌بندی و مثال‌های ویرایشی چرخش در زیر از این فایل استفاده می‌کنند.

### **مقیاس**

از [createScaleEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) همراه با درصدهای X/Y استفاده کنید: [getFrom](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iscaleeffect/#getFrom--) و [getTo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iscaleeffect/#getTo--) اندازه شروع و پایان را توصیف می‌کنند، در حالی که [getBy](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iscaleeffect/#getBy--) تغییر نسبی را شرح می‌دهد. در اینجا، 100 به معنای اندازه اصلی است.

مثال دو بعد را از 100٪ به 125٪ در طول دو ثانیه بزرگ می‌کند. استفاده از درصدهای مساوی افقی و عمودی نسبت شکل را حفظ می‌کند؛ درصدهای متفاوت یک بعد را نسبت به دیگری کش می‌کند.

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

### **رنگ**

از [createColorEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibehaviorfactory/#createColorEffect--) برای تغییر پر کردن از آبی به نارنجی استفاده کنید. [getFrom](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icoloreffect/#getFrom--) و [getTo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icoloreffect/#getTo--) رنگ‌ها هستند؛ [getBy](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icoloreffect/#getBy--) جابجایی رنگ است. [IBehavior.getProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibehavior/#getProperties--) ویژگی انیمیشن‌شده را شناسایی می‌کند.

پر کردن جامد شکل به رنگ آبی مقداردهی اولیه می‌شود، که با رنگ شروع انیمیشن مطابقت دارد. انتخاب ویژگی fill‑color به رفتار می‌گوید کدام بخش شکل را تغییر دهد؛ تنها نقاط انتهایی رنگ آن ویژگی را مشخص نمی‌کنند. افکت ذخیره‌شده توصیف‌کننده انتقال دو ثانیه‌ای به نارنجی است.

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

### **فیلتر**

از [createFilterEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) برای انتخاب یک پاک‌کن (wipe) استفاده کنید. [getType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifiltereffect/#getType--)، [getSubtype](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifiltereffect/#getSubtype--) و [getReveal](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifiltereffect/#getReveal--) فیلتر، جهت و این که شکل نمایش داده شود یا مخفی شود را مشخص می‌کنند.

این مثال پاک‌کن دو ثانیه‌ای را که شکل را با جهت راست نمایش می‌دهد، پیکربندی می‌کند. تنظیمات فیلتر متعلق به رفتار داخل افکت هستند، بنابراین پس از حذف عملیات اصلی پیش‌تنظیم، انجام می‌شوند.

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

### **ویژگی**

از [createPropertyEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) برای انیمیشن شفافیت استفاده کنید. [getFrom](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipropertyeffect/#getFrom--)، [getTo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipropertyeffect/#getTo--) و [getBy](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipropertyeffect/#getBy--) رشته‌هایی هستند که با استفاده از [getValueType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipropertyeffect/#getValueType--) و [getCalcMode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipropertyeffect/#getCalcMode--) تفسیر می‌شوند. به‌جای تنظیم همزمان هر سه مقدار، نقطهٔ انتهایی یا جابجایی نسبی را انتخاب کنید.

در اینجا، ویژگی انتخاب‌شده شفافیت است و رشته‌های عددی تغییر از 25٪ شفافیت به شفافیت کامل را نشان می‌دهند. درون‌یابی خطی تغییر تدریجی بین این مقادیر را توصیف می‌کند. هنگام تطبیق این مثال برای ویژگی دیگر، نوع مقدار و مقادیر نقطهٔ انتهایی مناسب آن ویژگی را انتخاب کنید.

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

### **تنظیم**

از [createSetEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibehaviorfactory/#createSetEffect--) برای اختصاص قابلیت دیده شدن از طریق [getTo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iseteffect/#getTo--) استفاده کنید. یک رفتار set بین نقطهٔ انتهایی درون‌یابی نمی‌کند.

مثال ویژگی visible را هنگامی که رفتار اجرا می‌شود، اختصاص می‌دهد. مستطیل در این ارائهٔ ساده از قبل دیده می‌شود، لذا این تخصیص ممکن است به‌تنهایی تغییر واضحی نداشته باشد. چنین عملیاتی در کنار افکت بزرگ‌تری که زمان مخفی شدن یا نمایش شکل را نیز کنترل می‌کند، مفید است.

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

### **دستور**

از [createCommandEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) استفاده کنید و [getType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icommandeffect/#getType--)، [getCommandString](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icommandeffect/#getCommandString--) و [getShapeTarget](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icommandeffect/#getShapeTarget--) را پیکربندی کنید. یک فایل ضبط صوتی WAV به نام `sample.wav` را در پوشه کاری قرار دهید. این مثال آن را با [addAudioFrameEmbedded](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) جاسازی می‌کند و یک دستور play به فریم صوتی می‌چسباند.

فریم صوتی هم هدف افکت و هم هدف دستور است. این کار درخواست play را به ضبط جاسازی‌شده متصل می‌کند؛ یک رشتهٔ دستور به‌تنهایی شی رسانه‌ای را که باید کنترل شود، شناسایی نمی‌کند. افکت طوری پیکربندی می‌شود که در حین ارائه با کلیک شروع شود.

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

ذخیره‌سازی دستور را در `command.pptx` ذخیره می‌کند؛ ضبط را پخش نمی‌کند. پخش نیاز به یک پخش‌کنندهٔ ارائه دارد که دستور و هدف رسانه‌ای آن را پشتیبانی کند.

## **مدیریت مجموعهٔ رفتارها**

[IBehaviorCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibehaviorcollection/) از [add](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-)، [insert](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-)، [remove](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-)، و [removeAt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibehaviorcollection/#removeAt-int-) پشتیبانی می‌کند. این مثال `rotation.pptx` را باز می‌کند، مقیاس‌بندی اضافه می‌کند، قبل از چرخش آن را حرکت می‌دهد و چرخش را حذف می‌کند. حذف و دوباره‌درج همان شیء موقعیت ذخیره‌شدهٔ آن را بدون ایجاد کپی تغییر می‌دهد.

دنبالهٔ ویرایش‌ها مجموعه را از rotation–scale به scale–rotation و سپس به scale فقط تغییر می‌دهد. اندیس‌ها به مجموعهٔ جاری اشاره دارند، بنابراین حذف از اندیس جدید چرخش پس از بازچینش استفاده می‌کند. شمارش نهایی نشان می‌دهد کدام رفتار ذخیره خواهد شد.

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

خروجی `ScaleEffect` است: فقط مقیاس‌بندی باقی می‌ماند. ترتیب مجموعه به‌تنهایی رفتارها را یکی‌پس‑یکی زمان‌بندی نمی‌کند. فقط وقتی همهٔ عملیات را جایگزین می‌کنید، مجموعه را پاک کنید.

## **پیکربندی زمان‌بندی رفتار**

[IBehavior.getTiming](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibehavior/#getTiming--) متد [ITiming](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/) را به‌صورت مستقل از [IEffect.getTiming](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#getTiming--) افشا می‌کند. زمان‌بندی افکت توالیٔ محاط‌کننده را برنامه‌ریزی می‌کند؛ زمان‌بندی رفتار عملیاتی داخل آن را توصیف می‌کند.

### **تنظیم مدت زمان، تأخیر، تکرار و شتاب**

`rotation.pptx` را باز کنید و مدت زمان ([getDuration](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#getDuration--)) و تأخیر تحریک ([getTriggerDelayTime](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--)) را به ثانیه تنظیم کنید، سپس تعداد تکرار را از طریق [setRepeatCount](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-) پیکربندی کنید. [getAccelerate](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#getAccelerate--) و [getDecelerate](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#getDecelerate--) کسرهایی از مدت زمان هستند؛ مجموع آن‌ها حداکثر 1 باشد.

فایل ورودی همان فایلی است که در مثال چرخش ایجاد شد و در آن اولین رفتار یک چرخش است. این مثال فقط زمان‌بندی آن رفتار را تغییر می‌دهد؛ زاویهٔ 90 درجه دست‌نخورده می‌ماند. جدا نگه داشتن زاویه و زمان‌بندی، تنظیم سرعت را بدون بازسازی انیمیشن آسان‌تر می‌کند.

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

رفتار دو ثانیه مدت زمان دارد، نیم‌ثانیه تأخیر، و تعداد تکرار 3. 20٪ اول و آخر مدت زمان برای شتاب و کاهش سرعت استفاده می‌شود.

سیاست‌های تکرار دیگر شامل [getRepeatDuration](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#getRepeatDuration--)، [getRepeatUntilEndSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--) و [getRepeatUntilNextClick](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--) هستند؛ یکی را انتخاب کنید نه اینکه همه را همزمان فعال کنید. [getAutoReverse](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiming/#getAutoReverse--) پس از عبور جلو، انیمیشن را به عقب پخش می‌کند. شتاب و کاهش سرعت برای تغییرات پیوسته اعمال می‌شود، نه برای انتساب‌های گسسته یا دستورات.

## **ساخت مسیر حرکتی**

از [createMotionEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) برای ایجاد حرکت استفاده کنید. [getFrom](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imotioneffect/#getFrom--)، [getTo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imotioneffect/#getTo--) و [getBy](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imotioneffect/#getBy--) مختصات یا جابجایی‌های مبتنی بر درصد را توصیف می‌کنند. برای یک مسیر قابل ویرایش، یک [MotionPath](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/motionpath/) ایجاد کنید و آن را با [IMotionEffect.setPath](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-) اختصاص دهید. [IMotionPath](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imotionpath/) دستورات مسیر را ذخیره می‌کند.

[MotionCommandPathType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/motioncommandpathtype/) عملیات را انتخاب می‌کند:

| فرمان | نقاط | معنی |
| --- | --- | --- |
| MoveTo | One | تنظیم موقعیت شروع. |
| LineTo | One | حرکت در یک قطعهٔ مستقیم به نقطهٔ انتهایی آن. |
| CurveTo | Three | دنبال کردن یک منحنی مکعبی که توسط دو نقطهٔ کنترل و یک نقطهٔ انتهایی تعریف می‌شود. |
| CloseLoop | None | بازگشت به موقعیت شروع. |
| End | None | پایان مسیر. |

[MotionPathPointsType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/motionpathpointstype/) ویژگی‌های ویرایش نقطه‌ها را توصیف می‌کند، مانند نقطهٔ گوشه یا صاف. این نوع نقطه جایگزین نوع فرمان نمی‌شود. برای مثال منحنی زیر از نوع نقطهٔ Curve استفاده کنید و برای قطعات مستقیم از نوع Corner.

مختصات مسیر نسبت به ابعاد اسلاید نرمال‌سازی می‌شوند: جابجایی X برابر 0.25 نمایانگر یک‌چهارم عرض اسلاید است، نه 0.25 پیکسل. Y مثبت به سمت پایین حرکت می‌کند. دستورات مطلق موقعیت‌ها را در سیستم مختصات مسیر مشخص می‌کنند؛ دستورات نسبی جابجایی‌ها را از موقعیت جاری تعریف می‌کنند. این موضوع جدا از [getOrigin](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imotioneffect/#getOrigin--) است که چارچوب مرجع مسیر را انتخاب می‌کند و از [getPathEditMode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imotioneffect/#getPathEditMode--) که نحوهٔ حرکت مسیر هنگام جابه‌جایی شکل را کنترل می‌کند، متمایز است.

### **ایجاد مسیر مستقیم**

یک رفتار حرکتی با نقطهٔ شروع، یک قطعهٔ مستقیم و یک فرمان پایان ایجاد کنید. [IMotionPath.add](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imotionpath/#add-int-android.graphics.PointF---int-boolean-) نوع فرمان، نقاط آن، نوع نقطه و پرچم مختصات نسبی را می‌گیرد.

فرمان شروع (0, 0) را تعیین می‌کند و خط به (0.25, 0) ختم می‌شود که مسیر را به اندازهٔ یک‌چهارم عرض اسلاید افقی می‌کند. فرمان پایان هیچ نقطه‌ای ندارد. پس از اختصاص مسیر، افزودن رفتار حرکتی به افکت، این مسیر را به مستطیل وصل می‌کند.

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

`motion.pptx` شامل یک رفتار حرکتی با سه فرمان مسیر است. مثال‌های ویرایشی زیر از این ساختار شناخته‌شده استفاده می‌کنند.

### **مقایسهٔ مختصات مطلق و نسبی**

این دو شیء مسیر همان مسیر را توصیف می‌کنند. فرمان مطلق در (0.3, 0.1) پایان می‌یابد؛ فرمان نسبی (0.1, 0.1) را به موقعیت جاری (0.2, 0) اضافه می‌کند.

هر دو مسیر از موقعیت یکسانی شروع می‌شوند. برای خط نسبی، جابجایی‌های X و Y را به موقعیت جاری اضافه کنید تا نقطهٔ انتهایی به‌دست آید؛ برای خط مطلق، نقطهٔ انتهایی را مستقیماً بخوانید. تغییر پرچم بدون تبدیل مختصات مسیر متفاوتی ایجاد می‌کند.

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

هر یک از مسیرها را به یک رفتار حرکتی اختصاص دهید تا در ارائه استفاده شود. آرگومان بولی نهایی مختصات نسبی را برای آن فرمان انتخاب می‌کند.

### **جایگزینی یک خط با منحنی**

`motion.pptx` را باز کنید و فرمان خط آن را با یک منحنی مکعبی جایگزین کنید. ابتدا دو نقطهٔ کنترل را، سپس نقطهٔ انتهایی را فراهم کنید.

موقعیت شروع توسط فرمان قبلی فراهم می‌شود. دو نقطه اول شکل منحنی را می‌سازند، در حالی که نقطهٔ سوم مقصد نهایی است؛ آن‌ها سه مقصد متوالی نیستند. به‌روزرسانی همزمان نوع فرمان، نوع ویرایشی نقطه و آرایهٔ نقاط، بخش را با هندسهٔ جدید سازگار نگه می‌دارد.

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

مسیر در `curve.pptx` هنوز سه فرمان دارد؛ فرمان میانی اکنون یک منحنی را تعریف می‌کند.

## **بازرسی و ویرایش مسیر ذخیره‌شده**

هر [IMotionCmdPath](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imotioncmdpath/) [getPoints](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imotioncmdpath/#getPoints--)، [getCommandType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imotioncmdpath/#getCommandType--)، [getPointsType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imotioncmdpath/#getPointsType--) و [isRelative](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imotioncmdpath/#isRelative--) را افشا می‌کند. مثال‌های زیر از مسیر سه‑فرمانی معروف در `motion.pptx` استفاده می‌کنند. برای ورودی‌های دلخواه، اثر مورد نظر را پیدا کنید و قبل از ویرایش با اندیس، انواع فرمان و تعداد نقاط را بررسی کنید.

### **خواندن فرمان‌ها و مختصات**

مسیر را بدون تغییر بخوانید. فرمان‌های End و CloseLoop نیازی به نقاط ندارند، بنابراین آرایهٔ نقطهٔ خالی (null) را در نظر بگیرید.

خروجی هر نوع فرمان عددی را همراه پرچم مختصات نسبی قبل از فهرست‌کردن نقاط نشان می‌دهد. این امکان را می‌دهد تا قبل از تغییر مسیر، نقطهٔ انتهایی را از جابجایی تشخیص دهید. یک منحنی سه نقطه فهرست می‌کند، در حالی که خط مستقیم در این فایل تنها یک نقطه دارد.

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

فهرست شامل نقطهٔ شروع، یک خط مطلق که در (0.25, 0) پایان می‌یابد و یک فرمان End است.

### **تغییر نقطهٔ انتهایی**

`motion.pptx` را باز کنید و آرایهٔ نقاط خط را برای جابه‌جایی نقطهٔ انتهایی آن جایگزین کنید.

در فایل ورودی، اندیس 0 فرمان شروع و اندیس 1 خط است. جایگزینی نقطهٔ تک خط، مقصد آن را بدون تغییر نوع فرمان، زمان‌بندی یا موقعیت در مجموعه تغییر می‌دهد. چون فرمان از مختصات مطلق استفاده می‌کند، جفت جدید یک موقعیت را مشخص می‌کند نه یک جابجایی افزوده‌شده.

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

خط در `motion-endpoint.pptx` در (0.4, 0.1) پایان می‌یابد؛ فایل اصلی بدون تغییر باقی می‌ماند.

### **جایگزینی یک بخش**

از [insert](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imotionpath/#insert-int-int-android.graphics.PointF---int-boolean-) و [removeAt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imotionpath/#removeAt-int-) برای جایگزینی خط در `motion.pptx` استفاده کنید. درج خط جدید، خط قدیمی را به اندیس 2 منتقل می‌کند.

این کار نشان می‌دهد که به جای ویرایش مختصات موجود، می‌توانید یک شیء فرمان را جایگزین کنید. پس از درج، مجموعه شامل فرمان شروع، خط جدید، خط قدیمی و فرمان End می‌شود. حذف اندیس 2 خط قدیمی را حذف می‌کند و مسیر جدید در‌جا می‌ماند.

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

مسیر ذخیره‌شده همچنان سه فرمان دارد؛ خط جدید در (0.2, 0.1) پایان می‌یابد و فرمان End آخرین فرمان است.

## **تغییر و تأیید یک رفتار موجود**

وقتی اندیس رفتار ناشناخته است، با نوع آن انتخاب کنید. این مثال `rotation.pptx` را باز می‌کند، [IRotationEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/irotationeffect/) را پیدا می‌کند، زاویه را تغییر می‌دهد و مقدار ذخیره‌شده را پس از بازگشایی دوباره بررسی می‌کند.

بررسی نوع باعث می‌شود حلقه رفتارهای غیرچرخشی را رد کند. بار دوم فایل ذخیره‌شده را به یک شیء ارائهٔ جداگانه می‌خواند، بنابراین مقایسه داده‌های باقی‌مانده را نه مقدار در حافظه، بررسی می‌کند. این مثال هنوز فرض می‌کند افکت شناخته‌شده اولین در توالی اصلی است؛ انتخاب رفتار بر اساس نوع لزوماً افکت صحیح را در یک ارائهٔ دلخواه پیدا نمی‌کند.

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

خروجی `Rotation preserved: true` است. الگوی بررسی نوع را برای سایر رفتارها نیز به‌کار ببرید. برای یک بررسی کامل حفظ، شکل هدف، افکت، انواع و ترتیب رفتارها، زمان‌بندی و فرمان‌های مسیر را مقایسه کنید. برای ارائه با طرح انیمیشن ناشناخته، به [خواندن انیمیشن‌های شکل](/slides/fa/androidjava/shape-animation/#read-shape-animations) برای پیمایش توالی‌های اصلی و تعاملی مراجعه کنید.

## **ترتیب رفتارها، پیش‌تنظیم‌ها و پخش**

ترتیب در [IBehaviorCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibehaviorcollection/) همان ترتیب ذخیره‌شدهٔ عملیات‌های یک افکت است. این یک لیست پخش نیست که در آن هر رفتار به‌صورت خودکار پس از رفتار قبلی منتظر بماند. زمان‌بندی و افکت محاط‌کننده برنامه‌ریزی را تعیین می‌کند. رفتارها می‌توانند همپوشانی داشته باشند و عملیات روی یک ویژگی می‌توانند از طریق [getAdditive](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibehavior/#getAdditive--) و [getAccumulate](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibehavior/#getAccumulate--) با هم تعامل داشته باشند. فقط با بازترتیب‌دادن مجموعه زمان‌بندی «حرکت، سپس چرخش» را برنامه‌ریزی نکنید؛ از زمان‌بندی صریح یا افکت‌های جداگانه همان‌طور که در [انیمیشن شکل](/slides/fa/androidjava/shape-animation/) شرح داده شده استفاده کنید.

[getType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#getType--) و [getSubtype](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#getSubtype--) افکت پیش‌تنظیم آن را توصیف می‌کنند. این‌ها توصیف کامل درخت رفتارهای ویرایش‌شده نیستند. پیش‌تنظیم و زیرنوع را قبل از سفارشی‌سازی رفتارها انتخاب کنید: تغییر پیش‌تنظیم می‌تواند مجموعه را بازسازی کرده و عملیات سفارشی شما را از بین ببرد. برای مثال، تغییر یک افکت Spin سفارشی به Fade می‌تواند رفتار چرخش را با رفتارهای set و filter جایگزین کند. پس از تغییر پیش‌تنظیم یا زیرنوع، دوباره مجموعه را بررسی کنید. پاک کردن رفتارهای پیش‌تنظیم می‌تواند عملیات دیده‌شدن یا مقداردهی اولیه‌ای را که پیش‌تنظیم به آن نیاز دارد، نیز حذف کند. مثال‌ها عمداً از اشکال قابل مشاهده استفاده کرده و رفتارها را جایگزین می‌کنند؛ آن‌ها همهٔ پیاده‌سازی پیش‌تنظیم‌ها را بازسازی نمی‌کنند.

## **سازگاری قالب‌ها**

یک درخت رفتار حفظ‌شده تضمین‌کنندهٔ پخش یکسان در هر نمایشگر یا رندر کنندهٔ خروجی نیست. داده‌های ذخیره‌شده و خروجی رندر شده را جداگانه بررسی کنید.

| قالب یا خروجی | نکات بررسی |
| --- | --- |
| PPTX | به عنوان قالب اصلی برای این مثال‌ها استفاده شود. پس از بازگشایی، درخت رفتارهای ویرایشی را تأیید کنید، سپس پخش را در نسخهٔ PowerPoint موردنظر بررسی کنید. |
| PPT | نمای باینری قدیمی ممکن است متفاوت از PPTX باشد. یک چرخهٔ ذخیره‑بازگشت جداگانه و پخش را آزمایش کنید؛ از موفقیت خروجی PPTX برای استنتاج پشتیبانی تمام ترکیب‌های سفارشی استفاده نکنید. |
| PDF، PNG، JPEG و سایر تصویرهای ثابت اسلاید | شامل نمایش ثابت اسلاید هستند، نه یک خط زمان رفتار قابل پخش یا فریم نهایی انیمیشن تضمین‌شده. |
| [HTML5](/slides/fa/androidjava/export-to-html5/) | می‌تواند انیمیشن‌های پشتیبانی‌شده را زمانی که انیمیشن شکل در گزینه‌های خروجی فعال باشد، پخش کند. ترکیب‌های سفارشی را در مرورگر تست کنید. |
| [GIF متحرک](/slides/fa/androidjava/convert-powerpoint-to-animated-gif/) | فریم‌های رندرشده را ذخیره می‌کند، نه رفتارهای ویرایشی یا تعاملات مبتنی بر کلیک. حرکت واقعی رندرشده را بررسی کنید. |
| [ویدیو](/slides/fa/androidjava/convert-powerpoint-to-video/) | فریم‌های انیمیشن را رندر و به‌صورت ویدیو انکود می‌کند. پشتیبانی محدود به [انیمیشن‌ها و افکت‌های پشتیبانی‌شده](/slides/fa/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) رندرر است؛ دستورات و رویدادهای تعاملی تبدیل به خط زمان ویرایشی نمی‌شوند. |

## **سؤالات متداول**

**چرا افکتر قبل از افزودن من رفتار دارد؟**

ایجاد یک افکت پیش‌تنظیم می‌تواند عملیات زیرین آن را ایجاد کند. قبل از تصمیم به گسترش پیش‌تنظیم یا جایگزینی رفتارهایش، آن‌ها را بررسی کنید.

**آیا حرکت یک رفتار به ابتدای مجموعه باعث می‌شود ابتدا اجرا شود؟**

لزماً نیست. ترتیب مجموعه جایگزین زمان‌بندی نمی‌شود. تأخیرها، مدت زمان‌ها و تعاملات بین عملیات روی همان ویژگی را بررسی کنید.

**چرا یک فرمان End هیچ نقطه‌ای ندارد؟**

این فرمان پایان مسیر را نشان می‌دهد و نیازی به مختصات ندارد. هنگام بررسی مسیر خوانده‌شده از فایل، به وجود آرایه نقطهٔ null توجه کنید.

**آیا عبور موفق یک‌دوره کافی برای تأیید پخش است؟**

نه. بازگشایی فقط حفظ ویژگی‌هایی را که بررسی کردید تأیید می‌کند. پخش‌کنندهٔ اسلایدشو یا خروجی‌های انیمیشنی را جداگانه تست کنید تا رفتار بصری آن را تأیید کنید.