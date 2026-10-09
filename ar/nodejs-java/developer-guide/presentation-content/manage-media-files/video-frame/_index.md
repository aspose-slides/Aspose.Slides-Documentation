---
title: إدارة إطارات الفيديو في العروض التقديمية باستخدام Node.js
linktitle: إطار الفيديو
type: docs
weight: 10
url: /ar/nodejs-java/video-frame/
keywords:
- إضافة فيديو
- إنشاء فيديو
- تضمين فيديو
- استخراج فيديو
- استرجاع فيديو
- إطار فيديو
- مصدر ويب
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجياً في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides لـ Node.js عبر Java. دليل سريع عملي."
---
## **المقدمة**

يمكن أن تساعد مقاطع الفيديو في شرح الأفكار وجذب الجمهور. يتيح لك Aspose.Slides لـ Node.js عبر Java إضافة إطارات فيديو إلى الشرائح، وضبط إعدادات التشغيل، وإدارة التسميات التوضيحية، واستخراج بيانات الفيديو المضمنة.

يدعم PowerPoint مقاطع الفيديو المحلية والروابط إلى مقاطع الفيديو على الإنترنت، مثل مقاطع YouTube.

لتمثيل بيانات الفيديو وإطارات الفيديو، يوفر Aspose.Slides الفئة [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) والفئة [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) وغيرها من الأنواع ذات الصلة.

## **إنشاء إطار فيديو مضمّن**

إذا كان ملف الفيديو الذي تريد إضافته إلى الشريحة مخزّنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في العرض التقديمي.

يُظهر هذا المثال كيفية تضمين فيديو محلي في الشريحة الأولى من عرض تقديمي موجود وحفظ النتيجة. إحداثيات الإطار وأبعاده بوحدة النقاط. يبقى التيار مفتوحًا حتى الانتهاء من الحفظ لأن [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) يبقيه مقفلاً بينما يستخدمه العرض التقديمي.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const slide = presentation.getSlides().get_Item(0);

        const video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

        presentation.save("embedded_video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

يمكنك أيضًا تمرير مسار الفيديو المحلي مباشرة إلى [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/). يُظهر هذا المثال كيفية تضمين الفيديو في الشريحة الأولى من عرض تقديمي جديد. يجب أن يظل الفيديو متاحًا حتى يتم حفظ العرض التقديمي.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إنشاء إطار فيديو باستخدام فيديو من مصدر ويب**

يدعم Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) مقاطع الفيديو عبر الإنترنت في العروض التقديمية. يمكنك إنشاء إطار فيديو يربط بفيديو على الإنترنت، مثل فيديو YouTube.

يضيف هذا المثال رابط فيديو YouTube وصورة مصغرة إلى الشريحة الأولى. استبدل معرف الفيديو لاستخدام فيديو آخر. طريقة [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) تطلب التشغيل التلقائي. تنزيل الصورة المصغرة وتشغيل الفيديو يتطلب اتصالًا بالإنترنت. يجب أن يدعم عارض العروض التقديمية تشغيل الفيديو عبر الإنترنت أيضًا.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoId = "aqz-KE-bpKQ";
    const videoUrl = "https://www.youtube.com/embed/" + videoId;
    const videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    const thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    const thumbnailLocation = java.newInstanceSync("java.net.URL", thumbnailUrl);
    const thumbnailStream = thumbnailLocation.openStream();
    try {
        const thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    } finally {
        thumbnailStream.close();
    }

    presentation.save("online_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تشغيل فيديو في وضع الشاشة الكاملة**

في عرض تقديمي تدريبي، يمكنك تشغيل عرض توضيحي للبرمجيات في وضع الشاشة الكاملة حتى يتمكن الجمهور من رؤية التفاصيل. استدعِ [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) مع `true` لتفعيل هذا السلوك أثناء التشغيل.

يفتح هذا المثال عرضًا تقديميًا، يبحث عن أول [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) في الشريحة الأولى، ويُفعّل تشغيل الشاشة الكاملة. يجب أن يحتوي عرض الإدخال على شريحة واحدة على الأقل تحتوي على إطار فيديو موجود في الشريحة الأولى.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تتحكم وضعية التشغيل الكاملة في طريقة عرض الفيديو. بشكل مستقل، تتحكم [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) في ما إذا كان يبدأ تلقائيًا أو عند النقر، وتتحكم [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) في ما إذا كان يتكرر. لاختيار سلوك البدء، اضبط وضع التشغيل على [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/). يحافظ المثال على إعدادات البدء والتكرار الحالية.

## **إعادة تشغيل الفيديو بعد الانتهاء من التشغيل**

في عرض تقديمي تدريبي، يعيد إرجاع فيديو العرض التوضيحي إلى بدايته جاهزيته للمقدم لتشغيله مرة أخرى. استدعِ [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) مع `true` لإرجاع الفيديو إلى البداية بعد انتهاء التشغيل.

يفتح هذا المثال عرضًا تقديميًا، يبحث عن أول [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) في الشريحة الأولى، ويُفعّل إعادة التشغيل. يعطل التكرار حتى يتمكن التشغيل من الانتهاء ويضبط التشغيل على البدء عند النقر. يجب أن يحتوي عرض الإدخال على شريحة واحدة على الأقل تحتوي على إطار فيديو موجود في الشريحة الأولى.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

إعادة التشغيل تُعيد الفيديو إلى بدايته دون بدء تشغيله مرة أخرى. على العكس، استدعاء [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) مع `true` يكرّر التشغيل تلقائيًا. أبقِ التكرار مُعطلاً عندما تريد أن ينتهي الفيديو ويبقى جاهزًا لإعادة التشغيل. تتحكم [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) بشكل مستقل في بدء التشغيل التلقائي أو عند النقر؛ يستخدم هذا المثال [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) بحيث يتحكم المقدم في موعد بدء التشغيل. اضبط وضع التشغيل بعد ضبط إعداد التكرار، كما هو موضح في المثال. تعمل إعادة التشغيل بشكل مستقل عن [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/).

## **قص جزء من إطار الفيديو**

استخدم [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) و[VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) لتخطي جزء من بداية أو نهاية الفيديو أثناء التشغيل. القيم بوحدة المللي ثانية. يغيّر القص إعدادات التشغيل دون تعديل بيانات الفيديو المضمنة.

**تعيين إعدادات القص**

يُظهر هذا المثال كيفية تضمين فيديو محلي وتخطي أول 2.5 ثانية وآخر ثانية أثناء التشغيل. استخدم فيديوً أطول من 3.5 ثانية لتبقى هناك مقطع قابل للتشغيل.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500);
    videoFrame.setTrimFromEnd(1000);

    presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**قراءة إعدادات القص**

