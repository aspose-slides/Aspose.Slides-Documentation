---
title: مدیریت صدا در ارائه‌ها روی اندروید
linktitle: قاب صوتی
type: docs
weight: 10
url: /fa/androidjava/audio-frame/
keywords:
- صدا
- قاب صوتی
- تصویر کوچک
- اضافه کردن صدا
- ویژگی‌های صدا
- گزینه‌های صدا
- استخراج صدا
- اندروید
- جاوا
- Aspose.Slides
description: "ایجاد و کنترل قاب‌های صوتی در Aspose.Slides برای اندروید—مثال‌های جاوا برای جاسازی، برش، حلقه‌گذاری و پیکربندی پخش در ارائه‌های PPT، PPTX و ODP."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه با فریم‌های صوتی در Aspose.Slides کار کنید. این مقاله نشان می‌دهد چگونه صداهای جاسازی‌شده را به اسلایدها اضافه کنید، تصویر کوچک فریم صوتی را سفارشی کنید، گزینه‌های پخش مانند صدا، تکرار، مخفی‌سازی، برش و مدت زمان‌های محو شدن را پیکربندی کنید و صداهای استفاده‌شده در انتقال‌های نمایش اسلاید را استخراج کنید.

## **ایجاد فریم‌های صوتی**
Aspose.Slides برای Android از طریق Java به شما امکان می‌دهد فایل‌های صوتی را به اسلایدها اضافه کنید. فایل‌های صوتی به عنوان فریم‌های صوتی در اسلایدها جاسازی می‌شوند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) را ایجاد کنید.
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
3. جریان فایل صوتی که می‌خواهید در اسلاید جاسازی کنید را بارگذاری کنید.
4. فریم صوتی جاسازی‌شده (شامل فایل صوتی) را به اسلاید اضافه کنید.
5. مقدار [PlayMode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/AudioPlayModePreset) و `Volume` که توسط شیء [IAudioFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IAudioFrame) ارائه می‌شود را تنظیم کنید.
6. ارائه تغییر یافته را ذخیره کنید.

این کد Java نشان می‌دهد چگونه یک فریم صوتی جاسازی‌شده را به اسلاید اضافه کنید:

