---
title: اعمال انیمیشن‌های شکل در ارائه‌ها با استفاده از جاوا
linktitle: انیمیشن شکل
type: docs
weight: 60
url: /fa/java/shape-animation/
keywords:
- شکل
- انیمیشن
- افکت
- شکل انیمیشن‌دار
- متن انیمیشن‌دار
- افزودن انیمیشن
- دریافت انیمیشن
- استخراج انیمیشن
- افزودن افکت
- دریافت افکت
- استخراج افکت
- صدای افکت
- اعمال انیمیشن
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "کشف کنید چگونه می‌توان انیمیشن‌های شکل را در ارائه‌های پاورپوینت با Aspose.Slides برای جاوا ایجاد و سفارشی‌سازی کرد. متمایز شوید!"
---
## **مقدمه**

انیمیشن‌ها افکت‌های بصری هستند که می‌توانند بر روی متن‌ها، تصاویر، شکل‌ها یا [نمودارها](https://docs.aspose.com/slides/fa/java/animated-charts/) اعمال شوند. آن‌ها به ارائه‌ها یا اجزای آن جان می‌بخشند. 

## **چرا از انیمیشن‌ها در ارائه‌ها استفاده کنیم؟**

با استفاده از انیمیشن‌ها می‌توانید  

* کنترل جریان اطلاعات  
* برجسته‌سازی نکات مهم  
* افزایش علاقه یا مشارکت مخاطبان  
* آسان‌تر کردن خواندن یا درک یا پردازش محتوا  
* جلب توجه خوانندگان یا بینندگان به بخش‌های مهم در یک ارائه  

PowerPoint گزینه‌ها و ابزارهای متعددی برای انیمیشن‌ها و افکت‌های انیمیشن در دسته‌های **ورودی**، **خروجی**، **تاکید** و **مسیرهای حرکتی** فراهم می‌کند. 

## **انیمیشن‌ها در Aspose.Slides**

* Aspose.Slides کلاس‌ها و انواع مورد نیاز برای کار با انیمیشن‌ها را تحت فضای نام `Aspose.Slides.Animation` فراهم می‌کند،  
* Aspose.Slides بیش از **150 افکت انیمیشن** را تحت شمارش‌گر [EffectType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/effecttype) ارائه می‌دهد. این افکت‌ها عملاً همان افکت‌های استفاده شده در PowerPoint هستند (یا معادل آن‌ها).  

## **اعمال انیمیشن به TextBox**

Aspose.Slides برای Java به شما امکان می‌دهد انیمیشن را بر متن داخل یک شکل اعمال کنید. 

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را بر اساس شاخص آن دریافت کنید.  
3. یک `rectangle` [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape) اضافه کنید.  
4. متن را به [IAutoShape.TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) اضافه کنید.  
5. دنباله اصلی افکت‌ها را دریافت کنید.  
6. یک افکت انیمیشن به [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape) اضافه کنید.  
7. ویژگی `TextAnimation.BuildType` را به مقدار موجود در شمارش‌گر `BuildType` تنظیم کنید.  
8. ارائه را به صورت فایل PPTX روی دیسک ذخیره کنید.  

این کد Java نشان می‌دهد چگونه افکت `Fade` را به AutoShape اعمال کنید و انیمیشن متن را به مقدار *By 1st Level Paragraphs* تنظیم کنید:  

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation ایجاد می‌کند که یک فایل ارائه را نشان می‌دهد.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // یک AutoShape جدید با متن اضافه می‌کند
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // دنباله اصلی اسلاید را دریافت می‌کند.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // افکت انیمیشن Fade را به شکل اضافه می‌کند
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // متن شکل را بر اساس پاراگراف‌های سطح 1 انیمیشن می‌کند
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // فایل PPTX را روی دیسک ذخیره می‌کند
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 

علاوه بر اعمال انیمیشن بر متن، می‌توانید انیمیشن را به یک [Paragraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraph) واحد نیز اعمال کنید. مشاهده کنید [**متن انیمیشنی**](/slides/fa/java/animated-text/).  

{{% /alert %}} 

## **اعمال انیمیشن به PictureFrame**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را بر اساس شاخص آن دریافت کنید.  
3. یک [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pictureframe) را در اسلاید اضافه کنید یا دریافت کنید.  
4. دنباله اصلی افکت‌ها را دریافت کنید.  
5. یک افکت انیمیشن به [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pictureframe) اضافه کنید.  
6. ارائه را به صورت فایل PPTX روی دیسک ذخیره کنید.  

این کد Java نشان می‌دهد چگونه افکت `Fly` را به یک فریم تصویر اعمال کنید:  

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation ایجاد می‌کند که یک فایل ارائه را نشان می‌دهد.
Presentation pres = new Presentation();
try {
    // تصویر را برای اضافه شدن به مجموعه تصویرهای ارائه بارگذاری می‌کند
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // یک فریم تصویر به اسلاید اضافه می‌کند
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

## **اعمال انیمیشن به یک Shape**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را بر اساس شاخص آن دریافت کنید.  
3. یک `rectangle` [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape) اضافه کنید.  
4. یک `Bevel` [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape) اضافه کنید (زمانی که این شیء کلیک شود، انیمیشن اجرا می‌شود).  
5. دنباله‌ای از افکت‌ها بر روی شکل Bevel ایجاد کنید.  
6. یک `UserPath` سفارشی ایجاد کنید.  
7. دستورات برای حرکت به `UserPath` اضافه کنید.  
8. ارائه را به صورت فایل PPTX روی دیسک ذخیره کنید.  

این کد Java نشان می‌دهد چگونه افکت `PathFootball` (مسیر فوتبال) را به یک شکل اعمال کنید:  

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// یک نمونه از کلاس Presentation ایجاد می‌کند که یک فایل PPTX را نشان می‌دهد.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // افکت PathFootball را برای شکل موجود از ابتدا ایجاد می‌کند.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // افکت انیمیشن PathFootBall را اضافه می‌کند
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // نوعی "دکمه" ایجاد می‌کند.
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // دنباله‌ای از افکت‌ها برای این دکمه ایجاد می‌کند.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // مسیر کاربری سفارشی ایجاد می‌کند. شیء ما فقط پس از کلیک روی دکمه جابه‌جا می‌شود.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // فرمان‌های جابه‌جایی را اضافه می‌کند چون مسیر ایجاد شده خالی است.
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

## **دریافت افکت‌های انیمیشن اعمال شده به یک Shape**

مثال‌های زیر نشان می‌دهند چگونه از متد `getEffectsByShape` در رابط [ISequence](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isequence/) برای دریافت تمام افکت‌های انیمیشن اعمال شده به یک شکل استفاده کنید.  

**مثال ۱: دریافت افکت‌های انیمیشن اعمال شده به یک شکل در اسلاید عادی**  

قبلاً یاد گرفته‌اید چگونه افکت‌های انیمیشن را به شکل‌ها در ارائه‌های PowerPoint اضافه کنید. کد نمونه زیر نشان می‌دهد چگونه افکت‌های اعمال شده به اولین شکل در اولین اسلاید عادی ارائه `AnimExample_out.pptx` را دریافت کنید.  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // دنباله اصلی انیمیشن اسلاید را دریافت می‌کند.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // اولین شکل در اولین اسلاید را دریافت می‌کند.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // افکت‌های انیمیشن اعمال‌شده به شکل را دریافت می‌کند.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**مثال ۲: دریافت تمام افکت‌های انیمیشن، شامل آنهایی که از جای‌دارها به ارث رسیده‌اند**  

اگر یک شکل در اسلاید عادی دارای جای‌دارهایی باشد که در اسلاید قالب و/یا اسلاید اصلی قرار دارند و افکت‌های انیمیشن به این جای‌دارها اضافه شده باشد، تمام افکت‌های شکل در خلال نمایش اسلاید اجرا می‌شود، از جمله افکت‌های به ارث‌رفته از جای‌دارها.  

فرض کنید فایل ارائه PowerPoint `sample.pptx` داریم که یک اسلاید شامل فقط یک شکل پایین (footer) با متن "Made with Aspose.Slides" دارد و افکت **Random Bars** بر روی آن شکل اعمال شده است.  

![افکت انیمیشن شکل اسلاید](slide-shape-animation.png)

همچنین فرض کنید افکت **Split** بر روی جای‌دار پایینی در اسلاید **layout** اعمال شده است.  

![افکت انیمیشن شکل قالب](layout-shape-animation.png)

و در نهایت، افکت **Fly In** بر روی جای‌دار پایینی در اسلاید **master** اعمال شده است.  

![افکت انیمیشن شکل اصلی](master-shape-animation.png)

کد نمونه زیر نشان می‌دهد چگونه از متد `getBasePlaceholder` در رابط [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) برای دسترسی به جای‌دارهای شکل و دریافت افکت‌های انیمیشن اعمال شده به شکل پایینی استفاده کنید، شامل افکت‌های به ارث‌رفته از جای‌دارهای موجود در اسلایدهای قالب و اصلی.  

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

```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **تغییر ویژگی‌های زمان‌بندی افکت انیمیشن**

Aspose.Slides برای Java به شما امکان می‌دهد ویژگی‌های Timing یک افکت انیمیشن را تغییر دهید.  

این پنل زمان‌بندی انیمیشن در Microsoft PowerPoint است:  

![پنل زمان‌بندی انیمیشن](shape-animation.png)

این‌ها تطابق‌های بین زمان‌بندی PowerPoint و ویژگی‌های [Effect.Timing](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IEffect#getTiming--) هستند:  

- فهرست کشویی **Start** در PowerPoint Timing با ویژگی [Effect.Timing.TriggerType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITiming#getTriggerType--) مطابقت دارد.  
- PowerPoint Timing **Duration** با ویژگی [Effect.Timing.Duration](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITiming#getDuration--) مطابقت دارد. مدت زمان یک انیمیشن (به ثانیه) کل زمانی است که برای تکمیل یک چرخه صرف می‌شود.  
- PowerPoint Timing **Delay** با ویژگی [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITiming#getTriggerDelayTime--) مطابقت دارد.  

این نحوه تغییر ویژگی‌های زمان‌بندی افکت است:  

1. یک افکت انیمیشن را [اعمال](#apply-animation-to-shape) کنید یا دریافت کنید.  
2. مقادیر جدیدی برای ویژگی‌های [Effect.Timing](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IEffect#getTiming--) که نیاز دارید تنظیم کنید.  
3. فایل PPTX اصلاح‌شده را ذخیره کنید.  

این کد Java عملیات را نشان می‌دهد:  

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation ایجاد می‌کند که یک فایل ارائه را نشان می‌دهد.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // دنباله اصلی اسلاید را دریافت می‌کند.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // اولین افکت دنباله اصلی را دریافت می‌کند.
    IEffect effect = sequence.get_Item(0);

    // نوع TriggerType افکت را به شروع با کلیک تغییر می‌دهد
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // مدت زمان افکت را تغییر می‌دهد
    effect.getTiming().setDuration(3f);

    // زمان تأخیر TriggerDelayTime افکت را تغییر می‌دهد
    effect.getTiming().setTriggerDelayTime(0.5f);

    // فایل PPTX را روی دیسک ذخیره می‌کند
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **صدای افکت انیمیشن**

Aspose.Slides این ویژگی‌ها را برای کار با صداها در افکت‌های انیمیشن ارائه می‌دهد:  

- [setSound(IAudio value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-)  

### **افزودن صدا به افکت انیمیشن**

این کد Java نشان می‌دهد چگونه صدا به افکت انیمیشن اضافه کرده و هنگام شروع افکت بعدی آن را متوقف کنید:  

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // صدایی را به مجموعه صداهای ارائه اضافه می‌کند
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // دنباله اصلی اسلاید را دریافت می‌کند.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // اولین افکت دنباله اصلی را دریافت می‌کند
    IEffect firstEffect = sequence.get_Item(0);

    // افکت را برای «بدون صدا» بررسی می‌کند
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // صدایی برای اولین افکت اضافه می‌کند
        firstEffect.setSound(effectSound);
    }

    // اولین دنباله تعاملی اسلاید را دریافت می‌کند.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // پرچم «متوقف کردن صدای قبلی» افکت را تنظیم می‌کند
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // فایل PPTX را روی دیسک می‌نویسد
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **استخراج صدا از افکت انیمیشن**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.  
2. مرجع یک اسلاید را بر اساس شاخص آن دریافت کنید.  
3. دنباله اصلی افکت‌ها را دریافت کنید.  
4. متد [setSound(IAudio value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) تعبیه‌شده در هر افکت انیمیشن را استخراج کنید.  

این کد Java نشان می‌دهد چگونه صدای تعبیه‌شده در یک افکت انیمیشن را استخراج کنید:  

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation ایجاد می‌کند که یک فایل ارائه را نشان می‌دهد.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // دنباله اصلی اسلاید را دریافت می‌کند.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // صداهای افکت را به صورت آرایه بایت استخراج می‌کند
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **پس از انیمیشن**

Aspose.Slides برای Java به شما امکان می‌دهد ویژگی After animation یک افکت انیمیشن را تغییر دهید.  

این پنل افکت انیمیشن و منوی توسعه‌یافته در Microsoft PowerPoint است:  

![پنل افکت انیمیشن](shape-after-animation.png)

فهرست کشویی **After animation** در PowerPoint Effect با این ویژگی‌ها مطابقت دارد:  

- ویژگی [setAfterAnimationType(int value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) که نوع After animation را توصیف می‌کند :  
  * PowerPoint **More Colors** با نوع [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/java/com.aspose.slides/afteranimationtype/#Color) مطابقت دارد؛  
  * مورد **Don't Dim** در PowerPoint با نوع [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/fa/java/com.aspose.slides/afteranimationtype/#DoNotDim) مطابقت دارد (نوع پیش‌فرض After animation)؛  
  * مورد **Hide After Animation** در PowerPoint با نوع [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation) مطابقت دارد؛  
  * مورد **Hide on Next Mouse Click** در PowerPoint با نوع [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/fa/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) مطابقت دارد؛  
- ویژگی [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) که فرمت رنگ After animation را تعریف می‌کند. این ویژگی همراه با نوع [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/java/com.aspose.slides/afteranimationtype/#Color) کار می‌کند. اگر نوع را به مقدار دیگری تغییر دهید، رنگ After animation پاک خواهد شد.  

این کد Java نشان می‌دهد چگونه یک افکت After animation را تغییر دهید:  

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک نمونه از کلاس Presentation ایجاد می‌کند که یک فایل ارائه را نشان می‌دهد
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // اولین افکت دنباله اصلی را دریافت می‌کند
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // نوع after animation را به Color تغییر می‌دهد
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // رنگ محو‌سازی after animation را تنظیم می‌کند
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // فایل PPTX را روی دیسک می‌نویسد
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **انیمیشن متن**

Aspose.Slides این ویژگی‌ها را برای کار با بلوک *Animate text* یک افکت انیمیشن ارائه می‌دهد:  

- ویژگی [setAnimateTextType(int value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) که نوع Animate text افکت را توصیف می‌کند. متن شکل می‌تواند انیمیشن شود:  
  * تماماً به‌صورت همزمان ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/fa/java/com.aspose.slides/animatetexttype/#AllAtOnce) نوع)؛  
  * به‌صورت کلمه به کلمه ([AnimateTextType.ByWord](https://reference.aspose.com/slides/fa/java/com.aspose.slides/animatetexttype/#ByWord) نوع)؛  
  * به‌صورت حرف به حرف ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/fa/java/com.aspose.slides/animatetexttype/#ByLetter) نوع)؛  
- ویژگی [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) تاخیر بین بخش‌های متن انیمیشن‌شده (کلمات یا حروف) را تنظیم می‌کند. مقدار مثبت درصد مدت افکت را مشخص می‌کند. مقدار منفی تاخیر را بر حسب ثانیه تعیین می‌کند.  

این نحوه تغییر ویژگی‌های Animate text افکت است:  

1. یک افکت انیمیشن را [اعمال](#apply-animation-to-shape) کنید یا دریافت کنید.  
2. ویژگی [setBuildType(int value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextanimation/#setBuildType-int-) را به مقدار [BuildType.AsOneObject](https://reference.aspose.com/slides/fa/java/com.aspose.slides/buildtype/#AsOneObject) تنظیم کنید تا حالت انیمیشن *By Paragraphs* غیرفعال شود.  
3. مقادیر جدیدی برای ویژگی‌های [setAnimateTextType(int value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) و [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) تنظیم کنید.  
4. فایل PPTX اصلاح‌شده را ذخیره کنید.  

این کد Java عملیات را نشان می‌دهد:  

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation ایجاد می‌کند که یک فایل ارائه را نشان می‌دهد.
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // اولین افکت دنباله اصلی را دریافت می‌کند
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // نوع انیمیشن متن افکت را به "As One Object" تغییر می‌دهد
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // نوع Animate text افکت را به "By word" تغییر می‌دهد
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // تاخیر بین کلمات را به 20% از مدت افکت تنظیم می‌کند
    firstEffect.setDelayBetweenTextParts(20f);

    // فایل PPTX را روی دیسک می‌نویسد
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سؤالات متداول**

### چگونه می‌توانم اطمینان حاصل کنم که انیمیشن‌ها هنگام انتشار ارائه در وب حفظ می‌شوند؟

[Export to HTML5](/slides/fa/java/export-to-html5/) و فعال کردن [options](https://reference.aspose.com/slides/fa/java/com.aspose.slides/html5options/) که مسئول انیمیشن‌های [shape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و [transition](https://reference.aspose.com/slides/fa/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) هستند. HTML ساده انیمیشن‌های اسلاید را پخش نمی‌کند، در حالی که HTML5 این کار را می‌کند.  

### تغییر ترتیب z (لایه) اشکال چگونه بر انیمیشن تاثیر می‌گذارد؟

انیمیشن و ترتیب رسم به‌صورت مستقل هستند: یک افکت زمان‌بندی و نوع ظهور/ناپدید شدن را کنترل می‌کند، در حالی که [z-order](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#getZOrderPosition--) تعیین می‌کند کدام عنصر بر دیگری قرار می‌گیرد. نتیجهٔ قابل مشاهده ترکیب این دو است. (این رفتار کلی PowerPoint است؛ مدل افکت‌ها و اشکال Aspose.Slides همین منطق را دنبال می‌کند.)  

### آیا محدودیت‌هایی هنگام تبدیل انیمیشن‌ها به ویدئو برای برخی افکت‌ها وجود دارد؟

به‌طور کلی، [انیمیشن‌ها پشتیبانی می‌شوند](/slides/fa/java/convert-powerpoint-to-video/)، اما در موارد نادر یا برای افکت‌های خاص ممکن است به‌صورت متفاوتی رندر شوند. توصیه می‌شود با افکت‌هایی که استفاده می‌کنید و با نسخهٔ کتابخانه تست کنید.