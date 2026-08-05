---
title: مدیریت فریم‌های ویدئویی در ارائه‌ها با استفاده از JavaScript
linktitle: فریم ویدئو
type: docs
weight: 10
url: /fa/nodejs-java/video-frame/
keywords:
- افزودن ویدئو
- ایجاد ویدئو
- جاسازی ویدئو
- استخراج ویدئو
- بازیابی ویدئو
- فریم ویدئو
- منبع وب
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یادگیری افزودن و استخراج فریم‌های ویدئویی به‌صورت برنامه‌نویسی در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Node.js به‌وسیله Java. راهنمای سریع نحوه کار."
---
## **مقدمه**

یک ویدئوی به‌خوبی قرار گرفته در یک ارائه می‌تواند پیام شما را قانع‌کننده‌تر کند و سطح تعامل با مخاطبان را افزایش دهد. 

PowerPoint به شما امکان می‌دهد ویدئوها را به یک اسلاید در یک ارائه به دو روش اضافه کنید:

* یک ویدئوی محلی اضافه یا جاسازی کنید (ذخیره‌شده بر روی دستگاه شما)
* یک ویدئوی آنلاین اضافه کنید (از منبع وب مانند YouTube).

برای اینکه بتوانید ویدئوها (اشیای ویدئویی) را به یک ارائه اضافه کنید، Aspose.Slides کلاس‌های [Video](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/video/)، [VideoFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/) و سایر انواع مرتبط را ارائه می‌دهد.

## **ایجاد فریم ویدئوی جاسازی‌شده**

اگر فایل ویدئویی که می‌خواهید به اسلاید خود اضافه کنید به‌صورت محلی ذخیره شده باشد، می‌توانید یک فریم ویدئویی ایجاد کنید تا ویدئو را در ارائه خود جاسازی کنید. 

