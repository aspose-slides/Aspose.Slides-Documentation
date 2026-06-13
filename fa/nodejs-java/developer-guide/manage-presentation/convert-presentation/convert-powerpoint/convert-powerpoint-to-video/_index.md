---
title: تبدیل ارائه‌های PowerPoint به ویدیو در JavaScript
linktitle: PowerPoint به ویدیو
type: docs
weight: 130
url: /fa/nodejs-java/convert-powerpoint-to-video/
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
- استخراج PPT به MP4
- استخراج PPTX به MP4
- تبدیل ویدیو
- PowerPoint
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PowerPoint را در JavaScript به ویدیو تبدیل کنید. نمونه کد و تکنیک‌های خودکارسازی را برای بهینه‌سازی جریان کار خود کشف کنید."
---
## **مقدمه**

با تبدیل ارائه PowerPoint خود به ویدیو، موارد زیر را به دست می‌آورید  

* **افزایش دسترسی‌پذیری:** همه دستگاه‌ها (بدون توجه به پلتفرم) به‌صورت پیش‌فرض دارای پخش‌کننده ویدیو هستند در مقایسه با برنامه‌های باز کردن ارائه، بنابراین کاربران باز کردن یا پخش ویدیو را آسان‌تر می‌دانند.  
* **دسترس‌پذیری بیشتر:** از طریق ویدیوها می‌توانید به مخاطبان گسترده‌ای برسید و با اطلاعاتی که در یک ارائه ممکن است خسته‌کننده به‌نظر برسد، هدف‌گیری کنید. اکثر نظرسنجی‌ها و آمارها نشان می‌دهند که مردم ویدیوها را بیشتر از سایر انواع محتوا مشاهده و مصرف می‌کنند و عموماً چنین محتوایی را ترجیح می‌دهند.

{{% alert color="primary" %}} 
ممکن است بخواهید مبدل آنلاین **PowerPoint به Video** ما را بررسی کنید زیرا این یک پیاده‌سازی زنده و مؤثر از فرآیندی است که در اینجا توصیف شده است. 
{{% /alert %}} 

## **تبدیل PowerPoint به Video در Aspose.Slides**

Aspose.Slides از تبدیل ارائه به ویدیو پشتیبانی می‌کند.

* از **Aspose.Slides** برای تولید مجموعه‌ای از فریم‌ها (از اسلایدهای ارائه) که با FPS (فریم در ثانیه) خاصی مطابقت دارند، استفاده کنید.  
* از یک ابزار شخص ثالث مانند **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) برای ایجاد یک ویدیو بر پایه فریم‌ها استفاده کنید. 

### **تبدیل PowerPoint به Video**

