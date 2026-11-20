---
title: مدیریت قاب‌های صوتی در ارائه‌ها بر روی Android
linktitle: قاب صوتی
type: docs
weight: 10
url: /fa/androidjava/audio-frame/
keywords:
- صوت
- قاب صوتی
- تصویر بندانگشتی
- افزودن صدا
- خصوصیات صدا
- گزینه‌های صدا
- استخراج صدا
- Android
- Java
- Aspose.Slides
description: "صدا را در اسلایدها جاسازی کنید، آیکن صوتی را تغییر دهید، پخش را پیکربندی کنید، زیرنویس‌های WebVTT را مدیریت کنید و صداهای انتقال اسلاید را با Aspose.Slides for Android via Java استخراج کنید."
---
## **نمای کلی**

یک قاب صوتی به شما امکان می‌دهد صدا را روی اسلاید پخش کنید. با Aspose.Slides for Android via Java می‌توانید یک کلیپ صوتی را جاسازی کنید، تصویری که نمایانگر آن است را انتخاب کنید، تنظیمات پخش را تنظیم کنید و زیرنویس‌ها را الصاق کنید. همچنین می‌توانید صدایی که به یک انتقال اسلاید اختصاص یافته است را بازیابی کنید.

## **ایجاد قاب‌های صوتی**

از [addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) برای جاسازی یک کلیپ صوتی محلی در اولین اسلاید استفاده کنید. دو مختصهٔ اول موقعیت قاب را روی اسلاید تعیین می‌کند و دو مقدار بعدی عرض و ارتفاع آن را به‌واحد نقطه تنظیم می‌کند. این مثال از [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) برای شروع خودکار کلیپ و از [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-) برای انتخاب پیش‌تنظیم صدای بلند استفاده می‌کند.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audioStream);
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تغییر تصویر بندانگشتی قاب صوتی**

