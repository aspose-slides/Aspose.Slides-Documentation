---
title: "مدیریت صدا در ارائه‌ها با استفاده از جاوا"
linktitle: "فریم صوتی"
type: docs
weight: 10
url: /fa/java/audio-frame/
keywords:
- "صدا"
- "فریم صوتی"
- "تصویر کوچک"
- "اضافه کردن صدا"
- "ویژگی‌های صدا"
- "گزینه‌های صدا"
- "استخراج صدا"
- "جاوا"
- "Aspose.Slides"
description: "ایجاد و کنترل فریم‌های صوتی در Aspose.Slides برای جاوا—نمونه‌های کد برای جاسازی، برش، حلقه‌زدن و پیکربندی پخش در ارائه‌های PPT، PPTX و ODP."
---
## **بررسی اجمالی**

این مقاله توضیح می‌دهد که چگونه با فریم‌های صوتی در Aspose.Slides کار کنید. این مقاله نشان می‌دهد چگونه صداهای جاسازی‌شده را به اسلایدها اضافه کنید، تصویر کوچک فریم صوتی را سفارشی کنید، گزینه‌های پخش مانند حجم، حلقه‌زدن، مخفی‌کردن، برش و مدت زمان محو شدن را پیکربندی کنید و صدای استفاده شده در انتقال‌های نمای اسلاید را استخراج کنید.

## **ایجاد فریم‌های صوتی**

Aspose.Slides برای Java به شما اجازه می‌دهد فایل‌های صوتی را به اسلایدها اضافه کنید. فایل‌های صوتی به‌عنوان فریم‌های صوتی در اسلایدها جاسازی می‌شوند. 

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسلاید را از طریق اندیس آن بدست آورید.
3. جریان فایل صوتی که می‌خواهید در اسلاید جاسازی کنید را بارگذاری کنید.
4. فریم صوتی جاسازی‌شده (حاوی فایل صوتی) را به اسلاید اضافه کنید.
5. مقدار [PlayMode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/AudioPlayModePreset) و `Volume` ارائه‌شده توسط شیء [IAudioFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAudioFrame) را تنظیم کنید.
6. ارائه اصلاح‌شده را ذخیره کنید.

این کد Java نشان می‌دهد چگونه یک فریم صوتی جاسازی‌شده را به یک اسلاید اضافه کنید:

