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
- أندرويد
- جافا
- Aspose.Slides
description: "إنشاء والتحكم في إطارات الصوت في Aspose.Slides لنظام Android—أمثلة Java لتضمين، تقليم، تشغيل متكرر، وتكوين التشغيل عبر عروض PPT وPPTX وODP."
---

## **إنشاء إطارات صوتية**
Aspose.Slides for Android via Java يسمح لك بإضافة ملفات صوتية إلى الشرائح. يتم تضمين ملفات الصوت في الشرائح كإطارات صوتية.

1. إنشاء كائن من فئة [العرض التقديمي](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرسها.
3. تحميل تدفق ملف الصوت الذي تريد تضمينه في الشريحة.
4. إضافة إطار الصوت المضمن (الذي يحتوي على ملف الصوت) إلى الشريحة.
5. تعيين [وضع التشغيل](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioPlayModePreset) و`Volume` المعروضين بواسطة كائن [IAudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAudioFrame).
6. حفظ العرض التقديمي المعدل.

يظهر لك هذا الكود Java كيفية إضافة إطار صوت مضمّن إلى شريحة:
```java
// ينشئ كائن من فئة Presentation التي تمثل ملف العرض التقديمي
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // يحمّل ملف الصوت wav إلى تيار
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // يضيف إطار الصوت
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // يضبط وضع التشغيل ومستوى الصوت للإطار الصوتي
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // يكتب ملف PowerPoint إلى القرص
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **تغيير صورة مصغرة لإطار الصوت**

عند إضافة ملف صوتي إلى عرض تقديمي، يظهر الصوت كإطار بصورة افتراضية قياسية (انظر الصورة في القسم أدناه). يمكنك تغيير صورة المعاينة لإطار الصوت (تعيين الصورة المفضلة لديك).

يظهر لك هذا الكود Java كيفية تغيير الصورة المصغرة أو صورة المعاينة لإطار الصوت:
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // يضيف إطار صوت إلى الشريحة بموقع وحجم محددين.
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

    // يضبط الصورة لإطار الصوت.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //يحفظ العرض التقديمي المعدل إلى القرص
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **تغيير خيارات تشغيل الصوت**

Aspose.Slides for Android via Java يسمح لك بتغيير الخيارات التي تتحكم في تشغيل الصوت أو خصائصه. على سبيل المثال، يمكنك تعديل مستوى صوت الصوت، أو ضبط تشغيل الصوت بشكل متكرر، أو حتى إخفاء أيقونة الصوت.

لوحة **خيارات الصوت** في Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

خيارات **الصوت** في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame):

- قائمة **Start** المنسدلة تتطابق مع خاصية [AudioFrame.PlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) 
- **Volume** يتطابق مع خاصية [AudioFrame.Volume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getVolume--) 
- **Play Across Slides** يتطابق مع خاصية [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) 
- **Loop until Stopped** يتطابق مع خاصية [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) 
- **Hide During Show** يتطابق مع خاصية [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) 
- **Rewind after Playing** يتطابق مع خاصية [AudioFrame.RewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) 

خيارات **التحرير** في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/):

- **Fade In** يتطابق مع خاصية [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) 
- **Fade Out** يتطابق مع خاصية [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) 
- **Trim Audio Start Time** يتطابق مع خاصية [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) 
- **Trim Audio End Time** يساوي مدة الصوت ناقص قيمة خاصية [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) 

متحكم **حجم الصوت** في لوحة التحكم الخاصة بالصوت في PowerPoint يتطابق مع خاصية [AudioFrame.VolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getVolumeValue--) . يسمح لك بتغيير مستوى الصوت كنسبة مئوية.

هذا هو كيفية تغيير خيارات تشغيل الصوت:

1. [إنشاء](#create-audio-frame) أو الحصول على إطار الصوت.
2. تعيين قيم جديدة لخصائص إطار الصوت التي تريد تعديلها.
3. حفظ ملف PowerPoint المعدل.

يظهر لك هذا الكود Java مثالاً على تعديل خيارات الصوت:
```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // يحصل على شكل AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // يضبط وضع التشغيل للتشغيل عند النقر
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // يضبط مستوى الصوت إلى منخفض
    audioFrame.setVolume(AudioVolumeMode.Low);

    // يضبط تشغيل الصوت عبر الشرائح
    audioFrame.setPlayAcrossSlides(true);

    // يعطل التكرار للصوت
    audioFrame.setPlayLoopMode(false);

    // يخفي AudioFrame أثناء عرض الشرائح
    audioFrame.setHideAtShowing(true);

    // يعيد تشغيل الصوت من البداية بعد الانتهاء
    audioFrame.setRewindAudio(true);

    // يحفظ ملف PowerPoint إلى القرص
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


يوضح هذا المثال Java كيفية إضافة إطار صوت جديد مع صوت مضمّن، تقصيره، وتعيين مدتي التلاشي:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // يضبط إزاحة بدء القطع إلى 1.5 ثانية
    audioFrame.setTrimFromStart(1500f);
    // يضبط إزاحة نهاية القطع إلى ثانيتين
    audioFrame.setTrimFromEnd(2000f);

    // يضبط مدة التلاشي التدريجي إلى 200 مللي ثانية
    audioFrame.setFadeInDuration(200f);
    // يضبط مدة الانخفاض التدريجي إلى 500 مللي ثانية
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


يظهر لك عينة الكود التالية كيفية استرجاع إطار صوت مضمّن وتعيين حجم الصوت إلى 85٪:
```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // يحصل على شكل إطار صوت
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

Aspose.Slides for Android via Java يسمح لك باستخراج الصوت المستخدم في انتقالات عرض الشرائح. على سبيل المثال، يمكنك استخراج الصوت المستخدم في شريحة محددة.

1. إنشاء كائن من فئة [العرض التقديمي](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) وتحميل العرض الذي يحتوي على الصوت.
2. الحصول على مرجع الشريحة المعنية عبر فهرسها.
3. الوصول إلى [انتقالات عرض الشرائح](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) للشريحة.
4. استخراج الصوت كبيانات بايت.

يبين لك هذا الكود Java كيفية استخراج الصوت المستخدم في شريحة:
```java
// ينشئ كائنًا من فئة Presentation التي تمثل ملف عرض تقديمي
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // يصل إلى الشريحة المطلوبة
    ISlide slide = pres.getSlides().get_Item(0);
    
    // يحصل على تأثيرات انتقال عرض الشرائح للشريحة
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //يستخرج الصوت في مصفوفة بايت
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**هل يمكنني إعادة استخدام نفس ملف الصوت عبر عدة شرائح دون زيادة حجم الملف؟**

نعم. أضف الصوت مرة واحدة إلى [مجموعة الصوت المشتركة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) في العرض، ثم أنشئ إطارات صوت إضافية تشير إلى ذلك الأصل الموجود. هذا يمنع تكرار بيانات الوسائط ويحافظ على حجم العرض تحت السيطرة.

**هل يمكنني استبدال الصوت في إطار صوت موجود دون إعادة إنشاء الشكل؟**

نعم. بالنسبة لصوت مرتبط، حدّث [مسار الرابط](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) للإشارة إلى الملف الجديد. بالنسبة لصوت مضمّن، استبدل كائن [audio embedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) بآخر من [مجموعة الصوت](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) في العرض. يظل تنسيق الإطار ومعظم إعدادات التشغيل كما هي.

**هل يغيّر القص البيانات الصوتية الأساسية المخزنة في العرض؟**

لا. يضبط القص حدود التشغيل فقط. تظل بايتات الصوت الأصلية دون تعديل ويمكن الوصول إليها عبر الصوت المضمّن أو مجموعة الصوت في العرض.