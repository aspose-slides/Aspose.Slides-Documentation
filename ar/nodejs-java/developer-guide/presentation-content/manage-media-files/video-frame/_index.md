---
title: إدارة إطارات الفيديو في العروض التقديمية باستخدام JavaScript
linktitle: إطار الفيديو
type: docs
weight: 10
url: /ar/nodejs-java/video-frame/
keywords:
- إضافة فيديو
- إنشاء فيديو
- دمج فيديو
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
description: "تعلم كيف تضيف وتستخرج إطارات الفيديو برمجيًا في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides لـ Node.js عبر Java. دليل سريع خطوة بخطوة."
---
## **مقدمة**

يمكن للفيديو الموضوع بشكل مناسب في العرض أن يجعل رسالتك أكثر إقناعًا ويزيد من مستوى تفاعل الجمهور معك. 

PowerPoint يتيح لك إضافة مقاطع فيديو إلى شريحة في عرض تقديمي بطريقتين:

* إضافة أو دمج فيديو محلي (محفوظ على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل YouTube).

للسماح لك بإضافة مقاطع فيديو (كائنات فيديو) إلى عرض تقديمي، توفر Aspose.Slides فئة [Video](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/video/)، وفئة [VideoFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/)، وغيرها من الأنواع ذات الصلة.

## **إنشاء إطار فيديو مدمج**

إذا كان ملف الفيديو الذي تريد إضافته إلى شريحةك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لدمج الفيديو في عرضك التقديمي. 

1. إنشاء مثال من فئة [Presentation ](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation)class.
1. الحصول على مرجع الشريحة عبر فهرستها. 
1. إضافة كائن [Video](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/video/) وتمرير مسار ملف الفيديو لدمج الفيديو مع العرض التقديمي.
1. إضافة كائن [VideoFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/) لإنشاء إطار للفيديو.
1. حفظ العرض التقديمي المعدل. 

يظهر لك هذا الكود JavaScript كيفية إضافة فيديو مخزن محليًا إلى عرض تقديمي:

```javascript
// إنشاء مثيل لفئة Presentation
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // تحميل الفيديو
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // الحصول على الشريحة الأولى وإضافة إطار فيديو
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // حفظ العرض التقديمي إلى القرص
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

بدلاً من ذلك، يمكنك إضافة فيديو بتمرير مسار ملفه مباشرة إلى طريقة [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) :

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إنشاء إطار فيديو باستخدام فيديو من مصدر ويب**

يدعم Microsoft [PowerPoint 2013 والإصدارات الأحدث](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) مقاطع فيديو YouTube في العروض التقديمية. إذا كان الفيديو الذي تريد استخدامه متاحًا عبر الإنترنت (مثلًا على YouTube)، يمكنك إضافته إلى عرضك التقديمي عبر الرابط الإلكتروني الخاص به. 

1. إنشاء مثال من فئة [Presentation ](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation)class
1. الحصول على مرجع الشريحة عبر فهرستها. 
1. إضافة كائن [Video](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/video/) وتمرير الرابط إلى الفيديو.
1. تعيين صورة مصغرة لإطار الفيديو. 
1. حفظ العرض التقديمي. 

يظهر لك هذا الكود JavaScript كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint:

```javascript
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
async function addVideoFromYouTube(pres, videoID) {
    let slide = pres.getSlides().get_Item(0);
    let videoUrl = "https://www.youtube.com/embed/" + videoID;
    let videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    let thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";

    try {
        const imageStream = await getImageStream(thumbnailUri);
        let image = pres.getImages().addImage(imageStream);
        videoFrame.getPictureFormat().getPicture().setImage(image);
    } catch (error) {
        console.error("Error loading thumbnail:", error);
    }
}

async function getImageStream(url) {
    return new Promise((resolve, reject) => {
        http.get(url, (response) => {
            if (response.statusCode === 200) {
                resolve(response);
            } else {
                reject(new Error(`Failed to load image: ${response.statusCode}`));
            }
        }).on('error', (e) => {
            reject(e);
        });
    });
}
```

## **قص إطار فيديو**

تتيح لك Aspose.Slides التحكم في الجزء الذي يُشغل من الفيديو عن طريق ضبط قيمتي trim-from-start و trim-from-end من خلال [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/settrimfromstart/) و [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/settrimfromend/). يتم تحديد القيمتين بالميليثانية وتحدد مقدار الوقت الذي يتم تخطيه من بداية الفيديو ونهايته، على التوالي. هذه الإعدادات تغير إعدادات تشغيل الفيديو في العرض التقديمي؛ ولا تقوم بقطع أو تعديل بيانات الفيديو المدمجة.

**ضبط إعدادات القص**

لإنشاء إطار فيديو وضبط إعدادات القص الخاصة به:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/)class.
1. إضافة كائن [Video](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/video/) إلى العرض التقديمي.
1. إضافة كائن [VideoFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/) إلى شريحة.
1. ضبط قيمتي trim-from-start و trim-from-end من خلال [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/settrimfromstart/) و [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/settrimfromend/) .
1. حفظ العرض التقديمي المعدل.

يتخطى مثال الكود التالي أول 2.5 ثانية والثانية الأخيرة من فيديو مدمج أثناء التشغيل:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const video = presentation.getVideos().addVideo(
            videoStream, aspose.slides.LoadingStreamBehavior.ReadStreamAndRelease);
        const slide = presentation.getSlides().get_Item(0);
        const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500);
        videoFrame.setTrimFromEnd(1000);

        presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**قراءة إعدادات القص**

لفحص إعدادات القص الحالية، حمّل عرضًا تقديميًا، واعثر على كائن [VideoFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/) بين الأشكال على الشريحة الأولى، واقرأ القيم من خلال [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/gettrimfromstart/) و [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/gettrimfromend/) .

يعثر مثال الكود التالي على أول إطار فيديو في الشريحة الأولى ويعرض إعدادات القص الخاصة به بالميليثانية:

```javascript
const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            const trimFromStart = videoFrame.getTrimFromStart();
            const trimFromEnd = videoFrame.getTrimFromEnd();

            console.log("Trim from start: " + trimFromStart + " ms");
            console.log("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **إدارة ترجمات الفيديو**

تتيح لك Aspose.Slides إدارة الترجمات المغلقة لإطارات الفيديو في عروض PowerPoint. تُخزن الترجمات بصيغة WebVTT وتُتاح عبر طريقة [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) .

**إضافة ترجمات إلى إطار فيديو**

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/)class.
1. إضافة فيديو إلى العرض التقديمي.
1. إضافة كائن [VideoFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/) إلى شريحة.
1. استخدام مجموعة [CaptionsCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/captionscollection/) لإضافة مسار ترجمة WebVTT.
1. حفظ العرض التقديمي المعدل.