```java
// یک شی Presentation ایجاد می‌کند که نمایانگر فایل ارائه است
Presentation pres = new Presentation();
try {
    // اسلاید اول را دریافت می‌کند
    ISlide sld = pres.getSlides().get_Item(0);

    // فایل صوتی wav را به‌صورت جریان بارگذاری می‌کند
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // فریم صوتی را اضافه می‌کند
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // حالت پخش و حجم صدا را تنظیم می‌کند
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // فایل PowerPoint را روی دیسک می‌نویسد
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **تغییر تصویر کوچک فریم صوتی**

زمانی که یک فایل صوتی را به یک ارائه اضافه می‌کنید، صدا به‌صورت فریمی با تصویر پیش‌فرض استاندارد ظاهر می‌شود (به تصویر در بخش زیر نگاه کنید). می‌توانید تصویر پیش‌نمایش فریم صوتی را تغییر دهید (تصویر دلخواه خود را تنظیم کنید).

این کد Java نشان می‌دهد چگونه تصویر کوچک یا پیش‌نمایش فریم صوتی را تغییر دهید:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک فریم صوتی را با موقعیت و اندازهٔ مشخص به اسلاید اضافه می‌کند.
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // یک تصویر را به منابع ارائه اضافه می‌کند.
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // تصویر را برای فریم صوتی تنظیم می‌کند.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //ارائهٔ تغییر یافته را روی دیسک ذخیره می‌کند
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **تغییر گزینه‌های پخش صدا**

Aspose.Slides برای Java به شما امکان می‌دهد گزینه‌هایی را که کنترل پخش یا ویژگی‌های صدا را تنظیم می‌کنند، تغییر دهید. به عنوان مثال می‌توانید حجم صدا را تنظیم کنید، صدا را به‌صورت حلقه‌دار پخش کنید یا حتی نماد صدا را مخفی کنید.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/AudioFrame) properties:

- **Start** فهرست کشویی با متد [AudioFrame.setPlayMode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/audioframe/#setPlayMode-int-) مطابقت دارد
- **Volume** با متد [AudioFrame.setVolume](https://reference.aspose.com/slides/fa/java/com.aspose.slides/audioframe/#setVolume-int-) مطابقت دارد
- **Play Across Slides** با متد [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-) مطابقت دارد
- **Loop until Stopped** با متد [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-) مطابقت دارد
- **Hide During Show** با متد [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/fa/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-) مطابقت دارد
- **Rewind after Playing** با متد [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/fa/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-) مطابقت دارد

PowerPoint **Editing** options that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/AudioFrame) properties:

- **Fade In** با متد [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/fa/java/com.aspose.slides/audioframe/#setFadeInDuration-float-) مطابقت دارد
- **Fade Out** با متد [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/fa/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-) مطابقت دارد
- **Trim Audio Start Time** با متد [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/fa/java/com.aspose.slides/audioframe/#setTrimFromStart-float-) مطابقت دارد
- **Trim Audio End Time** مقدار برابر با مدت زمان صدا منهای مقدار متد [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/fa/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-) است

کنترل **Volume** در PowerPoint که روی پنل کنترل صدا قرار دارد، با متد [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/audioframe/#setVolumeValue-float-) مطابقت دارد. این امکان را می‌دهد تا حجم صدا را به‌عنوان درصد تغییر دهید.

این نحوه تغییر گزینه‌های پخش صدا است:

1. [ایجاد](#create-audio-frame) یا دریافت فریم صوتی.
2. مقادیر جدید برای ویژگی‌های فریم صوتی که می‌خواهید تنظیم کنید، تنظیم کنید.
3. فایل PowerPoint اصلاح‌شده را ذخیره کنید.

این کد Java نشان می‌دهد چگونه گزینه‌های یک صدا تنظیم می‌شوند:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // شکل AudioFrame را دریافت می‌کند
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // حالت پخش را برای پخش با کلیک تنظیم می‌کند
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // حجم را به مقدار کم تنظیم می‌کند
    audioFrame.setVolume(AudioVolumeMode.Low);

    // صدا را برای پخش در سراسر اسلایدها تنظیم می‌کند
    audioFrame.setPlayAcrossSlides(true);

    // حلقه‌زدن صدا را غیرفعال می‌کند
    audioFrame.setPlayLoopMode(false);

    // فریم صوتی را در طول نمایش اسلایدها مخفی می‌کند
    audioFrame.setHideAtShowing(true);

    // صدا را پس از پخش به ابتدا برمی‌گرداند
    audioFrame.setRewindAudio(true);

    // فایل PowerPoint را روی دیسک ذخیره می‌کند
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

این مثال Java نشان می‌دهد چگونه فریم صوتی جدیدی با صدا جاسازی‌شده اضافه کنید، آن را برش دهید و مدت زمان محو شدن را تنظیم کنید:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // آفست شروع برش را به ۱٫۵ ثانیه تنظیم می‌کند
    audioFrame.setTrimFromStart(1500f);
    // آفست پایان برش را به ۲ ثانیه تنظیم می‌کند
    audioFrame.setTrimFromEnd(2000f);

    // مدت زمان محو شدن ورودی را به ۲۰۰ میلی‌ثانیه تنظیم می‌کند
    audioFrame.setFadeInDuration(200f);
    // مدت زمان محو شدن خروجی را به ۵۰۰ میلی‌ثانیه تنظیم می‌کند
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

نمونه کد زیر نشان می‌دهد چگونه فریم صوتی با صدا جاسازی‌شده بازیابی شده و حجم آن به 85٪ تنظیم می‌شود:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // یک شکل فریم صوتی دریافت می‌کند
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // حجم صدا را به ۸۵٪ تنظیم می‌کند
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **مدیریت کپشن‌های صوتی**

Aspose.Slides به شما امکان می‌دهد کپشن‌های بسته (closed captions) را به یک فریم صوتی از طریق متد [getCaptionTracks](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) اضافه کنید. این متد یک [ICaptionsCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icaptionscollection/) باز می‌گرداند که به شما اجازه می‌دهد مسیرهای کپشن WebVTT را اضافه کنید، از مسیرهای موجود عبور کنید و در صورت نیاز آن‌ها را حذف کنید.

**اضافه کردن کپشن‌های صوتی**

از متد [getCaptionTracks](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) استفاده کنید تا یک یا چند مسیر کپشن را به فریم صوتی متصل کنید. در مثال زیر، یک فایل صوتی به اسلاید اضافه می‌شود و سپس مسیر کپشن جدیدی از یک فایل `.vtt` بارگذاری می‌شود.

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // یک مسیر کپشن جدید از یک فایل WebVTT اضافه می‌کند.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**استخراج کپشن‌های صوتی**

می‌توانید از مسیرهای کپشن مرتبط با فریم صوتی عبور کنید و آن‌ها را به‌صورت فایل‌های `.vtt` ذخیره کنید. هر مسیر کپشن داده باینری و شناسهٔ منحصر به‌فرد خود را ارائه می‌دهد که می‌تواند در هنگام استخراج کپشن‌ها استفاده شود.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame ) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // مسیر کپشن را به عنوان فایل .vtt ذخیره می‌کند.
                Path filePath = Paths.get(captionTrack.getCaptionId() + ".vtt");
                Files.write(filePath, captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**حذف کپشن‌های صوتی**

برای حذف کپشن‌ها از یک فریم صوتی، از متدهای ارائه‌شده توسط [ICaptionsCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icaptionscollection/) استفاده کنید، مانند [clear](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icaptionscollection/#clear--)، [remove](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) یا [removeAt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icaptionscollection/#removeAt-int-). مثال زیر تمام مسیرهای کپشن را از فریم صوتی حذف می‌کند.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // تمام مسیرهای کپشن را از فریم صوتی حذف می‌کند.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **استخراج صدا**

Aspose.Slides برای Java به شما امکان می‌دهد صدای استفاده‌شده در انتقال‌های نمایش اسلایدها را استخراج کنید. به عنوان مثال می‌توانید صدای مورد استفاده در یک اسلاید خاص را استخراج کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید و ارائه حاوی صدا را بارگذاری کنید.
2. مرجع اسلاید مربوطه را از طریق اندیس آن بدست آورید.
3. به [slideshow transitions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) برای اسلاید دسترسی پیدا کنید.
4. صدا را به‌صورت داده بایت استخراج کنید.

این کد Java نشان می‌دهد چگونه صدای استفاده‌شده در یک اسلاید استخراج شود:

```java
// یک شی از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // اسلاید مورد نظر را دسترسی می‌گیرد
    ISlide slide = pres.getSlides().get_Item(0);
    
    // اثرات انتقال اسلاید شو را برای اسلاید دریافت می‌کند
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //صدا را به صورت آرایه بایت استخراج می‌کند
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **پرسش‌های متداول**

