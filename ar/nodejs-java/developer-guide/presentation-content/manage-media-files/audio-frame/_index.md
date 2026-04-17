---
title: إدارة الصوت في العروض التقديمية باستخدام JavaScript
linktitle: إطار الصوت
type: docs
weight: 10
url: /ar/nodejs-java/audio-frame/
keywords:
- صوت
- إطار صوت
- صورة مصغرة
- إضافة صوت
- خصائص الصوت
- خيارات الصوت
- استخراج صوت
- Node.js
- JavaScript
- Aspose.Slides
description: "إنشاء والتحكم في إطارات الصوت في Aspose.Slides لـ Node.js—أمثلة على تضمين، قص، تشغيل متكرر، وتكوين التشغيل عبر عروض PPT و PPTX و ODP."
---
## **إنشاء إطارات صوتية**

Aspose.Slides for Node.js via Java يتيح لك إضافة ملفات صوتية إلى الشرائح. يتم تضمين ملفات الصوت في الشرائح كإطارات صوتية.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation).
2. احصل على مرجع الشريحة من خلال فهرستها.
3. حمِّل تدفق ملف الصوت الذي تريد تضمينه في الشريحة.
4. أضف إطار الصوت المضمن (الذي يحتوي على ملف الصوت) إلى الشريحة.
5. عيّن [PlayMode](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/AudioPlayModePreset) و `Volume` المتاحين عبر كائن [AudioFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/AudioFrame).
6. احفظ العرض التقديمي المعدل.

يظهر لك هذا الكود JavaScript كيفية إضافة إطار صوت مضمّن إلى شريحة:

