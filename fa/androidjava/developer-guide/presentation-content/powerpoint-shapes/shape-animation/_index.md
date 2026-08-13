---
title: اعمال انیمیشن‌های شکل در ارائه‌ها بر روی Android
linktitle: انیمیشن شکل
type: docs
weight: 60
url: /fa/androidjava/shape-animation/
keywords:
- شکل
- انیمیشن
- اثر
- شکل انیمیشن‌دار
- متن انیمیشن‌دار
- افزودن انیمیشن
- دریافت انیمیشن
- استخراج انیمیشن
- افزودن اثر
- دریافت اثر
- استخراج اثر
- صدا اثر
- اعمال انیمیشن
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "کشف کنید چگونه انیمیشن‌های شکل را در ارائه‌های پاورپوینت با Aspose.Slides برای Android از طریق جاوا ایجاد و سفارشی کنید. برجسته باشید!"
---
## **مقدمه**

انیمیشن‌ها اثرات بصری هستند که می‌توان آنها را بر روی متن‌ها، تصاویر، اشکال یا [نمودارها](https://docs.aspose.com/slides/fa/androidjava/animated-charts/) اعمال کرد. این انیمیشن‌ها به ارائه‌ها یا اجزای آن جان می‌بخشند.

## **چرا از انیمیشن‌ها در ارائه‌ها استفاده کنیم؟**

با استفاده از انیمیشن‌ها می‌توانید  

* کنترل جریان اطلاعات  
* تأکید بر نکات مهم  
* افزایش علاقه یا مشارکت مخاطبان  
* سهل‌تر کردن خواندن یا درک یا پردازش محتوا  
* جلب توجه خوانندگان یا بینندگان به بخش‌های مهم در یک ارائه  

PowerPoint گزینه‌ها و ابزارهای متعددی برای انیمیشن‌ها و اثرات انیمیشن در دسته‌بندی‌های **ورود**، **خروج**، **تاکید** و **مسیرهای حرکت** ارائه می‌دهد. 

## **انیمیشن‌ها در Aspose.Slides**

* Aspose.Slides کلاس‌ها و نوع‌هایی را که برای کار با انیمیشن‌ها نیاز دارید در فضای نام `Aspose.Slides.Animation` فراهم می‌کند،  
* Aspose.Slides بیش از **150 اثر انیمیشن** را تحت شمارش‌گر [EffectType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/effecttype) ارائه می‌دهد. این اثرها اساساً همان (یا معادل) اثرهایی هستند که در PowerPoint استفاده می‌شوند.

## **اعمال انیمیشن به TextBox**

Aspose.Slides برای Android از طریق Java به شما امکان می‌دهد انیمیشن را بر روی متن در یک شکل اعمال کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع اسلاید را از طریق شاخص آن به دست آورید.  
3. یک `rectangle` [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape) اضافه کنید.  
4. متن را به [IAutoShape.TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) اضافه کنید.  
5. دنباله اصلی اثرها را دریافت کنید.  
6. یک اثر انیمیشن را به [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape) اضافه کنید.  
7. خاصیت `TextAnimation.BuildType` را به مقدار مناسب از شمارش‌گر `BuildType` تنظیم کنید.  
8. ارائه را به صورت فایل PPTX بر روی دیسک بنویسید.  

این کد جاوا نشان می‌دهد چگونه اثر `Fade` را به AutoShape اعمال کنید و انیمیشن متن را به مقدار *By 1st Level Paragraphs* تنظیم کنید:

```java
import com.aspose.slides.*;

// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // یک AutoShape جدید با متن اضافه می‌کند
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // دنباله اصلی اسلاید را دریافت می‌کند.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // یک اثر انیمیشن Fade را به شکل اضافه می‌کند
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // متن شکل را بر اساس پاراگراف‌های سطح اول انیمیشن می‌دهد
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // فایل PPTX را روی دیسک ذخیره می‌کند
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 

علاوه بر اعمال انیمیشن به متن، می‌توانید انیمیشن را به یک [Paragraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph) تک‌تک نیز اعمال کنید. به [**متن انیمیشن‌دار**](/slides/fa/androidjava/animated-text/) مراجعه کنید.

{{% /alert %}} 

## **اعمال انیمیشن به PictureFrame**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع اسلاید را از طریق شاخص آن به دست آورید.  
3. یک [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pictureframe) را به اسلاید اضافه کنید یا دریافت کنید.  
4. دنباله اصلی اثرها را دریافت کنید.  
5. یک اثر انیمیشن را به [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pictureframe) اضافه کنید.  
6. ارائه را به صورت فایل PPTX بر روی دیسک بنویسید.  

این کد جاوا نشان می‌دهد چگونه اثر `Fly` را به یک picture frame اعمال کنید:

```java
import com.aspose.slides.*;

// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است.
Presentation pres = new Presentation();
try {
    // تصویر را برای اضافه کردن به مجموعه تصاویر ارائه بارگیری می‌کند
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // فریم تصویر را به اسلاید اضافه می‌کند
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // دنباله اصلی اسلاید را دریافت می‌کند.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // اثر انیمیشن Fly از سمت چپ را به فریم تصویر اضافه می‌کند
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // فایل PPTX را روی دیسک ذخیره می‌کند
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **اعمال انیمیشن به Shape**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع اسلاید را از طریق شاخص آن به دست آورید.  
3. یک `rectangle` [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape) اضافه کنید.  
4. یک `Bevel` [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape) اضافه کنید (زمانی که این شیء کلیک شود، انیمیشن اجرا می‌شود).  
5. دنباله‌ای از اثرها بر روی شکل Bevel ایجاد کنید.  
6. یک `UserPath` سفارشی ایجاد کنید.  
7. دستورات برای حرکت به `UserPath` اضافه کنید.  
8. ارائه را به صورت فایل PPTX بر روی دیسک بنویسید.  

این کد جاوا نشان می‌دهد چگونه اثر `PathFootball` (path football) را به یک shape اعمال کنید:

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // اثر PathFootball را برای شکل موجود از ابتدا ایجاد می‌کند.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // افکت انیمیشن PathFootBall را اضافه می‌کند
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // یک نوع "دکمه" ایجاد می‌کند.
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // دنباله‌ای از اثرها را برای این دکمه ایجاد می‌کند.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // یک مسیر کاربر سفارشی ایجاد می‌کند. شیء ما فقط پس از کلیک روی دکمه جابه‌جا خواهد شد.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // دستورات حرکت را اضافه می‌کند چون مسیر ایجاد شده خالی است.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // فایل PPTX را روی دیسک می‌نویسد
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **دریافت اثرهای انیمیشن اعمال‌شده به یک Shape**

مثال‌های زیر نشان می‌دهند چگونه از متد `getEffectsByShape` در رابط [ISequence](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isequence/) برای دریافت تمام اثرهای انیمیشن اعمال‌شده به یک shape استفاده کنید.

**مثال 1: دریافت اثرهای انیمیشن اعمال‌شده به یک shape در اسلاید عادی**

قبلاً نحوه افزودن اثرهای انیمیشن به شکل‌ها در ارائه‌های PowerPoint را یاد گرفته‌اید. کد نمونه زیر نشان می‌دهد چگونه اثرهای اعمال‌شده به اولین shape در اولین اسلاید عادی در ارائه `AnimExample_out.pptx` را دریافت کنید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // دنباله اصلی انیمیشن اسلاید را دریافت می‌کند.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // اولین شکل در اسلاید اول را دریافت می‌کند.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // اثرهای انیمیشن اعمال‌شده به شکل را دریافت می‌کند.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**مثال 2: دریافت تمام اثرهای انیمیشن، از جمله آنهایی که از جای‌نگهدارها (placeholders) ارث‌بری شده‌اند**

اگر یک shape در اسلاید عادی دارای placeholdersی باشد که در اسلاید لایه‌بندی و/یا اسلاید اصلی قرار دارند و اثرهای انیمیشن به این placeholders اضافه شده باشد، تمام اثرهای shape در هنگام نمایش اسلاید اجرا می‌شوند، از جمله آنهایی که از placeholders ارث‌بری شده‌اند.

فرض کنید یک فایل ارائه PowerPoint به نام `sample.pptx` داریم که شامل یک اسلاید است که فقط یک shape فوتر با متن «Made with Aspose.Slides» دارد و اثر **Random Bars** بر روی آن shape اعمال شده است.

![اثر انیمیشن شکل اسلاید](slide-shape-animation.png)

همچنین فرض کنید که اثر **Split** بر روی placeholder فوتر در اسلاید **layout** اعمال شده است.

![اثر انیمیشن شکل لایه‌بندی](layout-shape-animation.png)

و در نهایت، اثر **Fly In** بر روی placeholder فوتر در اسلاید **master** اعمال شده است.

![اثر انیمیشن شکل مستر](master-shape-animation.png)

کد نمونه زیر نشان می‌دهد چگونه از متد `getBasePlaceholder` در رابط [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) برای دسترسی به placeholders شکل و دریافت اثرهای انیمیشن اعمال‌شده به shape فوتر، شامل اثرهای ارث‌بری از placeholders موجود در اسلایدهای layout و master استفاده کنید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
for (IEffect[] effects : new IEffect[][] { masterShapeEffects, layoutShapeEffects, shapeEffects }) {
    for (IEffect effect : effects) {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}

presentation.dispose();
```
```java
import com.aspose.slides.*;

static void printEffects(IEffect[] effects)
{
    for (IEffect effect : effects)
    {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}
```

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **تغییر خصوصیات زمان‌بندی اثر انیمیشن**

Aspose.Slides برای Android از طریق Java به شما اجازه می‌دهد خصوصیات Timing یک اثر انیمیشن را تغییر دهید.

این پنل زمان‌بندی انیمیشن در Microsoft PowerPoint است:

![پنل زمان‌بندی انیمیشن در Microsoft PowerPoint](shape-animation.png)

این‌ها تطبیق‌های بین Timing در PowerPoint و خصوصیات [Effect.Timing](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IEffect#getTiming--) هستند:

- فهرست کشویی **Start** در PowerPoint Timing با ویژگی [Effect.Timing.TriggerType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITiming#getTriggerType--) مطابقت دارد.  
- **Duration** در PowerPoint Timing با ویژگی [Effect.Timing.Duration](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITiming#getDuration--) مطابقت دارد. مدت زمان یک انیمیشن (به ثانیه) کل زمانی است که انیمیشن برای تکمیل یک دوره نیاز دارد.  
- **Delay** در PowerPoint Timing با ویژگی [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--) مطابقت دارد.  

به این صورت می‌توانید خصوصیات Timing اثر را تغییر دهید:

1. [Apply](#apply-animation-to-shape) یا دریافت اثر انیمیشن.  
2. مقادیر جدید برای ویژگی‌های [Effect.Timing](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IEffect#getTiming--) که نیاز دارید تنظیم کنید.  
3. فایل PPTX اصلاح‌شده را ذخیره کنید.  

این کد جاوا عملیات را نشان می‌دهد:

```java
import com.aspose.slides.*;

// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // دنباله اصلی اسلاید را دریافت می‌کند.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // اولین اثر دنباله اصلی را دریافت می‌کند.
    IEffect effect = sequence.get_Item(0);

    // نوع TriggerType اثر را به شروع با کلیک تغییر می‌دهد
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // مدت زمان اثر را تغییر می‌دهد
    effect.getTiming().setDuration(3f);

    // زمان تأخیر TriggerDelayTime اثر را تغییر می‌دهد
    effect.getTiming().setTriggerDelayTime(0.5f);

    // فایل PPTX را روی دیسک ذخیره می‌کند
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **صدا در اثر انیمیشن**

Aspose.Slides این ویژگی‌ها را برای کار با صداها در اثرهای انیمیشن فراهم می‌کند: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **افزودن صدا به اثر انیمیشن**

این کد جاوا نشان می‌دهد چگونه صدا به یک اثر انیمیشن اضافه کنید و هنگام شروع اثر بعدی متوقف کنید:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // صوت را به مجموعه صوت‌های ارائه اضافه می‌کند
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // دنباله اصلی اسلاید را دریافت می‌کند.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // اولین اثر دنباله اصلی را دریافت می‌کند
    IEffect firstEffect = sequence.get_Item(0);

    // اثر را برای «بدون صدا» بررسی می‌کند
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // صدا را برای اولین اثر اضافه می‌کند
        firstEffect.setSound(effectSound);
    }

    // اولین دنباله تعاملی اسلاید را دریافت می‌کند.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // پرچم «توقف صدای قبلی» اثر را تنظیم می‌کند
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // فایل PPTX را روی دیسک می‌نویسد
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **استخراج صدا از اثر انیمیشن**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.  
2. مرجع اسلاید را از طریق شاخص آن به دست آورید.  
3. دنباله اصلی اثرها را دریافت کنید.  
4. صداهای [setSound(IAudio value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) جاسازی شده در هر اثر انیمیشن را استخراج کنید.  

این کد جاوا نشان می‌دهد چگونه صدا را از یک اثر انیمیشن استخراج کنید:

```java
import com.aspose.slides.*;

// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // دنباله اصلی اسلاید را دریافت می‌کند.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // صدا را به صورت آرایه بایت استخراج می‌کند
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **پس از انیمیشن**

Aspose.Slides برای Android از طریق Java به شما امکان می‌دهد ویژگی After animation یک اثر انیمیشن را تغییر دهید.

این پنل اثر انیمیشن و منو گسترش یافته در Microsoft PowerPoint است:

![پنل اثر انیمیشن و منو گسترش یافته در Microsoft PowerPoint](shape-after-animation.png)

فهرست کشویی PowerPoint Effect **After animation** با این ویژگی‌ها مطابقت دارد: 

- ویژگی [setAfterAnimationType(int value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) که نوع After animation را توصیف می‌کند:  
  * **More Colors** در PowerPoint با نوع [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/afteranimationtype/#Color) مطابقت دارد؛  
  * **Don't Dim** در PowerPoint با نوع [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) مطابقت دارد (نوع پیش‌فرض after animation)؛  
  * **Hide After Animation** در PowerPoint با نوع [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation) مطابقت دارد؛  
  * **Hide on Next Mouse Click** در PowerPoint با نوع [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) مطابقت دارد؛  
- ویژگی [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) که یک قالب رنگی after animation را تعریف می‌کند. این ویژگی همراه با نوع [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/afteranimationtype/#Color) کار می‌کند. اگر نوع را به مقدار دیگری تغییر دهید، رنگ after animation پاک می‌شود.  

این کد جاوا نشان می‌دهد چگونه یک اثر after animation را تغییر دهید:

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // اولین اثر دنباله اصلی را دریافت می‌کند
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // نوع after animation را به Color تغییر می‌دهد
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // رنگ after animation را تنظیم می‌کند
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // فایل PPTX را روی دیسک می‌نویسد
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **انیمیشن متن**

Aspose.Slides این ویژگی‌ها را برای کار با بلوک *Animate text* یک اثر انیمیشن فراهم می‌کند:  

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) که نوع Animate text اثر را توصیف می‌کند. متن شکل می‌تواند به‌صورت:  
  - همه به‌یکباره ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce))  
  - برحسب کلمه ([AnimateTextType.ByWord](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/animatetexttype/#ByWord))  
  - برحسب حرف ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/animatetexttype/#ByLetter))  
  انیمیشن شود.  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) که تاخیر بین بخش‌های متنی (کلمات یا حروف) انیمیشن را تنظیم می‌کند. مقدار مثبت درصد مدت اثر را نشان می‌دهد؛ مقدار منفی تاخیر را بر حسب ثانیه مشخص می‌کند.  

به این صورت می‌توانید خصوصیات Animate text اثر را تغییر دهید:

1. [Apply](#apply-animation-to-shape) یا دریافت اثر انیمیشن.  
2. ویژگی [setBuildType(int value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) را به مقدار [BuildType.AsOneObject](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/buildtype/#AsOneObject) تنظیم کنید تا حالت انیمیشن *By Paragraphs* غیرفعال شود.  
3. مقادیر جدید برای ویژگی‌های [setAnimateTextType(int value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) و [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) تنظیم کنید.  
4. فایل PPTX اصلاح‌شده را ذخیره کنید.  

این کد جاوا عملیات را نشان می‌دهد:

```java
import com.aspose.slides.*;

// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است.
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // اولین اثر دنباله اصلی را دریافت می‌کند
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // نوع انیمیشن متن اثر را به "As One Object" تغییر می‌دهد
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // نوع Animate text اثر را به "By word" تغییر می‌دهد
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // تأخیر بین کلمات را به 20 درصد از مدت اثر تنظیم می‌کند
    firstEffect.setDelayBetweenTextParts(20f);

    // فایل PPTX را روی دیسک می‌نویسد
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

### چگونه می‌توانم اطمینان حاصل کنم که انیمیشن‌ها هنگام انتشار ارائه در وب حفظ می‌شوند؟

[Export to HTML5](/slides/fa/androidjava/export-to-html5/) را استفاده کنید و گزینه‌های مربوط به انیمیشن‌های [shape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و [transition](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) را فعال کنید. HTML ساده انیمیشن‌های اسلاید را اجرا نمی‌کند، در حالی که HTML5 این کار را انجام می‌دهد.

### تغییر ترتیب z-order (لایه) شکل‌ها چگونه بر انیمیشن‌ها تأثیر می‌گذارد؟

ترتیب انیمیشن و رسم بصورت مستقل هستند: یک اثر زمان‌بندی و نوع ظاهر شدن/از بین رفتن را کنترل می‌کند، در حالی که [z-order](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#getZOrderPosition--) تعیین می‌کند چه چیزی چه چیزی را می‌پوشاند. نتیجه قابل مشاهده ترکیب این دوست. (این رفتار عمومی PowerPoint است؛ مدل اثرها و شکل‌های Aspose.Slides نیز از همان منطق پیروی می‌کند.)

### آیا محدودیتی در تبدیل انیمیشن‌ها به ویدیو برای برخی اثرها وجود دارد؟

به طور کلی، [انیمیشن‌ها پشتیبانی می‌شوند](/slides/fa/androidjava/convert-powerpoint-to-video/)، اما در موارد نادر یا برای بعضی اثرها ممکن است به‌صورت متفاوتی رندر شوند. توصیه می‌شود که با اثرهای مورد استفاده و نسخه کتابخانه تست کنید.