**آیا می‌توانم همان فایل صوتی را در چندین اسلاید بدون افزایش حجم فایل استفاده مجدد کنم؟**

بله. صدا را یک بار به [audio collection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getAudios--) مشترک ارائه اضافه کنید و فریم‌های صوتی اضافی که به آن دارایی موجود ارجاع می‌دهند ایجاد کنید. این کار از تکرار داده‌های رسانه‌ای جلوگیری می‌کند و اندازه ارائه را تحت کنترل نگه می‌دارد.

**آیا می‌توانم صدا را در یک فریم صوتی موجود بدون ایجاد دوباره شکل جایگزین کنم؟**

بله. برای صدای لینک‌شده، مسیر [link path](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) را به فایل جدید اشاره دهید. برای صدای جاسازی‌شده، شیء [embedded audio](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) را با صدای دیگری از [audio collection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getAudios--) ارائه تعویض کنید. قالب‌بندی فریم و اکثر تنظیمات پخش دست نخورده می‌مانند.

**آیا برش کردن باعث تغییر داده‌های صوتی اصلی ذخیره‌شده در ارائه می‌شود؟**

خیر. برش فقط مرزهای پخش را تنظیم می‌کند. بایت‌های اصلی صدا دست‌نخورده می‌مانند و از طریق صدای جاسازی‌شده یا مجموعه صوتی ارائه قابل دسترسی هستند.