---
title: مدیریت فریم‌های ویدئویی در ارائه‌ها با استفاده از JavaScript
linktitle: فریم ویدئویی
type: docs
weight: 10
url: /fa/nodejs-java/video-frame/
keywords:
- افزودن ویدئو
- ساخت ویدئو
- جاسازی ویدئو
- استخراج ویدئو
- بازیابی ویدئو
- فریم ویدئویی
- منبع وب
- پاورپوینت
- سند باز
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید به‌صورت برنامه‌نویسی فریم‌های ویدئویی را در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Node.js از طریق Java اضافه و استخراج کنید. راهنمای سریع گام‌به‌گام."
---
## **مقدمه**

یک ویدئوی مناسب در یک ارائه می‌تواند پیام شما را قانع‌کننده‌تر کند و سطح مشارکت مخاطبان را افزایش دهد.

PowerPoint به شما اجازه می‌دهد ویدئوها را به یک اسلاید در ارائه به دو روش اضافه کنید:

* افزودن یا جاسازی یک ویدئوی محلی (ذخیره‌شده بر روی دستگاه شما)
* افزودن یک ویدئوی آنلاین (از منبع وبی مانند YouTube).

برای افزودن ویدئوها (اشیاء ویدئویی) به یک ارائه، Aspose.Slides کلاس‌های [Video](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/video/)، [VideoFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/) و سایر انواع مرتبط را فراهم می‌کند.

## **ایجاد فریم ویدئوی جاسازی‌شده**

اگر فایل ویدئویی که می‌خواهید به اسلاید خود اضافه کنید به‌صورت محلی ذخیره شده باشد، می‌توانید یک فریم ویدئویی بسازید تا ویدئو را در ارائه خود جاسازی کنید.

