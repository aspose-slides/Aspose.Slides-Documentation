---
title: إدارة الصوت في العروض التقديمية باستخدام Java
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
description: "إنشاء والتحكم في إطارات الصوت في Aspose.Slides for Java — أمثلة برمجية لتضمين، قص، تكرار، وتكوين تشغيل عبر عروض PPT و PPTX و ODP."
---

## **إنشاء إطارات صوتية**

Aspose.Slides for Java يسمح لك بإضافة ملفات صوتية إلى الشرائح. يتم تضمين ملفات الصوت في الشرائح كإطارات صوتية. 

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرستها.
3. تحميل تدفق ملف الصوت الذي تريد تضمينه في الشريحة.
4. إضافة إطار الصوت المضمن (الذي يحتوي على ملف الصوت) إلى الشريحة.
5. تعيين [PlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioPlayModePreset) و`Volume` المعروضين بواسطة كائن [IAudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAudioFrame).
6. حفظ العرض التقديمي المعدل.

يعرض لك هذا الكود بلغة Java كيفية إضافة إطار صوت مضمّن إلى شريحة:
```java
// ينشئ كائن من فئة Presentation تمثل ملف عرض تقديمي
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


## **تغيير صورة إطار الصوت المصغرة**

عند إضافة ملف صوت إلى عرض تقديمي، يظهر الصوت كإطار يحتوي على صورة افتراضية قياسية (انظر الصورة في القسم أدناه). يمكنك تغيير صورة المعاينة لإطار الصوت (ضع الصورة التي تفضلها).

يعرض لك هذا الكود بلغة Java كيفية تغيير صورة مصغرة أو صورة المعاينة لإطار الصوت:
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

    // Sets the image for the audio frame.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //يحفظ العرض التقديمي المعدل إلى القرص
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **تغيير خيارات تشغيل الصوت**

تتيح لك Aspose.Slides for Java تغيير الخيارات التي تتحكم في تشغيل الصوت أو خصائصه. على سبيل المثال، يمكنك ضبط مستوى صوت الصوت، أو ضبط تشغيل الصوت بشكل متكرر، أو حتى إخفاء أيقونة الصوت.

اللوحة **Audio Options** في Microsoft PowerPoint:
![example1_image](audio_frame_0.png)

خيارات **Audio Options** في PowerPoint التي تتوافق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame) :

- **Start** القائمة المنسدلة تتطابق مع طريقة [AudioFrame.setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayMode-int-).
- **Volume** يتطابق مع طريقة [AudioFrame.setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setVolume-int-).
- **Play Across Slides** يتطابق مع طريقة [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-).
- **Loop until Stopped** يتطابق مع طريقة [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-).
- **Hide During Show** يتطابق مع طريقة [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-).
- **Rewind after Playing** يتطابق مع طريقة [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-).

خيارات **Editing** في PowerPoint التي تتوافق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame) :

- **Fade In** يتطابق مع طريقة [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setFadeInDuration-float-).
- **Fade Out** يتطابق مع طريقة [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-).
- **Trim Audio Start Time** يتطابق مع طريقة [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setTrimFromStart-float-).
- **Trim Audio End Time** القيمة تساوي مدة الصوت ناقص قيمة طريقة [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-).

يتوافق **Volume controll** في PowerPoint على لوحة التحكم بالصوت مع طريقة [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setVolumeValue-float-). يسمح لك بتغيير مستوى الصوت كنسبة مئوية.

هذه هي الطريقة التي تغير بها خيارات تشغيل الصوت:

1. [إنشاء](#create-audio-frame) أو الحصول على إطار الصوت.
2. تعيين قيم جديدة لخصائص إطار الصوت التي تريد تعديلها.
3. حفظ ملف PowerPoint المعدل.

هذا الكود بلغة Java يوضح عملية تعديل خيارات الصوت:
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

    // يعيد الصوت إلى البداية بعد التشغيل
    audioFrame.setRewindAudio(true);

    // يحفظ ملف PowerPoint إلى القرص
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


هذا المثال بلغة Java يوضح كيفية إضافة إطار صوت جديد مع صوت مضمّن، قصه، وتعيين مدد التلاشي:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // يضبط إزاحة القطع في البداية إلى 1.5 ثانية
    // يضبط إزاحة القطع في النهاية إلى 2 ثانية
    // يضبط مدة التلاشي التدريجي إلى 200 مللي ثانية
    // يضبط مدة التلاشي التنازلي إلى 500 مللي ثانية

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


العينة البرمجية التالية توضح كيفية استرجاع إطار صوت مضمّن وتعيين حجمه إلى 85٪:
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

تتيح لك Aspose.Slides for Java استخراج الصوت المستخدم في انتقالات عرض الشرائح. على سبيل المثال، يمكنك استخراج الصوت المستخدم في شريحة معينة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) وتحميل العرض التقديمي الذي يحتوي على الصوت.
2. الحصول على مرجع الشريحة ذات الصلة عبر فهرستها.
3. الوصول إلى [slideshow transitions](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) للشريحة.
4. استخراج الصوت في بيانات بايت.

هذا الكود بلغة Java يظهر لك كيفية استخراج الصوت المستخدم في شريحة:
```java
// ينشئ كائنًا من فئة Presentation تمثل ملف عرض تقديمي
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // الوصول إلى الشريحة المطلوبة
    ISlide slide = pres.getSlides().get_Item(0);
    
    // يحصل على تأثيرات انتقال عرض الشرائح للشريحة
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    // يستخرج الصوت في مصفوفة بايت
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**هل يمكنني إعادة استخدام نفس ملف الصوت عبر عدة شرائح دون زيادة حجم الملف؟**

نعم. أضف الصوت مرة واحدة إلى [audio collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) المشتركة في العرض التقديمي وأنشئ إطارات صوتية إضافية تشير إلى هذا الأصل الموجود. هذا يمنع تكرار بيانات الوسائط ويحافظ على حجم العرض التقديمي تحت السيطرة.

**هل يمكنني استبدال الصوت في إطار صوت موجود دون إعادة إنشاء الشكل؟**

نعم. بالنسبة لصوت مرتبط، قم بتحديث [link path](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) للإشارة إلى الملف الجديد. بالنسبة لصوت مضمّن، استبدل كائن [embedded audio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) بآخر من [audio collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) الخاصة بالعرض التقديمي. يظل تنسيق الإطار ومعظم إعدادات التشغيل كما هي.

**هل يؤدي القص إلى تغيير بيانات الصوت الأساسية المخزنة في العرض التقديمي؟**

لا. القص يضبط فقط حدود التشغيل. تبقى بايتات الصوت الأصلية دون تعديل ويمكن الوصول إليها عبر الصوت المضمّن أو مجموعة الصوت الخاصة بالعرض التقديمي.