يطبع هذا المثال قيم القص لإطار الفيديو الأول في الشريحة الأولى بالمللي ثانية. يجب أن يحتوي العرض التقديمي على شريحة واحدة على الأقل. إذا لم تحتوي الشريحة على إطار فيديو، لا يُطبع شيء. يُنتج المثال السابق القيم 2500 و1000.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            console.log("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            console.log("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **إدارة تسميات الفيديو**

يسمح Aspose.Slides لك بإدارة التسميات المغلقة لإطارات الفيديو في عروض PowerPoint. تُخزن التسميات بتنسيق WebVTT وتُتاح عبر طريقة [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks).

**إضافة تسميات إلى إطار فيديو**

يُظهر هذا المثال كيفية تضمين فيديو محلي وإضافة مسار تسمية WebVTT مسمى English. يجب أن تتطابق طوابع الوقت في التسمية مع الفيديو. يتضمن العرض التقديمي المحفوظ كلًا من الفيديو وتسمياته.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

توفر الفئة [CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) أيضًا طريقة [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream) لإضافة تسميات من تيار.

**استخراج تسميات من إطار فيديو**

يحفظ هذا المثال جميع مسارات التسميات من إطارات الفيديو في الشريحة الأولى كملفات WebVTT منفصلة. تُحافظ الأرقام المتسلسلة على تميز ملفات الإخراج. يُظهر سطر الأوامر عدد المسارات المستخرجة. يجب أن يحتوي العرض التقديمي على شريحة واحدة على الأقل.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let trackCount = 0;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            for (let trackIndex = 0; trackIndex < videoFrame.getCaptionTracks().getCount(); trackIndex++) {
                const captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                trackCount++;
                const outputPath = "captions_" + trackCount + ".vtt";
                const outputData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
            }
        }
    }

    console.log("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

كل كائن [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) يُظهر معرف التسمية، والملصق، والبيانات الثنائية، ونص التسمية كسلسلة UTF-8.

**إزالة تسميات من إطار فيديو**

يُظهر هذا المثال كيفية إزالة جميع التسميات من إطار الفيديو في أول موضع شكل في الشريحة الأولى وحفظ النتيجة. يفترض وجود الشريحة والشكل وأن الشكل هو إطار فيديو.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoFrame = slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

إذا كنت بحاجة إلى إزالة مسار تسمية واحد فقط، استخدم طريقة [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) أو [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) بدلاً من [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear).

## **استخراج فيديو من شريحة**

إلى جانب إضافة مقاطع الفيديو إلى الشرائح، يتيح Aspose.Slides استخراج مقاطع الفيديو المضمنة في العروض التقديمية.

يُظهر هذا المثال استخراج مقاطع الفيديو المضمنة من كل شريحة إلى ملفات ثنائية مرقمة منفصلة. تُهمل الفيديوهات المرتبطة لأنها لا تحتوي على بيانات مضمّنة. يعرض سطر الأوامر نوع MIME لكل فيديو وإجمالي عدد الفيديوهات. يستخدم الإخراج الامتداد العام `.bin`؛ غيّره ليتطابق مع نوع الوسائط المُعلن عند الحاجة.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("presentation_with_videos.pptx");
try {
    let videoCount = 0;
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                const videoFrame = shape;
                const video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    console.log("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                const outputPath = "extracted_video_" + videoCount + ".bin";
                const outputData = Buffer.from(video.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
                console.log("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    console.log("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **الأسئلة المتكررة**

**ما هي معلمات تشغيل الفيديو التي يمكن تغييرها لإطار فيديو؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/). تتوفر هذه الخيارات عبر طرق كائن [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/).

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عند تضمين فيديو محلي، تُضاف البيانات الثنائية إلى المستند، وبالتالي يزداد حجم العرض التقديمي proportionally لحجم الملف. عند ربط فيديو على الإنترنت وإضافة صورة مصغرة، يخزن العرض التقديمي الرابط وصورة المعاينة بدلًا من بيانات الفيديو، لذا عادةً ما يكون الزيادة أصغر.

**هل يمكن استبدال الفيديو في إطار فيديو موجود دون تغيير موضعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) داخل الإطار مع الحفاظ على شكل الهندسة؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المضمن؟**

نعم. يحتوي الفيديو المضمن على [نوع محتوى](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه إلى القرص.