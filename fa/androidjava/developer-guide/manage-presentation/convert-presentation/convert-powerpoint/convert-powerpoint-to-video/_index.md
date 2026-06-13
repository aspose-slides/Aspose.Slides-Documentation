---
title: تبدیل ارائه‌های PowerPoint به ویدیو در Android
linktitle: PowerPoint به ویدیو
type: docs
weight: 130
url: /fa/androidjava/convert-powerpoint-to-video/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به ویدیو
- ارائه به ویدیو
- PPT به ویدیو
- PPTX به ویدیو
- PowerPoint به MP4
- ارائه به MP4
- PPT به MP4
- PPTX به MP4
- ذخیره PPT به عنوان MP4
- ذخیره PPTX به عنوان MP4
- صادرات PPT به MP4
- صادرات PPTX به MP4
- تبدیل ویدیو
- PowerPoint
- Android
- Java
- Aspose.Slides
description: "بیاموزید چطور ارائه‌های PowerPoint را در Java به ویدیو تبدیل کنید. نمونه کد و تکنیک‌های خودکارسازی را برای ساده‌سازی جریان کار خود کشف کنید."
---
## **معرفی**

با تبدیل ارائهٔ PowerPoint خود به ویدئو، می‌توانید 

* **افزایش دسترسی‌پذیری:** تمام دستگاه‌ها (صرف‌نظر از پلتفرم) به‌صورت پیش‌فرض دارای پلیرهای ویدئویی هستند در مقایسه با برنامه‌های بازکن ارائه، بنابراین کاربران راحت‌تر می‌توانند ویدئوها را باز یا پخش کنند.
* **دستیابی بیشتر:** از طریق ویدئوها می‌توانید به مخاطبان وسیعی دست یابید و اطلاعاتی را به آن‌ها ارائه دهید که در یک ارائه ممکن است خسته‌کننده به نظر برسد. اکثر نظرسنجی‌ها و آمارها نشان می‌دهند که مردم ویدئوها را نسبت به سایر انواع محتوا بیشتر تماشا و مصرف می‌کنند و عموماً این نوع محتوا را ترجیح می‌دهند.

{{% alert color="primary" %}} 

ممکن است بخواهید [**مبدل آنلاین PowerPoint به ویدئو**](https://products.aspose.app/slides/fa/conversion/ppt-to-word) ما را بررسی کنید زیرا این یک پیاده‌سازی زنده و مؤثر از فرآیند توضیح داده‌شده در اینجا است.

{{% /alert %}} 

## **تبدیل PowerPoint به ویدئو در Aspose.Slides**

Aspose.Slides از تبدیل ارائه به ویدئو پشتیبانی می‌کند.

* از **Aspose.Slides** برای تولید مجموعه‌ای از فریم‌ها (از اسلایدهای ارائه) استفاده کنید که با FPS (قاب بر ثانیه) مورد نظر مطابقت دارند
* از یک ابزار شخص ثالث مانند **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) برای ایجاد ویدئو بر پایه فریم‌ها استفاده کنید. 

### **تبدیل PowerPoint به ویدئو**

