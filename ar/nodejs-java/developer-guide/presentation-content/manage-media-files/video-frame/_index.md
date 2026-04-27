---
title: إدارة إطارات الفيديو في العروض التقديمية باستخدام JavaScript
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
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجياً في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides لـ Node.js عبر Java. دليل سريع خطوة بخطوة."
---

يمكن للفيديو الموضوع في الموضع المناسب داخل العرض التقديمي أن يجعل رسالتك أكثر جذبًا ويزيد من مستويات التفاعل مع جمهورك.

يتيح لك PowerPoint إضافة مقاطع فيديو إلى شريحة في عرض تقديمي بطريقتين:

* إضافة أو تضمين فيديو محلي (مخزن على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل YouTube).

للسماح لك بإضافة مقاطع فيديو (كائنات فيديو) إلى عرض تقديمي، توفر Aspose.Slides الفئة [Video](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/video/) الفئة [VideoFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/) وأنواع أخرى ذات صلة.

## **إنشاء إطار فيديو مدمج**

إذا كان ملف الفيديو الذي تريد إضافته إلى شريحتك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation) .
2. احصل على مرجع الشريحة عبر فهرستها.
3. أضف كائنًا من الفئة [Video](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/video/) ومرّر مسار ملف الفيديو لتضمين الفيديو مع العرض التقديمي.
4. أضف كائنًا من الفئة [VideoFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/) لإنشاء إطار للفيديو.
5. احفظ العرض التقديمي المعدل.

يعرض لك هذا الشيفرة JavaScript كيفية إضافة فيديو مخزن محليًا إلى عرض تقديمي:

```javascript
// ينشئ كائن من الفئة Presentation
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // يقوم بتحميل الفيديو
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // يحصل على الشريحة الأولى ويضيف إطار فيديو
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // يحفظ العرض التقديمي على القرص
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

بدلاً من ذلك، يمكنك إضافة فيديو بتمرير مسار ملفه مباشرةً إلى طريقة [addVideoFrame(float x,float y,float width,float height,IVideo video)](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) :

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

تدعم Microsoft [PowerPoint 2013 والإصدارات الأحدث](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) مقاطع فيديو YouTube في العروض التقديمية. إذا كان الفيديو الذي تريد استخدامه متاحًا عبر الإنترنت (مثلاً على YouTube)، يمكنك إضافته إلى عرضك التقديمي عبر الرابط الويب الخاص به.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation) .
2. احصل على مرجع الشريحة عبر فهرستها.
3. أضف كائنًا من الفئة [Video](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/video/) ومرّر الرابط إلى الفيديو.
4. عيّن صورة مصغرة لإطار الفيديو.
5. احفظ العرض التقديمي.

يعرض لك هذا الشيفرة JavaScript كيفية إضافة فيديو عبر الويب إلى شريحة في عرض PowerPoint:

```javascript
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
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

## **إدارة تسميات الفيديو**

تتيح لك Aspose.Slides إدارة الترجمة النصية المغلقة لإطارات الفيديو في عروض PowerPoint. يتم تخزين الترجمة بصيغة WebVTT وتُتاح عبر طريقة [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) .

**إضافة ترجمات إلى إطار فيديو**

لإضافة ترجمات إلى إطار فيديو:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) .
2. أضف فيديوًا إلى العرض التقديمي.
3. أضف كائنًا من الفئة [VideoFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/) إلى شريحة.
4. استخدم مجموعة [CaptionsCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/captionscollection/) لإضافة مسار ترجمة WebVTT.
5. احفظ العرض التقديمي المعدل.

يعرض لك الشيفرة التالية كيفية إضافة ترجمات إلى إطار فيديو:

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // يضيف مسار ترجمات جديد من ملف WebVTT.
    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تقدم فئة [CaptionsCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/captionscollection/) أيضًا طريقة [addFromStream](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/captionscollection/#addFromStream) التي تسمح لك بإضافة ترجمات من تدفق.

**استخراج الترجمات من إطار فيديو**

لاستخراج الترجمات من إطار فيديو:

1. حمّل العرض التقديمي الذي يحتوي على الفيديو.
2. اعثر على كائن [VideoFrame] الهدف.
3. تجول عبر مجموعة [CaptionsCollection].
4. احفظ كل مسار ترجمة في ملف `.vtt`.

يعرض لك الشيفرة التالية كيفية استخراج الترجمات من إطار فيديو:

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

كل كائن من فئة [Captions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/captions/) يُظهر معرف الترجمة، التسمة، البيانات الثنائية، ونص الترجمة كسلسلة UTF-8.

**إزالة الترجمات من إطار فيديو**

لإزالة الترجمات من إطار فيديو:

1. حمّل العرض التقديمي الذي يحتوي على الفيديو.
2. احصل على كائن [VideoFrame] الهدف.
3. أزل مسارات الترجمة من مجموعة [CaptionsCollection].
4. احفظ العرض التقديمي المعدل.

يعرض لك الشيفرة التالية كيفية إزالة جميع الترجمات من إطار فيديو:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // النوع: com.aspose.slides.VideoFrame

    // يزيل جميع الترجمات من إطار الفيديو.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

إذا كنت بحاجة إلى إزالة مسار ترجمة واحد فقط، استخدم طريقتي [remove](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/captionscollection/#remove) أو [removeAt](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/captionscollection/#removeAt) بدلاً من [clear](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/captionscollection/#clear).

## **استخراج الفيديو من الشريحة**

إلى جانب إضافة مقاطع فيديو إلى الشرائح، تتيح لك Aspose.Slides استخراج مقاطع الفيديو المدمجة في العروض التقديمية.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation) لتحميل العرض التقديمي الذي يحتوي على الفيديو.
2. تجول عبر جميع كائنات [Slide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/).
3. تجول عبر جميع كائنات [Shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/) للعثور على [VideoFrame].
4. احفظ الفيديو على القرص.

يعرض لك هذا الشيفرة JavaScript كيفية استخراج الفيديو من شريحة عرض تقديمي:

```javascript
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
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

## **الأسئلة المتكررة**

**ما هي معلمات تشغيل الفيديو التي يمكن تغييرها لإطار الفيديو؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/setplaymode/) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/setplayloopmode/). تتوفر هذه الخيارات عبر خصائص كائن [VideoFrame].

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عند تضمين فيديو محلي، تُدرج البيانات الثنائية في المستند، وبالتالي يزداد حجم العرض التقديمي بنسبة حجم الملف. عندما تضيف فيديوًا عبر الإنترنت، يُضمن رابط وصورة مصغرة فقط، لذا يكون الزيادة أصغر.

**هل يمكنني استبدال الفيديو في إطار فيديو موجود دون تغيير موقعه أو حجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) داخل الإطار مع الحفاظ على هندسة الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) لفيديو مدمج؟**

نعم. للفيديو المدمج [نوع محتوى](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/video/getcontenttype/) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه على القرص.