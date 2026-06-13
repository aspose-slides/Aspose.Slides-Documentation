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
- شکل متحرک
- متن متحرک
- افزودن انیمیشن
- دریافت انیمیشن
- استخراج انیمیشن
- افزودن افکت
- دریافت افکت
- استخراج افکت
- صدای افکت
- اعمال انیمیشن
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید انیمیشن‌های شکل را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای Java ایجاد و سفارشی کنید. برجسته باشید!"
---
## **مقدمه**

انیمیشن‌ها افکت‌های بصری هستند که می‌توانند بر روی متن‌ها، تصاویر، اشکال یا [نمودارها](https://docs.aspose.com/slides/fa/java/animated-charts/) اعمال شوند. آن‌ها به ارائه‌ها یا اجزای آن جان می‌بخشند.

## **چرا از انیمیشن‌ها در ارائه‌ها استفاده کنیم؟**

* کنترل جریان اطلاعات
* تأکید بر نکات مهم
* افزایش علاقه یا مشارکت مخاطبان
* آسان‌تر کردن خواندن یا درک یا پردازش محتوا
* جلب توجه خوانندگان یا بینندگان به بخش‌های مهم در یک ارائه

PowerPoint گزینه‌ها و ابزارهای فراوانی برای انیمیشن‌ها و افکت‌های انیمیشن در دسته‌های **ورودی**، **خروجی**، **تاکید** و **مسیرهای حرکتی** ارائه می‌دهد.

## **انیمیشن‌ها در Aspose.Slides**

* Aspose.Slides کلاس‌ها و انواع مورد نیاز برای کار با انیمیشن‌ها را در فضای نام `Aspose.Slides.Animation` ارائه می‌دهد،
* Aspose.Slides بیش از **150 افکت انیمیشن** را در زیرمجموعه [EffectType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/effecttype) ارائه می‌دهد. این افکت‌ها در اصل همان افکت‌های استفاده‌شده در PowerPoint هستند (یا معادل آن‌ها).

## **اعمال انیمیشن به TextBox**

Aspose.Slides برای Java به شما امکان می‌دهد انیمیشن را بر متن یک شکل اعمال کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
2. یک مرجع اسلاید را از طریق اندیس آن به‌دست آورید.
3. یک `rectangle` [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape) اضافه کنید.
4. متن را به [IAutoShape.TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) اضافه کنید.
5. یک توالی اصلی از افکت‌ها دریافت کنید.
6. یک افکت انیمیشن به [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape) اضافه کنید.
7. ویژگی `TextAnimation.BuildType` را به مقدار موجود در Enumeraton `BuildType` تنظیم کنید.
8. ارائه را به‌صورت فایل PPTX روی دیسک بنویسید.

این کد Java نشان می‌دهد چگونه افکت `Fade` را به AutoShape اعمال کنید و انیمیشن متن را به مقدار *By 1st Level Paragraphs* تنظیم کنید:

```java
// یک کلاس ارائه را که نمایانگر یک فایل ارائه است، نمونه‌سازی می‌کند.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // یک AutoShape جدید با متن اضافه می‌کند
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // توالی اصلی اسلاید را می‌گیرد.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // افکت انیمیشن Fade را به شکل اضافه می‌کند
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // متن شکل را بر اساس پاراگراف‌های سطح اول انیمیشن می‌کند
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // فایل PPTX را روی دیسک ذخیره می‌کند
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

علاوه بر اعمال انیمیشن بر متن، می‌توانید انیمیشن‌ها را به یک [Paragraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraph) منفرد نیز اعمال کنید. ببینید [**Animated Text**](/slides/fa/java/animated-text/).

{{% /alert %}} 

## **اعمال انیمیشن به PictureFrame**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
2. مرجع اسلاید را از طریق اندیس آن به‌دست آورید.
3. یک [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pictureframe) را روی اسلاید اضافه کنید یا دریافت کنید.
4. توالی اصلی افکت‌ها را دریافت کنید.
5. یک افکت انیمیشن به [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pictureframe) اضافه کنید.
6. فایل PPTX اصلاح‌شده را ذخیره کنید.

این کد Java نشان می‌دهد چگونه افکت `Fly` را به یک picture frame اعمال کنید:

```java
// یک کلاس ارائه را که نمایانگر یک فایل ارائه است، نمونه‌سازی می‌کند.
Presentation pres = new Presentation();
try {
    // تصویر را که باید به مجموعه تصاویر ارائه اضافه شود، بارگذاری می‌کند
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // یک قاب تصویر به اسلاید اضافه می‌کند
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // توالی اصلی اسلاید را می‌گیرد.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // افکت انیمیشن Fly از سمت چپ را به قاب تصویر اضافه می‌کند
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // فایل PPTX را روی دیسک ذخیره می‌کند
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **اعمال انیمیشن به Shape**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
2. مرجع اسلاید را از طریق اندیس آن به‌دست آورید.
3. یک `rectangle` [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape) اضافه کنید.
4. یک `Bevel` [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape) اضافه کنید (زمانی که این شیء کلیک شود، انیمیشن اجرا می‌شود).
5. یک توالی از افکت‌ها روی شکل Bevel ایجاد کنید.
6. یک `UserPath` سفارشی ایجاد کنید.
7. دستورات برای حرکت به `UserPath` اضافه کنید.
8. فایل PPTX اصلاح‌شده را ذخیره کنید.

این کد Java نشان می‌دهد چگونه افکت `PathFootball` (مسیر فوتبال) را به یک shape اعمال کنید:

```java
// یک کلاس Presentation که نمایانگر یک فایل PPTX است را نمونه‌سازی می‌کند.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // افکت PathFootball را برای شکل موجود از ابتدا ایجاد می‌کند.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // افکت انیمیشن PathFootBall را اضافه می‌کند
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // یک نوع "دکمه" ایجاد می‌کند.
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // یک توالی از افکت‌ها برای این دکمه ایجاد می‌کند.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // یک مسیر سفارشی کاربر ایجاد می‌کند. شیء ما تنها پس از کلیک روی دکمه جابه‌جا می‌شود.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // دستورات جابه‌جایی را اضافه می‌کند زیرا مسیر ایجاد شده خالی است.
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

## **دریافت افکت‌های انیمیشن اعمال‌شده بر یک Shape**

مثال‌های زیر نحوه استفاده از متد `getEffectsByShape` از رابط [ISequence](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isequence/) را برای دریافت تمام افکت‌های انیمیشن اعمال‌شده بر یک shape نشان می‌دهند.

**مثال ۱: دریافت افکت‌های انیمیشن اعمال‌شده بر یک shape در اسلاید معمولی**

در ابتدا، یاد گرفتید چگونه افکت‌های انیمیشن را به شکل‌ها در ارائه‌های PowerPoint اضافه کنید. کد نمونه زیر نشان می‌دهد چگونه افکت‌های اعمال‌شده بر اولین shape در اولین اسلاید معمولی در ارائه `AnimExample_out.pptx` را دریافت کنید:

```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // توالی اصلی انیمیشن اسلاید را دریافت می‌کند.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // اولین شکل در اولین اسلاید را دریافت می‌کند.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // افکت‌های انیمیشن اعمال‌شده بر شکل را دریافت می‌کند.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**مثال ۲: دریافت تمام افکت‌های انیمیشن، از جمله آن‌هایی که از placeholders به ارث می‌رسند**

اگر یک shape در اسلاید معمولی دارای placeholders باشد که در اسلاید layout و/یا master قرار دارند و افکت‌های انیمیشن به این placeholders اضافه شده باشند، تمام افکت‌های shape در طول نمایش اسلاید پخش خواهد شد، شامل آن‌هایی که از placeholders به ارث رسیده‌اند.

فرض کنید یک فایل ارائه PowerPoint به نام `sample.pptx` داریم که یک اسلاید دارد که فقط شامل یک shape فوتر با متن "Made with Aspose.Slides" است و افکت **Random Bars** بر این shape اعمال شده است.

![Slide shape animation effect](slide-shape-animation.png)

همچنین فرض کنید افکت **Split** بر placeholder فوتر در اسلاید **layout** اعمال شده است.

![Layout shape animation effect](layout-shape-animation.png)

و در نهایت، افکت **Fly In** بر placeholder فوتر در اسلاید **master** اعمال شده است.

![Master shape animation effect](master-shape-animation.png)

کد نمونه زیر نحوه استفاده از متد `getBasePlaceholder` از رابط [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) را برای دسترسی به placeholders شکل و دریافت افکت‌های انیمیشن اعمال‌شده بر shape فوتر، شامل آن‌هایی که از placeholders موجود در اسلایدهای layout و master به ارث رسیده‌اند، نشان می‌دهد:

```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// دریافت افکت‌های انیمیشن شکل در اسلاید عادی.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// دریافت افکت‌های انیمیشن placeholder در اسلاید layout.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// دریافت افکت‌های انیمیشن placeholder در اسلاید master.
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

خروجی:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **تغییر ویژگی‌های زمان‌بندی افکت انیمیشن**

Aspose.Slides برای Java به شما امکان می‌دهد ویژگی‌های Timing یک افکت انیمیشن را تغییر دهید.

این پنل Animation Timing در Microsoft PowerPoint است:

![example1_image](shape-animation.png)

- لیست کشویی **Start** در PowerPoint Timing با ویژگی [Effect.Timing.TriggerType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITiming#getTriggerType--) مطابقت دارد. 
- PowerPoint Timing **Duration** با ویژگی [Effect.Timing.Duration](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITiming#getDuration--) مطابقت دارد. مدت زمان یک انیمیشن (به ثانیه) زمان کل لازم برای تکمیل یک چرخه انیمیشن است. 
- PowerPoint Timing **Delay** با ویژگی [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITiming#getTriggerDelayTime--) مطابقت دارد. 

نحوه تغییر ویژگی‌های Timing افکت به این صورت است:

1. [Apply](#apply-animation-to-shape) یا دریافت افکت انیمیشن.
2. مقادیر جدید برای ویژگی‌های [Effect.Timing](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IEffect#getTiming--) که نیاز دارید تنظیم کنید.
3. فایل PPTX اصلاح‌شده را ذخیره کنید.

این کد Java عملیات را نشان می‌دهد:

```java
// یک کلاس Presentation که نمایانگر یک فایل ارائه است را نمونه‌سازی می‌کند.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // دنباله اصلی اسلاید را دریافت می‌کند.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // اولین افکت دنباله اصلی را دریافت می‌کند.
    IEffect effect = sequence.get_Item(0);

    // نوع Trigger افکت را به شروع با کلیک تغییر می‌دهد
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // مدت زمان افکت را تغییر می‌دهد
    effect.getTiming().setDuration(3f);

    // زمان تأخیر Trigger افکت را تغییر می‌دهد
    effect.getTiming().setTriggerDelayTime(0.5f);

    // فایل PPTX را روی دیسک ذخیره می‌کند
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **صدا در افکت انیمیشن**

Aspose.Slides این ویژگی‌ها را برای کار با صداها در افکت‌های انیمیشن فراهم می‌کند: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **افزودن صدا به افکت انیمیشن**

این کد Java نشان می‌دهد چگونه یک صدا به افکت انیمیشن اضافه کنید و هنگام شروع افکت بعدی آن را متوقف کنید:

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // صدا را به مجموعه صداهای ارائه اضافه می‌کند
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // دنباله اصلی اسلاید را دریافت می‌کند.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // اولین افکت دنباله اصلی را دریافت می‌کند
    IEffect firstEffect = sequence.get_Item(0);

    // بررسی می‌کند افکت برای "بدون صدا"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // صدا را برای اولین افکت اضافه می‌کند
        firstEffect.setSound(effectSound);
    }

    // اولین توالی تعاملی اسلاید را دریافت می‌کند.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // پرچم "Stop previous sound" افکت را تنظیم می‌کند
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // فایل PPTX را روی دیسک می‌نویسد
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **استخراج صدا از افکت انیمیشن**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. مرجع اسلاید را از طریق اندیس آن به‌دست آورید. 
3. توالی اصلی افکت‌ها را دریافت کنید. 
4. صدا [setSound(IAudio value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) تعبیه‌شده در هر افکت انیمیشن را استخراج کنید. 

این کد Java نشان می‌دهد چگونه صدا تعبیه‌شده در یک افکت انیمیشن را استخراج کنید:

```java
// یک کلاس Presentation که نمایانگر یک فایل ارائه است را نمونه‌سازی می‌کند.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // دنباله اصلی اسلاید را دریافت می‌کند.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // صدای افکت را به صورت آرایه بایت استخراج می‌کند
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **بعد از انیمیشن**

Aspose.Slides برای Java به شما امکان می‌دهد ویژگی After animation یک افکت انیمیشن را تغییر دهید.

این پنل Animation Effect و منوی گسترده در Microsoft PowerPoint است:

![example1_image](shape-after-animation.png)

لیست کشویی **After animation** در PowerPoint Effect با این ویژگی‌ها مطابقت دارد: 

- ویژگی [setAfterAnimationType(int value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) که نوع After animation را توصیف می‌کند:
  * PowerPoint **More Colors** با نوع [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/java/com.aspose.slides/afteranimationtype/#Color) مطابقت دارد؛
  * PowerPoint **Don't Dim** با نوع [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/fa/java/com.aspose.slides/afteranimationtype/#DoNotDim) (نوع پیش‌فرض after animation) مطابقت دارد؛
  * PowerPoint **Hide After Animation** با نوع [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation) مطابقت دارد؛
  * PowerPoint **Hide on Next Mouse Click** با نوع [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/fa/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) مطابقت دارد؛
- ویژگی [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) که فرمت رنگ after animation را تعریف می‌کند. این ویژگی همراه با نوع [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/java/com.aspose.slides/afteranimationtype/#Color) کار می‌کند. اگر نوع را به مقدار دیگری تغییر دهید، رنگ after animation پاک می‌شود.

این کد Java نشان می‌دهد چگونه یک افکت after animation را تغییر دهید:

```java
// یک کلاس Presentation که نمایانگر یک فایل ارائه است را نمونه‌سازی می‌کند
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // اولین افکت دنباله اصلی را دریافت می‌کند
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // نوع after animation را به Color تغییر می‌دهد
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // رنگ after animation dim را تنظیم می‌کند
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // فایل PPTX را روی دیسک ذخیره می‌کند
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **انیمیشن متن**

Aspose.Slides این ویژگی‌ها را برای کار با بلوک *Animate text* یک افکت انیمیشن فراهم می‌کند:

- ویژگی [setAnimateTextType(int value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) که نوع animate text افکت را توصیف می‌کند. متن shape می‌تواند انیمیشن شود:
  * همه به‌طور همزمان ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/fa/java/com.aspose.slides/animatetexttype/#AllAtOnce))
  * به‌صورت کلمه به کلمه ([AnimateTextType.ByWord](https://reference.aspose.com/slides/fa/java/com.aspose.slides/animatetexttype/#ByWord))
  * به‌صورت حرف به حرف ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/fa/java/com.aspose.slides/animatetexttype/#ByLetter))
- ویژگی [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) تاخیر بین بخش‌های متن انیمیشن‌شده (کلمات یا حروف) را تنظیم می‌کند. مقدار مثبت درصد مدت افکت را مشخص می‌کند. مقدار منفی تاخیر را بر حسب ثانیه تعیین می‌کند.

نحوه تغییر ویژگی‌های Effect Animate text به این صورت است:

1. [Apply](#apply-animation-to-shape) یا دریافت افکت انیمیشن.
2. ویژگی [setBuildType(int value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextanimation/#setBuildType-int-) را به مقدار [BuildType.AsOneObject](https://reference.aspose.com/slides/fa/java/com.aspose.slides/buildtype/#AsOneObject) تنظیم کنید تا حالت انیمیشن *By Paragraphs* غیرفعال شود.
3. مقادیر جدید را برای ویژگی‌های [setAnimateTextType(int value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) و [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) تنظیم کنید.
4. فایل PPTX اصلاح‌شده را ذخیره کنید.

این کد Java عملیات را نشان می‌دهد:

```java
// یک کلاس Presentation که نمایانگر یک فایل ارائه است را نمونه‌سازی می‌کند.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // اولین افکت دنباله اصلی را دریافت می‌کند
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // نوع انیمیشن متن افکت را به «As One Object» تغییر می‌دهد
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // نوع Animate text افکت را به «By word» تغییر می‌دهد
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // تاخیر بین کلمات را به 20 درصد از مدت افکت تنظیم می‌کند
    firstEffect.setDelayBetweenTextParts(20f);

    // فایل PPTX را روی دیسک ذخیره می‌کند
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**چگونه می‌توانم اطمینان حاصل کنم که انیمیشن‌ها هنگام انتشار ارائه در وب حفظ می‌شوند؟**

[Export to HTML5](/slides/fa/java/export-to-html5/) و فعال کردن [options](https://reference.aspose.com/slides/fa/java/com.aspose.slides/html5options/) که مسئول انیمیشن‌های [shape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و [transition](https://reference.aspose.com/slides/fa/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) هستند. HTML ساده انیمیشن‌های اسلاید را پخش نمی‌کند، در حالی که HTML5 این کار را انجام می‌دهد.

**تغییر ترتیب z-order (ترتیب لایه) اشکال چگونه بر انیمیشن تاثیر می‌گذارد؟**

انیمیشن و ترتیب رسم مستقل هستند: یک افکت زمان‌بندی و نوع ظاهر شدن/ناپدید شدن را کنترل می‌کند، در حالی که [z-order](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#getZOrderPosition--) تعیین می‌کند کدام شیء چه چیزی را می‌پوشاند. نتیجه قابل‌مشاهده ترکیبی از این دو است. (این رفتار کلی PowerPoint است؛ مدل effects-and-shapes در Aspose.Slides همان منطق را دنبال می‌کند.)

**آیا محدودیتی هنگام تبدیل انیمیشن‌ها به ویدیو برای برخی افکت‌ها وجود دارد؟**

به‌طور کلی، [انیمیشن‌ها پشتیبانی می‌شوند](/slides/fa/java/convert-powerpoint-to-video/)، اما در موارد نادر یا برای افکت‌های خاص ممکن است به‌صورت متفاوتی رندر شوند. توصیه می‌شود با افکت‌هایی که استفاده می‌کنید و نسخه کتابخانه تست کنید.