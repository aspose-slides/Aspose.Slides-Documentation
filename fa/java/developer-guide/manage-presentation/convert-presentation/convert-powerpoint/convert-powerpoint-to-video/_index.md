---
title: تبدیل ارائه‌های PowerPoint به ویدیو در Java
linktitle: PowerPoint به ویدیو
type: docs
weight: 130
url: /fa/java/convert-powerpoint-to-video/
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
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PowerPoint را به ویدیو در Java تبدیل کنید. نمونه کد و تکنیک‌های خودکارسازی را برای بهینه‌سازی جریان کار خود کشف کنید."
---
## **Introduction**

با تبدیل ارائه PowerPoint یا OpenDocument خود به ویدیو، مزایای زیر را به دست می‌آورید:

**دسترسی بیشتر:** تمام دستگاه‌ها، صرف‌نظر از پلتفرم، به‌طور پیش‌فرض دارای پخش‌کننده ویدیو هستند، بنابراین برای کاربران آسان‌تر است که ویدیوها را باز یا پخش کنند نسبت به برنامه‌های ارائه سنتی.

**دسترس‌پذیری گسترده‌تر:** ویدیوها به شما امکان می‌دهند به مخاطبان بیشتری دسترسی پیدا کنید و اطلاعات را به شکل جذاب‌تری ارائه دهید. نظرسنجی‌ها و آمارها نشان می‌دهند که مردم ترجیح می‌دهند محتوای ویدیویی را نسبت به سایر فرم‌ها تماشا و مصرف کنند، که پیام شما را تأثیرگذارتر می‌کند.