1. ffmpeg را از [اینجا](https://ffmpeg.org/download.html) دانلود کنید.  
2. کد JavaScript تبدیل PowerPoint به Video را اجرا کنید.

این کد JavaScript نشان می‌دهد که چگونه یک ارائه (شامل یک شکل و دو اثر انیمیشن) را به ویدیو تبدیل کنید:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // یک شکل لبخند اضافه می‌کند و سپس آن را انیمیشن می‌دهد
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // پوشه باینری‌های ffmpeg را پیکربندی کنید. این صفحه را ببینید: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **افکت‌های ویدیو**

می‌توانید انیمیشن‌ها را بر روی اشیاء اسلایدها اعمال کنید و از انتقال‌ها بین اسلایدها استفاده نمایید.  

{{% alert color="primary" %}} 
ممکن است بخواهید این مقالات را ببینید: [PowerPoint Animation](https://docs.aspose.com/slides/fa/nodejs-java/powerpoint-animation/)، [Shape Animation](https://docs.aspose.com/slides/fa/nodejs-java/shape-animation/)، و [Shape Effect](https://docs.aspose.com/slides/fa/nodejs-java/shape-effect/). 
{{% /alert %}} 

انیمیشن‌ها و انتقال‌ها اسلایدشوها را جذاب‌تر و جالب‌تر می‌سازند—و همین کار را برای ویدیوها انجام می‌دهند. بیایید یک اسلاید دیگر و یک انتقال به کد ارائه قبلی اضافه کنیم:

```javascript
// یک شکل لبخند اضافه می‌کند و آن را انیمیشن می‌دهد
// ...
// یک اسلاید جدید اضافه می‌کند و انتقال انیمیشن‌دار
var newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());
newSlide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
newSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
newSlide.getSlideShowTransition().setType(aspose.slides.TransitionType.Push);
```

Aspose.Slides همچنین از انیمیشن متون پشتیبانی می‌کند. بنابراین پاراگراف‌ها را بر روی اشیاء انیمیشن می‌کنیم، که یکی پس از دیگری ظاهر می‌شوند (با تأخیر تنظیم‌شده برابر یک ثانیه):

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // متن و انیمیشن‌ها را اضافه می‌کند
    var autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 120, 300, 300);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Aspose Slides for Node.js via Java"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("convert PowerPoint Presentation with text to video"));
    var para3 = new aspose.slides.Paragraph();
    para3.getPortions().add(new aspose.slides.Portion("paragraph by paragraph"));
    var paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new aspose.slides.Paragraph());
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effect1 = mainSequence.addEffect(para1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect2 = mainSequence.addEffect(para2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect3 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect4 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    effect1.getTiming().setTriggerDelayTime(1.0);
    effect2.getTiming().setTriggerDelayTime(1.0);
    effect3.getTiming().setTriggerDelayTime(1.0);
    effect4.getTiming().setTriggerDelayTime(1.0);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // پوشه باینری‌های ffmpeg را پیکربندی کنید. این صفحه را ببینید: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **کلاس‌های تبدیل ویدیو**

برای انجام عملیات تبدیل PowerPoint به ویدیو، Aspose.Slides کلاس‌های [PresentationAnimationsGenerator](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationanimationsgenerator/) و [PresentationPlayer](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationplayer/) را ارائه می‌دهد.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationanimationsgenerator/) به شما امکان می‌دهد اندازه فریم برای ویدیو (که بعداً ساخته می‌شود) را از طریق سازنده‌اش تنظیم کنید. اگر یک نمونه از ارائه را پاس کنید، `Presentation.getSlideSize` استفاده می‌شود و انیمیشن‌هایی تولید می‌کند که [PresentationPlayer](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationplayer/) استفاده می‌کند.

هنگامی که انیمیشن‌ها تولید می‌شوند، یک رویداد `NewAnimation` برای هر انیمیشن پسین ایجاد می‌شود که پارامتر player انیمیشن ارائه را دارد. دومی کلاس نمایانگر پخش‌کننده‌ای برای یک انیمیشن جداگانه است.

برای کار با player انیمیشن ارائه، از متد `getDuration` (مدت زمان کامل انیمیشن) و متد `setTimePosition` استفاده می‌شود. هر موقعیت انیمیشن در بازه *0 تا duration* تنظیم می‌شود و سپس متد `getFrame` یک BufferedImage که با وضعیت انیمیشن در آن لحظه مطابقت دارد برمی‌گرداند:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // یک شکل لبخند اضافه می‌کند و آن را انیمیشن می‌دهد
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer -> {
            console.log(java.callStaticMethodSync("java.lang.String", "format", "Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0);// وضعیت اولیه انیمیشن
            try {
                // بیت‌مپ وضعیت اولیه انیمیشن
                animationPlayer.getFrame().save("firstFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration());// وضعیت نهایی انیمیشن
            try {
                // فریم آخر انیمیشن
                animationPlayer.getFrame().save("lastFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
        });
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

برای پخش همزمان تمام انیمیشن‌های یک ارائه، از کلاس [PresentationPlayer](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationplayer/) استفاده می‌شود. این کلاس یک نمونه از [PresentationAnimationsGenerator](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationanimationsgenerator/) و FPS برای افکت‌ها را در سازنده‌اش می‌گیرد و سپس برای تمام انیمیشن‌ها رویداد `FrameTick` را فراخوانی می‌کند تا آن‌ها پخش شوند:

```javascript
var presentation = new aspose.slides.Presentation("animated.pptx");
try {
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    arguments.getFrame().save(("frame_" + sender.getFrameIndex()) + ".png", aspose.slides.ImageFormat.Png);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

سپس فریم‌های تولید شده می‌توانند ترکیب شوند تا یک ویدیو ساخته شوند. بخش [Convert PowerPoint to Video](https://docs.aspose.com/slides/fa/nodejs-java/convert-powerpoint-to-video/#convert-powerpoint-to-video) را ببینید.

## **انیمیشن‌ها و افکت‌های پشتیبانی‌شده**

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

## **سوالات متداول**

**آیا امکان تبدیل ارائه‌های دارای رمز عبور وجود دارد؟**  
بله، Aspose.Slides امکان کار با ارائه‌های دارای رمز عبور را فراهم می‌کند. هنگام پردازش چنین فایل‌هایی باید رمز عبور صحیح را ارائه دهید تا کتابخانه بتواند به محتوای ارائه دسترسی پیدا کند.

**آیا Aspose.Slides از استفاده در راه‌حل‌های ابری پشتیبانی می‌کند؟**  
بله، Aspose.Slides می‌تواند در برنامه‌ها و سرویس‌های ابری یکپارچه شود. این کتابخانه برای کار در محیط‌های سرور طراحی شده است و عملکرد بالا و مقیاس‌پذیری مناسب برای پردازش دسته‌ای فایل‌ها را تضمین می‌کند.

**آیا محدودیت حجمی برای ارائه‌ها در حین تبدیل وجود دارد؟**  
Aspose.Slides قادر به پردازش ارائه‌های تقریباً با هر اندازه‌ای است. با این حال، هنگام کار با فایل‌های خیلی بزرگ ممکن است به منابع سیستم بیشتری نیاز باشد و گاهی توصیه می‌شود برای بهبود عملکرد، ارائه را بهینه‌سازی کنید.