1. یک نمونه از کلاس [Presentation ](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
1. یک شیء [Video](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/video/) اضافه کنید و مسیر فایل ویدئو را برای جاسازی ویدئو در ارائه بدهید.
1. یک شیء [VideoFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/) اضافه کنید تا فریمی برای ویدئو ایجاد شود.
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه یک ویدئوی ذخیره‌شده به‌صورت محلی را به یک ارائه اضافه کنید:

```javascript
// یک شی از کلاس Presentation را ایجاد می‌کند
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // ویدئو را بارگذاری می‌کند
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // اسلاید اول را به دست می‌آورد و یک فریم ویدئویی اضافه می‌کند
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // ارائه را روی دیسک ذخیره می‌کند
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

به‌جای آن، می‌توانید با عبور مسیر فایل ویدئو مستقیم به متد [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) ویدئویی اضافه کنید:

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

Microsoft [PowerPoint 2013 و جدیدتر](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) از ویدئوهای YouTube در ارائه‌ها پشتیبانی می‌کند. اگر ویدئویی که می‌خواهید استفاده کنید به‌صورت آنلاین در دسترس باشد (مثلاً در YouTube)، می‌توانید آن را از طریق لینک وب به ارائه‌تان اضافه کنید.

1. یک نمونه از کلاس [Presentation ](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
1. یک شیء [Video](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/video/) اضافه کنید و لینک ویدئو را به آن بدهید.
1. یک تصویر بندانگشتی برای فریم ویدئو تنظیم کنید.
1. ارائه را ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه یک ویدئوی وب را به یک اسلاید در ارائه PowerPoint اضافه کنید:

```javascript
// یک شی Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
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

## **مدیریت زیرنویس‌های ویدئو**

Aspose.Slides به شما امکان می‌دهد زیرنویس‌های بسته (closed captions) برای فریم‌های ویدئویی در ارائه‌های PowerPoint را مدیریت کنید. زیرنویس‌ها در قالب WebVTT ذخیره می‌شوند و از طریق متد [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) در دسترس هستند.

**افزودن زیرنویس به فریم ویدئویی**

برای افزودن زیرنویس به فریم ویدئویی:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. یک ویدئو به ارائه اضافه کنید.
1. یک شیء [VideoFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/) به یک اسلاید اضافه کنید.
1. از مجموعه [CaptionsCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/captionscollection/) برای افزودن یک مسیر زیرنویس WebVTT استفاده کنید.
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

کد زیر نشان می‌دهد چگونه زیرنویس‌ها را به یک فریم ویدئویی اضافه کنید:

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // یک مسیر زیرنویس جدید از فایل WebVTT اضافه می‌کند.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

کلاس [CaptionsCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/captionscollection/) همچنین متد [addFromStream](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/captionscollection/#addFromStream) را فراهم می‌کند که به شما اجازه می‌دهد زیرنویس‌ها را از یک جریان (stream) اضافه کنید.

**استخراج زیرنویس‌ها از فریم ویدئویی**

برای استخراج زیرنویس‌ها از فریم ویدئویی:

1. ارائه‌ای که حاوی ویدئو است را بارگذاری کنید.
1. شیء هدف [VideoFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/) را پیدا کنید.
1. بر مجموعهٔ [CaptionsCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/captionscollection/) تکرار کنید.
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
                // مسیر زیرنویس را در یک فایل WebVTT ذخیره می‌کند.
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

هر شیء [Captions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/captions/) شناسهٔ زیرنویس، برچسب، داده‌های باینری و متن زیرنویس را به‌عنوان یک رشته UTF-8 نمایش می‌دهد.

**حذف زیرنویس‌ها از فریم ویدئویی**

برای حذف زیرنویس‌ها از فریم ویدئویی:

1. ارائه‌ای که شامل ویدئو است را بارگذاری کنید.
1. شیء هدف [VideoFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/) را دریافت کنید.
1. مسیرهای زیرنویس را از مجموعهٔ [CaptionsCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/captionscollection/) حذف کنید.
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

کد زیر نشان می‌دهد چگونه تمام زیرنویس‌ها را از یک فریم ویدئویی حذف کنید:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // نوع: com.aspose.slides.VideoFrame

    // تمام زیرنویس‌ها را از فریم ویدئویی حذف می‌کند.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اگر فقط نیاز به حذف یک مسیر زیرنویس دارید، به جای [clear](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/captionscollection/#clear) از متدهای [remove](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/captionscollection/#remove) یا [removeAt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/captionscollection/#removeAt) استفاده کنید.

## **استخراج ویدئو از اسلاید**

علاوه بر افزودن ویدئوها به اسلایدها، Aspose.Slides به شما امکان می‌دهد ویدئوهای جاسازی‌شده در ارائه‌ها را استخراج کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) برای بارگذاری ارائه‌ای که حاوی ویدئو است ایجاد کنید.
2. بر تمام اشیاء [Slide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/) تکرار کنید.
3. بر تمام اشیاء [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/) تکرار کنید تا یک [VideoFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/) پیدا کنید.
4. ویدئو را روی دیسک ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه ویدئوی موجود در یک اسلاید ارائه را استخراج کنید:

```javascript
// یک شی Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
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

## **پرسش‌های متداول**

**کدام پارامترهای پخش ویدئو برای یک VideoFrame قابل تغییر هستند؟**

شما می‌توانید [حالت پخش](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/setplaymode/) (خودکار یا با کلیک) و [حلقه‌گذاری](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/setplayloopmode/) را کنترل کنید. این گزینه‌ها از طریق ویژگی‌های شیء [VideoFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن ویدئو بر اندازهٔ فایل PPTX تأثیر می‌گذارد؟**

بله. وقتی یک ویدئوی محلی را جاسازی می‌کنید، داده‌های باینری در سند گنجانده می‌شود، بنابراین اندازهٔ ارائه به نسبت اندازهٔ فایل افزایش می‌یابد. وقتی یک ویدئوی آنلاین را اضافه می‌کنید، فقط یک لینک و یک تصویر بندانگشتی جاسازی می‌شود، لذا افزایش اندازه کمتر است.

**آیا می‌توانم ویدئو را در یک VideoFrame موجود بدون تغییر موقعیت و اندازه‌اش جایگزین کنم؟**

بله. می‌توانید محتوای [ویدئو](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) را داخل فریم تعویض کنید در حالی که هندسهٔ شکل حفظ می‌شود؛ این یک سناریوی رایج برای به‌روزرسانی رسانه در یک طرح موجود است.

**آیا می‌توان نوع محتوا (MIME) یک ویدئوی جاسازی‌شده را تعیین کرد؟**

بله. یک ویدئوی جاسازی‌شده دارای یک [نوع محتوا](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/video/getcontenttype/) است که می‌توانید آن را بخوانید و استفاده کنید، به‌عنوان مثال هنگام ذخیره‌سازی روی دیسک.