```java
// یک شیء از کلاس Presentation می‌سازد که یک فایل ارائه را نمایندگی می‌کند
Presentation pres = new Presentation();
try {
    // اسلاید اول را دریافت می‌کند
    ISlide sld = pres.getSlides().get_Item(0);

    // فایل صوتی wav را به جریان می‌خواند
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // فریم صوتی را اضافه می‌کند
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // حالت پخش و حجم صدا را تنظیم می‌کند
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // فایل PowerPoint را بر روی دیسک می‌نویسد
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **تغییر تصویر کوچک فریم صوتی**

هنگامی که یک فایل صوتی را به ارائه اضافه می‌کنید، صدا به صورت یک فریم با تصویر پیش‌فرض استاندارد ظاهر می‌شود (تصویر را در بخش زیر ببینید). می‌توانید تصویر پیش‌نمایش فریم صوتی را تغییر دهید (تصویر دلخواه خود را تنظیم کنید).

این کد Java نشان می‌دهد چگونه تصویر کوچک یا پیش‌نمایش یک فریم صوتی را تغییر دهید:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک فریم صوتی را با موقعیت و اندازه مشخص به اسلاید اضافه می‌کند.
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

    // Sets the image for the audio frame.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //ارائهٔ تغییر یافته را بر روی دیسک ذخیره می‌کند
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **تغییر گزینه‌های پخش صدا**

Aspose.Slides برای Android از طریق Java به شما امکان می‌دهد گزینه‌هایی را که کنترل پخش یا ویژگی‌های صدا را تنظیم می‌کنند، تغییر دهید. به عنوان مثال می‌توانید حجم صدا را تنظیم کنید، صدا را به شکل حلقه‌ای پخش کنید یا حتی نماد صدا را مخفی کنید.

پنل **Audio Options** در Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

**Audio Options** در PowerPoint که با ویژگی‌های Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/AudioFrame) مطابقت دارد:

- **Start** لیست کشویی مطابق با ویژگی [AudioFrame.PlayMode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) است
- **Volume** مطابق با ویژگی [AudioFrame.Volume](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/AudioFrame#getVolume--) است
- **Play Across Slides** مطابق با ویژگی [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) است
- **Loop until Stopped** مطابق با ویژگی [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) است
- **Hide During Show** مطابق با ویژگی [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) است
- **Rewind after Playing** مطابق با ویژگی [AudioFrame.RewindAudio](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) است

**Editing** در PowerPoint که با ویژگی‌های Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/audioframe/) مطابقت دارد:

- **Fade In** مطابق با ویژگی [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) است
- **Fade Out** مطابق با ویژگی [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) است
- **Trim Audio Start Time** مطابق با ویژگی [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) است
- **Trim Audio End Time** مقدار برابر است با مدت زمان صدا منهای مقدار ویژگی [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) 

کنترل **Volume** در پنل کنترل صدا در PowerPoint با ویژگی [AudioFrame.VolumeValue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/audioframe/#getVolumeValue--) مطابقت دارد. این امکان را می‌دهد تا حجم صدا را به درصد تغییر دهید.

این‌گونه می‌توانید گزینه‌های پخش صدا را تغییر دهید:

1. [Сreate](#create-audio-frame) یا دریافت فریم صوتی.
2. مقادیر جدید را برای ویژگی‌های فریم صوتی که می‌خواهید تنظیم کنید، تنظیم کنید.
3. فایل PowerPoint تغییر یافته را ذخیره کنید.

این کد Java عملی را نشان می‌دهد که در آن گزینه‌های صدا تنظیم می‌شوند:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // شکل AudioFrame را دریافت می‌کند
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // حالت پخش را روی پخش با کلیک تنظیم می‌کند
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // حجم صدا را به پایین تنظیم می‌کند
    audioFrame.setVolume(AudioVolumeMode.Low);

    // صدا را برای پخش در تمام اسلایدها تنظیم می‌کند
    audioFrame.setPlayAcrossSlides(true);

    // حلقه پخش صدا را غیرفعال می‌کند
    audioFrame.setPlayLoopMode(false);

    // AudioFrame را در طول نمایش اسلاید مخفی می‌کند
    audioFrame.setHideAtShowing(true);

    // پس از پخش، صدا را به ابتدای آن برمی‌گرداند
    audioFrame.setRewindAudio(true);

    // فایل PowerPoint را بر روی دیسک ذخیره می‌کند
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

این مثال Java نشان می‌دهد چگونه یک فریم صوتی جدید با صوت جاسازی‌شده اضافه کنید، آن را برش دهید و مدت زمان‌های محو شدن را تنظیم کنید:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // آفست شروع برش را به ۱٫۵ ثانیه تنظیم می‌کند
    // آفست پایان برش را به ۲ ثانیه تنظیم می‌کند

    // مدت زمان محو شدن ورودی را به ۲۰۰ میلی‌ثانیه تنظیم می‌کند
    // مدت زمان محو شدن خروجی را به ۵۰۰ میلی‌ثانیه تنظیم می‌کند

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

نمونه کد زیر نشان می‌دهد چگونه یک فریم صوتی با صوت جاسازی‌شده بازیابی کرده و حجم آن را به 85٪ تنظیم کنید:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // یک شکل فریم صوتی را دریافت می‌کند
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // حجم صدا را به 85٪ تنظیم می‌کند
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **مدیریت زیرنویس‌های صوتی**

Aspose.Slides به شما امکان می‌دهد زیرنویس‌های بسته شده را به یک فریم صوتی از طریق متد [getCaptionTracks](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) اضافه کنید. این متد یک [ICaptionsCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icaptionscollection/) را برمی‌گرداند که به شما اجازه می‌دهد مسیرهای زیرنویس WebVTT را اضافه کنید، در مسیرهای موجود مرور کنید و در صورت نیاز آن‌ها را حذف نمایید.

**افزودن زیرنویس‌های صوتی**

از متد [getCaptionTracks](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) برای الصاق یک یا چند مسیر زیرنویس به فریم صوتی استفاده کنید. در مثال زیر، یک فایل صوتی به اسلاید اضافه می‌شود و سپس یک مسیر زیرنویس جدید از فایل `.vtt` بارگذاری می‌شود.

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // یک مسیر کپشن جدید از فایل WebVTT اضافه می‌کند.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**استخراج زیرنویس‌های صوتی**

می‌توانید در مسیرهای زیرنویس مرتبط با فریم صوتی مرور کنید و آن‌ها را به صورت فایل‌های `.vtt` ذخیره کنید. هر مسیر زیرنویس داده‌های باینری و شناسه منحصر به فرد خود را ارائه می‌دهد که هنگام صادرات زیرنویس‌ها قابل استفاده است.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // مسیر کپشن را به عنوان فایل .vtt ذخیره می‌کند.
                FileOutputStream fos = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                fos.write(captionTrack.getBinaryData());
                fos.close();
            }
        }
    }
} catch (IOException e){
} finally {
    presentation.dispose();
}
```