{{% alert color="primary" %}} 
ممکن است بخواهید [**تبدیل‌کننده آنلاین PowerPoint به ویدیو**](https://products.aspose.app/slides/fa/conversion/ppt-to-word) ما را بررسی کنید، زیرا پیاده‌سازی زنده و مؤثری از فرایند شرح داده‌شده در اینجا است.
{{% /alert %}} 

## **PowerPoint to Video Conversion in Aspose.Slides**

در [Aspose.Slides 22.11](https://docs.aspose.com/slides/fa/java/aspose-slides-for-java-22-11-release-notes/) ما پشتیبانی از تبدیل ارائه به ویدیو را پیاده‌سازی کردیم. 

* از **Aspose.Slides** برای تولید مجموعه‌ای از فریم‌ها (از اسلایدهای ارائه) استفاده کنید که متناسب با FPS (فریم در ثانیه) معینی باشد
* از یک ابزار شخص ثالث مانند **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) برای ایجاد ویدیو بر پایه فریم‌ها استفاده کنید. 

### **Convert PowerPoint to Video**

1. این موارد را به فایل POM خود اضافه کنید:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. ffmpeg را [اینجا](https://ffmpeg.org/download.html) دانلود کنید.

4. کد Java تبدیل PowerPoint به ویدیو را اجرا کنید.

این کد Java نشان می‌دهد چگونه یک ارائه (شامل یک نمودار و دو افکت انیمیشن) را به ویدیو تبدیل کنید:

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

## **Video Effects**

می‌توانید انیمیشن‌ها را بر روی اشیاء در اسلایدها اعمال کنید و از انتقال‌ها بین اسلایدها استفاده کنید. 

{{% alert color="primary" %}} 
ممکن است بخواهید این مقالات را ببینید: [PowerPoint Animation](https://docs.aspose.com/slides/fa/java/powerpoint-animation/)، [Shape Animation](https://docs.aspose.com/slides/fa/java/shape-animation/)، و [Shape Effect](https://docs.aspose.com/slides/fa/java/shape-effect/).
{{% /alert %}} 

انیمیشن‌ها و انتقال‌ها نمایش اسلایدها را جذاب‌تر و جالب‌تر می‌کنند—و برای ویدیوها نیز همین کار را انجام می‌دهند. بیایید یک اسلاید دیگر و یک انتقال به کد ارائه قبلی اضافه کنیم:

```java
// یک شکل لبخند اضافه می‌کند و آن را انیمیشن می‌دهد

// ...

// یک اسلاید جدید اضافه می‌کند و انتقال انیمیشنی

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides همچنین از انیمیشن برای متن‌ها پشتیبانی می‌کند. بنابراین ما پاراگراف‌های روی اشیاء را انیمیشن می‌کنیم که یکی پس از دیگری ظاهر می‌شوند (با تاخیر تنظیم‌شده به یک ثانیه):

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

## **Video Conversion Classes**

برای انجام وظایف تبدیل PowerPoint به ویدیو، Aspose.Slides کلاس‌های [PresentationAnimationsGenerator](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationanimationsgenerator/) و [PresentationPlayer](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationplayer/) را ارائه می‌دهد.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationanimationsgenerator/) به شما اجازه می‌دهد اندازه فریم برای ویدیو (که بعداً ساخته می‌شود) را از طریق سازنده‌اش تنظیم کنید. اگر نمونه‌ای از ارائه را پاس دهید، `Presentation.SlideSize` استفاده می‌شود و انیمیشن‌هایی تولید می‌کند که [PresentationPlayer](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationplayer/) استفاده می‌کند. 

هنگامی که انیمیشن‌ها تولید می‌شوند، یک رویداد `NewAnimation` برای هر انیمیشن بعدی ایجاد می‌شود که پارامتر [IPresentationAnimationPlayer](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationanimationplayer/) دارد. این کلاس نماینده یک پلیر برای انیمیشن جداگانه است.

برای کار با [IPresentationAnimationPlayer](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationanimationplayer/)، از ویژگی [Duration](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (مدت کامل انیمیشن) و متد [SetTimePosition](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) استفاده می‌شود. هر موقعیت انیمیشن در بازه *۰ تا مدت* تنظیم می‌شود و سپس متد `GetFrame` یک BufferedImage بر می‌گرداند که با وضعیت انیمیشن در آن لحظه مطابقت دارد:

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
            animationPlayer.setTimePosition(0); // حالت اولیه انیمیشن
            try {
                // نقشه‌بیتی حالت اولیه انیمیشن
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // حالت نهایی انیمیشن
            try {
                // آخرین فریم انیمیشن
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

برای پخش همزمان تمام انیمیشن‌های یک ارائه، از کلاس [PresentationPlayer](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationplayer/) استفاده می‌شود. این کلاس یک نمونه از [PresentationAnimationsGenerator](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationanimationsgenerator/) و FPS برای افکت‌ها را در سازنده می‌گیرد و سپس برای تمام انیمیشن‌ها رویداد `FrameTick` را صدا می‌زند تا آن‌ها اجرا شوند:

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

سپس فریم‌های تولید شده می‌توانند ترکیب شوند تا یک ویدیو ساخته شود. بخش [Convert PowerPoint to Video](https://docs.aspose.com/slides/fa/java/convert-powerpoint-to-video/#convert-powerpoint-to-video) را ببینید.

## **Supported Animations and Effects**

**Entrance**:

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

**Emphasis**:

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

**Exit**:

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

**Motion Paths**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**آیا امکان تبدیل ارائه‌های دارای رمز عبور وجود دارد؟**

بله، Aspose.Slides امکان کار با [presentations protected by password](/slides/fa/java/password-protected-presentation/) را فراهم می‌کند. هنگام پردازش چنین فایل‌هایی، باید رمز عبور صحیح را ارائه دهید تا کتابخانه بتواند به محتوای ارائه دسترسی پیدا کند.

**آیا Aspose.Slides از استفاده در راه‌حل‌های ابری پشتیبانی می‌کند؟**

بله، Aspose.Slides می‌تواند در برنامه‌ها و سرویس‌های ابری ادغام شود. این کتابخانه برای کار در محیط‌های سرور طراحی شده است و عملکرد بالا و مقیاس‌پذیری را برای پردازش دسته‌ای فایل‌ها تضمین می‌کند.

**آیا محدودیت اندازه‌ای برای ارائه‌ها هنگام تبدیل وجود دارد؟**

Aspose.Slides قادر به پردازش ارائه‌هایی با هر اندازه‌ای است. اما هنگام کار با فایل‌های بسیار بزرگ، ممکن است به منابع سیستمی بیشتری نیاز باشد و گاهی توصیه می‌شود برای بهبود عملکرد، ارائه را بهینه‌سازی کنید.