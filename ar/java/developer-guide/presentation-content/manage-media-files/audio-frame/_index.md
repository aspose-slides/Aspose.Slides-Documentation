---
title: إطار الصوت
type: docs
weight: 10
url: /ar/java/audio-frame/
keywords: "إضافة صوت, إطار الصوت, خصائص الصوت, استخراج الصوت, جافا, Aspose.Slides لجافا"
description: "إضافة صوت إلى عرض PowerPoint في جافا"
---

## **إنشاء إطار الصوت**
تتيح لك Aspose.Slides لجافا إضافة ملفات الصوت إلى الشرائح. يتم تضمين ملفات الصوت في الشرائح كإطارات صوتية.

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة من خلال فهرسها.
3. قم بتحميل تدفق ملف الصوت الذي تريد تضمينه في الشريحة.
4. أضف إطار الصوت المضمن (الذي يحتوي على ملف الصوت) إلى الشريحة.
5. قم بضبط [PlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioPlayModePreset) و `Volume` المعروضان بواسطة كائن [IAudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAudioFrame).
6. احفظ العرض التقديمي المعدل.

يعرض لك هذا الرمز البرمجي في جافا كيفية إضافة إطار صوت مضمن إلى شريحة:

```Java
// ينشئ فئة Presentation التي تمثل ملف العرض التقديمي
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // يقوم بتحميل ملف الصوت wav إلى الدفق
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // يضيف إطار الصوت
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // يضبط وضع التشغيل وحجم الصوت
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

عند إضافة ملف صوتي إلى عرض تقديمي، يظهر الصوت كإطار بصورة افتراضية قياسية (انظر الصورة في القسم أدناه). يمكنك تغيير صورة المعاينة لإطار الصوت (تعيين صورتك المفضلة).

يعرض لك هذا الرمز البرمجي في جافا كيفية تغيير صورة مصغرة لإطار الصوت:

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

    // يحفظ العرض التقديمي المعدل إلى القرص
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **تغيير خيارات تشغيل الصوت**

تتيح لك Aspose.Slides لجافا تغيير الخيارات التي تتحكم في تشغيل الصوت أو خصائصه. على سبيل المثال، يمكنك ضبط حجم الصوت، أو تعيين الصوت ليعمل في حلقة، أو حتى إخفاء أيقونة الصوت.

نافذة **خيارات الصوت** في Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

خيارات الصوت في PowerPoint التي تتوافق مع خصائص [AudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame) لـ Aspose.Slides:
- قائمة منسدلة خيارات الصوت **ابدأ** تطابق خاصية [AudioFrame.PlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getPlayMode--)
- خيارات الصوت **حجم الصوت** تطابق خاصية [AudioFrame.Volume](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getVolume--)
- خيارات الصوت **تشغيل عبر الشرائح** تطابق خاصية [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getPlayAcrossSlides--)
- خيارات الصوت **التكرار حتى الإيقاف** تطابق خاصية [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getPlayLoopMode--)
- خيارات الصوت **إخفاء أثناء العرض** تطابق خاصية [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getHideAtShowing--)
- خيارات الصوت **الإرجاع بعد التشغيل** تطابق خاصية [AudioFrame.RewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getRewindAudio--)

هذه هي الطريقة التي يمكنك بها تغيير خيارات تشغيل الصوت:

1. [أنشئ](#create-audio-frame) أو احصل على إطار الصوت.
2. قم بضبط قيم جديدة لخصائص إطار الصوت التي تريد تعديلها.
3. احفظ ملف PowerPoint المعدل.

يعرض الكود البرمجي في جافا عملية يتم فيها ضبط خيارات الصوت:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // يحصل على شكل AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // يضبط وضع التشغيل على التشغيل عند النقر
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // يضبط الحجم على منخفض
    audioFrame.setVolume(AudioVolumeMode.Low);

    // يضبط الصوت ليعمل عبر الشرائح
    audioFrame.setPlayAcrossSlides(true);

    // يعطل الحلقة للصوت
    audioFrame.setPlayLoopMode(false);

    // يخفي AudioFrame أثناء عرض الشريحة
    audioFrame.setHideAtShowing(true);

    // يعيد الصوت إلى البداية بعد التشغيل
    audioFrame.setRewindAudio(true);

    // يحفظ ملف PowerPoint إلى القرص
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **استخراج الصوت**

تتيح لك Aspose.Slides لجافا استخراج الصوت المستخدم في انتقالات العرض التقديمي. على سبيل المثال، يمكنك استخراج الصوت المستخدم في شريحة معينة.

1. أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) وقم بتحميل العرض التقديمي مع انتقالات الشرائح.
2. الوصول إلى الشريحة المطلوبة.
3. الوصول إلى [انتقالات العرض التقديمي](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) للشريحة.
4. استخراج الصوت في بيانات بايت.

يعرض هذا الرمز في جافا كيفية استخراج الصوت المستخدم في شريحة:

```java
// ينشئ فئة Presentation التي تمثل ملف العرض التقديمي
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // يصل إلى الشريحة المطلوبة
    ISlide slide = pres.getSlides().get_Item(0);
    
    // يحصل على تأثيرات انتقال العرض التقديمي للشريحة
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //يستخرج الصوت في مصفوفة بايت
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("الطول: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```