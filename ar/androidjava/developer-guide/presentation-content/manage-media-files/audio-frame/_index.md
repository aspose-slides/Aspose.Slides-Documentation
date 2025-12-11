---
title: إدارة الصوت في العروض التقديمية على Android
linktitle: إطار الصوت
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
- استخراج صوت
- Android
- Java
- Aspose.Slides
description: "إنشاء والتحكم في إطارات الصوت في Aspose.Slides لنظام Android—أمثلة Java لتضمين الصوت، قصه، تشغيله على حلقة، وتكوين تشغيله عبر عروض PPT و PPTX و ODP."
---

## **إنشاء إطارات صوتية**
Aspose.Slides for Android via Java يسمح لك بإضافة ملفات صوتية إلى الشرائح. تُضمّن ملفات الصوت في الشرائح كإطارات صوتية.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر الفهرس الخاص بها.
3. تحميل تدفق ملف الصوت الذي تريد تضمينه في الشريحة.
4. إضافة إطار الصوت المضمّن (الذي يحتوي على ملف الصوت) إلى الشريحة.
5. ضبط [PlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioPlayModePreset) و`Volume` المعروضين بواسطة كائن [IAudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAudioFrame).
6. حفظ العرض التقديمي المعدّل.

هذا الكود Java يوضح كيفية إضافة إطار صوت مضمّن إلى شريحة:
```java
// ينشئ فئة Presentation التي تمثل ملف عرض تقديمي
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // يحمل ملف الصوت wav إلى تدفق
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // يضيف إطار الصوت
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // يحدد وضع التشغيل ومستوى الصوت للإطار الصوتي
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // يكتب ملف PowerPoint إلى القرص
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **تغيير الصورة المصغرة لإطار الصوت**

عند إضافة ملف صوت إلى عرض تقديمي، يظهر الصوت كإطار بصورة افتراضية قياسية (انظر الصورة في القسم أدناه). يمكنك تغيير الصورة المصغرة لإطار الصوت (تعيين الصورة التي تفضلها).

هذا الكود Java يوضح كيفية تغيير الصورة المصغرة أو صورة المعاينة لإطار الصوت:
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // يضيف إطار صوتي إلى الشريحة بموقع وحجم محددين.
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // يضيف صورة إلى موارد العرض التقديمي.
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // يضبط الصورة لإطار الصوت. // <-----
    // يحفظ العرض المعدل إلى القرص
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **تغيير خيارات تشغيل الصوت**

Aspose.Slides for Android via Java يسمح لك بتغيير الخيارات التي تتحكم في تشغيل الصوت أو خصائصه. على سبيل المثال، يمكنك تعديل مستوى صوت الصوت، ضبط تشغيل الصوت على حلقة، أو حتى إخفاء أيقونة الصوت.

لوحة **Audio Options** في Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

**Audio Options** في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame) هي:

- القائمة المنسدلة **Start** تتطابق مع خاصية [AudioFrame.PlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) 
- **Volume** تتطابق مع خاصية [AudioFrame.Volume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getVolume--) 
- **Play Across Slides** تتطابق مع خاصية [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) 
- **Loop until Stopped** تتطابق مع خاصية [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) 
- **Hide During Show** تتطابق مع خاصية [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) 
- **Rewind after Playing** تتطابق مع خاصية [AudioFrame.RewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) 

خيارات **Editing** في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/) هي:

- **Fade In** تتطابق مع خاصية [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) 
- **Fade Out** تتطابق مع خاصية [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) 
- **Trim Audio Start Time** تتطابق مع خاصية [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) 
- قيمة **Trim Audio End Time** تساوي مدة الصوت مطروحاً منها قيمة خاصية [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) 

متحكم **Volume** في لوحة التحكم الصوتية في PowerPoint يتطابق مع خاصية [AudioFrame.VolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getVolumeValue--)، ويتيح لك تعديل مستوى الصوت كنسبة مئوية.

إليك كيفية تغيير خيارات تشغيل الصوت:

1. [Create](#create-audio-frame) أو الحصول على إطار الصوت.
2. ضبط القيم الجديدة لخصائص إطار الصوت التي تريد تعديلها.
3. حفظ ملف PowerPoint المعدّل.

هذا الكود Java يوضح عملية تعديل خيارات الصوت:
```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // يحصل على شكل AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // يحدد وضع التشغيل لتشغيله عند النقر
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // يحدد مستوى الصوت إلى منخفض
    audioFrame.setVolume(AudioVolumeMode.Low);

    // يحدد تشغيل الصوت عبر الشرائح
    audioFrame.setPlayAcrossSlides(true);

    // يعطل التكرار للصوت
    audioFrame.setPlayLoopMode(false);

    // يخفى إطار الصوت أثناء عرض الشرائح
    audioFrame.setHideAtShowing(true);

    // يعيد الصوت إلى البداية بعد التشغيل
    audioFrame.setRewindAudio(true);

    // يحفظ ملف PowerPoint إلى القرص
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