يعرض لك الكود التالي كيفية إضافة ترجمات إلى إطار فيديو:

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // إضافة مسار ترجمات جديد من ملف WebVTT.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

توفر فئة [CaptionsCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/captionscollection/) أيضًا طريقة [addFromStream](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/captionscollection/#addFromStream) التي تتيح لك إضافة الترجمات من تدفق.

**استخراج الترجمات من إطار فيديو**

1. تحميل العرض التقديمي الذي يحتوي على الفيديو.
1. العثور على كائن [VideoFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/) المستهدف.
1. التنقل عبر مجموعة [CaptionsCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/captionscollection/) .
1. حفظ كل مسار ترجمة إلى ملف `.vtt` .

يعرض لك الكود التالي كيفية استخراج الترجمات من إطار فيديو:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            let videoFrame = shape;
            let trackCount = videoFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                // يحفظ مسار الترجمات إلى ملف WebVTT.
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

كل كائن [Captions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/captions/) يكشف عن معرّف الترجمة، والوسم، والبيانات الثنائية، ونص الترجمة كسلسلة UTF-8.

**إزالة الترجمات من إطار فيديو**

1. تحميل العرض التقديمي الذي يحتوي على الفيديو.
1. الحصول على كائن [VideoFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/) المستهدف.
1. إزالة مسارات الترجمات من مجموعة [CaptionsCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/captionscollection/) .
1. حفظ العرض التقديمي المعدل.

يعرض لك الكود التالي كيفية إزالة جميع الترجمات من إطار فيديو:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // النوع: com.aspose.slides.VideoFrame

    // إزالة جميع الترجمات من إطار الفيديو.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

إذا كنت تحتاج إلى إزالة مسار ترجمة واحد فقط، استخدم طريقة [remove](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/captionscollection/#remove) أو [removeAt](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/captionscollection/#removeAt) بدلاً من [clear](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/captionscollection/#clear).


## **استخراج فيديو من الشريحة**

إلى جانب إضافة مقاطع فيديو إلى الشرائح، تسمح لك Aspose.Slides باستخراج مقاطع الفيديو المدمجة في العروض التقديمية.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation)class لتحميل العرض التقديمي الذي يحتوي على الفيديو.
2. التنقل عبر جميع كائنات [Slide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/) .
3. التنقل عبر جميع كائنات [Shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/) للعثور على [VideoFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/) .
4. حفظ الفيديو إلى القرص.

يعرض لك هذا الكود JavaScript كيفية استخراج الفيديو من شريحة عرض تقديمي:

```javascript
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation("VideoSample.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                var vf = shape;
                console.log(shape);
                var type = vf.getEmbeddedVideo().getContentType();
                var ss = type.lastIndexOf('-');
                const buffer = Buffer.from(vf.getEmbeddedVideo().getBinaryData());
                console.log(buffer);
                // يحصل على امتداد الملف
                var charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);
                fs.writeFileSync("testing2." + type, buffer);
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **الأسئلة الشائعة**

**ما هي معايير تشغيل الفيديو التي يمكن تغييرها لإطار الفيديو؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/setplaymode/) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/setplayloopmode/). هذه الخيارات متاحة عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/) .

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عندما تقوم بدمج فيديو محلي، تُضمّن البيانات الثنائية في المستند، وبالتالي يزيد حجم العرض التقديمي نسبةً لحجم الملف. عندما تضيف فيديوًا عبر الإنترنت، يتم دمج رابط وصورة مصغرة، لذا تكون الزيادة في الحجم أصغر.

**هل يمكنني استبدال الفيديو في إطار فيديو موجود دون تغيير موقعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) داخل الإطار مع الحفاظ على هندسة الشكل؛ وهذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) لفيديو مدمج؟**

نعم. للفيديو المدمج [نوع محتوى](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/video/getcontenttype/) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه إلى القرص.