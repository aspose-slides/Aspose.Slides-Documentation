---
title: إدارة الصوت في العروض التقديمية باستخدام JavaScript
linktitle: إطار صوت
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
- استخراج الصوت
- Node.js
- JavaScript
- Aspose.Slides
description: "إنشاء والتحكم في إطارات الصوت في Aspose.Slides لـ Node.js—أمثلة JavaScript لإدماج، تقليم، تكرار، وتكوين التشغيل عبر عروض PPT و PPTX و ODP."
---

## **إنشاء إطارات صوتية**

Aspose.Slides for Node.js via Java يتيح لك إضافة ملفات صوتية إلى الشرائح. تُدمج ملفات الصوت في الشرائح كإطارات صوتية.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرستها.
3. تحميل تدفق ملف الصوت الذي تريد دمجه في الشريحة.
4. إضافة إطار الصوت المدمج (الذي يحتوي على ملف الصوت) إلى الشريحة.
5. تعيين [PlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AudioPlayModePreset) و`Volume` المعروضة بواسطة كائن [AudioFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AudioFrame).
6. حفظ العرض التقديمي المعدل.

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
    // تعيين وضع التشغيل ومستوى الصوت للملف الصوتي
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


## **تغيير صورة مصغرة لإطار الصوت**

عند إضافة ملف صوت إلى عرض تقديمي، يظهر الصوت كإطار يحتوي على صورة افتراضية قياسية (انظر الصورة في القسم أدناه). يمكنك تغيير صورة المعاينة لإطار الصوت (تعيين الصورة التي تفضلها).

هذا الكود JavaScript يوضح لك كيفية تغيير صورة مصغرة أو صورة معاينة لإطار الصوت:
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
    // يحدد الصورة لإطار الصوت.
    audioFrame.getPictureFormat().getPicture().setImage(picture);// <-----
    // يحفظ العرض التقديمي المعدل على القرص
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **تغيير خيارات تشغيل الصوت**

Aspose.Slides for Node.js via Java يتيح لك تعديل الخيارات التي تتحكم في تشغيل الصوت أو خصائصه. على سبيل المثال، يمكنك ضبط مستوى صوت الصوت، أو تشغيل الصوت بصورة متكررة، أو حتى إخفاء أيقونة الصوت.

لوحة **Audio Options** في Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/) هي:
- **Start** قائمة منسدلة تتطابق مع طريقة [AudioFrame.setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode).
- **Volume** تتطابق مع طريقة [AudioFrame.setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume).
- **Play Across Slides** تتطابق مع طريقة [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides).
- **Loop until Stopped** تتطابق مع طريقة [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode).
- **Hide During Show** تتطابق مع طريقة [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setHideAtShowing).
- **Rewind after Playing** تتطابق مع طريقة [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setRewindAudio).

PowerPoint **Editing** options التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/):
- **Fade In** تتطابق مع طريقة [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeInDuration).
- **Fade Out** تتطابق مع طريقة [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration).
- **Trim Audio Start Time** تتطابق مع طريقة [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart).
- **Trim Audio End Time** القيمة تساوي مدة الصوت ناقص قيمة طريقة [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd).

تحكم **Volume** في لوحة التحكم بالصوت في PowerPoint يتطابق مع طريقة [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue). يتيح لك تعديل مستوى الصوت كنسبة مئوية.

هذه هي طريقة تغيير خيارات تشغيل الصوت:
1. [Сreate](#create-audio-frame) أو الحصول على إطار الصوت.
2. تعيين قيم جديدة لخصائص إطار الصوت التي تريد تعديلها.
3. حفظ ملف PowerPoint المعدل.

```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // يحصل على شكل AudioFrame
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // يضبط وضع التشغيل لتشغيل عند النقر
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // يضبط مستوى الصوت إلى منخفض
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // يضبط الصوت لتشغيل عبر الشرائح
    audioFrame.setPlayAcrossSlides(true);
    // يعطل الحلقة للصوت
    audioFrame.setPlayLoopMode(false);
    // يخفي AudioFrame أثناء عرض الشرائح
    audioFrame.setHideAtShowing(true);
    // يعيد تشغيل الصوت من البداية بعد التشغيل
    audioFrame.setRewindAudio(true);
    // يحفظ ملف PowerPoint على القرص
    pres.save("AudioFrameEmbed_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


هذا الكود JavaScript يوضح عملية تعديل خيارات الصوت:
```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // يضبط إزاحة بداية التقليم إلى 1.5 ثانية
    audioFrame.setTrimFromStart(1500);
    // يضبط إزاحة نهاية التقليم إلى 2 ثانية
    audioFrame.setTrimFromEnd(2000);

    // يضبط مدة التلاشي التدريجي للبدء إلى 200 مللي ثانية
    audioFrame.setFadeInDuration(200);
    // يضبط مدة التلاشي التدريجي للنهاية إلى 500 مللي ثانية
    audioFrame.setFadeOutDuration(500);

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


العينة التالية من الكود توضح كيفية استرداد إطار صوت مدمج وتعيين مستوى صوته إلى 85%:
```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // يحصل على شكل إطار صوت
    const audioFrame = slide.getShapes().get_Item(0);

    // يضبط مستوى الصوت إلى 85%
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```


## **استخراج الصوت**

Aspose.Slides for Node.js via Java يتيح لك استخراج الصوت المستخدم في انتقالات عرض الشرائح. على سبيل المثال، يمكنك استخراج الصوت المستخدم في شريحة معينة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) وتحميل العرض التقديمي الذي يحتوي على الصوت.
2. الحصول على مرجع الشريحة ذات الصلة عبر فهرستها.
3. الوصول إلى [slideshow transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--) الخاصة بالشريحة.
4. استخراج الصوت على شكل بيانات بايت.

هذا الكود JavaScript يوضح لك كيفية استخراج الصوت المستخدم في شريحة:
```javascript
// ينشئ كائن من فئة Presentation التي تمثل ملف عرض تقديمي
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // يصل إلى الشريحة المطلوبة
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


## **الأسئلة المتكررة**

**هل يمكنني إعادة استخدام نفس ملف الصوت عبر عدة شرائح دون زيادة حجم الملف؟**

نعم. أضف الصوت مرة واحدة إلى [audio collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getaudios/) المشترك في العرض التقديمي وأنشئ إطارات صوت إضافية تشير إلى ذلك الأصل الموجود. هذا يمنع تكرار بيانات الوسائط ويحافظ على حجم العرض التقديمي تحت السيطرة.

**هل يمكنني استبدال الصوت في إطار صوت موجود دون إعادة إنشاء الشكل؟**

نعم. بالنسبة لصوت مرتبط، قم بتحديث [link path](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/setlinkpathlong/) للإشارة إلى الملف الجديد. بالنسبة لصوت مدمج، استبدل كائن [embedded audio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/setembeddedaudio/) بآخر من [audio collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getaudios/) الموجود في العرض التقديمي. يبقى تنسيق الإطار ومعظم إعدادات التشغيل كما هي.

**هل يؤدي التقليم إلى تغيير بيانات الصوت الأساسية المخزنة في العرض التقديمي؟**

لا. يقتصر التقليم على تعديل حدود التشغيل فقط. تبقى بايتات الصوت الأصلية دون تغيير ويمكن الوصول إليها عبر الصوت المدمج أو مجموعة الصوت في العرض التقديمي.