```javascript
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي
const pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    const sld = pres.getSlides().get_Item(0);
    // تحميل ملف الصوت wav إلى تدفق
    const fstr = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));
    // إضافة إطار صوت
    const audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    // تعيين وضع التشغيل ومستوى الصوت للإطار الصوتي
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Loud);
    // كتابة ملف PowerPoint إلى القرص
    pres.save("AudioFrameEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تغيير الصورة المصغرة لإطار الصوت**

عند إضافة ملف صوتي إلى عرض تقديمي، يظهر الصوت كإطار يحتوي على صورة افتراضية قياسية (انظر الصورة في القسم أدناه). يمكنك تغيير صورة معاينة إطار الصوت (حدد الصورة المفضلة لديك).

يظهر لك هذا الكود JavaScript كيفية تغيير الصورة المصغرة أو صورة المعاينة لإطار الصوت:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    // يضيف إطار صوت إلى الشريحة بموقع وحجم محددين.
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample2.mp3");
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();
    // يضيف صورة إلى موارد العرض التقديمي.
    let picture;
    const image = aspose.slides.Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // يعيّن الصورة لإطار الصوت.
    audioFrame.getPictureFormat().getPicture().setImage(picture);// <-----
    // Saves the modified presentation to disk
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **تغيير خيارات تشغيل الصوت**

Aspose.Slides for Node.js via Java يتيح لك تغيير الخيارات التي تتحكم في تشغيل الصوت أو خصائصه. على سبيل المثال، يمكنك تعديل حجم الصوت، أو ضبط تشغيل الصوت في حلقة، أو حتى إخفاء أيقونة الصوت.

لوحة **Audio Options** في Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

خيارات **Audio Options** في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/audioframe/) :

- **Start** القائمة المنسدلة تتطابق مع طريقة [AudioFrame.setPlayMode](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/audioframe/#setPlayMode).
- **Volume** يتطابق مع طريقة [AudioFrame.setVolume](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/audioframe/#setVolume).
- **Play Across Slides** يتطابق مع طريقة [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides).
- **Loop until Stopped** يتطابق مع طريقة [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode).
- **Hide During Show** يتطابق مع طريقة [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/audioframe/#setHideAtShowing).
- **Rewind after Playing** يتطابق مع طريقة [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/audioframe/#setRewindAudio).

خيارات **Editing** في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/audioframe/) :

- **Fade In** يتطابق مع طريقة [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/audioframe/#setFadeInDuration).
- **Fade Out** يتطابق مع طريقة [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration).
- **Trim Audio Start Time** يتطابق مع طريقة [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/audioframe/#setTrimFromStart).
- **Trim Audio End Time** القيمة تساوي مدة الصوت ناقص قيمة طريقة [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd).

يتطابق عنصر **Volume controll** في PowerPoint على لوحة التحكم بالصوت مع طريقة [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/audioframe/#setVolumeValue). يسمح لك بتغيير مستوى الصوت كنسبة مئوية.

إليك كيفية تغيير خيارات تشغيل الصوت:

1. [إنشاء](#create-audio-frame) أو الحصول على إطار الصوت.
2. عيّن القيم الجديدة لخصائص إطار الصوت التي تريد تعديلها.
3. احفظ ملف PowerPoint المعدل.

يظهر لك هذا الكود JavaScript عملية تعديل خيارات الصوت:

```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // يحصل على شكل AudioFrame
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // يضبط وضع التشغيل ليتم تشغيله عند النقر
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // يضبط مستوى الصوت إلى منخفض
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // يضبط تشغيل الصوت عبر الشرائح
    audioFrame.setPlayAcrossSlides(true);
    // يعطل التكرار للصوت
    audioFrame.setPlayLoopMode(false);
    // يخفي إطار الصوت أثناء عرض الشرائح
    audioFrame.setHideAtShowing(true);
    // يعيد تشغيل الصوت من البداية بعد التشغيل
    audioFrame.setRewindAudio(true);
    // يحفظ ملف PowerPoint إلى القرص
    pres.save("AudioFrameEmbed_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

يظهر لك هذا المثال JavaScript كيفية إضافة إطار صوت جديد مع صوت مضمّن، قصه، وتعيين مدة التلاشي:

```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // يحدد إزاحة بداية القطع إلى 1.5 ثانية
    audioFrame.setTrimFromStart(1500);
    // يحدد إزاحة نهاية القطع إلى ثانيتين
    audioFrame.setTrimFromEnd(2000);

    // يحدد مدة التلاشي داخل إلى 200 ملليثانية
    audioFrame.setFadeInDuration(200);
    // يحدد مدة التلاشي خارج إلى 500 ملليثانية
    audioFrame.setFadeOutDuration(500);

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

يوضح المثال البرمجي التالي كيفية استرجاع إطار صوت مضمّن وتعيين مستوى الصوت إلى 85٪:

```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // يحصل على شكل إطار صوت
    const audioFrame = slide.getShapes().get_Item(0);

    // يضبط حجم الصوت إلى 85%
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **إدارة تسميات صوتية**

Aspose.Slides يتيح لك إضافة تسميات مغلقة إلى إطار الصوت عبر طريقة [getCaptionTracks](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/audioframe/#getCaptionTracks). ترجع هذه الطريقة [CaptionsCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/captionscollection/)، والتي تتيح لك إضافة مسارات تسميات WebVTT، والتكرار عبر المسارات الموجودة، وإزالتها عند الحاجة.

**إضافة تسميات صوتية**

استخدم طريقة [getCaptionTracks] لإرفاق مسار أو أكثر من مسارات التسمية إلى إطار الصوت. في المثال التالي، يتم إضافة ملف صوت إلى شريحة، ثم يتم تحميل مسار تسمية جديد من ملف `.vtt`.

```js
let presentation = new aspose.slides.Presentation();
try {
    let audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.mp3");
    let audio = presentation.getAudios().addAudio(audioStream);
    audioStream.close();

    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // إضافة مسار توضيحات جديد من ملف WebVTT.
    presentation.save("audio_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**استخراج تسميات صوتية**

يمكنك التكرار عبر مسارات التسمية المرتبطة بإطار الصوت وحفظها كملفات `.vtt`. كل مسار تسمية يكشف عن بياناته الثنائية ومعرفه الفريد، والذي يمكن استخدامه عند تصدير التسميات.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            let audioFrame = shape;
            let trackCount = audioFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = audioFrame.getCaptionTracks().get_Item(trackIndex);
                // احفظ مسار التسمية كملف .vtt.
                let filePath = captionTrack.getCaptionId() + ".vtt";
                let captionData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(filePath, captionData);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**إزالة تسميات صوتية**

لإزالة التسميات من إطار الصوت، استخدم الطرق المتوفرة في [CaptionsCollection] مثل [clear](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/captionscollection/#clear)، [remove](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/captionscollection/#remove) أو [removeAt](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/captionscollection/#removeAt). يوضح المثال التالي كيفية إزالة جميع مسارات التسمية من إطار الصوت.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().get_Item(0); // النوع: aspose.slides.AudioFrame

    // إزالة جميع مسارات التسمية من إطار الصوت.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **استخراج الصوت**

Aspose.Slides for Node.js via Java يتيح لك استخراج الصوت المستخدم في انتقالات عرض الشرائح. على سبيل المثال، يمكنك استخراج الصوت المستخدم في شريحة معينة.

1. إنشاء مثيل من فئة [Presentation] وتحميل العرض التقديمي الذي يحتوي على الصوت.
2. الحصول على مرجع الشريحة ذات الصلة عبر فهرستها.
3. الوصول إلى [slideshow transitions] للشريحة.
4. استخراج الصوت كبيانات بايت.

يظهر لك هذا الكود JavaScript كيفية استخراج الصوت المستخدم في شريحة:

```javascript
// ينشئ كائنًا من فئة Presentation يمثل ملف عرض تقديمي
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // الوصول إلى الشريحة المطلوبة
    const slide = pres.getSlides().get_Item(0);
    // يحصل على تأثيرات انتقال عرض الشرائح للشريحة
    const transition = slide.getSlideShowTransition();
    // يستخرج الصوت كمصفوفة بايت
    const audio = transition.getSound().getBinaryData();
    console.log("Length: " + audio.length);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **الأسئلة الشائعة**

**هل يمكنني إعادة استخدام نفس ملف الصوت عبر شرائح متعددة دون زيادة حجم الملف؟**

نعم. أضف الصوت مرة واحدة إلى [audio collection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getaudios/) المشتركة في العرض التقديمي ثم أنشئ إطارات صوت إضافية تشير إلى ذلك المورد الموجود. هذا يتجنب تكرار البيانات الإعلامية ويحافظ على حجم العرض تحت السيطرة.

**هل يمكنني استبدال الصوت في إطار صوت موجود دون إعادة إنشاء الشكل؟**

نعم. بالنسبة لملف صوت مرتبط، حدّث [link path](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/audioframe/setlinkpathlong/) ليشير إلى الملف الجديد. بالنسبة لملف صوت مدمج، استبدل كائن [embedded audio](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/audioframe/setembeddedaudio/) بآخر من [audio collection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getaudios/) الخاصة بالعرض التقديمي. تظل تنسيق الإطار ومعظم إعدادات التشغيل كما هي.

**هل يغير القص البيانات الصوتية الأساسية المخزنة في العرض التقديمي؟**

لا. يقتصر القص على تعديل حدود التشغيل فقط. تبقى بايتات الصوت الأصلية دون تغيير وتظل متاحة عبر الصوت المدمج أو مجموعة الصوت في العرض التقديمي.