1. این را به فایل POM خود اضافه کنید:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. ffmpeg را از [اینجا](https://ffmpeg.org/download.html) دانلود کنید.

4. کد Java تبدیل PowerPoint به ویدئو را اجرا کنید.

این کد Java به شما نشان می‌دهد چگونه یک ارائه (که شامل یک شکل و دو افکت انیمیشن است) را به ویدئو تبدیل کنید:

```java
Presentation presentation = new Presentation();
try {
    // یک شکل لبخند اضافه می‌کند و سپس آن را انیمیشن می‌دهد
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // پوشه باینری‌های ffmpeg را پیکربندی کنید. این صفحه را ببینید: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **افکت‌های ویدئویی**

می‌توانید انیمیشن‌ها را بر روی اشیاء اسلایدها اعمال کنید و از انتقال‌ها بین اسلایدها استفاده کنید. 

{{% alert color="primary" %}} 

ممکن است مایل باشید این مقالات را ببینید: [انیمیشن PowerPoint](https://docs.aspose.com/slides/fa/androidjava/powerpoint-animation/)، [انیمیشن شکل](https://docs.aspose.com/slides/fa/androidjava/shape-animation/)، و [افکت شکل](https://docs.aspose.com/slides/fa/androidjava/shape-effect/).

{{% /alert %}} 

انیمیشن‌ها و انتقال‌ها نمایش اسلایدها را جذاب‌تر و جالب‌تر می‌کنند — و همین‌طور برای ویدئوها نیز صدق می‌کند. بیایید اسلاید دیگری و یک انتقال به کد ارائه قبلی اضافه کنیم:

```java
// یک شکل لبخند اضافه می‌کند و آن را انیمیشن می‌دهد

// ...

// یک اسلاید جدید اضافه می‌کند و انتقال انیمیشن‌شده

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides همچنین از انیمیشن برای متن‌ها پشتیبانی می‌کند. بنابراین ما پاراگراف‌ها را بر روی اشیاء انیمیشن می‌کنیم که یکی پس از دیگری ظاهر می‌شوند (با تاخیر یک ثانیه تنظیم شده):

```java
Presentation presentation = new Presentation();
try {
    // متن و انیمیشن‌ها را اضافه می‌کند
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides for Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("convert PowerPoint Presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Portion("paragraph by paragraph"));
    IParagraphCollection paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new Paragraph());

    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effect1 = mainSequence.addEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect2 = mainSequence.addEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect3 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect4 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);
    effect4.getTiming().setTriggerDelayTime(1f);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // پیکربندی پوشه باینری‌های ffmpeg. این صفحه را ببینید: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **کلاس‌های تبدیل ویدئو**

برای انجام وظایف تبدیل PowerPoint به ویدئو، Aspose.Slides کلاس‌های [PresentationAnimationsGenerator](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentationanimationsgenerator/) و [PresentationPlayer](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentationplayer/) را ارائه می‌دهد.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentationanimationsgenerator/) به شما امکان می‌دهد اندازه فریم برای ویدئویی که بعداً ایجاد خواهد شد را از طریق سازنده‌اش تنظیم کنید. اگر نمونه‌ای از ارائه را پاس کنید، `Presentation.SlideSize` استفاده می‌شود و انیمیشن‌هایی را که [PresentationPlayer](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentationplayer/) استفاده می‌کند، تولید می‌کند.

زمانی که انیمیشن‌ها تولید می‌شوند، برای هر انیمیشن بعدی یک رویداد `NewAnimation` ایجاد می‌شود که پارامتر [IPresentationAnimationPlayer](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationanimationplayer/) دارد. این کلاس نمایانگر یک پلیر برای یک انیمیشن جداگانه است.

برای کار با [IPresentationAnimationPlayer](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationanimationplayer/)، از ویژگی [Duration](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (کل زمان انیمیشن) و متد [SetTimePosition](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) استفاده می‌شود. هر موقعیت انیمیشن در بازه *۰ تا مدت زمان* تنظیم می‌شود و سپس متد `GetFrame` یک BufferedImage که متناظر با وضعیت انیمیشن در آن لحظه است، برمی‌گرداند:

```java
Presentation presentation = new Presentation();
try {
    // یک شکل لبخند اضافه می‌کند و آن را انیمیشن می‌دهد
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer ->
        {
            System.out.println(String.format("Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0); // وضعیت اولیه انیمیشن
            try {
                // bitmap وضعیت اولیه انیمیشن
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // فریم آخر انیمیشن
            try {
                // فریم آخر انیمیشن
                animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        });
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

برای پخش تمام انیمیشن‌های یک ارائه به‌صورت همزمان، از کلاس [PresentationPlayer](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentationplayer/) استفاده می‌شود. این کلاس یک نمونه از [PresentationAnimationsGenerator](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentationanimationsgenerator/) و FPS برای افکت‌ها را در سازنده دریافت کرده و سپس برای تمام انیمیشن‌ها رویداد `FrameTick` را فراخوانی می‌کند تا آن‌ها پخش شوند:

```java
Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

سپس فریم‌های تولیدشده می‌توانند به‌منظور ساخت یک ویدئو ترکیب شوند. بخش [تبدیل PowerPoint به ویدئو](https://docs.aspose.com/slides/fa/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video) را ببینید.

## **انیمیشن‌ها و افکت‌های پشتیبانی‌شده**

**ورودی**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**تاکید**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**خروج**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**مسیرهای حرکتی**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **سوالات متداول**

**آیا امکان تبدیل ارائه‌های دارای رمز عبور وجود دارد؟**

بله، Aspose.Slides امکان کار با [ارائه‌های دارای رمز عبور](/slides/fa/androidjava/password-protected-presentation/) را فراهم می‌کند. هنگام پردازش چنین فایل‌هایی باید رمز عبور صحیح را ارائه دهید تا کتابخانه بتواند به محتوای ارائه دسترسی پیدا کند.

**آیا Aspose.Slides از استفاده در راه‌حل‌های ابری پشتیبانی می‌کند؟**

بله، Aspose.Slides می‌تواند در برنامه‌ها و سرویس‌های ابری یکپارچه شود. این کتابخانه برای کار در محیط‌های سروری طراحی شده است و عملکرد بالا و مقیاس‌پذیری را برای پردازش انبوه فایل‌ها تضمین می‌کند.

**آیا محدودیت اندازه‌ای برای ارائه‌ها هنگام تبدیل وجود دارد؟**

Aspose.Slides قادر به پردازش ارائه‌های با اندازه تقریباً هر چه باشد است. با این حال، هنگام کار با فایل‌های بسیار بزرگ ممکن است نیاز به منابع سیستمی بیشتری باشد و گاهی توصیه می‌شود تا بهبود عملکرد، ارائه را بهینه‌سازی کنید.