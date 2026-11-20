---
title: إدارة إطارات الصوت في العروض التقديمية على Android
linktitle: إطار صوت
type: docs
weight: 10
url: /ar/androidjava/audio-frame/
keywords:
- صوت
- إطار صوت
- صورة مصغرة
- إضافة صوت
- خصائص الصوت
- خيارات الصوت
- استخراج الصوت
- Android
- Java
- Aspose.Slides
description: "تضمين الصوت في الشرائح، تغيير أيقونة الصوت، تكوين التشغيل، إدارة ترجمات WebVTT، واستخراج أصوات انتقال الشرائح باستخدام Aspose.Slides for Android عبر Java."
---
## **نظرة عامة**

إطار الصوت يسمح لك بتشغيل صوت على شريحة. باستخدام Aspose.Slides for Android عبر Java، يمكنك تضمين مقطع صوتي، اختيار الصورة التي تمثله، ضبط التشغيل، وإرفاق الترجمات. يمكنك أيضًا استرداد الصوت المعيّن لانتقال الشريحة.

## **إنشاء إطارات صوتية**

استخدم [addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) لتضمين مقطع صوتي محلي على الشريحة الأولى. تحدد الإحداثيتان الأوليان موضع الإطار على الشريحة، وتحدد القيمتان التاليتان عرضه وارتفاعه، جميعها بالنقاط. يستدعي هذا المثال [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) لتشغيل المقطع تلقائيًا ويستدعي [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-) لاختيار إعداد الصوت العالي.

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

## **تغيير الصورة المصغرة لإطار الصوت**

بشكل افتراضي، يعرض إطار الصوت أيقونة مكبر صوت. لعرض صورة مصغرة مخصصة، أضف صورة إلى العرض التقديمي باستخدام [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-) ثم عيّنها على صورة الإطار باستخدام [setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-). يستخدم المثال ملف JPEG كصورة مصغرة لمقطع صوت مدمج.

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

## **تغيير خيارات تشغيل الصوت**

تحدد عناصر تحكم **Audio Options** في PowerPoint متى يبدأ المقطع، ومدى صوته، وكيفية سلوكه أثناء عرض الشرائح.

![عناصر تحكم خيارات الصوت في PowerPoint لإطار صوت](audio_frame_0.png)

| عنصر تحكم PowerPoint | طريقة Aspose.Slides for Android عبر Java |
| --- | --- |
| بدء | [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| إعداد حجم الصوت المسبق | [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-) |
| التشغيل عبر الشرائح | [setPlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| تكرار حتى إيقاف | [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| إخفاء أثناء العرض | [setHideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| إعادة إلى البداية بعد التشغيل | [setRewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| تلاشي الدخول | [setFadeInDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| تلاشي الخروج | [setFadeOutDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| قص وقت بدء الصوت | [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| قص وقت نهاية الصوت | [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| شريط حجم الصوت | [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

يجد المثال أول إطار صوت على الشريحة الأولى، يستدعي [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) لبدء التشغيل عند النقر، ويختار إعداد حجم الصوت المنخفض. يستمر المقطع عبر الشرائح مع تعطيل التكرار. تبقى الأيقونة مخفية أثناء العرض، ويتراجع المقطع بعد التشغيل.

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

لمقطع أطول من 3.5 ثوانٍ، يتخطى هذا المثال الثانية الأولى 1.5 وثانية الأخيرة 2. يأخذ [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) مدة الإزالة من نهاية المقطع. للحصول على وقت النهاية المعروض في PowerPoint، اطرح هذا الإزاحة من مدة المقطع الكاملة. يطمس المقطع المقصوص عند الدخول على مدى 200 مللي ثانية ويطمس عند الخروج على مدى 500 مللي ثانية. جميع الطرق الأربعة تقبل القيم بالمللي ثانية.

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

لتعيين حجم التشغيل إلى نسبة مئوية محددة، استخدم [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-). يضبط هذا المثال أول إطار صوت على الشريحة الأولى إلى 85٪.

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

## **إدارة ترجمات الصوت**

كل إطار صوت يوفر إمكانية الوصول إلى مسارات الترجمات الخاصة به عبر [getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--). استخدم المجموعة لإرفاق ترجمات WebVTT بالمقطع، أو تصدير المسارات الموجودة، أو إزالتها.

### **إضافة ترجمات صوتية**

يقوم المثال بتضمين مقطع صوتي على الشريحة الأولى ويستخدم [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-) لإرفاق مسار WebVTT محلي. المعامل الأول يزود بتسمية المسار، والثاني يحدد الملف الذي يحتوي على الترجمات الموقوتة.

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

### **استخراج ترجمات صوتية**

يصدر هذا المثال كل مسار ترجمة مرفق بإطار صوت على الشريحة الأولى. يكتب البايتات التي تعيدها [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getBinaryData--) إلى ملف WebVTT ويستخدم المعرف الذي تعيده [getCaptionId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getCaptionId--) كاسم للملف بحيث يكون لكل مسار إخراج منفصل.

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

### **إزالة ترجمات صوتية**

استخدم [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) أو [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) لحذف مسار فردي. يستخدم المثال [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#clear--) لإزالة جميع الترجمات من أول إطار صوت على الشريحة الأولى مع الحفاظ على المقطع.

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

### **البحث عن سطر في ترجمات الصوت**

للبحث عن سطر في ترجمات الصوت على الشريحة الأولى، ابحث في النص الذي تعيده [getDataAsString](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getDataAsString--) في الذاكرة. في إشعار WebVTT نصي عادي، يحتوي سطر التوقيت على `-->`، وتليها سطور الترجمات، ويختتم السطر الفارغ الإشعار. يطبع هذا المثال تسمية المسار وكل سطر ترجمة يحتوي على “café”.

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

## **استخراج الصوت**

يمكن أن يحتوي انتقال الشريحة على صوت خاص به. لاسترداده، استدعِ [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSound--) على انتقال الشريحة. يصل المثال إلى البايتات التي تعيدها [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--) ويطبع عدد البايتات. إذا لم يكن لدى الشريحة الأولى صوت انتقال، فإنه يطبع رسالة بدلاً من ذلك.

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

## **الأسئلة المتكررة**

**هل يمكنني إعادة استخدام نفس المقطع الصوتي عبر شرائح متعددة دون تكراره؟**

نعم. أضف المقطع مرة واحدة إلى [مجموعة الصوت](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) في العرض التقديمي، ومرّر كائن الصوت نفسه إلى [addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-) لكل شريحة.

**هل يمكنني استبدال الصوت في إطار صوت موجود؟**

نعم. بالنسبة لصوت مرتبط، استخدم [setLinkPathLong](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) للإشارة إلى ملف الاستبدال. بالنسبة لصوت مدمج، اختر مقطعًا آخر من مجموعة الصوت في العرض التقديمي باستخدام [setEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-). كلا النهجين يحافظان على الإطار الحالي.

**هل يغير القص بيانات الصوت المخزنة في العرض التقديمي؟**

لا. تقوم [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) و[setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) بتحديد حدود التشغيل. لا يزال بإمكانك استرداد المقطع الكامل عبر [getEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getEmbeddedAudio--).