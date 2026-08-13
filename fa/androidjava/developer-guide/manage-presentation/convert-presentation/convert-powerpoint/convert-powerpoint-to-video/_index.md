---
title: تبدیل ارائه‌های PowerPoint به ویدیو در اندروید
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
- ذخیره PPT به صورت MP4
- ذخیره PPTX به صورت MP4
- صادرات PPT به MP4
- صادرات PPTX به MP4
- تبدیل ویدیو
- PowerPoint
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PowerPoint را به ویدیو در جاوا تبدیل کنید. کد نمونه و تکنیک‌های خودکارسازی را برای بهینه‌سازی جریان کار خود کشف کنید."
---
## **مقدمه**

با تبدیل ارائه PowerPoint خود به ویدیو، شما دریافت می‌کنید  

* **افزایش دسترسی‌پذیری:** تمام دستگاه‌ها (بدون در نظر گرفتن پلتفرم) به‌طور پیش‌فرض دارای پخش‌کننده‌های ویدیو هستند در مقایسه با برنامه‌های باز کردن ارائه، بنابراین کاربران راحت‌تر می‌توانند ویدیوها را باز یا پخش کنند.  
* **دسترس بیشتر:** از طریق ویدیوها می‌توانید به مخاطبان گسترده‌ای دست پیدا کنید و اطلاعاتی را به آن‌ها ارائه دهید که در یک ارائه ممکن است خسته‌کننده به نظر برسد. اکثر نظرسنجی‌ها و آمارها نشان می‌دهند که مردم ویدیوها را بیش از سایر اشکال محتوا نگاه می‌کنند و مصرف می‌کنند و عموماً این نوع محتوا را ترجیح می‌دهند.  

## **تبدیل PowerPoint به ویدیو در Aspose.Slides**

Aspose.Slides از تبدیل ارائه به ویدیو پشتیبانی می‌کند.  

