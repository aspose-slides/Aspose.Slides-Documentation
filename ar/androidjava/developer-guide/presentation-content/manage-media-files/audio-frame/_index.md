---
title: إطار الصوت
type: docs
weight: 10
url: /androidjava/audio-frame/
keywords: "إضافة صوت, إطار صوت, خصائص الصوت, استخراج الصوت, جافا, Aspose.Slides لـ Android عبر جافا"
description: "إضافة صوت إلى عرض PowerPoint التقديمي في جافا"
---

## **إنشاء إطار صوت**
Aspose.Slides لـ Android عبر جافا يتيح لك إضافة ملفات صوتية إلى الشرائح. يتم تضمين ملفات الصوت في الشرائح كإطارات صوتية.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة من خلال فهرسها.
3. تحميل دفق ملف الصوت الذي تريد تضمينه في الشريحة.
4. أضف إطار الصوت المضمن (الذي يحتوي على ملف الصوت) إلى الشريحة.
5. تعيين [PlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioPlayModePreset) و`Volume` المنكشف من قبل كائن [IAudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAudioFrame).
6. حفظ العرض التقديمي المعدل.

هذا الرمز في جافا يوضح لك كيفية إضافة إطار صوت مضمن إلى شريحة:

```Java
// ينشئ فئة Presentation تمثل ملف عرض تقديمي
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // يحمل ملف الصوت wav إلى الدفق
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // يضيف إطار الصوت
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // يحدد وضع التشغيل ومستوى الصوت للصوت
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // يكتب ملف PowerPoint على القرص
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **تغيير صورة مصغرة لإطار الصوت**

عند إضافة ملف صوتي إلى عرض تقديمي، يظهر الصوت كإطار بصورة افتراضية قياسية (انظر الصورة في القسم أدناه). يمكنك تغيير صورة المعاينة لإطار الصوت (تعيين الصورة المفضلة لديك).

هذا الرمز في جافا يوضح لك كيفية تغيير صورة مصغرة لإطار الصوت أو صورة المعاينة:

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

    // يحدد الصورة لإطار الصوت.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    // يحفظ العرض التقديمي المعدل على القرص
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **تغيير خيارات تشغيل الصوت**

Aspose.Slides لـ Android عبر جافا يتيح لك تغيير الخيارات التي تتحكم في تشغيل الصوت أو خصائصه. على سبيل المثال، يمكنك ضبط مستوى الصوت للصوت، تعيين الصوت للتشغيل في حلقة، أو حتى إخفاء أيقونة الصوت.

لوحة **خيارات الصوت** في Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

خيارات الصوت في PowerPoint التي تتوافق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame):
- قائمة خيارات الصوت **بدء** المنسدلة تتوافق مع خاصية [AudioFrame.PlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) 
- خيارات الصوت **مستوى الصوت** تتوافق مع خاصية [AudioFrame.Volume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getVolume--) 
- خيارات الصوت **تشغيل عبر الشرائح** تتوافق مع خاصية [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) 
- خيارات الصوت **التكرار حتى الإيقاف** تتوافق مع خاصية [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) 
- خيارات الصوت **إخفاء أثناء العرض** تتوافق مع خاصية [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) 
- خيارات الصوت **التراجع بعد التشغيل** تتوافق مع خاصية [AudioFrame.RewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) 

هذه هي كيفية تغيير خيارات تشغيل الصوت:

1. [إنشاء](#create-audio-frame) أو الحصول على إطار الصوت.
2. تعيين قيم جديدة لخصائص إطار الصوت التي تريد ضبطها.
3. حفظ ملف PowerPoint المعدل.

هذا الرمز في جافا يوضح عملية يتم فيها ضبط خيارات الصوت:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // يحصل على شكل AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // يحدد وضع التشغيل ليكون عند النقر
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // يحدد مستوى الصوت ليكون منخفض
    audioFrame.setVolume(AudioVolumeMode.Low);

    // يحدد الصوت للتشغيل عبر الشرائح
    audioFrame.setPlayAcrossSlides(true);

    // يعطل التكرار للصوت
    audioFrame.setPlayLoopMode(false);

    // يخفي إطار الصوت أثناء عرض الشريحة
    audioFrame.setHideAtShowing(true);

    // يعيد الصوت إلى البداية بعد التشغيل
    audioFrame.setRewindAudio(true);

    // يحفظ ملف PowerPoint على القرص
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **استخراج الصوت**

Aspose.Slides لـ Android عبر جافا يتيح لك استخراج الصوت المستخدم في انتقالات عرض الشرائح. على سبيل المثال، يمكنك استخراج الصوت المستخدم في شريحة معينة.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) وحميل العرض التقديمي مع انتقالات الشرائح.
2. الوصول إلى الشريحة المطلوبة.
3. الوصول إلى [انتقالات عرض الشرائح](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) للشريحة.
4. استخراج الصوت في بيانات بايت.

هذا الرمز في جافا يوضح لك كيفية استخراج الصوت المستخدم في شريحة:

```java
// ينشئ فئة Presentation تمثل ملف عرض تقديمي
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // يصل إلى الشريحة المطلوبة
    ISlide slide = pres.getSlides().get_Item(0);
    
    // يحصل على تأثيرات انتقال عرض الشرائح للشريحة
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //يستخرج الصوت في مصفوفة بايت
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("الطول: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```