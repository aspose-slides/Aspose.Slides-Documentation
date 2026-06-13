---
title: اعمال انیمیشن‌های شکل در ارائه‌ها روی اندروید
linktitle: انیمیشن شکل
type: docs
weight: 60
url: /fa/androidjava/shape-animation/
keywords:
- شکل
- انیمیشن
- اثر
- شکل انیمیشنی
- متن انیمیشن‌دار
- افزودن انیمیشن
- دریافت انیمیشن
- استخراج انیمیشن
- افزودن اثر
- دریافت اثر
- استخراج اثر
- صدای اثر
- اعمال انیمیشن
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید انیمیشن‌های شکل را در ارائه‌های PowerPoint با Aspose.Slides برای اندروید از طریق جاوا ایجاد و سفارشی کنید. برجسته باشید!"
---
## **معرفی**

انیمیشن‌ها جلوه‌های بصری هستند که می‌توانند بر روی متن‌ها، تصاویر، اشکال یا [نمودارها](https://docs.aspose.com/slides/fa/androidjava/animated-charts/) اعمال شوند. آن‌ها زندگی به ارائه‌ها یا اجزای آن می‌بخشند.

## **چرا در ارائه‌ها از انیمیشن استفاده کنیم؟**

با استفاده از انیمیشن، می‌توانید 

* کنترل جریان اطلاعات
* تأکید بر نکات مهم
* افزایش علاقه یا مشارکت مخاطبان
* آسان‌تر کردن خواندن یا هضم یا پردازش محتوا
* جلب توجه خوانندگان یا بینندگان به بخش‌های مهم در یک ارائه

PowerPoint گزینه‌ها و ابزارهای متعددی برای انیمیشن‌ها و اثرهای انیمیشن در دسته‌های **ورود**, **خروج**, **تاکید** و **مسیرهای حرکتی** فراهم می‌کند. 

## **انیمیشن‌ها در Aspose.Slides**

* Aspose.Slides کلاس‌ها و نوع‌هایی را که برای کار با انیمیشن‌ها نیاز دارید، تحت فضای نام `Aspose.Slides.Animation` فراهم می‌کند،
* Aspose.Slides بیش از **150 اثر انیمیشن** را تحت شمارش‌گر [EffectType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/effecttype) ارائه می‌دهد. این اثرها در اصل همان اثرهای (یا معادل) مورد استفاده در PowerPoint هستند.

## **اعمال انیمیشن بر TextBox**

Aspose.Slides برای Android از طریق Java به شما امکان می‌دهد انیمیشن را به متن داخل یک شکل اعمال کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسلاید را از طریق ایندکس آن بدست آورید.
3. یک `rectangle` [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape) اضافه کنید.
4. متن را به [IAutoShape.TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) اضافه کنید.
5. یک دنباله اصلی از اثرها را دریافت کنید.
6. یک اثر انیمیشن به [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape) اضافه کنید.
7. ویژگی `TextAnimation.BuildType` را به مقداری از شمارش‌گر `BuildType` تنظیم کنید.
8. ارائه را به صورت فایل PPTX روی دیسک بنویسید.

این کد Java نشان می‌دهد چگونه اثر `Fade` را به AutoShape اعمال کنید و انیمیشن متن را به مقدار *By 1st Level Paragraphs* تنظیم کنید:

```java
// یک کلاس ارائه را که نمایانگر یک فایل ارائه است، نمونه‌سازی می‌کند.
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

    // متن شکل را بر اساس پاراگراف‌های سطح اول انیمیت می‌کند
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // فایل PPTX را بر روی دیسک ذخیره می‌کند
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

علاوه بر اعمال انیمیشن به متن، می‌توانید انیمیشن را به یک [Paragraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph) تک‌تک نیز اعمال کنید. به ‎[**Animated Text**](/slides/fa/androidjava/animated-text/)‎ مراجعه کنید.

{{% /alert %}} 

## **اعمال انیمیشن بر PictureFrame**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
2. مرجع اسلاید را از طریق ایندکس آن بدست آورید.
3. یک [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pictureframe) را به اسلاید اضافه یا دریافت کنید.
4. دنباله اصلی اثرها را دریافت کنید.
5. یک اثر انیمیشن به [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pictureframe) اضافه کنید.
6. ارائه را به صورت فایل PPTX روی دیسک بنویسید.

این کد Java نشان می‌دهد چگونه اثر `Fly` را به یک فریم تصویر اعمال کنید:

```java
// یک کلاس Presentation را که نمایانگر یک فایل ارائه است، نمونه‌سازی می‌کند.
Presentation pres = new Presentation();
try {
    // تصویری را که باید به مجموعه تصاویر ارائه اضافه شود، بارگذاری می‌کند
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

    // فایل PPTX را بر روی دیسک ذخیره می‌کند
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **اعمال انیمیشن بر Shape**

1. یک نمونه از ‎[Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation)‎ ایجاد کنید.
2. مرجع اسلاید را از طریق ایندکس آن بدست آورید.
3. یک `rectangle` [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape) اضافه کنید.
4. یک `Bevel` [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape) اضافه کنید (زمانی که این شیء کلیک شود، انیمیشن اجرا می‌شود).
5. یک دنباله از اثرها روی شکل Bevel ایجاد کنید.
6. یک `UserPath` سفارشی ایجاد کنید.
7. دستورات برای حرکت به `UserPath` اضافه کنید.
8. ارائه را به صورت فایل PPTX روی دیسک بنویسید.

این کد Java نشان می‌دهد چگونه اثر `PathFootball` (پات فوتبال) را به یک شکل اعمال کنید:

```java
// یک کلاس Presentation را که نمایانگر یک فایل PPTX است، نمونه‌سازی می‌کند.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // اثر PathFootball را برای شکل موجود از ابتدا ایجاد می‌کند.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // اثر انیمیشن PathFootBall را اضافه می‌کند
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // نوعی "دکمه" ایجاد می‌کند.
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // یک دنباله از اثرها برای این دکمه ایجاد می‌کند.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // یک مسیر سفارشی کاربر ایجاد می‌کند. شیء ما فقط پس از کلیک روی دکمه جابه‌جا خواهد شد.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // دستورات جابجایی را اضافه می‌کند چون مسیر ایجاد شده خالی است.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // فایل PPTX را بر روی دیسک ذخیره می‌کند
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **دریافت اثرهای انیمیشن اعمال شده به یک Shape**

مثال‌های زیر نشان می‌دهند چطور از متد `getEffectsByShape` در رابط [ISequence](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isequence/) برای دریافت تمام اثرهای انیمیشن اعمال شده به یک شکل استفاده کنید.

**مثال ۱: دریافت اثرهای انیمیشن اعمال شده به یک شکل در اسلاید عادی**

قبلاً یاد گرفتید چگونه اثرهای انیمیشن را به اشکال در ارائه‌های PowerPoint اضافه کنید. کد نمونه زیر نشان می‌دهد چطور اثرهای اعمال شده به اولین شکل در اولین اسلاید عادی در ارائه `AnimExample_out.pptx` را دریافت کنید.

```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // دنباله اصلی انیمیشن اسلاید را دریافت می‌کند.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // شکل اول در اولین اسلاید را دریافت می‌کند.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // اثرهای انیمیشن اعمال شده به شکل را دریافت می‌کند.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**مثال ۲: دریافت تمام اثرهای انیمیشن، شامل آنهایی که از جای‌نگهدارها به ارث برده شده‌اند**

اگر یک شکل در اسلاید عادی دارای جای‌نگهدارهایی باشد که در اسلاید چیدمان و/یا اسلاید اصلی قرار دارند و اثرهای انیمیشن به این جای‌نگهدارها اضافه شده باشد، تمام اثرهای شکل در طول نمایش اسلاید اجرا می‌شوند، شامل آنهایی که از جای‌نگهدارها به ارث برده شده‌اند.

فرض کنید فایلی به نام `sample.pptx` داریم که شامل یک اسلاید است و فقط یک شکل پاورقی با متن «Made with Aspose.Slides» دارد و اثر **Random Bars** بر روی این شکل اعمال شده است.

![اثر انیمیشن شکل اسلاید](slide-shape-animation.png)

همچنین فرض کنید اثر **Split** بر روی جای‌نگهدار پاورقی در اسلاید **layout** اعمال شده باشد.

![اثر انیمیشن شکل چیدمان](layout-shape-animation.png)

و در نهایت، اثر **Fly In** بر روی جای‌نگهدار پاورقی در اسلاید **master** اعمال شده باشد.

![اثر انیمیشن شکل اصلی](master-shape-animation.png)

کد نمونه زیر نشان می‌دهد چگونه از متد `getBasePlaceholder` در رابط [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) برای دسترسی به جای‌نگهدارهای شکل و دریافت اثرهای انیمیشن اعمال شده به شکل پاورقی، شامل آنهایی که از جای‌نگهدارهای موقعیت‌های چیدمان و اصلی به ارث برده شده‌اند، استفاده کنید.

```java
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
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```java
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

## **تغییر ویژگی‌های زمان‌بندی اثر انیمیشن**

Aspose.Slides برای Android از طریق Java به شما امکان می‌دهد ویژگی‌های زمان‌بندی یک اثر انیمیشن را تغییر دهید.

این پنل زمان‌بندی انیمیشن در Microsoft PowerPoint است:

![example1_image](shape-animation.png)

این‌ها تطابق‌های بین زمان‌بندی PowerPoint و ویژگی‌های [Effect.Timing](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IEffect#getTiming--) هستند:

- لیست کشویی **Start** در PowerPoint با ویژگی [Effect.Timing.TriggerType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITiming#getTriggerType--) مطابقت دارد.
- **Duration** در PowerPoint با ویژگی [Effect.Timing.Duration](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITiming#getDuration--) مطابقت دارد. مدت زمان یک انیمیشن (بر حسب ثانیه) کل زمان لازم برای تکمیل یک چرخه انیمیشن است.
- **Delay** در PowerPoint با ویژگی [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--) مطابقت دارد.

این نحوه تغییر ویژگی‌های زمان‌بندی Effect است:

1. [Apply](#apply-animation-to-shape) یا دریافت اثر انیمیشن.
2. مقادیر جدید را برای ویژگی‌های [Effect.Timing](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IEffect#getTiming--) که نیاز دارید، تنظیم کنید.
3. فایل PPTX اصلاح‌شده را ذخیره کنید.

این کد Java عملیات را نشان می‌دهد:

```java
// یک کلاس Presentation را که نمایانگر یک فایل ارائه است، نمونه‌سازی می‌کند.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // دنباله اصلی اسلاید را دریافت می‌کند.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // اولین اثر در دنباله اصلی را دریافت می‌کند.
    IEffect effect = sequence.get_Item(0);

    // نوع TriggerType اثر را به شروع با کلیک تغییر می‌دهد
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // مدت زمان اثر را تغییر می‌دهد
    effect.getTiming().setDuration(3f);

    // زمان تاخیر TriggerDelayTime اثر را تغییر می‌دهد
    effect.getTiming().setTriggerDelayTime(0.5f);

    // فایل PPTX را بر روی دیسک ذخیره می‌کند
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **صدا در اثر انیمیشن**

Aspose.Slides این ویژگی‌ها را برای کار با صداها در اثرهای انیمیشن فراهم می‌کند: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **افزودن صدا به یک اثر انیمیشن**

این کد Java نشان می‌دهد چگونه صدا به یک اثر انیمیشن اضافه کنید و هنگام شروع اثر بعدی آن را متوقف کنید:

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // صدا را به مجموعه صداهای ارائه اضافه می‌کند
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // دنباله اصلی اسلاید را دریافت می‌کند.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // اولین اثر دنباله اصلی را دریافت می‌کند
    IEffect firstEffect = sequence.get_Item(0);

    // اثر را برای «No Sound» بررسی می‌کند
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // صدا را برای اولین اثر اضافه می‌کند
        firstEffect.setSound(effectSound);
    }

    // دنباله تعاملی اول اسلاید را دریافت می‌کند.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // پرچم «Stop previous sound» اثر را تنظیم می‌کند
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // فایل PPTX را بر روی دیسک ذخیره می‌کند
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **استخراج صدا از یک اثر انیمیشن**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. مرجع اسلاید را از طریق ایندکس آن بدست آورید. 
3. دنباله اصلی اثرها را دریافت کنید. 
4. صداهای جاسازی‌شده در هر اثر انیمیشن را با استفاده از متد [setSound(IAudio value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) استخراج کنید.

این کد Java نشان می‌دهد چگونه صداهای جاسازی‌شده در یک اثر انیمیشن را استخراج کنید:

```java
// یک کلاس Presentation را که نمایانگر یک فایل ارائه است، نمونه‌سازی می‌کند.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // دنباله اصلی اسلاید را دریافت می‌کند.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // صدای اثر را به صورت آرایه بایت استخراج می‌کند
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **After Animation**

Aspose.Slides برای Android از طریق Java به شما امکان می‌دهد ویژگی After animation یک اثر انیمیشن را تغییر دهید.

این پنل اثر انیمیشن و منوی گسترش‌یافته در Microsoft PowerPoint است:

![example1_image](shape-after-animation.png)

لیست کشویی **After animation** در PowerPoint با این ویژگی‌ها مطابقت دارد: 

- ویژگی [setAfterAnimationType(int value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) که نوع After animation را توصیف می‌کند:
  * **More Colors** در PowerPoint با نوع [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/afteranimationtype/#Color) مطابقت دارد;
  * گزینه **Don't Dim** در PowerPoint با نوع [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) (نوع پیش‌فرض) مطابقت دارد;
  * گزینه **Hide After Animation** در PowerPoint با نوع [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation) مطابقت دارد;
  * گزینه **Hide on Next Mouse Click** در PowerPoint با نوع [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) مطابقت دارد;
- ویژگی [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) که فرمت رنگ After animation را تعریف می‌کند. این ویژگی همراه با نوع [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/afteranimationtype/#Color) کار می‌کند. اگر نوع را به مقدار دیگری تغییر دهید، رنگ After animation پاک می‌شود.

این کد Java نشان می‌دهد چگونه یک اثر After animation را تغییر دهید:

```java
// یک کلاس Presentation را که نمایانگر یک فایل ارائه است، نمونه‌سازی می‌کند
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // اولین اثر دنباله اصلی را دریافت می‌کند
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // نوع After animation را به Color تغییر می‌دهد
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // رنگ پس‌از انیمیشن را تنظیم می‌کند
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // فایل PPTX را بر روی دیسک ذخیره می‌کند
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animate Text**

Aspose.Slides این ویژگی‌ها را برای کار با بخش *Animate text* یک اثر انیمیشن فراهم می‌کند:

- ویژگی [setAnimateTextType(int value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) که نوع animate text اثر را توصیف می‌کند. متن شکل می‌تواند به صورت:
  - همه به‌یک‌باره ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce))
  - به‌صورت کلمه‌ای ([AnimateTextType.ByWord](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/animatetexttype/#ByWord))
  - به‌صورت حرفی ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/animatetexttype/#ByLetter))
  انیمیت شود.
- ویژگی [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) که تاخیر بین بخش‌های متن انیمیشنی (کلمات یا حروف) را تنظیم می‌کند. مقدار مثبت درصد مدت اثر را مشخص می‌کند. مقدار منفی تاخیر را برحسب ثانیه تعیین می‌کند.

این نحوه تغییر ویژگی‌های Animate text برای Effect است:

1. [Apply](#apply-animation-to-shape) یا دریافت اثر انیمیشن.
2. ویژگی [setBuildType(int value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) را به مقدار [BuildType.AsOneObject](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/buildtype/#AsOneObject) تنظیم کنید تا حالت انیمیشن *By Paragraphs* غیرفعال شود.
3. مقادیر جدید را برای ویژگی‌های [setAnimateTextType(int value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) و [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) تنظیم کنید.
4. فایل PPTX اصلاح‌شده را ذخیره کنید.

این کد Java عملیات را نشان می‌دهد:

```java
// یک کلاس Presentation را که نمایانگر یک فایل ارائه است، نمونه‌سازی می‌کند.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // اولین اثر دنباله اصلی را دریافت می‌کند
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // نوع انیمیشن متن اثر را به As One Object تغییر می‌دهد
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // نوع Animate text اثر را به By word تغییر می‌دهد
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // تاخیر بین کلمات را به 20 درصد از مدت اثر تنظیم می‌کند
    firstEffect.setDelayBetweenTextParts(20f);

    // فایل PPTX را بر روی دیسک ذخیره می‌کند
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**چگونه می‌توانم اطمینان حاصل کنم که انیمیشن‌ها هنگام انتشار ارائه در وب حفظ می‌شوند؟**

[Export to HTML5](/slides/fa/androidjava/export-to-html5/) را استفاده کنید و گزینه‌های [shape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و [transition](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) که مسئول انیمیشن‌ها هستند، فعال کنید. HTML ساده انیمیشن اسلاید را پخش نمی‌کند، در حالی که HTML5 این کار را انجام می‌دهد.

**تغییر ترتیب لایه (z-order) اشکال چگونه بر انیمیشن تأثیر می‌گذارد؟**

ترتیب انیمیشن و ترتیب ترسیم مستقل هستند: یک اثر زمان‌بندی و نوع ظاهر شدن/نقشیدن را کنترل می‌کند، در حالی که [z-order](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#getZOrderPosition--) تعیین می‌کند چه چیزی چه چیزی را می‌پوشاند. نتیجه قابل مشاهده ترکیبی از این دو است. (این رفتار عمومی PowerPoint است؛ مدل اثرها و اشکال Aspose.Slides نیز همان منطق را دنبال می‌کند.)

**آیا محدودیتی در تبدیل انیمیشن‌ها به ویدیو برای برخی اثرها وجود دارد؟**

به طور کلی، [انیمیشن‌ها پشتیبانی می‌شوند](/slides/fa/androidjava/convert-powerpoint-to-video/)، اما در موارد نادر یا برای اثرهای خاص ممکن است به شکل متفاوتی رندر شوند. توصیه می‌شود اثرهایی که استفاده می‌کنید و نسخه کتابخانه را آزمایش کنید.