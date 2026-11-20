---
title: مدیریت فریم‌های صوتی در ارائه‌ها با استفاده از جاوا
linktitle: فریم صوتی
type: docs
weight: 10
url: /fa/java/audio-frame/
keywords:
- صدا
- فریم صوتی
- تصویر بندانگشتی
- افزودن صدا
- ویژگی‌های صدا
- گزینه‌های صدا
- استخراج صدا
- جاوا
- Aspose.Slides
description: "صدا را در اسلایدها جاسازی کنید، نماد صوتی را تغییر دهید، پخش را تنظیم کنید، زیرنویس‌های WebVTT را مدیریت کنید و صداهای انتقال اسلاید را با Aspose.Slides برای جاوا استخراج کنید."
---
## **نمای کلی**

یک فریم صوتی به شما امکان می‌دهد تا یک صدا را در یک اسلاید پخش کنید. با Aspose.Slides for Java می‌توانید یک کلیپ صوتی را جاسازی کنید، تصویر نمایانگر آن را انتخاب کنید، تنظیمات پخش را تنظیم کنید و زیرنویس‌ها را ضمیمه کنید. همچنین می‌توانید صدایی که به یک انتقال اسلاید اختصاص داده شده است را بازیابی کنید.

## **ایجاد فریم‌های صوتی**

از [addAudioFrameEmbedded](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) برای جاسازی یک کلیپ صوتی محلی در اسلاید اول استفاده کنید. دو مختصات اول موقعیت فریم را بر روی اسلاید تعیین می‌کنند و دو مقدار بعدی عرض و ارتفاع آن را (به نقطه) تنظیم می‌نمایند. این مثال از [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) برای شروع خودکار کلیپ و از [setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolume-int-) برای انتخاب پیش‌تنظیم صدای بلند استفاده می‌کند.

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

## **تغییر تصویر بندانگشتی فریم صوتی**

به‌طور پیش‌فرض، یک فریم صوتی نماد میکروفن را نمایش می‌دهد. برای نمایش تصویر بندانگشتی سفارشی، یک تصویر را با [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-) به ارائه اضافه کنید و با [setImage](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-) آن را بر روی تصویر فریم تنظیم کنید. مثال از یک JPEG به‌عنوان تصویر بندانگشتی برای یک کلیپ صوتی جاسازی‌شده استفاده می‌کند.

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

## **تغییر گزینه‌های پخش صدا**