به‌طور پیش‌فرض، یک قاب صوتی یک آیکن میکروفن را نمایش می‌دهد. برای نمایش تصویر بندانگشتی سفارشی، یک تصویر را با [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-) به ارائه اضافه کنید و با [setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-) آن را بر روی تصویر قاب تنظیم کنید. این مثال از یک JPEG به‌عنوان تصویر بندانگشتی برای کلیپ صوتی جاسازی‌شده استفاده می‌کند.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav");
     FileInputStream imageStream = new FileInputStream("eagle.jpeg")) {
    IPPImage thumbnail = presentation.getImages().addImage(imageStream);

    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioFrame.getPictureFormat().getPicture().setImage(thumbnail);

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تغییر گزینه‌های پخش صوت**

کنترل‌های **Audio Options** در پاورپوینت تعیین می‌کنند کلیپ چه‌وقت شروع شود، چه‌قدر بلند باشد و در طول نمایش اسلاید چگونه رفتار کند.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| کنترل پاورپوینت | متد Aspose.Slides for Android via Java |
| --- | --- |
| Start | [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| Volume preset | [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-) |
| Play Across Slides | [setPlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| Loop until Stopped | [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| Hide During Show | [setHideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| Rewind after Playing | [setRewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| Fade In | [setFadeInDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| Fade Out | [setFadeOutDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| Trim Audio start time | [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| Trim Audio end time | [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| Volume slider | [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

مثال اولین قاب صوتی را در اولین اسلاید پیدا می‌کند، با [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) پخش را با کلیک آغاز می‌کند و پیش‌تنظیم صدای پایین را انتخاب می‌کند. کلیپ در اسلایدها ادامه می‌یابد در حالی که حلقه‌سازی غیرفعال است. آیکن در طول نمایش مخفی می‌ماند و پس از پخش کلیپ به عقب برمی‌گردد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setPlayMode(AudioPlayModePreset.OnClick);
        audioFrame.setVolume(AudioVolumeMode.Low);
        audioFrame.setPlayAcrossSlides(true);
        audioFrame.setPlayLoopMode(false);
        audioFrame.setHideAtShowing(true);
        audioFrame.setRewindAudio(true);
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

برای کلیپی با طول بیش از ۳٫۵ ثانیه، این مثال ۱٫۵ ثانیهٔ اول و ۲ ثانیهٔ آخر را کنار می‌گذارد. [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) مدت زمان حذف‌شده از انتهای کلیپ را دریافت می‌کند. برای به‌دست آوردن زمان پایان نشان‌داده‌شده در پاورپوینت، این مقدار را از مدت زمان کل کلیپ کم کنید. کلیپ برش‌خورده به‌صورت ۲۰۰ میلی‌ثانیه‌ای fade‑in و ۵۰۰ میلی‌ثانیه‌ای fade‑out می‌شود. هر چهار متد مقادیر را به‌صورت میلی‌ثانیه می‌پذیرند.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioStream);
    audioFrame.setTrimFromStart(1500f);
    audioFrame.setTrimFromEnd(2000f);
    audioFrame.setFadeInDuration(200f);
    audioFrame.setFadeOutDuration(500f);

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای تنظیم حجم پخش به درصد خاص، از [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-) استفاده کنید. این مثال اولین قاب صوتی را در اولین اسلاید به ۸۵٪ تنظیم می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setVolumeValue(85f);
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

## **مدیریت زیرنویس‌های صوتی**

هر قاب صوتی دسترسی به مسیرهای زیرنویس خود را از طریق [getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) فراهم می‌کند. از این مجموعه می‌توانید زیرنویس‌های WebVTT را به کلیپ الصاق کنید، مسیرهای موجود را استخراج کنید یا آن‌ها را حذف کنید.

### **اضافه‌کردن زیرنویس‌های صوتی**

این مثال یک کلیپ صوتی را در اولین اسلاید جاسازی می‌کند و با [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-) یک مسیر WebVTT محلی الصاق می‌نماید. آرگومان اول برچسب مسیر را فراهم می‌کند و آرگومان دوم فایلی که شامل زیرنویس‌های زمانی است را شناسایی می‌کند.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audioStream);
    audioFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **استخراج زیرنویس‌های صوتی**

این مثال هر مسیر زیرنویس الصاق‌شده به یک قاب صوتی در اولین اسلاید را صادر می‌کند. داده‌های بایت دریافت‌شده از [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getBinaryData--) را در فایلی با فرمت WebVTT می‌نویسد و از شناسه‌ای که توسط [getCaptionId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getCaptionId--) بازگردانده می‌شود به عنوان نام فایل استفاده می‌کند تا هر مسیر خروجی جداگانه داشته باشد.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            try (FileOutputStream output = new FileOutputStream(track.getCaptionId() + ".vtt")) {
                output.write(track.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

### **حذف زیرنویس‌های صوتی**

از [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) یا [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) برای حذف یک مسیر خاص استفاده کنید. این مثال با استفاده از [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#clear--) تمام زیرنویس‌ها را از اولین قاب صوتی در اولین اسلاید حذف می‌کند در حالی که کلیپ حفظ می‌شود.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.getCaptionTracks().clear();
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

### **یافتن یک خط در زیرنویس‌های صوتی**

برای یافتن یک خط در زیرنویس‌های صوتی اولین اسلاید، متن بازگشتی از [getDataAsString](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getDataAsString--) را در حافظه جستجو کنید. در یک کد WebVTT متنی، خط زمان‌گذاری شامل `-->` است، خطوط زیرنویس پس از آن می‌آیند و یک خط خالی کد را خاتمه می‌دهد. این مثال برچسب مسیر و هر خط زیرنویس حاوی «café» را چاپ می‌کند.

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            boolean inCue = false;
            String captions = track.getDataAsString();
            for (String line : captions.split("\\r\\n|\\r|\\n")) {
                if (line.isEmpty()) {
                    inCue = false;
                } else if (line.contains("-->")) {
                    inCue = true;
                } else if (inCue && line.toLowerCase(Locale.ROOT).contains("café")) {
                    System.out.println(track.getLabel() + ": " + line);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **استخراج صدا**

یک انتقال اسلاید می‌تواند صدای خودش را داشته باشد. برای بازیابی آن، بر روی انتقال اسلاید [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSound--) فراخوانی کنید. این مثال بایت‌های بازگشتی از [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--) را دریافت می‌کند و تعداد بایت‌ها را چاپ می‌نماید. اگر اسلاید اول صدا نداشته باشد، به‌جای آن پیام متنی چاپ می‌شود.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioSlide.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudio sound = slide.getSlideShowTransition().getSound();
    if (sound != null) {
        byte[] audioData = sound.getBinaryData();
        System.out.println("Transition sound: " + audioData.length + " bytes.");
    } else {
        System.out.println("The first slide has no transition sound.");
    }
} finally {
    presentation.dispose();
}
```

## **پرسش‌های متداول**

**آیا می‌توانم همان کلیپ صوتی را در اسلایدهای متعدد بدون تکثیر استفاده کنم؟**

بله. کلیپ را یک‌بار به [audio collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) ارائه اضافه کنید و همان شیء صوتی را برای هر اسلاید به [addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-) پاس دهید.

**آیا می‌توانم صدای موجود در یک قاب صوتی را جایگزین کنم؟**

بله. برای صدای پیوندی، از [setLinkPathLong](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) برای اشاره به فایل جایگزین استفاده کنید. برای صدای جاسازی‌شده، با [setEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) کلیپ دیگری از مجموعهٔ صوتی ارائه انتخاب کنید. هر دو روش قاب موجود را حفظ می‌کنند.

**آیا برش صدا دادهٔ صوتی ذخیره‌شده در ارائه را تغییر می‌دهد؟**

نه. [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) و [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) مرزهای پخش را تنظیم می‌کنند. شما هنوز می‌توانید کلیپ کامل را از [getEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getEmbeddedAudio--) دریافت کنید.