**حذف زیرنویس‌های صوتی**

برای حذف زیرنویس‌ها از یک فریم صوتی، از متدهای ارائه‌شده توسط [ICaptionsCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icaptionscollection/) مانند [clear](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icaptionscollection/#clear--)، [remove](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-)، یا [removeAt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) استفاده کنید. مثال زیر تمام مسیرهای زیرنویس را از فریم صوتی حذف می‌کند.

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

Aspose.Slides برای Android از طریق Java به شما امکان می‌دهد صداهای استفاده‌شده در انتقال‌های نمایش اسلاید را استخراج کنید. برای مثال می‌توانید صدای استفاده‌شده در یک اسلاید خاص را استخراج کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید و ارائه حاوی صدا را بارگذاری کنید.
2. مرجع اسلاید مربوطه را از طریق ایندکس آن دریافت کنید.
3. به [slideshow transitions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) اسلاید دسترسی پیدا کنید.
4. صدای مورد نظر را به شکل داده‌های بایت استخراج کنید.

این کد Java نشان می‌دهد چگونه صداهای استفاده‌شده در یک اسلاید را استخراج کنید:

```java
// یک شیء از کلاس Presentation می‌سازد که یک فایل ارائه را نمایندگی می‌کند
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // به اسلاید موردنظر دسترسی می‌یابد
    ISlide slide = pres.getSlides().get_Item(0);
    
    // اثرات انتقال اسلایدشو را برای اسلاید دریافت می‌کند
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    // صدای انتقال را به صورت آرایه بایت استخراج می‌کند
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **پرسش‌های متداول**

**آیا می‌توانم دارایی صوتی یکسان را در چندین اسلاید بدون افزایش حجم فایل استفاده مجدد کنم؟**  
بله. صدا را یکبار به مجموعه مشترک [audio collection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getAudios--) ارائه اضافه کنید و فریم‌های صوتی اضافی که به آن دارایی موجود ارجاع می‌دهند، ایجاد کنید. این کار از تکرار داده‌های رسانه‌ای جلوگیری می‌کند و اندازه ارائه را کنترل می‌دارد.

**آیا می‌توانم صدای موجود در یک فریم صوتی را بدون ایجاد دوباره شکل جایگزین کنم؟**  
بله. برای صدای پیوندی، مسیر [link path](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) را به فایل جدید تغییر دهید. برای صدای جاسازی‌شده، شیء [embedded audio](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) را با دیگری از [audio collection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getAudios--) ارائه جایگزین کنید. قالب‌بندی فریم و اکثر تنظیمات پخش بدون تغییر باقی می‌مانند.

**آیا برش صدا داده‌های صوتی زیرین ذخیره‌شده در ارائه را تغییر می‌دهد؟**  
خیر. برش فقط مرزهای پخش را تنظیم می‌کند. بایت‌های اصلی صدا بدون تغییر باقی می‌مانند و از طریق صوت جاسازی‌شده یا مجموعه صوتی ارائه در دسترس هستند.