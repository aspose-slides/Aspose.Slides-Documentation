---
title: إدارة إطارات الصوت في العروض باستخدام Java
linktitle: إطار الصوت
type: docs
weight: 10
url: /ar/java/audio-frame/
keywords:
- صوت
- إطار صوت
- صورة مصغرة
- إضافة صوت
- خصائص الصوت
- خيارات الصوت
- استخراج صوت
- Java
- Aspose.Slides
description: "إدراج صوت في الشرائح، تغيير أيقونة الصوت، تكوين التشغيل، إدارة ترجمات WebVTT، واستخراج أصوات انتقال الشرائح باستخدام Aspose.Slides for Java."
---
## **نظرة عامة**

إطار صوتي يتيح لك تشغيل صوت على شريحة. باستخدام Aspose.Slides for Java، يمكنك دمج مقطع صوتي، اختيار الصورة التي تمثله، ضبط طريقة التشغيل، وإرفاق ترجمات. يمكنك أيضًا استرداد صوت مخصص لانتقال شريحة.

## **إنشاء إطارات صوتية**

استخدم [addAudioFrameEmbedded](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) لإدراج مقطع صوتي محلي على الشريحة الأولى. تُحدِّد الإحداثيتان الأوليتان موضع الإطار على الشريحة، وتحدد القيمتان التاليتان عرضه وارتفاعه، كلها بنقاط. يوضح هذا المثال استدعاء [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) لتشغيل المقطع تلقائيًا ويستدعي [setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolume-int-) لاختيار إعداد الصوت العالي.

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

## **تغيير صورة إطار الصوت**

بشكل افتراضي، يعرض إطار الصوت أيقونة مكبر صوت. لعرض صورة مصغرة مخصصة، أضف صورة إلى العرض التقديمي باستخدام [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-) واضبطها على صورة الإطار باستخدام [setImage](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-). يستخدم المثال ملف JPEG كالصورة المصغرة لمقطع صوت مدمج.

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

تتحكم **خيارات الصوت** في PowerPoint في متى يبدأ المقطع، مستوى صوته، وسلوكه أثناء العرض التقديمي.

![عناصر التحكم في خيارات الصوت في PowerPoint لإطار صوتي](audio_frame_0.png)

| عنصر تحكم PowerPoint | طريقة Aspose.Slides for Java |
| --- | --- |
| بدء | [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| إعداد حجم الصوت | [setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolume-int-) |
| التشغيل عبر الشرائح | [setPlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| التكرار حتى الإيقاف | [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| إخفاء أثناء العرض | [setHideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| إعادة تنفيذ بعد التشغيل | [setRewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| تلاشي الدخول | [setFadeInDuration](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| تلاشي الخروج | [setFadeOutDuration](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| قص وقت بدء الصوت | [setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| قص وقت انتهاء الصوت | [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| شريط ضبط الصوت | [setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

يجد المثال أول إطار صوتي في الشريحة الأولى، ويستدعي [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) لبدء التشغيل عند النقر، ويختار إعداد حجم الصوت المنخفض. يستمر المقطع عبر الشرائح مع تعطيل التكرار. يبقى الأيقونة مخفيًا أثناء العرض، ويُعيد المقطع تشغيله بعد الانتهاء.

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

لمقاطع أطول من 3.5 ثانية، يتخطى هذا المثال أول 1.5 ثانية وآخر 2 ثانية. يأخذ [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) المدة التي يجب إلغاؤها من نهاية المقطع. للحصول على وقت النهاية المعروض في PowerPoint، اطرح هذا الفرق من المدة الكاملة للمقطع. يَتَلاشى المقطع المُقَصَّ أولاً خلال 200 مللي ثانية ثم يَتَلاشى خارجه خلال 500 مللي ثانية. جميع الطرق الأربعة تقبل القيم بالمللي ثانية.

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

لتعيين حجم التشغيل بنسبة مئوية محددة، استخدم [setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolumeValue-float-). يضبط هذا المثال أول إطار صوتي في الشريحة الأولى على 85٪.

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

كل إطار صوتي يوفر وصولًا إلى مسارات الترجمة الخاصة به عبر [getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#getCaptionTracks--). استخدم المجموعة لإرفاق ترجمات WebVTT بالمقطع، أو تصدير المسارات الموجودة، أو إزالتها.

### **إضافة ترجمات صوتية**

يُدرج المثال مقطع صوتي على الشريحة الأولى ويستدعي [add](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-) لإرفاق مسار WebVTT محلي. يزود الوسيط الأول تسمية المسار، والوسيط الثاني يحدد الملف الذي يحتوي على الترجمات الزمنية.

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

يصدّر هذا المثال كل مسار ترجمة مرفق بإطار صوتي في الشريحة الأولى. يكتب البايتات التي تُعيدها [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getBinaryData--) إلى ملف WebVTT ويستخدم المعرف الذي تُعيده [getCaptionId](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getCaptionId--) كاسم للملف بحيث يكون لكل مسار مخرج منفصل.

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

### **إزالة ترجمات صوتية**

استخدم [remove](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) أو [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#removeAt-int-) لحذف مسار فردي. يستخدم المثال [clear](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#clear--) لإزالة جميع الترجمات من أول إطار صوتي في الشريحة الأولى مع الحفاظ على المقطع.

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

### **العثور على سطر في ترجمات الصوت**

للعثور على سطر في ترجمات الصوت في الشريحة الأولى، ابحث في النص الذي تُعيده [getDataAsString](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getDataAsString--) بالذاكرة. في إشارة WebVTT نصية عادية، يحتوي سطر التوقيت على `-->`، وتتبعه أسطر الترجمات، وتُنهي إشارة فارغة الإطار. يطبع هذا المثال تسمية المسار وكل سطر ترجمة يحتوي على كلمة “café”.

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

## **استخراج الصوت**

يمكن لانتقال الشريحة أن يحتوي على صوته الخاص. لاسترداده، استدعِ [getSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSound--) على انتقال الشريحة. يصل المثال إلى البايتات التي تُعيدها [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/iaudio/#getBinaryData--) ويطبع عدد البايتات. إذا لم يكن للشرائح الأولى صوت انتقال، يطبع رسالة بدلاً من ذلك.

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

**هل يمكنني إعادة استخدام نفس مقطع الصوت عبر شرائح متعددة دون تكراره؟**

نعم. أضف المقطع مرة واحدة إلى [audio collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) الخاصة بالعرض التقديمي، ثم مرر كائن الصوت نفسه إلى [addAudioFrameEmbedded](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-) لكل شريحة.

**هل يمكنني استبدال الصوت في إطار صوتي موجود؟**

نعم. بالنسبة لصوت مرتبط، استخدم [setLinkPathLong](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) لتوجيهه إلى ملف الاستبدال. بالنسبة لصوت مدمج، اختر مقطعًا آخر من مجموعة أصوات العرض باستخدام [setEmbeddedAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-). كلا النهجين يحافظان على الإطار الحالي.

**هل يؤدي القص إلى تغيير بيانات الصوت المخزنة في العرض التقديمي؟**

لا. يحدد كل من [setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) و[setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) حدود التشغيل. لا يزال بإمكانك استرداد المقطع الكامل عبر [getEmbeddedAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#getEmbeddedAudio--).