کنترل‌های **Audio Options** در PowerPoint زمان شروع کلیپ، میزان صدا و رفتار آن در طول ارائه را تعیین می‌کنند.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| کنترل PowerPoint | متد Aspose.Slides for Java |
| --- | --- |
| Start | [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| Volume preset | [setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolume-int-) |
| Play Across Slides | [setPlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| Loop until Stopped | [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| Hide During Show | [setHideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| Rewind after Playing | [setRewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| Fade In | [setFadeInDuration](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| Fade Out | [setFadeOutDuration](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| Trim Audio start time | [setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| Trim Audio end time | [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| Volume slider | [setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

مثال اولین فریم صوتی را در اسلاید اول پیدا می‌کند، از [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) برای شروع پخش با کلیک استفاده می‌کند و پیش‌تنظیم صدای کم را انتخاب می‌کند. کلیپ در اسلایدها ادامه می‌یابد و حلقه‌پذیری غیرفعال است. نماد در طول نمایش مخفی می‌ماند و پس از پایان پخش کلیپ به عقب برمی‌گردد.

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

برای کلیپی که طول آن بیش از ۳٫۵ ثانیه است، این مثال ۱٫۵ ثانیه اول و ۲ ثانیه آخر را حذف می‌کند. [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) مدت‌زمانی را که باید از انتهای کلیپ حذف شود، دریافت می‌کند. برای به‌دست آوردن زمان انتهایی که در PowerPoint نشان داده می‌شود، این مقدار را از طول کامل کلیپ کم کنید. کلیپ برش‌خورده با ۲۰۰ میلی‌ثانیه به‌صورت تدریجی ظاهر می‌شود و با ۵۰۰ میلی‌ثانیه به‌صورت تدریجی ناپدید می‌شود. چهار متد همه مقادیر را بر حسب میلی‌ثانیه می‌پذیرند.

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

برای تنظیم صدای پخش به درصد خاصی، از [setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolumeValue-float-) استفاده کنید. این مثال اولین فریم صوتی را در اسلاید اول به ۸۵٪ تنظیم می‌کند.

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

هر فریم صوتی دسترسی به مسیرهای زیرنویس خود را از طریق [getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) فراهم می‌کند. از این مجموعه می‌توانید زیرنویس‌های WebVTT را به کلیپ الصاق کنید، مسیرهای موجود را استخراج کنید یا آن‌ها را حذف کنید.

### **افزودن زیرنویس‌های صوتی**

مثال یک کلیپ صوتی را در اسلاید اول جاسازی می‌کند و با [add](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-) یک مسیر WebVTT محلی الصاق می‌نماید. آرگومان اول برچسب مسیر را فراهم می‌کند و آرگومان دوم فایلی را که حاوی زیرنویس‌های زمان‌بندی شده است، شناسایی می‌کند.

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

این مثال هر مسیر زیرنویس الصاق شده به یک فریم صوتی در اسلاید اول را استخراج می‌کند. بایت‌های بازگردانده‌شده توسط [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getBinaryData--) را در یک فایل WebVTT می‌نویسد و از شناسه‌ای که توسط [getCaptionId](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getCaptionId--) بازگردانده می‌شود، برای نامگذاری فایل استفاده می‌کند تا هر مسیر خروجی جداگانه داشته باشد.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            Path output = Paths.get(track.getCaptionId() + ".vtt");
            Files.write(output, track.getBinaryData());
        }
    }
} finally {
    presentation.dispose();
}
```

### **حذف زیرنویس‌های صوتی**

از [remove](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) یا [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#removeAt-int-) برای حذف یک مسیر خاص استفاده کنید. مثال از [clear](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#clear--) برای حذف تمام زیرنویس‌ها از اولین فریم صوتی در اسلاید اول استفاده می‌کند در حالی که کلیپ را حفظ می‌کند.

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

### **یافتن خطی در زیرنویس‌های صوتی**

برای یافتن خطی در زیرنویس‌های صوتی اسلاید اول، متن بازگردانده‌شده توسط [getDataAsString](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getDataAsString--) را در حافظه جستجو کنید. در یک cue متنی ساده WebVTT، خط زمان‌بندی شامل `-->` است، خطوط زیرنویس پس از آن می‌آیند و یک خط خالی cue را پایان می‌دهد. این مثال برچسب مسیر و هر خط زیرنویس حاوی «café» را چاپ می‌کند.

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
            for (String line : captions.split("\\R")) {
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

یک انتقال اسلاید می‌تواند صدای مخصوص به خود را داشته باشد. برای بازیابی آن، بر روی انتقال اسلاید فراخوانی [getSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSound--) انجام دهید. مثال بایت‌های بازگردانده‌شده توسط [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/iaudio/#getBinaryData--) را دسترسی می‌یابد و تعداد بایت‌ها را چاپ می‌کند. اگر اسلاید اول صدای انتقال نداشته باشد، به جای آن یک پیام چاپ می‌شود.

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

## **سؤال‌های متداول**

**آیا می‌توانم همان کلیپ صوتی را در چندین اسلاید بدون تکرار استفاده کنم؟**

بله. کلیپ را یک بار به [audio collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) ارائه اضافه کنید و همان شیء صوتی را برای هر اسلاید به [addAudioFrameEmbedded](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-) پاس بدهید.

**آیا می‌توانم صدای یک فریم صوتی موجود را جایگزین کنم؟**

بله. برای صدای پیوندی، از [setLinkPathLong](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) برای اشاره به فایل جایگزین استفاده کنید. برای صدای جاسازی‌شده، با [setEmbeddedAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) یک کلیپ دیگر از مجموعه صوتی ارائه انتخاب کنید. هر دو روش فریم موجود را حفظ می‌کند.

**آیا برش صدا داده‌های صوتی ذخیره‌شده در ارائه را تغییر می‌دهد؟**

نه. [setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) و [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) مرزهای پخش را تنظیم می‌کنند. همچنان می‌توانید کلیپ کامل را از [getEmbeddedAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#getEmbeddedAudio--) بازیابی کنید.