---
title: ایجاد و اصلاح رفتارهای سفارشی انیمیشن در Java
linktitle: انیمیشن سفارشی
type: docs
weight: 151
url: /fa/java/custom-animation/
keywords:
- انیمیشن سفارشی
- رفتار انیمیشن
- مسیر حرکت
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "ایجاد، بررسی و اصلاح رفتارهای سفارشی انیمیشن و مسیرهای حرکت قابل ویرایش در ارائه‌های PowerPoint با Aspose.Slides برای Java."
---
## **Overview**

رفتارهای سفارشی انیمیشن به شما امکان می‌دهند عملیات‌های فردی داخل یک اثر انیمیشن را کنترل کنید، مانند تغییر رنگ، چرخاندن شکل، یا دنبال کردن مسیر حرکت ویرایش‌پذیر. این راهنما نشان می‌دهد چگونه رفتارها را ایجاد و ترکیب کنید، زمان‌بندی آن‌ها را پیکربندی کنید، انیمیشن‌های موجود را بررسی و اصلاح کنید، و تأیید کنید که ویژگی‌های آن‌ها پس از ذخیره و بازگشایی ارائه حفظ می‌شوند.

برای اثرهای از پیش تعریف شده و محرک‌های کلیک، به [Shape Animation](/slides/fa/java/shape-animation/) مراجعه کنید.

## **Understand the Animation Model**

یک انیمیشن به صورت **Timeline → Sequence → Effect → Behaviors** سازماندهی می‌شود:

- متد [getTimeline](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseslide/#getTimeline--) زمان‌بندی اسلاید را برمی‌گرداند که شامل دنباله اصلی و دنباله‌های تعاملی آن است.
- یک [ISequence](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isequence/) شامل اثرها است که ممکن است به اشکال مختلف هدف‌گذاری شوند.
- یک [IEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ieffect/) شکل هدف، پیش‌تنظیم، زیرنوع و زمان‌بندی اثر را شناسایی می‌کند.
- مجموعه‌ای که توسط [IEffect.getBehaviors](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ieffect/#getBehaviors--) بازگردانده می‌شود شامل عملیات‌هایی است که اثر را پیاده‌سازی می‌کنند: تغییر رنگ، حرکت، چرخش، تنظیم یک ویژگی و غیره.

## **Create Individual Behaviors**

برای ایجاد یک اثر و دسترسی به مجموعه [getBehaviors](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ieffect/#getBehaviors--) متد [ISequence.addEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) را فراخوانی کنید. یک پیش‌تنظیم می‌تواند به‌صورت خودکار این مجموعه را پر کند. هنگام گسترش پیش‌تنظیم عملیات‌های آن را حفظ کنید، یا وقتی عمداً جایگزین می‌کنید از [clear](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibehaviorcollection/#clear--) استفاده کنید.

[IBehaviorFactory](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibehaviorfactory/) هشت نوع رفتار را که در زیر نشان داده شده‌اند می‌سازد. حرکت در بخش [Build a Motion Path](#build-a-motion-path) پوشش داده شده است. هر قطعه کد شامل importهای آن است؛ دستورات اجرایی را داخل یک متد قرار دهید. مثال‌های ویرایشی بعدی فایل خروجی که استفاده می‌کنند را بیان می‌کنند.

### **Rotation**

برای ایجاد یک چرخش از [createRotationEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) استفاده کنید. [getBy](https://reference.aspose.com/slides/fa/java/com.aspose.slides/irotationeffect/#getBy--) زاویه نسبی را بر حسب درجه مشخص می‌کند؛ [getFrom](https://reference.aspose.com/slides/fa/java/com.aspose.slides/irotationeffect/#getFrom--) و [getTo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/irotationeffect/#getTo--) نقاط انتهایی را تعیین می‌کنند.

این مثال با یک اثر Spin شروع می‌شود، عملیات‌های پیش‌تنظیم آن را با یک رفتار چرخش جایگزین می‌کند و به آن عملیات مدت زمان دو ثانیه می‌دهد. یک زاویه نسبی 90 درجه یک چهارگرد نسبت به جهت شروع شکل را بیان می‌کند، بنابراین نیازی به زاویه شروع صریح نیست.

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

`rotation.pptx` شامل یک شکل و یک رفتار چرخش است. مجموعه، زمان‌بندی و مثال‌های ویرایش چرخش در زیر از این فایل استفاده می‌کنند.

### **Scale**

برای ایجاد یک اثر مقیاس‌گذاری از [createScaleEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) با درصدهای X/Y استفاده کنید: [getFrom](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iscaleeffect/#getFrom--) و [getTo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iscaleeffect/#getTo--) اندازه شروع و پایان را توصیف می‌کنند، در حالی که [getBy](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iscaleeffect/#getBy--) تغییر نسبی را توصیف می‌کند. در اینجا، 100 به معنای اندازه اصلی است.

مثال ابعاد هر دو جهت را از 100% به 125% در دو ثانیه افزایش می‌دهد. استفاده از درصدهای افقی و عمودی برابر نسبت‌های شکل را حفظ می‌کند؛ درصدهای متفاوت یکی از ابعاد را بیش از دیگری کش می‌دهد.

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

### **Color**

برای تغییر پر کردن از آبی به نارنجی از [createColorEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibehaviorfactory/#createColorEffect--) استفاده کنید. [getFrom](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icoloreffect/#getFrom--) و [getTo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icoloreffect/#getTo--) رنگ‌ها هستند؛ [getBy](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icoloreffect/#getBy--) یک جابجایی رنگ است. [IBehavior.getProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibehavior/#getProperties--) ویژگی انیمیشن‌شده را شناسایی می‌کند.

پر کردن جامد شکل ابتدا به آبی تنظیم شده است، که با رنگ شروع انیمیشن مطابقت دارد. انتخاب ویژگی رنگ پر کردن به رفتار می‌گوید کدام بخش شکل تغییر کند؛ تنها نقاط انتهایی رنگ آن ویژگی را شناسایی نمی‌کند. اثر ذخیره‌شده یک انتقال دو ثانیه‌ای به نارنجی را توصیف می‌کند.

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

### **Filter**

برای انتخاب یک پاک‌کن (wipe) از [createFilterEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) استفاده کنید. [getType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifiltereffect/#getType--)، [getSubtype](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifiltereffect/#getSubtype--) و [getReveal](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifiltereffect/#getReveal--) فیلتر، جهت و این که شکل نمایان شود یا مخفی، را مشخص می‌کنند.

این مثال یک پاک‌کن دو ثانیه‌ای که شکل را با جهت راست نمایان می‌کند پیکربندی می‌کند. تنظیمات فیلتر متعلق به رفتار داخل اثر هستند، بنابراین پس از حذف عملیات اصلی پیش‌تنظیم پیکربندی می‌شوند.

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

### **Property**

برای انیمیشن شفافیت (opacity) از [createPropertyEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) استفاده کنید. [getFrom](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipropertyeffect/#getFrom--)، [getTo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipropertyeffect/#getTo--) و [getBy](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipropertyeffect/#getBy--) رشته‌هایی هستند که با [getValueType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipropertyeffect/#getValueType--) و [getCalcMode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipropertyeffect/#getCalcMode--) تفسیر می‌شوند. به جای تنظیم همزمان هر سه، یا نقاط انتهایی یا یک جابجایی نسبی را انتخاب کنید.

در اینجا ویژگی انتخاب‌شده شفافیت است و رشته‌های عددی تغییر از 25% شفافیت به شفافیت کامل را نشان می‌دهند. درون‌یابی خطی توصیف‌کنندهٔ تغییر تدریجی بین این مقادیر است. هنگام تطبیق این مثال با ویژگی دیگری، نوع مقدار و مقادیر نقطهٔ انتهایی را متناسب با آن ویژگی انتخاب کنید.

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

### **Set**

برای اختصاص قابلیت نمایش با استفاده از [getTo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iseteffect/#getTo--) از [createSetEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibehaviorfactory/#createSetEffect--) استفاده کنید. یک رفتار set بین نقاط انتهایی درونی‌سازی نمی‌کند.

مثال ویژگی نمایش را انتخاب می‌کند و رشتهٔ `visible` را هنگام اجرا تعیین می‌کند. مستطیل در این ارائهٔ حداقل از قبل قابل مشاهده است، بنابراین تخصیص ممکن است به‌تنهایی تغییر بصری واضحی ندهد. چنین عملیاتی به‌عنوان بخشی از یک اثر بزرگ‌تر که زمان مخفی یا نمایان شدن شکل را نیز کنترل می‌کند مفید است.

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

### **Command**

برای استفاده از [createCommandEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) و پیکربندی [getType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icommandeffect/#getType--)، [getCommandString](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icommandeffect/#getCommandString--) و [getShapeTarget](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icommandeffect/#getShapeTarget--) استفاده کنید. فایل صوتی WAV به نام `sample.wav` را در پوشهٔ کاری قرار دهید. این مثال آن را با [addAudioFrameEmbedded](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) جاسازی می‌کند و یک دستور پخش به فریم صوتی پیوست می‌کند.

فریم صوتی هم هدف اثر و هم هدف دستور است. این کار درخواست پخش را به ضبط جاسازی‌شده متصل می‌کند؛ یک رشتهٔ دستور به‌تنهایی مشخص نمی‌کند کدام شیء رسانه‌ای کنترل شود. اثر برای شروع روی کلیک در طول نمایش اسلاید پیکربندی می‌شود.

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

ذخیره‌سازی دستور را در `command.pptx` ذخیره می‌کند؛ ضبط را اجرا نمی‌کند. پخش برای مشاهدهٔ اسلایدشویی که از این دستور و هدف رسانه‌ای پشتیبانی می‌کند لازم است.

## **Manage the Behavior Collection**

[IBehaviorCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibehaviorcollection/) از [add](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-)، [insert](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-)، [remove](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-)، و [removeAt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibehaviorcollection/#removeAt-int-) پشتیبانی می‌کند. این مثال `rotation.pptx` را باز می‌کند، مقیاس‌گذاری اضافه می‌کند، آن را قبل از چرخش می‌گذارد و چرخش را حذف می‌کند. حذف و دوباره‌درج همان شیء موقعیت ذخیره‌شده را بدون ایجاد کپی تغییر می‌دهد.

دنبالهٔ ویرایش‌ها مجموعه را از rotation–scale به scale–rotation، سپس به فقط scale تغییر می‌دهد. اندیس‌ها به مجموعهٔ فعلی اشاره دارند، بنابراین حذف از اندیس جدید چرخش پس از ترتیب‌گذاری دوباره استفاده می‌کند. شمارش نهایی نشان می‌دهد کدام رفتار ذخیره خواهد شد.

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

خروجی `ScaleEffect` است: فقط مقیاس‌گذاری باقی می‌ماند. ترتیب مجموعه به‌تنهایی رفتارها را یکی پس از دیگری زمان‌بندی نمی‌کند. فقط زمانی که تمام عملیات‌های مجموعه را جایگزین می‌کنید، آن را پاک کنید.

## **Configure Behavior Timing**

[IBehavior.getTiming](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibehavior/#getTiming--)، به‌صورت مستقل از [IEffect.getTiming](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ieffect/#getTiming--)، [ITiming](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiming/) را نمایش می‌دهد. زمان‌بندی اثر زمان‌بندی اثر محاط‌کننده را زمان‌بندی می‌کند؛ زمان‌بندی رفتار عملیاتی داخل آن را توصیف می‌کند.

### **Set Duration, Delay, Repetition, and Acceleration**

`rotation.pptx` را باز کنید و مدت زمان ([getDuration](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiming/#getDuration--)) و تاخیر محرک ([getTriggerDelayTime](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiming/#getTriggerDelayTime--)) را بر حسب ثانیه تنظیم کنید، سپس تعداد تکرار را از طریق [setRepeatCount](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiming/#setRepeatCount-float-) پیکربندی کنید. [getAccelerate](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiming/#getAccelerate--) و [getDecelerate](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiming/#getDecelerate--) کسرهایی از مدت زمان هستند؛ مجموع آن‌ها حداکثر 1 باشد.

فایل ورودی همان فایلی است که در مثال چرخش ایجاد شده؛ در آن اولین رفتار شناخته‌شده چرخش است. این مثال تنها زمان‌بندی آن رفتار را تغییر می‌دهد؛ زاویهٔ 90 درجه دست‌نخورده می‌ماند. حفظ جداگانهٔ زاویه و زمان‌بندی باعث می‌شود بدون بازسازی انیمیشن سرعت را‌ آسان‌تر تنظیم کنید.

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

این رفتار مدت زمان دو ثانیه، تاخیر نیم ثانیه‌ای و تعداد تکرار 3 دارد. 20 ٪ اول و آخر مدت زمان برای شتاب و کاهش شتاب استفاده می‌شوند.

سیاست‌های تکرار دیگر شامل [getRepeatDuration](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiming/#getRepeatDuration--)، [getRepeatUntilEndSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--) و [getRepeatUntilNextClick](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--) هستند؛ یک سیاست را انتخاب کنید نه اینکه همه را همزمان فعال کنید. [getAutoReverse](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiming/#getAutoReverse--) پس از عبور پیشرو، انیمیشن را به‌صورت معکوس پخش می‌کند. شتاب و کاهش شتاب برای تغییرات پیوسته اعمال می‌شوند، نه برای انتساب‌های گسسته یا دستورات.

## **Build a Motion Path**

برای ایجاد حرکت از [createMotionEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) استفاده کنید. [getFrom](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imotioneffect/#getFrom--)، [getTo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imotioneffect/#getTo--) و [getBy](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imotioneffect/#getBy--) مختصات یا جابجایی‌های مبتنی بر درصد را توصیف می‌کنند. برای داشتن یک مسیر قابل ویرایش، یک [MotionPath](https://reference.aspose.com/slides/fa/java/com.aspose.slides/motionpath/) ایجاد کنید و با [IMotionEffect.setPath](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-) اختصاص دهید. [IMotionPath](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imotionpath/) دستورات مسیر را ذخیره می‌کند.

[MotionCommandPathType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/motioncommandpathtype/) عملیات را انتخاب می‌کند:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | موقعیت شروع را تعیین می‌کند. |
| LineTo | One | در یک قسمت مستقیم به نقطهٔ انتهایی حرکت می‌کند. |
| CurveTo | Three | یک منحنی مکعبی را که توسط دو نقطهٔ کنترل و یک نقطهٔ انتهایی تعریف شده، دنبال می‌کند. |
| CloseLoop | None | به موقعیت شروع باز می‌گردد. |
| End | None | مسیر را به پایان می‌رساند. |

[MotionPathPointsType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/motionpathpointstype/) ویژگی‌های ویرایشی نقطه‌ها را توصیف می‌کند، مانند نقطهٔ گوشه یا صاف. این نوع جایگزین نوع فرمان نمی‌شود. برای مثال منحنی زیر از نوع نقطهٔ منحنی و برای بخش‌های مستقیم از نوع نقطهٔ گوشه استفاده کنید.

مختصات مسیر نسبت به ابعاد اسلاید نرمال‌سازی می‌شوند: جابه‌جایی X برابر 0.25 نمایانگر یک‌چهارم عرض اسلاید است، نه 0.25 پوینت. Y مثبت به‌پایین می‌رود. دستورات مطلق موقعیت‌ها را در سیستم مختصات مسیر مشخص می‌کنند؛ دستورات نسبی جابجایی‌ها را نسبت به موقعیت فعلی نشان می‌دهند. این موضوع جدا از [getOrigin](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imotioneffect/#getOrigin--) است که چارچوب مرجع مسیر را انتخاب می‌کند و از [getPathEditMode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imotioneffect/#getPathEditMode--) که نحوهٔ حرکت مسیر هنگام جابه‌جایی شکل را کنترل می‌کند، متمایز است.

### **Create a Straight Path**

یک رفتار حرکتی با نقطهٔ شروع، یک بخش مستقیم و یک فرمان پایان ایجاد کنید. [IMotionPath.add](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imotionpath/#add-int-java.awt.geom.Point2D.Float---int-boolean-) نوع فرمان، نقاط آن، نوع نقطه و پرچم مختصات نسبی را می‌گیرد.

فرمان شروع (0, 0) را برقرار می‌کند و خط به (0.25, 0) ختم می‌شود و مسیر را به‌صورت جابه‌جایی افقی یک‌چهارم عرض اسلاید می‌برد. فرمان پایان هیچ نقطهٔ مختصاتی ندارد. پس از اختصاص مسیر، افزودن رفتار حرکتی به اثر، آن مسیر را به مستطیل متصل می‌کند.

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

`motion.pptx` شامل یک رفتار حرکتی با سه فرمان مسیر است. مثال‌های ویرایش فایل زیر از این ساختار شناخته‌شده استفاده می‌کنند.

### **Compare Absolute and Relative Coordinates**

این دو شیء مسیر همان مسیر را توصیف می‌کنند. فرمان مطلق در (0.3, 0.1) خاتمه می‌یابد؛ فرمان نسبی (0.1, 0.1) را به موقعیت فعلی (0.2, 0) اضافه می‌کند.

هر دو مسیر از همان موقعیت شروع می‌شوند. برای خط نسبی، جابجایی‌های X و Y را به موقعیت فعلی اضافه کنید تا نقطهٔ انتها بدست آید؛ برای خط مطلق، مستقیم نقطهٔ انتها را بخوانید. تغییر پرچم بدون تبدیل مختصات مسیر متفاوتی توصیف می‌کند.

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

هر یک از مسیرها را می‌توان به یک رفتار حرکتی اختصاص داد تا در ارائه استفاده شود. آرگومان بولی نهایی مختصات نسبی را برای آن فرمان انتخاب می‌کند.

### **Replace a Line with a Curve**

`motion.pptx` را باز کنید و فرمان خط آن را با یک منحنی مکعبی جایگزین کنید. ابتدا دو نقطهٔ کنترل را سپس نقطهٔ انتهایی فراهم کنید.

موقعیت شروع توسط فرمان قبلی تامین می‌شود. دو نقطهٔ اول شکل منحنی را می‌سازند، در حالی که نقطهٔ سوم مقصد نهایی است؛ آن‌ها سه مقصد متوالی نیستند. به‌روزرسانی همزمان نوع فرمان، نوع ویرایشی نقطه و آرایهٔ نقاط، بخش را با هندسهٔ جدید سازگار نگه می‌دارد.

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

مسیر در `curve.pptx` همچنان سه فرمان دارد؛ فرمان میانی اکنون یک منحنی است.

## **Inspect and Edit a Saved Path**

هر [IMotionCmdPath](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imotioncmdpath/) متدهای [getPoints](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imotioncmdpath/#getPoints--)، [getCommandType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imotioncmdpath/#getCommandType--)، [getPointsType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imotioncmdpath/#getPointsType--) و [isRelative](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imotioncmdpath/#isRelative--) را ارائه می‌دهد. مثال‌های زیر از مسیر سه‌فرمان شناخته‌شده در `motion.pptx` استفاده می‌کنند. برای ورودی‌های دلخواه، پیش از ویرایش بر اساس اندیس، اثر موردنظر را پیدا کنید و نوع فرمان‌ها و تعداد نقاط را بررسی کنید.

### **Read Commands and Coordinates**

مسیر را بدون تغییر بخوانید. دستورات End و CloseLoop نیازی به نقاط ندارند، لذا برای آرایهٔ نقطهٔ تهی (null) Allow کنید.

خروجی هر نوع فرمان عددی را همراه پرچم مختصات نسبی قبل از فهرست کردن نقاطش نمایش می‌دهد. این به شما امکان می‌دهد قبل از اصلاح مسیر، نقطهٔ انتهایی را از جابجایی متمایز کنید. یک منحنی سه نقطه را فهرست می‌کند، در حالی که خط مستقیم در این فایل فقط یک نقطه دارد.

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

فهرست شامل یک نقطهٔ شروع، یک خط مطلق که به (0.25, 0) ختم می‌شود، و یک فرمان End است.

### **Change an Endpoint**

`motion.pptx` را باز کنید و آرایهٔ نقاط خط را برای جابه‌جایی نقطهٔ انتهایی جایگزین کنید.

در فایل ورودی، اندیس 0 فرمان شروع و اندیس 1 خط است. جایگزینی نقطهٔ تک خط مقصد آن را بدون تغییر نوع فرمان، زمان‌بندی یا موقعیت در مجموعه تغییر می‌دهد. چون فرمان از مختصات مطلق استفاده می‌کند، جفت جدید موقعیت را نشان می‌دهد نه یک جابجایی افزوده.

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

خط در `motion-endpoint.pptx` به (0.4, 0.1) ختم می‌شود؛ فایل اصلی دست‌نخورده باقی می‌ماند.

### **Replace a Segment**

از [insert](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imotionpath/#insert-int-int-java.awt.geom.Point2D.Float---int-boolean-) و [removeAt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imotionpath/#removeAt-int-) برای جایگزینی خط در `motion.pptx` استفاده کنید. درج خط قدیمی را به اندیس 2 منتقل می‌کند.

این نشان می‌دهد چگونه یک شیء فرمان را جایگزین می‌کنید نه اینکه مختصات موجود آن را ویرایش کنید. پس از درج، مجموعه موقتاً شامل فرمان شروع، خط جدید، خط قدیمی و فرمان End می‌شود. حذف اندیس 2 خط قدیمی را حذف می‌کند و مسیر جدید در جای خود می‌ماند.

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

مسیر ذخیره‌شده همچنان سه فرمان دارد؛ خط جدید به (0.2, 0.1) ختم می‌شود و فرمان End در انتهاست.

## **Modify and Verify an Existing Behavior**

وقتی اندیس رفتار ناشناخته باشد، با نوع آن انتخاب کنید. این مثال `rotation.pptx` را باز می‌کند، [IRotationEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/irotationeffect/) را پیدا می‌کند، زاویه را تغییر می‌دهد و مقدار ذخیره‌شده را پس از بازگشایی بررسی می‌کند.

بررسی نوع باعث می‌شود حلقه رفتارهای غیرچرخشی را عبور دهد. بار دوم فایل ذخیره‌شده را به‌عنوان شیء ارائهٔ جداگانه می‌خواند، بنابراین مقایسه داده‌های ماندگار نه مقدار در حافظه را بررسی می‌کند. این مثال همچنان فرض می‌کند اثر شناخته‌شده اولین در دنبالهٔ اصلی است؛ انتخاب رفتار بر پایه نوع، اثر درست را در یک ارائهٔ دلخواه مکان‌یابی نمی‌کند.

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

خروجی `Rotation preserved: true` است. همان الگوی بررسی نوع را برای رفتارهای دیگر به‌کار بگیرید. برای بررسی کامل حفظ، شکل هدف، اثر، انواع رفتار و ترتیب، زمان‌بندی و دستورات مسیر را مقایسه کنید. برای مقادیر اعشاری از تحمل عددی استفاده کنید. برای ارائه‌ای با ساختار انیمیشن ناشناخته، به [Read Shape Animations](/slides/fa/java/shape-animation/#read-shape-animations) برای پیمایش دنباله‌های اصلی و تعاملی مراجعه کنید.

## **Behavior Order, Presets, and Playback**

ترتیب در [IBehaviorCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibehaviorcollection/) ترتیب ذخیره‌شدهٔ عملیات‌های یک اثر است. این یک لیست پخش نیست که در آن هر رفتار به‌صورت خودکار منتظر رفتار قبلی بماند. زمان‌بندی و اثر محاط‌کننده زمان‌بندی را تعیین می‌کنند. رفتارها می‌توانند هم‌پوشانی شوند و عملیات روی یک ویژگی ممکن است از طریق [getAdditive](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibehavior/#getAdditive--) و [getAccumulate](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibehavior/#getAccumulate--) با یکدیگر تعامل داشته باشند. فقط ترتیب‌گذاری مجموعه به‌تنهایی برای زمان‌بندی «حرکت، سپس چرخش» کافی نیست؛ از زمان‌بندی صریح یا اثرهای جداگانه همان‌گونه که در [Shape Animation](/slides/fa/java/shape-animation/) توضیح داده شده است، استفاده کنید.

[getType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ieffect/#getType--) و [getSubtype](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ieffect/#getSubtype--) اثر پیش‌تنظیم آن را توصیف می‌کنند. این‌ها توصیف کامل درخت رفتارهای ویرایش‌شده نیستند. پیش‌تنظیم و زیرنوع را پیش از سفارشی‌سازی رفتارها انتخاب کنید: تغییر پیش‌تنظیم می‌تواند مجموعه را بازسازی و عملیات سفارشی شما را از بین ببرد. به‌عنوان مثال، تغییر یک اثر Spin سفارشی‌شده به Fade می‌تواند رفتار چرخش را با رفتارهای set و filter جایگزین کند. پس از تغییر پیش‌تنظیم یا زیرنوع، مجموعه را دوباره بررسی کنید. پاک‌سازی رفتارهای پیش‌تنظیم همچنین می‌تواند عملیات نمایش یا مقداردهی اولیه‌ای که پیش‌تنظیم به آن نیاز دارد حذف کند. مثال‌ها به‌صورت عمدی از اشکال قابل مشاهده استفاده می‌کنند و رفتارها را جایگزین می‌نمایند؛ آن‌ها تمام پیاده‌سازی پیش‌تنظیم‌ها را بازتولید نمی‌کنند.

## **Format Compatibility**

درخت رفتار حفظ‌شده تضمین‌کنندهٔ پخش یکسان در هر نمایشگر یا رندر خروجی نیست. داده‌های ذخیره‌شده و خروجی رندرد را جداگانه بررسی کنید.

| Format or output | What to verify |
| --- | --- |
| PPTX | به‌عنوان فرمت اصلی برای این مثال‌ها استفاده کنید. آن را بازگشایی کنید تا درخت رفتار ویرایشی را تأیید کنید، سپس پخش را در نسخهٔ موردنظر PowerPoint بررسی کنید. |
| PPT | نمایش باینری قدیمی ممکن است با PPTX متفاوت باشد. یک چرخهٔ ذخیره‑بازگشایی جداگانه و پخش را تست کنید؛ از موفقیت خروجی PPTX برای استنتاج پشتیبانی از هر ترکیب سفارشی استفاده نکنید. |
| PDF, PNG, JPEG, and other static slide images | یک نمای ایستای اسلاید را شامل می‌شوند، نه یک خط زمان قابل پخش یا فریم نهایی انیمیشن تضمین‌شده. |
| [HTML5](/slides/fa/java/export-to-html5/) | می‌تواند انیمیشن‌های پشتیبانی‌شده را هنگام فعال‌سازی انیمیشن شکل در گزینه‌های خروجی اجرا کند. ترکیبات سفارشی را در مرورگر تست کنید. |
| [Animated GIF](/slides/fa/java/convert-powerpoint-to-animated-gif/) | فریم‌های رندرشده را ذخیره می‌کند، نه رفتارهای ویرایشی یا تعاملات مبتنی بر کلیک. حرکت رندرد شده را بررسی کنید. |
| [Video](/slides/fa/java/convert-powerpoint-to-video/) | فریم‌های انیمیشن را رندر و به‌صورت ویدئو رمزگذاری می‌کند. پشتیبانی به‌محدودیت‌های [supported animations and effects](/slides/fa/java/convert-powerpoint-to-video/#supported-animations-and-effects) رندر محدود است؛ دستورات و رویدادهای تعاملی تبدیل به یک خط زمان ویرایشی نمی‌شوند. |

## **FAQ**

**چرا اثر من قبل از افزودن رفتارها شامل رفتارها است؟**

ایجاد یک اثر پیش‌تنظیم می‌تواند عملیات زیرین آن را ایجاد کند. پیش از تصمیم‌گیری برای گسترش پیش‌تنظیم یا جایگزینی رفتارهای آن، آن‌ها را بررسی کنید.

**آیا جابه‌جایی یک رفتار به ابتدا باعث می‌شود اول پخش شود؟**

لزماً نه. ترتیب مجموعه جایگزین زمان‌بندی نمی‌شود. تاخیرها، مدت‌ها و تعاملات بین عملیات روی یک ویژگی را بررسی کنید.

**چرا یک فرمان End هیچ نقطه‌ای ندارد؟**

این فرمان پایان مسیر است و نیازی به مختصات ندارد. هنگام بررسی مسیر خوانده‌شده از فایل، برای آرایهٔ نقطهٔ تهی (null) بررسی کنید.

**آیا یک دور کامل موفق برای تأیید پخش کافی است؟**

نه. بازگشایی فقط حفظ ویژگی‌هایی را که بررسی کرده‌اید تأیید می‌کند. برای تأیید رفتار بصری، پخش‌کنندهٔ اسلایدشو یا خروجی انیمیشن را جداگانه تست کنید.