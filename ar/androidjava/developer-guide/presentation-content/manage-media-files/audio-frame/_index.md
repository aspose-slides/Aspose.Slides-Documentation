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
- استخراج الصوت
- Android
- Java
- Aspose.Slides
description: "إنشاء والتحكم في إطارات الصوت في Aspose.Slides for Android — أمثلة Java لتضمين الصوت، تقصيره، تشغيله بشكل متكرر، وتكوين التشغيل عبر عروض PPT و PPTX و ODP."
---
## **إنشاء إطارات الصوت**
Aspose.Slides for Android via Java يتيح لك إضافة ملفات صوتية إلى الشرائح. تُدمج ملفات الصوت في الشرائح كإطارات صوتية.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation) .
2. الحصول على مرجع الشريحة عبر فهرستها.
3. تحميل تدفق ملف الصوت الذي تريد دمجه في الشريحة.
4. إضافة إطار الصوت المدمج (الذي يحتوي على ملف الصوت) إلى الشريحة.
5. تعيين [PlayMode](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/AudioPlayModePreset) و`Volume` المعروضة بواسطة كائن [IAudioFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IAudioFrame) .
6. حفظ العرض التقديمي المعدل.

```java
// ينشئ كائنًا من فئة Presentation تمثل ملف عرض تقديمي
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // يقوم بتحميل ملف الصوت wav إلى تدفق
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // يضيف إطار الصوت
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // يضبط وضع التشغيل ومستوى الصوت للملف الصوتي
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

عند إضافة ملف صوتي إلى عرض تقديمي، يظهر الصوت كإطار بصورة افتراضية قياسية (انظر الصورة في القسم أدناه). يمكنك تغيير صورة المعاينة لإطار الصوت (تعيين الصورة المفضلة لديك).

هذا الكود بلغة Java يوضح كيفية تغيير الصورة المصغرة أو صورة المعاينة لإطار الصوت:

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

    // يعيّن الصورة لإطار الصوت.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //يحفظ العرض التقديمي المعدل على القرص
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **تغيير خيارات تشغيل الصوت**

Aspose.Slides for Android via Java يتيح لك تعديل الخيارات التي تتحكم في تشغيل الصوت أو خصائصه. على سبيل المثال، يمكنك ضبط مستوى صوت الصوت، تشغيل الصوت بشكل متكرر، أو إخفاء أيقونة الصوت.

لوحة **Audio Options** في Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/AudioFrame) :

- **Start** القائمة المنسدلة تتطابق مع خاصية [AudioFrame.PlayMode](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) 
- **Volume** تتطابق مع خاصية [AudioFrame.Volume](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/AudioFrame#getVolume--) 
- **Play Across Slides** تتطابق مع خاصية [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) 
- **Loop until Stopped** تتطابق مع خاصية [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) 
- **Hide During Show** تتطابق مع خاصية [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) 
- **Rewind after Playing** تتطابق مع خاصية [AudioFrame.RewindAudio](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) 

PowerPoint **Editing** options التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/audioframe/) :

- **Fade In** تتطابق مع خاصية [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) 
- **Fade Out** تتطابق مع خاصية [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) 
- **Trim Audio Start Time** تتطابق مع خاصية [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) 
- **Trim Audio End Time** القيمة تساوي مدة الصوت ناقص قيمة خاصية [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) 

متحكم **Volume** في لوحة التحكم بالصوت في PowerPoint يتطابق مع خاصية [AudioFrame.VolumeValue](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/audioframe/#getVolumeValue--) . يتيح لك تغيير مستوى الصوت كنسبة مئوية.

إليك كيفية تعديل خيارات تشغيل الصوت:

1. [إنشاء](#create-audio-frame) أو الحصول على إطار الصوت.
2. تعيين قيم جديدة للخصائص التي ترغب في تعديلها في إطار الصوت.
3. حفظ ملف PowerPoint المعدل.

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // يحصل على شكل AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // يضبط وضع التشغيل للتشغيل عند النقر
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // يضبط مستوى الصوت إلى منخفض
    audioFrame.setVolume(AudioVolumeMode.Low);

    // يضبط الصوت للتشغيل عبر الشرائح
    audioFrame.setPlayAcrossSlides(true);

    // يعطل التكرار للصوت
    audioFrame.setPlayLoopMode(false);

    // يخفي AudioFrame خلال عرض الشرائح
    audioFrame.setHideAtShowing(true);

    // يرجع الصوت إلى البداية بعد التشغيل
    audioFrame.setRewindAudio(true);

    // يحفظ ملف PowerPoint على القرص
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

هذا المثال بلغة Java يوضح كيفية إضافة إطار صوت جديد مع صوت مدمج، تقصير المدة، وتعيين فترات التلاشي:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // يضبط إزاحة بداية القص إلى 1.5 ثانية
    audioFrame.setTrimFromStart(1500f);
    // يضبط إزاحة نهاية القص إلى 2 ثانية
    audioFrame.setTrimFromEnd(2000f);

    // يضبط مدة التلاشي التدريجي إلى 200 مللي ثانية
    audioFrame.setFadeInDuration(200f);
    // يضبط مدة التلاشي التدريجي للخروج إلى 500 مللي ثانية
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

العينة البرمجية التالية توضح كيفية استرجاع إطار صوت مدمج وتعيين مستوى صوته إلى 85٪:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // يحصل على شكل إطار صوت
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // يضبط مستوى الصوت إلى 85٪
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **إدارة ترجمات الصوت**

Aspose.Slides يتيح لك إضافة ترجمات مغلقة إلى إطار صوت عبر طريقة [getCaptionTracks](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) . تُرجع هذه الطريقة كائنًا من نوع [ICaptionsCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icaptionscollection/)، والذي يسمح لك بإضافة مسارات ترجمات WebVTT، التمرير عبر المسارات الموجودة، وإزالتها عند الحاجة.

**إضافة ترجمات صوتية**

استخدم طريقة [getCaptionTracks](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) لإرفاق مسار أو أكثر إلى إطار الصوت. في المثال التالي، يُضاف ملف صوت إلى شريحة، ثم يتم تحميل مسار ترجمة جديد من ملف `.vtt`.

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // أضف مسار توضيحات جديد من ملف WebVTT.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**استخراج ترجمات الصوت**

يمكنك التمرير عبر مسارات الترجمات المرتبطة بإطار الصوت وحفظها كملفات `.vtt`. كل مسار ترجمة يكشف عن بياناته الثنائية ومعرفه الفريد، وهو ما يمكن استخدامه عند تصدير الترجمات.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // احفظ مسار التوضيح كملف .vtt.
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

**إزالة ترجمات الصوت**

لإزالة الترجمات من إطار الصوت، استخدم الأساليب المتوفرة في [ICaptionsCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icaptionscollection/)، مثل [clear](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icaptionscollection/#clear--)، [remove](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) أو [removeAt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-). المثال التالي يزيل جميع مسارات الترجمات من إطار الصوت.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // إزالة جميع مسارات التوضيح من إطار الصوت.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **استخراج الصوت**

Aspose.Slides for Android via Java يتيح لك استخراج الصوت المستخدم في انتقالات العرض التقديمي. على سبيل المثال، يمكنك استخراج الصوت المستخدم في شريحة معينة.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation) وتحميل العرض التقديمي الذي يحتوي على الصوت.
2. الحصول على مرجع الشريحة ذات الصلة عبر فهرستها.
3. الوصول إلى [انتقالات العرض التقديمي](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) للشريحة.
4. استخراج الصوت كبيانات بايت.

هذا الكود بلغة Java يوضح كيفية استخراج الصوت المستخدم في شريحة:

```java
// ينشئ كائنًا من فئة Presentation تمثل ملف عرض تقديمي
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

