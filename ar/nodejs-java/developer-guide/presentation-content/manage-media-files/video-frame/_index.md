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
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجيًا في شرائح PowerPoint و OpenDocument باستخدام Aspose.Slides لـ Node.js عبر Java. دليل سريع خطوة بخطوة."
---
## **مقدمة**

يمكن للفيديوهات أن تساعد في شرح الأفكار وإشراك الجمهور. يتيح Aspose.Slides لـ Node.js عبر Java إمكانية إضافة إطارات فيديو إلى الشرائح، وضبط إعدادات التشغيل، وإدارة التسميات التوضيحية، واستخراج بيانات الفيديو المضمَّنة.

يدعم PowerPoint مقاطع الفيديو المحلية والروابط إلى مقاطع الفيديو على الإنترنت، مثل مقاطع YouTube.

لتمثيل بيانات الفيديو وإطارات الفيديو، يوفر Aspose.Slides الفئة [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) الفئة [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) وأنواع أخرى ذات صلة.

## **إنشاء إطار فيديو مضمَّن**

إذا كان ملف الفيديو الذي تريد إضافته إلى شريحتك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في العرض التقديمي.

يُظهر هذا المثال كيفية تضمين فيديو محلي على الشريحة الأولى من عرض تقديمي موجود وحفظ النتيجة. إحداثيات الإطار وأبعاده بوحدات النقاط. يبقى التدفق مفتوحًا حتى ينتهي الحفظ لأن [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) يُبقيه مقفولًا أثناء استخدام العرض التقديمي له.

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

يمكنك أيضًا تمرير مسار الفيديو المحلي مباشرةً إلى [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/). يضمّن هذا المثال الفيديو على الشريحة الأولى من عرض تقديمي جديد. يجب أن يبقى الفيديو متاحًا حتى يتم حفظ العرض التقديمي.

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

## **إنشاء إطار فيديو مع فيديو من مصدر ويب**

يدعم Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) مقاطع الفيديو على الإنترنت في العروض التقديمية. يمكنك إنشاء إطار فيديو يربط إلى مقطع فيديو على الإنترنت، مثل مقطع YouTube.

يضيف هذا المثال رابط فيديو YouTube وصورة مصغرة إلى الشريحة الأولى. استبدل معرف الفيديو لتستخدم فيديوًا آخر. تطلب طريقة [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) تشغيلًا تلقائيًا. يتطلب تنزيل الصورة المصغرة وتشغيل الفيديو اتصالًا بالإنترنت. يجب أن يدعم عارض العرض التقديمي أيضًا تشغيل الفيديو عبر الإنترنت.

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

## **تشغيل فيديو في وضع ملء الشاشة**

في عرض تدريبي، يمكنك تشغيل عرض توضيحي للبرنامج في وضع ملء الشاشة حتى يتمكن الجمهور من رؤية التفاصيل. استدعِ [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) مع `true` لتمكين هذا السلوك أثناء التشغيل.

يفتح هذا المثال عرضًا تقديميًا، ويعثر على أول [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) في الشريحة الأولى، ويفعل تشغيل ملء الشاشة. يجب أن يحتوي عرض الإدخال على شريحة واحدة على الأقل تحتوي على إطار فيديو موجود في الشريحة الأولى.

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

يتحكم تشغيل ملء الشاشة في طريقة عرض الفيديو. بشكل مستقل، تتحكم طريقة [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) في ما إذا كان يبدأ تلقائيًا أو عند النقر، وتتحكم [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) في ما إذا كان يكرر. لاختيار سلوك البدء، اضبط وضع التشغيل إلى [VideoPlayModePreset.Auto أو VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/). يحافظ المثال على إعدادات البدء والتكرار الحالية.

## **إرجاع الفيديو إلى البداية بعد التشغيل**

في عرض تدريبي، يُعيد إرجاع فيديو العرض التوضيحي إلى بدايته الفيديو جاهزًا للمقدم لتشغيله مرة أخرى. استدعِ [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) مع `true` لإرجاع الفيديو إلى البداية بعد انتهاء التشغيل.

يفتح هذا المثال عرضًا تقديميًا، ويعثر على أول [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) في الشريحة الأولى، ويفعل الإرجاع. يوقف التكرار حتى يمكن انتهاء التشغيل ويحدد بدء التشغيل عند النقر. يجب أن يحتوي عرض الإدخال على شريحة واحدة على الأقل تحتوي على إطار فيديو موجود في الشريحة الأولى.

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

يُعيد الإرجاع الفيديو إلى بدايته دون بدء التشغيل مرة أخرى. على العكس، استدعاء [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) مع `true` يكرر التشغيل تلقائيًا. أبق التكرار معطَّلًا عندما تريد أن ينتهي الفيديو ويظل جاهزًا لإعادة التشغيل. تتحكم [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) بشكل مستقل في بدء التشغيل التلقائي أو عند النقر؛ يستخدم هذا المثال [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) بحيث يتحكم المقدم في توقيت بدء التشغيل. اضبط وضع التشغيل بعد ضبط التكرار، كما هو موضح في المثال. يعمل الإرجاع بشكل مستقل عن [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/).

## **قص إطار فيديو**

استخدم [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) و[VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) لتخطي جزء من بداية أو نهاية الفيديو أثناء التشغيل. القيمُ كلاهما بالميليثانية. يؤدي القص إلى تغيير إعدادات التشغيل دون تعديل بيانات الفيديو المضمَّنة.

**ضبط إعدادات القص**

يُظهر هذا المثال كيفية تضمين فيديوًا محليًا ويتخطى الثواني 2.5 الأولى والثانية الأخيرة أثناء التشغيل. استخدم فيديوًا أطول من 3.5 ثوانٍ حتى يبقى جزءًا قابلاً للتشغيل.

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