1. یک نمونه از کلاس [Presentation ](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
1. با استفاده از اندیس آن، مرجع یک اسلاید را دریافت کنید. 
1. یک شیء [Video](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/video/) اضافه کنید و مسیر فایل ویدئو را برای جاسازی ویدئو در ارائه پاس دهید.
1. یک شیء [VideoFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/) اضافه کنید تا فریمی برای ویدئو ایجاد شود.
1. ارائه‌ی اصلاح‌شده را ذخیره کنید. 

این کد JavaScript نشان می‌دهد چگونه یک ویدئوی ذخیره‌شده به‌صورت محلی را به یک ارائه اضافه کنید:

```javascript
// نمونه‌سازی کلاس Presentation
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // ویدئو را بارگذاری می‌کند
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // اسلاید اول را دریافت می‌کند و یک فریم ویدئویی اضافه می‌کند
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // ارائه را بر روی دیسک ذخیره می‌کند
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

به‌طور جایگزین، می‌توانید با پاس دادن مسیر فایل ویدئو مستقیماً به متد [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) ویدئو را اضافه کنید:

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

## **ایجاد فریم ویدئویی با ویدئویی از منبع وب**

Microsoft [PowerPoint 2013 و جدیدتر](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) از ویدئوهای YouTube در ارائه‌ها پشتیبانی می‌کند. اگر ویدئویی که می‌خواهید استفاده کنید به صورت آنلاین موجود باشد (مثلاً در YouTube)، می‌توانید آن را از طریق لینک وب به ارائه خود اضافه کنید. 

1. یک نمونه از کلاس [Presentation ](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید
1. با استفاده از اندیس آن، مرجع یک اسلاید را دریافت کنید. 
1. یک شیء [Video](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/video/) اضافه کنید و لینک به ویدئو را پاس دهید.
1. یک تصویر بند انگشتی برای فریم ویدئو تنظیم کنید. 
1. ارائه را ذخیره کنید. 

این کد JavaScript نشان می‌دهد چگونه یک ویدئوی آنلاین را به یک اسلاید در ارائه PowerPoint اضافه کنید:

```javascript
// نمونه‌سازی یک شیء Presentation که نمایانگر یک فایل ارائه است
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

## **قاطع‌سازی فریم ویدئویی**

Aspose.Slides به شما امکان می‌دهد بخش پخش ویدئو را با تنظیم مقادیر trim‑from‑start و trim‑from‑end از طریق [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/settrimfromstart/) و [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/settrimfromend/) کنترل کنید. هر دو مقدار بر حسب میلی‌ثانیه مشخص می‌شوند و تعیین می‌کنند چه مقدار زمان از ابتدای و انتهای ویدئو به ترتیب پرش شود. این تنظیمات فقط تنظیمات پخش ویدئو در ارائه را تغییر می‌دهند؛ داده‌های باینری ویدئوی جاسازی‌شده را قطع یا تغییر نمی‌دهند.

**تنظیمات برش**

برای ایجاد یک فریم ویدئوی و تنظیم مقادیر برش آن:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. یک شیء [Video](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/video/) به ارائه اضافه کنید.
1. یک شیء [VideoFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/) به یک اسلاید اضافه کنید.
1. مقادیر trim‑from‑start و trim‑from‑end را از طریق [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/settrimfromstart/) و [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/settrimfromend/) تنظیم کنید.
1. ارائه‌ی اصلاح‌شده را ذخیره کنید.

کد زیر اولین ۲٫۵ ثانیه و یک ثانیه انتهای یک ویدئوی جاسازی‌شده را در زمان پخش نادیده می‌گیرد:

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

**خواندن تنظیمات برش**

برای بررسی تنظیمات برش موجود، یک ارائه را بارگذاری کنید، یک شیء [VideoFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/) را در میان اشکال اسلاید اول پیدا کنید و مقادیر را از طریق [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/gettrimfromstart/) و [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/gettrimfromend/) بخوانید.

کد زیر اولین فریم ویدئویی در اسلاید اول را پیدا می‌کند و تنظیمات برش آن را بر حسب میلی‌ثانیه گزارش می‌دهد:

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

## **مدیریت زیرنویس‌های ویدئو**

Aspose.Slides به شما امکان می‌دهد زیرنویس‌های بسته (closed captions) برای فریم‌های ویدئویی در ارائه‌های PowerPoint را مدیریت کنید. زیرنویس‌ها در قالب WebVTT ذخیره می‌شوند و از طریق متد [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) در دسترس هستند.

**افزودن زیرنویس به فریم ویدئو**

برای افزودن زیرنویس به فریم ویدئو:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. یک ویدئو به ارائه اضافه کنید.
1. یک شیء [VideoFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/) به اسلاید اضافه کنید.
1. از مجموعه [CaptionsCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/captionscollection/) برای افزودن یک مسیر زیرنویس WebVTT استفاده کنید.
1. ارائه‌ی اصلاح‌شده را ذخیره کنید.

کد زیر نشان می‌دهد چگونه زیرنویس‌ها را به یک فریم ویدئویی اضافه کنید:

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // یک مسیر زیرنویس جدید از یک فایل WebVTT اضافه می‌کند.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

کلاس [CaptionsCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/captionscollection/) همچنین متد [addFromStream](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/captionscollection/#addFromStream) را ارائه می‌دهد که به شما اجازه می‌دهد زیرنویس‌ها را از یک جریان (stream) اضافه کنید.

**استخراج زیرنویس‌ها از فریم ویدئو**

برای استخراج زیرنویس‌ها از فریم ویدئو:

1. ارائه‌ای که شامل ویدئو است را بارگذاری کنید.
1. شیء [VideoFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/) هدف را پیدا کنید.
1. در مجموعه [CaptionsCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/captionscollection/) پیمایش کنید.
1. هر مسیر زیرنویس را در یک فایل `.vtt` ذخیره کنید.

کد زیر نشان می‌دهد چگونه زیرنویس‌ها را از یک فریم ویدئویی استخراج کنید:

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
                // یک مسیر زیرنویس را به یک فایل WebVTT ذخیره می‌کند.
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

هر شیء [Captions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/captions/) شناسهٔ زیرنویس، برچسب، داده باینری و متن زیرنویس را به‌صورت رشتهٔ UTF‑8 ارائه می‌کند.

**حذف زیرنویس‌ها از فریم ویدئو**

برای حذف زیرنویس‌ها از فریم ویدئو:

1. ارائه‌ای که شامل ویدئو است را بارگذاری کنید.
1. شیء [VideoFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/) هدف را دریافت کنید.
1. مسیرهای زیرنویس را از مجموعه [CaptionsCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/captionscollection/) حذف کنید.
1. ارائه‌ی اصلاح‌شده را ذخیره کنید.

کد زیر نشان می‌دهد چگونه تمام زیرنویس‌ها را از یک فریم ویدئویی حذف کنید:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // نوع: com.aspose.slides.VideoFrame

    // تمام زیرنویس‌ها را از فریم ویدئو حذف می‌کند.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اگر نیاز به حذف تنها یک مسیر زیرنویس دارید، به‌جای متد [clear](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/captionscollection/#clear) از متدهای [remove](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/captionscollection/#remove) یا [removeAt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/captionscollection/#removeAt) استفاده کنید.

## **استخراج ویدئو از اسلاید**

علاوه بر افزودن ویدئوها به اسلایدها، Aspose.Slides به شما امکان می‌دهد ویدئوهای جاسازی‌شده در ارائه‌ها را استخراج کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید تا ارائه‌ای که شامل ویدئو است بارگذاری شود.
2. در تمام اشیاء [Slide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/) پیمایش کنید.
3. در تمام اشیاء [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/) پیمایش کنید تا یک [VideoFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/) پیدا شود.
4. ویدئو را روی دیسک ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه ویدئوی موجود در یک اسلاید ارائه را استخراج کنید:

```javascript
// نمونه‌سازی یک شیء Presentation که نمایانگر یک فایل ارائه است
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
                // پسوند فایل را دریافت می‌کند
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

## **سوالات متداول**

**کدام پارامترهای پخش ویدئو می‌توان برای VideoFrame تغییر داد؟**

می‌توانید حالت پخش ([playback mode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/setplaymode/)) (به‌صورت خودکار یا با کلیک) و حلقه‌زدن ([looping](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/setplayloopmode/)) را کنترل کنید. این گزینه‌ها از طریق ویژگی‌های شیء [VideoFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن یک ویدئو بر اندازه فایل PPTX تاثیر می‌گذارد؟**

بله. وقتی یک ویدئوی محلی را جاسازی می‌کنید، داده‌های باینری در سند گنجانده می‌شوند، بنابراین اندازه ارائه متناسب با حجم فایل افزایش می‌یابد. وقتی یک ویدئوی آنلاین را اضافه می‌کنید، فقط یک لینک و تصویر بند انگشتی جاسازی می‌شود، لذا افزایش اندازه کمتر است.

**آیا می‌توان ویدئوی موجود در یک VideoFrame را بدون تغییر موقعیت و اندازه آن جایگزین کرد؟**

بله. می‌توانید محتوای ویدئو ([video content](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/setembeddedvideo/)) را داخل فریم تعویض کنید در حالی که شکل (geometry) حفظ می‌شود؛ این سناریوی رایجی برای به‌روزرسانی رسانه در یک طرح موجود است.

**آیا می‌توان نوع محتوا (MIME) یک ویدئوی جاسازی‌شده را تعیین کرد؟**

بله. یک ویدئوی جاسازی‌شده دارای یک [content type](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/video/getcontenttype/) است که می‌توانید آن را بخوانید و استفاده کنید، برای مثال هنگام ذخیره‌سازی بر روی دیسک.