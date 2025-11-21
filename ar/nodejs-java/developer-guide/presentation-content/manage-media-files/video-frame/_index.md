---
title: إطار الفيديو
type: docs
weight: 10
url: /ar/nodejs-java/video-frame/
keywords: "إضافة فيديو, إنشاء إطار فيديو, استخراج فيديو, عرض تقديمي PowerPoint, Java, Aspose.Slides لـ Node.js عبر Java"
description: "إضافة إطار فيديو إلى عرض تقديمي PowerPoint باستخدام JavaScript"
---

يمكن للفيديو الموضوع بشكل جيد في عرض تقديمي أن يجعل رسالتك أكثر إقناعًا ويزيد من مستويات التفاعل مع جمهورك. 

PowerPoint يتيح لك إضافة مقاطع فيديو إلى شريحة في عرض تقديمي بطريقتين:

* إضافة أو تضمين فيديو محلي (مخزن على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل يوتيوب).

لتمكينك من إضافة مقاطع فيديو (كائنات فيديو) إلى عرض تقديمي، توفر Aspose.Slides فئة [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/)، وفئة [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/)، وغيرها من الأنواع ذات الصلة.

## **إنشاء إطار فيديو مضمّن**

إذا كان ملف الفيديو الذي ترغب في إضافته إلى شريحتك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي.

1. إنشاء كائن من فئة [Presentation ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)class.
1. الحصول على مرجع الشريحة عبر الفهرس الخاص بها. 
1. إضافة كائن [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) وتمرير مسار ملف الفيديو لتضمين الفيديو مع العرض التقديمي.
1. إضافة كائن [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) لإنشاء إطار للفيديو.
1. حفظ العرض التقديمي المعدل. 

يظهر لك هذا الشيفرة JavaScript كيفية إضافة فيديو مخزن محليًا إلى عرض تقديمي:
```javascript
// ينشئ فئة Presentation
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // يحمل الفيديو
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // يحصل على الشريحة الأولى ويضيف إطار فيديو
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // يحفظ العرض التقديمي إلى القرص
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


بدلاً من ذلك، يمكنك إضافة فيديو بتمرير مسار ملفه مباشرةً إلى طريقة [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) method:
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


## **إنشاء إطار فيديو مع فيديو من مصدر ويب**

تدعم Microsoft [PowerPoint 2013 وما بعده](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) مقاطع فيديو YouTube في العروض التقديمية. إذا كان الفيديو الذي تريد استخدامه متاحًا عبر الإنترنت (مثلًا على YouTube)، يمكنك إضافته إلى عرضك التقديمي من خلال الرابط الخاص به. 

1. إنشاء كائن من فئة [Presentation ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)class
1. الحصول على مرجع الشريحة عبر الفهرس الخاص بها. 
1. إضافة كائن [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) وتمرير الرابط إلى الفيديو.
1. تعيين صورة مصغرة لإطار الفيديو. 
1. حفظ العرض التقديمي. 

يظهر لك هذا الشيفرة JavaScript كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint التقديمي:
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


## **استخراج الفيديو من الشريحة**

إلى جانب إضافة مقاطع الفيديو إلى الشرائح، يسمح لك Aspose.Slides باستخراج مقاطع الفيديو المضمّنة في العروض التقديمية.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class لتحميل العرض التقديمي الذي يحتوي على الفيديو.
2. التكرار عبر جميع كائنات [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/).
3. التكرار عبر جميع كائنات [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) للعثور على [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/).
4. حفظ الفيديو إلى القرص.

يظهر لك هذا الشيفرة JavaScript كيفية استخراج الفيديو من شريحة في عرض تقديمي:
```javascript
// ينشئ كائن Presentation الذي يمثل ملف عرض تقديمي
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
                // الحصول على امتداد الملف
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


## **التعليمات المتكررة**

**ما هي معايير تشغيل الفيديو التي يمكن تغييرها لإطار الفيديو (VideoFrame)؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/). هذه الخيارات متاحة عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/).

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عندما تقوم بتضمين فيديو محلي، تُدرج البيانات الثنائية داخل المستند، لذا يزداد حجم العرض التقديمي بنسبة حجم الملف. عندما تضيف فيديو عبر الإنترنت، يتم تضمين رابط وصورة مصغرة، لذلك الزيادة في الحجم تكون أصغر.

**هل يمكنني استبدال الفيديو في إطار فيديو موجود دون تغيير موقعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) داخل الإطار مع الحفاظ على هندسة الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المضمن؟**

نعم. يحتوي الفيديو المضمن على [نوع محتوى](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه إلى القرص.