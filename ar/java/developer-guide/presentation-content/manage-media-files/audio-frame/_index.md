---
title: إدارة الصوت في العروض التقديمية باستخدام Java
linktitle: إطار صوتي
type: docs
weight: 10
url: /ar/java/audio-frame/
keywords:
- صوت
- إطار صوتي
- صورة مصغرة
- إضافة صوت
- خصائص الصوت
- خيارات الصوت
- استخراج الصوت
- Java
- Aspose.Slides
description: "إنشاء والتحكم في إطارات الصوت في Aspose.Slides for Java—أمثلة على الشيفرة لتضمين، قص، تشغيل متكرر، وتكوين التشغيل عبر عروض PPT و PPTX و ODP."
---
## **إنشاء إطارات صوتية**

Aspose.Slides for Java يسمح لك بإضافة ملفات صوتية إلى الشرائح. يتم تضمين ملفات الصوت في الشرائح كإطارات صوتية. 

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation) .
2. الحصول على مرجع الشريحة عبر فهرسها.
3. تحميل تدفق ملف الصوت الذي تريد تضمينه في الشريحة.
4. إضافة إطار الصوت المضمّن (الذي يحتوي على ملف الصوت) إلى الشريحة.
5. ضبط [PlayMode](https://reference.aspose.com/slides/ar/java/com.aspose.slides/AudioPlayModePreset) و `Volume` المعروضة بواسطة كائن [IAudioFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IAudioFrame) .
6. حفظ العرض التقديمي المعدَّل.

يعرض لك هذا الكود بلغة Java كيفية إضافة إطار صوتي مضمّن إلى شريحة:

```java
// ينشئ مثيلًا لفئة Presentation التي تمثل ملف عرض تقديمي
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // يحمّل ملف الصوت wav إلى تدفق
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

عند إضافة ملف صوتي إلى عرض تقديمي، يظهر الصوت كإطار يحتوي على صورة افتراضية قياسية (انظر الصورة في القسم أدناه). يمكنك تغيير صورة المعاينة لإطار الصوت (تعيين الصورة التي تفضلها).

يعرض لك هذا الكود بلغة Java كيفية تغيير الصورة المصغرة أو صورة المعاينة لإطار الصوت:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // يضيف إطارًا صوتيًا إلى الشريحة بموقع وحجم محددين.
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

    // يحفظ العرض التقديمي المعدّل إلى القرص
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **تغيير خيارات تشغيل الصوت**

Aspose.Slides for Java يسمح لك بتغيير الخيارات التي تتحكم في تشغيل الصوت أو خصائصه. على سبيل المثال، يمكنك تعديل حجم الصوت، ضبط تشغيل الصوت بشكل متكرر، أو حتى إخفاء أيقونة الصوت.

لوحة **Audio Options** في Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

خيارات **Audio Options** في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/AudioFrame) :

- **Start** في القائمة المنسدلة يطابق طريقة [AudioFrame.setPlayMode](https://reference.aspose.com/slides/ar/java/com.aspose.slides/audioframe/#setPlayMode-int-) .
- **Volume** يطابق طريقة [AudioFrame.setVolume](https://reference.aspose.com/slides/ar/java/com.aspose.slides/audioframe/#setVolume-int-) .
- **Play Across Slides** يطابق طريقة [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-) .
- **Loop until Stopped** يطابق طريقة [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/ar/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-) .
- **Hide During Show** يطابق طريقة [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/ar/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-) .
- **Rewind after Playing** يطابق طريقة [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/ar/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-) .

خيارات **Editing** في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/AudioFrame) :

- **Fade In** يطابق طريقة [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/ar/java/com.aspose.slides/audioframe/#setFadeInDuration-float-) .
- **Fade Out** يطابق طريقة [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/ar/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-) .
- **Trim Audio Start Time** يطابق طريقة [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/ar/java/com.aspose.slides/audioframe/#setTrimFromStart-float-) .
- **Trim Audio End Time** القيمة تساوي مدة الصوت مطروحًا منها قيمة طريقة [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/ar/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-) .

يتطابق **مفتاح التحكم في مستوى الصوت** في PowerPoint على لوحة التحكم الصوتية مع طريقة [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/ar/java/com.aspose.slides/audioframe/#setVolumeValue-float-) . يتيح لك تعديل مستوى صوت الصوت كنسبة مئوية.

هذه هي طريقة تغيير خيارات تشغيل الصوت:

1. [إنشاء](#create-audio-frame) أو الحصول على إطار الصوت.
2. ضبط القيم الجديدة لخصائص إطار الصوت التي ترغب في تعديلها.
3. حفظ ملف PowerPoint المعدَّل.

يعرض لك هذا الكود بلغة Java عملية تعديل خيارات الصوت:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // يحصل على شكل AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // يضبط وضع التشغيل على التشغيل عند النقر
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

يعرض لك هذا المثال بلغة Java كيفية إضافة إطار صوت جديد مع صوت مضمّن، تقصيره، وضبط فترات التلاشي:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // يضبط إزاحة بدء القص إلى 1.5 ثانية
    audioFrame.setTrimFromStart(1500f);
    // يضبط إزاحة نهاية القص إلى 2 ثانية
    audioFrame.setTrimFromEnd(2000f);

    // يضبط مدة التلاشي التدريجي إلى 200 مللي ثانية
    audioFrame.setFadeInDuration(200f);
    // يضبط مدة التلاشي الخروج إلى 500 مللي ثانية
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

تظهر عينة الكود التالية كيفية استرجاع إطار صوت مضمّن وتعيين مستوى صوته إلى 85٪:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // يحصل على شكل إطار صوتي
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // يضبط مستوى صوت الإطار إلى 85٪
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **إدارة توضيحات الصوت**

Aspose.Slides يتيح لك إضافة توضيحات مغلقة إلى إطار الصوت عبر طريقة [getCaptionTracks](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) . تُعيد هذه الطريقة كائنًا من نوع [ICaptionsCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icaptionscollection/)، والذي يتيح لك إضافة مسارات توضيحات WebVTT، التجول عبر المسارات الموجودة، وإزالتها عند الضرورة.

**إضافة توضيحات صوتية**

استخدم طريقة [getCaptionTracks](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) لإرفاق مسار أو أكثر من مسارات التوضيح إلى إطار الصوت. في المثال التالي، يتم إضافة ملف صوتي إلى شريحة، ثم يتم تحميل مسار توضيح جديد من ملف `.vtt` .

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // أضف مسار توضيحات جديد من ملف WebVTT.
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**استخراج توضيحات الصوت**

يمكنك التجول عبر مسارات التوضيح المرتبطة بإطار الصوت وحفظها كملفات `.vtt`. كل مسار توضيح يعرض بياناته الثنائية ومعرّفه الفريد، والذي يمكن استخدامه عند تصدير التوضيحات.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame ) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // احفظ مسار التوضيح كملف .vtt.
                Path filePath = Paths.get(captionTrack.getCaptionId() + ".vtt");
                Files.write(filePath, captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**إزالة توضيحات الصوت**

لإزالة التوضيحات من إطار الصوت، استخدم الطرق المتوفرة في [ICaptionsCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icaptionscollection/)، مثل [clear](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icaptionscollection/#clear--)، [remove](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-)، أو [removeAt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icaptionscollection/#removeAt-int-) . يوضح المثال التالي إزالة جميع مسارات التوضيح من إطار الصوت.

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

Aspose.Slides for Java يتيح لك استخراج الصوت المستخدم في انتقالات عرض الشرائح. على سبيل المثال، يمكنك استخراج الصوت المستخدم في شريحة معينة.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation) وتحميل العرض التقديمي الذي يحتوي على الصوت.
2. الحصول على مرجع الشريحة ذات الصلة عبر فهرسها.
3. الوصول إلى [slideshow transitions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) الخاصة بالشريحة.
4. استخراج الصوت على شكل بيانات بايت.

يعرض لك هذا الكود بلغة Java كيفية استخراج الصوت المستخدم في شريحة:

```java
// ينشئ كائنًا من فئة Presentation التي تمثل ملف عرض تقديمي
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

**هل يمكنني إعادة استخدام ملف الصوت نفسه عبر شرائح متعددة دون زيادة حجم الملف؟**

نعم. أضف الصوت مرة واحدة إلى مجموعة الصوت المشتركة في العرض التقديمي، وأنشئ إطارات صوت إضافية تشير إلى ذلك الأصل الموجود. يمنع ذلك تكرار بيانات الوسائط ويحافظ على التحكم في حجم العرض.

**هل يمكنني استبدال الصوت في إطار صوت موجود دون إعادة إنشاء الشكل؟**

نعم. بالنسبة للصوت المرتبط، حدّث [link path](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) للإشارة إلى الملف الجديد. بالنسبة للصوت المضمّن، استبدل كائن [embedded audio](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) بآخر من مجموعة الصوت في العرض التقديمي. يظل تنسيق الإطار ومعظم إعدادات التشغيل كما هي.

**هل يؤدي القص إلى تغيير بيانات الصوت الأساسية المخزنة في العرض التقديمي؟**

لا. يضبط القص حدود التشغيل فقط. تظل بايتات الصوت الأصلية غير متغيرة ويمكن الوصول إليها عبر الصوت المضمن أو مجموعة الصوت في العرض التقديمي.