## **الأسئلة الشائعة**

**هل يمكنني إعادة استخدام نفس ملف الصوت عبر عدة شرائح دون زيادة حجم الملف؟**

نعم. أضف الصوت مرة واحدة إلى [مجموعة الصوت المشتركة](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getAudios--) في العرض التقديمي وأنشئ إطارات صوتية إضافية تشير إلى هذا الأصل الموجود. هذا يمنع تكرار بيانات الوسائط ويحافظ على حجم العرض تحت التحكم.

**هل يمكنني استبدال الصوت في إطار صوت موجود دون إعادة إنشاء الشكل؟**

نعم. بالنسبة للصوت المرتبط، حدّث مسار [link path](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) ليشير إلى الملف الجديد. بالنسبة للصوت المدمج، استبدل كائن [embedded audio](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) بآخر من [مجموعة الصوت](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getAudios--) في العرض. تبقى تنسيقات الإطار ومعظم إعدادات التشغيل كما هي.

**هل يؤدي التقليم إلى تغيير بيانات الصوت الأساسية المخزنة في العرض؟**

لا. يقوم التقليم بتعديل حدود التشغيل فقط. تظل بايتات الصوت الأصلية دون تعديل وتكون متاحة عبر الصوت المدمج أو مجموعة الصوت في العرض.