* از **Aspose.Slides** برای تولید مجموعه‌ای از فریم‌ها (از اسلایدهای ارائه) که با یک FPS (فریم در ثانیه) مشخص مطابقت دارند استفاده کنید  
* از ابزاری شخص ثالث مانند **ffmpeg**([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) برای ایجاد یک ویدیو بر پایه فریم‌ها استفاده کنید.  

### **تبدیل PowerPoint به ویدیو**

1. این را به فایل POM خود اضافه کنید:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. ffmpeg را از [اینجا](https://ffmpeg.org/download.html) دانلود کنید.  

3. کد Java تبدیل PowerPoint به ویدیو را اجرا کنید.  

این کد Java به شما نشان می‌دهد چگونه یک ارائه (شامل یک شکل و دو اثر انیمیشن) را به یک ویدیو تبدیل کنید:
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // یک شکل لبخند اضافه می‌کند و سپس آن را انیمیت می‌کند
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

    // پوشه باینری‌های ffmpeg را تنظیم کنید. این صفحه را ببینید: https://github.com/bramp/ffmpeg-cli-wrapper
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

## **افکت‌های ویدیو**

می‌توانید انیمیشن‌ها را بر روی اشیاء در اسلایدها اعمال کنید و از انتقال‌ها بین اسلایدها استفاده کنید.  

{{% alert color="info" %}} 
ممکن است بخواهید این مقالات را ببینید: [PowerPoint Animation](https://docs.aspose.com/slides/fa/androidjava/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/fa/androidjava/shape-animation/), و [Shape Effect](https://docs.aspose.com/slides/fa/androidjava/shape-effect/).  
{{% /alert %}} 

انیمیشن‌ها و انتقال‌ها اسلایدشوها را جذاب‌تر و جالب‌تر می‌کنند — و همین کار را برای ویدیوها نیز انجام می‌دهند. بیایید یک اسلاید دیگر و یک انتقال به کد ارائه قبلی اضافه کنیم:
```java
import com.aspose.slides.*;
import java.awt.Color;

// ارائه‌ای که شکل لبخند متحرک در آن ایجاد شده است.
Presentation presentation = new Presentation();
try {
    // یک اسلاید جدید و انتقال متحرک اضافه می‌کند

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides همچنین از انیمیشن برای متن‌ها پشتیبانی می‌کند. بنابراین ما پاراگراف‌ها را بر روی اشیاء انیمیشن می‌کنیم که یکی پس از دیگری ظاهر می‌شوند (با تاخیری تنظیم‌شده به یک ثانیه):
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

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

    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effect1 = mainSequence.addEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect2 = mainSequence.addEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect3 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);

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

    // پوشه باینری‌های ffmpeg را تنظیم کنید. این صفحه را ببینید: https://github.com/bramp/ffmpeg-cli-wrapper
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

## **کلاس‌های تبدیل ویدیو**

برای اینکه بتوانید کارهای تبدیل PowerPoint به ویدیو را انجام دهید، Aspose.Slides کلاس‌های [PresentationAnimationsGenerator](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentationanimationsgenerator/) و [PresentationPlayer](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentationplayer/) را فراهم می‌کند.  

[PresentationAnimationsGenerator] به شما امکان می‌دهد اندازه فریم برای ویدیو (که بعداً ایجاد خواهد شد) را از طریق سازنده‌اش تنظیم کنید. اگر یک نمونه از ارائه را پاس کنید، `Presentation.SlideSize` استفاده می‌شود و انیمیشن‌هایی تولید می‌کند که [PresentationPlayer] از آنها استفاده می‌کند.  

هنگامی که انیمیشن‌ها تولید می‌شوند، یک رویداد `NewAnimation` برای هر انیمیشن بعدی ایجاد می‌شود که پارامتر [IPresentationAnimationPlayer] را دارد. این کلاس بازیکنی برای یک انیمیشن جداگانه را نشان می‌دهد.  

برای کار با [IPresentationAnimationPlayer]، ویژگی [Duration] (کل مدت زمان انیمیشن) و متد [SetTimePosition] استفاده می‌شوند. هر موقعیت انیمیشن در بازه *۰ تا مدت* تنظیم می‌شود و سپس متد `getFrame` یک [IImage] را برمی‌گرداند که با وضعیت انیمیشن در آن لحظه مطابقت دارد:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // یک شکل لبخند اضافه می‌کند و آن را انیمیت می‌نماید
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
            // نقشه بیت وضعیت اولیه انیمیشن
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // وضعیت نهایی انیمیشن
            // فریم آخر انیمیشن
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // انیمیشن‌ها را تولید می‌کند. فراخوانی بالا برای هر یک از آنها اجرا می‌شود.
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

برای اینکه تمام انیمیشن‌های یک ارائه به‌صورت همزمان پخش شوند، از کلاس [PresentationPlayer] استفاده می‌شود. این کلاس یک نمونه [PresentationAnimationsGenerator] و FPS برای افکت‌ها را در سازنده‌اش می‌گیرد و سپس رویداد `FrameTick` را برای تمام انیمیشن‌ها فراخوانی می‌کند تا آن‌ها پخش شوند:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
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

سپس فریم‌های تولید شده می‌توانند برای ساخت یک ویدیو ترکیب شوند. بخش [Convert PowerPoint to Video](https://docs.aspose.com/slides/fa/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video) را ببینید.  

## **انیمیشن‌ها و افکت‌های پشتیبانی‌شده**

**ورودی**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **ظاهر شدن** | ![not supported](x.png) | ![supported](v.png) |
| **محو شدن** | ![supported](v.png) | ![supported](v.png) |
| **پرواز به داخل** | ![supported](v.png) | ![supported](v.png) |
| **شناور شدن به داخل** | ![supported](v.png) | ![supported](v.png) |
| **تقسیم** | ![supported](v.png) | ![supported](v.png) |
| **پاک کردن** | ![supported](v.png) | ![supported](v.png) |
| **شکل** | ![supported](v.png) | ![supported](v.png) |
| **چرخ** | ![supported](v.png) | ![supported](v.png) |
| **نوارهای تصادفی** | ![supported](v.png) | ![supported](v.png) |
| **رشد و چرخش** | ![not supported](x.png) | ![supported](v.png) |
| **بزرگ‌نمایی** | ![supported](v.png) | ![supported](v.png) |
| **چرخش** | ![supported](v.png) | ![supported](v.png) |
| **پریدن** | ![supported](v.png) | ![supported](v.png) |

**تأکید**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **پالس** | ![not supported](x.png) | ![supported](v.png) |
| **پالس رنگی** | ![not supported](x.png) | ![supported](v.png) |
| **دلقک‌وار** | ![supported](v.png) | ![supported](v.png) |
| **چرخش** | ![supported](v.png) | ![supported](v.png) |
| **رشد/کوچک شدن** | ![not supported](x.png) | ![supported](v.png) |
| **از رنگ‌زدایی** | ![not supported](x.png) | ![supported](v.png) |
| **تیره‌کردن** | ![not supported](x.png) | ![supported](v.png) |
| **روشن‌کردن** | ![not supported](x.png) | ![supported](v.png) |
| **شفافیت** | ![not supported](x.png) | ![supported](v.png) |
| **رنگ شیء** | ![not supported](x.png) | ![supported](v.png) |
| **رنگ مکمل** | ![not supported](x.png) | ![supported](v.png) |
| **رنگ خط** | ![not supported](x.png) | ![supported](v.png) |
| **رنگ پرکردن** | ![not supported](x.png) | ![supported](v.png) |

**خروج**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **ناپدید شدن** | ![not supported](x.png) | ![supported](v.png) |
| **محو شدن** | ![supported](v.png) | ![supported](v.png) |
| **پرواز به بیرون** | ![supported](v.png) | ![supported](v.png) |
| **شناور شدن به بیرون** | ![supported](v.png) | ![supported](v.png) |
| **تقسیم** | ![supported](v.png) | ![supported](v.png) |
| **پاک کردن** | ![supported](v.png) | ![supported](v.png) |
| **شکل** | ![supported](v.png) | ![supported](v.png) |
| **نوارهای تصادفی** | ![supported](v.png) | ![supported](v.png) |
| **کوچک شدن و چرخش** | ![not supported](x.png) | ![supported](v.png) |
| **بزرگ‌نمایی** | ![supported](v.png) | ![supported](v.png) |
| **چرخش** | ![supported](v.png) | ![supported](v.png) |
| **پریدن** | ![supported](v.png) | ![supported](v.png) |

**مسیرهای حرکت**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **خطوط** | ![supported](v.png) | ![supported](v.png) |
| **قوس‌ها** | ![supported](v.png) | ![supported](v.png) |
| **چرخش‌ها** | ![supported](v.png) | ![supported](v.png) |
| **اشکال** | ![supported](v.png) | ![supported](v.png) |
| **حلقه‌ها** | ![supported](v.png) | ![supported](v.png) |
| **مسیر سفارشی** | ![supported](v.png) | ![supported](v.png) |

## **سوالات متداول**

### آیا امکان تبدیل ارائه‌های محافظت‌شده با رمز عبور وجود دارد؟

بله، Aspose.Slides امکان کار با [presentations protected with password](/slides/fa/androidjava/password-protected-presentation/) را فراهم می‌کند. هنگام پردازش چنین فایل‌هایی باید رمز عبور صحیح را ارائه دهید تا کتابخانه به محتوای ارائه دسترسی پیدا کند.  

### آیا Aspose.Slides از استفاده در راه‌حل‌های ابری پشتیبانی می‌کند؟

بله، Aspose.Slides می‌تواند در برنامه‌ها و سرویس‌های ابری یکپارچه شود. این کتابخانه برای کار در محیط‌های سرور طراحی شده و عملکرد بالا و مقیاس‌پذیری برای پردازش دسته‌ای فایل‌ها را تضمین می‌کند.  

### آیا محدودیت‌های حجمی برای ارائه‌ها در هنگام تبدیل وجود دارد؟

Aspose.Slides می‌تواند ارائه‌های تقریباً با هر اندازه‌ای را پردازش کند. با این حال، هنگام کار با فایل‌های بسیار بزرگ ممکن است به منابع سیستم بیشتری نیاز باشد و گاهی توصیه می‌شود برای بهبود عملکرد، ارائه را بهینه‌سازی کنید.  