يطبع هذا المثال قيم القص لأول إطار فيديو في الشريحة الأولى بالميليثانية. يجب أن يحتوي العرض التقديمي على شريحة واحدة على الأقل. إذا لم تحتوي تلك الشريحة على إطار فيديو، لا يُطبع شيء. يُنتج المثال السابق القيم 2500 و1000.

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

يتيح Aspose.Slides لك إدارة التسميات المغلقة لإطارات الفيديو في عروض PowerPoint التقديمية. تُخزن التسميات بتنسيق WebVTT وتُعرض عبر طريقة [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks).

### **إضافة تسميات إلى إطار فيديو**

يضمّن هذا المثال فيديوًا محليًا ويضيف مسار تسميات WebVTT مُسمّى English. يجب أن تتطابق طوابع الوقت للتسميات مع الفيديو. يتضمن العرض التقديمي المحفوظ كلًّا من الفيديو وتسمياته.

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

توفر الفئة [CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) أيضًا طريقة [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream) لإضافة تسميات من تدفق.

### **استخراج التسميات من إطار فيديو**

يحفظ هذا المثال جميع مسارات التسميات من إطارات الفيديو في الشريحة الأولى كملفات WebVTT منفصلة. تحافظ الأرقام المتسلسلة على تمييز ملفات الإخراج. تُظهر وحدة التحكم عدد المسارات المستخرجة. يجب أن يحتوي العرض التقديمي على شريحة واحدة على الأقل.

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

كل كائن [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) يعرض معرّف التسمية، والملصق، والبيانات الثنائية، ونص التسمية كسلسلة UTF-8.

### **إزالة التسميات من إطار فيديو**

يُزيل هذا المثال جميع التسميات من إطار الفيديو في الموضع الأول للشكل في الشريحة الأولى ويحفظ النتيجة. يفترض أن الشريحة والشكل موجودان وأن الشكل هو إطار فيديو.

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

إذا كنت بحاجة لإزالة مسار تسمية واحد فقط، استخدم طرق [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) أو [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) بدلًا من [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear).

### **بحث عن تسميات الفيديو**

تعيد طريقة [Captions.getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) مسار WebVTT كامل، بما في ذلك الرأس، وخطوط التوقيت، ونص التسمية. يمكنك البحث في نص التسمية في الذاكرة للعثور على عبارة وتوقيتها. على سبيل المثال، قد يحتوي مسار إنجليزي على الشريحة 2 على هذه الإشارة:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

يفتح هذا المثال الملف `captioned_media.pptx` ويستخدم [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) لقراءة مسارات كل إطار فيديو من المستوى العلوي في جميع الشرائح. في إشارة نصية بسيطة، يحتوي خط التوقيت على `-->`، ويسطر فارغ ينهي الإشارة. لكل تسمية تحتوي على كلمة “café” بأي حالة حرفية، يطبع المثال رقم الشريحة، وملصق المسار، وخط التوقيت الأصلي، والتسمية الكاملة.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("captioned_media.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const shapes = slide.getShapes();
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            const shape = shapes.get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                continue;
            }

            const tracks = shape.getCaptionTracks();
            for (let trackIndex = 0; trackIndex < tracks.getCount(); trackIndex++) {
                const track = tracks.get_Item(trackIndex);
                const lines = track.getDataAsString().split(/\r\n|\n|\r/);
                for (let i = 0; i < lines.length; i++) {
                    const timing = lines[i];
                    if (!timing.includes("-->")) {
                        continue;
                    }
                    const start = i + 1;
                    i = start;
                    while (i < lines.length && lines[i] !== "") {
                        i++;
                    }
                    const caption = lines.slice(start, i).join("\n");
                    if (caption.toLowerCase().includes("café")) {
                        console.log(`Slide ${slide.getSlideNumber()} | ${track.getLabel()} | ${timing}`);
                        console.log(caption);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

يجد البحث عن “café” تطابقًا واحدًا في مسار العينة. يتخطى البحث رأس المسار ويحافظ على إعداد التوقيت وكسر السطر في الناتج.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **استخراج الفيديو من شريحة**

بالإضافة إلى إضافة الفيديوهات إلى الشرائح، يتيح Aspose.Slides استخراج الفيديوهات المضمَّنة في العروض التقديمية.

يستخرج هذا المثال الفيديوهات المضمَّنة من كل شريحة إلى ملفات ثنائية منفصلة مرقَّمة. تُتخطى الفيديوهات المرتبطة لأنها لا تحتوي على بيانات مضمَّنة. تُظهر وحدة التحكم نوع MIME لكل فيديو وإجمالي العدد. يستخدم الناتج الامتداد العام `.bin`؛ غيّره ليتطابق مع نوع الوسائط المُبلغ عنه عند الحاجة.

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

## **الأسئلة الشائعة**

**ما هي معلمات تشغيل الفيديو التي يمكن تغييرها لإطار الفيديو؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/). تتوفر هذه الخيارات عبر طرق كائن [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/).

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عندما تدمج فيديوًا محليًا، تُدرج البيانات الثنائية في المستند، لذا ينمو حجم العرض التقديمي بالتناسب مع حجم الملف. عندما تربط بفيديو على الإنترنت وتضيف صورة مصغرة، يخزن العرض التقديمي الرابط وصورة المعاينة بدلاً من بيانات الفيديو، لذا عادةً ما يكون الزيادة في الحجم أصغر.

**هل يمكن استبدال الفيديو في إطار فيديو موجود دون تغيير موضعه وحجمه؟**

نعم. يمكنك تبديل [محتوى الفيديو](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) داخل الإطار مع الحفاظ على هندسة الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المضمّن؟**

نعم. للفيديو المضمّن [نوع محتوى](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه إلى القرص.