هذا المثال Java يوضح كيفية إضافة إطار صوت جديد مع صوت مضمّن، قصه، وتعيين مدة التلاشي:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // يحدد إزاحة بداية القص إلى 1.5 ثانية
    // يحدد إزاحة نهاية القص إلى 2 ثانية

    // يحدد مدة الفيد إن إلى 200 مللي ثانية
    // يحدد مدة الفيد آوت إلى 500 مللي ثانية

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


العينة البرمجية التالية توضح كيفية استرجاع إطار صوت مضمّن وتعيين مستوى صوته إلى 85%:
```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // يحصل على شكل إطار صوتي
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // يضبط مستوى الصوت إلى 85%
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```


## **استخراج الصوت**

Aspose.Slides for Android via Java يسمح لك باستخراج الصوت المستخدم في انتقالات عرض الشرائح. على سبيل المثال، يمكنك استخراج الصوت المستخدم في شريحة معينة.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) وتحميل العرض التقديمي الذي يحتوي على الصوت.
2. الحصول على مرجع الشريحة ذات الصلة عبر فهرسها.
3. الوصول إلى [slideshow transitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) للشريحة.
4. استخراج الصوت كبيانات بايت.

هذا الكود Java يوضح كيفية استخراج الصوت المستخدم في شريحة:
```java
// ينشئ كائن من فئة Presentation التي تمثل ملف عرض تقديمي
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // يصل إلى الشريحة المطلوبة
    ISlide slide = pres.getSlides().get_Item(0);
    
    // يحصل على تأثيرات انتقال العرض التقديمي للشريحة
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //يستخرج الصوت في مصفوفة بايت
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**هل يمكنني إعادة استخدام نفس ملف الصوت عبر شرائح متعددة دون زيادة حجم الملف؟**

نعم. أضف الصوت مرة واحدة إلى مجموعة الصوت المشتركة في العرض التقديمي ثم أنشئ أطر صوت إضافية تشير إلى هذا الأصل الموجود. هذا يجنّب تكرار بيانات الوسائط ويحافظ على حجم العرض تحت السيطرة.

**هل يمكنني استبدال الصوت في إطار صوت موجود دون إعادة إنشاء الشكل؟**

نعم. بالنسبة للصوت المرتبط، حدّث [link path](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) ليشير إلى الملف الجديد. بالنسبة للصوت المضمن، استبدل كائن [embedded audio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) بآخر من مجموعة الصوت في العرض التقديمي. يظل تنسيق الإطار ومعظم إعدادات التشغيل كما هو.

**هل يغيّر القص البيانات الصوتية الأساسية المخزنة في العرض التقديمي؟**

لا. يضبط القص حدود التشغيل فقط. تبقى بايتات الصوت الأصلية دون تعديل ويمكن الوصول إليها من خلال الصوت المضمن أو مجموعة الصوت في العرض التقديمي.